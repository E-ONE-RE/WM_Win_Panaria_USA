Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic

Public Class frmTRASF_UBI_Part_2
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_UBI_Part_2"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private UdMTrasfListIndex As Integer = 0


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    cmdSelectUbicazione_Click(Me, e)
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

            'RITORNO AL MENU DI PARTENZA
            RetCode = clsTrasfUbi.Go_To_Original_Menu(Me)

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
            Call clsNavigation.Show_Ope_TRASF_UBI(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_UBI_Part_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazioneDestinazione.Focused = True) And (Me.txtUbicazioneDestinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
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

    Private Sub frmTRASF_UBI_Part_2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.lblUbicazioneDestinazione.Text = clsAppTranslation.GetSingleParameterValue(77, lblUbicazioneDestinazione.Text, "Ubicazione Destinazione")

            Me.Text = clsAppTranslation.GetSingleParameterValue(199, Me.Text, "TRASF - Ubi. (2)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazione.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazione.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazione.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************     


            If Not (clsTrasfUbi.objDataTableGiacenzeInfo Is Nothing) Then
                clsTrasfUbi.objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = clsTrasfUbi.objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            RetCode = RefreshDatiMaterialeAttivo()

            Me.txtUbicazioneDestinazione.Focus()

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
        Dim RetCodeFinal As Long = 0
        Dim OT_Executed_Ok As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim OT_Executed_Numbers() As String
        Dim OT_Info As New StrctSapMoveSuMulParams
        Dim UserAnswer As DialogResult
        Dim IntroMessage As String
        Dim NumeroUdcTotaliUbicazione As Long
        Dim WorkOT_Executed_Numbers As String
        Dim LoopIndex As Long
        Dim CheckSameStockUbiDestinationOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazioneDestinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)

            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazioneDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazioneDestinazione.Text = WorkOutUbicazione


            '>>> CONTROLLO E RITORNO DATI DELL'UBICAZIONE DI DESTINAZIONE
            'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
            clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
            RetCode = clsUtility.ClearArray(clsTrasfMat.GiacenzeUbiDestinazione)
            DatiRicercaUbicazione.Divisione = clsUser.GetUserDivisionToUse() '>>> RITORNO LA DIVISIONE DA USARE
            DatiRicercaUbicazione.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse() '>>> RITORNO IL NUMERO MAGAZZINO DA USARE
            DatiRicercaUbicazione.Ubicazione = Me.txtUbicazioneDestinazione.Text
            DatiRicercaUbicazione.UnitaMagazzino = ""

            RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, clsTrasfMat.GiacenzeUbiDestinazione, Nothing, SapFunctionError, False)
            'RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, True)
            If (ChekUbicazioneOk <> True) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (InfoUbicazione.NumeroMagazzino = clsTrasfUbi.SourceUbicazione.NumeroMagazzino And _
                    InfoUbicazione.TipoMagazzino = clsTrasfUbi.SourceUbicazione.TipoMagazzino And _
                        InfoUbicazione.Ubicazione = clsTrasfUbi.SourceUbicazione.Ubicazione) Then

                ErrDescription = clsAppTranslation.GetSingleParameterValue(507, "", "Stessa Ubicazione di Origine e Destinazione.Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA OMOGENEI
            RetCode = clsShowUtility.CheckSameStockUbiDestination(clsTrasfUbi.GiacenzeTrasfList(0), clsTrasfMat.GiacenzeUbiDestinazione, CheckSameStockUbiDestinationOk, False)
            If (CheckSameStockUbiDestinationOk <> True) Then
                '>>> SEGNALO A OPERATORE CHE  L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA DIVERSE
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(1222, "", "Materiale e/o Partita diverse ubicate nell'ubicazione di destinazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1223, "", "Si desidera continuare ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    Exit Sub
                End If
            End If


            'IMPOSTO DATI DELL'UBICAZIONE DI DESTINAZIONE VERIFICATA
            clsTrasfUbi.DestinationUbicazione = InfoUbicazione


            'INIZIALIZZO VARIABILE ESITO
            ErrDescription = ""
            RetCodeFinal = 0


            '**************************************************************************************************************
            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT

#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtMulInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
            OT_Info.SapOtMulInfo_Rec.ISquit = "X" '>>> OT CONFERMATO

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.SapOtMulInfo_Rec.INltyp = clsTrasfUbi.DestinationUbicazione.TipoMagazzino
            OT_Info.SapOtMulInfo_Rec.INlpla = clsTrasfUbi.DestinationUbicazione.Ubicazione

            'DIMENSIONO ARRAY PER PASSARE LE  UDC DA TRASFERIRE
            ReDim OT_Info.SapOtMulInfo_Rec.ILenumTab(clsTrasfUbi.GiacenzeTrasfList.Length - 1)

            'IMPOSTO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each SapWmGiacenza In clsTrasfUbi.GiacenzeTrasfList

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.SapOtMulInfo_Rec.ILenumTab(UdMTrasfListIndex) = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(SapWmGiacenza.UbicazioneInfo.UnitaMagazzino)

                'AGGIORNO CONTATORE UM
                UdMTrasfListIndex += 1

            Next

#Else

            OT_Info.rfcSapOtMulInfo_Rec.IBwlvs = Default_TRASF_UM_TipoMovNoFt
            OT_Info.rfcSapOtMulInfo_Rec.ISquit = "X" '>>> OT CONFERMATO

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.rfcSapOtMulInfo_Rec.INltyp = clsTrasfUbi.DestinationUbicazione.TipoMagazzino
            OT_Info.rfcSapOtMulInfo_Rec.INlpla = clsTrasfUbi.DestinationUbicazione.Ubicazione

            'DIMENSIONO ARRAY PER PASSARE LE  UDC DA TRASFERIRE
            ReDim OT_Info.rfcSapOtMulInfo_Rec.ILenumTab(clsTrasfUbi.GiacenzeTrasfList.Length - 1)

            'IMPOSTO TUTTE LE UDC SELEZIONATE PRECEDENTEMENTE
            For Each SapWmGiacenza In clsTrasfUbi.GiacenzeTrasfList

                '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
                OT_Info.rfcSapOtMulInfo_Rec.ILenumTab(UdMTrasfListIndex) = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(SapWmGiacenza.UbicazioneInfo.UnitaMagazzino)

                'AGGIORNO CONTATORE UM
                UdMTrasfListIndex += 1

            Next

#End If


            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)



            If InfoUbicazione.AbilitaUnitaMagazzino = True Then

                'CASO CON GESTIONE DELLA UM

                'ESEGUO OT IN SAP ( CON TUTTE LE  PALETTE DA MUOVERE )
                RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_TO_MOVE_SU_MUL(OT_Info, OT_Executed_Ok, SapFunctionError, OT_Executed_Numbers, False)

            Else

                'CASO CON GESTIONE SENZA UM

                'ESEGUO OT IN SAP ( CON TUTTE LE  PALETTE DA MUOVERE )
                RetCode = clsSapWS.Call_ZWM_MB_EXEC_WM_TO_MULTIPLE(OT_Info, clsTrasfUbi.GiacenzeTrasfList, OT_Executed_Ok, SapFunctionError, OT_Executed_Numbers, False)


            End If


            'AGGIORNO CONTATORE Errori
            RetCodeFinal += RetCode

            If (RetCode <> 0) Or (RetCodeFinal <> 0) Or (OT_Executed_Ok = False) Then
                ErrDescription += clsAppTranslation.GetSingleParameterValue(508, "", "Attenzione!Errore nel trasferimento delle UMag.") & vbCrLf
            Else

                'PALETTE TOTALI PRESENTI IN UBICAZIONE
                NumeroUdcTotaliUbicazione = clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione + clsTrasfUbi.DestinationUbicazione.NumeroUdcInUbicazione

                '>>> TUTTO OK
                IntroMessage = ""
                IntroMessage = IntroMessage & clsAppTranslation.GetSingleParameterValue(509, "", "Trasferimento delle UMag.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1226, "", "Eseguito con successo.")

                'VISUALIZZO INFORMAZIONI DELLE PALETTE TRASFERITE
                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1192, "", "Trasferite N° UDC:") & Trim(Str(clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione))

                'VISUALIZZO INFORMAZIONI DELLE PALETTE TOTALI NELL'UBICAZIONE DI DESTINAZIONE
                IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))


                If (Not OT_Executed_Numbers Is Nothing) Then
                    If (OT_Executed_Numbers.Length > 0) Then
                        IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1465, "", "Elenco Trasferimenti eseguiti:") & vbCrLf
                        For LoopIndex = 0 To (OT_Executed_Numbers.Length - 1)
                            WorkOT_Executed_Numbers = OT_Executed_Numbers(LoopIndex)
                            ErrDescription += clsAppTranslation.GetSingleParameterValue(1247, "", "OT:") & WorkOT_Executed_Numbers & vbCrLf
                        Next
                    End If
                End If

                'REGISTRO UM TRASFERIMENTO CORRETTO
                clsTrasfUbi.GiacenzeTrasfList(0).NumeroOrdineTrasferimento = OT_Executed_Numbers(0)

            End If

            'RI-INIZIALIZZO L'INDICE
            UdMTrasfListIndex = 0

            'If (RetCodeFinal <> 0) Then
            '    IntroMessage = clsAppTranslation.GetSingleParameterValue(1191, "", "Attenzione!!! Si è verificato un errore.")
            'Else
            '    'PALETTE TOTALI PRESENTI IN UBICAZIONE
            '    NumeroUdcTotaliUbicazione = clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione + clsTrasfUbi.DestinationUbicazione.NumeroUdcInUbicazione
            '    'CASO TUTO OK
            '    IntroMessage = clsAppTranslation.GetSingleParameterValue(1192, "", "Trasferite N° UDC:") & Trim(Str(clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione))
            '    IntroMessage = IntroMessage & vbCrLf & clsAppTranslation.GetSingleParameterValue(1193, "", "N° UDC Totali Ubicazione:") & Trim(Str(NumeroUdcTotaliUbicazione))
            'End If


            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(IntroMessage & vbCrLf & ErrDescription)

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCodeFinal <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(394, "", "Si è verificato un errore.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(395, "", "Si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmTRASF_UBI_Part_2Form = New frmTRASF_UBI_Part_2
                    frmTRASF_UBI_Part_2Form.Show()
                    frmTRASF_UBI_Part_2Form.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
            Call clsNavigation.Show_Ope_TRASF_UBI(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


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
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            If (clsTrasfUbi.GiacenzeTrasfList Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If
            If (clsTrasfUbi.GiacenzeTrasfList.GetLength(0) = 0) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO IL NUMERO DI UDC LETTE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsTrasfUbi.SourceUbicazione.NumeroUdcInUbicazione

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

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
                clsTrasfUbi.DestinationUbicazione.Divisione = clsSelezioneUbicazione.UbicazioneSelezionata.Divisione
                clsTrasfUbi.DestinationUbicazione.NumeroMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.NumeroMagazzino
                clsTrasfUbi.DestinationUbicazione.TipoMagazzino = clsSelezioneUbicazione.UbicazioneSelezionata.TipoMagazzino
                Me.txtUbicazioneDestinazione.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
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
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazioneDestinazione.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            clsSelezioneUbicazione.FilterDivisione = clsTrasfUbi.DestinationUbicazione.Divisione
            clsSelezioneUbicazione.FilterNumMag = clsTrasfUbi.DestinationUbicazione.NumeroMagazzino
            clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazioneDestinazione.Text


            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtUbicazioneDestinazione_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazioneDestinazione.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUbicazioneDestinazione.Text = "") Then Exit Sub

            Me.txtUbicazioneDestinazione.Text = UCase(Me.txtUbicazioneDestinazione.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function SetDataGridColumnStyles() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridStockInfo.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), False, DefDtGridCol_NumeroMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), False, DefDtGridCol_TipoMagazzino + 40, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), False, DefDtGridCol_Ubicazione, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), True, DefDtGridCol_CodiceMateriale, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale + 20, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale + 20, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(308, "", "Tip.Stock"), True, DefDtGridCol_TipoStock + 20, True)
                If (DefaultEnableShowQtyInUdmCons = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_PZ", clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_PZ", clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), False, 0, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), False, 0, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VRKME", clsAppTranslation.GetSingleParameterValue(309, "", "UdM(Cons)"), False, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_CONS", clsAppTranslation.GetSingleParameterValue(310, "", "Q.Tot.(Cons)"), False, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_CONS", clsAppTranslation.GetSingleParameterValue(311, "", "Q.Disp.(Cons)"), False, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(312, "", "UdM(Base)"), True, DefDtGridCol_UnitaDiMisura, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(313, "", "Q.Tot.(Base)"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(314, "", "Q.Disp.(Base)"), True, DefDtGridCol_QtaDisponibile, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME_PZ", clsAppTranslation.GetSingleParameterValue(1179, "", "Q.Tot.Sfusi"), True, DefDtGridCol_QtaTotale, True)
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME_PZ", clsAppTranslation.GetSingleParameterValue(1180, "", "Q.Disp.Sfusi"), True, DefDtGridCol_QtaDisponibile, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino + 20, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_UnitaMagazzino + 20, True)
            End If

            SetDataGridColumnStyles = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyles = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function

End Class