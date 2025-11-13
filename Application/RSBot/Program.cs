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
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-p":
                    if (i + 1 < args.Length)
                    {
                        var profile = args[i + 1];
                        if (ProfileManager.ProfileExists(profile))
                            ProfileManager.SetSelectedProfile(profile);
                        else
                            ProfileManager.Add(profile);

                        ProfileManager.IsProfileLoadedByArgs = true;
                        Log.Debug($"Selected profile by args: {profile}");
                    }
                    break;

                case "-c":
                    if (i + 1 < args.Length)
                    {
                        var character = args[i + 1];
                        ProfileManager.SelectedCharacter = character;
                        Log.Debug($"Selected character by args: {character}");
                    }
                    break;
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
        Application.Run(new SplashScreen());
    }
}