<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_display_second
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgtDisplayDataPosMani As DataGridView
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblRiel As Label
    Friend WithEvents lblBard As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents blbDiscount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgtDisplayDataPosMani = New System.Windows.Forms.DataGridView()
        Me.lblRiel = New System.Windows.Forms.Label()
        Me.lblBard = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.blbDiscount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgtDisplayDataPosMani, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(7, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1206, 62)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.POS_SYSTEM.My.Resources.Resources.Positron_Logo_White1
        Me.PictureBox1.Location = New System.Drawing.Point(10, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Enabled = False
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(151, 21)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(142, 26)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "WELCOME"
        Me.lblTitle.Visible = False
        '
        'dgtDisplayDataPosMani
        '
        Me.dgtDisplayDataPosMani.AllowUserToAddRows = False
        Me.dgtDisplayDataPosMani.AllowUserToDeleteRows = False
        Me.dgtDisplayDataPosMani.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgtDisplayDataPosMani.BackgroundColor = System.Drawing.Color.Gray
        Me.dgtDisplayDataPosMani.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgtDisplayDataPosMani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgtDisplayDataPosMani.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.dgtDisplayDataPosMani.Location = New System.Drawing.Point(7, 69)
        Me.dgtDisplayDataPosMani.Margin = New System.Windows.Forms.Padding(4)
        Me.dgtDisplayDataPosMani.Name = "dgtDisplayDataPosMani"
        Me.dgtDisplayDataPosMani.ReadOnly = True
        Me.dgtDisplayDataPosMani.RowHeadersWidth = 51
        Me.dgtDisplayDataPosMani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgtDisplayDataPosMani.Size = New System.Drawing.Size(527, 457)
        Me.dgtDisplayDataPosMani.TabIndex = 1
        '
        'lblRiel
        '
        Me.lblRiel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRiel.AutoSize = True
        Me.lblRiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRiel.ForeColor = System.Drawing.Color.White
        Me.lblRiel.Location = New System.Drawing.Point(418, 148)
        Me.lblRiel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRiel.Name = "lblRiel"
        Me.lblRiel.Size = New System.Drawing.Size(40, 31)
        Me.lblRiel.TabIndex = 55
        Me.lblRiel.Text = "៛ 0"
        '
        'lblBard
        '
        Me.lblBard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBard.AutoSize = True
        Me.lblBard.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblBard.ForeColor = System.Drawing.Color.White
        Me.lblBard.Location = New System.Drawing.Point(677, 150)
        Me.lblBard.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBard.Name = "lblBard"
        Me.lblBard.Size = New System.Drawing.Size(40, 24)
        Me.lblBard.TabIndex = 56
        Me.lblBard.Text = "฿ 0"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(88, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 25)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Qty"
        '
        'lblQty
        '
        Me.lblQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.White
        Me.lblQty.Location = New System.Drawing.Point(220, 40)
        Me.lblQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(24, 25)
        Me.lblQty.TabIndex = 58
        Me.lblQty.Text = "0"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lblGrandTotal)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.blbDiscount)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblSubTotal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lblQty)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblBard)
        Me.Panel2.Controls.Add(Me.lblRiel)
        Me.Panel2.Location = New System.Drawing.Point(7, 534)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1207, 183)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(188, 150)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 25)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = ":"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.White
        Me.lblGrandTotal.Location = New System.Drawing.Point(221, 151)
        Me.lblGrandTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(24, 25)
        Me.lblGrandTotal.TabIndex = 67
        Me.lblGrandTotal.Text = "0"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 151)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 25)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Grand Total "
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(189, 114)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 25)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(189, 77)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 25)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = ":"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(189, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 25)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = ":"
        '
        'blbDiscount
        '
        Me.blbDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.blbDiscount.AutoSize = True
        Me.blbDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blbDiscount.ForeColor = System.Drawing.Color.White
        Me.blbDiscount.Location = New System.Drawing.Point(221, 115)
        Me.blbDiscount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.blbDiscount.Name = "blbDiscount"
        Me.blbDiscount.Size = New System.Drawing.Size(24, 25)
        Me.blbDiscount.TabIndex = 62
        Me.blbDiscount.Text = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(37, 115)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 25)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Discount"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTotal.ForeColor = System.Drawing.Color.White
        Me.lblSubTotal.Location = New System.Drawing.Point(220, 79)
        Me.lblSubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(24, 25)
        Me.lblSubTotal.TabIndex = 60
        Me.lblSubTotal.Text = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Sub Total "
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2PictureBox1.BorderRadius = 10
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.Gray
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(541, 70)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(672, 456)
        Me.Guna2PictureBox1.TabIndex = 2
        Me.Guna2PictureBox1.TabStop = False
        '
        'frm_display_second
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(1220, 721)
        Me.Controls.Add(Me.Guna2PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgtDisplayDataPosMani)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_display_second"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_display_second"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgtDisplayDataPosMani, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub frm_display_second_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDisplayDataGrid()
        lblTitle.Text = "WELCOME TO POSITRON STORE"
        Me.TopMost = True
        Me.TopMost = False
    End Sub

    ' --- Initialize the DataGridView columns on load ---
    Private Sub InitializeDisplayDataGrid()
        With dgtDisplayDataPosMani
            .Rows.Clear()
            .Columns.Clear()

            ' --- THIS IS THE LINE TO REMOVE THE HEADER ---
            .ColumnHeadersVisible = False
            ' ---------------------------------------------

            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True

            ' Font and Color styling for data rows
            Dim detailStyle As New DataGridViewCellStyle()
            detailStyle.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
            detailStyle.ForeColor = Color.White
            detailStyle.BackColor = Color.Gray
            detailStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .DefaultCellStyle = detailStyle
            .RowTemplate.Height = 32

            .GridColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None

            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = .DefaultForeColor

            .ScrollBars = ScrollBars.Vertical
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Add columns (Headers text will be ignored because ColumnHeadersVisible = False)
            AddDisplayColumn("i_CODE", "", 90, 80, DataGridViewContentAlignment.MiddleLeft)
            AddDisplayColumn("i_DESC", "", 500, 150, DataGridViewContentAlignment.MiddleLeft)
            AddDisplayColumn("i_Qty", "", 55, 55, DataGridViewContentAlignment.MiddleRight)
            AddDisplayColumn("i_Price", "", 75, 65, DataGridViewContentAlignment.MiddleRight)
            AddDisplayColumn("i_NetAmt", "", 80, 80, DataGridViewContentAlignment.MiddleRight)

            For Each col As DataGridViewColumn In .Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With
    End Sub

    ' --- Helper Method: To set column properties easily, similar to SetupColumn in dg_Items ---
    Private Sub AddDisplayColumn(ByVal name As String, ByVal headerText As String, ByVal width As Integer, ByVal minWidth As Integer, ByVal alignment As DataGridViewContentAlignment)
        With dgtDisplayDataPosMani
            If Not .Columns.Contains(name) Then
                Dim col As New DataGridViewTextBoxColumn()
                With col
                    .Name = name
                    .HeaderText = headerText
                    .Width = width
                    .MinimumWidth = minWidth
                    .DefaultCellStyle.Alignment = alignment
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ' Center header text
                    .ReadOnly = True ' Since the whole grid is read-only, this is mainly for clarity
                End With
                .Columns.Add(col)
            End If
        End With
    End Sub

    ' --- PUBLIC METHOD: To receive and display the items and summary totals ---
    Public Sub UpdateDisplayItems(ByVal itemDataList As List(Of main_pos_system.DisplayItemInfo),
                              ByVal netTotalDue As Decimal,
                              ByVal subTotal As Decimal,
                              ByVal discountAmt As Decimal,
                              Optional ByVal currentItemImageUrl As String = "")

        dgtDisplayDataPosMani.Rows.Clear()

        For Each item In itemDataList
            dgtDisplayDataPosMani.Rows.Add(
            item.ItemCode,
            item.Description,
            item.Quantity.ToString("0.00"),
            item.Price.ToString("0.00"),
            item.NetPrice.ToString("0.00")
        )
        Next

        ' ⭐ FIX: Handle the PictureBox Image Loading
        If Not String.IsNullOrEmpty(currentItemImageUrl) Then
            Try
                ' Use ImageLocation for URL strings
                Guna2PictureBox1.ImageLocation = currentItemImageUrl
                Guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Catch ex As Exception
                ' Fallback if URL is broken
                Guna2PictureBox1.Image = Nothing
            End Try
        Else
            ' No image for this item
            Guna2PictureBox1.Image = Nothing
        End If
        If dgtDisplayDataPosMani.Rows.Count > 0 Then
            dgtDisplayDataPosMani.FirstDisplayedScrollingRowIndex = dgtDisplayDataPosMani.Rows.Count - 1
            lblRiel.Text = "៛ " & itemDataList(0).TotalKHR
            lblBard.Text = "฿ " & itemDataList(0).TotalTHB
            lblQty.Text = itemDataList(0).Totalqty
        Else
            lblRiel.Text = "៛ 0"
            lblBard.Text = "฿ 0"
            lblQty.Text = "0"
        End If
        Me.lblSubTotal.Text = subTotal.ToString("N2")
        Me.blbDiscount.Text = discountAmt.ToString("N2")
        Me.lblGrandTotal.Text = netTotalDue.ToString("N2")
        'Me.lblPaid.Text = "$ " & netTotalDue.ToString("N2")

        dgtDisplayDataPosMani.ClearSelection()
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub dgtDisplayDataPosMani_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgtDisplayDataPosMani.CellContentClick

    End Sub
End Class
