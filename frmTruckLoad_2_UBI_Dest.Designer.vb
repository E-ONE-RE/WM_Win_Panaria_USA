<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTruckLoad_2_UBI_Dest
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
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmdPreviousScreen = New System.Windows.Forms.Button()
        Me.cmdNextScreen = New System.Windows.Forms.Button()
        Me.cmdSelectUbicazione = New System.Windows.Forms.Button()
        Me.txtUbicazioneDestinazione = New System.Windows.Forms.TextBox()
        Me.lblUbicazioneDestinazione = New System.Windows.Forms.Label()
        Me.txtInfoOperazioneUtente = New System.Windows.Forms.TextBox()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.txtStaging = New System.Windows.Forms.TextBox()
        Me.lblStaging = New System.Windows.Forms.Label()
        Me.txtDockDoor = New System.Windows.Forms.TextBox()
        Me.lblDockDoor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(14, 631)
        Me.cmdAbortScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdAbortScreen.TabIndex = 85
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmdPreviousScreen
        '
        Me.cmdPreviousScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdPreviousScreen.Location = New System.Drawing.Point(491, 631)
        Me.cmdPreviousScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdPreviousScreen.Name = "cmdPreviousScreen"
        Me.cmdPreviousScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdPreviousScreen.TabIndex = 84
        Me.cmdPreviousScreen.Text = "<"
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(773, 631)
        Me.cmdNextScreen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(220, 80)
        Me.cmdNextScreen.TabIndex = 83
        Me.cmdNextScreen.Text = "OK"
        '
        'cmdSelectUbicazione
        '
        Me.cmdSelectUbicazione.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdSelectUbicazione.Location = New System.Drawing.Point(902, 525)
        Me.cmdSelectUbicazione.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdSelectUbicazione.Name = "cmdSelectUbicazione"
        Me.cmdSelectUbicazione.Size = New System.Drawing.Size(92, 82)
        Me.cmdSelectUbicazione.TabIndex = 162
        Me.cmdSelectUbicazione.Text = "..."
        '
        'txtUbicazioneDestinazione
        '
        Me.txtUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.txtUbicazioneDestinazione.Location = New System.Drawing.Point(592, 567)
        Me.txtUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUbicazioneDestinazione.MaxLength = 10
        Me.txtUbicazioneDestinazione.Name = "txtUbicazioneDestinazione"
        Me.txtUbicazioneDestinazione.Size = New System.Drawing.Size(302, 40)
        Me.txtUbicazioneDestinazione.TabIndex = 161
        '
        'lblUbicazioneDestinazione
        '
        Me.lblUbicazioneDestinazione.BackColor = System.Drawing.Color.Yellow
        Me.lblUbicazioneDestinazione.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicazioneDestinazione.ForeColor = System.Drawing.Color.Black
        Me.lblUbicazioneDestinazione.Location = New System.Drawing.Point(593, 525)
        Me.lblUbicazioneDestinazione.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUbicazioneDestinazione.Name = "lblUbicazioneDestinazione"
        Me.lblUbicazioneDestinazione.Size = New System.Drawing.Size(301, 38)
        Me.lblUbicazioneDestinazione.TabIndex = 178
        Me.lblUbicazioneDestinazione.Text = "Dook Door"
        '
        'txtInfoOperazioneUtente
        '
        Me.txtInfoOperazioneUtente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoOperazioneUtente.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoOperazioneUtente.ForeColor = System.Drawing.Color.Black
        Me.txtInfoOperazioneUtente.Location = New System.Drawing.Point(1, 32)
        Me.txtInfoOperazioneUtente.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfoOperazioneUtente.Multiline = True
        Me.txtInfoOperazioneUtente.Name = "txtInfoOperazioneUtente"
        Me.txtInfoOperazioneUtente.ReadOnly = True
        Me.txtInfoOperazioneUtente.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoOperazioneUtente.Size = New System.Drawing.Size(994, 485)
        Me.txtInfoOperazioneUtente.TabIndex = 177
        Me.txtInfoOperazioneUtente.TabStop = False
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(1, 1)
        Me.lblInfoUDC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(992, 27)
        Me.lblInfoUDC.TabIndex = 0
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'txtStaging
        '
        Me.txtStaging.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStaging.ForeColor = System.Drawing.Color.Black
        Me.txtStaging.Location = New System.Drawing.Point(14, 573)
        Me.txtStaging.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStaging.MaxLength = 10
        Me.txtStaging.Name = "txtStaging"
        Me.txtStaging.ReadOnly = True
        Me.txtStaging.Size = New System.Drawing.Size(248, 40)
        Me.txtStaging.TabIndex = 185
        '
        'lblStaging
        '
        Me.lblStaging.BackColor = System.Drawing.Color.Yellow
        Me.lblStaging.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStaging.ForeColor = System.Drawing.Color.Black
        Me.lblStaging.Location = New System.Drawing.Point(15, 525)
        Me.lblStaging.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStaging.Name = "lblStaging"
        Me.lblStaging.Size = New System.Drawing.Size(247, 38)
        Me.lblStaging.TabIndex = 186
        Me.lblStaging.Text = "Staging Destinaz."
        Me.lblStaging.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDockDoor
        '
        Me.txtDockDoor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDockDoor.ForeColor = System.Drawing.Color.Black
        Me.txtDockDoor.Location = New System.Drawing.Point(302, 573)
        Me.txtDockDoor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDockDoor.MaxLength = 10
        Me.txtDockDoor.Name = "txtDockDoor"
        Me.txtDockDoor.ReadOnly = True
        Me.txtDockDoor.Size = New System.Drawing.Size(248, 40)
        Me.txtDockDoor.TabIndex = 183
        '
        'lblDockDoor
        '
        Me.lblDockDoor.BackColor = System.Drawing.Color.Yellow
        Me.lblDockDoor.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDockDoor.ForeColor = System.Drawing.Color.Black
        Me.lblDockDoor.Location = New System.Drawing.Point(303, 525)
        Me.lblDockDoor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDockDoor.Name = "lblDockDoor"
        Me.lblDockDoor.Size = New System.Drawing.Size(248, 38)
        Me.lblDockDoor.TabIndex = 184
        Me.lblDockDoor.Text = "Dock Door"
        Me.lblDockDoor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmTruckLoad_2_UBI_Dest
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1006, 723)
        Me.Controls.Add(Me.txtStaging)
        Me.Controls.Add(Me.lblStaging)
        Me.Controls.Add(Me.txtDockDoor)
        Me.Controls.Add(Me.lblDockDoor)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.txtInfoOperazioneUtente)
        Me.Controls.Add(Me.cmdSelectUbicazione)
        Me.Controls.Add(Me.txtUbicazioneDestinazione)
        Me.Controls.Add(Me.lblUbicazioneDestinazione)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.cmdPreviousScreen)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTruckLoad_2_UBI_Dest"
        Me.Text = "Carico Camion (2)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmdPreviousScreen As System.Windows.Forms.Button
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdSelectUbicazione As System.Windows.Forms.Button
    Friend WithEvents txtUbicazioneDestinazione As System.Windows.Forms.TextBox
    Friend WithEvents lblUbicazioneDestinazione As System.Windows.Forms.Label
    Friend WithEvents txtInfoOperazioneUtente As System.Windows.Forms.TextBox
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents txtStaging As System.Windows.Forms.TextBox
    Friend WithEvents lblStaging As System.Windows.Forms.Label
    Friend WithEvents txtDockDoor As System.Windows.Forms.TextBox
    Friend WithEvents lblDockDoor As System.Windows.Forms.Label
End Class
