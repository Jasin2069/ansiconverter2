Namespace MediaFormats


    Public Module BIN
        Public Sub ProcessBINFile(ByVal aFile As Byte())
            Call ProcessBINFile("", aFile)
        End Sub

        Public Sub ProcessBINFile(ByVal sFile As String, Optional ByVal aFile As Byte() = Nothing)

            Dim aAnsi As Byte() = Nothing
            Dim bDrawChar As Boolean
            Dim CurChr As Integer, iLoop2 As Integer
            Dim sStr As String = ""

            Dim sCol As String = ""
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
                        If bDrawChar = True Then
                            If UBound(aAnsi) >= iLoop + 1 Then
                                sStr = CurChr
                                iLoop += 1
                                CurChr = CInt(aAnsi(iLoop))
                                sCol = Right("0" & Hex(CurChr), 2)
                                ForeColor = ConverterSupport.HexToDec(Right(sCol, 1))
                                BackColor = ConverterSupport.HexToDec(Left(sCol, 1))
                                If ForeColor > 7 Then : Bold = 8 : ForeColor -= 8 : Else : Bold = 0 : End If
                                CurChr = sStr
                                If CurChr = 0 Then
                                    If Not ConverterSupport.SetChar(" ") Then
                                        iLoop = UBound(aAnsi) + 1
                                    End If
                                    bDrawChar = False
                                End If
                            End If
                        End If

                        If bDrawChar = True Then
                            If ConverterSupport.SetChar(Chr(CurChr)) = False Then : iLoop = UBound(aAnsi) + 1 : End If
                        End If
                        iLoop += 1
                        If iLoop / 1000 = CInt(iLoop / 1000) Then System.Windows.Forms.Application.DoEvents()
                    Loop
                End If
            End If
        End Sub
    End Module
End Namespace