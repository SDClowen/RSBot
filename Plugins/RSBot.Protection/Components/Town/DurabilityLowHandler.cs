using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Linq;

namespace RSBot.Protection.Components.Town;

public class DurabilityLowHandler : AbstractTownHandler
{
    /// <summary>
    /// The last tick count
    /// </summary>
    private static long _lastTick = Kernel.TickCount;

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        SubscribeEvents();
    }

    /// <summary>
    /// Subscribes the events.
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateItemDurability", new System.Action<byte, uint>(OnUpdateItemDurability));
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    /// <summary>
    /// Check the equiped items durabilities
    /// </summary>
    /// <param name="slot">The slot.</param>
    /// <param name="durability">The durability.</param>
    private static void OnTick()
    {
        if (!Kernel.Bot.Running)
            return;
            
        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkDurability"))
            return;

        if (Kernel.TickCount - _lastTick < 10000)
            return;

        if (PlayerInTownScriptRegion())
            return;

        _lastTick = Kernel.TickCount;

        for (byte slot = 0; slot < 8; slot++)
        {
            var item = Game.Player.Inventory.GetItemAt(slot);
            if (item == null)
                return;

            if (!item.Record.IsEquip)
                continue;
                
            if (item.Durability > 6)
                continue;

            var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose");
            var inventoryItem = Game.Player.Inventory.GetItem(new TypeIdFilter(3, 3, 13, 7), p => itemsToUse.Contains(p.Record.CodeName));
            if (inventoryItem != null)
            {
                inventoryItem.Use();
                return;
            }

            if (Game.Player.UseReturnScroll())
                Log.WarnLang("ReturnToTownDurLow", item.Record.GetRealName());
                
            break;
        }
    }

    /// <summary>
    /// Cores the on update item.
    /// </summary>
    /// <param name="slot">The slot.</param>
    /// <param name="durability">The durability.</param>
    private static void OnUpdateItemDurability(byte slot, uint durability)
    {
        var item = Game.Player.Inventory.GetItemAt(slot);
        if (item == null)
            return;

        item.Durability = durability;
    }
}