Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingOdP_UM_2

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingOdP_UM_2"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private CodiceMaterialeSel As String = ""


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingOdP_UM_2_KeyPress(Me, e)

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

    Private Sub cmdOkBC_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkBC.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DatiRicercaWmGiacenza As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim CheckUnitaMagazzinoOk As Boolean
        Dim wkQtaConfermata As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(373, "", "Unità Magazzino non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUM.Text = UCase(Me.txtUM.Text)

            Me.txtUM.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtUM.Text)


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

            'NECESSARIO PER EVENTUALI DECIMALI
            wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
            If (wkQtaConfermata <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            'CHIAMO WS PER VERIFICARE DATI UNITA MAGAZZINO
            RetCode += clsSapUtility.ResetGiacenzaStruct(DatiRicercaWmGiacenza)
            DatiRicercaWmGiacenza.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaWmGiacenza.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaWmGiacenza, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, False, False, Nothing, Nothing, False)
            If (CheckUnitaMagazzinoOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(770, "", "L'Unita Magazzino specificata non è presente a sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'CONTROLLO SE HO SPARATO UN MATERIALE DIVERSO DAL PRIMO SPARATO 
            If CodiceMaterialeSel = "" Then
                CodiceMaterialeSel = clsPickCompOdP.MaterialeGiacenza.CodiceMateriale
            Else

                If clsPickCompOdP.MaterialeGiacenza.CodiceMateriale = CodiceMaterialeSel Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(771, "", "Il Codice Materiale è differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If


            'MEMORIZZO LA QTANTITA' CoNFERMATA DALL'OPERATORE
            WorkGiacenzaUM.QuantitaConfermataOperatore = wkQtaConfermata

            'MEMORIZZO DATI GIACENZA SPECIFICATA
            clsPickCompOdP.SourceUbicazione = WorkGiacenzaUM.UbicazioneInfo

            'IMPOSTO I DATI DEL COMPONENTE DA PRELEVARE
            clsPickCompOdP.MaterialeGiacenza = WorkGiacenzaUM



            'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsTrasfUnitaMagazzino
            If (clsPickCompOdP.UdMTrasfList Is Nothing) Then
                ReDim clsPickCompOdP.UdMTrasfList(0)
            Else
                ReDim Preserve clsPickCompOdP.UdMTrasfList(clsPickCompOdP.UdMTrasfList.Length)
            End If

            clsPickCompOdP.UdMTrasfList(clsPickCompOdP.UdMTrasfList.Length - 1) = clsPickCompOdP.MaterialeGiacenza


            'AGGIUNGO L'UdM SELEZIONATA ALLA LISTA
            Me.txtInfoUMSelezionata.Text += txtUM.Text & " (" & clsPickCompOdP.MaterialeGiacenza.QuantitaConfermataOperatore & " " & clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione & ")" & vbCrLf
            Me.txtUM.Text = ""
            Me.txtQtaConfermata.Text = ""
            Me.txtQtaPrevista.Text = ""
            Me.txtUDMQuantità.Text = ""
            Me.txtUM.Focus()



            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub frmPickingOdP_UM_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
                    Call GetUnitaMagazzinoInfo()
                    Exit Sub
                End If
            End If

            If ((Me.cmdOkBC.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
                    Call Me.cmdOkBC_click(Me, e)
                    Exit Sub
                End If
            End If


            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdUbica_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdUbica.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdUbica_Click(Me, e)
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

    Private Sub frmPickingOdP_UM_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(67, lblQtaPrevista.Text, "Qta Prev.")
            lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, lblUDMQuantita.Text, "UdM")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(184, lblQtaConfermata.Text, "Quantità")

            Me.Text = clsAppTranslation.GetSingleParameterValue(185, Me.Text, "Picking - UM (2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdOkBC.Text = clsAppTranslation.GetSingleParameterValue(274, cmdOkBC.Text, "OK BC")
            cmdUbica.Text = clsAppTranslation.GetSingleParameterValue(8, cmdUbica.Text, "OK")

            '**************************************   


            RefreshDatiMaterialeAttivo()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPreviousScreen_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_UscitaMerci_x_OdP(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            'Riporto Testata contenente dati OdP
            Me.txtInfoUMSelezionata.Text = clsAppTranslation.GetSingleParameterValue(774, "", "OdP :") & clsSapUtility.FormattaStringaNumeroOrdineProduzione(clsPickCompOdP.OrdineProduzioneOrigine.NumeroOrdineProduzione) & vbCrLf & _
                                           clsAppTranslation.GetSingleParameterValue(775, "", "Mat. :") & clsSapUtility.FormattaStringaCodiceMateriale(clsPickCompOdP.OrdineProduzioneOrigine.CodiceMateriale) & vbCrLf & _
                                           clsAppTranslation.GetSingleParameterValue(776, "", "Desc. :") & clsPickCompOdP.OrdineProduzioneOrigine.DescrizioneMateriale & vbCrLf & vbCrLf

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdUbica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUbica.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim wkQtaConfermata As Double = 0
        Dim CheckComponentOk As Boolean = False
        Dim CheckLenumOk As Boolean = False
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        'Dim WorkDatiGiacenzeAll() As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree As clsDataType.SapWmGiacenza
        Dim ComponentiOrdineProduzione() As clsDataType.SapComponenteOrdineProduzione

        Dim WorkCatchErrorHappened As Boolean = False
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim OT_Executed_Number As String = ""
        Dim OT_Executed_Ok As Boolean = False
        Dim stFunctionError As clsBusinessLogic.SapFunctionError
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Controllo sia presente almeno una UM nella lista
            If clsPickCompOdP.UdMTrasfList Is Nothing Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(772, "", "Leggere almeno un componente.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If clsPickCompOdP.UdMTrasfList.Length <= 0 Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(772, "", "Leggere almeno un componente.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'Azzero Variabile Quantità Confermata
            wkQtaConfermata = 0

            'Loop per ottenere quantità pallet confermati
            For Each SapWmGiacenza In clsPickCompOdP.UdMTrasfList
                wkQtaConfermata += SapWmGiacenza.QuantitaConfermataOperatore
            Next


            '******************************************************************************
            'VERIFICO IN SAP (CODICE MATERIALE, GIACENZA, QTA SE CORRETTA, CODICE UDM)
            '******************************************************************************
            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkDatiRicercaStock)
            RetCode = clsSapUtility.ResetGiacenzaStruct(WorkDatiGiacenza)

            'WorkDatiRicercaStock.QtaTotaleDaPrelevare = wkQtaConfermata


            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""

            'ELABORO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each SapWmGiacenza In clsPickCompOdP.UdMTrasfList

                '
                If SapWmGiacenza.NumeroOrdineTrasferimento > 0 Then
                    Continue For
                End If


                WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = wkQtaConfermata

                WorkDatiRicercaStock.CodiceMateriale = SapWmGiacenza.CodiceMateriale
                WorkDatiRicercaStock.Partita = SapWmGiacenza.Partita
                'QUANTITA'
                WorkDatiRicercaStock.UnitaDiMisuraBase = SapWmGiacenza.UnitaDiMisuraAcquisizione

                WorkDatiRicercaStock.UbicazioneInfo.Divisione = SapWmGiacenza.UbicazioneInfo.Divisione
                WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = SapWmGiacenza.UbicazioneInfo.NumeroMagazzino

                WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = SapWmGiacenza.UbicazioneInfo.TipoMagazzino
                WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = SapWmGiacenza.UbicazioneInfo.Ubicazione
                WorkDatiRicercaStock.UbicazioneInfo.UnitaMagazzino = SapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                'ESEGUO UNA UNICA CHIAMATA CHE MI VERIFICA LO STOCK E MI RITORNA LA DESTINAZIONE DA USARE
                RetCode = Call_ZWS_CHECK_ODP_COMPONENTS_UM(clsPickCompOdP.OrdineProduzioneOrigine, WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckComponentOk, CheckLenumOk, ComponentiOrdineProduzione, WorkDatiGiacenzeFree, SapFunctionError, False)
                'RetCode = Call_ZWS_MB_CHECK_STOCK_FREE_EXTRA(WorkDatiRicercaStock, True, DefaultSapUserLanguage, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkDatiGiacenzeAll, SapFunctionError, False, WorkCatchErrorHappened)
                If (WorkCatchErrorHappened = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(434, "", "Verificato probabile errore di rete (CatchError).") & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(435, "", "Verificare segnale connessione e riprovare.") & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (CheckComponentOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(436, "", "Materiale o Qtà specificata non trovato in stock.") & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(438, "", "Qta:") & Me.txtQtaConfermata.Text & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(439, "", "Tip.Mag:") & WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino & vbCrLf
                    ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(440, "", "Tip.Mag:") & WorkDatiRicercaStock.UbicazioneInfo.Ubicazione & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (CheckLenumOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(773, "", "Unità di Magazzino specificata non trovata.") & vbCrLf
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If


            Next



            'ELABORO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each SapWmGiacenza In clsPickCompOdP.UdMTrasfList


                '**************************************************************************************************************
                '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT

#If Not APPLICAZIONE_WIN32 = "SI" Then

                OT_Info.SapOtInfo_Rec.IAnfme = SapWmGiacenza.QuantitaConfermataOperatore              'QUANTITA DA TRASFERIRE

                'If (clsTrasfUnitaMagazzino.FunctionTransferUMType = FunctionTransferUMType.FunctionTransferTypeForNewUMLabel) Then
                '    'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
                '    OT_Info.SapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraBase                  'UDM BASE
                'Else
                '    OT_Info.SapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione                 'UDM
                'End If

                OT_Info.SapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                OT_Info.SapOtInfo_Rec.ILgnum = clsPickCompOdP.SourceUbicazione.NumeroMagazzino
                OT_Info.SapOtInfo_Rec.IWerks = clsPickCompOdP.SourceUbicazione.Divisione
                OT_Info.SapOtInfo_Rec.IMatnr = clsPickCompOdP.MaterialeGiacenza.CodiceMateriale
                OT_Info.SapOtInfo_Rec.ICharg = clsPickCompOdP.MaterialeGiacenza.Partita
                OT_Info.SapOtInfo_Rec.ILgort = clsPickCompOdP.MaterialeGiacenza.MagazzinoLogico

                'IMPOSTO TIPO MOVIMENTO
                OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.SapOtInfo_Rec.ILetyp = clsPickCompOdP.SourceUbicazione.TipoUnitaMagazzino

                '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
                OT_Info.SapOtInfo_Rec.IBestq = SapWmGiacenza.TipoStock
                OT_Info.SapOtInfo_Rec.ISobkz = SapWmGiacenza.CdStockSpeciale
                OT_Info.SapOtInfo_Rec.ISonum = SapWmGiacenza.NumeroStockSpeciale

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.SapOtInfo_Rec.IVltyp = SapWmGiacenza.UbicazioneInfo.TipoMagazzino
                OT_Info.SapOtInfo_Rec.IVlpla = SapWmGiacenza.UbicazioneInfo.Ubicazione
                OT_Info.SapOtInfo_Rec.IVlenr = SapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.SapOtInfo_Rec.INltyp = Default_PickingComp_TipoMag
                OT_Info.SapOtInfo_Rec.INlpla = Default_PickingComp_Ubicazione
                OT_Info.SapOtInfo_Rec.INlenr = ""

#Else

                OT_Info.rfcSapOtInfo_Rec.IAnfme = SapWmGiacenza.QuantitaConfermataOperatore              'QUANTITA DA TRASFERIRE

                'If (clsTrasfUnitaMagazzino.FunctionTransferUMType = FunctionTransferUMType.FunctionTransferTypeForNewUMLabel) Then
                '    'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
                '    OT_Info.rfcSapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraBase                  'UDM BASE
                'Else
                '    OT_Info.rfcSapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione                 'UDM
                'End If

                OT_Info.rfcSapOtInfo_Rec.IAltme = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                OT_Info.rfcSapOtInfo_Rec.ILgnum = clsPickCompOdP.SourceUbicazione.NumeroMagazzino
                OT_Info.rfcSapOtInfo_Rec.IWerks = clsPickCompOdP.SourceUbicazione.Divisione
                OT_Info.rfcSapOtInfo_Rec.IMatnr = clsPickCompOdP.MaterialeGiacenza.CodiceMateriale
                OT_Info.rfcSapOtInfo_Rec.ICharg = clsPickCompOdP.MaterialeGiacenza.Partita
                OT_Info.rfcSapOtInfo_Rec.ILgort = clsPickCompOdP.MaterialeGiacenza.MagazzinoLogico

                'IMPOSTO TIPO MOVIMENTO
                OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.rfcSapOtInfo_Rec.ILetyp = clsPickCompOdP.SourceUbicazione.TipoUnitaMagazzino

                '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
                OT_Info.rfcSapOtInfo_Rec.IBestq = SapWmGiacenza.TipoStock
                OT_Info.rfcSapOtInfo_Rec.ISobkz = SapWmGiacenza.CdStockSpeciale
                OT_Info.rfcSapOtInfo_Rec.ISonum = SapWmGiacenza.NumeroStockSpeciale

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.rfcSapOtInfo_Rec.IVltyp = SapWmGiacenza.UbicazioneInfo.TipoMagazzino
                OT_Info.rfcSapOtInfo_Rec.IVlpla = SapWmGiacenza.UbicazioneInfo.Ubicazione
                OT_Info.rfcSapOtInfo_Rec.IVlenr = SapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.rfcSapOtInfo_Rec.INltyp = Default_PickingComp_TipoMag
                OT_Info.rfcSapOtInfo_Rec.INlpla = Default_PickingComp_Ubicazione
                OT_Info.rfcSapOtInfo_Rec.INlenr = ""

#End If

                RetCode = clsBusinessLogic.InitSapFunctionError(stFunctionError)

                'ESEGUO OT IN SAP
                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, stFunctionError, OT_Executed_Number, True)
                If (RetCode <> 0) Then
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsPickCompOdP.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & vbCrLf
                Else
                    '>>> TUTTO OK
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(clsPickCompOdP.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number & vbCrLf & vbCrLf

                    'REGISTRO UM TRASFERIMENTO CORRETTO
                    SapWmGiacenza.NumeroOrdineTrasferimento = OT_Executed_Number
                End If


            Next



            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)


            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmPickingOdp_UM_2Form = New frmPickingOdP_UM_2
                    frmPickingOdp_UM_2Form.Show()
                    frmPickingOdp_UM_2Form.cmdOkBC.Focus()
                    Exit Sub
                End If
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_UscitaMerci_x_OdP(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Function GetUnitaMagazzinoInfo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DatiRicercaWmGiacenza As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim CheckUnitaMagazzinoOk As Boolean
        Dim UnitaMagazzinoOk As Boolean
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RetCode = 0

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(373, "", "Unità Magazzino non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            Me.txtUM.Text = UCase(Me.txtUM.Text)

            Me.txtUM.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtUM.Text)


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Function
            End If


            'CHIAMO WS PER VERIFICARE DATI UNITA MAGAZZINO
            RetCode += clsSapUtility.ResetGiacenzaStruct(DatiRicercaWmGiacenza)
            DatiRicercaWmGiacenza.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaWmGiacenza.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaWmGiacenza, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, False, False, Nothing, SapFunctionError, False)
            If (CheckUnitaMagazzinoOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(770, "", "L'Unita Magazzino specificata non è presente a sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If


            'MEMORIZZO DATI GIACENZA SPECIFICATA
            clsPickCompOdP.SourceUbicazione = WorkGiacenzaUM.UbicazioneInfo

            'IMPOSTO I DATI DEL COMPONENTE DA PRELEVARE
            clsPickCompOdP.MaterialeGiacenza = WorkGiacenzaUM


            Me.txtQtaPrevista.Text = clsPickCompOdP.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            Me.txtUDMQuantità.Text = clsPickCompOdP.MaterialeGiacenza.UnitaDiMisuraAcquisizione
            Me.txtQtaConfermata.Text = clsPickCompOdP.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq


            '
            Me.txtQtaConfermata.Focus()

            GetUnitaMagazzinoInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            GetUnitaMagazzinoInfo = 1000
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

    Public Shared Function Call_ZWS_CHECK_ODP_COMPONENTS_UM(ByRef inOrdineProduzioneOrigine As clsDataType.SapOrdineProduzione, ByRef inInfoStock As clsDataType.SapWmGiacenza, ByVal inLingua As String, ByRef outCheckComponentOk As Boolean, ByRef outCheckLenumOk As Boolean, ByRef outSapComponentiOrdineProduzione() As clsDataType.SapComponenteOrdineProduzione, ByRef outDatiGiacenza As clsDataType.SapWmGiacenza, ByRef outSapFunctionError As clsBusinessLogic.SapFunctionError, ByVal inShowMessageBox As Boolean) As Long

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '' ''Dim RetCode As Long = 0

        '' ''Dim objWS As New WM_MobilePanariaUSA.WS_CHECK_ODP_COMPONENTS_UM.ZWS_CHECK_ODP_COMPONENTS_UM
        '' ''Dim stImportParams As New WM_MobilePanariaUSA.WS_CHECK_ODP_COMPONENTS_UM.ZwmCheckOdpComponentsUm
        '' ''Dim objWSResponse As New WM_MobilePanariaUSA.WS_CHECK_ODP_COMPONENTS_UM.ZwmCheckOdpComponentsUmResponse
        '' ''Dim SingolaVarianteImballo As New WM_MobilePanariaUSA.WS_CHECK_ODP_COMPONENTS_UM.Ze1Mt00015
        ' '' ''**************************************
        '' ''Try 'HERE PUT NORMAL EXECUTION CODE
        '' ''    '**************************************

        '' ''    Call_ZWS_CHECK_ODP_COMPONENTS_UM = 1 'INIT AT ERROR

        '' ''    If (Len(inInfoStock.UbicazioneInfo.UnitaMagazzino) <= 0) Then
        '' ''        RetCode = 200
        '' ''        outSapFunctionError.ERROR_CODE = RetCode
        '' ''        outSapFunctionError.ERROR_DESCRIPTION = "Errore in esecuzione CHECK COMPONENTS. Parametro [UnitaMagazzino] non valido."
        '' ''        If (inShowMessageBox = True) Then
        '' ''            MessageBox.Show(outSapFunctionError.ERROR_DESCRIPTION, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '' ''        End If
        '' ''        Exit Function
        '' ''    End If


        '' ''    '**************************************************************************
        '' ''    'IMPOSTO I PARAMETRI DI IMPORT DELLA FUNZIONE

        '' ''    stImportParams.IAufnr = inOrdineProduzioneOrigine.NumeroOrdineProduzione
        '' ''    stImportParams.ILenum = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(inInfoStock.UbicazioneInfo.UnitaMagazzino)
        '' ''    stImportParams.IMatnrToCheck = inOrdineProduzioneOrigine.CodiceMateriale
        '' ''    stImportParams.IMatnrToCheckQty = inInfoStock.QuantitaConfermataOperatore
        '' ''    stImportParams.IUdmQty = inInfoStock.UnitaDiMisuraAcquisizione
        '' ''    stImportParams.ILanguage = inLingua

        '' ''    '>>> IMPOSTO LE CREDENZIALI PER LA CHIAMATA DEL WS
        '' ''    objNetworkCredential.UserName = UserRfcWs
        '' ''    objNetworkCredential.Password = PswUserRfcWs
        '' ''    objWS.Credentials = objNetworkCredential

        '' ''    '>>> IMPOSTO URL DINAMICO PER GESTIRE I DIVERSI AMBIENTI (DEV/TEST/PRODUZIONE)
        '' ''    objWS.Url = "http://" & WsHostName & ":" & WsPortNumber & "/sap/bc/srt/rfc/sap/zws_check_odp_components_um/" & SapClient & "/zws_check_odp_components_um/zws_check_odp_components_um"


        '' ''    Cursor.Current = Cursors.WaitCursor '>>> IMPOSTO SEGNALE ATTESA
        '' ''    'chiamo function per eseguire CONTROLLO UBICAZIONE
        '' ''    objWSResponse = objWS.ZwmCheckOdpComponentsUm(stImportParams)
        '' ''    Cursor.Current = Cursors.Default  '>>> FINE SEGNALE ATTESA

        '' ''    If (objWSResponse.ESuccess = "Y") And (objWSResponse.EFoundrows > 0) Then

        '' ''        If (objWSResponse.ECheckComponentOk = "Y") Then
        '' ''            outCheckComponentOk = True 'UNICO CASO DI CHECK COMPONENTE OK
        '' ''        End If
        '' ''        If (objWSResponse.ECheckLenumOk = "Y") Then
        '' ''            outCheckLenumOk = True 'UNICO CASO DI CHECK UM OK
        '' ''        End If

        '' ''        'RITORNO DATI DELLA GIACENZA TROVATA/E
        '' ''        If (outDatiGiacenza.CodiceMateriale = "") And (clsUtility.IsStringValid(objWSResponse.EDataMara.Matnr, True) = True) Then
        '' ''            outDatiGiacenza.CodiceMateriale = objWSResponse.EDataMara.Matnr
        '' ''        End If
        '' ''        If (outDatiGiacenza.CodiceMateriale = "") And (clsUtility.IsStringValid(objWSResponse.ETextMakt.Matnr, True) = True) Then
        '' ''            outDatiGiacenza.CodiceMateriale = objWSResponse.EDataMara.Matnr
        '' ''        End If

        '' ''        '>>> SE LA PARTITA NON E' VALORIZZATA LA IMPOSTO
        '' ''        If (outDatiGiacenza.Partita = "") Then
        '' ''            If (clsUtility.IsStringValid(inInfoStock.Partita, True) = True) Then
        '' ''                outDatiGiacenza.Partita = inInfoStock.Partita
        '' ''            Else
        '' ''                outDatiGiacenza.Partita = ""
        '' ''            End If
        '' ''        End If


        '' ''        'RITORNO I DATI DEI COMPONENTI
        '' ''        ReDim outSapComponentiOrdineProduzione(objWSResponse.EOdpComponents.Length - 1)
        '' ''        For index = 0 To objWSResponse.EOdpComponents.Length - 1
        '' ''            outSapComponentiOrdineProduzione(index).CodiceMateriale = objWSResponse.EOdpComponents(index).Material
        '' ''            outSapComponentiOrdineProduzione(index).DescrizioneMateriale = objWSResponse.EOdpComponents(index).MaterialDescription
        '' ''            outSapComponentiOrdineProduzione(index).NumeroOrdineProduzione = objWSResponse.EOdpComponents(index).OrderNumber
        '' ''            outSapComponentiOrdineProduzione(index).Partita = objWSResponse.EOdpComponents(index).Batch
        '' ''            outSapComponentiOrdineProduzione(index).QtaSingolaPartita = objWSResponse.EOdpComponents(index).WithdrawnQuantity
        '' ''            outSapComponentiOrdineProduzione(index).UdMQtaSingolaPartita = objWSResponse.EOdpComponents(index).BaseUom
        '' ''            outSapComponentiOrdineProduzione(index).EccessoQtaSingolaPartita = objWSResponse.EOdpComponents(index).Shortage
        '' ''            outSapComponentiOrdineProduzione(index).EccessoQtaTotaleComponente = objWSResponse.EOdpComponents(index).CommitedQuantity
        '' ''            outSapComponentiOrdineProduzione(index).QtaTotaleComponente = objWSResponse.EOdpComponents(index).EntryQuantity
        '' ''        Next


        '' ''        outDatiGiacenza.DescrizioneMateriale = objWSResponse.ETextMakt.Maktx
        '' ''        outDatiGiacenza.QuantitaInStock = objWSResponse.EZwmStockInfoRec.QtaTotPresenteBase
        '' ''        outDatiGiacenza.QtaTotaleDisponibile = objWSResponse.EZwmStockInfoRec.QtaTotDisponibileBase
        '' ''        outDatiGiacenza.QtaTotaleDaImmagazzinare = objWSResponse.EZwmStockInfoRec.QtaTotDaImmagazBase
        '' ''        outDatiGiacenza.QtaTotaleDaPrelevare = objWSResponse.EZwmStockInfoRec.QtaTotDaPrelevareBase
        '' ''        outDatiGiacenza.QuantitaInUdMBase = objWSResponse.EZwmStockInfoRec.QtaTotDisponibileBase
        '' ''        outDatiGiacenza.UnitaDiMisuraBase = objWSResponse.EZwmStockInfoRec.Meins

        '' ''        outDatiGiacenza.QuantitaInStockUdMAcq = objWSResponse.EZwmStockInfoRec.QtaTotPresenteCons
        '' ''        outDatiGiacenza.QtaTotaleLquaDispoUdMAcq = objWSResponse.EZwmStockInfoRec.QtaTotDisponibileCons
        '' ''        outDatiGiacenza.QtaTotaleDaImmaUdMAcq = objWSResponse.EZwmStockInfoRec.QtaTotDaImmagazCons
        '' ''        outDatiGiacenza.QtaTotaleLquaDaPrelUdMAcq = objWSResponse.EZwmStockInfoRec.QtaTotDaPrelevareCons
        '' ''        outDatiGiacenza.QuantitaInUdMAcquisizione = objWSResponse.EZwmStockInfoRec.QtaTotPresenteCons
        '' ''        outDatiGiacenza.UnitaDiMisuraAcquisizione = objWSResponse.EZwmStockInfoRec.Vrkme
        '' ''        If (objWSResponse.ECheckPickAllSu = "X") Then
        '' ''            outDatiGiacenza.PickSUCompleto = True
        '' ''        Else
        '' ''            outDatiGiacenza.PickSUCompleto = False
        '' ''        End If

        '' ''        If (objWSResponse.EFoundrows > 0) Then
        '' ''            outDatiGiacenza.UbicazioneInfo.Divisione = objWSResponse.ELquaTabFree(0).Lqua.Werks
        '' ''            outDatiGiacenza.UbicazioneInfo.NumeroMagazzino = objWSResponse.ELquaTabFree(0).Lqua.Lgnum
        '' ''            outDatiGiacenza.UbicazioneInfo.TipoMagazzino = objWSResponse.ELquaTabFree(0).Lqua.Lgtyp
        '' ''            outDatiGiacenza.UbicazioneInfo.Ubicazione = objWSResponse.ELquaTabFree(0).Lqua.Lgpla
        '' ''            outDatiGiacenza.UbicazioneInfo.UnitaMagazzino = objWSResponse.ELquaTabFree(0).Lqua.Lenum
        '' ''            outDatiGiacenza.UbicazioneInfo.TipoUnitaMagazzino = objWSResponse.ELquaTabFree(0).Lqua.Letyp
        '' ''            outDatiGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = True 'devo considerare le UM
        '' ''            outDatiGiacenza.MagazzinoLogico = objWSResponse.ELquaTabFree(0).Lqua.Lgort

        '' ''            '>>> SE NECESSARIO VALORIZZO IL CODICE MATERIALE
        '' ''            If (outDatiGiacenza.CodiceMateriale = "") And (clsUtility.IsStringValid(objWSResponse.ELquaTabFree(0).Lqua.Matnr, True) = True) Then
        '' ''                outDatiGiacenza.CodiceMateriale = objWSResponse.ELquaTabFree(0).Lqua.Matnr
        '' ''            End If

        '' ''            '>>> PER LA PARTITA C'è UNA LOGICA PARTICOLARE (SE NE HO UNA VALIDA PRENDO QUELLA
        '' ''            If (clsUtility.IsStringValid(objWSResponse.ELquaTabFree(0).Lqua.Charg, True) = True) Then
        '' ''                outDatiGiacenza.Partita = objWSResponse.ELquaTabFree(0).Lqua.Charg
        '' ''            ElseIf (clsUtility.IsStringValid(objWSResponse.ELquaTabFree(0).Lqua.Charg, True) = False) And (clsUtility.IsStringValid(inInfoStock.Partita, True) = True) Then
        '' ''                outDatiGiacenza.Partita = inInfoStock.Partita
        '' ''            Else
        '' ''                outDatiGiacenza.Partita = ""
        '' ''            End If

        '' ''            outDatiGiacenza.CdStockSpeciale = objWSResponse.ELquaTabFree(0).Lqua.Sobkz
        '' ''            outDatiGiacenza.NumeroStockSpeciale = objWSResponse.ELquaTabFree(0).Lqua.Sonum
        '' ''            outDatiGiacenza.TipoStock = objWSResponse.ELquaTabFree(0).Lqua.Bestq
        '' ''            outDatiGiacenza.NumeroFabbisognoDiTrasporto = objWSResponse.ELquaTabFree(0).Lqua.Tbnum
        '' ''        End If
        '' ''    End If

        '' ''    '**************************************
        '' ''Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
        '' ''    Cursor.Current = Cursors.Default  '>>> FINE SEGNALE ATTESA
        '' ''    'LOG ERROR CONDITION
        '' ''    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        '' ''    '**************************************
        '' ''Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
        '' ''    Cursor.Current = Cursors.Default  '>>> FINE SEGNALE ATTESA
        '' ''    If (outCheckComponentOk = False) Then
        '' ''        RetCode = 101
        '' ''        If (inShowMessageBox = True) Then
        '' ''            outSapFunctionError.ERROR_CODE = RetCode
        '' ''            outSapFunctionError.ERROR_DESCRIPTION = "Materiale/Giacenza non trovato tra i componenti.Verificare e riprovare." & vbCrLf & "ErrorCode:" & objWSResponse.EErrorCode & vbCrLf & "Err.Descr.:" & objWSResponse.EErrorDescription
        '' ''            MessageBox.Show(outSapFunctionError.ERROR_DESCRIPTION, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '' ''        End If
        '' ''        Call_ZWS_CHECK_ODP_COMPONENTS_UM = RetCode 'errore
        '' ''    Else
        '' ''        Call_ZWS_CHECK_ODP_COMPONENTS_UM = 0 'TUTTO OK
        '' ''    End If
        '' ''End Try

    End Function

End Class