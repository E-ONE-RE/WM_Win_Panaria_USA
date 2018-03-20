
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsSapUtility

Public Class frmEM_FromJob_Part_ChiudiLista

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJob_Part_ChiudiLista"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


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

    Private Sub frmEM_FromJob_Part_ChiudiLista_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************



            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJob_Part_ChiudiLista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(1213, Me.Text, "Identifica.(Chiudi)")
            Me.cmdVerificaStock.Text = clsAppTranslation.GetSingleParameterValue(1214, Me.cmdVerificaStock.Text, "Stamp.Etichette")
            Me.cmdCloseJobsGroup.Text = clsAppTranslation.GetSingleParameterValue(252, Me.cmdCloseJobsGroup.Text, "Chiudi")
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsWmsJob.GetUdcProcessedInfoForUser()


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPutAwayInfoForUserString(3)

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGUO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdVerificaStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerificaStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim outJobsGroupOkxClose As Boolean = False
        Dim outJobsGroupMaterialOk As Boolean = False
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            WorkString = clsAppTranslation.GetSingleParameterValue(1215, "", "Si desidera stampare le etichette ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                'Modifica stampa UDC 
                '***

                RetCode = clsNavigation.Show_Ope_PrintLabelUdC(Me, clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
                If (RetCode <> 0) Then
                    ErrDescription = "Errore nell'apertura della form. Verificare e riprovare."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If


                '***

                Exit Sub
            End If

            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE MISSIONI SONO IN STATO "TERMINATO" PER POTERE CHIUDERE IL GRUPPO
            outJobsGroupOkxClose = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkxClose(outJobsGroupOkxClose, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(709, "", "Errore in CHECK GRUPPO OK x CHIUSURA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupOkxClose = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(710, "", "Attenzione! Gruppo non OK per la CHIUSURA.") & clsAppTranslation.GetSingleParameterValue(711, "", " Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            'SE ARRIVO QUI LA GIACENZA E' CORRETTA
            '            ErrDescription = clsAppTranslation.GetSingleParameterValue(715, "", "Giacenza del GRUPPO MISSIONE VALIDA!")
            '           MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdCloseJobsGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCloseJobsGroup.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String
        Dim JobsGroupClosedOk As Boolean = False
        Dim UMStorageLocations As Collection
        Dim outJobsGroupOkxClose As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsWmsJobsGroup.WmsJobsGroupInfo.JobsGroupClosed = True) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(729, "", "Gruppo gia' CHIUSO. Si desidera abbandonare la procedura ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
                '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE IL CODICE DEL GRUPPO MISSIONI DA ESEGUIRE 
                Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
                Exit Sub
            Else
                'CASO NORNALE => CHIEDO ALL'OPERATORE SE DESIDERA CHIUDERE LA LISTA
                WorkString = clsAppTranslation.GetSingleParameterValue(730, "", "Si desidera veramente chiudere il GRUPPO MISSIONI ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
                    UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If
                    'IN QUESTO CASO L'OPERATORE ESCE DALLA MISSIONE SENZA CHIUDERE IL GRUPPO MISSIONI
                    '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                    Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
                    Exit Sub
                End If
            End If

            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE MISSIONI SONO IN STATO "TERMINATO" PER POTERE CHIUDERE IL GRUPPO
            outJobsGroupOkxClose = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkxClose(outJobsGroupOkxClose, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(709, "", "Errore in CHECK GRUPPO OK x CHIUSURA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupOkxClose = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(710, "", "Attenzione! Gruppo non OK per la CHIUSURA.") & clsAppTranslation.GetSingleParameterValue(711, "", " Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '**********************************************************************
            'ESEGUO LA CHIUSURA DEL JOB GROUPS
            JobsGroupClosedOk = False
            RetCode = clsWmsJobsGroup.SetJobsGroupClosed(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, JobsGroupClosedOk, False)
            If (RetCode <> 0) Or (JobsGroupClosedOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(735, "", "Attenzione! Errore in CHIUSURA gruppo missioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromJob.EM_SourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class