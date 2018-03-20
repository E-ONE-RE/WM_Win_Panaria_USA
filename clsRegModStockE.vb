' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/12/2012
' DATA MODIFICA     : 18/12/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di REG. MOVIMENTO DI STOCK E
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility


Public Class clsRegModStockE


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsRegModStockE"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableGiacenzeInfo As New DataTable

    Public Shared AbilitaSceltaSingoloStock As Boolean

    Public Shared UbicazioneMovimento As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared FoundGiacenzeMateriale As Boolean

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False
    Public Shared FirstLoadExecuted_Step_2 As Boolean = False
    Public Shared FirstLoadExecuted_Step_3 As Boolean = False
    Public Shared FirstLoadExecuted_Step_4 As Boolean = False

    'MI INDICA CHE TIPO DI MOVIMENTO DI STOCK 'E'
    Public Shared FunctionRegModStockEType As clsDataType.FunctionRegModStockEType


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

            FoundGiacenzeMateriale = False

            AbilitaSceltaSingoloStock = False

            FunctionRegModStockEType = clsDataType.FunctionRegModStockEType.FunctionRegModStockETypeNone

            RetCode += clsSapUtility.ResetUbicazioneStruct(UbicazioneMovimento)

            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            RetCode += ClearGiacenzeInfo()

            FirstLoadExecuted_Step_1 = False
            FirstLoadExecuted_Step_2 = False
            FirstLoadExecuted_Step_3 = False
            FirstLoadExecuted_Step_4 = False

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
    Public Shared Function ClearForNewPositionRead() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearForNewPositionRead = 1 'init at error

            FoundGiacenzeMateriale = False

            AbilitaSceltaSingoloStock = False

            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            RetCode += ClearGiacenzeInfo()

            FirstLoadExecuted_Step_3 = False
            FirstLoadExecuted_Step_4 = False

            ClearForNewPositionRead = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearForNewPositionRead = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function ClearGiacenzeInfo() As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearGiacenzeInfo = 1 'init at error

            If (Not (objDataTableGiacenzeInfo Is Nothing)) Then
                objDataTableGiacenzeInfo.Rows.Clear()
            End If

            ClearGiacenzeInfo = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearGiacenzeInfo = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CreateDateTableForGiacenze() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForGiacenze = 1 'init at error

            Dim WorkWERKS As DataColumn = New DataColumn("WERKS") 'declaring a column named Name
            WorkWERKS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkWERKS) 'adding the column to table

            Dim WorkLGNUM As DataColumn = New DataColumn("LGNUM") 'declaring a column named Name
            WorkLGNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGNUM) 'adding the column to table

            Dim WorkLGTYP As DataColumn = New DataColumn("LGTYP") 'declaring a column named Name
            WorkLGTYP.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGTYP) 'adding the column to table

            Dim WorkLGPLA As DataColumn = New DataColumn("LGPLA") 'declaring a column named Name
            WorkLGPLA.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGPLA) 'adding the column to table

            Dim WorkLQNUM As DataColumn = New DataColumn("LQNUM") 'declaring a column named Name
            WorkLQNUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLQNUM) 'adding the column to table

            Dim WorkMATNR As DataColumn = New DataColumn("MATNR") 'declaring a column named Name
            WorkMATNR.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkMATNR) 'adding the column to table

            Dim WorkCHARG As DataColumn = New DataColumn("CHARG") 'declaring a column named Name
            WorkCHARG.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkCHARG) 'adding the column to table

            Dim WorkBESTQ As DataColumn = New DataColumn("BESTQ") 'declaring a column named Name
            WorkBESTQ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkBESTQ) 'adding the column to table

            Dim WorkMEINS As DataColumn = New DataColumn("MEINS") 'declaring a column named Name
            WorkMEINS.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkMEINS) 'adding the column to table

            Dim WorkGESME As DataColumn = New DataColumn("GESME") 'declaring a column named Name
            WorkGESME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkGESME) 'adding the column to table

            Dim WorkVERME As DataColumn = New DataColumn("VERME") 'declaring a column named Name
            WorkVERME.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkVERME) 'adding the column to table

            Dim WorkLENUM As DataColumn = New DataColumn("LENUM") 'declaring a column named Name
            WorkLENUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLENUM) 'adding the column to table

            Dim WorkSOBKZ As DataColumn = New DataColumn("SOBKZ") 'declaring a column named Name
            WorkSOBKZ.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkSOBKZ) 'adding the column to table

            Dim WorkSONUM As DataColumn = New DataColumn("SONUM") 'declaring a column named Name
            WorkSONUM.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkSONUM) 'adding the column to table

            Dim WorkLGORT As DataColumn = New DataColumn("LGORT") 'declaring a column named Name
            WorkLGORT.DataType = System.Type.GetType("System.String") 'setting the datatype for the column
            objDataTableGiacenzeInfo.Columns.Add(WorkLGORT) 'adding the column to table

            CreateDateTableForGiacenze = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForGiacenze = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
