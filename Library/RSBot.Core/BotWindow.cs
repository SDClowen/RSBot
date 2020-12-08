using RSBot.Core.Event;

namespace RSBot.Core
{
    public class BotWindow
    {
        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void SetStatusText(string text)
        {
            EventManager.FireEvent("OnChangeStatusText", text);
        }
    }
}