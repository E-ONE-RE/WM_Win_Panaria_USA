
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmMovimento_StockE_Part_4_SelStock

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmMovimento_StockE_Part_4_SelStock"

    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmMovimento_StockE_Part_4_SelStock_KeyPress(Me, e)

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
        Dim UserSelezioneOk As Boolean = False
        Dim UserAnswer As DialogResult
        Dim Mov_Executed_Ok As Boolean = False
        Dim Mov_Info As StrctGoodMovCreateMB1BInfo
        Dim outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale
        Dim stFunctionError As clsBusinessLogic.SapFunctionError
        Dim wkNumeroOrdine As String = ""
        Dim wkNumeroOrdinePosizione As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)
            If (UserSelezioneOk = False) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(302, "", "Attenzione, selezione stock non corretta.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (clsRegModStockE.MaterialeGiacenza.QuantitaConfermataOperatore > clsRegModStockE.MaterialeGiacenza.QtaTotaleLquaDisponibile) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(382, "", "Attenzione, il traferimento è  limitato alla sola QTA disponibile.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                clsTrasfMat.MaterialeGiacenza.QuantitaConfermataOperatore = clsTrasfMat.MaterialeGiacenza.QtaTotaleLquaDisponibile
            End If

            If (clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale = "") Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(641, "", "Attenzione, specificare un numero di STOCK SPECIALE (E).")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (Len(clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale) <> 16) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(645, "", "Attenzione, lunghezza numero STOCK SPECIALE (E) <> 16.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            wkNumeroOrdine = clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale.Substring(0, 10)
            wkNumeroOrdinePosizione = clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale.Substring(10, 6)


#If Not APPLICAZIONE_WIN32 = "SI" Then

            '>>> IMPOSTO DATI DI TESTATA
            Mov_Info.BILL_OF_LADING = ""
            'Mov_Info.DOC_DATE = ""
            Mov_Info.GR_GI_SLIP_NO = ""
            Mov_Info.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(646, "", "MB TOGLI STOCK E")
            Mov_Info.LGNUM = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            Mov_Info.LGPLA = clsRegModStockE.UbicazioneMovimento.Ubicazione
            Mov_Info.LGTYP = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            Mov_Info.LQNUM = ""
            'Mov_Info.PSTNG_DATE = ""
            Mov_Info.REF_DOC_NO = ""
            Mov_Info.SOBKZ = "E"
            Mov_Info.SONUM = clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_Info.SapMovCreateItem_Rec.Material = clsRegModStockE.MaterialeGiacenza.CodiceMateriale
            Mov_Info.SapMovCreateItem_Rec.Plant = clsRegModStockE.UbicazioneMovimento.Divisione
            Mov_Info.SapMovCreateItem_Rec.StgeLoc = "0001" '????>>>clsRegModStockE.MaterialeGiacenza.

            Select Case clsRegModStockE.FunctionRegModStockEType
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE
                    Mov_Info.SapMovCreateItem_Rec.MoveType = DefaultMovimento_StockE_TipoMov_RemoveStockE  '>>> 411"
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom
                    Mov_Info.SapMovCreateItem_Rec.MoveType = DefaultMovimento_StockE_TipoMov_RemoveStockECustom
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
            Mov_Info.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(646, "", "MB TOGLI STOCK E")
            Mov_Info.LGNUM = clsRegModStockE.UbicazioneMovimento.NumeroMagazzino
            Mov_Info.LGPLA = clsRegModStockE.UbicazioneMovimento.Ubicazione
            Mov_Info.LGTYP = clsRegModStockE.UbicazioneMovimento.TipoMagazzino
            Mov_Info.LQNUM = ""
            'Mov_Info.PSTNG_DATE = ""
            Mov_Info.REF_DOC_NO = ""
            Mov_Info.SOBKZ = "E"
            Mov_Info.SONUM = clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale

            '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsRegModStockE.MaterialeGiacenza.CodiceMateriale
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsRegModStockE.UbicazioneMovimento.Divisione
            Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = "0001" '????>>>clsRegModStockE.MaterialeGiacenza.

            Select Case clsRegModStockE.FunctionRegModStockEType
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockE
                    Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_StockE_TipoMov_RemoveStockE  '>>> 411"
                Case clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeRemoveStockECustom
                    Mov_Info.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_StockE_TipoMov_RemoveStockECustom
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
                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(647, "", "Attenzione!Errore nel Movimento di rimozione STOCK E.")
            Else
                '>>> TUTTO OK
                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(648, "", "Movimento rimozione STOCK E eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
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

    Private Sub frmMovimento_StockE_Part_4_SelStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.DtGridStockInfo.Focused = True) And (Me.DtGridStockInfo.CurrentRowIndex >= 0)) Then
                If ((e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape)) Or (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return))) Then
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

    Private Sub frmMovimento_StockE_Part_4_SelStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            lblCodiceMateriale.Text = clsAppTranslation.GetSingleParameterValue(150, lblCodiceMateriale.Text, "Cod.Materiale/Partita/Spec.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(151, Me.Text, "Mov. Stock E (4)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            '************************************** 

            If Not (clsRegModStockE.objDataTableGiacenzeInfo Is Nothing) Then
                clsRegModStockE.objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = clsRegModStockE.objDataTableGiacenzeInfo
            End If

            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            RetCode = GetSelectedStockInfo(UserSelezioneOk)
            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshMaterialeInfo()

            Me.Text = clsAppTranslation.GetSingleParameterValue(151, Me.Text, "Mov. Stock E (4)")
            If (Not (clsRegModStockE.objDataTableGiacenzeInfo Is Nothing)) Then
                Me.Text = Me.Text & "-" & clsRegModStockE.objDataTableGiacenzeInfo.Rows.Count
            End If

            clsRegModStockE.FirstLoadExecuted_Step_4 = True

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)

            Me.DtGridStockInfo.Focus()

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
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, DefDtGridCol_NumeroMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, DefDtGridCol_CodiceMateriale, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "GESME", clsAppTranslation.GetSingleParameterValue(379, "", "Qta Tot."), True, DefDtGridCol_QtaTotale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "VERME", clsAppTranslation.GetSingleParameterValue(85, "", "Qta Disp."), True, DefDtGridCol_QtaDisponibile, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_UnitaMagazzino, True)
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
    Public Function GetSelectedStockInfo(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfo = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (clsRegModStockE.objDataTableGiacenzeInfo Is Nothing)) Then
                If (clsRegModStockE.objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridStockInfo.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = clsRegModStockE.objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, clsRegModStockE.MaterialeGiacenza, False)
                            If (RetCode = 0) Then
                                outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                                'VISUALIZZO DATI CORRENTI
                                RetCode = RefreshMaterialeInfo()
                            End If
                        End If
                    End If
                End If
            End If

            GetSelectedStockInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Function RefreshMaterialeInfo() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshMaterialeInfo = 1 'INIT AT ERROR

            Me.txtUbicazioneOrigine.Text = clsRegModStockE.UbicazioneMovimento.TipoMagazzino & "/" & clsRegModStockE.UbicazioneMovimento.Ubicazione
            Me.txtCodiceMaterialeEPartita.Text = clsRegModStockE.MaterialeGiacenza.CodiceMateriale & "/" & clsRegModStockE.MaterialeGiacenza.Partita
            Me.txtStockSpeciale.Text = clsRegModStockE.MaterialeGiacenza.CdStockSpeciale & "/" & clsRegModStockE.MaterialeGiacenza.NumeroStockSpeciale

            RefreshMaterialeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridStockInfo_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtGridStockInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfo(UserSelezioneOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class