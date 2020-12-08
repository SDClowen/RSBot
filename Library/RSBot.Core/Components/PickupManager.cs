using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Core.Components
{
    public class PickupManager
    {
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
        /// Gets or sets a value indicating whether this <see cref="PickupManager"/> is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public static bool Running { get; set; }

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
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            PickupFilter = new ItemFilter();

            Log.Debug("[PickupManager] Initialized!");
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void Run(uint itemUniqueId)
        {
            var item = Game.Spawns.GetItem(itemUniqueId);

            if (item.OwnerJID != Game.Player.JID && item.HasOwner && item.OwnerJID != 0xffffffff)
            {
                Running = false;
                return;
            }
            if (PickupGold && item.Record.TypeID2 == 3 && item.Record.TypeID3 == 5)
            {
                if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
                    Game.Player.AbilityPet.Pickup(item.UniqueId);
                else
                    Game.Player.Pickup(item.UniqueId);
            }

            if (PickupFilter.Invoke(item.Record))
            {
                if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
                    Game.Player.AbilityPet.Pickup(item.UniqueId);
                else
                    Game.Player.Pickup(item.UniqueId);
            }

            // ReSharper disable once InvertIf
            if ((byte)item.Rarity >= 2 && PickupRareItems)
            {
                if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
                    Game.Player.AbilityPet.Pickup(item.UniqueId);
                else
                    Game.Player.Pickup(item.UniqueId);
            }
        }

        /// <summary>
        /// Runs the specified center position.
        /// </summary>
        /// <param name="centerPosition">The center position.</param>
        /// <param name="radius">The radius.</param>
        public static void Run(Position centerPosition, int radius = 50)
        {
            Running = true;

            foreach (var item in
                        Game.Spawns.GetItems()
                                .Where(i => i.OwnerJID == Game.Player.JID || i.HasOwner == false)
                                .OrderBy(item => item.Position.DistanceTo(centerPosition))
                                .Where(item => item.Position.DistanceTo(centerPosition) <= radius)
                                .Take(5)
                     )
            {
                //Bot stopped?
                if (!Running)
                    return;

                if (PlayerConfig.Get<bool>("RSBot.Items.Pickup.JustPickMyItems") && item.OwnerJID != Game.Player.JID)
                    continue;

                //Pickup gold
                if (PickupGold && item.Record.TypeID2 == 3 && item.Record.TypeID3 == 5)
                {
                    if (UseAbilityPet && Game.Player.HasActiveAbilityPet && !Game.Player.AbilityPet.Full)
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

                //Pickup rare items
                // ReSharper disable once InvertIf
                if ((byte)item.Rarity > 2 && PickupRareItems)
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