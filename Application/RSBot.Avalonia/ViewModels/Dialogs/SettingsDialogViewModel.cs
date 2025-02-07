using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialogs;

/// <summary>
/// View model for the settings dialog that manages application configuration
/// </summary>
public class SettingsDialogViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _selectedLanguage;
    private GameClientType _selectedClientType;
    private string _silkroadDirectory;
    private string _proxyAddress;
    private string _proxyPort;

    public SettingsDialogViewModel(Window owner)
    {
        _owner = owner;

        LoadSettings();

        SaveCommand = ReactiveCommand.Create(ExecuteSave);
        CancelCommand = ReactiveCommand.Create(ExecuteCancel);
        BrowseCommand = ReactiveCommand.Create(ExecuteBrowse);
    }

    public List<string> Languages { get; } = new() { "en_US", "tr_TR" };
    public List<GameClientType> ClientTypes { get; } = new() 
    { 
        GameClientType.Vietnam, 
        GameClientType.Turkey, 
        GameClientType.Global 
    };
    public List<PluginInfo> Plugins { get; private set; }

    public string SelectedLanguage
    {
        get => _selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref _selectedLanguage, value);
    }

    public GameClientType SelectedClientType
    {
        get => _selectedClientType;
        set => this.RaiseAndSetIfChanged(ref _selectedClientType, value);
    }

    public string SilkroadDirectory
    {
        get => _silkroadDirectory;
        set => this.RaiseAndSetIfChanged(ref _silkroadDirectory, value);
    }

    public string ProxyAddress
    {
        get => _proxyAddress;
        set => this.RaiseAndSetIfChanged(ref _proxyAddress, value);
    }

    public string ProxyPort
    {
        get => _proxyPort;
        set => this.RaiseAndSetIfChanged(ref _proxyPort, value);
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand BrowseCommand { get; }

    private void LoadSettings()
    {
        SelectedLanguage = GlobalConfig.Get("RSBot.Language", "en_US");
        SelectedClientType = GlobalConfig.GetEnum("RSBot.Game.ClientType", GameClientType.Vietnam);
        SilkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
        ProxyAddress = GlobalConfig.Get("RSBot.Proxy.Address", string.Empty);
        ProxyPort = GlobalConfig.Get("RSBot.Proxy.Port", string.Empty);
        
        LoadPlugins();
    }

    private void LoadPlugins()
    {
        Plugins = new List<PluginInfo>();
        foreach (var plugin in Kernel.PluginManager.Extensions)
        {
            Plugins.Add(new PluginInfo
            {
                Name = plugin.Value.InternalName,
                IsEnabled = plugin.Value.RequireIngame
            });
        }
    }

    private void ExecuteSave()
    {
        GlobalConfig.Set("RSBot.Language", SelectedLanguage);
        GlobalConfig.Set("RSBot.Game.ClientType", SelectedClientType);
        GlobalConfig.Set("RSBot.SilkroadDirectory", SilkroadDirectory);
        GlobalConfig.Set("RSBot.Proxy.Address", ProxyAddress);
        GlobalConfig.Set("RSBot.Proxy.Port", ProxyPort);

        //foreach (var plugin in Plugins)
        //{
        //    var kernelPlugin = Kernel.PluginManager.Extensions.FirstOrDefault(p => p.Value.InternalName == plugin.Name);
        //    if (kernelPlugin != null)
        //        kernelPlugin.Value.RequireIngame = plugin.IsEnabled;
        //}

        GlobalConfig.Save();
        _owner.Close();
    }

    private void ExecuteCancel()
    {
        _owner.Close();
    }

    private async void ExecuteBrowse()
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Select Silkroad Directory"
        };

        var result = await dialog.ShowAsync(_owner);
        if (!string.IsNullOrEmpty(result))
            SilkroadDirectory = result;
    }
}

public class PluginInfo
{
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
} 