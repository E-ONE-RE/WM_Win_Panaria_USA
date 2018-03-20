<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_ChiudiLista
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
        Me.cmdVerificaStock = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdCloseJobsGroup = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdVerificaStock
        '
        Me.cmdVerificaStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdVerificaStock.Location = New System.Drawing.Point(3, 244)
        Me.cmdVerificaStock.Name = "cmdVerificaStock"
        Me.cmdVerificaStock.Size = New System.Drawing.Size(114, 40)
        Me.cmdVerificaStock.TabIndex = 102
        Me.cmdVerificaStock.Text = "Stamp.Etichette"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(119, 244)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(55, 40)
        Me.cmdPreviousScreen.TabIndex = 101
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdCloseJobsGroup
        '
        Me.cmdCloseJobsGroup.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdCloseJobsGroup.Location = New System.Drawing.Point(177, 244)
        Me.cmdCloseJobsGroup.Name = "cmdCloseJobsGroup"
        Me.cmdCloseJobsGroup.Size = New System.Drawing.Size(60, 40)
        Me.cmdCloseJobsGroup.TabIndex = 100
        Me.cmdCloseJobsGroup.Text = "Chiudi"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 26)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(234, 215)
        Me.txtInfoJobSelezionato.TabIndex = 180
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(0, 1)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(233, 22)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'frmEM_FromJob_Part_ChiudiLista
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdVerificaStock)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdCloseJobsGroup)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_ChiudiLista"
        Me.Text = "Picking Appr.(Chiudi)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdVerificaStock As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdCloseJobsGroup As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
End Class
