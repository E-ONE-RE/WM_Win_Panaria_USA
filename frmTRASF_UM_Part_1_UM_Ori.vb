Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmTRASF_UM_Part_1_UM_Ori

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_UM_Part_1_UM_Ori"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private UdMTrasfListIndex As Integer = 0


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

            'RITORNO AL MENU DI PARTENZA
            RetCode = clsTrasfMat.Go_To_Original_Menu(Me)

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


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'DEVO AVERE SPECIFICATO ALMENO UNA UNITA MAGAZZINO DA TRASFERIRE
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                If (clsTrasfMat.UdMTrasfList Is Nothing) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub

                Else
                    If (clsTrasfMat.UdMTrasfList.GetLength(0) <= 0) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If

            'SE DIGITATO UN BARCODE LO PROCESSO CON IL PULSANTE DI "OK"
            If (Me.txtUM.Text <> "") Then
                Call cmdOK_Click(sender, e)
            End If


            If (clsTrasfMat.UdMTrasfList Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtUM.Text = ""
                Exit Sub
            End If

            If Not (clsTrasfMat.UdMTrasfList Is Nothing) Then
                If (clsTrasfMat.UdMTrasfList.GetLength(0) <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtUM.Text = ""
                    Exit Sub
                End If
            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_TRASF_UnitaMagazzino(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_UM_Part_1_UM_Ori_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUM.Focused = True) And (Me.txtUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM.Text = UCase(Me.txtUM.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdOK_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdOK.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
                    Call Me.cmdOK_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE BARCODE
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

    Private Sub frmTRASF_UM_Part_1_UM_Ori_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.lblUM.Text = clsAppTranslation.GetSingleParameterValue(201, lblUM.Text, "UM Da Trasferire")

            Me.Text = clsAppTranslation.GetSingleParameterValue(200, Me.Text, "TRASF - Unità Mag.(1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdOK.Text = clsAppTranslation.GetSingleParameterValue(8, cmdOK.Text, "OK")

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************     


            'NEL CASO DI BACK VISUALIZZO I DATI CHE ERANO STATI IMPOSTATI
            'IN CASO DI PRIMO LOAD CARICO I DATI DI DEFAULT
            Me.txtUM.Text = ""

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'NEL CASO DI "BACK" DEVO RIVISUALIZZARE LE UM CHE ERANO STATO IMMESSE
            Call RefreshDatiMaterialeAttivo()

            Me.txtUM.Focus()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUM.Text <> "") Then
                Me.txtUM.Text = UCase(Me.txtUM.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim DatiRicercaUbicazione As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim UnitaMagazzinoOk As Boolean = False
        Dim i As Integer = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE HO SPECIFICATO UN CODICE VALIDO DI UNITA MAGAZZINO
            '***********************************************************************************************
            If (Me.txtUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Me.txtUM.Text = UCase(Me.txtUM.Text)

            Me.txtUM.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtUM.Text)


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Me.txtUM.Text = ""
                Exit Sub
            End If

            'VERIFICO DI NON AVER GIA' SELEZIONATO L'UNITA' DI MAGAZZINO
            If (UdMTrasfListIndex > 0) Then
                For i = 0 To UdMTrasfListIndex - 1
                    If (clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.UdMTrasfList(i).UbicazioneInfo.UnitaMagazzino) = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(Me.txtUM.Text)) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1178, "", "L'Unita Magazzino specificata è già stata selezionata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next

                'NEL CASO DI RI-ETICHETTATURA DELLA UNITA DI MAGAZZINO NE DEVO LEGGERE SOLO UNA ( UN UNICO BC )
                If (clsTrasfMat.FunctionTransferMaterialType = clsDataType.FunctionTransferMaterialType.FunctionTransferMaterialTypeForUMChangeLabel) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1194, "", "Per RI-ETICHETTARE leggere solo una singola Unita Magazzino.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'VERIFICO SE L'UNITA MAGAZZINO E' CORRETTA
            RetCode = clsSapUtility.ResetGiacenzaStruct(DatiRicercaUbicazione)
            DatiRicercaUbicazione.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaUbicazione.UbicazioneInfo.UnitaMagazzino = Me.txtUM.Text
            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaUbicazione, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, False, False, False, Nothing, SapFunctionError, False)
            If (CheckUnitaMagazzinoOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(501, "", "L'Unita Magazzino specificata non è definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO DI SPOSTARE LE PALLETTE DALLA ZONA DI PRONTO
            If (clsUser.SapWmsUser.PROFID <> "ADMIN") And (WorkGiacenzaUM.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(502, "", "L'Unita Magazzino non puo' essere trasferita dal TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PULISCO CASELLA DATA ENTRY PER IMMISSIONE NUOVA UM
            Me.txtUM.Text = ""
            Me.txtUM.Focus()

            'AGGIUNGO L'UdM SELEZIONATA COME NUOVO ELEMENTO DELL'ARRAY DELLA CLASSE clsTrasfUnitaMagazzino
            ReDim Preserve clsTrasfMat.UdMTrasfList(UdMTrasfListIndex)
            clsTrasfMat.UdMTrasfList(UdMTrasfListIndex) = WorkGiacenzaUM

            'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
            Call RefreshDatiMaterialeAttivo()

            UdMTrasfListIndex += 1


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Function RefreshDatiMaterialeAttivo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoOperazioneUtente.Text = ""

            If (clsTrasfMat.UdMTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsTrasfMat.UdMTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & Trim(Str(clsTrasfMat.UdMTrasfList.GetLength(0)))

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            For Each WorkSapWmGiacenza In clsTrasfMat.UdMTrasfList
                Me.txtInfoOperazioneUtente.Text += clsTrasfMat.ShowTransferSingleUMInfo(WorkSapWmGiacenza, Nothing, 0) & vbCrLf
            Next

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub
End Class