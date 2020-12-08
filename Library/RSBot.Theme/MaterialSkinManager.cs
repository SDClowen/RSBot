using System.Drawing;

namespace RSBot.Theme
{
    public class MaterialSkinManager
    {
        //Singleton instance
        private static MaterialSkinManager instance;

        public ColorScheme ColorScheme { get; set; }

        //Constant color values
        private static readonly Color PRIMARY_TEXT_BLACK = Color.FromArgb(222, 0, 0, 0);

        private static readonly Brush PRIMARY_TEXT_BLACK_BRUSH = new SolidBrush(PRIMARY_TEXT_BLACK);
        public static Color SECONDARY_TEXT_BLACK = Color.FromArgb(138, 0, 0, 0);
        public static Brush SECONDARY_TEXT_BLACK_BRUSH = new SolidBrush(SECONDARY_TEXT_BLACK);
        private static readonly Color DISABLED_OR_HINT_TEXT_BLACK = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush DISABLED_OR_HINT_TEXT_BLACK_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_BLACK);
        private static readonly Color DIVIDERS_BLACK = Color.FromArgb(31, 0, 0, 0);
        private static readonly Brush DIVIDERS_BLACK_BRUSH = new SolidBrush(DIVIDERS_BLACK);

        private static readonly Color PRIMARY_TEXT_WHITE = Color.FromArgb(255, 255, 255, 255);
        private static readonly Brush PRIMARY_TEXT_WHITE_BRUSH = new SolidBrush(PRIMARY_TEXT_WHITE);
        public static Color SECONDARY_TEXT_WHITE = Color.FromArgb(179, 255, 255, 255);
        public static Brush SECONDARY_TEXT_WHITE_BRUSH = new SolidBrush(SECONDARY_TEXT_WHITE);
        private static readonly Color DISABLED_OR_HINT_TEXT_WHITE = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush DISABLED_OR_HINT_TEXT_WHITE_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_WHITE);
        private static readonly Color DIVIDERS_WHITE = Color.FromArgb(31, 255, 255, 255);
        private static readonly Brush DIVIDERS_WHITE_BRUSH = new SolidBrush(DIVIDERS_WHITE);

        // Checkbox colors
        private static readonly Color CHECKBOX_OFF_LIGHT = Color.FromArgb(138, 0, 0, 0);

        private static readonly Brush CHECKBOX_OFF_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_LIGHT);
        private static readonly Color CHECKBOX_OFF_DISABLED_LIGHT = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush CHECKBOX_OFF_DISABLED_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_LIGHT);

        private static readonly Color CHECKBOX_OFF_DARK = Color.FromArgb(179, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DARK);
        private static readonly Color CHECKBOX_OFF_DISABLED_DARK = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DISABLED_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_DARK);

        //Raised button
        private static readonly Color RAISED_BUTTON_BACKGROUND = Color.FromArgb(255, 255, 255, 255);

        private static readonly Brush RAISED_BUTTON_BACKGROUND_BRUSH = new SolidBrush(RAISED_BUTTON_BACKGROUND);
        private static readonly Color RAISED_BUTTON_TEXT_LIGHT = PRIMARY_TEXT_WHITE;
        private static readonly Brush RAISED_BUTTON_TEXT_LIGHT_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_LIGHT);
        private static readonly Color RAISED_BUTTON_TEXT_DARK = PRIMARY_TEXT_BLACK;
        private static readonly Brush RAISED_BUTTON_TEXT_DARK_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_DARK);

        //Flat button
        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_LIGHT = Color.FromArgb(20.PercentageToColorComponent(), 0x999999.ToColor());

        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_LIGHT);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT = Color.FromArgb(40.PercentageToColorComponent(), 0x999999.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT);
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH = new SolidBrush(Color.DarkGray);

        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_DARK = Color.FromArgb(15.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_DARK = Color.FromArgb(25.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH = new SolidBrush(Color.FromArgb(86, 86, 86));

        //ContextMenuStrip
        private static readonly Brush CMS_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(Color.FromArgb(255, 238, 238, 238));

        private static readonly Brush CMS_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(Color.FromArgb(38, 204, 204, 204));

        //Application background
        private static readonly Color BACKGROUND_LIGHT = Color.FromArgb(255, 255, 255, 255);

        private static Brush BACKGROUND_LIGHT_BRUSH = new SolidBrush(BACKGROUND_LIGHT);

        private static readonly Color BACKGROUND_DARK = Color.FromArgb(255, 51, 51, 51);
        private static Brush BACKGROUND_DARK_BRUSH = new SolidBrush(BACKGROUND_DARK);

        //Application action bar
        public readonly Color ACTION_BAR_TEXT = Color.FromArgb(255, 255, 255, 255);

        public readonly Brush ACTION_BAR_TEXT_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        public readonly Color ACTION_BAR_TEXT_SECONDARY = Color.FromArgb(153, 255, 255, 255);
        public readonly Brush ACTION_BAR_TEXT_SECONDARY_BRUSH = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

        public Color GetPrimaryTextColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? PRIMARY_TEXT_BLACK : PRIMARY_TEXT_WHITE);
        }

        public Brush GetPrimaryTextBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? PRIMARY_TEXT_BLACK_BRUSH : PRIMARY_TEXT_WHITE_BRUSH);
        }

        public Color GetSecondaryTextColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? SECONDARY_TEXT_BLACK : SECONDARY_TEXT_WHITE);
        }

        public Brush GetSecondaryTextBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? SECONDARY_TEXT_BLACK_BRUSH : SECONDARY_TEXT_WHITE_BRUSH);
        }

        public Color GetDisabledOrHintColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK : DISABLED_OR_HINT_TEXT_WHITE);
        }

        public Brush GetDisabledOrHintBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK_BRUSH : DISABLED_OR_HINT_TEXT_WHITE_BRUSH);
        }

        public Color GetDividersColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? DIVIDERS_BLACK : DIVIDERS_WHITE);
        }

        public Brush GetDividersBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? DIVIDERS_BLACK_BRUSH : DIVIDERS_WHITE_BRUSH);
        }

        public Color GetCheckboxOffColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? CHECKBOX_OFF_LIGHT : CHECKBOX_OFF_DARK);
        }

        public Brush GetCheckboxOffBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? CHECKBOX_OFF_LIGHT_BRUSH : CHECKBOX_OFF_DARK_BRUSH);
        }

        public Color GetCheckBoxOffDisabledColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT : CHECKBOX_OFF_DISABLED_DARK);
        }

        public Brush GetCheckBoxOffDisabledBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT_BRUSH : CHECKBOX_OFF_DISABLED_DARK_BRUSH);
        }

        public Brush GetRaisedButtonBackgroundBrush()
        {
            return RAISED_BUTTON_BACKGROUND_BRUSH;
        }

        public Brush GetRaisedButtonTextBrush(bool primary)
        {
            return (primary ? RAISED_BUTTON_TEXT_LIGHT_BRUSH : RAISED_BUTTON_TEXT_DARK_BRUSH);
        }

        public Color GetFlatButtonHoverBackgroundColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT : FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        }

        public Brush GetFlatButtonHoverBackgroundBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public Color GetFlatButtonPressedBackgroundColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT : FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        }

        public Brush GetFlatButtonPressedBackgroundBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH);
        }

        public Brush GetFlatButtonDisabledTextBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH : FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH);
        }

        public Brush GetCmsSelectedItemBrush()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? CMS_BACKGROUND_HOVER_LIGHT_BRUSH : CMS_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public Color GetApplicationBackgroundColor()
        {
            return (ColorScheme.Theme == THEME.LIGHT ? BACKGROUND_LIGHT : BACKGROUND_DARK);
        }

        private MaterialSkinManager()
        {
            ColorScheme = new ColorScheme(Primary.BlueGrey600, Primary.Indigo800, Primary.Blue700, Accent.NewBlue, TextShade.WHITE);
            //ColorScheme = new ColorScheme(Primary.DARK2, Primary.Indigo500, Primary.DARK, Accent.NewBlue, TextShade.WHITE);
        }

        public static MaterialSkinManager Instance => instance ?? (instance = new MaterialSkinManager());
    }
}