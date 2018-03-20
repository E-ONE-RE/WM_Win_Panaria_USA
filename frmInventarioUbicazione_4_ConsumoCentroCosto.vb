Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports System.Math

Public Class frmInventarioUbicazione_4_ConsumoCentroCosto

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmInventarioUbicazione_4_ConsumoCentroCosto"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmInventarioUbicazione_4_ConsumoCentroCosto_KeyPress(Me, e)

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


        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione


        Dim UserAnswer As DialogResult
        Dim OkEseguiOtInventario As Boolean = False
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim wkExitFormDone As Boolean = False
        Dim FlagErroreAttivo As Boolean
        Dim wkQtaConfermata As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE LA QTA E' CORRETTA
            If (Me.txtQtaConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(614, "", "Qtà Conteggiata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Me.txtQtaConfermata.Focus()
                Exit Sub
            End If

            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'NECESSARIO PER EVENTUALI DECIMALI
            wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
            If (wkQtaConfermata < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(615, "", "La Qtà deve essere positiva.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VERIFICO SE L'OPERATORE HA SPECIFICATO UNA MODIFICA DELLA QTA
            OkEseguiOtInventario = False

            If (clsInventarioUbicazione.ConfermataQtaConteggiata = False) Then
                'NEL TRASFERIMENTO PER INVENTARIO SEGNALO LA GIACENZA DIVERSA MA L'OPERATORE PUO' FORZARE A PROSEGUIRE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(623, "", "Inserita una Qtà da consumare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(624, "", "Proseguire con un movimento di consumo del CENTRO DI COSTO ? (Si/No)")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
                clsInventarioUbicazione.ConfermataQtaConteggiata = True
            End If
            '>>>> OTTENGO LA DIFFERENZA TRA LA GIACENZA E LA QTA CONTEGGIATA
            clsInventarioUbicazione.QtOtDaInventario = wkQtaConfermata
            OkEseguiOtInventario = True


            '***************************************************************************************
            '>>> SE HO CONFERMATO LE QTA NON DEVO ESEGUIRE NESSUN CAMBIAMENTO
            '***************************************************************************************
            If (OkEseguiOtInventario <> True) Or (clsInventarioUbicazione.QtOtDaInventario = 0) Then
                'MANDO IL MESSAGGIO CHE AVVISA OPERATORE DI S
                '>>>> SEGNALO CHE NON SI ESEGUE NESSUNA OPERAZIONE ESEGUITA
                ErrDescription = clsAppTranslation.GetSingleParameterValue(618, "", "ATTENZIONE!!! Nessuna rettifica eseguita.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(619, "", "Nessuna giacenza modificata.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                '>>> CHIEDO AD OPERATORE SE VUOLE PROSEGUIRE L'INVENTARIO DELLO STESSO OGGETTO
                RetCode = clsInventarioUbicazione.AskExecuteOtherInventorySameLocation(Me, wkExitFormDone)
                If (wkExitFormDone = True) Then
                    Exit Sub
                End If
            End If


            '**************************************************************************************************************
            '**************************************************************************************************************
            '>>> VERIFICO SE DEVO FARE ANCHE UN OT PER UN CONTEGGIO SUPERIORE ALLA GIACENZA PRELEVANDO DALL'INVENTARIO
            If (OkEseguiOtInventario = True) And (clsInventarioUbicazione.QtOtDaInventario <> 0) Then
                RetCode = clsInventarioUbicazione.ExecTrasferimentoPerInventario(Me, "", True, FlagErroreAttivo, ErrDescription)
            End If
            '**************************************************************************************************************
            '**************************************************************************************************************



            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmInventarioUbicazione_4_ConfQtaForm = New frmInventarioUbicazione_4_ConfQta
                    frmInventarioUbicazione_4_ConfQtaForm.Show()
                    frmInventarioUbicazione_4_ConfQtaForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            '******************************************************************************************
            '>>> CHIEDO AD OPERATORE SE VUOLE PROSEGUIRE L'INVENTARIO DELLO STESSO OGGETTO
            '******************************************************************************************
            RetCode = clsInventarioUbicazione.AskExecuteOtherInventorySameLocation(Me, wkExitFormDone)
            If (wkExitFormDone = True) Then
                Exit Sub
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmInventarioUbicazione_4_ConsumoCentroCosto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)
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

    Private Sub frmInventarioUbicazione_4_ConsumoCentroCosto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblCentroCosto.Text = clsAppTranslation.GetSingleParameterValue(130, lblCentroCosto.Text, "Centro Costo")
            txtQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(131, txtQtaConfermata.Text, "Qta Cons.")
            lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(69, lblUDMQuantita.Text, "Udm")

            Me.Text = clsAppTranslation.GetSingleParameterValue(128, Me.Text, "Invent.Ubicazione (4)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************  


            'VISUALIZZO INFO DATI GIACENZA
            Me.txtInfoJobSelezionato.Text = clsInventarioUbicazione.FromInventarioStructsToString(0)

            Me.txtUDMQuantità.Text = clsInventarioUbicazione.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            Select Case clsInventarioUbicazione.InventoryType
                Case clsInventarioUbicazione.EnumInventoryType.EnumInventoryTypeCentroCosto
                    Me.Text = clsAppTranslation.GetSingleParameterValue(625, "", "Consumo Centro Costo (4)")
                    Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(626, "", "Qtà Consumata")
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(599, "", "Tipo Inventario non corretto.(InventoryType)")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtQtaConfermata.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class