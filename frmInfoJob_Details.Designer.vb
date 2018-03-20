<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoJob_Details
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DtGridShowInfo = New System.Windows.Forms.DataGrid()
        Me.cmdLast = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrevious = New System.Windows.Forms.Button()
        Me.cmdFirst = New System.Windows.Forms.Button()
        Me.lblIndex = New System.Windows.Forms.Label()
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.Location = New System.Drawing.Point(193, 245)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(42, 38)
        Me.btnClose.TabIndex = 92
        Me.btnClose.Text = "Chiudi"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'DtGridShowInfo
        '
        Me.DtGridShowInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridShowInfo.DataMember = ""
        Me.DtGridShowInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridShowInfo.Location = New System.Drawing.Point(0, 1)
        Me.DtGridShowInfo.Name = "DtGridShowInfo"
        Me.DtGridShowInfo.Size = New System.Drawing.Size(238, 242)
        Me.DtGridShowInfo.TabIndex = 94
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdLast.Location = New System.Drawing.Point(152, 245)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(38, 38)
        Me.cmdLast.TabIndex = 99
        Me.cmdLast.Text = ">>"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNext.Location = New System.Drawing.Point(112, 245)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(38, 38)
        Me.cmdNext.TabIndex = 98
        Me.cmdNext.Text = ">"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPrevious.Location = New System.Drawing.Point(43, 245)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(38, 38)
        Me.cmdPrevious.TabIndex = 97
        Me.cmdPrevious.Text = "<"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdFirst.Location = New System.Drawing.Point(3, 245)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(38, 38)
        Me.cmdFirst.TabIndex = 96
        Me.cmdFirst.Text = "<<"
        '
        'lblIndex
        '
        Me.lblIndex.Location = New System.Drawing.Point(78, 256)
        Me.lblIndex.Name = "lblIndex"
        Me.lblIndex.Size = New System.Drawing.Size(36, 18)
        Me.lblIndex.TabIndex = 100
        Me.lblIndex.Text = "999"
        Me.lblIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmInfoJob_Details
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.lblIndex)
        Me.Controls.Add(Me.DtGridShowInfo)
        Me.Controls.Add(Me.btnClose)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoJob_Details"
        Me.Text = "Info Missione"
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DtGridShowInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents lblIndex As System.Windows.Forms.Label
End Class
