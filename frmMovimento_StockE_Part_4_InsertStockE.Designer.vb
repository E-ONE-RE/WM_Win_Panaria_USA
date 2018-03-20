<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMovimento_StockE_Part_4_InsertStockE
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMaterialeEPartita = New System.Windows.Forms.TextBox()
        Me.txtStockSpeciale = New System.Windows.Forms.TextBox()
        Me.lblStockSpeciale = New System.Windows.Forms.Label()
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtDescrizioneMateriale = New System.Windows.Forms.TextBox()
        Me.lblDescrizioneMateriale = New System.Windows.Forms.Label()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(1, 17)
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(238, 20)
        Me.txtUbicazioneOrigine.TabIndex = 57
        Me.txtUbicazioneOrigine.TabStop = False
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 233)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 48)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 233)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdPreviousScreen.TabIndex = 60
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 233)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(1, 0)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(238, 19)
        Me.lblUbicazioneOrigine.TabIndex = 126
        Me.lblUbicazioneOrigine.Text = "Ubicazione"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Transparent
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 42)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(239, 18)
        Me.lblCodiceMateriale.TabIndex = 125
        Me.lblCodiceMateriale.Text = "Cod.Materiale/Partita"
        '
        'txtCodiceMaterialeEPartita
        '
        Me.txtCodiceMaterialeEPartita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCodiceMaterialeEPartita.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceMaterialeEPartita.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMaterialeEPartita.Location = New System.Drawing.Point(1, 60)
        Me.txtCodiceMaterialeEPartita.Name = "txtCodiceMaterialeEPartita"
        Me.txtCodiceMaterialeEPartita.Size = New System.Drawing.Size(239, 20)
        Me.txtCodiceMaterialeEPartita.TabIndex = 85
        Me.txtCodiceMaterialeEPartita.TabStop = False
        '
        'txtStockSpeciale
        '
        Me.txtStockSpeciale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtStockSpeciale.ForeColor = System.Drawing.Color.Black
        Me.txtStockSpeciale.Location = New System.Drawing.Point(1, 196)
        Me.txtStockSpeciale.Name = "txtStockSpeciale"
        Me.txtStockSpeciale.Size = New System.Drawing.Size(239, 25)
        Me.txtStockSpeciale.TabIndex = 97
        Me.txtStockSpeciale.TabStop = False
        '
        'lblStockSpeciale
        '
        Me.lblStockSpeciale.BackColor = System.Drawing.Color.Yellow
        Me.lblStockSpeciale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockSpeciale.ForeColor = System.Drawing.Color.Black
        Me.lblStockSpeciale.Location = New System.Drawing.Point(1, 173)
        Me.lblStockSpeciale.Name = "lblStockSpeciale"
        Me.lblStockSpeciale.Size = New System.Drawing.Size(239, 23)
        Me.lblStockSpeciale.TabIndex = 124
        Me.lblStockSpeciale.Text = "Stock Speciale"
        '
        'txtUM
        '
        Me.txtUM.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUM.Enabled = False
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(115, 145)
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(125, 20)
        Me.txtUM.TabIndex = 101
        Me.txtUM.Visible = False
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Transparent
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(118, 127)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(37, 17)
        Me.lblUM.TabIndex = 123
        Me.lblUM.Text = "UM"
        Me.lblUM.Visible = False
        '
        'txtDescrizioneMateriale
        '
        Me.txtDescrizioneMateriale.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDescrizioneMateriale.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescrizioneMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtDescrizioneMateriale.Location = New System.Drawing.Point(1, 102)
        Me.txtDescrizioneMateriale.Name = "txtDescrizioneMateriale"
        Me.txtDescrizioneMateriale.Size = New System.Drawing.Size(238, 20)
        Me.txtDescrizioneMateriale.TabIndex = 104
        Me.txtDescrizioneMateriale.TabStop = False
        '
        'lblDescrizioneMateriale
        '
        Me.lblDescrizioneMateriale.BackColor = System.Drawing.Color.Transparent
        Me.lblDescrizioneMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescrizioneMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblDescrizioneMateriale.Location = New System.Drawing.Point(1, 85)
        Me.lblDescrizioneMateriale.Name = "lblDescrizioneMateriale"
        Me.lblDescrizioneMateriale.Size = New System.Drawing.Size(238, 18)
        Me.lblDescrizioneMateriale.TabIndex = 122
        Me.lblDescrizioneMateriale.Text = "Descr. Materiale"
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(71, 127)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(42, 15)
        Me.lblUDMQuantita.TabIndex = 0
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(71, 145)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(42, 20)
        Me.txtUDMQuantità.TabIndex = 120
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(0, 126)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(55, 19)
        Me.lblQtaConfermata.TabIndex = 121
        Me.lblQtaConfermata.Text = "Qta"
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(0, 145)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(69, 20)
        Me.txtQtaConfermata.TabIndex = 118
        Me.txtQtaConfermata.TabStop = False
        '
        'frmMovimento_StockE_Part_4_InsertStockE
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.Controls.Add(Me.txtDescrizioneMateriale)
        Me.Controls.Add(Me.lblDescrizioneMateriale)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.lblStockSpeciale)
        Me.Controls.Add(Me.txtStockSpeciale)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMaterialeEPartita)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimento_StockE_Part_4_InsertStockE"
        Me.Text = "Movimento Stock E (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMaterialeEPartita As System.Windows.Forms.TextBox
    Friend WithEvents txtStockSpeciale As System.Windows.Forms.TextBox
    Friend WithEvents lblStockSpeciale As System.Windows.Forms.Label
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents txtDescrizioneMateriale As System.Windows.Forms.TextBox
    Friend WithEvents lblDescrizioneMateriale As System.Windows.Forms.Label
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
End Class
