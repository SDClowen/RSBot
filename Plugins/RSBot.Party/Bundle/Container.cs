using RSBot.Party.Bundle.AutoParty;
using RSBot.Party.Bundle.Commands;
using RSBot.Party.Bundle.PartyMatching;

namespace RSBot.Party.Bundle
{
    internal static class Container
    {
        /// <summary>
        /// Gets or sets the automatic party.
        /// </summary>
        /// <value>
        /// The automatic party.
        /// </value>
        public static AutoPartyBundle AutoParty { get; set; }

        /// <summary>
        /// Gets or sets the party matching.
        /// </summary>
        /// <value>
        /// The party matching.
        /// </value>
        public static PartyMatchingBundle PartyMatching { get; set; }

        /// <summary>
        /// Gets or sets the party matching.
        /// </summary>
        /// <value>
        /// The party matching.
        /// </value>
        public static CommandsBundle Commands { get; set; }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public static void Refresh()
        {
            AutoParty ??= new();
            PartyMatching ??= new();
            Commands ??= new();

            AutoParty.Refresh();
            Commands.Refresh();
        }
    }
}