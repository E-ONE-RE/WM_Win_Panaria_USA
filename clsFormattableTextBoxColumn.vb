Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Namespace DataGridTest.DataGrid
	''' <summary>
	''' Summary description for FormattableTextBoxColumn.
	''' </summary>
	Public Class FormattableTextBoxColumn
		Inherits DataGridTextBoxColumn

		Public Event SetCellFormat As FormatCellEventHandler

		Protected Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
			Dim e As New DataGridFormatCellEventArgs(rowNum, source)
			e.ForeBrush = foreBrush
			e.BackBrush = backBrush
			OnSetCellFormat(e)
			MyBase.Paint(g, bounds, source, rowNum, e.BackBrush, e.ForeBrush, alignToRight)
		End Sub

		Private Sub OnSetCellFormat(ByVal e As DataGridFormatCellEventArgs)

            Dim handler As FormatCellEventHandler = SetCellFormatEvent

			If handler IsNot Nothing Then
				handler(Me, e)
			End If
		End Sub
	End Class
End Namespace
