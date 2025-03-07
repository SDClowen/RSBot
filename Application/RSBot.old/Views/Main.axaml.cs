using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Plugins;
using RSBot.Views.Dialog;

namespace RSBot.Views;

/// <summary>
/// The main window of the RSBot application
/// Handles the core UI functionality and plugin management
/// </summary>
public partial class Main : Window
{
    #region Members

    private string _playerName;
    private readonly Dictionary<string, Window> _pluginWindows = new(8);
    private readonly TrayIcon _trayIcon;

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();

        _trayIcon = new TrayIcon
        {
            Icon = new WindowIcon(AssetLoader.Open(new Uri("avares://RSBot/Resources/app.ico"))),
            ToolTipText = "RSBot",
            IsVisible = true
        };
        _trayIcon.Clicked += (s, e) => Show();

        RegisterEvents();
        Title = "RSBot";
    }

    #endregion

    #region Methods

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void RegisterEvents()
    {
        EventManager.SubscribeEvent("OnLoadPlugins", new Action<List<IPlugin>>(OnLoadPlugins));
        EventManager.SubscribeEvent("OnLoadBotbases", new Action<List<IBotbase>>(OnLoadBotbases));
        EventManager.SubscribeEvent("OnLoadLanguages", new Action<List<string>>(OnLoadLanguages));
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        EventManager.SubscribeEvent("OnStopBot", OnStopBot);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnAgentServerConnected", OnAgentServerConnected);
        EventManager.SubscribeEvent("OnLoadCharacter", new Action<string>(OnLoadCharacter));
        EventManager.SubscribeEvent("OnChangeStatus", new Action<string>(OnChangeStatus));
    }

    private void OnLoadPlugins(List<IPlugin> plugins)
    {
        var menuPlugins = this.FindControl<MenuItem>("menuPlugins");
        menuPlugins.Items = plugins.Select(plugin => new MenuItem
        {
            Header = plugin.DisplayName,
            Tag = plugin
        }).ToList();

        foreach (var item in menuPlugins.Items.Cast<MenuItem>())
            item.Click += PluginMenuItem_Click;
    }

    private void OnLoadBotbases(List<IBotbase> botbases)
    {
        var botsMenu = this.FindControl<MenuItem>("botsToolStripMenuItem");
        botsMenu.Items = botbases.Select(botbase => new MenuItem
        {
            Header = botbase.Name,
            Tag = botbase
        }).ToList();

        foreach (var item in botsMenu.Items.Cast<MenuItem>())
            item.Click += BotbaseMenuItem_Click;
    }

    private void OnLoadLanguages(List<string> languages)
    {
        var languageMenu = this.FindControl<MenuItem>("languageToolStripMenuItem");
        languageMenu.Items = languages.Select(lang => new MenuItem
        {
            Header = lang,
            Tag = lang
        }).ToList();

        foreach (var item in languageMenu.Items.Cast<MenuItem>())
            item.Click += LanguageMenuItem_Click;
    }

    private void OnStartBot()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var btnStartStop = this.FindControl<Button>("btnStartStop");
            btnStartStop.Content = "STOP BOT";
        });
    }

    private void OnStopBot()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var btnStartStop = this.FindControl<Button>("btnStartStop");
            btnStartStop.Content = "START BOT";
        });
    }

    private void OnAgentServerDisconnected()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblIngameStatus = this.FindControl<TextBlock>("lblIngameStatus");
            lblIngameStatus.Text = "Not in game";
        });
    }

    private void OnAgentServerConnected()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblIngameStatus = this.FindControl<TextBlock>("lblIngameStatus");
            lblIngameStatus.Text = "Connected";
        });
    }

    private void OnLoadCharacter(string name)
    {
        _playerName = name;
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            Title = $"RSBot - {name}";
        });
    }

    private void OnChangeStatus(string status)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblIngameStatus = this.FindControl<TextBlock>("lblIngameStatus");
            lblIngameStatus.Text = status;
        });
    }

    private async void PluginMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var plugin = (IPlugin)menuItem.Tag;

        if (!_pluginWindows.TryGetValue(plugin.InternalName, out var pluginWindow) || pluginWindow.IsVisible == false)
        {
            pluginWindow = new Window
            {
                Title = plugin.DisplayName,
                Name = plugin.InternalName,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Content = plugin.View,
                SizeToContent = SizeToContent.WidthAndHeight,
                CanResize = false,
                Icon = Icon
            };

            plugin.Translate();
            _pluginWindows[plugin.InternalName] = pluginWindow;
        }

        await pluginWindow.ShowDialog(this);
    }

    private void BotbaseMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var botbase = (IBotbase)menuItem.Tag;

        Kernel.Bot.BotbaseManager.LoadBotbase(botbase);
    }

    private void LanguageMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var language = (string)menuItem.Tag;

        GlobalConfig.Set("RSBot.Language", language);
        LanguageManager.Load(language);
    }

    private void menuSelectProfile_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ProfileSelectionDialog();
        if (dialog.ShowDialog(this))
        {
            ProfileManager.SetSelectedProfile(dialog.SelectedProfile);
            GlobalConfig.Load();

            var menuCurrentProfile = this.FindControl<TextBlock>("menuCurrentProfile");
            menuCurrentProfile.Text = $"Profile: {dialog.SelectedProfile}";
        }
    }

    private void menuItemExit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void menuSidebar_Click(object sender, RoutedEventArgs e)
    {
        var pSidebar = this.FindControl<Grid>("pSidebar");
        pSidebar.IsVisible = !pSidebar.IsVisible;
    }

    private void comboDivision_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboDivision = (ComboBox)sender;
        GlobalConfig.Set("RSBot.GatewayIndex", comboDivision.SelectedIndex.ToString());
    }

    private void comboServer_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboServer = (ComboBox)sender;
        GlobalConfig.Set("RSBot.GatewayIndex", comboServer.SelectedIndex.ToString());
    }

    private void buttonConfig_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Implement network configuration dialog
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        GlobalConfig.Save();
    }

    private void btnStartStop_Click(object sender, RoutedEventArgs e)
    {
        if (Kernel.Bot.Running)
            Kernel.Bot.Stop();
        else
            Kernel.Bot.Start();
    }

    private void darkToolStripMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        GlobalConfig.Set("RSBot.Theme", "Dark");
    }

    private void lightToolStripMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        GlobalConfig.Set("RSBot.Theme", "Light");
    }

    private void autoToolStripMenuItem_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.RequestedThemeVariant = null;
        GlobalConfig.Set("RSBot.Theme", "Auto");
    }

    private void coloredToolStripMenuItem_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Implement colored theme
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        base.OnClosing(e);
        _trayIcon.Dispose();
    }

    #endregion
} 