' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 17/10/2011
' DATA MODIFICA     : 17/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni di un CODICE MATERIALE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoCodiceMateriale


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoCodiceMateriale"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableCodiceMaterialeInfo As New DataTable
    Public Shared objDataTableDetailsCodMateriale As New DataTable

    'OGGETTO ROW PER LA VISUALIZZAZIONE DEL DETTAGLIO DEI DATI
    Public Shared objDetailsDataRow As Data.DataRow

    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DELL'ANAGRAFICA MATERIALE
    Public Shared FilterDivisione As String
    Public Shared FilterCodiceMateriale As String
    Public Shared FilterPartitaMateriale As String
    Public Shared FilterSKU As String

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False

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
            FirstLoadExecuted_Step_1 = False
            RowIndex = 0

            If (Not (objDataTableCodiceMaterialeInfo Is Nothing)) Then
                objDataTableCodiceMaterialeInfo.Rows.Clear()
            End If

            'If (Not (objDataTableDetailsCodMateriale Is Nothing)) Then
            '    objDataTableDetailsCodMateriale.Rows.Clear()
            'End If

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

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkMAKTG As DataColumn = New DataColumn("MAKTG") 'declaring a column named Name
            WorkMAKTG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMAKTG) 'adding the column to table

            Dim WorkMTART As DataColumn = New DataColumn("MTART") 'declaring a column named Name
            WorkMTART.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMTART) 'adding the column to table

            Dim WorkMATKL As DataColumn = New DataColumn("MATKL") 'declaring a column named Name
            WorkMATKL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMATKL) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkEKGRP As DataColumn = New DataColumn("EKGRP") 'declaring a column named Name
            WorkEKGRP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkEKGRP) 'adding the column to table

            Dim WorkBRGEW As DataColumn = New DataColumn("BRGEW") 'declaring a column named Name
            WorkBRGEW.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkBRGEW) 'adding the column to table

            Dim WorkNTGEW As DataColumn = New DataColumn("NTGEW") 'declaring a column named Name
            WorkNTGEW.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkNTGEW) 'adding the column to table

            Dim WorkPESO_UDM_CONSEGNA As DataColumn = New DataColumn("PESO_UDM_CONSEGNA") 'declaring a column named Name
            WorkPESO_UDM_CONSEGNA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkPESO_UDM_CONSEGNA) 'adding the column to table

            Dim WorkPESO_UDM_PALLET As DataColumn = New DataColumn("PESO_UDM_PALLET") 'declaring a column named Name
            WorkPESO_UDM_PALLET.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkPESO_UDM_PALLET) 'adding the column to table

            Dim WorkGEWEI As DataColumn = New DataColumn("GEWEI") 'declaring a column named Name
            WorkGEWEI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkGEWEI) 'adding the column to table

            Dim WorkVOLUM As DataColumn = New DataColumn("VOLUM") 'declaring a column named Name
            WorkVOLUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkVOLUM) 'adding the column to table

            Dim WorkVOLEH As DataColumn = New DataColumn("VOLEH") 'declaring a column named Name
            WorkVOLEH.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkVOLEH) 'adding the column to table

            Dim WorkPZ_X_SC As DataColumn = New DataColumn("PZ_X_SC") 'declaring a column named Name
            WorkPZ_X_SC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkPZ_X_SC) 'adding the column to table

            Dim WorkSC_X_PAL As DataColumn = New DataColumn("SC_X_PAL") 'declaring a column named Name
            WorkSC_X_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkSC_X_PAL) 'adding the column to table

            Dim WorkETILE_UMBASE_UMCONSEGNA As DataColumn = New DataColumn("ETILE_UMBASE_UMCONSEGNA") 'declaring a column named Name
            WorkETILE_UMBASE_UMCONSEGNA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkETILE_UMBASE_UMCONSEGNA) 'adding the column to table

            Dim WorkM2_X_PAL As DataColumn = New DataColumn("M2_X_PAL") 'declaring a column named Name
            WorkM2_X_PAL.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkM2_X_PAL) 'adding the column to table

            Dim WorkEAN11 As DataColumn = New DataColumn("EAN11") 'declaring a column named Name
            WorkEAN11.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkEAN11) 'adding the column to table

            Dim WorkLABOR As DataColumn = New DataColumn("LABOR") 'declaring a column named Name
            WorkLABOR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkLABOR) 'adding the column to table

            Dim WorkT024X As DataColumn = New DataColumn("T024X") 'declaring a column named Name
            WorkT024X.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkT024X) 'adding the column to table

            Dim WorkMVGR5 As DataColumn = New DataColumn("MVGR5") 'declaring a column named Name
            WorkMVGR5.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkMVGR5) 'adding the column to table

            Dim WorkBEZEI As DataColumn = New DataColumn("BEZEI") 'declaring a column named Name
            WorkBEZEI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkBEZEI) 'adding the column to table

            Dim WorkZ_ORG_COMM_ETICH As DataColumn = New DataColumn("Z_ORG_COMM_ETICH") 'declaring a column named Name
            WorkZ_ORG_COMM_ETICH.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkZ_ORG_COMM_ETICH) 'adding the column to table


            Dim WorkZZSTORAGE_CODE As DataColumn = New DataColumn("ZZSTORAGE_CODE") 'declaring a column named Name
            WorkZZSTORAGE_CODE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkZZSTORAGE_CODE) 'adding the column to table

            Dim WorkZZWAREHOUSE_CODE As DataColumn = New DataColumn("ZZWAREHOUSE_CODE") 'declaring a column named Name
            WorkZZWAREHOUSE_CODE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableCodiceMaterialeInfo.Columns.Add(WorkZZWAREHOUSE_CODE) 'adding the column to table


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

            If objDataTableDetailsCodMateriale.Columns("PropertyId") Is Nothing Then
                Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
                WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsCodMateriale.Columns.Add(WorkPropertyId) 'adding the column to table
            End If

            If objDataTableDetailsCodMateriale.Columns("PropertyText") Is Nothing Then
                Dim WorkPropertyText As DataColumn = New DataColumn("PropertyText") 'declaring a column named Name
                WorkPropertyText.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsCodMateriale.Columns.Add(WorkPropertyText) 'adding the column to table
            End If

            If objDataTableDetailsCodMateriale.Columns("PropertyValue") Is Nothing Then
                Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
                WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
                objDataTableDetailsCodMateriale.Columns.Add(WorkPropertyValue) 'adding the column to table
            End If


            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "WERKS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(6, "", "Divisione")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MATNR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(306, "", "Cod.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MAKTG"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(534, "", "Descr.Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MTART"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(535, "", "Tipo Materiale")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MATKL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(536, "", "Gruppo Merci")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MEINS"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(862, "", "UdM Base")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "GEWEI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(863, "", "UdM Peso")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "EKGRP"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(538, "", "Gruppo Acquisti")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "BRGEW"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(864, "", "Peso Lordo (UdMBase)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "NTGEW"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(865, "", "Peso Netto (UdMBase)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "PESO_UDM_CONSEGNA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(866, "", "Peso UdM Consegna")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "PESO_UDM_PALLET"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(867, "", "Peso Pallet")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "GEWEI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(868, "", "Unità Di Peso")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "VOLUM"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(869, "", "Volume (UdMBase)")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "VOLEH"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(870, "", "Unità Di Volume")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "PZ_X_SC"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(871, "", "Pezzi x Scatola")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "SC_X_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(872, "", "Scatole x Pallet")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "ETILE_UMBASE_UMCONSEGNA"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(873, "", "M2 x Udm Consegna")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "M2_X_PAL"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(874, "", "M2 x Pallet")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "EAN11"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(875, "", "Codice EAN")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "LABOR"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(876, "", "Codice Formato")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "T024X"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(877, "", "Descrizione Formato")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "MVGR5"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(878, "", "Codice Serie")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "BEZEI"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(879, "", "Descrizione Serie")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "Z_ORG_COMM_ETICH"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(880, "", "Marchio")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga


            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "ZZSTORAGE_CODE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1463, "", "Sto.Code")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableDetailsCodMateriale.NewRow()
            WorkRow.Item("PropertyId") = "ZZWAREHOUSE_CODE"
            WorkRow.Item("PropertyText") = clsAppTranslation.GetSingleParameterValue(1464, "", "W.Code")
            WorkRow.Item("PropertyValue") = ""
            objDataTableDetailsCodMateriale.Rows.Add(WorkRow) 'aggiungo la riga


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

            If (objDataTableDetailsCodMateriale Is Nothing) Then Exit Function

            If (objDataTableDetailsCodMateriale.Rows.Count = 0) Then Exit Function

            If (objDetailsDataRow Is Nothing) Then Exit Function

            For Each WorkRow In objDataTableDetailsCodMateriale.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "WERKS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "WERKS", "")
                    Case "MATNR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATNR", "")
                        WorkPropertyValue = clsSapUtility.FormattaStringaCodiceMateriale(WorkPropertyValue)
                    Case "MAKTG"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MAKTG", "")
                    Case "MTART"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MTART", "")
                    Case "MATKL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MATKL", "")
                    Case "MEINS"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MEINS", "")
                    Case "EKGRP"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "EKGRP", "")
                    Case "GEWEI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "GEWEI", "")
                    Case "BRGEW"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BRGEW", "")
                    Case "NTGEW"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "NTGEW", "")
                    Case "PESO_UDM_CONSEGNA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PESO_UDM_CONSEGNA", "")
                    Case "PESO_UDM_PALLET"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PESO_UDM_PALLET", "")
                    Case "VOLUM"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VOLUM", "")
                    Case "VOLEH"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "VOLEH", "")
                    Case "PZ_X_SC"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "PZ_X_SC", "")
                    Case "SC_X_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "SC_X_PAL", "")
                    Case "ETILE_UMBASE_UMCONSEGNA"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ETILE_UMBASE_UMCONSEGNA", "")
                    Case "M2_X_PAL"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "M2_X_PAL", "")
                    Case "EAN11"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "EAN11", "")
                    Case "LABOR"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "LABOR", "")
                    Case "T024X"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "T024X", "")
                    Case "MVGR5"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "MVGR5", "")
                    Case "BEZEI"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "BEZEI", "")
                    Case "Z_ORG_COMM_ETICH"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "Z_ORG_COMM_ETICH", "")

                    Case "ZZSTORAGE_CODE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZZSTORAGE_CODE", "")
                    Case "ZZWAREHOUSE_CODE"
                        WorkPropertyValue = clsUtility.GetDataRowItem(objDetailsDataRow, "ZZWAREHOUSE_CODE", "")

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
