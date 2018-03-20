Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPrintLabelUdc

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPrintLabelUdc"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            If clsDataType.SelPrintLabelType = clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC Then
                Call clsNavigation.Show_Ope_PrintLabelUdC(Me, clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            Else
                Call clsNavigation.Show_Ope_PrintLabelUdC(Me, clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypeNone, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            End If


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
        Dim UnitaMagazzinoOk As Boolean = False
        Dim WorkDataRow As DataRow
        Dim WorkString As String = ""
        Dim UserAnswer As String = ""
        Dim Destination_Printer As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE I DATI ESSENZIALI SONO CORRETTI
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(373, "", "Unità Magazzino non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUM.Text = UCase(Me.txtUM.Text)

            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            clsInfoGiacenze.FilterDivisione = ""
            clsInfoGiacenze.FilterNumMag = ""
            clsInfoGiacenze.FilterUnitaMagazzino = Me.txtUM.Text

            'If (clsInfoGiacenze.InfoGiacenzeType = clsDataType.InfoGiacenzeType.InfoGiacenzeTypeForUnitaMagazzino) Then
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


            'IMPOSTANDO COME FILTRO PRINCIPALE L'UNITA DI MAGAZZINO
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultInfoGiacenze_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsInfoGiacenze.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                If (RetCode = 101) Then
                    'CASO DI DATO NON TROVATO
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(555, "", "Nessun dato trovato.Verificare i dati immessi e riprovare.")
                Else
                    'ERRORE NEL CODICE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(497, "", "Errore in estrazione dati (GET_GET_LQUA).Verificare e riprovare.")
                End If
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            'End If


            'COPIO I DATI DELLA GIACENZA DAL DATAROW ALLA STRUTURA DI LAVORO
            WorkDataRow = clsInfoGiacenze.objDataTableGiacenzeInfo.Rows(0)
            clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, WorkGiacenza, False)


            'Determino la stampante di destinazione
            If RBtnPrinter01.Checked = True Then
                Destination_Printer = WM_PRN_PLID_GOOD_RECEIPT
            Else
                Destination_Printer = WM_PRN_PLID_SHIPPING
            End If


            'IMPOSTANDO COME FILTRO PRINCIPALE L'UNITA DI MAGAZZINO
            RetCode = clsSapWS.Call_ZWMS_EXEC_PRINT_PALLET_UDC(WorkGiacenza, GetDataOk, SapFunctionError, False, Destination_Printer)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then

                'CASO DI ERRORE STAMPA
                ErrDescription = clsAppTranslation.GetSingleParameterValue(555, "", "Nessun dato trovato.Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            WorkString = clsAppTranslation.GetSingleParameterValue(780, "", "Stampa.eseguita con successo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Me.txtUM.Text = ""
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            If clsDataType.SelPrintLabelType = clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC Then
                Call clsNavigation.Show_Ope_PrintLabelUdC(Me, clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypePrintUDC, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            Else
                Call clsNavigation.Show_Ope_PrintLabelUdC(Me, clsDataType.SelezionePrintLabelType.SelezionePrintLabelTypeNone, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoGiacenze_1_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
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

    Private Sub frmInfoGiacenze_1_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUM.Text = clsAppTranslation.GetSingleParameterValue(64, lblUM.Text, "Unita Magazzino")

            Me.Text = clsAppTranslation.GetSingleParameterValue(1665, Me.Text, "Stampa Label UDC")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


            lblPrinters.Text = clsAppTranslation.GetSingleParameterValue(1780, lblPrinters.Text, "Stampanti")
            txtPrinter01.Text = clsAppTranslation.GetSingleParameterValue(1782, txtPrinter01.Text, "Good Receipt")
            txtPrinter02.Text = clsAppTranslation.GetSingleParameterValue(1781, txtPrinter02.Text, "Shipping Office")


#If Not APPLICAZIONE_WIN32 = "SI" Then

			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************   

            If (clsInfoGiacenze.FilterUnitaMagazzino <> "") Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Me.txtUM.Text = clsInfoGiacenze.FilterUnitaMagazzino
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.txtUM.Text = DefaultInfoGiacenze_UnitaMagazzino
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'GESTIONE SCELTA STAMPANTE
            RBtnPrinter01.Checked = True


            Me.txtUM.Focus()

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

End Class