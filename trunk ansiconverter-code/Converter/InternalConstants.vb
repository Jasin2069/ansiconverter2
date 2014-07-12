Namespace Internal
    ''' <summary>
    ''' Constants for Internal Use Only
    ''' </summary>
    ''' <remarks></remarks>
    Public Module InternalConstants
        Public aInp() As String = New String() {"ASC", "ANS", "HTML", "UTF", "PCB", "BIN", "WC2", "WC3", "AVT", "IMG", "VID"}
        Public UTF16Hdr As Byte() = New Byte() {255, 254}
        Public UTF8Hdr As Byte() = New Byte() {239, 187, 191}
        Public ANSIHdr As Byte() = New Byte() {27, 91, 50, 53, 53, 68, 27, 91, 52, 48, 109} '<[255D<[40m "<" = ESC
        Public PCBHdr As Byte() = New Byte() {64, 88, 48, 55} '@X07
        Public aCPLN() As String
        Public aCPL() As String
        Public aCPLISO() As String
        Public aWinCPL() As String
        Public aWinCPLN() As String
        Public aWinCPLISO() As String
        Public aSpecH(255) As String
        Public aCPdesc() As String
        Public aUniCode As String()
        Public aCSS(2, 15) As String
        Public sSauceCSS As String = ""
        Public MainThreadID As String = ""
        Public m_NFOTextImg As System.Drawing.Bitmap
        Public m_NFOText As String = ""
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
    End Module
End Namespace