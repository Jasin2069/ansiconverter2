Public Class CodePage
    Private myCode As String
    Private myISO As String
    Private myName As String

    Public Sub New(ByVal Name As String, ByVal Code As String, ByVal ISO As String)
        Me.myCode = Code
        Me.myName = Name
        Me.myISO = ISO
    End Sub 'New

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
