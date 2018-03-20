<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMainHomeMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainHomeMenu))
        Me.tmrCheckSapConnection = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBackground = New System.Windows.Forms.PictureBox()
        Me.btnEntrataMerci = New System.Windows.Forms.Button()
        Me.btnUscitaMerci = New System.Windows.Forms.Button()
        Me.btnTrasferimentoMerci = New System.Windows.Forms.Button()
        Me.btnBloccoMerci = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.actExitApplication = New System.Windows.Forms.PictureBox()
        Me.btnInventario = New System.Windows.Forms.Button()
        Me.btnProduzione = New System.Windows.Forms.Button()
        Me.btnPalletizzazione = New System.Windows.Forms.Button()
        Me.btnSelectTipiMag = New System.Windows.Forms.PictureBox()
        Me.txtConfigurationInfo = New System.Windows.Forms.TextBox()
        Me.btnSelectForkLift = New System.Windows.Forms.PictureBox()
        Me.btnUtilita = New System.Windows.Forms.Button()
        CType(Me.PictureBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.actExitApplication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectTipiMag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBackground
        '
        Me.PictureBackground.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBackground.Image = CType(resources.GetObject("PictureBackground.Image"), System.Drawing.Image)
        Me.PictureBackground.Location = New System.Drawing.Point(0, 0)
        Me.PictureBackground.Name = "PictureBackground"
        Me.PictureBackground.Size = New System.Drawing.Size(238, 285)
        Me.PictureBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBackground.TabIndex = 22
        Me.PictureBackground.TabStop = False
        Me.PictureBackground.Visible = False
        '
        'btnEntrataMerci
        '
        Me.btnEntrataMerci.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerci.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerci.Location = New System.Drawing.Point(10, 4)
        Me.btnEntrataMerci.Name = "btnEntrataMerci"
        Me.btnEntrataMerci.Size = New System.Drawing.Size(218, 38)
        Me.btnEntrataMerci.TabIndex = 0
        Me.btnEntrataMerci.Tag = "EM00001"
        Me.btnEntrataMerci.Text = "1 - Entrata Merci"
        Me.btnEntrataMerci.UseVisualStyleBackColor = False
        '
        'btnUscitaMerci
        '
        Me.btnUscitaMerci.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnUscitaMerci.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnUscitaMerci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUscitaMerci.Location = New System.Drawing.Point(10, 45)
        Me.btnUscitaMerci.Name = "btnUscitaMerci"
        Me.btnUscitaMerci.Size = New System.Drawing.Size(218, 38)
        Me.btnUscitaMerci.TabIndex = 1
        Me.btnUscitaMerci.Tag = "PK00001"
        Me.btnUscitaMerci.Text = "2 - Uscita/Picking Merci"
        Me.btnUscitaMerci.UseVisualStyleBackColor = False
        '
        'btnTrasferimentoMerci
        '
        Me.btnTrasferimentoMerci.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnTrasferimentoMerci.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasferimentoMerci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasferimentoMerci.Location = New System.Drawing.Point(10, 86)
        Me.btnTrasferimentoMerci.Name = "btnTrasferimentoMerci"
        Me.btnTrasferimentoMerci.Size = New System.Drawing.Size(218, 38)
        Me.btnTrasferimentoMerci.TabIndex = 2
        Me.btnTrasferimentoMerci.Tag = "TR00001"
        Me.btnTrasferimentoMerci.Text = "3 - Trasferimento Merci"
        Me.btnTrasferimentoMerci.UseVisualStyleBackColor = False
        '
        'btnBloccoMerci
        '
        Me.btnBloccoMerci.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnBloccoMerci.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnBloccoMerci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBloccoMerci.Location = New System.Drawing.Point(189, 116)
        Me.btnBloccoMerci.Name = "btnBloccoMerci"
        Me.btnBloccoMerci.Size = New System.Drawing.Size(45, 32)
        Me.btnBloccoMerci.TabIndex = 3
        Me.btnBloccoMerci.Tag = "BL00001"
        Me.btnBloccoMerci.Text = "4 - Blocco/Sblocco Merci"
        Me.btnBloccoMerci.UseVisualStyleBackColor = False
        Me.btnBloccoMerci.Visible = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(10, 168)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(218, 38)
        Me.btnVisualizzaInfo.TabIndex = 4
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "5 - Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightGreen
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(209, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 15)
        Me.Button1.TabIndex = 12
        Me.Button1.TabStop = False
        Me.Button1.Text = "TEST"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'actExitApplication
        '
        Me.actExitApplication.Image = CType(resources.GetObject("actExitApplication.Image"), System.Drawing.Image)
        Me.actExitApplication.Location = New System.Drawing.Point(196, 230)
        Me.actExitApplication.Name = "actExitApplication"
        Me.actExitApplication.Size = New System.Drawing.Size(38, 38)
        Me.actExitApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.actExitApplication.TabIndex = 21
        Me.actExitApplication.TabStop = False
        '
        'btnInventario
        '
        Me.btnInventario.BackColor = System.Drawing.Color.Yellow
        Me.btnInventario.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnInventario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInventario.Location = New System.Drawing.Point(189, 154)
        Me.btnInventario.Name = "btnInventario"
        Me.btnInventario.Size = New System.Drawing.Size(45, 32)
        Me.btnInventario.TabIndex = 4
        Me.btnInventario.Tag = "IV00001"
        Me.btnInventario.Text = "5 - Inventario"
        Me.btnInventario.UseVisualStyleBackColor = False
        Me.btnInventario.Visible = False
        '
        'btnProduzione
        '
        Me.btnProduzione.BackColor = System.Drawing.Color.Blue
        Me.btnProduzione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnProduzione.ForeColor = System.Drawing.Color.White
        Me.btnProduzione.Location = New System.Drawing.Point(206, 130)
        Me.btnProduzione.Name = "btnProduzione"
        Me.btnProduzione.Size = New System.Drawing.Size(29, 30)
        Me.btnProduzione.TabIndex = 15
        Me.btnProduzione.TabStop = False
        Me.btnProduzione.Text = "Produzione"
        Me.btnProduzione.UseVisualStyleBackColor = False
        Me.btnProduzione.Visible = False
        '
        'btnPalletizzazione
        '
        Me.btnPalletizzazione.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnPalletizzazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPalletizzazione.ForeColor = System.Drawing.Color.White
        Me.btnPalletizzazione.Location = New System.Drawing.Point(205, 177)
        Me.btnPalletizzazione.Name = "btnPalletizzazione"
        Me.btnPalletizzazione.Size = New System.Drawing.Size(29, 30)
        Me.btnPalletizzazione.TabIndex = 18
        Me.btnPalletizzazione.TabStop = False
        Me.btnPalletizzazione.Text = "Palletizzazione"
        Me.btnPalletizzazione.UseVisualStyleBackColor = False
        Me.btnPalletizzazione.Visible = False
        '
        'btnSelectTipiMag
        '
        Me.btnSelectTipiMag.Image = CType(resources.GetObject("btnSelectTipiMag.Image"), System.Drawing.Image)
        Me.btnSelectTipiMag.Location = New System.Drawing.Point(4, 230)
        Me.btnSelectTipiMag.Name = "btnSelectTipiMag"
        Me.btnSelectTipiMag.Size = New System.Drawing.Size(38, 38)
        Me.btnSelectTipiMag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectTipiMag.TabIndex = 20
        Me.btnSelectTipiMag.TabStop = False
        Me.btnSelectTipiMag.Tag = "IU00001"
        '
        'txtConfigurationInfo
        '
        Me.txtConfigurationInfo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtConfigurationInfo.ForeColor = System.Drawing.Color.Black
        Me.txtConfigurationInfo.Location = New System.Drawing.Point(84, 211)
        Me.txtConfigurationInfo.Multiline = True
        Me.txtConfigurationInfo.Name = "txtConfigurationInfo"
        Me.txtConfigurationInfo.ReadOnly = True
        Me.txtConfigurationInfo.Size = New System.Drawing.Size(110, 74)
        Me.txtConfigurationInfo.TabIndex = 6
        '
        'btnSelectForkLift
        '
        Me.btnSelectForkLift.Image = CType(resources.GetObject("btnSelectForkLift.Image"), System.Drawing.Image)
        Me.btnSelectForkLift.Location = New System.Drawing.Point(43, 230)
        Me.btnSelectForkLift.Name = "btnSelectForkLift"
        Me.btnSelectForkLift.Size = New System.Drawing.Size(38, 38)
        Me.btnSelectForkLift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectForkLift.TabIndex = 19
        Me.btnSelectForkLift.TabStop = False
        Me.btnSelectForkLift.Tag = "SF00001"
        '
        'btnUtilita
        '
        Me.btnUtilita.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnUtilita.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnUtilita.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUtilita.Location = New System.Drawing.Point(10, 127)
        Me.btnUtilita.Name = "btnUtilita"
        Me.btnUtilita.Size = New System.Drawing.Size(218, 38)
        Me.btnUtilita.TabIndex = 3
        Me.btnUtilita.Tag = "MU00001"
        Me.btnUtilita.Text = "4 - Menu Utilità"
        Me.btnUtilita.UseVisualStyleBackColor = False
        '
        'frmMainHomeMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnProduzione)
        Me.Controls.Add(Me.btnPalletizzazione)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBloccoMerci)
        Me.Controls.Add(Me.btnInventario)
        Me.Controls.Add(Me.btnUtilita)
        Me.Controls.Add(Me.btnSelectForkLift)
        Me.Controls.Add(Me.txtConfigurationInfo)
        Me.Controls.Add(Me.btnSelectTipiMag)
        Me.Controls.Add(Me.actExitApplication)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnTrasferimentoMerci)
        Me.Controls.Add(Me.btnUscitaMerci)
        Me.Controls.Add(Me.btnEntrataMerci)
        Me.Controls.Add(Me.PictureBackground)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMainHomeMenu"
        Me.Text = "WM Home Menu"
        CType(Me.PictureBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.actExitApplication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectTipiMag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrCheckSapConnection As System.Windows.Forms.Timer
    Friend WithEvents PictureBackground As System.Windows.Forms.PictureBox
    Friend WithEvents btnEntrataMerci As System.Windows.Forms.Button
    Friend WithEvents btnUscitaMerci As System.Windows.Forms.Button
    Friend WithEvents btnTrasferimentoMerci As System.Windows.Forms.Button
    Friend WithEvents btnBloccoMerci As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents actExitApplication As System.Windows.Forms.PictureBox
    Friend WithEvents btnInventario As System.Windows.Forms.Button
    Friend WithEvents btnProduzione As System.Windows.Forms.Button
    Friend WithEvents btnPalletizzazione As System.Windows.Forms.Button
    Friend WithEvents btnSelectTipiMag As System.Windows.Forms.PictureBox
    Friend WithEvents txtConfigurationInfo As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectForkLift As System.Windows.Forms.PictureBox
    Friend WithEvents btnUtilita As System.Windows.Forms.Button
End Class
