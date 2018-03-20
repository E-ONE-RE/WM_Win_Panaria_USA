Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmPickingMerci_Appr_4_Sel_UbiOrigine

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_4_Sel_UbiOrigine"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_4_Sel_UbiOrigine_KeyPress(Me, e)

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
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim WorkOkCaricoGiacenza As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(553, "", "Ubicazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazione.Text = UCase(Me.txtUbicazione.Text)
            Me.txtUbicazione.Text = Trim(Me.txtUbicazione.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazione.Text = WorkOutUbicazione


            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazione.Text
            DatiRicercaUbicazione.TipoMagazzino = ""
            DatiRicercaUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            DatiRicercaUbicazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Or (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(662, "", "Ubicazione Origine non definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '************************************************************************************************
            'SE E' SELEZIONATA PER ERRORE UNA UBICAZIONE DEL PRONTO DEVO BLOCCARE L'OPERATORE
            If (DefaultPickingMerci_Ori_Exclude_LgtypPronto = True) Then
                If (InfoUbicazione.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(663, "", "L'Ubicazione Origine scelta è nel TIPO MAGAZZINO PRONTO (") & clsSapUtility.cstSapTipoMagPronto & ")." & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            WorkUbicazione = InfoUbicazione

            WorkDatiRicercaStock.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkDatiRicercaStock.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkDatiRicercaStock.TipoStock = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.TipoStock
            WorkDatiRicercaStock.CdStockSpeciale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CdStockSpeciale
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmOriginale
            WorkDatiRicercaStock.UnitaDiMisuraBase = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UdmQtaJobRichiesta

            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkDatiRicercaStock, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(664, "", "Nessuna giacenza trovata nell'ubicazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (GetDataOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(665, "", "Giacenza non presente nell'ubicazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsWmsJob.GetRowCountGiacenzeOriInfo(False) <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(666, "", "Nessuna Giacenza presente nell'ubicazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
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

                'VERIFICO E ELABORO EVENTUALE ACCORPAMENTO MISSIONI
                RetCode = clsWmsJob.GetJobPickGroupExecInformation(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(378, "", "Errore in elab. accorpamento.") & vbCrLf & "[GetJobPickGroupExecInformation]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
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
            End If

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_4_Sel_UbiOrigine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazione.Focused = True) And (Me.txtUbicazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazione.Text = UCase(Me.txtUbicazione.Text)
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

    Private Sub frmPickingMerci_Appr_4_Sel_UbiOrigine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        Dim wkInfoPrelievo As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblUbicazioneProposta.Text = clsAppTranslation.GetSingleParameterValue(162, lblUbicazioneProposta.Text, "Proposta:")
            lblUbicazione.Text = clsAppTranslation.GetSingleParameterValue(124, lblUbicazione.Text, "Ubicazione Origine")

            Me.Text = clsAppTranslation.GetSingleParameterValue(161, Me.Text, "Picking Appr. (4)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
		    cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************    


            Me.Text = clsAppTranslation.GetSingleParameterValue(161, Me.Text, "Picking Appr. (4)")

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                'VERIFICO SE DEVO SEGNALARE UNA INFORMAZIONE DI PRELIEVO
                RetCode = clsWmsJob.GetJobInfoPrelievo(wkInfoPrelievo)
                If (wkInfoPrelievo = "") Then
                    Me.txtUbicazioneProposta.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                Else
                    '>>> MOSTRO L'INFORMAZIONE SOLO SE HO FATTO ALMENO UNO STEP
                    If (clsWmsJob.WmsJob.CurrentStep > 1) Then
                        '>>> NEL SECONDO STEP MI SERVE L'EVENTUALE INDICAZIONE
                        Me.txtUbicazioneProposta.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione & "-" & wkInfoPrelievo
                    Else
                        Me.txtUbicazioneProposta.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                    End If
                End If
                If (WorkSapWmGiacenza.UbicazioneInfo.Ubicazione = Default_PickingMerci_Ubicazione_Scaffale) Then
                    Me.txtUbicazione.Text = Default_PickingMerci_Ubicazione_Scaffale
                End If
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUbicazione.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Function ConfermaSelezioneLocazione(ByVal inUbicazioneSelezionata As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneLocazione = 1 'init at error

            Me.Focus()
            If (inUbicazioneSelezionata <> "") Then
                Me.txtUbicazione.Text = inUbicazioneSelezionata
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
    Private Sub cmdSelectUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazione.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CREO IL DATASET DEI DIVERSI STOCK PRELEVABILI
            RetCode = clsSapUtility.FromSapWmGiacenzaArrayToDataRow(clsWmsJob.MaterialePickOriGiacenze, clsWmsJob.objDataTableGiacenzeOriInfo)

            frmPickingMerci_Appr_SelStockOrigineForm = New frmPickingMerci_Appr_SelStockOrigine
            frmPickingMerci_Appr_SelStockOrigineForm.SourceForm = Me
            frmPickingMerci_Appr_SelStockOrigineForm.Show()

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

            If (Me.txtUbicazione.Text <> "") Then
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

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class