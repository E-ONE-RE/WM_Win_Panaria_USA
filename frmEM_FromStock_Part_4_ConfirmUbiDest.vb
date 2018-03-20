Imports clsSapWS
Imports clsSapUtility
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic


Public Class frmEM_FromStock_Part_4_ConfirmUbiDest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_4_ConfirmUbiDest"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private UdMTrasfListIndex As Integer = 0


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
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_4_ConfirmUbiDest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmEM_FromStock_Part_4_ConfirmUbiDest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            'hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(162, lblLocationProposal.Text, "Proposta:")
            lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(74, lblUbicazDestConfermata.Text, "Ubicazione Dest.")


            Me.Text = clsAppTranslation.GetSingleParameterValue(97, Me.Text, "EM - Prod. Mul. (2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")
            cmdShowStock.Text = clsAppTranslation.GetSingleParameterValue(253, cmdShowStock.Text, "STOCK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazioneDest.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazioneDest.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************

            'VISUALIZZO INFORMAZIONI PER UTENTE
            Me.txtInfoJobSelezionato.Text = clsEMFromStock.ShowJobPutAwayInfoForUserString(1)

            'INIT CONTROLLI DI DATA ENTRY
            Me.txtUbicazDestConfermata.Text = ""

            '*********************************************************************************************************
            '>>> SE LA LOGICA MI HA TROVATO UNA UBICAZIONE VALIDA LA PROPONGO
            If (Not clsEMFromStock.UbicazioneDestProposte Is Nothing) Then
                If (clsEMFromStock.UbicazioneDestProposte.GetLength(0) > 0) Then

                    '>>> MOSTRO L'INFORMAZIONE SOLO SE HO UNA SOLUZIONE TROVATA
                    If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.Ubicazione, True) = True) And (clsWmsJob.StockSelezionatoUtente.Ubicazione <> clsEMFromStock.UbicazioneDestProposte(0).UbicazioneInfo.Ubicazione) Then
                        '>>> CASO PARTICOLARE IN CUI VISUALIZZO L'UBICAZIONE SELEZIONATA DALLO USER DALLA VIDEATA STOCK 
                        Me.txtLocationProposal.Text = "*" & clsWmsJob.StockSelezionatoUtente.TipoMagazzino & "-" & clsWmsJob.StockSelezionatoUtente.Ubicazione
                    Else
                        '>>> CASO NORMALE DI VISUALIZZAZIONE PROPOSTA RITORNATA DALLA STRATEGIA 
                        Me.txtLocationProposal.Text = clsEMFromStock.UbicazioneDestProposte(0).UbicazioneInfo.TipoMagazzino & "-" & clsEMFromStock.UbicazioneDestProposte(0).UbicazioneInfo.Ubicazione
                    End If
                End If
            End If


            Me.txtUbicazDestConfermata.Enabled = True
            Me.txtUbicazDestConfermata.BackColor = Color.White
            Me.lblUbicazDestConfermata.BackColor = Color.Yellow
            Me.cmdSelectUbicazioneDest.Enabled = True

            If (Not clsEMFromStock.UdMTrasfList Is Nothing) Then
                'AGGIORNO IL NUMERO DI UDC LETTE
                Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsEMFromStock.UdMTrasfList.GetLength(0)
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

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
        Dim RetCodeFinal As Long = 0
        Dim OT_Executed_Ok As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim OT_Executed_Number As String = ""
        Dim OT_Info As New StrctSapMoveSuParams
        Dim UserAnswer As DialogResult
        Dim WorkOutUbicazione As String = ""
        Dim FlagEmProduzione As Boolean = False
        Dim SapWmGiacenza As clsDataType.SapWmGiacenza

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazDestConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazDestConfermata.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazDestConfermata.Text = WorkOutUbicazione

            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            clsSapUtility.ResetUbicazioneStruct(InfoUbicazione)
            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazDestConfermata.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""
            DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_LOC_OCCUPATION = True
            If (clsEMFromStock.UdMTrasfList.Length > 0) Then
                SapWmGiacenza = clsEMFromStock.UdMTrasfList(0)
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_LOCATION = True
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_MATERIAL_CODE = SapWmGiacenza.CodiceMateriale
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_CHARG = SapWmGiacenza.Partita

                DatiRicercaUbicazione.FlagCheckLocationInfo.Quantity = SapWmGiacenza.QtaTotaleLquaInStock
                DatiRicercaUbicazione.FlagCheckLocationInfo.UdMQuantity = SapWmGiacenza.UnitaDiMisuraBase

            End If
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (InfoUbicazione.FlagLocationFull = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1679, "", "L'Ubicazione di DESTINAZIONE e' PIENA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Me.txtUbicazDestConfermata.Text = ""
                Exit Sub
            End If
            If (InfoUbicazione.FlagLocationWithDifferentMaterialCode = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1680, "", "L'Ubicazione di DESTINAZIONE contiene un MATERIALE diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Me.txtUbicazDestConfermata.Text = ""
                Exit Sub
            End If
            If (InfoUbicazione.FlagLocationWithDifferentBatch = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1681, "", "L'Ubicazione di DESTINAZIONE contiene una PARTITA diversa.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Me.txtUbicazDestConfermata.Text = ""
                Exit Sub
            End If

            If (InfoUbicazione.NumeroMagazzino = clsEMFromStock.SourceUbicazione.NumeroMagazzino And _
                    InfoUbicazione.TipoMagazzino = clsEMFromStock.SourceUbicazione.TipoMagazzino And _
                        InfoUbicazione.Ubicazione = clsEMFromStock.SourceUbicazione.Ubicazione) Then

                ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            clsEMFromStock.DestinationUbicazione.Divisione = InfoUbicazione.Divisione
            clsEMFromStock.DestinationUbicazione.NumeroMagazzino = InfoUbicazione.NumeroMagazzino
            clsEMFromStock.DestinationUbicazione.TipoMagazzino = InfoUbicazione.TipoMagazzino
            clsEMFromStock.DestinationUbicazione.Ubicazione = InfoUbicazione.Ubicazione

            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""

            'IMPOSTO IL FLAG CHE MI INDICA L'ENTRATA DA PRODUZIONE
            If (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_FromOdp) Then
                FlagEmProduzione = True
            End If

            'ELABORO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each SapWmGiacenza In clsEMFromStock.UdMTrasfList

                'VERIFICO SE E' IL SECONDO TENTATIVO
                If SapWmGiacenza.NumeroOrdineTrasferimento > 0 Then
                    Continue For
                End If

                'L'UNITA DI MAGAZZINO DI DESTINAZIONE E' LA STESSA DI ORIGINE (PALLET TRASFERITO TUTTO)
                clsEMFromStock.DestinationUbicazione.UnitaMagazzino = clsEMFromStock.SourceUbicazione.UnitaMagazzino

                '**************************************************************************************************************
                '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT
                'IMPOSTO TIPO MOVIMENTO

#If Not APPLICAZIONE_WIN32 = "SI" Then

                OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                'OT_Info.SapOtInfo_Rec.ILetyp = clsTrasfUnitaMagazzino.SourceUbicazione.TipoUnitaMagazzino
                OT_Info.SapOtInfo_Rec.ILetyp = SapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.SapOtInfo_Rec.ILenum = SapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.SapOtInfo_Rec.INltyp = clsEMFromStock.DestinationUbicazione.TipoMagazzino
                OT_Info.SapOtInfo_Rec.INlpla = clsEMFromStock.DestinationUbicazione.Ubicazione

#Else

                OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                'OT_Info.rfcSapOtInfo_Rec.ILetyp = clsTrasfUnitaMagazzino.SourceUbicazione.TipoUnitaMagazzino
                OT_Info.rfcSapOtInfo_Rec.ILetyp = SapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.rfcSapOtInfo_Rec.ILenum = SapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.rfcSapOtInfo_Rec.INltyp = clsEMFromStock.DestinationUbicazione.TipoMagazzino
                OT_Info.rfcSapOtInfo_Rec.INlpla = clsEMFromStock.DestinationUbicazione.Ubicazione

#End If


                RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

                'ESEGUO OT IN SAP
                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_TO_MOVE_SU(OT_Info, True, FlagEmProduzione, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
                If (RetCode <> 0) Then

                    ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(SapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & vbCrLf

                Else
                    '>>> TUTTO OK
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(SapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number & vbCrLf & vbCrLf

                    'REGISTRO UM TRASFERIMENTO CORRETTO
                    clsEMFromStock.UdMTrasfList(UdMTrasfListIndex).NumeroOrdineTrasferimento = OT_Executed_Number

                End If

                'AGGIORNO CONTATORE Errori
                RetCodeFinal += RetCode

                'AGGIORNO CONTATORE UM
                UdMTrasfListIndex += 1

            Next

            'RI-INIZIALIZZO L'INDICE
            UdMTrasfListIndex = 0


            '************************************************************************************************
            ' >>> SE ABILITATO VISUALIZZO RISULTATO OPERAZIONE
            '************************************************************************************************
            If (EntrataMerceAbilitaMsgConfermaSuccesso = True) Or (RetCodeFinal <> 0) Then
                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
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
                    frmEM_FromStock_Part_4_ConfirmUbiDestForm = New frmEM_FromStock_Part_4_ConfirmUbiDest
                    frmEM_FromStock_Part_4_ConfirmUbiDestForm.Show()
                    frmEM_FromStock_Part_4_ConfirmUbiDestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If


            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


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

    Private Sub txtUMDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If Me.txtUMDestConfermata.Text <> "" Then
            '    Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
            'End If

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
        Dim wkTipoMagazzino As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazDestConfermata.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione
            ElseIf (clsUtility.IsStringValid(clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsWmsJob.WmsJob.UbicazioneDestinazione.Divisione
            Else
                'DIVISIONE DI DIONE DI DEFAULT
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



            '*********************************************************************************************************
            '>>> SE LA LOGICA MI HA TROVATO UNA UBICAZIONE VALIDA LA PROPONGO
            If (Not clsEMFromStock.UbicazioneDestProposte Is Nothing) Then
                If (clsEMFromStock.UbicazioneDestProposte.GetLength(0) > 0) Then
                    wkTipoMagazzino = clsEMFromStock.UbicazioneDestProposte(0).UbicazioneInfo.TipoMagazzino
                End If
            End If

            If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.TipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = clsWmsJob.StockSelezionatoUtente.TipoMagazzino
            ElseIf (clsUtility.IsStringValid(wkTipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = wkTipoMagazzino
            End If


            '>>> VEDO TUTTE LE UBICAZIONI
            Dim WorkFilterUbicazione As String = ""
            WorkFilterUbicazione = Me.txtUbicazDestConfermata.Text
            clsSelezioneUbicazione.FilterUbicazione = WorkFilterUbicazione.Substring(0, MinNumCaratteriPerHelpUbicazione) & "*"

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
                'Me.txtUbicazDestConfermata.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
                'clsWmsJob.WmsJob.UbicazioneDestinazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                'clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino

                Me.txtUbicazDestConfermata.Text = ""
                Me.txtLocationProposal.Text = "*" & clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino & "-" & clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione

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

    Private Sub cmdShowStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione

        Dim GetDataOk As Boolean = False
        Dim FlagNoGiacenza As Boolean = False
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '******************************************************************************
            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEL MAGAZZINO
            '******************************************************************************
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsEMFromStock.ClearGiacSameMatPart() 'init

            If (clsEMFromStock.UdMTrasfList Is Nothing) Then
                Exit Sub
            End If
            If (clsEMFromStock.UdMTrasfList.Length <= 0) Then
                Exit Sub
            End If

            WorkGiacenza = clsEMFromStock.UdMTrasfList(0)

            WorkUbicazione.Divisione = WorkGiacenza.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = WorkGiacenza.UbicazioneInfo.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = "" 'clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino 'FORZO A VEDERE LO STOCK DI SOLO IL TIPO MAGAZZINO DECISO DALLA LOGICA
            WorkUbicazione.Ubicazione = "*"
            WorkGiacenza.CodiceMateriale = WorkGiacenza.CodiceMateriale
            WorkGiacenza.Partita = WorkGiacenza.Partita

            '>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            ReDim WorkExcludeUbicazioni(0)
            WorkExcludeUbicazioni(0) = WorkUbicazione

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE/PARTITA ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsEMFromStock.objDataTableGiacSameMatPartInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                FlagNoGiacenza = True
            End If

            If (FlagNoGiacenza = False) And (clsEMFromStock.objDataTableGiacSameMatPartInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                FlagNoGiacenza = True
            End If
            If (FlagNoGiacenza = False) And (clsEMFromStock.objDataTableGiacSameMatPartInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                FlagNoGiacenza = True
            End If

            If (FlagNoGiacenza = True) Then
                '>>> CHIEDO SE RICERCO LO STESSO MATERIALE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(475, "", "Ricercare le giacenze con lo stesso MATERIALE ? ( Partite Diverse )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Exit Sub
                End If

                'RICERCO MATERIALE CON LO STESSO MATERIALE
                WorkUbicazione.Divisione = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
                WorkUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.UbicazioneOrigine.NumeroMagazzino
                WorkUbicazione.TipoMagazzino = clsWmsJob.WmsJob.UbicazioneDestinazione.TipoMagazzino 'FORZO A VEDERE LO STOCK DI SOLO IL TIPO MAGAZZINO DECISO DALLA LOGICA
                WorkUbicazione.Ubicazione = "*"
                WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
                WorkGiacenza.Partita = ""

                'MOSTRO LE GIACENZE DELLO STESSO MATERIALE/PARTITA ESCLUDENDO L'UBICAZIONE DI ORIGINE
                RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsEMFromStock.objDataTableGiacSameMatPartInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
                If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If (clsEMFromStock.objDataTableGiacSameMatPartInfo Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (clsEMFromStock.objDataTableGiacSameMatPartInfo.Rows.Count <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'VISUALIZZO INFO DELLE GIACENZE DELLO STESSO MATERIALE / PARTITE
            frmEM_FromJob_Part_ShowStockForm = New frmEM_FromJob_Part_ShowStock
            frmEM_FromJob_Part_ShowStockForm.SourceForm = Me
            frmEM_FromJob_Part_ShowStockForm.objDataTableGiacenzeInfo = clsEMFromStock.objDataTableGiacSameMatPartInfo
            frmEM_FromJob_Part_ShowStockForm.Show()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

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
                'RetCode = ShowStrategyProposalInfoForOperator()
                Me.txtLocationProposal.Text = "*" & clsWmsJob.StockSelezionatoUtente.TipoMagazzino & "-" & clsWmsJob.StockSelezionatoUtente.Ubicazione


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

End Class
