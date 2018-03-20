Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoMappaUbicazioni_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoMappaUbicazioni_1"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    If cmdSelectTipoMagazzino.Focused Then
                        cmdSelectTipoMagazzino_Click(Me, e)
                    ElseIf cmdSelectUbicazione.Focused Then
                        cmdSelectUbicazione_Click(Me, e)
                    Else
                        cmdSelectTipoMagazzino_Click(Me, e)
                    End If
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
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim StatoUbicazione As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LE INFORMAZIONI IMMESSE SONO CORRETTE
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

            '>>> METTO BLOCCO PERCHE' CAUSEREBBE UN TEMPO DI CARICAMENTO MOLTO LUNGO PERCHE' TORNEREBBERO TUTTE LE UBICAZIONI
            If (Me.txtTipiMag.Text = "*") And (Me.txtUbicazione.Text = "*") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(565, "", " Specificare il Tipo Magazzino o l'Ubicazione per ridurre i tempi") & clsAppTranslation.GetSingleParameterValue(566, "", " della visualizzazione dei dati.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtNumMag.Text = UCase(Me.txtNumMag.Text)
            Me.txtTipiMag.Text = UCase(Me.txtTipiMag.Text)
            Me.txtUbicazione.Text = UCase(Me.txtUbicazione.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazione.Text = WorkOutUbicazione


            clsInfoMappaUbicazioni.FilterNumMag = Me.txtNumMag.Text
            clsInfoMappaUbicazioni.FilterTipiMag = Me.txtTipiMag.Text
            clsInfoMappaUbicazioni.FilterUbicazione = Me.txtUbicazione.Text

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init

            WorkUbicazione.NumeroMagazzino = clsInfoMappaUbicazioni.FilterNumMag
            WorkUbicazione.TipoMagazzino = clsInfoMappaUbicazioni.FilterTipiMag
            WorkUbicazione.Ubicazione = clsInfoMappaUbicazioni.FilterUbicazione


            'FILTRO UBICAZIONI
            If rdbAll.Checked Then
                StatoUbicazione = "A"
            ElseIf rdbEmpty.Checked Then
                StatoUbicazione = "E"
            ElseIf rdbFull.Checked Then
                StatoUbicazione = "F"
            End If


            'IN QUESTO CASO DEVO CHIAMARE SUBITO IL WEB SERVICE
            'IMPOSTANDO COME FILTRO PRINCIPALE LA SOLA UBICAZIONE
            RetCode = clsSapWS.Call_ZWS_MB_GET_UBICAZIONI_INFO(WorkUbicazione, StatoUbicazione, True, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsInfoMappaUbicazioni.objDataTableMappaUbicazioniInfo, Val(DefaultEM_List_MaxNumRowReturned), SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(567, "", "Attenzione! L'ubicazione specificata non e' definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Info_Mappa_Ubicazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoMappaUbicazioni_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtNumMag.Focused = True) And (Me.txtNumMag.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazione.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtTipiMag.Focused = True) And (Me.txtTipiMag.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    If (Me.txtUbicazione.Text <> "") Then
                        Call Me.cmdNextScreen_Click(Me, e)
                    Else
                        Me.txtUbicazione.Focus()
                    End If
                    Exit Sub
                End If
            End If

            If ((Me.txtUbicazione.Focused = True) And (Me.txtUbicazione.Text <> "")) Then
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

    Private Sub frmInfoGiacenze_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblNumMag.Text = clsAppTranslation.GetSingleParameterValue(119, lblNumMag.Text, "Num.Mag.")
            lblTipiMag.Text = clsAppTranslation.GetSingleParameterValue(206, lblTipiMag.Text, "Tip.Mag.")
            lblUbicazione.Text = clsAppTranslation.GetSingleParameterValue(4, lblUbicazione.Text, "Ubicazione")


            Me.rdbAll.Text = clsAppTranslation.GetSingleParameterValue(1724, Me.rdbAll.Text, "Tutte")
            Me.rdbEmpty.Text = clsAppTranslation.GetSingleParameterValue(1725, Me.rdbEmpty.Text, "Vuote")
            Me.rdbFull.Text = clsAppTranslation.GetSingleParameterValue(1726, Me.rdbFull.Text, "Piene")


            Me.Text = clsAppTranslation.GetSingleParameterValue(255, Me.Text, "Info Map.Ubicaz.(1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectTipoMagazzino.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectTipoMagazzino.Text, "...")
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectTipoMagazzino.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectTipoMagazzino.Text, "...")
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************  



            '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
            RetCode += clsUtility.FillComboFromStringArray(Me.txtNumMag, NumMagAvailable, clsUser.GetUserNumeroMagazzinoToUse())

            '>>> LOGICA CARICO DATI ATTIVA SOLO SE NON HO APERTO LE VIDEATE DI PRESELEZIONE DATI
            If (clsSelezioneUbicazione.SelectionOnRun = False) And (clsSelezioneTipoMagazzino.SelectionTipoMagazzinoOnRun = False) Then
                If (clsInfoMappaUbicazioni.FirstLoadExecuted_Step_1 = True) Then
                    'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                    'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                    Me.txtNumMag.Text = clsInfoMappaUbicazioni.FilterNumMag
                    Me.txtTipiMag.Text = clsInfoMappaUbicazioni.FilterTipiMag
                    Me.txtUbicazione.Text = clsInfoMappaUbicazioni.FilterUbicazione
                Else
                    If (clsUtility.IsStringValid(clsUser.GetUserNumeroMagazzinoToUse(), True) = True) Then
                        Me.txtNumMag.Text = clsUser.GetUserNumeroMagazzinoToUse()
                    Else
                        Me.txtNumMag.Text = DefaultInfoMappaUbicazioni_NumMag
                    End If
                    Me.txtTipiMag.Text = DefaultInfoMappaUbicazioni_TipoMag
                    Me.txtUbicazione.Text = DefaultInfoMappaUbicazioni_Ubicazione
                    clsInfoMappaUbicazioni.FirstLoadExecuted_Step_1 = True
                End If
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'SETTO Filtro ALL di Default
            rdbAll.Checked = True

            Me.txtTipiMag.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Function ConfermaSelezioneLocazione() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneLocazione = 1 'init at error

            Me.Focus()
            If (clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione <> "") Then
                Me.txtNumMag.Text = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                Me.txtTipiMag.Text = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
                Me.txtUbicazione.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneLocazione = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Function ConfermaSelezioneTipoMagazzino() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneTipoMagazzino = 1 'init at error

            Me.Focus()
            If (clsSelezioneTipoMagazzino.TipoMagazzinoSelezionato.TipoMagazzino <> "") Then
                Me.txtNumMag.Text = clsSelezioneTipoMagazzino.TipoMagazzinoSelezionato.NumeroMagazzino
                Me.txtTipiMag.Text = clsSelezioneTipoMagazzino.TipoMagazzinoSelezionato.TipoMagazzino
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneTipoMagazzino = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdSelectUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazione.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me, Me.txtUbicazione.Text, "", Me.txtNumMag.Text, Me.txtTipiMag.Text, False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtUbicazione_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazione.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtUbicazione.Text <> "" Then
                Me.txtUbicazione.Text = UCase(Me.txtUbicazione.Text)
            End If

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

            If Me.txtTipiMag.Text <> "" Then
                Me.txtTipiMag.Text = UCase(Me.txtTipiMag.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtNumMag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtNumMag.Text <> "" Then
                Me.txtNumMag.Text = UCase(Me.txtNumMag.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectTipoMagazzino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectTipoMagazzino.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneTipoMagazzino.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneTipoMagazzino.FilterNumMag = Me.txtNumMag.Text
            clsSelezioneTipoMagazzino.FilterTipiMag = DefaultSelectTipoMag_TipoMag

            RetCode = clsSelezioneTipoMagazzino.SelezionaElemento(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class