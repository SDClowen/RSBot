using RSBot.Bot.Default.Bundle.Attack;
using RSBot.Bot.Default.Bundle.Avoidance;
using RSBot.Bot.Default.Bundle.Berzerk;
using RSBot.Bot.Default.Bundle.Buff;
using RSBot.Bot.Default.Bundle.Loop;
using RSBot.Bot.Default.Bundle.Loot;
using RSBot.Bot.Default.Bundle.Movement;
using RSBot.Bot.Default.Bundle.PartyBuffing;
using RSBot.Bot.Default.Bundle.Resurrect;
using RSBot.Bot.Default.Bundle.Target;
using RSBot.Bot.Default.Bundle.TraceMode;

namespace RSBot.Bot.Default.Bundle
{
    internal static class Bundles
    {
        /// <summary>
        /// Gets the berzerk.
        /// </summary>
        /// <value>
        /// The berzerk.
        /// </value>
        public static BerzerkBundle Berzerk { get; private set; }

        /// <summary>
        /// Gets the avoidance.
        /// </summary>
        /// <value>
        /// The avoidance.
        /// </value>
        public static AvoidanceBundle Avoidance { get; private set; }

        /// <summary>
        /// Gets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        public static MovementBundle Movement { get; private set; }

        /// <summary>
        /// Gets the buff.
        /// </summary>
        /// <value>
        /// The buff.
        /// </value>
        public static BuffBundle Buff { get; private set; }

        /// <summary>
        /// Gets the party buff.
        /// </summary>
        /// <value>
        /// The party buff.
        /// </value>
        public static PartyBuffingBundle PartyBuff { get; private set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public static TargetBundle Target { get; private set; }

        /// <summary>
        /// Gets the attack.
        /// </summary>
        /// <value>
        /// The attack.
        /// </value>
        public static AttackBundle Attack { get; private set; }

        /// <summary>
        /// Gets the loot.
        /// </summary>
        /// <value>
        /// The loot.
        /// </value>
        public static LootBundle Loot { get; private set; }

        /// <summary>
        /// Gets the loop.
        /// </summary>
        /// <value>
        /// The loop.
        /// </value>
        public static LoopBundle Loop { get; private set; }

        /// <summary>
        /// Gets the Resurrect.
        /// </summary>
        /// <value>
        /// The Resurrect.
        /// </value>
        public static ResurrectBundle Resurrect { get; private set; }
        
        public static TraceModeBundle TraceMode { get; private set; }

        /// <summary>
        /// Reloads this instance.
        /// </summary>
        public static void Reload()
        {
            Berzerk = Berzerk ?? new BerzerkBundle();
            Berzerk.Refresh();

            Avoidance = Avoidance ?? new AvoidanceBundle();
            Avoidance.Refresh();

            Movement = Movement ?? new MovementBundle();
            Movement.Refresh();

            Buff = Buff ?? new BuffBundle();
            Buff.Refresh();

            PartyBuff = PartyBuff ?? new PartyBuffingBundle();
            PartyBuff.Refresh();

            Target = Target ?? new TargetBundle();
            Target.Refresh();

            Attack = Attack ?? new AttackBundle();
            Attack.Refresh();

            Loot = Loot ?? new LootBundle();
            Loot.Refresh();

            Loop = Loop ?? new LoopBundle();
            Loop.Refresh();

            Resurrect = Resurrect ?? new ResurrectBundle();
            Resurrect.Refresh();

            TraceMode = TraceMode ?? new TraceModeBundle();
            TraceMode.Refresh();
        }
    }
}