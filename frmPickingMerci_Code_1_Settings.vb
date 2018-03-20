Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Code_1_Settings

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_1_Settings"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_1_Settings_KeyPress(Me, e)

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
        Dim outExecutionOk As Boolean = False
        Dim outNrJobOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            ' >>> VERIFICO SE LA MISSIONE SPECIFICATA E' CORRETTA
            '***********************************************************************************************
            If (Me.txtCurrentTipoMagazzino.Enabled = True) Then
                If (Me.txtCurrentTipoMagazzino.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(563, "", "Tipo Magazzino non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            Me.txtCurrentTipoMagazzino.Text = UCase(Me.txtCurrentTipoMagazzino.Text)
            Me.txtCurrentTipoMagazzino.Text = Trim(Me.txtCurrentTipoMagazzino.Text)
            Me.txtNumConsegna.Text = Trim(Me.txtNumConsegna.Text)
            Me.txtJobNumber.Text = Trim(Me.txtJobNumber.Text)
            If (Me.txtCurrentForkLift.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(417, "", "Carrello / Muletto non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtCurrentWorkQueue.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1418, "", "Coda Task non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            clsShowUtility.CheckJobsEnteredString(Me.txtJobNumber.Text, outNrJobOk, False)
            If (outNrJobOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1807, "", "Il NUMERO MISSIONE digitato non è corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(921, "", "La lunghezza è superiore a 10 caratteri.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'RECUPERO TUTTI I DATI DELLA CODA MISSIONE
            outExecutionOk = False
            RetCode += clsWmsJob.ClearAllData()
            RetCode = clsWmsJobsGroup.GetJobsQueueList(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, Me.txtJobNumber.Text, Me.txtNumConsegna.Text, True, outExecutionOk, False)
            'VERIFICO SE IL GRUPPO E' STATO CANCELLATO (FLAG IMPOSTATO DAL CRUSCOTTO PER ORDINE ANNULLATO)
            If (clsWmsJobsGroup.WmsJobsGroupInfo.FoundGroupDeleted = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(649, "", "Attenzione! Il Gruppo Missioni e' stato CANCELLATO/ANNULLATO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(650, "", "Contattare SUBITO l'ufficio spedizioni per verificare la lista.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '>>> IN QUESTO CASO NON SI PUO' FORZARE L'ESECUZIONE IN QUANTO TUTTI I JOB SONO CANCELLATI
                Exit Sub
            End If


            'Verifico se a bordo del Forklift è già presente un KTAG di una missione differente
            If (clsForkLift.CurrentForLift.UdsOnForkDiffUser = "X") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1833, "", "UDS a bordo muletto creato da user differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1813, "", "Effettuare il Drop dell'UDS.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Verifico se a bordo del Forklift è già presente un KTAG di una missione differente
            If (clsForkLift.CurrentForLift.DropUdsFromForklift = "X") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1812, "", "Missione non compatibile con UDS a bordo muletto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1813, "", "Effettuare il Drop dell'UDS.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsForkLift.CurrentForLift.NumUdsOnForklift > 1) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1810, "", "Attenzione! Presente piu' di un KTAG sul muletto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1811, "", "Eseguire il DROP e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (RetCode <> 0) Or (outExecutionOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1498, "", "Attenzione! Missioni non trovate nella CODA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(350, "", "Verificare il dato immesso e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If




            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND hrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_1_Settings_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCurrentTipoMagazzino.Focused = True) And (Me.txtCurrentTipoMagazzino.Text <> "")) Then
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
    Private Sub frmPickingMerci_Code_1_Settings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.lblCurrentTipoMagazzino.Text = clsAppTranslation.GetSingleParameterValue(80, lblCurrentTipoMagazzino.Text, "Tipo Magazzino")
            Me.lblCurrentForkLift.Text = clsAppTranslation.GetSingleParameterValue(1277, lblCurrentForkLift.Text, "Carrello / Muletto")
            Me.lblCurrentWorkQueue.Text = clsAppTranslation.GetSingleParameterValue(1278, lblCurrentWorkQueue.Text, "Coda Task")
            Me.lblJobNumber.Text = clsAppTranslation.GetSingleParameterValue(1242, Me.lblJobNumber.Text, "Missione")
            Me.lblNumConsegna.Text = clsAppTranslation.GetSingleParameterValue(1620, Me.lblNumConsegna.Text, "Numero Consegna")

            Me.grpTaskFullPartialModeExecution.Text = clsAppTranslation.GetSingleParameterValue(1279, grpTaskFullPartialModeExecution.Text, "Modalita Esecuzione Prelievo Interi / Sfusi")

            Me.rdbTaskFullPartialMode_FullOnly.Text = clsAppTranslation.GetSingleParameterValue(1280, rdbTaskFullPartialMode_FullOnly.Text, "Solo Interi")
            Me.rdbTaskFullPartialMode_PartialOnly.Text = clsAppTranslation.GetSingleParameterValue(1281, rdbTaskFullPartialMode_PartialOnly.Text, "Solo Sfusi")
            Me.rdbTaskFullPartialMode_All.Text = clsAppTranslation.GetSingleParameterValue(1282, rdbTaskFullPartialMode_All.Text, "Tutti")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1283, Me.Text, "Picking Task (1)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")



#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************        


            Me.txtCurrentTipoMagazzino.Text = clsUser.UsersProfLgtyp.LGTYP 'clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup

            Me.txtCurrentForkLift.Text = clsUser.SapWmsUser.ZID_WMS_FORKLIFT

            Me.txtCurrentWorkQueue.Text = clsUser.SapWmsUser.ZPICK_QUEUE_DESC

            Me.txtJobNumber.Text = clsUser.SapWmsUser.ZNR_WMS_JOBS


            'Valore Default Check
            Me.rdbTaskFullPartialMode_All.Checked = True


            Me.txtCurrentTipoMagazzino.Focus()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnSelectTipiMag_Click(sender As Object, e As EventArgs) Handles btnSelectTipiMag.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectTipiMag.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_SelectUserTipiMag(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub btnSelectForkLift_Click(sender As Object, e As EventArgs) Handles btnSelectForkLift.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'CONTROLLO PRIVILEGI UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectForkLift.Tag) = False) Then Exit Sub

            RetCode = clsNavigation.Show_Select_ForkLift(Me, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub btnSelectUserPickQueue_Click(sender As Object, e As EventArgs) Handles btnSelectUserPickQueue.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ErrDescription As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'SELEZIONA CODA UTENTE
            If (clsUserGrants.CheckOperUserGrant(Me.btnSelectUserPickQueue.Tag) = False) Then Exit Sub

            'SETTO FILTRO CHE MI VISUALIZZA SOLO LE CODE CON MISSIONI E FILTRO CHE VEDO SOLO LE CODE CON MISSIONI DA ESEGUIRE
            RetCode = clsNavigation.Show_Select_UserPickQueue(Me, True, True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub btnSelectUserTaskList_Click(sender As Object, e As EventArgs) Handles btnSelectUserTaskList.Click


        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult
        Dim outExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            ' >>> VERIFICO SE LA MISSIONE SPECIFICATA E' CORRETTA
            '***********************************************************************************************
            If (Me.txtCurrentTipoMagazzino.Enabled = True) Then
                If (Me.txtCurrentTipoMagazzino.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(563, "", "Tipo Magazzino non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            Me.txtCurrentTipoMagazzino.Text = UCase(Me.txtCurrentTipoMagazzino.Text)
            Me.txtCurrentTipoMagazzino.Text = Trim(Me.txtCurrentTipoMagazzino.Text)
            Me.txtNumConsegna.Text = Trim(Me.txtNumConsegna.Text)
            Me.txtJobNumber.Text = Trim(Me.txtJobNumber.Text)
            If (Me.txtCurrentForkLift.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(417, "", "Carrello / Muletto non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'If (Me.txtCurrentWorkQueue.Text = "") Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(1418, "", "Coda Task non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If


            'RECUPERO TUTTI I DATI DELLA CODA MISSIONE
            outExecutionOk = False
            RetCode += clsWmsJob.ClearAllData()
            RetCode = clsWmsJobsGroup.GetTaskLinesAssigned(clsUser.SapWmsUser.ZID_PICK_QUEUE, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, Me.txtJobNumber.Text, Me.txtNumConsegna.Text, True, outExecutionOk, False)
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


            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            'Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            'SETTO FILTRO CHE MI VISUALIZZA SOLO LE CODE CON MISSIONI E FILTRO CHE VEDO SOLO LE CODE CON MISSIONI DA ESEGUIRE
            RetCode = clsNavigation.Show_Select_UserTaskLinesAssigned(Me, True, True, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND hrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

        End Try

    End Sub

End Class