using ReactiveUI;

namespace RSBot.Party.Models;

/// <summary>
/// Represents the settings and configuration for party management
/// </summary>
public class PartySettings : ReactiveObject
{
    private bool _allowInvitations;
    private bool _autoShareExperience;
    private bool _autoShareItems;
    private bool _autoShareGold;
    private bool _autoReform;
    private bool _autoAccept;
    private int _minLevel;
    private int _maxLevel;
    private bool _isHunting;
    private bool _isQuest;
    private bool _isTrade;
    private bool _isThief;

    /// <summary>
    /// Gets or sets whether party invitations are allowed
    /// </summary>
    public bool AllowInvitations
    {
        get => _allowInvitations;
        set => this.RaiseAndSetIfChanged(ref _allowInvitations, value);
    }

    /// <summary>
    /// Gets or sets whether experience is automatically shared
    /// </summary>
    public bool AutoShareExperience
    {
        get => _autoShareExperience;
        set => this.RaiseAndSetIfChanged(ref _autoShareExperience, value);
    }

    /// <summary>
    /// Gets or sets whether items are automatically shared
    /// </summary>
    public bool AutoShareItems
    {
        get => _autoShareItems;
        set => this.RaiseAndSetIfChanged(ref _autoShareItems, value);
    }

    /// <summary>
    /// Gets or sets whether gold is automatically shared
    /// </summary>
    public bool AutoShareGold
    {
        get => _autoShareGold;
        set => this.RaiseAndSetIfChanged(ref _autoShareGold, value);
    }

    /// <summary>
    /// Gets or sets whether the party should automatically reform
    /// </summary>
    public bool AutoReform
    {
        get => _autoReform;
        set => this.RaiseAndSetIfChanged(ref _autoReform, value);
    }

    /// <summary>
    /// Gets or sets whether party invitations are automatically accepted
    /// </summary>
    public bool AutoAccept
    {
        get => _autoAccept;
        set => this.RaiseAndSetIfChanged(ref _autoAccept, value);
    }

    /// <summary>
    /// Gets or sets the minimum level requirement for party members
    /// </summary>
    public int MinLevel
    {
        get => _minLevel;
        set => this.RaiseAndSetIfChanged(ref _minLevel, value);
    }

    /// <summary>
    /// Gets or sets the maximum level requirement for party members
    /// </summary>
    public int MaxLevel
    {
        get => _maxLevel;
        set => this.RaiseAndSetIfChanged(ref _maxLevel, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for hunting purposes
    /// </summary>
    public bool IsHunting
    {
        get => _isHunting;
        set => this.RaiseAndSetIfChanged(ref _isHunting, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for quest purposes
    /// </summary>
    public bool IsQuest
    {
        get => _isQuest;
        set => this.RaiseAndSetIfChanged(ref _isQuest, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for trading purposes
    /// </summary>
    public bool IsTrade
    {
        get => _isTrade;
        set => this.RaiseAndSetIfChanged(ref _isTrade, value);
    }

    /// <summary>
    /// Gets or sets whether the party is for thief purposes
    /// </summary>
    public bool IsThief
    {
        get => _isThief;
        set => this.RaiseAndSetIfChanged(ref _isThief, value);
    }
} 