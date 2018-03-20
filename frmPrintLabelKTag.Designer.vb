<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrintLabelKTag
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
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtNr = New System.Windows.Forms.TextBox()
        Me.lblNr = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 200)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 200)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(0, 67)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(236, 30)
        Me.txtUM.TabIndex = 80
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Yellow
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(1, 43)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(235, 24)
        Me.lblUM.TabIndex = 81
        Me.lblUM.Text = "Unità Magazzino"
        '
        'txtNr
        '
        Me.txtNr.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNr.ForeColor = System.Drawing.Color.Black
        Me.txtNr.Location = New System.Drawing.Point(154, 139)
        Me.txtNr.MaxLength = 10
        Me.txtNr.Name = "txtNr"
        Me.txtNr.Size = New System.Drawing.Size(83, 30)
        Me.txtNr.TabIndex = 82
        '
        'lblNr
        '
        Me.lblNr.BackColor = System.Drawing.Color.Yellow
        Me.lblNr.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNr.ForeColor = System.Drawing.Color.Black
        Me.lblNr.Location = New System.Drawing.Point(154, 115)
        Me.lblNr.Name = "lblNr"
        Me.lblNr.Size = New System.Drawing.Size(83, 24)
        Me.lblNr.TabIndex = 83
        Me.lblNr.Text = "Nr. Copie"
        '
        'frmPrintLabelKTag
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtNr)
        Me.Controls.Add(Me.lblNr)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintLabelKTag"
        Me.Text = "Info Giacenze(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents txtNr As System.Windows.Forms.TextBox
    Friend WithEvents lblNr As System.Windows.Forms.Label
End Class
