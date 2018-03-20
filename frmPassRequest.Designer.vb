<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPassRequest
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
        Me.lblPassRequested = New System.Windows.Forms.Label()
        Me.txtPassRequested = New System.Windows.Forms.TextBox()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPassRequested
        '
        Me.lblPassRequested.BackColor = System.Drawing.Color.Yellow
        Me.lblPassRequested.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassRequested.ForeColor = System.Drawing.Color.Black
        Me.lblPassRequested.Location = New System.Drawing.Point(0, 28)
        Me.lblPassRequested.Name = "lblPassRequested"
        Me.lblPassRequested.Size = New System.Drawing.Size(235, 25)
        Me.lblPassRequested.TabIndex = 94
        Me.lblPassRequested.Text = "Internal Password"
        '
        'txtPassRequested
        '
        Me.txtPassRequested.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPassRequested.ForeColor = System.Drawing.Color.Black
        Me.txtPassRequested.Location = New System.Drawing.Point(-1, 54)
        Me.txtPassRequested.MaxLength = 14
        Me.txtPassRequested.Name = "txtPassRequested"
        Me.txtPassRequested.Size = New System.Drawing.Size(237, 30)
        Me.txtPassRequested.TabIndex = 9
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 90)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 80)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(-1, 90)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 80)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'frmPassRequest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 176)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.txtPassRequested)
        Me.Controls.Add(Me.lblPassRequested)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPassRequest"
        Me.Text = "Pass-Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPassRequested As System.Windows.Forms.Label
    Friend WithEvents txtPassRequested As System.Windows.Forms.TextBox
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
