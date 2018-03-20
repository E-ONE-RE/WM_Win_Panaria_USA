<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_1_Odp
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
        Me.txtNumOrdineProd = New System.Windows.Forms.TextBox()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPosDocMateriale
        '
        Me.lblPosDocMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblPosDocMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosDocMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblPosDocMateriale.Location = New System.Drawing.Point(1, 40)
        Me.lblPosDocMateriale.Name = "lblPosDocMateriale"
        Me.lblPosDocMateriale.Size = New System.Drawing.Size(236, 28)
        Me.lblPosDocMateriale.TabIndex = 13
        Me.lblPosDocMateriale.Text = "N° Ordine Di Produzione"
        '
        'txtNumOrdineProd
        '
        Me.txtNumOrdineProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumOrdineProd.ForeColor = System.Drawing.Color.Black
        Me.txtNumOrdineProd.Location = New System.Drawing.Point(1, 68)
        Me.txtNumOrdineProd.MaxLength = 12
        Me.txtNumOrdineProd.Name = "txtNumOrdineProd"
        Me.txtNumOrdineProd.Size = New System.Drawing.Size(236, 25)
        Me.txtNumOrdineProd.TabIndex = 9
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 183)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 183)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'frmEM_FromStock_Part_1_Odp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.txtNumOrdineProd)
        Me.Controls.Add(Me.lblPosDocMateriale)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_1_Odp"
        Me.Text = "EM - Produzione (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPosDocMateriale As System.Windows.Forms.Label
    Friend WithEvents txtNumOrdineProd As System.Windows.Forms.TextBox
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
