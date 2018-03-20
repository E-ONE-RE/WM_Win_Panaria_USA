Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms
Imports System.Data

Public Class frmTRASF_MAT_Part_2_ConfCodMat

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_MAT_Part_2_ConfCodMat"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza


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

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_MAT_Part_2_ConfCodMat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
                    WorkDatiRicercaGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
                    WorkDatiRicercaGiacenza.UbicazioneInfo.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
                    WorkDatiRicercaGiacenza.UbicazioneInfo.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino
                    WorkDatiRicercaGiacenza.UbicazioneInfo.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione
                    RetCode = GetMaterialInfo(WorkDatiRicercaGiacenza)
                    If (clsUtility.IsStringValid(Me.txtDescrizioneMateriale.Text, True) = True) Then
                        'SE HO TROVATO MATERIALE VALIDO PASSO A CONFERMA QTA
                        Me.txtQtaConfermata.Focus()
                    End If
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

    Private Sub frmTRASF_MAT_Part_2_ConfCodMat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(192, Me.Text, "TRASF - Mat. (2)")

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
                'VISUALIZZO UBICAZIONE ORIGINE
                Me.txtUbicazioneOrigine.Text = clsTrasfMat.SourceUbicazione.TipoMagazzino & "/" & clsTrasfMat.SourceUbicazione.Ubicazione
                Me.txtCodiceMateriale.Text = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
                Me.txtDescrizioneMateriale.Text = clsTrasfMat.MaterialeGiacenza.DescrizioneMateriale
                Me.txtQtaPrevista.Text = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDisponibile
                Me.txtQtaConfermata.Text = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore

                'VERIFICO SE IL TIPO MAGAZZINO PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
                If (clsTrasfMat.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
                    Me.txtUM.Visible = True
                    Me.lblUM.Visible = True
                Else
                    Me.txtUM.Visible = False
                    Me.lblUM.Visible = False
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
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkSapFunctionError As clsBusinessLogic.SapFunctionError
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDataRow As datarow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
            Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)

            'VERIFICO SE IL MATERIALE SPECIFICATO E' CORRETTA
            If (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE HO ATTIVA LA GESTIONE DELL'UDM LO DEVO VERIFICARE
            If (clsTrasfMat.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
                If (Me.txtUM.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(791, "", "Codice Udm non corretto.")
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

            '*************************************************************************
            'VERIFICO IN SAP (CODICE MATERIALE, GIACENZA, QTA SE CORRETTA, CODICE UDM)
            WorkDatiRicercaStock.CodiceMateriale = Me.txtCodiceMateriale.Text
            WorkDatiRicercaStock.QtaJobRichiestaInUdmOriginale = Me.txtQtaConfermata.Text
            WorkDatiRicercaStock.UbicazioneInfo.Divisione = clsTrasfMat.SourceUbicazione.Divisione
            WorkDatiRicercaStock.UbicazioneInfo.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino
            WorkDatiRicercaStock.UbicazioneInfo.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(WorkDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkSapFunctionError, False, Nothing)
            If (CheckMatnrOk = False) Then
                '>>> CASO DI CODICE MATERIALE NON VALIDO
                ErrDescription = clsAppTranslation.GetSingleParameterValue(610, "", "Codice Materiale non valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtCodiceMateriale.Focus()
                Exit Sub
            End If
            If (CheckStockOk = False) Then
                '>>> NEL TRASFERIMENTO NORMALE SONO OBBLIGATO AD AVERE LA GIACENZA
                RetCode = ClearMaterialInfo()
                ErrDescription = clsAppTranslation.GetSingleParameterValue(793, "", "Qtà specificata non trovata in stock.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '*************************************************************************
            'VERIFICO IN SAP LE GIACENZE CHE CORRISPONDONO AI CRITERI IMMESSI
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfMat.ClearGiacenzeInfo() 'init
            WorkUbicazione.Divisione = clsTrasfMat.SourceUbicazione.Divisione
            WorkUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino
            WorkUbicazione.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione
            WorkUbicazione.UnitaMagazzino = Me.txtUM.Text
            WorkGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsTrasfMat.objDataTableGiacenzeInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
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
            If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(375, "", "Nessuna Giacenza in STOCK con i FILTRI immessi.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            '************************************************************************************************
            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E POSSO VISUALIZZARE I DATI
            '************************************************************************************************
            If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count = 1) Then
                WorkDataRow = clsTrasfMat.objDataTableGiacenzeInfo.Rows(0)
                'SETTO I DATI DELLA GIACENZA SELEZIONATA
                RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, WorkDatiGiacenza, False)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(605, "", "Errore in estrazione dati Giacenza (FromLquaToWmGiacenza).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '>>> SALVO E VISUALIZZO I DATI DELLO STOCK TROVATO
                clsTrasfMat.MaterialeGiacenza = WorkDatiGiacenza
                clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = Me.txtQtaConfermata.Text
            End If


            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEI MAGAZZINI DI SISTEMA
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfMat.ClearGiacenzeInfo() 'init
            WorkUbicazione.Divisione = clsTrasfMat.SourceUbicazione.Divisione
            WorkUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = "*"
            WorkUbicazione.Ubicazione = "*"

            WorkGiacenza.CodiceMateriale = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
            WorkGiacenza.Partita = clsTrasfMat.MaterialeGiacenza.Partita

            '>>> DEVO ESCLUDERE L'UBICAZIONE CORRENTE
            ReDim WorkExcludeUbicazioni(0)
            WorkExcludeUbicazioni(0).Divisione = clsTrasfMat.SourceUbicazione.Divisione
            WorkExcludeUbicazioni(0).NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            WorkExcludeUbicazioni(0).TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino
            WorkExcludeUbicazioni(0).Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsTrasfMat.objDataTableGiacenzeInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            If ((GetDataOk = True) Or (RetCode = 0)) Then
                If (Not (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing)) Then

                End If
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

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


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtCodiceMateriale.Text = "" Then
                Exit Sub
            End If
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

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

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_STOCK_GIACENZA(inDatiRicercaStock, clsUser.SapWmsUser.LANGUAGE, CheckStockOk, CheckMatnrOk, WorkDatiGiacenza, WorkDatiGiacenzeFree, WorkSapFunctionError, False, Nothing)
            If (CheckMatnrOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(610, "", "Codice Materiale non valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                RetCode = ClearMaterialInfo()
                Me.txtCodiceMateriale.Focus()
                Exit Function
            End If

            If (WorkDatiGiacenza.QtaTotaleLquaDisponibile = 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(611, "", "Attenzione, QTA in stock = 0.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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


            'If (Me.txtCodiceMateriale.Text = "") Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'If (InStr(1, Me.txtCodiceMateriale.Text, "*") > 0) Then
            '    If (Len(Me.txtCodiceMateriale.Text) < 6) Then
            '        ErrDescription = clsAppTranslation.GetSingleParameterValue(529, "", "Per velocizzare la ricerca inserire almeno 6 caratteri.")
            '        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '        Exit Sub
            '    End If
            'End If
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            clsSelezioneCodiceMateriale.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneCodiceMateriale.SelezioneCodiceMaterialeType = clsDataType.SelezioneCodiceMaterialeType.SelezioneCodiceMaterialeTypeForUbicazione
            clsSelezioneCodiceMateriale.FilterDivisione = clsTrasfMat.SourceUbicazione.Divisione
            clsSelezioneCodiceMateriale.FilterNumMag = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            clsSelezioneCodiceMateriale.FilterTipiMag = clsTrasfMat.SourceUbicazione.TipoMagazzino
            clsSelezioneCodiceMateriale.FilterUbicazione = clsTrasfMat.SourceUbicazione.Ubicazione
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