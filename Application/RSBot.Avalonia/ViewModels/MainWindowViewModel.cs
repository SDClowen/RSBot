using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Views.Controls;
using RSBot.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Input;

namespace RSBot.ViewModels;

/// <summary>
/// View model for the main window that manages all child view models and application state
/// </summary>
public class MainWindowViewModel : ReactiveObject
{
    #region Private Fields

    private string _startButtonText = "Start Bot";
    private IBrush _startButtonBackground;
    private IBrush _startButtonBorderBrush;
    private bool _cosManagerVisible = false;
    private string _statusText = "Waiting for user login";
    private bool _isBotRunning;
    private string _playerName;
    private string _selectedDivision;
    private string _selectedServer;
    private readonly Dictionary<string, Window> _pluginWindows = new();
    private Window _mainWindow;

    #endregion

    /// <summary>
    /// Initializes a new instance of the MainWindowViewModel class
    /// </summary>
    /// <param name="mainWindow">The main window instance</param>
    public MainWindowViewModel(Window mainWindow)
    {
        _mainWindow = mainWindow;
        Character = new CharacterViewModel();
        Entity = new EntityViewModel();
        StartButtonBackground = new SolidColorBrush(Colors.DodgerBlue);
        StartButtonBorderBrush = new SolidColorBrush(Colors.Gray);

        BotBases = new ObservableCollection<BotBaseInfo>();
        Plugins = new ObservableCollection<PluginInfo>();
        Languages = new ObservableCollection<KeyValuePair<string, string>>();
        Divisions = new ObservableCollection<string>();
        Servers = new ObservableCollection<string>();

        InitializeCommands();
        SubscribeEvents();
        LoadLanguages();
        LoadBotBases();
        LoadPlugins();
    }

    #region Public Properties

    /// <summary>
    /// Gets the character view model
    /// </summary>
    public CharacterViewModel Character { get; }

    /// <summary>
    /// Gets the entity view model
    /// </summary>
    public EntityViewModel Entity { get; }

    /// <summary>
    /// Gets the collection of available bot bases
    /// </summary>
    public ObservableCollection<BotBaseInfo> BotBases { get; }

    /// <summary>
    /// Gets the collection of available plugins
    /// </summary>
    public ObservableCollection<PluginInfo> Plugins { get; }

    /// <summary>
    /// Gets the collection of available languages
    /// </summary>
    public ObservableCollection<KeyValuePair<string, string>> Languages { get; }

    /// <summary>
    /// Gets the collection of available divisions
    /// </summary>
    public ObservableCollection<string> Divisions { get; }

    /// <summary>
    /// Gets the collection of available servers
    /// </summary>
    public ObservableCollection<string> Servers { get; }

    /// <summary>
    /// Gets or sets the text displayed on the start/stop button
    /// </summary>
    public string StartButtonText
    {
        get => _startButtonText;
        set => this.RaiseAndSetIfChanged(ref _startButtonText, value);
    }

    /// <summary>
    /// Gets or sets the background color of the start/stop button
    /// </summary>
    public IBrush StartButtonBackground
    {
        get => _startButtonBackground;
        set => this.RaiseAndSetIfChanged(ref _startButtonBackground, value);
    }

    /// <summary>
    /// Gets or sets the border color of the start/stop button
    /// </summary>
    public IBrush StartButtonBorderBrush
    {
        get => _startButtonBorderBrush;
        set => this.RaiseAndSetIfChanged(ref _startButtonBorderBrush, value);
    }

    /// <summary>
    /// Gets or sets whether the COS manager is visible
    /// </summary>
    public bool CosManagerVisible
    {
        get => _cosManagerVisible;
        set => this.RaiseAndSetIfChanged(ref _cosManagerVisible, value);
    }

    /// <summary>
    /// Gets or sets the status text displayed in the status bar
    /// </summary>
    public string StatusText
    {
        get => _statusText;
        set => this.RaiseAndSetIfChanged(ref _statusText, value);
    }

    /// <summary>
    /// Gets or sets the selected division
    /// </summary>
    public string SelectedDivision
    {
        get => _selectedDivision;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedDivision, value);
            OnDivisionChanged();
        }
    }

    /// <summary>
    /// Gets or sets the selected server
    /// </summary>
    public string SelectedServer
    {
        get => _selectedServer;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedServer, value);
            OnServerChanged();
        }
    }

    #endregion

    #region Commands

    /// <summary>
    /// Gets the command to start or stop the bot
    /// </summary>
    public ICommand StartStopCommand { get; private set; }

    /// <summary>
    /// Gets the command to toggle the COS manager visibility
    /// </summary>
    public ICommand ToggleCosManagerCommand { get; private set; }

    /// <summary>
    /// Gets the command to show the settings dialog
    /// </summary>
    public ICommand ShowSettingsCommand { get; private set; }

    /// <summary>
    /// Gets the command to show the about dialog
    /// </summary>
    public ICommand ShowAboutCommand { get; private set; }

    /// <summary>
    /// Gets the command to exit the application
    /// </summary>
    public ICommand ExitCommand { get; private set; }

    /// <summary>
    /// Gets the command to select a profile
    /// </summary>
    public ICommand SelectProfileCommand { get; private set; }

    /// <summary>
    /// Gets the command to show the script recorder
    /// </summary>
    public ICommand ShowScriptRecorderCommand { get; private set; }

    /// <summary>
    /// Gets the command to show the network configuration dialog
    /// </summary>
    public ICommand ShowNetworkConfigCommand { get; private set; }

    /// <summary>
    /// Gets the command to select a bot base
    /// </summary>
    public ICommand SelectBotBaseCommand { get; private set; }

    /// <summary>
    /// Gets the command to show a plugin window
    /// </summary>
    public ICommand ShowPluginCommand { get; private set; }

    /// <summary>
    /// Gets the command to select a language
    /// </summary>
    public ICommand SelectLanguageCommand { get; private set; }

    /// <summary>
    /// Gets the command to set the theme
    /// </summary>
    public ICommand SetThemeCommand { get; private set; }

    /// <summary>
    /// Gets the command to set a custom theme
    /// </summary>
    public ICommand SetCustomThemeCommand { get; private set; }

    /// <summary>
    /// Gets the command to open donation links
    /// </summary>
    public ICommand DonateCommand { get; private set; }

    /// <summary>
    /// Initializes all commands
    /// </summary>
    private void InitializeCommands()
    {
        StartStopCommand = ReactiveCommand.Create(ExecuteStartStop);
        ToggleCosManagerCommand = ReactiveCommand.Create(ExecuteToggleCosManager);
        ShowSettingsCommand = ReactiveCommand.Create(ExecuteShowSettings);
        ShowAboutCommand = ReactiveCommand.Create(ExecuteShowAbout);
        ExitCommand = ReactiveCommand.Create(ExecuteExit);
        SelectProfileCommand = ReactiveCommand.Create(ExecuteSelectProfile);
        ShowScriptRecorderCommand = ReactiveCommand.Create(ExecuteShowScriptRecorder);
        ShowNetworkConfigCommand = ReactiveCommand.Create(ExecuteShowNetworkConfig);
        SelectBotBaseCommand = ReactiveCommand.Create<string>(ExecuteSelectBotBase);
        ShowPluginCommand = ReactiveCommand.Create<PluginInfo>(ExecuteShowPlugin);
        SelectLanguageCommand = ReactiveCommand.Create<string>(ExecuteSelectLanguage);
        SetThemeCommand = ReactiveCommand.Create<string>(ExecuteSetTheme);
        SetCustomThemeCommand = ReactiveCommand.Create(ExecuteSetCustomTheme);
        DonateCommand = ReactiveCommand.Create(ExecuteDonate);
    }

    #endregion

    #region Event Handlers

    /// <summary>
    /// Subscribes to all required events
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnLoadDivisionInfo", new Action<DivisionInfo>(OnLoadDivisionInfo));
        EventManager.SubscribeEvent("OnLoadPlugins", OnLoadPlugins);
        EventManager.SubscribeEvent("OnLoadBotbases", OnLoadBotbases);
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        EventManager.SubscribeEvent("OnStopBot", OnStopBot);
    }

    /// <summary>
    /// Handles the character load event
    /// </summary>
    private void OnLoadCharacter()
    {
        _playerName = Game.Player.Name;
        StatusText = $"Connected: {_playerName}";

        foreach (var plugin in Plugins)
            plugin.IsEnabled = true;

        if (Game.Clientless)
            StatusText += " [Clientless]";

        if (Kernel.Debug)
            StatusText += $" [JID = {Game.Player.JID}]";
    }

    /// <summary>
    /// Handles the agent server disconnected event
    /// </summary>
    private void OnAgentServerDisconnected()
    {
        StatusText = "Waiting for user login";
    }

    /// <summary>
    /// Handles the division info load event
    /// </summary>
    private void OnLoadDivisionInfo(DivisionInfo info)
    {
        Divisions.Clear();
        foreach (var division in info.Divisions)
            Divisions.Add(division.Name);

        var divisionIndex = GlobalConfig.Get<int>("RSBot.DivisionIndex");
        if (Divisions.Count > divisionIndex)
            SelectedDivision = Divisions[divisionIndex];

        PopulateServerCombobox(info);
    }

    /// <summary>
    /// Handles the plugins load event
    /// </summary>
    private void OnLoadPlugins()
    {
        LoadPlugins();
    }

    /// <summary>
    /// Handles the bot bases load event
    /// </summary>
    private void OnLoadBotbases()
    {
        LoadBotBases();
        SelectBotBase(GlobalConfig.Get("RSBot.BotName", "RSBot.Default"));
    }

    /// <summary>
    /// Handles the bot start event
    /// </summary>
    private void OnStartBot()
    {
        StartButtonText = LanguageManager.GetLang("StopBot");
    }

    /// <summary>
    /// Handles the bot stop event
    /// </summary>
    private void OnStopBot()
    {
        StartButtonText = LanguageManager.GetLang("StartBot");
    }

    #endregion

    #region Command Handlers

    /// <summary>
    /// Executes the start/stop command
    /// </summary>
    private void ExecuteStartStop()
    {
        if (Kernel.Proxy == null || !Kernel.Proxy.IsConnectedToAgentserver)
            return;

        if (Kernel.Bot == null)
        {
            Log.NotifyLang("NotifyPleaseSelectProperBotBase");
            return;
        }

        if (Game.Player == null)
        {
            Log.WarnLang("NotifyPlayerWasNull");
            return;
        }

        if (!_isBotRunning)
        {
            StartButtonText = "Stop Bot";
            StartButtonBackground = new SolidColorBrush(Colors.Red);
            StartButtonBorderBrush = new SolidColorBrush(Colors.Red);
            
            _isBotRunning = true;
            Kernel.Bot.Start();
            Log.Notify("Bot started");
        }
        else
        {
            StartButtonText = "Start Bot";
            StartButtonBackground = new SolidColorBrush(Colors.DodgerBlue);
            StartButtonBorderBrush = new SolidColorBrush(Colors.Gray);
            
            _isBotRunning = false;
            Kernel.Bot.Stop();
            Log.Notify("Bot stopped");
        }
    }

    /// <summary>
    /// Executes the toggle COS manager command
    /// </summary>
    private void ExecuteToggleCosManager()
    {
        CosManagerVisible = !CosManagerVisible;
    }

    /// <summary>
    /// Executes the show settings command
    /// </summary>
    private async void ExecuteShowSettings()
    {
        var dialog = new SettingsDialog();
        await dialog.ShowDialog(_mainWindow);
    }

    /// <summary>
    /// Executes the show about command
    /// </summary>
    private async void ExecuteShowAbout()
    {
        var dialog = new AboutDialog();
        await dialog.ShowDialog(_mainWindow);
    }

    /// <summary>
    /// Executes the exit command
    /// </summary>
    private async void ExecuteExit()
    {
        if (_isBotRunning)
            Kernel.Bot.Stop();

        if (Kernel.Proxy?.ClientConnected == true && GlobalConfig.Get("RSBot.showExitDialog", true))
        {
            var result = await MessageBox.Show(_mainWindow, 
                LanguageManager.GetLang("AreYouSureWantToExit"), 
                LanguageManager.GetLang("ExitConfirmation"), 
                MessageBoxButtons.YesNo);

            if (result != MessageBoxResult.Yes)
                return;
        }

        GlobalConfig.Save();
        PlayerConfig.Save();
        ClientManager.Kill();

        Environment.Exit(0);
    }

    /// <summary>
    /// Executes the select profile command
    /// </summary>
    private async void ExecuteSelectProfile()
    {
        var dialog = new ProfileSelectionDialog();
        if (await dialog.ShowDialog<bool>(_mainWindow))
        {
            if (dialog.SelectedProfile == ProfileManager.SelectedProfile)
                return;

            var oldSroPath = GlobalConfig.Get("RSBot.SilkroadDirectory", "");
            var tempNewConfig = new Config(ProfileManager.GetProfileFile(dialog.SelectedProfile));

            if (oldSroPath != tempNewConfig.Get("RSBot.SilkroadDirectory", ""))
            {
                // TODO: Show restart confirmation dialog
                // Application.Restart();
            }

            ProfileManager.SetSelectedProfile(dialog.SelectedProfile);
            GlobalConfig.Load();

            EventManager.FireEvent("OnProfileChanged");

            if (Game.Player != null)
            {
                PlayerConfig.Load(Game.Player.Name);
                EventManager.FireEvent("OnLoadCharacter");
            }
        }
    }

    /// <summary>
    /// Executes the show script recorder command
    /// </summary>
    private void ExecuteShowScriptRecorder()
    {
        var recorder = new ScriptRecorder();
        recorder.Show();
    }

    /// <summary>
    /// Executes the show network config command
    /// </summary>
    private async void ExecuteShowNetworkConfig()
    {
        var dialog = new NetworkConfigDialog();
        await dialog.ShowDialog(_mainWindow);
    }

    /// <summary>
    /// Executes the select bot base command
    /// </summary>
    private void ExecuteSelectBotBase(string botBaseName)
    {
        if (_isBotRunning)
            return;

        var oldBotbaseName = Kernel.Bot?.Botbase?.Name;
        var newBotbase = Kernel.BotbaseManager.Bots.FirstOrDefault(bot => bot.Value.Name == botBaseName);
        if (newBotbase.Value == null)
        {
            Log.Error($"Botbase [{botBaseName}] could not be found!");
            return;
        }

        newBotbase.Value.Translate();
        Kernel.Bot?.SetBotbase(newBotbase.Value);
        GlobalConfig.Set("RSBot.BotName", newBotbase.Value.Name);

        foreach (var botBase in BotBases)
            botBase.IsSelected = botBase.Name == botBaseName;

        if (Game.Player != null)
            EventManager.FireEvent("OnLoadCharacter");
    }

    /// <summary>
    /// Selects a bot base by name
    /// </summary>
    private void SelectBotBase(string botBaseName)
    {
        var botBase = Kernel.BotbaseManager.Bots.FirstOrDefault(bot => bot.Value.Name == botBaseName);
        if (botBase.Value == null)
        {
            Log.Error($"Botbase [{botBaseName}] could not be found!");
            return;
        }

        botBase.Value.Translate();
        Kernel.Bot?.SetBotbase(botBase.Value);
        GlobalConfig.Set("RSBot.BotName", botBase.Value.Name);

        foreach (var bot in BotBases)
            bot.IsSelected = bot.Name == botBaseName;
    }

    /// <summary>
    /// Executes the show plugin command
    /// </summary>
    private void ExecuteShowPlugin(PluginInfo plugin)
    {
        if (!_pluginWindows.TryGetValue(plugin.Name, out var pluginWindow))
        {
            pluginWindow = new Window
            {
                Title = plugin.DisplayName,
                Width = 400,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            var content = plugin.View;
            pluginWindow.Content = content;

            _pluginWindows[plugin.Name] = pluginWindow;
        }

        pluginWindow.Show();
    }

    /// <summary>
    /// Executes the select language command
    /// </summary>
    private void ExecuteSelectLanguage(string languageKey)
    {
        Kernel.Language = languageKey;
        GlobalConfig.Set("RSBot.Language", languageKey);
        GlobalConfig.Save();

        foreach (var plugin in Kernel.PluginManager.Extensions)
            plugin.Value.Translate();

        foreach (var botbase in Kernel.BotbaseManager.Bots)
            botbase.Value.Translate();

        LoadLanguages();
    }

    /// <summary>
    /// Executes the set theme command
    /// </summary>
    private void ExecuteSetTheme(string theme)
    {
        switch (theme)
        {
            case "Light":
                GlobalConfig.Set("RSBot.Theme.Auto", false);
                // TODO: Apply light theme
                break;
            case "Dark":
                GlobalConfig.Set("RSBot.Theme.Auto", false);
                // TODO: Apply dark theme
                break;
            case "Auto":
                GlobalConfig.Set("RSBot.Theme.Auto", true);
                // TODO: Apply system theme
                break;
        }
    }

    /// <summary>
    /// Executes the set custom theme command
    /// </summary>
    private async void ExecuteSetCustomTheme()
    {
        //var dialog = new ColorDialog();
        //if (await dialog.ShowDialog<Color?>(App.Current.MainWindow) is Color color)
        //{
        //    // TODO: Apply custom color theme
        //}
    }

    /// <summary>
    /// Executes the donate command
    /// </summary>
    private void ExecuteDonate()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://buymeacoffee.com/sdclowen", UseShellExecute = true });
        Process.Start(new ProcessStartInfo { FileName = "https://github.com/sponsors/SDClowen", UseShellExecute = true });
        Process.Start(new ProcessStartInfo { FileName = "https://www.patreon.com/sdclowen", UseShellExecute = true });
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Loads available languages
    /// </summary>
    private void LoadLanguages()
    {
        Languages.Clear();
        foreach (var language in LanguageManager.GetLanguages())
            Languages.Add(language);
    }

    /// <summary>
    /// Loads available bot bases
    /// </summary>
    private void LoadBotBases()
    {
        BotBases.Clear();
        foreach (var botBase in Kernel.BotbaseManager.Bots)
        {
            BotBases.Add(new BotBaseInfo
            {
                Name = botBase.Value.Name,
                DisplayName = botBase.Value.DisplayName,
                IsSelected = botBase.Value.Name == GlobalConfig.Get("RSBot.BotName", "RSBot.Default")
            });
        }
    }

    /// <summary>
    /// Loads available plugins
    /// </summary>
    private void LoadPlugins()
    {
        Plugins.Clear();
        foreach (var plugin in Kernel.PluginManager.Extensions)
        {
            Plugins.Add(new PluginInfo
            {
                Name = plugin.Value.InternalName,
                DisplayName = plugin.Value.DisplayName,
                IsEnabled = !plugin.Value.RequireIngame,
                View = plugin.Value.View
            });
        }
    }

    /// <summary>
    /// Populates the server combobox based on the selected division
    /// </summary>
    private void PopulateServerCombobox(DivisionInfo info)
    {
        Servers.Clear();
        if (SelectedDivision != null)
        {
            var divisionIndex = Divisions.IndexOf(SelectedDivision);
            foreach (var server in info.Divisions[divisionIndex].GatewayServers)
                Servers.Add(server);

            var gatewayIndex = GlobalConfig.Get<int>("RSBot.GatewayIndex");
            if (Servers.Count > gatewayIndex)
                SelectedServer = Servers[gatewayIndex];
        }
    }

    /// <summary>
    /// Handles division selection change
    /// </summary>
    private void OnDivisionChanged()
    {
        if (SelectedDivision != null)
        {
            var index = Divisions.IndexOf(SelectedDivision);
            GlobalConfig.Set("RSBot.DivisionIndex", index.ToString());

            if (Game.ReferenceManager.DivisionInfo != null)
                PopulateServerCombobox(Game.ReferenceManager.DivisionInfo);
        }
    }

    /// <summary>
    /// Handles server selection change
    /// </summary>
    private void OnServerChanged()
    {
        if (SelectedServer != null)
        {
            var index = Servers.IndexOf(SelectedServer);
            GlobalConfig.Set("RSBot.GatewayIndex", index.ToString());
        }
    }

    #endregion
}

/// <summary>
/// Represents information about a bot base
/// </summary>
public class BotBaseInfo
{
    /// <summary>
    /// Gets or sets the name of the bot base
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the display name of the bot base
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets whether the bot base is selected
    /// </summary>
    public bool IsSelected { get; set; }
}

/// <summary>
/// Represents information about a plugin
/// </summary>
public class PluginInfo
{
    /// <summary>
    /// Gets or sets the name of the plugin
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the display name of the plugin
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets whether the plugin is enabled
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the view associated with the plugin
    /// </summary>
    public object View { get; set; }
} 