using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Protection.Components.Player
{
    internal class SkillHealthHandler
    {
        public static void Initialize()
        {
            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnTick", OnTick);
        }

        /// <summary>
        /// Cores the on player HPMP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnTick()
        {
            if ((Game.Player.BadEffect & BadEffect.Zombie) == BadEffect.Zombie)
                return;

            var useHealthPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseSkillHP");
            if (!useHealthPotion) return;

            var skillName = PlayerConfig.Get<string>("RSBot.Protection.skillPlayerHP", "");
            if (string.IsNullOrWhiteSpace(skillName)) return;

            var minHealth = PlayerConfig.Get<int>("RSBot.Protection.numPlayerSkillHPMin", 50);

            var healthPercent = ((double)Game.Player.Health / (double)Game.Player.MaximumHealth) * 100;

            if (healthPercent <= minHealth)
            {
                var skill = Game.Player.Skills.GetSkillByName(skillName);

                Log.Debug("Using HP skill: " + skill.Record.GetRealName());
                Game.Player.CastBuff(skill.Id);
            }
        }
    }
}