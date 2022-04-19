using RSBot.Core;
using RSBot.Theme;
using RSBot.Views;
using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.Run(new SplashScreen());
        }
    }
}