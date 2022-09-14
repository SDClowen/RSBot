﻿using RSBot.Training.Bot;
using RSBot.Training.Views;

namespace RSBot.Training
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