using CommunityToolkit.Mvvm.ComponentModel;
using RSBot.Core.Objects.Party;

namespace RSBot.Party.Models;

/// <summary>
/// Represents a party match entry in the party matching list
/// </summary>
public partial class PartyMatchModel : ObservableObject
{
    [ObservableProperty]
    private uint _id;

    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private string _purpose;

    [ObservableProperty]
    private string _members;

    [ObservableProperty]
    private string _levelRange;

    /// <summary>
    /// Initializes a new instance of the PartyMatchModel class
    /// </summary>
    public PartyMatchModel(PartyMatchEntry entry)
    {
        Update(entry);
    }

    /// <summary>
    /// Updates the model with new entry data
    /// </summary>
    public void Update(PartyMatchEntry entry)
    {
        Id = entry.Id;
        Title = entry.Title;
        Purpose = entry.Purpose.ToString();
        Members = $"{entry.Members}/{entry.MaxMembers}";
        LevelRange = $"{entry.LevelFrom}~{entry.LevelTo}";
    }
} 