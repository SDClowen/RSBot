using System;
using System.Windows.Forms;

namespace RSBot.Theme.Extensions
{
    public static class TextBoxBaseExtensions
    {
        /// <summary>
        /// Append string to type in the text controls
        /// </summary>
        /// <param name="value">The TextBoxBase</param>
        /// <param name="str">The string to type in the <seealso cref="TextBoxBase"/></param>
        /// <param name="time">The time</param>
        public static void Write(this TextBoxBase value, string str, bool time = true)
        {
            value.RunInUIThread(() =>
            {
                if (time)
                    value.AppendText(DateTime.Now.ToString("[hh:mm:ss]\t"));

                value.AppendText(str);
                value.AppendText(Environment.NewLine);
                value.ScrollToCaret();
            });
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