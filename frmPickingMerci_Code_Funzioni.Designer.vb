<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_Funzioni
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
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.cmdForcedNextStep = New System.Windows.Forms.Button()
        Me.cmdForcedEndJob = New System.Windows.Forms.Button()
        Me.cmdPickListInfo = New System.Windows.Forms.Button()
        Me.cmdSetZeroPick = New System.Windows.Forms.Button()
        Me.cmdSetDropPick = New System.Windows.Forms.Button()
        Me.cmdExecJobGetBestOriLocation = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(776, 656)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 68)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(1, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(995, 319)
        Me.txtInfoJobSelezionato.TabIndex = 57
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdForcedNextStep
        '
        Me.cmdForcedNextStep.Enabled = False
        Me.cmdForcedNextStep.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdForcedNextStep.Location = New System.Drawing.Point(1, 523)
        Me.cmdForcedNextStep.Name = "cmdForcedNextStep"
        Me.cmdForcedNextStep.Size = New System.Drawing.Size(995, 57)
        Me.cmdForcedNextStep.TabIndex = 94
        Me.cmdForcedNextStep.Text = "Forza Fine Step"
        '
        'cmdForcedEndJob
        '
        Me.cmdForcedEndJob.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdForcedEndJob.Location = New System.Drawing.Point(-1, 457)
        Me.cmdForcedEndJob.Name = "cmdForcedEndJob"
        Me.cmdForcedEndJob.Size = New System.Drawing.Size(995, 57)
        Me.cmdForcedEndJob.TabIndex = 95
        Me.cmdForcedEndJob.Text = "Forza Termina Missione"
        '
        'cmdPickListInfo
        '
        Me.cmdPickListInfo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPickListInfo.Location = New System.Drawing.Point(3, 656)
        Me.cmdPickListInfo.Name = "cmdPickListInfo"
        Me.cmdPickListInfo.Size = New System.Drawing.Size(767, 68)
        Me.cmdPickListInfo.TabIndex = 96
        Me.cmdPickListInfo.Text = "Info Prelievo Gruppo Miss."
        '
        'cmdSetZeroPick
        '
        Me.cmdSetZeroPick.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSetZeroPick.Location = New System.Drawing.Point(-1, 325)
        Me.cmdSetZeroPick.Name = "cmdSetZeroPick"
        Me.cmdSetZeroPick.Size = New System.Drawing.Size(995, 57)
        Me.cmdSetZeroPick.TabIndex = 97
        Me.cmdSetZeroPick.Text = "Forza Termina Con Qta Zero"
        '
        'cmdSetDropPick
        '
        Me.cmdSetDropPick.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSetDropPick.Location = New System.Drawing.Point(-1, 391)
        Me.cmdSetDropPick.Name = "cmdSetDropPick"
        Me.cmdSetDropPick.Size = New System.Drawing.Size(995, 57)
        Me.cmdSetDropPick.TabIndex = 98
        Me.cmdSetDropPick.Text = "Forza Annulla Prenotazione Missione"
        '
        'cmdExecJobGetBestOriLocation
        '
        Me.cmdExecJobGetBestOriLocation.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdExecJobGetBestOriLocation.Location = New System.Drawing.Point(3, 589)
        Me.cmdExecJobGetBestOriLocation.Name = "cmdExecJobGetBestOriLocation"
        Me.cmdExecJobGetBestOriLocation.Size = New System.Drawing.Size(995, 57)
        Me.cmdExecJobGetBestOriLocation.TabIndex = 99
        Me.cmdExecJobGetBestOriLocation.Text = "Ricalcola"
        '
        'frmPickingMerci_Code_Funzioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cmdExecJobGetBestOriLocation)
        Me.Controls.Add(Me.cmdSetDropPick)
        Me.Controls.Add(Me.cmdSetZeroPick)
        Me.Controls.Add(Me.cmdPickListInfo)
        Me.Controls.Add(Me.cmdForcedEndJob)
        Me.Controls.Add(Me.cmdForcedNextStep)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_Funzioni"
        Me.Text = "Picking Code"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdForcedNextStep As System.Windows.Forms.Button
    Friend WithEvents cmdForcedEndJob As System.Windows.Forms.Button
    Friend WithEvents cmdPickListInfo As System.Windows.Forms.Button
    Friend WithEvents cmdSetZeroPick As System.Windows.Forms.Button
    Friend WithEvents cmdSetDropPick As System.Windows.Forms.Button
    Friend WithEvents cmdExecJobGetBestOriLocation As System.Windows.Forms.Button
End Class
