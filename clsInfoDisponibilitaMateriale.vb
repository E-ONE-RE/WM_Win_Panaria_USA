' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 06/04/2014
' DATA MODIFICA     : 06/04/2014
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni di DISPONIBILITA del MATERIALE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoDisponibilitaMateriale


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoDisponibilitaMateriale"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableDispoMaterialeInfo As New DataTable
    Public Shared objDataTableDetailsDispoMateriale As New DataTable

    'OGGETTO ROW PER LA VISUALIZZAZIONE DEL DETTAGLIO DEI DATI
    Public Shared objDetailsDataRow As Data.DataRow

    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DELL'ANAGRAFICA MATERIALE
    Public Shared FilterDivisione As String
    Public Shared FilterCodiceMateriale As String
    Public Shared FilterPartitaMateriale As String
    Public Shared FilterMagazzinoLogico As String

    Public Shared FilterSKU As String

    Public Shared RowIndex As Long

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

            FilterDivisione = ""
            FilterCodiceMateriale = ""
            FilterPartitaMateriale = ""
            FilterMagazzinoLogico = ""
            FilterSKU = ""
            RowIndex = 0

            If (Not (objDataTableDispoMaterialeInfo Is Nothing)) Then
                objDataTableDispoMaterialeInfo.Rows.Clear()
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

    Public Shared Function CreateDateTableList() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con LISTA MATERIALI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableList = 1 'init at error


            'CAMPI PER STRUTTURA  ZE1_SS_00004

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkUTA_VIS As DataColumn = New DataColumn("UTA_VIS") 'declaring a column named Name
            WorkUTA_VIS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkUTA_VIS) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkLGORT) 'adding the column to table

            Dim WorkVBMNC As DataColumn = New DataColumn("VBMNC") 'declaring a column named Name
            WorkVBMNC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNC) 'adding the column to table

            Dim WorkDISPO As DataColumn = New DataColumn("DISPO") 'declaring a column named Name
            WorkDISPO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkDISPO) 'adding the column to table

            Dim WorkSCELTA As DataColumn = New DataColumn("SCELTA") 'declaring a column named Name
            WorkSCELTA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkSCELTA) 'adding the column to table

            Dim WorkNOTA As DataColumn = New DataColumn("NOTA") 'declaring a column named Name
            WorkNOTA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkNOTA) 'adding the column to table



            Dim WorkCLABS As DataColumn = New DataColumn("CLABS") 'declaring a column named Name
            WorkCLABS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCLABS) 'adding the column to table

            Dim WorkCINSM As DataColumn = New DataColumn("CINSM") 'declaring a column named Name
            WorkCINSM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCINSM) 'adding the column to table

            Dim WorkBDMNG As DataColumn = New DataColumn("BDMNG") 'declaring a column named Name
            WorkBDMNG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkBDMNG) 'adding the column to table

            Dim WorkVBMNJ As DataColumn = New DataColumn("VBMNJ") 'declaring a column named Name
            WorkVBMNJ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNJ) 'adding the column to table

            Dim WorkCSPEM As DataColumn = New DataColumn("CSPEM") 'declaring a column named Name
            WorkCSPEM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCSPEM) 'adding the column to table

            Dim WorkCLABS_E As DataColumn = New DataColumn("CLABS_E") 'declaring a column named Name
            WorkCLABS_E.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCLABS_E) 'adding the column to table



            'CAMPI PER STRUTTURA  ZE1_SS_00004_CONS  Dettaglio Qtà

            Dim WorkCLABS_FULL As DataColumn = New DataColumn("CLABS_FULL") 'declaring a column named Name
            WorkCLABS_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCLABS_FULL) 'adding the column to table

            Dim WorkCLABS_PARTIAL As DataColumn = New DataColumn("CLABS_PARTIAL") 'declaring a column named Name
            WorkCLABS_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCLABS_PARTIAL) 'adding the column to table

            Dim WorkCLABS_SF As DataColumn = New DataColumn("CLABS_SF") 'declaring a column named Name
            WorkCLABS_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCLABS_SF) 'adding the column to table


            Dim WorkCINSM_FULL As DataColumn = New DataColumn("CINSM_FULL") 'declaring a column named Name
            WorkCINSM_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCINSM_FULL) 'adding the column to table

            Dim WorkCINSM_PARTIAL As DataColumn = New DataColumn("CINSM_PARTIAL") 'declaring a column named Name
            WorkCINSM_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCINSM_PARTIAL) 'adding the column to table

            Dim WorkCINSM_SF As DataColumn = New DataColumn("CINSM_SF") 'declaring a column named Name
            WorkCINSM_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCINSM_SF) 'adding the column to table


            Dim WorkCSPEM_FULL As DataColumn = New DataColumn("CSPEM_FULL") 'declaring a column named Name
            WorkCSPEM_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCSPEM_FULL) 'adding the column to table

            Dim WorkCSPEM_PARTIAL As DataColumn = New DataColumn("CSPEM_PARTIAL") 'declaring a column named Name
            WorkCSPEM_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCSPEM_PARTIAL) 'adding the column to table

            Dim WorkCSPEM_SF As DataColumn = New DataColumn("CSPEM_SF") 'declaring a column named Name
            WorkCSPEM_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkCSPEM_SF) 'adding the column to table


            Dim WorkBDMNG_FULL As DataColumn = New DataColumn("BDMNG_FULL") 'declaring a column named Name
            WorkBDMNG_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkBDMNG_FULL) 'adding the column to table

            Dim WorkBDMNG_PARTIAL As DataColumn = New DataColumn("BDMNG_PARTIAL") 'declaring a column named Name
            WorkBDMNG_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkBDMNG_PARTIAL) 'adding the column to table

            Dim WorkBDMNG_SF As DataColumn = New DataColumn("BDMNG_SF") 'declaring a column named Name
            WorkBDMNG_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkBDMNG_SF) 'adding the column to table


            Dim WorkVBMNC_FULL As DataColumn = New DataColumn("VBMNC_FULL") 'declaring a column named Name
            WorkVBMNC_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNC_FULL) 'adding the column to table

            Dim WorkVBMNC_PARTIAL As DataColumn = New DataColumn("VBMNC_PARTIAL") 'declaring a column named Name
            WorkVBMNC_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNC_PARTIAL) 'adding the column to table

            Dim WorkVBMNC_SF As DataColumn = New DataColumn("VBMNC_SF") 'declaring a column named Name
            WorkVBMNC_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNC_SF) 'adding the column to table


            Dim WorkVBMNJ_FULL As DataColumn = New DataColumn("VBMNJ_FULL") 'declaring a column named Name
            WorkVBMNJ_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNJ_FULL) 'adding the column to table

            Dim WorkVBMNJ_PARTIAL As DataColumn = New DataColumn("VBMNJ_PARTIAL") 'declaring a column named Name
            WorkVBMNJ_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNJ_PARTIAL) 'adding the column to table

            Dim WorkVBMNJ_SF As DataColumn = New DataColumn("VBMNJ_SF") 'declaring a column named Name
            WorkVBMNJ_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkVBMNJ_SF) 'adding the column to table


            Dim WorkDISPO_FULL As DataColumn = New DataColumn("DISPO_FULL") 'declaring a column named Name
            WorkDISPO_FULL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkDISPO_FULL) 'adding the column to table

            Dim WorkDISPO_PARTIAL As DataColumn = New DataColumn("DISPO_PARTIAL") 'declaring a column named Name
            WorkDISPO_PARTIAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkDISPO_PARTIAL) 'adding the column to table

            Dim WorkDISPO_SF As DataColumn = New DataColumn("DISPO_SF") 'declaring a column named Name
            WorkDISPO_SF.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableDispoMaterialeInfo.Columns.Add(WorkDISPO_SF) 'adding the column to table



            CreateDateTableList = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableList = 1000 'IL THREAD E' USCITO DAL LOOP
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

            If objDataTableDetailsDispoMateriale.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsDispoMateriale.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsDispoMateriale.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsDispoMateriale.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsDispoMateriale.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsDispoMateriale.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If


            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "WERKS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(6, "", "Divisione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MATNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "CHARG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(881, "", "Partita.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "UTA_VIS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(86, "", "UdM")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "LGORT"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(117, "", "Magazzino")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "VBMNC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(882, "", "Qta Impegnata")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "DISPO"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(782, "", "Qta Disponibile")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "SCELTA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(550, "", "Scelta")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "NOTA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(551, "", "Note")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga



            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "CLABS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1727, "", "Stock")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "CINSM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1728, "", "Quality")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "BDMNG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1729, "", "TempReser")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "VBMNJ"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1730, "", "Prepar.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "CSPEM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1731, "", "Block stock S")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsDispoMateriale.NewRow()
            WorkRow.Item("PropertyId") = "CLABS_E"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1732, "", "Cust.reser.")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsDispoMateriale.Rows.Add(WorkRow) 'aggiungo la riga



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

            If (objDataTableDetailsDispoMateriale Is Nothing) Then Exit Function

            If (objDataTableDetailsDispoMateriale.Rows.Count = 0) Then Exit Function

            If (objDetailsDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsDispoMateriale.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "WERKS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS", "")
                    Case "MATNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATNR", "")
                        WorkPropertyValue = clsSapUtility.FormattaStringaCodiceMateriale(WorkPropertyValue)
                    Case "CHARG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CHARG", "")
                    Case "LGORT"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LGORT", "")
                    Case "VBMNC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VBMNC", "")
                    Case "DISPO"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "DISPO", "")
                    Case "UTA_VIS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "UTA_VIS", "")
                    Case "SCELTA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SCELTA", "")
                    Case "NOTA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NOTA", "")

                    Case "CLABS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CLABS", "")
                    Case "CINSM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CINSM", "")
                    Case "BDMNG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BDMNG", "")
                    Case "VBMNJ"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VBMNJ", "")
                    Case "CSPEM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CSPEM", "")
                    Case "CLABS_E"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "CLABS_E", "")

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
