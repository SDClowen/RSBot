﻿using System;
using System.Collections.Generic;
using RSBot.Core.Event;
using RSBot.Core;

namespace RSBot.Inventory.Subscriber;

internal class UseItemAtTrainplaceSubscriber
{
    private static List<string> _blacklistedItems = new();
    private static long _lastTick;

    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTick", OnTick);
    }

    private static void OnTick()
    {
        //Retry blacklisted items after 5 minutes
        if (TimeSpan.FromTicks(DateTime.Now.Ticks - _lastTick).Minutes >= 5)
            _blacklistedItems.Clear();
        
        _lastTick = DateTime.Now.Ticks;

        if (!Kernel.Bot.Running || Kernel.Bot.CenterPosition.RegionId == 0)
            return;

        if (Kernel.Bot.CenterPosition.DistanceToPlayer() > 100)
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

            if (!invItem.Use())
            {
                //e.g. overlapping with another buff
                Log.Warn($"Can not use item [{invItem.Record.GetRealName()}] at training place. Blacklisting it for 5 minutes before next try.");

                _blacklistedItems.Add(invItem.Record.CodeName);
            }
        }
    }
}
