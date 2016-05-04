Public Class Diagnose

    'Dim ioParPort As New IONET.IONET
    'Dim t As New System.Timers.Timer
    'Dim bDelayDone As Boolean = False
    'Dim bStop As Boolean
    'Dim bKeyTimedOut As Boolean
    'Dim bStopCycle As Boolean
    ''
    'Dim WithEvents KeyboardHook As New classKeyboardHook
    'Dim ConfigFile As classConfigFile
    'Public LastKey As structLastKey
    'Public WatchDog As New System.Timers.Timer
    Dim WithEvents KeyboardHook As New classKeyboardHook
    'Miliseconds to wait for scancode

    Private Sub Diagnose_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Call KeyboardHook.UnhookKeyboard()
    End Sub

    Private Sub Diagnose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler t.Elapsed, AddressOf TimerFired
        AddHandler WatchDog.Elapsed, AddressOf TimeoutForPosition
        WatchDog.Interval = My.Settings.TimeoutForKey
        KeyboardHook = New classKeyboardHook
    End Sub
    Private Sub UpdateStatus(ByVal Message As KBDLLHOOKSTRUCT) Handles KeyboardHook.KeyHit


        'Update the status message in the StatusBarPanel1
        'Console.WriteLine(Hex(Message.scanCode))
        ListBox1.Items.Add(Hex(Message.scanCode) & vbTab & Hex(Message.vkCode))
        LastKey.ScanCode = Message.scanCode
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1

    End Sub
    Private Sub TimeoutForPosition(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Do stuff Here
        bKeyTimedOut = True

    End Sub
    Private Sub btnFireSolenoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFireSolenoid.Click
        Dim Solenoid As String
        If chkCycle.Checked = True Then
            Call CycleSolenoid(HexToByte(cmbSelectSolenoid.Text.ToUpper))
            ' Call CycleSolenoid(HexToByte(txtSolenoid.Text.ToUpper))
        Else
            Call ActivateSolenoid(HexToByte(txtSolenoid.Text.ToUpper))
        End If

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
    Private Sub CycleSolenoid(ByVal Solenoid As Byte)
        t.Interval = 300
        Call ResetHead()
        bStop = False
        While Not bStop
            ioParPort.WriteAddress = 888
            ioParPort.WriteIO(Solenoid)
            ioParPort.WriteAddress = 890
            ioParPort.WriteIO(1) ' on
            Console.WriteLine(Solenoid.ToString & " On " & Now)
            bDelayDone = False
            t.Enabled = True
            t.Start()
            While Not bDelayDone                        '
                System.Windows.Forms.Application.DoEvents()
                If bStop Then
                    Call ResetHead()
                    Exit Sub
                End If
            End While
            't.Enabled = False
            t.Stop()
            System.Windows.Forms.Application.DoEvents()
            ioParPort.WriteAddress = 890
            ioParPort.WriteIO(0) ' off
            Console.WriteLine(Solenoid.ToString & " Off " & Now)
            bDelayDone = False

            '     t.Enabled = True
            t.Start()
            While Not bDelayDone                        '
                System.Windows.Forms.Application.DoEvents()
                If bStop Then
                    Call ResetHead()
                    Exit Sub
                End If
            End While
            t.Stop()
            '    t.Enabled = False
        End While

    End Sub

    Private Sub FireAndRetract(ByVal Solenoid As Byte)
        t.Interval = 200
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(Solenoid)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(1) ' on
        Console.WriteLine(Solenoid.ToString & " On " & Now)
        bDelayDone = False
        t.Enabled = True
        t.Start()
        While Not bDelayDone                        '
            System.Windows.Forms.Application.DoEvents()
            If bStop Then
                Call ResetHead()
                Exit Sub
            End If
        End While
        't.Enabled = False
        t.Stop()
        System.Windows.Forms.Application.DoEvents()
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(0) ' off
        Console.WriteLine(Solenoid.ToString & " Off " & Now)
        bDelayDone = False

        '     t.Enabled = True
        t.Start()
        While Not bDelayDone                        '
            System.Windows.Forms.Application.DoEvents()
            If bStop Then
                Call ResetHead()
                Exit Sub
            End If
        End While
        t.Stop()
        '    t.Enabled = False
    End Sub


    Private Sub TimerFired(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        'Do stuff Here
        bDelayDone = True
        ' txtCurrentSolenoid.Text = Hex(bySolenoid).PadLeft(2, Chr(48))
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        bStop = True
        Call ResetHead()
    End Sub
    Public Sub ResetHead()
        ioParPort.WriteAddress = 888
        ioParPort.WriteIO(0)
        ioParPort.WriteAddress = 890
        ioParPort.WriteIO(2) ' bring c1 low
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        KeyboardHook.UnhookKeyboard()
        ListBox1.Items.Clear()
    End Sub

    Private Sub btnLoadConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadConfig.Click

        Call LoadConfig()

    End Sub

    Private Sub LoadConfig()
        Dim Keys As New KeyPosition

        ConfigFile = New classConfigFile
        ConfigFile.ReadFKTFile("C:\Unicomp\FKT\USB104.FKT")

        ' Keys = ConfigFile.KBPositions.
        ' Console.WriteLine(ConfigFile.KBPositions.Item(1))

        'For Each curPos As KeyPosition In ConfigFile.KBPositions
        '    Console.WriteLine(curPos.Solenoid)
        '    FireAndRetract(curPos.Solenoid)
        'Next
    End Sub


    Private Sub DoTest2()

        'Dim iPasses As Integer
        Dim bKeyPassed As Boolean
        Dim Failure As New KeyPosition
        Call ResetHead()
        bStopCycle = False

        For Each curPos As KeyPosition In ConfigFile.KBPositions
            Console.WriteLine(curPos.Solenoid)

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
                Console.WriteLine("FAILED. POS: " & Failure.Position)
                ListBox1.Items.Add("FAILED. POS: " & Failure.Position & vbTab & "Read: " & Hex(LastKey.ScanCode).PadLeft(2, CChar("0")) & vbTab & "Expected: " & Hex(curPos.SetOneScanCode).PadLeft(2, CChar("0")))
            End If
            WatchDog.Stop()
            bKeyPassed = False
            RetractSolenoid(curPos.Solenoid)
        Next


    End Sub

    'Private Sub DoTest()
    '    'Dim CurPos As KeyPosition
    '    Dim Failure As New KeyPosition
    '    Dim bKeyTimedOut, bKeyPassed, bStopCycle As Boolean
    '    Dim iPasses As Integer

    '    Call ResetHead()
    '    ListBox1.Items.Clear()
    '    bStopCycle = False
    '    While Not bStopCycle And iPasses <> 4
    '        For Each curPos As KeyPosition In ConfigFile.KBPositions
    '            'Console.WriteLine(Hex(CurPos.Solenoid))
    '            bKeyTimedOut = False
    '            bKeyPassed = False
    '            LastKey = Nothing
    '            ActivateSolenoid(curPos.Solenoid)
    '            WatchDog.Enabled = True
    '            While Not bKeyTimedOut And Not bKeyPassed
    '                System.Windows.Forms.Application.DoEvents()
    '                If LastKey.ScanCode = curPos.SetOneScanCode Then
    '                    bKeyPassed = True
    '                End If
    '            End While
    '            If bKeyTimedOut Then
    '                'do failed key stuff here
    '                Failure = curPos
    '                'FailedKeys.Add(Failure)
    '                Console.WriteLine("FAILED. POS: " & curPos.Position)
    '                ListBox1.Items.Add("FAILED. POS: " & curPos.Position & vbTab & "Read: " & Hex(LastKey.ScanCode).PadLeft(2, CChar("0")) & vbTab & "Expected: " & Hex(curPos.SetOneScanCode).PadLeft(2, CChar("0")))
    '            End If

    '            If bKeyPassed Then
    '                'do pass key stuff here
    '            End If
    '            bKeyPassed = False
    '            WatchDog.Enabled = False

    '            RetractSolenoid(curPos.Solenoid)
    '        Next
    '        iPasses += 1
    '        'For Each CurPos In FailedKeys
    '        '    Console.WriteLine(CurPos.Position)
    '        'Next
    '        System.Windows.Forms.Application.DoEvents()
    '    End While
    'End Sub


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Call KeyboardHook.HookKeyboard()
        Call LoadConfig()
        Call DoTest2()
    End Sub

    Private Sub btnHook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHook.Click
        Call KeyboardHook.HookKeyboard()
        ListBox1.Items.Add("Keyboard Hooked")
    End Sub

    Private Sub txtSolenoid_TextChanged(sender As Object, e As EventArgs) Handles txtSolenoid.TextChanged

    End Sub

    Private Sub chkCycle_CheckedChanged(sender As Object, e As EventArgs) Handles chkCycle.CheckedChanged

    End Sub
End Class

Friend Module Functions
    Public Function HexToByte(ByVal sHex As String) As Byte

        Dim LeftPart, RightPart As String
        Dim sHexCodes As String
        Dim iByte As Byte

        sHexCodes = "0123456789ABCDEF"
        sHex = UCase(sHex)
        If Len(sHex) <> 2 Then
            Return 0
        Else

            LeftPart = UCase(Left(sHex, 1))
            RightPart = UCase(Right(sHex, 1))

            iByte = CByte(((InStr(sHexCodes, LeftPart) - 1) * 16))
            iByte = iByte + CByte((InStr(sHexCodes, RightPart) - 1))
        End If

        Return iByte
    End Function
End Module


