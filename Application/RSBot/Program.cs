using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Views;

namespace RSBot;

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
        if (args.Length == 1)
        {
            var profile = args[0];
            if (ProfileManager.ProfileExists(profile))
            {
                ProfileManager.SetSelectedProfile(profile);
                ProfileManager.IsProfileLoadedByArgs = true;
                Log.Debug($"Selected profile by args: {profile}");
            }
        }

        //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        // We need "." instead of "," while saving float numbers
        // Also client data is "." based float digit numbers
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

        Main mainForm = new Main();
        SplashScreen splashScreen = new SplashScreen(mainForm);
        splashScreen.ShowDialog();

        Application.Run(mainForm);
    }
}