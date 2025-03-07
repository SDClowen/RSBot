using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;
using RSBot.Core.UI;
using RSBot.General.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reactive;

namespace RSBot.General.ViewModels;

/// <summary>
/// View model for the main view of the General plugin
/// Handles all the core functionality for managing bot and client settings
/// </summary>
public class MainViewModel : ReactiveObject
{
    #region Fields

    private string _silkroadPath;
    private string _version;
    private bool _isClientRunning;
    private bool _enableAutoLogin;
    private Account _selectedAccount;
    private string _selectedCharacter;
    private bool _enableStaticCaptcha;
    private string _staticCaptcha;
    private bool _enableLoginDelay;
    private int _loginDelay;
    private bool _hideClientOnStart;
    private bool _autoSelectCharacter;
    private bool _autoSelectFirst;
    private bool _startBotAfterLogin;
    private bool _useReturnScroll;
    private bool _stayConnected;
    private GameClientType _selectedClientType;
    private bool _minimizeToTray;
    private bool _autoHidePendingWindow;
    private bool _enableQueueLogs;
    private bool _enableQueueNotification;
    private int _queueNotificationThreshold;
    private bool _clientVisible;

    #endregion

    #region Properties

    public string SilkroadPath
    {
        get => _silkroadPath;
        set
        {
            this.RaiseAndSetIfChanged(ref _silkroadPath, value);
            GlobalConfig.Set("RSBot.SilkroadDirectory", Path.GetDirectoryName(value));
            GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(value));
        }
    }

    public string Version
    {
        get => _version;
        set => this.RaiseAndSetIfChanged(ref _version, value);
    }

    public bool IsClientRunning
    {
        get => _isClientRunning;
        set => this.RaiseAndSetIfChanged(ref _isClientRunning, value);
    }

    public bool EnableAutoLogin
    {
        get => _enableAutoLogin;
        set
        {
            this.RaiseAndSetIfChanged(ref _enableAutoLogin, value);
            GlobalConfig.Set("RSBot.General.EnableAutomatedLogin", value.ToString());
        }
    }

    public ObservableCollection<Account> Accounts { get; } = [];

    public Account SelectedAccount
    {
        get => _selectedAccount;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedAccount, value);
            if (value != null)
            {
                GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", value.Username);
                LoadCharacters();
            }
        }
    }

    public ObservableCollection<string> Characters { get; } = [];

    public string SelectedCharacter
    {
        get => _selectedCharacter;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedCharacter, value);
            if (value != null && SelectedAccount != null)
            {
                SelectedAccount.SelectedCharacter = value;
                Components.Accounts.Save();
            }
        }
    }

    public bool EnableStaticCaptcha
    {
        get => _enableStaticCaptcha;
        set
        {
            this.RaiseAndSetIfChanged(ref _enableStaticCaptcha, value);
            GlobalConfig.Set("RSBot.General.EnableStaticCaptcha", value.ToString());
        }
    }

    public string StaticCaptcha
    {
        get => _staticCaptcha;
        set
        {
            this.RaiseAndSetIfChanged(ref _staticCaptcha, value);
            GlobalConfig.Set("RSBot.General.StaticCaptcha", value);
        }
    }

    public bool EnableLoginDelay
    {
        get => _enableLoginDelay;
        set
        {
            this.RaiseAndSetIfChanged(ref _enableLoginDelay, value);
            GlobalConfig.Set("RSBot.General.EnableLoginDelay", value);
        }
    }

    public int LoginDelay
    {
        get => _loginDelay;
        set
        {
            this.RaiseAndSetIfChanged(ref _loginDelay, value);
            GlobalConfig.Set("RSBot.General.LoginDelay", value);
        }
    }

    public bool HideClientOnStart
    {
        get => _hideClientOnStart;
        set
        {
            this.RaiseAndSetIfChanged(ref _hideClientOnStart, value);
            GlobalConfig.Set("RSBot.General.HideOnStartClient", value);
        }
    }

    public bool AutoSelectCharacter
    {
        get => _autoSelectCharacter;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoSelectCharacter, value);
            GlobalConfig.Set("RSBot.General.CharacterAutoSelect", value);
        }
    }

    public bool AutoSelectFirst
    {
        get => _autoSelectFirst;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoSelectFirst, value);
            GlobalConfig.Set("RSBot.General.CharacterAutoSelectFirst", value);
        }
    }

    public bool StartBotAfterLogin
    {
        get => _startBotAfterLogin;
        set
        {
            this.RaiseAndSetIfChanged(ref _startBotAfterLogin, value);
            GlobalConfig.Set("RSBot.General.StartBot", value);
        }
    }

    public bool UseReturnScroll
    {
        get => _useReturnScroll;
        set
        {
            this.RaiseAndSetIfChanged(ref _useReturnScroll, value);
            GlobalConfig.Set("RSBot.General.UseReturnScroll", value);
        }
    }

    public bool StayConnected
    {
        get => _stayConnected;
        set
        {
            this.RaiseAndSetIfChanged(ref _stayConnected, value);
            GlobalConfig.Set("RSBot.General.StayConnected", value);
        }
    }

    public ObservableCollection<GameClientType> ClientTypes { get; } = [.. Enum.GetValues<GameClientType>()];

    public GameClientType SelectedClientType
    {
        get => _selectedClientType;
        set
        {
            if (Game.Player != null)
            {
                // Show warning message
                return;
            }

            this.RaiseAndSetIfChanged(ref _selectedClientType, value);
            GlobalConfig.Set("RSBot.Game.ClientType", value);
            Game.ClientType = value;
            GlobalConfig.Save();
        }
    }

    public bool MinimizeToTray
    {
        get => _minimizeToTray;
        set
        {
            this.RaiseAndSetIfChanged(ref _minimizeToTray, value);
            GlobalConfig.Set("RSBot.General.TrayWhenMinimize", value);
        }
    }

    public bool AutoHidePendingWindow
    {
        get => _autoHidePendingWindow;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoHidePendingWindow, value);
            GlobalConfig.Set("RSBot.General.AutoHidePendingWindow", value);
        }
    }

    public bool EnableQueueLogs
    {
        get => _enableQueueLogs;
        set
        {
            this.RaiseAndSetIfChanged(ref _enableQueueLogs, value);
            GlobalConfig.Set("RSBot.General.PendingEnableQueueLogs", value);
        }
    }

    public bool EnableQueueNotification
    {
        get => _enableQueueNotification;
        set
        {
            this.RaiseAndSetIfChanged(ref _enableQueueNotification, value);
            GlobalConfig.Set("RSBot.General.EnableQueueNotification", value);
        }
    }

    public int QueueNotificationThreshold
    {
        get => _queueNotificationThreshold;
        set
        {
            this.RaiseAndSetIfChanged(ref _queueNotificationThreshold, value);
            GlobalConfig.Set("RSBot.General.QueueLeft", value);
        }
    }

    #endregion

    #region Commands

    public ReactiveCommand<Unit, Unit> BrowseCommand { get; }
    public ReactiveCommand<Unit, Unit> StartClientCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> StartClientlessCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> ToggleClientVisibilityCommand { get; }
    public ReactiveCommand<Unit, Unit> GoClientlessCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> ShowAutoLoginSettingsCommand { get; }
    public ReactiveCommand<Unit, Unit> ShowQueueCommand { get; }

    #endregion

    public MainViewModel()
    {
        BrowseCommand = ReactiveCommand.CreateFromTask(BrowseAsync);
        StartClientCommand = ReactiveCommand.Create(StartClient);
        StartClientlessCommand = ReactiveCommand.Create(StartClientless);
        ToggleClientVisibilityCommand = ReactiveCommand.Create(ToggleClientVisibility);
        GoClientlessCommand = ReactiveCommand.Create(GoClientless);
        ShowAutoLoginSettingsCommand = ReactiveCommand.Create(ShowAutoLoginSettings);
        ShowQueueCommand = ReactiveCommand.Create(ShowQueue);

        LoadSettings();
        SubscribeEvents();
    }

    private async Task BrowseAsync()
    {
        var dialog = new OpenFileDialog
        {
            Title = "Select Silkroad executable",
            Filters =
            [
                new FileDialogFilter { Name = "Silkroad executable", Extensions = { "exe" } }
            ]
        };

        var result = await dialog.ShowAsync(null);
        if (result?.Length > 0)
        {
            SilkroadPath = result[0];
            SaveSettings();
        }
    }

    private void StartClient()
    {
        if (!Game.Clientless && Kernel.Proxy != null && Kernel.Proxy.IsConnectedToAgentserver)
        {
            var extraStr = "KillClientWarnMsgBoxSplit1";
            if (!GlobalConfig.Get<bool>("RSBot.General.StayConnected"))
                extraStr = "KillClientWarnMsgBoxSplit2";

            MessageBox.Show(extraStr);
            // Show warning message
            ClientManager.Kill();
            return;
        }

        StartClientProcess();
    }

    private async Task StartClientProcess()
    {
        IsClientRunning = false;
        Game.Start();

        await Task.Run(async () =>
        {
            var startedResult = await ClientManager.Start();
            if (!startedResult)
            {
                OnExitClient();
                Log.WarnLang("ClientStartingError");
            }
        });
    }

    private void StartClientless()
    {
        if (!Game.Clientless)
        {
            if (!EnableAutoLogin || SelectedAccount == null)
            {
                // Show warning message
                return;
            }

            IsClientRunning = false;
            _clientVisible = false;

            Game.Clientless = true;
            Log.StatusLang("StartingClientless");
            Game.Start();
        }
        else
        {
            // Show warning message
            Game.Clientless = false;

            IsClientRunning = true;
            StartClientCommand = ReactiveCommand.Create(StartClient);

            Kernel.Proxy.Shutdown();
        }
    }

    private void ToggleClientVisibility()
    {
        if (!ClientManager.IsRunning)
            return;

        _clientVisible = !_clientVisible;
        ClientManager.SetVisible(_clientVisible);
    }

    private void GoClientless()
    {
        if (Game.Clientless)
            return;

        // Show warning message

        ClientlessManager.GoClientless();
        ClientManager.Kill();

        IsClientRunning = false;
        _clientVisible = false;
    }

    private void ShowAutoLoginSettings()
    {
        // Show accounts window
        LoadAccounts();
    }

    private void ShowQueue()
    {
        if (!Components.AutoLogin.Pending)
            return;

        // Show pending window
    }

    private void LoadSettings()
    {
        SilkroadPath = Path.Combine(
        GlobalConfig.Get<string>("RSBot.SilkroadDirectory"),
        GlobalConfig.Get<string>("RSBot.SilkroadExecutable"));
        EnableStaticCaptcha = GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha");
        EnableAutoLogin = GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin");
        StartBotAfterLogin = GlobalConfig.Get<bool>("RSBot.General.StartBot");
        UseReturnScroll = GlobalConfig.Get<bool>("RSBot.General.UseReturnScroll");
        StayConnected = GlobalConfig.Get<bool>("RSBot.General.StayConnected");
        MinimizeToTray = GlobalConfig.Get<bool>("RSBot.General.TrayWhenMinimize");
        StaticCaptcha = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
        EnableLoginDelay = GlobalConfig.Get<bool>("RSBot.General.EnableLoginDelay");
        LoginDelay = GlobalConfig.Get("RSBot.General.LoginDelay", 10);
        HideClientOnStart = GlobalConfig.Get<bool>("RSBot.General.HideOnStartClient");
        AutoSelectCharacter = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelect");
        AutoSelectFirst = GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectFirst");
        AutoHidePendingWindow = GlobalConfig.Get<bool>("RSBot.General.AutoHidePendingWindow");
        EnableQueueLogs = GlobalConfig.Get<bool>("RSBot.General.PendingEnableQueueLogs");
        EnableQueueNotification = GlobalConfig.Get<bool>("RSBot.General.EnableQueueNotification");
        QueueNotificationThreshold = GlobalConfig.Get("RSBot.General.QueueLeft", 30);

        SelectedClientType = Game.ClientType;

        Components.Accounts.Load();
        LoadAccounts();
    }

    private static void SaveSettings() => GlobalConfig.Save();

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadVersionInfo", new Action<VersionInfo>(OnLoadVersionInfo));
        EventManager.SubscribeEvent("OnAgentServerConnected", OnAgentServerConnected);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnGatewayServerDisconnected", OnGatewayServerDisconnected);
        EventManager.SubscribeEvent("OnClientConnected", OnClientConnected);
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        EventManager.SubscribeEvent("OnStartClient", OnStartClient);
        EventManager.SubscribeEvent("OnExitClient", OnExitClient);
        EventManager.SubscribeEvent("OnCharacterListReceived", OnCharacterListReceived);
        EventManager.SubscribeEvent("OnInitialized", OnInitialized);
        EventManager.SubscribeEvent("OnProfileChanged", OnProfileChanged);
    }

    private void OnProfileChanged()
    {
        Components.Accounts.Load();
        LoadAccounts();
    }

    private void OnGatewayServerDisconnected()
    {
        Components.AutoLogin.Pending = false;
        // Hide pending window

        if (!Kernel.Proxy.IsConnectedToAgentserver)
        {
            Game.Clientless = false;

            IsClientRunning = true;
            Log.StatusLang("Ready");
            Kernel.Proxy.Shutdown();
        }
    }

    private void OnInitialized()
    {
        LoadSettings();
    }

    private void OnCharacterListReceived()
    {
        LoadAccounts();
    }

    private void LoadAccounts()
    {
        Accounts.Clear();
        Accounts.Add(null); // No selected

        var autoLoginUserName = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
        foreach (var account in Components.Accounts.SavedAccounts)
        {
            Accounts.Add(account);
            if (account.Username == autoLoginUserName)
                SelectedAccount = account;
        }

        SelectedAccount ??= Accounts[0];
    }

    private void LoadCharacters()
    {
        Characters.Clear();
        Characters.Add(null); // No selected

        if (SelectedAccount?.Characters == null)
        {
            SelectedCharacter = null;
            return;
        }

        foreach (var character in SelectedAccount.Characters.Where(n => n != null))
        {
            Characters.Add(character);
            if (character == SelectedAccount.SelectedCharacter)
                SelectedCharacter = character;
        }

        if (SelectedCharacter == null ||
            string.IsNullOrWhiteSpace(SelectedAccount.SelectedCharacter))
            SelectedCharacter = Characters[0];
    }

    private async void OnEnterGame()
    {
        if (!Game.Clientless)
        {
            IsClientRunning = true;
            _clientVisible = true;
        }

        //Wait for the game to be ready!
        while (!Game.Ready)
            await Task.Delay(100);

        if (UseReturnScroll)
            Game.Player.UseReturnScroll();

        if (StartBotAfterLogin)
            Kernel.Bot.Start();
    }

    private void OnLoadVersionInfo(VersionInfo info)
    {
        Version = "v" + ((1000f + info.Version) / 1000f).ToString("0.000", CultureInfo.InvariantCulture);
    }

    private void OnAgentServerConnected()
    {
        // Implementation
    }

    private async void OnAgentServerDisconnected()
    {
        Kernel.Bot.Stop();

        if (Game.Clientless)
            return;

        ClientManager.Kill();

        if (EnableAutoLogin)
        {
            IsClientRunning = false;

            Thread.Sleep(2000);

            await StartClientProcess().ConfigureAwait(false);
            return;
        }

        IsClientRunning = true;
    }

    private void OnClientConnected()
    {
        StartClientlessCommand = ReactiveCommand.Create(() => { });
    }

    private void OnStartClient()
    {
        IsClientRunning = false;
        _clientVisible = true;

        if (HideClientOnStart)
            ClientManager.SetVisible(false);
    }

    private void OnExitClient()
    {
        Log.StatusLang("Ready");
        _clientVisible = false;

        if (Game.Clientless)
            return;

        IsClientRunning = true;

        if (!StayConnected)
        {
            Kernel.Proxy.Shutdown();
        }
        else
        {
            if (!Kernel.Proxy.IsConnectedToAgentserver)
                return;

            IsClientRunning = false;

            ClientlessManager.GoClientless();

            GoClientlessCommand = ReactiveCommand.Create(() => { });
            Log.NotifyLang("ClientlessModeActivated");
        }
    }
} 