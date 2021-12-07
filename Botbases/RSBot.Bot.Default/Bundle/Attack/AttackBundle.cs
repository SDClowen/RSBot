using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;

namespace RSBot.Bot.Default.Bundle.Attack
{
    internal class AttackBundle : IBundle
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

            if (Game.SelectedEntity == null ||
                Game.SelectedEntity.Monster == null)
                return;

            if (Game.SelectedEntity.Bionic.IsBehindObstacle)
            {
                Log.Debug("Deselecting entity because it moved behind an obstacle!");
                Game.Player.DeselectEntity();
                return;
            }

            if (SkillManager.ImbueSkill != null &&
                !Game.Player.State.HasActiveBuff(SkillManager.ImbueSkill, out _) &&
                SkillManager.ImbueSkill.CanBeCasted)
                SkillManager.CastBuff(SkillManager.ImbueSkill);

            uint uniqueId = Game.SelectedEntity.UniqueId;

            var skill = SkillManager.GetNextSkill();
            if (skill == null || !SkillManager.CastSkill(skill, uniqueId))
                SkillManager.CastAutoAttack(uniqueId);
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