<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_3_SelMis
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
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.cmdCloseJobsGroup = New System.Windows.Forms.Button()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdExit.Location = New System.Drawing.Point(3, 233)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(51, 48)
        Me.cmdExit.TabIndex = 61
        Me.cmdExit.Text = "&Esci"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 233)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(0, 113)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.Size = New System.Drawing.Size(237, 117)
        Me.DtGridListInfo.TabIndex = 93
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(238, 112)
        Me.txtInfoJobSelezionato.TabIndex = 171
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(139, 233)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(43, 48)
        Me.cmdJobFunctions.TabIndex = 173
        Me.cmdJobFunctions.Text = "..."
        '
        'cmdCloseJobsGroup
        '
        Me.cmdCloseJobsGroup.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdCloseJobsGroup.Location = New System.Drawing.Point(56, 233)
        Me.cmdCloseJobsGroup.Name = "cmdCloseJobsGroup"
        Me.cmdCloseJobsGroup.Size = New System.Drawing.Size(77, 48)
        Me.cmdCloseJobsGroup.TabIndex = 172
        Me.cmdCloseJobsGroup.Text = "Chiudi Lista"
        '
        'frmEM_FromJob_Part_3_SelMis
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.cmdCloseJobsGroup)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_3_SelMis"
        Me.Text = "EM - Bem-SelPos (1)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents cmdCloseJobsGroup As System.Windows.Forms.Button
End Class
