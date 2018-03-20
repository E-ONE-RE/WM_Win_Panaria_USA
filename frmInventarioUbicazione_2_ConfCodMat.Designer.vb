<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_2_ConfCodMat
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
        Me.txtUbicazioneOrigine = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.lblDescrizioneMateriale = New System.Windows.Forms.Label()
        Me.txtDescrizioneMateriale = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblLottoPartita = New System.Windows.Forms.Label()
        Me.txtLottoPartita = New System.Windows.Forms.TextBox()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.cmdSelectCodiceMateriale = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(1, 19)
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.ReadOnly = True
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(238, 22)
        Me.txtUbicazioneOrigine.TabIndex = 7
        Me.txtUbicazioneOrigine.TabStop = False
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(111, 183)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(126, 23)
        Me.lblQtaConfermata.TabIndex = 81
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(111, 207)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(126, 25)
        Me.txtQtaConfermata.TabIndex = 10
        '
        'lblDescrizioneMateriale
        '
        Me.lblDescrizioneMateriale.BackColor = System.Drawing.Color.Transparent
        Me.lblDescrizioneMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescrizioneMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblDescrizioneMateriale.Location = New System.Drawing.Point(3, 137)
        Me.lblDescrizioneMateriale.Name = "lblDescrizioneMateriale"
        Me.lblDescrizioneMateriale.Size = New System.Drawing.Size(160, 20)
        Me.lblDescrizioneMateriale.TabIndex = 80
        Me.lblDescrizioneMateriale.Text = "Descr. Materiale"
        '
        'txtDescrizioneMateriale
        '
        Me.txtDescrizioneMateriale.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescrizioneMateriale.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescrizioneMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtDescrizioneMateriale.Location = New System.Drawing.Point(0, 157)
        Me.txtDescrizioneMateriale.Name = "txtDescrizioneMateriale"
        Me.txtDescrizioneMateriale.ReadOnly = True
        Me.txtDescrizioneMateriale.Size = New System.Drawing.Size(163, 20)
        Me.txtDescrizioneMateriale.TabIndex = 13
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(0, 182)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(112, 25)
        Me.lblQtaPrevista.TabIndex = 79
        Me.lblQtaPrevista.Text = "Qta Stock"
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(0, 207)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(111, 25)
        Me.txtQtaPrevista.TabIndex = 16
        '
        'lblLottoPartita
        '
        Me.lblLottoPartita.BackColor = System.Drawing.Color.Transparent
        Me.lblLottoPartita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLottoPartita.ForeColor = System.Drawing.Color.Black
        Me.lblLottoPartita.Location = New System.Drawing.Point(165, 137)
        Me.lblLottoPartita.Name = "lblLottoPartita"
        Me.lblLottoPartita.Size = New System.Drawing.Size(74, 20)
        Me.lblLottoPartita.TabIndex = 78
        Me.lblLottoPartita.Text = "Lot/Part."
        '
        'txtLottoPartita
        '
        Me.txtLottoPartita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLottoPartita.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtLottoPartita.ForeColor = System.Drawing.Color.Black
        Me.txtLottoPartita.Location = New System.Drawing.Point(165, 157)
        Me.txtLottoPartita.Name = "txtLottoPartita"
        Me.txtLottoPartita.ReadOnly = True
        Me.txtLottoPartita.Size = New System.Drawing.Size(74, 20)
        Me.txtLottoPartita.TabIndex = 19
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 46)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(188, 25)
        Me.lblCodiceMateriale.TabIndex = 77
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 72)
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(188, 25)
        Me.txtCodiceMateriale.TabIndex = 28
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 236)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 47)
        Me.cmdNextScreen.TabIndex = 41
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 236)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 47)
        Me.cmdPreviousScreen.TabIndex = 43
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 236)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(76, 47)
        Me.cmdAbortScreen.TabIndex = 44
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Yellow
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(1, 107)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(39, 25)
        Me.lblUM.TabIndex = 76
        Me.lblUM.Text = "UM"
        '
        'txtUM
        '
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(41, 106)
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(198, 20)
        Me.txtUM.TabIndex = 47
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(1, 0)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(238, 19)
        Me.lblUbicazioneOrigine.TabIndex = 75
        Me.lblUbicazioneOrigine.Text = "Ubicazione Origine"
        '
        'cmdSelectCodiceMateriale
        '
        Me.cmdSelectCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectCodiceMateriale.Location = New System.Drawing.Point(189, 45)
        Me.cmdSelectCodiceMateriale.Name = "cmdSelectCodiceMateriale"
        Me.cmdSelectCodiceMateriale.Size = New System.Drawing.Size(50, 60)
        Me.cmdSelectCodiceMateriale.TabIndex = 74
        Me.cmdSelectCodiceMateriale.Text = "..."
        '
        'frmInventarioUbicazione_2_ConfCodMat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdSelectCodiceMateriale)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.lblLottoPartita)
        Me.Controls.Add(Me.txtLottoPartita)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.lblDescrizioneMateriale)
        Me.Controls.Add(Me.txtDescrizioneMateriale)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioUbicazione_2_ConfCodMat"
        Me.Text = "Invent.Ubicazione (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblDescrizioneMateriale As System.Windows.Forms.Label
    Friend WithEvents txtDescrizioneMateriale As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblLottoPartita As System.Windows.Forms.Label
    Friend WithEvents txtLottoPartita As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents cmdSelectCodiceMateriale As System.Windows.Forms.Button
End Class
