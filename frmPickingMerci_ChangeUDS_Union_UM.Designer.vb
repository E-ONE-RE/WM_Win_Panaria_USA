<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_ChangeUDS_Union_UM
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
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.lblInfoUDS = New System.Windows.Forms.Label()
        Me.txtInfoUDS = New System.Windows.Forms.TextBox()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
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
        Me.txtUM.Location = New System.Drawing.Point(6, 107)
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
        Me.lblCodiceUM.Location = New System.Drawing.Point(6, 63)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(294, 40)
        Me.lblCodiceUM.TabIndex = 2
        Me.lblCodiceUM.Text = "Codice UDS"
        '
        'cmdSelectUDSTask
        '
        Me.cmdSelectUDSTask.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUDSTask.Location = New System.Drawing.Point(308, 59)
        Me.cmdSelectUDSTask.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectUDSTask.Name = "cmdSelectUDSTask"
        Me.cmdSelectUDSTask.Size = New System.Drawing.Size(120, 85)
        Me.cmdSelectUDSTask.TabIndex = 119
        Me.cmdSelectUDSTask.Text = "OK"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(11, 343)
        Me.DtGridListInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.ReadOnly = True
        Me.DtGridListInfo.Size = New System.Drawing.Size(990, 290)
        Me.DtGridListInfo.TabIndex = 120
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
        'txtInfoUDS
        '
        Me.txtInfoUDS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUDS.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUDS.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUDS.Location = New System.Drawing.Point(7, 150)
        Me.txtInfoUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoUDS.Multiline = True
        Me.txtInfoUDS.Name = "txtInfoUDS"
        Me.txtInfoUDS.ReadOnly = True
        Me.txtInfoUDS.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUDS.Size = New System.Drawing.Size(994, 185)
        Me.txtInfoUDS.TabIndex = 178
        Me.txtInfoUDS.TabStop = False
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(531, 650)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 67)
        Me.cmdPreviousScreen.TabIndex = 185
        Me.cmdPreviousScreen.Text = "<"
        '
        'frmPickingMerci_ChangeUDS_Union_UM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.txtInfoUDS)
        Me.Controls.Add(Me.lblInfoUDS)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdSelectUDSTask)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_ChangeUDS_Union_UM"
        Me.Text = "UDS Union (3)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUDSTask As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents lblInfoUDS As System.Windows.Forms.Label
    Friend WithEvents txtInfoUDS As System.Windows.Forms.TextBox
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
End Class
