using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Theme.Controls
{
    public partial class TabDisabledInfo : UserControl
    {
        public TabDisabledInfo()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var backgroundBrush = new SolidBrush(Color.FromArgb(224, 221, 38));
            e.Graphics.FillRectangle(backgroundBrush, 0, 0, Width, Height);

            var flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(e.Graphics, "Please enter the game", new Font("Segoe UI Semibold", 13.37f), new Point(Width, Height), Color.FromArgb(143, 140, 0), flags);
        }
    }
}