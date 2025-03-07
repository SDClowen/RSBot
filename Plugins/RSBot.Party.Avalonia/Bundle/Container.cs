using RSBot.Party.Bundle.AutoParty;
using RSBot.Party.Bundle.Commands;
using RSBot.Party.Bundle.PartyMatching;

namespace RSBot.Party.Bundle;

/// <summary>
/// Container for managing party-related bundles and services
/// </summary>
internal static class Container
{
    /// <summary>
    /// Gets or sets the automatic party bundle
    /// </summary>
    public static AutoPartyBundle AutoParty { get; set; }

    /// <summary>
    /// Gets or sets the party matching bundle
    /// </summary>
    public static PartyMatchingBundle PartyMatching { get; set; }

    /// <summary>
    /// Gets or sets the commands bundle
    /// </summary>
    public static CommandsBundle Commands { get; set; }

    /// <summary>
    /// Refreshes all bundles
    /// </summary>
    public static void Refresh()
    {
        AutoParty ??= new AutoPartyBundle();
        PartyMatching ??= new PartyMatchingBundle();
        Commands ??= new CommandsBundle();

        AutoParty.Refresh();
        Commands.Refresh();
    }
} 