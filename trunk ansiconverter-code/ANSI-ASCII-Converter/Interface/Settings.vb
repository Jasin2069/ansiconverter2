
Namespace My
    
    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.

    Partial Friend NotInheritable Class MySettings
        Private Sub MySettings_SettingsSaving(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.SettingsSaving
            If MainFormLoaded = False Or bUpdatingControls = True Then
                e.Cancel = True
            End If
        End Sub

        Sub Loaded(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SettingsLoaded
            If MainFormLoaded = True And bUpdatingControls = False Then
                UpdateControls()
            End If
        End Sub

    End Class
End Namespace
