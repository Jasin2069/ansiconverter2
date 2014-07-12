Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Namespace MediaSupport


    Public Class AviWriter
        Private aviFile As Integer = 0
        Private aviStream As IntPtr = IntPtr.Zero
        Private frameRate As UInt32 = 0
        Private countFrames As Integer = 0
        Private width As Integer = 0
        Private height As Integer = 0
        Private stride As UInt32 = 0
        Private fccType As UInt32 = MediaFormats.Avi.StreamtypeVIDEO
        Private fccHandler As UInt32 = 1668707181

        Private strideInt As Integer
        Private strideU As UInteger
        Private heightU As UInteger
        Private widthU As UInteger

        Public Sub OpenAVI(ByVal fileName As String, ByVal frameRate As UInt32, Optional ByVal w As Integer = 0, Optional ByVal h As Integer = 0)
            Me.frameRate = frameRate

            MediaFormats.Avi.AVIFileInit()

            If w <> 0 Then : Me.width = w : End If
            If h <> 0 Then : Me.height = h : End If
            Dim OpeningError As Integer = MediaFormats.Avi.AVIFileOpen(aviFile, fileName, 4097, 0)
            If OpeningError <> 0 Then
                Throw New Exception("Error in AVIFileOpen: " + OpeningError.ToString())
            End If
        End Sub
        Public Sub AddFrame(ByVal bmp_ As Bitmap)
            Dim gr As Graphics
            Dim bmp As Bitmap
            If Me.width = 0 Then : Me.width = bmp_.Width : End If
            If Me.height = 0 Then : Me.height = bmp_.Height : End If

            bmp = New Bitmap(Me.width, Me.height, PixelFormat.Format24bppRgb)
            gr = Graphics.FromImage(bmp)
            gr.DrawImage(bmp_, New Point(0, 0))

            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[ReadOnly], PixelFormat.Format24bppRgb)
            If countFrames = 0 Then
                Dim bmpDatStride As UInteger = bmpData.Stride
                Me.stride = CType(bmpDatStride, UInt32)
                'Me.width = bmp.Width
                'Me.height = bmp.Height
                CreateStream()
            End If

            strideInt = stride
            Dim writeResult As Integer = MediaFormats.Avi.AVIStreamWrite(aviStream, countFrames, 1, bmpData.Scan0, CType((strideInt * height), Int32), 0, _
             0, 0)

            If writeResult <> 0 Then
                Throw New Exception("Error in AVIStreamWrite: " + writeResult.ToString())
            End If
            bmp.UnlockBits(bmpData)
            System.Math.Max(System.Threading.Interlocked.Increment(countFrames), countFrames - 1)

        End Sub
        Private Sub CreateStream()
            Dim strhdr As New MediaFormats.Avi.AVISTREAMINFOstruc()
            strhdr.fccType = fccType
            strhdr.fccHandler = fccHandler
            strhdr.dwScale = 1
            strhdr.dwRate = frameRate
            strideU = stride
            heightU = height
            strhdr.dwSuggestedBufferSize = CType((stride * strideU), UInt32)
            strhdr.dwQuality = 10000

            heightU = height
            widthU = width
            strhdr.rcFrame.bottom = CType(heightU, UInt32)
            strhdr.rcFrame.right = CType(widthU, UInt32)
            strhdr.szName = New UInt16(64) {}
            Dim createResult As Integer = MediaFormats.Avi.AVIFileCreateStream(aviFile, aviStream, strhdr)
            If createResult <> 0 Then
                Throw New Exception("Error in AVIFileCreateStream: " + createResult.ToString())
            End If
            Dim bi As New MediaFormats.Avi.BITMAPINFOHEADERstruc()
            Dim bisize As UInteger = Marshal.SizeOf(bi)
            bi.biSize = CType(bisize, UInt32)
            bi.biWidth = CType(width, Int32)
            bi.biHeight = CType(height, Int32)
            bi.biPlanes = 1
            bi.biBitCount = 24

            strideU = stride
            heightU = height
            bi.biSizeImage = CType((strideU * heightU), UInt32)
            Dim formatResult As Integer = MediaFormats.Avi.AVIStreamSetFormat(aviStream, 0, bi, Marshal.SizeOf(bi))
            If formatResult <> 0 Then
                Throw New Exception("Error in AVIStreamSetFormat: " + formatResult.ToString())
            End If
        End Sub
        Public Sub Close()
            If aviStream <> IntPtr.Zero Then
                MediaFormats.Avi.AVIStreamRelease(aviStream)
                aviStream = IntPtr.Zero
            End If
            If aviFile <> 0 Then
                MediaFormats.Avi.AVIFileRelease(aviFile)
                aviFile = 0
            End If
            MediaFormats.Avi.AVIFileExit()
        End Sub

        Private Sub CreateFile()
            Dim Writer As New AviWriter
            Dim screenBimaps(99) As Bitmap
            Dim currentBitmap As Integer = 0
            Writer.OpenAVI("C:\Test.Avi", 10)
            For Frame As Integer = 0 To currentBitmap - 1
                Writer.AddFrame(screenBimaps(Frame))
            Next
            Writer.Close()
        End Sub
    End Class
End Namespace