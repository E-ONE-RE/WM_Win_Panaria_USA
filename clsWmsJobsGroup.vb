' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/12/2014
' DATA MODIFICA     : 18/12/2014
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni della ESECUZIONE DI UN JOBS GROUP
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic

Public Class clsWmsJobsGroup


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsWmsJobsGroup"

    Public Shared WmsJobsGroupInfo As clsDataType.SapJobsGroupInfo

    ' OGGETTI DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableWmsJobGroupList As New DataTable
    Public Shared objDataTablePickUMInfo As New DataTable

    Public Shared objDataTableDetailsWmsJobGroup As New DataTable

    'OGGETTO ROW PER LA VISUALIZZAZIONE DEL DETTAGLIO DEI DATI
    Public Shared objDetailsDataRow As Data.DataRow

    Public Shared UserFilterGetList As clsDataType.SapWmGiacenza

    Private Shared ErrDescription As String
    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError

    Public Shared RowIndex As Long

    Public Shared inSapWmWmsJob As clsDataType.SapWmWmsJob


    Public Shared Function ClearAllData() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearAllData = 1 'init at error

            RetCode += ClearWmsJobGroupListInfo()

            RetCode += clsSapUtility.ResetWmsJobsGroupInfoStruct(WmsJobsGroupInfo)


            'FilterDivisione = ""
            RowIndex = 0

            If (Not (objDataTablePickUMInfo Is Nothing)) Then
                objDataTablePickUMInfo.Rows.Clear()
            End If

            'If (Not (objDataTableDetailsWmsJobGroup Is Nothing)) Then
            '    objDataTableDetailsWmsJobGroup.Rows.Clear()
            'End If

            If (Not (objDataTableWmsJobGroupList Is Nothing)) Then
                objDataTableWmsJobGroupList.Rows.Clear()
            End If

            ClearAllData = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearAllData = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsValidJobsGroup() As Boolean
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        IsValidJobsGroup = False
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (clsUtility.IsStringValid(WmsJobsGroupInfo.NumeroJobsGroup, True) = True) Then
                IsValidJobsGroup = True
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsValidJobsGroup = False 'CONDIZIONE DI CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckJobsGroupOkxClose(ByRef outJobsGroupOkxClose As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ********************************************************************************
        ' DESCRIZIONE : verifica se ci sono le condizioni per chiudere il GRUPPO MISSIONI
        ' ********************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckJobsGroupOkxClose = 1 'init at error
            outJobsGroupOkxClose = False

            If (clsUtility.IsStringValid(WmsJobsGroupInfo.NumeroJobsGroup, True) = False) Then
                RetCode = 10
                CheckJobsGroupOkxClose = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(979, "", "CHECK CHIUSURA del JOBS GROUP. [NumeroJobsGroup] non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            RetCode += clsSapWS.Call_ZWS_CHECK_JOBGROUP_OK_X_CLOSE(WmsJobsGroupInfo.NumeroJobsGroup, clsUser.SapWmsUser.LANGUAGE, outJobsGroupOkxClose, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                RetCode = 200
                CheckJobsGroupOkxClose = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(980, "", "CHECK dati per CHIUSURA JOBS GROUP.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (outJobsGroupOkxClose = False) Then
                RetCode = 0 '>>> ESECUZIONE OK MA NON CI SONO LE CONDIZIONI PER LA CHIUSURA
                CheckJobsGroupOkxClose = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(732, "", "Gruppo non OK per la CHIUSURA. Esiste almeno una missione non terminata.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            CheckJobsGroupOkxClose = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckJobsGroupOkxClose = 1000 'CASO DI CATCH ERROR!
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckJobsGroupOkBeforeActivate(ByRef outJobsGroupOkBeforeActivate As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ********************************************************************************
        ' DESCRIZIONE : verifica se ci sono le condizioni per chiudere il GRUPPO MISSIONI
        ' ********************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim UserAnswer As DialogResult
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckJobsGroupOkBeforeActivate = 1 'init at error

            outJobsGroupOkBeforeActivate = False


            'SE SONO STATE CANCELLATE DELLE MISSIONI ALLORA LO SEGNALO ALL'OPERATORE CHE PUO' COMUNQUE CONTINUARE
            If (clsWmsJobsGroup.WmsJobsGroupInfo.FoundRowsDeleted > 0) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(651, "", "Attenzione! Verificate righe:") & Trim(Val(clsWmsJobsGroup.WmsJobsGroupInfo.FoundRowsDeleted)) & clsAppTranslation.GetSingleParameterValue(652, "", " in stato CANCELLATO/ANNULLATO.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(654, "", "Contattare l'ufficio spedizioni per verificare la lista.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                ErrDescription = clsAppTranslation.GetSingleParameterValue(653, "", "Dopo la verifica con l'ufficio spedizioni") & vbCrLf & clsAppTranslation.GetSingleParameterValue(352, "", "Si desidera ESEGUIRE il GRUPPO MISSIONI selezionato ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    RetCode = 10
                    CheckJobsGroupOkBeforeActivate = RetCode
                    Exit Function
                End If
            End If

            If (clsUtility.IsStringValid(clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione, True) = True) And (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione <> clsUser.SapWmsUser.ZCARR) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(351, "", "Il GRUPPO è stato ESEGUITO da ") & clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione & vbCrLf & clsAppTranslation.GetSingleParameterValue(352, "", "Si desidera ESEGUIRE il GRUPPO MISSIONI selezionato ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    RetCode = 20
                    CheckJobsGroupOkBeforeActivate = RetCode
                    Exit Function
                End If
            End If
            If (clsUtility.IsStringValid(clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaProposto, True) = True) And (clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaEsecuzione <> clsUser.SapWmsUser.ZCARR) Then
                ErrDescription = clsAppTranslation.GetSingleParameterValue(353, "", "Il GRUPPO è stato ATTRIBUITO a ") & clsWmsJobsGroup.WmsJobsGroupInfo.IdCarrellistaProposto & vbCrLf & clsAppTranslation.GetSingleParameterValue(352, "", "Si desidera ESEGUIRE il GRUPPO MISSIONI selezionato ?")
                UserAnswer = MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (UserAnswer <> DialogResult.Yes) Then
                    RetCode = 30
                    CheckJobsGroupOkBeforeActivate = RetCode
                    Exit Function
                End If
            End If


            outJobsGroupOkBeforeActivate = True 'SE ARRIVO QUI IL CHECK E' OK

            CheckJobsGroupOkBeforeActivate = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckJobsGroupOkBeforeActivate = 1000 'CASO DI CATCH ERROR!
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckJobsGroupMaterialOk(ByRef outJobsGroupMaterialOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ********************************************************************************
        ' DESCRIZIONE : verifica se ci sono le condizioni per chiudere il GRUPPO MISSIONI
        ' ********************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            CheckJobsGroupMaterialOk = 1 'init at error
            outJobsGroupMaterialOk = False

            If (clsUtility.IsStringValid(WmsJobsGroupInfo.NumeroJobsGroup, True) = False) Then
                RetCode = 10
                CheckJobsGroupMaterialOk = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(981, "", "CHECK GIACENZA JOBS GROUP. [NumeroJobsGroup] non valido.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            RetCode += clsSapWS.Call_ZWS_CHECK_JOBSGROUP_MATNR_OK(WmsJobsGroupInfo.NumeroJobsGroup, clsUser.SapWmsUser.LANGUAGE, outJobsGroupMaterialOk, Nothing, SapFunctionError, False)
            If (RetCode <> 0) Then
                RetCode = 200
                CheckJobsGroupMaterialOk = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(712, "", "Errore in CHECK GIACENZA JOBS GROUP.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (outJobsGroupMaterialOk = False) Then
                RetCode = 0 '>>> ESECUZIONE OK MA NON CI SONO LE CONDIZIONI PER LA CHIUSURA
                CheckJobsGroupMaterialOk = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(982, "", "Attenzione! Giacenza del GRUPPO MISSIONE NON VALIDA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(714, "", "Andare in UFFICIO e verificare merce con RESPONSABILE.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            CheckJobsGroupMaterialOk = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckJobsGroupMaterialOk = 1000 'CASO DI CATCH ERROR!
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForWmsJobGroupList() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con JOB GROUP LIST INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForWmsJobGroupList = 1 'init at error


            Dim WorkNUM_ACCORPAMENTI As DataColumn = New DataColumn("NUM_ACCORPAMENTI") 'declaring a column named Name
            WorkNUM_ACCORPAMENTI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkNUM_ACCORPAMENTI) 'adding the column to table

            Dim WorkZNR_WMS_JOBSGRP As DataColumn = New DataColumn("ZNR_WMS_JOBSGRP") 'declaring a column named Name
            WorkZNR_WMS_JOBSGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZNR_WMS_JOBSGRP) 'adding the column to table

            Dim WorkZNRPICK As DataColumn = New DataColumn("ZNRPICK") 'declaring a column named Name
            WorkZNRPICK.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZNRPICK) 'adding the column to table

            Dim WorkZWMS_JOBSGRP_DESCR As DataColumn = New DataColumn("ZWMS_JOBSGRP_DESCR") 'declaring a column named Name
            WorkZWMS_JOBSGRP_DESCR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZWMS_JOBSGRP_DESCR) 'adding the column to table

            Dim WorkZDOC As DataColumn = New DataColumn("ZDOC") 'declaring a column named Name
            WorkZDOC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZDOC) 'adding the column to table

            Dim WorkNUM_DOC As DataColumn = New DataColumn("NUM_DOC") 'declaring a column named Name
            WorkNUM_DOC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkNUM_DOC) 'adding the column to table

            Dim WorkRIF_ODA_BSTKD As DataColumn = New DataColumn("RIF_ODA_BSTKD") 'declaring a column named Name
            WorkRIF_ODA_BSTKD.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkRIF_ODA_BSTKD) 'adding the column to table

            Dim WorkRIF_ODV_IHREZ As DataColumn = New DataColumn("RIF_ODV_IHREZ") 'declaring a column named Name
            WorkRIF_ODV_IHREZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkRIF_ODV_IHREZ) 'adding the column to table

            Dim WorkWERKS_DEST As DataColumn = New DataColumn("WERKS_DEST") 'declaring a column named Name
            WorkWERKS_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkWERKS_DEST) 'adding the column to table

            Dim WorkLGORT_DEST As DataColumn = New DataColumn("LGORT_DEST") 'declaring a column named Name
            WorkLGORT_DEST.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkLGORT_DEST) 'adding the column to table

            Dim WorkZCARR_PROP As DataColumn = New DataColumn("ZCARR_PROP") 'declaring a column named Name
            WorkZCARR_PROP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZCARR_PROP) 'adding the column to table

            Dim WorkZCARR_EXEC As DataColumn = New DataColumn("ZCARR_EXEC") 'declaring a column named Name
            WorkZCARR_EXEC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkZCARR_EXEC) 'adding the column to table

            Dim WorkTOT_NUM_SCATOLE As DataColumn = New DataColumn("TOT_NUM_SCATOLE") 'declaring a column named Name
            WorkTOT_NUM_SCATOLE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkTOT_NUM_SCATOLE) 'adding the column to table

            Dim WorkTOT_NUM_M2 As DataColumn = New DataColumn("TOT_NUM_M2") 'declaring a column named Name
            WorkTOT_NUM_M2.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkTOT_NUM_M2) 'adding the column to table

            Dim WorkTOT_NUM_PZ As DataColumn = New DataColumn("TOT_NUM_PZ") 'declaring a column named Name
            WorkTOT_NUM_PZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkTOT_NUM_PZ) 'adding the column to table

            Dim WorkTOT_NUM_OTHERS As DataColumn = New DataColumn("TOT_NUM_OTHERS") 'declaring a column named Name
            WorkTOT_NUM_OTHERS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkTOT_NUM_OTHERS) 'adding the column to table

            '>>> INFORMAZIONI PARTNER SAP [AG]
            Dim WorkPARTNER_AG_KUNNR As DataColumn = New DataColumn("PARTNER_AG_KUNNR") 'declaring a column named Name
            WorkPARTNER_AG_KUNNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_KUNNR) 'adding the column to table

            Dim WorkPARTNER_AG_NAME1 As DataColumn = New DataColumn("PARTNER_AG_NAME1") 'declaring a column named Name
            WorkPARTNER_AG_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_NAME1) 'adding the column to table

            Dim WorkPARTNER_AG_NAME2 As DataColumn = New DataColumn("PARTNER_AG_NAME2") 'declaring a column named Name
            WorkPARTNER_AG_NAME2.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_NAME2) 'adding the column to table

            Dim WorkPARTNER_AG_ORT01 As DataColumn = New DataColumn("PARTNER_AG_ORT01") 'declaring a column named Name
            WorkPARTNER_AG_ORT01.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_ORT01) 'adding the column to table

            Dim WorkPARTNER_AG_PSTLZ As DataColumn = New DataColumn("PARTNER_AG_PSTLZ") 'declaring a column named Name
            WorkPARTNER_AG_PSTLZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_PSTLZ) 'adding the column to table

            Dim WorkPARTNER_AG_REGIO As DataColumn = New DataColumn("PARTNER_AG_REGIO") 'declaring a column named Name
            WorkPARTNER_AG_REGIO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_REGIO) 'adding the column to table

            Dim WorkPARTNER_AG_STRAS As DataColumn = New DataColumn("PARTNER_AG_STRAS") 'declaring a column named Name
            WorkPARTNER_AG_STRAS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_AG_STRAS) 'adding the column to table


            '>>> INFORMAZIONI PARTNER SAP [WE]
            Dim WorkPARTNER_WE_KUNNR As DataColumn = New DataColumn("PARTNER_WE_KUNNR") 'declaring a column named Name
            WorkPARTNER_WE_KUNNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_KUNNR) 'adding the column to table

            Dim WorkPARTNER_WE_NAME1 As DataColumn = New DataColumn("PARTNER_WE_NAME1") 'declaring a column named Name
            WorkPARTNER_WE_NAME1.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_NAME1) 'adding the column to table

            Dim WorkPARTNER_WE_NAME2 As DataColumn = New DataColumn("PARTNER_WE_NAME2") 'declaring a column named Name
            WorkPARTNER_WE_NAME2.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_NAME2) 'adding the column to table

            Dim WorkPARTNER_WE_ORT01 As DataColumn = New DataColumn("PARTNER_WE_ORT01") 'declaring a column named Name
            WorkPARTNER_WE_ORT01.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_ORT01) 'adding the column to table

            Dim WorkPARTNER_WE_PSTLZ As DataColumn = New DataColumn("PARTNER_WE_PSTLZ") 'declaring a column named Name
            WorkPARTNER_WE_PSTLZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_PSTLZ) 'adding the column to table

            Dim WorkPARTNER_WE_REGIO As DataColumn = New DataColumn("PARTNER_WE_REGIO") 'declaring a column named Name
            WorkPARTNER_WE_REGIO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_REGIO) 'adding the column to table

            Dim WorkPARTNER_WE_STRAS As DataColumn = New DataColumn("PARTNER_WE_STRAS") 'declaring a column named Name
            WorkPARTNER_WE_STRAS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkPARTNER_WE_STRAS) 'adding the column to table

            '>>> INFORMAZIONI PARTNER SAP [FORNITORE]
            Dim WorkFORNITORE_LIFNR As DataColumn = New DataColumn("FORNITORE_LIFNR") 'declaring a column named Name
            WorkFORNITORE_LIFNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_LIFNR) 'adding the column to table

            Dim WorkFORNITORE_NAME11 As DataColumn = New DataColumn("FORNITORE_NAME1") 'declaring a column named Name
            WorkFORNITORE_NAME11.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_NAME11) 'adding the column to table

            Dim WorkFORNITORE_NAME2 As DataColumn = New DataColumn("FORNITORE_NAME2") 'declaring a column named Name
            WorkFORNITORE_NAME2.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_NAME2) 'adding the column to table

            Dim WorkFORNITORE_ORT01 As DataColumn = New DataColumn("FORNITORE_ORT01") 'declaring a column named Name
            WorkFORNITORE_ORT01.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_ORT01) 'adding the column to table

            Dim WorkFORNITORE_PSTLZ As DataColumn = New DataColumn("FORNITORE_PSTLZ") 'declaring a column named Name
            WorkFORNITORE_PSTLZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_PSTLZ) 'adding the column to table

            Dim WorkFORNITORE_REGIO As DataColumn = New DataColumn("FORNITORE_REGIO") 'declaring a column named Name
            WorkFORNITORE_REGIO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_REGIO) 'adding the column to table

            Dim WorkFORNITORE_STRAS As DataColumn = New DataColumn("FORNITORE_STRAS") 'declaring a column named Name
            WorkFORNITORE_STRAS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableWmsJobGroupList.Columns.Add(WorkFORNITORE_STRAS) 'adding the column to table

            CreateDateTableForWmsJobGroupList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForWmsJobGroupList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTablePickUMInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTablePickUMInfo = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkVrkme As DataColumn = New DataColumn("VRKME") 'declaring a column named Name
            WorkVrkme.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkVrkme) 'adding the column to table

            Dim WorkVerme_cons As DataColumn = New DataColumn("VERME_CONS") 'declaring a column named Name
            WorkVerme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkVerme_cons) 'adding the column to table

            Dim WorkGesme_cons As DataColumn = New DataColumn("GESME_CONS") 'declaring a column named Name
            WorkGesme_cons.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkGesme_cons) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkTBNUM As DataColumn = New DataColumn("TBNUM") 'declaring a column named Name
            WorkTBNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkTBNUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkLGORT) 'adding the column to table

            Dim WorkMaktg As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMaktg.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTablePickUMInfo.Columns.Add(WorkMaktg) 'adding the column to table

            CreateDateTablePickUMInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTablePickUMInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetJobsGroupClosed(ByVal inNumeroJobsGroup As String, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobsGroupClosed = 1 'init at error

            outExecutionOk = False

            'ESEGUO LA CHIAMATA PER CHIUDERE IL GRUPPO MISSIONI
            RetCode += clsSapWS.Call_ZWS_SET_JOBSGROUP_CLOSED(inNumeroJobsGroup, True, True, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, WmsJobsGroupInfo, SapFunctionError, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                SetJobsGroupClosed = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(983, "", "CHIUSURA del JOBS GROUP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            SetJobsGroupClosed = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobsGroupClosed = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function SetJobsGroupUbicazDestination(ByVal inNumeroJobsGroup As String, ByRef inSapWmUbicazione As clsDataType.SapWmUbicazione, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetJobsGroupUbicazDestination = 1 'init at error

            outExecutionOk = False

            RetCode += clsSapWS.Call_ZWS_SET_JOBSGROUP_UBI_DEST(inNumeroJobsGroup, inSapWmUbicazione, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, SapFunctionError, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                SetJobsGroupUbicazDestination = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(984, "", "CAMBIO DESTINAZIONE del JOBS GROUP.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(348, "", "Verificare e riprovare")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            SetJobsGroupUbicazDestination = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetJobsGroupUbicazDestination = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromSapJobsGroupInfoToString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapJobsGroupInfoToString = ""

            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(985, "", "GRUPPO MIS:")
                    tmpString += UCase(WmsJobsGroupInfo.NumeroJobsGroup)
                    tmpString += vbCrLf
                    tmpString += WmsJobsGroupInfo.JobsGroupDescription
                    tmpString += vbCrLf

                    If (clsUtility.IsStringValid(WmsJobsGroupInfo.PartnerWEInfo.NAME1, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(986, "", "DEST.:")
                        tmpString += UCase(WmsJobsGroupInfo.PartnerWEInfo.NAME1)
                        tmpString += vbCrLf

                    End If

                    If (clsUtility.IsStringValid(WmsJobsGroupInfo.PartnerAGInfo.NAME1, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(987, "", "CLI.:")
                        tmpString += UCase(WmsJobsGroupInfo.PartnerAGInfo.NAME1)
                        tmpString += vbCrLf
                    End If

                    If (WmsJobsGroupInfo.NumTotaleScatole > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(988, "", "SC:")
                        tmpString += UCase(WmsJobsGroupInfo.NumPickTotaleScatole) + " ( su "
                        tmpString += UCase(WmsJobsGroupInfo.NumTotaleScatole) + ")"
                        tmpString += vbCrLf
                    End If
                    If (WmsJobsGroupInfo.NumTotaleM2 > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(989, "", "M2:")
                        tmpString += UCase(WmsJobsGroupInfo.NumPickTotaleM2) + " ( su "
                        tmpString += UCase(WmsJobsGroupInfo.NumTotaleM2) + ")"
                        tmpString += vbCrLf
                    End If
                    If (WmsJobsGroupInfo.NumTotalePezzi > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(990, "", "PZ:")
                        tmpString += UCase(WmsJobsGroupInfo.NumPickTotalePezzi) + " ( su "
                        tmpString += UCase(WmsJobsGroupInfo.NumTotalePezzi) + ")"
                        tmpString += vbCrLf
                    End If
                    If (WmsJobsGroupInfo.NumTotaleOthers > 0) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(991, "", "OT:")
                        tmpString += UCase(WmsJobsGroupInfo.NumPickTotaleOthers) + " ( su "
                        tmpString += UCase(WmsJobsGroupInfo.NumTotaleOthers) + ")"
                        tmpString += vbCrLf
                    End If
                    If (clsUtility.IsStringValid(WmsJobsGroupInfo.CheckMaterialePronto, True) = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(992, "", "STATO MATER:")
                        tmpString += UCase(WmsJobsGroupInfo.CheckMaterialePronto)
                        tmpString += vbCrLf
                    End If
                    If (WmsJobsGroupInfo.JobsGroupClosed = True) Then
                        tmpString += clsAppTranslation.GetSingleParameterValue(993, "", "GRUPPO CHIUSO")
                        tmpString += vbCrLf
                    End If
            End Select

            FromSapJobsGroupInfoToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapJobsGroupInfoToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsGroupSummary(ByVal inNumeroJobsGroup As String, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ******************************************************************************
        ' DESCRIZIONE : ritorna le informazioni dell'esecuzione del JOB GROUP
        ' ******************************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsGroupSummary = 1 'init at error

            outExecutionOk = False

            'INIT DEI DATI
            RetCode += ClearAllData()

            'CHIAMO WS PER OTTENERE DATI DEL GRUPPO MISSIONI
            RetCode += clsSapWS.Call_ZWS_GET_JOBSGROUP_EXE_SUMMARY(inNumeroJobsGroup, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, GetDataOk, SapFunctionError, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                GetJobsGroupSummary = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & clsAppTranslation.GetSingleParameterValue(994, "", "estrazione dati del JOBS GROUP EXE SUMMARY.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (GetDataOk = False) Then
                RetCode = 220
                GetJobsGroupSummary = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(995, "", "Gruppo non trovato nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobsGroupSummary = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsGroupSummary = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsGroupSingle(ByVal inNumeroJobsGroup As String, ByVal inNumeroConsegna As String, ByVal inNumeroDocumentoMateriale As String, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsGroupSingle = 1 'init at error

            outExecutionOk = False

            RetCode += clsWmsJobsGroup.ClearWmsJobGroupListInfo()
            RetCode += clsWmsJob.ClearForNewPositionRead()

            RetCode += clsSapWS.Call_ZWS_GET_JOBS_GROUP_SINGLE(inNumeroJobsGroup, inNumeroConsegna, inNumeroDocumentoMateriale, True, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, GetDataOk, clsWmsJob.objDataTableWmsJobsList, clsWmsJobsGroup.WmsJobsGroupInfo, SapFunctionError, clsWmsJobsGroup.WmsJobsGroupInfo.FoundGroupDeleted, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                GetJobsGroupSingle = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & "estrazione dati del JOBS GROUP."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (GetDataOk = False) Then
                RetCode = 220
                GetJobsGroupSingle = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(995, "", "Gruppo non trovato nel sistema.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            GetJobsGroupSingle = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsGroupSingle = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsQueueList(ByVal inCurrentWorkQueue As String, ByVal inDivisione As String, ByVal inNumeroMagazzino As String, ByVal inFilterJobNumber As String, ByVal inFilterNumConsegna As String, ByVal inGetQueueForExecution As Boolean, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsQueueList = 1 'init at error

            outExecutionOk = False

            RetCode += clsWmsJobsGroup.ClearWmsJobGroupListInfo()
            RetCode += clsWmsJob.ClearForNewPositionRead()

            'INIZIALIZZO OGGETTO
            clsWmsJob.TaskLines = New clsTaskLines

            If (IsNumeric(inFilterJobNumber)) Then
                inSapWmWmsJob.NrWmsJobs = Val(inFilterJobNumber)
            End If

            If (clsUtility.IsStringValid(inFilterNumConsegna, True) = True) Then
                inSapWmWmsJob.ConsegnaNumero = inFilterNumConsegna
            End If


            RetCode += clsSapWS.Call_ZWMS_GET_JOBS_LIST_QUEUE(inDivisione, inNumeroMagazzino, inCurrentWorkQueue, inSapWmWmsJob, True, False, inGetQueueForExecution, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, clsWmsJob.objDataTableWmsJobsList, clsWmsJob.TaskLines.objDataTableJobTaskLines, clsWmsJob.TaskLines.TaskLinesInfo, clsWmsJob.JobsQueueWeightInfo, clsWmsJob.UDSOnWork, clsForkLift.CurrentForLift, SapFunctionError, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                GetJobsQueueList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & "estrazione dati del JOBS GROUP."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            If (clsUtility.IsDataTableValid(clsWmsJob.objDataTableWmsJobsList, True) = False) Then
                RetCode = 222
                GetJobsQueueList = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(1496, "", "Missioni non trovate nella CODA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If


            GetJobsQueueList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsQueueList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetTaskLinesAssigned(ByVal inCurrentWorkQueue As String, ByVal inDivisione As String, ByVal inNumeroMagazzino As String, ByVal inFilterJobNumber As String, ByVal inFilterNumConsegna As String, ByVal inGetQueueForExecution As Boolean, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        Dim inSapWmWmsJob As clsDataType.SapWmWmsJob
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetTaskLinesAssigned = 1 'init at error

            outExecutionOk = False

            RetCode += clsWmsJobsGroup.ClearWmsJobGroupListInfo()
            RetCode += clsWmsJob.ClearForNewPositionRead()
            RetCode += clsTaskLinesAssigned.ClearAllData()


            'INIZIALIZZO OGGETTO
            clsWmsJob.TaskLines = New clsTaskLines

            If (IsNumeric(inFilterJobNumber)) Then
                inSapWmWmsJob.NrWmsJobs = Val(inFilterJobNumber)
            End If

            If (clsUtility.IsStringValid(inFilterNumConsegna, True) = True) Then
                inSapWmWmsJob.ConsegnaNumero = inFilterNumConsegna
            End If


            RetCode += clsSapWS.Call_ZWMS_GET_USER_TASK_LINES(inNumeroMagazzino, inSapWmWmsJob, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, clsTaskLinesAssigned.objDataTableTaskLinesAssigned, clsWmsJob.TaskLines.TaskLinesInfo, SapFunctionError, False)
            If (outExecutionOk = False) Or (RetCode <> 0) Then
                RetCode = 200
                GetTaskLinesAssigned = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(912, "", "Errore in ") & "estrazione dati del JOBS GROUP."
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If
            'If (clsUtility.IsDataTableValid(clsWmsJob.objDataTableWmsJobsList, True) = False) Then
            '    RetCode = 222
            '    GetTaskLinesAssigned = RetCode
            '    If (inShowMessageBox = True) Then
            '        ErrDescription = clsAppTranslation.GetSingleParameterValue(1496, "", "Missioni non trovate nella CODA.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(417, "", "Verificare i dati e riprovare.")
            '        MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    End If
            '    Exit Function
            'End If


            GetTaskLinesAssigned = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetTaskLinesAssigned = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetJobsGroupList(ByVal inJobTypeFamily As String, ByRef outExecutionOk As Boolean, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : ritorna un DATASET con un ELENCO DI JOBS (STESSO GRUPPO)
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetJobsGroupList = 1 'init at error

            outExecutionOk = False

            RetCode += clsWmsJobsGroup.ClearWmsJobGroupListInfo()

            'FILTRO LE GIACENZE USANDO I FILTRI PASSATI DALL'OPERATORE
            RetCode = clsSapWS.Call_ZWS_GET_JOBS_GROUP_LIST(clsUser.GetUserDivisionToUse, clsUser.GetUserNumeroMagazzinoToUse, inJobTypeFamily, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.USERID, clsUser.SapWmsUser.USERID, True, clsUser.SapWmsUser.LANGUAGE, outExecutionOk, clsWmsJobsGroup.objDataTableWmsJobGroupList, SapFunctionError, False)
            If ((outExecutionOk <> True) Or (RetCode <> 0)) Then
                If (RetCode = 101) Then
                    'CASO DI DATO NON TROVATO
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(478, "", "Nessun dato trovato.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                Else
                    'ERRORE NEL CODICE
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(479, "", "Errore in estrazione dati giacenze.") & vbCrLf & clsAppTranslation.GetSingleParameterValue(415, "", "Verificare i dati inseriti e riprovare.")
                End If
                If (inShowMessageBox = True) Then
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                GetJobsGroupList = RetCode
                Exit Function
            End If

            GetJobsGroupList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetJobsGroupList = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function LoadDataRowFirstJob() As Long
        ' ************************************************************
        ' DESCRIZIONE : carica la classe JOB con il primo JOB del datatable []
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            LoadDataRowFirstJob = 1

            If (clsWmsJob.objDataTableWmsJobsList Is Nothing) Then
                RetCode = 10
                LoadDataRowFirstJob = RetCode
                Exit Function
            End If

            If (clsWmsJob.objDataTableWmsJobsList.Rows.Count <= 0) Then
                RetCode = 20
                LoadDataRowFirstJob = RetCode
                Exit Function
            End If

            'CARICO IL JOB DEL PRIMO RECORD DEL GRUPPO MISSIONE
            RetCode = clsWmsJob.FromDataRowToWmsJobsInfoStruct(clsWmsJob.objDataTableWmsJobsList.Rows(0), clsWmsJob.WmsJob, False)

            LoadDataRowFirstJob = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            LoadDataRowFirstJob = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function JobsGroupsActivate(ByVal inNumeroJobsGroup As String, ByVal inIdCarrellistaEsecuzione As String, ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : Attiva un JOBS GROUP per l'esecuzione di un OPERATORE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim GetDataOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            JobsGroupsActivate = 1 'init at error

            RetCode += clsSapWS.Call_ZWS_SET_JOBSGROUP_ACTIVATE(inNumeroJobsGroup, inIdCarrellistaEsecuzione, clsUser.SapWmsUser.LANGUAGE, GetDataOk, Nothing, SapFunctionError, inShowMessageBox)
            If (GetDataOk = False) Then
                RetCode = 200
                JobsGroupsActivate = RetCode
                If (inShowMessageBox = True) Then
                    ErrDescription = clsAppTranslation.GetSingleParameterValue(962, "", "Attenzione, errore in estrazione dati JOBS GROUP ACTIVATE.")
                    MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                Exit Function
            End If

            JobsGroupsActivate = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            JobsGroupsActivate = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetRowWmsJobsGroupExecutionPickUM(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetRowWmsJobsGroupExecutionPickUM = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Not objDataTablePickUMInfo Is Nothing) Then
                GetRowWmsJobsGroupExecutionPickUM = objDataTablePickUMInfo.Rows.Count
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRowWmsJobsGroupExecutionPickUM = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetRowCountWmsJobGroupList(ByVal inShowMessageBox As Boolean) As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetRowCountWmsJobGroupList = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (Not (objDataTableWmsJobGroupList Is Nothing)) Then
                GetRowCountWmsJobGroupList = objDataTableWmsJobGroupList.Rows.Count
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetRowCountWmsJobGroupList = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetPickUMStorageLocations(ByRef outStorageLocations As Collection) As Long
        ' ************************************************************
        ' DESCRIZIONE : RETURN THE 
        ' ************************************************************
        Dim WorkDataRow As DataRow
        Dim WorkUbicazione As String
        Dim WorkKeyFound As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        GetPickUMStorageLocations = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (outStorageLocations Is Nothing) Then
                outStorageLocations = New Collection
            Else
                outStorageLocations.Clear()
            End If


            If (objDataTablePickUMInfo Is Nothing) Then
                Exit Function
            End If
            For Each WorkDataRow In objDataTablePickUMInfo.Rows
                WorkUbicazione = UCase(clsUtility.GetDataRowItem(WorkDataRow, "LGPLA", ""))
                If (clsUtility.IsStringValid(WorkUbicazione, True) = True) Then
                    WorkKeyFound = outStorageLocations.Contains(WorkUbicazione)
                    If (WorkKeyFound = False) Then
                        outStorageLocations.Add(WorkUbicazione, WorkUbicazione)
                    End If
                End If
            Next

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetPickUMStorageLocations = 0 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromSapJobsGroupInfoStructToString(Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapJobsGroupInfoStructToString = FromSapJobsGroupInfoStructToString(WmsJobsGroupInfo, inShowMode)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapJobsGroupInfoStructToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromSapJobsGroupInfoStructToString(ByRef inSapJobsGroupInfo As clsDataType.SapJobsGroupInfo, Optional ByVal inShowMode As Long = 0) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromSapJobsGroupInfoStructToString = ""

            'inShowMode = 0 (DEFAULT)
            ' >>>> GRP.MIS.:[NumeroJobsGroup] - [JobsGroupDescription]


            Select Case inShowMode
                Case 0
                    tmpString += clsAppTranslation.GetSingleParameterValue(997, "", "GRP:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.NumeroJobsGroup, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.NumeroJobsGroup) + " - "
                    Else
                        tmpString += " - "
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.JobsGroupDescription, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.JobsGroupDescription) + " "
                    Else
                        tmpString += " "
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(998, "", "COMM:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerAGInfo.NAME1, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerAGInfo.NAME1) + " - "
                    Else
                        tmpString += " - "
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerAGInfo.ORT01, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerAGInfo.ORT01) + "-"
                    Else
                        tmpString += "-"
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerAGInfo.REGIO, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerAGInfo.REGIO) + " "
                    Else
                        tmpString += " "
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(999, "", "DEST:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerWEInfo.NAME1, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerWEInfo.NAME1) + " - "
                    Else
                        tmpString += " - "
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerWEInfo.ORT01, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerWEInfo.ORT01) + "-"
                    Else
                        tmpString += "-"
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.PartnerWEInfo.REGIO, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.PartnerWEInfo.REGIO) + " "
                    Else
                        tmpString += " "
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(1000, "", "RIF.:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.RiferimentoOdA, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.RiferimentoOdA) + " - "
                    Else
                        tmpString += " - "
                    End If
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.RiferimentoOdV, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.RiferimentoOdV) + " "
                    Else
                        tmpString += " "
                    End If
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(1001, "", "RI:")
                    tmpString += UCase(inSapJobsGroupInfo.NumAccorpamenti) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(988, "", "SC:")
                    tmpString += UCase(inSapJobsGroupInfo.NumTotaleScatole) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(989, "", "M2:")
                    tmpString += UCase(inSapJobsGroupInfo.NumTotaleM2) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(990, "", "PZ:")
                    tmpString += UCase(inSapJobsGroupInfo.NumTotalePezzi) + " "
                    tmpString += clsAppTranslation.GetSingleParameterValue(1002, "", "VR:")
                    tmpString += UCase(inSapJobsGroupInfo.NumTotaleOthers) + " "
                    tmpString += vbCrLf

                    tmpString += clsAppTranslation.GetSingleParameterValue(1003, "", "CAR.P:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.IdCarrellistaProposto, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.IdCarrellistaProposto) + " "
                    Else
                        tmpString += " "
                    End If
                    tmpString += clsAppTranslation.GetSingleParameterValue(1004, "", "CAR.E:")
                    If (clsUtility.IsStringValid(inSapJobsGroupInfo.IdCarrellistaEsecuzione, True) = True) Then
                        tmpString += UCase(inSapJobsGroupInfo.IdCarrellistaEsecuzione) + ""
                    Else
                        tmpString += ""
                    End If
                    tmpString += vbCrLf

            End Select

            FromSapJobsGroupInfoStructToString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromSapJobsGroupInfoStructToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ReloadDataOfSameJobGroupForNewPick(ByRef inSourceForm As Form) As Long
        ' ************************************************************
        ' DESCRIZIONE :
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim ErrDescription As String

        Dim ExecutionOk As Boolean = False
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ReloadDataOfSameJobGroupForNewPick = 1 'init at error

            'RECUPERO TUTTI I DATI DEL JOBGROUP
            RetCode = clsWmsJobsGroup.GetJobsGroupSingle(clsWmsJob.WmsJob.CodiceGruppoMissioni, Nothing, Nothing, ExecutionOk, False)
            If (ExecutionOk = False) And (RetCode <> 0) Then
                '>>> FACCIO SEGNALAZIONE SONO SE HO AVUTO ERRORE (PER OPERATORE FONDI NON DEVO DARE SEGNALAZIONI)
                ErrDescription = clsAppTranslation.GetSingleParameterValue(996, "", "Attenzione! Dati JOBGROUP non trovati.")
                MessageBox.Show(ErrDescription, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            'PARTO NUOVAMENTE DALLO STEP CHE RICHIEDE DI SELEZIONARE LA MISSIONE DA ESEGUIRE 
            'Call clsNavigation.Show_Ope_PickingMerci_Approntamento(inSourceForm, clsDataType.WizardDirectionStepType.WizardDirectionStepTypeStartGroupSeq, True)

            ReloadDataOfSameJobGroupForNewPick = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ReloadDataOfSameJobGroupForNewPick = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearWmsJobGroupListInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearWmsJobGroupListInfo = 1 'init at error

            If (Not (objDataTableWmsJobGroupList Is Nothing)) Then
                objDataTableWmsJobGroupList.Rows.Clear()
            End If

            ClearWmsJobGroupListInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearWmsJobGroupListInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromDataRowToSapJobsGroupInfoStruct(ByRef inDataRow As DataRow, ByRef outSapJobsGroupInfo As clsDataType.SapJobsGroupInfo, ByVal inShowMessageBox As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromDataRowToSapJobsGroupInfoStruct = 1 'INIT AT ERROR

            If (inDataRow Is Nothing) Then
                RetCode = 10
                FromDataRowToSapJobsGroupInfoStruct = RetCode
                Exit Function
            End If

            outSapJobsGroupInfo.NumAccorpamenti = clsUtility.GetDataRowItem(inDataRow, "NUM_ACCORPAMENTI", "")
            outSapJobsGroupInfo.NumeroJobsGroup = clsUtility.GetDataRowItem(inDataRow, "ZNR_WMS_JOBSGRP", "")
            outSapJobsGroupInfo.NumeroOrdinePicking = clsUtility.GetDataRowItem(inDataRow, "ZNRPICK", "")
            outSapJobsGroupInfo.JobsGroupDescription = clsUtility.GetDataRowItem(inDataRow, "ZWMS_JOBSGRP_DESCR", "")
            outSapJobsGroupInfo.TipoDocumento = clsUtility.GetDataRowItem(inDataRow, "ZDOC", "")
            outSapJobsGroupInfo.NumeroDocumento = clsUtility.GetDataRowItem(inDataRow, "NUM_DOC", "")
            outSapJobsGroupInfo.RiferimentoOdA = clsUtility.GetDataRowItem(inDataRow, "RIF_ODA_BSTKD", "")
            outSapJobsGroupInfo.RiferimentoOdV = clsUtility.GetDataRowItem(inDataRow, "RIF_ODV_IHREZ", "")

            outSapJobsGroupInfo.PartnerAGInfo.KUNNR = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_KUNNR", "")
            outSapJobsGroupInfo.PartnerAGInfo.NAME1 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_NAME1", "")
            outSapJobsGroupInfo.PartnerAGInfo.NAME2 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_NAME2", "")
            outSapJobsGroupInfo.PartnerAGInfo.ORT01 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_ORT01", "")
            outSapJobsGroupInfo.PartnerAGInfo.PSTLZ = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_PSTLZ", "")
            outSapJobsGroupInfo.PartnerAGInfo.REGIO = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_REGIO", "")
            outSapJobsGroupInfo.PartnerAGInfo.STRAS = clsUtility.GetDataRowItem(inDataRow, "PARTNER_AG_STRAS", "")

            outSapJobsGroupInfo.PartnerWEInfo.KUNNR = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_KUNNR", "")
            outSapJobsGroupInfo.PartnerWEInfo.NAME1 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_NAME1", "")
            outSapJobsGroupInfo.PartnerWEInfo.NAME2 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_NAME2", "")
            outSapJobsGroupInfo.PartnerWEInfo.ORT01 = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_ORT01", "")
            outSapJobsGroupInfo.PartnerWEInfo.PSTLZ = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_PSTLZ", "")
            outSapJobsGroupInfo.PartnerWEInfo.REGIO = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_REGIO", "")
            outSapJobsGroupInfo.PartnerWEInfo.STRAS = clsUtility.GetDataRowItem(inDataRow, "PARTNER_WE_STRAS", "")

            outSapJobsGroupInfo.FornitoreInfo.LIFNR = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_LIFNR", "")
            outSapJobsGroupInfo.FornitoreInfo.NAME1 = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_NAME1", "")
            outSapJobsGroupInfo.FornitoreInfo.NAME2 = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_NAME2", "")
            outSapJobsGroupInfo.FornitoreInfo.ORT01 = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_ORT01", "")
            outSapJobsGroupInfo.FornitoreInfo.PSTLZ = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_PSTLZ", "")
            outSapJobsGroupInfo.FornitoreInfo.REGIO = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_REGIO", "")
            outSapJobsGroupInfo.FornitoreInfo.STRAS = clsUtility.GetDataRowItem(inDataRow, "FORNITORE_STRAS", "")

            outSapJobsGroupInfo.DivisioneDestinazione = clsUtility.GetDataRowItem(inDataRow, "WERKS_DEST", "")
            outSapJobsGroupInfo.MagLogicoDestinazione = clsUtility.GetDataRowItem(inDataRow, "LGORT_DEST", "")

            outSapJobsGroupInfo.IdCarrellistaProposto = clsUtility.GetDataRowItem(inDataRow, "ZCARR_PROP", "")
            outSapJobsGroupInfo.IdCarrellistaEsecuzione = clsUtility.GetDataRowItem(inDataRow, "ZCARR_EXEC", "")

            outSapJobsGroupInfo.NumTotaleScatole = clsUtility.GetDataRowItem(inDataRow, "TOT_NUM_SCATOLE", "")
            outSapJobsGroupInfo.NumTotaleM2 = clsUtility.GetDataRowItem(inDataRow, "TOT_NUM_M2", "0")
            outSapJobsGroupInfo.NumTotalePezzi = clsUtility.GetDataRowItem(inDataRow, "TOT_NUM_PZ", "0")
            outSapJobsGroupInfo.NumTotaleOthers = clsUtility.GetDataRowItem(inDataRow, "TOT_NUM_OTHERS", "0")


            FromDataRowToSapJobsGroupInfoStruct = RetCode 'SE = 0 TUTTO OK

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Cursor.Current = Cursors.Default '>>> FINE SEGNALE ATTESA
            FromDataRowToSapJobsGroupInfoStruct = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableDetails() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per griglia DETTAGLI MATERIALE
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableDetails = 1 'init at error

            If objDataTableDetailsWmsJobGroup.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobGroup.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsWmsJobGroup.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobGroup.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsWmsJobGroup.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsWmsJobGroup.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If


            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "NUM_ACCORPAMENTI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(764, "", "Num.Miss.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZNR_WMS_JOBSGRP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(761, "", "Grup.Miss.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZNRPICK"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(762, "", "Ord.Pick.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZWMS_JOBSGRP_DESCR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1437, "", "ZWMS_JOBSGRP_DESCR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZDOC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1399, "", "ZDOC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "NUM_DOC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(422, "", "NUM_DOC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "RIF_ODA_BSTKD"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1438, "", "RIF_ODA_BSTKD")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "RIF_ODV_IHREZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1439, "", "RIF_ODV_IHREZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "WERKS_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1356, "", "WERKS_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "LGORT_DEST"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1357, "", "LGORT_DEST")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZCARR_PROP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(366, "", "ZCARR_PROP")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "ZCARR_EXEC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(367, "", "ZCARR_EXEC")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "TOT_NUM_SCATOLE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(765, "", "TOT_NUM_SCATOLE")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "TOT_NUM_M2"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(766, "", "TOT_NUM_M2")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "TOT_NUM_PZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(767, "", "TOT_NUM_PZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "TOT_NUM_OTHERS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(768, "", "TOT_NUM_OTHERS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_KUNNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1440, "", "PARTNER_AG_KUNNR")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_NAME1"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1441, "", "PARTNER_AG_NAME1")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_NAME2"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1442, "", "PARTNER_AG_NAME2")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_ORT01"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1443, "", "PARTNER_AG_ORT01")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_PSTLZ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1444, "", "PARTNER_AG_PSTLZ")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_REGIO"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1445, "", "PARTNER_AG_REGIO")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsWmsJobGroup.NewRow()
            WorkRow.Item("PropertyId") = "PARTNER_AG_STRAS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1436, "", "PARTNER_AG_STRAS")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsWmsJobGroup.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableDetails = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableDetails = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshDateTableDetailsInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow
        Dim WorkPropertyId As String = ""
        Dim WorkPropertyValue As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableDetailsInfo = 1 'init at error

            If (objDataTableDetailsWmsJobGroup Is Nothing) Then Exit Function

            If (objDataTableDetailsWmsJobGroup.Rows.Count = 0) Then Exit Function

            If (objDetailsDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsWmsJobGroup.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "NUM_ACCORPAMENTI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NUM_ACCORPAMENTI", "")
                    Case "ZNR_WMS_JOBSGRP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNR_WMS_JOBSGRP", "")
                    Case "ZNRPICK"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZNRPICK", "")
                    Case "ZWMS_JOBSGRP_DESCR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZWMS_JOBSGRP_DESCR", "")
                    Case "ZDOC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZDOC", "")
                    Case "NUM_DOC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NUM_DOC", "")
                    Case "RIF_ODA_BSTKD"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "RIF_ODA_BSTKD", "")
                    Case "RIF_ODV_IHREZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "RIF_ODV_IHREZ", "")
                    Case "WERKS_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS_DEST", "")
                    Case "LGORT_DEST"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT_DEST", "")
                    Case "ZCARR_PROP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZCARR_PROP", "")
                    Case "ZCARR_EXEC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZCARR_EXEC", "")
                    Case "TOT_NUM_SCATOLE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TOT_NUM_SCATOLE", "")
                    Case "TOT_NUM_M2"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TOT_NUM_M2", "")
                    Case "TOT_NUM_PZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TOT_NUM_PZ", "")
                    Case "TOT_NUM_OTHERS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "TOT_NUM_OTHERS", "")
                    Case "PARTNER_AG_KUNNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_KUNNR", "")
                    Case "PARTNER_AG_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_NAME1", "")
                    Case "PARTNER_AG_NAME2"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_NAME2", "")
                    Case "PARTNER_AG_ORT01"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_ORT01", "")
                    Case "PARTNER_AG_PSTLZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_PSTLZ", "")
                    Case "PARTNER_AG_REGIO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_REGIO", "")
                    Case "PARTNER_AG_STRAS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_AG_STRAS", "")
                    Case "PARTNER_WE_KUNNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_KUNNR", "")
                    Case "PARTNER_WE_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_NAME1", "")
                    Case "PARTNER_WE_NAME2"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_NAME2", "")
                    Case "PARTNER_WE_ORT01"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_ORT01", "")
                    Case "PARTNER_WE_PSTLZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_PSTLZ", "")
                    Case "PARTNER_WE_REGIO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_REGIO", "")
                    Case "PARTNER_WE_STRAS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PARTNER_WE_STRAS", "")
                    Case "FORNITORE_LIFNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_LIFNR", "")
                    Case "FORNITORE_NAME1"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_NAME1", "")
                    Case "FORNITORE_NAME2"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_NAME2", "")
                    Case "FORNITORE_ORT01"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_ORT01", "")
                    Case "FORNITORE_PSTLZ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_PSTLZ", "")
                    Case "FORNITORE_REGIO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_REGIO", "")
                    Case "FORNITORE_STRAS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "FORNITORE_STRAS", "")
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableDetailsInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableDetailsInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
