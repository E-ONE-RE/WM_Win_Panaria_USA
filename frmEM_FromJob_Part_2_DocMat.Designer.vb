<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_2_DocMat
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
        Me.lblPosDocMateriale = New System.Windows.Forms.Label()
        Me.txtDocMateriale = New System.Windows.Forms.TextBox()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblPosDocMaterialeHelp = New System.Windows.Forms.Label()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPosDocMateriale
        '
        Me.lblPosDocMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblPosDocMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosDocMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblPosDocMateriale.Location = New System.Drawing.Point(1, 40)
        Me.lblPosDocMateriale.Name = "lblPosDocMateriale"
        Me.lblPosDocMateriale.Size = New System.Drawing.Size(235, 25)
        Me.lblPosDocMateriale.TabIndex = 94
        Me.lblPosDocMateriale.Text = "Barcode BEM"
        '
        'txtDocMateriale
        '
        Me.txtDocMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtDocMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtDocMateriale.Location = New System.Drawing.Point(0, 90)
        Me.txtDocMateriale.MaxLength = 14
        Me.txtDocMateriale.Name = "txtDocMateriale"
        Me.txtDocMateriale.Size = New System.Drawing.Size(237, 25)
        Me.txtDocMateriale.TabIndex = 9
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 198)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 80)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 198)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 80)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblPosDocMaterialeHelp
        '
        Me.lblPosDocMaterialeHelp.BackColor = System.Drawing.Color.Yellow
        Me.lblPosDocMaterialeHelp.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosDocMaterialeHelp.ForeColor = System.Drawing.Color.Black
        Me.lblPosDocMaterialeHelp.Location = New System.Drawing.Point(1, 65)
        Me.lblPosDocMaterialeHelp.Name = "lblPosDocMaterialeHelp"
        Me.lblPosDocMaterialeHelp.Size = New System.Drawing.Size(235, 25)
        Me.lblPosDocMaterialeHelp.TabIndex = 93
        Me.lblPosDocMaterialeHelp.Text = "(ANNO+DOC.MAT)"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(98, 198)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(64, 80)
        Me.cmdPreviousScreen.TabIndex = 92
        Me.cmdPreviousScreen.Text = "<"
        '
        'frmEM_FromJob_Part_2_DocMat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.lblPosDocMaterialeHelp)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.txtDocMateriale)
        Me.Controls.Add(Me.lblPosDocMateriale)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_2_DocMat"
        Me.Text = "EM - Bem (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPosDocMateriale As System.Windows.Forms.Label
    Friend WithEvents txtDocMateriale As System.Windows.Forms.TextBox
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblPosDocMaterialeHelp As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
End Class
