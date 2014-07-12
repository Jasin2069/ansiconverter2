Public Module Convert
    Public Function ReadByteArray(ByRef Arr() As Byte, ByRef iLoop As Integer, ByVal iLen As Integer, ByVal DtaType As String) As String
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


    Public Function UniHex(ByVal iNum As Integer) As String
        Return Right("0000" & Decimal2BaseN(iNum, 16), 4)
    End Function


    Public Function Decimal2BaseN(ByVal value As Integer, ByVal outBase As Integer) As String
        Dim quotient As Integer
        Dim reminder As Object
        Dim denominator As Integer
        Dim result As String = ""
        denominator = outBase
        quotient = value
        Do
            reminder = quotient Mod denominator
            quotient = Math.Floor(quotient / denominator)
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

    Public Function ByteArrayToHexString(ByVal ba As Byte()) As String
        ' concat the bytes into one long string 
        Return ba.Aggregate(New System.Text.StringBuilder(32), Function(sb, b) sb.Append(b.ToString("X2"))).ToString()
    End Function
    Public Function BteArr2Str(ByVal ba As Byte()) As String
        ' concat the bytes into one long string 
        Return ba.Aggregate(New System.Text.StringBuilder(32), Function(sb, b) sb.Append(Chr(b))).ToString()
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

    Public Function ByteArrayToString(ByVal ByteArray() As Byte) As String
        Dim sResult As String = ""
        For a As Integer = 0 To ByteArray.Length - 1
            If CType(ByteArray(a), Byte) <> 0 Then
                sResult &= Strings.Chr(CType(ByteArray(a), Byte))
            End If
        Next
        Return sResult
    End Function
    Public Function StringToByteArray(ByVal iStr As String) As Byte()
        Dim bte() As Byte = New Byte() {0}
        If iStr.Length > 0 Then
            ReDim bte(iStr.Length - 1)
            For a As Integer = 1 To iStr.Length
                bte(a - 1) = Strings.Asc(Strings.Mid(iStr, a, 1))
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
                dByte((a - 1) / 2) = CByte(HexToDec(Strings.Mid(sHexStr, a, 2)))
            Next
        Else
            dByte(0) = CByte(HexToDec(sHexStr))
        End If
        Return dByte
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
    Public Function StringToHex(ByVal sStr As String, Optional ByVal sep As String = "") 'as String
        'sStr as String
        Dim a As Integer
        Dim sResult As String
        sResult = ""
        For a = 1 To Len(sStr)
            sResult &= Strings.Right("0" & CStr(Hex(Strings.Asc(Strings.Mid(sStr, a, 1)))), 2)
            If a < Strings.Len(sStr) Then : sResult &= sep : End If
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
            TempValue = TempValue + CInt(Strings.Mid(BinaryNumber, Length - x + 1, 1)) * 2 ^ (x - 1)
        Next

        Return TempValue

    End Function

    Public Function hex2utf8(ByVal hexstr As String) As String
        Dim binv As String = Int2Bin(HexToDec(hexstr))
        Dim numbyte As Integer = Math.Ceiling(binv.Length / 6)
        Dim tmpbin As String = ""
        If binv.Length > 21 Then
            Return ""
        ElseIf numbyte = 1 Then
            Return Hex(Bin2Int("0" & binv))
        Else
            Dim part0 As String = ""
            Select Case numbyte
                Case 2
                    part0 = "110"
                Case 3
                    part0 = "1110"
                Case 4
                    part0 = "11110"
            End Select
            For a As Integer = 1 To numbyte - 1
                tmpbin = "10" & Strings.Right(binv, 6) & tmpbin
                binv = Strings.Left(binv, binv.Length - 6)
            Next
            Dim part1 As String = Strings.Right("00000" & binv, (7 - numbyte))
            Return Hex(Bin2Int(part0 & part1 & tmpbin))
        End If
    End Function

End Module
