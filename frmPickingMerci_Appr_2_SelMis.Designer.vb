<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_2_SelMis
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
        Me.cmdCloseJobsGroup = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCloseJobsGroup
        '
        Me.cmdCloseJobsGroup.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdCloseJobsGroup.Location = New System.Drawing.Point(45, 242)
        Me.cmdCloseJobsGroup.Name = "cmdCloseJobsGroup"
        Me.cmdCloseJobsGroup.Size = New System.Drawing.Size(77, 42)
        Me.cmdCloseJobsGroup.TabIndex = 10
        Me.cmdCloseJobsGroup.Text = "Chiudi Lista"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 242)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 42)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "OK"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(0, 113)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.Size = New System.Drawing.Size(237, 127)
        Me.DtGridListInfo.TabIndex = 0
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
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(236, 113)
        Me.txtInfoRowSelected.TabIndex = 0
        Me.txtInfoRowSelected.TabStop = False
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(128, 242)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(43, 42)
        Me.cmdJobFunctions.TabIndex = 11
        Me.cmdJobFunctions.Text = "..."
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(0, 242)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(43, 42)
        Me.cmdAbortScreen.TabIndex = 13
        Me.cmdAbortScreen.Text = "Esci"
        '
        'frmPickingMerci_Appr_2_SelMis
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdCloseJobsGroup)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_2_SelMis"
        Me.Text = "Picking Appr. (2)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCloseJobsGroup As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
