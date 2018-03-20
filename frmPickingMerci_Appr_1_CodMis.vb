Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Appr_1_CodMis

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_1_CodMis"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_1_CodMis_KeyPress(Me, e)

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
        Dim UserAnswer As DialogResult
        Dim JobsGroupOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            ' >>> VERIFICO SE LA MISSIONE SPECIFICATA E' CORRETTA
            '***********************************************************************************************
            If (Me.txtNrWmsJobs.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(347, "", "Gruppo Missione non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtNrWmsJobs.Text = UCase(Me.txtNrWmsJobs.Text)
            Me.txtNrWmsJobs.Text = Trim(Me.txtNrWmsJobs.Text)

            'VERIFICO IL FORMATO DEI DATI IMMESSI PER EVITARE ERRORI A VALLE
            RetCode = clsShowUtility.CheckJobsGroupEnteredString(Me.txtNrWmsJobs.Text, JobsGroupOk, True)
            If (JobsGroupOk = False) Then
                Exit Sub
            End If

            'RECUPERO TUTTI I DATI DEL JOBGROUP
            RetCode += clsWmsJob.ClearAllData()
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(Me.txtNrWmsJobs.Text, Nothing, Nothing, JobsGroupOk, False)
            'VERIFICO SE IL GRUPPO E' STATO CANCELLATO (FLAG IMPOSTATO DAL CRUSCOTTO PER ORDINE ANNULLATO)
            If (clsWmsJobsGroup.WmsJobsGroupInfo.FoundGroupDeleted = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(649, "", "Attenzione! Il Gruppo Missioni e' stato CANCELLATO/ANNULLATO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(650, "", "Contattare SUBITO l'ufficio spedizioni per verificare la lista.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '>>> IN QUESTO CASO NON SI PUO' FORZARE L'ESECUZIONE IN QUANTO TUTTI I JOB SONO CANCELLATI
                Exit Sub
            End If
            If (RetCode <> 0) Or (JobsGroupOk = False) Then
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

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND hrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_1_CodMis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtNrWmsJobs.Focused = True) And (Me.txtNrWmsJobs.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
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
    Private Sub frmPickingMerci_Appr_1_CodMis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NOORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            lblNrWmsJobs.Text = clsAppTranslation.GetSingleParameterValue(153, lblNrWmsJobs.Text, "Gruppo Missioni")

            Me.Text = clsAppTranslation.GetSingleParameterValue(152, Me.Text, "Picking Appr. (1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************        


            Me.txtNrWmsJobs.Text = clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup

            Me.txtNrWmsJobs.Focus()

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
End Class