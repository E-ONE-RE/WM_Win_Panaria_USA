' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/04/2012
' DATA MODIFICA     : 30/04/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di USCITA MERCI per CONSEGNA
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility

Public Class clsUscitaMerciConsegna

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUscitaMerciConsegna"

    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum UM_Consegna_SourceCodeType
        UM_Consegna_SourceCodeTypeNone = 0
        UM_Consegna_SourceCodeTypeConsegna = 1
        UM_Consegna_SourceCodeTypeOdP = 2
        UM_Consegna_SourceCodeTypeBoth = 10
    End Enum

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared UbicazioneDestProposte As clsDataType.SapWmUbicazione()
    Public Shared DescrUbiDestinazione As String
    Public Shared OrdineProduzioneDestinazione As clsDataType.SapOrdineProduzione

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False
    Public Shared FirstLoadExecuted_Step_2 As Boolean = False
    Public Shared FirstLoadExecuted_Step_3 As Boolean = False
    Public Shared FirstLoadExecuted_Step_4 As Boolean = False

    Public Shared UM_ConsegnaSourceCodeType As UM_Consegna_SourceCodeType

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

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)
            RetCode += clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneDestinazione)

            UM_ConsegnaSourceCodeType = UM_Consegna_SourceCodeType.UM_Consegna_SourceCodeTypeNone

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
End Class
