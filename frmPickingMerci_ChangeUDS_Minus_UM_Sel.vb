Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_ChangeUDS_Minus_UM_Sel

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_ChangeUDS_Minus_UM_Sel"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private UdMChangeListIndex As Integer = 0
    'Private UnitaMagazzinoNew As Boolean = False


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim WorkUbicazioneDestinazione As clsDataType.SapWmUbicazione
        Dim ArrayGiacenze(0) As clsDataType.SapJobUdsChange
        Dim WmOtInfo() As clsDataType.SapWmOtInfo
        Dim IndexDataRowJob As Long = 0
        Dim IndexDataRowTaskLines As Long = 0
        Dim MemoNrWmsJobs As Long = 0
        Dim WorkDataRowJob As DataRow
        Dim WorkUdmQty As String = ""
        Dim outMessageDescription As String = ""
        Dim outPickExecutionOk As Boolean = False
        Dim wkQtaConfermata As Double = 0
        Dim wkQtaSfusiConfermata As Double = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim UserSelezioneOk As Boolean = False
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

            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '* Mod. Gestione Pezzi sfusi
            If (Not (IsNumeric(Me.txtQtaSfusiConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If (InStr(Me.txtQtaConfermata.Text, ".") > 0) Or (InStr(Me.txtQtaConfermata.Text, ",") > 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1600, "", "Qtà Confermata non intera.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '* Mod. Gestione Pezzi sfusi
            If (InStr(Me.txtQtaSfusiConfermata.Text, ".") > 0) Or (InStr(Me.txtQtaSfusiConfermata.Text, ",") > 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1600, "", "Qtà Confermata non intera.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            '* Mod. Gestione Pezzi sfusi

            'NECESSARIO PER EVENTUALI DECIMALI
            If (Me.txtQtaConfermata.Text <> "") Then
                wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
                If (wkQtaConfermata < 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                wkQtaSfusiConfermata = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)
                If (wkQtaSfusiConfermata < 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '>>> SE HO MESSO LA QTA IN PEZZI NON PUO' ESSERE SUPERIORE AI PEZZI DI UNA SCATOLA
                If (clsChangeUDS.UDSChange(1).VarianteImballo.PezziPerScatola > 0) And (wkQtaSfusiConfermata >= clsChangeUDS.UDSChange(1).VarianteImballo.PezziPerScatola) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1755, "", "La Qtà SFUSI immessa deve essere inferore ai pezzi di una SCATOLA.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If



            If (Val(Me.txtQtaConfermata.Text) > Val(Me.txtQtaPrevista.Text)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1773, "", "Qtà Confermata superiore a quella disponibile.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsChangeUDS.UDSChange Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1789, "", "Dati UDS non validi.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsChangeUDS.UDSChange.Length < 2) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1790, "", "Attenzione! Confermare l'UDS di DESTINAZIONE.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'NECESSARIO PER EVENTUALI DECIMALI
            wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)

            '* Mod. Gestione Pezzi sfusi
            wkQtaSfusiConfermata = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)




            'GIACENZA DESTINAZIONE
            clsChangeUDS.UDSChange(1).UbicazioneInfo.Divisione = clsChangeUDS.UDSChange(1).Divisione
            clsChangeUDS.UDSChange(1).UbicazioneInfo.NumeroMagazzino = clsChangeUDS.UDSChange(1).NumeroMagazzino
            clsChangeUDS.UDSChange(1).UbicazioneInfo.TipoMagazzino = clsChangeUDS.UDSChange(1).TipoMagazzino
            clsChangeUDS.UDSChange(1).UbicazioneInfo.Ubicazione = clsChangeUDS.UDSChange(1).Ubicazione
            clsChangeUDS.UDSChange(1).UbicazioneInfo.UnitaMagazzino = clsChangeUDS.UDSChange(1).UnitaMagazzino
            ArrayGiacenze(0).GiacenzaDestinazione.CodiceMateriale = clsChangeUDS.UDSChange(1).CodiceMateriale
            ArrayGiacenze(0).GiacenzaDestinazione.MagazzinoLogico = clsChangeUDS.UDSChange(1).MagazzinoLogico
            ArrayGiacenze(0).GiacenzaDestinazione.Partita = clsChangeUDS.UDSChange(1).Partita
            ArrayGiacenze(0).GiacenzaDestinazione.UbicazioneInfo = clsChangeUDS.UDSChange(1).UbicazioneInfo

            ArrayGiacenze(0).GiacenzaDestinazione.QuantitaConfermataOperatore = wkQtaConfermata
            ArrayGiacenze(0).GiacenzaDestinazione.UnitaDiMisuraAcquisizione = clsChangeUDS.UDSChange(1).UdmQtaPrelevataInUdMConsegna

            '* Modifica Gestione Qtà Pezzi Sfusi
            ArrayGiacenze(0).GiacenzaDestinazione.QuantitaConfermataSfusiOperatore = wkQtaSfusiConfermata


            'GIACENZA ORIGINE
            clsChangeUDS.UDSChange(0).UbicazioneInfo.Divisione = clsChangeUDS.UDSChange(0).Divisione
            clsChangeUDS.UDSChange(0).UbicazioneInfo.NumeroMagazzino = clsChangeUDS.UDSChange(0).NumeroMagazzino
            clsChangeUDS.UDSChange(0).UbicazioneInfo.TipoMagazzino = clsChangeUDS.UDSChange(0).TipoMagazzino
            clsChangeUDS.UDSChange(0).UbicazioneInfo.Ubicazione = clsChangeUDS.UDSChange(0).Ubicazione
            clsChangeUDS.UDSChange(0).UbicazioneInfo.UnitaMagazzino = clsChangeUDS.UDSChange(0).UnitaMagazzino
            ArrayGiacenze(0).GiacenzaOrigine.CodiceMateriale = clsChangeUDS.UDSChange(0).CodiceMateriale
            ArrayGiacenze(0).GiacenzaOrigine.MagazzinoLogico = clsChangeUDS.UDSChange(0).MagazzinoLogico
            ArrayGiacenze(0).GiacenzaOrigine.Partita = clsChangeUDS.UDSChange(0).Partita
            ArrayGiacenze(0).GiacenzaOrigine.UbicazioneInfo = clsChangeUDS.UDSChange(0).UbicazioneInfo


            RetCode = clsSapWS.Call_ZWMS_JOB_CHANGE_UDS_ADD(ArrayGiacenze, Default_PickingMerci_ChangeUDS_MINUS, clsUser.GetUserDivisionToUse, clsUser.GetUserNumeroMagazzinoToUse, ArrayGiacenze(0).GiacenzaDestinazione.UbicazioneInfo, clsUser.SapWmsUser.LANGUAGE, clsWmsJob.UDSOnWork, WmOtInfo, outPickExecutionOk, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1759, "", "Errore MINUS") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaDestinazione)
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                Exit Sub

            End If


            'CHIEDERE SE SI VUOLE RIPETERE L'OPERAZIONE CON STESSA UDS MASTER ( SE SI PULIRE GLI OGGETTI DELLA UDS AGGIUNTA IN PRECEDENZA E RIMANERE NELLA VIDEATA )
            WorkString = clsAppTranslation.GetSingleParameterValue(1774, "", "Si desidera ripetere l'operazione con lo stesso K-TAG ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaDestinazione)
                'txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                'AGGIORNO IL MATERIALE ATTIVO CHE SI E' SCELTO DI CONTINUARE AD USARE
                RetCode = Me.LoadUdsDataEntered()

                'ESEGUO IL REFRESH DELLA GRIGLIA DEL KTAG MASTER
                Call RefreshDatiMaterialeAttivoMaster()

                Exit Sub

            Else

                'CHIEDERE SE VUOLE USARE UN ALTRO K-TAG
                WorkString = clsAppTranslation.GetSingleParameterValue(1775, "", "Si desidera ripetere l'operazione con un nuovo K-TAG ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                    clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                    clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaDestinazione)
                    Me.txtUM.Text = ""
                    Me.txtInfoUDS.Text = ""
                    UdMChangeListIndex = 0
                    Me.DtGridListInfo.DataSource = Nothing

                    'ESEGUO IL REFRESH DELLA GRIGLIA DEL KTAG MASTER
                    Call RefreshDatiMaterialeAttivoMaster()

                    'ESEGUO IL REFRESH DELLA GRIGLIA E TEXTBOX DEL KTAG DESTINAZIONE
                    Call RefreshDatiMaterialeAttivoDest()

                    Exit Sub

                Else

                    clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(0))
                    clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                    clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaOrigine)
                    clsSapUtility.ResetGiacenzaStruct(ArrayGiacenze(0).GiacenzaDestinazione)
                    txtUM.Text = ""
                    txtInfoUDS.Text = ""
                    UdMChangeListIndex = 0
                    Me.DtGridListInfo.DataSource = Nothing

                    'PASSO ALLO VIDEATA DELLO STEP INIZIALE
                    clsChangeUDS.ClearAllData()
                    frmPickingMerci_ChangeUDS_1_UM_OriForm = New frmPickingMerci_ChangeUDS_1_UM_Ori
                    frmPickingMerci_ChangeUDS_1_UM_OriForm.Show()
                    Me.Close()

                End If

            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            'Call clsNavigation.Show_Ope_PickingMerci_ChangeUDS(Me, clsChangeUDS.FunctionChangeUDSType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ChangeUDS_Minus_UM_Sel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmPickingMerci_ChangeUDS_Minus_UM_Sel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim outCheckOk As Boolean = False
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1778, Me.lblCodiceUM.Text, "Codice UDS Destinazione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(1415, Me.Text, "Cambia - UDS (Elim.)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")

            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


            Me.lblMateriale.Text = ""
            Me.lblBatch.Text = ""

            Me.lblMat.Text = clsAppTranslation.GetSingleParameterValue(1767, "", "Materiale")
            Me.lblBat.Text = clsAppTranslation.GetSingleParameterValue(1768, "", "Batch")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUDSTask.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            'cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUDSTask.Text, "...")
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
                Me.DtGridListInfoMaster.DataSource = clsChangeUDS.objDataTableUDSInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStylesMaster()

            'AGGIORNO I CAMPI QTA' CON LA PRIMA RIGA
            RetCode = GetSelectedStockInfo(UserSelezioneOk)


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1793, "", "DESTINATION KTAG: ")


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

            If Me.txtUM.Text <> "" Then
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
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsChangeUDS.UDSChange.GetLength(0)))

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            'For Each WorkSapUDSInfo In clsChangeUDS.UDSChange
            '    Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            'Next

            'Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(1), Nothing, 0) & vbCrLf
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1793, "", "DESTINATION KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(1).UnitaMagazzino))



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

    Private Function RefreshDatiMaterialeAttivoMaster() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim outCheckOk As Boolean = False
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivoMaster = 1 'INIT AT ERROR

            Me.txtInfoUDS.Text = ""

            If (clsChangeUDS.UDSChange Is Nothing) Then
                RefreshDatiMaterialeAttivoMaster = 0
                Exit Function
            End If
            If (clsChangeUDS.UDSChange.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivoMaster = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            'Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsChangeUDS.UDSChange.GetLength(0)))
            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1793, "", "DESTINATION KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(1).UnitaMagazzino))



            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            'For Each WorkSapUDSInfo In clsChangeUDS.UDSChange
            '    Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            'Next
            Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(0), Nothing, 0) & vbCrLf


            RetCode = clsSapWS.Call_ZWMS_GET_JOBS_UDS_MATNR_OF_UDS(clsChangeUDS.UDSChange(0).UnitaMagazzino, clsUser.SapWmsUser.LANGUAGE, outCheckOk, clsChangeUDS.objDataTableUDSInfo, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1610, "", "Errore informazioni UDS.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            If Not (clsChangeUDS.objDataTableUDSInfo Is Nothing) Then
                clsChangeUDS.objDataTableUDSInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfoMaster.DataSource = clsChangeUDS.objDataTableUDSInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStylesMaster()

            'AGGIORNO I CAMPI QTA' CON LA PRIMA RIGA
            RetCode = GetSelectedStockInfo(UserSelezioneOk)


            RefreshDatiMaterialeAttivoMaster = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function RefreshDatiMaterialeAttivoDest() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivoDest = 1 'INIT AT ERROR

            Me.txtInfoUDS.Text = ""

            If (clsChangeUDS.UDSChange Is Nothing) Then
                RefreshDatiMaterialeAttivoDest = 0
                Exit Function
            End If
            If (clsChangeUDS.UDSChange.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivoDest = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            'Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsChangeUDS.UDSChange.GetLength(0)))
            'Me.txtInfoUDS.Text += clsChangeUDS.ShowSingleUDSInfo(clsChangeUDS.UDSChange(1), Nothing, 0) & vbCrLf

            Me.lblInfoUDS.Text = clsAppTranslation.GetSingleParameterValue(1792, "", "SOURCE KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(0).UnitaMagazzino)) & " - " & clsAppTranslation.GetSingleParameterValue(1793, "", "DESTINATION KTAG: ") & Trim(Str(clsChangeUDS.UDSChange(1).UnitaMagazzino))


            RefreshDatiMaterialeAttivoDest = RetCode

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


    Private Function SetDataGridColumnStylesMaster() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridListInfoMaster.TableStyles.Count = 0) Then


                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità di Magazzino"), True, DefDtGridCol_UnitaMagazzino - 10, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "MATNR", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale + 10, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "LETYP", clsAppTranslation.GetSingleParameterValue(80, "", "Tipo Magazzino"), True, DefDtGridCol_TipoMagazzino + 70, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prel."), True, DefDtGridCol_QtaPrelevata - 70, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 80, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "ZWMS_PESOMAT_USA", clsAppTranslation.GetSingleParameterValue(1504, "", "Peso Materiale"), True, DefDtGridCol_QtaDaPrelevare, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "GEWEI_USA", clsAppTranslation.GetSingleParameterValue(868, "", "Unità di peso USA"), True, DefDtGridCol_UnitaDiMisura, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfoMaster, "", "USERID_RF_CREA", clsAppTranslation.GetSingleParameterValue(367, "", "Utente"), True, DefDtGridCol_CarrelistaProposto + 50, True)


            End If


            SetDataGridColumnStylesMaster = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStylesMaster = 1000
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

    Private Function LoadUdsDataEntered() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        Dim UnitaMagazzinoOk As Boolean = False
        Dim UserAnswer As DialogResult = DialogResult.No

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


            'VERIFICO DI AVER INSERITO UNA UNITA' DI MAGAZZINO DIVERSA DALLA MASTER
            If (clsChangeUDS.UDSChange(0).UnitaMagazzino = Me.txtUM.Text) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1777, "", "L'Unita Magazzino specificata è uguale a quella Master.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM.Text = ""
                Exit Function
            End If

            Me.txtInfoUDS.Text = ""
            UdMChangeListIndex = 0
            Me.DtGridListInfo.DataSource = Nothing

            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse
            DatiRicercaUbicazione.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse
            DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWM_GET_JOB_UDS_INFO(clsUser.SapWmsUser.WERKS, DatiRicercaUbicazione, clsChangeUDS.UDSOnWork, clsChangeUDS.objDataTableUDSChangeInfo, True, clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkSapUDSInfo, SapFunctionError, False)


            If (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1779, "", "Si desidera crearne una nuova?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If (UserAnswer = Windows.Forms.DialogResult.Yes) Then
                    'Se si desire crearne una nuova, aggiorno array con nuovo codice UM

                    'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsChangeUDS
                    UdMChangeListIndex = 1

                    ReDim Preserve clsChangeUDS.UDSChange(UdMChangeListIndex)
                    clsChangeUDS.UDSChange(UdMChangeListIndex) = WorkSapUDSInfo


                    'COPIO da GIACENZA ORIGINE
                    clsChangeUDS.UDSChange(UdMChangeListIndex).Divisione = clsChangeUDS.UDSChange(0).Divisione
                    clsChangeUDS.UDSChange(UdMChangeListIndex).NumeroMagazzino = clsChangeUDS.UDSChange(0).NumeroMagazzino
                    clsChangeUDS.UDSChange(UdMChangeListIndex).TipoMagazzino = clsChangeUDS.UDSChange(0).TipoMagazzino

                    clsChangeUDS.UDSChange(UdMChangeListIndex).UbicazioneInfo.Divisione = clsChangeUDS.UDSChange(0).Divisione
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UbicazioneInfo.NumeroMagazzino = clsChangeUDS.UDSChange(0).NumeroMagazzino
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UbicazioneInfo.TipoMagazzino = clsChangeUDS.UDSChange(0).TipoMagazzino
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UbicazioneInfo.Ubicazione = clsChangeUDS.UDSChange(0).Ubicazione
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UnitaMagazzino = Me.txtUM.Text

                    clsChangeUDS.UDSChange(UdMChangeListIndex).CodiceMateriale = clsChangeUDS.UDSChange(0).CodiceMateriale
                    clsChangeUDS.UDSChange(UdMChangeListIndex).MagazzinoLogico = clsChangeUDS.UDSChange(0).MagazzinoLogico
                    clsChangeUDS.UDSChange(UdMChangeListIndex).Partita = clsChangeUDS.UDSChange(0).Partita

                    clsChangeUDS.UDSChange(UdMChangeListIndex).UdmQtaPrelevataInUdMBase = clsChangeUDS.UDSChange(0).UdmQtaPrelevataInUdMBase
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UdmQtaPrelevataInUdMConsegna = clsChangeUDS.UDSChange(0).UdmQtaPrelevataInUdMConsegna
                    clsChangeUDS.UDSChange(UdMChangeListIndex).UdmQtaPrelevataInUdMPezzo = clsChangeUDS.UDSChange(0).UdmQtaPrelevataInUdMPezzo

                    'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
                    Call RefreshDatiMaterialeAttivoDest()
                    Exit Function
                Else

                    'Se non si desira crearne una nuova azzero campi
                    txtUM.Text = ""
                    txtInfoUDS.Text = ""
                    UdMChangeListIndex = 0
                    Me.DtGridListInfo.DataSource = Nothing

                End If

                Exit Function

            End If


            'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsChangeUDS
            If (UdMChangeListIndex = 0) Then

                UdMChangeListIndex += 1

                ReDim Preserve clsChangeUDS.UDSChange(UdMChangeListIndex)
                clsChangeUDS.UDSChange(UdMChangeListIndex) = WorkSapUDSInfo

            End If




            'VERIFICO DI AVER INSERITO UN KTAG CON STESSO CODICE TRASPORTO SE E' GIA' ESISTENTE
            If (CheckUnitaMagazzinoOk = True) And (clsChangeUDS.UDSChange(1).NrTrasporto <> clsChangeUDS.UDSChange(0).NrTrasporto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1787, "", "L'Unita Magazzino specificata appartiene ad un Trasporto Differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                clsSapUtility.ResetSapUDSInfoStruct(clsChangeUDS.UDSChange(1))
                txtUM.Text = ""
                txtInfoUDS.Text = ""
                UdMChangeListIndex = 0
                DtGridListInfo.DataSource = Nothing

                Exit Function

            End If


            'VERIFICO DI AVER INSERITO UN KTAG CON STESSO CODICE CONSEGNA SE E' GIA' ESISTENTE
            If (CheckUnitaMagazzinoOk = True) And (clsChangeUDS.UDSChange(1).Consegna <> clsChangeUDS.UDSChange(0).Consegna) Then
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
            If (CheckUnitaMagazzinoOk = True) And (clsChangeUDS.UDSChange(1).UbicazioneInfo.FlagLocationStagingDoor = False) Then
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


    Private Sub DtGridStockInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridListInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Public Function GetSelectedStockInfo(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfo = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (clsChangeUDS.objDataTableUDSInfo Is Nothing)) Then
                If (clsChangeUDS.objDataTableUDSInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridListInfoMaster.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = clsChangeUDS.objDataTableUDSInfo.Rows(Me.DtGridListInfoMaster.CurrentRowIndex)


                        'ASSOCIO ALL'UDS MASTER i DATI DELL'ELEMENTO SELEZIONATO
                        clsChangeUDS.UDSChange(0).CodiceMateriale = clsUtility.GetDataRowItem(WorkDataRow, "Matnr", "")
                        clsChangeUDS.UDSChange(0).Partita = clsUtility.GetDataRowItem(WorkDataRow, "Charg", "")


                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA

                            Me.lblMateriale.Text = clsUtility.GetDataRowItem(WorkDataRow, "Matnr", "")
                            Me.lblBatch.Text = clsUtility.GetDataRowItem(WorkDataRow, "Charg", "")

                            ' <<<<< DA COMPLETARE
                            Me.txtQtaPrevista.Text = Trim(Str(Int(clsUtility.GetDataRowItem(WorkDataRow, "ZQTA_PREL_CONS", ""))))
                            Me.txtUDMQuantità.Text = clsUtility.GetDataRowItem(WorkDataRow, "UDM_QTAPR_CONS", "")
                            Me.txtQtaConfermata.Text = Trim(Str(Int(clsUtility.GetDataRowItem(WorkDataRow, "ZQTA_PREL_CONS", ""))))

                            Me.txtQtaSfusiConfermata.Text = Trim(Str(Int(clsUtility.GetDataRowItem(WorkDataRow, "ZQTA_PREL_SF", ""))))

                        End If
                    End If
                End If
            End If

            GetSelectedStockInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridListInfoMaster_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridListInfoMaster.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)

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