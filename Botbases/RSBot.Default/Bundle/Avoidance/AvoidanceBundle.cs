﻿using System.Linq;
using RSBot.Core;
using RSBot.Core.Objects;

namespace RSBot.Default.Bundle.Avoidance;

internal class AvoidanceBundle : IBundle
{
    /// <summary>
    ///     Gets the avoidance list.
    /// </summary>
    /// <value>
    ///     The avoidance list.
    /// </value>
    public MonsterRarity[] AvoidanceList => PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Avoid");

    /// <summary>
    ///     Gets the preferance list.
    /// </summary>
    /// <value>
    ///     The preferance list.
    /// </value>
    public MonsterRarity[] PreferanceList => PlayerConfig.GetEnums<MonsterRarity>("RSBot.Avoidance.Prefer");

    /// <summary>
    ///     Invokes this instance.
    /// </summary>
    public void Invoke()
    {
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {

    }

    public void Stop()
    {
        //Nothing to do
    }

    /// <summary>
    ///     Avoids the monster.
    /// </summary>
    /// <param name="rarity">The rarity.</param>
    /// <returns></returns>
    public bool AvoidMonster(MonsterRarity rarity) => AvoidanceList.Contains(rarity);

    /// <summary>
    ///     Prefers the monster.
    /// </summary>
    /// <param name="rarity">The rarity.</param>
    /// <returns></returns>
    public bool PreferMonster(MonsterRarity rarity) => PreferanceList.Contains(rarity);
}