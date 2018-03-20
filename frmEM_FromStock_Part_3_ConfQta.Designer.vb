<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_3_ConfQta
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
        Me.txtUM_Origine = New System.Windows.Forms.TextBox()
        Me.lblUM_Origine = New System.Windows.Forms.Label()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblQtaDisponibile = New System.Windows.Forms.Label()
        Me.txtQtaDisponibile = New System.Windows.Forms.TextBox()
        Me.lblQtaConfermata = New System.Windows.Forms.Label()
        Me.txtQtaConfermata = New System.Windows.Forms.TextBox()
        Me.lblUDMQuantità = New System.Windows.Forms.Label()
        Me.txtUDMQuantita = New System.Windows.Forms.TextBox()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtUM_Origine
        '
        Me.txtUM_Origine.ForeColor = System.Drawing.Color.Black
        Me.txtUM_Origine.Location = New System.Drawing.Point(43, 171)
        Me.txtUM_Origine.MaxLength = 10
        Me.txtUM_Origine.Name = "txtUM_Origine"
        Me.txtUM_Origine.Size = New System.Drawing.Size(194, 20)
        Me.txtUM_Origine.TabIndex = 66
        '
        'lblUM_Origine
        '
        Me.lblUM_Origine.BackColor = System.Drawing.Color.Yellow
        Me.lblUM_Origine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM_Origine.ForeColor = System.Drawing.Color.Black
        Me.lblUM_Origine.Location = New System.Drawing.Point(2, 172)
        Me.lblUM_Origine.Name = "lblUM_Origine"
        Me.lblUM_Origine.Size = New System.Drawing.Size(40, 24)
        Me.lblUM_Origine.TabIndex = 160
        Me.lblUM_Origine.Text = "UM"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(2, 245)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(76, 45)
        Me.cmdAbortScreen.TabIndex = 65
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(103, 245)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(64, 45)
        Me.cmdPreviousScreen.TabIndex = 64
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(172, 245)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(64, 45)
        Me.cmdNextScreen.TabIndex = 62
        Me.cmdNextScreen.Text = ">"
        '
        'lblQtaDisponibile
        '
        Me.lblQtaDisponibile.BackColor = System.Drawing.Color.Transparent
        Me.lblQtaDisponibile.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaDisponibile.ForeColor = System.Drawing.Color.Black
        Me.lblQtaDisponibile.Location = New System.Drawing.Point(-1, 200)
        Me.lblQtaDisponibile.Name = "lblQtaDisponibile"
        Me.lblQtaDisponibile.Size = New System.Drawing.Size(77, 15)
        Me.lblQtaDisponibile.TabIndex = 161
        Me.lblQtaDisponibile.Text = "Qta Disp."
        '
        'txtQtaDisponibile
        '
        Me.txtQtaDisponibile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtQtaDisponibile.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaDisponibile.ForeColor = System.Drawing.Color.Black
        Me.txtQtaDisponibile.Location = New System.Drawing.Point(-1, 218)
        Me.txtQtaDisponibile.Name = "txtQtaDisponibile"
        Me.txtQtaDisponibile.ReadOnly = True
        Me.txtQtaDisponibile.Size = New System.Drawing.Size(77, 24)
        Me.txtQtaDisponibile.TabIndex = 59
        '
        'lblQtaConfermata
        '
        Me.lblQtaConfermata.BackColor = System.Drawing.Color.Yellow
        Me.lblQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.lblQtaConfermata.Location = New System.Drawing.Point(124, 199)
        Me.lblQtaConfermata.Name = "lblQtaConfermata"
        Me.lblQtaConfermata.Size = New System.Drawing.Size(112, 17)
        Me.lblQtaConfermata.TabIndex = 162
        Me.lblQtaConfermata.Text = "Qtà Conf."
        '
        'txtQtaConfermata
        '
        Me.txtQtaConfermata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtQtaConfermata.ForeColor = System.Drawing.Color.Black
        Me.txtQtaConfermata.Location = New System.Drawing.Point(123, 218)
        Me.txtQtaConfermata.Name = "txtQtaConfermata"
        Me.txtQtaConfermata.Size = New System.Drawing.Size(113, 24)
        Me.txtQtaConfermata.TabIndex = 57
        '
        'lblUDMQuantità
        '
        Me.lblUDMQuantità.BackColor = System.Drawing.Color.Transparent
        Me.lblUDMQuantità.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUDMQuantità.ForeColor = System.Drawing.Color.Black
        Me.lblUDMQuantità.Location = New System.Drawing.Point(77, 202)
        Me.lblUDMQuantità.Name = "lblUDMQuantità"
        Me.lblUDMQuantità.Size = New System.Drawing.Size(46, 13)
        Me.lblUDMQuantità.TabIndex = 159
        Me.lblUDMQuantità.Text = "UdM"
        '
        'txtUDMQuantita
        '
        Me.txtUDMQuantita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUDMQuantita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUDMQuantita.ForeColor = System.Drawing.Color.Black
        Me.txtUDMQuantita.Location = New System.Drawing.Point(75, 218)
        Me.txtUDMQuantita.Name = "txtUDMQuantita"
        Me.txtUDMQuantita.ReadOnly = True
        Me.txtUDMQuantita.Size = New System.Drawing.Size(49, 24)
        Me.txtUDMQuantita.TabIndex = 114
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 169)
        Me.txtInfoJobSelezionato.TabIndex = 158
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'frmEM_FromStock_Part_3_ConfQta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 293)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.lblUDMQuantità)
        Me.Controls.Add(Me.txtUDMQuantita)
        Me.Controls.Add(Me.txtUM_Origine)
        Me.Controls.Add(Me.lblUM_Origine)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.lblQtaDisponibile)
        Me.Controls.Add(Me.txtQtaDisponibile)
        Me.Controls.Add(Me.lblQtaConfermata)
        Me.Controls.Add(Me.txtQtaConfermata)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_3_ConfQta"
        Me.Text = "EM - Lista (3)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUM_Origine As System.Windows.Forms.TextBox
    Friend WithEvents lblUM_Origine As System.Windows.Forms.Label
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblQtaDisponibile As System.Windows.Forms.Label
    Friend WithEvents txtQtaDisponibile As System.Windows.Forms.TextBox
    Friend WithEvents lblQtaConfermata As System.Windows.Forms.Label
    Friend WithEvents txtQtaConfermata As System.Windows.Forms.TextBox
    Friend WithEvents lblUDMQuantità As System.Windows.Forms.Label
    Friend WithEvents txtUDMQuantita As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
End Class
