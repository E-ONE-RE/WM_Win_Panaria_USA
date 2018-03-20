
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmEM_FromJob_Part_3_SelMis

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_3_SelMis"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************
            Dim RetCode As Long
            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 116

                    'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                    clsWmsJob.RowIndex = Me.DtGridListInfo.CurrentRowIndex
                    clsWmsJob.objDetailsDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(Me.DtGridListInfo.CurrentRowIndex)
                    clsWmsJob.RefreshDateTableDetailsInfo()

                    'VISUALIZZO IL DETTAGLIO DEL JOBS GROUP
                    RetCode = clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType.EM_FromJob_SourceTypeJobList, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails, True)
                    If (RetCode <> 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

            End Select


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            Select Case clsEMFromJob.EM_SourceType
                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeDocMat, clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobGroup
                    'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                    Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

                Case clsEMFromJob.EM_FromJob_SourceType.EM_FromJob_SourceTypeJobList
                    'FILTRO LE LISTE ASSEGNATE USANDO I FILTRI PASSATI DALL'OPERATORE
                    RetCode = clsWmsJobsGroup.GetJobsGroupList("ENTRATA_MERCE", GetDataOk, False)
                    If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                        If (RetCode = 101) Then
                            'CASO DI DATO NON TROVATO
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(478, "", "Nessun dato trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                        Else
                            'ERRORE NEL CODICE
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1221, "", "Errore in estrazione dati LISTE MISSIONI.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                        End If
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If

                    'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
                    Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
                Case Else
                    'IN TUTTI GLI ALTRI CASI VADO AL MENU CONTESTUALE
                    RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)
            End Select


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
        Dim UserSelezioneOk As Boolean = False
        Dim UserAnswer As DialogResult = DialogResult.None
        Dim UbicazioneDestFound As Boolean = False
        Dim CheckStockTypeOk As Boolean = False
        Dim CheckStockOdvOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA RIGA VALIDA 
            RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(302, "", "Attenzione, selezione stock non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '******************************************************************************************************
            'VERIFICARE SE HO PRELEVATO TUTTA LA QTA
            '******************************************************************************************************
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(418, "", "Attenzione! Nessuna QTA da prelevare. QTA Da Prelevare:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq & vbCrLf & clsAppTranslation.GetSingleParameterValue(419, "", "Qta Prelevata:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> VERIFICO LE CONDIZIONI OK PER POTERE ESEGUIRE IL PICKING DI UN JOB
            RetCode = clsWmsJob.JobsActivateExecution("", True, True)
            If (RetCode <> 0) Then
                'ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                'MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> IMPOSTO IL CARRELLISTA DI ESECUZIONE DELLA MISSIONE
            RetCode = clsWmsJob.SetJobCarrellistaEsecuzioneMissione(True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1596, "", "Errore in IMPOSTAZIONE OPERATORE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '******************************************************************************************************
            'VERIFICO E SEGNALO EVENTUALI PRESENZE DI STOCK SPECIALI (ES. STOCK Q)
            '******************************************************************************************************
            RetCode = clsEMFromJob.CheckStockTypeByUser(CheckStockTypeOk)
            If (RetCode <> 0) Or (CheckStockTypeOk = False) Then
                Exit Sub
            End If

            '******************************************************************************************************
            'VERIFICO E SEGNALO SE MERCE E' ASSOCIATA AD UN ORDINE DI VENDITA
            '******************************************************************************************************
            RetCode = clsEMFromJob.CheckStockForOrdineDiVendita(CheckStockOdvOk)
            If (RetCode <> 0) Or (CheckStockOdvOk = False) Then
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJob_Part_3_SelMis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.DtGridListInfo.Focused = True) And (Me.DtGridListInfo.CurrentRowIndex >= 0)) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdCloseJobsGroup.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdCloseJobsGroup_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdExit.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdAbortScreen_Click(Me, e)
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

    Private Sub frmEM_FromJob_Part_3_SelMis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        Dim Index As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.Text = clsAppTranslation.GetSingleParameterValue(61, Me.Text, "EM - Bem-SelPos (1)")
            Me.cmdExit.Text = clsAppTranslation.GetSingleParameterValue(268, Me.cmdExit.Text, "Esci")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, Me.cmdNextScreen.Text, "OK")
            Me.cmdCloseJobsGroup.Text = clsAppTranslation.GetSingleParameterValue(267, Me.cmdCloseJobsGroup.Text, "Chiudi Lista")


#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
#Else
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
#End If

            '***************************************************************     


            If Not (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                clsWmsJob.objDataTableWmsJobsList.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsWmsJob.objDataTableWmsJobsList
            End If

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            'IL  CURSORE  SI POSIZIONE SULLA PRIMA RIGA DA ESEGUIRE
            RetCode = clsShowUtility.VaiAllaPrimaRigaDaEseguire(Me.DtGridListInfo)

            'VISUALIZZO DATI CORRENTI E FACCIO REFRESH DATI RIGA ATTIVA
            RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)

            Me.Text = "Sel.Pos(1)"
            Me.Text = Me.Text & "-" & clsWmsJob.GetRowCountWmsJobsList(False)


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            Me.DtGridListInfo.Focus()

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

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "GRID_EXECUTED", clsAppTranslation.GetSingleParameterValue(365, "", "Stato"), True, DefDtGridCol_GridExecuted + 3, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_JOBS", clsAppTranslation.GetSingleParameterValue(361, "", "N°Miss."), True, DefDtGridCol_NumeroMissione, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MATNR_ORI", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "CHARG_ORI", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTAPK_ORI", clsAppTranslation.GetSingleParameterValue(1706, "", "Q.Da Pr."), True, DefDtGridCol_QtaDaPrelevare, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MEINS_ORI", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(1707, "", "Q.Prep."), True, DefDtGridCol_QtaPrelevata, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTA_PREL_PZ", clsAppTranslation.GetSingleParameterValue(364, "", "Sfusi"), True, DefDtGridCol_QtaPrelevata, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MEINS_PZ", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "STATUS", clsAppTranslation.GetSingleParameterValue(365, "", "Stato"), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_PROP", clsAppTranslation.GetSingleParameterValue(366, "", "Ope.Prop."), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(367, "", "Ope.Esec."), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat."), True, DefDtGridCol_DescrMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "SEQUENCE", clsAppTranslation.GetSingleParameterValue(369, "", "Seq."), True, DefDtGridCol_Sequenza, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "PRIORITA", clsAppTranslation.GetSingleParameterValue(370, "", "Pri."), True, DefDtGridCol_Priorita, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "URGENTE", clsAppTranslation.GetSingleParameterValue(371, "", "Urg."), True, DefDtGridCol_Urgente, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNRPICK", clsAppTranslation.GetSingleParameterValue(658, "", "N°Ord.Pic."), False, DefDtGridCol_NumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZPOSPK", clsAppTranslation.GetSingleParameterValue(659, "", "Pos.Ord.Pic."), False, DefDtGridCol_PosNumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_GRPEXEC", clsAppTranslation.GetSingleParameterValue(660, "", "Ragr."), False, DefDtGridCol_NumGruppoExecMissioni, True)

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
    Public Function GetSelectedGridRowInfo(ByVal inCurrentRowIndex As Long, ByRef outSelezioneOk As Boolean, ByVal RefreshWithDataRow As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedGridRowInfo = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (clsWmsJob.objDataTableWmsJobsList Is Nothing)) Then
                'SE HO SELEZIONATO UNA RIGA
                If ((clsWmsJob.objDataTableWmsJobsList.Rows.Count > 0) And (inCurrentRowIndex >= 0)) Then
                    'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                    WorkDataRow = clsWmsJob.objDataTableWmsJobsList.Rows(inCurrentRowIndex)
                    If (RefreshWithDataRow = True) Then
                        'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
                        RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, clsWmsJob.WmsJob, False)
                        If (RetCode = 0) Then
                            outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                        End If
                    End If
                    'AGGIORNO LA LISTA CON LE INFORMAZIONI PER L'UTENTE
                    Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPutAwayInfoForUserString(0)
                End If
            End If

            GetSelectedGridRowInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetSelectedGridRowInfo = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtGridListInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdCloseJobsGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseJobsGroup.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkString As String = ""
        Dim GetExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '>>> RECUPERO INFORMAZIONI DI SUMMARY SUL GRUPPO DEI JOBS
            RetCode = clsWmsJobsGroup.GetJobsGroupSummary(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, GetExecutionOk, False)
            If ((RetCode <> 0) Or (GetExecutionOk = False)) Then
                '>>> CASO DI ERRORE IN ESECUZIONE
                WorkString = clsAppTranslation.GetSingleParameterValue(655, "", "Errore in lettura dati esecuzione LISTA PRELIEVO.")
                MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> PASSO ALLA VIDEATA DI CHIUSURA DEL PICKING
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeCloseGroupSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdJobFunctions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(657, "", "Attenzione, selezione RIGA MISSIONE non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            frmEM_FromJob_Part_FunzioniForm = New frmEM_FromJob_Part_Funzioni
            frmEM_FromJob_Part_FunzioniForm.SourceForm = Me
            frmEM_FromJob_Part_FunzioniForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class