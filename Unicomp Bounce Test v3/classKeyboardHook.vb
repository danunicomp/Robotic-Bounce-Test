Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Drawing
Imports System.Threading

Public Class classKeyboardHook

#Region " CONSTANTS "
    ' Low-Level Keyboard Constants
    Private Const HC_ACTION As Integer = 0
    Private Const LLKHF_EXTENDED As Byte = &H1
    Private Const LLKHF_INJECTED As Byte = &H10
    Private Const LLKHF_ALTDOWN As Byte = &H20
    Private Const LLKHF_UP As Byte = &H80

    ' Virtual Keys
    Private Const VK_TAB As Byte = &H9
    Private Const VK_CONTROL As Byte = &H11
    Private Const VK_ESCAPE As Byte = &H1B
    Private Const VK_DELETE As Byte = &H2E
    Private Const VK_LEFTWINDOWS As Byte = &H5B
    Private Const VK_RIGHTWINDOWS As Byte = &H5C

    Private Const WH_KEYBOARD_LL As Byte = 13&
    Private KeyboardHandle As Integer
#End Region


    Public LastScanCode As Byte
    Public LastKey As structLastKey

    Friend Event KeyHit(ByVal KeyInfo As KBDLLHOOKSTRUCT)

    Friend Declare Function UnhookWindowsHookEx Lib "user32" _
      (ByVal hHook As Integer) As Integer

    Friend Declare Function SetWindowsHookEx Lib "user32" _
      Alias "SetWindowsHookExA" (ByVal idHook As Integer, _
      ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, _
      ByVal dwThreadId As Integer) As Integer

    Private Declare Function GetAsyncKeyState Lib "user32" _
      (ByVal vKey As Integer) As Integer

    Private Declare Function CallNextHookEx Lib "user32" _
      (ByVal hHook As Integer, _
      ByVal nCode As Integer, _
      ByVal wParam As Integer, _
      ByVal lParam As KBDLLHOOKSTRUCT) As Integer


    ' Implement this function to block as many
    ' key combinations as you'd like
    Private Function IsHooked( _
      ByRef Hookstruct As KBDLLHOOKSTRUCT) As Boolean
        If (Hookstruct.flags = HC_ACTION) OrElse (Hookstruct.flags = LLKHF_EXTENDED) OrElse ((Hookstruct.flags And LLKHF_ALTDOWN) = LLKHF_ALTDOWN) Then
            RaiseEvent KeyHit(Hookstruct)
        End If

        Return True
    End Function

    Private Sub HookedState(ByVal Text As String)
        Console.WriteLine(Text)
    End Sub

    Private Function KeyboardCallback(ByVal Code As Integer, _
      ByVal wParam As Integer, _
      ByRef lParam As KBDLLHOOKSTRUCT) As Integer

        If (Code = HC_ACTION) Then
            'console.WriteLine("Calling IsHooked")

            If (IsHooked(lParam)) Then
                Return 1
            End If

        End If

        Return CallNextHookEx(KeyboardHandle, _
          Code, wParam, lParam)

    End Function

    Public Delegate Function KeyboardHookDelegate( _
      ByVal Code As Integer, _
      ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) _
                   As Integer

    <MarshalAs(UnmanagedType.FunctionPtr)> _
    Private callback As KeyboardHookDelegate

    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)

        KeyboardHandle = SetWindowsHookEx( _
          WH_KEYBOARD_LL, callback, _
          Marshal.GetHINSTANCE( _
          [Assembly].GetExecutingAssembly.GetModules()(0)).ToInt32, 0)

        Call CheckHooked()
    End Sub

    Private Sub CheckHooked()
        If (Hooked()) Then
            Console.WriteLine("Keyboard hooked")
        Else
            Console.WriteLine("Keyboard hook failed: " & Err.LastDllError)
        End If
    End Sub

    Private Function Hooked() As Boolean
        Dim hook As Boolean
        hook = KeyboardHandle <> 0
        Return hook
    End Function

    Public Sub UnhookKeyboard()
        If (Hooked()) Then
            Call UnhookWindowsHookEx(KeyboardHandle)
        End If
    End Sub

End Class