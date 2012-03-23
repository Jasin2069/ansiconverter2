Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Avi

    Public Const StreamtypeVIDEO As Integer = 1935960438
    Public Const OF_SHARE_DENY_WRITE As Integer = 32
    Public Const BMP_MAGIC_COOKIE As Integer = 19778



    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure RECTstruc
        Public left As UInt32
        Public top As UInt32
        Public right As UInt32
        Public bottom As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure BITMAPINFOHEADERstruc
        Public biSize As UInt32
        Public biWidth As Int32
        Public biHeight As Int32
        Public biPlanes As Int16
        Public biBitCount As Int16
        Public biCompression As UInt32
        Public biSizeImage As UInt32
        Public biXPelsPerMeter As Int32
        Public biYPelsPerMeter As Int32
        Public biClrUsed As UInt32
        Public biClrImportant As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure AVISTREAMINFOstruc
        Public fccType As UInt32
        Public fccHandler As UInt32
        Public dwFlags As UInt32
        Public dwCaps As UInt32
        Public wPriority As UInt16
        Public wLanguage As UInt16
        Public dwScale As UInt32
        Public dwRate As UInt32
        Public dwStart As UInt32
        Public dwLength As UInt32
        Public dwInitialFrames As UInt32
        Public dwSuggestedBufferSize As UInt32
        Public dwQuality As UInt32
        Public dwSampleSize As UInt32
        Public rcFrame As RECTstruc
        Public dwEditCount As UInt32
        Public dwFormatChangeCount As UInt32
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=64)> _
        Public szName As UInt16()
    End Structure



    'Initialize the AVI library
    <DllImport("avifil32.dll")> _
    Public Shared Sub AVIFileInit()
    End Sub

    'Open an AVI file
    <DllImport("avifil32.dll", PreserveSig:=True)> _
    Public Shared Function AVIFileOpen(ByRef ppfile As Integer, ByVal szFile As [String], ByVal uMode As Integer, ByVal pclsidHandler As Integer) As Integer
    End Function

    'Create a new stream in an open AVI file
    <DllImport("avifil32.dll")> _
    Public Shared Function AVIFileCreateStream(ByVal pfile As Integer, ByRef ppavi As IntPtr, ByRef ptr_streaminfo As AVISTREAMINFOstruc) As Integer
    End Function

    'Set the format for a new stream
    <DllImport("avifil32.dll")> _
    Public Shared Function AVIStreamSetFormat(ByVal aviStream As IntPtr, ByVal lPos As Int32, ByRef lpFormat As BITMAPINFOHEADERstruc, ByVal cbFormat As Int32) As Integer
    End Function

    'Write a sample to a stream
    <DllImport("avifil32.dll")> _
    Public Shared Function AVIStreamWrite(ByVal aviStream As IntPtr, ByVal lStart As Int32, ByVal lSamples As Int32, ByVal lpBuffer As IntPtr, ByVal cbBuffer As Int32, ByVal dwFlags As Int32, _
     ByVal dummy1 As Int32, ByVal dummy2 As Int32) As Integer
    End Function

    'Release an open AVI stream
    <DllImport("avifil32.dll")> _
    Public Shared Function AVIStreamRelease(ByVal aviStream As IntPtr) As Integer
    End Function

    'Release an open AVI file
    <DllImport("avifil32.dll")> _
    Public Shared Function AVIFileRelease(ByVal pfile As Integer) As Integer
    End Function

    'Close the AVI library
    <DllImport("avifil32.dll")> _
    Public Shared Sub AVIFileExit()
    End Sub

End Class
