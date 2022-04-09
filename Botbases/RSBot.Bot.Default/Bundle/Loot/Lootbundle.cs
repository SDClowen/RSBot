﻿using RSBot.Core;
using RSBot.Core.Components;
using System.Threading.Tasks;

namespace RSBot.Bot.Default.Bundle.Loot
{
    internal class LootBundle : IBundle
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public LootConfig Config { get; private set; }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            if (Bundles.Loot.Config.DontPickupWhileBotting)
                return;

            //If we use the ability pet, we can attack during the work of the Pickup manager
            if (Config.UseAbilityPet && Game.Player.HasActiveAbilityPet)
                Task.Run(() => PickupManager.Run(Container.Bot.Area.CenterPosition, Container.Bot.Area.Radius));
            else
            {
                if (Bundles.Loot.Config.DontPickupInBerzerk && Game.Player.Berzerking)
                    return;

                PickupManager.Run(Container.Bot.Area.CenterPosition, Container.Bot.Area.Radius);
            }
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            Config = new LootConfig
            {
                UseAbilityPet = PlayerConfig.Get<bool>("RSBot.Items.Pickup.EnableAbilityPet", true),
                DontPickupWhileBotting = PlayerConfig.Get<bool>("RSBot.Items.Pickup.DontPickupWhileBotting", true),
                DontPickupInBerzerk = PlayerConfig.Get<bool>("RSBot.Items.Pickup.DontPickupInBerzerk", true)
            };
        }
    }
}