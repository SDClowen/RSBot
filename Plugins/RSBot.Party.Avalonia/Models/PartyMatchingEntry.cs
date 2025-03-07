using ReactiveUI;

namespace RSBot.Party.Models;

/// <summary>
/// Represents an entry in the party matching list with party details
/// </summary>
public class PartyMatchingEntry : ReactiveObject
{
    private string _leader;
    private string _purpose;
    private string _levelRange;
    private int _memberCount;

    /// <summary>
    /// Gets or sets the name of the party leader
    /// </summary>
    public string Leader
    {
        get => _leader;
        set => this.RaiseAndSetIfChanged(ref _leader, value);
    }

    /// <summary>
    /// Gets or sets the purpose of the party (e.g., Hunting, Quest, Trade)
    /// </summary>
    public string Purpose
    {
        get => _purpose;
        set => this.RaiseAndSetIfChanged(ref _purpose, value);
    }

    /// <summary>
    /// Gets or sets the level range requirement for the party
    /// </summary>
    public string LevelRange
    {
        get => _levelRange;
        set => this.RaiseAndSetIfChanged(ref _levelRange, value);
    }

    /// <summary>
    /// Gets or sets the current number of members in the party
    /// </summary>
    public int MemberCount
    {
        get => _memberCount;
        set => this.RaiseAndSetIfChanged(ref _memberCount, value);
    }
} 