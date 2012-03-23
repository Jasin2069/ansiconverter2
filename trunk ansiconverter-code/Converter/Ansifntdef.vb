Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Public Class Ansifntdef
    Private m_Fontwidth As Integer
    Private m_FontHeight As Integer
    Private m_FontTranspColor As Drawing.Color
    Private m_FontImage As Bitmap
    Private m_FontBGImage As Bitmap
    Private m_Palette As Drawing.Imaging.ColorPalette
    Public DefaultForecolorID As Integer = 7
    Public DefaultBackColorID As Integer = 0
    Public FntBits(255) As String
    Public FontSet As Boolean = False

    Public ReadOnly Property Width() As Integer
        Get
            Return m_Fontwidth
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return m_FontHeight
        End Get
    End Property
    Public Sub New()
        FontSet = False
    End Sub
    Public Sub New(ByVal w As Integer, ByVal h As Integer, ByVal tc As Drawing.Color, ByVal fimg As Bitmap, ByVal fbgimg As Bitmap)
        m_Fontwidth = w
        m_FontHeight = h
        m_FontTranspColor = tc
        m_FontBGImage = fbgimg
        m_Palette = m_FontBGImage.Palette
        'm_FontImage = BitmapToIndexed(fimg, m_Palette)
        'm_FontImage.Palette = m_Palette
        m_FontImage = fimg
        m_FontImage.MakeTransparent(m_FontTranspColor)
        If m_Fontwidth = 8 Then
            BuildFntBits()
        End If
        FontSet = True
    End Sub
    Private Sub BuildFntBits()
        Dim c As Drawing.Color
        Dim btCnt As Integer = 0
        Dim crCnt As Integer = 0
        Dim bt As Byte = 0
        For a As Integer = 0 To 255
            FntBits(a) = ""
        Next
        For y As Integer = 0 To m_FontImage.Height - 1
            btCnt = 0
            crCnt = 0
            bt = 0
            For x As Integer = 0 To m_FontImage.Width - 1
                c = m_FontImage.GetPixel(x, y)
                btCnt += 1
                If c.R = m_FontTranspColor.R And c.G = m_FontTranspColor.G And c.B = m_FontTranspColor.B Then
                Else
                    SetBit(bt, btCnt)
                End If
                If btCnt = 8 Then
                    FntBits(crCnt) &= Strings.Right("00" & Hex(bt).ToString, 2)
                    bt = 0
                    btCnt = 0
                    crCnt += 1
                End If
            Next
        Next
    End Sub

    Public Function DrawText(Optional ByVal bNoCols As Boolean = False) As Bitmap
        Dim FntCurrChar As Integer, iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
        Dim gr As Graphics
        Dim CharXPos As Integer = 0
        Dim CharYPos As Integer = 0
        Dim UseForeColID As Integer = DefaultForecolorID
        Dim UseBackColID As Integer = DefaultBackColorID
        iMaxWidth = maxX
        iMaxHeight = LinesUsed
        Dim bm As Bitmap = Nothing
        Try
            bm = BitmapToIndexed(New Bitmap(iMaxWidth * m_Fontwidth, iMaxHeight * m_FontHeight), m_Palette)
        Catch ex As Exception

        End Try

        bm.Palette = m_Palette
        bm.MakeTransparent(m_FontTranspColor)

        Dim ForeColorID As Integer = DefaultForecolorID
        Dim BackColorID As Integer = DefaultBackColorID
        gr = Graphics.FromImage(bm)
        gr.PageUnit = GraphicsUnit.Pixel
        gr.Clear(Color.Black)

        For a As Integer = 0 To iMaxHeight - 1
            CharXPos = 0
            For FntCharPos As Integer = 1 To iMaxWidth
                Dim charimg As Bitmap = New Bitmap(m_Fontwidth, m_FontHeight)
                charimg = BitmapToIndexed(New Bitmap(m_Fontwidth, m_FontHeight), m_Palette)
                charimg.Palette = m_Palette
                charimg.MakeTransparent(m_FontTranspColor)
                Dim grchar As Graphics = Graphics.FromImage(charimg)
                grchar.Clear(Color.Black)
                grchar.PageUnit = GraphicsUnit.Pixel

                FntCurrChar = Screen(FntCharPos, a + 1).DosChar
                BackColorID = Screen(FntCharPos, a + 1).BackColor
                ForeColorID = Screen(FntCharPos, a + 1).ForeColor + Screen(FntCharPos, a + 1).Bold
                Dim destRect As Rectangle = New Rectangle(CharXPos, CharYPos, m_Fontwidth, m_FontHeight)
                If bNoCols = False Then
                    UseForeColID = ForeColorID
                    UseBackColID = UseBackColID
                End If
                'Dim srcRectBG As Rectangle = New Rectangle(UseBackColID * m_Fontwidth, 0, m_Fontwidth, m_FontHeight)
                Dim srcRectCR As Rectangle = New Rectangle(FntCurrChar * m_Fontwidth, UseForeColID * m_FontHeight, m_Fontwidth, m_FontHeight)

                'gr.DrawImage(m_FontBGImage, destRect, srcRectBG, GraphicsUnit.Pixel)
                'gr.Clear(AnsiColorsARGB(UseBackColID))
                'gr.DrawRectangle(New Drawing.Pen(AnsiColorsARGB(UseBackColID)), destRect)
                gr.FillRectangle(New SolidBrush(AnsiColorsARGB(UseBackColID)), destRect)
                gr.DrawImage(m_FontImage, destRect, srcRectCR, GraphicsUnit.Pixel)

                CharXPos += m_Fontwidth
            Next
            CharYPos += m_FontHeight
        Next
        gr.Dispose()
        Return bm

    End Function
    Public Function DrawTextFromString(ByVal stext As String) As Bitmap
        Dim aworktxt() As String = New String() {""}
        Dim iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
        Dim bte() As Byte, bIsSmallFont As Boolean = False
        If m_FontHeight = 8 Then
            bIsSmallFont = True
        End If
        aworktxt = Split(stext, vbCrLf)
        For a As Integer = 0 To UBound(aworktxt)
            If Len(aworktxt(a)) > iMaxWidth Then
                iMaxWidth = Len(aworktxt(a))
            End If
        Next
        iMaxHeight = (UBound(aworktxt) + 1)
        For a As Integer = 0 To UBound(aworktxt)
            If Len(aworktxt(a)) < iMaxWidth Then
                aworktxt(a) &= Space(iMaxWidth - Len(aworktxt(a)))
            End If
        Next
        bte = StringToByteArray(Join(aworktxt, ""))

 
        Return ByteArrayToBitmap(bte, iMaxWidth, iMaxHeight, bIsSmallFont)
    End Function

End Class
