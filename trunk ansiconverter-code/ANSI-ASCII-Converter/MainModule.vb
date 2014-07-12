Public Module MainModule

    Public WithEvents oMainForm As MainForm = Nothing
    Public WithEvents oCodePageMaps As CodePageMaps = Nothing
    Public WithEvents oUnicodeBlocks As UnicodeBlocks = Nothing
    Public WithEvents oUniCodeSearch As UniCodeSearch = Nothing
    Public WithEvents oNfo As NFOViewer = Nothing
    Public ToolVersion As String = My.Application.Info.Version.ToString '"1.05.00"
    Public Const ToolVersionDate = "07.2014"
    Public Sub Main()
        oMainForm = New MainForm
        My.Application.OpenForms.Add(oMainForm)
        oMainForm.Version.Text = ToolVersion
        oMainForm.VersionDate.Text = ToolVersionDate

        System.Windows.Forms.Application.Run(oMainForm)
    End Sub

End Module
