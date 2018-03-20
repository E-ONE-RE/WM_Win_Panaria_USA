Imports System
Public Class clsFileLog

    Public Const Name As String = "clsFileLog"

    Public Enum FileLogLevelDtlEnum
        LogLevelDtlNone = 0
        LogLevelDtlOnlyError = 1
        LogLevelDtlAllAction = 2
    End Enum

    '************************
    'ATTRIBUTE OF SOURCE CODE
    Public Shared AbsoluteFileName As String
    Public Shared FileName As String
    Public Shared DateOnFileName As String
    Public Shared StadardApplicationLogFileName As Boolean
    Public Shared GenericLogFileName As Boolean

    Public Shared Sub SetLogFileName(Optional ByVal inLogFileName As String = "", Optional ByVal inLogLevelDtl As FileLogLevelDtlEnum = FileLogLevelDtlEnum.LogLevelDtlOnlyError)
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inLogFileName <> "") Then
                If (Not clsFile.IsPathRooted(inLogFileName)) Then
                    'in this case it's relative path so need to add the current directory
                    inLogFileName = clsUtility.GetBaseDirectory() & inLogFileName
                End If
            Else

                If (GenericLogFileName = True) Then
                    'in questo caso si usa il nome [FileName] + currente date with ".log" extension
                    inLogFileName = clsUtility.GetGenericLogFileName(FileName, False)
                Else
                    'in this case the default log file name is the exe file name + currente date with ".log" extension
                    inLogFileName = clsUtility.GetWorkStationApplicationLogFileName(False)
                End If

                DateOnFileName = clsUtility.GetDateNowString(True, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "dd_MM_yyyy")
                StadardApplicationLogFileName = True
            End If

            AbsoluteFileName = inLogFileName

            FileName = clsFile.GetFileName(AbsoluteFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT


            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub
    Private Shared Function WriteLog(ByVal inString As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        'Dim objFile As clsFile
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WriteLog = 0 'init

            If (inString = "") Then Exit Function

            'append to the strin to the log file
            RetCode = clsFile.AppendTextFile(AbsoluteFileName, inString)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Dim tmpString As String
            tmpString = Now.ToString() & "Error in [WriteLog] of " & Name
            clsFile.WriteEmergencyLog(tmpString)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            WriteLog = RetCode
        End Try
    End Function
    Public Shared Function WriteLog(ByVal inErrorInfoType As clsProgramError.ErrorInfoTypeEnum, ByVal inClassObjectName As String, ByVal inMethodName As String, ByVal inExceptionCode As Long, ByVal inExcepionDescription As String, ByVal inString As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim tmpStringToLog As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (AbsoluteFileName Is Nothing) Then
                SetLogFileName()
            End If
            If (AbsoluteFileName.Length = 0) Then
                SetLogFileName()
            End If
            'il nome del file deve essere relativo alla data corrente
            'si fa un FILE DI LOG specifico per ogni giorno
            If (DateOnFileName <> clsUtility.GetDateNowString(True, clsUtility.DateFormatTypeEnum.DateFormatTypeNone, "dd_MM_yyyy")) Then
                SetLogFileName()
            End If

            tmpStringToLog = Now.ToString()
            Select Case (inErrorInfoType)
                Case clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeLog
                    tmpStringToLog = tmpStringToLog & ";[L]"
                Case clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeWarning
                    tmpStringToLog = tmpStringToLog & ";[W]"
                Case clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError
                    tmpStringToLog = tmpStringToLog & ";[E]"
                Case clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeCritical
                    tmpStringToLog = tmpStringToLog & ";[C]"
                Case Else
                    tmpStringToLog = tmpStringToLog & ";[ ]"
            End Select

            tmpStringToLog = tmpStringToLog & ";" & inClassObjectName
            tmpStringToLog = tmpStringToLog & ";" & inMethodName
            tmpStringToLog = tmpStringToLog & ";" & inString
            If (Not (inExcepionDescription Is Nothing)) Then
                tmpStringToLog = tmpStringToLog & ";" & inExcepionDescription
            End If

            RetCode = WriteLog(tmpStringToLog)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            Dim tmpString As String
            tmpString = Now.ToString() & "Error in [WriteLog] of " & clsFileLog.Name
            clsFile.WriteEmergencyLog(tmpString)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            WriteLog = RetCode
        End Try
    End Function

    Public Sub New()

    End Sub
End Class
