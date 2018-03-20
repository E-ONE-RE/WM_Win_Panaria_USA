Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports clsBusinessLogic
Imports clsSapUtility


Public Class frmEM_FromStock_Part_5_ConfirmSKU

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmEM_FromStock_Part_5_ConfirmSKU"

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
            Dim frmEM_FromStock_Part_1_UMForm As New frmEM_FromStock_Part_1_UM
            frmEM_FromStock_Part_1_UMForm.Show()
            clsSapUtility.ResetGiacenzaStruct(clsEMFromStock.WorkGiacenzaUM)
            frmEM_FromStock_Part_1_UMForm.RefreshDatiMaterialeAttivo()

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
                frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
                frmEM_FromStock_Part_1_UMForm.Show()
                frmEM_FromStock_Part_1_UMForm.cmdNextScreen.Focus()
                frmEM_FromStock_Part_1_UMForm.RefreshDatiMaterialeAttivo()
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
                    'VERIFICO SE LA SKU E' CORRETTA E
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



                    'aggiungere msg partita attesa ingresso charg
                    'aggiungere msg partite elaborate E_CHARG_SKU   E_CHARG_ALTE_SKU
                    If (FlagErrorSkuElaboration.FlagErrorSku_CHARG = True) Then
                        'ErrDescription = clsAppTranslation.GetSingleParameterValue(1538, "", "Errore in determinazione codice  partita  da SKU .") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1546, "", "Verificare anagrafica materiale e classificazioni e riprovare.")
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1538, "", "Errore in determinazione codice  partita  da SKU .") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1830, "", "Partita attesa :") & FlagErrorSkuElaboration.EChargExpected & vbCrLf & clsAppTranslation.GetSingleParameterValue(1832, "", "Partite elaborate :") & FlagErrorSkuElaboration.EChargSku & "/" & FlagErrorSkuElaboration.EChargAlteSku & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_ShadeNotFound = True) Then
                        'ErrDescription = clsAppTranslation.GetSingleParameterValue(1539, "", "Errore codice SHADE dello SKU non trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1547, "", "Verificare anagrafica SHADE e riprovare.")
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1539, "", "Errore codice SHADE dello SKU non trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1830, "", "Partita attesa :") & FlagErrorSkuElaboration.EChargExpected & vbCrLf & clsAppTranslation.GetSingleParameterValue(1832, "", "Partite elaborate :") & FlagErrorSkuElaboration.EChargSku & "/" & FlagErrorSkuElaboration.EChargAlteSku & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
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



                    'aggiungere msg partita attesa ingresso charg
                    'aggiungere msg partite elaborate E_CHARG_SKU   E_CHARG_ALTE_SKU
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffTono = True) Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1543, "", "Errore differenza tra il tono della produzione e tono dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1831, "", "Tono e calibro attesi :") & outSapGiacenzaScelta.Tono & " - " & outSapGiacenzaScelta.Calibro & vbCrLf & clsAppTranslation.GetSingleParameterValue(1832, "", "Partite elaborate :") & FlagErrorSkuElaboration.EChargSku & "/" & FlagErrorSkuElaboration.EChargAlteSku & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (FlagErrorSkuElaboration.FlagErrorSku_DiffCalibro = True) Then
                        'ErrDescription = clsAppTranslation.GetSingleParameterValue(1544, "", "Errore differenza tra il calibro della produzione e calibro dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1544, "", "Errore differenza tra il calibro della produzione e calibro dello SKU.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1831, "", "Tono e calibro attesi :") & outSapGiacenzaScelta.Tono & " - " & outSapGiacenzaScelta.Calibro & vbCrLf & clsAppTranslation.GetSingleParameterValue(1832, "", "Partite elaborate :") & FlagErrorSkuElaboration.EChargSku & "/" & FlagErrorSkuElaboration.EChargAlteSku & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtSKUBarcode.Text = ""
                        txtSKUBarcode.Focus()
                        Me.lblCheckSKU.Visible = True
                        Exit Sub
                    End If
                    If (CheckSkuOk <> True) Then
                        'ErrDescription = clsAppTranslation.GetSingleParameterValue(1229, "", "Il codice SKU specificato non è congruente con i dati della produzione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1229, "", "Il codice SKU specificato non è congruente con i dati della produzione.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(1831, "", "Tono e calibro attesi :") & outSapGiacenzaScelta.Tono & " - " & outSapGiacenzaScelta.Calibro & vbCrLf & clsAppTranslation.GetSingleParameterValue(1832, "", "Partite elaborate :") & FlagErrorSkuElaboration.EChargSku & "/" & FlagErrorSkuElaboration.EChargAlteSku & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare.")
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


                    'GESTISCO NUOVI CAMPI PER MATERIALI 2° e 3° SCELTA ( DIXIE... ) 
                    If clsEMFromStock.WorkGiacenzaUM.ZFLAG_SKIPUNLOAD = "X" Then
                        ErrDescription = clsAppTranslation.GetSingleParameterValue(1693, "", "Paletta da non Caricare!")
                        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If


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

            Me.lblEscludiTrasf.Text = clsAppTranslation.GetSingleParameterValue(1699, lblEscludiTrasf.Text, "Escludi Trasf.")
            Me.ckboxFlagEscludiTrasf.Text = clsAppTranslation.GetSingleParameterValue(1700, ckboxFlagEscludiTrasf.Text, "ESCLUDERE")
            '**************************************

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            'SETTO OGGETTI DISABILITATI 
            txtQtaConfermata.Enabled = False
            cmdOK.Enabled = False
            cmdReject.Enabled = False


            'GESTISCO NUOVI CAMPI PER MATERIALI 2° e 3° SCELTA ( DIXIE... ) 
            If clsEMFromStock.WorkGiacenzaUM.ZFLAG_SKIPUNLOAD = "X" Then

                lblTrasfDesc01.Visible = True
                lblTrasfDesc01.Text = clsAppTranslation.GetSingleParameterValue(1693, lblTrasfDesc01.Text, "Paletta da non Caricare!")

                lblTrasfDesc02.Visible = True
                lblTrasfDesc02.Text = clsEMFromStock.WorkGiacenzaUM.ZSKIPUNLOAD_DESC

                'Check Automatico se è 2° o 3° scelta
                ckboxFlagEscludiTrasf.Checked = True

            End If

            ckboxFlagEscludiTrasf.Visible = True
            lblEscludiTrasf.Visible = True

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

            If (Not (IsNumeric(Me.txtQtaConfermata.Text))) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Not (CDbl(Me.txtQtaConfermata.Text) > 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(318, "", "Qtà Confermata non valida.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.txtInfoUMSelezionata.Text = UCase(Me.txtInfoUMSelezionata.Text)

            Me.txtInfoUMSelezionata.Text = clsSapUtility.MascheraStringaUnitaMagazzino(Me.txtInfoUMSelezionata.Text)

            'Controllo cambio quantità se diversa ... 
            If (txtQtaConfermata.Text <> txtQta) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(1232, "", "Si è sicuri di voler MODIFICARE la Quantità ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer = Windows.Forms.DialogResult.Yes) Then

                    clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaInStock = CDbl(txtQtaConfermata.Text)
                    clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDisponibile = CDbl(txtQtaConfermata.Text)

                Else

                    'Imposto la quantità precedente
                    txtQtaConfermata.Text = txtQta
                    Exit Sub
                End If
            End If


            '>>> SALVO SELEZIONE "ESCLUDI TRASFERIMENTO" DA CHECKBOX
            If ckboxFlagEscludiTrasf.Checked Then

                clsEMFromStock.WorkGiacenzaUM.ZFLAG_SKIPUNLOAD = "X"

            Else

                clsEMFromStock.WorkGiacenzaUM.ZFLAG_SKIPUNLOAD = ""

            End If


            '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
            System.Windows.Forms.Application.DoEvents()
            Me.Close()
            System.Windows.Forms.Application.DoEvents()
            frmEM_FromStock_Part_1_UMForm = New frmEM_FromStock_Part_1_UM
            frmEM_FromStock_Part_1_UMForm.Show()
            frmEM_FromStock_Part_1_UMForm.cmdNextScreen.Focus()
            frmEM_FromStock_Part_1_UMForm.AddUMToList(clsEMFromStock.WorkGiacenzaUM)
            frmEM_FromStock_Part_1_UMForm.RefreshDatiMaterialeAttivo()
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

            Me.txtQtaConfermata.Text = UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDispoUdMAcq)
            Me.txtQta = UCase(clsEMFromStock.WorkGiacenzaUM.QtaTotaleLquaDispoUdMAcq)

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