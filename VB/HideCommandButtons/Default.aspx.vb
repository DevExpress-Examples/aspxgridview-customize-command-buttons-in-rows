Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView.Rendering

Namespace HideCommandButtons
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetData()
			ASPxGridView1.DataBind()
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			For i As Integer = 0 To 9
				table.Rows.Add(i)
			Next i
			Return table
		End Function

		Protected Sub ASPxGridView1_CommandButtonInitialize(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCommandButtonEventArgs)
			Dim isOddRow As Boolean = e.VisibleIndex Mod 2 = 0
			If isOddRow Then ' some condition
				' hide the Edit button
				If e.Button.ButtonType = DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Edit Then
					e.Visible = False
				End If

				' disable the selction checkbox
				If e.Button.ButtonType = DevExpress.Web.ASPxGridView.ColumnCommandButtonType.Select Then
					e.Enabled = False
				End If
			End If
		End Sub
	End Class
End Namespace
