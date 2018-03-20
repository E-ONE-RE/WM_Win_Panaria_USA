Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms
Imports System.Data

Public Class frmMovimento_StockE_Part_3

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMovimento_StockE_Part_3"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmMovimento_StockE_Part_3_KeyPress(Me, e)

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


    Private Sub frmMovimento_StockE_Part_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMovimento_StockE_Part_3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(4, lblUbicazioneOrigine.Text, "Ubicazione")
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")
            lblUM.Text = clsAppTranslation.GetSingleParameterValue(70, lblUM.Text, "UM")
            lblDescrizioneMateriale.Text = clsAppTranslation.GetSingleParameterValue(95, lblDescrizioneMateriale.Text, "Descr. Materiale")
            lblLottoPartita.Text = clsAppTranslation.GetSingleParameterValue(96, lblLottoPartita.Text, "Lot/Part.")
            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(126, lblQtaPrevista.Text, "Qta Stock")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, lblQtaConfermata.Text, "Qta Conf.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(146, Me.Text, "Movimento Stock E (3)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

            '************************************** 


            If (clsSelezioneCodiceMateriale.SelectionOnRun = False) Then
                If (clsRegModStockE.FirstLoadExecuted_Step_3 = True) Then
                    'VISUALIZZO UBICAZIONE ORIGINE
                    Me.txtCodiceMateriale.Text = clsRegModStockE.MaterialeGiacenza.CodiceMateriale
                    Me.txtDescrizioneMateriale.Text = clsRegModStockE.MaterialeGiacenza.DescrizioneMateriale
                    Me.txtQtaPrevista.Text = clsRegModStockE.MaterialeGiacenza.QtaTotaleLquaDisponibile
                    Me.txtQtaConfermata.Text = clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore

                    'VERIFICO SE IL TIPO MAGAZZINO PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
                    If (clsRegModStockE.UbicazioneMovimento.AbilitaUnitaMagazzino = True) Then
                        Me.txtUM.Visible = True
                        Me.lblUM.Visible = True
                    Else
                        Me.txtUM.Visible = False
                        Me.lblUM.Visible = False
                    End If
                Else
                    '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                    clsRegModStockE.FirstLoadExecuted_Step_3 = True
                End If
            End If

            Me.txtUbicazioneOrigine.Text = clsRegModStockE.UbicazioneMovimento.TipoMagazzino & "/" & clsRegModStockE.UbicazioneMovimento.Ubicazione

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
            Call clsNavigation.Show_Ope_Reg_Modifica_Stock_E(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim WorkDataRow As datarow = Nothing
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
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
            If (clsRegModStockE.UbicazioneMovimento.AbilitaUnitaMagazzino = True) Then
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
            If (clsRegModStockE.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE) Or (clsRegModStockE.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom) Then
                WorkDatiRicercaStock.CdStockSpeciale = "E"
            End If
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = Me.txtQtaConfermata.Text
            WorkDatiRicercaStock.UbicazioneInfo.Divisione = clsRegModStockE.UbicazioneMovimento.Divisione
            WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = clsRegModStockE.UbicazioneMovimento.Ubicazione

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkSapFunctionError, True, Nothing)
            If (CheckStockOk = False) Then
                RetCode = ClearMaterialInfo()
                ErrDescription = clsAppTranslation.GetSingleParameterValue(639, "", "Materiale e Qtà specificata non in stock.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '*************************************************************************
            'VERIFICO IN SAP LE GIACENZE CHE CORRISPONDONO AI CRITERI IMMESSI
            If (clsRegModStockE.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE) Or (clsRegModStockE.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom) Then
                clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
                RetCode = clsRegModStockE.ClearGiacenzeInfo() 'init
                WorkUbicazione.Divisione = clsRegModStockE.UbicazioneMovimento.Divisione
                WorkUbicazione.NumeroMagazzino = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
                WorkUbicazione.TipoMagazzino = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
                WorkUbicazione.Ubicazione = clsRegModStockE.UbicazioneMovimento.Ubicazione
                WorkUbicazione.UnitaMagazzino = Me.txtUM.Text
                WorkGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
                WorkGiacenza.CdStockSpeciale = "E"
                'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
                RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsRegModStockE.objDataTableGiacenzeInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (GetDataOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(640, "", "Giacenza con STOCK E non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If ((GetDataOk = True) Or (RetCode = 0)) Then
                    If (Not (clsRegModStockE.objDataTableGiacenzeInfo Is Nothing)) Then
                        If (clsRegModStockE.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                            WorkDataRow = clsRegModStockE.objDataTableGiacenzeInfo.Rows(0)
                            If (Not (WorkDataRow Is Nothing)) Then
                                ErrDescription = clsAppTranslation.GetSingleParameterValue(640, "", "Giacenza con STOCK E non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If


            '********************************************************************************
            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E POSSO VISUALIZZARE I DATI
            '>>> SALVO E VISUALIZZO I DATI DELLO STOCK TROVATO
            Me.txtDescrizioneMateriale.Text = WorkDatiGiacenza.DescrizioneMateriale
            Me.txtQtaPrevista.Text = WorkDatiGiacenza.QtaTotaleLquaDisponibile
            clsRegModStockE.MaterialeGiacenza.DescrizioneMateriale = WorkDatiGiacenza.DescrizioneMateriale
            clsRegModStockE.MaterialeGiacenza.UnitaDiMisuraBase = WorkDatiGiacenza.UnitaDiMisuraBase
            clsRegModStockE.MaterialeGiacenza.QtaTotaleLquaDisponibile = WorkDatiGiacenza.QtaTotaleLquaDisponibile

            'MEMORIZZO DATI GIACENZA NEI DATI DEL TRASFERIMENTO IN CORSO
            clsRegModStockE.MaterialeGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
            clsRegModStockE.MaterialeGiacenza.DescrizioneMateriale = Me.txtDescrizioneMateriale.Text
            clsRegModStockE.MaterialeGiacenza.Partita = Me.txtLottoPartita.Text
            If (IsNumeric(Me.txtQtaPrevista.Text)) And (Me.txtQtaPrevista.Text <> "") Then
                clsRegModStockE.MaterialeGiacenza.QtaTotaleLquaInStock = Me.txtQtaPrevista.Text
            Else
                clsRegModStockE.MaterialeGiacenza.QtaTotaleLquaInStock = 0
            End If
            If (IsNumeric(Me.txtQtaConfermata.Text)) And (Me.txtQtaConfermata.Text <> "") Then
                clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore = Me.txtQtaConfermata.Text
            Else
                clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore = 0
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_Reg_Modifica_Stock_E(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

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
            WorkDatiRicercaGiacenza.UbicazioneInfo.NumeroMagazzino = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            WorkDatiRicercaGiacenza.UbicazioneInfo.TipoMagazzino = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            WorkDatiRicercaGiacenza.UbicazioneInfo.Ubicazione = clsRegModStockE.UbicazioneMovimento.Ubicazione

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
            clsSelezioneCodiceMateriale.FilterDivisione = clsRegModStockE.UbicazioneMovimento.Divisione
            clsSelezioneCodiceMateriale.FilterNumMag = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            clsSelezioneCodiceMateriale.FilterTipiMag = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            clsSelezioneCodiceMateriale.FilterUbicazione = clsRegModStockE.UbicazioneMovimento.Ubicazione
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