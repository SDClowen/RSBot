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
            if (Game.SelectedEntity == null)
                return;

            if (Game.SelectedEntity.IsBehindObstacle)
            {
                Log.Debug("Deselecting entity because it moved behind an obstacle!");

                if (Game.Player.InAction)
                    SkillManager.CancelAction();

                if(Game.SelectedEntity.TryDeselect())
                    Game.SelectedEntity = null;

                return;
            }

            if (SkillManager.ImbueSkill != null &&
                !Game.Player.State.HasActiveBuff(SkillManager.ImbueSkill, out _) &&
                SkillManager.ImbueSkill.CanBeCasted)
                SkillManager.CastBuff(SkillManager.ImbueSkill);

            if (Game.Player.InAction && SkillManager.LastActionType != ActionType.AutoAttack)
                return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var skill = SkillManager.GetNextSkill();
            Log.Debug($"Getnextskill: {stopwatch.ElapsedMilliseconds} Action:{Game.Player.InAction} Entity:{Game.SelectedEntity != null} LA:{SkillManager.LastActionType} Skill:{skill}");
            if (skill == null)
            {
                if (Game.Player.InAction)
                    return;

                SkillManager.CastAutoAttack();
                return;
            }
            else if (Game.Player.InAction && SkillManager.LastActionType == ActionType.AutoAttack)
                SkillManager.CancelAction();

            var uniqueId = Game.SelectedEntity.UniqueId;
            SkillManager.CastSkill(skill, uniqueId);
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