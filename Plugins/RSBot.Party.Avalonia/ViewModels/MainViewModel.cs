using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using RSBot.Party.Models;
using RSBot.Party.Services;
using RSBot.Party.Views;
using System.Linq;
using System.Reactive.Linq;

namespace RSBot.Party.ViewModels;

/// <summary>
/// Main view model for the Party plugin that manages party members and settings
/// </summary>
public class MainViewModel : ReactiveObject
{
    private readonly IPartyService _partyService;
    private PartySettings _settings;
    private ObservableCollection<PartyMember> _partyMembers;
    private ObservableCollection<PartyMatchingEntry> _matchingList;
    private bool _allowInvitations;
    private bool _autoShareExperience;
    private bool _autoShareItems;
    private bool _autoShareGold;

    /// <summary>
    /// Gets or sets whether party invitations are allowed
    /// </summary>
    public bool AllowInvitations
    {
        get => _allowInvitations;
        set
        {
            this.RaiseAndSetIfChanged(ref _allowInvitations, value);
            SaveSettings();
        }
    }

    /// <summary>
    /// Gets or sets whether experience is automatically shared
    /// </summary>
    public bool AutoShareExperience
    {
        get => _autoShareExperience;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoShareExperience, value);
            SaveSettings();
        }
    }

    /// <summary>
    /// Gets or sets whether items are automatically shared
    /// </summary>
    public bool AutoShareItems
    {
        get => _autoShareItems;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoShareItems, value);
            SaveSettings();
        }
    }

    /// <summary>
    /// Gets or sets whether gold is automatically shared
    /// </summary>
    public bool AutoShareGold
    {
        get => _autoShareGold;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoShareGold, value);
            SaveSettings();
        }
    }

    /// <summary>
    /// Gets or sets the party settings
    /// </summary>
    public PartySettings Settings
    {
        get => _settings;
        set => this.RaiseAndSetIfChanged(ref _settings, value);
    }

    /// <summary>
    /// Gets or sets the collection of party members
    /// </summary>
    public ObservableCollection<PartyMember> PartyMembers
    {
        get => _partyMembers;
        set => this.RaiseAndSetIfChanged(ref _partyMembers, value);
    }

    /// <summary>
    /// Gets or sets the collection of party matching entries
    /// </summary>
    public ObservableCollection<PartyMatchingEntry> MatchingList
    {
        get => _matchingList;
        set => this.RaiseAndSetIfChanged(ref _matchingList, value);
    }

    /// <summary>
    /// Command to leave the current party
    /// </summary>
    public ReactiveCommand<Unit, Unit> LeavePartyCommand { get; }

    /// <summary>
    /// Command to join a party
    /// </summary>
    public ReactiveCommand<Unit, Unit> JoinPartyCommand { get; }

    public MainViewModel(IPartyService partyService)
    {
        _partyService = partyService;
        _settings = new PartySettings();
        _partyMembers = new ObservableCollection<PartyMember>();
        _matchingList = new ObservableCollection<PartyMatchingEntry>();

        LeavePartyCommand = ReactiveCommand.CreateFromTask(LeavePartyAsync);
        JoinPartyCommand = ReactiveCommand.Create(ShowAutoFormPartyDialog);

        // Subscribe to party events
        EventManager.SubscribeEvent("OnPartyMemberJoined", OnPartyMemberJoined);
        EventManager.SubscribeEvent("OnPartyMemberLeft", OnPartyMemberLeft);
        EventManager.SubscribeEvent("OnPartyMemberKicked", OnPartyMemberKicked);
        EventManager.SubscribeEvent("OnPartyDismissed", OnPartyDismissed);
        EventManager.SubscribeEvent("OnPartyMatchingListReceived", OnPartyMatchingListReceived);

        // Load initial settings and data
        LoadSettings();
        LoadPartyMembers();
        RefreshPartyList();
    }

    private void LoadSettings()
    {
        AllowInvitations = PlayerConfig.Get("RSBot.Party.AllowInvitations", true);
        AutoShareExperience = PlayerConfig.Get("RSBot.Party.AutoShareExperience", true);
        AutoShareItems = PlayerConfig.Get("RSBot.Party.AutoShareItems", true);
        AutoShareGold = PlayerConfig.Get("RSBot.Party.AutoShareGold", true);

        Game.Party.Settings.AllowInvitations = AllowInvitations;
        Game.Party.Settings.ExperienceAutoShare = AutoShareExperience;
        Game.Party.Settings.ItemAutoShare = AutoShareItems;
        Game.Party.Settings.GoldAutoShare = AutoShareGold;
    }

    private void SaveSettings()
    {
        PlayerConfig.Set("RSBot.Party.AllowInvitations", AllowInvitations);
        PlayerConfig.Set("RSBot.Party.AutoShareExperience", AutoShareExperience);
        PlayerConfig.Set("RSBot.Party.AutoShareItems", AutoShareItems);
        PlayerConfig.Set("RSBot.Party.AutoShareGold", AutoShareGold);

        Game.Party.Settings.AllowInvitations = AllowInvitations;
        Game.Party.Settings.ExperienceAutoShare = AutoShareExperience;
        Game.Party.Settings.ItemAutoShare = AutoShareItems;
        Game.Party.Settings.GoldAutoShare = AutoShareGold;
    }

    private async Task LeavePartyAsync()
    {
        try
        {
            await _partyService.LeavePartyAsync();
            Log.Debug("[Party] Left party successfully");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to leave party: {ex.Message}");
        }
    }

    private void ShowAutoFormPartyDialog()
    {
        var dialog = new Views.AutoFormPartyView();
        dialog.Show();
    }

    private void LoadPartyMembers()
    {
        PartyMembers.Clear();
        foreach (var member in _partyService.GetPartyMembers())
        {
            PartyMembers.Add(new PartyMember
            {
                Name = member.Name,
                Level = member.Level,
                Job = member.Job.ToString(),
                HpPercentage = member.HpPercentage,
                MpPercentage = member.MpPercentage
            });
        }
    }

    private void RefreshPartyList()
    {
        try
        {
            _partyService.RequestPartyList();
            Log.Debug("[Party] Party list refresh requested");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to refresh party list: {ex.Message}");
        }
    }

    private void OnPartyMemberJoined(object[] args)
    {
        LoadPartyMembers();
    }

    private void OnPartyMemberLeft(object[] args)
    {
        LoadPartyMembers();
    }

    private void OnPartyMemberKicked(object[] args)
    {
        LoadPartyMembers();
    }

    private void OnPartyDismissed(object[] args)
    {
        PartyMembers.Clear();
    }

    private void OnPartyMatchingListReceived(object[] args)
    {
        try
        {
            MatchingList.Clear();
            var entries = Bundle.Container.PartyMatching.Entries;

            foreach (var entry in entries)
            {
                MatchingList.Add(new PartyMatchingEntry
                {
                    Leader = entry.Leader,
                    Purpose = entry.Purpose.ToString(),
                    LevelRange = $"{entry.LevelFrom}~{entry.LevelTo}",
                    MemberCount = entry.Members
                });
            }

            Log.Debug($"[Party] Received {entries.Count} party matching entries");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to process party matching list: {ex.Message}");
        }
    }
} 