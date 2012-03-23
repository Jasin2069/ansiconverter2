Imports System.Runtime.InteropServices 'used for APIs
Imports System 'System imports
Imports System.IO 'File input / output
Imports System.Text 'Advanced Text capabilities
Imports System.Windows.Forms.Control

Public Class VideoConverterFFMPEG
    Inherits Windows.Forms.Control

    Public Enum OutTypes
        AVI = 1
        MP4 = 2
        WMV = 3
        MKV = 4
        VOB = 5
        FLV = 6
        GIF = 7
        MPG = 8
    End Enum
    Public Enum ConvStates
        Idle = 0
        WaitingForParams = 1
        Converting = 2
        Aborted = 3
        Finished = 4
        ConvError = 5
        Ready = 6
    End Enum
    Public WithEvents bw As New System.ComponentModel.BackgroundWorker
    Private prcFFMPEG As New Process 'FFMPEG Process Object
    Private strFinalOutput As String 'Stores Final Output Location
    Private strFWOE As String 'Stores Filename Without Path & Extension
    Private strOutExt As String 'Stores Selected Output File Format
    Private strOutAudio As String 'Stores Audio Bitrate
    Private strVidSize As String 'Stores Video Size
    Private strOutFile As String
    Private strInFile As String
    Private strOutType As String
    Private OutType As OutTypes = OutTypes.AVI
    Private intQuality As Integer 'Stores Output Quality
    Private strFFMPEGPath As String
    Private intStatus As ConvStates
    Private dFPS As Double = 29.97
    Private sVCodec As String = ""
    Private sImageList As String = ""
    Private iNumFrames As Integer = 0
    Private iWidth As Integer = 0
    Private iHeight As Integer = 0
    Public Property VCodec() As String
        Get
            Return sVCodec
        End Get
        Set(ByVal value As String)
            If sVCodec <> value Then
                sVCodec = value
            End If
        End Set
    End Property
    Public Property VideoWidth() As Integer
        Get
            Return iWidth
        End Get
        Set(ByVal value As Integer)
            If iWidth <> value Then
                iWidth = value
            End If
        End Set
    End Property
    Public Property VideoHeight() As Integer
        Get
            Return iHeight
        End Get
        Set(ByVal value As Integer)
            If iHeight <> value Then
                iHeight = value
            End If
        End Set
    End Property
    Public Property Imagelist() As String
        Get
            Return sImageList
        End Get
        Set(ByVal value As String)
            If sImageList <> value Then
                sImageList = value
            End If
        End Set
    End Property
    Public Property Numframes() As Integer
        Get
            Return iNumFrames
        End Get
        Set(ByVal value As Integer)
            If iNumFrames <> value Then
                iNumFrames = value
            End If
        End Set
    End Property
    Public Property FPS() As Double
        Get
            Return dFPS
        End Get
        Set(ByVal value As Double)
            If dFPS <> value Then
                dFPS = value
            End If
        End Set
    End Property
    Public Property Output() As String
        Get
            Return strOutFile
        End Get
        Set(ByVal value As String)
            If intStatus <> ConvStates.Converting Then
                If strOutFile <> value Then
                    strOutFile = value
                    intStatus = ConvStates.Idle
                    CheckParameter()
                End If
            End If
        End Set
    End Property
    Public Property Input() As String
        Get
            Return strInFile
        End Get
        Set(ByVal value As String)
            If intStatus <> ConvStates.Converting Then
                If strInFile <> value Then
                    strInFile = value
                    intStatus = ConvStates.Idle
                    CheckParameter()
                End If
            End If
        End Set
    End Property
    Public Property FFMPEGPath() As String
        Get
            Return strFFMPEGPath
        End Get
        Set(ByVal value As String)
            If intStatus <> ConvStates.Converting Then
                If IO.File.Exists(value) And value <> strFFMPEGPath Then
                    strFFMPEGPath = value
                    CheckParameter()
                End If
            End If
        End Set
    End Property
    Public Property OutFormat() As OutTypes
        Get
            Return OutType
        End Get
        Set(ByVal value As OutTypes)
            If intStatus <> ConvStates.Converting Then
                If OutType <> value Then
                    OutType = value
                End If
            End If

        End Set
    End Property
    Public Property Quality() As Integer
        Get
            Return intQuality
        End Get
        Set(ByVal value As Integer)
            intQuality = value
        End Set
    End Property
    Public ReadOnly Property Status() As ConvStates
        Get
            Return intStatus
        End Get
    End Property


    Public Sub New()
        strFFMPEGPath = "C:\Documents\VisualStudioProjects\DirectShowVideoTest\ffmpeg.exe"
        intStatus = ConvStates.WaitingForParams
    End Sub

    Public Sub New(ByVal sourcefile As String, ByVal destfile As String, ByVal outformat As OutTypes, Optional ByVal quality As Integer = 0)
        Me.New()
        strInFile = sourcefile
        strOutFile = destfile
        OutType = outformat
        intQuality = quality
        CheckParameter()
    End Sub
    Public Sub Cancel()
        If intStatus = ConvStates.Converting Then
            bw.CancelAsync()
            intStatus = ConvStates.Aborted
            prcFFMPEG.Kill() 'Done
        End If
    End Sub
    Public Sub Convert()
        If intStatus = ConvStates.Ready Or intStatus = ConvStates.Finished Or intStatus = ConvStates.Aborted Then
            bw.RunWorkerAsync() 'Start Conversion
            intStatus = ConvStates.Converting
        End If
    End Sub
    Private Sub CheckParameter()
        If intStatus = ConvStates.Aborted Or intStatus = ConvStates.Finished Or intStatus = ConvStates.ConvError Then
            intStatus = ConvStates.Idle
        End If
        If intStatus = ConvStates.Idle Or intStatus = ConvStates.WaitingForParams Then
            If (strInFile = "" And sImageList = "") Or (strInFile <> "" And IO.File.Exists(strInFile) = False) Or strOutFile = "" Or IO.File.Exists(strFFMPEGPath) = False Then
                intStatus = ConvStates.WaitingForParams
            Else
                intStatus = ConvStates.Ready
            End If
        End If
    End Sub
    Private Function OutTypeToStr(ByVal ot As OutTypes) As String
        Select Case ot
            Case OutTypes.AVI
                Return "avi"
            Case OutTypes.FLV
                Return "flv"
            Case OutTypes.MKV
                Return "mkv"
            Case OutTypes.MP4
                Return "mp4"
            Case OutTypes.VOB
                Return "vob"
            Case OutTypes.WMV
                Return "wmv"
            Case OutTypes.GIF
                Return "gif"
            Case OutTypes.MPG
                Return "mpg"
            Case Else
                Return "avi"
        End Select
    End Function
    Private Function ConvertFile() 'Function To Convert File
        '        Dim cmd As String = " -i """ & input & """ -ar " & strOutAudio & " -b 64k -r 24 -s " & strVidSize & "-qscale " & intQuality & " -y """ & output & """" 'ffmpeg commands -y replace

        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False 'Disable Illegal Crossthread Calls From Controls

        Dim strOutput As String = strOutFile 'Output File Name
        Dim strFFMPEGOut As String 'Lines Read From Input / Source File
        strOutExt = OutTypeToStr(OutFormat)
        Dim strSource As String = strInFile

        'ffmpeg -y -f image2 -i "C:\Users\ccumbrowski\AppData\Local\Temp\ANSIToVideoTemp\ACID-TR.ANS_%05d.PNG"  -r 30 -vframes 373 -map 0:0 -pix_fmt rgb24  -s 640x400 "F:\ANSI\ANI\ACID-TR.ANS.GIF"
        Dim strFFMPEGCmd As String = ""
        strFFMPEGCmd &= " -y"
        If OutType <> OutTypes.GIF Then
            strFFMPEGCmd &= " -b:v 64k"
        End If
        If sImageList <> "" Then
            strFFMPEGCmd &= " -f image2 -i """ & sImageList & """ "
        Else
            strFFMPEGCmd &= " -i """ & strSource & """ "
        End If
        If dFPS <> 0 Then
            strFFMPEGCmd &= " -r " & dFPS
            If OutType <> OutTypes.GIF Then
                strFFMPEGCmd &= " -force_fps"
            End If
        End If
        If iNumFrames <> 0 Then
            If OutType = OutTypes.GIF Then
                strFFMPEGCmd &= " -vframes " & iNumFrames & " -map 0:0 -pix_fmt rgb24"
            Else
                strFFMPEGCmd &= " -frames " & iNumFrames
            End If

        End If
        If iHeight <> 0 And iWidth <> 0 Then
            strFFMPEGCmd &= " -s " & iWidth & "x" & iHeight
        End If
        If sVCodec <> "" Then
            strFFMPEGCmd &= " -vcodec " & LCase(sVCodec)
        End If
        strFFMPEGCmd &= " """ & strOutput & """"
        Console.WriteLine("FFMPEG Parameters: " & strFFMPEGCmd)
        Dim psiProcInfo As New System.Diagnostics.ProcessStartInfo 'Proc Info Object For FFMPEG.EXE

        Dim srFFMPEG As StreamReader 'Reads Source File's Lines

        '        Dim cmd As String = " -i """ & input & """ -ar " & strOutAudio & " -b 64k -r 24 -s " & strVidSize & "-qscale " & intQuality & " -y """ & output & """" 'ffmpeg commands -y replace

        If strFinalOutput <> "" And strFWOE <> "" And strOutExt <> "" And strOutAudio <> "" And strVidSize <> "" Then

            strOutput = strFinalOutput & strFWOE & strOutExt

        Else

            'MessageBox.Show("Ensure all settings are properly made!") 'If Something Not Set

            'Exit Function

        End If


        psiProcInfo.FileName = strFFMPEGPath 'Location Of FFMPEG.EXE
        psiProcInfo.Arguments = strFFMPEGCmd 'Command String
        psiProcInfo.UseShellExecute = False

        psiProcInfo.WindowStyle = ProcessWindowStyle.Hidden

        psiProcInfo.RedirectStandardError = True
        psiProcInfo.RedirectStandardOutput = True
        psiProcInfo.CreateNoWindow = True

        prcFFMPEG.StartInfo = psiProcInfo

        prcFFMPEG.Start() 'Start Process
        '

        srFFMPEG = prcFFMPEG.StandardError 'Enable Error Checking For FFMPEG.EXE

        'Me.btnStart.Enabled = False

        Do

            If bw.CancellationPending Then 'Cancelled?
                Return 1
                Exit Function

            End If

            strFFMPEGOut = srFFMPEG.ReadLine 'Read Source File Line By Line

        Loop Until prcFFMPEG.HasExited And strFFMPEGOut = Nothing Or strFFMPEGOut = "" 'Read Until There Is Nothing Left

        intStatus = ConvStates.Finished
        Return 0

    End Function

    Private Sub bgwConvert_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork

        ConvertFile() 'Function / Sub That Must Start

    End Sub

End Class
