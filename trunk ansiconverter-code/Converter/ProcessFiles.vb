Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.RegexOptions
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections.Generic
Imports System.Net.Mime.MediaTypeNames


Public Class ProcessFiles

    Public Event InfoMsg(ByVal Msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
    Public Event ErrMsg(ByVal Msg As String)
    Public Event AdjustnumUTF16(ByVal value As Integer)
    Public Event AdjustnumUTF8(ByVal value As Integer)
    Public Event AdjustnumSel(ByVal value As Integer)
    Public Event AdjustnumASCII(ByVal value As Integer)
    Public Event AdjustnumTotal(ByVal value As Integer)
    Public Event ProcessedFile(ByVal idx As Integer)

    ''' <summary>
    ''' Triggered if Processing was finished or Cancelled (checked <see cref="Cancelled"/>)
    ''' </summary>
    ''' <param name="Sender">Converter Object</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event ProcessFinished(ByVal Sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' Triggered if Processing Status Changes (see <see cref="eStatus"/> Enumerator)
    ''' </summary>
    ''' <param name="sender">Converter Object</param>
    ''' <param name="NewStatus">New Status (see <see cref="eStatus"/> Enumerator)</param>
    ''' <remarks></remarks>
    Public Event StatusChanged(ByVal sender As Object, ByVal NewStatus As eStatus)
    ''' <summary>
    ''' Triggered if item was removed from <see cref="Data.ListInputFiles"/>
    ''' </summary>
    ''' <param name="sender">Converter Object</param>
    ''' <param name="item">File Item (see <see cref="FileListItem"/>)</param>
    ''' <remarks></remarks>
    Public Event ListItemRemoved(ByVal sender As Object, ByVal item As FileListItem)
    Private _cancelled As Boolean = False
    Private _status As eStatus = eStatus.Idle

    ''' <summary>
    ''' Enumerator of Possible Processing States
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum eStatus
        Idle = 0
        Processing = 1
        Paused = 2
    End Enum
    ''' <summary>
    ''' Indicated wheather or not the conversion process finished normally or if it was cancelled
    ''' </summary>
    ''' <value></value>
    ''' <returns>True/False</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Cancelled As Boolean
        Get
            Return Me._cancelled
        End Get
    End Property
    ''' <summary>
    ''' Returns the current processing status (see <see cref="eStatus"/>)
    ''' </summary>
    ''' <value></value>
    ''' <returns><see cref="eStatus"/></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Status As eStatus
        Get
            Return Me._status
        End Get
    End Property
    ''' <summary>
    ''' Read only ArrayList of <see cref="ConverterSupport.WebFontDef"/> objects
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WebFonts() As ArrayList
        Get
            Return WebFontList
        End Get
    End Property
    Public Sub New()
        InitConst()
    End Sub
    ''' <summary>
    ''' Aborts the current processing and sets <see cref="Cancelled"/> Property to 'True'
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CancelProcessing()
        Me._cancelled = True
    End Sub
    ''' <summary>
    ''' Pauses the current processing and sets <see cref="Status"/> to eStatus.Paused
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PauseProcessing()
        If Me._status = eStatus.Processing Then
            Me._status = eStatus.Paused
            RaiseEvent StatusChanged(Me, eStatus.Paused)
        End If
    End Sub
    ''' <summary>
    ''' Resumes Processing (if <see cref="Status"/> = 'eStatus.Paused') and returns <see cref="Status"/> to 'eStates.Processing'
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ResumeProcessing()
        If Me._status = eStatus.Paused Then
            Me._status = eStatus.Processing
            RaiseEvent StatusChanged(Me, eStatus.Processing)
        End If
    End Sub

    Private Sub ProcessInfoMsg(ByVal msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
        RaiseEvent InfoMsg(msg, nolinebreak, removelast)
    End Sub
    ''' <summary>
    ''' Begins Processing of all Items in <see cref="Data.ListInputFiles"/>
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConvertAllFiles()
        Me._cancelled = False
        oAnsi = New MediaFormats.ANSI
        AddHandler oAnsi.InfoMsg, AddressOf ProcessInfoMsg

        If Internal.AnsiColorsARGBM.Count < 256 Then
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 0, 0, 0))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 0, 0, 173))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 0, 173, 0))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 0, 173, 173))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 173, 0, 0))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 173, 0, 173))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 173, 82, 0))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 173, 173, 173))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 82, 82, 82))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 82, 82, 255))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 82, 255, 82))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 82, 255, 255))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 255, 82, 82))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 255, 82, 255))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 255, 255, 82))
            Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 255, 255, 255))
            For a As Integer = Internal.AnsiColorsARGBM.Count To 255
                Internal.AnsiColorsARGBM.Add(System.Windows.Media.Color.FromArgb(255, 0, 0, 0))
            Next
        End If
        If DosFnt80x25.FontSet = False Then
            DosFnt80x25 = New MediaSupport.Ansifntdef(8, 16, Drawing.Color.FromArgb(255, 0, 0, 0), My.Resources.fnt80x25, My.Resources.dosfontback16c)
        End If
        If DosFnt80x50.FontSet = False Then
            DosFnt80x50 = New MediaSupport.Ansifntdef(8, 8, Drawing.Color.FromArgb(255, 0, 0, 0), My.Resources.fnt80x50, My.Resources.dosfontback16c)
        End If

        Dim ProcessedCount As Integer = 0, ConvertedCount As Integer = 0, ErrorCount As Integer = 0, SkippedCount As Integer = 0
        Dim Ret As String() = New String() {0, "", ""}
        Dim bteWork1 As Byte() = New Byte() {0}, bteWork2 As Byte() = New Byte() {0}
        Dim bteWork3 As Integer() = New Integer() {0}
        Dim strWork1 As String = "", strWork2 As String = ""
        Dim iLp As Integer = 0
        Dim bResetMappings As Boolean = False
        Dim bSkipIt As Boolean = False
        Dim PreviousInputFormat As String = ""
        sOutPutFormat = pOut
        'sInputFormat = MainForm.pIn.Tag.ToString
        If pSauce = "Strip" Then
            bOutputSauce = False
        Else
            bOutputSauce = True
        End If
        If pAnim = "Static" Then
            bAnimation = False
        Else
            bAnimation = True
        End If
        If sOutPutFormat = "AVI" Then
            Call ConverterSupport.WriteFile(ffmpegpath, My.Resources.ffmpeg, True, 0, True, True)
        End If
        bResetMappings = ResetMappings()
        OutputFileExists = CType(pOutExist, Integer)
        'For a As Integer = ListInputFiles.Count - 1 To 0 Step -1
        Dim iToDoCount As Integer = ListInputFiles.Count

        Me._status = eStatus.Processing
        RaiseEvent StatusChanged(Me, eStatus.Processing)

        For a As Integer = 0 To ListInputFiles.Count - 1 Step 1
            If Me._cancelled = True Then
                Exit For
            End If
            Dim bPauseEnded As Boolean = True
            If Me._status = eStatus.Paused Then
                RaiseEvent InfoMsg("[b]Processing Paused![/b]...", False, False)
                bPauseEnded = False
            End If
            Do While Not bPauseEnded
                If Me._status = eStatus.Processing Then
                    bPauseEnded = True
                    RaiseEvent InfoMsg("[b]Continue Processing![/b]", True, True)
                End If
                System.Threading.Thread.Sleep(100)
                System.Windows.Forms.Application.DoEvents()
            Loop
            Dim sFileNam As String = ListInputFiles.Item(a).FullPath
            cBPF = 0
            Dim FTyp As FFormats = ListInputFiles.Item(a).Format
            sInputFormat = Internal.aInp(ListInputFiles.Item(a).Type)
            If PreviousInputFormat = "" Then : PreviousInputFormat = sInputFormat : End If
            ProcessedCount += 1
            RaiseEvent InfoMsg("Processing (" & ProcessedCount.ToString & "/" & iToDoCount.ToString & ") [b]" & sFileNam & "[/b]", False, False)
            Dim sOutF As String = ConverterSupport.DetermineOutputFileName(sFileNam)
            OutFileWrite = sOutF
            '  RaiseEvent InfoMsg("Target Output: " & sOutF & ",rOutPathInput=" & rOutPathInput & ",rReplaceExt=" & rReplaceExt & ",txtExt=" & txtExt & ",outPath=" & outPath)
            ProcFilesCounter += 1
            If OutputFileExists = 1 And IO.File.Exists(sOutF) Then
                RaiseEvent InfoMsg("Output File [i]" & sOutF & "[/i] exists. SKIP!", False, False)
                SkippedCount += 1
            Else
                bSkipIt = False
                maxX = 80
                bHasSauce = False
                oSauce = New ConverterSupport.SauceMeta

                If bResetMappings = True Or PreviousInputFormat <> sInputFormat Then
                    bResetMappings = ResetMappings()
                End If
                PreviousInputFormat = sInputFormat
                Select Case sInputFormat
                    Case "ASC"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not ASCII. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "ASC" Then
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False Then
                            If sOutPutFormat = "UTF" Or sOutPutFormat = "ANS" Or sOutPutFormat = "BBS" Then
                                'Read ASC File to a Byte Array
                                bteWork1 = ConverterSupport.ReadBinaryFile(sFileNam)
                            End If
                            If sOutPutFormat = "HTML" Or sOutPutFormat = "IMG" Then
                                'Read ASC File as a String
                                strWork1 = ConverterSupport.ReadFile(sFileNam)
                                bHasSauce = oSauce.GetFromFile(sFileNam)
                                If bHasSauce = True Then
                                    Dim iOff As Integer = InStr(1, strWork1, Chr(26) & "SAUCE00", CompareMethod.Binary)
                                    If iOff = 0 Then
                                        iOff = InStr(1, strWork1, "SAUCE00", CompareMethod.Binary)
                                    End If
                                    If iOff > 0 Then
                                        strWork1 = Microsoft.VisualBasic.Left(strWork1, iOff - 1)
                                    End If
                                End If
                                strWork1 = Strings.Replace(strWork1, vbCrLf, vbLf, 1, -1, CompareMethod.Binary)
                                strWork1 = Strings.Replace(strWork1, vbCr, vbLf, 1, -1, CompareMethod.Binary)
                                strWork1 = Strings.Replace(strWork1, vbLf, vbCrLf, 1, -1, CompareMethod.Binary)
                            End If
                            If sOutPutFormat = "BIN" Then
                                bConv2Unicode = False
                                'Read ASCII File and Convert it to Custom Class/Array
                                oAnsi.ProcessANSIFile(sFileNam)
                            End If
                        End If
                    Case "ANS"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not an ANSI in US-ASCII Encoded format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "ANS" Then
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False Then
                            If sOutPutFormat = "AVI" Then
                                Dim VideoFile As String = ""
                                Ret = ConverterSupport.WriteFile(sOutF, "", bForceOverwrite, OutputFileExists, True, False)
                                VideoFile = Ret(1)
                                OutFileWrite = VideoFile
                                TempVideoFolder = IO.Path.Combine(IO.Path.GetTempPath, "ANSIToVideoTemp")
                                If Not IO.Directory.Exists(TempVideoFolder) Then
                                    IO.Directory.CreateDirectory(TempVideoFolder)
                                Else
                                    For Each fil In IO.Directory.GetFiles(TempVideoFolder)
                                        Try
                                            IO.File.Delete(fil)
                                        Catch ex As Exception
                                        End Try
                                    Next
                                End If
                                bMakeVideo = True
                                'oAVIFile = New AviWriter

                                'oAVIFile.OpenAVI(VideoFile, Math.Round(FPS, 0), iAVIWidth, iAVIHeight)
                            End If
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read ANSI File and Convert it to Custom Class/Array
                            If sOutPutFormat = "HTML" And bAnimation = True Then
                                Ret = MediaFormats.ProcessANSIAnimationFile(sFileNam, sOutF)
                            Else
                                'Also used for Video Conversion of Ansi Animations
                                oAnsi.ProcessANSIFile(sFileNam)
                            End If
                        End If
                    Case "HTML"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not HTML Code in ASCII Format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "HTML" Then
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False Then
                            'Read HTML Document as ASCII Text to a String Variable
                            strWork1 = ConverterSupport.ReadFile(sFileNam)
                            '
                            strWork1 = ConverterSupport.CutorSandR(strWork1, "<html>", "<div class=ANSICSS>", "I", "I", "C", 1)
                            strWork1 = ConverterSupport.CutorSandR(strWork1, "</div>", "</html>", "I", "I", "C", 1)
                            strWork1 = ConverterSupport.CutorSandR(strWork1, "<style>", "</style>", "I", "I", "C", "")
                            strWork1 = ConverterSupport.CutorSandR(strWork1, "<script", "</script>", "I", "I", "C", "")
                            strWork1 = ConverterSupport.RegExReplace(strWork1, "", "</?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[^'"">\s]+))?)+\s*|\s*)/?>", RegexOptions.IgnoreCase, True)
                        End If
                    Case "UTF"
                        If FTyp <> FFormats.utf_16 And FTyp <> FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is neither UTF-8 nor UTF-16 format. Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "UTF" Then
                            If (FTyp = FFormats.utf_16 And selUTF = "UTF16") Or (FTyp = FFormats.utf_8 And selUTF = "UTF8") Then
                                bSkipIt = True
                                SkippedCount += 1
                            End If
                        End If
                        If bSkipIt = False Then
                            bteWork1 = ConverterSupport.ReadBinaryFile(sFileNam)
                            If FTyp = FFormats.utf_16 Then
                                'Read UTF-16 Encoded Text File to a String Variable
                                strWork1 = ConverterSupport.ByteArrayToStr(bteWork1, FFormats.utf_16)
                            End If
                            If FTyp = FFormats.utf_8 Then
                                'Read UTF-8 Encoded Text File to a String Variable
                                strWork1 = ConverterSupport.ByteArrayToStr(bteWork1, FFormats.utf_8)
                            End If
                        End If
                    Case "PCB"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not an PCB @ Styled Ansi in US-ASCII Encoded format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "BBS" Then
                            If pBBS = "PCB" Then
                                bSkipIt = True
                                SkippedCount += 1
                            End If
                        End If
                        If bSkipIt = False Then
                            'Read PCB @ Styled ANSI File to Screen Array
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read PCB File and Convert it to Custom Class/Array
                            MediaFormats.ProcessPCBFile(sFileNam)
                        End If
                    Case "WC2"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not an PCB @ Styled Ansi in US-ASCII Encoded format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "BBS" Then
                            If pBBS = "WC2" Then
                                bSkipIt = True
                                SkippedCount += 1
                            End If
                        End If
                        If bSkipIt = False Then
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read WC2 File and Convert it to Custom Class/Array
                            MediaFormats.ProcessWC2File(sFileNam)
                        End If
                    Case "WC3"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not an PCB @ Styled Ansi in US-ASCII Encoded format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "BBS" Then
                            If pBBS = "WC3" Then
                                bSkipIt = True
                                SkippedCount += 1
                            End If
                        End If
                        If bSkipIt = False Then
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read WC3 File and Convert it to Custom Class/Array
                            MediaFormats.ProcessWC3File(sFileNam)
                        End If
                    Case "AVT"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not an PCB @ Styled Ansi in US-ASCII Encoded format. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "BBS" Then
                            If pBBS = "AVT" Then
                                bSkipIt = True
                                SkippedCount += 1
                            End If
                        End If
                        If bSkipIt = False Then
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read AVT File and Convert it to Custom Class/Array
                            MediaFormats.ProcessAVTFile(sFileNam)
                        End If
                    Case "BIN"
                        If FTyp = FFormats.utf_16 Or FTyp = FFormats.utf_8 Then
                            RaiseEvent ErrMsg("Input file: " & sFileNam & " is Unicode format and not a DOS Binary Ansi. File Skipped!")
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False And sOutPutFormat = "BIN" Then
                            bSkipIt = True
                            SkippedCount += 1
                        End If
                        If bSkipIt = False Then
                            'Read DOS Binary ANSI File to a Byte Array
                            Select Case sOutPutFormat
                                Case "HTML"
                                    bConv2Unicode = True
                                Case Else
                                    bConv2Unicode = False
                            End Select
                            'Read BIN File and Convert it to Custom Class/Array
                            maxX = 160
                            MediaFormats.ProcessBINFile(sFileNam)
                        End If
                End Select
                System.Windows.Forms.Application.DoEvents()
                If bSkipIt = False Then
                    'Input seams okay, no skipping of file 

                    bForceOverwrite = False
                    Select Case sOutPutFormat
                        Case "ASC"
                            If sInputFormat = "UTF" Then
                                'Convert Unicode Text File to ASC File
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Microsoft.VisualBasic.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.HexStringToByteArray(strWork2), bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If sInputFormat = "HTML" Then
                                'Convert HTML Encoded Unicode ASCII to ASC File
                                strWork2 = ConverterSupport.convuniasc(strWork1)
                                strWork2 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                    Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                    For b As Integer = 0 To UBound(aTmp1)
                                        aTmp1(b) = RTrim(aTmp1(b))
                                    Next
                                    strWork2 = Join(aTmp1, vbCrLf)
                                Else
                                    strWork2 = RTrim(strWork2)
                                End If
                                Dim iLen As Integer = Microsoft.VisualBasic.Len(strWork2)
                                ReDim bteWork1(iLen - 1)
                                For iLp = 1 To iLen
                                    bteWork1(iLp - 1) = Asc(Mid(strWork2, iLp, 1))
                                Next
                                Ret = ConverterSupport.WriteFile(sOutF, bteWork1, bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If sInputFormat = "ANS" Or sInputFormat = "PCB" Or sInputFormat = "BIN" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                'Save ANSI as ASCII
                                bteWork1 = ConverterSupport.ANSIScreenToASCIIByteArray()
                                Ret = ConverterSupport.WriteFile(sOutF, bteWork1, bForceOverwrite, OutputFileExists, False, True)
                            End If
                        Case "ANS"
                            If sInputFormat = "ASC" Then
                                'Create ANSI from ASC File
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.ANSIHdr, bteWork1), bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If sInputFormat = "PCB" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Or sInputFormat = "BIN" Then
                                Ret = ConverterSupport.OutputANS(sOutF)
                            End If
                            If sInputFormat = "HTML" Then
                                strWork2 = ConverterSupport.convuniasc(strWork1)
                                strWork2 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                    Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                    For b As Integer = 0 To UBound(aTmp1)
                                        aTmp1(b) = RTrim(aTmp1(b))
                                    Next
                                    strWork2 = Join(aTmp1, vbCrLf)
                                Else
                                    strWork2 = RTrim(strWork2)
                                End If
                                Dim iLen As Integer = Microsoft.VisualBasic.Len(strWork2)
                                ReDim bteWork1(iLen - 1)
                                For iLp = 1 To iLen
                                    bteWork1(iLp - 1) = Asc(Mid(strWork2, iLp, 1))
                                Next
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.ANSIHdr, bteWork1), bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If sInputFormat = "UTF" Then
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Microsoft.VisualBasic.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                bteWork1 = ConverterSupport.HexStringToByteArray(strWork2)
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.ANSIHdr, bteWork1), bForceOverwrite, OutputFileExists, False, True)
                            End If
                        Case "HTML"
                            If sInputFormat = "ANS" Or sInputFormat = "PCB" Or sInputFormat = "BIN" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                'Convert ANSI to Html Encoded Unicode and CSS
                                If bAnimation = False Then
                                    Ret = ConverterSupport.OutputHTML(sOutF)
                                End If
                            End If
                            If sInputFormat = "ASC" Then
                                'Convert ASC to HTML Encoded Unicode
                                strWork2 = ConverterSupport.convascuni(strWork1)
                                Ret = ConverterSupport.OutputASCHTML(sOutF, strWork2)
                            End If
                            If sInputFormat = "UTF" Then
                                'Convert Unicode Text File to HTML Encoded Unicode 
                                'Currently converting the Text File back to an ASCII and then the 
                                'ASCII back again to Encoded Unicode. Not very efficient and should 
                                'be changed when there is time.
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Microsoft.VisualBasic.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                strWork1 = ConverterSupport.ByteArrayToString(ConverterSupport.HexStringToByteArray(strWork2))
                                strWork2 = ConverterSupport.convascuni(strWork1)
                                Ret = ConverterSupport.OutputASCHTML(sOutF, strWork2)
                            End If
                        Case "UTF"
                            If sInputFormat = "ASC" Or sInputFormat = "HTML" Then
                                'Convert Unicode Encoded HTML ASCII to ASC Byte Array
                                If sInputFormat = "HTML" Then
                                    strWork2 = ConverterSupport.convuniasc(strWork1)
                                    strWork1 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                    strWork2 = ConverterSupport.convuniuni(strWork1)
                                    If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                        Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                        For b As Integer = 0 To UBound(aTmp1)
                                            aTmp1(b) = RTrim(aTmp1(b))
                                        Next
                                        strWork2 = Join(aTmp1, vbCrLf)
                                    Else
                                        strWork2 = RTrim(strWork2)
                                    End If
                                    'Dim iLen As Integer = Microsoft.VisualBasic.Len(strWork2)
                                    'ReDim bteWork3(iLen - 1)
                                    'For iLp = 1 To iLen
                                    ' bteWork3(iLp - 1) = AscW(Mid(strWork2, iLp, 1))
                                    'Next
                                    'bConv2Unicode = False
                                    'bHTMLEncode = False
                                    'Call BuildMappings(sCodePg)
                                    'bResetMappings = True
                                End If
                            End If
                            If sInputFormat = "ANS" Or sInputFormat = "BIN" Or sInputFormat = "PCB" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                bteWork1 = ConverterSupport.ANSIScreenToASCIIByteArray()
                            End If
                            'Convert ASC File to Unicode Text File
                            strWork1 = ""
                            If sInputFormat = "HTML" Then
                                strWork1 = strWork2
                            Else
                                For iLp = 0 To UBound(bteWork1)
                                    strWork1 &= ConverterSupport.AsciiToUnicode(bteWork1(iLp))
                                Next
                            End If
                            If selUTF = "UTF16" Then 'MainForm.rUTF16.Checked = True Then
                                'Save as UTF-16 Encoded Text File
                                bteWork2 = ConverterSupport.StrToByteArray(strWork1, FFormats.utf_16)
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.UTF16Hdr, bteWork2), bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If selUTF = "UTF8" Then 'MainForm.rUTF8.Checked = True Then
                                'Save as UTF-8 Encoded Text File
                                bteWork2 = ConverterSupport.StrToByteArray(strWork1, FFormats.utf_8)
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.UTF8Hdr, bteWork2), bForceOverwrite, OutputFileExists, False, True)
                            End If


                        Case "BBS"
                            If sInputFormat = "ANS" Or sInputFormat = "BIN" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                'Save ANSI to PCBoard @ Styled ANSI
                                Select Case pBBS
                                    Case "PCB"
                                        Ret = ConverterSupport.OutputPCB(sOutF)
                                    Case "AVT"
                                        Ret = ConverterSupport.OutputAVT(sOutF)
                                    Case "WC2"
                                        Ret = ConverterSupport.OutputWC2(sOutF)
                                    Case "WC3"
                                        Ret = ConverterSupport.OutputWC3(sOutF)
                                End Select
                            End If
                            If sInputFormat = "ASC" Then
                                'Create PCBoard @ Styled ANSI from ASC File
                                Ret = ConverterSupport.WriteFile(sOutF, ConverterSupport.MergeByteArrays(Internal.PCBHdr, bteWork1), bForceOverwrite, OutputFileExists, False, True)
                            End If
                            If sInputFormat = "HTML" Then
                                strWork2 = ConverterSupport.convuniasc(strWork1)
                                strWork2 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                    Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                    For b As Integer = 0 To UBound(aTmp1)
                                        aTmp1(b) = RTrim(aTmp1(b))
                                    Next
                                    strWork2 = Join(aTmp1, vbCrLf)
                                Else
                                    strWork2 = RTrim(strWork2)
                                End If
                                Dim iLen As Integer = Microsoft.VisualBasic.Len(strWork2)
                                ReDim bteWork1(iLen - 1)
                                For iLp = 1 To iLen
                                    bteWork1(iLp - 1) = Asc(Mid(strWork2, iLp, 1))
                                Next
                                bConv2Unicode = False
                                bHTMLEncode = False
                                'Convert ASCII from Byte Array to Custom Class/Array
                                oAnsi.ProcessANSIFile(sFileNam, bteWork1)
                                Select Case pBBS
                                    Case "PCB"
                                        Ret = ConverterSupport.OutputPCB(sOutF)
                                    Case "AVT"
                                        Ret = ConverterSupport.OutputAVT(sOutF)
                                    Case "WC2"
                                        Ret = ConverterSupport.OutputWC2(sOutF)
                                    Case "WC3"
                                        Ret = ConverterSupport.OutputWC3(sOutF)
                                End Select

                            End If
                            If sInputFormat = "UTF" Then
                                'Convert Unicode Text File to ASCII Byte Array and from there to Custom Class to PCB
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Microsoft.VisualBasic.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                bConv2Unicode = False
                                bHTMLEncode = False
                                oAnsi.ProcessANSIFile(sFileNam, ConverterSupport.HexStringToByteArray(strWork2))
                                Ret = ConverterSupport.OutputPCB(sOutF)
                            End If
                        Case "BIN"
                            If sInputFormat = "ANS" Or sInputFormat = "PCB" Or sInputFormat = "ASC" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                'Save ANSI as Binary DOS File
                                If bDebug = True Then Console.WriteLine("output filename:" & sOutF)
                                maxX = 160
                                Screen = ConverterSupport.ResizeScreen(Screen, maxX, LinesUsed)
                                Ret = ConverterSupport.OutputBin(sOutF)
                            End If
                            If sInputFormat = "HTML" Then
                                strWork2 = ConverterSupport.convuniasc(strWork1)
                                strWork2 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                    Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                    For b As Integer = 0 To UBound(aTmp1)
                                        aTmp1(b) = RTrim(aTmp1(b))
                                    Next
                                    strWork2 = Join(aTmp1, vbCrLf)
                                Else
                                    strWork2 = RTrim(strWork2)
                                End If
                                Dim iLen As Integer = Microsoft.VisualBasic.Len(strWork2)
                                ReDim bteWork1(iLen - 1)
                                For iLp = 1 To iLen
                                    bteWork1(iLp - 1) = Asc(Mid(strWork2, iLp, 1))
                                Next
                                bConv2Unicode = False
                                bHTMLEncode = False
                                'Convert ASCII from Byte Array to Custom Class/Array
                                oAnsi.ProcessANSIFile(sFileNam, bteWork1)
                                maxX = 160
                                Screen = ConverterSupport.ResizeScreen(Screen, maxX, LinesUsed)
                                Ret = ConverterSupport.OutputBin(sOutF)
                            End If
                            If sInputFormat = "UTF" Then
                                'Convert Unicode Text File to ASCII Byte Array and from there to Custom Class to Binary
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Strings.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                bConv2Unicode = False
                                bHTMLEncode = False
                                oAnsi.ProcessANSIFile(sFileNam, ConverterSupport.HexStringToByteArray(strWork2))
                                maxX = 160
                                Screen = ConverterSupport.ResizeScreen(Screen, maxX, LinesUsed)
                                Ret = ConverterSupport.OutputBin(sOutF)
                            End If
                        Case "IMG"
                            Dim i As Drawing.Bitmap
                            Dim bLocNoColors As Boolean = pNoColors

                            If sInputFormat = "UTF" Then
                                strWork2 = ""
                                For iLp = 2 To strWork1.Length
                                    strWork2 &= Strings.Right("0" & Hex(Asc(ConverterSupport.UnicodeToAscii(AscW(Mid(strWork1, iLp, 1))))), 2)
                                Next
                                strWork1 = ConverterSupport.HexStringToString(strWork2)
                                bLocNoColors = True
                            End If
                            If sInputFormat = "HTML" Then
                                'Convert HTML Encoded Unicode ASCII to ASC File
                                strWork2 = ConverterSupport.convuniasc(strWork1)
                                strWork2 = Replace(strWork2, Chr(255), " ", 1, -1, CompareMethod.Binary)
                                If InStr(strWork2, vbCrLf, CompareMethod.Text) > 0 Then
                                    Dim aTmp1() As String = Split(strWork2, vbCrLf)
                                    For b As Integer = 0 To UBound(aTmp1)
                                        aTmp1(b) = RTrim(aTmp1(b))
                                    Next
                                    strWork1 = Join(aTmp1, vbCrLf)
                                Else
                                    strWork1 = RTrim(strWork2)
                                End If
                                bLocNoColors = True
                            End If
                            If sInputFormat = "ANS" Or sInputFormat = "PCB" Or sInputFormat = "BIN" Or sInputFormat = "WC2" Or sInputFormat = "WC3" Or sInputFormat = "AVT" Then
                                'Save ANSI as ASCII
                                If pNoColors = True Then
                                    bteWork1 = ConverterSupport.ANSIScreenToASCIIByteArray()
                                    strWork1 = ConverterSupport.ByteArrayToString(bteWork1)
                                End If
                                i = MediaFormats.CreateImageFromScreenChars()
                            Else
                                i = MediaFormats.CreateImageFromASCII(strWork1, Nothing, Nothing)
                            End If
                            If bLocNoColors = True Then

                            Else

                            End If

                            Ret = ConverterSupport.WriteFile(sOutF, i, bForceOverwrite, OutputFileExists, False, True)
                        Case "AVI"
                            'oAVIFile.Close()
                            RaiseEvent InfoMsg("Compiling Video File", False, False)
                            Dim iAVIWidth As Integer, iAVIHeight As Integer
                            If pSmallFont Then
                                iAVIWidth = DosFnt80x50.Width * 80
                                iAVIHeight = DosFnt80x50.Height * 25
                            Else
                                iAVIWidth = DosFnt80x25.Width * 80
                                iAVIHeight = DosFnt80x25.Height * 25
                            End If
                            Dim vc2 As New MediaSupport.VideoConverterFFMPEG
                            vc2.FFMPEGPath = ffmpegpath
                            vc2.Imagelist = IO.Path.Combine(TempVideoFolder, IO.Path.GetFileNameWithoutExtension(OutFileWrite) & "_%05d.PNG")
                            vc2.Output = OutFileWrite
                            vc2.FPS = FPS
                            vc2.Numframes = iFramesCount
                            vc2.VideoHeight = iAVIHeight
                            vc2.VideoWidth = iAVIWidth
                            vc2.VCodec = VidCodec
                            Select Case VidFmt
                                Case "AVI"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.AVI
                                Case "WMV"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.WMV
                                Case "FLV"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.FLV
                                Case "MKV"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.MKV
                                Case "GIF"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.GIF
                                    'vc2.VCodec = "gif"
                                Case "VOB"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.VOB
                                Case "MPG"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.MPG
                                Case "MP4"
                                    vc2.OutFormat = MediaSupport.VideoConverterFFMPEG.OutTypes.MP4
                            End Select
                            'iFramesCount

                            If vc2.Status = MediaSupport.VideoConverterFFMPEG.ConvStates.Ready Then
                                vc2.Convert()
                                Do While vc2.Status <> MediaSupport.VideoConverterFFMPEG.ConvStates.Aborted And vc2.Status <> MediaSupport.VideoConverterFFMPEG.ConvStates.Finished
                                    System.Threading.Thread.Sleep(200)
                                    System.Windows.Forms.Application.DoEvents()
                                Loop
                            End If
                            If bDebug = False Then
                                For Each fil In IO.Directory.GetFiles(TempVideoFolder)
                                    Try
                                        IO.File.Delete(fil)
                                    Catch ex As Exception
                                    End Try
                                Next

                            End If




                    End Select


                    If CInt(Ret(0)) >= 0 Then
                        RaiseEvent InfoMsg("Output generated at [b]" & Ret(1) & "[/b]. " & vbCrLf & Ret(2), False, False)
                        ConvertedCount += 1
                    Else
                        RaiseEvent ErrMsg("Error writing: " & Ret(1) & ". " & vbCrLf & Ret(2))
                        ErrorCount += 1
                    End If

                    'Skipped
                End If

                'Existing output skipped
            End If
            '  If MainForm.bRemoveCompleted.Checked = True Then
            If bRemoveCompleted = True Then
                Select Case ListInputFiles.Item(a).Format
                    Case FFormats.utf_16

                        RaiseEvent AdjustnumUTF16(-1)
                    Case FFormats.utf_8

                        RaiseEvent AdjustnumUTF8(-1)
                    Case Else

                        RaiseEvent AdjustnumASCII(-1)
                End Select

                RaiseEvent AdjustnumTotal(-1)
                If ListInputFiles.Item(a).Selected = True Then
                    RaiseEvent AdjustnumSel(-1)
                End If
                Dim item As FileListItem = ListInputFiles.Item(a)
                ListInputFiles.Remove(item)
                RaiseEvent ListItemRemoved(Me, item)
                RaiseEvent ProcessedFile(a)
                RaiseEvent InfoMsg("[s]-[/s]", False, False)
                a -= 1
                If ListInputFiles.Count = 0 Then
                    Exit For
                End If
                ' MainForm.listFiles.DataSource = Nothing
                ' MainForm.listFiles.DataSource = ListInputFiles
                ' UpdateCounts()
                ' End If
            Else
                RaiseEvent ProcessedFile(a)
                RaiseEvent InfoMsg("[s]-[/s]", False, False)
            End If

            System.Windows.Forms.Application.DoEvents()
        Next
        If sOutPutFormat = "AVI" Then
            Try
                IO.File.Delete(ffmpegpath)
                IO.Directory.Delete(TempVideoFolder)
            Catch ex As Exception

            End Try
        End If
        Dim sFinalMessage As String = ""

        If ProcessedCount > ConvertedCount Then
            sFinalMessage = "Total Processed: [b]" & ProcessedCount & "[/b] "
            If ConvertedCount > 0 Then
                sFinalMessage &= ", Converted: [t]" & ConvertedCount & "[/t]"
            End If
            If SkippedCount > 0 Then
                sFinalMessage &= ", Skipped: [b]" & SkippedCount & "[/b]"
            End If
            If ErrorCount > 0 Then
                sFinalMessage &= ", Errors: [e]" & ErrorCount & "[/e]"
            End If
        Else
            sFinalMessage = "Total Converted: [t]" & ConvertedCount & "[/t] "
        End If
        RaiseEvent InfoMsg(sFinalMessage, False, False)
        If Me._cancelled Then
            RaiseEvent InfoMsg("[e]Processing cancelled by user![/e]", False, False)
        Else
            RaiseEvent InfoMsg("[f]Done Processing[/f]", False, False)
        End If

        RaiseEvent ProcessFinished(Me, EventArgs.Empty)

        Me._status = eStatus.Idle
        RaiseEvent StatusChanged(Me, eStatus.Idle)
    End Sub

    ''' <summary>
    ''' Resets Code Page Mapper Settings to Initial Value
    ''' </summary>
    ''' <returns>False</returns>
    ''' <remarks></remarks>
    Public Function ResetMappings() As Boolean
        bSanitize = pSanitize
        sCodePg = pCP
        bHTMLEncode = pHTMLEncode
        bHTMLComplete = pHTMLComplete
        ConverterSupport.BuildMappings(sCodePg)

        Return False

    End Function

    ''' <summary>
    ''' Initializes Required Constants for HTML Processing and Code Page Mappings
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitConst()

        Internal.aCSS(0, 0) = "B0" : Internal.aCSS(1, 0) = "C0" : Internal.aCSS(2, 0) = "#000000"
        Internal.aCSS(0, 1) = "B1" : Internal.aCSS(1, 1) = "C1" : Internal.aCSS(2, 1) = "#0000AA"
        Internal.aCSS(0, 2) = "B2" : Internal.aCSS(1, 2) = "C2" : Internal.aCSS(2, 2) = "#00AA00"
        Internal.aCSS(0, 3) = "B3" : Internal.aCSS(1, 3) = "C3" : Internal.aCSS(2, 3) = "#00AAAA"
        Internal.aCSS(0, 4) = "B4" : Internal.aCSS(1, 4) = "C4" : Internal.aCSS(2, 4) = "#AA0000"
        Internal.aCSS(0, 5) = "B5" : Internal.aCSS(1, 5) = "C5" : Internal.aCSS(2, 5) = "#AA00AA"
        Internal.aCSS(0, 6) = "B6" : Internal.aCSS(1, 6) = "C6" : Internal.aCSS(2, 6) = "#AA5500"
        Internal.aCSS(0, 7) = "B7" : Internal.aCSS(1, 7) = "C7" : Internal.aCSS(2, 7) = "#AAAAAA"
        Internal.aCSS(1, 8) = "C8" : Internal.aCSS(2, 8) = "#555555"
        Internal.aCSS(1, 9) = "C9" : Internal.aCSS(2, 9) = "#5555FF"
        Internal.aCSS(1, 10) = "CA" : Internal.aCSS(2, 10) = "#55FF55"
        Internal.aCSS(1, 11) = "CB" : Internal.aCSS(2, 11) = "#55FFFF"
        Internal.aCSS(1, 12) = "CC" : Internal.aCSS(2, 12) = "#FF5555"
        Internal.aCSS(1, 13) = "CD" : Internal.aCSS(2, 13) = "#FF55FF"
        Internal.aCSS(1, 14) = "CE" : Internal.aCSS(2, 14) = "#FFFF55"
        Internal.aCSS(1, 15) = "CF" : Internal.aCSS(2, 15) = "#FFFFFF"

        Internal.aCPLN = Split(Internal.sCPLN, "|")
        Internal.aCPL = Split(Internal.sCPL, "|")
        Internal.aCPLISO = Split(Internal.sCPLISO, "|")
        Internal.aWinCPL = Split(Internal.sWinCPL, "|")
        Internal.aWinCPLN = Split(Internal.sWinCPLN, "|")
        Internal.aWinCPLISO = Split(Internal.sWinCPLISO, "|")

        If DosFnt80x50 Is Nothing Then
            DosFnt80x50 = New MediaSupport.Ansifntdef(8, 8, Drawing.Color.FromArgb(255, 32, 32, 32), My.Resources.dosfont80x50c16b2, My.Resources.dosfontback16c)
        End If
        If DosFnt80x25 Is Nothing Then
            DosFnt80x25 = New MediaSupport.Ansifntdef(8, 16, Drawing.Color.FromArgb(255, 32, 32, 32), My.Resources.dosfont80x25c16b2, My.Resources.dosfontback16c)
        End If
        WebFontList.Add(New ConverterSupport.WebFontDef("Default", "font-size:16px;", "", "font-family:DOS,monospace;font-size:16px;", "font-size:16px;", "", "font-family:DOS,monospace;font-size:16px;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Terminal", "font-size:16px;", "", "font-family:Terminal,monospace;font-size:16px;", "font-size:16px;", "", "font-family:Terminal,monospace;font-size:16px;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Lucida Console", "font-size:16px;", "", "font-family:""Lucida Console"", monospace;font-size:16px;", "font-size:16px;", "", "font-family:""Lucida Console"",monospace;font-size:16px;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("FixedSys", "font-size:100%;", "", "font-family:FixedSys,monospace;font-size:100%;", "font-size:100%;", "", "font-family:FixedSys,monospace;font-size:100%;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("VT-100", "font-size:16px;", "", "font-family:VT-100,monospace;font-size:16px;", "font-size:16px;", "", "font-family:VT-100,monospace;font-size:16px;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Monaco", "font-size:100%;", "", "font-family:Monaco,monospace;font-size:100%;", "font-size:100%;", "", "font-family:Monaco,monospace;font-size:100%;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Andale Mono", "font-size:100%;", "", "font-family:""Andale Mono"",monospace;font-size:100%;", "font-size:100%;", "", "font-family:""Andale Mono"",monospace;font-size:100%;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("MS Gothic", "font-size:16px;", "", "font-family:""MS Gothic"",monospace;font-size:16px;", "font-size:16px;", "", "font-family:""MS Gothic"",monospace;font-size:16px;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Courier", "font-size:100%;", "", "font-family:Courier, monospace;font-size:100%;", "font-size:100%;", "", "font-family:Courier,monospace;font-size:100%;width:8px;height:16px;overflow:hidden;border:none;"))
        WebFontList.Add(New ConverterSupport.WebFontDef("Courier New", "font-size:100%;", "", "font-family:""Courier New"",monospace;font-size:100%;", "font-size:100%;", "", "font-family:""Courier New"",monospace;font-size:100%;width:8px;height:16px;overflow:hidden;border:none;"))


        sCSSDef = ""
        If bCUFon = True Then
            sCSSDef = sCSSDef & "DIV.ANSICSS {background-color:#000; color:#C6C6C6;width:%WIDTH%;padding: 5px;}" & vbCrLf & _
                                "DIV.ANSICSS PRE {margin:0px;padding:0px;line-height:100%;font-size: 100%;}" & vbCrLf
        Else
            sCSSDef = "DIV.ANSICSS {background-color:#000;color:#C6C6C6;display:inline-block;width:%WIDTH%;margin:0px;padding:0px;letter-spacing:0px;line-height:16px;%EXTRACSSDIV%}" & vbCrLf & _
                      "DIV.ANSICSS PRE {margin:0px;padding:0px;display:block;width:100%;%EXTRACSSPRE%}" & vbCrLf & _
                      "DIV.ANSICSS PRE SPAN {padding:0;margin-top:-1px;line-height:16px;letter-spacing:0;display:inline-block;white-space:nowrap;%EXTRACSSSPAN%}" & vbCrLf

            'sCSSDef = sCSSDef & "DIV.ANSICSS {background-color:#000;color:#C6C6C6;width:%WIDTH%;padding:5px;margin:0px;}" & vbCrLf & _
            '                    "DIV.ANSICSS PRE {margin:0px;padding:0px;line-height:16px;font-size:16px;letter-spacing:0;width:%WIDTH%;%EXTRACSSPRE%}" & vbCrLf & _
            '                    "DIV.ANSICSS PRE SPAN {margin:-1px;* margin:0px;padding:0px;line-height:16px;font-size:16px;letter-spacing:0px;white-space:nowrap;%EXTRACSSSPAN%}" & vbCrLf
        End If

        For x As Integer = 0 To 15
            If x < 8 Then
                sCSSDef = sCSSDef & "DIV.ANSICSS PRE SPAN." & Internal.aCSS(0, x) & " {background-color:" & Internal.aCSS(2, x) & ";}" & vbCrLf
            End If
            sCSSDef = sCSSDef & "DIV.ANSICSS PRE SPAN." & Internal.aCSS(1, x) & " {color:" & Internal.aCSS(2, x) & ";}" & vbCrLf
        Next
        sCSSDef = sCSSDef & "DIV.ANSICSS PRE SPAN.II{background-color:" & Internal.aCSS(2, 0) & ";color:" & Internal.aCSS(2, 7) & ";}" & vbCrLf

        Internal.sSauceCSS = ""
        Internal.sSauceCSS &= "div.sauce,div.saucecomments{margin-top:5px;margin-left:20px;background-color:#000000;border:3px solid #C1C1C1;color:#555555;padding:10px;width:600px;align:right;font-family:dos, monospace;font-size:0.75em;display:inline-block;position:relative;}" & vbCrLf & _
                    "div.sauce span.saucelabel{font-weight: bold; width: 170px;text-align: right; line-height: 1.5em;border-bottom: 1px dotted #222266;}" & _
                    "div.sauce span.saucedata{width: 400px; position: absolute;right: 5; text-align: left; color: #CCCCCC;border-bottom: 1px dotted #222266;}" & vbCrLf & _
                    "div.sauce div.saucetitle span.saucelabel { color: #FFFF55;}" & vbCrLf & _
                    "div.sauce div.saucetitle span.saucedata { color: #858500;}" & vbCrLf & _
                    "div.sauce div.sauceauthor span.saucelabel { color: #55FF55;}" & vbCrLf & _
                    "div.sauce div.sauceauthor span.saucedata { color: #008500;}" & vbCrLf & _
                    "div.sauce div.saucegroup span.saucelabel { color: #C1C1C1;}" & vbCrLf & _
                    "div.sauce div.saucegroup span.saucedata { color: #555555;}" & vbCrLf & _
                    "div.sauce div.saucedatatype span.saucelabel { color: #555555;}" & vbCrLf & _
                    "div.sauce div.saucedatatype span.saucedata { color: #444444;}" & vbCrLf & _
                    "div.sauce div.saucefiletype span.saucelabel { color: #444444;}" & vbCrLf & _
                    "div.sauce div.saucefiletype span.saucedata { color: #333333;}" & vbCrLf & _
                    "div.sauce div.saucecreatedate span.saucelabel { color: #5555FF;}" & vbCrLf & _
                    "div.sauce div.saucecreatedate span.saucedata { color: #555599;}" & vbCrLf & _
                    "div.sauce div.saucetinfo1 span.saucelabel { color: #FFFF55;}" & vbCrLf & _
                    "div.sauce div.saucetinfo1 span.saucedata { color: #858500;}" & vbCrLf & _
                    "div.sauce div.saucetinfo2 span.saucelabel { color: #FFFF55;}" & vbCrLf & _
                    "div.sauce div.saucetinfo2 span.saucedata { color: #858500;}" & vbCrLf & _
                    "div.sauce div.saucetinfo3 span.saucelabel { color: #FFFF55;}" & vbCrLf & _
                    "div.sauce div.saucetinfo3 span.saucedata { color: #858500;}" & vbCrLf & _
                    "div.sauce div.sauceice{color: #FFFFFF;}" & vbCrLf


    End Sub
End Class
