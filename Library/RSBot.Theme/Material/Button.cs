using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace RSBot.Theme.Material
{
    using Animation;

    public class Button : System.Windows.Forms.Button, IMaterialControl
    {
        [Browsable(false)]
        public int Depth { get; set; }

        [Browsable(false)]
        public MaterialSkinManager SkinManager { get { return MaterialSkinManager.Instance; } }

        [Browsable(false)]
        public IMatMouseState MouseState { get; set; }

        public bool Primary { get; set; }

        public bool Raised { get; set; }

        public Color SingleColor { get; set; } = Color.Empty;

        private readonly AnimationManager animationManager;
        private readonly AnimationManager hoverAnimationManager;

        private SizeF textSize;

        private Image _icon;

        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                if (AutoSize)
                    Size = GetPreferredSize();
                Invalidate();
            }
        }

        public Button()
        {
            Primary = false;

            animationManager = new AnimationManager(false)
            {
                Increment = 0.03,
                AnimationType = AnimationType.EaseOut
            };
            hoverAnimationManager = new AnimationManager
            {
                Increment = 0.07,
                AnimationType = AnimationType.Linear
            };

            hoverAnimationManager.OnAnimationProgress += sender => Invalidate();
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                textSize = CreateGraphics().MeasureString(value, Font);
                if (AutoSize)
                    Size = GetPreferredSize();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.SystemDefault;

            if (Parent.BackColor == Color.Transparent)
                g.Clear(ColorScheme.BackColor);
            else
                g.Clear(Parent.BackColor);

            //Hover
            Color hoverColor = SkinManager.GetFlatButtonHoverBackgroundColor();

            using (var backgroundPath = Utility.CreateRoundRect(ClientRectangle.X,
                 ClientRectangle.Y,
                 ClientRectangle.Width - 1,
                 ClientRectangle.Height - 1,
                 1f))
            {
                if (Raised)
                {
                    if (SingleColor == Color.Empty)
                    {
                        if (Enabled)
                        {
                            g.FillPath(Primary ? SkinManager.ColorScheme.LightPrimaryBrush : SkinManager.GetRaisedButtonBackgroundBrush(), backgroundPath);
                            g.DrawPath(new Pen(Primary ? SkinManager.ColorScheme.LightPrimaryBrush : SkinManager.GetRaisedButtonBackgroundBrush()), backgroundPath);
                        }
                        else
                        {
                            g.DrawPath(new Pen(ColorScheme.BorderColor), backgroundPath);
                            using (Brush b = new SolidBrush(Color.FromArgb((int)(hoverAnimationManager.GetProgress() * hoverColor.A), hoverColor.RemoveAlpha())))
                                g.FillRectangle(b, ClientRectangle);
                        }
                    }
                    else
                    {
                        g.FillPath(new SolidBrush(SingleColor), backgroundPath);
                        g.DrawPath(new Pen(SingleColor), backgroundPath);
                    }
                }
                else
                {
                    g.DrawPath(new Pen(ColorScheme.BorderColor), backgroundPath);
                    using (Brush b = new SolidBrush(Color.FromArgb((int)(hoverAnimationManager.GetProgress() * hoverColor.A), hoverColor.RemoveAlpha())))
                        g.FillRectangle(b, ClientRectangle);
                }
            }
            //Ripple
            if (animationManager.IsAnimating())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                for (int i = 0; i < animationManager.GetAnimationCount(); i++)
                {
                    var animationValue = animationManager.GetProgress(i);
                    var animationSource = animationManager.GetSource(i);

                    using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), Color.Black)))
                    {
                        var rippleSize = (int)(animationValue * Width * 2);
                        g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                    }
                }
                g.SmoothingMode = SmoothingMode.None;
            }

            //Icon
            Rectangle iconRect = new Rectangle(8, 6, 24, 24);

            if (String.IsNullOrEmpty(Text))
                // Center Icon
                iconRect.X += 2;

            if (Icon != null)
                g.DrawImage(Icon, iconRect);

            //Text
            Rectangle textRect = ClientRectangle;

            if (Icon != null)
            {
                //
                // Resize and move Text container
                //

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                // Third 8: right padding
                textRect.Width -= 8 + 24 + 4 + 8;

                // First 8: left padding
                // 24: icon width
                // Second 4: space between Icon and Text
                textRect.X += 8 + 24 + 4;
            }

            Color foreColor = Color.Empty;

            if (Raised)
            {
                if (Enabled)
                    foreColor = new Pen(SkinManager.GetRaisedButtonTextBrush(Primary)).Color;
                else
                    foreColor = new Pen((Enabled ? (Primary ? SkinManager.ColorScheme.PrimaryBrush : SkinManager.GetPrimaryTextBrush()) : SkinManager.GetFlatButtonDisabledTextBrush())).Color;
            }
            else
                foreColor = new Pen((Enabled ? (Primary ? SkinManager.ColorScheme.PrimaryBrush : SkinManager.GetPrimaryTextBrush()) : SkinManager.GetFlatButtonDisabledTextBrush())).Color;

            TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
            TextRenderer.DrawText(g, Text, Font, textRect, foreColor, flags);
        }

        private Size GetPreferredSize()
        {
            return GetPreferredSize(new Size(0, 0));
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            // Provides extra space for proper padding for content
            int extra = 16;

            if (Icon != null)
                // 24 is for icon size
                // 4 is for the space between icon & text
                extra += 24 + 4;

            return new Size((int)Math.Ceiling(textSize.Width) + extra, 36);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode) return;

            MouseState = IMatMouseState.OUT;
            MouseEnter += (sender, args) =>
            {
                MouseState = IMatMouseState.HOVER;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            };
            MouseLeave += (sender, args) =>
            {
                MouseState = IMatMouseState.OUT;
                hoverAnimationManager.StartNewAnimation(AnimationDirection.Out);
                Invalidate();
            };
            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                {
                    MouseState = IMatMouseState.DOWN;

                    animationManager.StartNewAnimation(AnimationDirection.In, args.Location);
                    Invalidate();
                }
            };
            MouseUp += (sender, args) =>
            {
                MouseState = IMatMouseState.HOVER;

                Invalidate();
            };
        }
    }
}