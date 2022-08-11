using RSBot.Core.Objects;
using System.Collections.Generic;

namespace RSBot.Alchemy.Bot
{
    internal class AttributesEngineConfig
    {
        internal class AttributesEngineConfigItem
        {
            /// <summary>
            /// Gets the maximum value.
            /// </summary>
            /// <value>
            /// The maximum value.
            /// </value>
            public int MaxValue { get; init; }

            /// <summary>
            /// Gets the stone.
            /// </summary>
            /// <value>
            /// The stone.
            /// </value>
            public InventoryItem Stone { get; init; }

            /// <summary>
            /// Gets the group.
            /// </summary>
            /// <value>
            /// The group.
            /// </value>
            public ItemAttributeGroup Group { get; init; }
        }

        #region Properties

        /// <summary>
        /// Gets the item that should be fused into.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public InventoryItem Item { get; init; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public IEnumerable<AttributesEngineConfigItem> Attributes { get; set; }

        #endregion Properties
    }
}