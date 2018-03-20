<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromJob_Part_4_ConfQta
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
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantità = New System.Windows.Forms.Label()
        Me.txtUDMQuantita = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.lblQtaSfusiConfermata = New System.Windows.Forms.Label()
        Me.txtQtaSfusiConfermata = New System.Windows.Forms.TextBox()
        Me.txtQtaPrevistaSfusi = New System.Windows.Forms.TextBox()
        Me.txtUDMQuantitaSfusi = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(2, 254)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(76, 37)
        Me.cmdAbortScreen.TabIndex = 65
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(110, 254)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 37)
        Me.cmdPreviousScreen.TabIndex = 64
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(176, 254)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 37)
        Me.cmdNextScreen.TabIndex = 62
        Me.cmdNextScreen.Text = ">"
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(2, 179)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(62, 19)
        Me.lblQtaPrevista.TabIndex = 213
        Me.lblQtaPrevista.Text = "Rich."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(2, 196)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(57, 28)
        Me.txtQtaPrevista.TabIndex = 59
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(106, 196)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(70, 21)
        Me.lblQtaConfermata.TabIndex = 214
        Me.lblQtaConfermata.Text = "Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(178, 196)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(57, 28)
        Me.txtQtaConfermata.TabIndex = 57
        '
        'lblUDMQuantità
        '
        Me.lblUDMQuantità.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantità.Location = New System.Drawing.Point(61, 179)
        Me.lblUDMQuantità.Name = "lblUDMQuantità"
        Me.lblUDMQuantità.Size = New System.Drawing.Size(34, 18)
        Me.lblUDMQuantità.TabIndex = 212
        Me.lblUDMQuantità.Text = "UdM"
        '
        'txtUDMQuantita
        '
        Me.txtUDMQuantita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantita.Location = New System.Drawing.Point(61, 196)
        Me.txtUDMQuantita.Name = "txtUDMQuantita"
        Me.txtUDMQuantita.ReadOnly = True
        Me.txtUDMQuantita.Size = New System.Drawing.Size(37, 28)
        Me.txtUDMQuantita.TabIndex = 114
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(2, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 174)
        Me.txtInfoJobSelezionato.TabIndex = 170
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'lblQtaSfusiConfermata
        '
        Me.lblQtaSfusiConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaSfusiConfermata.Location = New System.Drawing.Point(106, 223)
        Me.lblQtaSfusiConfermata.Name = "lblQtaSfusiConfermata"
        Me.lblQtaSfusiConfermata.Size = New System.Drawing.Size(70, 21)
        Me.lblQtaSfusiConfermata.TabIndex = 0
        Me.lblQtaSfusiConfermata.Text = "Sfusi"
        '
        'txtQtaSfusiConfermata
        '
        Me.txtQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiConfermata.Location = New System.Drawing.Point(178, 223)
        Me.txtQtaSfusiConfermata.Name = "txtQtaSfusiConfermata"
        Me.txtQtaSfusiConfermata.Size = New System.Drawing.Size(57, 28)
        Me.txtQtaSfusiConfermata.TabIndex = 211
        '
        'txtQtaPrevistaSfusi
        '
        Me.txtQtaPrevistaSfusi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevistaSfusi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevistaSfusi.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevistaSfusi.Location = New System.Drawing.Point(2, 223)
        Me.txtQtaPrevistaSfusi.Name = "txtQtaPrevistaSfusi"
        Me.txtQtaPrevistaSfusi.ReadOnly = True
        Me.txtQtaPrevistaSfusi.Size = New System.Drawing.Size(57, 28)
        Me.txtQtaPrevistaSfusi.TabIndex = 215
        '
        'txtUDMQuantitaSfusi
        '
        Me.txtUDMQuantitaSfusi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantitaSfusi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantitaSfusi.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantitaSfusi.Location = New System.Drawing.Point(61, 223)
        Me.txtUDMQuantitaSfusi.Name = "txtUDMQuantitaSfusi"
        Me.txtUDMQuantitaSfusi.ReadOnly = True
        Me.txtUDMQuantitaSfusi.Size = New System.Drawing.Size(37, 28)
        Me.txtUDMQuantitaSfusi.TabIndex = 216
        '
        'frmEM_FromJob_Part_4_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtUDMQuantita)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.txtUDMQuantitaSfusi)
        Me.Controls.Add(Me.txtQtaPrevistaSfusi)
        Me.Controls.Add(Me.lblQtaSfusiConfermata)
        Me.Controls.Add(Me.txtQtaSfusiConfermata)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantità)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromJob_Part_4_ConfQta"
        Me.Text = "EM - Bem (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantità As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantita As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaSfusiConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaSfusiConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaPrevistaSfusi As System.Windows.Forms.TextBox
    Friend WithEvents txtUDMQuantitaSfusi As System.Windows.Forms.TextBox
End Class
