Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmPickingMerci_ChangeUDS_2_UM_Oper
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_ChangeUDS_2_UM_Oper"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private UdMChangeListIndex As Integer = 0


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            'Select Case inKey
            '    Case 115

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
            RetCode = clsChangeUDS.Go_To_Original_Menu(Me)

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
            Call clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeNone, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ChangeUDS_2_UM_Oper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        'Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If ((Me.txt.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
            '    If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
            '        Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
            '        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
            '        Call cmdNextScreen_Click(Me, e)
            '        Exit Sub
            '    End If
            'End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ChangeUDS_2_UM_Oper_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim outCheckOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.Text = clsAppTranslation.GetSingleParameterValue(1412, Me.Text, "Cambia - UDS (2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")

            Me.cmdOperUDSAdd.Text = clsAppTranslation.GetSingleParameterValue(1764, "", "Aggiungi K-TAG Esistente")
            Me.cmdOperUDSUnion.Text = clsAppTranslation.GetSingleParameterValue(1765, "", "Consolida K-TAG")
            Me.cmdOperUDSMinus.Text = clsAppTranslation.GetSingleParameterValue(1766, "", "Splitta K-TAG")



#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************     


            RetCode = clsSapWS.Call_ZWMS_GET_JOBS_UDS_MATNR_OF_UDS(clsChangeUDS.UDSChange(0).UnitaMagazzino, clsUser.SapWmsUser.LANGUAGE, outCheckOk, clsChangeUDS.objDataTableUDSInfo, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1610, "", "Errore informazioni UDS.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            If Not (clsChangeUDS.objDataTableUDSInfo Is Nothing) Then
                clsChangeUDS.objDataTableUDSInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsChangeUDS.objDataTableUDSInfo
            End If

            'clsChangeUDS.RefreshDateTableUDSInfo()

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            RefreshDatiMaterialeAttivo()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    '    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
    '        '**************************************
    '        'HERE PUT DECLARATION OF LOCAL VARIABLE
    '        Dim RetCode As Long = 0
    '        Dim RetCodeFinal As Long = 0
    '        Dim OT_Executed_Ok As Boolean = False
    '        Dim ChekUbicazioneOk As Boolean = False
    '        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
    '        Dim InfoUbicazione As clsDataType.SapWmUbicazione
    '        Dim OT_Executed_Number As String = ""
    '        Dim OT_Info As New StrctSapMoveSuParams
    '        Dim UserAnswer As DialogResult
    '        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
    '        Dim IntroMessage As String
    '        Dim NumeroUdcTotaliUbicazione As Long
    '        Dim CheckSameStockUbiDestinationOk As Boolean = False
    '        '**************************************
    '        Try 'HERE PUT NORMAL EXECUTION CODE
    '            '**************************************

    '            ''VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
    '            'If (Me.txtUbicazioneDestinazione.Text = "") Then
    '            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
    '            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '            '    Exit Sub
    '            'End If


    '            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE, VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
    '            RetCode = clsUtility.ClearArray(clsTrasfMat.GiacenzeUbiDestinazione)
    '            RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
    '            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
    '            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
    '            DatiRicercaUbicazione.UnitaMagazzino = ""
    '            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, clsTrasfMat.GiacenzeUbiDestinazione, Nothing, SapFunctionError, False)
    '            If (ChekUbicazioneOk <> True) Then
    '                '>>> CASO DI UBICAZIONE NON DEFINITA ( ERRORE DATA ENTRY OPERATORE )
    '                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
    '                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                Exit Sub
    '            End If
    '            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA OMOGENEI
    '            RetCode = clsShowUtility.CheckSameStockUbiDestination(clsTrasfMat.UdMTrasfList(0), clsTrasfMat.GiacenzeUbiDestinazione, CheckSameStockUbiDestinationOk, False)
    '            If (CheckSameStockUbiDestinationOk <> True) Then
    '                '>>> SEGNALO A OPERATORE CHE  L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA DIVERSE
    '                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(1222, "", "Materiale e/o Partita diverse ubicate nell'ubicazione di destinazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1223, "", "Si desidera continuare ?")
    '                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                If (UserAnswer <> DialogResult.Yes) Then
    '                    Exit Sub
    '                End If
    '            End If


    '            'L'UBICAZIONE DI  DESTINAZIONE DEVE ESSERE DIVERSA
    '            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList
    '                If (InfoUbicazione.NumeroMagazzino = WorkSapWmGiacenza.UbicazioneInfo.NumeroMagazzino And _
    '                        InfoUbicazione.TipoMagazzino = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino And _
    '                            InfoUbicazione.Ubicazione = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione) Then

    '                    ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
    '                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If
    '            Next

    '            'SETTO UBICAZIONE DI DESTINAZIONE
    '            clsTrasfMat.DestinationUbicazione = InfoUbicazione

    '            'INIZIALIZZO VARIABILE ESITO
    '            ErrDescription = ""
    '            RetCodeFinal = 0

    '            'ELABORO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
    '            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList

    '                'NEL CASO DI "RIPROVA" IN CASO DI ERRORE NON DEVO PROVARE A TRASFERIRE LA STESSA UNITA DI MAGAZZINO
    '                If (WorkSapWmGiacenza.NumeroOrdineTrasferimento > 0) Then
    '                    Continue For
    '                End If


    '                '**************************************************************************************************************
    '                '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT
    '                '**************************************************************************************************************

    '#If Not APPLICAZIONE_WIN32 = "SI" Then

    '                OT_Info.SapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
    '                OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
    '                OT_Info.SapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

    '                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
    '                OT_Info.SapOtInfo_Rec.ILenum = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

    '                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE ( STESSA DESTINAZIONE PER TUTTE LE UM )
    '                OT_Info.SapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
    '                OT_Info.SapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione

    '#Else

    '                OT_Info.rfcSapOtInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
    '                OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
    '                OT_Info.rfcSapOtInfo_Rec.ILetyp = WorkSapWmGiacenza.UbicazioneInfo.TipoUnitaMagazzino

    '                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
    '                OT_Info.rfcSapOtInfo_Rec.ILenum = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino

    '                '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE ( STESSA DESTINAZIONE PER TUTTE LE UM )
    '                OT_Info.rfcSapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
    '                OT_Info.rfcSapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione

    '#End If

    '                RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)

    '                'ESEGUO OT IN SAP
    '                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_TO_MOVE_SU(OT_Info, False, False, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
    '                If (RetCode <> 0) Then

    '                    ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento della UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & vbCrLf

    '                Else
    '                    '>>> TUTTO OK
    '                    ErrDescription += clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento UMag.:") & clsSapUtility.FormattaStringaUnitaMagazzino(WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino) & vbCrLf & clsAppTranslation.GetSingleParameterValue(510, "", "Eseguito con successo. OT NUM:") & OT_Executed_Number & vbCrLf & vbCrLf

    '                    'REGISTRO UM TRASFERIMENTO CORRETTO
    '                    clsTrasfMat.UdMTrasfList(UdMChangeListIndex).NumeroOrdineTrasferimento = OT_Executed_Number

    '                End If

    '                'AGGIORNO CONTATORE Errori
    '                RetCodeFinal += RetCode

    '                'AGGIORNO CONTATORE UM
    '                UdMChangeListIndex += 1

    '            Next

    '            'RI-INIZIALIZZO L'INDICE
    '            UdMChangeListIndex = 0

    '            If (RetCodeFinal <> 0) Then
    '                IntroMessage = clsAppTranslation.GetSingleParameterValue(1191, "", "Attenzione!!! Si è verificato un errore.")
    '            Else
    '                'PALETTE TOTALI PRESENTI IN UBICAZIONE
    '                NumeroUdcTotaliUbicazione = clsTrasfMat.UdMTrasfList.GetLength(0) + clsTrasfMat.DestinationUbicazione.NumeroUdcInUbicazione
    '                'CASO TUTO OK
    '                IntroMessage = clsAppTranslation.GetSingleParameterValue(1192, "", "Trasferite N° UDC:") & Trim(Str(clsTrasfMat.UdMTrasfList.GetLength(0)))
    '                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))
    '            End If

    '            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
    '            frmMessageForUserForm = New frmMessageForUser
    '            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
    '            frmMessageForUserForm.ShowMessage(IntroMessage & vbCrLf & ErrDescription)

    '            '************************************************************************************************
    '            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
    '            '************************************************************************************************
    '            If (RetCodeFinal <> 0) Then
    '                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
    '                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
    '                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
    '                    System.Windows.Forms.Application.DoEvents()
    '                    Me.Close()
    '                    System.Windows.Forms.Application.DoEvents()
    '                    frmTRASF_UM_Part_2_Ubi_DestForm = New frmTRASF_UM_Part_2_Ubi_Dest
    '                    frmTRASF_UM_Part_2_Ubi_DestForm.Show()
    '                    frmTRASF_UM_Part_2_Ubi_DestForm.cmdNextScreen.Focus()
    '                    Exit Sub
    '                End If
    '            End If


    '            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
    '            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
    '            Call clsNavigation.Show_Ope_TRASF_UnitaMagazzino(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


    '            '**************************************
    '        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '            'LOG ERROR CONDITION
    '            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '            '**************************************
    '        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '        End Try
    '    End Sub

    Private Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoUDS.Text = ""

            If (clsChangeUDS.UDSChange Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsChangeUDS.UDSChange.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            'Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsChangeUDS.UDSChange.GetLength(0)))
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino))



            'For Each WorkSapUDSInfo In clsChangeUDS.UDSChange
            '    Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            'Next
            Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(0), Nothing, 0) & vbCrLf


            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdOperUDSMinus_Click(sender As Object, e As EventArgs) Handles cmdOperUDSMinus.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.cmdOperUDSMinus.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeMinus, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdOperUDSAdd_Click(sender As Object, e As EventArgs) Handles cmdOperUDSAdd.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.cmdOperUDSAdd.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeAdd, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdOperUDSUnion_Click(sender As Object, e As EventArgs) Handles cmdOperUDSUnion.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.cmdOperUDSAdd.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeUnion, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridListInfo.TableStyles.Count = 0) Then


                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità di Magazzino"), True, DefDtGridCol_UnitaMagazzino - 10, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "LETYP", clsAppTranslation.GetSingleParameterValue(80, "", "Tipo Magazzino"), True, DefDtGridCol_TipoMagazzino + 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prel."), True, DefDtGridCol_QtaPrelevata - 70, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 80, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZWMS_PESOMAT_USA", clsAppTranslation.GetSingleParameterValue(1504, "", "Peso Materiale"), True, DefDtGridCol_QtaDaPrelevare, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "GEWEI_USA", clsAppTranslation.GetSingleParameterValue(868, "", "Unità di peso USA"), True, DefDtGridCol_UnitaDiMisura, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "USERID_RF_CREA", clsAppTranslation.GetSingleParameterValue(367, "", "Utente"), True, DefDtGridCol_CarrelistaProposto + 50, True)


            End If


            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

End Class