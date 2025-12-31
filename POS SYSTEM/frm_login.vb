Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class frm_login
    ' Define the base URL for your API
    'Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    'Private Const API_BASE_URL As String = "http://localhost:5005"
    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form load actions here if needed
    End Sub

    'Private Async Sub btn_LogIn_Click(sender As Object, e As EventArgs) Handles btn_LogIn.Click
    '    ' Trim values
    '    Dim userId As String = txt_UserID.Text.Trim()
    '    Dim pin As String = txt_Password.Text.Trim()

    '    ' Simple client-side validation
    '    If String.IsNullOrEmpty(userId) OrElse userId = "Enter User ID" Then
    '        MessageBox.Show("Please enter your User ID.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    If String.IsNullOrEmpty(pin) OrElse pin = "Enter PIN" Then
    '        MessageBox.Show("Please enter your PIN.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    btn_LogIn.Enabled = False ' Disable button to prevent multiple clicks
    '    Me.Cursor = Cursors.WaitCursor

    '    Try
    '        ' 1. Construct the JSON payload for the API
    '        Dim jsonPayload As String = $"{{" &
    '                                    $"""user_id"": ""{userId}"", " &
    '                                    $"""pin"": ""{pin}""" &
    '                                    $"}}"

    '        ' 2. Send POST request to the login endpoint
    '        Using httpClient As New Net.Http.HttpClient()
    '            ' Set content type to application/json
    '            Dim content As New Net.Http.StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")

    '            Dim response As Net.Http.HttpResponseMessage = Await httpClient.PostAsync($"{API_BASE_URL}/api/auth/pin-login", content)

    '            Dim responseBody As String = Await response.Content.ReadAsStringAsync()

    '            If response.IsSuccessStatusCode Then
    '                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                ' Parse the full response
    '                Dim fullResponse As JObject = JObject.Parse(responseBody)
    '                Dim userData As JToken = fullResponse("user")

    '                If userData Is Nothing OrElse userData.Type = JTokenType.Null Then
    '                    MessageBox.Show("Login successful but missing user data in response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Return
    '                End If

    '                Me.Close()

    '            Else
    '                ' The API returns 401 (Unauthorized) for invalid credentials
    '                MessageBox.Show($"Login Failed. Invalid credentials or API error. (Status: {response.StatusCode})", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show($"An error occurred: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        ' Re-enable the button and reset the cursor only if the form is still visible/not disposed.
    '        If Not Me.IsDisposed Then
    '            btn_LogIn.Enabled = True
    '            Me.Cursor = Cursors.Default
    '        End If
    '    End Try
    'End Sub
    Private Async Sub btn_LogIn_Click(sender As Object, e As EventArgs) Handles btn_LogIn.Click
        ' Trim and validate inputs
        Dim userId As String = txt_UserID.Text.Trim()
        Dim pin As String = txt_Password.Text.Trim()

        If String.IsNullOrEmpty(userId) Or String.IsNullOrEmpty(pin) Then
            MessageBox.Show("Please enter User ID and PIN.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Optionally disable UI during network call
        ' Note: Assuming btn_LogIn and cursor handling logic exist elsewhere or were removed for brevity.

        Try
            ' 1. Construct the JSON payload for the API
            Dim jsonPayload As String =
                $"{{""user_id"": ""{userId}"", ""pin"": ""{pin}""}}"

            Using client As New HttpClient()
                Dim content As New StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")

                ' 2. Send POST request to the login endpoint
                Dim response = Await client.PostAsync($"{API_BASE_URL}/api/auth/pin-login", content)

                Dim body = Await response.Content.ReadAsStringAsync()

                ' Inside btn_LogIn_Click success logic:
                If response.IsSuccessStatusCode Then
                    Dim fullResponse = JObject.Parse(body)
                    Dim user = fullResponse("user")

                    ' 1. Set Master Admin status ⭐
                    UserSession.IsAdmin = If(user("is_admin") IsNot Nothing, CBool(user("is_admin")), False)

                    ' 2. Store Permissions Array ⭐
                    UserSession.Permissions.Clear()
                    Dim permsArray As JArray = user("permissions")
                    If permsArray IsNot Nothing Then
                        For Each p As JObject In permsArray
                            UserSession.Permissions.Add(New UserPermission With {
                .module_path = p("module_path").ToString(),
                .can_view = CBool(p("can_view"))
            })
                        Next
                    End If

                    ' 3. Continue to main POS form (Your existing logic)
                    'frm_pos_sell.LoggedInUserId = user("user_id").ToString()
                    'frm_pos_sell.LoggedInUserName = user("username").ToString()
                    'frm_pos_sell.SetUserData(user("user_id").ToString(), user("username").ToString(), user("store_code").ToString(), user("store_name").ToString())
                    main_pos_system.LoggedInUserId = user("user_id").ToString()
                    main_pos_system.LoggedInUserName = user("username").ToString()
                    main_pos_system.SetUserData(user("user_id").ToString(), user("username").ToString(), user("store_code").ToString(), user("store_name").ToString())

                    Me.Hide()
                    main_pos_system.Show()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Re-enable button and cursor handling here if they were disabled earlier
        End Try
    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Application.Exit()
    End Sub

    Private Sub lblForgotPassword_Click(sender As Object, e As EventArgs) Handles lblForgotPassword.Click
        Dim F As New frm_reset_password
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub

End Class