<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ChangeAmt
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel_TitleBar = New System.Windows.Forms.Panel()
        Me.btn_Exit = New FontAwesome.Sharp.IconButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_ChangeBAT = New System.Windows.Forms.Label()
        Me.lbl_ChangeKHR = New System.Windows.Forms.Label()
        Me.lbl_ChangeUSD = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel_TitleBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(8, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 29)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Payment Change"
        '
        'Panel_TitleBar
        '
        Me.Panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Panel_TitleBar.Controls.Add(Me.btn_Exit)
        Me.Panel_TitleBar.Controls.Add(Me.Label4)
        Me.Panel_TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.Panel_TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel_TitleBar.Name = "Panel_TitleBar"
        Me.Panel_TitleBar.Size = New System.Drawing.Size(655, 48)
        Me.Panel_TitleBar.TabIndex = 29
        '
        'btn_Exit
        '
        Me.btn_Exit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exit.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Exit.IconChar = FontAwesome.Sharp.IconChar.Remove
        Me.btn_Exit.IconColor = System.Drawing.SystemColors.Window
        Me.btn_Exit.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Exit.IconSize = 27
        Me.btn_Exit.Location = New System.Drawing.Point(605, 4)
        Me.btn_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(40, 37)
        Me.btn_Exit.TabIndex = 22
        Me.btn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lbl_ChangeBAT)
        Me.Panel1.Controls.Add(Me.lbl_ChangeKHR)
        Me.Panel1.Controls.Add(Me.lbl_ChangeUSD)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(655, 254)
        Me.Panel1.TabIndex = 30
        '
        'lbl_ChangeBAT
        '
        Me.lbl_ChangeBAT.AutoSize = True
        Me.lbl_ChangeBAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ChangeBAT.ForeColor = System.Drawing.Color.Black
        Me.lbl_ChangeBAT.Location = New System.Drawing.Point(260, 188)
        Me.lbl_ChangeBAT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ChangeBAT.Name = "lbl_ChangeBAT"
        Me.lbl_ChangeBAT.Size = New System.Drawing.Size(77, 36)
        Me.lbl_ChangeBAT.TabIndex = 5
        Me.lbl_ChangeBAT.Text = "BAT"
        '
        'lbl_ChangeKHR
        '
        Me.lbl_ChangeKHR.AutoSize = True
        Me.lbl_ChangeKHR.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ChangeKHR.ForeColor = System.Drawing.Color.Black
        Me.lbl_ChangeKHR.Location = New System.Drawing.Point(260, 118)
        Me.lbl_ChangeKHR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ChangeKHR.Name = "lbl_ChangeKHR"
        Me.lbl_ChangeKHR.Size = New System.Drawing.Size(81, 36)
        Me.lbl_ChangeKHR.TabIndex = 4
        Me.lbl_ChangeKHR.Text = "KHR"
        '
        'lbl_ChangeUSD
        '
        Me.lbl_ChangeUSD.AutoSize = True
        Me.lbl_ChangeUSD.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ChangeUSD.ForeColor = System.Drawing.Color.Black
        Me.lbl_ChangeUSD.Location = New System.Drawing.Point(260, 49)
        Me.lbl_ChangeUSD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ChangeUSD.Name = "lbl_ChangeUSD"
        Me.lbl_ChangeUSD.Size = New System.Drawing.Size(81, 36)
        Me.lbl_ChangeUSD.TabIndex = 2
        Me.lbl_ChangeUSD.Text = "USD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Change Amount  In:"
        '
        'frm_ChangeAmt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 298)
        Me.Controls.Add(Me.Panel_TitleBar)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm_ChangeAmt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_ChangeAmt"
        Me.Panel_TitleBar.ResumeLayout(False)
        Me.Panel_TitleBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Panel_TitleBar As Panel
    Friend WithEvents btn_Exit As FontAwesome.Sharp.IconButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_ChangeBAT As Label
    Friend WithEvents lbl_ChangeKHR As Label
    Friend WithEvents lbl_ChangeUSD As Label
    Friend WithEvents Label1 As Label
End Class
