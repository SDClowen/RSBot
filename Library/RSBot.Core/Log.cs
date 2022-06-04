using RSBot.Core.Event;

using System;
using System.IO;

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
        /// Appends the specified language key.
        /// </summary>
        /// <param name="obj">The message.</param>
        /// <param name="level">The level.</param>
        public static void NotifyLang(string key, params object[] args) 
            => EventManager.FireEvent("OnAddLog", LanguageManager.GetLang(key, args), LogLevel.Notify);

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
        /// Appends the specified language key.
        /// </summary>
        /// <param name="obj">The message.</param>
        /// <param name="level">The level.</param>
        public static void WarnLang(string key, params object[] args) 
            => EventManager.FireEvent("OnAddLog", LanguageManager.GetLang(key, args), LogLevel.Warning);

        /// <summary>
        /// Append specified Error message
        /// </summary>
        /// <param name="obj">The message</param>
        public static void Error(object obj) => EventManager.FireEvent("OnAddLog", obj.ToString(), LogLevel.Error);

        /// <summary>
        /// Append specified fatal message
        /// </summary>
        /// <param name="obj">The message</param>
        public static void Fatal(Exception obj)
        {
            Warn(obj.Message);

            var filePath = Path.Combine(Environment.CurrentDirectory, "Data", "Logs", "Exceptions", $"{DateTime.Now:dd-MM-yyyy}.txt");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = File.AppendText(filePath))
                stream.WriteLine(obj.ToString());
        }
    }
}