using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Bot.Default.Bundle.Buff
{
    internal class BuffBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            if (!Kernel.Bot.Running)
                return;

            if (Game.Player.Exchanging)
                return;

            if (Game.Player.State.LifeState == LifeState.Dead)
                return;

            if (Game.Player.Untouchable)
                return;

            while (true)
            {
                if (Game.Player.State.LifeState != LifeState.Alive)
                    break;

                var buff = SkillManager.Buffs.Find(p => !Game.Player.State.HasActiveBuff(p, out _) && p.CanBeCasted);
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
            //Nothing to do here
        }
    }
}