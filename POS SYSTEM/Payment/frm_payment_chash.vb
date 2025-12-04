Imports System.Windows.Forms

Public Class frm_payment_chash

    ' --- PROPERTIES TO RECEIVE DATA FROM frm_pos_sell ---
    Public Property PaymentMethod As String = "Cash" ' e.g., "Cash", "Card", etc.
    Public Property CurrencyCode As String = "USD"
    Public Property ExchangeRate As Decimal = 1D
    Public Property IsBaseCurrency As Boolean = True

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    ' *** FIX 2: Modified btnConfrim_Click to combine Method and Currency into PAY_METHOD cell ***
    Private Sub btnConfrim_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click
        Try
            Dim localAmt As Decimal = 0D
            Dim usdAmtToRecord As Decimal = 0D
            Dim displayMethod As String = ""

            ' 1. Validate and parse the local amount entered by the user
            If Not Decimal.TryParse(txtAmount.Text.Replace(",", "").Trim(), localAmt) OrElse localAmt <= 0 Then
                MessageBox.Show("Invalid or zero amount! Please enter a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtAmount.Focus()
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

    Private Sub frm_payment_chash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialization logic
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class