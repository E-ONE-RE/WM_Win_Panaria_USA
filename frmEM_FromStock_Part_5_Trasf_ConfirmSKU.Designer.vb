<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_5_Trasf_ConfirmSKU
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
        Me.txtInfoUMSelezionata = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.txtSKUBarcode = New System.Windows.Forms.TextBox()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.cmdReject = New System.Windows.Forms.Button()
        Me.lblCheckSKU = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(4, 217)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtInfoUMSelezionata
        '
        Me.txtInfoUMSelezionata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUMSelezionata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUMSelezionata.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUMSelezionata.Location = New System.Drawing.Point(1, 57)
        Me.txtInfoUMSelezionata.Multiline = True
        Me.txtInfoUMSelezionata.Name = "txtInfoUMSelezionata"
        Me.txtInfoUMSelezionata.ReadOnly = True
        Me.txtInfoUMSelezionata.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUMSelezionata.Size = New System.Drawing.Size(237, 110)
        Me.txtInfoUMSelezionata.TabIndex = 165
        Me.txtInfoUMSelezionata.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(166, 217)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(68, 60)
        Me.cmdOK.TabIndex = 166
        Me.cmdOK.Text = "OK"
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKUBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtSKUBarcode.Location = New System.Drawing.Point(1, 33)
        Me.txtSKUBarcode.MaxLength = 10
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(236, 30)
        Me.txtSKUBarcode.TabIndex = 168
        '
        'lblSKU
        '
        Me.lblSKU.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU.ForeColor = System.Drawing.Color.Black
        Me.lblSKU.Location = New System.Drawing.Point(1, 2)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(236, 37)
        Me.lblSKU.TabIndex = 169
        Me.lblSKU.Text = "SKU Barcode"
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(1, 170)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(112, 17)
        Me.lblQtaConfermata.TabIndex = 171
        Me.lblQtaConfermata.Text = "Qtà Conf."
        Me.lblQtaConfermata.Visible = False
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(0, 189)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(113, 28)
        Me.txtQtaConfermata.TabIndex = 170
        Me.txtQtaConfermata.Visible = False
        '
        'cmdReject
        '
        Me.cmdReject.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdReject.Location = New System.Drawing.Point(85, 217)
        Me.cmdReject.Name = "cmdReject"
        Me.cmdReject.Size = New System.Drawing.Size(68, 60)
        Me.cmdReject.TabIndex = 172
        Me.cmdReject.Text = "Rifiuta"
        '
        'lblCheckSKU
        '
        Me.lblCheckSKU.BackColor = System.Drawing.Color.Red
        Me.lblCheckSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckSKU.ForeColor = System.Drawing.Color.Black
        Me.lblCheckSKU.Location = New System.Drawing.Point(118, 197)
        Me.lblCheckSKU.Name = "lblCheckSKU"
        Me.lblCheckSKU.Size = New System.Drawing.Size(112, 17)
        Me.lblCheckSKU.TabIndex = 174
        Me.lblCheckSKU.Text = "SKU ERROR"
        Me.lblCheckSKU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCheckSKU.Visible = False
        '
        'frmEM_FromStock_Part_5_Trasf_ConfirmSKU
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblCheckSKU)
        Me.Controls.Add(Me.cmdReject)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtSKUBarcode)
        Me.Controls.Add(Me.lblSKU)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtInfoUMSelezionata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_5_Trasf_ConfirmSKU"
        Me.Text = "EM - Prod. da Trasf. SKU (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoUMSelezionata As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents cmdReject As System.Windows.Forms.Button
    Friend WithEvents lblCheckSKU As System.Windows.Forms.Label
End Class
