<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSelectCodiceMateriale
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.DtGridInfo = New System.Windows.Forms.DataGrid()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnOK.Location = New System.Drawing.Point(166, 245)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(69, 38)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'DtGridInfo
        '
        Me.DtGridInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridInfo.DataMember = ""
        Me.DtGridInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridInfo.Location = New System.Drawing.Point(0, 1)
        Me.DtGridInfo.Name = "DtGridInfo"
        Me.DtGridInfo.Size = New System.Drawing.Size(238, 244)
        Me.DtGridInfo.TabIndex = 17
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(1, 246)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 38)
        Me.cmdAbortScreen.TabIndex = 19
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'frmSelectCodiceMateriale
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.DtGridInfo)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectCodiceMateriale"
        Me.Text = "Selezione Cod.Mat."
        CType(Me.DtGridInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DtGridInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
