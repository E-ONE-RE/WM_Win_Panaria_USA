<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuUscitaMerciMainWin
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
        Me.btnForkDropUDS = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.btnMissioneDiPicking = New System.Windows.Forms.Button()
        Me.btnPrintPalletCard = New System.Windows.Forms.Button()
        Me.btnTrasfRietichettaUnitaMagazzino = New System.Windows.Forms.Button()
        Me.btnUscitaMerciOdP = New System.Windows.Forms.Button()
        Me.btnExecTaskFromQueue = New System.Windows.Forms.Button()
        Me.btnMoveUDS = New System.Windows.Forms.Button()
        Me.btnChangeUDS = New System.Windows.Forms.Button()
        Me.btnExecTruckLoad = New System.Windows.Forms.Button()
        Me.btnUDSJobsMoveList = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnForkDropUDS
        '
        Me.btnForkDropUDS.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnForkDropUDS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnForkDropUDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnForkDropUDS.Location = New System.Drawing.Point(4, 321)
        Me.btnForkDropUDS.Name = "btnForkDropUDS"
        Me.btnForkDropUDS.Size = New System.Drawing.Size(478, 56)
        Me.btnForkDropUDS.TabIndex = 5
        Me.btnForkDropUDS.Tag = "PK01008"
        Me.btnForkDropUDS.Text = "8 - Drop UDS ForkLift"
        Me.btnForkDropUDS.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(740, 661)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(256, 56)
        Me.btnHome.TabIndex = 11
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(4, 661)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(730, 56)
        Me.btnVisualizzaInfo.TabIndex = 10
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "9 - Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnMissioneDiPicking
        '
        Me.btnMissioneDiPicking.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnMissioneDiPicking.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMissioneDiPicking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMissioneDiPicking.Location = New System.Drawing.Point(518, 321)
        Me.btnMissioneDiPicking.Name = "btnMissioneDiPicking"
        Me.btnMissioneDiPicking.Size = New System.Drawing.Size(478, 56)
        Me.btnMissioneDiPicking.TabIndex = 6
        Me.btnMissioneDiPicking.Tag = "PK01009"
        Me.btnMissioneDiPicking.Text = "9 - Picking - Esegui Gruppo Missione"
        Me.btnMissioneDiPicking.UseVisualStyleBackColor = False
        Me.btnMissioneDiPicking.Visible = False
        '
        'btnPrintPalletCard
        '
        Me.btnPrintPalletCard.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnPrintPalletCard.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintPalletCard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintPalletCard.Location = New System.Drawing.Point(4, 384)
        Me.btnPrintPalletCard.Name = "btnPrintPalletCard"
        Me.btnPrintPalletCard.Size = New System.Drawing.Size(478, 56)
        Me.btnPrintPalletCard.TabIndex = 7
        Me.btnPrintPalletCard.Tag = "PK01006"
        Me.btnPrintPalletCard.Text = "Stampa Pallet Card"
        Me.btnPrintPalletCard.UseVisualStyleBackColor = False
        Me.btnPrintPalletCard.Visible = False
        '
        'btnTrasfRietichettaUnitaMagazzino
        '
        Me.btnTrasfRietichettaUnitaMagazzino.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnTrasfRietichettaUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrasfRietichettaUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfRietichettaUnitaMagazzino.Location = New System.Drawing.Point(518, 383)
        Me.btnTrasfRietichettaUnitaMagazzino.Name = "btnTrasfRietichettaUnitaMagazzino"
        Me.btnTrasfRietichettaUnitaMagazzino.Size = New System.Drawing.Size(478, 56)
        Me.btnTrasfRietichettaUnitaMagazzino.TabIndex = 8
        Me.btnTrasfRietichettaUnitaMagazzino.Tag = "PK01007"
        Me.btnTrasfRietichettaUnitaMagazzino.Text = "Ri-etichettatura Unita Magazzino"
        Me.btnTrasfRietichettaUnitaMagazzino.UseVisualStyleBackColor = False
        Me.btnTrasfRietichettaUnitaMagazzino.Visible = False
        '
        'btnUscitaMerciOdP
        '
        Me.btnUscitaMerciOdP.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnUscitaMerciOdP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUscitaMerciOdP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUscitaMerciOdP.Location = New System.Drawing.Point(4, 446)
        Me.btnUscitaMerciOdP.Name = "btnUscitaMerciOdP"
        Me.btnUscitaMerciOdP.Size = New System.Drawing.Size(992, 56)
        Me.btnUscitaMerciOdP.TabIndex = 9
        Me.btnUscitaMerciOdP.Tag = "PK01008"
        Me.btnUscitaMerciOdP.Text = "Prelievo Merci x OdP"
        Me.btnUscitaMerciOdP.UseVisualStyleBackColor = False
        Me.btnUscitaMerciOdP.Visible = False
        '
        'btnExecTaskFromQueue
        '
        Me.btnExecTaskFromQueue.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnExecTaskFromQueue.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecTaskFromQueue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExecTaskFromQueue.Location = New System.Drawing.Point(4, 9)
        Me.btnExecTaskFromQueue.Name = "btnExecTaskFromQueue"
        Me.btnExecTaskFromQueue.Size = New System.Drawing.Size(992, 56)
        Me.btnExecTaskFromQueue.TabIndex = 0
        Me.btnExecTaskFromQueue.Tag = "PK01001"
        Me.btnExecTaskFromQueue.Text = "1 - Picking - Esegui Task Coda Missioni "
        Me.btnExecTaskFromQueue.UseVisualStyleBackColor = False
        '
        'btnMoveUDS
        '
        Me.btnMoveUDS.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnMoveUDS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveUDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMoveUDS.Location = New System.Drawing.Point(4, 72)
        Me.btnMoveUDS.Name = "btnMoveUDS"
        Me.btnMoveUDS.Size = New System.Drawing.Size(992, 56)
        Me.btnMoveUDS.TabIndex = 1
        Me.btnMoveUDS.Tag = "PK01002"
        Me.btnMoveUDS.Text = "2 - Sposta UDS"
        Me.btnMoveUDS.UseVisualStyleBackColor = False
        '
        'btnChangeUDS
        '
        Me.btnChangeUDS.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnChangeUDS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeUDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChangeUDS.Location = New System.Drawing.Point(4, 134)
        Me.btnChangeUDS.Name = "btnChangeUDS"
        Me.btnChangeUDS.Size = New System.Drawing.Size(992, 56)
        Me.btnChangeUDS.TabIndex = 2
        Me.btnChangeUDS.Tag = "PK01003"
        Me.btnChangeUDS.Text = "3 - Modifica UDS"
        Me.btnChangeUDS.UseVisualStyleBackColor = False
        '
        'btnExecTruckLoad
        '
        Me.btnExecTruckLoad.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnExecTruckLoad.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecTruckLoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExecTruckLoad.Location = New System.Drawing.Point(4, 197)
        Me.btnExecTruckLoad.Name = "btnExecTruckLoad"
        Me.btnExecTruckLoad.Size = New System.Drawing.Size(992, 56)
        Me.btnExecTruckLoad.TabIndex = 3
        Me.btnExecTruckLoad.Tag = "PK01004"
        Me.btnExecTruckLoad.Text = "4 - Carico Camion"
        Me.btnExecTruckLoad.UseVisualStyleBackColor = False
        '
        'btnUDSJobsMoveList
        '
        Me.btnUDSJobsMoveList.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnUDSJobsMoveList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUDSJobsMoveList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUDSJobsMoveList.Location = New System.Drawing.Point(4, 259)
        Me.btnUDSJobsMoveList.Name = "btnUDSJobsMoveList"
        Me.btnUDSJobsMoveList.Size = New System.Drawing.Size(992, 56)
        Me.btnUDSJobsMoveList.TabIndex = 4
        Me.btnUDSJobsMoveList.Tag = "PK01005"
        Me.btnUDSJobsMoveList.Text = "5 - Lista UDS da Movimentare"
        Me.btnUDSJobsMoveList.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(4, 508)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(478, 56)
        Me.Button1.TabIndex = 12
        Me.Button1.Tag = "PK01008"
        Me.Button1.Text = "8 - Lista Picking Approntamento"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'frmMenuUscitaMerciMainWin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnUDSJobsMoveList)
        Me.Controls.Add(Me.btnExecTruckLoad)
        Me.Controls.Add(Me.btnChangeUDS)
        Me.Controls.Add(Me.btnMoveUDS)
        Me.Controls.Add(Me.btnExecTaskFromQueue)
        Me.Controls.Add(Me.btnUscitaMerciOdP)
        Me.Controls.Add(Me.btnTrasfRietichettaUnitaMagazzino)
        Me.Controls.Add(Me.btnPrintPalletCard)
        Me.Controls.Add(Me.btnMissioneDiPicking)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnForkDropUDS)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuUscitaMerciMainWin"
        Me.Text = "Uscita/Picking Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnForkDropUDS As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnMissioneDiPicking As System.Windows.Forms.Button
    Friend WithEvents btnPrintPalletCard As System.Windows.Forms.Button
    Friend WithEvents btnTrasfRietichettaUnitaMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnUscitaMerciOdP As System.Windows.Forms.Button
    Friend WithEvents btnExecTaskFromQueue As System.Windows.Forms.Button
    Friend WithEvents btnMoveUDS As System.Windows.Forms.Button
    Friend WithEvents btnChangeUDS As System.Windows.Forms.Button
    Friend WithEvents btnExecTruckLoad As System.Windows.Forms.Button
    Friend WithEvents btnUDSJobsMoveList As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
