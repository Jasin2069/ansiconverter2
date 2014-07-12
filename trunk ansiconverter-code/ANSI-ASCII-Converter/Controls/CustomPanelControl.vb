Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class CustomPanelControl
    Inherits System.Windows.Forms.Control
    Private WithEvents mToolTip As New Windows.Forms.ToolTip
    Private mbackcolor1 As Color = Color.FromArgb(255, 84, 84, 84) 'SystemColors.ControlDark
    Private mbackcolor2 As Color = Color.Black 'SystemColors.ControlLight
    Private mbackcolorstyle As ColorStyle = ColorStyle.Gradient 'ColorStyle.Solid
    Private mbackgradientmode As LinearGradientMode = LinearGradientMode.Vertical 'LinearGradientMode.Horizontal
    Private mbacksigmafocus As Single = CSng(50 / 100.0F) '0.5F  ' Focus value for  background SetSigmaBellShape()
    Private mbacksigmascale As Single = CSng(90 / 100.0F) '1.0F  ' Scale value for background SetSigmaBellShape()
    Private mbacksigmamode As SigmaMode = SigmaMode.SigmaBell 'SigmaMode.None

    Private mforecolor1 As Color = Color.FromArgb(196, 40, 40, 180) 'SystemColors.ControlDark
    Private mforecolor2 As Color = Color.FromArgb(196, 255, 230, 210) 'SystemColors.ControlLight
    Private mforecolorstyle As ColorStyle = ColorStyle.Gradient 'ColorStyle.Solid
    Private mforegradientmode As LinearGradientMode = LinearGradientMode.Vertical 'LinearGradientMode.Horizontal
    Private mforesigmafocus As Single = CSng(50 / 100.0F) '0.5F  ' Focus value for  background SetSigmaBellShape()
    Private mforesigmascale As Single = CSng(90 / 100.0F) '1.0F  ' Scale value for background SetSigmaBellShape()
    Private mforesigmamode As SigmaMode = SigmaMode.SigmaBell

    Private mborderstyle As eBorderStyle = eBorderStyle.StandardFixed3D
    Private mBorderWidth As Integer = 1
    Private mBorderColorSingle As Color = Color.Black
    Private mBorderColor3DDark As Color = SystemColors.ControlDark
    Private mBorderColor3DLight As Color = SystemColors.ControlLightLight
    Private mLightSource As eLightSource = eLightSource.TopLeft
    Private mSelRange As PointF = New PointF(0, 0)
    Private mMaxValue As Long = 100
    Private mValue As Long = 0
    Private mCurPos As Long = 0
    Enum Orient
        Horizontal
        Vertical
    End Enum

    Enum Direct
        Normal
        Reverse
    End Enum

    Enum ColorStyle
        Solid
        Gradient
    End Enum

    Enum SigmaMode
        None
        SigmaBell
    End Enum

    Enum StretchMode
        Normal
        Stretch
    End Enum

    Enum eBorderStyle
        None
        StandardSingle
        StandardFixed3D
        CustomSingle
        Custom3D
    End Enum

    Enum eLightSource
        TopLeft
        TopRight
        BottomRight
        BottomLeft
    End Enum

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()
        mToolTip.BackColor = Color.Yellow
        mToolTip.ForeColor = Color.Black
        mToolTip.IsBalloon = False
        mToolTip.ReshowDelay = 1000
        mToolTip.AutomaticDelay = 100
        mToolTip.ShowAlways = False
        mToolTip.UseAnimation = False
        mToolTip.UseFading = False
        mToolTip.SetToolTip(Me, "")
        'Add any initialization after the InitializeComponent() call
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.DoubleBuffer Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.Opaque Or _
                    ControlStyles.UserPaint, True)

    End Sub

    'Control overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        '
        '
        Me.Name = "CustomPanel"
        Me.Size = New System.Drawing.Size(150, 20)

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rectf As RectangleF = RectangleF.op_Implicit(Me.ClientRectangle)
        ' Draw the background of the ProgressBar control.
        If mbackcolorstyle = ColorStyle.Gradient Then

            Using brush As New LinearGradientBrush(rectf, _
               mbackcolor1, mbackcolor2, mbackgradientmode)

                If mbacksigmamode = SigmaMode.SigmaBell Then _
                   brush.SetSigmaBellShape(mbacksigmafocus, mbacksigmascale)

                e.Graphics.FillRectangle(brush, rectf)
                brush.Dispose()
            End Using
        Else
            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillRectangle(brush, rectf)
                brush.Dispose()
            End Using

        End If

        If mMaxValue > 0 And mValue > 0 Then
            'Math.Round(mValue * rectf.Width / mMaxValue, 0)
            Dim selRange As Long = Math.Round(mValue * Me.Width / mMaxValue, 0)
            If selRange > 0 Then
                Dim valRectF As RectangleF = New RectangleF(New PointF(rectf.X, rectf.Y), New SizeF(Math.Min(selRange, rectf.Width), rectf.Height))
                Dim valBrush As Object
                If mforecolorstyle = ColorStyle.Gradient Then
                    valBrush = New LinearGradientBrush(valRectF, _
                        mforecolor1, mforecolor2, mforegradientmode)
                    If mforesigmamode = SigmaMode.SigmaBell Then _
                       valBrush.SetSigmaBellShape(mforesigmafocus, mforesigmascale)
                Else
                    valBrush = New SolidBrush(Me.ForeColor)
                End If
                e.Graphics.FillRectangle(valBrush, valRectF)
                valBrush.dispose()
            End If
        End If
        If (mSelRange.X > 0 Or mSelRange.Y > 0) And mSelRange.Y > mSelRange.X And mSelRange.Y < rectf.Width Then

            Dim adjRectf As RectangleF = New RectangleF(New PointF(rectf.X + mSelRange.X, rectf.Y), New SizeF(mSelRange.Y - mSelRange.X, rectf.Height))
            Dim adjBrush As Object
            If mforecolorstyle = ColorStyle.Gradient Then
                adjBrush = New LinearGradientBrush(adjRectf, _
                    ColorSubtract(HueRotate(mforecolor1, 180, 128), 32, 152), ColorSubtract(HueRotate(mforecolor2, 90, 128), 45, 152), mforegradientmode)
                If mforesigmamode = SigmaMode.SigmaBell Then _
                   adjBrush.SetSigmaBellShape(mforesigmafocus, mforesigmascale)
            Else
                adjBrush = New SolidBrush(HueRotate(Me.ForeColor, 270, 128))
            End If
            e.Graphics.FillRectangle(adjBrush, adjRectf)
            Using posBrush2 As New Drawing.Pen(Color.Black, 1)
                e.Graphics.DrawLine(posBrush2, New PointF(rectf.X + mSelRange.X, rectf.Y), New PointF(rectf.X + mSelRange.X, rectf.Top + rectf.Height))
                e.Graphics.DrawLine(posBrush2, New PointF(rectf.X + mSelRange.Y, rectf.Y), New PointF(rectf.X + mSelRange.Y, rectf.Top + rectf.Height))
                posBrush2.Dispose()
            End Using
            Try

                adjBrush.Dispose()
            Catch ex As Exception

            End Try
        End If

        If mMaxValue > 0 And mCurPos > 0 And rectf.Width > 0 Then
            '
            Dim selPos As Long = Math.Round(mCurPos * Me.Width / mMaxValue, 0)

            Using posBrush1 As New Pen(Color.White, 1)
                e.Graphics.DrawLine(posBrush1, New PointF(selPos, rectf.Y), New PointF(selPos, rectf.Top + rectf.Height))
                posBrush1.Dispose()
            End Using

        End If


        ' Draw a border around the ProgressBar control.
        If Me.BorderStyle <> eBorderStyle.None Then DrawBorder(e.Graphics)
    End Sub

    Public Event ValueChanged(ByVal newValue As Long)

    Private Function ColorAdd(ByVal col As Drawing.Color, ByVal amount As Byte, Optional ByVal alpha As Integer = -1) As Drawing.Color
        Return Color.FromArgb(IIf(alpha <> -1, Math.Min(255, alpha), col.A), Math.Min(255, CInt(col.R) + amount), Math.Min(255, CInt(col.G) + amount), Math.Min(255, CInt(col.B) + amount))
    End Function
    Private Function ColorSubtract(ByVal col As Drawing.Color, ByVal amount As Byte, Optional ByVal alpha As Integer = -1) As Drawing.Color
        Return Color.FromArgb(IIf(alpha <> -1, Math.Max(0, alpha), col.A), Math.Max(0, CInt(col.R) - amount), Math.Max(0, CInt(col.G) - amount), Math.Max(0, CInt(col.B) - amount))
    End Function
    Private Function ValidateColor(ByVal bteVal) As Byte
        Return IIf(bteVal < 0, 0, IIf(bteVal > 255, 255, bteVal))
    End Function
    Private Function HueRotate(ByVal col As Drawing.Color, ByVal h As Double, Optional ByVal alpha As Integer = -1) As Drawing.Color
        Dim U As Double = Math.Cos(h * Math.PI / 180)
        Dim W As Double = Math.Sin(h * Math.PI / 180)
        Dim mR As Double = col.R
        Dim mG As Double = col.G
        Dim mB As Double = col.B
        Dim R As Byte = ValidateColor(Math.Abs(Math.Round(((0.701 * U + 0.168 * W) * mR _
                + (-0.587 * U + 0.33 * W) * mG _
                + (-0.114 * U - 0.497 * W) * mB) * 100) / 10))

        Dim G As Byte = ValidateColor(Math.Abs(Math.Round(((-0.299 * U - 0.328 * W) * mR _
                + (0.413 * U + 0.035 * W) * mG _
                + (-0.114 * U + 0.292 * W) * mB) * 100) / 10))

        Dim B As Byte = ValidateColor(Math.Abs(Math.Round(((-0.3 * U + 1.25 * W) * mR _
                + (-0.588 * U - 1.05 * W) * mG _
                + (0.886 * U - 0.203 * W) * mB) * 100) / 10))

        Return Color.FromArgb(IIf(alpha <> -1, alpha, col.A), R, G, B)
    End Function
    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If mMaxValue > 0 Then
            'mPos = mValue * rectf.Width / mMaxValue
            'mValue = mPos * mMaxValue / rectf.width
            If Me.Width > 0 Then
                Dim newVal As Long = Math.Round(e.X * mMaxValue / Me.Width, 0)
                If newVal <> mValue Then
                    mValue = newVal
                    Me.Invalidate()
                    RaiseEvent ValueChanged(newVal)
                End If
            End If
        End If
    End Sub
    Private Sub me_Movepos(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If mMaxValue > 0 Then
            If Me.Width > 0 Then
                Dim newVal As Long = Math.Round(e.X * mMaxValue / Me.Width, 0)
                If mCurPos <> newVal Then
                    mCurPos = newVal
                    mToolTip.Show("  Pos: " & MSToString(newVal), Me)
                End If

                'mToolTip.SetToolTip(Me, MSToString(newVal))
                '
            End If
        End If
    End Sub
    Private Sub me_mouseleave(ByVal Sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
        mCurPos = 0
        mToolTip.SetToolTip(Me, "")
    End Sub
    Private Sub Me_MouseOver(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseHover
        '        mouseOffset = New Point(-e.X, -e.Y)
        If mMaxValue > 0 Then
            Me.Cursor = Cursors.Hand
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        'mwidth = Me.ClientRectangle.Width
        'mheight = Me.ClientRectangle.Height
        ' Invalidate the control to get a repaint.
        Me.Invalidate()
    End Sub
    Private Sub DrawBorder(ByVal g As Graphics)
        Dim PenL As Drawing.Pen = Nothing, PenT As Drawing.Pen = Nothing
        Dim PenR As Drawing.Pen = Nothing, PenB As Drawing.Pen = Nothing

        Dim PenWidth As Integer = CInt(Pens.White.Width)
        Select Case Me.BorderStyle
            Case eBorderStyle.StandardFixed3D
                PenT = New Drawing.Pen(SystemColors.ControlDark, 1.0F)
                PenL = New Drawing.Pen(SystemColors.ControlDark, 1.0F)
                PenB = New Drawing.Pen(SystemColors.ControlLightLight, 1.0F)
                PenR = New Drawing.Pen(SystemColors.ControlLightLight, 1.0F)
                PenWidth = CInt(Pens.White.Width)
            Case eBorderStyle.StandardSingle
                PenT = Drawing.Pens.Black : PenL = Drawing.Pens.Black : PenB = Drawing.Pens.Black : PenR = Drawing.Pens.Black
                PenWidth = CInt(Pens.White.Width)
            Case eBorderStyle.CustomSingle
                PenT = New Drawing.Pen(mBorderColorSingle, mBorderWidth)
                PenL = New Drawing.Pen(mBorderColorSingle, mBorderWidth)
                PenB = New Drawing.Pen(mBorderColorSingle, mBorderWidth)
                PenR = New Drawing.Pen(mBorderColorSingle, mBorderWidth)
                PenWidth = mBorderWidth
            Case eBorderStyle.Custom3D
                PenWidth = mBorderWidth
                Select Case mLightSource
                    Case eLightSource.TopLeft
                        PenT = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenL = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenB = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenR = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                    Case eLightSource.TopRight
                        PenT = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenL = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenB = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenR = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                    Case eLightSource.BottomLeft
                        PenT = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenL = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenB = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenR = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                    Case eLightSource.BottomRight
                        PenT = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenL = New Drawing.Pen(mBorderColor3DLight, mBorderWidth)
                        PenB = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                        PenR = New Drawing.Pen(mBorderColor3DDark, mBorderWidth)
                End Select
        End Select


        With Me.ClientRectangle
            g.DrawLine(PenT, New Drawing.Point(.Left, .Top), _
                        New Drawing.Point(.Width - PenWidth, .Top))
            g.DrawLine(PenL, New Drawing.Point(.Left, .Top), _
                        New Drawing.Point(.Left, .Height - PenWidth))
            g.DrawLine(PenB, New Drawing.Point(.Left, .Height - PenWidth), _
                        New Drawing.Point(.Width - PenWidth, .Height - PenWidth))
            g.DrawLine(PenR, New Drawing.Point(.Width - PenWidth, .Top), _
                        New Drawing.Point(.Width - PenWidth, .Height - PenWidth))
        End With

        Try
            PenB.Dispose()
            PenL.Dispose()
            PenR.Dispose()
            PenT.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    <Category("Appearance"), DefaultValue(GetType(Color), "ControlDark"), _
Description("The background color of the ProgressBar.")> _
    Public Property BackColor1() As Color
        Get
            Return mbackcolor1
        End Get
        Set(ByVal Value As Color)
            mbackcolor1 = Value
            MyBase.ForeColor = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance"), DefaultValue(GetType(Color), "ControlLight"), _
    Description("The background end color of the ProgressBar in Gradient mode.")> _
    Public Property BackColor2() As Color
        Get
            Return mbackcolor2
        End Get
        Set(ByVal Value As Color)
            mbackcolor2 = Value
            MyBase.BackColor = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance"), DefaultValue(eBorderStyle.StandardFixed3D), _
    Description("Indicates whether or not the ProgressBar should have a border.")> _
    Public Property BorderStyle() As eBorderStyle
        Get
            Return mborderstyle
        End Get
        Set(ByVal Value As eBorderStyle)
            mborderstyle = Value
            Me.Invalidate()
        End Set
    End Property


    <Category("Appearance"), DefaultValue(ColorStyle.Solid), _
    Description("The background color style of the ProgressBar.")> _
    Public Property BackColorStyle() As ColorStyle
        Get
            Return mbackcolorstyle
        End Get
        Set(ByVal Value As ColorStyle)
            mbackcolorstyle = Value
            Me.Invalidate()
        End Set
    End Property



    <Category("Appearance"), DefaultValue(LinearGradientMode.Horizontal), _
    Description("The direction of the background gradient fill in Gradient mode.")> _
    Public Property BackGradientMode() As LinearGradientMode
        Get
            Return mbackgradientmode
        End Get
        Set(ByVal Value As LinearGradientMode)
            mbackgradientmode = Value
            Me.Invalidate()
        End Set
    End Property



    <Category("Appearance"), DefaultValue(50), _
    Description("A value from 0 through 100 that specifies the center of the background gradient in SigmaBell mode.")> _
    Public Property BackSigmaFocus() As Integer
        Get
            Return CInt(mbacksigmafocus * 100.0F)
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 Then : mbacksigmafocus = 0.0F
            ElseIf Value > 100 Then : mbacksigmafocus = 1.0F
            Else : mbacksigmafocus = CSng(Value / 100.0F) : End If
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance"), DefaultValue(100), _
    Description("A value from 0 through 100 that specifies how fast the background color falls off from the focus in SigmaBell mode.")> _
    Public Property BackSigmaScale() As Integer
        Get
            Return CInt(mbacksigmascale * 100.0F)
        End Get
        Set(ByVal Value As Integer)
            If Value < 0 Then : mbacksigmascale = 0.0F
            ElseIf Value > 100 Then : mbacksigmascale = 1.0F
            Else : mbacksigmascale = CSng(Value / 100.0F) : End If
            Me.Invalidate()
        End Set
    End Property



    <Category("Appearance"), DefaultValue(SigmaMode.None), _
    Description("When set to SigmaBell, creates a background gradient falloff based on a bell-shaped curve using the BackSigmaFocus and BackSigmaScale values.")> _
    Public Property BackSigmaMode() As SigmaMode
        Get
            Return mbacksigmamode
        End Get
        Set(ByVal Value As SigmaMode)
            mbacksigmamode = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance"), DefaultValue(GetType(Color), "Color.Black"), _
Description("Border Color for Border Type 'CustomSingle'")> _
    Public Property BorderColorSingle() As Color
        Get
            Return mBorderColorSingle
        End Get
        Set(ByVal Value As Color)
            mBorderColorSingle = Value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DefaultValue(GetType(Color), "SystemColors.ControlDark"), _
Description("Dark Border Color for Border Type 'Custom3d'")> _
    Public Property BorderColor3DDark() As Color
        Get
            Return mBorderColor3DDark
        End Get
        Set(ByVal Value As Color)
            mBorderColor3DDark = Value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DefaultValue(GetType(Color), "SystemColors.ControlLight"), _
Description("Light Border Color for Border Type 'Custom3d'")> _
    Public Property BorderColor3DLight() As Color
        Get
            Return mBorderColor3DLight
        End Get
        Set(ByVal Value As Color)
            mBorderColor3DLight = Value
            Me.Invalidate()
        End Set
    End Property
    'Private mLightSource As eLightSource = eLightSource.TopLeft
    <Category("Appearance"), DefaultValue(eLightSource.TopLeft), _
Description("Light Source location for Border Type 'Custom3d'")> _
    Public Property LightSource() As eLightSource
        Get
            Return mLightSource
        End Get
        Set(ByVal Value As eLightSource)
            mLightSource = Value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance"), DefaultValue(GetType(Integer), "1"), _
Description("Border Width for Custom Borders Style")> _
    Public Property BorderWidth() As Integer
        Get
            Return mBorderWidth
        End Get
        Set(ByVal Value As Integer)
            mBorderWidth = Value
            Me.Invalidate()
        End Set
    End Property

    Public Property SelRange As PointF
        Get
            Return mSelRange
        End Get
        Set(ByVal value As PointF)
            mSelRange = value
            Me.Invalidate()
        End Set
    End Property
    Public Property MaxValue As Long
        Get
            Return mMaxValue
        End Get
        Set(ByVal value As Long)
            mMaxValue = value
            Me.Invalidate()
        End Set
    End Property
    Public Property Value As Long
        Get
            Return mValue
        End Get
        Set(ByVal value As Long)
            mValue = value
            Me.Invalidate()
        End Set
    End Property
    ' Private mBorderWidth As Integer = 1
    '  Private mBorderColorSingle As Color = Color.Black
    '   Private mBorderColor3DDark As Color = SystemColors.ControlDark
    '    Private mBorderColor3DLight As Color = SystemColors.ControlLightLight

    <Browsable(False)> _
    Shadows Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    <Browsable(False)> _
    Shadows Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)

        End Set
    End Property

    <Browsable(False)> _
    Shadows Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    <Browsable(False)> _
    Shadows Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)

        End Set
    End Property
    Public Sub AdjustValue(ByVal adj As Long)
        If mValue + adj > mMaxValue Then
            Me.Value = mMaxValue
        ElseIf mValue + adj < 0 Then
            Me.Value = 0
        Else
            Me.Value = mValue + adj
        End If
    End Sub
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property
    Public Function MSToString(ByVal lTime As Long) As String
        Dim ts As New TimeSpan(lTime * TimeSpan.TicksPerMillisecond)
        Return Strings.Right("0" & ts.Hours, 2) & ":" & Strings.Right("0" & ts.Minutes, 2) & ":" & Strings.Right("0" & ts.Seconds, 2) & "." & Strings.Right("00" & ts.Milliseconds, 3)
    End Function
End Class
