<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_1_UM
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
        Me.txtUnitaMagazzino = New System.Windows.Forms.TextBox()
        Me.lblUnitaMagazzino = New System.Windows.Forms.Label()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtUnitaMagazzino
        '
        Me.txtUnitaMagazzino.BackColor = System.Drawing.Color.White
        Me.txtUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.txtUnitaMagazzino.Location = New System.Drawing.Point(0, 35)
        Me.txtUnitaMagazzino.MaxLength = 10
        Me.txtUnitaMagazzino.Name = "txtUnitaMagazzino"
        Me.txtUnitaMagazzino.Size = New System.Drawing.Size(237, 30)
        Me.txtUnitaMagazzino.TabIndex = 7
        '
        'lblUnitaMagazzino
        '
        Me.lblUnitaMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblUnitaMagazzino.Location = New System.Drawing.Point(0, 6)
        Me.lblUnitaMagazzino.Name = "lblUnitaMagazzino"
        Me.lblUnitaMagazzino.Size = New System.Drawing.Size(237, 28)
        Me.lblUnitaMagazzino.TabIndex = 11
        Me.lblUnitaMagazzino.Text = "Unità Magazzino"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 202)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 202)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(1, 95)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(235, 30)
        Me.txtSKU.TabIndex = 85
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(2, 73)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(235, 23)
        Me.lblSKU.TabIndex = 86
        Me.lblSKU.Text = "SKU"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(0, 135)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(236, 25)
        Me.lblCodiceMateriale.TabIndex = 88
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(0, 161)
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(236, 30)
        Me.txtCodiceMateriale.TabIndex = 87
        '
        'frmInventarioUbicazione_1_UM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblUnitaMagazzino)
        Me.Controls.Add(Me.txtUnitaMagazzino)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioUbicazione_1_UM"
        Me.Text = "Invent.Ubicazione (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUnitaMagazzino As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitaMagazzino As System.Windows.Forms.Label
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
End Class
