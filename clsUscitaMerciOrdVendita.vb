' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/04/2012
' DATA MODIFICA     : 30/04/2012
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di USCITA MERCI per ORDINE DI VENDITA
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility

Public Class clsUscitaMerciOrdVendita

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUscitaMerciOrdVendita"


    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared UbicazioniDestProposte As clsDataType.SapWmUbicazione()
    Public Shared GiacenzeOrigineProposte As clsDataType.SapWmGiacenza()
    Public Shared DescrUbiDestinazione As String

    Public Shared OrdineVenditaTestata As clsDataType.SapOrdineVendita
    Public Shared OrdineVenditaPosizioni As clsDataType.SapOrdineVendita()

    Public Shared FirstLoadExecuted_Step_1 As Boolean = False
    Public Shared FirstLoadExecuted_Step_2 As Boolean = False
    Public Shared FirstLoadExecuted_Step_3 As Boolean = False
    Public Shared FirstLoadExecuted_Step_4 As Boolean = False


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
            RetCode += clsSapUtility.ResetOrdineVenditaStruct(OrdineVenditaTestata)

            If (Not OrdineVenditaPosizioni Is Nothing) Then
                ReDim OrdineVenditaPosizioni(0)
                OrdineVenditaPosizioni.Clear(OrdineVenditaPosizioni, 0, 0)
            End If
            If (Not UbicazioniDestProposte Is Nothing) Then
                ReDim UbicazioniDestProposte(0)
                UbicazioniDestProposte.Clear(UbicazioniDestProposte, 0, 0)
            End If
            If (Not GiacenzeOrigineProposte Is Nothing) Then
                ReDim GiacenzeOrigineProposte(0)
                GiacenzeOrigineProposte.Clear(GiacenzeOrigineProposte, 0, 0)
            End If

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
    Public Shared Function CheckRightPositionMaterialCode(ByVal inCodiceMateriale As String, ByRef outCheckOk As Boolean, ByRef outNotOkCheckDescription As String) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckRightPositionMaterialCode = 1 'init at error

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)
            RetCode += clsSapUtility.ResetOrdineVenditaStruct(OrdineVenditaTestata)

            If (Not OrdineVenditaPosizioni Is Nothing) Then
                ReDim OrdineVenditaPosizioni(0)
                OrdineVenditaPosizioni.Clear(OrdineVenditaPosizioni, 0, 0)
            End If
            If (Not UbicazioniDestProposte Is Nothing) Then
                ReDim UbicazioniDestProposte(0)
                UbicazioniDestProposte.Clear(UbicazioniDestProposte, 0, 0)
            End If
            If (Not GiacenzeOrigineProposte Is Nothing) Then
                ReDim GiacenzeOrigineProposte(0)
                GiacenzeOrigineProposte.Clear(GiacenzeOrigineProposte, 0, 0)
            End If

            FirstLoadExecuted_Step_1 = False
            FirstLoadExecuted_Step_2 = False
            FirstLoadExecuted_Step_3 = False
            FirstLoadExecuted_Step_4 = False


            CheckRightPositionMaterialCode = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckRightPositionMaterialCode = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
