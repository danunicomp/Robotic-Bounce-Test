Public Module modGlobals
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Byte
        Public scanCode As Integer
        Public flags As Byte
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    Public Structure structLastKey
        Dim ScanCode As Integer
        Dim Flag As Byte
        Dim VirtualCode As Byte
    End Structure

    Public Structure KeyPosition
        Public Position As Byte
        Public Solenoid As Byte
        Public VirtualCode As Byte
        Public Flag As Byte
        Public SetOneScanCode As Byte
    End Structure

    Public Structure structTestFiles
        Public TestPN As String
        Public TestFileName As String
    End Structure

    Public ioParPort As New IONET.IONET
    Public t As New System.Timers.Timer
    Public bDelayDone As Boolean = False
    Public bStop As Boolean
    Public bKeyTimedOut As Boolean
    Public bStopCycle As Boolean
    Public LastKey As structLastKey
    Public WatchDog As New System.Timers.Timer


    Public ConfigFile As classConfigFile

    'Public Const KeyTimeout As Integer = 250
End Module
