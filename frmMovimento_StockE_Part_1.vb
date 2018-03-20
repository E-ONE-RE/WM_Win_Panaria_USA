Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmMovimento_StockE_Part_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMovimento_StockE_Part_1"

    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmMovimento_StockE_Part_1_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)

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
            If ((Me.RadioBtnMettiStockE.Checked = False) And (Me.RadioBtnTogliStockE.Checked = False) And (Me.RadioBtnTransferStockE.Checked = False) _
                    And (Me.RadioBtnMettiStockECustom.Checked = False) And (Me.RadioBtnTogliStockECustom.Checked = False) And (Me.RadioBtnTransferStockECustom.Checked = False)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(511, "", "Selezionare una delle possibili destinazioni.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.RadioBtnMettiStockE.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockE
            ElseIf (Me.RadioBtnTogliStockE.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE
            ElseIf (Me.RadioBtnTransferStockE.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeTransferStockE
            ElseIf (Me.RadioBtnMettiStockECustom.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockECustom
            ElseIf (Me.RadioBtnTogliStockECustom.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom
            ElseIf (Me.RadioBtnTransferStockECustom.Checked = True) Then
                clsRegModStockE.FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeTransferStockECustom
            Else
                ErrDescription = clsAppTranslation.GetSingleParameterValue(637, "", "Caso [FunctionRegModStockEType] non previsto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_Reg_Modifica_Stock_E(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMovimento_StockE_Part_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.RadioBtnMettiStockE.Checked = True) Or (Me.RadioBtnTogliStockE.Checked = True)) Then
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

    Private Sub frmMovimento_StockE_Part_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            RadioBtnMettiStockE.Text = clsAppTranslation.GetSingleParameterValue(139, RadioBtnMettiStockE.Text, "Metti In Stock E (412E)")
            RadioBtnTogliStockE.Text = clsAppTranslation.GetSingleParameterValue(140, RadioBtnTogliStockE.Text, "Togli Stock E (411 E)")
            RadioBtnTransferStockE.Text = clsAppTranslation.GetSingleParameterValue(141, RadioBtnTransferStockE.Text, "Trasf. Stock E (413E)")
            RadioBtnMettiStockECustom.Text = clsAppTranslation.GetSingleParameterValue(142, RadioBtnMettiStockECustom.Text, "Metti In Stock E (998E)")
            RadioBtnTogliStockECustom.Text = clsAppTranslation.GetSingleParameterValue(143, RadioBtnTogliStockECustom.Text, "Togli Stock E (997 E)")
            RadioBtnTransferStockECustom.Text = clsAppTranslation.GetSingleParameterValue(144, RadioBtnTransferStockECustom.Text, "Trasf. Stock E (xxxE)")

            Me.Text = clsAppTranslation.GetSingleParameterValue(137, Me.Text, "Movimento Stock E (1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

            '**************************************



            '>>> LOGICA CARICO DATI ATTIVA SOLO SE NON HO APERTO LE VIDEATE DI PRESELEZIONE DATI
            If (clsRegModStockE.FirstLoadExecuted_Step_1 = True) Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Select Case clsRegModStockE.FunctionRegModStockEType
                    Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockE
                        Me.RadioBtnMettiStockE.Checked = True
                    Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE
                        Me.RadioBtnTogliStockE.Checked = True
                End Select
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.RadioBtnMettiStockE.Checked = True

                clsRegModStockE.FirstLoadExecuted_Step_1 = True
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