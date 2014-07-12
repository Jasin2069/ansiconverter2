Imports System
Imports System.Globalization
Imports System.Collections
Imports System.Text

Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.CollectionEditor
Imports System.ComponentModel.Design.Serialization

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class FadingLabelPanel
    Inherits Windows.Forms.Panel
    Implements IContainer

#Region "Private Fields"
    Private _AutoEllipsis As System.Boolean = True
    Private _UseMnemonic As System.Boolean = True
    Private _TextAlign As System.Drawing.ContentAlignment = System.Drawing.ContentAlignment.MiddleLeft
    Private _TextRenderingHint As System.Drawing.Text.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
    Private _StringTrimming As System.Drawing.StringTrimming = System.Drawing.StringTrimming.EllipsisPath
    Private _HotKeyPrefix As System.Drawing.Text.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
    Private _StringFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat(StringFormatFlags.FitBlackBox + StringFormatFlags.NoWrap + StringFormatFlags.NoClip)
    Private _StringFormats As StringFormats = StringFormats.FitBlackBox
    Private _SmoothingMode As System.Drawing.Drawing2D.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
    Private _CompositingMode As System.Drawing.Drawing2D.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver
    Private _CompositingQuality As System.Drawing.Drawing2D.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
    Private _InterpolationMode As System.Drawing.Drawing2D.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

    Private _Size As System.Drawing.Size = New System.Drawing.Size(100, 20)
    Private _Radius As System.Int32 = 0
    Private _Borderwidth As System.Int32 = 1

    Private MyContentImage As System.Drawing.Image = Nothing
    Private FinalRenderImage As System.Drawing.Bitmap = Nothing
    Private tPoint As System.Drawing.Point = New System.Drawing.Point(0, 0)
    Private _Alpha As System.Int32 = 0
    Private _GrayScale As System.Boolean = False
    Private _Label As System.String = ""

    Private WithEvents _Timer As Windows.Forms.Timer = Nothing
    Private _Autofade As Boolean = True
    Private _Status As FadeFlag = FadeFlag.IDLE                'Var to keep track of which transition is going to take place (fade in or out)
    Private _StepSize As Integer = 4      'Var to hold the increment amount when increasing/decreasing the Opacity
    Private _Interval As Integer = 100
    Private _TimeWait As Integer = 1000
    Private _FadeEnabled As New Boolean           'Var used to enable or disable the fade in/out effect
    Private _EndTime As Long = 0
    Private _MakeMeTopMostFist As Boolean = True
    Private _AutoHide As Boolean = True

#End Region

#Region "Custom Enumerations"
    <FlagsAttribute()>
    Public Enum StringFormats
        None = 0
        DirectionRightToLeft = 1
        DirectionVertical = 2
        FitBlackBox = 4
        DisplayFormatControl = 32
        NoFontFallback = 1024
        MeasureTrailingSpaces = 2048
        NoWrap = 4096
        LineLimit = 8192
        NoClip = 16384
    End Enum

    <FlagsAttribute()>
    Public Enum FadeFlag                           'Enumeration for the current status of the window.
        IDLE = 0
        FADEIN = 1
        FADEOUT = 2
        PAUSE = 4
    End Enum
#End Region

#Region "Public Properties"

#Region "Fader Setting Properties"

    <Category("Fader Settings")> Public ReadOnly Property Status As FadeFlag
        Get
            Return _Status
        End Get
    End Property

    <DefaultValue(True)> _
    <Category("Fader Settings")> Public Property AutoFade As Boolean
        Get
            Return _Autofade
        End Get
        Set(ByVal value As Boolean)
            If Not _Autofade.Equals(value) Then
                _Autofade = value
            End If
        End Set
    End Property
    Public Function ShouldSerializeAutoFade() As Boolean
        If Me._Autofade = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetAutoFade()
        Me.AutoFade = True
    End Sub

    <DefaultValue(1000)> _
    <Category("Fader Settings")> Public Property TimeWait As Integer
        Get
            Return _TimeWait
        End Get
        Set(ByVal value As Integer)
            If Not _TimeWait.Equals(value) Then
                _TimeWait = value
            End If
        End Set
    End Property
    Public Function ShouldSerializeTimeWait() As Boolean
        If Me._TimeWait = 1000 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetTimeWait()
        Me.TimeWait = 1000
    End Sub

    <DefaultValue(100)> _
    <Category("Fader Settings")> Public Property Interval As Integer
        Get
            Return _Interval
        End Get
        Set(ByVal value As Integer)
            If Not _Interval.Equals(value) Then
                _Interval = value
                If Not _Timer Is Nothing Then
                    _Timer.Interval = _Interval
                End If
            End If
        End Set
    End Property
    Public Function ShouldSerializeInterval() As Boolean
        If Me._Interval = 100 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetInterval()
        Me.Interval = 100
    End Sub

    <DefaultValue(4)> _
    <Category("Fader Settings")> Public Property StepSize As Integer
        Get
            Return _StepSize
        End Get
        Set(ByVal value As Integer)
            If Not _StepSize.Equals(value) Then
                _StepSize = value
            End If
        End Set
    End Property
    Public Function ShouldSerializeStepSize() As Boolean
        If Me._StepSize = 4 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetStepSize()
        Me.StepSize = 4
    End Sub

    <DefaultValue(True)> _
    <Category("Fader Settings")> Public Property MakeMeTopMostFist As Boolean
        Get
            Return _MakeMeTopMostFist
        End Get
        Set(ByVal value As Boolean)
            If Not _MakeMeTopMostFist.Equals(value) Then
                _MakeMeTopMostFist = value
            End If
        End Set
    End Property
    Public Function ShouldSerializeMakeMeTopMostFist() As Boolean
        If Me._MakeMeTopMostFist = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetMakeMeTopMostFist()
        Me.MakeMeTopMostFist = True
    End Sub

    <DefaultValue(True)> _
    <Category("Fader Settings")> Public Property AutoHide As Boolean
        Get
            Return _AutoHide
        End Get
        Set(ByVal value As Boolean)
            If Not _AutoHide.Equals(value) Then
                _AutoHide = value
            End If
        End Set
    End Property
    Public Function ShouldSerializeAutoHide() As Boolean
        If Me._AutoHide = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetAutoHide()
        Me.AutoHide = True
    End Sub

#End Region

#Region "Text Rendering Properties"
    <DefaultValue("Text Here")> _
    <Category("Text Rendering")> Public Overloads Property Label As System.String
        Get
            Return _Label
        End Get
        Set(ByVal value As System.String)
            If Not _Label.Equals(value) Then
                _Label = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeLabel() As Boolean
        If Me._Label = "Text Here" Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetLabel()
        Me.Label = "Text Here"
    End Sub

    <DefaultValue(True)> _
    <Category("Text Rendering")> Public Property AutoEllipsis As System.Boolean
        Get
            Return _AutoEllipsis
        End Get
        Set(ByVal value As System.Boolean)
            If Not _AutoEllipsis.Equals(value) Then
                _AutoEllipsis = value
                If _AutoEllipsis And Me.StringTrimming <> System.Drawing.StringTrimming.EllipsisPath Then
                    Me.StringTrimming = System.Drawing.StringTrimming.EllipsisPath
                Else
                    Invalidate()
                End If
            End If
        End Set
    End Property
    Public Function ShouldSerializeAutoEllipsis() As Boolean
        If Me._AutoEllipsis = True Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetAutoEllipsis()
        Me.AutoEllipsis = True
    End Sub

    <DefaultValue(False)> _
    <Category("Text Rendering")> Public Property UseMnemonic As System.Boolean
        Get
            Return _UseMnemonic
        End Get
        Set(ByVal value As System.Boolean)
            If Not _UseMnemonic.Equals(value) Then
                _UseMnemonic = value
                If (_UseMnemonic And Me.ShowKeyboardCues And Me.HotKeyPrefix <> System.Drawing.Text.HotkeyPrefix.Show) Then
                    Me.HotKeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
                ElseIf (_UseMnemonic And Not Me.ShowKeyboardCues And Me.HotKeyPrefix <> System.Drawing.Text.HotkeyPrefix.Hide) Then
                    Me.HotKeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide
                ElseIf (Not _UseMnemonic And Me.HotKeyPrefix <> System.Drawing.Text.HotkeyPrefix.None) Then
                    Me.HotKeyPrefix = System.Drawing.Text.HotkeyPrefix.None
                Else
                    Invalidate()
                End If
            End If
        End Set
    End Property
    Public Function ShouldSerializeUseMnemonic() As Boolean
        If Me._UseMnemonic = False Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetUseMnemonic()
        Me.UseMnemonic = False
    End Sub

    <DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)> _
    <Category("Text Rendering")> Public Property TextAlign As System.Drawing.ContentAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As System.Drawing.ContentAlignment)
            If Not _TextAlign.Equals(value) Then
                _TextAlign = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeTextAlign() As Boolean
        If Me._TextAlign = ContentAlignment.MiddleCenter Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetTextAlign()
        Me.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    <DefaultValue(System.Drawing.Text.TextRenderingHint.AntiAlias)> _
    <Category("Text Rendering")> Public Property TextRenderingHint As System.Drawing.Text.TextRenderingHint
        Get
            Return _TextRenderingHint
        End Get
        Set(ByVal value As System.Drawing.Text.TextRenderingHint)
            If Not _TextRenderingHint.Equals(value) Then
                _TextRenderingHint = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeTextRenderingHint() As Boolean
        If Me._TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetTextRenderingHint()
        Me.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
    End Sub

    <DefaultValue(System.Drawing.StringTrimming.EllipsisPath)> _
    <Category("Text Rendering")> Public Property StringTrimming As System.Drawing.StringTrimming
        Get
            Return _StringTrimming
        End Get
        Set(ByVal value As System.Drawing.StringTrimming)
            If Not _StringTrimming.Equals(value) Then
                _StringTrimming = value
                If _StringTrimming = System.Drawing.StringTrimming.EllipsisPath And _AutoEllipsis <> True Then
                    Me.AutoEllipsis = True
                Else
                    Invalidate()
                End If
            End If
        End Set
    End Property
    Public Function ShouldSerializeStringTrimming() As Boolean
        If Me._StringTrimming = Drawing.StringTrimming.EllipsisPath Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetStringTrimming()
        Me.StringTrimming = Drawing.StringTrimming.EllipsisPath
    End Sub

    <DefaultValue(False)> _
    <Category("Text Rendering")> Public Property HotKeyPrefix As System.Drawing.Text.HotkeyPrefix
        Get
            Return _HotKeyPrefix
        End Get
        Set(ByVal value As System.Drawing.Text.HotkeyPrefix)
            If Not _HotKeyPrefix.Equals(value) Then
                _HotKeyPrefix = value
                If _HotKeyPrefix = System.Drawing.Text.HotkeyPrefix.None And Me.UseMnemonic Then
                    Me.UseMnemonic = False
                Else
                    Invalidate()
                End If
            End If
        End Set
    End Property
    Public Function ShouldSerializeHotKeyPrefix() As Boolean
        If Me._HotKeyPrefix = Drawing.Text.HotkeyPrefix.None Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetHotKeyPrefix()
        Me.HotKeyPrefix = Drawing.Text.HotkeyPrefix.None
    End Sub

    <DefaultValue(0)> _
    <Category("Text Rendering")> _
    <TypeConverter(GetType(StringFormatsConverter))> _
    <EditorAttribute(GetType(StringFormatsEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property StringFormat As StringFormats
        Get
            Return _StringFormats
        End Get
        Set(ByVal value As StringFormats)
            If Not _StringFormats.Equals(value) Then
                _StringFormats = value
                _StringFormat = New System.Drawing.StringFormat(_StringFormats)
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeStringFormat() As Boolean
        If Me._StringFormats = StringFormats.FitBlackBox Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetStringFormat()
        Me.StringFormat = StringFormats.FitBlackBox
    End Sub
#End Region

#Region "General Rendering Properties"

    <DefaultValue(System.Drawing.Drawing2D.SmoothingMode.AntiAlias)> _
    <Category("General Rendering")> Public Property SmoothingMode As System.Drawing.Drawing2D.SmoothingMode
        Get
            Return _SmoothingMode
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.SmoothingMode)
            If Not _SmoothingMode.Equals(value) Then
                _SmoothingMode = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeSmoothingMode() As Boolean
        If Me._SmoothingMode = Drawing2D.SmoothingMode.AntiAlias Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetSmoothingMode()
        Me.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    End Sub

    <DefaultValue(System.Drawing.Drawing2D.CompositingMode.SourceOver)> _
    <Category("General Rendering")> Public Property CompositingMode As System.Drawing.Drawing2D.CompositingMode
        Get
            Return _CompositingMode
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.CompositingMode)
            If Not _CompositingMode.Equals(value) Then
                _CompositingMode = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeCompositingMode() As Boolean
        If Me._CompositingMode = Drawing2D.CompositingMode.SourceOver Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetCompositingMode()
        Me.CompositingMode = Drawing2D.CompositingMode.SourceOver
    End Sub

    <DefaultValue(System.Drawing.Drawing2D.CompositingQuality.HighQuality)> _
    <Category("General Rendering")> Public Property CompositingQuality As System.Drawing.Drawing2D.CompositingQuality
        Get
            Return _CompositingQuality
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.CompositingQuality)
            If Not _CompositingQuality.Equals(value) Then
                _CompositingQuality = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeCompositingQuality() As Boolean
        If Me._CompositingQuality = Drawing2D.CompositingQuality.HighQuality Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetCompositingQuality()
        Me.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
    End Sub

    <DefaultValue(System.Drawing.Drawing2D.InterpolationMode.Default)> _
    <Category("General Rendering")> Public Property InterpolationMode As System.Drawing.Drawing2D.InterpolationMode
        Get
            Return _InterpolationMode
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.InterpolationMode)
            If Not _InterpolationMode.Equals(value) Then
                _InterpolationMode = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeInterpolationMode() As Boolean
        If Me._InterpolationMode = Drawing2D.InterpolationMode.Default Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetInterpolationMode()
        Me.InterpolationMode = Drawing2D.InterpolationMode.Default
    End Sub

    <DefaultValue(0)> _
    <Category("General Rendering")> Public Property Alpha As System.Int32
        Get
            Return _Alpha
        End Get
        Set(ByVal value As System.Int32)
            If Not _Alpha.Equals(value) Then
                _Alpha = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeAlpha() As Boolean
        If Me._Alpha = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetAlpha()
        Me.Alpha = 0
    End Sub

    <DefaultValue(False)> _
    <Category("General Rendering")> Public Property GrayScale As System.Boolean
        Get
            Return _GrayScale
        End Get
        Set(ByVal value As System.Boolean)
            If Not _GrayScale.Equals(value) Then
                _GrayScale = value
                Invalidate()
            End If
        End Set
    End Property
    Public Function ShouldSerializeGrayScale() As Boolean
        If Me._GrayScale = False Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetGrayScale()
        Me.GrayScale = False
    End Sub
#End Region

#Region "Appearance Setting Properties"

    <Category("Appearance")> Public Shadows Property Size As System.Drawing.Size
        Get
            Return Me._Size
        End Get
        Set(ByVal value As System.Drawing.Size)
            If Not Me._Size.Equals(value) Then
                Me._Size = value
                MyBase.Size = value
                Invalidate()
            End If
        End Set
    End Property
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Function ShouldSerializeSize() As Boolean
        If Me._Size.Equals(New Drawing.Point(100, 20)) Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Sub ResetSize()
        Me.Size = New Drawing.Point(100, 20)
    End Sub

    <DefaultValue(0), Category("Appearance")> Public Property Radius As System.Int32
        Get
            Return Me._Radius
        End Get
        Set(ByVal value As System.Int32)
            If Not Me._Radius.Equals(value) Then
                Me._Radius = value
                Invalidate()
            End If
        End Set
    End Property
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Function ShouldSerializeRadius() As Boolean
        If Me._Radius = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Sub ResetRadius()
        Me.Radius = 0
    End Sub
    <DefaultValue(1), Category("Appearance")> Public Property Borderwidth As System.Int32
        Get
            Return Me._Borderwidth
        End Get
        Set(ByVal value As System.Int32)
            If Not _Borderwidth.Equals(value) Then
                Me._Borderwidth = value
                Invalidate()
            End If
        End Set
    End Property
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Function ShouldSerializeBorderwidth() As Boolean
        If Me._Borderwidth = 1 Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Sub ResetBorderwidth()
        Me.Borderwidth = 1
    End Sub
    <Category("Appearance"), DefaultValue(True)> Public Property ShowFocus As Boolean
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Function ShouldSerializeShowFocus() As Boolean
        If Me._ShowFocus = False Then
            Return False
        Else
            Return True
        End If
    End Function
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Sub ResetShowFocus()
        Me.ShowFocus = False
    End Sub

#End Region

#Region "Other Properties"
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
    Public Overrides Property BackgroundImage As System.Drawing.Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(ByVal value As System.Drawing.Image)
            'MyBase.BackgroundImage = value
        End Set
    End Property
    Public Function ShouldSerializeBackgroundImage() As Boolean
        If Me.BackgroundImage Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub ResetBackgroundImage()
        Me.BackgroundImage = Nothing
    End Sub
#End Region

#End Region

#Region "Public Custom Events and Events Handlers"

    Public Delegate Sub FaderStart(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Delegate Sub FaderFinish(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Delegate Sub FaderPause(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Delegate Sub FaderContinue(ByVal myself As Object, ByVal bAutoFade As Boolean)

    Private FaderStarteventshandlers As New ArrayList()
    Private FaderFinisheventshandlers As New ArrayList()
    Private FaderPauseeventshandlers As New ArrayList()
    Private FaderContinueeventshandlers As New ArrayList()
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Custom Event FaderStarted As FaderStart
        AddHandler(ByVal value As FaderStart)
            FaderStarteventshandlers.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As FaderStart)
            FaderStarteventshandlers.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal myself As Object, ByVal bAutoFade As Boolean)
            For Each handler As FaderStart In FaderStarteventshandlers
                handler.Invoke(Me, bAutoFade)
            Next
        End RaiseEvent
    End Event
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Custom Event FaderFinished As FaderFinish
        AddHandler(ByVal value As FaderFinish)
            FaderFinisheventshandlers.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As FaderFinish)
            FaderFinisheventshandlers.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal myself As Object, ByVal bAutoFade As Boolean)
            For Each handler As FaderFinish In FaderFinisheventshandlers
                handler.Invoke(Me, bAutoFade)
            Next
        End RaiseEvent
    End Event
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Custom Event FaderPaused As FaderPause
        AddHandler(ByVal value As FaderPause)
            FaderPauseeventshandlers.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As FaderPause)
            FaderPauseeventshandlers.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal myself As Object, ByVal bAutoFade As Boolean)
            For Each handler As FaderPause In FaderPauseeventshandlers
                handler.Invoke(Me, bAutoFade)
            Next
        End RaiseEvent
    End Event
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Custom Event FaderContinued As FaderContinue
        AddHandler(ByVal value As FaderContinue)
            FaderContinueeventshandlers.Add(value)
        End AddHandler
        RemoveHandler(ByVal value As FaderContinue)
            FaderContinueeventshandlers.Remove(value)
        End RemoveHandler
        RaiseEvent(ByVal myself As Object, ByVal bAutoFade As Boolean)
            For Each handler As FaderContinue In FaderContinueeventshandlers
                handler.Invoke(Me, bAutoFade)
            Next
        End RaiseEvent
    End Event

#End Region

#Region "Public Constructor Methods"

    Public Sub New()
        MyBase.New()
        SetStyle(Windows.Forms.ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(Windows.Forms.ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(Windows.Forms.ControlStyles.ResizeRedraw, True)
        Me.BackColor = System.Drawing.Color.Transparent
        _Timer = New Windows.Forms.Timer
        _Timer.Enabled = False
        _Timer.Interval = _Interval
        AddHandler _Timer.Tick, AddressOf Fading

    End Sub

#End Region

    Private Sub MeLoading(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ControlAdded
        Me.Label = "test"
    End Sub

#Region "Internal Events Handlers"

    Private Sub Panel_FontChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Invalidate()
    End Sub

    Private Sub Panel_PaddingChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.PaddingChanged
        Invalidate()
    End Sub

    Private Sub Panel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        MyBase.Width = Me.Width
        MyBase.Height = Me.Height
        Invalidate()
    End Sub
    Private Sub Panel_ClientSizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ClientSizeChanged
        MyBase.Width = Me.Width
        MyBase.Height = Me.Height
        Invalidate()
    End Sub
    Private Sub Panel_ReSizeFinished(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Resize
        MyBase.Width = Me.Width
        MyBase.Height = Me.Height
        Invalidate()
    End Sub

#End Region

#Region "Fader Control Methods"

#Region "Public Fader Control Methods"

    Public Sub Fade()
        If _Status = FadeFlag.IDLE Then
            '_Alpha = 0

            If _Autofade = True Then
                Me.FadeIn()
            End If

        End If
    End Sub

    Public Sub FadeIn()
        If _Status = FadeFlag.IDLE Then
            If _MakeMeTopMostFist Then
                Me.BringToFront()
                Me.Visible = True
            End If
            _Status = FadeFlag.FADEIN
            _Timer.Enabled = True
            RaiseEvent FaderStarted(Me, _Autofade)
        End If
    End Sub

    Public Sub FadeOut()
        If _Status = FadeFlag.PAUSE Or (_Status = FadeFlag.IDLE And _Alpha > 0) Then
            If _MakeMeTopMostFist Then
                Me.BringToFront()
                Me.Visible = True
            End If
            _Status = FadeFlag.FADEOUT
            _Timer.Enabled = True
        Else
            If _Status = FadeFlag.FADEIN Then
                _TimeWait = 0
            End If
        End If
    End Sub

    Public Sub Abort()
        If _Status <> FadeFlag.IDLE Then
            _Status = FadeFlag.FADEOUT
            _Alpha = 0
            _EndTime = Environment.TickCount + _TimeWait
        End If
    End Sub

#End Region

#Region "Private Fader Control Methods"

    Private Sub Fading(ByVal Sender As System.Object, ByVal e As System.EventArgs)
        Select Case _Status
            Case FadeFlag.FADEIN
                _EndTime = 0
                'We know the status is set to "fade in". Increase the Opacity
                'Check the level of opacity
                If _Alpha = 255 Then
                    _Status = FadeFlag.PAUSE
                    _EndTime = Environment.TickCount + _TimeWait
                    RaiseEvent FaderPaused(Me, _Autofade)
                Else
                    _EndTime = 0
                    'Increase the opacity by specified amount
                    _Alpha = IIf(_Alpha + _StepSize > 255, 255, _Alpha + _StepSize)
                End If
                Invalidate()
            Case FadeFlag.FADEOUT

                'We know the status is set to "fade out". Decrease the Opacity
                'Check the level of opacity
                If _Alpha = 0 Then
                    'Shut the timer off.  Our work is done here.
                    _Timer.Enabled = False
                    'thePanel.Visible = True
                    _Alpha = 0

                    If _AutoHide Then
                        Me.SendToBack()
                        Me.Visible = False
                    End If

                    _Status = FadeFlag.IDLE

                    RaiseEvent FaderFinished(Me, _Autofade)
                    'Shut off the timer. Our work is done here
                    'FadeTimer.Enabled = False
                Else
                    _Alpha = IIf(_Alpha - _StepSize < 0, 0, _Alpha - _StepSize)
                End If
                Invalidate()
            Case FadeFlag.PAUSE

                If Environment.TickCount >= _EndTime And _EndTime <> 0 Then
                    If _Autofade = True Then
                        _Status = FadeFlag.FADEOUT
                        RaiseEvent FaderContinued(Me, _Autofade)
                    Else
                        _Timer.Enabled = False
                        _Status = FadeFlag.IDLE
                        RaiseEvent FaderFinished(Me, _Autofade)
                    End If
                End If
            Case FadeFlag.IDLE
        End Select
    End Sub

#End Region

#End Region

#Region "Control Rendering Private Methods"


    Private Sub Painting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Me.SmoothingMode 'System.Drawing.Drawing2D.SmoothingMode.HighQuality
        e.Graphics.CompositingMode = Me.CompositingMode ' System.Drawing.Drawing2D.CompositingMode.SourceOver
        e.Graphics.CompositingQuality = Me.CompositingQuality ' System.Drawing.Drawing2D.CompositingQuality.HighQuality 'System.Drawing.Drawing2D.CompositingQuality.HighSpeed
        e.Graphics.InterpolationMode = Me.InterpolationMode 'System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic 'System.Drawing.Drawing2D.InterpolationMode.Default

        'Prepare Rendering Content to Image
        FinalRenderImage = New System.Drawing.Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(FinalRenderImage)

        Dim layout_rect As System.Drawing.RectangleF
        Dim pos_rect As System.Drawing.Rectangle

        '        If MyContentImage Is Nothing Then



        Dim the_font As System.Drawing.Font = Me.Font
        Dim sDisplayText As System.String = System.String.Copy(Me._Label)
        Dim sRenderText As System.String = ""
        Dim string_format As System.Drawing.StringFormat = GetStringFormat(Me.TextAlign)
        string_format.Trimming = Me.StringTrimming 'System.Drawing.StringTrimming.EllipsisPath
        'string_format.HotkeyPrefix = Me.HotKeyPrefix
        If (Me.UseMnemonic) And (MyBase.ShowKeyboardCues) Then
            string_format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
        ElseIf (Me.UseMnemonic) And (Not MyBase.ShowKeyboardCues) Then
            string_format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide
        Else
            string_format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None
        End If

        Dim brBrush As Brush
        Dim rcClient As Rectangle = New Rectangle(Me.Padding.Left, Me.Padding.Top, Me.Width - Me.Padding.Right - Me.Padding.Left, Me.Height - Me.Padding.Bottom - Me.Padding.Top)

        Dim cwa As ColorWithAlpha = New ColorWithAlpha()
        cwa.Alpha = 0
        cwa.Color = Me.BackColor
        cwa.Parent = Me.Parent
        brBrush = New SolidBrush(Color.FromArgb(cwa.Alpha, cwa.Color.R, cwa.Color.G, cwa.Color.B))

        e.Graphics.TextRenderingHint = Me.TextRenderingHint 'System.Drawing.Text.TextRenderingHint.AntiAliasGridFit

        layout_rect = Me.DisplayRectangle
        pos_rect = Me.DisplayRectangle

        g.FillRectangle(brBrush, layout_rect)
        ' p = Me.Parent.PointToScreen(Me.Location)
        Try


            'Create Graphics for Text Formating Details Pre-Determination
            'Try
            '  g = MyBase.CreateGraphics
            '   'g = e.Graphics
            'Catch ex As System.Exception
            '  img = New System.Drawing.Bitmap(System.Convert.ToUInt16(layout_rect.Width), System.Convert.ToUInt16(layout_rect.Height))
            '   g = System.Drawing.Graphics.FromImage(img)
            'End Try

            g.TextRenderingHint = Me.TextRenderingHint

            tPoint.Y = 0
            tPoint.X = 0

            ' Correction for ShowFocus
            Dim ctlCorr As System.Int32 = IIf(Me._ShowFocus, 1, 0)

            ' Correction for curvature
            Dim _c As System.Int32 = Me._Radius / 4

            ' Define the inner boundaries for text and image placement
            Dim ctlTop As System.Int32 = Me._Borderwidth + ctlCorr + _c
            Dim ctlLeft As System.Int32 = Me._Borderwidth + ctlCorr + _c
            Dim ctlWidth As System.Int32 = Me.Width - 2 * (Me._Borderwidth + ctlCorr) - 1
            Dim ctlHeight As System.Int32 = Me.Height - 2 * (Me._Borderwidth + ctlCorr) + ctlCorr - 1

            Dim newRect As New System.Drawing.Rectangle(ctlLeft, ctlTop, ctlWidth, ctlHeight)
            Dim textSize As System.Drawing.SizeF
            Dim ampSize As System.Drawing.SizeF

            Dim sEllipsisValue As System.String = System.String.Copy(sDisplayText)

            If (sDisplayText.Length > 0) Then


                sEllipsisValue = String.Copy(sDisplayText)
                Dim iOut1 As Integer = 0, iOut2 As Integer = 0

                'Dim ores = System.Windows.Forms.TextRenderer.MeasureText(sEllipsisValue, the_font, New System.Drawing.Size(newRect.Width, newRect.Height), _StringFormat, iOut1, iOut2) 'string_format.FormatFlags
                textSize = g.MeasureString(sEllipsisValue, the_font, New System.Drawing.Size(newRect.Width, newRect.Height), _StringFormat, iOut1, iOut2) 'string_format.FormatFlags
                'MeasureString
                If (sEllipsisValue.IndexOf("\0") >= 0) Then
                    sRenderText = sEllipsisValue.Substring(0, sEllipsisValue.IndexOf("\0"))
                Else
                    sRenderText = sEllipsisValue
                End If
                '                System.Windows.Forms.TextRenderer.MeasureText(sEllipsisValue, MyBase.Font, New System.Drawing.Size(Convert.ToInt32(newRect.Width), Convert.ToInt32(newRect.Height)), TextFormatFlags.NoClipping Or TextFormatFlags.Default) 'string_format.FormatFlags
                'Dim ores = System.Windows.Forms.TextRenderer.MeasureText(
                'textSize = g.MeasureString(sRenderText, Me.Font, newRect.Width)
                'Dim dc As New System.Drawing.
                'System.Drawing.StringFormatFlags
                'System.Windows.Forms.TextFormatFlags
                If (Me.UseMnemonic) Then
                    Dim ampPosition As System.Int32 = sRenderText.IndexOf("&")
                    If (ampPosition > -1 And ampPosition < sRenderText.Length) Then
                        ampSize = g.MeasureString("&", Me.Font, newRect.Width)
                    Else
                        ampSize = New System.Drawing.SizeF(0.0, 0.0)
                    End If
                Else
                    ampSize = New System.Drawing.SizeF(0.0, 0.0)
                End If
                If Me.DesignMode Then

                End If
                Select Case Me.TextAlign
                    Case System.Drawing.ContentAlignment.BottomCenter
                        string_format.LineAlignment = StringAlignment.Far
                        string_format.Alignment = StringAlignment.Center
                    Case System.Drawing.ContentAlignment.BottomLeft
                        string_format.LineAlignment = StringAlignment.Far
                        string_format.Alignment = StringAlignment.Near
                    Case System.Drawing.ContentAlignment.BottomRight
                        string_format.LineAlignment = StringAlignment.Far
                        string_format.Alignment = StringAlignment.Far
                    Case System.Drawing.ContentAlignment.MiddleCenter
                        string_format.LineAlignment = StringAlignment.Center
                        string_format.Alignment = StringAlignment.Center
                    Case System.Drawing.ContentAlignment.MiddleLeft
                        string_format.LineAlignment = StringAlignment.Center
                        string_format.Alignment = StringAlignment.Near
                    Case System.Drawing.ContentAlignment.MiddleRight
                        string_format.LineAlignment = StringAlignment.Center
                        string_format.Alignment = StringAlignment.Far
                    Case System.Drawing.ContentAlignment.TopCenter
                        string_format.LineAlignment = StringAlignment.Near
                        string_format.Alignment = StringAlignment.Center
                    Case System.Drawing.ContentAlignment.TopLeft
                        string_format.LineAlignment = StringAlignment.Near
                        string_format.Alignment = StringAlignment.Near
                    Case System.Drawing.ContentAlignment.TopRight
                        string_format.LineAlignment = StringAlignment.Near
                        string_format.Alignment = StringAlignment.Far
                End Select
                'string_format.LineAlignment = StringAlignment.Far
                Select Case Me.TextAlign
                    Case System.Drawing.ContentAlignment.BottomCenter
                        tPoint.Y = ctlTop - _c + (ctlHeight - System.Math.Floor(textSize.Height)) - ctlCorr
                        tPoint.X = ctlLeft - _c + (CDbl(ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width)) / 2)
                    Case System.Drawing.ContentAlignment.BottomLeft
                        tPoint.Y = ctlTop - _c + (ctlHeight - System.Math.Floor(textSize.Height)) - ctlCorr
                        tPoint.X = ctlLeft
                    Case System.Drawing.ContentAlignment.BottomRight
                        tPoint.Y = ctlTop - _c + (ctlHeight - System.Math.Floor(textSize.Height)) - ctlCorr
                        tPoint.X = ctlLeft + (ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width))
                    Case System.Drawing.ContentAlignment.MiddleCenter
                        tPoint.Y = ctlTop - _c + (CDbl(ctlHeight - System.Math.Floor(textSize.Height)) / 2)
                        tPoint.X = ctlLeft - _c + (CDbl(ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width)) / 2)
                    Case System.Drawing.ContentAlignment.MiddleLeft
                        tPoint.Y = ctlTop - _c + (CDbl(ctlHeight - System.Math.Floor(textSize.Height)) / 2)
                        tPoint.X = ctlLeft
                    Case System.Drawing.ContentAlignment.MiddleRight
                        tPoint.Y = ctlTop - _c + (CDbl(ctlHeight - System.Math.Floor(textSize.Height)) / 2)
                        tPoint.X = ctlLeft + (ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width))
                    Case System.Drawing.ContentAlignment.TopCenter
                        tPoint.Y = ctlTop - _c
                        tPoint.X = ctlLeft - _c + (CDbl(ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width)) / 2)
                    Case System.Drawing.ContentAlignment.TopLeft
                        tPoint.Y = ctlTop - _c
                        tPoint.X = ctlLeft
                    Case System.Drawing.ContentAlignment.TopRight
                        tPoint.Y = ctlTop
                        tPoint.X = ctlLeft + (ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width))
                    Case Else
                        tPoint.Y = ctlTop - _c + (CDbl(ctlHeight - System.Math.Floor(textSize.Height)) / 2)
                        tPoint.X = ctlLeft - _c + (CDbl(ctlWidth - System.Math.Floor(textSize.Width - ampSize.Width)) / 2)
                End Select
            End If

            'TextFormatFlags.ModifyString Or TextFormatFlags.PathEllipsis

            'g.Dispose()
            ' g.DrawString(sRenderText, the_font, New System.Drawing.SolidBrush(Me.ForeColor), tPoint, string_format)
            g.DrawString(sRenderText, the_font, New System.Drawing.SolidBrush(Me.ForeColor), e.ClipRectangle, string_format)

            g.Dispose()
        Catch ex As Exception
#If DEBUG Then
            Console.WriteLine("FadingLabelPanel Error. Unable to Render Text")
#End If
        End Try
        'e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(layout_rect))
        'Else
        Dim ms As New System.IO.MemoryStream
        ''Save Bitmap to Memory Stream
        FinalRenderImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        ''Create Image from Stream
        MyContentImage = System.Drawing.Image.FromStream(ms)
        ms.Dispose()
        'If _Alpha <> 100 And Not _GrayScale Then


        Try

            'Adjust Alpha
            Dim btBitmap As System.Drawing.Bitmap = MyContentImage

            Dim bm As System.Drawing.Bitmap = New System.Drawing.Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
            g = System.Drawing.Graphics.FromImage(bm)

            Dim arArray As System.Single()() = {New System.Single() {1, 0, 0, 0, 0}, New System.Single() {0, 1, 0, 0, 0}, New System.Single() {0, 0, 1, 0, 0}, New System.Single() {0, 0, 0, CSng(_Alpha / 100), 0}, New System.Single() {0, 0, 0, 0, 1}}

            Dim clrMatrix As System.Drawing.Imaging.ColorMatrix
            If _GrayScale Then
                clrMatrix = New System.Drawing.Imaging.ColorMatrix(New System.Single()() _
                       {New System.Single() {0.299, 0.299, 0.299, 0, 0}, _
                        New System.Single() {0.587, 0.587, 0.587, 0, 0}, _
                        New System.Single() {0.114, 0.114, 0.114, 0, 0}, _
                        New System.Single() {0, 0, 0, CSng(_Alpha / 100), 0}, _
                        New System.Single() {0, 0, 0, 0, 1}})
            Else
                clrMatrix = New System.Drawing.Imaging.ColorMatrix(New System.Single()() _
                       {New System.Single() {1, 0, 0, 0, 0}, _
                        New System.Single() {0, 1, 0, 0, 0}, _
                        New System.Single() {0, 0, 1, 0, 0}, _
                        New System.Single() {0, 0, 0, CSng(_Alpha / 100), 0}, _
                        New System.Single() {0, 0, 0, 0, 1}})
            End If

            Dim imgAttributes As New System.Drawing.Imaging.ImageAttributes()

            imgAttributes.SetColorMatrix(clrMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap)


            g.DrawImage(btBitmap, pos_rect, 0, 0, btBitmap.Width, btBitmap.Height, System.Drawing.GraphicsUnit.Pixel, imgAttributes)


            btBitmap.Dispose()
            'FinalRenderImage
            g.Dispose()

            e.Graphics.DrawImageUnscaled(bm, New System.Drawing.Point(0, 0))

            ms = New System.IO.MemoryStream
            ''Save Bitmap to Memory Stream
            bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ''Create Image from Stream
            MyContentImage = System.Drawing.Image.FromStream(ms)
            ms.Dispose()

        Catch ex As Exception
#If DEBUG Then
            Console.WriteLine("FadingLabelPanel Error. Unable to Render Image with Alpha Settings")
#End If
        End Try

        'End If
        'End If
        e.Dispose()

    End Sub


    Protected Overloads Sub MyInvalidation() ' Handles Me.Invalidated
        MyBase.Invalidate()
        Try
            MyContentImage = Nothing
            Me.Visible = False

            'Enable Custom Drawing
            AddHandler Me.Paint, AddressOf Painting
            Me.Refresh()

            'Draw Control to Bitmap
            Dim bm As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.Width, Me.Height)
            Me.DrawToBitmap(bm, New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height))
            MyContentImage = bm
            Me.Refresh()

            ' Dim ms As New System.IO.MemoryStream
            ''Save Bitmap to Memory Stream
            'bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ''Create Image from Stream
            ''MyContentImage = System.Drawing.Image.FromStream(ms)
            'ms.Dispose()
            'Refresh to trigger redraw, this time the image only with alpha applied

            'remove paint event handler until the control is invalidated again
            RemoveHandler Me.Paint, AddressOf Painting
            'btBitmap
            Me.Visible = True
        Catch ex As Exception
#If DEBUG Then
            Console.WriteLine("FadingLabelPanel Error in Invalidation Routine")
#End If
        End Try

    End Sub

    Private Function GetStringFormat(ByVal ctrlalign As System.Drawing.ContentAlignment) As System.Drawing.StringFormat
        Dim strFormat As System.Drawing.StringFormat = New System.Drawing.StringFormat()
        Select Case ctrlalign
            Case System.Drawing.ContentAlignment.MiddleCenter
                strFormat.LineAlignment = System.Drawing.StringAlignment.Center
                strFormat.Alignment = System.Drawing.StringAlignment.Center
            Case System.Drawing.ContentAlignment.MiddleLeft
                strFormat.LineAlignment = System.Drawing.StringAlignment.Center
                strFormat.Alignment = System.Drawing.StringAlignment.Near
            Case System.Drawing.ContentAlignment.MiddleRight
                strFormat.LineAlignment = System.Drawing.StringAlignment.Center
                strFormat.Alignment = System.Drawing.StringAlignment.Far
            Case System.Drawing.ContentAlignment.TopCenter
                strFormat.LineAlignment = System.Drawing.StringAlignment.Near
                strFormat.Alignment = System.Drawing.StringAlignment.Center
            Case System.Drawing.ContentAlignment.TopLeft
                strFormat.LineAlignment = System.Drawing.StringAlignment.Near
                strFormat.Alignment = System.Drawing.StringAlignment.Near
            Case System.Drawing.ContentAlignment.TopRight
                strFormat.LineAlignment = System.Drawing.StringAlignment.Near
                strFormat.Alignment = System.Drawing.StringAlignment.Far
            Case System.Drawing.ContentAlignment.BottomCenter
                strFormat.LineAlignment = System.Drawing.StringAlignment.Far
                strFormat.Alignment = System.Drawing.StringAlignment.Center
            Case System.Drawing.ContentAlignment.BottomLeft
                strFormat.LineAlignment = System.Drawing.StringAlignment.Far
                strFormat.Alignment = System.Drawing.StringAlignment.Near
            Case System.Drawing.ContentAlignment.BottomRight
                strFormat.LineAlignment = System.Drawing.StringAlignment.Far
                strFormat.Alignment = System.Drawing.StringAlignment.Far
        End Select
        Return strFormat
    End Function
#End Region

#Region "Supporting Classes"

#Region "ColorWithAlpha"
    <TypeConverter(GetType(ColorWithAlphaTypeConverter)), _
    DesignTimeVisible(False), _
    ToolboxItem(False), _
    Serializable()> _
    Public Class ColorWithAlpha
        Inherits Component

        Private ctlParent As Control

        <Browsable(False)> _
        Public Property Parent() As Control
            Get
                Return ctlParent
            End Get
            Set(ByVal value As Control)
                ctlParent = value
            End Set
        End Property

        Sub New()
            MyBase.New()
            Invalidate()
        End Sub

        Sub Invalidate()
            If Not Parent Is Nothing Then
                Parent.Invalidate()
            End If
        End Sub

        Private clColor As Color = SystemColors.Control
        Private iAlpha As Integer = 255

        Property Color() As Color
            Get
                Return clColor
            End Get
            Set(ByVal value As Color)
                clColor = value
                Invalidate()
            End Set
        End Property

        Property Alpha() As Integer
            Get
                Return iAlpha
            End Get
            Set(ByVal value As Integer)
                iAlpha = value
                Invalidate()
            End Set
        End Property

    End Class
#End Region

#Region "Type Convertors"

#Region "ColorWithAlphaTypeConverter"
    Public Class ColorWithAlphaTypeConverter
        Inherits ExpandableObjectConverter

        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destType As Type) As Boolean
            If destType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destType)
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
            If destType Is GetType(String) Then
                Return "My color"
            End If
            Return MyBase.ConvertTo(context, culture, value, destType)
        End Function

    End Class
#End Region

#Region "ColorWithAlphaCollectionConverter"
    Public Class ColorWithAlphaCollectionConverter
        Inherits ExpandableObjectConverter

        Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destType As Type) As Boolean
            If destType Is GetType(String) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destType)
        End Function

        Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
            If destType Is GetType(String) Then
                Return CType(value, ColorWithAlphaCollection).Count & " colors"
            End If
            Return MyBase.ConvertTo(context, culture, value, destType)
        End Function

    End Class
#End Region

#End Region

#Region "Collections"

#Region "ColorWithAlphaCollection"
    <TypeConverter(GetType(ColorWithAlphaCollectionConverter)), _
    Editor(GetType(ColorWithAlphaCollectionEditor), GetType(UITypeEditor)), _
    DesignTimeVisible(False), _
    ToolboxItem(False), _
    Serializable()> _
    Public Class ColorWithAlphaCollection
        Inherits CollectionBase
        Implements ICustomTypeDescriptor

        Private ctlParent As Control

        Sub New()

        End Sub

        Sub New(ByVal ParentControl As Control)
            Parent = ParentControl
        End Sub

        <Browsable(False)> _
        Property Parent() As Control
            Get
                Return ctlParent
            End Get
            Set(ByVal value As Control)
                ctlParent = value
            End Set
        End Property

        Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As Object, ByVal newValue As Object)
            CType(newValue, ColorWithAlpha).Parent = Parent
            MyBase.OnSet(index, oldValue, newValue)
        End Sub

        Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As Object)
            CType(value, ColorWithAlpha).Parent = Parent
            MyBase.OnInsert(index, value)
        End Sub

        Default ReadOnly Property Item(ByVal Index As Integer) As ColorWithAlpha
            Get
                Return DirectCast(List(Index), ColorWithAlpha)
            End Get
        End Property

        Public Function Add(ByVal value As ColorWithAlpha) As ColorWithAlpha
            List.Add(value)
            Return value
        End Function

        Public Function Contains(ByVal value As ColorWithAlpha) As Boolean
            Return List.Contains(value)
        End Function

        Public Sub Remove(ByVal value As ColorWithAlpha)
            List.Remove(value)
        End Sub

        Public Function IndexOf(ByVal value As ColorWithAlpha) As Integer
            Return List.IndexOf(value)
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As ColorWithAlpha)
            List.Insert(index, value)
        End Sub

        Public Shadows Sub Clear()
            MyBase.Clear()
        End Sub

        Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
            Return TypeDescriptor.GetAttributes(Me, True)
        End Function

        Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
            Return TypeDescriptor.GetClassName(Me, True)
        End Function

        Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
            Return TypeDescriptor.GetComponentName(Me, True)
        End Function

        Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
            Return TypeDescriptor.GetConverter(Me, True)
        End Function

        Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
            Return TypeDescriptor.GetDefaultEvent(Me, True)
        End Function

        Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
            Return TypeDescriptor.GetDefaultProperty(Me, True)
        End Function

        Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
            Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
        End Function

        Public Overloads Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, True)
        End Function

        Public Overloads Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, attributes, True)
        End Function

        Public Overloads Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            Return Nothing
        End Function

        Public Overloads Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
            Dim pdcProperties As New PropertyDescriptorCollection(Nothing)
            For i As Integer = 0 To List.Count - 1
                Dim pdProperty As New ColorWithAlphaCollectionPropertyDescriptor(Me, i)
                pdcProperties.Add(pdProperty)
            Next
            Return pdcProperties
        End Function

        Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
            Return Me
        End Function

    End Class
#End Region

#Region "ColorWithAlphaCollectionPropertyDescriptor"
    Public Class ColorWithAlphaCollectionPropertyDescriptor
        Inherits PropertyDescriptor

        Private _Collection As ColorWithAlphaCollection = Nothing
        Private _Index As Integer = -1

        Sub New(ByVal Collection As ColorWithAlphaCollection, ByVal Index As Integer)
            MyBase.New("#" + Index.ToString(), Nothing)
            _Collection = Collection
            _Index = Index
        End Sub

        Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
            Return True
        End Function

        Public Overrides ReadOnly Property ComponentType() As System.Type
            Get
                Return _Collection.GetType
            End Get
        End Property

        Public Overrides Function GetValue(ByVal component As Object) As Object
            Return _Collection(_Index)
        End Function

        Public Overrides ReadOnly Property IsReadOnly() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property PropertyType() As System.Type
            Get
                Return _Collection(_Index).GetType()
            End Get
        End Property

        Public Overrides Sub ResetValue(ByVal component As Object)

        End Sub

        Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)

        End Sub

        Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
            Return True
        End Function

        Public Overrides ReadOnly Property Attributes() As System.ComponentModel.AttributeCollection
            Get
                Return New AttributeCollection(Nothing)
            End Get
        End Property

        Public Overrides ReadOnly Property DisplayName() As String
            Get
                Dim item As ColorWithAlpha = _Collection(_Index)
                Return "Color " & _Index
            End Get
        End Property

        Public Overrides ReadOnly Property Description() As String
            Get
                Return "Defines a color with an alpha level (0-255). 0 being transparent and 255 being full opaque"
            End Get
        End Property

        Public Overrides ReadOnly Property Name() As String
            Get
                Return "#" + _Index.ToString()
            End Get
        End Property

    End Class
#End Region

#Region "ColorWithAlphaCollectionEditor"
    Friend Class ColorWithAlphaCollectionEditor
        Inherits CollectionEditor

        Private cfForm As CollectionForm

        Sub New(ByVal Type As Type)
            MyBase.New(Type)
        End Sub

        Protected Overrides Function CreateCollectionForm() As System.ComponentModel.Design.CollectionEditor.CollectionForm
            cfForm = MyBase.CreateCollectionForm
            Return cfForm
        End Function

        Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            If Not cfForm Is Nothing AndAlso cfForm.Visible Then
                Return New ColorWithAlphaCollectionEditor(CollectionType)
            Else
                Return MyBase.EditValue(context, provider, value)
            End If
        End Function
    End Class
#End Region

#End Region

#Region "String Formats Dialog"

#Region "StringFormatsConverter"
    Private Class StringFormatsConverter
        Inherits System.ComponentModel.TypeConverter

        ' We can convert into String.
        Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As System.Boolean
            If destinationType Is GetType(System.String) Then Return True
            Return MyBase.CanConvertTo(context, destinationType)
        End Function

        ' Convert into a blank String.
        Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As System.Object, ByVal destinationType As System.Type) As System.Object
            If destinationType Is GetType(System.String) Then
                Return ""
            Else
                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End If
        End Function
    End Class
#End Region

#Region "StringFormatsEditor"

    Private Class StringFormatsEditor
        Inherits System.Drawing.Design.UITypeEditor
        ' Indicates that this editor displays a dropdown.

        Public Overloads Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
            Return System.Drawing.Design.UITypeEditorEditStyle.Modal
        End Function

        Public Overloads Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As System.Object) As System.Object
            ' Get an IWindowsFormsEditorService.
            Dim editor_service As Windows.Forms.Design.IWindowsFormsEditorService = _
             CType(provider.GetService(GetType(Windows.Forms.Design.IWindowsFormsEditorService)),  _
              Windows.Forms.Design.IWindowsFormsEditorService)

            ' Convert the generic value into a PolyPolyline.
            Dim strfmts As StringFormats = CType(value, StringFormats)

            ' If we failed to get the editor service, return the value unchanged.
            If editor_service Is Nothing Then Return value
            Dim editor_dialog As New StringFormatEditorDialog()
            editor_dialog.StringFormatFlag = strfmts
            editor_dialog.EditorService = editor_service

            ' Display the editing dialog.
            editor_service.ShowDialog(editor_dialog)

            ' Save the new results.
            If editor_dialog.DialogResult = Windows.Forms.DialogResult.OK Then
                ' Return the new StringFormatFlag.
                Return editor_dialog.StringFormatFlag
            Else
                ' Return the old StringFormatFlag.
                Return strfmts
            End If

        End Function

        ' Indicate that we draw a representation for the Properties window's value.
        Public Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Boolean
            Return True
        End Function
    End Class
#End Region

#Region "StringFormatEditorDialog"

    ' The StringFormatEditorDialog class displays this dialog to edit a StringFormatFlag.
    Private Class StringFormatEditorDialog
        Public EditorService As Windows.Forms.Design.IWindowsFormsEditorService = Nothing
        Private StrFormats As StringFormats = StringFormats.None
        Private FormLoaded As System.Boolean = False

        ' Delegate StringFormatFlag to the SpecialButton.
        Public Property StringFormatFlag As StringFormats
            Get
                StrFormats = StringFormats.None

                If FormLoaded Then
                    If Me.rDirectionRightToLeft.Checked = True Then StrFormats += StringFormats.DirectionRightToLeft
                    If Me.rDirectionVertical.Checked = True Then StrFormats += StringFormats.DirectionVertical
                    If Me.rDisplayFormatControl.Checked = True Then StrFormats += StringFormats.DisplayFormatControl
                    If Me.rNoFontFallback.Checked = True Then StrFormats += StringFormats.NoFontFallback
                    If Me.rNoWrap.Checked = True Then StrFormats += StringFormats.NoWrap
                    If Me.rLineLimit.Checked = True Then StrFormats += StringFormats.LineLimit
                    If Me.rNoClip.Checked = True Then StrFormats += StringFormats.NoClip
                    If Me.rFitBlackBox.Checked = True Then StrFormats += StringFormats.FitBlackBox
                    If Me.rMeasureTrailingSpaces.Checked = True Then StrFormats += StringFormats.MeasureTrailingSpaces
                End If
                Return StrFormats
            End Get
            Set(ByVal value As StringFormats)
                ' Make a copy of the StringFormatFlag.
                StrFormats = CType(value, StringFormats)
                If FormLoaded Then
                    If (StrFormats And StringFormats.DirectionRightToLeft) Then Me.rDirectionRightToLeft.Checked = True
                    If (StrFormats And StringFormats.DirectionVertical) Then Me.rDirectionVertical.Checked = True
                    If (StrFormats And StringFormats.DisplayFormatControl) Then Me.rDisplayFormatControl.Checked = True
                    If (StrFormats And StringFormats.NoFontFallback) Then Me.rNoFontFallback.Checked = True
                    If (StrFormats And StringFormats.NoWrap) Then Me.rNoWrap.Checked = True
                    If (StrFormats And StringFormats.LineLimit) Then Me.rLineLimit.Checked = True
                    If (StrFormats And StringFormats.NoClip) Then Me.rNoClip.Checked = True
                    If (StrFormats And StringFormats.FitBlackBox) Then Me.rFitBlackBox.Checked = True
                    If (StrFormats And StringFormats.MeasureTrailingSpaces) Then Me.rMeasureTrailingSpaces.Checked = True
                End If
            End Set
        End Property

        Public Sub Load_Form(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
            AddHandler btnOk.Click, AddressOf OK_Click
            If (StrFormats And StringFormats.DirectionRightToLeft) Then Me.rDirectionRightToLeft.Checked = True
            If (StrFormats And StringFormats.DirectionVertical) Then Me.rDirectionVertical.Checked = True
            If (StrFormats And StringFormats.DisplayFormatControl) Then Me.rDisplayFormatControl.Checked = True
            If (StrFormats And StringFormats.NoFontFallback) Then Me.rNoFontFallback.Checked = True
            If (StrFormats And StringFormats.NoWrap) Then Me.rNoWrap.Checked = True
            If (StrFormats And StringFormats.LineLimit) Then Me.rLineLimit.Checked = True
            If (StrFormats And StringFormats.NoClip) Then Me.rNoClip.Checked = True
            If (StrFormats And StringFormats.FitBlackBox) Then Me.rFitBlackBox.Checked = True
            If (StrFormats And StringFormats.MeasureTrailingSpaces) Then Me.rMeasureTrailingSpaces.Checked = True
            FormLoaded = True
        End Sub
        Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            StrFormats = StringFormats.None
            If Me.rDirectionRightToLeft.Checked = True Then StrFormats += StringFormats.DirectionRightToLeft
            If Me.rDirectionVertical.Checked = True Then StrFormats += StringFormats.DirectionVertical
            If Me.rDisplayFormatControl.Checked = True Then StrFormats += StringFormats.DisplayFormatControl
            If Me.rNoFontFallback.Checked = True Then StrFormats += StringFormats.NoFontFallback
            If Me.rNoWrap.Checked = True Then StrFormats += StringFormats.NoWrap
            If Me.rLineLimit.Checked = True Then StrFormats += StringFormats.LineLimit
            If Me.rNoClip.Checked = True Then StrFormats += StringFormats.NoClip
            If Me.rFitBlackBox.Checked = True Then StrFormats += StringFormats.FitBlackBox
            If Me.rMeasureTrailingSpaces.Checked = True Then StrFormats += StringFormats.MeasureTrailingSpaces
        End Sub
        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            Dim brush As New System.Drawing.SolidBrush(MyBase.BackColor)
            pevent.Graphics.FillRectangle(brush, pevent.ClipRectangle)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim brush As System.Drawing.Drawing2D.LinearGradientBrush
            Dim mode As System.Drawing.Drawing2D.LinearGradientMode
            mode = System.Drawing.Drawing2D.LinearGradientMode.Vertical

            Me.OnPaintBackground(e)
            Dim newRect As System.Drawing.Rectangle = New System.Drawing.Rectangle(Me.ClientRectangle.X, Me.ClientRectangle.Y, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
            brush = New System.Drawing.Drawing2D.LinearGradientBrush(newRect, MyBase.BackColor, MyBase.BackColor, mode)
            e.Graphics.FillRectangle(brush, newRect)
            e.Graphics.DrawRectangle(New System.Drawing.Pen(System.Drawing.Color.Black, CDbl(1)), newRect)
            e.Graphics.Dispose()
        End Sub
    End Class

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class StringFormatEditorDialog
        Inherits System.Windows.Forms.Form
        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As System.Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.rDirectionRightToLeft = New System.Windows.Forms.CheckBox
            Me.rDirectionVertical = New System.Windows.Forms.CheckBox
            Me.rDisplayFormatControl = New System.Windows.Forms.CheckBox
            Me.rNoFontFallback = New System.Windows.Forms.CheckBox
            Me.rNoWrap = New System.Windows.Forms.CheckBox
            Me.rLineLimit = New System.Windows.Forms.CheckBox
            Me.rNoClip = New System.Windows.Forms.CheckBox
            Me.rFitBlackBox = New System.Windows.Forms.CheckBox
            Me.rMeasureTrailingSpaces = New System.Windows.Forms.CheckBox
            Me.lblHeader = New System.Windows.Forms.Label
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.SuspendLayout()

            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.AutoSize = False
            Me.lblHeader.Location = New System.Drawing.Point(20, 5)
            Me.lblHeader.Size = New System.Drawing.Size(120, 20)
            Me.lblHeader.Text = "String Formats"
            Me.lblHeader.ForeColor = System.Drawing.Color.Blue
            Me.lblHeader.UseCompatibleTextRendering = True
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

            '
            'btnOk
            '
            Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.Location = New System.Drawing.Point(56, 130)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(75, 23)
            Me.btnOk.TabIndex = 100
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            Me.btnOk.AutoSize = False
            Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnOk.UseCompatibleTextRendering = True
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(168, 130)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 200
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            Me.btnCancel.AutoSize = False
            Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCancel.UseCompatibleTextRendering = True

            Me.rDirectionRightToLeft.AutoSize = True
            Me.rDirectionRightToLeft.Text = "Direction Right to Left"
            Me.rDirectionRightToLeft.Location = New System.Drawing.Point(8, 30)
            Me.rDirectionRightToLeft.Name = "rDirectionRightToLeft"
            Me.rDirectionRightToLeft.TabIndex = 0
            Me.rDirectionRightToLeft.Tag = 1
            Me.rDirectionRightToLeft.Checked = False
            Me.rDirectionRightToLeft.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rDirectionRightToLeft, "Text is displayed" & vbCrLf & "from right to left.")

            Me.rDirectionVertical.AutoSize = True
            Me.rDirectionVertical.Text = "Direction Vertical"
            Me.rDirectionVertical.Location = New System.Drawing.Point(8, 50)
            Me.rDirectionVertical.Name = "rDirectionVertical"
            Me.rDirectionVertical.TabIndex = 1
            Me.rDirectionVertical.Tag = 2
            Me.rDirectionVertical.Checked = False
            Me.rDirectionVertical.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rDirectionVertical, "Text is vertically aligned.")

            Me.rDisplayFormatControl.AutoSize = True
            Me.rDisplayFormatControl.Text = "Display Format Control"
            Me.rDisplayFormatControl.Location = New System.Drawing.Point(8, 70)
            Me.rDisplayFormatControl.Name = "rDisplayFormatControl"
            Me.rDisplayFormatControl.TabIndex = 2
            Me.rDisplayFormatControl.Tag = 32
            Me.rDisplayFormatControl.Checked = False
            Me.rDisplayFormatControl.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rDisplayFormatControl, "Control characters such as" & vbCrLf & "the left-to-right mark" & vbCrLf & "are shown in the output with" & vbCrLf & "a representative glyph.")

            Me.rNoFontFallback.AutoSize = True
            Me.rNoFontFallback.Text = "No Font Fallback"
            Me.rNoFontFallback.Location = New System.Drawing.Point(8, 90)
            Me.rNoFontFallback.Name = "rNoFontFallback"
            Me.rNoFontFallback.TabIndex = 3
            Me.rNoFontFallback.Tag = 1024
            Me.rNoFontFallback.Checked = False
            Me.rNoFontFallback.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rNoFontFallback, "Fallback to alternate fonts for characters" & vbCrLf & "not supported in the requested font is disabled." & vbCrLf & "Any missing characters are displayed with" & vbCrLf & "the fonts missing glyph, usually an open square.")

            Me.rNoWrap.AutoSize = True
            Me.rNoWrap.Text = "No Wrap"
            Me.rNoWrap.Location = New System.Drawing.Point(200, 30)
            Me.rNoWrap.Name = "rNoWrap"
            Me.rNoWrap.TabIndex = 4
            Me.rNoWrap.Tag = 4096
            Me.rNoWrap.Checked = False
            Me.rNoWrap.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rNoWrap, "Text wrapping between lines when formatting" & vbCrLf & "within a rectangle is disabled." & vbCrLf & "This flag is implied when a point is passed" & vbCrLf & "instead of a rectangle, or when the specified rectangle" & vbCrLf & "has a zero line length.")

            Me.rLineLimit.AutoSize = True
            Me.rLineLimit.Text = "Line Limit"
            Me.rLineLimit.Location = New System.Drawing.Point(200, 50)
            Me.rLineLimit.Name = "rLineLimit"
            Me.rLineLimit.TabIndex = 5
            Me.rLineLimit.Tag = 8192
            Me.rLineLimit.Checked = False
            Me.rLineLimit.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rLineLimit, "Only entire lines are laid out in the" & vbCrLf & "formatting rectangle. By default layout continues" & vbCrLf & "until the end of the text, or until no more" & vbCrLf & "lines are visible as a result of clipping," & vbCrLf & "whichever comes first. Note that the default" & vbCrLf & "settings allow the last line to be partially" & vbCrLf & "obscured by a formatting rectangle that" & vbCrLf & "is not a whole multiple of the line height." & vbCrLf & "To ensure that only whole lines are seen," & vbCrLf & "specify this value and be careful to provide a" & vbCrLf & "formatting rectangle at least as tall as the" & vbCrLf & "height of one line.")

            Me.rNoClip.AutoSize = True
            Me.rNoClip.Text = "No Clip"
            Me.rNoClip.Location = New System.Drawing.Point(200, 70)
            Me.rNoClip.Name = "rNoClip"
            Me.rNoClip.TabIndex = 6
            Me.rNoClip.Tag = 16384
            Me.rNoClip.Checked = False
            Me.rNoClip.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rNoClip, "Overhanging parts of glyphs," & vbCrLf & "and unwrapped text reaching outside the" & vbCrLf & "formatting rectangle are allowed to show." & vbCrLf & "By default all text and glyph parts" & vbCrLf & "reaching outside the formatting rectangle" & vbCrLf & "are clipped.")

            Me.rFitBlackBox.AutoSize = True
            Me.rFitBlackBox.Text = "Fit Black Box"
            Me.rFitBlackBox.Location = New System.Drawing.Point(200, 90)
            Me.rFitBlackBox.Name = "rFitBlackBox"
            Me.rFitBlackBox.TabIndex = 7
            Me.rFitBlackBox.Tag = 4
            Me.rFitBlackBox.Checked = False
            Me.rFitBlackBox.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rFitBlackBox, "Parts of characters are allowed to overhang" & vbCrLf & "the string's layout rectangle." & vbCrLf & "By default, characters are repositioned" & vbCrLf & "to avoid any overhang.")

            'rMeasureTrailingSpaces
            Me.rMeasureTrailingSpaces.AutoSize = True
            Me.rMeasureTrailingSpaces.Text = "Measure Trailing Spaces"
            Me.rMeasureTrailingSpaces.Location = New System.Drawing.Point(8, 110)
            Me.rMeasureTrailingSpaces.Name = "rMeasureTrailingSpaces"
            Me.rMeasureTrailingSpaces.TabIndex = 8
            Me.rMeasureTrailingSpaces.Tag = 2048
            Me.rMeasureTrailingSpaces.Checked = False
            Me.rMeasureTrailingSpaces.Cursor = System.Windows.Forms.Cursors.Hand
            Me.ToolTip1.SetToolTip(Me.rMeasureTrailingSpaces, "Includes the trailing space at the end" & vbCrLf & "of each line. By default the boundary" & vbCrLf & "rectangle returned by the MeasureString method" & vbCrLf & "excludes the space at the end of each line." & vbCrLf & "Set this flag to include that space in measurement.")

            '
            'StringFormatEditorDialog
            '
            Me.AcceptButton = Me.btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(340, 160)
            Me.Controls.AddRange(New System.Windows.Forms.Control() { _
             Me.btnOk, Me.btnCancel, Me.lblHeader, _
             Me.rDirectionRightToLeft, Me.rDirectionVertical, _
             Me.rDisplayFormatControl, Me.rNoFontFallback, _
             Me.rNoWrap, Me.rLineLimit, Me.rNoClip, Me.rFitBlackBox, Me.rMeasureTrailingSpaces _
            })
            Me.ControlBox = False
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "StringFormatEditorDialog"
            Me.Text = "String Formats"
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents rDirectionRightToLeft As System.Windows.Forms.CheckBox
        Friend WithEvents rDirectionVertical As System.Windows.Forms.CheckBox
        Friend WithEvents rDisplayFormatControl As System.Windows.Forms.CheckBox
        Friend WithEvents rNoFontFallback As System.Windows.Forms.CheckBox
        Friend WithEvents rNoWrap As System.Windows.Forms.CheckBox
        Friend WithEvents rLineLimit As System.Windows.Forms.CheckBox
        Friend WithEvents rNoClip As System.Windows.Forms.CheckBox
        Friend WithEvents rFitBlackBox As System.Windows.Forms.CheckBox
        Friend WithEvents rMeasureTrailingSpaces As System.Windows.Forms.CheckBox
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    End Class
#End Region

#End Region

#End Region




    Public Sub Add(component As System.ComponentModel.IComponent) Implements System.ComponentModel.IContainer.Add
        Throw New NotImplementedException()
    End Sub

    Public Sub Add(component As System.ComponentModel.IComponent, name As String) Implements System.ComponentModel.IContainer.Add

        Throw New NotImplementedException()
    End Sub

    Public ReadOnly Property Components As System.ComponentModel.ComponentCollection Implements System.ComponentModel.IContainer.Components
        Get
            Return Nothing
        End Get
    End Property

    Public Sub Remove(component As System.ComponentModel.IComponent) Implements System.ComponentModel.IContainer.Remove
        Throw New NotImplementedException()
    End Sub
End Class

Public Class FadingLabelPanelItem
    Inherits ToolStripControlHost
    Private WithEvents FadingLabelPanel As FadingLabelPanel
    Public Event FaderStart(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Event FaderFinish(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Event FaderPause(ByVal myself As Object, ByVal bAutoFade As Boolean)
    Public Event FaderContinue(ByVal myself As Object, ByVal bAutoFade As Boolean)

    Public Sub New()
        MyBase.New(New FadingLabelPanel())
        Me.FadingLabelPanel = TryCast(Me.Control, FadingLabelPanel)
        Me.FadingLabelPanel.AutoFade = True
        Me.FadingLabelPanel.AutoHide = True
        Me.FadingLabelPanel.AutoEllipsis = False
        Me.FadingLabelPanel.StepSize = 8
        Me.FadingLabelPanel.TextAlign = ContentAlignment.MiddleLeft
        Me.FadingLabelPanel.Font = New Drawing.Font("Arial Narrow", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel)
        Me.FadingLabelPanel.Location = New Drawing.Point(0, 0)
        Me.FadingLabelPanel.Size = New Drawing.Point(185, 24)
        AddHandler Me.FadingLabelPanel.FaderContinued, AddressOf me_FaderContinued
        AddHandler Me.FadingLabelPanel.FaderStarted, AddressOf me_FaderStart
        AddHandler Me.FadingLabelPanel.FaderFinished, AddressOf me_FaderFinish
        AddHandler Me.FadingLabelPanel.FaderPaused, AddressOf me_FaderPause

    End Sub
    Private Sub me_FaderContinued(sender As Object, autofade As Boolean)
        RaiseEvent FaderContinue(sender, autofade)
    End Sub
    Private Sub me_FaderStart(sender As Object, autofade As Boolean)
        RaiseEvent FaderStart(sender, autofade)
    End Sub
    Private Sub me_FaderFinish(sender As Object, autofade As Boolean)
        RaiseEvent FaderFinish(sender, autofade)
    End Sub
    Private Sub me_FaderPause(sender As Object, autofade As Boolean)
        RaiseEvent FaderPause(sender, autofade)
    End Sub
    Public Property Label As String
        Get
            Return Me.FadingLabelPanel.Label
        End Get
        Set(value As String)
            Me.FadingLabelPanel.Label = value
        End Set
    End Property
    Public Property AutoFade As Boolean
        Get
            Return Me.FadingLabelPanel.AutoFade
        End Get
        Set(value As Boolean)
            Me.FadingLabelPanel.AutoFade = value
        End Set
    End Property
    Public ReadOnly Property Status As FadingLabelPanel.FadeFlag
        Get
            Return Me.FadingLabelPanel.Status
        End Get
    End Property
    Public Sub Fade()
        Me.FadingLabelPanel.Fade()
    End Sub
    Public Sub Abort()
        Me.FadingLabelPanel.Abort()
    End Sub
    Public Sub FadeOut()
        Me.FadingLabelPanel.FadeOut()
    End Sub
    Public Sub FadeIn()
        Me.FadingLabelPanel.FadeIn()
    End Sub
    Public Shadows Property TextAlign As ContentAlignment
        Get
            Return Me.FadingLabelPanel.TextAlign
        End Get
        Set(value As ContentAlignment)
            Me.FadingLabelPanel.TextAlign = value
        End Set
    End Property
    Public Overrides Property Size As System.Drawing.Size
        Get
            Return MyBase.Size
        End Get
        Set(value As System.Drawing.Size)
            MyBase.Size = value
            If Not Me.FadingLabelPanel Is Nothing Then
                Me.FadingLabelPanel.Size = value
            End If
        End Set
    End Property

    ' Add properties, events etc. you want to expose...
End Class