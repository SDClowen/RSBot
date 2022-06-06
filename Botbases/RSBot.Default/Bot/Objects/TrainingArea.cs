using RSBot.Core.Objects;

namespace RSBot.Default.Bot.Objects
{
    internal class TrainingArea
    {
        /// <summary>
        /// Gets or sets the center position.
        /// </summary>
        /// <value>
        /// The center position.
        /// </value>
        public Position CenterPosition { get; set; }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public int Radius { get; set; }
    }
}