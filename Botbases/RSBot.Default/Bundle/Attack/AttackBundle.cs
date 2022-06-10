using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Default.Bundle.Attack
{
    internal class AttackBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            if (Game.SelectedEntity == null || Game.Player.HasActiveVehicle)
                return;

            if (Game.SelectedEntity.IsBehindObstacle)
            {
                Log.Debug("Deselecting entity because it moved behind an obstacle!");

                if (Game.Player.InAction)
                    SkillManager.CancelAction();

                Game.SelectedEntity.TryDeselect();
                Game.SelectedEntity = null;

                return;
            }

            if (SkillManager.ImbueSkill != null &&
                !Game.Player.State.HasActiveBuff(SkillManager.ImbueSkill, out _) &&
                SkillManager.ImbueSkill.CanBeCasted)
                SkillManager.CastBuff(SkillManager.ImbueSkill);

            if (Game.Player.InAction && !SkillManager.IsLastCastedBasic)
                return;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var skill = SkillManager.GetNextSkill();

            Log.Debug($"Getnextskill: {stopwatch.ElapsedMilliseconds} Action:{Game.Player.InAction} Entity:{Game.SelectedEntity != null} LA:{SkillManager.IsLastCastedBasic} Skill:{skill}");

            if (skill == null)
            {
                if (Game.Player.InAction)
                    return;

                SkillManager.CastAutoAttack();

                return;
            }
            if (Game.Player.InAction && SkillManager.IsLastCastedBasic)
                SkillManager.CancelAction();

            var uniqueId = Game.SelectedEntity?.UniqueId;
            if (uniqueId == null)
                return;

            SkillManager.CastSkill(skill, (uint) uniqueId);
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            //Nothing to do here
        }

        public void Stop()
        {
            //Nothing to do
        }
    }
}