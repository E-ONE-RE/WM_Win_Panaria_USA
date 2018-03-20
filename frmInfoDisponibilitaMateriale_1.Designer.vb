<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoDisponibilitaMateriale_1
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.cmdSelectCodiceMateriale = New System.Windows.Forms.Button()
        Me.lblPartita = New System.Windows.Forms.Label()
        Me.txtPartita = New System.Windows.Forms.TextBox()
        Me.cmdSelectPartitaMateriale = New System.Windows.Forms.Button()
        Me.txtDivisione = New System.Windows.Forms.ComboBox()
        Me.lblDivisione = New System.Windows.Forms.Label()
        Me.txtMagazzino = New System.Windows.Forms.ComboBox()
        Me.lblMagazzino = New System.Windows.Forms.Label()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 215)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 215)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 4)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(185, 26)
        Me.lblCodiceMateriale.TabIndex = 8
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 30)
        Me.txtCodiceMateriale.MaxLength = 18
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(185, 30)
        Me.txtCodiceMateriale.TabIndex = 0
        '
        'cmdSelectCodiceMateriale
        '
        Me.cmdSelectCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectCodiceMateriale.Location = New System.Drawing.Point(186, 0)
        Me.cmdSelectCodiceMateriale.Name = "cmdSelectCodiceMateriale"
        Me.cmdSelectCodiceMateriale.Size = New System.Drawing.Size(50, 60)
        Me.cmdSelectCodiceMateriale.TabIndex = 1
        Me.cmdSelectCodiceMateriale.Text = "..."
        '
        'lblPartita
        '
        Me.lblPartita.BackColor = System.Drawing.Color.Yellow
        Me.lblPartita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartita.ForeColor = System.Drawing.Color.Black
        Me.lblPartita.Location = New System.Drawing.Point(0, 59)
        Me.lblPartita.Name = "lblPartita"
        Me.lblPartita.Size = New System.Drawing.Size(185, 26)
        Me.lblPartita.TabIndex = 7
        Me.lblPartita.Text = "Partita"
        '
        'txtPartita
        '
        Me.txtPartita.BackColor = System.Drawing.SystemColors.Control
        Me.txtPartita.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartita.ForeColor = System.Drawing.Color.Black
        Me.txtPartita.Location = New System.Drawing.Point(0, 85)
        Me.txtPartita.MaxLength = 10
        Me.txtPartita.Name = "txtPartita"
        Me.txtPartita.ReadOnly = True
        Me.txtPartita.Size = New System.Drawing.Size(185, 30)
        Me.txtPartita.TabIndex = 0
        Me.txtPartita.TabStop = False
        '
        'cmdSelectPartitaMateriale
        '
        Me.cmdSelectPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectPartitaMateriale.Location = New System.Drawing.Point(186, 58)
        Me.cmdSelectPartitaMateriale.Name = "cmdSelectPartitaMateriale"
        Me.cmdSelectPartitaMateriale.Size = New System.Drawing.Size(50, 53)
        Me.cmdSelectPartitaMateriale.TabIndex = 2
        Me.cmdSelectPartitaMateriale.Text = "..."
        '
        'txtDivisione
        '
        Me.txtDivisione.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione.Location = New System.Drawing.Point(-1, 196)
        Me.txtDivisione.Name = "txtDivisione"
        Me.txtDivisione.Size = New System.Drawing.Size(100, 32)
        Me.txtDivisione.TabIndex = 3
        '
        'lblDivisione
        '
        Me.lblDivisione.BackColor = System.Drawing.Color.Yellow
        Me.lblDivisione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDivisione.ForeColor = System.Drawing.Color.Black
        Me.lblDivisione.Location = New System.Drawing.Point(1, 167)
        Me.lblDivisione.Name = "lblDivisione"
        Me.lblDivisione.Size = New System.Drawing.Size(98, 28)
        Me.lblDivisione.TabIndex = 6
        Me.lblDivisione.Text = "Divisione"
        '
        'txtMagazzino
        '
        Me.txtMagazzino.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtMagazzino.Location = New System.Drawing.Point(138, 195)
        Me.txtMagazzino.Name = "txtMagazzino"
        Me.txtMagazzino.Size = New System.Drawing.Size(100, 32)
        Me.txtMagazzino.TabIndex = 4
        '
        'lblMagazzino
        '
        Me.lblMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblMagazzino.Location = New System.Drawing.Point(140, 166)
        Me.lblMagazzino.Name = "lblMagazzino"
        Me.lblMagazzino.Size = New System.Drawing.Size(98, 28)
        Me.lblMagazzino.TabIndex = 5
        Me.lblMagazzino.Text = "Magazzino"
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(1, 136)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(235, 30)
        Me.txtSKU.TabIndex = 38
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(2, 114)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(235, 23)
        Me.lblSKU.TabIndex = 39
        Me.lblSKU.Text = "SKU"
        '
        'frmInfoDisponibilitaMateriale_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.txtMagazzino)
        Me.Controls.Add(Me.lblMagazzino)
        Me.Controls.Add(Me.txtDivisione)
        Me.Controls.Add(Me.lblDivisione)
        Me.Controls.Add(Me.cmdSelectPartitaMateriale)
        Me.Controls.Add(Me.lblPartita)
        Me.Controls.Add(Me.txtPartita)
        Me.Controls.Add(Me.cmdSelectCodiceMateriale)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoDisponibilitaMateriale_1"
        Me.Text = "Info Dispo. Materiale(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectCodiceMateriale As System.Windows.Forms.Button
    Friend WithEvents lblPartita As System.Windows.Forms.Label
    Friend WithEvents txtPartita As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectPartitaMateriale As System.Windows.Forms.Button
    Friend WithEvents txtDivisione As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivisione As System.Windows.Forms.Label
    Friend WithEvents txtMagazzino As System.Windows.Forms.ComboBox
    Friend WithEvents lblMagazzino As System.Windows.Forms.Label
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
End Class
