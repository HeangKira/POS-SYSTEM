' ======================================================================
' --- New Form: frm_OverridePin (Manager/Cashier Override) ---
' ======================================================================
Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks

Public Class frm_OverridePin

    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    Private ReadOnly httpClient As New HttpClient()

    ' Public property to hold the result of the validation
    Public Property IsPinValid As Boolean = False

    ' The User ID for the user attempting the override
    Public Property OverrideUserId As String = ""

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Async Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim userId As String = txtUserId.Text.Trim()
        Dim pin As String = txtPin.Text.Trim()

        If String.IsNullOrEmpty(userId) OrElse String.IsNullOrEmpty(pin) Then
            MessageBox.Show("Please enter both User ID and PIN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        btnConfirm.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Try
            ' Reuse the existing pin-login API endpoint for validation
            Dim jsonPayload As String =
                $"{{""user_id"": ""{userId}"", ""pin"": ""{pin}""}}"

            Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            Dim response = Await httpClient.PostAsync($"{API_BASE_URL}/api/auth/pin-login", content)

            If response.IsSuccessStatusCode Then
                ' Login successful means the PIN is valid
                IsPinValid = True
                OverrideUserId = userId
                Me.DialogResult = DialogResult.OK
            Else
                ' Login failed
                IsPinValid = False
                MessageBox.Show("Invalid User ID or PIN.", "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Connection Error during PIN validation: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnConfirm.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub frm_OverridePin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.None
    End Sub
End Class