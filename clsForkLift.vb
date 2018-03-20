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

Public Class clsForkLift

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsForkLift"

    Public Shared CurrentForLift As clsDataType.SapForkLiftStruct

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableForkLift As New DataTable
    Public Shared objDataTableForkLiftWH As New DataTable


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

            RetCode = clsSapUtility.ResetSapForkLiftStuct(CurrentForLift)

            If (Not (objDataTableForkLift Is Nothing)) Then
                objDataTableForkLift.Rows.Clear()
            End If


            If (Not (objDataTableForkLiftWH Is Nothing)) Then
                objDataTableForkLiftWH.Rows.Clear()
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
    Public Shared Function ClearUDSInfoAfterDrop() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearUDSInfoAfterDrop = 1 'init at error

            CurrentForLift.NumUdsOnForklift = 0

 


            ClearUDSInfoAfterDrop = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearUDSInfoAfterDrop = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function CheckIsValidCurrentForLift() As Boolean
        ' ************************************************************
        ' DESCRIZIONE : VERIFICA SE HO CURRENT FORKLIFT ATTIVO
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckIsValidCurrentForLift = False

            If (clsUtility.IsStringValid(CurrentForLift.IdForkLift, True) = True) Then
                CheckIsValidCurrentForLift = True
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIsValidCurrentForLift = False  'CATCH
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


    Public Shared Function CreateDateTableForForkLift() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForForkLift = 1 'init at error


            Dim WorkMANDT As DataColumn = New DataColumn("MANDT") 'declaring a column named Name
            WorkMANDT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkMANDT) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkZID_WMS_FORKLIFT As DataColumn = New DataColumn("ZID_WMS_FORKLIFT") 'declaring a column named Name
            WorkZID_WMS_FORKLIFT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkZID_WMS_FORKLIFT) 'adding the column to table

            Dim WorkZDESCR_WMS_FORKLIFT As DataColumn = New DataColumn("ZDESCR_WMS_FORKLIFT") 'declaring a column named Name
            WorkZDESCR_WMS_FORKLIFT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkZDESCR_WMS_FORKLIFT) 'adding the column to table

            Dim WorkZFORKLIFT_MAX_PESO As DataColumn = New DataColumn("ZFORKLIFT_MAX_PESO") 'declaring a column named Name
            WorkZFORKLIFT_MAX_PESO.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkZFORKLIFT_MAX_PESO) 'adding the column to table

            Dim WorkGEWEI As DataColumn = New DataColumn("GEWEI") 'declaring a column named Name
            WorkGEWEI.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkGEWEI) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLINE_INDEX As DataColumn = New DataColumn("LINE_INDEX") 'declaring a column named Name
            WorkLINE_INDEX.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkLINE_INDEX) 'adding the column to table

            Dim WorkZNUM_UDS As DataColumn = New DataColumn("ZNUM_UDS") 'declaring a column named Name
            WorkZNUM_UDS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLift.Columns.Add(WorkZNUM_UDS) 'adding the column to table


            CreateDateTableForForkLift = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForForkLift = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function



    Public Shared Function CreateDateTableForForkLiftWH() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia ForkLift
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForForkLiftWH = 1 'init at error


            Dim WorkMANDT As DataColumn = New DataColumn("MANDT") 'declaring a column named Name
            WorkMANDT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkMANDT) 'adding the column to table

            Dim WorkZID_WMS_FORKLIFT As DataColumn = New DataColumn("ZID_WMS_FORKLIFT") 'declaring a column named Name
            WorkZID_WMS_FORKLIFT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkZID_WMS_FORKLIFT) 'adding the column to table

            Dim WorkZDESCR_WMS_FORKLIFT As DataColumn = New DataColumn("ZDESCR_WMS_FORKLIFT") 'declaring a column named Name
            WorkZDESCR_WMS_FORKLIFT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkZDESCR_WMS_FORKLIFT) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLINE_INDEX As DataColumn = New DataColumn("LINE_INDEX") 'declaring a column named Name
            WorkLINE_INDEX.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableForkLiftWH.Columns.Add(WorkLINE_INDEX) 'adding the column to table


            CreateDateTableForForkLiftWH = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForForkLiftWH = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    'Public Shared Function RefreshDateTableForForkLiftInfo() As Long
    '    ' ************************************************************
    '    ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
    '    ' ************************************************************

    '    '**************************************
    '    'HERE PUT DECLARATION OF LOCAL VARIABLE
    '    Dim RetCode As Long
    '    Dim WorkRow As DataRow
    '    Dim WorkPropertyId As String = ""
    '    Dim WorkPropertyValue As String
    '    '**************************************
    '    Try 'HERE PUT NORMAL EXECUTION CODE
    '        '**************************************

    '        RefreshDateTableForForkLiftInfo = 1 'init at error

    '        If (objDataTableForkLift Is Nothing) Then Exit Function

    '        If (objDataTableForkLift.Rows.Count = 0) Then Exit Function

    '        For Each WorkRow In objDataTableForkLift.Rows
    '            WorkPropertyId = WorkRow.Item("PropertyId")
    '            Select Case UCase(WorkPropertyId)
    '                Case "MANDT"
    '                    WorkPropertyValue = SapWmsUser.MANDT
    '                Case "MODULE_AREA"
    '                    WorkPropertyValue = SapWmsUser.MODULE_AREA
    '                Case "PROGNAME"
    '                    WorkPropertyValue = SapWmsUser.PROGNAME
    '                Case "USERID"
    '                    WorkPropertyValue = SapWmsUser.USERID
    '                Case "PROFID"
    '                    WorkPropertyValue = SapWmsUser.PROFID
    '                Case "NAME_FIRST"
    '                    WorkPropertyValue = SapWmsUser.NAME_FIRST
    '                Case "NAME_LAST"
    '                    WorkPropertyValue = SapWmsUser.NAME_LAST
    '                Case "BCDA1"
    '                    WorkPropertyValue = SapWmsUser.BCDA1
    '                Case "MOB_NUMBER"
    '                    WorkPropertyValue = SapWmsUser.MOB_NUMBER
    '                Case "EMAIL"
    '                    WorkPropertyValue = SapWmsUser.EMAIL
    '                Case "DESCRIPTION"
    '                    WorkPropertyValue = SapWmsUser.DESCRIPTION
    '                Case "ZCARR"
    '                    WorkPropertyValue = SapWmsUser.DESCRIPTION
    '                Case "SPEC1"
    '                    'WorkPropertyValue = SapWmsUser.Spec1
    '                Case "SPEC2"
    '                    'WorkPropertyValue = SapWmsUser.Spec2
    '                Case "SPEC3"
    '                    'WorkPropertyValue = SapWmsUser.Spec3
    '                Case "SPEC4"
    '                    'WorkPropertyValue = SapWmsUser.Spec4
    '                Case "SPEC5"
    '                    'WorkPropertyValue = SapWmsUser.Spec5
    '                Case Else
    '                    WorkPropertyValue = "NO DATA"
    '            End Select
    '            WorkRow.Item("PropertyValue") = WorkPropertyValue
    '        Next

    '        RefreshDateTableForForkLiftInfo = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        RefreshDateTableForForkLiftInfo = 1000 'IL THREAD E' USCITO DAL LOOP
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function


End Class
