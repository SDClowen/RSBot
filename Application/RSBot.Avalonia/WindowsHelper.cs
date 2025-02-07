using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Extensions
{
    internal static class WindowsHelper
    {
        public const int DWMWA_SYSTEMBACKDROP_TYPE = 38;
        public const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public enum DwmSystemBackdropType
        {
            Auto = 0,
            None = 1,
            Mica = 2,
            Acrylic = 3,
            Tabbed = 4
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);
        public static void EnableMica(this Window window)
        {
            var platformHandle = window.TryGetPlatformHandle(); // PlatformHandle'ı al
            if (platformHandle != null && platformHandle.Handle != IntPtr.Zero)
            {
                IntPtr hwnd = platformHandle.Handle; // HWND değerini al

                // Mica efektini etkinleştir
                int micaEffect = (int)DwmSystemBackdropType.Mica;
                DwmSetWindowAttribute(hwnd, DWMWA_SYSTEMBACKDROP_TYPE, ref micaEffect, Marshal.SizeOf(typeof(int)));
            }
        }

        public static void EnableDarkMode(this Window window)
        {
            var platformHandle = window.TryGetPlatformHandle();
            if (platformHandle != null && platformHandle.Handle != IntPtr.Zero)
            {
                IntPtr hwnd = platformHandle.Handle;

                int useDarkMode = 1; // 1: dark mode etkin, 0: light mode
                DwmSetWindowAttribute(hwnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, Marshal.SizeOf(typeof(int)));
            }
        }
    }
}
