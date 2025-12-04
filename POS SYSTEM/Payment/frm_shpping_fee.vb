Public Class frm_shpping_fee

    ' ⭐ 1. PUBLIC PROPERTY TO HOLD THE CONFIRMED AMOUNT ⭐
    Public Property ShippingAmount As Decimal = 0D

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.DialogResult = DialogResult.Cancel ' Signal cancel/no change
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel ' Signal cancel/no change
        Me.Close()
    End Sub

    ' ⭐ 2. NEW CONFIRM BUTTON HANDLER ⭐
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim fee As Decimal = 0D

        ' Ensure your input control name matches (e.g., txtShippingFeeInput)
        If Decimal.TryParse(txtAmount.Text, fee) Then
            ShippingAmount = fee
            Me.DialogResult = DialogResult.OK ' Signal successful confirmation
            Me.Close()
        Else
            MessageBox.Show("Please enter a valid shipping fee amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class