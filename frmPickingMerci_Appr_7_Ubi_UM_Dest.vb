Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsWmsJob
Imports clsSapUtility


Public Class frmPickingMerci_Appr_7_Ubi_UM_Dest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_7_Ubi_UM_Dest"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_7_Ubi_UM_Dest_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

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
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_7_Ubi_UM_Dest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

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

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_7_Ubi_UM_Dest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim WorkIsFirstJobConfirmed As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(77, lblUbicazioneDestinazione.Text, "Ubicazione Destinazione")
            lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(172, lblCodiceUM.Text, "UM Destinazione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(170, Me.Text, "Picking Appr. (7)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdSelectUbicazioneDest.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdSelectUbicazioneDest.Text, ">")
#End If

            '**************************************   


            Me.Text = "Picking x Pronto (7)"

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(2, False)

            '>>> SOLO SUL PRIMO JOB DA CONFERMARE NON ESEGUO NESSUNA PROPOSTA
            WorkIsFirstJobConfirmed = clsWmsJob.IsFirstJobConfirmed()
            If (WorkIsFirstJobConfirmed = False) Then
                RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
                If (RetCode = 0) Then
                    If (DefaultPickingMerci_EnableShowDestProposta = True) Then
                        Me.txtUbicazioneDestinazione.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                    End If
                End If
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            '>>> NEL CASO HO PRELEVATO TUTTA LA UNITA DI MAGAZZINO ALLORA TENGO LA STESSO CODICE
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.PickSUCompleto = True) And (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                Me.txtCodiceUM.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino
                Me.cmdNextScreen.Focus()
            Else
                '>>> DEVO IMMETTERE UNA NUOVA UNITA DI MAGAZZINO
                Me.txtCodiceUM.Focus()
            End If


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
        Dim CheckUdcDestinazioneOk As Boolean = False
        Dim wkCheckUmInUbicazione As clsDataType.SapWmGiacenza
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenze() As clsDataType.SapWmGiacenza
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim InfoClienteJobCurrent As clsDataType.SapAnagraficaCliente
        Dim InfoClienteJobOthers As clsDataType.SapAnagraficaCliente
        Dim UserAnswer As DialogResult
        Dim FlagErroreAttivo As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim wkJobsOkForExecution As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim wkExitFormDone As Boolean = False
        Dim OkTrasfDecoriAutomatico As Boolean = False
        Dim NumJobsDecoriTrovati As Long = 0
        Dim EndAutoTransfers As Boolean = False
        Dim IndexJob As Long = 0
        Dim GetJobDataOk As Boolean = False
        Dim QtaRimastaDaPrelevare As Double = 0
        Dim GetPickLocationOk As Boolean = False
        Dim GetPickQtyOk As Boolean = False
        Dim ReturnedMessageSingleJob As String
        Dim UnitaMagazzinoOk As Boolean = False
        Dim QtaResiduaRimasta As Double = 0
        Dim WorkTipoMagazzinoPrevistoDestinazione As String = ""
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
            Me.txtUbicazioneDestinazione.Text = Trim(Me.txtUbicazioneDestinazione.Text)

            Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
            Me.txtCodiceUM.Text = Trim(Me.txtCodiceUM.Text)


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

            '>>> RECUPERO IL TIPO DI MAGAZZINO DI DESTINAZIONE PREVISTO DALLA LOGICA (TIPICAMENTE IL PRONTO)
            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkSapWmGiacenza)
            RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                WorkTipoMagazzinoPrevistoDestinazione = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino
            Else
                WorkTipoMagazzinoPrevistoDestinazione = clsSapUtility.cstSapTipoMagPronto
            End If

            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            '>>> VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsSapUtility.ResetGiacenzaStruct(wkCheckUmInUbicazione)
            wkCheckUmInUbicazione.UbicazioneInfo.Ubicazione = Me.txtUbicazioneDestinazione.Text
            wkCheckUmInUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
            wkCheckUmInUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            wkCheckUmInUbicazione.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            wkCheckUmInUbicazione.UbicazioneInfo.TipoMagazzino = WorkTipoMagazzinoPrevistoDestinazione
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_WITH_LGPLA(wkCheckUmInUbicazione, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, CheckUbicazioneOk, CheckUnitaMagazzinoOk, CheckUMInUbicazioneOk, InfoGiacenze, InfoUbicazione, SapFunctionError, True)
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
            'ATTENZIONE! L'UNITA MAGAZZINO PUO' ESSERE NUOVA. SE E' GIA PRESENTE NEL PRONTO DEVE ESSERE NELLA STESSA UBICAZIONE
            If (CheckUnitaMagazzinoOk = True) And (CheckUMInUbicazioneOk = False) Then
                If (InfoGiacenze.Length <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(405, "", "Dati giacenza Unita Mag. errati.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                InfoGiacenza = InfoGiacenze(0)
                'SEGNALO SE LA PALETTA SI TROVA IN REALTA IN UN'ALTRA UBICAZIONE DIVERSA DA QUELLE PROPOSTA DAL SISTEMA
                If (InfoGiacenza.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(406, "", "L'Unita Magazzino è nell'UBICAZIONE:") & InfoGiacenza.UbicazioneInfo.Ubicazione & " che è diversa da quella specificata." & vbCrLf & "Considerare l'Unita di Mag. corretta ? (Si/No)"
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If
                    '>>> FORZO L'UBICAZIONE A QUELLA DELLA PALLETTA
                    Me.txtUbicazioneDestinazione.Text = InfoGiacenza.UbicazioneInfo.Ubicazione
                End If
            End If

            'SE L'UNITA MAGAZZINO E' GIA DEFINITA VERIFICO SE LE DESTINAZIONI MERCI COINCIDONO
            If (CheckUnitaMagazzinoOk = True) And (InfoGiacenze(0).UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                CheckUdcDestinazioneOk = False 'init
                InfoGiacenza = InfoGiacenze(0)
                RetCode = clsSapWS.Call_ZWS_CHECK_UDC_JOBS_DEST_OK(InfoGiacenza, clsWmsJob.WmsJob, clsUser.SapWmsUser.LANGUAGE, CheckUdcDestinazioneOk, InfoClienteJobCurrent, InfoClienteJobOthers, SapFunctionError, False)
                If (CheckUdcDestinazioneOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(683, "", "Attenzione.Il materiale della paletta ha una diversa destinazione merci.") & vbCrLf & "Dest.Corr:" & InfoClienteJobCurrent.Nome1 & vbCrLf & "Dest.UDC:" & InfoClienteJobOthers.Nome1 & vbCrLf & "Verificare in UFFICIO e riprovare."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'L'UBICAZIONE E LA PALETTA SPECIFICATA DEVE ESSERE NEL TIPO MAGAZZINI PREVISTO DALLA MISSIONE
            If (InfoUbicazione.NumeroMagazzino <> clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(687, "", "L'Ubicazione e/o l'unita magazzino specificata non sono contenute") & clsAppTranslation.GetSingleParameterValue(688, "", "nel NUMERO MAGAZZINO previsto che è:") & clsWmsJob.WmsJob.MaterialeGiacenzaDestinazione.UbicazioneInfo.NumeroMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (InfoUbicazione.TipoMagazzino <> WorkTipoMagazzinoPrevistoDestinazione) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(687, "", "L'Ubicazione e/o l'unita magazzino specificata non sono contenute") & clsAppTranslation.GetSingleParameterValue(689, "", "nel TIPO MAGAZZINO previsto") & WorkTipoMagazzinoPrevistoDestinazione & clsAppTranslation.GetSingleParameterValue(690, "", "ma sono nel:") & InfoUbicazione.TipoMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

            '>>> VERIFICO SE HO LA CONDIZIONE DEL TRASFERIMENTO DI TUTTI I DECORI DALLO SCAFFALE AL PRONTO
            OkTrasfDecoriAutomatico = False 'INIT
            If (clsWmsJob.WmsJob.IdWmsJobType = clsWmsJob.cstIdJobType_PickPronto1S) Then
                'ALA PRIMA MISSIONE DEI DECORI ESEGUO IL CONTROLLO
                '???? IN FUTURO ATTIVARE QUESTA PARTE CON UN FLAG NEL DB
                NumJobsDecoriTrovati = clsWmsJob.GetDataTableJobsTypeNotEndedForAutoTransfer(clsWmsJob.cstIdJobType_PickPronto1S, False)
                If (NumJobsDecoriTrovati >= 1) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(691, "", "Si desidera trasferire tutti gli altri DECORI automaticamente? (Si/No)")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer = DialogResult.Yes) Then
                        OkTrasfDecoriAutomatico = True
                    End If
                End If
            End If


            If (OkTrasfDecoriAutomatico = True) Then
                '>>> ESEGUO IL PRIMO TRASFERIMENTO (JOB CORRENTE)
                RetCode = clsWmsJob.ExecJobStepExecuted(CheckExecutionOk, ReturnedMessageSingleJob, RetInfoSapWmWmsJob)
                If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                    FlagErroreAttivo = True
                End If
                ErrDescription = ReturnedMessageSingleJob & vbCrLf

                '>>> CONDIZIONE DI TRASFERIMENTI MULTIPLI DI TUTTI I DECORI PRESENTI NELLO SCAFFALE PER QUESTE MISSIONI
                EndAutoTransfers = False
                IndexJob = 0
                Do Until EndAutoTransfers
                    'CARICO I DATI DEL SINGOLO JOB DA ESEGUIRE AUTOMATICAMENTE
                    RetCode = clsWmsJob.GetElementDataTableWmsJobsAutoTransferList(IndexJob, GetJobDataOk)
                    If (RetCode <> 0) Or (GetJobDataOk = False) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(692, "", "Attenzione, errore in recupero missioni da trasferire.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Else
                        'IMPOSTO DATI DI ORIGINE E DESTINAZIONE
                        'RECUPERO LE INFO SULLA QTA RIMASTA DA PRELEVARE
                        QtaRimastaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna

                        'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
                        If (QtaRimastaDaPrelevare > 0) Then
                            '>>> RECUPERO L'INFORMAZIONE DI DOVE PRELEVARE IL MATERIALE
                            RetCode += clsSapWS.Call_ZWS_MB_GET_WM_OUT_ORI_BASIC(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine, clsWmsJob.WmsJob, QtaRimastaDaPrelevare, clsWmsJob.WmsJob.UbicazioneOrigine, Nothing, "", GetPickLocationOk, GetPickQtyOk, clsWmsJob.MaterialePickOriGiacenze, clsWmsJob.DescrUbicOriPick, Nothing, SapFunctionError, False)
                            If (GetPickLocationOk = False) Then
                                ErrDescription = clsAppTranslation.GetSingleParameterValue(693, "", "Attenzione, errore in ricerca materiale da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If

                            'LA QTA CONFERMATA E' QUELLA DA PRELEVARE
                            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = QtaRimastaDaPrelevare

                            'IMPOSTO L'UBICAZIONE DI ORIGINE DOVE PRELEVARE LA MERCE (CHE E' LO SCAFFALE)
                            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo = clsWmsJob.MaterialePickOriGiacenze(0).UbicazioneInfo

                            'IMPOSTO LA STESSA DESTINAZIONE DELLA MISSIONE CONFERMATA DALL'OPERATORE
                            RetCode = clsWmsJob.SetJobPickMaterialGiacenzaDest()

                            RetCode = clsWmsJob.ExecJobStepExecuted(CheckExecutionOk, ReturnedMessageSingleJob, RetInfoSapWmWmsJob)
                            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                                FlagErroreAttivo = True
                                EndAutoTransfers = True
                            End If
                            ErrDescription = ErrDescription & ReturnedMessageSingleJob & vbCrLf
                        End If
                    End If
                    IndexJob = IndexJob + 1
                    If (IndexJob >= clsWmsJob.GetNumRecDataTableWmsJobsAutoTransfer()) Then
                        EndAutoTransfers = True
                    End If
                Loop
            Else
                '>>> ESEGUO UNICA AZIONE PREVISTA DALLA MISSIONE
                RetCode = clsWmsJob.ExecJobStepExecuted(CheckExecutionOk, ErrDescription, RetInfoSapWmWmsJob)
                If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                    FlagErroreAttivo = True
                End If
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
                    frmPickingMerci_Appr_7_Ubi_UM_DestForm = New frmPickingMerci_Appr_7_Ubi_UM_Dest
                    frmPickingMerci_Appr_7_Ubi_UM_DestForm.Show()
                    frmPickingMerci_Appr_7_Ubi_UM_DestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '***********************************************************************************************************
            '>>> SE NON E' STATO PRELEVATA TUTTA LA PALETTA CHIEDO SE E' NECESSARIO RIETICHETTARE LA PALETTA DI ORIGINE
            '***********************************************************************************************************
            If (FlagErroreAttivo = False) Then
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.PickSUCompleto = False) And ((clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.AbilitaUnitaMagazzino = True) Or (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True)) Then

                    'RICALCOLO LA QTA RESIDUA RIMASTA
                    QtaResiduaRimasta = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore

                    ErrDescription = clsAppTranslation.GetSingleParameterValue(694, "", "Si desidera rietichettare la paletta di origine ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer = DialogResult.Yes) Then
                        frmPickingMerci_Appr_8_RietichettaturaForm = New frmPickingMerci_Appr_8_Rietichettatura
                        frmPickingMerci_Appr_8_RietichettaturaForm.Show()
                        RetCode = clsNavigation.CloseSourceForm(Me, False)
                        Exit Sub
                    Else
                        'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE CON INFO DELLA PALETTA RIMASTA DA RIPOSIZIONARE
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(695, "", "Riposizionare paletta:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(697, "", "QTA Residua:") & Trim(QtaResiduaRimasta) & " " & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione & vbCrLf & clsAppTranslation.GetSingleParameterValue(696, "", "Ubicazione Originale:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino & "-" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione

                        frmMessageForUserForm = New frmMessageForUser
                        frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                        frmMessageForUserForm.ShowMessage(ErrDescription)
                    End If
                End If
            End If

            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA OPERAZIONE DELLA STESSA RIGA MISSIONE
            '*************************************************************************************************
            wkExitFormDone = False
            If (FlagErroreAttivo = False) And (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) And (RetInfoSapWmWmsJob.CurrentStep = clsWmsJob.WmsJob.CurrentStep) Then
                RetCode = clsWmsJob.ReloadDataOfSameJobForNewPick(Me, wkExitFormDone, True)
                If (wkExitFormDone = True) Then
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

            'ESCO DALLA FUNZIONE => TORNO AL MENU INIZIALE
            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

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