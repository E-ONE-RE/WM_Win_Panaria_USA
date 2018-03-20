' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 12/10/2011
' DATA MODIFICA     : 12/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni dei MOTIVI MOVIMENTI
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoMotiviMov


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoMotiviMov"

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableMotiviMovInfo As New DataTable


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI TIPI MAGAZZINO
    'Public Shared FilterNumMag As String
    'Public Shared FilterTipiMag As String

    'Public Shared FirstLoadExecuted_Step_1 As Boolean = False


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

            If (Not (objDataTableMotiviMovInfo Is Nothing)) Then
                objDataTableMotiviMovInfo.Rows.Clear()
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


    Public Shared Function CreateDateTableForMotiviMov() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForMotiviMov = 1 'init at error


            Dim WorkBWART As DataColumn = New DataColumn("BWART") 'declaring a column named Name
            WorkBWART.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMotiviMovInfo.Columns.Add(WorkBWART) 'adding the column to table

            Dim WorkGRUND As DataColumn = New DataColumn("GRUND") 'declaring a column named Name
            WorkGRUND.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMotiviMovInfo.Columns.Add(WorkGRUND) 'adding the column to table

            Dim WorkGRTXT As DataColumn = New DataColumn("GRTXT") 'declaring a column named Name
            WorkGRTXT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableMotiviMovInfo.Columns.Add(WorkGRTXT) 'adding the column to table


            CreateDateTableForMotiviMov = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForMotiviMov = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


End Class
