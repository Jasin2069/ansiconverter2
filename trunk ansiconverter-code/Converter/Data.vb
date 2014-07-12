Imports System.Reflection
Imports AnsiCPMaps
Imports System.Runtime.InteropServices
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text

Public Module Data
    '===============================
    Public bDebug As Boolean = False
    '===============================
    Public oAnsi As New MediaFormats.ANSI
    Public VidFmt As String = "AVI"
    Public cBPF As Integer = 0
    Public VidCodec As String = "LIBXVID"
    Public pOut As String = "ANS"
    Public pIn As String = "ASC"
    Public pSauce As String = "Keep" 'Strip"
    Public pAnim As String = "Static" '"Static"
    Public pOutExist As Integer = 0
    Public pSanitize As Boolean = True
    Public pCP As String = "CP437"
    Public pHTMLEncode As Boolean = True
    Public pHTMLComplete As Boolean = True
    Public bRemoveCompleted As Boolean = False
    Public selUTF As String = "UTF16" '"UTF16"/"UTF8"

    Public pNoColors As Boolean = False
    Public pSmallFont As Boolean = False
    Public bCreateThumbs As Boolean = False
    Public iThumbsResOpt As Integer = 1
    Public iThumbsScale As Double = 50
    Public iThumbsWidth As Integer = 0
    Public iThumbsHeight As Integer = 0
    Public txtExt As String
    Public rOutPathInput As Boolean
    Public rReplaceExt As Boolean
    Public outPath As String
    Public oAVIFile As New MediaSupport.AviWriter
    Public MForm As Windows.Forms.Form
    Public ToolTip As Windows.Forms.ToolTip
    Public FPS As Double = 29.97
    Public BPS As Integer = 14400
    Public LastFrame As Integer = 3
    Public bMakeVideo As Boolean = False
    Public ffmpegpath As String = IO.Path.Combine(IO.Path.GetTempPath, "ansiconvffmpeg.exe")
    Public iFramesCount As Integer = 0
    Public sCodePg As String
    Public sCodePgOut As String
    Public sCodePgIn As String
    Public TempVideoFolder As String
    Public bHTMLEncode As Boolean
    Public bHTMLComplete As Boolean = True
    Public bSanitize As Boolean
    Public bCUFon As Boolean = False
    Public OutputFileExists As Integer = 0
    Public bForceOverwrite As Boolean = False
    Public sHTMLFont As String = "Default"
    Public bConv2Unicode As Boolean
    Public sOutPutFormat As String
    Public sInputFormat As String
    Public CPS As AnsiCPMaps.AnsiCPMaps = AnsiCPMaps.AnsiCPMaps.Instance
    Public ForeColor As Integer = 7, BackColor As Integer = 0, Blink As Boolean = False
    Public Bold As Integer = 0, Intense As Integer = 0, Reversed As Boolean = False
    Public XPos As Integer = 1, YPos As Integer = 1
    Public LineWrap As Boolean = False
    Public LinesUsed As Integer = 0
    Public iLoop As Integer = 0
    'Public DosFnt80x25 As New MediaSupport.Ansifntdef(8, 16, Drawing.Color.FromArgb(255, 32, 32, 32), My.Resources.dosfont80x25c16b2, My.Resources.dosfontback16c)
    'Public DosFnt80x50 As New MediaSupport.Ansifntdef(8, 8, Drawing.Color.FromArgb(255, 32, 32, 32), My.Resources.dosfont80x50c16b2, My.Resources.dosfontback16c)
    Public DosFnt80x25 As New MediaSupport.Ansifntdef(8, 16, Drawing.Color.FromArgb(255, 0, 0, 0), My.Resources.fnt80x25, My.Resources.dosfontback16c)
    Public DosFnt80x50 As New MediaSupport.Ansifntdef(8, 8, Drawing.Color.FromArgb(255, 0, 0, 0), My.Resources.fnt80x50, My.Resources.dosfontback16c)
    Public Screen(,) As ConverterSupport.ScreenChar
    Public sCSSDef = ""
    Public bAnimation As Boolean = False

    Public OutFileWrite As String = ""
    Public ProcFilesCounter As Integer = 0
    Public bExtInp As Boolean = False
    Public ListInputFiles As New List(Of FileListItem)

    Public pBBS As String = "PCB"
    'Public currCPBlockzoompanel As xPanel
    Public Const DefForeColor = 7
    Public Const DefBackColor = 0
    Public Const DefBold = 0
    Public oSauce As New ConverterSupport.SauceMeta
    Public bHasSauce As Boolean = False
    Public bOutputSauce As Boolean = False

    Public Yoffset As Integer = 0
    'Img 

    '    Public m_FontBmp As Bitmap

    'Public m_TopOffSet As Integer = 0
    'Public m_Margins As New Windows.Forms.Padding(0)
    ' Public DosFont As MediaSupport.Ansifntdef = Nothing
    'Public m_BackgroundColor As Drawing.Color = Color.Black
    'Public m_TextColor As Drawing.Color = Color.FromArgb(255, 168, 168, 168)
    ' Public DosFontSml As MediaSupport.Ansifntdef = Nothing
    Public WebFontList As New ArrayList
    Public SelectedWebFont As Integer = 0
    Public Const minX = 1
    Public maxX As Integer = 80
    Public Const minY = 1
    Public maxY As Integer = 1500




End Module
