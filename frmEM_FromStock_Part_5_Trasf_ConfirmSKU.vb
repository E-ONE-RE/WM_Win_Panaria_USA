Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmEM_FromStock_Part_5_Trasf_ConfirmSKU

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_5_Trasf_ConfirmSKU"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String
    Private UdMTrasfListIndex As Integer = 0
    Private txtQta As String

    Public outSapGiacenzaScelta As clsDataType.SapDatiProduzioneScelta


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

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

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'TODO : controllo cambio quantità se diversa ... 
            Dim frmEM_FromStock_Part_1_Trasf_UMForm As New frmEM_FromStock_Part_1_Trasf_UM
            frmEM_FromStock_Part_1_Trasf_UMForm.Show()
            clsSapUtility.ResetGiacenzaStruct(clsEMFromStock.WorkGiacenzaUM)
            frmEM_FromStock_Part_1_Trasf_UMForm.RefreshDatiMaterialeAttivo()

            Me.Close()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdReject_Click(sender As Object, e As EventArgs) Handles cmdReject.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim UserAnswer As DialogResult = DialogResult.No

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'MESSAGGIO DI CONFERMA REJECT PALLET
            ErrDescription = clsAppTranslation.GetSingleParameterValue(1228, "", "Si è sicuri di voler ANNULLARE l'Unità di Magazzino?")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = Windows.Forms.DialogResult.Yes) Then
                '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                System.Windows.Forms.Application.DoEvents()
                Me.Close()
                System.Windows.Forms.Application.DoEvents()
                clsSapUtility.ResetGiacenzaStruct(clsEMFromStock.WorkGiacenzaUM)
                frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
                frmEM_FromStock_Part_1_Trasf_UMForm.Show()
                frmEM_FromStock_Part_1_Trasf_UMForm.cmdNextScreen.Focus()
                frmEM_FromStock_Part_1_Trasf_UMForm.RefreshDatiMaterialeAttivo()
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

    Private Sub frmEM_FromStock_Part_1_UM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckSkuOk As Boolean = False
        Dim FlagErrorSkuElaboration As clsDataType.FlagErrorSkuElaborationStruct
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtSKUBarcode.Focused = True) And (Me.txtSKUBarcode.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then

                    'SULL'ENTER CONFERMO DATI BC

                    Me.cmdOK.Enabled = False

                    'GESTIONE LABEL SKU
                    Me.lblCheckSKU.Text = "ERROR SKU!"
                    Me.lblCheckSKU.BackColor = Color.Red
                    Me.lblCheckSKU.Visible = False


                    CheckSkuOk = False

                    RetCode = clsSapUtility.ResetFlagErrorSkuElaborationStruct(FlagErrorSkuElaboration)
                    RetCode = clsSapWS.Call_ZWMS_CHECK_MATERIAL_SKU(Me.txtSKUBarcode.Text, clsUser.SapWmsUser.LGNUM, clsEMFromStock.WorkGiacenzaUM.CodiceMateriale, clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, True, CheckSkuOk, FlagErrorSkuElaboration, outSapGiacenzaScelta, SapFunctionError, False)
                    If (FlagErrorSkuElaboration.FlagErrorSku_MATNR = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1537, "", "Errore in determinazione codice  materiale  da SKU .") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1546, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_CHARG = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1538, "", "Errore in determinazione codice  partita  da SKU .") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1546, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_ShadeNotFound = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1539, "", "Errore codice SHADE dello SKU non trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1547, "", "Verificare anagrafica SHADE e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffMatnr = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1540, "", "Errore differenza tra CODICE MATERIALE e SKU letto.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_MatnrClass001 = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1541, "", "Errore classificazione 001 del materiale non trovata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1456, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffClass001 = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1542, "", "Errore differenza tra codice classificazione 001 e codice dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1546, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffTono = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1543, "", "Errore differenza tra il tono della produzione e tono dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffCalibro = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1544, "", "Errore differenza tra il calibro della produzione e calibro dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (CheckSkuOk <> True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1229, "", "Il codice SKU specificato non è congruente con i dati della produzione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If

                    'SETTO OGGETTI ABILITATI
                    txtQtaConfermata.Enabled = True
                    cmdOK.Enabled = True
                    cmdReject.Enabled = True
                    txtQtaConfermata.Focus()

                    'GESTIONE LABEL SKU
                    Me.lblCheckSKU.Text = "SKU OK!"
                    Me.lblCheckSKU.BackColor = Color.SpringGreen
                    Me.lblCheckSKU.Visible = True

                    RefreshDatiMaterialeAttivo()

                    Exit Sub
                End If
            End If


            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    'SULL'ENTER SPOSTO IL FOCUS SUL PULSANTE OK
                    cmdOK.Focus()
                End If
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Me.txtSKUBarcode.Text = ""
            Me.txtSKUBarcode.Focus()
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmEM_FromStock_Part_1_UM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'Me.lblUnitaMagazzinoOrigine.Text = clsAppTranslation.GetSingleParameterValue(64, lblUnitaMagazzinoOrigine.Text, "Unita Magazzino")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1230, Me.Text, "EM - Prod. da Trasf. SKU (1)")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            Me.cmdReject.Text = clsAppTranslation.GetSingleParameterValue(1231, cmdReject.Text, "Rifiuta")
            Me.cmdOK.Text = clsAppTranslation.GetSingleParameterValue(8, cmdOK.Text, "OK")
            Me.lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, lblQtaConfermata.Text, "Qtà Conf.")
            '**************************************

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'SETTO OGGETTI DISABILITATI 
            txtQtaConfermata.Enabled = False
            cmdOK.Enabled = False
            cmdReject.Enabled = False


#If Not APPLICAZIONE_WIN32 <> "SI" Then
            'AGGIUSTAMENTI PER MIGLIOR VISUALIZZAZIONE
            txtInfoUMSelezionata.Top = txtInfoUMSelezionata.Top - 30
            txtInfoUMSelezionata.Height = txtInfoUMSelezionata.Height + 100

            lblQtaConfermata.Top = lblQtaConfermata.Top + 60
            lblQtaConfermata.Height = lblQtaConfermata.Height - 20

            txtQtaConfermata.Top = txtQtaConfermata.Top + 40
#End If


            'NEL CASO DI "BACK" DEVO RIVISUALIZZARE LE UM CHE ERANO STATO IMMESSE
            Call RefreshDatiMaterialeAttivo()

            txtSKUBarcode.Focus()

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
        Dim RetCode As Long
        Dim UserAnswer As DialogResult = DialogResult.No

        Dim RetCodeFinal As Long = 0
        Dim OT_Executed_Ok As Boolean = False
        Dim OT_Executed_Number() As String
        Dim Doc_Mat_INFO() As String
        Dim Out_JobsGroup As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '***********************************************************************************************
            'VERIFICO SE LA LOCAZIONE SPECIFICATA E' CORRETTA
            If (Me.txtInfoUMSelezionata.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(503, "", "Specificare un'UNITA MAGAZZINO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Me.txtSKUBarcode.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1640, "", "Specificare uno SKU valido.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Me.txtInfoUMSelezionata.Text = UCase(Me.txtInfoUMSelezionata.Text)

            Me.txtInfoUMSelezionata.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtInfoUMSelezionata.Text)

            'Controllo cambio quantità se diversa ... 
            If txtQtaConfermata.Text <> txtQta Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1232, "", "Si è sicuri di voler MODIFICARE la Quantità ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                    clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile = CDbl(txtQtaConfermata.Text)

                Else

                    'Imposto la quantità precedente
                    txtQtaConfermata.Text = txtQta

                End If
            End If



            '>>> GESTIONE REGISTRAZIONE DIRETTA

            If (Default_TRASF_UM_EnableRegistrazioneDiretta = True) Then


                '>>> AGGIORNO ARRAY GIACENZE
                frmEM_FromStock_Part_1_Trasf_UMForm.AddUMToList(clsEMFromStock.WorkGiacenzaUM)


                '>>> CODICE PER REGISTRAZIONE IMMEDIATA ENTRATA MERCE

                RetCode = clsSapWS.Call_ZWMS_EXEC_ENT_MERCE_PROD_TRASF(clsEMFromStock.UdMTrasfList, clsUser.SapWmsUser.LGNUM, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, OT_Executed_Ok, SapFunctionError, OT_Executed_Number, Doc_Mat_INFO, clsEMFromStock.UdMTrasfList, Out_JobsGroup, False)

                If (RetCode <> 0) Then

                    ErrDescription += clsAppTranslation.GetSingleParameterValue(1224, "", "Errore nel trasferimento Materiale")

                Else
                    '>>> TUTTO OK
                    ErrDescription += clsAppTranslation.GetSingleParameterValue(1225, "", "Trasferimento Materiale ") & " " & clsAppTranslation.GetSingleParameterValue(1226, "", " eseguito con successo.") & vbCrLf
                    Dim MaxArrayIndex As Long
                    Dim IndexFor As Long

                    ErrDescription += clsAppTranslation.GetSingleParameterValue(1243, "", " JOBS GROUP:") & Out_JobsGroup & vbCrLf

                    If Not (OT_Executed_Number Is Nothing) Then
                        MaxArrayIndex = UBound(OT_Executed_Number)
                        For IndexFor = 0 To MaxArrayIndex
                            ErrDescription += clsAppTranslation.GetSingleParameterValue(1247, "", " OT:") & OT_Executed_Number(IndexFor) & vbCrLf
                        Next
                    End If

                    If Not (Doc_Mat_INFO Is Nothing) Then
                        MaxArrayIndex = UBound(Doc_Mat_INFO)
                        For IndexFor = 0 To MaxArrayIndex
                            ErrDescription += clsAppTranslation.GetSingleParameterValue(1227, "", " DOC MAT. INFO:") & Doc_Mat_INFO(IndexFor) & vbCrLf
                        Next
                    End If

                End If

                'AGGIORNO CONTATORE Errori
                RetCodeFinal += RetCode


                '************************************************************************************************
                ' >>> SE ABILITATO VISUALIZZO RISULTATO OPERAZIONE
                '************************************************************************************************
                If (EntrataMerceAbilitaMsgConfermaSuccesso = True) Or (RetCodeFinal <> 0) Then
                    'If (RetCodeFinal = 0) Then
                    'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                    frmMessageForUserForm = New frmMessageForUser
                    frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                    frmMessageForUserForm.ShowMessage(ErrDescription)
                End If

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

                        If Not (clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUM_MovTransfUnLoad) Then
                            frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm = New frmEM_FromStock_Part_1_Trasf_SelUbiSpunta
                            frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm.Show()
                            frmEM_FromStock_Part_1_Trasf_SelUbiSpuntaForm.cmdNextScreen.Focus()
                        Else
                            frmEM_FromStock_Part_4_TrasfConfirmMovForm = New frmEM_FromStock_Part_4_TrasfConfirmMov
                            frmEM_FromStock_Part_4_TrasfConfirmMovForm.Show()
                            frmEM_FromStock_Part_4_TrasfConfirmMovForm.cmdNextScreen.Focus()
                        End If

                        Exit Sub

                    End If

                End If

                'frmEM_FromStock_Part_1_Trasf_UMForm.RefreshDatiMaterialeAttivo()

                'PER VELOCIZZARE ATTIVITA OPERATORE PASSO DIRETTAMENTE ALLA VIDEATA INIZIALE DELLA SEQUENZA OPERATIVA
                'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE LA UM DA TRASFERIRE
                Call clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_StockSourceType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)

                Exit Sub
                '>>>

            End If



            '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
            System.Windows.Forms.Application.DoEvents()
            Me.Close()
            System.Windows.Forms.Application.DoEvents()
            frmEM_FromStock_Part_1_Trasf_UMForm = New frmEM_FromStock_Part_1_Trasf_UM
            frmEM_FromStock_Part_1_Trasf_UMForm.Show()
            frmEM_FromStock_Part_1_Trasf_UMForm.cmdNextScreen.Focus()
            frmEM_FromStock_Part_1_Trasf_UMForm.AddUMToList(clsEMFromStock.WorkGiacenzaUM)
            frmEM_FromStock_Part_1_Trasf_UMForm.RefreshDatiMaterialeAttivo()
            Exit Sub

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

            Me.txtInfoUMSelezionata.Text = ""

            If (clsUtility.IsStringValid(clsEMFromStock.WorkGiacenzaUM.UbicazioneInfo.UnitaMagazzino, True) = False) Then
                RefreshDatiMaterialeAttivo = 0
                Me.txtInfoUMSelezionata.Text = ""
                Exit Function
            End If

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLE PALETTE LETTE DALL'OPERATORE
            Me.txtInfoUMSelezionata.Text = clsEMFromStock.ShowJobPutAwayInfoForUserString(3)

            txtQtaConfermata.Text = UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile)
            txtQta = UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile)

            If Not (clsEMFromStock.UdMTrasfList Is Nothing) Then
                Me.lblSKU.Text = clsAppTranslation.GetSingleParameterValue(1246, "", "SKU Barcode ") & vbCrLf & _
                                     clsAppTranslation.GetSingleParameterValue(1242, "", "MISSIONE: ") & clsEMFromStock.UdMTrasfList(0).NrWmsJobs & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1243, "", "JOBS GROUP: ") & clsEMFromStock.UdMTrasfList(0).CodiceGruppoMissioni & vbCrLf & _
                                     clsAppTranslation.GetSingleParameterValue(1244, "", "NR. TRUCK: ") & clsEMFromStock.UdMTrasfList(0).TruckDayNr & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1245, "", "NR TOT PALLET: ") & clsEMFromStock.UdMTrasfList(0).TrasfNumPallet & "  " & _
                                     clsAppTranslation.GetSingleParameterValue(1248, "", "NR PALLET RIMANENTI: ") & clsEMFromStock.UdMTrasfList(0).TrasfNumPallet - clsEMFromStock.UdMTrasfList.GetUpperBound(0) - 1
            End If

            RefreshDatiMaterialeAttivo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class