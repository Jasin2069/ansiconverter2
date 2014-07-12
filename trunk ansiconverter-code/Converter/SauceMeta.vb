Namespace ConverterSupport


    Public Class SauceMeta
        <VBFixedString(5)> Public ID As String  '5 Bytes 'SAUCE'                   0
        Public Version(1) As Byte     '2 Bytes 00 00                               5
        <VBFixedString(35)> Public Title As String     '35 Bytes                   7
        <VBFixedString(20)> Public Author As String     '20 Bytes                 42
        <VBFixedString(20)> Public Group As String      '20 Bytes                 62
        <VBFixedString(8)> Public CreatedDate As String '8 Bytes CCYYMMDD         82
        Public FileSize As Integer   '4 Bytes (Long) (-2147483648 to -2147483647) 90
        Public DataType As Byte   '1 Byte                                         94 
        Public FileType As Byte   '1 Byte                                         95
        Public TInfo1 As Int16    '2 Bytes (Word) (0 to 65535)                    96
        Public TInfo2 As Int16     '2 Bytes (Word)                                98
        Public TInfo3 As Int16     '2 Bytes (Word)                               100
        Public TInfo4 As Int16     '2 Bytes (Word)                               102 
        Public Comments As Byte   '1 Byte                                        104
        Public Flags As Byte      '1 Byte                                        105
        Public Filler(21) As Byte      '22 Bytes   all 00                        106 
        '--- Total 128 bytes
        'Comments Optional started with 'COMNT' (5 bytes), followed by (Comments (=Num Comments) * 64 bytes) with the actual comments itself
        Public aComments() As String 'Note, Dimension 0 isn't used, only "1" to "Comments", length fixed = 64 bytes
        Private iError As Integer = 0

        Public Event SauceParseError(ByRef sender As Object, ByVal e As EventArgs)

        Public ReadOnly Property ErrorStatus() As Integer
            Get
                Return iError
            End Get
        End Property
        Public ReadOnly Property DataTypeName() As String
            Get
                If DataType >= 0 And DataType <= 8 Then
                    Return aDT(DataType)
                Else
                    Return "n/a"
                End If
            End Get
        End Property
        Public ReadOnly Property FileTypeName() As String
            Get
                If DataType >= 0 And DataType <= 8 Then
                    If FileType >= 0 And FileType <= UBound(aFT(DataType)) Then
                        Return aFT(DataType)(FileType)
                    Else
                        Return "n/a"
                    End If
                Else
                    Return "n/a"
                End If
            End Get
        End Property


        Private aDT() As String = New String() {"None", "Character (ANSI, ASCII, RIP)", "Graphics", "Vector", "Sound", "Binary Text", "XBIN", "Archive", "Executable"}
        Private aFT() As Object = New Object() { _
                                  New String() {""}, _
                                  New String() {"ASCII", "ANSI", "ANSIMation", "RIP", "PcBoard", "AVATAR", "HTML", "SOURCE"}, _
                                  New String() {"Gif", "PCX", "LBM/IFF", "TGA", "FLI", "FLC", "BMP", "GL", "DL", "WPG", "PNG ", "JPG", "MPG", "AVI"}, _
                                  New String() {"DXF", "DWG", "WPG", "3DS"}, _
                                  New String() {"MOD (4, 6 or 8 channel MOD/NST file) ", "669 (Renaissance 8 channel 669 format) ", "STM (Future Crew 4 channel ScreamTracker format) ", _
                                                "S3M (Future Crew variable channel ScreamTracker3 format) ", "MTM (Renaissance variable channel MultiTracker Module) ", "FAR (Farandole composer module) ", _
                                                "ULT (UltraTracker module) ", "AMF (DMP/DSMI Advanced Module Format) ", "DMF (Delusion Digital Music Format (XTracker)) ", "OKT (Oktalyser module) ", _
                                                "ROL (AdLib ROL file (FM)) ", "CMF (Creative Labs FM) ", "MIDI (MIDI file) ", "SADT (SAdT composer FM Module) ", "VOC (Creative Labs Sample) ", _
                                                "WAV (Windows Wave file) ", "SMP8 (8 Bit Sample, TInfo1 holds sampling rate) ", "SMP8S (8 Bit sample stereo, TInfo1 holds sampling rate) ", _
                                                "SMP16 (16 Bit sample, TInfo1 holds sampling rate) ", "SMP16S (16 Bit sample stereo, TInfo1 holds sampling rate) ", "PATCH8 (8 Bit patch-file) ", _
                                                "PATCH16(16 Bit Patch-file) ", "XM (FastTracker ][ Module) ", "HSC (HSC Module) ", "IT (Impulse Tracker) "}, _
                                  New String() {""}, _
                                  New String() {""}, _
                                  New String() {"ZIP (PKWare)", "ARJ (Robert K. Jung)", "LZH (Haruyasu Yoshizaki (Yoshi))", "ARC (SEA)", "TAR (Unix TAR format)", "ZOO", "RAR", "UC2", "PAK", "SQZ"}, _
                                  New String() {""} _
                                  }
        Private inArrPos As Integer = 0
        'DateTypes
        '0 None
        '  FileTypes
        '  -
        '1 Character (ANSI, ASCII, RIP)
        '  FileTypes
        '  0 ASCII
        '    TInfo1 = Width
        '    TInfo2 = Num Lines
        '  1 ANSI
        '    TInfo1 = Width
        '    TInfo2 = Num Lines
        '  2 ANSIMation
        '    TInfo1 = Width
        '    TInfo2 = Num Lines
        '  3 RIP
        '    TInfo1 = Width
        '    TInfo2 = Height
        '    TInfo3 = Num Colors
        '  4 PcBoard
        '    TInfo1 = Width
        '    TInfo2 = Num Lines
        '  5 AVATAR
        '    TInfo1 = Width
        '    TInfo2 = Num Lines
        '  6 HTML
        '  7 SOURCE
        '
        '  Flag
        '    ICe Color, No Blinking and 16 back and fore colors
        '    Bit  7 6 5 4 3 2 1 0
        '    Set  0 0 0 0 0 0 0 X
        '
        '2 Graphics
        '  TInfo1 = Width
        '  TInfo2 = Height
        '  TInfo3 = Bits Per Pixel
        '
        '  FileTypes
        '  0 Gif
        '  1 PCX
        '  2 LBM/IFF
        '  3 TGA
        '  4 FLI
        '  5 FLC
        '  6 BMP
        '  7 GL
        '  8 DL
        '  9 WPG
        ' 10 PNG 
        ' 11 JPG
        ' 12 MPG
        ' 13 AVI
        '
        '3 Vector
        '
        '  FileTypes
        '  0 DXF
        '  1 DWG
        '  2 WPG
        '  3 3DS
        '
        '4 Sound
        '  FileTypes
        '   0) MOD (4, 6 or 8 channel MOD/NST file) 
        '   1) 669 (Renaissance 8 channel 669 format) 
        '   2) STM (Future Crew 4 channel ScreamTracker format) 
        '   3) S3M (Future Crew variable channel ScreamTracker3 format) 
        '   4) MTM (Renaissance variable channel MultiTracker Module) 
        '   5) FAR (Farandole composer module) 
        '   6) ULT (UltraTracker module) 
        '   7) AMF (DMP/DSMI Advanced Module Format) 
        '   8) DMF (Delusion Digital Music Format (XTracker)) 
        '   9) OKT (Oktalyser module) 
        '   10) ROL (AdLib ROL file (FM)) 
        '   11) CMF (Creative Labs FM) 
        '   12) MIDI (MIDI file) 
        '   13) SADT (SAdT composer FM Module) 
        '   14) VOC (Creative Labs Sample) 
        '   15) WAV (Windows Wave file) 
        '   16) SMP8 (8 Bit Sample, TInfo1 holds sampling rate) 
        '   17) SMP8S (8 Bit sample stereo, TInfo1 holds sampling rate) 
        '   18) SMP16 (16 Bit sample, TInfo1 holds sampling rate) 
        '   19) SMP16S (16 Bit sample stereo, TInfo1 holds sampling rate) 
        '   20) PATCH8 (8 Bit patch-file) 
        '   21) PATCH16(16 Bit Patch-file) 
        '   22) XM (FastTracker ][ Module) 
        '   23) HSC (HSC Module) 
        '   24) IT (Impulse Tracker) 
        '   
        '
        '5 Binary Text
        '  Flag
        '    ICe Color, No Blinking and 16 back and fore colors
        '    Bit  7 6 5 4 3 2 1 0
        '    Set  0 0 0 0 0 0 0 X    
        '
        '6 XBIN
        '  TInfo1  = Width
        '  TInfo2 = Height
        '
        '7 Archive
        '  FileTypes
        '  0) ZIP (PKWare) 
        '  1) ARJ (Robert K. Jung) 
        '  2) LZH (Haruyasu Yoshizaki (Yoshi)) 
        '  3) ARC (SEA) 
        '  4) TAR (Unix TAR format) 
        '  5) ZOO 
        '  6) RAR 
        '  7) UC2 
        '  8) PAK 
        '  9) SQZ 
        '
        '
        '8 Executable

        Public Sub New()
            ID = "SAUCE"
            Title = ""
            Author = ""
            Group = ""
            CreatedDate = "19000101"
            FileSize = 0
            DataType = 0
            FileType = 0
            TInfo1 = 0
            TInfo2 = 0
            TInfo3 = 0
            TInfo4 = 0
            Comments = 0
            Flags = 0
            iError = 0
            inArrPos = 0
            'Filler = Replace(Space(22), " ", "00", 1, -1, 1)
            ReDim aComments(0)
        End Sub

        Public Sub SetComments(ByVal iNum As Integer)
            Dim xxx As Integer
            ReDim aComments(iNum)
            For xxx = 0 To iNum
                aComments(xxx) = ""
            Next
            Comments = iNum
            System.Windows.Forms.Application.DoEvents()
        End Sub
        Public Sub AddComment(ByVal sComment As String)
            Comments += 1
            ReDim Preserve aComments(Comments)
            If sComment.Length > 64 Then
                aComments(Comments) = Strings.Left(sComment, 64)
            Else
                aComments(Comments) = sComment
            End If
        End Sub
        Public Overrides Function toString() As String
            Dim sRes As String = ""
            sRes &= Chr(26) & Me.ID
            sRes &= Me.ByteArrayToString(Me.Version, Chr(48))
            sRes &= Strings.Left(Me.Title & Space(35), 35)
            sRes &= Strings.Left(Me.Author & Space(20), 20)
            sRes &= Strings.Left(Me.Group & Space(20), 20)
            sRes &= Strings.Left(Me.CreatedDate & Space(8), 8)
            sRes &= Me.ByteArrayToString(Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("0000" & Hex(Me.FileSize), 4))))
            sRes &= Chr(Me.DataType)
            sRes &= Chr(Me.FileType)
            sRes &= Me.ByteArrayToString(Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("00" & Hex(Me.TInfo1), 2))))
            sRes &= Me.ByteArrayToString(Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("00" & Hex(Me.TInfo2), 2))))
            sRes &= Me.ByteArrayToString(Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("00" & Hex(Me.TInfo3), 2))))
            sRes &= Me.ByteArrayToString(Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("00" & Hex(Me.TInfo4), 2))))
            sRes &= Chr(Me.Comments)
            sRes &= Chr(Me.Flags)
            sRes &= Me.ByteArrayToString(Me.Filler)
            If Me.Comments > 0 Then
                sRes &= "COMNT"
                For x As Integer = 0 To UBound(Me.aComments)
                    sRes &= Strings.Left(Me.aComments(x) & Space(64), 64)
                Next
            End If
            System.Windows.Forms.Application.DoEvents()
            Return sRes

        End Function
        Public Function AppendToByteArray(ByVal bte As Byte()) As Byte()
            Dim bSauce As Byte() = Me.toByteArray
            Return Me.MergeByteArrays(bte, bSauce)
        End Function

        Public Function toByteArray() As Byte()
            Dim bte() As Byte = New Byte() {0}
            If Me.Comments > 0 Then
                ReDim bte(127 + (Me.Comments * 64) + 5 + 1)
            Else
                ReDim bte(127 + 1)
            End If
            bte = New Byte() {26}
            bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.ID))
            bte = Me.MergeByteArrays(bte, Me.Version)
            bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.Title, 35))
            bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.Author, 20))
            bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.Group, 20))
            bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.CreatedDate, 8))
            bte = Me.MergeByteArrays(bte, Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("00000000" & Hex(Me.FileSize), 8))))
            bte = Me.MergeByteArrays(bte, New Byte() {Me.DataType})
            bte = Me.MergeByteArrays(bte, New Byte() {Me.FileType})
            bte = Me.MergeByteArrays(bte, Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("0000" & Hex(Me.TInfo1), 4))))
            bte = Me.MergeByteArrays(bte, Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("0000" & Hex(Me.TInfo2), 4))))
            bte = Me.MergeByteArrays(bte, Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("0000" & Hex(Me.TInfo3), 4))))
            bte = Me.MergeByteArrays(bte, Me.HexStringToByteArray(Me.FlipHexVal(Strings.Right("0000" & Hex(Me.TInfo4), 4))))
            bte = Me.MergeByteArrays(bte, New Byte() {Me.Comments})
            bte = Me.MergeByteArrays(bte, New Byte() {Me.Flags})
            bte = Me.MergeByteArrays(bte, Me.Filler)
            If Me.Comments > 0 Then
                bte = Me.MergeByteArrays(bte, Me.StringToBytearray("COMNT"))
                For x As Integer = 0 To UBound(Me.aComments)
                    bte = Me.MergeByteArrays(bte, Me.StringToBytearray(Me.aComments(x), 64))
                Next
            End If
            System.Windows.Forms.Application.DoEvents()
            Return bte
        End Function

        Public Function GetFromByteArray(ByVal aArray As Byte(), ByVal Offset As Integer) As Integer
            Dim sStr As String = ""
            inArrPos = Offset
            iError = 0
            If UBound(aArray) >= Offset + 128 - 1 Then
                Try

                    Me.ID = Me.ReadByteArray(aArray, 5, "s", Offset)
                    Me.Version(0) = Me.ReadByteArray(aArray, 1, "b", Offset)
                    Me.Version(1) = Me.ReadByteArray(aArray, 1, "b", Offset)
                    Me.Title = Me.ReadByteArray(aArray, 35, "s", Offset)
                    Me.Author = Me.ReadByteArray(aArray, 20, "s", Offset)
                    Me.Group = Me.ReadByteArray(aArray, 20, "s", Offset)
                    Me.CreatedDate = Me.ReadByteArray(aArray, 8, "s", Offset)
                    Me.FileSize = Me.Hex2Int64(Me.FlipHexVal(Me.ReadByteArray(aArray, 4, "h", Offset)))
                    Me.DataType = CInt(Me.ReadByteArray(aArray, 1, "b", Offset))
                    Me.FileType = CInt(Me.ReadByteArray(aArray, 1, "b", Offset))
                    Me.TInfo1 = Me.Hex2Int64(Me.FlipHexVal(Me.ReadByteArray(aArray, 2, "h", Offset)))
                    Me.TInfo2 = Me.Hex2Int64(Me.FlipHexVal(Me.ReadByteArray(aArray, 2, "h", Offset)))
                    Me.TInfo3 = Me.Hex2Int64(Me.FlipHexVal(Me.ReadByteArray(aArray, 2, "h", Offset)))
                    Me.TInfo4 = Me.Hex2Int64(Me.FlipHexVal(Me.ReadByteArray(aArray, 2, "h", Offset)))
                    Me.Comments = CInt(Me.ReadByteArray(aArray, 1, "b", Offset))
                    Me.Flags = CInt(Me.ReadByteArray(aArray, 1, "b", Offset))
                    For x As Integer = 0 To 21
                        Me.Filler(x) = Me.ReadByteArray(aArray, 1, "b", Offset)
                    Next
                    If UBound(aArray) >= Offset + (Me.Comments * 64) + 5 Then
                        If Me.Comments <> 0 Then
                            sStr = Me.ReadByteArray(aArray, 5, "s", Offset)
                            If sStr = "COMNT" Then
                                Me.SetComments(CInt(Me.Comments))
                                For iLoop2 As Integer = 1 To Me.Comments
                                    Me.aComments(iLoop2) = Me.ReadByteArray(aArray, 64, "s", Offset)
                                Next
                            End If
                        End If
                    End If

                Catch ex As Exception
                    iError = 1
                    RaiseEvent SauceParseError(Me, EventArgs.Empty)
                    Offset = inArrPos
                End Try
            End If
            System.Windows.Forms.Application.DoEvents()
            Return Offset
        End Function
        Public Sub AddToFile(ByVal sFile As String)
            If IO.File.Exists(sFile) Then
                Dim ofile As System.IO.FileStream
                Dim iSize As Integer = 0
                Dim bte As Byte() = Me.toByteArray
                ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.ReadWrite)
                ofile.Seek(0, IO.SeekOrigin.Begin)
                iSize = ofile.Length
                ofile.Seek(0, IO.SeekOrigin.End)
                Dim iNewSize = iSize + bte.Length
                ofile.SetLength(iNewSize)
                ofile.Write(bte, 0, bte.Length)
                ofile.Close()
            End If
        End Sub
        Public Function RemoveFromFile(ByVal sFile As String) As Boolean
            Dim bRemoved As Boolean = False
            If IO.File.Exists(sFile) Then
                Dim ofile As System.IO.FileStream
                Dim iSize As Integer = 0
                Dim bte As Byte()
                ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.ReadWrite)
                ofile.Seek(0, IO.SeekOrigin.Begin)
                iSize = ofile.Length
                Dim iNumRead As Integer = 0
                Dim iReadOFf As Integer = 0
                If iSize > 511 Then
                    iReadOFf = iSize - 512
                    iNumRead = 512
                Else
                    iNumRead = iSize
                End If
                ReDim bte(iNumRead - 1)
                ofile.Seek(iReadOFf, IO.SeekOrigin.Begin)
                ofile.Read(bte, 0, iNumRead)
                Dim xLoop As Integer = 0
                Do While xLoop <= UBound(bte)
                    Dim CurChr As Integer = CInt(bte(xLoop))
                    If CurChr = 26 Or CurChr = 83 Then 'SUB or "S"
                        Dim iSauceOffset As Integer = IIf(CurChr = 83, 1, 0)
                        If UBound(bte) >= iLoop + 128 - iSauceOffset Then
                            Dim sStr As String = ""
                            For iLoop2 = 1 - iSauceOffset To 5 - iSauceOffset
                                sStr &= Chr(bte(xLoop + iLoop2))
                            Next
                            If sStr = "SAUCE" Then
                                xLoop += 1 - iSauceOffset '
                                Dim iNewxLoop As Integer = Me.GetFromByteArray(bte, xLoop)
                                ofile.SetLength(iSize - iNumRead + iNewxLoop)
                                bRemoved = True
                                If bDebug = True Then Console.WriteLine("Sauce Meta found")
                            End If
                        End If
                    End If
                    xLoop += 1
                Loop
                ofile.Close()

            End If
            Return bRemoved
        End Function
        Public Function GetFromFile(ByVal sFile As String) As Boolean
            Dim bFound As Boolean = False
            iError = 0
            If IO.File.Exists(sFile) Then
                Dim bte As Byte()
                Dim ofile As System.IO.FileStream
                Dim iSize As Integer = 0
                Try

                    ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.Read)
                    iSize = ofile.Length
                    Dim iNumRead As Integer = 0
                    Dim iReadOFf As Integer = 0
                    If iSize > 511 Then
                        iReadOFf = iSize - 512
                        iNumRead = 512
                    Else
                        iNumRead = iSize
                    End If
                    ReDim bte(iNumRead - 1)
                    ofile.Seek(iReadOFf, IO.SeekOrigin.Begin)
                    ofile.Read(bte, 0, iNumRead)
                    ofile.Close()
                    Dim xLoop As Integer = 0
                    Do While xLoop <= UBound(bte)
                        Dim CurChr As Integer = CInt(bte(xLoop))
                        If CurChr = 26 Or CurChr = 83 Then 'SUB or "S"
                            Dim iSauceOffset As Integer = IIf(CurChr = 83, 1, 0)
                            If UBound(bte) >= iLoop + 128 - iSauceOffset Then
                                Dim sStr As String = ""
                                For iLoop2 = 1 - iSauceOffset To 5 - iSauceOffset
                                    sStr &= Chr(bte(xLoop + iLoop2))
                                Next
                                If sStr = "SAUCE" Then
                                    xLoop += 1 - iSauceOffset : xLoop = Me.GetFromByteArray(bte, xLoop)
                                    bFound = True
                                    If bDebug = True Then Console.WriteLine("Sauce Meta found")
                                End If
                            End If
                        End If
                        xLoop += 1
                    Loop
                Catch ex As Exception
                    iError = 1
                    RaiseEvent SauceParseError(Me, EventArgs.Empty)

                End Try

            End If
            System.Windows.Forms.Application.DoEvents()
            Return bFound
        End Function

        Public Function BuildHTML(Optional ByVal bGenCmts As Boolean = True) As String
            Dim sOutput As String = ""
            Dim cDay As Integer, cMonth As Integer, cYear As Integer

            sOutput = "<div class=""sauce"">"
            If Strings.Trim(Me.Title) <> "" Then
                sOutput &= "<div class=""saucetitle""><span class=""saucelabel"">Title:</span><span class=""saucedata"">" & Strings.Trim(Me.Title) & "</span></div>"
            End If
            If Strings.Trim(Me.Author) <> "" Then
                sOutput &= "<div class=""sauceauthor""><span class=""saucelabel"">Author:</span><span class=""saucedata"">" & Strings.Trim(Me.Author) & "</span></div>"
            End If
            If Strings.Trim(Me.Group) <> "" Then
                sOutput &= "<div class=""saucegroup""><span class=""saucelabel"">Group:</span><span class=""saucedata"">" & Strings.Trim(Me.Group) & "</span></div>"
            End If
            If Me.DataType <> 0 Then
                sOutput &= "<div class=""saucedatatype""><span class=""saucelabel"">Data Type:</span><span class=""saucedata"">" & Strings.Trim(Me.DataTypeName) & " (" & Me.DataType & ")</span></div>"
            End If
            If Me.FileType <> 0 Then
                sOutput &= "<div class=""saucefiletype""><span class=""saucelabel"">File Type:</span><span class=""saucedata"">" & Strings.Trim(Me.FileTypeName) & " (" & Me.FileType & ")</span></div>"
                'me.FileTypeName
            End If
            If Strings.Trim(Me.CreatedDate) <> "" And IsNumeric(Me.CreatedDate) Then
                cYear = Strings.Left(Me.CreatedDate, 4)
                cMonth = Strings.Mid(Me.CreatedDate, 5, 2)
                cDay = Strings.Right(Me.CreatedDate, 2)
                sOutput &= "<div class=""saucecreatedate""><span class=""saucelabel"">Creation Date:</span><span class=""saucedata"">" & cDay.ToString & "." & MonthName(cMonth) & " " & cYear.ToString & "</span></div>"
            End If
            If (Me.DataType = 1 And Me.FileType >= 0 And Me.FileType <= 5) Or Me.DataType = 2 Or Me.DataType = 6 Then
                If Me.TInfo1 <> 0 Then 'width
                    sOutput &= "<div class=""saucetinfo1""><span class=""saucelabel"">Width:</span><span class=""saucedata"">" & Me.TInfo1.ToString & "</span></div>"
                End If
                If Me.TInfo2 <> 0 Then 'height
                    sOutput &= "<div class=""saucetinfo2""><span class=""saucelabel"">Height:</span><span class=""saucedata"">" & Me.TInfo2.ToString & "</span></div>"
                End If
            End If
            If Me.DataType = 1 And Me.FileType = 3 And Me.TInfo3 <> 0 Then
                '# RIP colors
                sOutput &= "<div class=""saucetinfo3""><span class=""saucelabel""># Colors:</span><span class=""saucedata"">" & Me.TInfo3.ToString & "</span></div>"
            End If
            If Me.DataType = 1 And Me.ExamineBit(Me.Flags, 0) = True Then ' Ice Colors
                sOutput &= "<div class=""sauceice"">ICE Colors Enabled</div>"
            End If
            If Me.DataType = 2 And Me.TInfo3 <> 0 Then
                'Bits per Pixel
                sOutput &= "<div class=""saucetinfo3""><span class=""saucelabel"">Bits per Pixel:</span><span class=""saucedata"">" & Me.TInfo3.ToString & "</span></div>"
            End If

            sOutput &= "</div>"

            If Me.Comments > 0 And bGenCmts = True Then
                sOutput &= "<div class=""saucecomments""><ol>"
                For x As Integer = 0 To UBound(Me.aComments)
                    sOutput &= "<li>" & Strings.Trim(Me.aComments(x)) & "</li>"
                Next
                sOutput &= "</ol></div>"
            End If
            System.Windows.Forms.Application.DoEvents()
            Return sOutput
        End Function

        Private Function ReadByteArray(ByRef Arr() As Byte, ByVal iLen As Integer, ByVal DtaType As String, ByRef iPos As Integer) As String
            Dim a As Integer, sRes As String = ""
            If DtaType = "b" Then : iLen = 1 : End If
            For a = 1 To iLen
                If UBound(Arr) >= inArrPos Then
                    Select Case DtaType
                        Case "s" : sRes = sRes & Chr(Arr(iPos))
                        Case "h" : sRes = sRes & Strings.Right("0" & Hex(Arr(iPos)), 2)
                        Case "b" : sRes = Arr(iPos)
                    End Select
                End If
                iPos += 1
            Next
            System.Windows.Forms.Application.DoEvents()
            Return sRes
        End Function
        ' The ExamineBit function will return True or False 
        ' depending on the value of the 1 based, nth bit (MyBit) 
        ' of an integer (MyByte).
        Private Function ExamineBit(ByVal MyByte As Byte, ByVal MyBit As Byte) As Boolean
            Dim BitMask As Int16
            MyByte = MyByte And &HFF
            BitMask = 2 ^ (MyBit - 1)
            ExamineBit = ((MyByte And BitMask) > 0)
        End Function
        Private Function FlipHexVal(ByVal sHexStr As String) As String '(hex)
            Dim a As Integer, sResult As String = ""
            If sHexStr.Length Mod 2 <> 0 Then : Return sHexStr : Exit Function : End If
            For a = sHexStr.Length - 1 To 1 Step -2
                sResult &= Strings.Mid(sHexStr, a, 2)
            Next
            System.Windows.Forms.Application.DoEvents()
            Return sResult
        End Function

        Private Function Hex2Int64(ByVal strHex As String) As Int64
            Dim lngResult As Int64 = 0, intIndex As Integer, strDigit As String
            Dim intDigit As Int64, intValue As Int64
            For intIndex = strHex.Length To 1 Step -1
                strDigit = Strings.Mid(strHex, intIndex, 1)
                intDigit = InStr("0123456789ABCDEF", UCase(strDigit)) - 1
                If intDigit >= 0 Then
                    intValue = intDigit * (16 ^ (strHex.Length - CLng(intIndex)))
                    lngResult = lngResult + intValue
                Else
                    lngResult = 0 : intIndex = 0 ' stop the loop
                End If
            Next
            System.Windows.Forms.Application.DoEvents()
            Return lngResult
        End Function

        Private Function HexStringToByteArray(ByVal sHexStr As String) As Byte()
            Dim a As Integer, dByte As Byte()
            If sHexStr.Length Mod 2 <> 0 Then
                Return Nothing
                Exit Function
            End If
            ReDim dByte(sHexStr.Length / 2 - 1)
            If sHexStr.Length > 2 Then
                For a = 1 To sHexStr.Length - 1 Step 2
                    dByte((a - 1) / 2) = CByte(Me.Hex2Int64(Mid(sHexStr, a, 2)))
                Next
            Else
                dByte(0) = CByte(Me.Hex2Int64(sHexStr))
            End If
            System.Windows.Forms.Application.DoEvents()
            Return dByte
        End Function
        Private Function StringToBytearray(ByVal sStr As String, Optional ByVal fixlength As Integer = 0) As Byte()
            Dim bte(sStr.Length - 1) As Byte
            Dim i As Integer = 0
            For i = 1 To sStr.Length
                bte(i - 1) = Asc(Strings.Mid(sStr, i, 1))
            Next
            If fixlength > 0 And sStr.Length < fixlength Then
                ReDim Preserve bte(fixlength - 1)
                Do While i <= fixlength
                    i += 1
                    bte(i - 1) = 32
                Loop
            End If
            System.Windows.Forms.Application.DoEvents()
            Return bte
        End Function
        Private Function ByteArrayToString(ByVal ByteArray As Byte(), Optional ByVal NullByte As String = "") As String
            Dim result As String = ""
            For a As Integer = 0 To ByteArray.Length - 1
                result += IIf(ByteArray(a) = 0, NullByte, Chr(ByteArray(a)))
            Next
            System.Windows.Forms.Application.DoEvents()
            Return result
        End Function
        Private Function MergeByteArrays(ByVal bArr1 As Byte(), ByVal bArr2 As Byte()) As Byte()
            Dim iDim1 As Integer = 0, iDim2 As Integer = 0, iDimOut As Integer = 0
            Dim i As Integer = 0, bArrOut() As Byte
            iDim1 = UBound(bArr1) : iDim2 = UBound(bArr2) : iDimOut = iDim1 + iDim2 + 1
            ReDim bArrOut(iDimOut)
            For i = 0 To iDim1
                bArrOut(i) = bArr1(i)
            Next
            System.Windows.Forms.Application.DoEvents()
            For i = 0 To iDim2
                bArrOut(iDim1 + 1 + i) = bArr2(i)
            Next
            System.Windows.Forms.Application.DoEvents()
            MergeByteArrays = bArrOut
        End Function
    End Class
End Namespace