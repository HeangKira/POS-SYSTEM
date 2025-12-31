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

Public Class frm_sale_by_item_group_
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
    ' --- Data Structures ---
    ' ----------------------------------------------------------------------

    ' Matches the response from /api/reports/saleitemgroup
    Public Class SalesData
        <JsonProperty("Date")>
        Public Property SalesDate As String
        <JsonProperty("Receipt No.")>
        Public Property ReceiptNo As String
        <JsonProperty("Store ID")>
        Public Property StoreID As String
        <JsonProperty("Item Code")>
        Public Property ItemCode As String
        <JsonProperty("Item Name")>
        Public Property ItemName As String
        <JsonProperty("Item Group Code")>
        Public Property ItemGroupCode As String
        <JsonProperty("Item Category Name")>
        Public Property ItemCategoryName As String
        <JsonProperty("Unit Price")>
        Public Property UnitPrice As Decimal
        <JsonProperty("Quantity Sold")>
        Public Property Qty As Decimal
        <JsonProperty("Gross Sale Amount")>
        Public Property GrossSaleAmount As Decimal
        <JsonProperty("Line Discount Amount")>
        Public Property LineDiscountAmount As Decimal
        <JsonProperty("Net Sale Amount")>
        Public Property Net_Amount As Decimal
        Public Property CashierID As String
        Public Property CashierName As String
    End Class

    ' Data structure to bind to DataGridView
    Public Class DisplaySalesData
        <JsonProperty("Date")>
        Public Property SalesDate As String
        Public Property ReceiptNo As String
        Public Property StoreID As String
        Public Property CashierName As String
        Public Property ItemCode As String
        Public Property ItemName As String
        Public Property ItemGroupCode As String
        Public Property ItemCategoryName As String
        Public Property UnitPrice As Decimal
        Public Property Qty As Decimal
        Public Property GrossSaleAmount As Decimal
        Public Property LineDiscountAmount As Decimal
        Public Property Net_Amount As Decimal
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

    ' Class for the Cashier Filter Combobox
    Public Class CashierFilterItem
        Public Property DisplayName As String ' e.g., "101-Kira"
        Public Property CashierID As String  ' e.g., "101"

        Public Overrides Function ToString() As String
            Return DisplayName ' This is what the user sees in the combobox
        End Function
    End Class

    ' ⭐ NEW CLASS FOR SUMMARY REPORT DATA ⭐
    Public Class SummarySalesLine
        Public Property ItemName As String
        Public Property TotalQty As Decimal
        Public Property TotalAmount As Decimal
    End Class


    ' ----------------------------------------------------------------------
    ' --- Form Load and Filter Population Logic ---
    ' ----------------------------------------------------------------------

    Private Async Sub frm_sale_by_item_group_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize cmbfilter with default value
        InitializeCashierFilter()
        Await PopulateStoreFilter()
    End Sub

    Private Sub InitializeCashierFilter()
        cmbCashier.Items.Clear()
        cmbCashier.Items.Add(New CashierFilterItem With {.DisplayName = "All Cashiers", .CashierID = ""})
        cmbCashier.SelectedIndex = 0
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

                If storesList IsNot Nothing AndAlso storesList.Count > 0 Then
                    For Each store In storesList
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

    Private Sub PopulateCashierFilter(ByVal data As List(Of SalesData))
        ' Clear previous items
        cmbCashier.Items.Clear()

        ' Add an "All Cashiers" option
        cmbCashier.Items.Add(New CashierFilterItem With {.DisplayName = "All Cashiers", .CashierID = ""})

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
                ' ⭐ FORMAT: ID-Name (e.g., 101-Kira) ⭐
                Dim displayName As String = $"{cashier.CashierID}-{cashier.CashierName}"
                cmbCashier.Items.Add(New CashierFilterItem With {.DisplayName = displayName, .CashierID = cashier.CashierID})
            Next
        End If

        ' Select the default "All Cashiers" option
        cmbCashier.SelectedIndex = 0
    End Sub

    Private Sub ApplyCashierFilter()
        If v_AllSalesData Is Nothing OrElse v_AllSalesData.Count = 0 Then
            dgSalesByProductReport.DataSource = Nothing
            Return
        End If

        If cmbCashier.SelectedItem Is Nothing Then Return

        ' Get the underlying CashierFilterItem object
        Dim selectedItem As CashierFilterItem = TryCast(cmbCashier.SelectedItem, CashierFilterItem)
        If selectedItem Is Nothing Then Return

        ' ⭐ Filter using the hidden CashierID ⭐
        Dim selectedCashierID As String = selectedItem.CashierID
        Dim filteredData As List(Of SalesData)

        If String.IsNullOrEmpty(selectedCashierID) Then
            ' "All Cashiers" selected
            filteredData = v_AllSalesData
        Else
            ' Filter by the actual CashierID
            filteredData = v_AllSalesData.Where(Function(d) d.CashierID = selectedCashierID).ToList()
        End If

        ' Map the filtered data to the DisplaySalesData class
        Dim displayData = filteredData.Select(Function(d) New DisplaySalesData With {
            .SalesDate = d.SalesDate,
            .ReceiptNo = d.ReceiptNo,
            .StoreID = d.StoreID,
            .ItemCode = d.ItemCode,
            .ItemName = d.ItemName,
            .ItemGroupCode = d.ItemGroupCode,
            .ItemCategoryName = d.ItemCategoryName,
            .UnitPrice = d.UnitPrice,
            .Qty = d.Qty,
            .GrossSaleAmount = d.GrossSaleAmount,
            .LineDiscountAmount = d.LineDiscountAmount,
            .Net_Amount = d.Net_Amount,
            .CashierName = If(Not String.IsNullOrEmpty(d.CashierName), d.CashierName, d.CashierID)
        }).ToList()

        dgSalesByProductReport.DataSource = displayData

        If dgSalesByProductReport.DataSource IsNot Nothing Then
            dgSalesByProductReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        If displayData.Count = 0 Then
            If selectedCashierID <> "" Then
                MessageBox.Show($"No sales found for Cashier: {selectedItem.DisplayName} in the selected date range.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub


    ' ----------------------------------------------------------------------
    ' --- API Call Logic ---
    ' ----------------------------------------------------------------------
    Private Async Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Using client As New HttpClient()
            Try
                Dim fromDateStr As String = dtp_FDate.Value.ToString("yyyy-MM-dd")
                Dim toDateStr As String = dtp_TDate.Value.ToString("yyyy-MM-dd")

                Dim selectedStoreFilter As String = If(cmbStore.SelectedItem IsNot Nothing, cmbStore.SelectedItem.ToString(), "All Stores")
                Dim storeIdParam As String = If(selectedStoreFilter = "All Stores", "", selectedStoreFilter)

                Dim apiUrl As String = $"{API_BASE_URL}/api/reports/saleitemgroup?fromDate={fromDateStr}&toDate={toDateStr}&storeId={storeIdParam}"

                Me.Cursor = Cursors.WaitCursor

                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim reportResult As ReportResponse = JsonConvert.DeserializeObject(Of ReportResponse)(jsonString)

                If reportResult IsNot Nothing AndAlso reportResult.data IsNot Nothing Then
                    v_AllSalesData = reportResult.data

                    ' Populate the cashier filter with ID-Name format
                    PopulateCashierFilter(v_AllSalesData)

                    ' Apply the initial filter ("All Cashiers")
                    ApplyCashierFilter()

                Else
                    MessageBox.Show("No data found for the selected date range/store filter.", "Report Empty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgSalesByProductReport.DataSource = Nothing
                    v_AllSalesData.Clear()

                    ' Reset cashier filter
                    InitializeCashierFilter()
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

    Private Sub cmbfilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCashier.SelectedIndexChanged
        ' Apply the cashier filter whenever the selected item changes
        If cmbCashier.SelectedItem IsNot Nothing AndAlso v_AllSalesData.Count > 0 Then
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
    ' --- Printing and other handlers ---
    ' ----------------------------------------------------------------------

    ' --- ORIGINAL RECEIPT PRINT LOGIC (Kept but not used by the modified btnPreview_Click) ---
    Private Function GenerateReceiptContent(ByVal receiptLines As List(Of SalesData)) As String
        If receiptLines Is Nothing OrElse receiptLines.Count = 0 Then
            Return "--- No data found for this receipt ---" & vbCrLf & "----------------------------------------" & vbCrLf
        End If

        Dim sb As New StringBuilder()

        ' Constants for 40 Character Width
        Const TOTAL_WIDTH As Integer = 40
        Const DASH_LINE As String = "----------------------------------------" ' 40 dashes
        Dim CenterLine = Function(text As String) As String
                             Dim safeText As String = If(text, "")
                             Dim padding As Integer = (TOTAL_WIDTH - safeText.Length) / 2
                             If padding < 0 Then padding = 0
                             Return New String(" "c, padding) & safeText
                         End Function

        Dim firstLine = receiptLines.First()

        ' --- Calculations for Footer ---
        Dim totalGrossAmount As Decimal = receiptLines.Sum(Function(l) l.GrossSaleAmount)
        Dim totalDiscount As Decimal = receiptLines.Sum(Function(l) l.LineDiscountAmount)
        Dim totalNet As Decimal = receiptLines.Sum(Function(l) l.Net_Amount)

        ' --- Header Section ---
        sb.AppendLine()
        sb.AppendLine(CenterLine("SALES RECEIPT"))
        sb.AppendLine(DASH_LINE)

        ' Requested Header Fields
        sb.AppendLine(String.Format("DATE: {0}", firstLine.SalesDate.Substring(0, 10)))
        sb.AppendLine(String.Format("RECEIPT NO: {0}", firstLine.ReceiptNo))

        Dim cashierInfo As String = If(Not String.IsNullOrEmpty(firstLine.CashierName), firstLine.CashierName, firstLine.CashierID)
        sb.AppendLine(String.Format("CASHIER NAME: {0}", cashierInfo))

        sb.AppendLine(String.Format("STORE ID: {0}", firstLine.StoreID))

        ' Item Group (using ItemCategoryName, or "Mixed" if multiple categories are present)
        Dim uniqueGroups = receiptLines.Select(Function(l) l.ItemCategoryName).Distinct().ToList()
        Dim itemGroupDisplay As String = If(uniqueGroups.Count = 1, uniqueGroups.First(), "Mixed")
        sb.AppendLine(String.Format("ITEM GROUP: {0}", itemGroupDisplay))

        sb.AppendLine(DASH_LINE)

        ' --- Detail Line Header ---
        ' Item Name (20) | Qty (5) | Unit Price (10)
        sb.AppendLine(String.Format("{0,-20} {1,5} {2,10}", "ITEM NAME", "QTY", "U. PRICE"))
        sb.AppendLine(DASH_LINE)

        ' --- Detail Line Items ---
        For Each line In receiptLines
            Dim itemName As String = line.ItemName
            If itemName.Length > 20 Then itemName = itemName.Substring(0, 20)

            Dim qtyStr As String = line.Qty.ToString("0.##") ' Display quantity
            Dim unitPriceStr As String = line.UnitPrice.ToString("0.00") ' Use UnitPrice from API

            ' Line 1: Item Name
            sb.AppendLine(itemName)

            ' Line 2: Qty @ Unit Price
            sb.AppendLine(String.Format("{0,20} {1,5} @ {2,10}", "", qtyStr, unitPriceStr))

        Next

        sb.AppendLine(DASH_LINE)

        ' --- Footer Section ---

        ' Total Amount (Gross Sale Amount)
        sb.AppendLine(String.Format("{0,-20} {1,20:0.00}", "TOTAL AMOUNT:", totalGrossAmount))

        ' Total Discount
        sb.AppendLine(String.Format("{0,-20} {1,20:0.00}", "TOTAL DISCOUNT:", totalDiscount))

        ' Net Total (USD)
        sb.AppendLine(DASH_LINE)
        sb.AppendLine(String.Format("{0,-20} {1,20:0.00}", "**NET TOTAL (USD):**", totalNet))
        sb.AppendLine(DASH_LINE)
        sb.AppendLine()
        sb.AppendLine(CenterLine("THANK YOU FOR YOUR PURCHASE!"))
        sb.AppendLine()

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

    Private Sub HandlePrintButtonClick(ByVal receiptCount As Integer)
        lines = v_ReceiptContentToPrint.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
        linesPrinted = 0

        PrintDocument1.DocumentName = $"Sales Report Batch ({receiptCount} Items/Receipts)"

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

    ' ----------------------------------------------------------------------
    ' --- NEW SUMMARY REPORT LOGIC (To match the image) ---
    ' ----------------------------------------------------------------------

    ' Function to generate the aggregated summary data
    Private Function AggregateSummaryData(ByVal data As List(Of SalesData)) As List(Of SummarySalesLine)
        If data Is Nothing OrElse data.Count = 0 Then Return New List(Of SummarySalesLine)()

        Dim summary = data.
            GroupBy(Function(d) d.ItemName). ' Group by item name
            Select(Function(g) New SummarySalesLine With {
                .ItemName = g.Key,
                .TotalQty = g.Sum(Function(l) l.Qty),
                .TotalAmount = g.Sum(Function(l) l.Net_Amount) ' Use Net_Amount for the total
            }).
            OrderBy(Function(s) s.ItemName).ToList()

        Return summary
    End Function

    ' Function to generate the formatted content for the summary report (like the image)
    Private Function GenerateSummaryReportContent(ByVal summaryData As List(Of SummarySalesLine), ByVal dateRange As String, ByVal storeName As String, ByVal cashierName As String) As String
        Dim sb As New StringBuilder()

        ' Constants for 40 Character Width
        Const TOTAL_WIDTH As Integer = 40
        Const STAR_LINE As String = "****************************************" ' 40 stars
        Const DASH_LINE As String = "----------------------------------------" ' 40 dashes

        ' Helper to center text
        Dim CenterLine = Function(text As String) As String
                             Dim safeText As String = If(text, "")
                             Dim padding As Integer = (TOTAL_WIDTH - safeText.Length) / 2
                             If padding < 0 Then padding = 0
                             Return New String(" "c, padding) & safeText
                         End Function


        ' --- Header Section ---
        sb.AppendLine(STAR_LINE)
        sb.AppendLine("*** DAILY SALES DETAIL REPORT ***")
        sb.AppendLine(STAR_LINE)

        sb.AppendLine($"DATE RANGE: {dateRange}")
        sb.AppendLine($"STORE: {storeName}")
        sb.AppendLine($"CASHIER: {cashierName}")

        sb.AppendLine(DASH_LINE)

        ' --- Detail Line Header ---
        ' ITEM NAME (22) | QTY (6) | AMOUNT (10)
        sb.AppendLine(String.Format("{0,-22} {1,6} {2,10}", "ITEM NAME", "QTY", "AMOUNT"))
        sb.AppendLine(DASH_LINE)

        ' --- Detail Line Items (Truncating Item Name to 22 characters) ---
        For Each line In summaryData
            Dim itemName As String = line.ItemName
            ' Check if truncation is needed before using Substring
            If itemName.Length > 22 Then
                itemName = itemName.Substring(0, 20) & ".." ' Truncate and add ".."
            Else
                ' Ensure the item name is padded correctly by the format string {0,-22}
            End If

            Dim qtyStr As String = line.TotalQty.ToString("0") ' Assuming QTY is integer or simple decimal
            Dim amountStr As String = line.TotalAmount.ToString("0.00")

            sb.AppendLine(String.Format("{0,-22} {1,6} {2,10}", itemName, qtyStr, amountStr))
        Next

        sb.AppendLine(DASH_LINE)

        ' --- Summary Totals ---
        Dim totalQty As Decimal = summaryData.Sum(Function(s) s.TotalQty)
        Dim totalAmount As Decimal = summaryData.Sum(Function(s) s.TotalAmount)

        sb.AppendLine(String.Format("**TOTALS** {0,6} {1,10:0.00}", totalQty.ToString("0"), totalAmount))

        sb.AppendLine(STAR_LINE)

        ' ⭐ ADDED FOOTER TITLES HERE ⭐
        sb.AppendLine() ' Add a blank line for separation (1)
        sb.AppendLine(CenterLine("Thank you for your purchase !"))
        sb.AppendLine(CenterLine("Pls come again."))
        sb.AppendLine() ' Add a blank line after the titles (2)
        ' ⭐ END FOOTER TITLES ⭐
        ' --- Added Footer Space ---
        sb.AppendLine("----------------------------------------") ' (5)
        Return sb.ToString()
    End Function

    ' ⭐ MODIFIED btnPreview_Click to generate the Summary Report ⭐
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        If v_AllSalesData Is Nothing OrElse v_AllSalesData.Count = 0 Then
            MessageBox.Show("Please view the report data first by clicking 'View'.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim displayDataList As List(Of DisplaySalesData)
        Try
            displayDataList = CType(dgSalesByProductReport.DataSource, List(Of DisplaySalesData))
        Catch
            MessageBox.Show("Error reading displayed data source. Please click 'View' again.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If displayDataList Is Nothing OrElse displayDataList.Count = 0 Then
            MessageBox.Show("No sales data found to preview.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' --- 1. Determine Filters and Data Source for Summary ---
        Dim fromDateStr As String = dtp_FDate.Value.ToString("yyyy-MM-dd")
        Dim toDateStr As String = dtp_TDate.Value.ToString("yyyy-MM-dd")
        Dim dateRange As String = $"{fromDateStr} to {toDateStr}"

        Dim storeName As String = If(cmbStore.SelectedItem IsNot Nothing, cmbStore.SelectedItem.ToString(), "All Stores")

        Dim selectedCashier As CashierFilterItem = TryCast(cmbCashier.SelectedItem, CashierFilterItem)
        Dim cashierName As String = If(selectedCashier IsNot Nothing AndAlso selectedCashier.CashierID <> "", selectedCashier.DisplayName, "All Cashiers")

        ' Use the currently filtered data for aggregation, mapping DisplaySalesData back to an equivalent SalesData for aggregation
        Dim currentFilteredData = displayDataList.Select(Function(d) New SalesData With {
            .SalesDate = d.SalesDate,
            .ItemName = d.ItemName,
            .Qty = d.Qty,
            .Net_Amount = d.Net_Amount ' Use Net_Amount for the final amount
        }).ToList()

        ' --- 2. Aggregate the data like the image (Item Name, Total QTY, Total AMOUNT) ---
        Dim summaryData = AggregateSummaryData(currentFilteredData)

        If summaryData.Count = 0 Then
            MessageBox.Show("No aggregated sales data found to preview.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' --- 3. Generate the formatted content for the Summary Report ---
        v_ReceiptContentToPrint = GenerateSummaryReportContent(summaryData, dateRange, storeName, cashierName)

        ' --- 4. Display Preview Form ---
        Dim previewForm As New Form()
        previewForm.Text = "Daily Sales Detail Report (Summary)"
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

        ' This prints the single summary report page
        AddHandler btnPrint.Click, Sub() HandlePrintButtonClick(1)

        previewForm.ShowDialog()

    End Sub

End Class