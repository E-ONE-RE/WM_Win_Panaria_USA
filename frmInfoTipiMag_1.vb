Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoTipiMag_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoTipiMag_1"


    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private DivisioneUbiOrigine As String
    Private FlagFormLoaded As Boolean


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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

            RetCode = clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)

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
        Dim GetOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtNumMag.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(562, "", "Numero Magazzino non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtTipiMag.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(563, "", "Tipo Magazzino non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(564, "", "Inserire '*' per vedere la lista completa.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Me.txtNumMag.Text = UCase(Me.txtNumMag.Text)
            Me.txtTipiMag.Text = UCase(Me.txtTipiMag.Text)

            clsInfoTipiMagazzino.FilterNumMag = Me.txtNumMag.Text
            clsInfoTipiMagazzino.FilterTipiMag = Me.txtTipiMag.Text

            'CHIAMO WS PER VERIFICARE I DATI DEL DOCUMENTO MATERIALE IMMESSO
            RetCode = clsSapWS.Call_ZWS_MB_GET_LGTYP_LIST(Me.txtNumMag.Text, Me.txtTipiMag.Text, clsUser.SapWmsUser.LANGUAGE, GetOk, clsInfoTipiMagazzino.objDataTableTipiMagazzinoInfo, SapFunctionError, False)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(554, "", "Nessun dato trovato.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Tipi_Magazzino(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoTipiMag_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (FlagFormLoaded <> True) Then Exit Sub

            If ((Me.txtNumMag.Focused = True) And (Me.txtNumMag.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    If (Me.txtTipiMag.Text = "") Then
                        Me.txtTipiMag.Focus()
                        Exit Sub
                    Else
                        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                            e.Handled = True
                        End If
                        Call Me.cmdNextScreen_Click(Me, e)
                        Exit Sub
                    End If
                End If
            End If

            If ((Me.txtTipiMag.Focused = True) And (Me.txtTipiMag.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                        e.Handled = True
                    End If
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

    Private Sub frmInfoTipiMag_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblNumMag.Text = clsAppTranslation.GetSingleParameterValue(263, lblNumMag.Text, "Numero Magazzino")
            lblTipiMag.Text = clsAppTranslation.GetSingleParameterValue(80, lblTipiMag.Text, "Tipo Magazzino")

            Me.Text = clsAppTranslation.GetSingleParameterValue(261, Me.Text, "Info Tipi Mag.(1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************   


            '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
            RetCode += clsUtility.FillComboFromStringArray(Me.txtNumMag, NumMagAvailable, clsUser.GetUserNumeroMagazzinoToUse())
            If (clsUtility.IsStringValid(clsUser.GetUserNumeroMagazzinoToUse(), True) = True) Then
                Me.txtNumMag.Text = clsUser.GetUserNumeroMagazzinoToUse()
            Else
                Me.txtNumMag.Text = DefaultInfoTipiMag_NumMag
            End If
            Me.txtTipiMag.Text = DefaultInfoTipiMag_TipoMag

            'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
            If (clsUtility.IsStringValid(clsInfoTipiMagazzino.FilterNumMag, True) = True) Then
                Me.txtNumMag.Text = clsInfoTipiMagazzino.FilterNumMag
            End If
            If (clsUtility.IsStringValid(clsInfoTipiMagazzino.FilterTipiMag, True) = True) Then
                Me.txtTipiMag.Text = clsInfoTipiMagazzino.FilterTipiMag
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            FlagFormLoaded = True 'SETTO FLAG DI FINESTRA CARICATA

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtTipiMag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipiMag.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtTipiMag.Text = "") Then Exit Sub

            Me.txtTipiMag.Text = UCase(Me.txtTipiMag.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtNumMag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumMag.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtNumMag.Text = "") Then Exit Sub

            Me.txtNumMag.Text = UCase(Me.txtNumMag.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class