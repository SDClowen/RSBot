using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Pet;

public class AutoSummonAttackPet
{
    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnKillSelectedEnemy", OnKillSelectedEnemy);
        EventManager.SubscribeEvent("OnStartBot", OnStartBot);
    }

    /// <summary>
    /// </summary>
    /// <param name="uniqueId">The unique identifier.</param>
    private static void OnKillSelectedEnemy()
    {
        if (!Kernel.Bot.Running)
            return;

        if (Game.Player.State.LifeState == LifeState.Dead)
            return;

        if (Game.Player.Growth != null || Game.Player.Fellow != null)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkAutoSummonAttackPet"))
            return;

        //if (Game.Player.State.BattleState != BattleState.InPeace)
        //    return;

        if (Game.Player.SummonFellow())
            return;

        Game.Player.SummonGrowth();
    }

    /// <summary>
    /// </summary>
    private static void OnStartBot()
    {
        if (Game.Player.Growth != null || Game.Player.Fellow != null)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Protection.checkAutoSummonAttackPet"))
            return;

        if (Game.Player.State.BattleState != BattleState.InPeace)
            return;

        if (Game.Player.SummonFellow())
            return;

        Game.Player.SummonGrowth();
    }
}
