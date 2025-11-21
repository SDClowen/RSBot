using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Town;

public class DurabilityLowHandler : AbstractTownHandler
{
    /// <summary>
    ///     The last tick count
    /// </summary>
    private static long _lastTick = Kernel.TickCount;

    /// <summary>
    /// Indicates whether the system is currently busy processing an operation.
    /// </summary>
    /// <remarks>This field is intended for internal use to track the busy state of the system. It should not
    /// be accessed directly outside of the class.</remarks>
    private static bool _isBusy = false;

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateItemDurability", new Action<byte, uint>(OnUpdateItemDurability));
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    /// <summary>
    ///     Check the equiped items durabilities
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

        if (_isBusy)
            return;

        _isBusy = true;

        _lastTick = Kernel.TickCount;

        for (byte slot = 0; slot < 8; slot++)
        {
            var item = Game.Player.Inventory.GetItemAt(slot);
            if (item == null || !item.Record.IsEquip || item.Durability > 6)
                continue;

            var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.AutoUseAccordingToPurpose");
            var inventoryItem = Game.Player.Inventory.GetItem(
                new TypeIdFilter(3, 3, 13, 7),
                p => itemsToUse.Contains(p.Record.CodeName)
            );
            if (inventoryItem != null)
            {
                inventoryItem.Use();
                return;
            }

            if (Game.Player.UseReturnScroll())
                Log.WarnLang("ReturnToTownDurLow", item.Record.GetRealName());

            break;
        }

        _isBusy = false;
    }

    /// <summary>
    ///     Cores the on update item.
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
