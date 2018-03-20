<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmBloccoMovMM_Part_2
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
        Me.lblInfoScelta = New System.Windows.Forms.Label()
        Me.PanelSceltaDestinazione = New System.Windows.Forms.Panel()
        Me.RadioBtnUbicazioneMateriale = New System.Windows.Forms.RadioButton()
        Me.RadioBtnMateriale = New System.Windows.Forms.RadioButton()
        Me.RadioBtnUbicazione = New System.Windows.Forms.RadioButton()
        Me.RadioBtnUnitaMagazzino = New System.Windows.Forms.RadioButton()
        Me.PanelSceltaDestinazione.SuspendLayout()
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
        'lblInfoScelta
        '
        Me.lblInfoScelta.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoScelta.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoScelta.ForeColor = System.Drawing.Color.Black
        Me.lblInfoScelta.Location = New System.Drawing.Point(1, 6)
        Me.lblInfoScelta.Name = "lblInfoScelta"
        Me.lblInfoScelta.Size = New System.Drawing.Size(226, 29)
        Me.lblInfoScelta.TabIndex = 4
        Me.lblInfoScelta.Text = "Modalità di Ricerca:"
        '
        'PanelSceltaDestinazione
        '
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnUbicazioneMateriale)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnMateriale)
        Me.PanelSceltaDestinazione.Controls.Add(Me.lblInfoScelta)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnUbicazione)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnUnitaMagazzino)
        Me.PanelSceltaDestinazione.Location = New System.Drawing.Point(1, 1)
        Me.PanelSceltaDestinazione.Name = "PanelSceltaDestinazione"
        Me.PanelSceltaDestinazione.Size = New System.Drawing.Size(235, 210)
        Me.PanelSceltaDestinazione.TabIndex = 0
        '
        'RadioBtnUbicazioneMateriale
        '
        Me.RadioBtnUbicazioneMateriale.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnUbicazioneMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnUbicazioneMateriale.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnUbicazioneMateriale.Location = New System.Drawing.Point(1, 175)
        Me.RadioBtnUbicazioneMateriale.Name = "RadioBtnUbicazioneMateriale"
        Me.RadioBtnUbicazioneMateriale.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnUbicazioneMateriale.TabIndex = 3
        Me.RadioBtnUbicazioneMateriale.Text = "Ubi. + Mat. && Partita"
        Me.RadioBtnUbicazioneMateriale.UseVisualStyleBackColor = False
        '
        'RadioBtnMateriale
        '
        Me.RadioBtnMateriale.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnMateriale.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnMateriale.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnMateriale.Location = New System.Drawing.Point(1, 131)
        Me.RadioBtnMateriale.Name = "RadioBtnMateriale"
        Me.RadioBtnMateriale.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnMateriale.TabIndex = 2
        Me.RadioBtnMateriale.Text = "Materiale && Partita"
        Me.RadioBtnMateriale.UseVisualStyleBackColor = False
        '
        'RadioBtnUbicazione
        '
        Me.RadioBtnUbicazione.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnUbicazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnUbicazione.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnUbicazione.Location = New System.Drawing.Point(1, 87)
        Me.RadioBtnUbicazione.Name = "RadioBtnUbicazione"
        Me.RadioBtnUbicazione.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnUbicazione.TabIndex = 1
        Me.RadioBtnUbicazione.Text = "Ubicazione"
        Me.RadioBtnUbicazione.UseVisualStyleBackColor = False
        '
        'RadioBtnUnitaMagazzino
        '
        Me.RadioBtnUnitaMagazzino.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnUnitaMagazzino.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnUnitaMagazzino.Location = New System.Drawing.Point(1, 43)
        Me.RadioBtnUnitaMagazzino.Name = "RadioBtnUnitaMagazzino"
        Me.RadioBtnUnitaMagazzino.Size = New System.Drawing.Size(229, 23)
        Me.RadioBtnUnitaMagazzino.TabIndex = 0
        Me.RadioBtnUnitaMagazzino.Text = "Unità Magaz. - Pallet"
        Me.RadioBtnUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'frmBloccoMovMM_Part_2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.PanelSceltaDestinazione)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBloccoMovMM_Part_2"
        Me.Text = "Metti/Togli Stock.Spec.(2)"
        Me.PanelSceltaDestinazione.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblInfoScelta As System.Windows.Forms.Label
    Friend WithEvents PanelSceltaDestinazione As System.Windows.Forms.Panel
    Friend WithEvents RadioBtnUbicazione As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnUnitaMagazzino As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnMateriale As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnUbicazioneMateriale As System.Windows.Forms.RadioButton
End Class
