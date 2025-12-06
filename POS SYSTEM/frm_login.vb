Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class frm_login
    ' Define the base URL for your API
    Private Const API_BASE_URL As String = "http://localhost:5005"

    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form load actions here if needed
    End Sub

    Private Async Sub btn_LogIn_Click(sender As Object, e As EventArgs) Handles btn_LogIn.Click
        ' Trim values
        Dim userId As String = txt_UserID.Text.Trim()
        Dim pin As String = txt_Password.Text.Trim()

        ' Simple client-side validation
        If String.IsNullOrEmpty(userId) OrElse userId = "Enter User ID" Then
            MessageBox.Show("Please enter your User ID.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(pin) OrElse pin = "Enter PIN" Then
            MessageBox.Show("Please enter your PIN.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        btn_LogIn.Enabled = False ' Disable button to prevent multiple clicks
        Me.Cursor = Cursors.WaitCursor

        Try
            ' 1. Construct the JSON payload for the API
            Dim jsonPayload As String = $"{{" &
                                        $"""user_id"": ""{userId}"", " &
                                        $"""pin"": ""{pin}""" &
                                        $"}}"

            ' 2. Send POST request to the login endpoint
            Using httpClient As New Net.Http.HttpClient()
                ' Set content type to application/json
                Dim content As New Net.Http.StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")

                Dim response As Net.Http.HttpResponseMessage = Await httpClient.PostAsync($"{API_BASE_URL}/api/auth/pin-login", content)

                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Parse the full response
                    Dim fullResponse As JObject = JObject.Parse(responseBody)
                    Dim userData As JToken = fullResponse("user")

                    If userData Is Nothing OrElse userData.Type = JTokenType.Null Then
                        MessageBox.Show("Login successful but missing user data in response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    '' Extract data
                    Dim v_storeId As String = If(userData("store_code") IsNot Nothing, userData("store_code").ToString(), "DEFAULT_S")
                    Dim v_storeName As String = If(userData("store_name") IsNot Nothing, userData("store_name").ToString(), "Default Store Name")
                    Dim v_cashierId As String = If(userData("user_id") IsNot Nothing, userData("user_id").ToString(), "DEFAULT_C")
                    Dim v_cashierName As String = If(userData("username") IsNot Nothing, userData("username").ToString(), "Default Cashier")
                    Dim v_storeDisplayName As String = $"{v_storeId}-{v_storeName}"

                    '' --- FORM INSTANTIATION AND INITIALIZATION (START) ---

                    '' 1. Create the POS Shell form (frm_pos_sell) ONCE
                    Dim posForm As New frm_pos_sell()

                    '' 2. Pass the formatted data to this POS form instance
                    posForm.StoreId = v_storeId
                    posForm.StoreName = v_storeDisplayName
                    posForm.CashierId = v_cashierId
                    posForm.CashierName = v_cashierName
                    posForm.LoggedInUserId = v_cashierId

                    '' 3. Initialize the secondary display on this POS form instance
                    '' NOTE: The InitializeSecondaryDisplay() method must be Public or Friend in frm_pos_sell.
                    'posForm.InitializeSecondaryDisplay()

                    '' 4. Hide the login screen
                    'Me.Hide()

                    '' 5. Show the initialized POS form
                    'posForm.Show()

                    Me.Close()

                Else
                    ' The API returns 401 (Unauthorized) for invalid credentials
                    MessageBox.Show($"Login Failed. Invalid credentials or API error. (Status: {response.StatusCode})", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Re-enable the button and reset the cursor only if the form is still visible/not disposed.
            If Not Me.IsDisposed Then
                btn_LogIn.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End Try
    End Sub

End Class