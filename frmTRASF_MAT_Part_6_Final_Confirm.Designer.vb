<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTRASF_MAT_Part_6_Final_Confirm
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
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.txtUM_Destinazione = New System.Windows.Forms.TextBox()
        Me.lblUM_Destinazione = New System.Windows.Forms.Label()
        Me.cmdShowStock = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(1, 191)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(186, 18)
        Me.lblUbicazDestConfermata.TabIndex = 187
        Me.lblUbicazDestConfermata.Text = "Ubicazione Destinazione"
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(1, 210)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(186, 22)
        Me.txtUbicazDestConfermata.TabIndex = 47
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 241)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(56, 41)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(120, 241)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(55, 41)
        Me.cmdPreviousScreen.TabIndex = 60
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 241)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 41)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(187, 191)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(50, 45)
        Me.cmdSelectUbicazioneDest.TabIndex = 78
        Me.cmdSelectUbicazioneDest.Text = "..."
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 133)
        Me.txtInfoJobSelezionato.TabIndex = 178
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'txtUM_Destinazione
        '
        Me.txtUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Destinazione.Location = New System.Drawing.Point(1, 157)
        Me.txtUM_Destinazione.MaxLength = 10
        Me.txtUM_Destinazione.Name = "txtUM_Destinazione"
        Me.txtUM_Destinazione.Size = New System.Drawing.Size(188, 30)
        Me.txtUM_Destinazione.TabIndex = 180
        '
        'lblUM_Destinazione
        '
        Me.lblUM_Destinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Destinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Destinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Destinazione.Location = New System.Drawing.Point(1, 136)
        Me.lblUM_Destinazione.Name = "lblUM_Destinazione"
        Me.lblUM_Destinazione.Size = New System.Drawing.Size(187, 21)
        Me.lblUM_Destinazione.TabIndex = 186
        Me.lblUM_Destinazione.Text = "Unità Mag.Destinazione"
        '
        'cmdShowStock
        '
        Me.cmdShowStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdShowStock.Location = New System.Drawing.Point(187, 134)
        Me.cmdShowStock.Name = "cmdShowStock"
        Me.cmdShowStock.Size = New System.Drawing.Size(50, 51)
        Me.cmdShowStock.TabIndex = 185
        Me.cmdShowStock.Text = "STOCK"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(61, 242)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 40)
        Me.Button1.TabIndex = 188
        Me.Button1.Text = "Print"
        '
        'frmTRASF_MAT_Part_6_Final_Confirm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdShowStock)
        Me.Controls.Add(Me.txtUM_Destinazione)
        Me.Controls.Add(Me.lblUM_Destinazione)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTRASF_MAT_Part_6_Final_Confirm"
        Me.Text = "TRASF - Mat. (5)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents txtUM_Destinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUM_Destinazione As System.Windows.Forms.Label
    Friend WithEvents cmdShowStock As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
