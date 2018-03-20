Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsWmsJob

Public Class frmPickingMerci_Appr_7_Sel_UbiDestinazione
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_7_Sel_UbiDestinazione"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private UbicazioneDestinazioneChangeConf As Boolean = False


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_7_Sel_UbiDestinazione_KeyPress(Me, e)

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

    Private Sub frmPickingMerci_Appr_7_Sel_UbiDestinazione_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneDestinazione.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtInfoPrelievo.Focused = True) And (Me.txtInfoPrelievo.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtInfoPrelievo.Text = UCase(Me.txtInfoPrelievo.Text)
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

    Private Sub frmPickingMerci_Appr_7_Sel_UbiDestinazione_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(77, lblUbicazioneDestinazione.Text, "Ubicazione Destinazione")
            lblInfoPrelievo.Text = clsAppTranslation.GetSingleParameterValue(171, lblInfoPrelievo.Text, "Informazioni x Prelievo")

            Me.Text = clsAppTranslation.GetSingleParameterValue(170, Me.Text, "Picking Appr. (7)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdSelectUbicazioneDest.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdSelectUbicazioneDest.Text, ">")
#End If

            '**************************************    


            Me.Text = "Picking x Pronto (7)"

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(2, False)

            RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                Me.txtUbicazioneDestinazione.Text = WorkSapWmGiacenza.UbicazioneInfo.Ubicazione
                Me.txtInfoPrelievo.Text = clsWmsJob.WmsJob.InfoPrelievo
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            If (Me.txtUbicazioneDestinazione.Text = "") Then
                Me.txtUbicazioneDestinazione.Focus()
            Else
                Me.txtInfoPrelievo.Focus()
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
        Dim CheckExecutionOk As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim UserAnswer As DialogResult
        Dim FlagErroreAttivo As Boolean = False
        Dim MemoNrWmsJobs As String
        Dim wkJobsOkForExecution As Boolean = False
        Dim RetInfoSapWmWmsJob As clsDataType.SapWmWmsJob
        Dim wkExitFormDone As Boolean
        Dim CheckLastJobSequence As Boolean = False
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            clsSapUtility.ResetGiacenzaStruct(WorkSapWmGiacenza)
            RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                If (WorkSapWmGiacenza.UbicazioneInfo.Ubicazione = cstUbicazioneScaffaleDecori) Then
                    If (Me.txtUbicazioneDestinazione.Text <> cstUbicazioneScaffaleDecori) And (clsWmsJob.WmsJob.CurrentStep = 1) Then
                        UserAnswer = MsgBox(clsAppTranslation.GetSingleParameterValue(677, "", "Attenzione! La missione prevede di usare l'ubicazione:") & cstUbicazioneScaffaleDecori & vbCrLf & "Non si dovrebbe cambiare, si conferma di cambiarla ?", MsgBoxStyle.YesNo)
                        If (UserAnswer <> DialogResult.Yes) Then
                            Me.txtUbicazioneDestinazione.Text = cstUbicazioneScaffaleDecori
                            Exit Sub
                        End If
                    End If
                End If
            End If


            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
            Me.txtInfoPrelievo.Text = UCase(Me.txtInfoPrelievo.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneDestinazione.Text = WorkOutUbicazione



            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            DatiRicercaUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino

            'NEL CASO DI UBICAZIONE [TRANSFER] IL PROBLEMA E' CHE E' DEFINITA IN DIVERSI TIPO MAGAZZINO PER CUI DEVO FILTRARE ANCHE IL TIPO MAGAZZINO
            If (clsUtility.IsStringValid(WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino, True) = True) Then
                DatiRicercaUbicazione.TipoMagazzino = WorkSapWmGiacenza.UbicazioneInfo.TipoMagazzino
            End If

            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Or (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> VERIFICO IN OGNI CASO DI NON AVERE ASSOLUTAMENTE SELEZIONATO UNA UBICAZIONE IN UN TIPO MAGAZZINO CON LA GESTIONE DELLA PALLET ID ( SI TRATTA DI UN ERRORE )
            If (InfoUbicazione.AbilitaUnitaMagazzino = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(679, "", "Attenzione! L'ubicazione scelta non e' corretta per questo prelievo.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(680, "", "Tipo Mag:") & InfoUbicazione.TipoMagazzino & clsAppTranslation.GetSingleParameterValue(681, "", " Ubi:") & InfoUbicazione.Ubicazione & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> CASO PARTICOLARE
            'SE HO UN DECORO E QUESTO E' L'ULTIMO JOB DEVO RICHIEDERE FORZATAMENTE UNA INFO DI PRELIEVO
            If (Me.txtUbicazioneDestinazione.Text = cstUbicazioneScaffaleDecori) And (clsWmsJob.WmsJob.CurrentStep = 1) And (Me.txtInfoPrelievo.Text = "") Then
                RetCode = clsSapWS.Call_ZWS_CHECK_JOBS_GROUP_LAST_SEQ(clsWmsJob.WmsJob, CheckLastJobSequence, clsUser.SapWmsUser.LANGUAGE, SapFunctionError, False)
                If (CheckLastJobSequence = True) And (RetCode = 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(682, "", "Occorre specificare una informazione di prelievo per proseguire.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'IMPOSTO I DATI ESSENZIALI PER LE DESTINAZIONE
            clsWmsJob.MaterialeSelStockGiacenzaDest.UbicazioneInfo = InfoUbicazione
            RetCode = clsWmsJob.SetJobPickMaterialGiacenzaDest()
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(390, "", "Errore in impostazione dati DESTINAZIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO LE NOTE DI PRELIEVO
            clsWmsJob.WmsJob.InfoPrelievo = Me.txtInfoPrelievo.Text

            '>>> ESEGUO AZIONE PREVISTA DALLA MISSIONE
            RetCode = clsWmsJob.ExecJobStepExecuted(CheckExecutionOk, ErrDescription, RetInfoSapWmWmsJob)
            If (RetCode <> 0) Or (CheckExecutionOk = False) Then
                FlagErroreAttivo = True
            End If

            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm = New frmPickingMerci_Appr_7_Sel_UbiDestinazione
                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm.Show()
                    frmPickingMerci_Appr_7_Sel_UbiDestinazioneForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA OPERAZIONE DELLA STESSA RIGA MISSIONE
            '*************************************************************************************************
            wkExitFormDone = False
            If (FlagErroreAttivo = False) And (RetInfoSapWmWmsJob.IdWmsJobStatus < clsWmsJob.cstIdJobStatus_Cancellato) And (RetInfoSapWmWmsJob.CurrentStep = clsWmsJob.WmsJob.CurrentStep) Then
                RetCode = clsWmsJob.ReloadDataOfSameJobForNewPick(Me, wkExitFormDone, True)
                If (wkExitFormDone = True) Then
                    Exit Sub
                End If
            End If


            '*************************************************************************************************
            'GESTIONE ESECUZIONE ALTRA MISSIONE DELLO STESSO GRUPPO MISSIONI
            '*************************************************************************************************
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.CodiceGruppoMissioni, True) = True) Then
                RetCode = clsWmsJobsGroup.ReloadDataOfSameJobGroupForNewPick(Me)
                Exit Sub
            End If

            'ESCO DALLA BEM => TORNO AL MENU DI ENTRATA MERCI
            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

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
                Me.txtUbicazioneDestinazione.Text = inUbicazioneSelezionata
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
    Private Sub cmdSelectUbicazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazioneDest.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CREO IL DATASET DEI DIVERSI STOCK PRELEVABILI
            RetCode = clsSapUtility.FromSapWmGiacenzaArrayToDataRow(clsWmsJob.MaterialePickDestinations, clsWmsJob.objDataTableGiacenzeDestInfo)

            frmPickingMerci_Appr_SelStockDestinazioneForm = New frmPickingMerci_Appr_SelStockDestinazione
            frmPickingMerci_Appr_SelStockDestinazioneForm.SourceForm = Me
            frmPickingMerci_Appr_SelStockDestinazioneForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtUbicazioneDestinazione_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUbicazioneDestinazione.TextChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RetCode = clsWmsJob.GetElementMaterialePickDestinationProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                If (WorkSapWmGiacenza.UbicazioneInfo.Ubicazione = cstUbicazioneScaffaleDecori) Then
                    If (Me.txtUbicazioneDestinazione.Text <> cstUbicazioneScaffaleDecori) And (clsWmsJob.WmsJob.CurrentStep = 1) And (UbicazioneDestinazioneChangeConf = False) Then
                        UserAnswer = MsgBox(clsAppTranslation.GetSingleParameterValue(677, "", "Attenzione! La missione prevede di usare l'ubicazione:") & cstUbicazioneScaffaleDecori & vbCrLf & "Non si dovrebbe cambiare, si conferma di cambiarla ?", MsgBoxStyle.YesNo)
                        If (UserAnswer <> DialogResult.Yes) Then
                            Me.txtUbicazioneDestinazione.Text = cstUbicazioneScaffaleDecori
                        Else
                            UbicazioneDestinazioneChangeConf = True
                        End If
                    End If
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
End Class