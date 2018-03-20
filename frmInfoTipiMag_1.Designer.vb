<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoTipiMag_1
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
        Me.txtTipiMag = New System.Windows.Forms.TextBox()
        Me.lblTipiMag = New System.Windows.Forms.Label()
        Me.txtNumMag = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(1, 48)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(236, 20)
        Me.lblNumMag.TabIndex = 4
        Me.lblNumMag.Text = "Numero Magazzino"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 204)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdNextScreen.TabIndex = 2
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 204)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdAbortScreen.TabIndex = 3
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtTipiMag
        '
        Me.txtTipiMag.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTipiMag.ForeColor = System.Drawing.Color.Black
        Me.txtTipiMag.Location = New System.Drawing.Point(1, 143)
        Me.txtTipiMag.MaxLength = 3
        Me.txtTipiMag.Name = "txtTipiMag"
        Me.txtTipiMag.Size = New System.Drawing.Size(236, 25)
        Me.txtTipiMag.TabIndex = 1
        '
        'lblTipiMag
        '
        Me.lblTipiMag.BackColor = System.Drawing.Color.Yellow
        Me.lblTipiMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipiMag.ForeColor = System.Drawing.Color.Black
        Me.lblTipiMag.Location = New System.Drawing.Point(1, 122)
        Me.lblTipiMag.Name = "lblTipiMag"
        Me.lblTipiMag.Size = New System.Drawing.Size(236, 20)
        Me.lblTipiMag.TabIndex = 2
        Me.lblTipiMag.Text = "Tipo Magazzino"
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(0, 69)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(237, 27)
        Me.txtNumMag.TabIndex = 0
        '
        'frmInfoTipiMag_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtNumMag)
        Me.Controls.Add(Me.txtTipiMag)
        Me.Controls.Add(Me.lblTipiMag)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblNumMag)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoTipiMag_1"
        Me.Text = "Info Tipi Mag.(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumMag As System.Windows.Forms.Label
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtTipiMag As System.Windows.Forms.TextBox
    Friend WithEvents lblTipiMag As System.Windows.Forms.Label
    Friend WithEvents txtNumMag As System.Windows.Forms.ComboBox
End Class
