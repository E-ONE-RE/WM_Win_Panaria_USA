<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoDatiUbicazione
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
    Private mainHomeMenu As System.Windows.Forms.MainMenu

    'NOTA: la procedura seguente è richiesta da Progettazione Windows Form
    'Può essere modificata utilizzando Progettazione Windows Form.  
    'Non modificarla mediante l'editor di codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.mainHomeMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DtGridInfo = New System.Windows.Forms.DataGrid()
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.Location = New System.Drawing.Point(190, 246)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(48, 36)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Chiudi"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'DtGridInfo
        '
        Me.DtGridInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridInfo.DataMember = ""
        Me.DtGridInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridInfo.Location = New System.Drawing.Point(0, 0)
        Me.DtGridInfo.Name = "DtGridInfo"
        Me.DtGridInfo.Size = New System.Drawing.Size(238, 244)
        Me.DtGridInfo.TabIndex = 17
        '
        'frmInfoDatiUbicazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.DtGridInfo)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.Menu = Me.mainHomeMenu
        Me.MinimizeBox = False
        Me.Name = "frmInfoDatiUbicazione"
        Me.Text = "Info Dati Ubicazione"
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DtGridInfo As System.Windows.Forms.DataGrid
End Class
