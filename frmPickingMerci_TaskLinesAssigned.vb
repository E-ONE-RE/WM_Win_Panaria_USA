
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsWmsJob

Public Class frmPickingMerci_TaskLinesAssigned

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_TaskLinesAssigned"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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

        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                WorkDataRow = clsTaskLinesAssigned.objDataTableTaskLinesAssigned.Rows(Me.DtGridViewInfo.CurrentRow.Index)

                'IMPOSTO IL NR MISSIONE UTENTE
                clsUser.SapWmsUser.ZNR_WMS_JOBS = WorkDataRow.Item("ZNR_WMS_JOBS")
                clsUser.SapWmsUser.ZID_PICK_QUEUE = WorkDataRow.Item("ZID_PICK_QUEUE")
                clsUser.SapWmsUser.ZPICK_QUEUE_DESC = WorkDataRow.Item("ZPICK_QUEUE_DESC")

                Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_TaskLinesAssigned_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                If ((Me.DtGridViewInfo.Focused = True) And (Me.DtGridViewInfo.CurrentRow.Index >= 0)) Then
                    If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                        Call Me.cmdNextScreen_Click(Me, e)
                        Exit Sub
                    End If
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

    Private Sub frmPickingMerci_TaskLinesAssigned_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(1678, Me.Text, "Task Lines Assegnate")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(8, Me.cmdAbortScreen.Text, "OK")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1582, Me.cmdNextScreen.Text, "SELEZIONA")
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()

            Me.cmdSetDropPick.Text = clsAppTranslation.GetSingleParameterValue(1703, Me.cmdSetDropPick.Text, "ANNULLA PRENOTAZIONE")
            '**************************************        


            If Not (clsTaskLinesAssigned.objDataTableTaskLinesAssigned Is Nothing) Then
                clsTaskLinesAssigned.objDataTableTaskLinesAssigned.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID  
                Me.DtGridViewInfo.DataSource = clsTaskLinesAssigned.objDataTableTaskLinesAssigned
            End If

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            Me.DtGridViewInfo.Focus()
            Me.DtGridViewInfo.ReadOnly = True


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

            'Pulisco gli oggetti Coloumn del DataGridView
            Me.DtGridViewInfo.Columns.Clear()

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1668, "", "N° Task Lines"), False, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "USERID_RF", clsAppTranslation.GetSingleParameterValue(1669, "", "N° Task Lines"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZID_PICK_QUEUE", clsAppTranslation.GetSingleParameterValue(1239, "", "Id"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZPICK_QUEUE_DESC", clsAppTranslation.GetSingleParameterValue(1240, "", "Descrizione Coda"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZNR_TASK_LINES", clsAppTranslation.GetSingleParameterValue(1670, "", "N° Task Lines"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "DATA_CREAZIONE", clsAppTranslation.GetSingleParameterValue(1375, "", "Data Creazione"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZNR_WMS_JOBS", clsAppTranslation.GetSingleParameterValue(361, "", "N°Miss."), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZTASK_LINES_SEQ", clsAppTranslation.GetSingleParameterValue(1671, "", "Seq. Task Lines"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZPICKFULLPARTIAL", clsAppTranslation.GetSingleParameterValue(1672, "", "PickFullPartial"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "IDSTATUS", clsAppTranslation.GetSingleParameterValue(1337, "", "Id Status"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "STATUS", clsAppTranslation.GetSingleParameterValue(365, "", "Status"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTAPK_FULL_PALL", clsAppTranslation.GetSingleParameterValue(1673, "", "Qta Full Pall"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTAPK_PARTIAL", clsAppTranslation.GetSingleParameterValue(1674, "", "Qta Partial"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTAPK_SFUSI_PZ", clsAppTranslation.GetSingleParameterValue(1352, "", "Qta Sfusi PZ"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTA_PREL_FULL", clsAppTranslation.GetSingleParameterValue(1675, "", "Qta Prel Full"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTA_PREL_PARTIA", clsAppTranslation.GetSingleParameterValue(1676, "", "Qta Prel Partial"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTA_PREL_SF", clsAppTranslation.GetSingleParameterValue(1677, "", "Qta Prel SF"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZWMS_PESOMAT_USA", clsAppTranslation.GetSingleParameterValue(1504, "", "Peso Mat USA"), True, DefDtGridCol_NumeroMissione, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "GEWEI_USA", clsAppTranslation.GetSingleParameterValue(868, "", "UdM USA"), True, DefDtGridCol_NumeroMissione, True)

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

    Public Function GetSelectedGridRowInfo(ByVal inDataGridViewRow As DataGridViewRow, ByRef outSelezioneOk As Boolean, ByVal RefreshWithDataRow As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim SetTaskLinesOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedGridRowInfo = 1 'INIT AT ERROR

            outSelezioneOk = False 'init


            Dim dv As System.Data.DataRowView = CType(inDataGridViewRow.DataBoundItem, DataRowView)
            WorkDataRow = dv.Row


            If WorkDataRow Is Nothing Then
                Exit Function
            End If

            'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
            RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, clsWmsJob.WmsJob, False)
            If (RetCode = 0) Then
                '>>> IMPOSTO LA PRIMA TASK LINES DEL NUOVO JOB SELEZIONATO
                RetCode = clsWmsJob.TaskLines.SetCurrentTaskLinesOnWork(clsWmsJob.WmsJob.NrWmsJobs, SetTaskLinesOk)

                outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                Me.txtInfoRowSelected.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)
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

    Private Sub cmdAbortScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub DtGridViewInfo_KeyDown(sender As Object, e As KeyEventArgs) Handles DtGridViewInfo.KeyDown
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CODICE PER IMPEDIRE AVANZAMENTO NELL'INDICE RIGA SUL ENTER
            If e.KeyCode = 13 Then
                If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                    Me.DtGridViewInfo.CurrentRow.Selected = True
                    e.Handled = True
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


    Private Sub cmdSetDropPick_Click(sender As Object, e As EventArgs) Handles cmdSetDropPick.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckExecutionOk As Boolean = False
        Dim UserAnswer As DialogResult
        Dim ExecutionOk As Boolean = False
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza

        Dim WorkDataRow As DataRow
        Dim WorkDataGridRow As DataGridViewRow
        Dim WorkDataGridRowLines As DataGridViewRow

        Dim WorkSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim inNrWmsJobs() As Long
        Dim i As Integer
        Dim wkTaskLinesFound As Boolean = False
        Dim outExecutionOk As Boolean = False

        Dim wkZNR_WMS_JOBS As Integer = 5
        Dim wkZNR_TASK_LINES As Integer = 3

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            '*************************************************************************************************************************************
            '>>> ESEGUO CANCELLAZIONE DELLA PRENOTAZIONE DELLA SINGOLA TASK LINES ANCORA DA ESEGUIRE ( UNA CHIAMATA PER SINGOLO JOB )
            '*************************************************************************************************************************************

            'Controllo che sia stata selezionata almeno una riga
            If Me.DtGridViewInfo.SelectedRows.Count = 0 Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1701, "", "Attenzione! Nessuna riga selezionata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            For Each WorkDataGridRow In Me.DtGridViewInfo.SelectedRows()

                ReDim Preserve inNrWmsJobs(i)

                If i = 0 Then

                    'Chiedo conferma dell'operazione di ANNULLAMENTO PRENOTAZIONE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1702, "", "Si è veramente sicuri di voler Annullare le TaskLines Selezionate?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If

                    inNrWmsJobs(i) = WorkDataGridRow.Cells(wkZNR_WMS_JOBS).Value

                Else
                    'Controllo di non aver gia' lavorato su questo Job
                    For j = 0 To inNrWmsJobs.Count - 1
                        If inNrWmsJobs(j) = WorkDataGridRow.Cells(wkZNR_WMS_JOBS).Value Then
                            wkTaskLinesFound = True
                        End If
                    Next
                End If


                'Se non ho gia' lavorato le TaskLines del Job lo faccio qui
                If wkTaskLinesFound = False Then

                    If i <> 0 Then
                        'Aggiorno Array Jobs Lavorati
                        inNrWmsJobs(i) = WorkDataGridRow.Cells(wkZNR_WMS_JOBS).Value
                    End If


                    'Creo il DataTable di tutte le TaskLines del Job della Riga Selezionata
                    Dim WorkDataTableTaskLinesYetToExecute As New DataTable
                    WorkDataTableTaskLinesYetToExecute.Columns.Add("ZNR_TASK_LINES", Type.GetType("System.String"))


                    For Each WorkDataGridRowLines In Me.DtGridViewInfo.SelectedRows

                        If WorkDataGridRowLines.Cells(5).Value = WorkDataGridRow.Cells(wkZNR_WMS_JOBS).Value Then

                            Dim WorkDataRowTaskLinesYetToExecute As DataRow = WorkDataTableTaskLinesYetToExecute.NewRow

                            WorkDataRowTaskLinesYetToExecute("ZNR_TASK_LINES") = WorkDataGridRowLines.Cells(wkZNR_TASK_LINES).Value
                            WorkDataTableTaskLinesYetToExecute.Rows.Add(WorkDataRowTaskLinesYetToExecute)

                        End If

                    Next


                    RetCode = clsSapWS.Call_ZWMS_DELETE_JOBS_TASKLINES(inNrWmsJobs(i), WorkDataTableTaskLinesYetToExecute, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, Nothing, Nothing, SapFunctionError, False)
                    If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(748, "", "Errore in DROP PICK MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ExecutionOk = False 'SETTO FLAG DI ERRORE
                    End If


                End If


                i += 1
                wkTaskLinesFound = False


            Next


            'Rinfresco i dati della griglia
            RetCode += clsWmsJob.ClearAllData()
            RetCode = clsWmsJobsGroup.GetTaskLinesAssigned(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, "", "", True, outExecutionOk, False)
            'VERIFICO SE IL GRUPPO E' STATO CANCELLATO (FLAG IMPOSTATO DAL CRUSCOTTO PER ORDINE ANNULLATO)
            If (clsWmsJobsGroup.WmsJobsGroupInfo.FoundGroupDeleted = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(649, "", "Attenzione! Il Gruppo Missioni e' stato CANCELLATO/ANNULLATO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(650, "", "Contattare SUBITO l'ufficio spedizioni per verificare la lista.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '>>> IN QUESTO CASO NON SI PUO' FORZARE L'ESECUZIONE IN QUANTO TUTTI I JOB SONO CANCELLATI
                Exit Sub
            End If
            If (RetCode <> 0) Or (outExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1498, "", "Attenzione! Missioni non trovate nella CODA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(350, "", "Verificare il dato immesso e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call frmPickingMerci_TaskLinesAssigned_Load(Me, e)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class