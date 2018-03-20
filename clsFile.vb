' *****************************************************************************************
' AUTORE            : MARCO PALTRINIERI
' DITTA             : eOneGroup
' DATA CREAZIONE    : 03/03/2009
' DATA MODIFICA     : 03/03/2009
' VERSIONE          : 1.0
' DESCRIZIONE       : la classe implementa tutti i metodi base per la gestione dei files
' *****************************************************************************************

Imports System
Imports System.IO
Imports clsUtility

Public Class clsFile

    Public Const Name As String = "clsFile"
    Public Shared RetryCounter As Integer = 5
    Public Shared RetryInterval As Integer = 500

    Public Sub New()
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT


            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Sub

    Public Shared Function GetWindowsTempPath() As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetWindowsTempPath = "" 'init

            GetWindowsTempPath = Path.GetTempPath()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetWindowsTempPath = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetNewTempFileName() As String
        Return GetNewTempFileName(False, False)
    End Function

    Public Shared Function GetNewTempFileName(ByVal FileNameOnly As Boolean, ByVal ApplicationPath As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim strTempPath As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetNewTempFileName = "" 'init

            GetNewTempFileName = Path.GetTempFileName()
            If ApplicationPath = True Then
                
                strTempPath = clsUtility.GetApplicationPath()
                If strTempPath.Substring(strTempPath.Length - 1, 1) <> "\" Then
                    GetNewTempFileName = strTempPath & "\" & Path.GetFileName(GetNewTempFileName)
                Else
                    GetNewTempFileName = strTempPath & Path.GetFileName(GetNewTempFileName)
                End If
            ElseIf FileNameOnly = True Then
                GetNewTempFileName = Path.GetFileName(GetNewTempFileName)
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNewTempFileName = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetDirectoryName(ByVal inFileName As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetDirectoryName = "" 'init

            If (inFileName = "") Then
                Exit Function
            End If

            GetDirectoryName = Path.GetDirectoryName(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetDirectoryName = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetFileName(ByVal inFileName As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetFileName = "" 'init

            If (inFileName = "") Then
                Exit Function
            End If

            GetFileName = Path.GetFileName(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFileName = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetExtension(ByVal inFileName As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetExtension = "" 'init

            If (inFileName = "") Then
                Exit Function
            End If

            GetExtension = Path.GetExtension(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetExtension = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetFileNameWithoutExtension(ByVal inFileName As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetFileNameWithoutExtension = "" 'init

            If (inFileName = "") Then
                Exit Function
            End If

            GetFileNameWithoutExtension = Path.GetFileNameWithoutExtension(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFileNameWithoutExtension = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetPathRoot(ByVal inFileName As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetPathRoot = "" 'init

            If (inFileName = "") Then
                Exit Function
            End If

            GetPathRoot = Path.GetPathRoot(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetPathRoot = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function HasExtension(ByVal inFileName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            HasExtension = False 'init

            If (inFileName = "") Then
                Exit Function
            End If

            Return Path.HasExtension(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            HasExtension = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsPathRooted(ByVal inFileName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsPathRooted = False 'init

            If (inFileName = "") Then
                Exit Function
            End If

            Return Path.IsPathRooted(inFileName)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsPathRooted = "" 'init
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function AppendTextFile(ByVal inFileName As String, ByVal inString As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            AppendTextFile = 0 'init

            RetCode = WriteTextFile(inFileName, inString, FileMode.Append, FileShare.Read)

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            AppendTextFile = 1 'error
            WriteEmergencyLog(ex.Message)

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function WriteTextFile(ByVal inFileName As String, ByVal inString As String, Optional ByVal inFileMode As System.IO.FileMode = FileMode.Append, Optional ByVal inFileShare As System.IO.FileShare = FileShare.Read) As Long
        Dim intCounter As Integer

        WriteTextFile = 0

        Try
            For intCounter = 1 To RetryCounter Step 1
                WriteTextFile = WriteToFile(inFileName, inString, inFileMode, inFileShare)
                If WriteTextFile <> 2 Then
                    Exit For
                Else
                    System.Threading.Thread.Sleep(RetryInterval)
                End If
            Next

            'if failed, the string is written to a temporary log file
            If WriteTextFile <> 0 Then
                WriteTextFile = WriteEmergencyLog(inString)
            End If

        Catch ex As Exception
            WriteTextFile = 1
            WriteEmergencyLog(ex.Message)

        Finally
            'Reset to default values
            RetryCounter = 5
            RetryInterval = 500
        End Try
    End Function

    Private Shared Function WriteToFile(ByVal inFileName As String, ByVal inString As String, Optional ByVal inFileMode As System.IO.FileMode = FileMode.Append, Optional ByVal inFileShare As System.IO.FileShare = FileShare.Read) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFile As FileInfo = Nothing
        Dim tmpFileStream As Stream = Nothing
        Dim tmpFileStreamWriter As StreamWriter = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WriteToFile = 0 'init

            'Check the file name
            If inFileName.Length = 0 Then
                WriteToFile = 2
                Exit Function
            End If

            'Check the string value
            If (inString.Length = 0) Then
                WriteToFile = 3
                Exit Function
            End If

            'Add end-of-line character to the string
            If inString.Substring(inString.Length - 2, 2) <> ControlChars.CrLf Then
                inString = inString & ControlChars.CrLf
            End If

            tmpFile = New FileInfo(inFileName)
            'If (IsFileExisting(inFileName) = False) Then
            '    'LA PRIMA VOLTA CREO IL FILE
            '    tmpFile.Create()
            'End If
            tmpFileStream = tmpFile.Open(inFileMode, FileAccess.Write, inFileShare)
            tmpFileStreamWriter = New StreamWriter(tmpFileStream)
            Call tmpFileStreamWriter.Write(inString)
            tmpFileStreamWriter.Close()
            tmpFileStream.Close()

            '**************************************
        Catch ex As System.IO.IOException
            WriteToFile = 2 'file locked by another process

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            WriteToFile = 1 'error
            WriteEmergencyLog(ex.Message)

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If Not IsNothing(tmpFileStreamWriter) Then
                tmpFileStreamWriter = Nothing
            End If
            If Not IsNothing(tmpFileStream) Then
                tmpFileStream = Nothing
            End If
            If Not IsNothing(tmpFile) Then
                tmpFile = Nothing
            End If
        End Try
    End Function

    Public Shared Function WriteEmergencyLog(ByVal inString As String) As Integer
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFile As FileInfo = Nothing
        Dim tmpFileStream As Stream = Nothing
        Dim tmpFileStreamWriter As StreamWriter = Nothing
        Dim strTempFileName As String

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WriteEmergencyLog = 0 'init

            'Check the string value
            If (inString.Length = 0) Then
                WriteEmergencyLog = 2
                Exit Function
            End If

            'Get a system-generated temporary file name
            strTempFileName = GetNewTempFileName(False, True)
            If strTempFileName.Length = 0 Then
                'Generate a temporary file name
                strTempFileName = clsUtility.GetApplicationPath()
                If strTempFileName.Substring(strTempFileName.Length - 1, 1) <> "\" Then
                    strTempFileName = strTempFileName & "\" & Now.GetHashCode().ToString() & ".log"
                Else
                    strTempFileName = strTempFileName & Now.GetHashCode().ToString() & ".log"
                End If
            End If

            If strTempFileName.Length = 0 Then
                WriteEmergencyLog = 3   'file generation error
                Exit Function
            End If

            'Add end-of-line character to the string
            If inString.Substring(inString.Length - 2, 2) <> ControlChars.CrLf Then
                inString = inString & ControlChars.CrLf
            End If

            tmpFile = New FileInfo(strTempFileName)
            tmpFileStream = tmpFile.Open(FileMode.Append, FileAccess.Write, FileShare.None)
            tmpFileStreamWriter = New StreamWriter(tmpFileStream)
            Call tmpFileStreamWriter.Write(inString)
            tmpFileStreamWriter.Close()
            tmpFileStream.Close()

            '**************************************

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            WriteEmergencyLog = 1 'error

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If Not IsNothing(tmpFileStreamWriter) Then
                tmpFileStreamWriter = Nothing
            End If
            If Not IsNothing(tmpFileStream) Then
                tmpFileStream = Nothing
            End If
            If Not IsNothing(tmpFile) Then
                tmpFile = Nothing
            End If
        End Try

    End Function
    Public Shared Function IsFileExisting(ByVal inFileName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFile As FileInfo = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsFileExisting = False 'init

            If (inFileName Is Nothing) Then
                Exit Function
            End If
            If (inFileName.Length <= 0) Then
                Exit Function
            End If

            tmpFile = New FileInfo(inFileName.ToString)
            If (tmpFile Is Nothing) Then
                Exit Function
            End If

            IsFileExisting = tmpFile.Exists()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsFileExisting = False  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (Not tmpFile Is Nothing) Then
                tmpFile = Nothing
            End If
        End Try
    End Function
    Public Shared Function CopyFile(ByVal inFileSourceName As String, ByVal inFileDestinationName As String, Optional ByVal OverWriteDestinationFile As Boolean = True, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkSourceFile As FileInfo = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            CopyFile = 10 'init

            If (clsUtility.IsStringValid(inFileSourceName, True) = False) Then
                CopyFile = 20
                Exit Function
            End If

            If (clsUtility.IsStringValid(inFileDestinationName, True) = False) Then
                CopyFile = 30
                Exit Function
            End If

            WorkSourceFile = New FileInfo(inFileSourceName)
            If (WorkSourceFile Is Nothing) Then
                CopyFile = 40
                Exit Function
            End If

            WorkSourceFile.CopyTo(inFileDestinationName, OverWriteDestinationFile)

            CopyFile = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CopyFile = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (Not (WorkSourceFile Is Nothing)) Then
                WorkSourceFile = Nothing
            End If
        End Try
    End Function
    Public Shared Function MoveFile(ByVal inFileSourceName As String, ByVal inFileDestinationName As String, Optional ByVal OverWriteDestinationFile As Boolean = True, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE


        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            MoveFile = 10 'init

            If (clsUtility.IsStringValid(inFileSourceName, True) = False) Then
                MoveFile = 20
                Exit Function
            End If


            If (clsUtility.IsStringValid(inFileDestinationName, True) = False) Then
                MoveFile = 30
                Exit Function
            End If

            If (Not (System.IO.File.Exists(inFileSourceName))) Then
                MoveFile = 40
                Exit Function
            End If
            If (System.IO.File.Exists(inFileDestinationName)) Then
                'esiste un file di destinazione omonimo, faccio copia in overwrite e poi elimino file origine
                System.IO.File.Copy(inFileSourceName, inFileDestinationName, True)
                System.IO.File.Delete(inFileSourceName)
            Else
                'caso normale , muovo il file
                System.IO.File.Move(inFileSourceName, inFileDestinationName)
            End If

            MoveFile = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            MoveFile = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function DeleteFile(ByVal inFileName As String, Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFile As FileInfo = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            DeleteFile = 10 'init

            If (clsUtility.IsStringValid(inFileName, True) = False) Then
                DeleteFile = 20
                Exit Function
            End If


            WorkFile = New FileInfo(inFileName)
            If (WorkFile Is Nothing) Then
                DeleteFile = 30
                Exit Function
            End If

            WorkFile.Delete()

            DeleteFile = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            DeleteFile = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (Not (WorkFile Is Nothing)) Then
                WorkFile = Nothing
            End If
        End Try
    End Function
    Public Shared Function RenameFile(ByVal inFileName As String, ByVal inNewFileName As String, ByRef outNewFileName As String, Optional ByVal inNewFileExtension As String = "", Optional ByVal inShowMessageBox As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFile As FileInfo = Nothing
        Dim WorkNewFileName As String = ""
        Dim RenameFileOk As Boolean = False
        Dim TryCounter As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            RenameFile = 10 'init

            If (clsUtility.IsStringValid(inFileName, True) = False) Then
                RenameFile = 20
                Exit Function
            End If


            WorkFile = New FileInfo(inFileName)
            If (WorkFile Is Nothing) Then
                RenameFile = 30
                Exit Function
            End If

            If (clsUtility.IsStringValid(inNewFileName, True)) Then
                WorkFile.MoveTo(inNewFileName)
                outNewFileName = inNewFileName 'ritorno nome nuovo file
            Else
                If (clsUtility.IsStringValid(inNewFileExtension, True)) Then
                    WorkNewFileName = WorkFile.DirectoryName & "\" & WorkFile.Name & inNewFileExtension

                    Do Until RenameFileOk
                        If (TryCounter > 20) Then
                            Exit Do
                        End If
                        Try
                            WorkFile.MoveTo(WorkNewFileName)
                            RenameFileOk = True
                        Catch
                            RenameFileOk = False
                        Finally

                        End Try
                        If RenameFileOk Then
                            Exit Do
                        Else
                            'System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(500)
                            TryCounter += 1
                        End If
                    Loop
                    If RenameFileOk Then
                        outNewFileName = WorkNewFileName 'ritorno nome nuovo file
                    End If
                End If
            End If

            RenameFile = 0

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            RenameFile = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            If (Not (WorkFile Is Nothing)) Then
                WorkFile = Nothing
            End If
        End Try
    End Function
    Public Shared Function OpenFileExclusiveMode(ByVal inFileName As String, Optional ByVal inShowMessageBox As Boolean = False) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFile As FileInfo = Nothing
        Dim WorkFileStream As FileStream = Nothing
        Dim OpenFileOk As Boolean = False
        Dim TryCounter As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            OpenFileExclusiveMode = False 'init

            If (clsUtility.IsStringValid(inFileName, True) = False) Then
                OpenFileExclusiveMode = False
                Exit Function
            End If


            WorkFile = New FileInfo(inFileName)
            If (WorkFile Is Nothing) Then
                OpenFileExclusiveMode = False
                Exit Function
            End If


            Do Until OpenFileOk
                If (TryCounter > 20) Then
                    Exit Do
                End If
                Try
                    WorkFileStream = WorkFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    OpenFileOk = True
                    WorkFileStream.Close()
                Catch
                    OpenFileOk = False
                Finally

                End Try
                If OpenFileOk Then
                    Exit Do
                Else
                    'System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(500)
                    TryCounter += 1
                End If
            Loop

            OpenFileExclusiveMode = OpenFileOk

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            OpenFileExclusiveMode = False  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FolderExists(ByVal inAbsoluteFolderPath As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFolder As DirectoryInfo
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FolderExists = False 'init

            If (inAbsoluteFolderPath Is Nothing) Then
                Exit Function
            End If
            If (inAbsoluteFolderPath.Length <= 0) Then
                Exit Function
            End If

            WorkFolder = New IO.DirectoryInfo(inAbsoluteFolderPath)

            FolderExists = WorkFolder.Exists

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FolderExists = False  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************

            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            WorkFolder = Nothing
        End Try
    End Function
    Public Shared Function GetFilesFromDirectory(ByVal inDirectoryPath As String, ByRef outFilesInfo As FileInfo(), ByRef outFileCount As Long, Optional ByVal inFilterFilePattern As String = "") As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim WorkFolder As DirectoryInfo = Nothing
        Dim WorkFilesInfo As FileInfo()

        GetFilesFromDirectory = 1

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            outFileCount = 0
            outFilesInfo = Nothing

            WorkFolder = New IO.DirectoryInfo(inDirectoryPath)
            If (WorkFolder.Exists = False) Then
                RetCode = 0 'NON GENERO ERRORE
                GetFilesFromDirectory = RetCode
                Exit Function
            End If

            WorkFolder.Refresh()

            If (inFilterFilePattern <> "") Then
                'recupero solo i file che hanno una certo pattern
                WorkFilesInfo = WorkFolder.GetFiles(inFilterFilePattern)
            Else
                'recupero tutti i file
                WorkFilesInfo = WorkFolder.GetFiles()
            End If
            If (WorkFilesInfo Is Nothing) Then
                RetCode = 0 'NON GENERO ERRORE
                GetFilesFromDirectory = RetCode
                Exit Function
            End If
            If (WorkFilesInfo.Length <= 0) Then
                RetCode = 0 'NON GENERO ERRORE
                GetFilesFromDirectory = RetCode
                Exit Function
            End If

            outFilesInfo = WorkFilesInfo
            outFileCount = outFilesInfo.Length

            GetFilesFromDirectory = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFilesFromDirectory = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            WorkFolder = Nothing
        End Try
    End Function
    Public Shared Function GetFirstFileFromDirectory(ByVal inDirectoryPath As String, Optional ByVal inIndexFile As Long = 0, Optional ByRef outFileName As String = "", Optional ByRef outFileCount As Long = 0, Optional ByVal inFilterFileExtension As String = "") As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkFolder As DirectoryInfo = Nothing
        Dim WorkFilesInfo As FileInfo()
        Dim WorkFileInfo As FileInfo
        Dim WorkFileCounter As Long

        GetFirstFileFromDirectory = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************
            outFileCount = 0

            WorkFolder = New IO.DirectoryInfo(inDirectoryPath)
            If (WorkFolder.Exists = False) Then
                Exit Function
            End If

            WorkFolder.Refresh()

            If (inFilterFileExtension <> "") Then
                'recupero solo i file che hanno una certo pattern
                WorkFilesInfo = WorkFolder.GetFiles(inFilterFileExtension)
            Else
                'recupero tutti i file
                WorkFilesInfo = WorkFolder.GetFiles()
            End If
            If (Not WorkFilesInfo Is Nothing) Then
                If WorkFilesInfo.Length = 0 Then
                    Exit Function
                End If

                outFileCount = WorkFilesInfo.Length

                For Each WorkFileInfo In WorkFilesInfo
                    If ((WorkFileInfo.Length > 0) And (WorkFileInfo.Exists)) Then
                        WorkFileCounter += 1
                        If ((inIndexFile = 0) Or (inIndexFile = WorkFileCounter)) Then
                            GetFirstFileFromDirectory = WorkFileInfo.FullName
                            outFileName = WorkFileInfo.Name
                            Exit For
                        End If
                    End If
                Next
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFirstFileFromDirectory = ""  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            WorkFolder = Nothing
        End Try
    End Function
    Public Shared Function GetOldFilesFromDirectory(ByVal inDirectoryPath As String, ByVal inDateUpperLimit As Date, ByRef outFilesInfo As FileInfo(), ByRef outFileCount As Long, Optional ByVal inFilterFilePattern As String = "") As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim WorkFilesInfo As FileInfo()
        Dim workFileInfo As FileInfo
        Dim FileDateEdit As Date = Date.MinValue
        Dim workFileCount As Long = 0

        GetOldFilesFromDirectory = 1

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            outFileCount = 0

            WorkFilesInfo = Nothing

            If (clsUtility.IsStringValid(inDirectoryPath, True) = False) Then
                RetCode = 10
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If

            If (IsDate(inDateUpperLimit) = False) Then
                RetCode = 20
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If

            If (inDateUpperLimit <= Date.MinValue) Then
                RetCode = 30
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If

            If (inDateUpperLimit >= Date.MaxValue) Then
                RetCode = 40
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If

            RetCode = GetFilesFromDirectory(inDirectoryPath, WorkFilesInfo, workFileCount, inFilterFilePattern)
            If (RetCode <> 0) Then
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If
            If (WorkFilesInfo Is Nothing) Then
                RetCode = 0 'NON GENERO ERRORE
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If
            If (WorkFilesInfo.Length <= 0) Then
                RetCode = 0 'NON GENERO ERRORE
                GetOldFilesFromDirectory = RetCode
                Exit Function
            End If

            For Each workFileInfo In WorkFilesInfo
                FileDateEdit = IO.File.GetLastWriteTime(workFileInfo.FullName)
                If (FileDateEdit > Date.MinValue) And (FileDateEdit < Date.MaxValue) And (FileDateEdit < inDateUpperLimit) Then
                    If (outFilesInfo Is Nothing) Then
                        ReDim outFilesInfo(0)
                    Else
                        ReDim Preserve outFilesInfo(outFilesInfo.Length)
                    End If
                    outFilesInfo.SetValue(workFileInfo, outFilesInfo.Length - 1)
                End If
            Next

            If (Not outFilesInfo Is Nothing) Then
                outFileCount = outFilesInfo.Length
            End If


            GetOldFilesFromDirectory = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetOldFilesFromDirectory = 1000  'error case
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
End Class
