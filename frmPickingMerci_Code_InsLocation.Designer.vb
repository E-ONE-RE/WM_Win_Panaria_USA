<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_InsLocation
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
        Me.txtUM01 = New System.Windows.Forms.TextBox()
        Me.lblUBI01 = New System.Windows.Forms.Label()
        Me.txtUM02 = New System.Windows.Forms.TextBox()
        Me.lblUbi02 = New System.Windows.Forms.Label()
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
        'txtUM01
        '
        Me.txtUM01.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM01.ForeColor = System.Drawing.Color.Black
        Me.txtUM01.Location = New System.Drawing.Point(0, 67)
        Me.txtUM01.MaxLength = 10
        Me.txtUM01.Name = "txtUM01"
        Me.txtUM01.Size = New System.Drawing.Size(236, 30)
        Me.txtUM01.TabIndex = 80
        '
        'lblUBI01
        '
        Me.lblUBI01.BackColor = System.Drawing.Color.Yellow
        Me.lblUBI01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUBI01.ForeColor = System.Drawing.Color.Black
        Me.lblUBI01.Location = New System.Drawing.Point(1, 43)
        Me.lblUBI01.Name = "lblUBI01"
        Me.lblUBI01.Size = New System.Drawing.Size(235, 24)
        Me.lblUBI01.TabIndex = 81
        Me.lblUBI01.Text = "Locazione"
        '
        'txtUM02
        '
        Me.txtUM02.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM02.ForeColor = System.Drawing.Color.Black
        Me.txtUM02.Location = New System.Drawing.Point(0, 156)
        Me.txtUM02.MaxLength = 10
        Me.txtUM02.Name = "txtUM02"
        Me.txtUM02.Size = New System.Drawing.Size(236, 30)
        Me.txtUM02.TabIndex = 82
        '
        'lblUbi02
        '
        Me.lblUbi02.BackColor = System.Drawing.Color.Yellow
        Me.lblUbi02.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbi02.ForeColor = System.Drawing.Color.Black
        Me.lblUbi02.Location = New System.Drawing.Point(1, 131)
        Me.lblUbi02.Name = "lblUbi02"
        Me.lblUbi02.Size = New System.Drawing.Size(235, 24)
        Me.lblUbi02.TabIndex = 83
        Me.lblUbi02.Text = "Locazione"
        '
        'frmPickingMerci_Code_InsLocation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblUbi02)
        Me.Controls.Add(Me.txtUM02)
        Me.Controls.Add(Me.txtUM01)
        Me.Controls.Add(Me.lblUBI01)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_InsLocation"
        Me.Text = "Info Giacenze(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM01 As System.Windows.Forms.TextBox
    Friend WithEvents lblUBI01 As System.Windows.Forms.Label
    Friend WithEvents txtUM02 As System.Windows.Forms.TextBox
    Friend WithEvents lblUbi02 As System.Windows.Forms.Label
End Class
