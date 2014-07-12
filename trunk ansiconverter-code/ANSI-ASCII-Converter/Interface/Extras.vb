
Public Module Extras
    '-------------------------------------------------------
    'Get API Call
    '-------------------------------------------------------
    Public Const uriUniDataRoot = "http://www.unicode.org/Public/UNIDATA/"
    Public Const uriUniDataBlocks = "Blocks.txt"
    Public Const uriNamesList = "NamesList.txt"
    Public sUserID As String = ""
    Public sPassword As String = ""
    Public sBlockData As String = ""
    Public aBlockData() As String
    Public UniNamesList As New List(Of NL)

    Public aCtrlChars As String() = New String() {"NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL", "BS", "HT", "LF", "VT", "FF", "CR", "SO", "SI", "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US", "SP"}

    '------------------------------------

    Public Sub ProcBlocks(ByVal selBlock)
        Dim iRes



        iRes = BuildUniCodeBlocks(sBlockData)
        If selBlock = "" Then
            selBlock = aUniBlocks.item(0).sKey
            oUnicodeBlocks.seBlockName.Text = aUniBlocks.item(0).sDisplay
        End If
        pBlock.Visible = False
        '226, 80
        oUnicodeBlocks.FadingLabel1.Top = pBlock.Top + 20
        oUnicodeBlocks.FadingLabel1.Left = pBlock.Left + 100



        'pUniBlockTemplate
        'UnicodeBlocks.Controls.Add(UnicodeBlocks.FadingLabel1)
        oUnicodeBlocks.FadingLabel1.Visible = True
        'UnicodeBlocks.FadingLabel1.ffUnderObject = pBlock
        oUnicodeBlocks.FadingLabel1.AutoFade = True
        oUnicodeBlocks.FadingLabel1.Fade()
        For Each ctrl As Control In pBlock.Controls
            ctrl.Dispose()
        Next
        pBlock.Dispose()
        pBlock = New Windows.Forms.Panel
        pBlock.Name = "pBlocker"
        oUnicodeBlocks.Controls.Add(pBlock)
        pBlock.Visible = False
        '  ScrollBar = New ScrollBar.DefaultBackColor = Color.DarkBlue

        CopyControlSettings(oUnicodeBlocks.pUniBlockTemplate, pBlock)
        pBlock.Visible = False
        pBlock.Location = oUnicodeBlocks.pUniBlockTemplate.Location
        pBlock.AutoScroll = True
        AddHandler oUnicodeBlocks.MouseHover, AddressOf cpblock_panelzoomreset
        If iRes > 0 Then
            oUnicodeBlocks.NuMBlocks.Text = iRes
            BuildCharList(selBlock, pBlock)
        End If
        pBlock.Visible = True
        System.Windows.Forms.Application.DoEvents()


    End Sub
    Public Function BuildUniCodeNamesList(ByVal UNList As List(Of NL)) As List(Of NL)
        Dim sBaseURL As String, sCallResults As String
        Dim aTmp1() As String, aTmp2() As String
        Dim iCurrChar As Integer = -1
        Dim bIgnore As Boolean = True, bNewChar As Boolean = False
        Dim sLB As String = ""
        Dim newNL As NL = Nothing, sStr As String = ""
        If UNList.Count = 0 Then
            sBaseURL = uriUniDataRoot & uriNamesList
            'sCallResults = APICall(sBaseURL, "get", "", "", "", "", False)
            Dim webClient As System.Net.WebClient = New System.Net.WebClient()
            sCallResults = webClient.DownloadString(sBaseURL)
            If InStr(1, sCallResults, vbCrLf, CompareMethod.Text) > 0 Then
                sLB = vbCrLf
            ElseIf InStr(1, sCallResults, vbLf, CompareMethod.Text) > 0 Then
                sLB = vbLf
            ElseIf InStr(1, sCallResults, vbCr, CompareMethod.Text) > 0 Then
                sLB = vbCr
            End If
            If sLB.Length > 0 Then
                aTmp1 = Split(sCallResults, sLB)
                For a As Integer = 0 To aTmp1.Length - 1
                    If InStr(1, aTmp1(a), vbTab, CompareMethod.Text) > 0 Then
                        aTmp2 = Split(aTmp1(a), vbTab)
                        If aTmp2(0) <> "" Then
                            bNewChar = True
                            If Converter.ConverterSupport.isHex(aTmp2(0)) Then
                                If iCurrChar <> -1 Then
                                    UNList.Add(newNL)
                                End If
                                bIgnore = False
                                iCurrChar = Converter.ConverterSupport.HexToDec(aTmp2(0))
                                newNL = New NL(iCurrChar, aTmp2(0), Oct(iCurrChar), Converter.ConverterSupport.Int2Bin(iCurrChar), aTmp2(1))
                            Else
                                bIgnore = True
                            End If
                        Else
                            bNewChar = False
                        End If
                        If bNewChar = False And bIgnore = False Then
                            If Trim(aTmp2(1)).Length > 2 Then
                                sStr = Trim(aTmp2(1))
                                Select Case Strings.Left(sStr, 2)
                                    Case "= "
                                        sStr = Strings.Right(sStr, sStr.Length - 2)
                                        newNL.Aliases.Add(sStr)
                                    Case "* "
                                        sStr = Strings.Right(sStr, sStr.Length - 2)
                                        newNL.Notes.Add(sStr)
                                    Case "x "
                                        sStr = Strings.Right(sStr, sStr.Length - 2)
                                        newNL.Similar.Add(sStr)
                                End Select
                            End If
                        End If
                    End If
                Next
                If Not IsNothing(newNL) Then
                    UNList.Add(newNL)
                End If
            End If
        End If
        Return UNList
    End Function
    '---------------------------------------
    Public Function BuildUniCodeBlocks(ByRef sTxt)
        Dim sBaseURL, sCallResults
        Dim iBlockCount, sName, sRange, aRange, sRangeFrom, sRangeTo, sRec
        Dim aResults, iDiff


        If aUniBlocks.count = 0 Then

            sBaseURL = uriUniDataRoot & uriUniDataBlocks
            'sCallResults = APICall(sBaseURL, "get", "", "", "", "", False)
            Dim webClient As System.Net.WebClient = New System.Net.WebClient()
            sCallResults = webClient.DownloadString(sBaseURL)
            oUnicodeBlocks.listUniBlocks.DataSource = Nothing
            iBlockCount = 0
            If sCallResults <> "" Then
                sCallResults = Replace(sCallResults, vbCrLf, vbLf, 1, -1, CompareMethod.Text)
                sCallResults = Replace(sCallResults, vbCr, vbLf, 1, -1, CompareMethod.Text)
                aResults = Split(sCallResults, vbLf)
                For i As Integer = 0 To UBound(aResults)
                    sRec = Trim(aResults(i))
                    If sRec <> "" Then
                        Dim sLeft As String = Microsoft.VisualBasic.Left(sRec, 1)
                        If sLeft <> CStr("#") Then
                            If InStr(1, sRec, ";", CompareMethod.Text) > 0 And InStr(1, sRec, "..", CompareMethod.Text) > 0 Then
                                sName = ""
                                sRange = Microsoft.VisualBasic.Left(sRec, InStr(1, sRec, ";", CompareMethod.Text) - 1)
                                sName = Trim(Microsoft.VisualBasic.Right(sRec, sRec.length - sRange.length - 1))
                                aRange = Split(sRange, "..")
                                sRangeFrom = ""
                                sRangeTo = ""
                                If UBound(aRange) = 1 Then
                                    sRangeFrom = aRange(0)
                                    sRangeTo = aRange(1)
                                End If
                                If sName <> "" And sRangeFrom <> "" And sRangeFrom.length <= 4 And sRangeTo <> "" And Converter.ConverterSupport.isHex(sRangeFrom) And Converter.ConverterSupport.isHex(sRangeTo) Then
                                    iDiff = 0
                                    iDiff = Converter.ConverterSupport.HexToDec(sRangeTo) - Converter.ConverterSupport.HexToDec(sRangeFrom)
                                    If iDiff < 5000 Then
                                        iBlockCount += 1
                                        sBlockData = sBlockData & sRangeFrom & "|" & sRangeTo & "|" & sName & "~"
                                        aUniBlocks.Add(New UniBlock(sName, sRangeFrom, sRangeTo))
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            oUnicodeBlocks.listUniBlocks.DataSource = aUniBlocks
            oUnicodeBlocks.listUniBlocks.DisplayMember = "sDisplay"
            oUnicodeBlocks.listUniBlocks.ValueMember = "sKey"
            oUnicodeBlocks.listUniBlocks.Text = ""
            oUnicodeBlocks.listUniBlocks.SetSelected(0, True)
        Else
            'aBlockData = Split(sBlockData, "~")
            iBlockCount = aUniBlocks.Count
        End If


        Return iBlockCount
    End Function

  

    '--------------------------------------------------------------
    Public Sub BuildCharList(ByVal sKeyVal As String, ByRef p As Windows.Forms.Panel)
        Dim iCol, iLine, iTop, iLeft
        Dim aKeyVal, iFrom, iTo, iNumC, iNumBR
        Dim iCurr

        aKeyVal = Split(sKeyVal, "-")
        iFrom = Converter.ConverterSupport.HexToDec(aKeyVal(0))
        iTo = Converter.ConverterSupport.HexToDec(aKeyVal(1))
        iNumC = iTo - iFrom + 1
        'MsgBox "From: " & iFrom & ", To:" & iTo, vbOk, "test"
        'UnicodeBlocks.seBlockName.Text &= " (" & iNumC & " characters)"
        iLine = 0
        iCol = 0
        iCurr = iFrom


        iNumBR = ((iNumC Mod 7) + 1) * 4

        For I = 1 To iNumC
            iTop = (iLine * 40)
            iLeft = (iCol * 80)

            Dim p2 = New Windows.Forms.Panel
            Dim lC As New Windows.Forms.Label
            Dim lCi As New Windows.Forms.Label
            Dim lCh As New Windows.Forms.Label
            p2.Name = "pxr" & iCurr
            lC.Name = "lcr" & iCurr
            lCi.Name = "lci" & iCurr
            lCh.Name = "lch" & iCurr
            p.Controls.Add(p2)
            CopyControlSettings(oUnicodeBlocks.pCharTemplate, p2)
            p2.Top = iTop
            p2.Left = iLeft

            p2.Controls.Add(lC)
            p2.Controls.Add(lCi)
            p2.Controls.Add(lCh)

            CopyControlSettings(oUnicodeBlocks.lblCharTemplate, lC)
            lC.Visible = True
            CopyControlSettings(oUnicodeBlocks.lblCharIntTemplate, lCi)
            lCi.Visible = True
            CopyControlSettings(oUnicodeBlocks.lblCharHextemplate, lCh)
            lCh.Visible = True
            p2.BringToFront()
            'AddHandler p2.MouseEnter, AddressOf cpblock_panelzoomin
            '   AddHandler p2.MouseLeave, AddressOf cpblock_panelzoomout

            AddHandler lC.MouseEnter, AddressOf cpblock_panelzoominproxy
            AddHandler lCi.MouseEnter, AddressOf cpblock_panelzoominproxy
            AddHandler lCh.MouseEnter, AddressOf cpblock_panelzoominproxy
            AddHandler lC.MouseHover, AddressOf cpblock_panelzoominproxy
            AddHandler lCi.MouseHover, AddressOf cpblock_panelzoominproxy
            AddHandler lCh.MouseHover, AddressOf cpblock_panelzoominproxy
            AddHandler lC.MouseMove, AddressOf cpblock_panelzoominproxy
            AddHandler lCi.MouseMove, AddressOf cpblock_panelzoominproxy
            AddHandler lCh.MouseMove, AddressOf cpblock_panelzoominproxy
            ' AddHandler lC.MouseLeave, AddressOf cpblock_panelzoomoutproxy
            ' AddHandler lCi.MouseLeave, AddressOf cpblock_panelzoomoutproxy
            ' AddHandler lCh.MouseLeave, AddressOf cpblock_panelzoomoutproxy

            '      Console.WriteLine("name: " & p2.Name & ", top: " & iTop & ", Left: " & iLeft & ", width: " & p2.Width & ", height: " & p2.Height)

            If iCurr >= 0 And iCurr <= 32 Then
                lC.Text = Converter.Internal.aCtrlChars(iCurr)
                lC.Font = New Font("Lucida Console", 9, FontStyle.Bold, GraphicsUnit.Point)
            Else
                If iCurr = 38 Then
                    lC.Text = "&&"
                Else
                    lC.Text = ChrW(iCurr)
                End If

            End If
            lC.Tag = iCurr
            lCi.Tag = iCurr
            lCh.Tag = iCurr
            p2.Tag = iCurr
            AddHandler p2.Click, AddressOf CharClicker
            AddHandler lC.Click, AddressOf CharClicker
            AddHandler lCi.Click, AddressOf CharClicker
            AddHandler lCh.Click, AddressOf CharClicker

            lCi.Text = iCurr
            lCh.Text = Converter.ConverterSupport.UniHex(iCurr)


            iCol = iCol + 1
            If iCol = 10 Then
                iLine = iLine + 1
                iCol = 0

            End If
            iCurr = iCurr + 1

        Next

        oUnicodeBlocks.FontDialog1.Font = selectedFont
        ApplyFont(oUnicodeBlocks.FontDialog1, Nothing)
        System.Windows.Forms.Application.DoEvents()


    End Sub
    Public Sub CharClicker(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If IsNumeric(sender.tag) Then
                Dim idx As Integer = UniNamesList.FindIndex(Function(x) CInt(sender.tag).Equals(CInt(x.Code)))
                If idx >= 0 Then
                    Dim ChrDet As New CharDetail(UniNamesList.Item(idx))
                    ChrDet.Activate()
                    ChrDet.ShowDialog()
                    ChrDet.Dispose()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CopyControlSettings(ByRef cFrom As Windows.Forms.Control, ByRef cTo As Windows.Forms.Control)
        Dim panelf As Windows.Forms.Panel
        Dim labelf As Windows.Forms.Label
        Dim panelt As Windows.Forms.Panel
        Dim labelt As Windows.Forms.Label
        Dim xpanelf As xPanel
        Dim xpanelt As xPanel
        'CType(sender, ListBox)
        cTo.BackColor = cFrom.BackColor
        cTo.ForeColor = cFrom.ForeColor
        cTo.Height = cFrom.Height
        cTo.Width = cFrom.Width

        Select Case cFrom.GetType().ToString
            Case "ANSI_ASCII_Converter.xPanel"
                xpanelf = CType(cFrom, xPanel)
                xpanelt = CType(cTo, xPanel)
                xpanelt.BorderStyle = xpanelf.BorderStyle
                xpanelt.AutoSize = xpanelf.AutoSize
            Case "System.Windows.Forms.Panel"
                panelf = CType(cFrom, Windows.Forms.Panel)
                panelt = CType(cTo, Windows.Forms.Panel)
                panelt.BorderStyle = panelf.BorderStyle
                panelt.AutoSize = panelf.AutoSize
            Case "System.Windows.Forms.Label"
                labelf = CType(cFrom, Windows.Forms.Label)
                labelt = CType(cTo, Windows.Forms.Label)
                labelt.BorderStyle = labelf.BorderStyle
                labelt.AutoSize = labelf.AutoSize
                labelt.TextAlign = labelf.TextAlign
                labelt.Location = labelf.Location
        End Select
        cTo.BackgroundImage = cFrom.BackgroundImage
        cTo.BackgroundImageLayout = cFrom.BackgroundImageLayout
        cTo.Font = cFrom.Font
        cTo.Cursor = cFrom.Cursor
        cTo.Tag = cFrom.Tag
    End Sub
    Public Sub cpblock_panelzoominproxy(ByVal sender As Object, ByVal e As EventArgs)
        cpblock_panelzoomin(sender.parent, Nothing)
        Dim iobjid As Integer = CInt(Microsoft.VisualBasic.Right(sender.name, Len(sender.name) - 3))
        If currCPBlockZoomed.ToString <> iobjid.ToString Then
            If currCPBlockZoomed >= 0 Then
                Try
                    For Each ctl In currCPBlockzoompanel.Controls
                        ctl.dispose()
                    Next
                    currCPBlockzoompanel.Dispose()
                Catch ex As Exception

                End Try
            End If
            currCPBlockZoomed = iobjid
            If currCPBlockShiftDown = True Then
                cpblock_panelzoomin(sender.parent, Nothing)
            End If
        End If
        If currCPBlockShiftDown = True Then
            If currCPBlockZoomed >= 0 Then
                currCPBlockzoompanel.BringToFront()
            End If
        End If
    End Sub
    'cpblock_panelzoomreset
    Public Sub cpblock_panelzoomreset(ByVal sender As Object, ByVal e As EventArgs)
        If currCPBlockZoomed >= 0 Then
            Try
                For Each ctl In currCPBlockzoompanel.Controls
                    ctl.dispose()
                Next
                currCPBlockzoompanel.Dispose()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Public Sub cpblock_panelzoomin(ByVal sender As Object, ByVal e As EventArgs)
        Dim Orgwidth As Integer = sender.width, OrgHeight As Integer = sender.height
        Dim newwidth As Integer = Orgwidth * 2
        Dim newheight As Integer = OrgHeight * 2
        Dim olab As Windows.Forms.Label
        Dim iobjid As Integer = CInt(Microsoft.VisualBasic.Right(sender.name, Len(sender.name) - 3))
        Try
            currCPBlockzoompanel.Visible = False
            currCPBlockzoompanel.Dispose()
        Catch ex As Exception

        End Try
        If currCPBlockShiftDown = True Then
            currCPBlockZoomed = iobjid
            currCPBlockzoompanel = New Windows.Forms.Panel
            currCPBlockzoompanel.Name = "copyXPanel"
            currCPBlockzoompanel.Visible = False
            oUnicodeBlocks.Controls.Add(currCPBlockzoompanel)
            currCPBlockzoompanel.Left = oUnicodeBlocks.pUniBlockTemplate.Left + sender.left
            currCPBlockzoompanel.Top = oUnicodeBlocks.pUniBlockTemplate.Top + sender.top
            currCPBlockzoompanel.Tag = sender
            currCPBlockzoompanel.SendToBack()
            CopyControlSettings(sender, currCPBlockzoompanel)

            currCPBlockzoompanel.BackgroundImage = Nothing
            currCPBlockzoompanel.Width = newwidth
            currCPBlockzoompanel.Height = newheight
            currCPBlockzoompanel.BackColor = Color.FromArgb(75, 255, 255, 255)
            currCPBlockzoompanel.BorderStyle = BorderStyle.FixedSingle
            currCPBlockzoompanel.ForeColor = Color.White
            currCPBlockzoompanel.Cursor = Cursors.SizeAll
            'Dim p As New Panel
            'p.BackgroundImageLayout = ImageLayout.Center
            'p.BackgroundImageLayout = ImageLayout.Stretch
            currCPBlockzoompanel.BringToFront()
            If sender.top <> 0 Then : currCPBlockzoompanel.Top -= (OrgHeight / 2) - 2 : End If
            If sender.left <> 0 Then : currCPBlockzoompanel.Left -= (Orgwidth / 2) - 1 : End If
            For Each ctl In sender.controls
                Dim xLabel As New Windows.Forms.Label
                xLabel.Name = Microsoft.VisualBasic.Left(ctl.name, 3) & "x"
                currCPBlockzoompanel.Controls.Add(xLabel)
                CopyControlSettings(ctl, xLabel)
                xLabel.Text = ctl.text
                xLabel.BackColor = Color.FromArgb(128, 170, 170, 255)
                xLabel.Tag = iobjid
                xLabel.Width *= 2
                xLabel.Height *= 2
                xLabel.Cursor = Cursors.SizeAll
                If ctl.left <> 0 Then : xLabel.Left *= 2 : End If
                If ctl.top <> 0 Then : xLabel.Top *= 2 : End If
                olab = CType(xLabel, Windows.Forms.Label)
                xLabel.ForeColor = Color.White
                AddHandler xLabel.MouseClick, AddressOf currCPBlockZoom_selfdestruct
                xLabel.Font = New Font(olab.Font.FontFamily, olab.Font.SizeInPoints + 6, FontStyle.Bold)
            Next
            currCPBlockzoompanel.BringToFront()
            currCPBlockzoompanel.Visible = True
            currCPBlockzoompanel.Focus()
        End If
    End Sub
    Public Sub currCPBlockZoom_selfdestruct(ByVal sender As Object, ByVal e As EventArgs)
        ControlByName("pxr" & sender.tag, sender.parent.parent).Tag = ""
        sender.parent.dispose()
    End Sub

    Public Function ControlByName(ByVal strname As String, ByVal ctrl As Control) As Control

        'Dim ctrlCol As Windows.Forms.Control.ControlCollection = ctrl.Controls
        Dim ctrlCol As Windows.Forms.Control.ControlCollection
        Dim bFound As Boolean = False
        Dim stack As New Stack(Of Control)
        Dim CtrlMatch As Control = Nothing
        stack.Push(ctrl)

        Do While (stack.Count > 0) And bFound = False
            Dim result As Control = stack.Pop
            ' Get top directory string
            ctrlCol = result.Controls
            Try
                For Each c As Control In ctrlCol
                    If c.Controls.Count > 0 Then
                        stack.Push(c)
                    End If
                    If StrComp(c.Name, strname, CompareMethod.Text) = 0 Then
                        CtrlMatch = c
                        bFound = True
                        Exit For
                    End If
                Next

            Catch ex As Exception

            End Try
        Loop
        Return CtrlMatch


    End Function
    Public Sub SelectFont(Optional ByVal seldialog As FontDialog = Nothing)
        seldialog.Font = selectedFont
        seldialog.Color = Color.Black
        seldialog.ShowColor = False
        'Show the Apply button on the dialog box.		
        'The default is false.			
        seldialog.ShowApply = True
        ' Allow users to select effects. The default is true.			
        seldialog.ShowEffects = False
        ' Show the Help button.	 The default is false.			
        seldialog.ShowHelp = True
        ' Let the user change the character set, 			
        ' but don't allow simulations, vector fonts, 			
        ' or vertical fonts.		
        ' The default is true.		
        seldialog.AllowScriptChange = False
        seldialog.ScriptsOnly = True

        ' The default is true.			
        seldialog.AllowSimulations = True
        'The default is true.
        seldialog.AllowVectorFonts = False
        seldialog.AllowVerticalFonts = False

        ' Allow fixed and proportional fonts, 
        ' and only allow fonts that exist.
        ' Set the minimum and maximum selectable
        ' font sizes, well. These are arbitrary
        ' values, in this example.
        ' The default is false.

        seldialog.FixedPitchOnly = False

        ' The default is false.

        seldialog.FontMustExist = True

        ' The default for both these is 0.

        seldialog.MaxSize = 48
        seldialog.MinSize = 6

        ' Display the dialog box, and then
        ' fix up the font requested.
        Try
            If seldialog.ShowDialog() = DialogResult.OK Then
                Call ApplyFont(seldialog, Nothing)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, oMainForm.Text)
            Err.Clear()
            seldialog.Font = oUnicodeBlocks.lblCharTemplate.Font
            Call ApplyFont(seldialog, Nothing)
        End Try


    End Sub

    Public Sub ApplyFont(ByVal sender As Object, ByVal e As EventArgs)
        selectedFont = sender.Font
        If Not oUnicodeBlocks Is Nothing Then
            oUnicodeBlocks.lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"
        End If
        If Not oCodePageMaps Is Nothing Then
            oCodePageMaps.lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"
        End If
        If Not oUniCodeSearch Is Nothing Then
            oUniCodeSearch.lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"
        End If

        Dim tempChild As Form = My.Application.OpenForms.Item(1)
        If bDebug = True Then Console.WriteLine(tempChild.Name)

        Call SaveVariousSet("SelectedFontName", selectedFont.Name)
        Call SaveVariousSet("SelectedFontSize", selectedFont.Size)
        Call SaveVariousSet("SelectedFontUnit", selectedFont.Unit)
        Call SaveVariousSet("SelectedFontBold", selectedFont.Bold)

        If tempChild.Name = "CodePageMaps" Then
            If oCodePageMaps.DataGridView1.ColumnCount > 0 Then
                oCodePageMaps.DataGridView1.Columns(0).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oCodePageMaps.DataGridView1.Columns(1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.66, FontStyle.Regular, 3)
                oCodePageMaps.DataGridView1.Columns(2).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oCodePageMaps.DataGridView1.Columns(3).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oCodePageMaps.DataGridView1.Columns(4).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.5, FontStyle.Regular, 3)
                For x As Integer = 0 To 32
                    oCodePageMaps.DataGridView1.Rows(x).Cells(1).Style.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Bold, 3)
                Next
            End If
        End If
        If tempChild.Name = "UniCodeSearch" Then
            If oUniCodeSearch.DataGridView1.ColumnCount > 0 Then
                oUniCodeSearch.DataGridView1.Columns(0).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 2, FontStyle.Regular, 3)
                oUniCodeSearch.DataGridView1.Columns(1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oUniCodeSearch.DataGridView1.Columns(2).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oUniCodeSearch.DataGridView1.Columns(3).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
                oUniCodeSearch.DataGridView1.Columns(4).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)
            End If
        End If
        If tempChild.Name = "UnicodeBlocks" Then
            'Grp.Item(a).Font = New Drawing.Font(Grp.Item(a).Font.FontFamily, Grp.Item(a).Font.Size, FontStyle.Bold)
            Dim oCtrls As Windows.Forms.Control() = oUnicodeBlocks.Controls.Find("pBlocker", False)
            If oCtrls.Count > 0 Then
                For Each oChildCtrl In oCtrls(0).Controls
                    For Each oChildLabel In oChildCtrl.Controls
                        '  p2.Name = "pxr" & iCurr
                        '  lC.Name = "lcr" & iCurr
                        '  lCi.Name = "lci" & iCurr
                        '  lCh.Name = "lch" & iCurr
                        'Dim ol As Label


                        If Microsoft.VisualBasic.Left(oChildLabel.name, 3) = "lcr" Then
                            oChildLabel.font = selectedFont
                            If bDebug = True Then Console.WriteLine(oChildLabel.font.Bold)
                            If bDebug = True Then Console.WriteLine(oChildLabel.font.underline)
                            If bDebug = True Then Console.WriteLine(oChildLabel.font.Strikeout)
                            Dim oStyle As New FontStyle
                            If oChildLabel.font.Bold = True Then
                                oStyle = FontStyle.Bold
                            Else
                                oStyle = FontStyle.Regular
                            End If
                            If CInt(Microsoft.VisualBasic.Right(oChildLabel.name, Len(oChildLabel.name) - 3)) <= 32 Then
                                oChildLabel.font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.44, oStyle, oChildLabel.font.unit)
                            Else
                                oChildLabel.font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.66, oStyle, oChildLabel.font.unit)
                            End If

                        End If
                    Next
                Next
            Else
                If bDebug = True Then Console.WriteLine("not found")
            End If
        End If
    End Sub


    Public Sub CodePageDifferences(ByRef DGW As DataGridView)
        Dim MyRow As Integer
        Dim results(,) As Integer
        ReDim results(255, CPS.CodePages.Count)
        For a As Integer = 0 To 255
            For b As Integer = 0 To CPS.CodePages.Count - 1
                If b = 0 Then
                    results(a, 0) = 0
                    results(a, b + 1) = CPS.CodePages.Item(b).toUNI(a)
                Else
                    Dim iChr As Integer = CPS.CodePages.Item(b).toUNI(a)
                    If results(a, 1) = iChr Then
                        results(a, b + 1) = -1
                    Else
                        results(a, b + 1) = iChr
                        results(a, 0) += 1
                    End If
                End If

            Next
        Next
        DGW.Rows.Clear()
        DGW.Columns.Clear()
        DGW.ScrollBars = System.Windows.Forms.ScrollBars.Both
        DGW.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DGW.Columns.Add("ASC", "ASC")
        DGW.Columns(0).ReadOnly = True
        DGW.Columns(0).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.7, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
        DGW.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGW.Columns(0).Width = 40
        For a As Integer = 0 To CPS.CodePages.Count - 4
            Dim sCP As String = CType(CPS.CodePagesSelection(a), AnsiCPMaps.clsCodePage).Code
            DGW.Columns.Add(sCP, sCP)
            DGW.Columns(a + 1).ReadOnly = True
            If a = 0 Then
                DGW.Columns(a + 1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size, FontStyle.Bold, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
            Else
                DGW.Columns(a + 1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
            End If

            DGW.Columns(a + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGW.Columns(a + 1).Width = 40
        Next
        Try

            For a As Integer = 0 To 254
                If results(a, 0) > 0 Then
                    Dim itemP As New DataGridViewRow
                    itemP.CreateCells(DGW)
                    Try
                        With itemP
                            .Cells(0).Value = Strings.Right("  " & a, 3)
                            .Cells(0).Style.BackColor = Color.Silver
                            For b As Integer = 0 To CPS.CodePages.Count - 4
                                If results(a, b + 1) <> -1 Then
                                    If a >= 0 And a <= 32 Then
                                        .Cells(b + 1).Value = aCtrlChars(a)

                                        .Cells(b + 1).Style.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.8, FontStyle.Bold, 3) 'New Font("Lucida Console", 9, FontStyle.Bold, GraphicsUnit.Point)
                                    Else
                                        .Cells(b + 1).Value = ChrW(results(a, b + 1))
                                    End If
                                Else
                                    .Cells(b + 1).Value = " "
                                    .Cells(b + 1).Style.BackColor = Color.FromArgb(255, 64, 64, 64)
                                End If
                            Next
                        End With
                    Catch ex As Exception

                    End Try
                    MyRow = DGW.Rows.Add(itemP)
                    'My.Application.DoEvents()
                End If
            Next
            DGW.AutoResizeColumns()
            System.Windows.Forms.Application.DoEvents()
        Catch ex As Exception

        End Try

    End Sub

End Module
