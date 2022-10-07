﻿using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RSBot.Core.Components
{
    public class PickupManager
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PickupManager"/> is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public static bool RunningPlayerPickup { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PickupManager"/> is running for AbilityPet.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public static bool RunningAbilityPetPickup { get; private set; }

        /// <summary>
        /// Gets or sets the pickup items.
        /// </summary>
        /// <value>
        /// The pickup items.
        /// </value>
        public static List<(string CodeName, bool PickOnlyChar)> PickupFilter { get; } = new();

        /// <summary>
        /// Gets or sets a value indicating whether [pickup gold].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup gold]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupGold => PlayerConfig.Get<bool>("RSBot.Items.Pickup.Gold", true);

        /// <summary>
        /// Gets or sets a value indicating whether [pickup rare items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup rare items]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupRareItems => PlayerConfig.Get<bool>("RSBot.Items.Pickup.Rare", true);

        /// <summary>
        /// Gets or sets a value indicating whether [pickup rare items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup rare items]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupBlueItems => PlayerConfig.Get<bool>("RSBot.Items.Pickup.Blue", true);

        /// <summary>
        /// Gets or sets a value indicating whether [use ability pet].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use ability pet]; otherwise, <c>false</c>.
        /// </value>
        public static bool UseAbilityPet => PlayerConfig.Get<bool>("RSBot.Items.Pickup.EnableAbilityPet", true);

        /// <summary>
        /// Gets or sets a value indicating whether [just pick my items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use ability pet]; otherwise, <c>false</c>.
        /// </value>
        public static bool JustPickMyItems => PlayerConfig.Get<bool>("RSBot.Items.Pickup.JustPickMyItems", false);

        /// <summary>
        /// Runs the specified center position.
        /// </summary>
        /// <param name="playerPosition">The player position.</param>
        /// <param name="centerPosition">The center position.</param>
        /// <param name="radius">The radius.</param>
        public static void RunPlayer(Position playerPosition, Position centerPosition, int radius = 50)
        {
            // if the manager is busy,return
            if (RunningPlayerPickup)
                return;

            RunningPlayerPickup = true;
            try
            {
                if (!SpawnManager.TryGetEntities<SpawnedItem>(out var entities, (si) => Condition(si, centerPosition, radius)
                    && (!UseAbilityPet || !Game.Player.HasActiveAbilityPet || !si.Record.IsGold || PickupFilter.Any(p => p.CodeName == si.Record.CodeName && p.PickOnlyChar))))
                {
                    StopPlayerPickup();
                    return;
                }

                EventManager.FireEvent("OnChangeStatusText", "Picking up");
                foreach (var item in entities.OrderBy(item => item.Movement.Source.DistanceTo(playerPosition)/*.Take(5)*/))
                {
                    if (!RunningPlayerPickup)
                        return;

                    while (Game.Player.InAction)
                        Thread.Sleep(50);

                    //Make sure the player is at the item's location
                    //Game.Player.MoveTo(item.Movement.Source);
                    item.Pickup();
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e);
            }
            finally
            {
                StopPlayerPickup();
            }
        }

        public static void RunAbilityPet(Position centerPosition, int radius = 50)
        {
            if (RunningAbilityPetPickup || !UseAbilityPet || !Game.Player.HasActiveAbilityPet)
                return;

            RunningAbilityPetPickup = true;
            
            try
            {
                if (!SpawnManager.TryGetEntities<SpawnedItem>(out var entities, (si) => Condition(si, centerPosition, radius)
                    && (si.Record.IsGold || PickupFilter.Any(p => p.CodeName == si.Record.CodeName && !p.PickOnlyChar))))
                {
                    StopAbilityPetPickup();
                    return;
                }

                foreach (var item in entities.OrderBy(item => item.Movement.Source.DistanceTo(centerPosition)/*.Take(5)*/))
                {
                    if (!RunningAbilityPetPickup)
                        return;

                    Game.Player.AbilityPet.Pickup(item.UniqueId);
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e);
            }
            finally
            {
                StopAbilityPetPickup();
            }
        }

        private static bool Condition(SpawnedItem e, Position centerPosition, int radius)
        {
            var playerJid = Game.Player.JID;

            if (JustPickMyItems && e.OwnerJID != playerJid)
                return false;

            // Don't pickup items that still belong to another player
            if (e.HasOwner && e.OwnerJID != playerJid)
                return false;

            // Check if Item is within the training area + tolerance
            const int tolerance = 15;
            var isInside = e.Movement.Source.DistanceTo(centerPosition) <= radius + tolerance;
            if (!isInside)
                return false;

            if (PickupGold && e.Record.IsGold)
                return true;

            if (PickupFilter.Any(p => p.CodeName == e.Record.CodeName))
                return true;

            if (PickupRareItems && (byte)e.Rarity >= 2)
                return true;

            if (PickupBlueItems && (byte)e.Rarity >= 1)
                return true;

            return false;
        }

        public static void AddFilter(string codeName, bool pickOnlyChar = false)
        {
            PickupFilter.RemoveAll(p => p.CodeName == codeName);
            PickupFilter.Add((codeName, pickOnlyChar));

            SaveFilter();
        }

        public static void RemoveFilter(string codeName)
        {
            PickupFilter.RemoveAll(p => p.CodeName == codeName);
            SaveFilter();
        }

        public static void LoadFilter()
        {
            var config = PlayerConfig.GetArray<string>("RSBot.Shopping.Pickup");

            foreach (var item in config)
            {
                var split = item.Split('|');
                if (split.Length < 2)
                    continue;

                PickupFilter.Add((split[0], Convert.ToBoolean(split[1])));
            }
        }

        public static void SaveFilter()
        {
            var array = PickupFilter.Select(p => $"{p.CodeName}|{p.PickOnlyChar}").ToArray();
            if (array.Length == 0)
                return;

            PlayerConfig.SetArray("RSBot.Shopping.Pickup", array);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public static void StopPlayerPickup()
        {
            RunningPlayerPickup = false;
        }

        /// <summary>
        /// Stops this instance AbilityPet.
        /// </summary>
        public static void StopAbilityPetPickup()
        {
            RunningAbilityPetPickup = false;
        }
    }
}