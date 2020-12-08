using System.Drawing;

namespace RSBot.Core.Plugins
{
    public class BotbaseInfo
    {
        /// <summary>
        /// Gets internal the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image Image { get; set; }

        /// <summary>
        /// Gets the tab text.
        /// </summary>
        /// <value>
        /// The tab text.
        /// </value>
        public string TabText { get; set; }
    }
}