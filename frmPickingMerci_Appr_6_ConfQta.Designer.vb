<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_6_ConfQta
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.ckboxFlagForcedStepEnded = New System.Windows.Forms.CheckBox()
        Me.lblShowRaggruppamento = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(175, 254)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 39)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(110, 254)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 39)
        Me.cmdPreviousScreen.TabIndex = 11
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 254)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(50, 39)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Lavender
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(112, 213)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(32, 14)
        Me.lblUDMQuantita.TabIndex = 2
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(111, 229)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(33, 22)
        Me.txtUDMQuantità.TabIndex = 0
        Me.txtUDMQuantità.TabStop = False
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Lavender
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(52, 213)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(63, 16)
        Me.lblQtaPrevista.TabIndex = 3
        Me.lblQtaPrevista.Text = "Qta Prev."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(52, 229)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(57, 22)
        Me.txtQtaPrevista.TabIndex = 0
        Me.txtQtaPrevista.TabStop = False
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(166, 213)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(71, 15)
        Me.lblQtaConfermata.TabIndex = 4
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(165, 229)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(72, 22)
        Me.txtQtaConfermata.TabIndex = 1
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 211)
        Me.txtInfoJobSelezionato.TabIndex = 0
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'ckboxFlagForcedStepEnded
        '
        Me.ckboxFlagForcedStepEnded.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckboxFlagForcedStepEnded.Location = New System.Drawing.Point(-2, 228)
        Me.ckboxFlagForcedStepEnded.Name = "ckboxFlagForcedStepEnded"
        Me.ckboxFlagForcedStepEnded.Size = New System.Drawing.Size(54, 19)
        Me.ckboxFlagForcedStepEnded.TabIndex = 0
        Me.ckboxFlagForcedStepEnded.Text = "Fine"
        '
        'lblShowRaggruppamento
        '
        Me.lblShowRaggruppamento.BackColor = System.Drawing.Color.Lavender
        Me.lblShowRaggruppamento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblShowRaggruppamento.ForeColor = System.Drawing.Color.Black
        Me.lblShowRaggruppamento.Location = New System.Drawing.Point(146, 229)
        Me.lblShowRaggruppamento.Name = "lblShowRaggruppamento"
        Me.lblShowRaggruppamento.Size = New System.Drawing.Size(17, 21)
        Me.lblShowRaggruppamento.TabIndex = 0
        Me.lblShowRaggruppamento.Text = "R"
        Me.lblShowRaggruppamento.Visible = False
        '
        'frmPickingMerci_Appr_6_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.lblShowRaggruppamento)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.ckboxFlagForcedStepEnded)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_6_ConfQta"
        Me.Text = "Picking Appr. (6)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents ckboxFlagForcedStepEnded As System.Windows.Forms.CheckBox
    Friend WithEvents lblShowRaggruppamento As System.Windows.Forms.Label
End Class
