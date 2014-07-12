Public Class CodePageMaps
    Friend SelectedCP As String = ""
    Friend CodePages As ArrayList

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        My.Application.OpenForms.Remove(oCodePageMaps)
    End Sub
    Private Sub CodePageMaps_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Width = oMainForm.Width
        Me.Height = oMainForm.Height
        Me.Top = oMainForm.Top
        Me.Left = oMainForm.Left
        'btnClose.Top = MainForm.Height - btnClose.Height - 30
        'btnClose.Left = MainForm.Width - btnClose.Width - 15
        'DataGridView1.Width = MainForm.Width - 30
        'DataGridView1.Height = MainForm.Height - 220
        'DataGridView1.Columns(2).Width = DataGridView1.Width - 380
    End Sub

    Private Sub CodePageMaps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim iCPLcnt As Integer
        CodePages = New ArrayList()
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


        listCPnew.DataSource = CodePages
        listCPnew.DisplayMember = "Name"
        listCPnew.ValueMember = "Code"
        listCPnew.Text = ""
        SelectedCP = ""
        AddHandler listCPnew.SelectedValueChanged, AddressOf listCP_SelectedValueChanged
        listCPnew.Text = "CP437"
        listCPnew.SelectedValue = "CP437"
        listCP_SelectedValueChanged(listCPnew, Nothing)
        'listCPnew.SetSelected(0, True)
        lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"
        AddHandler FontDialog1.Apply, AddressOf ApplyFont

        'AddHandler Me.btnUp1.Click, AddressOf Buttons
        'AddHandler Me.btnDown1.Click, AddressOf Buttons
        'AddHandler Me.btnUpBig1.Click, AddressOf Buttons
        'AddHandler Me.btnDownBig1.Click, AddressOf Buttons
        'ScrollBar1.DataGridViewControl = Me.DataGridView1
        ScrollBar1.SetDataGridviewControl(Me.DataGridView1)
        'ScrollBar1.UpBtnImage = ANSI_ASCII_Converter.My.Resources.Resources.arrowup
        'ScrollBar1.DnBtnImage = ANSI_ASCII_Converter.My.Resources.Resources.arrowdown
        'Scrollbarinit()

    End Sub

    Friend Sub listCP_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim MyRow As Integer
        If listCPnew.SelectedIndex <> -1 Then
            If listCPnew.SelectedValue.ToString() <> "" Then
                If SelectedCP <> listCPnew.SelectedValue.ToString() Then
                    SelectedCP = listCPnew.SelectedValue.ToString()
                    'selCPName.Text = CodePages.Item(listCP.SelectedIndex).Name
                    selCPName.Text = CType(listCPnew.SelectedItem, CodePage).Name()
                    Me.Cursor = Cursors.WaitCursor
                    'Dim DataGridViewCellStyleX As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
                    'DataGridViewCellStyleX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))

                    DataGridView1.Rows.Clear()
                    DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                    DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
                    DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
                    DataGridView1.RowHeadersVisible = False
                    DataGridView1.AllowUserToAddRows = False
                    DataGridView1.AllowUserToDeleteRows = False
                    DataGridView1.AllowUserToResizeRows = False
                    DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None
                    DataGridView1.MultiSelect = False
                    DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    DataGridView1.Columns.Clear()
                    DataGridView1.Columns.Add("ASC", "ASC (HEX)")
                    DataGridView1.Columns.Add("DISP", "")
                    DataGridView1.Columns.Add("CNAME", "Name")
                    DataGridView1.Columns.Add("UNI", "UNI (HEX)")
                    DataGridView1.Columns.Add("HTML", "HTML")
                    System.Windows.Forms.Application.DoEvents()
                    DataGridView1.Columns(0).ReadOnly = True
                    DataGridView1.Columns(0).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
                    DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DataGridView1.Columns(1).ReadOnly = True
                    DataGridView1.Columns(1).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.66, FontStyle.Bold, 3)  'selectedFont 'New Font("Lucida Console", 14, FontStyle.Bold, GraphicsUnit.Point)
                    DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DataGridView1.Columns(2).ReadOnly = True
                    DataGridView1.Columns(2).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3)  ' New Font("Lucida Console", 8, FontStyle.Regular, GraphicsUnit.Point)
                    DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    DataGridView1.Columns(3).ReadOnly = True
                    DataGridView1.Columns(3).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Regular, 3) ' New Font("Lucida Console", 9, FontStyle.Regular, GraphicsUnit.Point)
                    DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DataGridView1.Columns(4).ReadOnly = True
                    DataGridView1.Columns(4).DefaultCellStyle.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.5, FontStyle.Bold, 3) ' New Font("Lucida Console", 11, FontStyle.Regular, GraphicsUnit.Point)
                    DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                    DataGridView1.Columns(0).Width = 85
                    DataGridView1.Columns(1).Width = 50
                    DataGridView1.Columns(2).Width = DataGridView1.Width - 380
                    DataGridView1.Columns(3).Width = 105
                    DataGridView1.Columns(4).Width = 100
                    Converter.bHTMLEncode = False
                    Converter.bSanitize = False
                    Converter.ConverterSupport.BuildMappings(SelectedCP)
                    System.Windows.Forms.Application.DoEvents()
                    Try
                        For a As Integer = 0 To 254
                            Dim itemP As New DataGridViewRow
                            itemP.CreateCells(DataGridView1)
                            With itemP
                                .Cells(0).Value = Microsoft.VisualBasic.Right("  " & a, 3) & " (" & Microsoft.VisualBasic.Right("00" & Hex(a), 2) & ")"
                                If a >= 0 And a <= 32 Then
                                    '.Cells(1).Value = ChrW(AscW(ChrW(9216 + a)))
                                    .Cells(1).Value = Converter.Internal.aCtrlChars(a)
                                    .Cells(1).Style.Font = New Drawing.Font(selectedFont.FontFamily, selectedFont.Size * 0.4, FontStyle.Bold, 3) 'New Font("Lucida Console", 9, FontStyle.Bold, GraphicsUnit.Point)
                                Else
                                    .Cells(1).Value = Converter.ConverterSupport.AscConv(a)
                                End If

                                .Cells(2).Value = Converter.Internal.aCPdesc(a)
                                .Cells(3).Value = Microsoft.VisualBasic.Right("     " & Converter.Internal.aUniCode(a), 5) & " (" & Microsoft.VisualBasic.Right("0000" & Hex(Converter.Internal.aUniCode(a)), 4) & ")"
                                If Converter.Internal.aSpecH(a) <> "" Then
                                    .Cells(4).Value = Converter.Internal.aSpecH(a)
                                Else
                                    .Cells(4).Value = ""
                                End If

                            End With
                            MyRow = DataGridView1.Rows.Add(itemP)
                            System.Windows.Forms.Application.DoEvents()
                        Next
                    Catch ex As Exception

                    End Try


                    'Loop
                    Me.Cursor = Cursors.Default
                    'End Loop
                End If
            Else
                listCPnew.SelectedValue = "CP437"
            End If



            ' If we also wanted to get the displayed text we could use
            ' the SelectedItem item property:
            ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
        End If
    End Sub 'iNCP_SelectedValueChanged

    Private Sub btnSelfont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfont.Click
        SelectFont(FontDialog1)
    End Sub


    Private Sub btnCompare_Click(sender As System.Object, e As System.EventArgs) Handles btnCompare.Click
        CodePageDifferences(DataGridView1)
        selCPName.Text = "Code Page Comparison"
        DataGridView1.ScrollBars = ScrollBars.Horizontal
    End Sub
End Class