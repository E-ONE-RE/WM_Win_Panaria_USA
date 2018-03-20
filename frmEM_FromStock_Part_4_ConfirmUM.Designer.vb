<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_4_ConfirmUM
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
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.txtUbicazioneDestInfo = New System.Windows.Forms.TextBox()
        Me.lblUM_Destinazione = New System.Windows.Forms.Label()
        Me.txtUMDestConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(181, 155)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(55, 43)
        Me.cmdSelectUbicazioneDest.TabIndex = 86
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 250)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 41)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(99, 250)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(67, 41)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(170, 250)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(67, 41)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(0, 158)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(179, 16)
        Me.lblUbicazDestConfermata.TabIndex = 164
        Me.lblUbicazDestConfermata.Text = "Ubicazione Destinazione"
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(-1, 175)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(182, 24)
        Me.txtUbicazDestConfermata.TabIndex = 81
        '
        'txtUbicazioneDestInfo
        '
        Me.txtUbicazioneDestInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUbicazioneDestInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneDestInfo.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestInfo.Location = New System.Drawing.Point(0, 200)
        Me.txtUbicazioneDestInfo.Name = "txtUbicazioneDestInfo"
        Me.txtUbicazioneDestInfo.ReadOnly = True
        Me.txtUbicazioneDestInfo.Size = New System.Drawing.Size(236, 24)
        Me.txtUbicazioneDestInfo.TabIndex = 126
        Me.txtUbicazioneDestInfo.TabStop = False
        '
        'lblUM_Destinazione
        '
        Me.lblUM_Destinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Destinazione.Location = New System.Drawing.Point(2, 227)
        Me.lblUM_Destinazione.Name = "lblUM_Destinazione"
        Me.lblUM_Destinazione.Size = New System.Drawing.Size(76, 20)
        Me.lblUM_Destinazione.TabIndex = 163
        Me.lblUM_Destinazione.Text = "UM.Dest."
        '
        'txtUMDestConfermata
        '
        Me.txtUMDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUMDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUMDestConfermata.Location = New System.Drawing.Point(78, 225)
        Me.txtUMDestConfermata.MaxLength = 10
        Me.txtUMDestConfermata.Name = "txtUMDestConfermata"
        Me.txtUMDestConfermata.Size = New System.Drawing.Size(159, 24)
        Me.txtUMDestConfermata.TabIndex = 138
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(236, 154)
        Me.txtInfoJobSelezionato.TabIndex = 162
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'frmEM_FromStock_Part_4_ConfirmUM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUM_Destinazione)
        Me.Controls.Add(Me.txtUMDestConfermata)
        Me.Controls.Add(Me.txtUbicazioneDestInfo)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_4_ConfirmUM"
        Me.Text = "EM - Lista (5)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicazioneDestInfo As System.Windows.Forms.TextBox
    Friend WithEvents lblUM_Destinazione As System.Windows.Forms.Label
    Friend WithEvents txtUMDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
End Class
