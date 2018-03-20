Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmInfoDisponibilitaMateriale_1

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInfoDisponibilitaMateriale_1"


    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private DivisioneSelected As String = ""

    Public Function ConfermaSelezioneDivisione() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneDivisione = 1 'init at error

            Me.Focus()

            If (Me.txtDivisione.Text <> "CP02") Then
                RetCode += clsUtility.FillComboFromStringArray(Me.txtMagazzino, MagazziniLogiciAvailable01, "", True)
            Else
                RetCode += clsUtility.FillComboFromStringArray(Me.txtMagazzino, MagazziniLogiciAvailable02, "", True)
            End If

            ConfermaSelezioneDivisione = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    If cmdSelectCodiceMateriale.Focused Then
                        cmdSelectCodiceMateriale_Click(Me, e)
                    Else
                        cmdSelectPartitaMateriale_Click(Me, e)
                    End If

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

            RetCode = clsNavigation.Show_Mnu_Main_Informazioni(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNone, True)

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
        Dim GetOk As Boolean = False
        Dim VisualizzaDettaglio As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE IL CODICE SPECIFICATO E' CORRETTO
            If (Me.txtCodiceMateriale.Text = "") And (Me.txtPartita.Text = "") And (Me.txtSKU.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (InStr(1, Me.txtCodiceMateriale.Text, "*") > 0) Then
                If (Len(Me.txtCodiceMateriale.Text) < 6) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(529, "", "Per velocizzare la ricerca inserire almeno 6 caratteri.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            Me.txtCodiceMateriale.Text = Trim(UCase(Me.txtCodiceMateriale.Text))
            Me.txtPartita.Text = UCase(Me.txtPartita.Text)
            Me.txtMagazzino.Text = UCase(Me.txtMagazzino.Text)
            Me.txtSKU.Text = UCase(Me.txtSKU.Text)

            clsInfoDisponibilitaMateriale.FilterCodiceMateriale = Me.txtCodiceMateriale.Text
            'clsInfoDisponibilitaMateriale.FilterDivisione = UCase(DefaultInfoAnaMateriale_Divisione)
            If (clsUtility.IsStringValid(Trim(Me.txtDivisione.Text), True) = True) Then
                clsInfoDisponibilitaMateriale.FilterDivisione = UCase(Me.txtDivisione.Text)
            Else
                clsInfoDisponibilitaMateriale.FilterDivisione = ""
            End If

            clsInfoDisponibilitaMateriale.FilterPartitaMateriale = Me.txtPartita.Text
            clsInfoDisponibilitaMateriale.FilterMagazzinoLogico = Me.txtMagazzino.Text

            clsInfoDisponibilitaMateriale.FilterSKU = Me.txtSKU.Text


            'CHIAMO WS PER RECUPERARE I DATI
            RetCode = clsSapWS.Call_ZWS_MB_GET_MATERIAL_DISPONIBILITA(clsInfoDisponibilitaMateriale.FilterCodiceMateriale, clsInfoDisponibilitaMateriale.FilterDivisione, clsInfoDisponibilitaMateriale.FilterPartitaMateriale, clsInfoDisponibilitaMateriale.FilterMagazzinoLogico, clsInfoDisponibilitaMateriale.FilterSKU, clsUser.SapWmsUser.LANGUAGE, GetOk, clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo, SapFunctionError, False)
            If ((GetOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(544, "", "Dati disponibilita' materiale non trovati.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(545, "", "Verificare il codice immesso e la partita e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE HO RECUPERATO SOLO UN DATO VISUALIZZO DIRETTAMENTE LA FINESTRA DI DETTAGLIO
            VisualizzaDettaglio = False 'INIT
            If (Not clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo Is Nothing) Then
                If (clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.Rows.Count = 1) Then
                    VisualizzaDettaglio = True
                End If
            End If

            If (VisualizzaDettaglio = True) Then
                'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                clsInfoDisponibilitaMateriale.objDetailsDataRow = clsInfoDisponibilitaMateriale.objDataTableDispoMaterialeInfo.Rows(0)
                clsInfoDisponibilitaMateriale.RefreshDateTableDetailsInfo()

                'PASSO ALLO VIDEATA DI DETTAGLIO
                Call clsNavigation.Show_Info_Disponibilita_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDetails, True)
            Else
                'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
                Call clsNavigation.Show_Info_Disponibilita_Materiale(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInfoDisponibilitaMateriale_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceMateriale.Focused = True) And (Me.txtCodiceMateriale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
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

    Private Sub frmInfoDisponibilitaMateriale_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")
            lblPartita.Text = clsAppTranslation.GetSingleParameterValue(1, lblPartita.Text, "Partita")
            lblDivisione.Text = clsAppTranslation.GetSingleParameterValue(6, lblDivisione.Text, "Divisione")
            lblMagazzino.Text = clsAppTranslation.GetSingleParameterValue(117, lblMagazzino.Text, "Magazzino")

            Me.Text = clsAppTranslation.GetSingleParameterValue(65, Me.Text, "Info Dispo. Materiale(1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

#If Not APPLICAZIONE_WIN32 = "SI" Then
		    cmdSelectCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectCodiceMateriale.Text, "...")
			cmdSelectPartitaMateriale.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectPartitaMateriale.Text, "...")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectCodiceMateriale.Text, "...")
            cmdSelectPartitaMateriale.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectPartitaMateriale.Text, "...")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************    


            DivisioneSelected = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            If (clsUtility.IsStringValid(DivisioneSelected, True) = False) Then
                DivisioneSelected = DefaultInfoDisponibilita_Divisione
            End If

            RetCode += clsUtility.FillComboFromStringArray(Me.txtDivisione, DivisioniAvailable, DivisioneSelected, True)

            'ADATTO LA COMBO DEL MAGAZZINO IN BASE ALLA DIVISIONE SCELTA
            RetCode += ConfermaSelezioneDivisione()
            '            RetCode += clsUtility.FillComboFromStringArray(Me.txtMagazzino, MagazziniLogiciAvailable, "", True)

            'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
            Me.txtCodiceMateriale.Text = clsInfoDisponibilitaMateriale.FilterCodiceMateriale
            Me.txtPartita.Text = clsInfoDisponibilitaMateriale.FilterPartitaMateriale

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'IMPOSTO IL CONTROLLO ATTIVO
            If (Me.txtCodiceMateriale.Text = "") Then
                Me.txtCodiceMateriale.Focus()
            Else
                Me.cmdNextScreen.Focus()
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectCodiceMateriale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectCodiceMateriale.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            If (Len(Me.txtCodiceMateriale.Text) < 5) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(532, "", "Per velocizzare la ricerca inserire almeno 5 caratteri.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            clsSelezioneCodiceMateriale.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneCodiceMateriale.FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            clsSelezioneCodiceMateriale.FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE

            clsSelezioneCodiceMateriale.FilterTipiMag = ""
            clsSelezioneCodiceMateriale.FilterUbicazione = ""
            clsSelezioneCodiceMateriale.FilterCodiceMateriale = Me.txtCodiceMateriale.Text
            If (InStr(1, clsSelezioneCodiceMateriale.FilterCodiceMateriale, "*") = 0) Then
                clsSelezioneCodiceMateriale.FilterCodiceMateriale += "*"
            End If

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
                Me.txtCodiceMateriale.Text = clsSelezioneCodiceMateriale.CodiceMaterialeSelezionato
                Me.cmdNextScreen.Focus()
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
    Public Function ConfermaSelezionePartitaMateriale() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezionePartitaMateriale = 1 'init at error

            Me.Focus()
            If (clsSelezionePartitaMateriale.CodicePartitaSelezionato <> "") Then
                Me.txtPartita.Text = UCase(clsSelezionePartitaMateriale.CodicePartitaSelezionato)
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezionePartitaMateriale = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub txtCodiceMateriale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceMateriale.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtCodiceMateriale.Text = "") Then Exit Sub

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectPartitaMateriale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectPartitaMateriale.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(504, "", "Codice Materiale non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(533, "", "Impostare prima un codice materiale.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)


            clsSelezionePartitaMateriale.ClearAllData() 'INIT

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezionePartitaMateriale.FilterDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            clsSelezionePartitaMateriale.FilterNumMag = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE

            clsSelezionePartitaMateriale.FilterTipiMag = ""
            clsSelezionePartitaMateriale.FilterUbicazione = ""
            clsSelezionePartitaMateriale.FilterCodiceMateriale = Me.txtCodiceMateriale.Text

            RetCode = clsSelezionePartitaMateriale.SelezionaElemento(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub
End Class