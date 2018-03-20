Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms

Public Class frmPickingMerci_Code_DropUDS

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_DropUDS"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza

    Private wkStart_time_read As Date
    Private wkEnd_time_read As Date

    Public Shared SourceForm As Form

    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_DropUDS_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub frmPickingMerci_Code_DropUDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneDestinazione.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Call cmdNextScreen_Click(Me, e)
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

    Private Sub frmPickingMerci_Code_DropUDS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim outCheckOk As Boolean = False
        Dim WorkStrategyLocation As String = ""
        '****************************1**********
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.Text = clsAppTranslation.GetSingleParameterValue(1288, Me.Text, "Picking Appr. (6)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
            Me.txtInfoPesoMissione.Text = clsWmsJob.ShowJobWeightInfoForUserString(0)


#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
            Me.cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdSelectUbicazione.Text, "...")
            Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, Me.cmdPreviousScreen.Text, "<")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, Me.cmdNextScreen.Text, ">")
            Me.lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(1319, Me.lblUbicazioneDestinazione.Text, "Staging Destinaz.")
            Me.lblStaging.Text = clsAppTranslation.GetSingleParameterValue(1624, Me.lblStaging.Text, "Staging Proposta")
#Else
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
            Me.cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdSelectUbicazione.Text, "...")
			Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, Me.cmdPreviousScreen.Text, "<")
			Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, Me.cmdNextScreen.Text, ">")
#End If
            '**************************************
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(1, True)


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            '>>> VERIFICO SE HO UNA DESTINAZIONE PARTICOLARE ( CASO PICKING IN AREA HR )
            If (clsWmsJob.FlagOutDestFoundAreaPD = True) And (clsUtility.IsStringValid(clsWmsJob.UbicazionePDPickingCodeDestinatione.Ubicazione, True) = True) Then
                WorkStrategyLocation = clsWmsJob.UbicazionePDPickingCodeDestinatione.TipoMagazzino + "-" + clsWmsJob.UbicazionePDPickingCodeDestinatione.Ubicazione
            End If

            If (clsUtility.IsStringValid(WorkStrategyLocation, True) = True) Then
                Me.txtStaging.Text = "(" & WorkStrategyLocation & ") " & clsWmsJob.WmsJob.UbicazioneStaging.TipoMagazzino + " - " + clsWmsJob.WmsJob.UbicazioneStaging.Ubicazione
            Else
                Me.txtStaging.Text = clsWmsJob.WmsJob.UbicazioneStaging.TipoMagazzino + " - " + clsWmsJob.WmsJob.UbicazioneStaging.Ubicazione
            End If
            Me.txtDockDoor.Text = clsWmsJob.WmsJob.UbicazioneDoor.TipoMagazzino + " - " + clsWmsJob.WmsJob.UbicazioneDoor.Ubicazione

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUbicazioneDestinazione.Focus()


            RetCode = clsSapWS.Call_ZWMS_GET_JOBS_UDS_MATNR_OF_UDS(clsUDS.UnitaMagazzino, clsUser.SapWmsUser.LANGUAGE, outCheckOk, clsUDS.objDataTableUDSInfo, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1610, "", "Errore informazioni UDS.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            If Not (clsUDS.objDataTableUDSInfo Is Nothing) Then
                clsUDS.objDataTableUDSInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsUDS.objDataTableUDSInfo
            End If

            clsUDS.RefreshDateTableUDSInfo()

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub
    Private Sub cmdAbortScreen_Click(sender As Object, e As EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPreviousScreen_Click(sender As Object, e As EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsWmsJob.FlagConfirmDone = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1617, "", "Attenzione! Occorre eseguire DROP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdNextScreen_Click(sender As Object, e As EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim InfoGiacenze() As clsDataType.SapWmGiacenza
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim UserAnswer As DialogResult
        Dim MoveUdsSuccess As Boolean = False
        Dim OT_Executed_Ok As Boolean = False
        Dim OT_Executed_Number() As String
        Dim RetCodeFinal As Long = 0
        Dim NumeroUdcTotaliUbicazione As Long = 0
        Dim IntroMessage As String
        Dim UdsToMove() As clsDataType.SapUDSInfo
        Dim FlagTaskLinesOnWorkIsFinish As Boolean = False
        Dim FlagAllTaskLinesAreFinish As Boolean = False
        Dim SetTaskLinesOk As Boolean = False
        Dim FlagStepTypeStartSeq As Boolean = False
        Dim FlagStartStrategy As Boolean = False
        Dim FlagStartNewJobs As Boolean = False
        Dim FlagAllJobsQueueAreFinished As Boolean = False

        Dim instring As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            '* INIZIO  print DEBUG
            wkStart_time_read = Now


            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)

            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneDestinazione.Text = WorkOutUbicazione


            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE, VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsUtility.ClearArray(clsMoveUDS.GiacenzeUbiDestinazione)
            RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapWS.Call_ZWM_CHECK_DROP_UBICAZIONE(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, InfoGiacenze, Nothing, SapFunctionError, False)
            If (InfoUbicazione.FlagLocationDoor = True) Then
                'L'UBICAZIONE DI DESTINAZIONE NON PUO' ESSERE UNA DOCK DOOR ( USABILE SOLO NEL CARICO CAMION )
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1527, "", "L'Ubicazione di Destinazione e' una DOOR e non e' corretta per il DROP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUbicazioneDestinazione.Text = ""
                Exit Sub
            End If
            If (ChekUbicazioneOk <> True) Then
                '>>> CASO DI UBICAZIONE NON DEFINITA ( ERRORE DATA ENTRY OPERATORE )
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '********************************************************************************
            'L'UBICAZIONE DI  DESTINAZIONE DEVE ESSERE DIVERSA DA QUELLA DI ORIGINE
            '********************************************************************************
            If (InfoUbicazione.NumeroMagazzino = clsWmsJob.UDSOnWork.UDSInfo.NumeroMagazzino And _
                    InfoUbicazione.TipoMagazzino = clsWmsJob.UDSOnWork.UDSInfo.TipoMagazzino And _
                        InfoUbicazione.Ubicazione = clsWmsJob.UDSOnWork.UDSInfo.Ubicazione) Then

                ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '***************************************************************************************
            'SE L'UBICAZIONE E' UNA STAGING DOOR ALLORA DEVE ESSERE QUELLA PREVISTA
            '***************************************************************************************
            If (InfoUbicazione.FlagLocationStagingDoor = True) Then
                If (InfoUbicazione.NumeroMagazzino <> clsWmsJob.WmsJob.UbicazioneStaging.NumeroMagazzino Or InfoUbicazione.TipoMagazzino <> clsWmsJob.WmsJob.UbicazioneStaging.TipoMagazzino Or InfoUbicazione.Ubicazione <> clsWmsJob.WmsJob.UbicazioneStaging.Ubicazione) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1528, "", "Ubicazione di STAGING selezionata diversa da quella prevista.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'SETTO UBICAZIONE DI DESTINAZIONE
            clsWmsJob.DestinationUbicazione = InfoUbicazione

            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""
            RetCodeFinal = 0

            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

            'ESEGUO IL DROP DELL'UDS IN SAP
            ReDim UdsToMove(0)
            UdsToMove(0) = clsWmsJob.UDSOnWork.UDSInfo
            If (clsUtility.IsStringValid(UdsToMove(0).UnitaMagazzino, True) = False) Then
                UdsToMove(0).UnitaMagazzino = clsWmsJob.UDSOnWork.UnitaMagazzino
            End If

            RetCode = clsSapWS.Call_ZWMS_JOB_UDS_DROP(clsForkLift.CurrentForLift, UdsToMove, clsWmsJob.DestinationUbicazione, clsUser.SapWmsUser.LANGUAGE, clsWmsJob.UDSOnWork.objDataTableUDSInfo, OT_Executed_Number, OT_Executed_Ok, MoveUdsSuccess, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription += clsAppTranslation.GetSingleParameterValue(1518, "", "Attenzione! Errore nel DROP della UDS:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.UDSOnWork.GetUnitaMagazzinoUDS()) & vbCrLf
            Else
                clsWmsJob.FlagConfirmDone = False   'RESETTO FLAG DI CONFERMA ESEGUITA 
                RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.UbicazionePDPickingCodeDestinatione) 'RESET EVENTUALE UBICAZIONE PD
                RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.UbicazioneUltimoPickingCodeOrigine) 'RESET ULTIMA UBICAZIONE DI PICKING PER ELABORAZIONE PD

                '>>> TUTTO OK
                ErrDescription += clsAppTranslation.GetSingleParameterValue(1519, "", "DROP UDS:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.UDSOnWork.GetUnitaMagazzinoUDS()) & vbCrLf & clsAppTranslation.GetSingleParameterValue(1226, "", "Eseguito con successo.") & vbCrLf

                'VISUALIZZO LOG ERRORI OT ESEGUITO
                Dim MaxArrayIndex As Long
                Dim IndexFor As Long
                If (Not OT_Executed_Number Is Nothing) Then
                    If (OT_Executed_Number.Length > 0) Then
                        MaxArrayIndex = UBound(OT_Executed_Number)
                        For IndexFor = 0 To MaxArrayIndex
                            ErrDescription += clsAppTranslation.GetSingleParameterValue(1247, "", " OT:") & OT_Executed_Number(IndexFor) & vbCrLf
                        Next
                    End If
                End If

            End If

            'AGGIORNO CONTATORE Errori
            RetCodeFinal += RetCode

            If (RetCodeFinal = 0) Then
                'PALETTE TOTALI PRESENTI IN UBICAZIONE DI DESTINAZIONE
                NumeroUdcTotaliUbicazione = UdsToMove.GetLength(0) + clsWmsJob.DestinationUbicazione.NumeroUdcInUbicazione
                'CASO TUTO OK
                IntroMessage = clsAppTranslation.GetSingleParameterValue(1520, "", "Eguito Drop N° UDC:") & Trim(Str(UdsToMove.GetLength(0)))
                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE ( SOLO SE HO AVUTO UN ERRORE )
            If (RetCodeFinal <> 0) Then
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(IntroMessage & vbCrLf & ErrDescription)
            End If

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCodeFinal <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmPickingMerci_Code_DropUDSForm = New frmPickingMerci_Code_DropUDS
                    frmPickingMerci_Code_DropUDSForm.Show()
                    frmPickingMerci_Code_DropUDSForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '**************************************************************************************************
            'PULISCO LA UDS APPENA DROPPATA
            '**************************************************************************************************
            RetCode = clsWmsJob.UDSOnWork.ClearAllData()
            RetCode = clsForkLift.ClearUDSInfoAfterDrop() '>>> PULISCO INFO FORKLIFT A BORDO

            '**************************************************************************************************
            'FACCIO UN CONTROLLO SE IL TASK CORRENTE E' TERMINATO
            '**************************************************************************************************
            If (clsWmsJob.WmsJob.IdWmsJobStatus <> clsWmsJob.cstIdJobStatus_Terminato) Then
                RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesOnWorkIsFinish(FlagTaskLinesOnWorkIsFinish, False)
                If (FlagTaskLinesOnWorkIsFinish = True) Then
                    'VERIFICO SE IL JOB  PREVEDE ALTRE TASK LINES
                    RetCode = clsWmsJob.TaskLines.CheckIfAllTaskLinesAreFinish(clsWmsJob.WmsJob.NrWmsJobs, FlagAllTaskLinesAreFinish, False)
                    If (FlagAllTaskLinesAreFinish = False) Then
                        '>>> IMPOSTO LA NUOVA  TASK LINES SUCCESSIVA DA FARE
                        RetCode = clsWmsJob.TaskLines.SetCurrentTaskLinesOnWork(clsWmsJob.WmsJob.NrWmsJobs, SetTaskLinesOk)
                        FlagStepTypeStartSeq = True
                        FlagStartStrategy = True
                    Else
                        'VERIFICO SE TUTTI I JOB ATTIVI SONO TERMINATI
                        RetCode = clsWmsJob.CheckIfAllJobsQueueAreFinished(FlagAllJobsQueueAreFinished, False)
                        '>>> PASSO  AL JOB SUCCESSIVO
                        FlagStartNewJobs = True
                    End If
                Else
                    '>>> CONTINUO LA TASK LINES CORRENTE
                    FlagStepTypeStartSeq = True
                    FlagStartStrategy = True
                End If
            Else
                'IN QUESTO CASO IL JOB E' TERMINATO PER CUI DEVO RIPARTIRE DALL'ELENCO DELLE MISSIONI PER INIZIARNE UNA NUOVA
                FlagStartNewJobs = True
            End If


            'VERIFICO SE DEVO RIESEGUIRE LA STRATEGIA PER RILEVARE IL POSTO MIGLIORE PER IL PICKING
            If (FlagStartStrategy = True) Then
                '*********************************************************************************************************************
                'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
                '*********************************************************************************************************************
                RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'Exit Sub
                End If
            End If

            'CASO IN CUI ESEGUO ALTRO PICKING PER STESSO TASK/JOB ( STESSO  MATERIALE )
            If (FlagStepTypeStartSeq = True) Then
                'RIPARTO IMPOSTANDO IL NUOVO UDS
                Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartNewUDS, True)

                '* FINE  print DEBUG
                wkEnd_time_read = Now

                instring += "NrWmsJobs : " + clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NrWmsJobs.ToString + " "
                instring += "Utente : " + clsUser.SapWmsUser.USERID + " "
                instring += "Fine - Elab. : " + ((wkEnd_time_read - wkStart_time_read).TotalSeconds).ToString + " secs"

                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)

                Exit Sub
            End If

            If (FlagStartNewJobs = True) Then
                'RIPARTO DALLA LISTA DELLE MISSIONI ( SE RIMASTO UN JOB )
                Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)

                '* FINE  print DEBUG
                wkEnd_time_read = Now

                instring += "NrWmsJobs : " + clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NrWmsJobs.ToString + " "
                instring += "Utente : " + clsUser.SapWmsUser.USERID + " "
                instring += "Fine - Elab. : " + ((wkEnd_time_read - wkStart_time_read).TotalSeconds).ToString + " secs"

                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)

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

    Private Sub cmdJobFunctions_Click(sender As Object, e As EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            frmPickingMerci_Code_FunzioniForm = New frmPickingMerci_Code_Funzioni
            frmPickingMerci_Code_FunzioniForm.SourceForm = Me
            frmPickingMerci_Code_FunzioniForm.Show()
            RetCode = clsNavigation.CloseSourceForm(Me, False)

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
            If (Me.DtGridListInfo.TableStyles.Count = 0) Then


                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità di Magazzino"), True, DefDtGridCol_UnitaMagazzino - 10, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "LETYP", clsAppTranslation.GetSingleParameterValue(80, "", "Tipo Magazzino"), True, DefDtGridCol_TipoMagazzino + 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prel."), True, DefDtGridCol_QtaPrelevata - 70, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 80, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZWMS_PESOMAT_USA", clsAppTranslation.GetSingleParameterValue(1504, "", "Peso Materiale"), True, DefDtGridCol_QtaDaPrelevare, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "GEWEI_USA", clsAppTranslation.GetSingleParameterValue(868, "", "Unità di peso USA"), True, DefDtGridCol_UnitaDiMisura, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "USERID_RF_CREA", clsAppTranslation.GetSingleParameterValue(367, "", "Utente"), True, DefDtGridCol_CarrelistaProposto + 50, True)


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


End Class