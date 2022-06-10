using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;

namespace RSBot.Default.Bundle.Buff
{
    internal class BuffBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            while (true)
            {
                if (Game.Player.State.LifeState != LifeState.Alive || Game.Player.HasActiveVehicle)
                    break;

                var buff = SkillManager.Buffs.Find(p => !Game.Player.State.HasActiveBuff(p, out _));
                if (buff == null)
                    break;

                var playerSkill = Game.Player.Skills.GetSkillInfoById(buff.Id);
                if (playerSkill == null)
                    continue;

                Log.Debug($"Trying to cast buff: {buff} {buff.Record.Basic_Code}");
                SkillManager.CastBuff(buff);
            }
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            //Nothing to do
        }

        public void Stop()
        {
            //Nothing to do
        }
    }
}