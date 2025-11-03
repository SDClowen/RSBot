using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Default.Bundle.Resurrect;

internal class ResurrectBundle : IBundle
{
    /// <summary>
    ///     The Last resurrect party members
    /// </summary>
    public Dictionary<string, int> _lastResurrectedPlayers = new();

    public void Invoke()
    {
        if (Game.Party == null ||
            Game.Party.Members == null ||
            Game.Player.HasActiveVehicle)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Skills.checkResurrectParty"))
            return;

        foreach (var member in Game.Party.Members)
        {
            if (_lastResurrectedPlayers.ContainsKey(member.Name) &&
                Kernel.TickCount - _lastResurrectedPlayers[member.Name] < 180 * 1000)
                continue;

            if (member.Player == null ||
                member.Player == null)
                continue;

            if (member.Player.Movement.Source.DistanceTo(Game.Player.Movement.Source) > 100 ||
                member.Player.Movement.Source.HasCollisionBetween(Game.Player.Movement.Source))
                continue;

            if (member.Player.State.LifeState != LifeState.Dead)
                continue;

            if (!_lastResurrectedPlayers.ContainsKey(member.Name))
                _lastResurrectedPlayers.Add(member.Name, Kernel.TickCount);
            else
                _lastResurrectedPlayers[member.Name] = Kernel.TickCount;

            var moved = Game.Player.MoveTo(member.Player.Movement.Source, false);
            if (!moved)
                continue;

            Log.Status($"Resurrecting player {member.Name}");
            SkillManager.ResurrectionSkill?.Cast(member.Player.UniqueId, true);
        }
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        //Nothing to do here
    }

    public void Stop()
    {
        //Nothing to do here
    }
}