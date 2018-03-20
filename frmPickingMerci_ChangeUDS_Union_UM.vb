Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_ChangeUDS_Union_UM

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_ChangeUDS_Union_UM"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private UdMChangeListIndex As Integer = 0


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            'Call frmPickingMerci_Code_3_SelUDS_KeyPress(Me, e)

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ArrayGiacenze(0) As clsDataType.SapJobUdsChange
        Dim WmOtInfo() As clsDataType.SapWmOtInfo
        Dim outPickExecutionOk As Boolean = False
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(667, "", "Specificare un CODICE UM valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUM.Text = UCase(Me.txtUM.Text)


            'PRIMA UDS LETTA ( NEL CASO DELLA UNIONE E' PALETTA CHE RIMMARRA DOPO L'UNIONE )
            clsChangeUDS.UDSChange(0).UbicazioneInfo.Divisione = clsChangeUDS.UDSChange(0).Divisione
            clsChangeUDS.UDSChange(0).UbicazioneInfo.NumeroMagazzino = clsChangeUDS.UDSChange(0).NumeroMagazzino
            clsChangeUDS.UDSChange(0).UbicazioneInfo.TipoMagazzino = clsChangeUDS.UDSChange(0).TipoMagazzino
            clsChangeUDS.UDSChange(0).UbicazioneInfo.Ubicazione = clsChangeUDS.UDSChange(0).Ubicazione
            clsChangeUDS.UDSChange(0).UbicazioneInfo.UnitaMagazzino = clsChangeUDS.UDSChange(0).UnitaMagazzino
            ArrayGiacenze(0).GiacenzaDestinazione.CodiceMateriale = clsChangeUDS.UDSChange(0).CodiceMateriale
            ArrayGiacenze(0).GiacenzaDestinazione.MagazzinoLogico = clsChangeUDS.UDSChange(0).MagazzinoLogico
            ArrayGiacenze(0).GiacenzaDestinazione.Partita = clsChangeUDS.UDSChange(0).Partita
            ArrayGiacenze(0).GiacenzaDestinazione.UbicazioneInfo = clsChangeUDS.UDSChange(0).UbicazioneInfo



            'SECONDA UDS LETTA ( DA AGGIUNGERE ALLA PRIMA )
            clsChangeUDS.UDSChange(1).UbicazioneInfo.Divisione = clsChangeUDS.UDSChange(1).Divisione
            clsChangeUDS.UDSChange(1).UbicazioneInfo.NumeroMagazzino = clsChangeUDS.UDSChange(1).NumeroMagazzino
            clsChangeUDS.UDSChange(1).UbicazioneInfo.TipoMagazzino = clsChangeUDS.UDSChange(1).TipoMagazzino
            clsChangeUDS.UDSChange(1).UbicazioneInfo.Ubicazione = clsChangeUDS.UDSChange(1).Ubicazione
            clsChangeUDS.UDSChange(1).UbicazioneInfo.UnitaMagazzino = clsChangeUDS.UDSChange(1).UnitaMagazzino
            ArrayGiacenze(0).GiacenzaOrigine.CodiceMateriale = clsChangeUDS.UDSChange(1).CodiceMateriale
            ArrayGiacenze(0).GiacenzaOrigine.MagazzinoLogico = clsChangeUDS.UDSChange(1).MagazzinoLogico
            ArrayGiacenze(0).GiacenzaOrigine.Partita = clsChangeUDS.UDSChange(1).Partita
            ArrayGiacenze(0).GiacenzaOrigine.UbicazioneInfo = clsChangeUDS.UDSChange(1).UbicazioneInfo


            RetCode = clsSapWS.Call_ZWMS_JOB_CHANGE_UDS_ADD(ArrayGiacenze, Default_PickingMerci_ChangeUDS_UNION, clsUser.GetUserDivisionToUse, clsUser.GetUserNumeroMagazzinoToUse, ArrayGiacenze(0).GiacenzaDestinazione.UbicazioneInfo, clsUser.SapWmsUser.LANGUAGE, clsWmsJob.UDSOnWork, WmOtInfo, outPickExecutionOk, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1757, "", "Errore UNION") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'CHIEDERE SE SI VUOLE RIPETERE L'OPERAZIONE UN'ALTRA UDS ( SE SI PULIRE GLI OGGETTI DELLA UDS AGGIUNTA IN PRECEDENZA E RIMANERE NELLA VIDEATA )
            WorkString = clsAppTranslation.GetSingleParameterValue(1737, "", "Si desidera ripetere l'operazione con un altro K-TAG ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = Windows.Forms.DialogResult.Yes) Then
                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaOrigine)
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing
                Exit Sub
            End If



            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ChangeUDS_Union_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "") And (Me.txtUM.Text.Length = 10)) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    RetCode = Me.LoadUdsDataEntered()
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

    Private Sub frmPickingMerci_ChangeUDS_Union_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1762, Me.lblCodiceUM.Text, "Codice UDS Origine")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1416, Me.Text, "Cambia - UDS (Unis.)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUDSTask.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            'cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUDSTask.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************    


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "MASTER KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1795, "", "K-TAG TO DELETE: ")


            Me.txtUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtCodiceUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM.LostFocus
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
    Private Function LoadUdsDataEntered() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim CheckUnitaMagazzinoOk As Boolean
        Dim GetDataOk As Boolean = False
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        Dim UnitaMagazzinoOk As Boolean = False


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE HO SPECIFICATO UN CODICE VALIDO DI UNITA MAGAZZINO
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
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


            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse
            DatiRicercaUbicazione.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse
            DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWM_GET_JOB_UDS_INFO(clsUser.SapWmsUser.WERKS, DatiRicercaUbicazione, clsChangeUDS.UDSOnWork, clsChangeUDS.objDataTableUDSChangeInfo, True, clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkSapUDSInfo, SapFunctionError, False)


            If (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM.Text = ""
                Exit Function
            End If


            'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsChangeUDS
            If UdMChangeListIndex = 0 Then

                UdMChangeListIndex += 1

                ReDim Preserve clsChangeUDS.UDSChange(UdMChangeListIndex)
                clsChangeUDS.UDSChange(UdMChangeListIndex) = WorkSapUDSInfo

            End If


            'VERIFICO DI AVER INSERITO UN KTAG CON STESSO CODICE TRASPORTO
            If (clsChangeUDS.UDSChange(1).NrTrasporto <> clsChangeUDS.UDSChange(0).NrTrasporto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1787, "", "L'Unita Magazzino specificata appartiene ad un Trasporto Differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                Exit Function

            End If


            'VERIFICO DI AVER INSERITO UN KTAG CON STESSO CODICE CONSEGNA
            If (clsChangeUDS.UDSChange(1).Consegna <> clsChangeUDS.UDSChange(0).Consegna) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1788, "", "L'Unita Magazzino specificata appartiene ad una Consegna Differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                Exit Function

            End If


            'CONTROLLO SE IL KTAG HA IL FLAG DI STAGINGDOOR
            If (clsChangeUDS.UDSChange(1).UbicazioneInfo.FlagLocationStagingDoor = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1791, "", "Il KTAG non ha il Flag di StagingDoor.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                Exit Function

            End If




            'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
            Call RefreshDatiMaterialeAttivo()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim outCheckOk As Boolean = False
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
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "MASTER KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1795, "", "K-TAG TO DELETE: ") & Trim(Str(clsChangeUDS.UDSChange(1).UnitaMagazzino))


            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            'For Each WorkSapUDSInfo In clsChangeUDS.UDSChange
            '    Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            'Next
            Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(1), Nothing, 0) & vbCrLf


            RetCode = clsSapWS.Call_ZWMS_GET_JOBS_UDS_MATNR_OF_UDS(clsChangeUDS.UDSChange(1).UnitaMagazzino, clsUser.SapWmsUser.LANGUAGE, outCheckOk, clsChangeUDS.objDataTableUDSChangeInfo, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1610, "", "Errore informazioni UDS.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            If Not (clsChangeUDS.objDataTableUDSChangeInfo Is Nothing) Then
                clsChangeUDS.objDataTableUDSChangeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsChangeUDS.objDataTableUDSChangeInfo
            End If

            'clsChangeUDS.RefreshDateTableUDSInfo()

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

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

    Private Sub cmdPreviousScreen_Click(sender As Object, e As EventArgs) Handles cmdPreviousScreen.Click
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


    Private Sub cmdSelectUDSTask_Click(sender As Object, e As EventArgs) Handles cmdSelectUDSTask.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtUM.Text <> "") And (Me.txtUM.Text.Length = 10)) Then
                RetCode = Me.LoadUdsDataEntered()
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class