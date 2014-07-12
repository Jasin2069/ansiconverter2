Namespace MediaFormats


    Public Module WC2
        Public Sub ProcessWC2File(ByVal aFile As Byte())
            Call ProcessWC2File("", aFile)
        End Sub

        Public Sub ProcessWC2File(ByVal sFile As String, Optional ByVal aFile As Byte() = Nothing)

            Dim aAnsi As Byte() = Nothing
            Dim AnsiMode As Integer = 0
            Dim bDrawChar As Boolean
            Dim CurChr As Integer, iLoop2 As Integer
            Dim sStr As String = ""
            Dim aRRSize As Integer
            Dim sEsc As String
            Dim bEnde As Boolean
            Dim aPar() As String
            If Not aFile Is Nothing Then
                aAnsi = ConverterSupport.MergeByteArrays(ConverterSupport.NullByteArray, aFile)
            Else
                If IO.File.Exists(sFile) Then : aAnsi = ConverterSupport.ReadBinaryFile(sFile) : aAnsi = ConverterSupport.MergeByteArrays(ConverterSupport.NullByteArray, aAnsi) : End If
            End If

            Call ConverterSupport.BuildMappings(sCodePg)

            ForeColor = 7 : BackColor = 0 : LineWrap = True : Blink = False : Bold = 0 : Reversed = False : LinesUsed = 0
            ReDim Screen(maxX, maxY)
            For x As Integer = minX To maxX
                For Y As Integer = minY To maxY
                    Screen(x, Y) = New ConverterSupport.ScreenChar(x)
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
                                    If ConverterSupport.SetChar(Chr(27)) = False Then
                                        iLoop = UBound(aAnsi) + 1
                                    Else
                                        bDrawChar = True : AnsiMode = 0
                                    End If
                                End If
                            Case 2


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
                                    If bDebug Then : Console.WriteLine("." & sEsc & ".") : End If
                                    aPar = BuildParams(sEsc)
                                    Dim NumParams As Integer = UBound(aPar)
                                    If Chr(CurChr) = "m" And NumParams = 3 Then
                                        Dim iPar1 As Integer, iPar2 As Integer, iPar3 As Integer
                                        iPar1 = CInt(aPar(1))
                                        iPar2 = CInt(aPar(2))
                                        iPar3 = CInt(aPar(3))
                                        If iPar1 = 0 And iPar2 = 0 And iPar3 = 40 Then
                                            ForeColor = 7 : BackColor = 0 : Blink = False : Bold = 0 : Reversed = False
                                        Else
                                            If iPar1 = 1 Then : Bold = 8 : Else : Bold = 0 : End If
                                            Select Case iPar2
                                                Case 30 : ForeColor = 0
                                                Case 31 : ForeColor = 4
                                                Case 32 : ForeColor = 2
                                                Case 33 : ForeColor = 6
                                                Case 34 : ForeColor = 1
                                                Case 35 : ForeColor = 5
                                                Case 36 : ForeColor = 3
                                                Case 37 : ForeColor = 7
                                            End Select
                                            Select Case iPar3
                                                Case 40 : BackColor = 0
                                                Case 41 : BackColor = 4
                                                Case 42 : BackColor = 2
                                                Case 43 : BackColor = 6
                                                Case 44 : BackColor = 1
                                                Case 45 : BackColor = 5
                                                Case 46 : BackColor = 3
                                                Case 47 : BackColor = 7
                                            End Select
                                        End If
                                    Else
                                        If bDebug Then : Console.WriteLine("Unsupported WildCat 2.X Command: " & Chr(CurChr) & " or invalid number of parameters: " & NumParams.ToString) : End If
                                    End If
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
                                    If YPos > LinesUsed Then : LinesUsed = YPos : End If
                                Case 13 ' restore X in linefeed so's to support *nix type files
                                Case 26 'ignore
                                Case Else : If ConverterSupport.SetChar(Chr(CurChr)) = False Then : iLoop = UBound(aAnsi) + 1 : End If
                            End Select
                        End If
                        iLoop += 1
                        If iLoop / 1000 = CInt(iLoop / 1000) Then System.Windows.Forms.Application.DoEvents()
                    Loop
                End If
            End If
        End Sub

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
    End Module
End Namespace