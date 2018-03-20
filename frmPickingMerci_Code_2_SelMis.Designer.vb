<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_2_SelMis
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
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.txtInfoPesoMissione = New System.Windows.Forms.TextBox()
        Me.cmdDropUDS = New System.Windows.Forms.Button()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.cmdGetNewJobTask = New System.Windows.Forms.Button()
        Me.DtGridViewInfo = New System.Windows.Forms.DataGridView()
        Me.txtInfoRowSelected = New System.Windows.Forms.RichTextBox()
        CType(Me.DtGridViewInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(891, 662)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(110, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(776, 662)
        Me.cmdJobFunctions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(110, 60)
        Me.cmdJobFunctions.TabIndex = 11
        Me.cmdJobFunctions.Text = "Opzioni"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(1, 662)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(110, 60)
        Me.cmdAbortScreen.TabIndex = 13
        Me.cmdAbortScreen.Text = "Esci"
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(3, 0)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(1001, 28)
        Me.lblSystemInfo.TabIndex = 117
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'txtInfoPesoMissione
        '
        Me.txtInfoPesoMissione.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtInfoPesoMissione.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoPesoMissione.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPesoMissione.Location = New System.Drawing.Point(347, 663)
        Me.txtInfoPesoMissione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoPesoMissione.Multiline = True
        Me.txtInfoPesoMissione.Name = "txtInfoPesoMissione"
        Me.txtInfoPesoMissione.ReadOnly = True
        Me.txtInfoPesoMissione.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoPesoMissione.Size = New System.Drawing.Size(423, 60)
        Me.txtInfoPesoMissione.TabIndex = 127
        Me.txtInfoPesoMissione.TabStop = False
        '
        'cmdDropUDS
        '
        Me.cmdDropUDS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdDropUDS.Location = New System.Drawing.Point(235, 662)
        Me.cmdDropUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDropUDS.Name = "cmdDropUDS"
        Me.cmdDropUDS.Size = New System.Drawing.Size(110, 60)
        Me.cmdDropUDS.TabIndex = 128
        Me.cmdDropUDS.Text = "Drop Pallet"
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(3, 28)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(1000, 28)
        Me.lblInfoUDSOnWork.TabIndex = 196
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'cmdGetNewJobTask
        '
        Me.cmdGetNewJobTask.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdGetNewJobTask.Location = New System.Drawing.Point(119, 662)
        Me.cmdGetNewJobTask.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdGetNewJobTask.Name = "cmdGetNewJobTask"
        Me.cmdGetNewJobTask.Size = New System.Drawing.Size(110, 60)
        Me.cmdGetNewJobTask.TabIndex = 197
        Me.cmdGetNewJobTask.Text = "Nuovi Task"
        '
        'DtGridViewInfo
        '
        Me.DtGridViewInfo.AllowUserToAddRows = False
        Me.DtGridViewInfo.AllowUserToDeleteRows = False
        Me.DtGridViewInfo.AllowUserToResizeRows = False
        Me.DtGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DtGridViewInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DtGridViewInfo.Location = New System.Drawing.Point(1, 395)
        Me.DtGridViewInfo.Name = "DtGridViewInfo"
        Me.DtGridViewInfo.ReadOnly = True
        Me.DtGridViewInfo.RowTemplate.Height = 24
        Me.DtGridViewInfo.Size = New System.Drawing.Size(1001, 264)
        Me.DtGridViewInfo.TabIndex = 198
        '
        'txtInfoRowSelected
        '
        Me.txtInfoRowSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoRowSelected.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold)
        Me.txtInfoRowSelected.ForeColor = System.Drawing.Color.Black
        Me.txtInfoRowSelected.Location = New System.Drawing.Point(0, 57)
        Me.txtInfoRowSelected.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoRowSelected.Name = "txtInfoRowSelected"
        Me.txtInfoRowSelected.ReadOnly = True
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(1001, 337)
        Me.txtInfoRowSelected.TabIndex = 199
        Me.txtInfoRowSelected.TabStop = False
        Me.txtInfoRowSelected.Text = ""
        '
        'frmPickingMerci_Code_2_SelMis
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.Controls.Add(Me.DtGridViewInfo)
        Me.Controls.Add(Me.cmdGetNewJobTask)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.cmdDropUDS)
        Me.Controls.Add(Me.txtInfoPesoMissione)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_2_SelMis"
        Me.Text = "Picking Task (2)"
        CType(Me.DtGridViewInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents txtInfoPesoMissione As System.Windows.Forms.TextBox
    Friend WithEvents cmdDropUDS As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents cmdGetNewJobTask As System.Windows.Forms.Button
    Friend WithEvents DtGridViewInfo As System.Windows.Forms.DataGridView
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.RichTextBox
End Class
