using RSBot.Core.Components;

namespace RSBot.Bot.Default.Bundle.Buff
{
    internal class BuffBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            SkillManager.CastBuffs();
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