using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Bot.Default.Bundle.Attack
{
    internal class AttackBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
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
                Game.Player.CastBuff(SkillManager.ImbueSkill.Id);

            uint uniqueId = Game.SelectedEntity.UniqueId;

            var skill = SkillManager.GetNextSkill();
            if (skill == null || !Game.Player.CastSkill(skill.Id, uniqueId))
                Game.Player.CastAutoAttack(uniqueId);
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