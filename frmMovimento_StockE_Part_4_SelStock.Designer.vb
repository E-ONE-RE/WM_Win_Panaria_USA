<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMovimento_StockE_Part_4_SelStock
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
        Me.txtUbicazioneOrigine = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.lblUbicazioneOrigine = New System.Windows.Forms.Label()
        Me.lblCodiceMateriale = New System.Windows.Forms.Label()
        Me.txtCodiceMaterialeEPartita = New System.Windows.Forms.TextBox()
        Me.DtGridStockInfo = New System.Windows.Forms.DataGrid()
        Me.txtStockSpeciale = New System.Windows.Forms.TextBox()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUbicazioneOrigine
        '
        Me.txtUbicazioneOrigine.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneOrigine.Location = New System.Drawing.Point(1, 20)
        Me.txtUbicazioneOrigine.Name = "txtUbicazioneOrigine"
        Me.txtUbicazioneOrigine.Size = New System.Drawing.Size(233, 20)
        Me.txtUbicazioneOrigine.TabIndex = 57
        Me.txtUbicazioneOrigine.TabStop = False
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 233)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(69, 48)
        Me.cmdAbortScreen.TabIndex = 61
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(111, 233)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdPreviousScreen.TabIndex = 60
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(177, 233)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(60, 48)
        Me.cmdNextScreen.TabIndex = 59
        Me.cmdNextScreen.Text = "OK"
        '
        'lblUbicazioneOrigine
        '
        Me.lblUbicazioneOrigine.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicazioneOrigine.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneOrigine.Location = New System.Drawing.Point(1, 0)
        Me.lblUbicazioneOrigine.Name = "lblUbicazioneOrigine"
        Me.lblUbicazioneOrigine.Size = New System.Drawing.Size(233, 19)
        Me.lblUbicazioneOrigine.TabIndex = 99
        Me.lblUbicazioneOrigine.Text = "Ubicazione"
        '
        'lblCodiceMateriale
        '
        Me.lblCodiceMateriale.BackColor = System.Drawing.Color.Transparent
        Me.lblCodiceMateriale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodiceMateriale.ForeColor = System.Drawing.Color.Black
        Me.lblCodiceMateriale.Location = New System.Drawing.Point(1, 44)
        Me.lblCodiceMateriale.Name = "lblCodiceMateriale"
        Me.lblCodiceMateriale.Size = New System.Drawing.Size(234, 18)
        Me.lblCodiceMateriale.TabIndex = 98
        Me.lblCodiceMateriale.Text = "Cod.Materiale/Partita/Spec."
        '
        'txtCodiceMaterialeEPartita
        '
        Me.txtCodiceMaterialeEPartita.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCodiceMaterialeEPartita.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodiceMaterialeEPartita.ForeColor = System.Drawing.Color.Black
        Me.txtCodiceMaterialeEPartita.Location = New System.Drawing.Point(1, 63)
        Me.txtCodiceMaterialeEPartita.Name = "txtCodiceMaterialeEPartita"
        Me.txtCodiceMaterialeEPartita.Size = New System.Drawing.Size(234, 20)
        Me.txtCodiceMaterialeEPartita.TabIndex = 85
        Me.txtCodiceMaterialeEPartita.TabStop = False
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(0, 113)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.Size = New System.Drawing.Size(237, 117)
        Me.DtGridStockInfo.TabIndex = 93
        '
        'txtStockSpeciale
        '
        Me.txtStockSpeciale.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtStockSpeciale.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtStockSpeciale.ForeColor = System.Drawing.Color.Black
        Me.txtStockSpeciale.Location = New System.Drawing.Point(1, 86)
        Me.txtStockSpeciale.Name = "txtStockSpeciale"
        Me.txtStockSpeciale.Size = New System.Drawing.Size(234, 22)
        Me.txtStockSpeciale.TabIndex = 97
        Me.txtStockSpeciale.TabStop = False
        '
        'frmMovimento_StockE_Part_4_SelStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.txtStockSpeciale)
        Me.Controls.Add(Me.DtGridStockInfo)
        Me.Controls.Add(Me.lblCodiceMateriale)
        Me.Controls.Add(Me.txtCodiceMaterialeEPartita)
        Me.Controls.Add(Me.lblUbicazioneOrigine)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.txtUbicazioneOrigine)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimento_StockE_Part_4_SelStock"
        Me.Text = "Mov. Stock E (4)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUbicazioneOrigine As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents lblUbicazioneOrigine As System.Windows.Forms.Label
    Friend WithEvents lblCodiceMateriale As System.Windows.Forms.Label
    Friend WithEvents txtCodiceMaterialeEPartita As System.Windows.Forms.TextBox
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents txtStockSpeciale As System.Windows.Forms.TextBox
End Class
