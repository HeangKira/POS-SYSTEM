Imports Npgsql
Imports System.Data
Imports System.Net.Http ' ⭐ REQUIRED: For API calls
Imports Newtonsoft.Json.Linq ' ⭐ REQUIRED: For JSON parsing

Public Class frm_dl_list

    ' --- PROPERTIES TO RECEIVE DATA FROM frm_pos_sell ---
    Public Property PaymentMethod As String = "Cash"
    Public Property CurrencyCode As String = "USD"
    Public Property ExchangeRate As Decimal = 1D
    Public Property IsBaseCurrency As Boolean = True

    ' ⭐ Public Property to hold a reference to the calling form ⭐
    'Public Property ParentFormSell As frm_pos_sell
    Public Property ParentFormSell As main_pos_system ' Match your actual class name

    ' --- API Configuration (Must match your Node.js server) ---
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    'Private Const API_BASE_URL As String = "http://localhost:5005"
    Private ReadOnly httpClient As New HttpClient()

    ' REMOVED: Direct database CONNECTION_STRING

    ' --- Data Structure for ComboBox Items ---
    Public Class DeliveryItem
        Public Property DeliveryId As String
        Public Property DeliveryName As String

        ' Overriding ToString is crucial for the ComboBox to display the Name
        Public Overrides Function ToString() As String
            Return DeliveryName
        End Function
    End Class

    ' ----------------------------------------------------------------------
    ' --- LOAD EVENT (REVISED TO USE API) ---
    ' ----------------------------------------------------------------------
    Private Async Sub frm_dl_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. Clear existing items
            cmbdelivery.Items.Clear()

            ' 2. **ADD THE "BLACK" PLACEHOLDER ITEM FIRST**
            Dim blackItem As New DeliveryItem With {.DeliveryId = "", .DeliveryName = "--- Select Delivery ---"}
            cmbdelivery.Items.Add(blackItem)

            ' 3. Connect to the API and load actual records
            Await LoadDeliveriesFromApi()

            ' 4. Select the first item ("Black" placeholder) by default
            If cmbdelivery.Items.Count > 0 Then
                cmbdelivery.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading delivery names: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Fetches delivery records from the API via the /api/deliveries endpoint.
    ''' </summary>
    Private Async Function LoadDeliveriesFromApi() As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/deliveries"

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim deliveryDataList As JArray = JArray.Parse(jsonString)

                For Each itemData As JObject In deliveryDataList
                    ' The API fields are delivery_id (integer) and delivery_name (string)
                    Dim dbItem As New DeliveryItem With {
                        .DeliveryId = itemData("delivery_id").ToString(),
                        .DeliveryName = itemData("delivery_name").ToString()
                    }
                    ' Add the custom object to the ComboBox
                    cmbdelivery.Items.Add(dbItem)
                Next
            Else
                Dim errorDetails = Await response.Content.ReadAsStringAsync()
                MessageBox.Show($"API Error: {response.StatusCode}. Failed to fetch deliveries. Details: {errorDetails}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As HttpRequestException
            MessageBox.Show("Connection Error: Could not reach the API server to fetch deliveries. Ensure the server is running at " & API_BASE_URL & ". 🔴", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error processing API response: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' ----------------------------------------------------------------------
    ' --- SELECTED INDEX CHANGED EVENT ---
    ' ----------------------------------------------------------------------
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Check if an item is actually selected
        If cmbdelivery.SelectedItem IsNot Nothing Then
            ' Cast the selected item back to our custom DeliveryItem object
            Dim selectedItem As DeliveryItem = TryCast(cmbdelivery.SelectedItem, DeliveryItem)

            If selectedItem IsNot Nothing Then
                Dim selectedID As Integer = selectedItem.DeliveryId
                Dim selectedName As String = selectedItem.DeliveryName

                ' You can now use the selectedID for filtering, updating, or other operations:
                If selectedID = 0 Then
                    ' The "Black" placeholder was selected
                    ' Example: MessageBox.Show("Please select a valid delivery name.")
                Else
                    ' A real delivery name was selected
                    ' Example: MessageBox.Show($"Selected Delivery ID: {selectedID} (Name: {selectedName})")
                End If
            End If
        End If
    End Sub

    Private Sub txtReciveAmount_TextChanged(sender As Object, e As EventArgs) Handles txtReciveAmount.TextChanged

    End Sub

    ' ⭐ Handle Confirmation and Data Transfer to Parent Form ⭐
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click ' ⭐ ENSURE your button is named 'btnConfirm'
        If cmbdelivery.SelectedItem IsNot Nothing AndAlso ParentFormSell IsNot Nothing Then
            Dim selectedItem As DeliveryItem = TryCast(cmbdelivery.SelectedItem, DeliveryItem)

            ' CHANGE: Check if ID is not empty. Do NOT use "> 0"
            If selectedItem IsNot Nothing AndAlso Not String.IsNullOrEmpty(selectedItem.DeliveryId) Then

                ' Pass the string "DL02" to main form
                ParentFormSell.SetDeliveryInfo(selectedItem.DeliveryId, selectedItem.DeliveryName)

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Please select a valid delivery name.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf ParentFormSell Is Nothing Then
            MessageBox.Show("Internal Error: Parent form reference is missing. Cannot proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Try
            Dim localAmt As Decimal = 0D
            Dim usdAmtToRecord As Decimal = 0D
            Dim displayMethod As String = ""

            ' 1. Validate and parse the local amount entered by the user
            If Not Decimal.TryParse(txtReciveAmount.Text.Replace(",", "").Trim(), localAmt) OrElse localAmt <= 0 Then
                MessageBox.Show("Invalid or zero amount! Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReciveAmount.Focus()
                Exit Sub
            End If

            ' 2. Calculate the USD equivalent for the hidden column (USD = Local / Rate)
            If IsBaseCurrency OrElse ExchangeRate = 0D Then
                usdAmtToRecord = localAmt
            Else
                usdAmtToRecord = localAmt / ExchangeRate
            End If

            ' 3. Get the main form's DataGridView
            Dim paymentGrid As DataGridView = main_pos_system.dg_Payment

            ' 4. Add a new, empty row
            Dim newRowIndex As Integer = paymentGrid.Rows.Add()
            Dim newRow As DataGridViewRow = paymentGrid.Rows(newRowIndex)

            ' 5. Set values: 
            ' Set the combined display string (e.g., "Cash (KHR)", "Cash (USD)")
            displayMethod = Me.PaymentMethod & " (" & Me.CurrencyCode & ")"
            newRow.Cells("PAY_METHOD").Value = displayMethod

            ' The CURRENCY cell is hidden (see frm_pos_sell.SetupDataColumns) but still exists. We can set it 
            ' or leave it to its default if the logic doesn't strictly rely on it. We'll set it for robustness.
            If paymentGrid.Columns.Contains("CURRENCY") Then
                newRow.Cells("CURRENCY").Value = Me.CurrencyCode
            End If

            newRow.Cells("BANK").Value = Me.PaymentMethod ' Using PaymentMethod property for the bank/type

            ' STORE LOCAL AMOUNT in REC_AMT (Visible column)
            If IsBaseCurrency Then
                newRow.Cells("REC_AMT").Value = localAmt.ToString("0.00")
            Else
                ' Store KHR/THB amount without decimals for display
                newRow.Cells("REC_AMT").Value = localAmt.ToString("N0")
            End If

            ' STORE USD EQUIVALENT in USD_REC_AMT (Hidden column used for all internal calculations)
            newRow.Cells("USD_REC_AMT").Value = usdAmtToRecord.ToString("0.00")

            ' 6. Indicate success and close the form
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred while adding the payment: " & ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class