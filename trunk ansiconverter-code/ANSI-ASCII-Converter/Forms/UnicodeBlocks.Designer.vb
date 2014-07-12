<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnicodeBlocks
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.btnClose = New MyControls.GButton()
        Me.listUniBlocks = New System.Windows.Forms.ListBox()
        Me.seBlockName = New System.Windows.Forms.Label()
        Me.pUniBlockTemplate = New System.Windows.Forms.Panel()
        Me.FadingLabel1 = New ANSI_ASCII_Converter.FadingLabelPanel()
        Me.pCharTemplate = New System.Windows.Forms.Panel()
        Me.lblCharHextemplate = New System.Windows.Forms.Label()
        Me.lblCharIntTemplate = New System.Windows.Forms.Label()
        Me.lblCharTemplate = New System.Windows.Forms.Label()
        Me.NuMBlocks = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblShiftKey = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.btnSelfont = New MyControls.GButton()
        Me.lblSelFont = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pUniBlockTemplate.SuspendLayout()
        Me.pCharTemplate.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BeginColor = System.Drawing.SystemColors.Control
        Me.btnClose.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnClose.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnClose.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnClose.Location = New System.Drawing.Point(715, 435)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(149, 29)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.btnClose, "list code page " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "list and return " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to converter")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'listUniBlocks
        '
        Me.listUniBlocks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listUniBlocks.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listUniBlocks.FormattingEnabled = True
        Me.listUniBlocks.Location = New System.Drawing.Point(12, 5)
        Me.listUniBlocks.Name = "listUniBlocks"
        Me.listUniBlocks.Size = New System.Drawing.Size(760, 108)
        Me.listUniBlocks.TabIndex = 5
        '
        'seBlockName
        '
        Me.seBlockName.BackColor = System.Drawing.Color.Transparent
        Me.seBlockName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seBlockName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.seBlockName.Location = New System.Drawing.Point(12, 113)
        Me.seBlockName.Name = "seBlockName"
        Me.seBlockName.Size = New System.Drawing.Size(667, 25)
        Me.seBlockName.TabIndex = 6
        Me.seBlockName.Text = "Selected Unicode Block"
        '
        'pUniBlockTemplate
        '
        Me.pUniBlockTemplate.BackColor = System.Drawing.Color.Transparent
        Me.pUniBlockTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pUniBlockTemplate.Controls.Add(Me.FadingLabel1)
        Me.pUniBlockTemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pUniBlockTemplate.Location = New System.Drawing.Point(16, 140)
        Me.pUniBlockTemplate.Name = "pUniBlockTemplate"
        Me.pUniBlockTemplate.Size = New System.Drawing.Size(840, 289)
        Me.pUniBlockTemplate.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.pUniBlockTemplate, "Click Character for Details")
        '
        'FadingLabel1
        '
        Me.FadingLabel1.AutoSize = True
        Me.FadingLabel1.BackColor = System.Drawing.Color.White
        Me.FadingLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FadingLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FadingLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FadingLabel1.HotKeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
        Me.FadingLabel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        Me.FadingLabel1.Interval = 4
        Me.FadingLabel1.Label = "Loading Characters"
        Me.FadingLabel1.Location = New System.Drawing.Point(226, 80)
        Me.FadingLabel1.Margin = New System.Windows.Forms.Padding(7)
        Me.FadingLabel1.Name = "FadingLabel1"
        Me.FadingLabel1.ShowFocus = False
        Me.FadingLabel1.Size = New System.Drawing.Size(330, 46)
        Me.FadingLabel1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Me.FadingLabel1.StepSize = 1
        Me.FadingLabel1.StringFormat = ANSI_ASCII_Converter.FadingLabelPanel.StringFormats.FitBlackBox
        Me.FadingLabel1.TabIndex = 13
        Me.FadingLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FadingLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Me.FadingLabel1.UseMnemonic = True
        '
        'pCharTemplate
        '
        Me.pCharTemplate.BackColor = System.Drawing.Color.Silver
        Me.pCharTemplate.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.BG25pxg
        Me.pCharTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pCharTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pCharTemplate.Controls.Add(Me.lblCharHextemplate)
        Me.pCharTemplate.Controls.Add(Me.lblCharIntTemplate)
        Me.pCharTemplate.Controls.Add(Me.lblCharTemplate)
        Me.pCharTemplate.Location = New System.Drawing.Point(778, 94)
        Me.pCharTemplate.Name = "pCharTemplate"
        Me.pCharTemplate.Size = New System.Drawing.Size(80, 40)
        Me.pCharTemplate.TabIndex = 8
        Me.pCharTemplate.Tag = "org"
        '
        'lblCharHextemplate
        '
        Me.lblCharHextemplate.BackColor = System.Drawing.Color.Silver
        Me.lblCharHextemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCharHextemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCharHextemplate.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharHextemplate.Location = New System.Drawing.Point(39, 20)
        Me.lblCharHextemplate.Name = "lblCharHextemplate"
        Me.lblCharHextemplate.Size = New System.Drawing.Size(41, 20)
        Me.lblCharHextemplate.TabIndex = 2
        Me.lblCharHextemplate.Text = "0000"
        Me.lblCharHextemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCharIntTemplate
        '
        Me.lblCharIntTemplate.BackColor = System.Drawing.Color.LightGray
        Me.lblCharIntTemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCharIntTemplate.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharIntTemplate.Location = New System.Drawing.Point(40, 1)
        Me.lblCharIntTemplate.Name = "lblCharIntTemplate"
        Me.lblCharIntTemplate.Size = New System.Drawing.Size(40, 19)
        Me.lblCharIntTemplate.TabIndex = 1
        Me.lblCharIntTemplate.Text = "0000"
        Me.lblCharIntTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCharTemplate
        '
        Me.lblCharTemplate.BackColor = System.Drawing.Color.Transparent
        Me.lblCharTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCharTemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCharTemplate.Font = New System.Drawing.Font("Lucida Console", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCharTemplate.Location = New System.Drawing.Point(0, 0)
        Me.lblCharTemplate.Name = "lblCharTemplate"
        Me.lblCharTemplate.Size = New System.Drawing.Size(40, 40)
        Me.lblCharTemplate.TabIndex = 0
        Me.lblCharTemplate.Text = "X"
        Me.lblCharTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NuMBlocks
        '
        Me.NuMBlocks.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NuMBlocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuMBlocks.Location = New System.Drawing.Point(780, 30)
        Me.NuMBlocks.Name = "NuMBlocks"
        Me.NuMBlocks.Size = New System.Drawing.Size(73, 35)
        Me.NuMBlocks.TabIndex = 9
        Me.NuMBlocks.Text = "0"
        Me.NuMBlocks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(780, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 27)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Blocks"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblShiftKey
        '
        Me.lblShiftKey.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftKey.ForeColor = System.Drawing.Color.Khaki
        Me.lblShiftKey.Location = New System.Drawing.Point(362, 440)
        Me.lblShiftKey.Name = "lblShiftKey"
        Me.lblShiftKey.Size = New System.Drawing.Size(327, 19)
        Me.lblShiftKey.TabIndex = 11
        Me.lblShiftKey.Text = "Hold Shift-Key to Zoom Details while Hovering"
        '
        'FontDialog1
        '
        Me.FontDialog1.FixedPitchOnly = True
        Me.FontDialog1.FontMustExist = True
        '
        'btnSelfont
        '
        Me.btnSelfont.BeginColor = System.Drawing.SystemColors.Control
        Me.btnSelfont.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnSelfont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelfont.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSelfont.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSelfont.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelfont.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSelfont.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSelfont.Location = New System.Drawing.Point(243, 435)
        Me.btnSelfont.Name = "btnSelfont"
        Me.btnSelfont.Size = New System.Drawing.Size(113, 29)
        Me.btnSelfont.TabIndex = 0
        Me.btnSelfont.Text = "Select Font"
        Me.btnSelfont.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnSelfont, "Select a different font" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the display of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " the character sets")
        Me.btnSelfont.UseVisualStyleBackColor = True
        '
        'lblSelFont
        '
        Me.lblSelFont.BackColor = System.Drawing.Color.Transparent
        Me.lblSelFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSelFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSelFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelFont.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSelFont.Location = New System.Drawing.Point(12, 440)
        Me.lblSelFont.Name = "lblSelFont"
        Me.lblSelFont.Size = New System.Drawing.Size(219, 19)
        Me.lblSelFont.TabIndex = 12
        Me.lblSelFont.Text = "Font Name"
        Me.ToolTip1.SetToolTip(Me.lblSelFont, "Name of the currently " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected font for the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "display of the character" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sets. Yo" & _
        "u can change it!")
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Yellow
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Quick Help"
        '
        'UnicodeBlocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(869, 466)
        Me.Controls.Add(Me.lblSelFont)
        Me.Controls.Add(Me.btnSelfont)
        Me.Controls.Add(Me.lblShiftKey)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NuMBlocks)
        Me.Controls.Add(Me.pCharTemplate)
        Me.Controls.Add(Me.pUniBlockTemplate)
        Me.Controls.Add(Me.seBlockName)
        Me.Controls.Add(Me.listUniBlocks)
        Me.Controls.Add(Me.btnClose)
        Me.KeyPreview = True
        Me.Name = "UnicodeBlocks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UnicodeBlocks"
        Me.pUniBlockTemplate.ResumeLayout(False)
        Me.pUniBlockTemplate.PerformLayout()
        Me.pCharTemplate.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As MyControls.GButton
    Friend WithEvents listUniBlocks As System.Windows.Forms.ListBox
    Friend WithEvents seBlockName As System.Windows.Forms.Label
    Friend WithEvents pUniBlockTemplate As System.Windows.Forms.Panel
    Friend WithEvents pCharTemplate As System.Windows.Forms.Panel
    Friend WithEvents lblCharTemplate As System.Windows.Forms.Label
    Friend WithEvents lblCharHextemplate As System.Windows.Forms.Label
    Friend WithEvents lblCharIntTemplate As System.Windows.Forms.Label
    Friend WithEvents NuMBlocks As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblShiftKey As System.Windows.Forms.Label
    Public WithEvents FontDialog1 As New System.Windows.Forms.FontDialog
    Friend WithEvents btnSelfont As MyControls.GButton
    Friend WithEvents lblSelFont As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FadingLabel1 As FadingLabelPanel
End Class
