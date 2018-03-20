Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsWmsJob
Imports clsSapUtility


Public Class frmPickingMerci_Appr_8_Rietichettatura
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_8_Rietichettatura"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_8_Rietichettatura_KeyPress(Me, e)

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

            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)
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

    Private Sub frmPickingMerci_Appr_8_Rietichettatura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM_Origine.Focused = True) And (Me.txtUM_Origine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Origine.Text = UCase(Me.txtUM_Origine.Text)
                    If (Me.txtUM_Destinazione.Text = "") Then
                        Me.txtUM_Destinazione.Focus()
                        Exit Sub
                    Else
                        Call Me.cmdNextScreen_Click(Me, e)
                        Exit Sub
                    End If
                End If
            End If

            If ((Me.txtUM_Destinazione.Focused = True) And (Me.txtUM_Destinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Me.txtUM_Origine.Text = UCase(Me.txtUM_Origine.Text)
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

    Private Sub frmPickingMerci_Appr_8_Rietichettatura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(174, lblUbicazioneDestinazione.Text, "Unita Magazzino Vecchia")
            lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(175, lblCodiceUM.Text, "Unita Magazzino Nuova")

            Me.Text = clsAppTranslation.GetSingleParameterValue(173, Me.Text, "Picking Appr. (8)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '**************************************   


            Me.Text = clsAppTranslation.GetSingleParameterValue(698, "", "Picking - Rietichetta")

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(3, False)

            Me.txtUM_Origine.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUM_Destinazione.Focus()

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
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim CheckUMInUbicazioneOk As Boolean = False
        Dim wkCheckUmInUbicazione As clsDataType.SapWmGiacenza
        Dim InfoGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenzaDestinazione As clsDataType.SapWmGiacenza
        Dim InfoGiacenze() As clsDataType.SapWmGiacenza
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim FlagErroreAttivo As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim wkJobsOkForExecution As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim OT_Executed_Number As String = ""
        Dim UnitaMagazzinoOk As Boolean = False
        Dim OkFineLetturaDati As Boolean = False
        Dim NumTentativiLetturaDati As Long = 0
        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM_Origine.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(699, "", "Unità Magazzino Origine inserita non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Me.txtUM_Destinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(700, "", "Unità Magazzino Destinazione inserita non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Me.txtUM_Origine.Text <> clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(701, "", "Unità Magazzino Origine divesa da quella prevista.") & vbCrLf & "UM:" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
            Me.txtUM_Destinazione.Text = Trim(Me.txtUM_Destinazione.Text)

            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM_Destinazione.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            '*******************************************************************************************************************
            '>>> CONTROLLO ESISTENZA DELL'UNITA MAGAZZINO DI ORIGINE (DEVO VERIFICARE ANCHE ESISTENZA MATERIALE PER RECUPERARLO)
            '*******************************************************************************************************************
            CheckUnitaMagazzinoOk = False
            RetCode = clsSapUtility.ResetGiacenzaStruct(wkCheckUmInUbicazione)
            wkCheckUmInUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            wkCheckUmInUbicazione.UbicazioneInfo = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo
            wkCheckUmInUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM_Origine.Text
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(wkCheckUmInUbicazione, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, InfoGiacenza, InfoGiacenze, False, False, False, Nothing, SapFunctionError, False)
            If (CheckUnitaMagazzinoOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(702, "", "Errore in verifica UNITA MAG. di ORIGINE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '******************************************************************************************************************
            'ATTENZIONE! L'UNITA MAGAZZINO DI DESTINAZIONE DEVE ESSERE NUOVA
            '******************************************************************************************************************
            CheckUnitaMagazzinoOk = False
            RetCode = clsSapUtility.ResetGiacenzaStruct(wkCheckUmInUbicazione)
            wkCheckUmInUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            wkCheckUmInUbicazione.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            wkCheckUmInUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM_Destinazione.Text
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(wkCheckUmInUbicazione, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, InfoGiacenzaDestinazione, InfoGiacenze, False, False, False, Nothing, SapFunctionError, False)
            If (CheckUnitaMagazzinoOk = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(703, "", "UNITA MAG. di DESTINAZIONE già definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            ''**************************************************************************************************************
            ''>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT
            ''**************************************************************************************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtInfo_Rec.IAnfme = InfoGiacenza.QtaTotaleLquaDisponibile               'QUANTITA DA TRASFERIRE
            'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
            OT_Info.SapOtInfo_Rec.IAltme = InfoGiacenza.UnitaDiMisuraBase                  'UDM BASE

            OT_Info.SapOtInfo_Rec.ILgnum = InfoGiacenza.UbicazioneInfo.NumeroMagazzino
            OT_Info.SapOtInfo_Rec.IWerks = InfoGiacenza.UbicazioneInfo.Divisione
            OT_Info.SapOtInfo_Rec.IMatnr = InfoGiacenza.CodiceMateriale
            OT_Info.SapOtInfo_Rec.ICharg = InfoGiacenza.Partita

            'IMPOSTO TIPO MOVIMENTO
            OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
            OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.SapOtInfo_Rec.ILetyp = InfoGiacenza.UbicazioneInfo.TipoUnitaMagazzino

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.SapOtInfo_Rec.IBestq = InfoGiacenza.TipoStock
            OT_Info.SapOtInfo_Rec.ISobkz = InfoGiacenza.CdStockSpeciale
            OT_Info.SapOtInfo_Rec.ISonum = InfoGiacenza.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.SapOtInfo_Rec.IVltyp = InfoGiacenza.UbicazioneInfo.TipoMagazzino
            OT_Info.SapOtInfo_Rec.IVlpla = InfoGiacenza.UbicazioneInfo.Ubicazione
            OT_Info.SapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(InfoGiacenza.UbicazioneInfo.UnitaMagazzino)

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.SapOtInfo_Rec.INltyp = InfoGiacenza.UbicazioneInfo.TipoMagazzino
            OT_Info.SapOtInfo_Rec.INlpla = InfoGiacenza.UbicazioneInfo.Ubicazione
            OT_Info.SapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(Me.txtUM_Destinazione.Text)

#Else

            OT_Info.rfcSapOtInfo_Rec.IAnfme = InfoGiacenza.QtaTotaleLquaDisponibile               'QUANTITA DA TRASFERIRE
            'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
            OT_Info.rfcSapOtInfo_Rec.IAltme = InfoGiacenza.UnitaDiMisuraBase                  'UDM BASE

            OT_Info.rfcSapOtInfo_Rec.ILgnum = InfoGiacenza.UbicazioneInfo.NumeroMagazzino
            OT_Info.rfcSapOtInfo_Rec.IWerks = InfoGiacenza.UbicazioneInfo.Divisione
            OT_Info.rfcSapOtInfo_Rec.IMatnr = InfoGiacenza.CodiceMateriale
            OT_Info.rfcSapOtInfo_Rec.ICharg = InfoGiacenza.Partita

            'IMPOSTO TIPO MOVIMENTO
            OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
            OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.rfcSapOtInfo_Rec.ILetyp = InfoGiacenza.UbicazioneInfo.TipoUnitaMagazzino

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.rfcSapOtInfo_Rec.IBestq = InfoGiacenza.TipoStock
            OT_Info.rfcSapOtInfo_Rec.ISobkz = InfoGiacenza.CdStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ISonum = InfoGiacenza.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.rfcSapOtInfo_Rec.IVltyp = InfoGiacenza.UbicazioneInfo.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.IVlpla = InfoGiacenza.UbicazioneInfo.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(InfoGiacenza.UbicazioneInfo.UnitaMagazzino)

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.rfcSapOtInfo_Rec.INltyp = InfoGiacenza.UbicazioneInfo.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.INlpla = InfoGiacenza.UbicazioneInfo.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(Me.txtUM_Destinazione.Text)

#End If


            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

            'ESEGUO OT IN SAP
            FlagErroreAttivo = False
            RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(704, "", "Errore nella ri-etichettatura della Unità Magazzino.")
                FlagErroreAttivo = True
            Else
                '>>> TUTTO OK
                ErrDescription = clsAppTranslation.GetSingleParameterValue(705, "", "Ri-etichettatura Unita Magazzino eseguita con successo. OT NUM:") & OT_Executed_Number
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)


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
                    frmPickingMerci_Appr_8_RietichettaturaForm = New frmPickingMerci_Appr_8_Rietichettatura
                    frmPickingMerci_Appr_8_RietichettaturaForm.Show()
                    frmPickingMerci_Appr_8_RietichettaturaForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            'VERIFICO SE IL JOB NON E' TERMINATO
            If (FlagErroreAttivo = False) And (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) And (RetInfoSapWmWmsJob.CurrentStep = clsWmsJob.WmsJob.CurrentStep) Then
                '*************************************************************************************************
                'GESTIONE ESECUZIONE ALTRA OPERAZIONE DELLA STESSA RIGA MISSIONE
                '*************************************************************************************************
                'SALVO CHIAVE JOB CORRENTE
                MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

                'RECUPERO TUTTI I DATI DEL JOBGROUP (PER EVITARE PROBLEMI DI COMUNICAZIONE CI PROVO "N" VOLTE)
                OkFineLetturaDati = False
                NumTentativiLetturaDati = 0
                Do Until OkFineLetturaDati
                    RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
                    If (RetCode = 0) Or (NumTentativiLetturaDati > 3) Then
                        OkFineLetturaDati = True
                    Else
                        NumTentativiLetturaDati = NumTentativiLetturaDati + 1
                    End If
                Loop
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(706, "", "Attenzione! Dati JOBGROUP non trovati nel sistema.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'CASO DI ERRORE => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)
                    Exit Sub
                End If

                'ESEGUO REFRESH DATI DEL JOB CORRENTE
                RetCode = clsWmsJob.RefreshJobsSingleStruct(MemoNrWmsJobs, True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'CASO DI ERRORE => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)
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
                        Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
                        Exit Sub
                    End If
                    Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
                    Exit Sub
                End If
            End If


            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)
                Exit Sub
            End If

            'ESCO DALLA MISSIONE => TORNO AL MENU DI ENTRATA MERCI
            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class