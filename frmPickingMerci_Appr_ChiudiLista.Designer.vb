<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Appr_ChiudiLista
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
        Me.cmdVerificaStock = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdCloseJobsGroup = New System.Windows.Forms.Button()
        Me.txtInfoRowSelected = New System.Windows.Forms.TextBox()
        Me.cmdSpostaTuttiGliUDC = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazioneDest = New System.Windows.Forms.Button()
        Me.txtUbicazioneDestinazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneDestinazione = New System.Windows.Forms.Label()
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtGridStockInfo
        '
        Me.DtGridStockInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridStockInfo.DataMember = ""
        Me.DtGridStockInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridStockInfo.Location = New System.Drawing.Point(0, 151)
        Me.DtGridStockInfo.Name = "DtGridStockInfo"
        Me.DtGridStockInfo.Size = New System.Drawing.Size(237, 103)
        Me.DtGridStockInfo.TabIndex = 104
        '
        'cmdVerificaStock
        '
        Me.cmdVerificaStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdVerificaStock.Location = New System.Drawing.Point(3, 255)
        Me.cmdVerificaStock.Name = "cmdVerificaStock"
        Me.cmdVerificaStock.Size = New System.Drawing.Size(59, 40)
        Me.cmdVerificaStock.TabIndex = 102
        Me.cmdVerificaStock.Text = "Verifica"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(115, 255)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(60, 40)
        Me.cmdPreviousScreen.TabIndex = 101
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdCloseJobsGroup
        '
        Me.cmdCloseJobsGroup.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdCloseJobsGroup.Location = New System.Drawing.Point(177, 255)
        Me.cmdCloseJobsGroup.Name = "cmdCloseJobsGroup"
        Me.cmdCloseJobsGroup.Size = New System.Drawing.Size(60, 40)
        Me.cmdCloseJobsGroup.TabIndex = 100
        Me.cmdCloseJobsGroup.Text = "Chiudi"
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
        Me.txtInfoRowSelected.Size = New System.Drawing.Size(238, 109)
        Me.txtInfoRowSelected.TabIndex = 180
        Me.txtInfoRowSelected.TabStop = False
        '
        'cmdSpostaTuttiGliUDC
        '
        Me.cmdSpostaTuttiGliUDC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cmdSpostaTuttiGliUDC.Location = New System.Drawing.Point(158, 111)
        Me.cmdSpostaTuttiGliUDC.Name = "cmdSpostaTuttiGliUDC"
        Me.cmdSpostaTuttiGliUDC.Size = New System.Drawing.Size(80, 39)
        Me.cmdSpostaTuttiGliUDC.TabIndex = 182
        Me.cmdSpostaTuttiGliUDC.Text = "Sposta"
        '
        'cmdSelectUbicazioneDest
        '
        Me.cmdSelectUbicazioneDest.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazioneDest.Location = New System.Drawing.Point(94, 111)
        Me.cmdSelectUbicazioneDest.Name = "cmdSelectUbicazioneDest"
        Me.cmdSelectUbicazioneDest.Size = New System.Drawing.Size(49, 39)
        Me.cmdSelectUbicazioneDest.TabIndex = 185
        Me.cmdSelectUbicazioneDest.Text = "..."
        '
        'txtUbicazioneDestinazione
        '
        Me.txtUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestinazione.Location = New System.Drawing.Point(1, 127)
        Me.txtUbicazioneDestinazione.MaxLength = 10
        Me.txtUbicazioneDestinazione.Name = "txtUbicazioneDestinazione"
        Me.txtUbicazioneDestinazione.Size = New System.Drawing.Size(91, 24)
        Me.txtUbicazioneDestinazione.TabIndex = 184
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(1, 110)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(91, 22)
        Me.lblUbicazioneDestinazione.TabIndex = 186
        Me.lblUbicazioneDestinazione.Text = "Ubicaz.Dest."
        '
        'frmPickingMerci_Appr_ChiudiLista
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Controls.Add(Me.cmdSelectUbicazioneDest)
        Me.Controls.Add(Me.txtUbicazioneDestinazione)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.cmdSpostaTuttiGliUDC)
        Me.Controls.Add(Me.txtInfoRowSelected)
        Me.Controls.Add(Me.DtGridStockInfo)
        Me.Controls.Add(Me.cmdVerificaStock)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdCloseJobsGroup)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Appr_ChiudiLista"
        Me.Text = "Picking Appr.(Chiudi)"
        CType(Me.DtGridStockInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtGridStockInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdVerificaStock As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdCloseJobsGroup As System.Windows.Forms.Button
    Friend WithEvents txtInfoRowSelected As System.Windows.Forms.TextBox
    Friend WithEvents cmdSpostaTuttiGliUDC As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazioneDest As System.Windows.Forms.Button
    Friend WithEvents txtUbicazioneDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneDestinazione As System.Windows.Forms.Label
End Class
