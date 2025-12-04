Imports System.Data
Imports System.Drawing
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json ' ⭐ RETAINED ⭐
Imports Newtonsoft.Json.Linq
Imports Npgsql
Imports NpgsqlTypes

' =================================================================
' ⭐ FORM CLASS: frm_delivery_list (The Main Form) ⭐
' =================================================================
Public Class frm_delivery_list
    Public Property AmountDueValue As Decimal = 0D
    Public Property SelectedDeliveryId As Integer = 0
    Public Property SelectedDeliveryName As String = String.Empty
    Public Property SelectedDeliveryDate As Date = Date.Today

    Private Const API_BASE_URL As String = "http://localhost:5005"

    ' --- DLL Imports and Mouse Event Handlers (Omitted for brevity) ---
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btn_Minimize_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_Maximize_Click(sender As Object, e As EventArgs)
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btn_Exit_Click_1(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    ' -----------------------------------------------------------------

    ' =================================================================
    ' ⭐ MAIN LOAD FUNCTION (ASYNC) ⭐
    ' =================================================================
    Private Async Sub frm_delivery_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display the received amount
        If Me.Controls.ContainsKey("txtAmount") AndAlso TypeOf Me.Controls("txtAmount") Is TextBox Then
            CType(Me.Controls("txtAmount"), TextBox).Text = AmountDueValue.ToString("0.00")
        End If

        If Me.Controls.ContainsKey("cmbdelivery") AndAlso TypeOf Me.Controls("cmbdelivery") Is ComboBox Then
            Dim cmb As ComboBox = CType(Me.Controls("cmbdelivery"), ComboBox)

            ' 1. Set Binding Properties
            ' This tells the ComboBox to display the DeliveryName property from the DeliveryItem object.
            cmb.DisplayMember = "DeliveryName"
            cmb.ValueMember = "DeliveryId"

            ' 2. AWAIT Data Loading
            Await LoadDeliveryNamesAsync(cmb)

            ' Initialize Selection ONLY if data was successfully loaded.
            If cmb.DataSource IsNot Nothing AndAlso cmb.Items.Count > 0 Then
                cmb.SelectedIndex = 0

                ' Set properties based on the selected item
                Dim firstItem As DeliveryItem = CType(cmb.SelectedItem, DeliveryItem)
                SelectedDeliveryName = firstItem.DeliveryName
                SelectedDeliveryId = firstItem.DeliveryId

                If Me.Controls.ContainsKey("txtDeliveryID") AndAlso TypeOf Me.Controls("txtDeliveryID") Is TextBox Then
                    CType(Me.Controls("txtDeliveryID"), TextBox).Text = SelectedDeliveryId.ToString()
                End If
            Else
                SelectedDeliveryName = String.Empty
                SelectedDeliveryId = 0
                If Me.Controls.ContainsKey("txtDeliveryID") AndAlso TypeOf Me.Controls("txtDeliveryID") Is TextBox Then
                    CType(Me.Controls("txtDeliveryID"), TextBox).Text = String.Empty
                End If
            End If
        End If

        ' Initialize dtpDeliveryDate
        If Me.Controls.ContainsKey("dtpDeliveryDate") AndAlso TypeOf Me.Controls("dtpDeliveryDate") Is DateTimePicker Then
            CType(Me.Controls("dtpDeliveryDate"), DateTimePicker).Value = Date.Today
            SelectedDeliveryDate = Date.Today
        End If
    End Sub

    ' =================================================================
    ' ⭐ ASYNC FUNCTION: API Data Fetching (FIXED USING NEWTONSOFT) ⭐
    ' =================================================================
    Private Async Function LoadDeliveryNamesAsync(ByVal cmb As ComboBox) As Task
        Const ApiEndpoint As String = "/api/deliveries"
        Dim ApiUrl As String = API_BASE_URL & ApiEndpoint

        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(5)

                Dim response As HttpResponseMessage = Await client.GetAsync(ApiUrl)
                response.EnsureSuccessStatusCode() ' Throws exception if status is 4xx or 5xx

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()

                ' ⭐ FIX: Use Newtonsoft.Json (JsonConvert) for deserialization ⭐
                Dim deliveries As List(Of DeliveryItem) = JsonConvert.DeserializeObject(Of List(Of DeliveryItem))(jsonString)

                ' Bind the list to the ComboBox's DataSource
                If deliveries IsNot Nothing AndAlso deliveries.Count > 0 Then
                    cmb.DataSource = deliveries
                Else
                    cmb.DataSource = Nothing
                    cmb.Items.Add("[No Delivery Data Received]")
                    cmb.SelectedIndex = 0
                End If

            End Using

        Catch ex As Exception
            ' Displays error if connection fails or server returns error status
            MessageBox.Show($"Error loading delivery data. Please ensure the API is running at {ApiUrl} and accessible. Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Add user-friendly failure message
            cmb.DataSource = Nothing
            cmb.Items.Clear()
            cmb.Items.Add("[Failed to Load Data]")
            cmb.SelectedIndex = 0
        End Try
    End Function

    ' =================================================================
    ' ⭐ EVENT HANDLER: Selection Change Logic ⭐
    ' =================================================================
    Private Sub cmbdelivery_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdelivery.SelectedIndexChanged
        ' Only proceed if a valid DeliveryItem is selected
        If cmbdelivery.SelectedItem IsNot Nothing AndAlso TypeOf cmbdelivery.SelectedItem Is DeliveryItem Then
            Dim selectedItem As DeliveryItem = CType(cmbdelivery.SelectedItem, DeliveryItem)

            SelectedDeliveryName = selectedItem.DeliveryName
            SelectedDeliveryId = selectedItem.DeliveryId

            ' Update txtDeliveryID 
            If Me.Controls.ContainsKey("txtDeliveryID") AndAlso TypeOf Me.Controls("txtDeliveryID") Is TextBox Then
                CType(Me.Controls("txtDeliveryID"), TextBox).Text = SelectedDeliveryId.ToString()
            End If
        Else
            SelectedDeliveryName = String.Empty
            SelectedDeliveryId = 0

            If Me.Controls.ContainsKey("txtDeliveryID") AndAlso TypeOf Me.Controls("txtDeliveryID") Is TextBox Then
                CType(Me.Controls("txtDeliveryID"), TextBox).Text = String.Empty
            End If
        End If
    End Sub

    ' [Other Event Handlers]
    Private Sub dtpDeliveryDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDeliveryDate.ValueChanged
        SelectedDeliveryDate = dtpDeliveryDate.Value.Date
    End Sub

    Private Sub btnConfrim_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click
        ' Final check before closing
        If cmbdelivery.SelectedItem IsNot Nothing AndAlso TypeOf cmbdelivery.SelectedItem Is DeliveryItem Then
            Dim finalItem As DeliveryItem = CType(cmbdelivery.SelectedItem, DeliveryItem)
            SelectedDeliveryName = finalItem.DeliveryName
            SelectedDeliveryId = finalItem.DeliveryId
        End If

        If Me.Controls.ContainsKey("dtpDeliveryDate") AndAlso TypeOf Me.Controls("dtpDeliveryDate") Is DateTimePicker Then
            SelectedDeliveryDate = CType(Me.Controls("dtpDeliveryDate"), DateTimePicker).Value.Date
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtDeliveryID_TextChanged(sender As Object, e As EventArgs)
        ' Empty event handler
    End Sub
End Class

' =================================================================
' ⭐ HELPER CLASS: DATA MODEL (FIXED MAPPING) ⭐
' =================================================================
Public Class DeliveryItem
    ' ⭐ FIX: Use Newtonsoft.Json attribute to map 'delivery_id' from API to VB property DeliveryId
    <JsonProperty("delivery_id")>
    Public Property DeliveryId As Integer

    ' ⭐ FIX: Use Newtonsoft.Json attribute to map 'delivery_name' from API to VB property DeliveryName
    <JsonProperty("delivery_name")>
    Public Property DeliveryName As String

    Public Overrides Function ToString() As String
        ' This is only used if DisplayMember is not set, but is good practice to return the display value.
        Return Me.DeliveryName
    End Function
End Class