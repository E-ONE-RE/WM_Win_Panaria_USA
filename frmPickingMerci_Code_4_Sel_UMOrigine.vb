Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility
Imports clsShowUtility

Public Class frmPickingMerci_Code_4_Sel_UMOrigine

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_Code_4_Sel_UMOrigine"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String

    Private wkStart_time_read As Date
    Private wkEnd_time_read As Date


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmPickingMerci_Code_4_Sel_UMOrigine_KeyPress(Me, e)

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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkSapWmPropostaGiacenza As clsDataType.SapWmGiacenza
        Dim wkPropostaUbicazioneInfo As clsDataType.SapWmUbicazione
        Dim GetDataOk As Boolean = False
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenzaUM As clsDataType.SapWmGiacenza
        Dim WorkGiacenzaUM_Free() As clsDataType.SapWmGiacenza
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim WorkUM_OnFinalLocation As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtCodiceUM.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1433, "", "Specificare un CODICE UDS/UBICAZIONE valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtCodiceUM.Text = Trim(UCase(Me.txtCodiceUM.Text))


            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtCodiceUM.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtCodiceUM.Text = WorkOutUbicazione


            'DETERMINO SE L'OPERATORE HA INSERITO UNA UM O UNA UBICAZIONE
            clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredNone
            RetCode = clsShowUtility.CheckUbicaOrUnitaMagEnteredString(Me.txtCodiceUM.Text, clsWmsJob.UbicaOrUnitaMagEntered)
            If (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredNone) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1432, "", "Codice UDS/UBICAZIONE non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUnitaMagazzino) And (clsUser.SapWmsUser.PROFID <> "ADMIN") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(298, "", "Specifica una UBICAZIONE valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUbicazione) Then
                'VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
                clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.Ubicazione = Me.txtCodiceUM.Text
                DatiRicercaUbicazione.TipoMagazzino = ""
                DatiRicercaUbicazione.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
                DatiRicercaUbicazione.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, Nothing, Nothing, SapFunctionError, False)
                If (ChekUbicazioneOk <> True) Or (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(662, "", "Ubicazione Origine non definita nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '*******************************************************************************************************
                '>>> AGGIUNGO CONTROLLI PER TIPO LOCAZIONE SELEZIONATA 
                '*******************************************************************************************************
                If (InfoUbicazione.FlagLocationDoor = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1796, "", "L'Ubicazione e' una DOOR e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (InfoUbicazione.FlagLocationEquipment = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1797, "", "L'Ubicazione e' un Equipment e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (InfoUbicazione.FlagLocationOperator = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1798, "", "L'Ubicazione e' un Operatore e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (InfoUbicazione.FlagLocationStagingDoor = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1799, "", "L'Ubicazione e' una Staging Door e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (InfoUbicazione.FlagLocationWrapping = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1800, "", "L'Ubicazione e' una Wrapping e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (InfoUbicazione.FlagLocation_P_D = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1801, "", "L'Ubicazione e' una P&D e non e' corretta per il PICKING.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If


                '*******************************************************************************************************
                '>>> SE L'OPERATORE HA SCELTO UNA UBICAZIONE DIVERSA FACCIO UNA SEGNALAZIONE ( PER IL PALLET PIENO )
                '*******************************************************************************************************
                '>>> RECUPERO LA GIACENZA DA PRELEVARE PROPOSTA  DALLA STRATEGIA
                RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmPropostaGiacenza)
                If (RetCode = 0) Then
                    'RECUPERO L'INFORMAZIONE DELL'UBICAZIONE
                    wkPropostaUbicazioneInfo = WorkSapWmPropostaGiacenza.OdaInputDestInfo.UbicazioneInfo

                    'L'UBICAZIONE SELEZIONATA DALL'OPERATORE
                    If (InfoUbicazione.NumeroMagazzino <> wkPropostaUbicazioneInfo.NumeroMagazzino) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1550, "", "Attenzione! L'Ubicazione selezionata ha un NUMERO MAGAZZINO diverso da quello proposto dalla stategia.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If


                    If (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        '>>> NEL CASO DI PALLET FULL FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                        '>>> NEL CASO DI PALLET PARZIALE FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                        '>>> NEL CASO DI PRELIEVO SFUSI FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                'MEMORIZZO L'INFORMAZIONE NELLA CLASSE DI GESTIONE
                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo = InfoUbicazione
            ElseIf (clsWmsJob.UbicaOrUnitaMagEntered = clsDataType.UbicaOrUnitaMagEnteredEnum.UbicaOrUnitaMagEnteredUnitaMagazzino) Then
                'CHECK NUMERO UM
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenzaUM)
                WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino = Me.txtCodiceUM.Text
                WorkGiacenzaUM.UbicazioneInfo.NumeroMagazzino = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.NumeroMagazzino
                'WorkGiacenzaUM.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo.Divisione
                WorkGiacenzaUM.UbicazioneInfo.Divisione = clsWmsJob.WmsJob.UbicazioneOrigine.Divisione
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(WorkGiacenzaUM, True, True, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, WorkGiacenzaUM, WorkGiacenzaUM_Free, WorkUM_OnFinalLocation, False, False, Nothing, SapFunctionError, False)
                If (CheckUnitaMagazzinoOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(668, "", "L'Unita Magazzino specificata non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                'IL CODICE MATERIALE E LA PARTITA DEVONO ESSERE CORRISPONDENTI
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale <> WorkGiacenzaUM.CodiceMateriale) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1431, "", "L'Unita magazzino selezionata non contiene il materiale richiesto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If
                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita <> WorkGiacenzaUM.Partita) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1430, "", "L'Unita magazzino selezionata non contiene la partita richiesta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (clsWmsJob.WmsJob.UbicazioneOrigine.Divisione <> WorkGiacenzaUM.UbicazioneInfo.Divisione) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(587, "", "La divisione selezionata non è corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                If (WorkUM_OnFinalLocation = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1825, "", "L'Unita magazzino selezionata non e' stoccata in una posizione di picking valida.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.txtCodiceUM.Text = ""
                    Exit Sub
                End If

                InfoUbicazione = WorkGiacenzaUM.UbicazioneInfo

                '*******************************************************************************************************
                '>>> SE L'OPERATORE HA SCELTO UNA UBICAZIONE DIVERSA FACCIO UNA SEGNALAZIONE ( PER IL PALLET PIENO )
                '*******************************************************************************************************
                '>>> RECUPERO LA GIACENZA DA PRELEVARE PROPOSTA  DALLA STRATEGIA
                RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmPropostaGiacenza)
                If (RetCode = 0) Then
                    'RECUPERO L'INFORMAZIONE DELL'UBICAZIONE
                    wkPropostaUbicazioneInfo = WorkSapWmPropostaGiacenza.OdaInputDestInfo.UbicazioneInfo

                    'L'UBICAZIONE SELEZIONATA DALL'OPERATORE
                    If (InfoUbicazione.NumeroMagazzino <> wkPropostaUbicazioneInfo.NumeroMagazzino) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1550, "", "Attenzione! L'Ubicazione selezionata ha un NUMERO MAGAZZINO diverso da quello proposto dalla stategia.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If


                    If (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_FullPallet) Then
                        '>>> NEL CASO DI PALLET FULL FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1152, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PartialPallet) Then
                        '>>> NEL CASO DI PALLET PARZIALE FACCIO UN WARNING BYPASSABILE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    ElseIf (clsWmsJob.TaskLines.TaskLinesOnWork.PickFullPartialType = clsTaskLines.cstTaskLinesPickType_PickPieces) Then
                        '>>> NEL CASO DI PRELIEVO SFUSI COSTRINGO L'OPERATORE A PRENDERE DA QUESTA UBICAZIONE
                        If (InfoUbicazione.TipoMagazzino <> wkPropostaUbicazioneInfo.TipoMagazzino) Or (InfoUbicazione.Ubicazione <> wkPropostaUbicazioneInfo.Ubicazione) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(1551, "", "Attenzione! L'Ubicazione selezionata e' diversa da quella proposta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1552, "", "Si desidera confermare la scelta ? ( SI/ NO )")
                            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                'MEMORIZZO L'INFORMAZIONE NELLA CLASSE DI GESTIONE
                clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.UbicazioneInfo = InfoUbicazione

                'IMPOSTO LA GIACENZA RECUPERATA CON LA LETTURA DELLA UM
                clsWmsJob.MaterialeSelStockGiacenzaOri = WorkGiacenzaUM
                clsWmsJob.MaterialeSelStockGiacenzaOri.NrWmsJobs = clsWmsJob.WmsJob.NrWmsJobs

                'IMPOSTO DATI DELLO STOCK SCELTO COME STOCK DI PRELIEVO PER PICKING
                RetCode = clsWmsJob.SetJobPickMaterialGiacenzaOri(True)
                If (RetCode <> 0) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(377, "", "Errore in impostazione dati giacenza.") & vbCrLf & "[SetJobPickMaterialGiacenzaOri]" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '???? CHIAMO UNA FUNCTION DI SAP CHE VERIFICA SE LA PALETTA SCELTAE'  OK

            End If

            'PASSO ALLO VIDEATA DELLO STEP SUCCESSIVO
            Call clsNavigation.Show_Ope_PickingMerci_Code(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_Code_4_Sel_UMOrigine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtCodiceUM.Focused = True) And (Me.txtCodiceUM.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
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

    Private Sub frmPickingMerci_Code_4_Sel_UMOrigine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim wkInfoPrelievo As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            Me.lblCodiceUMProposto.Text = clsAppTranslation.GetSingleParameterValue(162, lblCodiceUMProposto.Text, "Proposta:")
            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(4, "", "Ubicazione")
            'Me.cmdDropUDS.Text = clsAppTranslation.GetSingleParameterValue(1291, cmdDropUDS.Text, "Drop")
            Me.Text = clsAppTranslation.GetSingleParameterValue(164, Me.Text, "Picking x Pronto (4)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.cmdExecJobGetBestOriLocation.Text = clsAppTranslation.GetSingleParameterValue(1622, cmdExecJobGetBestOriLocation.Text, "Ricalcola")
            Me.lblInfoUDSOnWork.Text = clsWmsJob.ShowUDSOnWorkLabelInfoForUserString()
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

            '************************************************************************************************************    
            RetCode = clsMainApplication.GetSystemInfoForOperator(Me.lblSystemInfo.Text)


            '*************************************************************************************
            'VISUALIZZO INFORMAZIONI DELLA MISSIONE PER L'OPERATORE
            Me.txtInfoJobSelezionato.Text = clsWmsJob.ShowJobPickingInfoForUserString(0, True)

            'Evidenzio la riga della Qtà da prelevare
            Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1532, "", "QTA DA PRELEVARE") + ":"))).Length)
            Me.txtInfoJobSelezionato.SelectionBackColor = Color.Yellow


            'Evidenzio la riga con sigla "- MANDATORY" per gestione partita obbligatoria
            If (txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1742, "", "- MANDATORY")) > 0) Then

                Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(851, "", "PARTITA:")))).Length)
                Me.txtInfoJobSelezionato.SelectionBackColor = Color.LightCoral

            End If


            'Evidenzio la riga con "SCATOLE x PL:" per gestione caso 1pz = 1ct
            If (txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:")) > 0) Then

                If (clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.VarianteImballo.PezziPerScatola = 1) Then

                    Me.txtInfoJobSelezionato.Select(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:")), txtInfoJobSelezionato.Lines(txtInfoJobSelezionato.GetLineFromCharIndex(txtInfoJobSelezionato.Find(clsAppTranslation.GetSingleParameterValue(1217, "", "SCATOLE x PL:")))).Length)
                    Me.txtInfoJobSelezionato.SelectionBackColor = Color.LightCoral

                End If

                ''MESSAGGIO DI WARNING
                'ErrDescription = clsAppTranslation.GetSingleParameterValue(1776, "", "Attenzione! Il materiale prevede 1 PZ = 1 CT")
                'MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'Exit Sub

            End If


            '*************************************************************************************
            ' >>> VISUALIZZO LE INFO PRELIEVO ASSOCIATE ALLA MISSIONE
            RetCode = clsWmsJob.GetJobInfoPrelievo(wkInfoPrelievo)

            Me.txtInfoPrelievo.Text = wkInfoPrelievo

            '***************************************************************************************************
            ' >>> VISUALIZZO LE INFORMAZIONI DELLA UBICAZIONE / PALETTA DA PRELEVARE RITORNATE DALLA STRATEGIA
            RetCode = ShowStrategyProposalInfoForOperator()


            'GESTISCO MESSAGGIO STATO DI ERRORE
            If (clsWmsJob.WmsJob.ZWMS_ERROR_CODE <> "") Or (txtLocationProposal.Text = "") Then

                wkInfoPrelievo += clsAppTranslation.GetSingleParameterValue(1694, "", "WARNING:")
                wkInfoPrelievo += vbCrLf
                wkInfoPrelievo += clsAppTranslation.GetSingleParameterValue(1697, "", "Stock disponibile non trovato.")
                wkInfoPrelievo += vbCrLf

                Me.txtInfoPrelievo.BackColor = Color.LightCoral
                Me.txtInfoPrelievo.Text = wkInfoPrelievo

            Else

                Me.txtInfoPrelievo.BackColor = Color.LightGray

            End If

            '***************************************************************************************************
            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)


            'Disabilito il Copia/Incolla
            If (clsUser.SapWmsUser.PROFID = "ADMIN") Then
                Me.txtCodiceUM.ShortcutsEnabled = True
            Else
                Me.txtCodiceUM.ShortcutsEnabled = False
            End If


            Me.txtCodiceUM.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Sub txtCodiceUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodiceUM.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If Me.txtCodiceUM.Text <> "" Then
                Me.txtCodiceUM.Text = UCase(Me.txtCodiceUM.Text)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
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

    Private Sub cmdPreviousScreen_Click(sender As Object, e As EventArgs) Handles cmdPreviousScreen.Click
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

    Private Sub cmdShowStock_Click(sender As Object, e As EventArgs) Handles cmdShowStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkStrategyGiacenza As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione
        Dim GetDataGiacenzeOk As Boolean = False
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '******************************************************************************
            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEL MAGAZZINO
            '******************************************************************************

            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkStrategyGiacenza)
            If (RetCode <> 0) Then
                '??? MSG ERRORE
                Exit Sub
            End If

            'VISUALIZZO LO STOCK DELLO STESSO MATERIALE NEL TIPO MAGAZZINO ESTRAPOLATO DALLA LOGICA

            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkUbicazione.Divisione = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.Divisione
            WorkUbicazione.NumeroMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.TipoMagazzino
            WorkUbicazione.Ubicazione = "*"

            WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkGiacenza.MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            ''>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            'ReDim WorkExcludeUbicazioni(0)
            'WorkExcludeUbicazioni(0) = WorkStrategyGiacenza.UbicazioneInfo

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfo, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VISUALIZZO INFO DELLE GIACENZE DELLO STESSO MATERIALE / PARTITE
            frmPickingMerci_ShowStockInfoForm = New frmPickingMerci_ShowStockInfo
            frmPickingMerci_ShowStockInfoForm.objDataTableGiacenzeInfo = clsWmsJob.objDataTableGiacenzeOriInfo
            frmPickingMerci_ShowStockInfoForm.SourceForm = Me
            frmPickingMerci_ShowStockInfoForm.Show()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Function ShowStrategyProposalInfoForOperator() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim wkUbicazioneInfo As clsDataType.SapWmUbicazione
        Dim WorkSapWmGiacenza As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ShowStrategyProposalInfoForOperator = 1 'init at error

            'RECUPERO LA GIACENZA DA PRELEVARE PROPOSTA  DALLA STRATEGIA
            RetCode = clsWmsJob.GetElementMaterialePickOriGiacenzaProposte(0, WorkSapWmGiacenza)
            If (RetCode = 0) Then
                'VERIFICO SE DEVO SEGNALARE UNA INFORMAZIONE DI PRELIEVO

                wkUbicazioneInfo = WorkSapWmGiacenza.OdaInputDestInfo.UbicazioneInfo

                'RECUPERO INFOMAZIONI DI INFO PRELIEVO ASSOCIATE ALLA MISSIONE
                Me.txtLocationProposal.Text = ""

                '>>> MOSTRO L'INFORMAZIONE SOLO SE HO UNA SOLUZIONE TROVATA
                If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.Ubicazione, True) = True) And (clsWmsJob.StockSelezionatoUtente.Ubicazione <> wkUbicazioneInfo.Ubicazione) Then
                    '>>> CASO PARTICOLARE IN CUI VISUALIZZO L'UBICAZIONE SELEZIONATA DALLO USER DALLA VIDEATA STOCK 
                    Me.txtLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(950, Me.txtUMProposal.Text, "UBICAZIONE:") & "*" & clsWmsJob.StockSelezionatoUtente.TipoMagazzino & "-" & clsWmsJob.StockSelezionatoUtente.Ubicazione
                Else
                    '>>> CASO NORMALE DI VISUALIZZAZIONE PROPOSTA RITORNATA DALLA STRATEGIA 
                    Me.txtLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(950, Me.txtUMProposal.Text, "UBICAZIONE:") & wkUbicazioneInfo.TipoMagazzino & "-" & wkUbicazioneInfo.Ubicazione
                End If
            End If


            If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino, True) = True) And (clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino) <> clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(wkUbicazioneInfo.UnitaMagazzino)) Then
                '>>> CASO PARTICOLARE IN CUI VISUALIZZO LA PALETTA SELEZIONATA DALLO USER DALLA VIDEATA STOCK 
                Me.txtUMProposal.Text = clsAppTranslation.GetSingleParameterValue(956, "", "UM:") & "*" & clsSapUtility.FormattaStringaUnitaMagazzino(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino)
            Else
                '>>> CASO NORMALE DI VISUALIZZAZIONE PROPOSTA RITORNATA DALLA STRATEGIA 
                'Me.txtUMProposal.Text = clsAppTranslation.GetSingleParameterValue(956, "", "UM:") & clsSapUtility.FormattaStringaUnitaMagazzino(wkUbicazioneInfo.UnitaMagazzino)
                Me.txtUMProposal.Text = "**********"
            End If


            '>>> MOSTRO QTA LEGATA ALLA PALETTA PROPOSTA DA PRELEVARE

            If (clsUtility.IsStringValid(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino, True) = True) And (clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsWmsJob.StockSelezionatoUtente.UnitaMagazzino) <> clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(wkUbicazioneInfo.UnitaMagazzino)) Then

                'MOSTRO QTA MODIFICATE SELEZIONATE DALL'UTENTE RISPETTO ALLE PROPOSTE
                Me.txtQtyStockProposal.Text = clsWmsJob.StockSelezionatoUtente.QtyStockProposal
                Me.txtQtyLocationProposal.Text = clsWmsJob.StockSelezionatoUtente.QtyLocationProposal

            Else

                Me.txtQtyStockProposal.Text = clsAppTranslation.GetSingleParameterValue(1507, "", "QTA PALLET:") + " " + Trim(Str(Int(WorkSapWmGiacenza.QtaTotaleLquaDispoUdMAcq))) + " " + WorkSapWmGiacenza.UnitaDiMisuraAcquisizione
                Me.txtQtyStockProposal.Text = Me.txtQtyStockProposal.Text + " ( " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLquaInStocFullPallet)) + " PL/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLquaInStocPartialPallet)) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleInStockSfusi)) + " " + WorkSapWmGiacenza.UnitaDiMisuraPezzo + " ) "

                '>>> MOSTRO QTA LEGATA ALLA UBICAZIONE PROPOSTA DA PRELEVARE
                Me.txtQtyLocationProposal.Text = clsAppTranslation.GetSingleParameterValue(1508, "", "QTA UBI.:") + " " + Trim(Str(Int(WorkSapWmGiacenza.QtaTotaleLocationUdMAcq))) + " " + WorkSapWmGiacenza.UnitaDiMisuraAcquisizione
                Me.txtQtyLocationProposal.Text = Me.txtQtyLocationProposal.Text + " ( " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationFullPallet)) + " PL/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationPartialPallet)) + " " + UCase(WorkSapWmGiacenza.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WorkSapWmGiacenza.QtaTotaleLocationSfusi)) + " " + WorkSapWmGiacenza.UnitaDiMisuraPezzo + " ) "

            End If


            Me.lblNumPalletOfLocation.Text = clsAppTranslation.GetSingleParameterValue(1514, "", "PALLET IN UBICAZIONE:") + Trim(Str(WorkSapWmGiacenza.NumeroUDCLocation))


            ShowStrategyProposalInfoForOperator = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Function ConfermaSelezioneStock() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneStock = 1 'init at error

            Me.Focus()
            If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino <> "") Then
                'Me.txtCodiceUM.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino

                'IMPOSTO OGGETTO DEL JOB PERVISUALIZZARE INFO DELLO STOCK SELEZIONATO ( CHE BYPASSA LA PROPOSTA DELLA STRATEGIA )
                clsWmsJob.StockSelezionatoUtente = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata

                '>>> ESEGUO REFRESH DELLE INFO DELL'UBICAZIONE SUGGERITA PER IL PRELIEVO
                RetCode = ShowStrategyProposalInfoForOperator()

                clsSelezioneUnitaMagazzino.ClearAllData()
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneStock = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdJobFunctions_Click(sender As Object, e As EventArgs) Handles cmdJobFunctions.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
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

    Private Sub cmdExecJobGetBestOriLocation_Click(sender As Object, e As EventArgs) Handles cmdExecJobGetBestOriLocation.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(1621, "", "Si desidera veramente ricalcolare lo stock migliore per il PICKING ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If

            '*********************************************************************************************************************
            'IN BASE ALLA TIPOLOGIA DELLA TASK LINES DA ESEGUIRE ATTIVO LA STRATEGIA PER RICERCARE IL MATERIALE DA PRELEVARE
            '*********************************************************************************************************************
            RetCode = clsWmsJob.JobsActivateTaskLinesOnWorkExecution("", True, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(400, "", "Errore in ATTIVAZIONE MISSIONE:") & clsWmsJob.WmsJob.NrWmsJobs & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'Exit Sub
            End If

            '>>> ESEGUO RESET STRUTTURA SAP PER SELEZIONE UBICAZIONE FORZATA SELEZIONATA DA OPERATORE 
            RetCode = clsSapUtility.ResetUbicazioneStruct(clsWmsJob.StockSelezionatoUtente)

            'RIESEGUO TUTTA LA PROCEDURA PER  RICARICARE I DATI E FARE IL REFRESH DELLA VIDEATA
            Call frmPickingMerci_Code_4_Sel_UMOrigine_Load(sender, e)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PBoxInsLoc.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            Me.txtCodiceUM.Text = ""

            clsSelezioneUnitaMagazzino.SourceForm = frmPickingMerci_Code_4_Sel_UMOrigineForm

            frmPickingMerci_Code_InsLocationForm = New frmPickingMerci_Code_InsLocation
            frmPickingMerci_Code_InsLocationForm.Show()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub txtCodiceUM_TextChanged(sender As Object, e As EventArgs) Handles txtCodiceUM.TextChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim instring As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'Se utente administrator evito controllo input
            If (clsUser.SapWmsUser.PROFID = "ADMIN") Then
                Exit Sub
            End If


            'Inizio Lettura BARCODE
            If Len(txtCodiceUM.Text) = 1 Then
                wkStart_time_read = Now
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Inizio - Barcode Scan: " + wkStart_time_read)
                Exit Sub
            End If

            'Fine Lettura BARCODE
            If Len(txtCodiceUM.Text) > 7 Then

                'CASO IN CUI IMPOSTIAMO IL VALORE DALLA VIDEATA DI PICKING ISSUE
                If (wkStart_time_read = Date.MinValue) Then
                    wkStart_time_read = Now
                End If

                wkEnd_time_read = Now

                'Controllo tempo di inserimento BARCODE, se è maggiore di 2 sec e minore di 10 min. 
                'operatore ha inserito manualmente il Pallet ID
                If ((wkEnd_time_read - wkStart_time_read).TotalSeconds > 2) Then

                    'Operatore ha digitato manualmente il Codice Pallet Id  (Errore)
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1816, "", "Errore Pallet Id inserito manualmente. Prego usare il lettore BARCODE.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    instring = "Fine - Barcode Scan: " + wkEnd_time_read
                    clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)
                    txtCodiceUM.Text = ""

                    'Exit
                Else

                End If

                instring = "Fine - Barcode Scan: " + ((wkEnd_time_read - wkStart_time_read).TotalSeconds).ToString + " secs"
                clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog, instring)

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


    Public Function ConfermaSelezioneUnitaMagazzino() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneUnitaMagazzino = 1 'init at error

            Me.Focus()
            If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione <> "") Then
                wkStart_time_read = Now
                Me.txtCodiceUM.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione
                Me.cmdNextScreen.Focus()
            End If

            ConfermaSelezioneUnitaMagazzino = RetCode 'se = 0 tutto ok

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class