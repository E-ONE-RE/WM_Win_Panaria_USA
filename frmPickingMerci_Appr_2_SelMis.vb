
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsWmsJob

Public Class frmPickingMerci_Appr_2_SelMis

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_2_SelMis"

    Private ErrDescription As String
    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_2_SelMis_KeyPress(Me, e)

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
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeCloseGroupSeq, True)

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
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Me.DtGridListInfo.CurrentRowIndex > 0) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, False)
                If (UserSelezioneOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(657, "", "Attenzione, selezione RIGA MISSIONE non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '>>> VERIFICO LE CONDIZIONI OK PER POTERE ESEGUIRE IL PICKING DI UN JOB
            RetCode = clsWmsJob.JobsActivateExecution("", True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> IMPOSTO IL CARRELLISTA DI ESECUZIONE DELLA MISSIONE
            RetCode = clsWmsJob.SetJobCarrellistaEsecuzioneMissione(True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1596, "", "Errore in IMPOSTAZIONE OPERATORE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> MOSTRO UN WARNING PER LE MISSIONI DI SOLA VERIFICA
            RetCode = clsWmsJob.ShowJobsCheckMaterialWarning(True)

            'PASSO ALLO STEP SUCCESSIVO
            RetCode = clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_2_SelMis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

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

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_2_SelMis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(154, Me.Text, "Picking Appr. (2)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(268, cmdAbortScreen.Text, "Esci")
            Me.cmdCloseJobsGroup.Text = clsAppTranslation.GetSingleParameterValue(267, cmdCloseJobsGroup.Text, "Chiudi Lista")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdJobFunctions.Text, "...")
#Else
            cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdJobFunctions.Text, "...")
#End If

            '**************************************        

            If Not (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                clsWmsJob.objDataTableWmsJobsList.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsWmsJob.objDataTableWmsJobsList
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'REFRESH INFO RIGA SELEZIO
            If (Me.DtGridListInfo.CurrentRowIndex > 0) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)
            End If


            Me.Text = "Picking Appr.(2)" & "-" & Trim(Str(clsWmsJob.GetRowCountWmsJobsList(False)))

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.DtGridListInfo.Focus()

            'SI POSIZIONE SULLA PRIMA RIGA DA ESEGUIRE
            RetCode = clsShowUtility.VaiAllaPrimaRigaDaEseguire(Me.DtGridListInfo)

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "GRID_EXECUTED", " ", True, DefDtGridCol_GridExecuted + 3, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_JOBS", clsAppTranslation.GetSingleParameterValue(361, "", "N°Miss."), True, DefDtGridCol_NumeroMissione, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MATNR_ORI", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "CHARG_ORI", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTAPK_ORI", clsAppTranslation.GetSingleParameterValue(363, "", "Q.Da Pr."), True, DefDtGridCol_QtaDaPrelevare, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MEINS_ORI", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prel."), True, DefDtGridCol_QtaPrelevata, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "STATUS", clsAppTranslation.GetSingleParameterValue(365, "", "Stato"), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_PROP", clsAppTranslation.GetSingleParameterValue(366, "", "Ope.Prop."), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(367, "", "Ope.Esec."), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat."), True, DefDtGridCol_DescrMateriale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "SEQUENCE", clsAppTranslation.GetSingleParameterValue(369, "", "Seq."), True, DefDtGridCol_Sequenza, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "PRIORITA", clsAppTranslation.GetSingleParameterValue(370, "", "Pri."), True, DefDtGridCol_Priorita, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "URGENTE", clsAppTranslation.GetSingleParameterValue(371, "", "Urg."), True, DefDtGridCol_Urgente, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNRPICK", clsAppTranslation.GetSingleParameterValue(658, "", "N°Ord.Pic."), True, DefDtGridCol_NumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZPOSPK", clsAppTranslation.GetSingleParameterValue(659, "", "Pos.Ord.Pic."), True, DefDtGridCol_PosNumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_GRPEXEC", clsAppTranslation.GetSingleParameterValue(660, "", "Ragr."), True, DefDtGridCol_NumGruppoExecMissioni, True)
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
                        Me.txtInfoRowSelected.Text = clsWmsJob.FromSapWmWmsJobDataRowToString(WorkDataRow)
                    Else
                        'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
                        RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, clsWmsJob.WmsJob, False)
                        If (RetCode = 0) Then
                            outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                            Me.txtInfoRowSelected.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)
                        End If
                    End If
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
    'Public Function RefreshActiveGridRowInfo() As Long
    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long = 0
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        RefreshActiveGridRowInfo = 1 'INIT AT ERROR

    '        Me.txtInfoRowSelected.Text = clsWmsJob.ShowJobPickingInfoForUserString(0)

    '        RefreshActiveGridRowInfo = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function
    Private Sub DtGridListInfo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtGridListInfo.CurrentCellChanged

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA RIGA RINFRESCO LE INFORMAZIONI VISUALIZZATE
            If (Me.DtGridListInfo.CurrentRowIndex > 0) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, True)
            End If

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
            If (Me.DtGridListInfo.CurrentRowIndex > 0) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridListInfo.CurrentRowIndex, UserSelezioneOk, False)
                If (UserSelezioneOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(657, "", "Attenzione, selezione RIGA MISSIONE non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            frmPickingMerci_Appr_FunzioniForm = New frmPickingMerci_Appr_Funzioni
            frmPickingMerci_Appr_FunzioniForm.SourceForm = Me
            frmPickingMerci_Appr_FunzioniForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdAbortScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '>>> GESTIONE SENZA CHIUSURA LISTA ( PRIMA VERSIONE DEL PROGRAMMA )
            WorkString = clsAppTranslation.GetSingleParameterValue(656, "", "Si desidera eseguire un'altra lista di prelievo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                'PASSO ALLA VIDEATA INIZIALE
                Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
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
End Class