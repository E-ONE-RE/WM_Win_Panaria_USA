
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmPickingMerci_Code_Funzioni

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_Funzioni"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_Funzioni_KeyPress(Me, e)

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
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO ALL'ELENCO DELLE MISSIONI
                frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                frmPickingMerci_Code_2_SelMisForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_2_SelMis.GetType.Name) Then
                frmPickingMerci_Code_2_SelMisForm = New frmPickingMerci_Code_2_SelMis
                frmPickingMerci_Code_2_SelMisForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_3_SelUDS.GetType.Name) Then
                frmPickingMerci_Code_3_SelUDSForm = New frmPickingMerci_Code_3_SelUDS
                frmPickingMerci_Code_3_SelUDSForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name) Then
                frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name) Then
                frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_7_ConfQta.GetType.Name) Then
                frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                frmPickingMerci_Code_7_ConfQtaForm.Show()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_DropUDS.GetType.Name) Then
                frmPickingMerci_Code_DropUDSForm = New frmPickingMerci_Code_DropUDS
                frmPickingMerci_Code_DropUDSForm.Show()
            End If
            RetCode = clsNavigation.CloseSourceForm(Me, False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_Funzioni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmPickingMerci_Code_Funzioni_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.cmdPickListInfo.Text = clsAppTranslation.GetSingleParameterValue(271, Me.cmdPickListInfo.Text, "Info Prelievo Gruppo Miss.")
            Me.cmdSetZeroPick.Text = clsAppTranslation.GetSingleParameterValue(1572, Me.cmdSetZeroPick.Text, "Forza Termina Con Qta Zero")
            Me.cmdForcedNextStep.Text = clsAppTranslation.GetSingleParameterValue(272, Me.cmdForcedNextStep.Text, "Forza Fine Step")
            Me.cmdForcedEndJob.Text = clsAppTranslation.GetSingleParameterValue(273, Me.cmdForcedEndJob.Text, "Forza Termina Missione")
            Me.cmdSetDropPick.Text = clsAppTranslation.GetSingleParameterValue(1686, Me.cmdSetDropPick.Text, "Forza Annulla Prenotazione Missione")
            Me.Text = clsAppTranslation.GetSingleParameterValue(154, Me.Text, "Picking Appr. (2)")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, Me.cmdNextScreen.Text, "OK")
            '**************************************  


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

            Me.Text = clsAppTranslation.GetSingleParameterValue(1567, "", "Picking - Funzioni")

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)


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
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

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

            If (clsWmsJob.WmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Iniziato) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1611, "", "Attenzione! La missione deve essere INIZIATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> PER ESEGUIRE LO ZERO PICK DEVO AVERE ESEGUITO IL DROP DI TUTTO  LOSTOCK  A BORDO CARRELLO
            If (clsWmsJob.UDSOnWork.CheckIsValidUDSActive() = True) Then
                If (clsWmsJob.UDSOnWork.GetNumComponentiUDS() > 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1612, "", "Attenzione! Eseguire il DROP dell'UDS attivo:") & clsUDS.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
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

            ''RECUPERO TUTTI I DATI DEL JOBGROUP
            'RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
            'If (RetCode <> 0) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(706, "", "Attenzione! Dati JOBGROUP non trovati nel sistema.")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'ESEGUO IL RECUPERO DEI DATI DEL JOB CORRENTE
            RetCode += clsWmsJob.GetJobSingle(clsWmsJob.WmsJob.NrWmsJobs, Nothing, Nothing, Nothing, Nothing, False, False, True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1613, "", "Attenzione, errore in estrazione dati del JOBS.")
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
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

            'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
            ErrDescription = clsAppTranslation.GetSingleParameterValue(749, "", "Forzatura TERMINA MISSIONE eseguita con SUCCESSO.")
            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            'RIPARTO DALLA LISTA DELLE MISSIONI ( SE RIMASTO UN JOB )
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
            Exit Sub

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
            RetCode = clsWmsJobsGroup.GetJobsGroupSummary(clsWmsJob.WmsJob.CodiceGruppoMissioni, GetExecutionOk, False)
            If ((RetCode <> 0) Or (GetExecutionOk = False)) Then
                '>>> CASO DI ERRORE IN ESECUZIONE
                WorkString = clsAppTranslation.GetSingleParameterValue(655, "", "Errore in lettura dati esecuzione LISTA PRELIEVO.")
                MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            frmInfoListaPickingForm = New frmInfoListaPicking
            frmInfoListaPickingForm.SourceForm = Me
            frmInfoListaPickingForm.Show()
            RetCode = clsNavigation.CloseSourceForm(Me, False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSetZeroPick_Click(sender As Object, e As EventArgs) Handles cmdSetZeroPick.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckExecutionOk As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim UserAnswer As DialogResult

        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim WorkFilterSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim WorkUbicazioneInfo As clsDataType.SapWmUbicazione
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************
            ' >>> VERIFICO SE LO STATO DEI JOB E' COMPATIBILE CON L'OPERAZIONE
            '***********************************************************************************
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

            ''>>> PER ESEGUIRE LO ZERO PICK DEVO AVERE ESEGUITO IL DROP DI TUTTO LO STOCK A BORDO CARRELLO
            'If (clsUDS.CheckIsValidUDSActive() = True) Then
            '    If (clsWmsJob.UDSOnWork.GetNumComponentiUDS() > 0) Then
            '        ErrDescription = clsAppTranslation.GetSingleParameterValue(1612, "", "Attenzione! Eseguire il DROP dell'UDS attivo:") & clsUDS.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    End If
            'End If

            ErrDescription = clsAppTranslation.GetSingleParameterValue(1710, "", "Si conferma lo ZERO PICK per la missione attiva ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'RECUPERO LE INFO DELL'UBICAZIONE DA PRELEVARE PROPOSTA  DALLA STRATEGIA
            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmGiacenza)

            'GESTIONE ZERO PICK DALLA PRIMA VIDEATA DOVE UBICAZIONE NON E' SETTATA 
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazioneInfo)

            If clsUtility.IsStringValid(WorkSapWmGiacenza.OdaInputDestInfo.UbicazioneInfo.Ubicazione, True) = True Then
                WorkUbicazioneInfo = WorkSapWmGiacenza.OdaInputDestInfo.UbicazioneInfo
            Else
                WorkUbicazioneInfo = clsWmsJob.WmsJob.UbicazionePropostaOrigine
            End If


            '*************************************************************************************************************************************
            '>>> ESEGUO FORZATURA FINE MISSIONE
            '*************************************************************************************************************************************
            RetCode = clsSapWS.Call_ZWS_SET_JOB_STATUS_FORCED_END(clsWmsJob.WmsJob.NrWmsJobs, True, WorkUbicazioneInfo, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, SapFunctionError, True)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(748, "", "Errore in FORZA TERMINA MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'MEMORIZZO DATI DEL JOB ATTIVO
            MemoNrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

            'ESEGUO IL RECUPERO DEI DATI DELLA CODA ( LI RINFRESCO TUTTI )
            RetCode += clsWmsJob.GetJobCodaPerRefresh(WorkFilterSapWmWmsJob, True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1613, "", "Attenzione, errore in estrazione dati del JOBS.")
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
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

            'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
            ErrDescription = clsAppTranslation.GetSingleParameterValue(1711, "", "Esecuzione ZERO PICK eseguita con SUCCESSO.")
            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            'RIPARTO DALLA LISTA DELLE MISSIONI ( SE RIMASTO UN JOB )
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)
            Exit Sub


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

        Dim FlagTaskLinesOnWorkIsFinish As Boolean = False
        Dim FlagTaskLinesOnWorkIsStarted As Boolean = False
        Dim FlagAllJobsQueueAreFinished As Boolean = False
        Dim WorkDataRow As DataRow
        Dim WorkJobTaskLinesAreNotFinished As Boolean = False
        Dim WorkNrWmsJobs As String = ""
        Dim WorkFoundSomeTaskLines As Boolean = False
        Dim WorkDataTableTaskLinesYetToExecute As DataTable
        Dim WorkSapWmWmsJob As clsDataType.SapWmWmsJob
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                Exit Sub
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows Is Nothing) Then
                Exit Sub
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows.Count <= 0) Then
                Exit Sub
            End If


            '**************************************************************
            'VERIFICO SE LO STATO DEL JOB E' COMPATIBILE CON L'OPERAZIONE
            '**************************************************************


            '********************************************************************************************************************************
            '>>> PER ESEGUIRE L'ANNULLAMENTO DELLA PRENOTAZIONE DEL PICK DEVO AVERE ESEGUITO IL DROP DI TUTTO LO STOCK  A BORDO CARRELLO
            '********************************************************************************************************************************
            If (clsUDS.CheckIsValidUDSActive() = True) Then
                If (clsWmsJob.UDSOnWork.GetNumComponentiUDS() > 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1612, "", "Attenzione! Eseguire il DROP dell'UDS attivo:") & clsUDS.UnitaMagazzino & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'If (clsWmsJob.IsJobsYetEnded(False) = True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(741, "", "Attenzione! La missione è TERMINATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
            'If (clsWmsJob.IsJobsSuspended(False) = True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(742, "", "Attenzione! La missione è SOSPESA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
            'If (clsWmsJob.IsJobsCancelled(False) = True) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(743, "", "Attenzione! La missione è CANCELLATA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            '**************************************************************************************************
            'FACCIO UN CONTROLLO SE IL TASK CORRENTE E' TERMINATO ( DEVE ESSERE TERMINATO )
            '**************************************************************************************************
            RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesOnWorkIsFinish(FlagTaskLinesOnWorkIsFinish, False)
            If (FlagTaskLinesOnWorkIsFinish = False) Then
                RetCode = clsWmsJob.TaskLines.CheckIfTaskLinesOnWorkIsStarted(FlagTaskLinesOnWorkIsStarted, False)
                If (FlagTaskLinesOnWorkIsStarted = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1655, "", "Attenzione! Per eseguire il DROP PICK occorre prima terminare il TASK in corso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            '**************************************************************************************************
            'FACCIO UN CONTROLLO DEVO AVERE ALMENO UN JOB DA ESEGUIRE DI CUI ANNULLLARE L'ASSEGNAZIONE
            '**************************************************************************************************
            RetCode = clsWmsJob.CheckIfAllJobsQueueAreFinished(FlagAllJobsQueueAreFinished, False)
            If (FlagAllJobsQueueAreFinished = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1656, "", "Attenzione! Tutte le missioni sono terminate. Nessuno DROP PICK possibile.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            ErrDescription = clsAppTranslation.GetSingleParameterValue(1747, "", "Si conferma l'annullamento della prenotazione per le missioni attive ?") & clsAppTranslation.GetSingleParameterValue(322, "", "SI/NO")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            ExecutionOk = True

            '*************************************************************************************************************************************
            '>>> ESEGUO CANCELLAZIONE DELLA PRENOTAZIONE DELLA SINGOLA TASK LINES ANCORA DA ESEGUIRE ( UNA CHIAMATA PER SINGOLO JOB )
            '*************************************************************************************************************************************
            For Each WorkDataRow In clsWmsJob.objDataTableWmsJobsList.Rows

                WorkJobTaskLinesAreNotFinished = False

                'VERIFICO SE I TASK DEL JOB SONO TERMINATI O MENO
                RetCode = clsWmsJob.CheckIfJobTaskLinesAreNotFinished(WorkDataRow, WorkJobTaskLinesAreNotFinished)
                If (WorkJobTaskLinesAreNotFinished = False) Then
                    'IN QUESTO CASO I TASK DEL JOB SONO TERMINATI E NON OCCORRE FARE NESSUNA CANCELLAZIONE
                    Continue For
                End If

                'RECUPERO IL NUMERO DELLLA MISSIONE
                WorkNrWmsJobs = clsUtility.GetDataRowItem(WorkDataRow, "ZNR_WMS_JOBS", "0")

                WorkFoundSomeTaskLines = False
                WorkDataTableTaskLinesYetToExecute = Nothing
                clsTaskLines.GetAllTaskLinesYetToExecute(WorkNrWmsJobs, WorkFoundSomeTaskLines, WorkDataTableTaskLinesYetToExecute)
                If (WorkFoundSomeTaskLines = False) Then
                    Continue For
                End If
                If (WorkDataTableTaskLinesYetToExecute Is Nothing) Then
                    ExecutionOk = False 'SETTO FLAG DI ERRORE
                    Continue For
                End If
                If (WorkDataTableTaskLinesYetToExecute.Rows Is Nothing) Then
                    ExecutionOk = False 'SETTO FLAG DI ERRORE
                    Continue For
                End If
                If (WorkDataTableTaskLinesYetToExecute.Rows.Count <= 0) Then
                    ExecutionOk = False 'SETTO FLAG DI ERRORE
                    Continue For
                End If

                'COPIO IL DATAROW NELLA STRUTTURA DELLA MISSIONE
                RetCode = clsSapUtility.ResetWmsJobStruct(WorkSapWmWmsJob)
                RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(WorkDataRow, WorkSapWmWmsJob, False)
                If (RetCode <> 0) Or (WorkSapWmWmsJob.NrWmsJobs <= 0) Then
                    ExecutionOk = False 'SETTO FLAG DI ERRORE
                    Continue For
                End If

                RetCode = clsSapWS.Call_ZWMS_DELETE_JOBS_TASKLINES(WorkSapWmWmsJob.NrWmsJobs, WorkDataTableTaskLinesYetToExecute, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, Nothing, Nothing, SapFunctionError, False)
                If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(748, "", "Errore in DROP PICK MISSIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ExecutionOk = False 'SETTO FLAG DI ERRORE
                End If

            Next


            '*****************************************************************************************************************************
            ' >>> VERIFICO ESISTO OPERAZIONE ESEGUITA
            '*****************************************************************************************************************************
            If (ExecutionOk = True) Then
                'SEGNALO OPERAZIONE ESEGUITA CORRETTAMENTE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1683, "", "DROP PICK Task Lines Missioni eseguito con SUCCESSO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                'SEGNALO ERRORE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1684, "", "Errore in esecuzione del DROP PICK.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            'SE OPERAZIONE OK => RIPARTO DALLA PRIMA VIDEATA DEL PICKING PER ENTRARE IN UN'ALTRA CODA
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)


            Exit Sub


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub cmdExecJobGetBestOriLocation_Click(sender As Object, e As EventArgs) Handles cmdExecJobGetBestOriLocation.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1621, "", "Si desidera veramente ricalcolare lo stock migliore per il PICKING ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '*********************************************************************************************************************
            'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
            '*********************************************************************************************************************
            RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
            RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.StockSelezionatoUtente)

            'RIESEGUO TUTTA LA PROCEDURA PER  RICARICARE I DATI E FARE IL REFRESH DELLA VIDEATA
            Call frmPickingMerci_Code_Funzioni_Load(sender, e)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class