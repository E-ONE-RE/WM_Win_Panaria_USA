<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuUscitaMerciMain
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
        Me.btnListaMissioniDiPicking = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.btnMissioneDiPicking = New System.Windows.Forms.Button()
        Me.btnPrintPalletCard = New System.Windows.Forms.Button()
        Me.btnTrasfRietichettaUnitaMagazzino = New System.Windows.Forms.Button()
        Me.btnUscitaMerciOdP = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnListaMissioniDiPicking
        '
        Me.btnListaMissioniDiPicking.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnListaMissioniDiPicking.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnListaMissioniDiPicking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnListaMissioniDiPicking.Location = New System.Drawing.Point(2, 0)
        Me.btnListaMissioniDiPicking.Name = "btnListaMissioniDiPicking"
        Me.btnListaMissioniDiPicking.Size = New System.Drawing.Size(233, 34)
        Me.btnListaMissioniDiPicking.TabIndex = 0
        Me.btnListaMissioniDiPicking.Tag = "PK01001"
        Me.btnListaMissioniDiPicking.Text = "1 - Lista Picking Approntamento"
        Me.btnListaMissioniDiPicking.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(175, 246)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(60, 36)
        Me.btnHome.TabIndex = 6
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(3, 247)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(171, 35)
        Me.btnVisualizzaInfo.TabIndex = 5
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "9 - Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnMissioneDiPicking
        '
        Me.btnMissioneDiPicking.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnMissioneDiPicking.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMissioneDiPicking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMissioneDiPicking.Location = New System.Drawing.Point(2, 34)
        Me.btnMissioneDiPicking.Name = "btnMissioneDiPicking"
        Me.btnMissioneDiPicking.Size = New System.Drawing.Size(233, 34)
        Me.btnMissioneDiPicking.TabIndex = 1
        Me.btnMissioneDiPicking.Tag = "PK01002"
        Me.btnMissioneDiPicking.Text = "2 - Picking - Esegui Missione"
        Me.btnMissioneDiPicking.UseVisualStyleBackColor = False
        '
        'btnPrintPalletCard
        '
        Me.btnPrintPalletCard.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnPrintPalletCard.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintPalletCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintPalletCard.Location = New System.Drawing.Point(2, 68)
        Me.btnPrintPalletCard.Name = "btnPrintPalletCard"
        Me.btnPrintPalletCard.Size = New System.Drawing.Size(233, 34)
        Me.btnPrintPalletCard.TabIndex = 2
        Me.btnPrintPalletCard.Tag = "PK01003"
        Me.btnPrintPalletCard.Text = "3 - Stampa Pallet Card"
        Me.btnPrintPalletCard.UseVisualStyleBackColor = False
        Me.btnPrintPalletCard.Visible = False
        '
        'btnTrasfRietichettaUnitaMagazzino
        '
        Me.btnTrasfRietichettaUnitaMagazzino.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnTrasfRietichettaUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasfRietichettaUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfRietichettaUnitaMagazzino.Location = New System.Drawing.Point(2, 102)
        Me.btnTrasfRietichettaUnitaMagazzino.Name = "btnTrasfRietichettaUnitaMagazzino"
        Me.btnTrasfRietichettaUnitaMagazzino.Size = New System.Drawing.Size(233, 36)
        Me.btnTrasfRietichettaUnitaMagazzino.TabIndex = 25
        Me.btnTrasfRietichettaUnitaMagazzino.Tag = "PK01004"
        Me.btnTrasfRietichettaUnitaMagazzino.Text = "4 - Ri-etichettatura Unita Magazzino"
        Me.btnTrasfRietichettaUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'btnUscitaMerciOdP
        '
        Me.btnUscitaMerciOdP.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnUscitaMerciOdP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUscitaMerciOdP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUscitaMerciOdP.Location = New System.Drawing.Point(1, 206)
        Me.btnUscitaMerciOdP.Name = "btnUscitaMerciOdP"
        Me.btnUscitaMerciOdP.Size = New System.Drawing.Size(236, 34)
        Me.btnUscitaMerciOdP.TabIndex = 26
        Me.btnUscitaMerciOdP.Tag = "PK01007"
        Me.btnUscitaMerciOdP.Text = "7 - Prelievo Merci x OdP"
        Me.btnUscitaMerciOdP.UseVisualStyleBackColor = False
        '
        'frmMenuUscitaMerciMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnUscitaMerciOdP)
        Me.Controls.Add(Me.btnTrasfRietichettaUnitaMagazzino)
        Me.Controls.Add(Me.btnPrintPalletCard)
        Me.Controls.Add(Me.btnMissioneDiPicking)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnListaMissioniDiPicking)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuUscitaMerciMain"
        Me.Text = "Uscita/Picking Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnListaMissioniDiPicking As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnMissioneDiPicking As System.Windows.Forms.Button
    Friend WithEvents btnPrintPalletCard As System.Windows.Forms.Button
    Friend WithEvents btnTrasfRietichettaUnitaMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnUscitaMerciOdP As System.Windows.Forms.Button
End Class
