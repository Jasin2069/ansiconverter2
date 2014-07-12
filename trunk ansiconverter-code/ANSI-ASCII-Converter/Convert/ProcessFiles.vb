Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.RegexOptions


Public Module ProcessFiles
    Public Sub evHandlerProcessFinished(ByVal sender As Object, ByVal e As EventArgs)
        oMainForm.btnStart.BeginColor = System.Drawing.Color.Green
        oMainForm.btnStart.EndColor = System.Drawing.Color.Lime
        oMainForm.btnStart.Text = "Convert"
        oMainForm.btnStart.Enabled = True
        oMainForm.ToolTip1.SetToolTip(oMainForm.btnStart, "start converting all files" & vbCrLf & "in the input file list")
    End Sub
    Public Sub evHandlerProcessedFile(ByVal idx As Integer)
        oMainForm.listFiles.SuspendLayout()
        'MainForm.listFiles.DataSource = Nothing
        'MainForm.listFiles.DataSource = Converter.ListInputFiles
        UpdateCounts()
        UpdateControls()
        oMainForm.listFiles.ResumeLayout(False)
        oMainForm.listFiles.PerformLayout()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub evHandlerListItemRemoved(ByVal sender As Object, ByVal item As Converter.FileListItem)
        oMainForm.FileListItemBindingSource.SuspendBinding()
        oMainForm.FileListItemBindingSource.Remove(item)
        oMainForm.FileListItemBindingSource.ResumeBinding()
        oMainForm.listFiles.PerformLayout()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub evHandlerInfoMsg(ByVal Msg As String, ByVal nolinebreak As Boolean, ByVal removelast As Boolean)
        InfoMsg(Msg, nolinebreak, removelast)
    End Sub
    Public Sub evHandlerErrMsg(ByVal Msg As String)
        ErrMsg(Msg)
    End Sub
    Public Sub evHandlerAdjustnumUTF16(ByVal value As Integer)
        oMainForm.numUTF16.Text += value
        If bBatchAdd = False Then
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub
    Public Sub evHandlerAdjustnumUTF8(ByVal value As Integer)
        oMainForm.numUTF8.Text += value
        If bBatchAdd = False Then
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub
    Public Sub evHandlerAdjustnumSel(ByVal value As Integer)
        oMainForm.numSel.Text += value
        If bBatchAdd = False Then
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub
    Public Sub evHandlerAdjustnumASCII(ByVal value As Integer)
        oMainForm.numASCII.Text += value
        If bBatchAdd = False Then
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub
    Public Sub evHandlerAdjustnumTotal(ByVal value As Integer)
        oMainForm.numTotal.Text += value
        If bBatchAdd = False Then
            UpdateControls()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub

    Public Sub ConvertAllFiles()

        Converter.bDebug = bDebug
        Converter.txtExt = oMainForm.txtExt.Text
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
        If oMainForm.outHTML.Checked = True And ANSI_ASCII_Converter.Settings.Sanitize.Checked = True Then
            Converter.pSanitize = True
        End If
        Converter.BPS = BPS
        Converter.FPS = FPS
        Converter.pBBS = ANSI_ASCII_Converter.Settings.pBBS.Tag.ToString
        Converter.LastFrame = LastFrame
        Converter.rOutPathInput = oMainForm.rOutPathInput.Checked
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
        Converter.outPath = oMainForm.outPath.FullText
        Converter.bForceOverwrite = bForceOverwrite
        Converter.sOutPutFormat = oMainForm.pOut.Tag.ToString
        Converter.pOut = oMainForm.pOut.Tag.ToString
        'sInputFormat = MainForm.pIn.Tag.ToString

        Converter.pHTMLComplete = True
        If oMainForm.outHTML.Checked = True And ANSI_ASCII_Converter.Settings.rObjectOnly.Checked = True Then
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
        If oMainForm.pCPin.Visible = True Then
            Converter.pCP = oMainForm.pCPin.Tag.ToString
        Else
            If oMainForm.pCPout.Visible = True Then
                Converter.pCP = oMainForm.pCPout.Tag.ToString
            End If
        End If
        Converter.sCodePg = Converter.pCP
        Converter.pHTMLEncode = False
        If oMainForm.outHTML.Checked = True Or ListCntLabels.Item(2).Text > 0 Then
            Converter.pHTMLEncode = True
        End If



        oConv.ConvertAllFiles()






    End Sub


End Module
