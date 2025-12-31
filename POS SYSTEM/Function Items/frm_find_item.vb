Imports System.Runtime.InteropServices
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Windows.Forms
Imports System.Net

Public Class frm_find_item

    ' --- Global Constants and Variables ---
    Private Const API_BASE_URL As String = "http://172.29.29.56:5005"
    'Private Const API_BASE_URL As String = "http://localhost:5005"
    Private ReadOnly httpClient As New HttpClient()
    Private Const V_ProjectName As String = "POS System"
    Public F_Item As String = "" ' Public property to return selected value

    ' Variables for debouncing the search to prevent excessive API calls
    Private lastSearchTime As DateTime = DateTime.MinValue
    Private Const DEBOUNCE_MS As Integer = 500

    ' --- Form Load and Initialization ---
    Private Async Sub frm_find_item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDataGrid()
        InitializeControls()
        ' Load all items initially without strict filtering
        Await LoadItemsAsync(searchTriggeredByUser:=False)
    End Sub

    Private Sub InitializeControls()
        ' Set up cmb_FindBy with the search options
        cmb_FindBy.Items.Clear()
        cmb_FindBy.Items.Add("ItemCode")
        cmb_FindBy.Items.Add("ItemName")
        cmb_FindBy.Items.Add("Barcode")
        cmb_FindBy.SelectedIndex = 1 ' Default to ItemName

        txt_Filter.Focus()
    End Sub

    Private Sub InitializeDataGrid()
        Data_GridView.Columns.Clear()

        ' --- ⭐ NEW: SET FONT SIZE 14 AND ROW HEIGHT ⭐ ---
        Dim font14Reg As New System.Drawing.Font("Microsoft Sans Serif", 14.0F, System.Drawing.FontStyle.Regular)
        Dim font14Bold As New System.Drawing.Font("Microsoft Sans Serif", 14.0F, System.Drawing.FontStyle.Bold)

        With Data_GridView
            .DefaultCellStyle.Font = font14Reg
            .ColumnHeadersDefaultCellStyle.Font = font14Bold

            ' Set Row Height to 45 to fit Font 14 comfortably
            .RowTemplate.Height = 45
            .ColumnHeadersHeight = 50
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            ' Vertically center the text
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
        End With
        ' --------------------------------------------------

        ' 1. No (Line Number) - Width increased for Font 14
        Data_GridView.Columns.Add(New DataGridViewTextBoxColumn With {
          .Name = "gc_no", .HeaderText = "No", .Width = 60, .ReadOnly = True,
          .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
    })

        ' 2. ItemCode
        Data_GridView.Columns.Add(New DataGridViewTextBoxColumn With {
          .Name = "gc_item_code", .HeaderText = "Item Code", .Width = 150, .ReadOnly = True
    })

        ' 3. Barcode
        Data_GridView.Columns.Add(New DataGridViewTextBoxColumn With {
          .Name = "gc_barcode", .HeaderText = "Barcode", .Width = 180, .ReadOnly = True
    })

        ' 4. ItemName
        Data_GridView.Columns.Add(New DataGridViewTextBoxColumn With {
          .Name = "gc_item_name", .HeaderText = "Item Description", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, .ReadOnly = True
    })

        ' 5. UOM
        Data_GridView.Columns.Add(New DataGridViewTextBoxColumn With {
          .Name = "gc_uom", .HeaderText = "UoM", .Width = 80, .ReadOnly = True,
          .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
    })
    End Sub

    ' --- ASYNC DATA FETCHING AND LOADING ---

    Private Async Function LoadItemsAsync(Optional ByVal searchTriggeredByUser As Boolean = False) As Task
        Dim filterText As String = txt_Filter.Text.Trim()
        ' The API now handles the filtering for ItemName, ItemCode, and Barcode simultaneously
        Dim url As String = $"{API_BASE_URL}/api/item-lookup?search={Uri.EscapeDataString(filterText)}"

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)
            If Not response.IsSuccessStatusCode Then Exit Function

            Dim jsonString As String = Await response.Content.ReadAsStringAsync()
            Dim jsonArray As JArray = JArray.Parse(jsonString)

            ' Ensure UI thread safety
            Me.Invoke(Sub()
                          Data_GridView.Rows.Clear()
                          Dim rowNum As Integer = 1

                          For Each itemToken As JToken In jsonArray
                              ' Standardize field names from API
                              Dim itemCode As String = itemToken("itemcode")?.ToString()
                              Dim barcode As String = itemToken("barcode")?.ToString()
                              Dim itemName As String = itemToken("itemname")?.ToString()
                              Dim uom As String = itemToken("uom")?.ToString()

                              ' We trust the Server-Side filter, so we just add the rows
                              ' This prevents the "isMatch" logic from accidentally hiding valid results
                              Data_GridView.Rows.Add(rowNum, itemCode, barcode, itemName, uom)
                              rowNum += 1
                          Next

                          If Data_GridView.RowCount > 0 Then
                              Data_GridView.Rows(0).Selected = True
                          End If
                      End Sub)

        Catch ex As Exception
            If searchTriggeredByUser Then
                MessageBox.Show($"Search failed: {ex.Message}", V_ProjectName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Function

    ' --- EVENT HANDLERS ---
    ' --- ⭐ SINGLE CLICK SELECTION ⭐ ---
    ' This will select the item and close the form with just one click
    Private Sub Data_GridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data_GridView.CellClick
        ' Check e.RowIndex >= 0 to ensure they didn't click the header row
        If e.RowIndex >= 0 Then
            ProcessSelection(Data_GridView.Rows(e.RowIndex))
        End If
    End Sub

    ' Keep the Enter key logic so keyboard users can still select items
    Private Sub Data_GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles Data_GridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Data_GridView.CurrentRow IsNot Nothing Then
                ProcessSelection(Data_GridView.CurrentRow)
            End If
        End If
    End Sub
    Private Async Sub cmb_FindBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_FindBy.SelectedIndexChanged
        Await LoadItemsAsync(searchTriggeredByUser:=True)
    End Sub

    Private Async Sub txt_Filter_TextChanged(sender As Object, e As EventArgs) Handles txt_Filter.TextChanged
        ' Debounce check
        If DateTime.Now.Subtract(lastSearchTime).TotalMilliseconds < DEBOUNCE_MS Then Exit Sub
        lastSearchTime = DateTime.Now

        Await LoadItemsAsync(searchTriggeredByUser:=True)
    End Sub

    Private Async Sub btn_find_Click(sender As Object, e As EventArgs) Handles btn_find.Click
        Await LoadItemsAsync(searchTriggeredByUser:=True)
    End Sub

    Private Async Sub txt_Filter_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Filter.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Await LoadItemsAsync(searchTriggeredByUser:=True)

            If Data_GridView.RowCount > 0 Then
                If Data_GridView.RowCount = 1 Then
                    ' Auto-select if only one result
                    ProcessSelection(Data_GridView.Rows(0))
                Else
                    Data_GridView.Focus()
                End If
            End If
        End If
    End Sub

    ' --- Selection Logic ---

    Private Sub ProcessSelection(ByVal row As DataGridViewRow)
        If row Is Nothing Then Exit Sub

        Dim itemCodeVal As String = row.Cells("gc_item_code").Value?.ToString().Trim()
        Dim barcodeVal As String = row.Cells("gc_barcode").Value?.ToString().Trim()

        ' Priority 1: Use Barcode. Priority 2: Use ItemCode.
        If Not String.IsNullOrEmpty(barcodeVal) Then
            F_Item = barcodeVal
        Else
            F_Item = itemCodeVal
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Data_GridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Data_GridView.CellDoubleClick
        If e.RowIndex >= 0 Then ProcessSelection(Data_GridView.Rows(e.RowIndex))
    End Sub

    Private Sub btn_Select_Click(sender As Object, e As EventArgs) Handles btn_Select.Click
        If Data_GridView.CurrentRow IsNot Nothing Then ProcessSelection(Data_GridView.CurrentRow)
    End Sub

    ' --- UI Management ---

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click, btn_Cancel.Click
        F_Item = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_TitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class