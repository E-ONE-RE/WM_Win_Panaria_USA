<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_JobGroupDetails
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
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 260)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(69, 34)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "Chiudi"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(0, 108)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.Size = New System.Drawing.Size(238, 150)
        Me.DtGridListInfo.TabIndex = 93
        '
        'txtInfoRowSelected
        '
        Me.txtInfoRowSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoRowSelected.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoRowSelected.ForeColor = System.Drawing.Color.Black
        Me.txtInfoRowSelected.Location = New System.Drawing.Point(1, 0)
        Me.txtInfoRowSelected.Multiline = True
        Me.txtInfoRowSelected.Name = "txtInfoRowSelected"
        Me.txtInfoRowSelected.ReadOnly = True
        Me.txtInfoRowSelected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(237, 108)
        Me.txtInfoRowSelected.TabIndex = 57
        Me.txtInfoRowSelected.TabStop = False
        '
        'frmPickingMerci_JobGroupDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_JobGroupDetails"
        Me.Text = "Pick.Group Info"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
End Class
