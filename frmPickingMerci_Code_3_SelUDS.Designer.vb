<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_3_SelUDS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPickingMerci_Code_3_SelUDS))
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtCodiceUM = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.cmdSelectUDSTask = New System.Windows.Forms.Button()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.txtInfoPesoMissione = New System.Windows.Forms.TextBox()
        Me.iconWeight = New System.Windows.Forms.PictureBox()
        Me.cmdDropUDS = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.lblInfoTaskLinesOnWork = New System.Windows.Forms.Label()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.RichTextBox()
        CType(Me.iconWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(780, 649)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdNextScreen.TabIndex = 11
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(6, 649)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(210, 68)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtCodiceUM
        '
        Me.txtCodiceUM.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceUM.Location = New System.Drawing.Point(6, 589)
        Me.txtCodiceUM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodiceUM.MaxLength = 10
        Me.txtCodiceUM.Name = "txtCodiceUM"
        Me.txtCodiceUM.Size = New System.Drawing.Size(294, 35)
        Me.txtCodiceUM.TabIndex = 0
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Verdana", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(6, 548)
        Me.lblCodiceUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(294, 40)
        Me.lblCodiceUM.TabIndex = 2
        Me.lblCodiceUM.Text = "Codice UDS"
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(4, 3)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(998, 28)
        Me.lblSystemInfo.TabIndex = 118
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'cmdSelectUDSTask
        '
        Me.cmdSelectUDSTask.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUDSTask.Location = New System.Drawing.Point(308, 544)
        Me.cmdSelectUDSTask.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectUDSTask.Name = "cmdSelectUDSTask"
        Me.cmdSelectUDSTask.Size = New System.Drawing.Size(120, 82)
        Me.cmdSelectUDSTask.TabIndex = 119
        Me.cmdSelectUDSTask.Text = "..."
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(5, 34)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoUDSOnWork.TabIndex = 124
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'txtInfoPesoMissione
        '
        Me.txtInfoPesoMissione.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtInfoPesoMissione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoPesoMissione.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPesoMissione.Location = New System.Drawing.Point(591, 541)
        Me.txtInfoPesoMissione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoPesoMissione.Multiline = True
        Me.txtInfoPesoMissione.Name = "txtInfoPesoMissione"
        Me.txtInfoPesoMissione.ReadOnly = True
        Me.txtInfoPesoMissione.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoPesoMissione.Size = New System.Drawing.Size(409, 95)
        Me.txtInfoPesoMissione.TabIndex = 125
        Me.txtInfoPesoMissione.TabStop = False
        '
        'iconWeight
        '
        Me.iconWeight.Image = CType(resources.GetObject("iconWeight.Image"), System.Drawing.Image)
        Me.iconWeight.Location = New System.Drawing.Point(484, 541)
        Me.iconWeight.Name = "iconWeight"
        Me.iconWeight.Size = New System.Drawing.Size(105, 96)
        Me.iconWeight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.iconWeight.TabIndex = 126
        Me.iconWeight.TabStop = False
        '
        'cmdDropUDS
        '
        Me.cmdDropUDS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdDropUDS.Location = New System.Drawing.Point(220, 649)
        Me.cmdDropUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDropUDS.Name = "cmdDropUDS"
        Me.cmdDropUDS.Size = New System.Drawing.Size(210, 68)
        Me.cmdDropUDS.TabIndex = 127
        Me.cmdDropUDS.Text = "Drop Pallet"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(552, 649)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdPreviousScreen.TabIndex = 128
        Me.cmdPreviousScreen.Text = "<"
        '
        'lblInfoTaskLinesOnWork
        '
        Me.lblInfoTaskLinesOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoTaskLinesOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoTaskLinesOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoTaskLinesOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoTaskLinesOnWork.Location = New System.Drawing.Point(5, 64)
        Me.lblInfoTaskLinesOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoTaskLinesOnWork.Name = "lblInfoTaskLinesOnWork"
        Me.lblInfoTaskLinesOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoTaskLinesOnWork.TabIndex = 131
        Me.lblInfoTaskLinesOnWork.Text = "TASK ATTIVO:"
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(436, 649)
        Me.cmdJobFunctions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(110, 68)
        Me.cmdJobFunctions.TabIndex = 132
        Me.cmdJobFunctions.Text = "Opzioni"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(1, 92)
        Me.txtInfoJobSelezionato.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(1001, 444)
        Me.txtInfoJobSelezionato.TabIndex = 200
        Me.txtInfoJobSelezionato.TabStop = False
        Me.txtInfoJobSelezionato.Text = ""
        '
        'frmPickingMerci_Code_3_SelUDS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.lblInfoTaskLinesOnWork)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdDropUDS)
        Me.Controls.Add(Me.iconWeight)
        Me.Controls.Add(Me.txtInfoPesoMissione)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.cmdSelectUDSTask)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.txtCodiceUM)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_3_SelUDS"
        Me.Text = "Picking Task (3)"
        CType(Me.iconWeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtCodiceUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUDSTask As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents txtInfoPesoMissione As System.Windows.Forms.TextBox
    Friend WithEvents iconWeight As System.Windows.Forms.PictureBox
    Friend WithEvents cmdDropUDS As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblInfoTaskLinesOnWork As System.Windows.Forms.Label
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.RichTextBox
End Class
