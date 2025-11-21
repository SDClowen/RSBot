using RSBot.Training.Bundle.Attack;
using RSBot.Training.Bundle.Avoidance;
using RSBot.Training.Bundle.Berzerk;
using RSBot.Training.Bundle.Buff;
using RSBot.Training.Bundle.Loop;
using RSBot.Training.Bundle.Loot;
using RSBot.Training.Bundle.Movement;
using RSBot.Training.Bundle.PartyBuffing;
using RSBot.Training.Bundle.Protection;
using RSBot.Training.Bundle.Resurrect;
using RSBot.Training.Bundle.Target;

namespace RSBot.Training.Bundle;

internal static class Bundles
{
    /// <summary>
    ///     Gets the berzerk.
    /// </summary>
    /// <value>
    ///     The berzerk.
    /// </value>
    public static BerzerkBundle Berzerk { get; } = new();

    /// <summary>
    ///     Gets the avoidance.
    /// </summary>
    /// <value>
    ///     The avoidance.
    /// </value>
    public static AvoidanceBundle Avoidance { get; } = new();

    /// <summary>
    ///     Gets the movement.
    /// </summary>
    /// <value>
    ///     The movement.
    /// </value>
    public static MovementBundle Movement { get; } = new();

    /// <summary>
    ///     Gets the buff.
    /// </summary>
    /// <value>
    ///     The buff.
    /// </value>
    public static BuffBundle Buff { get; } = new();

    /// <summary>
    ///     Gets the party buff.
    /// </summary>
    /// <value>
    ///     The party buff.
    /// </value>
    public static PartyBuffingBundle PartyBuff { get; } = new();

    /// <summary>
    ///     Gets the target.
    /// </summary>
    /// <value>
    ///     The target.
    /// </value>
    public static TargetBundle Target { get; } = new();

    /// <summary>
    ///     Gets the attack.
    /// </summary>
    /// <value>
    ///     The attack.
    /// </value>
    public static AttackBundle Attack { get; } = new();

    /// <summary>
    ///     Gets the loot.
    /// </summary>
    /// <value>
    ///     The loot.
    /// </value>
    public static LootBundle Loot { get; } = new();

    /// <summary>
    ///     Gets the loop.
    /// </summary>
    /// <value>
    ///     The loop.
    /// </value>
    public static LoopBundle Loop { get; } = new();

    /// <summary>
    ///     Gets the Resurrect.
    /// </summary>
    /// <value>
    ///     The Resurrect.
    /// </value>
    public static ResurrectBundle Resurrect { get; } = new();

    /// <summary>
    ///     Gets the Protection.
    /// </summary>
    /// <value>
    ///     The Protection.
    /// </value>
    public static ProtectionBundle Protection { get; } = new();

    /// <summary>
    ///     Reloads this instance.
    /// </summary>
    public static void Reload()
    {
        Berzerk.Refresh();
        Avoidance.Refresh();
        Movement.Refresh();
        Buff.Refresh();
        PartyBuff.Refresh();
        Target.Refresh();
        Attack.Refresh();
        Loot.Refresh();
        Loop.Refresh();
        Resurrect.Refresh();
        Protection.Refresh();
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
