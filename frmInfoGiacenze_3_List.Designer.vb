<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoGiacenze_3_List
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnDetails = New System.Windows.Forms.Button()
        Me.btnSped = New System.Windows.Forms.Button()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.DtGridShowInfo = New System.Windows.Forms.DataGridView()
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(4, 667)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(110, 60)
        Me.cmdPreviousScreen.TabIndex = 2
        Me.cmdPreviousScreen.Text = "<"
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(895, 667)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(110, 60)
        Me.btnHome.TabIndex = 0
        Me.btnHome.Text = "Chiudi"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnDetails
        '
        Me.btnDetails.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDetails.Location = New System.Drawing.Point(598, 667)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(110, 60)
        Me.btnDetails.TabIndex = 1
        Me.btnDetails.Text = "Dettagli"
        '
        'btnSped
        '
        Me.btnSped.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSped.Location = New System.Drawing.Point(301, 666)
        Me.btnSped.Name = "btnSped"
        Me.btnSped.Size = New System.Drawing.Size(110, 60)
        Me.btnSped.TabIndex = 95
        Me.btnSped.Text = "Sped."
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(0, 1)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(1007, 63)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/UDS : "
        '
        'DtGridShowInfo
        '
        Me.DtGridShowInfo.AllowUserToAddRows = False
        Me.DtGridShowInfo.AllowUserToDeleteRows = False
        Me.DtGridShowInfo.AllowUserToResizeRows = False
        Me.DtGridShowInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtGridShowInfo.DefaultCellStyle = DataGridViewCellStyle1
        Me.DtGridShowInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DtGridShowInfo.Location = New System.Drawing.Point(4, 67)
        Me.DtGridShowInfo.Name = "DtGridShowInfo"
        Me.DtGridShowInfo.ReadOnly = True
        Me.DtGridShowInfo.RowTemplate.Height = 24
        Me.DtGridShowInfo.Size = New System.Drawing.Size(1001, 594)
        Me.DtGridShowInfo.TabIndex = 199
        '
        'frmInfoGiacenze_3_List
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.DtGridShowInfo)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.btnSped)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoGiacenze_3_List"
        Me.Text = "Info Giacenze(3)"
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnDetails As System.Windows.Forms.Button
    Friend WithEvents btnSped As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents DtGridShowInfo As System.Windows.Forms.DataGridView
End Class
