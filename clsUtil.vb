Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.DataGrid
Imports System.Xml
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Diagnostics
'Imports System.Net.Mail.MailMessage
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.Net
'Imports System.Runtime.InteropServices


' Copyright © 2009, Frank van de Ven, all rights reserved.       ]
' * email: vandevenator@gmail.com
' *
' * This is my first contribution to "The Code Project." I am not much of an article writer, but The Code Project (www.codeproject.com) has
' * been very useful to me over the past years, it is time to give something back.
' * 
' * This code is based on several code snippets and examples I found on the Internet.
' * I combined all this information to create a very useful Windows CE process enumeration and manipulation class.
' *
' * This code is for use with WINDOWS CE only.
' * 
' * The code was only tested on Windows Mobile 6.1 (Windows CE 5.2). Windows CE 4 should be no problem.
' *  
' * This source code is licensed under the Code Project Open License (CPOL).
' * Check out http://www.codeproject.com/info/cpol10.aspx for further details.
' * 
' * Some examples:
' * 
' *   ProcessInfo[] list = ProcessCE.GetProcesses();
' *          
' *   foreach (ProcessInfo item in list)
' *   {
' *       Debug.WriteLine("Process item: " + item.FullPath);
' *       if (item.FullPath == @"\Windows\iexplore.exe")
' *           item.Kill();
' *   }
' *
' *   bool result = ProcessCE.IsRunning(@"\Windows\iexplore.exe");
' *
' *   IntPtr pid = ProcessCE.FindProcessPID(@"\Windows\iexplore.exe");
' *   
' *   if (pid == IntPtr.Zero)
' *       throw new Exception("Process not found.");
' *
' *   result = ProcessCE.FindAndKill(@"\Windows\iexplore.exe");
' * 
' 

Namespace Terranova.API
    ''' <summary>
    ''' Contains information about a process.
    ''' This information is collected by ProcessCE.GetProcesses().
    ''' </summary>
    Public Class ProcessInfo
        <DllImport("coredll.dll", SetLastError:=True)> _
        Private Shared Function GetModuleFileName(ByVal hModule As IntPtr, ByVal lpFilename As StringBuilder, ByVal nSize As Integer) As Integer
        End Function

        Private Const INVALID_HANDLE_VALUE As Integer = -1

        Private _pid As IntPtr
        Private _threadCount As Integer
        Private _baseAddress As Integer
        Private _parentProcessID As Integer
        Private _fullPath As String

        Friend Sub New(ByVal pid As IntPtr, ByVal threadcount As Integer, ByVal baseaddress As Integer, ByVal parentid As Integer)
            _pid = pid
            _threadCount = threadcount
            _baseAddress = baseaddress
            _parentProcessID = parentid

            Dim sb As New StringBuilder(1024)
            GetModuleFileName(_pid, sb, sb.Capacity)
            _fullPath = sb.ToString()
        End Sub

        ''' <summary>
        ''' Returns the full path to the process .EXE file.
        ''' </summary>
        ''' <example>"\Program Files\Acme\main.exe"</example>
        Public Overrides Function ToString() As String
            Return _fullPath
        End Function

        Public ReadOnly Property BaseAddress() As Integer
            Get
                Return _baseAddress
            End Get
        End Property

        Public ReadOnly Property ThreadCount() As Integer
            Get
                Return _threadCount
            End Get
        End Property

        ''' <summary>
        ''' Returns the Process Id.
        ''' </summary>
        Public ReadOnly Property Pid() As IntPtr
            Get
                Return _pid
            End Get
        End Property

        ''' <summary>
        ''' Returns the full path to the process .EXE file.
        ''' </summary>
        ''' <example>"\Program Files\Acme\main.exe"</example>
        Public ReadOnly Property FullPath() As String
            Get
                Return _fullPath
            End Get
        End Property

        Public ReadOnly Property ParentProcessID() As Integer
            Get
                Return _parentProcessID
            End Get
        End Property

        ''' <summary>
        ''' Kills the process.
        ''' </summary>
        ''' <exception cref="Win32Exception">Thrown when killing the process fails.</exception>
        Public Sub Kill()
            ProcessCE.Kill(_pid)
        End Sub

    End Class

    ''' <summary>
    ''' Static class that provides Windows CE process information and manipulation.
    ''' The biggest difference with the Compact Framework's Process class is that this
    ''' class works with the full path to the .EXE file. And not the pathless .EXE file name.
    ''' </summary>
    Public NotInheritable Class ProcessCE
        Private Sub New()
        End Sub
        Private Const MAX_PATH As Integer = 260
        Private Const TH32CS_SNAPPROCESS As Integer = &H2
        Private Const TH32CS_SNAPNOHEAPS As Integer = &H40000000
        Private Const INVALID_HANDLE_VALUE As Integer = -1
        Private Const PROCESS_TERMINATE As Integer = 1

        ''' <summary>
        ''' Returns an array with information about running processes.
        ''' </summary>
        '''<exception cref="Win32Exception">Thrown when enumerating the processes fails.</exception>
        Public Shared Function GetProcesses() As ProcessInfo()
            Dim procList As New List(Of ProcessInfo)()

            Dim handle As IntPtr = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS Or TH32CS_SNAPNOHEAPS, 0)

            If DirectCast(CInt(handle), Int32) = INVALID_HANDLE_VALUE Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), "CreateToolhelp32Snapshot error.")
            End If

            Try
                Dim processentry As New PROCESSENTRY()
                processentry.dwSize = CUInt(Marshal.SizeOf(processentry))

                'Get the first process
                Dim retval As Integer = Process32First(handle, processentry)

                While retval = 1
                    procList.Add(New ProcessInfo(New IntPtr(CInt(processentry.th32ProcessID)), CInt(processentry.cntThreads), CInt(processentry.th32MemoryBase), CInt(processentry.th32ParentProcessID)))
                    retval = Process32Next(handle, processentry)
                End While
            Finally
                CloseToolhelp32Snapshot(handle)
            End Try

            Return procList.ToArray()
        End Function

        ''' <summary>
        ''' Checks if the specified .EXE is running.
        ''' </summary>
        ''' <param name="fullpath">The full path to an .EXE file.</param>
        ''' <returns>Returns true is the process is running.</returns>
        ''' <exception cref="Win32Exception">Thrown when taking a system snapshot fails.</exception>
        Public Shared Function IsRunning(ByVal fullpath As String) As Boolean
            Return (FindProcessPID(fullpath) <> IntPtr.Zero)
        End Function

        ''' <summary>
        ''' Finds and kills if the process for the specified .EXE file is running.
        ''' </summary>
        ''' <param name="fullpath">The full path to an .EXE file.</param>
        ''' <returns>True if the process was terminated. False if the process was not found.</returns>
        ''' <exception cref="Win32Exception">Thrown when opening or killing the process fails.</exception>
        Public Shared Function FindAndKill(ByVal fullpath As String) As Boolean
            Dim pid As IntPtr = FindProcessPID(fullpath)

            If pid = IntPtr.Zero Then
                Return False
            End If

            Kill(pid)

            Return True
        End Function

        ''' <summary>
        ''' Terminates the process with the specified Process Id.
        ''' </summary>
        ''' <param name="pid">The Process Id of the process to kill.</param>
        ''' <exception cref="Win32Exception">Thrown when opening or killing the process fails.</exception>
        Friend Shared Sub Kill(ByVal pid As IntPtr)

            Dim process_handle As IntPtr = OpenProcess(PROCESS_TERMINATE, False, CInt(pid))

            'If process_handle = DirectCast(INVALID_HANDLE_VALUE, IntPtr) Then
            If process_handle = New IntPtr(INVALID_HANDLE_VALUE) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), "OpenProcess failed.")
            End If

            Try
                Dim result As Boolean = TerminateProcess(process_handle, 0)

                If result = False Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error(), "TerminateProcess failed.")

                End If
            Finally
                CloseHandle(process_handle)
            End Try
        End Sub

        ''' <summary>
        ''' Finds the Process Id of the specified .EXE file.
        ''' </summary>
        ''' <param name="fullpath">The full path to an .EXE file.</param>
        ''' <returns>The Process Id to the process found. Return IntPtr.Zero if the process is not running.</returns>
        '''<exception cref="Win32Exception">Thrown when taking a system snapshot fails.</exception>
        Public Shared Function FindProcessPID(ByVal fullpath As String) As IntPtr
            fullpath = fullpath.ToLower()

            Dim snapshot_handle As IntPtr = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS Or TH32CS_SNAPNOHEAPS, 0)

            If DirectCast(CInt(snapshot_handle), Int32) = INVALID_HANDLE_VALUE Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), "CreateToolhelp32Snapshot failed.")
            End If

            Try
                Dim processentry As New PROCESSENTRY()
                processentry.dwSize = CUInt(Marshal.SizeOf(processentry))
                Dim fullexepath As New StringBuilder(1024)

                Dim retval As Integer = Process32First(snapshot_handle, processentry)

                While retval = 1
                    Dim pid As New IntPtr(CInt(processentry.th32ProcessID))

                    ' Writes the full path to the process into a StringBuilder object.
                    ' Note: If first parameter is IntPtr.Zero it returns the path to the current process.
                    GetModuleFileName(pid, fullexepath, fullexepath.Capacity)

                    If fullexepath.ToString().ToLower() = fullpath Then
                        Return pid
                    End If

                    retval = Process32Next(snapshot_handle, processentry)
                End While
            Finally
                CloseToolhelp32Snapshot(snapshot_handle)
            End Try

            Return IntPtr.Zero
        End Function

        <DllImport("toolhelp.dll", SetLastError:=True)> _
        Private Shared Function CreateToolhelp32Snapshot(ByVal flags As UInteger, ByVal processID As UInteger) As IntPtr
        End Function

        <DllImport("toolhelp.dll")> _
        Private Shared Function CloseToolhelp32Snapshot(ByVal snapshot As IntPtr) As Integer
        End Function

        <DllImport("toolhelp.dll")> _
        Private Shared Function Process32First(ByVal snapshot As IntPtr, ByRef processEntry As PROCESSENTRY) As Integer
        End Function

        <DllImport("toolhelp.dll")> _
        Private Shared Function Process32Next(ByVal snapshot As IntPtr, ByRef processEntry As PROCESSENTRY) As Integer
        End Function

        <DllImport("coredll.dll", SetLastError:=True)> _
        Private Shared Function GetModuleFileName(ByVal hModule As IntPtr, ByVal lpFilename As StringBuilder, ByVal nSize As Integer) As Integer
        End Function

        <DllImport("coredll.dll", SetLastError:=True)> _
        Private Shared Function TerminateProcess(ByVal hProcess As IntPtr, ByVal ExitCode As UInteger) As Boolean
        End Function

        <DllImport("coredll.dll", SetLastError:=True)> _
        Private Shared Function OpenProcess(ByVal flags As Integer, ByVal fInherit As Boolean, ByVal PID As Integer) As IntPtr
        End Function

        <DllImport("coredll.dll")> _
        Private Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
        End Function

        Private Structure PROCESSENTRY
            Public dwSize As UInteger
            Public cntUsage As UInteger
            Public th32ProcessID As UInteger
            Public th32DefaultHeapID As UInteger
            Public th32ModuleID As UInteger
            Public cntThreads As UInteger
            Public th32ParentProcessID As UInteger
            Public pcPriClassBase As Integer
            Public dwFlags As UInteger
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> _
            Public szExeFile As String
            Public th32MemoryBase As UInteger
            Public th32AccessKey As UInteger
        End Structure

    End Class
    ' end of class
End Namespace
' end of namespace 

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
