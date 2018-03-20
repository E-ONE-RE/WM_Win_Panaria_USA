Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmPickingMerci_MoveUDS_2_UBI_Dest
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_MoveUDS_2_UBI_Dest"

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
            RetCode = clsUscitaMerci.Go_To_Original_Menu(Me)

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
            Call clsNavigation.Show_Ope_PickingMerci_MoveUDS(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_MoveUDS_2_UBI_Dest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmPickingMerci_MoveUDS_2_UBI_Dest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(1321, lblUbicazioneDestinazione.Text, "Ubicazione Destinaz.")

            lblStaging.Text = clsAppTranslation.GetSingleParameterValue(1319, lblStaging.Text, "Staging Destinaz.")
            lblDockDoor.Text = clsAppTranslation.GetSingleParameterValue(1320, lblDockDoor.Text, "Dock Door")


            Me.Text = clsAppTranslation.GetSingleParameterValue(1315, Me.Text, "Picking - Move UDS(2)")

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
            Me.txtUbicazioneDestinazione.Text = clsMoveUDS.DestinationUbicazione.Ubicazione

            Me.txtStaging.Text = clsMoveUDS.UdMTrasfList(0).LGTYP_STAG_DOOR + " - " + clsMoveUDS.UdMTrasfList(0).LGPLA_STAG_DOOR
            Me.txtDockDoor.Text = clsMoveUDS.UdMTrasfList(0).LGTYP_DOCK_DOOR + " - " + clsMoveUDS.UdMTrasfList(0).LGPLA_DOCK_DOOR


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

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
        Dim ChekUbicazioneDropOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim OT_Executed_Number() As String
        Dim UserAnswer As DialogResult
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        Dim IntroMessage As String
        Dim NumeroUdcTotaliUbicazione As Long

        Dim outCheckOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
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
            ChekUbicazioneDropOk = False
            RetCode = clsUtility.ClearArray(clsMoveUDS.GiacenzeUbiDestinazione)
            RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapWS.Call_ZWM_CHECK_DROP_UBICAZIONE(DatiRicercaUbicazione, ChekUbicazioneDropOk, InfoUbicazione, clsMoveUDS.GiacenzeUbiDestinazione, Nothing, SapFunctionError, False)
            If (InfoUbicazione.FlagLocationDoor = True) Then
                'L'UBICAZIONE DI DESTINAZIONE NON PUO' ESSERE UNA DOCK DOOR ( USABILE SOLO NEL CARICO CAMION )
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1527, "", "L'Ubicazione di Destinazione e' una DOOR e non e' corretta per il DROP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUbicazioneDestinazione.Text = ""
                Exit Sub
            End If
            If (ChekUbicazioneDropOk <> True) Then
                '>>> CASO DI UBICAZIONE NON DEFINITA ( ERRORE DATA ENTRY OPERATORE )
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1523, "", "Ubicazione Destinazione non corretta per il DROP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUbicazioneDestinazione.Text = ""
                Exit Sub
            End If



            '********************************************************************************
            'L'UBICAZIONE DI  DESTINAZIONE DEVE ESSERE DIVERSA DA QUELLA DI ORIGINE
            '********************************************************************************
            For Each WorkSapUDSInfo In clsMoveUDS.UdMTrasfList
                'NON LA POSSO SPOSTARE NELLA STESSA UBICAZIONE DOVE SI TROVA
                If (InfoUbicazione.NumeroMagazzino = WorkSapUDSInfo.NumeroMagazzino And _
                        InfoUbicazione.TipoMagazzino = WorkSapUDSInfo.TipoMagazzino And _
                            InfoUbicazione.Ubicazione = WorkSapUDSInfo.Ubicazione) Then

                    ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If


                'SE L'UBICAZIONE E' UNA STAGING DOOR ALLORA DEVE ESSERE QUELLA PREVISTA
                If (InfoUbicazione.FlagLocationStagingDoor = True) Then
                    If (InfoUbicazione.NumeroMagazzino <> WorkSapUDSInfo.LGNUM_STAG_DOOR Or InfoUbicazione.TipoMagazzino <> WorkSapUDSInfo.LGTYP_STAG_DOOR Or InfoUbicazione.Ubicazione <> WorkSapUDSInfo.LGPLA_STAG_DOOR) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1528, "", "Ubicazione di STAGING selezionata diversa da quella prevista.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                If (clsUDS.OkUDSMove = False) And (clsUDS.OkUDSMoveWrapping = True) Then
                    If (InfoUbicazione.FlagLocationWrapping <> True) And (InfoUbicazione.Ubicazione <> WorkSapUDSInfo.LGPLA_STAG_DOOR) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1754, "", "Move UDS possibile solo per il WRAPPING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.txtUbicazioneDestinazione.Text = ""
                        Exit Sub
                    End If
                End If
            Next


            'SETTO UBICAZIONE DI DESTINAZIONE
            clsMoveUDS.DestinationUbicazione = InfoUbicazione

            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""
            RetCodeFinal = 0

            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

            'ESEGUO OT IN SAP
            RetCode = clsSapWS.Call_ZWMS_JOB_UDS_MOVE(clsMoveUDS.UdMTrasfList, clsUser.GetUserDivisionToUse(), clsMoveUDS.DestinationUbicazione.NumeroMagazzino, clsMoveUDS.DestinationUbicazione.TipoMagazzino, clsMoveUDS.DestinationUbicazione.Ubicazione, clsUser.SapWmsUser.LANGUAGE, clsMoveUDS.objDataTableUDSInfo, OT_Executed_Number, OT_Executed_Ok, outCheckOk, SapFunctionError, False)
            If (RetCode <> 0) Then

                ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapUDSInfo.UnitaMagazzino) & vbCrLf & vbCrLf

            Else
                '>>> TUTTO OK
                ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapUDSInfo.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number(UdMTrasfListIndex) & vbCrLf & vbCrLf

                'REGISTRO UM TRASFERIMENTO CORRETTO
                'clsMoveUDS.UdMTrasfList(UdMTrasfListIndex).Componenti(0).NumeroOrdineTrasferimento = OT_Executed_Number(UdMTrasfListIndex)
                Dim MaxArrayIndex As Long
                Dim IndexFor As Long

                If Not (OT_Executed_Number Is Nothing) Then
                    MaxArrayIndex = OT_Executed_Number.GetLength(0)
                    For IndexFor = 0 To (MaxArrayIndex - 1)
                        If (clsUtility.IsStringValid(OT_Executed_Number(IndexFor), True) = True) Then
                            ErrDescription += clsAppTranslation.GetSingleParameterValue(1247, "", " OT:") & OT_Executed_Number(IndexFor) & vbCrLf
                        End If
                    Next
                End If

            End If

            'AGGIORNO CONTATORE Errori
            RetCodeFinal += RetCode

            'RI-INIZIALIZZO L'INDICE
            UdMTrasfListIndex = 0

            If (RetCodeFinal <> 0) Then
                IntroMessage = clsAppTranslation.GetSingleParameterValue(1191, "", "Attenzione!!! Si è verificato un errore.")
            Else
                'PALETTE TOTALI PRESENTI IN UBICAZIONE
                NumeroUdcTotaliUbicazione = clsMoveUDS.UdMTrasfList.GetLength(0) + clsMoveUDS.DestinationUbicazione.NumeroUdcInUbicazione
                'CASO TUTO OK
                IntroMessage = clsAppTranslation.GetSingleParameterValue(1192, "", "Trasferite N° UDC:") & Trim(Str(clsMoveUDS.UdMTrasfList.GetLength(0)))
                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE ( SONO NEL CASO DI ERRORE )
            If (RetCodeFinal <> 0) Then
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(IntroMessage & vbCrLf & ErrDescription)
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
                    frmPickingMerci_MoveUDS_2_UBI_DestForm = New frmPickingMerci_MoveUDS_2_UBI_Dest
                    frmPickingMerci_MoveUDS_2_UBI_DestForm.Show()
                    frmPickingMerci_MoveUDS_2_UBI_DestForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If


            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
            Call clsNavigation.Show_Ope_PickingMerci_MoveUDS(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)


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
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoOperazioneUtente.Text = ""

            If (clsMoveUDS.UdMTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsMoveUDS.UdMTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsMoveUDS.UdMTrasfList.GetLength(0)))

            For Each WorkSapUDSInfo In clsMoveUDS.UdMTrasfList
                Me.txtInfoOperazioneUtente.Text += clsMoveUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
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
                clsMoveUDS.DestinationUbicazione.Divisione = clsSelezioneUbicazione.UbicazioneSelezionata.Divisione
                clsMoveUDS.DestinationUbicazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                clsMoveUDS.DestinationUbicazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
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
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazioneDestinazione.Text, 0, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneUbicazione.FilterDivisione = clsMoveUDS.DestinationUbicazione.Divisione
            clsSelezioneUbicazione.FilterNumMag = clsMoveUDS.DestinationUbicazione.NumeroMagazzino
            clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazioneDestinazione.Text


            RetCode = clsSelezioneUbicazione.SelezionaUbicazioneDropUDS(Me)

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