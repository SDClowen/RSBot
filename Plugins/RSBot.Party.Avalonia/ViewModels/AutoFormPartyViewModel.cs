using System;
using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.Party.Services;
using System.Threading.Tasks;
using RSBot.Core.Objects.Party;

namespace RSBot.Party.ViewModels;

/// <summary>
/// View model for auto-forming party dialog that manages party formation settings
/// </summary>
public class AutoFormPartyViewModel : ReactiveObject
{
    private readonly IPartyService _partyService;
    private readonly Window _window;

    private string _title;
    private int _minLevel;
    private int _maxLevel;
    private bool _isHunting;
    private bool _isQuest;
    private bool _isTrade;
    private bool _isThief;
    private bool _autoReform;
    private bool _autoAccept;

    /// <summary>
    /// Gets or sets the title of the party
    /// </summary>
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    /// <summary>
    /// Gets or sets the minimum level requirement
    /// </summary>
    public int MinLevel
    {
        get => _minLevel;
        set => this.RaiseAndSetIfChanged(ref _minLevel, value);
    }

    /// <summary>
    /// Gets or sets the maximum level requirement
    /// </summary>
    public int MaxLevel
    {
        get => _maxLevel;
        set => this.RaiseAndSetIfChanged(ref _maxLevel, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for hunting
    /// </summary>
    public bool IsHunting
    {
        get => _isHunting;
        set => this.RaiseAndSetIfChanged(ref _isHunting, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for questing
    /// </summary>
    public bool IsQuest
    {
        get => _isQuest;
        set => this.RaiseAndSetIfChanged(ref _isQuest, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for trading
    /// </summary>
    public bool IsTrade
    {
        get => _isTrade;
        set => this.RaiseAndSetIfChanged(ref _isTrade, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for thief activities
    /// </summary>
    public bool IsThief
    {
        get => _isThief;
        set => this.RaiseAndSetIfChanged(ref _isThief, value);
    }

    /// <summary>
    /// Gets or sets whether to automatically reform the party
    /// </summary>
    public bool AutoReform
    {
        get => _autoReform;
        set => this.RaiseAndSetIfChanged(ref _autoReform, value);
    }

    /// <summary>
    /// Gets or sets whether to automatically accept party invitations
    /// </summary>
    public bool AutoAccept
    {
        get => _autoAccept;
        set => this.RaiseAndSetIfChanged(ref _autoAccept, value);
    }

    /// <summary>
    /// Gets whether the character can use trade party type
    /// </summary>
    public bool CanTrade => Game.Player.JobInformation.Type == JobType.Trade || 
                           Game.Player.JobInformation.Type == JobType.Hunter;

    /// <summary>
    /// Gets whether the character can use thief party type
    /// </summary>
    public bool CanThief => Game.Player.JobInformation.Type == JobType.Thief;

    /// <summary>
    /// Command to start party formation
    /// </summary>
    public ReactiveCommand<Unit, Unit> StartCommand { get; }

    /// <summary>
    /// Command to cancel party formation
    /// </summary>
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public AutoFormPartyViewModel(IPartyService partyService, Window window)
    {
        _partyService = partyService;
        _window = window;

        LoadSettings();

        StartCommand = ReactiveCommand.CreateFromTask(StartAsync);
        CancelCommand = ReactiveCommand.Create(Cancel);
    }

    private void LoadSettings()
    {
        Title = PlayerConfig.Get("RSBot.Party.AutoForm.Title", "Looking for party members!");
        MinLevel = PlayerConfig.Get("RSBot.Party.AutoForm.MinLevel", 1);
        MaxLevel = PlayerConfig.Get("RSBot.Party.AutoForm.MaxLevel", 255);
        AutoReform = PlayerConfig.Get("RSBot.Party.AutoForm.AutoReform", false);
        AutoAccept = PlayerConfig.Get("RSBot.Party.AutoForm.AutoAccept", false);

        var purpose = (PartyPurpose)PlayerConfig.Get("RSBot.Party.AutoForm.Purpose", (int)PartyPurpose.Hunting);
        IsHunting = purpose == PartyPurpose.Hunting;
        IsQuest = purpose == PartyPurpose.Quest;
        IsTrade = purpose == PartyPurpose.Trade;
        IsThief = purpose == PartyPurpose.Thief;
    }

    private void SaveSettings()
    {
        PlayerConfig.Set("RSBot.Party.AutoForm.Title", Title);
        PlayerConfig.Set("RSBot.Party.AutoForm.MinLevel", MinLevel);
        PlayerConfig.Set("RSBot.Party.AutoForm.MaxLevel", MaxLevel);
        PlayerConfig.Set("RSBot.Party.AutoForm.AutoReform", AutoReform);
        PlayerConfig.Set("RSBot.Party.AutoForm.AutoAccept", AutoAccept);

        var purpose = PartyPurpose.Hunting;
        if (IsQuest) purpose = PartyPurpose.Quest;
        if (IsTrade) purpose = PartyPurpose.Trade;
        if (IsThief) purpose = PartyPurpose.Thief;

        PlayerConfig.Set("RSBot.Party.AutoForm.Purpose", (int)purpose);
    }

    private async Task StartAsync()
    {
        try
        {
            SaveSettings();

            var purpose = PartyPurpose.Hunting;
            if (IsQuest) purpose = PartyPurpose.Quest;
            if (IsTrade) purpose = PartyPurpose.Trade;
            if (IsThief) purpose = PartyPurpose.Thief;

            await _partyService.CreatePartyAsync(Title, MinLevel, MaxLevel, purpose, AutoReform, AutoAccept);
            Log.Debug("[Party] Auto form party started successfully");
            _window?.Close();
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to start auto form party: {ex.Message}");
        }
    }

    private void Cancel()
    {
        _window?.Close();
    }
} 