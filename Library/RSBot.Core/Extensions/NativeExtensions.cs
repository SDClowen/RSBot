using System;
using System.Runtime.InteropServices;

namespace RSBot.Core.Extensions
{
    public static class NativeExtensions
    {
        public const int
            SW_HIDE = 0,
            SW_SHOW = 5;

        [DllImport("User32")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
    }
}