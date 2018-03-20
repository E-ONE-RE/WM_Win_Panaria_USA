' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/10/2011
' DATA MODIFICA     : 18/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni dell'UTENTE ATTIVO
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsUser

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUser"

    Public Shared SapWmsUser As New clsDataType.StructSapWmsUser

    Public Shared UsersProfLgtyp As New clsDataType.StructUsersProfLgtyp

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableUserInfo As New DataTable
    Public Shared objDataTableUsersProfLgtyp As New DataTable

    Public Shared objDataTableUserPickQueues As New DataTable


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


            If (Not (objDataTableUserInfo Is Nothing)) Then
                'objDataTableUserInfo.Rows.Clear()
            End If

            If (Not (objDataTableUsersProfLgtyp Is Nothing)) Then
                objDataTableUsersProfLgtyp.Rows.Clear()
            End If

            If (Not (objDataTableUserPickQueues Is Nothing)) Then
                objDataTableUserPickQueues.Rows.Clear()
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

    Public Shared Function GetUserDivisionToUse() As String
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetUserDivisionToUse = "" 'init at nothing 

            If (clsUtility.IsStringValid(clsMobileConfiguration.MobileCfgData.Divisione, True) = True) Then
                GetUserDivisionToUse = clsMobileConfiguration.MobileCfgData.Divisione
                Exit Function
            End If

            If (clsUtility.IsStringValid(SapWmsUser.WERKS, True) = True) Then
                GetUserDivisionToUse = SapWmsUser.WERKS
                Exit Function
            End If

            'SE NON HO UNA DIVISIONE TORNO UN DEFAULT
            GetUserDivisionToUse = ""

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetUserDivisionToUse = "" 'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetUserNumeroMagazzinoToUse() As String
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetUserNumeroMagazzinoToUse = "" 'init at nothing 

            If (clsUtility.IsStringValid(clsMobileConfiguration.MobileCfgData.NumeroMagazzino, True) = True) Then
                GetUserNumeroMagazzinoToUse = clsMobileConfiguration.MobileCfgData.NumeroMagazzino
                Exit Function
            End If

            If (clsUtility.IsStringValid(SapWmsUser.LGNUM, True) = True) Then
                GetUserNumeroMagazzinoToUse = SapWmsUser.LGNUM
                Exit Function
            End If

            'SE NON HO UNA DIVISIONE TORNO UN DEFAULT
            'GetUserNumeroMagazzinoToUse = Default_PickingMerci_JobGroupList_NumMag

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetUserNumeroMagazzinoToUse = ""  'CATCH ERROR
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function InitUserData() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            InitUserData = 1 'init at error

            If (clsUtility.IsStringValid(SapWmsUser.ZCARR, True) = False) Then
                SapWmsUser.ZCARR = SapWmsUser.USERID
            End If

            InitUserData = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            InitUserData = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForUserInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUserInfo = 1 'init at error

            Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
            WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserInfo.Columns.Add(WorkPropertyId) 'adding the column to table

            Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
            WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserInfo.Columns.Add(WorkPropertyValue) 'adding the column to table

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "MANDT"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "MODULE_AREA"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "PROGNAME"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "USERID"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            '            PASSWORD()

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "PROFID"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "NAME_FIRST"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "NAME_LAST"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "BCDA1"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "MOB_NUMBER"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "EMAIL"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "DESCRIPTION"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "ZCARR"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "ZID_WMS_FORKLIFT"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPEC1"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPEC2"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPEC3"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPEC4"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUserInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPEC5"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUserInfo.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableForUserInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUserInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshDateTableForUserInfo() As Long
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

            RefreshDateTableForUserInfo = 1 'init at error

            If (objDataTableUserInfo Is Nothing) Then Exit Function

            If (objDataTableUserInfo.Rows.Count = 0) Then Exit Function

            For Each WorkRow In objDataTableUserInfo.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "MANDT"
                        WorkPropertyValue = SapWmsUser.Mandt
                    Case "MODULE_AREA"
                        WorkPropertyValue = SapWmsUser.MODULE_AREA
                    Case "PROGNAME"
                        WorkPropertyValue = SapWmsUser.PROGNAME
                    Case "USERID"
                        WorkPropertyValue = SapWmsUser.USERID
                    Case "PROFID"
                        WorkPropertyValue = SapWmsUser.PROFID
                    Case "NAME_FIRST"
                        WorkPropertyValue = SapWmsUser.NAME_FIRST
                    Case "NAME_LAST"
                        WorkPropertyValue = SapWmsUser.NAME_LAST
                    Case "BCDA1"
                        WorkPropertyValue = SapWmsUser.BCDA1
                    Case "MOB_NUMBER"
                        WorkPropertyValue = SapWmsUser.MOB_NUMBER
                    Case "EMAIL"
                        WorkPropertyValue = SapWmsUser.EMAIL
                    Case "DESCRIPTION"
                        WorkPropertyValue = SapWmsUser.DESCRIPTION
                    Case "ZCARR"
                        WorkPropertyValue = SapWmsUser.ZCARR
                    Case "ZID_WMS_FORKLIFT"
                        WorkPropertyValue = SapWmsUser.ZID_WMS_FORKLIFT
                    Case "SPEC1"
                        WorkPropertyValue = ""
                    Case "SPEC2"
                        WorkPropertyValue = ""
                    Case "SPEC3"
                        WorkPropertyValue = ""
                    Case "SPEC4"
                        WorkPropertyValue = ""
                    Case "SPEC5"
                        WorkPropertyValue = ""
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableForUserInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableForUserInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForUsersProfLgtyp() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUsersProfLgtyp = 1 'init at error

            Dim WorkPROFID As DataColumn = New DataColumn("PROFID") 'declaring a column named Name
            WorkPROFID.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUsersProfLgtyp.Columns.Add(WorkPROFID) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUsersProfLgtyp.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUsersProfLgtyp.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLTYPT As DataColumn = New DataColumn("LTYPT") 'declaring a column named Name
            WorkLTYPT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUsersProfLgtyp.Columns.Add(WorkLTYPT) 'adding the column to table


            CreateDateTableForUsersProfLgtyp = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUsersProfLgtyp = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForUserPickQueues() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForUserPickQueues = 1 'init at error

            Dim WorkZID_PICK_QUEUE As DataColumn = New DataColumn("ZID_PICK_QUEUE") 'declaring a column named Name
            WorkZID_PICK_QUEUE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZID_PICK_QUEUE) 'adding the column to table

            Dim WorkZPICK_QUEUE_DESC As DataColumn = New DataColumn("ZPICK_QUEUE_DESC") 'declaring a column named Name
            WorkZPICK_QUEUE_DESC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZPICK_QUEUE_DESC) 'adding the column to table

            Dim WorkZOPEN_FREE_NUM As DataColumn = New DataColumn("ZOPEN_FREE_NUM") 'declaring a column named Name
            WorkZOPEN_FREE_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZOPEN_FREE_NUM) 'adding the column to table

            Dim WorkZOPEN_ST_NUM As DataColumn = New DataColumn("ZOPEN_ST_NUM") 'declaring a column named Name
            WorkZOPEN_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZOPEN_ST_NUM) 'adding the column to table

            Dim WorkZOPEN_RSV_NUM As DataColumn = New DataColumn("ZOPEN_RSV_NUM") 'declaring a column named Name
            WorkZOPEN_RSV_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZOPEN_RSV_NUM) 'adding the column to table

            Dim WorkZTOTAL_WMSLINES As DataColumn = New DataColumn("ZTOTAL_WMSLINES") 'declaring a column named Name
            WorkZTOTAL_WMSLINES.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZTOTAL_WMSLINES) 'adding the column to table

            Dim WorkZTOTAL_WMS_KG As DataColumn = New DataColumn("ZTOTAL_WMS_KG") 'declaring a column named Name
            WorkZTOTAL_WMS_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZTOTAL_WMS_KG) 'adding the column to table

            Dim WorkZTOTAL_WMS_LB As DataColumn = New DataColumn("ZTOTAL_WMS_LB") 'declaring a column named Name
            WorkZTOTAL_WMS_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUserPickQueues.Columns.Add(WorkZTOTAL_WMS_LB) 'adding the column to table

            CreateDateTableForUserPickQueues = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUserPickQueues = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
