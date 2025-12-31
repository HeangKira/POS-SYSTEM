Imports System.Runtime.InteropServices
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Drawing

Public Class frm_delivery_shpping

    ' --- Constants and API Client ---
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    'Private Const API_BASE_URL As String = "http://localhost:5005"
    Private ReadOnly httpClient As New HttpClient()
    Private Const V_ProjectName As String = "POS System - Payment Log"

    ' --- Windows DLL Imports for Draggable Form ---
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
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ---------------------------------------------------------------------
    ' ## 🚀 Form Load and Data Fetching Logic 
    ' ---------------------------------------------------------------------
    Private Async Sub frm_delivery_shpping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Transaction Payment Log Update"

        InitializeDataGridViewLayout()

        ' Set default date to today
        If Me.Controls.ContainsKey("dtpDLDate") AndAlso TypeOf Me.Controls("dtpDLDate") Is DateTimePicker Then
            CType(Me.Controls("dtpDLDate"), DateTimePicker).Value = DateTime.Today
        End If

        Await LoadReceiptsData()
    End Sub

    Private Sub InitializeDataGridViewLayout()
        With dgtDeliveryList
            .AutoGenerateColumns = False
            .DataSource = Nothing
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()

            ' Define columns
            .Columns.Add("StoreCode", "Store Code")
            .Columns.Add("StoreName", "Store Name")
            .Columns.Add("ReceiptNumber", "Receipt Number")
            .Columns.Add("ReceiptDate", "Receipt Date")
            .Columns.Add("StatusInvoice", "Status Invoice")
            .Columns.Add("CashierName", "Cashier Name")
            .Columns.Add("DeliveryName", "Delivery Name")
            .Columns.Add("DeliveryID", "Delivery ID")

            ' Formatting
            .Columns("CashierName").Visible = False
            .Columns("StatusInvoice").Visible = False
            .Columns("StoreCode").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("ReceiptNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("ReceiptDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"

            ' Add the "Receipt Amount" button column
            If Not .Columns.Contains("LogPaymentButton") Then
                Dim btnCol As New DataGridViewButtonColumn()
                With btnCol
                    .HeaderText = "Action"
                    .Name = "LogPaymentButton"
                    .Text = "Receipt Amount"
                    .UseColumnTextForButtonValue = True
                    .Width = 120
                    .FlatStyle = FlatStyle.Flat
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                .Columns.Add(btnCol)
            End If
        End With
    End Sub

    'Private Async Function LoadReceiptsData() As Task
    '    Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales"

    '    Dim selectedDate As DateTime = DateTime.Today
    '    If Me.Controls.ContainsKey("dtpDLDate") AndAlso TypeOf Me.Controls("dtpDLDate") Is DateTimePicker Then
    '        selectedDate = CType(Me.Controls("dtpDLDate"), DateTimePicker).Value.Date
    '    End If

    '    Try
    '        Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

    '        If response.IsSuccessStatusCode Then
    '            Dim jsonString As String = Await response.Content.ReadAsStringAsync()
    '            Dim jsonObject As JObject = JObject.Parse(jsonString)
    '            Dim salesListToken As JToken = jsonObject("sales_list")
    '            Dim reportData As JArray = If(salesListToken IsNot Nothing, CType(salesListToken, JArray), New JArray())

    '            dgtDeliveryList.Rows.Clear()

    '            If reportData.Count > 0 Then
    '                For Each item As JObject In reportData.Children(Of JObject)()
    '                    Dim receiptDateTime As DateTime = If(item("receipt_date") IsNot Nothing, item("receipt_date").ToObject(Of DateTime), DateTime.MinValue)

    '                    ' 1. Filter by Date
    '                    If receiptDateTime.Date = selectedDate.Date Then

    '                        ' 2. Filter: Only show Active (Status 1) transactions
    '                        Dim receiptStatus As Integer = If(item("receipt_status") IsNot Nothing, item("receipt_status").ToObject(Of Integer), 0)
    '                        If receiptStatus <> 1 Then Continue For

    '                        Dim storeID As String = If(item("store_id") IsNot Nothing, item("store_id").ToString(), "")
    '                        Dim storeName As String = If(item("store_name") IsNot Nothing, item("store_name").ToString(), "")
    '                        Dim receiptNo As String = If(item("receipt_no") IsNot Nothing, item("receipt_no").ToString(), "")
    '                        Dim deliveryName As String = If(item("delivery_name") IsNot Nothing AndAlso item("delivery_name").Type <> JTokenType.Null, item("delivery_name").ToString(), "N/A")

    '                        ' Add the row
    '                        Dim rowIndex As Integer = dgtDeliveryList.Rows.Add(
    '                            storeID,
    '                            storeName,
    '                            receiptNo,
    '                            receiptDateTime,
    '                            "Active",
    '                            If(item("cashier_name") IsNot Nothing, item("cashier_name").ToString(), ""),
    '                            deliveryName,
    '                            If(item("delivery_id") IsNot Nothing AndAlso item("delivery_id").Type <> JTokenType.Null, item("delivery_id").ToString(), "")
    '                        )

    '                        ' Color the button green
    '                        dgtDeliveryList.Rows(rowIndex).Cells("LogPaymentButton").Style.BackColor = Color.ForestGreen
    '                        dgtDeliveryList.Rows(rowIndex).Cells("LogPaymentButton").Style.ForeColor = Color.White
    '                    End If
    '                Next
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Error loading data: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function
    Private Async Function LoadReceiptsData() As Task
        ' 1. Identify the API URL
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales"

        ' 2. Get the date from your DateTimePicker control
        ' Note: Using Me.dtpDLDate directly is safer if it's a standard control on the form
        Dim selectedDate As DateTime = dtpDLDate.Value.Date

        Try
            ' Show a loading state or clear rows first
            dgtDeliveryList.Rows.Clear()

            ' 3. Security/Permission Check
            Dim canUserSettle As Boolean = UserSession.HasAction("/pos/btn-delivery", "create") OrElse
                                       UserSession.HasAction("/pos/btn-delivery", "update")

            ' 4. Fetch Data
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObject As JObject = JObject.Parse(jsonString)
                Dim reportData As JArray = If(jsonObject("sales_list") IsNot Nothing, CType(jsonObject("sales_list"), JArray), New JArray())

                ' 5. Loop and Filter
                For Each item As JObject In reportData
                    ' Get the date from JSON
                    Dim receiptDateTime As DateTime = If(item("receipt_date") IsNot Nothing, item("receipt_date").ToObject(Of DateTime), DateTime.MinValue)

                    ' ⭐ CRITICAL FILTER: Compare the Date portions only
                    If receiptDateTime.Date = selectedDate Then

                        ' Status Check (e.g., only show Active invoices)
                        Dim receiptStatus As Integer = If(item("receipt_status") IsNot Nothing, item("receipt_status").ToObject(Of Integer), 0)
                        If receiptStatus <> 1 Then Continue For

                        ' Add the data to the DataGridView
                        Dim rowIndex As Integer = dgtDeliveryList.Rows.Add(
                        item("store_id").ToString(),
                        item("store_name").ToString(),
                        item("receipt_no").ToString(),
                        receiptDateTime,
                        "Active",
                        item("cashier_name").ToString(),
                        If(item("delivery_name")?.Type <> JTokenType.Null, item("delivery_name").ToString(), "N/A"),
                        If(item("delivery_id")?.Type <> JTokenType.Null, item("delivery_id").ToString(), "")
                    )

                        ' Handle Button Appearance based on permissions
                        ApplyButtonStyling(rowIndex, canUserSettle)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' Helper method to keep code clean
    Private Sub ApplyButtonStyling(rowIndex As Integer, canUserSettle As Boolean)
        With dgtDeliveryList.Rows(rowIndex).Cells("LogPaymentButton")
            If canUserSettle Then
                .Value = "Receipt Amount"
                .Style.BackColor = Color.ForestGreen
                .Style.ForeColor = Color.White
                .ReadOnly = False
            Else
                .Value = "Locked"
                .Style.BackColor = Color.LightGray
                .Style.ForeColor = Color.DimGray
                .ReadOnly = True
            End If
        End With
    End Sub

    ''' <summary>
    ''' Updates the payment log in the database via API.
    ''' </summary>
    Private Async Function UpdatePaymentLog(ByVal receiptNo As String, ByVal originalPaymentMethod As String) As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo}/update-delivery-payment"
        Dim currentLoggedUser As String = main_pos_system.LoggedInUserName

        If String.IsNullOrEmpty(currentLoggedUser) Then currentLoggedUser = "System"

        Dim requestBody As New JObject From {
            {"pay_updateby", currentLoggedUser},
            {"pay_orginalmethod", originalPaymentMethod}
        }

        Try
            Dim content As New StringContent(requestBody.ToString(), System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PutAsync(apiUrl, content)

            If response.IsSuccessStatusCode Then
                MessageBox.Show($"Receipt {receiptNo} settled successfully as '{originalPaymentMethod}'.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadReceiptsData() ' Refresh the grid
            Else
                MessageBox.Show("Failed to update payment. Please try again.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("API Error: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' ---------------------------------------------------------------------
    ' ## 📅 Events
    ' ---------------------------------------------------------------------
    Private Async Sub dtpDLDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDLDate.ValueChanged
        Await LoadReceiptsData()
    End Sub


    'Private Async Sub dgtDeliveryList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDeliveryList.CellContentClick
    '    ' Check if "Receipt Amount" button clicked
    '    If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgtDeliveryList.Columns("LogPaymentButton").Index Then

    '        Dim clickedRow As DataGridViewRow = dgtDeliveryList.Rows(e.RowIndex)
    '        Dim receiptNo As String = clickedRow.Cells("ReceiptNumber").Value.ToString()

    '        Try
    '            ' Open the settlement dialog
    '            Dim frm As New frm_assigned_dl()
    '            frm.ReceiptNumber = receiptNo

    '            If frm.ShowDialog(Me) = DialogResult.OK Then
    '                Dim selectedMethod As String = frm.OriginalPaymentMethod
    '                ' Update DB: This changes COD to the actual method (Cash/QR)
    '                Await UpdatePaymentLog(receiptNo, selectedMethod)
    '            End If

    '            frm.Dispose()
    '        Catch ex As Exception
    '            MessageBox.Show("Error: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End If
    'End Sub
    Private Async Sub dgtDeliveryList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDeliveryList.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgtDeliveryList.Columns("LogPaymentButton").Index Then

            ' ⭐ THE SECURITY GUARD: Check permission again before doing anything
            Dim canUserSettle As Boolean = UserSession.HasAction("/pos/btn-delivery", "create") OrElse
                                       UserSession.HasAction("/pos/btn-delivery", "update")

            If Not canUserSettle Then
                MessageBox.Show("Access Denied: You have 'View' permission only. You cannot perform this action.",
                            V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            ' 2. Proceed with existing logic if authorized
            Dim clickedRow As DataGridViewRow = dgtDeliveryList.Rows(e.RowIndex)
            Dim receiptNo As String = clickedRow.Cells("ReceiptNumber").Value.ToString()

            Try
                Dim frm As New frm_assigned_dl()
                frm.ReceiptNumber = receiptNo

                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim selectedMethod As String = frm.OriginalPaymentMethod
                    Await UpdatePaymentLog(receiptNo, selectedMethod)
                End If
                frm.Dispose()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class