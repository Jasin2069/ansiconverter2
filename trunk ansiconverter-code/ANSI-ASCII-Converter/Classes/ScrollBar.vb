Imports System.Runtime.InteropServices.Marshal
Imports System.Windows.Forms
Public Class ScrollBar
    Inherits Windows.Forms.Control

    Public Enum eOrientation
        Vertical = 1
        Horizontal = 2
    End Enum
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private WithEvents pScrollbar1 As System.Windows.Forms.Panel
    Private WithEvents btnDownBig1 As System.Windows.Forms.Button
    Private WithEvents btnUpBig1 As System.Windows.Forms.Button
    Private WithEvents btnDown1 As System.Windows.Forms.Button
    Private WithEvents btnUp1 As System.Windows.Forms.Button
    Private WithEvents pMiddle1 As System.Windows.Forms.Panel
    Private WithEvents btnMiddle1 As System.Windows.Forms.Button
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Private OrgControlHeight As Integer = 327
    Private OrgControlWidth As Integer = 24

    Private m_Action As String = ""
    Private m_MouseDown As Boolean = False

    Private m_TimeInit As Integer = 90
    Private m_TimeDecrement As Integer = 1
    Private m_TimeDecIntervall As Integer = 9
    Private m_TimeMin As Integer = 5
    Private m_IntervallCount As Integer = 0

    Private m_ScrollMouseDown As Boolean = False
    Private m_position As Point
    Private m_delta As Point

    Private ListScrollbarButtons As New List(Of Windows.Forms.Button)
    Private ListScrollBarButtonsOrgHeight As New List(Of Integer)
    Private ListScrollBarButtonsOrgFontSize As New List(Of Integer)

    Private DGridView As New Windows.Forms.DataGridView

    Private PositionUpdating As Boolean = False
    Private p_ScrollBarBackColor As Drawing.Color = System.Drawing.Color.Navy
    Private p_UpBtnImage As Image = New Bitmap(1, 1)
    Private p_UpBtnImageHover As Image = New Bitmap(1, 1)
    Private p_UpBtnImageClick As Image = New Bitmap(1, 1)
    Private p_DnBtnImage As Image = New Bitmap(1, 1)
    Private p_DnBtnImageHover As Image = New Bitmap(1, 1)
    Private p_DnBtnImageClick As Image = New Bitmap(1, 1)
    Private p_UpDnBtnsForeColor As Drawing.Color = Color.FromArgb(255, 128, 128, 255)
    Private p_UpDnBtnsBackColor As Drawing.Color = Color.FromArgb(255, 65, 105, 255)
    Private p_UpDownBigBtnsForeColor As Drawing.Color = Color.FromArgb(255, 192, 192, 255)
    Private p_UpDownBigBtnsBackColor As Drawing.Color = Color.FromArgb(255, 50, 50, 255)
    Private p_MiddleBtnColor As Drawing.Color = Color.FromArgb(255, 192, 0, 0)

    Private p_ObjectSize As Long = 100
    Private p_ObjectScale As Integer = 100
    Private p_UpdateUnitSize As Double = 1
    Private p_ObjectVisibleRange As Long = 10
    Private p_ObjectScrollPosition As Long = 0

    Private p_Orient As eOrientation = eOrientation.Vertical

    Private p_BtnUpLabel As Integer = 9651
    Private p_BtnDnLabel As Integer = 9661
    Private p_BtnLtLabel As Integer = 9665
    Private p_BtnRtLabel As Integer = 9655

    Private p_BtnIncLabel As Integer = 9651
    Private p_BtnDecLabel As Integer = 9661

    Public Delegate Sub actionAbsolutePositionChangedEventHandler(ByVal sender As System.Object, ByVal position As System.Double)
    Public Delegate Sub actionIncrementalPositionChangedUpEventHandler(ByVal sender As System.Object, ByVal change As System.Double)
    Public Delegate Sub actionIncrementalPositionChangedDownEventHandler(ByVal sender As System.Object, ByVal change As System.Double)

    Public Event actionAbsolutePositionChanged As actionAbsolutePositionChangedEventHandler
    Public Event actionIncrementalPositionChangedUp As actionIncrementalPositionChangedUpEventHandler
    Public Event actionIncrementalPositionChangedDown As actionIncrementalPositionChangedDownEventHandler

    Public Property ObjectSize() As Long
        Get
            Return p_ObjectSize
        End Get
        Set(ByVal value As Long)
            If p_ObjectSize <> value And value > 0 Then
                p_ObjectSize = value
                p_UpdateUnitSize = Math.Round(p_ObjectSize / p_ObjectScale, 5)
            End If
        End Set
    End Property
    Public Property Orientation() As eOrientation
        Get
            Return p_Orient
        End Get
        Set(ByVal value As eOrientation)
            If p_Orient <> value Then
                p_Orient = value
                FlipOver()
                Select Case p_Orient
                    Case eOrientation.Horizontal
                        p_BtnDecLabel = p_BtnLtLabel
                        p_BtnIncLabel = p_BtnRtLabel
                    Case eOrientation.Vertical
                        p_BtnDecLabel = p_BtnDnLabel
                        p_BtnIncLabel = p_BtnUpLabel
                End Select
            End If
        End Set
    End Property
    Public Property ObjectScale() As Long
        Get
            Return p_ObjectScale
        End Get
        Set(ByVal value As Long)
            If p_ObjectScale <> value And value > 0 Then
                p_ObjectScale = value
                p_UpdateUnitSize = Math.Round(p_ObjectSize / p_ObjectScale, 5)
            End If
        End Set
    End Property
    Public Property ObjectVisibleRange() As Long
        Get
            Return p_ObjectVisibleRange
        End Get
        Set(ByVal value As Long)
            If p_ObjectVisibleRange <> value And p_ObjectVisibleRange > 0 And p_ObjectVisibleRange < p_ObjectSize Then
                p_ObjectVisibleRange = value
            End If
        End Set
    End Property
    Public ReadOnly Property UpdateUnitSize() As Double
        Get
            Return p_UpdateUnitSize
        End Get
    End Property

    Public Property MiddleBtnColor() As Drawing.Color
        Get
            Return p_MiddleBtnColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(p_MiddleBtnColor) Then
                p_MiddleBtnColor = value
                Me.btnMiddle1.BackColor = p_MiddleBtnColor
                Me.btnMiddle1.ForeColor = p_MiddleBtnColor
                Me.btnMiddle1.FlatAppearance.BorderColor = ColorSubtract(p_MiddleBtnColor, Color.FromArgb(0, 20, 20, 20))
                Me.btnMiddle1.FlatAppearance.MouseDownBackColor = ColorAdd(p_MiddleBtnColor, Color.FromArgb(0, 100, 100, 100))
                Me.btnMiddle1.FlatAppearance.MouseOverBackColor = ColorAdd(p_MiddleBtnColor, Color.FromArgb(0, 50, 50, 50))
            End If
        End Set
    End Property
    Public Property UpDnBtnsBackColor() As Drawing.Color
        Get
            Return p_UpDnBtnsBackColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(p_UpDnBtnsBackColor) Then
                p_UpDnBtnsBackColor = value
                Me.btnUp1.BackColor = p_UpDnBtnsBackColor
                Me.btnDown1.BackColor = p_UpDnBtnsBackColor
                Me.btnUp1.FlatAppearance.BorderColor = ColorSubtract(p_UpDnBtnsBackColor, Color.FromArgb(0, 20, 20, 20))
                Me.btnUp1.FlatAppearance.MouseDownBackColor = ColorAdd(p_UpDnBtnsBackColor, Color.FromArgb(0, 100, 100, 100))
                Me.btnUp1.FlatAppearance.MouseOverBackColor = ColorAdd(p_UpDnBtnsBackColor, Color.FromArgb(0, 50, 50, 50))
                Me.btnDown1.FlatAppearance.BorderColor = ColorSubtract(p_UpDnBtnsBackColor, Color.FromArgb(0, 20, 20, 20))
                Me.btnDown1.FlatAppearance.MouseDownBackColor = ColorAdd(p_UpDnBtnsBackColor, Color.FromArgb(0, 100, 100, 100))
                Me.btnDown1.FlatAppearance.MouseOverBackColor = ColorAdd(p_UpDnBtnsBackColor, Color.FromArgb(0, 50, 50, 50))
            End If
        End Set
    End Property
    Public Property UpDownBigBtnsBackColor() As Drawing.Color
        Get
            Return p_UpDownBigBtnsBackColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(p_UpDownBigBtnsBackColor) Then
                p_UpDownBigBtnsBackColor = value
                Me.btnUpBig1.BackColor = p_UpDownBigBtnsBackColor
                Me.btnDownBig1.BackColor = p_UpDownBigBtnsBackColor
                Me.btnUpBig1.FlatAppearance.BorderColor = ColorSubtract(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 20, 20, 20))
                Me.btnUpBig1.FlatAppearance.MouseDownBackColor = ColorAdd(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 100, 100, 100))
                Me.btnUpBig1.FlatAppearance.MouseOverBackColor = ColorAdd(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 50, 50, 50))
                Me.btnDownBig1.FlatAppearance.BorderColor = ColorSubtract(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 20, 20, 20))
                Me.btnDownBig1.FlatAppearance.MouseDownBackColor = ColorAdd(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 100, 100, 100))
                Me.btnDownBig1.FlatAppearance.MouseOverBackColor = ColorAdd(p_UpDownBigBtnsBackColor, Color.FromArgb(0, 50, 50, 50))
            End If
        End Set
    End Property
    Public Property UpDnBtnsForeColor() As Drawing.Color
        Get
            Return p_UpDnBtnsForeColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(p_UpDnBtnsForeColor) Then
                p_UpDnBtnsForeColor = value
                Me.btnUp1.ForeColor = p_UpDnBtnsForeColor
                Me.btnDown1.ForeColor = p_UpDnBtnsForeColor
            End If
        End Set
    End Property
    Public Property UpDownBigBtnsForeColor() As Drawing.Color
        Get
            Return p_UpDownBigBtnsForeColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(p_UpDownBigBtnsForeColor) Then
                p_UpDownBigBtnsForeColor = value
                Me.btnUpBig1.ForeColor = p_UpDownBigBtnsForeColor
                Me.btnDownBig1.ForeColor = p_UpDownBigBtnsForeColor
            End If
        End Set
    End Property
    Public Sub SetDataGridviewControl(ByRef DGV As Windows.Forms.DataGridView)
        If Me.DGridView.Equals(DGV) = False Then
            Me.DGridView = DGV
            Try
                RemoveHandler Me.DGridView.RowsRemoved, AddressOf Me.DataGridRowsCountChange
                RemoveHandler Me.DGridView.RowsAdded, AddressOf Me.DataGridRowsCountChange
                RemoveHandler Me.DGridView.Scroll, AddressOf Me.DataGridRowsCountChange
            Catch ex As Exception

            End Try
            AddHandler Me.DGridView.RowsRemoved, AddressOf Me.DataGridRowsCountChange
            AddHandler Me.DGridView.RowsAdded, AddressOf Me.DataGridRowsCountChange
            AddHandler Me.DGridView.Scroll, AddressOf Me.DataGridRowsCountChange
            Me.DataGridRowsCountChange(Me.DGridView, Nothing)
        End If

    End Sub

    Public Property ScrollBarBackColor() As Drawing.Color
        Get
            Return p_ScrollBarBackColor
        End Get
        Set(ByVal value As Drawing.Color)
            If Not value.Equals(ScrollBarBackColor) Then
                p_ScrollBarBackColor = value
                Me.pScrollbar1.BackColor = ScrollBarBackColor
                Me.pMiddle1.ForeColor = ScrollBarBackColor
            End If
        End Set
    End Property
    Private Property UpBtnImage() As Image
        Get
            Return p_UpBtnImage
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_UpBtnImage) Then
                p_UpBtnImage = value
                Me.btnUp1.BackgroundImage = p_UpBtnImage
                If Not p_UpBtnImage Is Nothing Then
                    Me.btnUp1.Text = ""
                Else
                    Me.btnUp1.Text = ChrW(9651)
                End If
            End If
        End Set
    End Property
    Private Property DnBtnImage() As Image
        Get
            Return p_DnBtnImage
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_DnBtnImage) Then
                p_DnBtnImage = value
                Me.btnDown1.BackgroundImage = p_DnBtnImage
                If Not p_DnBtnImage Is Nothing Then
                    Me.btnDown1.Text = ""
                Else
                    Me.btnDown1.Text = ChrW(9661)
                End If
            End If
        End Set
    End Property
    Private Property UpBtnImageHover() As Image
        Get
            Return p_UpBtnImageHover
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_UpBtnImageHover) Then
                p_UpBtnImageHover = value
            End If
        End Set
    End Property
    Private Property UpBtnImageClick() As Image
        Get
            Return p_UpBtnImageClick
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_UpBtnImageClick) Then
                p_UpBtnImageClick = value
            End If
        End Set
    End Property
    Private Property DnBtnImageHover() As Image
        Get
            Return p_DnBtnImageHover
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_DnBtnImageHover) Then
                p_DnBtnImageHover = value
            End If
        End Set
    End Property
    Private Property DnBtnImageClick() As Image
        Get
            Return p_DnBtnImageClick
        End Get
        Set(ByVal value As Image)
            If Not value.Equals(p_DnBtnImageClick) Then
                p_DnBtnImageClick = value
            End If
        End Set
    End Property
    Private Sub ControlResize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Dim scalefactor As Double = 1
        If p_Orient = eOrientation.Vertical Then
            scalefactor = Me.Height / OrgControlHeight
            Me.pScrollbar1.Width = Me.Width
            Me.pScrollbar1.Height = Me.Height
            Me.pMiddle1.Width = Me.pScrollbar1.Width
            For Each c As Control In Me.ListScrollbarButtons
                Dim b As Button = CType(c, Button)
                b.Width = pScrollbar1.Width
                b.Height = Me.ListScrollBarButtonsOrgHeight.Item(Me.ListScrollBarButtonsOrgHeight.FindIndex(Function(x) b.Equals(x))) * scalefactor
                Dim fnt As Font = New Font(b.Font.FontFamily, Me.ListScrollBarButtonsOrgFontSize.Item(Me.ListScrollBarButtonsOrgFontSize.FindIndex(Function(x) b.Equals(x))) * scalefactor, b.Font.Style, GraphicsUnit.Point)
                b.Font = fnt
            Next
            Dim btnHeights As Integer = Me.btnUpBig1.Height + Me.btnUp1.Height + 4
            Me.btnUpBig1.Top = 0
            Me.btnUp1.Top = Me.btnUpBig1.Height + 2
            Me.btnDownBig1.Top = Me.pScrollbar1.Height - Me.btnDownBig1.Height
            Me.btnDown1.Top = Me.btnDownBig1.Top - Me.btnDown1.Height - 2
            Me.pMiddle1.Top = btnHeights
            Me.pMiddle1.Height = Me.pScrollbar1.Height - (btnHeights * 2)
        Else
            scalefactor = Me.Width / OrgControlWidth
            Me.pScrollbar1.Height = Me.Height
            Me.pScrollbar1.Width = Me.Width
            Me.pMiddle1.Height = Me.pScrollbar1.Height
            For Each c As Control In Me.ListScrollbarButtons
                Dim b As Button = CType(c, Button)
                b.Height = pScrollbar1.Height
                b.Width = Me.ListScrollBarButtonsOrgHeight.Item(Me.ListScrollBarButtonsOrgHeight.FindIndex(Function(x) b.Equals(x))) * scalefactor
                Dim fnt As Font = New Font(b.Font.FontFamily, Me.ListScrollBarButtonsOrgFontSize.Item(Me.ListScrollBarButtonsOrgFontSize.FindIndex(Function(x) b.Equals(x))) * scalefactor, b.Font.Style, GraphicsUnit.Point)
                b.Font = fnt
            Next
            Dim btnHeights As Integer = Me.btnUpBig1.Width + Me.btnUp1.Width + 4
            Me.btnUpBig1.Left = 0
            Me.btnUp1.Left = Me.btnUpBig1.Width + 2
            Me.btnDownBig1.Left = Me.pScrollbar1.Width - Me.btnDownBig1.Width
            Me.btnDown1.Left = Me.btnDownBig1.Left - Me.btnDown1.Width - 2
            Me.pMiddle1.Left = btnHeights
            Me.pMiddle1.Width = Me.pScrollbar1.Width - (btnHeights * 2)
        End If
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        Me.InitializeComponent()
        p_UpBtnImage = Nothing
        p_UpBtnImageHover = Nothing
        p_UpBtnImageClick = Nothing
        p_DnBtnImage = Nothing
        p_DnBtnImageHover = Nothing
        p_DnBtnImageClick = Nothing

        Me.ListScrollbarButtons.Add(Me.btnUpBig1)
        Me.ListScrollBarButtonsOrgHeight.Add(10)
        ListScrollBarButtonsOrgFontSize.Add(9)
        Me.ListScrollbarButtons.Add(Me.btnUp1)
        Me.ListScrollBarButtonsOrgHeight.Add(20)
        ListScrollBarButtonsOrgFontSize.Add(9)
        Me.ListScrollbarButtons.Add(Me.btnMiddle1)
        Me.ListScrollBarButtonsOrgHeight.Add(20)
        ListScrollBarButtonsOrgFontSize.Add(9)
        Me.ListScrollbarButtons.Add(Me.btnDown1)
        Me.ListScrollBarButtonsOrgHeight.Add(20)
        ListScrollBarButtonsOrgFontSize.Add(9)
        Me.ListScrollbarButtons.Add(Me.btnDownBig1)
        Me.ListScrollBarButtonsOrgHeight.Add(10)
        ListScrollBarButtonsOrgFontSize.Add(9)
        ' Add any initialization after the InitializeComponent() call.
        For Each c As Control In Me.ListScrollbarButtons
            Dim b As Button = CType(c, Button)
            AddHandler b.MouseEnter, AddressOf Me.btn_MouseEnter
            AddHandler b.MouseLeave, AddressOf Me.btn_MouseLeave
            AddHandler b.MouseUp, AddressOf Me.Scrollbar_MouseUpEvent
            AddHandler b.MouseDown, AddressOf Me.Scrollbar_MouseDownEvent
            With b
                .Cursor = Cursors.Hand
            End With
        Next
        'AddHandler Me.pMiddle1.MouseMove, AddressOf MouseScrollMove
        AddHandler Me.pMiddle1.Click, AddressOf Me.positionofmousecheck
        ' Me.Timer1.Enabled = False
        AddHandler Me.Timer1.Tick, AddressOf Me.Timer1_Tick

        'Me.MyForm = Me.TopLevelControl
    End Sub

    Private Sub DataGridRowsCountChange(ByVal sender As Object, ByVal e As EventArgs)
        Dim bGrid As Boolean = True
        If Me.DGridView Is Nothing Then
            bGrid = False
        End If
        Dim lPcntScrolled As Double = 0, lScrollPos As Double = 0
        Dim btnHalfSize As Integer = 0, btnMiddlePos As Integer = 0, iBtnHeight As Integer = 0, iNumRowsVisible As Long = 0
        Dim iRowCount As Long = 0

        If p_Orient = eOrientation.Vertical Then
            If bGrid Then iRowCount = Me.DGridView.RowCount
        Else
            If bGrid Then iRowCount = Me.DGridView.ColumnCount
        End If
        If Not bGrid Then iRowCount = p_ObjectScale


        If iRowCount = 0 Then
            Me.btnMiddle1.Visible = False
        Else
            '  Console.WriteLine("-------------- cycle starts ---------------")
            Me.btnMiddle1.Visible = True
            If p_Orient = eOrientation.Vertical Then
                If bGrid Then
                    iNumRowsVisible = (Me.DGridView.Height - Me.DGridView.ColumnHeadersHeight) / Me.DGridView.Rows(0).Height
                    'Height of pMiddle1
                    iBtnHeight = (Me.pMiddle1.Height * iNumRowsVisible) / Me.DGridView.RowCount
                Else
                    iNumRowsVisible = p_ObjectVisibleRange
                    iBtnHeight = (Me.pMiddle1.Height * p_ObjectVisibleRange) / p_ObjectSize
                End If
            Else
                If bGrid Then
                    iNumRowsVisible = (Me.DGridView.Width - Me.DGridView.RowHeadersWidth) / Me.DGridView.Columns(0).Width
                    'Height of pMiddle1
                    iBtnHeight = (Me.pMiddle1.Width * iNumRowsVisible) / Me.DGridView.ColumnCount
                Else
                    iNumRowsVisible = p_ObjectVisibleRange
                    iBtnHeight = (Me.pMiddle1.Width * p_ObjectVisibleRange) / p_ObjectSize
                End If
            End If

            'Console.WriteLine("iBtnHeight=" & iBtnHeight & ", iNumRowsVisible=" & iNumRowsVisible)


            If iBtnHeight = 0 Then : iBtnHeight = 2 : End If
            Me.btnMiddle1.Height = iBtnHeight
            'Now location
            Dim iFirstDispIndex As Long = 0
            '
            If bGrid Then
                If p_Orient = eOrientation.Vertical Then
                    iFirstDispIndex = Me.DGridView.FirstDisplayedScrollingRowIndex
                Else
                    iFirstDispIndex = Me.DGridView.FirstDisplayedScrollingColumnIndex
                End If

            Else
                iFirstDispIndex = p_ObjectScrollPosition
            End If
            If iFirstDispIndex = 0 Then
                If p_Orient = eOrientation.Vertical Then
                    Me.btnMiddle1.Top = 0
                Else
                    Me.btnMiddle1.Left = 0
                End If
                ' Console.WriteLine("Top of the list")
            Else
                If bGrid Then
                    If p_Orient = eOrientation.Vertical Then
                        lPcntScrolled = (Me.DGridView.FirstDisplayedScrollingRowIndex * 100) / Me.DGridView.RowCount
                    Else
                        lPcntScrolled = (Me.DGridView.FirstDisplayedScrollingColumnIndex * 100) / Me.DGridView.ColumnCount
                    End If

                Else
                    lPcntScrolled = (p_ObjectScrollPosition * 100) / p_ObjectScale
                End If

                If p_Orient = eOrientation.Vertical Then
                    lScrollPos = (Me.pMiddle1.Height * lPcntScrolled) / 100
                    btnHalfSize = Me.btnMiddle1.Height / 2 : btnMiddlePos = Me.btnMiddle1.Top + btnHalfSize
                    If (lScrollPos < btnHalfSize) Then
                        '  Console.WriteLine("lScrollPos < btnHalfSize, pos = 0")
                        Me.btnMiddle1.Top = 0
                    Else
                        If (lScrollPos > (Me.pMiddle1.Height - btnHalfSize)) Then
                            Me.btnMiddle1.Top = Me.pMiddle1.Height - Me.btnMiddle1.Height
                            'Console.WriteLine(" lScrollPos > (p-height - btnMiddlePos), top = p-height - btn-height")
                        Else
                            Me.btnMiddle1.Top = lScrollPos - btnHalfSize
                            ' Console.WriteLine("else")
                        End If
                    End If
                Else
                    lScrollPos = (Me.pMiddle1.Width * lPcntScrolled) / 100
                    btnHalfSize = Me.btnMiddle1.Width / 2 : btnMiddlePos = Me.btnMiddle1.Left + btnHalfSize
                    If (lScrollPos < btnHalfSize) Then
                        '  Console.WriteLine("lScrollPos < btnHalfSize, pos = 0")
                        Me.btnMiddle1.Left = 0
                    Else
                        If (lScrollPos > (Me.pMiddle1.Width - btnHalfSize)) Then
                            Me.btnMiddle1.Left = Me.pMiddle1.Width - Me.btnMiddle1.Width
                            'Console.WriteLine(" lScrollPos > (p-height - btnMiddlePos), top = p-height - btn-height")
                        Else
                            Me.btnMiddle1.Left = lScrollPos - btnHalfSize
                            ' Console.WriteLine("else")
                        End If
                    End If

                End If

                'Console.WriteLine("lPcntScrolled = " & lPcntScrolled & ", lScrollPos = " & lScrollPos & ", btnHalfSize = " & btnHalfSize & ", btnMiddlePos = " & btnMiddlePos)


            End If
        End If
    End Sub
    Private Sub btn_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.BackColor = ColorAdd(sender.BackColor, Drawing.Color.FromArgb(0, 32, 32, 32))
        If sender.name = "btnUp1" Then
            Me.btnUp1.BackgroundImage = p_UpBtnImageHover
            If Not p_UpBtnImageHover Is Nothing Then
                Me.btnUp1.Text = ""
            Else
                Me.btnUp1.Text = ChrW(p_BtnIncLabel)
            End If
        End If
        If sender.name = "btnDown1" Then
            Me.btnDown1.BackgroundImage = p_DnBtnImageHover
            If Not p_DnBtnImageHover Is Nothing Then
                Me.btnDown1.Text = ""
            Else
                Me.btnDown1.Text = ChrW(p_BtnDecLabel)
            End If
        End If
        sender.Refresh()
    End Sub
    Private Sub btn_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.BackColor = ColorSubtract(sender.BackColor, Drawing.Color.FromArgb(0, 32, 32, 32))
        If sender.name = "btnUp1" Then
            Me.btnUp1.BackgroundImage = p_UpBtnImage
            If Not p_UpBtnImage Is Nothing Then
                Me.btnUp1.Text = ""
            Else
                Me.btnUp1.Text = ChrW(p_BtnIncLabel)
            End If
        End If
        If sender.name = "btnDown1" Then
            Me.btnDown1.BackgroundImage = p_DnBtnImage
            If Not p_DnBtnImage Is Nothing Then
                Me.btnDown1.Text = ""
            Else
                Me.btnDown1.Text = ChrW(p_BtnDecLabel)
            End If
        End If
        sender.Refresh()

        '        Call Scrollbar_MouseUpEvent(sender, e)
    End Sub
    Private Function ColorAdd(ByVal col1 As Drawing.Color, ByVal col2 As Drawing.Color) As Drawing.Color
        Return Drawing.Color.FromArgb(ByteValueCheck(CInt(col1.A) + CInt(col2.A)), ByteValueCheck(CInt(col1.R) + CInt(col2.R)), ByteValueCheck(CInt(col1.G) + CInt(col2.G)), ByteValueCheck(CInt(col1.B) + CInt(col2.B)))
    End Function
    Private Function ColorSubtract(ByVal col1 As Drawing.Color, ByVal col2 As Drawing.Color) As Drawing.Color
        Return Drawing.Color.FromArgb(ByteValueCheck(CInt(col1.A) - CInt(col2.A)), ByteValueCheck(CInt(col1.R) - CInt(col2.R)), ByteValueCheck(CInt(col1.G) - CInt(col2.G)), ByteValueCheck(CInt(col1.B) - CInt(col2.B)))
    End Function
    Private Function ByteValueCheck(ByVal b As Integer) As Byte
        If b > 255 Then
            Return 255
        Else
            If b < 0 Then
                Return 0
            Else
                Return CByte(b)
            End If
        End If
    End Function
    Private Sub DebugMousePos(ByVal e As MouseEventArgs)
        If bDebug = True Then Console.WriteLine("      m = " & m_position.ToString & " | c = " & Cursor.Position.ToString & " | l = " & e.Location.ToString & " | x = " & MousePosition.ToString)
        If bDebug = True Then Console.WriteLine("x | PTC = " & Me.PointToClient(MousePosition).ToString & " | PTS = " & Me.PointToScreen(MousePosition).ToString)
        If bDebug = True Then Console.WriteLine("m | PTC = " & Me.PointToClient(m_position).ToString & " | PTS = " & Me.PointToScreen(m_position).ToString)
        If bDebug = True Then Console.WriteLine("c | PTC = " & Me.PointToClient(Cursor.Position).ToString & " | PTS = " & Me.PointToScreen(Cursor.Position).ToString)
        If bDebug = True Then Console.WriteLine("l | PTC = " & Me.PointToClient(e.Location).ToString & " | PTS = " & Me.PointToScreen(e.Location).ToString)
        If bDebug = True Then Console.WriteLine("...")
        If bDebug = True Then Console.WriteLine("p = " & Me.pMiddle1.Location.ToString)
        If bDebug = True Then Console.WriteLine("p | PTC = " & Me.PointToClient(Me.pMiddle1.Location).ToString & " | PTS = " & Me.PointToScreen(Me.pMiddle1.Location).ToString)
        If bDebug = True Then Console.WriteLine("...")
    End Sub
    Private Sub positionofmousecheck(ByVal sender As Object, ByVal e As MouseEventArgs)
        'm_delta = m_position - Cursor.Position 'e.Location
        'm_position = Cursor.Position 'e.Location
        'Console.WriteLine("Y:" & e.Location.Y.ToString)

        Me.ScrollToPosition(e.Location.Y)
        'Call DebugMousePos(e)

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_MouseDown = True And CStr(m_Action) = "2" Then
            Dim btnHalfSize As Integer
            If p_Orient = eOrientation.Vertical Then
                btnHalfSize = Me.btnMiddle1.Height / 2
            Else
                btnHalfSize = Me.btnMiddle1.Width / 2
            End If

            Me.m_delta = Me.m_position - Me.pMiddle1.PointToClient(MousePosition) 'Cursor.Position 'e.Location
            'MousePosition.X, MousePosition.Y
            Me.m_position = Me.pMiddle1.PointToClient(MousePosition) 'Cursor.Position 'e.Location
            If p_Orient = eOrientation.Vertical Then
                Me.m_position.Y += btnHalfSize
            Else
                Me.m_position.X += btnHalfSize
            End If

            Dim et As MouseEventArgs = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, Me.m_position.X, Me.m_position.Y, 0)
            'Call DebugMousePos(et)
            If p_Orient = eOrientation.Vertical Then
                If Me.m_position.Y < (Me.pMiddle1.Height) And Me.m_position.Y > 0 Then
                    Me.positionofmousecheck(pMiddle1, et)
                End If
            Else
                If Me.m_position.X < (Me.pMiddle1.Width) And Me.m_position.X > 0 Then
                    Me.positionofmousecheck(pMiddle1, et)
                End If
            End If
        End If


        Call Me.PerformScrollAction(m_Action)
        Me.m_IntervallCount += 1
        If Me.m_IntervallCount = Me.m_TimeDecIntervall Then
            Me.m_IntervallCount = 0
            If Me.Timer1.Interval >= Me.m_TimeMin + Me.m_TimeDecrement Then
                Me.Timer1.Interval -= Me.m_TimeDecrement
            Else
                Me.Timer1.Interval = Me.m_TimeMin
            End If
        End If
    End Sub


    Private Sub Scrollbar_MouseDownEvent(ByVal sender As Object, ByVal e As MouseEventArgs)

        'MsgBox(sender.parent.name)
        'MsgBox(sender.parent.parent.find("DataGridView1", False)(0).name)
        If sender.tag = "0" Then
            Me.m_position = Me.pMiddle1.PointToClient(MousePosition) 'Cursor.Position  'Me.PointToClient(MousePosition) ' Cursor.Position 'e.Location
            Me.m_delta = Me.m_position
            sender.cursor = Cursors.NoMoveVert
        End If

        Dim iFound As Integer = Me.ListScrollbarButtons.FindIndex(Function(x) sender.Equals(x))

        'ListScrollbarButtons1.find(sender.name, False)

        Me.m_MouseDown = True
        Me.m_Action = iFound
        Me.Timer1.Interval = Me.m_TimeInit
        Me.m_IntervallCount = 0
        Me.Timer1.Enabled = True


        Call Me.btn_MouseEnter(sender, EventArgs.Empty)
        Call Me.btn_MouseEnter(sender, EventArgs.Empty)
        Call Me.btn_MouseEnter(sender, EventArgs.Empty)
        If sender.name = "btnUp1" Then
            Me.btnUp1.BackgroundImage = p_UpBtnImageClick
            If Not p_UpBtnImageClick Is Nothing Then
                Me.btnUp1.Text = ""
            Else
                Me.btnUp1.Text = ChrW(p_BtnIncLabel)
            End If
        End If
        If sender.name = "btnDown1" Then
            Me.btnDown1.BackgroundImage = p_DnBtnImageClick
            If Not p_DnBtnImageClick Is Nothing Then
                Me.btnDown1.Text = ""
            Else
                Me.btnDown1.Text = ChrW(p_BtnDecLabel)
            End If
        End If
    End Sub
    Private Sub Scrollbar_MouseUpEvent(ByVal sender As Object, ByVal e As MouseEventArgs)
        Me.m_MouseDown = False
        Me.m_Action = -1
        Me.Timer1.Interval = Me.m_TimeInit
        Me.m_IntervallCount = 0
        Me.Timer1.Enabled = False
        sender.cursor = Cursors.Hand
        Call Me.btn_MouseLeave(sender, EventArgs.Empty)
        Call Me.btn_MouseLeave(sender, EventArgs.Empty)
        Call Me.btn_MouseLeave(sender, EventArgs.Empty)
        If sender.name = "btnUp1" Then
            Me.btnUp1.BackgroundImage = p_UpBtnImage
            If Not p_UpBtnImage Is Nothing Then
                Me.btnUp1.Text = ""
            Else
                Me.btnUp1.Text = ChrW(p_BtnIncLabel)
            End If
        End If
        If sender.name = "btnDown1" Then
            Me.btnDown1.BackgroundImage = p_DnBtnImage
            If Not p_DnBtnImage Is Nothing Then
                Me.btnDown1.Text = ""
            Else
                Me.btnDown1.Text = ChrW(p_BtnDecLabel)
            End If
        End If

    End Sub

    Private Sub PerformScrollAction(ByVal saction As String)
        Dim bGrid As Boolean = True
        If Me.DGridView Is Nothing Then
            bGrid = False
        End If
        Dim b As Button = Me.ListScrollbarButtons.Item(CType(saction, Integer))


        Dim dgv As DataGridView = Nothing
        If b.Tag = "0" Then
            'dgv = b.Parent.Parent.Parent.Controls.Find("DataGridView1", False)(0)
        Else
            'dgv = b.Parent.Parent.Controls.Find("DataGridView1", False)(0)
        End If
        If bGrid Then dgv = DGridView

        If dgv.Rows.Count = 0 Then
            'dgv.ScrollBars.Vertical.crollingOffset -= 5
            Exit Sub
        End If

        Select Case b.Tag
            Case "-1"  '"btnUpBig1"
                If bGrid Then
                    If p_Orient = eOrientation.Vertical Then
                        If dgv.FirstDisplayedScrollingRowIndex < 5 Then : dgv.FirstDisplayedScrollingRowIndex = 0 : Else : dgv.FirstDisplayedScrollingRowIndex -= 5 : End If
                    Else
                        If dgv.FirstDisplayedScrollingColumnIndex < 5 Then : dgv.FirstDisplayedScrollingColumnIndex = 0 : Else : dgv.FirstDisplayedScrollingColumnIndex -= 5 : End If
                    End If
                Else
                    If p_ObjectScrollPosition < 5 Then : p_ObjectScrollPosition = 0 : Else : p_ObjectScrollPosition -= 5 : End If
                End If
            Case "-5" '"btnUp1"
                If bGrid Then
                    If p_Orient = eOrientation.Vertical Then
                        If dgv.FirstDisplayedScrollingRowIndex < 2 Then : dgv.FirstDisplayedScrollingRowIndex = 0 : Else : dgv.FirstDisplayedScrollingRowIndex -= 1 : End If
                    Else
                        If dgv.FirstDisplayedScrollingColumnIndex < 2 Then : dgv.FirstDisplayedScrollingColumnIndex = 0 : Else : dgv.FirstDisplayedScrollingColumnIndex -= 1 : End If
                    End If
                Else
                    If p_ObjectScrollPosition < 2 Then : p_ObjectScrollPosition = 0 : Else : p_ObjectScrollPosition -= 1 : End If
                End If

            Case "0" '"btnMiddle1"
                '  MouseScrollMove(b, Nothing)
                If bDebug = True Then Console.WriteLine("btnMiddle action")
            Case "+1" '"btnDown1"
                If bGrid Then
                    If p_Orient = eOrientation.Vertical Then
                        If dgv.Rows.Count - dgv.FirstDisplayedScrollingRowIndex < 2 Then : dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1 : Else : dgv.FirstDisplayedScrollingRowIndex += 1 : End If
                    Else
                        If dgv.Rows.Count - dgv.FirstDisplayedScrollingColumnIndex < 2 Then : dgv.FirstDisplayedScrollingColumnIndex = dgv.Rows.Count - 1 : Else : dgv.FirstDisplayedScrollingColumnIndex += 1 : End If
                    End If

                Else
                    If p_ObjectScale - p_ObjectScrollPosition < 2 Then : p_ObjectScrollPosition = p_ObjectScale - 1 : Else : p_ObjectScrollPosition += 1 : End If
                End If

            Case "+5" '"btnDownBig1"
                If bGrid Then
                    If p_Orient = eOrientation.Vertical Then
                        If dgv.Rows.Count - dgv.FirstDisplayedScrollingRowIndex < 6 Then : dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1 : Else : dgv.FirstDisplayedScrollingRowIndex += 5 : End If
                    Else
                        If dgv.Rows.Count - dgv.FirstDisplayedScrollingColumnIndex < 6 Then : dgv.FirstDisplayedScrollingColumnIndex = dgv.Rows.Count - 1 : Else : dgv.FirstDisplayedScrollingColumnIndex += 5 : End If
                    End If

                Else
                    If p_ObjectScale - p_ObjectScrollPosition < 6 Then : p_ObjectScrollPosition = p_ObjectScale - 1 : Else : p_ObjectScrollPosition += 5 : End If
                End If
                '    scrollControl(sender..Handle, eScrollDirection.Vertical, eScrollAction.Relitive, 50)
        End Select
    End Sub

    'Scroll Bar Changes
    'Changes of Middle Button, Size and Position
    'Change in Top visible record in scrollable list
    '
    'Triggers
    '1. List changes: New Records, Del Records (size of middle button affected), Positioning of the top record visible 
    '2. Scroll (e.g. using keyboard, or direct scroll bar actions), affect position of middle button and change of current top visible record in list


    Private Sub ScrollToPosition(ByVal iVertPos As Integer)
        Dim bGrid As Boolean = True
        If Me.DGridView Is Nothing Then
            bGrid = False
        End If
        If PositionUpdating = False Then
            PositionUpdating = True
            Try
                Dim iNumRowsVisible As Integer = 0
                Dim lPcntScrolled As Double = 0, lScrollPos As Double = 0
                Dim btnHalfSize As Integer = 0, btnMiddlePos As Integer = 0
                Dim iNewAssumedPos As Integer = 0

                If p_Orient = eOrientation.Vertical Then
                    btnHalfSize = Me.btnMiddle1.Height / 2 : btnMiddlePos = Me.btnMiddle1.Top + btnHalfSize
                    lPcntScrolled = (100 * iVertPos) / Me.pMiddle1.Height
                Else
                    btnHalfSize = Me.btnMiddle1.Width / 2 : btnMiddlePos = Me.btnMiddle1.Left + btnHalfSize
                    lPcntScrolled = (100 * iVertPos) / Me.pMiddle1.Width
                End If
                If lPcntScrolled > 99 Then lPcntScrolled = 99
                iNewAssumedPos = iVertPos - btnHalfSize

                If p_Orient = eOrientation.Vertical Then
                    If bGrid Then iNumRowsVisible = (Me.DGridView.Height - Me.DGridView.ColumnHeadersHeight) / Me.DGridView.Rows(0).Height
                Else
                    If bGrid Then iNumRowsVisible = (Me.DGridView.Width - Me.DGridView.RowHeadersWidth) / Me.DGridView.Columns(0).Width
                End If

                If Not bGrid Then iNumRowsVisible = p_ObjectVisibleRange

                If iNewAssumedPos < btnHalfSize Then
                    Me.btnMiddle1.Top = 0
                    If p_Orient = eOrientation.Vertical Then
                        If bGrid Then : Me.DGridView.FirstDisplayedScrollingRowIndex = 0 : Else : p_ObjectScrollPosition = 0 : End If
                    Else
                        If bGrid Then : Me.DGridView.FirstDisplayedScrollingColumnIndex = 0 : Else : p_ObjectScrollPosition = 0 : End If
                    End If

                Else
                    If p_Orient = eOrientation.Vertical Then
                        If iNewAssumedPos > (Me.pMiddle1.Height - btnMiddlePos) And btnMiddlePos = Me.pMiddle1.Height - btnHalfSize Then
                            Me.btnMiddle1.Top = Me.pMiddle1.Height - Me.btnMiddle1.Height
                            If bGrid Then
                                If Me.DGridView.RowCount - iNumRowsVisible > 0 Then
                                    Me.DGridView.FirstDisplayedScrollingRowIndex = Me.DGridView.RowCount - iNumRowsVisible
                                Else
                                    Me.DGridView.FirstDisplayedScrollingRowIndex = 0
                                End If
                            Else
                                If p_ObjectScale - p_ObjectVisibleRange > 0 Then
                                    p_ObjectScrollPosition = p_ObjectScale - p_ObjectVisibleRange
                                Else
                                    p_ObjectScrollPosition = 0
                                End If
                            End If
                        Else
                            Me.btnMiddle1.Top = iNewAssumedPos - btnHalfSize
                            If bGrid Then Me.DGridView.FirstDisplayedScrollingRowIndex = (lPcntScrolled * Me.DGridView.RowCount) / 100
                            If Not bGrid Then p_ObjectScrollPosition = (lPcntScrolled * p_ObjectScale) / 100
                        End If
                    Else
                        If iNewAssumedPos > (Me.pMiddle1.Width - btnMiddlePos) And btnMiddlePos = Me.pMiddle1.Width - btnHalfSize Then
                            Me.btnMiddle1.Left = Me.pMiddle1.Width - Me.btnMiddle1.Width
                            If bGrid Then
                                If Me.DGridView.ColumnCount - iNumRowsVisible > 0 Then
                                    Me.DGridView.FirstDisplayedScrollingColumnIndex = Me.DGridView.ColumnCount - iNumRowsVisible
                                Else
                                    Me.DGridView.FirstDisplayedScrollingColumnIndex = 0
                                End If
                            Else
                                If p_ObjectScale - p_ObjectVisibleRange > 0 Then
                                    p_ObjectScrollPosition = p_ObjectScale - p_ObjectVisibleRange
                                Else
                                    p_ObjectScrollPosition = 0
                                End If
                            End If
                        Else
                            Me.btnMiddle1.Left = iNewAssumedPos - btnHalfSize
                            If bGrid Then Me.DGridView.FirstDisplayedScrollingColumnIndex = (lPcntScrolled * Me.DGridView.ColumnCount) / 100
                            If Not bGrid Then p_ObjectScrollPosition = (lPcntScrolled * p_ObjectScale) / 100
                        End If
                    End If

                End If
                PositionUpdating = False
            Catch ex As Exception
                PositionUpdating = False
            End Try
        End If
    End Sub

    Private Sub FlipOver()
        Me.SuspendLayout()
        Dim iTemp As Integer = 0
        Dim lTemp As Long = 0
        Dim dTemp As Double = 0.0
        RemoveHandler Me.Resize, AddressOf ControlResize

        iTemp = OrgControlHeight
        OrgControlHeight = OrgControlWidth
        OrgControlWidth = iTemp

        FlipControl(pScrollbar1)
        FlipControl(btnDownBig1)
        FlipControl(btnUpBig1)
        FlipControl(btnDown1)
        FlipControl(btnUp1)
        FlipControl(pMiddle1)
        FlipControl(btnMiddle1)
        FlipControl(Me)

        AddHandler Me.Resize, AddressOf ControlResize
        Me.ResumeLayout()
    End Sub
    Private Sub FlipControl(ByRef Ctrl As Windows.Forms.Control)
        Dim iTemp As Integer = 0
        iTemp = Ctrl.Height
        Ctrl.Height = Ctrl.Width
        Ctrl.Width = iTemp
        iTemp = Ctrl.Top
        Ctrl.Top = Ctrl.Left
        Ctrl.Left = iTemp
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pScrollbar1 = New System.Windows.Forms.Panel
        Me.btnDownBig1 = New System.Windows.Forms.Button
        Me.btnUpBig1 = New System.Windows.Forms.Button
        Me.btnDown1 = New System.Windows.Forms.Button
        Me.btnUp1 = New System.Windows.Forms.Button
        Me.pMiddle1 = New System.Windows.Forms.Panel
        Me.btnMiddle1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pScrollbar1.SuspendLayout()
        Me.pMiddle1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pScrollbar1
        '
        Me.pScrollbar1.BackColor = System.Drawing.Color.Navy
        Me.pScrollbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pScrollbar1.Controls.Add(Me.btnDownBig1)
        Me.pScrollbar1.Controls.Add(Me.btnUpBig1)
        Me.pScrollbar1.Controls.Add(Me.btnDown1)
        Me.pScrollbar1.Controls.Add(Me.btnUp1)
        Me.pScrollbar1.Controls.Add(Me.pMiddle1)
        Me.pScrollbar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pScrollbar1.Location = New System.Drawing.Point(0, 0)
        Me.pScrollbar1.Margin = New System.Windows.Forms.Padding(0)
        Me.pScrollbar1.Name = "pScrollbar1"
        Me.pScrollbar1.Size = New System.Drawing.Size(24, 327)
        Me.pScrollbar1.TabIndex = 19
        '
        'btnDownBig1
        '
        Me.btnDownBig1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownBig1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDownBig1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownBig1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownBig1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownBig1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownBig1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownBig1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownBig1.Location = New System.Drawing.Point(0, 313)
        Me.btnDownBig1.Name = "btnDownBig1"
        Me.btnDownBig1.Size = New System.Drawing.Size(24, 10)
        Me.btnDownBig1.TabIndex = 3
        Me.btnDownBig1.Tag = "+5"
        Me.btnDownBig1.UseVisualStyleBackColor = False
        '
        'btnUpBig1
        '
        Me.btnUpBig1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpBig1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpBig1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpBig1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpBig1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpBig1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpBig1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpBig1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpBig1.Location = New System.Drawing.Point(0, 0)
        Me.btnUpBig1.Name = "btnUpBig1"
        Me.btnUpBig1.Size = New System.Drawing.Size(24, 10)
        Me.btnUpBig1.TabIndex = 2
        Me.btnUpBig1.Tag = "-1"
        Me.btnUpBig1.UseVisualStyleBackColor = False
        '
        'btnDown1
        '
        Me.btnDown1.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnDown1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDown1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDown1.FlatAppearance.BorderSize = 0
        Me.btnDown1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDown1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDown1.Location = New System.Drawing.Point(0, 291)
        Me.btnDown1.Name = "btnDown1"
        Me.btnDown1.Size = New System.Drawing.Size(24, 20)
        Me.btnDown1.TabIndex = 1
        Me.btnDown1.Tag = "+1"
        Me.btnDown1.Text = "▽"
        Me.btnDown1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDown1.UseVisualStyleBackColor = False
        '
        'btnUp1
        '
        Me.btnUp1.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnUp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUp1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUp1.FlatAppearance.BorderSize = 0
        Me.btnUp1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUp1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp1.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUp1.Location = New System.Drawing.Point(0, 12)
        Me.btnUp1.Name = "btnUp1"
        Me.btnUp1.Size = New System.Drawing.Size(24, 20)
        Me.btnUp1.TabIndex = 0
        Me.btnUp1.Tag = "-5"
        Me.btnUp1.Text = "△"
        Me.btnUp1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnUp1.UseVisualStyleBackColor = False
        '
        'pMiddle1
        '
        Me.pMiddle1.Controls.Add(Me.btnMiddle1)
        Me.pMiddle1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pMiddle1.ForeColor = System.Drawing.Color.Navy
        Me.pMiddle1.Location = New System.Drawing.Point(0, 34)
        Me.pMiddle1.Name = "pMiddle1"
        Me.pMiddle1.Size = New System.Drawing.Size(24, 255)
        Me.pMiddle1.TabIndex = 4
        '
        'btnMiddle1
        '
        Me.btnMiddle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMiddle1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMiddle1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btnMiddle1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMiddle1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnMiddle1.ForeColor = System.Drawing.Color.Red
        Me.btnMiddle1.Location = New System.Drawing.Point(0, 0)
        Me.btnMiddle1.Name = "btnMiddle1"
        Me.btnMiddle1.Size = New System.Drawing.Size(24, 20)
        Me.btnMiddle1.TabIndex = 21
        Me.btnMiddle1.Tag = "0"
        Me.btnMiddle1.UseVisualStyleBackColor = False
        '
        'ScrollBar
        '
        Me.Controls.Add(Me.pScrollbar1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Size = New System.Drawing.Size(24, 327)
        Me.pScrollbar1.ResumeLayout(False)
        Me.pMiddle1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
