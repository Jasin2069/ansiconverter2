Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.MarshalByRefObject
Imports System.Runtime.InteropServices
Public Module IMG

    'Friend DosFontSml As New FontDef(8, 8, 0, 0, 0, 0, -1, 0, 256, 0, 255, Color.Black.ToArgb, Color.FromArgb(255, 168, 168, 168).ToArgb)
    'Friend DosFont As New FontDef(8, 16, 0, 0, 0, 0, -1, 1, 32, 1, 255, Color.Black.ToArgb, Color.FromArgb(255, 168, 168, 168).ToArgb)
    Public Function CreateImageFromASCII(ByVal NFOText As String, Optional ByVal TextColor As Integer = Nothing, Optional ByVal BackColor As Integer = Nothing) As Bitmap

        m_NFOText = NFOText
        If m_NFOText = "" Then m_NFOText = "THIS IS A TEST."

        If pSmallFont Then
            m_NFOTextImg = DosFontSml.DrawTextFromString(m_NFOText)
        Else
            m_NFOTextImg = DosFont.DrawTextFromString(m_NFOText)
        End If
        Return m_NFOTextImg
    End Function

    Public Function CreateImageFromScreenChars() As Bitmap
        m_NFOTextImg = ScreenToBitmap(pSmallFont, pNoColors)
        'If pSmallFont Then
        ' m_NFOTextImg = DosFontSml.DrawText(False)
        ' Else
        ' m_NFOTextImg = DosFont.DrawText(False)
        ' End If
        Return m_NFOTextImg
    End Function
End Module
