' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 10/04/2012
' DATA MODIFICA     : 10/04/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni delle DESTINAZIONE DI INGRESSO
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoInputDestination


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoInputDestination"

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableInputDestinationInfo As New DataTable

    Public Shared SelectionOnRun As Boolean 'flag che indica una selezione di destinazione in corso


    Public Shared FirstLoadExecuted_Step_1 As Boolean = False


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

            FirstLoadExecuted_Step_1 = False

            If (Not (objDataTableInputDestinationInfo Is Nothing)) Then
                objDataTableInputDestinationInfo.Rows.Clear()
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
    Public Shared Function CreateDateTable() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTable = 1 'init at error

            Dim WorkDESCRIZIONE_CAUSALE As DataColumn = New DataColumn("DESCRIZIONE_CAUSALE") 'declaring a column named Name
            WorkDESCRIZIONE_CAUSALE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkDESCRIZIONE_CAUSALE) 'adding the column to table

            Dim WorkDESCRIZIONE_UBICAZIONE As DataColumn = New DataColumn("DESCRIZIONE_UBICAZIONE") 'declaring a column named Name
            WorkDESCRIZIONE_UBICAZIONE.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkDESCRIZIONE_UBICAZIONE) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkCODICE_COMMESSA As DataColumn = New DataColumn("CODICE_COMMESSA") 'declaring a column named Name
            WorkCODICE_COMMESSA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkCODICE_COMMESSA) 'adding the column to table

            Dim WorkAUFNR As DataColumn = New DataColumn("AUFNR") 'declaring a column named Name
            WorkAUFNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkAUFNR) 'adding the column to table

            Dim WorkEBELN As DataColumn = New DataColumn("EBELN") 'declaring a column named Name
            WorkEBELN.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkEBELN) 'adding the column to table

            Dim WorkEBELP As DataColumn = New DataColumn("EBELP") 'declaring a column named Name
            WorkEBELP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkEBELP) 'adding the column to table

            Dim WorkMATNR_ODP_REQ_QTY As DataColumn = New DataColumn("MATNR_ODP_REQ_QTY") 'declaring a column named Name
            WorkEBELP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkMATNR_ODP_REQ_QTY) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkEBELP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableInputDestinationInfo.Columns.Add(WorkMEINS) 'adding the column to table

            CreateDateTable = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTable = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
