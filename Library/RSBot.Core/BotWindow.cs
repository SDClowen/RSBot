using RSBot.Core.Components;
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

        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void SetStatusTextLang(string key)
        {
            EventManager.FireEvent("OnChangeStatusText", LanguageManager.GetLang(key));
        }

        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void SetStatusTextLang(string key, params object[] args)
        {
            EventManager.FireEvent("OnChangeStatusText", LanguageManager.GetLang(key, args));
        }

        /// <summary>
        /// Brings the bot window to the front
        /// </summary>
        public static void Show()
        {
            EventManager.FireEvent("OnShowBotWindow");
        }
    }
}