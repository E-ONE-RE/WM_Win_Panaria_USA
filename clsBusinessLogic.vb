' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/07/2011
' DATA MODIFICA     : 18/07/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa tutte le funzioni di logica dell'applicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsBusinessLogic

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsBusinessLogic"


    '***********************************************************************************
    '>>>> STRUTTURE PUBBLICHE
    '***********************************************************************************
    Public Structure SapFunctionError
        Public ERROR_CODE As String
        Public ERROR_SUBRC As Long
        Public ERROR_DESCRIPTION As String
    End Structure


    '***********************************************************************************
    '***********************************************************************************

    Public Shared Function InitSapFunctionError(ByRef inSapFunctionError As SapFunctionError) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            inSapFunctionError.ERROR_CODE = ""
            inSapFunctionError.ERROR_SUBRC = 0
            inSapFunctionError.ERROR_DESCRIPTION = ""

            InitSapFunctionError = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            InitSapFunctionError = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function DaCodiceCestaACodiceStockE(ByVal inCodiceCesta As String, ByRef outCodiceStockE As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim OffsetIniziale As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            DaCodiceCestaACodiceStockE = 1 'init at error

            If (Len(inCodiceCesta) <> DefaultLunghezzaCodiceUM) And (Len(inCodiceCesta) <> DefaultLunghezzaCodiceUMInterna) Then
                DaCodiceCestaACodiceStockE = 10
                Exit Function
            End If

            If (Len(inCodiceCesta) = DefaultLunghezzaCodiceUMInterna) Then
                OffsetIniziale = 10
            End If

            'RECUPERO PRIMA PARTE CON NUMERO ODV / NUMERO ODP
            outCodiceStockE = "00000" & inCodiceCesta.Substring(OffsetIniziale, 5)

            'RECUPERO SECONDA PARTE DELLA POSIZIONE
            outCodiceStockE = outCodiceStockE & "00" & inCodiceCesta.Substring(OffsetIniziale + 5, 4)

            DaCodiceCestaACodiceStockE = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            DaCodiceCestaACodiceStockE = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function DaCodiceUbicazioneACodiceStockE(ByVal inCodiceUbicazione As String, ByRef outCodiceStockE As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : ESEGUE IL REFRESH DEI DATI DELLE USER INFORMATION
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim OffsetIniziale As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            DaCodiceUbicazioneACodiceStockE = 1 'init at error

            If (Len(inCodiceUbicazione) <> DefaultLunghezzaCodiceUM) Then
                DaCodiceUbicazioneACodiceStockE = 10
                Exit Function
            End If


            'RECUPERO PRIMA PARTE CON NUMERO ODV / NUMERO ODP
            OffsetIniziale = 1
            outCodiceStockE = "00000" & inCodiceUbicazione.Substring(OffsetIniziale, 5)

            'RECUPERO SECONDA PARTE DELLA POSIZIONE
            outCodiceStockE = outCodiceStockE & "00" & inCodiceUbicazione.Substring(OffsetIniziale + 5, 4)

            DaCodiceUbicazioneACodiceStockE = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            DaCodiceUbicazioneACodiceStockE = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
