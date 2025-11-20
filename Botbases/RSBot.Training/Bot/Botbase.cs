using System;
using System.Threading;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Training.Bundle;

namespace RSBot.Training.Bot;

internal class Botbase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Botbase" /> class.
    /// </summary>
    public Botbase()
    {
        EventManager.SubscribeEvent("OnSetTrainingArea", Reload);
    }

    /// <summary>
    ///     Gets the area.
    /// </summary>
    /// <value>
    ///     The area.
    /// </value>
    public Area Area { get; private set; }

    /// <summary>
    ///     Reloads this instance by re-reading the configuration.
    /// </summary>
    public void Reload()
    {
        Area = new Area
        {
            Position = new Position(
                PlayerConfig.Get<ushort>("RSBot.Area.Region"),
                PlayerConfig.Get<float>("RSBot.Area.X"),
                PlayerConfig.Get<float>("RSBot.Area.Y"),
                PlayerConfig.Get<float>("RSBot.Area.Z")
            ),
            Radius = Math.Clamp(PlayerConfig.Get("RSBot.Area.Radius", 50), 5, 100),
        };
    }

    /// <summary>
    ///     Ticks this instance.
    /// </summary>
    public void Tick()
    {
        if (!Kernel.Bot.Running)
            return;

        if (Game.Player.HasActiveVehicle)
        {
            Game.Player.Vehicle.Dismount();
            Thread.Sleep(1000);
        }

        //Wait for the pickup manager to finish
        if (PickupManager.RunningPlayerPickup)
            return;

        if (
            Bundles.Loop.Config.UseSpeedDrug
            && Game.Player.State.ActiveBuffs.FindIndex(p => p.Record.Params.Contains(1752396901)) < 0
        )
        {
            var item = Game.Player.Inventory.GetItem(
                new TypeIdFilter(3, 3, 13, 1),
                p => p.Record.Desc1.Contains("_SPEED_")
            );
            item?.Use();
        }

        var noAttack = PlayerConfig.Get("RSBot.Skills.checkBoxNoAttack", false);

        //Check for protection
        Bundles.Protection.Invoke();

        //Resurrect party members if needed
        Bundles.Resurrect.Invoke();

        //Cast buffs
        Bundles.Buff.Invoke();

        // Buff the configured party members if needed
        Bundles.PartyBuff.Invoke();

        //Loot items
        Bundles.Loot.Invoke();

        //Select next target
        if (!noAttack)
            Bundles.Target.Invoke();

        //Check for berzerk
        Bundles.Berzerk.Invoke();

        //Cast skill against enemy
        if (!noAttack)
            Bundles.Attack.Invoke();

        //Move around (maybe)
        Bundles.Movement.Invoke();
    }
}
