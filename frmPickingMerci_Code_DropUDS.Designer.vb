<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Code_DropUDS
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
        Me.lblSystemInfo = New System.Windows.Forms.Label()
        Me.txtInfoJobSelezionato = New System.Windows.Forms.TextBox()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.DtGridListInfo = New System.Windows.Forms.DataGrid()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.txtUbicazioneDestinazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneDestinazione = New System.Windows.Forms.Label()
        Me.txtStaging = New System.Windows.Forms.TextBox()
        Me.lblStaging = New System.Windows.Forms.Label()
        Me.txtDockDoor = New System.Windows.Forms.TextBox()
        Me.lblDockDoor = New System.Windows.Forms.Label()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.lblInfoUDSOnWork = New System.Windows.Forms.Label()
        Me.txtInfoPesoMissione = New System.Windows.Forms.TextBox()
        Me.cmdJobFunctions = New System.Windows.Forms.Button()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSystemInfo
        '
        Me.lblSystemInfo.BackColor = System.Drawing.Color.LightGreen
        Me.lblSystemInfo.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSystemInfo.Location = New System.Drawing.Point(5, 2)
        Me.lblSystemInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemInfo.Name = "lblSystemInfo"
        Me.lblSystemInfo.Size = New System.Drawing.Size(998, 28)
        Me.lblSystemInfo.TabIndex = 125
        Me.lblSystemInfo.Text = "Operatore: - Dispositivo"
        '
        'txtInfoJobSelezionato
        '
        Me.txtInfoJobSelezionato.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoJobSelezionato.Font = New System.Drawing.Font("Tahoma", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoJobSelezionato.ForeColor = System.Drawing.Color.Black
        Me.txtInfoJobSelezionato.Location = New System.Drawing.Point(6, 62)
        Me.txtInfoJobSelezionato.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoJobSelezionato.Multiline = True
        Me.txtInfoJobSelezionato.Name = "txtInfoJobSelezionato"
        Me.txtInfoJobSelezionato.ReadOnly = True
        Me.txtInfoJobSelezionato.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoJobSelezionato.Size = New System.Drawing.Size(994, 350)
        Me.txtInfoJobSelezionato.TabIndex = 121
        Me.txtInfoJobSelezionato.TabStop = False
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(9, 662)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(98, 62)
        Me.cmdAbortScreen.TabIndex = 122
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(802, 662)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(200, 62)
        Me.cmdNextScreen.TabIndex = 124
        Me.cmdNextScreen.Text = "OK"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(3, 414)
        Me.DtGridListInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.ReadOnly = True
        Me.DtGridListInfo.Size = New System.Drawing.Size(1003, 162)
        Me.DtGridListInfo.TabIndex = 126
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(907, 576)
        Me.cmdSelectUbicazione.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(94, 81)
        Me.cmdSelectUbicazione.TabIndex = 180
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtUbicazioneDestinazione
        '
        Me.txtUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestinazione.Location = New System.Drawing.Point(588, 616)
        Me.txtUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUbicazioneDestinazione.MaxLength = 10
        Me.txtUbicazioneDestinazione.Name = "txtUbicazioneDestinazione"
        Me.txtUbicazioneDestinazione.Size = New System.Drawing.Size(314, 40)
        Me.txtUbicazioneDestinazione.TabIndex = 179
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(588, 578)
        Me.lblUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(314, 38)
        Me.lblUbicazioneDestinazione.TabIndex = 181
        Me.lblUbicazioneDestinazione.Text = "Staging Destinaz."
        '
        'txtStaging
        '
        Me.txtStaging.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStaging.ForeColor = System.Drawing.Color.Black
        Me.txtStaging.Location = New System.Drawing.Point(5, 616)
        Me.txtStaging.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStaging.MaxLength = 10
        Me.txtStaging.Name = "txtStaging"
        Me.txtStaging.ReadOnly = True
        Me.txtStaging.Size = New System.Drawing.Size(380, 40)
        Me.txtStaging.TabIndex = 189
        '
        'lblStaging
        '
        Me.lblStaging.BackColor = System.Drawing.Color.Yellow
        Me.lblStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStaging.ForeColor = System.Drawing.Color.Black
        Me.lblStaging.Location = New System.Drawing.Point(6, 577)
        Me.lblStaging.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStaging.Name = "lblStaging"
        Me.lblStaging.Size = New System.Drawing.Size(379, 38)
        Me.lblStaging.TabIndex = 190
        Me.lblStaging.Text = "Staging Destinaz."
        Me.lblStaging.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDockDoor
        '
        Me.txtDockDoor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDockDoor.ForeColor = System.Drawing.Color.Black
        Me.txtDockDoor.Location = New System.Drawing.Point(391, 616)
        Me.txtDockDoor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDockDoor.MaxLength = 10
        Me.txtDockDoor.Name = "txtDockDoor"
        Me.txtDockDoor.ReadOnly = True
        Me.txtDockDoor.Size = New System.Drawing.Size(187, 40)
        Me.txtDockDoor.TabIndex = 187
        '
        'lblDockDoor
        '
        Me.lblDockDoor.BackColor = System.Drawing.Color.Yellow
        Me.lblDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDockDoor.ForeColor = System.Drawing.Color.Black
        Me.lblDockDoor.Location = New System.Drawing.Point(392, 577)
        Me.lblDockDoor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDockDoor.Name = "lblDockDoor"
        Me.lblDockDoor.Size = New System.Drawing.Size(187, 38)
        Me.lblDockDoor.TabIndex = 188
        Me.lblDockDoor.Text = "Dock Door"
        Me.lblDockDoor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(696, 661)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(100, 62)
        Me.cmdPreviousScreen.TabIndex = 191
        Me.cmdPreviousScreen.Text = "<"
        '
        'lblInfoUDSOnWork
        '
        Me.lblInfoUDSOnWork.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.lblInfoUDSOnWork.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDSOnWork.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDSOnWork.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDSOnWork.Location = New System.Drawing.Point(3, 30)
        Me.lblInfoUDSOnWork.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDSOnWork.Name = "lblInfoUDSOnWork"
        Me.lblInfoUDSOnWork.Size = New System.Drawing.Size(998, 28)
        Me.lblInfoUDSOnWork.TabIndex = 192
        Me.lblInfoUDSOnWork.Text = "UDS ATTIVO:"
        '
        'txtInfoPesoMissione
        '
        Me.txtInfoPesoMissione.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtInfoPesoMissione.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoPesoMissione.ForeColor = System.Drawing.Color.Black
        Me.txtInfoPesoMissione.Location = New System.Drawing.Point(113, 662)
        Me.txtInfoPesoMissione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoPesoMissione.Multiline = True
        Me.txtInfoPesoMissione.Name = "txtInfoPesoMissione"
        Me.txtInfoPesoMissione.ReadOnly = True
        Me.txtInfoPesoMissione.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoPesoMissione.Size = New System.Drawing.Size(467, 60)
        Me.txtInfoPesoMissione.TabIndex = 193
        Me.txtInfoPesoMissione.TabStop = False
        '
        'cmdJobFunctions
        '
        Me.cmdJobFunctions.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdJobFunctions.Location = New System.Drawing.Point(587, 661)
        Me.cmdJobFunctions.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdJobFunctions.Name = "cmdJobFunctions"
        Me.cmdJobFunctions.Size = New System.Drawing.Size(100, 62)
        Me.cmdJobFunctions.TabIndex = 208
        Me.cmdJobFunctions.Text = "Opzioni"
        '
        'frmPickingMerci_Code_DropUDS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.cmdJobFunctions)
        Me.Controls.Add(Me.txtInfoPesoMissione)
        Me.Controls.Add(Me.lblInfoUDSOnWork)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.txtStaging)
        Me.Controls.Add(Me.lblStaging)
        Me.Controls.Add(Me.txtDockDoor)
        Me.Controls.Add(Me.lblDockDoor)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazioneDestinazione)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.txtInfoJobSelezionato)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Code_DropUDS"
        Me.Text = "Picking Task (6)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
    Friend WithEvents txtInfoJobSelezionato As System.Windows.Forms.TextBox
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents DtGridListInfo As System.Windows.Forms.DataGrid
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtUbicazioneDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneDestinazione As System.Windows.Forms.Label
    Friend WithEvents txtStaging As System.Windows.Forms.TextBox
    Friend WithEvents lblStaging As System.Windows.Forms.Label
    Friend WithEvents txtDockDoor As System.Windows.Forms.TextBox
    Friend WithEvents lblDockDoor As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDSOnWork As System.Windows.Forms.Label
    Friend WithEvents txtInfoPesoMissione As System.Windows.Forms.TextBox
    Friend WithEvents cmdJobFunctions As System.Windows.Forms.Button
End Class
