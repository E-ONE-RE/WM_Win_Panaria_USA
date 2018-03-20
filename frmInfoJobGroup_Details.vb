Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoJobGroup_Details

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoJobGroup_Details"


    Private ErrDescription As String

    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInfoJobGroup_Details_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoJobGroup_Details_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'If ((Me.txtNumMag.Focused = True) And (Me.txtNumMag.Text <> "")) Then
            '    If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

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
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmEM_FromJobList_Part_2_JobGroupList.GetType.Name) Then
                'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
                Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
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
            If (Me.DtGridShowInfo.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "PropertyId", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), False, 0, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "PropertyText", clsAppTranslation.GetSingleParameterValue(542, "", "Proprietà"), True, 120, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridShowInfo, "", "PropertyValue", clsAppTranslation.GetSingleParameterValue(543, "", "Valore"), True, 500, True)
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

    Private Sub frmInfoJobGroup_Details_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(114, Me.Text, "Info Lista Missioni")
            Me.btnClose.Text = clsAppTranslation.GetSingleParameterValue(252, Me.btnClose.Text, "Chiudi")
            '**************************************   

            If Not (clsWmsJobsGroup.objDataTableDetailsWmsJobGroup Is Nothing) Then
                clsWmsJobsGroup.objDataTableDetailsWmsJobGroup.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridShowInfo.DataSource = clsWmsJobsGroup.objDataTableDetailsWmsJobGroup
            End If


            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNone)

            Me.lblIndex.Text = clsWmsJobsGroup.RowIndex + 1

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'refresh dei dati
            RetCode += clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsWmsJobsGroup.objDetailsDataRow = clsUtility.ExecDataTableMove(clsWmsJobsGroup.objDataTableWmsJobGroupList, clsWmsJobsGroup.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst)
            clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            lblIndex.Text = clsWmsJobsGroup.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsWmsJobsGroup.objDetailsDataRow = clsUtility.ExecDataTableMove(clsWmsJobsGroup.objDataTableWmsJobGroupList, clsWmsJobsGroup.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev)
            clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            lblIndex.Text = clsWmsJobsGroup.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsWmsJobsGroup.objDetailsDataRow = clsUtility.ExecDataTableMove(clsWmsJobsGroup.objDataTableWmsJobGroupList, clsWmsJobsGroup.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext)
            clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            lblIndex.Text = clsWmsJobsGroup.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            clsWmsJobsGroup.objDetailsDataRow = clsUtility.ExecDataTableMove(clsWmsJobsGroup.objDataTableWmsJobGroupList, clsWmsJobsGroup.RowIndex, clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast)
            clsWmsJobsGroup.RefreshDateTableDetailsInfo()

            lblIndex.Text = clsWmsJobsGroup.RowIndex + 1

            RefreshNavBtn(clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub RefreshNavBtn(ByVal inDateTableMoveOpType As clsUtility.DateTableMoveOpTypeEnum)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            Select Case inDateTableMoveOpType
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst
                    cmdLast.Enabled = True
                    cmdNext.Enabled = True
                    cmdPrevious.Enabled = False
                    cmdFirst.Enabled = False
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast
                    cmdLast.Enabled = False
                    cmdNext.Enabled = False
                    cmdPrevious.Enabled = True
                    cmdFirst.Enabled = True
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext
                    If clsWmsJobsGroup.RowIndex < clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows.Count - 1 Then
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    Else
                        cmdLast.Enabled = False
                        cmdNext.Enabled = False
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    End If
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev
                    If clsWmsJobsGroup.RowIndex > 0 Then
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = True
                        cmdFirst.Enabled = True
                    Else
                        cmdLast.Enabled = True
                        cmdNext.Enabled = True
                        cmdPrevious.Enabled = False
                        cmdFirst.Enabled = False
                    End If
                Case clsUtility.DateTableMoveOpTypeEnum.DateTableMoveOpTypeNone
                    Select Case clsWmsJobsGroup.RowIndex
                        Case 0
                            cmdLast.Enabled = True
                            cmdNext.Enabled = True
                            cmdPrevious.Enabled = False
                            cmdFirst.Enabled = False
                        Case clsWmsJobsGroup.objDataTableWmsJobGroupList.Rows.Count - 1
                            cmdLast.Enabled = False
                            cmdNext.Enabled = False
                            cmdPrevious.Enabled = True
                            cmdFirst.Enabled = True
                        Case Else
                            cmdLast.Enabled = True
                            cmdNext.Enabled = True
                            cmdPrevious.Enabled = True
                            cmdFirst.Enabled = True
                    End Select
            End Select


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class