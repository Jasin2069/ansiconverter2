Imports System
Imports System.Reflection
Imports System.IO
Imports System.MarshalByRefObject
Imports System.Runtime.InteropServices
Public Class BassModNet
    'BassMOD_Net.dll
    'Exports as Resource Embeded BASSMOD DLL Binary BassMOD_Net.DLL (My.Resources.BassMOD_Net) to the Users Temp Folder and 
    'Loads it from there. All Important Methods are interfaces via this class.
    'Dependencies: WriteFile function
    Public Property Volume() As Integer
        Get
            If bAsmLoaded Then
                BassVolume = Me.GetVolume
            End If
            Return BassVolume
        End Get
        Set(ByVal value As Integer)
            If value <> BassVolume Then
                BassVolume = value
                If bAsmLoaded Then
                    If Not Me.SetVolume(BassVolume) Then
                        Console.WriteLine("BASS:Error Setting Volume")
                    End If
                End If
            End If
        End Set
    End Property

    Public Enum e_BASSMusic
        BASS_DEFAULT = 0
        BASS_MUSIC_CALCLE = 8192
        BASS_MUSIC_FT2MOD = 16
        BASS_MUSIC_LOOP = 4
        BASS_MUSIC_NONINTER = 16384
        BASS_MUSIC_NOSAMPLE = 1048576
        BASS_MUSIC_POSRESET = 256
        BASS_MUSIC_PT1MOD = 32
        BASS_MUSIC_RAMP = 1
        BASS_MUSIC_RAMPS = 2
        BASS_MUSIC_STOPBACK = 2048
        BASS_MUSIC_SURROUND = 512
        BASS_MUSIC_SURROUND2 = 1024
        BASS_UNICODE = -2147483648
    End Enum
    Public Enum e_BASSInit
        BASS_DEVICE_8BITS = 1
        BASS_DEVICE_DEFAULT = 0
        BASS_DEVICE_MONO = 2
        BASS_DEVICE_NOSYNC = 16
    End Enum
    Public Enum e_BASSErrorCode
        BASS_OK = 0
        BASS_ERROR_MEM = 1
        BASS_ERROR_FILEOPEN = 2
        BASS_ERROR_DRIVER = 3
        BASS_ERROR_HANDLE = 5
        BASS_ERROR_FORMAT = 6
        BASS_ERROR_POSITION = 7
        BASS_ERROR_INIT = 8
        BASS_ERROR_START = 9
        BASS_ERROR_ALREADY = 14
        BASS_ERROR_ILLTYPE = 19
        BASS_ERROR_ILLPARAM = 20
        BASS_ERROR_DEVICE = 23
        BASS_ERROR_NOPLAY = 24
        BASS_ERROR_NOMUSIC = 28
        BASS_ERROR_NOSZNC = 30
        BASS_ERROR_EMPTY = 31
        BASS_ERROR_NOTAVAIL = 37
        BASS_ERROR_DECODE = 38
        BASS_ERROR_FILEFORM = 41
    End Enum
    Public ListMethods As New List(Of System.Reflection.MethodInfo)
    Public ListMethodNames As New List(Of String)
    Private asmBASS As System.Reflection.Assembly
    Private typBASSMOD As Type

    Private bAsmLoaded As Boolean = False
    Private Const sPreBASSClass = "Un4seen.BassMOD.BassMOD"
    Private oActivator As Object
    Private BassVolume As Integer = 100
    Private iPlayHandle As Integer = 0

    Public Sub New()
        ListMethodNames.Add("BASSMOD_Init")
        ListMethodNames.Add("BASS_MusicLoad")
        ListMethodNames.Add("BASS_MusicLoad2")
        ListMethodNames.Add("BASSMOD_MusicLoad")
        ListMethodNames.Add("BASSMOD_MusicLoad2")
        ListMethodNames.Add("BASSMOD_MusicStop")
        ListMethodNames.Add("BASSMOD_MusicPause")
        ListMethodNames.Add("BASSMOD_MusicGetName")
        ListMethodNames.Add("BASSMOD_MusicSetPosition")
        ListMethodNames.Add("BASSMOD_MusicGetPosition")
        ListMethodNames.Add("BASSMOD_SetVolume")
        ListMethodNames.Add("BASSMOD_GetVolume")
        ListMethodNames.Add("BASSMOD_MusicGetLength")
        ListMethodNames.Add("BASSMOD_MusicPlay")
        ListMethodNames.Add("BASSMOD_MusicPlayEx")
        ListMethodNames.Add("BASSMOD_MusicFree")

        For a As Integer = 0 To ListMethodNames.Count - 1
            ListMethods.Add(Nothing)
        Next
        BassVolume = 100
        bAsmLoaded = False
        iPlayHandle = 0
        asmBASS = Nothing
    End Sub

    Public Function Init(ByVal device As Int32, ByVal freq As Int32, ByVal flags As e_BASSInit) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_Init as boolean
        'device int32
        'freq int32
        'flags int32
        Dim sMethod As String = "BASSMOD_Init"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {Int32.Parse(device), Int32.Parse(freq), Int32.Parse(flags)}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        bResults = CType(oResults, Boolean)
        Return (bResults)
    End Function

    Public Function [Stop](Optional ByVal bFreeBass As Boolean = False) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicStop as boolean
        Dim sMethod As String = "BASSMOD_MusicStop"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        bResults = CType(oResults, Boolean)
        If bFreeBass = True Then
            Me.Free(iPlayHandle)
        End If
        Return (bResults)
    End Function
    Public Function Pause() As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicPause as boolean
        Dim sMethod As String = "BASSMOD_MusicPause"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {Nothing}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        bResults = CType(oResults, Boolean)
        Return (bResults)
    End Function
    Public Function Free(Optional ByVal handle As Int32 = 0) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicFree as boolean
        'handle int32
        Dim sMethod As String = "BASSMOD_MusicFree"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {Int32.Parse(handle)}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        bResults = CType(oResults, Boolean)
        Return (bResults)
    End Function
    Public Function Play(Optional ByVal initVolume As Int32 = 100) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicPlay as boolean
        Dim sMethod As String = "BASSMOD_MusicPlay"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {Nothing}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        bResults = CType(oResults, Boolean)
        If Not Me.SetVolume(initVolume) Then
            Console.WriteLine("BASS: Error SetVolume: " & initVolume)
        End If
        Return (bResults)
    End Function

    Public Function PlayEx(ByVal pos As Int32, ByVal flags As e_BASSInit, ByVal reset As Boolean) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicPlayEx as boolean
        'pos int32
        'flags int32
        'reset boolean
        Dim sMethod As String = "BASSMOD_MusicPlayEx"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {Int32.Parse(pos), Int32.Parse(flags), reset}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        bResults = CType(oResults, Boolean)
        Return (bResults)
    End Function

    Public Function GetLength(ByVal playlen As Boolean) As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicGetLength as int32
        'playlen boolean
        Dim sMethod As String = "BASSMOD_MusicGetLength"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {playlen}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        intResult = CType(oResults, Int32)
        Return (intResult)
    End Function

    Public Function GetName() As String
        Dim strResult As String = ""
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicGetName as string
        Dim sMethod As String = "BASSMOD_MusicGetName"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {Nothing}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        strResult = CType(oResults, String)
        Return (strResult)
    End Function
    Public Function GetPosition() As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicGetPosition as int32
        Dim sMethod As String = "BASSMOD_MusicGetPosition"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {Nothing}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        intResult = CType(oResults, Int32)
        Return (intResult)
    End Function
    Public Function SetPosition(ByVal pos As Int32) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicSetPosition as boolean
        'pos int32
        Dim sMethod As String = "BASSMOD_MusicSetPosition"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {Int32.Parse(pos)}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        bResults = CType(oResults, Boolean)
        Return (bResults)
    End Function
    Public Function LoadModule(ByVal memory As Byte(), ByVal offset As Int32, ByVal length As Int32, ByVal flags As e_BASSMusic) As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicLoad as int32
        'memory as byte()
        'offset as int32
        'length as int32
        'flags as e_BassMusic
        Dim sMethod As String = "BASSMOD_MusicLoad"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing
        Try
            Dim oParams As Object() = {memory, Int32.Parse(offset), Int32.Parse(length), Int32.Parse(flags)}
            oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
            intResult = CType(oResults, Int32)
            iPlayHandle = intResult
        Catch ex As Exception
            Dim ByteArray As Byte() = New Byte() {0}
            Dim iXSize As Integer = memory.Length - 1
            ReDim ByteArray(CType(iXSize, Int32))
            CType(memory, Byte()).CopyTo(ByteArray, 0)
            Dim gch As GCHandle = GCHandle.Alloc(ByteArray, GCHandleType.Pinned)
            intResult = Me.LoadModule(gch.AddrOfPinnedObject, offset, ByteArray.Length, flags)
            iPlayHandle = intResult
        End Try
        Return (intResult)
    End Function
    Public Function LoadModule(ByVal memory As IntPtr, ByVal offset As Int32, ByVal length As Int32, ByVal flags As e_BASSMusic) As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASSMOD_MusicLoad as int32
        'memory as IntPtr
        'offset as int32
        'length as int32
        'flags as e_BassMusic
        Dim sMethod As String = "BASSMOD_MusicLoad2"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {memory, Int32.Parse(offset), Int32.Parse(length), Int32.Parse(flags)}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        intResult = CType(oResults, Int32)
        iPlayHandle = intResult
        Return (intResult)
    End Function

    Public Function LoadModule(ByVal file As String, ByVal offset As Int32, ByVal length As Int32, ByVal flags As e_BASSMusic) As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASS_MusicLoad as int32
        'file as string
        'offset as int32
        'length as int32
        'flags as e_BassMusic
        Dim sMethod As String = "BASS_MusicLoad"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing
        If IO.File.Exists(file) Then
            'Dim iSize As Integer = GetFileSize(file)
            'm_TrackID = BassMOD.BASS_MusicLoad(sFile, 0, iSize, BASSMusic.BASS_MUSIC_FT2MOD)
            Dim oParams As Object() = {file.ToString, Int32.Parse(offset), Int32.Parse(length), Int32.Parse(flags)}
            oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
            intResult = CType(oResults, Int32)
            iPlayHandle = intResult
        Else
            intResult = e_BASSErrorCode.BASS_ERROR_FILEOPEN
        End If
        Return (intResult)
    End Function
    Public Function LoadModule(ByVal file As String, ByVal offset As Int32, ByVal length As Int32, ByVal flags As Int32) As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASS_MusicLoad as int32
        'file as string
        'offset as int32
        'length as int32
        'flags as int32
        Dim sMethod As String = "BASS_MusicLoad2"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing
        If IO.File.Exists(file) Then
            Dim oParams As Object() = {file.ToString, Int32.Parse(offset), Int32.Parse(length), Int32.Parse(flags)}
            oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
            intResult = CType(oResults, Int32)
            iPlayHandle = intResult
        Else
            intResult = e_BASSErrorCode.BASS_ERROR_FILEOPEN
        End If
        Return (intResult)
    End Function

    Public Sub FadeInMusic(ByVal iToVol As Integer)
        If BassVolume >= iToVol Then Exit Sub
        While BassVolume < iToVol
            BassVolume += 1
            If BassVolume > iToVol Then BassVolume = iToVol
            System.Windows.Forms.Application.DoEvents()
            If Not Me.SetVolume(BassVolume) Then
                Console.WriteLine("BASS:Error Setting Volume")
                System.Windows.Forms.Application.DoEvents()
            End If
            System.Threading.Thread.Sleep(2)
            For z As Integer = 1 To 10000
                If z Mod 1000 = 0 Then
                    System.Windows.Forms.Application.DoEvents()
                End If
            Next
            System.Threading.Thread.Sleep(2)
        End While
    End Sub
    Public Sub FadeOutMusic(Optional ByVal stopbass As Boolean = False)
        While BassVolume > 0
            BassVolume -= 1
            If BassVolume < 0 Then BassVolume = 0
            System.Windows.Forms.Application.DoEvents()
            If Not Me.SetVolume(BassVolume) Then
                Console.WriteLine("BASS:Error Setting Volume")
                System.Windows.Forms.Application.DoEvents()
            End If
            System.Threading.Thread.Sleep(2)
            For z As Integer = 1 To 10000
                If z Mod 1000 = 0 Then
                    System.Windows.Forms.Application.DoEvents()
                End If
            Next
            System.Threading.Thread.Sleep(2)
        End While
        If stopbass Then
            Me.Stop()
        End If
    End Sub


    Public Sub ExportAndLoadAssembly()

        Dim sTmpFile As String = IO.Path.GetTempFileName & ".dll"
        Call Converter.ConverterSupport.WriteFile(sTmpFile, My.Resources.BassMOD_Net, True, 0, True, True)
        asmBASS = System.Reflection.Assembly.LoadFrom(sTmpFile)
        If TypeOf asmBASS Is System.Reflection.Assembly Then
            bAsmLoaded = True
        Else
            bAsmLoaded = False
        End If

        Dim m As MethodInfo()
        Dim mm As MethodInfo
        Dim t As Type()
        If bAsmLoaded = True Then

            t = asmBASS.GetTypes()
            For a As Integer = 0 To t.Count - 1
                If t(a).FullName = sPreBASSClass Then
                    typBASSMOD = t(a)
                    Exit For
                End If
            Next
            oActivator = Activator.CreateInstance(typBASSMOD)
            m = typBASSMOD.GetMethods()
            For a As Integer = 0 To m.Count - 1
                '----------- Loop Through Methods --------------------------
                mm = m(a)
                Dim sLookupName = ""

                If mm.Name = "BASS_MusicLoad" Or mm.Name = "BASSMOD_MusicLoad" Then

                    Dim pi As ParameterInfo

                    For Each pi In CType(mm, MethodInfo).GetParameters()
                        'pi.ParameterType, pi.Name
                        Select Case mm.Name
                            Case "BASS_MusicLoad"
                                If pi.Name = "flags" Then
                                    If pi.ParameterType.ToString = "System.Int32" Then
                                        sLookupName = "BASS_MusicLoad"
                                    End If
                                    If pi.ParameterType.ToString = "Un4seen.BassMOD.BASSMusic" Then
                                        sLookupName = "BASS_MusicLoad2"
                                    End If
                                End If
                            Case "BASSMOD_MusicLoad"
                                If pi.Name = "memory" Then
                                    If pi.ParameterType.ToString = "System.Byte[]" Then
                                        sLookupName = "BASSMOD_MusicLoad"
                                    End If
                                    If pi.ParameterType.ToString = "System.IntPtr" Then
                                        sLookupName = "BASSMOD_MusicLoad2"
                                    End If
                                End If
                        End Select

                    Next

                Else
                    sLookupName = mm.Name
                End If

                Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sLookupName.Equals(x))
                If iFound >= 0 Then
                    ListMethods.Item(iFound) = mm
                End If
            Next


        End If

    End Sub

    Private Function GetTypeFromName(Optional ByVal FullName As String = "", Optional ByVal clsNamespace As String = "", _
                                     Optional ByVal clsName As String = "") As Type
        Dim MyTypes(), MyType As Type, Item As Type
        Item = Nothing
        ' Iterate through the program's classes.
        MyTypes = asmBASS.GetTypes()
        For Each MyType In MyTypes
            If (StrComp(MyType.Namespace, clsNamespace, CompareMethod.Text) = 0 And _
                StrComp(MyType.Name, clsName, CompareMethod.Text) = 0) Or (FullName <> "" And _
                StrComp(MyType.FullName, FullName, CompareMethod.Text) = 0) Then
                Item = Type.GetType(MyType.FullName)
                Exit For
            End If
        Next
        Return Item
    End Function

    Private Function SetVolume(ByVal volume As Int32) As Boolean
        Dim bResults As Boolean = False
        'Un4seen.BassMOD.BassMOD.BASSMOD_SetVolume as boolean
        'volume int32
        Dim sMethod As String = "BASSMOD_SetVolume"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        Dim oParams As Object() = {Int32.Parse(volume)}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, oParams).ToString()
        bResults = CType(oResults, Boolean)
        BassVolume = volume
        Return (bResults)
    End Function
    Private Function GetVolume() As Int32
        Dim intResult As Int32 = 0
        'Un4seen.BassMOD.BassMOD.BASSMOD_GetVolume as int32
        Dim sMethod As String = "BASSMOD_GetVolume"
        Dim iFound As Integer = ListMethodNames.FindIndex(Function(x) sMethod.Equals(x))
        Dim oResults As Object = Nothing

        'Dim oParams As Object() = {Nothing}
        oResults = ListMethods.Item(iFound).Invoke(oActivator, Nothing).ToString()
        intResult = CType(oResults, Int32)
        BassVolume = intResult
        Return (intResult)
    End Function

End Class
