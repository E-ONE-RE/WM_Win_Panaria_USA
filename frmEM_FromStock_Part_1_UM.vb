Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmEM_FromStock_Part_1_UM

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_1_UM"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private UdMTrasfListIndex As Integer = 0


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

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then
                If (clsEMFromStock.UdMTrasfList.GetLength(0) > 0) Then

                    WorkString = clsAppTranslation.GetSingleParameterValue(1638, "", "Per uscire dalla procedura occore confermare le palette lette.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1639, "", "Premere il pulsante Continua.")
                    UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If
            End If


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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim WorkDatiUbicaDest() As clsDataType.SapWmGiacenza
        Dim UnitaMagazzinoOk As Boolean = False
        Dim UbicazioneDestFound As Boolean = False
        Dim NumUbiDestFound As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            '***********************************************************************************************
            'DEVO AVERE SPECIFICATO ALMENO UNA UNITA MAGAZZINO DA TRASFERIRE
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                If (clsEMFromStock.UdMTrasfList Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub

                Else
                    If (clsEMFromStock.UdMTrasfList.GetLength(0) <= 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If


            If (Me.txtUM.Text <> "") Then
                Call cmdOK_Click(sender, e)
                Exit Sub
            End If


            If (clsEMFromStock.UdMTrasfList Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM.Text = ""
                Exit Sub
            End If

            If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then
                If (clsEMFromStock.UdMTrasfList.GetLength(0) <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtUM.Text = ""
                    Exit Sub
                End If
            End If



            If (clsEMFromStock.EM_StockSourceType <> clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad) Then

                '>>> SE ARRIVO LE UDC SONO CORRETTE E POSSO CERCARE LA MIGLIORE DESTINAZIONE
                clsEMFromStock.MaterialeGiacenza = clsEMFromStock.UdMTrasfList(0)

                'IMPOSTO I DATI DELL'UBICAZIONE DI ORIGINE
                clsEMFromStock.SourceUbicazione = clsEMFromStock.UdMTrasfList(0).UbicazioneInfo

                '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
                RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.StockSelezionatoUtente)

                'RECUPERO LE POSSIBILI DESTINAZIONI IN BASE ALLA LOGICA DI STRATEGIA
                RetCode = clsSapWS.Call_ZWS_MB_GET_WM_INPUT_DEST_BASIC(clsEMFromStock.MaterialeGiacenza, clsEMFromStock.SourceUbicazione, clsEMFromStock.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq, clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione, Nothing, Nothing, False, UbicazioneDestFound, WorkDatiUbicaDest, clsEMFromStock.DescrUbiDestinazione, SapFunctionError, False)

                'If (UbicazioneDestFound = False) Then
                '    ErrDescription = clsAppTranslation.GetSingleParameterValue(437, "", "Ubicazione destinazione non trovata.")
                '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If
                If (UbicazioneDestFound = True) Then
                    NumUbiDestFound = UBound(WorkDatiUbicaDest)
                    ReDim clsEMFromStock.UbicazioneDestProposte(NumUbiDestFound)
                    For Index = 0 To (NumUbiDestFound)
                        clsEMFromStock.UbicazioneDestProposte(Index).UbicazioneInfo = WorkDatiUbicaDest(Index).UbicazioneInfo
                        clsEMFromStock.UbicazioneDestProposte(Index).CodiceCommessa = WorkDatiUbicaDest(Index).OdaInputDestInfo.CodiceCommessa
                        clsEMFromStock.UbicazioneDestProposte(Index).DescrUbicDestinazione = WorkDatiUbicaDest(Index).OdaInputDestInfo.DescrUbicDestinazione
                        clsEMFromStock.UbicazioneDestProposte(Index).DescrizioneCausale = WorkDatiUbicaDest(Index).OdaInputDestInfo.DescrizioneCausale
                        clsEMFromStock.UbicazioneDestProposte(Index).NumDocumentoAcquisto = WorkDatiUbicaDest(Index).OdaInputDestInfo.NumDocumentoAcquisto
                        clsEMFromStock.UbicazioneDestProposte(Index).NumeroOrdineProduzione = WorkDatiUbicaDest(Index).OdaInputDestInfo.NumeroOrdineProduzione
                        clsEMFromStock.UbicazioneDestProposte(Index).PosizioneDocumentoAcquisto = WorkDatiUbicaDest(Index).OdaInputDestInfo.PosizioneDocumentoAcquisto
                        clsEMFromStock.UbicazioneDestProposte(Index).QtaRichiesta = WorkDatiUbicaDest(Index).OdaInputDestInfo.QtaRichiesta
                        clsEMFromStock.UbicazioneDestProposte(Index).UnitaDiMisuraBase = WorkDatiUbicaDest(Index).OdaInputDestInfo.UnitaDiMisuraBase

                        clsEMFromStock.UbicazioneDestProposte(Index).FoundMancanteOdp = WorkDatiUbicaDest(Index).OdaInputDestInfo.FoundMancanteOdp
                        clsEMFromStock.UbicazioneDestProposte(Index).FoundMagProd = WorkDatiUbicaDest(Index).OdaInputDestInfo.FoundMagProd
                        clsEMFromStock.UbicazioneDestProposte(Index).FoundAreaProd = WorkDatiUbicaDest(Index).OdaInputDestInfo.FoundAreaProd
                        clsEMFromStock.UbicazioneDestProposte(Index).FoundMagGeneric = WorkDatiUbicaDest(Index).OdaInputDestInfo.FoundMagGeneric
                        clsEMFromStock.UbicazioneDestProposte(Index).FoundMagEmpty = WorkDatiUbicaDest(Index).OdaInputDestInfo.FoundMagEmpty
                        If (clsEMFromStock.UbicazioneDestProposte(Index).FoundMagEmpty = True) Then
                            clsEMFromStock.IndexUbiVuotaDest = Index
                        End If
                    Next

                    'IMPOSTO PRIMA DESTINAZIONE COME QUELLA ATTIVA
                    clsEMFromStock.IndexUbicazioneDestAttiva = 0
                    clsEMFromStock.UbicazioneDestOnWork = clsEMFromStock.UbicazioneDestProposte(clsEMFromStock.IndexUbicazioneDestAttiva)
                Else
                    clsEMFromStock.IndexUbicazioneDestAttiva = -1 'NESSUNA DESTINAZIONE TROVATA
                End If


                Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            Else

                Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType.EM_Stock_SourceTypeUM_MovTransfLoad, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_1_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO OK ALLA CONFERMA DEL BC
                    Call Me.cmdOK_Click(Me, e)
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

    Private Sub txtUnitaMagazzinoOrigine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM.Text <> "") Then
                Me.txtUM.Text = UCase(Me.txtUM.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_1_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblUnitaMagazzinoOrigine.Text = clsAppTranslation.GetSingleParameterValue(64, lblUnitaMagazzinoOrigine.Text, "Unita Magazzino")
            Me.Text = clsAppTranslation.GetSingleParameterValue(91, Me.Text, "EM - Prod. Mul. (1)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(1644, cmdAbortScreen.Text, "Uscita")
            Me.cmdDeleteList.Text = clsAppTranslation.GetSingleParameterValue(1645, cmdDeleteList.Text, "Cancella Lista")

            Me.cmdOK.Text = clsAppTranslation.GetSingleParameterValue(8, cmdOK.Text, "OK")
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1689, cmdNextScreen.Text, ">")
#End If

            '**************************************

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


#If Not APPLICAZIONE_WIN32 <> "SI" Then
            'AGGIUSTAMENTI PER MIGLIOR VISUALIZZAZIONE
            txtInfoUMSelezionata.Height = txtInfoUMSelezionata.Height + 60

            lblUnitaMagazzinoOrigine.Top = lblUnitaMagazzinoOrigine.Top + 60
            lblUnitaMagazzinoOrigine.Height = lblUnitaMagazzinoOrigine.Height - 20

            txtUM.Top = txtUM.Top + 40
#End If


            'NEL CASO DI "BACK" DEVO RIVISUALIZZARE LE UM CHE ERANO STATO IMMESSE
            Call RefreshDatiMaterialeAttivo()

            Me.txtUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim UnitaMagazzinoOk As Boolean = False
        Dim CheckOnProduction As Boolean = False
        Dim UserAnswer As DialogResult
        Dim CheckUM_OnFinalLocation As Boolean = False
        Dim FlagCheckLenum As clsDataType.FlagCheckLenum

        Dim outTabProdError() As String = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Me.txtUM.Text = UCase(Me.txtUM.Text)

            Me.txtUM.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtUM.Text)


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Me.txtUM.Text = ""
                Exit Sub
            End If

            '*****************************************************************************
            'VERIFICO DI NON AVER GIA' SELEZIONATO L'UNITA' DI MAGAZZINO
            '*****************************************************************************
            If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then
                If (clsEMFromStock.UdMTrasfList.GetLength(0) > 0) Then
                    For i = 0 To clsEMFromStock.UdMTrasfList.GetLength(0) - 1
                        If (clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsEMFromStock.UdMTrasfList(i).UbicazioneInfo.UnitaMagazzino) = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(Me.txtUM.Text)) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1178, "", "L'Unita Magazzino specificata è già stata selezionata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            Me.txtUM.Text = ""
                            Me.txtUM.Focus()

                            Exit Sub
                        End If
                    Next
                End If
            End If

            '******************************************************************************************
            ' >>> NEL CASO DEL PUTAWAY DEVO LIMITARE IL NUMERO DI PALLET LETTI A 2 ( CONFIGURABILE )
            '******************************************************************************************
            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeNone) Or (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic) Then
                If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then
                    If (clsEMFromStock.UdMTrasfList.GetLength(0) >= Default_EMFromStock_Max_NumPalletScan) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1660, "", "Massimo numero di pallet letti raggiunto. Numero massimo =") & Trim(Str(Default_EMFromStock_Max_NumPalletScan)) & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        Me.txtUM.Text = ""
                        Me.txtUM.Focus()

                        Exit Sub
                    End If
                End If
            End If

            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text

            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad) Or (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp) Then
                CheckOnProduction = True
            End If

            RetCode = clsSapUtility.ResetFlagCheckLenum(FlagCheckLenum)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUbicazione, False, False, CheckOnProduction, False, True, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, clsEMFromStock.WorkGiacenzaUM, WorkGiacenzaUM_Free, CheckUM_OnFinalLocation, False, False, FlagCheckLenum, SapFunctionError, False, outTabProdError)
            If (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                Me.txtUM.Text = ""
                Me.txtUM.Focus()

                Exit Sub
            End If


            'CONTROLLO SE CI SONO ERRORI NELLA CONFIGURAZIONE DEL MATERIALE E NELL'ODP ( Controllo solo nel Carico Camion )
            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad) Then
                If (EnableCheckProdError = True) Then
                    If (Not outTabProdError Is Nothing) Then
                        If (outTabProdError.Count > 0) Then

                            For Each rfcRow In outTabProdError
                                ErrDescription += rfcRow.ToString + vbCrLf
                            Next

                            'Sono stati riscontrati errori di configurazione SAP avvisare il CED
                            MessageBox.Show(clsAppTranslation.GetSingleParameterValue(1808, "", "Sono stati riscontrati errori di configurazione SAP avvisare il CED."), AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            'ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            'If (UserAnswer = Windows.Forms.DialogResult.Yes) Then
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then

                                Me.txtUM.Text = ""
                                Me.txtUM.Focus()

                                ErrDescription = ""

                                Exit Sub
                            End If

                        End If
                    End If
                End If
            End If


            'SE IL PALLET SI TROVA GIA IN MAGAZZINO BLOCCO IL PUTAWAY
            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeNone) Or (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_Generic) Or (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp) Then
                If (CheckUM_OnFinalLocation = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1661, "", "L'Unita Magazzino e' gia nel tipo magazzino di destinazione del putaway.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    Me.txtUM.Text = ""
                    Me.txtUM.Focus()

                    Exit Sub
                End If


                'Controllo il Flag cumulativo di errori per effettuare il Putaway da Produzione e desc. Errore
                If (FlagCheckLenum.FlagE_PRD_FLAG_ERROR_PUTAWAY = True) Then

                    'Sono stati riscontrati errori di configurazione SAP avvisare il CED
                    MessageBox.Show(clsAppTranslation.GetSingleParameterValue(1809, "", "Sono stati riscontrati errori di configurazione SAP avvisare il CED."), AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    ErrDescription = FlagCheckLenum.StrE_PRD_FLAG_ERR_PUTAWAY_DESCR
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    'If (UserAnswer = Windows.Forms.DialogResult.Yes) Then
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Me.txtUM.Text = ""
                        Me.txtUM.Focus()

                        ErrDescription = ""

                        Exit Sub
                    End If

                End If

            End If


            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad) Then
                If (clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.Ubicazione <> "") And (clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.TipoMagazzino <> "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1692, "", "L'Unita Magazzino e' gia nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(950, "", "UBICAZIONE :") & clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.Ubicazione & " - " & clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.TipoMagazzino
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    Me.txtUM.Text = ""
                    Me.txtUM.Focus()

                    Exit Sub
                End If

                'CONTROLLO SE L'UNITA' DI MAGAZZINO E' STATA CANCELLATA
                If (FlagCheckLenum.FlagE_PRD_FLAG_CANCELLAZIO = True) And (FlagCheckLenum.FlagE_PRD_FLAG_MODIFICA = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1802, "", "L'Unita Magazzino e' stata Cancellata.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    Me.txtUM.Text = ""
                    Me.txtUM.Focus()

                    Exit Sub
                End If

                If (FlagCheckLenum.FlagE_PRD_FLAG_MB31 = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1698, "", "L'Unita Magazzino e' gia stata caricata nel sistema (MB31).")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    Me.txtUM.Text = ""
                    Me.txtUM.Focus()

                    Exit Sub
                End If

            End If




            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
            If (clsUser.SapWmsUser.PROFID = "") And (clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(502, "", "L'Unita Magazzino non puo' essere trasferita dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                Me.txtUM.Text = ""
                Me.txtUM.Focus()

                Exit Sub
            End If


            '*****
            'Non passo da navigazione e apro direttamente la form check SKU - sviluppare tipo messagebox
            '*****
            If clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad Then

                frmEM_FromStock_Part_5_ConfirmSKUForm = New frmEM_FromStock_Part_5_ConfirmSKU
                frmEM_FromStock_Part_5_ConfirmSKUForm.Show()

                RetCode = clsNavigation.CloseSourceForm(Me, False)

                Exit Sub
            End If

            '*****

            RetCode = AddUMToList(clsEMFromStock.WorkGiacenzaUM)
            '...TODO
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                    frmEM_FromStock_Part_1_UMForm.Show()
                    frmEM_FromStock_Part_1_UMForm.cmdNextScreen.Focus()
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

    Public Function AddUMToList(ByRef inWorkGiacenzaUM As clsDataType.SapWmGiacenza) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            UdMTrasfListIndex = 0

            If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then

                If (clsEMFromStock.UdMTrasfList.GetLength(0) > 0) Then
                    UdMTrasfListIndex = clsEMFromStock.UdMTrasfList.GetLength(0)
                End If

            End If


            'MEMORIZZO L'INFORMAZIONE DELL'UBICAZIONE DELLA 
            If (UdMTrasfListIndex = 0) Then
                clsEMFromStock.SourceUbicazione = inWorkGiacenzaUM.UbicazioneInfo
            ElseIf (UdMTrasfListIndex > 0) Then

                If clsEMFromStock.EM_StockSourceType <> clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfLoad Then

                    'POSSO AGGIUNGERE SOLO UDC CON LO STESSO MATERIALE / PARTITA
                    If (clsEMFromStock.UdMTrasfList(0).CodiceMateriale <> inWorkGiacenzaUM.CodiceMateriale) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1210, "", "L'UDC letta contiene un materiale diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.txtUM.Text = ""
                        Me.txtUM.Focus()
                        Exit Function
                    End If
                    If (clsEMFromStock.UdMTrasfList(0).Partita <> inWorkGiacenzaUM.Partita) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1210, "", "L'UDC letta contiene un materiale diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.txtUM.Text = ""
                        Me.txtUM.Focus()
                        Exit Function
                    End If

                End If

            End If

                clsEMFromStock.MaterialeGiacenza = inWorkGiacenzaUM
                clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore = inWorkGiacenzaUM.QtaTotaleLquaDispoUdMAcq


                'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsTrasfUnitaMagazzino
                ReDim Preserve clsEMFromStock.UdMTrasfList(UdMTrasfListIndex)
                clsEMFromStock.UdMTrasfList(UdMTrasfListIndex) = inWorkGiacenzaUM

                'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
                Call RefreshDatiMaterialeAttivo()

                clsSapUtility.ResetGiacenzaStruct(inWorkGiacenzaUM)

                Me.txtUM.Text = ""
                Me.txtUM.Focus()


                '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoUMSelezionata.Text = ""

            If (clsEMFromStock.UdMTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Me.txtInfoUMSelezionata.Text = ""
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & ""
                Exit Function
            End If
            If (clsEMFromStock.UdMTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Me.txtInfoUMSelezionata.Text = ""
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & ""
                Exit Function
            End If

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLE PALETTE LETTE DALL'OPERATORE
            Me.txtInfoUMSelezionata.Text = clsEMFromStock.ShowJobPutAwayInfoForUserString(0)

            If (Not clsEMFromStock.UdMTrasfList Is Nothing) Then
                'AGGIORNO IL NUMERO DI UDC LETTE
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsEMFromStock.UdMTrasfList.GetLength(0)
            Else
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & ""
            End If

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Sub cmdDeleteList_Click(sender As Object, e As EventArgs) Handles cmdDeleteList.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim UserAnswer As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'VERIFICO DI NON AVER GIA' SELEZIONATO L'UNITA' DI MAGAZZINO

            ErrDescription = clsAppTranslation.GetSingleParameterValue(1648, "", "Si è veramente sicuri di voler cancellare la lista pallet? (Si / No )")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                clsEMFromStock.ClearAllData()

                Call RefreshDatiMaterialeAttivo()
                Me.txtUM.Focus()

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