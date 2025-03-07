using CommunityToolkit.Mvvm.ComponentModel;
using RSBot.Core;
using RSBot.Core.Objects.Party;

namespace RSBot.Party.Models;

/// <summary>
/// Represents a party member with their properties
/// </summary>
public partial class PartyMemberModel : ObservableObject
{
    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private byte _level;

    [ObservableProperty]
    private string _guild;

    [ObservableProperty]
    private string _location;

    [ObservableProperty]
    private string _mastery1;

    [ObservableProperty]
    private string _mastery2;

    /// <summary>
    /// Initializes a new instance of the PartyMemberModel class
    /// </summary>
    public PartyMemberModel(PartyMember member)
    {
        Update(member);
    }

    /// <summary>
    /// Updates the model with new member data
    /// </summary>
    public void Update(PartyMember member)
    {
        Name = member.Name;
        Level = member.Level;
        Guild = string.IsNullOrWhiteSpace(member.Guild) ? "No Guild" : member.Guild;
        Location = Game.ReferenceManager.GetTranslation(member.Position.Region.ToString());
        
        var mastery1 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId1);
        var mastery2 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId2);

        Mastery1 = mastery1?.Name ?? string.Empty;
        Mastery2 = mastery2?.Name ?? string.Empty;
    }
} 