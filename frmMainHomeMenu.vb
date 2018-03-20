
Imports System.Math
Imports clsSapWS
Imports clsNavigation

Public Class frmMainHomeMenuWin
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMainHomeMenuWin"

    Private SkipCloseApplication As Boolean = False
    Private ClosingApplication As Boolean = False
    Private ErrDescription As String
    Private Shared MemoLastSysIdWarning As Date
    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Public ExecRefreshForm As Boolean = False
    Public LastTimeRefreshAction As Date

    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim retCode As Long = 0
        Dim CheckOk As Boolean = False

        retCode = clsSapWS.Call_ZWS_MB_CHECK_CONNECTION("", "", "", "", CheckOk)
        If (retCode = 0) And (CheckOk = True) Then
            MessageBox.Show(clsAppTranslation.GetSingleParameterValue(628, "", "Check Connessione Ok"))
        Else
            MessageBox.Show(clsAppTranslation.GetSingleParameterValue(629, "", "Check Connessione ERRORE!!!"))
        End If

    End Sub

    Private Sub frmMainHomeMenu_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'se sto già chiudendo l'applicazione non eseguo nessun controllo
            If (ClosingApplication = True) Then Exit Sub

            'chiamo chiusura applicazione con conferma dell'operatore
            Call actExitApplication_Click(sender, e)
            If (SkipCloseApplication = True) Then
                'l'operatore ha detto di NO alla CHIUSURA
                e.Cancel = True
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMainHomeMenu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D1)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.NumPad1)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnEntrataMerci_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D2)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnUscitaMerci_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D3)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnTrasferimentoMerci_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D4)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnUtilita_Click(Me, e)
                Exit Sub
            End If
            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.D9)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnVisualizzaInfo_Click(Me, e)
                Exit Sub
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Sub RefreshForm()
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim TimeInterval As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtConfigurationInfo.Text = "USER: " & clsUser.SapWmsUser.USERID & vbCrLf & "DIV: " & clsUser.GetUserDivisionToUse() & vbCrLf & "MAG: " & clsUser.UsersProfLgtyp.LGTYP & vbCrLf & "FORK: " & clsUser.SapWmsUser.ZID_WMS_FORKLIFT & vbCrLf & "TASK: " & clsUser.SapWmsUser.ZPICK_QUEUE_DESC

            If (LastTimeRefreshAction = Date.MinValue) Then
                'ExecRefreshForm = True
            Else
                TimeInterval = DateDiff(DateInterval.Second, LastTimeRefreshAction, Now)
                TimeInterval = Math.Abs(TimeInterval)
                If (TimeInterval >= 300) Then
                    'ExecRefreshForm = True
                End If
            End If

            'REFRESH DELLA VIDEATA PRINCIPALE
            RefreshMonitorInfo()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMainHomeMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim OkWarningMessage As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.btnEntrataMerci.Text = clsAppTranslation.GetSingleParameterValue(9, btnEntrataMerci.Text, "1 - Entrata Merci")
            Me.btnUscitaMerci.Text = clsAppTranslation.GetSingleParameterValue(10, btnUscitaMerci.Text, "2 - Uscita/picking Merci")
            Me.btnTrasferimentoMerci.Text = clsAppTranslation.GetSingleParameterValue(11, btnTrasferimentoMerci.Text, "3 - Trasferimento Merci")
            Me.btnUtilita.Text = clsAppTranslation.GetSingleParameterValue(1173, btnUtilita.Text, "4 - Menu Utilità")
            Me.btnVisualizzaInfo.Text = clsAppTranslation.GetSingleParameterValue(14, btnVisualizzaInfo.Text, "5 - Visualliza Info")
            Me.DtGridMonitorQueue.CaptionText = clsAppTranslation.GetSingleParameterValue(1408, Me.DtGridMonitorQueue.CaptionText, "Lista Code")
            Me.DtGridMonitorTask.CaptionText = clsAppTranslation.GetSingleParameterValue(1409, Me.DtGridMonitorTask.CaptionText, "Lista Task")
            '**************************************


            Me.Text = ApplMainFormTitle & " [" & SapSystemInfo.SystInfo_Rec.Sysid & "]"

            If (SapSystemInfo.SystInfo_Rec.Sysid <> DefaultSapSISID_Produzione) Then
                If (MemoLastSysIdWarning = Date.MinValue) Then
                    OkWarningMessage = True
                Else
                    If (DateDiff("m", Now, MemoLastSysIdWarning) > 10) Then
                        OkWarningMessage = True
                    End If
                End If
                If (OkWarningMessage = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(630, "", "ATTENZIONE! Non si è collegati al sistema di PRODUZIONE:") & DefaultSapSISID_Produzione
                    ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(631, "", "Verificata connessione al sistema:") & SapSystemInfo.SystInfo_Rec.Sysid & vbCrLf & "Host:" & WsHostName & vbCrLf & "Client:" & SapClient
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    MemoLastSysIdWarning = Now
                End If
            End If

            '>>> VISUALIZZO RIFERIMENTI UTENTE E CONFIGURAZIONE
            ExecRefreshForm = True
            Me.RefreshForm()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'ESEGUO IL REFRESH DELLE GRIGLIE DI MONITOR
            RefreshMonitorInfo()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnTrasferimentoMerci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasferimentoMerci.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnTrasferimentoMerci.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub actExitApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actExitApplication.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As MsgBoxResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SkipCloseApplication = False 'init

            If (objMainApplication Is Nothing) Then Exit Sub

            UserAnswer = MsgBox(clsAppTranslation.GetSingleParameterValue(632, "", "Si desidera veramente uscire dal programma ?"), MsgBoxStyle.YesNo, AppMsgBoxTitle)
            If (UserAnswer <> MsgBoxResult.Yes) Then
                SkipCloseApplication = True
                Exit Sub
            End If

            '>>> SE ARRIVO QUI HO CONFERMATO USCITA
            ClosingApplication = True 'setto FLAG DI CHIUSURA APPLICAZIONE IN CORSO

            UserAnswer = MsgBox(clsAppTranslation.GetSingleParameterValue(633, "", "Si desidera eseguire un nuovo LOGIN ?"), MsgBoxStyle.YesNo, AppMsgBoxTitle)
            If (UserAnswer = MsgBoxResult.Yes) Then
                'chiudo le finestre
                If (Not frmMainHomeMenuForm Is Nothing) Then
                    frmMainHomeMenuForm.Close()
                End If
                objMainApplication.StartThreadForms()
                ClosingApplication = False
                SkipCloseApplication = False
                Exit Sub
            End If

            '>>> SE ARRIVO QUI DEVO USCIRE DAL PROGRAMMA
            ClosingApplication = True 'setto FLAG DI CHIUSURA APPLICAZIONE IN CORSO

            'FACCIO RICHIESTA DI CHIUDERE L'APPLICAZIONE
            RetCode += objMainApplication.StopApplication(False)

            objMainApplication = Nothing

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub
    Private Sub btnEntrataMerci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrataMerci.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnEntrataMerci.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnVisualizzaInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizzaInfo.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnVisualizzaInfo.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnUscitaMerci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUscitaMerci.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '??? NELLO STEP INZIALE NON SI GESTISCE L'USCITA MERCI
            'ErrDescription = clsAppTranslation.GetSingleParameterValue(636, "", "Attenzione! Funzione Disabilitata.")
            'MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'Exit Sub

            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnUscitaMerci.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnSelectForkLift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectForkLift.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectForkLift.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Select_ForkLift(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub btnUtilita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUtilita.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnUtilita.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Mnu_Main_Utilita(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnSelectTipiMag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTipiMag.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectTipiMag.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_SelectUserTipiMag(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub SAPRfcTestConn_Click(sender As Object, e As EventArgs)

        Dim clsSAP As New clsSAPNetConn

        clsSAP.SAPRfcTestConnection()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CHIAMO WEB SERVICE ANAGRAFICA CARRELLISTI
            RetCode = clsSapWS.Call_ZWS_GET_FORKLIFT(clsUser.SapWmsUser.LGNUM, clsUser.SapWmsUser.WERKS, "", "", "", False, clsForkLift.objDataTableForkLift, clsForkLift.objDataTableForkLiftWH, SapFunctionError, False)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnSelectUserPickQueue_Click(sender As Object, e As EventArgs) Handles btnSelectUserPickQueue.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'SELEZIONA CODA UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectUserPickQueue.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Select_UserPickQueue(Me, True, False, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub RefreshMonitorInfo()
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'ESEGUO IL REFRESH SOLO SE ABILITATO IL FLAG
            If (ExecRefreshForm = False) Then
                Exit Sub
            End If

            'CHIAMO WEB SERVICE 
            RetCode = clsSapWS.Call_ZWS_GET_MONITOR_JOBS(clsUser.SapWmsUser.LANGUAGE, clsUser.SapWmsUser.ZPICK_QUEUE_DESC, True, False, clsMonitor.objDataTableMonitorJobs, SapFunctionError, False)

            If Not (clsMonitor.objDataTableMonitorJobs Is Nothing) Then
                clsMonitor.objDataTableMonitorJobs.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridMonitorTask.DataSource = clsMonitor.objDataTableMonitorJobs
            End If


            RetCode = clsSapWS.Call_ZWS_GET_MONITOR_QUEUES(clsUser.SapWmsUser.LANGUAGE, clsUser.SapWmsUser.ZPICK_QUEUE_DESC, True, False, clsMonitor.objDataTableMonitorQueues, SapFunctionError, False)

            If Not (clsMonitor.objDataTableMonitorQueues Is Nothing) Then
                clsMonitor.objDataTableMonitorQueues.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridMonitorQueue.DataSource = clsMonitor.objDataTableMonitorQueues
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'RESETTO IL FLAG DEL REFRESH
            ExecRefreshForm = False
            LastTimeRefreshAction = Now

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridMonitorQueue.TableStyles.Count = 0) Then

#If Not APPLICAZIONE_WIN32 <> "SI" Then

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZID_PICK_QUEUE", clsAppTranslation.GetSingleParameterValue(1239, "", "Id"), True, 20, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZPICK_QUEUE_DESC", clsAppTranslation.GetSingleParameterValue(1240, "", "Descrizione Coda"), True, DefDtGridCol_TipoMagazzino + 130, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZStatus", clsAppTranslation.GetSingleParameterValue(1293, "", "Status"), True, 20, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZOPEN_ST_NUM", clsAppTranslation.GetSingleParameterValue(1294, "", "Open Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZOPEN_ST_PER", clsAppTranslation.GetSingleParameterValue(1295, "", "Open %"), DefDtGridCol_Show_ZOPEN_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZOPEN_ST_KG", clsAppTranslation.GetSingleParameterValue(1296, "", "Open Kg."), DefDtGridCol_Show_ZOPEN_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZOPEN_ST_LB", clsAppTranslation.GetSingleParameterValue(1297, "", "Open Lb."), DefDtGridCol_Show_ZOPEN_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZPICKED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1298, "", "Picked Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZPICKED_ST_PER", clsAppTranslation.GetSingleParameterValue(1299, "", "Picked %"), DefDtGridCol_Show_ZPICKED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZPICKED_ST_KG", clsAppTranslation.GetSingleParameterValue(1300, "", "Picked Kg."), DefDtGridCol_Show_ZPICKED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZPICKED_ST_LB", clsAppTranslation.GetSingleParameterValue(1301, "", "Picked Lb."), DefDtGridCol_Show_ZPICKED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZSTAGED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1302, "", "Staged Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZSTAGED_ST_PER", clsAppTranslation.GetSingleParameterValue(1303, "", "Staged %"), DefDtGridCol_Show_ZSTAGED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZSTAGED_ST_KG", clsAppTranslation.GetSingleParameterValue(1304, "", "Staged Kg."), DefDtGridCol_Show_ZSTAGED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZSTAGED_ST_LB", clsAppTranslation.GetSingleParameterValue(1305, "", "Staged Lb."), DefDtGridCol_Show_ZSTAGED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZLOADED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1306, "", "Loaded Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZLOADED_ST_PER", clsAppTranslation.GetSingleParameterValue(1307, "", "Loaded %"), DefDtGridCol_Show_ZLOADED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZLOADED_ST_KG", clsAppTranslation.GetSingleParameterValue(1308, "", "Loaded Kg."), DefDtGridCol_Show_ZLOADED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZLOADED_ST_LB", clsAppTranslation.GetSingleParameterValue(1309, "", "Loaded Lb."), DefDtGridCol_Show_ZLOADED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZTOTAL_WMSLINES", clsAppTranslation.GetSingleParameterValue(1310, "", "Num.Linee"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZTOTAL_WMS_KG", clsAppTranslation.GetSingleParameterValue(1311, "", "Tot.Kg."), DefDtGridCol_Show_ZTOTAL_WMS_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorQueue, "", "ZTOTAL_WMS_LB", clsAppTranslation.GetSingleParameterValue(1312, "", "Tot.Lb."), True, 50, True)


#End If
            End If


            'creo la formattazione solo la prima volta
            If (Me.DtGridMonitorTask.TableStyles.Count = 0) Then

#If Not APPLICAZIONE_WIN32 <> "SI" Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZID_JOBS_TYPE", clsAppTranslation.GetSingleParameterValue(1239, "", "Id"), True, DefDtGridCol_NumeroMagazzino + 30, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZDESCR_JOBS_TYPE", clsAppTranslation.GetSingleParameterValue(1240, "", "Descrizione Coda"), True, DefDtGridCol_TipoMagazzino + 230, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZOPEN_ST_NUM", clsAppTranslation.GetSingleParameterValue(1294, "", "Open Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZOPEN_ST_PER", clsAppTranslation.GetSingleParameterValue(1295, "", "Open %"), DefDtGridCol_Show_ZOPEN_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZOPEN_ST_KG", clsAppTranslation.GetSingleParameterValue(1296, "", "Open Kg."), DefDtGridCol_Show_ZOPEN_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZOPEN_ST_LB", clsAppTranslation.GetSingleParameterValue(1297, "", "Open Lb."), DefDtGridCol_Show_ZOPEN_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZPICKED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1298, "", "Picked Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZPICKED_ST_PER", clsAppTranslation.GetSingleParameterValue(1299, "", "Picked %"), DefDtGridCol_Show_ZPICKED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZPICKED_ST_KG", clsAppTranslation.GetSingleParameterValue(1300, "", "Picked Kg."), DefDtGridCol_Show_ZPICKED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZPICKED_ST_LB", clsAppTranslation.GetSingleParameterValue(1301, "", "Picked Lb."), DefDtGridCol_Show_ZPICKED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZSTAGED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1302, "", "Staged Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZSTAGED_ST_PER", clsAppTranslation.GetSingleParameterValue(1303, "", "Staged %"), DefDtGridCol_Show_ZSTAGED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZSTAGED_ST_KG", clsAppTranslation.GetSingleParameterValue(1304, "", "Staged Kg."), DefDtGridCol_Show_ZSTAGED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZSTAGED_ST_LB", clsAppTranslation.GetSingleParameterValue(1305, "", "Staged Lb."), DefDtGridCol_Show_ZSTAGED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZLOADED_ST_NUM", clsAppTranslation.GetSingleParameterValue(1306, "", "Loaded Nr."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZLOADED_ST_PER", clsAppTranslation.GetSingleParameterValue(1307, "", "Loaded %"), DefDtGridCol_Show_ZLOADED_ST_PER, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZLOADED_ST_KG", clsAppTranslation.GetSingleParameterValue(1308, "", "Loaded Kg."), DefDtGridCol_Show_ZLOADED_ST_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZLOADED_ST_LB", clsAppTranslation.GetSingleParameterValue(1309, "", "Loaded Lb."), DefDtGridCol_Show_ZLOADED_ST_LB, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZTOTAL_WMSLINES", clsAppTranslation.GetSingleParameterValue(1310, "", "Num.Linee"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZTOTAL_WMS_KG", clsAppTranslation.GetSingleParameterValue(1311, "", "Tot.Kg."), DefDtGridCol_Show_ZTOTAL_WMS_KG, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridMonitorTask, "", "ZTOTAL_WMS_LB", clsAppTranslation.GetSingleParameterValue(1312, "", "Tot.Lb."), True, 50, True)


#End If
            End If

            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Private Sub btnRefreshMonitors_Click(sender As Object, e As EventArgs) Handles btnRefreshMonitors.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecRefreshForm = True
            RefreshMonitorInfo()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub


End Class