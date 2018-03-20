<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoForkLift
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
        Me.DtGridForkLiftInfo = New System.Windows.Forms.DataGrid()
        CType(Me.DtGridForkLiftInfo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DtGridForkLiftInfo
        '
        Me.DtGridForkLiftInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridForkLiftInfo.DataMember = ""
        Me.DtGridForkLiftInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridForkLiftInfo.Location = New System.Drawing.Point(0, 1)
        Me.DtGridForkLiftInfo.Name = "DtGridForkLiftInfo"
        Me.DtGridForkLiftInfo.Size = New System.Drawing.Size(237, 239)
        Me.DtGridForkLiftInfo.TabIndex = 17
        '
        'frmInfoForkLift
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.DtGridForkLiftInfo)
        Me.Controls.Add(Me.btnHome)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoForkLift"
        Me.Text = "Info Carrelli"
        CType(Me.DtGridForkLiftInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents DtGridForkLiftInfo As System.Windows.Forms.DataGrid
End Class
