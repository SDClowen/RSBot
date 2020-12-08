using RSBot.Bot.Default.Bot.Objects;
using RSBot.Bot.Default.Bundle;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using System.Threading;

namespace RSBot.Bot.Default.Bot
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
                    XSector = PlayerConfig.Get<byte>("RSBot.Area.XSec"),
                    YSector = PlayerConfig.Get<byte>("RSBot.Area.YSec"),
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
            //Player is exchanging
            if (Game.Player.Exchanging)
                return;

            //Loop back invokation
            if (Bundles.Loop.Running)
                return;

            //We can not fight on a vehicle
            if (Game.Player.HasActiveVehicle)
            {
                Game.Player.Vehicle.Dismount();
                Thread.Sleep(1000);
            }

            //Wait for the pickup manager to finish
            if (PickupManager.Running && !(Bundles.Loot.Config.UseAbilityPet && Game.Player.HasActiveAbilityPet))
                return;

            //Cast buffs
            Bundles.Buff.Invoke();

            //Resurrect party members if needed
            Bundles.Resurrect.Invoke();

            //Check for berzerk
            Bundles.Berzerk.Invoke();

            //Select next target
            Bundles.Target.Invoke();

            //Cast skill against enemy
            Bundles.Attack.Invoke();

            //Loot items
            Bundles.Loot.Invoke();

            //Move around (maybe)
            Bundles.Movement.Invoke();
        }
    }
}