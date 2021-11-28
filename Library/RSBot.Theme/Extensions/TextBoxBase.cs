using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RSBot.Theme.Extensions
{
    public static class TextBoxBaseExtensions
    {
        /// <summary>
        /// Sync lock object
        /// </summary>
        private static object _lock = new object();

        /// <summary>
        /// Append string to type in the text controls
        /// </summary>
        /// <param name="value">The TextBoxBase</param>
        /// <param name="str">The string to type in the <seealso cref="TextBoxBase"/></param>
        /// <param name="time">The time</param>
        public static void Write(this TextBoxBase value, string str, bool time = true, bool writeToFile = false, string filePath = "")
        {
            var stringBuilder = new StringBuilder();
            if (time)
                stringBuilder.Append(DateTime.Now.ToString("[hh:mm:ss]\t"));

            stringBuilder.Append(str);
            stringBuilder.Append(Environment.NewLine);

            value.RunInUIThread(() =>
            {
                value.AppendText(stringBuilder.ToString());
                value.ScrollToCaret();
            });

            if(writeToFile)
            {
                lock (_lock)
                {
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    using (var stream = File.AppendText(filePath))
                        stream.Write(stringBuilder.ToString());
                }
            }
        }

        /// <summary>
        /// Run action a required thread on controls
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="action">The action</param>
        public static void RunInUIThread(this Control target, Action action)
        {
            if (target.InvokeRequired)
                target.Invoke(action);
            else
                action();
        }
    }
}