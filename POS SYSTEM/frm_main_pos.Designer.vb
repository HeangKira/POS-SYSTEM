<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main_pos
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlAddress = New System.Windows.Forms.Panel()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblTypeUser = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnItemCode = New FontAwesome.Sharp.IconButton()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.Panel_TitleBar = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btn_Maximize = New FontAwesome.Sharp.IconButton()
        Me.btn_Minimize = New FontAwesome.Sharp.IconButton()
        Me.btn_Exit = New FontAwesome.Sharp.IconButton()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.btnClear = New FontAwesome.Sharp.IconButton()
        Me.btnSetting = New FontAwesome.Sharp.IconButton()
        Me.pnldgt = New System.Windows.Forms.Panel()
        Me.dg_Items = New System.Windows.Forms.DataGridView()
        Me.i_Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_ITEMNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Uom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_Amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DisPct = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_DisAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_NetAmt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_BARCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txt_Quantity = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Total_Discount_VAT = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txt_Total_Lin_Discount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Total_Global_Discount = New System.Windows.Forms.TextBox()
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.btnChangeQty = New FontAwesome.Sharp.IconButton()
        Me.btnCheckDiscount = New FontAwesome.Sharp.IconButton()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.btnRemove = New FontAwesome.Sharp.IconButton()
        Me.pnlAddress.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel_TitleBar.SuspendLayout()
        Me.pnl.SuspendLayout()
        Me.pnldgt.SuspendLayout()
        CType(Me.dg_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotal.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAddress
        '
        Me.pnlAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pnlAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAddress.Controls.Add(Me.lblCompanyName)
        Me.pnlAddress.Controls.Add(Me.picLogo)
        Me.pnlAddress.Controls.Add(Me.lblTypeUser)
        Me.pnlAddress.Controls.Add(Me.lblUser)
        Me.pnlAddress.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlAddress.Location = New System.Drawing.Point(2, 32)
        Me.pnlAddress.Name = "pnlAddress"
        Me.pnlAddress.Size = New System.Drawing.Size(504, 114)
        Me.pnlAddress.TabIndex = 1
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Location = New System.Drawing.Point(132, 3)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(324, 65)
        Me.lblCompanyName.TabIndex = 3
        Me.lblCompanyName.Text = "Positron Multiverse Co., Ltd   " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Borey New World,#74 Street 01A, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sangkat Krang " &
    "Thnong,Phnom Penh, Cambodia" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tel: +855 23 884 242 | Hotline: +855 17 222 009 & +" &
    "855 16 422 242" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'picLogo
        '
        Me.picLogo.Location = New System.Drawing.Point(1, 0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(125, 113)
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'lblTypeUser
        '
        Me.lblTypeUser.AutoSize = True
        Me.lblTypeUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblTypeUser.Location = New System.Drawing.Point(323, 94)
        Me.lblTypeUser.Name = "lblTypeUser"
        Me.lblTypeUser.Size = New System.Drawing.Size(73, 13)
        Me.lblTypeUser.TabIndex = 1
        Me.lblTypeUser.Text = "Type User :"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblUser.Location = New System.Drawing.Point(136, 94)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(41, 13)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "User :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnItemCode)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.dtpDate)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.lblItemName)
        Me.Panel1.Controls.Add(Me.lblItemCode)
        Me.Panel1.Controls.Add(Me.lblBarcode)
        Me.Panel1.Controls.Add(Me.lblInvoice)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Location = New System.Drawing.Point(512, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 114)
        Me.Panel1.TabIndex = 2
        '
        'btnItemCode
        '
        Me.btnItemCode.BackColor = System.Drawing.Color.White
        Me.btnItemCode.FlatAppearance.BorderSize = 0
        Me.btnItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItemCode.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemCode.ForeColor = System.Drawing.Color.Black
        Me.btnItemCode.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass
        Me.btnItemCode.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnItemCode.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnItemCode.IconSize = 19
        Me.btnItemCode.Location = New System.Drawing.Point(223, 51)
        Me.btnItemCode.Name = "btnItemCode"
        Me.btnItemCode.Size = New System.Drawing.Size(27, 17)
        Me.btnItemCode.TabIndex = 177
        Me.btnItemCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnItemCode.UseVisualStyleBackColor = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(329, 5)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(42, 13)
        Me.lblDate.TabIndex = 10
        Me.lblDate.Text = "Date :"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(377, 1)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(112, 20)
        Me.dtpDate.TabIndex = 9
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(82, 77)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(230, 20)
        Me.TextBox3.TabIndex = 8
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(82, 50)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(169, 20)
        Me.TextBox2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(81, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(209, 20)
        Me.TextBox1.TabIndex = 6
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblItemName.Location = New System.Drawing.Point(7, 81)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(75, 13)
        Me.lblItemName.TabIndex = 5
        Me.lblItemName.Text = "Item Name :"
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblItemCode.Location = New System.Drawing.Point(7, 54)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(72, 13)
        Me.lblItemCode.TabIndex = 2
        Me.lblItemCode.Text = "Item Code :"
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblBarcode.Location = New System.Drawing.Point(7, 28)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(62, 13)
        Me.lblBarcode.TabIndex = 1
        Me.lblBarcode.Text = "Barcode :"
        '
        'lblInvoice
        '
        Me.lblInvoice.AutoSize = True
        Me.lblInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.lblInvoice.Location = New System.Drawing.Point(7, 4)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(69, 13)
        Me.lblInvoice.TabIndex = 0
        Me.lblInvoice.Text = "Invoice # :"
        '
        'Panel_TitleBar
        '
        Me.Panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel_TitleBar.Controls.Add(Me.lblTitle)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Maximize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Minimize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Exit)
        Me.Panel_TitleBar.Location = New System.Drawing.Point(2, 1)
        Me.Panel_TitleBar.Name = "Panel_TitleBar"
        Me.Panel_TitleBar.Size = New System.Drawing.Size(1003, 30)
        Me.Panel_TitleBar.TabIndex = 4
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Tai Le", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(10, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(189, 19)
        Me.lblTitle.TabIndex = 25
        Me.lblTitle.Text = "POS System Base Of Sales"
        '
        'btn_Maximize
        '
        Me.btn_Maximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Maximize.FlatAppearance.BorderSize = 0
        Me.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Maximize.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Maximize.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Maximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.btn_Maximize.IconColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(9, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btn_Maximize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Maximize.IconSize = 27
        Me.btn_Maximize.Location = New System.Drawing.Point(926, 3)
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
        Me.btn_Minimize.IconColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(9, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btn_Minimize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Minimize.IconSize = 27
        Me.btn_Minimize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Minimize.Location = New System.Drawing.Point(890, 3)
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
        Me.btn_Exit.IconColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(9, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btn_Exit.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Exit.IconSize = 27
        Me.btn_Exit.Location = New System.Drawing.Point(962, 3)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(30, 24)
        Me.btn_Exit.TabIndex = 22
        Me.btn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.pnl.Controls.Add(Me.IconButton1)
        Me.pnl.Controls.Add(Me.btnClear)
        Me.pnl.Controls.Add(Me.btnSetting)
        Me.pnl.Location = New System.Drawing.Point(2, 147)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(1003, 41)
        Me.pnl.TabIndex = 5
        '
        'IconButton1
        '
        Me.IconButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.Black
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.Recycle
        Me.IconButton1.IconColor = System.Drawing.Color.Red
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 27
        Me.IconButton1.Location = New System.Drawing.Point(569, 5)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(102, 31)
        Me.IconButton1.TabIndex = 28
        Me.IconButton1.Text = "Add"
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.IconChar = FontAwesome.Sharp.IconChar.Recycle
        Me.btnClear.IconColor = System.Drawing.Color.Red
        Me.btnClear.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnClear.IconSize = 27
        Me.btnClear.Location = New System.Drawing.Point(431, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(102, 31)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSetting
        '
        Me.btnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetting.FlatAppearance.BorderSize = 0
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetting.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.ForeColor = System.Drawing.Color.Black
        Me.btnSetting.IconChar = FontAwesome.Sharp.IconChar.Cog
        Me.btnSetting.IconColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.btnSetting.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnSetting.IconSize = 27
        Me.btnSetting.Location = New System.Drawing.Point(884, 5)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(102, 31)
        Me.btnSetting.TabIndex = 26
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'pnldgt
        '
        Me.pnldgt.Controls.Add(Me.dg_Items)
        Me.pnldgt.Location = New System.Drawing.Point(2, 189)
        Me.pnldgt.Name = "pnldgt"
        Me.pnldgt.Size = New System.Drawing.Size(740, 201)
        Me.pnldgt.TabIndex = 6
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
        Me.dg_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.i_Line, Me.i_ITEMNO, Me.i_DESC, Me.i_Qty, Me.i_Price, Me.i_Uom, Me.i_Amt, Me.i_DisPct, Me.i_DisAmt, Me.i_NetAmt, Me.i_BARCODE})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_Items.DefaultCellStyle = DataGridViewCellStyle9
        Me.dg_Items.EnableHeadersVisualStyles = False
        Me.dg_Items.GridColor = System.Drawing.SystemColors.Control
        Me.dg_Items.Location = New System.Drawing.Point(8, 5)
        Me.dg_Items.Name = "dg_Items"
        Me.dg_Items.ReadOnly = True
        Me.dg_Items.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dg_Items.RowHeadersVisible = False
        Me.dg_Items.RowHeadersWidth = 50
        Me.dg_Items.RowTemplate.Height = 40
        Me.dg_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dg_Items.ShowEditingIcon = False
        Me.dg_Items.Size = New System.Drawing.Size(729, 296)
        Me.dg_Items.TabIndex = 1
        '
        'i_Line
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.i_Line.DefaultCellStyle = DataGridViewCellStyle2
        Me.i_Line.HeaderText = "Line"
        Me.i_Line.MinimumWidth = 40
        Me.i_Line.Name = "i_Line"
        Me.i_Line.ReadOnly = True
        Me.i_Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Line.Width = 40
        '
        'i_ITEMNO
        '
        Me.i_ITEMNO.HeaderText = "Item No"
        Me.i_ITEMNO.MinimumWidth = 200
        Me.i_ITEMNO.Name = "i_ITEMNO"
        Me.i_ITEMNO.ReadOnly = True
        Me.i_ITEMNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_ITEMNO.Width = 200
        '
        'i_DESC
        '
        Me.i_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.i_DESC.HeaderText = "Description"
        Me.i_DESC.MinimumWidth = 200
        Me.i_DESC.Name = "i_DESC"
        Me.i_DESC.ReadOnly = True
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
        Me.i_Qty.ReadOnly = True
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
        Me.i_Price.ReadOnly = True
        Me.i_Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Price.Width = 60
        '
        'i_Uom
        '
        Me.i_Uom.HeaderText = "UOM"
        Me.i_Uom.MinimumWidth = 60
        Me.i_Uom.Name = "i_Uom"
        Me.i_Uom.ReadOnly = True
        Me.i_Uom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Uom.Visible = False
        Me.i_Uom.Width = 60
        '
        'i_Amt
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_Amt.DefaultCellStyle = DataGridViewCellStyle5
        Me.i_Amt.HeaderText = "Sub Total($)"
        Me.i_Amt.MinimumWidth = 90
        Me.i_Amt.Name = "i_Amt"
        Me.i_Amt.ReadOnly = True
        Me.i_Amt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_Amt.Width = 90
        '
        'i_DisPct
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_DisPct.DefaultCellStyle = DataGridViewCellStyle6
        Me.i_DisPct.HeaderText = "Discount (%)"
        Me.i_DisPct.MinimumWidth = 90
        Me.i_DisPct.Name = "i_DisPct"
        Me.i_DisPct.ReadOnly = True
        Me.i_DisPct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.i_DisPct.Width = 90
        '
        'i_DisAmt
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_DisAmt.DefaultCellStyle = DataGridViewCellStyle7
        Me.i_DisAmt.HeaderText = "Discount ($)"
        Me.i_DisAmt.MinimumWidth = 100
        Me.i_DisAmt.Name = "i_DisAmt"
        Me.i_DisAmt.ReadOnly = True
        '
        'i_NetAmt
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0"
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.i_NetAmt.DefaultCellStyle = DataGridViewCellStyle8
        Me.i_NetAmt.HeaderText = "Sub Total1 ($)"
        Me.i_NetAmt.MinimumWidth = 120
        Me.i_NetAmt.Name = "i_NetAmt"
        Me.i_NetAmt.ReadOnly = True
        Me.i_NetAmt.Width = 120
        '
        'i_BARCODE
        '
        Me.i_BARCODE.HeaderText = "BARCODE"
        Me.i_BARCODE.MinimumWidth = 100
        Me.i_BARCODE.Name = "i_BARCODE"
        Me.i_BARCODE.ReadOnly = True
        Me.i_BARCODE.Visible = False
        '
        'Label41
        '
        Me.Label41.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label41.Location = New System.Drawing.Point(83, 17)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(103, 15)
        Me.Label41.TabIndex = 29
        Me.Label41.Text = "Total Quantity :"
        '
        'txt_Quantity
        '
        Me.txt_Quantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Quantity.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Quantity.Location = New System.Drawing.Point(210, 12)
        Me.txt_Quantity.Name = "txt_Quantity"
        Me.txt_Quantity.ReadOnly = True
        Me.txt_Quantity.Size = New System.Drawing.Size(200, 21)
        Me.txt_Quantity.TabIndex = 28
        Me.txt_Quantity.TabStop = False
        Me.txt_Quantity.Text = "0.00"
        Me.txt_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label13.Location = New System.Drawing.Point(88, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 15)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Discount VAT :"
        Me.Label13.Visible = False
        '
        'txt_Total_Discount_VAT
        '
        Me.txt_Total_Discount_VAT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Total_Discount_VAT.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Total_Discount_VAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Total_Discount_VAT.Location = New System.Drawing.Point(210, 93)
        Me.txt_Total_Discount_VAT.Name = "txt_Total_Discount_VAT"
        Me.txt_Total_Discount_VAT.ReadOnly = True
        Me.txt_Total_Discount_VAT.Size = New System.Drawing.Size(200, 21)
        Me.txt_Total_Discount_VAT.TabIndex = 25
        Me.txt_Total_Discount_VAT.TabStop = False
        Me.txt_Total_Discount_VAT.Text = "0.00"
        Me.txt_Total_Discount_VAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Total_Discount_VAT.Visible = False
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label38.Location = New System.Drawing.Point(61, 44)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(125, 15)
        Me.Label38.TabIndex = 23
        Me.Label38.Text = "Line Discount ($) :"
        '
        'txt_Total_Lin_Discount
        '
        Me.txt_Total_Lin_Discount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Total_Lin_Discount.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Total_Lin_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Total_Lin_Discount.Location = New System.Drawing.Point(210, 39)
        Me.txt_Total_Lin_Discount.Name = "txt_Total_Lin_Discount"
        Me.txt_Total_Lin_Discount.ReadOnly = True
        Me.txt_Total_Lin_Discount.Size = New System.Drawing.Size(200, 21)
        Me.txt_Total_Lin_Discount.TabIndex = 22
        Me.txt_Total_Lin_Discount.TabStop = False
        Me.txt_Total_Lin_Discount.Text = "0.00"
        Me.txt_Total_Lin_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label6.Location = New System.Drawing.Point(45, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Global Discount ($) :"
        '
        'txt_Total_Global_Discount
        '
        Me.txt_Total_Global_Discount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_Total_Global_Discount.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Total_Global_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Total_Global_Discount.Location = New System.Drawing.Point(210, 66)
        Me.txt_Total_Global_Discount.Name = "txt_Total_Global_Discount"
        Me.txt_Total_Global_Discount.ReadOnly = True
        Me.txt_Total_Global_Discount.Size = New System.Drawing.Size(200, 21)
        Me.txt_Total_Global_Discount.TabIndex = 1
        Me.txt_Total_Global_Discount.TabStop = False
        Me.txt_Total_Global_Discount.Text = "0.00"
        Me.txt_Total_Global_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.pnlTotal.Controls.Add(Me.txt_Quantity)
        Me.pnlTotal.Controls.Add(Me.Label41)
        Me.pnlTotal.Controls.Add(Me.txt_Total_Global_Discount)
        Me.pnlTotal.Controls.Add(Me.Label6)
        Me.pnlTotal.Controls.Add(Me.Label13)
        Me.pnlTotal.Controls.Add(Me.txt_Total_Lin_Discount)
        Me.pnlTotal.Controls.Add(Me.Label38)
        Me.pnlTotal.Controls.Add(Me.txt_Total_Discount_VAT)
        Me.pnlTotal.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlTotal.Location = New System.Drawing.Point(3, 508)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(736, 137)
        Me.pnlTotal.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnCheckDiscount)
        Me.Panel2.Controls.Add(Me.IconButton4)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.IconButton3)
        Me.Panel2.Controls.Add(Me.IconButton2)
        Me.Panel2.Controls.Add(Me.btnChangeQty)
        Me.Panel2.Location = New System.Drawing.Point(748, 191)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 538)
        Me.Panel2.TabIndex = 31
        '
        'IconButton3
        '
        Me.IconButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton3.FlatAppearance.BorderSize = 0
        Me.IconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.White
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.IconButton3.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 40
        Me.IconButton3.Location = New System.Drawing.Point(19, 122)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(102, 77)
        Me.IconButton3.TabIndex = 31
        Me.IconButton3.Text = "Change Quantiy"
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'IconButton2
        '
        Me.IconButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.White
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.Remove
        Me.IconButton2.IconColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 40
        Me.IconButton2.Location = New System.Drawing.Point(142, 15)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(102, 77)
        Me.IconButton2.TabIndex = 30
        Me.IconButton2.Text = "Remove Item"
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'btnChangeQty
        '
        Me.btnChangeQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeQty.FlatAppearance.BorderSize = 0
        Me.btnChangeQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeQty.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeQty.ForeColor = System.Drawing.Color.White
        Me.btnChangeQty.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.btnChangeQty.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnChangeQty.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnChangeQty.IconSize = 40
        Me.btnChangeQty.Location = New System.Drawing.Point(19, 15)
        Me.btnChangeQty.Name = "btnChangeQty"
        Me.btnChangeQty.Size = New System.Drawing.Size(102, 77)
        Me.btnChangeQty.TabIndex = 29
        Me.btnChangeQty.Text = "Change Quantiy"
        Me.btnChangeQty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnChangeQty.UseVisualStyleBackColor = True
        '
        'btnCheckDiscount
        '
        Me.btnCheckDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCheckDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnCheckDiscount.FlatAppearance.BorderSize = 0
        Me.btnCheckDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckDiscount.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckDiscount.ForeColor = System.Drawing.Color.Black
        Me.btnCheckDiscount.IconChar = FontAwesome.Sharp.IconChar.Percentage
        Me.btnCheckDiscount.IconColor = System.Drawing.Color.Black
        Me.btnCheckDiscount.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnCheckDiscount.IconSize = 25
        Me.btnCheckDiscount.Location = New System.Drawing.Point(31, 402)
        Me.btnCheckDiscount.Name = "btnCheckDiscount"
        Me.btnCheckDiscount.Size = New System.Drawing.Size(101, 58)
        Me.btnCheckDiscount.TabIndex = 38
        Me.btnCheckDiscount.Text = "CHECK DISCOUNT"
        Me.btnCheckDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCheckDiscount.UseVisualStyleBackColor = False
        Me.btnCheckDiscount.Visible = False
        '
        'IconButton4
        '
        Me.IconButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.IconButton4.FlatAppearance.BorderSize = 0
        Me.IconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton4.ForeColor = System.Drawing.Color.Black
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.IconButton4.IconColor = System.Drawing.Color.Black
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.IconSize = 25
        Me.IconButton4.Location = New System.Drawing.Point(31, 241)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(101, 58)
        Me.IconButton4.TabIndex = 36
        Me.IconButton4.Text = "CHANGE QUANTIY"
        Me.IconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton4.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnRemove.FlatAppearance.BorderSize = 0
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.IconChar = FontAwesome.Sharp.IconChar.Recycle
        Me.btnRemove.IconColor = System.Drawing.Color.Black
        Me.btnRemove.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnRemove.IconSize = 25
        Me.btnRemove.Location = New System.Drawing.Point(138, 241)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(101, 58)
        Me.btnRemove.TabIndex = 37
        Me.btnRemove.Text = "REMOVE ITEM"
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'frm_main_pos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlTotal)
        Me.Controls.Add(Me.pnldgt)
        Me.Controls.Add(Me.pnl)
        Me.Controls.Add(Me.Panel_TitleBar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlAddress)
        Me.Name = "frm_main_pos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS SYSTEM"
        Me.pnlAddress.ResumeLayout(False)
        Me.pnlAddress.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel_TitleBar.ResumeLayout(False)
        Me.Panel_TitleBar.PerformLayout()
        Me.pnl.ResumeLayout(False)
        Me.pnldgt.ResumeLayout(False)
        CType(Me.dg_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotal.ResumeLayout(False)
        Me.pnlTotal.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAddress As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel_TitleBar As Panel
    Friend WithEvents btn_Maximize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Minimize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Exit As FontAwesome.Sharp.IconButton
    Friend WithEvents lblTitle As Label
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblTypeUser As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents lblInvoice As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblItemCode As Label
    Friend WithEvents lblBarcode As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents btnItemCode As FontAwesome.Sharp.IconButton
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents pnl As Panel
    Friend WithEvents btnSetting As FontAwesome.Sharp.IconButton
    Friend WithEvents btnClear As FontAwesome.Sharp.IconButton
    Friend WithEvents pnldgt As Panel
    Friend WithEvents dg_Items As DataGridView
    Friend WithEvents i_Line As DataGridViewTextBoxColumn
    Friend WithEvents i_ITEMNO As DataGridViewTextBoxColumn
    Friend WithEvents i_DESC As DataGridViewTextBoxColumn
    Friend WithEvents i_Qty As DataGridViewTextBoxColumn
    Friend WithEvents i_Price As DataGridViewTextBoxColumn
    Friend WithEvents i_Uom As DataGridViewTextBoxColumn
    Friend WithEvents i_Amt As DataGridViewTextBoxColumn
    Friend WithEvents i_DisPct As DataGridViewTextBoxColumn
    Friend WithEvents i_DisAmt As DataGridViewTextBoxColumn
    Friend WithEvents i_NetAmt As DataGridViewTextBoxColumn
    Friend WithEvents i_BARCODE As DataGridViewTextBoxColumn
    Friend WithEvents Label41 As Label
    Friend WithEvents txt_Quantity As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_Total_Discount_VAT As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txt_Total_Lin_Discount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_Total_Global_Discount As TextBox
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents pnlTotal As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnChangeQty As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents btnCheckDiscount As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents btnRemove As FontAwesome.Sharp.IconButton
End Class
