Namespace MediaFormats


    Public Module ANM
        'ANSI Animation
        'Screen 80x25
        'Each Char represented by its own SPAN with unique ID
        'ID, starting with "0" counting up in HEX up to "7CF" (1999)
        'data are stored in string arrays
        'Axx up
        'Bxx down
        'Cxx right
        'Dxx left
        'Pxy position x,y where x chars 46-125 (to represent 1-80) and y chars a-y (for 1-25)
        'Tbf change color where b = background color 0-7 and f = foreground color 0-F
        'S Save Pos
        'R Restore Pos
        'Wxx Wait xx cycles (equivalent to the "Report Position" tag thats often used in ANSI anims to cause delays
        'Zxx xx number of spaces , space is replaced by &nbsp; 
        'X.. followed by either ASCII text or unicode HTML coded content, multiple text characters can be joint in one array
        '    entry, separated by space, if they have the same attributes
        'F clear screen
        'G clear to the end of line
        'H clear to start of line
        'I clear line
        'J clear to 1/1
        'K clear to end
        'N new line
        Public Function ProcessANSIAnimationFile(ByVal sOutFile As String, ByVal aFile As Byte()) As String()
            Return ProcessANSIAnimationFile("", sOutFile, aFile)
        End Function

        Public Function ProcessANSIAnimationFile(ByVal sFile As String, ByVal sOutFile As String, Optional ByVal aFile As Byte() = Nothing) As String()
            Dim StoreX As Integer = 1, StoreY As Integer = 1
            Dim AnsiMode As Integer = 0
            Dim aAnsi As Byte() = Nothing, aPar() As String
            Dim bDrawChar As Boolean, bEnde As Boolean
            Dim CurChr As Integer, iLoop2 As Integer
            Dim sStr As String = "", sEsc As String = ""
            Dim sRes As String = ""
            LineWrap = False
            Dim aOutAnm
            ReDim aOutAnm(5000)
            Dim iCmdCnt : iCmdCnt = 0
            If Not aFile Is Nothing Then
                aAnsi = ConverterSupport.MergeByteArrays(ConverterSupport.NullByteArray, aFile)
            Else
                If IO.File.Exists(sFile) Then : aAnsi = ConverterSupport.ReadBinaryFile(sFile) : aAnsi = ConverterSupport.MergeByteArrays(ConverterSupport.NullByteArray, aAnsi) : End If
            End If

            Call ConverterSupport.BuildMappings(sCodePg)
            System.Windows.Forms.Application.DoEvents()
            ForeColor = 7 : BackColor = 0 : LineWrap = True : Blink = False : Bold = 0 : Reversed = False : LinesUsed = 0

            XPos = minX : YPos = minY
            If Not aAnsi Is Nothing Then
                If UBound(aAnsi) > 0 Then
                    iLoop = 1
                    Do While iLoop <= UBound(aAnsi)
                        If iCmdCnt > UBound(aOutAnm) - 100 Then
                            ReDim Preserve aOutAnm(UBound(aOutAnm) + 1000)
                        End If
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
                                            If bDebug = True Then Console.WriteLine("Sauce Meta found")
                                        End If
                                    End If
                                End If
                            Case 1
                                If CurChr = 91 Then  '[
                                    AnsiMode = 2 : bDrawChar = False
                                Else
                                    aOutAnm(iCmdCnt) = "X" & Hex(27) : iCmdCnt += 1
                                    bDrawChar = True : AnsiMode = 0
                                End If
                            Case 2
                                Dim aRRSize
                                aRRSize = UBound(aAnsi) : sEsc = Chr(CurChr)
                                If (CurChr >= 48 And CurChr <= 57) Or CurChr = 59 Then '0-9 or ;
                                    bEnde = False
                                    Do While bEnde = False
                                        iLoop += 1
                                        If iLoop > aRRSize Then
                                            bEnde = True
                                        Else
                                            CurChr = aAnsi(iLoop) : sEsc &= CStr(Chr(CurChr))
                                            If (CurChr >= 65 And CurChr <= 90) Or (CurChr >= 97 And CurChr <= 122) Then : bEnde = True : End If
                                        End If
                                    Loop
                                End If
                                aPar = oAnsi.BuildParams(sEsc)
                                Dim NumParams As Integer = UBound(aPar)
                                Select Case Chr(CurChr)
                                    Case "A"
                                        'Move Cursor Up
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        aOutAnm(iCmdCnt) = "A" & Right("0" & Hex(iLoop2), 2)
                                        iCmdCnt += 1
                                    Case "B"
                                        'Move Cursor Down
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        YPos = YPos + iLoop2
                                        aOutAnm(iCmdCnt) = "B" & Right("0" & Hex(iLoop2), 2)
                                        iCmdCnt += 1
                                    Case "C"
                                        'Move Cursor Right
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        aOutAnm(iCmdCnt) = "C" & Right("0" & Hex(iLoop2), 2)
                                        iCmdCnt += 1
                                    Case "D"
                                        'Move Cursor left
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : If iLoop2 = 0 Then : iLoop2 = 1 : End If
                                        Else
                                            iLoop2 = 1
                                        End If
                                        aOutAnm(iCmdCnt) = "D" & Right("0" & Hex(iLoop2), 2)
                                        iCmdCnt += 1
                                    Case "H" 'Move Cursor
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : YPos = IIf(iLoop2 > 0, minY + (iLoop2 - 1), minY)
                                        Else
                                            YPos = minY
                                        End If
                                        If NumParams > 1 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(2)) : XPos = IIf(iLoop2 > 0, minX + (iLoop2 - 1), minX)
                                        Else
                                            XPos = minX
                                        End If
                                        aOutAnm(iCmdCnt) = "P" & escapchr(Chr(XPos + 45)) & escapchr(Chr(YPos + 96))
                                        iCmdCnt += 1
                                    Case "f" 'Move Cursor
                                        If NumParams > 0 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(1)) : YPos = IIf(iLoop2 > 0, minY + (iLoop2 - 1), minY)
                                        Else
                                            YPos = minY
                                        End If
                                        If NumParams > 1 Then
                                            iLoop2 = ConverterSupport.ChkNum(aPar(2)) : XPos = IIf(iLoop2 > 0, minX + (iLoop2 - 1), minX)
                                        Else
                                            XPos = minX
                                        End If
                                        aOutAnm(iCmdCnt) = "P" & escapchr(Chr(XPos + 45)) & escapchr(Chr(YPos + 96))
                                        iCmdCnt += 1
                                    Case "J"
                                        'ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False
                                        If NumParams > 0 Then
                                            Select Case ConverterSupport.ChkNum(aPar(1))
                                                Case 0 'erase from cursor to end of screen
                                                    aOutAnm(iCmdCnt) = "K"
                                                    iCmdCnt += 1
                                                Case 1 'Erase from beginning of screen to cursor
                                                    aOutAnm(iCmdCnt) = "J"
                                                    iCmdCnt += 1
                                                Case 2 'Clear screen and home cursor
                                                    aOutAnm(iCmdCnt) = "F"
                                                    iCmdCnt += 1
                                            End Select
                                        Else 'Erase from cursor to end of screen
                                            aOutAnm(iCmdCnt) = "K"
                                            iCmdCnt += 1
                                        End If


                                    Case "m" 'Set Attribute
                                        If NumParams = 0 Then : ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False : aOutAnm(iCmdCnt) = "T07" : iCmdCnt += 1 : aOutAnm(iCmdCnt) = "L0" : iCmdCnt += 1 : End If
                                        For iLoop3 = 1 To NumParams
                                            Dim i2
                                            iLoop2 = ConverterSupport.ChkNum(aPar(iLoop3))
                                            Select Case iLoop2
                                                Case 0
                                                    If CStr(Left(aPar(iLoop3), 1)) = "0" Then
                                                        ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False
                                                        aOutAnm(iCmdCnt) = "T07" : iCmdCnt += 1 : aOutAnm(iCmdCnt) = "L0" : iCmdCnt += 1
                                                    End If
                                                Case 1 : Bold = 8 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 2 : Bold = 0 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 5 : Blink = True : aOutAnm(iCmdCnt) = "L1" : iCmdCnt += 1
                                                Case 7 : i2 = ForeColor : ForeColor = BackColor : BackColor = i2 : Reversed = True : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 22 : Bold = 0 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 25 : Blink = False : aOutAnm(iCmdCnt) = "L0" : iCmdCnt += 1
                                                Case 27 : i2 = ForeColor : ForeColor = BackColor : BackColor = i2 : Reversed = False : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 30 : ForeColor = 0 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 31 : ForeColor = 4 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 32 : ForeColor = 2 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 33 : ForeColor = 6 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 34 : ForeColor = 1 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 35 : ForeColor = 5 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 36 : ForeColor = 3 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 37 : ForeColor = 7 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 40 : BackColor = 0 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 41 : BackColor = 4 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 42 : BackColor = 2 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 43 : BackColor = 6 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 44 : BackColor = 1 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 45 : BackColor = 5 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 46 : BackColor = 3 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                                Case 47 : BackColor = 7 : aOutAnm(iCmdCnt) = "T" & Hex(BackColor) & Hex(ForeColor + Bold) : iCmdCnt += 1
                                            End Select
                                        Next
                                    Case "K"
                                        If NumParams > 0 Then
                                            Select Case ConverterSupport.ChkNum(aPar(1))
                                                Case 0
                                                    'clear to the end of the line
                                                    aOutAnm(iCmdCnt) = "G" : iCmdCnt += 1
                                                Case 1
                                                    'Erase from beginning of line to cursor
                                                    aOutAnm(iCmdCnt) = "H" : iCmdCnt += 1
                                                Case 2
                                                    'Erase line containing the cursor
                                                    aOutAnm(iCmdCnt) = "I" : iCmdCnt += 1
                                            End Select
                                        Else
                                            'clear to the end of the line
                                            aOutAnm(iCmdCnt) = "G" : iCmdCnt += 1
                                        End If
                                    Case "s"     'save cursor position
                                        aOutAnm(iCmdCnt) = "S" : iCmdCnt += 1
                                    Case "u" 'Restore Position
                                        aOutAnm(iCmdCnt) = "R" : iCmdCnt += 1
                                    Case "n" 'Report Cursor Position
                                        aOutAnm(iCmdCnt) = "W01" : iCmdCnt += 1
                                    Case "h" 'Set Display Mode
                                        '<[=Xh   X = Mode, 7 = Turn ON linewrap

                                    Case "l" 'Set Display Mode
                                        '<[=7l  = Truncate Lines longer than 80 chars
                                    Case Else

                                        Console.WriteLine("Unknown ANSI Command: " & Chr(CurChr) & " (" & CurChr.ToString & ") Params: " & Join(aPar, "|").ToString & ",File: " & sFile & ", Pos: " & iLoop.ToString)
                                End Select
                                bDrawChar = False : AnsiMode = 0
                        End Select

                        If bDrawChar = True And AnsiMode = 0 Then
                            Select Case CurChr
                                Case 10
                                    aOutAnm(iCmdCnt) = "N" : iCmdCnt += 1
                                Case 13 ' restore X in linefeed so's to support *nix type files
                                    ' XPos = 1
                                Case 32
                                    aOutAnm(iCmdCnt) = "Z01" : iCmdCnt += 1
                                Case 26 'ignore
                                Case Else
                                    ' If CurChr >= 1 Then
                                    aOutAnm(iCmdCnt) = "X" & Hex(CurChr) : iCmdCnt += 1
                                    'End If
                            End Select
                        End If
                        iLoop += 1
                        If iLoop / 1000 = CInt(iLoop / 1000) Then System.Windows.Forms.Application.DoEvents()
                    Loop
                End If
            End If

            Dim SubBlock As String = "F", SubCnt As Integer = 1
            Dim aTmp As String(), sPrevCmd As String, ExecCnt As Integer, sCurCmd As String = "", iNewPos As Integer = 0, sCombStr As String = ""

            If iCmdCnt > 0 Then
                ReDim aTmp(iCmdCnt - 1)
                sPrevCmd = "" : ExecCnt = 0
                For iLoop2 = 0 To iCmdCnt - 1
                    sCurCmd = Microsoft.VisualBasic.Left(aOutAnm(iLoop2), 1)
                    If sPrevCmd <> sCurCmd Then
                        If sPrevCmd <> "" Then
                            Select Case sPrevCmd
                                'Case "P" : SubBlock &= " " & sCombStr : SubCnt += 1
                                Case "T" : SubBlock &= " " & sCombStr : SubCnt += 1
                                Case "S"
                                    If ExecCnt > 1 Then
                                        SubBlock &= " S" : SubCnt += 1
                                        SubBlock &= " W" & Right("0" & Hex(ExecCnt - 1), 2) : SubCnt += 1
                                    Else
                                        SubBlock &= " S" : SubCnt += 1
                                    End If
                                Case "R"
                                    If ExecCnt > 1 Then
                                        SubBlock &= " R" : SubCnt += 1
                                        SubBlock &= " W" & Right("0" & Hex(ExecCnt - 1), 2) : SubCnt += 1
                                    Else
                                        SubBlock &= " R" : SubCnt += 1
                                    End If
                                Case "W" : SubBlock &= " W" & Right("0" & Hex(ExecCnt), 2) : SubCnt += 1
                                Case "Z" : SubBlock &= " Z" & Right("0" & Hex(ExecCnt), 2) : SubCnt += 1
                                Case "X" : SubBlock &= IIf(ExecCnt > 1, " x" & sCombStr, " X" & sCombStr) : SubCnt += 1
                                Case Else
                                    'shouldn't be here
                            End Select
                            If SubCnt > 1000 Then
                                aTmp(iNewPos) = Trim(SubBlock) : iNewPos += 1
                                SubCnt = 0 : SubBlock = ""
                            End If
                        End If
                        sCombStr = ""
                        ExecCnt = 1
                        Select Case sCurCmd
                            'Case "P" : sCombStr = aOutAnm(iLoop2) : sPrevCmd = sCurCmd
                            Case "T" : sCombStr = aOutAnm(iLoop2) : sPrevCmd = sCurCmd
                            Case "S" : ExecCnt = 1 : sPrevCmd = sCurCmd
                            Case "R" : ExecCnt = 1 : sPrevCmd = sCurCmd
                            Case "W" : ExecCnt = 1 : sPrevCmd = sCurCmd
                            Case "Z" : ExecCnt = 1 : sPrevCmd = sCurCmd
                            Case "X" : sCombStr = Right(aOutAnm(iLoop2), aOutAnm(iLoop2).ToString.Length - 1) : ExecCnt = 1 : sPrevCmd = sCurCmd
                            Case Else
                                SubBlock &= " " & aOutAnm(iLoop2) : SubCnt += 1 : sPrevCmd = ""
                        End Select
                    Else
                        Select Case sCurCmd
                            'Case "P" : sCombStr = aOutAnm(iLoop2)
                            Case "T" : sCombStr = aOutAnm(iLoop2)
                            Case "S" : ExecCnt += 1
                            Case "R" : ExecCnt += 1
                            Case "W" : ExecCnt += 1
                            Case "Z" : ExecCnt += 1
                            Case "X" : sCombStr &= ";" & Right(aOutAnm(iLoop2), aOutAnm(iLoop2).ToString.Length - 1) : ExecCnt += 1
                        End Select
                    End If
                Next
                If sPrevCmd <> "" Then
                    Select Case sPrevCmd
                        'Case "P" : SubBlock &= " " & sCombStr : SubCnt += 1
                        Case "T" : SubBlock &= " " & sCombStr : SubCnt += 1
                        Case "S"
                            If ExecCnt > 1 Then
                                SubBlock &= " S" : SubCnt += 1
                                SubBlock &= " W" & Right("0" & Hex(ExecCnt - 1), 2) : SubCnt += 1
                            Else
                                SubBlock &= " S" : SubCnt += 1
                            End If
                        Case "R"
                            If ExecCnt > 1 Then
                                SubBlock &= " R" : SubCnt += 1
                                SubBlock &= " W" & Right("0" & Hex(ExecCnt - 1), 2) : SubCnt += 1
                            Else
                                SubBlock &= " R" : SubCnt += 1
                            End If
                        Case "W" : SubBlock &= " W" & Right("0" & Hex(ExecCnt), 2) : SubCnt += 1
                        Case "Z" : SubBlock &= " Z" & Right("0" & Hex(ExecCnt), 2) : SubCnt += 1
                        Case "X" : SubBlock &= IIf(ExecCnt > 1, " x" & sCombStr, " X" & sCombStr) : SubCnt += 1
                        Case Else
                            'shouldn't be here
                            Console.WriteLine("shouldn't be here. sPrevCmd='" & sPrevCmd & "'")
                    End Select

                    aTmp(iNewPos) = Trim(SubBlock) : iNewPos += 1
                    SubCnt = 0 : SubBlock = ""
                End If
                If SubCnt > 0 Then
                    aTmp(iNewPos) = Trim(SubBlock) : iNewPos += 1
                    SubCnt = 0 : SubBlock = ""
                End If
                ReDim Preserve aTmp(iNewPos - 1)
                sRes = Join(aTmp, ",")
                sRes = "var aAnim" & ProcFilesCounter & "=[""" & Replace(sRes, ",", """,""", 1, -1, CompareMethod.Text) & """];"
            End If
            Dim sOut As String = ""
            If bHTMLComplete = True Then
                sOut &= "<html><head>" & vbCrLf
                sOut &= ConverterSupport.BuildCSSforHTML()
                sOut &= "</head><body>" & vbCrLf
            End If

            sOut &= "<div class=ANSICSS id=""anm" & ProcFilesCounter & """><pre>" & vbCrLf
            iLoop = 0
            For a = 1 To 25
                For b = minX To maxX
                    sOut &= "<span class=""II"" id=""" & Hex(iLoop) & """>&nbsp;</span>"
                    iLoop += 1
                Next
                sOut &= vbCrLf
            Next
            sOut &= vbCrLf & "</pre></div>" & vbCrLf

            sOut &= "<script language=""Javascript"">" & vbCrLf

            Dim sJS As String '= ByteArrayToString(My.Resources.ANSIJS)
            sJS = ConverterSupport.ByteArrayToStr(My.Resources.ANSIJS, FFormats.us_ascii)
            'sJS = ByteArrayToStr(My.Resources.ANSIJS2, FFormats.us_ascii)

            sJS = ConverterSupport.CutorSandR(sJS, "//VARDEFSTART", "//VARDEFEND", "I", "I", "C", 1)
            sJS = ConverterSupport.CutorSandR(sJS, "//CALLSTART", "//CALLEND", "I", "I", "C", 1)

            sJS = Replace(sJS, "//AANIMVAR", sRes, 1, 1, CompareMethod.Text)

            Dim sMap As String = ""
            sMap &= "var aMappings" & ProcFilesCounter & "=["
            For a = 0 To 255
                sMap &= """" & HTMLUniEncode(a) & """"
                If a < 255 Then : sMap &= "," : End If
            Next
            sMap &= "];" & vbCrLf
            sJS = Replace(sJS, "//AMAPPINGSVAR", sMap, 1, 1, CompareMethod.Text)

            Dim sFN As String = "StartAnsiAnimation('anm" & ProcFilesCounter & "',aAnim" & ProcFilesCounter & ",aMappings" & ProcFilesCounter & ");" & vbCrLf
            sJS = Replace(sJS, "//CALLPLACEHOLDER", sFN, 1, 1, CompareMethod.Text)

            sOut &= sJS
            sOut &= "</script>" & vbCrLf

            If bHTMLComplete = True Then : sOut &= "</body></html>" : End If

            Return ConverterSupport.WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

        End Function
        Function escapchr(ByVal sChar As String) As String
            If sChar = "\" Then
                Return sChar & sChar
            Else
                Return sChar
            End If
        End Function
        Function HTMLUniEncode(ByVal iChr As Integer) As String
            If Internal.aSpecH(iChr) <> "" Then
                Return Internal.aSpecH(iChr)
            Else
                If Int(Internal.aUniCode(iChr)) <> Int(iChr) Or iChr = 44 Then
                    Return "&#" & Internal.aUniCode(iChr) & ";"
                Else
                    If iChr = 92 Then
                        Return Chr(iChr) & Chr(iChr)
                    Else
                        If iChr >= 0 And iChr <= 32 Then
                            Return "&#" & CStr(9216 + iChr) & ";"
                        Else
                            Return Chr(iChr)
                        End If
                    End If
                End If
            End If
        End Function
    End Module
End Namespace