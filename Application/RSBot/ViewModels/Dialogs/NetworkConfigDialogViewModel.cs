using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using System.Net;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the network configuration dialog
/// </summary>
public class NetworkConfigDialogViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _bindIp;

    public NetworkConfigDialogViewModel(Window owner)
    {
        _owner = owner;
        BindIp = GlobalConfig.Get("RSBot.Network.BindIp", "0.0.0.0");

        SaveCommand = ReactiveCommand.Create(ExecuteSave);
        CancelCommand = ReactiveCommand.Create(ExecuteCancel);
    }

    public string BindIp
    {
        get => _bindIp;
        set => this.RaiseAndSetIfChanged(ref _bindIp, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    private void ExecuteSave()
    {
        if (!IPAddress.TryParse(BindIp, out var ipAddress))
        {
            // TODO: Show error message dialog
            return;
        }

        GlobalConfig.Set("RSBot.Network.BindIp", ipAddress.ToString());
        GlobalConfig.Save();
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        _owner.Close();
    }
} 