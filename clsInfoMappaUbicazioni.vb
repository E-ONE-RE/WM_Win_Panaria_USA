' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 26/10/2011
' DATA MODIFICA     : 26/10/2011
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la funzione di visualizzare le informazioni della MAPPA UBICAZIONI
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType

Public Class clsInfoMappaUbicazioni


    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsInfoMappaUbicazioni"

    ' OGGETTO DATA TABLE PER VISUALIZZARE DATI NELLE GRIGLIE
    Public Shared objDataTableMappaUbicazioniInfo As New DataTable


    'VALORI DI FILTRO PER LA VISUALIZZAZIONE DEI DATI
    Public Shared FilterNumMag As String
    Public Shared FilterTipiMag As String
    Public Shared FilterUbicazione As String

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

            FilterNumMag = ""
            FilterTipiMag = ""
            FilterUbicazione = ""
            FirstLoadExecuted_Step_1 = False

            If (Not (objDataTableMappaUbicazioniInfo Is Nothing)) Then
                objDataTableMappaUbicazioniInfo.Rows.Clear()
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


            clsDataType.CreateDateTableForUbicazioni(objDataTableMappaUbicazioniInfo)


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
