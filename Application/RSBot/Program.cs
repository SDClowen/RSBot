using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views;
using System;
using System.Windows.Forms;

namespace RSBot
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                var profile = args[0];
                if (ProfileManager.IsExists(profile))
                {
                    ProfileManager.SetSelectedProfile(profile);
                    ProfileManager.IsProfileLoadedByArgs = true;
                    Log.Debug($"Selected profile by args: {profile}");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new SplashScreen());
        }
    }
}