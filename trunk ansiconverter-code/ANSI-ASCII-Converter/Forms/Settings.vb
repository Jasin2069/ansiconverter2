Public Class Settings
    Private lstPanels As New List(Of Windows.Forms.Panel)


    Friend Sub cbHTMLFontValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If MainFormLoaded = True And bUpdatingControls = False Then
            If cbHTMLFont.SelectedIndex <> -1 Then
                SelectedWebFont = cbHTMLFont.SelectedIndex
                If cbHTMLFont.SelectedValue <> "" Then
                    sHTMLFont = cbHTMLFont.SelectedValue
                    cbHTMLFont.Tag = sHTMLFont
                    cbHTMLFont.Text = sHTMLFont
                Else
                    cbHTMLFont.SelectedValue = sHTMLFont
                    cbHTMLFont.Tag = sHTMLFont
                    cbHTMLFont.Text = sHTMLFont
                End If
                ' If we also wanted to get the displayed text we could use
                ' the SelectedItem item property:
                ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
            Else
                sHTMLFont = "Default"
                cbHTMLFont.SelectedValue = "Default"
                cbHTMLFont.Text = "Default"
            End If
            UpdateControls()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        UpdateControls()
        Me.Close()
    End Sub


    Friend Sub btnSelfont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfont.Click
        SelectFont(FontDialog1)
    End Sub
    Private selectLbl As String = ""

    Public Shadows Function showdialog(ByVal selectLbl As String) As Windows.Forms.DialogResult
        Me.selectLbl = selectLbl
        Me.Visible = False
        Return MyBase.ShowDialog

    End Function
    Private Sub PaintControl(ByVal sender As Object, ByVal e As PaintEventArgs)
        If TypeOf sender Is Windows.Forms.Panel Then
            Dim p As Object = sender.parent
            If TypeOf p Is Windows.Forms.Panel Then
            Else
                If CType(sender, Windows.Forms.Panel).BorderStyle = BorderStyle.FixedSingle And CType(sender, Windows.Forms.Panel).ClientRectangle.Equals(e.ClipRectangle) Then
                    '                    If e.ClipRectangle.Width <> 448 Then
                    '                    Console.WriteLine(CType(sender, Windows.Forms.Panel).Name & "," & CType(sender, Windows.Forms.Panel).ClientRectangle.ToString & ";" & e.ClipRectangle.ToString)
                    'End If
                    Using b As New Drawing.Pen(New SolidBrush(Color.Yellow), 1)
                        e.Graphics.DrawRectangle(b, New Drawing.Rectangle(0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1))
                    End Using
                End If
            End If
        End If
    End Sub
    Public Shadows Function showdialog() As Windows.Forms.DialogResult
        Return Me.showdialog("")
    End Function
    Protected Overrides Sub OnActivated(e As System.EventArgs)

        If selectLbl = "" Then
            For a As Integer = 0 To Me.lstPanels.Count - 1
                Me.lstPanels.Item(a).Enabled = True
                Me.lstPanels.Item(a).BorderStyle = BorderStyle.None
                RemoveHandler Me.lstPanels.Item(a).Paint, AddressOf PaintControl
            Next
        Else
            For a As Integer = 0 To Me.lstPanels.Count - 1
                Me.lstPanels.Item(a).Enabled = False
                Me.lstPanels.Item(a).BorderStyle = BorderStyle.None
                RemoveHandler Me.lstPanels.Item(a).Paint, AddressOf PaintControl
            Next
            Select Case selectLbl.ToLower
                Case "settHTMLObj".ToLower
                    Me.pSettHTML.Enabled = True
                    Me.pHTMLObj.Enabled = True
                    Me.pSettHTML.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettHTML.Paint, AddressOf PaintControl
                Case "settAnim".ToLower
                    Me.pSettHTML.Enabled = True
                    Me.pAnim.Enabled = True
                    Me.pSettHTML.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettHTML.Paint, AddressOf PaintControl
                Case "settSanitize".ToLower
                    Me.pSettHTML.Enabled = True
                    Me.pSanitize.Enabled = True
                    Me.pSettHTML.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettHTML.Paint, AddressOf PaintControl
                Case "settHTMLFont".ToLower
                    Me.pSettHTML.Enabled = True
                    Me.pHTMLFont.Enabled = True
                    Me.pSettHTML.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettHTML.Paint, AddressOf PaintControl
                Case "settUTF".ToLower
                    Me.pSettUnicode.Enabled = True
                    Me.pSettUnicode.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettUnicode.Paint, AddressOf PaintControl
                Case "settNoCols".ToLower
                    Me.pSettImage.Enabled = True
                    Me.pNoCols.Enabled = True
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettImage.Paint, AddressOf PaintControl
                Case "settSMALLFNT".ToLower
                    Me.pSettImage.Enabled = True
                    Me.pSmallFnt.Enabled = True
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettImage.Paint, AddressOf PaintControl
                Case "attCreTh".ToLower
                    Me.pSettImage.Enabled = True
                    Me.pThumb.Enabled = True
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettImage.Paint, AddressOf PaintControl
                Case "settImgOut".ToLower
                    Me.pSettImage.Enabled = True
                    Me.pIMGOut.Enabled = True
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettImage.Paint, AddressOf PaintControl
                Case "settThumbs".ToLower
                    pSettImage.Enabled = True
                    pThumbs.Enabled = True
                    pThumb.Enabled = True
                    Me.pSettImage.BorderStyle = BorderStyle.FixedSingle
                    Me.pThumbs.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettImage.Paint, AddressOf PaintControl
                    AddHandler Me.pThumbs.Paint, AddressOf PaintControl
                Case "settGen".ToLower
                    Me.pSettInpFileList.Enabled = True
                    Me.pSettInpFileList.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pSettInpFileList.Paint, AddressOf PaintControl
                Case "settSauce".ToLower
                    Me.pGeneral.Enabled = True
                    Me.pSauce.Enabled = True
                    Me.pGeneral.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pGeneral.Paint, AddressOf PaintControl
                Case "settBBS".ToLower
                    Me.pBBS.Enabled = True
                    Me.pBBS.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pBBS.Paint, AddressOf PaintControl
                Case "settExist".ToLower
                    Me.pGeneral.Enabled = True
                    Me.pOutExist.Enabled = True
                    Me.pGeneral.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pGeneral.Paint, AddressOf PaintControl
                Case "settExt".ToLower
                    Me.pGeneral.Enabled = True
                    Me.pExt.Enabled = True
                    Me.pGeneral.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pGeneral.Paint, AddressOf PaintControl
                Case "settVideo".ToLower
                    Me.pVideo.Enabled = True
                    Me.pVideo.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pVideo.Paint, AddressOf PaintControl
                Case "settVidFmt".ToLower, "settVidCodec".ToLower
                    Me.pVideoOutFormats.Enabled = True
                    Me.pAVICodec.Enabled = True
                    Me.pMPGCodec.Enabled = True
                    Me.pVideoOutFormats.BorderStyle = BorderStyle.FixedSingle
                    Me.pAVICodec.BorderStyle = BorderStyle.FixedSingle
                    Me.pMPGCodec.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pVideoOutFormats.Paint, AddressOf PaintControl
                    AddHandler Me.pAVICodec.Paint, AddressOf PaintControl
                    AddHandler Me.pMPGCodec.Paint, AddressOf PaintControl
                Case "settLFExt".ToLower
                    Me.pLFrame.Enabled = True
                    Me.pLFrame.BorderStyle = BorderStyle.FixedSingle
                    AddHandler Me.pLFrame.Paint, AddressOf PaintControl
            End Select
        End If

        MyBase.OnActivated(e)
        Me.ResumeLayout(True)
        Me.Visible = True
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.StandardDoubleClick, False)
        Me.UpdateStyles()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"

        lstPanels.Add(Me.pGeneral)

        lstPanels.Add(Me.pSauce)
        lstPanels.Add(Me.pOutExist)
        lstPanels.Add(Me.pExt)

        lstPanels.Add(Me.pBBS)
        lstPanels.Add(Me.pSettFont)
        lstPanels.Add(Me.pVideo)
        lstPanels.Add(Me.pLFrame)
        lstPanels.Add(Me.pSettUnicode)
        lstPanels.Add(Me.pSettInpFileList)
        lstPanels.Add(Me.pSettHTML)

        lstPanels.Add(Me.pSanitize)
        lstPanels.Add(Me.pHTMLFont)
        lstPanels.Add(Me.pAnim)
        lstPanels.Add(Me.pHTMLObj)

        lstPanels.Add(Me.pThumbs)
        lstPanels.Add(Me.pSettImage)


        lstPanels.Add(Me.pNoCols)
        lstPanels.Add(Me.pSmallFnt)
        lstPanels.Add(Me.pThumb)
        lstPanels.Add(Me.pIMGOut)

        lstPanels.Add(Me.pAVICodec)
        lstPanels.Add(Me.pMPGCodec)
        lstPanels.Add(Me.pVideoOutFormats)

    End Sub
    Public Sub ControlUpdate2(ByVal sender As System.Object, ByVal bool As Boolean)
        'UpdateControls()
        oMainForm.ControlUpdate2(sender, bool)
    End Sub
    Public Sub ControlUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oMainForm.ControlUpdate(sender, e)
    End Sub

    Public Sub ExtUpd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.checked = True Then
            Dim item As Windows.Forms.RadioButton = sender
            Dim iFound As Integer = ListOutExtTrig.FindIndex(Function(x) item.Equals(x))
            If iFound >= 0 Then
                Dim ReqOut As String = ListOutExtReqOutSet.Item(iFound)
                Dim iOut As Integer = ListOut.FindIndex(Function(x) ReqOut.Equals(x.Tag.ToString))
                If iOut >= 0 Then
                    Dim out As Windows.Forms.RadioButton = ListOut.Item(iOut)
                    Dim iHTML As Integer = ListOutExtTrig.FindIndex(Function(x) out.Equals(x))
                    If iHTML >= 0 Then
                        ListOutExt.Item(iHTML) = ListOutExt.Item(iFound)
                    End If
                End If
            End If
        End If
    End Sub
    Friend Sub txtFPS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If IsNumeric(sender.text) Then
            FPS = sender.Text
            UpdateControls()
        End If
    End Sub
    Friend Sub txtBPS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsNumeric(sender.text) Then
            BPS = sender.Text
            UpdateControls()
        End If
    End Sub
    Friend Sub txtLastFrame_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsNumeric(sender.text) Then
            LastFrame = sender.Text
            UpdateControls()
        End If
    End Sub

    Private Sub Thumb_CheckedChanged(sender As System.Object, bChecked As Boolean) Handles Thumb.CheckedChanged
        If bChecked Then
            pThumbs.Visible = True
        Else
            pThumbs.Visible = False
        End If
    End Sub
End Class