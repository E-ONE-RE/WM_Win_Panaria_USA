Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmTRASF_UM_Part_2_Ubi_Dest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_UM_Part_2_Ubi_Dest"

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
                    cmdSelectUbicazione_Click(Me, e)
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

    Private Sub frmTRASF_UM_Part_2_Ubi_Dest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneDestinazione.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call cmdNextScreen_Click(Me, e)
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

    Private Sub frmTRASF_UM_Part_2_Ubi_Dest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(203, lblUbicazioneDestinazione.Text, "Ubic. Dest. UM ")

            Me.Text = clsAppTranslation.GetSingleParameterValue(202, Me.Text, "TRASF - Unità Mag.(2) ")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************     


            RefreshDatiMaterialeAttivo()
            Me.txtUbicazioneDestinazione.Text = clsTrasfMat.DestinationUbicazione.Ubicazione

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUbicazioneDestinazione.Focus()

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
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim OT_Executed_Number As String = ""
        Dim OT_Info As New StrctSapMoveSuParams
        Dim UserAnswer As DialogResult
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim IntroMessage As String
        Dim NumeroUdcTotaliUbicazione As Long
        Dim CheckSameStockUbiDestinationOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneDestinazione.Text = WorkOutUbicazione


            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE, VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsUtility.ClearArray(clsTrasfMat.GiacenzeUbiDestinazione)
            RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""

            DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_LOC_OCCUPATION = True
            DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_LOCATION = True
            DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_MATERIAL_CODE = clsTrasfMat.UdMTrasfList(0).CodiceMateriale
            DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_CHARG = clsTrasfMat.UdMTrasfList(0).Partita

            DatiRicercaUbicazione.FlagCheckLocationInfo.Quantity = clsTrasfMat.UdMTrasfList(0).QtaTotaleLquaInStock
            DatiRicercaUbicazione.FlagCheckLocationInfo.UdMQuantity = clsTrasfMat.UdMTrasfList(0).UnitaDiMisuraBase

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, clsTrasfMat.GiacenzeUbiDestinazione, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Then
                '>>> CASO DI UBICAZIONE NON DEFINITA ( ERRORE DATA ENTRY OPERATORE )
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (InfoUbicazione.FlagLocationFull = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1679, "", "L'Ubicazione di DESTINAZIONE e' PIENA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Exit Sub
                End If
            End If
            If (InfoUbicazione.FlagLocationWithDifferentMaterialCode = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1680, "", "L'Ubicazione di DESTINAZIONE contiene un MATERIALE diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Me.txtUbicazioneDestinazione.Text = ""
                Exit Sub
            End If
            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA OMOGENEI
            RetCode = clsShowUtility.CheckSameStockUbiDestination(clsTrasfMat.UdMTrasfList(0), clsTrasfMat.GiacenzeUbiDestinazione, CheckSameStockUbiDestinationOk, False)
            If (CheckSameStockUbiDestinationOk <> True) Then
                '>>> SEGNALO A OPERATORE CHE  L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA DIVERSE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(1222, "", "Materiale e/o Partita diverse ubicate nell'ubicazione di destinazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1223, "", "Si desidera continuare ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Exit Sub
                End If
            End If


            'L'UBICAZIONE DI  DESTINAZIONE DEVE ESSERE DIVERSA
            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList
                If (InfoUbicazione.NumeroMagazzino = WorkSapWmGiacenza.UbicazioneInfo.NumeroMagazzino And _
                        InfoUbicazione.TipoMagazzino = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino And _
                            InfoUbicazione.Ubicazione = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione) Then

                    ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next

            'SETTO UBICAZIONE DI DESTINAZIONE
            clsTrasfMat.DestinationUbicazione = InfoUbicazione

            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""
            RetCodeFinal = 0

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

                OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.SapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.SapOtInfo_Rec.ILenum = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE ( STESSA DESTINAZIONE PER TUTTE LE UM )
                OT_Info.SapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
                OT_Info.SapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione

#Else

                OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
                OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
                OT_Info.rfcSapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.rfcSapOtInfo_Rec.ILenum = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE ( STESSA DESTINAZIONE PER TUTTE LE UM )
                OT_Info.rfcSapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
                OT_Info.rfcSapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione

#End If

                RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

                'ESEGUO OT IN SAP
                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_TO_MOVE_SU(OT_Info, False, False, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
                If (RetCode <> 0) Then

                    ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & vbCrLf

                Else
                    '>>> TUTTO OK
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number & vbCrLf & vbCrLf

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
                    frmTRASF_UM_Part_2_Ubi_DestForm = New frmTRASF_UM_Part_2_Ubi_Dest
                    frmTRASF_UM_Part_2_Ubi_DestForm.Show()
                    frmTRASF_UM_Part_2_Ubi_DestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If


            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
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
                clsTrasfMat.DestinationUbicazione.Divisione = clsSelezioneUbicazione.UbicazioneSelezionata.Divisione
                clsTrasfMat.DestinationUbicazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                clsTrasfMat.DestinationUbicazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
                Me.txtUbicazioneDestinazione.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
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
    Private Sub cmdSelectUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazioneDestinazione.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneUbicazione.FilterDivisione = clsTrasfMat.DestinationUbicazione.Divisione
            clsSelezioneUbicazione.FilterNumMag = clsTrasfMat.DestinationUbicazione.NumeroMagazzino
            clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazioneDestinazione.Text


            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtUbicazioneDestinazione_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazioneDestinazione.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUbicazioneDestinazione.Text = "") Then Exit Sub

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class