Imports System
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace HideCommandButtons

    Public Partial Class _Default
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            ASPxGridView1.DataSource = GetData()
            ASPxGridView1.DataBind()
        End Sub

        Private Function GetData() As DataTable
            Dim table As DataTable = New DataTable()
            table.Columns.Add("ID", GetType(Integer))
            For i As Integer = 0 To 10 - 1
                table.Rows.Add(i)
            Next

            Return table
        End Function

        Protected Sub ASPxGridView1_CommandButtonInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewCommandButtonEventArgs)
            Dim isOddRow As Boolean = e.VisibleIndex Mod 2 = 0
            If isOddRow Then ' some condition
                ' hide the Edit button
                If e.ButtonType = DevExpress.Web.ColumnCommandButtonType.Edit Then e.Visible = False
                ' disable the selction checkbox
                If e.ButtonType = DevExpress.Web.ColumnCommandButtonType.SelectCheckbox Then e.Enabled = False
            End If
        End Sub
    End Class
End Namespace
