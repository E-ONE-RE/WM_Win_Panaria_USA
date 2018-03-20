
Imports System.Data
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsDataType

Public Class frmPickingMerci_ShowStockInfo

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmPickingMerci_ShowStockInfo"

    Public Shared SourceForm As Form
    Private ErrDescription As String
    Public objDataTableGiacenzeInfo As DataTable
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza

    Private SapFunctionError As clsBusinessLogic.SapFunctionError


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

    Private Sub cmdNextScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNO STOCK DI GIANCENZA 
            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)

                        'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE
                        'clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = WorkDataRow.Item("LGNUM")
                        'clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
                        'clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")

                    End If
                End If
            End If

            If (SourceForm Is Nothing) Then
                'SE NON HO INFORMAZIONI SUL CHIAMANTE ALLORA TORNO AL MENU PRINCIPALE
                Call clsNavigation.Show_Mnu_Home(Me, True)
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_4_Sel_UMOrigine.GetType.Name) Then
                'RITORNO ALLA FINESTRA CHE HA APERTO QUESTA
                'frmPickingMerci_Code_4_Sel_UMOrigineForm = New frmPickingMerci_Code_4_Sel_UMOrigine
                frmPickingMerci_Code_4_Sel_UMOrigineForm.Show()
                Me.Close()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_5_Sel_CodMatOrigine.GetType.Name) Then
                'RITORNO ALLA FINESTRA CHE HA APERTO QUESTA
                'frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                frmPickingMerci_Code_5_Sel_CodMatOrigineForm.Show()
                Me.Close()
            ElseIf (SourceForm.GetType.Name = frmPickingMerci_Code_6_Sel_UMOrigine.GetType.Name) Then
                'RITORNO ALLA FINESTRA CHE HA APERTO QUESTA
                'frmPickingMerci_Code_5_Sel_CodMatOrigineForm = New frmPickingMerci_Code_5_Sel_CodMatOrigine
                frmPickingMerci_Code_6_Sel_UMOrigineForm.Show()
                Me.Close()
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ShowStockInfo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmPickingMerci_ShowStockInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.Text = clsAppTranslation.GetSingleParameterValue(1509, Me.Text, "Picking - Mat. (Stock Info)")
            Me.cmdNextScreen.Text = clsAppTranslation.GetSingleParameterValue(8, cmdNextScreen.Text, "OK")

            Me.cmdSeleziona.Text = clsAppTranslation.GetSingleParameterValue(1582, cmdSeleziona.Text, "SELEZIONA")
            '**************************************  


            If Not (objDataTableGiacenzeInfo Is Nothing) Then
                objDataTableGiacenzeInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo.DataSource = objDataTableGiacenzeInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()


            RetCode = GetSelectedStockInfo(UserSelezioneOk)
            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshMaterialeInfo()

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(1510, "", "PICKING - Mat.") & "-" & objDataTableGiacenzeInfo.Rows.Count
            End If

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

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

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), True, DefDtGridCol_TipoStock, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "ZWMS_SKU_PALLET", clsAppTranslation.GetSingleParameterValue(1646, "", "SKU"), True, DefDtGridCol_SKU, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo, "", "ZZCDLEGACY", clsAppTranslation.GetSingleParameterValue(1647, "", "Cod.Legacy"), True, DefDtGridCol_CodiceMaterialeLegacy, True)


                objDataTableGiacenzeInfo.DefaultView.AllowNew = False 'DISABILITO POSSIBILITA DI CREARE UNA  NUOVA RIGA
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

    Private Sub DtGridStockInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridStockInfo.CurrentCellChanged
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
            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridStockInfo.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, MaterialeGiacenza, False)
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

            'VISUALIZZO DATI MATERIALE
            Me.txtInfoJobSelezionato.Text = clsShowUtility.FromSapWmGiacenzaStrucToString(MaterialeGiacenza, 0)

            RefreshMaterialeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub cmdSeleziona_Click(sender As Object, e As EventArgs) Handles cmdSeleziona.Click

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        Dim tmpString As String

        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim GetDataOk As Boolean = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNO STOCK DI GIANCENZA 
            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                If (objDataTableGiacenzeInfo.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If (Me.DtGridStockInfo.CurrentRowIndex >= 0) Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = objDataTableGiacenzeInfo.Rows(Me.DtGridStockInfo.CurrentRowIndex)


                        'IMPOSTO I DATI DELLA UBICAZIONE DI DESTINAZIONE SELEZIONATA ALLO STEP PRECEDENTE

                        clsSelezioneUnitaMagazzino.ClearAllData()

                        clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.UnitaMagazzino = WorkDataRow.Item("LENUM")
                        clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.NumeroMagazzino = WorkDataRow.Item("LGNUM")
                        clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.TipoMagazzino = WorkDataRow.Item("LGTYP")
                        clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.Ubicazione = WorkDataRow.Item("LGPLA")


                        'FORMATTAZIONE QTA' PROPOSTA "*" MODIFICATA
                        tmpString = ""
                        tmpString += clsAppTranslation.GetSingleParameterValue(1507, "", "QTA PALLET:") + " "
                        tmpString += "*" + UCase(MaterialeGiacenza.QtaTotaleLquaDispoUdMAcq) + " "
                        tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                        'FORMATTAZZIONE QTA COMPLETA PER UTENTE
                        tmpString += clsShowUtility.ShowOnStockQtyCompleteForUserString(MaterialeGiacenza)

                        clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.QtyStockProposal = tmpString


                    End If
                End If
            End If



            'VISUALIZZO LO STOCK DELLO STESSO MATERIALE SELEZIONATO

            clsSapUtility.ResetGiacenzaStruct(WorkGiacenza) 'init
            WorkGiacenza.UbicazioneInfo.Divisione = WorkDataRow.Item("WERKS")
            WorkGiacenza.UbicazioneInfo.NumeroMagazzino = WorkDataRow.Item("LGNUM")
            WorkGiacenza.UbicazioneInfo.TipoMagazzino = WorkDataRow.Item("LGTYP")
            WorkGiacenza.UbicazioneInfo.Ubicazione = WorkDataRow.Item("LGPLA")
            WorkGiacenza.CodiceMateriale = WorkDataRow.Item("MATNR")
            WorkGiacenza.Partita = WorkDataRow.Item("CHARG")
            WorkGiacenza.MagazzinoLogico = WorkDataRow.Item("LGORT")


            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE
            RetCode = clsSapWS.Call_ZWM_GET_LOCATION_QTY_MATNR(WorkGiacenza, clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableForLockStock, SapFunctionError, False, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNO STOCK DI GIANCENZA 
            If (Not (clsWmsJob.objDataTableForLockStock Is Nothing)) Then
                If (clsWmsJob.objDataTableForLockStock.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA

                    WorkDataRow = clsWmsJob.objDataTableForLockStock.Rows(0)


                    'FORMATTAZIONE QTA' LOCAZIONE PROPOSTA "*" MODIFICATA
                    tmpString = ""
                    tmpString += clsAppTranslation.GetSingleParameterValue(1508, "", "QTA UBI.:") + " "
                    tmpString += "*" + UCase(WorkDataRow.Item("ZQTA_LOCSTOCK_SC")) + " "
                    tmpString += UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + ""
                    'FORMATTAZZIONE QTA COMPLETA PER UTENTE
                    tmpString += " ( " + Trim(Str(WorkDataRow.Item("ZQTA_LOCSTOCK_FULL"))) + " PL/ " + Trim(Str(WorkDataRow.Item("ZQTA_LOCSTOCK_PARTIA"))) + " " + UCase(MaterialeGiacenza.UnitaDiMisuraAcquisizione) + "/ " + Trim(Str(WorkDataRow.Item("ZQTA_LOCSTOCK_SF"))) + " " + MaterialeGiacenza.UnitaDiMisuraPezzo + " ) "

                    clsSelezioneUnitaMagazzino.UnitaMagazzinoSelezionata.QtyLocationProposal = tmpString


                End If

            End If


            ConfermaSelezioneStock(Me)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Shared Function ConfermaSelezioneStock(ByRef inSelectForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim MethodRetval As Object

        Dim MaterialeGiacenze() As clsDataType.SapWmGiacenza
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ConfermaSelezioneStock = 1 'init at error

            If (Not inSelectForm Is Nothing) And (Not SourceForm Is Nothing) Then
#If Not APPLICAZIONE_WIN32 = "SI" Then
                SourceForm.Visible = False
#End If

                RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "ConfermaSelezioneStock", MethodRetval, Nothing)
                'RetCode = clsUtility.ExecuteObjectMethod(SourceForm, "Show", MethodRetval, Nothing)
                inSelectForm.Close()
            End If


            ConfermaSelezioneStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ConfermaSelezioneStock = 1000 'IL THREAD E' USCITO DAL LOOP

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Private Sub btnRefreshMonitors_Click(sender As Object, e As EventArgs) Handles btnRefreshMonitors.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkStrategyGiacenza As clsDataType.SapWmGiacenza
        Dim WorkUbicazione As clsDataType.SapWmUbicazione
        Dim WorkGiacenza As clsDataType.SapWmGiacenza
        Dim WorkExcludeUbicazioni() As clsDataType.SapWmUbicazione

        Dim GetDataOk As Boolean = False
        Dim UserSelezioneOk As Boolean = False
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
            'WorkUbicazione.TipoMagazzino = WorkStrategyGiacenza.OdaInputDestInfo.UbicazioneInfo.TipoMagazzino
            WorkUbicazione.Ubicazione = "*"

            WorkGiacenza.CodiceMateriale = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.CodiceMateriale
            WorkGiacenza.Partita = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.Partita
            WorkGiacenza.MagazzinoLogico = clsWmsJob.WmsJob.MaterialeGiacenzaOrigine.MagazzinoLogico

            ''>>> DEVO ESCLUDERE L'UBICAZIONE/PALLET CORRENTE
            'ReDim WorkExcludeUbicazioni(0)
            'WorkExcludeUbicazioni(0) = WorkStrategyGiacenza.UbicazioneInfo

            'MOSTRO LE GIACENZE DELLO STESSO MATERIALE ESCLUDENDO L'UBICAZIONE DI ORIGINE
            RetCode = clsSapWS.Call_ZWS_MB_GET_LQUA_GIACENZE(WorkUbicazione, WorkGiacenza, False, Val(DefaultEM_List_MaxNumRowReturned), clsUser.SapWmsUser.LANGUAGE, GetDataOk, clsWmsJob.objDataTableGiacenzeOriInfoTotStock, Nothing, Nothing, Nothing, Nothing, SapFunctionError, False)
            If ((GetDataOk <> True) Or (RetCode <> 0)) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(474, "", "Nessuna altra giacenza presente con lo stesso MATERIALE/PARTITA.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If Not (clsWmsJob.objDataTableGiacenzeOriInfoTotStock Is Nothing) Then
                clsWmsJob.objDataTableGiacenzeOriInfoTotStock.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridStockInfo01.DataSource = clsWmsJob.objDataTableGiacenzeOriInfoTotStock
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStylesTotStock()

            RetCode = GetSelectedStockInfoTotStock(UserSelezioneOk)
            'VISUALIZZO DATI CORRENTI
            RetCode = RefreshMaterialeInfoTotStock()

            If (Not (clsWmsJob.objDataTableGiacenzeOriInfoTotStock Is Nothing)) Then
                Me.Text = clsAppTranslation.GetSingleParameterValue(1510, "", "PICKING - Mat.") & "-" & clsWmsJob.objDataTableGiacenzeOriInfoTotStock.Rows.Count
            End If

            Me.DtGridStockInfo01.Focus()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub


    Private Function SetDataGridColumnStylesTotStock() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            'creo la formattazione solo la prima volta
            If (Me.DtGridStockInfo01.TableStyles.Count = 0) Then
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(303, "", "N.Mag."), DefDtGridCol_ShowNumeroMagazzino, DefDtGridCol_NumeroMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(304, "", "Tipo"), True, DefDtGridCol_TipoMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(305, "", "Ubica."), True, DefDtGridCol_Ubicazione, True)
                'POSSO NASCONDERE LA COLONNA
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "MATNR", clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale"), False, DefDtGridCol_CodiceMateriale, True)
                If (DefaultEnablePartita = True) Then
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), True, DefDtGridCol_PartitaMateriale, True)
                Else
                    RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "CHARG", clsAppTranslation.GetSingleParameterValue(307, "", "Partita"), False, DefDtGridCol_PartitaMateriale, True)
                End If
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "GESME", clsAppTranslation.GetSingleParameterValue(379, "", "Qta Tot."), True, DefDtGridCol_QtaTotale, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "VERME", clsAppTranslation.GetSingleParameterValue(85, "", "Qta Disp."), True, DefDtGridCol_QtaDisponibile, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "MEINS", clsAppTranslation.GetSingleParameterValue(86, "", "UdM"), True, DefDtGridCol_UnitaDiMisura, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "LENUM", clsAppTranslation.GetSingleParameterValue(315, "", "Unità Magazzino"), True, DefDtGridCol_UnitaMagazzino, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "SONUM", clsAppTranslation.GetSingleParameterValue(316, "", "Num.Stock spec."), True, DefDtGridCol_UnitaMagazzino, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "BESTQ", clsAppTranslation.GetSingleParameterValue(380, "", "Tipo Stock"), True, DefDtGridCol_TipoStock, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "ZWMS_SKU_PALLET", clsAppTranslation.GetSingleParameterValue(1646, "", "SKU"), True, DefDtGridCol_SKU, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridStockInfo01, "", "ZZCDLEGACY", clsAppTranslation.GetSingleParameterValue(1647, "", "Cod.Legacy"), True, DefDtGridCol_CodiceMaterialeLegacy, True)


                clsWmsJob.objDataTableGiacenzeOriInfoTotStock.DefaultView.AllowNew = False 'DISABILITO POSSIBILITA DI CREARE UNA  NUOVA RIGA
            End If

            SetDataGridColumnStylesTotStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStylesTotStock = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Public Function RefreshMaterialeInfoTotStock() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshMaterialeInfoTotStock = 1 'INIT AT ERROR

            'VISUALIZZO DATI MATERIALE
            Me.txtInfoJobSelezionato01.Text = clsShowUtility.FromSapWmGiacenzaStrucToString(MaterialeGiacenza, 0)

            RefreshMaterialeInfoTotStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Function GetSelectedStockInfoTotStock(ByRef outSelezioneOk As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSelectedStockInfoTotStock = 1 'INIT AT ERROR

            outSelezioneOk = False 'init

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            If (Not (clsWmsJob.objDataTableGiacenzeOriInfoTotStock Is Nothing)) Then
                If (clsWmsJob.objDataTableGiacenzeOriInfoTotStock.Rows.Count > 0) Then
                    'SE HO SELEZIONATO UNA RIGA
                    If Me.DtGridStockInfo01.CurrentRowIndex >= 0 Then
                        'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
                        WorkDataRow = clsWmsJob.objDataTableGiacenzeOriInfoTotStock.Rows(Me.DtGridStockInfo01.CurrentRowIndex)
                        If (Not (WorkDataRow Is Nothing)) Then
                            'SETTO I DATI DELLA GIACENZA SELEZIONATA
                            RetCode = clsSapUtility.FromGiacenzaDataRowToSapWmGiacenza(WorkDataRow, MaterialeGiacenza, False)
                            If (RetCode = 0) Then
                                outSelezioneOk = True 'UNICO CASO DI SELEZIONE OK
                                'VISUALIZZO DATI CORRENTI
                                RetCode = RefreshMaterialeInfoTotStock()
                            End If
                        End If
                    End If
                End If
            End If

            GetSelectedStockInfoTotStock = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Private Sub DtGridStockInfo01_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridStockInfo01.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim UserSelezioneOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'SE LA GRIGLIA HA DEI DATI E LO USER HA SELEZIONATO UNA GIACENZA ALLORA PRENDO QUESTA UBICAZIONE COME
            RetCode = GetSelectedStockInfoTotStock(UserSelezioneOk)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

End Class