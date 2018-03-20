Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports CLSUDS

Public Class frmPickingMerci_Code_3_SelUDS

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_3_SelUDS"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_3_SelUDS_KeyPress(Me, e)

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
        Dim GetDataOk As Boolean = False
        Dim CheckNewUds As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUnitaMagazzino As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim WorkNewUDS As New clsUDS
        Dim SetTaskLinesOk As Boolean = False

        Dim outE_CHECK_UDS_OK As String = ""
        Dim outE_CHECK_NEW_UDS As String = ""
        Dim outE_ERROR_DIFF_TKNUM As String = ""
        Dim outE_ERROR_DIFF_KUNNR_WE As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtCodiceUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(667, "", "Specificare un CODICE UM valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'acquisisco codice UDS
            Me.txtCodiceUM.Text = Trim(Me.txtCodiceUM.Text)
            Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)

            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtCodiceUM.Text, CheckUnitaMagazzinoOk, True)
            If (CheckUnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            'VERIFICO SE UDS IMMESSO E' GIA PRESENTE ( POSSO USARE SOLO UDS NUOVO O CORRENTE ) E SE TUTTO E' OK
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUnitaMagazzino)
            DatiRicercaUnitaMagazzino.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
            DatiRicercaUnitaMagazzino.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaUnitaMagazzino.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            RetCode = clsSapWS.Call_ZWS_CHECK_JOB_UDS(DatiRicercaUnitaMagazzino, True, clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, CheckNewUds, WorkNewUDS.UDSInfo, WorkNewUDS.UDSWeightInfo, SapFunctionError, False)
            If (CheckNewUds <> True) And (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1499, "", "UDS gia definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtCodiceUM.Text = ""
                Exit Sub
            End If

            'SE IL KTAG E'ESISTENTE ALLORA DEVE ESSERE NELL'UBICAZIONE DEL FORKLIFT ( NON SULLE BAIE )
            If (CheckNewUds = False) And (CheckUnitaMagazzinoOk = True) Then
                If (WorkNewUDS.UDSInfo.UbicazioneInfo.NumeroMagazzino <> clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1548, "", "UDS selezionata gia nel sistema e in un altro numero magazzino.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (UCase(WorkNewUDS.UDSInfo.UbicazioneInfo.TipoMagazzino) <> UCase(clsSapUtility.cstSapTipoMagWork)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1563, "", "UDS selezionata gia nel sistema e in un altro tipo magazzino.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (UCase(WorkNewUDS.UDSInfo.UbicazioneInfo.Ubicazione) <> UCase(clsForkLift.CurrentForLift.IdForkLift)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1549, "", "UDS selezionata gia nel sistema ma non nel forklift. L'UDS si trova nell'ubicazione:") & WorkNewUDS.UDSInfo.UbicazioneInfo.Ubicazione & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                'SE HO  SPECIFICATO UNA UDS CHE SI TROVA NEL FORKLIFT  DEVE  ESSERE  ANCHE  ASSOCIATA ALLO STESSO TRASPORTO
                Dim WorkUDSNumeroTrasporto As Long
                Dim WorkWmsJobNumeroTrasporto As Long
                If (clsUtility.IsStringValid(WorkNewUDS.UDSInfo.NrTrasporto, True) = True) Then
                    WorkUDSNumeroTrasporto = Val(WorkNewUDS.UDSInfo.NrTrasporto)
                Else
                    WorkUDSNumeroTrasporto = 0
                End If
                If (clsUtility.IsStringValid(clsWmsJob.WmsJob.NumeroTrasporto, True) = True) Then
                    WorkWmsJobNumeroTrasporto = Val(clsWmsJob.WmsJob.NumeroTrasporto)
                Else
                    WorkWmsJobNumeroTrasporto = 0
                End If

                If (WorkUDSNumeroTrasporto <> WorkWmsJobNumeroTrasporto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1632, "", "Attenzione! L'UDS immessa e' associata al trasporto:") & WorkNewUDS.UDSInfo.NrTrasporto & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                'SE HO  SPECIFICATO UNA UDS CHE SI TROVA NEL FORKLIFT  DEVE ESSERE ANCHE ASSOCIATA ALLO STESSA CONSEGNA
                If (UCase(WorkNewUDS.UDSInfo.Consegna) <> UCase(clsWmsJob.WmsJob.ConsegnaNumero)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1633, "", "Attenzione! L'UDS immessa e' associata alla consenga:") & WorkNewUDS.UDSInfo.Consegna & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
            End If


            '<--- Inserire qui la   Call_ZWM_CHECK_UDS_OK_FOR_JOB_PICK

            RetCode = clsSapWS.Call_ZWM_CHECK_UDS_OK_FOR_JOB_PICK(Me.txtCodiceUM.Text, True, False, clsWmsJob.WmsJob, Nothing, Nothing, Nothing, clsUser.GetUserDivisionToUse(), clsUser.GetUserNumeroMagazzinoToUse(), clsForkLift.CurrentForLift, Nothing, clsUser.SapWmsUser.LANGUAGE, outE_CHECK_UDS_OK, outE_CHECK_NEW_UDS, outE_ERROR_DIFF_TKNUM, outE_ERROR_DIFF_KUNNR_WE, False, Nothing, Nothing, SapFunctionError, False)

            If (outE_CHECK_UDS_OK = "N") And (outE_CHECK_NEW_UDS = "N") Then

                If (outE_ERROR_DIFF_TKNUM = "X") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1634, "", "K-TAG già associata a numero trasporto differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (outE_ERROR_DIFF_KUNNR_WE = "X") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1635, "", "K-TAG già associata a un destinatario merci differente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                ErrDescription = clsAppTranslation.GetSingleParameterValue(1636, "", "Errore K-TAG gia' in uso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtCodiceUM.Text = ""
                Exit Sub

            End If

            '...


            '>>> SE HO GIA UN UDS ATTIVO E NE HO LETTO UN ALTRO ALLORA DEVO PRIMA ESEGUIRE IL DROP DI QUELLO ESISTENTE
            If (clsUtility.IsStringValid(WorkNewUDS.UnitaMagazzino, True) = True) And (CheckNewUds = True) Then
                If (UCase(WorkNewUDS.UnitaMagazzino) <> UCase(Me.txtCodiceUM.Text)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1570, "", "Attenzione! Esiste gia' un UDS attivo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1571, "", "Occorre prima eseguire prima il DROP dell'UDS attivo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = WorkNewUDS.UnitaMagazzino
                    Exit Sub
                End If
            End If

            'ASSOCIO IL NUOVO UDS ALL'OGGETTO GLOBALE DELJOB
            WorkNewUDS.UnitaMagazzino = Me.txtCodiceUM.Text

            'IMPOSTO L'UDS ATTIVO NEL PRELIEVO
            clsWmsJob.UDSOnWork = WorkNewUDS



            '*********************************************************************************************************************
            'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
            '*********************************************************************************************************************
            RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_3_SelUDS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceUM.Focused = True) And (Me.txtCodiceUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
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

    Private Sub frmPickingMerci_Code_3_SelUDS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1289, Me.lblCodiceUM.Text, "Codice UDS")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1285, Me.Text, "Picking Task (3)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
            Me.lblInfoTaskLinesOnWork.Text = clsWmsJob.TaskLines.ShowTaskLinesLabelInfoForUserString()
            Me.txtInfoPesoMissione.Text = clsWmsJob.ShowJobWeightInfoForUserString(0)

            Me.cmdDropUDS.Text = clsAppTranslation.GetSingleParameterValue(1688, Me.cmdDropUDS.Text, "Drop Pallet")

#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
            Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, Me.cmdPreviousScreen.Text, "<")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, Me.cmdNextScreen.Text, ">")
            Me.cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1467, Me.cmdSelectUDSTask.Text, "...")
#Else
			Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, Me.cmdPreviousScreen.Text, "<")
			Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, Me.cmdNextScreen.Text, ">")
		    Me.cmdSelectUDSTask.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdSelectUDSTask.Text, "...")
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
#End If

            '**************************************    

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'SE HO UN UDS A BORO CARRELLO LO PROPONGO
            If (clsUtility.IsStringValid(clsWmsJob.UDSOnWork.UnitaMagazzino, True) = True) Then
                Me.txtCodiceUM.Text = clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.UDSOnWork.UnitaMagazzino)
            End If


            'Evidenzio la riga della Qtà da prelevare
            Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
            Me.txtInfoJobSelezionato.SelectionBackColor = Color.Yellow


            'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
            If (txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                Me.txtInfoJobSelezionato.SelectionBackColor = Color.LightCoral

            End If


            Me.txtCodiceUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtCodiceUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtCodiceUM.Text <> "" Then
                Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdPreviousScreen_Click(sender As Object, e As EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdDropUDS_Click(sender As Object, e As EventArgs) Handles cmdDropUDS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1512, "", "Si desidera veramente eseguire il DROP del KTAG attivo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'ESEGUO TUTTE LE OPERAZIONI PER VERIFICARE LA VALIDITA E PREPARAZONEDELLA VIDEATA DROP
            RetCode = clsWmsJob.ChecBeforeExecScreenDropUDS(Me, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DI "DROP" DELL'UDS
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDropUDS, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdJobFunctions_Click(sender As Object, e As EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            frmPickingMerci_Code_FunzioniForm = New frmPickingMerci_Code_Funzioni
            frmPickingMerci_Code_FunzioniForm.SourceForm = Me
            frmPickingMerci_Code_FunzioniForm.Show()
            RetCode = clsNavigation.CloseSourceForm(Me, False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


End Class