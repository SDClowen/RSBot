using RSBot.Theme.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Theme.Controls
{
    public class Separator : Control
    {
        public Separator()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.ResizeRedraw | 
                ControlStyles.UserPaint | 
                ControlStyles.SupportsTransparentBackColor, 
                true
            );

            this.Size = new Size(120, 10);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            var back = Parent.BackColor;
            var dark = Color.FromArgb(back.R >> 1, back.G >> 1, back.B >> 1);

            var topColor = Color.FromArgb(30, Parent.BackColor.Determine());

            //e.Graphics.DrawLine(new Pen(dark), 0, 5, Width, 5);
            e.Graphics.DrawLine(new Pen(topColor), 0, 6, Width, 6);
        }
    }
}
