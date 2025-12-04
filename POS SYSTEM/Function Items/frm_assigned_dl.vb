Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Drawing

Public Class frm_assigned_dl
    ' --- Public Properties to pass/return data ---
    ' Property to receive the Receipt Number from the calling form
    Public Property ReceiptNumber As String

    ' Property to return the user's selected payment method (Cash or QR)
    Public Property OriginalPaymentMethod As String

    Private Sub frm_assigned_dl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.None
        Me.Text = $"Log Payment Method for Receipt: {ReceiptNumber}"

        ' Check if the ComboBox exists and populate it with options
        If Me.Controls.ContainsKey("cmdPaymentMethod") AndAlso TypeOf Me.Controls("cmdPaymentMethod") Is ComboBox Then
            Dim cmb As ComboBox = CType(Me.Controls("cmdPaymentMethod"), ComboBox)
            If Not cmb.Items.Count > 0 Then
                cmb.Items.Add("Cash")
                cmb.Items.Add("QR")
            End If
            ' Set default selection if desired
            ' cmb.SelectedIndex = 0 
        Else
            ' Handle case where cmdPaymentMethod is missing (e.g., use MessageBox for debugging)
            MessageBox.Show("Error: cmdPaymentMethod control not found on frm_assigned_dl.", "Control Missing")
        End If

    End Sub

    ' --- Handler for the OK button ---
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Not Me.Controls.ContainsKey("cmdPaymentMethod") OrElse TypeOf Me.Controls("cmdPaymentMethod") IsNot ComboBox Then
            MessageBox.Show("System Error: Payment Method control is missing.", "Error")
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Exit Sub
        End If

        Dim cmb As ComboBox = CType(Me.Controls("cmdPaymentMethod"), ComboBox)

        If cmb.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Set the public property to the selected value (Cash or QR)
        OriginalPaymentMethod = cmb.SelectedItem.ToString()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class