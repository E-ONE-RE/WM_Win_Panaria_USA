<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_StockList_Part_1_Filter
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
        Me.cmbTipoMagazzino = New System.Windows.Forms.ComboBox()
        Me.cmdSelectCodiceMateriale = New System.Windows.Forms.Button()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.cmdSelectPartitaMateriale = New System.Windows.Forms.Button()
        Me.lblPartitaMateriale = New System.Windows.Forms.Label()
        Me.txtPartitaMateriale = New System.Windows.Forms.TextBox()
        Me.lblTipoMagazzino = New System.Windows.Forms.Label()
        Me.txtDivisione_NumeroMag = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 230)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 51)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 230)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 51)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmbTipoMagazzino
        '
        Me.cmbTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cmbTipoMagazzino.Location = New System.Drawing.Point(-1, 60)
        Me.cmbTipoMagazzino.Name = "cmbTipoMagazzino"
        Me.cmbTipoMagazzino.Size = New System.Drawing.Size(236, 27)
        Me.cmbTipoMagazzino.TabIndex = 13
        '
        'cmdSelectCodiceMateriale
        '
        Me.cmdSelectCodiceMateriale.Enabled = False
        Me.cmdSelectCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectCodiceMateriale.Location = New System.Drawing.Point(188, 98)
        Me.cmdSelectCodiceMateriale.Name = "cmdSelectCodiceMateriale"
        Me.cmdSelectCodiceMateriale.Size = New System.Drawing.Size(49, 54)
        Me.cmdSelectCodiceMateriale.TabIndex = 128
        Me.cmdSelectCodiceMateriale.Text = "..."
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 99)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(187, 25)
        Me.lblCodiceMateriale.TabIndex = 138
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 125)
        Me.txtCodiceMateriale.MaxLength = 18
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(187, 27)
        Me.txtCodiceMateriale.TabIndex = 127
        '
        'cmdSelectPartitaMateriale
        '
        Me.cmdSelectPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectPartitaMateriale.Location = New System.Drawing.Point(188, 166)
        Me.cmdSelectPartitaMateriale.Name = "cmdSelectPartitaMateriale"
        Me.cmdSelectPartitaMateriale.Size = New System.Drawing.Size(49, 54)
        Me.cmdSelectPartitaMateriale.TabIndex = 132
        Me.cmdSelectPartitaMateriale.Text = "..."
        '
        'lblPartitaMateriale
        '
        Me.lblPartitaMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartitaMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblPartitaMateriale.Location = New System.Drawing.Point(1, 167)
        Me.lblPartitaMateriale.Name = "lblPartitaMateriale"
        Me.lblPartitaMateriale.Size = New System.Drawing.Size(187, 25)
        Me.lblPartitaMateriale.TabIndex = 137
        Me.lblPartitaMateriale.Text = "Partita Materiale"
        '
        'txtPartitaMateriale
        '
        Me.txtPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPartitaMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtPartitaMateriale.Location = New System.Drawing.Point(1, 193)
        Me.txtPartitaMateriale.MaxLength = 10
        Me.txtPartitaMateriale.Name = "txtPartitaMateriale"
        Me.txtPartitaMateriale.Size = New System.Drawing.Size(187, 27)
        Me.txtPartitaMateriale.TabIndex = 131
        '
        'lblTipoMagazzino
        '
        Me.lblTipoMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblTipoMagazzino.Location = New System.Drawing.Point(0, 34)
        Me.lblTipoMagazzino.Name = "lblTipoMagazzino"
        Me.lblTipoMagazzino.Size = New System.Drawing.Size(236, 25)
        Me.lblTipoMagazzino.TabIndex = 136
        Me.lblTipoMagazzino.Text = "Tipo Magazzino"
        '
        'txtDivisione_NumeroMag
        '
        Me.txtDivisione_NumeroMag.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDivisione_NumeroMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione_NumeroMag.ForeColor = System.Drawing.Color.Black
        Me.txtDivisione_NumeroMag.Location = New System.Drawing.Point(1, 0)
        Me.txtDivisione_NumeroMag.Name = "txtDivisione_NumeroMag"
        Me.txtDivisione_NumeroMag.Size = New System.Drawing.Size(236, 27)
        Me.txtDivisione_NumeroMag.TabIndex = 135
        Me.txtDivisione_NumeroMag.TabStop = False
        '
        'frmEM_StockList_Part_1_Filter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtDivisione_NumeroMag)
        Me.Controls.Add(Me.lblTipoMagazzino)
        Me.Controls.Add(Me.cmdSelectPartitaMateriale)
        Me.Controls.Add(Me.lblPartitaMateriale)
        Me.Controls.Add(Me.txtPartitaMateriale)
        Me.Controls.Add(Me.cmdSelectCodiceMateriale)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.cmbTipoMagazzino)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_StockList_Part_1_Filter"
        Me.Text = "EM - Lista (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmbTipoMagazzino As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSelectCodiceMateriale As System.Windows.Forms.Button
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectPartitaMateriale As System.Windows.Forms.Button
    Friend WithEvents lblPartitaMateriale As System.Windows.Forms.Label
    Friend WithEvents txtPartitaMateriale As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoMagazzino As System.Windows.Forms.Label
    Friend WithEvents txtDivisione_NumeroMag As System.Windows.Forms.TextBox
End Class
