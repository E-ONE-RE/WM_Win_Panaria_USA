<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_1_Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPickingMerci_Code_1_Settings))
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtCurrentTipoMagazzino = New System.Windows.Forms.TextBox()
        Me.lblCurrentTipoMagazzino = New System.Windows.Forms.Label()
        Me.btnSelectUserPickQueue = New System.Windows.Forms.PictureBox()
        Me.btnSelectForkLift = New System.Windows.Forms.PictureBox()
        Me.btnSelectTipiMag = New System.Windows.Forms.PictureBox()
        Me.txtCurrentForkLift = New System.Windows.Forms.TextBox()
        Me.lblCurrentForkLift = New System.Windows.Forms.Label()
        Me.txtCurrentWorkQueue = New System.Windows.Forms.TextBox()
        Me.lblCurrentWorkQueue = New System.Windows.Forms.Label()
        Me.grpTaskFullPartialModeExecution = New System.Windows.Forms.GroupBox()
        Me.btnSelectUserTaskList = New System.Windows.Forms.PictureBox()
        Me.txtNumConsegna = New System.Windows.Forms.TextBox()
        Me.lblNumConsegna = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.lblJobNumber = New System.Windows.Forms.Label()
        Me.rdbTaskFullPartialMode_All = New System.Windows.Forms.RadioButton()
        Me.rdbTaskFullPartialMode_PartialOnly = New System.Windows.Forms.RadioButton()
        Me.rdbTaskFullPartialMode_FullOnly = New System.Windows.Forms.RadioButton()
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.btnSelectUserPickQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectTipiMag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTaskFullPartialModeExecution.SuspendLayout()
        CType(Me.btnSelectUserTaskList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(756, 640)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(13, 640)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtCurrentTipoMagazzino
        '
        Me.txtCurrentTipoMagazzino.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCurrentTipoMagazzino.Enabled = False
        Me.txtCurrentTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentTipoMagazzino.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentTipoMagazzino.Location = New System.Drawing.Point(9, 390)
        Me.txtCurrentTipoMagazzino.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentTipoMagazzino.Name = "txtCurrentTipoMagazzino"
        Me.txtCurrentTipoMagazzino.Size = New System.Drawing.Size(851, 30)
        Me.txtCurrentTipoMagazzino.TabIndex = 0
        '
        'lblCurrentTipoMagazzino
        '
        Me.lblCurrentTipoMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblCurrentTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentTipoMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentTipoMagazzino.Location = New System.Drawing.Point(9, 359)
        Me.lblCurrentTipoMagazzino.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentTipoMagazzino.Name = "lblCurrentTipoMagazzino"
        Me.lblCurrentTipoMagazzino.Size = New System.Drawing.Size(851, 31)
        Me.lblCurrentTipoMagazzino.TabIndex = 1
        Me.lblCurrentTipoMagazzino.Text = "Tipo Magazzino"
        '
        'btnSelectUserPickQueue
        '
        Me.btnSelectUserPickQueue.Image = CType(resources.GetObject("btnSelectUserPickQueue.Image"), System.Drawing.Image)
        Me.btnSelectUserPickQueue.Location = New System.Drawing.Point(867, 190)
        Me.btnSelectUserPickQueue.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectUserPickQueue.Name = "btnSelectUserPickQueue"
        Me.btnSelectUserPickQueue.Size = New System.Drawing.Size(109, 91)
        Me.btnSelectUserPickQueue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectUserPickQueue.TabIndex = 110
        Me.btnSelectUserPickQueue.TabStop = False
        Me.btnSelectUserPickQueue.Tag = "SF00001"
        '
        'btnSelectForkLift
        '
        Me.btnSelectForkLift.Image = CType(resources.GetObject("btnSelectForkLift.Image"), System.Drawing.Image)
        Me.btnSelectForkLift.Location = New System.Drawing.Point(867, 56)
        Me.btnSelectForkLift.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectForkLift.Name = "btnSelectForkLift"
        Me.btnSelectForkLift.Size = New System.Drawing.Size(109, 91)
        Me.btnSelectForkLift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectForkLift.TabIndex = 108
        Me.btnSelectForkLift.TabStop = False
        Me.btnSelectForkLift.Tag = "SF00001"
        '
        'btnSelectTipiMag
        '
        Me.btnSelectTipiMag.Enabled = False
        Me.btnSelectTipiMag.Image = CType(resources.GetObject("btnSelectTipiMag.Image"), System.Drawing.Image)
        Me.btnSelectTipiMag.Location = New System.Drawing.Point(867, 329)
        Me.btnSelectTipiMag.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectTipiMag.Name = "btnSelectTipiMag"
        Me.btnSelectTipiMag.Size = New System.Drawing.Size(109, 91)
        Me.btnSelectTipiMag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectTipiMag.TabIndex = 109
        Me.btnSelectTipiMag.TabStop = False
        Me.btnSelectTipiMag.Tag = "IU00001"
        '
        'txtCurrentForkLift
        '
        Me.txtCurrentForkLift.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentForkLift.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentForkLift.Location = New System.Drawing.Point(9, 117)
        Me.txtCurrentForkLift.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentForkLift.Name = "txtCurrentForkLift"
        Me.txtCurrentForkLift.Size = New System.Drawing.Size(851, 30)
        Me.txtCurrentForkLift.TabIndex = 111
        '
        'lblCurrentForkLift
        '
        Me.lblCurrentForkLift.BackColor = System.Drawing.Color.Yellow
        Me.lblCurrentForkLift.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentForkLift.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentForkLift.Location = New System.Drawing.Point(9, 86)
        Me.lblCurrentForkLift.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentForkLift.Name = "lblCurrentForkLift"
        Me.lblCurrentForkLift.Size = New System.Drawing.Size(851, 31)
        Me.lblCurrentForkLift.TabIndex = 112
        Me.lblCurrentForkLift.Text = "Carrello / Muletto"
        '
        'txtCurrentWorkQueue
        '
        Me.txtCurrentWorkQueue.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentWorkQueue.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentWorkQueue.Location = New System.Drawing.Point(8, 251)
        Me.txtCurrentWorkQueue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentWorkQueue.Name = "txtCurrentWorkQueue"
        Me.txtCurrentWorkQueue.Size = New System.Drawing.Size(851, 30)
        Me.txtCurrentWorkQueue.TabIndex = 113
        '
        'lblCurrentWorkQueue
        '
        Me.lblCurrentWorkQueue.BackColor = System.Drawing.Color.Yellow
        Me.lblCurrentWorkQueue.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentWorkQueue.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentWorkQueue.Location = New System.Drawing.Point(8, 220)
        Me.lblCurrentWorkQueue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentWorkQueue.Name = "lblCurrentWorkQueue"
        Me.lblCurrentWorkQueue.Size = New System.Drawing.Size(851, 31)
        Me.lblCurrentWorkQueue.TabIndex = 114
        Me.lblCurrentWorkQueue.Text = "Coda Task"
        '
        'grpTaskFullPartialModeExecution
        '
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.Label1)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.btnSelectUserTaskList)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtNumConsegna)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblNumConsegna)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.txtJobNumber)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.lblJobNumber)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbTaskFullPartialMode_All)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbTaskFullPartialMode_PartialOnly)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbTaskFullPartialMode_FullOnly)
        Me.grpTaskFullPartialModeExecution.Font = New System.Drawing.Font("Verdana", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTaskFullPartialModeExecution.Location = New System.Drawing.Point(9, 447)
        Me.grpTaskFullPartialModeExecution.Name = "grpTaskFullPartialModeExecution"
        Me.grpTaskFullPartialModeExecution.Size = New System.Drawing.Size(967, 179)
        Me.grpTaskFullPartialModeExecution.TabIndex = 115
        Me.grpTaskFullPartialModeExecution.TabStop = False
        Me.grpTaskFullPartialModeExecution.Text = "Modalita Esecuzione Prelievo Interi / Sfusi"
        '
        'btnSelectUserTaskList
        '
        Me.btnSelectUserTaskList.Image = CType(resources.GetObject("btnSelectUserTaskList.Image"), System.Drawing.Image)
        Me.btnSelectUserTaskList.Location = New System.Drawing.Point(791, 72)
        Me.btnSelectUserTaskList.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectUserTaskList.Name = "btnSelectUserTaskList"
        Me.btnSelectUserTaskList.Size = New System.Drawing.Size(109, 91)
        Me.btnSelectUserTaskList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectUserTaskList.TabIndex = 117
        Me.btnSelectUserTaskList.TabStop = False
        Me.btnSelectUserTaskList.Tag = "SF00001"
        '
        'txtNumConsegna
        '
        Me.txtNumConsegna.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumConsegna.ForeColor = System.Drawing.Color.Black
        Me.txtNumConsegna.Location = New System.Drawing.Point(494, 133)
        Me.txtNumConsegna.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumConsegna.Name = "txtNumConsegna"
        Me.txtNumConsegna.Size = New System.Drawing.Size(223, 30)
        Me.txtNumConsegna.TabIndex = 118
        '
        'lblNumConsegna
        '
        Me.lblNumConsegna.BackColor = System.Drawing.Color.Yellow
        Me.lblNumConsegna.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumConsegna.ForeColor = System.Drawing.Color.Black
        Me.lblNumConsegna.Location = New System.Drawing.Point(498, 101)
        Me.lblNumConsegna.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumConsegna.Name = "lblNumConsegna"
        Me.lblNumConsegna.Size = New System.Drawing.Size(220, 31)
        Me.lblNumConsegna.TabIndex = 117
        Me.lblNumConsegna.Text = "Numero Consegna"
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtJobNumber.ForeColor = System.Drawing.Color.Black
        Me.txtJobNumber.Location = New System.Drawing.Point(495, 55)
        Me.txtJobNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(223, 30)
        Me.txtJobNumber.TabIndex = 116
        '
        'lblJobNumber
        '
        Me.lblJobNumber.BackColor = System.Drawing.Color.Yellow
        Me.lblJobNumber.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblJobNumber.ForeColor = System.Drawing.Color.Black
        Me.lblJobNumber.Location = New System.Drawing.Point(497, 23)
        Me.lblJobNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJobNumber.Name = "lblJobNumber"
        Me.lblJobNumber.Size = New System.Drawing.Size(220, 31)
        Me.lblJobNumber.TabIndex = 115
        Me.lblJobNumber.Text = "Mission"
        '
        'rdbTaskFullPartialMode_All
        '
        Me.rdbTaskFullPartialMode_All.AutoSize = True
        Me.rdbTaskFullPartialMode_All.Location = New System.Drawing.Point(17, 139)
        Me.rdbTaskFullPartialMode_All.Name = "rdbTaskFullPartialMode_All"
        Me.rdbTaskFullPartialMode_All.Size = New System.Drawing.Size(76, 24)
        Me.rdbTaskFullPartialMode_All.TabIndex = 2
        Me.rdbTaskFullPartialMode_All.TabStop = True
        Me.rdbTaskFullPartialMode_All.Text = "Tutti"
        Me.rdbTaskFullPartialMode_All.UseVisualStyleBackColor = True
        '
        'rdbTaskFullPartialMode_PartialOnly
        '
        Me.rdbTaskFullPartialMode_PartialOnly.AutoSize = True
        Me.rdbTaskFullPartialMode_PartialOnly.Enabled = False
        Me.rdbTaskFullPartialMode_PartialOnly.Location = New System.Drawing.Point(17, 88)
        Me.rdbTaskFullPartialMode_PartialOnly.Name = "rdbTaskFullPartialMode_PartialOnly"
        Me.rdbTaskFullPartialMode_PartialOnly.Size = New System.Drawing.Size(125, 24)
        Me.rdbTaskFullPartialMode_PartialOnly.TabIndex = 1
        Me.rdbTaskFullPartialMode_PartialOnly.TabStop = True
        Me.rdbTaskFullPartialMode_PartialOnly.Text = "Solo Sfusi"
        Me.rdbTaskFullPartialMode_PartialOnly.UseVisualStyleBackColor = True
        Me.rdbTaskFullPartialMode_PartialOnly.Visible = False
        '
        'rdbTaskFullPartialMode_FullOnly
        '
        Me.rdbTaskFullPartialMode_FullOnly.AutoSize = True
        Me.rdbTaskFullPartialMode_FullOnly.Enabled = False
        Me.rdbTaskFullPartialMode_FullOnly.Location = New System.Drawing.Point(17, 37)
        Me.rdbTaskFullPartialMode_FullOnly.Name = "rdbTaskFullPartialMode_FullOnly"
        Me.rdbTaskFullPartialMode_FullOnly.Size = New System.Drawing.Size(132, 24)
        Me.rdbTaskFullPartialMode_FullOnly.TabIndex = 0
        Me.rdbTaskFullPartialMode_FullOnly.TabStop = True
        Me.rdbTaskFullPartialMode_FullOnly.Text = "Solo Interi"
        Me.rdbTaskFullPartialMode_FullOnly.UseVisualStyleBackColor = True
        Me.rdbTaskFullPartialMode_FullOnly.Visible = False
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(5, -1)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(971, 43)
        Me.lblSystemInfo.TabIndex = 116
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Lavender
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(740, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 31)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Show Task Assigned"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPickingMerci_Code_1_Settings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.grpTaskFullPartialModeExecution)
        Me.Controls.Add(Me.txtCurrentWorkQueue)
        Me.Controls.Add(Me.btnSelectTipiMag)
        Me.Controls.Add(Me.lblCurrentTipoMagazzino)
        Me.Controls.Add(Me.lblCurrentWorkQueue)
        Me.Controls.Add(Me.txtCurrentTipoMagazzino)
        Me.Controls.Add(Me.txtCurrentForkLift)
        Me.Controls.Add(Me.lblCurrentForkLift)
        Me.Controls.Add(Me.btnSelectUserPickQueue)
        Me.Controls.Add(Me.btnSelectForkLift)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_1_Settings"
        Me.Text = "Picking Task (1)"
        CType(Me.btnSelectUserPickQueue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectTipiMag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTaskFullPartialModeExecution.ResumeLayout(False)
        Me.grpTaskFullPartialModeExecution.PerformLayout()
        CType(Me.btnSelectUserTaskList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtCurrentTipoMagazzino As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentTipoMagazzino As System.Windows.Forms.Label
    Friend WithEvents btnSelectUserPickQueue As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectForkLift As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectTipiMag As System.Windows.Forms.PictureBox
    Friend WithEvents txtCurrentForkLift As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentForkLift As System.Windows.Forms.Label
    Friend WithEvents txtCurrentWorkQueue As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentWorkQueue As System.Windows.Forms.Label
    Friend WithEvents grpTaskFullPartialModeExecution As System.Windows.Forms.GroupBox
    Friend WithEvents rdbTaskFullPartialMode_PartialOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTaskFullPartialMode_FullOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTaskFullPartialMode_All As System.Windows.Forms.RadioButton
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents lblJobNumber As System.Windows.Forms.Label
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtNumConsegna As System.Windows.Forms.TextBox
    Friend WithEvents lblNumConsegna As System.Windows.Forms.Label
    Friend WithEvents btnSelectUserTaskList As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
