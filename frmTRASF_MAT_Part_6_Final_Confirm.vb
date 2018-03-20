Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType
Imports clsSapUtility

Public Class frmTRASF_MAT_Part_6_Final_Confirm

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmTRASF_MAT_Part_6_Final_Confirm"

    Private ErrDescription As String
    Private SapFunctionError As clsBusinessLogic.SapFunctionError


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Select Case inKey
                Case 115
                    If cmdSelectUbicazioneDest.Focused Then
                        cmdSelectUbicazioneDest_Click(Me, e)
                    ElseIf cmdShowStock.Focused Then
                        cmdShowStock_Click(Me, e)
                    Else
                        cmdSelectUbicazioneDest_Click(Me, e)
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
        Dim OT_Executed_Ok As Boolean = False
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        Dim DatiRicercaUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim InfoUbicazione As clsDataType.SapWmUbicazione
        Dim InfoGiacenzaUnitaMag As clsDataType.SapWmGiacenza
        Dim OT_Executed_Number As String = ""

        Dim UserAnswer As DialogResult
        Dim WorkUnitaMagOrigine As String
        Dim WorkUnitaMagDestinazione As String
        Dim OT_Info As New StrctSapWMSOtInfo
        Dim CheckUnitaMagazzinoOk As Boolean = False
        Dim CheckSameStockUbiDestinationOk As Boolean = False
        Dim UnitaMagazzinoOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
            Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)


            'VERIFICO SE L'UBICAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtUbicazDestConfermata.Text = "") And (Me.txtUM_Destinazione.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(388, "", "Ubicazione Destinazione non corretta.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'VERIFICO DATI UNITA DI MAGAZZINO INSERITA
            If (Me.txtUM_Destinazione.Text <> "") Then
                RetCode = clsShowUtility.CheckUnitaMagazzinoEntered(Me.txtUM_Destinazione.Text, UnitaMagazzinoOk, True)
                If (UnitaMagazzinoOk = False) Then
                    Me.txtUM_Destinazione.Text = ""
                    Exit Sub
                End If
            End If

            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazDestConfermata.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
            If (ChekUbicazioneOk = False) Then
                Exit Sub
            End If
            Me.txtUbicazDestConfermata.Text = WorkOutUbicazione


            '************************************************************************************************
            '>>> SE HO SPECIFICATO UNA PALLET ID , PUO' ESSERE CHE ESISTE O NON ESITE
            '************************************************************************************************
            CheckUnitaMagazzinoOk = False
            If (clsUtility.IsStringValid(Me.txtUM_Destinazione.Text, True) = True) Then
                clsSapUtility.ResetGiacenzaStruct(InfoGiacenzaUnitaMag)
                clsSapUtility.ResetGiacenzaStruct(WorkGiacenza)
                WorkGiacenza.UbicazioneInfo.Divisione = clsTrasfMat.SourceUbicazione.Divisione
                WorkGiacenza.UbicazioneInfo.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
                WorkGiacenza.UbicazioneInfo.UnitaMagazzino = Me.txtUM_Destinazione.Text
                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LENUM_GIACENZA(WorkGiacenza, False, False, False, False, False, "", "", clsUser.SapWmsUser.LANGUAGE, CheckUnitaMagazzinoOk, InfoGiacenzaUnitaMag, Nothing, False, False, False, Nothing, Nothing, False)
                If (CheckUnitaMagazzinoOk = True) And (clsUtility.IsStringValid(Me.txtUbicazDestConfermata.Text, True) = True) Then
                    '>>> NEL CASO TRASFERISCO L'INTERA PALETTA NON DEVO DARE NESSUNA SEGNALAZIONE
                    If (clsSapUtility.FormattaStringaUnitaMagazzino(clsTrasfMat.SourceUbicazione.UnitaMagazzino) <> clsSapUtility.FormattaStringaUnitaMagazzino(InfoGiacenzaUnitaMag.UbicazioneInfo.UnitaMagazzino)) Then
                        '>>> SE IL PALLET ESISTE VERIFICO CHE L'UBICAZIONE E' QUELLA SPECIFICATA
                        If (InfoGiacenzaUnitaMag.UbicazioneInfo.Ubicazione <> Me.txtUbicazDestConfermata.Text) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(796, "", "Ubicazione Destinazione diversa da quella del pallet immesso.") & vbCrLf & "Ubicazione pallet:" & InfoGiacenzaUnitaMag.UbicazioneInfo.Ubicazione
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        'SE TRASFERISCO LA MERCE DANDO COME DESTINAZIONE LA STESSA PALLETTA ALLORA DEVO AVERE PRELEVATO TUTTA LA PALETTA
                        If (clsTrasfMat.MaterialeGiacenza.PickSUCompleto = False) Then
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(798, "", "Attenzione!Non e' possibile spostare solo una parte della paletta") & clsAppTranslation.GetSingleParameterValue(799, "", "usando come destinazione lo stesso BARCODE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                End If
                '>>> SE HO IMMESSO SOLO L'UNITA DI MAGAZZINO E NON L'UBICAZIONE LA IMPOSTO AUTOMATICAMENTE
                If (CheckUnitaMagazzinoOk = True) And (clsUtility.IsStringValid(Me.txtUbicazDestConfermata.Text, True) = False) Then
                    InfoUbicazione = InfoGiacenzaUnitaMag.UbicazioneInfo
                    Me.txtUbicazDestConfermata.Text = InfoGiacenzaUnitaMag.UbicazioneInfo.Ubicazione
                End If
                '>>> NEL CASO CHE LA UDM E' NUOVA (NON PRESENTE IN MAGAZZINO) DEVO TASSATIVAMENTE AVERE MESSO UNA UBICAZIONE VALIDA
                If (CheckUnitaMagazzinoOk = False) And (clsUtility.IsStringValid(Me.txtUbicazDestConfermata.Text, True) = False) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(800, "", "Attenzione! Specificare una Ubicazione di DESTINAZIONE.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (CheckUnitaMagazzinoOk = False) Then
                    If (Val(Me.txtUM_Destinazione.Text) >= RangeInternoUnitaMagazzinoStart) And (Val(Me.txtUM_Destinazione.Text) <= RangeInternoUnitaMagazzinoEnd) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(930, "", "L'Unita Magazzino specificata e' nel RANGE INTERNO riservato a SAP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1606, "", "Inserire un valore inferiore a : " & RangeInternoUnitaMagazzinoStart)
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            End If

            '************************************************************************************************
            '>>> SE HO SPECIFICATO UNA UBICAZIONE LA VERIFICO
            '************************************************************************************************
            If (clsUtility.IsStringValid(Me.txtUbicazDestConfermata.Text, True) = True) Then
                '>>> VERIFICO SE L'UBICAZIONE E' CORRETTA IN SAP
                RetCode = clsUtility.ClearArray(clsTrasfMat.GiacenzeUbiDestinazione)
                RetCode = clsSapUtility.ResetUbicazioneStruct(DatiRicercaUbicazione)
                DatiRicercaUbicazione.Divisione = clsTrasfMat.SourceUbicazione.Divisione
                DatiRicercaUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
                DatiRicercaUbicazione.Ubicazione = Me.txtUbicazDestConfermata.Text

                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_LOC_OCCUPATION = True
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_LOCATION = True
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_MATERIAL_CODE = InfoGiacenzaUnitaMag.CodiceMateriale
                DatiRicercaUbicazione.FlagCheckLocationInfo.FlagCHECK_MIX_CHARG = InfoGiacenzaUnitaMag.Partita

                DatiRicercaUbicazione.FlagCheckLocationInfo.Quantity = InfoGiacenzaUnitaMag.QtaTotaleLquaInStock
                DatiRicercaUbicazione.FlagCheckLocationInfo.UdMQuantity = InfoGiacenzaUnitaMag.UnitaDiMisuraBase

                RetCode = clsSapWS.Call_ZWS_MB_CHECK_LGPLA(DatiRicercaUbicazione, ChekUbicazioneOk, InfoUbicazione, clsTrasfMat.GiacenzeUbiDestinazione, Nothing, SapFunctionError, False)
                If (ChekUbicazioneOk <> True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(389, "", "Ubicazione Destinazione non definita  nel sistema.Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If (InfoUbicazione.FlagLocationFull = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1679, "", "L'Ubicazione di DESTINAZIONE e' PIENA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1042, "", "Si desidera comunque continuare ? (Si / No )")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
                If (InfoUbicazione.FlagLocationWithDifferentMaterialCode = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1680, "", "L'Ubicazione di DESTINAZIONE contiene un MATERIALE diverso.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(284, "", "Verificare e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Me.txtUbicazDestConfermata.Text = ""
                    Exit Sub
                End If
                'VERIFICO SE L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA OMOGENEI
                RetCode = clsShowUtility.CheckSameStockUbiDestination(clsTrasfMat.MaterialeGiacenza, clsTrasfMat.GiacenzeUbiDestinazione, CheckSameStockUbiDestinationOk, False)
                If (CheckSameStockUbiDestinationOk <> True) Then
                    '>>> SEGNALO A OPERATORE CHE  L'UBICAZIONE DI DESTINAZIONE CONTIENE MATERIALE/PARTITA DIVERSE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & clsAppTranslation.GetSingleParameterValue(1222, "", "Materiale e/o Partita diverse ubicate nell'ubicazione di destinazione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1223, "", "Si desidera continuare ?")
                    UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If (UserAnswer <> DialogResult.Yes) Then
                        Exit Sub
                    End If
                End If
            End If


            'RECUPERO DATI DELL'UBICAZIONE DI DESTINAZIONE
            clsTrasfMat.DestinationUbicazione = InfoUbicazione

            If (clsUtility.IsStringValid(clsTrasfMat.SourceUbicazione.UnitaMagazzino, True) = False) And (clsUtility.IsStringValid(clsTrasfMat.DestinationUbicazione.UnitaMagazzino, True) = False) Then
                '>>> CASO DI UNITA MAGAZZINO NON GESTITA
                'NON POSSO AVERE LA STESSA UBICAZIONE DI ORIGINE E DESTINAZIONE
                If (clsTrasfMat.DestinationUbicazione.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione) And (clsTrasfMat.DestinationUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino) And (clsTrasfMat.DestinationUbicazione.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(801, "", "Ubicazione Destinazione = a quella di Origine.") & vbCrLf & "(" & clsTrasfMat.SourceUbicazione.Ubicazione & ")" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Else
                '>>> CASO DI UNITA MAGAZZINO GESTITE
                'NON POSSO AVERE LA STESSA UBICAZIONE E UNITA DI MAGAZZINO DI ORIGINE E DESTINAZIONE
                WorkUnitaMagOrigine = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.SourceUbicazione.UnitaMagazzino)
                WorkUnitaMagDestinazione = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.DestinationUbicazione.UnitaMagazzino)
                If (clsTrasfMat.DestinationUbicazione.Ubicazione = clsTrasfMat.SourceUbicazione.Ubicazione) And (clsTrasfMat.DestinationUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino) And (clsTrasfMat.DestinationUbicazione.TipoMagazzino = clsTrasfMat.SourceUbicazione.TipoMagazzino) _
                        And (WorkUnitaMagOrigine = WorkUnitaMagDestinazione) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(802, "", "Ubicazione e Unità Mag. Destinazione = a quelle di Origine.") & vbCrLf & "(" & clsTrasfMat.SourceUbicazione.Ubicazione & "-" & clsTrasfMat.SourceUbicazione.UnitaMagazzino & ")" & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            'VERIFICO SE IL TIPO MAGAZZINO DI DESTINAZIONE PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
            If (clsTrasfMat.DestinationUbicazione.AbilitaUnitaMagazzino = True) Then
                'IN QUESTO CASO DEVO RICHIEDERE LA LETTURA DI UN BARCODE DELLA CESTA
                If (Me.txtUM_Destinazione.Text = "") Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(457, "", "Unità Magazzino Destinazione non corretta.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
                'VERIFICO SE L'UNITA' DI MAGAZZINO E' CORRETTA ???? (PER SEGNALARE NUOVA UM)
                clsTrasfMat.DestinationUbicazione.UnitaMagazzino = Me.txtUM_Destinazione.Text
            Else
                clsTrasfMat.DestinationUbicazione.UnitaMagazzino = ""
            End If


            '**************************************************************************************************************
            '>>> PREPARO LE INFORMAZIONI PER ESEGUIRE L'OT NORMALE
            '**************************************************************************************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then

            OT_Info.SapOtInfo_Rec.IAnfme = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.SapOtInfo_Rec.IAltme = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione                'UDM
            OT_Info.SapOtInfo_Rec.IBwlvs = "999" 'IMPOSTO TIPO MOVIMENTO SAP
            OT_Info.SapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.SapOtInfo_Rec.ILgort = clsTrasfMat.MaterialeGiacenza.MagazzinoLogico
            OT_Info.SapOtInfo_Rec.ILgnum = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            OT_Info.SapOtInfo_Rec.IWerks = clsTrasfMat.SourceUbicazione.Divisione
            OT_Info.SapOtInfo_Rec.IMatnr = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
            OT_Info.SapOtInfo_Rec.ICharg = clsTrasfMat.MaterialeGiacenza.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.SapOtInfo_Rec.IBestq = clsTrasfMat.MaterialeGiacenza.TipoStock
            OT_Info.SapOtInfo_Rec.ISobkz = clsTrasfMat.MaterialeGiacenza.CdStockSpeciale
            OT_Info.SapOtInfo_Rec.ISonum = clsTrasfMat.MaterialeGiacenza.NumeroStockSpeciale
            OT_Info.SapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.SapOtInfo_Rec.IVltyp = clsTrasfMat.SourceUbicazione.TipoMagazzino
            OT_Info.SapOtInfo_Rec.IVlpla = clsTrasfMat.SourceUbicazione.Ubicazione
            OT_Info.SapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.SourceUbicazione.UnitaMagazzino)

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.SapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
            OT_Info.SapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione
            OT_Info.SapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.DestinationUbicazione.UnitaMagazzino)

            If (clsUtility.IsStringValid(clsTrasfMat.DestinationUbicazione.UnitaMagazzino, True) = True) Then
                OT_Info.SapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

#Else



            OT_Info.rfcSapOtInfo_Rec.IAnfme = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore 'QUANTITA DA TRASFERIRE
            OT_Info.rfcSapOtInfo_Rec.IAltme = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione                'UDM
            OT_Info.rfcSapOtInfo_Rec.IQtaExecutedSfusi = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataSfusiOperatore   'QTA DEGLI SFUSI ( PER SPOSTARE PEZZI )
            OT_Info.rfcSapOtInfo_Rec.IBwlvs = "999" 'IMPOSTO TIPO MOVIMENTO SAP
            OT_Info.rfcSapOtInfo_Rec.ISquit = "X" '>>> OT CONFERMATO
            OT_Info.rfcSapOtInfo_Rec.ILgort = clsTrasfMat.MaterialeGiacenza.MagazzinoLogico
            OT_Info.rfcSapOtInfo_Rec.ILgnum = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            OT_Info.rfcSapOtInfo_Rec.IWerks = clsTrasfMat.SourceUbicazione.Divisione
            OT_Info.rfcSapOtInfo_Rec.IMatnr = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
            OT_Info.rfcSapOtInfo_Rec.ICharg = clsTrasfMat.MaterialeGiacenza.Partita

            '>>> GESTIONE EVENTUALE STOCK SPECIALE 'E'
            OT_Info.rfcSapOtInfo_Rec.IBestq = clsTrasfMat.MaterialeGiacenza.TipoStock
            OT_Info.rfcSapOtInfo_Rec.ISobkz = clsTrasfMat.MaterialeGiacenza.CdStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ISonum = clsTrasfMat.MaterialeGiacenza.NumeroStockSpeciale
            OT_Info.rfcSapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino

            '>>>> IMPOSTO DATI UBICAZIONE ORIGINE
            OT_Info.rfcSapOtInfo_Rec.IVltyp = clsTrasfMat.SourceUbicazione.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.IVlpla = clsTrasfMat.SourceUbicazione.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.IVlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.SourceUbicazione.UnitaMagazzino)

            '>>>> IMPOSTO DATI UBICAZIONE DESTINAZIONE
            OT_Info.rfcSapOtInfo_Rec.INltyp = clsTrasfMat.DestinationUbicazione.TipoMagazzino
            OT_Info.rfcSapOtInfo_Rec.INlpla = clsTrasfMat.DestinationUbicazione.Ubicazione
            OT_Info.rfcSapOtInfo_Rec.INlenr = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsTrasfMat.DestinationUbicazione.UnitaMagazzino)

            If (clsUtility.IsStringValid(clsTrasfMat.DestinationUbicazione.UnitaMagazzino, True) = True) Then
                OT_Info.rfcSapOtInfo_Rec.ILetyp = Default_TipoUnitaMagazzino
            End If

#End If

            RetCode = clsBusinessLogic.InitSapFunctionError(SapFunctionError)
            'ESEGUO OT IN SAP (OT PER TRASFERIMENTO NORMALE)
            RetCode = clsSapWS.Call_ZWS_MB_EXEC_WM_WMS_TO(OT_Info, False, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, False)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(487, "", "Attenzione!Errore nel trasferimento.")
            Else
                '>>> TUTTO OK
                ErrDescription = clsAppTranslation.GetSingleParameterValue(488, "", "Trasferimento eseguito con successo. OT NUM:") & OT_Executed_Number
            End If



            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)

            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(468, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmTRASF_MAT_Part_6_Final_ConfirmForm = New frmTRASF_MAT_Part_6_Final_Confirm
                    frmTRASF_MAT_Part_6_Final_ConfirmForm.Show()
                    frmTRASF_MAT_Part_6_Final_ConfirmForm.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE I FILTRI PER CONTINUARE LA PROCEDURA
            Call clsNavigation.Show_Ope_TRASF_MAT(Me, clsTrasfMat.FunctionTransferMaterialType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmTRASF_MAT_Part_6_Final_Confirm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtUbicazDestConfermata.Focused = True) And (Me.txtUbicazDestConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, Nothing)
                    Exit Sub
                End If
            ElseIf ((Me.txtUbicazDestConfermata.Focused = True) And (Me.txtUbicazDestConfermata.Text = "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Destinazione.Focus()
                    Exit Sub
                End If
            End If

            If ((Me.txtUM_Destinazione.Focused = True) And (Me.txtUM_Destinazione.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtUM_Destinazione.Text = UCase(Me.txtUM_Destinazione.Text)
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

    Private Sub frmTRASF_MAT_Part_6_Final_Confirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(77, Me.lblUbicazDestConfermata.Text, "Ubicazione Destinazione")
            'Me.lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(196, Me.lblUM_Destinazione.Text, "Unità Mag.Destinazione")
            Me.lblUM_Destinazione.Text = clsAppTranslation.GetSingleParameterValue(1735, Me.lblUM_Destinazione.Text, "Nuovo Pallet Id")
            Me.Text = clsAppTranslation.GetSingleParameterValue(195, Me.Text, "TRASF - Mat. (5)")

            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, Me.cmdNextScreen.Text, "OK")
            Me.cmdShowStock.Text = clsAppTranslation.GetSingleParameterValue(253, Me.cmdShowStock.Text, "STOCK")


#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1466, cmdSelectUbicazioneDest.Text, "...")
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdSelectUbicazioneDest.Text = clsAppTranslation.GetSingleParameterValue(1467, cmdSelectUbicazioneDest.Text, "...")
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************    


            Me.txtInfoJobSelezionato.Text = clsTrasfMat.FromTrasfMatStrucToString(1)


            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            If (clsSelezioneUbicazione.SelectionOnRun = False) Then
                Me.txtUM_Destinazione.Focus()
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSelectUbicazioneDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectUbicazioneDest.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            clsSelezioneUbicazione.ClearAllData() 'INIT

            'VERIFICO SE UBICAZIONE INSERITA E' COMPATIBILE CON LA RICERCA
            RetCode = clsShowUtility.CheckUbicazioneBeforeHelpList(Me.txtUbicazDestConfermata.Text, MinNumCaratteriPerHelpUbicazione, True)
            If (RetCode <> 0) Then
                Exit Sub
            End If

            'IMPOSTO I FILTRI PER LA SELEZIONE DI UNA UBICAZIONE TRA QUELLE DISPONIBILI
            If (clsUtility.IsStringValid(clsTrasfMat.SourceUbicazione.Divisione, True) = False) Then
                Exit Sub
            End If
            If (clsUtility.IsStringValid(clsTrasfMat.SourceUbicazione.NumeroMagazzino, True) = False) Then
                Exit Sub
            End If

            clsSelezioneUbicazione.FilterDivisione = clsTrasfMat.SourceUbicazione.Divisione
            clsSelezioneUbicazione.FilterNumMag = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            clsSelezioneUbicazione.FilterTipiMag = DefaultSelectUbicazioni_TipoMag
            clsSelezioneUbicazione.FilterUbicazione = Me.txtUbicazDestConfermata.Text

            RetCode = clsSelezioneUbicazione.SelezionaUbicazione(Me)


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
                'Me.txtUbicazDestConfermata.Text = clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
                Me.txtUbicazDestConfermata.Text = ""
                Me.lblUbicazDestConfermata.Text = clsAppTranslation.GetSingleParameterValue(77, Me.lblUbicazDestConfermata.Text, "Ubicazione Destinazione") & " - " & clsSelezioneUbicazione.UbicazioneSelezionata.Ubicazione
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

    Private Sub txtUbicazDestConfermata_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicazDestConfermata.LostFocus
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtUbicazDestConfermata.Text = "") Then Exit Sub

            Me.txtUbicazDestConfermata.Text = UCase(Me.txtUbicazDestConfermata.Text)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdShowStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowStock.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione

        Dim GetDataOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '******************************************************************************
            '>>> RECUPERO SE HO ALTRE GIACENZE DI QUESTO MATERIALE NEL MAGAZZINO
            '******************************************************************************
            clsSapUtility.ResetUbicazioneStruct(WorkUbicazione) 'init
            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            RetCode = clsTrasfMat.ClearGiacenzeInfo() 'init
            WorkUbicazione.Divisione = clsTrasfMat.SourceUbicazione.Divisione
            WorkUbicazione.NumeroMagazzino = clsTrasfMat.SourceUbicazione.NumeroMagazzino
            WorkUbicazione.TipoMagazzino = "*"
            WorkUbicazione.Ubicazione = "*"

            WorkGiacenza.CodiceMateriale = clsTrasfMat.MaterialeGiacenza.CodiceMateriale
            WorkGiacenza.Partita = clsTrasfMat.MaterialeGiacenza.Partita

            '>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            ReDim WorkExcludeUbicazioni(0)
            WorkExcludeUbicazioni(0) = clsTrasfMat.SourceUbicazione

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsTrasfMat.objDataTableGiacenzeInfo, Nothing, Nothing, WorkExcludeUbicazioni, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            'VISUALIZZO INFO DELLE GIACENZE DELLO STESSO MATERIALE / PARTITE
            frmTRASF_MAT_Part_ShowStockForm = New frmTRASF_MAT_Part_ShowStock
            'frmTRASF_MAT_Part_ShowStockForm.objDataTableGiacenzeInfo = clsWmsJob.objDataTableGiacenzeOriInfo
            frmTRASF_MAT_Part_ShowStockForm.SourceForm = Me
            frmTRASF_MAT_Part_ShowStockForm.Show()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Function ConfermaSelezioneStock() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneStock = 1 'init at error

            Me.Focus()
            If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione <> "") Then
                Me.txtUbicazDestConfermata.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione
                If (clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino <> "") Then
                    Me.txtUM_Destinazione.Text = clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino
                Else
                    Me.txtUM_Destinazione.Text = ""
                End If
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim GetDataOk As Boolean = False
        Dim UserAnswer As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'Richiesta conferma stampa
            ErrDescription = clsAppTranslation.GetSingleParameterValue(1750, "", "Si desidera confermare la stampa ? ( SI/ NO )")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If


            'Aggiorno i campi quantità per la crezione della nuova etichetta UDC

            'IMPOSTO QTA CONFERMATA DELL'OPERATORE = A QUELLA DISPONIBILE
            clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDisponibile = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore
            clsTrasfMat.MaterialeGiacenza.QuantitaConfermataSfusiOperatore = clsTrasfMat.MaterialeGiacenza.QuantitaConfermataSfusiOperatore

            clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraBase = clsTrasfMat.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            'SE NON HO ANCORA INSERITO LA UBICAZIONE METTO I DEFAULT
            If (clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.Divisione = "") Then
                clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.Divisione = clsUser.GetUserDivisionToUse
            End If

            If (clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.NumeroMagazzino = "") Then
                clsTrasfMat.MaterialeGiacenza.UbicazioneInfo.NumeroMagazzino = clsUser.GetUserNumeroMagazzinoToUse()
            End If


            'IMPOSTANDO COME FILTRO PRINCIPALE L'UNITA DI MAGAZZINO
            RetCode = clsSapWS.Call_ZWMS_EXEC_PRINT_PALLET_UDC(clsTrasfMat.MaterialeGiacenza, GetDataOk, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then

                'CASO DI ERRORE STAMPA
                ErrDescription = clsAppTranslation.GetSingleParameterValue(555, "", "Nessun dato trovato.Verificare i dati immessi e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

End Class