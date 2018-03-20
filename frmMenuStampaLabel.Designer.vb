<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuStampaLabel
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
        Me.btnCloseForm = New System.Windows.Forms.Button()
        Me.btnPrintLabelUDC = New System.Windows.Forms.Button()
        Me.btnPrintLabelUDS = New System.Windows.Forms.Button()
        Me.btnPrintLabelKTAG = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(1, 246)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(120, 36)
        Me.btnVisualizzaInfo.TabIndex = 9
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "Visual. Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(178, 246)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(55, 36)
        Me.btnHome.TabIndex = 3
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnCloseForm
        '
        Me.btnCloseForm.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCloseForm.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnCloseForm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCloseForm.Location = New System.Drawing.Point(122, 246)
        Me.btnCloseForm.Name = "btnCloseForm"
        Me.btnCloseForm.Size = New System.Drawing.Size(55, 36)
        Me.btnCloseForm.TabIndex = 93
        Me.btnCloseForm.Text = "Chiudi"
        Me.btnCloseForm.UseVisualStyleBackColor = False
        '
        'btnPrintLabelUDC
        '
        Me.btnPrintLabelUDC.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnPrintLabelUDC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintLabelUDC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintLabelUDC.Location = New System.Drawing.Point(1, 3)
        Me.btnPrintLabelUDC.Name = "btnPrintLabelUDC"
        Me.btnPrintLabelUDC.Size = New System.Drawing.Size(237, 34)
        Me.btnPrintLabelUDC.TabIndex = 94
        Me.btnPrintLabelUDC.Tag = "TR01003"
        Me.btnPrintLabelUDC.Text = "1 - Stampa Etichette UDC"
        Me.btnPrintLabelUDC.UseVisualStyleBackColor = False
        '
        'btnPrintLabelUDS
        '
        Me.btnPrintLabelUDS.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnPrintLabelUDS.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintLabelUDS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintLabelUDS.Location = New System.Drawing.Point(1, 38)
        Me.btnPrintLabelUDS.Name = "btnPrintLabelUDS"
        Me.btnPrintLabelUDS.Size = New System.Drawing.Size(237, 34)
        Me.btnPrintLabelUDS.TabIndex = 95
        Me.btnPrintLabelUDS.Tag = "TR01004"
        Me.btnPrintLabelUDS.Text = "2 - Stampa Etichette UDS"
        Me.btnPrintLabelUDS.UseVisualStyleBackColor = False
        '
        'btnPrintLabelKTAG
        '
        Me.btnPrintLabelKTAG.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnPrintLabelKTAG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintLabelKTAG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintLabelKTAG.Location = New System.Drawing.Point(1, 73)
        Me.btnPrintLabelKTAG.Name = "btnPrintLabelKTAG"
        Me.btnPrintLabelKTAG.Size = New System.Drawing.Size(237, 34)
        Me.btnPrintLabelKTAG.TabIndex = 96
        Me.btnPrintLabelKTAG.Tag = "TR01005"
        Me.btnPrintLabelKTAG.Text = "3 - Stampa Etichette KTAG"
        Me.btnPrintLabelKTAG.UseVisualStyleBackColor = False
        '
        'frmMenuStampaLabel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnPrintLabelKTAG)
        Me.Controls.Add(Me.btnPrintLabelUDS)
        Me.Controls.Add(Me.btnPrintLabelUDC)
        Me.Controls.Add(Me.btnCloseForm)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuStampaLabel"
        Me.Text = "Menu Stampe Pallet CArd"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnCloseForm As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabelUDC As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabelUDS As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabelKTAG As System.Windows.Forms.Button
End Class
