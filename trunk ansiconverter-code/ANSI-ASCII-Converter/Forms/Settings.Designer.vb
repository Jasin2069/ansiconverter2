<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.btnClose = New MyControls.GButton
        Me.pThumbs = New System.Windows.Forms.Panel
        Me.lblTHumbs = New System.Windows.Forms.Label
        Me.lblPropPercent = New System.Windows.Forms.Label
        Me.ThumbHeight = New System.Windows.Forms.TextBox
        Me.ThumbWidth = New System.Windows.Forms.TextBox
        Me.ThumbScalePercent = New System.Windows.Forms.TextBox
        Me.selThumbProp = New System.Windows.Forms.RadioButton
        Me.lblScaleSize = New System.Windows.Forms.Label
        Me.selThumbCustom = New System.Windows.Forms.RadioButton
        Me.selThumbHFixed = New System.Windows.Forms.RadioButton
        Me.selThumbWFixed = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pGen = New System.Windows.Forms.Panel
        Me.bRemoveCompleted = New MyControls.OnOffInputControlSmall
        Me.lblRemComplete = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblUTFOut = New System.Windows.Forms.Label
        Me.pUTF = New System.Windows.Forms.Panel
        Me.rUTF16 = New System.Windows.Forms.RadioButton
        Me.rUTF8 = New System.Windows.Forms.RadioButton
        Me.pSettHTML = New System.Windows.Forms.Panel
        Me.pHTMLFont = New System.Windows.Forms.Panel
        Me.lblHTMLFont = New System.Windows.Forms.Label
        Me.cbHTMLFont = New System.Windows.Forms.ComboBox
        Me.pSanitize = New System.Windows.Forms.Panel
        Me.Sanitize = New MyControls.OnOffInputControlSmall
        Me.lblSanitize = New System.Windows.Forms.Label
        Me.pAnim = New System.Windows.Forms.Panel
        Me.rStatic = New System.Windows.Forms.RadioButton
        Me.rAnim = New System.Windows.Forms.RadioButton
        Me.pHTMLObj = New System.Windows.Forms.Panel
        Me.rObjectOnly = New System.Windows.Forms.RadioButton
        Me.rCompleteHTML = New System.Windows.Forms.RadioButton
        Me.lblHTMLOut = New System.Windows.Forms.Label
        Me.pSettImage = New System.Windows.Forms.Panel
        Me.pIMGOut = New System.Windows.Forms.Panel
        Me.rEMF = New System.Windows.Forms.RadioButton
        Me.rWMF = New System.Windows.Forms.RadioButton
        Me.rICO = New System.Windows.Forms.RadioButton
        Me.rTIF = New System.Windows.Forms.RadioButton
        Me.rJPG = New System.Windows.Forms.RadioButton
        Me.rGIF = New System.Windows.Forms.RadioButton
        Me.rBMP = New System.Windows.Forms.RadioButton
        Me.rPNG = New System.Windows.Forms.RadioButton
        Me.pThumb = New System.Windows.Forms.Panel
        Me.Thumb = New MyControls.OnOffInputControlSmall
        Me.lblThumb = New System.Windows.Forms.Label
        Me.pSmallFnt = New System.Windows.Forms.Panel
        Me.SmallFnt = New MyControls.OnOffInputControlSmall
        Me.lblSmallFnt = New System.Windows.Forms.Label
        Me.pNoCols = New System.Windows.Forms.Panel
        Me.NoCols = New MyControls.OnOffInputControlSmall
        Me.lblNoCols = New System.Windows.Forms.Label
        Me.lblImgFormat = New System.Windows.Forms.Label
        Me.lblImageOutputs = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.btnSelfont = New MyControls.GButton
        Me.lblSelFont = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.pGeneral = New System.Windows.Forms.Panel
        Me.pExt = New System.Windows.Forms.Panel
        Me.rReplaceExt = New System.Windows.Forms.RadioButton
        Me.rExtraExt = New System.Windows.Forms.RadioButton
        Me.lblExtension = New System.Windows.Forms.Label
        Me.pOutExist = New System.Windows.Forms.Panel
        Me.lblOutputExists = New System.Windows.Forms.Label
        Me.rOver = New System.Windows.Forms.RadioButton
        Me.rSkip = New System.Windows.Forms.RadioButton
        Me.rAutoRen = New System.Windows.Forms.RadioButton
        Me.rAsk = New System.Windows.Forms.RadioButton
        Me.pSauce = New System.Windows.Forms.Panel
        Me.rSauceStrip = New System.Windows.Forms.RadioButton
        Me.lblSauce = New System.Windows.Forms.Label
        Me.rSauceKeep = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pVideo = New System.Windows.Forms.Panel
        Me.lblBPS = New System.Windows.Forms.Label
        Me.lblVideoPanel = New System.Windows.Forms.Label
        Me.lblFPS = New System.Windows.Forms.Label
        Me.txtBPS = New System.Windows.Forms.TextBox
        Me.txtFPS = New System.Windows.Forms.TextBox
        Me.pVideoOutFormats = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.pVidFmts = New System.Windows.Forms.Panel
        Me.rVOB = New System.Windows.Forms.RadioButton
        Me.rMPG = New System.Windows.Forms.RadioButton
        Me.rMKV = New System.Windows.Forms.RadioButton
        Me.rMP4 = New System.Windows.Forms.RadioButton
        Me.rFLV = New System.Windows.Forms.RadioButton
        Me.rAGIF = New System.Windows.Forms.RadioButton
        Me.rWMV = New System.Windows.Forms.RadioButton
        Me.rAVI = New System.Windows.Forms.RadioButton
        Me.pAVICodec = New System.Windows.Forms.Panel
        Me.lblAVICodec = New System.Windows.Forms.Label
        Me.rFFVI = New System.Windows.Forms.RadioButton
        Me.rLIBXVID = New System.Windows.Forms.RadioButton
        Me.rMJPEG = New System.Windows.Forms.RadioButton
        Me.rH264 = New System.Windows.Forms.RadioButton
        Me.rLIBX264 = New System.Windows.Forms.RadioButton
        Me.rMPEG4 = New System.Windows.Forms.RadioButton
        Me.rZMBV = New System.Windows.Forms.RadioButton
        Me.pMPGCodec = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.rMPEG2 = New System.Windows.Forms.RadioButton
        Me.rMPEG1 = New System.Windows.Forms.RadioButton
        Me.pLFrame = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblFExtend = New System.Windows.Forms.Label
        Me.txtLastFrame = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.pBBS = New System.Windows.Forms.Panel
        Me.rWildcat3 = New System.Windows.Forms.RadioButton
        Me.rWildcat2 = New System.Windows.Forms.RadioButton
        Me.rAvatar = New System.Windows.Forms.RadioButton
        Me.rPCBoard = New System.Windows.Forms.RadioButton
        Me.lblBBSFormats = New System.Windows.Forms.Label
        Me.pThumbs.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pGen.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pUTF.SuspendLayout()
        Me.pSettHTML.SuspendLayout()
        Me.pHTMLFont.SuspendLayout()
        Me.pSanitize.SuspendLayout()
        Me.pAnim.SuspendLayout()
        Me.pHTMLObj.SuspendLayout()
        Me.pSettImage.SuspendLayout()
        Me.pIMGOut.SuspendLayout()
        Me.pThumb.SuspendLayout()
        Me.pSmallFnt.SuspendLayout()
        Me.pNoCols.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pGeneral.SuspendLayout()
        Me.pExt.SuspendLayout()
        Me.pOutExist.SuspendLayout()
        Me.pSauce.SuspendLayout()
        Me.pVideo.SuspendLayout()
        Me.pVideoOutFormats.SuspendLayout()
        Me.pVidFmts.SuspendLayout()
        Me.pAVICodec.SuspendLayout()
        Me.pMPGCodec.SuspendLayout()
        Me.pLFrame.SuspendLayout()
        Me.pBBS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BeginColor = System.Drawing.Color.Lime
        Me.btnClose.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnClose.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Cornsilk
        Me.btnClose.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnClose.Location = New System.Drawing.Point(560, 397)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(202, 55)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Back"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pThumbs
        '
        Me.pThumbs.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pThumbs.Controls.Add(Me.lblTHumbs)
        Me.pThumbs.Controls.Add(Me.lblPropPercent)
        Me.pThumbs.Controls.Add(Me.ThumbHeight)
        Me.pThumbs.Controls.Add(Me.ThumbWidth)
        Me.pThumbs.Controls.Add(Me.ThumbScalePercent)
        Me.pThumbs.Controls.Add(Me.selThumbProp)
        Me.pThumbs.Controls.Add(Me.lblScaleSize)
        Me.pThumbs.Controls.Add(Me.selThumbCustom)
        Me.pThumbs.Controls.Add(Me.selThumbHFixed)
        Me.pThumbs.Controls.Add(Me.selThumbWFixed)
        Me.pThumbs.Location = New System.Drawing.Point(47, 130)
        Me.pThumbs.Name = "pThumbs"
        Me.pThumbs.Size = New System.Drawing.Size(345, 90)
        Me.pThumbs.TabIndex = 63
        Me.pThumbs.Tag = "0"
        '
        'lblTHumbs
        '
        Me.lblTHumbs.BackColor = System.Drawing.Color.Transparent
        Me.lblTHumbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTHumbs.ForeColor = System.Drawing.Color.Yellow
        Me.lblTHumbs.Location = New System.Drawing.Point(-5, 8)
        Me.lblTHumbs.Name = "lblTHumbs"
        Me.lblTHumbs.Size = New System.Drawing.Size(116, 20)
        Me.lblTHumbs.TabIndex = 63
        Me.lblTHumbs.Text = "Thumbnails"
        Me.lblTHumbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTHumbs.UseCompatibleTextRendering = True
        '
        'lblPropPercent
        '
        Me.lblPropPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblPropPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropPercent.ForeColor = System.Drawing.Color.White
        Me.lblPropPercent.Location = New System.Drawing.Point(77, 62)
        Me.lblPropPercent.Name = "lblPropPercent"
        Me.lblPropPercent.Size = New System.Drawing.Size(15, 20)
        Me.lblPropPercent.TabIndex = 17
        Me.lblPropPercent.Text = "%"
        Me.lblPropPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPropPercent.UseCompatibleTextRendering = True
        '
        'ThumbHeight
        '
        Me.ThumbHeight.Enabled = False
        Me.ThumbHeight.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThumbHeight.Location = New System.Drawing.Point(183, 60)
        Me.ThumbHeight.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.ThumbHeight.MaximumSize = New System.Drawing.Size(65, 20)
        Me.ThumbHeight.Name = "ThumbHeight"
        Me.ThumbHeight.Size = New System.Drawing.Size(64, 20)
        Me.ThumbHeight.TabIndex = 16
        Me.ThumbHeight.Text = "100"
        Me.ThumbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ThumbWidth
        '
        Me.ThumbWidth.Enabled = False
        Me.ThumbWidth.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThumbWidth.Location = New System.Drawing.Point(113, 60)
        Me.ThumbWidth.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.ThumbWidth.MaximumSize = New System.Drawing.Size(65, 20)
        Me.ThumbWidth.Name = "ThumbWidth"
        Me.ThumbWidth.Size = New System.Drawing.Size(55, 20)
        Me.ThumbWidth.TabIndex = 15
        Me.ThumbWidth.Text = "150"
        Me.ThumbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ThumbScalePercent
        '
        Me.ThumbScalePercent.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThumbScalePercent.Location = New System.Drawing.Point(19, 63)
        Me.ThumbScalePercent.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.ThumbScalePercent.MaximumSize = New System.Drawing.Size(65, 20)
        Me.ThumbScalePercent.Name = "ThumbScalePercent"
        Me.ThumbScalePercent.Size = New System.Drawing.Size(55, 20)
        Me.ThumbScalePercent.TabIndex = 14
        Me.ThumbScalePercent.Text = "50"
        Me.ThumbScalePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'selThumbProp
        '
        Me.selThumbProp.Appearance = System.Windows.Forms.Appearance.Button
        Me.selThumbProp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.selThumbProp.Checked = True
        Me.selThumbProp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selThumbProp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.selThumbProp.FlatAppearance.BorderSize = 2
        Me.selThumbProp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selThumbProp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.selThumbProp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.selThumbProp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selThumbProp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selThumbProp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.selThumbProp.Location = New System.Drawing.Point(19, 32)
        Me.selThumbProp.Name = "selThumbProp"
        Me.selThumbProp.Size = New System.Drawing.Size(66, 24)
        Me.selThumbProp.TabIndex = 0
        Me.selThumbProp.TabStop = True
        Me.selThumbProp.Tag = "0"
        Me.selThumbProp.Text = "PROP"
        Me.selThumbProp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.selThumbProp.UseCompatibleTextRendering = True
        Me.selThumbProp.UseVisualStyleBackColor = False
        '
        'lblScaleSize
        '
        Me.lblScaleSize.BackColor = System.Drawing.Color.Transparent
        Me.lblScaleSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScaleSize.ForeColor = System.Drawing.Color.White
        Me.lblScaleSize.Location = New System.Drawing.Point(110, 8)
        Me.lblScaleSize.Name = "lblScaleSize"
        Me.lblScaleSize.Size = New System.Drawing.Size(83, 20)
        Me.lblScaleSize.TabIndex = 11
        Me.lblScaleSize.Text = "Scale / Size"
        Me.lblScaleSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblScaleSize.UseCompatibleTextRendering = True
        '
        'selThumbCustom
        '
        Me.selThumbCustom.Appearance = System.Windows.Forms.Appearance.Button
        Me.selThumbCustom.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.selThumbCustom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selThumbCustom.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.selThumbCustom.FlatAppearance.BorderSize = 2
        Me.selThumbCustom.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selThumbCustom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.selThumbCustom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.selThumbCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selThumbCustom.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.selThumbCustom.Location = New System.Drawing.Point(262, 58)
        Me.selThumbCustom.Name = "selThumbCustom"
        Me.selThumbCustom.Size = New System.Drawing.Size(69, 24)
        Me.selThumbCustom.TabIndex = 3
        Me.selThumbCustom.Tag = "3"
        Me.selThumbCustom.Text = "CUSTOM"
        Me.selThumbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.selThumbCustom.UseCompatibleTextRendering = True
        Me.selThumbCustom.UseVisualStyleBackColor = False
        '
        'selThumbHFixed
        '
        Me.selThumbHFixed.Appearance = System.Windows.Forms.Appearance.Button
        Me.selThumbHFixed.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.selThumbHFixed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selThumbHFixed.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.selThumbHFixed.FlatAppearance.BorderSize = 2
        Me.selThumbHFixed.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selThumbHFixed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.selThumbHFixed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.selThumbHFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selThumbHFixed.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.selThumbHFixed.Location = New System.Drawing.Point(181, 32)
        Me.selThumbHFixed.Name = "selThumbHFixed"
        Me.selThumbHFixed.Size = New System.Drawing.Size(66, 24)
        Me.selThumbHFixed.TabIndex = 2
        Me.selThumbHFixed.Tag = "2"
        Me.selThumbHFixed.Text = "HEIGHT"
        Me.selThumbHFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.selThumbHFixed.UseCompatibleTextRendering = True
        Me.selThumbHFixed.UseVisualStyleBackColor = False
        '
        'selThumbWFixed
        '
        Me.selThumbWFixed.Appearance = System.Windows.Forms.Appearance.Button
        Me.selThumbWFixed.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.selThumbWFixed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.selThumbWFixed.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.selThumbWFixed.FlatAppearance.BorderSize = 2
        Me.selThumbWFixed.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.selThumbWFixed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.selThumbWFixed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.selThumbWFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.selThumbWFixed.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.selThumbWFixed.Location = New System.Drawing.Point(114, 32)
        Me.selThumbWFixed.Name = "selThumbWFixed"
        Me.selThumbWFixed.Size = New System.Drawing.Size(55, 24)
        Me.selThumbWFixed.TabIndex = 1
        Me.selThumbWFixed.Tag = "1"
        Me.selThumbWFixed.Text = "WIDTH"
        Me.selThumbWFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.selThumbWFixed.UseCompatibleTextRendering = True
        Me.selThumbWFixed.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel2.Controls.Add(Me.pGen)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(150, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(261, 55)
        Me.Panel2.TabIndex = 64
        Me.Panel2.Tag = "0"
        '
        'pGen
        '
        Me.pGen.BackColor = System.Drawing.Color.Transparent
        Me.pGen.Controls.Add(Me.bRemoveCompleted)
        Me.pGen.Controls.Add(Me.lblRemComplete)
        Me.pGen.Location = New System.Drawing.Point(0, 20)
        Me.pGen.Name = "pGen"
        Me.pGen.Size = New System.Drawing.Size(258, 30)
        Me.pGen.TabIndex = 75
        Me.pGen.Tag = "lblRemComplete"
        '
        'bRemoveCompleted
        '
        Me.bRemoveCompleted.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.bRemoveCompleted.BackColor = System.Drawing.Color.Transparent
        Me.bRemoveCompleted.Checked = True
        Me.bRemoveCompleted.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bRemoveCompleted.EnableTabstops = False
        Me.bRemoveCompleted.Label = ""
        Me.bRemoveCompleted.LabelFont = New System.Drawing.Font("Lucida Console", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRemoveCompleted.LabelForeColor = System.Drawing.Color.Yellow
        Me.bRemoveCompleted.LabelShow = False
        Me.bRemoveCompleted.Location = New System.Drawing.Point(154, 4)
        Me.bRemoveCompleted.Margin = New System.Windows.Forms.Padding(0)
        Me.bRemoveCompleted.Name = "bRemoveCompleted"
        Me.bRemoveCompleted.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bRemoveCompleted.OffClickBack = System.Drawing.Color.Maroon
        Me.bRemoveCompleted.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bRemoveCompleted.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bRemoveCompleted.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.bRemoveCompleted.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bRemoveCompleted.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.bRemoveCompleted.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.bRemoveCompleted.RadioBorderColor = System.Drawing.Color.Black
        Me.bRemoveCompleted.RadioBorderWidth = 2
        Me.bRemoveCompleted.RadioForeColorChecked = System.Drawing.Color.White
        Me.bRemoveCompleted.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.bRemoveCompleted.Size = New System.Drawing.Size(94, 24)
        Me.bRemoveCompleted.TabIndex = 73
        '
        'lblRemComplete
        '
        Me.lblRemComplete.AutoSize = True
        Me.lblRemComplete.BackColor = System.Drawing.Color.Transparent
        Me.lblRemComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemComplete.ForeColor = System.Drawing.Color.White
        Me.lblRemComplete.Location = New System.Drawing.Point(0, 7)
        Me.lblRemComplete.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRemComplete.Name = "lblRemComplete"
        Me.lblRemComplete.Size = New System.Drawing.Size(157, 19)
        Me.lblRemComplete.TabIndex = 72
        Me.lblRemComplete.Text = "  Auto-Remove Completed?"
        Me.lblRemComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRemComplete.UseCompatibleTextRendering = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(0, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Input File List"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label7.UseCompatibleTextRendering = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblUTFOut)
        Me.Panel3.Controls.Add(Me.pUTF)
        Me.Panel3.Location = New System.Drawing.Point(417, 387)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(132, 67)
        Me.Panel3.TabIndex = 75
        Me.Panel3.Tag = "0"
        '
        'lblUTFOut
        '
        Me.lblUTFOut.BackColor = System.Drawing.Color.Transparent
        Me.lblUTFOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTFOut.ForeColor = System.Drawing.Color.Yellow
        Me.lblUTFOut.Location = New System.Drawing.Point(5, 8)
        Me.lblUTFOut.Name = "lblUTFOut"
        Me.lblUTFOut.Size = New System.Drawing.Size(126, 20)
        Me.lblUTFOut.TabIndex = 56
        Me.lblUTFOut.Text = "Unicode Outputs"
        '
        'pUTF
        '
        Me.pUTF.BackColor = System.Drawing.Color.Transparent
        Me.pUTF.Controls.Add(Me.rUTF16)
        Me.pUTF.Controls.Add(Me.rUTF8)
        Me.pUTF.Location = New System.Drawing.Point(5, 31)
        Me.pUTF.Name = "pUTF"
        Me.pUTF.Size = New System.Drawing.Size(127, 27)
        Me.pUTF.TabIndex = 55
        Me.pUTF.Tag = "UTF-16"
        '
        'rUTF16
        '
        Me.rUTF16.Appearance = System.Windows.Forms.Appearance.Button
        Me.rUTF16.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rUTF16.Checked = True
        Me.rUTF16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rUTF16.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rUTF16.FlatAppearance.BorderSize = 2
        Me.rUTF16.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rUTF16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rUTF16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rUTF16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rUTF16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rUTF16.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rUTF16.Location = New System.Drawing.Point(62, 3)
        Me.rUTF16.Name = "rUTF16"
        Me.rUTF16.Size = New System.Drawing.Size(60, 24)
        Me.rUTF16.TabIndex = 1
        Me.rUTF16.TabStop = True
        Me.rUTF16.Tag = "UTF-16"
        Me.rUTF16.Text = "UTF-16"
        Me.rUTF16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rUTF16.UseCompatibleTextRendering = True
        Me.rUTF16.UseVisualStyleBackColor = False
        '
        'rUTF8
        '
        Me.rUTF8.Appearance = System.Windows.Forms.Appearance.Button
        Me.rUTF8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rUTF8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rUTF8.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rUTF8.FlatAppearance.BorderSize = 2
        Me.rUTF8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rUTF8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rUTF8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rUTF8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rUTF8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rUTF8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rUTF8.Location = New System.Drawing.Point(3, 3)
        Me.rUTF8.Name = "rUTF8"
        Me.rUTF8.Size = New System.Drawing.Size(56, 24)
        Me.rUTF8.TabIndex = 0
        Me.rUTF8.Tag = "UTF-8"
        Me.rUTF8.Text = "UTF-8"
        Me.rUTF8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rUTF8.UseCompatibleTextRendering = True
        Me.rUTF8.UseVisualStyleBackColor = False
        '
        'pSettHTML
        '
        Me.pSettHTML.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pSettHTML.Controls.Add(Me.pHTMLFont)
        Me.pSettHTML.Controls.Add(Me.pSanitize)
        Me.pSettHTML.Controls.Add(Me.pAnim)
        Me.pSettHTML.Controls.Add(Me.pHTMLObj)
        Me.pSettHTML.Controls.Add(Me.lblHTMLOut)
        Me.pSettHTML.Location = New System.Drawing.Point(20, 226)
        Me.pSettHTML.Name = "pSettHTML"
        Me.pSettHTML.Size = New System.Drawing.Size(296, 134)
        Me.pSettHTML.TabIndex = 76
        Me.pSettHTML.Tag = "0"
        '
        'pHTMLFont
        '
        Me.pHTMLFont.BackColor = System.Drawing.Color.Transparent
        Me.pHTMLFont.Controls.Add(Me.lblHTMLFont)
        Me.pHTMLFont.Controls.Add(Me.cbHTMLFont)
        Me.pHTMLFont.Location = New System.Drawing.Point(4, 70)
        Me.pHTMLFont.Name = "pHTMLFont"
        Me.pHTMLFont.Size = New System.Drawing.Size(290, 24)
        Me.pHTMLFont.TabIndex = 61
        '
        'lblHTMLFont
        '
        Me.lblHTMLFont.BackColor = System.Drawing.Color.Transparent
        Me.lblHTMLFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHTMLFont.ForeColor = System.Drawing.Color.White
        Me.lblHTMLFont.Location = New System.Drawing.Point(3, 2)
        Me.lblHTMLFont.Name = "lblHTMLFont"
        Me.lblHTMLFont.Size = New System.Drawing.Size(70, 20)
        Me.lblHTMLFont.TabIndex = 61
        Me.lblHTMLFont.Text = "Web Font"
        Me.lblHTMLFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHTMLFont.UseCompatibleTextRendering = True
        '
        'cbHTMLFont
        '
        Me.cbHTMLFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbHTMLFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHTMLFont.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHTMLFont.Location = New System.Drawing.Point(78, 2)
        Me.cbHTMLFont.Name = "cbHTMLFont"
        Me.cbHTMLFont.Size = New System.Drawing.Size(205, 19)
        Me.cbHTMLFont.TabIndex = 60
        '
        'pSanitize
        '
        Me.pSanitize.BackColor = System.Drawing.Color.Transparent
        Me.pSanitize.Controls.Add(Me.Sanitize)
        Me.pSanitize.Controls.Add(Me.lblSanitize)
        Me.pSanitize.Location = New System.Drawing.Point(112, 100)
        Me.pSanitize.Name = "pSanitize"
        Me.pSanitize.Size = New System.Drawing.Size(135, 27)
        Me.pSanitize.TabIndex = 54
        Me.pSanitize.Tag = "lblSanitize"
        '
        'Sanitize
        '
        Me.Sanitize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Sanitize.BackColor = System.Drawing.Color.Transparent
        Me.Sanitize.ButtonsEqualSize = False
        Me.Sanitize.Checked = True
        Me.Sanitize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Sanitize.EnableTabstops = False
        Me.Sanitize.Label = ""
        Me.Sanitize.LabelFont = New System.Drawing.Font("Lucida Console", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sanitize.LabelForeColor = System.Drawing.Color.Yellow
        Me.Sanitize.LabelShow = False
        Me.Sanitize.Location = New System.Drawing.Point(50, 1)
        Me.Sanitize.Margin = New System.Windows.Forms.Padding(0)
        Me.Sanitize.Name = "Sanitize"
        Me.Sanitize.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Sanitize.OffClickBack = System.Drawing.Color.Maroon
        Me.Sanitize.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Sanitize.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Sanitize.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.Sanitize.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Sanitize.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Sanitize.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Sanitize.RadioBorderColor = System.Drawing.Color.Black
        Me.Sanitize.RadioBorderWidth = 2
        Me.Sanitize.RadioForeColorChecked = System.Drawing.Color.White
        Me.Sanitize.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.Sanitize.Size = New System.Drawing.Size(84, 24)
        Me.Sanitize.TabIndex = 11
        '
        'lblSanitize
        '
        Me.lblSanitize.AutoSize = True
        Me.lblSanitize.BackColor = System.Drawing.Color.Transparent
        Me.lblSanitize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSanitize.ForeColor = System.Drawing.Color.White
        Me.lblSanitize.Location = New System.Drawing.Point(0, 1)
        Me.lblSanitize.Margin = New System.Windows.Forms.Padding(0)
        Me.lblSanitize.Name = "lblSanitize"
        Me.lblSanitize.Size = New System.Drawing.Size(53, 20)
        Me.lblSanitize.TabIndex = 10
        Me.lblSanitize.Text = "Sanitize"
        Me.lblSanitize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSanitize.UseCompatibleTextRendering = True
        '
        'pAnim
        '
        Me.pAnim.BackColor = System.Drawing.Color.Transparent
        Me.pAnim.Controls.Add(Me.rStatic)
        Me.pAnim.Controls.Add(Me.rAnim)
        Me.pAnim.Location = New System.Drawing.Point(159, 35)
        Me.pAnim.Name = "pAnim"
        Me.pAnim.Size = New System.Drawing.Size(127, 27)
        Me.pAnim.TabIndex = 53
        Me.pAnim.Tag = "Static"
        '
        'rStatic
        '
        Me.rStatic.Appearance = System.Windows.Forms.Appearance.Button
        Me.rStatic.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rStatic.Checked = True
        Me.rStatic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rStatic.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rStatic.FlatAppearance.BorderSize = 2
        Me.rStatic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rStatic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rStatic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rStatic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rStatic.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rStatic.Location = New System.Drawing.Point(62, 3)
        Me.rStatic.Name = "rStatic"
        Me.rStatic.Size = New System.Drawing.Size(60, 24)
        Me.rStatic.TabIndex = 1
        Me.rStatic.TabStop = True
        Me.rStatic.Tag = "Static"
        Me.rStatic.Text = "Static"
        Me.rStatic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rStatic.UseCompatibleTextRendering = True
        Me.rStatic.UseVisualStyleBackColor = False
        '
        'rAnim
        '
        Me.rAnim.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAnim.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAnim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAnim.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAnim.FlatAppearance.BorderSize = 2
        Me.rAnim.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAnim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAnim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAnim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAnim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rAnim.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAnim.Location = New System.Drawing.Point(3, 3)
        Me.rAnim.Name = "rAnim"
        Me.rAnim.Size = New System.Drawing.Size(56, 24)
        Me.rAnim.TabIndex = 0
        Me.rAnim.Tag = "Anim"
        Me.rAnim.Text = "Anim"
        Me.rAnim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAnim.UseCompatibleTextRendering = True
        Me.rAnim.UseVisualStyleBackColor = False
        '
        'pHTMLObj
        '
        Me.pHTMLObj.BackColor = System.Drawing.Color.Transparent
        Me.pHTMLObj.Controls.Add(Me.rObjectOnly)
        Me.pHTMLObj.Controls.Add(Me.rCompleteHTML)
        Me.pHTMLObj.Location = New System.Drawing.Point(6, 35)
        Me.pHTMLObj.Name = "pHTMLObj"
        Me.pHTMLObj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pHTMLObj.Size = New System.Drawing.Size(132, 27)
        Me.pHTMLObj.TabIndex = 51
        Me.pHTMLObj.Tag = "COMPLETE"
        '
        'rObjectOnly
        '
        Me.rObjectOnly.Appearance = System.Windows.Forms.Appearance.Button
        Me.rObjectOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rObjectOnly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rObjectOnly.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rObjectOnly.FlatAppearance.BorderSize = 2
        Me.rObjectOnly.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rObjectOnly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rObjectOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rObjectOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rObjectOnly.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rObjectOnly.Location = New System.Drawing.Point(71, 3)
        Me.rObjectOnly.Name = "rObjectOnly"
        Me.rObjectOnly.Size = New System.Drawing.Size(57, 24)
        Me.rObjectOnly.TabIndex = 1
        Me.rObjectOnly.Tag = "OBJECT"
        Me.rObjectOnly.Text = "Object"
        Me.rObjectOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rObjectOnly.UseCompatibleTextRendering = True
        Me.rObjectOnly.UseVisualStyleBackColor = False
        '
        'rCompleteHTML
        '
        Me.rCompleteHTML.Appearance = System.Windows.Forms.Appearance.Button
        Me.rCompleteHTML.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rCompleteHTML.Checked = True
        Me.rCompleteHTML.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rCompleteHTML.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rCompleteHTML.FlatAppearance.BorderSize = 2
        Me.rCompleteHTML.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rCompleteHTML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rCompleteHTML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rCompleteHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rCompleteHTML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rCompleteHTML.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rCompleteHTML.Location = New System.Drawing.Point(3, 3)
        Me.rCompleteHTML.Name = "rCompleteHTML"
        Me.rCompleteHTML.Size = New System.Drawing.Size(66, 24)
        Me.rCompleteHTML.TabIndex = 0
        Me.rCompleteHTML.TabStop = True
        Me.rCompleteHTML.Tag = "COMPLETE"
        Me.rCompleteHTML.Text = "Complete"
        Me.rCompleteHTML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rCompleteHTML.UseCompatibleTextRendering = True
        Me.rCompleteHTML.UseVisualStyleBackColor = False
        '
        'lblHTMLOut
        '
        Me.lblHTMLOut.BackColor = System.Drawing.Color.Transparent
        Me.lblHTMLOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHTMLOut.ForeColor = System.Drawing.Color.Yellow
        Me.lblHTMLOut.Location = New System.Drawing.Point(3, 9)
        Me.lblHTMLOut.Name = "lblHTMLOut"
        Me.lblHTMLOut.Size = New System.Drawing.Size(124, 23)
        Me.lblHTMLOut.TabIndex = 6
        Me.lblHTMLOut.Text = "HTML Outputs"
        '
        'pSettImage
        '
        Me.pSettImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pSettImage.Controls.Add(Me.pIMGOut)
        Me.pSettImage.Controls.Add(Me.pThumb)
        Me.pSettImage.Controls.Add(Me.pSmallFnt)
        Me.pSettImage.Controls.Add(Me.pNoCols)
        Me.pSettImage.Controls.Add(Me.lblImgFormat)
        Me.pSettImage.Controls.Add(Me.lblImageOutputs)
        Me.pSettImage.Location = New System.Drawing.Point(12, 12)
        Me.pSettImage.Name = "pSettImage"
        Me.pSettImage.Size = New System.Drawing.Size(380, 122)
        Me.pSettImage.TabIndex = 77
        Me.pSettImage.Tag = "0"
        '
        'pIMGOut
        '
        Me.pIMGOut.BackColor = System.Drawing.Color.Transparent
        Me.pIMGOut.Controls.Add(Me.rEMF)
        Me.pIMGOut.Controls.Add(Me.rWMF)
        Me.pIMGOut.Controls.Add(Me.rICO)
        Me.pIMGOut.Controls.Add(Me.rTIF)
        Me.pIMGOut.Controls.Add(Me.rJPG)
        Me.pIMGOut.Controls.Add(Me.rGIF)
        Me.pIMGOut.Controls.Add(Me.rBMP)
        Me.pIMGOut.Controls.Add(Me.rPNG)
        Me.pIMGOut.Location = New System.Drawing.Point(220, 24)
        Me.pIMGOut.Name = "pIMGOut"
        Me.pIMGOut.Size = New System.Drawing.Size(150, 90)
        Me.pIMGOut.TabIndex = 68
        Me.pIMGOut.Tag = "PNG"
        '
        'rEMF
        '
        Me.rEMF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rEMF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rEMF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rEMF.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rEMF.FlatAppearance.BorderSize = 2
        Me.rEMF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rEMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rEMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rEMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rEMF.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rEMF.Location = New System.Drawing.Point(50, 62)
        Me.rEMF.Name = "rEMF"
        Me.rEMF.Size = New System.Drawing.Size(44, 24)
        Me.rEMF.TabIndex = 11
        Me.rEMF.Tag = "EMF"
        Me.rEMF.Text = "EMF"
        Me.rEMF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rEMF.UseCompatibleTextRendering = True
        Me.rEMF.UseVisualStyleBackColor = False
        '
        'rWMF
        '
        Me.rWMF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rWMF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rWMF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rWMF.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rWMF.FlatAppearance.BorderSize = 2
        Me.rWMF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rWMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rWMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rWMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rWMF.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rWMF.Location = New System.Drawing.Point(3, 62)
        Me.rWMF.Name = "rWMF"
        Me.rWMF.Size = New System.Drawing.Size(44, 24)
        Me.rWMF.TabIndex = 10
        Me.rWMF.Tag = "WMF"
        Me.rWMF.Text = "WMF"
        Me.rWMF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rWMF.UseCompatibleTextRendering = True
        Me.rWMF.UseVisualStyleBackColor = False
        '
        'rICO
        '
        Me.rICO.Appearance = System.Windows.Forms.Appearance.Button
        Me.rICO.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rICO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rICO.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rICO.FlatAppearance.BorderSize = 2
        Me.rICO.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rICO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rICO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rICO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rICO.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rICO.Location = New System.Drawing.Point(98, 32)
        Me.rICO.Name = "rICO"
        Me.rICO.Size = New System.Drawing.Size(44, 24)
        Me.rICO.TabIndex = 9
        Me.rICO.Tag = "ICO"
        Me.rICO.Text = "ICO"
        Me.rICO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rICO.UseCompatibleTextRendering = True
        Me.rICO.UseVisualStyleBackColor = False
        '
        'rTIF
        '
        Me.rTIF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rTIF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rTIF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rTIF.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rTIF.FlatAppearance.BorderSize = 2
        Me.rTIF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rTIF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rTIF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rTIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rTIF.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rTIF.Location = New System.Drawing.Point(50, 32)
        Me.rTIF.Name = "rTIF"
        Me.rTIF.Size = New System.Drawing.Size(44, 24)
        Me.rTIF.TabIndex = 8
        Me.rTIF.Tag = "TIF"
        Me.rTIF.Text = "TIF"
        Me.rTIF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rTIF.UseCompatibleTextRendering = True
        Me.rTIF.UseVisualStyleBackColor = False
        '
        'rJPG
        '
        Me.rJPG.Appearance = System.Windows.Forms.Appearance.Button
        Me.rJPG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rJPG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rJPG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rJPG.FlatAppearance.BorderSize = 2
        Me.rJPG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rJPG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rJPG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rJPG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rJPG.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rJPG.Location = New System.Drawing.Point(3, 32)
        Me.rJPG.Name = "rJPG"
        Me.rJPG.Size = New System.Drawing.Size(44, 24)
        Me.rJPG.TabIndex = 7
        Me.rJPG.Tag = "JPG"
        Me.rJPG.Text = "JPG"
        Me.rJPG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rJPG.UseCompatibleTextRendering = True
        Me.rJPG.UseVisualStyleBackColor = False
        '
        'rGIF
        '
        Me.rGIF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rGIF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rGIF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rGIF.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rGIF.FlatAppearance.BorderSize = 2
        Me.rGIF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rGIF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rGIF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rGIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rGIF.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rGIF.Location = New System.Drawing.Point(98, 2)
        Me.rGIF.Name = "rGIF"
        Me.rGIF.Size = New System.Drawing.Size(44, 24)
        Me.rGIF.TabIndex = 6
        Me.rGIF.Tag = "GIF"
        Me.rGIF.Text = "GIF"
        Me.rGIF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rGIF.UseCompatibleTextRendering = True
        Me.rGIF.UseVisualStyleBackColor = False
        '
        'rBMP
        '
        Me.rBMP.Appearance = System.Windows.Forms.Appearance.Button
        Me.rBMP.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rBMP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rBMP.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rBMP.FlatAppearance.BorderSize = 2
        Me.rBMP.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rBMP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rBMP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rBMP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rBMP.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rBMP.Location = New System.Drawing.Point(50, 2)
        Me.rBMP.Name = "rBMP"
        Me.rBMP.Size = New System.Drawing.Size(44, 24)
        Me.rBMP.TabIndex = 5
        Me.rBMP.Tag = "BMP"
        Me.rBMP.Text = "BMP"
        Me.rBMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rBMP.UseCompatibleTextRendering = True
        Me.rBMP.UseVisualStyleBackColor = False
        '
        'rPNG
        '
        Me.rPNG.Appearance = System.Windows.Forms.Appearance.Button
        Me.rPNG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rPNG.Checked = True
        Me.rPNG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rPNG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rPNG.FlatAppearance.BorderSize = 2
        Me.rPNG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rPNG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rPNG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rPNG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rPNG.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rPNG.Location = New System.Drawing.Point(2, 2)
        Me.rPNG.Name = "rPNG"
        Me.rPNG.Size = New System.Drawing.Size(44, 24)
        Me.rPNG.TabIndex = 4
        Me.rPNG.TabStop = True
        Me.rPNG.Tag = "PNG"
        Me.rPNG.Text = "PNG"
        Me.rPNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rPNG.UseCompatibleTextRendering = True
        Me.rPNG.UseVisualStyleBackColor = False
        '
        'pThumb
        '
        Me.pThumb.BackColor = System.Drawing.Color.Transparent
        Me.pThumb.Controls.Add(Me.Thumb)
        Me.pThumb.Controls.Add(Me.lblThumb)
        Me.pThumb.Location = New System.Drawing.Point(8, 93)
        Me.pThumb.Name = "pThumb"
        Me.pThumb.Size = New System.Drawing.Size(247, 27)
        Me.pThumb.TabIndex = 66
        Me.pThumb.Tag = "lblThumb"
        '
        'Thumb
        '
        Me.Thumb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Thumb.BackColor = System.Drawing.Color.Transparent
        Me.Thumb.ButtonsEqualSize = False
        Me.Thumb.Checked = False
        Me.Thumb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Thumb.EnableTabstops = False
        Me.Thumb.Label = ""
        Me.Thumb.LabelFont = New System.Drawing.Font("Lucida Console", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Thumb.LabelForeColor = System.Drawing.Color.Yellow
        Me.Thumb.LabelShow = False
        Me.Thumb.Location = New System.Drawing.Point(0, 0)
        Me.Thumb.Margin = New System.Windows.Forms.Padding(0)
        Me.Thumb.Name = "Thumb"
        Me.Thumb.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Thumb.OffClickBack = System.Drawing.Color.Maroon
        Me.Thumb.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Thumb.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Thumb.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.Thumb.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Thumb.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Thumb.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Thumb.Padding = New System.Windows.Forms.Padding(1)
        Me.Thumb.RadioBorderColor = System.Drawing.Color.Black
        Me.Thumb.RadioBorderWidth = 2
        Me.Thumb.RadioForeColorChecked = System.Drawing.Color.White
        Me.Thumb.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.Thumb.Size = New System.Drawing.Size(84, 24)
        Me.Thumb.TabIndex = 11
        '
        'lblThumb
        '
        Me.lblThumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThumb.ForeColor = System.Drawing.Color.White
        Me.lblThumb.Location = New System.Drawing.Point(89, 4)
        Me.lblThumb.Name = "lblThumb"
        Me.lblThumb.Size = New System.Drawing.Size(98, 23)
        Me.lblThumb.TabIndex = 10
        Me.lblThumb.Text = "Thumbnails?"
        Me.lblThumb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblThumb.UseCompatibleTextRendering = True
        '
        'pSmallFnt
        '
        Me.pSmallFnt.BackColor = System.Drawing.Color.Transparent
        Me.pSmallFnt.Controls.Add(Me.SmallFnt)
        Me.pSmallFnt.Controls.Add(Me.lblSmallFnt)
        Me.pSmallFnt.Location = New System.Drawing.Point(8, 60)
        Me.pSmallFnt.Name = "pSmallFnt"
        Me.pSmallFnt.Size = New System.Drawing.Size(247, 27)
        Me.pSmallFnt.TabIndex = 65
        Me.pSmallFnt.Tag = "lblSmallFnt"
        '
        'SmallFnt
        '
        Me.SmallFnt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SmallFnt.BackColor = System.Drawing.Color.Transparent
        Me.SmallFnt.ButtonsEqualSize = False
        Me.SmallFnt.Checked = False
        Me.SmallFnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SmallFnt.EnableTabstops = False
        Me.SmallFnt.Label = ""
        Me.SmallFnt.LabelFont = New System.Drawing.Font("Lucida Console", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SmallFnt.LabelForeColor = System.Drawing.Color.Yellow
        Me.SmallFnt.LabelShow = False
        Me.SmallFnt.Location = New System.Drawing.Point(0, 0)
        Me.SmallFnt.Margin = New System.Windows.Forms.Padding(0)
        Me.SmallFnt.Name = "SmallFnt"
        Me.SmallFnt.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SmallFnt.OffClickBack = System.Drawing.Color.Maroon
        Me.SmallFnt.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.SmallFnt.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.SmallFnt.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.SmallFnt.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SmallFnt.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.SmallFnt.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.SmallFnt.Padding = New System.Windows.Forms.Padding(1)
        Me.SmallFnt.RadioBorderColor = System.Drawing.Color.Black
        Me.SmallFnt.RadioBorderWidth = 2
        Me.SmallFnt.RadioForeColorChecked = System.Drawing.Color.White
        Me.SmallFnt.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.SmallFnt.Size = New System.Drawing.Size(84, 24)
        Me.SmallFnt.TabIndex = 11
        '
        'lblSmallFnt
        '
        Me.lblSmallFnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSmallFnt.ForeColor = System.Drawing.Color.White
        Me.lblSmallFnt.Location = New System.Drawing.Point(89, 7)
        Me.lblSmallFnt.Name = "lblSmallFnt"
        Me.lblSmallFnt.Size = New System.Drawing.Size(138, 23)
        Me.lblSmallFnt.TabIndex = 10
        Me.lblSmallFnt.Text = "80x50 Lines Mode?"
        Me.lblSmallFnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSmallFnt.UseCompatibleTextRendering = True
        '
        'pNoCols
        '
        Me.pNoCols.BackColor = System.Drawing.Color.Transparent
        Me.pNoCols.Controls.Add(Me.NoCols)
        Me.pNoCols.Controls.Add(Me.lblNoCols)
        Me.pNoCols.Location = New System.Drawing.Point(7, 27)
        Me.pNoCols.Name = "pNoCols"
        Me.pNoCols.Size = New System.Drawing.Size(248, 27)
        Me.pNoCols.TabIndex = 64
        Me.pNoCols.Tag = "lblNoCols"
        '
        'NoCols
        '
        Me.NoCols.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.NoCols.BackColor = System.Drawing.Color.Transparent
        Me.NoCols.ButtonsEqualSize = False
        Me.NoCols.Checked = False
        Me.NoCols.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NoCols.EnableTabstops = False
        Me.NoCols.Label = ""
        Me.NoCols.LabelFont = New System.Drawing.Font("Lucida Console", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoCols.LabelForeColor = System.Drawing.Color.Yellow
        Me.NoCols.LabelShow = False
        Me.NoCols.Location = New System.Drawing.Point(0, 0)
        Me.NoCols.Margin = New System.Windows.Forms.Padding(0)
        Me.NoCols.Name = "NoCols"
        Me.NoCols.OffCheckedBack = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NoCols.OffClickBack = System.Drawing.Color.Maroon
        Me.NoCols.OffHoverBack = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.NoCols.OffUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NoCols.OnCheckedBack = System.Drawing.Color.LimeGreen
        Me.NoCols.OnClickBack = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NoCols.OnHoverBack = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.NoCols.OnUnCheckedBack = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NoCols.Padding = New System.Windows.Forms.Padding(1)
        Me.NoCols.RadioBorderColor = System.Drawing.Color.Black
        Me.NoCols.RadioBorderWidth = 2
        Me.NoCols.RadioForeColorChecked = System.Drawing.Color.White
        Me.NoCols.RadioForeColorUnChecked = System.Drawing.Color.White
        Me.NoCols.Size = New System.Drawing.Size(84, 24)
        Me.NoCols.TabIndex = 11
        '
        'lblNoCols
        '
        Me.lblNoCols.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCols.ForeColor = System.Drawing.Color.White
        Me.lblNoCols.Location = New System.Drawing.Point(90, 4)
        Me.lblNoCols.Name = "lblNoCols"
        Me.lblNoCols.Size = New System.Drawing.Size(112, 23)
        Me.lblNoCols.TabIndex = 10
        Me.lblNoCols.Text = "No Colors (ASCII)"
        Me.lblNoCols.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoCols.UseCompatibleTextRendering = True
        '
        'lblImgFormat
        '
        Me.lblImgFormat.BackColor = System.Drawing.Color.Transparent
        Me.lblImgFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImgFormat.ForeColor = System.Drawing.Color.White
        Me.lblImgFormat.Location = New System.Drawing.Point(220, 4)
        Me.lblImgFormat.Name = "lblImgFormat"
        Me.lblImgFormat.Size = New System.Drawing.Size(54, 20)
        Me.lblImgFormat.TabIndex = 62
        Me.lblImgFormat.Text = "Format"
        Me.lblImgFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblImgFormat.UseCompatibleTextRendering = True
        '
        'lblImageOutputs
        '
        Me.lblImageOutputs.BackColor = System.Drawing.Color.Transparent
        Me.lblImageOutputs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageOutputs.ForeColor = System.Drawing.Color.Yellow
        Me.lblImageOutputs.Location = New System.Drawing.Point(4, 4)
        Me.lblImageOutputs.Name = "lblImageOutputs"
        Me.lblImageOutputs.Size = New System.Drawing.Size(174, 23)
        Me.lblImageOutputs.TabIndex = 56
        Me.lblImageOutputs.Text = "Image Outputs"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnSelfont)
        Me.Panel6.Controls.Add(Me.lblSelFont)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Location = New System.Drawing.Point(445, 171)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(383, 54)
        Me.Panel6.TabIndex = 75
        Me.Panel6.Tag = "0"
        '
        'btnSelfont
        '
        Me.btnSelfont.BeginColor = System.Drawing.Color.Navy
        Me.btnSelfont.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnSelfont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelfont.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSelfont.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSelfont.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelfont.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSelfont.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSelfont.Location = New System.Drawing.Point(288, 25)
        Me.btnSelfont.Name = "btnSelfont"
        Me.btnSelfont.Size = New System.Drawing.Size(84, 20)
        Me.btnSelfont.TabIndex = 74
        Me.btnSelfont.Text = "Select Font"
        Me.btnSelfont.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSelfont.UseVisualStyleBackColor = True
        '
        'lblSelFont
        '
        Me.lblSelFont.BackColor = System.Drawing.Color.Transparent
        Me.lblSelFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSelFont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelFont.ForeColor = System.Drawing.Color.White
        Me.lblSelFont.Location = New System.Drawing.Point(6, 25)
        Me.lblSelFont.Name = "lblSelFont"
        Me.lblSelFont.Size = New System.Drawing.Size(283, 19)
        Me.lblSelFont.TabIndex = 73
        Me.lblSelFont.Text = "Font Name"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 23)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Display Font"
        '
        'pGeneral
        '
        Me.pGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pGeneral.Controls.Add(Me.pExt)
        Me.pGeneral.Controls.Add(Me.pOutExist)
        Me.pGeneral.Controls.Add(Me.pSauce)
        Me.pGeneral.Controls.Add(Me.Label4)
        Me.pGeneral.Location = New System.Drawing.Point(412, 10)
        Me.pGeneral.Name = "pGeneral"
        Me.pGeneral.Size = New System.Drawing.Size(450, 88)
        Me.pGeneral.TabIndex = 75
        Me.pGeneral.Tag = "0"
        '
        'pExt
        '
        Me.pExt.BackColor = System.Drawing.Color.Transparent
        Me.pExt.Controls.Add(Me.rReplaceExt)
        Me.pExt.Controls.Add(Me.rExtraExt)
        Me.pExt.Controls.Add(Me.lblExtension)
        Me.pExt.Location = New System.Drawing.Point(3, 24)
        Me.pExt.Name = "pExt"
        Me.pExt.Size = New System.Drawing.Size(200, 28)
        Me.pExt.TabIndex = 70
        Me.pExt.Tag = "REPLACE"
        '
        'rReplaceExt
        '
        Me.rReplaceExt.Appearance = System.Windows.Forms.Appearance.Button
        Me.rReplaceExt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rReplaceExt.Checked = True
        Me.rReplaceExt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rReplaceExt.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rReplaceExt.FlatAppearance.BorderSize = 2
        Me.rReplaceExt.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rReplaceExt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rReplaceExt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rReplaceExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rReplaceExt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rReplaceExt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rReplaceExt.Location = New System.Drawing.Point(74, 3)
        Me.rReplaceExt.Name = "rReplaceExt"
        Me.rReplaceExt.Size = New System.Drawing.Size(66, 24)
        Me.rReplaceExt.TabIndex = 11
        Me.rReplaceExt.TabStop = True
        Me.rReplaceExt.Tag = "REPLACE"
        Me.rReplaceExt.Text = "Replace"
        Me.rReplaceExt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rReplaceExt.UseCompatibleTextRendering = True
        Me.rReplaceExt.UseVisualStyleBackColor = False
        '
        'rExtraExt
        '
        Me.rExtraExt.Appearance = System.Windows.Forms.Appearance.Button
        Me.rExtraExt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rExtraExt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rExtraExt.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rExtraExt.FlatAppearance.BorderSize = 2
        Me.rExtraExt.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rExtraExt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rExtraExt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rExtraExt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rExtraExt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rExtraExt.Location = New System.Drawing.Point(143, 3)
        Me.rExtraExt.Name = "rExtraExt"
        Me.rExtraExt.Size = New System.Drawing.Size(46, 24)
        Me.rExtraExt.TabIndex = 12
        Me.rExtraExt.Tag = "EXTRA"
        Me.rExtraExt.Text = "Extra"
        Me.rExtraExt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rExtraExt.UseCompatibleTextRendering = True
        Me.rExtraExt.UseVisualStyleBackColor = False
        '
        'lblExtension
        '
        Me.lblExtension.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExtension.ForeColor = System.Drawing.Color.White
        Me.lblExtension.Location = New System.Drawing.Point(0, 5)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(70, 20)
        Me.lblExtension.TabIndex = 10
        Me.lblExtension.Text = "Extension"
        Me.lblExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblExtension.UseCompatibleTextRendering = True
        '
        'pOutExist
        '
        Me.pOutExist.BackColor = System.Drawing.Color.Transparent
        Me.pOutExist.Controls.Add(Me.lblOutputExists)
        Me.pOutExist.Controls.Add(Me.rOver)
        Me.pOutExist.Controls.Add(Me.rSkip)
        Me.pOutExist.Controls.Add(Me.rAutoRen)
        Me.pOutExist.Controls.Add(Me.rAsk)
        Me.pOutExist.Location = New System.Drawing.Point(3, 56)
        Me.pOutExist.Name = "pOutExist"
        Me.pOutExist.Size = New System.Drawing.Size(333, 28)
        Me.pOutExist.TabIndex = 68
        Me.pOutExist.Tag = "0"
        '
        'lblOutputExists
        '
        Me.lblOutputExists.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputExists.ForeColor = System.Drawing.Color.White
        Me.lblOutputExists.Location = New System.Drawing.Point(0, 2)
        Me.lblOutputExists.Name = "lblOutputExists"
        Me.lblOutputExists.Size = New System.Drawing.Size(70, 20)
        Me.lblOutputExists.TabIndex = 11
        Me.lblOutputExists.Text = "File Exists"
        Me.lblOutputExists.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOutputExists.UseCompatibleTextRendering = True
        '
        'rOver
        '
        Me.rOver.Appearance = System.Windows.Forms.Appearance.Button
        Me.rOver.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rOver.Checked = True
        Me.rOver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rOver.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rOver.FlatAppearance.BorderSize = 2
        Me.rOver.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rOver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rOver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rOver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rOver.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rOver.Location = New System.Drawing.Point(74, 2)
        Me.rOver.Name = "rOver"
        Me.rOver.Size = New System.Drawing.Size(68, 24)
        Me.rOver.TabIndex = 0
        Me.rOver.TabStop = True
        Me.rOver.Tag = "0"
        Me.rOver.Text = "Overwrite"
        Me.rOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rOver.UseCompatibleTextRendering = True
        Me.rOver.UseVisualStyleBackColor = False
        '
        'rSkip
        '
        Me.rSkip.Appearance = System.Windows.Forms.Appearance.Button
        Me.rSkip.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rSkip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rSkip.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rSkip.FlatAppearance.BorderSize = 2
        Me.rSkip.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rSkip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rSkip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rSkip.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rSkip.Location = New System.Drawing.Point(145, 2)
        Me.rSkip.Name = "rSkip"
        Me.rSkip.Size = New System.Drawing.Size(46, 24)
        Me.rSkip.TabIndex = 1
        Me.rSkip.Tag = "1"
        Me.rSkip.Text = "Skip"
        Me.rSkip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rSkip.UseCompatibleTextRendering = True
        Me.rSkip.UseVisualStyleBackColor = False
        '
        'rAutoRen
        '
        Me.rAutoRen.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAutoRen.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAutoRen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAutoRen.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAutoRen.FlatAppearance.BorderSize = 2
        Me.rAutoRen.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAutoRen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAutoRen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAutoRen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAutoRen.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAutoRen.Location = New System.Drawing.Point(195, 2)
        Me.rAutoRen.Name = "rAutoRen"
        Me.rAutoRen.Size = New System.Drawing.Size(66, 24)
        Me.rAutoRen.TabIndex = 2
        Me.rAutoRen.Tag = "2"
        Me.rAutoRen.Text = "Auto-Ren"
        Me.rAutoRen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAutoRen.UseCompatibleTextRendering = True
        Me.rAutoRen.UseVisualStyleBackColor = False
        '
        'rAsk
        '
        Me.rAsk.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAsk.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAsk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAsk.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAsk.FlatAppearance.BorderSize = 2
        Me.rAsk.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAsk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAsk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAsk.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAsk.Location = New System.Drawing.Point(264, 2)
        Me.rAsk.Name = "rAsk"
        Me.rAsk.Size = New System.Drawing.Size(44, 24)
        Me.rAsk.TabIndex = 3
        Me.rAsk.Tag = "3"
        Me.rAsk.Text = "Ask"
        Me.rAsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAsk.UseCompatibleTextRendering = True
        Me.rAsk.UseVisualStyleBackColor = False
        '
        'pSauce
        '
        Me.pSauce.BackColor = System.Drawing.Color.Transparent
        Me.pSauce.Controls.Add(Me.rSauceStrip)
        Me.pSauce.Controls.Add(Me.lblSauce)
        Me.pSauce.Controls.Add(Me.rSauceKeep)
        Me.pSauce.Location = New System.Drawing.Point(224, 24)
        Me.pSauce.Name = "pSauce"
        Me.pSauce.Size = New System.Drawing.Size(210, 28)
        Me.pSauce.TabIndex = 66
        Me.pSauce.Tag = "Keep"
        '
        'rSauceStrip
        '
        Me.rSauceStrip.Appearance = System.Windows.Forms.Appearance.Button
        Me.rSauceStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rSauceStrip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rSauceStrip.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rSauceStrip.FlatAppearance.BorderSize = 2
        Me.rSauceStrip.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rSauceStrip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rSauceStrip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rSauceStrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rSauceStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSauceStrip.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rSauceStrip.Location = New System.Drawing.Point(90, 1)
        Me.rSauceStrip.Name = "rSauceStrip"
        Me.rSauceStrip.Size = New System.Drawing.Size(66, 24)
        Me.rSauceStrip.TabIndex = 0
        Me.rSauceStrip.Tag = "Strip"
        Me.rSauceStrip.Text = "Strip Tag"
        Me.rSauceStrip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rSauceStrip.UseCompatibleTextRendering = True
        Me.rSauceStrip.UseVisualStyleBackColor = False
        '
        'lblSauce
        '
        Me.lblSauce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSauce.ForeColor = System.Drawing.Color.White
        Me.lblSauce.Location = New System.Drawing.Point(10, 5)
        Me.lblSauce.Name = "lblSauce"
        Me.lblSauce.Size = New System.Drawing.Size(70, 20)
        Me.lblSauce.TabIndex = 11
        Me.lblSauce.Text = "Sauce Tag"
        Me.lblSauce.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSauce.UseCompatibleTextRendering = True
        '
        'rSauceKeep
        '
        Me.rSauceKeep.Appearance = System.Windows.Forms.Appearance.Button
        Me.rSauceKeep.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rSauceKeep.Checked = True
        Me.rSauceKeep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rSauceKeep.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rSauceKeep.FlatAppearance.BorderSize = 2
        Me.rSauceKeep.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rSauceKeep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rSauceKeep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rSauceKeep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rSauceKeep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSauceKeep.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rSauceKeep.Location = New System.Drawing.Point(159, 1)
        Me.rSauceKeep.Name = "rSauceKeep"
        Me.rSauceKeep.Size = New System.Drawing.Size(46, 24)
        Me.rSauceKeep.TabIndex = 1
        Me.rSauceKeep.TabStop = True
        Me.rSauceKeep.Tag = "Keep"
        Me.rSauceKeep.Text = "Keep"
        Me.rSauceKeep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rSauceKeep.UseCompatibleTextRendering = True
        Me.rSauceKeep.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(2, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 23)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "General"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Basic Font", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(27, 422)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(194, 32)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Settings"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Yellow
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Quick Help"
        '
        'pVideo
        '
        Me.pVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pVideo.Controls.Add(Me.lblBPS)
        Me.pVideo.Controls.Add(Me.lblVideoPanel)
        Me.pVideo.Controls.Add(Me.lblFPS)
        Me.pVideo.Controls.Add(Me.txtBPS)
        Me.pVideo.Controls.Add(Me.txtFPS)
        Me.pVideo.Location = New System.Drawing.Point(343, 233)
        Me.pVideo.Name = "pVideo"
        Me.pVideo.Size = New System.Drawing.Size(142, 84)
        Me.pVideo.TabIndex = 64
        Me.pVideo.Tag = "lblFPS"
        '
        'lblBPS
        '
        Me.lblBPS.AutoSize = True
        Me.lblBPS.BackColor = System.Drawing.Color.Transparent
        Me.lblBPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBPS.ForeColor = System.Drawing.Color.White
        Me.lblBPS.Location = New System.Drawing.Point(9, 55)
        Me.lblBPS.Name = "lblBPS"
        Me.lblBPS.Size = New System.Drawing.Size(32, 20)
        Me.lblBPS.TabIndex = 64
        Me.lblBPS.Text = "BPS"
        Me.lblBPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBPS.UseCompatibleTextRendering = True
        '
        'lblVideoPanel
        '
        Me.lblVideoPanel.BackColor = System.Drawing.Color.Transparent
        Me.lblVideoPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVideoPanel.ForeColor = System.Drawing.Color.Yellow
        Me.lblVideoPanel.Location = New System.Drawing.Point(-5, 8)
        Me.lblVideoPanel.Name = "lblVideoPanel"
        Me.lblVideoPanel.Size = New System.Drawing.Size(116, 20)
        Me.lblVideoPanel.TabIndex = 63
        Me.lblVideoPanel.Text = "Video Outputs"
        Me.lblVideoPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVideoPanel.UseCompatibleTextRendering = True
        '
        'lblFPS
        '
        Me.lblFPS.AutoSize = True
        Me.lblFPS.BackColor = System.Drawing.Color.Transparent
        Me.lblFPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFPS.ForeColor = System.Drawing.Color.White
        Me.lblFPS.Location = New System.Drawing.Point(9, 28)
        Me.lblFPS.Name = "lblFPS"
        Me.lblFPS.Size = New System.Drawing.Size(31, 20)
        Me.lblFPS.TabIndex = 17
        Me.lblFPS.Text = "FPS"
        Me.lblFPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFPS.UseCompatibleTextRendering = True
        '
        'txtBPS
        '
        Me.txtBPS.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBPS.Location = New System.Drawing.Point(44, 55)
        Me.txtBPS.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.txtBPS.MaximumSize = New System.Drawing.Size(75, 20)
        Me.txtBPS.Name = "txtBPS"
        Me.txtBPS.Size = New System.Drawing.Size(75, 20)
        Me.txtBPS.TabIndex = 16
        Me.txtBPS.Text = "14000"
        Me.txtBPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFPS
        '
        Me.txtFPS.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFPS.Location = New System.Drawing.Point(45, 30)
        Me.txtFPS.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.txtFPS.MaximumSize = New System.Drawing.Size(85, 20)
        Me.txtFPS.Name = "txtFPS"
        Me.txtFPS.Size = New System.Drawing.Size(75, 20)
        Me.txtFPS.TabIndex = 15
        Me.txtFPS.Text = "29.97"
        Me.txtFPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pVideoOutFormats
        '
        Me.pVideoOutFormats.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pVideoOutFormats.Controls.Add(Me.Label1)
        Me.pVideoOutFormats.Controls.Add(Me.pVidFmts)
        Me.pVideoOutFormats.Location = New System.Drawing.Point(480, 233)
        Me.pVideoOutFormats.Name = "pVideoOutFormats"
        Me.pVideoOutFormats.Size = New System.Drawing.Size(223, 84)
        Me.pVideoOutFormats.TabIndex = 65
        Me.pVideoOutFormats.Tag = "lblFPS"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Format"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.UseCompatibleTextRendering = True
        '
        'pVidFmts
        '
        Me.pVidFmts.BackColor = System.Drawing.Color.Transparent
        Me.pVidFmts.Controls.Add(Me.rVOB)
        Me.pVidFmts.Controls.Add(Me.rMPG)
        Me.pVidFmts.Controls.Add(Me.rMKV)
        Me.pVidFmts.Controls.Add(Me.rMP4)
        Me.pVidFmts.Controls.Add(Me.rFLV)
        Me.pVidFmts.Controls.Add(Me.rAGIF)
        Me.pVidFmts.Controls.Add(Me.rWMV)
        Me.pVidFmts.Controls.Add(Me.rAVI)
        Me.pVidFmts.Location = New System.Drawing.Point(15, 22)
        Me.pVidFmts.Name = "pVidFmts"
        Me.pVidFmts.Size = New System.Drawing.Size(202, 60)
        Me.pVidFmts.TabIndex = 69
        Me.pVidFmts.Tag = "AVI"
        '
        'rVOB
        '
        Me.rVOB.Appearance = System.Windows.Forms.Appearance.Button
        Me.rVOB.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rVOB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rVOB.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rVOB.FlatAppearance.BorderSize = 2
        Me.rVOB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rVOB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rVOB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rVOB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rVOB.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rVOB.Location = New System.Drawing.Point(146, 32)
        Me.rVOB.Name = "rVOB"
        Me.rVOB.Size = New System.Drawing.Size(44, 24)
        Me.rVOB.TabIndex = 11
        Me.rVOB.Tag = "VOB"
        Me.rVOB.Text = "VOB"
        Me.rVOB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rVOB.UseCompatibleTextRendering = True
        Me.rVOB.UseVisualStyleBackColor = False
        '
        'rMPG
        '
        Me.rMPG.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMPG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMPG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMPG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMPG.FlatAppearance.BorderSize = 2
        Me.rMPG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMPG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMPG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMPG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMPG.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMPG.Location = New System.Drawing.Point(146, 2)
        Me.rMPG.Name = "rMPG"
        Me.rMPG.Size = New System.Drawing.Size(44, 24)
        Me.rMPG.TabIndex = 10
        Me.rMPG.Tag = "MPG"
        Me.rMPG.Text = "MPG"
        Me.rMPG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMPG.UseCompatibleTextRendering = True
        Me.rMPG.UseVisualStyleBackColor = False
        '
        'rMKV
        '
        Me.rMKV.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMKV.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMKV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMKV.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMKV.FlatAppearance.BorderSize = 2
        Me.rMKV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMKV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMKV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMKV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMKV.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMKV.Location = New System.Drawing.Point(98, 32)
        Me.rMKV.Name = "rMKV"
        Me.rMKV.Size = New System.Drawing.Size(44, 24)
        Me.rMKV.TabIndex = 9
        Me.rMKV.Tag = "MKV"
        Me.rMKV.Text = "MKV"
        Me.rMKV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMKV.UseCompatibleTextRendering = True
        Me.rMKV.UseVisualStyleBackColor = False
        '
        'rMP4
        '
        Me.rMP4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMP4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMP4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMP4.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMP4.FlatAppearance.BorderSize = 2
        Me.rMP4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMP4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMP4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMP4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMP4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMP4.Location = New System.Drawing.Point(50, 32)
        Me.rMP4.Name = "rMP4"
        Me.rMP4.Size = New System.Drawing.Size(44, 24)
        Me.rMP4.TabIndex = 8
        Me.rMP4.Tag = "MP4"
        Me.rMP4.Text = "MP4"
        Me.rMP4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMP4.UseCompatibleTextRendering = True
        Me.rMP4.UseVisualStyleBackColor = False
        '
        'rFLV
        '
        Me.rFLV.Appearance = System.Windows.Forms.Appearance.Button
        Me.rFLV.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rFLV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rFLV.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rFLV.FlatAppearance.BorderSize = 2
        Me.rFLV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rFLV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rFLV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rFLV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rFLV.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rFLV.Location = New System.Drawing.Point(3, 32)
        Me.rFLV.Name = "rFLV"
        Me.rFLV.Size = New System.Drawing.Size(44, 24)
        Me.rFLV.TabIndex = 7
        Me.rFLV.Tag = "FLV"
        Me.rFLV.Text = "FLV"
        Me.rFLV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rFLV.UseCompatibleTextRendering = True
        Me.rFLV.UseVisualStyleBackColor = False
        '
        'rAGIF
        '
        Me.rAGIF.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAGIF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAGIF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAGIF.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAGIF.FlatAppearance.BorderSize = 2
        Me.rAGIF.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAGIF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAGIF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAGIF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAGIF.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAGIF.Location = New System.Drawing.Point(98, 2)
        Me.rAGIF.Name = "rAGIF"
        Me.rAGIF.Size = New System.Drawing.Size(44, 24)
        Me.rAGIF.TabIndex = 6
        Me.rAGIF.Tag = "GIF"
        Me.rAGIF.Text = "GIF"
        Me.rAGIF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAGIF.UseCompatibleTextRendering = True
        Me.rAGIF.UseVisualStyleBackColor = False
        '
        'rWMV
        '
        Me.rWMV.Appearance = System.Windows.Forms.Appearance.Button
        Me.rWMV.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rWMV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rWMV.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rWMV.FlatAppearance.BorderSize = 2
        Me.rWMV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rWMV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rWMV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rWMV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rWMV.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rWMV.Location = New System.Drawing.Point(50, 2)
        Me.rWMV.Name = "rWMV"
        Me.rWMV.Size = New System.Drawing.Size(44, 24)
        Me.rWMV.TabIndex = 5
        Me.rWMV.Tag = "WMV"
        Me.rWMV.Text = "WMV"
        Me.rWMV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rWMV.UseCompatibleTextRendering = True
        Me.rWMV.UseVisualStyleBackColor = False
        '
        'rAVI
        '
        Me.rAVI.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAVI.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAVI.Checked = True
        Me.rAVI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAVI.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAVI.FlatAppearance.BorderSize = 2
        Me.rAVI.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAVI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAVI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAVI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAVI.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAVI.Location = New System.Drawing.Point(2, 2)
        Me.rAVI.Name = "rAVI"
        Me.rAVI.Size = New System.Drawing.Size(44, 24)
        Me.rAVI.TabIndex = 4
        Me.rAVI.TabStop = True
        Me.rAVI.Tag = "AVI"
        Me.rAVI.Text = "AVI"
        Me.rAVI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAVI.UseCompatibleTextRendering = True
        Me.rAVI.UseVisualStyleBackColor = False
        '
        'pAVICodec
        '
        Me.pAVICodec.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pAVICodec.Controls.Add(Me.lblAVICodec)
        Me.pAVICodec.Controls.Add(Me.rFFVI)
        Me.pAVICodec.Controls.Add(Me.rLIBXVID)
        Me.pAVICodec.Controls.Add(Me.rMJPEG)
        Me.pAVICodec.Controls.Add(Me.rH264)
        Me.pAVICodec.Controls.Add(Me.rLIBX264)
        Me.pAVICodec.Controls.Add(Me.rMPEG4)
        Me.pAVICodec.Controls.Add(Me.rZMBV)
        Me.pAVICodec.Location = New System.Drawing.Point(488, 317)
        Me.pAVICodec.Name = "pAVICodec"
        Me.pAVICodec.Size = New System.Drawing.Size(265, 60)
        Me.pAVICodec.TabIndex = 76
        Me.pAVICodec.Tag = "ZMBV"
        '
        'lblAVICodec
        '
        Me.lblAVICodec.AutoSize = True
        Me.lblAVICodec.BackColor = System.Drawing.Color.Transparent
        Me.lblAVICodec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAVICodec.ForeColor = System.Drawing.Color.White
        Me.lblAVICodec.Location = New System.Drawing.Point(214, 32)
        Me.lblAVICodec.Name = "lblAVICodec"
        Me.lblAVICodec.Size = New System.Drawing.Size(44, 20)
        Me.lblAVICodec.TabIndex = 71
        Me.lblAVICodec.Text = "Codec"
        Me.lblAVICodec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAVICodec.UseCompatibleTextRendering = True
        '
        'rFFVI
        '
        Me.rFFVI.Appearance = System.Windows.Forms.Appearance.Button
        Me.rFFVI.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rFFVI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rFFVI.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rFFVI.FlatAppearance.BorderSize = 2
        Me.rFFVI.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rFFVI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rFFVI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rFFVI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rFFVI.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rFFVI.Location = New System.Drawing.Point(208, 4)
        Me.rFFVI.Name = "rFFVI"
        Me.rFFVI.Size = New System.Drawing.Size(54, 24)
        Me.rFFVI.TabIndex = 16
        Me.rFFVI.Tag = "FFVI"
        Me.rFFVI.Text = "FFVI"
        Me.rFFVI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rFFVI.UseCompatibleTextRendering = True
        Me.rFFVI.UseVisualStyleBackColor = False
        '
        'rLIBXVID
        '
        Me.rLIBXVID.Appearance = System.Windows.Forms.Appearance.Button
        Me.rLIBXVID.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rLIBXVID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rLIBXVID.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rLIBXVID.FlatAppearance.BorderSize = 2
        Me.rLIBXVID.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rLIBXVID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rLIBXVID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rLIBXVID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rLIBXVID.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rLIBXVID.Location = New System.Drawing.Point(130, 30)
        Me.rLIBXVID.Name = "rLIBXVID"
        Me.rLIBXVID.Size = New System.Drawing.Size(74, 24)
        Me.rLIBXVID.TabIndex = 15
        Me.rLIBXVID.Tag = "LIBXVID"
        Me.rLIBXVID.Text = "LIBXVID"
        Me.rLIBXVID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rLIBXVID.UseCompatibleTextRendering = True
        Me.rLIBXVID.UseVisualStyleBackColor = False
        '
        'rMJPEG
        '
        Me.rMJPEG.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMJPEG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMJPEG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMJPEG.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMJPEG.FlatAppearance.BorderSize = 2
        Me.rMJPEG.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMJPEG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMJPEG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMJPEG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMJPEG.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMJPEG.Location = New System.Drawing.Point(62, 30)
        Me.rMJPEG.Name = "rMJPEG"
        Me.rMJPEG.Size = New System.Drawing.Size(64, 24)
        Me.rMJPEG.TabIndex = 14
        Me.rMJPEG.Tag = "MJPEG"
        Me.rMJPEG.Text = "MJPEG"
        Me.rMJPEG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMJPEG.UseCompatibleTextRendering = True
        Me.rMJPEG.UseVisualStyleBackColor = False
        '
        'rH264
        '
        Me.rH264.Appearance = System.Windows.Forms.Appearance.Button
        Me.rH264.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rH264.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rH264.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rH264.FlatAppearance.BorderSize = 2
        Me.rH264.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rH264.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rH264.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rH264.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rH264.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rH264.Location = New System.Drawing.Point(4, 30)
        Me.rH264.Name = "rH264"
        Me.rH264.Size = New System.Drawing.Size(54, 24)
        Me.rH264.TabIndex = 13
        Me.rH264.Tag = "H264"
        Me.rH264.Text = "H264"
        Me.rH264.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rH264.UseCompatibleTextRendering = True
        Me.rH264.UseVisualStyleBackColor = False
        '
        'rLIBX264
        '
        Me.rLIBX264.Appearance = System.Windows.Forms.Appearance.Button
        Me.rLIBX264.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rLIBX264.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rLIBX264.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rLIBX264.FlatAppearance.BorderSize = 2
        Me.rLIBX264.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rLIBX264.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rLIBX264.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rLIBX264.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rLIBX264.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rLIBX264.Location = New System.Drawing.Point(130, 4)
        Me.rLIBX264.Name = "rLIBX264"
        Me.rLIBX264.Size = New System.Drawing.Size(74, 24)
        Me.rLIBX264.TabIndex = 12
        Me.rLIBX264.Tag = "LIBX264"
        Me.rLIBX264.Text = "LIBX264"
        Me.rLIBX264.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rLIBX264.UseCompatibleTextRendering = True
        Me.rLIBX264.UseVisualStyleBackColor = False
        '
        'rMPEG4
        '
        Me.rMPEG4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMPEG4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMPEG4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMPEG4.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMPEG4.FlatAppearance.BorderSize = 2
        Me.rMPEG4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMPEG4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMPEG4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMPEG4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMPEG4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMPEG4.Location = New System.Drawing.Point(62, 4)
        Me.rMPEG4.Name = "rMPEG4"
        Me.rMPEG4.Size = New System.Drawing.Size(64, 24)
        Me.rMPEG4.TabIndex = 11
        Me.rMPEG4.Tag = "MPEG4"
        Me.rMPEG4.Text = "MPEG4"
        Me.rMPEG4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMPEG4.UseCompatibleTextRendering = True
        Me.rMPEG4.UseVisualStyleBackColor = False
        '
        'rZMBV
        '
        Me.rZMBV.Appearance = System.Windows.Forms.Appearance.Button
        Me.rZMBV.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rZMBV.Checked = True
        Me.rZMBV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rZMBV.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rZMBV.FlatAppearance.BorderSize = 2
        Me.rZMBV.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rZMBV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rZMBV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rZMBV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rZMBV.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rZMBV.Location = New System.Drawing.Point(4, 4)
        Me.rZMBV.Name = "rZMBV"
        Me.rZMBV.Size = New System.Drawing.Size(54, 24)
        Me.rZMBV.TabIndex = 10
        Me.rZMBV.TabStop = True
        Me.rZMBV.Tag = "ZMBV"
        Me.rZMBV.Text = "ZMBV"
        Me.rZMBV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rZMBV.UseCompatibleTextRendering = True
        Me.rZMBV.UseVisualStyleBackColor = False
        '
        'pMPGCodec
        '
        Me.pMPGCodec.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pMPGCodec.Controls.Add(Me.Label2)
        Me.pMPGCodec.Controls.Add(Me.rMPEG2)
        Me.pMPGCodec.Controls.Add(Me.rMPEG1)
        Me.pMPGCodec.Location = New System.Drawing.Point(702, 233)
        Me.pMPGCodec.Name = "pMPGCodec"
        Me.pMPGCodec.Size = New System.Drawing.Size(72, 84)
        Me.pMPGCodec.TabIndex = 77
        Me.pMPGCodec.Tag = "MPEG1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Codec"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.UseCompatibleTextRendering = True
        '
        'rMPEG2
        '
        Me.rMPEG2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMPEG2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMPEG2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMPEG2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMPEG2.FlatAppearance.BorderSize = 2
        Me.rMPEG2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMPEG2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMPEG2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMPEG2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMPEG2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMPEG2.Location = New System.Drawing.Point(4, 50)
        Me.rMPEG2.Name = "rMPEG2"
        Me.rMPEG2.Size = New System.Drawing.Size(64, 24)
        Me.rMPEG2.TabIndex = 14
        Me.rMPEG2.Tag = "mpeg2video"
        Me.rMPEG2.Text = "MPEG2"
        Me.rMPEG2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMPEG2.UseCompatibleTextRendering = True
        Me.rMPEG2.UseVisualStyleBackColor = False
        '
        'rMPEG1
        '
        Me.rMPEG1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rMPEG1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rMPEG1.Checked = True
        Me.rMPEG1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rMPEG1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rMPEG1.FlatAppearance.BorderSize = 2
        Me.rMPEG1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rMPEG1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rMPEG1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rMPEG1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rMPEG1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rMPEG1.Location = New System.Drawing.Point(4, 24)
        Me.rMPEG1.Name = "rMPEG1"
        Me.rMPEG1.Size = New System.Drawing.Size(64, 24)
        Me.rMPEG1.TabIndex = 11
        Me.rMPEG1.TabStop = True
        Me.rMPEG1.Tag = "mpeg1video"
        Me.rMPEG1.Text = "MPEG1"
        Me.rMPEG1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rMPEG1.UseCompatibleTextRendering = True
        Me.rMPEG1.UseVisualStyleBackColor = False
        '
        'pLFrame
        '
        Me.pLFrame.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pLFrame.Controls.Add(Me.Label3)
        Me.pLFrame.Controls.Add(Me.lblFExtend)
        Me.pLFrame.Controls.Add(Me.txtLastFrame)
        Me.pLFrame.Location = New System.Drawing.Point(343, 323)
        Me.pLFrame.Name = "pLFrame"
        Me.pLFrame.Size = New System.Drawing.Size(142, 31)
        Me.pLFrame.TabIndex = 65
        Me.pLFrame.Tag = "lblFPS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(104, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "sec"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.UseCompatibleTextRendering = True
        '
        'lblFExtend
        '
        Me.lblFExtend.AutoSize = True
        Me.lblFExtend.BackColor = System.Drawing.Color.Transparent
        Me.lblFExtend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFExtend.ForeColor = System.Drawing.Color.White
        Me.lblFExtend.Location = New System.Drawing.Point(13, 7)
        Me.lblFExtend.Name = "lblFExtend"
        Me.lblFExtend.Size = New System.Drawing.Size(47, 20)
        Me.lblFExtend.TabIndex = 17
        Me.lblFExtend.Text = "Extend"
        Me.lblFExtend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFExtend.UseCompatibleTextRendering = True
        '
        'txtLastFrame
        '
        Me.txtLastFrame.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastFrame.Location = New System.Drawing.Point(64, 7)
        Me.txtLastFrame.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.txtLastFrame.MaximumSize = New System.Drawing.Size(85, 20)
        Me.txtLastFrame.Name = "txtLastFrame"
        Me.txtLastFrame.Size = New System.Drawing.Size(36, 20)
        Me.txtLastFrame.TabIndex = 15
        Me.txtLastFrame.Text = "5"
        Me.txtLastFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(774, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 122)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "__o|___" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "|____   \       ___" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "      \   \____/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       \_________/"
        '
        'pBBS
        '
        Me.pBBS.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pBBS.Controls.Add(Me.lblBBSFormats)
        Me.pBBS.Controls.Add(Me.rWildcat3)
        Me.pBBS.Controls.Add(Me.rWildcat2)
        Me.pBBS.Controls.Add(Me.rAvatar)
        Me.pBBS.Controls.Add(Me.rPCBoard)
        Me.pBBS.Location = New System.Drawing.Point(451, 105)
        Me.pBBS.Name = "pBBS"
        Me.pBBS.Size = New System.Drawing.Size(265, 60)
        Me.pBBS.TabIndex = 81
        Me.pBBS.Tag = "PCB"
        '
        'rWildcat3
        '
        Me.rWildcat3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rWildcat3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rWildcat3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rWildcat3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rWildcat3.FlatAppearance.BorderSize = 2
        Me.rWildcat3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rWildcat3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rWildcat3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rWildcat3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rWildcat3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rWildcat3.Location = New System.Drawing.Point(178, 33)
        Me.rWildcat3.Name = "rWildcat3"
        Me.rWildcat3.Size = New System.Drawing.Size(74, 24)
        Me.rWildcat3.TabIndex = 15
        Me.rWildcat3.Tag = "WC3"
        Me.rWildcat3.Text = "Wildcat 3"
        Me.rWildcat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rWildcat3.UseCompatibleTextRendering = True
        Me.rWildcat3.UseVisualStyleBackColor = False
        '
        'rWildcat2
        '
        Me.rWildcat2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rWildcat2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rWildcat2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rWildcat2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rWildcat2.FlatAppearance.BorderSize = 2
        Me.rWildcat2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rWildcat2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rWildcat2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rWildcat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rWildcat2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rWildcat2.Location = New System.Drawing.Point(109, 33)
        Me.rWildcat2.Name = "rWildcat2"
        Me.rWildcat2.Size = New System.Drawing.Size(64, 24)
        Me.rWildcat2.TabIndex = 14
        Me.rWildcat2.Tag = "WC2"
        Me.rWildcat2.Text = "Wildcat 2"
        Me.rWildcat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rWildcat2.UseCompatibleTextRendering = True
        Me.rWildcat2.UseVisualStyleBackColor = False
        '
        'rAvatar
        '
        Me.rAvatar.Appearance = System.Windows.Forms.Appearance.Button
        Me.rAvatar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rAvatar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rAvatar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rAvatar.FlatAppearance.BorderSize = 2
        Me.rAvatar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rAvatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rAvatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rAvatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rAvatar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rAvatar.Location = New System.Drawing.Point(178, 5)
        Me.rAvatar.Name = "rAvatar"
        Me.rAvatar.Size = New System.Drawing.Size(74, 24)
        Me.rAvatar.TabIndex = 12
        Me.rAvatar.Tag = "AVT"
        Me.rAvatar.Text = "Avatar"
        Me.rAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rAvatar.UseCompatibleTextRendering = True
        Me.rAvatar.UseVisualStyleBackColor = False
        '
        'rPCBoard
        '
        Me.rPCBoard.Appearance = System.Windows.Forms.Appearance.Button
        Me.rPCBoard.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rPCBoard.Checked = True
        Me.rPCBoard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rPCBoard.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rPCBoard.FlatAppearance.BorderSize = 2
        Me.rPCBoard.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rPCBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rPCBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rPCBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rPCBoard.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rPCBoard.Location = New System.Drawing.Point(109, 5)
        Me.rPCBoard.Name = "rPCBoard"
        Me.rPCBoard.Size = New System.Drawing.Size(64, 24)
        Me.rPCBoard.TabIndex = 11
        Me.rPCBoard.TabStop = True
        Me.rPCBoard.Tag = "PCB"
        Me.rPCBoard.Text = "PCBoard"
        Me.rPCBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rPCBoard.UseCompatibleTextRendering = True
        Me.rPCBoard.UseVisualStyleBackColor = False
        '
        'lblBBSFormats
        '
        Me.lblBBSFormats.BackColor = System.Drawing.Color.Transparent
        Me.lblBBSFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBBSFormats.ForeColor = System.Drawing.Color.Yellow
        Me.lblBBSFormats.Location = New System.Drawing.Point(19, 7)
        Me.lblBBSFormats.Name = "lblBBSFormats"
        Me.lblBBSFormats.Size = New System.Drawing.Size(71, 40)
        Me.lblBBSFormats.TabIndex = 66
        Me.lblBBSFormats.Text = "BBS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Formats"
        Me.lblBBSFormats.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Settings
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.ClientSize = New System.Drawing.Size(869, 466)
        Me.ControlBox = False
        Me.Controls.Add(Me.pBBS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pLFrame)
        Me.Controls.Add(Me.pMPGCodec)
        Me.Controls.Add(Me.pAVICodec)
        Me.Controls.Add(Me.pVideoOutFormats)
        Me.Controls.Add(Me.pVideo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pSettHTML)
        Me.Controls.Add(Me.pSettImage)
        Me.Controls.Add(Me.pGeneral)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pThumbs)
        Me.Controls.Add(Me.btnClose)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.pThumbs.ResumeLayout(False)
        Me.pThumbs.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pGen.ResumeLayout(False)
        Me.pGen.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pUTF.ResumeLayout(False)
        Me.pSettHTML.ResumeLayout(False)
        Me.pHTMLFont.ResumeLayout(False)
        Me.pSanitize.ResumeLayout(False)
        Me.pSanitize.PerformLayout()
        Me.pAnim.ResumeLayout(False)
        Me.pHTMLObj.ResumeLayout(False)
        Me.pSettImage.ResumeLayout(False)
        Me.pIMGOut.ResumeLayout(False)
        Me.pThumb.ResumeLayout(False)
        Me.pSmallFnt.ResumeLayout(False)
        Me.pNoCols.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pGeneral.ResumeLayout(False)
        Me.pExt.ResumeLayout(False)
        Me.pOutExist.ResumeLayout(False)
        Me.pSauce.ResumeLayout(False)
        Me.pVideo.ResumeLayout(False)
        Me.pVideo.PerformLayout()
        Me.pVideoOutFormats.ResumeLayout(False)
        Me.pVidFmts.ResumeLayout(False)
        Me.pAVICodec.ResumeLayout(False)
        Me.pAVICodec.PerformLayout()
        Me.pMPGCodec.ResumeLayout(False)
        Me.pMPGCodec.PerformLayout()
        Me.pLFrame.ResumeLayout(False)
        Me.pLFrame.PerformLayout()
        Me.pBBS.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As MyControls.GButton
    Friend WithEvents pThumbs As System.Windows.Forms.Panel
    Friend WithEvents selThumbProp As System.Windows.Forms.RadioButton
    Friend WithEvents lblScaleSize As System.Windows.Forms.Label
    Friend WithEvents selThumbCustom As System.Windows.Forms.RadioButton
    Friend WithEvents selThumbHFixed As System.Windows.Forms.RadioButton
    Friend WithEvents selThumbWFixed As System.Windows.Forms.RadioButton
    Friend WithEvents lblPropPercent As System.Windows.Forms.Label
    Friend WithEvents ThumbHeight As System.Windows.Forms.TextBox
    Friend WithEvents ThumbWidth As System.Windows.Forms.TextBox
    Friend WithEvents ThumbScalePercent As System.Windows.Forms.TextBox
    Friend WithEvents lblTHumbs As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblUTFOut As System.Windows.Forms.Label
    Friend WithEvents rUTF16 As System.Windows.Forms.RadioButton
    Friend WithEvents rUTF8 As System.Windows.Forms.RadioButton
    Friend WithEvents pSettHTML As System.Windows.Forms.Panel
    Friend WithEvents Sanitize As MyControls.OnOffInputControlSmall
    Friend WithEvents lblSanitize As System.Windows.Forms.Label
    Friend WithEvents rStatic As System.Windows.Forms.RadioButton
    Friend WithEvents rAnim As System.Windows.Forms.RadioButton
    Friend WithEvents rObjectOnly As System.Windows.Forms.RadioButton
    Friend WithEvents rCompleteHTML As System.Windows.Forms.RadioButton
    Friend WithEvents lblHTMLOut As System.Windows.Forms.Label
    Friend WithEvents pSettImage As System.Windows.Forms.Panel
    Friend WithEvents NoCols As MyControls.OnOffInputControlSmall
    Friend WithEvents lblNoCols As System.Windows.Forms.Label
    Friend WithEvents lblImgFormat As System.Windows.Forms.Label
    Friend WithEvents lblImageOutputs As System.Windows.Forms.Label
    Friend WithEvents SmallFnt As MyControls.OnOffInputControlSmall
    Friend WithEvents lblSmallFnt As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents pThumb As System.Windows.Forms.Panel
    Friend WithEvents Thumb As MyControls.OnOffInputControlSmall
    Friend WithEvents lblThumb As System.Windows.Forms.Label
    Friend WithEvents btnSelfont As MyControls.GButton
    Friend WithEvents lblSelFont As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pGeneral As System.Windows.Forms.Panel
    Friend WithEvents rOver As System.Windows.Forms.RadioButton
    Friend WithEvents lblOutputExists As System.Windows.Forms.Label
    Friend WithEvents rAsk As System.Windows.Forms.RadioButton
    Friend WithEvents rAutoRen As System.Windows.Forms.RadioButton
    Friend WithEvents rSkip As System.Windows.Forms.RadioButton
    Friend WithEvents rSauceStrip As System.Windows.Forms.RadioButton
    Friend WithEvents lblSauce As System.Windows.Forms.Label
    Friend WithEvents rSauceKeep As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pIMGOut As System.Windows.Forms.Panel
    Friend WithEvents rJPG As System.Windows.Forms.RadioButton
    Friend WithEvents rGIF As System.Windows.Forms.RadioButton
    Friend WithEvents rBMP As System.Windows.Forms.RadioButton
    Friend WithEvents rPNG As System.Windows.Forms.RadioButton
    Friend WithEvents rICO As System.Windows.Forms.RadioButton
    Friend WithEvents rTIF As System.Windows.Forms.RadioButton
    Friend WithEvents rWMF As System.Windows.Forms.RadioButton
    Friend WithEvents rEMF As System.Windows.Forms.RadioButton
    Public WithEvents pUTF As System.Windows.Forms.Panel
    Public WithEvents pSanitize As System.Windows.Forms.Panel
    Public WithEvents pAnim As System.Windows.Forms.Panel
    Public WithEvents pHTMLObj As System.Windows.Forms.Panel
    Public WithEvents pNoCols As System.Windows.Forms.Panel
    Public WithEvents pSmallFnt As System.Windows.Forms.Panel
    Public WithEvents pOutExist As System.Windows.Forms.Panel
    Public WithEvents pSauce As System.Windows.Forms.Panel
    Friend WithEvents pGen As System.Windows.Forms.Panel
    Friend WithEvents bRemoveCompleted As MyControls.OnOffInputControlSmall
    Friend WithEvents lblRemComplete As System.Windows.Forms.Label
    Friend WithEvents pHTMLFont As System.Windows.Forms.Panel
    Friend WithEvents lblHTMLFont As System.Windows.Forms.Label
    Friend WithEvents cbHTMLFont As System.Windows.Forms.ComboBox
    Friend WithEvents pExt As System.Windows.Forms.Panel
    Friend WithEvents rReplaceExt As System.Windows.Forms.RadioButton
    Friend WithEvents rExtraExt As System.Windows.Forms.RadioButton
    Friend WithEvents lblExtension As System.Windows.Forms.Label
    Friend WithEvents pVideo As System.Windows.Forms.Panel
    Friend WithEvents lblBPS As System.Windows.Forms.Label
    Friend WithEvents lblVideoPanel As System.Windows.Forms.Label
    Friend WithEvents lblFPS As System.Windows.Forms.Label
    Friend WithEvents txtBPS As System.Windows.Forms.TextBox
    Friend WithEvents txtFPS As System.Windows.Forms.TextBox
    Friend WithEvents pVideoOutFormats As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pVidFmts As System.Windows.Forms.Panel
    Friend WithEvents rVOB As System.Windows.Forms.RadioButton
    Friend WithEvents rMPG As System.Windows.Forms.RadioButton
    Friend WithEvents rMKV As System.Windows.Forms.RadioButton
    Friend WithEvents rMP4 As System.Windows.Forms.RadioButton
    Friend WithEvents rFLV As System.Windows.Forms.RadioButton
    Friend WithEvents rAGIF As System.Windows.Forms.RadioButton
    Friend WithEvents rWMV As System.Windows.Forms.RadioButton
    Friend WithEvents rAVI As System.Windows.Forms.RadioButton
    Friend WithEvents pAVICodec As System.Windows.Forms.Panel
    Friend WithEvents rLIBXVID As System.Windows.Forms.RadioButton
    Friend WithEvents rMJPEG As System.Windows.Forms.RadioButton
    Friend WithEvents rH264 As System.Windows.Forms.RadioButton
    Friend WithEvents rLIBX264 As System.Windows.Forms.RadioButton
    Friend WithEvents rMPEG4 As System.Windows.Forms.RadioButton
    Friend WithEvents rZMBV As System.Windows.Forms.RadioButton
    Friend WithEvents rFFVI As System.Windows.Forms.RadioButton
    Friend WithEvents lblAVICodec As System.Windows.Forms.Label
    Friend WithEvents pMPGCodec As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rMPEG2 As System.Windows.Forms.RadioButton
    Friend WithEvents rMPEG1 As System.Windows.Forms.RadioButton
    Friend WithEvents pLFrame As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFExtend As System.Windows.Forms.Label
    Friend WithEvents txtLastFrame As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pBBS As System.Windows.Forms.Panel
    Friend WithEvents rWildcat3 As System.Windows.Forms.RadioButton
    Friend WithEvents rWildcat2 As System.Windows.Forms.RadioButton
    Friend WithEvents rAvatar As System.Windows.Forms.RadioButton
    Friend WithEvents rPCBoard As System.Windows.Forms.RadioButton
    Friend WithEvents lblBBSFormats As System.Windows.Forms.Label
End Class
