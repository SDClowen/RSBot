using System.Drawing;
using System.Drawing.Drawing2D;

namespace RSBot.Theme
{
    internal static class Utility
    {
        /// <summary>
        /// Convert an integer number to a Color.
        /// </summary>
        /// <returns></returns>
        public static Color ToColor(this int argb)
        {
            return Color.FromArgb(
                (argb & 0xff0000) >> 16,
                (argb & 0xff00) >> 8,
                 argb & 0xff);
        }

        /// <summary>
        /// Removes the alpha component of a color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color RemoveAlpha(this Color color)
        {
            return Color.FromArgb(color.R, color.G, color.B);
        }

        /// <summary>
        /// Converts a 0-100 integer to a 0-255 color component.
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static int PercentageToColorComponent(this int percentage)
        {
            return (int)((percentage / 100d) * 255d);
        }

        public static GraphicsPath CreateRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath CreateRoundRect(Rectangle rect, float radius)
        {
            return CreateRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor, double blend)
        {
            double ratio = blend / 255d;
            double invRatio = 1d - ratio;
            int r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            int g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            int b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(r, g, b);
        }

        public static Color BlendColor(Color backgroundColor, Color frontColor)
        {
            return BlendColor(backgroundColor, frontColor, frontColor.A);
        }
    }
}