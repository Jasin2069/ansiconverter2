Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.MarshalByRefObject
Imports System.Runtime.InteropServices
Namespace MediaFormats


    Public Module IMG

        'Friend DosFontSml As New FontDef(8, 8, 0, 0, 0, 0, -1, 0, 256, 0, 255, Color.Black.ToArgb, Color.FromArgb(255, 168, 168, 168).ToArgb)
        'Friend DosFont As New FontDef(8, 16, 0, 0, 0, 0, -1, 1, 32, 1, 255, Color.Black.ToArgb, Color.FromArgb(255, 168, 168, 168).ToArgb)
        Public Function CreateImageFromASCII(ByVal NFOText As String, Optional ByVal TextColor As Integer = Nothing, Optional ByVal BackColor As Integer = Nothing) As Bitmap

            Internal.m_NFOText = NFOText
            If Internal.m_NFOText = "" Then Internal.m_NFOText = "THIS IS A TEST."

            If pSmallFont Then
                Internal.m_NFOTextImg = DosFnt80x50.DrawTextFromString(Internal.m_NFOText)
            Else
                Internal.m_NFOTextImg = DosFnt80x25.DrawTextFromString(Internal.m_NFOText)
            End If
            Return Internal.m_NFOTextImg
        End Function

        Public Function CreateImageFromScreenChars() As Bitmap
            Internal.m_NFOTextImg = ConverterSupport.ScreenToBitmap(pSmallFont, pNoColors)
            'If pSmallFont Then
            ' m_NFOTextImg = DosFontSml.DrawText(False)
            ' Else
            ' m_NFOTextImg = DosFont.DrawText(False)
            ' End If
            Return Internal.m_NFOTextImg
        End Function
    End Module
End Namespace