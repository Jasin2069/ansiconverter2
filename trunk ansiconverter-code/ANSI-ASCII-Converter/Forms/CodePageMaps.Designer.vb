<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodePageMaps
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
        Me.components = New System.ComponentModel.Container
        Me.selCPName = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnClose = New MyControls.GButton
        Me.lblSelFont = New System.Windows.Forms.Label
        Me.btnSelfont = New MyControls.GButton
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.listCPnew = New System.Windows.Forms.ComboBox
        Me.lblselectacp = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ScrollBar1 = New ANSI_ASCII_Converter.ScrollBar
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'selCPName
        '
        Me.selCPName.BackColor = System.Drawing.Color.Transparent
        Me.selCPName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selCPName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.selCPName.Location = New System.Drawing.Point(12, 77)
        Me.selCPName.Name = "selCPName"
        Me.selCPName.Size = New System.Drawing.Size(633, 25)
        Me.selCPName.TabIndex = 1
        Me.selCPName.Text = "Selected Code Page"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DataGridView1.CausesValidation = False
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 105)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(820, 325)
        Me.DataGridView1.TabIndex = 2
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
        Me.btnClose.Location = New System.Drawing.Point(708, 435)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(149, 28)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.btnClose, "list code page " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "list and return " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to converter")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblSelFont
        '
        Me.lblSelFont.BackColor = System.Drawing.Color.Transparent
        Me.lblSelFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSelFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSelFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelFont.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSelFont.Location = New System.Drawing.Point(13, 440)
        Me.lblSelFont.Name = "lblSelFont"
        Me.lblSelFont.Size = New System.Drawing.Size(219, 19)
        Me.lblSelFont.TabIndex = 14
        Me.lblSelFont.Text = "Font Name"
        Me.ToolTip1.SetToolTip(Me.lblSelFont, "Name of the currently " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected font for the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "display of the character" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sets. Yo" & _
                "u can change it!")
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
        Me.btnSelfont.Location = New System.Drawing.Point(244, 435)
        Me.btnSelfont.Name = "btnSelfont"
        Me.btnSelfont.Size = New System.Drawing.Size(113, 28)
        Me.btnSelfont.TabIndex = 13
        Me.btnSelfont.Text = "Select Font"
        Me.btnSelfont.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnSelfont, "Select a different font")
        Me.btnSelfont.UseVisualStyleBackColor = True
        '
        'FontDialog1
        '
        Me.FontDialog1.FixedPitchOnly = True
        Me.FontDialog1.FontMustExist = True
        '
        'listCPnew
        '
        Me.listCPnew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listCPnew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.listCPnew.Font = New System.Drawing.Font("Lucida Console", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listCPnew.FormattingEnabled = True
        Me.listCPnew.Location = New System.Drawing.Point(12, 32)
        Me.listCPnew.MaxDropDownItems = 10
        Me.listCPnew.Name = "listCPnew"
        Me.listCPnew.Size = New System.Drawing.Size(845, 24)
        Me.listCPnew.TabIndex = 15
        '
        'lblselectacp
        '
        Me.lblselectacp.BackColor = System.Drawing.Color.Transparent
        Me.lblselectacp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblselectacp.ForeColor = System.Drawing.Color.Gold
        Me.lblselectacp.Location = New System.Drawing.Point(13, 9)
        Me.lblselectacp.Name = "lblselectacp"
        Me.lblselectacp.Size = New System.Drawing.Size(298, 19)
        Me.lblselectacp.TabIndex = 16
        Me.lblselectacp.Text = "Select a Code Page from the List below"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Yellow
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Quick Help"
        '
        'ScrollBar1
        '
        Me.ScrollBar1.Location = New System.Drawing.Point(830, 103)
        Me.ScrollBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.ScrollBar1.Name = "ScrollBar1"
        Me.ScrollBar1.Size = New System.Drawing.Size(24, 327)
        Me.ScrollBar1.TabIndex = 19
        Me.ScrollBar1.Text = "ScrollBar1"
        '
        'CodePageMaps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(869, 466)
        Me.Controls.Add(Me.ScrollBar1)
        Me.Controls.Add(Me.lblselectacp)
        Me.Controls.Add(Me.listCPnew)
        Me.Controls.Add(Me.lblSelFont)
        Me.Controls.Add(Me.btnSelfont)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.selCPName)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Name = "CodePageMaps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Code Page Maps"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents selCPName As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As MyControls.GButton
    Friend WithEvents lblSelFont As System.Windows.Forms.Label
    Friend WithEvents btnSelfont As MyControls.GButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents listCPnew As System.Windows.Forms.ComboBox
    Friend WithEvents lblselectacp As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ScrollBar1 As ANSI_ASCII_Converter.ScrollBar
End Class
