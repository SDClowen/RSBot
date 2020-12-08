using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Theme.Controls
{
    [ToolboxBitmap(typeof(Panel))]
    public class HorizontalPanel : Panel
    {
        private bool _renderOnGlass = false;

        public HorizontalPanel()
        {
            this.BackColor = Color.Transparent;
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point, 0);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Whether or not the control needs to be rendered on the Glass surface.
        /// </summary>
        /// <remarks>
        /// This is false by default, it should only be toggled to true if the control needs to lay directly on
        /// the glass surface of the form.
        /// </remarks>
        [Description("Gets or sets whether the control can render on an Aero glass surface."), Category("Appearance"), DefaultValue(false)]
        public bool RenderOnGlass
        {
            get
            {
                return this._renderOnGlass;
            }
            set
            {
                this._renderOnGlass = value;
            }
        }

        public void RedrawControlAsBitmap(IntPtr hwnd)
        {
            Control c = Control.FromHandle(hwnd);
            using (Bitmap bm = new Bitmap(c.Width, c.Height))
            {
                c.DrawToBitmap(bm, c.ClientRectangle);
                using (Graphics g = c.CreateGraphics())
                {
                    Point p = new Point(-1, -1);
                    g.DrawImage(bm, p);
                }
            }
            c = null;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is LinkLabel)
            {
                e.Control.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point, 0);
                ((LinkLabel)e.Control).LinkBehavior = LinkBehavior.HoverUnderline;
                ((LinkLabel)e.Control).LinkColor = Color.FromArgb(64, 64, 64);
                ((LinkLabel)e.Control).ActiveLinkColor = Color.Blue;
            }
        }

        /// <summary>
        /// The actual painting of the background of our control.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>
        /// The colors in use here were extracted from an image of the Control Panel taken from a Windows 7 RC1 installation.
        /// </remarks>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color aeroColor1 = Color.FromArgb(204, 217, 234);
            Color aeroColor2 = Color.FromArgb(217, 227, 240); // 1
            Color aeroColor3 = Color.FromArgb(232, 238, 247);
            Color aeroColor4 = Color.FromArgb(237, 242, 249);
            Color aeroColor5 = Color.FromArgb(240, 244, 250);
            Color aeroColor6 = Color.FromArgb(241, 245, 251);

            Rectangle rect = new Rectangle(0, 0, this.Width, 1);
            SolidBrush sb = new SolidBrush(aeroColor1);
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 1, this.Width, 1);
            sb.Color = aeroColor2;
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 2, this.Width, 1);
            sb.Color = aeroColor3;
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 3, this.Width, 1);
            sb.Color = aeroColor3;
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 4, this.Width, 1);
            sb.Color = aeroColor4;
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 5, this.Width, 1);
            sb.Color = aeroColor5;
            e.Graphics.FillRectangle(sb, rect);

            rect = new Rectangle(0, 6, this.Width, this.Height - 5);
            sb.Color = aeroColor6;
            e.Graphics.FillRectangle(sb, rect);

            sb.Dispose();
        }

        /// <summary>
        /// Handles incoming Windows Messages.
        /// </summary>
        /// <param name="m"></param>
        /// <remarks>
        /// On the paint event and if the RenderOnGlass is set to true, we will redraw the control as an image directly on
        /// the form.  This has a little extra overhead but also provides the ability to lay this control directly on the
        /// glass and have it rendered correctly.
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int WM_PAINT = 15;
            if ((m.Msg == WM_PAINT) && this.RenderOnGlass)
            {
                this.RedrawControlAsBitmap(this.Handle);
            }
        }
    }
}