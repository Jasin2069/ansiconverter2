

Public Class ANSI
    Public Event InfoMsg(ByVal Msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
    Public Sub New()

    End Sub
    Public Sub ProcessANSIFile(ByVal aFile As Byte())
        Call ProcessANSIFile("", aFile)
    End Sub

    Public Sub ProcessANSIFile(ByVal sFile As String, Optional ByVal aFile As Byte() = Nothing)
        If bDebug Then : Console.WriteLine("Process ANS File: " & sFile) : End If
        Dim StoreX As Integer = 1, StoreY As Integer = 1
        Dim AnsiMode As Integer = 0
        Dim aAnsi As Byte() = Nothing, aPar() As String
        Dim bDrawChar As Boolean, bEnde As Boolean
        Dim CurChr As Integer, iLoop2 As Integer
        Dim sStr As String = "", sEsc As String = ""
        Dim Frame As Drawing.Bitmap = Nothing
        Dim multiplier As Double = 0.0
        LineWrap = False
        Yoffset = 0
        Dim BPF As Integer = Math.Floor((BPS / 8) / FPS)
        cBPF = 0
        iFramesCount = 0
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
                If bMakeVideo Then
                    multiplier = 100 / UBound(aAnsi)

                    RaiseEvent InfoMsg(" - Frames Created: ", True, False)
                    RaiseEvent InfoMsg("[b]    0[/b] (  0.00%)", False, False)
                End If
                Do While iLoop <= UBound(aAnsi)

                    bDrawChar = True : CurChr = CInt(aAnsi(iLoop))
                    Select Case AnsiMode
                        Case 0
                            If CurChr = 27 Then 'ESC
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
                                        '  If bDebug = True Then Console.WriteLine("Sauce Meta found")
                                    End If
                                End If
                            End If
                        Case 1
                            If CurChr = 91 Then  '[
                                AnsiMode = 2 : bDrawChar = False
                            Else
                                If SetChar(Chr(27)) = False Then
                                    iLoop = UBound(aAnsi) + 1
                                Else
                                    bDrawChar = True : AnsiMode = 0
                                End If
                            End If
                        Case 2
                            Dim aRRSize
                            aRRSize = UBound(aAnsi) : sEsc = Chr(CurChr)
                            If (CurChr >= 48 And CurChr <= 57) Or CurChr = 59 Or CurChr = 63 Then '0-9 or ; or ?
                                bEnde = False
                                Do While bEnde = False
                                    iLoop += 1
                                    If iLoop > aRRSize Then
                                        bEnde = True
                                    Else
                                        CurChr = aAnsi(iLoop) : sEsc &= CStr(Chr(CurChr))
                                        'A-Z, a-z
                                        If (CurChr >= 65 And CurChr <= 90) Or (CurChr >= 97 And CurChr <= 122) Or CurChr = 27 Then : bEnde = True : End If
                                    End If
                                    If CurChr = 27 Then
                                        AnsiMode = 1 : bDrawChar = False
                                    End If
                                Loop
                            End If
                            If AnsiMode = 2 Then


                                aPar = BuildParams(sEsc)
                                Dim NumParams As Integer = UBound(aPar)
                                Select Case Chr(CurChr)
                                    Case "A"
                                        'Move Cursor Up
                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        YPos = YPos - iLoop2
                                        Dim iSavY As Integer = YPos
                                        ' If bDebug = True Then Console.WriteLine("YPos - " & iLoop2 & ", New YPos: " & YPos)
                                        If YPos < minY Then : YPos = minY : End If
                                        'If YPos < Yoffset Then
                                        'Yoffset = YPos
                                        'End If
                                        ' If iSavY <> YPos Then
                                        'If bDebug = True Then Console.WriteLine("Adjusted Pos Y: " & YPos)
                                        ' End If
                                        cBPF -= 1
                                    Case "B"
                                        'Move Cursor Down
                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        YPos = YPos + iLoop2
                                        Dim iSavY As Integer = YPos
                                        ' If bDebug = True Then Console.WriteLine("YPos + " & iLoop2 & ", New YPos: " & YPos)
                                        If YPos > maxY - 1 Then : YPos = maxY - 1 : End If
                                        If YPos > LinesUsed Then
                                            ' If LinesUsed > 25 Then
                                            'Yoffset += (YPos - LinesUsed)
                                            'End If
                                            LinesUsed = YPos
                                        End If
                                        ' If iSavY <> YPos Then
                                        'If bDebug = True Then Console.WriteLine("Adjusted Pos Y: " & YPos)
                                        ' End If
                                        cBPF -= 1
                                    Case "C"
                                        'Move Cursor Right
                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        For x As Integer = 1 To iLoop2
                                            If SetChar("-2") = False Then iLoop = UBound(aAnsi) + 1
                                        Next
                                        cBPF -= 1
                                    Case "D"
                                        'Move Cursor left
                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        If iLoop2 = 255 Then
                                            XPos = minX
                                        Else
                                            For x As Integer = 1 To iLoop2
                                                If SetChar("-3") = False Then iLoop = UBound(aAnsi) + 1
                                            Next
                                        End If
                                        cBPF -= 1
                                    Case "H" 'Move Cursor to pos

                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : YPos = IIf(iLoop2 > 0, minY + (iLoop2 - 1), minY)
                                        Else
                                            YPos = minY
                                        End If
                                        If NumParams > 1 Then
                                            iLoop2 = ChkNum(aPar(2)) : XPos = IIf(iLoop2 > 0, minX + (iLoop2 - 1), minX)
                                        Else
                                            XPos = minX
                                        End If
                                        Dim iSavX As Integer = XPos
                                        Dim iSavY As Integer = YPos
                                        ' If bDebug = True Then Console.WriteLine("New Cursor Pos X:" & XPos & ", Y: " & YPos)
                                        If YPos > maxY - 1 Then : YPos = maxY - 1 : End If
                                        If YPos < minY Then : YPos = minY : End If
                                        If XPos > maxX Then : XPos = maxX : End If
                                        If XPos < minX Then : XPos = minX : End If
                                        If YPos > LinesUsed Then
                                            If LinesUsed > 25 Then
                                                Yoffset += (YPos - LinesUsed)
                                            End If
                                            LinesUsed = YPos
                                        End If
                                        If YPos < Yoffset Then
                                            Yoffset = YPos - 1
                                        End If
                                        ' If iSavX <> XPos Or iSavY <> YPos Then
                                        ' If bDebug = True Then Console.WriteLine("Adjusted Pos X: " & XPos & ", Y: " & YPos)
                                        ' End If
                                        cBPF -= 1
                                    Case "f" 'Move Cursor to pos
                                        If NumParams > 0 Then
                                            iLoop2 = ChkNum(aPar(1)) : YPos = IIf(iLoop2 > 0, minY + (iLoop2 - 1), minY)
                                        Else
                                            YPos = minY
                                        End If
                                        If NumParams > 1 Then
                                            iLoop2 = ChkNum(aPar(2)) : XPos = IIf(iLoop2 > 0, minX + (iLoop2 - 1), minX)
                                        Else
                                            XPos = minX
                                        End If
                                        Dim iSavX As Integer = XPos
                                        Dim iSavY As Integer = YPos
                                        If YPos > maxY - 1 Then : YPos = maxY - 1 : End If
                                        If YPos < minY Then : YPos = minY : End If
                                        If XPos > maxX Then : XPos = maxX : End If
                                        If XPos < minX Then : XPos = minX : End If
                                        If YPos > LinesUsed Then
                                            'Yoffset()
                                            If LinesUsed > 25 Then
                                                Yoffset += (YPos - LinesUsed)
                                            End If
                                            LinesUsed = YPos
                                        End If
                                        If YPos < Yoffset Then
                                            Yoffset = YPos - 1
                                        End If
                                        'If iSavX <> XPos Or iSavY <> YPos Then
                                        ' If bDebug = True Then Console.WriteLine("Adjusted Pos X: " & XPos & ", Y: " & YPos)
                                        ' End If
                                        cBPF -= 1
                                    Case "J"
                                        'ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False
                                        If NumParams > 0 Then
                                            Select Case ChkNum(aPar(1))
                                                Case 0 'erase from cursor to end of screen
                                                    ClearLineFromCursor(YPos, XPos)
                                                    If YPos < maxY Then
                                                        For Y As Integer = YPos + 1 To maxY
                                                            ClearLine(Y)
                                                        Next
                                                    End If
                                                    '   If bDebug = True Then Console.WriteLine("Clear Cursor to End of Screen X:" & XPos & ", Y: " & YPos)
                                                Case 1 'Erase from beginning of screen to cursor
                                                    ClearLineToCursor(YPos, XPos)
                                                    If YPos > minY Then
                                                        For Y As Integer = YPos - 1 To minY
                                                            ClearLine(Y)
                                                        Next
                                                    End If
                                                    'If bDebug = True Then Console.WriteLine("Clear Beginning of Screen to Cursor X:" & XPos & ", Y: " & YPos)
                                                Case 2 'Clear screen and home cursor
                                                    For Y As Integer = minY To LinesUsed
                                                        ClearLine(Y)
                                                    Next
                                                    XPos = minX : YPos = minY
                                                    'If bDebug = True Then Console.WriteLine("Clear Screen X:" & XPos & ", Y: " & YPos)
                                            End Select
                                        Else 'Erase from cursor to end of screen
                                            ClearLineFromCursor(YPos, XPos)
                                            If YPos < maxY Then
                                                For Y As Integer = YPos + 1 To maxY
                                                    ClearLine(Y)
                                                Next
                                            End If
                                            '  If bDebug = True Then Console.WriteLine("Clear Cursor to End of Screen X:" & XPos & ", Y: " & YPos)
                                        End If
                                        cBPF -= 1

                                    Case "m" 'Set Attribute
                                        If NumParams = 0 Then : ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False : End If
                                        For iLoop3 = 1 To NumParams
                                            Dim i2
                                            iLoop2 = ChkNum(aPar(iLoop3))
                                            Select Case iLoop2
                                                Case 0
                                                    If CStr(Left(aPar(iLoop3), 1)) = "0" Then
                                                        ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False
                                                    End If
                                                Case 1 : Bold = 8
                                                Case 2 : Bold = 0
                                                Case 5 : Blink = True
                                                Case 7 : i2 = ForeColor : ForeColor = BackColor : BackColor = i2 : Reversed = True
                                                Case 22 : Bold = 0
                                                Case 25 : Blink = False
                                                Case 27 : i2 = ForeColor : ForeColor = BackColor : BackColor = i2 : Reversed = False
                                                Case 30 : ForeColor = 0
                                                Case 31 : ForeColor = 4
                                                Case 32 : ForeColor = 2
                                                Case 33 : ForeColor = 6
                                                Case 34 : ForeColor = 1
                                                Case 35 : ForeColor = 5
                                                Case 36 : ForeColor = 3
                                                Case 37 : ForeColor = 7
                                                Case 40 : BackColor = 0
                                                Case 41 : BackColor = 4
                                                Case 42 : BackColor = 2
                                                Case 43 : BackColor = 6
                                                Case 44 : BackColor = 1
                                                Case 45 : BackColor = 5
                                                Case 46 : BackColor = 3
                                                Case 47 : BackColor = 7
                                            End Select
                                            cBPF -= 1
                                        Next
                                    Case "K"
                                        If NumParams > 0 Then
                                            Select Case ChkNum(aPar(1))
                                                Case 0
                                                    ClearLineFromCursor(YPos, XPos) 'clear to the end of the line
                                                Case 1
                                                    ClearLineToCursor(YPos, XPos) 'Erase from beginning of line to cursor
                                                Case 2
                                                    ClearLine(YPos) 'Erase line containing the cursor
                                            End Select
                                        Else
                                            ClearLineFromCursor(YPos, XPos) 'clear to the end of the line
                                        End If
                                        cBPF -= 1
                                        'iLoop2 = XPos
                                        'Do While iLoop2 <= maxX
                                        ' iLoop2 = IIf(SetChar("-1"), iLoop2 + 1, maxX + 1)
                                        ' Loop
                                    Case "s" : StoreX = XPos : StoreY = YPos     'save cursor position
                                        cBPF -= 2
                                        'If bDebug = True Then Console.WriteLine("Save pos X: " & XPos & ", Y:" & YPos)
                                    Case "u"
                                        ' If bDebug = True Then Console.WriteLine("Restore pos X: " & StoreX & ", Y:" & StoreY & ", Old Pos X: " & XPos & ", Y:" & YPos)
                                        XPos = StoreX : YPos = StoreY     'return to saved position
                                        cBPF -= 1
                                        If YPos > LinesUsed Then
                                            'Yoffset()
                                            If LinesUsed > 25 Then
                                                Yoffset += (YPos - LinesUsed)
                                            End If
                                            LinesUsed = YPos
                                        End If
                                        ' If YPos < Yoffset Then
                                        'Yoffset = YPos - 1
                                        'End If
                                    Case "n" 'Report Cursor Position
                                        cBPF -= 2
                                    Case "h" 'Set Display Mode
                                        '<[=Xh   X = Mode, 7 = Turn ON linewrap
                                        If NumParams > 0 Then
                                            If aPar(1) = "?7" Or aPar(1) = "7" Then
                                                'If bDebug = True Then Console.WriteLine(aPar(1) & ", Turn on Linewrap")
                                                LineWrap = True
                                            End If
                                        End If

                                    Case "l" 'Set Display Mode
                                        '<[=7l  = Truncate Lines longer than 80 chars
                                        If NumParams > 0 Then
                                            If aPar(1) = "?7" Or aPar(1) = "7" Then
                                                'If bDebug = True Then Console.WriteLine(aPar(1) & ", Truncate Lines longer than 80 chars")
                                                LineWrap = False
                                            End If
                                        End If
                                    Case Else
                                        If bDebug Then : Console.WriteLine("Unknown ANSI Command: " & Chr(CurChr) & " (" & CurChr.ToString & ") Params: " & Join(aPar, "|").ToString) : End If
                                End Select
                                bDrawChar = False : AnsiMode = 0
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
                                If YPos > LinesUsed Then
                                    If LinesUsed > 25 Then
                                        Yoffset += (YPos - LinesUsed)
                                    End If
                                    LinesUsed = YPos
                                End If
                                'If YPos < Yoffset Then
                                'Yoffset = YPos
                                'End If
                            Case 13 ' restore X in linefeed so's to support *nix type files
                                ' XPos = 1
                            Case 26 'ignore
                            Case Else : If SetChar(Chr(CurChr)) = False Then : iLoop = UBound(aAnsi) + 1 : End If
                        End Select
                    End If
                    If YPos > LinesUsed Then
                        '   If LinesUsed > 25 Then
                        'Yoffset += (YPos - LinesUsed)
                        'End If
                        LinesUsed = YPos
                    End If
                    'If YPos < Yoffset Then
                    'Yoffset = YPos - 1
                    'End If
                    iLoop += 1
                    cBPF += 1
                    If cBPF = BPF Then
                        If bMakeVideo Then
                            Frame = CreateVideoFrame(pSmallFont, pNoColors, Yoffset)
                            'TempVideoFolder
                            iFramesCount += 1
                            'oAVIFile.AddFrame(Frame)
                            'If bDebug Then
                            '
                            Dim newOutFile As String = IO.Path.Combine(TempVideoFolder, IO.Path.GetFileNameWithoutExtension(OutFileWrite) & "_" & Strings.Right("00000" & iFramesCount.ToString, 5) & ".PNG")
                            Frame.Save(newOutFile, System.Drawing.Imaging.ImageFormat.Png)
                            If iFramesCount / 10 = CInt(iFramesCount / 10) Then
                                RaiseEvent InfoMsg("[b]" & Strings.Right("     " & iFramesCount.ToString, 5) & "[/b] (" & Strings.Right("   " & Math.Round(iLoop * multiplier, 2).ToString, 6) & "%)", True, True)
                            End If

                            'End If
                            '
                        End If
                        cBPF = 0
                    End If
                    If iLoop / 1000 = CInt(iLoop / 1000) Then System.Windows.Forms.Application.DoEvents()
                Loop
                If bMakeVideo Then
                    RaiseEvent InfoMsg("[b]" & Strings.Right("     " & iFramesCount.ToString, 5) & "[/b] (100.00%)", True, True)
                    If LastFrame > 0 And Not Frame Is Nothing Then
                        For tmpi As Integer = 1 To Math.Floor(FPS * LastFrame)
                            iFramesCount += 1
                            Dim newOutFile As String = IO.Path.Combine(TempVideoFolder, IO.Path.GetFileNameWithoutExtension(OutFileWrite) & "_" & Strings.Right("00000" & iFramesCount.ToString, 5) & ".PNG")
                            Frame.Save(newOutFile, System.Drawing.Imaging.ImageFormat.Png)
                            RaiseEvent InfoMsg("[b]" & Strings.Right("     " & iFramesCount.ToString, 5) & "[/b] (100.00%)", True, True)
                        Next
                    End If
                    RaiseEvent InfoMsg("[b]" & Strings.Right("     " & iFramesCount.ToString, 5) & "[/b] (100.00%)", True, True)
                    RaiseEvent InfoMsg(vbCrLf, True, False)
                End If
            End If

        End If

    End Sub
    Sub ClearLine(ByVal iLine As Integer)
        For x As Integer = minX To maxX
            Screen(x, iLine) = New ScreenChar(x)
            Screen(x, iLine).BackColor = BackColor
        Next
    End Sub
    Sub ClearLineToCursor(ByVal iLine As Integer, ByVal ipos As Integer)
        For x As Integer = minX To ipos
            Screen(x, iLine) = New ScreenChar(x)
            Screen(x, iLine).BackColor = BackColor
        Next
    End Sub
    Sub ClearLineFromCursor(ByVal iLine As Integer, ByVal iPos As Integer)
        For x As Integer = iPos To maxX
            Screen(x, iLine) = New ScreenChar(x)
            Screen(x, iLine).BackColor = BackColor
        Next
    End Sub
 

    Function MoveCursorFW(ByVal iNum As Integer) As Boolean
        Dim bRes As Boolean = True
        For x As Integer = 1 To iNum
            XPos += 1
            If XPos > maxX Then
                'If LineWrap = True Then
                YPos += 1
                XPos = 1
                If YPos > maxY Then
                    YPos = maxY
                    bRes = False
                    Exit For
                End If
                'Else
                '    XPos = maxX
                'End If
            End If
        Next
        Return bRes
    End Function
    Function MoveCursorBW(ByVal iNum As Integer) As Boolean
        Dim bRes As Boolean = True
        For x As Integer = 1 To iNum
            XPos -= 1
            If XPos < minX Then
                'If LineWrap = True Then
                YPos -= 1
                XPos = maxX
                If YPos < minY Then
                    YPos = minY
                    bRes = False
                    Exit For
                End If
                '  Else
                '    XPos = minX
                ' End If
            End If
        Next
        Return bRes
    End Function
    '----------------------------------------------------
    Public Function BuildParams(ByVal str As String) As String()
        Dim pcount As Integer = 0
        Dim iLp2 As Integer = 0
        Dim sWork As String = str
        Dim sCurr As String = "", bEnde2 As Boolean = False, aParams() As String
        ReDim aParams(0) : aParams(0) = 0
        If sWork.Length > 1 Then
            Do While sWork.Length > 0
                iLp2 = 0 : sCurr = "" : bEnde2 = False
                Do While bEnde2 = False And iLp2 < sWork.Length
                    '0-9 or ?
                    If (Asc(Mid(sWork, iLp2 + 1, 1)) >= 48 And Asc(Mid(sWork, iLp2 + 1, 1)) <= 57) Or Asc(Mid(sWork, iLp2 + 1, 1)) = 63 Then
                        sCurr &= CStr(Mid(sWork, iLp2 + 1, 1)) : iLp2 += 1
                    Else
                        iLp2 += 1 : bEnde2 = True
                    End If
                    If iLp2 >= Len(sWork) Then : bEnde2 = True : End If
                Loop
                If iLp2 > 0 Then : sWork = Right(sWork, sWork.Length - iLp2) : End If
                pcount += 1
                ReDim Preserve aParams(pcount)
                aParams(pcount) = sCurr
            Loop
        End If
        'System.Windows.Forms.Application.DoEvents()
        Return aParams
    End Function

End Class
