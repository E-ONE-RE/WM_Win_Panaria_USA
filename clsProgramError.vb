Imports System
Imports System.Reflection
Imports System.Type
Imports System.AppDomain
Imports System.Windows.Forms

Public Class clsProgramError
    '*****************************************
    'MANAGEMENT OF OBJECT

    '************************
    'DATA TYPE
    Public Enum ErrorInfoTypeEnum
        ErrorInfoTypeLog = 0
        ErrorInfoTypeWarning = 1
        ErrorInfoTypeError = 2
        ErrorInfoTypeCritical = 3
    End Enum

    Public Enum ErrorOutputMode
        ErrorOutputModeOnlyFile = 0
        ErrorOutputModeFileAndMsgBox = 1
        ErrorOutputModeFileAndDb = 2
    End Enum

    '************************
    'ATTRIBUTE OF SOURCE CODE
    Private Shared FirstErrorLogExecute As Boolean 'flag to track about the first log execute

    Public Shared Sub ExecLogIfGetErrorCondition(ByVal inRetCode As Long, ByVal inErrorIfNotZero As Long, ByVal inClassObjectName As String, ByVal inMethodName As String, ByVal inErrorInfoType As ErrorInfoTypeEnum, ByVal inStringError As String, Optional ByVal inAppMsgBoxTitle As String = "", Optional ByVal inErrorOutputMode As ErrorOutputMode = ErrorOutputMode.ErrorOutputModeOnlyFile)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim ThereIsOneError As Boolean
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inErrorIfNotZero) Then
                If (inRetCode) Then
                    ThereIsOneError = True
                End If
            Else
                If (inRetCode = 0) Then
                    ThereIsOneError = True
                End If
            End If
            If (Not (ThereIsOneError)) Then Exit Sub

            'log error condition
            ManageLogErrorCondition(inClassObjectName, inMethodName, inErrorInfoType, inStringError, Nothing, inAppMsgBoxTitle, inErrorOutputMode)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT


            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Shared Sub ManageLogErrorCondition(ByVal inClassObjectName As String, ByVal inMethodName As String, ByVal inErrorInfoType As ErrorInfoTypeEnum, ByVal inStringError As String, Optional ByVal inException As Exception = Nothing, Optional ByVal inAppMsgBoxTitle As String = "", Optional ByVal inErrorOutputMode As ErrorOutputMode = ErrorOutputMode.ErrorOutputModeOnlyFile)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim tmpString As String
        Dim tmpExString As String
        Dim tmpExCode As Long
        Dim ApplicationPath As String
        Dim ApplicationName As String

        tmpExString = "" 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If inErrorInfoType = ErrorInfoTypeEnum.ErrorInfoTypeError Or inErrorInfoType = ErrorInfoTypeEnum.ErrorInfoTypeCritical Then
                System.Windows.Forms.Application.DoEvents()
            End If

            'get one string information from EXCEPTION object
            If (Not (inException Is Nothing)) Then

                '>>> VERIFICO SE L'ERRORE E' UN ERRORE DI RETE
                Call ManageNetWorkError(inClassObjectName, inMethodName, inException)

                tmpExCode = 0 'not used now
                tmpExString = "" 'init
                tmpExString = tmpExString & "Ex.Message:" & inException.Message & ControlChars.CrLf
                tmpExString = tmpExString & "Ex.Source:" & "" & ControlChars.CrLf
                'If (Not (inException.TargetSite Is Nothing)) Then
                '    tmpExString = tmpExString & "Ex.TargetSite:" & inException.TargetSite.Name & ControlChars.CrLf
                'End If
                tmpExString = tmpExString & "Ex.StackTrace:" & inException.StackTrace & ControlChars.CrLf

                'mi prendo anche le informazioni del numero di riga e colonna di dove è accaduta l'eccezione
                'Dim Trace As New System.Diagnostics.StackTrace(inException, True)
                'If (Not (Trace Is Nothing)) Then
                '    tmpExString = tmpExString & "Line:" & Trace.GetFrame(0).GetFileLineNumber().ToString() 'Numero Riga
                '    tmpExString = tmpExString & "Column:" & Trace.GetFrame(0).GetFileColumnNumber().ToString() ' Numero Colonna
                '    tmpExString = tmpExString & "Method:" & Trace.GetFrame(0).GetMethod.Name.ToString() 'Nome Funzione
                'End If
            End If

            'in every case I log the error condition
            RetCode = clsFileLog.WriteLog(inErrorInfoType, inClassObjectName, inMethodName, tmpExCode, tmpExString, inStringError)

            If (inAppMsgBoxTitle = "") Then
                'di default visualizzo il nome dell'applicazione
                ApplicationPath = clsUtility.GetApplicationPath()
                ApplicationName = clsUtility.GetApplicationName(True, False)
                inAppMsgBoxTitle = ApplicationPath & "\" & ApplicationName
            End If

            Select Case (inErrorOutputMode)
                Case ErrorOutputMode.ErrorOutputModeOnlyFile

                Case ErrorOutputMode.ErrorOutputModeFileAndMsgBox
                    tmpString = "Attention! Error condition" & ControlChars.CrLf
                    tmpString = tmpString & "Class:" & inClassObjectName & ControlChars.CrLf
                    tmpString = tmpString & "Method:" & inMethodName & ControlChars.CrLf
                    tmpString = tmpString & "Description:" & inStringError & ControlChars.CrLf
                    tmpString = tmpString & tmpExString
                    MessageBox.Show(tmpString, inAppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                Case ErrorOutputMode.ErrorOutputModeFileAndDb
                    '??? fare scrittura db

            End Select
            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT


            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Public Shared Sub ManageNetWorkError(ByVal inClassObjectName As String, ByVal inMethodName As String, Optional ByVal inException As Exception = Nothing)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim FoundErrorConnection As Boolean
        Dim UserAnswer As DialogResult = DialogResult.No
        Dim WorkString As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inException Is Nothing) Then
                Exit Sub
            End If

            FoundErrorConnection = False 'init

            'If (UCase(inException.Message) = UCase(clsAppTranslation.GetSingleParameterValue(917, "", "Impossibile effettuare la connessione al server remoto."))) Then
            If (UCase(inException.Message) = UCase("Impossibile stabilire la connessione alla rete.")) Then
                FoundErrorConnection = True
            End If

            If ((UCase(inException.Message).Substring(1, 40)) = (UCase("LOCATION    CPIC (TCP/IP) ON LOCAL HOST "))) Then
                FoundErrorConnection = True
            End If

            If (FoundErrorConnection = False) Then
                Exit Sub
            End If

            'AVVISO L'UTENTE DELLA PERDITA DI CONNESSIONE
            WorkString = "Connection Error. Would you Close the Application?" & vbCrLf & "Please Restart it again manually."
            UserAnswer = MessageBox.Show(WorkString, AppMsgBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If (UserAnswer = DialogResult.Yes) Then
                Application.Exit()
                End
            End If

            ''SE ARRIVO QUI HO LE CONDIZIONI DI ERRORE DI RETE
            'tmpString = "Attention! Connection error!" & vbCrLf & "WsHostName:" & WsHostName & vbCrLf & "WsPortNumber:" & WsPortNumber & vbCrLf & "SapClient:" & SapClient & vbCrLf & "Verify the connection status and retry."
            'MessageBox.Show(tmpString, AppMsgBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'Application.Exit()


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT


            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
End Class
