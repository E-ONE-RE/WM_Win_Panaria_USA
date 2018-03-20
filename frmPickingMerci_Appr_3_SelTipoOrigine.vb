Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Appr_3_SelTipoOrigine

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_3_SelTipoOrigine"


    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_3_SelTipoOrigine_KeyPress(Me, e)

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
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If ((Me.RadioBtnTypeUMEnter.Checked = False) And (Me.RadioBtnTypeUbicazioneEnter.Checked = False) And (Me.RadioBtnTypeCodMatEnter.Checked = False) And (Me.RadioBtnTypeUbieUMEnter.Checked = False)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(511, "", "Selezionare una delle possibili destinazioni.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.RadioBtnTypeUMEnter.Checked = True) Then
                clsWmsJob.PickingMerciSourceType = clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
            ElseIf (Me.RadioBtnTypeCodMatEnter.Checked = True) Then
                clsWmsJob.PickingMerciSourceType = clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
            ElseIf (Me.RadioBtnTypeUbicazioneEnter.Checked = True) Then
                clsWmsJob.PickingMerciSourceType = clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
            ElseIf (Me.RadioBtnTypeUbieUMEnter.Checked = True) Then
                clsWmsJob.PickingMerciSourceType = clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
            Else
                ErrDescription = clsAppTranslation.GetSingleParameterValue(661, "", "Caso [PickingMerciSourceType] non previsto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

    Private Sub frmPickingMerci_Appr_3_SelTipoOrigine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.RadioBtnTypeUMEnter.Checked = True) Or (Me.RadioBtnTypeUbicazioneEnter.Checked = True) Or (Me.RadioBtnTypeCodMatEnter.Checked = True) Or (Me.RadioBtnTypeUbieUMEnter.Checked = True)) Then
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

    Private Sub frmPickingMerci_Appr_3_SelTipoOrigine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblInfoScelta.Text = clsAppTranslation.GetSingleParameterValue(160, lblInfoScelta.Text, "Scelta Tipologia Prelievo")
            RadioBtnTypeUMEnter.Text = clsAppTranslation.GetSingleParameterValue(156, RadioBtnTypeUMEnter.Text, "Prelievo x UM")
            RadioBtnTypeUbicazioneEnter.Text = clsAppTranslation.GetSingleParameterValue(157, RadioBtnTypeUbicazioneEnter.Text, "Prelievo x Cod.Ubicaz.")
            RadioBtnTypeUbieUMEnter.Text = clsAppTranslation.GetSingleParameterValue(158, RadioBtnTypeUbieUMEnter.Text, "Prelievo x UM && Cod.Ubicaz.")
            RadioBtnTypeCodMatEnter.Text = clsAppTranslation.GetSingleParameterValue(159, RadioBtnTypeCodMatEnter.Text, "Prelievo x Cod.Mat.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(155, Me.Text, "Picking Appr. (3)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
		    cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************


            '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
            Select Case clsWmsJob.PickingMerciSourceType
                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeCodMatEnter
                    Me.RadioBtnTypeCodMatEnter.Checked = True
                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbicazioneEnter
                    Me.RadioBtnTypeUbicazioneEnter.Checked = True
                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUbieUMEnter
                    Me.RadioBtnTypeUbieUMEnter.Checked = True
                Case clsWmsJob.PickingMerci_SourceType.PickingMerci_SourceTypeUMEnter
                    Me.RadioBtnTypeUMEnter.Checked = True
            End Select

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.cmdNextScreen.Focus()

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

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class