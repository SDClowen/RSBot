using System.Collections.Generic;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Bundle.Attribute;

internal class AttributeBundleConfig
{
    internal class AttributeBundleConfigItem
    {
        /// <summary>
        ///     Gets the maximum value.
        /// </summary>
        /// <value>
        ///     The maximum value.
        /// </value>
        public int MaxValue { get; init; }

        /// <summary>
        ///     Gets the stone.
        /// </summary>
        /// <value>
        ///     The stone.
        /// </value>
        public InventoryItem Stone { get; init; }

        /// <summary>
        ///     Gets the group.
        /// </summary>
        /// <value>
        ///     The group.
        /// </value>
        public ItemAttributeGroup Group { get; init; }
    }

    #region Properties

    /// <summary>
    ///     Gets the item that should be fused into.
    /// </summary>
    /// <value>
    ///     The item.
    /// </value>
    public InventoryItem Item { get; init; }

    /// <summary>
    ///     Gets or sets the attributes.
    /// </summary>
    /// <value>
    ///     The attributes.
    /// </value>
    public IEnumerable<AttributeBundleConfigItem> Attributes { get; set; }

    #endregion Properties
}
