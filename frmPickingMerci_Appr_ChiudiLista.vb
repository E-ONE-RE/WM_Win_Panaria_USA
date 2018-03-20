
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsSapUtility

Public Class frmPickingMerci_Appr_ChiudiLista

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_ChiudiLista"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_ChiudiLista_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Appr_ChiudiLista_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.DtGridStockInfo.Focused = True) And (Me.DtGridStockInfo.CurrentRowIndex >= 0)) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdCloseJobsGroup_Click(Me, e)
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

    Private Sub frmPickingMerci_Appr_ChiudiLista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(177, lblUbicazioneDestinazione.Text, "Ubicaz.Dest.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(176, Me.Text, "Picking Appr.(Chiudi)")

            cmdSpostaTuttiGliUDC.Text = clsAppTranslation.GetSingleParameterValue(270, cmdSpostaTuttiGliUDC.Text, "Sposta")
            cmdVerificaStock.Text = clsAppTranslation.GetSingleParameterValue(269, cmdVerificaStock.Text, "Verifica")
            cmdCloseJobsGroup.Text = clsAppTranslation.GetSingleParameterValue(252, cmdCloseJobsGroup.Text, "Chiudi")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdSelectUbicazioneDest.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdSelectUbicazioneDest.Text, ">")
#End If

            '**************************************


            If (Not clsWmsJobsGroup.objDataTablePickUMInfo Is Nothing) Then
                clsWmsJobsGroup.objDataTablePickUMInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = clsWmsJobsGroup.objDataTablePickUMInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            RetCode = GetSelectedRowInfo(UserSelezioneOk)

            Me.Text = clsAppTranslation.GetSingleParameterValue(707, "", "Picking x Pronto (Chiudi)") & "-" & clsWmsJobsGroup.GetRowWmsJobsGroupExecutionPickUM(False)

            'ESEGUO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.DtGridStockInfo.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridStockInfo.TableStyles.Count = 0) Then
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, DefDtGridCol_NumeroMagazzino, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
            End If

            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function
    Public Function GetSelectedRowInfo(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedRowInfo = 1 'INIT AT ERROR

            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshInfoRowSelected()


            GetSelectedRowInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Function RefreshInfoRowSelected() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshInfoRowSelected = 1 'INIT AT ERROR

            'VISUALIZZO DATI DEL GRUPPO ESEGUITO
            Me.txtInfoRowSelected.Text = clsWmsJobsGroup.FromSapJobsGroupInfoToString(0)

            RefreshInfoRowSelected = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtGridStockInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedRowInfo(UserSelezioneOk)

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

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdVerificaStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerificaStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim outJobsGroupOkxClose As Boolean = False
        Dim outJobsGroupMaterialOk As Boolean = False
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            WorkString = clsAppTranslation.GetSingleParameterValue(708, "", "Si desidera verificare la posizione dello STOCK ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE MISSIONI SONO IN STATO "TERMINATO" PER POTERE CHIUDERE IL GRUPPO
            outJobsGroupOkxClose = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkxClose(outJobsGroupOkxClose, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(709, "", "Errore in CHECK GRUPPO OK x CHIUSURA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupOkxClose = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(710, "", "Attenzione! Gruppo non OK per la CHIUSURA.") & clsAppTranslation.GetSingleParameterValue(711, "", " Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'ESEGUO VERIFICA SULLE GIACENZE DEL GRUPPO
            outJobsGroupMaterialOk = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupMaterialOk(outJobsGroupMaterialOk, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(712, "", "Errore in CHECK GIACENZA JOBS GROUP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupMaterialOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(713, "", "Giacenza del GRUPPO MISSIONE NON VALIDA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(714, "", "Andare in UFFICIO e verificare merce con RESPONSABILE.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE ARRIVBO QUI LA GIACENZA E' CORRETTA
            ErrDescription = clsAppTranslation.GetSingleParameterValue(715, "", "Giacenza del GRUPPO MISSIONE VALIDA!")
            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub cmdSpostaTuttiGliUDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSpostaTuttiGliUDC.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim ChekUbicazioneOk As Boolean = False
        Dim JobsGroupUbicazDestinatioOk As Boolean = False
        Dim outJobsGroupOkxClose As Boolean = False
        Dim GetExecutionOk As Boolean = False
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim UMStorageLocations As Collection
        Dim WorkUbicazioneAttuale As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(716, "", "Attenzione, specificare una UBICAZIONE DESTINAZIONE corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE MISSIONI SONO IN STATO "TERMINATO" PER POTERE CHIUDERE IL GRUPPO
            outJobsGroupOkxClose = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkxClose(outJobsGroupOkxClose, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(709, "", "Errore in CHECK GRUPPO OK x CHIUSURA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupOkxClose = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(710, "", "Attenzione! Gruppo non OK per la CHIUSURA.") & clsAppTranslation.GetSingleParameterValue(711, "", " Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> VERIFICO SE L'UBICAZIONE SPECIFICATA E' CORRETTA E ESISTENTE
            clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            DatiRicercaUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            DatiRicercaUbicazione.UnitaMagazzino = ""
            RetCode = clsSapUtility.ResetSapFunctionError(SapFunctionError)
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Or (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(454, "", "Ubicazione Destinazione non definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PER SPOSTARE DEVO AVERE ALMENO PIU DI UNA PALETTA
            If (clsWmsJobsGroup.objDataTablePickUMInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(720, "", "Nessuna UNITA MAGAZZINO presente.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'DEVO AVERE ALMENO DUE UBICAZIONI DIVERSE
            RetCode = clsWmsJobsGroup.GetPickUMStorageLocations(UMStorageLocations)
            If (UMStorageLocations.Count <= 0) Or (UMStorageLocations Is Nothing) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(721, "", "Attenzione, nessuna ubicazione usata per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
            ElseIf (UMStorageLocations.Count = 1) Then
                'SE HO UNA SOLA UBICAZIONE USATA, LA MERCE NON PUO' ESSERE SPOSTATA NELLA STESSA UBICAZIONE
                WorkUbicazioneAttuale = UMStorageLocations(1)
                If (clsUtility.IsStringValid(WorkUbicazioneAttuale, True) = True) And (UCase(WorkUbicazioneAttuale) = UCase(Me.txtUbicazioneDestinazione.Text)) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(722, "", "Attenzione.Merce gia' posizionata in ubicazione:") & WorkUbicazioneAttuale & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '**********************************************************************
            'PER SPOSTARE LE UDC DEVO AVERE IL GRUPPO ANCORA APERTO
            '**********************************************************************
            If (clsWmsJobsGroup.WmsJobsGroupInfo.JobsGroupClosed = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(723, "", "Gruppo missioni chiuso. Non e' pu' possibile spostare la merce.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            WorkString = clsAppTranslation.GetSingleParameterValue(724, "", "Si desidera veramente spostare le UNITA MAGAZZINO nell'ubicazione:") & vbCrLf & Me.txtUbicazioneDestinazione.Text & " ?" & vbCrLf & clsAppTranslation.GetSingleParameterValue(725, "", "Rispondere (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '**********************************************************************
            'ESEGUO LA MOVIMENTAZIONE DELLA MERCE NELLA DESTINAZIONE SELEZIONATA
            '**********************************************************************
            JobsGroupUbicazDestinatioOk = False
            RetCode = clsWmsJobsGroup.SetJobsGroupUbicazDestination(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, InfoUbicazione, JobsGroupUbicazDestinatioOk, False)
            If (RetCode <> 0) Or (JobsGroupUbicazDestinatioOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(726, "", "Errore in  CAMBIO DESTINAZIONE gruppo missioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> REFRESH INFORMAZIONI DI SUMMARY SUL GRUPPO DEI JOBS
            GetExecutionOk = False
            RetCode = clsWmsJobsGroup.GetJobsGroupSummary(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, GetExecutionOk, False)
            If ((RetCode <> 0) Or (GetExecutionOk = False)) Then
                '>>> CASO DI ERRORE IN ESECUZIONE
                WorkString = clsAppTranslation.GetSingleParameterValue(727, "", "Errore in lettura dati esecuzione GRUPPO MISSIONI.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'AGGIORNO I DATI DELLA GRIGLIA DOPO AVERE CAMBIATO L'UBICAZIONE
            If (Not clsWmsJobsGroup.objDataTablePickUMInfo Is Nothing) Then
                Me.DtGridStockInfo.DataSource = clsWmsJobsGroup.objDataTablePickUMInfo
            End If

            WorkString = clsAppTranslation.GetSingleParameterValue(728, "", "Trasferimento delle UNITA MAGAZZINO eseguito con successo.")
            MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectUbicazioneDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazioneDest.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazioneDestinazione.Text, 0, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me, Me.txtUbicazioneDestinazione.Text, clsUser.SapWmsUser.WERKS, clsUser.SapWmsUser.LGNUM, clsSapUtility.cstSapTipoMagPronto, False)

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
                Me.txtUbicazioneDestinazione.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
                Me.cmdCloseJobsGroup.Focus()
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

    Private Sub cmdCloseJobsGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCloseJobsGroup.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String
        Dim JobsGroupClosedOk As Boolean = False
        Dim UMStorageLocations As Collection
        Dim outJobsGroupOkxClose As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsWmsJobsGroup.WmsJobsGroupInfo.JobsGroupClosed = True) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(729, "", "Gruppo gia' CHIUSO. Si desidera abbandonare la procedura ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
                '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE IL CODICE DEL GRUPPO MISSIONI DA ESEGUIRE 
                Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
                Exit Sub
            Else
                'CASO NORNALE => CHIEDO ALL'OPERATORE SE DESIDERA CHIUDERE LA LISTA
                WorkString = clsAppTranslation.GetSingleParameterValue(730, "", "Si desidera veramente chiudere il GRUPPO MISSIONI ? (SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
                    UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If
                    'IN QUESTO CASO L'OPERATORE ESCE DALLA MISSIONE SENZA CHIUDERE IL GRUPPO MISSIONI
                    '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
                    Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)
                    Exit Sub
                End If
            End If

            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE MISSIONI SONO IN STATO "TERMINATO" PER POTERE CHIUDERE IL GRUPPO
            outJobsGroupOkxClose = False
            RetCode = clsWmsJobsGroup.CheckJobsGroupOkxClose(outJobsGroupOkxClose, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(709, "", "Errore in CHECK GRUPPO OK x CHIUSURA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (outJobsGroupOkxClose = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(710, "", "Attenzione! Gruppo non OK per la CHIUSURA.") & clsAppTranslation.GetSingleParameterValue(711, "", " Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'FACCIO DEI CONTROLLI PER VERIFICARE SE TUTTE LE PALETTE SONO NELLA STESSA UBICAZIONE ( CASO NORMALE )
            RetCode = clsWmsJobsGroup.GetPickUMStorageLocations(UMStorageLocations)
            If (UMStorageLocations.Count > 1) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(733, "", "Attenzione, verificate piu' ubicazioni usate per il PICKING.") & vbCrLf & "Si desidera continuare (SI/NO)."
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
            End If

            '**********************************************************************
            'ESEGUO LA CHIUSURA DEL JOB GROUPS
            JobsGroupClosedOk = False
            RetCode = clsWmsJobsGroup.SetJobsGroupClosed(clsWmsJobsGroup.WmsJobsGroupInfo.NumeroJobsGroup, JobsGroupClosedOk, False)
            If (RetCode <> 0) Or (JobsGroupClosedOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(735, "", "Attenzione! Errore in CHIUSURA gruppo missioni.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
            Call clsNavigation.Show_Ope_PickingMerci_Approntamento(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeInitSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class