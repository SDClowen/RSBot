using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Training.Bundle.Resurrect;

internal class ResurrectBundle : IBundle
{
    /// <summary>
    ///     The Last resurrect party members
    /// </summary>
    public Dictionary<string, int> _lastResurrectedPlayers = new();

    public void Invoke()
    {
        if (Game.Party == null || Game.Party.Members == null || Game.Player.HasActiveVehicle)
            return;

        if (!PlayerConfig.Get<bool>("RSBot.Skills.checkResurrectParty"))
            return;

        ushort resDelay = PlayerConfig.Get<ushort>("RSBot.Skills.numResDelay", 120);
        ushort resRadius = PlayerConfig.Get<ushort>("RSBot.Skills.numResRadius", 100);

        foreach (var member in Game.Party.Members)
        {
            if (
                _lastResurrectedPlayers.ContainsKey(member.Name)
                && Kernel.TickCount - _lastResurrectedPlayers[member.Name] < resDelay * 1000
            )
                continue;

            if (
                (
                    member.Player?.Movement.Source.DistanceTo(Game.Player.Movement.Source)
                    ?? member.Position.DistanceTo(Game.Player.Movement.Source)
                ) > resRadius
                || (
                    member.Player?.Movement.Source.HasCollisionBetween(Game.Player.Movement.Source)
                    ?? member.Position.HasCollisionBetween(Game.Player.Movement.Source)
                )
            )
                continue;

            if (member.Player?.State.LifeState != LifeState.Dead && (member.HealthMana & 0x0F) != 0)
                continue;

            if (!_lastResurrectedPlayers.ContainsKey(member.Name))
                _lastResurrectedPlayers.Add(member.Name, Kernel.TickCount);
            else
                _lastResurrectedPlayers[member.Name] = Kernel.TickCount;

            var moved = Game.Player.MoveTo(member.Player?.Movement.Source ?? member.Position, true);
            if (!moved)
                continue;

            Log.Status($"Resurrecting player {member.Name}");
            SkillManager.ResurrectionSkill?.Cast(member.Player?.UniqueId ?? member.MemberId, true);
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
