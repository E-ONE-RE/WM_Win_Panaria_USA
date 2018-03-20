
Imports clsBusinessLogic
Imports clsUserGrants

Public Class frmLogin

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmLogin"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmLogin_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Static OneShot As Boolean
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.PictureBackground.Width = Me.Width
            Me.PictureBackground.Height = Me.Height

            If (Debugger.IsAttached = True) And (SkipLogin = True) And (OneShot = False) Then
                OneShot = True
                'LO FACCIO SOLO LA PRIMA VOLTA
                Call actExecLogin_Click(sender, e)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub frmLogin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUserId.Focused = True) And (Me.txtUserId.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI OK
                    Call Me.actExecLogin_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtPassword.Focused = True) And (Me.txtPassword.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI OK
                    Call Me.actExecLogin_Click(Me, e)
                    Exit Sub
                End If
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim i As Integer
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            actExecLogin.Text = clsAppTranslation.GetSingleParameterValue(8, actExecLogin.Text, "OK")

            '**************************************  




            If (EnableFormResizeControls = True) Then
                Me.Left = (PrimaryScreenWidth - Me.Width) / 2 ' AS Your Wish
                Me.Top = (PrimaryScreenHeight - Me.Height) / 2 ' AS Your Wish
            End If


            'Gestione combobox Lingua
            Me.cmbLanguage.Items.Add("")

            For i = 0 To 4
                If UserLanguageAvailable(i) <> "" Then
                    cmbLanguage.Items.Add(UserLanguageAvailable(i))
                End If
            Next

            If (Debugger.IsAttached = True) Then
                Me.txtUserId.Text = "PALTRY"
                Me.txtPassword.Text = ""
            Else
                'IMPOSTO 'EN' COME LINGUA  DI DEFAULT
                Me.cmbLanguage.Text = DefaultStartupLanguage
            End If
            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub actExecLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actExecLogin.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim strErrorDescr As String = ""
        Dim strSuccess As String = ""
        Dim strLog As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUserId.Text = "") Then
                'MsgBox(clsAppTranslation.GetSingleParameterValue(627, "", "Attenzione! Inserire uno UserId valido"), MsgBoxStyle.Exclamation, AppMsgBoxTitle)
                '>>> ATTENZIONE! LA TRADUZIONE NON E' ANCORA CARICATA PER CUI OCCORRE USARE DIRETTAMENTE LA LIGUA DI DEFAULT ( INGLESE )
                MsgBox("Attention! Insert a valid UserId", MsgBoxStyle.Exclamation, AppMsgBoxTitle)
                Exit Sub
            End If

            Me.txtUserId.Text = UCase(Me.txtUserId.Text)

            Me.lblWait.Visible = True

            RetCode = clsSapWS.Call_ZWS_MB_RF_LOGIN(Me.txtUserId.Text, Me.txtPassword.Text, strErrorDescr, clsUser.SapWmsUser, clsUserGrants.objSapProfOper, strSuccess, True)

            Me.lblWait.Visible = False

            If (strSuccess <> "Y") Then
                'MsgBox("Attenzione! Passowrd o UserId non valide.", MsgBoxStyle.Exclamation, AppMsgBoxTitle)
                Exit Sub
            End If

            'INIT DATI USER
            RetCode = clsUser.InitUserData()

            strLog = "Avvio Applicazione. UserId:" & Me.txtUserId.Text & "  Password:" & Me.txtPassword.Text
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "actExecLogin_Click", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, strLog, Nothing)

            'IMPOSTO LA LINGUA USATA IN QUESTO LOGIN DALL'UTENTE
            If (clsUtility.IsStringValid(Me.cmbLanguage.Text, True) = True) Then
                clsUser.SapWmsUser.LANGUAGE = Me.cmbLanguage.Text.Substring(0, 1)
            End If

            'SE L'UTENTE NON HA UNA LINGUA ASSOCIATA GLI FORZO LA LINGUA DI DEFAULT
            If (clsUtility.IsStringValid(clsUser.SapWmsUser.LANGUAGE, True) = False) Then
                clsUser.SapWmsUser.LANGUAGE = DefaultSapUserLanguage
            End If



            ' >>> RI-ESEGUO CHIAMATA WEB SERVICES PER AGGIORNARE LINGUAGGIO APPLICAZIONE
            RetCode = clsAppTranslation.GetApplicationParameters(SapFunctionError)

            ' >>> RECUPERO LE BAIE DI SPUNTA DELLO STABILIMENTO
            RetCode = clsSapWS.Call_ZWS_GET_UBI_SPUNTA(clsUser.SapWmsUser.LGNUM, clsUser.SapWmsUser.LANGUAGE, Nothing, clsSelezioneUbicazioneSpunta.objDataTableUbiSpunta, SapFunctionError, False)

            '>>> ESEGUO CREAZIONE DEI DATATABLE CON TRADUZIONE DEL CAMPO PROPRIETA DI DETTAGLIO (DA FARE DOPO LOGIN)
            RetCode = objMainApplication.CreateDateTableDetailsForAllObjects()

#If APPLICAZIONE_WIN32 = "SI" Then
            '>>> IMPOSTO LA CONNESSIONE PER IL SAP CONNECTOR
            clsSAPNetConn.SAPRfcDestination = clsSAPNetConn.GetValidSAPRfcDestination()
#End If


#If Not APPLICAZIONE_WIN32 = "SI" Then

            If Not frmMainHomeMenuForm Is Nothing Then
                frmMainHomeMenuForm.Dispose()
            End If
            frmMainHomeMenuForm = New frmMainHomeMenu

            Me.Visible = False
            frmMainHomeMenuForm.ShowDialog()

#Else

            If Not frmMainHomeMenuWinForm Is Nothing Then
                frmMainHomeMenuWinForm.Dispose()
            End If
            frmMainHomeMenuWinForm = New frmMainHomeMenuWin

            Me.Visible = False
            frmMainHomeMenuWinForm.ShowDialog()

#End If

            Me.Close()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            Me.lblWait.Visible = False
        End Try

    End Sub


    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.Close()
            Application.Exit() '>>>> TERMINO PROGRAMMA

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class