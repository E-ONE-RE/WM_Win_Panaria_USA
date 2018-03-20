<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTRASF_UM_Part_1_UM_Ori
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtInfoOperazioneUtente = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 226)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 57)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 226)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 57)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(1, 192)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(238, 27)
        Me.txtUM.TabIndex = 83
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Yellow
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(1, 170)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(237, 21)
        Me.lblUM.TabIndex = 166
        Me.lblUM.Text = "UM Da Trasferire"
        '
        'txtInfoOperazioneUtente
        '
        Me.txtInfoOperazioneUtente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoOperazioneUtente.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoOperazioneUtente.ForeColor = System.Drawing.Color.Black
        Me.txtInfoOperazioneUtente.Location = New System.Drawing.Point(1, 21)
        Me.txtInfoOperazioneUtente.Multiline = True
        Me.txtInfoOperazioneUtente.Name = "txtInfoOperazioneUtente"
        Me.txtInfoOperazioneUtente.ReadOnly = True
        Me.txtInfoOperazioneUtente.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoOperazioneUtente.Size = New System.Drawing.Size(237, 149)
        Me.txtInfoOperazioneUtente.TabIndex = 164
        Me.txtInfoOperazioneUtente.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(86, 226)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(68, 57)
        Me.cmdOK.TabIndex = 165
        Me.cmdOK.Text = "OK"
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(1, 0)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(238, 20)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'frmTRASF_UM_Part_1_UM_Ori
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(240, 285)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtInfoOperazioneUtente)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTRASF_UM_Part_1_UM_Ori"
        Me.Text = "TRASF - Unità Mag.(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents txtInfoOperazioneUtente As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
End Class
