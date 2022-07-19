using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Default.Bundle.Buff
{
    internal class BuffBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            var buffs = SkillManager.Buffs.FindAll(p => !Game.Player.State.HasActiveBuff(p, out _) && p.CanBeCasted);
            if (buffs == null || buffs.Count == 0)
                return;

            //Game.Player.TryGetAbilitySkills(out var abilitySkills);

            foreach (var buff in buffs)
            {
                if (Game.Player.State.LifeState != LifeState.Alive || Game.Player.HasActiveVehicle)
                    break;

                /* working stable but i dont think to need check again here
                var skillInfo = Game.Player.Skills.GetSkillInfoById(buff.Id);
                if (skillInfo == null)
                {
                    skillInfo = abilitySkills.FirstOrDefault(p => p.Id == buff.Id);
                    if (skillInfo == null)
                        continue;
                }
                */

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