using RSBot.Core;
using RSBot.Core.Components;
using System;
using System.Collections.Generic;

namespace RSBot.Bot.Default.Bundle.Resurrect
{
    internal class ResurrectBundle : IBundle
    {
        #region Fields

        /// <summary>
        /// The Last resurrect party members
        /// </summary>
        public Dictionary<string, DateTime> _lastResurrectedPlayers = new Dictionary<string, DateTime>();

        #endregion Fields

        public void Invoke()
        {
            if (Game.Party != null && PlayerConfig.Get<bool>("RSBot.Skills.ResurrectPartyMembers"))
            {
                if (Game.Party.Members == null) return;

                foreach (var member in Game.Party.Members)
                {
                    if (_lastResurrectedPlayers.ContainsKey(member.Name) && DateTime.Now.Subtract(_lastResurrectedPlayers[member.Name]).Seconds < 180)
                        continue;

                    var memberBionic = Game.Spawns.GetPlayerByName(member.Name)?.Bionic;
                    if (memberBionic != null)
                    {
                        if (memberBionic.Tracker.Position.DistanceTo(Game.Player.Tracker.Position) > 50)
                            continue;

                        if (memberBionic.State.LifeState == Core.Objects.LifeState.Dead)
                        {
                            if (!_lastResurrectedPlayers.ContainsKey(member.Name))
                                _lastResurrectedPlayers.Add(member.Name, DateTime.Now);
                            else
                                _lastResurrectedPlayers[member.Name] = DateTime.Now;

                            Game.Player.CastSkill(SkillManager.ResurrectionSkill.Id, memberBionic.UniqueId);
                        }
                    }
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