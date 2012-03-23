Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.RegexOptions


Public Module ProcessFiles
    Public Sub evHandlerProcessedFile(ByVal idx As Integer)
        MainForm.listFiles.DataSource = Nothing
        MainForm.listFiles.DataSource = Converter.ListInputFiles
        UpdateCounts()
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub evHandlerInfoMsg(ByVal Msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
        InfoMsg(Msg, nolinebreak, removelast)
    End Sub
    Public Sub evHandlerErrMsg(ByVal Msg As String)
        ErrMsg(Msg)
    End Sub
    Public Sub evHandlerAdjustnumUTF16(ByVal value As Integer)
        MainForm.numUTF16.Text += value
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub evHandlerAdjustnumUTF8(ByVal value As Integer)
        MainForm.numUTF8.Text += value
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub evHandlerAdjustnumSel(ByVal value As Integer)
        MainForm.numSel.Text += value
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub evHandlerAdjustnumASCII(ByVal value As Integer)
        MainForm.numASCII.Text += value
        UpdateControls()
        My.Application.DoEvents()
    End Sub
    Public Sub evHandlerAdjustnumTotal(ByVal value As Integer)
        MainForm.numTotal.Text += value
        UpdateControls()
        My.Application.DoEvents()
    End Sub

    Public Sub ConvertAllFiles()

        Converter.bDebug = bDebug
        Converter.txtExt = ANSI_ASCII_Converter.MainForm.txtExt.Text
        Converter.rReplaceExt = ANSI_ASCII_Converter.Settings.rReplaceExt.Checked
        Converter.pNoColors = ANSI_ASCII_Converter.Settings.NoCols.Checked
        Converter.pSmallFont = ANSI_ASCII_Converter.Settings.SmallFnt.Checked
        Converter.pOutExist = CType(ANSI_ASCII_Converter.Settings.pOutExist.Tag, Integer)
        If Settings.pSauce.Tag = "Strip" Then
            Converter.bOutputSauce = False
        Else
            Converter.bOutputSauce = True
        End If
        Converter.pSauce = Settings.pSauce.Tag
        If Settings.pAnim.Tag = "Static" Then
            Converter.bAnimation = False
        Else
            Converter.bAnimation = True
        End If
        Converter.pAnim = Settings.pAnim.Tag
        'Dim ffmpegpath As String = IO.Path.Combine(Application.StartupPath, "ffmpeg.exe")
        Converter.bRemoveCompleted = ANSI_ASCII_Converter.Settings.bRemoveCompleted.Checked
        Converter.bCreateThumbs = ANSI_ASCII_Converter.Settings.Thumb.Checked
        If Converter.bCreateThumbs = True Then
            Converter.iThumbsResOpt = CInt(ANSI_ASCII_Converter.Settings.pThumbs.Tag)
            Converter.iThumbsScale = ANSI_ASCII_Converter.Settings.ThumbScalePercent.Text
            Converter.iThumbsWidth = ANSI_ASCII_Converter.Settings.ThumbWidth.Text
            Converter.iThumbsHeight = ANSI_ASCII_Converter.Settings.ThumbHeight.Text

        End If
        Converter.pSanitize = False
        If MainForm.outHTML.Checked = True And ANSI_ASCII_Converter.Settings.Sanitize.Checked = True Then
            Converter.pSanitize = True
        End If
        Converter.BPS = BPS
        Converter.FPS = FPS
        Converter.pBBS = ANSI_ASCII_Converter.Settings.pBBS.Tag.ToString
        Converter.LastFrame = LastFrame
        Converter.rOutPathInput = MainForm.rOutPathInput.Checked
        Converter.VidFmt = ANSI_ASCII_Converter.Settings.pVidFmts.Tag.ToString
        Select Case ANSI_ASCII_Converter.Settings.pVidFmts.Tag.ToString
            Case "AVI"
                Converter.VidCodec = ANSI_ASCII_Converter.Settings.pAVICodec.Tag.ToString
            Case "MPG"
                Converter.VidCodec = ANSI_ASCII_Converter.Settings.pMPGCodec.Tag.ToString
            Case Else
                Converter.VidCodec = ""
        End Select
        Converter.SelectedWebFont = SelectedWebFont
        Converter.outPath = MainForm.outPath.FullText
        Converter.bForceOverwrite = bForceOverwrite
        Converter.sOutPutFormat = MainForm.pOut.Tag.ToString
        Converter.pOut = MainForm.pOut.Tag.ToString
        'sInputFormat = MainForm.pIn.Tag.ToString

        Converter.pHTMLComplete = True
        If MainForm.outHTML.Checked = True And ANSI_ASCII_Converter.Settings.rObjectOnly.Checked = True Then
            Converter.pHTMLComplete = False
        End If
        If ANSI_ASCII_Converter.Settings.rUTF16.Checked = True Then
            Converter.selUTF = "UTF16"
        End If
        If ANSI_ASCII_Converter.Settings.rUTF8.Checked = True Then
            Converter.selUTF = "UTF8"
        End If



        Converter.bSanitize = Converter.pSanitize
        Converter.sHTMLFont = sHTMLFont
        Converter.pCP = "CP437"
        If MainForm.pCPin.Visible = True Then
            Converter.pCP = MainForm.pCPin.Tag.ToString
        Else
            If MainForm.pCPout.Visible = True Then
                Converter.pCP = MainForm.pCPout.Tag.ToString
            End If
        End If
        Converter.sCodePg = Converter.pCP
        Converter.pHTMLEncode = False
        If MainForm.outHTML.Checked = True Or ListCntLabels.Item(2).Text > 0 Then
            Converter.pHTMLEncode = True
        End If



        oConv.ConvertAllFiles()


       



    End Sub


End Module
