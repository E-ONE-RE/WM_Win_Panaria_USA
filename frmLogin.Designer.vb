<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblUserId = New System.Windows.Forms.Label()
        Me.PictureBackground = New System.Windows.Forms.PictureBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblWait = New System.Windows.Forms.Label()
        Me.actExecLogin = New System.Windows.Forms.Button()
        Me.cmdAbortScreen = New System.Windows.Forms.Button()
        Me.cmbLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        CType(Me.PictureBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUserId
        '
        Me.txtUserId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserId.Location = New System.Drawing.Point(14, 33)
        Me.txtUserId.MaxLength = 12
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(224, 30)
        Me.txtUserId.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(12, 92)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(226, 30)
        Me.txtPassword.TabIndex = 1
        '
        'lblUserId
        '
        Me.lblUserId.BackColor = System.Drawing.Color.Transparent
        Me.lblUserId.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserId.ForeColor = System.Drawing.Color.Black
        Me.lblUserId.Location = New System.Drawing.Point(14, 13)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(111, 19)
        Me.lblUserId.TabIndex = 20
        Me.lblUserId.Text = "UserId"
        '
        'PictureBackground
        '
        Me.PictureBackground.Image = CType(resources.GetObject("PictureBackground.Image"), System.Drawing.Image)
        Me.PictureBackground.Location = New System.Drawing.Point(0, 0)
        Me.PictureBackground.Name = "PictureBackground"
        Me.PictureBackground.Size = New System.Drawing.Size(253, 332)
        Me.PictureBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBackground.TabIndex = 21
        Me.PictureBackground.TabStop = False
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(13, 70)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(111, 21)
        Me.lblPassword.TabIndex = 19
        Me.lblPassword.Text = "Password"
        '
        'lblWait
        '
        Me.lblWait.BackColor = System.Drawing.Color.Transparent
        Me.lblWait.ForeColor = System.Drawing.Color.Black
        Me.lblWait.Location = New System.Drawing.Point(14, 298)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(224, 23)
        Me.lblWait.TabIndex = 18
        Me.lblWait.Text = "Attendere..."
        Me.lblWait.Visible = False
        '
        'actExecLogin
        '
        Me.actExecLogin.Location = New System.Drawing.Point(138, 229)
        Me.actExecLogin.Name = "actExecLogin"
        Me.actExecLogin.Size = New System.Drawing.Size(100, 60)
        Me.actExecLogin.TabIndex = 7
        Me.actExecLogin.Text = "OK"
        '
        'cmdAbortScreen
        '
        Me.cmdAbortScreen.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmdAbortScreen.Location = New System.Drawing.Point(12, 229)
        Me.cmdAbortScreen.Name = "cmdAbortScreen"
        Me.cmdAbortScreen.Size = New System.Drawing.Size(100, 60)
        Me.cmdAbortScreen.TabIndex = 12
        Me.cmdAbortScreen.Text = "Annulla"
        '
        'cmbLanguage
        '
        Me.cmbLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLanguage.Location = New System.Drawing.Point(12, 170)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(226, 33)
        Me.cmbLanguage.TabIndex = 17
        '
        'lblLanguage
        '
        Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
        Me.lblLanguage.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLanguage.ForeColor = System.Drawing.Color.Black
        Me.lblLanguage.Location = New System.Drawing.Point(12, 148)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(111, 21)
        Me.lblLanguage.TabIndex = 0
        Me.lblLanguage.Text = "Language"
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(250, 332)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.cmbLanguage)
        Me.Controls.Add(Me.cmdAbortScreen)
        Me.Controls.Add(Me.actExecLogin)
        Me.Controls.Add(Me.lblWait)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserId)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.PictureBackground)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.Text = "User Login"
        CType(Me.PictureBackground, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents PictureBackground As System.Windows.Forms.PictureBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblWait As System.Windows.Forms.Label
    Friend WithEvents actExecLogin As System.Windows.Forms.Button
    Friend WithEvents cmdAbortScreen As System.Windows.Forms.Button
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
End Class
