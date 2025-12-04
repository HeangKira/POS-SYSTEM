' frm_void_reason.vb

Public Class frm_void_reason
    ' Public property to hold the reason entered by the user
    Public Property VoidReason As String = ""

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ' Assuming you have a TextBox named txtReason and a Button named btnOK
        If String.IsNullOrWhiteSpace(txtReason.Text) Then
            MessageBox.Show("Please enter a reason for the void.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        VoidReason = txtReason.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Assuming you have a Button named btnCancel
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Optional: Ensure the OK button can be triggered by pressing Enter
    Private Sub txtReason_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK_Click(sender, e)
            e.SuppressKeyPress = True
        End If
    End Sub
End Class