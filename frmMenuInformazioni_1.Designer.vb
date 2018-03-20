<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuInformazioni_1
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
        Me.btnInfoGiacenze = New System.Windows.Forms.Button()
        Me.btnInfoUbicazione = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnInfoUnitaMagazzino = New System.Windows.Forms.Button()
        Me.btnInfoCodiceMateriale = New System.Windows.Forms.Button()
        Me.btnInfoGiacenzaCodMateriale = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.btnInfoDisponibilitaMateriale = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInfoGiacenze
        '
        Me.btnInfoGiacenze.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoGiacenze.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoGiacenze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoGiacenze.Location = New System.Drawing.Point(2, 74)
        Me.btnInfoGiacenze.Name = "btnInfoGiacenze"
        Me.btnInfoGiacenze.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoGiacenze.TabIndex = 2
        Me.btnInfoGiacenze.Tag = "VI01003"
        Me.btnInfoGiacenze.Text = "3 - Info Giacenze WM - Generico"
        Me.btnInfoGiacenze.UseVisualStyleBackColor = False
        '
        'btnInfoUbicazione
        '
        Me.btnInfoUbicazione.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoUbicazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoUbicazione.Location = New System.Drawing.Point(2, 0)
        Me.btnInfoUbicazione.Name = "btnInfoUbicazione"
        Me.btnInfoUbicazione.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoUbicazione.TabIndex = 0
        Me.btnInfoUbicazione.Tag = "VI01001"
        Me.btnInfoUbicazione.Text = "1 - Info Giacenze WM x Ubicazione"
        Me.btnInfoUbicazione.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(173, 234)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(62, 48)
        Me.btnHome.TabIndex = 12
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnInfoUnitaMagazzino
        '
        Me.btnInfoUnitaMagazzino.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoUnitaMagazzino.Location = New System.Drawing.Point(2, 111)
        Me.btnInfoUnitaMagazzino.Name = "btnInfoUnitaMagazzino"
        Me.btnInfoUnitaMagazzino.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoUnitaMagazzino.TabIndex = 3
        Me.btnInfoUnitaMagazzino.Tag = "VI01004"
        Me.btnInfoUnitaMagazzino.Text = "4 - Info WM x Unita Magazzino"
        Me.btnInfoUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'btnInfoCodiceMateriale
        '
        Me.btnInfoCodiceMateriale.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoCodiceMateriale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoCodiceMateriale.Location = New System.Drawing.Point(2, 148)
        Me.btnInfoCodiceMateriale.Name = "btnInfoCodiceMateriale"
        Me.btnInfoCodiceMateriale.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoCodiceMateriale.TabIndex = 4
        Me.btnInfoCodiceMateriale.Tag = "VI01005"
        Me.btnInfoCodiceMateriale.Text = "5 - Info Anagrafica Materiali"
        Me.btnInfoCodiceMateriale.UseVisualStyleBackColor = False
        '
        'btnInfoGiacenzaCodMateriale
        '
        Me.btnInfoGiacenzaCodMateriale.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoGiacenzaCodMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoGiacenzaCodMateriale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoGiacenzaCodMateriale.Location = New System.Drawing.Point(2, 37)
        Me.btnInfoGiacenzaCodMateriale.Name = "btnInfoGiacenzaCodMateriale"
        Me.btnInfoGiacenzaCodMateriale.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoGiacenzaCodMateriale.TabIndex = 1
        Me.btnInfoGiacenzaCodMateriale.Tag = "VI01002"
        Me.btnInfoGiacenzaCodMateriale.Text = "2 - Info Giacenze WM x Materiale"
        Me.btnInfoGiacenzaCodMateriale.UseVisualStyleBackColor = False
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(3, 234)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdNextScreen.TabIndex = 10
        Me.cmdNextScreen.Text = ">"
        '
        'btnInfoDisponibilitaMateriale
        '
        Me.btnInfoDisponibilitaMateriale.BackColor = System.Drawing.Color.Khaki
        Me.btnInfoDisponibilitaMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoDisponibilitaMateriale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInfoDisponibilitaMateriale.Location = New System.Drawing.Point(2, 185)
        Me.btnInfoDisponibilitaMateriale.Name = "btnInfoDisponibilitaMateriale"
        Me.btnInfoDisponibilitaMateriale.Size = New System.Drawing.Size(234, 33)
        Me.btnInfoDisponibilitaMateriale.TabIndex = 5
        Me.btnInfoDisponibilitaMateriale.Tag = "VI01006"
        Me.btnInfoDisponibilitaMateriale.Text = "6 - Info Disponibilita Materiali"
        Me.btnInfoDisponibilitaMateriale.UseVisualStyleBackColor = False
        '
        'frmMenuInformazioni_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnInfoDisponibilitaMateriale)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.btnInfoGiacenzaCodMateriale)
        Me.Controls.Add(Me.btnInfoUnitaMagazzino)
        Me.Controls.Add(Me.btnInfoCodiceMateriale)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnInfoUbicazione)
        Me.Controls.Add(Me.btnInfoGiacenze)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuInformazioni_1"
        Me.Text = "Menu Informazioni"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnInfoGiacenze As System.Windows.Forms.Button
    Friend WithEvents btnInfoUbicazione As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnInfoUnitaMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnInfoCodiceMateriale As System.Windows.Forms.Button
    Friend WithEvents btnInfoGiacenzaCodMateriale As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents btnInfoDisponibilitaMateriale As System.Windows.Forms.Button
End Class
