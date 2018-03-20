Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports System.Windows.Forms

Public Class frmPickingMerci_Code_7_ConfQta

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_7_ConfQta"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private WorkDatiRicercaGiacenza As clsDataType.SapWmGiacenza

    Private wkStart_time_read As Date
    Private wkEnd_time_read As Date


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_7_ConfQta_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_UscitaMerci(Me, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Sub frmPickingMerci_Code_7_ConfQta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

    Private Sub frmPickingMerci_Code_7_ConfQta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkQtàPrevista As Double = 0
        Dim WorkUdmQtàPrevista As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni
            Me.ckboxFlagForcedStepEnded.Text = clsAppTranslation.GetSingleParameterValue(66, ckboxFlagForcedStepEnded.Text, "Fine")
            Me.lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(67, lblQtaPrevista.Text, "Qta Prev.")
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
            Me.txtInfoPesoMissione.Text = clsWmsJob.ShowJobWeightInfoForUserString(0)
            Me.lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, lblUDMQuantita.Text, "UdM")
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(169, lblQtaConfermata.Text, "Qtà Conf.")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1288, Me.Text, "Picking Appr. (6)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.lblInfoTaskLinesOnWork.Text = clsWmsJob.TaskLines.ShowTaskLinesLabelInfoForUserString()

            Me.cmdDropUDS.Text = clsAppTranslation.GetSingleParameterValue(1688, Me.cmdDropUDS.Text, "Drop Pallet")

#If APPLICAZIONE_WIN32 = "SI" Then
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1513, Me.cmdJobFunctions.Text, "Opzioni")
            Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, Me.cmdPreviousScreen.Text, "<")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1469, Me.cmdNextScreen.Text, ">")
#Else
            Me.cmdJobFunctions.Text = clsAppTranslation.GetSingleParameterValue(1466, Me.cmdJobFunctions.Text, "...")
			Me.cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, Me.cmdPreviousScreen.Text, "<")
			Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(1468, Me.cmdNextScreen.Text, ">")
#End If
            '**************************************

            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(1, True)

            'Evidenzio la riga della Qtà da prelevare
            Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
            Me.txtInfoJobSelezionato.SelectionBackColor = Color.Yellow


            'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
            If (txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                Me.txtInfoJobSelezionato.SelectionBackColor = Color.LightCoral

            End If


            'RECUPERO QTA PROPOSTA X OPERATORE ( E LA UDM PER GESTIRE  IL CASO DEL PRELIEVO DEGLI "SFUSI" )
            RetCode = clsWmsJob.GetJobPickOriQtyProposal(WorkQtàPrevista, WorkUdmQtàPrevista)
            If (RetCode = 0) Then
                Me.txtQtaPrevista.Text = Int(WorkQtàPrevista)
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore > 0) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore <= WorkQtàPrevista) Then
                    Me.txtQtaConfermata.Text = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QuantitaConfermataOperatore)
                Else
                    Me.txtQtaConfermata.Text = Int(WorkQtàPrevista)
                End If
            End If

            If (clsUtility.IsStringValid(WorkUdmQtàPrevista, True) = True) Then
                Me.txtUDMQuantità.Text = WorkUdmQtàPrevista
            Else
                Me.txtUDMQuantità.Text = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
            End If


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

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
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim QtaRimastaDaPrelevarePartialPallet As Double
        Dim QtaRimastaDaPrelevareFullPallet As Double
        Dim QtaRimastaDaPrelevareSfusi As Double
        Dim wkFlagOnlyFullPalletActive As Boolean = False
        Dim wkCheckQtyOkForFullPalletActive As Boolean = False
        Dim UserAnswer As DialogResult
        Dim wkQtaConfermata As Double
        Dim CheckExecutionOk As Boolean
        Dim CheckPickAllSU As Boolean = False
        Dim WorkUdmQty As String = ""
        Dim FlagErroreAttivo As Boolean = False
        Dim NavigationDoneOk As Boolean = False

        Dim instring As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            '* INIZIO  print DEBUG
            wkStart_time_read = Now


            If (Me.txtQtaConfermata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(317, "", "Qtà Confermata non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (InStr(Me.txtQtaConfermata.Text, ".") > 0) Or (InStr(Me.txtQtaConfermata.Text, ",") > 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1600, "", "Qtà Confermata non intera.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'NECESSARIO PER EVENTUALI DECIMALI
            wkQtaConfermata = System.Convert.ToDouble(Me.txtQtaConfermata.Text)
            If (clsWmsJob.IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                'CASO CON PRELEIVO SFUSI ( DEVO CONTROLLARE LA QTA IN PEZZI )
                If (wkQtaConfermata > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.") & vbCrLf & "Qtà Dispo:" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleDispoInUdmPZ & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                '>>> CASO NORMALE
                If (wkQtaConfermata > clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.") & vbCrLf & "Qtà Dispo:" & clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaTotaleLquaDispoUdMAcq & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'FACCIO UN CONTROLLO SULLA QTA RIMASTA DA PRELEVARE
            If (clsWmsJob.IsValidJobsGroupExec() = True) Then
                '>>> CASO CON ACCORPAMENTO
                QtaRimastaDaPrelevare = clsWmsJob.WmsJobsGroupExecInfo.QtaGroupTotaleDaPrelevare

            Else

                If (clsWmsJob.IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                    'CASO PARTICOLARE DI PRELIEVO DEGLI SFUSI
                    QtaRimastaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( PALLET PARZIALI )
                    QtaRimastaDaPrelevarePartialPallet = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( FULL PALLET )
                    QtaRimastaDaPrelevareFullPallet = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                    If (QtaRimastaDaPrelevareFullPallet > 0) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        QtaRimastaDaPrelevareFullPallet = QtaRimastaDaPrelevareFullPallet * clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                    End If

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( SFUSI )
                    QtaRimastaDaPrelevareSfusi = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

                Else
                    '>>> CASO NORMALE

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( ASSOLUTA )
                    If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = "SC") Or (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = "CT") Or (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = "CS") _
                            Or (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione = "CO") Then
                        'PER ALCUNI MATERIALI PUO' ESSERE CHE CI SIA UN PROBLEMA CON I DECIMALI PER CUI SE LA UDM CONSEGNA  E' LA SCATOLA RAGIONO SEMPRE  CON GLI INTERI 
                        QtaRimastaDaPrelevare = Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna) - Int(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna)
                    Else
                        QtaRimastaDaPrelevare = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaInUdmConsegna - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataInUdMConsegna
                    End If

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( PALLET PARZIALI )
                    QtaRimastaDaPrelevarePartialPallet = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaPartialPallet - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataPartialPallet

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( FULL PALLET )
                    QtaRimastaDaPrelevareFullPallet = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaFullPallet - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataFullPallet
                    If (QtaRimastaDaPrelevareFullPallet > 0) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                        QtaRimastaDaPrelevareFullPallet = QtaRimastaDaPrelevareFullPallet * clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet
                    End If

                    '>>> CALCOLO QTA ANCORA DA PRELEVARE ( SFUSI )
                    QtaRimastaDaPrelevareSfusi = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaJobRichiestaSfusiInPZ - clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.QtaPrelevataSfusi

                End If
            End If

            '>>> LA QTA CONFERMATA DEVE ESSERE > 0
            If (wkQtaConfermata <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di zero.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '>>> FACCIO VERIFICA SULLA QTA ASSOLUTA ANCORA DA PRELEVARE
            If (wkQtaConfermata > QtaRimastaDaPrelevare) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(384, "", "Qtà Confermata superiore a quella rimasta da prelevare.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevare & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                If (wkQtaConfermata > QtaRimastaDaPrelevareFullPallet) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1601, "", "Qtà Confermata superiore a quella rimasta da prelevare (FULL PALLET).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevareFullPallet & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'PUO' ESSERE CHE L'OPERATORE E' COSTRETTO A CONFERMARE UNA QTA MINORE DELLA QTA DELLA PALETTA PIENA ( GLI DO UNA SEGNALAZIONE NON BLOCCANTE )
                If (wkQtaConfermata < clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet) And (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet > 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1033, "", "Attenzione! Qtà diversa da quella di un pallet intero.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1615, "", "Qtà Pallet Intero:") & Trim(Str(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.ScatolePerPallet))
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1616, "", "Attenzione! TASK di tipo FULL PALLET.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(676, "", "Si conferma la QTA diversa da quella di un PALLET INTERO ? (Si/No)")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
            ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                If (wkQtaConfermata > QtaRimastaDaPrelevarePartialPallet) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1602, "", "Qtà Confermata superiore a quella rimasta da prelevare (PARTIAL PALLET).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevarePartialPallet & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                If (wkQtaConfermata > QtaRimastaDaPrelevareSfusi) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1603, "", "Qtà Confermata superiore a quella rimasta da prelevare (SFUSI).") & vbCrLf & clsAppTranslation.GetSingleParameterValue(385, "", "Qtà Da Prelevare:") & QtaRimastaDaPrelevareSfusi & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'VERIFICO SE HO ATTIVO IL CONTROLLO DEL FLAG DI PALLET INTERO
            wkCheckQtyOkForFullPalletActive = clsWmsJob.CheckQtyForFlagOnlyFullPallet(wkQtaConfermata, wkFlagOnlyFullPalletActive, False)
            If (wkFlagOnlyFullPalletActive = True) And (wkCheckQtyOkForFullPalletActive = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(675, "", "Attenzione! Missione con FLAG di PALLET INTERI.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(676, "", "Si conferma la QTA diversa da quella di un PALLET INTERO ? (Si/No)")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
            End If

            '*********************************************************************************
            '>>> SE ARRIVO QUI LA QTA INSERITA E' OK PER PROSEGUIRE
            '*********************************************************************************
            RetCode = clsWmsJob.SetJobPickQtyMaterialGiacenzaOri(wkQtaConfermata, Me.ckboxFlagForcedStepEnded.Checked)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(386, "", "Errore in impostazione Qtà Confermata.") & vbCrLf & "[SetJobPickQtyMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '***********************************************************************************************
            '>>> VERIFICO SE HO PRELEVATO TUTTA LA PALETTA
            '***********************************************************************************************
            clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.PickSUCompleto = False 'init
            If (clsUtility.IsStringValid(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.UnitaMagazzino, True) = True) Then
                If (clsWmsJob.IsJobPickPartialPickPieces(WorkUdmQty) = True) Then
                    'CASO UDM AL PEZZO
                    WorkUdmQty = WorkUdmQty
                Else
                    'CASO NORMALE
                    WorkUdmQty = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UnitaDiMisuraAcquisizione
                End If
                RetCode = clsSapWS.Call_ZWS_CHECK_PICK_ALL_SU(clsWmsJob.WmsJob.MaterialeGiacenzaOrigine, wkQtaConfermata, WorkUdmQty, clsUser.SapWmsUser.LANGUAGE, CheckExecutionOk, CheckPickAllSU, Nothing, SapFunctionError, False)
                If (CheckPickAllSU = True) Then
                    '>>> IMPOSTO FLAG DI PALETTA COMPLETAMENTE PRELEVATA
                    clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.PickSUCompleto = CheckPickAllSU
                End If
            End If

            '*****************************************************************************************************************************
            '*****************************************************************************************************************************
            '>>> ESEGUO IMMEDIATAMENTE IL TRASFERIMENTO DELLA  QTA CONFERMATA SUL  FORKLIFT
            '*****************************************************************************************************************************
            '*****************************************************************************************************************************
            RetCode = clsWmsJob.NavigationExecJobPickIntoUDS(Me, NavigationDoneOk, FlagErroreAttivo)

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (FlagErroreAttivo = True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmPickingMerci_Code_7_ConfQtaForm = New frmPickingMerci_Code_7_ConfQta
                    frmPickingMerci_Code_7_ConfQtaForm.Show()
                    frmPickingMerci_Code_7_ConfQtaForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If


            '* FINE  print DEBUG
            wkEnd_time_read = Now

            instring += "NrWmsJobs : " + clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.NrWmsJobs.ToString + " "
            instring += "Utente : " + clsUser.SapWmsUser.USERID + " "
            instring += "Fine - Elab. : " + ((wkEnd_time_read - wkStart_time_read).TotalSeconds).ToString + " secs"

            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdDropUDS_Click(sender As Object, e As EventArgs) Handles cmdDropUDS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1512, "", "Si desidera veramente eseguire il DROP del KTAG attivo ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            'ESEGUO TUTTE LE OPERAZIONI PER VERIFICARE LA VALIDITA E PREPARAZONEDELLA VIDEATA DROP
            RetCode = clsWmsJob.ChecBeforeExecScreenDropUDS(Me, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'PASSO ALLO VIDEATA DI "DROP" DELL'UDS
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeDropUDS, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdJobFunctions_Click(sender As Object, e As EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            frmPickingMerci_Code_FunzioniForm = New frmPickingMerci_Code_Funzioni
            frmPickingMerci_Code_FunzioniForm.SourceForm = Me
            frmPickingMerci_Code_FunzioniForm.Show()
            RetCode = clsNavigation.CloseSourceForm(Me, False)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class