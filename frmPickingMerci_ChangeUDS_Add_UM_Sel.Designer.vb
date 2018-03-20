<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_ChangeUDS_Add_UM_Sel
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
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.cmdSelectUDSTask = New System.Windows.Forms.Button()
        Me.lblInfoUDS = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtInfoUDS = New System.Windows.Forms.TextBox()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.lblMateriale = New System.Windows.Forms.Label()
        Me.lblBatch = New System.Windows.Forms.Label()
        Me.txtQtaSfusiConfermata = New System.Windows.Forms.TextBox()
        Me.lblQtaPezziConfermata = New System.Windows.Forms.Label()
        Me.lblBat = New System.Windows.Forms.Label()
        Me.lblMat = New System.Windows.Forms.Label()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(759, 649)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdNextScreen.TabIndex = 11
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(6, 649)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(6, 111)
        Me.txtUM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(294, 35)
        Me.txtUM.TabIndex = 0
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(6, 67)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(294, 40)
        Me.lblCodiceUM.TabIndex = 2
        Me.lblCodiceUM.Text = "Codice UDS"
        '
        'cmdSelectUDSTask
        '
        Me.cmdSelectUDSTask.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUDSTask.Location = New System.Drawing.Point(308, 67)
        Me.cmdSelectUDSTask.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectUDSTask.Name = "cmdSelectUDSTask"
        Me.cmdSelectUDSTask.Size = New System.Drawing.Size(120, 85)
        Me.cmdSelectUDSTask.TabIndex = 119
        Me.cmdSelectUDSTask.Text = "OK"
        '
        'lblInfoUDS
        '
        Me.lblInfoUDS.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDS.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDS.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDS.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDS.Location = New System.Drawing.Point(8, 3)
        Me.lblInfoUDS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDS.Name = "lblInfoUDS"
        Me.lblInfoUDS.Size = New System.Drawing.Size(992, 27)
        Me.lblInfoUDS.TabIndex = 121
        Me.lblInfoUDS.Text = "UDS:"
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(729, 207)
        Me.txtQtaConfermata.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(266, 35)
        Me.txtQtaConfermata.TabIndex = 130
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Lavender
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(649, 172)
        Me.lblUDMQuantita.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(73, 33)
        Me.lblUDMQuantita.TabIndex = 131
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(644, 207)
        Me.txtUDMQuantità.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(80, 35)
        Me.txtUDMQuantità.TabIndex = 128
        Me.txtUDMQuantità.TabStop = False
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Lavender
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(542, 172)
        Me.lblQtaPrevista.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(100, 33)
        Me.lblQtaPrevista.TabIndex = 132
        Me.lblQtaPrevista.Text = "Qta"
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(540, 207)
        Me.txtQtaPrevista.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(100, 35)
        Me.txtQtaPrevista.TabIndex = 129
        Me.txtQtaPrevista.TabStop = False
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(731, 169)
        Me.lblQtaConfermata.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(264, 38)
        Me.lblQtaConfermata.TabIndex = 133
        Me.lblQtaConfermata.Text = "Qtà Confermata"
        '
        'txtInfoUDS
        '
        Me.txtInfoUDS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUDS.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUDS.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUDS.Location = New System.Drawing.Point(7, 152)
        Me.txtInfoUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoUDS.Multiline = True
        Me.txtInfoUDS.Name = "txtInfoUDS"
        Me.txtInfoUDS.ReadOnly = True
        Me.txtInfoUDS.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUDS.Size = New System.Drawing.Size(506, 225)
        Me.txtInfoUDS.TabIndex = 180
        Me.txtInfoUDS.TabStop = False
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(11, 385)
        Me.DtGridListInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.ReadOnly = True
        Me.DtGridListInfo.Size = New System.Drawing.Size(990, 256)
        Me.DtGridListInfo.TabIndex = 179
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(531, 649)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 67)
        Me.cmdPreviousScreen.TabIndex = 181
        Me.cmdPreviousScreen.Text = "<"
        '
        'lblMateriale
        '
        Me.lblMateriale.BackColor = System.Drawing.Color.Lavender
        Me.lblMateriale.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblMateriale.Location = New System.Drawing.Point(695, 70)
        Me.lblMateriale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMateriale.Name = "lblMateriale"
        Me.lblMateriale.Size = New System.Drawing.Size(256, 33)
        Me.lblMateriale.TabIndex = 182
        Me.lblMateriale.Text = "Materiale"
        '
        'lblBatch
        '
        Me.lblBatch.BackColor = System.Drawing.Color.Lavender
        Me.lblBatch.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBatch.ForeColor = System.Drawing.Color.Black
        Me.lblBatch.Location = New System.Drawing.Point(695, 115)
        Me.lblBatch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBatch.Name = "lblBatch"
        Me.lblBatch.Size = New System.Drawing.Size(204, 33)
        Me.lblBatch.TabIndex = 183
        Me.lblBatch.Text = "Batch"
        '
        'txtQtaSfusiConfermata
        '
        Me.txtQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiConfermata.Location = New System.Drawing.Point(729, 286)
        Me.txtQtaSfusiConfermata.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtaSfusiConfermata.Name = "txtQtaSfusiConfermata"
        Me.txtQtaSfusiConfermata.Size = New System.Drawing.Size(266, 35)
        Me.txtQtaSfusiConfermata.TabIndex = 184
        '
        'lblQtaPezziConfermata
        '
        Me.lblQtaPezziConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaPezziConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtaPezziConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPezziConfermata.Location = New System.Drawing.Point(731, 248)
        Me.lblQtaPezziConfermata.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtaPezziConfermata.Name = "lblQtaPezziConfermata"
        Me.lblQtaPezziConfermata.Size = New System.Drawing.Size(264, 38)
        Me.lblQtaPezziConfermata.TabIndex = 185
        Me.lblQtaPezziConfermata.Text = "Qtà Pezzi Conf."
        '
        'lblBat
        '
        Me.lblBat.BackColor = System.Drawing.Color.Lavender
        Me.lblBat.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBat.ForeColor = System.Drawing.Color.Black
        Me.lblBat.Location = New System.Drawing.Point(535, 115)
        Me.lblBat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBat.Name = "lblBat"
        Me.lblBat.Size = New System.Drawing.Size(139, 33)
        Me.lblBat.TabIndex = 187
        Me.lblBat.Text = "Batch :"
        '
        'lblMat
        '
        Me.lblMat.BackColor = System.Drawing.Color.Lavender
        Me.lblMat.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMat.ForeColor = System.Drawing.Color.Black
        Me.lblMat.Location = New System.Drawing.Point(535, 70)
        Me.lblMat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMat.Name = "lblMat"
        Me.lblMat.Size = New System.Drawing.Size(152, 33)
        Me.lblMat.TabIndex = 186
        Me.lblMat.Text = "Materiale :"
        '
        'frmPickingMerci_ChangeUDS_Add_UM_Sel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.lblBat)
        Me.Controls.Add(Me.lblMat)
        Me.Controls.Add(Me.txtQtaSfusiConfermata)
        Me.Controls.Add(Me.lblQtaPezziConfermata)
        Me.Controls.Add(Me.lblBatch)
        Me.Controls.Add(Me.lblMateriale)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.txtInfoUDS)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.lblInfoUDS)
        Me.Controls.Add(Me.cmdSelectUDSTask)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_ChangeUDS_Add_UM_Sel"
        Me.Text = "UDS Add (3)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUDSTask As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDS As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtInfoUDS As System.Windows.Forms.TextBox
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblMateriale As System.Windows.Forms.Label
    Friend WithEvents lblBatch As System.Windows.Forms.Label
    Friend WithEvents txtQtaSfusiConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPezziConfermata As System.Windows.Forms.Label
    Friend WithEvents lblBat As System.Windows.Forms.Label
    Friend WithEvents lblMat As System.Windows.Forms.Label
End Class
