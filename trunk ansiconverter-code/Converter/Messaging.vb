Namespace Messaging
    Module Messaging
        Public Structure fmts
            Public elem As String
            Public fnt As fnts
            Public start As Stack(Of Integer)
            Sub New(ByVal e As String, ByVal f As fnts)
                elem = e
                fnt = f
                start = New Stack(Of Integer)
            End Sub
        End Structure
        Public Enum fnts
            bold = 1
            italic = 2
            underline = 3
            err = 4
        End Enum
        Public Structure sel
            Public format As fnts
            Public fromval As Integer
            Public toval As Integer
            Sub New(ByVal fn As fnts, ByVal f As Integer, ByVal t As Integer)
                format = fn
                fromval = f
                toval = t
            End Sub
        End Structure

    End Module
End Namespace
