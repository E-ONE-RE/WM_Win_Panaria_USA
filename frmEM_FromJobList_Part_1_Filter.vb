Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmEM_FromJobList_Part_1_Filter

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromJobList_Part_1_Filter"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    If (Me.txtCodiceMateriale.Focused = True) Then
                        Me.cmdSelectCodiceMateriale_Click(Me, e)
                    Else
                        Me.cmdSelectPartitaMateriale_Click(Me, e)
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
        Dim GetDataOk As Boolean = False


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO EVENTUALI DATI OBBLIGATORI
            'If (Me.txtUnitaMagazzinoOrigine.Text = "") Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(373, "", "Unità Magazzino non corretta.")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            'IMPOSTO TUTTI I FILTRI IN MAIUSCOLO
            Me.cmbTipoMagazzino.Text = UCase(Me.cmbTipoMagazzino.Text)
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
            Me.txtPartitaMateriale.Text = UCase(Me.txtPartitaMateriale.Text)
            Me.txtSKU.Text = UCase(Me.txtSKU.Text)

            '***************************************************************
            ' >>> CHIAMO WS PER ESTRAZIONE ELENCO LISTE MISSIONI X OPERATORE
            '***************************************************************

            'MEMORIZZO FILTRI OPERATORI PER OPERAZIONI SUCCESSIVE RIPETUTE
            clsWmsJobsGroup.UserFilterGetList.CodiceMateriale = Me.txtCodiceMateriale.Text
            clsWmsJobsGroup.UserFilterGetList.Partita = Me.txtPartitaMateriale.Text
            clsWmsJobsGroup.UserFilterGetList.UbicazioneInfo.TipoMagazzino = Me.cmbTipoMagazzino.Text
            clsWmsJobsGroup.UserFilterGetList.SKU = Me.txtSKU.Text


            'FILTRO LE LISTE ASSEGNATE USANDO I FILTRI PASSATI DALL'OPERATORE
            RetCode = clsWmsJobsGroup.GetJobsGroupList("ENTRATA_MERCE", GetDataOk, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                If (RetCode = 101) Then
                    'CASO DI DATO NON TROVATO
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(478, "", "Nessun dato trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                Else
                    'ERRORE NEL CODICE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1221, "", "Errore in estrazione dati LISTE MISSIONI.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                End If
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_EntrataMerci_FromJob(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJobList_Part_1_Filter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

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

    Private Sub txtCodiceMateriale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceMateriale.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtCodiceMateriale.Text <> "") Then
                Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtPartitaMateriale_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartitaMateriale.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtPartitaMateriale.Text <> "") Then
                Me.txtPartitaMateriale.Text = UCase(Me.txtPartitaMateriale.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmbTipoMagazzino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoMagazzino.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.cmbTipoMagazzino.Text <> "") Then
                Me.cmbTipoMagazzino.Text = UCase(Me.cmbTipoMagazzino.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromJobList_Part_1_Filter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblTipoMagazzino.Text = clsAppTranslation.GetSingleParameterValue(80, Me.lblTipoMagazzino.Text, "Tipo Magazzino")
            Me.lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, Me.lblCodiceMateriale.Text, "Codice Materiale")
            Me.lblPartitaMateriale.Text = clsAppTranslation.GetSingleParameterValue(82, Me.lblPartitaMateriale.Text, "Partita Materiale")
            Me.Text = clsAppTranslation.GetSingleParameterValue(79, Me.Text, "EM - Lista(1)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


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

            Me.cmbTipoMagazzino.Items.Add("")
            If (DefaultEM_List_EnableFilterLgtyp_Z0S = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMagZ0S)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_901 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag901)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_902 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag902)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_903 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag903)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_904 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag904)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_905 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag905)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_910 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag910)
            End If
            If (DefaultEM_List_EnableFilterLgtyp_921 = True) Then
                Me.cmbTipoMagazzino.Items.Add(cstTipoMag921)
            End If

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
                Me.txtPartitaMateriale.Text = UCase(clsSelezionePartitaMateriale.CodicePartitaSelezionato)
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
End Class