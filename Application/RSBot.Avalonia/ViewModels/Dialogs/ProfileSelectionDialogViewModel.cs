using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the profile selection dialog
/// </summary>
public class ProfileSelectionDialogViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _selectedProfile;

    public ProfileSelectionDialogViewModel(Window owner)
    {
        _owner = owner;
        Profiles = [.. ProfileManager.Profiles];
        SelectedProfile = ProfileManager.SelectedProfile;

        NewCommand = ReactiveCommand.Create(ExecuteNew);
        DeleteCommand = ReactiveCommand.Create(ExecuteDelete);
        OkCommand = ReactiveCommand.Create(ExecuteOk);
        CancelCommand = ReactiveCommand.Create(ExecuteCancel);
    }

    public ObservableCollection<string> Profiles { get; }

    public string SelectedProfile
    {
        get => _selectedProfile;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedProfile, value);

            ProfileManager.SetSelectedProfile(value);
        }
    }

    public ICommand NewCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }

    private async void ExecuteNew()
    {
        var dialog = new TextInputDialog("New Profile", "Enter profile name:");
        var result = await dialog.ShowDialog<string>(_owner);

        if (!string.IsNullOrEmpty(result))
        {
            ProfileManager.Add(result);
            Profiles.Add(result);
            SelectedProfile = result;
        }
    }

    private void ExecuteDelete()
    {
        if (SelectedProfile == null || SelectedProfile == "Default")
            return;

        ProfileManager.Remove(SelectedProfile);
        Profiles.Remove(SelectedProfile);
        SelectedProfile = "Default";
    }

    private void ExecuteOk()
    {
        if (SelectedProfile != null)
        {
            _owner.Close(true);
        }
    }

    private void ExecuteCancel()
    {
        _owner.Close(false);
    }
}