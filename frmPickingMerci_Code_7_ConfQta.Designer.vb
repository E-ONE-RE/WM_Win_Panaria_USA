<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_7_ConfQta
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.ckboxFlagForcedStepEnded = New System.Windows.Forms.CheckBox()
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.txtInfoPesoMissione = New System.Windows.Forms.TextBox()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.lblInfoTaskLinesOnWork = New System.Windows.Forms.Label()
        Me.cmdDropUDS = New System.Windows.Forms.Button()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(780, 642)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(554, 642)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdPreviousScreen.TabIndex = 11
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(9, 642)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(210, 68)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Lavender
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(684, 552)
        Me.lblUDMQuantita.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(90, 33)
        Me.lblUDMQuantita.TabIndex = 2
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(683, 589)
        Me.txtUDMQuantità.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(82, 35)
        Me.txtUDMQuantità.TabIndex = 0
        Me.txtUDMQuantità.TabStop = False
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Lavender
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(473, 552)
        Me.lblQtaPrevista.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(202, 37)
        Me.lblQtaPrevista.TabIndex = 3
        Me.lblQtaPrevista.Text = "Qta Prev."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(469, 589)
        Me.txtQtaPrevista.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(206, 35)
        Me.txtQtaPrevista.TabIndex = 0
        Me.txtQtaPrevista.TabStop = False
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(775, 551)
        Me.lblQtaConfermata.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(220, 38)
        Me.lblQtaConfermata.TabIndex = 4
        Me.lblQtaConfermata.Text = "Qtà Confermata"
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(773, 589)
        Me.txtQtaConfermata.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(222, 35)
        Me.txtQtaConfermata.TabIndex = 1
        '
        'ckboxFlagForcedStepEnded
        '
        Me.ckboxFlagForcedStepEnded.Enabled = False
        Me.ckboxFlagForcedStepEnded.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckboxFlagForcedStepEnded.Location = New System.Drawing.Point(469, 502)
        Me.ckboxFlagForcedStepEnded.Margin = New System.Windows.Forms.Padding(4)
        Me.ckboxFlagForcedStepEnded.Name = "ckboxFlagForcedStepEnded"
        Me.ckboxFlagForcedStepEnded.Size = New System.Drawing.Size(206, 36)
        Me.ckboxFlagForcedStepEnded.TabIndex = 0
        Me.ckboxFlagForcedStepEnded.Text = "Fine"
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(5, 3)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(998, 28)
        Me.lblSystemInfo.TabIndex = 120
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'txtInfoPesoMissione
        '
        Me.txtInfoPesoMissione.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtInfoPesoMissione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoPesoMissione.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPesoMissione.Location = New System.Drawing.Point(9, 502)
        Me.txtInfoPesoMissione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoPesoMissione.Multiline = True
        Me.txtInfoPesoMissione.Name = "txtInfoPesoMissione"
        Me.txtInfoPesoMissione.ReadOnly = True
        Me.txtInfoPesoMissione.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoPesoMissione.Size = New System.Drawing.Size(440, 132)
        Me.txtInfoPesoMissione.TabIndex = 126
        Me.txtInfoPesoMissione.TabStop = False
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(5, 33)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoUDSOnWork.TabIndex = 127
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'lblInfoTaskLinesOnWork
        '
        Me.lblInfoTaskLinesOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoTaskLinesOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoTaskLinesOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoTaskLinesOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoTaskLinesOnWork.Location = New System.Drawing.Point(4, 62)
        Me.lblInfoTaskLinesOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoTaskLinesOnWork.Name = "lblInfoTaskLinesOnWork"
        Me.lblInfoTaskLinesOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoTaskLinesOnWork.TabIndex = 132
        Me.lblInfoTaskLinesOnWork.Text = "TASK ATTIVO:"
        '
        'cmdDropUDS
        '
        Me.cmdDropUDS.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdDropUDS.Location = New System.Drawing.Point(225, 642)
        Me.cmdDropUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDropUDS.Name = "cmdDropUDS"
        Me.cmdDropUDS.Size = New System.Drawing.Size(210, 68)
        Me.cmdDropUDS.TabIndex = 133
        Me.cmdDropUDS.Text = "Drop Pallet"
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(440, 642)
        Me.cmdJobFunctions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(110, 68)
        Me.cmdJobFunctions.TabIndex = 206
        Me.cmdJobFunctions.Text = "Opzioni"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(5, 94)
        Me.txtInfoJobSelezionato.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(998, 400)
        Me.txtInfoJobSelezionato.TabIndex = 0
        Me.txtInfoJobSelezionato.TabStop = False
        Me.txtInfoJobSelezionato.Text = ""
        '
        'frmPickingMerci_Code_6_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.cmdDropUDS)
        Me.Controls.Add(Me.lblInfoTaskLinesOnWork)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.txtInfoPesoMissione)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.ckboxFlagForcedStepEnded)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_6_ConfQta"
        Me.Text = "Picking Task (6)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents ckboxFlagForcedStepEnded As System.Windows.Forms.CheckBox
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents txtInfoPesoMissione As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents lblInfoTaskLinesOnWork As System.Windows.Forms.Label
    Friend WithEvents cmdDropUDS As System.Windows.Forms.Button
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.RichTextBox
End Class
