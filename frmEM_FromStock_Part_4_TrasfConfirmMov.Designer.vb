<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_4_TrasfConfirmMov
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
        Me.txtInfoUMSelezionata = New System.Windows.Forms.TextBox()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 240)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 41)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(103, 240)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(64, 41)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(171, 240)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(64, 41)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'txtInfoUMSelezionata
        '
        Me.txtInfoUMSelezionata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUMSelezionata.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUMSelezionata.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUMSelezionata.Location = New System.Drawing.Point(1, 41)
        Me.txtInfoUMSelezionata.Multiline = True
        Me.txtInfoUMSelezionata.Name = "txtInfoUMSelezionata"
        Me.txtInfoUMSelezionata.ReadOnly = True
        Me.txtInfoUMSelezionata.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUMSelezionata.Size = New System.Drawing.Size(237, 194)
        Me.txtInfoUMSelezionata.TabIndex = 163
        Me.txtInfoUMSelezionata.TabStop = False
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(2, 2)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(236, 36)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'frmEM_FromStock_Part_4_TrasfConfirmMov
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.txtInfoUMSelezionata)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_4_TrasfConfirmMov"
        Me.Text = "EM - Prod. da Trasf. (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents txtInfoUMSelezionata As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
End Class
