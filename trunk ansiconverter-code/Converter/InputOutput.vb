Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO
Imports System.Text
Public Module InputOutput


    Public Function ReadBinaryFile(ByVal sFile As String) As Byte()
        Dim bte As Byte()
        Dim ofile As System.IO.FileStream
        Dim iSize As Integer = 0
        If IO.File.Exists(sFile) Then
            ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.Read, FileShare.ReadWrite)
            ofile.Seek(0, IO.SeekOrigin.Begin)
            iSize = ofile.Length - 1
            ReDim bte(iSize)
            ofile.Read(bte, 0, iSize + 1)
            ofile.Close()
            Return bte
        Else
            Return Nothing
        End If
    End Function


    ''' <summary>
    ''' Reads a text file and returns the content as string)
    ''' </summary>
    ''' <param name="sFile">Path/File Name of Textfile to read</param>
    ''' <returns>String</returns>
    Public Function ReadFile(ByVal sFile As String) As String
        Dim sAll As String = ""
        Dim Bte As Byte()
        Try
            ' Create an instance of StreamReader to read from a file.
            ' The using statement also closes the StreamReader.
            'Io.File.GetAttributes(sFile).
            Using sr As New StreamReader(sFile, True)
                ' Dim encoding As New System.Text.ASCIIEncoding
                ReDim Bte(sr.BaseStream.Length - 1)
                sr.BaseStream.Read(Bte, 0, sr.BaseStream.Length)
                'sAll = encoding.GetString(Bte)
                sAll = ByteArrayToString(Bte)
            End Using
        Catch e As Exception
        End Try

        Return sAll
    End Function
    ''' <summary>
    ''' Write a string value to the specified output file (with extended options)
    ''' </summary>
    ''' <param name="OutFileName">Path/File Name of the output text file</param>
    ''' <param name="sStr">The string value to export</param>
    ''' <param name="bForceOverwrite">Force Overwriting of an existing file at the specified Path/File Name location</param>
    ''' <param name="iOutExists">Extended Options for Existing File Handling
    ''' 
    ''' <para>
    ''' Output Array Structure 
    ''' Dimension   Usage
    '''    0        Result Code (Int), See List below
    '''    1        Path and Name of Output File Written (if there was one written)
    '''    2        Info/Error Message in Text Format
    ''' </para>
    ''' <para>iOutExists - General Program Settings for Existing Output Files</para>
    ''' <para>  0 = Overwrite </para>
    ''' <para>  1 = Skip (no Output)</para>
    ''' <para>  2 = Auto Rename New File (Path\Filename[x].Ext)</para>
    ''' <para>  3 = Ask (Message Dialog)</para>
    ''' <para>  4 = Auto Rename Existing File</para>
    ''' 
    '''</param>
    '''<returns>Response Message Array (3 dimensions) (0) = Return Code*, (1) Written File Name, (2) Extended Info/Error Message</returns>
    '''<remarks>* Result Codes:
    ''' 
    ''' <para>-4 - Error Writing Output File</para>
    ''' <para> 0 - Output Written, did not exist</para>
    ''' <para> 1 - Output Written, Existing Overwritten, Force Overwrite Enabled</para>
    ''' <para> 2 - Output Written, Existing Overwritten, iOutExists = Overwrite</para>
    ''' <para> 3 - Output Skipped, No Output, iOutExists = Skip</para>
    ''' <para> 4 - Output Written, Existing Overwritten, iOutExists = Ask, Result = Overwrite</para>
    ''' <para> 5 - Output Skipped, No Output, iOutExists = Ask, Result = Skip</para>
    ''' <para> 6 - Output Written, Different File Name, iOutExists = Auto Rename New File</para>
    ''' <para> 7 - Output Written, Existing File Renamed, iOutExists = Auto Rename Existing File</para>
    ''' 
    '''</remarks>
    Public Function WriteFile(ByVal OutFileName As String, _
                                     ByVal sStr As Object, _
                                     Optional ByVal bForceOverwrite As Boolean = False, _
                                     Optional ByVal iOutExists As Integer = 0, _
                                     Optional ByVal m_NoMsg As Boolean = False, _
                                     Optional ByVal isBinary As Boolean = False)
        Dim bProceed As Boolean = True
        Dim SF As String = "", sP As String = "", sE As String = "", sB As String = "", DC As Integer = 1, sWorkFN As String = ""
        Dim aResult(2) As String, sParentDir As String = ""

        sParentDir = IO.Path.GetDirectoryName(OutFileName)
        If IO.Directory.Exists(sParentDir) = False AndAlso sParentDir <> "" Then : IO.Directory.CreateDirectory(sParentDir) : End If

        If IO.File.Exists(OutFileName) Then
            If bForceOverwrite = True Then
                Try
                    IO.File.Delete(OutFileName)
                    bProceed = True : aResult(0) = "1" : aResult(1) = OutFileName
                    aResult(2) = "  - [b]Force Overwrite enabled.[/b] " & vbCrLf & "  - Existing Output file overwritten."
                Catch ex As Exception
                    bProceed = False : aResult(0) = "-4" : aResult(1) = OutFileName
                    aResult(2) = "  - Unable to Delete Existing Output File [i]'" & OutFileName & "'[/i]." & vbCrLf & "  - File Skipped."
                End Try
            Else
                Select Case iOutExists
                    Case 0
                        'Delete Output File, if it already exists
                        Try
                            IO.File.Delete(OutFileName)
                            bProceed = True : aResult(0) = "2" : aResult(1) = OutFileName
                            aResult(2) = "  - Program Setting [i]'Overwrite Existing Output Files'[/i]." & vbCrLf & "  - Existing Output file overwritten."
                        Catch ex As Exception
                            bProceed = False : aResult(0) = "-4" : aResult(1) = OutFileName
                            aResult(2) = "  - Unable to Delete Existing Output File [i]'" & OutFileName & "'[/i]." & vbCrLf & "  - File Skipped."
                        End Try

                    Case 1 'Skip
                        bProceed = False : aResult(0) = "3" : aResult(1) = ""
                        aResult(2) = "  - Program Setting [i]'Skip Existing Output Files'[/i]." & vbCrLf & "  - Output [b]'" & OutFileName & "'[/b] Skipped."
                    Case 3 'Ask    
                        If MsgBox("Output File: " & OutFileName & " already exists." & vbCrLf & "Do you want to overwrite it?", vbYesNo, "File Exists") = vbYes Then
                            IO.File.Delete(OutFileName)
                            bProceed = True : aResult(0) = "4" : aResult(1) = OutFileName
                            aResult(2) = "  - Manual Decision [i]'Overwrite Existing Output File'[/i]." & vbCrLf & "  - Existing Output file overwritten."
                        Else
                            bProceed = False : aResult(0) = "5" : aResult(1) = ""
                            aResult(2) = "  - Manual Decision [i]'Skip Existing Output File'[/i]." & vbCrLf & "  - Output [b]'" & OutFileName & "'[/b] Skipped."
                        End If
                    Case Else  'Auto-Ren
                        SF = IO.Path.GetFileNameWithoutExtension(OutFileName) & IO.Path.GetExtension(OutFileName)
                        sP = Left(OutFileName, Len(OutFileName) - Len(SF) - 1)
                        sE = IO.Path.GetExtension(OutFileName)
                        sB = Left(SF, Len(SF) - Len(sE))
                        DC = 1
                        sWorkFN = OutFileName
                        Do While IO.File.Exists(sWorkFN) = True
                            DC += 1 : sWorkFN = IO.Path.Combine(sP, sB & "(" & DC & ")" & sE)
                        Loop
                        If iOutExists = 2 Then 'Auto-Ren New
                            aResult(0) = "6" : aResult(1) = sWorkFN
                            aResult(2) = "  - Program Setting [i]'Auto-Rename New Output Files'[/i]." & vbCrLf & "  - Original Output file name: [b]'" & OutFileName & "'[/b]."
                            OutFileName = sWorkFN
                        End If
                        If iOutExists = 4 Then 'Auto-Ren Existing
                            aResult(0) = "7" : aResult(1) = OutFileName
                            aResult(2) = "  - Program Setting [i]'Auto-Rename Existing Output Files'[/i]. " & vbCrLf & "  - Exisiting File Renamed to: [b]'" & sWorkFN & "'[/b]."
                            IO.File.Move(OutFileName, sWorkFN)
                        End If
                        bProceed = True
                End Select
            End If
        Else
            bProceed = True : aResult(0) = "0" : aResult(1) = OutFileName : aResult(2) = ""
        End If

        If bProceed = True Then
            Try
                If isBinary = False Then
                    Using outfile As New StreamWriter(OutFileName)
                        outfile.Write(sStr)
                    End Using
                Else
                    '
                    If TypeOf sStr Is Bitmap Then
                        Dim f As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                        Dim img As Image = CType(sStr, Image)

                        Dim iThWidth As Integer = 150
                        Dim iSFact As Double = iThWidth / img.Width
                        Dim iThHeight As Integer = img.Height * iSFact

                        If bCreateThumbs = True Then
                            Select Case iThumbsResOpt
                                Case 0 'Scale Percent
                                    iThWidth = (img.Width / 100) * iThumbsScale
                                    iThHeight = (img.Height / 100) * iThumbsScale
                                Case 1
                                    iThWidth = iThumbsWidth
                                    iSFact = iThWidth / img.Width
                                    iThHeight = img.Height * iSFact
                                Case 2
                                    iThHeight = iThumbsHeight
                                    iSFact = iThHeight / img.Height
                                    iThWidth = img.Width * iSFact
                                Case 3
                                    iThWidth = iThumbsWidth
                                    iThHeight = iThumbsHeight
                            End Select
                            img = img.GetThumbnailImage(iThWidth, iThHeight, Nothing, Nothing)
                        End If
                        Select Case LCase(IO.Path.GetExtension(OutFileName))
                            Case ".png"
                                f = System.Drawing.Imaging.ImageFormat.Png
                            Case ".bmp"
                                f = System.Drawing.Imaging.ImageFormat.Bmp
                            Case ".gif"
                                f = System.Drawing.Imaging.ImageFormat.Gif
                            Case ".ico"
                                f = System.Drawing.Imaging.ImageFormat.Icon
                            Case ".emf"
                                f = System.Drawing.Imaging.ImageFormat.Emf
                            Case ".jpg"
                                f = System.Drawing.Imaging.ImageFormat.Jpeg
                            Case ".tif"
                                f = System.Drawing.Imaging.ImageFormat.Tiff
                            Case ".wmf"
                                f = System.Drawing.Imaging.ImageFormat.Wmf
                            Case Else
                                Throw New Exception()
                        End Select
                        img.Save(OutFileName, f)
                    ElseIf TypeOf sStr Is Byte() Then
                        Dim lngByte As Long = sStr.Length
                        Dim sw2 As New IO.FileStream(OutFileName, IO.FileMode.CreateNew, IO.FileAccess.Write)
                        sw2.Write(sStr, 0, lngByte)
                        sw2.Close()
                    Else
                        Throw New Exception()
                    End If

         
                End If
            Catch ex As Exception
                aResult(0) = "-4" : aResult(1) = OutFileName : aResult(2) = ex.Message
            End Try

        End If
        Return aResult
    End Function

    Public Function checkFileFormat(ByVal sFile As String) As FFormats
        Dim ReadTo As Integer = 3, Buf() As Byte = New Byte() {0, 0, 0}
        Dim sRes As FFormats = FFormats.us_ascii
        Dim i As Integer = 0
        Dim ofile As System.IO.FileStream
        If IO.File.Exists(sFile) Then
            ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.Read)
            ofile.Seek(0, IO.SeekOrigin.Begin)
            While i < ReadTo
                Buf(i) = ofile.ReadByte : i += 1
            End While
            ofile.Close()
            If Buf(0) = 239 And Buf(1) = 187 And Buf(2) = 191 Then
                sRes = FFormats.utf_8
            Else
                If Buf(0) = 255 And Buf(1) = 254 Then : sRes = FFormats.utf_16 : End If
            End If
        End If
        Return sRes
    End Function
    Public Function DetermineFileType(ByVal sFile As String) As FTypes
        Dim sRes As FTypes = FTypes.ASCII
        Dim eBte As Byte()
        Dim sData As String = ""
        Dim ofile As System.IO.FileStream
        If IO.File.Exists(sFile) Then
            ofile = IO.File.Open(sFile, IO.FileMode.Open, IO.FileAccess.Read)
            Dim iSize As Integer = ofile.Length - 1
            If iSize > 10000 Then iSize = 10000
            ReDim eBte(iSize)
            ofile.Seek(0, IO.SeekOrigin.Begin)
            ofile.Read(eBte, 0, iSize + 1)
            ofile.Close()
            sData = ByteArrayToString(eBte)
        End If
        If sData <> "" And Not sData Is Nothing Then
            If InStr(1, sData, Chr(27) & "[", CompareMethod.Text) > 0 Then
                If InStr(1, sData, Chr(27) & "[0;0;40m", CompareMethod.Text) > 0 Then
                    sRes = FTypes.WC2
                Else
                    sRes = FTypes.ANSI
                End If
            Else
                If InStr(1, sData, "<div", CompareMethod.Text) > 0 Or InStr(1, sData, "&lt;", CompareMethod.Text) > 0 _
                Or InStr(1, sData, "&nbsp;", CompareMethod.Text) > 0 Or InStr(1, sData, ";&#", CompareMethod.Text) > 0 Then
                    sRes = FTypes.HTML
                Else
                    If RegExTest(sData, "@X[0-9A-F]{2}", RegularExpressions.RegexOptions.Singleline) = True Then
                        sRes = FTypes.PCB
                    Else
                        If RegExTest(sData, "@[0-9A-F]{2}@", RegularExpressions.RegexOptions.Singleline) = True Then
                            sRes = FTypes.WC3
                        Else
                            If InStr(1, sData, Chr(22) & Chr(1), CompareMethod.Binary) > 0 Then
                                sRes = FTypes.AVT
                            Else
                                If InStr(1, sData, Chr(7), CompareMethod.Binary) > 0 Then
                                    sRes = FTypes.Bin
                                Else
                                    sRes = FTypes.ASCII
                                End If
                            End If

                        End If
                    End If
                End If
            End If
        End If
            Return sRes
    End Function
    Public Function GetFileSize(ByVal sFile As String) As String
        Dim oFile As FileInfo
        oFile = New FileInfo(sFile)
        Dim lSize As Double = oFile.Length
        Dim slSize As String = ""
        If lSize > 1024000000 Then 'GB
            slSize = CStr(USStringRound(lSize / 1024000000, 2)) & " GB"
        Else
            If lSize > 1024000 Then 'MB
                slSize = CStr(USStringRound(lSize / 1024000, 2)) & " MB"
            Else
                If lSize > 1024 Then     'KB
                    slSize = CStr(USStringRound(lSize / 1024, 2)) & " KB"
                Else  'Bytes
                    slSize = CStr(lSize) & " B"
                End If
            End If
        End If
        Return lSize
    End Function


    Public Function DetermineOutputFileName(ByVal sInpFile As String) As String
        Dim sDir As String = ""
        Dim sResult As String = ""

        sInpFile = IO.Path.GetFullPath(sInpFile)
        Dim sFile As String = IO.Path.GetFileName(sInpFile)
        Dim sFileBase As String = IO.Path.GetFileNameWithoutExtension(sInpFile)
        Dim sExt As String = "." & txtExt

        sDir = IIf(rOutPathInput, IO.Path.GetDirectoryName(sInpFile), outPath)
        sFile = IIf(rReplaceExt, sFileBase & sExt, sFile & sExt)
        sResult = IO.Path.Combine(sDir, sFile)

        Return sResult
    End Function
    '----------------------------------------------------
    '  Output Specific Formats from Gloabl "Screen" Array
    '  HTML Enc ASCII
    '  HTML Enc ANSI
    '  PCBoard @
    '  DOS Binary
    '----------------------------------------------------
    Public Function OutputASCHTML(ByVal sOutFile As String, ByVal sASC As String) As String()
        Dim sOut As String = "", sObjWidth As String = CStr(maxX * 8) & "px"
        Dim bteWork1 As Byte()
        Dim iLp2 As Integer = 0
        Dim iLen As Integer = 0

        If bHTMLComplete = True Then
            sOut &= "<html><head>" & vbCrLf
            sOut &= BuildCSSforHTML()
            sOut &= "</head><body>" & vbCrLf
        End If
        sOut &= "<div class=ANSICSS><pre>" & vbCrLf & "<span>"
        sOut &= sASC
        sOut &= "</span>" & vbCrLf & "</pre></div>" & vbCrLf

        If bHTMLComplete = True Then : sOut &= "</body></html>" : End If
        iLen = Microsoft.VisualBasic.Len(sOut)
        ReDim bteWork1(iLen - 1)
        For iLp2 = 1 To iLen
            bteWork1(iLp2 - 1) = Asc(Mid(sOut, iLp2, 1)) : System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            bteWork1 = MergeByteArrays(bteWork1, StrToByteArray(oSauce.BuildHTML(True)))
        End If
        Return WriteFile(sOutFile, bteWork1, bForceOverwrite, OutputFileExists, False, True)

    End Function

    Public Function BuildCSSforHTML() As String
        Dim sWorkCSS As String = sCSSDef
        Dim sObjWidth As String = CStr(maxX * 8) & "px"
        Dim sOut As String = ""

        If bCUFon = True Then
            sOut &= "<link rel=""stylesheet"" type=""text/css"" href=""style.css"">" & vbCrLf & _
                    "<script  type=""text/javascript"" src=""typeface-0.15.js""></script>" & vbCrLf & _
                    "<script  type=""text/javascript"" src=""msdos_fnt_vga_cp437_regular.typeface.js""></script>" & vbCrLf
        Else
            If bAnimation = True Then
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSDIV%", WebFontList.Item(SelectedWebFont).AnimEXTRACSSDIV, 1, -1, CompareMethod.Text)
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSPRE%", WebFontList.Item(SelectedWebFont).AnimEXTRACSSPRE, 1, -1, CompareMethod.Text)
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSSPAN%", WebFontList.Item(SelectedWebFont).AnimEXTRACSSSPAN, 1, -1, CompareMethod.Text)
            Else
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSDIV%", WebFontList.Item(SelectedWebFont).StaticEXTRACSSDIV, 1, -1, CompareMethod.Text)
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSPRE%", WebFontList.Item(SelectedWebFont).StaticEXTRACSSPRE, 1, -1, CompareMethod.Text)
                sWorkCSS = Replace(sWorkCSS, "%EXTRACSSSPAN%", WebFontList.Item(SelectedWebFont).StaticEXTRACSSSPAN, 1, -1, CompareMethod.Text)
            End If
            sWorkCSS = Replace(sWorkCSS, "%WIDTH%", sObjWidth, 1, -1, CompareMethod.Text)
            If bOutputSauce = True And bHasSauce = True Then
                sWorkCSS &= vbCrLf & sSauceCSS & vbCrLf
            End If
            sOut &= "<style>" & vbCrLf & sWorkCSS & vbCrLf & "</style>" & vbCrLf
        End If
        Return sOut
    End Function
    Public Function OutputHTML(ByVal sOutFile As String) As String()
        Dim sOut As String = "", sObjWidth As String = CStr(maxX * 8) & "px"
        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0
        If bHTMLComplete = True Then
            sOut &= "<html><head>" & vbCrLf
            sOut &= BuildCSSforHTML()
            sOut &= "</head><body>"
        End If

        If bCUFon = True Then
            sOut &= "<div class=""ANSICSS typeface-js"" style=""font-family:msdos_fnt_vga_cp437, Regular;font-weight: normal;font-size:1em;" & _
                     "width:" & sObjWidth & ";background-color:#000;color:#C6C6C6; padding: 0; margin: 0;""><pre>" & vbCrLf
        Else
            sOut &= "<div class=ANSICSS><pre>" & vbCrLf
        End If
        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If x = minX Then
                    sOut &= "<span class="""
                    If bCUFon = True Then : sOut &= "typeface-js " : End If
                    sOut &= aCSS(0, Screen(x, y).BackColor) & " " & aCSS(1, Screen(x, y).ForeColor + Screen(x, y).Bold)
                    sOut &= """>"
                End If
                If Screen(x, y).ForeColor + Screen(x, y).Bold <> ForeColor Or Screen(x, y).BackColor <> BackColor Then
                    sOut &= "</span><span class="""
                    If bCUFon = True Then : sOut &= "typeface-js " : End If
                    sOut &= aCSS(0, Screen(x, y).BackColor) & " " & aCSS(1, Screen(x, y).ForeColor + Screen(x, y).Bold) & """>"
                    ForeColor = Screen(x, y).ForeColor + Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr <> Chr(255) Then : sOut &= Screen(x, y).Chr : Else : sOut &= "&nbsp;" : End If
                Else
                    x = maxX
                End If
                If x = maxX Then : sOut &= "</span>" : End If
            Next
            sOut &= vbCrLf
            System.Windows.Forms.Application.DoEvents()
        Next
        sOut &= "</span></pre></div>"
        If bCUFon = True Then
            sOut &= "<script language=""Javascript"">" & vbCrLf & _
                    " _typeface_js.initialize();" & vbCrLf & _
                    "</script>" & vbCrLf
        End If
        If bOutputSauce = True And bHasSauce = True Then
            sOut &= oSauce.BuildHTML(True)
        End If
        If bHTMLComplete = True Then : sOut &= "</body></html>" : End If

        Return WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

    End Function

    Public Function OutputPCB(ByVal sOutFile As String) As String()
        Dim sOut As String = ""

        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0
        sOut = "@X" & Hex(BackColor) & Hex(ForeColor)

        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If Screen(x, y).ForeColor + Screen(x, y).Bold <> ForeColor Or Screen(x, y).BackColor <> BackColor Then
                    sOut = sOut & "@X" & Hex(Screen(x, y).BackColor) & Hex(Screen(x, y).ForeColor + Screen(x, y).Bold)
                    ForeColor = Screen(x, y).ForeColor + Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr <> Chr(255) Then : sOut = sOut & Screen(x, y).Chr : Else : sOut = sOut : End If
                Else
                    x = maxX : Exit For
                End If
            Next
            sOut &= vbCrLf
            System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            sOut &= oSauce.toString()
        End If
        Return WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

    End Function

    Public Function OutputAVT(ByVal sOutFile As String) As String()
        Dim sOut As String = ""

        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0

        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If Screen(x, y).ForeColor + Screen(x, y).Bold <> ForeColor Or Screen(x, y).BackColor <> BackColor Then
                    ForeColor = Screen(x, y).ForeColor + Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                    sOut = sOut & Chr(22) & Chr(1) & Chr(BackColor * 16 + ForeColor)
                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr <> Chr(255) Then : sOut = sOut & Screen(x, y).Chr : Else : sOut = sOut : End If
                Else
                    x = maxX : Exit For
                End If
            Next
            sOut &= vbCrLf
            System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            sOut &= oSauce.toString()
        End If
        Return WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

    End Function
    Public Function OutputWC2(ByVal sOutFile As String) As String()
        Dim sOut As String = ""
        Dim aWCF As Byte() = New Byte() {30, 34, 32, 36, 31, 35, 33, 37}
        Dim aWCB As Byte() = New Byte() {40, 44, 42, 46, 41, 45, 43, 47}

        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0 : Bold = 0

        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If Screen(x, y).ForeColor <> ForeColor Or Screen(x, y).BackColor <> BackColor Or Screen(x, y).Bold <> Bold Then
                    ForeColor = Screen(x, y).ForeColor
                    Bold = Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                    If ForeColor + Bold = 7 And BackColor = 0 Then
                        sOut = sOut & Chr(27) & "[0;0;40m"
                    Else
                        sOut = sOut & Chr(27) & "[" & Bold / 8 & ";" & aWCF(ForeColor) & ";" & aWCB(BackColor) & "m"
                    End If
                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr <> Chr(255) Then : sOut = sOut & Screen(x, y).Chr : Else : sOut = sOut : End If
                Else
                    x = maxX : Exit For
                End If
            Next
            sOut &= vbCrLf
            System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            sOut &= oSauce.toString()
        End If
        Return WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

    End Function
    Public Function OutputWC3(ByVal sOutFile As String) As String()
        Dim sOut As String = ""

        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0
        sOut = "@" & Hex(BackColor) & Hex(ForeColor) & "@"

        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If Screen(x, y).ForeColor + Screen(x, y).Bold <> ForeColor Or Screen(x, y).BackColor <> BackColor Then
                    ForeColor = Screen(x, y).ForeColor + Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                    sOut = sOut & "@" & Hex(BackColor) & Hex(ForeColor) & "@"
                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr <> Chr(255) Then : sOut = sOut & Screen(x, y).Chr : Else : sOut = sOut : End If
                Else
                    x = maxX : Exit For
                End If
            Next
            sOut &= vbCrLf
            System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            sOut &= oSauce.toString()
        End If
        Return WriteFile(sOutFile, sOut, bForceOverwrite, OutputFileExists, False, False)

    End Function

    Public Function OutputANS(ByVal sOutFile As String) As String()
        Dim aOut(1000) As Byte
        Dim Cnt As Integer = 0
        Dim iWhatChange As Integer = 0
        Dim x As Integer, y As Integer
        Dim bRest As Boolean = False
        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0 : Bold = 0 : Reversed = False
        For y = minY To LinesUsed
            For x = minX To maxX
                If Screen(x, y).Chr = "-1" Then
                    Screen(x, y).Chr = Chr(32)
                End If
            Next
        Next

        For y = minY To LinesUsed
            If y = minY Then
                '<[255D
                aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1 : aOut(Cnt) = 50 : Cnt += 1
                aOut(Cnt) = 50 : Cnt += 1 : aOut(Cnt) = 53 : Cnt += 1 : aOut(Cnt) = 68 : Cnt += 1
            End If
            bRest = False
            For x = minX To maxX
                '0 = 48, 1 = 49, 59 = ; 109 = m
                iWhatChange = 0
                If x = minX And y > minY Then
                    iWhatChange = 14
                Else
                    If Screen(x, y).ForeColor <> ForeColor Then
                        iWhatChange += 2
                    End If
                    If Screen(x, y).Bold <> Bold Then
                        iWhatChange += 4
                    End If
                    If Screen(x, y).BackColor <> BackColor Then
                        iWhatChange += 8
                    End If
                End If

                If iWhatChange <> 0 Then
                    ForeColor = Screen(x, y).ForeColor
                    Bold = Screen(x, y).Bold
                    BackColor = Screen(x, y).BackColor
                    If iWhatChange > 9 Then 'all changed
                        aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1
                        aOut(Cnt) = IIf(Bold <> 0, 49, 48) : Cnt += 1
                        aOut(Cnt) = 59 : Cnt += 1
                        aOut(Cnt) = Asc(Left(AnsiForeColors(ForeColor), 1)) : Cnt += 1
                        aOut(Cnt) = Asc(Right(AnsiForeColors(ForeColor), 1)) : Cnt += 1
                        aOut(Cnt) = 59 : Cnt += 1
                        aOut(Cnt) = Asc(Left(AnsiBackColors(BackColor), 1)) : Cnt += 1
                        aOut(Cnt) = Asc(Right(AnsiBackColors(BackColor), 1)) : Cnt += 1
                        aOut(Cnt) = 109 : Cnt += 1
                    Else
                        If iWhatChange = 8 Then 'Back color only
                            aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1
                            aOut(Cnt) = Asc(Left(AnsiBackColors(BackColor), 1)) : Cnt += 1
                            aOut(Cnt) = Asc(Right(AnsiBackColors(BackColor), 1)) : Cnt += 1
                            aOut(Cnt) = 109 : Cnt += 1
                        Else
                            aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1
                            aOut(Cnt) = IIf(Bold <> 0, 49, 48) : Cnt += 1
                            aOut(Cnt) = 59 : Cnt += 1
                            aOut(Cnt) = Asc(Left(AnsiForeColors(ForeColor), 1)) : Cnt += 1
                            aOut(Cnt) = Asc(Right(AnsiForeColors(ForeColor), 1)) : Cnt += 1
                            aOut(Cnt) = 109 : Cnt += 1
                        End If
                    End If

                End If
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr = Chr(32) Then
                        Dim iSpc As Integer = NumSpaces(x, y)
                        If iSpc > maxX Then
                            '<[XC move cursor right
                            aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1
                            For iLoop2 As Integer = 1 To iSpc.ToString.Length
                                aOut(Cnt) = Asc(Mid(iSpc.ToString, iLoop2, 1)) : Cnt += 1
                            Next
                            aOut(Cnt) = 67 : Cnt += 1
                            x += iSpc - 1
                        Else
                            aOut(Cnt) = Asc(Screen(x, y).Chr) : Cnt += 1
                        End If
                    Else
                        aOut(Cnt) = Asc(Screen(x, y).Chr) : Cnt += 1
                    End If
                Else
                    aOut(Cnt) = 32 : Cnt += 1
                End If
                If x >= maxX Then
                    '<[s
                    aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1 : aOut(Cnt) = 115 : Cnt += 1
                    bRest = True
                End If
                If Cnt > UBound(aOut) - 20 Then : ReDim Preserve aOut(UBound(aOut) + 1000) : End If
            Next
            'linebreak
            aOut(Cnt) = 13 : Cnt += 1 : aOut(Cnt) = 10 : Cnt += 1
            If bRest = True Then
                '<[u
                aOut(Cnt) = 27 : Cnt += 1 : aOut(Cnt) = 91 : Cnt += 1 : aOut(Cnt) = 117 : Cnt += 1

            End If

            If Cnt > UBound(aOut) - 20 Then : ReDim Preserve aOut(UBound(aOut) + 1000) : End If
        Next
        ReDim Preserve aOut(Cnt)
        If bOutputSauce = True And bHasSauce = True Then
            aOut = MergeByteArrays(aOut, oSauce.toByteArray)
        End If
        Return WriteFile(sOutFile, aOut, bForceOverwrite, OutputFileExists, False, True)
        Erase aOut
    End Function
    Public Function NumSpaces(ByVal xOffset As Integer, ByVal yOffset As Integer) As Integer
        Dim iNums As Integer = 1, bEnd As Boolean = False
        Dim iCnter As Integer = xOffset
        Do While bEnd = False
            If maxX >= iCnter + 1 Then
                iCnter += 1
                If Screen(iCnter, yOffset).Chr = Chr(32) Then
                    iNums += 1
                Else
                    bEnd = True
                End If
            Else
                bEnd = True
            End If
        Loop
        Return iNums
    End Function
    Public Function OutputBin(ByVal sOutFile As String) As String()
        XPos = minX : YPos = minY : ForeColor = 7 : BackColor = 0
        Dim aOut((LinesUsed * (maxX * 2)) - 1) As Byte
        Dim Cnt As Integer = 0
        Dim intC As Integer = 0
        Dim bFiller As Boolean = False

        For y As Integer = minY To LinesUsed
            For x As Integer = minX To maxX
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr = Chr(255) Then : bFiller = True : End If
                Else
                    bFiller = True
                End If
                If bFiller = True Then
                    ForeColor = DefForeColor : BackColor = DefBackColor : intC = 0
                Else
                    ForeColor = Screen(x, y).ForeColor + Screen(x, y).Bold : BackColor = Screen(x, y).BackColor : intC = Asc(Screen(x, y).Chr)
                End If
                aOut(Cnt) = intC : Cnt += 1
                aOut(Cnt) = System.Convert.ToInt32(Hex(BackColor) & Hex(ForeColor), 16) : Cnt += 1
            Next
            bFiller = False : System.Windows.Forms.Application.DoEvents()
        Next
        If bOutputSauce = True And bHasSauce = True Then
            aOut = MergeByteArrays(aOut, oSauce.toByteArray)
        End If
        Return WriteFile(sOutFile, aOut, bForceOverwrite, OutputFileExists, False, True)
        Erase aOut

    End Function




End Module
