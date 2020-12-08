using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet
{
    public class AutoSummonAttackPet
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
            EventManager.SubscribeEvent("OnUpdateEntityBattleState", new System.Action<uint>(OnEntityBattleStateChanged));
            EventManager.SubscribeEvent("OnStartBot", OnStartBot);
        }

        /// <summary>
        /// </summary>
        /// <param name="uniqueId">The unique identifier.</param>
        private static void OnEntityBattleStateChanged(uint uniqueId)
        {
            if (!Kernel.Bot.Running)
                return;

            if (uniqueId != Game.Player.UniqueId)
                return;

            if (Game.Player.AttackPet != null)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkAutoSummonAttackPet"))
                return;

            if (Game.Player.State.BattleState != BattleState.InPeace)
                return;

            Game.Player.SummonAttackPet();
        }

        /// <summary>
        /// </summary>
        private static void OnStartBot()
        {
            if (Game.Player.AttackPet != null)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkAutoSummonAttackPet"))
                return;

            if (Game.Player.State.BattleState != BattleState.InPeace)
                return;

            Game.Player.SummonAttackPet();
        }
    }
}