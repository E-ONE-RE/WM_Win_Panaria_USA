<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_5_FinalUbiConfirm
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.lblUM_Destinazione = New System.Windows.Forms.Label()
        Me.txtUMDestConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtUbicazioneDestInfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(187, 165)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(49, 45)
        Me.cmdSelectUbicazioneDest.TabIndex = 86
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 261)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 43)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 261)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(69, 43)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(0, 168)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(186, 17)
        Me.lblUbicazDestConfermata.TabIndex = 168
        Me.lblUbicazDestConfermata.Text = "Ubicazione Destinazione"
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(0, 185)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(187, 28)
        Me.txtUbicazDestConfermata.TabIndex = 81
        '
        'lblUM_Destinazione
        '
        Me.lblUM_Destinazione.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Destinazione.Location = New System.Drawing.Point(2, 237)
        Me.lblUM_Destinazione.Name = "lblUM_Destinazione"
        Me.lblUM_Destinazione.Size = New System.Drawing.Size(69, 20)
        Me.lblUM_Destinazione.TabIndex = 167
        Me.lblUM_Destinazione.Text = "UM.Dest."
        '
        'txtUMDestConfermata
        '
        Me.txtUMDestConfermata.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUMDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUMDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUMDestConfermata.Location = New System.Drawing.Point(75, 234)
        Me.txtUMDestConfermata.Name = "txtUMDestConfermata"
        Me.txtUMDestConfermata.ReadOnly = True
        Me.txtUMDestConfermata.Size = New System.Drawing.Size(162, 28)
        Me.txtUMDestConfermata.TabIndex = 138
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(2, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 165)
        Me.txtInfoJobSelezionato.TabIndex = 163
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtUbicazioneDestInfo
        '
        Me.txtUbicazioneDestInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUbicazioneDestInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneDestInfo.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestInfo.Location = New System.Drawing.Point(0, 211)
        Me.txtUbicazioneDestInfo.Name = "txtUbicazioneDestInfo"
        Me.txtUbicazioneDestInfo.ReadOnly = True
        Me.txtUbicazioneDestInfo.Size = New System.Drawing.Size(237, 28)
        Me.txtUbicazioneDestInfo.TabIndex = 166
        Me.txtUbicazioneDestInfo.TabStop = False
        '
        'frmEM_FromJob_Part_5_FinalUbiConfirm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 305)
        Me.Controls.Add(Me.txtUbicazioneDestInfo)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUM_Destinazione)
        Me.Controls.Add(Me.txtUMDestConfermata)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_5_FinalUbiConfirm"
        Me.Text = "EM - Bem (5)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblUM_Destinazione As System.Windows.Forms.Label
    Friend WithEvents txtUMDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicazioneDestInfo As System.Windows.Forms.TextBox
End Class
