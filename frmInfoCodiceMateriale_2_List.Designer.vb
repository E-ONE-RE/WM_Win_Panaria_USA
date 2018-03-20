<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoCodiceMateriale_2_List
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.DtGridShowInfo = New System.Windows.Forms.DataGrid()
        Me.btnDetails = New System.Windows.Forms.Button()
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(2, 245)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 38)
        Me.cmdPreviousScreen.TabIndex = 87
        Me.cmdPreviousScreen.Text = "<"
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(178, 245)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(60, 38)
        Me.btnHome.TabIndex = 92
        Me.btnHome.Text = "Chiudi"
        Me.btnHome.UseVisualStyleBackColor = False
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
        'btnDetails
        '
        Me.btnDetails.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDetails.Location = New System.Drawing.Point(92, 246)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(60, 38)
        Me.btnDetails.TabIndex = 96
        Me.btnDetails.Text = "Dettagli"
        '
        'frmInfoCodiceMateriale_2_List
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.DtGridShowInfo)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoCodiceMateriale_2_List"
        Me.Text = "Info Ana.Materiale(2)"
        CType(Me.DtGridShowInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents DtGridShowInfo As System.Windows.Forms.DataGrid
    Friend WithEvents btnDetails As System.Windows.Forms.Button
End Class
