
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmTRASF_MAT_Part_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_MAT_Part_1"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************
            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    cmdSelectUbicazione_Click(Me, e)
            End Select

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_MAT_Part_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneOrigine.Focused = True) And (Me.txtUbicazioneOrigine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, Nothing)
                    Exit Sub
                End If
            ElseIf ((Me.txtUbicazioneOrigine.Focused = True) And (Me.txtUbicazioneOrigine.Text = "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Origine.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtUM_Origine.Focused = True) And (Me.txtUM_Origine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Origine.Text = UCase(Me.txtUM_Origine.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, Nothing)
                    Exit Sub
                End If
            ElseIf ((Me.txtUM_Origine.Focused = True) And (Me.txtUM_Origine.Text = "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceMateriale.Focus()
                    Exit Sub
                End If
            End If


            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, Nothing)
                    Exit Sub
                End If
            ElseIf ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text = "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    If (Me.txtUbicazioneOrigine.Text = "") And (Me.txtUM_Origine.Text = "") And (Me.txtCodiceMateriale.Text = "") Then
                        'NESSUN FILTRO VALORIZZATO => TORNO ALLA PRIMA CASELLA
                        Me.txtUbicazioneOrigine.Focus()
                        Exit Sub
                    Else
                        'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                        Call Me.cmdNextScreen_Click(Me, Nothing)
                        Exit Sub
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

    Private Sub frmTRASF_MAT_Part_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(124, Me.lblUbicazioneOrigine.Text, "Ubicazione Origine")
            Me.lblUM_Origine.Text = clsAppTranslation.GetSingleParameterValue(64, Me.lblUM_Origine.Text, "Unità Magazzino")
            Me.lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, Me.lblCodiceMateriale.Text, "Codice Materiale")
            Me.Text = clsAppTranslation.GetSingleParameterValue(191, Me.Text, "TRASF - Mat. (1)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '************************************** 


            clsTrasfMat.SourceUbicazione.Divisione = clsUser.GetUserDivisionToUse()
            clsTrasfMat.SourceUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUbicazioneOrigine.Focus()

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione

        Dim InfoUbicazione As clsDataType.SapWmUbicazione

        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False
        Dim WorkDataRow As DataRow
        Dim UnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneOrigine.Text = "") And (Me.txtUM_Origine.Text = "") And (Me.txtCodiceMateriale.Text = "") And (Me.txtSKU.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(785, "", "Specificare una Ubicazione o una Unità di Magazzino") & clsAppTranslation.GetSingleParameterValue(786, "", "o un Codice Materiale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            If (Me.txtUM_Origine.Text <> "") Then
                RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM_Origine.Text, UnitaMagazzinoOk, True)
                If (UnitaMagazzinoOk = False) Then
                    Me.txtUM_Origine.Text = ""
                    Exit Sub
                End If
            End If


            Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneOrigine.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneOrigine.Text = WorkOutUbicazione


            If (clsUtility.IsStringValid(Me.txtUbicazioneOrigine.Text, True) = True) Then
                '>>>> CASO DOVE HO SPECIFICATO L'UBICAZIONE
                'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
                RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
                DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
                DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneOrigine.Text
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
                If (ChekUbicazioneOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(669, "", "Ubicazione Origine non definita  nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                Me.txtUbicazioneOrigine.Text = InfoUbicazione.Ubicazione

                'MEMORIZZO L'UBICAZIONE NEI DATI DEL TRASFERIMENTO IN CORSO
                clsTrasfMat.SourceUbicazione = InfoUbicazione

                'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
                If (clsUser.SapWmsUser.PROFID = "") And (InfoUbicazione.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(787, "", "Il materiale non puo' essere trasferito dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                '>>> IN QUESTO CASO DEVO RESETTARE LA
                clsSapUtility.ResetUbicazioneStruct(clsTrasfMat.SourceUbicazione)
                'IMPOSTO SOLO LA BASE PER LA RICERCA
                clsTrasfMat.SourceUbicazione.Divisione = clsUser.GetUserDivisionToUse()
                clsTrasfMat.SourceUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            End If

            '*************************************************************************
            '>>> SE NON GESTISCO L'INSERIMENTO DEL CODICE MATERIALE DEVO CARICARE
            '>>> LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfMat.ClearGiacenzeInfo() 'init
            If (clsUtility.IsStringValid(Me.txtUM_Origine.Text, True) = True) Then
                'FILTRO EVENTUALE UM IMMESSA
                clsTrasfMat.SourceUbicazione.UnitaMagazzino = Me.txtUM_Origine.Text
            End If
            WorkUbicazione = clsTrasfMat.SourceUbicazione
            WorkGiacenza.CodiceMateriale = Trim(UCase(Me.txtCodiceMateriale.Text))
            WorkGiacenza.SKU = UCase(Me.txtSKU.Text)
            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeOk, clsTrasfMat.objDataTableGiacenzeInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If (RetCode <> 101) And (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(291, "", "Errore in estrazione dati giacenza (GET_LQUA).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(292, "", "Verificare filtri e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (RetCode = 101) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(788, "", "Nessuna giacenza trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(789, "", "Verificare giacenze e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (GetDataGiacenzeOk <> True) Or (clsTrasfMat.objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(375, "", "Nessuna Giacenza in STOCK con i FILTRI immessi.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsTrasfMat.objDataTableGiacenzeInfo.Rows.Count = 1) Then
                WorkDataRow = clsTrasfMat.objDataTableGiacenzeInfo.Rows(0)
                If (WorkDataRow Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(790, "", "Errore in estrazione dati Giacenza (objDataTableGiacenzeInfo.Rows(0)).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                'RECUPERO I DATI DELLA GIACENZA SELEZIONATA
                RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, WorkGiacenza, False)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(605, "", "Errore in estrazione dati Giacenza (FromLquaToWmGiacenza).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
                If (clsUser.SapWmsUser.PROFID = "") And (WorkGiacenza.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(787, "", "Il materiale non puo' essere trasferito dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'MEMORIZZO DATI GIACENZA NEI DATI DEL TRASFERIMENTO IN CORSO IMPOSTO I DATI DEL MATERIALE
                clsTrasfMat.MaterialeGiacenza = WorkGiacenza
                clsTrasfMat.SourceUbicazione = WorkGiacenza.UbicazioneInfo
                clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = WorkGiacenza.QtaTotaleLquaDispoUdMAcq
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
                Me.txtUbicazioneOrigine.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
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

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazioneOrigine.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me, Me.txtUbicazioneOrigine.Text, "", "", "", False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtUbicazioneOrigine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazioneOrigine.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUbicazioneOrigine.Text = "") Then Exit Sub

            Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtUM_Origine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM_Origine.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM_Origine.Text = "") Then Exit Sub

            Me.txtUM_Origine.Text = UCase(Me.txtUM_Origine.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

End Class