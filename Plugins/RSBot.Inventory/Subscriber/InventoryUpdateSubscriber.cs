using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Inventory.Subscriber;

internal static class InventoryUpdateSubscriber
{
    private static object _lock;

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    public static void SubscribeEvents()
    {
        _lock = new object();
        EventManager.SubscribeEvent("OnInventoryUpdate", OnInventoryUpdate);
    }

    private static void OnInventoryUpdate()
    {
        var autoSort = PlayerConfig.Get("RSBot.Inventory.AutoSort", false);
        if (!autoSort)
            return;

        lock (_lock)
        {
            Game.Player.Inventory.Sort();
        }
    }
}
