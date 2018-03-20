<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.lblUbicazDestConfermata = New System.Windows.Forms.Label()
        Me.txtUbicazDestConfermata = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 206)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(188, 76)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(49, 73)
        Me.cmdSelectUbicazioneDest.TabIndex = 89
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'lblUbicazDestConfermata
        '
        Me.lblUbicazDestConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazDestConfermata.Location = New System.Drawing.Point(1, 76)
        Me.lblUbicazDestConfermata.Name = "lblUbicazDestConfermata"
        Me.lblUbicazDestConfermata.Size = New System.Drawing.Size(186, 43)
        Me.lblUbicazDestConfermata.TabIndex = 93
        Me.lblUbicazDestConfermata.Text = "Locazione Di Identificazione"
        '
        'txtUbicazDestConfermata
        '
        Me.txtUbicazDestConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazDestConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazDestConfermata.Location = New System.Drawing.Point(1, 120)
        Me.txtUbicazDestConfermata.MaxLength = 10
        Me.txtUbicazDestConfermata.Name = "txtUbicazDestConfermata"
        Me.txtUbicazDestConfermata.Size = New System.Drawing.Size(187, 24)
        Me.txtUbicazDestConfermata.TabIndex = 88
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(4, 206)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(76, 60)
        Me.cmdAbortScreen.TabIndex = 92
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.lblUbicazDestConfermata)
        Me.Controls.Add(Me.txtUbicazDestConfermata)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_1_Trasf_SelUbiSpunta"
        Me.Text = "EM - Bem (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents lblUbicazDestConfermata As System.Windows.Forms.Label
    Friend WithEvents txtUbicazDestConfermata As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
End Class
