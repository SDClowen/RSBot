using RSBot.Default.Bundle.Attack;
using RSBot.Default.Bundle.Avoidance;
using RSBot.Default.Bundle.Berzerk;
using RSBot.Default.Bundle.Buff;
using RSBot.Default.Bundle.Loop;
using RSBot.Default.Bundle.Loot;
using RSBot.Default.Bundle.Movement;
using RSBot.Default.Bundle.PartyBuffing;
using RSBot.Default.Bundle.Protection;
using RSBot.Default.Bundle.Resurrect;
using RSBot.Default.Bundle.Target;

namespace RSBot.Default.Bundle
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

        public static ProtectionBundle Protection { get; private set; }

        /// <summary>
        /// Reloads this instance.
        /// </summary>
        public static void Reload()
        {
            (Berzerk ??= new BerzerkBundle()).Refresh();
            (Avoidance ??= new AvoidanceBundle()).Refresh();
            (Movement ??= new MovementBundle()).Refresh();
            (Buff ??= new BuffBundle()).Refresh();
            (PartyBuff ??= new PartyBuffingBundle()).Refresh();
            (Target ??= new TargetBundle()).Refresh();
            (Attack ??= new AttackBundle()).Refresh();
            (Loot ??= new LootBundle()).Refresh();
            (Loop ??= new LoopBundle()).Refresh();
            (Resurrect ??= new ResurrectBundle()).Refresh();
            (Protection ??= new ProtectionBundle()).Refresh();
        }

        public static void Stop()
        {
            Berzerk?.Stop();
            Avoidance?.Stop();
            Movement?.Stop();
            Buff?.Stop();
            PartyBuff?.Stop();
            Target?.Stop();
            Attack?.Stop();
            Loot?.Stop();
            Loop?.Stop();
            Resurrect?.Stop();
            Protection?.Stop();
        }
    }
}