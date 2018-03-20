<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_5_FinalUMConfirm
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
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUM_Destinazione = New System.Windows.Forms.Label()
        Me.txtUMDestConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 247)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(57, 40)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(119, 247)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(57, 40)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 247)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(57, 40)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUM_Destinazione
        '
        Me.lblUM_Destinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Destinazione.Location = New System.Drawing.Point(2, 219)
        Me.lblUM_Destinazione.Name = "lblUM_Destinazione"
        Me.lblUM_Destinazione.Size = New System.Drawing.Size(76, 20)
        Me.lblUM_Destinazione.TabIndex = 164
        Me.lblUM_Destinazione.Text = "UM.Dest."
        '
        'txtUMDestConfermata
        '
        Me.txtUMDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUMDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUMDestConfermata.Location = New System.Drawing.Point(78, 217)
        Me.txtUMDestConfermata.MaxLength = 10
        Me.txtUMDestConfermata.Name = "txtUMDestConfermata"
        Me.txtUMDestConfermata.Size = New System.Drawing.Size(160, 28)
        Me.txtUMDestConfermata.TabIndex = 138
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(2, 23)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 192)
        Me.txtInfoJobSelezionato.TabIndex = 163
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(0, 0)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(238, 20)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(61, 247)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 40)
        Me.Button1.TabIndex = 165
        Me.Button1.Text = "Print"
        '
        'frmEM_FromJob_Part_5_FinalUMConfirm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUM_Destinazione)
        Me.Controls.Add(Me.txtUMDestConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_5_FinalUMConfirm"
        Me.Text = "EM - Bem (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUM_Destinazione As System.Windows.Forms.Label
    Friend WithEvents txtUMDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
