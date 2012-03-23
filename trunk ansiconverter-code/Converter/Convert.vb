Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.RegexOptions
Imports System.IO
Imports System.Text
Imports System.Windows.Media
Imports System.Windows.Forms
Imports System.Windows.Media.Imaging
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Collections.Generic
Imports System.Net.Mime.MediaTypeNames

Public Module Convert

    '---------------------------------------------------------------------------------
    'Conversion Routine 
    '---------------------------------------------------------------------------------
    Public Function UnicodeToAscii(ByVal iUChr As Integer) As String

        'Converts a Single Unicode ASCII Code to DOS ASCII String
        Dim a As Integer
        Dim result As String = ""
        If CInt(iUChr) < 128 And CInt(iUChr) > 0 Then
            result = Chr(iUChr)
        Else
            For a = 128 To 255
                If CStr(iUChr) = CStr(aUniCode(a)) Then
                    result = Chr(a) : Exit For
                End If
            Next
            System.Windows.Forms.Application.DoEvents()
            If result = "" Then
                'UnicodeToAscii = ChrW(iUChr)
                result = Space(1)
            End If
        End If
        Return result
    End Function
    Public Function AsciiToUnicode(ByVal iChr As Integer) As String
        'Converts a Single DOS ASCII Code to a Unicode String

        Dim result As String = ""
        Dim iUChr As Integer = aUniCode(iChr)
        If bHTMLEncode = True And aSpecH(iChr) <> "" Then
            result = aSpecH(iChr)
        Else
            result = ChrW(iUChr)
        End If

        If bSanitize = True Then
            If iChr < 32 Then
                Select Case iChr
                    Case 9      'Horizontal Tabulator (Tab)
                        If bHTMLEncode = True Then
                            result = Replace(Space(8), " ", "&nbsp;", 1, -1, CompareMethod.Text) 'Replace with eight spaces, the default Tab-Stop for DOS
                        Else
                            result = "        " 'Replace with eight spaces, the default Tab-Stop for DOS
                        End If
                    Case 10     'Line Feed (LF) 
                        'okay 
                    Case 13     'Carriage Return (CR)
                        'okay
                    Case Else
                        result = ""
                End Select
            End If
        End If
        Return result
    End Function

    Public Function convascuni(ByVal sInput As String) As String
        'Converts an entire DOS ASCII String to Unicode or HTML Encoded Unicode ASCII
        Dim swork As String = sInput, a As Integer, DestChr As String
        'Take care of Ampersand first
        a = 38 : DestChr = AscConv(a) : swork = Replace(swork, Chr(a), DestChr, 1, -1, CompareMethod.Binary)
        For a = 1 To 255
            If (a < 48 Or a > 57) And (a < 65 Or a > 90) And (a < 97 Or a > 122) And a <> 35 And a <> 59 And a <> 38 Then
                'Ignore 0-9, a-z, A-Z, # , ; and of course &  
                DestChr = AscConv(a) : swork = Replace(swork, Chr(a), DestChr, 1, -1, CompareMethod.Binary)
            End If
        Next
        System.Windows.Forms.Application.DoEvents()
        Return swork
    End Function
    '--------------------------------------------------------------
    Public Function convuniuni(ByVal sInput As String) As String
        Dim sWork As String = sInput
        Dim iPos As Integer = 1
        Dim iStart As Integer = 0
        Dim sChar As String = ""
        Dim iEnd As Integer = 0
        Dim sSearchStr As String = ""
        If sWork.Length > 5 Then
            Do While InStr(iPos, sWork, "&#", CompareMethod.Text) > 0
                iStart = InStr(iPos, sWork, "&#", CompareMethod.Text)
                If iStart > 0 Then
                    iStart += 2
                    iEnd = InStr(iPos, sWork, ";", CompareMethod.Text)
                    If iEnd > iStart Then
                        sChar = Strings.Mid(sWork, iStart, iEnd - iStart)
                        sSearchStr = "&#" & sChar & ";"
                        If LCase(Strings.Left(sChar, 1)) = "x" Then
                            sChar = Strings.Right(sChar, sChar.Length - 1)
                            If isHex(sChar) Then
                                sWork = Replace(sWork, sSearchStr, ChrW(HexToDec(sChar)), 1, -1, CompareMethod.Text)
                                iStart -= 2
                            End If
                        Else
                            If IsNumeric(sChar) Then
                                sWork = Replace(sWork, sSearchStr, ChrW(CInt(sChar)), 1, -1, CompareMethod.Text)
                                iStart -= 2
                            End If
                        End If
                    End If
                    iPos = iStart
                End If
            Loop
        End If
        Return sWork
    End Function
    '&#(x[0-9A-F]{1,5}|[0-9]{1,5});
    Public Function convuniasc(ByVal sInput As String) As String
        'Converts HTML Encoded Unicode String to DOS ASCII
        Dim swork As String = sInput, a As Integer, sHex As String, sChar As String
        For a = 128 To 255
            sHex = "&#x" & CStr(Hex(aUniCode(a))) & ";" : sChar = "&#" & CStr(aUniCode(a)) & ";"
            swork = Replace(swork, sHex, Chr(a), 1, -1, CompareMethod.Text)
            swork = Replace(swork, sChar, Chr(a), 1, -1, CompareMethod.Text)
        Next
        System.Windows.Forms.Application.DoEvents()
        For a = 32 To 255
            If aSpecH(a) <> "" Then : swork = Replace(swork, aSpecH(a), Chr(a), 1, -1, CompareMethod.Text) : End If
        Next
        Dim re As New System.Text.RegularExpressions.Regex("&#(?:x[0-9A-F]{1,5}|[0-9]{1,5});", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        swork = re.Replace(swork, " ", 1)

        System.Windows.Forms.Application.DoEvents()
        Return swork
    End Function

    Public Function AscConv(ByVal iChr As Integer) As String
        'Uses Global Settings "bHTMLEncode",if true, HTML Encoded String is returned, else the Unicode String
        'and "bSanitize", if True, TABs are converted to Spaces and Control Chars < 32 are being removed, except line breaks
        Dim sResult As String = "", s4 As String = ""
        If aSpecH(iChr) <> "" Then
            'Return Unicode Character or Special HTML Entity value for Character
            sResult = IIf(bHTMLEncode, aSpecH(iChr), ChrW(aUniCode(iChr)))
        Else
            If Int(aUniCode(iChr)) <> Int(iChr) Then
                'Return Unicode Character or HTML Encoded Unicode Char
                sResult = IIf(bHTMLEncode, "&#" & aUniCode(iChr) & ";", ChrW(aUniCode(iChr)))
            Else
                'Keep Original
                sResult = Chr(iChr)
            End If
        End If
        If bSanitize = True Then
            If iChr < 32 Then
                Select Case iChr
                    Case 9 : sResult = "        " 'Horizontal Tabulator (Tab), Replace with eight spaces, the default Tab-Stop for DOS
                    Case 10 'Line Feed (LF) OKAY
                    Case 13 'Carriage Return (CR) OKAY
                    Case Else : sResult = "" 'NOT OKAY
                End Select
            End If
        End If
        Return sResult
    End Function

    Public Function seekascuni(ByVal schr As String) As String
        'Convert a Single DOS ASCII String Character to Unicode or HTML Encoded Unicode
        Dim iASC As Integer = Asc(schr) : Return AscConv(iASC)
    End Function



    Function ReadSauce(ByVal aAnsi As Byte(), ByVal Offset As Integer) As SauceMeta
        'Read SAUCE Meta Tag Content from Byte Array to Special Sauce Meta Class
        Dim oSauce As SauceMeta
        Dim iLoop As Integer = Offset
        Dim sStr As String = ""
        oSauce = New SauceMeta
        oSauce.ID = ReadByteArray(aAnsi, 5, "s")
        oSauce.Version(0) = ReadByteArray(aAnsi, 1, "b")
        oSauce.Version(1) = ReadByteArray(aAnsi, 1, "b")
        oSauce.Title = ReadByteArray(aAnsi, 35, "s")
        oSauce.Author = ReadByteArray(aAnsi, 20, "s")
        oSauce.Group = ReadByteArray(aAnsi, 20, "s")
        oSauce.CreatedDate = ReadByteArray(aAnsi, 8, "s")
        oSauce.FileSize = HexToDec(FlipHex(ReadByteArray(aAnsi, 4, "h")))
        oSauce.DataType = CInt(ReadByteArray(aAnsi, 1, "b"))
        oSauce.FileType = CInt(ReadByteArray(aAnsi, 1, "b"))
        oSauce.TInfo1 = HexToDec(FlipHex(ReadByteArray(aAnsi, 2, "h")))
        oSauce.TInfo2 = HexToDec(FlipHex(ReadByteArray(aAnsi, 2, "h")))
        oSauce.TInfo3 = HexToDec(FlipHex(ReadByteArray(aAnsi, 2, "h")))
        oSauce.TInfo4 = HexToDec(FlipHex(ReadByteArray(aAnsi, 2, "h")))
        oSauce.Comments = CInt(ReadByteArray(aAnsi, 1, "b"))
        oSauce.Flags = CInt(ReadByteArray(aAnsi, 1, "b"))
        For x = 0 To 21
            oSauce.Filler(x) = ReadByteArray(aAnsi, 1, "b")
        Next
        If UBound(aAnsi) >= iLoop + (oSauce.Comments * 64) + 5 Then
            If oSauce.Comments <> 0 Then
                sStr = ReadByteArray(aAnsi, 5, "s")
                If sStr = "COMNT" Then
                    oSauce.SetComments(CInt(oSauce.Comments))
                    For iLoop2 = 1 To oSauce.Comments
                        oSauce.aComments(iLoop2) = ReadByteArray(aAnsi, 64, "s")
                    Next
                End If
            End If
        End If
        Return oSauce
    End Function
    Public Function ResizeScreen(ByVal aArr(,) As ScreenChar, ByVal iWidth As Integer, ByVal iHeight As Integer) As ScreenChar(,)
        Dim aNewScr(iWidth, iHeight) As ScreenChar
        For X As Integer = minX To iWidth
            For y As Integer = minY To iHeight
                If X <= UBound(aArr, 1) And y <= UBound(aArr, 2) Then
                    aNewScr(X, y) = aArr(X, y)
                Else
                    aNewScr(X, y) = New ScreenChar
                End If
            Next
        Next
        Return aNewScr
    End Function
    Function ReadByteArray(ByRef Arr() As Byte, ByVal iLen As Integer, ByVal DtaType As String) As String
        Dim a As Integer, sRes As String = ""
        If DtaType = "b" Then : iLen = 1 : End If
        For a = 1 To iLen
            If UBound(Arr) >= iLoop Then
                Select Case DtaType
                    Case "s" : sRes = sRes & Chr(Arr(iLoop))
                    Case "h" : sRes = sRes & Right("0" & Hex(Arr(iLoop)), 2)
                    Case "b" : sRes = Arr(iLoop)
                End Select
            End If
            iLoop = iLoop + 1
            If a / 100 = CInt(a / 100) Then System.Windows.Forms.Application.DoEvents()
        Next
        Return sRes
    End Function
    '----------------------------------------------------
    Public Function ANSIScreenToASCIIByteArray() As Byte()
        Dim bte As Byte(), cnt As Integer = 0
        ReDim bte(82 * LinesUsed)

        XPos = 1 : YPos = 1 : ForeColor = 7 : BackColor = 0
        For y As Integer = 1 To LinesUsed
            For x As Integer = 1 To 79
                ' If x = 1 Then
                If Screen(x, y).Chr <> Chr(0) Then
                    If Screen(x, y).Chr = "-1" Then
                        Exit For
                    Else
                        If Screen(x, y).Chr <> Chr(255) Then
                            cnt += 1 : bte(cnt) = Asc(Screen(x, y).Chr)
                        Else
                            cnt += 1 : bte(cnt) = 32
                        End If
                    End If
                Else
                    Exit For
                End If
                'End If
            Next
            cnt += 1 : bte(cnt) = 13
            cnt += 1 : bte(cnt) = 10
            If y / 100 = CInt(y / 100) Then System.Windows.Forms.Application.DoEvents()
        Next

        ReDim Preserve bte(cnt)
        Return bte

    End Function
    '----------------------------------------------------
    Public Function SetChar(ByVal sChar As String) As Boolean
        'Set Character in Global "Screen" Array at the Position of the global Loop Counter variable "iLoop"
        'Character is automatically converted to unicode, if global parameter "bConv2Unicode" is set to "True"
        'If global paramter "bHTMLEncode" is set to "True", the HTML Encoded version of the Unicode character is saved instead
        'Updates Global Variables: iLoop, XPos, YPos, LinesUsed, Screen
        'Also uses Global Variables: ForeColor, BackColor, Blink, Intense and Reversed; and Constants minX, maxX and maxY
        'Returns FALSE, if YPos reached its maximum
        ' cBPF += 1
        Dim bIncr As Boolean = True
        Dim bReturn As Boolean : bReturn = True
        If XPos >= minX And XPos <= maxX Then
            If CStr(sChar) = "-1" Or CStr(sChar) = "-2" Or CStr(sChar) = "-3" Then
                Select Case CStr(sChar)
                    Case "-1"
                        Screen(XPos, YPos) = New ScreenChar(XPos)
                    Case "-2"
                    Case "-3"
                        bIncr = False
                End Select
            Else
                If sChar.Length = 1 Then
                    Screen(XPos, YPos).DosChar = Asc(sChar)
                End If
                Screen(XPos, YPos).ForeColor = ForeColor : Screen(XPos, YPos).BackColor = BackColor : Screen(XPos, YPos).Bold = Bold
                If bConv2Unicode = True Then
                    Screen(XPos, YPos).Chr = IIf(bHTMLEncode, Replace(seekascuni(sChar), " ", "&nbsp;", 1, -1, CompareMethod.Text), seekascuni(sChar))
                Else
                    Screen(XPos, YPos).Chr = sChar
                End If
                Screen(XPos, YPos).Blink = Blink : Screen(XPos, YPos).Bold = Bold : Screen(XPos, YPos).Reversed = Reversed
            End If
        End If
        If bIncr Then
            XPos += 1
            If XPos > maxX Then
                YPos += 1
                If YPos > maxY - 1 Then : YPos = maxY - 1 : bReturn = False : Else : XPos = 1 : End If
            End If
            If YPos > LinesUsed Then
                If YPos > LinesUsed Then
                    If LinesUsed > 25 Then
                        Yoffset += (YPos - LinesUsed)
                    End If
                    LinesUsed = YPos
                End If
            End If
            Return bReturn
        Else
            XPos -= 1
            If XPos < minX Then
                YPos -= 1
                If YPos < minY Then : YPos = minY : XPos = minX : bReturn = False : Else : XPos = maxX : End If
            End If
            If YPos < Yoffset Then
                Yoffset = YPos - 1
            End If
            Return bReturn
            End If

    End Function

    '===========================================================
    'Generic Conversion Functions
    '===========================================================
    Public Function NotZero(ByVal iVal As Integer) As Integer
        Return IIf(iVal = 0, 1, iVal)
    End Function
    '----------------------------------------------------
    Public Function ChkNum(ByVal iVal As Object) As Integer
        If Trim(iVal) <> "" And Not iVal Is Nothing And IsNumeric(iVal) Then
            Return CInt(iVal)
        Else
            Return 0
        End If
    End Function

    Public Function UniHex(ByVal iNum As Integer) As String
        Return Right("0000" & Decimal2BaseN(iNum, 16), 4)
    End Function

    '--------------------------------------------------------------
    Public Function Decimal2BaseN(ByVal value As Integer, ByVal outBase As Integer) As String
        Dim quotient As Integer
        Dim reminder As Object
        Dim denominator As Integer
        Dim result As String = ""
        denominator = outBase
        quotient = value
        Do
            reminder = quotient Mod denominator
            quotient = CInt(quotient / denominator)
            If reminder >= 10 Then
                reminder = CStr(Chr(65 + (reminder - 10)))
            End If
            result &= CStr(reminder)
        Loop Until quotient = 0
        System.Windows.Forms.Application.DoEvents()
        Return StrReverse(result)
    End Function

    Public Function FlipHex(ByVal sHexStr As String) As String '(hex)
        Dim a As Integer, sResult As String = ""
        If sHexStr.Length Mod 2 <> 0 Then : Return sHexStr : Exit Function : End If
        For a = sHexStr.Length - 1 To 1 Step -2
            sResult &= Mid(sHexStr, a, 2)
        Next
        System.Windows.Forms.Application.DoEvents()
        Return sResult
    End Function
    ''' <summary>
    ''' Converts a string value to a "Byte Array"
    ''' </summary>
    ''' <param name="str">string</param>
    ''' <returns>Array of Byte()</returns>
    ''' <remarks></remarks>
    Public Function StrToByteArray(ByVal str As String, Optional ByVal enc As FFormats = FFormats.us_ascii) As Byte()
        Select Case enc
            Case FFormats.us_ascii
                Dim encoding As New System.Text.ASCIIEncoding
                Return encoding.GetBytes(str)
            Case FFormats.utf_7
                Dim encoding As New System.Text.UTF7Encoding()
                Return encoding.GetBytes(str)
            Case FFormats.utf_8
                Dim encoding As New System.Text.UTF8Encoding()
                Return encoding.GetBytes(str)
            Case FFormats.utf_16
                Dim encoding As New System.Text.UnicodeEncoding
                Return encoding.GetBytes(str)
            Case FFormats.utf_32
                Dim encoding As New System.Text.UTF32Encoding
                Return encoding.GetBytes(str)
            Case Else
                Dim encoding As New System.Text.ASCIIEncoding
                Return encoding.GetBytes(str)
        End Select

    End Function 'StrToByteArray

    ''' <summary>
    ''' Converts a Byte Array back to a string value
    ''' </summary>
    ''' <param name="ByteArray">Array of Byte's()</param>
    ''' <returns>String value</returns>
    ''' <remarks></remarks>
    Public Function ByteArrayToStr(ByVal ByteArray As Byte(), Optional ByVal enc As FFormats = FFormats.us_ascii) As String
        Select Case enc
            Case FFormats.us_ascii
                Dim encoding As New System.Text.ASCIIEncoding
                Return encoding.GetString(ByteArray)
            Case FFormats.utf_7
                Dim encoding As New System.Text.UTF7Encoding()
                Return encoding.GetString(ByteArray)
            Case FFormats.utf_8
                Dim encoding As New System.Text.UTF8Encoding()
                Return encoding.GetString(ByteArray)
            Case FFormats.utf_16
                Dim encoding As New System.Text.UnicodeEncoding
                Return encoding.GetString(ByteArray)
            Case FFormats.utf_32
                Dim encoding As New System.Text.UTF32Encoding
                Return encoding.GetString(ByteArray)
            Case Else
                Dim encoding As New System.Text.ASCIIEncoding
                Return encoding.GetString(ByteArray)
        End Select
        'str = encoding.GetString(ByteArray)
    End Function

    Public Function ByteArrayToString(ByVal ByteArray As Byte()) As String
        Dim result As String = ""
        For a As Integer = 0 To ByteArray.Length - 1
            If ByteArray(a) <> 0 Then
                result += Chr(ByteArray(a))
            End If
            If a / 1000 = CInt(a / 1000) Then System.Windows.Forms.Application.DoEvents()
        Next
        Return result
    End Function
    Public Function StringToByteArray(ByVal iStr As String) As Byte()
        Dim bte() As Byte = New Byte() {0}
        If iStr.Length > 0 Then
            ReDim bte(iStr.Length - 1)
            For a As Integer = 1 To iStr.Length
                bte(a - 1) = Asc(Mid(iStr, a, 1))
                If a / 1000 = CInt(a / 1000) Then System.Windows.Forms.Application.DoEvents()
            Next
        End If
        Return bte
    End Function
    Public Function HexStringToByteArray(ByVal sHexStr As String) As Byte()
        Dim a As Integer, dByte As Byte()
        If sHexStr.Length Mod 2 <> 0 Then
            Return Nothing
            Exit Function
        End If
        ReDim dByte(sHexStr.Length / 2 - 1)
        If sHexStr.Length > 2 Then
            For a = 1 To sHexStr.Length - 1 Step 2
                dByte((a - 1) / 2) = CByte(HexToDec(Mid(sHexStr, a, 2)))
                If a / 1000 = CInt(a / 1000) Then System.Windows.Forms.Application.DoEvents()
            Next
        Else
            dByte(0) = CByte(HexToDec(sHexStr))
        End If
        Return dByte
    End Function


    Public Function MergeByteArrays(ByVal bArr1 As Byte(), ByVal bArr2 As Byte()) As Byte()
        Dim iDim1 As Integer = 0, iDim2 As Integer = 0, iDimOut As Integer = 0
        Dim i As Integer = 0, bArrOut() As Byte
        iDim1 = UBound(bArr1) : iDim2 = UBound(bArr2) : iDimOut = iDim1 + iDim2 + 1
        ReDim bArrOut(iDimOut)
        For i = 0 To iDim1
            bArrOut(i) = bArr1(i)
            If i / 1000 = CInt(i / 1000) Then System.Windows.Forms.Application.DoEvents()
        Next
        For i = 0 To iDim2
            bArrOut(iDim1 + 1 + i) = bArr2(i)
            If i / 1000 = CInt(i / 1000) Then System.Windows.Forms.Application.DoEvents()
        Next
        MergeByteArrays = bArrOut
    End Function

    Public Function NullByteArray() As Byte()
        Dim aByte() As Byte = {0}
        Return aByte
    End Function

    Public Function NullByteArray(ByVal numb As Integer) As Byte()
        Dim i As Integer = 0
        Dim bArrOut() As Byte
        ReDim bArrOut(numb - 1)
        For i = 0 To numb - 1
            bArrOut(i) = 0
            If i / 1000 = CInt(i / 1000) Then System.Windows.Forms.Application.DoEvents()
        Next
        Return bArrOut
    End Function

    Public Function HexToDec(ByVal strHex As String) As Int64
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

    '  The ClearBit Sub clears the 1 based, nth bit 
    ' (MyBit) of an integer (MyByte).
    Public Sub ClearBit(ByRef MyByte As Byte, ByVal MyBit As Byte)
        Dim BitMask As Int16
        MyByte = MyByte And &HFF
        ' Create a bitmask with the 2 to the nth power bit set:
        BitMask = 2 ^ (MyBit - 1)
        ' Clear the nth Bit:
        MyByte = MyByte And Not BitMask
    End Sub

    ' The ExamineBit function will return True or False 
    ' depending on the value of the 1 based, nth bit (MyBit) 
    ' of an integer (MyByte).
    Public Function ExamineBit(ByVal MyByte As Byte, ByVal MyBit As Byte) As Boolean
        Dim BitMask As Int16
        MyByte = MyByte And &HFF
        BitMask = 2 ^ (MyBit - 1)
        ExamineBit = ((MyByte And BitMask) > 0)
    End Function

    ' The SetBit Sub will set the 1 based, nth bit 
    ' (MyBit) of an integer (MyByte).
    Public Sub SetBit(ByRef MyByte As Byte, ByVal MyBit As Byte)
        Dim BitMask As Int16
        MyByte = MyByte And &HFF
        BitMask = 2 ^ (MyBit - 1)
        MyByte = MyByte Or BitMask
    End Sub

    ' The ToggleBit Sub will change the state 
    ' of the 1 based, nth bit (MyBit)
    ' of an integer (MyByte).
    Public Sub ToggleBit(ByRef MyByte As Byte, ByVal MyBit As Byte)
        Dim BitMask As Int16
        MyByte = MyByte And &HFF
        BitMask = 2 ^ (MyBit - 1)
        MyByte = MyByte Xor BitMask
    End Sub
    Public Function SetCultureInfo(ByVal NumDigits As Integer) As System.Globalization.CultureInfo
        Dim nfio As New System.Globalization.CultureInfo("en-US")
        nfio.NumberFormat.NumberDecimalDigits = NumDigits
        nfio.NumberFormat.NumberDecimalSeparator = "."
        nfio.NumberFormat.NumberGroupSeparator = ","

        Return nfio
    End Function
    Public Function USStringRound(ByVal Value As Single, ByVal numdigits As Integer) As String
        Dim USNum As New System.Globalization.CultureInfo("en-US", False)
        Return Math.Round(CSng(Value.ToString("F", SetCultureInfo(numdigits))), numdigits).ToString(USNum)
    End Function


    ''' <summary>
    ''' Regular Expression Replace function
    ''' </summary>
    ''' <param name="sStr">String to Evaluate and Parse</param>
    ''' <param name="sRet">String with the Replacement Value/Pattern</param>
    ''' <param name="sPattern">Regular Expression Pattern</param>
    ''' <param name="RegExopt">RegEx Options</param>
    ''' <param name="isGlobal">Global Replace True/False (False = only replaces first found match, True = replace all matches in string</param>
    ''' <returns>String with replaced content</returns>
    ''' <remarks></remarks>
    Public Function RegExReplace(ByVal sStr As String, ByVal sRet As String, ByVal sPattern As String, _
                                 Optional ByVal RegExOpt As System.Text.RegularExpressions.RegexOptions = 0, _
                                 Optional ByVal isGlobal As Boolean = True) As String

        Dim re As New Regex(sPattern, RegExOpt)
        Dim sData As String
        If isGlobal = True Then
            sData = re.Replace(sStr, sRet)
        Else
            sData = re.Replace(sStr, sRet, 1)
        End If
        Return sData
    End Function
    ''' <summary>
    ''' Regular Expression Test Function to check if a string matches a provided RegEx pattern or not
    ''' </summary>
    ''' <param name="sStr">String to Evaluate</param>
    ''' <param name="sPattern">Regular Expression Pattern</param>
    ''' <param name="RegExopt">RegEx Options</param>
    ''' <returns>True is pattern matches, False if it does not</returns>
    ''' <remarks></remarks>
    Public Function RegExTest(ByVal sStr As String, ByVal sPattern As String, Optional ByVal RegExOpt As System.Text.RegularExpressions.RegexOptions = 0) As Boolean
        If RegExOpt AndAlso RegexOptions.Multiline Then
            sStr = Replace(sStr, vbCrLf, vbLf, 1, -1, CompareMethod.Text)
        End If
        Dim re As New Regex(sPattern, RegExOpt)
        Return re.IsMatch(sStr)
    End Function
    Public Function isInt(ByVal Value As String) As Boolean
        Return RegExTest(Value, "^[\d]{1,*}$")
    End Function
    Public Function CutorSandR(ByVal SInp As String, ByVal sFrom As String, ByVal sTo As String, _
                               ByVal sFromIE As String, ByVal sToIE As String, _
                               ByVal sMode As String, ByVal Num As String)

        Dim sPart1 As String, sPart2 As String, bFound As Boolean, iFrom As Integer, iTo As Integer
        Dim iCount As Integer, Ende As Boolean
        Dim sTemp As String
        '123456789
        '1AB45CD89
        'AB - CD
        '
        'InStr
        'AB  2
        'CD  6

        'Right CD
        'I Len(Str) - (InStr(CD) + Len(CD) - 1)
        'E Len(str) - (InStr(CD) - 1)
        'Left AB
        'I InStr(AB) - 1
        'E InStr(AB) + Len(AB) - 1

        iCount = 0
        If UCase(sMode) = "R" Then
            If Num <> "" And IsNumeric(Num) Then : SInp = Replace(SInp, sFrom, sTo, 1, CInt(Num), 1) : Else : SInp = Replace(SInp, sFrom, sTo, 1, -1, 1) : End If
        Else
            If UCase(sFromIE) = "A" Then : iFrom = 1 : sFromIE = "I" : Else : iFrom = InStr(1, SInp, sFrom, 1) : End If
            If iFrom > 0 Then : Ende = False : Else : Ende = True : End If

            While Ende = False
                iCount = iCount + 1
                If Num <> "" And IsNumeric(Num) Then
                    If CStr(iCount) = CStr(CInt(Num)) Then : Ende = True : End If
                End If
                bFound = False : sPart1 = "" : sPart2 = ""
                If iFrom > 0 Then
                    If UCase(sFromIE) = "I" Then 'Incl
                        If iFrom - 1 = 0 Then : sPart1 = "" : Else : sPart1 = Left(SInp, iFrom - 1) : End If
                    Else 'Excl
                        sPart1 = Left(SInp, iFrom + Len(sFrom) - 1)
                    End If
                    sTemp = Right(SInp, Len(SInp) - (iFrom + Len(sFrom) - 1))
                    If UCase(sToIE) = "Z" Then : iTo = Len(sTemp) + 1 : sToIE = "I" : Else : iTo = InStr(1, sTemp, sTo, 1) : End If
                    'sTemp = right(SInp,len(SInp)- instr(1,SInp,sFrom,1))
                    If iTo > 0 Then
                        bFound = True
                        If UCase(sToIE) = "I" Then 'Incl
                            If Len(sTemp) - (iTo + Len(sTo) - 1) = 0 Then : sPart2 = "" : Else : sPart2 = Right(sTemp, Len(sTemp) - (iTo + Len(sTo) - 1)) : End If
                        Else 'Excl
                            sPart2 = Right(sTemp, Len(sTemp) - (iTo - 1))
                        End If
                    Else
                        Ende = True
                    End If
                Else
                    Ende = True
                End If
                If bFound = True Then : SInp = sPart1 & sPart2 : End If
                iFrom = InStr(1, SInp, sFrom, 1)
                System.Windows.Forms.Application.DoEvents()
            End While
        End If
        Return SInp
    End Function

    Public Function isHex(ByVal sChar As String) As Boolean
        Dim bResult As Boolean = True
        Dim sChr As String = ""
        If sChar.Length = 0 Then : Return False : Exit Function : End If
        For x = 0 To sChar.Length - 1
            sChr = sChar.ToUpper.Substring(x, 1)
            If (Asc(sChr) < 48 Or Asc(sChr) > 57) And (Asc(sChr) < 65 Or Asc(sChr) > 70) Then
                bResult = False
            End If
        Next
        Return bResult
    End Function
    Public Function StringToHex(ByVal sStr As String, Optional ByVal sep As String = "") 'as String
        'sStr as String
        Dim a As Integer
        Dim sResult As String
        sResult = ""
        For a = 1 To Len(sStr)
            sResult &= Microsoft.VisualBasic.Right("0" & CStr(Hex(Asc(Mid(sStr, a, 1)))), 2)
            If a < Len(sStr) Then : sResult &= sep : End If
        Next
        Return CStr(sResult)
    End Function

    Public Function Int2Bin(ByVal IntegerNumber As Integer) As String
        Dim IntNum As Integer, TempValue As Integer, BinValue As String = ""

        IntNum = IntegerNumber
        Do
            'Use the Mod operator to get the current binary digit from the
            'Integer number
            TempValue = IntNum Mod 2
            BinValue = CStr(TempValue) & BinValue

            'Divide the current number by 2 and get the integer result
            IntNum = IntNum \ 2
        Loop Until IntNum = 0

        Return BinValue

    End Function
    '-----------------------------------------------------------------------      
    Public Function Bin2Int(ByVal BinaryNumber As String) As Integer
        Dim Length As Integer, x As Integer, TempValue As Integer
        'Get the length of the binary string
        Length = CStr(BinaryNumber).Length

        'Convert each binary digit to its corresponding integer value
        'and add the value to the previous sum
        'The string is parsed from the right (LSB - Least Significant Bit)
        'to the left (MSB - Most Significant Bit)
        For x = 1 To Length
            TempValue = TempValue + CInt(Mid(BinaryNumber, Length - x + 1, 1)) * 2 ^ (x - 1)
        Next

        Return TempValue

    End Function

    Public Function Replace2ColorsInImage(ByVal Img As System.Drawing.Bitmap, ByVal SrcColor1 As System.Drawing.Color, ByVal NewColor1 As System.Drawing.Color, ByVal SrcColor2 As System.Drawing.Color, ByVal NewColor2 As System.Drawing.Color) As System.Drawing.Bitmap
        Dim c As System.Drawing.Color
        Dim x, y As Int32
        Dim NewPic As System.Drawing.Bitmap = New System.Drawing.Bitmap(Img.Width, Img.Height)
        NewPic.MakeTransparent(System.Drawing.Color.FromArgb(128, 0, 128, 255))
        'e.Graphics.DrawImage(bmp, 10, 30)
        For x = 0 To Img.Width - 1
            For y = 0 To Img.Height - 1
                c = Img.GetPixel(x, y)
                If c.Equals(SrcColor1) Then
                    c = NewColor1
                    NewPic.SetPixel(x, y, c)
                ElseIf c.Equals(SrcColor2) Then
                    c = NewColor2
                    NewPic.SetPixel(x, y, c)
                Else
                    NewPic.SetPixel(x, y, c)
                End If
            Next
        Next
        Return NewPic
    End Function
    Public Function ReplaceColorInImage(ByVal Img As System.Drawing.Bitmap, ByVal SrcColor As System.Drawing.Color, ByVal NewColor As System.Drawing.Color) As System.Drawing.Bitmap
        Dim c As System.Drawing.Color
        Dim x, y As Int32
        Dim NewPic As System.Drawing.Bitmap = New System.Drawing.Bitmap(Img.Width, Img.Height)

        'e.Graphics.DrawImage(bmp, 10, 30)
        For x = 0 To Img.Width - 1
            For y = 0 To Img.Height - 1
                c = Img.GetPixel(x, y)
                If c.Equals(SrcColor) Then
                    c = NewColor
                    NewPic.SetPixel(x, y, c)
                Else
                    NewPic.SetPixel(x, y, c)
                End If
            Next
        Next
        Return NewPic
    End Function
    Public Function switchColorInImage(ByVal img As System.Drawing.Bitmap, ByVal col1 As System.Drawing.Color, ByVal col2 As System.Drawing.Color) As System.Drawing.Bitmap
        Dim c As System.Drawing.Color
        Dim x, y As Int32
        Dim NewPic As System.Drawing.Bitmap = img

        'e.Graphics.DrawImage(bmp, 10, 30)
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                c = img.GetPixel(x, y)
                If c.Equals(col1) Then
                    c = col2
                    NewPic.SetPixel(x, y, c)
                ElseIf c.Equals(col2) Then
                    c = col1
                    NewPic.SetPixel(x, y, c)
                End If
            Next
        Next
        Return NewPic
    End Function
    Public Function ByteArrayToImage(ByVal b As Byte()) As System.Drawing.Image
        Dim stream As MemoryStream = Nothing
        Dim img As System.Drawing.Image = Nothing

        'Read the byte array into a MemoryStream  
        stream = New MemoryStream(b, 0, b.Length)
        'Create the new Image from the stream  
        img = System.Drawing.Image.FromStream(stream)
        Return img
    End Function

    Public Function ImageToByteArray(ByVal i As System.Drawing.Image, Optional ByVal f As System.Drawing.Imaging.ImageFormat = Nothing) As Byte()
        Dim imageBytes As Byte()
        If f Is Nothing Then
            f = System.Drawing.Imaging.ImageFormat.MemoryBmp
        End If
        Using ms As MemoryStream = New MemoryStream()
            ' Convert Image to byte[]
            i.Save(ms, f)
            imageBytes = ms.ToArray()
        End Using
        Return imageBytes
    End Function
    Public Sub ByteArrayToImageFile(ByVal b As Byte(), ByVal fn As String, Optional ByVal f As System.Drawing.Imaging.ImageFormat = Nothing)
        If f Is Nothing Then
            f = System.Drawing.Imaging.ImageFormat.Bmp
        End If
        Dim img As System.Drawing.Image
        Dim stream As MemoryStream = Nothing
        'Read the byte array into a MemoryStream  
        stream = New MemoryStream(b, 0, b.Length)
        img = System.Drawing.Image.FromStream(stream)
        img.Save(fn, f)

    End Sub
    Public Function ImageFileToByteArray(ByVal i As String) As Byte()
        Dim imgData() As Byte
        'ImageToByteArray(New Image, 
        If i Is Nothing OrElse IsDBNull(i) Then
            Return Nothing
            Exit Function
        End If
        'FileInfo instance so we can get all the  
        'information we need regarding the image  
        Dim fInfo As New FileInfo(i)

        'Get the length of the image for the byte array  
        'we create later in the function          
        Dim len As Long = fInfo.Length

        'Open a FileStream the length of the image being inserted  
        Using stream As New FileStream(i.Trim(), FileMode.Open)
            'Create a new byte array the size of the length of the file  
            imgData = New Byte(System.Convert.ToInt32(len - 1)) {}

            'Read the byte array into the buffer  
            stream.Read(imgData, 0, len)
        End Using
        Return imgData
    End Function

    Public Function HexStringToString(ByVal sHexStr As String) As String
        Dim a As Integer, sResult As String = ""
        If sHexStr.Length Mod 2 <> 0 Then
            Return Nothing
            Exit Function
        End If
        If sHexStr.Length > 2 Then
            For a = 1 To sHexStr.Length - 1 Step 2
                sResult &= ChrW(HexToDec(Mid(sHexStr, a, 2)))
            Next
        Else
            sResult &= ChrW(HexToDec(sHexStr))
        End If
        Return sResult
    End Function

    Public Function ScreenToBitmap(Optional ByVal bSmallFnt As Boolean = False, Optional ByVal nocolors As Boolean = False) As System.Drawing.Bitmap
        Dim FntCurrChar As Byte = 0, iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
        Dim CurrBt As Byte = 0
        Dim CharXPos As Integer = 0, CharYPos As Integer = 0
        Dim UseForeColID As Integer = 7, UseBackColID As Integer = 0
        Dim FWidth As Integer, FHeight As Integer
        Dim fnt As Ansifntdef
        If bSmallFnt = True Then
            FWidth = 8 : FHeight = 8 : fnt = DosFnt80x50
        Else
            FWidth = 8 : FHeight = 16 : fnt = DosFnt80x25
        End If
        Dim ImgWidth As Integer = maxX * FWidth
        Dim ImgHeight As Integer = LinesUsed * FHeight
        Dim pf As System.Windows.Media.PixelFormat = System.Windows.Media.PixelFormats.Indexed8
        Dim width As Integer = ImgWidth, height As Integer = ImgHeight
        Dim stride As Integer = width 'CType((width * pf.BitsPerPixel + 7) / 8, Integer)
        Dim pixels(height * stride) As Byte
        Dim palnew = New System.Windows.Media.Imaging.BitmapPalette(AnsiColorsARGBM)
        Dim iCnt As Integer = 0, ByteEntry As Byte = 0
        Dim bSet As Boolean = False, colval As Byte = 0
        For PosY = minY To LinesUsed
            For y As Integer = 0 To FHeight - 1
                For PosX = minX To maxX
                    FntCurrChar = Screen(PosX, PosY).DosChar
                    CurrBt = CType(HexToDec(Strings.Mid(fnt.FntBits(FntCurrChar), (y * 2) + 1, 2)), Byte)
                    UseForeColID = Screen(PosX, PosY).ForeColor + Screen(PosX, PosY).Bold
                    UseBackColID = Screen(PosX, PosY).BackColor
                    For x As Integer = 0 To FWidth - 1
                        If ExamineBit(CurrBt, x + 1) Then
                            If nocolors = True Then : colval = 7 : Else : colval = UseForeColID : End If
                        Else
                            If nocolors = True Then : colval = 0 : Else : colval = UseBackColID : End If
                        End If
                        pixels(iCnt) = colval : iCnt += 1
                    Next
                Next
            Next
        Next
        Try
            Dim myBMSource As BitmapSource = Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, pf, palnew, pixels, stride)
            Dim enc As System.Windows.Media.Imaging.BmpBitmapEncoder = New System.Windows.Media.Imaging.BmpBitmapEncoder
            enc.Frames.Add(Windows.Media.Imaging.BitmapFrame.Create(myBMSource))
            Dim mem As New MemoryStream
            enc.Save(mem)
            Return System.Drawing.Bitmap.FromStream(mem)

        Catch ex As Exception
            Return New System.Drawing.Bitmap(width:=100, height:=100, stride:=100, Format:=System.Drawing.Imaging.PixelFormat.Format8bppIndexed, scan0:=0)
        End Try

    End Function
    Public Function ByteArrayToBitmap(ByVal Bte As Byte(), ByVal TextWidth As Integer, ByVal NumLines As Integer, Optional ByVal bSmallFnt As Boolean = False) As System.Drawing.Bitmap
        Dim FntCurrChar As Byte = 0, iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
        Dim CurrBt As Byte = 0
        Dim CharXPos As Integer = 0, CharYPos As Integer = 0
        Dim UseForeColID As Integer = 7, UseBackColID As Integer = 0
        Dim FWidth As Integer, FHeight As Integer
        Dim fnt As Ansifntdef
        If bSmallFnt = True Then
            FWidth = 8 : FHeight = 8 : fnt = DosFnt80x50
        Else
            FWidth = 8 : FHeight = 16 : fnt = DosFnt80x25
        End If
        Dim ImgWidth As Integer = TextWidth * FWidth
        Dim ImgHeight As Integer = NumLines * FHeight
        Dim pf As System.Windows.Media.PixelFormat = System.Windows.Media.PixelFormats.Indexed8
        Dim width As Integer = ImgWidth, height As Integer = ImgHeight
        Dim stride As Integer = width 'CType((width * pf.BitsPerPixel + 7) / 8, Integer)
        Dim pixels(height * stride) As Byte
        Dim palnew = New System.Windows.Media.Imaging.BitmapPalette(AnsiColorsARGBM)
        Dim iCnt As Integer = 0, ByteEntry As Byte = 0
        Dim bSet As Boolean = False, colval As Byte = 0
        For PosY = 1 To NumLines
            For y As Integer = 0 To FHeight - 1
                For PosX = 1 To TextWidth
                    FntCurrChar = Bte(((PosY - 1) * TextWidth) + PosX - 1)
                    CurrBt = CType(HexToDec(Strings.Mid(fnt.FntBits(FntCurrChar), (y * 2) + 1, 2)), Byte)
                    For x As Integer = 0 To FWidth - 1
                        If ExamineBit(CurrBt, x + 1) Then
                            colval = UseForeColID
                        Else
                            colval = UseBackColID
                        End If
                        pixels(iCnt) = colval : iCnt += 1
                    Next
                Next
            Next
        Next
        Try
            Dim myBMSource As BitmapSource = Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, pf, palnew, pixels, stride)
            Dim enc As System.Windows.Media.Imaging.BmpBitmapEncoder = New System.Windows.Media.Imaging.BmpBitmapEncoder
            enc.Frames.Add(Windows.Media.Imaging.BitmapFrame.Create(myBMSource))
            Dim mem As New MemoryStream
            enc.Save(mem)
            Return System.Drawing.Bitmap.FromStream(mem)

        Catch ex As Exception
            Return New System.Drawing.Bitmap(width:=100, height:=100, stride:=100, Format:=System.Drawing.Imaging.PixelFormat.Format8bppIndexed, scan0:=0)
        End Try

    End Function

    Public Function CreateVideoFrame(Optional ByVal bSmallFnt As Boolean = False, _
                                Optional ByVal nocolors As Boolean = False, _
                                Optional ByVal YIndex As Integer = 0) As System.Drawing.Bitmap
        Dim FntCurrChar As Byte = 0, iMaxWidth As Integer = 0, iMaxHeight As Integer = 0
        Dim CurrBt As Byte = 0
        Dim UseForeColIDVid As Integer = 7, UseBackColIDVid As Integer = 0
        Dim FWidth As Integer, FHeight As Integer
        Dim fnt As Ansifntdef
        If bSmallFnt = True Then
            FWidth = 8 : FHeight = 8 : fnt = DosFnt80x50
        Else
            FWidth = 8 : FHeight = 16 : fnt = DosFnt80x25
        End If
        Dim ImgWidth As Integer = 80 * FWidth
        Dim ImgHeight As Integer = 25 * FHeight
        Dim pf As System.Windows.Media.PixelFormat = System.Windows.Media.PixelFormats.Indexed8
        Dim width As Integer = ImgWidth, height As Integer = ImgHeight
        Dim stride As Integer = width 'CType((width * pf.BitsPerPixel + 7) / 8, Integer)
        Dim pixels(height * stride) As Byte
        Dim palnew = New System.Windows.Media.Imaging.BitmapPalette(AnsiColorsARGBM)
        Dim iCntVid As Integer = 0, ByteEntry As Byte = 0
        Dim bSet As Boolean = False, colvalVid As Byte = 0
        Dim YEnd As Integer
        Dim XPosV As Integer = 1, YPosV As Integer = 1

        If YIndex + 24 > LinesUsed Then
            YEnd = LinesUsed
        Else
            YEnd = YIndex + 24
        End If
        'YIndex
        For YPosV = YIndex + 1 To YEnd
            For yVid As Integer = 0 To FHeight - 1
                For XPosV = 1 To 80
                    FntCurrChar = Screen(XPosV, YPosV).DosChar
                    CurrBt = CType(HexToDec(Strings.Mid(fnt.FntBits(FntCurrChar), (yVid * 2) + 1, 2)), Byte)
                    UseForeColIDVid = Screen(XPosV, YPosV).ForeColor + Screen(XPosV, YPosV).Bold
                    UseBackColIDVid = Screen(XPosV, YPosV).BackColor
                    For xVid As Integer = 0 To FWidth - 1
                        If ExamineBit(CurrBt, xVid + 1) Then
                            If nocolors = True Then : colvalVid = 7 : Else : colvalVid = UseForeColIDVid : End If
                        Else
                            If nocolors = True Then : colvalVid = 0 : Else : colvalVid = UseBackColIDVid : End If
                        End If
                        pixels(iCntVid) = colvalVid : iCntVid += 1
                    Next
                Next
            Next
        Next
        Try
            Dim myBMSource As BitmapSource = Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, pf, palnew, pixels, stride)
            Dim enc As System.Windows.Media.Imaging.BmpBitmapEncoder = New System.Windows.Media.Imaging.BmpBitmapEncoder
            enc.Frames.Add(Windows.Media.Imaging.BitmapFrame.Create(myBMSource))
            Dim mem As New MemoryStream
            enc.Save(mem)
            Return System.Drawing.Bitmap.FromStream(mem)
        Catch ex As Exception
            Return New System.Drawing.Bitmap(width:=100, height:=100, stride:=100, Format:=System.Drawing.Imaging.PixelFormat.Format8bppIndexed, scan0:=0)


        End Try
 

    End Function
    Public Function BitmapToIndexed(ByVal bm As System.Drawing.Bitmap, ByVal pal As System.Drawing.Imaging.ColorPalette) As System.Drawing.Bitmap
        Dim newbm As System.Drawing.Bitmap = Nothing
        Try
            Dim pf As System.Windows.Media.PixelFormat = System.Windows.Media.PixelFormats.Indexed8
            Dim width As Integer = bm.Width
            Dim height As Integer = bm.Height
            Dim stride As Integer = (width * pf.BitsPerPixel) / 8
            '             height * (width * pf.BitsPerPixel / 8)

            Dim pixels(height * stride) As Byte
            Dim c As System.Drawing.Color
            Dim clist As New List(Of System.Windows.Media.Color)
            For id As Integer = 0 To pal.Entries.Count - 1
                clist.Add(System.Windows.Media.Color.FromArgb(pal.Entries(id).A, pal.Entries(id).R, pal.Entries(id).G, pal.Entries(id).B))
            Next
            Dim palnew = New System.Windows.Media.Imaging.BitmapPalette(clist)
            Dim palentry As Byte
            Dim iCnt As Integer = 0
            For x As Integer = 0 To width - 1
                For y As Integer = 0 To height - 1
                    c = bm.GetPixel(x, y)
                    palentry = FindPalettenEntry(c, pal)
                    pixels(iCnt) = palentry
                    iCnt += 1
                Next
            Next
            Dim myBMSource As BitmapSource = Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, pf, palnew, pixels, stride)
            Dim enc As System.Windows.Media.Imaging.BmpBitmapEncoder = New System.Windows.Media.Imaging.BmpBitmapEncoder
            enc.Frames.Add(Windows.Media.Imaging.BitmapFrame.Create(myBMSource))
            Dim mem As New MemoryStream
            enc.Save(mem)
            newbm = System.Drawing.Bitmap.FromStream(mem)

        Catch ex As Exception
        End Try

        Return newbm
    End Function
    Public Function FindPalettenEntry(ByVal col As System.Drawing.Color, ByVal cp As System.Drawing.Imaging.ColorPalette, Optional ByVal bIgnoreAlpha As Boolean = True) As Byte
        Dim iResult As Byte = 0
        Dim bFound As Boolean = False
        Dim nearc As System.Drawing.Color
        For a = 0 To cp.Entries.Count - 1
            If cp.Entries(a).R = col.R And cp.Entries(a).G = col.G And cp.Entries(a).B = col.B And _
               (bIgnoreAlpha = True Or (bIgnoreAlpha = False And cp.Entries(a).A = col.A)) Then
                bFound = True
                iResult = a
                Exit For
            End If
        Next
        If bFound = False Then
            nearc = GetClosestExistingRGBColor(col, cp)
            Dim newres As Integer = Array.FindIndex(cp.Entries, Function(x) nearc.Equals(x))
            If newres <> -1 Then
                iResult = CType(newres, Byte)
            End If
        End If
        Return iResult
    End Function

    Public Function TestColorCloser(ByVal Color1 As System.Drawing.Color, ByVal CurrNearCol As System.Drawing.Color, ByVal CompColor As System.Drawing.Color) As Boolean
        Dim MinDist As Double, DistCI As Double

        MinDist = ((CurrNearCol.R - CompColor.R) ^ 2 + (CurrNearCol.G - CompColor.G) ^ 2 + (CurrNearCol.B - CompColor.B) ^ 2)
        DistCI = ((Color1.R - CompColor.R) ^ 2 + (Color1.G - CompColor.G) ^ 2 + (Color1.B - CompColor.B) ^ 2)

        If DistCI <= MinDist Then
            ' distance is less than current minimum. set save variables.
            TestColorCloser = True
        Else
            TestColorCloser = False
        End If

    End Function

    Public Function GetClosestExistingRGBColor(ByVal ColorI As System.Drawing.Color, ByVal pal As System.Drawing.Imaging.ColorPalette) As System.Drawing.Color
        Dim a As Integer
        Dim CloseCol As System.Drawing.Color = System.Drawing.Color.Black
        For a = 0 To pal.Entries.Count - 1
            If a = 0 Then
                CloseCol = CType(pal.Entries(a), System.Drawing.Color)
            Else
                If TestColorCloser(CType(pal.Entries(a), System.Drawing.Color), CloseCol, ColorI) = True Then
                    CloseCol = CType(pal.Entries(a), System.Drawing.Color)
                End If
            End If
        Next
        GetClosestExistingRGBColor = CloseCol
    End Function
    Public Function larger(ByVal val1 As Integer, ByVal val2 As Integer) As Integer
        Return IIf(val1 > val2, val1, val2)
    End Function
    Public Function smaller(ByVal val1 As Integer, ByVal val2 As Integer) As Integer
        Return IIf(val1 < val2, val1, val2)
    End Function

End Module
