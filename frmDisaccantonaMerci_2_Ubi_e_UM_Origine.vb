Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmDisaccantonaMerci_2_Ubi_e_UM_Origine
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmDisaccantonaMerci_2_Ubi_e_UM_Origine"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmDisaccantonaMerci_2_Ubi_e_UM_Origine_KeyPress(Me, e)

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

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, Nothing, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmDisaccantonaMerci_2_Ubi_e_UM_Origine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneOrigine.Focused = True) And (Me.txtUbicazioneOrigine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If
            If ((Me.txtCodiceUMOrigine.Focused = True) And (Me.txtCodiceUMOrigine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)
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

    Private Sub frmDisaccantonaMerci_2_Ubi_e_UM_Origine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(165, lblUbicazioneOrigine.Text, "Ubicazione Prelievo")
            lblCodiceUMOrigine.Text = clsAppTranslation.GetSingleParameterValue(247, lblCodiceUMOrigine.Text, "UM Prelievo")

            Me.Text = clsAppTranslation.GetSingleParameterValue(248, Me.Text, "Disaccant.(2)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '************************************** 


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.InfoPrelievo, True) = True) Then
                Me.txtInfoJobSelezionato.Text += "INFO PREL:" & clsWmsJob.WmsJob.InfoPrelievo
            End If

            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                Me.txtUbicazioneOrigine.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                Me.txtCodiceUMOrigine.Text = WorkSapWmGiacenza.UbicazioneInfo.UnitaMagazzino
            End If

            If (DefaultDisacMerci_Enable_SelOriUbicazione = True) Then
                Me.txtUbicazioneOrigine.Enabled = True
            Else
                Me.txtUbicazioneOrigine.Enabled = False
            End If
            If (DefaultDisacMerci_Enable_SelUM_Origine = True) Then
                Me.txtCodiceUMOrigine.Enabled = True
            Else
                Me.txtCodiceUMOrigine.Enabled = False
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            If (WorkSapWmGiacenza.UbicazioneInfo.AbilitaUnitaMagazzino = True) And (DefaultDisacMerci_Enable_SelUM_Origine = True) Then
                Me.txtCodiceUMOrigine.Focus()
            Else
                Me.cmdNextScreen.Focus()
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
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim WorkOkCaricoGiacenza As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneOrigine.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(372, "", "Ubicazione di Prelievo non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (DefaultDisacMerci_Enable_SelUM_Origine = True) Then
                If (Me.txtCodiceUMOrigine.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(373, "", "Unità Magazzino non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            WorkUbicazione.Ubicazione = Me.txtUbicazioneOrigine.Text
            If (DefaultDisacMerci_Enable_SelUM_Origine = True) Then
                WorkUbicazione.UnitaMagazzino = Me.txtCodiceUMOrigine.Text
            Else
                WorkUbicazione.UnitaMagazzino = ""
            End If
            WorkUbicazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = ""

            WorkDatiRicercaStock.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkDatiRicercaStock.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkDatiRicercaStock.TipoStock = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock
            WorkDatiRicercaStock.CdStockSpeciale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CdStockSpeciale
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale
            WorkDatiRicercaStock.UnitaDiMisuraBase = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta

            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkDatiRicercaStock, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (GetDataOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(374, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(375, "", "Nessuna Giacenza in STOCK con i FILTRI immessi.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) = 1) Then
                '>>> SE HO SOLO UNA GIACENZA LA CARICO E PASSO DIRETTAMENTE ALLA CONFERMA DELLA QTA
                RetCode = clsWmsJob.GetElementDataTableGiacenzeOri(0, WorkOkCaricoGiacenza)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(376, "", "Errore in estrazione dati giacenza.") & vbCrLf & "[GetElementDataTableGiacenzeOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'VERIFICO E ELABORO EVENTUALE ACCORPAMENTO MISSIONI
                RetCode = clsWmsJob.GetJobPickGroupExecInformation(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(378, "", "Errore in elab. accorpamento.") & vbCrLf & "[GetJobPickGroupExecInformation]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, Nothing, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class