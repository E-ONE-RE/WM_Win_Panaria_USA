<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrintLabelUdc
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUM = New System.Windows.Forms.Label()
        Me.txtPrinter01 = New System.Windows.Forms.TextBox()
        Me.lblPrinters = New System.Windows.Forms.Label()
        Me.txtPrinter02 = New System.Windows.Forms.TextBox()
        Me.RBtnPrinter02 = New System.Windows.Forms.RadioButton()
        Me.RBtnPrinter01 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(166, 200)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 200)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 67)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(0, 67)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(236, 30)
        Me.txtUM.TabIndex = 80
        '
        'lblUM
        '
        Me.lblUM.BackColor = System.Drawing.Color.Yellow
        Me.lblUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUM.ForeColor = System.Drawing.Color.Black
        Me.lblUM.Location = New System.Drawing.Point(1, 43)
        Me.lblUM.Name = "lblUM"
        Me.lblUM.Size = New System.Drawing.Size(235, 24)
        Me.lblUM.TabIndex = 81
        Me.lblUM.Text = "Unità Magazzino"
        '
        'txtPrinter01
        '
        Me.txtPrinter01.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrinter01.ForeColor = System.Drawing.Color.Black
        Me.txtPrinter01.Location = New System.Drawing.Point(148, 138)
        Me.txtPrinter01.MaxLength = 10
        Me.txtPrinter01.Name = "txtPrinter01"
        Me.txtPrinter01.ReadOnly = True
        Me.txtPrinter01.Size = New System.Drawing.Size(56, 30)
        Me.txtPrinter01.TabIndex = 84
        '
        'lblPrinters
        '
        Me.lblPrinters.BackColor = System.Drawing.Color.Yellow
        Me.lblPrinters.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrinters.ForeColor = System.Drawing.Color.Black
        Me.lblPrinters.Location = New System.Drawing.Point(59, 110)
        Me.lblPrinters.Name = "lblPrinters"
        Me.lblPrinters.Size = New System.Drawing.Size(175, 21)
        Me.lblPrinters.TabIndex = 85
        Me.lblPrinters.Text = "Stampante"
        '
        'txtPrinter02
        '
        Me.txtPrinter02.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrinter02.ForeColor = System.Drawing.Color.Black
        Me.txtPrinter02.Location = New System.Drawing.Point(148, 169)
        Me.txtPrinter02.MaxLength = 10
        Me.txtPrinter02.Name = "txtPrinter02"
        Me.txtPrinter02.ReadOnly = True
        Me.txtPrinter02.Size = New System.Drawing.Size(56, 30)
        Me.txtPrinter02.TabIndex = 86
        '
        'RBtnPrinter02
        '
        Me.RBtnPrinter02.BackColor = System.Drawing.Color.Transparent
        Me.RBtnPrinter02.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RBtnPrinter02.ForeColor = System.Drawing.Color.Black
        Me.RBtnPrinter02.Location = New System.Drawing.Point(214, 163)
        Me.RBtnPrinter02.Name = "RBtnPrinter02"
        Me.RBtnPrinter02.Size = New System.Drawing.Size(30, 30)
        Me.RBtnPrinter02.TabIndex = 88
        Me.RBtnPrinter02.UseVisualStyleBackColor = False
        '
        'RBtnPrinter01
        '
        Me.RBtnPrinter01.BackColor = System.Drawing.Color.Transparent
        Me.RBtnPrinter01.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RBtnPrinter01.ForeColor = System.Drawing.Color.Black
        Me.RBtnPrinter01.Location = New System.Drawing.Point(214, 132)
        Me.RBtnPrinter01.Name = "RBtnPrinter01"
        Me.RBtnPrinter01.Size = New System.Drawing.Size(30, 30)
        Me.RBtnPrinter01.TabIndex = 87
        Me.RBtnPrinter01.UseVisualStyleBackColor = False
        '
        'frmPrintLabelUdc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.RBtnPrinter02)
        Me.Controls.Add(Me.RBtnPrinter01)
        Me.Controls.Add(Me.txtPrinter02)
        Me.Controls.Add(Me.txtPrinter01)
        Me.Controls.Add(Me.lblPrinters)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintLabelUdc"
        Me.Text = "Info Giacenze(1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUM As System.Windows.Forms.Label
    Friend WithEvents txtPrinter01 As System.Windows.Forms.TextBox
    Friend WithEvents lblPrinters As System.Windows.Forms.Label
    Friend WithEvents txtPrinter02 As System.Windows.Forms.TextBox
    Friend WithEvents RBtnPrinter02 As System.Windows.Forms.RadioButton
    Friend WithEvents RBtnPrinter01 As System.Windows.Forms.RadioButton
End Class
