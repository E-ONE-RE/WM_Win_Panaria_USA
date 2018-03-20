Imports clsSapWS
Imports clsSapUtility
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmEM_FromJob_Part_5_FinalUbiConfirm
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_5_FinalUbiConfirm"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    cmdSelectUbicazioneDest_Click(Me, e)
            End Select

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

            'PARTO NUOVAMENTE DALLO STEP DI SCELTA DELLA POSIZIONE
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJob_Part_5_FinalUbiConfirm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim outUbicConfermata As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazDestConfermata.Focused = True) And (Me.txtUbicazDestConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

                    Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)

                    'CONTROLLO PER DUE VOLTE LA CORRETTEZZA DEL DATO IMMESSO
                    RetCode = clsConfUsrInput.CheckUsrUbicInput(Me.txtUbicazDestConfermata, outUbicConfermata)
                    If (RetCode <> 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1208, "", "Ubicazione immessa diversa dalla precedente!")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.txtUbicazDestConfermata.Text = ""
                        Exit Sub
                    End If

                    If (outUbicConfermata = True) Then
                        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                        Call Me.cmdNextScreen_Click(Me, e)
                        Exit Sub
                    End If
                End If
            End If


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

    Private Sub frmEM_FromJob_Part_5_FinalUbiConfirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'Traduzioni
            Me.lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(77, Me.lblUbicazDestConfermata.Text, "Ubicazione Destinazione")
            Me.lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(75, Me.lblUbicazDestConfermata.Text, "UM.Dest.")
            Me.Text = clsAppTranslation.GetSingleParameterValue(76, Me.Text, "EM - Bem (5)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazioneDest.Text, "...")
#Else
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazioneDest.Text, "...")
#End If

            '**************************************


            'VISUALIZZO LE INFORMAZIONI DEI DATI ASSOCIATI ALL'ENTRATA MERCE
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPutAwayInfoForUserString(2)

            'INIT CONTROLLI DI DATA ENTRY
            Me.txtUbicazDestConfermata.Text = ""
            Me.txtUMDestConfermata.Text = ""

            '*********************************************************************************************************
            '>>> SE LA LOGICA MI HA TROVATO UNA UBICAZIONE VALIDA LA PROPONGO
            Me.txtUbicazDestConfermata.Text = clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione

            'RECUPERO L'INFORMAZIONE DELL'UNITA DI MAGAZZINO DA PROPORRE
            RetCode = clsEMFromJob.GetEntrataMerceUnitaMagDaConfermare(Me.txtUMDestConfermata.Text)

            Me.txtUbicazioneDestInfo.Text = clsWmsJob.DescrUbicDestPick  '>>> imposto descrizione ubicazione per help operatore

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'POSSO CAMBIARE SOLO L'UBICAZIONE DI DESTINAZIONE
            Me.txtUbicazDestConfermata.Focus()

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
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim OT_Executed_Number As String = ""
        Dim UserQuestion As String
        Dim UserAnswer As DialogResult
        Dim InfoUbicazioneDaCreare As clsDataType.SapWmUbicazione
        Dim CreaUbicazione_Executed_Ok As Boolean = False
        Dim ShowDescrizioneCreaUbica As String = ""
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim DatiRicercaDocMat As clsDataType.SapWmDocumentoMateriale
        Dim GetDocMatOk As Boolean
        Dim FlagErroreAttivo As Boolean = False
        Dim wkExitFormDone As Boolean = False
        Dim EntrataMerceDaOdp As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazDestConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'DEVO VERIFICARE SE L'OPERATORE MI HA CAMBIATO L'UBICAZIONE CONSIGLIATA
            Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazDestConfermata.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazDestConfermata.Text = WorkOutUbicazione


            '**************************************************************************************************
            '>>> VERIFICO SE L'UBICAZIONE DI DESTINAZIONE ESISTE
            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'SE L'OPERATORE NON HA CAMBIATO L'UBICAZIONE GLI ALTRI DATI SONO VALIDI
            RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino
            If (UCase(Me.txtUbicazDestConfermata.Text) = UCase(clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione)) Then
                DatiRicercaUbicazione.TipoMagazzino = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino
            End If
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazDestConfermata.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Or (RetCode <> 0) Then
                'L'UBICAZIONE DEVE ESISTERE ASSOLUTAMENTE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(454, "", "Ubicazione Destinazione non definita nel sistema.") & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '**************************************************************************************************
            '>>> IL NUMERO MAGAZZINO E IL TIPO MAGAZZINO DEVONO ESSERE COMUNQUE QUELLI PREVISTI DALLA LOGICA
            '>>> IN PRATICA L'OPERATORE PU' SCEGLIERE SONO UNA UBICAZIONE DI QUEL TIPO MAGAZZINO
            '**************************************************************************************************
            If (InfoUbicazione.NumeroMagazzino <> clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino) Or (InfoUbicazione.TipoMagazzino <> clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino) Then
                'L'UBICAZIONE DEVE ESISTERE ASSOLUTAMENTE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(456, "", "L'Ubicazione specificata non è presente nel tipo magazzino:") & clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '**************************************************************************************************
            '**************************************************************************************************
            'IMPOSTO I DATI DELL'UBICAZIONE DI DESTINAZIONE
            clsWmsJob.WmsJob.UbicazioneDestinazione = InfoUbicazione

            'SE LA DESTINAZIONE E' UN MAGAZZINO CON GESTIONE DELLE UM
            If (clsWmsJob.WmsJob.UbicazioneDestinazione.AbilitaUnitaMagazzino = True) Then
                'IN QUESTO CASO DEVO RICHIEDERE LA LETTURA DI UN BARCODE DELLA CESTA
                If (Me.txtUMDestConfermata.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(457, "", "Unità Magazzino Destinazione non corretta.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
                clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino = Me.txtUMDestConfermata.Text
            Else
                clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino = ""
            End If


            '************************************************************************************************************
            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'ORDINE DI TRASFERIMENTO PER L'ENTRATA MERCE
            '************************************************************************************************************


#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtInfo_Rec.IAnfme = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.SapOtInfo_Rec.IAltme = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione           'UDM
            'IMPOSTO TIPO MOVIMENTO PER DESTINAZIONI PARTICOLARI
            If (clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = clsSapUtility.cstSapTipoMagProduzione) Then
                OT_Info.SapOtInfo_Rec.IBwlvs = DefaultEM_BEM_TipoMovimentoNoFtToProd
                'OT_Info.SapOtInfo_Rec.IBenum = .NumeroFabbisognoTrasporto "???? VERIFICARE
            Else
                '>>> DESTINAZIONE GENERICA (NO PRODUZIONE)
                OT_Info.SapOtInfo_Rec.IBwlvs = DefaultEM_BEM_TipoMovimentoNoFt '"999"
                OT_Info.SapOtInfo_Rec.IBenum = ""
            End If
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino, True) = True) Then
                OT_Info.SapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

            OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.SapOtInfo_Rec.ILgnum = clsWmsJob.WmsJob.UbicazioneOrigine.NumeroMagazzino
            OT_Info.SapOtInfo_Rec.IWerks = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
            OT_Info.SapOtInfo_Rec.IMatnr = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            OT_Info.SapOtInfo_Rec.ICharg = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.SapOtInfo_Rec.IBestq = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock
            OT_Info.SapOtInfo_Rec.ISobkz = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CdStockSpeciale
            OT_Info.SapOtInfo_Rec.ISonum = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.SapOtInfo_Rec.IVltyp = clsWmsJob.WmsJob.UbicazioneOrigine.TipoMagazzino
            OT_Info.SapOtInfo_Rec.IVlpla = clsWmsJob.WmsJob.UbicazioneOrigine.Ubicazione
            OT_Info.SapOtInfo_Rec.IVlenr = clsWmsJob.WmsJob.UbicazioneOrigine.UnitaMagazzino

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.SapOtInfo_Rec.INltyp = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino
            OT_Info.SapOtInfo_Rec.INlpla = clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione
            OT_Info.SapOtInfo_Rec.INlenr = clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino

            '>>> IMPOSTO IL RIFERIMENTO AL MAGAZZINO LOGICO
            OT_Info.SapOtInfo_Rec.ILgort = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            '>>> IMPOSTO I RIFERIMENTI PER IL DOCUMENTO MATERIALE
            OT_Info.SapOtInfo_Rec.IMblnr = clsWmsJob.WmsJob.DocumentoMaterialeNumero
            OT_Info.SapOtInfo_Rec.IMjahr = clsWmsJob.WmsJob.DocumentoMaterialeAnno
            OT_Info.SapOtInfo_Rec.IZeile = clsWmsJob.WmsJob.DocumentoMaterialePosizione

            '>>>> PER TENERE TRACCIA DELL'OT NEL CASO NON CI SONO FABBISOGNI ATTIVI (USO CAMPO [Ablad] come campo di appoggio)
            OT_Info.SapOtInfo_Rec.IAblad = clsWmsJob.WmsJob.DocumentoMaterialeAnno & clsWmsJob.WmsJob.DocumentoMaterialeNumero & clsWmsJob.WmsJob.DocumentoMaterialePosizione

#Else

            OT_Info.rfcSapOtInfo_Rec.IAnfme = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.rfcSapOtInfo_Rec.IAltme = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione           'UDM
            'IMPOSTO TIPO MOVIMENTO PER DESTINAZIONI PARTICOLARI
            If (clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = clsSapUtility.cstSapTipoMagProduzione) Then
                OT_Info.rfcSapOtInfo_Rec.IBwlvs = DefaultEM_BEM_TipoMovimentoNoFtToProd
                'OT_Info.rfcSapOtInfo_Rec.IBenum = .NumeroFabbisognoTrasporto "???? VERIFICARE
            Else
                '>>> DESTINAZIONE GENERICA (NO PRODUZIONE)
                OT_Info.rfcSapOtInfo_Rec.IBwlvs = DefaultEM_BEM_TipoMovimentoNoFt '"999"
                OT_Info.rfcSapOtInfo_Rec.IBenum = ""
            End If
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino, True) = True) Then
                OT_Info.rfcSapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

            OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.rfcSapOtInfo_Rec.ILgnum = clsWmsJob.WmsJob.UbicazioneOrigine.NumeroMagazzino
            OT_Info.rfcSapOtInfo_Rec.IWerks = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
            OT_Info.rfcSapOtInfo_Rec.IMatnr = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            OT_Info.rfcSapOtInfo_Rec.ICharg = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.rfcSapOtInfo_Rec.IBestq = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock
            OT_Info.rfcSapOtInfo_Rec.ISobkz = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CdStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ISonum = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.rfcSapOtInfo_Rec.IVltyp = clsWmsJob.WmsJob.UbicazioneOrigine.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.IVlpla = clsWmsJob.WmsJob.UbicazioneOrigine.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.IVlenr = clsWmsJob.WmsJob.UbicazioneOrigine.UnitaMagazzino

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.rfcSapOtInfo_Rec.INltyp = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.INlpla = clsWmsJob.WmsJob.UbicazioneDestinazione.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.INlenr = clsWmsJob.WmsJob.UbicazioneDestinazione.UnitaMagazzino

            '>>> IMPOSTO IL RIFERIMENTO AL MAGAZZINO LOGICO
            OT_Info.rfcSapOtInfo_Rec.ILgort = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            '>>> IMPOSTO I RIFERIMENTI PER IL DOCUMENTO MATERIALE
            OT_Info.rfcSapOtInfo_Rec.IMblnr = clsWmsJob.WmsJob.DocumentoMaterialeNumero
            OT_Info.rfcSapOtInfo_Rec.IMjahr = clsWmsJob.WmsJob.DocumentoMaterialeAnno
            OT_Info.rfcSapOtInfo_Rec.IZeile = clsWmsJob.WmsJob.DocumentoMaterialePosizione

            '>>>> PER TENERE TRACCIA DELL'OT NEL CASO NON CI SONO FABBISOGNI ATTIVI (USO CAMPO [Ablad] come campo di appoggio)
            OT_Info.rfcSapOtInfo_Rec.IAblad = clsWmsJob.WmsJob.DocumentoMaterialeAnno & clsWmsJob.WmsJob.DocumentoMaterialeNumero & clsWmsJob.WmsJob.DocumentoMaterialePosizione

#End If

            'SE E'UN FLUSSO DI ENTRATA MERCE DA ODP SETTO IL FLAG SPECIFICO
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.NumeroOrdineDiProduzione, True) = True) Then
                EntrataMerceDaOdp = True
            Else
                EntrataMerceDaOdp = False
            End If

            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)
            'ESEGUO OT IN SAP
            RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, EntrataMerceDaOdp, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
            If (RetCode <> 0) Then
                FlagErroreAttivo = True '>>> CONDIZIONE DI ERRORE => SETTO IL FLAG
                ErrDescription = clsAppTranslation.GetSingleParameterValue(476, "", "Attenzione!Errore nel trasferimento della BEM.") & vbCrLf
                ErrDescription = ErrDescription & SapFunctionError.ERROR_DESCRIPTION
            Else
                FlagErroreAttivo = False
                '>>> TUTTO OK
                ErrDescription = clsAppTranslation.GetSingleParameterValue(477, "", "Trasferimento BEM eseguito con successo. OT NUM:") & OT_Executed_Number
                If (clsUtility.IsStringValid(ShowDescrizioneCreaUbica, True) = True) Then
                    ErrDescription = ErrDescription & vbCrLf & ShowDescrizioneCreaUbica
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
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmEM_FromJob_Part_5_FinalUbiConfirmForm = New frmEM_FromJob_Part_5_FinalUbiConfirm
                    frmEM_FromJob_Part_5_FinalUbiConfirmForm.Show()
                    frmEM_FromJob_Part_5_FinalUbiConfirmForm.cmdNextScreen.Focus()
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
            End If


            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)
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

    Private Sub txtUbicazDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazDestConfermata.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtUbicazDestConfermata.Text <> "" Then
                Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
            End If

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

    Private Sub cmdSelectUbicazioneDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazioneDest.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione
            ElseIf (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione
            Else
                'DIVISIONE DI DEFAULT
                clsSelezioneUbicazione.FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            End If

            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterNumMag = clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino
            ElseIf (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterNumMag = clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino
            Else
                'CASO DEFAULT
                clsSelezioneUbicazione.FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            End If

            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino
            ElseIf (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino
            End If

            '>>> VEDO TUTTE LE UBICAZIONI
            clsSelezioneUbicazione.FilterUbicazione = ""

            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Function ConfermaSelezioneLocazione() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneLocazione = 1 'init at error

            Me.Focus()
            If (clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione <> "") Then
                Me.txtUbicazDestConfermata.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
                clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneLocazione = RetCode 'se = 0 tutto ok

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class