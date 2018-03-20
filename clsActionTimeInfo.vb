' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 02/05/2013
' DATA MODIFICA     : 02/05/2013
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa le informazioni dei tempi di esecuzione di una operazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility


Public Class clsActionTimeInfo

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsActionTimeInfo"


    '*****************************************
    ' >>> PROPRIETA E VARIABILI
    Public Shared DataOraInizioAction As Date = Date.MinValue
    Public Shared DataOraFineAction As Date = Date.MinValue
    Public Shared ActionDurata As Long = 0

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

            DataOraInizioAction = Date.MinValue
            DataOraFineAction = Date.MinValue
            ActionDurata = 0

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
    Public Shared Function ActionStart() As Long
        ' ************************************************************
        ' DESCRIZIONE : evento di START dell'operazione
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ActionStart = 1 'init at error

            DataOraInizioAction = Now
            DataOraFineAction = Date.MinValue
            ActionDurata = 0

            ActionStart = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ActionStart = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function ActionEnd() As Long
        ' ************************************************************
        ' DESCRIZIONE : evento di START dell'operazione
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ActionEnd = 1 'init at error

            DataOraFineAction = Now
            If (DataOraFineAction > DataOraInizioAction) Then
                ActionDurata = DateDiff("s", DataOraFineAction, DataOraInizioAction)
            Else
                ActionDurata = 0
            End If

            ActionEnd = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ActionEnd = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
