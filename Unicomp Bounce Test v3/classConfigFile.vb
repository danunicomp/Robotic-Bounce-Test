Imports System.IO

Public Class classConfigFile

    Public KBPositions As New Collection

    Private iTotalKeysToTest As Integer

    Public ReadOnly Property TotalKeys() As Integer
        Get
            Return iTotalKeysToTest
        End Get
    End Property

    Public Function ReadFKTFile(ByVal sInputFile As String) As Boolean
        ' Dim iCnt As Integer
        Dim sConfigFile As String
        iTotalKeysToTest = 0

        sConfigFile = My.Settings.PathToConfigFiles & "\" & sInputFile

        'KBPositions = Nothing

        'clears collection

        While KBPositions.Count > 0
            KBPositions.Remove(1)
        End While

        Try
            Dim LineArray() As String
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader(sConfigFile)
            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Dim iLinesRead As Integer

            Do
                line = sr.ReadLine()
                If Microsoft.VisualBasic.Left(line, 1) <> "!" And line <> "" Then
                    'Console.WriteLine(line)
                    iLinesRead += 1

                    If iLinesRead > 1 And Not IsNothing(line) Then
                        LineArray = Split(line, " ")
                        Dim KBPos As New KeyPosition
                        KBPos.Position = CByte(LineArray(0))
                        KBPos.Solenoid = HexToByte(LineArray(2))
                        KBPos.VirtualCode = HexToByte(LineArray(4))
                        KBPos.Flag = CByte(LineArray(5))
                        KBPos.SetOneScanCode = HexToByte(LineArray(8))
                        KBPositions.Add(KBPos)
                        iTotalKeysToTest = iTotalKeysToTest + 1
                        'Console.WriteLine(KBPos.Position)
                    End If
                End If

            Loop Until line Is Nothing

            ReadFKTFile = True
            sr.Close()
        Catch ex As System.IO.FileNotFoundException
            ReadFKTFile = False
            MessageBox.Show("File: " & sConfigFile & " Not Found")
            iTotalKeysToTest = 0
        Catch ex As Exception
            ReadFKTFile = False
            MsgBox(ex.ToString)
            iTotalKeysToTest = 0
        Finally
            iTotalKeysToTest = iTotalKeysToTest * My.Settings.NumberOfPasses
        End Try
        'Console.WriteLine(KBPositions.Item(2))

    End Function

    Private Sub CountKeys()

    End Sub
End Class
