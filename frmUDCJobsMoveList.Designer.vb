<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmUDCJobsMoveList
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.grpTaskFullPartialModeExecution = New System.Windows.Forms.GroupBox()
        Me.cmdSearchUDC = New System.Windows.Forms.Button()
        Me.rdbUDCIdentifiedProd = New System.Windows.Forms.RadioButton()
        Me.rdbUDCToIdentify = New System.Windows.Forms.RadioButton()
        Me.rdbUDCIdentified = New System.Windows.Forms.RadioButton()
        Me.DtGridInfo = New System.Windows.Forms.DataGrid()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.rdbUDCIdentifiedExt = New System.Windows.Forms.RadioButton()
        Me.rdbUDCStaging = New System.Windows.Forms.RadioButton()
        Me.grpTaskFullPartialModeExecution.SuspendLayout()
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbUDCStaging)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbUDCIdentifiedExt)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.cmdSearchUDC)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbUDCIdentifiedProd)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbUDCToIdentify)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbUDCIdentified)
        Me.grpTaskFullPartialModeExecution.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTaskFullPartialModeExecution.Location = New System.Drawing.Point(0, 1)
        Me.grpTaskFullPartialModeExecution.Name = "grpTaskFullPartialModeExecution"
        Me.grpTaskFullPartialModeExecution.Size = New System.Drawing.Size(996, 183)
        Me.grpTaskFullPartialModeExecution.TabIndex = 116
        Me.grpTaskFullPartialModeExecution.TabStop = False
        Me.grpTaskFullPartialModeExecution.Text = "Filtro"
        '
        'cmdSearchUDC
        '
        Me.cmdSearchUDC.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSearchUDC.Location = New System.Drawing.Point(838, 18)
        Me.cmdSearchUDC.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSearchUDC.Name = "cmdSearchUDC"
        Me.cmdSearchUDC.Size = New System.Drawing.Size(155, 120)
        Me.cmdSearchUDC.TabIndex = 123
        Me.cmdSearchUDC.Text = "SEARCH"
        '
        'rdbUDCIdentifiedProd
        '
        Me.rdbUDCIdentifiedProd.AutoSize = True
        Me.rdbUDCIdentifiedProd.Location = New System.Drawing.Point(22, 81)
        Me.rdbUDCIdentifiedProd.Name = "rdbUDCIdentifiedProd"
        Me.rdbUDCIdentifiedProd.Size = New System.Drawing.Size(337, 22)
        Me.rdbUDCIdentifiedProd.TabIndex = 1
        Me.rdbUDCIdentifiedProd.TabStop = True
        Me.rdbUDCIdentifiedProd.Text = "UDC identificati Produzione (PRDST1)"
        Me.rdbUDCIdentifiedProd.UseVisualStyleBackColor = True
        '
        'rdbUDCToIdentify
        '
        Me.rdbUDCToIdentify.AutoSize = True
        Me.rdbUDCToIdentify.Location = New System.Drawing.Point(22, 25)
        Me.rdbUDCToIdentify.Name = "rdbUDCToIdentify"
        Me.rdbUDCToIdentify.Size = New System.Drawing.Size(238, 22)
        Me.rdbUDCToIdentify.TabIndex = 2
        Me.rdbUDCToIdentify.TabStop = True
        Me.rdbUDCToIdentify.Text = "UDC da identificare (902)"
        Me.rdbUDCToIdentify.UseVisualStyleBackColor = True
        '
        'rdbUDCIdentified
        '
        Me.rdbUDCIdentified.AutoSize = True
        Me.rdbUDCIdentified.Location = New System.Drawing.Point(22, 53)
        Me.rdbUDCIdentified.Name = "rdbUDCIdentified"
        Me.rdbUDCIdentified.Size = New System.Drawing.Size(212, 22)
        Me.rdbUDCIdentified.TabIndex = 0
        Me.rdbUDCIdentified.TabStop = True
        Me.rdbUDCIdentified.Text = "UDC identificati (Tutti)"
        Me.rdbUDCIdentified.UseVisualStyleBackColor = True
        '
        'DtGridInfo
        '
        Me.DtGridInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridInfo.DataMember = ""
        Me.DtGridInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridInfo.Location = New System.Drawing.Point(0, 192)
        Me.DtGridInfo.Name = "DtGridInfo"
        Me.DtGridInfo.Size = New System.Drawing.Size(996, 489)
        Me.DtGridInfo.TabIndex = 118
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(76, 688)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(845, 34)
        Me.lblInfoUDC.TabIndex = 119
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'rdbUDCIdentifiedExt
        '
        Me.rdbUDCIdentifiedExt.AutoSize = True
        Me.rdbUDCIdentifiedExt.Location = New System.Drawing.Point(22, 109)
        Me.rdbUDCIdentifiedExt.Name = "rdbUDCIdentifiedExt"
        Me.rdbUDCIdentifiedExt.Size = New System.Drawing.Size(301, 22)
        Me.rdbUDCIdentifiedExt.TabIndex = 124
        Me.rdbUDCIdentifiedExt.TabStop = True
        Me.rdbUDCIdentifiedExt.Text = "UDC identificati Esterni (IMPSE1)"
        Me.rdbUDCIdentifiedExt.UseVisualStyleBackColor = True
        '
        'rdbUDCStaging
        '
        Me.rdbUDCStaging.AutoSize = True
        Me.rdbUDCStaging.Location = New System.Drawing.Point(22, 137)
        Me.rdbUDCStaging.Name = "rdbUDCStaging"
        Me.rdbUDCStaging.Size = New System.Drawing.Size(206, 22)
        Me.rdbUDCStaging.TabIndex = 125
        Me.rdbUDCStaging.TabStop = True
        Me.rdbUDCStaging.Text = "UDC in baia di staging"
        Me.rdbUDCStaging.UseVisualStyleBackColor = True
        '
        'frmUDCJobsMoveList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.DtGridInfo)
        Me.Controls.Add(Me.grpTaskFullPartialModeExecution)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUDCJobsMoveList"
        Me.Text = "Lista UDC da Movimentare"
        Me.grpTaskFullPartialModeExecution.ResumeLayout(False)
        Me.grpTaskFullPartialModeExecution.PerformLayout()
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents grpTaskFullPartialModeExecution As System.Windows.Forms.GroupBox
    Friend WithEvents rdbUDCIdentifiedProd As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUDCIdentified As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUDCToIdentify As System.Windows.Forms.RadioButton
    Friend WithEvents DtGridInfo As System.Windows.Forms.DataGrid
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents cmdSearchUDC As System.Windows.Forms.Button
    Friend WithEvents rdbUDCStaging As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUDCIdentifiedExt As System.Windows.Forms.RadioButton
End Class
