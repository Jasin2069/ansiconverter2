Public Class FontsLoader
    Inherits Windows.Forms.Form


    Friend ItemCount As Integer = 0
    Friend Shared NumLoaded As Integer = 0
    Private WithEvents LoadTimer As New Windows.Forms.Timer
    Private aFiles() As String
    Private oThread As Threading.Thread = Nothing
    Public Event evItemLoaded()
    Public Event evIndexLoaded()

    Friend Sub TimerTick(ByVal Sender As Object, ByVal e As EventArgs)

        If Not oThread Is Nothing Then
            If oThread.ThreadState = Threading.ThreadState.Stopped Then
                LoadTimer.Enabled = False
                'indexloaded()
                If oMainForm.pOut.Visible = False Or oMainForm.listFiles.Items.Count = 0 Or oMainForm.pOut.Tag = "" Then
                    oMainForm.btnStart.Enabled = False
                Else
                    oMainForm.btnStart.Enabled = True
                End If
                bBatchAdd = False
                RaiseEvent evIndexLoaded()
                oMainForm.Visible = True
                oMainForm.BringToFront()
                Me.Close()
            End If
        End If
        Me.Invalidate()
        System.Windows.Forms.Application.DoEvents()
    End Sub
    Friend Sub Form_Activated(ByVal Sender As Object, ByVal e As EventArgs) Handles Me.Activated
        LoadTimer.Enabled = True
    End Sub
    Friend Sub indexloaded()
        SetloadStatusText(NumLoaded)
        SettxtCurrText(NumLoaded)
    End Sub
    Friend Sub fntLoaded()
        System.Threading.Interlocked.Add(NumLoaded, 1)
        'NumLoaded += 1
        SetloadStatusText(NumLoaded)
        SettxtCurrText(NumLoaded)
    End Sub

    Delegate Sub SetloadStatusTextCallback([text] As String)
    Private Sub SetloadStatusText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.loadStatus.InvokeRequired Then
            Dim d As New SetloadStatusTextCallback(AddressOf SetloadStatusText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.loadStatus.Value = [text]
            'Me.loadStatus.Invalidate()
        End If
    End Sub
    Delegate Sub SettxtCurrTextCallback([text] As String)
    Private Sub SettxtCurrText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.txtCurr.InvokeRequired Then
            Dim d As New SettxtCurrTextCallback(AddressOf SettxtCurrText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.txtCurr.Text = [text]
            'Me.txtCurr.Invalidate()
        End If
    End Sub

    Private Delegate Sub dlgAddFile(ByVal sFile As String)


    Public Sub LoadItems(ByVal aMyItems() As String)
        Dim alphacomp As New AlphanumComparator.AlphanumComparator
        Array.Sort(aMyItems, alphacomp)
        If aMyItems.Count > 10 Then
            bBatchAdd = True
        Else
            bBatchAdd = False
        End If
        For a As Integer = 0 To aMyItems.Length - 1
            Dim dlg As New dlgAddFile(AddressOf UserInterface.AddFile)
            FireAsync(dlg, New Object() {aMyItems(a)})
            'Call UserInterface.AddFile()
            RaiseEvent evItemLoaded()
        Next
    End Sub
    Public Sub New(ByVal items As String())
        MyBase.new()
        aFiles = items
        ' This call is required by the designer.
        InitializeComponent()
        loadStatus.MaxValue = aFiles.Length
        txtNum.Text = aFiles.Length
        txtCurr.Text = 0
        LoadTimer.Enabled = False
        LoadTimer.Interval = 3000
        NumLoaded = 0
        ItemCount = 0
        AddHandler LoadTimer.Tick, AddressOf TimerTick


        ' Add any initialization after the InitializeComponent() call.
        If Not Me.DesignMode Then
            Me.MakeFormBordersRound(Me.GetPathPointString())
        End If
    End Sub
    Protected Overrides Sub OnLoad(e As System.EventArgs)
        MyBase.OnLoad(e)
        oThread = New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf LoadItems))
        AddHandler evItemLoaded, AddressOf Me.fntLoaded
        AddHandler evIndexLoaded, AddressOf Me.indexloaded
        oThread.Start(aFiles)
        If Not Me.DesignMode Then
            Me.MakeFormBordersRound(Me.GetPathPointString())
        End If

    End Sub

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.DrawFormBorder(e, Me.GetPathPointString())
    End Sub
    Protected Overrides Sub OnActivated(e As System.EventArgs)
        MyBase.OnActivated(e)
        If Not Me.DesignMode Then
            Me.MakeFormBordersRound(Me.GetPathPointString())
        End If

    End Sub
    Protected Overrides Sub OnResizeEnd(e As System.EventArgs)
        MyBase.OnResizeEnd(e)
        If Not Me.DesignMode Then
            Me.MakeFormBordersRound(Me.GetPathPointString())
        End If
        Me.Invalidate()
    End Sub
    Protected Overrides Sub OnInvalidated(e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)
        If Not Me.DesignMode Then
            Me.MakeFormBordersRound(Me.GetPathPointString())
        End If

    End Sub
    Public Function GetPathPointString(Optional ByVal off As Integer = 30) As String
        Dim oGraphicsPath As New Drawing2D.GraphicsPath
        Dim w As Integer = Me.Width - off
        Dim h As Integer = Me.Height - off
        oGraphicsPath.AddArc(0, 0, off, off, 180, 90)
        oGraphicsPath.AddArc(w, 0, off, off, 270, 90)
        oGraphicsPath.AddArc(w, h, off, off, 0, 90)
        oGraphicsPath.AddArc(0, h, off, off, 90, 90)
        oGraphicsPath.CloseAllFigures()
        Dim sPathPoints As String = ""
        For a As Integer = 0 To oGraphicsPath.PathPoints.Length - 1
            If sPathPoints <> "" Then sPathPoints &= "|"
            sPathPoints &= oGraphicsPath.PathPoints(a).X.ToString & ";" & oGraphicsPath.PathPoints(a).Y.ToString
        Next
        Return sPathPoints
    End Function
    Public Sub MakeFormBordersRound(ByVal PathPoints As String)
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Or _
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized Then Exit Sub
        If PathPoints = "" Then
            PathPoints = Me.GetPathPointString()
        End If
        Dim path As System.Drawing.Drawing2D.GraphicsPath = PathPointsStringToGraphicsPath(PathPoints)
        If Not path Is Nothing Then
            Me.Region = New Region(path)
        End If
    End Sub
    Public Sub DrawFormBorder(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal PathPoints As String)
        If PathPoints = "" Then
            PathPoints = Me.GetPathPointString()
        End If
        Dim path As System.Drawing.Drawing2D.GraphicsPath = PathPointsStringToGraphicsPath(PathPoints)
        If Not path Is Nothing Then
            Using Pen1 As New Drawing.Pen(New System.Drawing.Drawing2D.LinearGradientBrush( _
                                          New Drawing.Point(0, 0), _
                                          New Drawing.Point(Me.ClientRectangle.Width, Me.ClientRectangle.Height), _
                                          Color.FromArgb(Me.Opacity * 255, 200, 0, 0), _
                                          Color.FromArgb(Me.Opacity * 255, 28, 0, 0)), 4)
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                Pen1.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset
                e.Graphics.DrawPath(Pen1, path)
                Pen1.Dispose()
                path.Dispose()
            End Using
        End If
    End Sub
    Public Function PathPointsStringToGraphicsPath(ByVal s As String) As Drawing2D.GraphicsPath

        If s = "" Or s Is Nothing Then
            Return Nothing
            Exit Function
        End If
        Dim aTemp() As String = Split(s, "|")
        Dim pntList As New List(Of Drawing.PointF)
        Dim gp As New Drawing2D.GraphicsPath
        For b = 0 To aTemp.Length - 1
            Dim aPnts() As String = Split(aTemp(b), ";")
            pntList.Add(New Drawing.PointF(CSng(aPnts(0)), CSng(aPnts(1))))
        Next
        Dim p1 As Drawing.PointF = Nothing
        Dim p2 As Drawing.PointF = Nothing
        For b = 0 To pntList.Count - 1
            If b = 0 Then
                p1 = pntList.Item(b)
            ElseIf b = pntList.Count - 1 Then
                p2 = pntList.Item(b)
                gp.AddLine(p1, p2)
                p1 = p2
                p2 = pntList.Item(0)
                gp.AddLine(p1, p2)
            Else
                p2 = pntList.Item(b)
                gp.AddLine(p1, p2)
                p1 = p2
            End If
        Next
        gp.CloseFigure()
        Return gp

    End Function
End Class