Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_ChangeUDS_1_UM_Ori

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_ChangeUDS_1_UM_Ori"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private UdMChangeListIndex As Integer = 0


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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim UnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'DEVO AVERE SPECIFICATO ALMENO UNA UNITA MAGAZZINO DA TRASFERIRE
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                If (clsChangeUDS.UDSChange Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub

                Else
                    If (clsChangeUDS.UDSChange.GetLength(0) <= 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If

            'SE DIGITATO UN BARCODE LO PROCESSO CON IL PULSANTE DI "OK"
            If (Me.txtUM.Text <> "") Then
                Call cmdOK_Click(sender, e)
            End If

            If (clsChangeUDS.UDSChange.GetLength(0) <= 0) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType.FunctionChnageUDSTypeNone, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ChangeUDS_1_UM_Ori_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM.Text = UCase(Me.txtUM.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdOK_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdOK.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
                    Call Me.cmdOK_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
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

    Private Sub frmPickingMerci_ChangeUDS_1_UM_Ori_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.lblUM.Text = clsAppTranslation.GetSingleParameterValue(1763, lblUM.Text, "UDS da Modificare")

            Me.Text = clsAppTranslation.GetSingleParameterValue(1411, Me.Text, "Cambia - UDS (1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdOK.Text = clsAppTranslation.GetSingleParameterValue(8, cmdOK.Text, "OK")

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************     


            'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
            'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
            Me.txtUM.Text = ""

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'NEL CASO DI "BACK" DEVO RIVISUALIZZARE LE UM CHE ERANO STATO IMMESSE
            Call RefreshDatiMaterialeAttivo()

            Me.txtUM.Focus()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM.LostFocus
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

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        Dim UnitaMagazzinoOk As Boolean = False
        Dim i As Integer = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE HO SPECIFICATO UN CODICE VALIDO DI UNITA MAGAZZINO
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Me.txtUM.Text = UCase(Me.txtUM.Text)

            Me.txtUM.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtUM.Text)


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            'VERIFICO DI NON AVER GIA' SELEZIONATO L'UNITA' DI MAGAZZINO
            If (UdMChangeListIndex > 0) Then
                For i = 0 To UdMChangeListIndex - 1
                    If (clsChangeUDS.UDSChange(i).UbicazioneInfo.UnitaMagazzino = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(Me.txtUM.Text)) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1178, "", "L'Unita Magazzino specificata è già stata selezionata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next
            End If

            '******************************************************************************************
            ' >>> NEL CASO DEL CHANGE UDS DEVO LIMITARE IL NUMERO DI PALLET LETTI A 1 ( CONFIGURABILE )
            '******************************************************************************************

            If Not (clsChangeUDS.UDSChange Is Nothing) Then
                If (clsChangeUDS.UDSChange.GetLength(0) >= Default_UDStoModify_Max_NumPalletScan) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1660, "", "Massimo numero di pallet letti raggiunto. Numero massimo =") & Trim(Str(Default_UDStoModify_Max_NumPalletScan)) & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    Me.txtUM.Text = ""
                    Me.txtUM.Focus()

                    Exit Sub
                End If
            End If


            ''VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            ''RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            ''DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            ''DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            ''RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUbicazione, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, False, False, Nothing, SapFunctionError, False)
            ''If (CheckUnitaMagazzinoOk <> True) Then
            ''    ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            ''    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ''    Exit Sub
            ''End If


            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse
            DatiRicercaUbicazione.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse
            DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWM_GET_JOB_UDS_INFO(clsUser.SapWmsUser.WERKS, DatiRicercaUbicazione, clsChangeUDS.UDSOnWork, clsChangeUDS.objDataTableUDSInfo, True, clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkSapUDSInfo, SapFunctionError, False)
            'If (clsUDS.OkUDSMove <> True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(1426, "", "Operazione di Move UDS non possibile. Errore : ") & vbCrLf & clsUDS.OkUDSMoveErr & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Me.txtUM.Text = ""
            '    Exit Sub
            'End If

            If (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM.Text = ""
                Exit Sub
            End If


            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
            If (clsUser.SapWmsUser.PROFID <> "ADMIN") And (WorkGiacenzaUM.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(502, "", "L'Unita Magazzino non puo' essere trasferita dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            'CONTROLLO SE IL KTAG HA IL FLAG DI STAGINGDOOR
            If (WorkSapUDSInfo.UbicazioneInfo.FlagLocationStagingDoor = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1791, "", "Il KTAG non ha il Flag di StagingDoor.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                'PULISCO CASELLA DATA ENTRY PER IMMISSIONE NUOVA UM
                Me.txtUM.Text = ""
                Me.txtUM.Focus()

                Exit Sub
            End If


            'PULISCO CASELLA DATA ENTRY PER IMMISSIONE NUOVA UM
            Me.txtUM.Text = ""
            Me.txtUM.Focus()


            'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsChangeUDS
            ReDim Preserve clsChangeUDS.UDSChange(UdMChangeListIndex)
            clsChangeUDS.UDSChange(UdMChangeListIndex) = WorkSapUDSInfo

            'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
            Call RefreshDatiMaterialeAttivo()

            UdMChangeListIndex += 1


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

            If (clsChangeUDS.UDSChange Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsChangeUDS.UDSChange.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            'Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsChangeUDS.UDSChange.GetLength(0)))
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino))


            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            'For Each WorkSapUDSInfo In clsChangeUDS.UDSChange
            '    Me.txtInfoOperazioneUtente.Text += clsChangeUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            'Next
            Me.txtInfoOperazioneUtente.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(0), Nothing, 0) & vbCrLf


            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub
End Class