<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDisaccantonaMerci_5_Sel_UbiDestinazione
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.txtUbicazioneDestinazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneDestinazione = New System.Windows.Forms.Label()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 244)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 38)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 244)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 244)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(187, 199)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(50, 40)
        Me.cmdSelectUbicazioneDest.TabIndex = 162
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'txtUbicazioneDestinazione
        '
        Me.txtUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestinazione.Location = New System.Drawing.Point(0, 216)
        Me.txtUbicazioneDestinazione.MaxLength = 10
        Me.txtUbicazioneDestinazione.Name = "txtUbicazioneDestinazione"
        Me.txtUbicazioneDestinazione.Size = New System.Drawing.Size(186, 28)
        Me.txtUbicazioneDestinazione.TabIndex = 161
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(0, 195)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(186, 19)
        Me.lblUbicazioneDestinazione.TabIndex = 204
        Me.lblUbicazioneDestinazione.Text = "Ubicazione Dest."
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(236, 193)
        Me.txtInfoJobSelezionato.TabIndex = 203
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'frmDisaccantonaMerci_5_Sel_UbiDestinazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.txtUbicazioneDestinazione)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDisaccantonaMerci_5_Sel_UbiDestinazione"
        Me.Text = "Disaccant.(5)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents txtUbicazioneDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneDestinazione As System.Windows.Forms.Label
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
End Class
