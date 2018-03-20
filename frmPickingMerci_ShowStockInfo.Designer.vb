<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_ShowStockInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPickingMerci_ShowStockInfo))
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.DtGridStockInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.cmdSeleziona = New System.Windows.Forms.Button()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabInfoUser = New System.Windows.Forms.TabPage()
        Me.TabAppParam = New System.Windows.Forms.TabPage()
        Me.txtInfoJobSelezionato01 = New System.Windows.Forms.TextBox()
        Me.DtGridStockInfo01 = New System.Windows.Forms.DataGrid()
        Me.btnRefreshMonitors = New System.Windows.Forms.PictureBox()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.TabInfoUser.SuspendLayout()
        Me.TabAppParam.SuspendLayout()
        CType(Me.DtGridStockInfo01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRefreshMonitors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(796, 669)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(200, 56)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "CHIUDI"
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(0, 176)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.ReadOnly = True
        Me.DtGridStockInfo.Size = New System.Drawing.Size(992, 457)
        Me.DtGridStockInfo.TabIndex = 93
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 3)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(995, 172)
        Me.txtInfoJobSelezionato.TabIndex = 178
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdSeleziona
        '
        Me.cmdSeleziona.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSeleziona.Location = New System.Drawing.Point(12, 670)
        Me.cmdSeleziona.Name = "cmdSeleziona"
        Me.cmdSeleziona.Size = New System.Drawing.Size(200, 56)
        Me.cmdSeleziona.TabIndex = 179
        Me.cmdSeleziona.Text = "SELEZIONA"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabInfoUser)
        Me.TabControl.Controls.Add(Me.TabAppParam)
        Me.TabControl.Location = New System.Drawing.Point(2, 6)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1003, 657)
        Me.TabControl.TabIndex = 204
        '
        'TabInfoUser
        '
        Me.TabInfoUser.Controls.Add(Me.txtInfoJobSelezionato)
        Me.TabInfoUser.Controls.Add(Me.DtGridStockInfo)
        Me.TabInfoUser.Location = New System.Drawing.Point(4, 25)
        Me.TabInfoUser.Name = "TabInfoUser"
        Me.TabInfoUser.Size = New System.Drawing.Size(995, 628)
        Me.TabInfoUser.TabIndex = 0
        Me.TabInfoUser.Text = "Mat. Stock Info"
        '
        'TabAppParam
        '
        Me.TabAppParam.Controls.Add(Me.btnRefreshMonitors)
        Me.TabAppParam.Controls.Add(Me.txtInfoJobSelezionato01)
        Me.TabAppParam.Controls.Add(Me.DtGridStockInfo01)
        Me.TabAppParam.Location = New System.Drawing.Point(4, 25)
        Me.TabAppParam.Name = "TabAppParam"
        Me.TabAppParam.Size = New System.Drawing.Size(995, 628)
        Me.TabAppParam.TabIndex = 1
        Me.TabAppParam.Text = "Tot. Mat. Stock Info"
        '
        'txtInfoJobSelezionato01
        '
        Me.txtInfoJobSelezionato01.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato01.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato01.Location = New System.Drawing.Point(0, 2)
        Me.txtInfoJobSelezionato01.Multiline = True
        Me.txtInfoJobSelezionato01.Name = "txtInfoJobSelezionato01"
        Me.txtInfoJobSelezionato01.ReadOnly = True
        Me.txtInfoJobSelezionato01.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato01.Size = New System.Drawing.Size(857, 172)
        Me.txtInfoJobSelezionato01.TabIndex = 180
        Me.txtInfoJobSelezionato01.TabStop = False
        '
        'DtGridStockInfo01
        '
        Me.DtGridStockInfo01.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo01.DataMember = ""
        Me.DtGridStockInfo01.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo01.Location = New System.Drawing.Point(0, 176)
        Me.DtGridStockInfo01.Name = "DtGridStockInfo01"
        Me.DtGridStockInfo01.ReadOnly = True
        Me.DtGridStockInfo01.Size = New System.Drawing.Size(992, 457)
        Me.DtGridStockInfo01.TabIndex = 179
        '
        'btnRefreshMonitors
        '
        Me.btnRefreshMonitors.Image = CType(resources.GetObject("btnRefreshMonitors.Image"), System.Drawing.Image)
        Me.btnRefreshMonitors.Location = New System.Drawing.Point(886, 46)
        Me.btnRefreshMonitors.Name = "btnRefreshMonitors"
        Me.btnRefreshMonitors.Size = New System.Drawing.Size(80, 80)
        Me.btnRefreshMonitors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnRefreshMonitors.TabIndex = 181
        Me.btnRefreshMonitors.TabStop = False
        '
        'frmPickingMerci_ShowStockInfo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cmdSeleziona)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.TabControl)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_ShowStockInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRASF - Mat. (Stock Info)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.TabInfoUser.ResumeLayout(False)
        Me.TabInfoUser.PerformLayout()
        Me.TabAppParam.ResumeLayout(False)
        Me.TabAppParam.PerformLayout()
        CType(Me.DtGridStockInfo01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRefreshMonitors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdSeleziona As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabInfoUser As System.Windows.Forms.TabPage
    Friend WithEvents TabAppParam As System.Windows.Forms.TabPage
    Friend WithEvents txtInfoJobSelezionato01 As System.Windows.Forms.TextBox
    Friend WithEvents DtGridStockInfo01 As System.Windows.Forms.DataGrid
    Friend WithEvents btnRefreshMonitors As System.Windows.Forms.PictureBox
End Class
