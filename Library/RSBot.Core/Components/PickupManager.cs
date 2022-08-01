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
            try
            {
                var playerJid = Game.Player.JID;

                bool condition(SpawnedItem e)
                {
                    if (JustPickMyItems && (e.OwnerJID != playerJid && e.OwnerJID != 0))
                        return false;

                    //Don't pickup items that still belong to another player
                    if (!JustPickMyItems && e.HasOwner)
                        return false;

                    const int tolerance = 15;
                    var isInside = e.Movement.Source.DistanceTo(centerPosition) <= radius + tolerance;
                    if (!isInside)
                        return false;

                    if (PickupGold && e.Record.IsGold)
                        return true;

                    if (PickupFilter.Invoke(e.Record))
                        return true;

                    if (PickupRareItems && (byte)e.Rarity >= 2)
                        return true;

                    if (PickupBlueItems && (byte)e.Rarity >= 1)
                        return true;

                    return false;
                }

                if (!SpawnManager.TryGetEntities<SpawnedItem>(out var entities, condition))
                {
                    Stop();
                    return;
                }

                if (UseAbilityPet && Game.Player.HasActiveAbilityPet)
                {
                    foreach (var item in entities.OrderBy(item => item.Movement.Source.DistanceTo(centerPosition))/*.Take(5)*/)
                    {
                        if (!Running)
                            return;

                        Game.Player.AbilityPet.Pickup(item.UniqueId);
                    }
                }
                else
                {
                    var itemsToPickup = entities.OrderBy(item => item.Movement.Source.DistanceTo(centerPosition));

                    foreach (var item in itemsToPickup) {
                        //Make sure the player is at the item's location
                        Game.Player.MoveTo(item.Movement.Source);

                        item.Pickup();
                    }
                }

                
            }
            catch (System.Exception e)
            {
                Log.Fatal(e);
            }
            finally
            {
                Stop();
            }
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