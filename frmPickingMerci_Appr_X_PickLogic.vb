Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports clsWmsJob
Imports System.Windows.Forms

Public Class frmPickingMerci_Appr_X_PickLogic

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_X_PickLogic"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_6_ConfQta_KeyPress(Me, e)

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


    Private Sub frmPickingMerci_Appr_6_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtInfoPrelievo.Focused = True) And (Me.txtInfoPrelievo.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Call cmdNextScreen_Click(Me, e)
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

    Private Sub frmPickingMerci_Appr_6_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkQtàPrevista As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            ckboxFlagForcedStepEnded.Text = clsAppTranslation.GetSingleParameterValue(65, ckboxFlagForcedStepEnded.Text, "Fine")
            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(67, lblQtaPrevista.Text, "Qta Prev.")
            txtUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, txtUDMQuantita.Text, "UdM")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(169, lblQtaConfermata.Text, "Qtà Conf.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(168, Me.Text, "Picking Appr. (6)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************


            Me.Text = clsAppTranslation.GetSingleParameterValue(736, "", "Picking Logico x Pronto")

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            'VISUALIZZO UBICAZIONE ORIGINE
            RetCode = clsWmsJob.GetJobPickOriQtyProposal(WorkQtàPrevista, Nothing)
            If (RetCode = 0) Then
                Me.txtQtaPrevista.Text = WorkQtàPrevista
            End If
            Me.txtUDMQuantita.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            Me.txtQtaConfermata.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore
            Me.txtInfoPrelievo.Text = clsWmsJob.WmsJob.InfoPrelievo

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtQtaConfermata.Focus()

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

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim QtaRimastaDaPrelevare As Double
        Dim UserAnswer As DialogResult
        Dim CheckExecutionOk As Boolean = False
        Dim FlagErroreAttivo As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim wkJobsOkForExecution As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim wkExitFormDone As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Me.txtQtaConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Val(Me.txtQtaConfermata.Text) > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.") & vbCrLf & "Qtà Dispo:" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If (Me.txtInfoPrelievo.Text = "") Or (Me.txtInfoPrelievo.Text = ".") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(754, "", "Attenzione! Non sono state inserite le informazioni di prelievo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(755, "", "Si desidera veramente continuare ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Me.txtInfoPrelievo.Focus()
                    Exit Sub
                End If
            End If

            Me.txtInfoPrelievo.Text = UCase(Me.txtInfoPrelievo.Text)

            'RECUPERO LE INFO SUL POSTO OTTIMALE DI PRELIEVO DELLA MERCE
            QtaRimastaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDaPrelUdMAcq - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
            If (Val(Me.txtQtaConfermata.Text) > QtaRimastaDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*********************************************************************************
            '>>> SE ARRIVO QUI LA QTA INSERITA E' OK PER PROSEGUIRE
            '*********************************************************************************

            'IMPOSTO QTA CONFERMATA
            RetCode = clsWmsJob.SetJobPickQtyMaterialGiacenzaOri(Val(Me.txtQtaConfermata.Text), Me.ckboxFlagForcedStepEnded.Checked)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(386, "", "Errore in impostazione Qtà Confermata.") & vbCrLf & "[SetJobPickQtyMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO LE NOTE DI PRELIEVO
            clsWmsJob.WmsJob.InfoPrelievo = Me.txtInfoPrelievo.Text

            '>>> ESEGUO AZIONE PREVISTA DALLA MISSIONE
            RetCode = clsWmsJob.ExecJobStepExecuted(CheckExecutionOk, ErrDescription, RetInfoSapWmWmsJob)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                FlagErroreAttivo = True
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmPickingMerci_Appr_X_PickLogicForm = New frmPickingMerci_Appr_X_PickLogic
                    frmPickingMerci_Appr_X_PickLogicForm.Show()
                    frmPickingMerci_Appr_X_PickLogicForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA OPERAZIONE DELLA STESSA RIGA MISSIONE
            '*************************************************************************************************
            wkExitFormDone = False
            If (FlagErroreAttivo = False) And (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) And (RetInfoSapWmWmsJob.CurrentStep = clsWmsJob.WmsJob.CurrentStep) Then
                RetCode = clsWmsJob.ReloadDataOfSameJobForNewPick(Me, wkExitFormDone, True)
                If (wkExitFormDone = True) Then
                    Exit Sub
                End If
            End If


            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)
                Exit Sub
            End If

            'ESCO DALLA BEM => TORNO AL MENU DI ENTRATA MERCI
            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class