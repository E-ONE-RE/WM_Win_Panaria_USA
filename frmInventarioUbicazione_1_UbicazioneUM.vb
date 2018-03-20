
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility

Public Class frmInventarioUbicazione_1_UbicazioneUM

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInventarioUbicazione_1_UbicazioneUM"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInventarioUbicazione_1_UbicazioneUM_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_1_UbicazioneUM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneOrigine.Focused = True) And (Me.txtUbicazioneOrigine.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtUnitaMagazzino.Focused = True) And (Me.txtUnitaMagazzino.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUnitaMagazzino.Text = UCase(Me.txtUnitaMagazzino.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.F4)) Then
                'SU F4 SIMULO MATCH CODE DI SAP
                Call Me.cmdSelectUbicazione_Click(Me, e)
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_1_UbicazioneUM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim DefaultDivisione As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblDivisione.Text = clsAppTranslation.GetSingleParameterValue(6, lblDivisione.Text, "Divisione")
            lblNumMag.Text = clsAppTranslation.GetSingleParameterValue(119, lblNumMag.Text, "Num.Mag.")
            lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(124, lblUbicazioneOrigine.Text, "Ubicazione Origine")
            lblUnitaMagazzino.Text = clsAppTranslation.GetSingleParameterValue(5, lblUnitaMagazzino.Text, "Unita magazzino")
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(81, lblCodiceMateriale.Text, "Codice Materiale")

            Me.Text = clsAppTranslation.GetSingleParameterValue(123, Me.Text, "Invent.Ubicazione (1)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If


            '**************************************  


            DefaultDivisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            If (clsUtility.IsStringValid(DefaultDivisione, True) = False) Then
                DefaultDivisione = Default_Inventario_Ori_Divisione
            End If

            RetCode += clsUtility.FillComboFromStringArray(Me.txtDivisione, DivisioniAvailable, DefaultDivisione)
            RetCode += clsUtility.FillComboFromStringArray(Me.txtNumMag, NumMagAvailable, clsUser.GetUserNumeroMagazzinoToUse())

            If (clsInventarioUbicazione.SourceUbicazione.Ubicazione <> "") Then
                Me.txtUbicazioneOrigine.Text = clsInventarioUbicazione.SourceUbicazione.Ubicazione
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
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataGiacenzeOk As Boolean = False
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneOrigine.Text = "") And (Me.txtUnitaMagazzino.Text = "") And (Me.txtSKU.Text = "") And (Me.txtCodiceMateriale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1565, "", "Specificare una Ubicazione o una Unità Magazzino o un Codice SKU")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneOrigine.Text = UCase(Me.txtUbicazioneOrigine.Text)
            Me.txtUnitaMagazzino.Text = UCase(Me.txtUnitaMagazzino.Text)
            Me.txtSKU.Text = UCase(Me.txtSKU.Text)
            Me.txtCodiceMateriale.Text = UCase(Me.txtCodiceMateriale.Text)


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneOrigine.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneOrigine.Text = WorkOutUbicazione


            'ESEGUO RESET DELL'UBICAZIONE DI ORIGINE
            clsSapUtility.ResetUbicazioneStruct(clsInventarioUbicazione.SourceUbicazione)

            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            If (clsUtility.IsStringValid(Me.txtUbicazioneOrigine.Text, True) = True) Then
                clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
                If (clsUtility.IsStringValid(Me.txtDivisione.Text, True) = True) Then
                    DatiRicercaUbicazione.Divisione = UCase(Me.txtDivisione.Text)
                End If
                If (clsUtility.IsStringValid(Me.txtNumMag.Text, True) = True) Then
                    DatiRicercaUbicazione.NumeroMagazzino = UCase(Me.txtNumMag.Text)
                End If
                DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneOrigine.Text
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
                If (ChekUbicazioneOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(590, "", "Ubicazione Origine non definita  nel sistema. Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'MEMORIZZO L'UBICAZIONE NEI DATI DEL TRASFERIMENTO IN CORSO
                clsInventarioUbicazione.SourceUbicazione = InfoUbicazione

                'SE L'OPERATORE E' UNO USER NORMALE GLI IMPEDISCO LE OPERAZIONI DI INVENTARIO NELLA ZONA DI PRONTO
                If (clsUser.SapWmsUser.PROFID = "") And (InfoUbicazione.TipoMagazzino = clsSapUtility.cstSapTipoMagPronto) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(591, "", "Non possibile operazione di inventario nel TIP.MAG:Pronto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '*************************************************************************************************
            '>>> ESTRAGGO LE GIACENZE CHE CORRISPONDONO AI FILTRI IMMESSI (UBICAZIONE / UNITA MAGAZZINO / SKU)
            '*************************************************************************************************
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione = clsInventarioUbicazione.SourceUbicazione
            WorkUbicazione.Divisione = clsUser.GetUserDivisionToUse()
            WorkUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            WorkUbicazione.UnitaMagazzino = Me.txtUnitaMagazzino.Text
            WorkGiacenza.SKU = Me.txtSKU.Text
            WorkGiacenza.CodiceMateriale = Me.txtCodiceMateriale.Text

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