using RSBot.Core;
using System.Drawing;

namespace RSBot.Theme
{
    public class ColorScheme
    {
        public static Color BackColor = Color.White;
        public static Color ForeColor = Color.Black;

        public static void Load()
        {
            BackColor = Color.FromArgb(255, Color.FromArgb(GlobalConfig.Get("RSBot.Theme.Color", 0)));
        }
    }
}
