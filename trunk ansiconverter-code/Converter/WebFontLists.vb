Namespace ConverterSupport
    '  Public Structure WebFont
    ' Public Name As String
    ' Public StaticEXTRACSSDIV As String
    ' Public StaticEXTRACSSPRE As String
    ' Public StaticEXTRACSSSPAN As String
    ' Public AnimEXTRACSSDIV As String
    ' Public AnimEXTRACSSPRE As String
    ' Public AnimEXTRACSSSPAN As String
    ' Public Sub New(ByVal n As String, ByVal sDIV As String, ByVal sPRE As String, ByVal sSPAN As String, ByVal aDIV As String, ByVal aPRE As String, ByVal aSPAN As String)
    '    Name = n
    '    StaticEXTRACSSDIV = sDIV
    '    StaticEXTRACSSPRE = sPRE
    '    StaticEXTRACSSSPAN = sSPAN
    '    AnimEXTRACSSDIV = aDIV
    '    AnimEXTRACSSPRE = aPRE
    '    AnimEXTRACSSSPAN = aSPAN
    'End Sub
    ' End Structure

    Public Class WebFontDef
        Private sName As String
        Private sStaticEXTRACSSDIV As String
        Private sStaticEXTRACSSPRE As String
        Private sStaticEXTRACSSSPAN As String
        Private sAnimEXTRACSSDIV As String
        Private sAnimEXTRACSSPRE As String
        Private sAnimEXTRACSSSPAN As String

        Public Sub New(ByVal n As String, ByVal sDIV As String, ByVal sPRE As String, ByVal sSPAN As String, ByVal aDIV As String, ByVal aPRE As String, ByVal aSPAN As String)
            Me.sName = n
            Me.sStaticEXTRACSSDIV = sDIV
            Me.sStaticEXTRACSSPRE = sPRE
            Me.sStaticEXTRACSSSPAN = sSPAN
            Me.sAnimEXTRACSSDIV = aDIV
            Me.sAnimEXTRACSSPRE = aPRE
            Me.sAnimEXTRACSSSPAN = aSPAN
        End Sub 'New

        Public ReadOnly Property Name() As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property StaticEXTRACSSDIV() As String
            Get
                Return sStaticEXTRACSSDIV
            End Get
        End Property
        Public ReadOnly Property StaticEXTRACSSPRE() As String
            Get
                Return sStaticEXTRACSSPRE
            End Get
        End Property
        Public ReadOnly Property StaticEXTRACSSSPAN() As String
            Get
                Return sStaticEXTRACSSSPAN
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSDIV() As String
            Get
                Return sAnimEXTRACSSDIV
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSPRE() As String
            Get
                Return sAnimEXTRACSSPRE
            End Get
        End Property
        Public ReadOnly Property AnimEXTRACSSSPAN() As String
            Get
                Return sAnimEXTRACSSSPAN
            End Get
        End Property
    End Class 'WebFontDef
End Namespace
