<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_1_UbicazioneUM
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
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.txtNumMag = New System.Windows.Forms.ComboBox()
        Me.txtDivisione = New System.Windows.Forms.ComboBox()
        Me.lblDivisione = New System.Windows.Forms.Label()
        Me.lblNumMag = New System.Windows.Forms.Label()
        Me.lblUnitaMagazzino = New System.Windows.Forms.Label()
        Me.txtUnitaMagazzino = New System.Windows.Forms.TextBox()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.Color.White
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(0, 68)
        Me.txtUbicazioneOrigine.MaxLength = 10
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(185, 30)
        Me.txtUbicazioneOrigine.TabIndex = 7
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(0, 49)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(185, 18)
        Me.lblUbicazioneOrigine.TabIndex = 62
        Me.lblUbicazioneOrigine.Text = "Ubicazione Origine"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 212)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 64)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 212)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 64)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(186, 49)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 33)
        Me.cmdSelectUbicazione.TabIndex = 13
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(133, 27)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(103, 32)
        Me.txtNumMag.TabIndex = 54
        '
        'txtDivisione
        '
        Me.txtDivisione.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione.Location = New System.Drawing.Point(0, 27)
        Me.txtDivisione.Name = "txtDivisione"
        Me.txtDivisione.Size = New System.Drawing.Size(100, 32)
        Me.txtDivisione.TabIndex = 53
        '
        'lblDivisione
        '
        Me.lblDivisione.BackColor = System.Drawing.Color.Yellow
        Me.lblDivisione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDivisione.ForeColor = System.Drawing.Color.Black
        Me.lblDivisione.Location = New System.Drawing.Point(2, -2)
        Me.lblDivisione.Name = "lblDivisione"
        Me.lblDivisione.Size = New System.Drawing.Size(98, 28)
        Me.lblDivisione.TabIndex = 60
        Me.lblDivisione.Text = "Divisione"
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(133, -2)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(101, 28)
        Me.lblNumMag.TabIndex = 61
        Me.lblNumMag.Text = "Num.Mag."
        '
        'lblUnitaMagazzino
        '
        Me.lblUnitaMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblUnitaMagazzino.Location = New System.Drawing.Point(0, 89)
        Me.lblUnitaMagazzino.Name = "lblUnitaMagazzino"
        Me.lblUnitaMagazzino.Size = New System.Drawing.Size(234, 18)
        Me.lblUnitaMagazzino.TabIndex = 0
        Me.lblUnitaMagazzino.Text = "Unità Magazzino"
        '
        'txtUnitaMagazzino
        '
        Me.txtUnitaMagazzino.BackColor = System.Drawing.Color.White
        Me.txtUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.txtUnitaMagazzino.Location = New System.Drawing.Point(0, 108)
        Me.txtUnitaMagazzino.MaxLength = 10
        Me.txtUnitaMagazzino.Name = "txtUnitaMagazzino"
        Me.txtUnitaMagazzino.Size = New System.Drawing.Size(234, 30)
        Me.txtUnitaMagazzino.TabIndex = 59
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(0, 190)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(234, 30)
        Me.txtSKU.TabIndex = 87
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(0, 172)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(234, 18)
        Me.lblSKU.TabIndex = 88
        Me.lblSKU.Text = "SKU"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(0, 130)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(234, 18)
        Me.lblCodiceMateriale.TabIndex = 90
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(0, 149)
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(234, 30)
        Me.txtCodiceMateriale.TabIndex = 89
        '
        'frmInventarioUbicazione_1_UbicazioneUM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.lblUnitaMagazzino)
        Me.Controls.Add(Me.txtUnitaMagazzino)
        Me.Controls.Add(Me.txtNumMag)
        Me.Controls.Add(Me.txtDivisione)
        Me.Controls.Add(Me.lblDivisione)
        Me.Controls.Add(Me.lblNumMag)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioUbicazione_1_UbicazioneUM"
        Me.Text = "Invent.Ubicazione (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtNumMag As System.Windows.Forms.ComboBox
    Friend WithEvents txtDivisione As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivisione As System.Windows.Forms.Label
    Friend WithEvents lblNumMag As System.Windows.Forms.Label
    Friend WithEvents lblUnitaMagazzino As System.Windows.Forms.Label
    Friend WithEvents txtUnitaMagazzino As System.Windows.Forms.TextBox
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
End Class
