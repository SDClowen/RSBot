using RSBot.Core.Event;
using RSBot.Core;

namespace RSBot.Inventory.Subscriber;

internal class UseItemAtTrainplaceSubscriber
{
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    private static void OnTick()
    {
        if (!Kernel.Bot.Running || Kernel.Bot.CenterPosition.RegionId == 0)
            return;

        if (Kernel.Bot.CenterPosition.DistanceToPlayer() > 100)
            return;

        var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace");

        foreach (var item in itemsToUse)
        {
            var invItem = Game.Player.Inventory.GetItem(item);
            if (invItem == null)
                continue;

            if (invItem.ItemSkillInUse)
                continue;

            Log.Notify($"Use [{invItem.Record.GetRealName()}] at training place");
            invItem.Use();
        }
    }
}
