' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 24/07/2015
' DATA MODIFICA     : 24/07/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la gestione dei PARAMETRI di BASE dell'applicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapWS
Imports clsBusinessLogic

Public Class clsAppParameters

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsAppParameters"

    Private SapFunctionError As clsBusinessLogic.SapFunctionError

    ' OGGETTO DATA TABLE PER VISUALIZZARE PARAMETRI NELLE GRIGLIE
    Public Shared objDataTableAppParamsInfo As New DataTable


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


            If (Not (objDataTableAppParamsInfo Is Nothing)) Then
                objDataTableAppParamsInfo.Rows.Clear()
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

    Public Shared Function GetApplicationParameters(ByVal InIWerks As String, ByVal InILgnum As String, ByRef outSapFunctionError As clsBusinessLogic.SapFunctionError, ByRef outDataTable As DataTable) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckOk As Boolean = False


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetApplicationParameters = 1 'init at error

            'CREO LA TABELLA DEI PARAMETRI APPLICAZIONE
            RetCode += clsAppParameters.CreateDateTableForAppParams()
            If (RetCode <> 0) Then
                MessageBox.Show(clsAppTranslation.GetSingleParameterValue(836, "", "Check Lettura Parametri ERRORE!!!"))
            End If

            'CHIAMO IL WEB SERVICE PER LA LETTURA DEI PARAMETRI APPLICAZIONE
            RetCode = clsSapWS.Call_ZWS_GET_APPLICATION_PARAMS(InIWerks, InILgnum, outSapFunctionError, objDataTableAppParamsInfo, CheckOk, False)
            If (RetCode <> 0) And (CheckOk = False) Then
                MessageBox.Show(clsAppTranslation.GetSingleParameterValue(836, "", "Check Lettura Parametri ERRORE!!!"))
            End If

            GetApplicationParameters = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetApplicationParameters = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetSingleParameterValue(ByVal inIdAppParameter As String, ByVal inWerks As String, ByVal inLgnum As String, ByVal inIdDevice As String, ByRef outAppParamValue As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetSingleParameterValue = 1 'init at error


            '1 => si filtra per tutti i parametri passati valorizzati ( inWerks, inLgnum, inIdDevice )
            'For i = 0 To objDataTableAppParamsInfo.Rows.Count - 1
            '    If objDataTableAppParamsInfo.Rows(i)("Werks") = inWerks And _
            '       objDataTableAppParamsInfo.Rows(i)("Lgnum") = inLgnum And _
            '       objDataTableAppParamsInfo.Rows(i)("IdWmsDevices") = inIdDevice Then

            '        outAppParamValue = objDataTableAppParamsInfo.Rows(i)("ZvalueWmsAppParams")

            '        'Se arriva qui ha trovato il record
            '        Exit Function
            '    End If
            'Next
            Dim findTheseVals03(3) As Object

            ' Set the values of the keys to find.
            findTheseVals03(0) = UCase(inIdAppParameter)
            findTheseVals03(1) = inWerks
            findTheseVals03(2) = inLgnum
            findTheseVals03(3) = inIdDevice

            Dim foundRow03 As DataRow = objDataTableAppParamsInfo.Rows.Find(findTheseVals03)
            If Not (foundRow03 Is Nothing) Then
                outAppParamValue = foundRow03("ZvalueWmsAppParams").ToString()
                GetSingleParameterValue = 0
                Exit Function
            End If



            '2 => si filtra per tutti i parametri passati valorizzati ( inWerks, inLgnum )
            'For i = 0 To objDataTableAppParamsInfo.Rows.Count - 1
            '    If objDataTableAppParamsInfo.Rows(i)("Werks") = inWerks And _
            '       objDataTableAppParamsInfo.Rows(i)("Lgnum") = inLgnum Then

            '        outAppParamValue = objDataTableAppParamsInfo.Rows(i)("ZvalueWmsAppParams")

            '        'Se arriva qui ha trovato il record
            '        Exit Function
            '    End If
            'Next

            Dim findTheseVals02(3) As Object

            ' Set the values of the keys to find.
            findTheseVals02(0) = UCase(inIdAppParameter)
            findTheseVals02(1) = inWerks
            findTheseVals02(2) = inLgnum

            Dim foundRow02 As DataRow = objDataTableAppParamsInfo.Rows.Find(findTheseVals02)
            If Not (foundRow02 Is Nothing) Then
                outAppParamValue = foundRow02("ZvalueWmsAppParams").ToString()
                GetSingleParameterValue = 0
                Exit Function
            End If


            '3 => si filtra per tutti i parametri passati valorizzati ( inWerks )
            'For i = 0 To objDataTableAppParamsInfo.Rows.Count - 1
            '    If objDataTableAppParamsInfo.Rows(i)("Werks") = inWerks Then

            '        outAppParamValue = objDataTableAppParamsInfo.Rows(i)("ZvalueWmsAppParams")

            '        'Se arriva qui ha trovato il record
            '        Exit Function
            '    End If
            'Next

            Dim findTheseVals01(3) As Object

            ' Set the values of the keys to find.
            findTheseVals01(0) = UCase(inIdAppParameter)
            findTheseVals01(1) = inWerks

            Dim foundRow01 As DataRow = objDataTableAppParamsInfo.Rows.Find(findTheseVals01)
            If Not (foundRow01 Is Nothing) Then
                outAppParamValue = foundRow01("ZvalueWmsAppParams").ToString()
                GetSingleParameterValue = 0
                Exit Function
            End If


            '4 => si filtra solo il singolo parametro ( settaggio globale )

            Dim findTheseVals(3) As Object

            ' Set the values of the keys to find.
            findTheseVals(0) = UCase(inIdAppParameter)
            findTheseVals(1) = inWerks

            Dim foundRow As DataRow = objDataTableAppParamsInfo.Rows.Find(findTheseVals)
            If Not (foundRow Is Nothing) Then
                outAppParamValue = foundRow("ZvalueWmsAppParams").ToString()
                GetSingleParameterValue = 0
                Exit Function
            End If


            GetSingleParameterValue = RetCode


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetSingleParameterValue = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function CreateDateTableForAppParams() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForAppParams = 1 'init at error


            Dim WorkZappName As DataColumn = New DataColumn("ZappName") 'declaring a column named Name
            WorkZappName.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkZappName) 'adding the column to table

            Dim WorkWerks As DataColumn = New DataColumn("Werks") 'declaring a column named Name
            WorkWerks.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkWerks) 'adding the column to table

            Dim WorkLgnum As DataColumn = New DataColumn("Lgnum") 'declaring a column named Name
            WorkLgnum.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkLgnum) 'adding the column to table

            Dim WorkIdWmsDevices As DataColumn = New DataColumn("IdWmsDevices") 'declaring a column named Name
            WorkIdWmsDevices.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkIdWmsDevices) 'adding the column to table

            Dim WorkZidWmsAppParams As DataColumn = New DataColumn("ZidWmsAppParams") 'declaring a column named Name
            WorkZidWmsAppParams.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkZidWmsAppParams) 'adding the column to table

            Dim WorkZvalueWmsAppParams As DataColumn = New DataColumn("ZvalueWmsAppParams") 'declaring a column named Name
            WorkZvalueWmsAppParams.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkZvalueWmsAppParams) 'adding the column to table

            Dim WorkEnable As DataColumn = New DataColumn("Enable") 'declaring a column named Name
            WorkEnable.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableAppParamsInfo.Columns.Add(WorkEnable) 'adding the column to table


            'Creo la chiave primaria
            objDataTableAppParamsInfo.PrimaryKey = New DataColumn() {objDataTableAppParamsInfo.Columns("ZidWmsAppParams"), _
                                                                     objDataTableAppParamsInfo.Columns("Werks"), _
                                                                     objDataTableAppParamsInfo.Columns("Lgnum"), _
                                                                     objDataTableAppParamsInfo.Columns("IdWmsDevices")}


            CreateDateTableForAppParams = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForAppParams = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    'Public Shared Function RefreshDateTableForSystemInfo() As Long
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

    '        RefreshDateTableForSystemInfo = 1 'init at error

    '        If (objDataTableAppParamsInfo Is Nothing) Then Exit Function

    '        If (objDataTableAppParamsInfo.Rows.Count = 0) Then Exit Function

    '        For Each WorkRow In objDataTableAppParamsInfo.Rows
    '            WorkPropertyId = WorkRow.Item("PropertyId")
    '            Select Case UCase(WorkPropertyId)
    '                Case "SYSID"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Sysid
    '                Case "MANDT"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Mandt
    '                Case "DBSYS"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dbsys
    '                Case "SAPRL"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Saprl
    '                Case "DATUM"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Datum
    '                Case "UZEIT"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Uzeit
    '                Case "UNAME"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Uname
    '                Case "HOST"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Host
    '                Case "DATLO"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Datlo
    '                Case "TIMLO"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Timlo
    '                Case "ZONLO"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Zonlo
    '                Case "TZONE"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Tzone
    '                Case "DAYST"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dayst
    '                Case "FDAYW"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Fdayw
    '                Case "DBNAM"
    '                    WorkPropertyValue = SapSystemInfo.SystInfo_Rec.Dbnam
    '                Case Else
    '                    WorkPropertyValue = "NO DATA"
    '            End Select
    '            WorkRow.Item("PropertyValue") = WorkPropertyValue
    '        Next

    '        RefreshDateTableForSystemInfo = RetCode

    '        '**************************************
    '    Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
    '        RefreshDateTableForSystemInfo = 1000 'IL THREAD E' USCITO DAL LOOP
    '        'LOG ERROR CONDITION
    '        clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
    '        '**************************************
    '    Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

    '    End Try
    'End Function


End Class
