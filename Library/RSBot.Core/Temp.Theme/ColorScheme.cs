using RSBot.Core;
using System.Drawing;

namespace System.Windows.Forms
{
    public class ColorScheme
    {
        public static Color BackColor = Color.White;
        public static Color ForeColor = Color.Black;

        public static void Load()
        {
            BackColor = Color.FromArgb(255, Color.FromArgb(GlobalConfig.Get("System.Windows.Forms.Color", 0)));
        }
    }
}
