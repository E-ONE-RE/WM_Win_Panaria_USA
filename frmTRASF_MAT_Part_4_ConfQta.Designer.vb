<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTRASF_MAT_Part_4_ConfQta
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
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.txtQtaInStock = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.lblQtaInStock = New System.Windows.Forms.Label()
        Me.lblQtaSfusiConfermata = New System.Windows.Forms.Label()
        Me.txtQtaSfusiConfermata = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 236)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 46)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 236)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 46)
        Me.cmdPreviousScreen.TabIndex = 60
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 236)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 46)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = ">"
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(238, 149)
        Me.txtInfoJobSelezionato.TabIndex = 178
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.BackColor = System.Drawing.Color.White
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(118, 175)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(120, 28)
        Me.txtQtaConfermata.TabIndex = 186
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(75, 175)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(40, 28)
        Me.txtUDMQuantità.TabIndex = 187
        '
        'txtQtaInStock
        '
        Me.txtQtaInStock.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaInStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaInStock.ForeColor = System.Drawing.Color.Black
        Me.txtQtaInStock.Location = New System.Drawing.Point(0, 175)
        Me.txtQtaInStock.Name = "txtQtaInStock"
        Me.txtQtaInStock.ReadOnly = True
        Me.txtQtaInStock.Size = New System.Drawing.Size(73, 28)
        Me.txtQtaInStock.TabIndex = 185
        Me.txtQtaInStock.TabStop = False
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(75, 159)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(40, 20)
        Me.lblUDMQuantita.TabIndex = 188
        Me.lblUDMQuantita.Text = "UdM"
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(120, 155)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(116, 18)
        Me.lblQtaConfermata.TabIndex = 189
        Me.lblQtaConfermata.Text = "Qtà Confermata"
        '
        'lblQtaInStock
        '
        Me.lblQtaInStock.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaInStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaInStock.ForeColor = System.Drawing.Color.Black
        Me.lblQtaInStock.Location = New System.Drawing.Point(0, 157)
        Me.lblQtaInStock.Name = "lblQtaInStock"
        Me.lblQtaInStock.Size = New System.Drawing.Size(73, 19)
        Me.lblQtaInStock.TabIndex = 190
        Me.lblQtaInStock.Text = "Qta Prev."
        '
        'lblQtaSfusiConfermata
        '
        Me.lblQtaSfusiConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaSfusiConfermata.Location = New System.Drawing.Point(46, 205)
        Me.lblQtaSfusiConfermata.Name = "lblQtaSfusiConfermata"
        Me.lblQtaSfusiConfermata.Size = New System.Drawing.Size(70, 21)
        Me.lblQtaSfusiConfermata.TabIndex = 212
        Me.lblQtaSfusiConfermata.Text = "Sfusi"
        '
        'txtQtaSfusiConfermata
        '
        Me.txtQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiConfermata.Location = New System.Drawing.Point(118, 205)
        Me.txtQtaSfusiConfermata.Name = "txtQtaSfusiConfermata"
        Me.txtQtaSfusiConfermata.Size = New System.Drawing.Size(118, 28)
        Me.txtQtaSfusiConfermata.TabIndex = 213
        '
        'frmTRASF_MAT_Part_4_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblQtaSfusiConfermata)
        Me.Controls.Add(Me.txtQtaSfusiConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.txtQtaInStock)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.lblQtaInStock)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTRASF_MAT_Part_4_ConfQta"
        Me.Text = "TRASF - Mat. (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaInStock As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents lblQtaInStock As System.Windows.Forms.Label
    Friend WithEvents lblQtaSfusiConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaSfusiConfermata As System.Windows.Forms.TextBox
End Class
