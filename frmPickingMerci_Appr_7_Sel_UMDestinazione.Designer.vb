<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_7_Sel_UMDestinazione
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
        Me.txtCodiceUM = New System.Windows.Forms.TextBox()
        Me.lblCodiceUM = New System.Windows.Forms.Label()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 232)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 50)
        Me.cmdNextScreen.TabIndex = 11
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 232)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 50)
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'txtCodiceUM
        '
        Me.txtCodiceUM.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceUM.Location = New System.Drawing.Point(1, 200)
        Me.txtCodiceUM.MaxLength = 10
        Me.txtCodiceUM.Name = "txtCodiceUM"
        Me.txtCodiceUM.Size = New System.Drawing.Size(236, 25)
        Me.txtCodiceUM.TabIndex = 0
        '
        'lblCodiceUM
        '
        Me.lblCodiceUM.BackColor = System.Drawing.Color.Yellow
        Me.lblCodiceUM.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceUM.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceUM.Location = New System.Drawing.Point(1, 181)
        Me.lblCodiceUM.Name = "lblCodiceUM"
        Me.lblCodiceUM.Size = New System.Drawing.Size(235, 18)
        Me.lblCodiceUM.TabIndex = 1
        Me.lblCodiceUM.Text = "UM Destinazione"
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
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(237, 180)
        Me.txtInfoJobSelezionato.TabIndex = 0
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'frmPickingMerci_Appr_7_Sel_UMDestinazione
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.txtCodiceUM)
        Me.Controls.Add(Me.lblCodiceUM)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_7_Sel_UMDestinazione"
        Me.Text = "Picking Appr. (7)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtCodiceUM As System.Windows.Forms.TextBox
    Friend WithEvents lblCodiceUM As System.Windows.Forms.Label
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
End Class
