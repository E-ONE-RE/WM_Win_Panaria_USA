<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPickingMerci_Fork_DropUDS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPickingMerci_Fork_DropUDS))
        Me.lblSystemInfo = New System.Windows.Forms.Label()
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
        Me.txtCurrentForkLift = New System.Windows.Forms.TextBox()
        Me.lblCurrentForkLift = New System.Windows.Forms.Label()
        Me.btnSelectForkLift = New System.Windows.Forms.PictureBox()
        Me.txtCurrentForkLiftUDS = New System.Windows.Forms.TextBox()
        Me.lblCurrentForkLiftUDS = New System.Windows.Forms.Label()
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdNextScreen.Location = New System.Drawing.Point(794, 662)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(208, 62)
        Me.cmdNextScreen.TabIndex = 124
        Me.cmdNextScreen.Text = "OK"
        '
        'DtGridListInfo
        '
        Me.DtGridListInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DtGridListInfo.DataMember = ""
        Me.DtGridListInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DtGridListInfo.Location = New System.Drawing.Point(3, 148)
        Me.DtGridListInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.DtGridListInfo.Name = "DtGridListInfo"
        Me.DtGridListInfo.ReadOnly = True
        Me.DtGridListInfo.Size = New System.Drawing.Size(1003, 422)
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
        Me.txtUbicazioneDestinazione.Location = New System.Drawing.Point(566, 616)
        Me.txtUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUbicazioneDestinazione.MaxLength = 10
        Me.txtUbicazioneDestinazione.Name = "txtUbicazioneDestinazione"
        Me.txtUbicazioneDestinazione.Size = New System.Drawing.Size(336, 40)
        Me.txtUbicazioneDestinazione.TabIndex = 179
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(566, 578)
        Me.lblUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(336, 38)
        Me.lblUbicazioneDestinazione.TabIndex = 181
        Me.lblUbicazioneDestinazione.Text = "Staging Destinaz."
        '
        'txtStaging
        '
        Me.txtStaging.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStaging.ForeColor = System.Drawing.Color.Black
        Me.txtStaging.Location = New System.Drawing.Point(9, 616)
        Me.txtStaging.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStaging.MaxLength = 10
        Me.txtStaging.Name = "txtStaging"
        Me.txtStaging.ReadOnly = True
        Me.txtStaging.Size = New System.Drawing.Size(263, 40)
        Me.txtStaging.TabIndex = 189
        '
        'lblStaging
        '
        Me.lblStaging.BackColor = System.Drawing.Color.Yellow
        Me.lblStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStaging.ForeColor = System.Drawing.Color.Black
        Me.lblStaging.Location = New System.Drawing.Point(10, 577)
        Me.lblStaging.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStaging.Name = "lblStaging"
        Me.lblStaging.Size = New System.Drawing.Size(262, 38)
        Me.lblStaging.TabIndex = 190
        Me.lblStaging.Text = "Staging Destinaz."
        Me.lblStaging.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDockDoor
        '
        Me.txtDockDoor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDockDoor.ForeColor = System.Drawing.Color.Black
        Me.txtDockDoor.Location = New System.Drawing.Point(292, 616)
        Me.txtDockDoor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDockDoor.MaxLength = 10
        Me.txtDockDoor.Name = "txtDockDoor"
        Me.txtDockDoor.ReadOnly = True
        Me.txtDockDoor.Size = New System.Drawing.Size(263, 40)
        Me.txtDockDoor.TabIndex = 187
        '
        'lblDockDoor
        '
        Me.lblDockDoor.BackColor = System.Drawing.Color.Yellow
        Me.lblDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDockDoor.ForeColor = System.Drawing.Color.Black
        Me.lblDockDoor.Location = New System.Drawing.Point(293, 577)
        Me.lblDockDoor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDockDoor.Name = "lblDockDoor"
        Me.lblDockDoor.Size = New System.Drawing.Size(263, 38)
        Me.lblDockDoor.TabIndex = 188
        Me.lblDockDoor.Text = "Dock Door"
        Me.lblDockDoor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCurrentForkLift
        '
        Me.txtCurrentForkLift.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentForkLift.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentForkLift.Location = New System.Drawing.Point(20, 90)
        Me.txtCurrentForkLift.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentForkLift.Name = "txtCurrentForkLift"
        Me.txtCurrentForkLift.Size = New System.Drawing.Size(584, 30)
        Me.txtCurrentForkLift.TabIndex = 210
        '
        'lblCurrentForkLift
        '
        Me.lblCurrentForkLift.BackColor = System.Drawing.Color.Yellow
        Me.lblCurrentForkLift.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentForkLift.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentForkLift.Location = New System.Drawing.Point(20, 59)
        Me.lblCurrentForkLift.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentForkLift.Name = "lblCurrentForkLift"
        Me.lblCurrentForkLift.Size = New System.Drawing.Size(584, 31)
        Me.lblCurrentForkLift.TabIndex = 211
        Me.lblCurrentForkLift.Text = "Carrello / Muletto"
        '
        'btnSelectForkLift
        '
        Me.btnSelectForkLift.Image = CType(resources.GetObject("btnSelectForkLift.Image"), System.Drawing.Image)
        Me.btnSelectForkLift.Location = New System.Drawing.Point(881, 42)
        Me.btnSelectForkLift.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectForkLift.Name = "btnSelectForkLift"
        Me.btnSelectForkLift.Size = New System.Drawing.Size(109, 91)
        Me.btnSelectForkLift.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnSelectForkLift.TabIndex = 209
        Me.btnSelectForkLift.TabStop = False
        Me.btnSelectForkLift.Tag = "SF00001"
        '
        'txtCurrentForkLiftUDS
        '
        Me.txtCurrentForkLiftUDS.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentForkLiftUDS.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentForkLiftUDS.Location = New System.Drawing.Point(612, 90)
        Me.txtCurrentForkLiftUDS.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCurrentForkLiftUDS.Name = "txtCurrentForkLiftUDS"
        Me.txtCurrentForkLiftUDS.Size = New System.Drawing.Size(261, 30)
        Me.txtCurrentForkLiftUDS.TabIndex = 212
        '
        'lblCurrentForkLiftUDS
        '
        Me.lblCurrentForkLiftUDS.BackColor = System.Drawing.Color.Yellow
        Me.lblCurrentForkLiftUDS.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentForkLiftUDS.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentForkLiftUDS.Location = New System.Drawing.Point(612, 59)
        Me.lblCurrentForkLiftUDS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentForkLiftUDS.Name = "lblCurrentForkLiftUDS"
        Me.lblCurrentForkLiftUDS.Size = New System.Drawing.Size(261, 31)
        Me.lblCurrentForkLiftUDS.TabIndex = 213
        Me.lblCurrentForkLiftUDS.Text = "UDS a bordo"
        '
        'frmPickingMerci_Fork_DropUDS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.txtCurrentForkLiftUDS)
        Me.Controls.Add(Me.lblCurrentForkLiftUDS)
        Me.Controls.Add(Me.txtCurrentForkLift)
        Me.Controls.Add(Me.lblCurrentForkLift)
        Me.Controls.Add(Me.btnSelectForkLift)
        Me.Controls.Add(Me.txtStaging)
        Me.Controls.Add(Me.lblStaging)
        Me.Controls.Add(Me.txtDockDoor)
        Me.Controls.Add(Me.lblDockDoor)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazioneDestinazione)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.DtGridListInfo)
        Me.Controls.Add(Me.lblSystemInfo)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPickingMerci_Fork_DropUDS"
        Me.Text = "Picking Task (6)"
        CType(Me.DtGridListInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSelectForkLift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemInfo As System.Windows.Forms.Label
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
    Friend WithEvents txtCurrentForkLift As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentForkLift As System.Windows.Forms.Label
    Friend WithEvents btnSelectForkLift As System.Windows.Forms.PictureBox
    Friend WithEvents txtCurrentForkLiftUDS As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentForkLiftUDS As System.Windows.Forms.Label
End Class
