'Imports System.Runtime.InteropServices
'Imports System.Reflection
'Imports System.Drawing
'Imports System.Threading

'Module modHookKB
'    Public LastScanCode As Byte

'    Public Structure structLastKey
'        Dim ScanCode As Integer
'        Dim Flag As Byte
'        Dim VirtualCode As Byte
'    End Structure
'    Public LastKey As structLastKey

'    Public Declare Function UnhookWindowsHookEx Lib "user32" _
'      (ByVal hHook As Integer) As Integer

'    Public Declare Function SetWindowsHookEx Lib "user32" _
'      Alias "SetWindowsHookExA" (ByVal idHook As Integer, _
'      ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, _
'      ByVal dwThreadId As Integer) As Integer

'    Private Declare Function GetAsyncKeyState Lib "user32" _
'      (ByVal vKey As Integer) As Integer

'    Private Declare Function CallNextHookEx Lib "user32" _
'      (ByVal hHook As Integer, _
'      ByVal nCode As Integer, _
'      ByVal wParam As Integer, _
'      ByVal lParam As KBDLLHOOKSTRUCT) As Integer

'    Public Structure KBDLLHOOKSTRUCT
'        Public vkCode As Byte
'        Public scanCode As Integer
'        Public flags As Byte
'        Public time As Integer
'        Public dwExtraInfo As Integer
'    End Structure

'    ' Low-Level Keyboard Constants
'    Private Const HC_ACTION As Integer = 0
'    Private Const LLKHF_EXTENDED As Byte = &H1
'    Private Const LLKHF_INJECTED As Byte = &H10
'    Private Const LLKHF_ALTDOWN As Byte = &H20
'    Private Const LLKHF_UP As Byte = &H80

'    ' Virtual Keys
'    Public Const VK_TAB As Byte = &H9
'    Public Const VK_CONTROL As Byte = &H11
'    Public Const VK_ESCAPE As Byte = &H1B
'    Public Const VK_DELETE As Byte = &H2E
'    Public Const VK_LEFTWINDOWS As Byte = &H5B
'    Public Const VK_RIGHTWINDOWS As Byte = &H5C

'    Private Const WH_KEYBOARD_LL As Byte = 13&
'    Public KeyboardHandle As Integer
'    Public Event KeyHit As EventHandler(Of EventArgs)

'    ' Implement this function to block as many
'    ' key combinations as you'd like
'    Public Function IsHooked( _
'      ByRef Hookstruct As KBDLLHOOKSTRUCT) As Boolean

'        AddHandler KeyHit, AddressOf Diagnose.KeyHits

'        LastScanCode = Hookstruct.vkCode

'        '  If (Hookstruct.flags = HC_ACTION) OrElse (Hookstruct.flags = LLKHF_EXTENDED) OrElse ((Hookstruct.flags And LLKHF_ALTDOWN) = LLKHF_ALTDOWN) Then
'        'If Hookstruct.flags = HC_ACTION Or Hookstruct.flags = LLKHF_EXTENDED Or (Hookstruct.flags And LLKHF_ALTDOWN) Then
'        If (Hookstruct.flags = HC_ACTION) OrElse (Hookstruct.flags = LLKHF_EXTENDED) OrElse ((Hookstruct.flags And LLKHF_ALTDOWN) = LLKHF_ALTDOWN) Then
'            '
'            Console.WriteLine("Hookstruct.vkCode: " & Hex(Hookstruct.vkCode).PadLeft(2, CChar("0")) & _
'            vbTab & "Scan Code: " & Hex(Hookstruct.scanCode).PadLeft(2, CChar("0")) & _
'            vbTab & "Flag: " & Hookstruct.flags)
'            'RaiseEvent KeyHit("KeyHook", Nothing)
'            LastKey.Flag = Hookstruct.flags
'            LastKey.ScanCode = Hookstruct.scanCode
'            LastKey.VirtualCode = Hookstruct.vkCode

'        End If
'        'Console.WriteLine(Hookstruct.scanCode)
'        'console.WriteLine(Hookstruct.vkCode = VK_ESCAPE)
'        'console.WriteLine(Hookstruct.vkCode = VK_TAB)

'        'If (Hookstruct.vkCode = VK_ESCAPE) And _
'        '  CBool(GetAsyncKeyState(VK_CONTROL) _
'        '  And &H8000) Then

'        '    Call HookedState("Ctrl + Esc blocked")
'        '    Return True
'        'End If

'        'If (Hookstruct.vkCode = VK_TAB) And _
'        '  CBool(Hookstruct.flags And _
'        '  LLKHF_ALTDOWN) Then

'        '    Call HookedState("Alt + Tab blockd")
'        '    Return True
'        'End If

'        'If (Hookstruct.vkCode = VK_ESCAPE) And _
'        '  CBool(Hookstruct.flags And _
'        '    LLKHF_ALTDOWN) Then

'        '    Call HookedState("Alt + Escape blocked")
'        '    Return True
'        'End If

'        Return True
'    End Function

'    Private Sub HookedState(ByVal Text As String)
'        Console.WriteLine(Text)
'    End Sub

'    Public Function KeyboardCallback(ByVal Code As Integer, _
'      ByVal wParam As Integer, _
'      ByRef lParam As KBDLLHOOKSTRUCT) As Integer

'        If (Code = HC_ACTION) Then
'            'console.WriteLine("Calling IsHooked")

'            If (IsHooked(lParam)) Then
'                Return 1
'            End If

'        End If

'        Return CallNextHookEx(KeyboardHandle, _
'          Code, wParam, lParam)

'    End Function

'    Public Delegate Function KeyboardHookDelegate( _
'      ByVal Code As Integer, _
'      ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) _
'                   As Integer

'    <MarshalAs(UnmanagedType.FunctionPtr)> _
'    Private callback As KeyboardHookDelegate

'    Public Sub HookKeyboard()
'        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)

'        KeyboardHandle = SetWindowsHookEx( _
'          WH_KEYBOARD_LL, callback, _
'          Marshal.GetHINSTANCE( _
'          [Assembly].GetExecutingAssembly.GetModules()(0)).ToInt32, 0)

'        Call CheckHooked()
'    End Sub

'    Public Sub CheckHooked()
'        If (Hooked()) Then
'            Console.WriteLine("Keyboard hooked")
'        Else
'            Console.WriteLine("Keyboard hook failed: " & Err.LastDllError)
'        End If
'    End Sub

'    Private Function Hooked() As Boolean
'        Dim hook As Boolean
'        hook = KeyboardHandle <> 0
'        Return hook
'    End Function

'    Public Sub UnhookKeyboard()
'        If (Hooked()) Then
'            Call UnhookWindowsHookEx(KeyboardHandle)
'        End If
'    End Sub
'End Module
