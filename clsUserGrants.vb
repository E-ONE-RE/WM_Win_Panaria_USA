' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI / LUCA BELLEI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 18/09/2015
' DATA MODIFICA     : 18/09/2015
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa la gestione dei PARAMETRI di BASE dell'applicazione
' *****************************************************************************************

Imports System.Web.Services
Imports System.Data
Imports clsDataType
Imports clsSapWS
Imports clsBusinessLogic


Public Class clsUserGrants
    '*****************************************
    'MANAGE OF CODE VERSION
    Private Const CodeClassObjectName As String = "clsUserGrants"

    Public outSapFunctionError As clsBusinessLogic.SapFunctionError

    Public Shared objSapProfOper As New Collection

    Public Structure SapAppProfUsersStruct
        Public NrOperation As String
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

            If (Not (objSapProfOper Is Nothing)) Then
                objSapProfOper.Clear()
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

    Public Shared Function CheckOperUserGrant(ByVal inIdOperations As String) As Boolean
        ' ************************************************************
        ' DESCRIZIONE : RESET DI TUTTI I DATI
        ' ************************************************************

        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CheckOperUserGrant = False 'init at error


            If UCase(clsUser.SapWmsUser.PROFID) = UCase(cstPROFID_ADMIN) Then
                CheckOperUserGrant = True
                Exit Function
            End If

            If Not IsNothing(objSapProfOper.Item(inIdOperations)) Then
                CheckOperUserGrant = True
            Else
                CheckOperUserGrant = False
            End If


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT

            'ELEMENTO NON PRESENTE NELLA COLLECTION (PRIVILEGIO NON PRESENTE : ZWMS_PROF_OPER )
            MsgBox(clsAppTranslation.GetSingleParameterValue(1159, "", "Utente non abilitato per l'operazione."), MsgBoxStyle.Exclamation)
            CheckOperUserGrant = False

            'LOG ERROR CONDITION
            'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

End Class
