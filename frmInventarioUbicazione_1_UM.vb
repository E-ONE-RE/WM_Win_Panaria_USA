
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmInventarioUbicazione_1_UM

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInventarioUbicazione_1_UM"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInventarioUbicazione_1_UM_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_1_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUnitaMagazzino.Focused = True) And (Me.txtUnitaMagazzino.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUnitaMagazzino.Text = UCase(Me.txtUnitaMagazzino.Text)
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

    Private Sub frmInventarioUbicazione_1_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(5, lblUnitaMagazzino.Text, "Unita Magazzino")

            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")

            Me.Text = clsAppTranslation.GetSingleParameterValue(123, Me.Text, "Invent.Ubicazione (1))")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************  


            If (clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino <> "") Then
                Me.txtUnitaMagazzino.Text = clsInventarioUbicazione.SourceUbicazione.UnitaMagazzino
            End If

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUbicazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(123, "", "Invent.Ubicazione (1)")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeUnitaMagazzino
                    Me.Text = clsAppTranslation.GetSingleParameterValue(593, "", "Invent.Unita Mag. (1)")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeRottamazione
                    Me.Text = clsAppTranslation.GetSingleParameterValue(585, "", "Invent.Rottamazione(1)")
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                    Me.Text = clsAppTranslation.GetSingleParameterValue(586, "", "Invent.CentroCosto(1)")
            End Select

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtUnitaMagazzino.Focus()

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ChekUbicazioneOk As Boolean = False
        Dim DatiRicercaGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenza As clsDataType.SapWmGiacenza
        Dim InfoGiacenzaFree() As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False

        Dim UnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA UNITA' DI MAGAZZINO SPECIFICATA E' CORRETTA
            If (Me.txtUnitaMagazzino.Text = "") And (Me.txtSKU.Text = "") And (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1685, "", "Unità Magazzino, Codice SKU o Cod. Materiale specificato non corretto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Me.txtUnitaMagazzino.Text = UCase(Me.txtUnitaMagazzino.Text)
            Me.txtSKU.Text = UCase(Me.txtSKU.Text)
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)


            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUnitaMagazzino.Text, UnitaMagazzinoOk, True)
            If (UnitaMagazzinoOk = False) Then
                Exit Sub
            End If

            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            clsSapUtility.ResetGiacenzaStruct(DatiRicercaGiacenza)
            DatiRicercaGiacenza.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse()
            DatiRicercaGiacenza.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse
            DatiRicercaGiacenza.UbicazioneInfo.UnitaMagazzino = Me.txtUnitaMagazzino.Text
            DatiRicercaGiacenza.SKU = Me.txtSKU.Text
            DatiRicercaGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text


            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiRicercaGiacenza, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, ChekUbicazioneOk, InfoGiacenza, InfoGiacenzaFree, False, False, False, Nothing, SapFunctionError, False)
            If (ChekUbicazioneOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(590, "", "Ubicazione Origine non definita  nel sistema. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO LE OPERAZIONI DI INVENTARIO NELLA ZONA DI PRONTO
            If (clsUser.SapWmsUser.PROFID = "") And (InfoGiacenza.UbicazioneInfo.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(591, "", "Non possibile operazione di inventario nel TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'MEMORIZZO L'UBICAZIONE NEI DATI DEL TRASFERIMENTO IN CORSO
            clsInventarioUbicazione.SourceUbicazione = InfoGiacenza.UbicazioneInfo

            '*******************************************************************************************
            '>>> ESTRAGGO LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO)
            '*******************************************************************************************
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = clsUser.GetUserDivisionToUse()
            WorkUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse
            If (Me.txtUnitaMagazzino.Text <> "") Then
                WorkUbicazione = clsInventarioUbicazione.SourceUbicazione
            End If
            If (Me.txtSKU.Text <> "") Or (Me.txtCodiceMateriale.Text <> "") Then
                WorkGiacenza.SKU = Me.txtSKU.Text
                WorkGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text
            End If
            RetCode = clsInventarioUbicazione.GetStockGiacenzaInfo(WorkUbicazione, WorkGiacenza, True, GetDataGiacenzeOk)
            If (RetCode <> 0) Or (GetDataGiacenzeOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(592, "", "Giacenza non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

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
                Me.txtUnitaMagazzino.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
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
    Private Sub txtUbicazioneOrigine_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitaMagazzino.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUnitaMagazzino.Text = "") Then Exit Sub

            Me.txtUnitaMagazzino.Text = UCase(Me.txtUnitaMagazzino.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class