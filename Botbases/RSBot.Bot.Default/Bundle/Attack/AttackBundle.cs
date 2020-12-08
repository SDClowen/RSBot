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
            if (Game.SelectedEntity == null || Game.SelectedEntity.Monster == null)
                return;

            if (Game.SelectedEntity.Bionic.IsBehindObstacle)
            {
                Log.Debug("Deselecting entity because it moved behind an obstacle!");
                Game.Player.DeselectEntity();
                return;
            }

            //Equip ammunitaion
            if (Game.Player.Weapon?.Record.Quivered == 1 && Game.Player.GetAmmunationAmount() == 0)
                Game.Player.EquipAmmunation();

            var uniqueId = Game.SelectedEntity.UniqueId;

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