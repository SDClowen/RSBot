using System;
using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Inventory.Subscriber;

internal class UseItemAtTrainplaceSubscriber
{
    private static readonly List<string> _blacklistedItems = new();
    private static long _lastTick;

    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    private static void OnTick()
    {
        //Retry blacklisted items after 5 minutes
        if (TimeSpan.FromMilliseconds(Kernel.TickCount - _lastTick).Minutes >= 5)
            _blacklistedItems.Clear();

        _lastTick = Kernel.TickCount;

        if (!Kernel.Bot.Running || Kernel.Bot.Botbase.Area.Position.Region == 0)
            return;

        //Only at training place
        if (Kernel.Bot.Botbase.Area.Position.DistanceToPlayer() > 100)
            return;

        var itemsToUse = PlayerConfig.GetArray<string>("RSBot.Inventory.ItemsAtTrainplace");

        foreach (var item in itemsToUse)
        {
            if (_blacklistedItems.Contains(item))
                continue;

            var invItem = Game.Player.Inventory.GetItem(item);
            if (invItem == null)
                continue;

            if (invItem.ItemSkillInUse)
                continue;

            Log.Notify($"Use [{invItem.Record.GetRealName()}] at training place");

            if (invItem.Use())
                continue;

            //e.g. overlapping with another buff
            _blacklistedItems.Add(invItem.Record.CodeName);

            Log.Warn(
                $"Can not use item [{invItem.Record.GetRealName()}] at training place. Blacklisting it for 5 minutes before next try."
            );
        }
    }
}
