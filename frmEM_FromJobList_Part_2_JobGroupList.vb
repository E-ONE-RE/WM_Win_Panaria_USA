
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic


Public Class frmEM_FromJobList_Part_2_JobGroupList

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJobList_Part_2_JobGroupList"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 116
                    btnDetails_Click(Me, e)
            End Select

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

#If Not APPLICAZIONE_WIN32 = "SI" Then

    Private Sub frmEM_FromJobList_Part_2_JobGroupList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
            If ((Me.cmdPreviousScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdPreviousScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdAbortScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdAbortScreen_Click(Me, e)
                    Exit Sub
                End If
            End If


            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.F5)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnDetails_Click(Me, e)
                Exit Sub
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

#End If

    Private Sub frmEM_FromJobList_Part_2_JobGroupList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(83, Me.Text, "EM - Lista (2)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.btnDetails.Text = clsAppTranslation.GetSingleParameterValue(254, Me.btnDetails.Text, "Dettagli")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************


            If (Not clsWmsJobsGroup.objDataTableWmsJobGroupList Is Nothing) Then
                clsWmsJobsGroup.objDataTableWmsJobGroupList.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsWmsJobsGroup.objDataTableWmsJobGroupList
            End If

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            RetCode = GetSelectedGridRowInfo(UserSelezioneOk)

            Me.Text = "EM-Lista (2)"
            Me.Text = Me.Text & "-" & Trim(clsWmsJobsGroup.GetRowCountWmsJobGroupList(False))


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

            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)

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
        Dim JobsGroupOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedGridRowInfo(UserSelezioneOk)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(302, "", "Attenzione, selezione stock non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'RECUPERO TUTTI I DATI DEL JOBGROUP ASSOCIATO ALL'ENTRATA MERCE
            RetCode += clsWmsJob.ClearAllData()
            RetCode += clsEMFromJob.ClearAllData()
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, Nothing, Nothing, JobsGroupOk, False)
            'VERIFICO SE IL GRUPPO E' STATO CANCELLATO (FLAG IMPOSTATO DAL CRUSCOTTO PER ORDINE ANNULLATO)
            If (clsWmsJobsGroup.WmsJobsGroupInfo.FoundGroupDeleted = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(649, "", "Attenzione! Il Gruppo Missioni e' stato CANCELLATO/ANNULLATO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(650, "", "Contattare SUBITO l'ufficio spedizioni per verificare la lista.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '>>> IN QUESTO CASO NON SI PUO' FORZARE L'ESECUZIONE IN QUANTO TUTTI I JOB SONO CANCELLATI
                Exit Sub
            End If
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(349, "", "Attenzione! Gruppo Missioni inserito non definito nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(350, "", "Verificare il dato immesso e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO LE VERIFICHE PER POTERE ATTIVARE IL GRUPPO MISSIONI
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkBeforeActivate(JobsGroupOk, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            '>>> ATTIVO IL GRUPPO MISSIONI E ASSEGNO LE MISSIONI DEL GRUPPO ALL'OPERATORE
            RetCode = clsWmsJobsGroup.JobsGroupsActivate(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, clsUser.SapWmsUser.ZCARR, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(354, "", "Attenzione! Errore in ATTIVAZIONE gruppo missioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(350, "", "Verificare il dato immesso e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            RetCode = clsWmsJobsGroup.LoadDataRowFirstJob()


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

    Public Function RefreshActiveGridRowInfo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshActiveGridRowInfo = 1 'INIT AT ERROR

            Me.txtInfoRowSelected.Text = clsWmsJobsGroup.FromSapJobsGroupInfoStructToString(0)

            RefreshActiveGridRowInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_JOBSGRP", clsAppTranslation.GetSingleParameterValue(761, "", "Grup.Miss."), True, DefDtGridCol_NumGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "NUM_ACCORPAMENTI", clsAppTranslation.GetSingleParameterValue(764, "", "Num.Miss."), True, DefDtGridCol_NumRigheMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_SCATOLE", clsAppTranslation.GetSingleParameterValue(765, "", "Tot.Scatole"), True, DefDtGridCol_NumTotScatoleGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_M2", clsAppTranslation.GetSingleParameterValue(766, "", "Tot.M2"), True, DefDtGridCol_NumTotM2GruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_PZ", clsAppTranslation.GetSingleParameterValue(767, "", "Tot.PZ"), True, DefDtGridCol_NumTotPezziGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_OTHERS", clsAppTranslation.GetSingleParameterValue(768, "", "Tot.Altri"), True, DefDtGridCol_NumTotAltriGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNRPICK", clsAppTranslation.GetSingleParameterValue(762, "", "Ord.Pick."), True, DefDtGridCol_NumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_PROP", clsAppTranslation.GetSingleParameterValue(366, "", "Ope.Prop."), True, DefDtGridCol_CarrelistaProposto, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(367, "", "Ope.Esec."), True, DefDtGridCol_CarrelistaEsecuzione, True)
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

    Public Function GetSelectedGridRowInfo(ByRef outSelezioneOk As Boolean) As Long
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
            If (Not (clsWmsJobsGroup.objDataTableWmsJobGroupList Is Nothing)) Then
                If (clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridListInfo.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows(Me.DtGridListInfo.CurrentRowIndex)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsWmsJobsGroup.FromDataRowToSapJobsGroupInfoStruct(WorkDataRow, clsWmsJobsGroup.WmsJobsGroupInfo, False)
                            If (RetCode = 0) Then
                                outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                                'VISUALIZZO DATI CORRENTI
                                RetCode = RefreshActiveGridRowInfo()
                            End If
                        End If
                    End If
                End If
            End If

            GetSelectedGridRowInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtGridListInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedGridRowInfo(UserSelezioneOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedGridRowInfo(UserSelezioneOk)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(355, "", "Attenzione, selezione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsUtility.IsStringValid(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, True) = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(757, "", "Attenzione! Numero Gruppo Missioni non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsWmsJobsGroup.RowIndex = Me.DtGridListInfo.CurrentRowIndex
            clsWmsJobsGroup.objDetailsDataRow = clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows(Me.DtGridListInfo.CurrentRowIndex)
            clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            'VISUALIZZO IL DETTAGLIO DEL JOBS GROUP
            RetCode = clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType.EM_FromJob_SourceTypeJobGroup, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


#If APPLICAZIONE_WIN32 = "SI" Then

    Private Sub frmEM_FromJobList_Part_2_JobGroupList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        frmKeyDown(Me, e)
    End Sub

    Private Sub DtGridListInfo_KeyDown(sender As Object, e As KeyEventArgs) Handles DtGridListInfo.KeyDown
        frmKeyDown(Me, e)
    End Sub

    Private Sub DtGridListInfo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtGridListInfo.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (e.KeyChar = Chr(Keys.F5)) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnDetails_Click(Me, e)
                Exit Sub
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmKeyDown(sender As Object, e As KeyEventArgs)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.DtGridListInfo.Focused = True) And (Me.DtGridListInfo.CurrentRowIndex >= 0)) Then
                If ((e.KeyCode = Keys.Escape) Or (e.KeyCode = Keys.Return)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyCode = Keys.Escape) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdPreviousScreen.Focused = True)) Then
                If (e.KeyCode = Keys.Escape) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdPreviousScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.cmdAbortScreen.Focused = True)) Then
                If (e.KeyCode = Keys.Escape) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdAbortScreen_Click(Me, e)
                    Exit Sub
                End If
            End If


            If (e.KeyCode = Keys.F5) Then
                'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                Call Me.btnDetails_Click(Me, e)
                Exit Sub
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

#End If


End Class