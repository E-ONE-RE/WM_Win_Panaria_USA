<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInfoListaPicking
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
        Me.DtGridStockInfo = New System.Windows.Forms.DataGrid()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        Me.btnHome = New System.Windows.Forms.Button()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(0, 120)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.Size = New System.Drawing.Size(237, 137)
        Me.DtGridStockInfo.TabIndex = 104
        '
        'txtInfoRowSelected
        '
        Me.txtInfoRowSelected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInfoRowSelected.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoRowSelected.ForeColor = System.Drawing.Color.Black
        Me.txtInfoRowSelected.Location = New System.Drawing.Point(0, 0)
        Me.txtInfoRowSelected.Multiline = True
        Me.txtInfoRowSelected.Name = "txtInfoRowSelected"
        Me.txtInfoRowSelected.ReadOnly = True
        Me.txtInfoRowSelected.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(238, 118)
        Me.txtInfoRowSelected.TabIndex = 180
        Me.txtInfoRowSelected.TabStop = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnHome.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnHome.Location = New System.Drawing.Point(189, 258)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(48, 36)
        Me.btnHome.TabIndex = 181
        Me.btnHome.Text = "Chiudi"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'frmInfoListaPicking
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.Controls.Add(Me.DtGridStockInfo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoListaPicking"
        Me.Text = "Picking Appr.(Chiudi)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents btnHome As System.Windows.Forms.Button
End Class
