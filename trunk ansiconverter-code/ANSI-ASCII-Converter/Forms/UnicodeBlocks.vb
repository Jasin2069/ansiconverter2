Public Class UnicodeBlocks
    Private bBlockUpdating As Boolean = False

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub UnicodeBlocks_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Width = oMainForm.Width
        Me.Height = oMainForm.Height
        Me.Top = oMainForm.Top
        Me.Left = oMainForm.Left
        'btnClose.Top = MainForm.Height - btnClose.Height - 30
        'btnClose.Left = MainForm.Width - btnClose.Width - 15
        bBlockUpdating = False
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub OnLocationChanged(e As System.EventArgs)
        MyBase.OnLocationChanged(e)
        ' Me.FadingLabel1.Top = Me.pUniBlockTemplate.PointToScreen(Me.pUniBlockTemplate.Location).Y + 20
        ' Me.FadingLabel1.Left = Me.pUniBlockTemplate.PointToScreen(Me.pUniBlockTemplate.Location).X + 100
    End Sub

    Private Sub UnicodeBlocks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.Shift Then
            currCPBlockShiftDown = True
            'lblDebug.Text = "Shift Down"
        End If
    End Sub

    Private Sub UnicodeBlocks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        ' lblDebug.Text = e.KeyChar

    End Sub

    Private Sub UnicodeBlocks_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.Shift Then
            currCPBlockShiftDown = False
            'lblDebug.Text = "Shift Up"
            Try
                currCPBlockzoompanel.Visible = False
                currCPBlockzoompanel.Dispose()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub AddFonts()

        ' Get the installed fonts collection.  
        Dim allFonts As New Drawing.Text.InstalledFontCollection
        ' Get an array of the system's font familiies.  
        Dim myfontFamilies() As FontFamily = allFonts.Families()
        ' Display the font families.  

        For Each fontFamilies As FontFamily In myfontFamilies
            'fontFamilies.
            ' List1.AddItem(fontFamilies.Name)

        Next 'font_family  

    End Sub

    Private Sub UnicodeBlocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lblSelFont.Text = selectedFont.Name
        bBlockUpdating = True
        'FadingLabel1.Location = pUniBlockTemplate.PointToScreen(New Point(pUniBlockTemplate.Top, pUniBlockTemplate.Left))
        'FadingLabel1.Left = pUniBlockTemplate.PointToScreen(New Point(pUniBlockTemplate.Top, pUniBlockTemplate.Left)).X + 100
        'Me.FadingLabel1.Top = Me.pUniBlockTemplate.PointToScreen(Me.pUniBlockTemplate.Location).Y + 20
        'Me.FadingLabel1.Left = Me.pUniBlockTemplate.PointToScreen(Me.pUniBlockTemplate.Location).X + 100

        ProcBlocks(selBlock)
        bBlockUpdating = False

        listUniBlocks.DataSource = aUniBlocks
        listUniBlocks.DisplayMember = "sDisplay"
        listUniBlocks.ValueMember = "sKey"

        AddHandler listUniBlocks.SelectedValueChanged, AddressOf listUniBlocks_SelectedValueChanged
        AddHandler FontDialog1.Apply, AddressOf ApplyFont


        pUniBlockTemplate.Visible = False
        pCharTemplate.Visible = False

    End Sub
    Private Sub listUniBlocks_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If listUniBlocks.SelectedIndex <> -1 Then
            If listUniBlocks.SelectedValue.ToString() <> "" Then
                If selBlock <> listUniBlocks.SelectedValue.ToString() Then
                    selBlock = listUniBlocks.SelectedValue.ToString()
                    'selCPName.Text = CodePages.Item(listCP.SelectedIndex).Name
                    seBlockName.Text = CType(listUniBlocks.SelectedItem, UniBlock).sDisplay
                    If bBlockUpdating = False Then
                        bBlockUpdating = True
                        Me.Cursor = Cursors.WaitCursor
                        ProcBlocks(selBlock)
                        Me.Cursor = Cursors.Default
                        bBlockUpdating = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnSelfont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfont.Click
        SelectFont(FontDialog1)
    End Sub

    Private Sub UnicodeBlocks_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

    End Sub
    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        My.Application.OpenForms.Remove(oUnicodeBlocks)
    End Sub
End Class