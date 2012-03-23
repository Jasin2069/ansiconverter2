Imports System
Imports System.Reflection

Public Module Reflect


    Public Sub GetPluginFromAssembly()
        Dim asm As System.Reflection.Assembly
        Dim t As Type()
        Dim ty As Type
        Dim m As MethodInfo()
        Dim mm As MethodInfo
        Dim p As ParameterInfo()
        Dim pi As ParameterInfo

        Dim sTmpFile As String = IO.Path.GetTempFileName & ".dll"
        Call Converter.WriteFile(sTmpFile, My.Resources.BassMOD_Net, True, 0, True, True)
        asm = System.Reflection.Assembly.LoadFrom(sTmpFile)

        ReflectionMain(asm)
        'Console.WriteLine("..............")
        'If p.ToString = pi.ToString Then

        t = asm.GetTypes()
        For a As Integer = 0 To t.Count - 1
            Dim tx As String = t(a).FullName
            Console.WriteLine("tx=" & tx)
            ty = asm.GetType(tx)
            m = ty.GetMethods()
            For b = 0 To m.Count - 1
                Dim mx As String = m(b).Name
                Console.WriteLine("   mx=" & mx)
                mm = ty.GetMethod(tx & "." & mx)
                If Not mm Is Nothing Then
                    p = mm.GetParameters()
                    For c = 0 To p.Count - 1
                        pi = p(c)
                        Console.WriteLine("        pi=" & pi.Name & ", typ: " & pi.GetType.ToString & ", default: " & pi.DefaultValue.ToString)
                    Next

                End If
                Dim o As Object
                o = Activator.CreateInstance(ty)
                '  Dim oo As Object() = {Int32.Parse(1), Int32.Parse(2)}
                '  Dim stmp = mm.Invoke(o, oo).ToString()

            Next
        Next
        'End If
    End Sub


    Private Function CreateClassFromString(Optional ByVal FullName As String = "", Optional ByVal clsNamespace As String = "", Optional ByVal clsName As String = "", Optional ByVal args() As [Object] = Nothing) As Object
        Dim MyAssembly As System.Reflection.Assembly
        Dim Item As Object = New Object
        MyAssembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim MyTypes(), MyType As Type
        ' Iterate through the program's classes.
        MyTypes = MyAssembly.GetTypes()
        For Each MyType In MyTypes
            If (StrComp(MyType.Namespace, clsNamespace, CompareMethod.Text) = 0 And StrComp(MyType.Name, clsName, CompareMethod.Text) = 0) Or (FullName <> "" And StrComp(MyType.FullName, FullName, CompareMethod.Text) = 0) Then
                If Not args Is Nothing Then
                    Item = MyType.InvokeMember(Nothing, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.CreateInstance, Nothing, Nothing, args)
                Else
                    Item = Activator.CreateInstance(Type.GetType(MyType.FullName))
                End If

                Return Item
            End If
        Next
        Return Item
    End Function
    Private Function GetTypeFromName(Optional ByVal FullName As String = "", Optional ByVal clsNamespace As String = "", Optional ByVal clsName As String = "") As Type
        Dim MyAssembly As System.Reflection.Assembly
        MyAssembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim MyTypes(), MyType As Type, Item As Type
        Item = Nothing
        ' Iterate through the program's classes.
        MyTypes = MyAssembly.GetTypes()
        For Each MyType In MyTypes
            If (StrComp(MyType.Namespace, clsNamespace, CompareMethod.Text) = 0 And StrComp(MyType.Name, clsName, CompareMethod.Text) = 0) Or (FullName <> "" And StrComp(MyType.FullName, FullName, CompareMethod.Text) = 0) Then
                Item = Type.GetType(MyType.FullName)
                Exit For
            End If
        Next
        Return Item
    End Function
    Private Sub SetPropertyFromPropertyName(ByVal PropertyName As String, ByVal PropertyValue As Object, Optional ByRef Obj As Object = Nothing, Optional ByVal FullClassName As String = "")
        Dim typeCode As TypeCode = Type.GetTypeCode(PropertyValue.GetType())
        If Obj Is Nothing Then
            Obj = CreateClassFromString(FullClassName)
        End If
        Dim t As Type

        t = Type.GetType(Obj.GetType.FullName)

        Select Case typeCode
            Case typeCode.Boolean
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CBool(PropertyValue)})
            Case typeCode.Byte
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CByte(PropertyValue)})
            Case typeCode.Char
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CChar(PropertyValue)})
            Case typeCode.DateTime
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CDate(PropertyValue)})
            Case typeCode.DBNull
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {DBNull.Value})
            Case typeCode.Decimal
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CDec(PropertyValue)})
            Case typeCode.Double
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CDbl(PropertyValue)})
            Case typeCode.Empty
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {Nothing})
            Case System.TypeCode.Int16
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
            Case System.TypeCode.Int32
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
            Case System.TypeCode.Int64
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
            Case System.TypeCode.Object
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {PropertyValue})
            Case System.TypeCode.SByte
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CByte(PropertyValue)})
            Case System.TypeCode.Single
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CSng(PropertyValue)})
            Case System.TypeCode.String
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CStr(PropertyValue)})
            Case System.TypeCode.UInt16
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
            Case System.TypeCode.UInt32
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
            Case System.TypeCode.UInt64
                t.InvokeMember(PropertyName, BindingFlags.SetProperty, Nothing, t, New Object() {CInt(PropertyValue)})
        End Select

    End Sub
    Private Function GetPropertyFromPropertyName(ByVal PropertyName As String, Optional ByRef Obj As Control = Nothing, Optional ByVal FullClassName As String = "") As Object
        Dim v As Object = Nothing
        If Obj Is Nothing Then
            Obj = CreateClassFromString(FullClassName)
        End If
        Dim t As Type
        t = Type.GetType(Obj.GetType.FullName)
        If PropertyName <> "Tag" Then


            'Console.WriteLine("{0}: {1}", p.Name, p.GetValue(obj, Nothing))
            Dim MyProperty As PropertyInfo
            MyProperty = Obj.GetType().GetProperty(PropertyName)
            If MyProperty.CanRead = True And MyProperty.CanWrite = True Then
                'If MyProperty.GetValue(Obj, Nothing).GetType().IsSerializable = True Then

                'End If
                v = MyProperty.GetValue(Obj, Nothing)
            End If



            '  Try
            ' v = t.InvokeMember(PropertyName, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.GetProperty, Nothing, t, Nothing)
            ' Catch ex As Exception
            'If Not ex.InnerException.GetType() Is GetType(ArgumentOutOfRangeException) And _
            'Not ex.InnerException.GetType() Is GetType(NullReferenceException) Then
            'Throw
            'End If
            'v = Nothing
            'End Try
            If Not v Is Nothing Then


                Dim typeCode As TypeCode = Type.GetTypeCode(v.GetType())
                Select Case typeCode
                    Case typeCode.Boolean
                        Return DirectCast(v, Boolean)
                    Case typeCode.Byte
                        Return DirectCast(v, Byte)
                    Case typeCode.Char
                        Return DirectCast(v, Char)
                    Case typeCode.DateTime
                        Return DirectCast(v, Date)
                    Case typeCode.DBNull
                        Return DBNull.Value
                    Case typeCode.Decimal
                        Return DirectCast(v, Decimal)
                    Case typeCode.Double
                        Return DirectCast(v, Double)
                    Case typeCode.Empty
                        Return Nothing
                    Case System.TypeCode.Int16
                        Return DirectCast(v, Int16)
                    Case System.TypeCode.Int32
                        Return DirectCast(v, Int32)
                    Case System.TypeCode.Int64
                        Return DirectCast(v, Int64)
                    Case System.TypeCode.Object
                        Return v
                    Case System.TypeCode.SByte
                        Return DirectCast(v, SByte)
                    Case System.TypeCode.Single
                        Return DirectCast(v, Single)
                    Case System.TypeCode.String
                        Return DirectCast(v, String)
                    Case System.TypeCode.UInt16
                        Return DirectCast(v, UInt16)
                    Case System.TypeCode.UInt32
                        Return DirectCast(v, UInt32)
                    Case System.TypeCode.UInt64
                        Return DirectCast(v, UInt64)
                    Case Else
                        Return v
                End Select
            Else
                Return v
            End If
        Else
            Return v
        End If
    End Function
    Private Sub CallSubMethodByName(ByVal obj As Object, ByVal Method As String, Optional ByVal args As Object() = Nothing)
        Dim t As Type = Type.GetType(obj.GetType.FullName)
        t.InvokeMember(Method, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, obj, args)
    End Sub
    Private Function CallFunctionMethodByName(ByVal obj As Object, ByVal Method As String, Optional ByVal args As Object() = Nothing) As Object
        Dim t As Type = Type.GetType(obj.GetType.FullName)
        Return t.InvokeMember(Method, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, obj, args)
    End Function

    Sub ReflectionMain(ByVal a As Assembly)
        ' This variable holds the amount of indenting that 
        ' should be used when displaying each line of information.
        Dim indent As Int32 = 0
        ' Display information about the EXE assembly.
        'Dim a As [Assembly] = System.Reflection.Assembly.GetExecutingAssembly()
        Display(indent, "Assembly identity={0}", a.FullName)
        Display(indent + 1, "Codebase={0}", a.CodeBase)

        ' Display the set of assemblies our assemblies reference.
        Dim an As AssemblyName
        Display(indent, "Referenced assemblies:")
        For Each an In a.GetReferencedAssemblies()
            Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", _
                an.Name, an.Version, an.CultureInfo.Name, BitConverter.ToString(an.GetPublicKeyToken))
        Next
        Display(indent, "")

        ' Display information about each assembly loading into this AppDomain.
        ' For Each a In AppDomain.CurrentDomain.GetAssemblies()
        Display(indent, "Assembly: {0}", a)

        ' Display information about each module of this assembly.
        Dim m As [Module]
        For Each m In a.GetModules(True)
            Display(indent + 1, "Module: {0}", m.Name)
        Next

        ' Display information about each type exported from this assembly.
        Dim t As Type
        indent += 1
        For Each t In a.GetExportedTypes()
            Display(0, "")
            Display(indent, "Type: {0}", t)

            ' For each type, show its members & their custom attributes.
            Dim mi As MemberInfo
            indent += 1
            For Each mi In t.GetMembers()
                Display(indent, "Member: {0}", mi.Name)
                DisplayAttributes(indent, mi)

                ' If the member is a method, display information about its parameters.
                Dim pi As ParameterInfo
                If mi.MemberType = MemberTypes.Method Then
                    For Each pi In CType(mi, MethodInfo).GetParameters()
                        Display(indent + 1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name)
                    Next
                End If

                ' If the member is a property, display information about the property's accessor methods.
                If mi.MemberType = MemberTypes.Property Then
                    Dim am As MethodInfo
                    For Each am In CType(mi, PropertyInfo).GetAccessors()
                        Display(indent + 1, "Accessor method: {0}", am)
                    Next
                End If
            Next
            indent -= 1
        Next
        indent -= 1
        '  Next
    End Sub

    ' Displays the custom attributes applied to the specified member.
    Sub DisplayAttributes(ByVal indent As Int32, ByVal mi As MemberInfo)
        ' Get the set of custom attributes; if none exist, just return.
        Dim attrs() As Object = mi.GetCustomAttributes(False)
        If attrs.Length = 0 Then Return

        ' Display the custom attributes applied to this member.
        Display(indent + 1, "Attributes:")
        Dim o As Object
        For Each o In attrs
            Display(indent + 2, "{0}", o.ToString())
        Next
    End Sub

    ' Display a formatted string indented by the specified amount.
    Sub Display(ByVal indent As Int32, ByVal format As String, ByVal ParamArray params() As Object)
        Console.Write(New String(" "c, indent * 2))
        Console.WriteLine(format, params)
    End Sub
End Module