using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using System;
using System.Collections.Generic;

namespace RSBot.Bot.Default.Bundle.Resurrect
{
    internal class ResurrectBundle : IBundle
    {
        /// <summary>
        /// The Last resurrect party members
        /// </summary>
        public Dictionary<string, int> _lastResurrectedPlayers = new Dictionary<string, int>();

        public void Invoke()
        {
            if (Game.Party == null ||
                Game.Party.Members == null)
                return;

            if (!Kernel.Bot.Running)
                return;

            if (Game.Player.Exchanging)
                return;

            if (Game.Player.State.LifeState == LifeState.Dead)
                return;

            if (Game.Player.Untouchable)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Skills.ResurrectPartyMembers"))
                return;

            foreach (var member in Game.Party.Members)
            {
                if (_lastResurrectedPlayers.ContainsKey(member.Name) &&
                    Environment.TickCount - _lastResurrectedPlayers[member.Name] < 180 * 1000)
                    continue;

                if (member.Player == null ||
                    member.Player == null)
                    continue;

                if (member.Player.Movement.Source.DistanceTo(Game.Player.Movement.Source) > 100)
                    continue;

                if (member.Player.State.LifeState == LifeState.Dead)
                {
                    if (!_lastResurrectedPlayers.ContainsKey(member.Name))
                        _lastResurrectedPlayers.Add(member.Name, Environment.TickCount);
                    else
                        _lastResurrectedPlayers[member.Name] = Environment.TickCount;

                    SkillManager.CastBuff(SkillManager.ResurrectionSkill, member.Player.UniqueId);
                }

            }
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            //Nothing to do here
        }
    }
}