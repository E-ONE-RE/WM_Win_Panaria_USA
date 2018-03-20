<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMenuInventario
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
        Me.btnInventarioUbicazione = New System.Windows.Forms.Button()
        Me.btnInventarioRottamazione = New System.Windows.Forms.Button()
        Me.btnVisualizzaInfo = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnInventarioCentroCosto = New System.Windows.Forms.Button()
        Me.btnInventarioUnitaMagazzino = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInventarioUbicazione
        '
        Me.btnInventarioUbicazione.BackColor = System.Drawing.Color.Yellow
        Me.btnInventarioUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInventarioUbicazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInventarioUbicazione.Location = New System.Drawing.Point(2, 1)
        Me.btnInventarioUbicazione.Name = "btnInventarioUbicazione"
        Me.btnInventarioUbicazione.Size = New System.Drawing.Size(234, 48)
        Me.btnInventarioUbicazione.TabIndex = 0
        Me.btnInventarioUbicazione.Tag = "IV00001"
        Me.btnInventarioUbicazione.Text = "1 - Inventario/Conta Ubicazione"
        Me.btnInventarioUbicazione.UseVisualStyleBackColor = False
        '
        'btnInventarioRottamazione
        '
        Me.btnInventarioRottamazione.BackColor = System.Drawing.Color.Yellow
        Me.btnInventarioRottamazione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInventarioRottamazione.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInventarioRottamazione.Location = New System.Drawing.Point(2, 115)
        Me.btnInventarioRottamazione.Name = "btnInventarioRottamazione"
        Me.btnInventarioRottamazione.Size = New System.Drawing.Size(234, 48)
        Me.btnInventarioRottamazione.TabIndex = 2
        Me.btnInventarioRottamazione.Tag = "IV00003"
        Me.btnInventarioRottamazione.Text = "3 - Rottura / Rottamazione"
        Me.btnInventarioRottamazione.UseVisualStyleBackColor = False
        '
        'btnVisualizzaInfo
        '
        Me.btnVisualizzaInfo.BackColor = System.Drawing.Color.Khaki
        Me.btnVisualizzaInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnVisualizzaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnVisualizzaInfo.Location = New System.Drawing.Point(3, 232)
        Me.btnVisualizzaInfo.Name = "btnVisualizzaInfo"
        Me.btnVisualizzaInfo.Size = New System.Drawing.Size(174, 46)
        Me.btnVisualizzaInfo.TabIndex = 5
        Me.btnVisualizzaInfo.Tag = "VI00001"
        Me.btnVisualizzaInfo.Text = "Visualizza Info"
        Me.btnVisualizzaInfo.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(178, 232)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(57, 46)
        Me.btnHome.TabIndex = 4
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnInventarioCentroCosto
        '
        Me.btnInventarioCentroCosto.BackColor = System.Drawing.Color.Yellow
        Me.btnInventarioCentroCosto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInventarioCentroCosto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInventarioCentroCosto.Location = New System.Drawing.Point(2, 172)
        Me.btnInventarioCentroCosto.Name = "btnInventarioCentroCosto"
        Me.btnInventarioCentroCosto.Size = New System.Drawing.Size(234, 48)
        Me.btnInventarioCentroCosto.TabIndex = 3
        Me.btnInventarioCentroCosto.Tag = "IV00004"
        Me.btnInventarioCentroCosto.Text = "4 - Consumo Per Centro Costo"
        Me.btnInventarioCentroCosto.UseVisualStyleBackColor = False
        '
        'btnInventarioUnitaMagazzino
        '
        Me.btnInventarioUnitaMagazzino.BackColor = System.Drawing.Color.Yellow
        Me.btnInventarioUnitaMagazzino.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnInventarioUnitaMagazzino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnInventarioUnitaMagazzino.Location = New System.Drawing.Point(2, 58)
        Me.btnInventarioUnitaMagazzino.Name = "btnInventarioUnitaMagazzino"
        Me.btnInventarioUnitaMagazzino.Size = New System.Drawing.Size(234, 48)
        Me.btnInventarioUnitaMagazzino.TabIndex = 1
        Me.btnInventarioUnitaMagazzino.Tag = "IV00002"
        Me.btnInventarioUnitaMagazzino.Text = "2-Inventario/Conta Unità Magazzino"
        Me.btnInventarioUnitaMagazzino.UseVisualStyleBackColor = False
        '
        'frmMenuInventario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.btnInventarioUnitaMagazzino)
        Me.Controls.Add(Me.btnInventarioCentroCosto)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnVisualizzaInfo)
        Me.Controls.Add(Me.btnInventarioRottamazione)
        Me.Controls.Add(Me.btnInventarioUbicazione)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuInventario"
        Me.Text = "Menu Inventario"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnInventarioUbicazione As System.Windows.Forms.Button
    Friend WithEvents btnInventarioRottamazione As System.Windows.Forms.Button
    Friend WithEvents btnVisualizzaInfo As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnInventarioCentroCosto As System.Windows.Forms.Button
    Friend WithEvents btnInventarioUnitaMagazzino As System.Windows.Forms.Button
End Class
