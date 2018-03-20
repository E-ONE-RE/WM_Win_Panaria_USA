
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmBloccoMovMM_Part_3_UM

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmBloccoMovMM_Part_3_UM"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmBloccoMovMM_Part_3_UM_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmBloccoMovMM_Part_3_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUnitaMagazzino.Focused = True) And (Me.txtUnitaMagazzino.Text <> "")) Then
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

    Private Sub frmBloccoMovMM_Part_3_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblOperazione.Text = clsAppTranslation.GetSingleParameterValue(242, lblOperazione.Text, "Operazione")
            lblUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(5, lblUnitaMagazzino.Text, "Unita Magazzino")

            Me.Text = clsAppTranslation.GetSingleParameterValue(241, Me.Text, "Metti/Togli Stock.Spec.(3)")

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
            If (clsBloccoMovMM.FirstLoadExecuted_Step_3 = True) Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Me.txtUnitaMagazzino.Text = clsBloccoMovMM.SourceUbicazione.UnitaMagazzino
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.txtUnitaMagazzino.Text = ""

                clsBloccoMovMM.FirstLoadExecuted_Step_3 = True
            End If

            Select Case clsBloccoMovMM.BloccoMovMMOperationType
                Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                    Me.txtOperazione.Text = clsAppTranslation.GetSingleParameterValue(234, Me.txtOperazione.Text, "Metti Stock Spec.")
                Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                    Me.txtOperazione.Text = clsAppTranslation.GetSingleParameterValue(235, Me.txtOperazione.Text, "Togli Stock Spec.")
                Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_None
                    Me.txtOperazione.Text = clsAppTranslation.GetSingleParameterValue(288, Me.txtOperazione.Text, "Nessuna")
                Case Else
                    Me.txtOperazione.Text = clsAppTranslation.GetSingleParameterValue(289, Me.txtOperazione.Text, "Non Valida")
            End Select

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUnitaMagazzino.Focus()

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
        Dim RetCode As Long = 0
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtUnitaMagazzino.Text = Me.txtUnitaMagazzino.Text.ToUpper

            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            If (clsUtility.IsStringValid(Me.txtUnitaMagazzino.Text, True) = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(300, Me.txtOperazione.Text, "Specifica una UNITA MAGAZZINO valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUnitaMagazzino.Text = Me.txtUnitaMagazzino.Text.ToUpper

            '*************************************************************************
            '>>> SE NON GESTISCO L'INSERIMENTO DEL CODICE MATERIALE DEVO CARICARE
            '>>> LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
            clsSapUtility.ResetUbicazioneStruct(clsBloccoMovMM.SourceUbicazione) 'init
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfMat.ClearGiacenzeInfo() 'init
            'FILTRO UM IMMESSA
            clsBloccoMovMM.SourceUbicazione.UnitaMagazzino = Me.txtUnitaMagazzino.Text

            WorkUbicazione = clsBloccoMovMM.SourceUbicazione
            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeOk, clsBloccoMovMM.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (GetDataGiacenzeOk <> True) Or (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsBloccoMovMM.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(301, "", "Nessuna giacenza trovata con l'UNITA DI MAGAZZINI immessa.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsBloccoMovMM.objDataTableGiacenzeInfo.Rows.Count = 1) Then
                'RECUPERO GIA' I DATI E PASSO ALLA VIDEATA DI CONFERMA
                RetCode = clsBloccoMovMM.GetGiacenzaFromDataRowTableGiacenze(0)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(296, "", "Errore in estrazione dati giacenza (GET_LQUA-Dataset).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore = clsBloccoMovMM.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
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