using RSBot.Bot.Default.Bundle.Attack;
using RSBot.Bot.Default.Bundle.Avoidance;
using RSBot.Bot.Default.Bundle.Berzerk;
using RSBot.Bot.Default.Bundle.Buff;
using RSBot.Bot.Default.Bundle.Loop;
using RSBot.Bot.Default.Bundle.Loot;
using RSBot.Bot.Default.Bundle.Movement;
using RSBot.Bot.Default.Bundle.Resurrect;
using RSBot.Bot.Default.Bundle.Target;

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

        /// <summary>
        /// Reloads this instance.
        /// </summary>
        public static void Reload()
        {
            if (Berzerk == null)
                Berzerk = new BerzerkBundle();

            Berzerk.Refresh();

            if (Avoidance == null)
                Avoidance = new AvoidanceBundle();

            Avoidance.Refresh();

            if (Movement == null)
                Movement = new MovementBundle();

            Movement.Refresh();

            if (Buff == null)
                Buff = new BuffBundle();

            Buff.Refresh();

            if (Target == null)
                Target = new TargetBundle();

            Target.Refresh();

            if (Attack == null)
                Attack = new AttackBundle();

            Attack.Refresh();

            if (Loot == null)
                Loot = new LootBundle();

            Loot.Refresh();

            if (Loop == null)
                Loop = new LoopBundle();

            Loop.Refresh();

            if (Resurrect == null)
                Resurrect = new ResurrectBundle();

            Resurrect.Refresh();
        }
    }
}