using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        /// Gets or sets a value indicating whether [pickup quest items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup quest items]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupQuestItems => PlayerConfig.Get<bool>("RSBot.Items.Pickup.Quest", true);

        /// <summary>
        /// Gets or sets a value indicating whether [pickup clean equips].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup clean equips]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupAnyEquips => PlayerConfig.Get<bool>("RSBot.Items.Pickup.AnyEquips", true);

        /// <summary>
        /// Gets or sets a value indicating whether [pickup everything].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [pickup everything]; otherwise, <c>false</c>.
        /// </value>
        public static bool PickupEverything => PlayerConfig.Get<bool>("RSBot.Items.Pickup.Everything", true);

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
            if (RunningPlayerPickup)
                return;

            RunningPlayerPickup = true;
            try
            {
                var flag = UseAbilityPet && Game.Player.HasActiveAbilityPet;
                if (!SpawnManager.TryGetEntities<SpawnedItem>(i => Condition(i, centerPosition, radius, flag, flag), out var entities))
                {
                    RunningPlayerPickup = false;
                    return;
                }

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
                RunningPlayerPickup = false;
            }
        }

        public static async void RunAbilityPet(Position centerPosition, int radius = 50)
        {
            if (RunningAbilityPetPickup)
                return;

            RunningAbilityPetPickup = true;

            try
            {
                if (!SpawnManager.TryGetEntities<SpawnedItem>(i => Condition(i, centerPosition, radius, true), out var entities))
                {
                    RunningAbilityPetPickup = false;
                    return;
                }

                foreach (var item in entities.OrderBy(item => item.Movement.Source.DistanceTo(Game.Player.AbilityPet.Position)))
                {
                    if (!RunningAbilityPetPickup)
                        return;

                    Game.Player.AbilityPet.Pickup(item.UniqueId);
                    await Task.Yield();
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e);
            }
            finally
            {
                RunningAbilityPetPickup = false;
            }
        }

        private static bool Condition(
            SpawnedItem e,
            Position centerPosition,
            int radius,
            bool applyPickOnlyChar = false,
            bool pickOnlyChar = false
        )
        {
            var playerJid = Game.Player.JID;

            if (JustPickMyItems && e.OwnerJID != playerJid)
                return false;

            // Don't pickup items that still belong to another player
            if (e.HasOwner && e.OwnerJID != playerJid)
                return false;

            if (applyPickOnlyChar && e.IsBehindObstacle)
                return false;

            // Check if Item is within the training area + tolerance
            const int tolerance = 15;
            var isInside = e.Movement.Source.DistanceTo(centerPosition) <= radius + tolerance;
            if (!isInside)
                return false;

            if (PickupGold && e.Record.IsGold && 
                !(applyPickOnlyChar && pickOnlyChar))
                return true;

            if (PickupRareItems && (byte)e.Rarity >= 2)
                return true;

            if (PickupBlueItems && (byte)e.Rarity >= 1)
                return true;

            if (PickupAnyEquips && e.Record.IsEquip)
                return true;

            if (PickupQuestItems && e.Record.IsQuest)
                return true;

            if (PickupEverything)
                return true;

            if (applyPickOnlyChar)
            {
               if(PickupFilter.Any(p => p.CodeName == e.Record.CodeName && p.PickOnlyChar == pickOnlyChar))
                    return true;
            }
            else if (PickupFilter.Any(p => p.CodeName == e.Record.CodeName))
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
        public static void Stop()
        {
            RunningPlayerPickup = false;
            RunningAbilityPetPickup = false;
        }
    }
}
