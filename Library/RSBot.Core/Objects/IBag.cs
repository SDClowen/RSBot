using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Objects
{
    /// <summary>
    /// Bag interface.
    /// </summary>
    public interface IBag
    {
        List<InventoryItem> Items { get; set; }
        InventoryItem GetItemAt(byte slot);
        void RemoveItemAt(byte slot);
    }

    /// <summary>
    /// Bag Type enum.
    /// </summary>
    public enum BagType
    {
        Inventory,
        Storage,
        GuildStorage,
        Pet,
    }
}
