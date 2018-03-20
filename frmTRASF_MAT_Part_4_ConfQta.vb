Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsSapUtility

Public Class frmTRASF_MAT_Part_4_ConfQta

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_MAT_Part_4_ConfQta"

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

            RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)


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
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim wkQtaConfermata As Double = 0
        Dim wkQtaConfermataSfusi As Double = 0
        Dim UserAnswer As DialogResult
        Dim DatiVerificaUnitaMagazzino As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim CheckUnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)
            Me.txtQtaSfusiConfermata.Text = UCase(Me.txtQtaSfusiConfermata.Text)

            If (Me.txtQtaConfermata.Text = "") And (Me.txtQtaSfusiConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtQtaConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaSfusiConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'NECESSARIO PER EVENTUALI DECIMALI
            If (Me.txtQtaConfermata.Text <> "") Then
                wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
                If (wkQtaConfermata < 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(795, "", "La Qtà Confermata deve essere positiva.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(568, "", "Verificare i dati immessi e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (Me.txtQtaSfusiConfermata.Text <> "") Then
                wkQtaConfermataSfusi = System.Convert.ToDouble(Me.txtQtaSfusiConfermata.Text)
                If (wkQtaConfermataSfusi <= 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If (wkQtaConfermata > clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.") & vbCrLf & "Qtà Dispo:" & clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (TrasfMatEnableWarningChangeQty = True) Then
                If (wkQtaConfermata <> clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(321, "", "Si desidera veramente confermare una QTA' diversa da quella disponibile ?") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
            End If

            '>>> SE HO CONFERMATO TUTTA LA QTA E HO UNA PALLET ID ALLORA VERIFICO SE STO TRASFERENDO TUTTA LA PALLETTA
            CheckUnitaMagazzinoOk = False
            If (wkQtaConfermata = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) And (clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino <> "") Then
                RetCode = clsSapUtility.ResetGiacenzaStruct(DatiVerificaUnitaMagazzino)
                RetCode = clsSapUtility.ResetGiacenzaStruct(WorkGiacenzaUM)
                DatiVerificaUnitaMagazzino.CodiceMateriale = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
                DatiVerificaUnitaMagazzino.Partita = clsTrasfMat.MaterialeGiacenza.Partita
                DatiVerificaUnitaMagazzino.UnitaDiMisuraBase = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraBase
                DatiVerificaUnitaMagazzino.QuantitaConfermataOperatore = wkQtaConfermata
                DatiVerificaUnitaMagazzino.UnitaDiMisuraAcquisizione = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione
                DatiVerificaUnitaMagazzino.UbicazioneInfo.Divisione = clsTrasfMat.SourceUbicazione.Divisione
                DatiVerificaUnitaMagazzino.UbicazioneInfo.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
                DatiVerificaUnitaMagazzino.UbicazioneInfo.UnitaMagazzino = clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(DatiVerificaUnitaMagazzino, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, Nothing, False, False, False, Nothing, SapFunctionError, False)
                If (CheckUnitaMagazzinoOk = True) And (WorkGiacenzaUM.PickSUCompleto = True) Then
                    clsTrasfMat.MaterialeGiacenza.PickSUCompleto = WorkGiacenzaUM.PickSUCompleto
                End If
            End If

            'IMPOSTO QTA CONFERMATA DELL'OPERATORE = A QUELLA DISPONIBILE
            clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = wkQtaConfermata
            clsTrasfMat.MaterialeGiacenza.QuantitaConfermataSfusiOperatore = wkQtaConfermataSfusi

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_MAT_Part_4_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtQtaConfermata.Text = UCase(Me.txtQtaConfermata.Text)
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

    Private Sub frmTRASF_MAT_Part_4_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblQtaInStock.Text = clsAppTranslation.GetSingleParameterValue(67, Me.lblQtaInStock.Text, "Qta Prev.")
            Me.lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, Me.lblUDMQuantita.Text, "UdM")
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(184, Me.lblQtaConfermata.Text, "Quantità")
            Me.lblQtaSfusiConfermata.Text = clsAppTranslation.GetSingleParameterValue(1461, Me.lblQtaSfusiConfermata.Text, "Sfusi")
            Me.Text = clsAppTranslation.GetSingleParameterValue(194, Me.Text, "TRASF - Mat. (4)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************


            Me.txtInfoJobSelezionato.Text = clsTrasfMat.FromTrasfMatStrucToString(1)

            Me.txtQtaInStock.Text = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            Me.txtUDMQuantità.Text = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            'VISUALIZZO DATI QTA
            If (clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore > 0) Then
                Me.txtQtaConfermata.Text = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore
            Else
                Me.txtQtaConfermata.Text = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            End If

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