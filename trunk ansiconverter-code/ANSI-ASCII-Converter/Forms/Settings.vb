Public Class Settings


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


    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSelFont.Text = selectedFont.Name & " (" & selectedFont.Size.ToString & " " & selectedFont.Unit.ToString & ")"

    End Sub
    Public Sub ControlUpdate2(ByVal sender As System.Object, ByVal bool As Boolean)
        'UpdateControls()
        MainForm.ControlUpdate2(sender, bool)
    End Sub
    Public Sub ControlUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.ControlUpdate(sender, e)
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
End Class