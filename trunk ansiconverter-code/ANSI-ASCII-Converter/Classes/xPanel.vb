Public Class xPanel
    Inherits Panel
    Private m_Bmp As Bitmap = Nothing
    Public Sub New()
        'Me.DoubleBuffered = True
    End Sub
    Public Property BMP() As Bitmap
        Get
            Return m_Bmp
        End Get
        Set(ByVal value As Bitmap)
            m_Bmp = value
            'Me.BackColor = Color.FromArgb(128, 0, 0, 0)

        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams
            cp = MyBase.CreateParams
            cp.ExStyle = &H20
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        If Not m_Bmp Is Nothing Then
            e.Graphics.DrawImage(m_Bmp, 0, 0, Me.Width, Me.Height)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), Me.ClientRectangle)
        End If

    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
    End Sub
End Class