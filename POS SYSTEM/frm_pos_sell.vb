Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Npgsql
Imports NpgsqlTypes

Public Class frm_pos_sell

    ' --- 0. Control Variables ---
    Private isCalculatingDiscount As Boolean = False
    Private v_LastPaymentCurrency As String = "USD" ' Tracks the currency of the last payment added
    Private v_LastPaymentRate As Decimal = 1D          ' Tracks the rate of the last payment added (e.g., 4100 for KHR)
    Private v_DeliveryId As Integer = 0 ' ⭐ CORRECTED: Private variable to hold the delivery ID ⭐
    Private v_DeliveryDate As Date = Date.Today ' Private variable to hold the delivery date

    ' ⭐ ADDED: Variable to hold the instance of the second display form ⭐
    Private v_DisplayForm As frm_display_second


    ' ⭐ NEW: Public Sub to receive data from frm_dl_list ⭐
    Public Sub SetDeliveryInfo(ByVal deliveryId As Integer, ByVal deliveryName As String)
        v_DeliveryId = deliveryId
        lblDelivery.Text = deliveryName
        v_DeliveryDate = Date.Today ' Use current date as the default delivery date
    End Sub

    Public Class DisplayItemInfo
        Public Property ItemCode As String
        Public Property Description As String
        Public Property Quantity As Decimal
        Public Property Price As Decimal
        Public Property NetPrice As Decimal
        Public Property TotalKHR As String
        Public Property TotalTHB As String
        Public Property TotalPaid As String
        Public Property Totalqty As String
    End Class

    ' --- 1. Window Management (Moving the borderless form) ---
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_TitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btn_Minimize_Click(sender As Object, e As EventArgs) Handles btn_Minimize.Click
        WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_Maximize_Click(sender As Object, e As EventArgs) Handles btn_Maximize.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        ' Close the secondary display form when the main form closes
        If v_DisplayForm IsNot Nothing AndAlso Not v_DisplayForm.IsDisposed Then
            v_DisplayForm.Close()
        End If
        Me.Close()
    End Sub
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Close the secondary display form when logging out/exiting
        If v_DisplayForm IsNot Nothing AndAlso Not v_DisplayForm.IsDisposed Then
            v_DisplayForm.Close()
        End If
        Application.Exit()
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 2. Constants, Database Configuration, and API Client ---
    ' ---------------------------------------------------------------------
    Private Const V_ProjectName As String = "POS System"
    Private Const v_FormatNo As String = "0.00"
    Private ReadOnly db As New PostgreSQLConnection() ' Placeholder for your DB connection class
    Private v_LastLineDisPct As Decimal = 0D ' Stores the percentage from the last line discount entry
    Private Const API_BASE_URL As String = "http://localhost:5005" ' Your Node.js API server address
    Private ReadOnly httpClient As New HttpClient() ' HttpClient instance for API calls
    Private Const V_StoreId As String = "S001" ' Store ID
    Private Const V_CashierId As String = "C001" ' Logged-in cashier ID (Replace with actual login variable)
    Private Const V_StoreName As String = "Positron Store"
    Private Const V_CashierName As String = "Cashier Name"

    ' ---------------------------------------------------------------------
    ' --- 3. Form Load and DataGridView Initialization ---
    ' ---------------------------------------------------------------------
    Private Async Sub frm_pos_sell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.None
        InitializeDataGridViewLayout()
        PaymentConfrim()

        ' ⭐ REVISED: Fetch the latest rates from the API instead of hardcoding ⭐
        Await FetchExchangeRates()

        ' Initialize fields to zero on load (Discount is 0, VAT amount is 0)
        txtPercentage.Text = 0D.ToString(v_FormatNo)
        txtCheckDiscountAmt.Text = 0D.ToString(v_FormatNo)
        txtVat.Text = 0D.ToString(v_FormatNo)
        txtShippingFee.Text = 0D.ToString(v_FormatNo)

        cbNonVat.Checked = True
        txtVat.ReadOnly = True
        txtVat.BackColor = System.Drawing.SystemColors.Control

        lblCasheri.Text = "Sovat"
        lblStroe.Text = "Positron Store"

        UpdateTotalSummary()
        SumPaymentAmounts()

        ' ⭐ Initialize Delivery Info ⭐
        lblDelivery.Text = "N/A"
        v_DeliveryId = 0 ' Reset ID
        v_DeliveryDate = Date.Today

        ' -------------------------
        ' ⭐ Secondary Display Logic (frm_display_second) ⭐
        ' -------------------------
        Try
            Dim screens As Screen() = Screen.AllScreens
            If screens.Length > 1 Then
                Dim screenBounds As Rectangle = screens(1).Bounds

                ' ⭐ REVISED: Create a NEW instance and store it in the private variable ⭐
                v_DisplayForm = New frm_display_second()

                v_DisplayForm.Location = New Point(screenBounds.X + (screenBounds.Width - v_DisplayForm.Width) \ 2, screenBounds.Y + (screenBounds.Height - v_DisplayForm.Height) \ 2)
                v_DisplayForm.FormBorderStyle = FormBorderStyle.None
                v_DisplayForm.Show() ' Use Show, not ShowDialog

            Else
                ' If only one screen, still create the form but don't position it on the second screen
                v_DisplayForm = New frm_display_second()
                ' You might want to hide it or show it on the main screen for debugging
                ' v_DisplayForm.Show() 
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing secondary display: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' -------------------------
        ' -------------------------

        Try
            Dim screens As Screen() = Screen.AllScreens
            If screens.Length > 1 Then
                Dim screenBounds As Rectangle = screens(0).Bounds
                Me.Location = New Point(screenBounds.X + (screenBounds.Width - Me.Width) \ 2, screenBounds.Y + (screenBounds.Height - Me.Height) \ 2)
                Me.FormBorderStyle = FormBorderStyle.None
                Me.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'WriteError(ex.Message)
        End Try
    End Sub

    Private Sub PaymentConfrim()
        dg_Payment.RowHeadersVisible = False
        dg_Payment.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg_Payment.AllowUserToAddRows = False
        dg_Payment.AllowUserToDeleteRows = False
        dg_Payment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        SetupDataColumns() ' Updated to include new columns
        AddRemoveButtonColumn()
    End Sub

    ' *** FIX 2: Modified SetupDataColumns to hide CURRENCY column and adjust PAY_METHOD width/header ***
    Private Sub SetupDataColumns()
        ' ORIGINAL COLUMNS
        If Not dg_Payment.Columns.Contains("PAY_METHOD") Then dg_Payment.Columns.Add("PAY_METHOD", "Method/Ccy")
        If Not dg_Payment.Columns.Contains("BANK") Then dg_Payment.Columns.Add("BANK", "Bank")

        ' NEW COLUMNS FOR MULTI-CURRENCY LOGIC
        If Not dg_Payment.Columns.Contains("CURRENCY") Then dg_Payment.Columns.Add("CURRENCY", "Ccy")
        If Not dg_Payment.Columns.Contains("REC_AMT") Then dg_Payment.Columns.Add("REC_AMT", "Amount") ' Now holds LOCAL amount
        If Not dg_Payment.Columns.Contains("USD_REC_AMT") Then dg_Payment.Columns.Add("USD_REC_AMT", "USD Amount") ' Hidden column for summation

        If dg_Payment.Columns.Contains("PAY_METHOD") Then
            With dg_Payment.Columns("PAY_METHOD")
                .HeaderText = "Method/Ccy" ' Descriptive header
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Width = 100 ' Increased width to accommodate "Cash (KHR)"
                .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
        End If

        If dg_Payment.Columns.Contains("CURRENCY") Then
            ' HIDE the CURRENCY column as requested by the user
            dg_Payment.Columns("CURRENCY").Visible = False
        End If

        If dg_Payment.Columns.Contains("BANK") Then
            dg_Payment.Columns("BANK").Visible = False
        End If

        If dg_Payment.Columns.Contains("REC_AMT") Then
            With dg_Payment.Columns("REC_AMT")
                .HeaderText = "Amount"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Allow amount to fill remaining space
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
            End With
        End If

        If dg_Payment.Columns.Contains("USD_REC_AMT") Then
            dg_Payment.Columns("USD_REC_AMT").Visible = False ' Hidden column for sum calculation
        End If

        ' Removed dg_Payment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None to allow fill mode on REC_AMT
    End Sub

    Private Sub AddRemoveButtonColumn()
        If dg_Payment.Columns.Contains("RemoveButton") Then Exit Sub

        Dim btnColumn As New DataGridViewButtonColumn()
        btnColumn.Name = "RemoveButton"
        btnColumn.HeaderText = ""
        btnColumn.Text = "X"
        btnColumn.UseColumnTextForButtonValue = True
        btnColumn.Width = 25
        btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        btnColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dg_Payment.Columns.Insert(0, btnColumn)
    End Sub

    Private Sub SetupColumn(ByVal colName As String, ByVal headerText As String, ByVal width As Integer, ByVal minWidth As Integer, ByVal readOnlyCol As Boolean)
        If dg_Items.Columns.Contains(colName) Then
            Dim col As DataGridViewColumn = dg_Items.Columns(colName)
            col.HeaderText = headerText
            col.Name = colName
            col.Width = width
            col.MinimumWidth = minWidth
            col.ReadOnly = readOnlyCol

            If colName = "i_Qty" OrElse colName = "i_Price" OrElse colName = "i_DisPct" OrElse colName = "i_DisAmt" OrElse colName = "i_NetAmt" Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf colName = "i_Line" Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub InitializeDataGridViewLayout()
        dg_Items.ScrollBars = ScrollBars.Vertical
        dg_Items.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dg_Items.AllowUserToResizeColumns = True

        SetupColumn("i_Line", "Line", 30, 30, True)
        SetupColumn("i_ITEMNO", "Item No", 60, 60, True)
        SetupColumn("i_DESC", "Description", 150, 100, True)
        SetupColumn("i_Qty", "Quantity", 55, 55, False)
        SetupColumn("i_Price", "Price", 65, 65, True)
        SetupColumn("i_Uom", "UOM", 35, 35, True)
        SetupColumn("i_DisPct", "Disc (%)", 60, 60, False)
        SetupColumn("i_DisAmt", "Disc ($)", 60, 60, False)
        SetupColumn("i_NetAmt", "Amount", 145, 70, True)

        Dim qtyIndex As Integer = If(dg_Items.Columns.Contains("i_Qty"), dg_Items.Columns("i_Qty").Index, -1)

        If Not dg_Items.Columns.Contains("i_Minus") Then
            Dim minusCol As New DataGridViewButtonColumn()
            With minusCol
                .HeaderText = ""
                .Name = "i_Minus"
                .Text = "-"
                .UseColumnTextForButtonValue = True
                .Width = 25
                .MinimumWidth = 25
                .ToolTipText = "Decrease Quantity"
            End With
            If qtyIndex <> -1 Then
                dg_Items.Columns.Insert(qtyIndex, minusCol)
                qtyIndex = qtyIndex + 1
            Else
                dg_Items.Columns.Add(minusCol)
            End If
        End If

        If Not dg_Items.Columns.Contains("i_Add") Then
            Dim addCol As New DataGridViewButtonColumn()
            With addCol
                .HeaderText = ""
                .Name = "i_Add"
                .Text = "+"
                .UseColumnTextForButtonValue = True
                .Width = 25
                .MinimumWidth = 25
                .ToolTipText = "Increase Quantity"
            End With
            If qtyIndex <> -1 AndAlso dg_Items.Columns.Contains("i_Qty") Then
                dg_Items.Columns.Insert(qtyIndex + 1, addCol)
            Else
                dg_Items.Columns.Add(addCol)
            End If
        End If

        If Not dg_Items.Columns.Contains("i_Remove") Then
            Dim removeCol As New DataGridViewButtonColumn()
            With removeCol
                .HeaderText = ""
                .Name = "i_Remove"
                .Text = "X"
                .UseColumnTextForButtonValue = True
                .Width = 30
                .MinimumWidth = 30
                .ToolTipText = "Remove Item"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dg_Items.Columns.Add(removeCol)
        End If

        For Each col As DataGridViewColumn In dg_Items.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 4. Sidebar Button Handlers ---
    ' ---------------------------------------------------------------------
    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        If db.TestConnection() Then
            MessageBox.Show("Connection Successful!")
        Else
            MessageBox.Show("Connection Failed!")
        End If
    End Sub
    Private Sub btnVoide_Click(sender As Object, e As EventArgs) Handles btnVoide.Click
        Dim F As New frm_voide()
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub
    Private Sub btnDriver_Click(sender As Object, e As EventArgs) Handles btnDriver.Click
        Dim F As New frm_delivery_shpping()
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 5. Barcode Scanning and Item Adding Logic (API Integration) ---
    ' ---------------------------------------------------------------------
    Private Async Sub txt_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Barcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim barcodeValue As String = txt_Barcode.Text.Trim()
            If String.IsNullOrEmpty(barcodeValue) Then Exit Sub

            Try
                ' 1. Construct the API URL
                Dim apiUrl As String = $"{API_BASE_URL}/api/scanbarcode?barcode={barcodeValue}"

                ' 2. Make the asynchronous API call
                Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

                If response.IsSuccessStatusCode Then
                    Dim jsonString As String = Await response.Content.ReadAsStringAsync()

                    ' 3. Parse the JSON response
                    Dim itemDataList As JArray = JArray.Parse(jsonString)

                    If itemDataList IsNot Nothing AndAlso itemDataList.Count > 0 Then
                        Dim itemData As JObject = itemDataList(0) ' Get the first matching item

                        ' Map JSON fields to VB variables
                        Dim v_ITEMNO As String = itemData("itemcode").ToString().Trim()
                        Dim itemDescription As String = itemData("itemname").ToString().Trim()
                        Dim itemUom As String = itemData("uom").ToString().Trim()
                        Dim itemPrice As Decimal = 0D
                        Decimal.TryParse(itemData("price1").ToString(), itemPrice)

                        Dim itemFound As Boolean = False
                        Dim itemDiscountPct As Decimal = 0D
                        Dim discountAmount As Decimal = 0D

                        ' 4. Check if the item is already in the DataGridView (i_ITEMNO)
                        For Each GDR As DataGridViewRow In dg_Items.Rows
                            If GDR.IsNewRow Then Continue For
                            If GDR.Cells("i_ITEMNO").Value IsNot Nothing AndAlso GDR.Cells("i_ITEMNO").Value.ToString().Trim() = v_ITEMNO Then
                                ' Item Found: Increase Quantity
                                Dim currentQty As Decimal
                                If Not Decimal.TryParse(GDR.Cells("i_Qty").Value.ToString(), currentQty) Then currentQty = 0D

                                GDR.Cells("i_Qty").Value = (currentQty + 1).ToString(v_FormatNo)
                                UpdateRowTotals(GDR)
                                itemFound = True
                                Exit For
                            End If
                        Next

                        ' 5. Add new item row if not found
                        If Not itemFound Then
                            Dim newQty As Decimal = 1D
                            Dim netAmount As Decimal = newQty * itemPrice ' Discount is 0 for new row

                            Me.dg_Items.Rows.Add(
                                dg_Items.Rows.Count,
                                v_ITEMNO,
                                itemDescription,
                                "-",
                                newQty.ToString(v_FormatNo),
                                "+",
                                itemPrice.ToString(v_FormatNo),
                                itemUom,
                                itemDiscountPct.ToString(v_FormatNo),
                                discountAmount.ToString(v_FormatNo),
                                netAmount.ToString(v_FormatNo),
                                "X"
                            )
                            dg_Items.Rows(dg_Items.Rows.Count - 1).Cells("i_Line").Value = dg_Items.Rows.Count

                            UpdateTotalSummary()
                        End If
                    Else
                        ' API returned success but the list was empty (no item found for that barcode)
                        MessageBox.Show("Barcode [" & barcodeValue & "] not found in the system.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                ElseIf response.StatusCode = Net.HttpStatusCode.NotFound Then
                    MessageBox.Show("Barcode [" & barcodeValue & "] not found or API endpoint missing.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Handle other HTTP error codes
                    Dim errorDetails = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show($"API Error: {response.StatusCode}. Details: {errorDetails}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As HttpRequestException
                MessageBox.Show("Connection Error: Could not reach the API server. Ensure the server is running at " & API_BASE_URL & ". " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error processing API response: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                txt_Barcode.Clear()
                txt_Barcode.Focus()
            End Try
        End If
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 6. Utility Functions and DataGridView Handlers (LINE ITEM DISCOUNT LOGIC) ---
    ' ---------------------------------------------------------------------
    Private Sub UpdateRowTotals(ByVal row As DataGridViewRow, Optional ByVal editedColumnName As String = "")
        Dim qty As Decimal = 0D
        If Not Decimal.TryParse(row.Cells("i_Qty").Value.ToString(), qty) Then qty = 0D

        Dim price As Decimal = 0D
        If Not Decimal.TryParse(row.Cells("i_Price").Value.ToString(), price) Then price = 0D

        Dim amount_Gross As Decimal = qty * price
        Dim finalDisAmt As Decimal = 0D
        Dim finalDisPct As Decimal = 0D

        If amount_Gross = 0D Then
            row.Cells("i_DisPct").Value = 0D.ToString(v_FormatNo)
            row.Cells("i_DisAmt").Value = 0D.ToString(v_FormatNo)
            row.Cells("i_NetAmt").Value = 0D.ToString(v_FormatNo)
            v_LastLineDisPct = 0D
            UpdateTotalSummary()
            Exit Sub
        End If

        If editedColumnName = "i_DisPct" Then
            If Decimal.TryParse(row.Cells("i_DisPct").Value.ToString(), finalDisPct) Then
                If finalDisPct > 100D Then finalDisPct = 100D
                If finalDisPct < 0D Then finalDisPct = 0D
                finalDisAmt = amount_Gross * (finalDisPct / 100D)
                row.Cells("i_DisAmt").Value = finalDisAmt.ToString(v_FormatNo)
                row.Cells("i_DisPct").Value = finalDisPct.ToString(v_FormatNo)
            Else
                finalDisPct = 0D
                finalDisAmt = 0D
                row.Cells("i_DisAmt").Value = 0D.ToString(v_FormatNo)
                row.Cells("i_DisPct").Value = 0D.ToString(v_FormatNo)
            End If
            v_LastLineDisPct = finalDisPct

        ElseIf editedColumnName = "i_DisAmt" Then
            If Decimal.TryParse(row.Cells("i_DisAmt").Value.ToString(), finalDisAmt) Then
                If finalDisAmt < 0D Then finalDisAmt = 0D
                If finalDisAmt > amount_Gross Then finalDisAmt = amount_Gross

                finalDisPct = (finalDisAmt / amount_Gross) * 100D
                row.Cells("i_DisPct").Value = finalDisPct.ToString(v_FormatNo)
            Else
                finalDisAmt = 0D
                finalDisPct = 0D
                row.Cells("i_DisPct").Value = 0D.ToString(v_FormatNo)
                row.Cells("i_DisAmt").Value = 0D.ToString(v_FormatNo)
            End If
            v_LastLineDisPct = finalDisPct
        Else
            If Decimal.TryParse(row.Cells("i_DisPct").Value.ToString(), finalDisPct) Then
                If finalDisPct > 100D Then finalDisPct = 100D
                If finalDisPct < 0D Then finalDisPct = 0D
                finalDisAmt = amount_Gross * (finalDisPct / 100D)
            Else
                finalDisPct = 0D
                finalDisAmt = 0D
            End If
            row.Cells("i_DisPct").Value = finalDisPct.ToString(v_FormatNo)
            row.Cells("i_DisAmt").Value = finalDisAmt.ToString(v_FormatNo)
            v_LastLineDisPct = finalDisPct
        End If

        Dim netAmt As Decimal = amount_Gross - finalDisAmt
        row.Cells("i_NetAmt").Value = netAmt.ToString(v_FormatNo)

        UpdateTotalSummary()
    End Sub
    Private Sub UpdateQuantity(rowIndex As Integer, change As Integer)
        If rowIndex < 0 OrElse dg_Items.Rows(rowIndex).IsNewRow Then Exit Sub

        Dim row As DataGridViewRow = dg_Items.Rows(rowIndex)
        Dim currentQty As Decimal
        If Not Decimal.TryParse(row.Cells("i_Qty").Value.ToString(), currentQty) Then currentQty = 0D

        Dim newQty As Decimal = currentQty + change

        If newQty > 0D Then
            row.Cells("i_Qty").Value = newQty.ToString(v_FormatNo)
        Else
            newQty = 1D
            row.Cells("i_Qty").Value = newQty.ToString(v_FormatNo)
        End If
        UpdateRowTotals(row)
    End Sub

    Private Sub RenumberLines()
        For i As Integer = 0 To dg_Items.Rows.Count - 1
            If Not dg_Items.Rows(i).IsNewRow Then
                dg_Items.Rows(i).Cells("i_Line").Value = i + 1
            End If
        Next
    End Sub
    Private Sub dg_Items_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_Items.CellClick
        Try
            If e.RowIndex < 0 OrElse dg_Items.Rows(e.RowIndex).IsNewRow Then Exit Sub

            If dg_Items.Columns(e.ColumnIndex) IsNot Nothing Then
                Dim colName As String = dg_Items.Columns(e.ColumnIndex).Name

                Select Case colName
                    Case "i_Add"
                        UpdateQuantity(e.RowIndex, 1)
                    Case "i_Minus"
                        UpdateQuantity(e.RowIndex, -1)
                    Case "i_Remove"
                        If MessageBox.Show("Remove selected item from the list?", V_ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            dg_Items.Rows.RemoveAt(e.RowIndex)
                            RenumberLines()
                            UpdateTotalSummary()
                        End If
                End Select

                ' ⭐ ADDED: Update the secondary display after item modification or removal ⭐
                UpdateSecondaryDisplay()
            End If
            txt_Barcode.Clear()
            txt_Barcode.Focus()
        Catch ex As Exception
            ' Error handling for cell click
        End Try
    End Sub

    Private Sub dg_Items_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dg_Items.CellBeginEdit
        If e.RowIndex < 0 OrElse dg_Items.Rows(e.RowIndex).IsNewRow Then Exit Sub

        Dim row As DataGridViewRow = dg_Items.Rows(e.RowIndex)
        row.Cells("i_DisPct").ReadOnly = False
        row.Cells("i_DisAmt").ReadOnly = False
        row.Cells("i_DisPct").Style.BackColor = dg_Items.DefaultCellStyle.BackColor
        row.Cells("i_DisAmt").Style.BackColor = dg_Items.DefaultCellStyle.BackColor
    End Sub

    Private Sub dg_Items_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dg_Items.CellEndEdit
        If e.RowIndex < 0 OrElse dg_Items.Rows(e.RowIndex).IsNewRow Then Exit Sub

        Dim ColName As String = dg_Items.Columns(e.ColumnIndex).Name
        Dim row As DataGridViewRow = dg_Items.Rows(e.RowIndex)
        Dim isDiscountColumn As Boolean = False
        Select Case ColName
            Case "i_Qty"
                Dim newQty As Decimal
                If Not Decimal.TryParse(row.Cells("i_Qty").Value.ToString(), newQty) OrElse newQty <= 0 Then
                    newQty = 1D
                End If
                row.Cells("i_Qty").Value = newQty.ToString(v_FormatNo)
                UpdateRowTotals(row)

            Case "i_DisPct"
                isDiscountColumn = True
                Dim newDisPct As Decimal
                If Not Decimal.TryParse(row.Cells("i_DisPct").Value.ToString(), newDisPct) Then newDisPct = 0D
                row.Cells("i_DisPct").Value = newDisPct.ToString(v_FormatNo)
                UpdateRowTotals(row, "i_DisPct")

            Case "i_DisAmt"
                isDiscountColumn = True
                Dim newDisAmt As Decimal
                If Not Decimal.TryParse(row.Cells("i_DisAmt").Value.ToString(), newDisAmt) Then newDisAmt = 0D
                row.Cells("i_DisAmt").Value = newDisAmt.ToString(v_FormatNo)
                UpdateRowTotals(row, "i_DisAmt")

            Case Else
                ' No action needed
        End Select

        If isDiscountColumn Then
            row.Cells("i_DisPct").Style.BackColor = dg_Items.DefaultCellStyle.BackColor
            row.Cells("i_DisAmt").Style.BackColor = dg_Items.DefaultCellStyle.BackColor
        End If

        dg_Items(e.ColumnIndex, e.RowIndex).Selected = False
        txt_Barcode.Clear()
        txt_Barcode.Focus()
    End Sub

    ' ⭐ NEW: Helper to extract DataGridView content for the display form ⭐
    ' ⭐ REVISED: Helper to extract DataGridView content for the display form ⭐
    Private Function GetCurrentItemsForDisplay() As List(Of DisplayItemInfo)
        Dim itemList As New List(Of DisplayItemInfo)()

        For Each row As DataGridViewRow In dg_Items.Rows
            If row.IsNewRow Then Continue For

            Dim itemCode As String = If(row.Cells("i_ITEMNO").Value IsNot Nothing, row.Cells("i_ITEMNO").Value.ToString(), "") ' << ADDED
            Dim description As String = If(row.Cells("i_DESC").Value IsNot Nothing, row.Cells("i_DESC").Value.ToString(), "")
            Dim qty As Decimal = 0D
            Dim price As Decimal = 0D  ' << ADDED
            Dim netAmt As Decimal = 0D

            Decimal.TryParse(If(row.Cells("i_Qty").Value IsNot Nothing, row.Cells("i_Qty").Value.ToString(), "0"), qty)
            Decimal.TryParse(If(row.Cells("i_Price").Value IsNot Nothing, row.Cells("i_Price").Value.ToString(), "0"), price) ' << ADDED
            Decimal.TryParse(If(row.Cells("i_NetAmt").Value IsNot Nothing, row.Cells("i_NetAmt").Value.ToString(), "0"), netAmt)

            Dim itemInfo As New DisplayItemInfo With {
                .ItemCode = itemCode,     ' << ADDED
                .Description = description,
                .Quantity = qty,
                .Price = price,           ' << ADDED
                .NetPrice = netAmt
            }
            itemList.Add(itemInfo)
        Next

        Return itemList
    End Function

    ' ⭐ NEW: Method to update the secondary display form ⭐
    Private Sub UpdateSecondaryDisplay()
        If v_DisplayForm IsNot Nothing AndAlso Not v_DisplayForm.IsDisposed Then
            Dim currentItems As List(Of DisplayItemInfo) = GetCurrentItemsForDisplay()

            ' 1. Read the Net Total Due from the main form
            Dim netTotalDue As Decimal = 0D
            Decimal.TryParse(txtNetTotal.Text, netTotalDue) ' <--- THIS IS THE AMOUNT YOU WANT TO DISPLAY

            Dim totalyqty As Decimal = 0D
            Decimal.TryParse(txtQuantity.Text, totalyqty)
            ' The original paidAmount variable is no longer necessary if you want NetTotal.
            ' However, we should still calculate the actual paid amount to show the difference.
            Dim actualPaidAmount As Decimal = 0D
            Decimal.TryParse(txtPaid.Text.Replace(" USD", ""), actualPaidAmount)

            ' 2. Read KHR and THB totals from the main form's summary labels
            Dim khrTotal As String = lblAmtKHR.Text
            Dim thbTotal As String = lblAmtTHB.Text

            ' NOTE: The variable below is redundant but was in your original code.
            ' Dim totalpaid As String = txtNetTotal.Text 

            ' 3. If there are items, attach the currency totals and the NET TOTAL (as TotalPaid) 
            ' to the first item for easy passing to the secondary display.
            If currentItems.Count > 0 Then
                currentItems(0).TotalKHR = khrTotal
                currentItems(0).TotalTHB = thbTotal
                ' ⭐ REVISED: Store the numeric Net Total Due (in USD) in the TotalPaid property.
                currentItems(0).TotalPaid = netTotalDue.ToString("N2")
                currentItems(0).Totalqty = totalyqty.ToString("N2")
            End If

            ' 4. Call the updated method on the display form
            ' ⭐ REVISED: Pass the Net Total Due (decimal) instead of the actual Paid Amount.
            v_DisplayForm.UpdateDisplayItems(currentItems, netTotalDue)
        End If
    End Sub


    ' ---------------------------------------------------------------------
    ' --- 7. Summary Panel Calculations (NET TOTAL DUE) ---
    ' ---------------------------------------------------------------------
    Public Function UpdateTotalSummary() As Decimal
        Dim totalQty As Decimal = 0D
        Dim totalGrossAmount As Decimal = 0D
        Dim subTotal_Net As Decimal = 0D      ' Sum of i_NetAmt (SubTotal after LINE discounts)
        Dim totalLineDiscount As Decimal = 0D
        Dim finalNetTotal As Decimal = 0D
        Dim vatAmt As Decimal = 0D
        Dim shippingFee As Decimal = 0D
        Dim checkDiscountAmt As Decimal = 0D

        Const VAT_RATE As Decimal = 0.1D ' Fixed 10% VAT Rate
        'Const PLT As Decimal = 0.05D

        ' SUM LINE ITEMS
        For Each row As DataGridViewRow In dg_Items.Rows
            If row.IsNewRow Then Continue For

            Dim qty As Decimal = 0D
            Decimal.TryParse(row.Cells("i_Qty").Value.ToString(), qty)
            totalQty += qty

            Dim price As Decimal = 0D
            Decimal.TryParse(row.Cells("i_Price").Value.ToString(), price)
            totalGrossAmount += qty * price

            Dim netAmount As Decimal = 0D
            Decimal.TryParse(row.Cells("i_NetAmt").Value.ToString(), netAmount)
            subTotal_Net += netAmount

            Dim rowDisAmt As Decimal = 0D
            Decimal.TryParse(row.Cells("i_DisAmt").Value.ToString(), rowDisAmt)
            totalLineDiscount += rowDisAmt
        Next

        ' UPDATE BASIC SUMMARY FIELDS
        txtQuantity.Text = totalQty.ToString(v_FormatNo)
        txtSubTotal.Text = subTotal_Net.ToString(v_FormatNo)

        ' Get fees and Check Discount amount
        Decimal.TryParse(txtShippingFee.Text, shippingFee)
        Decimal.TryParse(txtCheckDiscountAmt.Text, checkDiscountAmt)

        ' Calculate Base Amount After All Discounts
        Dim amountAfterCheckDiscount As Decimal = subTotal_Net - checkDiscountAmt
        If amountAfterCheckDiscount < 0D Then amountAfterCheckDiscount = 0D

        ' --- ⭐ VAT LOGIC IMPLEMENTATION (Based on cbNonVat.Checked) ⭐ ---
        If Not cbNonVat.Checked Then
            ' Case: Include VAT (Check = False) -> Calculate 10% VAT
            vatAmt = Math.Round(amountAfterCheckDiscount * VAT_RATE, 2)
            txtVat.Text = vatAmt.ToString(v_FormatNo)

        Else
            ' Case: Non-VAT (Check = True) -> VAT is 0
            vatAmt = 0D
            txtVat.Text = 0D.ToString(v_FormatNo)
        End If
        ' --- ⭐ VAT LOGIC END ⭐ ---

        ' Calculate Final Total Due: (Net Subtotal - Check Discount) + VAT + Shipping Fee
        finalNetTotal = amountAfterCheckDiscount + vatAmt + shippingFee

        ' Update currency display labels using the rates fetched from API (or defaults)
        Dim khrRate As Decimal = 0D
        Dim thbRate As Decimal = 0D
        Decimal.TryParse(txtKHRRate.Text, khrRate)
        Decimal.TryParse(txtTHBRate.Text, thbRate)

        ' Use sensible defaults if parsing fails or API failed
        If khrRate <= 0D Then khrRate = 4100D
        If thbRate <= 0D Then thbRate = 30D

        lblAmtKHR.Text = (finalNetTotal * khrRate).ToString("N0")
        lblAmtTHB.Text = (finalNetTotal * thbRate).ToString("N0")
        txtAmtDue.Text = (finalNetTotal).ToString(v_FormatNo)
        txtNetTotal.Text = finalNetTotal.ToString(v_FormatNo)

        ' ⭐️ IMPORTANT: Call SumPaymentAmounts to ensure Paid and Change are updated
        SumPaymentAmounts()

        ' ⭐ ADDED: Update the secondary display form after summary recalculation ⭐
        UpdateSecondaryDisplay()

        Return finalNetTotal
    End Function
    ' ---------------------------------------------------------------------
    ' --- 7a. Checkbox Handler (VAT / Non-VAT Logic) ---
    ' ---------------------------------------------------------------------
    Private Sub cbNonVat_CheckedChanged(sender As Object, e As EventArgs) Handles cbNonVat.CheckedChanged
        If cbNonVat.Checked Then
            ' Non-VAT (Check = True): VAT Amount is 0
            txtVat.Text = 0D.ToString(v_FormatNo)
            txtVat.ReadOnly = True
            txtVat.BackColor = System.Drawing.SystemColors.Control
        Else
            ' Include VAT (Check = False): Calculate 10% VAT
            txtVat.ReadOnly = False
            txtVat.BackColor = System.Drawing.SystemColors.Window
        End If

        ' Always trigger recalculation of the total amount due, which applies the 10% rate if not checked.
        UpdateTotalSummary()
    End Sub
    ' ---------------------------------------------------------------------
    ' --- 8. Text Box Change Handlers for Summary Panel (Discount Input Fields) ---
    ' ---------------------------------------------------------------------

    Private Sub txtPercentage_TextChanged(sender As Object, e As EventArgs) Handles txtPercentage.TextChanged
        CalculateCheckDiscountFromPercentage()
        ClearPaymentInfor()
    End Sub

    Private Sub txtCheckDiscountAmt_TextChanged(sender As Object, e As EventArgs) Handles txtCheckDiscountAmt.TextChanged
        CalculateCheckPercentageFromAmount()
        ClearPaymentInfor()
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSubTotal.TextChanged
    End Sub

    Private Sub txtVat_TextChanged(sender As Object, e As EventArgs) Handles txtVat.TextChanged
        ' Only recalculate when the VAT field is manually changed AND NOT due to the checkbox or calculation
        If Not cbNonVat.Checked Then
            UpdateTotalSummary()
        End If
    End Sub

    Private Sub txtShippingFee_TextChanged(sender As Object, e As EventArgs) Handles txtShippingFee.TextChanged
        UpdateTotalSummary()
    End Sub

    Private Sub txtNetTotal_TextChanged(sender As Object, e As EventArgs) Handles txtNetTotal.TextChanged
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 9. Check Discount Calculation Logic (Percentage <-> Amount) ---
    ' ---------------------------------------------------------------------

    Private Sub CalculateCheckDiscountFromPercentage()
        If isCalculatingDiscount Then Exit Sub

        isCalculatingDiscount = True

        Try
            Dim checkDisPct As Decimal = 0D
            Dim netSubtotal As Decimal = 0D

            If Not Decimal.TryParse(txtSubTotal.Text, netSubtotal) Then netSubtotal = 0D

            If Decimal.TryParse(txtPercentage.Text, checkDisPct) Then
                If checkDisPct < 0D Then checkDisPct = 0D
                If checkDisPct > 100D Then checkDisPct = 100D

                Dim discountAmt As Decimal = netSubtotal * (checkDisPct / 100D)

                txtCheckDiscountAmt.Text = discountAmt.ToString(v_FormatNo)
            Else
                txtCheckDiscountAmt.Text = 0D.ToString(v_FormatNo)
            End If

            UpdateTotalSummary()
        Catch ex As Exception
            MessageBox.Show("Error calculating discount from percentage: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isCalculatingDiscount = False
        End Try
    End Sub

    Private Sub CalculateCheckPercentageFromAmount()
        If isCalculatingDiscount Then Exit Sub

        isCalculatingDiscount = True

        Try
            Dim checkDisAmt As Decimal = 0D
            Dim netSubtotal As Decimal = 0D

            If Not Decimal.TryParse(txtSubTotal.Text, netSubtotal) Then netSubtotal = 0D

            If Decimal.TryParse(txtCheckDiscountAmt.Text, checkDisAmt) Then
                If checkDisAmt < 0D Then checkDisAmt = 0D
                If netSubtotal > 0D AndAlso checkDisAmt > netSubtotal Then
                    checkDisAmt = netSubtotal
                    ' We don't update txtCheckDiscountAmt here to avoid triggering the TextChanged event again instantly.
                End If

                Dim discountPct As Decimal = 0D

                If netSubtotal > 0D Then
                    discountPct = (checkDisAmt / netSubtotal) * 100D
                End If

                txtPercentage.Text = discountPct.ToString(v_FormatNo)
            Else
                txtPercentage.Text = 0D.ToString(v_FormatNo)
            End If

            UpdateTotalSummary()
        Catch ex As Exception
            MessageBox.Show("Error calculating discount from amount: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isCalculatingDiscount = False
        End Try
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 10. Payment Button Handlers (Passing Rate and Currency) ---
    ' ---------------------------------------------------------------------
    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "Cash" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKHR_Click(sender As Object, e As EventArgs) Handles btnKHR.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "KHR"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D
            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDueUSD As Decimal = totalDue - totalPaymentReceived
            If remainingDueUSD < 0D Then remainingDueUSD = 0D

            ' Get rate from txtKHRRate (Already updated by API)
            Dim khrRate As Decimal = 0D
            Decimal.TryParse(txtKHRRate.Text, khrRate)
            If khrRate <= 0D Then khrRate = 4100D

            Dim remainingDueKHR As Decimal = remainingDueUSD * khrRate

            F.txtAmount.Text = remainingDueKHR.ToString("N0")

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "Cash" ' Pass a generic method name
            F.CurrencyCode = "KHR"
            F.ExchangeRate = khrRate
            F.IsBaseCurrency = False

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "KHR"
                v_LastPaymentRate = khrRate
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            ' Re-add the necessary Catch block to handle errors in this payment process
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnQRCode_Click(sender As Object, e As EventArgs) Handles btnQRCode.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "QR Code" ' Updated method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTHB_Click(sender As Object, e As EventArgs) Handles btnTHB.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "THB"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D
            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDueUSD As Decimal = totalDue - totalPaymentReceived
            If remainingDueUSD < 0D Then remainingDueUSD = 0D

            ' Get rate from txtTHBRate (Already updated by API)
            Dim thbRate As Decimal = 0D
            Decimal.TryParse(txtTHBRate.Text, thbRate)
            If thbRate <= 0D Then thbRate = 30D

            Dim remainingDueTHB As Decimal = remainingDueUSD * thbRate

            F.txtAmount.Text = remainingDueTHB.ToString("N0")

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "Cash" ' Pass a generic method name
            F.CurrencyCode = "THB"
            F.ExchangeRate = thbRate
            F.IsBaseCurrency = False

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "THB"
                v_LastPaymentRate = thbRate
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles lblAmtKHR.Click
        UpdateTotalSummary()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles lblAmtTHB.Click
        UpdateTotalSummary()
    End Sub

    Private Sub dg_Payment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg_Payment.CellContentClick
        If dg_Payment.Columns(e.ColumnIndex).Name = "RemoveButton" AndAlso e.RowIndex >= 0 Then
            Dim rowIndex As Integer = e.RowIndex
            If MessageBox.Show("Remove this payment line?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                dg_Payment.Rows.RemoveAt(rowIndex)
                ' RECALCULATE PAID TOTAL AFTER REMOVAL
                SumPaymentAmounts()
            End If
        End If
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 11. Transaction Clearing (btnClear_Click implementation) ---
    ' ---------------------------------------------------------------------
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If dg_Items.Rows.Count = 0 AndAlso dg_Payment.Rows.Count = 0 Then
            ' Nothing to clear, just ensure textboxes are zeroed/cleared
            txt_Barcode.Clear()
            txtPercentage.Text = 0D.ToString(v_FormatNo)
            txtCheckDiscountAmt.Text = 0D.ToString(v_FormatNo)
            txtVat.Text = 0D.ToString(v_FormatNo)
            txtShippingFee.Text = 0D.ToString(v_FormatNo)

            ' Re-initialize NonVat state and update summary
            cbNonVat.Checked = True
            UpdateTotalSummary()
            Exit Sub
        End If

        ' Ask for confirmation before clearing the entire transaction
        Dim dialogResult As DialogResult = MessageBox.Show(
      "Are you sure you want to clear the entire transaction? All items and payments will be removed.",
      V_ProjectName,
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question)

        If dialogResult = DialogResult.Yes Then
            Try
                ' 1. Clear all items from the main DataGridView
                dg_Items.Rows.Clear()

                ' 2. Clear all payment entries
                dg_Payment.Rows.Clear()

                ' 3. Reset discount and fee fields to initial state
                txt_Barcode.Clear()
                txtPercentage.Text = 0D.ToString(v_FormatNo) ' Reset percentage default
                txtCheckDiscountAmt.Text = 0D.ToString(v_FormatNo)
                txtVat.Text = 0D.ToString(v_FormatNo)
                txtShippingFee.Text = 0D.ToString(v_FormatNo)
                cbNonVat.Checked = True

                ' ⭐ Reset Delivery Info ⭐
                lblDelivery.Text = "N/A"
                v_DeliveryId = 0 ' Reset ID
                v_DeliveryDate = Date.Today

                ' 4. Update the summary panel to reflect zero totals
                UpdateTotalSummary()
                SumPaymentAmounts()

                ' ⭐ ADDED: Clear secondary display
                UpdateSecondaryDisplay()

                ' 5. Focus on the barcode field for the next transaction
                txt_Barcode.Focus()

            Catch ex As Exception
                MessageBox.Show("Error clearing transaction: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ---------------------------------------------------------------------
    ' --- 12. Payment Calculations (SUM PAID AMOUNT & CALCULATE CHANGE) ---
    ' ---------------------------------------------------------------------

    Private Sub SumPaymentAmounts()
        Dim totalPaymentReceived As Decimal = 0D

        ' 1. Loop through all rows in the dg_Payment DataGridView
        ' Summing the value from the new hidden column: USD_REC_AMT
        For Each row As DataGridViewRow In dg_Payment.Rows
            If row.IsNewRow Then Continue For

            Try
                If row.Cells("USD_REC_AMT").Value IsNot Nothing Then
                    Dim amount As Decimal = 0D
                    ' We sum the USD equivalent amount.
                    If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                        totalPaymentReceived += amount
                    End If
                End If
            Catch ex As Exception
                ' Error handling
            End Try
        Next

        ' 2. Update Payment Summary using the actual total received (in USD)
        UpdatePaymentSummary(totalPaymentReceived)
        UpdateSecondaryDisplay()
    End Sub

    ' *** FIX 1: Modified UpdatePaymentSummary to include currency code next to change amount ***
    Private Sub UpdatePaymentSummary(ByVal totalPaymentReceived As Decimal)
        Dim netTotal As Decimal = 0D
        Dim paidAmountToDisplay As Decimal = 0D
        Dim rawChangeUSD As Decimal = 0D
        Dim changeDisplayText As String = ""

        ' 1. Get Net Total Due
        If Not Decimal.TryParse(txtNetTotal.Text, netTotal) Then netTotal = 0D

        ' 2. Calculate Change/Balance using the full payment received (always in USD equivalent)
        Dim rawChange As Decimal = totalPaymentReceived - netTotal

        ' 3. Determine the Paid amount to DISPLAY (USD) and the Change (USD)
        If rawChange >= 0D Then
            ' Paid enough or overpaid.
            paidAmountToDisplay = netTotal        ' Paid Display is capped at Net Total Due (USD)
            rawChangeUSD = rawChange              ' Change is the actual overpayment (in USD)
        Else
            ' Shortage (rawChange < 0D).
            paidAmountToDisplay = totalPaymentReceived ' Paid Display shows the actual received amount (USD)
            rawChangeUSD = 0D                     ' Change is 0.00
        End If

        ' 4. Update txtPaid (Always in USD format)
        txtPaid.Text = paidAmountToDisplay.ToString(v_FormatNo)
        txtAmtDue.Text = (netTotal - paidAmountToDisplay).ToString(v_FormatNo)

        ' 5. Calculate final change amount for display based on the last payment currency
        If rawChangeUSD > 0D Then
            Select Case v_LastPaymentCurrency
                Case "KHR"
                    Dim changeKHR As Decimal = rawChangeUSD * v_LastPaymentRate
                    ' Display KHR without decimals, using N0 format
                    changeDisplayText = changeKHR.ToString("N0") & " KHR" ' Added space for clarity
                Case "THB"
                    Dim changeTHB As Decimal = rawChangeUSD * v_LastPaymentRate
                    ' Display THB without decimals, using N0 format
                    changeDisplayText = changeTHB.ToString("N0") & " THB" ' Added space for clarity
                Case Else ' "USD" or anything else
                    ' USD is the base currency, use standard format
                    changeDisplayText = rawChangeUSD.ToString(v_FormatNo) & " USD" ' Added space for clarity
            End Select
        Else
            ' No change, display 0.00 in USD format
            changeDisplayText = 0D.ToString(v_FormatNo) & " USD"
        End If

        txtChange.Text = changeDisplayText

        ' 6. Change color for shortage/overpayment
        txtChange.BackColor = SystemColors.Window
    End Sub

    Public Sub ClearPaymentInfor()
        txtAmtDue.Text = txtNetTotal.Text
        txtPaid.Text = "0"
        txtChange.Text = "0"
        dg_Payment.Rows.Clear()
    End Sub

    ' Function to generate a unique receipt number (Note: This function is deprecated by the API sequence logic)
    Private Function GenerateReceiptNo() As String
        ' Note: Using a random suffix is OK for testing, but a proper sequence is needed in production.
        Dim prefix As String = "INV" & Now.ToString("yyMMdd")
        Dim randomSuffix As String = New Random().Next(1000, 9999).ToString()
        Return prefix & randomSuffix
    End Function

    Private Async Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        ' --- 1. PRE-CHECK & DATA GATHERING (UPDATED) ---
        Dim totalDue As Decimal = 0D
        Decimal.TryParse(txtNetTotal.Text, totalDue)

        Dim paidAmt As Decimal = 0D
        ' CORRECTED: Use TryParse directly on the numeric string from UpdatePaymentSummary
        If Not Decimal.TryParse(txtPaid.Text, paidAmt) Then
            MessageBox.Show("Error parsing Paid Amount.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If paidAmt < totalDue Then
            MessageBox.Show("Payment is incomplete. Please receive the full amount.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ⭐ Delivery Data Gathering (CORRECTED) ⭐
        Dim deliveryName As String = lblDelivery.Text
        Dim deliveryId As Integer = v_DeliveryId ' Get the captured ID

        ' Determine if it's an in-store sale or a valid delivery
        Dim isDeliverySale As Boolean = (deliveryId > 0)

        ' Gather summary fields
        Dim receiptNoPrefix As String = GenerateReceiptNo()

        Dim receiptDate As DateTime = DateTime.Now ' Default to current time

        ' Attempt to get receipt date from control named dtpInvoiceDate
        If Me.Controls.ContainsKey("dtpInvoiceDate") AndAlso TypeOf Me.Controls("dtpInvoiceDate") Is DateTimePicker Then
            receiptDate = CType(Me.Controls("dtpInvoiceDate"), DateTimePicker).Value
        Else
            ' If control not found, use Now
            receiptDate = DateTime.Now
        End If

        Dim checkDisAmt As Decimal = 0D : Decimal.TryParse(txtCheckDiscountAmt.Text, checkDisAmt)
        Dim checkDisPct As Decimal = 0D : Decimal.TryParse(txtPercentage.Text, checkDisPct)
        Dim vatAmt As Decimal = 0D : Decimal.TryParse(txtVat.Text, vatAmt)
        Dim shippingFee As Decimal = 0D : Decimal.TryParse(txtShippingFee.Text, shippingFee)
        Dim finalTotal As Decimal = totalDue ' grand_total

        ' Calculate Line Discount & Gross Sub Total
        Dim totalLineDiscount As Decimal = 0D
        Dim totalGrossAmt As Decimal = 0D

        For Each row As DataGridViewRow In dg_Items.Rows
            If Not row.IsNewRow Then
                Dim rowDisAmt As Decimal = 0D : Decimal.TryParse(row.Cells("i_DisAmt").Value.ToString(), rowDisAmt)
                totalLineDiscount += rowDisAmt

                Dim qty As Decimal = 0D : Decimal.TryParse(row.Cells("i_Qty").Value.ToString(), qty)
                Dim price As Decimal = 0D : Decimal.TryParse(row.Cells("i_Price").Value.ToString(), price)
                totalGrossAmt += qty * price
            End If
        Next

        Dim totalDiscount As Decimal = totalLineDiscount + checkDisAmt

        ' --- 2. BUILD SALES JSON PAYLOAD (tbl_pos_transcription_h/d) (CORRECTED HEADER) ---

        Dim headerObject As New JObject From {
            {"receipt_no", receiptNoPrefix},
            {"store_id", V_StoreId},
            {"store_name", V_StoreName},
            {"receipt_date", receiptDate.ToString("yyyy-MM-ddTHH:mm:ss")},
            {"receipt_batchinvoice", receiptNoPrefix},
            {"receipt_status", 1}, ' SmallInt value
            {"cashier_id", V_CashierId},
            {"cashier_name", V_CashierName},
            {"coment", ""},
            {"sub_total", totalGrossAmt}, ' Gross Amount
            {"line_discount", totalLineDiscount},
            {"global_discount", checkDisAmt}, ' Check Discount Amount
            {"global_discount_pct", checkDisPct},
            {"ship_fee", shippingFee},
            {"ship_discount", 0D},
            {"total_discount", totalDiscount},
            {"total_discount_vat", vatAmt}, ' VAT Amount
            {"grand_total", finalTotal}, ' Net Total Due
            {"exc_rate", 1D},
            {"add_user", V_CashierId},
            {"delivery_id", If(isDeliverySale, JToken.FromObject(deliveryId), JValue.CreateNull())},
            {"delivery_name", If(isDeliverySale, JToken.FromObject(deliveryName), JValue.CreateNull())},
            {"delivery_date", If(isDeliverySale, JToken.FromObject(v_DeliveryDate.ToString("yyyy-MM-ddTHH:mm:ss")), JValue.CreateNull())}
        }

        Dim detailsArray As New JArray()

        For Each row As DataGridViewRow In dg_Items.Rows
            If row.IsNewRow Then Continue For

            Dim itemQty As Decimal = CDec(row.Cells("i_Qty").Value)
            Dim itemPrice As Decimal = CDec(row.Cells("i_Price").Value)
            Dim itemLineDisAmt As Decimal = CDec(row.Cells("i_DisAmt").Value)
            Dim itemTotalAmt As Decimal = itemQty * itemPrice

            Dim detailObject As New JObject From {
                {"receipt_line", CInt(row.Cells("i_Line").Value)},
                {"itemno", row.Cells("i_ITEMNO").Value.ToString()},
                {"barcode", row.Cells("i_ITEMNO").Value.ToString()},
                {"item_name", row.Cells("i_DESC").Value.ToString()},
                {"qty", itemQty},
                {"price", itemPrice},
                {"uom", row.Cells("i_Uom").Value.ToString()},
                {"total_amt", itemTotalAmt},
                {"disc_pct", CDec(row.Cells("i_DisPct").Value)},
                {"disc_amt", itemLineDisAmt},
                {"gdisc_pct", 0D},
                {"gdisc_amt", 0D},
                {"net_amt", itemTotalAmt - itemLineDisAmt}
            }
            detailsArray.Add(detailObject)
        Next

        ' #######################################################################################
        ' ⭐ STEP 3: BUILD PAYMENT DETAILS ARRAY FOR tbl_pos_transcription_m ⭐
        ' #######################################################################################
        Dim paymentDetailsArray As New JArray()
        Dim totalPaymentReceivedUSD As Decimal = 0D : Decimal.TryParse(txtPaid.Text.Replace(" USD", ""), totalPaymentReceivedUSD) ' Parse actual USD received
        Dim totalChangeAmtUSD As Decimal = totalPaymentReceivedUSD - totalDue ' Only need to track total overpayment

        ' The final change value is currently displayed in txtChange, but its raw USD value is totalChangeAmtUSD.
        ' We'll use the rawChangeUSD value, and the Node.js API will handle assigning the change to the last payment.

        For Each pmtRow As DataGridViewRow In dg_Payment.Rows
            If pmtRow.IsNewRow Then Continue For

            Dim recAmtLocal As Decimal = 0D : Decimal.TryParse(pmtRow.Cells("REC_AMT").Value.ToString(), recAmtLocal)
            Dim payMethodText As String = pmtRow.Cells("PAY_METHOD").Value.ToString()
            Dim currencyCode As String = pmtRow.Cells("CURRENCY").Value.ToString()
            Dim bankCodeText As String = If(pmtRow.Cells("BANK").Value IsNot Nothing, pmtRow.Cells("BANK").Value.ToString(), Nothing)

            Dim rate As Decimal = 1D
            If currencyCode = "KHR" Then
                Decimal.TryParse(txtKHRRate.Text, rate)
            ElseIf currencyCode = "THB" Then
                Decimal.TryParse(txtTHBRate.Text, rate)
            End If
            If rate <= 0D Then rate = 1D ' Fallback

            ' Change is passed as 0 to all lines. The API takes totalChangeAmtUSD and applies it to the last payment.
            Dim paymentDetailObject As New JObject From {
            {"receipt_line", pmtRow.Index + 1},
            {"pay_method", JToken.FromObject(payMethodText)}, ' Ensure all string values are JTokens
            {"cur_code", JToken.FromObject(currencyCode)},
            {"cur_rate", rate},
            {"rec_amt", recAmtLocal}, ' Local currency amount paid
            {"bank_code", If(bankCodeText Is Nothing, JValue.CreateNull(), JToken.FromObject(bankCodeText))},
            {"change_amt", 0D}
        }

            ' Check if this is the last payment row
            If pmtRow.Index = dg_Payment.Rows.Count - 1 AndAlso totalChangeAmtUSD > 0D Then
                ' IMPORTANT: Pass the total USD change amount on the last payment line.
                paymentDetailObject("change_amt") = JToken.FromObject(totalChangeAmtUSD)
            End If

            paymentDetailsArray.Add(paymentDetailObject)
        Next
        ' #######################################################################################
        ' ⭐ END OF STEP 3 ⭐
        ' #######################################################################################


        ' --- 4. CONSTRUCT FINAL API REQUEST BODY (Now includes payments array) ---

        Dim requestBody As New JObject From {
            {"header", headerObject},
            {"details", detailsArray},
            {"payments", paymentDetailsArray} ' ⭐ ADDED PAYMENTS ARRAY HERE ⭐
        }

        Dim jsonPayload As String = requestBody.ToString()

        ' --- 5. EXECUTE ASYNCHRONOUS API POST (URL UNCHANGED) ---

        Try
            Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales"

            Dim response As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, content)

            Dim responseString As String = Await response.Content.ReadAsStringAsync()

            If response.IsSuccessStatusCode Then
                ' API returns 201 Created and the final receipt number
                Dim successJson As JObject = JObject.Parse(responseString)
                Dim finalReceiptNo As String = successJson("receipt_no").ToString() ' ⭐ CAPTURE FINAL UNIQUE NUMBER ⭐

                MessageBox.Show($"Transaction {finalReceiptNo} posted successfully via API! ✅", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                PrintReceiptExecute(finalReceiptNo)
                ' Clear the UI for the next transaction
                btnClear_Click(Nothing, EventArgs.Empty)
            Else
                ' Handle API errors (400, 500, etc.)
                Dim errorJson As JObject = JObject.Parse(responseString)
                Dim errorMessage As String = errorJson("message").ToString()
                Dim details As String = If(errorJson("details") IsNot Nothing, errorJson("details").ToString(), "No further details.")

                MessageBox.Show($"API Transaction Failed ({response.StatusCode}): {errorMessage}. Details: {details}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server. Ensure the Node.js server is running at " & API_BASE_URL & ". 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during API processing: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVisa_Click(sender As Object, e As EventArgs) Handles btnVisa.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "Visa" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMasterCard_Click(sender As Object, e As EventArgs) Handles btnMasterCard.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "MasterCard" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnJCB_Click(sender As Object, e As EventArgs) Handles btnJCB.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "JCB" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAMEX_Click(sender As Object, e As EventArgs) Handles btnAMEX.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "AMEX" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUnionpay_Click(sender As Object, e As EventArgs) Handles btnUnionpay.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "UnionPay" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAlipay_Click(sender As Object, e As EventArgs) Handles btnAlipay.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "Alipay" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnWechat_Click(sender As Object, e As EventArgs) Handles btnWechat.Click
        Try
            Dim F As New frm_payment_chash
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "USD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "WeChat Pay" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True

            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ----------------------------------------------------------------------
    ' --- 13. API Exchange Rate Fetching (New Section) ---
    ' ----------------------------------------------------------------------

    ''' <summary>
    ''' Fetches the latest exchange rate for a given currency code from the API.
    ''' </summary>
    ''' <param name="currencyCode">The currency code (e.g., "KHR", "THB").</param>
    ''' <returns>The rate value as a Decimal, or 0D if the fetch fails.</returns>
    Private Async Function FetchExchangeRate(currencyCode As String) As Task(Of Decimal)
        Try
            ' The API endpoint is: GET /api/exchange-rates/latest/:cur_code
            Dim apiUrl As String = $"{API_BASE_URL}/api/exchange-rates/latest/{currencyCode}"

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim rateData As JObject = JObject.Parse(jsonString)

                If rateData IsNot Nothing AndAlso rateData("rate_value") IsNot Nothing Then
                    Dim rateValue As Decimal = 0D
                    If Decimal.TryParse(rateData("rate_value").ToString(), rateValue) Then
                        Return rateValue
                    End If
                End If
                Return 0D ' Failed to parse rate_value
            ElseIf response.StatusCode = Net.HttpStatusCode.NotFound Then
                ' No rate found for the currency code, use default and log
                Console.WriteLine($"Exchange rate not found for {currencyCode} on the latest date. Using default rate.")
                Return 0D
            Else
                ' Handle other HTTP error codes
                Dim errorDetails = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"API Error fetching {currencyCode} rate: {response.StatusCode}. Details: {errorDetails}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0D
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server to fetch exchange rates. Ensure the server is running at " & API_BASE_URL & ". 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0D
        Catch ex As Exception
            MessageBox.Show($"Error processing API response for {currencyCode}: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0D
        End Try
    End Function

    ''' <summary>
    ''' Fetches KHR and THB exchange rates and updates the corresponding textboxes on form load.
    ''' </summary>
    Private Async Function FetchExchangeRates() As Task
        ' Fetch KHR rate
        Dim khrRate As Decimal = Await FetchExchangeRate("KHR")
        If khrRate > 0D Then
            txtKHRRate.Text = khrRate.ToString("0")
        Else
            txtKHRRate.Text = "4100"
        End If

        ' Fetch THB rate
        Dim thbRate As Decimal = Await FetchExchangeRate("THB")
        If thbRate > 0D Then
            txtTHBRate.Text = thbRate.ToString(v_FormatNo)
        Else
            txtTHBRate.Text = "39.00"
        End If

        ' After rates are set, update the summary to reflect the correct total and currency translations
        UpdateTotalSummary()
    End Function ' ⭐ End of Function ⭐

    ' ----------------------------------------------------------------------
    ' --- 14. Exchange Rate Text Changed Handlers (Updated Section) ---
    ' ----------------------------------------------------------------------

    Private Sub txtKHRRate_TextChanged(sender As Object, e As EventArgs) Handles txtKHRRate.TextChanged
        ' Recalculate summary if rate changes (either by API update or manual user input)
        UpdateTotalSummary()
    End Sub

    Private Sub txtTHBRate_TextChanged(sender As Object, e As EventArgs) Handles txtTHBRate.TextChanged
        ' Recalculate summary if rate changes (either by API update or manual user input)
        UpdateTotalSummary()
    End Sub

    Private Sub btnShppingFee_Click(sender As Object, e As EventArgs) Handles btnShppingFee.Click
        Dim F As New frm_shpping_fee()
        F.FormBorderStyle = FormBorderStyle.None

        ' Check if the user clicked the Confirm button (DialogResult.OK)
        If F.ShowDialog() = DialogResult.OK Then
            Try
                ' Get the confirmed amount from the public property of the closed form
                Dim confirmedFee As Decimal = F.ShippingAmount

                ' Set the value to txtShippingFee on the main form
                txtShippingFee.Text = confirmedFee.ToString(v_FormatNo)

                ' Recalculation is automatically handled by txtShippingFee_TextChanged

            Catch ex As Exception
                MessageBox.Show("Error retrieving shipping fee: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCOD_Click(sender As Object, e As EventArgs) Handles btnCOD.Click
        Try
            Dim F As New frm_dl_list
            F.FormBorderStyle = FormBorderStyle.None
            F.txtUSD.Text = "COD"

            Dim totalDue As Decimal = UpdateTotalSummary()
            Dim totalPaymentReceived As Decimal = 0D

            For Each row As DataGridViewRow In dg_Payment.Rows
                If row.IsNewRow Then Continue For
                Dim amount As Decimal = 0D
                ' SUMMING FROM USD_REC_AMT (the new hidden column)
                If Decimal.TryParse(row.Cells("USD_REC_AMT").Value.ToString(), amount) Then
                    totalPaymentReceived += amount
                End If
            Next

            Dim remainingDue As Decimal = totalDue - totalPaymentReceived
            If remainingDue < 0D Then remainingDue = 0D

            F.txtReciveAmount.Text = remainingDue.ToString(v_FormatNo)

            ' PASS RATE/CURRENCY TO PAYMENT FORM
            F.PaymentMethod = "COD" ' Pass a generic method name
            F.CurrencyCode = "USD"
            F.ExchangeRate = 1D
            F.IsBaseCurrency = True
            F.ParentFormSell = Me
            F.ShowDialog()

            ' CAPTURE LAST PAYMENT DETAILS
            If F.DialogResult = DialogResult.OK Then
                v_LastPaymentCurrency = "USD"
                v_LastPaymentRate = 1D
            End If

            SumPaymentAmounts()
        Catch ex As Exception
            MessageBox.Show(ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ======================================================================
    ' --- 15. Global Variables for Printing ---
    ' ======================================================================
    Private WithEvents PrintDocument1 As New System.Drawing.Printing.PrintDocument
    Private PrintPreviewDialog1 As New System.Windows.Forms.PrintPreviewDialog
    ' Store the content string so the PrintPage event can access it
    Private v_ReceiptContentToPrint As String = ""

    ' ======================================================================
    ' --- 16. Print Document Event Handler (Drawing the Receipt) - REVISED FONT & MARGINS ---
    ' ======================================================================

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' --- Configuration ---
        Dim leftMargin As Single = 1

        ' ⭐ 2. DYNAMIC LOGO PATH (Updated to use Application.StartupPath and correct file name) ⭐
        ' This assumes PositronLogo.png is in the same folder as the application's executable (.exe)
        Dim logoPath As String = Application.StartupPath & "\" & "CompanyLogo.png"

        Dim yPosition As Single = e.MarginBounds.Top
        ' --- 1. Draw Logo Dynamically ---
        Try
            Using logoImage As Image = Image.FromFile(logoPath)

                ' Define the logo's width and height on the receipt paper
                Dim targetWidth As Integer = 150 ' Typical width for an 80mm printer
                ' Calculate height to maintain aspect ratio
                Dim targetHeight As Integer = CInt((logoImage.Height / logoImage.Width) * targetWidth)

                ' Calculate X position to center the logo within the print area (approx 250px wide)
                Dim printAreaWidth As Single = 250.0F
                Dim centerOffset As Single = (printAreaWidth - targetWidth) / 2.0F
                Dim xPosition As Single = leftMargin + centerOffset

                ' Draw the logo
                e.Graphics.DrawImage(logoImage, xPosition, yPosition, targetWidth, targetHeight)

                ' Update Y position for the next text line
                yPosition += targetHeight
            End Using
        Catch ex As Exception
            ' Handle missing/invalid logo: Draw a placeholder text
            ' Note: If this text prints, the file path is still incorrect or the file is locked/invalid.
            Dim errorFont As New Font("Arial", 10)
            e.Graphics.DrawString("[LOGO MISSING/ERROR]", errorFont, Brushes.Red, leftMargin, yPosition)
            yPosition += errorFont.GetHeight(e.Graphics) * 1.5F ' Add space for the placeholder
        End Try

        ' --- 2. Add Space and Text Content ---
        ' Add a little space after the logo/placeholder
        yPosition += 5.0F

        ' Text Content Setup
        Dim font As New Font("Courier New", 8, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)
        Dim lineHeight As Single = font.GetHeight(e.Graphics) * 1.1F

        ' Split the receipt text content (assuming v_ReceiptContentToPrint is accessible)
        Dim lines() As String = v_ReceiptContentToPrint.Split(New String() {vbCrLf}, StringSplitOptions.None)

        ' Draw each line of the receipt content (text)
        For Each line As String In lines
            ' All text starts at the adjusted leftMargin
            e.Graphics.DrawString(line, font, brush, leftMargin, yPosition)
            yPosition += lineHeight
        Next

        e.HasMorePages = False
    End Sub
    ' ======================================================================
    ' --- 17. Receipt Generation Logic (Formatting Data) - REVISED FOR 40 CHARS ---
    ' ======================================================================

    Private Function GenerateReceiptContent(ByVal receiptNo As String) As String
        Dim receiptLines As New System.Text.StringBuilder()

        ' ⭐ FIX: Set fixed character width to 40 for optimal and safe fit on 80mm paper. ⭐
        Const TOTAL_WIDTH As Integer = 40
        Const DASH_LINE As String = "----------------------------------------" ' 40 dashes
        Const EQUAL_LINE As String = "========================================" ' 40 equals

        ' Helper function to center a string based on TOTAL_WIDTH
        Dim CenterLine = Function(text As String) As String
                             Dim padding As Integer = (TOTAL_WIDTH - text.Length) / 2
                             If padding < 0 Then padding = 0
                             Return New String(" "c, padding) & text
                         End Function

        ' --- Header Section ---
        receiptLines.AppendLine()
        receiptLines.AppendLine(CenterLine(V_StoreName))
        receiptLines.AppendLine(CenterLine("Store ID: " & V_StoreId))
        receiptLines.AppendLine(CenterLine("Tel: 020-386-****"))
        receiptLines.AppendLine(DASH_LINE)

        receiptLines.AppendLine(String.Format("RECEIPT NO: {0}", receiptNo))
        receiptLines.AppendLine(String.Format("DATE: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm")))
        receiptLines.AppendLine(String.Format("CASHIER: {0}", V_CashierName))

        If v_DeliveryId > 0 Then
            receiptLines.AppendLine(String.Format("DELIVERY: {0}", lblDelivery.Text))
        End If

        receiptLines.AppendLine(EQUAL_LINE)

        ' --- Detail Section Header (Total width: 40 characters) ---
        ' Breakdown: Description (20) + Qty (5) + Unit Price (15) = 40
        receiptLines.AppendLine(String.Format("{0,-20}{1,5}{2,15}", "ITEM DESCRIPTION", "QTY", "AMOUNT"))
        receiptLines.AppendLine(DASH_LINE)

        ' --- Detail Line Items ---
        Dim totalItemsInTransaction As Integer = 0

        For Each row As DataGridViewRow In dg_Items.Rows
            If row.IsNewRow Then Continue For
            totalItemsInTransaction += 1

            Dim itemName As String = row.Cells("i_DESC").Value.ToString().Trim()
            Dim qty As Decimal = CDec(row.Cells("i_Qty").Value)
            Dim unitPrice As Decimal = CDec(row.Cells("i_Price").Value)
            Dim netAmt As Decimal = CDec(row.Cells("i_NetAmt").Value)
            Dim lineDisAmt As Decimal = CDec(row.Cells("i_DisAmt").Value)

            ' Line 1: Item Name (Truncated) and Net Amount
            Dim displayItemName As String = itemName
            If displayItemName.Length > 20 Then displayItemName = displayItemName.Substring(0, 20)

            ' Format: [Item Name] [Blank Space] [Net Amount]
            receiptLines.AppendLine(String.Format("{0,-20}  {1,18:0.00}", displayItemName, netAmt))

            ' Line 2: QTY and Unit Price (Detailed breakdown for price accuracy)
            ' Format: [  @ Unit Price] [x QTY] [Blank Space]
            receiptLines.AppendLine(String.Format("{0,-20} x{1,5:0.00} @ {2,10:0.00}", "", qty, unitPrice))

            If lineDisAmt > 0D Then
                ' Discount line: [  - Discount Label] [Discount Amount]
                receiptLines.AppendLine(String.Format("{0,-25} {1,15:0.00}", "  - Line Discount:", -lineDisAmt))
            End If
        Next

        receiptLines.AppendLine(DASH_LINE)

        ' --- Summary Section (Total width: 40 characters) ---
        ' Label (25) + Value (15) = 40

        Dim subTotalNet As Decimal = 0D : Decimal.TryParse(txtSubTotal.Text, subTotalNet)
        Dim checkDiscountAmt As Decimal = 0D : Decimal.TryParse(txtCheckDiscountAmt.Text, checkDiscountAmt)
        Dim vatAmt As Decimal = 0D : Decimal.TryParse(txtVat.Text, vatAmt)
        Dim shippingFee As Decimal = 0D : Decimal.TryParse(txtShippingFee.Text, shippingFee)
        Dim grandTotal As Decimal = 0D : Decimal.TryParse(txtNetTotal.Text, grandTotal)
        Dim changeText As String = txtChange.Text

        receiptLines.AppendLine(String.Format("Total Items: {0}", totalItemsInTransaction))
        receiptLines.AppendLine(DASH_LINE)

        ' Subtotal, Fees, and Tax
        receiptLines.AppendLine(String.Format("{0,-25} {1,15:0.00}", "SUBTOTAL (Net):", subTotalNet))

        If checkDiscountAmt > 0D Then
            receiptLines.AppendLine(String.Format("{0,-25} {1,15:0.00}", "CHECK DISCOUNT:", -checkDiscountAmt))
        End If

        If shippingFee > 0D Then
            receiptLines.AppendLine(String.Format("{0,-25} {1,15:0.00}", "SHIPPING FEE:", shippingFee))
        End If

        If vatAmt > 0D Then
            receiptLines.AppendLine(String.Format("{0,-25} {1,15:0.00}", "VAT/TAX AMOUNT:", vatAmt))
        End If

        receiptLines.AppendLine(EQUAL_LINE)

        ' Emphasis on Grand Total
        receiptLines.AppendLine(String.Format("{0,-25} {1,15}", "**GRAND TOTAL (USD):**", Format(grandTotal, "0.00")))

        receiptLines.AppendLine(DASH_LINE)

        ' --- Payment Method Section ---
        receiptLines.AppendLine(CenterLine("PAYMENT RECEIVED"))

        For Each pmtRow As DataGridViewRow In dg_Payment.Rows
            If pmtRow.IsNewRow Then Continue For
            Dim method As String = pmtRow.Cells("PAY_METHOD").Value.ToString()
            Dim recAmtLocal As Decimal = CDec(pmtRow.Cells("REC_AMT").Value)
            Dim curCode As String = pmtRow.Cells("CURRENCY").Value.ToString()

            Dim paymentLabel As String = method & " (" & curCode & "):"
            If paymentLabel.Length > 25 Then paymentLabel = paymentLabel.Substring(0, 25)

            ' Format: [Method + Currency, 25 chars] [Amount, 15 chars]
            receiptLines.AppendLine(String.Format(" - {0,-25} {1,13:0.00}", paymentLabel, recAmtLocal))
        Next

        receiptLines.AppendLine(DASH_LINE)

        ' Change line - Use the formatted text from the UI
        receiptLines.AppendLine(String.Format("{0,-25} {1,15}", "**CHANGE:**", changeText))

        receiptLines.AppendLine(EQUAL_LINE)

        ' --- Footer Section ---
        receiptLines.AppendLine()
        receiptLines.AppendLine(CenterLine("THANK YOU FOR YOUR PURCHASE!"))
        receiptLines.AppendLine(CenterLine("Please come again."))
        receiptLines.AppendLine(DASH_LINE)
        receiptLines.AppendLine()
        receiptLines.AppendLine()

        Return receiptLines.ToString()
    End Function
    ' ======================================================================
    ' --- 18. Print/Preview Execution Handler ---
    ' This forces the Print Preview dialog to show. The actual printing 
    ' must be triggered by the user from within the dialog.
    ' ======================================================================

    Private Sub PrintReceiptExecute(ByVal receiptNo As String)
        ' 1. Generate Content
        v_ReceiptContentToPrint = GenerateReceiptContent(receiptNo)

        Try
            ' 2. Assign Document and Set Title
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.Text = "Receipt Preview: " & receiptNo

            ' 3. Show the Preview Dialog
            ' Execution pauses here until the user closes the dialog.
            PrintPreviewDialog1.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error preparing receipt print/preview: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class