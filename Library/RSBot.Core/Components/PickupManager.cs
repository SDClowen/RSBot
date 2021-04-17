using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Linq;

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
        public static bool Running { get; private set; }

        /// <summary>
        /// Gets or sets the pickup items.
        /// </summary>
        /// <value>
        /// The pickup items.
        /// </value>
        public static ItemFilter PickupFilter { get; set; }

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
        public static bool JustPickMyItems => PlayerConfig.Get<bool>("RSBot.Items.Pickup.JustPickMyItems", true);

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            PickupFilter = new ItemFilter();

            Log.Debug("[PickupManager] Initialized!");
        }

        /// <summary>
        /// Runs the specified center position.
        /// </summary>
        /// <param name="centerPosition">The center position.</param>
        /// <param name="radius">The radius.</param>
        public static void Run(Position centerPosition, int radius = 50)
        {
            // if the manager is busy,return
            if (Running)
                return;

            Running = true;
            var playerJid = Game.Player.JID;

            bool condition(SpawnedItem e)
            {
                var tolarance = 15;
                var isInside = e.Position.DistanceTo(centerPosition) <= radius + tolarance;
                var selfish = JustPickMyItems && e.OwnerJID == playerJid;

                return isInside && (selfish || !JustPickMyItems);
            }

            foreach (var item in Game.Spawns.GetItems().Where(i => condition(i))
                                     .OrderBy(item => item.Position.DistanceTo(centerPosition))
                                     .Take(5))
            {
                if (!Running)
                    return;

                if (PickupGold && item.Record.IsGold)
                {
                    if (UseAbilityPet && Game.Player.HasActiveAbilityPet)
                        Game.Player.AbilityPet.Pickup(item.UniqueId);
                    else
                        Game.Player.Pickup(item.UniqueId);

                    continue;
                }

                //Pickup regular items
                if (PickupFilter.Invoke(item.Record))
                {
                    if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
                        Game.Player.AbilityPet.Pickup(item.UniqueId);
                    else
                        Game.Player.Pickup(item.UniqueId);

                    continue;
                }

                if (PickupRareItems && (byte)item.Rarity >= 2)
                {
                    if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
                        Game.Player.AbilityPet.Pickup(item.UniqueId);
                    else
                        Game.Player.Pickup(item.UniqueId);
                }
            }

            Running = false;
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public static void Stop()
        {
            Running = false;
        }
    }
}