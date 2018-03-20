
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsWmsJob

Public Class frmPickingMerci_Code_2_SelMis

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_2_SelMis"

    Private ErrDescription As String
    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_2_SelMis_KeyPress(Me, e)

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
        Dim SetTaskLinesOk As Boolean = False
        Dim FlagAllTaskLinesAreFinish As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridViewInfo.CurrentRow, UserSelezioneOk, False)
                If (UserSelezioneOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(657, "", "Attenzione, selezione RIGA MISSIONE non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'VERIFICO SE IL JOB  PREVEDE ALTRE TASK LINES
            'RetCode = clsWmsJob.TaskLines.CheckIfAllTaskLinesAreFinish(clsWmsJob.WmsJob.NrWmsJobs, FlagAllTaskLinesAreFinish, False)
            'If (RetCode <> 0) Or (FlagAllTaskLinesAreFinish = True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(741, "", "Attenzione! La missione selezionata e' terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1242, "", "Missione:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            '>>> VERIFICO LE CONDIZIONI OK PER POTERE ESEGUIRE IL PICKING DI UN JOB
            RetCode = clsWmsJob.JobsActivateExecution("", True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> MOSTRO UN WARNING PER LE MISSIONI DI SOLA VERIFICA
            RetCode = clsWmsJob.ShowJobsCheckMaterialWarning(True)

            '***************************************************************************************************
            'RECUPERO LA PRIMA  TASK LINES DA ESEGUIRE DEL JOB SELEZIONATO
            '***************************************************************************************************
            RetCode = clsWmsJob.TaskLines.SetCurrentTaskLinesOnWork(clsWmsJob.WmsJob.NrWmsJobs, SetTaskLinesOk)
            If (RetCode <> 0) Or (SetTaskLinesOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1506, "", "Errore nella selezione della TASK LINE attiva.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
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


            'Controllo se è presente una NOTA di INFO avverto con MsgBox
            If clsWmsJob.WmsJob.InfoPrelievo <> "" Then

                ErrDescription = clsAppTranslation.GetSingleParameterValue(1704, "", "SPECIAL NOTE: ") & clsWmsJob.WmsJob.InfoPrelievo
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            End If

            If (clsUtility.IsStringValid(clsWmsJob.UDSOnWork.UnitaMagazzino, True) = True) And (Me.DtGridViewInfo.RowCount > 1) Then

                '*********************************************************************************************************************
                'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
                '*********************************************************************************************************************
                RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'IN QUESTO CASO PASSO DIRETTAMENTE AL PRELIEVO PER RISPARMIARE TEMPO ( IL KTAG RIMANE QUELLO IN LAVORAZIONE)
                frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()

                RetCode = clsNavigation.CloseSourceForm(Me, True)
            Else
                'PASSO ALLO STEP SUCCESSIVO => CASO NORMALE DOVE DEFINISCO IL KTAG
                RetCode = clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_2_SelMis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not Me.DtGridViewInfo Is Nothing) Then
                If (Not Me.DtGridViewInfo.CurrentRow Is Nothing) Then
                    If ((Me.DtGridViewInfo.Focused = True) And (Me.DtGridViewInfo.CurrentRow.Index >= 0)) Then
                        If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                            'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                            Call Me.cmdNextScreen_Click(Me, e)
                            Exit Sub
                        End If
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

    Private Sub frmPickingMerci_Code_2_SelMis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        Dim i As Integer = 0

        Dim WorkSapWmWmsJob As clsDataType.SapWmWmsJob

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.Text = clsAppTranslation.GetSingleParameterValue(1284, Me.Text, "Picking Appr. (2)")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(268, Me.cmdAbortScreen.Text, "Esci")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, Me.cmdNextScreen.Text, "OK")
            Me.cmdGetNewJobTask.Text = clsAppTranslation.GetSingleParameterValue(1534, Me.cmdGetNewJobTask.Text, "OK")
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
            Me.txtInfoPesoMissione.Text = clsWmsJob.ShowJobWeightInfoForUserString(1)

            Me.cmdDropUDS.Text = clsAppTranslation.GetSingleParameterValue(1688, Me.cmdDropUDS.Text, "Drop Pallet")


#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
#Else
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
#End If
            '**************************************        

            '*********************************************************************************
            'RICHIAMO AGGIORNA CAMPO COMPOSTO QTA' USER
            '*********************************************************************************
            If (Not clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                If (Not clsWmsJob.objDataTableWmsJobsList.Rows Is Nothing) Then
                    If (clsWmsJob.objDataTableWmsJobsList.Rows.Count > 0) Then
                        If Not (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                            For Each WorkDataRow In clsWmsJob.objDataTableWmsJobsList.Rows
                                'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
                                RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, WorkSapWmWmsJob, False)
                                If (RetCode = 0) Then
                                    '>>> IMPOSTO LA PRIMA TASK LINES DEL NUOVO JOB SELEZIONATO
                                    clsWmsJob.objDataTableWmsJobsList.Rows(i)("ZPICK_QUEUE_USER") = clsWmsJob.ShowJobQtyToPickCompleteForUserString(Nothing, WorkSapWmWmsJob, False, True)
                                End If
                                i += 1
                            Next
                        End If
                    End If
                End If
            End If


            If (Not clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                clsWmsJob.objDataTableWmsJobsList.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID  
                Me.DtGridViewInfo.DataSource = clsWmsJob.objDataTableWmsJobsList
            End If

            'REFRESH INFO RIGA SELEZIONATA
            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridViewInfo.CurrentRow, UserSelezioneOk, True)
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            Me.Text = "Picking Appr.(2)" & "-" & Trim(Str(clsWmsJob.GetRowCountWmsJobsList(False)))

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            Me.DtGridViewInfo.Focus()
            Me.DtGridViewInfo.ReadOnly = True

            'SI POSIZIONE SULLA PRIMA RIGA DA ESEGUIRE
            RetCode = clsShowUtility.VaiAllaPrimaRigaDaEseguire(Me.DtGridViewInfo)


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

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "GRID_EXECUTED", " ", True, DefDtGridCol_GridExecuted, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZNR_WMS_JOBS", clsAppTranslation.GetSingleParameterValue(361, "", "N°Miss."), True, DefDtGridCol_NumeroMissione - 60, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "MATNR_ORI", clsAppTranslation.GetSingleParameterValue(362, "", "Cod.Mat."), True, DefDtGridCol_CodiceMateriale, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "CHARG_ORI", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale - 50, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZPICK_QUEUE_USER", clsAppTranslation.GetSingleParameterValue(1682, "", "Q. for User"), True, DefDtGridCol_QtaDaPrelevare, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTAPK_ORI", clsAppTranslation.GetSingleParameterValue(363, "", "Q.Da Pr."), True, DefDtGridCol_QtaDaPrelevare - 40, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "MEINS_ORI", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 80, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZQTA_PREL_CONS", clsAppTranslation.GetSingleParameterValue(364, "", "Q.Prel."), True, DefDtGridCol_QtaPrelevata - 40, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "UDM_QTAPR_CONS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura - 80, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "STATUS", clsAppTranslation.GetSingleParameterValue(365, "", "Stato"), True, DefDtGridCol_CarrelistaProposto - 20, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_PROP", clsAppTranslation.GetSingleParameterValue(366, "", "Ope.Prop."), False, DefDtGridCol_CarrelistaProposto - 25, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZWMS_PESO_PAL_US", clsAppTranslation.GetSingleParameterValue(1705, "", "Peso Mat."), False, DefDtGridCol_CarrelistaProposto, True)


            If (DefaultEnableShowPickingOperator = True) Then

                Select Case clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType

                    Case clsTaskLines.cstTaskLinesPickType_FullPallet
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(1597, "", "Ope.Esec.Partial"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_FL", clsAppTranslation.GetSingleParameterValue(1598, "", "Ope.Esec.Full"), True, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_SF", clsAppTranslation.GetSingleParameterValue(1599, "", "Ope.Esec.Pieces"), False, DefDtGridCol_CarrelistaProposto - 25, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_Ubicazione, True)

                    Case clsTaskLines.cstTaskLinesPickType_PartialPallet
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(1597, "", "Ope.Esec.Partial"), True, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_FL", clsAppTranslation.GetSingleParameterValue(1598, "", "Ope.Esec.Full"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_SF", clsAppTranslation.GetSingleParameterValue(1599, "", "Ope.Esec.Pieces"), False, DefDtGridCol_CarrelistaProposto - 25, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)


                    Case clsTaskLines.cstTaskLinesPickType_PickPieces
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(1597, "", "Ope.Esec.Partial"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_FL", clsAppTranslation.GetSingleParameterValue(1598, "", "Ope.Esec.Full"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_SF", clsAppTranslation.GetSingleParameterValue(1599, "", "Ope.Esec.Pieces"), True, DefDtGridCol_CarrelistaProposto - 25, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)


                    Case Else
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(1597, "", "Ope.Esec.Partial"), True, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_FL", clsAppTranslation.GetSingleParameterValue(1598, "", "Ope.Esec.Full"), True, DefDtGridCol_CarrelistaProposto - 25, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_SF", clsAppTranslation.GetSingleParameterValue(1599, "", "Ope.Esec.Pieces"), True, DefDtGridCol_CarrelistaProposto - 25, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_Ubicazione, True)

                End Select

            Else
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC", clsAppTranslation.GetSingleParameterValue(1597, "", "Ope.Esec.Partial"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_FL", clsAppTranslation.GetSingleParameterValue(1598, "", "Ope.Esec.Full"), False, DefDtGridCol_CarrelistaProposto - 25, True)
                RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZCARR_EXEC_SF", clsAppTranslation.GetSingleParameterValue(1599, "", "Ope.Esec.Pieces"), False, DefDtGridCol_CarrelistaProposto - 25, True)

                'Caso Operatore non da visualizzare
                Select Case clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType

                    Case clsTaskLines.cstTaskLinesPickType_FullPallet

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_Ubicazione, True)

                    Case clsTaskLines.cstTaskLinesPickType_PartialPallet

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)


                    Case clsTaskLines.cstTaskLinesPickType_PickPieces

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)


                    Case Else

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORI", clsAppTranslation.GetSingleParameterValue(1607, "", "Ubic.prop."), True, DefDtGridCol_Ubicazione, True)

                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGTYP_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_TipoMagazzino, True)
                        RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "LGPLA_PROP_ORIFL", clsAppTranslation.GetSingleParameterValue(1608, "", "Ubic.prop.full"), True, DefDtGridCol_Ubicazione, True)

                End Select

            End If


            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "MAKTG", clsAppTranslation.GetSingleParameterValue(368, "", "Descr.Mat."), True, DefDtGridCol_DescrMateriale - 90, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "SEQUENCE", clsAppTranslation.GetSingleParameterValue(369, "", "Seq."), True, DefDtGridCol_Sequenza - 60, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "PRIORITA", clsAppTranslation.GetSingleParameterValue(370, "", "Pri."), True, DefDtGridCol_Priorita - 100, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "URGENTE", clsAppTranslation.GetSingleParameterValue(371, "", "Urg."), True, DefDtGridCol_Urgente - 60, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZNRPICK", clsAppTranslation.GetSingleParameterValue(658, "", "N°Ord.Pic."), False, DefDtGridCol_NumOrdinePicking, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZPOSPK", clsAppTranslation.GetSingleParameterValue(659, "", "Pos.Ord.Pic."), False, DefDtGridCol_PosNumOrdinePicking, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZNR_WMS_GRPEXEC", clsAppTranslation.GetSingleParameterValue(660, "", "Ragr."), True, DefDtGridCol_NumGruppoExecMissioni - 100, True)

            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZZCDLEGACY", clsAppTranslation.GetSingleParameterValue(1647, "", "Legacy"), True, DefDtGridCol_CodiceMateriale, True)


            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZWMS_ERROR_CODE", clsAppTranslation.GetSingleParameterValue(1695, "", "Error Code"), True, DefDtGridCol_CodiceMateriale, True)
            RetCode += clsUtility.SetDataGridViewColumnStyle(Me.DtGridViewInfo, "", "ZWMS_ROW_STA_DES", clsAppTranslation.GetSingleParameterValue(1696, "", "Error Desc."), True, DefDtGridCol_DescrMateriale, True)


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
        Dim SetTaskLinesOk As Boolean = False
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

                    'SETTO I DATI DAL DATA ROW ALLA STRUTTURA
                    RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, clsWmsJob.WmsJob, False)
                    If (RetCode = 0) Then
                        '>>> IMPOSTO LA PRIMA TASK LINES DEL NUOVO JOB SELEZIONATO
                        RetCode = clsWmsJob.TaskLines.SetCurrentTaskLinesOnWork(clsWmsJob.WmsJob.NrWmsJobs, SetTaskLinesOk)

                        outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                        Me.txtInfoRowSelected.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)


                        'Evidenzio la riga della Qtà da prelevare
                        Me.txtInfoRowSelected.Select(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoRowSelected.Lines(txtInfoRowSelected.GetLineFromCharIndex(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
                        Me.txtInfoRowSelected.SelectionBackColor = Color.Yellow

                        'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
                        If (txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                            Me.txtInfoRowSelected.Select(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoRowSelected.Lines(txtInfoRowSelected.GetLineFromCharIndex(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                            Me.txtInfoRowSelected.SelectionBackColor = Color.LightCoral

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


                'Evidenzio la riga della Qtà da prelevare
                Me.txtInfoRowSelected.Select(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoRowSelected.Lines(txtInfoRowSelected.GetLineFromCharIndex(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
                Me.txtInfoRowSelected.SelectionBackColor = Color.Yellow

                'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
                If (txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                    Me.txtInfoRowSelected.Select(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoRowSelected.Lines(txtInfoRowSelected.GetLineFromCharIndex(txtInfoRowSelected.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                    Me.txtInfoRowSelected.SelectionBackColor = Color.LightCoral

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

    Private Sub DtGridViewInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridViewInfo.CurrentCellChanged

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA RIGA RINFRESCO LE INFORMAZIONI VISUALIZZATE
                RetCode = GetSelectedGridRowInfo(Me.DtGridViewInfo.CurrentRow, UserSelezioneOk, True)
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
            If (Not (Me.DtGridViewInfo.CurrentRow Is Nothing)) Then
                RetCode = GetSelectedGridRowInfo(Me.DtGridViewInfo.CurrentRow, UserSelezioneOk, False)
                If (UserSelezioneOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(657, "", "Attenzione, selezione RIGA MISSIONE non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            frmPickingMerci_Code_FunzioniForm = New frmPickingMerci_Code_Funzioni
            frmPickingMerci_Code_FunzioniForm.SourceForm = Me
            frmPickingMerci_Code_FunzioniForm.Show()
            RetCode = clsNavigation.CloseSourceForm(Me, False)

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

            'IMPOSTO IL NR MISSIONE UTENTE
            clsUser.SapWmsUser.ZNR_WMS_JOBS = ""

            'RESETTO LA STRUTTURA DI APPOGGIO
            RetCode += clsSapUtility.ResetWmsJobStruct(clsWmsJobsGroup.inSapWmWmsJob)


            '>>> GESTIONE SENZA CHIUSURA LISTA ( PRIMA VERSIONE DEL PROGRAMMA )
            WorkString = clsAppTranslation.GetSingleParameterValue(656, "", "Si desidera eseguire un'altra lista di prelievo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                'PASSO ALLA VIDEATA INIZIALE
                Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
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

    Private Sub cmdDropUDS_Click(sender As Object, e As EventArgs) Handles cmdDropUDS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1512, "", "Si desidera veramente eseguire il DROP del KTAG attivo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'ESEGUO TUTTE LE OPERAZIONI PER VERIFICARE LA VALIDITA E PREPARAZONEDELLA VIDEATA DROP
            RetCode = clsWmsJob.ChecBeforeExecScreenDropUDS(Me, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DI "DROP" DELL'UDS
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDropUDS, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdGetNewJobTask_Click(sender As Object, e As EventArgs) Handles cmdGetNewJobTask.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim FlagAllJobsQueueAreFinished As Boolean = False
        Dim outExecutionOk As Boolean = False

        Dim inFilterJobNumber As String = ""
        Dim inFilterNumConsegna As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1525, "", "Si desidera veramente elaborare nuove missioni di questa coda ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '>>> PER ESEGUIRE NUOVI TASK DEVO AVERE ESEGUITO IL DROP DI TUTTO LO STOCK A BORDO CARRELLO
            If (clsUDS.CheckIsValidUDSActive() = True) Then
                If (clsWmsJob.UDSOnWork.GetNumComponentiUDS() > 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1612, "", "Attenzione! Eseguire il DROP dell'UDS attivo:") & clsUDS.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'VERIFICO SE TUTTI I JOB ATTIVI SONO TERMINATI
            RetCode = clsWmsJob.CheckIfAllJobsQueueAreFinished(FlagAllJobsQueueAreFinished, False)
            If (FlagAllJobsQueueAreFinished = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1535, "", "Attenzione! Occorre prima terminare tutte le missioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            'RECUPERO TUTTI I DATI DELLA CODA MISSIONE
            outExecutionOk = False
            RetCode += clsWmsJob.ClearAllData()


            'VERIFICO SE I FILTRI MISSIONE SONO GIA' APPLICATI
            If clsWmsJobsGroup.inSapWmWmsJob.NrWmsJobs <> 0 Then
                inFilterJobNumber = Trim(Str(clsWmsJobsGroup.inSapWmWmsJob.NrWmsJobs))
            End If

            If clsWmsJobsGroup.inSapWmWmsJob.ConsegnaNumero <> "" Then
                inFilterNumConsegna = clsWmsJobsGroup.inSapWmWmsJob.ConsegnaNumero
            End If


            If (inFilterJobNumber <> "") Or (inFilterNumConsegna <> "") Then
                WorkString = clsAppTranslation.GetSingleParameterValue(1743, "", "Si desidera applicare il filtro per ") & " "

                If (inFilterJobNumber <> "") Then
                    WorkString += clsAppTranslation.GetSingleParameterValue(1744, "", "NrMissione : ") & " " & clsWmsJobsGroup.inSapWmWmsJob.NrWmsJobs & " "
                End If

                If (inFilterNumConsegna <> "") Then
                    WorkString += clsAppTranslation.GetSingleParameterValue(1745, "", "Numero Consegna : ") & " " & clsWmsJobsGroup.inSapWmWmsJob.ConsegnaNumero & " "
                End If

                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer = DialogResult.Yes) Then
                    RetCode = clsWmsJobsGroup.GetJobsQueueList(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, inFilterJobNumber, inFilterNumConsegna, True, outExecutionOk, False)
                Else

                    'RESETTO I PARAMETRI FILTRI
                    clsWmsJobsGroup.inSapWmWmsJob.NrWmsJobs = 0
                    clsWmsJobsGroup.inSapWmWmsJob.ConsegnaNumero = ""

                    RetCode = clsWmsJobsGroup.GetJobsQueueList(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, "", "", True, outExecutionOk, False)

                End If
            Else
                RetCode = clsWmsJobsGroup.GetJobsQueueList(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, "", "", True, outExecutionOk, False)
            End If



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

            '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
            System.Windows.Forms.Application.DoEvents()
            Me.Close()
            System.Windows.Forms.Application.DoEvents()
            frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
            frmPickingMerci_Code_2_SelMisForm.Show()
            frmPickingMerci_Code_2_SelMisForm.cmdNextScreen.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub DtGridViewInfo_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DtGridViewInfo.CellFormatting
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkGRID_EXECUTED As String = ""
        Dim WorkZWMS_ERROR_CODE As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.DtGridViewInfo.Rows Is Nothing) Then
                Exit Sub
            End If

            If (Me.DtGridViewInfo.Rows.Count <= 0) Then
                Exit Sub
            End If

            ''Gestione colorazione riga per CODA CONCLUSA
            'For i As Integer = 0 To (Me.DtGridViewInfo.Rows.Count - 1)
            '    'If Me.DtGridViewInfo.Rows(i).Cells(0).Value = "*" Then
            '    If Me.DtGridViewInfo.Rows(i).Cells("GRID_EXECUTED").Value = "*" Then
            '        Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
            '    Else
            '        'Gestione colorazione riga per CODA CONCLUSA
            '        If (Me.DtGridViewInfo.Rows(i).Cells("ZWMS_ERROR_CODE") Is DBNull.Value) Then
            '            Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.White
            '        Else
            '            'If Me.DtGridViewInfo.Rows(i).Cells(Me.DtGridViewInfo.Rows(i).Cells.Count - 2).Value <> "" Then
            '            If Me.DtGridViewInfo.Rows(i).Cells("ZWMS_ERROR_CODE").Value <> "" Then
            '                Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
            '            Else
            '                Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.White
            '            End If
            '        End If
            '    End If
            'Next

            'Gestione colorazione riga per CODA CONCLUSA
            For i As Integer = 0 To (clsWmsJob.objDataTableWmsJobsList.Rows.Count - 1)
                WorkGRID_EXECUTED = clsUtility.GetDataRowItem(clsWmsJob.objDataTableWmsJobsList.Rows(i), "GRID_EXECUTED", "", False)
                If (WorkGRID_EXECUTED = "*") Then
                    Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                Else
                    'Gestione colorazione riga per CODA CONCLUSA
                    WorkZWMS_ERROR_CODE = clsUtility.GetDataRowItem(clsWmsJob.objDataTableWmsJobsList.Rows(i), "ZWMS_ERROR_CODE", "", False)
                    If (WorkZWMS_ERROR_CODE <> "") Then
                        Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.LightCoral
                    Else
                        Me.DtGridViewInfo.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If
                End If
            Next




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


End Class