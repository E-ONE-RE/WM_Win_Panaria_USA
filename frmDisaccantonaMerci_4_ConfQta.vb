Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms

Public Class frmDisaccantonaMerci_4_ConfQta

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmDisaccantonaMerci_4_ConfQta"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmDisaccantonaMerci_4_ConfQta_KeyPress(Me, e)

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


    Private Sub frmDisaccantonaMerci_4_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Call cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    Call cmdNextScreen_Click(Me, e)
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

    Private Sub frmDisaccantonaMerci_4_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkQtàPrevista As Double = 0
        Dim QtaRimastaDaPrelevareSfusi As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.ckboxFlagForcedStepEnded.Text = clsAppTranslation.GetSingleParameterValue(66, Me.ckboxFlagForcedStepEnded.Text, "Fine")
            Me.lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(67, Me.lblQtaPrevista.Text, "Qta Prev.")
            Me.lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, Me.lblUDMQuantita.Text, "UdM")
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(169, Me.lblQtaConfermata.Text, "Qtà Conf.")
            Me.Text = clsAppTranslation.GetSingleParameterValue(250, Me.Text, "Disaccant.(4)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
			cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, cmdNextScreen.Text, ">")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, cmdNextScreen.Text, ">")
#End If

            '**************************************       


            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, False)

            'VISUALIZZO UBICAZIONE ORIGINE
            RetCode = clsWmsJob.GetJobPickOriQtyProposal(WorkQtàPrevista, Nothing)
            If (RetCode = 0) Then

                If WorkQtàPrevista < 0 Then
                    WorkQtàPrevista = 0
                End If

                QtaRimastaDaPrelevareSfusi = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

                If QtaRimastaDaPrelevareSfusi < 0 Then
                    QtaRimastaDaPrelevareSfusi = 0
                End If

                Me.txtQtaPrevista.Text = Int(WorkQtàPrevista)
                Me.txtQtaSfusiPrevista.Text = Int(QtaRimastaDaPrelevareSfusi)

            End If


            Me.txtUDMQuantità.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            Me.txtQtaConfermata.Text = Int(WorkQtàPrevista) 'Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore)

            Me.txtUDMSfusiQuantità.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo
            Me.txtQtaSfusiConfermata.Text = Int(QtaRimastaDaPrelevareSfusi) 'Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore)


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

    Private Sub cmdPreviousScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviousScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, Nothing, True)

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
        Dim CheckStockOk As Boolean = False
        Dim CheckMatnrOk As Boolean = False
        Dim WorkDatiRicercaStock As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenza As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeAll() As clsDataType.SapWmGiacenza
        Dim WorkDatiGiacenzeFree() As clsDataType.SapWmGiacenza
        Dim WorkSapFunctionError As clsBusinessLogic.SapFunctionError
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataOk As Boolean = False
        Dim QtaRimastaDaPrelevare As Double
        Dim QtaRimastaDaPrelevareSfusi As Double
        Dim wkFlagOnlyFullPalletActive As Boolean = False
        Dim wkCheckQtyOkForFullPalletActive As Boolean = False
        Dim UserAnswer As DialogResult
        Dim QtaScatoleInPezzi As Double
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Me.txtQtaConfermata.Text = "") And (Me.txtQtaSfusiConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtQtaConfermata.Text <> "") Then
                If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
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


            If (Me.txtQtaConfermata.Text <> "") Then
                If (Val(Me.txtQtaConfermata.Text) > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(383, "", "Qtà Dispo:") & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'RECUPERO LE INFO SUL POSTO OTTIMALE DI PRELIEVO DELLA MERCE
            QtaRimastaDaPrelevare = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq)
            If (Val(Me.txtQtaConfermata.Text) > QtaRimastaDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            QtaRimastaDaPrelevare = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna)
            If (Val(Me.txtQtaConfermata.Text) > QtaRimastaDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '???? VERIFICA SE NON SUPERO LA QTA IN PEZZI
            QtaRimastaDaPrelevareSfusi = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ)
            If (Val(Me.txtQtaSfusiConfermata.Text) > QtaRimastaDaPrelevareSfusi) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            QtaRimastaDaPrelevareSfusi = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMPezzo)
            If (Val(Me.txtQtaSfusiConfermata.Text) > QtaRimastaDaPrelevareSfusi) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*********************************************************************************
            '>>> SE ARRIVO QUI LA QTA INSERITA E' OK PER PROSEGUIRE
            '*********************************************************************************


            'Modifica per portare tutte le quatità in Pezzi di Base se gestione CT + PC ... risoluzione problema qtà missione prelevata non completa

            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore = Val(Me.txtQtaSfusiConfermata.Text)

            If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione <> clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraPezzo) And (Val(Me.txtQtaConfermata.Text) > 0) Then

                QtaScatoleInPezzi = Val(Me.txtQtaConfermata.Text) * clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.PezziPerScatola

                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataSfusiOperatore = QtaScatoleInPezzi + Val(Me.txtQtaSfusiConfermata.Text)

                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = 0

            Else

                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore = Val(Me.txtQtaConfermata.Text)

            End If



            'RetCode = clsWmsJob.SetJobPickQtyMaterialGiacenzaOri(Val(Me.txtQtaConfermata.Text), Me.ckboxFlagForcedStepEnded.Checked)
            'If (RetCode <> 0) Then
            '    ErrDescription = clsAppTranslation.GetSingleParameterValue(386, "", "Errore in impostazione Qtà Confermata.") & vbCrLf & "[SetJobPickQtyMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
            '    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If

            RetCode = clsWmsJob.GetJobPickingBestDestination(True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(387, "", "Errore in elaborazione destinazione.") & vbCrLf & "[GetJobPickingBestDestination]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IN BASE AL CONTESTO PROSEGUO NEL WIZARD CORRISPONDENTE
            Call clsNavigation.Show_Ope_DisaccantonamentoMerci(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, Nothing, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class