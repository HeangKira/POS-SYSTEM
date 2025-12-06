<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reports_mgt
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
        Me.Panel_TitleBar = New System.Windows.Forms.Panel()
        Me.btn_Maximize = New FontAwesome.Sharp.IconButton()
        Me.btn_Minimize = New FontAwesome.Sharp.IconButton()
        Me.btn_Exit = New FontAwesome.Sharp.IconButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.btn_Summary_Daily_Sale = New FontAwesome.Sharp.IconButton()
        Me.Sale_Invoice_By_Payment = New FontAwesome.Sharp.IconButton()
        Me.btn_Product_Sale_Reports = New FontAwesome.Sharp.IconButton()
        Me.Panel_TitleBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_TitleBar
        '
        Me.Panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.Panel_TitleBar.Controls.Add(Me.btn_Maximize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Minimize)
        Me.Panel_TitleBar.Controls.Add(Me.btn_Exit)
        Me.Panel_TitleBar.Controls.Add(Me.Label4)
        Me.Panel_TitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.Panel_TitleBar.Name = "Panel_TitleBar"
        Me.Panel_TitleBar.Size = New System.Drawing.Size(524, 35)
        Me.Panel_TitleBar.TabIndex = 10
        '
        'btn_Maximize
        '
        Me.btn_Maximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Maximize.FlatAppearance.BorderSize = 0
        Me.btn_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Maximize.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Maximize.ForeColor = System.Drawing.Color.Gainsboro
        Me.btn_Maximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize
        Me.btn_Maximize.IconColor = System.Drawing.SystemColors.Window
        Me.btn_Maximize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Maximize.IconSize = 27
        Me.btn_Maximize.Location = New System.Drawing.Point(450, 4)
        Me.btn_Maximize.Name = "btn_Maximize"
        Me.btn_Maximize.Size = New System.Drawing.Size(30, 30)
        Me.btn_Maximize.TabIndex = 30
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
        Me.btn_Minimize.IconColor = System.Drawing.SystemColors.Window
        Me.btn_Minimize.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Minimize.IconSize = 27
        Me.btn_Minimize.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Minimize.Location = New System.Drawing.Point(413, 4)
        Me.btn_Minimize.Name = "btn_Minimize"
        Me.btn_Minimize.Size = New System.Drawing.Size(30, 30)
        Me.btn_Minimize.TabIndex = 29
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
        Me.btn_Exit.IconColor = System.Drawing.SystemColors.Window
        Me.btn_Exit.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Exit.IconSize = 27
        Me.btn_Exit.Location = New System.Drawing.Point(486, 4)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(30, 30)
        Me.btn_Exit.TabIndex = 22
        Me.btn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(21, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Closing Reports"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel1.Controls.Add(Me.IconButton1)
        Me.Panel1.Controls.Add(Me.IconButton2)
        Me.Panel1.Controls.Add(Me.IconButton3)
        Me.Panel1.Controls.Add(Me.btn_Summary_Daily_Sale)
        Me.Panel1.Controls.Add(Me.Sale_Invoice_By_Payment)
        Me.Panel1.Controls.Add(Me.btn_Product_Sale_Reports)
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(523, 213)
        Me.Panel1.TabIndex = 11
        '
        'IconButton1
        '
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.IconButton1.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 30
        Me.IconButton1.Location = New System.Drawing.Point(363, 115)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Size = New System.Drawing.Size(150, 73)
        Me.IconButton1.TabIndex = 35
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'IconButton2
        '
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.IconButton2.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 30
        Me.IconButton2.Location = New System.Drawing.Point(187, 115)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Size = New System.Drawing.Size(150, 73)
        Me.IconButton2.TabIndex = 34
        Me.IconButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'IconButton3
        '
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.IconButton3.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 30
        Me.IconButton3.Location = New System.Drawing.Point(14, 115)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(150, 73)
        Me.IconButton3.TabIndex = 33
        Me.IconButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.IconButton3.UseVisualStyleBackColor = True
        '
        'btn_Summary_Daily_Sale
        '
        Me.btn_Summary_Daily_Sale.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.btn_Summary_Daily_Sale.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btn_Summary_Daily_Sale.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Summary_Daily_Sale.IconSize = 30
        Me.btn_Summary_Daily_Sale.Location = New System.Drawing.Point(363, 18)
        Me.btn_Summary_Daily_Sale.Name = "btn_Summary_Daily_Sale"
        Me.btn_Summary_Daily_Sale.Size = New System.Drawing.Size(150, 73)
        Me.btn_Summary_Daily_Sale.TabIndex = 32
        Me.btn_Summary_Daily_Sale.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Summary_Daily_Sale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Summary_Daily_Sale.UseVisualStyleBackColor = True
        '
        'Sale_Invoice_By_Payment
        '
        Me.Sale_Invoice_By_Payment.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.Sale_Invoice_By_Payment.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Sale_Invoice_By_Payment.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.Sale_Invoice_By_Payment.IconSize = 30
        Me.Sale_Invoice_By_Payment.Location = New System.Drawing.Point(187, 18)
        Me.Sale_Invoice_By_Payment.Name = "Sale_Invoice_By_Payment"
        Me.Sale_Invoice_By_Payment.Size = New System.Drawing.Size(150, 73)
        Me.Sale_Invoice_By_Payment.TabIndex = 31
        Me.Sale_Invoice_By_Payment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Sale_Invoice_By_Payment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Sale_Invoice_By_Payment.UseVisualStyleBackColor = True
        '
        'btn_Product_Sale_Reports
        '
        Me.btn_Product_Sale_Reports.IconChar = FontAwesome.Sharp.IconChar.FileInvoice
        Me.btn_Product_Sale_Reports.IconColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btn_Product_Sale_Reports.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btn_Product_Sale_Reports.IconSize = 30
        Me.btn_Product_Sale_Reports.Location = New System.Drawing.Point(14, 18)
        Me.btn_Product_Sale_Reports.Name = "btn_Product_Sale_Reports"
        Me.btn_Product_Sale_Reports.Size = New System.Drawing.Size(150, 73)
        Me.btn_Product_Sale_Reports.TabIndex = 30
        Me.btn_Product_Sale_Reports.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Product_Sale_Reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Product_Sale_Reports.UseVisualStyleBackColor = True
        '
        'frm_reports_mgt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 245)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel_TitleBar)
        Me.Name = "frm_reports_mgt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_reports_mgt"
        Me.Panel_TitleBar.ResumeLayout(False)
        Me.Panel_TitleBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel_TitleBar As Panel
    Friend WithEvents btn_Maximize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Minimize As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Exit As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Summary_Daily_Sale As FontAwesome.Sharp.IconButton
    Friend WithEvents Sale_Invoice_By_Payment As FontAwesome.Sharp.IconButton
    Friend WithEvents btn_Product_Sale_Reports As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
End Class
