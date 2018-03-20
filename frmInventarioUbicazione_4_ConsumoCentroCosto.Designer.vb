<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventarioUbicazione_4_ConsumoCentroCosto
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
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.txtCentroCosto = New System.Windows.Forms.ComboBox()
        Me.lblCentroCosto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.lblQtaConfermata.Location = New System.Drawing.Point(165, 193)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(71, 18)
        Me.lblQtaConfermata.TabIndex = 189
        Me.lblQtaConfermata.Text = "Qtà Cons."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.BackColor = System.Drawing.Color.White
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(163, 211)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(75, 24)
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(236, 188)
        Me.txtInfoJobSelezionato.TabIndex = 182
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(127, 194)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(35, 20)
        Me.lblUDMQuantita.TabIndex = 188
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(127, 210)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(35, 24)
        Me.txtUDMQuantità.TabIndex = 181
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtCentroCosto.Location = New System.Drawing.Point(0, 209)
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.Size = New System.Drawing.Size(126, 27)
        Me.txtCentroCosto.TabIndex = 186
        '
        'lblCentroCosto
        '
        Me.lblCentroCosto.BackColor = System.Drawing.Color.Yellow
        Me.lblCentroCosto.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCentroCosto.ForeColor = System.Drawing.Color.Black
        Me.lblCentroCosto.Location = New System.Drawing.Point(2, 192)
        Me.lblCentroCosto.Name = "lblCentroCosto"
        Me.lblCentroCosto.Size = New System.Drawing.Size(124, 17)
        Me.lblCentroCosto.TabIndex = 187
        Me.lblCentroCosto.Text = "Centro Costo"
        '
        'frmInventarioUbicazione_4_ConsumoCentroCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtCentroCosto)
        Me.Controls.Add(Me.lblCentroCosto)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioUbicazione_4_ConsumoCentroCosto"
        Me.Text = "Invent.Ubicazione (4)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents txtCentroCosto As System.Windows.Forms.ComboBox
    Friend WithEvents lblCentroCosto As System.Windows.Forms.Label
End Class
