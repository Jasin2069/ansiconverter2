Public Class UniCodeSearch

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub UniCodeSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '   Me.Width = MainForm.Width
        '   Me.Height = MainForm.Height
        '   Me.Top = MainForm.Top
        '   Me.Left = MainForm.Left
        'btnClose.Top = MainForm.Height - btnClose.Height - 30
        'btnClose.Left = MainForm.Width - btnClose.Width - 15
        'DataGridView1.Width = MainForm.Width - 30
        'DataGridView1.Height = MainForm.Height - 220
        'DataGridView1.Columns(2).Width = DataGridView1.Width - 380
        txtSearch.Focus()
    End Sub

    Private Sub UniCodeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'AddHandler Me.btnSearch.Click, AddressOf Me.Searchstart

        'listCPnew.SetSelected(0, True)
        lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"
        AddHandler FontDialog1.Apply, AddressOf ApplyFont

        'AddHandler Me.btnUp1.Click, AddressOf Buttons
        'AddHandler Me.btnDown1.Click, AddressOf Buttons
        'AddHandler Me.btnUpBig1.Click, AddressOf Buttons
        'AddHandler Me.btnDownBig1.Click, AddressOf Buttons
        'ScrollBar1.DataGridViewControl = Me.DataGridView1
        'ScrollBar1.SetDataGridviewControl(Me.DataGridView1)
        'ScrollBar1.UpBtnImage = ANSI_ASCII_Converter.My.Resources.Resources.arrowup
        'ScrollBar1.DnBtnImage = ANSI_ASCII_Converter.My.Resources.Resources.arrowdown
        'Scrollbarinit()

    End Sub

    Friend Sub Searchstart(ByVal sender As Object, ByVal e As EventArgs)
        Dim MyRow As Integer
        '  If listCPnew.SelectedIndex <> -1 Then
        'If listCPnew.SelectedValue.ToString() <> "" Then
        'If SelectedCP <> listCPnew.SelectedValue.ToString() Then
        'SelectedCP = listCPnew.SelectedValue.ToString()
        'selCPName.Text = CodePages.Item(listCP.SelectedIndex).Name
        'selCPName.Text = CType(listCPnew.SelectedItem, CodePage).Name()
        Me.Cursor = Cursors.WaitCursor
        'Dim DataGridViewCellStyleX As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        'DataGridViewCellStyleX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))

        DataGridView1.Rows.Clear()
        sCount.Text = 0
        My.Application.DoEvents()
        DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = True
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.ScrollBars = ScrollBars.Both
        DataGridView1.MultiSelect = False

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("DISP", "")
        DataGridView1.Columns.Add("CID", "ID")
        DataGridView1.Columns.Add("CNAME", "Name")
        DataGridView1.Columns.Add("CSIMILAR", "Similar")
        DataGridView1.Columns.Add("NOTES", "Notes")

        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(0).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 2, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(0).ValueType = GetType(String)
        DataGridView1.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)  'selectedFont 'New Font("Lucida Console", 14, FontStyle.Bold, GraphicsUnit.Point)
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        DataGridView1.Columns(1).ValueType = GetType(String)
        DataGridView1.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(2).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)  ' New Font("Lucida Console", 8, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        DataGridView1.Columns(2).ValueType = GetType(String)
        DataGridView1.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(3).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        DataGridView1.Columns(3).ValueType = GetType(String)
        DataGridView1.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridView1.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(4).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3) ' New Font("Lucida Console", 11, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
        DataGridView1.Columns(4).ValueType = GetType(String)
        DataGridView1.Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 130
        DataGridView1.Columns(2).Width = DataGridView1.Width - 600
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
        DataGridView1.AutoScrollOffset = New Point(25, 25)
        Dim sSearch As String = txtSearch.Text
        UniNamesList = BuildUniCodeNamesList(UniNamesList)
        recCount.Text = UniNamesList.Count
        recCount.Refresh()
        Converter.bHTMLEncode = False
        Converter.bSanitize = False
        Converter.BuildMappings("CP437")
        My.Application.DoEvents()
        Try
            Dim bMatch As Boolean = False
            For a As Integer = 0 To UniNamesList.Count - 1
                bMatch = False
                If bIDs.Checked = True And bMatch = False Then
                    If Converter.isInt(sSearch) Then
                        If CInt(sSearch) = a Then
                            bMatch = True
                        End If
                    End If
                    If InStr(UniNamesList.Item(a).CodeHex, sSearch, CompareMethod.Text) > 0 Then
                        bMatch = True
                    End If
                    If InStr(UniNamesList.Item(a).CodeHex, sSearch, CompareMethod.Text) > 0 Then
                        bMatch = True
                    End If
                    If InStr(UniNamesList.Item(a).CodeOct, sSearch, CompareMethod.Text) > 0 Then
                        bMatch = True
                    End If
                    If InStr(UniNamesList.Item(a).CodeBin, sSearch, CompareMethod.Text) > 0 Then
                        bMatch = True
                    End If
                End If
                If bNames.Checked = True And bMatch = False Then
                    If InStr(UniNamesList.Item(a).Name, sSearch, CompareMethod.Text) > 0 Then
                        bMatch = True
                    End If
                    If bMatch = False Then
                        For b As Integer = 0 To UniNamesList.Item(a).Aliases.Count - 1
                            If InStr(UniNamesList.Item(a).Aliases.Item(b), sSearch, CompareMethod.Text) > 0 Then
                                bMatch = True
                                Exit For
                            End If
                        Next
                    End If
                End If
                If bSimilar.Checked = True And bMatch = False Then
                    For b As Integer = 0 To UniNamesList.Item(a).Similar.Count - 1
                        If InStr(UniNamesList.Item(a).Similar.Item(b), sSearch, CompareMethod.Text) > 0 Then
                            bMatch = True
                            Exit For
                        End If
                    Next
                End If
                If bNotes.Checked = True And bMatch = False Then
                    For b As Integer = 0 To UniNamesList.Item(a).Notes.Count - 1
                        If InStr(UniNamesList.Item(a).Notes.Item(b), sSearch, CompareMethod.Text) > 0 Then
                            bMatch = True
                            Exit For
                        End If
                    Next
                End If
                If bMatch = True Then
                    Dim itemP As New DataGridViewRow
                    itemP.CreateCells(DataGridView1)
                    With itemP
                        If UniNamesList.Item(a).Code >= 0 And UniNamesList.Item(a).Code <= 32 Then
                            '.Cells(1).Value = ChrW(AscW(ChrW(9216 + a)))
                            .Cells(0).Value = Converter.aCtrlChars(UniNamesList.Item(a).Code)
                            .Cells(0).Style.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 2, FontStyle.Bold, 3) 'New Font("Lucida Console", 9, FontStyle.Bold, GraphicsUnit.Point)
                        Else
                            .Cells(0).Value = Converter.AscConv(UniNamesList.Item(a).Code)
                        End If
                        .Cells(1).Value = "Dec:" & Strings.Right(Space(10) & UniNamesList.Item(a).Code, 10) & vbCrLf & _
                                          "Hex:" & Strings.Right("0000000000" & UniNamesList.Item(a).CodeHex, 10) & vbCrLf & _
                                          "Oct:" & Strings.Right("0000000000" & UniNamesList.Item(a).CodeOct, 10) & vbCrLf & _
                                          "Bin:" & Strings.Right("0000000000" & UniNamesList.Item(a).CodeBin, 10) & vbCrLf
                        Dim sVal As String = UniNamesList.Item(a).Name & vbCrLf
                        If UniNamesList.Item(a).Aliases.Count > 0 Then
                            For b As Integer = 0 To UniNamesList.Item(a).Aliases.Count - 1
                                sVal &= """" & Replace(UniNamesList.Item(a).Aliases.Item(b), " ", ".", 1, -1, CompareMethod.Text) & """" & vbCrLf
                            Next
                        End If
                        .Cells(2).Value = sVal
                        sVal = ""
                        If UniNamesList.Item(a).Similar.Count > 0 Then
                            For b As Integer = 0 To UniNamesList.Item(a).Similar.Count - 1
                                sVal &= "-" & Replace(UniNamesList.Item(a).Similar.Item(b), " ", ".", 1, -1, CompareMethod.Text) & vbCrLf
                            Next
                        End If
                        .Cells(3).Value = sVal
                        sVal = ""
                        If UniNamesList.Item(a).Notes.Count > 0 Then
                            For b As Integer = 0 To UniNamesList.Item(a).Notes.Count - 1
                                sVal &= "-" & Replace(UniNamesList.Item(a).Notes.Item(b), " ", ".", 1, -1, CompareMethod.Text) & vbCrLf
                            Next
                        End If
                        .Cells(4).Value = sVal


                    End With
                    sCount.Text += 1
                    MyRow = DataGridView1.Rows.Add(itemP)
                    My.Application.DoEvents()
                End If
            Next
            'DataGridView1.AutoSize = True
        Catch ex As Exception

        End Try
        DataGridView1.ScrollBars = ScrollBars.Both
        'DataGridView1.HorizontalScrollingOffset = 10

        'Loop
        Me.Cursor = Cursors.Default

    End Sub 'iNCP_SelectedValueChanged

    Private Sub btnSelfont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfont.Click
        SelectFont(FontDialog1)
    End Sub

    Private Sub txtSearch_Keydown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Searchstart(sender, e)
        End If
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Searchstart(sender, e)
    End Sub
End Class