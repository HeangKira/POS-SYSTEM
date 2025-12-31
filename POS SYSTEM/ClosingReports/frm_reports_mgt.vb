Imports System.Runtime.InteropServices

Public Class frm_reports_mgt
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel_TitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btn_Minimize_Click(sender As Object, e As EventArgs) Handles btn_Minimize.Click
        WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_Maximize_Click(sender As Object, e As EventArgs) Handles btn_Maximize.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub btn_Product_Sale_Reports_Click(sender As Object, e As EventArgs) Handles btn_Product_Sale_Reports.Click
        Dim F As New frm_sales_by_product_report
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub

    Private Sub btnItemixedSaleReport_Click(sender As Object, e As EventArgs) Handles btnItemixedSaleReport.Click
        Dim F As New frm_sale_by_item_group_
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub

    Private Sub btnSaleByPaymentMethod_Click(sender As Object, e As EventArgs) Handles btnSaleByPaymentMethod.Click
        Dim F As New frm_sale_by_payment_method
        F.FormBorderStyle = FormBorderStyle.None
        F.ShowDialog()
    End Sub
End Class