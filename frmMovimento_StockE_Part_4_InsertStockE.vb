
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmMovimento_StockE_Part_4_InsertStockE

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMovimento_StockE_Part_4_InsertStockE"

    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmMovimento_StockE_Part_4_InsertStockE_KeyPress(Me, e)

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
            Call clsNavigation.Show_Ope_Reg_Modifica_Stock_E(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim UserAnswer As DialogResult
        Dim Mov_Executed_Ok As Boolean = False
        Dim Mov_Info As StrctGoodMovCreateMB1BInfo
        Dim outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale
        Dim stFunctionError As clsBusinessLogic.SapFunctionError
        Dim wkNumeroOrdine As String = ""
        Dim wkNumeroOrdinePosizione As String = ""
        Dim wkNumeroStockSpeciale As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.txtStockSpeciale.Text = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(641, "", "Attenzione, specificare un numero di STOCK SPECIALE (E).")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Len(Me.txtStockSpeciale.Text) <> DefaultLunghezzaCodiceStockEInterna) And (Len(Me.txtStockSpeciale.Text) <> DefaultLunghezzaCodiceStockERidotta) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(642, "", "Attenzione, lunghezza numero STOCK SPECIALE (E) <> 16 e <> 11.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'PERMETTO DI NON INSERIRE PER PRIME 5 CIFRE = 0
            If (Len(Me.txtStockSpeciale.Text) = DefaultLunghezzaCodiceStockERidotta) Then
                wkNumeroStockSpeciale = "00000" & Me.txtStockSpeciale.Text
            Else
                wkNumeroStockSpeciale = Me.txtStockSpeciale.Text
            End If

            wkNumeroOrdine = wkNumeroStockSpeciale.Substring(0, 10)
            wkNumeroOrdinePosizione = wkNumeroStockSpeciale.Substring(10, 6)


#If Not APPLICAZIONE_WIN32 = "SI" Then

            '>>> IMPOSTO DATI DI TESTATA
            Mov_Info.BILL_OF_LADING = ""
            'Mov_Info.DOC_DATE = ""
            Mov_Info.GR_GI_SLIP_NO = ""
            Mov_Info.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(491, "", "MB METTI STOCK E")
            Mov_Info.LGNUM = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            Mov_Info.LGPLA = clsRegModStockE.UbicazioneMovimento.Ubicazione
            Mov_Info.LGTYP = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            Mov_Info.LQNUM = ""
            'Mov_Info.PSTNG_DATE = ""
            Mov_Info.REF_DOC_NO = ""
            Mov_Info.SOBKZ = "E"
            Mov_Info.SONUM = wkNumeroStockSpeciale

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_Info.SapMovCreateItem_Rec.Material = clsRegModStockE.MaterialeGiacenza.CodiceMateriale
            Mov_Info.SapMovCreateItem_Rec.Plant = clsRegModStockE.UbicazioneMovimento.Divisione
            Mov_Info.SapMovCreateItem_Rec.StgeLoc = "0001" '????>>>clsRegModStockE.MaterialeGiacenza.


            Select Case clsRegModStockE.FunctionRegModStockEType
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockE
                    Mov_Info.SapMovCreateItem_Rec.MoveType = DefaultMovimento_StockE_TipoMov_AddStockE '>>> 412"
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockECustom
                    Mov_Info.SapMovCreateItem_Rec.MoveType = DefaultMovimento_StockE_TipoMov_AddStockECustom
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select
            Mov_Info.SapMovCreateItem_Rec.SpecStock = "E"
            Mov_Info.SapMovCreateItem_Rec.EntryQnt = clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore
            Mov_Info.SapMovCreateItem_Rec.EntryUom = clsRegModStockE.MaterialeGiacenza.UnitaDiMisuraBase

            Mov_Info.SapMovCreateItem_Rec.PoNumber = wkNumeroOrdine
            Mov_Info.SapMovCreateItem_Rec.PoItem = wkNumeroOrdinePosizione

            'Mov_Info.SapMovCreateItem_Rec.RefDocYr = Now.Year
            Mov_Info.SapMovCreateItem_Rec.RefDoc = wkNumeroOrdine
            Mov_Info.SapMovCreateItem_Rec.RefDocIt = wkNumeroOrdinePosizione

            Mov_Info.SapMovCreateItem_Rec.ValSalesOrd = wkNumeroOrdine
            Mov_Info.SapMovCreateItem_Rec.ValSOrdItem = wkNumeroOrdinePosizione

#Else

            '>>> IMPOSTO DATI DI TESTATA
            Mov_Info.BILL_OF_LADING = ""
            'Mov_Info.DOC_DATE = ""
            Mov_Info.GR_GI_SLIP_NO = ""
            Mov_Info.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(491, "", "MB METTI STOCK E")
            Mov_Info.LGNUM = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            Mov_Info.LGPLA = clsRegModStockE.UbicazioneMovimento.Ubicazione
            Mov_Info.LGTYP = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            Mov_Info.LQNUM = ""
            'Mov_Info.PSTNG_DATE = ""
            Mov_Info.REF_DOC_NO = ""
            Mov_Info.SOBKZ = "E"
            Mov_Info.SONUM = wkNumeroStockSpeciale

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsRegModStockE.MaterialeGiacenza.CodiceMateriale
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsRegModStockE.UbicazioneMovimento.Divisione
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = "0001" '????>>>clsRegModStockE.MaterialeGiacenza.


            Select Case clsRegModStockE.FunctionRegModStockEType
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockE
                    Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_StockE_TipoMov_AddStockE '>>> 412"
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeAddStockECustom
                    Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_StockE_TipoMov_AddStockECustom
                Case Else
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.specStockField = "E"
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryQntField = clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsRegModStockE.MaterialeGiacenza.UnitaDiMisuraBase

            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poNumberField = wkNumeroOrdine
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poItemField = wkNumeroOrdinePosizione

            'Mov_Info.SapMovCreateItem_Rec.RefDocYr = Now.Year
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocField = wkNumeroOrdine
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocItField = wkNumeroOrdinePosizione

            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSalesOrdField = wkNumeroOrdine
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSOrdItemField = wkNumeroOrdinePosizione


#End If


            'ESEGUO MOVIMENTO IN SAP (MOVIMENTO DI STOCK E)
            RetCode = clsSapWS.Call_ZWS_MB_GOODSMVT_CREATE_MB1B(Mov_Info, Mov_Executed_Ok, stFunctionError, outDocumentoMateriale, False)
            If (RetCode <> 0) Then
                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(643, "", "Attenzione!Errore nel Movimento messa in STOCK E.")
            Else
                '>>> TUTTO OK
                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(495, "", "Movimento messa in STOCK E eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
            End If


            'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
            frmMessageForUserForm = New frmMessageForUser
            frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
            frmMessageForUserForm.ShowMessage(ErrDescription)

            ErrDescription = clsAppTranslation.GetSingleParameterValue(644, "", "Si desidera eseguire lo stesso MOVIMENTO STOCK E dalla stessa UBICAZIONE?") & clsAppTranslation.GetSingleParameterValue(322, "", "(Si/No)")
            UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                'PARTO NUOVAMENTE DALLO STEP CHE CHIDE IL MATERIALE PER CONTINUARE LA PROCEDURA
                Call clsNavigation.Show_Ope_Reg_Modifica_Stock_E(Me, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)
            Else
                'ESCO DALLA PROCEDURA => TORNO AL MENU CONTESTUALE
                RetCode = clsNavigation.Show_Mnu_Main_Trasfer(Me, True)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmMovimento_StockE_Part_4_InsertStockE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.cmdNextScreen.Focused = True)) Then
                If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Then
                    'SULL'ENTER PREMO AUTOMATICAMENTE IL PULSANTE DI NEXT
                    Call Me.cmdNextScreen_Click(Me, e)
                    Exit Sub
                End If
            End If

            If ((Me.txtStockSpeciale.Focused = True) And (Me.txtStockSpeciale.Text <> "")) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
                    Me.txtStockSpeciale.Text = UCase(Me.txtStockSpeciale.Text)
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

    Private Sub frmMovimento_StockE_Part_4_InsertStockE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

#If Not APPLICAZIONE_WIN32 = "SI" Then
            'CODICE PER INTERCETTARE PRESSIONE TASTI
            hook.Start(Me)
#End If

            '**************************************
            'Traduzioni

            lblUbicazioneOrigine.Text = clsAppTranslation.GetSingleParameterValue(4, lblUbicazioneOrigine.Text, "Ubicazione")
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(149, lblCodiceMateriale.Text, "Cod.Materiale/Partita")
            lblDescrizioneMateriale.Text = clsAppTranslation.GetSingleParameterValue(95, lblDescrizioneMateriale.Text, "Descr. Materiale")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(68, lblQtaConfermata.Text, "Qta Conf.")
            lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(126, lblUDMQuantita.Text, "Qta Stock")
            lblUM.Text = clsAppTranslation.GetSingleParameterValue(70, lblUM.Text, "UM")
            lblStockSpeciale.Text = clsAppTranslation.GetSingleParameterValue(149, lblStockSpeciale.Text, "Stock Speciale")

            Me.Text = clsAppTranslation.GetSingleParameterValue(146, Me.Text, "Movimento Stock E (3)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '************************************** 


            'VISUALIZZO UBICAZIONE ORIGINE
            Me.txtCodiceMaterialeEPartita.Text = clsRegModStockE.MaterialeGiacenza.CodiceMateriale & "/" & clsRegModStockE.MaterialeGiacenza.Partita
            Me.txtDescrizioneMateriale.Text = clsRegModStockE.MaterialeGiacenza.DescrizioneMateriale
            Me.txtQtaConfermata.Text = clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore
            Me.txtUDMQuantità.Text = clsRegModStockE.MaterialeGiacenza.UnitaDiMisuraBase
            'Me.txtUM.Text = clsRegModStockE.MaterialeGiacenza
            'VERIFICO SE IL TIPO MAGAZZINO PREVEDE LA GESTION DELL'UDM (NUMERO MAGAZZINO)
            If (clsRegModStockE.UbicazioneMovimento.AbilitaUnitaMagazzino = True) Then
                Me.txtUM.Visible = True
                Me.lblUM.Visible = True
            Else
                Me.txtUM.Visible = False
                Me.lblUM.Visible = False
            End If

            clsRegModStockE.FirstLoadExecuted_Step_4 = True

            Me.txtUbicazioneOrigine.Text = clsRegModStockE.UbicazioneMovimento.TipoMagazzino & "/" & clsRegModStockE.UbicazioneMovimento.Ubicazione

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.txtStockSpeciale.Focus()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class