<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrintPalletCard_1_UM
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
        Me.lblUnitaMagazzino = New System.Windows.Forms.Label()
        Me.txtUnitaMagazzino = New System.Windows.Forms.TextBox()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUnitaMagazzino
        '
        Me.lblUnitaMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.lblUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.lblUnitaMagazzino.Location = New System.Drawing.Point(1, 40)
        Me.lblUnitaMagazzino.Name = "lblUnitaMagazzino"
        Me.lblUnitaMagazzino.Size = New System.Drawing.Size(235, 28)
        Me.lblUnitaMagazzino.TabIndex = 13
        Me.lblUnitaMagazzino.Text = "Unita Magazzino"
        '
        'txtUnitaMagazzino
        '
        Me.txtUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.txtUnitaMagazzino.Location = New System.Drawing.Point(1, 68)
        Me.txtUnitaMagazzino.MaxLength = 10
        Me.txtUnitaMagazzino.Name = "txtUnitaMagazzino"
        Me.txtUnitaMagazzino.Size = New System.Drawing.Size(235, 25)
        Me.txtUnitaMagazzino.TabIndex = 9
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 225)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 54)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = "STAMPA"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 225)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 54)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'frmPrintPalletCard_1_UM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.txtUnitaMagazzino)
        Me.Controls.Add(Me.lblUnitaMagazzino)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintPalletCard_1_UM"
        Me.Text = "Stampa Pallet Card (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUnitaMagazzino As System.Windows.Forms.Label
    Friend WithEvents txtUnitaMagazzino As System.Windows.Forms.TextBox
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
