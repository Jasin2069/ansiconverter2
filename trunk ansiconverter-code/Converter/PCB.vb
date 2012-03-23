Public Module PCB
    Public Sub ProcessPCBFile(ByVal aFile As Byte())
        Call ProcessPCBFile("", aFile)
    End Sub

    Public Sub ProcessPCBFile(ByVal sFile As String, Optional ByVal aFile As Byte() = Nothing)

        Dim aAnsi As Byte() = Nothing
        Dim AnsiMode As Integer = 0
        Dim bDrawChar As Boolean
        Dim CurChr As Integer, iLoop2 As Integer
        Dim sStr As String = ""
        
        If Not aFile Is Nothing Then
            aAnsi = MergeByteArrays(NullByteArray, aFile)
        Else
            If IO.File.Exists(sFile) Then : aAnsi = ReadBinaryFile(sFile) : aAnsi = MergeByteArrays(NullByteArray, aAnsi) : End If
        End If

        Call BuildMappings(sCodePg)

        ForeColor = 7 : BackColor = 0 : LineWrap = True : Blink = False : Bold = 0 : Reversed = False : LinesUsed = 0
        ReDim Screen(maxX, maxY)
        For x As Integer = minX To maxX
            For Y As Integer = minY To maxY
                Screen(x, Y) = New ScreenChar(x)
            Next
        Next
        System.Windows.Forms.Application.DoEvents()
        XPos = minX : YPos = minY
        If Not aAnsi Is Nothing Then
            If UBound(aAnsi) > 0 Then
                iLoop = 1
                Do While iLoop <= UBound(aAnsi)
                    bDrawChar = True : CurChr = CInt(aAnsi(iLoop))
                    Select Case AnsiMode
                        Case 0
                            If CurChr = 64 Then '@
                                AnsiMode = 1 : bDrawChar = False
                            End If
                            If CurChr = 26 Or CurChr = 83 Then 'SUB or "S"
                                Dim iSauceOffset As Integer = IIf(CurChr = 83, 1, 0)
                                If UBound(aAnsi) >= iLoop + 128 - iSauceOffset Then
                                    sStr = ""
                                    For iLoop2 = 1 - iSauceOffset To 5 - iSauceOffset
                                        sStr &= Chr(aAnsi(iLoop + iLoop2))
                                    Next
                                    If sStr = "SAUCE" Then
                                        bDrawChar = False
                                        iLoop += 1 - iSauceOffset : iLoop = oSauce.GetFromByteArray(aAnsi, iLoop) : bHasSauce = True 'Read Sauce
                                        If bDebug = True Then Console.WriteLine("Sauce Meta found")
                                    End If
                                End If
                            End If
                        Case 1
                            If CurChr = 88 Then  'X
                                AnsiMode = 2 : bDrawChar = False
                            Else
                                Dim bRevert As Boolean = True
                                If UBound(aAnsi) >= iLoop + 5 Then
                                    sStr = ""
                                    For iLoop2 = 1 To 5
                                        sStr &= Chr(aAnsi(iLoop + iLoop2))
                                    Next
                                    If sStr = Left("CLS@", 4) Or sStr = Left("PON@", 4) Then
                                        iLoop += 4 : AnsiMode = 0 : bRevert = False
                                    Else
                                        If sStr = "POFF@" Then
                                            iLoop += 5 : AnsiMode = 0 : bRevert = False
                                        End If
                                    End If
                                End If
                                If bRevert = True Then
                                    If SetChar(Chr(64)) = False Then
                                        iLoop = UBound(aAnsi) + 1
                                    Else
                                        bDrawChar = True : AnsiMode = 0
                                    End If
                                End If
                            End If
                        Case 2
                            If UBound(aAnsi) >= iLoop + 1 Then
                                If isHex(Chr(CurChr)) And isHex(Chr(aAnsi(iLoop + 1))) Then
                                    BackColor = HexToDec(CStr(Chr(CurChr)))
                                    ForeColor = HexToDec(CStr(Chr(aAnsi(iLoop + 1))))
                                    If ForeColor > 7 Then : Bold = 8 : ForeColor -= 8 : Else : Bold = 0 : End If
                                    AnsiMode = 0
                                    iLoop += 1
                                    bDrawChar = False
                                Else
                                    bDrawChar = True
                                End If
                            Else
                                bDrawChar = True
                            End If
                            If bDrawChar = True Then
                                If SetChar(Chr(64)) = False Then
                                    iLoop = UBound(aAnsi) + 1
                                Else
                                    If SetChar(Chr(88)) Then
                                        AnsiMode = 0
                                    Else
                                        iLoop = UBound(aAnsi) + 1
                                    End If
                                End If
                            End If

                    End Select
                    If bDrawChar = True And AnsiMode = 0 Then
                        Select Case CurChr
                            Case 10
                                YPos += 1
                                If YPos > maxY - 1 Then
                                    YPos = maxY - 1 : iLoop = UBound(aAnsi) + 1
                                Else
                                    XPos = minX
                                End If
                                If YPos > LinesUsed Then : LinesUsed = YPos : End If
                            Case 13 ' restore X in linefeed so's to support *nix type files
                            Case 26 'ignore
                            Case Else : If SetChar(Chr(CurChr)) = False Then : iLoop = UBound(aAnsi) + 1 : End If
                        End Select
                    End If
                    iLoop += 1
                    If iLoop / 1000 = CInt(iLoop / 1000) Then System.Windows.Forms.Application.DoEvents()
                Loop
            End If
        End If
    End Sub
End Module
