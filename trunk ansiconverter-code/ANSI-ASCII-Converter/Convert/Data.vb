Imports System.Reflection
Imports AnsiCPMaps
Public Module Data

    Public oConv As New Converter.ProcessFiles
    Public sCodePg As String
    Public sCodePgOut As String
    Public sCodePgIn As String
    Public bDebug As Boolean = False
    Public bHTMLEncode As Boolean
    Public bHTMLComplete As Boolean = True
    Public bSanitize As Boolean
    Public bCUFon As Boolean = False
    Public OutputFileExists As Integer = 0
    Public bForceOverwrite As Boolean = False
    Public sHTMLFont As String = "Default"
    Public SelectedWebFont As Integer = 0
    Public bAddingFiles As Boolean = False
    Public bConv2Unicode As Boolean
    Public sOutPutFormat As String
    Public sInputFormat As String
    Public CPS As AnsiCPMaps.AnsiCPMaps = AnsiCPMaps.AnsiCPMaps.Instance
    Public executing_assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
    Public iLoop As Integer = 0
    Public oBASS As BassModNet = New BassModNet
    Public ThumbResizeOpt As Integer = 0
    Public ThumbResWidth As Integer = 0
    Public ThumbResHeight As Integer = 0
    Public ThumbResFact As Double = 1
    Public ImgSaveFileType As String = ".png"
    Public FPS As Double = 29.97
    Public BPS As Integer = 14000
    Public bAnimation As Boolean = False
    Public aCPLN() As String
    Public aCPL() As String
    Public aCPLISO() As String
    Public aWinCPL() As String
    Public aWinCPLN() As String
    Public aWinCPLISO() As String
    Public ProcFilesCounter As Integer = 0
    'Public ListIn As New List(Of Windows.Forms.RadioButton)
    Public ListIn2 As New List(Of Windows.Forms.CheckBox)
    Public ListInCPVis As New List(Of Boolean)
    Public ListOut As New List(Of Windows.Forms.RadioButton)
    Public ListUTF As New List(Of Windows.Forms.RadioButton)
    Public ListOutExist As New List(Of Windows.Forms.RadioButton)
    Public ListAnim As New List(Of Windows.Forms.RadioButton)
    Public ListHTMLObj As New List(Of Windows.Forms.RadioButton)
    Public ListOutPath As New List(Of Windows.Forms.RadioButton)
    Public ListExt As New List(Of Windows.Forms.RadioButton)
    Public ListSauce As New List(Of Windows.Forms.RadioButton)
    Public ListOutImg As New List(Of Windows.Forms.RadioButton)
    Public ListThumbScale As New List(Of Windows.Forms.RadioButton)
    Public ListVidOutFmt As New List(Of Windows.Forms.RadioButton)
    Public ListVidMpgCodec As New List(Of Windows.Forms.RadioButton)
    Public ListVidAviCodec As New List(Of Windows.Forms.RadioButton)
    Public ListBBSFormats As New List(Of Windows.Forms.RadioButton)
    Public ListAll As New List(Of List(Of Windows.Forms.RadioButton))
    Public ListOutExtExtend As New List(Of List(Of Windows.Forms.RadioButton))

    Public iSelectionStartBak As Integer = 0
    Public iLastRTFTextLen As Integer = 0
    Public bBatchAdd As Boolean = False
    Public LastFrame As Integer = 3
    Public ListAllLeft As New List(Of Integer)
    Public ListDepends As New List(Of ControlDepends)
    Public bUpdatingControls As Boolean = False
    Public MainFormLoaded As Boolean = False
    Public bExtInp As Boolean = False
    Public ListSettLabels As New List(Of Windows.Forms.Label)
    Public ListSettPanels As New List(Of Windows.Forms.Panel)
    Public ListOutExt As New List(Of String)
    Public ListOutExtTrig As New List(Of Windows.Forms.RadioButton)
    Public ListOutExtReqOutSet As New List(Of String)
    Public bNoDot As Boolean = True
    Public DotCount As Integer = 0
    Public currCPBlockZoomed As Integer = -1
    Public currCPBlockzoompanel As Windows.Forms.Panel
    Public currCPBlockShiftDown As Boolean = False
    'Public currCPBlockzoompanel As xPanel

    Public bOutputSauce As Boolean = False
    Public ListOrgPos As New List(Of Integer)
    Public aUniBlocks = New ArrayList()
    Public ListCntLabels As New List(Of Windows.Forms.Label)

    Public selectedFont As Font = UnicodeBlocks.lblCharTemplate.Font

    Public pBlock As New Windows.Forms.Panel
    Public selBlock As String = ""
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
        finished = 5
        sep = 6
        link = 7
        total = 8
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

    Friend Const sCPLN = "Latin US/United States/Canada|Greek|Baltic Rim|Latin 1 (Western Europe: DE, FR, ES)|" & _
              "Latin 2 (Slavic: PL, RU, BA, HR, HU, CZ, SK)|" & _
              "Cyrillic (RU, BG, UA)|Turkish, TR|Latin 1 Alt (= 850, 0xD5 = U+20AC EURO SYM)|" & _
              "Portuguese, PT|Islandic, IS|Hebrew, IL|Canada, CA (French)|Arabic|Nordic (except IS) (DK, SE, NO, FI)|" & _
              "Cyrillic Russian (based on GOST 19768-87)|Greek 2 (IBM Modern GR)|MS-DOS Thai"

    Friend Const sWinCPLN = "Windows Latin-2|Windows Cyrillic|Windows Latin-1|Windows Greek|Windows Turkish|Windows Hebrew|Windows Arabic|" & _
                     "Windows Baltic (1)|Windows Vietnamese|Windows Thai|Windows Japanese|Windows Chinese (VRCN)|Windows Korean|Windows Chinese (HK)"

    Friend Const sCPLISO = "iso-8859-1|iso-8859-7|iso-8859-4|iso-8859-1|iso-8859-2|iso-8859-5|iso-8859-9|iso-8859-1" & _
                           "|iso-8859-15|iso-8859-8|iso-8859-1|iso-8859-1|iso-8859-5|iso-8859-7|tactis|-|-"

    Friend Const sWinCPLISO = "iso-8859-2|iso-8859-5|us-ascii|iso-8859-7|iso-8859-9|iso-8859-8|-|iso-8859-4|-|tactis|-|-|-|-"

    Friend Const sCPL = "CP437|CP737|CP775|CP850|CP852|CP855|CP857|CP858|CP860|CP861|CP862|CP863|CP864|CP865|CP866|CP869|CP874"
    Friend Const sWinCPL = "CP1250|CP1251|CP1252|CP1253|CP1254|CP1255|CP1256|CP1257|CP1258|CP874|CP932|CP936|CP949|CP950"

    Public bWebConnectionIssue As Boolean = False

    Public Sub InitConst()

        AddHandler oConv.ProcessedFile, AddressOf evHandlerProcessedFile
        AddHandler oConv.InfoMsg, AddressOf evHandlerInfoMsg
        AddHandler oConv.ErrMsg, AddressOf evHandlerErrMsg
        AddHandler oConv.AdjustnumUTF16, AddressOf evHandlerAdjustnumUTF16
        AddHandler oConv.AdjustnumUTF8, AddressOf evHandlerAdjustnumUTF8
        AddHandler oConv.AdjustnumSel, AddressOf evHandlerAdjustnumSel
        AddHandler oConv.AdjustnumASCII, AddressOf evHandlerAdjustnumASCII
        AddHandler oConv.AdjustnumTotal, AddressOf evHandlerAdjustnumTotal
        AddHandler oConv.ProcessFinished, AddressOf evHandlerProcessFinished
        AddHandler oConv.ListItemRemoved, AddressOf evHandlerListItemRemoved
        Converter.MForm = oMainForm
        Converter.ToolTip = oMainForm.ToolTip1

        aCPLN = Split(sCPLN, "|")
        aCPL = Split(sCPL, "|")
        aCPLISO = Split(sCPLISO, "|")
        aWinCPL = Split(sWinCPL, "|")
        aWinCPLN = Split(sWinCPLN, "|")
        aWinCPLISO = Split(sWinCPLISO, "|")
        Try
            UniNamesList = BuildUniCodeNamesList(UniNamesList)
        Catch ex As System.Net.WebException
            bWebConnectionIssue = True
        Catch ex As Exception

        End Try


        Call InitRulez()
        Call InitializeForm()
        Try
            oBASS.ExportAndLoadAssembly()
        Catch ex As Exception

            Console.WriteLine("Error Loading Bass")
        End Try
    End Sub
End Module
