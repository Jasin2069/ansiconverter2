Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Namespace MediaSupport


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
        Private m_FontArrays(,,) As IntPtr
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
        Private m_FontTranspColor As Drawing.Color ' Transparent Color /Background color
        Private m_FontColor As Drawing.Color
        Private FontBmpBak As Bitmap 'Bitmap image of the Font (Backup)
        Private bBuildFont As Boolean
        Private m_FontColorPalIndex As Integer
        Private m_FontTranspColorPalIndex As Integer

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
                       ByVal chrf As Integer, ByVal chrt As Integer, ByVal backcolor As Integer, ByVal forecolor As Integer)
            ReDim m_FontImgs(255)
            ReDim m_FontArrays(255, 15, 7)
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
            'm_FontTranspColor = Color.Black
            m_FontCharFrom = chrf
            m_FontCharTo = chrt
            m_FontTranspColor = Drawing.Color.FromArgb(backcolor)
            m_FontColor = Drawing.Color.FromArgb(forecolor)
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
                        If c.Equals(m_FontColor) Then
                            c = NewColor
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
        Public Function FindPalettenEntry(ByVal col As Drawing.Color) As Integer
            Dim cp As ColorPalette = New Bitmap(1, 1).Palette, a As Integer
            Dim iResult As Integer = -1
            If Not m_FontBmp Is Nothing Then
                If m_FontBmp.PixelFormat = PixelFormat.Indexed Then
                    cp = m_FontBmp.Palette
                    For a = 0 To cp.Entries.Count - 1
                        If cp.Entries(a).Equals(col) Then
                            iResult = a
                            Exit For
                        End If
                    Next
                Else
                    iResult = -4
                End If
            End If
            Return iResult
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
                m_FontColorPalIndex = FindPalettenEntry(m_FontColor)
                m_FontTranspColorPalIndex = FindPalettenEntry(m_FontTranspColor)

                For a As Integer = m_FontCharFrom To m_FontCharTo
                    GetFont(a)
                Next
                bBuildFont = True
            End If
        End Sub
        Private Sub BuildBitmapArray(ByVal bmap As Bitmap, ByVal code As Byte)
            Dim bArray((16 * 8) - 1) As Array
            Dim b As Integer, bc As Integer, fc As Integer
            For b = 0 To (16 * 8) - 1
                Dim cTemp((bmap.Width * bmap.Height) - 1) As Byte
                bArray(b) = cTemp
            Next
            Dim a As Integer = 0, c As Drawing.Color
            'Dim MyPointer As IntPtr
            For x As Integer = 0 To bmap.Width - 1
                For y As Integer = 0 To bmap.Height - 1
                    c = bmap.GetPixel(x, y)
                    If c.Equals(m_FontTranspColor) Then
                        Dim d As Integer = 0
                        For b = 0 To (16 * 8) - 1
                            bArray(b)(a) = d
                            If b + 1 Mod 16 = 0 Then
                                d += 1
                                If d = 16 Then d = 0
                            End If
                        Next
                    ElseIf c.Equals(m_FontColor) Then
                        Dim d As Integer = 0
                        For b = 0 To (16 * 8) - 1
                            bArray(b)(a) = d
                            If b + 1 Mod 8 = 0 Then
                                d += 1
                                If d = 8 Then d = 0
                            End If
                        Next
                    End If
                    a += 1
                Next
            Next
            fc = 0
            bc = 0
            For b = 0 To (16 * 8) - 1
                Dim MyGC As GCHandle = GCHandle.Alloc(bArray(b), GCHandleType.Pinned)
                'MyPointer = Marshal.AllocHGlobal(Marshal.SizeOf(bArray(b)))
                'Marshal.StructureToPtr(bArray(b), MyPointer, False)
                If b + 1 Mod 8 = 0 Then
                    bc += 1
                    If bc = 8 Then bc = 0
                End If
                If b + 1 Mod 16 = 0 Then
                    fc += 1
                    If fc = 16 Then fc = 0
                End If
                m_FontArrays(code, fc, bc) = MyGC
            Next
        End Sub
        Structure Bte128
            Public b001 As Byte
            Public b002 As Byte
            Public b003 As Byte
            Public b004 As Byte
            Public b005 As Byte
        End Structure
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

            'bm.MakeTransparent(Color.FromArgb(128, 0, 128, 255))
            'Dim bmcol As Bitmap = My.Resources.ansibackgrounds256
            'Dim pal As Drawing.Imaging.ColorPalette = bmcol.Palette
            'bm.Palette = pal
            Dim gr As Graphics = Graphics.FromImage(bm)
            gr.Clear(m_FontTranspColor)
            gr.PageUnit = GraphicsUnit.Pixel

            Dim destRect As Rectangle = New Rectangle(0, 0, m_FontWidth, m_FontHeight)
            Dim srcRect As Rectangle = New Rectangle(FntX, FntY, CutLen, CutHgt)
            Try
                gr.DrawImage(m_FontBmp, destRect, srcRect, gr.PageUnit)
            Catch ex As Exception

            End Try
            gr.Dispose()
            m_FontImgs(charcode) = bm
            'Call BuildBitmapArray(bm, charcode)
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
        Public Function DrawText(ByRef gr As Graphics, ByVal xpos As Integer, ByVal ypos As Integer, ByRef stext As Object, ByVal bDrawNoColors As Boolean) As Bitmap
            If bBuildFont = False Then
                Me.BuildFont()
            End If
            Dim aText As ConverterSupport.ScreenChar(,) = Nothing
            Dim CharXPos As Integer = xpos
            Dim CharYPos As Integer = ypos
            Dim sworktxt As String = ""
            Dim aworktxt() As String = New String() {""}, CutLen As Integer, CutHgt As Integer
            Dim FntCurrChar As Integer, iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
            Dim UsedWidth As Integer = m_FontWidth - m_FontMarginLeft - m_FontMarginRight

            Dim bIsASCII As Boolean = True
            If TypeOf stext Is String Then
                bIsASCII = True
            ElseIf TypeOf stext Is ConverterSupport.ScreenChar(,) Then
                bIsASCII = False
            End If
            If bDrawNoColors = True Then
                aworktxt = Split(stext, vbCrLf)
                For a As Integer = 0 To UBound(aworktxt)
                    If Len(aworktxt(a)) > iMaxWidth Then
                        iMaxWidth = Len(aworktxt(a))
                    End If
                Next
                iMaxHeight = (UBound(aworktxt) + 1)
            Else
                iMaxWidth = maxX
                iMaxHeight = LinesUsed
                aText = Screen 'CType(stext, ScreenChar(,))
            End If
            Dim iLineLen As Integer = iMaxWidth
            'Dim bmcol As Bitmap = My.Resources.ansibackgrounds
            'Dim pal As Drawing.Imaging.ColorPalette = bmcol.Palette

            Dim bm As New Bitmap(iMaxWidth * m_FontWidth, iMaxHeight * m_FontHeight)
            ' bm.MakeTransparent(Color.FromArgb(128, 0, 128, 255))

            Dim ForeColorID As Integer = 7
            Dim BackColorID As Integer = 0
            Dim NewForeColor As Drawing.Color
            Dim NewBackColor As Drawing.Color
            'bm.Palette = pal
            gr = Graphics.FromImage(bm)
            gr.PageUnit = GraphicsUnit.Pixel
            gr.Clear(Color.Black)
            'm_BackgroundColor
            'gr.DrawRectangle(New Drawing.Pen(m_FontTranspColor), New Drawing.Rectangle(0, 0, bm.Width, bm.Height))
            For a As Integer = 0 To iMaxHeight - 1
                CharXPos = xpos
                If bDrawNoColors = True Then
                    sworktxt = aworktxt(a)
                    iLineLen = Len(sworktxt)
                End If

                For FntCharPos As Integer = 1 To iLineLen
                    Dim ImgAttributes As New ImageAttributes
                    Dim ImgColorMap() As ColorMap = Nothing
                    Dim MapCount As Integer = -1
                    Dim charimg As Bitmap = New Bitmap(m_FontWidth, m_FontHeight)
                    Dim grchar As Graphics = Graphics.FromImage(charimg)
                    grchar.Clear(m_FontTranspColor)

                    If bDrawNoColors = True Then
                        FntCurrChar = Asc(Mid(sworktxt, FntCharPos, 1))
                    Else
                        FntCurrChar = Screen(FntCharPos, a + 1).DosChar
                        BackColorID = Screen(FntCharPos, a + 1).BackColor
                        ForeColorID = Screen(FntCharPos, a + 1).ForeColor + Screen(FntCharPos, a + 1).Bold


                        NewForeColor = Internal.AnsiColorsARGB(ForeColorID)
                        NewBackColor = Internal.AnsiColorsARGB(BackColorID)
                        If Not NewBackColor.Equals(m_FontTranspColor) And 1 = 2 Then
                            MapCount += 1
                            ReDim Preserve ImgColorMap(MapCount)
                            ImgColorMap(MapCount) = New ColorMap
                            ImgColorMap(MapCount).OldColor = New Color()
                            ImgColorMap(MapCount).OldColor = m_FontTranspColor
                            ImgColorMap(MapCount).NewColor = New Color()
                            ImgColorMap(MapCount).NewColor = NewBackColor
                        End If
                        If Not NewForeColor.Equals(m_FontColor) And 1 = 2 Then
                            MapCount += 1
                            ReDim Preserve ImgColorMap(MapCount)
                            ImgColorMap(MapCount) = New ColorMap
                            ImgColorMap(MapCount).OldColor = New Color()
                            ImgColorMap(MapCount).OldColor = m_FontColor
                            ImgColorMap(MapCount).NewColor = New Color()
                            ImgColorMap(MapCount).NewColor = NewForeColor
                        End If
                        If MapCount > -1 Then
                            ImgAttributes.SetRemapTable(ImgColorMap, ColorAdjustType.Bitmap)
                        End If
                        If FntCurrChar = 0 Then
                            FntCurrChar = 32
                        End If
                    End If
                    If FntCurrChar = 32 And m_FontSpaceWidth <> -1 Then
                        CharXPos = CharXPos + m_FontSpaceWidth
                    Else
                        CutLen = m_FontWidth - m_FontMarginLeft - m_FontMarginRight
                        CutHgt = m_FontHeight - m_FontMarginTop - m_FontMarginBottom
                        Dim destRect As Rectangle = New Rectangle(CharXPos, CharYPos, m_FontWidth, m_FontHeight)
                        Dim srcRect As Rectangle = New Rectangle(0, 0, CutLen, CutHgt)

                        Dim imgChar As Bitmap
                        If bDrawNoColors = False Then
                            'imgChar = New Bitmap(m_FontWidth, m_FontHeight, m_FontWidth, PixelFormat.Format8bppIndexed, m_FontArrays(FntCurrChar, ForeColorID, BackColorID))
                            imgChar = m_FontImgs(FntCurrChar)
                            ' Dim bmcol As Bitmap = My.Resources.ansibackgrounds256
                            ' Dim pal As Drawing.Imaging.ColorPalette = bmcol.Palette
                            ' imgChar.Palette = pal
                            Dim drawimg As Bitmap = ConverterSupport.Replace2ColorsInImage(imgChar, m_FontColor, NewForeColor, m_FontTranspColor, NewBackColor)
                            imgChar = drawimg
                            'imgChar2.Palette = 
                        Else
                            imgChar = m_FontImgs(FntCurrChar)
                        End If

                        grchar.DrawImage(imgChar, 0, 0, m_FontWidth, m_FontHeight)

                        'Dim bmdo As BitmapData = bm.LockBits(New Rectangle(0, 0, m_FontWidth, m_FontHeight), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed)


                        'Dim chrimg As New Bitmap(CutLen, CutHgt)
                        'chrimg.Palette = imgChar.Palette
                        'Dim gr2 As Graphics = Graphics.FromImage(chrimg)
                        'gr2.Clear(NewBackColor)

                        '                    gr.DrawRectangle(New Drawing.Pen(AnsiColorsARGB(BackColorID)), destRect)
                        ' If bDrawNoColors = False And Not imgChar Is Nothing Then


                        'Dim drawimg As Bitmap = Replace2ColorsInImage(imgChar, Color.FromArgb(255, 168, 168, 168), NewForeColor, Color.White, NewBackColor)
                        'imgChar = ReplaceColorInImage(imgChar, Me.m_BackgroundColor, AnsiColorsARGB(Screen(FntCharPos, a + 1).BackColor))
                        'If MapCount > -1 Then
                        '    gr2.DrawImage(imgChar, destRect, 0, 0, CutLen, CutHgt, GraphicsUnit.Pixel, ImgAttributes)
                        ' gr.DrawImage(charimg, destRect, srcRect, GraphicsUnit.Pixel)
                        '  Else
                        '       gr.DrawImage(imgChar, destRect, srcRect, GraphicsUnit.Pixel)
                        '    End If

                        ' Else
                        '     gr.DrawImage(imgChar, destRect, srcRect, GraphicsUnit.Pixel)
                        ' End If

                        'gr2.Dispose()

                        gr.DrawImage(charimg, destRect, srcRect, GraphicsUnit.Pixel)

                        CharXPos = CharXPos + UsedWidth
                    End If
                Next
                CharYPos += m_FontHeight
            Next
            gr.Dispose()
            Return bm

        End Function


    End Class
End Namespace