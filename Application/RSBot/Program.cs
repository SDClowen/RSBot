using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RSBot
{
    internal static class Program
    { 
        public static string AssemblyTitle =
            Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        public static string AssemblyVersion =
            $"v{Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}";

        public static string AssemblyDescription =
            Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

        [STAThread]
        private static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                var profile = args[0];
                if (ProfileManager.ProfileExists(profile))
                {
                    ProfileManager.SetSelectedProfile(profile);
                    ProfileManager.IsProfileLoadedByArgs = true;
                    Log.Debug($"Selected profile by args: {profile}");
                }
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.Run(new SplashScreen());
        }
    }
}