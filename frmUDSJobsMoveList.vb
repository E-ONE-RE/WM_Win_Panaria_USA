
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmUDSJobsMoveList
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmUDSJobsMoveList"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    Private ErrDescription As String

    Public Shared SourceForm As Form


    Public Sub KeyPressed(ByVal inKey As Integer)
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'Dim e As New System.Windows.Forms.KeyPressEventArgs(ChrW(inKey))

            'Call frmEM_FromJob_Part_1_SelUbiSpunta_KeyPress(Me, e)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub frmUDSJobsMoveList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.grpTaskFullPartialModeExecution.Text = clsAppTranslation.GetSingleParameterValue(1658, Me.grpTaskFullPartialModeExecution.Text, "Filtri Selezione")
            Me.Text = clsAppTranslation.GetSingleParameterValue(1459, Me.Text, "Lista UDS da Movimentare")
            Me.cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, Me.cmdAbortScreen.Text, "Annulla")
            Me.btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, Me.btnOK.Text, "OK")
            Me.rdbAll.Text = clsAppTranslation.GetSingleParameterValue(1657, Me.rdbAll.Text, "Mostra Tutti")
            Me.rdbToStaging.Text = clsAppTranslation.GetSingleParameterValue(1453, Me.rdbToStaging.Text, "Verso Staging")
            Me.rdbToTruck.Text = clsAppTranslation.GetSingleParameterValue(1454, Me.rdbToTruck.Text, "Verso Camion")
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")
            Me.lblCodiceUM.Text = clsAppTranslation.GetSingleParameterValue(1573, Me.lblCodiceUM.Text, "UDS")
            Me.lblNumeroTrasporto.Text = clsAppTranslation.GetSingleParameterValue(1482, Me.lblNumeroTrasporto.Text, "TRASPORTO")
            Me.lblNumeroConsegna.Text = clsAppTranslation.GetSingleParameterValue(1327, Me.lblNumeroConsegna.Text, "CONSEGNA")
            Me.lblUbicazione.Text = clsAppTranslation.GetSingleParameterValue(950, Me.lblUbicazione.Text, "UBICAZIONE")
            '************************************** 

            'CHIAMO WEB SERVICE UDS da MOVIMENTARE
            'LoadDataTable(clsUser.SapWmsUser.WERKS, "", "", "", "")

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'CONTEGGIO IL NUMERO DI RIGHE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & ""


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'DEVO AVERE SELEZIONATO UNA RIGA
            If (Me.DtGridInfo.CurrentRowIndex < 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & clsAppTranslation.GetSingleParameterValue(541, "", "Selezionare una riga della griglia.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'IMPOSTO IL DATA ROW DELL'ELEMENTO DI CUI VISUALIZZARE I DATI
            WorkDataRow = clsMoveUDS.objDataTableUDCInfo.Rows(Me.DtGridInfo.CurrentRowIndex)

            'DEVONO ESSER PRESENTI DATI NEL RECORD
            If (WorkDataRow Is Nothing) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(445, "", "Attenzione!") & vbCrLf & "Oggetto selezionato non valido (Nothing)."
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else

            If rdbToStaging.Checked Then
                'PASSO ALLO VIDEATA DEL MOVE UDS
                frmPickingMerci_MoveUDS_1_UM_OriForm = New frmPickingMerci_MoveUDS_1_UM_Ori
                frmPickingMerci_MoveUDS_1_UM_OriForm.Show()
                Me.Close()
            Else
                'PASSO ALLO VIDEATA DEL MOVE TRUCK
                frmTruckLoad_1_UM_SelForm = New frmTruckLoad_1_UM_Sel
                frmTruckLoad_1_UM_SelForm.Show()
                Me.Close()
            End If


#End If


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
            If (Me.DtGridInfo.TableStyles.Count = 0) Then

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "WERKS", clsAppTranslation.GetSingleParameterValue(556, "", "Div."), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGNUM", clsAppTranslation.GetSingleParameterValue(1165, "", "NMg"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ICON_ID", clsAppTranslation.GetSingleParameterValue(1448, "", "Icon Id"), True, 75, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "TKNUM", clsAppTranslation.GetSingleParameterValue(1451, "", "Trasporto"), True, 110, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMS_STOP_SEQ", clsAppTranslation.GetSingleParameterValue(1449, "", "Stop"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMS_DROP_SEQ", clsAppTranslation.GetSingleParameterValue(1450, "", "Drop"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "NUM_CONS_VBELV", clsAppTranslation.GetSingleParameterValue(1327, "", "Consegna"), True, 110, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S"), True, 110, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMS_PESOMAT_USA", clsAppTranslation.GetSingleParameterValue(1705, "", "Peso Mat.") & " (LB)", True, 110, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(1167, "", "Ubic."), True, 150, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP_DOOCK_DOOR", clsAppTranslation.GetSingleParameterValue(320, "", "Dock Door"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA_DOOCK_DOOR", clsAppTranslation.GetSingleParameterValue(320, "", "Dock Door"), True, 50, True)

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

    Private Sub cmdAbortScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbortScreen.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = clsAppTranslation.GetSingleParameterValue(282, "", "Si desidera veramente abbandonare la procedura ? (SI/NO)")
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer <> Windows.Forms.DialogResult.Yes) Then
                Exit Sub
            End If


            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else
            If (SourceForm Is Nothing) Then
                'RITORNO AL MENU DI PARTENZA
                RetCode = clsUscitaMerci.Go_To_Original_Menu(Me)
            Else
                'RITORNO ALLE VIDEATE DI PROVENIENZA
                If (SourceForm.GetType.Name = frmPickingMerci_MoveUDS_1_UM_Ori.Name) Then
                    'PASSO ALLO VIDEATA DEL MOVE UDS
                    frmPickingMerci_MoveUDS_1_UM_OriForm = New frmPickingMerci_MoveUDS_1_UM_Ori
                    frmPickingMerci_MoveUDS_1_UM_OriForm.Show()
                    SourceForm = Nothing
                    Me.Close()
                ElseIf (SourceForm.GetType.Name = frmTruckLoad_1_UM_Sel.Name) Then
                    'PASSO ALLO VIDEATA DEL MOVE TRUCK
                    frmTruckLoad_1_UM_SelForm = New frmTruckLoad_1_UM_Sel
                    frmTruckLoad_1_UM_SelForm.Show()
                    SourceForm = Nothing
                    Me.Close()
                Else
                    'RITORNO AL MENU DI PARTENZA
                    SourceForm = Nothing
                    RetCode = clsUscitaMerci.Go_To_Original_Menu(Me)
                End If
            End If


#End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Sub cmdSearchUDS_Click(sender As Object, e As EventArgs) Handles cmdSearchUDS.Click
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ChekUbicazioneOk As Boolean = False
        Dim WorkOutUbicazione As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '>>> GESTIONE DEL BARCODE REVERSE DI PANARIA USA ( IL BARCODE E' SCRITTO ALLA ROVESCIA )
            If (clsUtility.IsStringValid(Me.txtUbicazione.Text, True) = True) Then
                RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtUbicazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
                If (ChekUbicazioneOk = False) Then
                    Exit Sub
                End If
                Me.txtUbicazione.Text = WorkOutUbicazione
            End If

            If (clsUtility.IsStringValid(Me.txtStagingDestinazione.Text, True) = True) Then
                RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtStagingDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
                If (ChekUbicazioneOk = False) Then
                    Exit Sub
                End If
                Me.txtStagingDestinazione.Text = WorkOutUbicazione
            End If

            If (clsUtility.IsStringValid(Me.txtDockDestinazione.Text, True) = True) Then
                RetCode = clsShowUtility.CheckUbicazioneEnteredString(Me.txtDockDestinazione.Text, ChekUbicazioneOk, True, WorkOutUbicazione)
                If (ChekUbicazioneOk = False) Then
                    Exit Sub
                End If
                Me.txtDockDestinazione.Text = WorkOutUbicazione
            End If


            'RECUPERO I DATI DELLE UDS DA SAP IN BASE AI FILTRI DEFINITI
            RetCode = LoadDataTable()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Private Function LoadDataTable() As Long
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkGetUdsToStaging As Boolean = False
        Dim WorkGetUdsToLoad As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Me.rdbToStaging.Checked = True) Then
                WorkGetUdsToStaging = True
            End If
            If (Me.rdbToTruck.Checked = True) Then
                WorkGetUdsToLoad = True
            End If


            'CHIAMO WEB SERVICE UDS da MOVIMENTARE
            RetCode = clsSapWS.Call_ZWS_GET_UDS_TO_MOVE(clsUser.GetUserDivisionToUse, WorkGetUdsToStaging, WorkGetUdsToLoad, Me.txtCodiceUM.Text, Me.txtNumeroTrasporto.Text, Me.txtNumeroConsegna.Text, Me.txtUbicazione.Text, Me.txtStagingDestinazione.Text, Me.txtDockDestinazione.Text, True, clsUser.SapWmsUser.LANGUAGE, False, clsMoveUDS.objDataTableUDCInfo, SapFunctionError, False)


            If Not (clsMoveUDS.objDataTableUDCInfo Is Nothing) Then
                clsMoveUDS.objDataTableUDCInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsMoveUDS.objDataTableUDCInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
            Call RefreshDatiMaterialeAttivo()

            'CONTEGGIO IL NUMERO DI RIGHE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsMoveUDS.objDataTableUDCInfo.Rows.Count

            LoadDataTable = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            LoadDataTable = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Function


    Private Sub DtGridInfo_CurrentCellChanged(sender As Object, e As EventArgs) Handles DtGridInfo.CurrentCellChanged
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'ESEGUO IL REFRESH DELLA VIDEATE CON L'ELENCO DELLE UM IMMESSE
            Call RefreshDatiMaterialeAttivo()

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
        Dim WorkSapUDSInfo As clsDataType.SapUDSInfo
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDatiMaterialeAttivo = 1 'INIT AT ERROR

            Me.txtInfoRowSelected.Text = ""

            If (clsMoveUDS.objDataTableUDCInfo Is Nothing) Then
                RefreshDatiMaterialeAttivo = 0
                Exit Function
            End If

            'AGGIORNO LA LISTA CON LE INFORMAZIONI DELLA VIDEATA
            If (Me.DtGridInfo.CurrentRowIndex <> -1) Then
                clsMoveUDS.FromDataRowToSapUDSInfoStruct(clsMoveUDS.objDataTableUDCInfo.Rows(Me.DtGridInfo.CurrentRowIndex), WorkSapUDSInfo, False)

                Me.txtInfoRowSelected.Text += clsMoveUDS.ShowSingleUDSInfo(WorkSapUDSInfo, Nothing, 0) & vbCrLf
            Else
                Exit Function
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