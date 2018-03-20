<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDisaccantonaMerci_2_Ubi_e_UM_Origine
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
        Me.txtUbicazioneOrigine = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtCodiceUMOrigine = New System.Windows.Forms.TextBox()
        Me.lblCodiceUMOrigine = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 250)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 43)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(109, 250)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 43)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(175, 250)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 43)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = ">"
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(0, 183)
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(237, 24)
        Me.txtUbicazioneOrigine.TabIndex = 161
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(0, 165)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(237, 17)
        Me.lblUbicazioneOrigine.TabIndex = 208
        Me.lblUbicazioneOrigine.Text = "Ubicazione Prelievo"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(0, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(238, 165)
        Me.txtInfoJobSelezionato.TabIndex = 203
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtCodiceUMOrigine
        '
        Me.txtCodiceUMOrigine.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCodiceUMOrigine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceUMOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceUMOrigine.Location = New System.Drawing.Point(0, 224)
        Me.txtCodiceUMOrigine.Name = "txtCodiceUMOrigine"
        Me.txtCodiceUMOrigine.Size = New System.Drawing.Size(237, 25)
        Me.txtCodiceUMOrigine.TabIndex = 206
        '
        'lblCodiceUMOrigine
        '
        Me.lblCodiceUMOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUMOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceUMOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUMOrigine.Location = New System.Drawing.Point(0, 207)
        Me.lblCodiceUMOrigine.Name = "lblCodiceUMOrigine"
        Me.lblCodiceUMOrigine.Size = New System.Drawing.Size(236, 16)
        Me.lblCodiceUMOrigine.TabIndex = 207
        Me.lblCodiceUMOrigine.Text = "UM Prelievo"
        '
        'frmDisaccantonaMerci_2_Ubi_e_UM_Origine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtCodiceUMOrigine)
        Me.Controls.Add(Me.lblCodiceUMOrigine)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDisaccantonaMerci_2_Ubi_e_UM_Origine"
        Me.Text = "Disaccant.(2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtCodiceUMOrigine As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUMOrigine As System.Windows.Forms.Label
End Class
