<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuDisaccantonamento
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
        Me.btnListaMissioniDisaccantonamento = New System.Windows.Forms.Button()
        Me.btnEseguiMissioneDisaccantonamento = New System.Windows.Forms.Button()
        Me.btnCloseForm = New System.Windows.Forms.Button()
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
        'btnListaMissioniDisaccantonamento
        '
        Me.btnListaMissioniDisaccantonamento.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnListaMissioniDisaccantonamento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnListaMissioniDisaccantonamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnListaMissioniDisaccantonamento.Location = New System.Drawing.Point(3, 13)
        Me.btnListaMissioniDisaccantonamento.Name = "btnListaMissioniDisaccantonamento"
        Me.btnListaMissioniDisaccantonamento.Size = New System.Drawing.Size(231, 34)
        Me.btnListaMissioniDisaccantonamento.TabIndex = 1
        Me.btnListaMissioniDisaccantonamento.Tag = "TR02001"
        Me.btnListaMissioniDisaccantonamento.Text = "1 - Lista Miss.Disaccantonamenti"
        Me.btnListaMissioniDisaccantonamento.UseVisualStyleBackColor = False
        '
        'btnEseguiMissioneDisaccantonamento
        '
        Me.btnEseguiMissioneDisaccantonamento.BackColor = System.Drawing.Color.LemonChiffon
        Me.btnEseguiMissioneDisaccantonamento.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEseguiMissioneDisaccantonamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEseguiMissioneDisaccantonamento.Location = New System.Drawing.Point(3, 48)
        Me.btnEseguiMissioneDisaccantonamento.Name = "btnEseguiMissioneDisaccantonamento"
        Me.btnEseguiMissioneDisaccantonamento.Size = New System.Drawing.Size(231, 34)
        Me.btnEseguiMissioneDisaccantonamento.TabIndex = 2
        Me.btnEseguiMissioneDisaccantonamento.Tag = "TR02002"
        Me.btnEseguiMissioneDisaccantonamento.Text = "2 - Disaccantonamento-Esegui Miss."
        Me.btnEseguiMissioneDisaccantonamento.UseVisualStyleBackColor = False
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
        'frmMenuDisaccantonamento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnCloseForm)
        Me.Controls.Add(Me.btnEseguiMissioneDisaccantonamento)
        Me.Controls.Add(Me.btnListaMissioniDisaccantonamento)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuDisaccantonamento"
        Me.Text = "Menu Trasf. Disaccantonamenti"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnListaMissioniDisaccantonamento As System.Windows.Forms.Button
    Friend WithEvents btnEseguiMissioneDisaccantonamento As System.Windows.Forms.Button
    Friend WithEvents btnCloseForm As System.Windows.Forms.Button
End Class
