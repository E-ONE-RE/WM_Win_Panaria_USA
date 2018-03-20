<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTRASF_MAT_Part_1
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
        Me.txtUM_Origine = New System.Windows.Forms.TextBox()
        Me.lblUM_Origine = New System.Windows.Forms.Label()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMateriale = New System.Windows.Forms.TextBox()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(1, 29)
        Me.txtUbicazioneOrigine.MaxLength = 10
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(185, 30)
        Me.txtUbicazioneOrigine.TabIndex = 7
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(1, 1)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(185, 27)
        Me.lblUbicazioneOrigine.TabIndex = 92
        Me.lblUbicazioneOrigine.Text = "Ubicazione Origine"
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
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 217)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(186, 1)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 55)
        Me.cmdSelectUbicazione.TabIndex = 13
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtUM_Origine
        '
        Me.txtUM_Origine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtUM_Origine.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Origine.Location = New System.Drawing.Point(1, 85)
        Me.txtUM_Origine.MaxLength = 10
        Me.txtUM_Origine.Name = "txtUM_Origine"
        Me.txtUM_Origine.Size = New System.Drawing.Size(237, 32)
        Me.txtUM_Origine.TabIndex = 86
        '
        'lblUM_Origine
        '
        Me.lblUM_Origine.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Origine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Origine.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Origine.Location = New System.Drawing.Point(1, 58)
        Me.lblUM_Origine.Name = "lblUM_Origine"
        Me.lblUM_Origine.Size = New System.Drawing.Size(236, 26)
        Me.lblUM_Origine.TabIndex = 91
        Me.lblUM_Origine.Text = "Unità Magazzino"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 117)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(235, 25)
        Me.lblCodiceMateriale.TabIndex = 0
        Me.lblCodiceMateriale.Text = "Codice Materiale"
        '
        'txtCodiceMateriale
        '
        Me.txtCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMateriale.Location = New System.Drawing.Point(1, 143)
        Me.txtCodiceMateriale.Name = "txtCodiceMateriale"
        Me.txtCodiceMateriale.Size = New System.Drawing.Size(235, 30)
        Me.txtCodiceMateriale.TabIndex = 90
        '
        'txtSKU
        '
        Me.txtSKU.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU.ForeColor = System.Drawing.Color.Black
        Me.txtSKU.Location = New System.Drawing.Point(2, 195)
        Me.txtSKU.MaxLength = 10
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(235, 30)
        Me.txtSKU.TabIndex = 93
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(2, 173)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(235, 23)
        Me.lblSKU.TabIndex = 94
        Me.lblSKU.Text = "SKU"
        '
        'frmTRASF_MAT_Part_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtSKU)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMateriale)
        Me.Controls.Add(Me.txtUM_Origine)
        Me.Controls.Add(Me.lblUM_Origine)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTRASF_MAT_Part_1"
        Me.Text = "TRASF - Mat. (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtUM_Origine As System.Windows.Forms.TextBox
    Friend WithEvents lblUM_Origine As System.Windows.Forms.Label
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMateriale As System.Windows.Forms.TextBox
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
End Class
