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
    Friend WithEvents lblPaid As Label
    Friend WithEvents lblRiel As Label
    Friend WithEvents lblBard As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox

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
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.lblRiel = New System.Windows.Forms.Label()
        Me.lblBard = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgtDisplayDataPosMani, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 50)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.POS_SYSTEM.My.Resources.Resources.Positron_Logo_White1
        Me.PictureBox1.Location = New System.Drawing.Point(697, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 44)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(12, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(114, 22)
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
        Me.dgtDisplayDataPosMani.Location = New System.Drawing.Point(0, 56)
        Me.dgtDisplayDataPosMani.Name = "dgtDisplayDataPosMani"
        Me.dgtDisplayDataPosMani.ReadOnly = True
        Me.dgtDisplayDataPosMani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgtDisplayDataPosMani.Size = New System.Drawing.Size(502, 268)
        Me.dgtDisplayDataPosMani.TabIndex = 1
        '
        'lblPaid
        '
        Me.lblPaid.AutoSize = True
        Me.lblPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaid.ForeColor = System.Drawing.Color.White
        Me.lblPaid.Location = New System.Drawing.Point(227, 82)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(38, 24)
        Me.lblPaid.TabIndex = 54
        Me.lblPaid.Text = "$ 0"
        '
        'lblRiel
        '
        Me.lblRiel.AutoSize = True
        Me.lblRiel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRiel.ForeColor = System.Drawing.Color.White
        Me.lblRiel.Location = New System.Drawing.Point(23, 82)
        Me.lblRiel.Name = "lblRiel"
        Me.lblRiel.Size = New System.Drawing.Size(35, 29)
        Me.lblRiel.TabIndex = 55
        Me.lblRiel.Text = "៛ 0"
        '
        'lblBard
        '
        Me.lblBard.AutoSize = True
        Me.lblBard.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBard.ForeColor = System.Drawing.Color.White
        Me.lblBard.Location = New System.Drawing.Point(414, 82)
        Me.lblBard.Name = "lblBard"
        Me.lblBard.Size = New System.Drawing.Size(40, 24)
        Me.lblBard.TabIndex = 56
        Me.lblBard.Text = "฿ 0"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Qty :"
        '
        'lblQty
        '
        Me.lblQty.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.White
        Me.lblQty.Location = New System.Drawing.Point(60, 22)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(19, 20)
        Me.lblQty.TabIndex = 58
        Me.lblQty.Text = "0"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblPaid)
        Me.Panel2.Controls.Add(Me.lblQty)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblBard)
        Me.Panel2.Controls.Add(Me.lblRiel)
        Me.Panel2.Location = New System.Drawing.Point(0, 329)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(502, 120)
        Me.Panel2.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(203, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Total Be Paid"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(505, 56)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(292, 393)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'frm_display_second
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgtDisplayDataPosMani)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_display_second"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_display_second"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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

    ' --- PUBLIC METHOD: To receive and display the items ---
    Public Sub UpdateDisplayItems(ByVal itemDataList As List(Of frm_pos_sell.DisplayItemInfo), ByVal netTotalDue As Decimal)
        ' ⭐ Ensure 'dgtDisplayDataPosMani' matches your DataGridView control name exactly ⭐
        dgtDisplayDataPosMani.Rows.Clear()

        For Each item In itemDataList
            dgtDisplayDataPosMani.Rows.Add(
                item.ItemCode,              ' Value from ItemCode property
                item.Description,           ' Value from Description property
                item.Quantity.ToString("0.00"), ' Formatted Qty
                item.Price.ToString("0.00"),    ' Formatted Unit Price
                item.NetPrice.ToString("0.00")  ' Formatted Net Amount (Amount)
            )
        Next

        If dgtDisplayDataPosMani.Rows.Count > 0 Then
            dgtDisplayDataPosMani.FirstDisplayedScrollingRowIndex = dgtDisplayDataPosMani.Rows.Count - 1

            ' Display KHR and THB totals attached to the first item
            lblRiel.Text = "៛ " & itemDataList(0).TotalKHR
            lblBard.Text = "฿ " & itemDataList(0).TotalTHB

            ' ⭐ CORRECT: Set the lblQty text from the Totalqty property of the first item
            lblQty.Text = itemDataList(0).Totalqty
        Else
            lblRiel.Text = "៛ 0" ' Show symbol even when zero
            lblBard.Text = "฿ 0" ' Show symbol even when zero
            lblQty.Text = "0" ' Clear or reset quantity display
        End If

        ' ⭐ Display the Net Total Due (in USD)
        lblPaid.Text = "$ " & netTotalDue.ToString("N2")
        dgtDisplayDataPosMani.ClearSelection()

    End Sub
End Class
