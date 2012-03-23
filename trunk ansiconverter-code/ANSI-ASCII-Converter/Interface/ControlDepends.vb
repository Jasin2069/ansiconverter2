Public Class ControlDepends
    Private m_Trigger As Windows.Forms.Control
    Private m_TriggerProp As String
    Private m_TriggerValue As Object
    Private m_Target As Windows.Forms.Control
    Private m_TargetProp As String
    Private m_TargetValue As Object
    Private m_ExtraTrigger As Windows.Forms.Control
    Private m_ExtraTriggerProp As String
    Private m_ExtraTriggerValue As Object

    Public Property Trigger() As Windows.Forms.Control
        Get
            Return m_Trigger
        End Get
        Set(ByVal value As Windows.Forms.Control)
            m_Trigger = value
        End Set
    End Property
    Public Property TriggerProp() As String
        Get
            Return m_TriggerProp
        End Get
        Set(ByVal value As String)
            m_TriggerProp = value
        End Set
    End Property
    Public Property TriggerValue() As Object
        Get
            Return m_TriggerValue
        End Get
        Set(ByVal value As Object)
            m_TriggerValue = value
        End Set
    End Property

    Public Property ExtraTrigger() As Windows.Forms.Control
        Get
            Return m_ExtraTrigger
        End Get
        Set(ByVal value As Windows.Forms.Control)
            m_ExtraTrigger = value
        End Set
    End Property
    Public Property ExtraTriggerProp() As String
        Get
            Return m_ExtraTriggerProp
        End Get
        Set(ByVal value As String)
            m_ExtraTriggerProp = value
        End Set
    End Property
    Public Property ExtraTriggerValue() As Object
        Get
            Return m_ExtraTriggerValue
        End Get
        Set(ByVal value As Object)
            m_ExtraTriggerValue = value
        End Set
    End Property
    Public Property Target() As Windows.Forms.Control
        Get
            Return m_Trigger
        End Get
        Set(ByVal value As Windows.Forms.Control)
            m_Trigger = value
        End Set
    End Property
    Public Property TargetProp() As String
        Get
            Return m_TargetProp
        End Get
        Set(ByVal value As String)
            m_TargetProp = value
        End Set
    End Property
    Public Property TargetValue() As Object
        Get
            Return m_TargetValue
        End Get
        Set(ByVal value As Object)
            m_TargetValue = value
        End Set
    End Property

    Public Sub New(ByRef Trigger As Windows.Forms.Control, ByVal TriggerProp As String, ByVal TriggerValue As Object, _
                   ByRef ETrigger As Windows.Forms.Control, ByVal ETriggerProp As String, ByVal ETriggerValue As Object, _
                   ByRef Target As Windows.Forms.Control, ByVal TargetProp As String, ByVal Targetvalue As Object)
        m_Trigger = Trigger
        m_TriggerProp = TriggerProp
        m_TriggerValue = TriggerValue
        m_Target = Target
        m_TargetProp = TargetProp
        m_TargetValue = Targetvalue
        m_ExtraTrigger = ETrigger
        m_ExtraTriggerProp = ETriggerProp
        m_ExtraTriggerValue = ETriggerValue
    End Sub
    Public Sub New(ByRef Trigger As Windows.Forms.Control, ByVal TriggerProp As String, ByVal TriggerValue As Object, ByRef Target As Windows.Forms.Control, ByVal TargetProp As String, ByVal Targetvalue As Object)
        m_Trigger = Trigger
        m_TriggerProp = TriggerProp
        m_TriggerValue = TriggerValue
        m_Target = Target
        m_TargetProp = TargetProp
        m_TargetValue = Targetvalue
        m_ExtraTrigger = Nothing
        m_ExtraTriggerProp = ""
        m_ExtraTriggerValue = Nothing
    End Sub
    Public Sub New()
        m_Trigger = Nothing
        m_TriggerProp = ""
        m_TriggerValue = Nothing
        m_Target = Nothing
        m_TargetProp = ""
        m_TargetValue = Nothing
        m_ExtraTrigger = Nothing
        m_ExtraTriggerProp = ""
        m_ExtraTriggerValue = Nothing
    End Sub

    Public Sub CheckControl(ByRef C As Windows.Forms.Control)
        If m_Trigger.Equals(C) Then
            If m_TriggerValue.Equals(PropertyVal(C, m_TriggerProp)) Then
                If Not m_ExtraTrigger Is Nothing Then
                    If m_ExtraTriggerValue.Equals(PropertyVal(m_ExtraTrigger, m_ExtraTriggerProp)) Then
                        Call SetPropertyVal(m_Target, m_TargetProp, m_TargetValue)
                    End If
                Else
                    Call SetPropertyVal(m_Target, m_TargetProp, m_TargetValue)
                End If
            End If
        End If
    End Sub
    Private Function PropertyVal(ByRef c As Windows.Forms.Control, ByVal prop As String) As Object
        Dim Check As Windows.Forms.CheckBox
        Dim radio As Windows.Forms.RadioButton
        Dim Check2 As MyControls.OnOffInputControlSmall
        Select Case LCase(prop)
            Case "visible"
                Return c.Visible
            Case "text"
                Return c.Text
            Case "tag"
                Return c.Tag
            Case "checked"
                Select Case c.GetType().ToString
                    Case "System.Windows.Forms.RadioButton"
                        radio = CType(c, Windows.Forms.RadioButton)
                        Return radio.Checked
                    Case "System.Windows.Forms.CheckBox"
                        Check = CType(c, Windows.Forms.CheckBox)
                        Return Check.Checked
                    Case "MyControls.OnOffInputControlSmall"
                        Check2 = CType(c, MyControls.OnOffInputControlSmall)
                        Return Check2.Checked
                    Case Else
                        Check = CType(c, Windows.Forms.CheckBox)
                        Return Check.Checked
                End Select
            Case "enabled"
                Return c.Enabled
            Case "top"
                Return c.Top
            Case "left"
                Return c.Left
            Case "width"
                Return c.Width
            Case "height"
                Return c.Height
            Case "backcolor"
                Return c.BackColor
            Case "forecolor"
                Return c.ForeColor
            Case "font"
                Return c.Font
            Case Else
                Return Nothing
        End Select
    End Function
    Private Sub SetPropertyVal(ByRef c As Windows.Forms.Control, ByVal prop As String, ByVal val As Object)
        Dim Check As Windows.Forms.CheckBox
        Dim radio As Windows.Forms.RadioButton
        Dim Check2 As MyControls.OnOffInputControlSmall
        Select Case LCase(prop)
            Case "visible"
                c.Visible = val
            Case "text"
                c.Text = val
            Case "tag"
                c.Tag = val
            Case "checked"
                Select Case c.GetType().ToString
                    Case "System.Windows.Forms.RadioButton"
                        radio = CType(c, Windows.Forms.RadioButton)
                        radio.Checked = val
                    Case "System.Windows.Forms.CheckBox"
                        Check = CType(c, Windows.Forms.CheckBox)
                        Check.Checked = val
                    Case "MyControls.OnOffInputControlSmall"
                        Check2 = CType(c, MyControls.OnOffInputControlSmall)
                        Check2.Checked = val
                    Case Else
                        Check = CType(c, Windows.Forms.CheckBox)
                        Check.Checked = val
                End Select
            Case "enabled"
                c.Enabled = val
            Case "top"
                c.Top = val
            Case "left"
                c.Left = val
            Case "width"
                c.Width = val
            Case "height"
                c.Height = val
            Case "backcolor"
                c.BackColor = val
            Case "forecolor"
                c.ForeColor = val
            Case "font"
                c.Font = val
            Case Else
        End Select
    End Sub

End Class