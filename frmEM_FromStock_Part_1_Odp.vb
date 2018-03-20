Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmEM_FromStock_Part_1_Odp

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_1_Odp"


    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))


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

            RetCode = clsNavigation.Show_Mnu_Main_EntrataMerci(Me, True)

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
        Dim ChekOrdineOk As Boolean = False
        Dim DatiRicercaOdP As clsDataType.SapOrdineProduzione
        Dim WkUbicazione As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtNumOrdineProd.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(498, "", " non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtNumOrdineProd.Text = UCase(Me.txtNumOrdineProd.Text)

            'VERIFICO SE IL NUMERO DI ORDINE DI PRODUZIONE SPECIFICATO E' CORRETTO
            DatiRicercaOdP.NumeroOrdineProduzione = Me.txtNumOrdineProd.Text

            'CHIAMO WS PER VERIFICARE I DATI DEL NUMERO DI ORDINE DI PRODUZIONE IMMESSO
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_ODP(DatiRicercaOdP, "", clsUser.SapWmsUser.LANGUAGE, ChekOrdineOk, clsEMFromStock.OrdineProduzioneOrigine, SapFunctionError, True)
            If ((ChekOrdineOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(499, "", "OdP non definito nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'VERIFICO SE IL CODICE MATERIALE E' DEFINITO
            If (clsEMFromStock.OrdineProduzioneOrigine.CodiceMateriale = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(500, "", "Cod.Materiale OdP non definito nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IN QUESTO FLUSSO SI PONE COME ASSIOMA CHE CI SI RIFERISCE AL MATERIALE PRODOTTO DALL'ODP
            clsEMFromStock.MaterialeGiacenza.CodiceMateriale = clsEMFromStock.OrdineProduzioneOrigine.CodiceMateriale

            clsEMFromStock.SourceUbicazione.Divisione = clsUser.GetUserDivisionToUse()
            clsEMFromStock.SourceUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            clsEMFromStock.SourceUbicazione.TipoMagazzino = DefaultEM_Prod_Ori_TipoMag

            'L'UBICAZIONE E' = AL NUMERO ODP
            WkUbicazione = clsEMFromStock.OrdineProduzioneOrigine.NumeroOrdineProduzione
            RetCode = clsSapUtility.CheckUbicazioneString(WkUbicazione) 'VERIFICO LA LUNGHEZZA (MAX 10 CARATTERI)
            clsEMFromStock.SourceUbicazione.Ubicazione = WkUbicazione

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_1_Odp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtNumOrdineProd.Focused = True) And (Me.txtNumOrdineProd.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
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

    Private Sub frmEM_FromStock_Part_1_Odp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblPosDocMateriale.Text = clsAppTranslation.GetSingleParameterValue(90, lblPosDocMateriale.Text, "N° Ordine Di Produzione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(89, Me.Text, "EM - Produzione (1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************     


            '>>> LOGICA CARICO DATI ATTIVA SOLO SE NON HO APERTO LE VIDEATE DI PRESELEZIONE DATI
            If (clsUtility.IsStringValid(clsEMFromStock.OrdineProduzioneOrigine.NumeroOrdineProduzione, True) = True) Then
                'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
                'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
                Me.txtNumOrdineProd.Text = clsEMFromStock.OrdineProduzioneOrigine.NumeroOrdineProduzione
            Else
                '>>> LA PRIMA VOLTA VISUALIZZO I FILTRI DI DEFAULT
                Me.txtNumOrdineProd.Text = ""
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtNumOrdineProd.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class