Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoGiacenze_2

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoGiacenze_2"


    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    cmdSelectCodiceMateriale_Click(Me, e)
            End Select

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
        Dim GetDataOk As Boolean = False
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************



            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
            Me.txtUM.Text = UCase(Me.txtUM.Text)
            Me.txtPartita.Text = UCase(Me.txtPartita.Text)
            Me.txtSKU.Text = UCase(Me.txtSKU.Text)

            clsInfoGiacenze.FilterCodiceMateriale = Me.txtCodiceMateriale.Text
            clsInfoGiacenze.FilterUnitaMagazzino = Me.txtUM.Text
            clsInfoGiacenze.FilterPartitaMateriale = Me.txtPartita.Text
            clsInfoGiacenze.FilterSKU = Me.txtSKU.Text

            If (clsInfoGiacenze.FilterDivisione = "") Then
                clsInfoGiacenze.FilterDivisione = "*"
            End If
            If (clsInfoGiacenze.FilterNumMag = "") Then
                clsInfoGiacenze.FilterNumMag = "*"
            End If

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = clsInfoGiacenze.FilterDivisione
            WorkUbicazione.NumeroMagazzino = clsInfoGiacenze.FilterNumMag
            WorkUbicazione.TipoMagazzino = clsInfoGiacenze.FilterTipiMag
            WorkUbicazione.Ubicazione = clsInfoGiacenze.FilterUbicazione
            WorkUbicazione.UnitaMagazzino = clsInfoGiacenze.FilterUnitaMagazzino
            WorkGiacenza.CodiceMateriale = clsInfoGiacenze.FilterCodiceMateriale

            WorkGiacenza.Partita = clsInfoGiacenze.FilterPartitaMateriale

            WorkGiacenza.SKU = clsInfoGiacenze.FilterSKU

            'CHIAMO WS PER OTTENERE I DATI DELLE GIACENZE CON I FILTRI IMPOSTATO
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultInfoGiacenze_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsInfoGiacenze.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False, True)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                If (RetCode = 101) Then
                    'CASO DI DATO NON TROVATO
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(554, "", "Nessun dato trovato.Verificare e riprovare.")
                Else
                    'ERRORE NEL CODICE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(497, "", "Errore in estrazione dati (GET_GET_LQUA).Verificare e riprovare.")
                End If
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoGiacenze_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtPartita.Focused = True) And (Me.txtPartita.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If (Me.cmdNextScreen.Focused = True) Then
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

    Private Sub frmInfoGiacenze_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")
            lblUM.Text = clsAppTranslation.GetSingleParameterValue(64, lblUM.Text, "Unita Magazzino")
            lblPartita.Text = clsAppTranslation.GetSingleParameterValue(1, lblPartita.Text, "Partita")

            Me.Text = clsAppTranslation.GetSingleParameterValue(120, Me.Text, "Info Giacenze(2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
		    cmdSelectCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectCodiceMateriale.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectCodiceMateriale.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************  


            If (clsSelezioneCodiceMateriale.SelectionOnRun = False) Then

                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                If clsInfoGiacenze.FilterCodiceMateriale <> "" Then
                    Me.txtCodiceMateriale.Text = clsInfoGiacenze.FilterCodiceMateriale
                Else
                    Me.txtCodiceMateriale.Text = ""
                End If

                If clsInfoGiacenze.FilterUnitaMagazzino <> "" Then
                    Me.txtUM.Text = clsInfoGiacenze.FilterUnitaMagazzino
                Else
                    Me.txtUM.Text = ""
                End If

                If clsInfoGiacenze.FilterPartitaMateriale <> "" Then
                    Me.txtPartita.Text = clsInfoGiacenze.FilterPartitaMateriale
                Else
                    Me.txtPartita.Text = ""
                End If

            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtCodiceMateriale.Focus()

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
            Call clsNavigation.Show_Info_Giacenze(Me, clsInfoGiacenze.InfoGiacenzeType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectCodiceMateriale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectCodiceMateriale.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (InStr(1, Me.txtCodiceMateriale.Text, "*") > 0) Then
                If (Len(Me.txtCodiceMateriale.Text) < 6) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(529, "", "Per velocizzare la ricerca inserire almeno 6 caratteri.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            clsSelezioneCodiceMateriale.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneCodiceMateriale.FilterDivisione = clsInfoGiacenze.FilterDivisione
            clsSelezioneCodiceMateriale.FilterNumMag = clsInfoGiacenze.FilterNumMag
            clsSelezioneCodiceMateriale.FilterTipiMag = clsInfoGiacenze.FilterTipiMag
            clsSelezioneCodiceMateriale.FilterUbicazione = clsInfoGiacenze.FilterUbicazione
            clsSelezioneCodiceMateriale.FilterCodiceMateriale = Me.txtCodiceMateriale.Text

            RetCode = clsSelezioneCodiceMateriale.SelezionaElemento(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Function ConfermaSelezioneCodiceMateriale() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneCodiceMateriale = 1 'init at error

            Me.Focus()
            If (clsSelezioneCodiceMateriale.CodiceMaterialeSelezionato <> "") Then
                Me.txtCodiceMateriale.Text = clsSelezioneCodiceMateriale.CodiceMaterialeSelezionato
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneCodiceMateriale = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub txtCodiceMateriale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceMateriale.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtCodiceMateriale.Text = "") Then Exit Sub

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM.Text = "") Then Exit Sub

            Me.txtUM.Text = UCase(Me.txtUM.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtPartita_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartita.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtPartita.Text = "") Then Exit Sub

            Me.txtPartita.Text = UCase(Me.txtPartita.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class