using System.Collections.Generic;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Bundle.Magic;

internal class MagicBundleConfig
{
    #region Properties

    /// <summary>
    ///     Gets or sets the selected item
    /// </summary>
    public InventoryItem Item { get; set; }

    /// <summary>
    ///     Gets or sets a dictionary of inventory items and the referenced magic option
    /// </summary>
    public Dictionary<InventoryItem, RefMagicOpt> MagicStones { get; set; }

    #endregion Properties
}
