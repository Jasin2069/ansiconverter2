Public Structure NL
    Public Code As Integer
    Public CodeHex As String
    Public CodeBin As String
    Public CodeOct As String
    Public Name As String
    Public Aliases As List(Of String) '=
    Public Similar As List(Of String) 'x
    Public Notes As List(Of String)  '*
    Public Sub New(ByVal C As Integer, ByVal Ch As String, ByVal cO As String, ByVal cB As String, ByVal N As String)
        Code = C
        CodeHex = Ch
        Name = N
        CodeBin = cB
        CodeOct = cO
        Aliases = New List(Of String)
        Similar = New List(Of String)
        Notes = New List(Of String)
    End Sub
End Structure