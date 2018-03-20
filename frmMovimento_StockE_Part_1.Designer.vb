<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMovimento_StockE_Part_1
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
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.PanelSceltaDestinazione = New System.Windows.Forms.Panel()
        Me.RadioBtnTransferStockECustom = New System.Windows.Forms.RadioButton()
        Me.RadioBtnTogliStockECustom = New System.Windows.Forms.RadioButton()
        Me.RadioBtnMettiStockECustom = New System.Windows.Forms.RadioButton()
        Me.RadioBtnTransferStockE = New System.Windows.Forms.RadioButton()
        Me.lblInfoScelta = New System.Windows.Forms.Label()
        Me.RadioBtnTogliStockE = New System.Windows.Forms.RadioButton()
        Me.RadioBtnMettiStockE = New System.Windows.Forms.RadioButton()
        Me.PanelSceltaDestinazione.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(157, 221)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(76, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(3, 221)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(76, 60)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'PanelSceltaDestinazione
        '
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTransferStockECustom)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTogliStockECustom)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnMettiStockECustom)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTransferStockE)
        Me.PanelSceltaDestinazione.Controls.Add(Me.lblInfoScelta)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnTogliStockE)
        Me.PanelSceltaDestinazione.Controls.Add(Me.RadioBtnMettiStockE)
        Me.PanelSceltaDestinazione.Location = New System.Drawing.Point(1, 1)
        Me.PanelSceltaDestinazione.Name = "PanelSceltaDestinazione"
        Me.PanelSceltaDestinazione.Size = New System.Drawing.Size(235, 210)
        Me.PanelSceltaDestinazione.TabIndex = 0
        '
        'RadioBtnTransferStockECustom
        '
        Me.RadioBtnTransferStockECustom.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnTransferStockECustom.Enabled = False
        Me.RadioBtnTransferStockECustom.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTransferStockECustom.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTransferStockECustom.Location = New System.Drawing.Point(1, 184)
        Me.RadioBtnTransferStockECustom.Name = "RadioBtnTransferStockECustom"
        Me.RadioBtnTransferStockECustom.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnTransferStockECustom.TabIndex = 5
        Me.RadioBtnTransferStockECustom.Text = "Trasf. Stock E (xxxE)"
        Me.RadioBtnTransferStockECustom.UseVisualStyleBackColor = False
        Me.RadioBtnTransferStockECustom.Visible = False
        '
        'RadioBtnTogliStockECustom
        '
        Me.RadioBtnTogliStockECustom.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnTogliStockECustom.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTogliStockECustom.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTogliStockECustom.Location = New System.Drawing.Point(1, 156)
        Me.RadioBtnTogliStockECustom.Name = "RadioBtnTogliStockECustom"
        Me.RadioBtnTogliStockECustom.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnTogliStockECustom.TabIndex = 4
        Me.RadioBtnTogliStockECustom.Text = "Togli Stock E (997 E)"
        Me.RadioBtnTogliStockECustom.UseVisualStyleBackColor = False
        '
        'RadioBtnMettiStockECustom
        '
        Me.RadioBtnMettiStockECustom.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnMettiStockECustom.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnMettiStockECustom.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnMettiStockECustom.Location = New System.Drawing.Point(1, 128)
        Me.RadioBtnMettiStockECustom.Name = "RadioBtnMettiStockECustom"
        Me.RadioBtnMettiStockECustom.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnMettiStockECustom.TabIndex = 3
        Me.RadioBtnMettiStockECustom.Text = "Metti In Stock E (998E)"
        Me.RadioBtnMettiStockECustom.UseVisualStyleBackColor = False
        '
        'RadioBtnTransferStockE
        '
        Me.RadioBtnTransferStockE.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnTransferStockE.Enabled = False
        Me.RadioBtnTransferStockE.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTransferStockE.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTransferStockE.Location = New System.Drawing.Point(1, 94)
        Me.RadioBtnTransferStockE.Name = "RadioBtnTransferStockE"
        Me.RadioBtnTransferStockE.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnTransferStockE.TabIndex = 2
        Me.RadioBtnTransferStockE.Text = "Trasf. Stock E (413E)"
        Me.RadioBtnTransferStockE.UseVisualStyleBackColor = False
        Me.RadioBtnTransferStockE.Visible = False
        '
        'lblInfoScelta
        '
        Me.lblInfoScelta.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoScelta.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoScelta.ForeColor = System.Drawing.Color.Black
        Me.lblInfoScelta.Location = New System.Drawing.Point(1, 0)
        Me.lblInfoScelta.Name = "lblInfoScelta"
        Me.lblInfoScelta.Size = New System.Drawing.Size(229, 29)
        Me.lblInfoScelta.TabIndex = 6
        Me.lblInfoScelta.Text = "Scelta Tipo Mov.Stock E"
        '
        'RadioBtnTogliStockE
        '
        Me.RadioBtnTogliStockE.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnTogliStockE.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnTogliStockE.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnTogliStockE.Location = New System.Drawing.Point(1, 66)
        Me.RadioBtnTogliStockE.Name = "RadioBtnTogliStockE"
        Me.RadioBtnTogliStockE.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnTogliStockE.TabIndex = 1
        Me.RadioBtnTogliStockE.Text = "Togli Stock E (411 E)"
        Me.RadioBtnTogliStockE.UseVisualStyleBackColor = False
        '
        'RadioBtnMettiStockE
        '
        Me.RadioBtnMettiStockE.BackColor = System.Drawing.Color.Transparent
        Me.RadioBtnMettiStockE.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioBtnMettiStockE.ForeColor = System.Drawing.Color.Black
        Me.RadioBtnMettiStockE.Location = New System.Drawing.Point(1, 38)
        Me.RadioBtnMettiStockE.Name = "RadioBtnMettiStockE"
        Me.RadioBtnMettiStockE.Size = New System.Drawing.Size(232, 23)
        Me.RadioBtnMettiStockE.TabIndex = 0
        Me.RadioBtnMettiStockE.Text = "Metti In Stock E (412E)"
        Me.RadioBtnMettiStockE.UseVisualStyleBackColor = False
        '
        'frmMovimento_StockE_Part_1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.PanelSceltaDestinazione)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimento_StockE_Part_1"
        Me.Text = "Movimento Stock E (1)"
        Me.PanelSceltaDestinazione.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents PanelSceltaDestinazione As System.Windows.Forms.Panel
    Friend WithEvents RadioBtnMettiStockE As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnTogliStockE As System.Windows.Forms.RadioButton
    Friend WithEvents lblInfoScelta As System.Windows.Forms.Label
    Friend WithEvents RadioBtnTransferStockE As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnTransferStockECustom As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnTogliStockECustom As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBtnMettiStockECustom As System.Windows.Forms.RadioButton
End Class
