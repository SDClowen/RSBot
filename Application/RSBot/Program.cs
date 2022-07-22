using RSBot.Views;
using System;
using System.Windows.Forms;

namespace RSBot
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] arguments) //TODO: Add config arg to startup?
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new SplashScreen());
        }
    }
}