using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet
{
    public class ReviveAttackPetHandler
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnUpdateInventoryItem", new System.Action<byte>(OnItemUpdate));
            EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        }

        /// <summary>
        /// </summary>
        /// <param name="slot">The slot.</param>
        private static void OnItemUpdate(byte slot)
        {
            if (!Kernel.Bot.Running)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkReviveAttackPet"))
                return;

            var item = Game.Player.Inventory.GetItemAt(slot);
            if (item.Record.TypeID2 != 2 || item.Record.TypeID3 != 1 || item.Record.TypeID4 != 1 || item.State != InventoryItemState.Dead) return;

            Game.Player.ReviveAttackPet();
        }

        /// <summary>
        /// </summary>
        private static void OnStartBot()
        {
            if (!Kernel.Bot.Running)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkReviveAttackPet"))
                return;

            Game.Player.ReviveAttackPet();
        }
    }
}