Imports System.Runtime.InteropServices
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Drawing

Public Class frm_delivery_shpping

    ' --- Constants and API Client ---
    Private Const API_BASE_URL As String = "http://localhost:5005"
    Private ReadOnly httpClient As New HttpClient()
    Private Const V_ProjectName As String = "POS System - Payment Log"
    Private Const V_DeliveryUser As String = "ADMIN" ' User performing the update

    ' --- Windows DLL Imports (Unchanged) ---
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

            ' Define all columns for data access
            .Columns.Add("StoreCode", "Store Code")
            .Columns.Add("StoreName", "Store Name")
            .Columns.Add("ReceiptNumber", "Receipt Number")
            .Columns.Add("ReceiptDate", "Receipt Date")
            .Columns.Add("StatusInvoice", "Status Invoice")
            .Columns.Add("CashierName", "Cashier Name")
            .Columns.Add("DeliveryName", "Delivery Name")
            .Columns.Add("DeliveryID", "Delivery ID")

            ' Column Visibility and Formatting
            .Columns("CashierName").Visible = False
            .Columns("StatusInvoice").Visible = False

            .Columns("StoreName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns("StoreCode").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("ReceiptNumber").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns("ReceiptDate").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            .Columns("ReceiptDate").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"

            ' Add the Receipt Amount button (Log Method)
            If Not .Columns.Contains("LogPaymentButton") Then
                Dim btnCol As New DataGridViewButtonColumn()
                With btnCol
                    .HeaderText = "Receipt Amount"
                    .Name = "LogPaymentButton"
                    .Text = "Receipt Amount"
                    .UseColumnTextForButtonValue = True
                    .Width = 120
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                End With
                .Columns.Add(btnCol)
            End If
            If .Columns.Contains("AssignDLButton") Then .Columns.Remove("AssignDLButton")
        End With
    End Sub

    Private Async Function LoadReceiptsData() As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales"

        Dim selectedDate As DateTime = DateTime.Today
        If Me.Controls.ContainsKey("dtpDLDate") AndAlso TypeOf Me.Controls("dtpDLDate") Is DateTimePicker Then
            selectedDate = CType(Me.Controls("dtpDLDate"), DateTimePicker).Value.Date
        End If

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObject As JObject = JObject.Parse(jsonString)
                Dim salesListToken As JToken = jsonObject("sales_list")
                Dim reportData As JArray = If(salesListToken IsNot Nothing, CType(salesListToken, JArray), New JArray())

                dgtDeliveryList.Rows.Clear()

                If reportData.Count > 0 Then

                    For Each item As JObject In reportData.Children(Of JObject)()

                        Dim receiptDateTime As DateTime = If(item("receipt_date") IsNot Nothing, item("receipt_date").ToObject(Of DateTime), DateTime.MinValue)

                        ' 1. Date filter
                        If receiptDateTime.Date = selectedDate.Date Then

                            ' Status check
                            Dim receiptStatus As Integer = If(item("receipt_status") IsNot Nothing, item("receipt_status").ToObject(Of Integer), 0)
                            Dim statusString As String = If(receiptStatus = 1, "Active", "Voided")

                            ' 2. FILTER: Skip if the status is Voided (Only show Active transactions)
                            If statusString = "Voided" Then
                                Continue For ' Skip to the next receipt in the loop
                            End If

                            ' Robust, safe retrieval of all required fields
                            Dim storeID As String = If(item("store_id") IsNot Nothing, item("store_id").ToString(), "")
                            Dim storeName As String = If(item("store_name") IsNot Nothing, item("store_name").ToString(), "")
                            Dim receiptNo As String = If(item("receipt_no") IsNot Nothing, item("receipt_no").ToString(), "")
                            Dim cashierName As String = If(item("cashier_name") IsNot Nothing, item("cashier_name").ToString(), "")

                            ' Delivery fields (check for both Missing and Null token types)
                            Dim deliveryID As String = If(item("delivery_id") IsNot Nothing AndAlso item("delivery_id").Type <> JTokenType.Null, item("delivery_id").ToString(), "")
                            Dim deliveryName As String = If(item("delivery_name") IsNot Nothing AndAlso item("delivery_name").Type <> JTokenType.Null, item("delivery_name").ToString(), "")

                            ' Add row using safely extracted variables
                            Dim rowIndex As Integer = dgtDeliveryList.Rows.Add(
                                storeID,
                                storeName,
                                receiptNo,
                                receiptDateTime,
                                statusString,
                                cashierName,
                                deliveryName,
                                deliveryID
                            )

                            ' Conditional formatting and button status (Simplified as only Active rows are included)
                            With dgtDeliveryList.Rows(rowIndex)
                                .Cells("LogPaymentButton").ReadOnly = False
                                .Cells("LogPaymentButton").Style.BackColor = Color.ForestGreen
                                .Cells("LogPaymentButton").Value = "Receipt Amount"
                            End With
                        End If
                    Next
                End If
            Else
                Dim errorDetails = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"API Error ({response.StatusCode}): Failed to fetch sales list. Details: {errorDetails}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error processing API response or binding data: " & ex.Message & vbCrLf & "Source: " & ex.Source, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ''' <summary>
    ''' Logs the original payment method (Cash/QR) to the pay_orginalmethod field in the database.
    ''' </summary>
    Private Async Function UpdatePaymentLog(ByVal receiptNo As String, ByVal originalPaymentMethod As String) As Task
        ' API ENDPOINT URL: PUT /api/pos/sales/{receipt_no}/update-delivery-payment
        Dim apiUrl As String = $"{API_BASE_URL}/api/pos/sales/{receiptNo}/update-delivery-payment"

        ' Request body contains the user and the original payment method to log
        Dim requestBody As New JObject From {
            {"pay_updateby", V_DeliveryUser},
            {"pay_orginalmethod", originalPaymentMethod} ' This is the value from frm_assigned_dl ("Cash" or "QR")
        }

        Dim jsonPayload As String = requestBody.ToString()

        Try
            Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PutAsync(apiUrl, content)

            Dim responseString As String = Await response.Content.ReadAsStringAsync()

            If response.IsSuccessStatusCode Then
                MessageBox.Show($"Receipt {receiptNo} payment log updated successfully. Original method logged as '{originalPaymentMethod}'.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadReceiptsData()
            Else
                Dim errorMessage As String = responseString
                Try
                    Dim errorJson As JObject = JObject.Parse(responseString)
                    errorMessage = errorJson("message")?.ToString() & If(errorJson("details") IsNot Nothing, $" (Details: {errorJson("details").ToString()})", "")
                Catch exJson As Exception
                    ' Fallback
                End Try

                MessageBox.Show($"API Update Failed ({response.StatusCode}): {errorMessage}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server during update operation. 🔴", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred during update processing: " & ex.Message & vbCrLf & "Source: " & ex.Source, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' ---------------------------------------------------------------------
    ' ## 📅 Date Picker and Button Click Handlers
    ' ---------------------------------------------------------------------
    Private Async Sub dtpDLDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDLDate.ValueChanged
        Await LoadReceiptsData()
    End Sub

    Private Async Sub dgtDeliveryList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDeliveryList.CellContentClick
        ' Check if the clicked cell is the LogPaymentButton (Receipt Amount button)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = dgtDeliveryList.Columns("LogPaymentButton").Index Then

            Dim clickedRow As DataGridViewRow = dgtDeliveryList.Rows(e.RowIndex)
            Dim receiptNo As String = clickedRow.Cells("ReceiptNumber").Value.ToString()
            Dim statusString As String = clickedRow.Cells("StatusInvoice").Value.ToString()

            ' Safety check (though Voided rows should not be displayed)
            If statusString = "Voided" Then
                MessageBox.Show($"Receipt {receiptNo} is Voided and cannot be processed.", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                ' Open the receipt details/payment form
                Dim frm As New frm_assigned_dl()

                ' Pass required data to the form (ReceiptNumber is essential)
                frm.ReceiptNumber = receiptNo

                ' Show the form as a dialog
                If frm.ShowDialog(Me) = DialogResult.OK Then

                    Dim selectedMethod As String = frm.OriginalPaymentMethod

                    ' Call the API function to log the payment method
                    Await UpdatePaymentLog(receiptNo, selectedMethod)

                End If

                frm.Dispose() ' Clean up the form object

            Catch ex As Exception
                MessageBox.Show("Error opening Receipt Amount form: " & ex.Message, V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class