using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Protection.Components.Player
{
    public class BadStateSkillHandler
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
            EventManager.SubscribeEvent("OnPlayerBadEffect", new System.Action<uint>(OnPlayerBadEffect));
        }

        /// <summary>
        /// Cores the on player bad effect.
        /// </summary>
        /// <param name="id">The identifier.</param>
        private static void OnPlayerBadEffect(uint id)
        {
            if (!Kernel.Bot.Running) return;

            var useSkill = PlayerConfig.Get<bool>("RSBot.Protection.checkUseBadStatusSkill", true);
            var skillName = PlayerConfig.Get<string>("RSBot.Protection.skillBadStatus");

            if (!useSkill || string.IsNullOrWhiteSpace(skillName)) return;

            var skill = Game.Player.Skills.GetSkillByName(skillName);
            if (skill == null) return;

            Game.Player.CastBuff(skill.Id);

            Log.Debug("Use bad status skill" + skill.Record.GetRealName());
        }
    }
}