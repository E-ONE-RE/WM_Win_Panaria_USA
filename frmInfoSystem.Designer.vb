<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoSystem
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
        Me.btnHome = New System.Windows.Forms.Button()
        Me.DtGridUserInfo = New System.Windows.Forms.DataGrid()
        Me.lblAssemblyVersion = New System.Windows.Forms.Label()
        Me.txtAssemblyVersion = New System.Windows.Forms.TextBox()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabInfoUser = New System.Windows.Forms.TabPage()
        Me.TabAppParam = New System.Windows.Forms.TabPage()
        Me.DtGridAppParam = New System.Windows.Forms.DataGrid()
        Me.lblAssemblyFolder = New System.Windows.Forms.Label()
        Me.txtAssemblyFolder = New System.Windows.Forms.TextBox()
        CType(Me.DtGridUserInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.TabInfoUser.SuspendLayout()
        Me.TabAppParam.SuspendLayout()
        CType(Me.DtGridAppParam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(881, 650)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(125, 67)
        Me.btnHome.TabIndex = 15
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'DtGridUserInfo
        '
        Me.DtGridUserInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtGridUserInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridUserInfo.DataMember = ""
        Me.DtGridUserInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridUserInfo.Location = New System.Drawing.Point(3, 3)
        Me.DtGridUserInfo.Name = "DtGridUserInfo"
        Me.DtGridUserInfo.ReadOnly = True
        Me.DtGridUserInfo.Size = New System.Drawing.Size(989, 590)
        Me.DtGridUserInfo.TabIndex = 17
        '
        'lblAssemblyVersion
        '
        Me.lblAssemblyVersion.BackColor = System.Drawing.Color.Lavender
        Me.lblAssemblyVersion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssemblyVersion.ForeColor = System.Drawing.Color.Black
        Me.lblAssemblyVersion.Location = New System.Drawing.Point(0, 634)
        Me.lblAssemblyVersion.Name = "lblAssemblyVersion"
        Me.lblAssemblyVersion.Size = New System.Drawing.Size(540, 16)
        Me.lblAssemblyVersion.TabIndex = 203
        Me.lblAssemblyVersion.Text = "Versione Applicazione"
        '
        'txtAssemblyVersion
        '
        Me.txtAssemblyVersion.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtAssemblyVersion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtAssemblyVersion.ForeColor = System.Drawing.Color.Black
        Me.txtAssemblyVersion.Location = New System.Drawing.Point(0, 650)
        Me.txtAssemblyVersion.Name = "txtAssemblyVersion"
        Me.txtAssemblyVersion.ReadOnly = True
        Me.txtAssemblyVersion.Size = New System.Drawing.Size(699, 26)
        Me.txtAssemblyVersion.TabIndex = 199
        '
        'btnAggiorna
        '
        Me.btnAggiorna.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnAggiorna.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnAggiorna.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAggiorna.Location = New System.Drawing.Point(738, 650)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(122, 67)
        Me.btnAggiorna.TabIndex = 200
        Me.btnAggiorna.Text = "Agg."
        Me.btnAggiorna.UseVisualStyleBackColor = False
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabInfoUser)
        Me.TabControl.Controls.Add(Me.TabAppParam)
        Me.TabControl.Location = New System.Drawing.Point(3, 3)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1003, 628)
        Me.TabControl.TabIndex = 202
        '
        'TabInfoUser
        '
        Me.TabInfoUser.Controls.Add(Me.DtGridUserInfo)
        Me.TabInfoUser.Location = New System.Drawing.Point(4, 25)
        Me.TabInfoUser.Name = "TabInfoUser"
        Me.TabInfoUser.Size = New System.Drawing.Size(995, 599)
        Me.TabInfoUser.TabIndex = 0
        Me.TabInfoUser.Text = "InfoUser"
        '
        'TabAppParam
        '
        Me.TabAppParam.Controls.Add(Me.DtGridAppParam)
        Me.TabAppParam.Location = New System.Drawing.Point(4, 25)
        Me.TabAppParam.Name = "TabAppParam"
        Me.TabAppParam.Size = New System.Drawing.Size(995, 599)
        Me.TabAppParam.TabIndex = 1
        Me.TabAppParam.Text = "Param"
        '
        'DtGridAppParam
        '
        Me.DtGridAppParam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtGridAppParam.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridAppParam.DataMember = ""
        Me.DtGridAppParam.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridAppParam.Location = New System.Drawing.Point(3, 3)
        Me.DtGridAppParam.Name = "DtGridAppParam"
        Me.DtGridAppParam.ReadOnly = True
        Me.DtGridAppParam.Size = New System.Drawing.Size(989, 590)
        Me.DtGridAppParam.TabIndex = 18
        '
        'lblAssemblyFolder
        '
        Me.lblAssemblyFolder.BackColor = System.Drawing.Color.Lavender
        Me.lblAssemblyFolder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssemblyFolder.ForeColor = System.Drawing.Color.Black
        Me.lblAssemblyFolder.Location = New System.Drawing.Point(0, 675)
        Me.lblAssemblyFolder.Name = "lblAssemblyFolder"
        Me.lblAssemblyFolder.Size = New System.Drawing.Size(501, 16)
        Me.lblAssemblyFolder.TabIndex = 205
        Me.lblAssemblyFolder.Text = "Folder Applicazione"
        '
        'txtAssemblyFolder
        '
        Me.txtAssemblyFolder.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtAssemblyFolder.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtAssemblyFolder.ForeColor = System.Drawing.Color.Black
        Me.txtAssemblyFolder.Location = New System.Drawing.Point(0, 691)
        Me.txtAssemblyFolder.Name = "txtAssemblyFolder"
        Me.txtAssemblyFolder.ReadOnly = True
        Me.txtAssemblyFolder.Size = New System.Drawing.Size(699, 26)
        Me.txtAssemblyFolder.TabIndex = 204
        '
        'frmInfoSystem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblAssemblyFolder)
        Me.Controls.Add(Me.txtAssemblyFolder)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btnAggiorna)
        Me.Controls.Add(Me.lblAssemblyVersion)
        Me.Controls.Add(Me.txtAssemblyVersion)
        Me.Controls.Add(Me.btnHome)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoSystem"
        Me.Text = "Info Sistema"
        CType(Me.DtGridUserInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.TabInfoUser.ResumeLayout(False)
        Me.TabAppParam.ResumeLayout(False)
        CType(Me.DtGridAppParam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents DtGridUserInfo As System.Windows.Forms.DataGrid
    Friend WithEvents lblAssemblyVersion As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyVersion As System.Windows.Forms.TextBox
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabInfoUser As System.Windows.Forms.TabPage
    Friend WithEvents TabAppParam As System.Windows.Forms.TabPage
    Friend WithEvents DtGridAppParam As System.Windows.Forms.DataGrid
    Friend WithEvents lblAssemblyFolder As System.Windows.Forms.Label
    Friend WithEvents txtAssemblyFolder As System.Windows.Forms.TextBox
End Class
