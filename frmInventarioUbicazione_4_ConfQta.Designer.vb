<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_4_ConfQta
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
        Me.lblQtaInStock = New System.Windows.Forms.Label()
        Me.txtQtaInStock = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.txtNumMov = New System.Windows.Forms.ComboBox()
        Me.lblNumMov = New System.Windows.Forms.Label()
        Me.txtUDMQuantitaSfusi = New System.Windows.Forms.TextBox()
        Me.txtQtaPrevistaSfusi = New System.Windows.Forms.TextBox()
        Me.txtQtaSfusiConfermata = New System.Windows.Forms.TextBox()
        Me.txtUDMQuantitaPezzi = New System.Windows.Forms.TextBox()
        Me.txtQtaPrevistaPezzi = New System.Windows.Forms.TextBox()
        Me.txtQtaPezziConfermata = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblQtaInStock
        '
        Me.lblQtaInStock.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaInStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaInStock.ForeColor = System.Drawing.Color.Black
        Me.lblQtaInStock.Location = New System.Drawing.Point(4, 115)
        Me.lblQtaInStock.Name = "lblQtaInStock"
        Me.lblQtaInStock.Size = New System.Drawing.Size(70, 19)
        Me.lblQtaInStock.TabIndex = 185
        Me.lblQtaInStock.Text = "Qta A Sistema"
        '
        'txtQtaInStock
        '
        Me.txtQtaInStock.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaInStock.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaInStock.ForeColor = System.Drawing.Color.Black
        Me.txtQtaInStock.Location = New System.Drawing.Point(7, 134)
        Me.txtQtaInStock.Name = "txtQtaInStock"
        Me.txtQtaInStock.Size = New System.Drawing.Size(62, 28)
        Me.txtQtaInStock.TabIndex = 43
        Me.txtQtaInStock.TabStop = False
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 237)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 44)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 237)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 44)
        Me.cmdPreviousScreen.TabIndex = 60
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 237)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 44)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(123, 115)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(103, 18)
        Me.lblQtaConfermata.TabIndex = 184
        Me.lblQtaConfermata.Text = "Qtà Confermata"
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.BackColor = System.Drawing.Color.White
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(122, 135)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(104, 28)
        Me.txtQtaConfermata.TabIndex = 97
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(1, 0)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(235, 112)
        Me.txtInfoJobSelezionato.TabIndex = 182
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(76, 114)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(45, 20)
        Me.lblUDMQuantita.TabIndex = 183
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(77, 134)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(37, 28)
        Me.txtUDMQuantità.TabIndex = 181
        '
        'txtNumMov
        '
        Me.txtNumMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtNumMov.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNumMov.Location = New System.Drawing.Point(3, 214)
        Me.txtNumMov.Name = "txtNumMov"
        Me.txtNumMov.Size = New System.Drawing.Size(232, 32)
        Me.txtNumMov.TabIndex = 186
        '
        'lblNumMov
        '
        Me.lblNumMov.BackColor = System.Drawing.Color.Yellow
        Me.lblNumMov.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumMov.ForeColor = System.Drawing.Color.Black
        Me.lblNumMov.Location = New System.Drawing.Point(3, 192)
        Me.lblNumMov.Name = "lblNumMov"
        Me.lblNumMov.Size = New System.Drawing.Size(230, 20)
        Me.lblNumMov.TabIndex = 187
        Me.lblNumMov.Text = "Motivo Movimento"
        '
        'txtUDMQuantitaSfusi
        '
        Me.txtUDMQuantitaSfusi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantitaSfusi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantitaSfusi.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantitaSfusi.Location = New System.Drawing.Point(77, 152)
        Me.txtUDMQuantitaSfusi.Name = "txtUDMQuantitaSfusi"
        Me.txtUDMQuantitaSfusi.ReadOnly = True
        Me.txtUDMQuantitaSfusi.Size = New System.Drawing.Size(37, 28)
        Me.txtUDMQuantitaSfusi.TabIndex = 219
        Me.txtUDMQuantitaSfusi.Visible = False
        '
        'txtQtaPrevistaSfusi
        '
        Me.txtQtaPrevistaSfusi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevistaSfusi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevistaSfusi.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevistaSfusi.Location = New System.Drawing.Point(7, 152)
        Me.txtQtaPrevistaSfusi.Name = "txtQtaPrevistaSfusi"
        Me.txtQtaPrevistaSfusi.ReadOnly = True
        Me.txtQtaPrevistaSfusi.Size = New System.Drawing.Size(62, 28)
        Me.txtQtaPrevistaSfusi.TabIndex = 218
        Me.txtQtaPrevistaSfusi.Visible = False
        '
        'txtQtaSfusiConfermata
        '
        Me.txtQtaSfusiConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaSfusiConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaSfusiConfermata.Location = New System.Drawing.Point(122, 152)
        Me.txtQtaSfusiConfermata.Name = "txtQtaSfusiConfermata"
        Me.txtQtaSfusiConfermata.Size = New System.Drawing.Size(104, 28)
        Me.txtQtaSfusiConfermata.TabIndex = 217
        Me.txtQtaSfusiConfermata.Visible = False
        '
        'txtUDMQuantitaPezzi
        '
        Me.txtUDMQuantitaPezzi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantitaPezzi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantitaPezzi.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantitaPezzi.Location = New System.Drawing.Point(77, 170)
        Me.txtUDMQuantitaPezzi.Name = "txtUDMQuantitaPezzi"
        Me.txtUDMQuantitaPezzi.ReadOnly = True
        Me.txtUDMQuantitaPezzi.Size = New System.Drawing.Size(37, 28)
        Me.txtUDMQuantitaPezzi.TabIndex = 222
        '
        'txtQtaPrevistaPezzi
        '
        Me.txtQtaPrevistaPezzi.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevistaPezzi.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevistaPezzi.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevistaPezzi.Location = New System.Drawing.Point(7, 170)
        Me.txtQtaPrevistaPezzi.Name = "txtQtaPrevistaPezzi"
        Me.txtQtaPrevistaPezzi.ReadOnly = True
        Me.txtQtaPrevistaPezzi.Size = New System.Drawing.Size(62, 28)
        Me.txtQtaPrevistaPezzi.TabIndex = 221
        '
        'txtQtaPezziConfermata
        '
        Me.txtQtaPezziConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPezziConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPezziConfermata.Location = New System.Drawing.Point(122, 170)
        Me.txtQtaPezziConfermata.Name = "txtQtaPezziConfermata"
        Me.txtQtaPezziConfermata.Size = New System.Drawing.Size(104, 28)
        Me.txtQtaPezziConfermata.TabIndex = 220
        '
        'frmInventarioUbicazione_4_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtUDMQuantitaPezzi)
        Me.Controls.Add(Me.txtQtaPrevistaPezzi)
        Me.Controls.Add(Me.txtQtaPezziConfermata)
        Me.Controls.Add(Me.txtUDMQuantitaSfusi)
        Me.Controls.Add(Me.txtQtaPrevistaSfusi)
        Me.Controls.Add(Me.txtQtaSfusiConfermata)
        Me.Controls.Add(Me.txtNumMov)
        Me.Controls.Add(Me.lblNumMov)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.txtQtaInStock)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblQtaInStock)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioUbicazione_4_ConfQta"
        Me.Text = "Invent.Ubicazione (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblQtaInStock As System.Windows.Forms.Label
    Friend WithEvents txtQtaInStock As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents txtNumMov As System.Windows.Forms.ComboBox
    Friend WithEvents lblNumMov As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantitaSfusi As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaPrevistaSfusi As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaSfusiConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtUDMQuantitaPezzi As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaPrevistaPezzi As System.Windows.Forms.TextBox
    Friend WithEvents txtQtaPezziConfermata As System.Windows.Forms.TextBox
End Class
