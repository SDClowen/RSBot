using System;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet;

public class CosReviveHandler
{
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
        EventManager.SubscribeEvent("OnUpdateInventoryItem", new Action<byte>(OnItemUpdate));
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
    }

    /// <summary>
    /// </summary>
    /// <param name="slot">The slot.</param>
    private static void OnItemUpdate(byte slot)
    {
        if (!Kernel.Bot.Running)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkReviveAttackPet"))
            return;

        var item = Game.Player.Inventory.GetItemAt(slot);
        if (item == null)
            return;

        var itemRecord = item.Record;

        if (!itemRecord.IsPet)
            return;

        if (item.State != InventoryItemState.Dead)
            return;

        System.Threading.Thread.Sleep(5000);

        if (itemRecord.IsGrowthPet)
            Game.Player.ReviveGrowth();

        if (item.Record.IsFellowPet)
            Game.Player.ReviveFellow();
    }

    /// <summary>
    /// </summary>
    private static void OnStartBot()
    {
        if (!Kernel.Bot.Running)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkReviveAttackPet"))
            return;

        if (Game.Player.ReviveFellow())
            return;

        Game.Player.ReviveGrowth();
    }
}
