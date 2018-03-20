' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 20/09/2013
' DATA MODIFICA     : 20/09/2013
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni delle UBICAZIONI
' *****************************************************************************************


Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoUbicazione
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoUbicazione"

    '*******************************************************
    ' OGGETTI DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableUbicazioneInfo As New DataTable

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False

    Public Shared Function CreateDateTableForUbicazioneInfo() As Long
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

            CreateDateTableForUbicazioneInfo = 1 'init at error

            Dim WorkPropertyId As DataColumn = New DataColumn("PropertyId") 'declaring a column named Name
            WorkPropertyId.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbicazioneInfo.Columns.Add(WorkPropertyId) 'adding the column to table

            Dim WorkPropertyValue As DataColumn = New DataColumn("PropertyValue") 'declaring a column named Name
            WorkPropertyValue.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableUbicazioneInfo.Columns.Add(WorkPropertyValue) 'adding the column to table

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "LGNUM"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "LGTYP"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "LGPLA"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "LGBER"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "LPTYP"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SKZUA"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SKZUE"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SKZSA"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SKZSE"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SKZSI"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "SPGRU"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "KZLER"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            WorkRow = objDataTableUbicazioneInfo.NewRow()
            WorkRow.Item("PropertyId") = "KZVOL"
            WorkRow.Item("PropertyValue") = ""
            objDataTableUbicazioneInfo.Rows.Add(WorkRow) 'aggiungo la riga

            CreateDateTableForUbicazioneInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForUbicazioneInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function RefreshDateTableForUbicazioneInfo(ByRef inInfoUbicazione As clsDataType.SapWmUbicazione) As Long
        ' *****************************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE INFORMATIONI DELLE UBICAZIONI
        ' *****************************************************************************
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim WorkRow As DataRow
        Dim WorkPropertyId As String = ""
        Dim WorkPropertyValue As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RefreshDateTableForUbicazioneInfo = 1 'init at error

            If (objDataTableUbicazioneInfo Is Nothing) Then Exit Function

            If (objDataTableUbicazioneInfo.Rows.Count = 0) Then Exit Function

            For Each WorkRow In objDataTableUbicazioneInfo.Rows
                WorkPropertyId = WorkRow.Item("PropertyId")
                Select Case UCase(WorkPropertyId)
                    Case "LGNUM"
                        WorkPropertyValue = inInfoUbicazione.NumeroMagazzino
                    Case "LGTYP"
                        WorkPropertyValue = inInfoUbicazione.TipoMagazzino
                    Case "LGPLA"
                        WorkPropertyValue = inInfoUbicazione.Ubicazione
                        'Case "USERID"
                        '    WorkPropertyValue = clsUser.SapWmsUser.Userid
                        'Case "PROFID"
                        '    WorkPropertyValue = clsUser.SapWmsUser.Profid
                        'Case "NAME_FIRST"
                        '    WorkPropertyValue = clsUser.SapWmsUser.NameFirst
                        'Case "NAME_LAST"
                        '    WorkPropertyValue = clsUser.SapWmsUser.NameLast
                        'Case "BCDA1"
                        '    WorkPropertyValue = clsUser.SapWmsUser.Bcda1
                        'Case "MOB_NUMBER"
                        '    WorkPropertyValue = clsUser.SapWmsUser.MobNumber
                    Case Else
                        WorkPropertyValue = "NO DATA"
                End Select
                WorkRow.Item("PropertyValue") = WorkPropertyValue
            Next

            RefreshDateTableForUbicazioneInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RefreshDateTableForUbicazioneInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
