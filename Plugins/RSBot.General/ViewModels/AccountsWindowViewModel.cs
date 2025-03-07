using Avalonia.Controls;
using ReactiveUI;
using RSBot.General.Components;
using RSBot.General.Models;
using System.Collections.ObjectModel;
using System.Reactive;

namespace RSBot.General.ViewModels;

/// <summary>
/// View model for the accounts window that manages account operations
/// </summary>
public class AccountsWindowViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _username;
    private string _password;
    private string _secondaryPassword;
    private string _selectedServer;
    private byte _selectedChannel;
    private Account _selectedAccount;
    private string _editMode = "Add";

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public string SecondaryPassword
    {
        get => _secondaryPassword;
        set => this.RaiseAndSetIfChanged(ref _secondaryPassword, value);
    }

    public string SelectedServer
    {
        get => _selectedServer;
        set => this.RaiseAndSetIfChanged(ref _selectedServer, value);
    }

    public byte SelectedChannel
    {
        get => _selectedChannel;
        set => this.RaiseAndSetIfChanged(ref _selectedChannel, value);
    }

    public ObservableCollection<string> Channels { get; } = ["JCPlanet", "JOYMAX"];

    public ObservableCollection<Account> SavedAccounts { get; } = new();

    public Account SelectedAccount
    {
        get => _selectedAccount;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedAccount, value);
            if (value != null)
            {
                EditMode = "Edit";
                Username = value.Username;
                Password = value.Password;
                SelectedChannel = value.Channel;
                SecondaryPassword = value.SecondaryPassword;
                SelectedServer = value.Servername;
            }
        }
    }

    public string EditMode
    {
        get => _editMode;
        set => this.RaiseAndSetIfChanged(ref _editMode, value);
    }

    public ReactiveCommand<Unit, Unit> SaveAccountCommand { get; }
    public ReactiveCommand<Account, Unit> RemoveAccountCommand { get; }
    public ReactiveCommand<Unit, Unit> ClearCommand { get; }

    public AccountsWindowViewModel(Window owner)
    {
        _owner = owner;
        SaveAccountCommand = ReactiveCommand.Create(SaveAccount);
        RemoveAccountCommand = ReactiveCommand.Create<Account>(RemoveAccount);
        ClearCommand = ReactiveCommand.Create(Clear);

        LoadAccounts();
    }

    private void LoadAccounts()
    {
        SavedAccounts.Clear();
        foreach (var account in Accounts.SavedAccounts)
            SavedAccounts.Add(account);
    }

    private void SaveAccount()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(SelectedServer))
            return;

        if (EditMode == "Edit" && SelectedAccount != null)
        {
            SelectedAccount.Username = Username;
            SelectedAccount.Password = Password;
            SelectedAccount.SecondaryPassword = SecondaryPassword;
            SelectedAccount.Servername = SelectedServer;
            SelectedAccount.Channel = (byte)(SelectedChannel + 1);
        }
        else
        {
            var account = new Account
            {
                Username = Username,
                Password = Password,
                SecondaryPassword = SecondaryPassword,
                Servername = SelectedServer,
                Channel = (byte)(SelectedChannel + 1)
            };

            SavedAccounts.Add(account);
            Accounts.SavedAccounts.Add(account);
        }

        Accounts.Save();
        Clear();
    }

    private void RemoveAccount(Account account)
    {
        if (account == null)
            return;

        SavedAccounts.Remove(account);
        Accounts.SavedAccounts.Remove(account);
        Accounts.Save();

        if (SelectedAccount == account)
            Clear();
    }

    private void Clear()
    {
        EditMode = "Add";
        Username = string.Empty;
        Password = string.Empty;
        SecondaryPassword = string.Empty;
        SelectedServer = null;
        SelectedAccount = null;
        SelectedChannel = 0;
    }
} 