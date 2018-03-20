Imports System
Imports System.Runtime.InteropServices
Imports frmInfoGiacenze_1_CodiceMateriale


Public Class clsHookKeys
#Region "delegates"
    Public Delegate Function HookProc(ByVal code As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    Public Delegate Sub HookEventHandler(ByVal e As HookEventArgs, ByVal keyBoardInfo As KeyBoardInfo)
    Public HookEvent As HookEventHandler

    Public Event AnEvent()

#End Region
#Region "fields"
    Private hookDeleg As HookProc
    Private Shared hHook As Integer = 0
    Private SingleHook As Integer = 0
#End Region

    Public Shared keyInfo As New KeyBoardInfo()

    Public Shared frmActive As Form

    Public Sub New()
        AddHandler AnEvent, AddressOf EventHandler1
    End Sub

    Protected Overrides Sub Finalize()
        If hHook <> 0 Then
            Me.Stop()
        End If
    End Sub

#Region "public methods"
    '''
    ''' Starts the hook
    '''

    Public Sub Start(ByRef inSourceForm As Form)
        frmActive = inSourceForm

        If hHook <> 0 Then
            'Unhook the previouse one
            Me.Stop()
        End If
        hookDeleg = New HookProc(AddressOf HookProcedure)
        hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookDeleg, GetModuleHandle(Nothing), 0)
        If hHook = 0 Then
            Throw New SystemException("Failed acquiring of the hook.")
        End If
        AllKeys(True)
    End Sub
    '''
    ''' Stops the hook
    '''
    Public Sub [Stop]()
        UnhookWindowsHookEx(hHook)
        AllKeys(False)
    End Sub
#End Region
#Region "protected and private methods"


    Public Sub EventHandler1()

        ' TODO: Insert constructor code here
        Dim ParamsMethod(0) As Object
        Dim outRetval As Object

        ParamsMethod(0) = clsHookKeys.keyInfo.vkCode

        clsUtility.ExecuteObjectMethod(clsHookKeys.frmActive, "KeyPressed", outRetval, ParamsMethod)

    End Sub

    Public Function HookProcedure(ByVal code As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        Dim hookStruct As KBDLLHOOKSTRUCT = DirectCast(Marshal.PtrToStructure(lParam, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT)

        If SingleHook = 0 Then
            SingleHook += 1

            If code < 0 Then
                Return CallNextHookEx(hookDeleg, code, wParam, lParam)
            End If

            ' Let clients determine what to do
            Dim e As New HookEventArgs()
            e.Code = code
            e.wParam = wParam
            e.lParam = lParam
            keyInfo.vkCode = hookStruct.vkCode
            keyInfo.scanCode = hookStruct.scanCode
            'OnHookEvent(e)
            'Return CallNextHookEx(hookDeleg, code, wParam, lParam)

            If (keyInfo.vkCode >= 112) And (keyInfo.vkCode <= 116) Then
                Dim Tm As New TestTimer
                Tm.Main()
                Tm.StartTime = True
                Return CallNextHookEx(hookDeleg, code, wParam, lParam)
            End If
            Exit Function
        Else
            SingleHook = 0
        End If

    End Function

    Sub CauseTheEvent()
        ' Raise an event. 
        RaiseEvent AnEvent()

    End Sub

#End Region
#Region "P/Invoke declarations"

    <DllImport("coredll.dll")> _
   Private Shared Function AllKeys(ByVal bEnable As Boolean) As Integer
    End Function

    <DllImport("coredll.dll")> _
   Private Shared Function SetWindowsHookEx(ByVal type As Integer, ByVal hookProc As HookProc, ByVal hInstance As IntPtr, ByVal m As Integer) As Integer
    End Function
    <DllImport("coredll.dll")> _
   Private Shared Function GetModuleHandle(ByVal [mod] As String) As IntPtr
    End Function
    <DllImport("coredll.dll")> _
   Private Shared Function CallNextHookEx(ByVal hhk As HookProc, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    <DllImport("coredll.dll")> _
   Private Shared Function GetCurrentThreadId() As Integer
    End Function
    <DllImport("coredll.dll", SetLastError:=True)> _
   Private Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Integer
    End Function
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure
    Private Const WH_KEYBOARD_LL As Integer = 20
    Private Const WH_SYSMSGFILTER As Integer = 6
#End Region
End Class
#Region "event arguments"

Public Class HookEventArgs
    Inherits EventArgs

    Public Code As Integer ' Hook code
    Public wParam As IntPtr ' WPARAM argument
    Public lParam As IntPtr ' LPARAM argument
End Class
Public Class KeyBoardInfo
    Public vkCode As Integer
    Public scanCode As Integer
    Public flags As Integer
    Public time As Integer
End Class


Public Class TestTimer

    Private aTimer As Timer

    Public Shared StartTime As Boolean = False

    Public Sub Main()
        SetTimer()
        'aTimer.Dispose()
    End Sub

    Private Sub SetTimer()
        ' Create a timer with a two second interval.
        aTimer = New Timer()
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Tick, AddressOf OnTimedEvent
        aTimer.Interval = 100
        aTimer.Enabled = True
    End Sub

    Private Sub OnTimedEvent()
        If StartTime Then
            aTimer.Enabled = False
            StartTime = False
            aTimer.Dispose()
            hook.CauseTheEvent()
        End If
    End Sub

End Class


#End Region
