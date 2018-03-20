<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuEntrataMerci
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
        Me.btnEntrataMerciDaBEMConDocMat = New System.Windows.Forms.Button()
        Me.btnListaMissioniEntrataMerce = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnResoMerciDaProd = New System.Windows.Forms.Button()
        Me.btnEntrataMerciDaProd = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.btnResoUbicazioneDaProd = New System.Windows.Forms.Button()
        Me.btnEntrataMerciFromStockUMGeneric = New System.Windows.Forms.Button()
        Me.btnEntrataMerciTrasfdaProdCarico = New System.Windows.Forms.Button()
        Me.btnEntrataMerciTrasfdaProdScarico = New System.Windows.Forms.Button()
        Me.btnEntrataMerciFromStockUMFromOdp = New System.Windows.Forms.Button()
        Me.btnUDCJobsMoveList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnEntrataMerciDaBEMConDocMat
        '
        Me.btnEntrataMerciDaBEMConDocMat.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciDaBEMConDocMat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciDaBEMConDocMat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciDaBEMConDocMat.Location = New System.Drawing.Point(0, 2)
        Me.btnEntrataMerciDaBEMConDocMat.Name = "btnEntrataMerciDaBEMConDocMat"
        Me.btnEntrataMerciDaBEMConDocMat.Size = New System.Drawing.Size(237, 32)
        Me.btnEntrataMerciDaBEMConDocMat.TabIndex = 0
        Me.btnEntrataMerciDaBEMConDocMat.Tag = "EM01001"
        Me.btnEntrataMerciDaBEMConDocMat.Text = "1 - IDENTIFICA MATERIALE"
        Me.btnEntrataMerciDaBEMConDocMat.UseVisualStyleBackColor = False
        '
        'btnListaMissioniEntrataMerce
        '
        Me.btnListaMissioniEntrataMerce.BackColor = System.Drawing.Color.LightGreen
        Me.btnListaMissioniEntrataMerce.Enabled = False
        Me.btnListaMissioniEntrataMerce.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnListaMissioniEntrataMerce.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnListaMissioniEntrataMerce.Location = New System.Drawing.Point(148, 228)
        Me.btnListaMissioniEntrataMerce.Name = "btnListaMissioniEntrataMerce"
        Me.btnListaMissioniEntrataMerce.Size = New System.Drawing.Size(237, 32)
        Me.btnListaMissioniEntrataMerce.TabIndex = 2
        Me.btnListaMissioniEntrataMerce.Tag = "EM01003"
        Me.btnListaMissioniEntrataMerce.Text = "3 - Lista Missioni Entrata Merce"
        Me.btnListaMissioniEntrataMerce.UseVisualStyleBackColor = False
        Me.btnListaMissioniEntrataMerce.Visible = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(189, 240)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(48, 42)
        Me.btnHome.TabIndex = 10
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnResoMerciDaProd
        '
        Me.btnResoMerciDaProd.BackColor = System.Drawing.Color.LightGreen
        Me.btnResoMerciDaProd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnResoMerciDaProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnResoMerciDaProd.Location = New System.Drawing.Point(109, 208)
        Me.btnResoMerciDaProd.Name = "btnResoMerciDaProd"
        Me.btnResoMerciDaProd.Size = New System.Drawing.Size(51, 36)
        Me.btnResoMerciDaProd.TabIndex = 17
        Me.btnResoMerciDaProd.Text = "EM - Reso Da Produzione"
        Me.btnResoMerciDaProd.UseVisualStyleBackColor = False
        Me.btnResoMerciDaProd.Visible = False
        '
        'btnEntrataMerciDaProd
        '
        Me.btnEntrataMerciDaProd.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciDaProd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciDaProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciDaProd.Location = New System.Drawing.Point(53, 208)
        Me.btnEntrataMerciDaProd.Name = "btnEntrataMerciDaProd"
        Me.btnEntrataMerciDaProd.Size = New System.Drawing.Size(50, 52)
        Me.btnEntrataMerciDaProd.TabIndex = 3
        Me.btnEntrataMerciDaProd.Text = "5 - EM Da Produzione (100)"
        Me.btnEntrataMerciDaProd.UseVisualStyleBackColor = False
        Me.btnEntrataMerciDaProd.Visible = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(1, 240)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(182, 42)
        Me.btnVisualizzaInfo.TabIndex = 9
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "9 - Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnResoUbicazioneDaProd
        '
        Me.btnResoUbicazioneDaProd.BackColor = System.Drawing.Color.LightGreen
        Me.btnResoUbicazioneDaProd.Enabled = False
        Me.btnResoUbicazioneDaProd.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnResoUbicazioneDaProd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnResoUbicazioneDaProd.Location = New System.Drawing.Point(166, 208)
        Me.btnResoUbicazioneDaProd.Name = "btnResoUbicazioneDaProd"
        Me.btnResoUbicazioneDaProd.Size = New System.Drawing.Size(55, 36)
        Me.btnResoUbicazioneDaProd.TabIndex = 23
        Me.btnResoUbicazioneDaProd.Text = "Reso UBICAZ. Da Prod.(Da 100)"
        Me.btnResoUbicazioneDaProd.UseVisualStyleBackColor = False
        Me.btnResoUbicazioneDaProd.Visible = False
        '
        'btnEntrataMerciFromStockUMGeneric
        '
        Me.btnEntrataMerciFromStockUMGeneric.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciFromStockUMGeneric.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciFromStockUMGeneric.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciFromStockUMGeneric.Location = New System.Drawing.Point(0, 36)
        Me.btnEntrataMerciFromStockUMGeneric.Name = "btnEntrataMerciFromStockUMGeneric"
        Me.btnEntrataMerciFromStockUMGeneric.Size = New System.Drawing.Size(237, 32)
        Me.btnEntrataMerciFromStockUMGeneric.TabIndex = 1
        Me.btnEntrataMerciFromStockUMGeneric.Tag = "EM01002"
        Me.btnEntrataMerciFromStockUMGeneric.Text = "2 - DEPOSITO UDC"
        Me.btnEntrataMerciFromStockUMGeneric.UseVisualStyleBackColor = False
        '
        'btnEntrataMerciTrasfdaProdCarico
        '
        Me.btnEntrataMerciTrasfdaProdCarico.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciTrasfdaProdCarico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciTrasfdaProdCarico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciTrasfdaProdCarico.Location = New System.Drawing.Point(0, 81)
        Me.btnEntrataMerciTrasfdaProdCarico.Name = "btnEntrataMerciTrasfdaProdCarico"
        Me.btnEntrataMerciTrasfdaProdCarico.Size = New System.Drawing.Size(237, 32)
        Me.btnEntrataMerciTrasfdaProdCarico.TabIndex = 2
        Me.btnEntrataMerciTrasfdaProdCarico.Tag = "EM01004"
        Me.btnEntrataMerciTrasfdaProdCarico.Text = "4 - EM Trasf. da PRODUZIONE - Carico Navetta"
        Me.btnEntrataMerciTrasfdaProdCarico.UseVisualStyleBackColor = False
        '
        'btnEntrataMerciTrasfdaProdScarico
        '
        Me.btnEntrataMerciTrasfdaProdScarico.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciTrasfdaProdScarico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciTrasfdaProdScarico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciTrasfdaProdScarico.Location = New System.Drawing.Point(0, 115)
        Me.btnEntrataMerciTrasfdaProdScarico.Name = "btnEntrataMerciTrasfdaProdScarico"
        Me.btnEntrataMerciTrasfdaProdScarico.Size = New System.Drawing.Size(237, 32)
        Me.btnEntrataMerciTrasfdaProdScarico.TabIndex = 3
        Me.btnEntrataMerciTrasfdaProdScarico.Tag = "EM01005"
        Me.btnEntrataMerciTrasfdaProdScarico.Text = "5 - EM Trasf. da PRODUZIONE - Scarico Navetta"
        Me.btnEntrataMerciTrasfdaProdScarico.UseVisualStyleBackColor = False
        '
        'btnEntrataMerciFromStockUMFromOdp
        '
        Me.btnEntrataMerciFromStockUMFromOdp.BackColor = System.Drawing.Color.LightGreen
        Me.btnEntrataMerciFromStockUMFromOdp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEntrataMerciFromStockUMFromOdp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEntrataMerciFromStockUMFromOdp.Location = New System.Drawing.Point(0, 160)
        Me.btnEntrataMerciFromStockUMFromOdp.Name = "btnEntrataMerciFromStockUMFromOdp"
        Me.btnEntrataMerciFromStockUMFromOdp.Size = New System.Drawing.Size(237, 32)
        Me.btnEntrataMerciFromStockUMFromOdp.TabIndex = 4
        Me.btnEntrataMerciFromStockUMFromOdp.Tag = "EM01006"
        Me.btnEntrataMerciFromStockUMFromOdp.Text = "6 - EM da PRODUZIONE con UM"
        Me.btnEntrataMerciFromStockUMFromOdp.UseVisualStyleBackColor = False
        '
        'btnUDCJobsMoveList
        '
        Me.btnUDCJobsMoveList.BackColor = System.Drawing.Color.LightGreen
        Me.btnUDCJobsMoveList.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUDCJobsMoveList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUDCJobsMoveList.Location = New System.Drawing.Point(0, 202)
        Me.btnUDCJobsMoveList.Name = "btnUDCJobsMoveList"
        Me.btnUDCJobsMoveList.Size = New System.Drawing.Size(237, 32)
        Me.btnUDCJobsMoveList.TabIndex = 5
        Me.btnUDCJobsMoveList.Tag = "EM01007"
        Me.btnUDCJobsMoveList.Text = "7 - Lista UDC da trasferire"
        Me.btnUDCJobsMoveList.UseVisualStyleBackColor = False
        '
        'frmMenuEntrataMerci
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnUDCJobsMoveList)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnEntrataMerciFromStockUMFromOdp)
        Me.Controls.Add(Me.btnEntrataMerciTrasfdaProdScarico)
        Me.Controls.Add(Me.btnEntrataMerciTrasfdaProdCarico)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnEntrataMerciFromStockUMGeneric)
        Me.Controls.Add(Me.btnResoUbicazioneDaProd)
        Me.Controls.Add(Me.btnEntrataMerciDaProd)
        Me.Controls.Add(Me.btnResoMerciDaProd)
        Me.Controls.Add(Me.btnListaMissioniEntrataMerce)
        Me.Controls.Add(Me.btnEntrataMerciDaBEMConDocMat)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuEntrataMerci"
        Me.Text = "Entrata Merci Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEntrataMerciDaBEMConDocMat As System.Windows.Forms.Button
    Friend WithEvents btnListaMissioniEntrataMerce As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnResoMerciDaProd As System.Windows.Forms.Button
    Friend WithEvents btnEntrataMerciDaProd As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnResoUbicazioneDaProd As System.Windows.Forms.Button
    Friend WithEvents btnEntrataMerciFromStockUMGeneric As System.Windows.Forms.Button
    Friend WithEvents btnEntrataMerciTrasfdaProdCarico As System.Windows.Forms.Button
    Friend WithEvents btnEntrataMerciTrasfdaProdScarico As System.Windows.Forms.Button
    Friend WithEvents btnEntrataMerciFromStockUMFromOdp As System.Windows.Forms.Button
    Friend WithEvents btnUDCJobsMoveList As System.Windows.Forms.Button
End Class
