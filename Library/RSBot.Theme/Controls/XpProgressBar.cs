using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

// Copyright 2004-2005 Marcos Meli - www.MarcosMeli.com.ar
// ReSharper disable All
namespace RSBot.Theme.Controls
{
    #region "  Gradient Mode  "

    public enum GradientMode
    {
        Vertical,
        VerticalCenter,
        Horizontal,
        HorizontalCenter,
        Diagonal
    };

    #endregion "  Gradient Mode  "

    public class XpProgressBar : Control
    {
        #region "  Constructor  "

        private const string CategoryName = "Xp ProgressBar";

        public XpProgressBar()
        { }

        #endregion "  Constructor  "

        #region "  Private Fields  "

        private Color mColor1 = Color.FromArgb(170, 240, 170);

        private Color mColor2 = Color.FromArgb(10, 150, 10);

        private Color mColorBackGround = Color.White;

        private Color mColorText = Color.Black;

        private Image mDobleBack = null;

        private GradientMode mGradientStyle = GradientMode.VerticalCenter;

        private int mMax = 100;

        private int mMin = 0;

        private int mPosition = 50;

        private byte mSteepDistance = 2;

        private byte mSteepWidth = 6;

        #endregion "  Private Fields  "

        #region "  Dispose  "

        protected override void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                mDobleBack?.Dispose();
                mBrush1?.Dispose();
                mPenIn?.Dispose();
                mBrush2?.Dispose();
                mPenOut?.Dispose();
                mPenOut2?.Dispose();
                base.Dispose(disposing);
            }
        }

        #endregion "  Dispose  "

        #region "  Colors   "

        [Category(CategoryName)]
        [Description("The Back Color of the Progress Bar")]
        public Color ColorBackGround
        {
            get { return mColorBackGround; }
            set
            {
                mColorBackGround = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category(CategoryName)]
        [Description("The Border Color of the gradient in the Progress Bar")]
        public Color ColorBarBorder
        {
            get { return mColor1; }
            set
            {
                mColor1 = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category(CategoryName)]
        [Description("The Center Color of the gradient in the Progress Bar")]
        public Color ColorBarCenter
        {
            get { return mColor2; }
            set
            {
                mColor2 = value;
                this.InvalidateBuffer(true);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Set to TRUE to reset all colors like the Windows XP Progress Bar �")]
        [Category(CategoryName)]
        [DefaultValue(false)]
        public bool ColorsXP
        {
            get { return false; }
            set
            {
                ColorBarBorder = Color.FromArgb(170, 240, 170);
                ColorBarCenter = Color.FromArgb(10, 150, 10);
                ColorBackGround = Color.White;
            }
        }

        [Category(CategoryName)]
        [Description("The Color of the text displayed in the Progress Bar")]
        public Color ColorText
        {
            get { return mColorText; }
            set
            {
                mColorText = value;

                if (this.Text != String.Empty)
                {
                    this.Invalidate();
                }
            }
        }

        #endregion "  Colors   "

        #region "  Position   "

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Current Position of the Progress Bar")]
        public int Position
        {
            get { return mPosition; }
            set
            {
                if (value > mMax)
                {
                    mPosition = mMax;
                }
                else if (value < mMin)
                {
                    mPosition = mMin;
                }
                else
                {
                    mPosition = value;
                }
                this.Invalidate();
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Max Position of the Progress Bar")]
        public int PositionMax
        {
            get { return mMax; }
            set
            {
                if (value > mMin)
                {
                    mMax = value;

                    if (mPosition > mMax)
                    {
                        Position = mMax;
                    }

                    this.InvalidateBuffer(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Min Position of the Progress Bar")]
        public int PositionMin
        {
            get { return mMin; }
            set
            {
                if (value < mMax)
                {
                    mMin = value;

                    if (mPosition < mMin)
                    {
                        Position = mMin;
                    }
                    this.InvalidateBuffer(true);
                }
            }
        }

        [Category(CategoryName)]
        [Description("The number of Pixels between two Steeps in Progress Bar")]
        [DefaultValue((byte)2)]
        public byte SteepDistance
        {
            get { return mSteepDistance; }
            set
            {
                if (value >= 0)
                {
                    mSteepDistance = value;
                    this.InvalidateBuffer(true);
                }
            }
        }

        #endregion "  Position   "

        #region "  Progress Style   "

        [Category(CategoryName)]
        [Description("The Style of the gradient bar in Progress Bar")]
        [DefaultValue(GradientMode.VerticalCenter)]
        public GradientMode GradientStyle
        {
            get { return mGradientStyle; }
            set
            {
                if (mGradientStyle != value)
                {
                    mGradientStyle = value;
                    CreatePaintElements();
                    this.Invalidate();
                }
            }
        }

        [Category(CategoryName)]
        [Description("The number of Pixels of the Steeps in Progress Bar")]
        [DefaultValue((byte)6)]
        public byte SteepWidth
        {
            get { return mSteepWidth; }
            set
            {
                if (value > 0)
                {
                    mSteepWidth = value;
                    this.InvalidateBuffer(true);
                }
            }
        }

        #endregion "  Progress Style   "

        #region "  BackImage  "

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                base.BackgroundImage = value;
                InvalidateBuffer();
            }
        }

        #endregion "  BackImage  "

        #region "  Text Override  "

        [Category(CategoryName)]
        [Description("The Text displayed in the Progress Bar")]
        [DefaultValue("")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
        }

        #endregion "  Text Override  "

        #region "  Text Shadow  "

        private bool mTextShadow = true;

        [Category(CategoryName)]
        [Description("Set the Text shadow in the Progress Bar")]
        [DefaultValue(true)]
        public bool TextShadow
        {
            get { return mTextShadow; }
            set
            {
                mTextShadow = value;
                this.Invalidate();
            }
        }

        #endregion "  Text Shadow  "

        #region "  Text Shadow Alpha  "

        private byte mTextShadowAlpha = 150;

        [Category(CategoryName)]
        [Description("Set the Alpha Channel of the Text shadow in the Progress Bar")]
        [DefaultValue((byte)150)]
        public byte TextShadowAlpha
        {
            get { return mTextShadowAlpha; }
            set
            {
                if (mTextShadowAlpha != value)
                {
                    mTextShadowAlpha = value;
                    this.TextShadow = true;
                }
            }
        }

        #endregion "  Text Shadow Alpha  "

        #region "  Paint Methods  "

        #region "  OnPaint  "

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("Paint " + this.CharacterName + "  Pos: "+this.Position.ToString());
                if (!this.IsDisposed)
                {
                    int mSteepTotal = mSteepWidth + mSteepDistance;
                    float mUtilWidth = this.Width - 6 + mSteepDistance;

                    if (mDobleBack == null)
                    {
                        mUtilWidth = this.Width - 6 + mSteepDistance;
                        int mMaxSteeps = (int)(mUtilWidth / mSteepTotal);
                        this.Width = 6 + mSteepTotal * mMaxSteeps;

                        mDobleBack = new Bitmap(this.Width, this.Height);

                        Graphics g2 = Graphics.FromImage(mDobleBack);

                        CreatePaintElements();

                        g2.Clear(mColorBackGround);

                        if (this.BackgroundImage != null)
                        {
                            TextureBrush textuBrush = new TextureBrush(this.BackgroundImage, WrapMode.Tile);
                            g2.FillRectangle(textuBrush, 0, 0, this.Width, this.Height);
                            textuBrush.Dispose();
                        }
                        //				g2.DrawImage()

                        g2.DrawRectangle(mPenOut2, outnnerRect2);
                        g2.Dispose();
                    }

                    if (mDobleBack == null)
                        return;

                    var ima = new Bitmap(mDobleBack);

                    Graphics gtemp = Graphics.FromImage(ima);

                    int mCantSteeps = (int)((((float)mPosition - mMin) / (mMax - mMin)) * mUtilWidth / mSteepTotal);

                    for (int i = 0; i < mCantSteeps; i++)
                        DrawSteep(gtemp, i);

                    if (!string.IsNullOrWhiteSpace(Text))
                        DrawCenterString(gtemp, this.ClientRectangle);

                    e.Graphics.DrawImage(ima, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);

                    ima.Dispose();
                    gtemp.Dispose();
                }
            }
            catch
            {
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #endregion "  OnPaint  "

        #region "  OnSizeChange  "

        protected override Size DefaultSize
        {
            get { return new Size(100, 29); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (this.Height < 12)
                {
                    this.Height = 12;
                }

                base.OnSizeChanged(e);
                this.InvalidateBuffer(true);
            }
        }

        #endregion "  OnSizeChange  "

        #region "  More Draw Methods  "

        private void DisposeBrushes()
        {
            if (mBrush1 != null)
            {
                mBrush1.Dispose();
                mBrush1 = null;
            }

            if (mBrush2 != null)
            {
                mBrush2.Dispose();
                mBrush2 = null;
            }
        }

        private void DrawCenterString(Graphics gfx, Rectangle box)
        {
            gfx.CompositingQuality = CompositingQuality.HighQuality;
            gfx.TextRenderingHint = TextRenderingHint.SystemDefault;
            gfx.SmoothingMode = SmoothingMode.HighQuality;
            SizeF ss = gfx.MeasureString(this.Text, this.Font);

            float left = box.X + (box.Width - ss.Width) / 2;
            float top = box.Y + (box.Height - ss.Height) / 2;

            var shadowColor = Color.Black;
            var textColor = mColorText;
            var valuePercent = Position * 100f / PositionMax;
            if (valuePercent < 50)
            {
                shadowColor = Color.White;
                textColor = Color.Black;
            }
            else
            {
                shadowColor = Color.Black;
                textColor = Color.White;
            }
            if (mTextShadow)
            {
                SolidBrush mShadowBrush = new SolidBrush(Color.FromArgb(mTextShadowAlpha, shadowColor));
                gfx.DrawString(this.Text, this.Font, mShadowBrush, left + 1, top + 1);
                mShadowBrush.Dispose();
            }
            //SolidBrush mTextBrush = new SolidBrush(mColorText);
            SolidBrush mTextBrush = new SolidBrush(textColor);
            gfx.DrawString(this.Text, this.Font, mTextBrush, left, top);
            mTextBrush.Dispose();
        }

        private void DrawSteep(Graphics g, int number)
        {
            g.FillRectangle(mBrush1, 4 + number * (mSteepDistance + mSteepWidth), mSteepRect1.Y + 1, mSteepWidth, mSteepRect1.Height);
            g.FillRectangle(mBrush2, 4 + number * (mSteepDistance + mSteepWidth), mSteepRect2.Y + 1, mSteepWidth, mSteepRect2.Height - 1);
        }

        private void InvalidateBuffer(bool InvalidateControl = false)
        {
            if (mDobleBack != null)
            {
                mDobleBack.Dispose();
                mDobleBack = null;
            }

            if (InvalidateControl)
            {
                this.Invalidate();
            }
        }

        #endregion "  More Draw Methods  "

        #region "  CreatePaintElements   "

        private readonly Pen mPenIn = new Pen(Color.FromArgb(239, 239, 239));
        private readonly Pen mPenOut = new Pen(Color.FromArgb(104, 104, 104));
        private readonly Pen mPenOut2 = new Pen(Color.FromArgb(190, 190, 190));
        private LinearGradientBrush mBrush1;
        private LinearGradientBrush mBrush2;
        private Rectangle mSteepRect1;
        private Rectangle mSteepRect2;
        private Rectangle outnnerRect2;

        private void CreatePaintElements()
        {
            DisposeBrushes();

            switch (mGradientStyle)
            {
                case GradientMode.VerticalCenter:

                    mSteepRect1 = new Rectangle(
                        0,
                        2,
                        mSteepWidth,
                        this.Height / 2 + (int)(this.Height * 0.05));
                    mBrush1 = new LinearGradientBrush(mSteepRect1, mColor1, mColor2, LinearGradientMode.Vertical);

                    mSteepRect2 = new Rectangle(
                        0,
                        mSteepRect1.Bottom - 1,
                        mSteepWidth,
                        this.Height - mSteepRect1.Height - 4);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, mColor2, mColor1, LinearGradientMode.Vertical);
                    break;

                case GradientMode.Vertical:
                    mSteepRect1 = new Rectangle(
                        0,
                        3,
                        mSteepWidth,
                        this.Height - 7);
                    mBrush1 = new LinearGradientBrush(mSteepRect1, mColor1, mColor2, LinearGradientMode.Vertical);
                    mSteepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, mColor2, mColor1, LinearGradientMode.Horizontal);
                    break;

                case GradientMode.Horizontal:
                    mSteepRect1 = new Rectangle(
                        0,
                        3,
                        mSteepWidth,
                        this.Height - 7);

                    //					mBrush1 = new LinearGradientBrush(rTemp, mColor1, mColor2, LinearGradientMode.Horizontal);
                    mBrush1 = new LinearGradientBrush(this.ClientRectangle, mColor1, mColor2, LinearGradientMode.Horizontal);
                    mSteepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;

                case GradientMode.HorizontalCenter:
                    mSteepRect1 = new Rectangle(
                        0,
                        3,
                        mSteepWidth,
                        this.Height - 7);
                    //					mBrush1 = new LinearGradientBrush(rTemp, mColor1, mColor2, LinearGradientMode.Horizontal);
                    mBrush1 = new LinearGradientBrush(this.ClientRectangle, mColor1, mColor2, LinearGradientMode.Horizontal);
                    mBrush1.SetBlendTriangularShape(0.5f);

                    mSteepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;

                case GradientMode.Diagonal:
                    mSteepRect1 = new Rectangle(
                        0,
                        3,
                        mSteepWidth,
                        this.Height - 7);
                    //					mBrush1 = new LinearGradientBrush(rTemp, mColor1, mColor2, LinearGradientMode.ForwardDiagonal);
                    mBrush1 = new LinearGradientBrush(this.ClientRectangle, mColor1, mColor2, LinearGradientMode.ForwardDiagonal);
                    //					((LinearGradientBrush) mBrush1).SetBlendTriangularShape(0.5f);

                    mSteepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;

                default:
                    mBrush1 = new LinearGradientBrush(mSteepRect1, mColor1, mColor2, LinearGradientMode.Vertical);
                    mBrush2 = new LinearGradientBrush(mSteepRect2, mColor2, mColor1, LinearGradientMode.Vertical);
                    break;
            }

            //innerRect = new Rectangle(
            //	this.ClientRectangle.X + 2,
            //	this.ClientRectangle.Y + 2,
            //	this.ClientRectangle.Width - 4,
            //	this.ClientRectangle.Height - 4);
            //outnnerRect = new Rectangle(
            //    this.ClientRectangle.X,
            //    this.ClientRectangle.Y,
            //    this.ClientRectangle.Width - 1,
            //    this.ClientRectangle.Height - 1);
            outnnerRect2 = new Rectangle(
                this.ClientRectangle.X,
                this.ClientRectangle.Y,
                this.ClientRectangle.Width,
                this.ClientRectangle.Height);
        }

        #endregion "  CreatePaintElements   "

        #endregion "  Paint Methods  "
    }
}