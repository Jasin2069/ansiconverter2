Module Module1
    Public ToolVersion As String = My.Application.Info.Version.ToString '"1.04.00"
    Public Const ToolVersionDate = "03.2012"
    Public Const bDebug As Boolean = False
    Public bInputFile As Boolean = True
    Public oConv As New Converter.ProcessFiles

    Public F As New System.Windows.Forms.Form
    Public TT As New System.Windows.Forms.ToolTip
    Public sCodePg As String = "CP437"
    Public bHTMLEncode As Boolean = True
    Public bHTMLComplete As Boolean = True
    Public bSanitize As Boolean = False
    Public pSauce As String = "Strip"
    Public pAnim As String = "Static"
    Public pUTF As String = "UTF16"
    Public bCUFon As Boolean = False
    Public OutputFileExists As Integer = 0
    Public bConv2Unicode As Boolean
    Public sOutPutFormat As String = ""
    Public bOutputSauce As Boolean = False
    Public bAnimation As Boolean = False
    Public txtExt As String = ""
    Public bOutPathInput As Boolean = True
    Public sHTMLFont As String = "Default"
    Public bReplaceExt As Boolean = False
    Public soutPath As String = ""
    Public bForceOverwrite As Boolean = False
    Public CPS As AnsiCPMaps.AnsiCPMaps = AnsiCPMaps.AnsiCPMaps.Instance
    Public bShowHelp As Boolean = False
    Public bShowCPList As Boolean = False
    Public sExtFilter As String = ""
    Public aExtFilter() As String
    Public sInputPath As String = ""
    Private aFTCounts(5) As Integer
    Private iNumProc As Integer = 0
    Private iNumDone As Integer = 0
    Public bNoColors As Boolean = False
    Public bSmallFont As Boolean = False
    Private iOutFormat As FTypes
    Private bThumb As Boolean = False
    Private iThumbResOpt As Integer = 0
    Private iThumbProp As Integer = 0
    Private iThumbWidth As Integer = 0
    Private iThumbHeight As Integer = 0
    Private pFPS As Double = 30.0
    Private pBPS As Integer = 28800
    Private pExtend As Integer = 3
    Private sCodec As String = ""
    Private aCodecs As Object(,) = New Object(,) {{"AVI", New String() {"ZMBV", "H264", "FFVI", "MPEG4", "MJPEG", "LIBX264", "LIBXVID"}}, _
                                                  {"MPG", New String() {"MPEG1", "MPEG2"}}, _
                                                  {"WMV", Nothing}, {"MP4", Nothing}, {"FLV", Nothing}, {"GIF", Nothing}, {"MKV", Nothing}, {"VOB", Nothing}}
    Private aImages As String() = New String() {"PNG", "GIF", "BMP", "JPG", "TIF", "ICO", "WMF", "EMF"}
    Private aHTML As String() = New String() {"HTM", "WEB"}
    Private aOutputs As String() = New String() {"ASC", "ANS", "HTML", "UTF8", "UTF16", "PCB", "WC2", "WC3", "AVT", "BIN", "IMG", "VID"}
    Private aExt As Object() = New Object() {Nothing, Nothing, aHTML, New String() {"TXT"}, New String() {"TXT"}, Nothing, Nothing, Nothing, Nothing, Nothing, aImages, aCodecs}

    Public Enum FFormats
        us_ascii = 0
        utf_8 = 1
        utf_16 = 2
        utf_7 = 3
        utf_32 = 4
    End Enum
    Public Enum FTypes
        ASCII = 0
        ANSI = 1
        HTML = 2
        Unicode = 3
        PCB = 4
        Bin = 5
        WC2 = 6
        WC3 = 7
        AVT = 8
        IMG = 9
        VID = 10
    End Enum

    Public Sub evHandlerInfoMsg(ByVal Msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
        Console.Out.WriteLine(StripMessageFormatting(Msg))
    End Sub
    Public Sub evHandlerErrMsg(ByVal Msg As String)
        Console.Error.WriteLine(StripMessageFormatting(Msg))
    End Sub

    Public Sub evHandlerAdjustnumTotal(ByVal value As Integer)

    End Sub
    Public Sub evHandlerProcessedFile(ByVal idx As Integer)
        iNumDone += 1
        Console.WriteLine(iNumDone.ToString & " of " & iNumProc.ToString & " files processed.")
        Console.WriteLine("")
    End Sub

    Public Function StripMessageFormatting(ByVal sMsg As String) As String
        Dim sResult As String = sMsg
        sResult = Replace(sResult, "[b]", "", 1, -1, CompareMethod.Text)
        sResult = Replace(sResult, "[/b]", "", 1, -1, CompareMethod.Text)
        sResult = Replace(sResult, "[i]", "", 1, -1, CompareMethod.Text)
        sResult = Replace(sResult, "[/i]", "", 1, -1, CompareMethod.Text)
        sResult = Replace(sResult, "[u]", "", 1, -1, CompareMethod.Text)
        sResult = Replace(sResult, "[/u]", "", 1, -1, CompareMethod.Text)
        Return sResult
    End Function
    Sub Main()
        AddHandler oConv.ProcessedFile, AddressOf evHandlerProcessedFile
        AddHandler oConv.InfoMsg, AddressOf evHandlerInfoMsg
        AddHandler oConv.ErrMsg, AddressOf evHandlerErrMsg
        AddHandler oConv.AdjustnumTotal, AddressOf evHandlerAdjustnumTotal
        Converter.MForm = F
        Converter.ToolTip = TT


        Dim iArgs As Integer = My.Application.CommandLineArgs.Count()
        Dim iVal As Integer = 0
        Dim dVal As Double = 0
        Dim sVal As String = ""
        Dim a As Integer = 0
        Dim index As Integer = 0
        Dim bNamedParam As Boolean = False
        Dim sNamedParam As String = ""
        Dim sPath As String = ""
        Dim bError As Boolean = False
        If iArgs > 0 Then
            If bDebug = True Then
                For a = 0 To iArgs - 1
                    Dim sParam As String = My.Application.CommandLineArgs.Item(a)
                    Console.WriteLine(Strings.Right("     " & a.ToString, 5) & "." & sParam)
                Next
                Console.WriteLine("... End Params")
            End If

            For a = 0 To iArgs - 1
                bNamedParam = False
                Dim sParam As String = My.Application.CommandLineArgs.Item(a)
                If Microsoft.VisualBasic.Left(sParam, 1) = "/" And InStr(sParam, ":", CompareMethod.Text) > 2 Then
                    sNamedParam = Strings.Left(sParam, InStr(sParam, ":", CompareMethod.Text))
                    bNamedParam = True
                End If
                If bNamedParam = True Then
                    sVal = Microsoft.VisualBasic.Right(sParam, Len(sParam) - Len(sNamedParam))
                    Select Case LCase(sNamedParam)
                        Case "/ftyp:"
                            sExtFilter = sVal
                            aExtFilter = Split(sVal, ",")
                        Case "/out:"
                            sVal = Trim(UCase(sVal))
                            Select Case sVal
                                Case "ASC"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.ASCII
                                Case "ANS"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.ANSI
                                Case "HTML"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.HTML
                                Case "UTF8"
                                    pUTF = "UTF8"
                                    sOutPutFormat = "UTF"
                                    iOutFormat = FTypes.Unicode
                                Case "UTF16"
                                    pUTF = "UTF16"
                                    sOutPutFormat = "UTF"
                                    iOutFormat = FTypes.Unicode
                                Case "PCB"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.PCB
                                Case "WC2"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.WC2
                                Case "WC3"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.WC3
                                Case "AVT"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.AVT
                                Case "VID"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.VID
                                Case "BIN"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.Bin
                                Case "IMG"
                                    sOutPutFormat = sVal
                                    iOutFormat = FTypes.IMG
                                Case Else
                                    Console.Error.WriteLine("'" & sVal & "' is not a valid value for the /OUT: Format Option.")
                                    bError = True
                            End Select

                        Case "/font:"
                            sHTMLFont = sVal
                        Case "/nocol:"
                            bNoColors = True
                        Case "/small:"
                            bSmallFont = True
                        Case "/save:"
                            sVal = Trim(sVal)
                            Try
                                If IO.Directory.Exists(sVal) Then
                                    soutPath = sVal
                                    bOutPathInput = False
                                Else
                                    Console.Error.WriteLine("'" & sVal & "' is not a valid output path or does not exist.")
                                    bError = True
                                End If
                            Catch ex As Exception
                                Console.Error.WriteLine("'" & sVal & "' is not a valid output path or does not exist.")
                                bError = True
                            End Try
                        Case "/ext:"
                            bReplaceExt = True
                            txtExt = sVal
                        Case "/newext:"
                            bReplaceExt = False
                            txtExt = sVal
                        Case "/over:"
                            sVal = Trim(UCase(sVal))
                            Select Case sVal
                                Case "OVER"
                                    OutputFileExists = 0
                                Case "SKIP"
                                    OutputFileExists = 1
                                Case "REN"
                                    OutputFileExists = 2
                                Case Else
                                    Console.Error.WriteLine("'" & sVal & "' is not a valid option for the /OVER: Option.")
                                    bError = True
                            End Select
                        Case "/thumbscale:"
                            sVal = Trim(UCase(sVal))
                            Select Case sVal
                                Case "PROP"
                                    iThumbResOpt = 0
                                Case "WIDTH"
                                    iThumbResOpt = 1
                                Case "HEIGHT"
                                    iThumbResOpt = 2
                                Case "CUSTOM"
                                    iThumbResOpt = 3
                            End Select
                        Case "/scale:"
                            If IsNumeric(sVal) Then
                                iThumbProp = Math.Abs(CInt(sVal))
                            End If

                        Case "/width:"
                            If IsNumeric(sVal) Then
                                iThumbWidth = Math.Abs(CInt(sVal))
                            End If
                        Case "/height:"
                            If IsNumeric(sVal) Then
                                iThumbHeight = Math.Abs(CInt(sVal))
                            End If
                        Case "/cp:"
                            If CodePageExists(Trim(sVal)) Then
                                sCodePg = Trim(UCase(sVal))
                            Else
                                Console.Error.WriteLine("'" & sVal & "' is not a valid code page value.")
                                bError = True
                            End If
                        Case "/codec:"
                            sCodec = sVal
                        Case "/fps:"
                            If IsNumeric(sVal) Then
                                pFPS = Math.Abs(CDbl(sVal))
                            End If
                        Case "/bps:"
                            If IsNumeric(sVal) Then
                                pBPS = Math.Abs(CInt(sVal))
                            End If
                        Case "/extend:"
                            If IsNumeric(sVal) Then
                                pExtend = Math.Abs(CInt(sVal))
                            End If
                    End Select
                Else
                    Select Case LCase(sParam)
                        Case "/?"
                            bShowHelp = True
                        Case "/h"
                            bShowHelp = True
                        Case "/help"
                            bShowHelp = True
                        Case "/cplist"
                            bShowCPList = True
                        Case "/sanitize"
                            bSanitize = True
                        Case "/anim"
                            pAnim = "Anim"
                            bAnimation = True
                        Case "/sauce"
                            pSauce = "Keep"
                            bOutputSauce = True
                        Case "/object"
                            bHTMLComplete = False
                        Case "/thumb"
                            bThumb = True
                        Case Else
                            sInputPath = sParam
                    End Select
                End If
            Next

            If bThumb = True Then
                Select Case iThumbResOpt
                    Case 0
                        If iThumbProp = 0 Then
                            Console.Error.WriteLine("/SCALE parameter not provided for proportional thumbnail scaling.")
                            bError = True
                        End If
                    Case 1
                        If iThumbWidth = 0 Then
                            Console.Error.WriteLine("/WIDTH parameter not provided for proportional fixed width thumbnail scaling.")
                            bError = True

                        End If
                    Case 2
                        If iThumbHeight = 0 Then
                            Console.Error.WriteLine("/HEIGHT parameter not provided for proportional fixed height thumbnail scaling.")
                            bError = True

                        End If

                    Case 3
                        If iThumbWidth = 0 Or iThumbHeight = 0 Then
                            Console.Error.WriteLine("/WIDTH and/or /HEIGHT parameter(s) not provided for custom size thumbnail scaling.")
                            bError = True
                        End If
                End Select
            End If
            If bShowHelp = True Then
                Call HelpMessage()
                End
            End If
            If bShowCPList = True Then
                Call BuildCPList()
                End
            End If
            If sInputPath = "" Then
                Console.Error.WriteLine("Input File/Folder Path are missing.")
                bError = True
            Else
                Try
                    If IO.Directory.Exists(sInputPath) Then
                        bInputFile = False
                        Call BuildFileList(sInputPath)
                        If Converter.ListInputFiles.Count = 0 Then
                            Console.Error.WriteLine("Input Folder: '" & sInputPath & "' no files to process found.")
                            bError = True
                        Else
                            Console.WriteLine("# Files to Process: " & Converter.ListInputFiles.Count & ", Break down by Type: ")
                            Dim sTmp As String = ""
                            For b As Integer = 0 To 5
                                If aFTCounts(b) <> 0 Then
                                    Select Case b
                                        Case 0
                                            sTmp &= ", ASC: "
                                        Case 1
                                            sTmp &= ", ANS: "
                                        Case 2
                                            sTmp &= ", HTM: "
                                        Case 3
                                            sTmp &= ", UTF: "
                                        Case 4
                                            sTmp &= ", PCB: "
                                        Case 5
                                            sTmp &= ", BIN: "
                                        Case 6
                                            sTmp &= ", WC2: "
                                        Case 7
                                            sTmp &= ", WC3: "
                                        Case 8
                                            sTmp &= ", AVT: "

                                    End Select
                                    sTmp &= aFTCounts(b).ToString
                                End If
                            Next
                            If sTmp <> "" Then
                                sTmp = Strings.Right(sTmp, sTmp.Length - 2)
                            End If
                            Console.WriteLine(sTmp)
                            Console.WriteLine("")
                        End If
                    Else
                        If IO.File.Exists(sInputPath) Then
                            bInputFile = True
                            Try
                                Call AddFile(sInputPath)
                            Catch ex As Exception

                            End Try
                            If Converter.ListInputFiles.Count = 0 Then
                                Console.Error.WriteLine("Input File: '" & sInputPath & "' cannot be processed. Unknow/Unsupported File Type or not accessible.")
                                bError = True
                            End If
                        Else
                            Console.Error.WriteLine("Input File/Folder Path: '" & sInputPath & "' does not exist.")
                            bError = True
                        End If
                    End If
                Catch ex As Exception
                    Console.Error.WriteLine("Invalid Input File/Folder Path Value: '" & sInputPath & "'.")
                    bError = True
                End Try
            End If
            If sOutPutFormat = "" Then
                Console.Error.WriteLine("Output Format was not specified.")
                bError = True
            End If
            If bError = True Then
                Console.Error.WriteLine("Start with /h option for Help.")
                End
            End If
            If txtExt = "" Then
                Select Case sOutPutFormat
                    Case "HTML"
                        If bHTMLComplete = False Then
                            txtExt = "WEB"
                        Else
                            txtExt = "HTM"
                        End If
                    Case "UTF"
                        txtExt = "TXT"
                    Case "IMG"
                        txtExt = "PNG"
                    Case "VID"
                        txtExt = "AVI"
                    Case Else
                        txtExt = sOutPutFormat
                End Select
            End If
            Dim sStr As String = ""
            iNumProc = Converter.ListInputFiles.Count
            Console.WriteLine("Output Format: " & sOutPutFormat)
            Select Case sOutPutFormat
                Case "HTML"
                    sStr = "Sanitize: "
                    If bSanitize Then
                        sStr &= "YES"
                    Else
                        sStr &= "NO"
                    End If
                    sStr &= ", Full HTML: "
                    If bHTMLComplete Then
                        sStr &= "YES"
                    Else
                        sStr &= "NO"
                    End If
                    sStr &= ", Anim: "
                    If bAnimation Then
                        sStr &= "YES"
                    Else
                        sStr &= "NO"
                    End If
                    Console.WriteLine(sStr)
                    Console.WriteLine("Font: " & sHTMLFont)
                Case "UTF"
                    sStr = "Unicode Format: " & pUTF
                    Console.WriteLine(sStr)
                Case "IMG"
                    sStr = "No Colors?: " & bNoColors.ToString
                    sStr &= ", Small Font: " & bSmallFont.ToString & vbCrLf
                    Console.WriteLine(sStr)
                    If bThumb Then
                        sStr = "Create Thumbnails."
                        Select Case iThumbResOpt
                            Case 0
                                sStr &= " Scale to: " & iThumbProp & "% of org image size."
                            Case 1
                                sStr &= " Fixed width: " & iThumbWidth & " pixels."
                            Case 2
                                sStr &= " Fixed Height: " & iThumbHeight & " pixels."
                            Case 3
                                sStr &= " Custom Size: " & iThumbWidth & "x" & iThumbHeight & " pixels."
                        End Select
                        Console.WriteLine(sStr)
                    End If
                Case "VID"
                    sStr = "FPS: " & pFPS.ToString & ", BPS: " & pBPS.ToString
                    If UCase(txtExt) = "AVI" Or UCase(txtExt) = "MPG" Then
                        sStr &= ", Codec: " & sCodec
                    End If
                    Console.WriteLine(sStr)
                    sStr = "Extend Last Frame by " & pExtend & " seconds."
                    Console.WriteLine(sStr)
            End Select
            sStr = "Output Path: "
            If bOutPathInput Then
                sStr &= " as input"
            Else
                sStr &= soutPath
            End If
            Console.WriteLine(sStr)
            sStr = "Extension: " & txtExt
            If bReplaceExt Then
                sStr &= " (Replace)"
            Else
                sStr &= " (Add)"
            End If
            Console.WriteLine(sStr)
            sStr = "Keep Sauce Meta: "
            If bOutputSauce Then
                sStr &= "YES"
            Else
                sStr &= "NO"
            End If
            Console.WriteLine("CodePage: " & sCodePg)

            Console.WriteLine(sStr)
            Console.WriteLine("----------------------------------------------------------")
            Converter.txtExt = txtExt
            Converter.rOutPathInput = bOutPathInput
            Converter.rReplaceExt = bReplaceExt
            Converter.outPath = soutPath
            Converter.bForceOverwrite = bForceOverwrite
            Converter.sHTMLFont = sHTMLFont
            Converter.pOutExist = OutputFileExists
            Converter.bCreateThumbs = bThumb
            Converter.iThumbsResOpt = iThumbResOpt
            Converter.iThumbsScale = iThumbProp
            Converter.iThumbsWidth = iThumbWidth
            Converter.iThumbsHeight = iThumbHeight
            Converter.sOutPutFormat = sOutPutFormat
            Converter.pOut = sOutPutFormat
            'sInputFormat = MainForm.pIn.Tag.ToString
            Converter.bOutputSauce = bOutputSauce
            Converter.pAnim = pAnim
            Converter.pSauce = pSauce

            Converter.bAnimation = bAnimation
            Converter.bRemoveCompleted = True

            Converter.bSanitize = bSanitize
            Converter.pSanitize = bSanitize
            Converter.pCP = sCodePg
            Converter.sCodePg = sCodePg
            Converter.pNoColors = bNoColors
            Converter.pSmallFont = bSmallFont
            Converter.pHTMLEncode = bHTMLEncode
            Converter.pHTMLComplete = bHTMLComplete
            Converter.selUTF = pUTF
            Converter.BPS = pBPS
            Converter.FPS = pFPS
            Converter.LastFrame = pExtend
            If sOutPutFormat = "VID" Then
                Select Case UCase(txtExt)
                    Case "AVI"
                        Converter.VidCodec = sCodec
                    Case "MPG"
                        Converter.VidCodec = sCodec
                    Case Else
                        Converter.VidCodec = ""
                End Select
            End If
            oConv.ConvertAllFiles()
            Console.WriteLine("DONE PROCESSING!")
            Console.WriteLine("... bye See you next time. Roy/SAC.")
        Else
            Call HelpMessage()
        End If
    End Sub

    Private Sub HelpMessage()

        Console.WriteLine("")
        Console.WriteLine("============================================================================")
        Console.WriteLine("ANSI/ASCII Converter CLI by Carsten Cumbrowski aka Roy/SAC (Freeware)")
        Console.WriteLine("Version: " & ToolVersion & ", From: " & ToolVersionDate)
        Console.WriteLine("============================================================================")
        Console.WriteLine("")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("ANSI/ASCII Converter CLI Usage:")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("ANSIASCIIConverterCLI ""[drive:][path][filename]"" /OUT:<FORMAT> [/FTYP:<EXT>,..]")
        Console.WriteLine("                   [/SAVE:<PATH>] [/EXT:<EXT>]|[/NEWEXT:<EXT>] [/OVER:<OPTION>]")
        Console.WriteLine("             [/CP<CP>] [/FONT:<FONTNAME>] [/SANITIZE] [/SAUCE] [OBJECT] [/ANIM]")
        Console.WriteLine("   [/THUMB] [/THUMBSCALE: <OPT>] [/SCALE: <NUM>] [/WIDTH:<NUM>] [/HEIGHT:<NUM>]")
        Console.WriteLine("                    [/CODEC: <ID>] [/FPS: <NUM>] [/BPS: <NUM>] [/EXTEND: <NUM>]")
        Console.WriteLine("")
        Console.WriteLine("   -or-")
        Console.WriteLine("")
        Console.WriteLine("ANSIASCIIConverterCLI [/H]|[/?]|[/HELP]")
        Console.WriteLine("")
        Console.WriteLine("   -or-")
        Console.WriteLine("")
        Console.WriteLine("ANSIASCIIConverterCLI [/CPLIST]")
        Console.WriteLine("")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("Required Parameters:")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("")
        Console.WriteLine("""[drive:][path][filename]""")
        Console.WriteLine("  Specifies a folder or file to process")
        Console.WriteLine("")
        Console.WriteLine("/OUT:<ASC|ANS|HTML|UTF8|UTF16|PCB|WC2|WC3|AVT|BIN|IMG|VID>")
        Console.WriteLine("   (Required) Output-format. ")
        Console.WriteLine("    Supported Values: ASC|ANS|HTML|UTF8|UTF16|PCB|WC2|WC3|AVT|BIN|IMG|VID")
        Console.WriteLine("")
        Console.WriteLine("   For Image outputs does the Extension determine the Image format.")
        Console.WriteLine("   Supported are: PNG, BMP, JPG, GIF, TIF, ICO, WMF, EMF")
        Console.WriteLine("")
        Console.WriteLine("   For Video outputs does the Extension determine the Video format.")
        Console.WriteLine("   Supported are: AVI, WMV, MP4, MKV, FLI, GIF (Animated), MPG, VOB")
        Console.WriteLine("")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("Optional Parameters:")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("")
        Console.WriteLine("/FTYP:<EXT>,...")
        Console.WriteLine("   (Optional) List of file extensions to include (Folder processing). ")
        Console.WriteLine("   Separated by comma, without the "".""")
        Console.WriteLine("")
        Console.WriteLine("/SAVE:<PATH>")
        Console.WriteLine("   (Optional) New Output Path (default uses Input Folder for outputs)")
        Console.WriteLine("")
        Console.WriteLine("/EXT:<EXT>")
        Console.WriteLine("   (Optional) Output, replaces extension of source with <EXT>")
        Console.WriteLine("")
        Console.WriteLine(" -or-")
        Console.WriteLine("")
        Console.WriteLine("/NEWEXT:<EXT>")
        Console.WriteLine("   (Optional) Output, add <EXT> to source for output file name. (Default)")
        Console.WriteLine("")
        Console.WriteLine("/OVER:<OVER|SKIP|REN> Default: OVER")
        Console.WriteLine("   (Optional) Output, handleing of existing output files. ")
        Console.WriteLine("   Values: ""OVER""=Overwrite, ""SKIP""=Skip File or ""REN""=Auto-Rename")
        Console.WriteLine("")
        Console.WriteLine("/CP:<CP> Default: CP437 (US)")
        Console.WriteLine("   (Optional) CodePage. Only if conversion involves any ASCII Format ")
        Console.WriteLine("   (ASC, ANS, PCB, BIN) and any Unicode Format (UTF, HTML) in any direction.")
        Console.WriteLine("   For list of available CodePage values, use /CPLIST paramter.")
        Console.WriteLine("")
        Console.WriteLine("/FONT:<FontName> Default: Default")
        Console.WriteLine("   (Optional) For HTML Output, Font Name for CSS")
        Console.WriteLine("")
        Console.WriteLine("/SANITIZE")
        Console.WriteLine("   (Optional) For HTML Output, Convert TABs to SPACES etc.")
        Console.WriteLine("")
        Console.WriteLine("/SAUCE")
        Console.WriteLine("   (Optional) Convert SAUCE Meta Tag to new Format (if supported)")
        Console.WriteLine("")
        Console.WriteLine("/OBJECT")
        Console.WriteLine("   (Optional) For HTML Output. Instead of FULL HTML Document, ")
        Console.WriteLine("   Export Main HTML Object ONLY (no CSS, no JS Func).")
        Console.WriteLine("")
        Console.WriteLine("/ANIM")
        Console.WriteLine("   (Optional) For HTML Output. Generate Dynamic Animation (CSS/JS) ")
        Console.WriteLine("   instead of Static Picture. Only use for ANSIAnimations and ")
        Console.WriteLine("   ANSIS that use the Blinking Formatting.")
        Console.WriteLine("")
        Console.WriteLine("/NOCOL")
        Console.WriteLine("   (Optional) For Image Output. Render output without colors (ASCII) ")
        Console.WriteLine("")
        Console.WriteLine("/SMALL")
        Console.WriteLine("   (Optional) For Image Output. Use Small 8x8 font (instead of 8x16) ")
        Console.WriteLine("")
        Console.WriteLine("/THUMB")
        Console.WriteLine("   (Optional) For Image Output. Create Thumbnail Image ")
        Console.WriteLine("")
        Console.WriteLine("/THUMBSCALE: <PROP>|<WIDTH>|<HEIGHT>|<CUSTOM>")
        Console.WriteLine("   (Optional) For Thumbnail Output. Scaling Option")
        Console.WriteLine("")
        Console.WriteLine("/SCALE: <PERCENT>")
        Console.WriteLine("   (Optional) For Thumbnail Scaleing <PROP>. Percent of Full Image Size")
        Console.WriteLine("")
        Console.WriteLine("/WIDTH: <NUM>")
        Console.WriteLine("   (Optional) For Thumbnail Scaleing <WIDTH>/<CUSTOM>. Thumbnail Width")
        Console.WriteLine("")
        Console.WriteLine("/HEIGHT: <NUM>")
        Console.WriteLine("   (Optional) For Thumbnail Scaleing <HEIGHT>/<CUSTOM>. Thumbnail Height")
        Console.WriteLine("")
        Console.WriteLine("/CODEC: <ID>")
        Console.WriteLine("    (Optional) For Video outputs in .AVI or .MPG Format. Following values")
        Console.WriteLine("    are(supported)")
        Console.WriteLine("")
        Console.WriteLine("    For .MPG: MPEG1 (Default) or MPEG2 ")
        Console.WriteLine("    For .AVI: ZMBV (Default), FFVI, H264, MPEG4, MJPEG, LIBX264 or LIBXVID")
        Console.WriteLine("")
        Console.WriteLine("/FPS: <NUM>")
        Console.WriteLine("    (Optional) For Video Outputs. The Video Frame Rate. Default = 30.00")
        Console.WriteLine("")
        Console.WriteLine("/BPS: <NUM>")
        Console.WriteLine("    (Optional) For Video Outputs. The Simulated Modem Speed in BPS ")
        Console.WriteLine("    (Bits per Second). Default = 28800")
        Console.WriteLine("")
        Console.WriteLine("/EXTEND: <NUM>")
        Console.WriteLine("    (Optional) For Video Outputs. Number of Seconds to extend the last Frame")
        Console.WriteLine("    of the Animation. Default = 3 (Seconds)")
        Console.WriteLine("")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("Extra Parameters:")
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("")
        Console.WriteLine("/H , /? , /HELP ")
        Console.WriteLine("   Returns this help text")
        Console.WriteLine("")
        Console.WriteLine("/CPLIST")
        Console.WriteLine("   All other parameters will be ignored. ")
        Console.WriteLine("   Returns list of available CodePages to be used for the /CP Param.")
        Console.WriteLine("")
        Console.WriteLine("============================================================================")
        Console.WriteLine("")

    End Sub

    Private Sub BuildCPList()
        Dim sStr As String = ""
        Console.WriteLine("")
        Console.WriteLine("List of Supported Code Pages")
        Console.WriteLine("--------+-----+------------+-----------------------------------")
        Console.WriteLine("     CP | OS  | ISO        | Desc")
        Console.WriteLine("--------+-----+------------+-----------------------------------")
        For a As Integer = 0 To CPS.CodePages.Count - 1
            sStr = " " & Strings.Right("      " & CPS.CodePages.Item(a).Name, 6) & " | "
            sStr &= Strings.Right("   " & CPS.CodePages.Item(a).OS, 3) & " | "
            sStr &= Strings.Right("          " & CPS.CodePages.Item(a).ISO, 10) & " | "
            sStr &= CPS.CodePages.Item(a).Description
            Console.WriteLine(sStr)
        Next
        Console.WriteLine("--------+-----+------------+-----------------------------------")
        Console.WriteLine("")
    End Sub

    Private Function CodePageExists(ByVal sstr As String) As Boolean
        Dim bReturn As Boolean = False
        For a As Integer = 0 To CPS.CodePages.Count - 1
            If LCase(CPS.CodePages.Item(a).Name) = sstr Then
                bReturn = True
                Exit For
            End If
        Next
        Return bReturn
    End Function

    Private Sub AddFile(ByVal sFile As String)
        Dim bAdd As Boolean = True
        sFile = IO.Path.GetFullPath(sFile)
        If sFile <> "" Then
            If IO.File.Exists(sFile) = False Then
                bAdd = False
            Else
                If Converter.ConverterSupport.GetFileSizeNum(sFile) = 0 Then
                    bAdd = False
                End If
            End If
        Else
            bAdd = False
        End If
        If Converter.ListInputFiles.Count > 0 And bAdd = True Then
            For a As Integer = 0 To Converter.ListInputFiles.Count - 1
                If Converter.ListInputFiles.Item(a).FullPath.Equals(sFile) Then
                    bAdd = False
                End If
            Next
        End If
        If bAdd = True Then
            Dim ff As FFormats = Converter.ConverterSupport.checkFileFormat(sFile)
            Dim ft As FTypes
            If ff = FFormats.us_ascii Then
                ft = Converter.ConverterSupport.DetermineFileType(sFile)
            Else
                ft = FTypes.Unicode
            End If
            If ft <> iOutFormat Then
                aFTCounts(ft) += 1
                Converter.ListInputFiles.Add(New Converter.FileListItem(IO.Path.GetFileName(sFile), sFile, ff, ft))
            End If
        End If
    End Sub

    Private Sub BuildFileList(ByVal sFold As String)
        Dim sFile As IO.FileInfo
        Dim DI As New IO.DirectoryInfo(sFold)
        Dim sFiles As IO.FileInfo() = DI.GetFiles()
        Dim bAdd As Boolean = True
        If sFiles.Length > 0 Then
            For Each sFile In sFiles
                bAdd = True
                If sExtFilter <> "" Then
                    If InclExt(sFile.Extension) = False Then
                        bAdd = False
                    End If
                End If
                If bAdd = True Then
                    Try
                        Call AddFile(sFile.FullName.ToString)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

    Private Function InclExt(ByVal sStr As String) As Boolean
        Dim bResult As Boolean = False
        If Strings.Left(sStr, 1) = "." Then
            If sStr.Length > 1 Then
                sStr = Strings.Right(sStr, sStr.Length - 1)
            Else
                sStr = ""
            End If
        End If
        For a As Integer = 0 To aExtFilter.Length - 1
            If LCase(sStr) = LCase(aExtFilter(a)) Then
                bResult = True
                Exit For
            End If
        Next
        Return bResult
    End Function
End Module
