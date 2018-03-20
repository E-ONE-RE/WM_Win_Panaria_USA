<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_5_Sel_CodMatOrigine
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
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.lblInfoTaskLinesOnWork = New System.Windows.Forms.Label()
        Me.cmdShowStock = New System.Windows.Forms.Button()
        Me.txtInfoPrelievo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodiceUM = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.cmdDropUDS = New System.Windows.Forms.Button()
        Me.lblNumPalletOfLocation = New System.Windows.Forms.TextBox()
        Me.txtQtyLocationProposal = New System.Windows.Forms.TextBox()
        Me.txtQtyStockProposal = New System.Windows.Forms.TextBox()
        Me.txtLocationProposal = New System.Windows.Forms.TextBox()
        Me.txtUMProposal = New System.Windows.Forms.TextBox()
        Me.lblCodiceUMProposto = New System.Windows.Forms.Label()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.RichTextBox()
        Me.PBoxInsPalletId = New System.Windows.Forms.PictureBox()
        CType(Me.PBoxInsPalletId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(783, 661)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 60)
        Me.cmdNextScreen.TabIndex = 11
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(7, 661)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(210, 60)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(7, -1)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(998, 28)
        Me.lblSystemInfo.TabIndex = 119
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(7, 29)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoUDSOnWork.TabIndex = 125
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(555, 661)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 60)
        Me.cmdPreviousScreen.TabIndex = 129
        Me.cmdPreviousScreen.Text = "<"
        '
        'lblInfoTaskLinesOnWork
        '
        Me.lblInfoTaskLinesOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoTaskLinesOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoTaskLinesOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoTaskLinesOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoTaskLinesOnWork.Location = New System.Drawing.Point(5, 60)
        Me.lblInfoTaskLinesOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoTaskLinesOnWork.Name = "lblInfoTaskLinesOnWork"
        Me.lblInfoTaskLinesOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoTaskLinesOnWork.TabIndex = 131
        Me.lblInfoTaskLinesOnWork.Text = "TASK ATTIVO:"
        '
        'cmdShowStock
        '
        Me.cmdShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdShowStock.Location = New System.Drawing.Point(912, 543)
        Me.cmdShowStock.Name = "cmdShowStock"
        Me.cmdShowStock.Size = New System.Drawing.Size(90, 74)
        Me.cmdShowStock.TabIndex = 196
        Me.cmdShowStock.Text = "STOCK"
        '
        'txtInfoPrelievo
        '
        Me.txtInfoPrelievo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoPrelievo.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoPrelievo.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPrelievo.Location = New System.Drawing.Point(562, 473)
        Me.txtInfoPrelievo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoPrelievo.Multiline = True
        Me.txtInfoPrelievo.Name = "txtInfoPrelievo"
        Me.txtInfoPrelievo.ReadOnly = True
        Me.txtInfoPrelievo.Size = New System.Drawing.Size(440, 62)
        Me.txtInfoPrelievo.TabIndex = 195
        Me.txtInfoPrelievo.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(558, 448)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "Info:"
        '
        'txtCodiceUM
        '
        Me.txtCodiceUM.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceUM.Location = New System.Drawing.Point(564, 581)
        Me.txtCodiceUM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodiceUM.MaxLength = 10
        Me.txtCodiceUM.Name = "txtCodiceUM"
        Me.txtCodiceUM.Size = New System.Drawing.Size(305, 35)
        Me.txtCodiceUM.TabIndex = 189
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(564, 543)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(305, 38)
        Me.lblCodiceUM.TabIndex = 191
        Me.lblCodiceUM.Text = "Codice UM/SKU"
        '
        'cmdDropUDS
        '
        Me.cmdDropUDS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdDropUDS.Location = New System.Drawing.Point(224, 661)
        Me.cmdDropUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDropUDS.Name = "cmdDropUDS"
        Me.cmdDropUDS.Size = New System.Drawing.Size(210, 60)
        Me.cmdDropUDS.TabIndex = 198
        Me.cmdDropUDS.Text = "Drop Pallet"
        '
        'lblNumPalletOfLocation
        '
        Me.lblNumPalletOfLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNumPalletOfLocation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumPalletOfLocation.ForeColor = System.Drawing.Color.Black
        Me.lblNumPalletOfLocation.Location = New System.Drawing.Point(12, 620)
        Me.lblNumPalletOfLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.lblNumPalletOfLocation.Name = "lblNumPalletOfLocation"
        Me.lblNumPalletOfLocation.ReadOnly = True
        Me.lblNumPalletOfLocation.Size = New System.Drawing.Size(543, 32)
        Me.lblNumPalletOfLocation.TabIndex = 204
        Me.lblNumPalletOfLocation.TabStop = False
        '
        'txtQtyLocationProposal
        '
        Me.txtQtyLocationProposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtQtyLocationProposal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtyLocationProposal.ForeColor = System.Drawing.Color.Black
        Me.txtQtyLocationProposal.Location = New System.Drawing.Point(12, 584)
        Me.txtQtyLocationProposal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtyLocationProposal.Name = "txtQtyLocationProposal"
        Me.txtQtyLocationProposal.ReadOnly = True
        Me.txtQtyLocationProposal.Size = New System.Drawing.Size(543, 32)
        Me.txtQtyLocationProposal.TabIndex = 203
        Me.txtQtyLocationProposal.TabStop = False
        '
        'txtQtyStockProposal
        '
        Me.txtQtyStockProposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtQtyStockProposal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtyStockProposal.ForeColor = System.Drawing.Color.Black
        Me.txtQtyStockProposal.Location = New System.Drawing.Point(12, 548)
        Me.txtQtyStockProposal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtyStockProposal.Name = "txtQtyStockProposal"
        Me.txtQtyStockProposal.ReadOnly = True
        Me.txtQtyStockProposal.Size = New System.Drawing.Size(543, 32)
        Me.txtQtyStockProposal.TabIndex = 202
        Me.txtQtyStockProposal.TabStop = False
        '
        'txtLocationProposal
        '
        Me.txtLocationProposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLocationProposal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocationProposal.ForeColor = System.Drawing.Color.Black
        Me.txtLocationProposal.Location = New System.Drawing.Point(12, 476)
        Me.txtLocationProposal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLocationProposal.Name = "txtLocationProposal"
        Me.txtLocationProposal.ReadOnly = True
        Me.txtLocationProposal.Size = New System.Drawing.Size(542, 32)
        Me.txtLocationProposal.TabIndex = 201
        Me.txtLocationProposal.TabStop = False
        '
        'txtUMProposal
        '
        Me.txtUMProposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUMProposal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtUMProposal.ForeColor = System.Drawing.Color.Black
        Me.txtUMProposal.Location = New System.Drawing.Point(12, 512)
        Me.txtUMProposal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUMProposal.Name = "txtUMProposal"
        Me.txtUMProposal.ReadOnly = True
        Me.txtUMProposal.Size = New System.Drawing.Size(543, 32)
        Me.txtUMProposal.TabIndex = 199
        Me.txtUMProposal.TabStop = False
        '
        'lblCodiceUMProposto
        '
        Me.lblCodiceUMProposto.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceUMProposto.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUMProposto.Location = New System.Drawing.Point(8, 448)
        Me.lblCodiceUMProposto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUMProposto.Name = "lblCodiceUMProposto"
        Me.lblCodiceUMProposto.Size = New System.Drawing.Size(88, 24)
        Me.lblCodiceUMProposto.TabIndex = 200
        Me.lblCodiceUMProposto.Text = "Proposta:"
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(440, 661)
        Me.cmdJobFunctions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(110, 60)
        Me.cmdJobFunctions.TabIndex = 205
        Me.cmdJobFunctions.Text = "Opzioni"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(6, 92)
        Me.txtInfoJobSelezionato.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(999, 347)
        Me.txtInfoJobSelezionato.TabIndex = 206
        Me.txtInfoJobSelezionato.TabStop = False
        Me.txtInfoJobSelezionato.Text = ""
        '
        'PBoxInsPalletId
        '
        Me.PBoxInsPalletId.Image = Global.WM_Win_PanariaUSA.My.Resources.Resources.keyboard
        Me.PBoxInsPalletId.Location = New System.Drawing.Point(841, 542)
        Me.PBoxInsPalletId.Name = "PBoxInsPalletId"
        Me.PBoxInsPalletId.Size = New System.Drawing.Size(65, 74)
        Me.PBoxInsPalletId.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBoxInsPalletId.TabIndex = 207
        Me.PBoxInsPalletId.TabStop = False
        '
        'frmPickingMerci_Code_5_Sel_CodMatOrigine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.PBoxInsPalletId)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.lblNumPalletOfLocation)
        Me.Controls.Add(Me.txtQtyLocationProposal)
        Me.Controls.Add(Me.txtQtyStockProposal)
        Me.Controls.Add(Me.txtLocationProposal)
        Me.Controls.Add(Me.txtUMProposal)
        Me.Controls.Add(Me.lblCodiceUMProposto)
        Me.Controls.Add(Me.cmdDropUDS)
        Me.Controls.Add(Me.cmdShowStock)
        Me.Controls.Add(Me.txtInfoPrelievo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodiceUM)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.lblInfoTaskLinesOnWork)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_5_Sel_CodMatOrigine"
        Me.Text = "Picking Task (5)"
        CType(Me.PBoxInsPalletId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblInfoTaskLinesOnWork As System.Windows.Forms.Label
    Friend WithEvents cmdShowStock As System.Windows.Forms.Button
    Friend WithEvents txtInfoPrelievo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodiceUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents cmdDropUDS As System.Windows.Forms.Button
    Friend WithEvents lblNumPalletOfLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyLocationProposal As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyStockProposal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationProposal As System.Windows.Forms.TextBox
    Friend WithEvents txtUMProposal As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUMProposto As System.Windows.Forms.Label
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.RichTextBox
    Friend WithEvents PBoxInsPalletId As System.Windows.Forms.PictureBox
End Class
