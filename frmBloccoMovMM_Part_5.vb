
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmBloccoMovMM_Part_5

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmBloccoMovMM_Part_5"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError
    Private ErrDescription As String


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            Call frmBloccoMovMM_Part_5_KeyPress(Me, e)

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

            RetCode = clsNavigation.Show_Mnu_Main_BloccoMerci(Me, True)


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
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'PASSO ALLO VIDEATA DELLO STEP PRECEDENTE
            Call clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.BloccoMovMMType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)

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
        Dim UserAnswer As DialogResult = DialogResult.None
        Dim WorkString As String = ""
        Dim Mov_Executed_Ok As Boolean = False
        Dim Mov_InfoStock As StrctGoodMovMB11CreateStock
        Dim Mov_InfoStockQ As StrctGoodMovCreateStockQ
        Dim outDocumentoMateriale As clsDataType.SapWmDocumentoMateriale
        Dim wkNumeroOrdine As String = ""
        Dim wkNumeroOrdinePosizione As String = ""
        Dim wk_qta_confermata As Double = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


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
            If (Val(Me.txtQtaConfermata.Text) <= 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(319, "", "La Qtà Confermata deve essere maggiore di ZERO.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'SE HO VERIFICATO LA POSIZIONE DEVO VERIFICARE LA QTA IMMESSA
            wk_qta_confermata = Val(Me.txtQtaConfermata.Text)
            If (wk_qta_confermata > clsBloccoMovMM.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(320, "", "Qtà Confermata superiore a quella disponibile.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If (wk_qta_confermata <> clsBloccoMovMM.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) Then
                WorkString = clsAppTranslation.GetSingleParameterValue(321, "", "Si desidera veramente confermare una QTA' diversa da quella disponibile ? ") & clsAppTranslation.GetSingleParameterValue(322, "", "(SI/NO)")
                UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    Exit Sub
                End If
            End If

            '>>> IMPOSTO QTA CONFERMATA DALL'OPERATORE
            clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore = Me.txtQtaConfermata.Text

            Select Case clsBloccoMovMM.BloccoMovMMType

                Case clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockQ

#If Not APPLICAZIONE_WIN32 = "SI" Then

                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStockQ.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStockQ.GR_GI_SLIP_NO = ""
                    Mov_InfoStockQ.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStockQ.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStockQ.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStockQ.LQNUM = ""
                    'Mov_InfoStockQ.PSTNG_DATE = ""
                    Mov_InfoStockQ.REF_DOC_NO = ""
                    Mov_InfoStockQ.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStockQ.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStockQ.LENUM = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
                    Mov_InfoStockQ.SapMovCreateItem_Rec.Material = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStockQ.SapMovCreateItem_Rec.Batch = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStockQ.SapMovCreateItem_Rec.Plant = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStockQ.SapMovCreateItem_Rec.StgeLoc = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO

                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStockQ.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_AddStockQ  '>>> 411"
                            Mov_InfoStockQ.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(323, "", "METTI STOCK Q")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStockQ.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockQ
                            Mov_InfoStockQ.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(324, "", "TOGLI STOCK Q")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select
                    Mov_InfoStockQ.SapMovCreateItem_Rec.StckType = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStockQ.SapMovCreateItem_Rec.SpecStock = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStockQ.SapMovCreateItem_Rec.EntryQnt = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStockQ.SapMovCreateItem_Rec.EntryUom = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStockQ.SapMovCreateItem_Rec.PoNumber = ""
                    Mov_InfoStockQ.SapMovCreateItem_Rec.PoItem = ""

                    'Mov_InfoStockQ.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStockQ.SapMovCreateItem_Rec.RefDoc = ""
                    Mov_InfoStockQ.SapMovCreateItem_Rec.RefDocIt = ""

                    Mov_InfoStockQ.SapMovCreateItem_Rec.ValSalesOrd = ""
                    Mov_InfoStockQ.SapMovCreateItem_Rec.ValSOrdItem = ""

#Else


                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStockQ.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStockQ.GR_GI_SLIP_NO = ""
                    Mov_InfoStockQ.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStockQ.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStockQ.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStockQ.LQNUM = ""
                    'Mov_InfoStockQ.PSTNG_DATE = ""
                    Mov_InfoStockQ.REF_DOC_NO = ""
                    Mov_InfoStockQ.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStockQ.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStockQ.LENUM = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)
                    Mov_InfoStockQ.BESTQ = clsBloccoMovMM.MaterialeGiacenza.TipoStock

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.batchField = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO

                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_AddStockQ  '>>> 411"
                            Mov_InfoStockQ.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(323, "", "METTI STOCK Q")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockQ
                            Mov_InfoStockQ.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(324, "", "TOGLI STOCK Q")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stckTypeField = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.specStockField = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryQntField = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poNumberField = ""
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poItemField = ""

                    'Mov_InfoStockQ.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocField = ""
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocItField = ""

                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSalesOrdField = ""
                    Mov_InfoStockQ.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSOrdItemField = ""


#End If

                    'ESEGUO MOVIMENTO IN SAP (MOVIMENTO DI STOCK Q)
                    RetCode = clsSapWS.Call_ZWS_MB_GOODSMVT_CREATE_MB11_Q(Mov_InfoStockQ, Mov_Executed_Ok, SapFunctionError, outDocumentoMateriale, False)
                    If (RetCode <> 0) Then
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(326, "", "Attenzione!Errore nel Movimento di METTI STOCK Q.")
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(327, "", "Attenzione!Errore nel Movimento di TOGLI STOCK Q.")
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(328, "", "Attenzione!Errore nel Movimento.")
                        End Select
                    Else
                        '>>> TUTTO OK
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(329, "", "Movimento METTI STOCK Q eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(330, "", "Movimento TOGLI STOCK Q eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(331, "", "Movimento eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                        End Select
                    End If

                Case clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockE

                Case clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockO

                Case clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockR

#If Not APPLICAZIONE_WIN32 = "SI" Then

                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStock.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStock.GR_GI_SLIP_NO = ""
                    Mov_InfoStock.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStock.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStock.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStock.LQNUM = ""
                    'Mov_InfoStock.PSTNG_DATE = ""
                    Mov_InfoStock.REF_DOC_NO = ""
                    Mov_InfoStock.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStock.LENUM = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO

                    Mov_InfoStock.SapMovCreateItem_Rec.Material = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStock.SapMovCreateItem_Rec.Batch = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStock.SapMovCreateItem_Rec.Plant = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStock.SapMovCreateItem_Rec.StgeLoc = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO

                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_AddStockS  '>>> NON POSSIBILE"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(332, "", "METTI STOCK R")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockR '>>> 453"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(333, "", "TOGLI STOCK R")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(334, "", "Attenzione, Tipo movimento STOCK R errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select
                    Mov_InfoStock.SapMovCreateItem_Rec.StckType = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStock.SapMovCreateItem_Rec.SpecStock = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SapMovCreateItem_Rec.EntryQnt = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStock.SapMovCreateItem_Rec.EntryUom = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStock.SapMovCreateItem_Rec.PoNumber = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.PoItem = ""

                    'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStock.SapMovCreateItem_Rec.RefDoc = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.RefDocIt = ""

                    Mov_InfoStock.SapMovCreateItem_Rec.ValSalesOrd = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.ValSOrdItem = ""

#Else

                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStock.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStock.GR_GI_SLIP_NO = ""
                    Mov_InfoStock.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStock.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStock.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStock.LQNUM = ""
                    'Mov_InfoStock.PSTNG_DATE = ""
                    Mov_InfoStock.REF_DOC_NO = ""
                    Mov_InfoStock.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStock.LENUM = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)
                    Mov_InfoStock.BESTQ = clsBloccoMovMM.MaterialeGiacenza.TipoStock

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.batchField = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO


                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_AddStockS  '>>> NON POSSIBILE"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(332, "", "METTI STOCK R")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockR '>>> 453"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(333, "", "TOGLI STOCK R")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(334, "", "Attenzione, Tipo movimento STOCK R errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stckTypeField = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.specStockField = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryQntField = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poNumberField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poItemField = ""

                    'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocItField = ""

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSalesOrdField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSOrdItemField = ""

#End If

                    'ESEGUO MOVIMENTO IN SAP (MOVIMENTO DI STOCK R)
                    RetCode = clsSapWS.Call_ZWS_MB_GOODSMVT_CREATE_MB11(Mov_InfoStock, Mov_Executed_Ok, SapFunctionError, outDocumentoMateriale, False)
                    If (RetCode <> 0) Then
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(335, "", "Attenzione!Errore nel Movimento di METTI STOCK R.")
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(336, "", "Attenzione!Errore nel Movimento di TOGLI STOCK R.")
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(328, "", "Attenzione!Errore nel Movimento.")
                        End Select
                    Else
                        '>>> TUTTO OK
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(337, "", "Movimento METTI STOCK R eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(338, "", "Movimento TOGLI STOCK R eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(331, "", "Movimento eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                        End Select
                    End If

                Case clsBloccoMovMM.Blocco_Mov_MM_Type.BloccoMovMM_Type_StockS

#If Not APPLICAZIONE_WIN32 = "SI" Then

                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStock.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStock.GR_GI_SLIP_NO = ""
                    Mov_InfoStock.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStock.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStock.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStock.LQNUM = ""
                    'Mov_InfoStock.PSTNG_DATE = ""
                    Mov_InfoStock.REF_DOC_NO = ""
                    Mov_InfoStock.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStock.LENUM = clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
                    Mov_InfoStock.SapMovCreateItem_Rec.Material = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStock.SapMovCreateItem_Rec.Batch = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStock.SapMovCreateItem_Rec.Plant = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStock.SapMovCreateItem_Rec.StgeLoc = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO

                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_AddStockS  '>>> 344"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(339, "", "METTI STOCK S")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStock.SapMovCreateItem_Rec.MoveType = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockS '>>> 343"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(340, "", "TOGLI STOCK S")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select
                    Mov_InfoStock.SapMovCreateItem_Rec.StckType = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStock.SapMovCreateItem_Rec.SpecStock = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SapMovCreateItem_Rec.EntryQnt = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStock.SapMovCreateItem_Rec.EntryUom = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStock.SapMovCreateItem_Rec.PoNumber = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.PoItem = ""

                    'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStock.SapMovCreateItem_Rec.RefDoc = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.RefDocIt = ""

                    Mov_InfoStock.SapMovCreateItem_Rec.ValSalesOrd = ""
                    Mov_InfoStock.SapMovCreateItem_Rec.ValSOrdItem = ""

#Else

                    '>>> IMPOSTO DATI DI TESTATA
                    Mov_InfoStock.BILL_OF_LADING = ""
                    'Mov_InfoStockQ.DOC_DATE = ""
                    Mov_InfoStock.GR_GI_SLIP_NO = ""
                    Mov_InfoStock.LGNUM = clsBloccoMovMM.SourceUbicazione.NumeroMagazzino
                    Mov_InfoStock.LGPLA = clsBloccoMovMM.SourceUbicazione.Ubicazione
                    Mov_InfoStock.LGTYP = clsBloccoMovMM.SourceUbicazione.TipoMagazzino
                    Mov_InfoStock.LQNUM = ""
                    'Mov_InfoStock.PSTNG_DATE = ""
                    Mov_InfoStock.REF_DOC_NO = ""
                    Mov_InfoStock.SOBKZ = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.SONUM = clsBloccoMovMM.MaterialeGiacenza.NumeroStockSpeciale
                    Mov_InfoStock.LENUM = clsSapUtility.FormattaStringaUnitaMagazzinoPerSap(clsBloccoMovMM.MaterialeGiacenza.UbicazioneInfo.UnitaMagazzino)
                    Mov_InfoStock.BESTQ = clsBloccoMovMM.MaterialeGiacenza.TipoStock

                    '>>> IMPOSTO DATI DI ITEM DEL MOVIMENTO
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.materialField = clsBloccoMovMM.MaterialeGiacenza.CodiceMateriale
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.batchField = clsBloccoMovMM.MaterialeGiacenza.Partita
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.plantField = clsBloccoMovMM.SourceUbicazione.Divisione
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stgeLocField = clsBloccoMovMM.MaterialeGiacenza.MagazzinoLogico  '">>> MAGAZZINO LOGICO

                    Select Case clsBloccoMovMM.BloccoMovMMOperationType
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_AddStockS  '>>> 344"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(339, "", "METTI STOCK S")
                        Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                            Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.moveTypeField = DefaultMovimento_BloccoMovMM_TipoMov_RemoveStockS '>>> 343"
                            Mov_InfoStock.HEADER_TEXT = clsAppTranslation.GetSingleParameterValue(340, "", "TOGLI STOCK S")
                        Case Else
                            ErrDescription = clsAppTranslation.GetSingleParameterValue(325, "", "Attenzione, Tipo movimento STOCK E errato.")
                            MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                    End Select

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.stckTypeField = clsBloccoMovMM.MaterialeGiacenza.TipoStock
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.specStockField = clsBloccoMovMM.MaterialeGiacenza.CdStockSpeciale
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryQntField = clsBloccoMovMM.MaterialeGiacenza.QuantitaConfermataOperatore
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.entryUomField = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poNumberField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.poItemField = ""

                    'Mov_InfoStock.SapMovCreateItem_Rec.RefDocYr = Now.Year
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.refDocItField = ""

                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSalesOrdField = ""
                    Mov_InfoStock.rfcSapMovCreateItem_Rec.iGoodsmvtItemTabField.valSOrdItemField = ""

#End If

                    'ESEGUO MOVIMENTO IN SAP (MOVIMENTO DI STOCK S)
                    RetCode = clsSapWS.Call_ZWS_MB_GOODSMVT_CREATE_MB11(Mov_InfoStock, Mov_Executed_Ok, SapFunctionError, outDocumentoMateriale, False)
                    If (RetCode <> 0) Then
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(342, "", "Attenzione!Errore nel Movimento di METTI STOCK S.")
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(343, "", "Attenzione!Errore nel Movimento di TOGLI STOCK S.")
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(328, "", "Attenzione!Errore nel Movimento.")
                        End Select
                    Else
                        '>>> TUTTO OK
                        Select Case clsBloccoMovMM.BloccoMovMMOperationType
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Metti
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(344, "", "Movimento METTI STOCK S eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case clsBloccoMovMM.Blocco_Mov_MM_Operation_Type.BloccoMovMMOperationType_Togli
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(345, "", "Movimento TOGLI STOCK S eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                            Case Else
                                ErrDescription = ErrDescription & vbCrLf & clsAppTranslation.GetSingleParameterValue(331, "", "Movimento eseguito con successo. DOC.MAT:") & outDocumentoMateriale.NumeroDocumento
                        End Select
                    End If
            End Select


            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (BloccoMovAbilitaMsgConfermaSuccesso = True) Or (RetCode <> 0) Then

                'VISUALIZZO FINESTRA PER MESSAGGI OPERATORE
                frmMessageForUserForm = New frmMessageForUser
                frmMessageForUserForm.SourceForm = Me 'setto riferimento a FORM per ricaricarla prima di chiudere la finestra del messaggio.
                frmMessageForUserForm.ShowMessage(ErrDescription)

            Else
                Me.Close()
            End If


            '************************************************************************************************
            '>>> SE HO AVUTO UN ERRORE VISUALIZZO UNA MESSAGE BOX PER RICHIEDERE SE RIPROVARE
            '************************************************************************************************
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(346, "", "Si è verificato un errore si desidera abbandonare ? (Si / No )")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                    '>>> DEVO RIPORTARE IL FOCUS SULLA FINESTRA, MA OCCORRE RICARICARLA
                    System.Windows.Forms.Application.DoEvents()
                    Me.Close()
                    System.Windows.Forms.Application.DoEvents()
                    frmBloccoMovMM_Part_5Form = New frmBloccoMovMM_Part_5
                    frmBloccoMovMM_Part_5Form.Show()
                    frmBloccoMovMM_Part_5Form.cmdNextScreen.Focus()
                    Exit Sub
                End If
            End If

            'PARTO NUOVAMENTE DALLO STEP CHE CHIEDE IL MATERIALE PER CONTINUARE LA PROCEDURA
            Call clsNavigation.Show_Ope_Blocco_Mov_MM(Me, clsBloccoMovMM.BloccoMovMMType, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartSeq, True)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmBloccoMovMM_Part_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If ((Me.txtQtaConfermata.Focused = True) And (Me.txtQtaConfermata.Text <> "")) Then
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

    Private Sub frmBloccoMovMM_Part_5_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            lblQtaPrevista.Text = clsAppTranslation.GetSingleParameterValue(67, lblQtaPrevista.Text, "Qta Prev.")
            lblUDMQuantita.Text = clsAppTranslation.GetSingleParameterValue(86, lblUDMQuantita.Text, "UdM")
            lblQtaConfermata.Text = clsAppTranslation.GetSingleParameterValue(169, lblQtaConfermata.Text, "Qtà Conf.")

            Me.Text = clsAppTranslation.GetSingleParameterValue(245, Me.Text, "Metti/Togli Stock.Spec.(5)")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

#If Not APPLICAZIONE_WIN32 = "SI" Then
			cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1470, cmdPreviousScreen.Text, "<")
#Else
            cmdPreviousScreen.Text = clsAppTranslation.GetSingleParameterValue(1471, cmdPreviousScreen.Text, "<")
#End If

            '**************************************      


            Me.txtInfoJobSelezionato.Text = clsShowUtility.FromSapWmUbicazioneStructToString(clsBloccoMovMM.SourceUbicazione, 0) & vbCrLf & clsShowUtility.FromSapWmGiacenzaStructToString(clsBloccoMovMM.MaterialeGiacenza, Nothing, 1)

            Me.txtQtaPrevista.Text = clsBloccoMovMM.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            Me.txtQtaConfermata.Text = clsBloccoMovMM.MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq
            Me.txtUDMQuantità.Text = clsBloccoMovMM.MaterialeGiacenza.UnitaDiMisuraAcquisizione

            clsBloccoMovMM.FirstLoadExecuted_Step_5 = True

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