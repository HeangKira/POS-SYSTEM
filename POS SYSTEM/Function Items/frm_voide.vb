Imports System.Runtime.InteropServices
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Drawing

Public Class frm_voide
    ' --- Constants and API Client ---
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005" ' Match API base URL
    Private ReadOnly httpClient As New HttpClient()
    Private Const V_ProjectName As String = "POS System"

    ' --- Windows DLL Imports (Existing Code) ---
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
    ' --- Form Load and Data Fetching Logic ---
    ' ---------------------------------------------------------------------
    Private Async Sub frm_voide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGridViewLayout()

        ' Set dtpVoidDate to today
        If Me.Controls.ContainsKey("dtpVoidDate") AndAlso TypeOf Me.Controls("dtpVoidDate") Is DateTimePicker Then
            CType(Me.Controls("dtpVoidDate"), DateTimePicker).Value = DateTime.Today
        End If

        Await LoadReceiptsData()
    End Sub

    ''' <summary>
    ''' Sets up the layout for the dgtDeliveryList DataGridView.
    ''' </summary>
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

            ' Define fixed columns
            .Columns.Add("StoreCode", "Store Code")
            .Columns.Add("StoreName", "Store Name")
            .Columns.Add("ReceiptNumber", "Receipt Number")
            .Columns.Add("ReceiptDate", "Receipt Date")
            .Columns.Add("StatusInvoice", "Status Invoice")
            .Columns.Add("CashierName", "Cashier Name")

            ' Access column directly to set format
            .Columns("ReceiptDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"

            ' Add the Void button column
            If Not .Columns.Contains("VoidButton") Then
                Dim btnCol As New DataGridViewButtonColumn()
                With btnCol
                    .HeaderText = "Action"
                    .Name = "VoidButton"
                    .Text = "Void"
                    .UseColumnTextForButtonValue = True
                    .Width = 60
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                .Columns.Add(btnCol)
            End If

            .Columns("StatusInvoice").DefaultCellStyle.Font = New Font(dgtDeliveryList.Font, FontStyle.Bold)
        End With
    End Sub

    'Private Async Function LoadReceiptsData() As Task
    '    Dim apiUrl As String = $"{API_BASE_URL}/api/pos/receipts-report"

    '    ' Determine the target date for filtering (from the date picker)
    '    Dim selectedDate As DateTime = DateTime.Today
    '    If Me.Controls.ContainsKey("dtpVoidDate") AndAlso TypeOf Me.Controls("dtpVoidDate") Is DateTimePicker Then
    '        selectedDate = CType(Me.Controls("dtpVoidDate"), DateTimePicker).Value.Date
    '    End If

    '    Try
    '        Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

    '        If response.IsSuccessStatusCode Then
    '            Dim jsonString As String = Await response.Content.ReadAsStringAsync()
    '            Dim jsonObject As JObject = JObject.Parse(jsonString)
    '            Dim reportData As JArray = CType(jsonObject("report_data"), JArray)

    '            dgtDeliveryList.Rows.Clear()

    '            If reportData IsNot Nothing AndAlso reportData.Count > 0 Then

    '                ' ⭐ Client-Side Filtering to match dtpVoidDate ⭐
    '                For Each item As JObject In reportData.Children(Of JObject)()
    '                    Dim receiptDate As DateTime = item("Receipt Date").ToObject(Of DateTime).Date

    '                    ' Filter 1: Only display receipts that match the selected date
    '                    If receiptDate.Date = selectedDate.Date Then

    '                        Dim receiptStatus As String = item("Status Invoice").ToString()

    '                        Dim rowIndex As Integer = dgtDeliveryList.Rows.Add(
    '                            item("Store Code").ToString(),
    '                            item("Store Name").ToString(),
    '                            item("Receipt Number").ToString(),
    '                            item("Receipt Date").ToObject(Of DateTime),
    '                            receiptStatus,
    '                            item("Cashier Name").ToString()
    '                        )

    '                        ' Conditional formatting and button status
    '                        With dgtDeliveryList.Rows(rowIndex)
    '                            If receiptStatus = "Voided" Then
    '                                .DefaultCellStyle.BackColor = Color.LightCoral
    '                                .Cells("VoidButton").ReadOnly = True
    '                                .Cells("VoidButton").Style.BackColor = Color.Gray
    '                                .Cells("VoidButton").Style.ForeColor = Color.DarkGray
    '                            Else
    '                                .Cells("VoidButton").ReadOnly = False
    '                                .Cells("VoidButton").Style.ForeColor = Color.White

    '                                ' Visually indicate if the receipt is NOT today's date
    '                                If receiptDate.Date <> DateTime.Today.Date Then
    '                                    .Cells("VoidButton").Style.BackColor = Color.DarkRed
    '                                    .Cells("VoidButton").ToolTipText = "Voiding this will fail (Not Current Date)"
    '                                Else
    '                                    .Cells("VoidButton").Style.BackColor = Color.OrangeRed
    '                                End If
    '                            End If
    '                        End With
    '                    End If
    '                Next

    '                If dgtDeliveryList.Rows.Count = 0 Then
    '                    Console.WriteLine($"No receipts found for {selectedDate.ToShortDateString()}.")
    '                End If
    '            Else
    '                Console.WriteLine("No receipt data found in the API response.")
    '            End If
    '        Else
    '            ' 🟢 IMPROVED ERROR HANDLING 🟢
    '            Dim errorDetails = Await response.Content.ReadAsStringAsync()
    '            Dim errorMessage As String = $"API Error ({response.StatusCode}): Failed to fetch receipts report."

    '            Try
    '                ' Try to parse the JSON error body from the server
    '                Dim errorJson As JObject = JObject.Parse(errorDetails)
    '                If errorJson IsNot Nothing AndAlso errorJson.ContainsKey("message") Then
    '                    errorMessage = $"API Error ({response.StatusCode}): {errorJson("message").ToString()}"
    '                End If
    '            Catch exJson As Exception
    '                ' If parsing fails, append the raw content for debugging
    '                errorMessage = $"{errorMessage}. Raw details: {errorDetails.Substring(0, Math.Min(errorDetails.Length, 150))}..."
    '            End Try

    '            MessageBox.Show(errorMessage, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If

    '    Catch ex As HttpRequestException
    '        MessageBox.Show("Connection Error: Could not reach the API server. Ensure the server is running at " & API_BASE_URL & ". 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("Error processing API response or binding data: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function
    Private Async Function LoadReceiptsData() As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/receipts-report"
        Dim selectedDate As DateTime = DateTime.Today

        If Me.Controls.ContainsKey("dtpVoidDate") AndAlso TypeOf Me.Controls("dtpVoidDate") Is DateTimePicker Then
            selectedDate = CType(Me.Controls("dtpVoidDate"), DateTimePicker).Value.Date
        End If

        Try
            ' PERMISSION CHECK: Must have 'update' checkbox checked in React for "/pos/btn-void"
            Dim canUserUpdateVoid As Boolean = UserSession.HasAction("/pos/btn-void", "update")

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObject As JObject = JObject.Parse(jsonString)
                Dim reportData As JArray = CType(jsonObject("report_data"), JArray)

                dgtDeliveryList.Rows.Clear()

                If reportData IsNot Nothing AndAlso reportData.Count > 0 Then
                    For Each item As JObject In reportData.Children(Of JObject)()
                        Dim receiptDate As DateTime = item("Receipt Date").ToObject(Of DateTime).Date

                        If receiptDate.Date = selectedDate.Date Then
                            Dim receiptStatus As String = item("Status Invoice").ToString()

                            Dim rowIndex As Integer = dgtDeliveryList.Rows.Add(
                                item("Store Code").ToString(),
                                item("Store Name").ToString(),
                                item("Receipt Number").ToString(),
                                item("Receipt Date").ToObject(Of DateTime),
                                receiptStatus,
                                item("Cashier Name").ToString()
                            )

                            With dgtDeliveryList.Rows(rowIndex)
                                If receiptStatus = "Voided" Then
                                    .Cells("VoidButton").Value = "Voided"
                                    .Cells("VoidButton").ReadOnly = True
                                    .Cells("VoidButton").Style.BackColor = Color.Gray
                                Else
                                    ' ⭐ Apply Permission Logic
                                    If canUserUpdateVoid Then
                                        .Cells("VoidButton").Value = "Void"
                                        .Cells("VoidButton").ReadOnly = False
                                        ' Visually indicate if receipt is not from today
                                        If receiptDate.Date <> DateTime.Today.Date Then
                                            .Cells("VoidButton").Style.BackColor = Color.DarkRed
                                        Else
                                            .Cells("VoidButton").Style.BackColor = Color.OrangeRed
                                        End If
                                        .Cells("VoidButton").Style.ForeColor = Color.White
                                    Else
                                        ' 🔒 User only has "View" - Lock the button
                                        .Cells("VoidButton").Value = "Locked"
                                        .Cells("VoidButton").ReadOnly = True
                                        .Cells("VoidButton").Style.BackColor = Color.LightGray
                                        .Cells("VoidButton").Style.ForeColor = Color.DimGray
                                    End If
                                End If
                            End With
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    ' ---------------------------------------------------------------------
    ' --- Cell Click Handler (Initiate Void and Popup Reason) ---
    ' ---------------------------------------------------------------------
    'Private Async Sub dgtDeliveryList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDeliveryList.CellContentClick
    '    If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

    '    If dgtDeliveryList.Columns(e.ColumnIndex).Name = "VoidButton" Then
    '        Dim row As DataGridViewRow = dgtDeliveryList.Rows(e.RowIndex)
    '        Dim receiptNo As String = row.Cells("ReceiptNumber").Value.ToString()
    '        Dim currentStatus As String = row.Cells("StatusInvoice").Value.ToString()

    '        If currentStatus = "Voided" Then
    '            MessageBox.Show("This receipt is already voided.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If

    '        ' ⭐ FIX: Use the actual frm_void_reason form for input ⭐
    '        ' NOTE: This assumes you have a form named frm_void_reason with a public property called VoidReason
    '        Dim frmReason As New frm_void_reason()
    '        frmReason.Text = $"Voiding Receipt: {receiptNo}"

    '        If frmReason.ShowDialog() = DialogResult.OK Then

    '            Dim voidReason As String = frmReason.VoidReason

    '            ' Validate that the reason property was set (i.e., the user typed something)
    '            If String.IsNullOrWhiteSpace(voidReason) Then
    '                MessageBox.Show("Void reason cannot be empty. Please try again.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                frmReason.Dispose()
    '                Exit Sub
    '            End If

    '            If MessageBox.Show($"Confirm void for receipt {receiptNo} with reason: {voidReason}?", V_ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

    '                ' STEP 2: Pass the receipt number and the reason to the API
    '                Await VoidSelectedReceipt(receiptNo, voidReason)
    '            End If
    '        End If

    '        ' Clean up the form after use
    '        frmReason.Dispose()
    '    End If
    'End Sub
    Private Async Sub dgtDeliveryList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDeliveryList.CellContentClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        If dgtDeliveryList.Columns(e.ColumnIndex).Name = "VoidButton" Then

            ' 1. Check permission again (Security Guard)
            If Not UserSession.HasAction("/pos/btn-void", "update") Then
                MessageBox.Show("Access Denied: You do not have 'Update' permission to void receipts.",
                                V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim row As DataGridViewRow = dgtDeliveryList.Rows(e.RowIndex)
            Dim receiptNo As String = row.Cells("ReceiptNumber").Value.ToString()
            Dim currentStatus As String = row.Cells("StatusInvoice").Value.ToString()

            If currentStatus = "Voided" Then
                MessageBox.Show("This receipt is already voided.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim frmReason As New frm_void_reason()
            frmReason.Text = $"Voiding Receipt: {receiptNo}"

            If frmReason.ShowDialog() = DialogResult.OK Then
                Dim voidReason As String = frmReason.VoidReason
                If String.IsNullOrWhiteSpace(voidReason) Then
                    MessageBox.Show("Void reason cannot be empty.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If MessageBox.Show($"Confirm void for receipt {receiptNo}?", V_ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Await VoidSelectedReceipt(receiptNo, voidReason)
                End If
            End If
            frmReason.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' Calls the restricted API endpoint to void a transaction.
    ''' </summary>
    ''' <param name="receiptNo">The receipt number to void.</param>
    ''' <param name="voidReason">The user-provided reason for the void.</param>
    'Private Async Function VoidSelectedReceipt(ByVal receiptNo As String, ByVal voidReason As String) As Task
    '    Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo}/void"

    '    Dim requestBody As New JObject From {
    '        {"void_user", main_pos_system.lblCasheri.Text},
    '        {"void_reason", voidReason}
    '    }

    '    Dim jsonPayload As String = requestBody.ToString()

    '    Try
    '        Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
    '        Dim response As HttpResponseMessage = Await httpClient.PutAsync(apiUrl, content)

    '        Dim responseString As String = Await response.Content.ReadAsStringAsync()

    '        If response.IsSuccessStatusCode Then
    '            MessageBox.Show($"Receipt {receiptNo} successfully VOIDED by user {main_pos_system.lblCasheri.Text}. Data will now refresh.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ' Refresh the grid to show the updated status
    '            Await LoadReceiptsData()
    '        Else
    '            Dim errorJson As JObject = JObject.Parse(responseString)
    '            Dim errorMessage As String = errorJson("message").ToString()

    '            If response.StatusCode = Net.HttpStatusCode.Forbidden Then
    '                ' Handles the specific current-day restriction failure (HTTP 403)
    '                MessageBox.Show($"VOID FAILED: {errorMessage}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Else
    '                MessageBox.Show($"API Void Failed ({response.StatusCode}): {errorMessage}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        End If

    '    Catch ex As HttpRequestException
    '        MessageBox.Show("Connection Error: Could not reach the API server during void operation. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("An unexpected error occurred during void processing: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function
    Private Async Function VoidSelectedReceipt(ByVal receiptNo As String, ByVal voidReason As String) As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo}/void"

        Dim requestBody As New JObject From {
            {"void_user", main_pos_system.lblCasheri.Text},
            {"void_reason", voidReason}
        }

        Dim jsonPayload As String = requestBody.ToString()

        Try
            Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PutAsync(apiUrl, content)
            Dim responseString As String = Await response.Content.ReadAsStringAsync()

            If response.IsSuccessStatusCode Then
                ' --- PRINTING LOGIC START ---
                ' 1. Fetch full transaction details (Details and Payments) needed for the receipt
                Dim transactionData As JObject = Await FetchTransactionData(receiptNo)

                If transactionData IsNot Nothing Then
                    ' 2. Generate content with the VOID flag set to True
                    Dim receiptContent As String = ReceiptPrinter.GenerateReceiptContentFromJObject(transactionData, isVoid:=True)

                    ' 3. Execute the print
                    ReceiptPrinter.ExecutePrint(receiptContent, receiptNo)
                End If
                ' --- PRINTING LOGIC END ---

                MessageBox.Show($"Receipt {receiptNo} successfully VOIDED and printed.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the grid to show the updated status
                Await LoadReceiptsData()
            Else
                Dim errorJson As JObject = JObject.Parse(responseString)
                Dim errorMessage As String = errorJson("message").ToString()

                If response.StatusCode = Net.HttpStatusCode.Forbidden Then
                    MessageBox.Show($"VOID FAILED: {errorMessage}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show($"API Void Failed ({response.StatusCode}): {errorMessage}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server during void operation. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during void processing: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ''' <summary>
    ''' Helper function to fetch the full transaction data (Header, Details, Payments) from the API.
    ''' </summary>
    Private Async Function FetchTransactionData(ByVal receiptNo As String) As Task(Of JObject)
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo.Trim()}"
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)
            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Return JObject.Parse(jsonString)
            End If
        Catch ex As Exception
            Console.WriteLine("Error fetching transaction for print: " & ex.Message)
        End Try
        Return Nothing
    End Function
    ' ---------------------------------------------------------------------
    ' --- DateTimePicker Handler (Reload data on date change) ---
    ' ---------------------------------------------------------------------
    Private Async Sub dtpVoidDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpVoidDate.ValueChanged
        ' Reload the data to display invoices matching the newly selected date
        Await LoadReceiptsData()
    End Sub

End Class