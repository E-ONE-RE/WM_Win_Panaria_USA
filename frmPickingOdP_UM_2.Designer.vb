<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingOdP_UM_2
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
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUnitaMagazzinoOrigine = New System.Windows.Forms.Label()
        Me.cmdUbica = New System.Windows.Forms.Button()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.txtInfoUMSelezionata = New System.Windows.Forms.TextBox()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.lblUDMQuantita = New System.Windows.Forms.Label()
        Me.txtUDMQuantità = New System.Windows.Forms.TextBox()
        Me.lblQtaPrevista = New System.Windows.Forms.Label()
        Me.txtQtaPrevista = New System.Windows.Forms.TextBox()
        Me.cmdOkBC = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 230)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(58, 54)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(33, 148)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(205, 25)
        Me.txtUM.TabIndex = 14
        '
        'lblUnitaMagazzinoOrigine
        '
        Me.lblUnitaMagazzinoOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUnitaMagazzinoOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitaMagazzinoOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUnitaMagazzinoOrigine.Location = New System.Drawing.Point(0, 148)
        Me.lblUnitaMagazzinoOrigine.Name = "lblUnitaMagazzinoOrigine"
        Me.lblUnitaMagazzinoOrigine.Size = New System.Drawing.Size(35, 24)
        Me.lblUnitaMagazzinoOrigine.TabIndex = 143
        Me.lblUnitaMagazzinoOrigine.Text = "UM"
        '
        'cmdUbica
        '
        Me.cmdUbica.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdUbica.Location = New System.Drawing.Point(180, 230)
        Me.cmdUbica.Name = "cmdUbica"
        Me.cmdUbica.Size = New System.Drawing.Size(58, 54)
        Me.cmdUbica.TabIndex = 16
        Me.cmdUbica.Text = "OK"
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(151, 180)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(86, 16)
        Me.lblQtaConfermata.TabIndex = 142
        Me.lblQtaConfermata.Text = "Quantità"
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(150, 197)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(87, 24)
        Me.txtQtaConfermata.TabIndex = 118
        '
        'txtInfoUMSelezionata
        '
        Me.txtInfoUMSelezionata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUMSelezionata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUMSelezionata.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUMSelezionata.Location = New System.Drawing.Point(0, 0)
        Me.txtInfoUMSelezionata.Multiline = True
        Me.txtInfoUMSelezionata.Name = "txtInfoUMSelezionata"
        Me.txtInfoUMSelezionata.ReadOnly = True
        Me.txtInfoUMSelezionata.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUMSelezionata.Size = New System.Drawing.Size(240, 145)
        Me.txtInfoUMSelezionata.TabIndex = 128
        Me.txtInfoUMSelezionata.TabStop = False
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(63, 230)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(50, 54)
        Me.cmdPreviousScreen.TabIndex = 129
        Me.cmdPreviousScreen.Text = "<"
        '
        'lblUDMQuantita
        '
        Me.lblUDMQuantita.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantita.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantita.Location = New System.Drawing.Point(95, 182)
        Me.lblUDMQuantita.Name = "lblUDMQuantita"
        Me.lblUDMQuantita.Size = New System.Drawing.Size(34, 13)
        Me.lblUDMQuantita.TabIndex = 140
        Me.lblUDMQuantita.Text = "UdM"
        '
        'txtUDMQuantità
        '
        Me.txtUDMQuantità.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantità.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantità.Location = New System.Drawing.Point(95, 197)
        Me.txtUDMQuantità.Name = "txtUDMQuantità"
        Me.txtUDMQuantità.ReadOnly = True
        Me.txtUDMQuantità.Size = New System.Drawing.Size(37, 24)
        Me.txtUDMQuantità.TabIndex = 135
        '
        'lblQtaPrevista
        '
        Me.lblQtaPrevista.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaPrevista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.lblQtaPrevista.Location = New System.Drawing.Point(36, 182)
        Me.lblQtaPrevista.Name = "lblQtaPrevista"
        Me.lblQtaPrevista.Size = New System.Drawing.Size(62, 14)
        Me.lblQtaPrevista.TabIndex = 141
        Me.lblQtaPrevista.Text = "Qta Prev."
        '
        'txtQtaPrevista
        '
        Me.txtQtaPrevista.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaPrevista.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaPrevista.ForeColor = System.Drawing.Color.Black
        Me.txtQtaPrevista.Location = New System.Drawing.Point(36, 197)
        Me.txtQtaPrevista.Name = "txtQtaPrevista"
        Me.txtQtaPrevista.ReadOnly = True
        Me.txtQtaPrevista.Size = New System.Drawing.Size(57, 24)
        Me.txtQtaPrevista.TabIndex = 134
        '
        'cmdOkBC
        '
        Me.cmdOkBC.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOkBC.Location = New System.Drawing.Point(119, 230)
        Me.cmdOkBC.Name = "cmdOkBC"
        Me.cmdOkBC.Size = New System.Drawing.Size(58, 54)
        Me.cmdOkBC.TabIndex = 139
        Me.cmdOkBC.Text = "OK BC"
        '
        'frmPickingOdP_UM_2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(240, 285)
        Me.Controls.Add(Me.cmdOkBC)
        Me.Controls.Add(Me.lblUDMQuantita)
        Me.Controls.Add(Me.txtUDMQuantità)
        Me.Controls.Add(Me.lblQtaPrevista)
        Me.Controls.Add(Me.txtQtaPrevista)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.txtInfoUMSelezionata)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.Controls.Add(Me.cmdUbica)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUnitaMagazzinoOrigine)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingOdP_UM_2"
        Me.Text = "Picking - UM (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitaMagazzinoOrigine As System.Windows.Forms.Label
    Friend WithEvents cmdUbica As System.Windows.Forms.Button
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoUMSelezionata As System.Windows.Forms.TextBox
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblUDMQuantita As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantità As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaPrevista As System.Windows.Forms.Label
    Friend WithEvents txtQtaPrevista As System.Windows.Forms.TextBox
    Friend WithEvents cmdOkBC As System.Windows.Forms.Button
End Class
