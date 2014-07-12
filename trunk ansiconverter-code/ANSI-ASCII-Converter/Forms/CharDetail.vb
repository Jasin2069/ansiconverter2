Public Class CharDetail
    Private borderleft As New Windows.Forms.Label
    Private bordertop As New Windows.Forms.Label
    Private borderright As New Windows.Forms.Label
    Private borderbottom As New Windows.Forms.Label

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Controls.Add(borderleft)
        Me.Controls.Add(bordertop)
        Me.Controls.Add(borderright)
        Me.Controls.Add(borderbottom)

        borderleft.Text = ""
        borderleft.BackColor = Color.White
        borderleft.Width = 2
        borderleft.Height = Me.Height
        borderleft.Top = 0
        borderleft.Left = 0
        bordertop.Text = ""
        bordertop.BackColor = Color.Gainsboro
        bordertop.Height = 2
        bordertop.Width = Me.Width
        bordertop.Top = 0
        bordertop.Left = 0
        borderright.Text = ""
        borderright.BackColor = Color.Silver
        borderright.Width = 2
        borderright.Height = Me.Height
        borderright.Top = 0
        borderright.Left = Me.Width - 2
        borderbottom.Text = ""
        borderbottom.BackColor = Color.Gray
        borderbottom.Height = 2
        borderbottom.Width = Me.Width
        borderbottom.Top = Me.Height - 2
        borderbottom.Left = 0
        borderleft.BringToFront()
        borderright.BringToFront()
        bordertop.BringToFront()
        borderbottom.BringToFront()

    End Sub
    Public Sub New(ByVal UL As NL)
        Me.New()
        Dim bHas As Boolean = False
        'Dim bImg As System.Drawing.Bitmap
        Try
            lblCode.Text = Strings.Right(Space(10) & UL.Code, 6)

            lblHex.Text = Strings.Right("0000000000" & UL.CodeHex, 6)
            lblOct.Text = Strings.Right("0000000000" & UL.CodeOct, 6)
            lblBin.Text = Strings.Right("0000000000" & UL.CodeBin, 8)
            lblName.Text = UL.Name
            ToolTipAndEvents(lblName, UL.Name)

            'ToolTipAndEvents
            lblChar.Text = ChrW(UL.Code)
            lblAliaseslbl.Text = "Aliases (" & UL.Aliases.Count.ToString & "): "
            If UL.Aliases.Count > 0 Then
                lblAliases.Text = ""
                For a As Integer = 0 To UL.Aliases.Count - 1
                    lblAliases.Text &= UL.Aliases.Item(a) & vbCrLf
                Next
            Else
                lblAliases.Text = "N/A"
            End If
            lblSimilarLbl.Text = "Similar (" & UL.Similar.Count.ToString & "): "
            If UL.Similar.Count > 0 Then
                lblSimilar.Text = ""
                For a As Integer = 0 To UL.Similar.Count - 1
                    lblSimilar.Text &= UL.Similar.Item(a) & vbCrLf
                Next
            Else
                lblSimilar.Text = "N/A"
            End If
            lblNotesLbl.Text = "Notes (" & UL.Notes.Count.ToString & "): "
            If UL.Notes.Count > 0 Then
                lblNotes.Text = ""
                For a As Integer = 0 To UL.Notes.Count - 1
                    lblNotes.Text &= UL.Notes.Item(a) & vbCrLf
                Next
            Else
                lblNotes.Text = "N/A"
            End If
            '  bImg = UniCodeChar(UL.Code, bHas)
            'If bHas = True Then
            ' imgChar.Image = bImg
            ' imgChar.Visible = True
            ' Else
            imgChar.Image = Nothing
            imgChar.Visible = False
            'End If
            lblUTF8Hex.Text = hex2utf8(Hex(UL.Code))
            If lblUTF8Hex.Text.Length Mod 2 <> 0 Then
                lblUTF8Hex.Text = "0" & lblUTF8Hex.Text
            End If
            lblUTF8Bin.Text = ""
            For a As Integer = 1 To lblUTF8Hex.Text.Length - 1 Step 2
                lblUTF8Bin.Text &= Strings.Right("00000000" & Int2Bin(HexToDec(Strings.Mid(lblUTF8Hex.Text, a, 2))), 8)
                If a + 2 < lblUTF8Hex.Text.Length Then
                    lblUTF8Bin.Text &= ":"
                End If
            Next
            'lblUTF8Bin.Text = Int2Bin(HexToDec(lblUTF8Hex.Text))
            lblUTF16hex.Text = "FEFF" & Hex(UL.Code)
            lblUTF16be.Text = UniHex(UL.Code)
            lblUTF16le.Text = FlipHex(UniHex(UL.Code))
            lblJava.Text = """\u" & UniHex(UL.Code) & """"
            lblPy.Text = "u""\" & UniHex(UL.Code) & """"
            lblHTMLDec.Text = "&#" & UL.Code.ToString & ";"
            lblHTMLHex.Text = "&#x" & Hex(UL.Code) & ";"

        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub lblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.Click

    End Sub
End Class