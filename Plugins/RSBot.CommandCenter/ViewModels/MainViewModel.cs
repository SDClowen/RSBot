using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Controls;
using RSBot.CommandCenter.Components;
using RSBot.CommandCenter.Views.Controls;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.CommandCenter.ViewModels;

/// <summary>
/// Main ViewModel for the Command Center plugin that manages the UI state and interactions
/// </summary>
public class MainViewModel : INotifyPropertyChanged
{
    private bool _isEnabled;
    private int _selectedTabIndex;

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets or sets whether the command center is enabled
    /// </summary>
    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            if (_isEnabled == value) return;
            _isEnabled = value;
            PlayerConfig.Set("RSBot.CommandCenter.Enabled", value);
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the selected tab index
    /// </summary>
    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set
        {
            if (_selectedTabIndex == value) return;
            _selectedTabIndex = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the collection of emoticon action elements
    /// </summary>
    public ObservableCollection<EmoticonActionElement> EmoticonActions { get; }

    /// <summary>
    /// Gets the chat command descriptions
    /// </summary>
    public string ChatCommandDescriptions { get; private set; }

    /// <summary>
    /// Gets the command to reset settings to defaults
    /// </summary>
    public ICommand ResetToDefaultsCommand { get; }

    /// <summary>
    /// Gets the command to save settings
    /// </summary>
    public ICommand SaveCommand { get; }

    /// <summary>
    /// Initializes a new instance of the MainViewModel class
    /// </summary>
    public MainViewModel()
    {
        EmoticonActions = new ObservableCollection<EmoticonActionElement>();
        ResetToDefaultsCommand = new RelayCommand(ResetToDefaults);
        SaveCommand = new RelayCommand(Save);

        LoadSettings();
        RefreshView();
    }

    /// <summary>
    /// Loads the settings from player config
    /// </summary>
    private void LoadSettings()
    {
        IsEnabled = PlayerConfig.Get("RSBot.CommandCenter.Enabled", true);
    }

    /// <summary>
    /// Refreshes the view with current data
    /// </summary>
    private void RefreshView()
    {
        EmoticonActions.Clear();
        PopulateEmoticonActions();
        PopulateChatCommandPage();
    }

    /// <summary>
    /// Populates the emoticon actions list
    /// </summary>
    private void PopulateEmoticonActions()
    {
        foreach (var emoticon in Emoticons.Items)
        {
            var selectedName = PluginConfig.GetAssignedEmoteCommand(emoticon.Name);
            EmoticonActions.Add(new EmoticonActionElement(emoticon, selectedName));
        }
    }

    /// <summary>
    /// Populates the chat command descriptions
    /// </summary>
    private void PopulateChatCommandPage()
    {
        var descriptions = string.Empty;

        foreach (var commandDescription in CommandManager.GetCommandDescriptions())
        {
            if (commandDescription.Key == "none")
                continue;

            descriptions += $"\\{commandDescription.Key}\t{commandDescription.Value}{Environment.NewLine}";
        }

        ChatCommandDescriptions = descriptions;
        OnPropertyChanged(nameof(ChatCommandDescriptions));
    }

    /// <summary>
    /// Resets all settings to their default values
    /// </summary>
    private void ResetToDefaults()
    {
        foreach (var emoticon in Emoticons.Items)
            PlayerConfig.Set($"RSBot.CommandCenter.MappedEmotes.{emoticon.Name}",
                Emoticons.GetEmoticonDefaultCommand(emoticon.Name));

        RefreshView();
    }

    /// <summary>
    /// Saves the current settings
    /// </summary>
    private void Save()
    {
        PlayerConfig.Save();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class RelayCommand : ICommand
{
    private readonly Action _execute;

    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
        _execute();
    }
} 