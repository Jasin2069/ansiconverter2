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
        IFrom = Converter.HexToDec(sFrom)
        sTo = T
        iTo = Converter.HexToDec(sTo)
        myKey = sFrom & "-" & sTo
        MyDisplay = myKey & " : " & sName & " (" & CStr(iTo - IFrom + 1) & " characters)"
    End Sub

End Class
