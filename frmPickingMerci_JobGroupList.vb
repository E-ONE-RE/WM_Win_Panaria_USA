
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmPickingMerci_JobGroupList

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_JobGroupList"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_JobGroupList_KeyPress(Me, e)

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
        Dim UserSelezioneOk As Boolean = False
        Dim UserAnswer As DialogResult
        Dim ExecutionOk As Boolean = False
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

            If (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaProposto = "") And (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione = "") Then
                '>>> CASO DI MISSIONE NON ATTRIBUITA A NESSUN OPERATORE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(758, "", "Si desidera ASSEGNARSI il GRUPPO MISSIONI selezionato ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Exit Sub
                End If
            Else
                If (clsUtility.IsStringValid(clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione, True) = True) And (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione <> clsUser.SapWmsUser.ZCARR) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(351, "", "Il GRUPPO è stato ESEGUITO da ") & clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione & vbCrLf & clsAppTranslation.GetSingleParameterValue(352, "", "Si desidera ESEGUIRE il GRUPPO MISSIONI selezionato ?")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
                If (clsUtility.IsStringValid(clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaProposto, True) = True) And (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione <> clsUser.SapWmsUser.ZCARR) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(353, "", "Il GRUPPO è stato ATTRIBUITO a ") & clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaProposto & vbCrLf & clsAppTranslation.GetSingleParameterValue(352, "", "Si desidera ESEGUIRE il GRUPPO MISSIONI selezionato ?")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
            End If

            'RECUPERO TUTTI I DATI DEL JOBGROUP
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, Nothing, Nothing, ExecutionOk, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(706, "", "Attenzione! Dati JOBGROUP non trovati nel sistema.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '>>> ATTIVO IL GRUPPO MISSIONI E ASSEGNO LE MISSIONI DEL GRUPPO ALL'OPERATORE
            RetCode = clsWmsJobsGroup.JobsGroupsActivate(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, clsUser.SapWmsUser.ZCARR, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(759, "", "Attenzione! Errore in JOBGROUP ACTIVATE")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '>>> CHIEDO ALL'OPERATORE SE DESIDERA ESEGUIRE IL GRUPPO MISSIONE
            ErrDescription = clsAppTranslation.GetSingleParameterValue(760, "", "Si desidera ESEGUIRE ORA il GRUPPO MISSIONI selezionato ?")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> DialogResult.Yes) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_JobGroupList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmPickingMerci_JobGroupList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(181, Me.Text, "Pick.Group List")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(252, cmdAbortScreen.Text, "Chiudi")
            btnDetails.Text = clsAppTranslation.GetSingleParameterValue(254, btnDetails.Text, "Dettagli")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '**************************************   


            'LEGGO IL DATASET DA VISUALIZZARE
            clsWmsJob.GetJobsGroupsList("PICKING", True)


            If Not (clsWmsJobsGroup.objDataTableWmsJobGroupList Is Nothing) Then
                clsWmsJobsGroup.objDataTableWmsJobGroupList.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridListInfo.DataSource = clsWmsJobsGroup.objDataTableWmsJobGroupList
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            RetCode = GetSelectedGridRowInfo(UserSelezioneOk)

            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshActiveGridRowInfo()

            Me.Text = clsAppTranslation.GetSingleParameterValue(181, "", "Pick.Group List")
            If (Not (clsWmsJobsGroup.objDataTableWmsJobGroupList Is Nothing)) Then
                Me.Text = Me.Text & "-" & clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows.Count
            End If


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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNR_WMS_JOBSGRP", clsAppTranslation.GetSingleParameterValue(761, "", "Grup.Miss."), True, DefDtGridCol_NumGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZNRPICK", clsAppTranslation.GetSingleParameterValue(762, "", "Ord.Pick."), True, DefDtGridCol_NumOrdinePicking, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "ZWMS_JOBSGRP_DESCR", clsAppTranslation.GetSingleParameterValue(763, "", "Desc.Grup.Miss."), True, DefDtGridCol_DescrGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "NUM_ACCORPAMENTI", clsAppTranslation.GetSingleParameterValue(764, "", "Num.Miss."), True, DefDtGridCol_NumRigheMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_SCATOLE", clsAppTranslation.GetSingleParameterValue(765, "", "Tot.Scatole"), True, DefDtGridCol_NumTotScatoleGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_M2", clsAppTranslation.GetSingleParameterValue(766, "", "Tot.M2"), True, DefDtGridCol_NumTotM2GruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_PZ", clsAppTranslation.GetSingleParameterValue(767, "", "Tot.PZ"), True, DefDtGridCol_NumTotPezziGruppoMissioni, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridListInfo, "", "TOT_NUM_OTHERS", clsAppTranslation.GetSingleParameterValue(768, "", "Tot.Altri"), True, DefDtGridCol_NumTotAltriGruppoMissioni, True)
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
    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtGridListInfo.CurrentCellChanged
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

            'VISUALIZZO IL DETTAGLIO DEL JOBS GROUP
            RetCode = clsNavigation.Show_JobGroup_Details(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, Me, True)
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
End Class