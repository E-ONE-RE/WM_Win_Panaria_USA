<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoUser
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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabInfoUser = New System.Windows.Forms.TabPage()
        Me.DtGridUserInfo = New System.Windows.Forms.DataGrid()
        Me.TabMagUser = New System.Windows.Forms.TabPage()
        Me.DtGridUserMag = New System.Windows.Forms.DataGrid()
        Me.TabControl.SuspendLayout()
        Me.TabInfoUser.SuspendLayout()
        CType(Me.DtGridUserInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMagUser.SuspendLayout()
        CType(Me.DtGridUserMag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(190, 246)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(48, 36)
        Me.btnHome.TabIndex = 15
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabInfoUser)
        Me.TabControl.Controls.Add(Me.TabMagUser)
        Me.TabControl.Location = New System.Drawing.Point(2, 3)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(235, 240)
        Me.TabControl.TabIndex = 203
        '
        'TabInfoUser
        '
        Me.TabInfoUser.Controls.Add(Me.DtGridUserInfo)
        Me.TabInfoUser.Location = New System.Drawing.Point(4, 25)
        Me.TabInfoUser.Name = "TabInfoUser"
        Me.TabInfoUser.Size = New System.Drawing.Size(227, 211)
        Me.TabInfoUser.TabIndex = 0
        Me.TabInfoUser.Text = "InfoUser"
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
        Me.DtGridUserInfo.Size = New System.Drawing.Size(221, 202)
        Me.DtGridUserInfo.TabIndex = 18
        '
        'TabMagUser
        '
        Me.TabMagUser.Controls.Add(Me.DtGridUserMag)
        Me.TabMagUser.Location = New System.Drawing.Point(4, 25)
        Me.TabMagUser.Name = "TabMagUser"
        Me.TabMagUser.Size = New System.Drawing.Size(227, 211)
        Me.TabMagUser.TabIndex = 1
        Me.TabMagUser.Text = "Mag."
        '
        'DtGridUserMag
        '
        Me.DtGridUserMag.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtGridUserMag.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridUserMag.DataMember = ""
        Me.DtGridUserMag.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridUserMag.Location = New System.Drawing.Point(3, 3)
        Me.DtGridUserMag.Name = "DtGridUserMag"
        Me.DtGridUserMag.ReadOnly = True
        Me.DtGridUserMag.Size = New System.Drawing.Size(221, 202)
        Me.DtGridUserMag.TabIndex = 19
        '
        'frmInfoUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.btnHome)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoUser"
        Me.Text = "Info Utente"
        Me.TabControl.ResumeLayout(False)
        Me.TabInfoUser.ResumeLayout(False)
        CType(Me.DtGridUserInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMagUser.ResumeLayout(False)
        CType(Me.DtGridUserMag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabInfoUser As System.Windows.Forms.TabPage
    Friend WithEvents DtGridUserInfo As System.Windows.Forms.DataGrid
    Friend WithEvents TabMagUser As System.Windows.Forms.TabPage
    Friend WithEvents DtGridUserMag As System.Windows.Forms.DataGrid
End Class
