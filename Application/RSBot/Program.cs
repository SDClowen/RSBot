using RSBot.Core;
using System.Windows.Forms;
using RSBot.Views;
using System;

namespace RSBot
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            GlobalConfig.Load("config");
            ColorScheme.Load();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}