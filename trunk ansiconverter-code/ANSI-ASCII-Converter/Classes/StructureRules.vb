Module StructureRules

    Public Sub InputRuleCheck()
        Dim a As Integer
        Dim bCheckRes(ListIn2.Count) As Boolean
        For a = 1 To ListIn2.Count
            bCheckRes(a) = True
            'ListIn2.Item(a - 1).Enabled = True
        Next
        bCheckRes(0) = False
        Dim bPanVis As Boolean = False
        For a = 0 To ListIn2.Count - 1
            If ListIn2.Item(a).Checked = True Then
                If ListInCPVis.Item(a) = True Then
                    bCheckRes(0) = True
                End If
                bCheckRes(a + 1) = False
                ListIn2.Item(a).Font = New Drawing.Font(ListIn2.Item(a).Font.FontFamily, ListIn2.Item(a).Font.Size, FontStyle.Bold)
            Else
                ListIn2.Item(a).Font = New Drawing.Font(ListIn2.Item(a).Font.FontFamily, ListIn2.Item(a).Font.Size, FontStyle.Regular)
            End If
        Next
        For a = 1 To ListIn2.Count
            If bCheckRes(a) = True Then
                bPanVis = True
            Else
                'ListOut.Item(a - 1).Checked = False
            End If
            'ListOut.Item(a - 1).Visible = bCheckRes(a)

            'ListIn2.Item(a - 1).Enabled = False
        Next
        MainForm.pOut.Visible = True
        MainForm.pCPin.Visible = bCheckRes(0)

    End Sub

    Public Structure OutputRulez
        Public outChecked As Integer
        Public CPoutVis As Boolean
        Public outOBJVis As Boolean
        Public outSANVis As Boolean
        Public outENCVis As Boolean
        Public outANMVis As Boolean
        Public outNOCVis As Boolean
        Public outSMFVis As Boolean
        Public outTMBVis As Boolean
        Public outAVIVis As Boolean
        Private Sub Init()
            outChecked = -1 : CPoutVis = False : outOBJVis = False
            outSANVis = False : outENCVis = False : outNOCVis = False : outSMFVis = False : outTMBVis = False
        End Sub
        Public Sub New(ByVal outChk As Integer)
            Call Me.Init()
            outChecked = outChk
        End Sub

        Public Sub New(ByVal outChk As Integer, ByVal CP As Boolean, ByVal OBJ As Boolean, ByVal SAN As Boolean, ByVal ENC As Boolean, ByVal ANM As Boolean, ByVal NOC As Boolean, ByVal SMF As Boolean, ByVal TMB As Boolean)
            Call Me.Init()
            outChecked = outChk : CPoutVis = CP : outOBJVis = OBJ
            outSANVis = SAN : outENCVis = ENC : outANMVis = ANM : outNOCVis = NOC : outSMFVis = SMF : outTMBVis = TMB
        End Sub
        Public Sub ExecRule()
            If CPoutVis = False Then
                MainForm.pCPout.Visible = False
            Else
                If MainForm.pCPin.Visible = False Then
                    MainForm.pCPout.Visible = True
                Else
                    MainForm.pCPout.Visible = False
                    MainForm.pCPin.Visible = False
                End If
            End If
            '            MainForm.pCPout.Visible = (CPoutVis Or MainForm.pCPin.Visible) And Not MainForm.pCPin.Visible

            ' MainForm.pHTMLObj.Visible = outOBJVis
            ' MainForm.pSanitize.Visible = outSANVis
            ' MainForm.pUTF.Visible = outENCVis
            ' MainForm.pAnim.Visible = outANMVis
            ' MainForm.pNoCols.Visible = outNOCVis
            ' MainForm.pSmallFnt.Visible = outSMFVis
            ' MainForm.pThumb.Visible = outTMBVis
        End Sub
    End Structure


    Public OutputRulezList As New List(Of OutputRulez)

    Public Sub InitRulez()
        'inChk, inCP, ASC,ANS,HTM,UTF,PCB,BIN,IMG,PAN
        OutputRulezList.Add(New OutputRulez(0, True, False, False, False, False, False, False, False))
        OutputRulezList.Add(New OutputRulez(1, True, False, False, False, False, False, False, False))
        OutputRulezList.Add(New OutputRulez(2, False, True, True, False, True, False, False, False))
        OutputRulezList.Add(New OutputRulez(3, False, False, False, True, False, False, False, False))
        OutputRulezList.Add(New OutputRulez(4, True, False, False, False, False, False, False, False))
        OutputRulezList.Add(New OutputRulez(5, True, False, False, False, False, False, False, False))
        OutputRulezList.Add(New OutputRulez(6, False, False, False, False, False, True, True, True))
        OutputRulezList.Add(New OutputRulez(-1, False, False, False, False, False, False, False, False))

    End Sub


    Public Sub CheckOutputRule(ByVal iChk As Integer)
        For x As Integer = 0 To OutputRulezList.Count - 1
            If OutputRulezList.Item(x).outChecked = iChk Then
                OutputRulezList.Item(x).ExecRule()
            End If
        Next
    End Sub
End Module
