
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmTRASF_UBI_Part_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_UBI_Part_1"

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

    Private Sub frmTRASF_UBI_Part_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_UBI_Part_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(124, lblUbicazioneOrigine.Text, "Ubicazione Origine")

            Me.Text = clsAppTranslation.GetSingleParameterValue(198, Me.Text, "TRASF - Ubi. (1)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '************************************** 

            clsTrasfUbi.SourceUbicazione.Divisione = clsUser.GetUserDivisionToUse()
            clsTrasfUbi.SourceUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()

            If (clsTrasfUbi.SourceUbicazione.Ubicazione <> "") Then
                Me.txtUbicazioneOrigine.Text = clsTrasfUbi.SourceUbicazione.Ubicazione
            End If


            'NEL CASO DI TRASFERIMENTO PER INVENTARIO PASSO SUBITO AL SECONDO STEP
            Me.txtUbicazioneOrigine.Focus()
            
            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

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




        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False
        Dim WorkDataRow As DataRow
        Dim WorkIndiceLoop As Integer = 0
        Dim NumUdcUbicazione As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneOrigine.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(785, "", "Specificare una Ubicazione o una Unità di Magazzino") & clsAppTranslation.GetSingleParameterValue(786, "", "o un Codice Materiale.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneOrigine.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneOrigine.Text = WorkOutUbicazione


            '*************************************************************************
            '>>> SE NON GESTISCO L'INSERIMENTO DEL CODICE MATERIALE DEVO CARICARE
            '>>> LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfUbi.ClearGiacenzeInfo() 'init

            'IMPOSTO SOLO LA BASE PER LA RICERCA
            WorkUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            WorkUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            WorkUbicazione.Ubicazione = Me.txtUbicazioneOrigine.Text

            WorkGiacenza.UbicazioneInfo = WorkUbicazione

            'VERIFICO LE GIACENZE DELLO STESSO MATERIALE SE POSSO AVERE AMBIGUITA
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, 0, clsUser.SapWmsUser.LANGUAGE, GetDataGiacenzeOk, clsTrasfUbi.objDataTableGiacenzeInfo, Nothing, NumUdcUbicazione, Nothing, Nothing, SapFunctionError, False)
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
            If (GetDataGiacenzeOk <> True) Or (clsTrasfUbi.objDataTableGiacenzeInfo Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(293, "", "Giacenza non presente in STOCK.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(294, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (clsTrasfUbi.objDataTableGiacenzeInfo.Rows.Count <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(375, "", "Nessuna Giacenza in STOCK con i FILTRI immessi.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(394, "", "Verificare dati e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            WorkIndiceLoop = 0
            'MEMORIZZO DATI GIACENZA NEI DATI DEL TRASFERIMENTO IN CORSO IMPOSTO I DATI DEL MATERIALE
            For Each WorkDataRow In clsTrasfUbi.objDataTableGiacenzeInfo.Rows

                WorkDataRow = clsTrasfUbi.objDataTableGiacenzeInfo.Rows(WorkIndiceLoop)

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
                If (clsUser.SapWmsUser.PROFID = "ADMIN") And (WorkGiacenza.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(787, "", "Il materiale non puo' essere trasferito dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'MEMORIZZO DATI GIACENZA NEI DATI DEL TRASFERIMENTO IN CORSO IMPOSTO I DATI DEL MATERIALE
                ReDim Preserve clsTrasfUbi.GiacenzeTrasfList(WorkIndiceLoop)
                clsTrasfUbi.GiacenzeTrasfList(WorkIndiceLoop) = WorkGiacenza

                WorkIndiceLoop += 1

                'MEMORIZZO I DATI DELL'UBICAZIONE DI ORIGINE
                If (WorkIndiceLoop = 1) Then
                    clsTrasfUbi.SourceUbicazione = WorkGiacenza.UbicazioneInfo
                    clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione = NumUdcUbicazione
                End If

            Next


            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_TRASF_UBI(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


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

End Class