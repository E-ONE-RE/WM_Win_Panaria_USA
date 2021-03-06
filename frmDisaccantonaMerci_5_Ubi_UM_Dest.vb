﻿Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsWmsJob
Imports clsSapUtility

Public Class frmDisaccantonaMerci_5_Ubi_UM_Dest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmDisaccantonaMerci_5_Ubi_UM_Dest"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmDisaccantonaMerci_5_Ubi_UM_Dest_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
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

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, Nothing, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmDisaccantonaMerci_5_Ubi_UM_Dest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneDestinazione.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
                    If (Me.txtCodiceUM.Text = "") Then
                        Me.txtCodiceUM.Focus()
                        Exit Sub
                    Else
                        Call Me.cmdNextScreen_Click(Me, e)
                        Exit Sub
                    End If
                End If
            End If

            If ((Me.txtCodiceUM.Focused = True) And (Me.txtCodiceUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.F4)) Then
                'SU F4 SIMULO MATCH CODE DI SAP
                Call Me.cmdSelectUbicazioneDest_Click(Me, e)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmDisaccantonaMerci_5_Ubi_UM_Dest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(74, lblUbicazioneDestinazione.Text, "Ubicazione Dest.")
            'lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(172, lblCodiceUM.Text, "UM Destinazione")
            lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1736, lblCodiceUM.Text, "pallet ID")


            Me.Text = clsAppTranslation.GetSingleParameterValue(251, Me.Text, "Disaccant.(5)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************  


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(2, False)

            RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                If (clsUtility.IsStringValid(WorkSapWmGiacenza.UbicazioneInfo.Ubicazione, True) = True) Then
                    Me.txtUbicazioneDestinazione.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                Else
                    Me.txtUbicazioneDestinazione.Text = WorkSapWmGiacenza.OdaInputDestInfo.UbicazioneInfo.Ubicazione
                End If
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtCodiceUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim OT_Executed_Ok As Boolean = False
        Dim CheckExecutionOk As Boolean = False
        Dim CheckUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim CheckUMInUbicazioneOk As Boolean = False
        Dim wkCheckUmInUbicazione As clsDataType.SapWmGiacenza
        Dim InfoGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenze() As clsDataType.SapWmGiacenza
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim FlagErroreAttivo As Boolean = False
        Dim wkJobsOkForExecution As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim UnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(402, "", "Ubicazione Destinazione inserita non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Me.txtCodiceUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(403, "", "Unità Magazzino inserita non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
            Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneDestinazione.Text, CheckUbicazioneOk, True, WorkOutUbicazione)
            If (CheckUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneDestinazione.Text = WorkOutUbicazione


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtCodiceUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsSapUtility.ResetGiacenzaStruct(wkCheckUmInUbicazione)
            wkCheckUmInUbicazione.UbicazioneInfo.Ubicazione = Me.txtUbicazioneDestinazione.Text
            wkCheckUmInUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
            wkCheckUmInUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            wkCheckUmInUbicazione.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_WITH_LGPLA(wkCheckUmInUbicazione, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, CheckUbicazioneOk, CheckUnitaMagazzinoOk, CheckUMInUbicazioneOk, InfoGiacenze, InfoUbicazione, SapFunctionError, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1630, "", "Errore in esecuzione verifica UBICAZIONE e UNITA MAG.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (CheckExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(404, "", "Errore in verifica UBICAZIONE e UNITA MAG.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (CheckUbicazioneOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            'ATTENZIONE! L'UNITA MAGAZZINO PUO' ESSERE NUOVA. SE E' GIA PRESENTE DEVE ESSERE NELLA STESSA UBICAZIONE
            If (CheckUnitaMagazzinoOk = True) And (CheckUMInUbicazioneOk = False) Then
                If (InfoGiacenze.Length <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(405, "", "Dati giacenza Unita Mag. errati.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                InfoGiacenza = InfoGiacenze(0)
                ErrDescription = clsAppTranslation.GetSingleParameterValue(406, "", "L'Unita Magazzino è nell'UBICAZIONE:") & InfoGiacenza.UbicazioneInfo.Ubicazione & clsAppTranslation.GetSingleParameterValue(407, "", " che è diversa da quella specificata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI DISACCANTONARE NELLA ZONA DI PRONTO (IL DISACCANTONATO DEVE RITORNARE IN MAGAZZINO)
            If (clsUser.SapWmsUser.PROFID = "") And (InfoGiacenze(0).UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(408, "", "ATTENZIONE!Scelta una ubicazione del mag. Pronto. DIV:") & InfoGiacenze(0).UbicazioneInfo.Divisione & clsAppTranslation.GetSingleParameterValue(409, "", " TIP.MAG:") & InfoGiacenze(0).UbicazioneInfo.TipoMagazzino
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ErrDescription = clsAppTranslation.GetSingleParameterValue(410, "", "Il materiale DISACCANTONATO deve essere riportato in MAGAZZINO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(411, "", "Verificare l'ubicazione di DESTINAZIONE e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO I DATI ESSENZIALI PER LE DESTINAZIONE
            clsWmsJob.MaterialeSelStockGiacenzaDest = InfoGiacenze(0)
            clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Ubicazione = Me.txtUbicazioneDestinazione.Text
            clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.TipoMagazzino = InfoUbicazione.TipoMagazzino
            If (CheckUnitaMagazzinoOk = False) Then
                'UNITA DI MAGAZZINO NUOVA DEVO IMPOSTARE DEI DATI FISSI
                clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
                clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
            End If
            RetCode = clsWmsJob.SetJobPickMaterialGiacenzaDest()
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(390, "", "Errore in impostazione dati DESTINAZIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> ESEGUO AZIONE PREVISTA DAL JOB ( PICKING IN QUESTO CASO)
            RetCode = clsSapWS.Call_ZWS_JOB_STEPS_EXECUTED(clsWmsJob.WmsJob, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore, clsWmsJob.FlagForcedStepEnded, "", clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, clsWmsJob.WmOtInfo, RetInfoSapWmWmsJob, SapFunctionError, True)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                FlagErroreAttivo = True
                ErrDescription = clsAppTranslation.GetSingleParameterValue(391, "", "Errore in esecuzione Operazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            Else
                '>>> TUTTO OK
                ErrDescription = clsAppTranslation.GetSingleParameterValue(392, "", "Operazione eseguita con successo.") & vbCrLf
                Dim MaxArrayIndex As Long
                Dim IndexFor As Long
                MaxArrayIndex = UBound(clsWmsJob.WmOtInfo)
                For IndexFor = 0 To MaxArrayIndex
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(393, "", " OT NUM:") & clsWmsJob.WmOtInfo(IndexFor).NumeroOrdineDiTrasferimento & vbCrLf
                Next
            End If

            If (FlagErroreAttivo = True) Then
                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE ( SOLO IN CASO DI ERRORE )
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
            End If

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmDisaccantonaMerci_5_Ubi_UM_DestForm = New frmDisaccantonaMerci_5_Ubi_UM_Dest
                    frmDisaccantonaMerci_5_Ubi_UM_DestForm.Show()
                    frmDisaccantonaMerci_5_Ubi_UM_DestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '*************************************************************************************
            'VERIFICO SE IL JOB NON E' TERMINATO, CHIEDO DI PROSEGUIRE CON UN ALTRO PICKING
            '*************************************************************************************
            If (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) Then

                'ESEGUO REFRESH DATI DEL JOB CORRENTE
                RetCode = clsWmsJob.GetJobSingleDisaccantonamento(clsWmsJob.WmsJob.NrWmsJobs, True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'CASO DI ERRORE => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)
                    Exit Sub
                End If

                'VERIFICO SE IL JOB E' OK PER UNA NUOVA ESECUZIONE
                wkJobsOkForExecution = clsWmsJob.IsJobsOkForExecution(True)
                If (wkJobsOkForExecution = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(399, "", "Missione non OK per esecuziome. MIS:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Else
                    'RIMANGO NELLA STESSA RIGA DI MISSIONE E RIGENERO LA LOGICA PER TROVARE UNA NUOVA ORIGINE/DESTINAZIONE
                    '>>> VERIFICO LE CONDIZIONI OK PER POTERE ESEGUIRE IL PICKING DI UN JOB
                    RetCode = clsWmsJob.JobsActivateExecution("", False, True)
                    If (RetCode <> 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        'CASO DI ERRORE PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                        Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                        Exit Sub
                    End If
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                End If
            End If

            'CASO IN CUI SONO PARTITO CON IMMISSIONE DEL [JOBSGROUP]
            If (clsWmsJob.DisaccantonamentoSourceType = clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeJobsGroup) Then
                'SE NON HO UN RECORDSET VALIDO PARTO DALLA PRIMA VIDEATA ( DICHIARAZIONE 
                If (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                    '>>> RIPARTO RISPECIFICANDO IL PROSSIMO [JOBSGROUP]
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                End If
                If (clsWmsJob.objDataTableWmsJobsList.Rows.Count > 1) Then
                    'IN QUESTO CASO HO PIU' RIGHE E PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                Else
                    '>>> RIPARTO RISPECIFICANDO IL PROSSIMO [JOBSGROUP]
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                End If
            ElseIf (clsWmsJob.DisaccantonamentoSourceType = clsWmsJob.Disaccantonamento_SourceType.Disaccantonamento_SourceTypeManualSelection) Then
                'SE NON HO UN RECORDSET VALIDO PARTO DALLA PRIMA VIDEATA ( DICHIARAZIONE 
                If (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                    '>>> RIPARTO RISPECIFICANDO IL PROSSIMO [JOBSGROUP]
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                End If
                If (clsWmsJob.objDataTableWmsJobsList.Rows.Count > 1) Then
                    'IN QUESTO CASO HO PIU' RIGHE E PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, clsWmsJob.DisaccantonamentoSourceType, True)
                    Exit Sub
                Else
                    '>>> RIPARTO RISPECIFICANDO IL PROSSIMO [JOBSGROUP]
                    Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, clsWmsJob.DisaccantonamentoSourceType, True)
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
    Public Function ConfermaSelezioneLocazione(ByVal inUbicazioneSelezionata As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneLocazione = 1 'init at error

            Me.Focus()
            If (inUbicazioneSelezionata <> "") Then
                Me.txtUbicazioneDestinazione.Text = inUbicazioneSelezionata
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneLocazione = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdSelectUbicazioneDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazioneDest.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CREO IL DATASET DEI DIVERSI STOCK PRELEVABILI
            RetCode = clsSapUtility.FromSapWmGiacenzaArrayToDataRow(clsWmsJob.MaterialePickDestinations, clsWmsJob.objDataTableGiacenzeDestInfo)

            frmPickingMerci_Appr_SelStockDestinazioneForm = New frmPickingMerci_Appr_SelStockDestinazione
            frmPickingMerci_Appr_SelStockDestinazioneForm.SourceForm = Me
            frmPickingMerci_Appr_SelStockDestinazioneForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class