<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuCommesse
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
        Me.btnVisualizzaMaterialeCommessa = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVisualizzaMaterialeCommessa
        '
        Me.btnVisualizzaMaterialeCommessa.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnVisualizzaMaterialeCommessa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaMaterialeCommessa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaMaterialeCommessa.Location = New System.Drawing.Point(2, 27)
        Me.btnVisualizzaMaterialeCommessa.Name = "btnVisualizzaMaterialeCommessa"
        Me.btnVisualizzaMaterialeCommessa.Size = New System.Drawing.Size(231, 36)
        Me.btnVisualizzaMaterialeCommessa.TabIndex = 8
        Me.btnVisualizzaMaterialeCommessa.Text = "Lista Materiale Commessa"
        Me.btnVisualizzaMaterialeCommessa.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(181, 243)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(54, 36)
        Me.btnHome.TabIndex = 15
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(1, 243)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(178, 36)
        Me.btnVisualizzaInfo.TabIndex = 22
        Me.btnVisualizzaInfo.Text = "Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'frmMenuCommesse
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnVisualizzaMaterialeCommessa)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuCommesse"
        Me.Text = "Commesse Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVisualizzaMaterialeCommessa As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
End Class
