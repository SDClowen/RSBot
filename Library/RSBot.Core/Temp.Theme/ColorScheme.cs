using RSBot.Core;
using System.Drawing;

namespace RSBot.Theme
{
    public class ColorScheme
    {
        public static Color BackColor = Color.FromArgb(20, 20, 20);
        public static Color ForeColor = Color.White;

        public static void Load()
        {
            var scheme = GlobalConfig.Get("RSBot.Theme", "Light");
            switch (scheme)
            {
                case "Light":
                    BackColor = Color.FromArgb(249, 249, 249);
                    ForeColor = Color.Black;
                    break;

                case "Dark":
                    BackColor = Color.FromArgb(20, 20, 20);
                    ForeColor = Color.White;
                    break;
            }
        }
    }
}
