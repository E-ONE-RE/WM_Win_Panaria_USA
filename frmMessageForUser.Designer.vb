<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMessageForUser
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
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtMessaggio = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(121, 245)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(114, 36)
        Me.cmdOK.TabIndex = 60
        Me.cmdOK.Text = "OK"
        '
        'txtMessaggio
        '
        Me.txtMessaggio.BackColor = System.Drawing.SystemColors.Window
        Me.txtMessaggio.Location = New System.Drawing.Point(1, 0)
        Me.txtMessaggio.Multiline = True
        Me.txtMessaggio.Name = "txtMessaggio"
        Me.txtMessaggio.ReadOnly = True
        Me.txtMessaggio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessaggio.Size = New System.Drawing.Size(239, 242)
        Me.txtMessaggio.TabIndex = 61
        '
        'frmMessageForUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtMessaggio)
        Me.Controls.Add(Me.cmdOK)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessageForUser"
        Me.Text = "Info Utente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtMessaggio As System.Windows.Forms.TextBox
End Class
