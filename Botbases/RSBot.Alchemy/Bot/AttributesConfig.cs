using RSBot.Core.Objects;
using RSBot.Core.Objects.Inventory.Item;
using System.Collections.Generic;

namespace RSBot.Alchemy.Bot
{
    internal class AttributesConfig
    {
        internal class AttributesConfigItem
        {
            public int MaxValue { get; init; }
            public InventoryItem Stone { get; init; }
            public AttributesGroup Group { get; init; }
        }

        #region Properties

        public InventoryItem Item { get; init; }

        public IEnumerable<AttributesConfigItem> Attributes { get; set; }

        #endregion Properties
    }
}