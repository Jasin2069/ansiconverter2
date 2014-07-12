Public Enum CodePg
    CP437 = 0
    CP737 = 1
    CP775 = 2
    CP850 = 3
    CP852 = 4
    CP855 = 5
    CP857 = 6
    CP858 = 7
    CP860 = 8
    CP861 = 9
    CP862 = 10
    CP863 = 11
    CP864 = 12
    CP865 = 13
    CP866 = 14
    CP869 = 15
    CP874 = 16
    CP1250 = 17
    CP1251 = 18
    CP1252 = 19
    CP1253 = 20
    CP1254 = 21
    CP1255 = 22
    CP1256 = 23
    CP1257 = 24
    CP1258 = 25
    CP874W = 26
    CP932 = 27
    CP936 = 28
    CP949 = 29
    CP950 = 30
End Enum

Public Structure CP
    Public Name As String
    Public Description As String
    Public OS As String
    Public ISO As String
    Public Map() As String
    Public Desc() As String
    Public HTML() As String

    Public Sub New(ByVal n As String, ByVal D As String, ByVal O As String, ByVal I As String, ByVal sMap As String, ByVal sDesc As String, ByVal sHTML As String)
        Name = n
        Description = D
        OS = O
        ISO = I
        Map = Split(sMap, ",")
        Desc = Split(sDesc, ",")
        HTML = Split(sHTML, ",")
    End Sub
    Public Function toUniHex(ByVal ascchar As Byte) As String
        Return Strings.Right("0000" & Hex(CInt(Map(ascchar))), 4)
    End Function
    Public Function toHex(ByVal ascchar As Byte) As String
        Return Strings.Right("00" & Hex(CInt(ascchar)), 2)
    End Function
    Public Function toASC(ByVal unichar As Integer) As Byte
        Dim bteOut As Byte = 32
        If unichar <= 127 Then
            Return CByte(unichar)
        Else
            Dim bteLoop As Byte
            For bteLoop = 0 To 255
                If Me.Map(bteLoop).ToString = unichar.ToString Then
                    bteOut = bteLoop
                    Exit For
                End If
            Next
            Return bteOut
        End If
    End Function
    Public Function SpecialHTML(ByVal ascchar As Byte) As String
        Return HTML(ascchar)
    End Function
    Public Function toUNI(ByVal ascchar As Byte) As Integer
        Return CInt(Map(ascchar))
    End Function
    Public Function ASCtoHTML(ByVal ascchar As Byte) As String
        If HTML(ascchar) <> "" Then
            Return HTML(ascchar)
        Else
            Return "&#" & Map(ascchar) & ";"
        End If
    End Function
    Public Function ASCtoHTMLDec(ByVal ascchar As Byte) As String
        Return "&#" & Map(ascchar) & ";"
    End Function
    Public Function ASCtoHTMLHex(ByVal ascchar As Byte) As String
        Return "&#x" & Hex(Map(ascchar)) & ";"
    End Function

End Structure

Public Class clsCodePage
    Private myID As CodePg
    Private myCode As String
    Private myISO As String
    Private myName As String

    Public Sub New(ByVal ID As CodePg, ByVal Name As String, ByVal Code As String, ByVal ISO As String)
        Me.myID = ID
        Me.myCode = Code
        Me.myName = Name
        Me.myISO = ISO
    End Sub 'New
    Public ReadOnly Property ID() As CodePg
        Get
            Return myID
        End Get
    End Property
    Public ReadOnly Property Description() As String
        Get
            Return Me.myCode & " (" & Me.myName & ") " & Me.myISO
        End Get
    End Property
    Public ReadOnly Property Code() As String
        Get
            Return myCode
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return myName
        End Get
    End Property
    Public ReadOnly Property ISO() As String
        Get
            Return myISO
        End Get
    End Property

End Class 'CodePage

Public Class AnsiCPMaps
    Private Shared m_instance As AnsiCPMaps = Nothing
    Public Shared ReadOnly Property Instance() As AnsiCPMaps
        Get
            If m_instance Is Nothing Then
                m_instance = New AnsiCPMaps()
            End If

            Return m_instance

        End Get

    End Property

    Public CodePagesSelection As ArrayList
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

    Public aCPLN() As String
    Public aCPL() As String
    Public aCPLISO() As String
    Public aWinCPL() As String
    Public aWinCPLN() As String
    Public aWinCPLISO() As String

    Private Sub New()

        aCPLN = Split(sCPLN, "|")
        aCPL = Split(sCPL, "|")
        aCPLISO = Split(sCPLISO, "|")
        aWinCPL = Split(sWinCPL, "|")
        aWinCPLN = Split(sWinCPLN, "|")
        aWinCPLISO = Split(sWinCPLISO, "|")

        CodePages = New List(Of CP)
        CodePagesSelection = New ArrayList
        CP437 = New CP("CP437", "Latin US/United States/Canada", "DOS", "iso-8859-1", sUniCodeCP437, sCP437desc, sCP437HTML)
        CodePages.Add(CP437)
        CP737 = New CP("CP737", "Greek", "DOS", "iso-8859-7", sUniCodeCP737, sCP737desc, sCP737HTML)
        CodePages.Add(CP737)
        CP775 = New CP("CP775", "Baltic Rim", "DOS", "iso-8859-4", sUniCodeCP775, sCP775desc, sCP775HTML)
        CodePages.Add(CP775)
        CP850 = New CP("CP850", "Latin 1 (Western Europe: DE, FR, ES)", "DOS", "iso-8859-1", sUniCodeCP850, sCP850desc, sCP850HTML)
        CodePages.Add(CP850)
        CP852 = New CP("CP852", "Latin 2 (Slavic: PL, RU, BA, HR, HU, CZ, SK)", "DOS", "iso-8859-2", sUniCodeCP852, sCP852desc, sCP852HTML)
        CodePages.Add(CP852)
        CP855 = New CP("CP855", "Cyrillic (RU, BG, UA)", "DOS", "iso-8859-5", sUniCodeCP855, sCP855desc, sCP855HTML)
        CodePages.Add(CP855)
        CP857 = New CP("CP857", "Turkish, TR", "DOS", "iso-8859-9", sUniCodeCP857, sCP857desc, sCP857HTML)
        CodePages.Add(CP857)
        CP858 = New CP("CP858", "Latin 1 Alt (= 850, 0xD5 = U+20AC EURO SYM)", "DOS", "iso-8859-1", sUniCodeCP858, sCP858desc, sCP858HTML)
        CodePages.Add(CP858)
        CP860 = New CP("CP860", "Portuguese, PT", "DOS", "iso-8859-15", sUniCodeCP860, sCP860desc, sCP860HTML)
        CodePages.Add(CP860)
        CP861 = New CP("CP861", "Islandic, IS", "DOS", "iso-8859-8", sUniCodeCP861, sCP861desc, sCP861HTML)
        CodePages.Add(CP861)
        CP862 = New CP("CP862", "Hebrew, IL", "DOS", "iso-8859-1", sUniCodeCP862, sCP862desc, sCP862HTML)
        CodePages.Add(CP862)
        CP863 = New CP("CP863", "Canada, CA (French)", "DOS", "iso-8859-1", sUniCodeCP863, sCP863desc, sCP863HTML)
        CodePages.Add(CP863)
        CP864 = New CP("CP864", "Arabic", "DOS", "iso-8859-5", sUniCodeCP864, sCP864desc, sCP864HTML)
        CodePages.Add(CP864)
        CP865 = New CP("CP865", "Nordic (except IS) (DK, SE, NO, FI)", "DOS", "iso-8859-7", sUniCodeCP865, sCP865desc, sCP865HTML)
        CodePages.Add(CP865)
        CP866 = New CP("CP866", "Cyrillic Russian (based on GOST 19768-87)", "DOS", "tactis", sUniCodeCP866, sCP866desc, sCP866HTML)
        CodePages.Add(CP866)
        CP869 = New CP("CP869", "Greek 2 (IBM Modern GR)", "DOS", "-", sUniCodeCP869, sCP869desc, sCP869HTML)
        CodePages.Add(CP869)
        CP874 = New CP("CP874", "MS-DOS Thai", "DOS", "-", sUniCodeCP874, sCP874desc, sCP874HTML)
        CodePages.Add(CP874)


        CP1250 = New CP("CP1250", "Windows Latin-2", "WIN", "iso-8859-2", sWinUniCodeCP1250, sWinCP1250desc, sCP1250HTML)
        CodePages.Add(CP1250)
        CP1251 = New CP("CP1251", "Windows Cyrillic", "WIN", "iso-8859-5", sWinUniCodeCP1251, sWinCP1251desc, sCP1251HTML)
        CodePages.Add(CP1251)
        CP1252 = New CP("CP1252", "Windows Latin-1", "WIN", "us-ascii", sWinUniCodeCP1252, sWinCP1252desc, sCP1252HTML)
        CodePages.Add(CP1252)
        CP1253 = New CP("CP1253", "Windows Greek", "WIN", "iso-8859-7", sWinUniCodeCP1253, sWinCP1253desc, sCP1253HTML)
        CodePages.Add(CP1253)
        CP1254 = New CP("CP1254", "Windows Turkish", "WIN", "iso-8859-9", sWinUniCodeCP1254, sWinCP1254desc, sCP1254HTML)
        CodePages.Add(CP1254)
        CP1255 = New CP("CP1255", "Windows Hebrew", "WIN", "iso-8859-8", sWinUniCodeCP1255, sWinCP1255desc, sCP1255HTML)
        CodePages.Add(CP1255)
        CP1256 = New CP("CP1256", "Windows Arabic", "WIN", "-", sWinUniCodeCP1256, sWinCP1256desc, sCP1256HTML)
        CodePages.Add(CP1256)
        CP1257 = New CP("CP1257", "Windows Baltic (1)", "WIN", "iso-8859-4", sWinUniCodeCP1257, sWinCP1257desc, sCP1257HTML)
        CodePages.Add(CP1257)
        CP1258 = New CP("CP1258", "Windows Vietnamese", "WIN", "-", sWinUniCodeCP1258, sWinCP1258desc, sCP1258HTML)
        CodePages.Add(CP1258)
        CP874W = New CP("CP874", "Windows Thai", "WIN", "tactis", sWinUniCodeCP874, sWinCP874desc, sCP874WHTML)
        CodePages.Add(CP874W)
        CP932 = New CP("CP932", "Windows Japanese", "WIN", "-", sWinUniCodeCP932, sWinCP932desc, sCP932HTML)
        CodePages.Add(CP932)
        CP936 = New CP("CP936", "Windows Chinese (VRCN)", "WIN", "-", sWinUniCodeCP936, sWinCP936desc, sCP936HTML)
        CodePages.Add(CP936)
        CP949 = New CP("CP949", "Windows Korean", "WIN", "-", sWinUniCodeCP949, sWinCP949desc, sCP949HTML)
        CodePages.Add(CP949)
        CP950 = New CP("CP950", "Windows Chinese (HK)", "WIN", "-", sWinUniCodeCP950, sWinCP950desc, sCP950HTML)
        CodePages.Add(CP950)

        Dim iEnumCnt As Integer = 0
        For a As Integer = 0 To UBound(aCPL)

            CodePagesSelection.Add(New clsCodePage(iEnumCnt, aCPLN(a) & " (" & aCPL(a) & ")", aCPL(a), aCPLISO(a)))
            iEnumCnt += 1
        Next
        For a As Integer = 0 To UBound(aWinCPL)
            CodePagesSelection.Add(New clsCodePage(iEnumCnt, aWinCPLN(a) & " (" & aCPL(a) & ")", aWinCPL(a), aWinCPLISO(a)))
            iEnumCnt += 1
        Next

    End Sub

End Class


Public Class UniBlock
    Public sName As String = ""
    Public IFrom As Integer = 0
    Public iTo As Integer = 0
    Public myKey As String = ""
    Public sFrom As String = ""
    Public sTo As String = ""
    Public MyDisplay As String = ""
    Public ReadOnly Property sKey() As String
        Get
            Return myKey
        End Get
    End Property

    Public ReadOnly Property sDisplay() As String
        Get
            Return MyDisplay
        End Get
    End Property

    Public Sub New()
        sName = ""
        IFrom = 0
        iTo = 0
        sFrom = ""
        sTo = ""
        myKey = "-"
        MyDisplay = ""
    End Sub
    Public Sub New(ByVal N As String, ByVal F As String, ByVal T As String)
        sName = N
        sFrom = F
        IFrom = Me.HexToDec(sFrom)
        sTo = T
        iTo = Me.HexToDec(sTo)
        myKey = sFrom & "-" & sTo
        MyDisplay = myKey & " : " & sName & " (" & CStr(iTo - IFrom + 1) & " characters)"
    End Sub
    '---------------------------------------------------------------------------
    Private Function HexToDec(ByVal strHex As String) As Int64
        Dim lngResult As Int64 = 0, intIndex As Integer, strDigit As String
        Dim intDigit As Int64, intValue As Int64
        For intIndex = Strings.Len(strHex) To 1 Step -1
            strDigit = Strings.Mid(strHex, intIndex, 1)
            intDigit = InStr("0123456789ABCDEF", UCase(strDigit)) - 1
            If intDigit >= 0 Then
                intValue = intDigit * (16 ^ (Strings.Len(strHex) - CLng(intIndex)))
                lngResult = lngResult + intValue
            Else
                lngResult = 0 : intIndex = 0 ' stop the loop
            End If
        Next
        Return lngResult
    End Function

End Class
