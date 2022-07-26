using RSBot.Default.Bot.Objects;
using RSBot.Default.Bundle;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using System.Threading;

namespace RSBot.Default.Bot
{
    internal class Botbase
    {
        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public TrainingArea Area { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Botbase" /> class.
        /// </summary>
        public Botbase()
        {
            Reload();
        }

        /// <summary>
        /// Reloads this instance by re-reading the configuration.
        /// </summary>
        public void Reload()
        {
            Area = new TrainingArea
            {
                CenterPosition = new Position
                {
                    XCoordinate = PlayerConfig.Get<float>("RSBot.Area.X"),
                    YCoordinate = PlayerConfig.Get<float>("RSBot.Area.Y")
                },
                Radius = PlayerConfig.Get<int>("RSBot.Area.Radius", 50)
            };
        }

        /// <summary>
        /// Ticks this instance.
        /// </summary>
        public void Tick()
        {
            if (Game.Player.HasActiveVehicle)
            {
                Game.Player.Vehicle.Dismount();
                Thread.Sleep(1000);
            }

            //Wait for the pickup manager to finish
            if (PickupManager.Running && !(Bundles.Loot.Config.UseAbilityPet && Game.Player.HasActiveAbilityPet))
                return;

            if (Bundles.Loop.Config.UseSpeedDrug && Game.Player.State.ActiveBuffs.FindIndex(p => p.Record.Params.Contains(1752396901)) < 0)
            {
                var item = Game.Player.Inventory.GetItem(new TypeIdFilter(3, 3, 13, 1), p => p.Record.Desc1.Contains("_SPEED_"));
                item?.Use();
            }

            var noAttack = PlayerConfig.Get("RSBot.Skills.NoAttack", false);

            //Cast buffs
            Bundles.Buff.Invoke();

            // Buff the configured party members if needed
            Bundles.PartyBuff.Invoke();

            //Resurrect party members if needed
            Bundles.Resurrect.Invoke();

            //Loot items
            Bundles.Loot.Invoke();

            //Select next target
            if(!noAttack)
                Bundles.Target.Invoke();

            //Check for berzerk
            Bundles.Berzerk.Invoke();

            //Cast skill against enemy
            if(!noAttack)
                Bundles.Attack.Invoke();

            //Move around (maybe)
            Bundles.Movement.Invoke();
        }
    }
}