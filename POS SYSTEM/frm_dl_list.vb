Imports Npgsql
Imports System.Data

Public Class frm_dl_list

    ' --- PROPERTIES TO RECEIVE DATA FROM frm_pos_sell ---
    Public Property PaymentMethod As String = "Cash" ' e.g., "Cash", "Card", etc.
    Public Property CurrencyCode As String = "USD"
    Public Property ExchangeRate As Decimal = 1D
    Public Property IsBaseCurrency As Boolean = True

    ' ⭐ NEW: Public Property to hold a reference to the calling form ⭐
    Public Property ParentFormSell As frm_pos_sell

    ' CONNECTION STRING (Ensure Npgsql reference is added to your project)
    Private Const CONNECTION_STRING As String = "Host=127.0.0.1;Port=5432;Username=postgres;Password=kira23;Database=POS-Database;"

    ' --- LOAD EVENT ---
    Private Sub frm_dl_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' 1. Clear existing items
            cmbdelivery.Items.Clear()

            ' 2. **ADD THE "BLACK" PLACEHOLDER ITEM FIRST**
            ' We assign an ID of 0 (or -1) to indicate it's not a real database record.
            Dim blackItem As New DeliveryItem With {.DeliveryId = 0, .DeliveryName = ""}
            cmbdelivery.Items.Add(blackItem)

            ' 3. Connect to the database and load actual records
            Using conn As New NpgsqlConnection(CONNECTION_STRING)
                conn.Open()

                ' SQL must select both ID and Name
                Dim sql As String = "SELECT delivery_id, delivery_name FROM public.tbl_delivery ORDER BY delivery_name;"

                Using cmd As New NpgsqlCommand(sql, conn)
                    Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Create a new DeliveryItem object for each database record
                            Dim dbItem As New DeliveryItem With {
                                .DeliveryId = CInt(reader("delivery_id")),
                                .DeliveryName = reader("delivery_name").ToString()
                            }
                            ' Add the custom object to the ComboBox
                            cmbdelivery.Items.Add(dbItem)
                        End While
                    End Using
                End Using
            End Using

            ' 4. Select the first item ("Black") by default
            If cmbdelivery.Items.Count > 0 Then
                cmbdelivery.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading delivery names: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- SELECTED INDEX CHANGED EVENT ---
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

    ' ⭐ NEW: Handle Confirmation and Data Transfer to Parent Form ⭐
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click ' ⭐ ENSURE your button is named 'btnConfirm'
        If cmbdelivery.SelectedItem IsNot Nothing AndAlso ParentFormSell IsNot Nothing Then
            Dim selectedItem As DeliveryItem = TryCast(cmbdelivery.SelectedItem, DeliveryItem)

            If selectedItem IsNot Nothing AndAlso selectedItem.DeliveryId > 0 Then

                ' 1. Load the delivery name into lblDelivery and set the ID in frm_pos_sell
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
            Dim paymentGrid As DataGridView = frm_pos_sell.dg_Payment

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