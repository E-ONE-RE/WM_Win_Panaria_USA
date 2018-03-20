
Imports clsSapWS
Imports clsNavigation
Imports clsDataType
Imports System.Data

Public Class frmUDCJobsMoveList
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "frmUDCJobsMoveList"

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

    Private Sub frmUDCJobsMoveList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = clsAppTranslation.GetSingleParameterValue(1447, Me.Text, "Lista UDC da Movimentare")

            cmdAbortScreen.Text = clsAppTranslation.GetSingleParameterValue(7, cmdAbortScreen.Text, "Annulla")
            btnOK.Text = clsAppTranslation.GetSingleParameterValue(8, btnOK.Text, "OK")

            grpTaskFullPartialModeExecution.Text = clsAppTranslation.GetSingleParameterValue(1455, grpTaskFullPartialModeExecution.Text, "Filtro")

            rdbUDCToIdentify.Text = clsAppTranslation.GetSingleParameterValue(1803, rdbUDCToIdentify.Text, "UDC da identificare (902)")
            rdbUDCIdentified.Text = clsAppTranslation.GetSingleParameterValue(1804, rdbUDCIdentified.Text, "UDC identificati (Tutti)")

            rdbUDCIdentifiedProd.Text = clsAppTranslation.GetSingleParameterValue(1805, rdbUDCIdentifiedProd.Text, "UDC identificati Produzione (PRDST1)")
            rdbUDCIdentifiedExt.Text = clsAppTranslation.GetSingleParameterValue(1806, rdbUDCIdentifiedExt.Text, "UDC identificati Produzione (IMPSE1)")

            rdbUDCStaging.Text = clsAppTranslation.GetSingleParameterValue(1458, rdbUDCStaging.Text, "UDC in baia di staging")


            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1322, "", "N° UDC/S: ")

            '************************************** 

            'CHIAMO WEB SERVICE ANAGRAFICA CARRELLISTI
            RefreshMonitorInfo()

            'imposto la formattazione delle colonne
            'RetCode += SetDataGridColumnStyles()

            'IMPOSTO LE PROPRIETA STANDARD DELLA FINESTRA PER L'APPLICAZIONE
            RetCode = clsShowUtility.SetStandardApplicationFormProperties(Me, False)

            'ESEGO RESIZE DELLA FINESTRA IN BASE ALLA RISOLUZIONE ATTIVA NEL DISPOSITIVO
            'RetCode = clsShowUtility.FormResizeControls(Me, EnableFormResizeControls, sender, e)


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
        Dim RetCode As Long = 0
        Dim WorkDataRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'DEVO AVERE SELEZIONATO UNA RIGA
            If Me.DtGridInfo.CurrentRowIndex < 0 Then
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

            'IMPOSTO I DATI DEL CARRELLO SELEZIONATO
            'clsUser.SapWmsUser.ZID_WMS_FORKLIFT = WorkDataRow.Item("ZID_WMS_FORKLIFT")


            'Aggiorno dati form
#If Not APPLICAZIONE_WIN32 = "SI" Then
            frmMainHomeMenuForm.RefreshForm()
#Else

            clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUDCJobsMoveList
            RetCode = clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUDCJobsMoveList, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeNext, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MATNR", clsAppTranslation.GetSingleParameterValue(243, "", "Materiale"), True, 150, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "CHARG", clsAppTranslation.GetSingleParameterValue(1, "", "Partita"), True, 110, True)

                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MBLNR", clsAppTranslation.GetSingleParameterValue(1387, "", "Doc.Mat."), True, 120, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "MJAHR", clsAppTranslation.GetSingleParameterValue(1386, "", "EsMat"), True, 120, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZEILE", clsAppTranslation.GetSingleParameterValue(423, "", "Pos."), True, 50, True)

                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ICON_ID", clsAppTranslation.GetSingleParameterValue(1448, "", "Icon Id"), True, 75, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "TKNUM", clsAppTranslation.GetSingleParameterValue(1451, "", "Trasporto"), True, 110, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMS_STOP_SEQ", clsAppTranslation.GetSingleParameterValue(1449, "", "Stop"), True, 50, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "ZWMS_DROP_SEQ", clsAppTranslation.GetSingleParameterValue(1450, "", "Drop"), True, 50, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "NUM_CONS_VBELV", clsAppTranslation.GetSingleParameterValue(1327, "", "Consegna"), True, 110, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LENUM", clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S"), True, 110, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP", clsAppTranslation.GetSingleParameterValue(1166, "", "Cat"), True, 50, True)
                RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA", clsAppTranslation.GetSingleParameterValue(1167, "", "Ubic."), True, 120, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGTYP_DOOCK_DOOR", clsAppTranslation.GetSingleParameterValue(320, "", "Dock Door"), True, 50, True)
                'RetCode += clsUtility.SetDataGridColumnStyle(Me.DtGridInfo, "", "LGPLA_DOOCK_DOOR", clsAppTranslation.GetSingleParameterValue(320, "", "Dock Door"), True, 50, True)

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

            'RITORNO AL MENU DI ENTRATA MERCE

            clsEMFromStock.EM_StockSourceType = clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUDCJobsMoveList
            RetCode = clsNavigation.Show_Ope_EntrataMerci_FromStock(Me, clsEMFromStock.EM_Stock_SourceType.EM_Stock_SourceTypeUDCJobsMoveList, clsDataType.WizardDirectionStepType.WizardDirectionStepTypePrevious, True)
            If (RetCode <> 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(281, "", "Errore nell'apertura della form. Verificare e riprovare.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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


    Private Sub RefreshMonitorInfo()
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'CHIAMO WEB SERVICE 
            RetCode = clsSapWS.Call_ZWS_GET_UDC_TO_MOVE(clsUser.SapWmsUser.WERKS, rdbUDCToIdentify.Checked, rdbUDCIdentified.Checked, rdbUDCIdentifiedProd.Checked, rdbUDCIdentifiedExt.Checked, rdbUDCStaging.Checked, clsUser.SapWmsUser.LANGUAGE, False, clsMoveUDS.objDataTableUDCInfo, SapFunctionError, False)


            If Not (clsMoveUDS.objDataTableUDCInfo Is Nothing) Then
                clsMoveUDS.objDataTableUDCInfo.DefaultView.AllowNew = False '>>> NON PERMETTO CREAZIONE NUOVE RIGHE NELLA DATAGRID
                Me.DtGridInfo.DataSource = clsMoveUDS.objDataTableUDCInfo
            End If


            'imposto la formattazione delle colonne
            RetCode += SetDataGridColumnStyles()

            'CONTEGGIO IL NUMERO DI RIGHE
            Me.lblInfoUDC.Text = clsAppTranslation.GetSingleParameterValue(1241, "", "N° UDC/S: ") & clsMoveUDS.objDataTableUDCInfo.Rows.Count

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

    Private Sub cmdSearchUDS_Click(sender As Object, e As EventArgs) Handles cmdSearchUDC.Click
        '**************************************
        'imposta la visualizzazione di tutte le colonne della DATA GRID
        '**************************************

        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshMonitorInfo()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try

    End Sub

End Class