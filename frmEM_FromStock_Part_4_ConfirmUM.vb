Imports clsSapWS
Imports clsSapUtility
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmEM_FromStock_Part_4_ConfirmUM
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_4_ConfirmUM"

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

    Private Sub frmEM_FromStock_Part_4_ConfirmUM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazDestConfermata.Focused = True) And (Me.txtUbicazDestConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
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
                    Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
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

    Private Sub frmEM_FromStock_Part_4_ConfirmUM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(77, lblUbicazDestConfermata.Text, "Ubicazione Destinazione")
            lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(75, lblUM_Destinazione.Text, "UM.Dest.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(88, Me.Text, "EM - Bem (5)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazioneDest.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazioneDest.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************


            'VISUALIZZO DATI ASSOCIATI ALLA POSIZIONE ATTIVA
            RetCode = RefreshDatiPosizioneAttiva()

            'VERIFICO SE IL TIPO MAGAZZINO DI DESTINAZIONE PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
            If (clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.AbilitaUnitaMagazzino = True) Then
                Me.txtUMDestConfermata.Enabled = True
                Me.txtUMDestConfermata.BackColor = Color.White
            Else
                Me.txtUMDestConfermata.Enabled = False
                Me.txtUMDestConfermata.BackColor = Color.Gray
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUbicazDestConfermata.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Function RefreshDatiPosizioneAttiva() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim NumUbiDestProposte As Long = 0
        Dim InfoOdP As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiPosizioneAttiva = 1 'INIT AT ERROR

            Me.txtInfoJobSelezionato.Text = clsShowUtility.FromSapWmUbicazioneStructToString(clsEMFromStock.SourceUbicazione, 0) & vbCrLf & clsShowUtility.FromSapWmGiacenzaStructToString(clsEMFromStock.MaterialeGiacenza, Nothing, 1)

            Me.txtUbicazDestConfermata.Text = ""
            NumUbiDestProposte = UBound(clsEMFromStock.UbicazioneDestProposte)
            If (NumUbiDestProposte > 0) Then
                'VISUALIZZO L'UBICAZIONE PROPOSTA
                Me.txtUbicazDestConfermata.Text = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.Ubicazione
                Select Case clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.AbilitaUnitaMagazzino
                    Case True '>>> caso magazzino con UM
                        If (Len(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.UnitaMagazzino) >= 10) Then
                            Me.txtUMDestConfermata.Text = clsSapUtility.FormattaStringaUnitaMagazzino(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.UnitaMagazzino)
                        Else
                            Me.txtUMDestConfermata.Text = ""
                        End If
                    Case Else
                        '>>>> NON PREVISTA L'UM DI DESTINAZIONE IN QUESTO TIPO MAG.
                        Me.lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(486, "", "Ubic.Dest.")
                        Me.txtUMDestConfermata.Text = ""
                End Select
            End If


            Me.txtUbicazioneDestInfo.Text = clsEMFromStock.DescrUbiDestinazione '>>> imposto descrizione ubicazione per help operatore

            RefreshDatiPosizioneAttiva = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim OT_Executed_Ok As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim OT_Executed_Number As String = ""
        Dim UserQuestion As String
        Dim UserAnswer As DialogResult
        Dim InfoUbicazioneDaCreare As clsDataType.SapWmUbicazione
        Dim CreaUbicazione_Executed_Ok As Boolean = False
        Dim ShowDescrizioneCreaUbica As String = ""
        Dim wkNumeroOrdine As String = ""
        Dim wkNumeroOrdinePosizione As String = ""
        Dim wkNumeroStockSpeciale As String = ""
        Dim Mov_Info As StrctGoodMovCreateMB1BInfo
        Dim Mov_Executed_Ok As Boolean = False
        Dim outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim Ok_MovMettiInStockE As Boolean = False
        Dim GetDataOk As Boolean = False
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
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
            If (UCase(Me.txtUbicazDestConfermata.Text) = UCase(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.Ubicazione)) Then
                DatiRicercaUbicazione.NumeroMagazzino = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.NumeroMagazzino
                DatiRicercaUbicazione.TipoMagazzino = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.TipoMagazzino
            End If
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazDestConfermata.Text

            If ((DatiRicercaUbicazione.TipoMagazzino = DefaultTipoMagAreaProduzione)) _
                    And (BemOdaEnableCreaUbicazionePerProd = True) Then
                'FORMATTO UBICAZIONE A ESSERE SEMPRE DI 10 NUMERI
                RetCode = clsSapUtility.CheckUbicazioneString(DatiRicercaUbicazione.Ubicazione, True)
            End If
            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Then
                If ((DatiRicercaUbicazione.TipoMagazzino = DefaultTipoMagAreaProduzione)) And (BemOdaEnableCreaUbicazionePerProd = True) Then
                    'NEL CASO CHE HO COME DESTINAZIONE IL MAGAZZINO CESTE O L'AREA DI APPRONTAMENTO PRODUZIONE
                    'ALLORA DEVO CREARE AUTOMATICAMENTE UNA UBICAZIONE CHE E' IL NUMERO DELL'ODP ASSOCIATO
                    'FORMATTO UBICAZIONE A ESSERE SEMPRE DI 10 NUMERI
                    RetCode = clsSapUtility.CheckUbicazioneString(DatiRicercaUbicazione.Ubicazione, True)
                    InfoUbicazioneDaCreare.NumeroMagazzino = DatiRicercaUbicazione.NumeroMagazzino
                    InfoUbicazioneDaCreare.TipoMagazzino = DatiRicercaUbicazione.TipoMagazzino
                    InfoUbicazioneDaCreare.Ubicazione = DatiRicercaUbicazione.Ubicazione
                    'ESEGUO CREAZIONE UBICAZIONI IN SAP
                    RetCode = clsSapWS.Call_ZWS_MB_CREA_UBICAZIONE(InfoUbicazioneDaCreare, CreaUbicazione_Executed_Ok, InfoUbicazione, SapFunctionError, False)
                    If (CreaUbicazione_Executed_Ok <> True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(452, "", "Errore nella creazione dell'Ubicazione Destinazione.") & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    'SE ARRIVO QUI L'UBICAZIONE E' STATA CREATA PER CUI REGISTRO LOG PER AVVISARE OPERATORE
                    ShowDescrizioneCreaUbica = clsAppTranslation.GetSingleParameterValue(453, "", "Creata ubicazione:") & InfoUbicazione.Ubicazione
                Else
                    'NEGLI ALTRI CASI L'UBICAZIONE DEVE ESISTERE ASSOLUTAMENTE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(454, "", "Ubicazione Destinazione non definita nel sistema.") & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '**************************************************************************************************
            '**************************************************************************************************
            'IMPOSTO I DATI DELL'UBICAZIONE DI DESTINAZIONE
            clsEMFromStock.DestinationUbicazione = InfoUbicazione

            'SE LA DESTINAZIONE E' IL MAGAZZINO CESTE
            If (clsEMFromStock.DestinationUbicazione.AbilitaUnitaMagazzino = True) Then
                'IN QUESTO CASO DEVO RICHIEDERE LA LETTURA DI UN BARCODE DELLA UM
                If (Me.txtUMDestConfermata.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(457, "", "Unità Magazzino Destinazione non corretta.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Me.txtUMDestConfermata.Text = UCase(Me.txtUMDestConfermata.Text)
                'VERIFICO SE L'UNITA' DI MAGAZZINO E' CORRETTA ????
                clsEMFromStock.DestinationUbicazione.UnitaMagazzino = Me.txtUMDestConfermata.Text
            Else
                clsEMFromStock.DestinationUbicazione.UnitaMagazzino = ""
            End If


            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT

#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtInfo_Rec.IAnfme = clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.SapOtInfo_Rec.IAltme = clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione           'UDM CONSEGNA
            'IMPOSTO TIPO MOVIMENTO
            OT_Info.SapOtInfo_Rec.IBwlvs = DefaultEM_List_TipoMovimentoPerOT '"999" 
            OT_Info.SapOtInfo_Rec.ITbnum = ""
            OT_Info.SapOtInfo_Rec.ITbpos = ""
            OT_Info.SapOtInfo_Rec.IBetyp = DefaultEM_List_FtTypePerOT '"" 
            OT_Info.SapOtInfo_Rec.IBenum = ""
            If (clsUtility.IsStringValid(clsEMFromStock.DestinationUbicazione.UnitaMagazzino, True) = True) Then
                OT_Info.SapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

            OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.SapOtInfo_Rec.ILgnum = clsEMFromStock.SourceUbicazione.NumeroMagazzino
            OT_Info.SapOtInfo_Rec.IWerks = clsEMFromStock.SourceUbicazione.Divisione
            OT_Info.SapOtInfo_Rec.IMatnr = clsEMFromStock.MaterialeGiacenza.CodiceMateriale
            OT_Info.SapOtInfo_Rec.ICharg = clsEMFromStock.MaterialeGiacenza.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.SapOtInfo_Rec.IBestq = clsEMFromStock.MaterialeGiacenza.TipoStock
            OT_Info.SapOtInfo_Rec.ISobkz = clsEMFromStock.MaterialeGiacenza.CdStockSpeciale
            OT_Info.SapOtInfo_Rec.ISonum = clsEMFromStock.MaterialeGiacenza.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.SapOtInfo_Rec.IVltyp = clsEMFromStock.SourceUbicazione.TipoMagazzino
            OT_Info.SapOtInfo_Rec.IVlpla = clsEMFromStock.SourceUbicazione.Ubicazione

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.SapOtInfo_Rec.INltyp = clsEMFromStock.DestinationUbicazione.TipoMagazzino
            OT_Info.SapOtInfo_Rec.INlpla = clsEMFromStock.DestinationUbicazione.Ubicazione
            OT_Info.SapOtInfo_Rec.INlenr = clsEMFromStock.DestinationUbicazione.UnitaMagazzino

            '>>>> PER TENERE TRACCIA DELL'OT (USO CAMPO [Ablad] come campo di appoggio) per determinare QTA
            OT_Info.SapOtInfo_Rec.IAblad = ""

#Else

            OT_Info.rfcSapOtInfo_Rec.IAnfme = clsEMFromStock.MaterialeGiacenza.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.rfcSapOtInfo_Rec.IAltme = clsEMFromStock.MaterialeGiacenza.UnitaDiMisuraAcquisizione           'UDM CONSEGNA
            'IMPOSTO TIPO MOVIMENTO
            OT_Info.rfcSapOtInfo_Rec.IBwlvs = DefaultEM_List_TipoMovimentoPerOT '"999" 
            OT_Info.rfcSapOtInfo_Rec.ITbnum = ""
            OT_Info.rfcSapOtInfo_Rec.ITbpos = ""
            OT_Info.rfcSapOtInfo_Rec.IBetyp = DefaultEM_List_FtTypePerOT '"" 
            OT_Info.rfcSapOtInfo_Rec.IBenum = ""
            If (clsUtility.IsStringValid(clsEMFromStock.DestinationUbicazione.UnitaMagazzino, True) = True) Then
                OT_Info.rfcSapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

            OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.rfcSapOtInfo_Rec.ILgnum = clsEMFromStock.SourceUbicazione.NumeroMagazzino
            OT_Info.rfcSapOtInfo_Rec.IWerks = clsEMFromStock.SourceUbicazione.Divisione
            OT_Info.rfcSapOtInfo_Rec.IMatnr = clsEMFromStock.MaterialeGiacenza.CodiceMateriale
            OT_Info.rfcSapOtInfo_Rec.ICharg = clsEMFromStock.MaterialeGiacenza.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.rfcSapOtInfo_Rec.IBestq = clsEMFromStock.MaterialeGiacenza.TipoStock
            OT_Info.rfcSapOtInfo_Rec.ISobkz = clsEMFromStock.MaterialeGiacenza.CdStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ISonum = clsEMFromStock.MaterialeGiacenza.NumeroStockSpeciale

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.rfcSapOtInfo_Rec.IVltyp = clsEMFromStock.SourceUbicazione.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.IVlpla = clsEMFromStock.SourceUbicazione.Ubicazione

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.rfcSapOtInfo_Rec.INltyp = clsEMFromStock.DestinationUbicazione.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.INlpla = clsEMFromStock.DestinationUbicazione.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.INlenr = clsEMFromStock.DestinationUbicazione.UnitaMagazzino

            '>>>> PER TENERE TRACCIA DELL'OT (USO CAMPO [Ablad] come campo di appoggio) per determinare QTA
            OT_Info.rfcSapOtInfo_Rec.IAblad = ""

#End If


            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

            'ESEGUO OT IN SAP
            RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(487, "", "Attenzione!Errore nel trasferimento.") & vbCrLf
                ErrDescription = ErrDescription & SapFunctionError.ERROR_DESCRIPTION
            Else
                '>>> TUTTO OK
                ErrDescription = clsAppTranslation.GetSingleParameterValue(488, "", "Trasferimento eseguito con successo. OT NUM:") & OT_Executed_Number
                If (clsUtility.IsStringValid(ShowDescrizioneCreaUbica, True) = True) Then
                    ErrDescription = ErrDescription & vbCrLf & ShowDescrizioneCreaUbica
                End If
            End If


            '************************************************************************************************
            ' >>> SE ABILITATO VISUALIZZO RISULTATO OPERAZIONE
            '************************************************************************************************
            If (EntrataMerceAbilitaMsgConfermaSuccesso = True) Or (RetCode <> 0) Then
                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)
            End If


            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmEM_List_Part_5_FinalConfirmForm = New frmEM_FromStock_Part_4_ConfirmUM
                    frmEM_List_Part_5_FinalConfirmForm.Show()
                    frmEM_List_Part_5_FinalConfirmForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            ErrDescription = clsAppTranslation.GetSingleParameterValue(473, "", "Si desidera eseguire un'altra ENTRATA MERCE ? (Si / No )")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                RetCode += clsEMFromStock.ClearForNewOperation() 'PULISCO I DATI DELL'ULTIMA OPERAZIONE
                '***************************************************************
                '* >>> CHIAMO WS PER ESTRAZIONE DATI GIACENZA 
                clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
                GetDataOk = False
                WorkUbicazione.Divisione = clsEMFromStock.UserFilterSourceUbicazione.Divisione
                WorkUbicazione.NumeroMagazzino = clsEMFromStock.UserFilterSourceUbicazione.NumeroMagazzino
                WorkUbicazione.TipoMagazzino = clsEMFromStock.UserFilterSourceUbicazione.TipoMagazzino
                WorkUbicazione.Ubicazione = ""
                WorkGiacenza.CodiceMateriale = clsEMFromStock.UserFilterMaterialeGiacenza.CodiceMateriale
                WorkGiacenza.Partita = clsEMFromStock.UserFilterMaterialeGiacenza.Partita

                'FILTRO LE GIACENZE USANDO I FILTRI PASSATI DALL'OPERATORE
                RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, True, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsEMFromStock.objDataTable_EM_List_Info, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
                If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                    If (RetCode = 101) Then
                        'CASO DI DATO NON TROVATO
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(496, "", "Nessun dato trovato.Verificare i filtri e riprovare.")
                    Else
                        'ERRORE NEL CODICE
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(497, "", "Errore in estrazione dati (GET_GET_LQUA).Verificare e riprovare.")
                    End If
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'ESCO DALLA BEM => TORNO AL MENU DI ENTRATA MERCI
                    RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)
                End If
                'PARTO NUOVAMENTE DALLO STEP CHE CHIDE IL MATERIALE PER DETERMINARE LA RIGA DELLA BEM 
                Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
            Else
                'ESCO DALLA BEM => TORNO AL MENU DI ENTRATA MERCI
                RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)
            End If

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

    Private Sub txtUMDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUMDestConfermata.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

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
            If (clsUtility.IsStringValid(clsEMFromStock.DestinationUbicazione.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsEMFromStock.DestinationUbicazione.Divisione
            ElseIf (clsUtility.IsStringValid(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.Divisione, True) = True) Then
                clsSelezioneUbicazione.FilterDivisione = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.Divisione
            Else
                'DIVISIONE DI DEFAULT
                clsSelezioneUbicazione.FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            End If

            If (clsUtility.IsStringValid(clsEMFromStock.DestinationUbicazione.NumeroMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterNumMag = clsEMFromStock.DestinationUbicazione.NumeroMagazzino
            ElseIf (clsUtility.IsStringValid(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.NumeroMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterNumMag = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.NumeroMagazzino
            Else
                'CASO DEFAULT
                clsSelezioneUbicazione.FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            End If

            If (clsUtility.IsStringValid(clsEMFromStock.DestinationUbicazione.TipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = clsEMFromStock.DestinationUbicazione.TipoMagazzino
            ElseIf (clsUtility.IsStringValid(clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.TipoMagazzino, True) = True) Then
                clsSelezioneUbicazione.FilterTipiMag = clsEMFromStock.UbicazioneDestOnWork.UbicazioneInfo.TipoMagazzino
            Else
                '???? CASO DEFAULT

            End If

            If (Me.txtUbicazDestConfermata.Text = "") Then
                clsSelezioneUbicazione.FilterUbicazione = DefaultSelectUbicazione_Ubicazione
            Else
                If (Len(Me.txtUbicazDestConfermata.Text) > 2) Then
                    clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazDestConfermata.Text.Substring(1, 2) & "*"
                Else
                    clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazDestConfermata.Text & "*"
                End If
            End If

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
                clsEMFromStock.DestinationUbicazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                clsEMFromStock.DestinationUbicazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
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
End Class