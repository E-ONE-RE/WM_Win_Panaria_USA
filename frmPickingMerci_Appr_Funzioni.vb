
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmPickingMerci_Appr_Funzioni

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_Funzioni"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_Funzioni_KeyPress(Me, e)

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

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Appr_2_SelMis.GetType.Name) Then
                frmPickingMerci_Appr_2_SelMisForm = New frmPickingMerci_Appr_2_SelMis
                frmPickingMerci_Appr_2_SelMisForm.Show()
                RetCode = clsNavigation.CloseSourceForm(Me, False)
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_2_SelMis.GetType.Name) Then
                frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                frmPickingMerci_Code_2_SelMisForm.Show()
                RetCode = clsNavigation.CloseSourceForm(Me, False)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_Funzioni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdForcedNextStep.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdForcedEndJob_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdForcedEndJob.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdForcedEndJob_Click(Me, e)
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

    Private Sub frmPickingMerci_Appr_Funzioni_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            cmdPickListInfo.Text = clsAppTranslation.GetSingleParameterValue(271, cmdPickListInfo.Text, "Info Prelievo Gruppo Miss.")
            cmdForcedNextStep.Text = clsAppTranslation.GetSingleParameterValue(272, cmdForcedNextStep.Text, "Forza Fine Step")
            cmdForcedEndJob.Text = clsAppTranslation.GetSingleParameterValue(273, cmdForcedEndJob.Text, "Forza Termina Missione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(154, Me.Text, "Picking Appr. (2)")

            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '**************************************  


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            Me.Text = clsAppTranslation.GetSingleParameterValue(736, "", "Picking Appr. - Funzioni")

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
    Private Sub cmdForcedNextStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForcedNextStep.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckExecutionOk As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim UserAnswer As DialogResult
        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'ESEGUO LE VERIFICHE PER ESCLUDERE ERRORI OPERATORE
            If (clsWmsJob.WmsJob.NumeroStepTotali <= 1) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(737, "", "Attenzione! Funzione disponibile solo per MISSIONI con più di UNO step.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Not (IsNumeric(clsWmsJob.WmsJob.CurrentStep))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(738, "", "Attenzione! Informazione dello STEP CORRENTE non valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Val(clsWmsJob.WmsJob.CurrentStep) >= clsWmsJob.WmsJob.NumeroStepTotali) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(739, "", "Attenzione! Funzione non disponibile all'ultimo STEP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(739, "", "Usare il TERMINA missione.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '**************************************************************
            'VERIFICO SE LO STATO DEL JOB E' COMPATIBILE CON L'OPERAZIONE
            If (clsWmsJob.IsJobsYetEnded(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(741, "", "Attenzione! La missione è TERMINATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.IsJobsSuspended(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(742, "", "Attenzione! La missione è SOSPESA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.IsJobsCancelled(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(743, "", "Attenzione! La missione è CANCELLATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            ErrDescription = clsAppTranslation.GetSingleParameterValue(744, "", "Si conferma la FORZATURA del FINE STEP MISSIONE per la missione attiva ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '>>> ESEGUO FORZATURA FINE STEP
            RetCode = clsSapWS.Call_ZWS_SET_JOB_STEP_FORCED_NEXT(clsWmsJob.WmsJob.NrWmsJobs, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, SapFunctionError, True)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(745, "", "Errore in FORZA FINE STEP MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            'RECUPERO TUTTI I DATI DEL JOBGROUP
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(706, "", "Attenzione! Dati JOBGROUP non trovati nel sistema.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO REFRESH DEI DATI DEL JOB
            RetCode = clsWmsJob.RefreshJobsSingleStruct(MemoNrWmsJobs, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO REFRESH INFO VIDEATA
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
            ErrDescription = clsAppTranslation.GetSingleParameterValue(746, "", "Forzatura FINE STEP eseguita con SUCCESSO.")
            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdForcedEndJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForcedEndJob.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckExecutionOk As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim UserAnswer As DialogResult
        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '**************************************************************
            'VERIFICO SE LO STATO DEL JOB E' COMPATIBILE CON L'OPERAZIONE
            If (clsWmsJob.IsJobsYetEnded(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(741, "", "Attenzione! La missione è TERMINATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.IsJobsSuspended(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(742, "", "Attenzione! La missione è SOSPESA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.IsJobsCancelled(False) = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(743, "", "Attenzione! La missione è CANCELLATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            ErrDescription = clsAppTranslation.GetSingleParameterValue(747, "", "Si conferma la FORZATURA del FINE MISSIONE per la missione attiva?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '>>> ESEGUO FORZATURA FINE STEP
            RetCode = clsSapWS.Call_ZWS_SET_JOB_STATUS_FORCED_END(clsWmsJob.WmsJob.NrWmsJobs, False, Nothing, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, SapFunctionError, True)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(748, "", "Errore in FORZA TERMINA MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            'RECUPERO TUTTI I DATI DEL JOBGROUP
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(706, "", "Attenzione! Dati JOBGROUP non trovati nel sistema.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO REFRESH DEI DATI DEL JOB
            RetCode = clsWmsJob.RefreshJobsSingleStruct(MemoNrWmsJobs, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(398, "", "Attenzione! Errore in lettura dati JOB")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO REFRESH INFO VIDEATA
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
            ErrDescription = clsAppTranslation.GetSingleParameterValue(749, "", "Forzatura TERMINA MISSIONE eseguita con SUCCESSO.")
            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdPickListInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPickListInfo.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetExecutionOk As Boolean = False
        Dim WorkString As String = ""
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

            frmInfoListaPickingForm = New frmInfoListaPicking
            frmInfoListaPickingForm.SourceForm = Me
            frmInfoListaPickingForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class