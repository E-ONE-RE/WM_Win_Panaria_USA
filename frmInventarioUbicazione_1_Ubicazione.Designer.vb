<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_1_Ubicazione
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
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.Color.White
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(0, 126)
        Me.txtUbicazioneOrigine.MaxLength = 10
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(189, 25)
        Me.txtUbicazioneOrigine.TabIndex = 7
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(0, 97)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(188, 28)
        Me.lblUbicazioneOrigine.TabIndex = 57
        Me.lblUbicazioneOrigine.Text = "Ubicazione Origine"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 198)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 198)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(188, 96)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 55)
        Me.cmdSelectUbicazione.TabIndex = 13
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(135, 31)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(103, 27)
        Me.txtNumMag.TabIndex = 54
        '
        'txtDivisione
        '
        Me.txtDivisione.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione.Location = New System.Drawing.Point(0, 31)
        Me.txtDivisione.Name = "txtDivisione"
        Me.txtDivisione.Size = New System.Drawing.Size(100, 27)
        Me.txtDivisione.TabIndex = 53
        '
        'lblDivisione
        '
        Me.lblDivisione.BackColor = System.Drawing.Color.Yellow
        Me.lblDivisione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDivisione.ForeColor = System.Drawing.Color.Black
        Me.lblDivisione.Location = New System.Drawing.Point(2, 2)
        Me.lblDivisione.Name = "lblDivisione"
        Me.lblDivisione.Size = New System.Drawing.Size(98, 28)
        Me.lblDivisione.TabIndex = 55
        Me.lblDivisione.Text = "Divisione"
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(135, 2)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(101, 28)
        Me.lblNumMag.TabIndex = 56
        Me.lblNumMag.Text = "Num.Mag."
        '
        'frmInventarioUbicazione_1_Ubicazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
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
        Me.Name = "frmInventarioUbicazione_1_Ubicazione"
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
End Class
