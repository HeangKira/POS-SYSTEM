<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_pos_sell
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_TitleBar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnLogout = New FontAwesome.Sharp.IconButton()
        Me.btnSetting = New FontAwesome.Sharp.IconButton()
        Me.btnSell = New FontAwesome.Sharp.IconButton()
        Me.btnHome = New FontAwesome.Sharp.IconButton()
        Me.btn_Maximize = New FontAwesome.Sharp.IconButton()
        Me.btn_Minimize = New FontAwesome.Sharp.IconButton()
        Me.btn_Exit = New FontAwesome.Sharp.IconButton()
        Me.dg_Items = New System.Windows.Forms.DataGridView()
        Me.i_Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_ITEMNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DisPct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DisAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_NetAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnClostingReport = New FontAwesome.Sharp.IconButton()
        Me.btnDriver = New FontAwesome.Sharp.IconButton()
        Me.btnVoide = New FontAwesome.Sharp.IconButton()
        Me.btnClear = New FontAwesome.Sharp.IconButton()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtTHBRate = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtKHRRate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.btnItemCode = New FontAwesome.Sharp.IconButton()
        Me.txt_Barcode = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCOD = New FontAwesome.Sharp.IconButton()
        Me.btnTHB = New FontAwesome.Sharp.IconButton()
        Me.btnKHR = New FontAwesome.Sharp.IconButton()
        Me.btnWechat = New FontAwesome.Sharp.IconButton()
        Me.btnAlipay = New FontAwesome.Sharp.IconButton()
        Me.btnUnionpay = New FontAwesome.Sharp.IconButton()
        Me.btnAMEX = New FontAwesome.Sharp.IconButton()
        Me.btnJCB = New FontAwesome.Sharp.IconButton()
        Me.btnMasterCard = New FontAwesome.Sharp.IconButton()
        Me.btnQRCode = New FontAwesome.Sharp.IconButton()
        Me.btnPay = New FontAwesome.Sharp.IconButton()
        Me.btnVisa = New FontAwesome.Sharp.IconButton()
        Me.btnCash = New FontAwesome.Sharp.IconButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnShppingFee = New FontAwesome.Sharp.IconButton()
        Me.cbNonVat = New System.Windows.Forms.CheckBox()
        Me.txtPercentage = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDelivery = New System.Windows.Forms.Label()
        Me.lblDeliveryName = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblAmtTHB = New System.Windows.Forms.Label()
        Me.lblAmtKHR = New System.Windows.Forms.Label()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.txtPaid = New System.Windows.Forms.TextBox()
        Me.txtAmtDue = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dg_Payment = New System.Windows.Forms.DataGridView()
        Me.PAY_METHOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BANK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REC_AMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNetTotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtCheckDiscountAmt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtShippingFee = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtVat = New System.Windows.Forms.TextBox()
        Me.lblCasheri = New System.Windows.Forms.Label()
        Me.lblStroe = New System.Windows.Forms.Label()
        Me.Panel_TitleBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg_Payment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_TitleBar
        '
        Me.Panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Panel_TitleBar.Controls.Add(Me.PictureBox1)
        Me.Panel_TitleBar.Controls.Add(Me.btnLogout)
        Me.Panel_TitleBar.Controls.Add(Me.btnSetting)
        Me.Panel_TitleBar.Controls.Add(Me.btnSell)
        Me.Panel_TitleBar.Controls.Add(Me.btnHome)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Maximize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Minimize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Exit)
        Me.Panel_TitleBar.Location = New System.Drawing.Point(0, 1)
        Me.Panel_TitleBar.Name = "Panel_TitleBar"
        Me.Panel_TitleBar.Size = New System.Drawing.Size(1008, 56)
        Me.Panel_TitleBar.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.POS_SYSTEM.My.Resources.Resources.Positron_Logo_White
        Me.PictureBox1.Location = New System.Drawing.Point(2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket
        Me.btnLogout.IconColor = System.Drawing.Color.White
        Me.btnLogout.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnLogout.IconSize = 27
        Me.btnLogout.Location = New System.Drawing.Point(493, 3)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(90, 50)
        Me.btnLogout.TabIndex = 29
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnSetting
        '
        Me.btnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetting.FlatAppearance.BorderSize = 0
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetting.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.ForeColor = System.Drawing.Color.White
        Me.btnSetting.IconChar = FontAwesome.Sharp.IconChar.Cog
        Me.btnSetting.IconColor = System.Drawing.Color.White
        Me.btnSetting.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnSetting.IconSize = 27
        Me.btnSetting.Location = New System.Drawing.Point(774, 3)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(90, 50)
        Me.btnSetting.TabIndex = 28
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnSell
        '
        Me.btnSell.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSell.FlatAppearance.BorderSize = 0
        Me.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSell.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSell.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnSell.IconChar = FontAwesome.Sharp.IconChar.Sellsy
        Me.btnSell.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnSell.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnSell.IconSize = 27
        Me.btnSell.Location = New System.Drawing.Point(271, 2)
        Me.btnSell.Name = "btnSell"
        Me.btnSell.Size = New System.Drawing.Size(90, 50)
        Me.btnSell.TabIndex = 27
        Me.btnSell.Text = "Sale Reports"
        Me.btnSell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSell.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnHome.IconChar = FontAwesome.Sharp.IconChar.House
        Me.btnHome.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnHome.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnHome.IconSize = 27
        Me.btnHome.Location = New System.Drawing.Point(155, 3)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(90, 50)
        Me.btnHome.TabIndex = 26
        Me.btnHome.Text = "Home"
        Me.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btn_Maximize
        '
        Me.btn_Maximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Maximize.FlatAppearance.BorderSize = 0
        Me.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Maximize.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Maximize.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Maximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.btn_Maximize.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btn_Maximize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Maximize.IconSize = 27
        Me.btn_Maximize.Location = New System.Drawing.Point(931, 13)
        Me.btn_Maximize.Name = "btn_Maximize"
        Me.btn_Maximize.Size = New System.Drawing.Size(30, 24)
        Me.btn_Maximize.TabIndex = 24
        Me.btn_Maximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Maximize.UseVisualStyleBackColor = True
        '
        'btn_Minimize
        '
        Me.btn_Minimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Minimize.FlatAppearance.BorderSize = 0
        Me.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Minimize.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Minimize.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Minimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize
        Me.btn_Minimize.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btn_Minimize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Minimize.IconSize = 27
        Me.btn_Minimize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Minimize.Location = New System.Drawing.Point(895, 13)
        Me.btn_Minimize.Name = "btn_Minimize"
        Me.btn_Minimize.Size = New System.Drawing.Size(30, 22)
        Me.btn_Minimize.TabIndex = 23
        Me.btn_Minimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Minimize.UseVisualStyleBackColor = True
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exit.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Exit.IconChar = FontAwesome.Sharp.IconChar.Remove
        Me.btn_Exit.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btn_Exit.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Exit.IconSize = 27
        Me.btn_Exit.Location = New System.Drawing.Point(967, 13)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(30, 24)
        Me.btn_Exit.TabIndex = 22
        Me.btn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'dg_Items
        '
        Me.dg_Items.AllowUserToAddRows = False
        Me.dg_Items.AllowUserToDeleteRows = False
        Me.dg_Items.AllowUserToResizeColumns = False
        Me.dg_Items.AllowUserToResizeRows = False
        Me.dg_Items.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dg_Items.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dg_Items.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(79, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_Items.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_Items.ColumnHeadersHeight = 45
        Me.dg_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.i_Line, Me.i_ITEMNO, Me.i_DESC, Me.i_Qty, Me.i_Price, Me.i_Uom, Me.i_DisPct, Me.i_DisAmt, Me.i_NetAmt})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_Items.DefaultCellStyle = DataGridViewCellStyle6
        Me.dg_Items.EnableHeadersVisualStyles = False
        Me.dg_Items.GridColor = System.Drawing.SystemColors.Control
        Me.dg_Items.Location = New System.Drawing.Point(0, 129)
        Me.dg_Items.Name = "dg_Items"
        Me.dg_Items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg_Items.RowHeadersVisible = False
        Me.dg_Items.RowHeadersWidth = 50
        Me.dg_Items.RowTemplate.Height = 40
        Me.dg_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_Items.ShowEditingIcon = False
        Me.dg_Items.Size = New System.Drawing.Size(788, 341)
        Me.dg_Items.TabIndex = 1
        '
        'i_Line
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.i_Line.DefaultCellStyle = DataGridViewCellStyle2
        Me.i_Line.HeaderText = "Line"
        Me.i_Line.MinimumWidth = 40
        Me.i_Line.Name = "i_Line"
        Me.i_Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Line.Width = 40
        '
        'i_ITEMNO
        '
        Me.i_ITEMNO.HeaderText = "Item No"
        Me.i_ITEMNO.MinimumWidth = 150
        Me.i_ITEMNO.Name = "i_ITEMNO"
        Me.i_ITEMNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_ITEMNO.Width = 150
        '
        'i_DESC
        '
        Me.i_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.i_DESC.HeaderText = "Description"
        Me.i_DESC.MinimumWidth = 130
        Me.i_DESC.Name = "i_DESC"
        Me.i_DESC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'i_Qty
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.i_Qty.DefaultCellStyle = DataGridViewCellStyle3
        Me.i_Qty.HeaderText = "Quantity"
        Me.i_Qty.MinimumWidth = 60
        Me.i_Qty.Name = "i_Qty"
        Me.i_Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Qty.Width = 60
        '
        'i_Price
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_Price.DefaultCellStyle = DataGridViewCellStyle4
        Me.i_Price.HeaderText = "Price"
        Me.i_Price.MinimumWidth = 60
        Me.i_Price.Name = "i_Price"
        Me.i_Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Price.Width = 60
        '
        'i_Uom
        '
        Me.i_Uom.HeaderText = "UOM"
        Me.i_Uom.MinimumWidth = 60
        Me.i_Uom.Name = "i_Uom"
        Me.i_Uom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Uom.Visible = False
        Me.i_Uom.Width = 60
        '
        'i_DisPct
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_DisPct.DefaultCellStyle = DataGridViewCellStyle5
        Me.i_DisPct.HeaderText = "Discount (%)"
        Me.i_DisPct.MinimumWidth = 85
        Me.i_DisPct.Name = "i_DisPct"
        Me.i_DisPct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_DisPct.Width = 85
        '
        'i_DisAmt
        '
        Me.i_DisAmt.HeaderText = "Discount ($)"
        Me.i_DisAmt.Name = "i_DisAmt"
        Me.i_DisAmt.Width = 80
        '
        'i_NetAmt
        '
        Me.i_NetAmt.HeaderText = "Amount"
        Me.i_NetAmt.Name = "i_NetAmt"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnClostingReport)
        Me.Panel1.Controls.Add(Me.btnDriver)
        Me.Panel1.Controls.Add(Me.btnVoide)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Location = New System.Drawing.Point(0, 471)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 63)
        Me.Panel1.TabIndex = 6
        '
        'btnClostingReport
        '
        Me.btnClostingReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClostingReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnClostingReport.FlatAppearance.BorderSize = 0
        Me.btnClostingReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClostingReport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClostingReport.ForeColor = System.Drawing.Color.Black
        Me.btnClostingReport.IconChar = FontAwesome.Sharp.IconChar.FileText
        Me.btnClostingReport.IconColor = System.Drawing.Color.Black
        Me.btnClostingReport.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnClostingReport.IconSize = 25
        Me.btnClostingReport.Location = New System.Drawing.Point(236, 6)
        Me.btnClostingReport.Name = "btnClostingReport"
        Me.btnClostingReport.Size = New System.Drawing.Size(101, 51)
        Me.btnClostingReport.TabIndex = 35
        Me.btnClostingReport.Text = "Closing Report"
        Me.btnClostingReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClostingReport.UseVisualStyleBackColor = False
        '
        'btnDriver
        '
        Me.btnDriver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDriver.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnDriver.FlatAppearance.BorderSize = 0
        Me.btnDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDriver.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDriver.ForeColor = System.Drawing.Color.Black
        Me.btnDriver.IconChar = FontAwesome.Sharp.IconChar.Motorcycle
        Me.btnDriver.IconColor = System.Drawing.Color.Black
        Me.btnDriver.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnDriver.IconSize = 25
        Me.btnDriver.Location = New System.Drawing.Point(119, 6)
        Me.btnDriver.Name = "btnDriver"
        Me.btnDriver.Size = New System.Drawing.Size(101, 51)
        Me.btnDriver.TabIndex = 34
        Me.btnDriver.Text = "Delivery"
        Me.btnDriver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDriver.UseVisualStyleBackColor = False
        '
        'btnVoide
        '
        Me.btnVoide.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoide.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnVoide.FlatAppearance.BorderSize = 0
        Me.btnVoide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoide.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoide.ForeColor = System.Drawing.Color.Black
        Me.btnVoide.IconChar = FontAwesome.Sharp.IconChar.Remove
        Me.btnVoide.IconColor = System.Drawing.Color.Black
        Me.btnVoide.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVoide.IconSize = 25
        Me.btnVoide.Location = New System.Drawing.Point(4, 6)
        Me.btnVoide.Name = "btnVoide"
        Me.btnVoide.Size = New System.Drawing.Size(101, 51)
        Me.btnVoide.TabIndex = 33
        Me.btnVoide.Text = "Void"
        Me.btnVoide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnVoide.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.IconChar = FontAwesome.Sharp.IconChar.Recycle
        Me.btnClear.IconColor = System.Drawing.Color.Red
        Me.btnClear.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnClear.IconSize = 20
        Me.btnClear.Location = New System.Drawing.Point(682, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(101, 51)
        Me.btnClear.TabIndex = 28
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Enabled = False
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(820, 10)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(144, 20)
        Me.dtpInvoiceDate.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblStroe)
        Me.Panel2.Controls.Add(Me.lblCasheri)
        Me.Panel2.Controls.Add(Me.txtTHBRate)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.txtKHRRate)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblBarcode)
        Me.Panel2.Controls.Add(Me.dtpInvoiceDate)
        Me.Panel2.Controls.Add(Me.btnItemCode)
        Me.Panel2.Controls.Add(Me.txt_Barcode)
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1007, 66)
        Me.Panel2.TabIndex = 7
        '
        'txtTHBRate
        '
        Me.txtTHBRate.Enabled = False
        Me.txtTHBRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTHBRate.Location = New System.Drawing.Point(931, 35)
        Me.txtTHBRate.Name = "txtTHBRate"
        Me.txtTHBRate.Size = New System.Drawing.Size(65, 21)
        Me.txtTHBRate.TabIndex = 185
        Me.txtTHBRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(863, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 16)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "TBH Rate :"
        '
        'txtKHRRate
        '
        Me.txtKHRRate.Enabled = False
        Me.txtKHRRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKHRRate.Location = New System.Drawing.Point(794, 35)
        Me.txtKHRRate.Name = "txtKHRRate"
        Me.txtKHRRate.Size = New System.Drawing.Size(66, 21)
        Me.txtKHRRate.TabIndex = 183
        Me.txtKHRRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(724, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 16)
        Me.Label14.TabIndex = 182
        Me.Label14.Text = "KHR Rate :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(725, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Invoice Date :"
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcode.Location = New System.Drawing.Point(13, 24)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(91, 16)
        Me.lblBarcode.TabIndex = 180
        Me.lblBarcode.Text = "Scan Barcode : "
        '
        'btnItemCode
        '
        Me.btnItemCode.BackColor = System.Drawing.Color.White
        Me.btnItemCode.FlatAppearance.BorderSize = 0
        Me.btnItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemCode.ForeColor = System.Drawing.Color.Black
        Me.btnItemCode.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass
        Me.btnItemCode.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnItemCode.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnItemCode.IconSize = 19
        Me.btnItemCode.Location = New System.Drawing.Point(325, 22)
        Me.btnItemCode.Name = "btnItemCode"
        Me.btnItemCode.Size = New System.Drawing.Size(27, 17)
        Me.btnItemCode.TabIndex = 179
        Me.btnItemCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnItemCode.UseVisualStyleBackColor = False
        '
        'txt_Barcode
        '
        Me.txt_Barcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Barcode.Location = New System.Drawing.Point(110, 17)
        Me.txt_Barcode.Multiline = True
        Me.txt_Barcode.Name = "txt_Barcode"
        Me.txt_Barcode.Size = New System.Drawing.Size(246, 30)
        Me.txt_Barcode.TabIndex = 178
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.btnCOD)
        Me.Panel3.Controls.Add(Me.btnTHB)
        Me.Panel3.Controls.Add(Me.btnKHR)
        Me.Panel3.Controls.Add(Me.btnWechat)
        Me.Panel3.Controls.Add(Me.btnAlipay)
        Me.Panel3.Controls.Add(Me.btnUnionpay)
        Me.Panel3.Controls.Add(Me.btnAMEX)
        Me.Panel3.Controls.Add(Me.btnJCB)
        Me.Panel3.Controls.Add(Me.btnMasterCard)
        Me.Panel3.Controls.Add(Me.btnQRCode)
        Me.Panel3.Controls.Add(Me.btnPay)
        Me.Panel3.Controls.Add(Me.btnVisa)
        Me.Panel3.Controls.Add(Me.btnCash)
        Me.Panel3.Location = New System.Drawing.Point(789, 129)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(217, 405)
        Me.Panel3.TabIndex = 8
        '
        'btnCOD
        '
        Me.btnCOD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCOD.FlatAppearance.BorderSize = 0
        Me.btnCOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCOD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCOD.ForeColor = System.Drawing.Color.Black
        Me.btnCOD.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.btnCOD.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCOD.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnCOD.IconSize = 30
        Me.btnCOD.Location = New System.Drawing.Point(111, 295)
        Me.btnCOD.Name = "btnCOD"
        Me.btnCOD.Size = New System.Drawing.Size(98, 54)
        Me.btnCOD.TabIndex = 65
        Me.btnCOD.Text = "COD"
        Me.btnCOD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCOD.UseVisualStyleBackColor = True
        '
        'btnTHB
        '
        Me.btnTHB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTHB.FlatAppearance.BorderSize = 0
        Me.btnTHB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTHB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTHB.ForeColor = System.Drawing.Color.Black
        Me.btnTHB.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.btnTHB.IconColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.btnTHB.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnTHB.IconSize = 30
        Me.btnTHB.Location = New System.Drawing.Point(110, 60)
        Me.btnTHB.Name = "btnTHB"
        Me.btnTHB.Size = New System.Drawing.Size(98, 51)
        Me.btnTHB.TabIndex = 64
        Me.btnTHB.Text = "Cash THB"
        Me.btnTHB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnTHB.UseVisualStyleBackColor = True
        '
        'btnKHR
        '
        Me.btnKHR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKHR.FlatAppearance.BorderSize = 0
        Me.btnKHR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKHR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKHR.ForeColor = System.Drawing.Color.Black
        Me.btnKHR.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.btnKHR.IconColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.btnKHR.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnKHR.IconSize = 30
        Me.btnKHR.Location = New System.Drawing.Point(111, 3)
        Me.btnKHR.Name = "btnKHR"
        Me.btnKHR.Size = New System.Drawing.Size(98, 51)
        Me.btnKHR.TabIndex = 63
        Me.btnKHR.Text = "Cash KHR"
        Me.btnKHR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnKHR.UseVisualStyleBackColor = True
        '
        'btnWechat
        '
        Me.btnWechat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWechat.FlatAppearance.BorderSize = 0
        Me.btnWechat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWechat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWechat.ForeColor = System.Drawing.Color.Black
        Me.btnWechat.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnWechat.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnWechat.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnWechat.IconSize = 30
        Me.btnWechat.Location = New System.Drawing.Point(5, 295)
        Me.btnWechat.Name = "btnWechat"
        Me.btnWechat.Size = New System.Drawing.Size(98, 54)
        Me.btnWechat.TabIndex = 62
        Me.btnWechat.Text = "Wechat"
        Me.btnWechat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnWechat.UseVisualStyleBackColor = True
        '
        'btnAlipay
        '
        Me.btnAlipay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlipay.FlatAppearance.BorderSize = 0
        Me.btnAlipay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlipay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlipay.ForeColor = System.Drawing.Color.Black
        Me.btnAlipay.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnAlipay.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnAlipay.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnAlipay.IconSize = 30
        Me.btnAlipay.Location = New System.Drawing.Point(111, 236)
        Me.btnAlipay.Name = "btnAlipay"
        Me.btnAlipay.Size = New System.Drawing.Size(98, 51)
        Me.btnAlipay.TabIndex = 61
        Me.btnAlipay.Text = "Alipay"
        Me.btnAlipay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAlipay.UseVisualStyleBackColor = True
        '
        'btnUnionpay
        '
        Me.btnUnionpay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnionpay.FlatAppearance.BorderSize = 0
        Me.btnUnionpay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnionpay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnionpay.ForeColor = System.Drawing.Color.Black
        Me.btnUnionpay.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnUnionpay.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnUnionpay.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnUnionpay.IconSize = 30
        Me.btnUnionpay.Location = New System.Drawing.Point(6, 236)
        Me.btnUnionpay.Name = "btnUnionpay"
        Me.btnUnionpay.Size = New System.Drawing.Size(98, 51)
        Me.btnUnionpay.TabIndex = 60
        Me.btnUnionpay.Text = "Unionpay"
        Me.btnUnionpay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUnionpay.UseVisualStyleBackColor = True
        '
        'btnAMEX
        '
        Me.btnAMEX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAMEX.FlatAppearance.BorderSize = 0
        Me.btnAMEX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAMEX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAMEX.ForeColor = System.Drawing.Color.Black
        Me.btnAMEX.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnAMEX.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnAMEX.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnAMEX.IconSize = 30
        Me.btnAMEX.Location = New System.Drawing.Point(109, 174)
        Me.btnAMEX.Name = "btnAMEX"
        Me.btnAMEX.Size = New System.Drawing.Size(98, 51)
        Me.btnAMEX.TabIndex = 59
        Me.btnAMEX.Text = "Amex"
        Me.btnAMEX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAMEX.UseVisualStyleBackColor = True
        '
        'btnJCB
        '
        Me.btnJCB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnJCB.FlatAppearance.BorderSize = 0
        Me.btnJCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJCB.ForeColor = System.Drawing.Color.Black
        Me.btnJCB.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnJCB.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnJCB.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnJCB.IconSize = 30
        Me.btnJCB.Location = New System.Drawing.Point(4, 174)
        Me.btnJCB.Name = "btnJCB"
        Me.btnJCB.Size = New System.Drawing.Size(98, 51)
        Me.btnJCB.TabIndex = 58
        Me.btnJCB.Text = "JCB "
        Me.btnJCB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnJCB.UseVisualStyleBackColor = True
        '
        'btnMasterCard
        '
        Me.btnMasterCard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMasterCard.FlatAppearance.BorderSize = 0
        Me.btnMasterCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMasterCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMasterCard.ForeColor = System.Drawing.Color.Black
        Me.btnMasterCard.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnMasterCard.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnMasterCard.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnMasterCard.IconSize = 30
        Me.btnMasterCard.Location = New System.Drawing.Point(110, 116)
        Me.btnMasterCard.Name = "btnMasterCard"
        Me.btnMasterCard.Size = New System.Drawing.Size(98, 51)
        Me.btnMasterCard.TabIndex = 57
        Me.btnMasterCard.Text = "Master Card"
        Me.btnMasterCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMasterCard.UseVisualStyleBackColor = True
        '
        'btnQRCode
        '
        Me.btnQRCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQRCode.FlatAppearance.BorderSize = 0
        Me.btnQRCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQRCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQRCode.ForeColor = System.Drawing.Color.Black
        Me.btnQRCode.IconChar = FontAwesome.Sharp.IconChar.Qrcode
        Me.btnQRCode.IconColor = System.Drawing.Color.Black
        Me.btnQRCode.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnQRCode.IconSize = 30
        Me.btnQRCode.Location = New System.Drawing.Point(7, 60)
        Me.btnQRCode.Name = "btnQRCode"
        Me.btnQRCode.Size = New System.Drawing.Size(98, 51)
        Me.btnQRCode.TabIndex = 46
        Me.btnQRCode.Text = "QR Code"
        Me.btnQRCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnQRCode.UseVisualStyleBackColor = True
        '
        'btnPay
        '
        Me.btnPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPay.BackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnPay.FlatAppearance.BorderSize = 0
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPay.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.ForeColor = System.Drawing.Color.Black
        Me.btnPay.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.btnPay.IconColor = System.Drawing.Color.SeaGreen
        Me.btnPay.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnPay.IconSize = 25
        Me.btnPay.Location = New System.Drawing.Point(3, 355)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(211, 46)
        Me.btnPay.TabIndex = 56
        Me.btnPay.Text = "Settle"
        Me.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'btnVisa
        '
        Me.btnVisa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVisa.FlatAppearance.BorderSize = 0
        Me.btnVisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisa.ForeColor = System.Drawing.Color.Black
        Me.btnVisa.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt
        Me.btnVisa.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnVisa.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnVisa.IconSize = 30
        Me.btnVisa.Location = New System.Drawing.Point(5, 114)
        Me.btnVisa.Name = "btnVisa"
        Me.btnVisa.Size = New System.Drawing.Size(98, 51)
        Me.btnVisa.TabIndex = 45
        Me.btnVisa.Text = "Visa"
        Me.btnVisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnVisa.UseVisualStyleBackColor = True
        '
        'btnCash
        '
        Me.btnCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCash.FlatAppearance.BorderSize = 0
        Me.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCash.ForeColor = System.Drawing.Color.Black
        Me.btnCash.IconChar = FontAwesome.Sharp.IconChar.MoneyBill
        Me.btnCash.IconColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.btnCash.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnCash.IconSize = 30
        Me.btnCash.Location = New System.Drawing.Point(6, 3)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(98, 51)
        Me.btnCash.TabIndex = 44
        Me.btnCash.Text = "Cash USD"
        Me.btnCash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btnShppingFee)
        Me.Panel4.Controls.Add(Me.cbNonVat)
        Me.Panel4.Controls.Add(Me.txtPercentage)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtNetTotal)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtSubTotal)
        Me.Panel4.Controls.Add(Me.txtQuantity)
        Me.Panel4.Controls.Add(Me.Label41)
        Me.Panel4.Controls.Add(Me.txtCheckDiscountAmt)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.txtShippingFee)
        Me.Panel4.Controls.Add(Me.Label38)
        Me.Panel4.Controls.Add(Me.txtVat)
        Me.Panel4.Location = New System.Drawing.Point(0, 536)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1006, 190)
        Me.Panel4.TabIndex = 7
        '
        'btnShppingFee
        '
        Me.btnShppingFee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShppingFee.BackColor = System.Drawing.Color.Transparent
        Me.btnShppingFee.FlatAppearance.BorderSize = 0
        Me.btnShppingFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShppingFee.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShppingFee.ForeColor = System.Drawing.Color.Black
        Me.btnShppingFee.IconChar = FontAwesome.Sharp.IconChar.PlusCircle
        Me.btnShppingFee.IconColor = System.Drawing.Color.Green
        Me.btnShppingFee.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnShppingFee.IconSize = 20
        Me.btnShppingFee.Location = New System.Drawing.Point(277, 123)
        Me.btnShppingFee.Name = "btnShppingFee"
        Me.btnShppingFee.Size = New System.Drawing.Size(30, 20)
        Me.btnShppingFee.TabIndex = 29
        Me.btnShppingFee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnShppingFee.UseVisualStyleBackColor = False
        '
        'cbNonVat
        '
        Me.cbNonVat.AutoSize = True
        Me.cbNonVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cbNonVat.Location = New System.Drawing.Point(276, 96)
        Me.cbNonVat.Name = "cbNonVat"
        Me.cbNonVat.Size = New System.Drawing.Size(81, 19)
        Me.cbNonVat.TabIndex = 45
        Me.cbNonVat.Text = "Non-VAT"
        Me.cbNonVat.UseVisualStyleBackColor = True
        '
        'txtPercentage
        '
        Me.txtPercentage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPercentage.BackColor = System.Drawing.SystemColors.Window
        Me.txtPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercentage.Location = New System.Drawing.Point(276, 67)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(89, 21)
        Me.txtPercentage.TabIndex = 44
        Me.txtPercentage.TabStop = False
        Me.txtPercentage.Text = "0.00"
        Me.txtPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label5.Location = New System.Drawing.Point(246, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 15)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "% :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblDelivery)
        Me.GroupBox1.Controls.Add(Me.lblDeliveryName)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblAmtTHB)
        Me.GroupBox1.Controls.Add(Me.lblAmtKHR)
        Me.GroupBox1.Controls.Add(Me.txtChange)
        Me.GroupBox1.Controls.Add(Me.txtPaid)
        Me.GroupBox1.Controls.Add(Me.txtAmtDue)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dg_Payment)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(481, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 177)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Payment Information"
        '
        'lblDelivery
        '
        Me.lblDelivery.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDelivery.AutoSize = True
        Me.lblDelivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelivery.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblDelivery.Location = New System.Drawing.Point(402, 100)
        Me.lblDelivery.Name = "lblDelivery"
        Me.lblDelivery.Size = New System.Drawing.Size(47, 13)
        Me.lblDelivery.TabIndex = 57
        Me.lblDelivery.Text = "Deliver"
        '
        'lblDeliveryName
        '
        Me.lblDeliveryName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDeliveryName.AutoSize = True
        Me.lblDeliveryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeliveryName.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblDeliveryName.Location = New System.Drawing.Point(299, 100)
        Me.lblDeliveryName.Name = "lblDeliveryName"
        Me.lblDeliveryName.Size = New System.Drawing.Size(97, 13)
        Me.lblDeliveryName.TabIndex = 56
        Me.lblDeliveryName.Text = "Delivery Name :"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label12.Location = New System.Drawing.Point(225, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 20)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "THB :"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label11.Location = New System.Drawing.Point(17, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 20)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "KHR :"
        '
        'lblAmtTHB
        '
        Me.lblAmtTHB.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAmtTHB.AutoSize = True
        Me.lblAmtTHB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmtTHB.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblAmtTHB.Location = New System.Drawing.Point(285, 151)
        Me.lblAmtTHB.Name = "lblAmtTHB"
        Me.lblAmtTHB.Size = New System.Drawing.Size(19, 20)
        Me.lblAmtTHB.TabIndex = 53
        Me.lblAmtTHB.Text = "0"
        '
        'lblAmtKHR
        '
        Me.lblAmtKHR.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAmtKHR.AutoSize = True
        Me.lblAmtKHR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmtKHR.ForeColor = System.Drawing.SystemColors.InfoText
        Me.lblAmtKHR.Location = New System.Drawing.Point(73, 151)
        Me.lblAmtKHR.Name = "lblAmtKHR"
        Me.lblAmtKHR.Size = New System.Drawing.Size(19, 20)
        Me.lblAmtKHR.TabIndex = 52
        Me.lblAmtKHR.Text = "0"
        '
        'txtChange
        '
        Me.txtChange.Enabled = False
        Me.txtChange.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChange.Location = New System.Drawing.Point(137, 97)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(153, 28)
        Me.txtChange.TabIndex = 51
        '
        'txtPaid
        '
        Me.txtPaid.Enabled = False
        Me.txtPaid.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaid.Location = New System.Drawing.Point(137, 64)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.Size = New System.Drawing.Size(153, 28)
        Me.txtPaid.TabIndex = 50
        '
        'txtAmtDue
        '
        Me.txtAmtDue.Enabled = False
        Me.txtAmtDue.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtDue.Location = New System.Drawing.Point(136, 31)
        Me.txtAmtDue.Name = "txtAmtDue"
        Me.txtAmtDue.Size = New System.Drawing.Size(153, 28)
        Me.txtAmtDue.TabIndex = 49
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label10.Location = New System.Drawing.Point(115, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = ":"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label9.Location = New System.Drawing.Point(115, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = ":"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label8.Location = New System.Drawing.Point(12, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 20)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Change"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label7.Location = New System.Drawing.Point(13, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 20)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Paid"
        '
        'dg_Payment
        '
        Me.dg_Payment.AllowUserToAddRows = False
        Me.dg_Payment.AllowUserToDeleteRows = False
        Me.dg_Payment.AllowUserToResizeColumns = False
        Me.dg_Payment.AllowUserToResizeRows = False
        Me.dg_Payment.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dg_Payment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_Payment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dg_Payment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_Payment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dg_Payment.ColumnHeadersHeight = 20
        Me.dg_Payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg_Payment.ColumnHeadersVisible = False
        Me.dg_Payment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PAY_METHOD, Me.BANK, Me.REC_AMT})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_Payment.DefaultCellStyle = DataGridViewCellStyle9
        Me.dg_Payment.GridColor = System.Drawing.SystemColors.Control
        Me.dg_Payment.Location = New System.Drawing.Point(301, 32)
        Me.dg_Payment.Name = "dg_Payment"
        Me.dg_Payment.ReadOnly = True
        Me.dg_Payment.RowHeadersVisible = False
        Me.dg_Payment.RowTemplate.Height = 30
        Me.dg_Payment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_Payment.Size = New System.Drawing.Size(209, 60)
        Me.dg_Payment.TabIndex = 44
        '
        'PAY_METHOD
        '
        Me.PAY_METHOD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAY_METHOD.DefaultCellStyle = DataGridViewCellStyle8
        Me.PAY_METHOD.HeaderText = "Payment Method"
        Me.PAY_METHOD.Name = "PAY_METHOD"
        Me.PAY_METHOD.ReadOnly = True
        Me.PAY_METHOD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BANK
        '
        Me.BANK.HeaderText = "Bank"
        Me.BANK.Name = "BANK"
        Me.BANK.ReadOnly = True
        Me.BANK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'REC_AMT
        '
        Me.REC_AMT.HeaderText = "Amount"
        Me.REC_AMT.Name = "REC_AMT"
        Me.REC_AMT.ReadOnly = True
        Me.REC_AMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label4.Location = New System.Drawing.Point(10, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Amount Due : "
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label3.Location = New System.Drawing.Point(65, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Net Total :"
        '
        'txtNetTotal
        '
        Me.txtNetTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNetTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtNetTotal.Enabled = False
        Me.txtNetTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetTotal.Location = New System.Drawing.Point(155, 149)
        Me.txtNetTotal.Name = "txtNetTotal"
        Me.txtNetTotal.ReadOnly = True
        Me.txtNetTotal.Size = New System.Drawing.Size(210, 21)
        Me.txtNetTotal.TabIndex = 40
        Me.txtNetTotal.TabStop = False
        Me.txtNetTotal.Text = "0.00"
        Me.txtNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label2.Location = New System.Drawing.Point(68, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Sub Total : "
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(155, 38)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(210, 21)
        Me.txtSubTotal.TabIndex = 38
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(155, 9)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ReadOnly = True
        Me.txtQuantity.Size = New System.Drawing.Size(210, 21)
        Me.txtQuantity.TabIndex = 36
        Me.txtQuantity.TabStop = False
        Me.txtQuantity.Text = "0.00"
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label41.Location = New System.Drawing.Point(42, 14)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(103, 15)
        Me.Label41.TabIndex = 37
        Me.Label41.Text = "Total Quantity :"
        '
        'txtCheckDiscountAmt
        '
        Me.txtCheckDiscountAmt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCheckDiscountAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckDiscountAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckDiscountAmt.Location = New System.Drawing.Point(155, 67)
        Me.txtCheckDiscountAmt.Name = "txtCheckDiscountAmt"
        Me.txtCheckDiscountAmt.Size = New System.Drawing.Size(89, 21)
        Me.txtCheckDiscountAmt.TabIndex = 30
        Me.txtCheckDiscountAmt.TabStop = False
        Me.txtCheckDiscountAmt.Text = "0.00"
        Me.txtCheckDiscountAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label6.Location = New System.Drawing.Point(29, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Check Discount :"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label13.Location = New System.Drawing.Point(98, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 15)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = " VAT :"
        '
        'txtShippingFee
        '
        Me.txtShippingFee.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtShippingFee.BackColor = System.Drawing.SystemColors.Window
        Me.txtShippingFee.Enabled = False
        Me.txtShippingFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShippingFee.Location = New System.Drawing.Point(155, 121)
        Me.txtShippingFee.Name = "txtShippingFee"
        Me.txtShippingFee.ReadOnly = True
        Me.txtShippingFee.Size = New System.Drawing.Size(118, 21)
        Me.txtShippingFee.TabIndex = 32
        Me.txtShippingFee.TabStop = False
        Me.txtShippingFee.Text = "0.00"
        Me.txtShippingFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label38.Location = New System.Drawing.Point(44, 126)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(96, 15)
        Me.Label38.TabIndex = 33
        Me.Label38.Text = "Shpping Fee :"
        '
        'txtVat
        '
        Me.txtVat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtVat.BackColor = System.Drawing.SystemColors.Window
        Me.txtVat.Enabled = False
        Me.txtVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVat.Location = New System.Drawing.Point(155, 94)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.ReadOnly = True
        Me.txtVat.Size = New System.Drawing.Size(89, 21)
        Me.txtVat.TabIndex = 34
        Me.txtVat.TabStop = False
        Me.txtVat.Text = "0.00"
        Me.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCasheri
        '
        Me.lblCasheri.AutoSize = True
        Me.lblCasheri.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCasheri.Location = New System.Drawing.Point(499, 10)
        Me.lblCasheri.Name = "lblCasheri"
        Me.lblCasheri.Size = New System.Drawing.Size(50, 16)
        Me.lblCasheri.TabIndex = 186
        Me.lblCasheri.Text = "Casheir "
        '
        'lblStroe
        '
        Me.lblStroe.AutoSize = True
        Me.lblStroe.Font = New System.Drawing.Font("Microsoft Tai Le", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStroe.Location = New System.Drawing.Point(500, 39)
        Me.lblStroe.Name = "lblStroe"
        Me.lblStroe.Size = New System.Drawing.Size(38, 16)
        Me.lblStroe.TabIndex = 187
        Me.lblStroe.Text = "Store"
        '
        'frm_pos_sell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dg_Items)
        Me.Controls.Add(Me.Panel_TitleBar)
        Me.Name = "frm_pos_sell"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel_TitleBar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg_Payment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel_TitleBar As Panel
    Friend WithEvents btn_Maximize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Minimize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Exit As FontAwesome.Sharp.IconButton
    Friend WithEvents btnHome As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSell As FontAwesome.Sharp.IconButton
    Friend WithEvents btnSetting As FontAwesome.Sharp.IconButton
    Friend WithEvents btnLogout As FontAwesome.Sharp.IconButton
    Friend WithEvents dg_Items As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpInvoiceDate As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblBarcode As Label
    Friend WithEvents btnItemCode As FontAwesome.Sharp.IconButton
    Friend WithEvents txt_Barcode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnDriver As FontAwesome.Sharp.IconButton
    Friend WithEvents btnVoide As FontAwesome.Sharp.IconButton
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtCheckDiscountAmt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtShippingFee As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txtVat As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNetTotal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnQRCode As FontAwesome.Sharp.IconButton
    Friend WithEvents btnVisa As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCash As FontAwesome.Sharp.IconButton
    Friend WithEvents txtPercentage As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnClear As FontAwesome.Sharp.IconButton
    Friend WithEvents btnClostingReport As FontAwesome.Sharp.IconButton
    Friend WithEvents i_Line As DataGridViewTextBoxColumn
    Friend WithEvents i_ITEMNO As DataGridViewTextBoxColumn
    Friend WithEvents i_DESC As DataGridViewTextBoxColumn
    Friend WithEvents i_Qty As DataGridViewTextBoxColumn
    Friend WithEvents i_Price As DataGridViewTextBoxColumn
    Friend WithEvents i_Uom As DataGridViewTextBoxColumn
    Friend WithEvents i_DisPct As DataGridViewTextBoxColumn
    Friend WithEvents i_DisAmt As DataGridViewTextBoxColumn
    Friend WithEvents i_NetAmt As DataGridViewTextBoxColumn
    Friend WithEvents btnPay As FontAwesome.Sharp.IconButton
    Friend WithEvents btnMasterCard As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAlipay As FontAwesome.Sharp.IconButton
    Friend WithEvents btnUnionpay As FontAwesome.Sharp.IconButton
    Friend WithEvents btnAMEX As FontAwesome.Sharp.IconButton
    Friend WithEvents btnJCB As FontAwesome.Sharp.IconButton
    Friend WithEvents btnWechat As FontAwesome.Sharp.IconButton
    Friend WithEvents Label7 As Label
    Friend WithEvents dg_Payment As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtChange As TextBox
    Friend WithEvents txtPaid As TextBox
    Friend WithEvents txtAmtDue As TextBox
    Friend WithEvents btnTHB As FontAwesome.Sharp.IconButton
    Friend WithEvents btnKHR As FontAwesome.Sharp.IconButton
    Friend WithEvents lblAmtTHB As Label
    Friend WithEvents lblAmtKHR As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cbNonVat As CheckBox
    Friend WithEvents PAY_METHOD As DataGridViewTextBoxColumn
    Friend WithEvents BANK As DataGridViewTextBoxColumn
    Friend WithEvents REC_AMT As DataGridViewTextBoxColumn
    Friend WithEvents Label14 As Label
    Friend WithEvents txtKHRRate As TextBox
    Friend WithEvents txtTHBRate As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnShppingFee As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCOD As FontAwesome.Sharp.IconButton
    Friend WithEvents lblDeliveryName As Label
    Friend WithEvents lblDelivery As Label
    Friend WithEvents lblStroe As Label
    Friend WithEvents lblCasheri As Label
End Class
