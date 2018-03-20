Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmEM_FromStock_Part_3_ConfQta
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_3_ConfQta"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


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
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType.EM_Stock_SourceTypeStockList, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim CheckStockOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim Index As Long = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim UbicazioneDestFound As Boolean = False
        Dim WorkDatiUbicaDest() As clsDataType.SapWmGiacenza
        Dim NumUbiDestFound As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'SE HO ATTIVA LA GESTIONE DELL'UDM LO DEVO GESTIRE
            If (clsEMFromStock.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
                If (Me.txtUM_Origine.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(431, "", "Codice UM non corretto.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            If (Me.txtQtaConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
            If (wkQtaConfermata <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VERIFICO LA QTA IMMESSA
            If (wkQtaConfermata > clsEMFromStock.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(481, "", "Qtà Confermata superiore a quella della GIACENZA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> CONFERMO QTA CONFERMATA DIVERSA DA QUELLA DELLA GIACENZA
            If (wkQtaConfermata <> clsEMFromStock.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(482, "", "Si desidera veramente confermare una QTA' diversa da quella prevista ? ") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
            End If

            '*************************************************************************
            'VERIFICO IN SAP (CODICE MATERIALE, GIACENZA, QTA SE CORRETTA, CODICE UDM)
            WorkDatiRicercaStock.CodiceMateriale = clsEMFromStock.MaterialeGiacenza.CodiceMateriale
            WorkDatiRicercaStock.Partita = clsEMFromStock.MaterialeGiacenza.Partita
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = wkQtaConfermata
            WorkDatiRicercaStock.UnitaDiMisuraBase = clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione
            WorkDatiRicercaStock.UbicazioneInfo.Divisione = clsEMFromStock.SourceUbicazione.Divisione
            WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = clsEMFromStock.SourceUbicazione.NumeroMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = clsEMFromStock.SourceUbicazione.TipoMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = clsEMFromStock.SourceUbicazione.Ubicazione
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, SapFunctionError, False, Nothing)
            If (CheckStockOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(436, "", "Materiale o Qtà specificata non trovato in stock.") & vbCrLf
                ErrDescription = ErrDescription & "Qty:" & Me.txtQtaConfermata.Text & vbCrLf
                ErrDescription = ErrDescription & "Tip.Mag:" & WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino & vbCrLf
                ErrDescription = ErrDescription & "Ubicaz.:" & WorkDatiRicercaStock.UbicazioneInfo.Ubicazione & vbCrLf
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E MEMORIZZO I DATI DELL'ENTRATA MERCE
            '>>> SALVO E VISUALIZZO I DATI DELLO STOCK TROVATO
            'COME DATI DI GIACENZA TENGO QUELLI DELLA GIACENZA VERIFICATA
            clsEMFromStock.MaterialeGiacenza = WorkDatiGiacenza
            clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore = wkQtaConfermata

            'IMPOSTO I DATI DELL'UBICAZIONE DI ORIGINE
            clsEMFromStock.SourceUbicazione = WorkDatiGiacenza.UbicazioneInfo

            '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
            RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.StockSelezionatoUtente)

            'RECUPERO LE POSSIBILI DESTINAZIONI IN BASE ALLA LOGICA DI STRATEGIA
            RetCode = clsSapWS.Call_ZWS_MB_GET_WM_INPUT_DEST_BASIC(clsEMFromStock.MaterialeGiacenza, clsEMFromStock.SourceUbicazione, clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore, clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione, Nothing, Nothing, False, UbicazioneDestFound, WorkDatiUbicaDest, clsEMFromStock.DescrUbiDestinazione, SapFunctionError, False)
            If (UbicazioneDestFound = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(437, "", "Ubicazione destinazione non trovata.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            NumUbiDestFound = UBound(WorkDatiUbicaDest)
            ReDim clsEMFromStock.UbicazioneDestProposte(NumUbiDestFound)
            For Index = 0 To (NumUbiDestFound - 1)
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

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_3_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM_Origine.Focused = True) And (Me.txtUM_Origine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

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
                End If
            End If
            If ((Me.cmdPreviousScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdPreviousScreen_Click(Me, e)
                End If
            End If
            If ((Me.cmdAbortScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdAbortScreen_Click(Me, e)
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

    Private Sub frmEM_FromStock_Part_3_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblUM_Origine.Text = clsAppTranslation.GetSingleParameterValue(70, Me.lblUM_Origine.Text, "UM")
            Me.lblQtaDisponibile.Text = clsAppTranslation.GetSingleParameterValue(85, Me.lblQtaDisponibile.Text, "Qta Disp.")
            Me.txtQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, Me.txtQtaConfermata.Text, "Qta Conf.")
            Me.txtUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(69, Me.txtUDMQuantita.Text, "Udm")
            Me.Text = clsAppTranslation.GetSingleParameterValue(84, Me.Text, "EM - Bem (3)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************


            Me.txtInfoJobSelezionato.Text = clsShowUtility.FromSapWmUbicazioneStructToString(clsEMFromStock.SourceUbicazione, 0) & vbCrLf & clsShowUtility.FromSapWmGiacenzaStructToString(clsEMFromStock.MaterialeGiacenza, Nothing, 1)

            Me.txtQtaDisponibile.Text = clsEMFromStock.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            Me.txtUDMQuantita.Text = clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione
            If (clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                Me.txtQtaConfermata.Text = clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore
            Else
                Me.txtQtaConfermata.Text = clsEMFromStock.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            End If

            'VERIFICO SE IL TIPO MAGAZZINO DI ORIGINE PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
            If (clsEMFromStock.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
                Me.txtUM_Origine.Enabled = True
                Me.txtUM_Origine.BackColor = Color.White
                Me.txtUM_Origine.Focus()
            Else
                Me.txtUM_Origine.Enabled = False
                Me.txtUM_Origine.BackColor = Color.Gray
                Me.txtQtaConfermata.Focus()
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
End Class