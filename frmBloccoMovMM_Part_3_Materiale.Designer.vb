<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmBloccoMovMM_Part_3_Materiale
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.txtOperazione = New System.Windows.Forms.TextBox()
        Me.lblOperazione = New System.Windows.Forms.Label()
        Me.cmdSelectMateriale = New System.Windows.Forms.Button()
        Me.lblMateriale = New System.Windows.Forms.Label()
        Me.txtMateriale = New System.Windows.Forms.TextBox()
        Me.cmdSelectPartitaMateriale = New System.Windows.Forms.Button()
        Me.lblPartita = New System.Windows.Forms.Label()
        Me.txtPartita = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 217)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 9
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 217)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(92, 217)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdPreviousScreen.TabIndex = 44
        Me.cmdPreviousScreen.Text = "<"
        '
        'txtOperazione
        '
        Me.txtOperazione.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOperazione.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtOperazione.ForeColor = System.Drawing.Color.Black
        Me.txtOperazione.Location = New System.Drawing.Point(-5, 17)
        Me.txtOperazione.Name = "txtOperazione"
        Me.txtOperazione.Size = New System.Drawing.Size(239, 20)
        Me.txtOperazione.TabIndex = 104
        Me.txtOperazione.TabStop = False
        '
        'lblOperazione
        '
        Me.lblOperazione.BackColor = System.Drawing.Color.Transparent
        Me.lblOperazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOperazione.ForeColor = System.Drawing.Color.Black
        Me.lblOperazione.Location = New System.Drawing.Point(1, 1)
        Me.lblOperazione.Name = "lblOperazione"
        Me.lblOperazione.Size = New System.Drawing.Size(104, 17)
        Me.lblOperazione.TabIndex = 116
        Me.lblOperazione.Text = "Operazione"
        '
        'cmdSelectMateriale
        '
        Me.cmdSelectMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectMateriale.Location = New System.Drawing.Point(189, 49)
        Me.cmdSelectMateriale.Name = "cmdSelectMateriale"
        Me.cmdSelectMateriale.Size = New System.Drawing.Size(48, 76)
        Me.cmdSelectMateriale.TabIndex = 108
        Me.cmdSelectMateriale.Text = "..."
        '
        'lblMateriale
        '
        Me.lblMateriale.BackColor = System.Drawing.Color.Yellow
        Me.lblMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblMateriale.Location = New System.Drawing.Point(2, 51)
        Me.lblMateriale.Name = "lblMateriale"
        Me.lblMateriale.Size = New System.Drawing.Size(186, 46)
        Me.lblMateriale.TabIndex = 115
        Me.lblMateriale.Text = "Materiale"
        '
        'txtMateriale
        '
        Me.txtMateriale.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtMateriale.ForeColor = System.Drawing.Color.Black
        Me.txtMateriale.Location = New System.Drawing.Point(2, 98)
        Me.txtMateriale.MaxLength = 18
        Me.txtMateriale.Name = "txtMateriale"
        Me.txtMateriale.Size = New System.Drawing.Size(186, 25)
        Me.txtMateriale.TabIndex = 107
        '
        'cmdSelectPartitaMateriale
        '
        Me.cmdSelectPartitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectPartitaMateriale.Location = New System.Drawing.Point(189, 141)
        Me.cmdSelectPartitaMateriale.Name = "cmdSelectPartitaMateriale"
        Me.cmdSelectPartitaMateriale.Size = New System.Drawing.Size(48, 61)
        Me.cmdSelectPartitaMateriale.TabIndex = 113
        Me.cmdSelectPartitaMateriale.Text = "..."
        '
        'lblPartita
        '
        Me.lblPartita.BackColor = System.Drawing.Color.Yellow
        Me.lblPartita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPartita.ForeColor = System.Drawing.Color.Black
        Me.lblPartita.Location = New System.Drawing.Point(2, 141)
        Me.lblPartita.Name = "lblPartita"
        Me.lblPartita.Size = New System.Drawing.Size(186, 33)
        Me.lblPartita.TabIndex = 114
        Me.lblPartita.Text = "Partita"
        '
        'txtPartita
        '
        Me.txtPartita.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPartita.ForeColor = System.Drawing.Color.Black
        Me.txtPartita.Location = New System.Drawing.Point(2, 175)
        Me.txtPartita.MaxLength = 10
        Me.txtPartita.Name = "txtPartita"
        Me.txtPartita.Size = New System.Drawing.Size(186, 25)
        Me.txtPartita.TabIndex = 112
        '
        'frmBloccoMovMM_Part_3_Materiale
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdSelectPartitaMateriale)
        Me.Controls.Add(Me.lblPartita)
        Me.Controls.Add(Me.txtPartita)
        Me.Controls.Add(Me.cmdSelectMateriale)
        Me.Controls.Add(Me.lblMateriale)
        Me.Controls.Add(Me.txtMateriale)
        Me.Controls.Add(Me.txtOperazione)
        Me.Controls.Add(Me.lblOperazione)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBloccoMovMM_Part_3_Materiale"
        Me.Text = "Metti/Togli Stock.Spec.(3)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents txtOperazione As System.Windows.Forms.TextBox
    Friend WithEvents lblOperazione As System.Windows.Forms.Label
    Friend WithEvents cmdSelectMateriale As System.Windows.Forms.Button
    Friend WithEvents lblMateriale As System.Windows.Forms.Label
    Friend WithEvents txtMateriale As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectPartitaMateriale As System.Windows.Forms.Button
    Friend WithEvents lblPartita As System.Windows.Forms.Label
    Friend WithEvents txtPartita As System.Windows.Forms.TextBox
End Class
