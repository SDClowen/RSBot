using RSBot.Core.Event;

namespace RSBot.Core
{
    public class Log
    {
        /// <summary>
        /// Replaces the format item in a specified string with the string
        /// representation of a corresponding object in a specified array
        /// </summary>
        /// <param name="logLevel">The message level</param>
        /// <param name="format">The format</param>
        /// <param name="args">The args</param>
        public static void AppendFormat(LogLevel logLevel, string format, params object[] args)
        {
            EventManager.FireEvent("OnAddLog", string.Format(format, args), logLevel);
        }

        /// <summary>
        /// Appends the specified message.
        /// </summary>
        /// <param name="obj">The message.</param>
        /// <param name="level">The level.</param>
        public static void Notify(object obj) => EventManager.FireEvent("OnAddLog", obj.ToString(), LogLevel.Notify);

        /// <summary>
        /// Append specified debug message
        /// </summary>
        /// <param name="obj">The message</param>
        public static void Debug(object obj) => EventManager.FireEvent("OnAddLog", obj.ToString(), LogLevel.Debug);

        /// <summary>
        /// Append specified Warning message
        /// </summary>
        /// <param name="obj">The message</param>
        public static void Warn(object obj) => EventManager.FireEvent("OnAddLog", obj.ToString(), LogLevel.Warning);

        /// <summary>
        /// Append specified Error message
        /// </summary>
        /// <param name="obj">The message</param>
        public static void Error(object obj) => EventManager.FireEvent("OnAddLog", obj.ToString(), LogLevel.Error);
    }
}