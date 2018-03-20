Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmTRASF_UM_Part_2_UM_Dest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_UM_Part_2_UM_Dest"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            'Select Case inKey
            '    Case 115
            '        cmdSelectUbicazionDest_Click(Me, e)
            'End Select

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

            'RITORNO AL MENU DI PARTENZA
            RetCode = clsTrasfMat.Go_To_Original_Menu(Me)

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
            Call clsNavigation.Show_Ope_TRASF_UnitaMagazzino(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_UM_Part_2_UM_Dest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM_Destinazione.Focused = True) And (Me.txtUM_Destinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtUbicazDestConfermata.Focused = True) And (Me.txtUbicazDestConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
                    If (Me.txtUM_Destinazione.Text <> "") Then
                        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                        Call cmdNextScreen_Click(Me, e)
                        Exit Sub
                    Else
                        Me.txtUM_Destinazione.Focus()
                        Exit Sub
                    End If
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

    Private Sub frmTRASF_UM_Part_2_UM_Dest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(77, lblUbicazDestConfermata.Text, "Ubicazione Destinazione")
            'lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(196, lblUM_Destinazione.Text, "Unità Mag.Destinazione")
            lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(1735, lblUM_Destinazione.Text, "Unità Mag.Destinazione")


            Me.Text = clsAppTranslation.GetSingleParameterValue(204, Me.Text, "TRASF - Unità Mag.(2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazioneDest.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazioneDest.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************


            'COME DESTINAZIONE DI DEFAULT E' PROPOSTA L'UBICAZIONE ATTUALE
            If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                If (Not clsTrasfMat.UdMTrasfList Is Nothing) Then
                    If (clsTrasfMat.UdMTrasfList.GetLength(0) > 0) Then
                        Me.txtUbicazDestConfermata.Text = clsTrasfMat.UdMTrasfList(0).UbicazioneInfo.Ubicazione
                    End If
                End If
            End If
            Me.txtUM_Destinazione.Text = clsTrasfMat.DestinationUbicazione.UnitaMagazzino

            If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                'DISABILITO IL CAMBIO DI UBICAZIONE
                Me.txtUbicazDestConfermata.Enabled = False
                Me.cmdSelectUbicazioneDest.Enabled = False
            Else
                Me.txtUbicazDestConfermata.Enabled = True
                Me.cmdSelectUbicazioneDest.Enabled = True
            End If

            'VISUALIZZO LE INFORMAZIONI PER L'OPERATORE
            RetCode = RefreshDatiMaterialeAttivo()

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
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUnitaMagazzino As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim stFunctionError As clsBusinessLogic.SapFunctionError
        Dim OT_Executed_Number As String = ""
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim UserAnswer As DialogResult
        Dim UnitaMagazzinoOk As Boolean = False
        Dim RetCodeFinal As Long = 0
        Dim UdMTrasfListIndex As Long = 0
        Dim IntroMessage As String = ""
        Dim NumeroUdcTotaliUbicazione As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM_Destinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(808, "", "Unità di Magazzino di Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Me.txtUbicazDestConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(809, "", "Ubicazione specificata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
            Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)

            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazDestConfermata.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazDestConfermata.Text = WorkOutUbicazione


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM_Destinazione.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                'SE  RIETICHETTO TENGO STESSA UBICAZIONE DI DESTINAZIONE  E CAMBIO SOLO LA  UM
                InfoUbicazione = clsTrasfMat.UdMTrasfList(0).UbicazioneInfo
            Else
                '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE / VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
                RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
                DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
                DatiRicercaUbicazione.Ubicazione = Me.txtUbicazDestConfermata.Text
                DatiRicercaUbicazione.UnitaMagazzino = ""
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, True)
                If (ChekUbicazioneOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'NEL CASO DI RIETICHETTATURA L'UBICAZIONE E' LA STESSA PER CUI IL CONTROLLO VA BYPASSATO
            If (clsTrasfMat.FunctionTransferMaterialType <> clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                If (InfoUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino And _
                        InfoUbicazione.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino And _
                            InfoUbicazione.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione) Then

                    ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'SETTO UBICAZIONE DI DESTINAZIONE
            clsTrasfMat.DestinationUbicazione = InfoUbicazione

            '>>> CONTROLLO L'UNITA DI MAGAZZINO PASSATA
            '>>> ATTENZIONE VERIFICO CHE NON DEVE ESSERE PRESENTE
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUnitaMagazzino)
            DatiRicercaUnitaMagazzino.UbicazioneInfo.Divisione = clsTrasfMat.DestinationUbicazione.Divisione
            DatiRicercaUnitaMagazzino.UbicazioneInfo.NumeroMagazzino = clsTrasfMat.DestinationUbicazione.NumeroMagazzino
            DatiRicercaUnitaMagazzino.UbicazioneInfo.UnitaMagazzino = Me.txtUM_Destinazione.Text
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUnitaMagazzino, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, False, False, Nothing, SapFunctionError, False)
            If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                '>>> CASO DI RI-ETICHETTATURA => L'UNITA DI MAGAZZINO NON DEVE ESSERE ESISTENTE
                If (CheckUnitaMagazzinoOk = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(810, "", "L'Unita Magazzino è gia esistente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""
            RetCodeFinal = 0

            'IMPOSTO I DATI DELL'UNITA DI MAGAZZINO DI DESTINAZIONE
            clsTrasfMat.DestinationUbicazione.UnitaMagazzino = Me.txtUM_Destinazione.Text

            'ELABORO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList

                'NEL CASO DI "RIPROVA" IN CASO DI ERRORE NON DEVO PROVARE A TRASFERIRE LA STESSA UNITA DI MAGAZZINO
                If (WorkSapWmGiacenza.NumeroOrdineTrasferimento > 0) Then
                    Continue For
                End If

                '**************************************************************************************************************
                '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT
                '**************************************************************************************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then

                If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMPrintLabel) Then
                    OT_Info.SapOtInfo_Rec.IAnfme = WorkSapWmGiacenza.QtaTotaleLquaInStock                'QUANTITA DA TRASFERIRE
                    'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
                    OT_Info.SapOtInfo_Rec.IAltme = WorkSapWmGiacenza.UnitaDiMisuraBase                  'UDM BASE
                Else
                    OT_Info.SapOtInfo_Rec.IAnfme = WorkSapWmGiacenza.QtaTotaleLquaInStockUdMAcq
                    OT_Info.SapOtInfo_Rec.IAltme = WorkSapWmGiacenza.UnitaDiMisuraAcquisizione                 'UDM
                End If

                OT_Info.SapOtInfo_Rec.ILgort = WorkSapWmGiacenza.MagazzinoLogico
                OT_Info.SapOtInfo_Rec.ILgnum = WorkSapWmGiacenza.UbicazioneInfo.NumeroMagazzino
                OT_Info.SapOtInfo_Rec.IWerks = WorkSapWmGiacenza.UbicazioneInfo.Divisione
                OT_Info.SapOtInfo_Rec.IMatnr = WorkSapWmGiacenza.CodiceMateriale
                OT_Info.SapOtInfo_Rec.ICharg = WorkSapWmGiacenza.Partita

                'IMPOSTO TIPO MOVIMENTO
                OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.SapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
                OT_Info.SapOtInfo_Rec.IBestq = WorkSapWmGiacenza.TipoStock
                OT_Info.SapOtInfo_Rec.ISobkz = WorkSapWmGiacenza.CdStockSpeciale
                OT_Info.SapOtInfo_Rec.ISonum = WorkSapWmGiacenza.NumeroStockSpeciale

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.SapOtInfo_Rec.IVltyp = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino
                OT_Info.SapOtInfo_Rec.IVlpla = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                OT_Info.SapOtInfo_Rec.IVlenr = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.SapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
                OT_Info.SapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione
                OT_Info.SapOtInfo_Rec.INlenr = clsTrasfMat.DestinationUbicazione.UnitaMagazzino

#Else

                If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMPrintLabel) Then
                    OT_Info.rfcSapOtInfo_Rec.IAnfme = WorkSapWmGiacenza.QtaTotaleLquaInStock                'QUANTITA DA TRASFERIRE
                    'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
                    OT_Info.rfcSapOtInfo_Rec.IAltme = WorkSapWmGiacenza.UnitaDiMisuraBase                  'UDM BASE
                Else
                    OT_Info.rfcSapOtInfo_Rec.IAnfme = WorkSapWmGiacenza.QtaTotaleLquaInStockUdMAcq
                    OT_Info.rfcSapOtInfo_Rec.IAltme = WorkSapWmGiacenza.UnitaDiMisuraAcquisizione                 'UDM
                End If

                OT_Info.rfcSapOtInfo_Rec.ILgort = WorkSapWmGiacenza.MagazzinoLogico
                OT_Info.rfcSapOtInfo_Rec.ILgnum = WorkSapWmGiacenza.UbicazioneInfo.NumeroMagazzino
                OT_Info.rfcSapOtInfo_Rec.IWerks = WorkSapWmGiacenza.UbicazioneInfo.Divisione
                OT_Info.rfcSapOtInfo_Rec.IMatnr = WorkSapWmGiacenza.CodiceMateriale
                OT_Info.rfcSapOtInfo_Rec.ICharg = WorkSapWmGiacenza.Partita

                'IMPOSTO TIPO MOVIMENTO
                OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.rfcSapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
                OT_Info.rfcSapOtInfo_Rec.IBestq = WorkSapWmGiacenza.TipoStock
                OT_Info.rfcSapOtInfo_Rec.ISobkz = WorkSapWmGiacenza.CdStockSpeciale
                OT_Info.rfcSapOtInfo_Rec.ISonum = WorkSapWmGiacenza.NumeroStockSpeciale

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.rfcSapOtInfo_Rec.IVltyp = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino
                OT_Info.rfcSapOtInfo_Rec.IVlpla = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                OT_Info.rfcSapOtInfo_Rec.IVlenr = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
                OT_Info.rfcSapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
                OT_Info.rfcSapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione
                OT_Info.rfcSapOtInfo_Rec.INlenr = clsTrasfMat.DestinationUbicazione.UnitaMagazzino

#End If

                RetCode = clsBusinessLogic.InitSapFunctionError(stFunctionError)

                'ESEGUO OT IN SAP
                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, stFunctionError, OT_Executed_Number, True)
                If (RetCode <> 0) Then
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & " " & clsSapUtility.FormattaStringaUnitaMagazzino(clsTrasfMat.DestinationUbicazione.UnitaMagazzino) & vbCrLf & vbCrLf
                Else
                    '>>> TUTTO OK
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & " " & clsSapUtility.FormattaStringaUnitaMagazzino(clsTrasfMat.DestinationUbicazione.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number & vbCrLf & vbCrLf

                    'REGISTRO UM TRASFERIMENTO CORRETTO
                    clsTrasfMat.UdMTrasfList(UdMTrasfListIndex).NumeroOrdineTrasferimento = OT_Executed_Number
                End If

                'AGGIORNO CONTATORE Errori
                RetCodeFinal += RetCode

                'AGGIORNO CONTATORE UM
                UdMTrasfListIndex += 1

            Next

            'RI-INIZIALIZZO L'INDICE
            UdMTrasfListIndex = 0

            If (RetCodeFinal <> 0) Then
                IntroMessage = clsAppTranslation.GetSingleParameterValue(1191, "", "Attenzione!!! Si è verificato un errore.")
            Else
                'PALETTE TOTALI PRESENTI IN UBICAZIONE
                NumeroUdcTotaliUbicazione = clsTrasfMat.UdMTrasfList.GetLength(0) + clsTrasfMat.DestinationUbicazione.NumeroUdcInUbicazione
                'CASO TUTO OK
                IntroMessage = clsAppTranslation.GetSingleParameterValue(1192, "", "Trasferite N° UDC:") & Trim(Str(clsTrasfMat.UdMTrasfList.GetLength(0)))
                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(IntroMessage & vbCrLf & ErrDescription)




            '/////////////////////////////
            ''IMPOSTO I DATI DELL'UNITA DI MAGAZZINO DI DESTINAZIONE
            'clsTrasfMat.DestinationUbicazione.UnitaMagazzino = Me.txtUM_Destinazione.Text

            ''**************************************************************************************************************
            ''>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT
            'OT_Info.SapOtInfo_Rec.IAnfme = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore              'QUANTITA DA TRASFERIRE
            'If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMPrintLabel) Then
            '    'GESTIONE CONFERMA CON UDM DI BASE PER EVITARE PROBLEMI CON I DECIMALI SE UDM CONSEGNA NON INTERA
            '    OT_Info.SapOtInfo_Rec.IAltme = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraBase                  'UDM BASE
            'Else
            '    OT_Info.SapOtInfo_Rec.IAltme = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione                 'UDM
            'End If

            'OT_Info.SapOtInfo_Rec.ILgort = clsTrasfMat.MaterialeGiacenza.MagazzinoLogico
            'OT_Info.SapOtInfo_Rec.ILgnum = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            'OT_Info.SapOtInfo_Rec.IWerks = clsTrasfMat.SourceUbicazione.Divisione
            'OT_Info.SapOtInfo_Rec.IMatnr = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
            'OT_Info.SapOtInfo_Rec.ICharg = clsTrasfMat.MaterialeGiacenza.Partita

            ''IMPOSTO TIPO MOVIMENTO
            'OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
            'OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            'OT_Info.SapOtInfo_Rec.ILetyp = clsTrasfMat.SourceUbicazione.TipoUnitaMagazzino

            ''>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            'OT_Info.SapOtInfo_Rec.IBestq = clsTrasfMat.MaterialeGiacenza.TipoStock
            'OT_Info.SapOtInfo_Rec.ISobkz = clsTrasfMat.MaterialeGiacenza.CdStockSpeciale
            'OT_Info.SapOtInfo_Rec.ISonum = clsTrasfMat.MaterialeGiacenza.NumeroStockSpeciale

            ''>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            'OT_Info.SapOtInfo_Rec.IVltyp = clsTrasfMat.SourceUbicazione.TipoMagazzino
            'OT_Info.SapOtInfo_Rec.IVlpla = clsTrasfMat.SourceUbicazione.Ubicazione
            'OT_Info.SapOtInfo_Rec.IVlenr = clsTrasfMat.SourceUbicazione.UnitaMagazzino

            ''>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            'OT_Info.SapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
            'OT_Info.SapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione
            'OT_Info.SapOtInfo_Rec.INlenr = clsTrasfMat.DestinationUbicazione.UnitaMagazzino

            'RetCode = clsBusinessLogic.InitSapFunctionError(stFunctionError)

            ''ESEGUO OT IN SAP
            'RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, stFunctionError, OT_Executed_Number, True)
            'If (RetCode <> 0) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.")
            'Else
            '    '>>> TUTTO OK
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(807, "", "Trasferimento UMag. eseguito con successo. OT NUM:") & OT_Executed_Number
            'End If

  

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
                    frmTRASF_UM_Part_2_UM_DestForm = New frmTRASF_UM_Part_2_UM_Dest
                    frmTRASF_UM_Part_2_UM_DestForm.Show()
                    frmTRASF_UM_Part_2_UM_DestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_TRASF_UnitaMagazzino(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)

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
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoOperazioneUtente.Text = ""

            If (clsTrasfMat.UdMTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsTrasfMat.UdMTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsTrasfMat.UdMTrasfList.GetLength(0)))

            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList
                Me.txtInfoOperazioneUtente.Text += clsTrasfMat.ShowTransferSingleUMInfo(WorkSapWmGiacenza, Nothing, 0) & vbCrLf
            Next

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Sub txtUM_Destinazione_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM_Destinazione.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM_Destinazione.Text = "") Then Exit Sub

            Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class