


Public Module ReplicateControls
    Friend TmpC As Control = Nothing
    Friend TmpRect As New Drawing.Rectangle
    Friend TmpP As Control = Nothing
    Friend TmpIdx As Integer = -1

    Public Sub ShowUpdateControl(ByVal sender As Object, ByVal e As EventArgs)
        If Not TmpC Is Nothing Then
            TmpC.Dispose()
            System.Windows.Forms.Application.DoEvents()
        End If
        If Not TmpP Is Nothing Then
            TmpP.Dispose()
            System.Windows.Forms.Application.DoEvents()
        End If
        Dim iFound As Integer = ListSettLabels.FindIndex(Function(x) sender.Equals(x))
        If iFound >= 0 Then
            TmpIdx = iFound : TmpP = ListSettPanels.Item(iFound)
        Else
            TmpIdx = -1 : TmpP = Nothing
        End If
        If Not TmpP Is Nothing Then
            TmpC = CloneControl(TmpP, oMainForm)
            TmpC.Visible = True
            TmpC.BringToFront()
            For Each subc As Control In TmpC.Controls
                Select Case subc.GetType().ToString
                    Case "System.Windows.Forms.RadioButton"
                        AddHandler subc.Click, AddressOf TmpRadioUpdate
                    Case "MyControls.OnOffInputControlSmall"
                        AddHandler CType(subc, MyControls.OnOffInputControlSmall).CheckedChanged, AddressOf TmpOnOffUpdate
                End Select
            Next
            Dim posadj As New Point
            AddHandler TmpC.MouseLeave, AddressOf TempControlClose
            'sender.FindForm.Controls.add(TmpC)
            TmpC.BackColor = Color.Black
            TmpC.BringToFront()
            TmpC.Location = Control2TopFormPosition(sender)
            If posadj.X <> 0 Then : TmpC.Left += posadj.X : End If
            If posadj.Y <> 0 Then : TmpC.Top += posadj.Y : End If
            TmpRect = New Drawing.Rectangle(TmpC.Location.X, TmpC.Location.Y, TmpC.Width, TmpC.Height)
            TmpC.Visible = True
            TmpC.BringToFront()
            System.Windows.Forms.Application.DoEvents()
            TmpC.Focus()
        End If
    End Sub
    Public Sub TmpOnOffUpdate(ByVal sender As Object, ByVal b As Boolean)
        oMainForm.ControlUpdate2(ControlByName(sender.name, Settings), b)
        TmpC.Visible = False : TmpC.Dispose() : TmpP.Dispose()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Public Sub TmpRadioUpdate(ByVal sender As Object, ByVal e As EventArgs)
        oMainForm.ControlUpdate(ControlByName(sender.name, Settings), e)
        TmpC.Visible = False : TmpC.Dispose() : TmpP.Dispose()
        System.Windows.Forms.Application.DoEvents()
    End Sub


    Public Sub TempControlClose(ByVal sender As Object, ByVal e As EventArgs)
        If CursorInRectangle(CType(sender, Control).FindForm.PointToClient(Cursor.Position), TmpRect) = False Then
            TmpC.Visible = False : TmpC.Dispose() : TmpP.Dispose()
            System.Windows.Forms.Application.DoEvents()
        End If
    End Sub
    Function CursorInRectangle(ByVal p As Point, ByVal r As Drawing.Rectangle) As Boolean
        Console.WriteLine(p.ToString)
        If p.X >= r.Left And p.X <= r.Right And p.Y >= r.Top And p.Y <= r.Bottom Then : Return True : Else : Return False : End If
    End Function
    Public Function Control2TopFormPosition(ByVal Ctl As Control) As Drawing.Point
        Dim topf As Windows.Forms.Form = Ctl.FindForm, curct As Control
        Dim bEnde As Boolean = False, iCnt As Integer = 0, pos As New Drawing.Point
        pos.X = Ctl.Location.X : pos.Y = Ctl.Location.Y : curct = Ctl.Parent
        If Not topf Is Nothing Then
            Do While bEnde = False
                If curct.Name = topf.Name Then
                    bEnde = True
                Else
                    iCnt += 1 : pos.X += curct.Location.X : pos.Y += curct.Location.Y : curct = curct.Parent
                End If
                If iCnt >= 50 Then : bEnde = True : End If
            Loop
        End If
        Return pos
    End Function


    Private Function CloneControl(ByVal Ctrl As Control, ByVal Parent As Object) As Control
        Try
            Dim CtrlType As Type = Ctrl.GetType()
            Dim CtrlObject As Object = Activator.CreateInstance(CtrlType)
            Dim CtrlNew As Control = CtrlObject

            Dim pdcCtrl As System.ComponentModel.PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(Ctrl)
            Dim pdcCtrlNew As System.ComponentModel.PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(CtrlNew)
            For i As Integer = 0 To pdcCtrl.Count - 1
                If pdcCtrl(i).Name = "Parent" Then
                    CtrlNew.Parent = Parent

                ElseIf pdcCtrl(i).Name = "Controls" Then
                    If Not Ctrl.Controls Is Nothing Then
                        For Each CtrlChild As Control In Ctrl.Controls
                            CtrlNew.Controls.Add(CloneControl(CtrlChild, CtrlNew))
                        Next
                    End If

                Else
                    pdcCtrlNew(i).SetValue(CtrlNew, pdcCtrl(i).GetValue(Ctrl))
                End If
            Next
            CtrlNew.Visible = True
            CtrlNew.BringToFront()
            Return CtrlNew

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
