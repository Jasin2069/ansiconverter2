<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAdd = New MyControls.GButton
        Me.btnRemove = New MyControls.GButton
        Me.btnClear = New MyControls.GButton
        Me.numASCII = New System.Windows.Forms.Label
        Me.numUTF16 = New System.Windows.Forms.Label
        Me.numUTF8 = New System.Windows.Forms.Label
        Me.numTotal = New System.Windows.Forms.Label
        Me.lblLogAndInfos = New System.Windows.Forms.Label
        Me.numSel = New System.Windows.Forms.Label
        Me.btnSelNone = New MyControls.GButton
        Me.btnStart = New MyControls.GButton
        Me.lblDropHere = New System.Windows.Forms.Label
        Me.btnQuit = New MyControls.GButton
        Me.lblCPin = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.btnUniBlocks = New MyControls.GButton
        Me.btnSettings = New MyControls.GButton
        Me.btnSettings2 = New MyControls.GButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lblNumUTF16 = New System.Windows.Forms.Label
        Me.lblNUmASCII = New System.Windows.Forms.Label
        Me.lblNumUTF8 = New System.Windows.Forms.Label
        Me.log = New System.Windows.Forms.RichTextBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSelected = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblDebugOnOff = New System.Windows.Forms.Label
        Me.pCPInEmpty = New System.Windows.Forms.Panel
        Me.btnSearch = New MyControls.GButton
        Me.btnNFO = New System.Windows.Forms.Button
        Me.VersionDate = New System.Windows.Forms.Label
        Me.Version = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.btnCPMaps = New MyControls.GButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pCPout = New System.Windows.Forms.Panel
        Me.lblCPout = New System.Windows.Forms.Label
        Me.outCP = New System.Windows.Forms.ComboBox
        Me.pCPOutEmpty = New System.Windows.Forms.Panel
        Me.pOutPath = New System.Windows.Forms.Panel
        Me.lblExt = New System.Windows.Forms.Label
        Me.lblInfoSameDirOut = New System.Windows.Forms.Label
        Me.txtExt = New System.Windows.Forms.TextBox
        Me.btnOutputFolder = New MyControls.GButton
        Me.rOutPathInput = New System.Windows.Forms.RadioButton
        Me.outPath = New MyControls.PartialPathDisplayLabel
        Me.rOutPathNew = New System.Windows.Forms.RadioButton
        Me.pOut = New System.Windows.Forms.Panel
        Me.outVideo = New System.Windows.Forms.RadioButton
        Me.outImage = New System.Windows.Forms.RadioButton
        Me.lblOutput = New System.Windows.Forms.Label
        Me.outBinary = New System.Windows.Forms.RadioButton
        Me.outBBS = New System.Windows.Forms.RadioButton
        Me.outUnicode = New System.Windows.Forms.RadioButton
        Me.outHTML = New System.Windows.Forms.RadioButton
        Me.outANSI = New System.Windows.Forms.RadioButton
        Me.outASCII = New System.Windows.Forms.RadioButton
        Me.pCPin = New System.Windows.Forms.Panel
        Me.inCP = New System.Windows.Forms.ComboBox
        Me.pIn = New System.Windows.Forms.Panel
        Me.cntBIN = New System.Windows.Forms.Label
        Me.cntPCB = New System.Windows.Forms.Label
        Me.cntUNI = New System.Windows.Forms.Label
        Me.cntHTML = New System.Windows.Forms.Label
        Me.cntANSI = New System.Windows.Forms.Label
        Me.cntASCII = New System.Windows.Forms.Label
        Me.in2Binary = New System.Windows.Forms.CheckBox
        Me.in2PCBoard = New System.Windows.Forms.CheckBox
        Me.in2Unicode = New System.Windows.Forms.CheckBox
        Me.in2HTML = New System.Windows.Forms.CheckBox
        Me.in2ANSI = New System.Windows.Forms.CheckBox
        Me.in2ASCII = New System.Windows.Forms.CheckBox
        Me.lblInputFormats = New System.Windows.Forms.Label
        Me.listFiles = New System.Windows.Forms.ListBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.XPanel1 = New ANSI_ASCII_Converter.xPanel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.settSMALLFNT = New System.Windows.Forms.Label
        Me.settImgOut = New System.Windows.Forms.Label
        Me.settThumbs = New System.Windows.Forms.Label
        Me.attCreTh = New System.Windows.Forms.Label
        Me.settNoCols = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.settBBS = New System.Windows.Forms.Label
        Me.settLFExt = New System.Windows.Forms.Label
        Me.settVidCodec = New System.Windows.Forms.Label
        Me.settVidFmt = New System.Windows.Forms.Label
        Me.settVideo = New System.Windows.Forms.Label
        Me.settExt = New System.Windows.Forms.Label
        Me.settExist = New System.Windows.Forms.Label
        Me.settSauce = New System.Windows.Forms.Label
        Me.settGen = New System.Windows.Forms.Label
        Me.pIMGSett = New System.Windows.Forms.Panel
        Me.settUTF = New System.Windows.Forms.Label
        Me.settAnim = New System.Windows.Forms.Label
        Me.settSanitize = New System.Windows.Forms.Label
        Me.settHTMLFont = New System.Windows.Forms.Label
        Me.settHTMLObj = New System.Windows.Forms.Label
        Me.cntWC2 = New System.Windows.Forms.Label
        Me.in2Wildcat2 = New System.Windows.Forms.CheckBox
        Me.cntWC3 = New System.Windows.Forms.Label
        Me.in2Wildcat3 = New System.Windows.Forms.CheckBox
        Me.cntAVT = New System.Windows.Forms.Label
        Me.in2Avatar = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pCPout.SuspendLayout()
        Me.pOutPath.SuspendLayout()
        Me.pOut.SuspendLayout()
        Me.pCPin.SuspendLayout()
        Me.pIn.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pIMGSett.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.Yellow
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Quick Help"
        '
        'btnAdd
        '
        Me.btnAdd.BeginColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.EndColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAdd.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnAdd.Location = New System.Drawing.Point(537, 66)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(68, 25)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Add files to process" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the list")
        Me.btnAdd.UseCompatibleTextRendering = True
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.BeginColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRemove.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemove.EndColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRemove.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnRemove.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnRemove.Location = New System.Drawing.Point(609, 66)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(69, 25)
        Me.btnRemove.TabIndex = 14
        Me.btnRemove.Text = "Remove"
        Me.ToolTip1.SetToolTip(Me.btnRemove, "remove selected " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files from the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files to be processed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file list")
        Me.btnRemove.UseCompatibleTextRendering = True
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BeginColor = System.Drawing.Color.Red
        Me.btnClear.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.EndColor = System.Drawing.Color.Maroon
        Me.btnClear.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClear.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnClear.Location = New System.Drawing.Point(682, 66)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(64, 25)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.btnClear, "clear input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file list completely")
        Me.btnClear.UseCompatibleTextRendering = True
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'numASCII
        '
        Me.numASCII.Location = New System.Drawing.Point(817, 256)
        Me.numASCII.Name = "numASCII"
        Me.numASCII.Size = New System.Drawing.Size(47, 15)
        Me.numASCII.TabIndex = 20
        Me.numASCII.Text = "0"
        Me.numASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.numASCII, "Number of Non-Unicode encoded" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files in the file listing box")
        '
        'numUTF16
        '
        Me.numUTF16.ForeColor = System.Drawing.Color.Navy
        Me.numUTF16.Location = New System.Drawing.Point(817, 216)
        Me.numUTF16.Name = "numUTF16"
        Me.numUTF16.Size = New System.Drawing.Size(47, 15)
        Me.numUTF16.TabIndex = 21
        Me.numUTF16.Text = "0"
        Me.numUTF16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.numUTF16, "Number of UTF-16 Unicode encoded" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files in the file listing box")
        '
        'numUTF8
        '
        Me.numUTF8.ForeColor = System.Drawing.Color.DarkRed
        Me.numUTF8.Location = New System.Drawing.Point(817, 176)
        Me.numUTF8.Name = "numUTF8"
        Me.numUTF8.Size = New System.Drawing.Size(47, 15)
        Me.numUTF8.TabIndex = 23
        Me.numUTF8.Text = "0"
        Me.numUTF8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.numUTF8, "Number of UTF-8 Unicode encoded" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files in the file listing box")
        '
        'numTotal
        '
        Me.numTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numTotal.Location = New System.Drawing.Point(817, 308)
        Me.numTotal.Name = "numTotal"
        Me.numTotal.Size = New System.Drawing.Size(47, 15)
        Me.numTotal.TabIndex = 34
        Me.numTotal.Text = "0"
        Me.numTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.numTotal, "Total Number of files in the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file listing box of any type of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "encoding and form" & _
                "at.")
        '
        'lblLogAndInfos
        '
        Me.lblLogAndInfos.AutoSize = True
        Me.lblLogAndInfos.BackColor = System.Drawing.Color.White
        Me.lblLogAndInfos.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogAndInfos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblLogAndInfos.Location = New System.Drawing.Point(145, 393)
        Me.lblLogAndInfos.Name = "lblLogAndInfos"
        Me.lblLogAndInfos.Size = New System.Drawing.Size(218, 38)
        Me.lblLogAndInfos.TabIndex = 39
        Me.lblLogAndInfos.Text = "Log and Infos"
        Me.ToolTip1.SetToolTip(Me.lblLogAndInfos, "Output messages as log," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "showing information about" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the current files being proce" & _
                "ssed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as well as warnings and errors.")
        '
        'numSel
        '
        Me.numSel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.numSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numSel.Location = New System.Drawing.Point(814, 89)
        Me.numSel.Name = "numSel"
        Me.numSel.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.numSel.Size = New System.Drawing.Size(47, 15)
        Me.numSel.TabIndex = 32
        Me.numSel.Text = "0"
        Me.numSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.numSel, "Number of files in the input " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file list that are currently " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "selected and could " & _
                "be removed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from the list, leaving any other" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "non-selected file still in the lis" & _
                "t.")
        '
        'btnSelNone
        '
        Me.btnSelNone.BackColor = System.Drawing.Color.Transparent
        Me.btnSelNone.BeginColor = System.Drawing.Color.Yellow
        Me.btnSelNone.BeginColorDisabled = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSelNone.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelNone.EndColor = System.Drawing.Color.Red
        Me.btnSelNone.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSelNone.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSelNone.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSelNone.Location = New System.Drawing.Point(720, 66)
        Me.btnSelNone.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.btnSelNone.Name = "btnSelNone"
        Me.btnSelNone.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnSelNone.Size = New System.Drawing.Size(78, 25)
        Me.btnSelNone.TabIndex = 30
        Me.btnSelNone.Text = "Select None"
        Me.ToolTip1.SetToolTip(Me.btnSelNone, "clear input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "file list completely")
        Me.btnSelNone.UseCompatibleTextRendering = True
        Me.btnSelNone.UseVisualStyleBackColor = False
        Me.btnSelNone.Visible = False
        '
        'btnStart
        '
        Me.btnStart.BeginColor = System.Drawing.Color.Green
        Me.btnStart.BeginColorDisabled = System.Drawing.Color.Gray
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.EndColor = System.Drawing.Color.Lime
        Me.btnStart.EndColorDisabled = System.Drawing.Color.Silver
        Me.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnStart.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnStart.Location = New System.Drawing.Point(537, 374)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(154, 81)
        Me.btnStart.TabIndex = 16
        Me.btnStart.Text = "Convert"
        Me.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolTip1.SetToolTip(Me.btnStart, "start converting all files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the input file list")
        Me.btnStart.UseCompatibleTextRendering = True
        Me.btnStart.UseMnemonic = False
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'lblDropHere
        '
        Me.lblDropHere.AllowDrop = True
        Me.lblDropHere.AutoSize = True
        Me.lblDropHere.BackColor = System.Drawing.Color.White
        Me.lblDropHere.Font = New System.Drawing.Font("Arial Black", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDropHere.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDropHere.Location = New System.Drawing.Point(572, 193)
        Me.lblDropHere.Name = "lblDropHere"
        Me.lblDropHere.Size = New System.Drawing.Size(245, 38)
        Me.lblDropHere.TabIndex = 35
        Me.lblDropHere.Text = "Drop Files Here"
        Me.ToolTip1.SetToolTip(Me.lblDropHere, "Drop file from Windows" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "directly into this list" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for selection and future" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "proces" & _
                "sing.")
        Me.lblDropHere.Visible = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnQuit.BeginColor = System.Drawing.Color.Maroon
        Me.btnQuit.BeginColorDisabled = System.Drawing.Color.DimGray
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.EndColor = System.Drawing.Color.Red
        Me.btnQuit.EndColorDisabled = System.Drawing.Color.Navy
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnQuit.ForeColorDisabled = System.Drawing.Color.Navy
        Me.btnQuit.Location = New System.Drawing.Point(694, 374)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(101, 81)
        Me.btnQuit.TabIndex = 17
        Me.btnQuit.Text = "Quit"
        Me.ToolTip1.SetToolTip(Me.btnQuit, "quit the converter" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "application now")
        Me.btnQuit.UseCompatibleTextRendering = True
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'lblCPin
        '
        Me.lblCPin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPin.ForeColor = System.Drawing.Color.Black
        Me.lblCPin.Location = New System.Drawing.Point(-4, 3)
        Me.lblCPin.Name = "lblCPin"
        Me.lblCPin.Size = New System.Drawing.Size(110, 20)
        Me.lblCPin.TabIndex = 28
        Me.lblCPin.Text = "Code Page (In)"
        Me.lblCPin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblCPin, resources.GetString("lblCPin.ToolTip"))
        Me.lblCPin.UseCompatibleTextRendering = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.Silver
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Yellow
        Me.LinkLabel1.LinkArea = New System.Windows.Forms.LinkArea(1, 10)
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(686, 5)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(80, 17)
        Me.LinkLabel1.TabIndex = 41
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "(RoySAC.com)"
        Me.ToolTip1.SetToolTip(Me.LinkLabel1, "visit my website!")
        Me.LinkLabel1.UseCompatibleTextRendering = True
        '
        'btnUniBlocks
        '
        Me.btnUniBlocks.BeginColor = System.Drawing.Color.Teal
        Me.btnUniBlocks.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnUniBlocks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUniBlocks.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnUniBlocks.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnUniBlocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUniBlocks.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnUniBlocks.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnUniBlocks.Location = New System.Drawing.Point(660, 32)
        Me.btnUniBlocks.Name = "btnUniBlocks"
        Me.btnUniBlocks.Size = New System.Drawing.Size(74, 28)
        Me.btnUniBlocks.TabIndex = 52
        Me.btnUniBlocks.Text = "UTF Sets"
        Me.ToolTip1.SetToolTip(Me.btnUniBlocks, "List Unicode Character Sets")
        Me.btnUniBlocks.UseCompatibleTextRendering = True
        Me.btnUniBlocks.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.BeginColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSettings.BeginColorDisabled = System.Drawing.Color.Yellow
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.EndColor = System.Drawing.Color.Lime
        Me.btnSettings.EndColorDisabled = System.Drawing.Color.Silver
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Lucida Console", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSettings.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSettings.Location = New System.Drawing.Point(0, 0)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(44, 36)
        Me.btnSettings.TabIndex = 60
        Me.btnSettings.Text = "O"
        Me.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolTip1.SetToolTip(Me.btnSettings, "Open and Modify Programm Settings and Options")
        Me.btnSettings.UseCompatibleTextRendering = True
        Me.btnSettings.UseMnemonic = False
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnSettings2
        '
        Me.btnSettings2.BeginColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSettings2.BeginColorDisabled = System.Drawing.Color.Yellow
        Me.btnSettings2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings2.EndColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings2.EndColorDisabled = System.Drawing.Color.Silver
        Me.btnSettings2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSettings2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSettings2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue
        Me.btnSettings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings2.Font = New System.Drawing.Font("Lucida Console", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSettings2.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSettings2.Location = New System.Drawing.Point(798, 374)
        Me.btnSettings2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSettings2.Name = "btnSettings2"
        Me.btnSettings2.Size = New System.Drawing.Size(44, 81)
        Me.btnSettings2.TabIndex = 61
        Me.btnSettings2.Text = "O"
        Me.btnSettings2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ToolTip1.SetToolTip(Me.btnSettings2, "Open and Modify Programm Settings and Options")
        Me.btnSettings2.UseCompatibleTextRendering = True
        Me.btnSettings2.UseMnemonic = False
        Me.btnSettings2.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'lblNumUTF16
        '
        Me.lblNumUTF16.BackColor = System.Drawing.Color.DimGray
        Me.lblNumUTF16.ForeColor = System.Drawing.Color.Navy
        Me.lblNumUTF16.Location = New System.Drawing.Point(817, 201)
        Me.lblNumUTF16.Name = "lblNumUTF16"
        Me.lblNumUTF16.Size = New System.Drawing.Size(47, 13)
        Me.lblNumUTF16.TabIndex = 18
        Me.lblNumUTF16.Text = "UTF-16"
        Me.lblNumUTF16.UseCompatibleTextRendering = True
        '
        'lblNUmASCII
        '
        Me.lblNUmASCII.BackColor = System.Drawing.Color.Gray
        Me.lblNUmASCII.ForeColor = System.Drawing.Color.Black
        Me.lblNUmASCII.Location = New System.Drawing.Point(817, 241)
        Me.lblNUmASCII.Name = "lblNUmASCII"
        Me.lblNUmASCII.Size = New System.Drawing.Size(47, 13)
        Me.lblNUmASCII.TabIndex = 19
        Me.lblNUmASCII.Text = "US-ASC"
        Me.lblNUmASCII.UseCompatibleTextRendering = True
        '
        'lblNumUTF8
        '
        Me.lblNumUTF8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblNumUTF8.ForeColor = System.Drawing.Color.Red
        Me.lblNumUTF8.Location = New System.Drawing.Point(817, 158)
        Me.lblNumUTF8.Name = "lblNumUTF8"
        Me.lblNumUTF8.Size = New System.Drawing.Size(47, 15)
        Me.lblNumUTF8.TabIndex = 22
        Me.lblNumUTF8.Text = "UTF-8"
        Me.lblNumUTF8.UseCompatibleTextRendering = True
        '
        'log
        '
        Me.log.AcceptsTab = True
        Me.log.BackColor = System.Drawing.Color.White
        Me.log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.log.CausesValidation = False
        Me.log.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.log.ForeColor = System.Drawing.Color.DimGray
        Me.log.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.log.Location = New System.Drawing.Point(4, 368)
        Me.log.Margin = New System.Windows.Forms.Padding(1)
        Me.log.Name = "log"
        Me.log.ReadOnly = True
        Me.log.Size = New System.Drawing.Size(504, 94)
        Me.log.TabIndex = 27
        Me.log.Text = ""
        Me.log.WordWrap = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(817, 290)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Total"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.UseCompatibleTextRendering = True
        '
        'lblSelected
        '
        Me.lblSelected.BackColor = System.Drawing.Color.Gray
        Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelected.ForeColor = System.Drawing.Color.Yellow
        Me.lblSelected.Location = New System.Drawing.Point(814, 74)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(47, 13)
        Me.lblSelected.TabIndex = 31
        Me.lblSelected.Text = "Selected"
        Me.lblSelected.UseCompatibleTextRendering = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ANSI_ASCII_Converter.My.Resources.Resources.RoyAvt6faster1
        Me.PictureBox2.Location = New System.Drawing.Point(805, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(54, 50)
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.btnSelNone)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.numSel)
        Me.Panel1.Controls.Add(Me.lblSelected)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 471)
        Me.Panel1.TabIndex = 38
        Me.Panel1.Tag = "lblRemComplete"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblDebugOnOff)
        Me.Panel2.Controls.Add(Me.btnSettings2)
        Me.Panel2.Controls.Add(Me.pCPInEmpty)
        Me.Panel2.Controls.Add(Me.XPanel1)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.btnNFO)
        Me.Panel2.Controls.Add(Me.VersionDate)
        Me.Panel2.Controls.Add(Me.Version)
        Me.Panel2.Controls.Add(Me.lblVersion)
        Me.Panel2.Controls.Add(Me.btnUniBlocks)
        Me.Panel2.Controls.Add(Me.btnCPMaps)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.pCPout)
        Me.Panel2.Controls.Add(Me.pCPOutEmpty)
        Me.Panel2.Controls.Add(Me.pOutPath)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.pOut)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.pCPin)
        Me.Panel2.Controls.Add(Me.pIn)
        Me.Panel2.Controls.Add(Me.btnQuit)
        Me.Panel2.Controls.Add(Me.lblDropHere)
        Me.Panel2.Controls.Add(Me.listFiles)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.btnStart)
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(-29, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 473)
        Me.Panel2.TabIndex = 29
        '
        'lblDebugOnOff
        '
        Me.lblDebugOnOff.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDebugOnOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebugOnOff.ForeColor = System.Drawing.Color.Red
        Me.lblDebugOnOff.Location = New System.Drawing.Point(856, 362)
        Me.lblDebugOnOff.Name = "lblDebugOnOff"
        Me.lblDebugOnOff.Size = New System.Drawing.Size(10, 10)
        Me.lblDebugOnOff.TabIndex = 62
        Me.lblDebugOnOff.Text = "*"
        Me.lblDebugOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDebugOnOff.UseCompatibleTextRendering = True
        '
        'pCPInEmpty
        '
        Me.pCPInEmpty.BackColor = System.Drawing.Color.Gray
        Me.pCPInEmpty.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pCPInEmpty.Location = New System.Drawing.Point(28, 344)
        Me.pCPInEmpty.Name = "pCPInEmpty"
        Me.pCPInEmpty.Size = New System.Drawing.Size(508, 10)
        Me.pCPInEmpty.TabIndex = 60
        Me.pCPInEmpty.Tag = "CP437"
        '
        'btnSearch
        '
        Me.btnSearch.BeginColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearch.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSearch.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnSearch.Location = New System.Drawing.Point(737, 32)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(85, 28)
        Me.btnSearch.TabIndex = 58
        Me.btnSearch.Text = "UTF Search"
        Me.btnSearch.UseCompatibleTextRendering = True
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnNFO
        '
        Me.btnNFO.BackColor = System.Drawing.Color.Blue
        Me.btnNFO.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.BG25pxg
        Me.btnNFO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNFO.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnNFO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnNFO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnNFO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNFO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNFO.ForeColor = System.Drawing.Color.Gray
        Me.btnNFO.Location = New System.Drawing.Point(780, 3)
        Me.btnNFO.Name = "btnNFO"
        Me.btnNFO.Size = New System.Drawing.Size(39, 26)
        Me.btnNFO.TabIndex = 57
        Me.btnNFO.Text = "NFO"
        Me.btnNFO.UseCompatibleTextRendering = True
        Me.btnNFO.UseVisualStyleBackColor = False
        '
        'VersionDate
        '
        Me.VersionDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionDate.ForeColor = System.Drawing.Color.Goldenrod
        Me.VersionDate.Location = New System.Drawing.Point(839, 441)
        Me.VersionDate.Name = "VersionDate"
        Me.VersionDate.Size = New System.Drawing.Size(46, 14)
        Me.VersionDate.TabIndex = 56
        Me.VersionDate.Text = "01.1900"
        Me.VersionDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.VersionDate.UseCompatibleTextRendering = True
        '
        'Version
        '
        Me.Version.ForeColor = System.Drawing.Color.Yellow
        Me.Version.Location = New System.Drawing.Point(839, 430)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(46, 14)
        Me.Version.TabIndex = 55
        Me.Version.Text = "0.00"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Version.UseCompatibleTextRendering = True
        '
        'lblVersion
        '
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(840, 416)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(46, 12)
        Me.lblVersion.TabIndex = 54
        Me.lblVersion.Text = "Version:"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVersion.UseCompatibleTextRendering = True
        '
        'btnCPMaps
        '
        Me.btnCPMaps.BeginColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCPMaps.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnCPMaps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCPMaps.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnCPMaps.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnCPMaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCPMaps.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCPMaps.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnCPMaps.Location = New System.Drawing.Point(610, 32)
        Me.btnCPMaps.Name = "btnCPMaps"
        Me.btnCPMaps.Size = New System.Drawing.Size(48, 28)
        Me.btnCPMaps.TabIndex = 51
        Me.btnCPMaps.Text = "CP's"
        Me.btnCPMaps.UseCompatibleTextRendering = True
        Me.btnCPMaps.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkRed
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(607, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "aka Roy/SAC"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(390, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 12)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "written by Carsten Cumbrowski"
        '
        'pCPout
        '
        Me.pCPout.BackColor = System.Drawing.Color.Silver
        Me.pCPout.Controls.Add(Me.lblCPout)
        Me.pCPout.Controls.Add(Me.outCP)
        Me.pCPout.Location = New System.Drawing.Point(28, 165)
        Me.pCPout.Name = "pCPout"
        Me.pCPout.Size = New System.Drawing.Size(508, 23)
        Me.pCPout.TabIndex = 46
        Me.pCPout.Tag = "CP437"
        Me.pCPout.Visible = False
        '
        'lblCPout
        '
        Me.lblCPout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPout.ForeColor = System.Drawing.Color.Black
        Me.lblCPout.Location = New System.Drawing.Point(-2, 0)
        Me.lblCPout.Name = "lblCPout"
        Me.lblCPout.Size = New System.Drawing.Size(110, 20)
        Me.lblCPout.TabIndex = 28
        Me.lblCPout.Text = "Code Page (Out)"
        Me.lblCPout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCPout.UseCompatibleTextRendering = True
        '
        'outCP
        '
        Me.outCP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.outCP.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outCP.Location = New System.Drawing.Point(110, 2)
        Me.outCP.Name = "outCP"
        Me.outCP.Size = New System.Drawing.Size(346, 17)
        Me.outCP.TabIndex = 27
        '
        'pCPOutEmpty
        '
        Me.pCPOutEmpty.BackColor = System.Drawing.Color.Silver
        Me.pCPOutEmpty.Location = New System.Drawing.Point(3, 334)
        Me.pCPOutEmpty.Name = "pCPOutEmpty"
        Me.pCPOutEmpty.Size = New System.Drawing.Size(508, 10)
        Me.pCPOutEmpty.TabIndex = 60
        Me.pCPOutEmpty.Tag = "CP437"
        '
        'pOutPath
        '
        Me.pOutPath.BackColor = System.Drawing.Color.LightGray
        Me.pOutPath.Controls.Add(Me.lblExt)
        Me.pOutPath.Controls.Add(Me.lblInfoSameDirOut)
        Me.pOutPath.Controls.Add(Me.txtExt)
        Me.pOutPath.Controls.Add(Me.btnOutputFolder)
        Me.pOutPath.Controls.Add(Me.rOutPathInput)
        Me.pOutPath.Controls.Add(Me.outPath)
        Me.pOutPath.Controls.Add(Me.rOutPathNew)
        Me.pOutPath.Location = New System.Drawing.Point(28, 190)
        Me.pOutPath.Name = "pOutPath"
        Me.pOutPath.Size = New System.Drawing.Size(508, 32)
        Me.pOutPath.TabIndex = 45
        Me.pOutPath.Tag = "INPUT"
        '
        'lblExt
        '
        Me.lblExt.AutoSize = True
        Me.lblExt.BackColor = System.Drawing.Color.Transparent
        Me.lblExt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExt.ForeColor = System.Drawing.Color.Black
        Me.lblExt.Location = New System.Drawing.Point(418, 7)
        Me.lblExt.Name = "lblExt"
        Me.lblExt.Size = New System.Drawing.Size(25, 15)
        Me.lblExt.TabIndex = 17
        Me.lblExt.Text = "Ext:"
        '
        'lblInfoSameDirOut
        '
        Me.lblInfoSameDirOut.AutoSize = True
        Me.lblInfoSameDirOut.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoSameDirOut.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoSameDirOut.ForeColor = System.Drawing.Color.Black
        Me.lblInfoSameDirOut.Location = New System.Drawing.Point(467, 9)
        Me.lblInfoSameDirOut.Name = "lblInfoSameDirOut"
        Me.lblInfoSameDirOut.Size = New System.Drawing.Size(239, 13)
        Me.lblInfoSameDirOut.TabIndex = 16
        Me.lblInfoSameDirOut.Text = "Input Folder is Output Folder"
        Me.lblInfoSameDirOut.Visible = False
        '
        'txtExt
        '
        Me.txtExt.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExt.Location = New System.Drawing.Point(444, 4)
        Me.txtExt.Margin = New System.Windows.Forms.Padding(1, 5, 1, 1)
        Me.txtExt.MaximumSize = New System.Drawing.Size(75, 20)
        Me.txtExt.Name = "txtExt"
        Me.txtExt.Size = New System.Drawing.Size(55, 20)
        Me.txtExt.TabIndex = 15
        Me.txtExt.Text = "WEB"
        Me.txtExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOutputFolder
        '
        Me.btnOutputFolder.BeginColor = System.Drawing.SystemColors.Control
        Me.btnOutputFolder.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnOutputFolder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOutputFolder.EndColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnOutputFolder.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnOutputFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOutputFolder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnOutputFolder.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnOutputFolder.Location = New System.Drawing.Point(396, 4)
        Me.btnOutputFolder.Name = "btnOutputFolder"
        Me.btnOutputFolder.Size = New System.Drawing.Size(20, 22)
        Me.btnOutputFolder.TabIndex = 14
        Me.btnOutputFolder.Text = ">"
        Me.btnOutputFolder.UseVisualStyleBackColor = True
        '
        'rOutPathInput
        '
        Me.rOutPathInput.Appearance = System.Windows.Forms.Appearance.Button
        Me.rOutPathInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rOutPathInput.Checked = True
        Me.rOutPathInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rOutPathInput.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rOutPathInput.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rOutPathInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rOutPathInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rOutPathInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rOutPathInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rOutPathInput.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rOutPathInput.Location = New System.Drawing.Point(6, 4)
        Me.rOutPathInput.Name = "rOutPathInput"
        Me.rOutPathInput.Size = New System.Drawing.Size(58, 20)
        Me.rOutPathInput.TabIndex = 11
        Me.rOutPathInput.TabStop = True
        Me.rOutPathInput.Tag = "INPUT"
        Me.rOutPathInput.Text = "As Input"
        Me.rOutPathInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rOutPathInput.UseCompatibleTextRendering = True
        Me.rOutPathInput.UseVisualStyleBackColor = False
        '
        'outPath
        '
        Me.outPath.BackColor = System.Drawing.Color.White
        Me.outPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.outPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outPath.ForeColor = System.Drawing.Color.Navy
        Me.outPath.FullText = Nothing
        Me.outPath.FullTextLineAlignment = MyControls.PartialPathDisplayLabel.VAlign.Middle
        Me.outPath.FullTextStringAlignment = MyControls.PartialPathDisplayLabel.Align.Left
        Me.outPath.Location = New System.Drawing.Point(115, 4)
        Me.outPath.Name = "outPath"
        Me.outPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.outPath.Size = New System.Drawing.Size(278, 22)
        Me.outPath.TabIndex = 13
        '
        'rOutPathNew
        '
        Me.rOutPathNew.Appearance = System.Windows.Forms.Appearance.Button
        Me.rOutPathNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rOutPathNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rOutPathNew.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.rOutPathNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rOutPathNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.rOutPathNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.rOutPathNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rOutPathNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rOutPathNew.Location = New System.Drawing.Point(69, 4)
        Me.rOutPathNew.Name = "rOutPathNew"
        Me.rOutPathNew.Size = New System.Drawing.Size(42, 20)
        Me.rOutPathNew.TabIndex = 12
        Me.rOutPathNew.Tag = "NEW"
        Me.rOutPathNew.Text = "New"
        Me.rOutPathNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rOutPathNew.UseCompatibleTextRendering = True
        Me.rOutPathNew.UseVisualStyleBackColor = False
        '
        'pOut
        '
        Me.pOut.BackColor = System.Drawing.Color.DarkGray
        Me.pOut.Controls.Add(Me.outVideo)
        Me.pOut.Controls.Add(Me.btnSettings)
        Me.pOut.Controls.Add(Me.outImage)
        Me.pOut.Controls.Add(Me.lblOutput)
        Me.pOut.Controls.Add(Me.outBinary)
        Me.pOut.Controls.Add(Me.outBBS)
        Me.pOut.Controls.Add(Me.outUnicode)
        Me.pOut.Controls.Add(Me.outHTML)
        Me.pOut.Controls.Add(Me.outANSI)
        Me.pOut.Controls.Add(Me.outASCII)
        Me.pOut.Location = New System.Drawing.Point(28, 128)
        Me.pOut.Name = "pOut"
        Me.pOut.Size = New System.Drawing.Size(508, 35)
        Me.pOut.TabIndex = 43
        Me.pOut.Tag = "-"
        Me.pOut.Visible = False
        '
        'outVideo
        '
        Me.outVideo.Appearance = System.Windows.Forms.Appearance.Button
        Me.outVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outVideo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outVideo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outVideo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outVideo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outVideo.Location = New System.Drawing.Point(462, 3)
        Me.outVideo.Name = "outVideo"
        Me.outVideo.Size = New System.Drawing.Size(42, 28)
        Me.outVideo.TabIndex = 61
        Me.outVideo.Tag = "AVI"
        Me.outVideo.Text = "VID"
        Me.outVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outVideo.UseCompatibleTextRendering = True
        Me.outVideo.UseVisualStyleBackColor = False
        '
        'outImage
        '
        Me.outImage.Appearance = System.Windows.Forms.Appearance.Button
        Me.outImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outImage.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outImage.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outImage.Location = New System.Drawing.Point(414, 4)
        Me.outImage.Name = "outImage"
        Me.outImage.Size = New System.Drawing.Size(42, 28)
        Me.outImage.TabIndex = 13
        Me.outImage.Tag = "IMG"
        Me.outImage.Text = "IMG"
        Me.outImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outImage.UseCompatibleTextRendering = True
        Me.outImage.UseVisualStyleBackColor = False
        '
        'lblOutput
        '
        Me.lblOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutput.ForeColor = System.Drawing.Color.Black
        Me.lblOutput.Location = New System.Drawing.Point(39, 5)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(67, 24)
        Me.lblOutput.TabIndex = 12
        Me.lblOutput.Text = "Output"
        Me.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOutput.UseCompatibleTextRendering = True
        '
        'outBinary
        '
        Me.outBinary.Appearance = System.Windows.Forms.Appearance.Button
        Me.outBinary.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outBinary.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outBinary.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outBinary.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outBinary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outBinary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outBinary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outBinary.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outBinary.Location = New System.Drawing.Point(367, 4)
        Me.outBinary.Name = "outBinary"
        Me.outBinary.Size = New System.Drawing.Size(42, 28)
        Me.outBinary.TabIndex = 5
        Me.outBinary.Tag = "BIN"
        Me.outBinary.Text = "BIN"
        Me.outBinary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outBinary.UseCompatibleTextRendering = True
        Me.outBinary.UseVisualStyleBackColor = False
        '
        'outBBS
        '
        Me.outBBS.Appearance = System.Windows.Forms.Appearance.Button
        Me.outBBS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outBBS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outBBS.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outBBS.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outBBS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outBBS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outBBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outBBS.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outBBS.Location = New System.Drawing.Point(319, 4)
        Me.outBBS.Name = "outBBS"
        Me.outBBS.Size = New System.Drawing.Size(42, 28)
        Me.outBBS.TabIndex = 4
        Me.outBBS.Tag = "BBS"
        Me.outBBS.Text = "BBS"
        Me.outBBS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outBBS.UseCompatibleTextRendering = True
        Me.outBBS.UseVisualStyleBackColor = False
        '
        'outUnicode
        '
        Me.outUnicode.Appearance = System.Windows.Forms.Appearance.Button
        Me.outUnicode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outUnicode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outUnicode.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outUnicode.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outUnicode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outUnicode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outUnicode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outUnicode.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outUnicode.Location = New System.Drawing.Point(271, 4)
        Me.outUnicode.Name = "outUnicode"
        Me.outUnicode.Size = New System.Drawing.Size(42, 28)
        Me.outUnicode.TabIndex = 3
        Me.outUnicode.Tag = "UTF"
        Me.outUnicode.Text = "UTF"
        Me.outUnicode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outUnicode.UseCompatibleTextRendering = True
        Me.outUnicode.UseVisualStyleBackColor = False
        '
        'outHTML
        '
        Me.outHTML.Appearance = System.Windows.Forms.Appearance.Button
        Me.outHTML.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outHTML.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outHTML.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outHTML.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outHTML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outHTML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outHTML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outHTML.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outHTML.Location = New System.Drawing.Point(216, 4)
        Me.outHTML.Margin = New System.Windows.Forms.Padding(0)
        Me.outHTML.Name = "outHTML"
        Me.outHTML.Size = New System.Drawing.Size(49, 28)
        Me.outHTML.TabIndex = 2
        Me.outHTML.Tag = "HTML"
        Me.outHTML.Text = "HTML"
        Me.outHTML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outHTML.UseCompatibleTextRendering = True
        Me.outHTML.UseVisualStyleBackColor = False
        '
        'outANSI
        '
        Me.outANSI.Appearance = System.Windows.Forms.Appearance.Button
        Me.outANSI.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outANSI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outANSI.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outANSI.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outANSI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outANSI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outANSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outANSI.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outANSI.Location = New System.Drawing.Point(166, 4)
        Me.outANSI.Name = "outANSI"
        Me.outANSI.Size = New System.Drawing.Size(44, 28)
        Me.outANSI.TabIndex = 1
        Me.outANSI.Tag = "ANS"
        Me.outANSI.Text = "ANSI"
        Me.outANSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outANSI.UseCompatibleTextRendering = True
        Me.outANSI.UseVisualStyleBackColor = False
        '
        'outASCII
        '
        Me.outASCII.Appearance = System.Windows.Forms.Appearance.Button
        Me.outASCII.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.outASCII.Cursor = System.Windows.Forms.Cursors.Hand
        Me.outASCII.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.outASCII.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.outASCII.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.outASCII.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.outASCII.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.outASCII.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.outASCII.Location = New System.Drawing.Point(110, 4)
        Me.outASCII.Name = "outASCII"
        Me.outASCII.Size = New System.Drawing.Size(50, 28)
        Me.outASCII.TabIndex = 0
        Me.outASCII.Tag = "ASC"
        Me.outASCII.Text = "ASCII"
        Me.outASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.outASCII.UseCompatibleTextRendering = True
        Me.outASCII.UseVisualStyleBackColor = False
        '
        'pCPin
        '
        Me.pCPin.BackColor = System.Drawing.Color.Gray
        Me.pCPin.Controls.Add(Me.lblCPin)
        Me.pCPin.Controls.Add(Me.inCP)
        Me.pCPin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pCPin.Location = New System.Drawing.Point(28, 102)
        Me.pCPin.Name = "pCPin"
        Me.pCPin.Size = New System.Drawing.Size(508, 24)
        Me.pCPin.TabIndex = 39
        Me.pCPin.Tag = "CP437"
        Me.pCPin.Visible = False
        '
        'inCP
        '
        Me.inCP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.inCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.inCP.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inCP.Location = New System.Drawing.Point(110, 4)
        Me.inCP.Name = "inCP"
        Me.inCP.Size = New System.Drawing.Size(346, 17)
        Me.inCP.TabIndex = 27
        '
        'pIn
        '
        Me.pIn.BackColor = System.Drawing.Color.DimGray
        Me.pIn.Controls.Add(Me.cntAVT)
        Me.pIn.Controls.Add(Me.in2Avatar)
        Me.pIn.Controls.Add(Me.cntWC3)
        Me.pIn.Controls.Add(Me.in2Wildcat3)
        Me.pIn.Controls.Add(Me.cntWC2)
        Me.pIn.Controls.Add(Me.in2Wildcat2)
        Me.pIn.Controls.Add(Me.cntBIN)
        Me.pIn.Controls.Add(Me.cntPCB)
        Me.pIn.Controls.Add(Me.cntUNI)
        Me.pIn.Controls.Add(Me.cntHTML)
        Me.pIn.Controls.Add(Me.cntANSI)
        Me.pIn.Controls.Add(Me.cntASCII)
        Me.pIn.Controls.Add(Me.in2Binary)
        Me.pIn.Controls.Add(Me.in2PCBoard)
        Me.pIn.Controls.Add(Me.in2Unicode)
        Me.pIn.Controls.Add(Me.in2HTML)
        Me.pIn.Controls.Add(Me.in2ANSI)
        Me.pIn.Controls.Add(Me.in2ASCII)
        Me.pIn.Controls.Add(Me.lblInputFormats)
        Me.pIn.Location = New System.Drawing.Point(28, 59)
        Me.pIn.Name = "pIn"
        Me.pIn.Size = New System.Drawing.Size(508, 42)
        Me.pIn.TabIndex = 4
        Me.pIn.Tag = "NONE"
        '
        'cntBIN
        '
        Me.cntBIN.BackColor = System.Drawing.Color.DarkGray
        Me.cntBIN.Location = New System.Drawing.Point(320, 24)
        Me.cntBIN.Name = "cntBIN"
        Me.cntBIN.Size = New System.Drawing.Size(40, 15)
        Me.cntBIN.TabIndex = 59
        Me.cntBIN.Text = "0"
        Me.cntBIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntBIN.UseCompatibleTextRendering = True
        '
        'cntPCB
        '
        Me.cntPCB.BackColor = System.Drawing.Color.DarkGray
        Me.cntPCB.Location = New System.Drawing.Point(278, 24)
        Me.cntPCB.Name = "cntPCB"
        Me.cntPCB.Size = New System.Drawing.Size(40, 15)
        Me.cntPCB.TabIndex = 58
        Me.cntPCB.Text = "0"
        Me.cntPCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntPCB.UseCompatibleTextRendering = True
        '
        'cntUNI
        '
        Me.cntUNI.BackColor = System.Drawing.Color.DarkGray
        Me.cntUNI.Location = New System.Drawing.Point(236, 24)
        Me.cntUNI.Name = "cntUNI"
        Me.cntUNI.Size = New System.Drawing.Size(40, 15)
        Me.cntUNI.TabIndex = 57
        Me.cntUNI.Text = "0"
        Me.cntUNI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntUNI.UseCompatibleTextRendering = True
        '
        'cntHTML
        '
        Me.cntHTML.BackColor = System.Drawing.Color.DarkGray
        Me.cntHTML.Location = New System.Drawing.Point(194, 24)
        Me.cntHTML.Name = "cntHTML"
        Me.cntHTML.Size = New System.Drawing.Size(40, 15)
        Me.cntHTML.TabIndex = 56
        Me.cntHTML.Text = "0"
        Me.cntHTML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntHTML.UseCompatibleTextRendering = True
        '
        'cntANSI
        '
        Me.cntANSI.BackColor = System.Drawing.Color.DarkGray
        Me.cntANSI.Location = New System.Drawing.Point(152, 24)
        Me.cntANSI.Name = "cntANSI"
        Me.cntANSI.Size = New System.Drawing.Size(40, 15)
        Me.cntANSI.TabIndex = 55
        Me.cntANSI.Text = "0"
        Me.cntANSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntANSI.UseCompatibleTextRendering = True
        '
        'cntASCII
        '
        Me.cntASCII.BackColor = System.Drawing.Color.DarkGray
        Me.cntASCII.Location = New System.Drawing.Point(110, 24)
        Me.cntASCII.Name = "cntASCII"
        Me.cntASCII.Size = New System.Drawing.Size(40, 15)
        Me.cntASCII.TabIndex = 54
        Me.cntASCII.Text = "0"
        Me.cntASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntASCII.UseCompatibleTextRendering = True
        '
        'in2Binary
        '
        Me.in2Binary.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2Binary.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2Binary.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2Binary.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2Binary.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2Binary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2Binary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2Binary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2Binary.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2Binary.Location = New System.Drawing.Point(320, 2)
        Me.in2Binary.Name = "in2Binary"
        Me.in2Binary.Size = New System.Drawing.Size(40, 20)
        Me.in2Binary.TabIndex = 23
        Me.in2Binary.Tag = "BIN"
        Me.in2Binary.Text = "BIN"
        Me.in2Binary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2Binary.UseCompatibleTextRendering = True
        Me.in2Binary.UseVisualStyleBackColor = False
        '
        'in2PCBoard
        '
        Me.in2PCBoard.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2PCBoard.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2PCBoard.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2PCBoard.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2PCBoard.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2PCBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2PCBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2PCBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2PCBoard.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2PCBoard.Location = New System.Drawing.Point(278, 2)
        Me.in2PCBoard.Name = "in2PCBoard"
        Me.in2PCBoard.Size = New System.Drawing.Size(40, 20)
        Me.in2PCBoard.TabIndex = 22
        Me.in2PCBoard.Tag = "PCB"
        Me.in2PCBoard.Text = "PCB"
        Me.in2PCBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2PCBoard.UseCompatibleTextRendering = True
        Me.in2PCBoard.UseVisualStyleBackColor = False
        '
        'in2Unicode
        '
        Me.in2Unicode.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2Unicode.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2Unicode.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2Unicode.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2Unicode.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2Unicode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2Unicode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2Unicode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2Unicode.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2Unicode.Location = New System.Drawing.Point(236, 2)
        Me.in2Unicode.Name = "in2Unicode"
        Me.in2Unicode.Size = New System.Drawing.Size(40, 20)
        Me.in2Unicode.TabIndex = 21
        Me.in2Unicode.Tag = "UTF"
        Me.in2Unicode.Text = "UTF"
        Me.in2Unicode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2Unicode.UseCompatibleTextRendering = True
        Me.in2Unicode.UseVisualStyleBackColor = False
        '
        'in2HTML
        '
        Me.in2HTML.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2HTML.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2HTML.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2HTML.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2HTML.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2HTML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2HTML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2HTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2HTML.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2HTML.Location = New System.Drawing.Point(194, 2)
        Me.in2HTML.Name = "in2HTML"
        Me.in2HTML.Size = New System.Drawing.Size(40, 20)
        Me.in2HTML.TabIndex = 20
        Me.in2HTML.Tag = "HTML"
        Me.in2HTML.Text = "HTM"
        Me.in2HTML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2HTML.UseCompatibleTextRendering = True
        Me.in2HTML.UseVisualStyleBackColor = False
        '
        'in2ANSI
        '
        Me.in2ANSI.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2ANSI.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2ANSI.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2ANSI.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2ANSI.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2ANSI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2ANSI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2ANSI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2ANSI.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2ANSI.Location = New System.Drawing.Point(152, 2)
        Me.in2ANSI.Name = "in2ANSI"
        Me.in2ANSI.Size = New System.Drawing.Size(40, 20)
        Me.in2ANSI.TabIndex = 19
        Me.in2ANSI.Tag = "ANS"
        Me.in2ANSI.Text = "ANS"
        Me.in2ANSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2ANSI.UseCompatibleTextRendering = True
        Me.in2ANSI.UseVisualStyleBackColor = False
        '
        'in2ASCII
        '
        Me.in2ASCII.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2ASCII.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2ASCII.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2ASCII.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2ASCII.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2ASCII.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2ASCII.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2ASCII.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2ASCII.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2ASCII.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2ASCII.Location = New System.Drawing.Point(110, 2)
        Me.in2ASCII.Margin = New System.Windows.Forms.Padding(0)
        Me.in2ASCII.Name = "in2ASCII"
        Me.in2ASCII.Size = New System.Drawing.Size(40, 20)
        Me.in2ASCII.TabIndex = 18
        Me.in2ASCII.Tag = "ASC"
        Me.in2ASCII.Text = "ASC"
        Me.in2ASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2ASCII.UseCompatibleTextRendering = True
        Me.in2ASCII.UseMnemonic = False
        Me.in2ASCII.UseVisualStyleBackColor = False
        '
        'lblInputFormats
        '
        Me.lblInputFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputFormats.ForeColor = System.Drawing.Color.Black
        Me.lblInputFormats.Location = New System.Drawing.Point(38, 10)
        Me.lblInputFormats.Name = "lblInputFormats"
        Me.lblInputFormats.Size = New System.Drawing.Size(60, 20)
        Me.lblInputFormats.TabIndex = 11
        Me.lblInputFormats.Text = "Input"
        Me.lblInputFormats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblInputFormats.UseCompatibleTextRendering = True
        '
        'listFiles
        '
        Me.listFiles.AllowDrop = True
        Me.listFiles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.listFiles.FormattingEnabled = True
        Me.listFiles.Location = New System.Drawing.Point(537, 91)
        Me.listFiles.Name = "listFiles"
        Me.listFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.listFiles.Size = New System.Drawing.Size(300, 277)
        Me.listFiles.TabIndex = 12
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ANSI_ASCII_Converter.My.Resources.Resources.ASCIIUnicodeConverter
        Me.PictureBox1.Location = New System.Drawing.Point(44, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(580, 70)
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'XPanel1
        '
        Me.XPanel1.BMP = Nothing
        Me.XPanel1.Controls.Add(Me.Panel5)
        Me.XPanel1.Controls.Add(Me.Panel3)
        Me.XPanel1.Controls.Add(Me.pIMGSett)
        Me.XPanel1.Location = New System.Drawing.Point(28, 225)
        Me.XPanel1.Name = "XPanel1"
        Me.XPanel1.Size = New System.Drawing.Size(508, 105)
        Me.XPanel1.TabIndex = 59
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.settSMALLFNT)
        Me.Panel5.Controls.Add(Me.settImgOut)
        Me.Panel5.Controls.Add(Me.settThumbs)
        Me.Panel5.Controls.Add(Me.attCreTh)
        Me.Panel5.Controls.Add(Me.settNoCols)
        Me.Panel5.Location = New System.Drawing.Point(5, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(268, 51)
        Me.Panel5.TabIndex = 83
        '
        'settSMALLFNT
        '
        Me.settSMALLFNT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settSMALLFNT.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settSMALLFNT.ForeColor = System.Drawing.Color.Black
        Me.settSMALLFNT.Location = New System.Drawing.Point(101, 7)
        Me.settSMALLFNT.Name = "settSMALLFNT"
        Me.settSMALLFNT.Size = New System.Drawing.Size(100, 12)
        Me.settSMALLFNT.TabIndex = 5
        Me.settSMALLFNT.Text = "/ 80x50 Mode"
        '
        'settImgOut
        '
        Me.settImgOut.AutoSize = True
        Me.settImgOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settImgOut.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settImgOut.ForeColor = System.Drawing.Color.Black
        Me.settImgOut.Location = New System.Drawing.Point(110, 21)
        Me.settImgOut.Name = "settImgOut"
        Me.settImgOut.Size = New System.Drawing.Size(96, 11)
        Me.settImgOut.TabIndex = 4
        Me.settImgOut.Text = "Img Out: .PNG"
        '
        'settThumbs
        '
        Me.settThumbs.AutoSize = True
        Me.settThumbs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settThumbs.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settThumbs.ForeColor = System.Drawing.Color.Black
        Me.settThumbs.Location = New System.Drawing.Point(8, 34)
        Me.settThumbs.Name = "settThumbs"
        Me.settThumbs.Size = New System.Drawing.Size(152, 11)
        Me.settThumbs.TabIndex = 3
        Me.settThumbs.Text = "Custom w: 150, h: 200"
        '
        'attCreTh
        '
        Me.attCreTh.AutoSize = True
        Me.attCreTh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.attCreTh.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.attCreTh.ForeColor = System.Drawing.Color.Black
        Me.attCreTh.Location = New System.Drawing.Point(8, 21)
        Me.attCreTh.Name = "attCreTh"
        Me.attCreTh.Size = New System.Drawing.Size(96, 11)
        Me.attCreTh.TabIndex = 2
        Me.attCreTh.Text = "Create Thumbs"
        '
        'settNoCols
        '
        Me.settNoCols.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settNoCols.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settNoCols.ForeColor = System.Drawing.Color.Black
        Me.settNoCols.Location = New System.Drawing.Point(8, 7)
        Me.settNoCols.Name = "settNoCols"
        Me.settNoCols.Size = New System.Drawing.Size(80, 12)
        Me.settNoCols.TabIndex = 0
        Me.settNoCols.Text = "No Colors "
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.settBBS)
        Me.Panel3.Controls.Add(Me.settLFExt)
        Me.Panel3.Controls.Add(Me.settVidCodec)
        Me.Panel3.Controls.Add(Me.settVidFmt)
        Me.Panel3.Controls.Add(Me.settVideo)
        Me.Panel3.Controls.Add(Me.settExt)
        Me.Panel3.Controls.Add(Me.settExist)
        Me.Panel3.Controls.Add(Me.settSauce)
        Me.Panel3.Controls.Add(Me.settGen)
        Me.Panel3.Location = New System.Drawing.Point(276, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(228, 91)
        Me.Panel3.TabIndex = 82
        '
        'settBBS
        '
        Me.settBBS.AutoSize = True
        Me.settBBS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settBBS.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settBBS.ForeColor = System.Drawing.Color.Black
        Me.settBBS.Location = New System.Drawing.Point(125, 23)
        Me.settBBS.Name = "settBBS"
        Me.settBBS.Size = New System.Drawing.Size(89, 11)
        Me.settBBS.TabIndex = 9
        Me.settBBS.Text = "BBS: PCBoard"
        '
        'settLFExt
        '
        Me.settLFExt.AutoSize = True
        Me.settLFExt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settLFExt.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settLFExt.ForeColor = System.Drawing.Color.Black
        Me.settLFExt.Location = New System.Drawing.Point(180, 70)
        Me.settLFExt.Name = "settLFExt"
        Me.settLFExt.Size = New System.Drawing.Size(40, 11)
        Me.settLFExt.TabIndex = 8
        Me.settLFExt.Text = "2 sec"
        '
        'settVidCodec
        '
        Me.settVidCodec.AutoSize = True
        Me.settVidCodec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settVidCodec.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settVidCodec.ForeColor = System.Drawing.Color.Black
        Me.settVidCodec.Location = New System.Drawing.Point(110, 70)
        Me.settVidCodec.Name = "settVidCodec"
        Me.settVidCodec.Size = New System.Drawing.Size(68, 11)
        Me.settVidCodec.TabIndex = 7
        Me.settVidCodec.Text = "(LIBXVID)"
        '
        'settVidFmt
        '
        Me.settVidFmt.AutoSize = True
        Me.settVidFmt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settVidFmt.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settVidFmt.ForeColor = System.Drawing.Color.Black
        Me.settVidFmt.Location = New System.Drawing.Point(6, 70)
        Me.settVidFmt.Name = "settVidFmt"
        Me.settVidFmt.Size = New System.Drawing.Size(75, 11)
        Me.settVidFmt.TabIndex = 6
        Me.settVidFmt.Text = "Video: AVI"
        '
        'settVideo
        '
        Me.settVideo.AutoSize = True
        Me.settVideo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settVideo.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settVideo.ForeColor = System.Drawing.Color.Black
        Me.settVideo.Location = New System.Drawing.Point(8, 54)
        Me.settVideo.Name = "settVideo"
        Me.settVideo.Size = New System.Drawing.Size(201, 11)
        Me.settVideo.TabIndex = 5
        Me.settVideo.Text = "AVI FPS: 29.97 / BPS: 14,400"
        '
        'settExt
        '
        Me.settExt.AutoSize = True
        Me.settExt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settExt.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settExt.ForeColor = System.Drawing.Color.Black
        Me.settExt.Location = New System.Drawing.Point(135, 38)
        Me.settExt.Name = "settExt"
        Me.settExt.Size = New System.Drawing.Size(82, 11)
        Me.settExt.TabIndex = 4
        Me.settExt.Text = "Ext: Append"
        '
        'settExist
        '
        Me.settExist.AutoSize = True
        Me.settExist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settExist.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settExist.ForeColor = System.Drawing.Color.Black
        Me.settExist.Location = New System.Drawing.Point(8, 38)
        Me.settExist.Name = "settExist"
        Me.settExist.Size = New System.Drawing.Size(89, 11)
        Me.settExist.TabIndex = 3
        Me.settExist.Text = "Exists: Over"
        '
        'settSauce
        '
        Me.settSauce.AutoSize = True
        Me.settSauce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settSauce.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settSauce.ForeColor = System.Drawing.Color.Black
        Me.settSauce.Location = New System.Drawing.Point(8, 23)
        Me.settSauce.Name = "settSauce"
        Me.settSauce.Size = New System.Drawing.Size(82, 11)
        Me.settSauce.TabIndex = 2
        Me.settSauce.Text = "Sauce: Keep"
        '
        'settGen
        '
        Me.settGen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settGen.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settGen.ForeColor = System.Drawing.Color.Black
        Me.settGen.Location = New System.Drawing.Point(8, 7)
        Me.settGen.Name = "settGen"
        Me.settGen.Size = New System.Drawing.Size(207, 12)
        Me.settGen.TabIndex = 0
        Me.settGen.Text = "List: Auto-Remove Completed"
        '
        'pIMGSett
        '
        Me.pIMGSett.BackColor = System.Drawing.Color.Silver
        Me.pIMGSett.Controls.Add(Me.settUTF)
        Me.pIMGSett.Controls.Add(Me.settAnim)
        Me.pIMGSett.Controls.Add(Me.settSanitize)
        Me.pIMGSett.Controls.Add(Me.settHTMLFont)
        Me.pIMGSett.Controls.Add(Me.settHTMLObj)
        Me.pIMGSett.Location = New System.Drawing.Point(5, 7)
        Me.pIMGSett.Name = "pIMGSett"
        Me.pIMGSett.Size = New System.Drawing.Size(268, 37)
        Me.pIMGSett.TabIndex = 81
        '
        'settUTF
        '
        Me.settUTF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settUTF.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settUTF.ForeColor = System.Drawing.Color.Black
        Me.settUTF.Location = New System.Drawing.Point(209, 21)
        Me.settUTF.Name = "settUTF"
        Me.settUTF.Size = New System.Drawing.Size(54, 12)
        Me.settUTF.TabIndex = 5
        Me.settUTF.Text = "UTF-8"
        '
        'settAnim
        '
        Me.settAnim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settAnim.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settAnim.ForeColor = System.Drawing.Color.Black
        Me.settAnim.Location = New System.Drawing.Point(84, 7)
        Me.settAnim.Name = "settAnim"
        Me.settAnim.Size = New System.Drawing.Size(70, 12)
        Me.settAnim.TabIndex = 4
        Me.settAnim.Text = "/ Static"
        '
        'settSanitize
        '
        Me.settSanitize.AutoSize = True
        Me.settSanitize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settSanitize.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settSanitize.ForeColor = System.Drawing.Color.Black
        Me.settSanitize.Location = New System.Drawing.Point(154, 7)
        Me.settSanitize.Name = "settSanitize"
        Me.settSanitize.Size = New System.Drawing.Size(110, 11)
        Me.settSanitize.TabIndex = 3
        Me.settSanitize.Text = ", Sanitize: Yes"
        '
        'settHTMLFont
        '
        Me.settHTMLFont.AutoSize = True
        Me.settHTMLFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settHTMLFont.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settHTMLFont.ForeColor = System.Drawing.Color.Black
        Me.settHTMLFont.Location = New System.Drawing.Point(8, 21)
        Me.settHTMLFont.Name = "settHTMLFont"
        Me.settHTMLFont.Size = New System.Drawing.Size(47, 11)
        Me.settHTMLFont.TabIndex = 2
        Me.settHTMLFont.Text = "Font: "
        '
        'settHTMLObj
        '
        Me.settHTMLObj.Cursor = System.Windows.Forms.Cursors.Hand
        Me.settHTMLObj.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.settHTMLObj.ForeColor = System.Drawing.Color.Black
        Me.settHTMLObj.Location = New System.Drawing.Point(8, 7)
        Me.settHTMLObj.Name = "settHTMLObj"
        Me.settHTMLObj.Size = New System.Drawing.Size(70, 12)
        Me.settHTMLObj.TabIndex = 0
        Me.settHTMLObj.Text = "Full HTML"
        '
        'cntWC2
        '
        Me.cntWC2.BackColor = System.Drawing.Color.DarkGray
        Me.cntWC2.Location = New System.Drawing.Point(362, 24)
        Me.cntWC2.Name = "cntWC2"
        Me.cntWC2.Size = New System.Drawing.Size(40, 15)
        Me.cntWC2.TabIndex = 61
        Me.cntWC2.Text = "0"
        Me.cntWC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntWC2.UseCompatibleTextRendering = True
        '
        'in2Wildcat2
        '
        Me.in2Wildcat2.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2Wildcat2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2Wildcat2.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2Wildcat2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2Wildcat2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2Wildcat2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2Wildcat2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2Wildcat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2Wildcat2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2Wildcat2.Location = New System.Drawing.Point(362, 2)
        Me.in2Wildcat2.Name = "in2Wildcat2"
        Me.in2Wildcat2.Size = New System.Drawing.Size(40, 20)
        Me.in2Wildcat2.TabIndex = 60
        Me.in2Wildcat2.Tag = "WC2"
        Me.in2Wildcat2.Text = "WC2"
        Me.in2Wildcat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2Wildcat2.UseCompatibleTextRendering = True
        Me.in2Wildcat2.UseVisualStyleBackColor = False
        '
        'cntWC3
        '
        Me.cntWC3.BackColor = System.Drawing.Color.DarkGray
        Me.cntWC3.Location = New System.Drawing.Point(404, 24)
        Me.cntWC3.Name = "cntWC3"
        Me.cntWC3.Size = New System.Drawing.Size(40, 15)
        Me.cntWC3.TabIndex = 63
        Me.cntWC3.Text = "0"
        Me.cntWC3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntWC3.UseCompatibleTextRendering = True
        '
        'in2Wildcat3
        '
        Me.in2Wildcat3.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2Wildcat3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2Wildcat3.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2Wildcat3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2Wildcat3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2Wildcat3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2Wildcat3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2Wildcat3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2Wildcat3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2Wildcat3.Location = New System.Drawing.Point(404, 2)
        Me.in2Wildcat3.Name = "in2Wildcat3"
        Me.in2Wildcat3.Size = New System.Drawing.Size(40, 20)
        Me.in2Wildcat3.TabIndex = 62
        Me.in2Wildcat3.Tag = "WC3"
        Me.in2Wildcat3.Text = "WC3"
        Me.in2Wildcat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2Wildcat3.UseCompatibleTextRendering = True
        Me.in2Wildcat3.UseVisualStyleBackColor = False
        '
        'cntAVT
        '
        Me.cntAVT.BackColor = System.Drawing.Color.DarkGray
        Me.cntAVT.Location = New System.Drawing.Point(446, 24)
        Me.cntAVT.Name = "cntAVT"
        Me.cntAVT.Size = New System.Drawing.Size(40, 15)
        Me.cntAVT.TabIndex = 65
        Me.cntAVT.Text = "0"
        Me.cntAVT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cntAVT.UseCompatibleTextRendering = True
        '
        'in2Avatar
        '
        Me.in2Avatar.Appearance = System.Windows.Forms.Appearance.Button
        Me.in2Avatar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.in2Avatar.Cursor = System.Windows.Forms.Cursors.Help
        Me.in2Avatar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.in2Avatar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.in2Avatar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.in2Avatar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.in2Avatar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.in2Avatar.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.in2Avatar.Location = New System.Drawing.Point(446, 2)
        Me.in2Avatar.Name = "in2Avatar"
        Me.in2Avatar.Size = New System.Drawing.Size(40, 20)
        Me.in2Avatar.TabIndex = 64
        Me.in2Avatar.Tag = "AVT"
        Me.in2Avatar.Text = "AVT"
        Me.in2Avatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.in2Avatar.UseCompatibleTextRendering = True
        Me.in2Avatar.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ANSI_ASCII_Converter.My.Resources.Resources.CHSAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(869, 466)
        Me.Controls.Add(Me.lblLogAndInfos)
        Me.Controls.Add(Me.numTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.log)
        Me.Controls.Add(Me.numUTF8)
        Me.Controls.Add(Me.lblNumUTF8)
        Me.Controls.Add(Me.numUTF16)
        Me.Controls.Add(Me.numASCII)
        Me.Controls.Add(Me.lblNUmASCII)
        Me.Controls.Add(Me.lblNumUTF16)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Name = "MainForm"
        Me.Opacity = 0.98
        Me.Text = "ANSI & ASCII Converter"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pCPout.ResumeLayout(False)
        Me.pOutPath.ResumeLayout(False)
        Me.pOutPath.PerformLayout()
        Me.pOut.ResumeLayout(False)
        Me.pCPin.ResumeLayout(False)
        Me.pIn.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pIMGSett.ResumeLayout(False)
        Me.pIMGSett.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAdd As MyControls.GButton
    Friend WithEvents btnRemove As MyControls.GButton
    Friend WithEvents btnClear As MyControls.GButton
    Friend WithEvents lblNumUTF16 As System.Windows.Forms.Label
    Friend WithEvents lblNUmASCII As System.Windows.Forms.Label
    Friend WithEvents numASCII As System.Windows.Forms.Label
    Friend WithEvents numUTF16 As System.Windows.Forms.Label
    Friend WithEvents lblNumUTF8 As System.Windows.Forms.Label
    Friend WithEvents numUTF8 As System.Windows.Forms.Label
    Friend WithEvents log As System.Windows.Forms.RichTextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents numTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLogAndInfos As System.Windows.Forms.Label

    Friend WithEvents lblSelected As System.Windows.Forms.Label
    Friend WithEvents numSel As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelNone As MyControls.GButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnUniBlocks As MyControls.GButton
    Friend WithEvents btnCPMaps As MyControls.GButton
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pCPout As System.Windows.Forms.Panel
    Friend WithEvents lblCPout As System.Windows.Forms.Label
    Friend WithEvents outCP As System.Windows.Forms.ComboBox
    Friend WithEvents pOutPath As System.Windows.Forms.Panel
    Friend WithEvents btnOutputFolder As MyControls.GButton
    Friend WithEvents rOutPathInput As System.Windows.Forms.RadioButton
    Friend WithEvents outPath As MyControls.PartialPathDisplayLabel
    Friend WithEvents rOutPathNew As System.Windows.Forms.RadioButton
    Friend WithEvents pOut As System.Windows.Forms.Panel
    Friend WithEvents lblOutput As System.Windows.Forms.Label
    Friend WithEvents outBinary As System.Windows.Forms.RadioButton
    Friend WithEvents outBBS As System.Windows.Forms.RadioButton
    Friend WithEvents outUnicode As System.Windows.Forms.RadioButton
    Friend WithEvents outHTML As System.Windows.Forms.RadioButton
    Friend WithEvents outANSI As System.Windows.Forms.RadioButton
    Friend WithEvents outASCII As System.Windows.Forms.RadioButton
    Friend WithEvents pCPin As System.Windows.Forms.Panel
    Friend WithEvents lblCPin As System.Windows.Forms.Label
    Friend WithEvents inCP As System.Windows.Forms.ComboBox
    Friend WithEvents pIn As System.Windows.Forms.Panel
    Friend WithEvents cntBIN As System.Windows.Forms.Label
    Friend WithEvents cntPCB As System.Windows.Forms.Label
    Friend WithEvents cntUNI As System.Windows.Forms.Label
    Friend WithEvents cntHTML As System.Windows.Forms.Label
    Friend WithEvents cntANSI As System.Windows.Forms.Label
    Friend WithEvents cntASCII As System.Windows.Forms.Label
    Friend WithEvents in2Binary As System.Windows.Forms.CheckBox
    Friend WithEvents in2PCBoard As System.Windows.Forms.CheckBox
    Friend WithEvents in2Unicode As System.Windows.Forms.CheckBox
    Friend WithEvents in2HTML As System.Windows.Forms.CheckBox
    Friend WithEvents in2ANSI As System.Windows.Forms.CheckBox
    Friend WithEvents in2ASCII As System.Windows.Forms.CheckBox
    Friend WithEvents lblInputFormats As System.Windows.Forms.Label
    Friend WithEvents btnQuit As MyControls.GButton
    Friend WithEvents lblDropHere As System.Windows.Forms.Label
    Friend WithEvents listFiles As System.Windows.Forms.ListBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnStart As MyControls.GButton
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents VersionDate As System.Windows.Forms.Label
    Friend WithEvents btnNFO As System.Windows.Forms.Button
    Friend WithEvents btnSearch As MyControls.GButton
    Friend WithEvents outImage As System.Windows.Forms.RadioButton
    Friend WithEvents XPanel1 As ANSI_ASCII_Converter.xPanel
    Friend WithEvents txtExt As System.Windows.Forms.TextBox
    Friend WithEvents btnSettings As MyControls.GButton
    Friend WithEvents pIMGSett As System.Windows.Forms.Panel
    Friend WithEvents settHTMLFont As System.Windows.Forms.Label
    Friend WithEvents settHTMLObj As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents settExist As System.Windows.Forms.Label
    Friend WithEvents settSauce As System.Windows.Forms.Label
    Friend WithEvents settGen As System.Windows.Forms.Label
    Friend WithEvents settSanitize As System.Windows.Forms.Label
    Friend WithEvents settExt As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents settImgOut As System.Windows.Forms.Label
    Friend WithEvents settThumbs As System.Windows.Forms.Label
    Friend WithEvents attCreTh As System.Windows.Forms.Label
    Friend WithEvents settNoCols As System.Windows.Forms.Label
    Friend WithEvents pCPOutEmpty As System.Windows.Forms.Panel
    Friend WithEvents pCPInEmpty As System.Windows.Forms.Panel
    Friend WithEvents btnSettings2 As MyControls.GButton
    Friend WithEvents lblInfoSameDirOut As System.Windows.Forms.Label
    Friend WithEvents lblExt As System.Windows.Forms.Label
    Friend WithEvents settSMALLFNT As System.Windows.Forms.Label
    Friend WithEvents settAnim As System.Windows.Forms.Label
    Friend WithEvents outVideo As System.Windows.Forms.RadioButton
    Friend WithEvents settVideo As System.Windows.Forms.Label
    Friend WithEvents settVidFmt As System.Windows.Forms.Label
    Friend WithEvents settUTF As System.Windows.Forms.Label
    Friend WithEvents settVidCodec As System.Windows.Forms.Label
    Friend WithEvents settLFExt As System.Windows.Forms.Label
    Friend WithEvents lblDebugOnOff As System.Windows.Forms.Label
    Friend WithEvents settBBS As System.Windows.Forms.Label
    Friend WithEvents cntWC3 As System.Windows.Forms.Label
    Friend WithEvents in2Wildcat3 As System.Windows.Forms.CheckBox
    Friend WithEvents cntWC2 As System.Windows.Forms.Label
    Friend WithEvents in2Wildcat2 As System.Windows.Forms.CheckBox
    Friend WithEvents cntAVT As System.Windows.Forms.Label
    Friend WithEvents in2Avatar As System.Windows.Forms.CheckBox

End Class
