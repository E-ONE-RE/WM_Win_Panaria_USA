<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_TaskLinesAssigned
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
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.DtGridViewInfo = New System.Windows.Forms.DataGridView()
        Me.cmdSetDropPick = New System.Windows.Forms.Button()
        CType(Me.DtGridViewInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(229, 667)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(200, 56)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "SELEZIONA"
        '
        'txtInfoRowSelected
        '
        Me.txtInfoRowSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoRowSelected.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoRowSelected.ForeColor = System.Drawing.Color.Black
        Me.txtInfoRowSelected.Location = New System.Drawing.Point(1, 57)
        Me.txtInfoRowSelected.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoRowSelected.Multiline = True
        Me.txtInfoRowSelected.Name = "txtInfoRowSelected"
        Me.txtInfoRowSelected.ReadOnly = True
        Me.txtInfoRowSelected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(1001, 307)
        Me.txtInfoRowSelected.TabIndex = 0
        Me.txtInfoRowSelected.TabStop = False
        Me.txtInfoRowSelected.Visible = False
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(802, 666)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(200, 56)
        Me.cmdAbortScreen.TabIndex = 13
        Me.cmdAbortScreen.Text = "CHIUDI"
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(3, 0)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(1001, 28)
        Me.lblSystemInfo.TabIndex = 117
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(3, 28)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(1000, 28)
        Me.lblInfoUDSOnWork.TabIndex = 196
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'DtGridViewInfo
        '
        Me.DtGridViewInfo.AllowUserToAddRows = False
        Me.DtGridViewInfo.AllowUserToDeleteRows = False
        Me.DtGridViewInfo.AllowUserToResizeRows = False
        Me.DtGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtGridViewInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DtGridViewInfo.Location = New System.Drawing.Point(1, 59)
        Me.DtGridViewInfo.Name = "DtGridViewInfo"
        Me.DtGridViewInfo.ReadOnly = True
        Me.DtGridViewInfo.RowTemplate.Height = 24
        Me.DtGridViewInfo.Size = New System.Drawing.Size(1001, 601)
        Me.DtGridViewInfo.TabIndex = 198
        '
        'cmdSetDropPick
        '
        Me.cmdSetDropPick.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSetDropPick.Location = New System.Drawing.Point(1, 667)
        Me.cmdSetDropPick.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSetDropPick.Name = "cmdSetDropPick"
        Me.cmdSetDropPick.Size = New System.Drawing.Size(200, 56)
        Me.cmdSetDropPick.TabIndex = 199
        Me.cmdSetDropPick.Text = "ANNULLA PRENOTAZIONE"
        '
        'frmPickingMerci_TaskLinesAssigned
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cmdSetDropPick)
        Me.Controls.Add(Me.DtGridViewInfo)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_TaskLinesAssigned"
        Me.Text = "Picking Task (2)"
        CType(Me.DtGridViewInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents DtGridViewInfo As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSetDropPick As System.Windows.Forms.Button
End Class
