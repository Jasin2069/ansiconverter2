'[VBS2EXE]
'EXE=C:\Documents\VisualStudioProjects\ANSIASCIIConverter\Uninstall.exe
'ICO=
'SHO=cscript.exe
'BTC=1
'[/VBS2EXE]

Const ProgName = "ANSI/ASCII Converter"
Const ProgVer = "1.04.0"
Const is64Bit = False
'-----------------------------------------------------------------
Dim FSO : Set FSO = CreateObject("Scripting.FileSystemObject") 
Dim SH : Set SH = CreateObject("WScript.Shell")
Dim aEnum , iCnt,ax, sVal, sVal2,sKeYRoot, NO_EXIST, TS, Dic : NO_EXIST = "80070002"
If is64Bit = True Then
 sKeYRoot = "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
Else
 sKeYRoot = "HKLM\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
End If 
iCnt = REGEnumSubKeys(sKeYRoot,aEnum)
If iCnt > 0 Then
    For Each ax In  aEnum
        sVal = REGReadValue(sKeYRoot & "\" & ax & "\DisplayName", "S") 
        sVer = REGReadValue(sKeYRoot & "\" & ax & "\DisplayVersion", "S") 
        If sVal = ProgName And sVer = ProgVer Then
            sVal = REGReadValue(sKeYRoot & "\" & ax & "\UninstallString", "S") 
            SH.Run sVal, , False : WScript.Quit(0)
        End If
    Next
End If    
WScript.Quit(0)
'-----------------------------------------------------------------
Function REGEnumSubKeys(RegPath, byref AList)
    Dim sKey, sTemp, A1, Dic, TS, s1, LB, LenP, Pt1, sName
    On Error Resume Next
    If Mid(RegPath, 4, 1) = "\" Then : sKey = "HKEY_USERS" : Else : sKey = TranslateREGKey(Left(RegPath, 4)) : End If    
    If (sKey = "") Then : REGEnumSubKeys = -1 : Exit Function : End If    
    sTemp = FSO.GetSpecialFolder(2) & "\regk.reg.txt"
    If FSO.FileExists(sTemp) Then : FSO.DeleteFile sTemp, True : End If
    sKey = sKey & Right(RegPath, (Len(RegPath) - 4)) : LB = "["
    SH.Run "REGEDIT /E:A """ & sTemp & """ " & Chr(34) & sKey & Chr(34), , True  
    If (FSO.FileExists(sTemp) = False) Then : REGEnumSubKeys = -2 : Exit Function : End If
    LenP = Len(sKey) + 1 : sKey = LB & sKey
    Set Dic = CreateObject("Scripting.Dictionary") : Set TS = FSO.OpenTextFile(sTemp, 1)
    Do While TS.AtEndOfStream = False
        s1 = TS.readline
        If (Left(s1, 1) = LB) Then
            If (Left(s1, LenP) = sKey) Then  
                Pt1 = InStr((LenP + 2), s1, "\") 
                If (Pt1 = 0) Then Pt1 = InStr(LenP, s1, "]") 
                If Pt1 = 0 Then   
                    REGEnumSubKeys = -3 : Set Dic = Nothing : Exit Function 
                End If
                sName = Mid(s1, (LenP + 2), Pt1 - (LenP + 2))
                If (sName <> "") And (Dic.Exists(sName) = False) Then Dic.add sName, sName  
            End If 
        End If    
    Loop     
    TS.Close : Set TS = Nothing
    If (Dic.Count > 0) Then : AList = Dic.keys : End If     
    FSO.DeleteFile sTemp, True
    REGEnumSubKeys = Dic.Count 
End Function
Function REGReadValue(RegPath, sType)
    Dim r, i, i2, A1(), Ub
    On Error Resume Next
    Err.Clear : sType = GetType(RegPath)
    If sType = "E" Then : REGReadValue = "" : Exit Function : End If
    r = SH.RegRead(RegPath)  
    Select Case sType  
        Case "S", "N" : REGReadValue = r
        Case "X" : REGReadValue = SH.ExpandEnvironmentStrings(r)
        Case "BN", "BS"
        Ub = UBound(r) : ReDim A1(Ub)
        For i = 0 To UBound(r)
            A1(i) = Hex(r(i))  
        Next
        REGReadValue = A1
    End Select       
End Function
Function TranslateREGKey(sKeyIn)
    Dim s1 : s1 = UCase(sKeyIn)
    Select Case s1
        Case "HKCR" : TranslateREGKey = "HKEY_CLASSES_ROOT"
        Case "HKCU" : TranslateREGKey = "HKEY_CURRENT_USER"
        Case "HKLM" : TranslateREGKey = "HKEY_LOCAL_MACHINE" 
        Case "HKU" : TranslateREGKey = "HKEY_USERS"
        Case Else : TranslateREGKey = ""
    End Select         
End Function    