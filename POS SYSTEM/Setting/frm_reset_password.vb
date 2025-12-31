Imports System.Net.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Guna.UI2.WinForms

Public Class frm_reset_password

    ' 🔹 API Base URL
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"

    Public Sub New()
        InitializeComponent()
    End Sub

    ' 🔹 Universal string cleaner (TRIM + remove invisible chars)
    Private Function CleanInput(value As String) As String
        If String.IsNullOrEmpty(value) Then Return ""
        Return value.Replace(vbCr, "") _
                     .Replace(vbLf, "") _
                     .Replace(vbTab, "") _
                     .Trim()
    End Function

    ' ⭐ REVISION: GetLoggedInAdminId is REMOVED as this is a self-reset form.

    Private Async Sub btn_ResetPassword_Click(sender As Object, e As EventArgs) Handles btn_ResetPassword.Click

        ' 🔹 Get Target User ID (user whose password is being reset) and New PIN
        Dim targetUserId As String = CleanInput(txt_UserID.Text).Trim()
        Dim newPin As String = CleanInput(txtNewPin.Text)
        Dim confirmPin As String = CleanInput(txtConfrimPin.Text)

        ' ⭐ REVISION: updatedBy is now the user performing the action (targetUserId).
        Dim updatedByUserId As String = targetUserId

        Dim btn As Guna2Button = TryCast(sender, Guna2Button)

        ' 🔹 Validation
        If targetUserId = "" Then
            MessageBox.Show("Please enter your User ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Note: Other validation checks for newPin, confirmPin, and length remain valid for a self-reset.
        If newPin = "" OrElse confirmPin = "" Then
            MessageBox.Show("New PIN and Confirm PIN are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If newPin.Length < 4 Then
            MessageBox.Show("PIN must be at least 4 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If newPin <> confirmPin Then
            MessageBox.Show("PIN and Confirm PIN do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 🔹 Disable UI
        If btn IsNot Nothing Then btn.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        Try
            ' 🔹 JSON payload
            Dim payload As New JObject From {
                {"new_password", newPin},
                {"updatedby", updatedByUserId}
            }

            Using client As New HttpClient()
                Dim content As New StringContent(
                    payload.ToString(Formatting.None),
                    System.Text.Encoding.UTF8,
                    "application/json"
                )

                ' 🔹 Send PUT request to the reset-password endpoint
                ' The URL includes the user ID of the person whose password is being reset.
                Dim requestUrl As String = $"{API_BASE_URL}/api/users/reset-password/{targetUserId}"

                Dim response As HttpResponseMessage =
                    Await client.PutAsync(requestUrl, content)

                Dim body As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    MessageBox.Show(
                        $"Password (PIN) for user {targetUserId} reset successfully. You can now log in.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )
                    Me.Close()
                Else
                    Dim message As String = $"Reset Failed for User ID: {targetUserId}. Status: {response.StatusCode}."

                    If Not String.IsNullOrWhiteSpace(body) Then
                        ' Attempt to parse the server's error message
                        Try
                            Dim err As JObject = JObject.Parse(body)
                            If err.ContainsKey("message") Then
                                message = err("message").ToString()
                            End If
                        Catch exJson As Exception
                            ' If JSON parsing fails, use the raw body as the message
                            message = body
                        End Try
                    End If

                    MessageBox.Show(
                        message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    )
                End If
            End Using

        Catch ex As Exception
            ' Catch network or unexpected errors
            MessageBox.Show(
                "System Error: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        Finally
            ' 🔹 Restore UI
            If Not Me.IsDisposed Then
                If btn IsNot Nothing Then btn.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End Try

    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

End Class