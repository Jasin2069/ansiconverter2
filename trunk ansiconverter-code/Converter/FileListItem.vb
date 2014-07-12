Imports System.Windows.Forms
''' <summary>
''' Represents a list of files in list <see cref="ListInputFiles"/> to be processed by the converter
''' </summary>
''' <remarks></remarks>
Public Class FileListItem
    Inherits Windows.Forms.Control

    Private m_Name As String
    Private m_FullPath As String
    Private m_Format As FFormats
    Private m_Color As Drawing.Color
    Private m_Label As Windows.Forms.Label
    Private m_Selected As Boolean
    Private m_FType As FTypes

    ''' <summary>
    '''  Gets or Sets the Current <see cref="MForm"/> where the converter assembly is attached to
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Form() As Windows.Forms.Form
        Get
            Return MForm
        End Get
        Set(ByVal value As Windows.Forms.Form)
            MForm = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or Sets the Current <see cref="ToolTip"/> Extender Control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TT() As Windows.Forms.ToolTip
        Get
            Return ToolTip
        End Get
        Set(ByVal value As Windows.Forms.ToolTip)
            ToolTip = value
        End Set
    End Property
    ''' <summary>
    ''' Main Constructor for this class, pre-setting vital properties right away
    ''' </summary>
    ''' <param name="Name">File Name (String)</param>
    ''' <param name="FullPath">Full Path of File (String)</param>
    ''' <param name="Format">File Format as <see cref="FFormats"/></param>
    ''' <param name="FTyp">Optional File Type as <see cref="FTypes"/>, Default = 'FTypes.ASCII'</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Name As String, _
                   ByVal FullPath As String, _
                   ByVal Format As FFormats, _
                   Optional ByVal FTyp As FTypes = FTypes.ASCII)
        Me.m_Name = Name
        Me.m_FullPath = FullPath
        Me.m_Format = Format
        Select Case Format
            Case FFormats.us_ascii
                Me.m_Color = Drawing.Color.Black
            Case FFormats.utf_16
                Me.m_Color = Drawing.Color.Blue
            Case FFormats.utf_8
                Me.m_Color = Drawing.Color.Red
            Case Else
                Me.m_Color = Drawing.Color.Black
        End Select
        Me.m_Label = New Windows.Forms.Label
        Me.m_Label.Text = Me.m_Name
        Me.m_Label.ForeColor = Me.m_Color
        Me.m_Label.BackColor = Drawing.Color.White
        Me.m_FType = FTyp
        MForm.Controls.Add(Me.Label)
        'AddHandler Me.m_Label.Click, AddressOf filelistitem_click
        Me.m_Selected = False
        MForm.Controls.Add(Me)
        ToolTipAndEvents(Me, Me.FullPath)
        ToolTipAndEvents(Me.Label, Me.FullPath)
    End Sub 'New
    ''' <summary>
    ''' Default constructor without any pre-set parameters
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.m_Name = ""
        Me.m_FullPath = ""
        Me.m_Format = FFormats.us_ascii
        Me.m_Color = Drawing.Color.Red
        Me.m_Label = New Windows.Forms.Label
        Me.m_Label.Text = Me.m_Name
        Me.m_Label.ForeColor = Me.m_Color
        Me.m_Label.BackColor = Drawing.Color.White
        Me.m_FType = FTypes.ASCII
        'AddHandler Me.m_Label.Click, AddressOf filelistitem_click
        Me.m_Selected = False
        MForm.Controls.Add(Me.Label)
        MForm.Controls.Add(Me)
        ToolTipAndEvents(Me, Me.FullPath)
        ToolTipAndEvents(Me.Label, Me.FullPath)
    End Sub

    ''' <summary>
    ''' Gets or Sets if the Current Item is Selected or Not
    ''' Toggles to Background Color of the Item between <see cref="System.Drawing.Color.White"/> and <see cref="System.Drawing.Color.Yellow"/>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Selected() As Boolean
        Get
            Return Me.m_Selected
        End Get
        Set(ByVal value As Boolean)
            If value <> Me.m_Selected Then
                Me.m_Selected = value
                If Me.m_Label.BackColor = Drawing.Color.White Then
                    Me.m_Label.BackColor = Drawing.Color.Yellow
                Else
                    Me.m_Label.BackColor = Drawing.Color.White
                End If
            End If

        End Set
    End Property
    ''' <summary>
    ''' returns the default ForeColor used for the control depending of <see cref="Format"/> of the item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Color() As Drawing.Color
        Get
            Return Me.m_Color
        End Get
    End Property
    ''' <summary>
    ''' The <see cref="Windows.Forms.Label"/> Control that represents the item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Label() As Windows.Forms.Label
        Get
            Return Me.m_Label
        End Get
    End Property
    ''' <summary>
    ''' returns the Full Name and Path of the File
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FullPath() As String
        Get
            Return Me.m_FullPath
        End Get
    End Property
    ''' <summary>
    ''' returns the File Name of the File
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Name() As String
        Get
            Return Me.m_Name
        End Get
    End Property
    ''' <summary>
    ''' Returns the detected <see cref="FFormats"/> of Item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Format() As FFormats
        Get
            Return Me.m_Format
        End Get
    End Property
    ''' <summary>
    ''' Returns the detected <see cref="FTypes"/> of the Item
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Type() As FTypes
        Get
            Return Me.m_FType
        End Get
    End Property

    ''' <summary>
    ''' Sets the new Tooltip Value for the specified <paramref>fctrl</paramref> on <see cref="ToolTip"/>
    ''' </summary>
    ''' <param name="fctrl"></param>
    ''' <param name="sStr"></param>
    ''' <remarks></remarks>
    Public Sub ToolTipAndEvents(ByVal fctrl As Windows.Forms.Control, ByVal sStr As String)
        ToolTip.SetToolTip(fctrl, sStr)
        AddHandler fctrl.MouseHover, AddressOf tooltip_MouseHover
        AddHandler fctrl.MouseLeave, AddressOf tooltip_MouseLeave
    End Sub
    Public Sub tooltip_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Cursor <> Cursors.Hand Then
            sender.Cursor = Cursors.Help
        End If
    End Sub
    Public Sub tooltip_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.cursor = Cursors.Help Then
            sender.Cursor = Cursors.Default
        End If
    End Sub
End Class
