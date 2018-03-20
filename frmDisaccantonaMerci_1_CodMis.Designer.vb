<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDisaccantonaMerci_1_CodMis
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.txtNrWmsJobs = New System.Windows.Forms.TextBox()
        Me.lblNrWmsJobs = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 230)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 230)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = ">"
        '
        'txtNrWmsJobs
        '
        Me.txtNrWmsJobs.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNrWmsJobs.ForeColor = System.Drawing.Color.Black
        Me.txtNrWmsJobs.Location = New System.Drawing.Point(0, 107)
        Me.txtNrWmsJobs.Name = "txtNrWmsJobs"
        Me.txtNrWmsJobs.Size = New System.Drawing.Size(237, 25)
        Me.txtNrWmsJobs.TabIndex = 87
        '
        'lblNrWmsJobs
        '
        Me.lblNrWmsJobs.BackColor = System.Drawing.Color.Yellow
        Me.lblNrWmsJobs.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNrWmsJobs.ForeColor = System.Drawing.Color.Black
        Me.lblNrWmsJobs.Location = New System.Drawing.Point(0, 61)
        Me.lblNrWmsJobs.Name = "lblNrWmsJobs"
        Me.lblNrWmsJobs.Size = New System.Drawing.Size(237, 46)
        Me.lblNrWmsJobs.TabIndex = 88
        Me.lblNrWmsJobs.Text = "Gruppo Missioni"
        '
        'frmDisaccantonaMerci_1_CodMis
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.txtNrWmsJobs)
        Me.Controls.Add(Me.lblNrWmsJobs)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDisaccantonaMerci_1_CodMis"
        Me.Text = "Disaccant.(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtNrWmsJobs As System.Windows.Forms.TextBox
    Friend WithEvents lblNrWmsJobs As System.Windows.Forms.Label
End Class
