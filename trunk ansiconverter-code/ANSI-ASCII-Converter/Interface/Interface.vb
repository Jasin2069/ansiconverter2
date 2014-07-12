Imports System.Runtime.InteropServices.Marshal
Imports System.Windows.Forms

Public Module UserInterface
    Public MainThreadID As String = ""

    Public Sub InitializeForm()



        ListIn2.Add(oMainForm.in2ASCII)
        ListCntLabels.Add(oMainForm.cntASCII)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2ANSI)
        ListCntLabels.Add(oMainForm.cntANSI)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2HTML)
        ListCntLabels.Add(oMainForm.cntHTML)
        ListInCPVis.Add(False)
        ListIn2.Add(oMainForm.in2Unicode)
        ListCntLabels.Add(oMainForm.cntUNI)
        ListInCPVis.Add(False)
        ListIn2.Add(oMainForm.in2PCBoard)
        ListCntLabels.Add(oMainForm.cntPCB)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2Binary)
        ListCntLabels.Add(oMainForm.cntBIN)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2Wildcat2)
        ListCntLabels.Add(oMainForm.cntWC2)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2Wildcat3)
        ListCntLabels.Add(oMainForm.cntWC3)
        ListInCPVis.Add(True)
        ListIn2.Add(oMainForm.in2Avatar)
        ListCntLabels.Add(oMainForm.cntAVT)
        ListInCPVis.Add(True)


        ListOut.Add(oMainForm.outASCII)
        ListOut.Add(oMainForm.outANSI)
        ListOut.Add(oMainForm.outHTML)
        ListOut.Add(oMainForm.outUnicode)
        ListOut.Add(oMainForm.outBBS)
        ListOut.Add(oMainForm.outBinary)
        ListOut.Add(oMainForm.outImage)
        ListOut.Add(oMainForm.outVideo)

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

        ListOutExtTrig.Add(oMainForm.outImage)
        ListOutExt.Add("PNG")
        ListOutExtReqOutSet.Add("IMG")
        ListOutExtTrig.Add(oMainForm.outVideo)
        ListOutExt.Add("AVI")
        ListOutExtReqOutSet.Add("AVI")
        ListOutExtTrig.Add(oMainForm.outHTML)
        ListOutExt.Add("HTM")
        ListOutExtReqOutSet.Add("HTML")
        ListOutExtTrig.Add(oMainForm.outASCII)
        ListOutExt.Add("ASC")
        ListOutExtReqOutSet.Add("ASC")
        ListOutExtTrig.Add(oMainForm.outANSI)
        ListOutExt.Add("ANS")
        ListOutExtReqOutSet.Add("ANS")
        ListOutExtTrig.Add(oMainForm.outUnicode)
        ListOutExt.Add("TXT")
        ListOutExtReqOutSet.Add("UTF")
        ListOutExtTrig.Add(oMainForm.outBBS)
        ListOutExt.Add("PCB")
        ListOutExtReqOutSet.Add("BBS")
        ListOutExtTrig.Add(oMainForm.outBinary)
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

        ListOutPath.Add(oMainForm.rOutPathInput)
        ListOutPath.Add(oMainForm.rOutPathNew)

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



        ListSettLabels.Add(oMainForm.settGen)
        ListSettPanels.Add(Settings.pGen)
        ListSettLabels.Add(oMainForm.settSauce)
        ListSettPanels.Add(Settings.pSauce)
        ListSettLabels.Add(oMainForm.settExist)
        ListSettPanels.Add(Settings.pOutExist)
        ListSettLabels.Add(oMainForm.settExt)
        ListSettPanels.Add(Settings.pExt)
        ListSettLabels.Add(oMainForm.settUTF)
        ListSettPanels.Add(Settings.pUTF)
        ListSettLabels.Add(oMainForm.settHTMLObj)
        ListSettPanels.Add(Settings.pHTMLObj)
        ListSettLabels.Add(oMainForm.settAnim)
        ListSettPanels.Add(Settings.pAnim)
        ListSettLabels.Add(oMainForm.settSanitize)
        ListSettPanels.Add(Settings.pSanitize)
        ListSettLabels.Add(oMainForm.settHTMLFont)
        ListSettPanels.Add(Settings.pHTMLFont)
        ListSettLabels.Add(oMainForm.settNoCols)
        ListSettPanels.Add(Settings.pNoCols)
        ListSettLabels.Add(oMainForm.settSMALLFNT)
        ListSettPanels.Add(Settings.pSmallFnt)
        ListSettLabels.Add(oMainForm.attCreTh)
        ListSettPanels.Add(Settings.pThumb)
        ListSettLabels.Add(oMainForm.settImgOut)
        ListSettPanels.Add(Settings.pIMGOut)
        ListSettLabels.Add(oMainForm.settThumbs)
        ListSettPanels.Add(Settings.pThumbs)
        ListSettLabels.Add(oMainForm.settVideo)
        ListSettPanels.Add(Settings.pVideo)
        ListSettLabels.Add(oMainForm.settVidFmt)
        ListSettPanels.Add(Settings.pVidFmts)
        ListSettLabels.Add(oMainForm.settVidCodec)
        ListSettPanels.Add(Settings.pMPGCodec)
        ListSettPanels.Add(Settings.pAVICodec)
        ListSettLabels.Add(oMainForm.settLFExt)
        ListSettPanels.Add(Settings.pLFrame)
        ListSettLabels.Add(oMainForm.settBBS)
        ListSettPanels.Add(Settings.pBBS)

        ListDepends.Add(New ControlDepends(oMainForm.in2ANSI, "checked", True, oMainForm.outVideo, "visible", True))
        ListDepends.Add(New ControlDepends(oMainForm.in2ASCII, "checked", True, oMainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.in2HTML, "checked", True, oMainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.in2PCBoard, "checked", True, oMainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.in2Unicode, "checked", True, oMainForm.outVideo, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.in2Binary, "checked", True, oMainForm.outVideo, "visible", False))

        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", True, oMainForm.outPath, "visible", True))
        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", True, oMainForm.btnOutputFolder, "visible", True))
        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", False, oMainForm.outPath, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", False, oMainForm.btnOutputFolder, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", True, oMainForm.lblInfoSameDirOut, "visible", False))
        ListDepends.Add(New ControlDepends(oMainForm.rOutPathNew, "checked", False, oMainForm.lblInfoSameDirOut, "visible", True))

        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", False, Settings.ThumbScalePercent, "Enabled", False))

        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))
        ListDepends.Add(New ControlDepends(Settings.selThumbProp, "checked", True, Settings.ThumbScalePercent, "Enabled", True))

        ListDepends.Add(New ControlDepends(Settings.rAVI, "checked", True, Settings.pAVICodec, "Visible", True))
        ListDepends.Add(New ControlDepends(Settings.rAVI, "checked", False, Settings.pAVICodec, "Visible", False))
        ListDepends.Add(New ControlDepends(Settings.rMPG, "checked", True, Settings.pMPGCodec, "Visible", True))
        ListDepends.Add(New ControlDepends(Settings.rMPG, "checked", False, Settings.pMPGCodec, "Visible", False))
        ListDepends.Add(New ControlDepends(Settings.Thumb, "checked", False, Settings.pThumbs, "Visible", False))
        ListDepends.Add(New ControlDepends(Settings.Thumb, "checked", True, Settings.pThumbs, "Visible", True))

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

        ToolTipAndEvents(oMainForm.in2ASCII, "Input file(s) are " & vbCrLf & "MS DOS ASCII text files")
        ToolTipAndEvents(oMainForm.in2ANSI, "Input file(s) are MS DOS" & vbCrLf & "text files with" & vbCrLf & "ESC control sequences" & vbCrLf & "for terminal colors")
        ToolTipAndEvents(oMainForm.in2HTML, "Input file(s) are ASCII text" & vbCrLf & "formated HTML code" & vbCrLf & "where the Unicode" & vbCrLf & "characters were HTML" & vbCrLf & "encoded for display on the web." & vbCrLf & "It's the reverse of my" & vbCrLf & "HTML encoding function," & vbCrLf & "but only works for" & vbCrLf & "ASCII's (not ANSIs)")
        ToolTipAndEvents(oMainForm.in2Unicode, "Input file(s) are Unicode" & vbCrLf & "(UTF-8 or UTF-16) encoded" & vbCrLf & "text files for Windows")
        ToolTipAndEvents(oMainForm.in2PCBoard, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the PCBoard" & vbCrLf & "BBS Software." & vbCrLf & "(@X.. color codes)")
        ToolTipAndEvents(oMainForm.in2Wildcat2, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the Wildcat V2.X" & vbCrLf & "BBS Software." & vbCrLf & "(ANSI Like Codes)")
        ToolTipAndEvents(oMainForm.in2Wildcat3, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding" & vbCrLf & "used by the Wildcat V3.X" & vbCrLf & "BBS Software." & vbCrLf & "(@..@ color codes)")
        ToolTipAndEvents(oMainForm.in2Avatar, "Input files are in PC DOS" & vbCrLf & "ASCII text format" & vbCrLf & "with Color Encoding in AVATAR Format")

        ToolTipAndEvents(oMainForm.in2Binary, "Input files are MS DOS" & vbCrLf & "Binary encoded graphics files" & vbCrLf & "ANSIs with double the width" & vbCrLf & "of a normal PC ANSI" & vbCrLf & "file (160 chars instead of 80)")
        ToolTipAndEvents(oMainForm.lblCPin, "Code Page that was used" & vbCrLf & "originally. This only matters," & vbCrLf & "if the file uses characters that" & vbCrLf & "are different between code pages." & vbCrLf & "These are typically reginal text " & vbCrLf & "characters and some graphical" & vbCrLf & "elements as well, especially borders.")
        ToolTipAndEvents(oMainForm.lblCPout, "Code Page that should be used" & vbCrLf & "for the output DOS ASCII file." & vbCrLf & "This only matters, if " & vbCrLf & "characters were used that " & vbCrLf & "are different in different " & vbCrLf & "Code Page settings.")
        ToolTipAndEvents(oMainForm.outASCII, "Convert output to MS DOS PC ASCII text files")
        ToolTipAndEvents(oMainForm.outANSI, "Convert output to MSDOS" & vbCrLf & "PC Text files with" & vbCrLf & "ESC sequences for" & vbCrLf & "color encoding.")
        ToolTipAndEvents(oMainForm.outHTML, "Convert output to ASCII text" & vbCrLf & "(HTML) with HTML encoded" & vbCrLf & "Unicode charcters and" & vbCrLf & "using CSS for styling" & vbCrLf & "and coloring (of ANSIs)")
        ToolTipAndEvents(oMainForm.outUnicode, "Convert output to" & vbCrLf & "Windows PC/Unicode encoded" & vbCrLf & "plain text files.")
        ToolTipAndEvents(oMainForm.outBBS, "Convert output to ANSI-like" & vbCrLf & "text for DOS, in a format" & vbCrLf & "used by a specified Bulletin Board System software.")
        ToolTipAndEvents(oMainForm.outBinary, "Convert output to binary" & vbCrLf & "image DOS format for" & vbCrLf & "double width ANSIs or ASCIIs. ")
        ToolTipAndEvents(oMainForm.outImage, "Convert output to an Bitmap Image" & vbCrLf & "The specified Extension determines " & vbCrLf & "the Image Format. Supported " & vbCrLf & "Image Formats: PNG, BMP, JPG, GIF, TIF, ICO, WMF, EMF")
        ToolTipAndEvents(oMainForm.outVideo, "Convert ANSI Animation to Video")
        ToolTipAndEvents(oMainForm.rOutPathInput, "Use same path for output" & vbCrLf & "as the original input file")
        ToolTipAndEvents(oMainForm.rOutPathNew, "Write all outputs to the" & vbCrLf & "same folder location specified.")
        ToolTipAndEvents(oMainForm.btnOutputFolder, "Select folder location" & vbCrLf & "for all outputs")
        ToolTipAndEvents(oMainForm.numSel, "Number of files in the input" & vbCrLf & "file list that are currently" & vbCrLf & "selected and could be removed" & vbCrLf & "from the list, leaving any other" & vbCrLf & "non-selected file still in the list.")
        ToolTipAndEvents(oMainForm.numUTF8, "Number of UTF-8 Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(oMainForm.numUTF16, "Number of UTF-16 Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(oMainForm.numASCII, "Number of Non-Unicode encoded" & vbCrLf & "files in the file listing box")
        ToolTipAndEvents(oMainForm.numTotal, "Total Number of files in the" & vbCrLf & "file listing box of any type of" & vbCrLf & "encoding and format.")
        ToolTipAndEvents(oMainForm.lblDropHere, "Drop file from Windows" & vbCrLf & "directly into this list" & vbCrLf & "for selection and future" & vbCrLf & "processing.")
        ToolTipAndEvents(oMainForm.lblLogAndInfos, "Output messages as log," & vbCrLf & "showing information about" & vbCrLf & "the current files being processed" & vbCrLf & "as well as warnings and errors.")
        ToolTipAndEvents(oMainForm.btnUniBlocks, "Show Unicode Character" & vbCrLf & "Sets Grouped in Blocks")
        ToolTipAndEvents(oMainForm.btnCPMaps, "Show Unicode Mappings and" & vbCrLf & "Special HTML Encoding for" & vbCrLf & "the various DOS and" & vbCrLf & "Windows Code Pages")
        ToolTipAndEvents(oMainForm.btnSearch, "Search Unicode Character" & vbCrLf & "Definitions, by Code, Name and more")
        ToolTipAndEvents(oMainForm.btnSettings2, "Modify Program Settings")
        ToolTipAndEvents(oMainForm.btnSettings, "Modify Program Settings")
        'lblSelInput
        'btnSettings2
        ToolTipAndEvents(oMainForm.lblInputFormats, "The tool automatically" & vbCrLf & "detects the format of the" & vbCrLf & "selected files and" & vbCrLf & "updates counts/checks formats" & vbCrLf & "while you select more" & vbCrLf & "files to process.")
        ToolTipAndEvents(oMainForm.lblOutput, "The selection for possible" & vbCrLf & "output formats depends on" & vbCrLf & "the types of files added to" & vbCrLf & "the list for processing")
        ToolTipAndEvents(oMainForm.btnNFO, "Open the Release" & vbCrLf & "NFO File for this" & vbCrLf & "Tool(Version)")

        ToolTipAndEvents(oMainForm.txtExt, "Extension used for Output Files")

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

        ToolTipSettAndEvents(Settings.lblIMGOut, "Select the bitmap output format" & vbCrLf & "for the export to images option")
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
            oMainForm.SuspendLayout()
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


            If outSelected = -1 Then : oMainForm.pOut.Tag = "" : End If
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
            oMainForm.ResumeLayout(False)
            bUpdatingControls = False
            oMainForm.PerformLayout()
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
                        If oMainForm.pOut.Tag = ListOutExtReqOutSet.Item(iFound) Then
                            If Not ListOutExt.Item(iFound).Equals(oMainForm.txtExt.Text) Then
                                bUpdatingControls = True
                                oMainForm.txtExt.Text = ListOutExt.Item(iFound)
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

        oMainForm.FileListItemBindingSource.SuspendBinding()
        oMainForm.FileListItemBindingSource.Clear()
        Converter.ListInputFiles.Clear()
        oMainForm.FileListItemBindingSource.ResumeBinding()

        'MainForm.listFiles.DataSource = Nothing
        'MainForm.listFiles.DataSource = Converter.ListInputFiles
        'MainForm.listFiles.Items.Clear()
        UpdateCounts()
        UpdateControls()
    End Sub

    Public Delegate Sub delAddFile(ByVal sFile As String)
    Public dlg As New delAddFile(AddressOf AddFile)
    Public Sub AddFile(ByVal sFile As String)
        If Not isMainThread() Then
            dlg.Invoke(sFile)
            Exit Sub
        End If
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
            'MainForm.listFiles.BindingContext.Item(0).SuspendBinding()
            'Console.WriteLine("sFile:" & sFile)
            'Console.WriteLine("MainForm.outPath.FullText:" & MainForm.outPath.FullText)
            'Console.WriteLine("GetDir:" & IO.Path.GetDirectoryName(sFile))
            Dim item = New Converter.FileListItem(IO.Path.GetFileName(sFile), sFile, ff, ft)
            oMainForm.FileListItemBindingSource.SuspendBinding()
            Converter.ListInputFiles.Add(item)
            oMainForm.FileListItemBindingSource.Add(item)
            oMainForm.FileListItemBindingSource.ResumeBinding()
            If Not bBatchAdd Then
                oMainForm.PerformLayout()
            End If
            If oMainForm.outPath.FullText = "" Then
                oMainForm.outPath.Text = IO.Path.GetDirectoryName(sFile)
                oMainForm.outPath.FullText = IO.Path.GetDirectoryName(sFile)
            End If
            If bAddingFiles = False Then

                'RefreshListFiles()
            End If
        End If
    End Sub
    Public Sub RefreshListFiles()
        'MainForm.listFiles.DataSource = Nothing
        'MainForm.listFiles.DataSource = Converter.ListInputFiles
        oMainForm.listFiles.PerformLayout()
        UpdateCounts()
        UpdateControls()
    End Sub
    Public Sub RemoveSelectedFiles()
        Dim cnt As Integer = oMainForm.listFiles.SelectedItems.Count

        If cnt > 0 Then
            Dim l As New List(Of Converter.FileListItem)
            For a As Integer = cnt - 1 To 0 Step -1
                l.Add(oMainForm.listFiles.SelectedItems.Item(a))
            Next
            oMainForm.FileListItemBindingSource.SuspendBinding()
            oMainForm.SuspendLayout()
            For a As Integer = l.Count - 1 To 0 Step -1
                Converter.ListInputFiles.Remove(l.Item(a))
                oMainForm.FileListItemBindingSource.Remove(l.Item(a))
            Next
            l.Clear()
            l = Nothing
            'MainForm.listFiles.DataSource = Nothing
            'MainForm.listFiles.DataSource = Converter.ListInputFiles
            oMainForm.FileListItemBindingSource.ResumeBinding()
            oMainForm.ResumeLayout(True)
        End If
        UpdateCounts()
        UpdateControls()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub UpdateCounts()
        oMainForm.numSel.Text = 0
        oMainForm.numUTF8.Text = 0
        oMainForm.numUTF16.Text = 0
        oMainForm.numASCII.Text = 0
        oMainForm.numTotal.Text = Converter.ListInputFiles.Count
        'ChangeVisible(ListIn, True)
        ResetText(ListCntLabels)
        TypeCounts = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0}
        If Converter.ListInputFiles.Count > 0 Then
            For a As Integer = 0 To Converter.ListInputFiles.Count - 1
                Select Case Converter.ListInputFiles.Item(a).Format
                    Case FFormats.utf_16
                        oMainForm.numUTF16.Text += 1
                    Case FFormats.utf_8
                        oMainForm.numUTF8.Text += 1
                    Case Else
                        oMainForm.numASCII.Text += 1
                End Select
                TypeCounts(Converter.ListInputFiles.Item(a).Type) += 1
                If Converter.ListInputFiles.Item(a).Selected = True Then
                    oMainForm.numSel.Text += 1
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
        If oMainForm.listFiles.Items.Count = 0 Then
            oMainForm.lblDropHere.Visible = True
            oMainForm.lblDropHere.BringToFront()
        Else
            oMainForm.lblDropHere.Visible = False
        End If
        If oMainForm.pOut.Visible = False Or oMainForm.listFiles.Items.Count = 0 Or oMainForm.pOut.Tag = "" Then
            oMainForm.btnStart.Enabled = False
        Else
            oMainForm.btnStart.Enabled = True
        End If
    End Sub
    Public Sub unSelectAll()
        Dim cnt As Integer = oMainForm.listFiles.SelectedIndices.Count
        Dim val As Integer
        Do While oMainForm.numSel.Text > 0
            For Each item In oMainForm.listFiles.SelectedIndices
                val = item
                oMainForm.listFiles.Items(val).selected = False
                oMainForm.listFiles.SetSelected(val, False)

            Next
            'MainForm.listFiles.Refresh()
        Loop
        'For Each val In MainForm.listFiles.SelectedIndices
        ''val = MainForm.listFiles.SelectedIndices.Item(a)
        'MainForm.listFiles.SetSelected(val, False)
        'MainForm.listFiles.Items(val).selected = False
        'Next

    End Sub


    Public Sub filelistitem_indexchange(ByVal sender As Object, ByVal e As EventArgs)
        oMainForm.listFiles.SuspendLayout()
        oMainForm.btnSelNone.SuspendLayout()
        oMainForm.numTotal.Text = oMainForm.listFiles.Items.Count
        If oMainForm.listFiles.Items.Count = 0 Then
            oMainForm.lblDropHere.Visible = True
        Else
            oMainForm.lblDropHere.Visible = False
        End If
        For a As Integer = 0 To oMainForm.listFiles.Items.Count - 1
            oMainForm.listFiles.Items(a).selected = False
        Next
        oMainForm.numSel.Text = oMainForm.listFiles.SelectedItems.Count
        If oMainForm.listFiles.SelectedItems.Count > 0 Then
            For a As Integer = 0 To oMainForm.listFiles.SelectedItems.Count - 1
                oMainForm.listFiles.SelectedItems.Item(a).selected = True
            Next
            oMainForm.btnSelNone.Visible = True
        Else
            oMainForm.btnSelNone.Visible = False
        End If
        oMainForm.btnSelNone.ResumeLayout(True)
        oMainForm.listFiles.ResumeLayout(False)
        sender.invalidate()
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
                                Exit Do
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
        oMainForm.ToolTip1.SetToolTip(fctrl, sStr)
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
            SaveVariousSet("pOut", oMainForm.pOut.Tag.ToString)
            SaveVariousSet("pCPout", oMainForm.pCPout.Tag.ToString)
            SaveVariousSet("pCPin", oMainForm.pCPin.Tag.ToString)
            SaveVariousSet("pExt", Settings.pExt.Tag.ToString)
            SaveVariousSet("txtExt", oMainForm.txtExt.Text)
            SaveVariousSet("pOutExist", Settings.pOutExist.Tag.ToString)
            SaveVariousSet("pOutPath", oMainForm.pOutPath.Tag.ToString)
            SaveVariousSet("outPath", oMainForm.outPath.FullText)
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
    Public Function isMainThread() As Boolean
        If System.Threading.Thread.CurrentThread.GetHashCode() = MainThreadID Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Utility function for firing an event through the target.
    ' It uses C#'s variable length parameter list support
    ' to build the parameter list.
    ' This functions presumes that the caller holds the object lock.
    ' (This is because the event list is typically modified on the UI
    ' thread, but events are usually raised on the worker thread.)
    Public Sub FireAsync(ByVal dlg As [Delegate], ByVal ParamArray pList As Object())
        If dlg IsNot Nothing Then
            Try

                '                    Console.WriteLine(" " + dlg.ToString());
                'If CurrentWorkForm.Target.InvokeRequired Then
                If isMainThread() = False Then
                    'CurrentWorkForm.Target.BeginInvoke(dlg, pList)
                    CType(oMainForm, MainForm).Target.BeginInvoke(New HandleCall(AddressOf FireAsync), New Object() {dlg, pList})
                Else
                    dlg.DynamicInvoke(pList)
                End If

            Catch e As Exception
                ' The documentation recommends not catching
                ' SystemExceptions, so having notified the caller we
                ' rethrow if it was one of them.
                If TypeOf e Is SystemException Then
                    Throw
                End If

            End Try
        End If
    End Sub
    Delegate Sub HandleCall(ByVal dlg As [Delegate], ByVal plist As Object())

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
                oMainForm.SuspendLayout()
                oMainForm.Visible = False
                Dim aFiles() As String = Split(sFiles, "|")
                If aFiles.Length > 0 Then
                    Dim ItemLoader As New FontsLoader(aFiles)
                    ItemLoader.Show()
                    ItemLoader.BringToFront()
                End If

                oMainForm.ResumeLayout(False)
                oMainForm.PerformLayout()

                InfoMsg(aFiles.Length.ToString & " files added to list.", False, False)
            End If
        Catch ex As Exception

        End Try
        bUpdatingControls = False
        Try
            bUpdatingControls = True
            Select Case spOut
                Case "ASC"
                    Call oMainForm.ControlUpdate(oMainForm.outASCII, Nothing)
                Case "ANS"
                    Call oMainForm.ControlUpdate(oMainForm.outANSI, Nothing)
                Case "HTML"
                    Call oMainForm.ControlUpdate(oMainForm.outHTML, Nothing)
                Case "UTF"
                    Call oMainForm.ControlUpdate(oMainForm.outUnicode, Nothing)
                Case "BBS"
                    Call oMainForm.ControlUpdate(oMainForm.outBBS, Nothing)
                Case "BIN"
                    Call oMainForm.ControlUpdate(oMainForm.outBinary, Nothing)
                Case "IMG"
                    Call oMainForm.ControlUpdate(oMainForm.outImage, Nothing)
                Case "AVI"
                    Call oMainForm.ControlUpdate(oMainForm.outVideo, Nothing)
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
                Call oMainForm.ControlUpdate(Settings.rCompleteHTML, Nothing)
            Else
                Call oMainForm.ControlUpdate(Settings.rObjectOnly, Nothing)
            End If
            If spAnim = "STATIC" Then
                Call oMainForm.ControlUpdate(Settings.rStatic, Nothing)
            Else
                Call oMainForm.ControlUpdate(Settings.rAnim, Nothing)
            End If
            If spUTF = "UTF-16" Then
                Call oMainForm.ControlUpdate(Settings.rUTF16, Nothing)
            Else
                Call oMainForm.ControlUpdate(Settings.rUTF8, Nothing)
            End If
            If spSauce = "KEEP" Then
                Call oMainForm.ControlUpdate(Settings.rSauceKeep, Nothing)
            Else
                Call oMainForm.ControlUpdate(Settings.rSauceStrip, Nothing)
            End If
            If spOutPath = "INPUT" Then
                Call oMainForm.ControlUpdate(oMainForm.rOutPathInput, Nothing)
            Else
                Call oMainForm.ControlUpdate(oMainForm.rOutPathNew, Nothing)
            End If
            oMainForm.outPath.FullText = soutPath
            oMainForm.txtExt.Text = stxtExt
            Settings.txtFPS.Text = sFPS
            Settings.txtBPS.Text = sBPS
            Settings.txtLastFrame.Text = sLastFrame

            If spExt = "REPLACE" Then
                Call oMainForm.ControlUpdate(Settings.rReplaceExt, Nothing)
            Else
                Call oMainForm.ControlUpdate(Settings.rExtraExt, Nothing)
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
                Settings.pThumbs.Visible = True
            Else
                Settings.Thumb.Checked = False
                Settings.pThumbs.Visible = False
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
                    Call oMainForm.ControlUpdate(oMainForm.outASCII, Nothing)
                Case "ANS"
                    Call oMainForm.ControlUpdate(oMainForm.outANSI, Nothing)
                Case "HTML"
                    Call oMainForm.ControlUpdate(oMainForm.outHTML, Nothing)
                Case "UTF"
                    Call oMainForm.ControlUpdate(oMainForm.outUnicode, Nothing)
                Case "PCB"
                    Call oMainForm.ControlUpdate(oMainForm.outBBS, Nothing)
                Case "BIN"
                    Call oMainForm.ControlUpdate(oMainForm.outBinary, Nothing)
                Case "IMG"
                    Call oMainForm.ControlUpdate(oMainForm.outImage, Nothing)
                Case "AVI"
                    Call oMainForm.ControlUpdate(oMainForm.outVideo, Nothing)
                Case Else
            End Select
            oMainForm.inCP.Text = spCPin
            oMainForm.outCP.Text = spCPout
            bUpdatingControls = False
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()

        Catch ex As Exception
            MainFormLoaded = True
            bUpdatingControls = False

        End Try

        bUpdatingControls = False
    End Sub
    Public Function SelectFolder(Optional ByVal sDefault As String = "", Optional ByVal Desc As String = "Select the Folder to process.", Optional ByVal shownew As Boolean = True) As String
        Dim result As Integer

        If sDefault <> "" Then
            oMainForm.FolderBrowserDialog1.SelectedPath = sDefault
        End If

        oMainForm.FolderBrowserDialog1.Description = Desc

        oMainForm.FolderBrowserDialog1.ShowNewFolderButton = shownew
        result = oMainForm.FolderBrowserDialog1.ShowDialog()
        If result = 1 Then
            If IO.Directory.Exists(oMainForm.FolderBrowserDialog1.SelectedPath) = True Then
                SelectFolder = oMainForm.FolderBrowserDialog1.SelectedPath
            Else
                SelectFolder = sDefault
            End If
        Else
            SelectFolder = sDefault
        End If

    End Function

    Public Sub SelectFiles()
        Dim result As Integer = 0
        If oMainForm.btnAdd.Tag <> "" Then
            If IO.File.Exists(oMainForm.btnAdd.Tag) = False Then

            Else
                oMainForm.OpenFileDialog1.FileName = oMainForm.btnAdd.Tag
            End If
        End If
        Dim sFileN As String = ReadVariousSet("LastOpenPath", "")
        oMainForm.OpenFileDialog1.FileName = sFileN
        If oMainForm.OpenFileDialog1.FileName = "OpenFileDialog1" Then
            oMainForm.OpenFileDialog1.FileName = ""
        End If
        If oMainForm.OpenFileDialog1.FileName <> "" Then
            oMainForm.OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.GetParentPath(oMainForm.OpenFileDialog1.FileName)

        End If
        oMainForm.OpenFileDialog1.CheckFileExists = True
        result = oMainForm.OpenFileDialog1.ShowDialog()
        If result <> 2 And result <> 3 Then
            If oMainForm.OpenFileDialog1.FileName <> "" Then
                Dim aFiles() As String = oMainForm.OpenFileDialog1.FileNames
                oMainForm.listFiles.SuspendLayout()
                bAddingFiles = True
                Dim alphacomp As New AlphanumComparator.AlphanumComparator
                Array.Sort(aFiles, alphacomp)
                For a As Integer = 0 To UBound(aFiles)
                    If aFiles(a) <> "" Then
                        SaveVariousSet("LastOpenPath", aFiles(a))
                        AddFile(aFiles(a))
                    End If
                    If a / 10 = CInt(a \ 10) Then
                        RefreshListFiles()
                        System.Windows.Forms.Application.DoEvents()
                    End If
                Next
                bAddingFiles = False
                oMainForm.listFiles.ResumeLayout()
                RefreshListFiles()
                InfoMsg(aFiles.Length.ToString & " items added to list.", False, False)
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
            AddFormattedRichText(oMainForm.log, msg, nolinebreak, removeprev)
        Else
            AddFormattedRichText(oMainForm.log, " - " & msg, nolinebreak, removeprev)
        End If

    End Sub

    Public Sub SummSettings()
        If ANSI_ASCII_Converter.Settings.rCompleteHTML.Checked = True Then
            oMainForm.settHTMLObj.Text = "Full HTML"
        Else
            oMainForm.settHTMLObj.Text = "DIV Only"
        End If
        If ANSI_ASCII_Converter.Settings.rStatic.Checked = True Then
            oMainForm.settAnim.Text = " / Static"
        Else
            oMainForm.settAnim.Text = " / Anim"
        End If
        If ANSI_ASCII_Converter.Settings.NoCols.Checked = True Then
            oMainForm.settNoCols.Text = "No Colors"
        Else
            oMainForm.settNoCols.Text = "Colored"
        End If
        If ANSI_ASCII_Converter.Settings.SmallFnt.Checked = True Then
            oMainForm.settSMALLFNT.Text = " / 80x50 Lines Mode"
        Else
            oMainForm.settSMALLFNT.Text = " / 80x25 Lines Mode"
        End If
        If ANSI_ASCII_Converter.Settings.Thumb.Checked = True Then
            oMainForm.attCreTh.Text = "Thumbnails"
        Else
            oMainForm.attCreTh.Text = "Image"
        End If
        oMainForm.settHTMLFont.Text = "HTML Font: " & sHTMLFont
        If ANSI_ASCII_Converter.Settings.Sanitize.Checked = True Then
            oMainForm.settSanitize.Text = ", Sanitize: Yes"
        Else
            oMainForm.settSanitize.Text = ", Sanitize: No"
        End If
        If ANSI_ASCII_Converter.Settings.Thumb.Checked = True Then
            Select Case ANSI_ASCII_Converter.Settings.pThumbs.Tag.ToString
                Case "0"
                    oMainForm.settThumbs.Text = "Scale: " & ANSI_ASCII_Converter.Settings.ThumbScalePercent.Text.ToString & "%"
                Case "1"
                    oMainForm.settThumbs.Text = "Fixed Width w: " & ANSI_ASCII_Converter.Settings.ThumbWidth.Text.ToString
                Case "2"
                    oMainForm.settThumbs.Text = "Fixed Height h: " & ANSI_ASCII_Converter.Settings.ThumbHeight.Text.ToString
                Case "3"
                    oMainForm.settThumbs.Text = "Custom:  w: " & ANSI_ASCII_Converter.Settings.ThumbWidth.Text.ToString & ", h: " & ANSI_ASCII_Converter.Settings.ThumbHeight.Text.ToString
            End Select
        Else
            oMainForm.settThumbs.Text = "Original Size"
        End If
        If ANSI_ASCII_Converter.Settings.rUTF8.Checked = True Then
            oMainForm.settUTF.Text = "UTF-8"
        Else
            oMainForm.settUTF.Text = "UTF-16"
        End If
        If ANSI_ASCII_Converter.Settings.bRemoveCompleted.Checked = True Then
            oMainForm.settGen.Text = "List: Auto-Remove Completed"
        Else
            oMainForm.settGen.Text = "List: Keep Completed"
        End If
        oMainForm.settVidFmt.Text = "Video: " & Settings.pVidFmts.Tag.ToString
        Select Case Settings.pVidFmts.Tag.ToString
            Case "AVI"
                oMainForm.settVidCodec.Text = "(" & Settings.pAVICodec.Tag.ToString & ")"
            Case "MPG"
                oMainForm.settVidCodec.Text = "(" & Replace(Settings.pMPGCodec.Tag.ToString, "video", "", 1, -1, CompareMethod.Text) & ")"
            Case Else
                oMainForm.settVidCodec.Text = ""
        End Select
        oMainForm.settVidCodec.BringToFront()
        oMainForm.settVideo.Text = "FPS: " & FPS.ToString & " / BPS: " & BPS.ToString
        oMainForm.settLFExt.Text = Settings.txtLastFrame.Text.ToString & " sec"
        If ANSI_ASCII_Converter.Settings.rSauceStrip.Checked = True Then
            oMainForm.settSauce.Text = "Sauce: Strip"
        Else
            oMainForm.settSauce.Text = "Sauce: Keep"
        End If
        Select Case ANSI_ASCII_Converter.Settings.pBBS.Tag.ToString
            Case "PCB"
                oMainForm.settBBS.Text = "BBS: PCBoard"
            Case "AVT"
                oMainForm.settBBS.Text = "BBS: Avatar"
            Case "WC2"
                oMainForm.settBBS.Text = "BBS: Wildcat 2"
            Case "WC3"
                oMainForm.settBBS.Text = "BBS: Wildcat 3"
        End Select

        Select Case ANSI_ASCII_Converter.Settings.pOutExist.Tag.ToString
            Case "0"
                oMainForm.settExist.Text = "Exist: Over"
            Case "1"
                oMainForm.settExist.Text = "Exist: Skip"
            Case "2"
                oMainForm.settExist.Text = "Exist: Auto-Ren"
            Case "3"
                oMainForm.settExist.Text = "Exist: Ask"
        End Select
        If ANSI_ASCII_Converter.Settings.rExtraExt.Checked = True Then
            oMainForm.settExt.Text = "Ext: Append"
        Else
            oMainForm.settExt.Text = "Ext: Replace"
        End If
        oMainForm.settImgOut.Text = ", Image Format: " & Settings.pIMGOut.Tag

        oMainForm.settSanitize.Tag = Color.Black
        oMainForm.settGen.Tag = Color.Black
        oMainForm.settExist.Tag = Color.Black
        oMainForm.settExt.Tag = Color.Black
        If oMainForm.pOut.Tag.ToString = "IMG" Or oMainForm.pOut.Tag.ToString = "AVI" Then
            oMainForm.settSMALLFNT.ForeColor = Color.Black
            oMainForm.settNoCols.ForeColor = Color.Black
            oMainForm.settSMALLFNT.Tag = Color.Black
            oMainForm.settNoCols.Tag = Color.Black
            If oMainForm.pOut.Tag.ToString = "IMG" Then
                oMainForm.attCreTh.ForeColor = Color.Black
                oMainForm.attCreTh.Tag = Color.Black
                oMainForm.settThumbs.ForeColor = Color.Black
                oMainForm.settThumbs.Tag = Color.Black
                oMainForm.settImgOut.ForeColor = Color.Black
                oMainForm.settImgOut.Tag = Color.Black
            Else
                oMainForm.attCreTh.ForeColor = Color.Gray
                oMainForm.attCreTh.Tag = Color.Gray
                oMainForm.settThumbs.ForeColor = Color.Gray
                oMainForm.settThumbs.Tag = Color.Gray
                oMainForm.settImgOut.ForeColor = Color.Gray
                oMainForm.settImgOut.Tag = Color.Gray
            End If
            If oMainForm.pOut.Tag.ToString = "AVI" Then
                oMainForm.settVideo.ForeColor = Color.Black
                oMainForm.settVideo.Tag = Color.Black
                oMainForm.settVidFmt.ForeColor = Color.Black
                oMainForm.settVidFmt.Tag = Color.Black
                oMainForm.settLFExt.ForeColor = Color.Black
                oMainForm.settLFExt.Tag = Color.Black
                If Settings.pVidFmts.Tag.ToString = "AVI" Or Settings.pVidFmts.Tag.ToString = "MPG" Then
                    oMainForm.settVidCodec.ForeColor = Color.Black
                    oMainForm.settVidCodec.Tag = Color.Black
                Else
                    oMainForm.settVidCodec.ForeColor = Color.Gray
                    oMainForm.settVidCodec.Tag = Color.Gray
                End If
            Else
                oMainForm.settVideo.ForeColor = Color.Gray
                oMainForm.settVideo.Tag = Color.Gray
                oMainForm.settVidFmt.ForeColor = Color.Gray
                oMainForm.settVidFmt.Tag = Color.Gray
                oMainForm.settVidCodec.ForeColor = Color.Gray
                oMainForm.settVidCodec.Tag = Color.Gray
                oMainForm.settLFExt.ForeColor = Color.Gray
                oMainForm.settLFExt.Tag = Color.Gray
            End If
        Else
            oMainForm.settNoCols.ForeColor = Color.Gray
            oMainForm.settNoCols.Tag = Color.Gray
            oMainForm.settSMALLFNT.ForeColor = Color.Gray
            oMainForm.settSMALLFNT.Tag = Color.Gray
            oMainForm.attCreTh.ForeColor = Color.Gray
            oMainForm.attCreTh.Tag = Color.Gray
            oMainForm.settThumbs.ForeColor = Color.Gray
            oMainForm.settThumbs.Tag = Color.Gray
            oMainForm.settImgOut.ForeColor = Color.Gray
            oMainForm.settImgOut.Tag = Color.Gray
            oMainForm.settVideo.ForeColor = Color.Gray
            oMainForm.settVideo.Tag = Color.Gray
            oMainForm.settVidFmt.ForeColor = Color.Gray
            oMainForm.settVidFmt.Tag = Color.Gray
            oMainForm.settVidCodec.ForeColor = Color.Gray
            oMainForm.settVidCodec.Tag = Color.Gray
            oMainForm.settLFExt.ForeColor = Color.Gray
            oMainForm.settLFExt.Tag = Color.Gray
        End If

        If oMainForm.pOut.Tag.ToString = "HTML" Then
            oMainForm.settHTMLFont.ForeColor = Color.Black
            oMainForm.settHTMLFont.Tag = Color.Black
            oMainForm.settHTMLObj.ForeColor = Color.Black
            oMainForm.settHTMLObj.Tag = Color.Black
            oMainForm.settAnim.ForeColor = Color.Black
            oMainForm.settAnim.Tag = Color.Black
        Else
            oMainForm.settHTMLFont.ForeColor = Color.Gray
            oMainForm.settHTMLFont.Tag = Color.Gray
            oMainForm.settHTMLObj.ForeColor = Color.Gray
            oMainForm.settHTMLObj.Tag = Color.Gray
            oMainForm.settAnim.ForeColor = Color.Gray
            oMainForm.settAnim.Tag = Color.Gray
        End If
        If oMainForm.pOut.Tag.ToString = "UTF" Then
            oMainForm.settUTF.ForeColor = Color.Black
            oMainForm.settUTF.Tag = Color.Black
        Else
            oMainForm.settUTF.ForeColor = Color.Gray
            oMainForm.settUTF.Tag = Color.Gray
        End If
        If oMainForm.pOut.Tag.ToString = "BBS" Then
            oMainForm.settBBS.ForeColor = Color.Black
            oMainForm.settBBS.Tag = Color.Black
        Else
            oMainForm.settBBS.ForeColor = Color.Gray
            oMainForm.settBBS.Tag = Color.Gray
        End If
        If oMainForm.pOut.Tag.ToString <> "IMG" And Settings.rAnim.Checked = False Then
            oMainForm.settSauce.ForeColor = Color.Black
            oMainForm.settSauce.Tag = Color.Black
        Else
            oMainForm.settSauce.ForeColor = Color.Gray
            oMainForm.settSauce.Tag = Color.Gray
        End If



    End Sub

End Module
