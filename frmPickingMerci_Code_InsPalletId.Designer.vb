<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_InsPalletId
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
        Me.lblUM01 = New System.Windows.Forms.Label()
        Me.txtUM02 = New System.Windows.Forms.TextBox()
        Me.lblUM02 = New System.Windows.Forms.Label()
        Me.txtSKU01 = New System.Windows.Forms.TextBox()
        Me.lblSKU01 = New System.Windows.Forms.Label()
        Me.txtSKU02 = New System.Windows.Forms.TextBox()
        Me.lblSKU02 = New System.Windows.Forms.Label()
        Me.DtGridStockInfo = New System.Windows.Forms.DataGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPartialPallet = New System.Windows.Forms.Button()
        Me.btnWrongPallet = New System.Windows.Forms.Button()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(844, 621)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(141, 87)
        Me.cmdNextScreen.TabIndex = 8
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(21, 621)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(130, 87)
        Me.cmdAbortScreen.TabIndex = 5
        Me.cmdAbortScreen.Text = "CANCEL"
        '
        'txtUM01
        '
        Me.txtUM01.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM01.ForeColor = System.Drawing.Color.Black
        Me.txtUM01.Location = New System.Drawing.Point(0, 71)
        Me.txtUM01.MaxLength = 10
        Me.txtUM01.Name = "txtUM01"
        Me.txtUM01.Size = New System.Drawing.Size(236, 30)
        Me.txtUM01.TabIndex = 1
        '
        'lblUM01
        '
        Me.lblUM01.BackColor = System.Drawing.Color.Yellow
        Me.lblUM01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM01.ForeColor = System.Drawing.Color.Black
        Me.lblUM01.Location = New System.Drawing.Point(1, 47)
        Me.lblUM01.Name = "lblUM01"
        Me.lblUM01.Size = New System.Drawing.Size(235, 24)
        Me.lblUM01.TabIndex = 81
        Me.lblUM01.Text = "Pallet ID"
        '
        'txtUM02
        '
        Me.txtUM02.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM02.ForeColor = System.Drawing.Color.Black
        Me.txtUM02.Location = New System.Drawing.Point(0, 161)
        Me.txtUM02.MaxLength = 10
        Me.txtUM02.Name = "txtUM02"
        Me.txtUM02.Size = New System.Drawing.Size(236, 30)
        Me.txtUM02.TabIndex = 2
        '
        'lblUM02
        '
        Me.lblUM02.BackColor = System.Drawing.Color.Yellow
        Me.lblUM02.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM02.ForeColor = System.Drawing.Color.Black
        Me.lblUM02.Location = New System.Drawing.Point(1, 137)
        Me.lblUM02.Name = "lblUM02"
        Me.lblUM02.Size = New System.Drawing.Size(235, 24)
        Me.lblUM02.TabIndex = 83
        Me.lblUM02.Text = "Pallet ID"
        '
        'txtSKU01
        '
        Me.txtSKU01.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU01.ForeColor = System.Drawing.Color.Black
        Me.txtSKU01.Location = New System.Drawing.Point(0, 271)
        Me.txtSKU01.MaxLength = 10
        Me.txtSKU01.Name = "txtSKU01"
        Me.txtSKU01.Size = New System.Drawing.Size(236, 30)
        Me.txtSKU01.TabIndex = 3
        '
        'lblSKU01
        '
        Me.lblSKU01.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU01.ForeColor = System.Drawing.Color.Black
        Me.lblSKU01.Location = New System.Drawing.Point(1, 247)
        Me.lblSKU01.Name = "lblSKU01"
        Me.lblSKU01.Size = New System.Drawing.Size(235, 24)
        Me.lblSKU01.TabIndex = 85
        Me.lblSKU01.Text = "SKU"
        '
        'txtSKU02
        '
        Me.txtSKU02.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtSKU02.ForeColor = System.Drawing.Color.Black
        Me.txtSKU02.Location = New System.Drawing.Point(0, 363)
        Me.txtSKU02.MaxLength = 10
        Me.txtSKU02.Name = "txtSKU02"
        Me.txtSKU02.Size = New System.Drawing.Size(236, 30)
        Me.txtSKU02.TabIndex = 4
        '
        'lblSKU02
        '
        Me.lblSKU02.BackColor = System.Drawing.Color.Yellow
        Me.lblSKU02.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSKU02.ForeColor = System.Drawing.Color.Black
        Me.lblSKU02.Location = New System.Drawing.Point(1, 339)
        Me.lblSKU02.Name = "lblSKU02"
        Me.lblSKU02.Size = New System.Drawing.Size(235, 24)
        Me.lblSKU02.TabIndex = 87
        Me.lblSKU02.Text = "SKU"
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtGridStockInfo.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(262, 71)
        Me.DtGridStockInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.ReadOnly = True
        Me.DtGridStockInfo.Size = New System.Drawing.Size(737, 451)
        Me.DtGridStockInfo.TabIndex = 180
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(262, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(734, 24)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Location Stock"
        '
        'btnPartialPallet
        '
        Me.btnPartialPallet.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPartialPallet.Location = New System.Drawing.Point(235, 621)
        Me.btnPartialPallet.Name = "btnPartialPallet"
        Me.btnPartialPallet.Size = New System.Drawing.Size(230, 87)
        Me.btnPartialPallet.TabIndex = 6
        Me.btnPartialPallet.Text = "PARTIAL PALLET"
        '
        'btnWrongPallet
        '
        Me.btnWrongPallet.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnWrongPallet.Location = New System.Drawing.Point(536, 621)
        Me.btnWrongPallet.Name = "btnWrongPallet"
        Me.btnWrongPallet.Size = New System.Drawing.Size(230, 87)
        Me.btnWrongPallet.TabIndex = 7
        Me.btnWrongPallet.Text = "WRONG PALLET ID BARCODE"
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(261, 553)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(735, 38)
        Me.lblCodiceUM.TabIndex = 192
        '
        'frmPickingMerci_Code_InsPalletId
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.btnWrongPallet)
        Me.Controls.Add(Me.btnPartialPallet)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DtGridStockInfo)
        Me.Controls.Add(Me.txtSKU02)
        Me.Controls.Add(Me.lblSKU02)
        Me.Controls.Add(Me.txtSKU01)
        Me.Controls.Add(Me.lblSKU01)
        Me.Controls.Add(Me.lblUM02)
        Me.Controls.Add(Me.txtUM02)
        Me.Controls.Add(Me.txtUM01)
        Me.Controls.Add(Me.lblUM01)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_InsPalletId"
        Me.Text = "Info Giacenze(1)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM01 As System.Windows.Forms.TextBox
    Friend WithEvents lblUM01 As System.Windows.Forms.Label
    Friend WithEvents txtUM02 As System.Windows.Forms.TextBox
    Friend WithEvents lblUM02 As System.Windows.Forms.Label
    Friend WithEvents txtSKU01 As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU01 As System.Windows.Forms.Label
    Friend WithEvents txtSKU02 As System.Windows.Forms.TextBox
    Friend WithEvents lblSKU02 As System.Windows.Forms.Label
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPartialPallet As System.Windows.Forms.Button
    Friend WithEvents btnWrongPallet As System.Windows.Forms.Button
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
End Class
