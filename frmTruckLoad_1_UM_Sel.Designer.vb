<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTruckLoad_1_UM_Sel
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
        Me.btnUDSJobsMoveList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(773, 630)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(13, 630)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(3, 582)
        Me.txtUM.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(348, 40)
        Me.txtUM.TabIndex = 83
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Yellow
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(1, 539)
        Me.lblUM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(350, 37)
        Me.lblUM.TabIndex = 166
        Me.lblUM.Text = "UDS Da Caricare"
        '
        'txtInfoOperazioneUtente
        '
        Me.txtInfoOperazioneUtente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoOperazioneUtente.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoOperazioneUtente.ForeColor = System.Drawing.Color.Black
        Me.txtInfoOperazioneUtente.Location = New System.Drawing.Point(3, 34)
        Me.txtInfoOperazioneUtente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoOperazioneUtente.Multiline = True
        Me.txtInfoOperazioneUtente.Name = "txtInfoOperazioneUtente"
        Me.txtInfoOperazioneUtente.ReadOnly = True
        Me.txtInfoOperazioneUtente.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoOperazioneUtente.Size = New System.Drawing.Size(997, 496)
        Me.txtInfoOperazioneUtente.TabIndex = 164
        Me.txtInfoOperazioneUtente.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(525, 630)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(220, 80)
        Me.cmdOK.TabIndex = 165
        Me.cmdOK.Text = "OK"
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(1, 0)
        Me.lblInfoUDC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(1001, 29)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDS: 0"
        '
        'btnUDSJobsMoveList
        '
        Me.btnUDSJobsMoveList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnUDSJobsMoveList.Location = New System.Drawing.Point(267, 630)
        Me.btnUDSJobsMoveList.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUDSJobsMoveList.Name = "btnUDSJobsMoveList"
        Me.btnUDSJobsMoveList.Size = New System.Drawing.Size(220, 80)
        Me.btnUDSJobsMoveList.TabIndex = 167
        Me.btnUDSJobsMoveList.Tag = "PK01005"
        Me.btnUDSJobsMoveList.Text = "Lista UDS"
        '
        'frmTruckLoad_1_UM_Sel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.btnUDSJobsMoveList)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtInfoOperazioneUtente)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTruckLoad_1_UM_Sel"
        Me.Text = "Carico Camion (1)"
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
    Friend WithEvents btnUDSJobsMoveList As System.Windows.Forms.Button
End Class
