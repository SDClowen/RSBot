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
        /// Gets the display name (label).
        ///
        /// This value will be displayed as item text botbase ComboBox in the main window.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// This value will be displayed as TabPage text in the main window.
        /// </summary>
        /// <value>
        /// The tab text.
        /// </value>
        public string TabText { get; set; }
    }
}