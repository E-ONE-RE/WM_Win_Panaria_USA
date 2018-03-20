<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoMappaUbicazioni_1
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
        Me.lblNumMag = New System.Windows.Forms.Label()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtTipiMag = New System.Windows.Forms.TextBox()
        Me.lblTipiMag = New System.Windows.Forms.Label()
        Me.txtUbicazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazione = New System.Windows.Forms.Label()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.cmdSelectTipoMagazzino = New System.Windows.Forms.Button()
        Me.txtNumMag = New System.Windows.Forms.ComboBox()
        Me.grpTaskFullPartialModeExecution = New System.Windows.Forms.GroupBox()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.rdbFull = New System.Windows.Forms.RadioButton()
        Me.rdbEmpty = New System.Windows.Forms.RadioButton()
        Me.grpTaskFullPartialModeExecution.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNumMag
        '
        Me.lblNumMag.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMag.ForeColor = System.Drawing.Color.Black
        Me.lblNumMag.Location = New System.Drawing.Point(1, 0)
        Me.lblNumMag.Name = "lblNumMag"
        Me.lblNumMag.Size = New System.Drawing.Size(234, 28)
        Me.lblNumMag.TabIndex = 52
        Me.lblNumMag.Text = "Num.Mag."
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 213)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 213)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 63)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtTipiMag
        '
        Me.txtTipiMag.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtTipiMag.ForeColor = System.Drawing.Color.Black
        Me.txtTipiMag.Location = New System.Drawing.Point(1, 102)
        Me.txtTipiMag.MaxLength = 3
        Me.txtTipiMag.Name = "txtTipiMag"
        Me.txtTipiMag.Size = New System.Drawing.Size(89, 30)
        Me.txtTipiMag.TabIndex = 16
        '
        'lblTipiMag
        '
        Me.lblTipiMag.BackColor = System.Drawing.Color.Yellow
        Me.lblTipiMag.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipiMag.ForeColor = System.Drawing.Color.Black
        Me.lblTipiMag.Location = New System.Drawing.Point(1, 74)
        Me.lblTipiMag.Name = "lblTipiMag"
        Me.lblTipiMag.Size = New System.Drawing.Size(88, 28)
        Me.lblTipiMag.TabIndex = 51
        Me.lblTipiMag.Text = "Tip.Mag."
        '
        'txtUbicazione
        '
        Me.txtUbicazione.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazione.Location = New System.Drawing.Point(1, 175)
        Me.txtUbicazione.MaxLength = 10
        Me.txtUbicazione.Name = "txtUbicazione"
        Me.txtUbicazione.Size = New System.Drawing.Size(186, 30)
        Me.txtUbicazione.TabIndex = 24
        '
        'lblUbicazione
        '
        Me.lblUbicazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazione.Location = New System.Drawing.Point(1, 147)
        Me.lblUbicazione.Name = "lblUbicazione"
        Me.lblUbicazione.Size = New System.Drawing.Size(186, 28)
        Me.lblUbicazione.TabIndex = 50
        Me.lblUbicazione.Text = "Ubicazione"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(187, 147)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(50, 53)
        Me.cmdSelectUbicazione.TabIndex = 30
        Me.cmdSelectUbicazione.Text = "..."
        '
        'cmdSelectTipoMagazzino
        '
        Me.cmdSelectTipoMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectTipoMagazzino.Location = New System.Drawing.Point(92, 73)
        Me.cmdSelectTipoMagazzino.Name = "cmdSelectTipoMagazzino"
        Me.cmdSelectTipoMagazzino.Size = New System.Drawing.Size(50, 54)
        Me.cmdSelectTipoMagazzino.TabIndex = 36
        Me.cmdSelectTipoMagazzino.Text = "..."
        '
        'txtNumMag
        '
        Me.txtNumMag.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMag.Location = New System.Drawing.Point(0, 29)
        Me.txtNumMag.Name = "txtNumMag"
        Me.txtNumMag.Size = New System.Drawing.Size(236, 32)
        Me.txtNumMag.TabIndex = 49
        '
        'grpTaskFullPartialModeExecution
        '
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbAll)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbFull)
        Me.grpTaskFullPartialModeExecution.Controls.Add(Me.rdbEmpty)
        Me.grpTaskFullPartialModeExecution.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTaskFullPartialModeExecution.Location = New System.Drawing.Point(152, 74)
        Me.grpTaskFullPartialModeExecution.Name = "grpTaskFullPartialModeExecution"
        Me.grpTaskFullPartialModeExecution.Size = New System.Drawing.Size(85, 53)
        Me.grpTaskFullPartialModeExecution.TabIndex = 117
        Me.grpTaskFullPartialModeExecution.TabStop = False
        Me.grpTaskFullPartialModeExecution.Text = "Filtro"
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Location = New System.Drawing.Point(9, 22)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(73, 22)
        Me.rdbAll.TabIndex = 133
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "Tutte"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'rdbFull
        '
        Me.rdbFull.AutoSize = True
        Me.rdbFull.Location = New System.Drawing.Point(9, 83)
        Me.rdbFull.Name = "rdbFull"
        Me.rdbFull.Size = New System.Drawing.Size(111, 22)
        Me.rdbFull.TabIndex = 1
        Me.rdbFull.TabStop = True
        Me.rdbFull.Text = "solo piene"
        Me.rdbFull.UseVisualStyleBackColor = True
        '
        'rdbEmpty
        '
        Me.rdbEmpty.AutoSize = True
        Me.rdbEmpty.Location = New System.Drawing.Point(9, 51)
        Me.rdbEmpty.Name = "rdbEmpty"
        Me.rdbEmpty.Size = New System.Drawing.Size(114, 22)
        Me.rdbEmpty.TabIndex = 0
        Me.rdbEmpty.TabStop = True
        Me.rdbEmpty.Text = "solo vuote"
        Me.rdbEmpty.UseVisualStyleBackColor = True
        '
        'frmInfoMappaUbicazioni_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.grpTaskFullPartialModeExecution)
        Me.Controls.Add(Me.txtNumMag)
        Me.Controls.Add(Me.cmdSelectTipoMagazzino)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazione)
        Me.Controls.Add(Me.lblUbicazione)
        Me.Controls.Add(Me.txtTipiMag)
        Me.Controls.Add(Me.lblTipiMag)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.lblNumMag)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoMappaUbicazioni_1"
        Me.Text = "Info Map.Ubicaz.(1)"
        Me.grpTaskFullPartialModeExecution.ResumeLayout(False)
        Me.grpTaskFullPartialModeExecution.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumMag As System.Windows.Forms.Label
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtTipiMag As System.Windows.Forms.TextBox
    Friend WithEvents lblTipiMag As System.Windows.Forms.Label
    Friend WithEvents txtUbicazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazione As System.Windows.Forms.Label
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents cmdSelectTipoMagazzino As System.Windows.Forms.Button
    Friend WithEvents txtNumMag As System.Windows.Forms.ComboBox
    Friend WithEvents grpTaskFullPartialModeExecution As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFull As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEmpty As System.Windows.Forms.RadioButton
End Class
