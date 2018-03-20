<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDisaccantonaMerci_4_ConfQta
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
        Me.txtQtaSfusiConfermata = New System.Windows.Forms.TextBox()
        Me.txtUDMSfusiQuantità = New System.Windows.Forms.TextBox()
        Me.txtQtaSfusiPrevista = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(180, 240)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(55, 42)
        Me.cmdNextScreen.TabIndex = 41
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(117, 240)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(55, 42)
        Me.cmdPreviousScreen.TabIndex = 43
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 240)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(50, 42)
        Me.cmdAbortScreen.TabIndex = 44
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Lavender
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(128, 179)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(35, 14)
        Me.lblUDMQuantita.TabIndex = 206
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(127, 195)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(34, 26)
        Me.txtUDMQuantità.TabIndex = 198
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Lavender
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(62, 179)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(61, 16)
        Me.lblQtaPrevista.TabIndex = 207
        Me.lblQtaPrevista.Text = "Qta Prev."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(62, 195)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(61, 26)
        Me.txtQtaPrevista.TabIndex = 197
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(165, 177)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(70, 19)
        Me.lblQtaConfermata.TabIndex = 208
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(164, 195)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(71, 26)
        Me.txtQtaConfermata.TabIndex = 196
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 174)
        Me.txtInfoJobSelezionato.TabIndex = 201
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'ckboxFlagForcedStepEnded
        '
        Me.ckboxFlagForcedStepEnded.Enabled = False
        Me.ckboxFlagForcedStepEnded.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckboxFlagForcedStepEnded.Location = New System.Drawing.Point(2, 194)
        Me.ckboxFlagForcedStepEnded.Name = "ckboxFlagForcedStepEnded"
        Me.ckboxFlagForcedStepEnded.Size = New System.Drawing.Size(58, 19)
        Me.ckboxFlagForcedStepEnded.TabIndex = 205
        Me.ckboxFlagForcedStepEnded.Text = "Fine"
        '
        'txtQtaSfusiConfermata
        '
        Me.txtQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiConfermata.Location = New System.Drawing.Point(164, 217)
        Me.txtQtaSfusiConfermata.Name = "txtQtaSfusiConfermata"
        Me.txtQtaSfusiConfermata.Size = New System.Drawing.Size(71, 26)
        Me.txtQtaSfusiConfermata.TabIndex = 209
        '
        'txtUDMSfusiQuantità
        '
        Me.txtUDMSfusiQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMSfusiQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMSfusiQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMSfusiQuantità.Location = New System.Drawing.Point(127, 217)
        Me.txtUDMSfusiQuantità.Name = "txtUDMSfusiQuantità"
        Me.txtUDMSfusiQuantità.ReadOnly = True
        Me.txtUDMSfusiQuantità.Size = New System.Drawing.Size(34, 26)
        Me.txtUDMSfusiQuantità.TabIndex = 211
        '
        'txtQtaSfusiPrevista
        '
        Me.txtQtaSfusiPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaSfusiPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaSfusiPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiPrevista.Location = New System.Drawing.Point(62, 217)
        Me.txtQtaSfusiPrevista.Name = "txtQtaSfusiPrevista"
        Me.txtQtaSfusiPrevista.ReadOnly = True
        Me.txtQtaSfusiPrevista.Size = New System.Drawing.Size(61, 26)
        Me.txtQtaSfusiPrevista.TabIndex = 210
        '
        'frmDisaccantonaMerci_4_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtQtaSfusiConfermata)
        Me.Controls.Add(Me.txtUDMSfusiQuantità)
        Me.Controls.Add(Me.txtQtaSfusiPrevista)
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
        Me.Name = "frmDisaccantonaMerci_4_ConfQta"
        Me.Text = "Disaccant.(4)"
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
    Friend WithEvents txtQtaSfusiConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtUDMSfusiQuantità As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaSfusiPrevista As System.Windows.Forms.TextBox
End Class
