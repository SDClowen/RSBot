using RSBot.Default.Bot;
using RSBot.Default.Views;

namespace RSBot.Default
{
    internal static class Container
    {
        /// <summary>
        /// Gets or sets the bot.
        /// </summary>
        /// <value>
        /// The bot.
        /// </value>
        public static Botbase Bot { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public static Main View { get; set; }

        /// <summary>
        /// Gets or sets the lock.
        /// </summary>
        /// <value>
        /// The lock.
        /// </value>
        public static object Lock { get; set; }
    }
}