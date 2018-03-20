Imports clsSapWS
Imports clsSapUtility
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmEM_FromJob_Part_5_FinalUMConfirm
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_5_FinalUMConfirm"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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

            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)

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

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJob_Part_5_FinalUMConfirm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim outUbicConfermata As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtUMDestConfermata.Focused = True) And (Me.txtUMDestConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
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

    Private Sub frmEM_FromJob_Part_5_FinalUMConfirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************


            '**************************************
            'Traduzioni
            Me.lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(75, lblUM_Destinazione.Text, "UM.Dest.")
            Me.Text = clsAppTranslation.GetSingleParameterValue(76, Me.Text, "EM - Bem (5)") '74
            '**************************************

            'INIT CONTROLLI DI DATA ENTRY
            Me.txtUMDestConfermata.Text = ""

            '*********************************************************************************************************
            '>>> SE LA LOGICA MI HA TROVATO UNA UBICAZIONE VALIDA LA PROPONGO

            'RECUPERO L'INFORMAZIONE DELL'UNITA DI MAGAZZINO DA PROPORRE
            RetCode = clsEMFromJob.GetEntrataMerceUnitaMagDaConfermare(Me.txtUMDestConfermata.Text)


            Me.txtUMDestConfermata.Enabled = True
            Me.txtUMDestConfermata.BackColor = Color.White
            Me.lblUM_Destinazione.BackColor = Color.Yellow


            'VISUALIZZO LE INFORMAZIONI DEI DATI ASSOCIATI ALL'ENTRATA MERCE
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPutAwayInfoForUserString(2)

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'AGGIORNO IL NUMERO DI UDC PROCESSATE E QUELLE DA PROCESSARE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsWmsJob.GetUdcProcessedInfoForUser()

            Me.txtUMDestConfermata.Focus()

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
        Dim JobStepExecuted_Ok As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim OT_Executed_Number As String = ""
        Dim UserAnswer As DialogResult
        Dim ShowDescrizioneCreaUbica As String = ""
        Dim RetStepExecutedInfo() As clsDataType.SapWmRetStepExecuted
        Dim FlagErroreAttivo As Boolean = False
        Dim wkExitFormDone As Boolean = False
        Dim UnitaMagazzinoOk As Boolean = False
        Dim EntrataMerceDaOdp As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim UM_DifferentMaterialCode As Boolean = False
        Dim UM_DifferentMaterialBatch As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************



            Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
            Me.txtUMDestConfermata.Text = Trim(Me.txtUMDestConfermata.Text)

            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUMDestConfermata.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If



            '**************************************************************************************************
            '**************************************************************************************************

            'SE LA DESTINAZIONE E' UN MAGAZZINO CON GESTIONE DELLE UM
            If (clsWmsJob.WmsJob.UbicazioneDestinazione.AbilitaUnitaMagazzino = True) Then
                'IN QUESTO CASO DEVO RICHIEDERE LA LETTURA DI UN BARCODE DELLA CESTA
                If (Me.txtUMDestConfermata.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(457, "", "Unità Magazzino Destinazione non corretta.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
                'VERIFICO SE L'UNITA' DI MAGAZZINO E' CORRETTA ????
                clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino = Me.txtUMDestConfermata.Text
            Else
                clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino = ""
            End If


            '****************************************************************************************************************************

            If (clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat) Or (clsEMFromJob.EM_SourceType = clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup) Then

                'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
                RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
                DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUMDestConfermata.Text
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUbicazione, False, False, False, True, False, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale, clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita, clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, UM_DifferentMaterialCode, UM_DifferentMaterialBatch, Nothing, SapFunctionError, False)
                If (UM_DifferentMaterialCode = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1210, "", "L'UNITA MAG. di DESTINAZIONE contiene un MATERIALE diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Me.txtUMDestConfermata.Text = ""
                    Exit Sub
                End If
                If (UM_DifferentMaterialBatch = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1210, "", "L'UNITA MAG. di DESTINAZIONE contiene una PARTITA diversa.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Me.txtUMDestConfermata.Text = ""
                    Exit Sub
                End If
                '>>> SE E' GIA ESISTENTE LA PALETTA CON STESSO MATERIALE E PARTITA LO SEGNALO ALL'OPERATORE
                If (CheckUnitaMagazzinoOk = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(703, "", "UNITA MAG. di DESTINAZIONE già definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Me.txtUMDestConfermata.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            '****************************************************************************************************************************


            '****************************************************************************************************************************
            '****************************************************************************************************************************
            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'ORDINE DI TRASFERIMENTO PER L'ENTRATA MERCE (TIPICAMENTE DA 90X => A MAGAZZINO)
            '****************************************************************************************************************************
            '****************************************************************************************************************************
            ReDim clsWmsJob.MaterialeGiacenzeConfirmed(0)
            clsWmsJob.MaterialeGiacenzeConfirmed(0).QuantitaConfermataOperatore = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE IN UDM CONSEGNA
            clsWmsJob.MaterialeGiacenzeConfirmed(0).UnitaDiMisuraAcquisizione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione           'UDM
            clsWmsJob.MaterialeGiacenzeConfirmed(0).QuantitaConfermataSfusiOperatore = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore  'QUANTITA DA TRASFERIRE IN UDM PEZZI ( PER CONFERMA SFUSI )

            clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.UbicazioneOrigine.NumeroMagazzino
            clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.Divisione = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
            clsWmsJob.MaterialeGiacenzeConfirmed(0).CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            clsWmsJob.MaterialeGiacenzeConfirmed(0).Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            clsWmsJob.MaterialeGiacenzeConfirmed(0).TipoStock = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock
            clsWmsJob.MaterialeGiacenzeConfirmed(0).CdStockSpeciale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CdStockSpeciale
            clsWmsJob.MaterialeGiacenzeConfirmed(0).NumeroStockSpeciale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.TipoMagazzino = clsWmsJob.WmsJob.UbicazioneOrigine.TipoMagazzino
            clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.Ubicazione = clsWmsJob.WmsJob.UbicazioneOrigine.Ubicazione
            clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.UnitaMagazzino = clsWmsJob.WmsJob.UbicazioneOrigine.UnitaMagazzino

            '>>> IMPOSTO IL RIFERIMENTO AL MAGAZZINO LOGICO
            clsWmsJob.MaterialeGiacenzeConfirmed(0).MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.TipoUnitaMagazzino, True) = True) Then
                clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.TipoUnitaMagazzino = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoUnitaMagazzino
            Else
                clsWmsJob.MaterialeGiacenzeConfirmed(0).UbicazioneInfo.TipoUnitaMagazzino = Default_TipoUnitaMagazzino
            End If


            'SE E'UN FLUSSO DI ENTRATA MERCE DA ODP SETTO IL FLAG SPECIFICO
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.NumeroOrdineDiProduzione, True) = True) Then
                EntrataMerceDaOdp = True
            Else
                EntrataMerceDaOdp = False
            End If

            'IMPOSTO I DATI ANCHE DELLA GIACENZA DI DESTINAZIONE
            clsWmsJob.WmsJob.MaterialeGiacenzaDestinazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine
            clsWmsJob.WmsJob.MaterialeGiacenzaDestinazione.UbicazioneInfo = clsWmsJob.WmsJob.UbicazioneDestinazione

            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

            '*******************************************************************************************
            '>>> ESEGUO OPERAZIONE PREVISTA DELLA MISSIONE
            '*******************************************************************************************
            ErrDescription = ""
            '>>> CASO PALETTE MULTIPLE ( ESEGUO UN OT PER OGNI PALETTA PRESENTE)
            FlagErroreAttivo = False 'INIT
            RetCode = clsSapWS.Call_ZWS_JOB_EM_STEPS_EXECUTED(clsWmsJob.WmsJob, clsWmsJob.MaterialeGiacenzeConfirmed, False, False, "", clsUser.SapWmsUser.LANGUAGE, JobStepExecuted_Ok, RetStepExecutedInfo, RetInfoSapWmWmsJob, SapFunctionError, False)
            If (RetCode <> 0) Then
                FlagErroreAttivo = True '>>> CONDIZIONE DI ERRORE => SETTO IL FLAG
                ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(458, "", "Attenzione!Errore in ENTRATA MERCE UM:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino) & vbCrLf
                ErrDescription = ErrDescription & SapFunctionError.ERROR_DESCRIPTION
            Else
                '>>> TUTTO OK
                ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(459, "", "Entrata Merce (UM:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino) & clsAppTranslation.GetSingleParameterValue(460, "", " ) eseguita con successo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(461, "", "OT NUM:") & OT_Executed_Number & vbCrLf
                If (clsUtility.IsStringValid(ShowDescrizioneCreaUbica, True) = True) Then
                    ErrDescription = ErrDescription & vbCrLf & ShowDescrizioneCreaUbica
                End If
            End If
            '************************************************************************************************
            '************************************************************************************************




            '************************************************************************************************
            ' >>> SE ABILITATO VISUALIZZO RISULTATO OPERAZIONE
            '************************************************************************************************
            If (EntrataMerceAbilitaMsgConfermaSuccesso = True) Or (RetCode <> 0) Then
                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
            End If


            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmEM_FromJob_Part_5_FinalUMConfirmForm = New frmEM_FromJob_Part_5_FinalUMConfirm
                    frmEM_FromJob_Part_5_FinalUMConfirmForm.Show()
                    frmEM_FromJob_Part_5_FinalUMConfirmForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA OPERAZIONE DELLA STESSA RIGA MISSIONE
            '*************************************************************************************************
            wkExitFormDone = False
            If (FlagErroreAttivo = False) And (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) And (RetInfoSapWmWmsJob.CurrentStep = clsWmsJob.WmsJob.CurrentStep) Then
                RetCode = clsWmsJob.ReloadDataOfSameJobForNewPick(Me, wkExitFormDone, False)
                If (wkExitFormDone = True) Then
                    Exit Sub
                End If
                'PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
                Exit Sub
            End If


            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)

                'PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
                Exit Sub
            End If

            'ESCO DALLA BEM => TORNO AL MENU DI ENTRATA MERCI
            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub txtUMDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUMDestConfermata.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtUMDestConfermata.Text <> "" Then
                Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Aggiorno i campi quantità per la crezione della nuova etichetta UDC
            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDisponibile = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
            'clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDisponibile = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore

            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraBase = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione


            'IMPOSTANDO COME FILTRO PRINCIPALE L'UNITA DI MAGAZZINO
            RetCode = clsSapWS.Call_ZWMS_EXEC_PRINT_PALLET_UDC(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine, GetDataOk, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then

                'CASO DI ERRORE STAMPA
                ErrDescription = clsAppTranslation.GetSingleParameterValue(555, "", "Nessun dato trovato.Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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


End Class
