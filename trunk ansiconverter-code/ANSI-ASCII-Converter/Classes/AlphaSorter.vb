Imports System
Imports System.Collections
Imports System.Text

Namespace AlphanumComparator

    Public Class AlphanumComparator
        Implements IComparer

        Private Enum ChunkType
            Alphanumeric
            Numeric
        End Enum

        Private Function InChunk(ByVal ch As Char, ByVal otherCh As Char) As Boolean
            Dim type As ChunkType = ChunkType.Alphanumeric
            If Char.IsDigit(otherCh) Then
                type = ChunkType.Numeric
            End If
            If (((type = ChunkType.Alphanumeric) _
                        AndAlso Char.IsDigit(ch)) _
                        OrElse ((type = ChunkType.Numeric) _
                        AndAlso Not Char.IsDigit(ch))) Then
                Return False
            End If
            Return True
        End Function

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim s1 As String = CType(x, String)
            Dim s2 As String = CType(y, String)
            If ((s1 Is Nothing) _
                        OrElse (s2 Is Nothing)) Then
                Return 0
            End If
            Dim thisNumericChunk As Integer = 0
            Dim thisMarker As Integer = 0
            Dim thatNumericChunk As Integer = 0
            Dim thatMarker As Integer = 0

            While ((thisMarker < s1.Length) _
                        OrElse (thatMarker < s2.Length))
                If (thisMarker >= s1.Length) Then
                    Return -1
                ElseIf (thatMarker >= s2.Length) Then
                    Return 1
                End If
                Dim thisCh As Char = s1(thisMarker)
                Dim thatCh As Char = s2(thatMarker)
                Dim thisChunk As StringBuilder = New StringBuilder
                Dim thatChunk As StringBuilder = New StringBuilder

                While ((thisMarker < s1.Length) _
                            AndAlso ((thisChunk.Length = 0) _
                            OrElse InChunk(thisCh, thisChunk(0))))
                    thisChunk.Append(thisCh)
                    thisMarker = (thisMarker + 1)
                    If (thisMarker < s1.Length) Then
                        thisCh = s1(thisMarker)
                    End If

                End While

                While ((thatMarker < s2.Length) _
                            AndAlso ((thatChunk.Length = 0) _
                            OrElse InChunk(thatCh, thatChunk(0))))
                    thatChunk.Append(thatCh)
                    thatMarker = (thatMarker + 1)
                    If (thatMarker < s2.Length) Then
                        thatCh = s2(thatMarker)
                    End If

                End While
                Dim result As Integer = 0
                ' If both chunks contain numeric characters, sort them numerically
                If (Char.IsDigit(thisChunk(0)) AndAlso Char.IsDigit(thatChunk(0))) Then
                    thisNumericChunk = System.Convert.ToInt32(thisChunk.ToString)
                    thatNumericChunk = System.Convert.ToInt32(thatChunk.ToString)
                    If (thisNumericChunk < thatNumericChunk) Then
                        result = -1
                    End If
                    If (thisNumericChunk > thatNumericChunk) Then
                        result = 1
                    End If
                Else
                    result = thisChunk.ToString.CompareTo(thatChunk.ToString)
                End If
                If (result <> 0) Then
                    Return result
                End If

            End While
            Return 0
        End Function
    End Class
End Namespace
