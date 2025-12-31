<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_screen_user
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel_Top = New System.Windows.Forms.Panel()
        Me.Panel_Welcom = New System.Windows.Forms.Panel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel_Sub_Total = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalRiel = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtTotalBard = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtTotalQty = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtTotalUSD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlItemDetail = New System.Windows.Forms.Panel()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Panel_Welcom.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel_Sub_Total.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Top
        '
        Me.Panel_Top.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(800, 10)
        Me.Panel_Top.TabIndex = 1
        '
        'Panel_Welcom
        '
        Me.Panel_Welcom.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel_Welcom.Controls.Add(Me.Guna2Panel1)
        Me.Panel_Welcom.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Welcom.Location = New System.Drawing.Point(0, 10)
        Me.Panel_Welcom.Name = "Panel_Welcom"
        Me.Panel_Welcom.Size = New System.Drawing.Size(800, 58)
        Me.Panel_Welcom.TabIndex = 5
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Guna2Panel1.BorderThickness = 1
        Me.Guna2Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.Guna2Panel1.Location = New System.Drawing.Point(30, 8)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(741, 39)
        Me.Guna2Panel1.TabIndex = 1
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(26, 7)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(339, 27)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "WELCOME TO POSITRON STORE"
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.POS_SYSTEM.My.Resources.Resources.pi
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.pnlItemDetail)
        Me.Panel1.Controls.Add(Me.Panel_Sub_Total)
        Me.Panel1.Location = New System.Drawing.Point(0, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 386)
        Me.Panel1.TabIndex = 6
        '
        'Panel_Sub_Total
        '
        Me.Panel_Sub_Total.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Sub_Total.Controls.Add(Me.Label4)
        Me.Panel_Sub_Total.Controls.Add(Me.Label3)
        Me.Panel_Sub_Total.Controls.Add(Me.Label2)
        Me.Panel_Sub_Total.Controls.Add(Me.Label5)
        Me.Panel_Sub_Total.Controls.Add(Me.txtTotalRiel)
        Me.Panel_Sub_Total.Controls.Add(Me.txtTotalBard)
        Me.Panel_Sub_Total.Controls.Add(Me.txtTotalQty)
        Me.Panel_Sub_Total.Controls.Add(Me.txtTotalUSD)
        Me.Panel_Sub_Total.Controls.Add(Me.Label15)
        Me.Panel_Sub_Total.Location = New System.Drawing.Point(500, 0)
        Me.Panel_Sub_Total.Name = "Panel_Sub_Total"
        Me.Panel_Sub_Total.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel_Sub_Total.Size = New System.Drawing.Size(297, 386)
        Me.Panel_Sub_Total.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(18, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(181, 18)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Thank you for coming !"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 18)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Total Bard :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 18)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Total Riel :"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 18)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Total USD :"
        '
        'txtTotalRiel
        '
        Me.txtTotalRiel.BorderRadius = 10
        Me.txtTotalRiel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalRiel.DefaultText = "៛0"
        Me.txtTotalRiel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalRiel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalRiel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalRiel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalRiel.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalRiel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalRiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRiel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTotalRiel.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalRiel.Location = New System.Drawing.Point(120, 67)
        Me.txtTotalRiel.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.txtTotalRiel.Name = "txtTotalRiel"
        Me.txtTotalRiel.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.txtTotalRiel.PlaceholderText = ""
        Me.txtTotalRiel.ReadOnly = True
        Me.txtTotalRiel.SelectedText = ""
        Me.txtTotalRiel.SelectionStart = 2
        Me.txtTotalRiel.Size = New System.Drawing.Size(170, 38)
        Me.txtTotalRiel.TabIndex = 45
        Me.txtTotalRiel.TabStop = False
        Me.txtTotalRiel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBard
        '
        Me.txtTotalBard.BorderRadius = 10
        Me.txtTotalBard.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBard.DefaultText = "฿0.00"
        Me.txtTotalBard.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalBard.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalBard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalBard.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalBard.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalBard.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalBard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTotalBard.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalBard.Location = New System.Drawing.Point(121, 166)
        Me.txtTotalBard.Margin = New System.Windows.Forms.Padding(10)
        Me.txtTotalBard.Name = "txtTotalBard"
        Me.txtTotalBard.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.txtTotalBard.PlaceholderText = ""
        Me.txtTotalBard.ReadOnly = True
        Me.txtTotalBard.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalBard.SelectedText = ""
        Me.txtTotalBard.Size = New System.Drawing.Size(170, 38)
        Me.txtTotalBard.TabIndex = 44
        Me.txtTotalBard.TabStop = False
        '
        'txtTotalQty
        '
        Me.txtTotalQty.BorderRadius = 10
        Me.txtTotalQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalQty.DefaultText = "0"
        Me.txtTotalQty.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalQty.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalQty.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalQty.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalQty.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalQty.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTotalQty.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalQty.Location = New System.Drawing.Point(120, 19)
        Me.txtTotalQty.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.txtTotalQty.Name = "txtTotalQty"
        Me.txtTotalQty.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.txtTotalQty.PlaceholderText = ""
        Me.txtTotalQty.ReadOnly = True
        Me.txtTotalQty.SelectedText = ""
        Me.txtTotalQty.Size = New System.Drawing.Size(170, 38)
        Me.txtTotalQty.TabIndex = 43
        Me.txtTotalQty.TabStop = False
        Me.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSD
        '
        Me.txtTotalUSD.BorderRadius = 10
        Me.txtTotalUSD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalUSD.DefaultText = "$0.00"
        Me.txtTotalUSD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTotalUSD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTotalUSD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalUSD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTotalUSD.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalUSD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTotalUSD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalUSD.Location = New System.Drawing.Point(120, 116)
        Me.txtTotalUSD.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.txtTotalUSD.Name = "txtTotalUSD"
        Me.txtTotalUSD.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        Me.txtTotalUSD.PlaceholderText = ""
        Me.txtTotalUSD.ReadOnly = True
        Me.txtTotalUSD.SelectedText = ""
        Me.txtTotalUSD.SelectionStart = 5
        Me.txtTotalUSD.Size = New System.Drawing.Size(170, 38)
        Me.txtTotalUSD.TabIndex = 42
        Me.txtTotalUSD.TabStop = False
        Me.txtTotalUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(18, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 18)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Total Qty :"
        '
        'pnlItemDetail
        '
        Me.pnlItemDetail.BackColor = System.Drawing.Color.Transparent
        Me.pnlItemDetail.Location = New System.Drawing.Point(3, 2)
        Me.pnlItemDetail.Name = "pnlItemDetail"
        Me.pnlItemDetail.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlItemDetail.Size = New System.Drawing.Size(491, 381)
        Me.pnlItemDetail.TabIndex = 51
        '
        'frm_screen_user
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel_Welcom)
        Me.Controls.Add(Me.Panel_Top)
        Me.Name = "frm_screen_user"
        Me.Text = "frm_screen_user"
        Me.Panel_Welcom.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel_Sub_Total.ResumeLayout(False)
        Me.Panel_Sub_Total.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel_Top As Panel
    Friend WithEvents Panel_Welcom As Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel_Sub_Total As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalRiel As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtTotalBard As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtTotalQty As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtTotalUSD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents pnlItemDetail As Panel
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
