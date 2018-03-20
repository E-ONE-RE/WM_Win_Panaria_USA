
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic


Public Class frmBloccoMovMM_Part_2

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmBloccoMovMM_Part_2"

    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmBloccoMovMM_Part_2_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmBloccoMovMM_Part_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.RadioBtnUnitaMagazzino.Checked = True) Or (Me.RadioBtnUbicazione.Checked = True) Or (Me.RadioBtnMateriale.Checked = True) Or (Me.RadioBtnUbicazioneMateriale.Checked = True)) Then
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

    Private Sub frmBloccoMovMM_Part_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblInfoScelta.Text = clsAppTranslation.GetSingleParameterValue(236, lblInfoScelta.Text, "Modalità di Ricerca:")
            RadioBtnUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(237, RadioBtnUnitaMagazzino.Text, "Unità Magaz. - Pallet")
            RadioBtnUbicazione.Text = clsAppTranslation.GetSingleParameterValue(4, RadioBtnUbicazione.Text, "Ubicazione")
            RadioBtnMateriale.Text = clsAppTranslation.GetSingleParameterValue(238, RadioBtnMateriale.Text, "Materiale && Partita")
            RadioBtnUbicazioneMateriale.Text = clsAppTranslation.GetSingleParameterValue(239, RadioBtnUbicazioneMateriale.Text, "Ubi. + Mat. && Partita")

            Me.Text = clsAppTranslation.GetSingleParameterValue(240, Me.Text, "Metti/Togli Stock.Spec.(2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************


            '>>> LOGICA CARICO DATI ATTIVA SOLO SE NON HO APERTO LE VIDEATE DI PRESELEZIONE DATI
            If (clsBloccoMovMM.FirstLoadExecuted_Step_2 = True) Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Select Case clsBloccoMovMM.BloccoMovMMFindType
                    Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
                        Me.RadioBtnUnitaMagazzino.Checked = True
                    Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
                        Me.RadioBtnUbicazione.Checked = True
                    Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
                        Me.RadioBtnMateriale.Checked = True
                    Case clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
                        Me.RadioBtnUbicazioneMateriale.Checked = True
                    Case Else
                        '>>> SE NON AVEVO DECISO NULLA MOSTRO OPZIONE DI DEFAULT
                        Me.RadioBtnUnitaMagazzino.Checked = True
                End Select
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.RadioBtnUnitaMagazzino.Checked = True

                clsBloccoMovMM.FirstLoadExecuted_Step_2 = True
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
            If ((Me.RadioBtnMateriale.Checked = False) And (Me.RadioBtnUbicazione.Checked = False) And (Me.RadioBtnUbicazioneMateriale.Checked = False) And (Me.RadioBtnUnitaMagazzino.Checked = False)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(287, "", "Selezionare una delle possibili madalità di ricerca.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.RadioBtnUnitaMagazzino.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMFindType = clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UnitaMagazzino
            ElseIf (Me.RadioBtnUbicazione.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMFindType = clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Ubicazione
            ElseIf (Me.RadioBtnMateriale.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMFindType = clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_Materiale
            ElseIf (Me.RadioBtnUbicazioneMateriale.Checked = True) Then
                clsBloccoMovMM.BloccoMovMMFindType = clsBloccoMovMM.Blocco_Mov_MM_Find_Type.BloccoMovMMFindType_UbicazioneMateriale
            Else
                ErrDescription = clsAppTranslation.GetSingleParameterValue(286, "", "Caso [BloccoMovMMOperationType] non previsto.")
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
    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.BloccoMovMMType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class