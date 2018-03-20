<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_5_ConfirmSKU
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.cmdReject = New System.Windows.Forms.Button()
        Me.lblCheckSKU = New System.Windows.Forms.Label()
        Me.lblTrasfDesc02 = New System.Windows.Forms.Label()
        Me.lblTrasfDesc01 = New System.Windows.Forms.Label()
        Me.lblEscludiTrasf = New System.Windows.Forms.Label()
        Me.ckboxFlagEscludiTrasf = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(12, 648)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtInfoUMSelezionata
        '
        Me.txtInfoUMSelezionata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUMSelezionata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUMSelezionata.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUMSelezionata.Location = New System.Drawing.Point(1, 66)
        Me.txtInfoUMSelezionata.Multiline = True
        Me.txtInfoUMSelezionata.Name = "txtInfoUMSelezionata"
        Me.txtInfoUMSelezionata.ReadOnly = True
        Me.txtInfoUMSelezionata.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUMSelezionata.Size = New System.Drawing.Size(995, 448)
        Me.txtInfoUMSelezionata.TabIndex = 165
        Me.txtInfoUMSelezionata.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(776, 649)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(220, 68)
        Me.cmdOK.TabIndex = 166
        Me.cmdOK.Text = "OK"
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKUBarcode.ForeColor = System.Drawing.Color.Black
        Me.txtSKUBarcode.Location = New System.Drawing.Point(1, 30)
        Me.txtSKUBarcode.MaxLength = 10
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(995, 30)
        Me.txtSKUBarcode.TabIndex = 168
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(995, 28)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "SKU Barcode"
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(8, 524)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(361, 34)
        Me.lblQtaConfermata.TabIndex = 171
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(12, 566)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(361, 28)
        Me.txtQtaConfermata.TabIndex = 170
        '
        'cmdReject
        '
        Me.cmdReject.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdReject.Location = New System.Drawing.Point(528, 648)
        Me.cmdReject.Name = "cmdReject"
        Me.cmdReject.Size = New System.Drawing.Size(220, 68)
        Me.cmdReject.TabIndex = 172
        Me.cmdReject.Text = "Rifiuta"
        '
        'lblCheckSKU
        '
        Me.lblCheckSKU.BackColor = System.Drawing.Color.Red
        Me.lblCheckSKU.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCheckSKU.ForeColor = System.Drawing.Color.Black
        Me.lblCheckSKU.Location = New System.Drawing.Point(541, 603)
        Me.lblCheckSKU.Name = "lblCheckSKU"
        Me.lblCheckSKU.Size = New System.Drawing.Size(436, 41)
        Me.lblCheckSKU.TabIndex = 173
        Me.lblCheckSKU.Text = "SKU ERROR"
        Me.lblCheckSKU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCheckSKU.Visible = False
        '
        'lblTrasfDesc02
        '
        Me.lblTrasfDesc02.BackColor = System.Drawing.Color.Red
        Me.lblTrasfDesc02.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrasfDesc02.ForeColor = System.Drawing.Color.Black
        Me.lblTrasfDesc02.Location = New System.Drawing.Point(541, 561)
        Me.lblTrasfDesc02.Name = "lblTrasfDesc02"
        Me.lblTrasfDesc02.Size = New System.Drawing.Size(436, 38)
        Me.lblTrasfDesc02.TabIndex = 174
        Me.lblTrasfDesc02.Text = "TEST"
        Me.lblTrasfDesc02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTrasfDesc02.Visible = False
        '
        'lblTrasfDesc01
        '
        Me.lblTrasfDesc01.BackColor = System.Drawing.Color.Red
        Me.lblTrasfDesc01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTrasfDesc01.ForeColor = System.Drawing.Color.Black
        Me.lblTrasfDesc01.Location = New System.Drawing.Point(541, 519)
        Me.lblTrasfDesc01.Name = "lblTrasfDesc01"
        Me.lblTrasfDesc01.Size = New System.Drawing.Size(436, 38)
        Me.lblTrasfDesc01.TabIndex = 175
        Me.lblTrasfDesc01.Text = "TEST"
        Me.lblTrasfDesc01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTrasfDesc01.Visible = False
        '
        'lblEscludiTrasf
        '
        Me.lblEscludiTrasf.BackColor = System.Drawing.Color.Yellow
        Me.lblEscludiTrasf.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEscludiTrasf.ForeColor = System.Drawing.Color.Black
        Me.lblEscludiTrasf.Location = New System.Drawing.Point(387, 524)
        Me.lblEscludiTrasf.Name = "lblEscludiTrasf"
        Me.lblEscludiTrasf.Size = New System.Drawing.Size(135, 34)
        Me.lblEscludiTrasf.TabIndex = 176
        Me.lblEscludiTrasf.Text = "Exclude Trans."
        '
        'ckboxFlagEscludiTrasf
        '
        Me.ckboxFlagEscludiTrasf.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ckboxFlagEscludiTrasf.Location = New System.Drawing.Point(391, 566)
        Me.ckboxFlagEscludiTrasf.Name = "ckboxFlagEscludiTrasf"
        Me.ckboxFlagEscludiTrasf.Size = New System.Drawing.Size(123, 27)
        Me.ckboxFlagEscludiTrasf.TabIndex = 206
        Me.ckboxFlagEscludiTrasf.Text = "ECLUDE"
        '
        'frmEM_FromStock_Part_5_ConfirmSKU
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.ckboxFlagEscludiTrasf)
        Me.Controls.Add(Me.lblEscludiTrasf)
        Me.Controls.Add(Me.lblTrasfDesc01)
        Me.Controls.Add(Me.lblTrasfDesc02)
        Me.Controls.Add(Me.lblCheckSKU)
        Me.Controls.Add(Me.cmdReject)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtSKUBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtInfoUMSelezionata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_5_ConfirmSKU"
        Me.Text = "EM - Prod. da Trasf. SKU (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoUMSelezionata As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents cmdReject As System.Windows.Forms.Button
    Friend WithEvents lblCheckSKU As System.Windows.Forms.Label
    Friend WithEvents lblTrasfDesc02 As System.Windows.Forms.Label
    Friend WithEvents lblTrasfDesc01 As System.Windows.Forms.Label
    Friend WithEvents lblEscludiTrasf As System.Windows.Forms.Label
    Friend WithEvents ckboxFlagEscludiTrasf As System.Windows.Forms.CheckBox
End Class
