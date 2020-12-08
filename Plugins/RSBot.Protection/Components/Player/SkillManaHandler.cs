using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Player
{
    public class SkillManaHandler
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
            var useHealthPotion = PlayerConfig.Get<bool>("RSBot.Protection.checkUseSkillMP");
            if (!useHealthPotion) return;

            var skillName = PlayerConfig.Get<string>("RSBot.Protection.skillPlayerMP");
            if (string.IsNullOrWhiteSpace(skillName)) return;

            var minMana = PlayerConfig.Get<int>("RSBot.Protection.numPlayerSkillMPMin", 50);
            var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;

            if (!(manaPercent <= minMana)) return;

            var skill = Game.Player.Skills.GetSkillByName(skillName);

            Log.Debug("Using MP skill: " + skill.Record.GetRealName());
            Game.Player.CastBuff(skill.Id);
        }
    }
}