' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 19/06/2012
' DATA MODIFICA     : 19/06/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni del SISTEMA
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoSystem


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoSystem"


    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableInfo As New DataTable


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


            If (Not (objDataTableInfo Is Nothing)) Then
                'objDataTableUserInfo.Rows.Clear()
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
    Public Shared Function CreateDateTableForSystemInfo() As Long
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

            CreateDateTableForSystemInfo = 1 'init at error

            Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
            WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInfo.Columns.Add(WorkPropertyId) 'adding the column to table

            Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
            WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInfo.Columns.Add(WorkPropertyValue) 'adding the column to table


            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "SYSID"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "MANDT"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "DBSYS"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "SAPRL"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "DATUM"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "UZEIT"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "UNAME"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "HOST"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "DATLO"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "TIMLO"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "ZONLO"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "TZONE"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "DAYST"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "FDAYW"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableInfo.NewRow()
            WorkRow.Item("PropertyId") = "DBNAM"
            WorkRow.Item("PropertyValue") = ""
            objDataTableInfo.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableForSystemInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForSystemInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function RefreshDateTableForSystemInfo() As Long
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

            RefreshDateTableForSystemInfo = 1 'init at error

            If (objDataTableInfo Is Nothing) Then Exit Function

            If (objDataTableInfo.Rows.Count = 0) Then Exit Function

            For Each WorkRow In objDataTableInfo.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "SYSID"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Sysid
                    Case "MANDT"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Mandt
                    Case "DBSYS"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dbsys
                    Case "SAPRL"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Saprl
                    Case "DATUM"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Datum
                    Case "UZEIT"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Uzeit
                    Case "UNAME"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Uname
                    Case "HOST"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Host
                    Case "DATLO"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Datlo
                    Case "TIMLO"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Timlo
                    Case "ZONLO"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Zonlo
                    Case "TZONE"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Tzone
                    Case "DAYST"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dayst
                    Case "FDAYW"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Fdayw
                    Case "DBNAM"
                        WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dbnam
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableForSystemInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableForSystemInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
