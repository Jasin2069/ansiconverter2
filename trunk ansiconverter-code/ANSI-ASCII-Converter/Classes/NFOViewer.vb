Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.MarshalByRefObject
Imports System.Runtime.InteropServices


<Serializable()> Public Class NFOViewer
    Inherits Windows.Forms.Form
    Public Enum Align
        Left = 0
        Center = 1
        Right = 2
    End Enum
    Public Enum VAlign
        Top = 0
        Middle = 1
        Bottom = 2
    End Enum
    Public Structure TextAlignment
        Public Horizontal As Align
        Public Vertical As VAlign
        Public Sub New(ByVal h As Align, ByVal v As VAlign)
            Horizontal = h
            Vertical = v
        End Sub
    End Structure
    Public Enum FadeDirection
        NoFade = 0
        FadeIn = 1
        FadeOut = 2
    End Enum

    Private iSingleIncr As Integer = 10
    Private iPageIncr As Integer = 100
    Private iSingleIncrBackup As Integer = iSingleIncr

    Private m_NFOTimeInit As Integer = 100
    Private m_NFOTimeDecrement As Integer = 1
    Private m_NFOTimeDecIntervall As Integer = 5
    Private m_NFOTimeMin As Integer = 5
    Private m_NFOIntervallCount As Integer = 0
    Private m_NFOLineIncrement As Integer = 1
    Private m_NFOLineIncIntervall As Integer = 5
    Private m_NFOTimeIntervCount As Integer = 0

    Private m_NFOKeyDown As Boolean = False
    Private m_NFOAction As String = ""

    Private DosFont As New FontDef(8, 16, 0, 0, 0, 0, -1, 1, 32, 1, 255)
    Private m_FontBmp As Bitmap
    Private m_NFOText As String = ""

    Private m_TopOffSet As Integer = 0
    Private m_TextHeight As Integer = 0
    Private m_NFOTextImg As Bitmap

    Private m_WindowPosition As New Point(100, 100)
    Private m_WindowSize As New Size(New Point(500, 500))
    Private m_BackgroundColor As Drawing.Color = Color.Black
    Private m_TextColor As Drawing.Color = Color.FromArgb(255, 168, 168, 168)
    Private bClearScreen As Boolean = True
    Private m_Margins As New Padding(10)
    Private m_FaderHeight As Integer = 100
    Private m_ShowHelpText As Boolean = True
    Private m_HelpTextFont As Font = New Drawing.Font("Lucida Console", 11, FontStyle.Regular, GraphicsUnit.Pixel, 0)
    Private m_HelpTextColor As Drawing.Color = Color.Yellow
    Private m_HelpTextPos As New Point(10, 10)
    Private m_HelpTextLoc As New TextAlignment(Align.Right, VAlign.Bottom)
    Private m_HelpText As String = "Use 'Up'/'Dn'" & vbCrLf & "  - or - " & vbCrLf & "'PGUP'/'PGDN'" & vbCrLf & "Keys to Scroll" & vbCrLf & "Press 'ESC'" & vbCrLf & "to Exit"
    Private m_FontLoaded As Boolean = False

    Private m_TrackID As Integer = -1
    Private m_Volume As Integer = 100
    Private oMusic() As Byte = New Byte() {0}

    Private Shared globalAlpha As Integer = 0

    Private Shared globalFadeDirection As FadeDirection = FadeDirection.NoFade
    Private FormFader As Boolean = True
    Private m_AutoStart As Boolean = True
    Private oBASS As BassModNet = Nothing
    Private m_Closing As Boolean = False

#Region "Class Properties"
    Public Property HelpTextColor() As Drawing.Color
        Get
            Return m_HelpTextColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not m_HelpTextColor.Equals(value) Then
                m_HelpTextColor = value
            End If
        End Set
    End Property
    Public Property HelpText() As String
        Get
            Return m_HelpText
        End Get
        Set(ByVal value As String)
            If value <> m_HelpText Then
                m_HelpText = value
            End If
        End Set
    End Property
    Public Property ShowHelpText() As Boolean
        Get
            Return m_ShowHelpText
        End Get
        Set(ByVal value As Boolean)
            If value <> m_ShowHelpText Then
                m_ShowHelpText = value
            End If
        End Set
    End Property
    Public Property HelpTextFont() As Drawing.Font
        Get
            Return m_HelpTextFont
        End Get
        Set(ByVal value As Drawing.Font)
            If Not m_HelpTextFont.Equals(value) Then
                m_HelpTextFont = value
            End If
        End Set
    End Property
    Public Property HelpTextPosition() As Point
        Get
            Return m_HelpTextPos
        End Get
        Set(ByVal value As Point)
            If Not m_HelpTextPos.Equals(value) Then
                m_HelpTextPos = value
            End If
        End Set
    End Property
    Public Property HelpTextLocation() As TextAlignment
        Get
            Return m_HelpTextLoc
        End Get
        Set(ByVal value As TextAlignment)
            If Not m_HelpTextLoc.Equals(value) Then
                m_HelpTextLoc = value
            End If
        End Set
    End Property
    Public Property FaderHeight() As Integer
        Get
            Return m_FaderHeight
        End Get
        Set(ByVal value As Integer)
            If value <> m_FaderHeight Then
                m_FaderHeight = value
            End If
        End Set
    End Property
    Public Property TextMargins() As Padding
        Get
            Return m_Margins
        End Get
        Set(ByVal value As Padding)
            If value <> m_Margins Then
                m_Margins = value
            End If
        End Set
    End Property

    Public Property TextColor() As Drawing.Color
        Get
            Return m_TextColor
        End Get
        Set(ByVal value As Drawing.Color)
            If value <> m_TextColor Then
                m_TextColor = value
                DosFont.SetFontColor(value)
                If m_NFOText <> "" Then
                    Dim i As IntPtr = Me.Handle
                    m_NFOTextImg = DosFont.DrawText(Graphics.FromHwnd(i), 0, 0, m_NFOText)
                    m_TextHeight = m_NFOTextImg.Height
                End If
            End If
        End Set
    End Property

    Public Property BackgroundColor() As Drawing.Color
        Get
            Return m_BackgroundColor
        End Get
        Set(ByVal value As Drawing.Color)
            If value <> m_BackgroundColor Then
                m_BackgroundColor = value
                DosFont.SetTranspColor(value)
                If m_NFOText <> "" Then
                    Dim i As IntPtr = Me.Handle
                    m_NFOTextImg = DosFont.DrawText(Graphics.FromHwnd(i), 0, 0, m_NFOText)
                    m_TextHeight = m_NFOTextImg.Height
                End If
            End If
        End Set
    End Property
    Public Property WindowWidth() As Integer
        Get
            Return m_WindowSize.Width
        End Get
        Set(ByVal value As Integer)
            If value <> m_WindowSize.Width Then
                m_WindowSize.Width = value
            End If
        End Set
    End Property

    Public Property WindowHeight() As Integer
        Get
            Return m_WindowSize.Height
        End Get
        Set(ByVal value As Integer)
            If value <> m_WindowSize.Height Then
                m_WindowSize.Height = value
            End If
        End Set
    End Property
    Public Property WindowSize() As Size
        Get
            Return m_WindowSize
        End Get
        Set(ByVal value As Size)
            If Not value.Equals(m_WindowSize) Then
                m_WindowSize = value
                Me.Width = m_WindowSize.Width
                Me.Height = m_WindowSize.Height
            End If
        End Set
    End Property
    Public Property WindowPosition() As Point
        Get
            Return m_WindowPosition
        End Get
        Set(ByVal value As Point)
            If value <> m_WindowPosition Then
                m_WindowPosition = value
                Me.Top = m_WindowPosition.Y
                Me.Left = m_WindowPosition.X
            End If
        End Set
    End Property

    Public Property NFOText() As String
        Get
            Return m_NFOText
        End Get
        Set(ByVal value As String)
            If value <> m_NFOText Then
                m_NFOText = value
                If m_FontLoaded = True Then
                    Dim i As IntPtr = Me.Handle
                    m_NFOTextImg = DosFont.DrawText(Graphics.FromHwnd(i), 0, 0, m_NFOText)
                    m_TextHeight = m_NFOTextImg.Height
                End If
            End If
        End Set
    End Property

#End Region

    Public Property AutoStart() As Boolean
        Get
            Return m_AutoStart
        End Get
        Set(ByVal value As Boolean)
            If value <> m_AutoStart Then
                m_AutoStart = value
            End If
        End Set
    End Property
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        Me.InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        Me.Opacity = 0
        Me.m_Closing = False
        If oBASS Is Nothing Then
            oBASS = New BassModNet
            Try
                oBASS.ExportAndLoadAssembly()
            Catch ex As Exception

                Console.WriteLine("Error Loading Bass")
            End Try
        End If
    End Sub
    Public Sub New(ByRef Bass As BassModNet)
        Me.New()
        oBASS = Bass
    End Sub
    Private Sub NFOViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Call EndForm()
    End Sub

    Private Sub NFOViewer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        oBASS.Stop(True)
        Me.Opacity = 0
    End Sub

    Private Sub NFOViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        oBASS.Stop(True)
        Me.Opacity = 0
        Me.DestroyHandle()
    End Sub

    Private Sub NFOViewer_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Call EndForm()
    End Sub

    Public Sub FormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        m_FontBmp = My.Resources.dossifont2b1
        DosFont.SetBitmap(m_FontBmp)
        DosFont.BuildFont()
        Dim i As IntPtr = Me.Handle
        If m_NFOText = "" Then m_NFOText = "THIS IS A TEST."
        m_NFOTextImg = DosFont.DrawText(Graphics.FromHwnd(i), 0, 0, m_NFOText)
        m_TextHeight = m_NFOTextImg.Height
        m_TopOffSet = 0
        m_NFOAction = ""
        m_NFOKeyDown = False
        m_FontLoaded = True
        Me.Top = m_WindowPosition.Y
        Me.Left = m_WindowPosition.X
        Me.Width = m_WindowSize.Width
        Me.Height = m_WindowSize.Height
        Me.BackColor = m_BackgroundColor
        Me.ForeColor = m_TextColor
        Me.TTimer.Enabled = False
        Me.TTimer.Interval = m_NFOTimeInit
        AddHandler Me.TTimer.Tick, AddressOf TimerTick
        AddHandler Me.KeyDown, AddressOf keyboarddown
        AddHandler Me.KeyUp, AddressOf Keyboardup
        AddHandler Me.FadeTimer.Tick, AddressOf FadeTimer_Tick
        AddHandler Me.LostFocus, AddressOf NFOViewer_LostFocus
        AddHandler Me.MdiChildActivate, AddressOf NFOViewer_MdiChildActivate
        AddHandler Me.FormClosed, AddressOf NFOViewer_FormClosed
        AddHandler Me.FormClosing, AddressOf NFOViewer_FormClosing
        'AddHandler Me.Paint, AddressOf CanvasPaint
        'If oBassMod.BASSMOD_Init(0, 44100, BassMOD.BASSInit.BASS_DEVICE_DEFAULT) Then
        '   oBassMod.BASSMOD_MusicLoad()
        'End If
        oMusic = CType(My.Resources.JESPERK, Byte())
 
    End Sub
    Public Sub StartForm()
        If Me.m_Closing = False Then
            BassModMusicInit()
            BassModMusicLoad(oMusic)
            'Dim iSize As Integer = GetFileSize("C:\Documents\VisualStudioProjects\ANSIASCIIConverter\ANSI-ASCII-Converter\Resources\JESPERK.XM")
            'Dim xyz As Integer = oBASS.LoadModule("C:\Documents\VisualStudioProjects\ANSIASCIIConverter\ANSI-ASCII-Converter\Resources\JESPERK.XM", 0, iSize, BassModNet.e_BASSMusic.BASS_MUSIC_FT2MOD)
            StartFadeIn()
            oBASS.Play(0)
            oBASS.FadeInMusic(100)
        End If
    End Sub

    Private Sub BassModMusicInit()
        If Not oBASS.Init(-1, 44100, BassModNet.e_BASSInit.BASS_DEVICE_DEFAULT) Then
            Console.WriteLine("Bass: Error INIT")
        End If
    End Sub
    Private Sub BassModMusicLoad(ByVal oMusic As Byte())
        oBASS.LoadModule(oMusic, 0, oMusic.Length, BassModNet.e_BASSMusic.BASS_MUSIC_FT2MOD)
    End Sub
    Private Sub keyboarddown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        m_NFOKeyDown = True
        Select Case e.KeyCode
            Case Keys.Down
                m_NFOAction = "down"
            Case Keys.Up
                m_NFOAction = "up"
            Case Keys.PageUp
                m_NFOAction = "pgup"
            Case Keys.PageDown
                m_NFOAction = "pgdown"
            Case Keys.Pause
                m_NFOAction = "pause"
            Case Keys.Oemplus
                m_NFOAction = "volup"
            Case Keys.OemMinus
                m_NFOAction = "voldown"
            Case Keys.D
                Console.WriteLine(DosFont.ExportPalette.Entries.Count)
                For a As Integer = 0 To DosFont.ExportPalette.Entries.Count - 1
                    Console.WriteLine(a & ": " & DosFont.GetPalettenEntry(a).ToString)
                Next
            Case Keys.Escape
                'Close
                Call EndForm()
            Case Else
                m_NFOKeyDown = False
                m_NFOAction = ""
        End Select
        Me.TTimer.Enabled = True

    End Sub
    Public Sub EndForm()
        If Me.m_Closing = False Then
            Me.m_Closing = True

            StartFadeOut()
            oBASS.FadeOutMusic(True)
        End If
    End Sub
    Private Sub Keyboardup(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Me.TTimer.Enabled = False
        m_NFOKeyDown = False
        m_NFOAction = ""
        Me.TTimer.Interval = m_NFOTimeInit
        m_NFOIntervallCount = 0
        m_NFOTimeIntervCount = 0
        iSingleIncr = iSingleIncrBackup

    End Sub
    Private Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
        If m_NFOKeyDown = True Then
            If m_FontLoaded = True And m_NFOAction <> "" Then
                Call PerformNFOScrollAction(m_NFOAction)
            End If

            m_NFOIntervallCount += 1
            If m_NFOIntervallCount = m_NFOTimeDecIntervall Then
                m_NFOIntervallCount = 0
                m_NFOTimeIntervCount += 1
                If Me.TTimer.Interval >= m_NFOTimeMin + m_NFOTimeDecrement Then
                    Me.TTimer.Interval -= m_NFOTimeDecrement
                Else
                    Me.TTimer.Interval = m_NFOTimeMin
                End If
                If m_NFOTimeIntervCount = m_NFOLineIncIntervall Then
                    m_NFOTimeIntervCount = 0
                    iSingleIncr += m_NFOLineIncrement
                End If
            End If
        End If
    End Sub
    Private Sub PerformNFOScrollAction(ByVal sLocAction As String)
        Dim iVisibleTextHeight As Integer = m_WindowSize.Height - m_Margins.Top - m_Margins.Bottom
        Dim iTopMax As Integer = m_NFOTextImg.Height - iVisibleTextHeight
        If m_TopOffSet > iTopMax Then m_TopOffSet = iTopMax
        If m_TopOffSet < 0 Then m_TopOffSet = 0
        Dim TopOffsetBackup As Integer = m_TopOffSet

        Select Case sLocAction
            Case "up"
                If m_TopOffSet >= iSingleIncr Then
                    m_TopOffSet -= iSingleIncr
                Else
                    m_TopOffSet = 0
                End If
            Case "down"
                If iTopMax > 0 Then
                    If m_TopOffSet <= iTopMax - iSingleIncr Then
                        m_TopOffSet += iSingleIncr
                    Else
                        m_TopOffSet = iTopMax
                    End If
                End If
            Case "pgup"
                If m_TopOffSet >= iPageIncr Then
                    m_TopOffSet -= iPageIncr
                Else
                    m_TopOffSet = 0
                End If
            Case "pgdown"
                If iTopMax > 0 Then
                    If m_TopOffSet <= iTopMax - iPageIncr Then
                        m_TopOffSet += iPageIncr
                    Else
                        m_TopOffSet = iTopMax
                    End If
                End If
            Case "volup"
                If m_Volume < 100 Then
                    m_Volume += 1
                    oBASS.Volume = m_Volume
                End If
            Case "voldown"
                If m_Volume > 0 Then
                    m_Volume -= 1

                    oBASS.Volume = m_Volume
                End If

        End Select

        If m_TopOffSet <> TopOffsetBackup Then
            bClearScreen = True
            Me.Refresh()
        End If
    End Sub
    Private Function AdjustColorWithGlobalFader(ByVal col As Color) As Color
        Return Color.FromArgb(CheckAlpha(col.A - globalAlpha), col.R, col.B, col.G)
    End Function
    Public Sub CanvasPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim BackBuffer = New Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
        Dim g As Graphics = Graphics.FromImage(BackBuffer)
        If bClearScreen = True Then
            e.Graphics.DrawRectangle(New Drawing.Pen(AdjustColorWithGlobalFader(m_BackgroundColor)), _
                            New Drawing.Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height))
            '  g.ResetClip()
            bClearScreen = False
        End If
        If m_FontLoaded = True And Not m_NFOTextImg Is Nothing Then
            'Draw NFO File Text OFFSET
            Dim destRect As Rectangle = New Rectangle(m_Margins.Left, m_Margins.Top, m_NFOTextImg.Width, m_WindowSize.Height - m_Margins.Top - m_Margins.Bottom)
            Dim srcRect As Rectangle = New Rectangle(0, m_TopOffSet, m_NFOTextImg.Width, m_WindowSize.Height - m_Margins.Top - m_Margins.Bottom)
            g.PageUnit = GraphicsUnit.Pixel
            g.DrawImage(m_NFOTextImg, destRect, srcRect, g.PageUnit)
        End If
        If globalFadeDirection <> FadeDirection.NoFade Then
            Call DosFont.ChangePalettenEntry(1, AdjustColorWithGlobalFader(DosFont.GetPalettenEntry(1)))
        End If
        'Draw Help Text


        Dim iIncr As Integer = 255 / m_FaderHeight
        Dim iTransp As Integer = 255
        If m_FontLoaded = True And Not m_NFOTextImg Is Nothing Then


            For y As Integer = m_Margins.Top To m_Margins.Top + m_FaderHeight
                g.DrawLine(New Pen(Color.FromArgb(CheckAlpha(iTransp - globalAlpha), m_BackgroundColor.R, m_BackgroundColor.G, m_BackgroundColor.B)), m_Margins.Left, y, m_Margins.Left + m_NFOTextImg.Width, y)
                iTransp -= iIncr
                If iTransp < 0 Then
                    iTransp = 0
                End If
            Next
            For y As Integer = m_WindowSize.Height - m_Margins.Top - m_Margins.Bottom - m_FaderHeight To m_WindowSize.Height - m_Margins.Bottom
                g.DrawLine(New Pen(Color.FromArgb(CheckAlpha(iTransp - globalAlpha), m_BackgroundColor.R, m_BackgroundColor.G, m_BackgroundColor.B)), m_Margins.Left, y, m_Margins.Left + m_NFOTextImg.Width, y)
                iTransp += iIncr
                If iTransp > 255 Then
                    iTransp = 255
                End If
            Next
        End If

        If m_ShowHelpText = True And m_HelpText <> "" Then
            Dim s As SizeF
            s = g.MeasureString(m_HelpText, m_HelpTextFont)
            Dim iPos As New Point(0, 0)
            Select Case m_HelpTextLoc.Horizontal
                Case Align.Left
                    iPos.X = m_HelpTextPos.X
                Case Align.Right
                    iPos.X = e.ClipRectangle.Width - s.ToSize.Width - m_HelpTextPos.X
                Case Align.Center
                    iPos.X = e.ClipRectangle.Width / 2 - s.ToSize.Width / 2
            End Select
            Select Case m_HelpTextLoc.Vertical
                Case VAlign.Bottom
                    iPos.Y = e.ClipRectangle.Height - s.ToSize.Height - m_HelpTextPos.Y
                Case VAlign.Middle
                    iPos.Y = e.ClipRectangle.Height / 2 - s.ToSize.Height / 2
                Case VAlign.Top
                    iPos.Y = m_HelpTextPos.Y
            End Select
            g.DrawString(m_HelpText, m_HelpTextFont, New SolidBrush(m_HelpTextColor), iPos.X, iPos.Y)
        End If

        e.Graphics.CompositingMode = Drawing2D.CompositingMode.SourceOver
        e.Graphics.CompositingQuality = CompositingQuality.HighSpeed
        e.Graphics.InterpolationMode = InterpolationMode.Default

        e.Graphics.DrawImageUnscaled(BackBuffer, New Point(0, 0))
        BackBuffer.Dispose()
        g.Dispose()
        'System.Windows.Forms.Application.DoEvents()

        'ExtendedDraw(e)
        'DrawBorder(e.Graphics)
        'If lHovertimer < Environment.TickCount And bOverColorList = False And bOverColorLabel = False And ColorListControl1.Visible = True Then
        ' ColorListControl1.Visible = False
        ' End If

    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        'MyBase.OnPaint(e)
        CanvasPaint(Me, e)
        'bClearScreen = True
    End Sub
    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        bClearScreen = True
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Function CheckAlpha(ByVal alp As Integer) As Integer
        If alp < 0 Then alp = 0
        If alp > 255 Then alp = 255
        Return alp
    End Function
    Private Sub StartFadeIn()
        If FormFader = True Then
            If Me.Opacity = 1.0 Then Me.Opacity = 0
        Else
            If globalAlpha = 0 Then globalAlpha = 255
        End If
        globalFadeDirection = FadeDirection.FadeIn
        FadeTimer.Interval = 10
    End Sub
    Private Sub StartFadeOut()
        If FormFader = True Then
            If Me.Opacity = 0 Then Me.Opacity = 1.0
        Else
            If globalAlpha = 255 Then globalAlpha = 0
        End If
        globalFadeDirection = FadeDirection.FadeOut
        FadeTimer.Interval = 10
    End Sub

    Private Sub FadeControl()
        Dim iGlobalAlphaBak As Integer = globalAlpha
        Dim iFormOpacityBak As Long = Me.Opacity
        Select Case globalFadeDirection
            Case FadeDirection.NoFade
                If Me.m_Closing = True Then
                    If Not Me.ParentForm Is Nothing Then
                        Me.ParentForm.BringToFront()
                    End If
                    Me.Close()
                End If
            Case FadeDirection.FadeIn
                If FormFader = True Then
                    If Me.Opacity < 1.0 Then
                        Me.Opacity += 0.05
                    Else
                        Me.Opacity = 1.0
                        globalFadeDirection = FadeDirection.NoFade : FadeTimer.Interval = 50
                        RemoveHandler Me.Leave, AddressOf NFOViewer_Leave
                        AddHandler Me.Leave, AddressOf NFOViewer_Leave
                    End If
                Else
                    If globalAlpha > 0 Then globalAlpha -= 5
                    If globalAlpha = 0 Then : globalFadeDirection = FadeDirection.NoFade : FadeTimer.Interval = 50 : End If
                End If
            Case FadeDirection.FadeOut
                If FormFader = True Then
                    If Me.Opacity > 0 Then
                        Me.Opacity -= 0.05
                    Else
                        Me.Opacity = 0
                        globalFadeDirection = FadeDirection.NoFade : FadeTimer.Interval = 50
                    End If
                Else
                    If globalAlpha < 255 Then globalAlpha += 5
                    If globalAlpha = 255 Then : globalFadeDirection = FadeDirection.NoFade : FadeTimer.Interval = 50 : End If
                End If
        End Select
        If iGlobalAlphaBak <> globalAlpha Or iFormOpacityBak <> Me.Opacity Then
            bClearScreen = True
            Me.Refresh()
        End If
    End Sub
    '===================================================================================
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FontDef
        Public Property FontBmp() As Bitmap 'Bitmap image of the Font
            Get
                Return m_FontBmp
            End Get
            Set(ByVal value As Bitmap)
                If Not m_FontBmp.Equals(value) Then
                    m_FontBmp = value
                    FontBmpBak = value
                End If
            End Set
        End Property
        Public ReadOnly Property FontImgs() As Image() 'Array, which will hold images for each character of the font set
            Get
                Return m_FontImgs
            End Get
        End Property
        Public Property FontWidth() As Integer ' = 8  Width used in the Image for a Single Character
            Get
                Return m_FontWidth
            End Get
            Set(ByVal value As Integer)
                If m_FontWidth <> value Then
                    m_FontWidth = value
                End If
            End Set
        End Property
        Public Property FontHeight() As Integer '= 16  Height used in the Image for a Single Character
            Get
                Return m_FontHeight
            End Get
            Set(ByVal value As Integer)
                If m_FontHeight <> value Then
                    m_FontHeight = value
                End If
            End Set
        End Property
        Public Property FontMarginLeft() As Integer ' = 0 Top, Bottom, Left, Right offset to use
            Get
                Return m_FontMarginLeft
            End Get
            Set(ByVal value As Integer)
                If m_FontMarginLeft <> value Then
                    m_FontMarginLeft = value
                End If
            End Set
        End Property
        Public Property FontMarginRight() As Integer ' = 0
            Get
                Return m_FontMarginRight
            End Get
            Set(ByVal value As Integer)
                If m_FontMarginRight <> value Then
                    m_FontMarginRight = value
                End If
            End Set
        End Property
        Public Property FontMarginTop() As Integer '= 0
            Get
                Return m_FontMarginTop
            End Get
            Set(ByVal value As Integer)
                If m_FontMarginTop <> value Then
                    m_FontMarginTop = value
                End If
            End Set
        End Property
        Public Property FontMarginBottom() As Integer ' = 0
            Get
                Return m_FontMarginBottom
            End Get
            Set(ByVal value As Integer)
                If m_FontMarginBottom <> value Then
                    m_FontMarginBottom = value
                End If
            End Set
        End Property
        Public Property FontSpaceWidth() As Integer '= -1  with of the space character, -1 = Font Width
            Get
                Return m_FontSpaceWidth
            End Get
            Set(ByVal value As Integer)
                If m_FontSpaceWidth <> value Then
                    m_FontSpaceWidth = value
                End If
            End Set
        End Property
        Public Property FontInitChar() As Integer '= 1 Asc Code of first character in the Image File
            Get
                Return m_FontInitChar
            End Get
            Set(ByVal value As Integer)
                If m_FontInitChar <> value Then
                    m_FontInitChar = value
                End If
            End Set
        End Property
        Public Property FontCharsperLine() As Integer '= 32  Number of Characters per line defined in Image
            Get
                Return m_FontCharsperLine
            End Get
            Set(ByVal value As Integer)
                If m_FontCharsperLine <> value Then
                    m_FontCharsperLine = value
                End If
            End Set
        End Property
        Public Property FontCharFrom() As Integer     'Font Image Contains characters starting from ASC this code 
            Get
                Return m_FontCharFrom
            End Get
            Set(ByVal value As Integer)
                If m_FontCharFrom <> value Then
                    m_FontCharFrom = value
                End If
            End Set
        End Property
        Public Property FontCharTo() As Integer       'to this ASCII code
            Get
                Return m_FontCharTo
            End Get
            Set(ByVal value As Integer)
                If m_FontCharTo <> value Then
                    m_FontCharTo = value
                End If
            End Set
        End Property
        Public Property FontTranspColor() As Color ' Transparent Color /Background color
            Get
                Return m_FontTranspColor
            End Get
            Set(ByVal value As Color)
                If Not m_FontTranspColor.Equals(value) Then
                    m_FontTranspColor = value
                    If bBuildFont = True Then
                        Me.BuildFont()
                    End If
                End If
            End Set
        End Property




        Private m_FontBmp As Bitmap
        Private m_FontImgs() As Image
        Private m_FontWidth As Integer
        Private m_FontHeight As Integer
        Private m_FontMarginLeft As Integer ' = 0 Top, Bottom, Left, Right offset to use
        Private m_FontMarginRight As Integer ' = 0
        Private m_FontMarginTop As Integer '= 0
        Private m_FontMarginBottom As Integer ' = 0
        Private m_FontSpaceWidth As Integer '= -1  with of the space character, -1 = Font Width
        Private m_FontInitChar As Integer '= 1 Asc Code of first character in the Image File
        Private m_FontCharsperLine As Integer '= 32  Number of Characters per line defined in Image
        Private m_FontCharFrom As Integer     'Font Image Contains characters starting from ASC this code 
        Private m_FontCharTo As Integer       'to this ASCII code
        Private m_FontTranspColor As Color ' Transparent Color /Background color

        Private FontBmpBak As Bitmap 'Bitmap image of the Font (Backup)
        Private bBuildFont As Boolean

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="w"></param>
        ''' <param name="h"></param>
        ''' <param name="marginlf"></param>
        ''' <param name="marginrt"></param>
        ''' <param name="margintp"></param>
        ''' <param name="marginbt"></param>
        ''' <param name="spcw"></param>
        ''' <param name="initc"></param>
        ''' <param name="chrspln"></param>
        ''' <param name="chrf"></param>
        ''' <param name="chrt"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal w As Integer, ByVal h As Integer, ByVal marginlf As Integer, ByVal marginrt As Integer, _
                       ByVal margintp As Integer, ByVal marginbt As Integer, ByVal spcw As Integer, ByVal initc As Integer, ByVal chrspln As Integer, _
                       ByVal chrf As Integer, ByVal chrt As Integer)
            ReDim m_FontImgs(255)
            m_FontBmp = Nothing
            m_FontWidth = w
            m_FontHeight = h
            m_FontMarginLeft = marginlf
            m_FontMarginRight = marginrt
            m_FontMarginTop = margintp
            m_FontMarginBottom = marginbt
            m_FontSpaceWidth = spcw
            m_FontInitChar = initc
            m_FontCharsperLine = chrspln
            m_FontTranspColor = Color.Black
            m_FontCharFrom = chrf
            m_FontCharTo = chrt
            bBuildFont = False
            '   For a As Integer = 0 To 255
            'FontImgs(a) = New Bitmap(FontWidth, FontHeight)
            'Next
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="bm"></param>
        ''' <remarks></remarks>
        Public Sub SetBitmap(ByVal bm As Bitmap)
            m_FontBmp = bm
            FontBmpBak = bm
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Public Sub SetTranspColor(ByVal col As Color)
            If Not m_FontTranspColor.Equals(col) Then
                m_FontTranspColor = col
                If bBuildFont = True Then
                    Me.BuildFont()
                End If
            End If
        End Sub

        Public Sub SetFontColor(ByVal NewColor As Drawing.Color)
            If Not m_FontBmp Is Nothing Then
                Dim c As Color
                Dim x, y As Int32
                'e.Graphics.DrawImage(bmp, 10, 30)
                For x = 0 To FontBmpBak.Width - 1
                    For y = 0 To FontBmpBak.Height - 1
                        c = FontBmpBak.GetPixel(x, y)
                        If c.ToArgb.Equals(Color.FromArgb(255, 168, 168, 168)) Then
                            c = Color.FromArgb(NewColor.ToArgb)
                            m_FontBmp.SetPixel(x, y, c)
                        End If
                    Next
                Next
                If bBuildFont = True Then
                    Me.BuildFont()
                End If
            End If
        End Sub
        Public Function ExportPalette() As ColorPalette
            Dim cp As ColorPalette = New Bitmap(1, 1).Palette
            If Not m_FontBmp Is Nothing Then
                cp = m_FontBmp.Palette
            End If
            Return cp
        End Function
        Public Sub ChangePalettenEntry(ByVal id As Integer, ByVal Col As Drawing.Color)
            If Not m_FontBmp Is Nothing Then
                If id >= 0 And id <= m_FontBmp.Palette.Entries.Count - 1 Then
                    m_FontBmp.Palette.Entries(id) = Col
                End If
            End If
        End Sub
        Public Function GetPalettenEntry(ByVal ID As Integer) As Drawing.Color
            If Not m_FontBmp Is Nothing Then
                If ID >= 0 And ID <= m_FontBmp.Palette.Entries.Count - 1 Then
                    Return m_FontBmp.Palette.Entries(ID)
                End If
            End If
        End Function
        Public Function PaletteArray() As Color()
            Dim cp As ColorPalette = New Bitmap(1, 1).Palette
            Dim aCol() As Color = New Color() {Color.Black}
            If Not m_FontBmp Is Nothing Then
                cp = m_FontBmp.Palette
                ReDim aCol(cp.Entries.Count - 1)
                For a As Integer = 0 To cp.Entries.Count - 1
                    aCol(a) = cp.Entries(a)
                Next
            End If
            Return aCol
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub BuildFont()
            If Not m_FontBmp Is Nothing Then
                'Create images for all characters included in the font
                For a As Integer = m_FontCharFrom To m_FontCharTo
                    GetFont(a)
                Next
                bBuildFont = True
            End If
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="charcode"></param>
        ''' <remarks></remarks>
        Private Sub GetFont(ByVal charcode As Integer)
            'Charcode = Character ASCII Code
            'Cut Out character from the Font Bitmap and store it in the font chars array
            Dim FntX As Integer, FntY As Integer, FntPOS As Integer, CutLen As Integer, CutHgt As Integer
            FntPOS = charcode - m_FontInitChar
            FntX = ((FntPOS Mod m_FontCharsperLine) * m_FontWidth) + m_FontMarginLeft
            FntY = (Int(FntPOS / m_FontCharsperLine) * m_FontHeight) + m_FontMarginTop
            CutLen = m_FontWidth - m_FontMarginLeft - m_FontMarginRight
            CutHgt = m_FontHeight - m_FontMarginTop - m_FontMarginBottom
            Dim bm As New Bitmap(m_FontWidth, m_FontHeight)
            Dim gr As Graphics = Graphics.FromImage(bm)
            gr.Clear(m_FontTranspColor)
            gr.PageUnit = GraphicsUnit.Pixel

            Dim destRect As Rectangle = New Rectangle(0, 0, m_FontWidth, m_FontHeight)
            Dim srcRect As Rectangle = New Rectangle(FntX, FntY, CutLen, CutHgt)
            Try
                gr.DrawImage(m_FontBmp, destRect, srcRect, gr.PageUnit)
            Catch ex As Exception

            End Try
            m_FontImgs(charcode) = bm
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="gr"></param>
        ''' <param name="xpos"></param>
        ''' <param name="ypos"></param>
        ''' <param name="stext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DrawText(ByRef gr As Graphics, ByVal xpos As Integer, ByVal ypos As Integer, ByVal stext As String) As Bitmap
            If bBuildFont = False Then
                Me.BuildFont()
            End If
            Dim CharXPos As Integer = xpos
            Dim CharYPos As Integer = ypos
            Dim sworktxt As String = ""
            Dim aworktxt() As String, CutLen As Integer, CutHgt As Integer
            Dim FntCurrChar As Integer, iMaxWidth As Integer = 0
            Dim UsedWidth As Integer = m_FontWidth - m_FontMarginLeft - m_FontMarginRight

            aworktxt = Split(stext, vbCrLf)
            For a As Integer = 0 To UBound(aworktxt)
                If Len(aworktxt(a)) > iMaxWidth Then
                    iMaxWidth = Len(aworktxt(a))
                End If
            Next
            Dim bm As New Bitmap(iMaxWidth * m_FontWidth, (UBound(aworktxt) + 1) * m_FontHeight)
            gr = Graphics.FromImage(bm)

            For a As Integer = 0 To UBound(aworktxt)
                sworktxt = aworktxt(a)
                CharXPos = xpos
                For FntCharPos As Integer = 1 To Len(sworktxt)
                    FntCurrChar = Asc(Mid(sworktxt, FntCharPos, 1))

                    If FntCurrChar = 32 And m_FontSpaceWidth <> -1 Then
                        CharXPos = CharXPos + m_FontSpaceWidth
                    Else
                        CutLen = m_FontWidth - m_FontMarginLeft - m_FontMarginRight
                        CutHgt = m_FontHeight - m_FontMarginTop - m_FontMarginBottom
                        Dim destRect As Rectangle = New Rectangle(CharXPos, CharYPos, m_FontWidth, m_FontHeight)
                        Dim srcRect As Rectangle = New Rectangle(0, 0, CutLen, CutHgt)
                        gr.PageUnit = GraphicsUnit.Pixel
                        gr.DrawImage(m_FontImgs(FntCurrChar), destRect, srcRect, gr.PageUnit)

                        CharXPos = CharXPos + UsedWidth
                    End If
                Next
                CharYPos += m_FontHeight
            Next
            Return bm

        End Function


    End Class

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FadeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'FadeTimer
        '
        Me.FadeTimer.Enabled = True
        Me.FadeTimer.Interval = 10
        '
        'NFOViewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.ControlBox = False
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Perfect DOS VGA 437", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NFOViewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Red
        Me.ResumeLayout(False)

    End Sub
    Private components As System.ComponentModel.IContainer
    Friend WithEvents TTimer As System.Windows.Forms.Timer
    Friend WithEvents FadeTimer As System.Windows.Forms.Timer

    Private Sub FadeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call FadeControl()
    End Sub

    Private Sub NFOViewer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Call EndForm()
    End Sub

    Private Sub NFOViewer_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class


