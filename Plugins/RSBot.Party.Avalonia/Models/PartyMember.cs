using ReactiveUI;

namespace RSBot.Party.Models;

/// <summary>
/// Represents a member in the party with their attributes and status
/// </summary>
public class PartyMember : ReactiveObject
{
    private string _name;
    private int _level;
    private string _job;
    private int _hpPercentage;
    private int _mpPercentage;

    /// <summary>
    /// Gets or sets the name of the party member
    /// </summary>
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    /// <summary>
    /// Gets or sets the level of the party member
    /// </summary>
    public int Level
    {
        get => _level;
        set => this.RaiseAndSetIfChanged(ref _level, value);
    }

    /// <summary>
    /// Gets or sets the job/class of the party member
    /// </summary>
    public string Job
    {
        get => _job;
        set => this.RaiseAndSetIfChanged(ref _job, value);
    }

    /// <summary>
    /// Gets or sets the HP percentage of the party member
    /// </summary>
    public int HpPercentage
    {
        get => _hpPercentage;
        set => this.RaiseAndSetIfChanged(ref _hpPercentage, value);
    }

    /// <summary>
    /// Gets or sets the MP percentage of the party member
    /// </summary>
    public int MpPercentage
    {
        get => _mpPercentage;
        set => this.RaiseAndSetIfChanged(ref _mpPercentage, value);
    }
} 