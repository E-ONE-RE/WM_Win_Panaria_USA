<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJobList_Part_1_Filter
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
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(168, 230)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 54)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 230)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 54)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmbTipoMagazzino
        '
        Me.cmbTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cmbTipoMagazzino.Location = New System.Drawing.Point(-1, 22)
        Me.cmbTipoMagazzino.Name = "cmbTipoMagazzino"
        Me.cmbTipoMagazzino.Size = New System.Drawing.Size(189, 27)
        Me.cmbTipoMagazzino.TabIndex = 13
        '
        'cmdSelectCodiceMateriale
        '
        Me.cmdSelectCodiceMateriale.Enabled = False
        Me.cmdSelectCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectCodiceMateriale.Location = New System.Drawing.Point(188, 57)
        Me.cmdSelectCodiceMateriale.Name = "cmdSelectCodiceMateriale"
        Me.cmdSelectCodiceMateriale.Size = New System.Drawing.Size(49, 56)
        Me.cmdSelectCodiceMateriale.TabIndex = 128
        Me.cmdSelectCodiceMateriale.Text = "..."
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 58)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(187, 23)
        Me.lblCodiceMateriale.TabIndex = 144
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 81)
        Me.txtCodiceMateriale.MaxLength = 18
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(187, 27)
        Me.txtCodiceMateriale.TabIndex = 127
        '
        'cmdSelectPartitaMateriale
        '
        Me.cmdSelectPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectPartitaMateriale.Location = New System.Drawing.Point(188, 116)
        Me.cmdSelectPartitaMateriale.Name = "cmdSelectPartitaMateriale"
        Me.cmdSelectPartitaMateriale.Size = New System.Drawing.Size(49, 53)
        Me.cmdSelectPartitaMateriale.TabIndex = 132
        Me.cmdSelectPartitaMateriale.Text = "..."
        '
        'lblPartitaMateriale
        '
        Me.lblPartitaMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartitaMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblPartitaMateriale.Location = New System.Drawing.Point(1, 116)
        Me.lblPartitaMateriale.Name = "lblPartitaMateriale"
        Me.lblPartitaMateriale.Size = New System.Drawing.Size(187, 22)
        Me.lblPartitaMateriale.TabIndex = 143
        Me.lblPartitaMateriale.Text = "Partita Materiale"
        '
        'txtPartitaMateriale
        '
        Me.txtPartitaMateriale.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtPartitaMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtPartitaMateriale.Location = New System.Drawing.Point(1, 139)
        Me.txtPartitaMateriale.MaxLength = 10
        Me.txtPartitaMateriale.Name = "txtPartitaMateriale"
        Me.txtPartitaMateriale.ReadOnly = True
        Me.txtPartitaMateriale.Size = New System.Drawing.Size(187, 27)
        Me.txtPartitaMateriale.TabIndex = 131
        '
        'lblTipoMagazzino
        '
        Me.lblTipoMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblTipoMagazzino.Location = New System.Drawing.Point(0, 0)
        Me.lblTipoMagazzino.Name = "lblTipoMagazzino"
        Me.lblTipoMagazzino.Size = New System.Drawing.Size(188, 22)
        Me.lblTipoMagazzino.TabIndex = 142
        Me.lblTipoMagazzino.Text = "Tip.Mag."
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(2, 196)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(235, 25)
        Me.txtSKU.TabIndex = 140
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(4, 174)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(232, 23)
        Me.lblSKU.TabIndex = 141
        Me.lblSKU.Text = "SKU"
        '
        'frmEM_FromJobList_Part_1_Filter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
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
        Me.Name = "frmEM_FromJobList_Part_1_Filter"
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
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
End Class
