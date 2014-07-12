<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CharDetail
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
        Me.imgChar = New System.Windows.Forms.PictureBox
        Me.lblChar = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.lblHex = New System.Windows.Forms.Label
        Me.lblOct = New System.Windows.Forms.Label
        Me.lblBin = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblAliaseslbl = New System.Windows.Forms.Label
        Me.lblSimilarLbl = New System.Windows.Forms.Label
        Me.lblNotesLbl = New System.Windows.Forms.Label
        Me.btnOK = New MyControls.GButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblAliases = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblSimilar = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblNotes = New System.Windows.Forms.Label
        Me.lblUTF8Hex = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblUTF8Bin = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblHTMLDec = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblHTMLHex = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblJava = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblPy = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblUTF16hex = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblUTF16be = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblUTF16le = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.imgChar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgChar
        '
        Me.imgChar.BackColor = System.Drawing.Color.Transparent
        Me.imgChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgChar.ErrorImage = Nothing
        Me.imgChar.InitialImage = Nothing
        Me.imgChar.Location = New System.Drawing.Point(12, 12)
        Me.imgChar.Name = "imgChar"
        Me.imgChar.Size = New System.Drawing.Size(48, 48)
        Me.imgChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgChar.TabIndex = 0
        Me.imgChar.TabStop = False
        '
        'lblChar
        '
        Me.lblChar.BackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.lblChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChar.Font = New System.Drawing.Font("Lucida Sans Unicode", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChar.ForeColor = System.Drawing.Color.Cyan
        Me.lblChar.Location = New System.Drawing.Point(66, 12)
        Me.lblChar.Name = "lblChar"
        Me.lblChar.Size = New System.Drawing.Size(48, 48)
        Me.lblChar.TabIndex = 1
        Me.lblChar.Text = "X"
        Me.lblChar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(134, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Code Dec:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(134, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Code Hex:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(300, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Code Oct:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(300, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Code Bin:"
        '
        'lblCode
        '
        Me.lblCode.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCode.Location = New System.Drawing.Point(220, 11)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(65, 15)
        Me.lblCode.TabIndex = 6
        Me.lblCode.Text = "FFFF"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHex
        '
        Me.lblHex.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHex.Location = New System.Drawing.Point(220, 37)
        Me.lblHex.Name = "lblHex"
        Me.lblHex.Size = New System.Drawing.Size(65, 15)
        Me.lblHex.TabIndex = 7
        Me.lblHex.Text = "FFFF"
        Me.lblHex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOct
        '
        Me.lblOct.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOct.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblOct.Location = New System.Drawing.Point(390, 11)
        Me.lblOct.Name = "lblOct"
        Me.lblOct.Size = New System.Drawing.Size(75, 15)
        Me.lblOct.TabIndex = 8
        Me.lblOct.Text = "FFFF"
        Me.lblOct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBin
        '
        Me.lblBin.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBin.Location = New System.Drawing.Point(390, 36)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(75, 15)
        Me.lblBin.TabIndex = 9
        Me.lblBin.Text = "FFFF"
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(134, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Name:"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(180, 63)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(290, 15)
        Me.lblName.TabIndex = 11
        Me.lblName.Text = "FFFF"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAliaseslbl
        '
        Me.lblAliaseslbl.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAliaseslbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAliaseslbl.Location = New System.Drawing.Point(12, 70)
        Me.lblAliaseslbl.Name = "lblAliaseslbl"
        Me.lblAliaseslbl.Size = New System.Drawing.Size(110, 16)
        Me.lblAliaseslbl.TabIndex = 12
        Me.lblAliaseslbl.Text = "Aliases:"
        '
        'lblSimilarLbl
        '
        Me.lblSimilarLbl.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimilarLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSimilarLbl.Location = New System.Drawing.Point(12, 155)
        Me.lblSimilarLbl.Name = "lblSimilarLbl"
        Me.lblSimilarLbl.Size = New System.Drawing.Size(110, 16)
        Me.lblSimilarLbl.TabIndex = 13
        Me.lblSimilarLbl.Text = "Similar:"
        '
        'lblNotesLbl
        '
        Me.lblNotesLbl.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotesLbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNotesLbl.Location = New System.Drawing.Point(12, 238)
        Me.lblNotesLbl.Name = "lblNotesLbl"
        Me.lblNotesLbl.Size = New System.Drawing.Size(110, 16)
        Me.lblNotesLbl.TabIndex = 14
        Me.lblNotesLbl.Text = "Notes:"
        '
        'btnOK
        '
        Me.btnOK.BeginColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOK.BeginColorDisabled = System.Drawing.Color.Black
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.EndColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnOK.EndColorDisabled = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Silver
        Me.btnOK.ForeColorDisabled = System.Drawing.Color.DarkGray
        Me.btnOK.Location = New System.Drawing.Point(349, 460)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(121, 31)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblAliases)
        Me.Panel1.Location = New System.Drawing.Point(5, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(470, 65)
        Me.Panel1.TabIndex = 25
        '
        'lblAliases
        '
        Me.lblAliases.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAliases.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAliases.Location = New System.Drawing.Point(3, 5)
        Me.lblAliases.Name = "lblAliases"
        Me.lblAliases.Size = New System.Drawing.Size(31, 13)
        Me.lblAliases.TabIndex = 29
        Me.lblAliases.Text = "N/A"
        Me.lblAliases.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblSimilar)
        Me.Panel2.Location = New System.Drawing.Point(5, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 65)
        Me.Panel2.TabIndex = 26
        '
        'lblSimilar
        '
        Me.lblSimilar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimilar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSimilar.Location = New System.Drawing.Point(3, 5)
        Me.lblSimilar.Name = "lblSimilar"
        Me.lblSimilar.Size = New System.Drawing.Size(31, 13)
        Me.lblSimilar.TabIndex = 30
        Me.lblSimilar.Text = "N/A"
        Me.lblSimilar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblNotes)
        Me.Panel3.Location = New System.Drawing.Point(5, 253)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 65)
        Me.Panel3.TabIndex = 27
        '
        'lblNotes
        '
        Me.lblNotes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNotes.Location = New System.Drawing.Point(3, 5)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(31, 13)
        Me.lblNotes.TabIndex = 30
        Me.lblNotes.Text = "N/A"
        Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUTF8Hex
        '
        Me.lblUTF8Hex.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTF8Hex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUTF8Hex.Location = New System.Drawing.Point(128, 329)
        Me.lblUTF8Hex.Name = "lblUTF8Hex"
        Me.lblUTF8Hex.Size = New System.Drawing.Size(85, 15)
        Me.lblUTF8Hex.TabIndex = 29
        Me.lblUTF8Hex.Text = "FFFF"
        Me.lblUTF8Hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(9, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "UTF8 (Hex):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUTF8Bin
        '
        Me.lblUTF8Bin.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTF8Bin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUTF8Bin.Location = New System.Drawing.Point(128, 356)
        Me.lblUTF8Bin.Name = "lblUTF8Bin"
        Me.lblUTF8Bin.Size = New System.Drawing.Size(277, 14)
        Me.lblUTF8Bin.TabIndex = 31
        Me.lblUTF8Bin.Text = "FFFF"
        Me.lblUTF8Bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(9, 356)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 15)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "UTF8 (Bin):"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHTMLDec
        '
        Me.lblHTMLDec.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHTMLDec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHTMLDec.Location = New System.Drawing.Point(128, 380)
        Me.lblHTMLDec.Name = "lblHTMLDec"
        Me.lblHTMLDec.Size = New System.Drawing.Size(85, 15)
        Me.lblHTMLDec.TabIndex = 33
        Me.lblHTMLDec.Text = "FFFF"
        Me.lblHTMLDec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(9, 381)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 15)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "HTML (Dec):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHTMLHex
        '
        Me.lblHTMLHex.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHTMLHex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblHTMLHex.Location = New System.Drawing.Point(128, 408)
        Me.lblHTMLHex.Name = "lblHTMLHex"
        Me.lblHTMLHex.Size = New System.Drawing.Size(85, 15)
        Me.lblHTMLHex.TabIndex = 35
        Me.lblHTMLHex.Text = "FFFF"
        Me.lblHTMLHex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(9, 409)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "HTML (Hex):"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblJava
        '
        Me.lblJava.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJava.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblJava.Location = New System.Drawing.Point(128, 436)
        Me.lblJava.Name = "lblJava"
        Me.lblJava.Size = New System.Drawing.Size(85, 15)
        Me.lblJava.TabIndex = 37
        Me.lblJava.Text = "FFFF"
        Me.lblJava.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(9, 437)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 15)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "C++/Java:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPy
        '
        Me.lblPy.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPy.Location = New System.Drawing.Point(128, 465)
        Me.lblPy.Name = "lblPy"
        Me.lblPy.Size = New System.Drawing.Size(85, 15)
        Me.lblPy.TabIndex = 39
        Me.lblPy.Text = "FFFF"
        Me.lblPy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(9, 465)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(110, 15)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Python:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUTF16hex
        '
        Me.lblUTF16hex.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTF16hex.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUTF16hex.Location = New System.Drawing.Point(370, 381)
        Me.lblUTF16hex.Name = "lblUTF16hex"
        Me.lblUTF16hex.Size = New System.Drawing.Size(85, 15)
        Me.lblUTF16hex.TabIndex = 41
        Me.lblUTF16hex.Text = "FFFF"
        Me.lblUTF16hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(240, 381)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 15)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "UTF16 (Hex):"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUTF16be
        '
        Me.lblUTF16be.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTF16be.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUTF16be.Location = New System.Drawing.Point(370, 409)
        Me.lblUTF16be.Name = "lblUTF16be"
        Me.lblUTF16be.Size = New System.Drawing.Size(85, 15)
        Me.lblUTF16be.TabIndex = 43
        Me.lblUTF16be.Text = "FFFF"
        Me.lblUTF16be.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(234, 409)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(130, 14)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "UTF16BE (Hex):"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUTF16le
        '
        Me.lblUTF16le.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTF16le.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblUTF16le.Location = New System.Drawing.Point(370, 437)
        Me.lblUTF16le.Name = "lblUTF16le"
        Me.lblUTF16le.Size = New System.Drawing.Size(85, 15)
        Me.lblUTF16le.TabIndex = 45
        Me.lblUTF16le.Text = "FFFF"
        Me.lblUTF16le.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(237, 437)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(127, 14)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "UTF16LE (Hex):"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CharDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(482, 495)
        Me.Controls.Add(Me.lblUTF16le)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblUTF16be)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblUTF16hex)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblPy)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblJava)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblHTMLHex)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblHTMLDec)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblUTF8Bin)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblUTF8Hex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblNotesLbl)
        Me.Controls.Add(Me.lblSimilarLbl)
        Me.Controls.Add(Me.lblAliaseslbl)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblBin)
        Me.Controls.Add(Me.lblOct)
        Me.Controls.Add(Me.lblHex)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblChar)
        Me.Controls.Add(Me.imgChar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CharDetail"
        Me.Opacity = 0.98
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CharDetail"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(4, Byte), Integer), CType(CType(4, Byte), Integer))
        CType(Me.imgChar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imgChar As System.Windows.Forms.PictureBox
    Friend WithEvents lblChar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblHex As System.Windows.Forms.Label
    Friend WithEvents lblOct As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblAliaseslbl As System.Windows.Forms.Label
    Friend WithEvents lblSimilarLbl As System.Windows.Forms.Label
    Friend WithEvents lblNotesLbl As System.Windows.Forms.Label
    Friend WithEvents btnOK As MyControls.GButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblAliases As System.Windows.Forms.Label
    Friend WithEvents lblSimilar As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblUTF8Hex As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblUTF8Bin As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblHTMLDec As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblHTMLHex As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblJava As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPy As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblUTF16hex As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblUTF16be As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblUTF16le As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
