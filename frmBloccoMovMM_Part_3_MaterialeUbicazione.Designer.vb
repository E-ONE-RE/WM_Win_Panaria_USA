<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmBloccoMovMM_Part_3_MaterialeUbicazione
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
        Me.txtOperazione = New System.Windows.Forms.TextBox()
        Me.lblOperazione = New System.Windows.Forms.Label()
        Me.lblMateriale = New System.Windows.Forms.Label()
        Me.txtMateriale = New System.Windows.Forms.TextBox()
        Me.lblPartita = New System.Windows.Forms.Label()
        Me.txtPartita = New System.Windows.Forms.TextBox()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.txtUbicazioneOrigine = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 217)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 217)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(92, 217)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdPreviousScreen.TabIndex = 44
        Me.cmdPreviousScreen.Text = "<"
        '
        'txtOperazione
        '
        Me.txtOperazione.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOperazione.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtOperazione.ForeColor = System.Drawing.Color.Black
        Me.txtOperazione.Location = New System.Drawing.Point(1, 17)
        Me.txtOperazione.Name = "txtOperazione"
        Me.txtOperazione.Size = New System.Drawing.Size(235, 20)
        Me.txtOperazione.TabIndex = 104
        Me.txtOperazione.TabStop = False
        '
        'lblOperazione
        '
        Me.lblOperazione.BackColor = System.Drawing.Color.Transparent
        Me.lblOperazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOperazione.ForeColor = System.Drawing.Color.Black
        Me.lblOperazione.Location = New System.Drawing.Point(1, 1)
        Me.lblOperazione.Name = "lblOperazione"
        Me.lblOperazione.Size = New System.Drawing.Size(104, 17)
        Me.lblOperazione.TabIndex = 123
        Me.lblOperazione.Text = "Operazione"
        '
        'lblMateriale
        '
        Me.lblMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblMateriale.Location = New System.Drawing.Point(2, 101)
        Me.lblMateriale.Name = "lblMateriale"
        Me.lblMateriale.Size = New System.Drawing.Size(232, 20)
        Me.lblMateriale.TabIndex = 122
        Me.lblMateriale.Text = "Materiale"
        '
        'txtMateriale
        '
        Me.txtMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtMateriale.Location = New System.Drawing.Point(2, 123)
        Me.txtMateriale.MaxLength = 18
        Me.txtMateriale.Name = "txtMateriale"
        Me.txtMateriale.Size = New System.Drawing.Size(235, 25)
        Me.txtMateriale.TabIndex = 107
        '
        'lblPartita
        '
        Me.lblPartita.BackColor = System.Drawing.Color.Yellow
        Me.lblPartita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartita.ForeColor = System.Drawing.Color.Black
        Me.lblPartita.Location = New System.Drawing.Point(2, 162)
        Me.lblPartita.Name = "lblPartita"
        Me.lblPartita.Size = New System.Drawing.Size(233, 21)
        Me.lblPartita.TabIndex = 121
        Me.lblPartita.Text = "Partita"
        '
        'txtPartita
        '
        Me.txtPartita.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartita.ForeColor = System.Drawing.Color.Black
        Me.txtPartita.Location = New System.Drawing.Point(2, 185)
        Me.txtPartita.MaxLength = 10
        Me.txtPartita.Name = "txtPartita"
        Me.txtPartita.Size = New System.Drawing.Size(234, 25)
        Me.txtPartita.TabIndex = 112
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(185, 39)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 52)
        Me.cmdSelectUbicazione.TabIndex = 119
        Me.cmdSelectUbicazione.Text = "..."
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(2, 39)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(182, 24)
        Me.lblUbicazioneOrigine.TabIndex = 120
        Me.lblUbicazioneOrigine.Text = "Ubicazione"
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(2, 64)
        Me.txtUbicazioneOrigine.MaxLength = 10
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(182, 25)
        Me.txtUbicazioneOrigine.TabIndex = 118
        '
        'frmBloccoMovMM_Part_3_MaterialeUbicazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.Controls.Add(Me.lblPartita)
        Me.Controls.Add(Me.txtPartita)
        Me.Controls.Add(Me.lblMateriale)
        Me.Controls.Add(Me.txtMateriale)
        Me.Controls.Add(Me.txtOperazione)
        Me.Controls.Add(Me.lblOperazione)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBloccoMovMM_Part_3_MaterialeUbicazione"
        Me.Text = "Metti/Togli Stock.Spec.(3)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents txtOperazione As System.Windows.Forms.TextBox
    Friend WithEvents lblOperazione As System.Windows.Forms.Label
    Friend WithEvents lblMateriale As System.Windows.Forms.Label
    Friend WithEvents txtMateriale As System.Windows.Forms.TextBox
    Friend WithEvents lblPartita As System.Windows.Forms.Label
    Friend WithEvents txtPartita As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
End Class
