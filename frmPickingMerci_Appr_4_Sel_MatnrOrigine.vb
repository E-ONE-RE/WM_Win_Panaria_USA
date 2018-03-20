Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms

Public Class frmPickingMerci_Appr_4_Sel_MatnrOrigine

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Appr_4_Sel_MatnrOrigine"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza



    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Appr_4_Sel_MatnrOrigine_KeyPress(Me, e)

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


    Private Sub frmPickingMerci_Appr_4_Sel_MatnrOrigine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
                    Me.txtQtaConfermata.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Call cmdNextScreen_Click(Me, e)
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

    Private Sub frmPickingMerci_Appr_4_Sel_MatnrOrigine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(124, lblUbicazioneOrigine.Text, "Ubicazione Origine")
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")
            lblUM.Text = clsAppTranslation.GetSingleParameterValue(70, lblUM.Text, "UM")
            lblDescrizioneMateriale.Text = clsAppTranslation.GetSingleParameterValue(95, lblDescrizioneMateriale.Text, "Descr. Materiale")
            lblLottoPartita.Text = clsAppTranslation.GetSingleParameterValue(96, lblLottoPartita.Text, "Lot/Part.")
            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(126, lblQtaPrevista.Text, "Qta Stock")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, lblQtaConfermata.Text, "Qta Conf.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(161, Me.Text, "Picking Appr. (4)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

            '**************************************    


            'VISUALIZZO UBICAZIONE ORIGINE
            Me.txtCodiceMateriale.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            Me.txtDescrizioneMateriale.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.DescrizioneMateriale
            Me.txtQtaPrevista.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDisponibile
            Me.txtQtaConfermata.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore

            'VERIFICO SE IL TIPO MAGAZZINO PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.AbilitaUnitaMagazzino = True) Then
                Me.txtUM.Visible = True
                Me.lblUM.Visible = True
            Else
                Me.txtUM.Visible = False
                Me.lblUM.Visible = False
            End If

            Me.txtUbicazioneOrigine.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino & "/" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione

            Me.Text = "Picking x Pronto (4)"

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckStockOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkSapFunctionError As clsBusinessLogic.SapFunctionError
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE IL MATERIALE SPECIFICATO E' CORRETTA
            If (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE HO ATTIVA LA GESTIONE DELL'UDM LO DEVO VERIFICARE
            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.AbilitaUnitaMagazzino = True) Then
                If (Me.txtUM.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(431, "", "Codice UM non corretto.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            If (Me.txtQtaConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            '*************************************************************************
            'VERIFICO IN SAP (CODICE MATERIALE, GIACENZA, QTA SE CORRETTA, CODICE UDM)
            WorkDatiRicercaStock.CodiceMateriale = Me.txtCodiceMateriale.Text
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = Me.txtQtaConfermata.Text
            WorkDatiRicercaStock.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
            WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.TipoMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Ubicazione

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkSapFunctionError, True, Nothing)
            If (CheckStockOk = False) Then
                RetCode = ClearMaterialInfo()
                ErrDescription = clsAppTranslation.GetSingleParameterValue(639, "", "Materiale e Qtà specificata non in stock.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E POSSO VISUALIZZARE I DATI
            '>>> SALVO E VISUALIZZO I DATI DELLO STOCK TROVATO
            Me.txtDescrizioneMateriale.Text = WorkDatiGiacenza.DescrizioneMateriale
            Me.txtQtaPrevista.Text = WorkDatiGiacenza.QtaTotaleLquaDisponibile

            'MEMORIZZO TUTTE LE GIACENZE LIBERE TROVATE
            'clsWmsJob.MaterialeSourceGiacenzeFree = WorkDatiGiacenzeFree

            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = Me.txtQtaConfermata.Text

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
    Private Sub txtCodiceMateriale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceMateriale.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtCodiceMateriale.Text = "" Then
                Exit Sub
            End If

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
            WorkDatiRicercaGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text

            RetCode = GetMaterialInfo(WorkDatiRicercaGiacenza)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Function ClearMaterialInfo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtDescrizioneMateriale.Text = ""

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Function GetMaterialInfo(ByVal inDatiRicercaStock As clsDataType.SapWmGiacenza) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckStockOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkSapFunctionError As clsBusinessLogic.SapFunctionError
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Len(inDatiRicercaStock.CodiceMateriale) = 0) Then
                RetCode = ClearMaterialInfo()
                Exit Function
            End If

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(inDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkSapFunctionError, True, Nothing)
            If (CheckStockOk = False) Then
                RetCode = ClearMaterialInfo()
                Exit Function
            End If

            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E POSSO VISUALIZZARE I DATI
            Me.txtDescrizioneMateriale.Text = WorkDatiGiacenza.DescrizioneMateriale
            Me.txtQtaPrevista.Text = WorkDatiGiacenza.QtaTotaleLquaDisponibile
            Me.txtQtaConfermata.Text = WorkDatiGiacenza.QtaTotaleLquaDisponibile

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdSelectCodiceMateriale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectCodiceMateriale.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            clsSelezioneCodiceMateriale.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione

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
                Me.txtCodiceMateriale.Focus()
                WorkDatiRicercaGiacenza.UbicazioneInfo.Divisione = clsSelezioneCodiceMateriale.UbicazioneSelezionata.Divisione
                WorkDatiRicercaGiacenza.UbicazioneInfo.NumeroMagazzino = clsSelezioneCodiceMateriale.UbicazioneSelezionata.NumeroMagazzino
                WorkDatiRicercaGiacenza.UbicazioneInfo.TipoMagazzino = clsSelezioneCodiceMateriale.UbicazioneSelezionata.TipoMagazzino
                WorkDatiRicercaGiacenza.UbicazioneInfo.Ubicazione = clsSelezioneCodiceMateriale.UbicazioneSelezionata.Ubicazione
                WorkDatiRicercaGiacenza.UbicazioneInfo.UnitaMagazzino = clsSelezioneCodiceMateriale.UbicazioneSelezionata.UnitaMagazzino
                Me.txtCodiceMateriale.Text = clsSelezioneCodiceMateriale.CodiceMaterialeSelezionato
                Me.txtQtaConfermata.Focus()
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

    Private Sub txtCodiceMateriale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodiceMateriale.TextChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsSelezioneCodiceMateriale.SelectionOnRun = False) Then
                clsSapUtility.ResetGiacenzaStruct(WorkDatiRicercaGiacenza)
                clsSelezioneCodiceMateriale.ClearAllData()
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