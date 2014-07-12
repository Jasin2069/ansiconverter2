Imports System.Windows.Forms.Control
Imports System.Threading
Imports System.ComponentModel
Public Class MainForm
    Private DraggingStart As Boolean = False

    Public MainDataLoaded As Boolean = False
    Private _Target As ISynchronizeInvoke
    Public ReadOnly Property Target As ISynchronizeInvoke
        Get
            Return _Target
        End Get
    End Property
    Private Sub MainForm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If NFOViewer.Opacity > 0 Then
            NFOViewer.Close()
        End If
    End Sub


    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainFormLoaded = False
        MainThreadID = System.Threading.Thread.CurrentThread.GetHashCode()
        Me.Text = My.Application.Info.ProductName & " - " & My.Application.Info.Version.ToString
        Me.Top = (My.Computer.Screen.WorkingArea.Height / 2) - (Me.Height / 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width / 2) - (Me.Width / 2)
        'Console.WriteLine("Maroon R: " & Drawing.Color.Maroon.R.ToString & ",G:" & Drawing.Color.Maroon.G.ToString & ",B:" & Drawing.Color.Maroon.B.ToString)
        'Console.WriteLine("RoyalBlue R: " & Drawing.Color.RoyalBlue.R.ToString & ",G:" & Drawing.Color.RoyalBlue.G.ToString & ",B:" & Drawing.Color.RoyalBlue.B.ToString)
        Try
            Call InitConst()
        Catch ex As Exception

        End Try

        Me._Target = Me
        'pHTMLObj.Left = 388
        'pHTMLObj.Top = 163
        'pUTF.Left = outUnicode.Left + 25
        'pUTF.Top = 163
        'pHTMLObj.Left = outHTML.Left + 105
        'pNoCols.Top = 163
        'pSmallFnt.Top = 163
        'pSmallFnt.Left = outImage.Left - pSmallFnt.Width - 125
        'pNoCols.Left = pSmallFnt.Left - pNoCols.Width
        'pThumb.Top = 163
        'pThumb.Left = pSmallFnt.Left + pSmallFnt.Width + 3
        'pSanitize.Left = 388
        'pSanitize.Top = 163
        'pSanitize.Left = pHTMLObj.Left + pHTMLObj.Width
        'pAnim.Top = 163
        'pAnim.Left = (outHTML.Left - pAnim.Width) + 5
        Dim HDiff As Integer = 78
        log.Top -= HDiff
        log.Top += 40
        log.Height += HDiff - 30
        log.Height -= 10
        lblLogAndInfos.Top -= 10
        lblLogAndInfos.BringToFront()
        'pHTMLObj.BringToFront()
        'pSanitize.BringToFront()
        'pSmallFnt.BringToFront()
        'pNoCols.BringToFront()
        'pThumb.BringToFront()

        pCPInEmpty.Top = pCPin.Top
        pCPInEmpty.Left = pCPin.Left
        pCPInEmpty.Width = pCPin.Width
        pCPInEmpty.Height = pCPin.Height
        pCPInEmpty.SendToBack()

        pCPOutEmpty.Top = pCPout.Top
        pCPOutEmpty.Left = pCPout.Left
        pCPOutEmpty.Width = pCPout.Width
        pCPOutEmpty.Height = pCPout.Height
        pCPOutEmpty.SendToBack()

        'My.Application.SaveMySettingsOnExit = True
        'My.Settings.Reset()
        Dim iCPLcnt As Integer
        Dim CodePages As New ArrayList()
        For iCPLcnt = 0 To UBound(aCPL)
            If aCPL(iCPLcnt) <> "" Then
                CodePages.Add(New CodePage(aCPLN(iCPLcnt) & " (" & aCPL(iCPLcnt) & ")", aCPL(iCPLcnt), aCPLISO(iCPLcnt)))
            End If
        Next
        For iCPLcnt = 0 To UBound(aWinCPL)
            If aWinCPL(iCPLcnt) <> "" Then
                CodePages.Add(New CodePage(aWinCPLN(iCPLcnt) & " (" & aWinCPL(iCPLcnt) & ")", aWinCPL(iCPLcnt), aWinCPLISO(iCPLcnt)))
            End If
        Next
        outCP.DataSource = CodePages
        outCP.DisplayMember = "Name"
        outCP.ValueMember = "Code"
        inCP.DataSource = CodePages
        inCP.DisplayMember = "Name"
        inCP.ValueMember = "Code"
        Me.log.Width = 506
        lblInfoSameDirOut.Left = 120
        inCP.Text = "CP437"
        'inCP.SelectedValue = "CP437"
        outCP.Text = "CP437"
        'outCP.SelectedValue = "CP437"

        ' Bind the SelectedValueChanged event to our handler for it.
        AddHandler inCP.SelectedValueChanged, AddressOf inCP_SelectedValueChanged
        AddHandler outCP.SelectedValueChanged, AddressOf outCP_SelectedValueChanged


        listFiles.DataSource = FileListItemBindingSource
        listFiles.SelectionMode = SelectionMode.MultiExtended
        listFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        AddHandler listFiles.DrawItem, AddressOf DrawItemHandler
        AddHandler listFiles.MeasureItem, AddressOf MeasureItemHandler
        AddHandler listFiles.SelectedIndexChanged, AddressOf filelistitem_indexchange


        AddHandler Me.MouseHover, AddressOf MainForm_MouseOver

        AddHandler btnQuit.Click, AddressOf btnQuit_Click
        AddHandler btnStart.Click, AddressOf btnStart_Click
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        AddHandler btnRemove.Click, AddressOf btnRemove_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler listFiles.Click, AddressOf listFiles_click
        AddHandler btnSelNone.Click, AddressOf btnSelNone_Click
        AddHandler log.TextChanged, AddressOf log_TextChanged

        btnSettings.Text = ChrW(9788)
        btnSettings2.Text = ChrW(9788)
        AddHandler btnCPMaps.Click, AddressOf btnCPMaps_Click
        AddHandler btnUniBlocks.Click, AddressOf btnUniBlocks_Click
        AddHandler btnSearch.Click, AddressOf btnUniSearch_Click
        AddHandler lblDropHere.DragEnter, AddressOf listfiles_DragEnter
        AddHandler lblDropHere.DragLeave, AddressOf listfiles_DragLeave
        AddHandler lblDropHere.DragDrop, AddressOf listfiles_DragDrop

        AddHandler listFiles.DragDrop, AddressOf listfiles_DragDrop
        AddHandler listFiles.DragEnter, AddressOf listfiles_DragEnter
        AddHandler Me.DragEnter, AddressOf listfiles_DragLeave
        AddHandler listFiles.DragLeave, AddressOf listfiles_DragLeave
        AddHandler listFiles.MouseLeave, AddressOf listfiles_MouseLeave
        AddHandler btnOutputFolder.Click, AddressOf btnOutputFolder_Click

        AddHandler btnSettings.Click, AddressOf btnSettings2_Click
        AddHandler btnSettings2.Click, AddressOf btnSettings2_Click
        'btnSettings2
        For Each l As Label In ListSettLabels
            'AddHandler l.Click, AddressOf ShowUpdateControl
            AddHandler l.Click, AddressOf btnSettings_Click
            AddHandler l.MouseEnter, AddressOf settMouseOver
            AddHandler l.MouseLeave, AddressOf settMouseOut
        Next
        'AddHandler settSanitize.Click, AddressOf ShowUpdateControl
        'AddHandler settUTF.Click, AddressOf ShowUpdateControl
        'AddHandler settGen.Click, AddressOf ShowUpdateControl

        'ShowUpdateControl
        For a As Integer = 0 To ListIn2.Count - 1
            AddHandler ListIn2.Item(a).Click, AddressOf InputUpdate
        Next
        AddHandler txtExt.TextChanged, AddressOf txtExt_TextChanged
        AddHandler txtExt.DoubleClick, AddressOf txtExt_DoubleClick

        'Settings forms event handlers
        AddHandler Settings.FontDialog1.Apply, AddressOf ApplyFont

        For a As Integer = 0 To ListAll.Count - 1
            For Each r As RadioButton In CType(ListAll.Item(a), List(Of RadioButton))
                AddHandler r.Click, AddressOf ControlUpdate
            Next
        Next
        For a As Integer = 0 To ListOutExtExtend.Count - 1
            For Each r As RadioButton In CType(ListOutExtExtend.Item(a), List(Of RadioButton))
                AddHandler r.CheckedChanged, AddressOf Settings.ExtUpd
            Next
        Next
        '
      
        Settings.cbHTMLFont.DataSource = oConv.WebFonts
        Settings.cbHTMLFont.DisplayMember = "Name"
        Settings.cbHTMLFont.ValueMember = "Name"
        Settings.cbHTMLFont.Text = sHTMLFont
        Settings.cbHTMLFont.SelectedValue = sHTMLFont
        Settings.cbHTMLFont.Tag = sHTMLFont

        AddHandler Settings.Sanitize.CheckedChanged, AddressOf Settings.ControlUpdate2
        AddHandler Settings.bRemoveCompleted.CheckedChanged, AddressOf Settings.ControlUpdate2
        AddHandler Settings.SmallFnt.CheckedChanged, AddressOf Settings.ControlUpdate2
        AddHandler Settings.NoCols.CheckedChanged, AddressOf Settings.ControlUpdate2
        AddHandler Settings.Thumb.CheckedChanged, AddressOf Settings.ControlUpdate2


        AddHandler Settings.txtFPS.TextChanged, AddressOf Settings.txtFPS_TextChanged
        AddHandler Settings.txtBPS.TextChanged, AddressOf Settings.txtBPS_TextChanged
        AddHandler Settings.txtLastFrame.TextChanged, AddressOf Settings.txtLastFrame_TextChanged
        AddHandler lblDebugOnOff.Click, AddressOf DebugSwitch
        AddHandler Settings.cbHTMLFont.SelectedValueChanged, AddressOf Settings.cbHTMLFontValueChanged

        'pCPin.BringToFront()
        MainFormLoaded = True
        UpdateControls(True)

        If log.Text.Length = 0 Then
            lblLogAndInfos.Visible = True
        Else
            lblLogAndInfos.Visible = False
        End If
        If listFiles.Items.Count = 0 Then
            lblDropHere.Visible = True
            lblDropHere.BringToFront()
        Else
            lblDropHere.Visible = False
        End If
        pCPin.BringToFront()
        pCPout.BringToFront()
        Dim sTempBold As Boolean, sTempName As String, sTempUnit As String, sTempSize As String

        Try
            sTempName = ReadVariousSet("SelectedFontName", selectedFont.Name)
            sTempSize = ReadVariousSet("SelectedFontSize", selectedFont.Size)
            sTempUnit = ReadVariousSet("SelectedFontUnit", selectedFont.Unit)
            sTempBold = ReadVariousSet("SelectedFontBold", selectedFont.Bold)
            selectedFont = New Drawing.Font(sTempName, CSng(sTempSize), CBool(sTempBold), CByte(sTempUnit))
        Catch ex As Exception
            If bDebug = True Then Console.WriteLine("Error Restoring Font Settings")
        End Try

        'InitializeForm()
    End Sub



    Public Sub listfiles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim filelist() As String
        'Dim file As String
        listFiles.BackColor = Color.White
        filelist = e.Data.GetData(DataFormats.FileDrop)
        listFiles.SuspendLayout()
        bAddingFiles = True
        Dim alphacomp As New AlphanumComparator.AlphanumComparator
        Array.Sort(filelist, alphacomp)
        If filelist.Count > 10 Then
            bBatchAdd = True
            Me.SuspendLayout()
        Else
            bBatchAdd = False
        End If
        For ax = 0 To filelist.Length - 1
            AddFile(filelist(ax))
            If Not bBatchAdd Then
                If ax / 10 = CInt(ax \ 10) Then
                    RefreshListFiles()
                    System.Windows.Forms.Application.DoEvents()
                End If
            End If
        Next
        If bBatchAdd Then
            Me.ResumeLayout(True)
            bBatchAdd = False
        End If

        bAddingFiles = False
        listFiles.ResumeLayout()
        RefreshListFiles()
        InfoMsg(filelist.Length.ToString & " items added to list.", False, False)
        'For Each file In filelist
        ' AddFile(file)
        ' Next

    End Sub
    Public Sub listfiles_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        listFiles.BackColor = Color.White
        listFiles.Refresh()
        If numTotal.Text = 0 Then
            lblDropHere.Visible = True
        End If
        System.Windows.Forms.Application.DoEvents()

    End Sub
    Public Sub MainForm_MouseOver(ByVal sender As Object, ByVal e As EventArgs)
        listFiles.BackColor = Color.White
        listFiles.Refresh()
        If numTotal.Text = 0 Then
            lblDropHere.Visible = True
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub listfiles_DragLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        listFiles.BackColor = Color.White
        listFiles.PerformLayout()
        If numTotal.Text = 0 Then
            lblDropHere.Visible = True
        End If
        System.Windows.Forms.Application.DoEvents()

    End Sub

    Public Sub listfiles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        ' Check to be sure that the drag content is the correct type for this 
        ' control. If not, reject the drop.
        lblDropHere.Visible = False
        If (e.Data.GetDataPresent(DataFormats.FileDrop, True)) Then
            e.Effect = DragDropEffects.Copy
            listFiles.BackColor = Color.Yellow
        Else
            'e.Effect = DragDropEffects.Move
            e.Effect = DragDropEffects.None
            listFiles.BackColor = Color.White
        End If
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Private Sub InputUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iFound As Integer = ListIn2.FindIndex(Function(x) sender.Equals(x))
        If ListCntLabels.Item(iFound).Text > 0 Then
            sender.checked = True
        Else
            sender.checked = False
        End If

    End Sub
    Public Sub ControlUpdate2(ByVal sender As System.Object, ByVal bool As Boolean)
        UpdateControls()
        If sender.parent.GetType().ToString = "System.Windows.Forms.Panel" Then
            'Dim c As Control = ControlByName(sender.parent.tag.ToString, sender.parent)
            'If sender.checked = True Then
            ' c.ForeColor = Color.Yellow
            ' c.BackColor = Color.FromArgb(128, 100, 200, 100)
            'Else
            '   c.ForeColor = Color.Black
            '  c.BackColor = Color.DarkGray
            'End If
        End If
    End Sub
    Public Sub ControlUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.checked = True
        UpdateControls()
        Exit Sub
        If sender.parent.name = "pIn" Then
            If Not sender.parent.tag.Equals(sender.tag) Then
                For a As Integer = 0 To ListOut.Count - 1
                    ListOut.Item(a).Checked = False
                Next
            End If
        End If
        If Not sender.parent.tag.Equals(sender.tag) Then
            UpdateControls()
        End If
    End Sub

    Private Sub inCP_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If MainFormLoaded = True And bUpdatingControls = False Then
            If inCP.SelectedIndex <> -1 Then
                If inCP.SelectedValue.ToString() <> "" Then
                    sCodePgIn = inCP.SelectedValue.ToString()
                    pCPin.Tag = sCodePgIn
                Else
                    inCP.SelectedValue = "CP437"
                End If
                ' If we also wanted to get the displayed text we could use
                ' the SelectedItem item property:
                ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
            End If
            UpdateControls()
        End If
    End Sub 'iNCP_SelectedValueChanged
    Private Sub outCP_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If MainFormLoaded = True And bUpdatingControls = False Then
            If outCP.SelectedIndex <> -1 Then
                If outCP.SelectedValue.ToString() <> "" Then
                    sCodePgOut = outCP.SelectedValue.ToString()
                    pCPout.Tag = sCodePgOut
                Else
                    outCP.SelectedValue = "CP437"
                End If
                ' If we also wanted to get the displayed text we could use
                ' the SelectedItem item property:
                ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
            End If
            UpdateControls()
        End If
    End Sub 'outCP_SelectedValueChanged

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()
    End Sub



    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case oConv.Status
            Case Converter.ProcessFiles.eStatus.Processing
                Select Case MsgBox("Do you really want to abort the current process? " & vbCrLf & "Press 'Yes' to ABORT!, 'No' to only PAUSE! or 'Cancel' to CONTINUE! Processing.", MsgBoxStyle.YesNoCancel, "Abort/Pause Processing?")

                    Case MsgBoxResult.Cancel
                    Case MsgBoxResult.Yes
                        oConv.CancelProcessing()
                        Me.btnStart.Text = "Aborting"
                        ToolTip1.SetToolTip(btnStart, "")
                        Me.btnStart.Enabled = False
                        System.Windows.Forms.Application.DoEvents()
                    Case MsgBoxResult.No
                        oConv.PauseProcessing()
                        Me.btnStart.Text = "Paused"
                        ToolTip1.SetToolTip(btnStart, "Click to 'Resume'" & vbCrLf & "Current Batch Processing")
                        System.Windows.Forms.Application.DoEvents()
                End Select
            Case Converter.ProcessFiles.eStatus.Paused
                ToolTip1.SetToolTip(btnStart, "click to 'Abort' or 'Pause'" & vbCrLf & "current batch processing")
                oConv.ResumeProcessing()
                Me.btnStart.Text = "Abort"
                System.Windows.Forms.Application.DoEvents()
            Case Else
                log.Text = ""
                System.Windows.Forms.Application.DoEvents()
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                Me.btnStart.Text = "Abort"
                ToolTip1.SetToolTip(btnStart, "click to 'Abort' or 'Pause'" & vbCrLf & "current batch processing")
                Me.btnStart.BeginColor = Drawing.Color.DarkRed
                Me.btnStart.EndColor = Drawing.Color.Orange
                Me.btnStart.Cursor = Cursors.Hand
                ConvertAllFiles()
                Me.Cursor = Windows.Forms.Cursors.Default
        End Select
    End Sub


    Private Sub btnOutputFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        outPath.FullText = SelectFolder(outPath.FullText)
        UpdateControls()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectFiles()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If listFiles.SelectedItems.Count > 0 Then
            If MsgBox("Are you sure that you want to remove the selected files?", MsgBoxStyle.YesNo, "Remove Selected Files") = MsgBoxResult.Yes Then
                RemoveSelectedFiles()
            End If
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If listFiles.Items.Count > 0 Then
            If MsgBox("Are you sure that you want to remove ALL files from the list?", MsgBoxStyle.YesNo, "Clear Input File List") = MsgBoxResult.Yes Then
                ClearFileList()
            End If

        End If
    End Sub

    Private Sub listFiles_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listFiles.Refresh()
    End Sub

    Private Sub btnSelNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        unSelectAll()
    End Sub
    Private Sub txtExt_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bExtInp = True Then
            If MsgBox("Are you sure that you want to reset the output file extension determination back to automatic mode?", MsgBoxStyle.YesNo, "Reset Custom Extension") = MsgBoxResult.Yes Then
                bExtInp = False
                txtExt.ForeColor = Color.Black
                txtExt.Tag = Color.Black
                ToolTipAndEvents(txtExt, "Extension used for Output Files.")
                txtExt.Cursor = Cursors.Default
                UpdateControls()

            End If
        End If
    End Sub


    Private Sub txtExt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bUpdatingControls = False And MainFormLoaded = True Then
            bExtInp = True
            txtExt.ForeColor = Color.Red
            txtExt.Tag = Color.Red
            txtExt.Cursor = Cursors.Hand
            ToolTipAndEvents(txtExt, "Custom Extension Override is active." & vbCrLf & "If you would like to reset this" & vbCrLf & "status back to automatic" & vbCrLf & "extension determination," & vbCrLf & "double click on this text box.")
            UpdateControls()
        End If
    End Sub

    Private Sub log_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Text.Length = 0 Then
            lblLogAndInfos.Visible = True
        Else
            lblLogAndInfos.Visible = False
        End If
    End Sub


   
    Private Sub btnCPMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'CodePageMaps.Top = Me.Top
            'CodePageMaps.Left = Me.Left
            'CodePageMaps.Height = Me.Height
            'CodePageMaps.Width = Me.Width
        Catch ex As Exception

        End Try
        Try

            'CodePageMaps.Visible = False

            'CodePageMaps.Visible = True
            oCodePageMaps = New CodePageMaps
            My.Application.OpenForms.Add(oCodePageMaps)
            oCodePageMaps.ShowDialog()
            'CodePageMaps.BringToFront()
            'CodePageMaps.Activate()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUniBlocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bWebConnectionIssue Then
            If MsgBox("There seems to be a problem with your Internet Connection or the site: " & uriUniDataRoot & "." & vbCrLf & "Do you want to continue anyway (may results in an Error)?", MsgBoxStyle.YesNo, "Connection Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Try
            'UnicodeBlocks.Visible = False
            'UnicodeBlocks.BringToFront()
            oUnicodeBlocks = New UnicodeBlocks
            My.Application.OpenForms.Add(oUnicodeBlocks)
            oUnicodeBlocks.ShowDialog()
            'UnicodeBlocks.Activate()
            'UnicodeBlocks.Visible = True
        Catch ex As Exception
            MsgBox("Unable to load Unicode Blocks.", MsgBoxStyle.OkOnly, "Error")
        End Try

    End Sub

    Private Sub btnUniSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bWebConnectionIssue Then
            If MsgBox("There seems to be a problem with your Internet Connection or the site: " & uriUniDataRoot & "." & vbCrLf & "Do you want to continue anyway (may results in an Error)?", MsgBoxStyle.YesNo, "Connection Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Try
            'UnicodeBlocks.Visible = False
            'UnicodeBlocks.BringToFront()

            'UnicodeBlocks.Activate()
            'UnicodeBlocks.Visible = True
            oUniCodeSearch = New UniCodeSearch
            My.Application.OpenForms.Add(oUniCodeSearch)
        Catch ex As Exception
            MsgBox("Unable to load Unicode Blocks.", MsgBoxStyle.OkOnly, "Error")
        End Try
        oUniCodeSearch.ShowDialog()
    End Sub
    Protected Overrides Sub OnActivated(e As System.EventArgs)
        MyBase.OnActivated(e)
        If Me.MainDataLoaded = False Then
            Try
                Call LoadAll()
                MainDataLoaded = True
            Catch ex As Exception
                MainDataLoaded = True
            End Try
        End If
    End Sub


    Private Sub btnNFO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNFO.Click
        oNfo = New NFOViewer
        My.Application.OpenForms.Add(oNfo)
        oNfo.AutoStart = False
        oNfo.Opacity = 0
        oNfo.WindowSize = Me.Size
        oNfo.WindowPosition = Me.Location
        oNfo.NFOText = RTrim(Converter.ConverterSupport.ByteArrayToString(My.Resources.RoySAC))
        oNfo.Show()
        oNfo.BringToFront()
        oNfo.StartForm()
        oNfo.Activate()


        oNfo.NFOText = RTrim(Converter.ConverterSupport.ByteArrayToString(My.Resources.RoySAC))
        'oNFO.Dispose()


        'Dim oForm As New FormBitmap
        'oForm.ShowDialog()
        'oForm.BringToFront()
        'oForm.Activate()

        '   oForm.Dispose()
    End Sub



    Private Sub settMouseOver(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim l As Windows.Forms.Label
        If sender.tag.Equals(Color.Black) Then
            sender.forecolor = Color.Blue
        Else
            sender.forecolor = Color.Navy
        End If

        l = CType(sender, Windows.Forms.Label)
        l.Font = New Drawing.Font(l.Font.FontFamily, l.Font.Size, FontStyle.Underline, l.Font.Unit)
    End Sub

    Private Sub settMouseOut(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim l As Windows.Forms.Label
        sender.forecolor = sender.tag
        l = CType(sender, Windows.Forms.Label)
        l.Font = New Drawing.Font(l.Font.FontFamily, l.Font.Size, FontStyle.Regular, l.Font.Unit)
    End Sub


    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Windows.Forms.Label Then
            Dim l As Windows.Forms.Label = CType(sender, Windows.Forms.Label)
            If l.Tag.Equals(Color.Black) Then
                Settings.SuspendLayout()
                Settings.Visible = False
                Settings.showdialog(sender.name)
            End If
        Else
            Settings.SuspendLayout()
            Settings.Visible = False
            Settings.showdialog("")
        End If

    End Sub

    Private Sub DebugSwitch(ByVal sender As Object, ByVal e As EventArgs)
        If bDebug = True Then
            bDebug = False
            CType(sender, Control).ForeColor = Color.Red
        Else
            bDebug = True
            CType(sender, Control).ForeColor = Color.White
        End If
    End Sub

    Private Sub btnSettings2_Click(sender As System.Object, e As System.EventArgs)
        Settings.SuspendLayout()
        Settings.Visible = False
        Settings.showdialog("")
    End Sub


End Class

