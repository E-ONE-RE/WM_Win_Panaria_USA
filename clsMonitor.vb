' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI & LUCA BELLEI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/10/2011
' DATA MODIFICA     : 18/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni dei Carrelli
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsMonitor

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsMonitor"

    'Public Shared SapWmsUser As New StructSapWmsUser

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableMonitorQueues As New DataTable
    Public Shared objDataTableMonitorJobs As New DataTable


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


            If (Not (objDataTableMonitorQueues Is Nothing)) Then
                objDataTableMonitorQueues.Rows.Clear()
            End If


            If (Not (objDataTableMonitorJobs Is Nothing)) Then
                objDataTableMonitorJobs.Rows.Clear()
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

            'If (clsUtility.IsStringValid(SapWmsUser.ZCARR, True) = False) Then
            '    SapWmsUser.ZCARR = SapWmsUser.USERID
            'End If

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


    Public Shared Function CreateDateTableForMonitorQueues() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForMonitorQueues = 1 'init at error


            Dim WorkZID_PICK_QUEUE As DataColumn = New DataColumn("ZID_PICK_QUEUE") 'declaring a column named Name
            WorkZID_PICK_QUEUE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZID_PICK_QUEUE) 'adding the column to table

            Dim WorkZPICK_QUEUE_DESC As DataColumn = New DataColumn("ZPICK_QUEUE_DESC") 'declaring a column named Name
            WorkZPICK_QUEUE_DESC.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZPICK_QUEUE_DESC) 'adding the column to table

            Dim WorkZStatus As DataColumn = New DataColumn("ZStatus") 'declaring a column named Name
            WorkZStatus.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZStatus) 'adding the column to tablev

            Dim WorkZOPEN_ST_NUM As DataColumn = New DataColumn("ZOPEN_ST_NUM") 'declaring a column named Name
            WorkZOPEN_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZOPEN_ST_NUM) 'adding the column to table

            Dim WorkZOPEN_ST_PER As DataColumn = New DataColumn("ZOPEN_ST_PER") 'declaring a column named Name
            WorkZOPEN_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZOPEN_ST_PER) 'adding the column to table

            Dim WorkZOPEN_ST_KG As DataColumn = New DataColumn("ZOPEN_ST_KG") 'declaring a column named Name
            WorkZOPEN_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZOPEN_ST_KG) 'adding the column to table

            Dim WorkZOPEN_ST_LB As DataColumn = New DataColumn("ZOPEN_ST_LB") 'declaring a column named Name
            WorkZOPEN_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZOPEN_ST_LB) 'adding the column to table

            Dim WorkZPICKED_ST_NUM As DataColumn = New DataColumn("ZPICKED_ST_NUM") 'declaring a column named Name
            WorkZPICKED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZPICKED_ST_NUM) 'adding the column to table

            Dim WorkZPICKED_ST_PER As DataColumn = New DataColumn("ZPICKED_ST_PER") 'declaring a column named Name
            WorkZPICKED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZPICKED_ST_PER) 'adding the column to table

            Dim WorkZPICKED_ST_KG As DataColumn = New DataColumn("ZPICKED_ST_KG") 'declaring a column named Name
            WorkZPICKED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZPICKED_ST_KG) 'adding the column to table

            Dim WorkZPICKED_ST_LB As DataColumn = New DataColumn("ZPICKED_ST_LB") 'declaring a column named Name
            WorkZPICKED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZPICKED_ST_LB) 'adding the column to table

            Dim WorkZSTAGED_ST_NUM As DataColumn = New DataColumn("ZSTAGED_ST_NUM") 'declaring a column named Name
            WorkZSTAGED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZSTAGED_ST_NUM) 'adding the column to table

            Dim WorkZSTAGED_ST_PER As DataColumn = New DataColumn("ZSTAGED_ST_PER") 'declaring a column named Name
            WorkZSTAGED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZSTAGED_ST_PER) 'adding the column to table

            Dim WorkZSTAGED_ST_KG As DataColumn = New DataColumn("ZSTAGED_ST_KG") 'declaring a column named Name
            WorkZSTAGED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZSTAGED_ST_KG) 'adding the column to table

            Dim WorkZSTAGED_ST_LB As DataColumn = New DataColumn("ZSTAGED_ST_LB") 'declaring a column named Name
            WorkZSTAGED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZSTAGED_ST_LB) 'adding the column to table

            Dim WorkZLOADED_ST_NUM As DataColumn = New DataColumn("ZLOADED_ST_NUM") 'declaring a column named Name
            WorkZLOADED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZLOADED_ST_NUM) 'adding the column to table

            Dim WorkZLOADED_ST_PER As DataColumn = New DataColumn("ZLOADED_ST_PER") 'declaring a column named Name
            WorkZLOADED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZLOADED_ST_PER) 'adding the column to table

            Dim WorkZLOADED_ST_KG As DataColumn = New DataColumn("ZLOADED_ST_KG") 'declaring a column named Name
            WorkZLOADED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZLOADED_ST_KG) 'adding the column to table

            Dim WorkZLOADED_ST_LB As DataColumn = New DataColumn("ZLOADED_ST_LB") 'declaring a column named Name
            WorkZLOADED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZLOADED_ST_LB) 'adding the column to table

            Dim WorkZTOTAL_WMSLINES As DataColumn = New DataColumn("ZTOTAL_WMSLINES") 'declaring a column named Name
            WorkZTOTAL_WMSLINES.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZTOTAL_WMSLINES) 'adding the column to table

            Dim WorkZTOTAL_WMS_KG As DataColumn = New DataColumn("ZTOTAL_WMS_KG") 'declaring a column named Name
            WorkZTOTAL_WMS_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZTOTAL_WMS_KG) 'adding the column to tablev

            Dim WorkZTOTAL_WMS_LB As DataColumn = New DataColumn("ZTOTAL_WMS_LB") 'declaring a column named Name
            WorkZTOTAL_WMS_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorQueues.Columns.Add(WorkZTOTAL_WMS_LB) 'adding the column to tablev


            CreateDateTableForMonitorQueues = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForMonitorQueues = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForMonitorJobs() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForMonitorJobs = 1 'init at error


            Dim WorkZID_JOBS_TYPE As DataColumn = New DataColumn("ZID_JOBS_TYPE") 'declaring a column named Name
            WorkZID_JOBS_TYPE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZID_JOBS_TYPE) 'adding the column to table

            Dim WorkZDESCR_JOBS_TYPE As DataColumn = New DataColumn("ZDESCR_JOBS_TYPE") 'declaring a column named Name
            WorkZDESCR_JOBS_TYPE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZDESCR_JOBS_TYPE) 'adding the column to table

            Dim WorkZOPEN_ST_NUM As DataColumn = New DataColumn("ZOPEN_ST_NUM") 'declaring a column named Name
            WorkZOPEN_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZOPEN_ST_NUM) 'adding the column to table

            Dim WorkZOPEN_ST_PER As DataColumn = New DataColumn("ZOPEN_ST_PER") 'declaring a column named Name
            WorkZOPEN_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZOPEN_ST_PER) 'adding the column to table

            Dim WorkZOPEN_ST_KG As DataColumn = New DataColumn("ZOPEN_ST_KG") 'declaring a column named Name
            WorkZOPEN_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZOPEN_ST_KG) 'adding the column to table

            Dim WorkZOPEN_ST_LB As DataColumn = New DataColumn("ZOPEN_ST_LB") 'declaring a column named Name
            WorkZOPEN_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZOPEN_ST_LB) 'adding the column to table

            Dim WorkZPICKED_ST_NUM As DataColumn = New DataColumn("ZPICKED_ST_NUM") 'declaring a column named Name
            WorkZPICKED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZPICKED_ST_NUM) 'adding the column to table

            Dim WorkZPICKED_ST_PER As DataColumn = New DataColumn("ZPICKED_ST_PER") 'declaring a column named Name
            WorkZPICKED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZPICKED_ST_PER) 'adding the column to table

            Dim WorkZPICKED_ST_KG As DataColumn = New DataColumn("ZPICKED_ST_KG") 'declaring a column named Name
            WorkZPICKED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZPICKED_ST_KG) 'adding the column to table

            Dim WorkZPICKED_ST_LB As DataColumn = New DataColumn("ZPICKED_ST_LB") 'declaring a column named Name
            WorkZPICKED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZPICKED_ST_LB) 'adding the column to table

            Dim WorkZSTAGED_ST_NUM As DataColumn = New DataColumn("ZSTAGED_ST_NUM") 'declaring a column named Name
            WorkZSTAGED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZSTAGED_ST_NUM) 'adding the column to table

            Dim WorkZSTAGED_ST_PER As DataColumn = New DataColumn("ZSTAGED_ST_PER") 'declaring a column named Name
            WorkZSTAGED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZSTAGED_ST_PER) 'adding the column to table

            Dim WorkZSTAGED_ST_KG As DataColumn = New DataColumn("ZSTAGED_ST_KG") 'declaring a column named Name
            WorkZSTAGED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZSTAGED_ST_KG) 'adding the column to table

            Dim WorkZSTAGED_ST_LB As DataColumn = New DataColumn("ZSTAGED_ST_LB") 'declaring a column named Name
            WorkZSTAGED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZSTAGED_ST_LB) 'adding the column to table

            Dim WorkZLOADED_ST_NUM As DataColumn = New DataColumn("ZLOADED_ST_NUM") 'declaring a column named Name
            WorkZLOADED_ST_NUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZLOADED_ST_NUM) 'adding the column to table

            Dim WorkZLOADED_ST_PER As DataColumn = New DataColumn("ZLOADED_ST_PER") 'declaring a column named Name
            WorkZLOADED_ST_PER.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZLOADED_ST_PER) 'adding the column to table

            Dim WorkZLOADED_ST_KG As DataColumn = New DataColumn("ZLOADED_ST_KG") 'declaring a column named Name
            WorkZLOADED_ST_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZLOADED_ST_KG) 'adding the column to table

            Dim WorkZLOADED_ST_LB As DataColumn = New DataColumn("ZLOADED_ST_LB") 'declaring a column named Name
            WorkZLOADED_ST_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZLOADED_ST_LB) 'adding the column to table

            Dim WorkZTOTAL_WMSLINES As DataColumn = New DataColumn("ZTOTAL_WMSLINES") 'declaring a column named Name
            WorkZTOTAL_WMSLINES.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZTOTAL_WMSLINES) 'adding the column to table

            Dim WorkZTOTAL_WMS_KG As DataColumn = New DataColumn("ZTOTAL_WMS_KG") 'declaring a column named Name
            WorkZTOTAL_WMS_KG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZTOTAL_WMS_KG) 'adding the column to tablev

            Dim WorkZTOTAL_WMS_LB As DataColumn = New DataColumn("ZTOTAL_WMS_LB") 'declaring a column named Name
            WorkZTOTAL_WMS_LB.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMonitorJobs.Columns.Add(WorkZTOTAL_WMS_LB) 'adding the column to tablev


            CreateDateTableForMonitorJobs = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForMonitorJobs = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
