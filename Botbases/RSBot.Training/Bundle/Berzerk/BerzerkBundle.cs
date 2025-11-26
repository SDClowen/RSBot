using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Training.Bundle.Berzerk;

internal class BerzerkBundle : IBundle
{
    /// <summary>
    ///     Gets or sets the configuration.
    /// </summary>
    /// <value>
    ///     The configuration.
    /// </value>
    public BerzerkConfig Config { get; set; }

    /// <summary>
    ///     Invokes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Invoke()
    {
        if (!Game.Player.CanEnterBerzerk || Game.Player.HasActiveVehicle)
            return;

        if (Config.WhenFull)
        {
            Game.Player.EnterBerzerkMode();

            return;
        }

        if (Config.SurroundedByMonsters)
        {
            var mobAmount = SpawnManager.Count<SpawnedMonster>(m => m.AttackingPlayer && m.DistanceToPlayer < 20);
            if (mobAmount >= Config.SurroundingMonsterAmount)
            {
                Game.Player.EnterBerzerkMode();
                return;
            }
        }

        if (Config.WhenTargetSpecificRartiyMonster)
        {
            if (Game.SelectedEntity is SpawnedMonster e && Bundles.Avoidance.UseBerserkOnMonster(e.Rarity))
            {
                Game.Player.EnterBerzerkMode();
                return;
            }
        }

        if (!Config.BeeingAttackedByAwareMonster)
            return;

        if (Game.SelectedEntity is not SpawnedMonster entity)
            return;

        if (Bundles.Avoidance.AvoidMonster(entity.Rarity))
            Game.Player.EnterBerzerkMode();
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        Config = new BerzerkConfig
        {
            WhenFull = PlayerConfig.Get<bool>("RSBot.Training.checkBerzerkWhenFull"),
            BeeingAttackedByAwareMonster = PlayerConfig.Get<bool>("RSBot.Training.checkBerzerkAvoidance"),
            SurroundedByMonsters = PlayerConfig.Get<bool>("RSBot.Training.checkBerzerkMonsterAmount"),
            SurroundingMonsterAmount = PlayerConfig.Get<byte>("RSBot.Training.numBerzerkMonsterAmount", 5),
            WhenTargetSpecificRartiyMonster = PlayerConfig.Get<bool>("RSBot.Training.checkBerserkOnMonsterRarity"),
        };
    }

    public void Stop()
    {
        //Nothing to do
    }
}
