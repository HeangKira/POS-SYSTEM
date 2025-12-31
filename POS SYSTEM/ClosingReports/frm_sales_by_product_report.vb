Imports System.Drawing
Imports System.Drawing.Printing ' Required for printing functionality
Imports System.IO
Imports System.Linq ' Required for Linq methods like Select, Distinct, OrderBy, Where
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading.Tasks ' Required for using async/await
Imports Newtonsoft.Json
Imports OfficeOpenXml ' Required for EPPlus library
Imports OfficeOpenXml.Style ' Required for styling/formatting
Public Class frm_sales_by_product_report

    ' ----------------------------------------------------------------------
    ' --- DllImport and Form Drag/Close/Minimize/Maximize Handlers ---
    ' ----------------------------------------------------------------------
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
    Private Sub btn_Minimize_Click(sender As Object, e As EventArgs) Handles btn_Minimize.Click
        WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    ' ----------------------------------------------------------------------
    ' --- Global Variables ---
    ' ----------------------------------------------------------------------
    Private Const API_BASE_URL As String = "http://172.29.29.56:5006" ' Define the API Base URL here

    Private WithEvents PrintDocument1 As New System.Drawing.Printing.PrintDocument
    Private PrintPreviewDialog1 As New System.Windows.Forms.PrintPreviewDialog
    Private v_ReceiptContentToPrint As String = ""
    Private Shared lines() As String ' Used by the PrintPage handler
    Private Shared linesPrinted As Integer = 0

    ' ⭐ MODULE-LEVEL VARIABLE TO HOLD ALL FETCHED DATA ⭐
    Private v_AllSalesData As List(Of SalesData) = New List(Of SalesData)()

    ' ----------------------------------------------------------------------
    ' --- Data Structures for JSON Deserialization ---
    ' ----------------------------------------------------------------------
    Public Class SalesData
        <JsonProperty("Date")>
        Public Property SalesDate As String
        Public Property ReceiptNo As String
        Public Property StoreID As String
        <JsonProperty("Item Code")>
        Public Property ItemCode As String
        Public Property Description As String
        Public Property Qty As Decimal
        <JsonProperty("Net Amount")>
        Public Property Net_Amount As Decimal
        ' ⭐ MODIFIED: Keep CashierID for filtering ⭐
        Public Property CashierID As String
        ' ⭐ NEW: Property for Cashier Name (from API) ⭐
        Public Property CashierName As String
    End Class

    ' ⭐ NEW CLASS: Data structure to bind to DataGridView (excludes CashierID) ⭐
    Public Class DisplaySalesData
        <JsonProperty("Date")>
        Public Property SalesDate As String
        Public Property ReceiptNo As String
        Public Property StoreID As String
        <JsonProperty("Item Code")>
        Public Property ItemCode As String
        Public Property Description As String
        Public Property Qty As Decimal
        <JsonProperty("Net Amount")>
        Public Property Net_Amount As Decimal
        ' Note: CashierID is intentionally excluded here
        Public Property CashierName As String ' Display Cashier Name instead
    End Class

    Public Class ReportResponse
        Public Property reportName As String
        Public Property filter As Object
        Public Property data As List(Of SalesData)
    End Class

    Public Class StoreFilterData
        Public Property ID As String
        Public Property Name As String
    End Class

    ' ⭐ NEW CLASS: Used for ComboBox items (stores ID for filtering and Name for display) ⭐
    Public Class CashierFilterItem
        Public Property DisplayName As String
        Public Property CashierID As String

        Public Overrides Function ToString() As String
            Return DisplayName ' This is what the user sees in the combobox
        End Function
    End Class


    ' ----------------------------------------------------------------------
    ' --- Form Load and Filter Population Logic ---
    ' ----------------------------------------------------------------------

    Private Async Sub frm_sales_by_product_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize cmbfilter with default value (using the new object structure)
        If cmbfilter.Items.Count = 0 Then
            cmbfilter.Items.Add(New CashierFilterItem With {.DisplayName = "All Cashiers", .CashierID = ""})
            cmbfilter.SelectedIndex = 0
        End If

        Await PopulateStoreFilter()
    End Sub

    Private Async Function PopulateStoreFilter() As Task
        Dim apiUrl As String = $"{API_BASE_URL}/api/data/stores"

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim storesList As List(Of StoreFilterData) = JsonConvert.DeserializeObject(Of List(Of StoreFilterData))(jsonString)

                ' Clear and populate cmbStore
                cmbStore.Items.Clear()

                ' StoreFilterData only needs ID/Name, we can still just add the Name string to cmbStore
                If storesList IsNot Nothing AndAlso storesList.Count > 0 Then
                    For Each store In storesList
                        ' The API returns Name as "All Stores" or the actual Store ID
                        cmbStore.Items.Add(store.Name)
                    Next
                Else
                    cmbStore.Items.Add("All Stores")
                End If

                If cmbStore.Items.Count > 0 Then
                    cmbStore.SelectedIndex = 0
                End If

            Catch ex As Exception
                MessageBox.Show($"Error loading store list: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    ' ⭐ MODIFIED: Populates ComboBox with ID-Name format and uses the new CashierFilterItem class ⭐
    Private Sub PopulateCashierFilter(ByVal data As List(Of SalesData))
        ' Clear previous items
        cmbfilter.Items.Clear()

        ' Add an "All Cashiers" option
        cmbfilter.Items.Add(New CashierFilterItem With {.DisplayName = "All Cashiers", .CashierID = ""})

        If data IsNot Nothing AndAlso data.Count > 0 Then
            ' Get a distinct list of Cashier IDs and Names, sort them, and add to the combobox
            Dim uniqueCashiers = data.
                Where(Function(d) Not String.IsNullOrEmpty(d.CashierID)).
                GroupBy(Function(d) d.CashierID).
                Select(Function(g) New With {
                    .CashierID = g.Key,
                    .CashierName = g.First().CashierName ' Take the name from the first match
                }).
                OrderBy(Function(c) c.CashierID).ToList()

            For Each cashier In uniqueCashiers
                Dim displayName As String = $"{cashier.CashierID}-{cashier.CashierName}"
                cmbfilter.Items.Add(New CashierFilterItem With {.DisplayName = displayName, .CashierID = cashier.CashierID})
            Next
        End If

        ' Select the default "All Cashiers" option
        cmbfilter.SelectedIndex = 0
    End Sub

    ' ⭐ MODIFIED: Uses the CashierFilterItem object to get the actual CashierID for filtering ⭐
    Private Sub ApplyCashierFilter()
        If v_AllSalesData Is Nothing OrElse v_AllSalesData.Count = 0 Then
            dgSalesByProductReport.DataSource = Nothing
            Return
        End If

        If cmbfilter.SelectedItem Is Nothing Then Return ' Safety check

        ' ⭐ Get the underlying CashierFilterItem object ⭐
        Dim selectedItem As CashierFilterItem = TryCast(cmbfilter.SelectedItem, CashierFilterItem)
        If selectedItem Is Nothing Then Return ' Should not happen if populated correctly

        Dim selectedCashierID As String = selectedItem.CashierID
        Dim filteredData As List(Of SalesData)

        If String.IsNullOrEmpty(selectedCashierID) Then
            ' "All Cashiers" selected
            filteredData = v_AllSalesData
        Else
            ' Filter by the actual CashierID
            filteredData = v_AllSalesData.Where(Function(d) d.CashierID = selectedCashierID).ToList()
        End If

        ' ⭐ Map the filtered data to the DisplaySalesData class to hide CashierID column ⭐
        Dim displayData = filteredData.Select(Function(d) New DisplaySalesData With {
            .SalesDate = d.SalesDate,
            .ReceiptNo = d.ReceiptNo,
            .StoreID = d.StoreID,
            .ItemCode = d.ItemCode,
            .Description = d.Description,
            .Qty = d.Qty,
            .Net_Amount = d.Net_Amount,
            .CashierName = If(Not String.IsNullOrEmpty(d.CashierName), d.CashierName, d.CashierID)
        }).ToList()

        dgSalesByProductReport.DataSource = displayData

        If dgSalesByProductReport.DataSource IsNot Nothing Then
            dgSalesByProductReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        If displayData.Count = 0 Then
            ' Optional: Show warning only if a specific cashier was selected and no data found
            If selectedCashierID <> "" Then
                MessageBox.Show($"No sales found for Cashier: {selectedItem.DisplayName} in the selected date range.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    ' ----------------------------------------------------------------------
    ' --- API Call Logic (Unchanged for filter mechanism) ---
    ' ----------------------------------------------------------------------
    Private Async Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Using client As New HttpClient()
            Try
                Dim fromDateStr As String = dtp_FDate.Value.ToString("yyyy-MM-dd")
                Dim toDateStr As String = dtp_TDate.Value.ToString("yyyy-MM-dd")

                Dim selectedStoreFilter As String = If(cmbStore.SelectedItem IsNot Nothing, cmbStore.SelectedItem.ToString(), "All Stores")
                Dim storeIdParam As String = If(selectedStoreFilter = "All Stores", "", selectedStoreFilter)

                Dim apiUrl As String = $"{API_BASE_URL}/api/reports/sales/byproduct?fromDate={fromDateStr}&toDate={toDateStr}&storeId={storeIdParam}"

                Me.Cursor = Cursors.WaitCursor

                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                ' Ensure SalesData now includes CashierName
                Dim reportResult As ReportResponse = JsonConvert.DeserializeObject(Of ReportResponse)(jsonString)

                If reportResult IsNot Nothing AndAlso reportResult.data IsNot Nothing Then
                    v_AllSalesData = reportResult.data

                    PopulateCashierFilter(v_AllSalesData)

                    ' Apply the initial filter ("All Cashiers")
                    ApplyCashierFilter()

                Else
                    MessageBox.Show("No data found for the selected date range/store filter.", "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgSalesByProductReport.DataSource = Nothing
                    v_AllSalesData.Clear()

                    ' Reset cashier filter control using the new object structure
                    cmbfilter.Items.Clear()
                    cmbfilter.Items.Add(New CashierFilterItem With {.DisplayName = "All Cashiers", .CashierID = ""})
                    cmbfilter.SelectedIndex = 0
                End If

            Catch ex As HttpRequestException
                MessageBox.Show($"Error connecting to the API: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show($"An error occurred while loading the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Using
    End Sub

    ' ----------------------------------------------------------------------
    ' --- Filter Change Events ---
    ' ----------------------------------------------------------------------

    Private Sub cmbfilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfilter.SelectedIndexChanged
        ' Apply the cashier filter whenever the selected item changes
        If cmbfilter.SelectedItem IsNot Nothing AndAlso v_AllSalesData.Count > 0 Then
            ApplyCashierFilter()
        End If
    End Sub

    Private Sub cmbStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStore.SelectedIndexChanged
        ' Automatically re-run the report query when the store selection changes
        If cmbStore.SelectedItem IsNot Nothing Then
            btnView_Click(sender, e)
        End If
    End Sub

    ' ----------------------------------------------------------------------
    ' --- Printing and other handlers (Unchanged) ---
    ' ----------------------------------------------------------------------

    Private Function GenerateReceiptContent(ByVal receiptLines As List(Of SalesData)) As String
        If receiptLines Is Nothing OrElse receiptLines.Count = 0 Then
            Return "--- No data found for this receipt ---" & vbCrLf & "----------------------------------------" & vbCrLf
        End If

        Dim sb As New StringBuilder()

        ' ⭐ CONSTANTS FOR 40 CHARACTER WIDTH ⭐
        Const TOTAL_WIDTH As Integer = 40
        Const DASH_LINE As String = "----------------------------------------" ' 40 dashes
        Dim CenterLine = Function(text As String) As String
                             Dim safeText As String = If(text, "")
                             Dim padding As Integer = (TOTAL_WIDTH - safeText.Length) / 2
                             If padding < 0 Then padding = 0
                             Return New String(" "c, padding) & safeText
                         End Function

        Dim firstLine = receiptLines.First()
        Dim totalNet As Decimal = 0

        ' --- Header Section ---
        sb.AppendLine()
        sb.AppendLine(CenterLine("POS SALES REPORT"))
        sb.AppendLine(CenterLine("Store ID: " & firstLine.StoreID))
        ' Display Cashier ID or Name if available (using CashierID for backward compatibility)
        If Not String.IsNullOrEmpty(firstLine.CashierID) Then
            ' Use ID-Name format for clarity in the receipt, or just Name if available
            Dim cashierInfo As String = If(Not String.IsNullOrEmpty(firstLine.CashierName), $"{firstLine.CashierID}-{firstLine.CashierName}", firstLine.CashierID)
            sb.AppendLine(CenterLine("Cashier: " & cashierInfo))
        End If
        sb.AppendLine(DASH_LINE)

        ' --- Receipt Number Line ---
        Const RECEIPT_LABEL As String = "RECEIPT NO: "
        Const MAX_RECEIPT_NO_LENGTH As Integer = 28

        Dim displayReceiptNo As String = firstLine.ReceiptNo
        If displayReceiptNo.Length > MAX_RECEIPT_NO_LENGTH Then
            displayReceiptNo = displayReceiptNo.Substring(0, MAX_RECEIPT_NO_LENGTH)
        End If

        Dim receiptLine As String = RECEIPT_LABEL & displayReceiptNo
        If receiptLine.Length > TOTAL_WIDTH Then
            receiptLine = receiptLine.Substring(0, TOTAL_WIDTH)
        End If
        sb.AppendLine(receiptLine)

        sb.AppendLine(String.Format("DATE: {0}", firstLine.SalesDate.Substring(0, 10))) ' Extract only the date part
        sb.AppendLine(String.Format("{0,-25}{1,5}{2,10}", "ITEM DESCRIPTION", "QTY", "AMOUNT"))
        sb.AppendLine(DASH_LINE)

        ' --- Detail Line Items ---
        For Each line In receiptLines
            Dim itemName As String = line.Description

            If itemName.Length > 25 Then itemName = itemName.Substring(0, 25)

            Dim qtyStr As String = line.Qty.ToString("0.00")
            Dim netStr As String = line.Net_Amount.ToString("0.00")

            sb.AppendLine(String.Format("{0,-25}{1,5}{2,10}", itemName, qtyStr, netStr))

            totalNet += line.Net_Amount
        Next

        sb.AppendLine(DASH_LINE)

        ' --- Summary Section ---
        sb.AppendLine(String.Format("{0,-25} {1,15:0.00}", "NET TOTAL (USD):", totalNet))
        sb.AppendLine() ' Only one blank line for separation now

        Return sb.ToString()
    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim leftMargin As Single = 1
        Dim yPosition As Single = e.MarginBounds.Top

        Dim font As New Font("Courier New", 8, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)
        Dim lineHeight As Single = font.GetHeight(e.Graphics) * 1.1F

        Do While linesPrinted < lines.Length
            Dim line As String = lines(linesPrinted)

            e.Graphics.DrawString(line, font, brush, leftMargin, yPosition)

            yPosition += lineHeight
            linesPrinted += 1

            If yPosition >= e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
        Loop

        e.HasMorePages = False
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        If dgSalesByProductReport.DataSource Is Nothing Then
            MessageBox.Show("Please view the report data first by clicking 'View'.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim displayDataList As List(Of DisplaySalesData) ' Get the displayed data
        Try
            displayDataList = CType(dgSalesByProductReport.DataSource, List(Of DisplaySalesData))
        Catch
            MessageBox.Show("Error reading displayed data source. Ensure the DataGridView contains a List(Of DisplaySalesData).", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If displayDataList Is Nothing OrElse displayDataList.Count = 0 Then
            MessageBox.Show("No sales data found to preview.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Convert DisplaySalesData back to SalesData (or equivalent for printing)
        Dim printableDataList As List(Of SalesData) = displayDataList.Select(Function(d) New SalesData With {
            .SalesDate = d.SalesDate,
            .ReceiptNo = d.ReceiptNo,
            .StoreID = d.StoreID,
            .ItemCode = d.ItemCode,
            .Description = d.Description,
            .Qty = d.Qty,
            .Net_Amount = d.Net_Amount,
            .CashierName = d.CashierName,
            .CashierID = "" ' ID is not needed for receipt content, only filtering
        }).ToList()

        Dim finalPreviewText As New StringBuilder()

        ' Group by ReceiptNo to process each transaction as a single receipt
        Dim receiptsGrouped = printableDataList.GroupBy(Function(d) d.ReceiptNo).ToList()

        For Each receiptGroup In receiptsGrouped
            Dim receiptLines As List(Of SalesData) = receiptGroup.ToList()
            Dim receiptText As String = GenerateReceiptContent(receiptLines)
            finalPreviewText.AppendLine(receiptText)

            If receiptGroup IsNot receiptsGrouped.Last() Then
                finalPreviewText.AppendLine("----------------------------------------")
            End If
        Next

        v_ReceiptContentToPrint = finalPreviewText.ToString().TrimEnd(vbCr, vbLf)

        ' ... (Rest of Preview button logic)
        Dim previewForm As New Form()
        previewForm.Text = $"80mm Batch Receipt Preview ({receiptsGrouped.Count} Receipts)"
        previewForm.Size = New Size(320, 700)
        previewForm.StartPosition = FormStartPosition.CenterScreen

        Dim rtbReceipt As New RichTextBox()
        rtbReceipt.Dock = DockStyle.Fill
        rtbReceipt.Font = New Font("Courier New", 8, FontStyle.Regular)
        rtbReceipt.Text = v_ReceiptContentToPrint
        rtbReceipt.ReadOnly = True
        rtbReceipt.WordWrap = False

        previewForm.Controls.Add(rtbReceipt)

        Dim btnPrint As New Button()
        btnPrint.Text = "Print to Printer"
        btnPrint.Dock = DockStyle.Bottom
        btnPrint.Height = 40
        previewForm.Controls.Add(btnPrint)

        AddHandler btnPrint.Click, Sub() HandlePrintButtonClick(receiptsGrouped.Count)

        previewForm.ShowDialog()

    End Sub

    Private Sub HandlePrintButtonClick(ByVal receiptCount As Integer)
        lines = v_ReceiptContentToPrint.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
        linesPrinted = 0

        PrintDocument1.DocumentName = $"Sales Report Batch ({receiptCount} Receipts)"

        Dim printDlg As New PrintDialog()
        printDlg.Document = PrintDocument1

        If printDlg.ShowDialog() = DialogResult.OK Then
            Try
                PrintDocument1.Print()
            Catch ex As Exception
                MessageBox.Show("An error occurred during printing: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub btn_Maximize_Click_1(sender As Object, e As EventArgs) Handles btn_Maximize.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
End Class