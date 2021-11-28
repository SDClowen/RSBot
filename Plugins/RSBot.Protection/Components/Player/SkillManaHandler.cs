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
            EventManager.SubscribeEvent("OnUpdateMP", OnUpdateMP);
        }

        /// <summary>
        /// Cores the on player HPMP update.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void OnUpdateMP()
        {
            if (!Kernel.Bot.Running)
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkUseSkillMP")) 
                return;

            var skillId = PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
            if (skillId == 0)
                return;

            var minMana = PlayerConfig.Get<int>("RSBot.Protection.numPlayerSkillMPMin", 50);
            var manaPercent = ((double)Game.Player.Mana / (double)Game.Player.MaximumMana) * 100;
            if (manaPercent > minMana)
                return;

            var skill = Game.Player.Skills.GetSkillInfoById(skillId);
            if (skill == null)
                return;

            Log.Debug($"Using MP skill: {skill}");
            Game.Player.CastBuff(skill.Id);
        }
    }
}