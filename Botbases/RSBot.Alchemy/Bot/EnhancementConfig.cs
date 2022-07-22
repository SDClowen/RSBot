using RSBot.Core.Objects;

namespace RSBot.Alchemy.Bot
{
    internal class EnhancementConfig
    {
        #region Properties

        /// <summary>
        /// Gets or sets the maximum opt level for the item
        /// </summary>
        public byte MaxOptLevel { get; set; }

        /// <summary>
        /// Gets or sets the inventory item used to do the alchemy on
        /// </summary>
        public InventoryItem Item { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the bot should stop if lucky powder is empty
        /// </summary>
        public bool StopIfLuckyPowderEmpty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if immortal stones should be used
        /// </summary>
        public bool UseImmortalStones { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if astral stones should be used
        /// </summary>
        public bool UseAstralStones { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if steady stones should be used
        /// </summary>
        public bool UseSteadyStones { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if lucky stones should be used
        /// </summary>
        public bool UseLuckyStones { get; set; }

        /// <summary>
        /// Gets or sets the selected enhancer elixir
        /// </summary>
        public InventoryItem Elixir { get; set; }

        #endregion Properties
    }
}