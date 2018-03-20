<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_4_Sel_UbiOrigine
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtUbicazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazione = New System.Windows.Forms.Label()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtUbicazioneProposta = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneProposta = New System.Windows.Forms.Label()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(176, 246)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 246)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUbicazione
        '
        Me.txtUbicazione.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazione.Location = New System.Drawing.Point(3, 217)
        Me.txtUbicazione.MaxLength = 10
        Me.txtUbicazione.Name = "txtUbicazione"
        Me.txtUbicazione.Size = New System.Drawing.Size(182, 25)
        Me.txtUbicazione.TabIndex = 0
        '
        'lblUbicazione
        '
        Me.lblUbicazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazione.Location = New System.Drawing.Point(3, 196)
        Me.lblUbicazione.Name = "lblUbicazione"
        Me.lblUbicazione.Size = New System.Drawing.Size(182, 19)
        Me.lblUbicazione.TabIndex = 13
        Me.lblUbicazione.Text = "Ubicazione Origine"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(186, 195)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 47)
        Me.cmdSelectUbicazione.TabIndex = 1
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 162)
        Me.txtInfoJobSelezionato.TabIndex = 0
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtUbicazioneProposta
        '
        Me.txtUbicazioneProposta.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUbicazioneProposta.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneProposta.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneProposta.Location = New System.Drawing.Point(59, 166)
        Me.txtUbicazioneProposta.Name = "txtUbicazioneProposta"
        Me.txtUbicazioneProposta.ReadOnly = True
        Me.txtUbicazioneProposta.Size = New System.Drawing.Size(179, 25)
        Me.txtUbicazioneProposta.TabIndex = 0
        Me.txtUbicazioneProposta.TabStop = False
        '
        'lblUbicazioneProposta
        '
        Me.lblUbicazioneProposta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneProposta.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneProposta.Location = New System.Drawing.Point(1, 169)
        Me.lblUbicazioneProposta.Name = "lblUbicazioneProposta"
        Me.lblUbicazioneProposta.Size = New System.Drawing.Size(58, 13)
        Me.lblUbicazioneProposta.TabIndex = 12
        Me.lblUbicazioneProposta.Text = "Proposta:"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(112, 246)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdPreviousScreen.TabIndex = 11
        Me.cmdPreviousScreen.Text = "<"
        '
        'frmPickingMerci_Appr_4_Sel_UbiOrigine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.txtUbicazioneProposta)
        Me.Controls.Add(Me.lblUbicazioneProposta)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazione)
        Me.Controls.Add(Me.lblUbicazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_4_Sel_UbiOrigine"
        Me.Text = "Picking Appr. (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUbicazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazione As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicazioneProposta As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneProposta As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
End Class
