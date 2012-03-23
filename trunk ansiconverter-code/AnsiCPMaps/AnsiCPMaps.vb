Public Structure CP
    Public Name As String
    Public Description As String
    Public OS As String
    Public ISO As String
    Public Map() As String
    Public Desc() As String
    Public Sub New(ByVal n As String, ByVal D As String, ByVal O As String, ByVal I As String, ByVal sMap As String, ByVal sDesc As String)
        Name = n
        Description = D
        OS = O
        ISO = I
        Map = Split(sMap, ",")
        Desc = Split(sDesc, ",")
    End Sub
End Structure
Public Class AnsiCPMaps

    Public CodePages As List(Of CP)
    Public CP437 As CP
    Public CP737 As CP
    Public CP775 As CP
    Public CP850 As CP
    Public CP852 As CP
    Public CP855 As CP
    Public CP857 As CP
    Public CP858 As CP
    Public CP860 As CP
    Public CP861 As CP
    Public CP862 As CP
    Public CP863 As CP
    Public CP864 As CP
    Public CP865 As CP
    Public CP866 As CP
    Public CP869 As CP
    Public CP874 As CP

    Public CP1250 As CP
    Public CP1251 As CP
    Public CP1252 As CP
    Public CP1253 As CP
    Public CP1254 As CP
    Public CP1255 As CP
    Public CP1256 As CP
    Public CP1257 As CP
    Public CP1258 As CP
    Public CP874W As CP
    Public CP932 As CP
    Public CP936 As CP
    Public CP949 As CP
    Public CP950 As CP

    Public Sub New()
        CodePages = New List(Of CP)
        CP437 = New CP("CP437", "Latin US/United States/Canada", "DOS", "iso-8859-1", sUniCodeCP437, sCP437desc)
        CodePages.Add(CP437)
        CP737 = New CP("CP737", "Greek", "DOS", "iso-8859-7", sUniCodeCP737, sCP737desc)
        CodePages.Add(CP737)
        CP775 = New CP("CP775", "Baltic Rim", "DOS", "iso-8859-4", sUniCodeCP775, sCP775desc)
        CodePages.Add(CP775)
        CP850 = New CP("CP850", "Latin 1 (Western Europe: DE, FR, ES)", "DOS", "iso-8859-1", sUniCodeCP850, sCP850desc)
        CodePages.Add(CP850)
        CP852 = New CP("CP852", "Latin 2 (Slavic: PL, RU, BA, HR, HU, CZ, SK)", "DOS", "iso-8859-2", sUniCodeCP852, sCP852desc)
        CodePages.Add(CP852)
        CP855 = New CP("CP855", "Cyrillic (RU, BG, UA)", "DOS", "iso-8859-5", sUniCodeCP855, sCP855desc)
        CodePages.Add(CP855)
        CP857 = New CP("CP857", "Turkish, TR", "DOS", "iso-8859-9", sUniCodeCP857, sCP857desc)
        CodePages.Add(CP857)
        CP858 = New CP("CP858", "Latin 1 Alt (= 850, 0xD5 = U+20AC EURO SYM)", "DOS", "iso-8859-1", sUniCodeCP858, sCP858desc)
        CodePages.Add(CP858)
        CP860 = New CP("CP860", "Portuguese, PT", "DOS", "iso-8859-15", sUniCodeCP860, sCP860desc)
        CodePages.Add(CP860)
        CP861 = New CP("CP861", "Islandic, IS", "DOS", "iso-8859-8", sUniCodeCP861, sCP861desc)
        CodePages.Add(CP861)
        CP862 = New CP("CP862", "Hebrew, IL", "DOS", "iso-8859-1", sUniCodeCP862, sCP862desc)
        CodePages.Add(CP862)
        CP863 = New CP("CP863", "Canada, CA (French)", "DOS", "iso-8859-1", sUniCodeCP863, sCP863desc)
        CodePages.Add(CP863)
        CP864 = New CP("CP864", "Arabic", "DOS", "iso-8859-5", sUniCodeCP864, sCP864desc)
        CodePages.Add(CP864)
        CP865 = New CP("CP865", "Nordic (except IS) (DK, SE, NO, FI)", "DOS", "iso-8859-7", sUniCodeCP865, sCP865desc)
        CodePages.Add(CP865)
        CP866 = New CP("CP866", "Cyrillic Russian (based on GOST 19768-87)", "DOS", "tactis", sUniCodeCP866, sCP866desc)
        CodePages.Add(CP866)
        CP869 = New CP("CP869", "Greek 2 (IBM Modern GR)", "DOS", "-", sUniCodeCP869, sCP869desc)
        CodePages.Add(CP869)
        CP874 = New CP("CP874", "MS-DOS Thai", "DOS", "-", sUniCodeCP874, sCP874desc)
        CodePages.Add(CP874)


        CP1250 = New CP("CP1250", "Windows Latin-2", "WIN", "iso-8859-2", sWinUniCodeCP1250, sWinCP1250desc)
        CodePages.Add(CP1250)
        CP1251 = New CP("CP1251", "Windows Cyrillic", "WIN", "iso-8859-5", sWinUniCodeCP1251, sWinCP1251desc)
        CodePages.Add(CP1251)
        CP1252 = New CP("CP1252", "Windows Latin-1", "WIN", "us-ascii", sWinUniCodeCP1252, sWinCP1252desc)
        CodePages.Add(CP1252)
        CP1253 = New CP("CP1253", "Windows Greek", "WIN", "iso-8859-7", sWinUniCodeCP1253, sWinCP1253desc)
        CodePages.Add(CP1253)
        CP1254 = New CP("CP1254", "Windows Turkish", "WIN", "iso-8859-9", sWinUniCodeCP1254, sWinCP1254desc)
        CodePages.Add(CP1254)
        CP1255 = New CP("CP1255", "Windows Hebrew", "WIN", "iso-8859-8", sWinUniCodeCP1255, sWinCP1255desc)
        CodePages.Add(CP1255)
        CP1256 = New CP("CP1256", "Windows Arabic", "WIN", "-", sWinUniCodeCP1256, sWinCP1256desc)
        CodePages.Add(CP1256)
        CP1257 = New CP("CP1257", "Windows Baltic (1)", "WIN", "iso-8859-4", sWinUniCodeCP1257, sWinCP1257desc)
        CodePages.Add(CP1257)
        CP1258 = New CP("CP1258", "Windows Vietnamese", "WIN", "-", sWinUniCodeCP1258, sWinCP1258desc)
        CodePages.Add(CP1258)
        CP874W = New CP("CP874", "Windows Thai", "WIN", "tactis", sWinUniCodeCP874, sWinCP874desc)
        CodePages.Add(CP874W)
        CP932 = New CP("CP932", "Windows Japanese", "WIN", "-", sWinUniCodeCP932, sWinCP932desc)
        CodePages.Add(CP932)
        CP936 = New CP("CP936", "Windows Chinese (VRCN)", "WIN", "-", sWinUniCodeCP936, sWinCP936desc)
        CodePages.Add(CP936)
        CP949 = New CP("CP949", "Windows Korean", "WIN", "-", sWinUniCodeCP949, sWinCP949desc)
        CodePages.Add(CP949)
        CP950 = New CP("CP950", "Windows Chinese (HK)", "WIN", "-", sWinUniCodeCP950, sWinCP950desc)
        CodePages.Add(CP950)
    End Sub

End Class
