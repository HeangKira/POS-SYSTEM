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
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtPaid As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgtDisplayDataPosMani = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtPaid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgtDisplayDataPosMani, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 35)
        Me.Panel1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(26, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(72, 15)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "WELCOME"
        '
        'dgtDisplayDataPosMani
        '
        Me.dgtDisplayDataPosMani.AllowUserToAddRows = False
        Me.dgtDisplayDataPosMani.AllowUserToDeleteRows = False
        Me.dgtDisplayDataPosMani.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.dgtDisplayDataPosMani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgtDisplayDataPosMani.GridColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.dgtDisplayDataPosMani.Location = New System.Drawing.Point(0, 36)
        Me.dgtDisplayDataPosMani.Name = "dgtDisplayDataPosMani"
        Me.dgtDisplayDataPosMani.ReadOnly = True
        Me.dgtDisplayDataPosMani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgtDisplayDataPosMani.Size = New System.Drawing.Size(505, 335)
        Me.dgtDisplayDataPosMani.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtPaid)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(0, 369)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(505, 81)
        Me.Panel2.TabIndex = 1
        '
        'txtPaid
        '
        Me.txtPaid.Enabled = False
        Me.txtPaid.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaid.Location = New System.Drawing.Point(140, 25)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.Size = New System.Drawing.Size(153, 28)
        Me.txtPaid.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(123, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 20)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = ":"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Total Be Paid"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(505, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(295, 414)
        Me.Panel3.TabIndex = 2
        '
        'frm_display_second
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgtDisplayDataPosMani)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_display_second"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_display_second"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgtDisplayDataPosMani, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub frm_display_second_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDisplayDataGrid()
        lblTitle.Text = "WELCOME TO POSITRON STORE"
    End Sub

    ' --- Initialize the DataGridView columns on load ---
    Private Sub InitializeDisplayDataGrid()
        ' ⭐ Ensure 'dgtDisplayDataPosMani' matches your DataGridView control name exactly ⭐
        With dgtDisplayDataPosMani
            .Rows.Clear()
            .Columns.Clear()
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True ' Display only
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' --- 1. SET HEADER STYLE: Bold and Center ---
            Dim headerStyle As New DataGridViewCellStyle()
            headerStyle.Font = New Font(.Font, FontStyle.Bold) ' Make font bold
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Center align text

            .ColumnHeadersDefaultCellStyle = headerStyle
            ' -------------------------------------------

            ' Add Columns for the requested fields: Code, Item Name, Qty, Price, Amount
            .Columns.Add("i_CODE", "Item Code")
            .Columns.Add("i_DESC", "Item Name")
            .Columns.Add("i_Qty", "Qty")
            .Columns.Add("i_Price", "Price")
            .Columns.Add("i_NetAmt", "Amount")

            ' Set Column Alignment and Width (Adjust widths as necessary for your design)
            .Columns("i_CODE").Width = 80
            .Columns("i_DESC").Width = 180
            .Columns("i_Qty").Width = 50
            .Columns("i_Price").Width = 70
            .Columns("i_NetAmt").Width = 80

            ' Set alignment for numeric columns
            .Columns("i_Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("i_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("i_NetAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    ' --- PUBLIC METHOD: To receive and display the items (Fixes the BC30456 Error) ---
    Public Sub UpdateDisplayItems(ByVal itemDataList As List(Of frm_pos_sell.DisplayItemInfo), ByVal paidAmount As Decimal)
        ' ⭐ Ensure 'dgtDisplayDataPosMani' matches your DataGridView control name exactly ⭐
        dgtDisplayDataPosMani.Rows.Clear()

        For Each item In itemDataList
            dgtDisplayDataPosMani.Rows.Add(
            item.ItemCode,                              ' Value from ItemCode property
            item.Description,                           ' Value from Description property
            item.Quantity.ToString("0.00"),             ' Formatted Qty
            item.Price.ToString("0.00"),                ' Formatted Unit Price
            item.NetPrice.ToString("0.00")              ' Formatted Net Amount (Amount)
        )
        Next

        ' Optional: Scroll to the last added item to show the most recent change
        If dgtDisplayDataPosMani.Rows.Count > 0 Then
            dgtDisplayDataPosMani.FirstDisplayedScrollingRowIndex = dgtDisplayDataPosMani.Rows.Count - 1
        End If

        ' ⭐ UPDATED: Display the Paid Amount in the txtPaid control on this form
        txtPaid.Text = paidAmount.ToString("N2")
    End Sub
End Class
