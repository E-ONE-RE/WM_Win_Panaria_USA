<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_X_PickLogic
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
        Me.lblUDMQuantità = New System.Windows.Forms.Label()
        Me.txtUDMQuantita = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.ckboxFlagForcedStepEnded = New System.Windows.Forms.CheckBox()
        Me.txtInfoPrelievo = New System.Windows.Forms.TextBox()
        Me.lblInfoPrelievo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 250)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 34)
        Me.cmdNextScreen.TabIndex = 41
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(95, 250)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(68, 34)
        Me.cmdPreviousScreen.TabIndex = 43
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 250)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 34)
        Me.cmdAbortScreen.TabIndex = 44
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblUDMQuantità
        '
        Me.lblUDMQuantità.BackColor = System.Drawing.Color.Lavender
        Me.lblUDMQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantità.Location = New System.Drawing.Point(128, 167)
        Me.lblUDMQuantità.Name = "lblUDMQuantità"
        Me.lblUDMQuantità.Size = New System.Drawing.Size(35, 14)
        Me.lblUDMQuantità.TabIndex = 212
        Me.lblUDMQuantità.Text = "UdM"
        '
        'txtUDMQuantita
        '
        Me.txtUDMQuantita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantita.Location = New System.Drawing.Point(127, 183)
        Me.txtUDMQuantita.Name = "txtUDMQuantita"
        Me.txtUDMQuantita.ReadOnly = True
        Me.txtUDMQuantita.Size = New System.Drawing.Size(34, 22)
        Me.txtUDMQuantita.TabIndex = 198
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Lavender
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(60, 167)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(63, 16)
        Me.lblQtaPrevista.TabIndex = 213
        Me.lblQtaPrevista.Text = "Qta Prev."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(60, 183)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(63, 22)
        Me.txtQtaPrevista.TabIndex = 197
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(164, 163)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(71, 21)
        Me.lblQtaConfermata.TabIndex = 214
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(163, 183)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(72, 22)
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 165)
        Me.txtInfoJobSelezionato.TabIndex = 201
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'ckboxFlagForcedStepEnded
        '
        Me.ckboxFlagForcedStepEnded.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckboxFlagForcedStepEnded.Location = New System.Drawing.Point(-1, 182)
        Me.ckboxFlagForcedStepEnded.Name = "ckboxFlagForcedStepEnded"
        Me.ckboxFlagForcedStepEnded.Size = New System.Drawing.Size(63, 19)
        Me.ckboxFlagForcedStepEnded.TabIndex = 205
        Me.ckboxFlagForcedStepEnded.Text = "Fine"
        '
        'txtInfoPrelievo
        '
        Me.txtInfoPrelievo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoPrelievo.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPrelievo.Location = New System.Drawing.Point(2, 225)
        Me.txtInfoPrelievo.MaxLength = 40
        Me.txtInfoPrelievo.Name = "txtInfoPrelievo"
        Me.txtInfoPrelievo.Size = New System.Drawing.Size(235, 25)
        Me.txtInfoPrelievo.TabIndex = 210
        '
        'lblInfoPrelievo
        '
        Me.lblInfoPrelievo.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoPrelievo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoPrelievo.ForeColor = System.Drawing.Color.Black
        Me.lblInfoPrelievo.Location = New System.Drawing.Point(2, 207)
        Me.lblInfoPrelievo.Name = "lblInfoPrelievo"
        Me.lblInfoPrelievo.Size = New System.Drawing.Size(233, 18)
        Me.lblInfoPrelievo.TabIndex = 211
        Me.lblInfoPrelievo.Text = "Informazioni x Prelievo"
        '
        'frmPickingMerci_Appr_X_PickLogic
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtInfoPrelievo)
        Me.Controls.Add(Me.lblInfoPrelievo)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.ckboxFlagForcedStepEnded)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantità)
        Me.Controls.Add(Me.txtUDMQuantita)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_X_PickLogic"
        Me.Text = "Picking Appr. (6)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblUDMQuantità As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantita As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents ckboxFlagForcedStepEnded As System.Windows.Forms.CheckBox
    Friend WithEvents txtInfoPrelievo As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoPrelievo As System.Windows.Forms.Label
End Class
