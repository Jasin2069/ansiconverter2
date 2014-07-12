Namespace ConverterSupport
    ''' <summary>
    ''' Code Page Class used for <see cref="CPS"/> Class (also see <see cref="AnsiCPMaps.AnsiCPMaps.CodePages"/>)
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CodePage
        Private myCode As String
        Private myISO As String
        Private myName As String

        ''' <summary>
        ''' Constructor of <see cref="CodePage"/> Class
        ''' </summary>
        ''' <param name="Name">Name of Code Page</param>
        ''' <param name="Code">Short Code/Abbreviation of Code Page</param>
        ''' <param name="ISO">ISO Name of Code Page</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Name As String, ByVal Code As String, ByVal ISO As String)
            Me.myCode = Code
            Me.myName = Name
            Me.myISO = ISO
        End Sub 'New

        ''' <summary>
        ''' Returns Read-Only Property 'Code', Short Code/Abbreviation of Code Page 
        ''' </summary>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Code() As String
            Get
                Return myCode
            End Get
        End Property
        ''' <summary>
        ''' Returns Name of Code Page
        ''' </summary>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Name() As String
            Get
                Return myName
            End Get
        End Property
        ''' <summary>
        ''' Returns ISO-Code of Code Page
        ''' </summary>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ISO() As String
            Get
                Return myISO
            End Get
        End Property

    End Class 'CodePage
End Namespace