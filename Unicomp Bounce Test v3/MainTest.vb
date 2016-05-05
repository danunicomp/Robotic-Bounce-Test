'Imports System.IO
Imports System.Runtime.InteropServices



Public Class frmMain

    <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall,
      CharSet:=CharSet.Unicode, EntryPoint:="keybd_event",
      ExactSpelling:=True, SetLastError:=True)>
    Private Shared Function keybd_event(ByVal bVk As Int32, ByVal bScan As Int32,
               ByVal dwFlags As Int32, ByVal dwExtraInfo As Int32) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Private Shared Function GetKeyState(ByVal nVirtKey As Integer) As Short
    End Function


    Const DEBUGMODE As Boolean = False

    Friend Solenoid As New classSolenoid
    'Dim ConfigFile As classConfigFile
    'Dim WithEvents KeyboardHook As New classKeyboardHook
    Dim WithEvents KeyboardHook As New classKeyboardHook

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        'Solenoid.ResetHead()
        bStop = True
        Call ResetHead()
    End Sub

    Private Sub btnDiagnose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiagnose.Click
        Call KeyboardHook.UnhookKeyboard()
        Dim frmDiag As New Diagnose
        frmDiag.ShowDialog()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Text = "v4"
        'grpTest.Text = "No Test File Loaded"
        Me.Text = "Unicomp FKT v3.40   05-MAY-2016"

        Call PopulateTestFiles()
        AddHandler t.Elapsed, AddressOf TimerFired
        AddHandler WatchDog.Elapsed, AddressOf TimeoutForPosition
        WatchDog.Interval = My.Settings.TimeoutForKey
        KeyboardHook = New classKeyboardHook
        cboTestFile.SelectedIndex = 0

    End Sub

    Private Sub PopulateTestFiles()
        For Each TestFile As String In My.Settings.TestFiles
            cboTestFile.Items.Add(TestFile.Trim.ToUpper)
        Next
    End Sub

    Private Sub cboTestFile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTestFile.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboTestFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestFile.SelectedIndexChanged

        ConfigFile = New classConfigFile
        If ConfigFile.ReadFKTFile(cboTestFile.SelectedItem.ToString) Then
            grpTest.Text = "Test File: " & cboTestFile.SelectedItem.ToString
        Else
            grpTest.Text = "NO TEST FILE LOADED"
        End If

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Call KeyboardHook.UnhookKeyboard()
        ShowLEDs(True)
        Call KeyboardHook.HookKeyboard()
        lstFailedKeys.Items.Clear()
        Call DoTest2()
        Call ResetHead()

    End Sub

#Region " TEST "
    Private Sub ResetHead()
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(0)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(2) ' bring c1 low
    End Sub
    Private Sub ActivateSolenoid(ByVal Solenoid As Byte)
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(1) ' on
    End Sub
    Private Sub RetractSolenoid(ByVal Solenoid As Byte)
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(0) ' off
    End Sub
    Private Sub DoTest2()
        Dim iKeysTested As Integer = 0

        Dim iPasses As Integer
        Dim bKeyPassed As Boolean
        Dim iFailureCount As Integer
        Dim Failure As New KeyPosition
        Call ResetHead()
        bStopCycle = False
        bStop = False
        Dim bKeyBoardFail As Boolean
        Call ResultTest()
        prgTest.Minimum = 0
        prgTest.Maximum = ConfigFile.TotalKeys
        prgTest.Value = 0
        For iPasses = 1 To My.Settings.NumberOfPasses
            For Each curPos As KeyPosition In ConfigFile.KBPositions
                'Console.WriteLine(curPos.Solenoid)

                bKeyTimedOut = False
                bKeyPassed = False
                LastKey = Nothing

                ActivateSolenoid(curPos.Solenoid)
                WatchDog.Enabled = True
                WatchDog.Start()
                While Not bKeyTimedOut And Not bKeyPassed
                    System.Windows.Forms.Application.DoEvents()
                    If LastKey.ScanCode = curPos.SetOneScanCode Then
                        bKeyPassed = True
                    End If
                End While
                If bKeyTimedOut Then
                    'do failed key stuff here
                    Failure = curPos

                    'FailedKeys.Add(Failure)
                    'Console.WriteLine("FAILED. POS: " & Failure.Position)
                    lstFailedKeys.Items.Add("POS:" & Failure.Position &
                    vbTab & "SOL:" & Hex(Failure.Solenoid).PadLeft(2, CChar("0")) & vbTab &
                    "Read: " & Hex(LastKey.ScanCode).PadLeft(2, CChar("0")) & " Expected: " & Hex(curPos.SetOneScanCode).PadLeft(2, CChar("0")))
                    bKeyBoardFail = True
                    iFailureCount = iFailureCount + 1
                    If iFailureCount >= My.Settings.MaxFailures Then
                        bStop = True
                    End If
                End If
                iKeysTested = iKeysTested + 1
                prgTest.Value = iKeysTested
                prgTest.Refresh()
                WatchDog.Stop()
                bKeyPassed = False
                RetractSolenoid(curPos.Solenoid)
                If bStop And Not DEBUGMODE Then Exit For

            Next
            If bKeyBoardFail And Not DEBUGMODE Then Exit For

        Next
        Call KeyboardHook.UnhookKeyboard()
        If bStop Then Call ResultAbort()
        If bKeyBoardFail Then
            Call ResultFail()
        Else
            Call KeyboardHook.UnhookKeyboard()
            ShowLEDs(True)
            Call ResultPass()
        End If


    End Sub

    Private Sub ShowLEDs(ByVal newState As Boolean)
        ' if the current state must be changed
        If CBool(GetKeyState(Keys.CapsLock)) <> newState Then
            ' programmatically press and release the CapsLock key
            keybd_event(Keys.CapsLock, 0, 0, 0)
            keybd_event(Keys.CapsLock, 0, &H2, 0)
        End If

        If CBool(GetKeyState(Keys.NumLock)) <> newState Then
            keybd_event(Keys.NumLock, 0, 0, 0)
            keybd_event(Keys.NumLock, 0, &H2, 0)
        End If

        If CBool(GetKeyState(Keys.Scroll)) <> newState Then
            keybd_event(Keys.Scroll, 0, 0, 0)
            keybd_event(Keys.Scroll, 0, &H2, 0)
        End If
    End Sub


    Private Sub ResultFail()
        lblResult.ForeColor = Color.Red
        lblResult.Text = "FAIL"
    End Sub

    Private Sub ResultPass()
        lblResult.ForeColor = Color.Green
        lblResult.Text = "PASS"
    End Sub

    Private Sub ResultAbort()
        lblResult.ForeColor = Color.Blue
        lblResult.Text = "Abort"
    End Sub

    Private Sub ResultTest()
        lblResult.ForeColor = Color.Blue
        lblResult.Text = "Test"
    End Sub

    Private Sub TimeoutForPosition(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Do stuff Here
        bKeyTimedOut = True
    End Sub
    Private Sub TimerFired(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Do stuff Here
        bDelayDone = True
        ' txtCurrentSolenoid.Text = Hex(bySolenoid).PadLeft(2, Chr(48))
    End Sub
    Private Sub UpdateStatus(ByVal Message As KBDLLHOOKSTRUCT) Handles KeyboardHook.KeyHit

        'Update the status message in the StatusBarPanel1
        Console.WriteLine(Hex(Message.scanCode))
        'ListBox1.Items.Add(Hex(Message.scanCode) & vbTab & Hex(Message.vkCode))
        LastKey.ScanCode = Message.scanCode
        'ListBox1.SelectedIndex = ListBox1.Items.Count - 1

    End Sub
#End Region

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim frmConfig As New ConfigForm
        frmConfig.ShowDialog()
    End Sub

    Private Sub btnTestLights_Click(sender As Object, e As EventArgs) Handles btnTestLights.Click

    End Sub
End Class

Class classSolenoid

    ' to reset send 2 to address 890
    '  (bring c1 LOW)

    ' to fire solenoid
    '   ioParPort.WriteAddress = 888    'set address to 888
    '  ioParPort.WriteIO(bySolenoid)    ' send solenoid number
    '  ioParPort.WriteAddress = 890     ' set activate address
    '  ioParPort.WriteIO(1) ' on        ' send 1

    Dim ioParPort As New IONET.IONET
    Private bDelayDone As Boolean

    Public Sub ExtendSolenoid(ByVal Solenoid As Byte)
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(1) ' on
    End Sub

    Public Sub RetractSolenoid(ByVal Solenoid As Byte)
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(0) ' off
    End Sub

    Public Sub ResetHead()
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(0)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(2) ' bring c1 low
    End Sub

    Public bstop As Boolean
    Public Sub ExerciseSolenoid(ByVal Solenoid As Byte)
        Dim t As New Timer
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        t.Interval = 500
        t.Enabled = False

        t.Enabled = True

        Do While Not bStop
            ioParPort.WriteAddress = 890
            ioParPort.WriteIO(1) ' on
            Console.WriteLine(Now & vbTab & "On")
            System.Threading.Thread.Sleep(500)
            ioParPort.WriteAddress = 890
            ioParPort.WriteIO(0) ' off
            Console.WriteLine(Now & vbTab & "off")
            System.Threading.Thread.Sleep(500)

            System.Windows.Forms.Application.DoEvents()
        Loop

    End Sub

End Class

