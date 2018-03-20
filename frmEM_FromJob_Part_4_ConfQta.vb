Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmEM_FromJob_Part_4_ConfQta
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_4_ConfQta"

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
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ErrDescription = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim wkQtaConfermata As Double = 0
        Dim wkQtaConfermataSfusi As Double = 0
        Dim wkQtaConfermataRettificaPositiva As Double = 0
        Dim wkQtaConfermataRettificaNegativa As Double = 0
        Dim wkQtaPrevista As Double = 0
        Dim wkQtaPrevistaSfusi As Double = 0
        Dim wkCheckQtyOk As Boolean = False
        Dim CheckStockOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeAll() As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkString As String = ""
        Dim UbicazioneDestFound As Boolean = False
        Dim WorkCatchErrorHappened As Boolean = False
        Dim EntrataMerceDaOdp As Boolean = False
        Dim NumDestinazioni As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)
            Me.txtQtaSfusiConfermata.Text = UCase(Me.txtQtaSfusiConfermata.Text)

            If (Me.txtQtaConfermata.Text = "") And (Me.txtQtaSfusiConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtQtaConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaSfusiConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'NECESSARIO PER EVENTUALI DECIMALI
            If (Me.txtQtaConfermata.Text <> "") Then
                wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
                If (wkQtaConfermata <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                wkQtaConfermataSfusi = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)
                If (wkQtaConfermataSfusi <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            '**************************************************************************
            '>>> VERIFICO SE LA QTA CONFERMATA E' NEI RANGE AMMESSI
            '**************************************************************************
            If (Me.txtQtaPrevista.Text <> "") Then
                wkQtaPrevista = System.Convert.ToDouble(Me.txtQtaPrevista.Text)
            End If
            If (Me.txtQtaPrevistaSfusi.Text <> "") Then
                wkQtaPrevistaSfusi = System.Convert.ToDouble(Me.txtQtaPrevistaSfusi.Text)
            End If

            RetCode = clsEMFromJob.CheckQtyConfirmedByUser(wkQtaConfermata, wkQtaPrevista, wkQtaConfermataSfusi, wkQtaPrevistaSfusi, False, wkCheckQtyOk, wkQtaConfermataRettificaPositiva, wkQtaConfermataRettificaNegativa)
            If (wkCheckQtyOk = False) Then
                '>>> ESCO PERCHE' QTA IMMESSA NON E' CORRETTA
                Exit Sub
            End If

            '******************************************************************************
            'VERIFICO IN SAP (CODICE MATERIALE, GIACENZA, QTA SE CORRETTA, CODICE UDM)
            '******************************************************************************
            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkDatiRicercaStock)
            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkDatiGiacenza)
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = wkQtaConfermata
            WorkDatiRicercaStock.UnitaDiMisuraBase = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            WorkDatiRicercaStock.QuantitaConfermataSfusiOperatore = wkQtaConfermataSfusi
            WorkDatiRicercaStock.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkDatiRicercaStock.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkDatiRicercaStock.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione
            WorkDatiRicercaStock.UbicazioneInfo.UnitaMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, SapFunctionError, False, Nothing)
            If (CheckStockOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(436, "", "Materiale o Qtà specificata non trovato in stock.") & vbCrLf
                ErrDescription = ErrDescription & "Qty:" & Me.txtQtaConfermata.Text & vbCrLf
                ErrDescription = ErrDescription & "Tip.Mag:" & WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino & vbCrLf
                ErrDescription = ErrDescription & "Ubicaz.:" & WorkDatiRicercaStock.UbicazioneInfo.Ubicazione & vbCrLf
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If





            'IMPOSTO FLAG PER CASO DI ENTRATA MERCE DA ODP (PER PRODUZIONE)
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.NumeroOrdineDiProduzione, True) = True) Then
                EntrataMerceDaOdp = True
            Else
                EntrataMerceDaOdp = False
            End If


            If (clsWmsJob.WmsJob.ForcedConfirmUbicazioneSpunta = True) Then
                'IN QUESTO CASO LA DESTINAZIONE E' LA BAIA DI LAVORO

                '???? GESTIRE CONTRLLO DELLA SOLA GIACENZA ( STOCK )
                clsWmsJob.WmsJob.UbicazioneDestinazione = clsSelezioneUbicazioneSpunta.UbicazioneSpuntaSelezionata
            Else
                'ESEGUO VERIFICA PRESENZA STOCK DA TRASFERIRE E OTTENGO LA DESTINAZIONE MIGLIORE PER LA MERCE CHE ENTRA
                RetCode = clsWmsJob.GetJobPutawayBestDestination(WorkDatiRicercaStock, False, CheckStockOk, UbicazioneDestFound, WorkCatchErrorHappened)
                If (WorkCatchErrorHappened = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(434, "", "Verificato probabile errore di rete (CatchError).") & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(435, "", "Verificare segnale connessione e riprovare.") & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (CheckStockOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(436, "", "Materiale o Qtà specificata non trovato in stock.") & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(438, "", "Qta:") & Me.txtQtaConfermata.Text & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(439, "", "Tip.Mag:") & WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(440, "", "Ubicaz.:") & WorkDatiRicercaStock.UbicazioneInfo.Ubicazione & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (UbicazioneDestFound = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(437, "", "Ubicazione destinazione non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'SE ARRIVO QUI LA QTA E' STATA CONFERMATA PER CUI LA SALVO NELLA STRUTTURA DEL JOB
            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = wkQtaConfermata
            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore = wkQtaConfermataSfusi

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJob_Part_4_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
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
            If ((Me.cmdPreviousScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdPreviousScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdAbortScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdAbortScreen_Click(Me, e)
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

    Private Sub frmEM_FromJob_Part_4_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkQtàPrevista As Double = 0
        Dim WorkQtàSfusiPrevista As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(1211, Me.lblQtaPrevista.Text, "Richiesta") '67 '1211
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(1212, Me.lblQtaConfermata.Text, "Confermata") '68 '1212
            Me.lblQtaSfusiConfermata.Text = clsAppTranslation.GetSingleParameterValue(1461, Me.lblQtaSfusiConfermata.Text, "Sfusi")
            Me.lblUDMQuantità.Text = clsAppTranslation.GetSingleParameterValue(69, Me.lblUDMQuantità.Text, "Udm")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1206, Me.Text, "EM - Bem (3)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************

            'SE NON CI SONO SFUSI LA CASELLA SFUSI VA DISABILITATA
            Me.txtQtaPrevistaSfusi.Text = ""

            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ > 0) Then
                'MISSIONE CON SFUSI
                Me.txtQtaSfusiConfermata.Enabled = True
                Me.txtQtaSfusiConfermata.BackColor = Color.White
            Else
                'MISSIONE SENZA SFUSI
                Me.txtQtaSfusiConfermata.Enabled = False
                Me.txtQtaSfusiConfermata.BackColor = Color.Gray
            End If

            'RECUPERO QTA PROPOSTA X OPERATORE
            RetCode = clsEMFromJob.GetJobcConfirmQtyProposal(WorkQtàPrevista, WorkQtàSfusiPrevista, True)
            If (RetCode = 0) Then
                Me.txtQtaPrevista.Text = WorkQtàPrevista

                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore > 0) Then
                    '>>> NEL CASO DI RITORNO-INDIETRO RIVISUALIZZO QUELLO CHE ERA STATO CONFERMATO NELLO STEP
                    Me.txtQtaConfermata.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
                Else
                    'SE ABILITA LA CONFERMA DELLA QTA  RESIDUA DA PARTE DELL'OPERATORE, ALLORA NEL CASO
                    'DEL RESIDUO NON PROPONGO NESSUNA QTA
                    If (EntrataMerceAbilitaDigitazioneResiduo = True) Then
                        If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) And (WorkQtàPrevista = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) Then
                            Me.txtQtaConfermata.Text = WorkQtàPrevista
                        Else
                            'IN QUESTO CASO NON PROPONGO NULLA ( L'OPERATORE DEVE DIGITARE  LA QTA )
                            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ > 0) Then
                                Me.txtQtaPrevistaSfusi.Text = WorkQtàSfusiPrevista
                                If (WorkQtàPrevista <> Int(WorkQtàPrevista)) Then
                                    '>>> NEL CASO DI SFUSI LA QTA IN SCATOLE VIENE TRONCATA ALL'INTERO
                                    Me.txtQtaPrevista.Text = Int(WorkQtàPrevista)
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'RINFRESCO INFORMAZIONI PER UTENTE
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPutAwayInfoForUserString(1)

            Me.txtUDMQuantita.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            Me.txtUDMQuantitaSfusi.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtQtaConfermata.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Function RefreshDatiPosizioneAttiva(ByRef outUnloadThisFormDone As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkString As String
        Dim wkExecutionOk As Boolean
        Dim UserAnswer As DialogResult
        Dim wkDescrizioneMateriale As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiPosizioneAttiva = 1 'INIT AT ERROR
            outUnloadThisFormDone = False 'INIT

            'AGGIORNO DATI VARIANTE IMBALLO
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.CodiceMateriale, True) = True) Then
                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo
            End If
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna > 0) Then
                ErrDescription = "Attenzione!Verificate precedenti conferme" & vbCrLf
                ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(419, "", "Qta Prelevata:") & Trim(Str(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna)) & vbCrLf
                ErrDescription = ErrDescription & "Qta Da Prelevare:" & Trim(Str(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq)) & vbCrLf
                ErrDescription = ErrDescription & "Qta Totale Prevista:" & Trim(Str(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale)) & vbCrLf
                ErrDescription = ErrDescription & "Verificare e procedere."
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                'INSERISCO CONTROLLO QTA GIA' CONFERMATA
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna >= clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale) Then
                    WorkString = "Attenzione!Entrata Merce già completamente confermata." & vbCrLf & "Si desidera Continuare ? (SI/NO)"
                    UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        WorkString = "Si desidera Continuare con la BEM attiva ? (SI/NO)"
                        UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                            'ESCO DALLA PROCEDURA
                            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)
                            outUnloadThisFormDone = True
                            Exit Function
                        Else
                            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
                            outUnloadThisFormDone = True
                            Exit Function
                        End If
                    End If
                End If
            End If


            RefreshDatiPosizioneAttiva = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class