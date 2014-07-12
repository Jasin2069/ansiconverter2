<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FontsLoader
    Inherits Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FontsLoader))
        Me.lblFontProperties = New System.Windows.Forms.Label()
        Me.txtCurr = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.Label()
        Me.lblSep = New System.Windows.Forms.Label()
        Me.loadStatus = New ANSI_ASCII_Converter.CustomPanelControl()
        Me.SuspendLayout()
        '
        'lblFontProperties
        '
        Me.lblFontProperties.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFontProperties.ForeColor = System.Drawing.Color.Cyan
        Me.lblFontProperties.Location = New System.Drawing.Point(12, 9)
        Me.lblFontProperties.Name = "lblFontProperties"
        Me.lblFontProperties.Size = New System.Drawing.Size(519, 43)
        Me.lblFontProperties.TabIndex = 25
        Me.lblFontProperties.Text = "Reload Unfinished Items from Last Session"
        Me.lblFontProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurr
        '
        Me.txtCurr.ForeColor = System.Drawing.Color.White
        Me.txtCurr.Location = New System.Drawing.Point(287, 114)
        Me.txtCurr.Name = "txtCurr"
        Me.txtCurr.Size = New System.Drawing.Size(100, 23)
        Me.txtCurr.TabIndex = 27
        Me.txtCurr.Text = "0"
        Me.txtCurr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNum
        '
        Me.txtNum.ForeColor = System.Drawing.Color.White
        Me.txtNum.Location = New System.Drawing.Point(406, 114)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(100, 23)
        Me.txtNum.TabIndex = 28
        Me.txtNum.Text = "0"
        Me.txtNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSep
        '
        Me.lblSep.ForeColor = System.Drawing.Color.White
        Me.lblSep.Location = New System.Drawing.Point(390, 114)
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(12, 23)
        Me.lblSep.TabIndex = 29
        Me.lblSep.Text = "/"
        Me.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'loadStatus
        '
        Me.loadStatus.BackColor = System.Drawing.Color.Black
        Me.loadStatus.BackColor1 = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.loadStatus.BackColor2 = System.Drawing.Color.Black
        Me.loadStatus.BackColorStyle = ANSI_ASCII_Converter.CustomPanelControl.ColorStyle.Gradient
        Me.loadStatus.BackGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.loadStatus.BackSigmaMode = ANSI_ASCII_Converter.CustomPanelControl.SigmaMode.SigmaBell
        Me.loadStatus.BackSigmaScale = 90
        Me.loadStatus.BorderColor3DDark = System.Drawing.SystemColors.ControlDark
        Me.loadStatus.BorderColor3DLight = System.Drawing.SystemColors.ControlLightLight
        Me.loadStatus.BorderColorSingle = System.Drawing.Color.Black
        Me.loadStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.loadStatus.Location = New System.Drawing.Point(19, 75)
        Me.loadStatus.MaxValue = CType(100, Long)
        Me.loadStatus.Name = "loadStatus"
        Me.loadStatus.SelRange = CType(resources.GetObject("loadStatus.SelRange"), System.Drawing.PointF)
        Me.loadStatus.Size = New System.Drawing.Size(512, 20)
        Me.loadStatus.TabIndex = 26
        Me.loadStatus.Value = CType(0, Long)
        '
        'FontsLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(554, 155)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSep)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.txtCurr)
        Me.Controls.Add(Me.loadStatus)
        Me.Controls.Add(Me.lblFontProperties)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FontsLoader"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FontsLoader"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFontProperties As System.Windows.Forms.Label
    Friend WithEvents loadStatus As CustomPanelControl
    Friend WithEvents txtCurr As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.Label
    Friend WithEvents lblSep As System.Windows.Forms.Label
End Class
