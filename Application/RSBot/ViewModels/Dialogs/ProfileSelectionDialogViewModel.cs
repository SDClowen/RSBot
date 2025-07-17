using Avalonia.Controls;
using PeNet.Header.Resource;
using ReactiveUI;
using RSBot.Core.Components;
using RSBot.Core.UI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace RSBot.ViewModels.Dialogs;

public class ProfileSelectionDialogViewModel : ReactiveObject
{
    private bool _saveSelection;
    private string _selectedProfile;
    private readonly Window _owner;

    public ProfileSelectionDialogViewModel(Window owner = null)
    {
        _owner = owner;

        Profiles = new ObservableCollection<string>();
        LoadProfiles();

        ContinueCommand = ReactiveCommand.Create(Continue);
        CreateProfileCommand = ReactiveCommand.CreateFromTask(CreateProfileAsync);
        DeleteProfileCommand = ReactiveCommand.CreateFromTask(DeleteProfileAsync);
    }

    public ObservableCollection<string> Profiles { get; }

    public string SelectedProfile
    {
        get => _selectedProfile;
        set => this.RaiseAndSetIfChanged(ref _selectedProfile, value);
    }

    public bool SaveSelection
    {
        get => _saveSelection;
        set => this.RaiseAndSetIfChanged(ref _saveSelection, value);
    }

    public bool CanDeleteProfile =>
        SelectedProfile != null &&
        SelectedProfile != "Default" &&
        SelectedProfile != ProfileManager.SelectedProfile;

    public ReactiveCommand<Unit, Unit> ContinueCommand { get; }
    public ReactiveCommand<Unit, Unit> CreateProfileCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteProfileCommand { get; }

    private void LoadProfiles()
    {
        Profiles.Clear();

        if (!ProfileManager.Any())
            ProfileManager.Add("Default");

        foreach (var profile in ProfileManager.Profiles)
            Profiles.Add(profile);

        SelectedProfile = Profiles.FirstOrDefault(p => p == ProfileManager.SelectedProfile);
        SaveSelection = !ProfileManager.ShowProfileDialog;
    }

    private void Continue()
    {
        ProfileManager.ShowProfileDialog = !SaveSelection;
        _owner?.Close();
    }

    private async Task CreateProfileAsync()
    {
        while (true)
        {
            var dialog = new TextInputDialog("New Profile", "Enter profile name:");
            var profile = await dialog.ShowDialog<string>(_owner);
            if(ProfileManager.ProfileExists(profile))
            {
                await MessageBox.Show(_owner,
                    "Invalid name",
                    $"The profile name '{profile}' already exists!"
                );

                continue;
            }

            if (!string.IsNullOrEmpty(profile))
            {
                ProfileManager.Add(profile);
                Profiles.Add(profile);
                SelectedProfile = profile;
            }

            break;
        }

        LoadProfiles();
    }

    private async Task DeleteProfileAsync()
    {
        if (!CanDeleteProfile) return;

        var result = await MessageBox.Show(_owner,
            "Cannot delete profile",
             $"Do you want to delete the profile {SelectedProfile} from the list?\nThis will not delete the user data.",
             MessageBoxButtons.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            ProfileManager.Remove(SelectedProfile);
            LoadProfiles();
        }
    }
}