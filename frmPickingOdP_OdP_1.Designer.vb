<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingOdP_OdP_1
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
        Me.txtNumOrdineProd = New System.Windows.Forms.TextBox()
        Me.lblOdP = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 206)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 206)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtNumOrdineProd
        '
        Me.txtNumOrdineProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumOrdineProd.ForeColor = System.Drawing.Color.Black
        Me.txtNumOrdineProd.Location = New System.Drawing.Point(1, 101)
        Me.txtNumOrdineProd.MaxLength = 10
        Me.txtNumOrdineProd.Name = "txtNumOrdineProd"
        Me.txtNumOrdineProd.Size = New System.Drawing.Size(238, 25)
        Me.txtNumOrdineProd.TabIndex = 14
        '
        'lblOdP
        '
        Me.lblOdP.BackColor = System.Drawing.Color.Yellow
        Me.lblOdP.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblOdP.ForeColor = System.Drawing.Color.Black
        Me.lblOdP.Location = New System.Drawing.Point(1, 73)
        Me.lblOdP.Name = "lblOdP"
        Me.lblOdP.Size = New System.Drawing.Size(238, 28)
        Me.lblOdP.TabIndex = 15
        Me.lblOdP.Text = "N° Ord. Prod."
        '
        'frmPickingOdP_OdP_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(240, 285)
        Me.Controls.Add(Me.txtNumOrdineProd)
        Me.Controls.Add(Me.lblOdP)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingOdP_OdP_1"
        Me.Text = "Picking - OdP (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtNumOrdineProd As System.Windows.Forms.TextBox
    Friend WithEvents lblOdP As System.Windows.Forms.Label
End Class
