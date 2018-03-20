<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_StockList_Part_2_List_Giacenze
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura seguente è richiesta da Progettazione Windows Form
    'Può essere modificata utilizzando Progettazione Windows Form.  
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.DtGridStockInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 256)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 37)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 256)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 37)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(94, 256)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(68, 37)
        Me.cmdPreviousScreen.TabIndex = 44
        Me.cmdPreviousScreen.Text = "<"
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(1, 0)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.Size = New System.Drawing.Size(237, 179)
        Me.DtGridStockInfo.TabIndex = 107
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 179)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(238, 76)
        Me.txtInfoJobSelezionato.TabIndex = 159
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'frmEM_StockList_Part_2_List_Giacenze
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.DtGridStockInfo)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_StockList_Part_2_List_Giacenze"
        Me.Text = "EM - Lista (2)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
End Class
