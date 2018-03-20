<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_4_ConfirmUbiDest
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
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.cmdShowStock = New System.Windows.Forms.Button()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.lblLocationProposal = New System.Windows.Forms.Label()
        Me.txtLocationProposal = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(188, 197)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(47, 50)
        Me.cmdSelectUbicazioneDest.TabIndex = 86
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 249)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 41)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(103, 249)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(64, 41)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(171, 249)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(64, 41)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(0, 221)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(117, 14)
        Me.lblUbicazDestConfermata.TabIndex = 187
        Me.lblUbicazDestConfermata.Text = "Ubicazione Dest."
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(0, 233)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(117, 28)
        Me.txtUbicazDestConfermata.TabIndex = 81
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(-1, 24)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 169)
        Me.txtInfoJobSelezionato.TabIndex = 163
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdShowStock
        '
        Me.cmdShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdShowStock.Location = New System.Drawing.Point(123, 197)
        Me.cmdShowStock.Name = "cmdShowStock"
        Me.cmdShowStock.Size = New System.Drawing.Size(61, 49)
        Me.cmdShowStock.TabIndex = 186
        Me.cmdShowStock.Text = "STOCK"
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(0, 1)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(238, 20)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'lblLocationProposal
        '
        Me.lblLocationProposal.BackColor = System.Drawing.Color.Yellow
        Me.lblLocationProposal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLocationProposal.ForeColor = System.Drawing.Color.Black
        Me.lblLocationProposal.Location = New System.Drawing.Point(0, 195)
        Me.lblLocationProposal.Name = "lblLocationProposal"
        Me.lblLocationProposal.Size = New System.Drawing.Size(117, 14)
        Me.lblLocationProposal.TabIndex = 189
        Me.lblLocationProposal.Text = "Ubicazione Dest."
        '
        'txtLocationProposal
        '
        Me.txtLocationProposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLocationProposal.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtLocationProposal.ForeColor = System.Drawing.Color.Black
        Me.txtLocationProposal.Location = New System.Drawing.Point(0, 209)
        Me.txtLocationProposal.Name = "txtLocationProposal"
        Me.txtLocationProposal.ReadOnly = True
        Me.txtLocationProposal.Size = New System.Drawing.Size(117, 28)
        Me.txtLocationProposal.TabIndex = 188
        '
        'frmEM_FromStock_Part_4_ConfirmUbiDest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.Controls.Add(Me.txtLocationProposal)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.cmdShowStock)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.lblLocationProposal)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_4_ConfirmUbiDest"
        Me.Text = "EM - Prod. (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdShowStock As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents lblLocationProposal As System.Windows.Forms.Label
    Friend WithEvents txtLocationProposal As System.Windows.Forms.TextBox
End Class
