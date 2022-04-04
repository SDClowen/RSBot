using System.Drawing;

namespace System.Windows.Forms.Extensions
{
    public static class ColorExtentions
    {
        public static Color Determine(this Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color...      
            double luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (luminance > 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }
    }
}
