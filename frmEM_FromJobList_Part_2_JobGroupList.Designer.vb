<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJobList_Part_2_JobGroupList
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        Me.btnDetails = New System.Windows.Forms.Button()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 256)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(54, 37)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(178, 256)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(58, 37)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(118, 256)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(58, 37)
        Me.cmdPreviousScreen.TabIndex = 44
        Me.cmdPreviousScreen.Text = "<"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(1, 105)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.Size = New System.Drawing.Size(237, 148)
        Me.DtGridListInfo.TabIndex = 107
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
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(237, 104)
        Me.txtInfoRowSelected.TabIndex = 108
        Me.txtInfoRowSelected.TabStop = False
        '
        'btnDetails
        '
        Me.btnDetails.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDetails.Location = New System.Drawing.Point(58, 256)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(60, 37)
        Me.btnDetails.TabIndex = 109
        Me.btnDetails.Text = "Dettagli"
        '
        'frmEM_FromJobList_Part_2_JobGroupList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.btnDetails)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJobList_Part_2_JobGroupList"
        Me.Text = "EM - Lista (2)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents btnDetails As System.Windows.Forms.Button
End Class
