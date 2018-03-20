<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTRASF_UM_Part_2_UM_Dest
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
        Me.lblUM_Destinazione = New System.Windows.Forms.Label()
        Me.txtUM_Destinazione = New System.Windows.Forms.TextBox()
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.txtInfoOperazioneUtente = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 249)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 35)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 249)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 35)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 249)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 35)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUM_Destinazione
        '
        Me.lblUM_Destinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Destinazione.Location = New System.Drawing.Point(1, 197)
        Me.lblUM_Destinazione.Name = "lblUM_Destinazione"
        Me.lblUM_Destinazione.Size = New System.Drawing.Size(235, 19)
        Me.lblUM_Destinazione.TabIndex = 189
        Me.lblUM_Destinazione.Text = "Unità Magazzino Destinazione"
        '
        'txtUM_Destinazione
        '
        Me.txtUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Destinazione.Location = New System.Drawing.Point(-1, 217)
        Me.txtUM_Destinazione.MaxLength = 10
        Me.txtUM_Destinazione.Name = "txtUM_Destinazione"
        Me.txtUM_Destinazione.Size = New System.Drawing.Size(239, 27)
        Me.txtUM_Destinazione.TabIndex = 179
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Enabled = False
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(187, 147)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(50, 48)
        Me.cmdSelectUbicazioneDest.TabIndex = 183
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(0, 149)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(187, 18)
        Me.lblUbicazDestConfermata.TabIndex = 188
        Me.lblUbicazDestConfermata.Text = "Ubicazione Destinazione"
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(0, 167)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(187, 20)
        Me.txtUbicazDestConfermata.TabIndex = 182
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(0, -2)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(238, 20)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'txtInfoOperazioneUtente
        '
        Me.txtInfoOperazioneUtente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoOperazioneUtente.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoOperazioneUtente.ForeColor = System.Drawing.Color.Black
        Me.txtInfoOperazioneUtente.Location = New System.Drawing.Point(-1, 20)
        Me.txtInfoOperazioneUtente.Multiline = True
        Me.txtInfoOperazioneUtente.Name = "txtInfoOperazioneUtente"
        Me.txtInfoOperazioneUtente.ReadOnly = True
        Me.txtInfoOperazioneUtente.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoOperazioneUtente.Size = New System.Drawing.Size(239, 126)
        Me.txtInfoOperazioneUtente.TabIndex = 187
        Me.txtInfoOperazioneUtente.TabStop = False
        '
        'frmTRASF_UM_Part_2_UM_Dest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.txtInfoOperazioneUtente)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.Controls.Add(Me.txtUM_Destinazione)
        Me.Controls.Add(Me.lblUM_Destinazione)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTRASF_UM_Part_2_UM_Dest"
        Me.Text = "TRASF - Unità Mag.(2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUM_Destinazione As System.Windows.Forms.Label
    Friend WithEvents txtUM_Destinazione As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents txtInfoOperazioneUtente As System.Windows.Forms.TextBox
End Class