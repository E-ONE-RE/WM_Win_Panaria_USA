<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuInformazioni_2
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
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnInfoTipiMagazzino = New System.Windows.Forms.Button()
        Me.btnInfoMappaUbicazioni = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.btnInfoForkLift = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(168, 229)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(65, 44)
        Me.btnHome.TabIndex = 4
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnInfoTipiMagazzino
        '
        Me.btnInfoTipiMagazzino.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoTipiMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoTipiMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoTipiMagazzino.Location = New System.Drawing.Point(2, 5)
        Me.btnInfoTipiMagazzino.Name = "btnInfoTipiMagazzino"
        Me.btnInfoTipiMagazzino.Size = New System.Drawing.Size(235, 33)
        Me.btnInfoTipiMagazzino.TabIndex = 1
        Me.btnInfoTipiMagazzino.Tag = "VI02001"
        Me.btnInfoTipiMagazzino.Text = "1 - Info Tipi Magazzino"
        Me.btnInfoTipiMagazzino.UseVisualStyleBackColor = False
        '
        'btnInfoMappaUbicazioni
        '
        Me.btnInfoMappaUbicazioni.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoMappaUbicazioni.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoMappaUbicazioni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoMappaUbicazioni.Location = New System.Drawing.Point(2, 40)
        Me.btnInfoMappaUbicazioni.Name = "btnInfoMappaUbicazioni"
        Me.btnInfoMappaUbicazioni.Size = New System.Drawing.Size(235, 33)
        Me.btnInfoMappaUbicazioni.TabIndex = 2
        Me.btnInfoMappaUbicazioni.Tag = "VI02002"
        Me.btnInfoMappaUbicazioni.Text = "2 - Info Mappa Ubicazioni"
        Me.btnInfoMappaUbicazioni.UseVisualStyleBackColor = False
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(3, 229)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(65, 44)
        Me.cmdPreviousScreen.TabIndex = 5
        Me.cmdPreviousScreen.Text = "<"
        '
        'btnInfoForkLift
        '
        Me.btnInfoForkLift.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoForkLift.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoForkLift.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoForkLift.Location = New System.Drawing.Point(2, 75)
        Me.btnInfoForkLift.Name = "btnInfoForkLift"
        Me.btnInfoForkLift.Size = New System.Drawing.Size(235, 33)
        Me.btnInfoForkLift.TabIndex = 3
        Me.btnInfoForkLift.Tag = "VI02003"
        Me.btnInfoForkLift.Text = "3 - Info Anagrafica Carrelli"
        Me.btnInfoForkLift.UseVisualStyleBackColor = False
        '
        'frmMenuInformazioni_2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnInfoForkLift)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.btnInfoMappaUbicazioni)
        Me.Controls.Add(Me.btnInfoTipiMagazzino)
        Me.Controls.Add(Me.btnHome)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuInformazioni_2"
        Me.Text = "Menu Informazioni"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnInfoTipiMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnInfoMappaUbicazioni As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents btnInfoForkLift As System.Windows.Forms.Button
End Class
