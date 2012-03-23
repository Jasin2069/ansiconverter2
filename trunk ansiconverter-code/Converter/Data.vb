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
    Public oAnsi As New ANSI
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
    Public aInp() As String = New String() {"ASC", "ANS", "HTML", "UTF", "PCB", "BIN", "WC2", "WC3", "AVT", "IMG", "VID"}
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
    Public oAVIFile As New AviWriter
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
    Public CPS As AnsiCPMaps.AnsiCPMaps = New AnsiCPMaps.AnsiCPMaps
    Public ForeColor As Integer = 7, BackColor As Integer = 0, Blink As Boolean = False
    Public Bold As Integer = 0, Intense As Integer = 0, Reversed As Boolean = False
    Public XPos As Integer = 1, YPos As Integer = 1
    Public LineWrap As Boolean = False
    Public LinesUsed As Integer = 0
    Public iLoop As Integer = 0
    Public DosFnt80x25 As New Ansifntdef
    Public DosFnt80x50 As New Ansifntdef
    Public aSpecH(255) As String
    Public aCPdesc() As String
    Public aUniCode As String()
    Public aCSS(2, 15) As String
    Public Screen(,) As ScreenChar
    Public sCSSDef = ""
    Public bAnimation As Boolean = False
    Public aCPLN() As String
    Public aCPL() As String
    Public aCPLISO() As String
    Public aWinCPL() As String
    Public aWinCPLN() As String
    Public aWinCPLISO() As String
    Public OutFileWrite As String = ""
    Public ProcFilesCounter As Integer = 0
    Public bExtInp As Boolean = False
    Public ListInputFiles As New List(Of FileListItem)
    Public UTF16Hdr As Byte() = New Byte() {255, 254}
    Public UTF8Hdr As Byte() = New Byte() {239, 187, 191}
    Public ANSIHdr As Byte() = New Byte() {27, 91, 50, 53, 53, 68, 27, 91, 52, 48, 109} '<[255D<[40m "<" = ESC
    Public PCBHdr As Byte() = New Byte() {64, 88, 48, 55} '@X07
    Public pBBS As String = "PCB"
    'Public currCPBlockzoompanel As xPanel
    Public Const DefForeColor = 7
    Public Const DefBackColor = 0
    Public Const DefBold = 0
    Public oSauce As New SauceMeta
    Public bHasSauce As Boolean = False
    Public bOutputSauce As Boolean = False
    Public sSauceCSS As String = ""

    Public Yoffset As Integer = 0
    'Img 
    Public m_NFOTextImg As Bitmap
    Public m_FontBmp As Bitmap
    Public m_NFOText As String = ""
    Public m_TopOffSet As Integer = 0
    Public m_Margins As New Windows.Forms.Padding(0)
    Public DosFont As Ansifntdef = Nothing
    Public m_BackgroundColor As Drawing.Color = Color.Black
    Public m_TextColor As Drawing.Color = Color.FromArgb(255, 168, 168, 168)
    Public DosFontSml As Ansifntdef = Nothing
    Public WebFontList As New ArrayList
    Public SelectedWebFont As Integer = 0
    Public Const minX = 1
    Public maxX As Integer = 80
    Public Const minY = 1
    Public maxY As Integer = 1500
    Public AnsiColorsARGBM As New List(Of System.Windows.Media.Color)
    Public AnsiColorsARGB As Drawing.Color() = New Drawing.Color() { _
            Drawing.Color.FromArgb(255, 0, 0, 0), _
            Drawing.Color.FromArgb(255, 0, 0, 173), _
            Drawing.Color.FromArgb(255, 0, 173, 0), _
            Drawing.Color.FromArgb(255, 0, 173, 173), _
            Drawing.Color.FromArgb(255, 173, 0, 0), _
            Drawing.Color.FromArgb(255, 173, 0, 173), _
            Drawing.Color.FromArgb(255, 173, 82, 0), _
            Drawing.Color.FromArgb(255, 173, 173, 173), _
            Drawing.Color.FromArgb(255, 82, 82, 82), _
            Drawing.Color.FromArgb(255, 82, 82, 255), _
            Drawing.Color.FromArgb(255, 82, 255, 82), _
            Drawing.Color.FromArgb(255, 82, 255, 255), _
            Drawing.Color.FromArgb(255, 255, 82, 82), _
            Drawing.Color.FromArgb(255, 255, 82, 255), _
            Drawing.Color.FromArgb(255, 255, 255, 82), _
            Drawing.Color.FromArgb(255, 255, 255, 255)}

    Public AnsiForeColors As String() = New String() {"30", "34", "32", "36", "31", "35", "33", "37"}
    Public AnsiBackColors As String() = New String() {"40", "44", "42", "46", "41", "45", "43", "47"}
    Public aCtrlChars As String() = New String() {"NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL", "BS", "HT", "LF", "VT", "FF", "CR", "SO", "SI", "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US", "SP"}

    Public TypeCounts() As Integer = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public Structure fmts
        Public elem As String
        Public fnt As fnts
        Public start As Stack(Of Integer)
        Sub New(ByVal e As String, ByVal f As fnts)
            elem = e
            fnt = f
            start = New Stack(Of Integer)
        End Sub
    End Structure
    Public Enum fnts
        bold = 1
        italic = 2
        underline = 3
        err = 4
    End Enum
    Public Structure sel
        Public format As fnts
        Public fromval As Integer
        Public toval As Integer
        Sub New(ByVal fn As fnts, ByVal f As Integer, ByVal t As Integer)
            format = fn
            fromval = f
            toval = t
        End Sub
    End Structure

    Public Enum FFormats
        us_ascii = 0
        utf_8 = 1
        utf_16 = 2
        utf_7 = 3
        utf_32 = 4
    End Enum
    Public Enum FTypes
        ASCII = 0
        ANSI = 1
        HTML = 2
        Unicode = 3
        PCB = 4
        Bin = 5
        WC2 = 6
        WC3 = 7
        AVT = 8
        IMG = 9
        VID = 10
    End Enum
    Public Structure WebFont
        Public Name As String
        Public StaticEXTRACSSDIV As String
        Public StaticEXTRACSSPRE As String
        Public StaticEXTRACSSSPAN As String
        Public AnimEXTRACSSDIV As String
        Public AnimEXTRACSSPRE As String
        Public AnimEXTRACSSSPAN As String
        Public Sub New(ByVal n As String, ByVal sDIV As String, ByVal sPRE As String, ByVal sSPAN As String, ByVal aDIV As String, ByVal aPRE As String, ByVal aSPAN As String)
            Name = n
            StaticEXTRACSSDIV = sDIV
            StaticEXTRACSSPRE = sPRE
            StaticEXTRACSSSPAN = sSPAN
            AnimEXTRACSSDIV = aDIV
            AnimEXTRACSSPRE = aPRE
            AnimEXTRACSSSPAN = aSPAN
        End Sub


    End Structure
    Public Class WebFontDef
        Private sName As String
        Private sStaticEXTRACSSDIV As String
        Private sStaticEXTRACSSPRE As String
        Private sStaticEXTRACSSSPAN As String
        Private sAnimEXTRACSSDIV As String
        Private sAnimEXTRACSSPRE As String
        Private sAnimEXTRACSSSPAN As String

        Public Sub New(ByVal n As String, ByVal sDIV As String, ByVal sPRE As String, ByVal sSPAN As String, ByVal aDIV As String, ByVal aPRE As String, ByVal aSPAN As String)
            Me.sName = n
            Me.sStaticEXTRACSSDIV = sDIV
            Me.sStaticEXTRACSSPRE = sPRE
            Me.sStaticEXTRACSSSPAN = sSPAN
            Me.sAnimEXTRACSSDIV = aDIV
            Me.sAnimEXTRACSSPRE = aPRE
            Me.sAnimEXTRACSSSPAN = aSPAN
        End Sub 'New

        Public ReadOnly Property Name() As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property StaticEXTRACSSDIV() As String
            Get
                Return sStaticEXTRACSSDIV
            End Get
        End Property
        Public ReadOnly Property StaticEXTRACSSPRE() As String
            Get
                Return sStaticEXTRACSSPRE
            End Get
        End Property
        Public ReadOnly Property StaticEXTRACSSSPAN() As String
            Get
                Return sStaticEXTRACSSSPAN
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSDIV() As String
            Get
                Return sAnimEXTRACSSDIV
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSPRE() As String
            Get
                Return sAnimEXTRACSSPRE
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSSPAN() As String
            Get
                Return sAnimEXTRACSSSPAN
            End Get
        End Property
    End Class 'WebFontDef


    Public Const sCPLN = "|Latin US/United States/Canada|Greek|Baltic Rim|Latin 1 (Western Europe: DE, FR, ES)|" & _
                  "Latin 2 (Slavic: PL, RU, BA, HR, HU, CZ, SK)|" & _
                  "Cyrillic (RU, BG, UA)|Turkish, TR|Latin 1 Alt (= 850, 0xD5 = U+20AC EURO SYM)|" & _
                  "Portuguese, PT|Islandic, IS|Hebrew, IL|Canada, CA (French)|Arabic|Nordic (except IS) (DK, SE, NO, FI)|" & _
                  "Cyrillic Russian (based on GOST 19768-87)|Greek 2 (IBM Modern GR)|MS-DOS Thai|"

    Public Const sWinCPLN = "|Windows Latin-2|Windows Cyrillic|Windows Latin-1|Windows Greek|Windows Turkish|Windows Hebrew|Windows Arabic|" & _
                     "Windows Baltic (1)|Windows Vietnamese|Windows Thai|Windows Japanese|Windows Chinese (VRCN)|Windows Korean|Windows Chinese (HK)|"

    Public Const sCPLISO = "|iso-8859-1|iso-8859-7|iso-8859-4|iso-8859-1|iso-8859-2|iso-8859-5|iso-8859-9|iso-8859-1" & _
                           "|iso-8859-15|iso-8859-8|iso-8859-1|iso-8859-1|iso-8859-5|iso-8859-7|tactis|-|-|"

    Public Const sWinCPLISO = "|iso-8859-2|iso-8859-5|us-ascii|iso-8859-7|iso-8859-9|iso-8859-8|-|iso-8859-4|-|tactis|-|-|-|"

    Public Const sCPL = "|CP437|CP737|CP775|CP850|CP852|CP855|CP857|CP858|CP860|CP861|CP862|CP863|CP864|CP865|CP866|CP869|CP874|"
    Public Const sWinCPL = "|CP1250|CP1251|CP1252|CP1253|CP1254|CP1255|CP1256|CP1257|CP1258|CP874|CP932|CP936|CP949|CP950|"



End Module
