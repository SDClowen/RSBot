using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the about dialog that displays application information
/// </summary>
public class AboutDialogViewModel : ReactiveObject
{
    private readonly Window _owner;

    public AboutDialogViewModel(Window owner)
    {
        _owner = owner;
        Version = $"Version {Program.AssemblyVersion}";
        CloseCommand = ReactiveCommand.Create(ExecuteClose);
    }

    public string Version { get; }
    public ICommand CloseCommand { get; }

    private void ExecuteClose()
    {
        _owner.Close();
    }
} 