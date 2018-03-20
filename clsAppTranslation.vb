' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI / LUCA BELLEI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 30/07/2015
' DATA MODIFICA     : 30/07/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la gestione dei PARAMETRI di BASE dell'applicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapWS
Imports clsBusinessLogic

Public Class clsAppTranslation

    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsAppTranslation"

    Public outSapFunctionError As clsBusinessLogic.SapFunctionError

    ' OGGETTO DATA TABLE PER VISUALIZZARE PARAMETRI NELLE GRIGLIE
    'Public Shared objDataTableAppParamsInfo As New DataTable
    Public Shared objSapAppTrans As New Collection


    Public Structure SapAppTransStruct
        Public NrMsg As String
        Public Text As String
    End Structure


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

            If (Not (objSapAppTrans Is Nothing)) Then
                objSapAppTrans.Clear()
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

    Public Shared Function GetApplicationParameters(ByRef outSapFunctionError As clsBusinessLogic.SapFunctionError) As Long
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim CheckOk As Boolean = False


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetApplicationParameters = 1 'init at error

            'CHIAMO IL WEB SERVICE PER LA LETTURA DEI PARAMETRI APPLICAZIONE da 0 a 999
            RetCode = clsSapWS.Call_ZWS_GET_APP_TRANSLATION(objSapAppTrans, CheckOk, outSapFunctionError, False, "ZMWS_MOB_MSG")
            If (RetCode <> 0) And (CheckOk = False) Then
                MessageBox.Show(clsAppTranslation.GetSingleParameterValue(837, "", "Check Lettura Traduzioni ERRORE!!!"))
            End If


            'CHIAMO IL WEB SERVICE PER LA LETTURA DEI PARAMETRI APPLICAZIONE da 1000 a 1999
            RetCode = clsSapWS.Call_ZWS_GET_APP_TRANSLATION(objSapAppTrans, CheckOk, outSapFunctionError, False, "ZMWS_MOB_MSG_01")
            If (RetCode <> 0) And (CheckOk = False) Then
                MessageBox.Show(clsAppTranslation.GetSingleParameterValue(837, "", "Check Lettura Traduzioni ERRORE!!!"))
            End If

            GetApplicationParameters = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetApplicationParameters = 1000 'IL THREAD E' USCITO DAL LOOP
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetSingleParameterValue(ByVal inIdAppTrans As Integer, ByRef outAppTransValue As String, ByVal InDefautAppTrans As String) As String
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'se passato -1 esco senza provare la traduzione
            If (inIdAppTrans < 0) Then
                outAppTransValue = "*" & InDefautAppTrans
                GetSingleParameterValue = outAppTransValue
                Exit Function
            End If

            outAppTransValue = objSapAppTrans.Item(inIdAppTrans.ToString("000"))
            If outAppTransValue = "" Then
                'CASO L'INDICE TROVATO MA STRINGA VUOTA / TRADUZIONE NO PRESENTE
                outAppTransValue = "@" & InDefautAppTrans
            End If

            GetSingleParameterValue = outAppTransValue

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT

            'CASO L'INDICE ERRATO NON TROVATO NELLA COLLECTION
            outAppTransValue = "!" & InDefautAppTrans

            GetSingleParameterValue = outAppTransValue

            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
