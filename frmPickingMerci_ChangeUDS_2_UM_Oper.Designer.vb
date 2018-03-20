<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_ChangeUDS_2_UM_Oper
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdOperUDSMinus = New System.Windows.Forms.Button()
        Me.txtInfoUDS = New System.Windows.Forms.TextBox()
        Me.lblInfoUDS = New System.Windows.Forms.Label()
        Me.cmdOperUDSAdd = New System.Windows.Forms.Button()
        Me.cmdOperUDSUnion = New System.Windows.Forms.Button()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(14, 631)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(545, 630)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(773, 631)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        Me.cmdNextScreen.Visible = False
        '
        'cmdOperUDSMinus
        '
        Me.cmdOperUDSMinus.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOperUDSMinus.Location = New System.Drawing.Point(678, 306)
        Me.cmdOperUDSMinus.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOperUDSMinus.Name = "cmdOperUDSMinus"
        Me.cmdOperUDSMinus.Size = New System.Drawing.Size(320, 80)
        Me.cmdOperUDSMinus.TabIndex = 162
        Me.cmdOperUDSMinus.Tag = "PK01003"
        Me.cmdOperUDSMinus.Text = "SPLIT K-TAG"
        '
        'txtInfoUDS
        '
        Me.txtInfoUDS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUDS.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUDS.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUDS.Location = New System.Drawing.Point(3, 32)
        Me.txtInfoUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoUDS.Multiline = True
        Me.txtInfoUDS.Name = "txtInfoUDS"
        Me.txtInfoUDS.ReadOnly = True
        Me.txtInfoUDS.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUDS.Size = New System.Drawing.Size(994, 266)
        Me.txtInfoUDS.TabIndex = 177
        Me.txtInfoUDS.TabStop = False
        '
        'lblInfoUDS
        '
        Me.lblInfoUDS.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDS.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDS.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDS.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDS.Location = New System.Drawing.Point(1, 1)
        Me.lblInfoUDS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDS.Name = "lblInfoUDS"
        Me.lblInfoUDS.Size = New System.Drawing.Size(992, 27)
        Me.lblInfoUDS.TabIndex = 0
        Me.lblInfoUDS.Text = "UDS:"
        '
        'cmdOperUDSAdd
        '
        Me.cmdOperUDSAdd.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOperUDSAdd.Location = New System.Drawing.Point(6, 306)
        Me.cmdOperUDSAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOperUDSAdd.Name = "cmdOperUDSAdd"
        Me.cmdOperUDSAdd.Size = New System.Drawing.Size(320, 80)
        Me.cmdOperUDSAdd.TabIndex = 178
        Me.cmdOperUDSAdd.Tag = "PK01003"
        Me.cmdOperUDSAdd.Text = "ADD EXISTING K-TAG"
        '
        'cmdOperUDSUnion
        '
        Me.cmdOperUDSUnion.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOperUDSUnion.Location = New System.Drawing.Point(342, 306)
        Me.cmdOperUDSUnion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOperUDSUnion.Name = "cmdOperUDSUnion"
        Me.cmdOperUDSUnion.Size = New System.Drawing.Size(320, 80)
        Me.cmdOperUDSUnion.TabIndex = 179
        Me.cmdOperUDSUnion.Tag = "PK01003"
        Me.cmdOperUDSUnion.Text = "CONSOLIDATE K-TAG"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(3, 394)
        Me.DtGridListInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.ReadOnly = True
        Me.DtGridListInfo.Size = New System.Drawing.Size(1003, 229)
        Me.DtGridListInfo.TabIndex = 180
        '
        'frmPickingMerci_ChangeUDS_2_UM_Oper
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdOperUDSUnion)
        Me.Controls.Add(Me.cmdOperUDSAdd)
        Me.Controls.Add(Me.lblInfoUDS)
        Me.Controls.Add(Me.txtInfoUDS)
        Me.Controls.Add(Me.cmdOperUDSMinus)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_ChangeUDS_2_UM_Oper"
        Me.Text = "UDS Change (2)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdOperUDSMinus As System.Windows.Forms.Button
    Friend WithEvents txtInfoUDS As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDS As System.Windows.Forms.Label
    Friend WithEvents cmdOperUDSAdd As System.Windows.Forms.Button
    Friend WithEvents cmdOperUDSUnion As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
End Class
