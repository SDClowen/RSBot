using System.Text;

namespace RSBot.Core.Objects.Party;

public class PartySettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PartySettings" /> class.
    /// </summary>
    /// <param name="experienceAutoShare">if set to <c>true</c> [experience automatic share].</param>
    /// <param name="itemsAutoShare">if set to <c>true</c> [items automatic share].</param>
    /// <param name="allowInvitation">if set to <c>true</c> [allow invitation].</param>
    public PartySettings(bool experienceAutoShare, bool itemsAutoShare, bool allowInvitation)
    {
        ExperienceAutoShare = experienceAutoShare;
        ItemAutoShare = itemsAutoShare;
        AllowInvitation = allowInvitation;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PartySettings" /> class.
    /// </summary>
    public PartySettings() { }

    /// <summary>
    ///     Gets or sets a value indicating whether [allow invitation].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [allow invitation]; otherwise, <c>false</c>.
    /// </value>
    public bool AllowInvitation { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [experience automatic share].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [experience automatic share]; otherwise, <c>false</c>.
    /// </value>
    public bool ExperienceAutoShare { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [item automatic share].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [item automatic share]; otherwise, <c>false</c>.
    /// </value>
    public bool ItemAutoShare { get; set; }

    /// <summary>
    ///     Get max member count
    /// </summary>
    public int MaxMember
    {
        get
        {
            var partyType = GetPartyType();
            return partyType == 4 || partyType == 0 ? 4 : 8;
        }
    }

    /// <summary>
    ///     Creates a new party setting from a specific type
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    public static PartySettings FromType(byte type)
    {
        switch (type)
        {
            case 0:
                return new PartySettings();

            case 1:
                return new PartySettings { ExperienceAutoShare = true };

            case 2:
                return new PartySettings { ItemAutoShare = true };

            case 3:
                return new PartySettings { ItemAutoShare = true, ExperienceAutoShare = true };

            case 4:
                return new PartySettings { AllowInvitation = true };

            case 5:
                return new PartySettings { ExperienceAutoShare = true, AllowInvitation = true };

            case 6:
                return new PartySettings { ItemAutoShare = true, AllowInvitation = true };

            case 7:
                return new PartySettings
                {
                    ItemAutoShare = true,
                    ExperienceAutoShare = true,
                    AllowInvitation = true,
                };
        }

        return new PartySettings();
    }

    /// <summary>
    ///     Gets the type of the party.
    /// </summary>
    /// <returns></returns>
    public byte GetPartyType()
    {
        if (!ExperienceAutoShare && !ItemAutoShare && !AllowInvitation)
            return 0;
        if (ExperienceAutoShare && !ItemAutoShare && !AllowInvitation)
            return 1;
        if (!ExperienceAutoShare && ItemAutoShare && !AllowInvitation)
            return 2;
        if (ExperienceAutoShare && ItemAutoShare && !AllowInvitation)
            return 3;
        if (!ExperienceAutoShare && !ItemAutoShare && AllowInvitation)
            return 4;
        if (ExperienceAutoShare && !ItemAutoShare && AllowInvitation)
            return 5;
        if (!ExperienceAutoShare && ItemAutoShare && AllowInvitation)
            return 6;
        if (ExperienceAutoShare && ItemAutoShare && AllowInvitation)
            return 7;

        return 0;
    }

    public override string ToString()
    {
        var str = new StringBuilder();
        if (ExperienceAutoShare)
            str.AppendLine("Exp Auto Share");
        else
            str.AppendLine("Exp Free-For-All");

        if (ItemAutoShare)
            str.AppendLine("Item Auto Share");
        else
            str.AppendLine("Item Free-For-All");

        return str.ToString();
    }
}
