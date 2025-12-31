<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_login))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_UserID = New Guna.UI2.WinForms.Guna2TextBox()
        Me.lblForgotPassword = New System.Windows.Forms.Label()
        Me.btn_Close = New FontAwesome.Sharp.IconButton()
        Me.txt_Password = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_LogIn = New Guna.UI2.WinForms.Guna2Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(495, 444)
        Me.Panel4.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1, 196)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(493, 46)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "POS SYSTEM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txt_UserID)
        Me.Panel1.Controls.Add(Me.lblForgotPassword)
        Me.Panel1.Controls.Add(Me.btn_Close)
        Me.Panel1.Controls.Add(Me.txt_Password)
        Me.Panel1.Controls.Add(Me.btn_LogIn)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(495, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 49, 0, 0)
        Me.Panel1.Size = New System.Drawing.Size(501, 444)
        Me.Panel1.TabIndex = 20
        '
        'txt_UserID
        '
        Me.txt_UserID.BorderRadius = 15
        Me.txt_UserID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_UserID.DefaultText = "ID01"
        Me.txt_UserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_UserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_UserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_UserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_UserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txt_UserID.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_UserID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.txt_UserID.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_UserID.IconLeft = CType(resources.GetObject("txt_UserID.IconLeft"), System.Drawing.Image)
        Me.txt_UserID.IconLeftOffset = New System.Drawing.Point(5, 0)
        Me.txt_UserID.Location = New System.Drawing.Point(100, 127)
        Me.txt_UserID.Margin = New System.Windows.Forms.Padding(27, 7, 27, 7)
        Me.txt_UserID.Name = "txt_UserID"
        Me.txt_UserID.PlaceholderText = "User name"
        Me.txt_UserID.SelectedText = ""
        Me.txt_UserID.Size = New System.Drawing.Size(321, 43)
        Me.txt_UserID.TabIndex = 1
        Me.txt_UserID.TextOffset = New System.Drawing.Point(5, 0)
        '
        'lblForgotPassword
        '
        Me.lblForgotPassword.AutoSize = True
        Me.lblForgotPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblForgotPassword.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgotPassword.ForeColor = System.Drawing.Color.GhostWhite
        Me.lblForgotPassword.Location = New System.Drawing.Point(275, 331)
        Me.lblForgotPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblForgotPassword.Name = "lblForgotPassword"
        Me.lblForgotPassword.Size = New System.Drawing.Size(142, 15)
        Me.lblForgotPassword.TabIndex = 18
        Me.lblForgotPassword.Text = "Forgot Password"
        '
        'btn_Close
        '
        Me.btn_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Close.FlatAppearance.BorderSize = 0
        Me.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Close.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Close.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Close.IconChar = FontAwesome.Sharp.IconChar.Remove
        Me.btn_Close.IconColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btn_Close.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Close.IconSize = 27
        Me.btn_Close.Location = New System.Drawing.Point(451, 10)
        Me.btn_Close.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(40, 37)
        Me.btn_Close.TabIndex = 17
        Me.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'txt_Password
        '
        Me.txt_Password.BorderRadius = 15
        Me.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Password.DefaultText = "123"
        Me.txt_Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txt_Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txt_Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txt_Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txt_Password.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_Password.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.txt_Password.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_Password.IconLeft = CType(resources.GetObject("txt_Password.IconLeft"), System.Drawing.Image)
        Me.txt_Password.IconLeftOffset = New System.Drawing.Point(5, 0)
        Me.txt_Password.IconRightOffset = New System.Drawing.Point(5, 0)
        Me.txt_Password.Location = New System.Drawing.Point(100, 196)
        Me.txt_Password.Margin = New System.Windows.Forms.Padding(53, 7, 53, 7)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Password.PlaceholderText = "Password"
        Me.txt_Password.SelectedText = ""
        Me.txt_Password.Size = New System.Drawing.Size(321, 43)
        Me.txt_Password.TabIndex = 2
        Me.txt_Password.TextOffset = New System.Drawing.Point(5, 0)
        '
        'btn_LogIn
        '
        Me.btn_LogIn.BorderRadius = 15
        Me.btn_LogIn.FillColor = System.Drawing.Color.SeaGreen
        Me.btn_LogIn.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_LogIn.ForeColor = System.Drawing.Color.GhostWhite
        Me.btn_LogIn.Location = New System.Drawing.Point(100, 254)
        Me.btn_LogIn.Margin = New System.Windows.Forms.Padding(27, 7, 27, 7)
        Me.btn_LogIn.Name = "btn_LogIn"
        Me.btn_LogIn.Size = New System.Drawing.Size(321, 49)
        Me.btn_LogIn.TabIndex = 3
        Me.btn_LogIn.Text = "Log in"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(0, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(501, 46)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "L O G I N"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me
        '
        'frm_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 444)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frm_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_login"
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblForgotPassword As Label
    Friend WithEvents btn_Close As FontAwesome.Sharp.IconButton
    Friend WithEvents txt_Password As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btn_LogIn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_UserID As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
