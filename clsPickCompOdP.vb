' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 24/06/2015
' DATA MODIFICA     : 24/06/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di ENTRATA MERCE da PRODUZIONE
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapUtility

Public Class clsPickCompOdP


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsPickCompOdP"


    '*****************************************
    ' >>> TIPI DI DATI
    Public Enum PC_Prod_DestinationType
        PC_Prod_DestinationTypeNone = 0
        PC_Prod_DestinationTypeMagazzino = 1
        PC_Prod_DestinationTypeContoLavoro = 2
        PC_Prod_DestinationTypeProduzione = 3
        PC_Prod_DestinationTypeMagCommesse = 10
    End Enum

    Public Enum PC_Prod_SourceType
        PC_Prod_SourceTypeNone = 0
        PC_Prod_SourceTypeOdP = 1
        PC_Prod_SourceTypeUM = 2
    End Enum

    '*****************************************
    ' >>> PROPRIETA E VARIABILI
    Public Shared OrdineProduzioneOrigine As clsDataType.SapOrdineProduzione

    Public Shared SourceUbicazione As clsDataType.SapWmUbicazione
    Public Shared DestinationUbicazione As clsDataType.SapWmUbicazione
    Public Shared MaterialeGiacenza As clsDataType.SapWmGiacenza
    Public Shared UbicazioneDestProposte() As clsDataType.SapWmGiacenza
    Public Shared DescrUbiDestinazione As String
    Public Shared UbicazioneDestOnWork As clsDataType.SapStrateInputDestInfo
    Public Shared IndexUbicazioneDestAttiva As Long
    Public Shared IndexUbiVuotaDest As Long
    Public Shared SapComponentiOrdineProduzione() As clsDataType.SapComponenteOrdineProduzione

    Public Shared UdMTrasfList() As clsDataType.SapWmGiacenza


    Public Shared PC_ProdDestinationType As PC_Prod_DestinationType
    Public Shared PC_SourceType As PC_Prod_SourceType

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

            clsSapUtility.ResetOrdineProduzioneStruct(OrdineProduzioneOrigine)

            RetCode += clsSapUtility.ResetUbicazioneStruct(SourceUbicazione)
            RetCode += clsSapUtility.ResetUbicazioneStruct(DestinationUbicazione)
            RetCode += clsSapUtility.ResetGiacenzaStruct(MaterialeGiacenza)

            If (Not UbicazioneDestProposte Is Nothing) Then
                ReDim UbicazioneDestProposte(0)
                UbicazioneDestProposte.Clear(UbicazioneDestProposte, 0, 0)
            End If
            If (Not UdMTrasfList Is Nothing) Then
                ReDim UdMTrasfList(0)
                UdMTrasfList.Clear(UdMTrasfList, 0, 0)
            End If
            If (Not SapComponentiOrdineProduzione Is Nothing) Then
                ReDim SapComponentiOrdineProduzione(0)
                SapComponentiOrdineProduzione.Clear(SapComponentiOrdineProduzione, 0, 0)
            End If


            PC_ProdDestinationType = PC_Prod_DestinationType.PC_Prod_DestinationTypeNone

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
    Public Shared Function GetNumDestinazioniProposte() As Long
        ' ************************************************************
        ' DESCRIZIONE : 
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        'Dim RetCode As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNumDestinazioniProposte = 0 'init

            GetNumDestinazioniProposte = UbicazioneDestProposte.Length

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNumDestinazioniProposte = 0 'CONDIZIONE DI ERRORE
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    
End Class
