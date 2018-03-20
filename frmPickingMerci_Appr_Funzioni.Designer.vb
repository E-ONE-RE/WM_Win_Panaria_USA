<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_Funzioni
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
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 242)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 42)
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(236, 114)
        Me.txtInfoJobSelezionato.TabIndex = 57
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdForcedNextStep
        '
        Me.cmdForcedNextStep.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdForcedNextStep.Location = New System.Drawing.Point(3, 157)
        Me.cmdForcedNextStep.Name = "cmdForcedNextStep"
        Me.cmdForcedNextStep.Size = New System.Drawing.Size(232, 36)
        Me.cmdForcedNextStep.TabIndex = 94
        Me.cmdForcedNextStep.Text = "Forza Fine Step"
        '
        'cmdForcedEndJob
        '
        Me.cmdForcedEndJob.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdForcedEndJob.Location = New System.Drawing.Point(3, 199)
        Me.cmdForcedEndJob.Name = "cmdForcedEndJob"
        Me.cmdForcedEndJob.Size = New System.Drawing.Size(232, 36)
        Me.cmdForcedEndJob.TabIndex = 95
        Me.cmdForcedEndJob.Text = "Forza Termina Missione"
        '
        'cmdPickListInfo
        '
        Me.cmdPickListInfo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPickListInfo.Location = New System.Drawing.Point(3, 116)
        Me.cmdPickListInfo.Name = "cmdPickListInfo"
        Me.cmdPickListInfo.Size = New System.Drawing.Size(232, 36)
        Me.cmdPickListInfo.TabIndex = 96
        Me.cmdPickListInfo.Text = "Info Prelievo Gruppo Miss."
        '
        'frmPickingMerci_Appr_Funzioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdPickListInfo)
        Me.Controls.Add(Me.cmdForcedEndJob)
        Me.Controls.Add(Me.cmdForcedNextStep)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_Funzioni"
        Me.Text = "Picking Appr. (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdForcedNextStep As System.Windows.Forms.Button
    Friend WithEvents cmdForcedEndJob As System.Windows.Forms.Button
    Friend WithEvents cmdPickListInfo As System.Windows.Forms.Button
End Class
