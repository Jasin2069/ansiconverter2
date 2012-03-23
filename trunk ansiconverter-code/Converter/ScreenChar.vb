Public Class ScreenChar
    Public ForeColor As Integer
    Public BackColor As Integer
    Public Blink As Boolean
    Public Bold As Integer
    Public Reversed As Boolean
    Public Chr As String
    Public DosChar As Byte
    Public Sub New()
        Me.Init(1)
    End Sub
    Public Sub New(ByVal xPos As Integer)
        Me.Init(xPos)
    End Sub
    Public Sub Init(ByVal xPos As Integer)
        DosChar = 32
        ForeColor = 7
        BackColor = 0
        Blink = False
        Bold = 0
        Reversed = False
        Chr = Strings.Chr(32)
        If bHTMLEncode = True Then
            Chr = "&nbsp;"
        End If
        If xPos = 80 Then
            Chr = Strings.Chr(255)
        End If


    End Sub

End Class
