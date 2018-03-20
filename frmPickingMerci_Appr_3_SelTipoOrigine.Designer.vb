<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_3_SelTipoOrigine
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
        Me.RadioBtnTypeUbieUMEnter = New System.Windows.Forms.RadioButton()
        Me.RadioBtnTypeCodMatEnter = New System.Windows.Forms.RadioButton()
        Me.lblInfoScelta = New System.Windows.Forms.Label()
        Me.RadioBtnTypeUbicazioneEnter = New System.Windows.Forms.RadioButton()
        Me.RadioBtnTypeUMEnter = New System.Windows.Forms.RadioButton()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.PanelSceltaDestinazione.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(169, 221)
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
        Me.cmdAbortScreen.TabIndex = 10
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'PanelSceltaDestinazione
        '
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTypeUbieUMEnter)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTypeCodMatEnter)
        Me.PanelSceltaDestinazione.Controls.Add(Me.lblInfoScelta)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTypeUbicazioneEnter)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTypeUMEnter)
        Me.PanelSceltaDestinazione.Location = New System.Drawing.Point(1, 1)
        Me.PanelSceltaDestinazione.Name = "PanelSceltaDestinazione"
        Me.PanelSceltaDestinazione.Size = New System.Drawing.Size(236, 210)
        Me.PanelSceltaDestinazione.TabIndex = 12
        '
        'RadioBtnTypeUbieUMEnter
        '
        Me.RadioBtnTypeUbieUMEnter.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTypeUbieUMEnter.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTypeUbieUMEnter.Location = New System.Drawing.Point(1, 126)
        Me.RadioBtnTypeUbieUMEnter.Name = "RadioBtnTypeUbieUMEnter"
        Me.RadioBtnTypeUbieUMEnter.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnTypeUbieUMEnter.TabIndex = 2
        Me.RadioBtnTypeUbieUMEnter.Text = "Prelievo x UM && Cod.Ubicaz."
        '
        'RadioBtnTypeCodMatEnter
        '
        Me.RadioBtnTypeCodMatEnter.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTypeCodMatEnter.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTypeCodMatEnter.Location = New System.Drawing.Point(1, 173)
        Me.RadioBtnTypeCodMatEnter.Name = "RadioBtnTypeCodMatEnter"
        Me.RadioBtnTypeCodMatEnter.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnTypeCodMatEnter.TabIndex = 3
        Me.RadioBtnTypeCodMatEnter.Text = "Prelievo x Cod.Mat."
        '
        'lblInfoScelta
        '
        Me.lblInfoScelta.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoScelta.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoScelta.ForeColor = System.Drawing.Color.Black
        Me.lblInfoScelta.Location = New System.Drawing.Point(1, 0)
        Me.lblInfoScelta.Name = "lblInfoScelta"
        Me.lblInfoScelta.Size = New System.Drawing.Size(234, 29)
        Me.lblInfoScelta.TabIndex = 4
        Me.lblInfoScelta.Text = "Scelta Tipologia Prelievo"
        '
        'RadioBtnTypeUbicazioneEnter
        '
        Me.RadioBtnTypeUbicazioneEnter.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTypeUbicazioneEnter.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTypeUbicazioneEnter.Location = New System.Drawing.Point(1, 79)
        Me.RadioBtnTypeUbicazioneEnter.Name = "RadioBtnTypeUbicazioneEnter"
        Me.RadioBtnTypeUbicazioneEnter.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnTypeUbicazioneEnter.TabIndex = 1
        Me.RadioBtnTypeUbicazioneEnter.Text = "Prelievo x Cod.Ubicaz."
        '
        'RadioBtnTypeUMEnter
        '
        Me.RadioBtnTypeUMEnter.Enabled = False
        Me.RadioBtnTypeUMEnter.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTypeUMEnter.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTypeUMEnter.Location = New System.Drawing.Point(1, 32)
        Me.RadioBtnTypeUMEnter.Name = "RadioBtnTypeUMEnter"
        Me.RadioBtnTypeUMEnter.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnTypeUMEnter.TabIndex = 0
        Me.RadioBtnTypeUMEnter.Text = "Prelievo x UM"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(95, 221)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(68, 60)
        Me.cmdPreviousScreen.TabIndex = 11
        Me.cmdPreviousScreen.Text = "<"
        '
        'frmPickingMerci_Appr_3_SelTipoOrigine
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.PanelSceltaDestinazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_3_SelTipoOrigine"
        Me.Text = "Picking Appr. (3)"
        Me.PanelSceltaDestinazione.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents PanelSceltaDestinazione As System.Windows.Forms.Panel
    Friend WithEvents RadioBtnTypeUMEnter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnTypeUbicazioneEnter As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfoScelta As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents RadioBtnTypeCodMatEnter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnTypeUbieUMEnter As System.Windows.Forms.RadioButton
End Class
