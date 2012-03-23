<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UniCodeSearch
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSearch = New MyControls.GButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.bIDs = New MyControls.OnOffInputControlSmall
        Me.bNames = New MyControls.OnOffInputControlSmall
        Me.bSimilar = New MyControls.OnOffInputControlSmall
        Me.bNotes = New MyControls.OnOffInputControlSmall
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.recCount = New System.Windows.Forms.Label
        Me.sCount = New System.Windows.Forms.Label
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
        Me.selCPName.Text = "Search Results"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
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
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(845, 325)
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
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Yellow
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Quick Help"
        '
        'btnSearch
        '
        Me.btnSearch.BeginColor = System.Drawing.SystemColors.Control
        Me.btnSearch.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnSearch.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSearch.Location = New System.Drawing.Point(717, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(99, 31)
        Me.btnSearch.TabIndex = 21
        Me.btnSearch.Text = "Search"
        Me.ToolTip1.SetToolTip(Me.btnSearch, "start Search")
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Lucida Console", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(16, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(695, 31)
        Me.txtSearch.TabIndex = 20
        '
        'bIDs
        '
        Me.bIDs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.bIDs.BackColor = System.Drawing.Color.Transparent
        Me.bIDs.Checked = True
        Me.bIDs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bIDs.EnableTabstops = False
        Me.bIDs.Label = ""
        Me.bIDs.LabelFont = New System.Drawing.Font("Lucida Console", 7.3!, System.Drawing.FontStyle.Bold)
        Me.bIDs.LabelFontSizeFixed = True
        Me.bIDs.LabelForeColor = System.Drawing.Color.Yellow
        Me.bIDs.LabelShow = False
        Me.bIDs.Location = New System.Drawing.Point(58, 46)
        Me.bIDs.Margin = New System.Windows.Forms.Padding(0)
        Me.bIDs.Name = "bIDs"
        Me.bIDs.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bIDs.OffClickBack = System.Drawing.Color.Maroon
        Me.bIDs.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bIDs.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bIDs.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.bIDs.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bIDs.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bIDs.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bIDs.RadioBorderColor = System.Drawing.Color.Black
        Me.bIDs.RadioBorderWidth = 1
        Me.bIDs.RadioForeColorChecked = System.Drawing.Color.White
        Me.bIDs.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.bIDs.Size = New System.Drawing.Size(94, 25)
        Me.bIDs.TabIndex = 22
        '
        'bNames
        '
        Me.bNames.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.bNames.BackColor = System.Drawing.Color.Transparent
        Me.bNames.Checked = True
        Me.bNames.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bNames.EnableTabstops = False
        Me.bNames.Label = ""
        Me.bNames.LabelFont = New System.Drawing.Font("Lucida Console", 7.3!, System.Drawing.FontStyle.Bold)
        Me.bNames.LabelFontSizeFixed = True
        Me.bNames.LabelForeColor = System.Drawing.Color.Yellow
        Me.bNames.LabelShow = False
        Me.bNames.Location = New System.Drawing.Point(285, 46)
        Me.bNames.Margin = New System.Windows.Forms.Padding(0)
        Me.bNames.Name = "bNames"
        Me.bNames.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bNames.OffClickBack = System.Drawing.Color.Maroon
        Me.bNames.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bNames.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bNames.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.bNames.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bNames.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bNames.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bNames.RadioBorderColor = System.Drawing.Color.Black
        Me.bNames.RadioBorderWidth = 1
        Me.bNames.RadioForeColorChecked = System.Drawing.Color.White
        Me.bNames.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.bNames.Size = New System.Drawing.Size(94, 25)
        Me.bNames.TabIndex = 23
        '
        'bSimilar
        '
        Me.bSimilar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.bSimilar.BackColor = System.Drawing.Color.Transparent
        Me.bSimilar.Checked = False
        Me.bSimilar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bSimilar.EnableTabstops = False
        Me.bSimilar.Label = ""
        Me.bSimilar.LabelFont = New System.Drawing.Font("Lucida Console", 7.3!, System.Drawing.FontStyle.Bold)
        Me.bSimilar.LabelFontSizeFixed = True
        Me.bSimilar.LabelForeColor = System.Drawing.Color.Yellow
        Me.bSimilar.LabelShow = False
        Me.bSimilar.Location = New System.Drawing.Point(451, 45)
        Me.bSimilar.Margin = New System.Windows.Forms.Padding(0)
        Me.bSimilar.Name = "bSimilar"
        Me.bSimilar.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bSimilar.OffClickBack = System.Drawing.Color.Maroon
        Me.bSimilar.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bSimilar.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bSimilar.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.bSimilar.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bSimilar.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bSimilar.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bSimilar.RadioBorderColor = System.Drawing.Color.Black
        Me.bSimilar.RadioBorderWidth = 1
        Me.bSimilar.RadioForeColorChecked = System.Drawing.Color.White
        Me.bSimilar.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.bSimilar.Size = New System.Drawing.Size(94, 25)
        Me.bSimilar.TabIndex = 24
        '
        'bNotes
        '
        Me.bNotes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.bNotes.BackColor = System.Drawing.Color.Transparent
        Me.bNotes.Checked = False
        Me.bNotes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bNotes.EnableTabstops = False
        Me.bNotes.Label = ""
        Me.bNotes.LabelFont = New System.Drawing.Font("Lucida Console", 7.3!, System.Drawing.FontStyle.Bold)
        Me.bNotes.LabelFontSizeFixed = True
        Me.bNotes.LabelForeColor = System.Drawing.Color.Yellow
        Me.bNotes.LabelShow = False
        Me.bNotes.Location = New System.Drawing.Point(617, 46)
        Me.bNotes.Margin = New System.Windows.Forms.Padding(0)
        Me.bNotes.Name = "bNotes"
        Me.bNotes.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bNotes.OffClickBack = System.Drawing.Color.Maroon
        Me.bNotes.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bNotes.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bNotes.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.bNotes.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bNotes.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bNotes.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bNotes.RadioBorderColor = System.Drawing.Color.Black
        Me.bNotes.RadioBorderWidth = 1
        Me.bNotes.RadioForeColorChecked = System.Drawing.Color.White
        Me.bNotes.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.bNotes.Size = New System.Drawing.Size(94, 25)
        Me.bNotes.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(553, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Notes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(394, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Similar:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(192, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 18)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Names && Aliases:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(12, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 18)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "IDs:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(714, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 18)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Record Count:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'recCount
        '
        Me.recCount.BackColor = System.Drawing.Color.Transparent
        Me.recCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.recCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.recCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.recCount.ForeColor = System.Drawing.Color.Yellow
        Me.recCount.Location = New System.Drawing.Point(802, 53)
        Me.recCount.Name = "recCount"
        Me.recCount.Size = New System.Drawing.Size(55, 18)
        Me.recCount.TabIndex = 31
        Me.recCount.Text = "0"
        Me.recCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sCount
        '
        Me.sCount.BackColor = System.Drawing.Color.Transparent
        Me.sCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.sCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sCount.ForeColor = System.Drawing.Color.Yellow
        Me.sCount.Location = New System.Drawing.Point(165, 77)
        Me.sCount.Name = "sCount"
        Me.sCount.Size = New System.Drawing.Size(55, 18)
        Me.sCount.TabIndex = 32
        Me.sCount.Text = "0"
        Me.sCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UniCodeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(869, 466)
        Me.Controls.Add(Me.sCount)
        Me.Controls.Add(Me.recCount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bNotes)
        Me.Controls.Add(Me.bSimilar)
        Me.Controls.Add(Me.bIDs)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSelFont)
        Me.Controls.Add(Me.btnSelfont)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.selCPName)
        Me.Controls.Add(Me.bNames)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Name = "UniCodeSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "UniCode Search"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents selCPName As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As MyControls.GButton
    Friend WithEvents lblSelFont As System.Windows.Forms.Label
    Friend WithEvents btnSelfont As MyControls.GButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As MyControls.GButton
    Friend WithEvents bIDs As MyControls.OnOffInputControlSmall
    Friend WithEvents bNames As MyControls.OnOffInputControlSmall
    Friend WithEvents bSimilar As MyControls.OnOffInputControlSmall
    Friend WithEvents bNotes As MyControls.OnOffInputControlSmall
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents recCount As System.Windows.Forms.Label
    Friend WithEvents sCount As System.Windows.Forms.Label
End Class
