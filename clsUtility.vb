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
Imports Terranova.API
Imports clsMainApplication
Imports System.Reflection


Public Class clsUtility

    Private Const Name As String = "clsUtility"
    '*****************************************


    Private Const RESOURCE_CONNECTED As Integer = &H1
    Private Const RESOURCE_GLOBALNET As Integer = &H2
    Private Const RESOURCE_REMEMBERED As Integer = &H3

    Private Const RESURCETYPE_ANY As Integer = &H0
    Private Const RESOURCETYPE_DISK As Integer = &H1
    Private Const RESOURCETYPE_PRINT As Integer = &H2

    Private Const RESOURCEDISPLAYTYPE_GENERIC As Integer = &H0
    Private Const RESOURCEDISPLAYTYPE_DOMAIN As Integer = &H1
    Private Const RESOURCEDISPLAYTYPE_SERVER As Integer = &H2
    Private Const RESOURCEDISPLAYTYPE_SHARE As Integer = &H3
    Private Const RESOURCEDISPLAYTYPE_FILE As Integer = &H4
    Private Const RESOURCEDISPLAYTYPE_GROUP As Integer = &H5

    Private Const RESOURCEUSAGE_CONNECTABLE As Integer = &H1
    Private Const RESOURCEUSAGE_CONTAINER As Integer = &H2

    Private Const CONNECT_INTERACTIVE As Integer = &H8
    Private Const CONNECT_PROMPT As Integer = &H10
    Private Const CONNECT_UPDATE_PROFILE As Integer = &H1

    Private Const NO_ERROR As Integer = &H0

    '*****************************************
    'MANAGEMENT OF OBJECT


    '************************
    'DATA TYPE
    Public Enum DateFormatTypeEnum
        DateFormatTypeNone = 0
        DateFormatTypeMMDDYYYY = 1
        DateFormatTypeDDMMYYYY = 2
    End Enum


    Public Enum DateTableMoveOpTypeEnum
        DateTableMoveOpTypeNone = 0
        DateTableMoveOpTypeFirst = 1
        DateTableMoveOpTypeNext = 2
        DateTableMoveOpTypePrev = 3
        DateTableMoveOpTypeLast = 4
    End Enum

    Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As Integer
        Public dwDisplayType As Integer
        Public dwUsage As Integer
        Public lpLocalName As IntPtr
        Public lpRemoteName As IntPtr
        Public lpComment As IntPtr
        Public lpProvider As IntPtr
    End Structure

    'System time structure used to pass to P/Invoke...
    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Public Structure SYSTEMTIME
        Public year As Short
        Public month As Short
        Public dayOfWeek As Short
        Public day As Short
        Public hour As Short
        Public minute As Short
        Public second As Short
        Public milliseconds As Short
    End Structure

    'P/Invoke dec for setting the system time...
    <DllImport("coredll.dll")> _
    Public Shared Function SetLocalTime(ByRef time As SYSTEMTIME) As Boolean
    End Function


    <DllImport("coredll.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
     Private Shared Function FindWindow( _
          ByVal lpClassName As String, _
          ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("coredll.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindowByClass( _
         ByVal lpClassName As String, _
         ByVal zero As IntPtr) As IntPtr
    End Function

    <DllImport("coredll.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function FindWindowByCaption( _
         ByVal zero As IntPtr, _
         ByVal lpWindowName As String) As IntPtr
    End Function

    'Declare Function WNetAddConnection2 Lib "coredll.dll" _

    <DllImport("coredll.dll", EntryPoint:="WNetAddConnection2A")> _
    Public Shared Function WNetAddConnection2 _
        (ByVal lpNetResource As NETRESOURCE, _
        ByVal lpPassword As System.Text.StringBuilder, _
        ByVal lpUserName As System.Text.StringBuilder, _
        ByVal dwFlags As Int32) As Int32
    End Function



    '<DllImport("coredll.dll", EntryPoint:="WNetAddConnection2", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Public Class Win32
        <DllImport("coredll.dll", EntryPoint:="WNetAddConnection3W", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function WNetAddConnection3W(ByVal hwndOwner As IntPtr, _
            ByRef lpNetResource As NETRESOURCE, ByVal lpPassword As String, ByVal lpUserName As String, ByVal dwFlags As UInt32) As Integer
        End Function
    End Class


    '<DllImport("coredll.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    'Private Shared Function WNetAddConnection3W(ByRef hwndOwner As Object, ByRef lpNetResource As NETRESOURCE, ByRef lpPassword As String, ByRef lpUserName As String, ByVal dwFlags As Integer) As Integer
    'End Function

    '************************
    'ATTRIBUTE OF SOURCE CODE

    Public Shared Function ClearArray(ByRef inArray As Array) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ClearArray = 1

            If (Not inArray Is Nothing) Then
                'ReDim inArray(0)
                inArray.Clear(inArray, 0, 0)
                inArray = Nothing
            End If

            ClearArray = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ClearArray = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetGUID() As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpGuid As Guid
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetGUID = ""

            tmpGuid = New Guid

            GetGUID = tmpGuid.ToString()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetGUID = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            tmpGuid = Nothing
        End Try
    End Function
    Public Shared Function ExecDataTableMove(ByRef inDataTable As DataTable, ByRef inCurrentIndex As Long, ByVal inDateTableMoveOpType As DateTableMoveOpTypeEnum) As DataRow
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecDataTableMove = Nothing

            If (inDataTable Is Nothing) Then Exit Function

            If (inDataTable.Rows() Is Nothing) Then Exit Function

            If (inDataTable.Rows.Count <= 0) Then Exit Function

            Select Case inDateTableMoveOpType
                Case DateTableMoveOpTypeEnum.DateTableMoveOpTypeFirst
                    inCurrentIndex = 0
                    ExecDataTableMove = inDataTable.Rows(inCurrentIndex)
                Case DateTableMoveOpTypeEnum.DateTableMoveOpTypeLast
                    If (inDataTable.Rows.Count > 1) Then
                        inCurrentIndex = inDataTable.Rows.Count - 1
                        ExecDataTableMove = inDataTable.Rows(inCurrentIndex)
                    Else
                        inCurrentIndex = 0
                        ExecDataTableMove = inDataTable.Rows(0)
                    End If
                Case DateTableMoveOpTypeEnum.DateTableMoveOpTypeNext
                    If (inCurrentIndex < inDataTable.Rows.Count - 1) Then
                        inCurrentIndex = inCurrentIndex + 1
                        ExecDataTableMove = inDataTable.Rows(inCurrentIndex)
                    Else
                        ExecDataTableMove = inDataTable.Rows(inDataTable.Rows.Count - 1) 'RIMANGO ALL'ULTIMO RECORD
                    End If
                Case DateTableMoveOpTypeEnum.DateTableMoveOpTypePrev
                    If (inCurrentIndex > 0) Then
                        inCurrentIndex = inCurrentIndex - 1
                        ExecDataTableMove = inDataTable.Rows(inCurrentIndex)
                    Else
                        ExecDataTableMove = inDataTable.Rows(0) 'RIMANGO AL PRIMO RECORD
                    End If
                Case Else
                    'CASO NON PREVISTO
                    ExecDataTableMove = Nothing
            End Select


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecDataTableMove = Nothing
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FromBoolToString(ByVal inBoolean As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpGuid As Guid
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromBoolToString = "0"

            If (IsNothing(inBoolean)) Then Exit Function

            If (inBoolean = True) Then
                FromBoolToString = "1"
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromBoolToString = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            tmpGuid = Nothing
        End Try
    End Function
    Public Shared Function FromBoolToLong(ByVal inBoolean As Boolean) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpGuid As Guid
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FromBoolToLong = 0

            If (IsNothing(inBoolean)) Then Exit Function

            If (inBoolean = True) Then
                FromBoolToLong = 1
            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FromBoolToLong = 0
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            tmpGuid = Nothing
        End Try
    End Function
    Public Shared Function FillComboFromStringArray(ByRef inComboControl As ComboBox, ByRef inStringArray() As String, ByVal inDefaultValue As String, Optional ByVal inAddEmptySelection As Boolean = False) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        Dim ArrayIndex As Long = 0
        Dim WorkString As String = ""
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FillComboFromStringArray = 0

            If (IsNothing(inComboControl)) Then Exit Function

            If (IsNothing(inStringArray)) Then Exit Function

            If (inStringArray.Length <= 0) Then Exit Function

            If (Not IsNothing(inComboControl.Items)) Then
                inComboControl.Items.Clear()
            End If

            'SE RICHIESTO AGGIUNGO NELLA LISTA L'OPZIONE NULLA
            If (inAddEmptySelection = True) Then
                inComboControl.Items.Add("")
            End If

            For ArrayIndex = 0 To inStringArray.Length - 1
                If (clsUtility.IsStringValid(inStringArray(ArrayIndex), True) = True) Then
                    WorkString = UCase(inStringArray(ArrayIndex))
                    inComboControl.Items.Add(WorkString)
                    If (WorkString = UCase(inDefaultValue)) Then
                        inComboControl.Text = inDefaultValue
                    End If
                End If
            Next


            FillComboFromStringArray = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FillComboFromStringArray = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetNotNullDbValue(ByRef inDataValue As Object, ByVal inGenericDataType As clsDataType.GenericDbDataTypeEnum) As Object
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpRetValue As Object

        tmpRetValue = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Select Case inGenericDataType
                Case clsDataType.GenericDbDataTypeEnum.GenericDbDataTypeDate
                    tmpRetValue = ""
                Case clsDataType.GenericDbDataTypeEnum.GenericDbDataTypeNumeric
                    tmpRetValue = 0
                Case clsDataType.GenericDbDataTypeEnum.GenericDbDataTypeString
                    tmpRetValue = ""
                Case Else
                    tmpRetValue = ""
            End Select

            GetNotNullDbValue = tmpRetValue

            If (IsNothing(inDataValue)) Then
                Exit Function
            End If

            If (IsDBNull(inDataValue)) Then
                Exit Function
            End If


            GetNotNullDbValue = inDataValue

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetNotNullDbValue = tmpRetValue
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsDataTableValid(ByRef inDataTableToCheck As DataTable, ByVal inCheckExistRows As Boolean) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsDataTableValid = False

            If (IsNothing(inDataTableToCheck)) Then
                Exit Function
            End If

            If (inCheckExistRows = True) Then
                If (IsNothing(inDataTableToCheck.Rows)) Then
                    Exit Function
                End If
                If (inDataTableToCheck.Rows.Count <= 0) Then
                    Exit Function
                End If
            End If

            IsDataTableValid = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsDataTableValid = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsStringValid(ByRef inStringToCheck As String, ByVal inCheckPositiveLen As Boolean) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsStringValid = False

            If (IsNothing(inStringToCheck)) Then
                Exit Function
            End If

            If (inCheckPositiveLen = True) Then
                If (inStringToCheck.Length <= 0) Then
                    Exit Function
                End If
            End If

            IsStringValid = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsStringValid = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsStringValidWithoutWildChars(ByRef inStringToCheck As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim IndexCharFound As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsStringValidWithoutWildChars = False

            If (IsNothing(inStringToCheck)) Then
                Exit Function
            End If

            If (inStringToCheck.Length <= 0) Then
                Exit Function
            End If

            IndexCharFound = InStr(inStringToCheck, "*")
            If (IndexCharFound > 0) Then
                Exit Function
            End If

            IsStringValidWithoutWildChars = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsStringValidWithoutWildChars = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function InitDataTable(ByRef inDataTable As DataTable) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            InitDataTable = 1 'init at error

            If (inDataTable Is Nothing) Then
                inDataTable = New DataTable
            End If

            inDataTable.Rows.Clear()

            InitDataTable = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            InitDataTable = 1000
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsStringElementInArray(ByRef inArray() As Object, ByVal inElementToFind As String, ByRef outArrayIndex As Long) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkArrayIndex As Long = 0
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsStringElementInArray = False
            outArrayIndex = -1

            If (IsNothing(inArray)) Then
                Exit Function
            End If

            If (clsUtility.IsStringValid(inElementToFind, True) = False) Then
                Exit Function
            End If

            If (UBound(inArray, 1) <= 0) Then
                Exit Function
            End If

            inElementToFind = UCase(inElementToFind)

            For WorkArrayIndex = 0 To inArray.Length - 1
                If (UCase(inArray(WorkArrayIndex).ToString) = inElementToFind) Then
                    outArrayIndex = WorkArrayIndex
                    IsStringElementInArray = True
                    Exit Function
                End If
            Next


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsStringElementInArray = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function IsArrayValid(ByRef inArray() As Object, ByVal inCheckPositiveLen As Boolean) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsArrayValid = False

            If (IsNothing(inArray)) Then
                Exit Function
            End If

            If (inCheckPositiveLen = True) Then
                If (UBound(inArray, 1) <= 0) Then
                    Exit Function
                End If
            End If

            IsArrayValid = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsArrayValid = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsArrayValid(ByRef inArray(,) As Object, ByVal inCheckPositiveLen As Boolean) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsArrayValid = False

            If (IsNothing(inArray)) Then
                Exit Function
            End If

            If (inCheckPositiveLen = True) Then
                If (UBound(inArray, 1) <= 0) Then
                    Exit Function
                End If
                If (UBound(inArray, 2) <= 0) Then
                    Exit Function
                End If
            End If

            IsArrayValid = True

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsArrayValid = False
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetDateNowString(ByVal inGetOnlyDate As Boolean, ByVal inDateFormatType As DateFormatTypeEnum, Optional ByVal inCustomFormat As String = "") As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim tmpString As String = ""
        Dim tmpMonth As String
        Dim tmpDay As String
        Dim tmpYear As String
        Dim tmpHour As String
        Dim tmpMinute As String
        Dim tmpSecond As String

        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetDateNowString = "" 'init

            tmpMonth = Format(Now.Month, "00")
            tmpDay = Format(Now.Day, "00")
            tmpYear = Format(Now.Year, "0000")

            tmpHour = Format(Now.Hour, "00")
            tmpMinute = Format(Now.Minute, "00")
            tmpSecond = Format(Now.Second, "00")

            If (inGetOnlyDate = True) Then
                Select Case (inDateFormatType)
                    Case DateFormatTypeEnum.DateFormatTypeDDMMYYYY
                        tmpString = tmpDay & "/" & tmpMonth & "/" & tmpYear
                    Case DateFormatTypeEnum.DateFormatTypeMMDDYYYY
                        tmpString = tmpMonth & "/" & tmpDay & "/" & tmpYear
                    Case DateFormatTypeEnum.DateFormatTypeNone
                        If (inCustomFormat.Length > 0) Then
                            tmpString = Format(Now, inCustomFormat)
                        End If
                End Select
            Else
                Select Case (inDateFormatType)
                    Case DateFormatTypeEnum.DateFormatTypeDDMMYYYY
                        tmpString = tmpDay & "/" & tmpMonth & "/" & tmpYear & " " & tmpHour & ":" & tmpMinute & ":" & tmpSecond
                    Case DateFormatTypeEnum.DateFormatTypeMMDDYYYY
                        tmpString = tmpMonth & "/" & tmpDay & "/" & tmpYear & " " & tmpHour & ":" & tmpMinute & ":" & tmpSecond
                    Case DateFormatTypeEnum.DateFormatTypeNone
                        If (inCustomFormat.Length > 0) Then
                            tmpString = Format(Now, inCustomFormat)
                        End If
                End Select
            End If

            GetDateNowString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetDateNowString = "" 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function FormatDateString(ByVal inDate As String) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim tmpString As String = ""
        Dim tmpMonth As String
        Dim tmpDay As String
        Dim tmpYear As String


        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            FormatDateString = "" 'init

            tmpMonth = inDate.Substring(4, 2)
            tmpDay = inDate.Substring(6, 2)
            tmpYear = inDate.Substring(0, 4)

            tmpString = tmpMonth & tmpDay & tmpYear


            FormatDateString = tmpString

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            FormatDateString = "" 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetApplicationPath() As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetApplicationPath = ""

            Dim path As String

#If APPLICAZIONE_WIN32 = "SI" Then
            path = Application.StartupPath()
#Else
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
#End If

            GetApplicationPath = path

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetApplicationPath = "" 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function IsProcesOnRunning(ByVal inProcesName As String, ByRef outProcessOnRunning As Boolean, ByRef outNumRunningProces As Long) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            IsProcesOnRunning = 1
            outProcessOnRunning = False

            Try
                'ProcessOnRunning = ProcessCE.IsRunning(@"\Windows\iexplore.exe")

                Dim nWnd As IntPtr
                Dim ceroIntPtr As New IntPtr(0)
                Dim Wnd_name As String

                Wnd_name = inProcesName
                nWnd = FindWindow(Nothing, Wnd_name)
                'show the info
                If (nWnd.Equals(ceroIntPtr)) Then
                    outProcessOnRunning = False
                Else
                    outProcessOnRunning = True
                End If
                ' Process is running
            Catch

            End Try


            IsProcesOnRunning = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            IsProcesOnRunning = 1000 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetAllRunningProcess(ByRef outAllRunningProcess() As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0

        Dim ProcesList As Process
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetAllRunningProcess = 1

            Dim handle As IntPtr = 0

            ProcesList = Process.GetCurrentProcess()


            GetAllRunningProcess = RetCode

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetAllRunningProcess = 1000 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function NetworkShareConnect(ByRef inForm As Form, ByVal inNetworkShare As String) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim result As Int32
            Dim WorkNetResource As New NETRESOURCE
            Dim remoteName As String = inNetworkShare
            Dim NetPass As String = "Mogwai2015"
            Dim NetUser As String = "lbellei"

            Dim myResource As NETRESOURCE
            myResource.dwScope = RESOURCE_GLOBALNET Or RESOURCE_REMEMBERED
            myResource.dwType = RESOURCETYPE_DISK
            myResource.dwDisplayType = RESOURCEDISPLAYTYPE_SHARE
            myResource.dwUsage = RESOURCEUSAGE_CONNECTABLE
            myResource.lpRemoteName = Marshal.StringToBSTR("\\pc-lbellei\palmari")
            myResource.lpLocalName = IntPtr.Zero 'Marshal.StringToBSTR("")
            myResource.lpComment = IntPtr.Zero
            myResource.lpProvider = IntPtr.Zero

            Dim DllErr As Integer

            Try

                ' Connect to the remote machine.
                result = Win32.WNetAddConnection3W(IntPtr.Zero, myResource, NetPass, NetUser, 0)
                'result = Win32.WNetAddConnection3W(IntPtr.Zero, myResource, NetPass, NetUser, CONNECT_PROMPT)
                'result = Win32.WNetAddConnection3W(IntPtr.Zero, myResource, NetPass, NetUser, CONNECT_UPDATE_PROFILE)

                If (result <> 0) Then
                    MsgBox(clsAppTranslation.GetSingleParameterValue(961, "", "Errore di Rete") & " : " & result.ToString, MsgBoxStyle.Exclamation, clsAppTranslation.GetSingleParameterValue(961, "", "Errore di Rete"))
                    Exit Function
                End If

                'System.IO.File.Copy("\\pc-lbellei\palmari\esempio.txt", "programmi\esempio.txt")


            Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
                DllErr = Err.LastDllError()
                Dim errorM = New System.ComponentModel.Win32Exception(result).Message
                'MsgBox("Could not connect to " & myResource.lpRemoteName & ". The server said this: " & vbNewLine & vbNewLine & "(Error " & result & ") " & errorM)
            End Try

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            NetworkShareConnect = 1000 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function GetFileExeVersionInfo(ByVal inFileName As String) As Version
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkVersion As Version
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetFileExeVersionInfo = Nothing

            If (clsFile.IsFileExisting(inFileName) = False) Then
                Exit Function
            End If

            WorkVersion = System.Reflection.Assembly.LoadFrom(inFileName).GetName.Version

            GetFileExeVersionInfo = WorkVersion

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFileExeVersionInfo = Nothing 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetAssemblyApplicationVersion(ByVal inXmlManifestPath As String, Optional ByVal outVersionString As String = "") As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkVersion As String
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetAssemblyApplicationVersion = Nothing

            'WorkVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName.Version


            Dim xmlDoc As New XmlDocument()
            If (clsUtility.IsStringValid(inXmlManifestPath, True) = True) Then
                xmlDoc.Load(inXmlManifestPath)
            Else
                xmlDoc.Load(".\WM_Win_PanariaUSA.exe.manifest")
            End If
            Dim ns As New XmlNamespaceManager(xmlDoc.NameTable)
            ns.AddNamespace("asmv1", "urn:schemas-microsoft-com:asm.v1")
            Dim xPath As String
            xPath = "/asmv1:assembly/asmv1:assemblyIdentity/@version"
            Dim node As XmlNode
            node = xmlDoc.SelectSingleNode(xPath, ns)
            Dim version As String
            WorkVersion = node.Value


            GetAssemblyApplicationVersion = WorkVersion

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetAssemblyApplicationVersion = Nothing 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetAssemblyApplicationVersion(Optional ByVal outVersionString As String = "") As Version
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkVersion As Version
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetAssemblyApplicationVersion = Nothing

            WorkVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName.Version

#If APPLICAZIONE_WIN32 = "SI" Then
            Dim myVersion As Version

            If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
                myVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                outVersionString = myVersion.ToString
            End If
#Else
            If (WorkVersion Is Nothing) Then
                outVersionString = WorkVersion.ToString
            End If
#End If

            GetAssemblyApplicationVersion = WorkVersion

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetAssemblyApplicationVersion = Nothing 'error conditiont
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function GetBaseDirectory() As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetBaseDirectory = "" 'init

            GetBaseDirectory = GetApplicationPath()

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetBaseDirectory = "" 'init
            '**************************************
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetApplicationName(ByVal inGetOnlyExeName As Boolean, ByVal inRemoveExeSuffix As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim ApplicationName As String
        Dim WorkModules As System.Reflection.Module()
        Dim IndexStartExeString As Long
        ApplicationName = "" 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            WorkModules = System.Reflection.Assembly.GetExecutingAssembly.GetModules()
            If (WorkModules.Length > 0) Then
                If (inGetOnlyExeName = True) Then
                    ApplicationName = UCase(WorkModules(0).Name)
                    If (inRemoveExeSuffix = True) Then
                        IndexStartExeString = InStr(ApplicationName, ".EXE")
                        If (IndexStartExeString > 0) Then
                            ApplicationName = LSet(ApplicationName, IndexStartExeString - 1)
                        End If
                    End If
                Else
                    'in questo caso ritorno il nome completo dell'applicazione (con path assoluto)
                    ApplicationName = UCase(WorkModules(0).FullyQualifiedName)
                End If

            End If

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ApplicationName = "" 'return nothing in case of error
            '**************************************
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            GetApplicationName = ApplicationName
        End Try

    End Function
    Public Shared Function GetWorkStationApplicationLogFileName(ByVal inShowMessageBox As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFileName As String = "" 'init
        Dim StringFileLen As Long = 0
        GetWorkStationApplicationLogFileName = "" 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            tmpFileName = GetBaseDirectory()
            If tmpFileName Is Nothing Then
                Exit Function
            End If
            StringFileLen = Len(tmpFileName)
            If (StringFileLen <= 0) Then
                Exit Function
            End If
            If (tmpFileName.Chars(StringFileLen - 1) <> "\") Then
                tmpFileName += "\"
            End If
            tmpFileName += "Log\" & GetApplicationName(True, True) & "_" & GetDateNowString(True, DateFormatTypeEnum.DateFormatTypeNone, "dd_MM_yyyy") & ".txt"

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            tmpFileName = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            GetWorkStationApplicationLogFileName = tmpFileName
        End Try
    End Function
    Public Shared Function GetWorkStationConfigFileName(ByVal inShowMessageBox As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFileName As String

        GetWorkStationConfigFileName = "" 'init
        tmpFileName = "" 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            tmpFileName = GetBaseDirectory()
            If (tmpFileName.Length <= 0) Then
                Exit Function
            End If
            'esempio : WM_Mobile.exe.config
            tmpFileName += "\" + GetApplicationName(True, False) & ".config"

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            tmpFileName = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "GetWorkStationConfigFileName", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            GetWorkStationConfigFileName = tmpFileName
        End Try
    End Function

    Public Shared Function GetGenericLogFileName(ByVal inLogFileName As String, ByVal inShowMessageBox As Boolean) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpFileName As String

        GetGenericLogFileName = "" 'init

        tmpFileName = "" 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            tmpFileName = GetBaseDirectory()
            If (tmpFileName.Length <= 0) Then
                Exit Function
            End If

            tmpFileName += "Log\" & inLogFileName & "_" & GetDateNowString(True, DateFormatTypeEnum.DateFormatTypeNone, "dd_MM_yyyy") & ".txt"

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            tmpFileName = ""
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            GetGenericLogFileName = tmpFileName
        End Try
    End Function

    Public Shared Function GetFormsControls(ByRef inControl As Object, Optional ByRef inCollection As Collection = Nothing) As Collection
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetFormsControls = Nothing 'init at nothing

            If (IsNothing(inControl)) Then
                Exit Function
            End If

            '???check se esiste la collection controls

            If inCollection Is Nothing Then
                inCollection = New Collection
            End If

            For Each control As Control In CType(inControl, System.Windows.Forms.Control).Controls
                If Not control Is Nothing Then
                    Try
                        inCollection.Add(control)
                        If control.Controls.Count > 0 Then
                            GetFormsControls(control, inCollection)
                        End If
                    Catch ex As Exception
                        clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                    End Try
                End If
            Next

            GetFormsControls = inCollection

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFormsControls = Nothing 'erorr
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetFormsComboBoxControls(ByRef inWinForm As Object, Optional ByRef inCollection As Collection = Nothing) As Collection
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim tmpComboBoxCollection As Collection = Nothing

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetFormsComboBoxControls = Nothing 'init at nothing

            If (IsNothing(inWinForm)) Then
                Exit Function
            End If

            '???check se esiste la collection controls

            'get the collection with all the controls inside the form
            inCollection = GetFormsControls(inWinForm)

            If inCollection Is Nothing Then
                Exit Function
            End If

            tmpComboBoxCollection = New Collection

            For Each control As Control In inCollection
                If Not control Is Nothing Then
                    Try
                        If ((control.GetType Is GetType(ComboBox))) Then
                            tmpComboBoxCollection.Add(control)
                        End If
                    Catch ex As Exception
                        clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                    End Try
                End If
            Next

            GetFormsComboBoxControls = tmpComboBoxCollection

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetFormsComboBoxControls = Nothing 'erorr
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function IncreaseCounter(ByVal inCurrentValue As Long, Optional ByVal inMinValue As Long = Long.MinValue, Optional ByVal inMaxValue As Long = Long.MaxValue) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkValue As Long

        IncreaseCounter = inCurrentValue 'init

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            If (inCurrentValue < inMaxValue) Then
                WorkValue = inCurrentValue + 1
            Else
                WorkValue = inMinValue
            End If
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            WorkValue = inCurrentValue
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            IncreaseCounter = WorkValue
        End Try
    End Function



    Public Shared Function FileIsLocked(ByVal fileFullPathName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE

        Dim isLocked As Boolean = False
        Dim fileObj As System.IO.FileStream = Nothing

        FileIsLocked = False
        Try
            fileObj = New System.IO.FileStream(fileFullPathName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None)
        Catch
            isLocked = True
        Finally
            If fileObj IsNot Nothing Then
                fileObj.Close()
            End If
        End Try
        Return isLocked
    End Function

    Public Shared Function SetDataGridColumnStyle(ByRef inDataGridControl As DataGrid, ByVal inFormatString As String, ByVal inMappingNameString As String, ByVal inHeaderTextString As String, ByVal inColumnVisible As Boolean, ByVal inColumnWidth As Long, Optional ByVal inReadOnly As Boolean = True) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim DataGridTextColumn As DataGridTextBoxColumn
        Dim TableStyle As DataGridTableStyle
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetDataGridColumnStyle = 1 'init at error

            If (IsNothing(inDataGridControl)) Then
                RetCode = 10
                SetDataGridColumnStyle = RetCode
                Exit Function
            End If

            DataGridTextColumn = New DataGridTextBoxColumn()

            If (clsUtility.IsStringValid(inMappingNameString, True)) Then
                DataGridTextColumn.MappingName = inMappingNameString
            End If
            If (clsUtility.IsStringValid(inHeaderTextString, True)) Then
                DataGridTextColumn.HeaderText = inHeaderTextString
            End If

            If (clsUtility.IsStringValid(inFormatString, True)) Then
                DataGridTextColumn.Format = inFormatString
            End If

            'DataGridTextColumn. = inReadOnly

            'DataGridTextColumn.Visible = inColumnVisible
            If (inColumnVisible = True) Then
                'imposto larghezza della colonna
                DataGridTextColumn.Width = inColumnWidth
            Else
                DataGridTextColumn.Width = 0
            End If

            If (inDataGridControl.TableStyles.Count > 0) Then
                TableStyle = inDataGridControl.TableStyles(0)
            Else
                TableStyle = New DataGridTableStyle
            End If

            'Con questo codice disabilito in tutte le DataGrid il sorting (che introduce problemi in certi casi)
            TableStyle.AllowSorting = False

            'aggiungo la colonna definita
            TableStyle.GridColumnStyles.Add(DataGridTextColumn)


            'solo la prima volta aggiungo il table style
            If (inDataGridControl.TableStyles.Count = 0) Then
                inDataGridControl.TableStyles.Add(TableStyle)
            End If

            SetDataGridColumnStyle = RetCode 'if 0 all go well

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridColumnStyle = 1000 'error condition
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function SetDataGridViewColumnStyle(ByRef inDataGridControl As DataGridView, ByVal inFormatString As String, ByVal inMappingNameString As String, ByVal inHeaderTextString As String, ByVal inColumnVisible As Boolean, ByVal inColumnWidth As Long, Optional ByVal inReadOnly As Boolean = True) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim DataGridViewTextColumn As DataGridViewTextBoxColumn

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            SetDataGridViewColumnStyle = 1 'init at error

            If (IsNothing(inDataGridControl)) Then
                RetCode = 10
                SetDataGridViewColumnStyle = RetCode
                Exit Function
            End If

            DataGridViewTextColumn = New DataGridViewTextBoxColumn()

            If (clsUtility.IsStringValid(inMappingNameString, True)) Then
                DataGridViewTextColumn.DataPropertyName = inMappingNameString
            End If
            If (clsUtility.IsStringValid(inHeaderTextString, True)) Then
                DataGridViewTextColumn.HeaderText = inHeaderTextString
            End If

            If (inColumnVisible = True) Then
                'imposto larghezza della colonna
                DataGridViewTextColumn.Width = inColumnWidth
                inDataGridControl.Columns.Add(DataGridViewTextColumn)
            End If

            'Con questo codice disabilito in tutte le DataGrid il sorting (che introduce problemi in certi casi)
            DataGridViewTextColumn.SortMode = DataGridViewColumnSortMode.NotSortable

            SetDataGridViewColumnStyle = RetCode 'if 0 all go well

            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDataGridViewColumnStyle = 1000 'error condition
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function CheckIfDataRowItemExist(ByRef inDataRow As DataRow, ByVal inFieldName As String) As Boolean
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim WorkString As String = ""
        CheckIfDataRowItemExist = False

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            If (Not (inDataRow Is Nothing)) Then
                WorkString = inDataRow.Item(inFieldName).ToString
                CheckIfDataRowItemExist = True
            End If

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            CheckIfDataRowItemExist = False
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function GetDataRowItem(ByRef inDataRow As DataRow, ByVal inFieldName As String, Optional ByVal inDefaultValueIfEmptyString As String = "", Optional ByVal inGetSqlCompatibileString As Boolean = False) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WorkString As String = ""
        '**************************************

        GetDataRowItem = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            WorkString = ""

            If (Not (inDataRow Is Nothing)) Then
                WorkString = inDataRow.Item(inFieldName).ToString
            End If

            If ((WorkString = "") And (inDefaultValueIfEmptyString <> "")) Then
                If (inDefaultValueIfEmptyString = "DateTime.MinValue") Then
                    WorkString = DateTime.MinValue
                Else
                    WorkString = inDefaultValueIfEmptyString
                End If
            End If

            If (inGetSqlCompatibileString = True) Then
                WorkString = WorkString.Replace(",", ".")
            End If
            GetDataRowItem = WorkString

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetDataRowItem = "" 'error condition
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "GetDataRowItem", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function
    Public Shared Function SendMail(ByVal inFromMailAddressAccount As String, ByVal inFromMailAddressDisplayName As String, ByVal inToMailAddressArray As String(), ByVal inSubjectString As String, ByVal inBodyString As String, ByVal inSMTP_HostName As String, Optional ByVal inMailUserIdCredential As String = "", Optional ByVal inMailUserPasswordCredential As String = "") As Long
        ''**************************************
        ''HERE PUT DECLARATION OF LOCAL VARIABLE
        'Dim Mail_Message As New System.Net.Mail.MailMessage
        'Dim ToMailAddress As String
        'Dim IndexArray As Long = 0
        ''**************************************
        'Try 'HERE PUT NORMAL EXECUTION CODE
        '    '**************************************

        '    SendMail = 10

        '    With Mail_Message
        '        .From = New System.Net.Mail.MailAddress(Trim(inFromMailAddressAccount), Trim(inFromMailAddressDisplayName))

        '        For IndexArray = 0 To (inToMailAddressArray.Length - 1)
        '            ToMailAddress = inToMailAddressArray(IndexArray)
        '            If (clsUtility.IsStringValid(ToMailAddress, True)) Then
        '                .To.Add(Trim(ToMailAddress))
        '            End If
        '        Next
        '        .SubjectEncoding = System.Text.Encoding.Default
        '        .Subject = inSubjectString
        '        .BodyEncoding = System.Text.Encoding.Default
        '        .Body = inBodyString
        '        .Priority = Net.Mail.MailPriority.High
        '        .IsBodyHtml = False
        '    End With
        '    Dim Mail_SmtpClient As New System.Net.Mail.SmtpClient
        '    Mail_SmtpClient.Host = inSMTP_HostName
        '    If (Trim(inMailUserIdCredential) <> "") Then
        '        Mail_SmtpClient.Credentials = New Net.NetworkCredential(inMailUserIdCredential, inMailUserPasswordCredential)
        '    End If
        '    Mail_SmtpClient.Send(Mail_Message)

        '    SendMail = 0 'SE ARRIVO QUA TUTTO E' ANDATO OK

        '    '**************************************
        'Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
        '    SendMail = 10000
        '    'LOG ERROR CONDITION
        '    clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
        '    '**************************************
        'Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        'End Try
    End Function
    Public Shared Function PrevInstance() As Boolean

        Dim objMutex As New Mutex(True)
        PrevInstance = False
        If (objMutex.WaitOne(0, False) = False) Then
            PrevInstance = True
        End If
    End Function
    Public Shared Function SetDeviceTime(ByVal p_NewDate As Date) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long = 0
        '**************************************

        SetDeviceTime = 1

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            Dim st As SYSTEMTIME
            st.year = p_NewDate.Year
            st.month = p_NewDate.Month
            st.dayOfWeek = p_NewDate.DayOfWeek
            st.day = p_NewDate.Day
            st.hour = p_NewDate.Hour
            st.minute = p_NewDate.Minute
            st.second = p_NewDate.Second
            st.milliseconds = p_NewDate.Millisecond

            'Set the new time...

#If Not APPLICAZIONE_WIN32 = "SI" Then
            SetLocalTime(st)
            SetDeviceTime = RetCode
#End If

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            SetDeviceTime = 1000 'error condition
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "GetDataRowItem", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function KillPrevProcess() As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim ApplicationLogPath As String
        Dim list As Terranova.API.ProcessInfo() = Terranova.API.ProcessCE.GetProcesses()
        Dim currentProcess As Process = Process.GetCurrentProcess()
        Dim Pid As String = currentProcess.Id.ToString
        '**************************************

        Dim RetCode As Long = 0

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            'RECUPERO LA DIRECTORY DEL PROGRAMMA
            ApplicationLogPath = clsUtility.GetApplicationPath() & "\"

            For Each item As Terranova.API.ProcessInfo In list
                Debug.WriteLine("Process item: " + item.FullPath)
                If item.FullPath = (ApplicationLogPath & "WM_MobileGRESMALT.exe") Then

                    'Se non è se stesso, chiudo il processo
                    If Not item.Pid.ToString = Pid Then
                        item.Kill()
                    End If

                End If
            Next

            KillPrevProcess = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            KillPrevProcess = 1000 'error condition
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "KillPrevProcess", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function ExecuteObjectMethod(ByRef inObject As Object, ByVal inMethodName As String, ByRef outRetval As Object, ByRef inParams() As Object) As Long
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim RetCode As Long
        Dim objType As Type
        Dim tmpMethodInfo As MethodInfo
        Dim tmpParameterInfo() As ParameterInfo
        Dim tmpParamInfo As ParameterInfo
        Dim tmpMethodInfoParamLen As Long
        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            ExecuteObjectMethod = 1 'init at error

            If (Not (inObject Is Nothing)) Then
                objType = inObject.GetType()
                If (Not (objType Is Nothing)) Then
                    tmpMethodInfo = objType.GetMethod(inMethodName)
                    If (Not (tmpMethodInfo Is Nothing)) Then

                        'Check parameters
                        tmpMethodInfoParamLen = tmpMethodInfo.GetParameters.Length
                        If inParams Is Nothing And tmpMethodInfoParamLen > 0 Then
                            Return 10
                        End If
                        If Not inParams Is Nothing Then
                            If tmpMethodInfoParamLen < inParams.Length Then
                                Return 20
                            End If
                            Dim index As Integer = 0
                            Dim tmpPassedParamType As Type
                            Dim tmpParamInfoTypeName As String = ""
                            tmpParameterInfo = tmpMethodInfo.GetParameters
                            If (Not (IsNothing(tmpParameterInfo))) Then
                                If tmpParameterInfo.Length >= inParams.Length Then
                                    For Each tmpParamInfo In tmpParameterInfo
                                        'If (tmpParamInfo.IsOptional() = False) Then
                                        If (index > UBound(inParams, 1)) Then
                                            Return 30
                                        End If
                                        'Mandatory parameter
                                        If Not inParams(index) Is Nothing Then
                                            'Check the parameter data type (check the name)
                                            tmpParamInfoTypeName = GetParamInfoTypeName(tmpParamInfo)
                                            tmpPassedParamType = inParams(index).GetType()
                                            If (tmpParamInfoTypeName <> "Object") Then
                                                If (tmpParamInfoTypeName <> tmpPassedParamType.Name) Then
                                                    'Wrong parameter type
                                                    Return 50
                                                Else
                                                    'Parameter ok - do nothing
                                                End If
                                            End If
                                        End If
                                        'Else
                                        ''ok
                                        ''End of mandatory parameters
                                        'If (index >= inParams.Length) Then
                                        '    ReDim Preserve inParams(index)
                                        '    inParams(index) = Nothing
                                        'End If
                                        'End If
                                        If (index >= inParams.Length) Then
                                            Exit For
                                        End If
                                        index += 1
                                    Next
                                End If
                            End If
                        End If

                        'try catch per esecuzione metodo [Invoke]
                        Try
                            outRetval = tmpMethodInfo.Invoke(inObject, inParams)

                            '**************************************
                        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
                            ExecuteObjectMethod = 1000  'error case
                            'LOG ERROR CONDITION
                            'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, ex.TargetSite.Name, clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
                            '**************************************
                        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

                        End Try
                    End If
                End If
            End If

            ExecuteObjectMethod = RetCode

        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            ExecuteObjectMethod = 1000  'error case
            'LOG ERROR CONDITION
            'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, ex.TargetSite.Name, clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function


    Public Shared Function GetParamInfoTypeName(ByVal inParamInfo As ParameterInfo) As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        '**************************************
        Dim ParamInfoType As Type
        Dim tmpString As String
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************

            GetParamInfoTypeName = ""

            If (IsNothing(inParamInfo)) Then
                Exit Function
            End If

            ParamInfoType = inParamInfo.ParameterType
            If (IsNothing(ParamInfoType)) Then
                Exit Function
            End If

            GetParamInfoTypeName = ParamInfoType.Name

            If (ParamInfoType.IsByRef = True) Then
                tmpString = GetParamInfoTypeName
                If (clsUtility.IsStringValid(tmpString, True)) Then
                    'If (Right(tmpString, 1) = "&") Then
                    If (tmpString.Substring(1) = "&") Then
                        'GetParamInfoTypeName = Left(tmpString, tmpString.Length - 1)
                        GetParamInfoTypeName = tmpString.Substring(tmpString.Length - 1, 1)
                    End If
                End If
            End If


        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            GetParamInfoTypeName = ""  'error case
            'LOG ERROR CONDITION
            'clsProgramError.ManageLogErrorCondition(CodeClassObjectName, ex.TargetSite.Name, clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION

        End Try
    End Function

    Public Shared Function GetWorkStationName() As String
        '**************************************
        'HERE PUT DECLARATION OF LOCAL VARIABLE
        Dim WkStationName As String = ""

        '**************************************
        Try 'HERE PUT NORMAL EXECUTION CODE
            '**************************************


            WkStationName = UCase(System.Net.Dns.GetHostName)


            '**************************************
        Catch ex As Exception 'HERE PUT ERROR MANAGEMENT
            WkStationName = "" 'return nothing in case of error
            '**************************************
            'LOG ERROR CONDITION
            clsProgramError.ManageLogErrorCondition(Name, "", clsProgramError.ErrorInfoTypeEnum.ErrorInfoTypeError, "Catch Error!", ex)
            '**************************************
        Finally 'HERE PUT NORMAL AND NOT NORMAL END EXECUTION
            GetWorkStationName = WkStationName
        End Try

    End Function

End Class
