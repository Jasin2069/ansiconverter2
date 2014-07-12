Imports System
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Collections
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ControlFactory
    Public Class ControlFactory
        Public Overloads Shared Function CreateControl(ByVal ctrlName As String, ByVal partialName As String)
            Try
                Dim ctrl As Control
                Select Case ctrlName
                    Case "Label"
                        ctrl = New Label
                    Case "TextBox"
                        ctrl = New TextBox
                    Case "PictureBox"
                        ctrl = New PictureBox
                    Case "ListView"
                        ctrl = New ListView
                    Case "ComboBox"
                        ctrl = New ComboBox
                    Case "Button"
                        ctrl = New Button
                    Case "CheckBox"
                        ctrl = New CheckBox
                    Case "RadioButton"
                        ctrl = New RadioButton
                    Case "Panel"
                        ctrl = New Panel
                    Case "MonthCalender"
                        ctrl = New MonthCalendar
                    Case "DateTimePicker"
                        ctrl = New DateTimePicker
                    Case "OnOffInputControlSmall"
                        ctrl = New MyControls.OnOffInputControlSmall
                    Case Else
                        'Dim controlAsm As Assembly = Assembly.LoadWithPartialName(partialName)
                        Dim controlAsm As Assembly = Assembly.Load(partialName)
                        Dim controlType As Type = controlAsm.GetType(partialName + "." + ctrlName)
                        ctrl = Activator.CreateInstance(controlType)
                        'Type.GetType(instances(i))
                End Select
                Return ctrl
            Catch ex As Exception
                System.Diagnostics.Trace.WriteLine("create control failed:" + ex.Message)
                Return New Control()

            End Try
        End Function

        Public Overloads Shared Sub SetControlProperties(ByVal ctrl As Control, ByVal propertylist As Hashtable)
            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)
            For Each myProperty As PropertyDescriptor In properties
                If propertylist.Contains(myProperty.Name) Then
                    Dim obj As Object = propertylist(myProperty.Name)
                    Try
                        myProperty.SetValue(ctrl, obj)
                    Catch ex As Exception
                        System.Diagnostics.Trace.WriteLine(ex.Message)
                    End Try
                End If
            Next
        End Sub

        Public Overloads Shared Function CloneCtrl(ByVal ctrl As Control, Optional ByVal Newname As String = "")
            Dim cbCtrl As CBFormCtrl = New CBFormCtrl(ctrl)
            Dim newCtrl As Control = ControlFactory.CreateControl(cbCtrl.CtrlName, cbCtrl.PartialName)
            If Newname <> "" Then newCtrl.Name = Newname
            ControlFactory.SetControlProperties(newCtrl, cbCtrl.PropertyList)
            Return newCtrl
        End Function

    End Class

    <Serializable()> _
    Public Class CBFormCtrl

        Private m_PartialName As String
        Private m_PropertyList As Hashtable
        Private m_CtrlName As String
        Shared m_Format As DataFormats.Format
        Public Sub New()
            m_PropertyList = New Hashtable

        End Sub
        Public Sub New(ByVal Ctrl As Control)
            m_PropertyList = New Hashtable
            ' Registers a new data format with the windows Clipboard
            m_Format = DataFormats.GetFormat(Me.GetType().FullName)
        End Sub
        Public Shared Property Format() As DataFormats.Format
            Get
                Return m_Format
            End Get
            Set(ByVal value As DataFormats.Format)
                m_Format = value
            End Set
        End Property
        Public Property CtrlName() As String
            Get
                Return m_CtrlName
            End Get
            Set(ByVal value As String)
                m_CtrlName = value
            End Set
        End Property

        Public Property PartialName() As String
            Get
                Return m_PartialName
            End Get
            Set(ByVal value As String)
                m_PartialName = value
            End Set
        End Property
        Public Property PropertyList() As Hashtable
            Get
                Return m_PropertyList
            End Get
            Set(ByVal value As Hashtable)
                m_PropertyList = value
            End Set
        End Property
        Public Sub CBFormCtrl(ByVal ctrl As Control)
            m_CtrlName = ctrl.GetType().Name
            m_PartialName = ctrl.GetType().Namespace
            Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(ctrl)
            For Each myProperty As PropertyDescriptor In properties
                Try
                    If (myProperty.PropertyType.IsSerializable) Then
                        PropertyList.Add(myProperty.Name, myProperty.GetValue(ctrl))
                    End If

                Catch ex As Exception
                    System.Diagnostics.Trace.WriteLine(ex.Message)
                End Try
            Next
        End Sub

    End Class

End Class
