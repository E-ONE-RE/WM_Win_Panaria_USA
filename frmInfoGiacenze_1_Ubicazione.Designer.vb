<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoGiacenze_1_Ubicazione
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
        Me.txtUbicazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazione = New System.Windows.Forms.Label()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.txtDivisione = New System.Windows.Forms.ComboBox()
        Me.txtNumMag = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(134, 0)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(101, 28)
        Me.lblNumMag.TabIndex = 49
        Me.lblNumMag.Text = "Num.Mag."
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(165, 210)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 65)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 210)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 65)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblDivisione
        '
        Me.lblDivisione.BackColor = System.Drawing.Color.Yellow
        Me.lblDivisione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDivisione.ForeColor = System.Drawing.Color.Black
        Me.lblDivisione.Location = New System.Drawing.Point(2, 0)
        Me.lblDivisione.Name = "lblDivisione"
        Me.lblDivisione.Size = New System.Drawing.Size(98, 28)
        Me.lblDivisione.TabIndex = 48
        Me.lblDivisione.Text = "Divisione"
        '
        'txtUbicazione
        '
        Me.txtUbicazione.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazione.Location = New System.Drawing.Point(3, 169)
        Me.txtUbicazione.MaxLength = 10
        Me.txtUbicazione.Name = "txtUbicazione"
        Me.txtUbicazione.Size = New System.Drawing.Size(182, 25)
        Me.txtUbicazione.TabIndex = 24
        '
        'lblUbicazione
        '
        Me.lblUbicazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazione.Location = New System.Drawing.Point(3, 141)
        Me.lblUbicazione.Name = "lblUbicazione"
        Me.lblUbicazione.Size = New System.Drawing.Size(182, 28)
        Me.lblUbicazione.TabIndex = 47
        Me.lblUbicazione.Text = "Ubicazione"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(186, 137)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 60)
        Me.cmdSelectUbicazione.TabIndex = 30
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtDivisione
        '
        Me.txtDivisione.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtDivisione.Location = New System.Drawing.Point(0, 29)
        Me.txtDivisione.Name = "txtDivisione"
        Me.txtDivisione.Size = New System.Drawing.Size(100, 27)
        Me.txtDivisione.TabIndex = 41
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(134, 29)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(103, 27)
        Me.txtNumMag.TabIndex = 46
        '
        'frmInfoGiacenze_1_Ubicazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtNumMag)
        Me.Controls.Add(Me.txtDivisione)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazione)
        Me.Controls.Add(Me.lblUbicazione)
        Me.Controls.Add(Me.lblDivisione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblNumMag)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoGiacenze_1_Ubicazione"
        Me.Text = "Info Giacenze(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumMag As System.Windows.Forms.Label
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblDivisione As System.Windows.Forms.Label
    Friend WithEvents txtUbicazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazione As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtDivisione As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumMag As System.Windows.Forms.ComboBox
End Class
