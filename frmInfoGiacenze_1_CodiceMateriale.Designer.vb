<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoGiacenze_1_CodiceMateriale
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
        Me.lblNumMag = New System.Windows.Forms.Label()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblDivisione = New System.Windows.Forms.Label()
        Me.cmdSelectCodiceMateriale = New System.Windows.Forms.Button()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.txtNumMag = New System.Windows.Forms.ComboBox()
        Me.txtDivisione = New System.Windows.Forms.ComboBox()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.cmdSelectPartitaMateriale = New System.Windows.Forms.Button()
        Me.lblPartita = New System.Windows.Forms.Label()
        Me.txtPartita = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(133, 1)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(103, 19)
        Me.lblNumMag.TabIndex = 40
        Me.lblNumMag.Text = "Num.Mag."
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 223)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 61)
        Me.cmdNextScreen.TabIndex = 6
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 223)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 61)
        Me.cmdAbortScreen.TabIndex = 7
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblDivisione
        '
        Me.lblDivisione.BackColor = System.Drawing.Color.Yellow
        Me.lblDivisione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDivisione.ForeColor = System.Drawing.Color.Black
        Me.lblDivisione.Location = New System.Drawing.Point(1, 1)
        Me.lblDivisione.Name = "lblDivisione"
        Me.lblDivisione.Size = New System.Drawing.Size(99, 19)
        Me.lblDivisione.TabIndex = 39
        Me.lblDivisione.Text = "Divisione"
        '
        'cmdSelectCodiceMateriale
        '
        Me.cmdSelectCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectCodiceMateriale.Location = New System.Drawing.Point(187, 55)
        Me.cmdSelectCodiceMateriale.Name = "cmdSelectCodiceMateriale"
        Me.cmdSelectCodiceMateriale.Size = New System.Drawing.Size(50, 54)
        Me.cmdSelectCodiceMateriale.TabIndex = 3
        Me.cmdSelectCodiceMateriale.Text = "..."
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 57)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(185, 23)
        Me.lblCodiceMateriale.TabIndex = 38
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 80)
        Me.txtCodiceMateriale.MaxLength = 18
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(185, 25)
        Me.txtCodiceMateriale.TabIndex = 2
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(133, 21)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(103, 27)
        Me.txtNumMag.TabIndex = 1
        '
        'txtDivisione
        '
        Me.txtDivisione.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione.Location = New System.Drawing.Point(0, 21)
        Me.txtDivisione.Name = "txtDivisione"
        Me.txtDivisione.Size = New System.Drawing.Size(100, 27)
        Me.txtDivisione.TabIndex = 0
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(2, 192)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(235, 25)
        Me.txtSKU.TabIndex = 5
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(2, 170)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(235, 23)
        Me.lblSKU.TabIndex = 37
        Me.lblSKU.Text = "SKU"
        '
        'cmdSelectPartitaMateriale
        '
        Me.cmdSelectPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectPartitaMateriale.Location = New System.Drawing.Point(187, 113)
        Me.cmdSelectPartitaMateriale.Name = "cmdSelectPartitaMateriale"
        Me.cmdSelectPartitaMateriale.Size = New System.Drawing.Size(50, 53)
        Me.cmdSelectPartitaMateriale.TabIndex = 4
        Me.cmdSelectPartitaMateriale.Text = "..."
        '
        'lblPartita
        '
        Me.lblPartita.BackColor = System.Drawing.Color.Yellow
        Me.lblPartita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartita.ForeColor = System.Drawing.Color.Black
        Me.lblPartita.Location = New System.Drawing.Point(1, 116)
        Me.lblPartita.Name = "lblPartita"
        Me.lblPartita.Size = New System.Drawing.Size(185, 23)
        Me.lblPartita.TabIndex = 5
        Me.lblPartita.Text = "Partita"
        '
        'txtPartita
        '
        Me.txtPartita.BackColor = System.Drawing.SystemColors.Control
        Me.txtPartita.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartita.ForeColor = System.Drawing.Color.Black
        Me.txtPartita.Location = New System.Drawing.Point(1, 140)
        Me.txtPartita.MaxLength = 10
        Me.txtPartita.Name = "txtPartita"
        Me.txtPartita.ReadOnly = True
        Me.txtPartita.Size = New System.Drawing.Size(185, 25)
        Me.txtPartita.TabIndex = 36
        Me.txtPartita.TabStop = False
        '
        'frmInfoGiacenze_1_CodiceMateriale
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdSelectPartitaMateriale)
        Me.Controls.Add(Me.lblPartita)
        Me.Controls.Add(Me.txtPartita)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.txtNumMag)
        Me.Controls.Add(Me.txtDivisione)
        Me.Controls.Add(Me.cmdSelectCodiceMateriale)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.lblDivisione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblNumMag)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoGiacenze_1_CodiceMateriale"
        Me.Text = "Info Giacenze(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumMag As System.Windows.Forms.Label
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblDivisione As System.Windows.Forms.Label
    Friend WithEvents cmdSelectCodiceMateriale As System.Windows.Forms.Button
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
    Friend WithEvents txtNumMag As System.Windows.Forms.ComboBox
    Friend WithEvents txtDivisione As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents cmdSelectPartitaMateriale As System.Windows.Forms.Button
    Friend WithEvents lblPartita As System.Windows.Forms.Label
    Friend WithEvents txtPartita As System.Windows.Forms.TextBox
End Class
