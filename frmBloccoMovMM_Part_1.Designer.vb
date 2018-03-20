<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmBloccoMovMM_Part_1
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
        Me.PanelSceltaDestinazione = New System.Windows.Forms.Panel()
        Me.lblInfoScelta = New System.Windows.Forms.Label()
        Me.RadioBtnSblocco = New System.Windows.Forms.RadioButton()
        Me.RadioBtnBlocco = New System.Windows.Forms.RadioButton()
        Me.PanelSceltaDestinazione.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(167, 221)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 221)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'PanelSceltaDestinazione
        '
        Me.PanelSceltaDestinazione.Controls.Add(Me.lblInfoScelta)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnSblocco)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnBlocco)
        Me.PanelSceltaDestinazione.Location = New System.Drawing.Point(1, 1)
        Me.PanelSceltaDestinazione.Name = "PanelSceltaDestinazione"
        Me.PanelSceltaDestinazione.Size = New System.Drawing.Size(235, 210)
        Me.PanelSceltaDestinazione.TabIndex = 0
        '
        'lblInfoScelta
        '
        Me.lblInfoScelta.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoScelta.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoScelta.ForeColor = System.Drawing.Color.Black
        Me.lblInfoScelta.Location = New System.Drawing.Point(1, 6)
        Me.lblInfoScelta.Name = "lblInfoScelta"
        Me.lblInfoScelta.Size = New System.Drawing.Size(229, 29)
        Me.lblInfoScelta.TabIndex = 0
        Me.lblInfoScelta.Text = "Scelta Operazione:"
        '
        'RadioBtnSblocco
        '
        Me.RadioBtnSblocco.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnSblocco.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnSblocco.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnSblocco.Location = New System.Drawing.Point(1, 82)
        Me.RadioBtnSblocco.Name = "RadioBtnSblocco"
        Me.RadioBtnSblocco.Size = New System.Drawing.Size(228, 23)
        Me.RadioBtnSblocco.TabIndex = 1
        Me.RadioBtnSblocco.Text = "Togli Stock Spec."
        Me.RadioBtnSblocco.UseVisualStyleBackColor = False
        '
        'RadioBtnBlocco
        '
        Me.RadioBtnBlocco.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnBlocco.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnBlocco.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnBlocco.Location = New System.Drawing.Point(1, 43)
        Me.RadioBtnBlocco.Name = "RadioBtnBlocco"
        Me.RadioBtnBlocco.Size = New System.Drawing.Size(228, 23)
        Me.RadioBtnBlocco.TabIndex = 0
        Me.RadioBtnBlocco.Text = "Metti Stock Spec."
        Me.RadioBtnBlocco.UseVisualStyleBackColor = False
        '
        'frmBloccoMovMM_Part_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.PanelSceltaDestinazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBloccoMovMM_Part_1"
        Me.Text = "Metti/Togli Stock.Spec.(1)"
        Me.PanelSceltaDestinazione.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents PanelSceltaDestinazione As System.Windows.Forms.Panel
    Friend WithEvents RadioBtnBlocco As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnSblocco As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfoScelta As System.Windows.Forms.Label
End Class
