' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/05/2013
' DATA MODIFICA     : 30/05/2013
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa le funzioni di gestione delle missioni [ZWMS_JOBS] 
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility
Imports clsSapWS
Imports clsNavigation
Imports clsBusinessLogic
Imports clsUDS
Imports clsTASKLINES

Public Class clsTaskLinesAssigned

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsTaskLinesAssigned"

    'OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableTaskLinesAssigned As New DataTable

    Private Shared ErrDescription As String
    Private Shared SapFunctionError As clsBusinessLogic.SapFunctionError


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


            If (Not (objDataTableTaskLinesAssigned Is Nothing)) Then
                objDataTableTaskLinesAssigned.Rows.Clear()
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

    Public Shared Function CreateDateTableForTaskLinesAssigned() As Long
        ' ************************************************************
        ' DESCRIZIONE : crea data table per gliglia con JOB INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CreateDateTableForTaskLinesAssigned = 1 'init at error

            'CREO IL DATA TABLE PER GESTIRE TUTTE LE INFORMAZIONI DELLE TASK LINES
            RetCode = clsDataType.CreateDateTableForTaskLines(objDataTableTaskLinesAssigned)

            CreateDateTableForTaskLinesAssigned = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CreateDateTableForTaskLinesAssigned = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
