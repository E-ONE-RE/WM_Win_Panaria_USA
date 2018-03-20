<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEM_FromStock_Part_1_UM
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
        Me.txtUM = New System.Windows.Forms.TextBox()
        Me.lblUnitaMagazzinoOrigine = New System.Windows.Forms.Label()
        Me.txtInfoUMSelezionata = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblInfoUDC = New System.Windows.Forms.Label()
        Me.cmdDeleteList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdNextScreen
        '
        Me.cmdNextScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdNextScreen.Location = New System.Drawing.Point(183, 217)
        Me.cmdNextScreen.Name = "cmdNextScreen"
        Me.cmdNextScreen.Size = New System.Drawing.Size(50, 60)
        Me.cmdNextScreen.TabIndex = 12
        Me.cmdNextScreen.Text = ">"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(4, 217)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(50, 60)
        Me.cmdAbortScreen.TabIndex = 11
        Me.cmdAbortScreen.Text = "Uscita"
        '
        'txtUM
        '
        Me.txtUM.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtUM.ForeColor = System.Drawing.Color.Black
        Me.txtUM.Location = New System.Drawing.Point(2, 186)
        Me.txtUM.MaxLength = 10
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(236, 30)
        Me.txtUM.TabIndex = 14
        '
        'lblUnitaMagazzinoOrigine
        '
        Me.lblUnitaMagazzinoOrigine.BackColor = System.Drawing.Color.Yellow
        Me.lblUnitaMagazzinoOrigine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitaMagazzinoOrigine.ForeColor = System.Drawing.Color.Black
        Me.lblUnitaMagazzinoOrigine.Location = New System.Drawing.Point(2, 158)
        Me.lblUnitaMagazzinoOrigine.Name = "lblUnitaMagazzinoOrigine"
        Me.lblUnitaMagazzinoOrigine.Size = New System.Drawing.Size(236, 28)
        Me.lblUnitaMagazzinoOrigine.TabIndex = 167
        Me.lblUnitaMagazzinoOrigine.Text = "Unita Magazzino"
        '
        'txtInfoUMSelezionata
        '
        Me.txtInfoUMSelezionata.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfoUMSelezionata.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfoUMSelezionata.ForeColor = System.Drawing.Color.Black
        Me.txtInfoUMSelezionata.Location = New System.Drawing.Point(1, 22)
        Me.txtInfoUMSelezionata.Multiline = True
        Me.txtInfoUMSelezionata.Name = "txtInfoUMSelezionata"
        Me.txtInfoUMSelezionata.ReadOnly = True
        Me.txtInfoUMSelezionata.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInfoUMSelezionata.Size = New System.Drawing.Size(237, 132)
        Me.txtInfoUMSelezionata.TabIndex = 165
        Me.txtInfoUMSelezionata.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdOK.Location = New System.Drawing.Point(124, 217)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(50, 60)
        Me.cmdOK.TabIndex = 166
        Me.cmdOK.Text = "OK"
        '
        'lblInfoUDC
        '
        Me.lblInfoUDC.BackColor = System.Drawing.Color.Yellow
        Me.lblInfoUDC.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblInfoUDC.ForeColor = System.Drawing.Color.Black
        Me.lblInfoUDC.Location = New System.Drawing.Point(2, 1)
        Me.lblInfoUDC.Name = "lblInfoUDC"
        Me.lblInfoUDC.Size = New System.Drawing.Size(236, 20)
        Me.lblInfoUDC.TabIndex = 168
        Me.lblInfoUDC.Text = "N° UDC/S: 0"
        '
        'cmdDeleteList
        '
        Me.cmdDeleteList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdDeleteList.Location = New System.Drawing.Point(63, 217)
        Me.cmdDeleteList.Name = "cmdDeleteList"
        Me.cmdDeleteList.Size = New System.Drawing.Size(50, 60)
        Me.cmdDeleteList.TabIndex = 169
        Me.cmdDeleteList.Text = "Delete List"
        '
        'frmEM_FromStock_Part_1_UM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(238, 285)
        Me.Controls.Add(Me.cmdDeleteList)
        Me.Controls.Add(Me.lblInfoUDC)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtInfoUMSelezionata)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.lblUnitaMagazzinoOrigine)
        Me.Controls.Add(Me.cmdNextScreen)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEM_FromStock_Part_1_UM"
        Me.Text = "EM - Prod. Mul. (1)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNextScreen As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents txtUM As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitaMagazzinoOrigine As System.Windows.Forms.Label
    Friend WithEvents txtInfoUMSelezionata As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblInfoUDC As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteList As System.Windows.Forms.Button
End Class
