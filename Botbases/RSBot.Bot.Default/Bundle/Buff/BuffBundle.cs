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
            if (Game.Player.InAction) 
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
                Game.Player.CastBuff(buff.Id);
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