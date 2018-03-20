<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmUDSJobsMoveList
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.DtGridInfo = New System.Windows.Forms.DataGrid()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.grpTaskFullPartialModeExecution = New System.Windows.Forms.GroupBox()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.txtDockDestinazione = New System.Windows.Forms.TextBox()
        Me.lblDockDestinazione = New System.Windows.Forms.Label()
        Me.txtStagingDestinazione = New System.Windows.Forms.TextBox()
        Me.lblStagingDestinazione = New System.Windows.Forms.Label()
        Me.txtNumeroConsegna = New System.Windows.Forms.TextBox()
        Me.lblNumeroConsegna = New System.Windows.Forms.Label()
        Me.txtUbicazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazione = New System.Windows.Forms.Label()
        Me.txtNumeroTrasporto = New System.Windows.Forms.TextBox()
        Me.lblNumeroTrasporto = New System.Windows.Forms.Label()
        Me.cmdSearchUDS = New System.Windows.Forms.Button()
        Me.txtCodiceUM = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.rdbToTruck = New System.Windows.Forms.RadioButton()
        Me.rdbToStaging = New System.Windows.Forms.RadioButton()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTaskFullPartialModeExecution.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnOK.Location = New System.Drawing.Point(927, 684)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 38)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'DtGridInfo
        '
        Me.DtGridInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridInfo.DataMember = ""
        Me.DtGridInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridInfo.Location = New System.Drawing.Point(0, 297)
        Me.DtGridInfo.Name = "DtGridInfo"
        Me.DtGridInfo.ReadOnly = True
        Me.DtGridInfo.Size = New System.Drawing.Size(996, 384)
        Me.DtGridInfo.TabIndex = 17
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(1, 685)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 38)
        Me.cmdAbortScreen.TabIndex = 19
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'grpTaskFullPartialModeExecution
        '
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbAll)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtDockDestinazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblDockDestinazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtStagingDestinazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblStagingDestinazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtNumeroConsegna)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblNumeroConsegna)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtUbicazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblUbicazione)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtNumeroTrasporto)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblNumeroTrasporto)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.cmdSearchUDS)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtCodiceUM)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblCodiceUM)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbToTruck)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbToStaging)
        Me.grpTaskFullPartialModeExecution.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTaskFullPartialModeExecution.Location = New System.Drawing.Point(0, 1)
        Me.grpTaskFullPartialModeExecution.Name = "grpTaskFullPartialModeExecution"
        Me.grpTaskFullPartialModeExecution.Size = New System.Drawing.Size(1001, 151)
        Me.grpTaskFullPartialModeExecution.TabIndex = 116
        Me.grpTaskFullPartialModeExecution.TabStop = False
        Me.grpTaskFullPartialModeExecution.Text = "Filtro"
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Location = New System.Drawing.Point(12, 25)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(129, 22)
        Me.rdbAll.TabIndex = 133
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "Mostra Tutti"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'txtDockDestinazione
        '
        Me.txtDockDestinazione.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDockDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtDockDestinazione.Location = New System.Drawing.Point(545, 108)
        Me.txtDockDestinazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDockDestinazione.MaxLength = 10
        Me.txtDockDestinazione.Name = "txtDockDestinazione"
        Me.txtDockDestinazione.Size = New System.Drawing.Size(170, 35)
        Me.txtDockDestinazione.TabIndex = 131
        '
        'lblDockDestinazione
        '
        Me.lblDockDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblDockDestinazione.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDockDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblDockDestinazione.Location = New System.Drawing.Point(546, 81)
        Me.lblDockDestinazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDockDestinazione.Name = "lblDockDestinazione"
        Me.lblDockDestinazione.Size = New System.Drawing.Size(169, 26)
        Me.lblDockDestinazione.TabIndex = 132
        Me.lblDockDestinazione.Text = "DOCK DEST."
        '
        'txtStagingDestinazione
        '
        Me.txtStagingDestinazione.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStagingDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtStagingDestinazione.Location = New System.Drawing.Point(355, 109)
        Me.txtStagingDestinazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStagingDestinazione.MaxLength = 10
        Me.txtStagingDestinazione.Name = "txtStagingDestinazione"
        Me.txtStagingDestinazione.Size = New System.Drawing.Size(185, 35)
        Me.txtStagingDestinazione.TabIndex = 129
        '
        'lblStagingDestinazione
        '
        Me.lblStagingDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblStagingDestinazione.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStagingDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblStagingDestinazione.Location = New System.Drawing.Point(356, 82)
        Me.lblStagingDestinazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStagingDestinazione.Name = "lblStagingDestinazione"
        Me.lblStagingDestinazione.Size = New System.Drawing.Size(184, 26)
        Me.lblStagingDestinazione.TabIndex = 130
        Me.lblStagingDestinazione.Text = "STAGING DEST."
        '
        'txtNumeroConsegna
        '
        Me.txtNumeroConsegna.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroConsegna.ForeColor = System.Drawing.Color.Black
        Me.txtNumeroConsegna.Location = New System.Drawing.Point(545, 41)
        Me.txtNumeroConsegna.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroConsegna.MaxLength = 10
        Me.txtNumeroConsegna.Name = "txtNumeroConsegna"
        Me.txtNumeroConsegna.Size = New System.Drawing.Size(170, 35)
        Me.txtNumeroConsegna.TabIndex = 127
        '
        'lblNumeroConsegna
        '
        Me.lblNumeroConsegna.BackColor = System.Drawing.Color.Yellow
        Me.lblNumeroConsegna.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroConsegna.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroConsegna.Location = New System.Drawing.Point(546, 14)
        Me.lblNumeroConsegna.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumeroConsegna.Name = "lblNumeroConsegna"
        Me.lblNumeroConsegna.Size = New System.Drawing.Size(169, 26)
        Me.lblNumeroConsegna.TabIndex = 128
        Me.lblNumeroConsegna.Text = "CONSEGNA"
        '
        'txtUbicazione
        '
        Me.txtUbicazione.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazione.Location = New System.Drawing.Point(165, 109)
        Me.txtUbicazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUbicazione.MaxLength = 10
        Me.txtUbicazione.Name = "txtUbicazione"
        Me.txtUbicazione.Size = New System.Drawing.Size(185, 35)
        Me.txtUbicazione.TabIndex = 125
        '
        'lblUbicazione
        '
        Me.lblUbicazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazione.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazione.Location = New System.Drawing.Point(166, 83)
        Me.lblUbicazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUbicazione.Name = "lblUbicazione"
        Me.lblUbicazione.Size = New System.Drawing.Size(182, 26)
        Me.lblUbicazione.TabIndex = 126
        Me.lblUbicazione.Text = "UBICAZIONE"
        '
        'txtNumeroTrasporto
        '
        Me.txtNumeroTrasporto.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroTrasporto.ForeColor = System.Drawing.Color.Black
        Me.txtNumeroTrasporto.Location = New System.Drawing.Point(355, 41)
        Me.txtNumeroTrasporto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumeroTrasporto.MaxLength = 10
        Me.txtNumeroTrasporto.Name = "txtNumeroTrasporto"
        Me.txtNumeroTrasporto.Size = New System.Drawing.Size(184, 35)
        Me.txtNumeroTrasporto.TabIndex = 123
        '
        'lblNumeroTrasporto
        '
        Me.lblNumeroTrasporto.BackColor = System.Drawing.Color.Yellow
        Me.lblNumeroTrasporto.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroTrasporto.ForeColor = System.Drawing.Color.Black
        Me.lblNumeroTrasporto.Location = New System.Drawing.Point(356, 15)
        Me.lblNumeroTrasporto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumeroTrasporto.Name = "lblNumeroTrasporto"
        Me.lblNumeroTrasporto.Size = New System.Drawing.Size(183, 26)
        Me.lblNumeroTrasporto.TabIndex = 124
        Me.lblNumeroTrasporto.Text = "TRASPORTO"
        '
        'cmdSearchUDS
        '
        Me.cmdSearchUDS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSearchUDS.Location = New System.Drawing.Point(838, 18)
        Me.cmdSearchUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSearchUDS.Name = "cmdSearchUDS"
        Me.cmdSearchUDS.Size = New System.Drawing.Size(155, 120)
        Me.cmdSearchUDS.TabIndex = 122
        Me.cmdSearchUDS.Text = "SEARCH"
        '
        'txtCodiceUM
        '
        Me.txtCodiceUM.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceUM.Location = New System.Drawing.Point(165, 41)
        Me.txtCodiceUM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodiceUM.MaxLength = 10
        Me.txtCodiceUM.Name = "txtCodiceUM"
        Me.txtCodiceUM.Size = New System.Drawing.Size(185, 35)
        Me.txtCodiceUM.TabIndex = 120
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Verdana", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(166, 15)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(184, 26)
        Me.lblCodiceUM.TabIndex = 121
        Me.lblCodiceUM.Text = "UDS"
        '
        'rdbToTruck
        '
        Me.rdbToTruck.AutoSize = True
        Me.rdbToTruck.Location = New System.Drawing.Point(12, 95)
        Me.rdbToTruck.Name = "rdbToTruck"
        Me.rdbToTruck.Size = New System.Drawing.Size(141, 22)
        Me.rdbToTruck.TabIndex = 1
        Me.rdbToTruck.TabStop = True
        Me.rdbToTruck.Text = "verso Camion"
        Me.rdbToTruck.UseVisualStyleBackColor = True
        '
        'rdbToStaging
        '
        Me.rdbToStaging.AutoSize = True
        Me.rdbToStaging.Location = New System.Drawing.Point(12, 60)
        Me.rdbToStaging.Name = "rdbToStaging"
        Me.rdbToStaging.Size = New System.Drawing.Size(142, 22)
        Me.rdbToStaging.TabIndex = 0
        Me.rdbToStaging.TabStop = True
        Me.rdbToStaging.Text = "verso Staging"
        Me.rdbToStaging.UseVisualStyleBackColor = True
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(76, 688)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(845, 34)
        Me.lblInfoUDC.TabIndex = 120
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'txtInfoRowSelected
        '
        Me.txtInfoRowSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoRowSelected.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoRowSelected.ForeColor = System.Drawing.Color.Black
        Me.txtInfoRowSelected.Location = New System.Drawing.Point(0, 147)
        Me.txtInfoRowSelected.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoRowSelected.Multiline = True
        Me.txtInfoRowSelected.Name = "txtInfoRowSelected"
        Me.txtInfoRowSelected.ReadOnly = True
        Me.txtInfoRowSelected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(1001, 151)
        Me.txtInfoRowSelected.TabIndex = 121
        Me.txtInfoRowSelected.TabStop = False
        '
        'frmUDSJobsMoveList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.DtGridInfo)
        Me.Controls.Add(Me.grpTaskFullPartialModeExecution)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUDSJobsMoveList"
        Me.Text = "Lista UDS da Movimentare"
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTaskFullPartialModeExecution.ResumeLayout(False)
        Me.grpTaskFullPartialModeExecution.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DtGridInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents grpTaskFullPartialModeExecution As System.Windows.Forms.GroupBox
    Friend WithEvents rdbToTruck As System.Windows.Forms.RadioButton
    Friend WithEvents rdbToStaging As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazione As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTrasporto As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroTrasporto As System.Windows.Forms.Label
    Friend WithEvents cmdSearchUDS As System.Windows.Forms.Button
    Friend WithEvents txtCodiceUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents txtNumeroConsegna As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroConsegna As System.Windows.Forms.Label
    Friend WithEvents txtStagingDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblStagingDestinazione As System.Windows.Forms.Label
    Friend WithEvents txtDockDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblDockDestinazione As System.Windows.Forms.Label
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
End Class
