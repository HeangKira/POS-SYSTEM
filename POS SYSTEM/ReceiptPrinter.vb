Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Text.RegularExpressions

Public Module ReceiptPrinter

    ' IMPORTANT: This constant MUST match the printer name used in frm_pos_sell.
    Private Const POS_PRINTER_NAME As String = "EPSON TM-T88VI Receipt"
    Private Const TOTAL_WIDTH As Integer = 40
    Private Const DASH_LINE As String = "----------------------------------------" ' 40 dashes
    Private Const EQUAL_LINE As String = "========================================" ' 40 equals

    Private SharedContentToPrint As String = ""

    ' Helper function to center a string based on 40 character width
    Private Function CenterLine(ByVal text As String) As String
        Dim safeText As String = If(text, "")
        Return If(safeText.Length >= TOTAL_WIDTH, safeText.Substring(0, TOTAL_WIDTH), New String(" "c, (TOTAL_WIDTH - safeText.Length) \ 2) & safeText)
    End Function

    ''' <summary>
    ''' Formats the full transaction data into a printable receipt string.
    ''' VERSION COMPATIBLE WITH OLDER VB.NET (No ?. or ?? operators)
    ''' Updated with Description Auto-Fit and Left-Aligned Qty.
    ''' </summary>
    Public Function GenerateReceiptContentFromJObject(ByVal transactionData As JObject, Optional ByVal isVoid As Boolean = False) As String
        Dim receiptLines As New System.Text.StringBuilder()

        ' 1. Safely Extract Main JObjects
        Dim header As JObject = CType(transactionData("header"), JObject)
        Dim details As JArray = CType(transactionData("details"), JArray)
        Dim payments As JArray = CType(transactionData("payments"), JArray)

        If header Is Nothing OrElse details Is Nothing OrElse payments Is Nothing Then
            Return CenterLine("!!! ERROR: Invalid Transaction Data !!!") & vbCrLf & vbCrLf
        End If

        ' --- 2. Header Section ---
        Dim storeName As String = ""
        If header("store_name") IsNot Nothing Then storeName = header("store_name").ToString()

        Dim receiptNo As String = ""
        If header("receipt_no") IsNot Nothing Then receiptNo = header("receipt_no").ToString()

        Dim receiptDate As DateTime = DateTime.Now
        If header("receipt_date") IsNot Nothing Then receiptDate = header("receipt_date").ToObject(Of DateTime)()

        Dim cashierName As String = ""
        If header("cashier_name") IsNot Nothing Then cashierName = header("cashier_name").ToString()
        receiptLines.AppendLine(CenterLine(storeName))
        receiptLines.AppendLine(String.Format("Check: {0}", receiptNo))
        receiptLines.AppendLine(String.Format("Date : {0}", receiptDate.ToString("dd-MM-yyyy HH:mm")))
        receiptLines.AppendLine(String.Format("Staff: {0}", cashierName))
        receiptLines.AppendLine(EQUAL_LINE)

        ' --- 3. Detail Line Items (Auto-Fit Logic) ---
        Dim totalItemsInTransaction As Decimal = 0D

        For Each detail As JObject In details
            ' A. Clean Description: Merges multiline UI text into one single string
            Dim itemNameText As String = ""
            If detail("item_name") IsNot Nothing Then itemNameText = detail("item_name").ToString()

            Dim rawDesc As String = itemNameText.Replace(vbCrLf, " ").Replace(vbLf, " ").Trim()
            ' B. Ensure only single spaces exist between words
            Dim fullDesc As String = System.Text.RegularExpressions.Regex.Replace(rawDesc, "\s+", " ")

            Dim qty As Decimal = 0
            If detail("qty") IsNot Nothing Then qty = detail("qty").ToObject(Of Decimal)()

            Dim price As Decimal = 0
            If detail("price") IsNot Nothing Then price = detail("price").ToObject(Of Decimal)()

            Dim netAmt As Decimal = 0
            If detail("net_amt") IsNot Nothing Then netAmt = detail("net_amt").ToObject(Of Decimal)()

            If qty <= 0D Then Continue For
            totalItemsInTransaction += qty

            ' C. Split cleaned description into 20-character chunks
            Dim chunks As New List(Of String)
            For i As Integer = 0 To fullDesc.Length - 1 Step 20
                If i + 20 <= fullDesc.Length Then
                    chunks.Add(fullDesc.Substring(i, 20))
                Else
                    chunks.Add(fullDesc.Substring(i))
                End If
            Next

            ' D. Formatting Logic
            Dim firstChunk As String = If(chunks.Count > 0, chunks(0), "")
            ' Logic: If Qty = 1, hide price; otherwise add "@" symbol
            Dim priceDisplay As String = If(qty = 1, "", "@" & price.ToString("N2"))

            ' Qty left-aligned {0,-3}
            ' Layout: Qty(3, Left) + Space(1) + NamePart(20) + Space(1) + Price(7) + Space(1) + Total(7) = 40
            receiptLines.AppendLine(String.Format("{0,-3} {1,-20} {2,7} {3,7:N2}",
                                qty.ToString("0"),
                                firstChunk,
                                priceDisplay,
                                netAmt))

            ' E. Auto-wrapped description indented by 4 spaces
            If chunks.Count > 1 Then
                For j As Integer = 1 To chunks.Count - 1
                    receiptLines.AppendLine(String.Format("    {0,-20}", chunks(j)))
                Next
            End If
        Next

        ' --- 4. Summary Totals Section ---
        receiptLines.AppendLine(DASH_LINE)

        Dim grossTotalSum As Decimal = 0
        If header("sub_total") IsNot Nothing Then grossTotalSum = header("sub_total").ToObject(Of Decimal)()

        Dim lineDiscount As Decimal = 0
        If header("line_discount") IsNot Nothing Then lineDiscount = header("line_discount").ToObject(Of Decimal)()

        Dim globalDiscount As Decimal = 0
        If header("global_discount") IsNot Nothing Then globalDiscount = header("global_discount").ToObject(Of Decimal)()

        Dim vatAmt As Decimal = 0
        If header("total_discount_vat") IsNot Nothing Then vatAmt = header("total_discount_vat").ToObject(Of Decimal)()

        Dim shippingFee As Decimal = 0
        If header("ship_fee") IsNot Nothing Then shippingFee = header("ship_fee").ToObject(Of Decimal)()

        Dim grandTotal As Decimal = 0
        If header("grand_total") IsNot Nothing Then grandTotal = header("grand_total").ToObject(Of Decimal)()

        Dim totalDiscount As Decimal = lineDiscount + globalDiscount

        receiptLines.AppendLine(String.Format("{0,-30} {1,9:N2}", "Sub Total", grossTotalSum))
        receiptLines.AppendLine(String.Format("{0,-30} {1,9:N2}", "Discount", -totalDiscount))

        If shippingFee > 0D Then receiptLines.AppendLine(String.Format("{0,-30} {1,9:N2}", "Shipping Fee", shippingFee))
        If vatAmt > 0D Then receiptLines.AppendLine(String.Format("{0,-30} {1,9:N2}", "VAT Amount", vatAmt))

        receiptLines.AppendLine(DASH_LINE)
        receiptLines.AppendLine(String.Format("{0,-30} {1,9:N2}", "**Total USD**", grandTotal))
        receiptLines.AppendLine(DASH_LINE)

        ' --- 5. Payment and Change Logic ---
        Dim totalPaidUSD As Decimal = 0D
        For Each payment As JObject In payments
            Dim curRate As Decimal = 1D
            If payment("cur_rate") IsNot Nothing Then Decimal.TryParse(payment("cur_rate").ToString(), curRate)
            Dim recAmtLocal As Decimal = 0D
            If payment("rec_amt") IsNot Nothing Then Decimal.TryParse(payment("rec_amt").ToString(), recAmtLocal)
            If curRate > 0D Then totalPaidUSD += (recAmtLocal / curRate)
        Next

        Dim rawChangeUSD As Decimal = totalPaidUSD - grandTotal
        Dim khrRate As Decimal = 4100
        Dim thbRate As Decimal = 35

        For Each p As JObject In payments
            If p("cur_code") IsNot Nothing Then
                If p("cur_code").ToString() = "KHR" Then khrRate = CDec(p("cur_rate"))
                If p("cur_code").ToString() = "THB" Then thbRate = CDec(p("cur_rate"))
            End If
        Next

        receiptLines.AppendLine(String.Format("{0,-15} {1,24}", "Amount", "Changes"))
        receiptLines.AppendLine(String.Format("USD {0,-11:N2} {1,23:N2}", totalPaidUSD, Math.Max(0, rawChangeUSD)))
        receiptLines.AppendLine(String.Format("KHR {0,-11:N0} {1,23:N0}", totalPaidUSD * khrRate, Math.Max(0, rawChangeUSD * khrRate)))
        receiptLines.AppendLine(String.Format("THB {0,-11:N0} {1,23:N0}", totalPaidUSD * thbRate, Math.Max(0, rawChangeUSD * thbRate)))

        ' --- 6. Footer Update ---
        receiptLines.AppendLine()
        If isVoid Then
            receiptLines.AppendLine(CenterLine("THIS TRANSACTION HAS BEEN VOIDED"))
            If header("void_reason") IsNot Nothing Then
                receiptLines.AppendLine(CenterLine("Reason: " & header("void_reason").ToString()))
            End If
        Else
            receiptLines.AppendLine(CenterLine("THANK YOU FOR YOUR PURCHASE!"))
        End If

        receiptLines.AppendLine(CenterLine(If(isVoid, "!!! VOID RECEIPT !!!", "!!! REPRINT RECEIPT !!!")))
        receiptLines.AppendLine(CenterLine("Please come again."))
        receiptLines.AppendLine(DASH_LINE)
        receiptLines.AppendLine(CenterLine("Tel:(855)23 884 242, 017 222 009"))

        receiptLines.AppendLine(vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & ".")

        Return receiptLines.ToString()
    End Function

    ''' <summary>
    ''' Executes the printing of the generated receipt content to the POS printer.
    ''' </summary>
    Public Sub ExecutePrint(ByVal receiptContent As String, ByVal receiptNo As String)
        Using doc As New PrintDocument()
            doc.PrinterSettings.PrinterName = POS_PRINTER_NAME
            doc.DocumentName = String.Format("Receipt: {0}", receiptNo)

            If Not doc.PrinterSettings.IsValid Then
                Throw New InvalidOperationException(String.Format("POS Printer '{0}' is not found.", POS_PRINTER_NAME))
            End If

            SharedContentToPrint = receiptContent
            AddHandler doc.PrintPage, AddressOf ReceiptPrinter_PrintPage

            Try
                doc.Print()
            Catch ex As Exception
                Throw New Exception(String.Format("Error printing: {0}", ex.Message))
            Finally
                RemoveHandler doc.PrintPage, AddressOf ReceiptPrinter_PrintPage
                SharedContentToPrint = ""
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Standard PrintPage handler with dynamic header text.
    ''' </summary>
    Private Sub ReceiptPrinter_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin As Single = 1
        Dim yPosition As Single = 5

        Dim HeaderFont As New Font("Courier New", 12, FontStyle.Bold)
        Dim NormalFont As New Font("Courier New", 8, FontStyle.Regular)
        Dim brush As New SolidBrush(Color.Black)
        Dim lineHeight As Single = NormalFont.GetHeight(e.Graphics) * 1.1F

        ' --- 1. LOGO INTEGRATION (RETAINED) ---
        Dim logoPath As String = Application.StartupPath & "\" & "CompanyLogo.png"
        Try
            If System.IO.File.Exists(logoPath) Then
                Using logoImage As Image = Image.FromFile(logoPath)
                    Dim logoWidth As Integer = 150
                    Dim logoHeight As Integer = CInt(logoImage.Height * (logoWidth / logoImage.Width))
                    Dim centerX As Single = (e.Graphics.VisibleClipBounds.Width - logoWidth) / 2
                    If centerX < leftMargin Then centerX = leftMargin
                    e.Graphics.DrawImage(logoImage, centerX, yPosition, logoWidth, logoHeight)
                    yPosition += logoHeight + 10
                End Using
            End If
        Catch ex As Exception
            yPosition += 20
        End Try

        ' --- 2. DYNAMIC HEADER logic (RETAINED) ---
        Dim headerText As String = "REPRINT RECEIPT"
        If SharedContentToPrint.Contains("VOIDED") Then
            headerText = "VOID RECEIPT"
        End If

        yPosition += 5.0F
        Dim stringSize As SizeF = e.Graphics.MeasureString(headerText, HeaderFont)
        e.Graphics.DrawString(headerText, HeaderFont, brush, (e.Graphics.VisibleClipBounds.Width - stringSize.Width) / 2, yPosition)
        yPosition += stringSize.Height + 5.0F

        ' --- 3. Body Content ---
        Dim lines() As String = SharedContentToPrint.Split(New String() {vbCrLf}, StringSplitOptions.None)
        For Each line As String In lines
            e.Graphics.DrawString(line, NormalFont, brush, leftMargin, yPosition)
            yPosition += lineHeight
        Next

        e.HasMorePages = False
    End Sub

End Module