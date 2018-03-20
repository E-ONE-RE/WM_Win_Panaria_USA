Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Code_5_Sel_CodMatOrigine

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_5_Sel_CodMatOrigine"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private wkStart_time_read As Date
    Private wkEnd_time_read As Date


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_5_Sel_CodMatOrigine_KeyPress(Me, e)

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkDataRow As DataRow
        Dim GetDataOk As Boolean = False
        Dim GetDataGiacenzeSKUOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim WorkSapWmPropostaGiacenza As clsDataType.SapWmGiacenza
        Dim wkPropostaUbicazioneInfo As clsDataType.SapWmUbicazione
        Dim DatiRicercaSKUUbicazione As clsDataType.SapWmUbicazione
        Dim DatiRicercaSKUGiacenza As clsDataType.SapWmGiacenza
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim FlagErrorSkuElaboration As clsDataType.FlagErrorSkuElaborationStruct
        Dim WorkUM_OnFinalLocation As Boolean = False
        Dim WorkFlagCheckLenum As clsDataType.FlagCheckLenum
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtCodiceUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(667, "", "Specificare un CODICE UM valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)

            'DETERMINO SE L'OPERATORE HA INSERITO UNA UM O UNA SKU
            clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredNone
            RetCode = clsShowUtility.CheckSkuOrUnitaMagEnteredString(Me.txtCodiceUM.Text, clsWmsJob.SkuOrUnitaMagEntered)
            If (clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredNone) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1526, "", "Codice UDS/SKU non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            clsSapUtility.ResetGiacenzaStruct(WorkGiacenzaUM) 'INIT
            If (clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredSku) Then
                'INSERITO LO SKU : DEVO ESTRARRE LE GIACENZE DELL'UBICAZIONE PER VERIFICARE LO STOCK
                '*************************************************************************
                '>>> SE NON GESTISCO L'INSERIMENTO DEL CODICE MATERIALE DEVO CARICARE
                '>>> LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
                clsSapUtility.ResetUbicazioneStruct(DatiRicercaSKUUbicazione) 'init
                clsSapUtility.ResetGiacenzaStruct(DatiRicercaSKUGiacenza) 'init
                clsWmsJob.objDataTableGiacenzeOriInfo.Rows.Clear() 'INIT
                DatiRicercaSKUUbicazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo
                DatiRicercaSKUGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
                DatiRicercaSKUGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
                DatiRicercaSKUGiacenza.SKU = UCase(Me.txtCodiceUM.Text)
                DatiRicercaSKUGiacenza.MagazzinoLogico = UCase(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico)
                'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
                RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(DatiRicercaSKUUbicazione, DatiRicercaSKUGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeSKUOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, Nothing, FlagErrorSkuElaboration, SapFunctionError, False)
                If (RetCode <> 101) And (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (RetCode = 101) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1558, "", "Nessuna giacenza trovata con lo SKU/UBICAZIONE inseriti.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(789, "", "Verificare giacenze e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_MATNR = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1553, "", "Attenzione! Errore in elaborazione dello SKU per determinare CODICE MATERIALE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1554, "", "Controllare anagrafica materiale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_CHARG = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1564, "", "Attenzione! Errore in elaborazione dello SKU per determinare la PARTITA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1554, "", "Controllare anagrafica materiale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_ShadeNotFound = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1539, "", "Errore codice SHADE dello SKU non trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1547, "", "Verificare anagrafica SHADE e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_DiffMatnr = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1540, "", "Errore differenza tra CODICE MATERIALE e SKU letto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_MatnrClass001 = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1541, "", "Errore classificazione 001 del materiale non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1456, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_DiffClass001 = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1542, "", "Errore differenza tra codice classificazione 001 e codice dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1546, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_DiffTono = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1543, "", "Errore differenza tra il tono della produzione e tono dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                If (FlagErrorSkuElaboration.FlagErrorSku_DiffCalibro = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1544, "", "Errore differenza tra il calibro della produzione e calibro dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If
                'If (CheckSkuOk <> True) Then
                '    ErrDescription = clsAppTranslation.GetSingleParameterValue(1229, "", "Il codice SKU specificato non è congruente con i dati della produzione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '    Me.txtCodiceUM.Text = ""
                '    Me.txtCodiceUM.Focus()
                '    Exit Sub
                'End If
                If (GetDataGiacenzeSKUOk <> True) Or (clsWmsJob.objDataTableGiacenzeOriInfo Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Me.txtCodiceUM.Focus()
                    Exit Sub
                End If


                If (clsWmsJob.objDataTableGiacenzeOriInfo.Rows.Count <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1558, "", "Nessuna giacenza trovata con lo SKU/UBICAZIONE inseriti.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If (clsWmsJob.objDataTableGiacenzeOriInfo.Rows.Count = 1) Then
                    clsWmsJob.FlagFoundOneStockWithSKU = True
                ElseIf (clsWmsJob.objDataTableGiacenzeOriInfo.Rows.Count > 1) Then
                    ''IN QUESTO CASO DEVO RICHIEDERE DI LEGGERE LA PALLET DI SE HO 
                    'ErrDescription = clsAppTranslation.GetSingleParameterValue(1559, "", "Troppe giacenze trovate.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                    'MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'Exit Sub
                End If


                'COPIO I DATI DELLA GIACENZA DAL DATAROW ALLA STRUTURA DI LAVORO
                WorkDataRow = clsWmsJob.objDataTableGiacenzeOriInfo.Rows(0)
                RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, WorkGiacenzaUM, False)

                'IL CODICE MATERIALE E LA PARTITA DEVONO ESSERE CORRISPONDENTI
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale <> WorkGiacenzaUM.CodiceMateriale) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1431, "", "L'Unita magazzino selezionata non contiene il materiale richiesto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita <> WorkGiacenzaUM.Partita) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1430, "", "L'Unita magazzino selezionata non contiene la partita richiesta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (clsWmsJob.WmsJob.UbicazioneOrigine.Divisione <> WorkGiacenzaUM.UbicazioneInfo.Divisione) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(587, "", "La divisione selezionata non è corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                End If
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico <> WorkGiacenzaUM.MagazzinoLogico) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1827, "", "Il Magazzino Logico selezionato non è corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                'SE ARRIVO QUI LO SKU INSERITO E' CORRETTO E NON CI SONO DUBBI SULLA GIACENZA DA SPOSTARE

                'NEL CASO DELLO SKU SE HO AVUTO PIU' DI UN RECORD DEVO PULIRE IL CAMPO ASSOCIATO ALLA PALLET ID PERCHE' MI GENERA ERRORI NELLA VIDEATA SUCCESSIVA
                If (clsWmsJob.objDataTableGiacenzeOriInfo.Rows.Count > 1) Then
                    WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino = ""
                End If
                'IMPOSTO DATI UBICAZIONE
                InfoUbicazione = WorkGiacenzaUM.UbicazioneInfo


            ElseIf (clsWmsJob.SkuOrUnitaMagEntered = clsDataType.SkuOrUnitaMagEnteredEnum.SkuOrUnitaMagEnteredUnitaMagazzino) Then
                'CASO DI IMMISSIONE DELLA PALLET ID =>>> CHECK NUMERO UM
                clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
                DatiRicercaUbicazione.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
                'DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
                DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUbicazione, True, True, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, WorkUM_OnFinalLocation, False, False, WorkFlagCheckLenum, SapFunctionError, False)
                If (CheckUnitaMagazzinoOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(668, "", "L'Unita Magazzino specificata non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'SE LA PALETTA E' IN STATO BLOCCATO LO DEVO SEGNALARE E NON E' POSSIBILE PRELEVARLA
                If (WorkFlagCheckLenum.Flag_UM_BLOCKED = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1828, "", "L'Unita magazzino selezionata e' bloccata alla movimentazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                'SE LA PALETTA E' IN STOCK SPECIALE LO DEVO SEGNALARE E NON E' POSSIBILE PRELEVARLA
                If (WorkFlagCheckLenum.Flag_UM_SPECIAL_STOCK = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1829, "", "L'Unita magazzino selezionata e' in stato di STOCK SPECIALE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                'IL CODICE MATERIALE E LA PARTITA DEVONO ESSERE CORRISPONDENTI
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale <> WorkGiacenzaUM.CodiceMateriale) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1431, "", "L'Unita magazzino selezionata non contiene il materiale richiesto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita <> WorkGiacenzaUM.Partita) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1430, "", "L'Unita magazzino selezionata non contiene la partita richiesta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (clsWmsJob.WmsJob.UbicazioneOrigine.Divisione <> WorkGiacenzaUM.UbicazioneInfo.Divisione) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(587, "", "La divisione selezionata non è corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico <> WorkGiacenzaUM.MagazzinoLogico) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1827, "", "Il Magazzino Logico selezionato non è corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1826, "", "Contattare il responsabile di turno.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (WorkUM_OnFinalLocation = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1825, "", "L'Unita magazzino selezionata non e' stoccata in una posizione di picking valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                'IMPOSTO DATI UBICAZIONE
                InfoUbicazione = WorkGiacenzaUM.UbicazioneInfo

                '*******************************************************************************************************
                '>>> SE L'OPERATORE HA SCELTO UNA UBICAZIONE DIVERSA FACCIO UNA SEGNALAZIONE ( PER IL PALLET PIENO )
                '*******************************************************************************************************
                '>>> RECUPERO LA GIACENZA DA PRELEVARE PROPOSTA  DALLA STRATEGIA
                RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmPropostaGiacenza)
                If (RetCode = 0) Then
                    'RECUPERO L'INFORMAZIONE DELL'UBICAZIONE
                    wkPropostaUbicazioneInfo = WorkSapWmPropostaGiacenza.OdaInputDestInfo.UbicazioneInfo

                    'L'UBICAZIONE SELEZIONATA DALL'OPERATORE
                    If (InfoUbicazione.NumeroMagazzino <> wkPropostaUbicazioneInfo.NumeroMagazzino) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1550, "", "Attenzione! L'Ubicazione selezionata ha un NUMERO MAGAZZINO diverso da quello proposto dalla stategia.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If


                    If (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        '>>> NEL CASO DI PALLET FULL FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                        '>>> NEL CASO DI PALLET PARZIALE COSTRINGO L'OPERATORE A PRENDERE DA QUESTA UBICAZIONE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                        '>>> NEL CASO DI PALLET PARZIALE COSTRINGO L'OPERATORE A PRENDERE DA QUESTA UBICAZIONE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If


            'MEMORIZZO L'INFORMAZIONE NELLA CLASSE DI GESTIONE
            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo = InfoUbicazione

            'IMPOSTO LA GIACENZA RECUPERATA CON LA LETTURA DELLA UM
            clsWmsJob.MaterialeSelStockGiacenzaOri = WorkGiacenzaUM
            clsWmsJob.MaterialeSelStockGiacenzaOri.NrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
            RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_5_Sel_CodMatOrigine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceUM.Focused = True) And (Me.txtCodiceUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
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

    Private Sub frmPickingMerci_Code_5_Sel_CodMatOrigine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim wkInfoPrelievo As String
        Dim wkUbicazioneInfo As clsDataType.SapWmUbicazione

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.lblCodiceUMProposto.Text = clsAppTranslation.GetSingleParameterValue(162, lblCodiceUMProposto.Text, "Proposta:")
            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1292, lblCodiceUM.Text, "Codice UM/SKU")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.Text = clsAppTranslation.GetSingleParameterValue(1287, Me.Text, "Picking Appr. (5)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
            Me.lblInfoTaskLinesOnWork.Text = clsWmsJob.TaskLines.ShowTaskLinesLabelInfoForUserString()

            Me.cmdDropUDS.Text = clsAppTranslation.GetSingleParameterValue(1688, Me.cmdDropUDS.Text, "Drop Pallet")

#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
            Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, Me.cmdPreviousScreen.Text, "<")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, Me.cmdNextScreen.Text, ">")
#Else
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
			Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, Me.cmdPreviousScreen.Text, "<")
			Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, Me.cmdNextScreen.Text, ">")
#End If
            '**************************************    


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

            'Evidenzio la riga della Qtà da prelevare
            Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
            Me.txtInfoJobSelezionato.SelectionBackColor = Color.Yellow


            'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
            If (txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                Me.txtInfoJobSelezionato.SelectionBackColor = Color.LightCoral

            End If


            '*************************************************************************************
            ' >>> VISUALIZZO LE INFO PRELIEVO ASSOCIATE ALLA MISSIONE
            RetCode = clsWmsJob.GetJobInfoPrelievo(wkInfoPrelievo)
            Me.txtInfoPrelievo.Text = wkInfoPrelievo

            '***************************************************************************************************
            ' >>> VISUALIZZO LE INFORMAZIONI DELLA UBICAZIONE / PALETTA DA PRELEVARE RITORNATE DALLA STRATEGIA
            RetCode = ShowStrategyProposalInfoForOperator()


            'GESTISCO MESSAGGIO STATO DI ERRORE
            If (clsWmsJob.WmsJob.ZWMS_ERROR_CODE <> "") Or (txtLocationProposal.Text = "") Then

                wkInfoPrelievo += clsAppTranslation.GetSingleParameterValue(1694, "", "WARNING:")
                wkInfoPrelievo += vbCrLf
                wkInfoPrelievo += clsAppTranslation.GetSingleParameterValue(1697, "", "Stock disponibile non trovato.")
                wkInfoPrelievo += vbCrLf

                Me.txtInfoPrelievo.BackColor = Color.LightCoral
                Me.txtInfoPrelievo.Text = wkInfoPrelievo

            Else

                Me.txtInfoPrelievo.BackColor = Color.LightGray

            End If

            '***************************************************************************************************
            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)


            'Disabilito il Copia/Incolla
            If (clsUser.SapWmsUser.PROFID = "ADMIN") Then
                Me.txtCodiceUM.ShortcutsEnabled = True
            Else
                Me.txtCodiceUM.ShortcutsEnabled = False
            End If


            clsWmsJob.FlagFoundOneStockWithSKU = False 'RESET FLAG

            Me.txtCodiceUM.Focus()


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
    Private Sub cmdDropUDS_Click(sender As Object, e As EventArgs) Handles cmdDropUDS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1512, "", "Si desidera veramente eseguire il DROP del KTAG attivo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'ESEGUO TUTTE LE OPERAZIONI PER VERIFICARE LA VALIDITA E PREPARAZONEDELLA VIDEATA DROP
            RetCode = clsWmsJob.ChecBeforeExecScreenDropUDS(Me, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DI "DROP" DELL'UDS
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDropUDS, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdShowStock_Click(sender As Object, e As EventArgs) Handles cmdShowStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkStrategyGiacenza As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim GetDataGiacenzeOk As Boolean = False
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '******************************************************************************
            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEL MAGAZZINO
            '******************************************************************************

            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkStrategyGiacenza)
            If (RetCode <> 0) Then
                '??? MSG ERRORE
                Exit Sub
            End If

            'VISUALIZZO LO STOCK DELLO STESSO MATERIALE NEL TIPO MAGAZZINO ESTRAPOLATO DALLA LOGICA

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.TipoMagazzino
            WorkUbicazione.Ubicazione = "*"

            WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkGiacenza.MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            ''>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            'ReDim WorkExcludeUbicazioni(0)
            'WorkExcludeUbicazioni(0) = WorkStrategyGiacenza.UbicazioneInfo

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VISUALIZZO INFO DELLE GIACENZE DELLO STESSO MATERIALE / PARTITE
            frmPickingMerci_ShowStockInfoForm = New frmPickingMerci_ShowStockInfo
            frmPickingMerci_ShowStockInfoForm.objDataTableGiacenzeInfo = clsWmsJob.objDataTableGiacenzeOriInfo
            frmPickingMerci_ShowStockInfoForm.SourceForm = Me
            frmPickingMerci_ShowStockInfoForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Function ShowStrategyProposalInfoForOperator() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim wkUbicazioneInfo As clsDataType.SapWmUbicazione
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowStrategyProposalInfoForOperator = 1 'init at error

            'RECUPERO LA GIACENZA DA PRELEVARE PROPOSTA  DALLA STRATEGIA
            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                'VERIFICO SE DEVO SEGNALARE UNA INFORMAZIONE DI PRELIEVO

                wkUbicazioneInfo = WorkSapWmGiacenza.OdaInputDestInfo.UbicazioneInfo

                'RECUPERO INFOMAZIONI DI INFO PRELIEVO ASSOCIATE ALLA MISSIONE
                Me.txtLocationProposal.Text = ""

                '>>> MOSTRO L'INFORMAZIONE SOLO SE HO UNA SOLUZIONE TROVATA
                If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.Ubicazione, True) = True) And (clsWmsJob.StockSelezionatoUtente.Ubicazione <> wkUbicazioneInfo.Ubicazione) Then
                    '>>> CASO PARTICOLARE IN CUI VISUALIZZO L'UBICAZIONE SELEZIONATA DALLO USER DALLA VIDEATA STOCK 
                    Me.txtLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(950, Me.txtUMProposal.Text, "UBICAZIONE:") & "*" & clsWmsJob.StockSelezionatoUtente.TipoMagazzino & "-" & clsWmsJob.StockSelezionatoUtente.Ubicazione
                Else
                    '>>> CASO NORMALE DI VISUALIZZAZIONE PROPOSTA RITORNATA DALLA STRATEGIA 
                    Me.txtLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(950, Me.txtUMProposal.Text, "UBICAZIONE:") & wkUbicazioneInfo.TipoMagazzino & "-" & wkUbicazioneInfo.Ubicazione
                End If
            End If


            If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino, True) = True) And (clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino) <> clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(wkUbicazioneInfo.UnitaMagazzino)) Then
                '>>> CASO PARTICOLARE IN CUI VISUALIZZO LA PALETTA SELEZIONATA DALLO USER DALLA VIDEATA STOCK 
                Me.txtUMProposal.Text = clsAppTranslation.GetSingleParameterValue(956, "", "UM:") & "*" & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino)
            Else
                '>>> CASO NORMALE DI VISUALIZZAZIONE PROPOSTA RITORNATA DALLA STRATEGIA 
                'Me.txtUMProposal.Text = clsAppTranslation.GetSingleParameterValue(956, "", "UM:") & clsSapUtility.FormattaStringaUnitaMagazzino(wkUbicazioneInfo.UnitaMagazzino)
                Me.txtUMProposal.Text = "**********"
            End If

            '>>> SE HO UNO SKU VALIO LO VISUALIZZO
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.SKU, True) = True) Then
                Me.txtUMProposal.Text = Me.txtUMProposal.Text & " - " & "SKU:" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.SKU
            End If

            '>>> MOSTRO QTA LEGATA ALLA PALETTA PROPOSTA DA PRELEVARE
            Me.txtQtyStockProposal.Text = clsAppTranslation.GetSingleParameterValue(1507, "", "QTA PALLET:") + " " + Trim(Str(Int(WorkSapWmGiacenza.QtaTotaleLquaDispoUdMAcq))) + " " + WorkSapWmGiacenza.UnitaDiMisuraAcquisizione
            Me.txtQtyStockProposal.Text = Me.txtQtyStockProposal.Text + " ( " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLquaInStocFullPallet)) + " PL/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLquaInStocPartialPallet)) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleInStockSfusi)) + " " + WorkSapWmGiacenza.UnitaDiMisuraPezzo + " ) "

            '>>> MOSTRO QTA LEGATA ALLA UBICAZIONE PROPOSTA DA PRELEVARE
            Me.txtQtyLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(1508, "", "QTA UBI.:") + " " + Trim(Str(Int(WorkSapWmGiacenza.QtaTotaleLocationUdMAcq))) + " " + WorkSapWmGiacenza.UnitaDiMisuraAcquisizione
            Me.txtQtyLocationProposal.Text = Me.txtQtyLocationProposal.Text + " ( " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationFullPallet)) + " PL/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationPartialPallet)) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationSfusi)) + " " + WorkSapWmGiacenza.UnitaDiMisuraPezzo + " ) "
            Me.lblNumPalletOfLocation.Text = clsAppTranslation.GetSingleParameterValue(1514, "", "PALLET IN UBICAZIONE:") + Trim(Str(WorkSapWmGiacenza.NumeroUDCLocation))

            ShowStrategyProposalInfoForOperator = RetCode 'se = 0 tutto ok


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Function ConfermaSelezioneStock() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneStock = 1 'init at error

            Me.Focus()
            If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino <> "") Then
                'Me.txtCodiceUM.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino

                'IMPOSTO OGGETTO DEL JOB PERVISUALIZZARE INFO DELLO STOCK SELEZIONATO ( CHE BYPASSA LA PROPOSTA DELLA STRATEGIA )
                clsWmsJob.StockSelezionatoUtente = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata

                '>>> ESEGUO REFRESH DELLE INFO DELL'UBICAZIONE SUGGERITA PER IL PRELIEVO
                RetCode = ShowStrategyProposalInfoForOperator()

                clsSelezioneUnitaMagazzino.ClearAllData()
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneStock = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdJobFunctions_Click(sender As Object, e As EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
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

    Private Sub txtCodiceUM_LostFocus(sender As Object, e As EventArgs) Handles txtCodiceUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtCodiceUM.Text <> "") Then
                Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PBoxInsPalletId.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkStrategyGiacenza As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim GetDataGiacenzeOk As Boolean = False
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '******************************************************************************
            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEL MAGAZZINO
            '******************************************************************************

            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkStrategyGiacenza)
            If (RetCode <> 0) Then
                '??? MSG ERRORE
                Exit Sub
            End If


            'RESET CLASSE DI APPOGGIO DATI
            clsSelezioneUnitaMagazzino.ClearAllData()


            'VISUALIZZO LO STOCK DELLO STESSO MATERIALE NEL TIPO MAGAZZINO ESTRAPOLATO DALLA LOGICA

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.NumeroMagazzino
            'WorkUbicazione.TipoMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.TipoMagazzino
            WorkUbicazione.TipoMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino
            'WorkUbicazione.Ubicazione = "*"
            'WorkUbicazione.Ubicazione = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.Ubicazione
            WorkUbicazione.Ubicazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione


            WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkGiacenza.MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            ''>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            'ReDim WorkExcludeUbicazioni(0)
            'WorkExcludeUbicazioni(0) = WorkStrategyGiacenza.UbicazioneInfo

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            clsSelezioneUnitaMagazzino.SourceForm = frmPickingMerci_Code_5_Sel_CodMatOrigineForm


            'VISUALIZZO INFO DELLE GIACENZE DELLO STESSO MATERIALE / PARTITE
            Me.txtCodiceUM.Text = ""

            frmPickingMerci_Code_InsPalletIdForm = New frmPickingMerci_Code_InsPalletId
            frmPickingMerci_Code_InsPalletIdForm.objDataTableGiacenzeInfo = clsWmsJob.objDataTableGiacenzeOriInfo
            frmPickingMerci_Code_InsPalletIdForm.SourceForm = Me
            frmPickingMerci_Code_InsPalletIdForm.Show()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtCodiceUM_TextChanged(sender As Object, e As EventArgs) Handles txtCodiceUM.TextChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim instring As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'Se utente administrator evito controllo input
            If (clsUser.SapWmsUser.PROFID = "ADMIN") Then
                Exit Sub
            End If


            'Inizio Lettura BARCODE
            If Len(txtCodiceUM.Text) = 1 Then
                wkStart_time_read = Now
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Inizio - Barcode Scan: " + wkStart_time_read)
                Exit Sub
            End If

            'Fine Lettura BARCODE
            If Len(txtCodiceUM.Text) > 8 Then

                'CASO IN CUI IMPOSTIAMO IL VALORE DALLA VIDEATA DI PICKING ISSUE
                If (wkStart_time_read = Date.MinValue) Then
                    wkStart_time_read = Now
                End If

                wkEnd_time_read = Now

                'Controllo tempo di inserimento BARCODE, se è maggiore di 2 sec e minore di 10 min. 
                'operatore ha inserito manualmente il Pallet ID
                If ((wkEnd_time_read - wkStart_time_read).TotalSeconds > 2) Then

                    'Operatore ha digitato manualmente il Codice Pallet Id  (Errore)
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1816, "", "Errore Pallet Id inserito manualmente. Prego usare il lettore BARCODE.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    instring = "Fine - Barcode Scan: " + wkEnd_time_read
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)
                    txtCodiceUM.Text = ""

                    'Exit
                Else

                End If

                instring = "Fine - Barcode Scan: " + ((wkEnd_time_read - wkStart_time_read).TotalSeconds).ToString + " secs"
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


    'Private Sub txtCodiceUM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodiceUM.KeyDown
    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE

    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        'Intercetto il Ctrl+C / Ctrl+V  per impedire il copia/incolla del Pallet Id
    '            If (e.KeyCode = Keys.V) And (clsUser.SapWmsUser.PROFID <> "ADMIN") Then
    '                e.SuppressKeyPress = True
    '                txtCodiceUM.Text = ""
    '                Exit Sub
    '            End If


    '            '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Sub

    Public Function ConfermaSelezioneUnitaMagazzino() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneUnitaMagazzino = 1 'init at error

            Me.Focus()
            If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino <> "") Then
                wkStart_time_read = Now
                Me.txtCodiceUM.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneUnitaMagazzino = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class