<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuTrasferMain
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
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnTrasfUBI = New System.Windows.Forms.Button()
        Me.btnTrasfChangeLabelUnitaMagazzino = New System.Windows.Forms.Button()
        Me.btnTrasfUnitaMagazzino = New System.Windows.Forms.Button()
        Me.btnTrasfMateriale = New System.Windows.Forms.Button()
        Me.btnDisaccantonamentoMerci = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(3, 246)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(174, 36)
        Me.btnVisualizzaInfo.TabIndex = 7
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(178, 246)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(57, 36)
        Me.btnHome.TabIndex = 6
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnTrasfUBI
        '
        Me.btnTrasfUBI.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnTrasfUBI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasfUBI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfUBI.Location = New System.Drawing.Point(4, 108)
        Me.btnTrasfUBI.Name = "btnTrasfUBI"
        Me.btnTrasfUBI.Size = New System.Drawing.Size(231, 34)
        Me.btnTrasfUBI.TabIndex = 4
        Me.btnTrasfUBI.Tag = "TR01005"
        Me.btnTrasfUBI.Text = "5 - Trasferisci Ubicazione"
        Me.btnTrasfUBI.UseVisualStyleBackColor = False
        '
        'btnTrasfChangeLabelUnitaMagazzino
        '
        Me.btnTrasfChangeLabelUnitaMagazzino.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnTrasfChangeLabelUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasfChangeLabelUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfChangeLabelUnitaMagazzino.Location = New System.Drawing.Point(4, 73)
        Me.btnTrasfChangeLabelUnitaMagazzino.Name = "btnTrasfChangeLabelUnitaMagazzino"
        Me.btnTrasfChangeLabelUnitaMagazzino.Size = New System.Drawing.Size(231, 34)
        Me.btnTrasfChangeLabelUnitaMagazzino.TabIndex = 3
        Me.btnTrasfChangeLabelUnitaMagazzino.Tag = "TR01003"
        Me.btnTrasfChangeLabelUnitaMagazzino.Text = "3 - Ri-etichettatura Unita Magazzino"
        Me.btnTrasfChangeLabelUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'btnTrasfUnitaMagazzino
        '
        Me.btnTrasfUnitaMagazzino.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnTrasfUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasfUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfUnitaMagazzino.Location = New System.Drawing.Point(4, 38)
        Me.btnTrasfUnitaMagazzino.Name = "btnTrasfUnitaMagazzino"
        Me.btnTrasfUnitaMagazzino.Size = New System.Drawing.Size(231, 34)
        Me.btnTrasfUnitaMagazzino.TabIndex = 2
        Me.btnTrasfUnitaMagazzino.Tag = "TR01002"
        Me.btnTrasfUnitaMagazzino.Text = "2 - Trasf. Unita Mag. Completa"
        Me.btnTrasfUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'btnTrasfMateriale
        '
        Me.btnTrasfMateriale.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnTrasfMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTrasfMateriale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnTrasfMateriale.Location = New System.Drawing.Point(4, 3)
        Me.btnTrasfMateriale.Name = "btnTrasfMateriale"
        Me.btnTrasfMateriale.Size = New System.Drawing.Size(231, 34)
        Me.btnTrasfMateriale.TabIndex = 1
        Me.btnTrasfMateriale.Tag = "TR01001"
        Me.btnTrasfMateriale.Text = "1 - Trasferimento Merce"
        Me.btnTrasfMateriale.UseVisualStyleBackColor = False
        '
        'btnDisaccantonamentoMerci
        '
        Me.btnDisaccantonamentoMerci.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnDisaccantonamentoMerci.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDisaccantonamentoMerci.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDisaccantonamentoMerci.Location = New System.Drawing.Point(4, 207)
        Me.btnDisaccantonamentoMerci.Name = "btnDisaccantonamentoMerci"
        Me.btnDisaccantonamentoMerci.Size = New System.Drawing.Size(231, 34)
        Me.btnDisaccantonamentoMerci.TabIndex = 5
        Me.btnDisaccantonamentoMerci.Tag = "TR01006"
        Me.btnDisaccantonamentoMerci.Text = "8 - Disaccantonamento Merci"
        Me.btnDisaccantonamentoMerci.UseVisualStyleBackColor = False
        '
        'frmMenuTrasferMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnDisaccantonamentoMerci)
        Me.Controls.Add(Me.btnTrasfUBI)
        Me.Controls.Add(Me.btnTrasfChangeLabelUnitaMagazzino)
        Me.Controls.Add(Me.btnTrasfUnitaMagazzino)
        Me.Controls.Add(Me.btnTrasfMateriale)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuTrasferMain"
        Me.Text = "Menu Trasferimenti"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnTrasfUBI As System.Windows.Forms.Button
    Friend WithEvents btnTrasfChangeLabelUnitaMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnTrasfUnitaMagazzino As System.Windows.Forms.Button
    Friend WithEvents btnTrasfMateriale As System.Windows.Forms.Button
    Friend WithEvents btnDisaccantonamentoMerci As System.Windows.Forms.Button
End Class
