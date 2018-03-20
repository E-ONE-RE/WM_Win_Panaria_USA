<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_8_Rietichettatura
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.txtUM_Origine = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneDestinazione = New System.Windows.Forms.Label()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtUM_Destinazione = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 269)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 32)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(165, 269)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(69, 32)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "OK"
        '
        'txtUM_Origine
        '
        Me.txtUM_Origine.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtUM_Origine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM_Origine.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Origine.Location = New System.Drawing.Point(0, 203)
        Me.txtUM_Origine.Name = "txtUM_Origine"
        Me.txtUM_Origine.ReadOnly = True
        Me.txtUM_Origine.Size = New System.Drawing.Size(237, 24)
        Me.txtUM_Origine.TabIndex = 0
        Me.txtUM_Origine.TabStop = False
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(0, 187)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(237, 16)
        Me.lblUbicazioneDestinazione.TabIndex = 3
        Me.lblUbicazioneDestinazione.Text = "Unita Magazzino Vecchia"
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 188)
        Me.txtInfoJobSelezionato.TabIndex = 0
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtUM_Destinazione
        '
        Me.txtUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Destinazione.Location = New System.Drawing.Point(0, 243)
        Me.txtUM_Destinazione.MaxLength = 10
        Me.txtUM_Destinazione.Name = "txtUM_Destinazione"
        Me.txtUM_Destinazione.Size = New System.Drawing.Size(237, 25)
        Me.txtUM_Destinazione.TabIndex = 1
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(2, 227)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(234, 15)
        Me.lblCodiceUM.TabIndex = 2
        Me.lblCodiceUM.Text = "Unita Magazzino Nuova"
        '
        'frmPickingMerci_Appr_8_Rietichettatura
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 303)
        Me.Controls.Add(Me.txtUM_Destinazione)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.txtUM_Origine)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_8_Rietichettatura"
        Me.Text = "Picking Appr. (8)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM_Origine As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneDestinazione As System.Windows.Forms.Label
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtUM_Destinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
End Class
