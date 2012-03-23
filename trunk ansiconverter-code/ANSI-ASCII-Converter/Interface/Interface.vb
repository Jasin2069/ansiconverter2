Imports System.Runtime.InteropServices.Marshal
Imports System.Windows.Forms

Public Module UserInterface
    Public Sub InitializeForm()

        MainForm.Version.Text = ToolVersion
        MainForm.VersionDate.Text = ToolVersionDate

        ListIn2.Add(MainForm.in2ASCII)
        ListCntLabels.Add(MainForm.cntASCII)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2ANSI)
        ListCntLabels.Add(MainForm.cntANSI)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2HTML)
        ListCntLabels.Add(MainForm.cntHTML)
        ListInCPVis.Add(False)
        ListIn2.Add(MainForm.in2Unicode)
        ListCntLabels.Add(MainForm.cntUNI)
        ListInCPVis.Add(False)
        ListIn2.Add(MainForm.in2PCBoard)
        ListCntLabels.Add(MainForm.cntPCB)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2Binary)
        ListCntLabels.Add(MainForm.cntBIN)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2Wildcat2)
        ListCntLabels.Add(MainForm.cntWC2)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2Wildcat3)
        ListCntLabels.Add(MainForm.cntWC3)
        ListInCPVis.Add(True)
        ListIn2.Add(MainForm.in2Avatar)
        ListCntLabels.Add(MainForm.cntAVT)
        ListInCPVis.Add(True)


        ListOut.Add(MainForm.outASCII)
        ListOut.Add(MainForm.outANSI)
        ListOut.Add(MainForm.outHTML)
        ListOut.Add(MainForm.outUnicode)
        ListOut.Add(MainForm.outBBS)
        ListOut.Add(MainForm.outBinary)
        ListOut.Add(MainForm.outImage)
        ListOut.Add(MainForm.outVideo)

        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rAVI)
        ListOutExt.Add("AVI")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rWMV)
        ListOutExt.Add("WMV")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rAGIF)
        ListOutExt.Add("GIF")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rMPG)
        ListOutExt.Add("MPG")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rFLV)
        ListOutExt.Add("FLV")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rMP4)
        ListOutExt.Add("MP4")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rMKV)
        ListOutExt.Add("MKV")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rVOB)
        ListOutExt.Add("VOB")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rBMP)
        ListOutExt.Add("BMP")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rGIF)
        ListOutExt.Add("GIF")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rPNG)
        ListOutExt.Add("PNG")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rTIF)
        ListOutExt.Add("TIF")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rJPG)
        ListOutExt.Add("JPG")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rICO)
        ListOutExt.Add("ICO")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rWMF)
        ListOutExt.Add("WMF")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rEMF)
        ListOutExt.Add("EMF")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rObjectOnly)
        ListOutExt.Add("WEB")
        ListOutExtReqOutSet.Add("HTML")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rCompleteHTML)
        ListOutExt.Add("HTM")
        ListOutExtReqOutSet.Add("HTM")

        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rPCBoard)
        ListOutExt.Add("PCB")
        ListOutExtReqOutSet.Add("BBS")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rAvatar)
        ListOutExt.Add("AVT")
        ListOutExtReqOutSet.Add("BBS")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rWildcat2)
        ListOutExt.Add("WC2")
        ListOutExtReqOutSet.Add("BBS")
        ListOutExtTrig.Add(ANSI_ASCII_Converter.Settings.rWildcat3)
        ListOutExt.Add("WC3")
        ListOutExtReqOutSet.Add("BBS")

        ListOutExtTrig.Add(MainForm.outImage)
        ListOutExt.Add("PNG")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(MainForm.outVideo)
        ListOutExt.Add("AVI")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(MainForm.outHTML)
        ListOutExt.Add("HTM")
        ListOutExtReqOutSet.Add("HTML")
        ListOutExtTrig.Add(MainForm.outASCII)
        ListOutExt.Add("ASC")
        ListOutExtReqOutSet.Add("ASC")
        ListOutExtTrig.Add(MainForm.outANSI)
        ListOutExt.Add("ANS")
        ListOutExtReqOutSet.Add("ANS")
        ListOutExtTrig.Add(MainForm.outUnicode)
        ListOutExt.Add("TXT")
        ListOutExtReqOutSet.Add("UTF")
        ListOutExtTrig.Add(MainForm.outBBS)
        ListOutExt.Add("PCB")
        ListOutExtReqOutSet.Add("BBS")
        ListOutExtTrig.Add(MainForm.outBinary)
        ListOutExt.Add("BIN")
        ListOutExtReqOutSet.Add("BIN")



        ListHTMLObj.Add(Settings.rObjectOnly)
        ListHTMLObj.Add(Settings.rCompleteHTML)
        ListSauce.Add(Settings.rSauceStrip)
        ListSauce.Add(Settings.rSauceKeep)
        ListAnim.Add(Settings.rAnim)
        ListAnim.Add(Settings.rStatic)
        ListUTF.Add(Settings.rUTF8)
        ListUTF.Add(Settings.rUTF16)

        ListOutPath.Add(MainForm.rOutPathInput)
        ListOutPath.Add(MainForm.rOutPathNew)

        ListOutExist.Add(Settings.rOver)
        ListOutExist.Add(Settings.rSkip)
        ListOutExist.Add(Settings.rAutoRen)
        ListOutExist.Add(Settings.rAsk)

        ListExt.Add(Settings.rReplaceExt)
        ListExt.Add(Settings.rExtraExt)

        ListOutImg.Add(Settings.rPNG)
        ListOutImg.Add(Settings.rBMP)
        ListOutImg.Add(Settings.rGIF)
        ListOutImg.Add(Settings.rJPG)
        ListOutImg.Add(Settings.rTIF)
        ListOutImg.Add(Settings.rICO)
        ListOutImg.Add(Settings.rWMF)
        ListOutImg.Add(Settings.rEMF)

        ListVidOutFmt.Add(Settings.rAVI)
        ListVidOutFmt.Add(Settings.rWMV)
        ListVidOutFmt.Add(Settings.rAGIF)
        ListVidOutFmt.Add(Settings.rFLV)
        ListVidOutFmt.Add(Settings.rMPG)
        ListVidOutFmt.Add(Settings.rMP4)
        ListVidOutFmt.Add(Settings.rMKV)
        ListVidOutFmt.Add(Settings.rVOB)

        ListVidMpgCodec.Add(Settings.rMPEG1)
        ListVidMpgCodec.Add(Settings.rMPEG2)

        ListVidAviCodec.Add(Settings.rZMBV)
        ListVidAviCodec.Add(Settings.rH264)
        ListVidAviCodec.Add(Settings.rMPEG4)
        ListVidAviCodec.Add(Settings.rMJPEG)
        ListVidAviCodec.Add(Settings.rFFVI)
        ListVidAviCodec.Add(Settings.rLIBX264)
        ListVidAviCodec.Add(Settings.rLIBXVID)

        ListThumbScale.Add(Settings.selThumbProp)
        ListThumbScale.Add(Settings.selThumbWFixed)
        ListThumbScale.Add(Settings.selThumbHFixed)
        ListThumbScale.Add(Settings.selThumbCustom)

        ListBBSFormats.Add(Settings.rPCBoard)
        ListBBSFormats.Add(Settings.rAvatar)
        ListBBSFormats.Add(Settings.rWildcat2)
        ListBBSFormats.Add(Settings.rWildcat3)

        ListOutExtExtend.Add(ListHTMLObj)
        ListOutExtExtend.Add(ListOutImg)
        ListOutExtExtend.Add(ListVidOutFmt)
        ListOutExtExtend.Add(ListBBSFormats)


        ListAll.Add(ListOut)
        ListAllLeft.Add(110)  '148
        ListOrgPos.Add(110)
        ListAll.Add(ListUTF)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListOutExist)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListHTMLObj)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListOutPath)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListExt)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListSauce)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListAnim)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListOutImg)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListThumbScale)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListVidOutFmt)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListVidMpgCodec)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListVidAviCodec)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)
        ListAll.Add(ListBBSFormats)
        ListAllLeft.Add(-1)
        ListOrgPos.Add(-1)


        '
        'ListScrollbarButtons1.Add(CodePageMaps.btnUpBig1)
        'ListScrollbarButtons1.Add(CodePageMaps.btnUp1)
        'ListScrollbarButtons1.Add(CodePageMaps.btnMiddle1)
        'ListScrollbarButtons1.Add(CodePageMaps.btnDown1)
        'ListScrollbarButtons1.Add(CodePageMaps.btnDownBig1)



        ListSettLabels.Add(MainForm.settGen)
        ListSettPanels.Add(Settings.pGen)
        ListSettLabels.Add(MainForm.settSauce)
        ListSettPanels.Add(Settings.pSauce)
        ListSettLabels.Add(MainForm.settExist)
        ListSettPanels.Add(Settings.pOutExist)
        ListSettLabels.Add(MainForm.settExt)
        ListSettPanels.Add(Settings.pExt)
        ListSettLabels.Add(MainForm.settUTF)
        ListSettPanels.Add(Settings.pUTF)
        ListSettLabels.Add(MainForm.settHTMLObj)
        ListSettPanels.Add(Settings.pHTMLObj)
        ListSettLabels.Add(MainForm.settAnim)
        ListSettPanels.Add(Settings.pAnim)
        ListSettLabels.Add(MainForm.settSanitize)
        ListSettPanels.Add(Settings.pSanitize)
        ListSettLabels.Add(MainForm.settHTMLFont)
        ListSettPanels.Add(Settings.pHTMLFont)
        ListSettLabels.Add(MainForm.settNoCols)
        ListSettPanels.Add(Settings.pNoCols)
        ListSettLabels.Add(MainForm.settSMALLFNT)
        ListSettPanels.Add(Settings.pSmallFnt)
        ListSettLabels.Add(MainForm.attCreTh)
        ListSettPanels.Add(Settings.pThumb)
        ListSettLabels.Add(MainForm.settImgOut)
        ListSettPanels.Add(Settings.pIMGOut)
        ListSettLabels.Add(MainForm.settThumbs)
        ListSettPanels.Add(Settings.pThumbs)
        ListSettLabels.Add(MainForm.settVideo)
        ListSettPanels.Add(Settings.pVideo)
        ListSettLabels.Add(MainForm.settVidFmt)
        ListSettPanels.Add(Settings.pVidFmts)
        ListSettLabels.Add(MainForm.settVidCodec)
        ListSettPanels.Add(Settings.pMPGCodec)
        ListSettLabels.Add(MainForm.settVidCodec)
        ListSettPanels.Add(Settings.pAVICodec)
        ListSettLabels.Add(MainForm.settLFExt)
        ListSettPanels.Add(Settings.pLFrame)
        ListSettLabels.Add(MainForm.settBBS)
        ListSettPanels.Add(Settings.pBBS)

        ListDepends.Add(New ControlDepends(MainForm.in2ANSI, "checked", True, MainForm.outVideo, "visible", True))
        ListDepends.Add(New ControlDepends(MainForm.in2ASCII, "checked", True, MainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.in2HTML, "checked", True, MainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.in2PCBoard, "checked", True, MainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.in2Unicode, "checked", True, MainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.in2Binary, "checked", True, MainForm.outVideo, "visible", False))

        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", True, MainForm.outPath, "visible", True))
        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", True, MainForm.btnOutputFolder, "visible", True))
        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", False, MainForm.outPath, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", False, MainForm.btnOutputFolder, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", True, MainForm.lblInfoSameDirOut, "visible", False))
        ListDepends.Add(New ControlDepends(MainForm.rOutPathNew, "checked", False, MainForm.lblInfoSameDirOut, "visible", True))

        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", False, Settings.ThumbScalePercent, "Enabled", False))

        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))

        ListDepends.Add(New ControlDepends(Settings.rAVI, "checked", True, Settings.pAVICodec, "Visible", True))
        ListDepends.Add(New ControlDepends(Settings.rAVI, "checked", False, Settings.pAVICodec, "Visible", False))
        ListDepends.Add(New ControlDepends(Settings.rMPG, "checked", True, Settings.pMPGCodec, "Visible", True))
        ListDepends.Add(New ControlDepends(Settings.rMPG, "checked", False, Settings.pMPGCodec, "Visible", False))

        ListDepends.Add(New ControlDepends(Settings.selThumbWFixed, "checked", True, Settings.ThumbWidth, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbWFixed, "checked", True, Settings.ThumbHeight, "Enabled", False))
        ListDepends.Add(New ControlDepends(Settings.selThumbWFixed, "checked", True, Settings.ThumbScalePercent, "Enabled", False))

        ListDepends.Add(New ControlDepends(Settings.selThumbHFixed, "checked", True, Settings.ThumbHeight, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbHFixed, "checked", True, Settings.ThumbWidth, "Enabled", False))
        ListDepends.Add(New ControlDepends(Settings.selThumbHFixed, "checked", True, Settings.ThumbScalePercent, "Enabled", False))

        ListDepends.Add(New ControlDepends(Settings.selThumbCustom, "checked", True, Settings.ThumbWidth, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbCustom, "checked", True, Settings.ThumbHeight, "Enabled", True))

        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", True, MainForm.lblHTMLFont, "visible", True))
        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", False, MainForm.cbHTMLFont, "visible", False))
        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", False, MainForm.lblHTMLFont, "visible", False))


        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", True, MainForm.cbHTMLFont, "visible", True))
        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", True, MainForm.lblHTMLFont, "visible", True))
        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", False, MainForm.cbHTMLFont, "visible", False))
        'ListDepends.Add(New ControlDepends(MainForm.outHTML, "checked", False, MainForm.lblHTMLFont, "visible", False))

        '        sHTMLFont
        'MainForm.cbHTMLFont
        'MainForm.lblHTMLFont
        'ListDepends.Add(New ControlDepends(MainForm.rAnim, "checked", True, MainForm.outHTML, "checked", True, MainForm.rSauceStrip, "checked", True))
        'ListDepends.Add(New ControlDepends(MainForm.rAnim, "checked", True, MainForm.outHTML, "checked", True, MainForm.Sanitize, "checked", True))


        'ToolTipAndEvents(MainForm.lblOutputLoc, "Where do you want to " & vbCrLf & "save the results " & vbCrLf & "of the conversion?")

        ToolTipAndEvents(MainForm.in2ASCII, "Input file(s) are " & vbCrLf & "MS DOS ASCII text files")
        ToolTipAndEvents(MainForm.in2ANSI, "Input file(s) are MS DOS" & vbCrLf & "text files with" & vbCrLf & "ESC control sequences" & vbCrLf & "for terminal colors")
        ToolTipAndEvents(MainForm.in2HTML, "Input file(s) are ASCII text" & vbCrLf & "formated HTML code" & vbCrLf & "where the Unicode" & vbCrLf & "characters were HTML" & vbCrLf & "encoded for display on the web." & vbCrLf & "It's the reverse of my" & vbCrLf & "HTML encoding function," & vbCrLf & "but only works for" & vbCrLf & "ASCII's (not ANSIs)")
        ToolTipAndEvents(MainForm.in2Unicode, "Input file(s) are Unicode" & vbCrLf & "(UTF-8 or UTF-16) encoded" & vbCrLf & "text files for Windows")
        ToolTipAndEvents(MainForm.in2PCBoard, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the PCBoard" & vbCrLf & "BBS Software." & vbCrLf & "(@X.. color codes)")
        ToolTipAndEvents(MainForm.in2Wildcat2, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the Wildcat V2.X" & vbCrLf & "BBS Software." & vbCrLf & "(ANSI Like Codes)")
        ToolTipAndEvents(MainForm.in2Wildcat3, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the Wildcat V3.X" & vbCrLf & "BBS Software." & vbCrLf & "(@..@ color codes)")
        ToolTipAndEvents(MainForm.in2Avatar, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding in AVATAR Format")

        ToolTipAndEvents(MainForm.in2Binary, "Input files are MS DOS" & vbCrLf & "Binary encoded graphics files" & vbCrLf & "ANSIs with double the width" & vbCrLf & "of a normal PC ANSI" & vbCrLf & "file (160 chars instead of 80)")
        ToolTipAndEvents(MainForm.lblCPin, "Code Page that was used" & vbCrLf & "originally. This only matters," & vbCrLf & "if the file uses characters that" & vbCrLf & "are different between code pages." & vbCrLf & "These are typically reginal text " & vbCrLf & "characters and some graphical" & vbCrLf & "elements as well, especially borders.")
        ToolTipAndEvents(MainForm.lblCPout, "Code Page that should be used" & vbCrLf & "for the output DOS ASCII file." & vbCrLf & "This only matters, if " & vbCrLf & "characters were used that " & vbCrLf & "are different in different " & vbCrLf & "Code Page settings.")
        ToolTipAndEvents(MainForm.outASCII, "Convert output to MS DOS PC ASCII text files")
        ToolTipAndEvents(MainForm.outANSI, "Convert output to MSDOS" & vbCrLf & "PC Text files with" & vbCrLf & "ESC sequences for" & vbCrLf & "color encoding.")
        ToolTipAndEvents(MainForm.outHTML, "Convert output to ASCII text" & vbCrLf & "(HTML) with HTML encoded" & vbCrLf & "Unicode charcters and" & vbCrLf & "using CSS for styling" & vbCrLf & "and coloring (of ANSIs)")
        ToolTipAndEvents(MainForm.outUnicode, "Convert output to" & vbCrLf & "Windows PC/Unicode encoded" & vbCrLf & "plain text files.")
        ToolTipAndEvents(MainForm.outBBS, "Convert output to ANSI-like" & vbCrLf & "text for DOS, in a format" & vbCrLf & "used by a specified Bulletin Board System software.")
        ToolTipAndEvents(MainForm.outBinary, "Convert output to binary" & vbCrLf & "image DOS format for" & vbCrLf & "double width ANSIs or ASCIIs. ")
        ToolTipAndEvents(MainForm.outImage, "Convert output to an Bitmap Image" & vbCrLf & "The specified Extension determines " & vbCrLf & "the Image Format. Supported " & vbCrLf & "Image Formats: PNG, BMP, JPG, GIF, TIF, ICO, WMF, EMF")
        ToolTipAndEvents(MainForm.outVideo, "Convert ANSI Animation to Video")
        ToolTipAndEvents(MainForm.rOutPathInput, "Use same path for output" & vbCrLf & "as the original input file")
        ToolTipAndEvents(MainForm.rOutPathNew, "Write all outputs to the" & vbCrLf & "same folder location specified.")
        ToolTipAndEvents(MainForm.btnOutputFolder, "Select folder location" & vbCrLf & "for all outputs")
        ToolTipAndEvents(MainForm.numSel, "Number of files in the input" & vbCrLf & "file list that are currently" & vbCrLf & "selected and could be removed" & vbCrLf & "from the list, leaving any other" & vbCrLf & "non-selected file still in the list.")
        ToolTipAndEvents(MainForm.numUTF8, "Number of UTF-8 Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(MainForm.numUTF16, "Number of UTF-16 Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(MainForm.numASCII, "Number of Non-Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(MainForm.numTotal, "Total Number of files in the" & vbCrLf & "file listing box of any type of" & vbCrLf & "encoding and format.")
        ToolTipAndEvents(MainForm.lblDropHere, "Drop file from Windows" & vbCrLf & "directly into this list" & vbCrLf & "for selection and future" & vbCrLf & "processing.")
        ToolTipAndEvents(MainForm.lblLogAndInfos, "Output messages as log," & vbCrLf & "showing information about" & vbCrLf & "the current files being processed" & vbCrLf & "as well as warnings and errors.")
        ToolTipAndEvents(MainForm.btnUniBlocks, "Show Unicode Character" & vbCrLf & "Sets Grouped in Blocks")
        ToolTipAndEvents(MainForm.btnCPMaps, "Show Unicode Mappings and" & vbCrLf & "Special HTML Encoding for" & vbCrLf & "the various DOS and" & vbCrLf & "Windows Code Pages")
        ToolTipAndEvents(MainForm.btnSearch, "Search Unicode Character" & vbCrLf & "Definitions, by Code, Name and more")
        ToolTipAndEvents(MainForm.btnSettings2, "Modify Program Settings")
        ToolTipAndEvents(MainForm.btnSettings, "Modify Program Settings")
        'lblSelInput
        'btnSettings2
        ToolTipAndEvents(MainForm.lblInputFormats, "The tool automatically" & vbCrLf & "detects the format of the" & vbCrLf & "selected files and" & vbCrLf & "updates counts/checks formats" & vbCrLf & "while you select more" & vbCrLf & "files to process.")
        ToolTipAndEvents(MainForm.lblOutput, "The selection for possible" & vbCrLf & "output formats depends on" & vbCrLf & "the types of files added to" & vbCrLf & "the list for processing")
        ToolTipAndEvents(MainForm.btnNFO, "Open the Release" & vbCrLf & "NFO File for this" & vbCrLf & "Tool(Version)")

        ToolTipAndEvents(MainForm.txtExt, "Extension used for Output Files")

        ToolTipSettAndEvents(Settings.rUTF16, "Use Unicode UTF-16 Encoding" & vbCrLf & "for output text file")
        ToolTipSettAndEvents(Settings.rUTF8, "Use Unicode UTF-8 Encoding" & vbCrLf & "for output text file")

        ToolTipSettAndEvents(Settings.rAnim, "Ansi Animation." & vbCrLf & "Don't use this option, if" & vbCrLf & "you are not sure, because" & vbCrLf & "the output will be entirely" & vbCrLf & "different and Javascript driven.")
        ToolTipSettAndEvents(Settings.rStatic, "Static ANSI Picture." & vbCrLf & "Leave this option, if you are not sure.")

        ToolTipSettAndEvents(Settings.rCompleteHTML, "Write complete HTML document" & vbCrLf & "with headers and" & vbCrLf & "style sheet definitions")
        ToolTipSettAndEvents(Settings.rObjectOnly, "Write only object wrapped" & vbCrLf & "in a div tag, without the" & vbCrLf & "stylesheet definitions")
        ToolTipSettAndEvents(Settings.rExtraExt, "Add the new extension" & vbCrLf & "as an extra extension" & vbCrLf & "to the output file name")
        ToolTipSettAndEvents(Settings.rReplaceExt, "Replace the original extension" & vbCrLf & "of the input file with the" & vbCrLf & "new extension for the output file")

        ToolTipSettAndEvents(Settings.rOver, "Overwrite any existing" & vbCrLf & "output file automatically")
        ToolTipSettAndEvents(Settings.rSkip, "Skip files where a file with" & vbCrLf & "the same name for output" & vbCrLf & "already exists.")
        ToolTipSettAndEvents(Settings.rAsk, "Ask for every file that" & vbCrLf & "already exists what to do")
        ToolTipSettAndEvents(Settings.rAutoRen, "Automatically rename output files," & vbCrLf & "if a file with the same name" & vbCrLf & "already exists, adding " & vbCrLf & "(2), (3) ... (x) to the name" & vbCrLf & "of the file.")

        ToolTipSettAndEvents(Settings.selThumbProp, "Scale Thumbnail Image proportionally" & vbCrLf & "to specified percent of" & vbCrLf & "original image size.")
        ToolTipSettAndEvents(Settings.selThumbWFixed, "Proportionally Scale Thumbnail" & vbCrLf & "Image to specified fixed width" & vbCrLf & "and adjust the height automatically")
        ToolTipSettAndEvents(Settings.selThumbHFixed, "Proportionally Scale Thumbnail" & vbCrLf & "Image to specified fixed height" & vbCrLf & "and adjust the width automatically")
        ToolTipSettAndEvents(Settings.selThumbCustom, "Scale Thumbnail to specified" & vbCrLf & "custom Width and Height" & vbCrLf & "ignoring the proportions")
        '
        ToolTipSettAndEvents(Settings.lblRemComplete, "If ON: files that were finished" & vbCrLf & "converting will be removed from" & vbCrLf & "the list of files to be processed")
        ToolTipSettAndEvents(Settings.rSauceStrip, "Ignore existing 'Sauce'" & vbCrLf & "Meta Tag Data from Input File.")
        ToolTipSettAndEvents(Settings.rSauceKeep, "If Input File has 'Sauce'" & vbCrLf & "Meta Tag, include it in converted" & vbCrLf & "output file as well.")
        ToolTipSettAndEvents(Settings.lblSauce, "Determine what to do, " & vbCrLf & "if 'Sauce' Meta Tag are " & vbCrLf & "found in input files.")

        ToolTipSettAndEvents(Settings.lblImgFormat, "Select the bitmap output format" & vbCrLf & "for the export to images option")
        ToolTipSettAndEvents(Settings.rPNG, "Image Output in " & vbCrLf & "Portable Network Graphics (PNG)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rGIF, "Image Output in " & vbCrLf & "Graphics Interchange Format (GIF)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rBMP, "Image Output in " & vbCrLf & "Windows Bitmap (BMP)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rICO, "Image Output in " & vbCrLf & "Windows Icon (ICO)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rJPG, "Image Output in " & vbCrLf & "Joint Photographic Experts Group (JPEG)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rTIF, "Image Output in " & vbCrLf & "Tagged Image File Format (TIFF)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rWMF, "Image Output in " & vbCrLf & "Windows Meta File Format (WMF)" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rEMF, "Image Output in " & vbCrLf & "Enhanced Metafile Format (EMF)" & vbCrLf & "File Format")
        ' 
        ToolTipSettAndEvents(Settings.rAVI, "Video Output in " & vbCrLf & "Audio Video Interleave (AVI) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rWMV, "Video Output in " & vbCrLf & "Windows Media Video (WMV) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rAGIF, "Video Output in " & vbCrLf & "Animated Graphics Interchange Format (GIF) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rMPG, "Video Output in " & vbCrLf & "Motion Picture Group (MPG) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rFLV, "Video Output in " & vbCrLf & "Flash Video / Sorenson Spark / Sorenson H.263 (FLV) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rMP4, "Video Output in " & vbCrLf & "Mpeg-4 (MP4) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rMKV, "Video Output in " & vbCrLf & "Matroshka (MKV) Format" & vbCrLf & "File Format")
        ToolTipSettAndEvents(Settings.rVOB, "Video Output in " & vbCrLf & "Video Object Binary (VOB) Format" & vbCrLf & "File Format")

        ToolTipSettAndEvents(Settings.rMPEG1, "MPEG Video Codec " & vbCrLf & "MPEG-1 video")
        ToolTipSettAndEvents(Settings.rMPEG2, "MPEG Video Codec " & vbCrLf & "MPEG-2 video")

        ToolTipSettAndEvents(Settings.rZMBV, "AVI Video Codec " & vbCrLf & "Zip Motion Blocks Video")
        ToolTipSettAndEvents(Settings.rH264, "AVI Video Codec " & vbCrLf & "H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10")
        ToolTipSettAndEvents(Settings.rMPEG4, "AVI Video Codec " & vbCrLf & "MPEG-4 part 2")
        ToolTipSettAndEvents(Settings.rMJPEG, "AVI Video Codec " & vbCrLf & "MJPEG (Motion JPEG)")
        ToolTipSettAndEvents(Settings.rFFVI, "AVI Video Codec " & vbCrLf & "FFmpeg video codec #1")
        ToolTipSettAndEvents(Settings.rLIBX264, "AVI Video Codec " & vbCrLf & "libx264 H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10")
        ToolTipSettAndEvents(Settings.rLIBXVID, "AVI Video Codec " & vbCrLf & "libxvidcore MPEG-4 part 2")
        ToolTipSettAndEvents(Settings.lblFExtend, "Extend Video with " & vbCrLf & "last frame by specified" & vbCrLf & "number of seconds")

        ToolTipSettAndEvents(Settings.rPCBoard, "Output as PCBoard BBS " & vbCrLf & "compatible ANSI Screen")
        ToolTipSettAndEvents(Settings.rAvatar, "Output as Avatar " & vbCrLf & "formatted ANSI Screen")
        ToolTipSettAndEvents(Settings.rWildcat2, "Output as Wildcat BBS V2.X" & vbCrLf & "compatible ANSI Screen")
        ToolTipSettAndEvents(Settings.rWildcat3, "Output as Wildcat BBS V3.X" & vbCrLf & "compatible ANSI Screen")

        ToolTipSettAndEvents(Settings.lblNoCols, "If ON: Output Image " & vbCrLf & "will be rendered without " & vbCrLf & "colors, like an ASCII. ")
        ToolTipSettAndEvents(Settings.lblSmallFnt, "If ON: Output Image " & vbCrLf & "will use the small 8x8 pixels font " & vbCrLf & "instead of 8x16 (to simulate " & vbCrLf & "DOS 50x50 resolution).")
        ToolTipSettAndEvents(Settings.lblThumb, "Generate Thumbnail " & vbCrLf & "image instead of" & vbCrLf & "original full size image capture.")
        ToolTipSettAndEvents(Settings.Sanitize, "If ON: removes characters " & vbCrLf & "asc-code < 32, except LF & CR;" & vbCrLf & "also replaces TAB with 8 spaces " & vbCrLf & "(DOS tab-stop default) ")
        ToolTipSettAndEvents(Settings.lblSanitize, "If ON: removes characters " & vbCrLf & "asc-code < 32, except LF & CR;" & vbCrLf & "also replaces TAB with 8 spaces " & vbCrLf & "(DOS tab-stop default) ")
        ToolTipSettAndEvents(Settings.lblScaleSize, "What should happen, if " & vbCrLf & "a file at the location of the" & vbCrLf & "output for the converted" & vbCrLf & "input file already exists")
        ToolTipSettAndEvents(Settings.lblFPS, "Frames per Second." & vbCrLf & "Setting for AVI Video Output")
        ToolTipSettAndEvents(Settings.lblBPS, "Bits per Second." & vbCrLf & "Simulated Modem Speed for" & vbCrLf & "ANSI Animation playback" & vbCrLf & "and Video Capture")
        'ToolTipAndEvents(MainForm.xxx,"")


    End Sub

    Public Sub UpdateControls(Optional ByVal dontsave As Boolean = False)
        Dim a As Integer
        If MainFormLoaded = True And bUpdatingControls = False Then
            bUpdatingControls = True
            'ControlReset()
            For x As Integer = 0 To ListOrgPos.Count - 1
                ListAllLeft.Item(x) = ListOrgPos.Item(x)
            Next
            Try
                UpdateControlDepends()
            Catch ex As Exception

            End Try


            ' For a = 0 To ListIn.Count - 1
            '  If ListIn.Item(a).Checked = True Then
            '       inSelected = a
            '    End If
            'Next
            'CheckInputRule(inSelected)
            Try
                InputRuleCheck()
            Catch ex As Exception

            End Try


            Dim outSelected As Integer = -1
            For a = 0 To ListOut.Count - 1
                If ListOut.Item(a).Checked = True Then
                    outSelected = a
                End If
            Next
            Try
                CheckOutputRule(outSelected)
            Catch ex As Exception

            End Try


            If outSelected = -1 Then : MainForm.pOut.Tag = "" : End If
            For a = 0 To ListAll.Count - 1
                UpdateRadioGroup(ListAll.Item(a), ListAllLeft.Item(a))
            Next
            Try
                UpdateCounts()
            Catch ex As Exception

            End Try

            If dontsave = False Then
                Try
                    SaveAll()
                Catch ex As Exception

                End Try

            End If
            Try
                Call SummSettings()
            Catch ex As Exception

            End Try

            bUpdatingControls = False
        End If
    End Sub
    Public Sub UpdateControlDepends()
        For a As Integer = 0 To ListAll.Count - 1
            For b As Integer = 0 To ListAll.Item(a).Count - 1
                CheckDepends(ListDepends, ListAll.Item(a).Item(b))
            Next
        Next
    End Sub
    Public Sub ChangeVisible(ByRef Grp As List(Of Windows.Forms.RadioButton), ByVal bVisible As Boolean)
        For a As Integer = 0 To Grp.Count - 1
            Grp.Item(a).Visible = bVisible
        Next
    End Sub
    Public Sub ResetText(ByRef Grp As List(Of Windows.Forms.Label))
        For a As Integer = 0 To Grp.Count - 1
            Grp.Item(a).Text = 0
        Next
    End Sub
    Public Sub UpdateRadioGroup(ByVal Grp As List(Of Windows.Forms.RadioButton), ByVal LeftPos As Integer)
        For a As Integer = 0 To Grp.Count - 1
            If Grp.Item(a).Checked = True Then
                Grp.Item(a).Font = New Drawing.Font(Grp.Item(a).Font.FontFamily, Grp.Item(a).Font.Size, FontStyle.Bold)
                Grp.Item(a).Parent.Tag = Grp.Item(a).Tag
                If bExtInp = False And Grp.Item(a).Visible = True And Grp.Item(a).Parent.Visible = True And Grp.Item(a).Checked = True Then
                    Dim item As Windows.Forms.RadioButton = Grp.Item(a)
                    Dim iFound As Integer = ListOutExtTrig.FindIndex(Function(x) item.Equals(x))
                    If iFound >= 0 Then
                        If MainForm.pOut.Tag = ListOutExtReqOutSet.Item(iFound) Then
                            If Not ListOutExt.Item(iFound).Equals(MainForm.txtExt.Text) Then
                                bUpdatingControls = True
                                MainForm.txtExt.Text = ListOutExt.Item(iFound)
                                bUpdatingControls = False
                                UpdateControls()
                            End If
                        End If
                    End If
                End If
            Else
                Grp.Item(a).Font = New Drawing.Font(Grp.Item(a).Font.FontFamily, Grp.Item(a).Font.Size, FontStyle.Regular)
            End If
            If Grp.Item(a).Visible = True And LeftPos >= 0 Then
                Grp.Item(a).Left = LeftPos
                LeftPos += Grp.Item(a).Width + 5
            End If
        Next

    End Sub

    Public Sub CheckDepends(ByRef l As List(Of ControlDepends), ByRef c As Windows.Forms.Control)
        If l.Count > 0 Then
            For a As Integer = 0 To l.Count - 1
                l.Item(a).CheckControl(c)
            Next
        End If
    End Sub

    Public Sub ClearFileList()
        Converter.ListInputFiles.Clear()
        MainForm.listFiles.DataSource = Nothing
        MainForm.listFiles.DataSource = Converter.ListInputFiles
        'MainForm.listFiles.Items.Clear()
        UpdateCounts()
        UpdateControls()
    End Sub

    Public Sub AddFile(ByVal sFile As String)
        Dim bAdd As Boolean = True
        sFile = IO.Path.GetFullPath(sFile)
        If sFile <> "" Then
            If IO.File.Exists(sFile) = False Then
                bAdd = False
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
            Dim ff As FFormats = Converter.checkFileFormat(sFile)
            Dim ft As FTypes
            If ff = FFormats.us_ascii Then
                ft = Converter.DetermineFileType(sFile)
            Else
                ft = FTypes.Unicode
            End If
            'MainForm.listFiles.BindingContext.Item(0).SuspendBinding()
            'Console.WriteLine("sFile:" & sFile)
            'Console.WriteLine("MainForm.outPath.FullText:" & MainForm.outPath.FullText)
            'Console.WriteLine("GetDir:" & IO.Path.GetDirectoryName(sFile))
            Converter.ListInputFiles.Add(New Converter.FileListItem(IO.Path.GetFileName(sFile), sFile, ff, ft))
            If MainForm.outPath.FullText = "" Then
                MainForm.outPath.Text = IO.Path.GetDirectoryName(sFile)
                MainForm.outPath.FullText = IO.Path.GetDirectoryName(sFile)
            End If
            If bAddingFiles = False Then
                RefreshListFiles()
            End If
        End If
    End Sub
    Public Sub RefreshListFiles()
        MainForm.listFiles.DataSource = Nothing
        MainForm.listFiles.DataSource = Converter.ListInputFiles
        UpdateCounts()
        UpdateControls()
    End Sub
    Public Sub RemoveSelectedFiles()
        Dim cnt As Integer = MainForm.listFiles.SelectedItems.Count
        If cnt > 0 Then
            For a As Integer = 0 To cnt - 1
                Converter.ListInputFiles.Remove(MainForm.listFiles.SelectedItems.Item(a))
            Next
            MainForm.listFiles.DataSource = Nothing
            MainForm.listFiles.DataSource = Converter.ListInputFiles
        End If
        UpdateCounts()
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub UpdateCounts()
        MainForm.numSel.Text = 0
        MainForm.numUTF8.Text = 0
        MainForm.numUTF16.Text = 0
        MainForm.numASCII.Text = 0
        MainForm.numTotal.Text = Converter.ListInputFiles.Count
        'ChangeVisible(ListIn, True)
        ResetText(ListCntLabels)
        TypeCounts = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0}
        If Converter.ListInputFiles.Count > 0 Then
            For a As Integer = 0 To Converter.ListInputFiles.Count - 1
                Select Case Converter.ListInputFiles.Item(a).Format
                    Case FFormats.utf_16
                        MainForm.numUTF16.Text += 1
                    Case FFormats.utf_8
                        MainForm.numUTF8.Text += 1
                    Case Else
                        MainForm.numASCII.Text += 1
                End Select
                TypeCounts(Converter.ListInputFiles.Item(a).Type) += 1
                If Converter.ListInputFiles.Item(a).Selected = True Then
                    MainForm.numSel.Text += 1
                End If
            Next
        End If
        For a As Integer = 0 To TypeCounts.Count - 1
            ListCntLabels.Item(a).Text = TypeCounts(a)
            If TypeCounts(a) > 0 Then
                ListIn2.Item(a).Checked = True
            Else
                ListIn2.Item(a).Checked = False
            End If
        Next
        If MainForm.listFiles.Items.Count = 0 Then
            MainForm.lblDropHere.Visible = True
            MainForm.lblDropHere.BringToFront()
        Else
            MainForm.lblDropHere.Visible = False
        End If
        If MainForm.pOut.Visible = False Or MainForm.listFiles.Items.Count = 0 Or MainForm.pOut.Tag = "" Then
            MainForm.btnStart.Enabled = False
        Else
            MainForm.btnStart.Enabled = True
        End If
    End Sub
    Public Sub unSelectAll()
        Dim cnt As Integer = MainForm.listFiles.SelectedIndices.Count
        Dim val As Integer
        Do While MainForm.numSel.Text > 0
            For Each item In MainForm.listFiles.SelectedIndices
                val = item
                MainForm.listFiles.Items(val).selected = False
                MainForm.listFiles.SetSelected(val, False)

            Next
            MainForm.listFiles.Refresh()
        Loop
        'For Each val In MainForm.listFiles.SelectedIndices
        ''val = MainForm.listFiles.SelectedIndices.Item(a)
        'MainForm.listFiles.SetSelected(val, False)
        'MainForm.listFiles.Items(val).selected = False
        'Next

    End Sub


    Public Sub filelistitem_indexchange(ByVal sender As Object, ByVal e As EventArgs)
        MainForm.numTotal.Text = MainForm.listFiles.Items.Count
        If MainForm.listFiles.Items.Count = 0 Then
            MainForm.lblDropHere.Visible = True
        Else
            MainForm.lblDropHere.Visible = False
        End If
        For a As Integer = 0 To MainForm.listFiles.Items.Count - 1
            MainForm.listFiles.Items(a).selected = False
        Next
        MainForm.numSel.Text = MainForm.listFiles.SelectedItems.Count
        If MainForm.listFiles.SelectedItems.Count > 0 Then
            For a As Integer = 0 To MainForm.listFiles.SelectedItems.Count - 1
                MainForm.listFiles.SelectedItems.Item(a).selected = True
            Next
            MainForm.btnSelNone.Visible = True
        Else
            MainForm.btnSelNone.Visible = False
        End If

        sender.refresh()
    End Sub

    Public Sub DrawItemHandler(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        Dim fMyFont As Font = CType(sender, ListBox).Font
        If e.Index <> -1 Then


            Dim cMyColor As Color = CType(sender, ListBox).Items(e.Index).Color
            '
            'Required
            '
            'e.DrawBackground()
            Dim b As New SolidBrush(sender.items(e.Index).label.backcolor)
            e.Graphics.FillRectangle(b, e.Bounds)
            'If sender.items(e.Index).selected = True Then

            'Else
            'e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            'End If
            'If sender.SelectedItems.Contains(sender.items(e.Index)) Then
            '        e.Graphics.FillRectangle(Brushes.Yellow, e.Bounds)
            '       Else
            '      e.Graphics.FillRectangle(Brushes.White, e.Bounds)
            '     End If
            'e.DrawFocusRectangle()
            'sender.items(e.Index)
            '

            '
            'Draw colored text
            Dim sPrintN As String = CType(sender, ListBox).Items(e.Index).Name.ToString
            Dim sPathN As String = IO.Path.GetDirectoryName(CType(sender, ListBox).Items(e.Index).FullPath.ToString)
            Dim sFName As String = sPrintN
            Dim sStringSize As SizeF = e.Graphics.MeasureString(sPrintN, fMyFont)
            Dim sPrnSub As String = "", sPrnSubl As String = "", sPrnSubr As String = ""
            If sStringSize.Width > sender.width Then
                Do While sStringSize.Width > sender.width
                    sPrintN = Left(sPrintN, Len(sPrintN) - 1)
                    sStringSize = e.Graphics.MeasureString(sPrintN, fMyFont)
                Loop
            Else
                sPrintN = CType(sender, ListBox).Items(e.Index).FullPath.ToString
                sStringSize = e.Graphics.MeasureString(sPrintN, fMyFont)
                If sStringSize.Width > sender.width Then
                    sPrnSub = sPathN
                    Dim iC As Integer = ((sPathN.Length - 3) / 2) + 1
                    If iC > 0 Then

                        Do While sStringSize.Width > sender.width
                            iC -= 1
                            If iC > 0 Then
                                sPrnSubl = Left(sPrnSub, iC)
                                sPrnSubr = Right(sPrnSub, iC)
                                sPrintN = sPrnSubl & "..." & sPrnSubr & "\" & sFName
                            Else
                                sPrintN = ".." & sFName
                            End If
                            sStringSize = e.Graphics.MeasureString(sPrintN, fMyFont)
                        Loop
                    Else
                        sPrintN = ".." & sFName
                    End If
                End If
            End If
            e.Graphics.DrawString(sPrintN, fMyFont, New SolidBrush(cMyColor), e.Bounds.X, e.Bounds.Y)
        End If
    End Sub 'DrawItemHandler


    Public Sub MeasureItemHandler(ByVal sender As Object, ByVal e As MeasureItemEventArgs)
        Dim fMyFont As Font = CType(sender, ListBox).Font
        Dim sStringSize As SizeF = e.Graphics.MeasureString(CType(sender, ListBox).Items(e.Index).Name.ToString, fMyFont)

        '
        'Set the height of the row, column doesn't matter as there is only uno
        '
        e.ItemWidth = sender.width
        e.ItemHeight = CInt(sStringSize.Height)

    End Sub 'MeasureItemHandler

    Public Sub ToolTipAndEvents(ByVal fctrl As Windows.Forms.Control, ByVal sStr As String)
        MainForm.ToolTip1.SetToolTip(fctrl, sStr)
        AddHandler fctrl.MouseHover, AddressOf tooltip_MouseHover
        AddHandler fctrl.MouseLeave, AddressOf tooltip_MouseLeave
    End Sub
    Public Sub ToolTipSettAndEvents(ByVal fctrl As Windows.Forms.Control, ByVal sStr As String)
        Settings.ToolTip1.SetToolTip(fctrl, sStr)
        AddHandler fctrl.MouseHover, AddressOf tooltip_MouseHover
        AddHandler fctrl.MouseLeave, AddressOf tooltip_MouseLeave
    End Sub
    Public Sub tooltip_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Cursor <> Cursors.Hand Then
            sender.Cursor = Cursors.Help
        End If
    End Sub
    Public Sub tooltip_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.cursor = Cursors.Help Then
            sender.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub SaveVariousSet(ByVal n As String, ByVal v As Object)
        Try
            SaveSetting("ANSIASCIIConverter", "Various", n, CStr(v))
        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False
        End Try
    End Sub
    Public Function ReadVariousSet(ByVal n As String, ByVal def As Object) As Object
        Try
            Return GetSetting("ANSIASCIIConverter", "Various", n, CStr(def))
        Catch ex As Exception
            Return def
        End Try
    End Function
    Public Sub DeleteVariousSet(ByVal n As String)
        Try
            DeleteSetting("ANSIASCIIConverter", "Various", n)
        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False
        End Try
    End Sub
    Public Sub SaveAll()
        bUpdatingControls = True
        Try
            SaveVariousSet("pOut", MainForm.pOut.Tag.ToString)
            SaveVariousSet("pCPout", MainForm.pCPout.Tag.ToString)
            SaveVariousSet("pCPin", MainForm.pCPin.Tag.ToString)
            SaveVariousSet("pExt", Settings.pExt.Tag.ToString)
            SaveVariousSet("txtExt", MainForm.txtExt.Text)
            SaveVariousSet("pOutExist", Settings.pOutExist.Tag.ToString)
            SaveVariousSet("pOutPath", MainForm.pOutPath.Tag.ToString)
            SaveVariousSet("outPath", MainForm.outPath.FullText)
            SaveVariousSet("pSauce", Settings.pSauce.Tag.ToString)
            SaveVariousSet("pUTF", Settings.pUTF.Tag.ToString)
            SaveVariousSet("pAnim", Settings.pAnim.Tag.ToString)
            SaveVariousSet("pHTMLObj", Settings.pHTMLObj.Tag.ToString)
            SaveVariousSet("Sanitize", Settings.Sanitize.Checked.ToString)
            SaveVariousSet("NoCols", Settings.NoCols.Checked.ToString)
            SaveVariousSet("SmallFnt", Settings.SmallFnt.Checked.ToString)
            SaveVariousSet("Thumb", Settings.Thumb.Checked.ToString)
            SaveVariousSet("pVidFmts", Settings.pVidFmts.Tag.ToString)
            SaveVariousSet("pMPGCodec", Settings.pMPGCodec.Tag.ToString)
            SaveVariousSet("pAVICodec", Settings.pAVICodec.Tag.ToString)

            SaveVariousSet("ThumbResizeOpt", Settings.pThumbs.Tag.ToString)
            SaveVariousSet("ThumbScalePercent", Settings.ThumbScalePercent.Text.ToString)
            SaveVariousSet("ThumbWidth", Settings.ThumbWidth.Text.ToString)
            SaveVariousSet("ThumbHeight", Settings.ThumbHeight.Text.ToString)

            SaveVariousSet("pIMGOut", Settings.pIMGOut.Tag.ToString)
            SaveVariousSet("HTMLFont", sHTMLFont)
            SaveVariousSet("FPS", Settings.txtFPS.Text.ToString)
            SaveVariousSet("BPS", Settings.txtBPS.Text.ToString)
            SaveVariousSet("LastFrame", Settings.txtLastFrame.Text.ToString)

            SaveVariousSet("pBBS", Settings.pBBS.Tag.ToString)

            SaveVariousSet("bRemoveCompleted", Settings.bRemoveCompleted.Checked.ToString)
            Dim sFiles As String = ""
            If Converter.ListInputFiles.Count > 0 Then
                For a As Integer = 0 To Converter.ListInputFiles.Count - 1
                    sFiles &= Converter.ListInputFiles.Item(a).FullPath
                    If a < Converter.ListInputFiles.Count - 1 Then
                        sFiles &= "|"
                    End If
                Next
            End If
            SaveVariousSet("Files", sFiles)

        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False

        End Try
        bUpdatingControls = False
    End Sub
    Public Sub LoadAll()
        Dim spOut As String = "", spHTMLObj As String = "", spAnim As String = "", spUTF As String = ""
        Dim spSauce As String = "", spOutPath As String = "", soutPath As String = "", stxtExt As String = ""
        Dim spExt As String = "", spOutExist As String = "", sSanitize As String = "", sNoCols As String = "", sSmalLFnt As String = "", sThumb As String = ""
        Dim sbRemoveCompleted As String = "", spCPin As String = "", spCPout As String = ""
        Dim sThumbResizeOpt As String = "", sThumbScalePercent As String = "", sThumbWidth As String = "", sThumbHeight As String = "", spIMGOut As String = ""
        Dim sBPS As String = "", sFPS As String = "", spVidFmts As String = "", spMPGCodec As String = "", spAVICodec As String = "", sLastFrame As String = ""
        Dim spBBS As String = ""

        Dim sHTMLFontRead As String = ""
        bUpdatingControls = True
        Try
            spOut = UCase(ReadVariousSet("pOut", ""))
            spHTMLObj = UCase(ReadVariousSet("pHTMLObj", "COMPLETE"))
            spAnim = UCase(ReadVariousSet("pAnim", "STATIC"))
            spUTF = UCase(ReadVariousSet("pUTF", "UTF-16"))
            spSauce = UCase(ReadVariousSet("pSauce", "KEEP"))
            spOutPath = UCase(ReadVariousSet("pOutPath", "INPUT"))
            soutPath = ReadVariousSet("outPath", "")
            stxtExt = ReadVariousSet("txtExt", "WEB")
            spExt = UCase(ReadVariousSet("pExt", "REPLACE"))
            spOutExist = UCase(ReadVariousSet("pOutExist", "0"))
            sSanitize = LCase(ReadVariousSet("Sanitize", "true"))
            sNoCols = LCase(ReadVariousSet("NoCols", "true"))
            sSmalLFnt = LCase(ReadVariousSet("SmallFnt", "true"))
            sThumb = LCase(ReadVariousSet("Thumb", "false"))
            sbRemoveCompleted = LCase(ReadVariousSet("bRemoveCompleted", "false"))
            spCPin = ReadVariousSet("pCPin", "CP437")
            spCPout = ReadVariousSet("pCPout", "CP437")

            sThumbResizeOpt = ReadVariousSet("ThumbResizeOpt", "0")
            sThumbScalePercent = ReadVariousSet("ThumbScalePercent", "50")
            sThumbWidth = ReadVariousSet("ThumbWidth", "0")
            sThumbHeight = ReadVariousSet("ThumbHeight", "0")
            spIMGOut = ReadVariousSet("pIMGOut", "PNG")
            sHTMLFontRead = ReadVariousSet("HTMLFont", sHTMLFont)
            sBPS = ReadVariousSet("BPS", "14400")
            sFPS = ReadVariousSet("FPS", "29.97")
            spVidFmts = ReadVariousSet("pVidFmts", "AVI")
            spMPGCodec = ReadVariousSet("pMPGCodec", "MPEG1")
            spAVICodec = ReadVariousSet("pAVICodec", "ZMBV")
            sLastFrame = ReadVariousSet("LastFrame", "3")
            spBBS = ReadVariousSet("pBBS", "PCB")

        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False

        End Try
        bUpdatingControls = False
        Try

            Dim sFiles As String = ""
            sFiles = ReadVariousSet("Files", "")
            If sFiles <> "" Then
                Dim aFiles() As String = Split(sFiles, "|")
                For a As Integer = 0 To aFiles.Length - 1
                    Call AddFile(aFiles(a))
                Next
            End If
        Catch ex As Exception

        End Try
        bUpdatingControls = False
        Try
            bUpdatingControls = True
            Select Case spOut
                Case "ASC"
                    Call MainForm.ControlUpdate(MainForm.outASCII, Nothing)
                Case "ANS"
                    Call MainForm.ControlUpdate(MainForm.outANSI, Nothing)
                Case "HTML"
                    Call MainForm.ControlUpdate(MainForm.outHTML, Nothing)
                Case "UTF"
                    Call MainForm.ControlUpdate(MainForm.outUnicode, Nothing)
                Case "BBS"
                    Call MainForm.ControlUpdate(MainForm.outBBS, Nothing)
                Case "BIN"
                    Call MainForm.ControlUpdate(MainForm.outBinary, Nothing)
                Case "IMG"
                    Call MainForm.ControlUpdate(MainForm.outImage, Nothing)
                Case "AVI"
                    Call MainForm.ControlUpdate(MainForm.outVideo, Nothing)
                Case Else
            End Select
            sHTMLFont = sHTMLFontRead
            Settings.cbHTMLFont.Text = sHTMLFont
            Settings.cbHTMLFont.SelectedValue = sHTMLFont
            Settings.cbHTMLFont.Tag = sHTMLFont
            SelectedWebFont = Settings.cbHTMLFont.SelectedIndex
            Select Case spAVICodec
                Case "ZMBV"
                    Call Settings.ControlUpdate(Settings.rZMBV, Nothing)
                Case "H264"
                    Call Settings.ControlUpdate(Settings.rH264, Nothing)
                Case "MPEG4"
                    Call Settings.ControlUpdate(Settings.rMPEG4, Nothing)
                Case "MJPEG"
                    Call Settings.ControlUpdate(Settings.rMJPEG, Nothing)
                Case "FFVI"
                    Call Settings.ControlUpdate(Settings.rFFVI, Nothing)
                Case "LIBX264"
                    Call Settings.ControlUpdate(Settings.rLIBX264, Nothing)
                Case "LIBXVID"
                    Call Settings.ControlUpdate(Settings.rLIBXVID, Nothing)

            End Select
            Select Case spIMGOut
                Case "PNG"
                    Call Settings.ControlUpdate(Settings.rPNG, Nothing)
                Case "BMP"
                    Call Settings.ControlUpdate(Settings.rBMP, Nothing)
                Case "GIF"
                    Call Settings.ControlUpdate(Settings.rGIF, Nothing)
                Case "JPG"
                    Call Settings.ControlUpdate(Settings.rJPG, Nothing)
                Case "TIF"
                    Call Settings.ControlUpdate(Settings.rTIF, Nothing)
                Case "ICO"
                    Call Settings.ControlUpdate(Settings.rICO, Nothing)
                Case "WMF"
                    Call Settings.ControlUpdate(Settings.rWMF, Nothing)
                Case "EMF"
                    Call Settings.ControlUpdate(Settings.rEMF, Nothing)
            End Select
            Select Case spMPGCodec
                Case "mpeg1video"
                    Call Settings.ControlUpdate(Settings.rMPEG1, Nothing)
                Case "mpeg2video"
                    Call Settings.ControlUpdate(Settings.rMPEG2, Nothing)
            End Select

            Select Case spVidFmts
                Case "AVI"
                    Call Settings.ControlUpdate(Settings.rAVI, Nothing)
                Case "WMV"
                    Call Settings.ControlUpdate(Settings.rWMV, Nothing)
                Case "AGIF"
                    Call Settings.ControlUpdate(Settings.rAGIF, Nothing)
                Case "MPG"
                    Call Settings.ControlUpdate(Settings.rMPG, Nothing)
                Case "FLV"
                    Call Settings.ControlUpdate(Settings.rFLV, Nothing)
                Case "MP4"
                    Call Settings.ControlUpdate(Settings.rMP4, Nothing)
                Case "MKV"
                    Call Settings.ControlUpdate(Settings.rMKV, Nothing)
                Case "VOB"
                    Call Settings.ControlUpdate(Settings.rVOB, Nothing)
            End Select
            Select Case spBBS
                Case "PCB"
                    Call Settings.ControlUpdate(Settings.rPCBoard, Nothing)
                Case "AVT"
                    Call Settings.ControlUpdate(Settings.rAvatar, Nothing)
                Case "WC2"
                    Call Settings.ControlUpdate(Settings.rWildcat2, Nothing)
                Case "WC3"
                    Call Settings.ControlUpdate(Settings.rWildcat3, Nothing)
            End Select
            If spHTMLObj = "COMPLETE" Then
                Call MainForm.ControlUpdate(Settings.rCompleteHTML, Nothing)
            Else
                Call MainForm.ControlUpdate(Settings.rObjectOnly, Nothing)
            End If
            If spAnim = "STATIC" Then
                Call MainForm.ControlUpdate(Settings.rStatic, Nothing)
            Else
                Call MainForm.ControlUpdate(Settings.rAnim, Nothing)
            End If
            If spUTF = "UTF-16" Then
                Call MainForm.ControlUpdate(Settings.rUTF16, Nothing)
            Else
                Call MainForm.ControlUpdate(Settings.rUTF8, Nothing)
            End If
            If spSauce = "KEEP" Then
                Call MainForm.ControlUpdate(Settings.rSauceKeep, Nothing)
            Else
                Call MainForm.ControlUpdate(Settings.rSauceStrip, Nothing)
            End If
            If spOutPath = "INPUT" Then
                Call MainForm.ControlUpdate(MainForm.rOutPathInput, Nothing)
            Else
                Call MainForm.ControlUpdate(MainForm.rOutPathNew, Nothing)
            End If
            MainForm.outPath.FullText = soutPath
            MainForm.txtExt.Text = stxtExt
            Settings.txtFPS.Text = sFPS
            Settings.txtBPS.Text = sBPS
            Settings.txtLastFrame.Text = sLastFrame

            If spExt = "REPLACE" Then
                Call MainForm.ControlUpdate(Settings.rReplaceExt, Nothing)
            Else
                Call MainForm.ControlUpdate(Settings.rExtraExt, Nothing)
            End If
            Select Case spOutExist.ToString
                Case "0"
                    Call Settings.ControlUpdate(Settings.rOver, Nothing)
                Case "1"
                    Call Settings.ControlUpdate(Settings.rSkip, Nothing)
                Case "2"
                    Call Settings.ControlUpdate(Settings.rAutoRen, Nothing)
                Case "3"
                    Call Settings.ControlUpdate(Settings.rAsk, Nothing)
            End Select
            Select Case sThumbResizeOpt.ToString
                Case "0"
                    Call Settings.ControlUpdate(Settings.selThumbProp, Nothing)
                    Settings.ThumbScalePercent.Enabled = True
                    Settings.ThumbWidth.Enabled = False
                    Settings.ThumbHeight.Enabled = False
                Case "1"
                    Call Settings.ControlUpdate(Settings.selThumbWFixed, Nothing)
                    Settings.ThumbScalePercent.Enabled = False
                    Settings.ThumbWidth.Enabled = True
                    Settings.ThumbHeight.Enabled = False

                Case "2"
                    Call Settings.ControlUpdate(Settings.selThumbCustom, Nothing)
                    Settings.ThumbScalePercent.Enabled = False
                    Settings.ThumbWidth.Enabled = False
                    Settings.ThumbHeight.Enabled = True

                Case "3"
                    Call Settings.ControlUpdate(Settings.selThumbHFixed, Nothing)
                    Settings.ThumbScalePercent.Enabled = False
                    Settings.ThumbWidth.Enabled = True
                    Settings.ThumbHeight.Enabled = True

            End Select
            Settings.ThumbScalePercent.Text = sThumbScalePercent
            Settings.ThumbWidth.Text = sThumbWidth
            Settings.ThumbHeight.Text = sThumbHeight




            If sSanitize = "true" Then
                Settings.Sanitize.Checked = True
            Else
                Settings.Sanitize.Checked = False
            End If
            If sSmalLFnt = "true" Then
                Settings.SmallFnt.Checked = True
            Else
                Settings.SmallFnt.Checked = False
            End If
            If sThumb = "true" Then
                Settings.Thumb.Checked = True
            Else
                Settings.Thumb.Checked = False
            End If
            If sNoCols = "true" Then
                Settings.NoCols.Checked = True
            Else
                Settings.NoCols.Checked = False
            End If
            If sbRemoveCompleted = "true" Then
                Settings.bRemoveCompleted.Checked = True
            Else
                Settings.bRemoveCompleted.Checked = False
            End If
            Select Case spOut
                Case "ASC"
                    Call MainForm.ControlUpdate(MainForm.outASCII, Nothing)
                Case "ANS"
                    Call MainForm.ControlUpdate(MainForm.outANSI, Nothing)
                Case "HTML"
                    Call MainForm.ControlUpdate(MainForm.outHTML, Nothing)
                Case "UTF"
                    Call MainForm.ControlUpdate(MainForm.outUnicode, Nothing)
                Case "PCB"
                    Call MainForm.ControlUpdate(MainForm.outBBS, Nothing)
                Case "BIN"
                    Call MainForm.ControlUpdate(MainForm.outBinary, Nothing)
                Case "IMG"
                    Call MainForm.ControlUpdate(MainForm.outImage, Nothing)
                Case "AVI"
                    Call MainForm.ControlUpdate(MainForm.outVideo, Nothing)
                Case Else
            End Select
            MainForm.inCP.Text = spCPin
            MainForm.outCP.Text = spCPout
            bUpdatingControls = False
            UpdateControls()


        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False

        End Try

        bUpdatingControls = False
    End Sub
    Public Function SelectFolder(Optional ByVal sDefault As String = "", Optional ByVal Desc As String = "Select the Folder to process.", Optional ByVal shownew As Boolean = True) As String
        Dim result As Integer

        If sDefault <> "" Then
            MainForm.FolderBrowserDialog1.SelectedPath = sDefault
        End If

        MainForm.FolderBrowserDialog1.Description = Desc

        MainForm.FolderBrowserDialog1.ShowNewFolderButton = shownew
        result = MainForm.FolderBrowserDialog1.ShowDialog()
        If result = 1 Then
            If IO.Directory.Exists(MainForm.FolderBrowserDialog1.SelectedPath) = True Then
                SelectFolder = MainForm.FolderBrowserDialog1.SelectedPath
            Else
                SelectFolder = sDefault
            End If
        Else
            SelectFolder = sDefault
        End If

    End Function

    Public Sub SelectFiles()
        Dim result As Integer = 0
        If MainForm.btnAdd.Tag <> "" Then
            If IO.File.Exists(MainForm.btnAdd.Tag) = False Then

            Else
                MainForm.OpenFileDialog1.FileName = MainForm.btnAdd.Tag
            End If
        End If
        Dim sFileN As String = ReadVariousSet("LastOpenPath", "")
        MainForm.OpenFileDialog1.FileName = sFileN
        If MainForm.OpenFileDialog1.FileName = "OpenFileDialog1" Then
            MainForm.OpenFileDialog1.FileName = ""
        End If
        If MainForm.OpenFileDialog1.FileName <> "" Then
            MainForm.OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(MainForm.OpenFileDialog1.FileName)

        End If
        MainForm.OpenFileDialog1.CheckFileExists = True
        result = MainForm.OpenFileDialog1.ShowDialog()
        If result <> 2 And result <> 3 Then
            If MainForm.OpenFileDialog1.FileName <> "" Then
                Dim aFiles() As String = MainForm.OpenFileDialog1.FileNames
                MainForm.listFiles.SuspendLayout()
                bAddingFiles = True
                For a As Integer = 0 To UBound(aFiles)
                    If aFiles(a) <> "" Then
                        SaveVariousSet("LastOpenPath", aFiles(a))
                        AddFile(aFiles(a))
                    End If
                    If a / 10 = CInt(a \ 10) Then
                        RefreshListFiles()
                        My.Application.DoEvents()
                    End If
                Next
                bAddingFiles = False
                MainForm.listFiles.ResumeLayout()
                RefreshListFiles()
            End If
        End If
    End Sub



    Public Sub AddFormattedRichText(ByVal rt As RichTextBox, ByVal str As String, Optional ByVal nolinebreak As Boolean = False, Optional ByVal removeprevious As Boolean = False)
        rt.DetectUrls = True
        Dim iOff As Integer = Len(rt.Text)
        Dim attr As List(Of fmts) = New List(Of fmts)
        Dim sels As List(Of sel) = New List(Of sel)
        Dim ifont As New Font(rt.Font, FontStyle.Italic)
        Dim bfont As New Font(rt.Font, FontStyle.Bold)
        Dim ufont As New Font(rt.Font, FontStyle.Underline)
        Dim ffont As New Font(rt.Font.FontFamily, rt.Font.SizeInPoints + 2, FontStyle.Italic Or FontStyle.Bold, GraphicsUnit.Pixel, 0)
        Dim lfont As New Font("Default, Monospace", rt.Font.SizeInPoints, FontStyle.Underline, GraphicsUnit.Pixel, 0)
        Dim sfont As New Font("Default, Monospace", rt.Font.SizeInPoints + 2, FontStyle.Underline, GraphicsUnit.Pixel, 0)
        Dim tfont As New Font(rt.Font.FontFamily, rt.Font.SizeInPoints + 1, FontStyle.Underline Or FontStyle.Bold, GraphicsUnit.Pixel, 0)
        If removeprevious = True Then
            Try
                rt.Text = Strings.Left(rt.Text, iSelectionStartBak)
                'rt.SelectionStart = iSelectionStartBak
                'rt.SelectionLength = iLastRTFTextLen
                'rt.SelectedText.Remove(0, iLastRTFTextLen)
                'rt.Cut()
                'rt.SelectionStart = Len(rt.Text)
                iOff = Len(rt.Text)
                rt.ScrollToCaret()

                '                iOff = Len(rt.Text)
            Catch ex As Exception

            End Try
        End If
        If rt.Name = "log" Then
            If str <> "." Then
                If bNoDot = False And DotCount > 0 Then
                    Try
                        Dim iDel As Integer = Len(rt.Text) - DotCount
                        rt.SelectionStart = iDel
                        rt.SelectionLength = DotCount
                        rt.Cut()
                        rt.SelectionStart = Len(rt.Text)
                        iOff = Len(rt.Text)
                        rt.ScrollToCaret()
                        DotCount = 0

                    Catch ex As Exception

                    End Try
                End If
                bNoDot = True
            End If
        End If
        attr.Add(New fmts("b", fnts.bold))
        attr.Add(New fmts("i", fnts.italic))
        attr.Add(New fmts("u", fnts.underline))
        attr.Add(New fmts("e", fnts.err))
        attr.Add(New fmts("f", fnts.finished))
        attr.Add(New fmts("l", fnts.link))
        attr.Add(New fmts("s", fnts.sep))
        attr.Add(New fmts("t", fnts.total))
        Dim istart As Integer = InStr(str, "[", CompareMethod.Text)
        Dim iEnd As Integer = istart + 1
        Dim bfound As Boolean = False
        Do While istart > 0
            If Mid(str, istart + 1, 1) = "/" Then
                'look for matching end marker
                For a As Integer = 0 To attr.Count - 1
                    If StrComp(attr.Item(a).elem & "]", Mid(str, istart + 2, Len(attr.Item(a).elem) + 1), CompareMethod.Text) = 0 Then
                        sels.Add(New sel(attr.Item(a).fnt, attr.Item(a).start.Pop, istart))
                        iEnd = istart + 2 + Len(attr.Item(a).elem)
                    End If
                Next
            Else
                'look for matching start marker
                For a As Integer = 0 To attr.Count - 1
                    If StrComp(attr.Item(a).elem & "]", Mid(str, istart + 1, Len(attr.Item(a).elem) + 1), CompareMethod.Text) = 0 Then
                        attr.Item(a).start.Push(istart)
                        iEnd = istart + 1 + Len(attr.Item(a).elem)
                    End If
                Next
            End If
            Dim sleft As String = Microsoft.VisualBasic.Left(str, istart - 1)
            Dim sright As String = Microsoft.VisualBasic.Right(str, Len(str) - iEnd)
            str = sleft & sright
            istart = InStr(str, "[", CompareMethod.Text)
            iEnd = istart + 1
        Loop
        iSelectionStartBak = iOff
        rt.SelectionStart = iOff
        If nolinebreak = True Then
            rt.SelectedText = str
        Else
            rt.SelectedText = str & vbCrLf
        End If
        rt.ScrollToCaret()

        If sels.Count > 0 Then
            For j As Integer = 0 To sels.Count - 1
                rt.SelectionStart = iOff + sels.Item(j).fromval - 1
                rt.SelectionLength = sels.Item(j).toval - sels.Item(j).fromval
                Select Case sels.Item(j).format
                    Case fnts.bold
                        'rt.SelectionFont = bfont
                        rt.SelectionColor = Color.Black
                    Case fnts.italic
                        rt.SelectionFont = ifont
                        rt.SelectionColor = Color.Blue
                    Case fnts.underline
                        rt.SelectionFont = ufont
                    Case fnts.err
                        rt.SelectionColor = Color.Red
                    Case fnts.finished
                        rt.SelectionFont = ffont
                        rt.SelectionColor = Color.Green
                    Case fnts.link
                        rt.SelectionFont = lfont
                        rt.SelectionColor = Color.Navy
                    Case fnts.sep
                        rt.SelectedText = Replace(Space(80), " ", "-", 1, -1, CompareMethod.Text)
                        iLastRTFTextLen = 80
                        rt.SelectionLength = 30
                        rt.SelectionFont = sfont
                        rt.SelectionColor = Color.Silver

                    Case fnts.total
                        rt.SelectionFont = tfont
                        rt.SelectionColor = Color.Gray
                End Select
            Next
        End If
        iLastRTFTextLen = rt.TextLength - iSelectionStartBak

    End Sub
    Public Sub ErrMsg(ByVal msg As String, Optional ByVal nolinebreak As Boolean = False)
        Call InfoMsg("[e]" & msg & "[/e]", nolinebreak)
    End Sub
    Public Sub InfoMsg(ByVal msg As String, Optional ByVal nolinebreak As Boolean = False, Optional ByVal removeprev As Boolean = False)
        If nolinebreak Then
            AddFormattedRichText(MainForm.log, msg, nolinebreak, removeprev)
        Else
            AddFormattedRichText(MainForm.log, " - " & msg, nolinebreak, removeprev)
        End If

    End Sub

    Public Sub SummSettings()
        If ANSI_ASCII_Converter.Settings.rCompleteHTML.Checked = True Then
            MainForm.settHTMLObj.Text = "Full HTML"
        Else
            MainForm.settHTMLObj.Text = "DIV Only"
        End If
        If ANSI_ASCII_Converter.Settings.rStatic.Checked = True Then
            MainForm.settAnim.Text = " / Static"
        Else
            MainForm.settAnim.Text = " / Anim"
        End If
        If ANSI_ASCII_Converter.Settings.NoCols.Checked = True Then
            MainForm.settNoCols.Text = "No Colors"
        Else
            MainForm.settNoCols.Text = "Colored"
        End If
        If ANSI_ASCII_Converter.Settings.SmallFnt.Checked = True Then
            MainForm.settSMALLFNT.Text = " / 80x50 Lines Mode"
        Else
            MainForm.settSMALLFNT.Text = " / 80x25 Lines Mode"
        End If
        If ANSI_ASCII_Converter.Settings.Thumb.Checked = True Then
            MainForm.attCreTh.Text = "Thumbnails"
        Else
            MainForm.attCreTh.Text = "Image"
        End If
        MainForm.settHTMLFont.Text = "HTML Font: " & sHTMLFont
        If ANSI_ASCII_Converter.Settings.Sanitize.Checked = True Then
            MainForm.settSanitize.Text = ", Sanitize: Yes"
        Else
            MainForm.settSanitize.Text = ", Sanitize: No"
        End If
        If ANSI_ASCII_Converter.Settings.Thumb.Checked = True Then
            Select Case ANSI_ASCII_Converter.Settings.pThumbs.Tag.ToString
                Case "0"
                    MainForm.settThumbs.Text = "Scale: " & ANSI_ASCII_Converter.Settings.ThumbScalePercent.Text.ToString & "%"
                Case "1"
                    MainForm.settThumbs.Text = "Fixed Width w: " & ANSI_ASCII_Converter.Settings.ThumbWidth.Text.ToString
                Case "2"
                    MainForm.settThumbs.Text = "Fixed Height h: " & ANSI_ASCII_Converter.Settings.ThumbHeight.Text.ToString
                Case "3"
                    MainForm.settThumbs.Text = "Custom:  w: " & ANSI_ASCII_Converter.Settings.ThumbWidth.Text.ToString & ", h: " & ANSI_ASCII_Converter.Settings.ThumbHeight.Text.ToString
            End Select
        Else
            MainForm.settThumbs.Text = "Original Size"
        End If
        If ANSI_ASCII_Converter.Settings.rUTF8.Checked = True Then
            MainForm.settUTF.Text = "UTF-8"
        Else
            MainForm.settUTF.Text = "UTF-16"
        End If
        If ANSI_ASCII_Converter.Settings.bRemoveCompleted.Checked = True Then
            MainForm.settGen.Text = "List: Auto-Remove Completed"
        Else
            MainForm.settGen.Text = "List: Keep Completed"
        End If
        MainForm.settVidFmt.Text = "Video: " & Settings.pVidFmts.Tag.ToString
        Select Case Settings.pVidFmts.Tag.ToString
            Case "AVI"
                MainForm.settVidCodec.Text = "(" & Settings.pAVICodec.Tag.ToString & ")"
            Case "MPG"
                MainForm.settVidCodec.Text = "(" & Replace(Settings.pMPGCodec.Tag.ToString, "video", "", 1, -1, CompareMethod.Text) & ")"
            Case Else
                MainForm.settVidCodec.Text = ""
        End Select
        MainForm.settVideo.Text = "FPS: " & FPS.ToString & " / BPS: " & BPS.ToString
        MainForm.settLFExt.Text = Settings.txtLastFrame.Text.ToString & " sec"
        If ANSI_ASCII_Converter.Settings.rSauceStrip.Checked = True Then
            MainForm.settSauce.Text = "Sauce: Strip"
        Else
            MainForm.settSauce.Text = "Sauce: Keep"
        End If
        Select Case ANSI_ASCII_Converter.Settings.pBBS.Tag.ToString
            Case "PCB"
                MainForm.settBBS.Text = "BBS: PCBoard"
            Case "AVT"
                MainForm.settBBS.Text = "BBS: Avatar"
            Case "WC2"
                MainForm.settBBS.Text = "BBS: Wildcat 2"
            Case "WC3"
                MainForm.settBBS.Text = "BBS: Wildcat 3"
        End Select

        Select Case ANSI_ASCII_Converter.Settings.pOutExist.Tag.ToString
            Case "0"
                MainForm.settExist.Text = "Exist: Over"
            Case "1"
                MainForm.settExist.Text = "Exist: Skip"
            Case "2"
                MainForm.settExist.Text = "Exist: Auto-Ren"
            Case "3"
                MainForm.settExist.Text = "Exist: Ask"
        End Select
        If ANSI_ASCII_Converter.Settings.rExtraExt.Checked = True Then
            MainForm.settExt.Text = "Ext: Append"
        Else
            MainForm.settExt.Text = "Ext: Replace"
        End If
        MainForm.settImgOut.Text = ", Image Format: " & Settings.pIMGOut.Tag

        MainForm.settSanitize.Tag = Color.Black
        MainForm.settGen.Tag = Color.Black
        MainForm.settExist.Tag = Color.Black
        MainForm.settExt.Tag = Color.Black
        If MainForm.pOut.Tag.ToString = "IMG" Or MainForm.pOut.Tag.ToString = "AVI" Then
            MainForm.settSMALLFNT.ForeColor = Color.Black
            MainForm.settNoCols.ForeColor = Color.Black
            MainForm.settSMALLFNT.Tag = Color.Black
            MainForm.settNoCols.Tag = Color.Black
            If MainForm.pOut.Tag.ToString = "IMG" Then
                MainForm.attCreTh.ForeColor = Color.Black
                MainForm.attCreTh.Tag = Color.Black
                MainForm.settThumbs.ForeColor = Color.Black
                MainForm.settThumbs.Tag = Color.Black
                MainForm.settImgOut.ForeColor = Color.Black
                MainForm.settImgOut.Tag = Color.Black
            Else
                MainForm.attCreTh.ForeColor = Color.Gray
                MainForm.attCreTh.Tag = Color.Gray
                MainForm.settThumbs.ForeColor = Color.Gray
                MainForm.settThumbs.Tag = Color.Gray
                MainForm.settImgOut.ForeColor = Color.Gray
                MainForm.settImgOut.Tag = Color.Gray
            End If
            If MainForm.pOut.Tag.ToString = "AVI" Then
                MainForm.settVideo.ForeColor = Color.Black
                MainForm.settVideo.Tag = Color.Black
                MainForm.settVidFmt.ForeColor = Color.Black
                MainForm.settVidFmt.Tag = Color.Black
                MainForm.settLFExt.ForeColor = Color.Black
                MainForm.settLFExt.Tag = Color.Black
                If Settings.pVidFmts.Tag.ToString = "AVI" Or Settings.pVidFmts.Tag.ToString = "MPG" Then
                    MainForm.settVidCodec.ForeColor = Color.Black
                    MainForm.settVidCodec.Tag = Color.Black
                Else
                    MainForm.settVidCodec.ForeColor = Color.Gray
                    MainForm.settVidCodec.Tag = Color.Gray
                End If
            Else
                MainForm.settVideo.ForeColor = Color.Gray
                MainForm.settVideo.Tag = Color.Gray
                MainForm.settVidFmt.ForeColor = Color.Gray
                MainForm.settVidFmt.Tag = Color.Gray
                MainForm.settVidCodec.ForeColor = Color.Gray
                MainForm.settVidCodec.Tag = Color.Gray
                MainForm.settLFExt.ForeColor = Color.Gray
                MainForm.settLFExt.Tag = Color.Gray
            End If
        Else
            MainForm.settNoCols.ForeColor = Color.Gray
            MainForm.settNoCols.Tag = Color.Gray
            MainForm.settSMALLFNT.ForeColor = Color.Gray
            MainForm.settSMALLFNT.Tag = Color.Gray
            MainForm.attCreTh.ForeColor = Color.Gray
            MainForm.attCreTh.Tag = Color.Gray
            MainForm.settThumbs.ForeColor = Color.Gray
            MainForm.settThumbs.Tag = Color.Gray
            MainForm.settImgOut.ForeColor = Color.Gray
            MainForm.settImgOut.Tag = Color.Gray
            MainForm.settVideo.ForeColor = Color.Gray
            MainForm.settVideo.Tag = Color.Gray
            MainForm.settVidFmt.ForeColor = Color.Gray
            MainForm.settVidFmt.Tag = Color.Gray
            MainForm.settVidCodec.ForeColor = Color.Gray
            MainForm.settVidCodec.Tag = Color.Gray
            MainForm.settLFExt.ForeColor = Color.Gray
            MainForm.settLFExt.Tag = Color.Gray
        End If

        If MainForm.pOut.Tag.ToString = "HTML" Then
            MainForm.settHTMLFont.ForeColor = Color.Black
            MainForm.settHTMLFont.Tag = Color.Black
            MainForm.settHTMLObj.ForeColor = Color.Black
            MainForm.settHTMLObj.Tag = Color.Black
            MainForm.settAnim.ForeColor = Color.Black
            MainForm.settAnim.Tag = Color.Black
        Else
            MainForm.settHTMLFont.ForeColor = Color.Gray
            MainForm.settHTMLFont.Tag = Color.Gray
            MainForm.settHTMLObj.ForeColor = Color.Gray
            MainForm.settHTMLObj.Tag = Color.Gray
            MainForm.settAnim.ForeColor = Color.Gray
            MainForm.settAnim.Tag = Color.Gray
        End If
        If MainForm.pOut.Tag.ToString = "UTF" Then
            MainForm.settUTF.ForeColor = Color.Black
            MainForm.settUTF.Tag = Color.Black
        Else
            MainForm.settUTF.ForeColor = Color.Gray
            MainForm.settUTF.Tag = Color.Gray
        End If
        If MainForm.pOut.Tag.ToString = "BBS" Then
            MainForm.settBBS.ForeColor = Color.Black
            MainForm.settBBS.Tag = Color.Black
        Else
            MainForm.settBBS.ForeColor = Color.Gray
            MainForm.settBBS.Tag = Color.Gray
        End If
        If MainForm.pOut.Tag.ToString <> "IMG" And Settings.rAnim.Checked = False Then
            MainForm.settSauce.ForeColor = Color.Black
            MainForm.settSauce.Tag = Color.Black
        Else
            MainForm.settSauce.ForeColor = Color.Gray
            MainForm.settSauce.Tag = Color.Gray
        End If
    


    End Sub

End Module
