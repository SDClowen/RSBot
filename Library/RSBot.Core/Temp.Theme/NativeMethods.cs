using System;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    public class NativeMethods
    {
        private const string user32 = "user32.dll";
        private const string uxtheme = "uxtheme.dll";
        private const string dwmapi = "dwmapi.dll";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int CS_DROPSHADOW = 0x00020000;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCHITTEST = 0x84;
        public const int HTCAPTION = 0x2;
        public const int HTCLIENT = 0x1;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        [DllImport(user32)]
        public static extern bool ReleaseCapture();

        [DllImport(user32, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport(dwmapi)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport(dwmapi)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport(dwmapi)]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
    }
}
