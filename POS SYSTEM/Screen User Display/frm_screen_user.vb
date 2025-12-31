Imports System.Windows.Forms
Imports System.Linq

Public Class frm_screen_user

    ' --- Form Initialization ---
    Private Sub frm_screen_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No header setup needed now.
    End Sub

    ' The SetupPanelHeader and AddHeaderLabel methods have been removed.


    ' --- PUBLIC METHOD: To receive and display the items ---
    Public Sub UpdateDisplayItems(ByVal itemDataList As List(Of main_pos_system.DisplayItemInfo), ByVal netTotalDue As Decimal)

        ' 1. Clear ALL existing items and separators
        pnlItemDetail.Controls.Clear()

        ' 2. Loop through items and add them as dynamic TableLayoutPanels (rows)
        For Each item In itemDataList

            ' Create a new panel (row) for the item details
            Dim rowPanel As New TableLayoutPanel()
            With rowPanel
                ' Ensure it matches the width of the parent FlowLayoutPanel (pnlItemDetail)
                .Width = pnlItemDetail.ClientSize.Width - 5
                .Height = 30 ' Slightly larger height for better spacing
                .ColumnCount = 5
                .RowCount = 1
                .Margin = New Padding(0)
                .BackColor = Drawing.Color.White ' Set row background for contrast

                ' Set Column Styles (widths for item alignment)
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 80))  ' Code
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180)) ' Name
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50))  ' Qty
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70))  ' Price
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 80))  ' Amount
            End With

            ' Add the data labels to the row panel
            AddDetailLabel(rowPanel, item.ItemCode, 0, Drawing.ContentAlignment.MiddleLeft)
            AddDetailLabel(rowPanel, item.Description, 1, Drawing.ContentAlignment.MiddleLeft)
            AddDetailLabel(rowPanel, item.Quantity.ToString("N2"), 2, Drawing.ContentAlignment.MiddleRight, Drawing.FontStyle.Bold) ' Bold Qty
            AddDetailLabel(rowPanel, item.Price.ToString("N2"), 3, Drawing.ContentAlignment.MiddleRight)
            AddDetailLabel(rowPanel, item.NetPrice.ToString("N2"), 4, Drawing.ContentAlignment.MiddleRight, Drawing.FontStyle.Bold) ' Bold Amount

            ' Add the new row panel to the FlowLayoutPanel
            pnlItemDetail.Controls.Add(rowPanel)

            ' Add a visual separator line (a thin Panel) for better UI design
            CreateSeparatorLine()

        Next

        ' 3. Update Totals Display (unchanged)
        If itemDataList.Count > 0 Then
            Dim finalTotals As main_pos_system.DisplayItemInfo = itemDataList.Last()

            txtTotalRiel.Text = "៛ " & finalTotals.TotalKHR.ToString("N0")
            txtTotalBard.Text = "฿ " & finalTotals.TotalTHB.ToString("N0")
            txtTotalQty.Text = finalTotals.Totalqty.ToString("N2")
        Else
            ' Handle empty cart case
            txtTotalRiel.Text = "៛ 0"
            txtTotalBard.Text = "฿ 0"
            txtTotalQty.Text = "0"
        End If

        txtTotalUSD.Text = "$ " & netTotalDue.ToString("N2")
    End Sub

    ''' <summary>
    ''' Helper method to create and style the Labels for the detail rows.
    ''' </summary>
    Private Sub AddDetailLabel(ByVal container As TableLayoutPanel, ByVal text As String, ByVal column As Integer, ByVal alignment As Drawing.ContentAlignment, Optional ByVal style As Drawing.FontStyle = Drawing.FontStyle.Regular)
        Dim lbl As New Label()
        With lbl
            .Text = text
            .Font = New Drawing.Font(Me.Font.FontFamily, 12, style) ' Apply optional bold style
            .Dock = DockStyle.Fill
            .TextAlign = alignment
            .Margin = New Padding(0, 5, 0, 5) ' Vertical margin within the row
            .ForeColor = Drawing.Color.Black
        End With
        container.Controls.Add(lbl, column, 0)
    End Sub

    ''' <summary>
    ''' Creates a thin separator line to improve UI separation between items.
    ''' </summary>
    Private Sub CreateSeparatorLine()
        Dim separatorPanel As New Panel()
        With separatorPanel
            .Width = pnlItemDetail.ClientSize.Width - 10 ' Full width minus padding
            .Height = 1 ' Very thin line
            .BackColor = Drawing.Color.LightGray ' Light color for a subtle line
            .Margin = New Padding(5, 0, 5, 0) ' No vertical margin, centered horizontally
        End With
        pnlItemDetail.Controls.Add(separatorPanel)
    End Sub

End Class