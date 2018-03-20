Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmBloccoMovMM_Part_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmBloccoMovMM_Part_1"

    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmBloccoMovMM_Part_1_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_BloccoMerci(Me, True)

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

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If ((Me.RadioBtnBlocco.Checked = False) And (Me.RadioBtnSblocco.Checked = False)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(283, "", "Attenzione! Selezionare una delle possibili operazioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.RadioBtnBlocco.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMOperationType = clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                If (clsBloccoMovMM.BloccoMovMMType = clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockR) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(285, "", "Attenzione! Per lo STOCK R questo caso non è previsto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            ElseIf (Me.RadioBtnSblocco.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMOperationType = clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
            Else
                ErrDescription = clsAppTranslation.GetSingleParameterValue(286, "", "Caso [BloccoMovMMOperationType] non previsto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.BloccoMovMMType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmBloccoMovMM_Part_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.RadioBtnBlocco.Checked = True) Or (Me.RadioBtnSblocco.Checked = True)) Then
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

    Private Sub frmBloccoMovMM_Part_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblInfoScelta.Text = clsAppTranslation.GetSingleParameterValue(233, lblInfoScelta.Text, "Scelta Operazione:")
            RadioBtnBlocco.Text = clsAppTranslation.GetSingleParameterValue(234, RadioBtnBlocco.Text, "Metti Stock Spec.")
            RadioBtnSblocco.Text = clsAppTranslation.GetSingleParameterValue(235, RadioBtnSblocco.Text, "Togli Stock Spec.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(232, Me.Text, "Metti/Togli Stock.Spec.(1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************


            '>>> LOGICA CARICO DATI ATTIVA SOLO SE NON HO APERTO LE VIDEATE DI PRESELEZIONE DATI
            If (clsBloccoMovMM.FirstLoadExecuted_Step_1 = True) Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Select Case clsBloccoMovMM.BloccoMovMMOperationType
                    Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                        Me.RadioBtnBlocco.Checked = True
                    Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                        Me.RadioBtnSblocco.Checked = True
                End Select
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.RadioBtnBlocco.Checked = True

                clsBloccoMovMM.FirstLoadExecuted_Step_1 = True
            End If

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
End Class