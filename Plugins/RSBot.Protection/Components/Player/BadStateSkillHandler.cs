using RSBot.Core;
using RSBot.Core.Components;
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
            if (!Kernel.Bot.Running) 
                return;

            if (!PlayerConfig.Get<bool>("RSBot.Protection.checkUseBadStatusSkill"))
                return;

            var skillId = PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
            if (skillId == 0)
                return;

            var skill = Game.Player.Skills.GetSkillInfoById(skillId);
            if (skill == null)
                return;

            Log.Debug($"Using bad status skill: {skill}");
            SkillManager.CastBuff(skill);
        }
    }
}