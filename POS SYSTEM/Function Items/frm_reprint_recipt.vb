Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports System.Threading.Tasks

' NOTE: This code assumes you have a DataGridView named dgtInvoiceLists, 
' a DateTimePicker named dtpReprintDate, a Panel named Panel_TitleBar, 
' and Buttons named btn_Minimize, btn_Maximize, btn_Exit, and btnClose 
' on your Windows Form (frm_reprint_recipt).
' It also assumes you have a shared module named ReceiptPrinter 
' with the methods GenerateReceiptContentFromJObject and ExecutePrint.

Public Class frm_reprint_recipt

    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    Private ReadOnly httpClient As New HttpClient()
    Private Const V_ProjectName As String = "POS System"

    ' Used to retrieve the current CashierName for the reprint log request
    Private posSellInstance As main_pos_system

    ' ---------------------------------------------------------------------
    ' --- Windows DLL Imports (For Form Dragging) ---
    ' ---------------------------------------------------------------------
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
    Private Async Sub frm_reprint_recipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGridViewLayout()

        ' Find the main POS form instance to get the Cashier Name for logging
        For Each form As Form In Application.OpenForms
            If TypeOf form Is main_pos_system Then
                posSellInstance = CType(form, main_pos_system)
                Exit For
            End If
        Next

        If posSellInstance Is Nothing Then
            MessageBox.Show("Warning: Cannot find the main POS form (frm_pos_sell). Cashier name for logging may default to 'SYSTEM'.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Set the date picker to today's date upon load
        If dtpReprintDate IsNot Nothing Then
            dtpReprintDate.Value = DateTime.Today
        End If

        ' Load initial data (today's receipts)
        Await LoadReceiptsData()
    End Sub

    ''' <summary>
    ''' Sets up the layout for the dgtInvoiceLists DataGridView.
    ''' </summary>
    Private Sub InitializeDataGridViewLayout()
        With dgtInvoiceLists
            .AutoGenerateColumns = False
            .DataSource = Nothing
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()

            .Columns.Add("StoreCode", "Store Code")
            .Columns.Add("StoreName", "Store Name")
            .Columns.Add("ReceiptNumber", "Receipt Number")
            .Columns.Add("ReceiptDate", "Receipt Date")
            .Columns.Add("StatusInvoice", "Status Invoice")
            .Columns.Add("CashierName", "Cashier Name")

            .Columns("ReceiptDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"

            If Not .Columns.Contains("ReprintButton") Then
                Dim btnCol As New DataGridViewButtonColumn()
                With btnCol
                    .HeaderText = "Action"
                    .Name = "ReprintButton"
                    .Text = "Reprint"
                    .UseColumnTextForButtonValue = True
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End With
                .Columns.Add(btnCol)
            End If

            .Columns("StatusInvoice").DefaultCellStyle.Font = New Font(dgtInvoiceLists.Font, FontStyle.Bold)
        End With
    End Sub

    ''' <summary>
    ''' Fetches the detailed receipt report and displays data filtered by the selected date.
    ''' </summary>
    Private Async Function LoadReceiptsData() As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/receipts-report"

        Dim selectedDate As DateTime = DateTime.Today

        ' ⭐️ Retrieve the date selected by the user ⭐️
        If dtpReprintDate IsNot Nothing Then
            selectedDate = dtpReprintDate.Value.Date
        End If

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObject As JObject = JObject.Parse(jsonString)
                Dim reportData As JArray = CType(jsonObject("report_data"), JArray)

                dgtInvoiceLists.Rows.Clear()

                If reportData IsNot Nothing AndAlso reportData.Count > 0 Then

                    For Each item As JObject In reportData.Children(Of JObject)()
                        Dim receiptDate As DateTime = item("Receipt Date").ToObject(Of DateTime).Date

                        ' ⭐️ Apply the date filter ⭐️
                        If receiptDate.Date = selectedDate.Date Then

                            Dim receiptStatus As String = item("Status Invoice").ToString()

                            Dim rowIndex As Integer = dgtInvoiceLists.Rows.Add(
                                item("Store Code").ToString(),
                                item("Store Name").ToString(),
                                item("Receipt Number").ToString(),
                                item("Receipt Date").ToObject(Of DateTime),
                                receiptStatus,
                                item("Cashier Name").ToString()
                            )

                            ' Apply styling based on status
                            With dgtInvoiceLists.Rows(rowIndex)
                                If receiptStatus = "Voided" Then
                                    .DefaultCellStyle.BackColor = Color.LightCoral
                                    .Cells("ReprintButton").ReadOnly = True
                                    .Cells("ReprintButton").Style.BackColor = Color.DarkGray
                                    .Cells("ReprintButton").Style.ForeColor = Color.Black
                                Else
                                    .Cells("ReprintButton").ReadOnly = False
                                    .Cells("ReprintButton").Style.BackColor = Color.Navy
                                    .Cells("ReprintButton").Style.ForeColor = Color.White
                                End If
                            End With
                        End If
                    Next

                    If dgtInvoiceLists.Rows.Count = 0 Then
                        Console.WriteLine($"No receipts found for {selectedDate.ToShortDateString()}.")
                    End If
                Else
                    Console.WriteLine("No receipt data found in the API response.")
                End If
            Else
                Dim errorDetails = Await response.Content.ReadAsStringAsync()
                Dim errorMessage As String = $"API Error ({response.StatusCode}): Failed to fetch receipts report."
                Try
                    Dim errorJson As JObject = JObject.Parse(errorDetails)
                    If errorJson IsNot Nothing AndAlso errorJson.ContainsKey("message") Then
                        errorMessage = $"API Error ({response.StatusCode}): {errorJson("message").ToString()}"
                    End If
                Catch exJson As Exception
                    errorMessage = $"{errorMessage}. Raw details: {errorDetails.Substring(0, Math.Min(errorDetails.Length, 150))}..."
                End Try
                MessageBox.Show(errorMessage, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server. Ensure the server is running at " & API_BASE_URL & ". 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error processing API response or binding data: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    ''' <summary>
    ''' Function to Fetch Full Transaction Data (Header, Details, Payments)
    ''' </summary>
    Private Async Function FetchTransactionData(ByVal receiptNo As String) As Task(Of JObject)
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo.Trim()}"

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim transactionData As JObject = JObject.Parse(jsonString)
                Return transactionData
            Else
                Dim errorDetails = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"API Error ({response.StatusCode}): Failed to fetch transaction data for reprint. Details: {errorDetails}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server during transaction fetch. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during transaction data fetching: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Calls the API endpoint to log a reprint attempt.
    ''' </summary>
    Private Async Function LogReprintRequest(ByVal receiptNo As String) As Task(Of Boolean)
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo}/reprint"

        ' Get Cashier Name from the currently running POS form instance
        Dim cashierName As String = If(posSellInstance IsNot Nothing, posSellInstance.CashierName, "SYSTEM")

        Dim requestBody As New JObject From {
            {"reprint_user", cashierName},
            {"reprint_timestamp", DateTime.Now.ToString("o")}
        }

        Dim jsonPayload As String = requestBody.ToString()

        Try
            Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, content)

            If response.IsSuccessStatusCode Then
                Return True
            Else
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Dim errorMessage As String = $"API Reprint Log Failed ({response.StatusCode}): {response.ReasonPhrase}"
                Try
                    Dim errorJson As JObject = JObject.Parse(responseString)
                    If errorJson IsNot Nothing AndAlso errorJson.ContainsKey("message") Then
                        errorMessage = $"API Reprint Log Failed ({response.StatusCode}): {errorJson("message").ToString()}"
                    End If
                Catch exJson As Exception
                    ' Ignore parsing error
                End Try

                MessageBox.Show(errorMessage, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server during reprint log. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during reprint logging: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' ---------------------------------------------------------------------
    ' --- Reprint Execution Logic ---
    ' ---------------------------------------------------------------------
    Private Async Sub dgtInvoiceLists_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtInvoiceLists.CellContentClick
        ' Check if a valid row and the ReprintButton column were clicked
        If e.RowIndex >= 0 AndAlso dgtInvoiceLists.Columns(e.ColumnIndex).Name = "ReprintButton" Then
            Dim row As DataGridViewRow = dgtInvoiceLists.Rows(e.RowIndex)

            ' Check if the reprint button is disabled (e.g., for Voided transactions)
            Dim statusCell As DataGridViewCell = row.Cells("StatusInvoice")
            If statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Voided" Then
                MessageBox.Show("Cannot reprint a Voided transaction.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim receiptNo As String = row.Cells("ReceiptNumber").Value?.ToString()

            If String.IsNullOrEmpty(receiptNo) Then
                MessageBox.Show("Invalid Receipt Number.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If MessageBox.Show($"Confirm reprint for Receipt No: {receiptNo}?", V_ProjectName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Disable UI/Button during process for safety
                dgtInvoiceLists.Enabled = False
                Await HandleReprintTransaction(receiptNo)
                dgtInvoiceLists.Enabled = True
            End If
        End If
    End Sub


    ''' <summary>
    ''' Handles the full workflow for reprinting a specific receipt: Fetch -> Log -> Print.
    ''' </summary>
    Private Async Function HandleReprintTransaction(ByVal receiptNo As String) As Task
        ' 1. Fetch the full transaction data (Header, Details, Payments)
        Dim transactionData As JObject = Await FetchTransactionData(receiptNo)

        If transactionData Is Nothing Then
            Exit Function
        End If

        ' 2. Log the reprint request in the system (Node.js API should return 200 OK)
        If Not Await LogReprintRequest(receiptNo) Then
            MessageBox.Show("Reprint audit logging failed. Printing will still proceed.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' 3. Execute the print logic using the shared ReceiptPrinter module
        Try
            ' NOTE: ReceiptPrinter and its methods must be defined in your project
            Dim receiptContent As String = ReceiptPrinter.GenerateReceiptContentFromJObject(transactionData)
            ReceiptPrinter.ExecutePrint(receiptContent, receiptNo)

            MessageBox.Show($"Receipt {receiptNo} successfully reprinted. ✅", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As InvalidOperationException
            MessageBox.Show($"Printing Failed (Config Error): {ex.Message}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Printing Failed (System Error): {ex.Message}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' ---------------------------------------------------------------------
    ' --- DateTimePicker Handler (Reload data on date change) ---
    ' ---------------------------------------------------------------------
    Private Async Sub dtpReprintDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpReprintDate.ValueChanged
        ' This is the handler that automatically reloads data when the user selects a new date
        Await LoadReceiptsData()
    End Sub
End Class