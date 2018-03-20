Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms
Imports System.Data

Public Class frmInventarioUbicazione_2_ConfCodMat

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInventarioUbicazione_2_ConfCodMat"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInventarioUbicazione_2_ConfCodMat_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_Inventario(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub frmInventarioUbicazione_2_ConfCodMat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
                    WorkDatiRicercaGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
                    WorkDatiRicercaGiacenza.UbicazioneInfo.NumeroMagazzino = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
                    WorkDatiRicercaGiacenza.UbicazioneInfo.TipoMagazzino = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                    WorkDatiRicercaGiacenza.UbicazioneInfo.Ubicazione = clsInventarioUbicazione.SourceUbicazione.Ubicazione
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

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.F4)) Then
                'SU F4 SIMULO MATCH CODE DI SAP
                Call Me.cmdSelectCodiceMateriale_Click(Me, e)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_2_ConfCodMat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(106, lblCodiceMateriale.Text, "Cod. Materiale")
            lblUM.Text = clsAppTranslation.GetSingleParameterValue(70, lblUM.Text, "UM")
            lblDescrizioneMateriale.Text = clsAppTranslation.GetSingleParameterValue(95, lblDescrizioneMateriale.Text, "Descr. Materiale")
            lblLottoPartita.Text = clsAppTranslation.GetSingleParameterValue(96, lblLottoPartita.Text, "Lot/Part.")
            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(126, lblQtaPrevista.Text, "Qta Stock")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, lblQtaConfermata.Text, "Qta Conf.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(125, Me.Text, "Invent.Ubicazione (2)")

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
                Me.txtUbicazioneOrigine.Text = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino & "/" & clsInventarioUbicazione.SourceUbicazione.Ubicazione
                Me.txtCodiceMateriale.Text = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
                Me.txtDescrizioneMateriale.Text = clsInventarioUbicazione.MaterialeGiacenza.DescrizioneMateriale
                Me.txtQtaPrevista.Text = clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile

                If (clsInventarioUbicazione.MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                    Me.txtQtaConfermata.Text = clsInventarioUbicazione.MaterialeGiacenza.QuantitaConfermataOperatore
                End If

                'VERIFICO SE IL TIPO MAGAZZINO PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
                If (clsInventarioUbicazione.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
                    Me.txtUM.Visible = True
                    Me.lblUM.Visible = True
                Else
                    Me.txtUM.Visible = False
                    Me.lblUM.Visible = False
                End If
            End If

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(125, Me.Text, "Invent.Ubicazione (2)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(596, Me.Text, "Qtà Conteggiata")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(597, Me.Text, "Invent.Rottamazione (2)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(598, Me.Text, "Qtà Rottamata")
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, Me.Text, "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select

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
            Call clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.InventoryType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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

        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeAll() As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkSapFunctionError As clsBusinessLogic.SapFunctionError
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataOk As Boolean = False

        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkDataRow As DataRow
        Dim CasoGiacenzaNonPresente As Boolean = False
        Dim CheckMatnrExistOk As Boolean = False
        Dim WorkInfoMaterialeGiacenzaNulla As clsDataType.SapWmGiacenza
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
            If (clsInventarioUbicazione.SourceUbicazione.AbilitaUnitaMagazzino = True) Then
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

            If (Val(Me.txtQtaConfermata.Text) < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(600, "", "La Qtà NEGATIVA non è valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*************************************************************************
            'VERIFICO IN SAP LE GIACENZE CHE CORRISPONDONO AI CRITERI IMMESSI
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = clsInventarioUbicazione.SourceUbicazione.Divisione
            WorkUbicazione.NumeroMagazzino = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
            WorkUbicazione.Ubicazione = clsInventarioUbicazione.SourceUbicazione.Ubicazione
            WorkUbicazione.UnitaMagazzino = Me.txtUM.Text
            WorkGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsInventarioUbicazione.objDataTableGiacenzeInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            'If (RetCode <> 0) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
            If (GetDataOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(601, "", "Si desidera forzare un conteggio POSITIVO ? (SI/NO)")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> vbYes) Then
                    Exit Sub
                End If
                If (Val(Me.txtQtaConfermata.Text) <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(602, "", "In questo caso la QTA deve essere positiva.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                'VERIFICO SE IL CODICE MATERIALE E' OK.
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_MATERIAL_EXIST(Me.txtCodiceMateriale.Text, clsUser.SapWmsUser.LANGUAGE, CheckMatnrExistOk, WorkInfoMaterialeGiacenzaNulla, SapFunctionError, False)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(603, "", "Errore in estrazione dati MATERIALE (MATERIAL_EXIST).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (CheckMatnrExistOk = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(604, "", "Codice MATERIALE non codificato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (GetDataOk = True) Then
                '>>> CASO GIACENZA PRESENTE E FORZO SOLO IL CAMBIO QTA
                If (Not (clsInventarioUbicazione.objDataTableGiacenzeInfo Is Nothing)) Then
                    If (clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows.Count > 1) Then
                        '>>> CASO DI STOCK AMBIGUO, DEVO OBBLIGARE UTENTE A SELEZIONARE LO STOCK CORRETTO (STOCK E)

                        '>>>> CASO PARTICOLARE DI UN ULTERIORE STEP DI SCELTA DELLA RIGA DI STOCK
                        'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
                        Call clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.InventoryType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
                        Exit Sub
                    ElseIf (clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows.Count = 1) Then
                        WorkDataRow = clsInventarioUbicazione.objDataTableGiacenzeInfo.Rows(0)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, clsInventarioUbicazione.MaterialeGiacenza, False)
                            If (RetCode <> 0) Then
                                ErrDescription = clsAppTranslation.GetSingleParameterValue(605, "", "Errore in estrazione dati Giacenza (FromLquaToWmGiacenza).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Else
                'CASO GIACENZA NON PRESENTE. FISSO I DATI MANUALMENTE
                CasoGiacenzaNonPresente = True
                clsInventarioUbicazione.MaterialeGiacenza.UbicazioneInfo.Divisione = clsInventarioUbicazione.SourceUbicazione.Divisione
                clsInventarioUbicazione.MaterialeGiacenza.UbicazioneInfo.NumeroMagazzino = clsInventarioUbicazione.SourceUbicazione.NumeroMagazzino
                clsInventarioUbicazione.MaterialeGiacenza.UbicazioneInfo.TipoMagazzino = clsInventarioUbicazione.SourceUbicazione.TipoMagazzino
                clsInventarioUbicazione.MaterialeGiacenza.UbicazioneInfo.Ubicazione = clsInventarioUbicazione.SourceUbicazione.Ubicazione
                clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
                clsInventarioUbicazione.MaterialeGiacenza.DescrizioneMateriale = WorkInfoMaterialeGiacenzaNulla.DescrizioneMateriale '>>> RECUPERATA DALL'ANAGRAFICA
                clsInventarioUbicazione.MaterialeGiacenza.Partita = Me.txtLottoPartita.Text
                clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile = 0
                clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaInStock = 0
                clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraBase = WorkInfoMaterialeGiacenzaNulla.UnitaDiMisuraBase '>>> RECUPERATA DALL'ANAGRAFICA
                clsInventarioUbicazione.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
                clsInventarioUbicazione.MaterialeGiacenza.CdStockSpeciale = ""
                clsInventarioUbicazione.MaterialeGiacenza.NumeroStockSpeciale = ""
                clsInventarioUbicazione.MaterialeGiacenza.TipoStock = ""
            End If

            '>>>> VERIFICO SE HO ESTRATTO I DATI DELLA GIACENZA
            If (CasoGiacenzaNonPresente = False) And (clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile = 0) And (clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraBase = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(606, "", "Dati Giacenza non valido (QTA=0).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    If (clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile <> Val(Me.txtQtaConfermata.Text)) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(607, "", "Qtà CONTEGGIATA diversa dallo stock.") & vbCrLf
                        ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                        UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                            Exit Sub
                        End If
                        clsInventarioUbicazione.ConfermataQtaConteggiata = True
                    End If
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    If (Val(Me.txtQtaConfermata.Text) > 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(609, "", "E' stata inserire una QTA da ROTTAMARE.") & vbCrLf
                        ErrDescription = ErrDescription & clsAppTranslation.GetSingleParameterValue(608, "", "Proseguire con una rettifica ? (Si/No)")
                        UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                            Exit Sub
                        End If
                        clsInventarioUbicazione.ConfermataQtaConteggiata = True
                    End If
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select


            '>>> SE ARRIVO QUA LO STOCK E' CORRETTO E POSSO MEMORIZZARE I DATI
            Me.txtDescrizioneMateriale.Text = clsInventarioUbicazione.MaterialeGiacenza.DescrizioneMateriale
            Me.txtQtaPrevista.Text = clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile
            clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale = clsInventarioUbicazione.MaterialeGiacenza.CodiceMateriale
            clsInventarioUbicazione.MaterialeGiacenza.DescrizioneMateriale = clsInventarioUbicazione.MaterialeGiacenza.DescrizioneMateriale
            clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraBase = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraBase
            clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile = clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile
            clsInventarioUbicazione.MaterialeGiacenza.Partita = clsInventarioUbicazione.MaterialeGiacenza.Partita
            clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaInStock = clsInventarioUbicazione.MaterialeGiacenza.QtaTotaleLquaDisponibile
            clsInventarioUbicazione.MaterialeGiacenza.QuantitaConfermataOperatore = Me.txtQtaConfermata.Text

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_InventarioUbicazione(Me, clsInventarioUbicazione.InventoryType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

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
            'Me.txtQtaConfermata.Text = WorkDatiGiacenza.QtaTotaleDisponibile

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