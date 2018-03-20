Imports System
Imports System.Windows.Forms
Imports System.Drawing

Namespace DataGridTest.DataGrid
	Public Delegate Sub FormatCellEventHandler(ByVal sender As Object, ByVal e As DataGridFormatCellEventArgs)

	Public Class DataGridFormatCellEventArgs
		Inherits EventArgs

		Public Row As Integer
		Public Source As CurrencyManager
		Public BackBrush As Brush
		Public ForeBrush As Brush

		Public Sub New(ByVal row As Integer, ByVal manager As CurrencyManager)
			Me.Row = row
			Me.Source = manager
		End Sub
	End Class
End Namespace
