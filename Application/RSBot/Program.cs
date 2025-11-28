using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.General.Components;
using RSBot.General.Models;
using RSBot.Views;

namespace RSBot;

internal static class Program
{
    public static Main MainForm { get; private set; }
    private static string _commandLineSelectAutologinUsername;

    public static string AssemblyTitle = Assembly
        .GetExecutingAssembly()
        .GetCustomAttribute<AssemblyProductAttribute>()
        ?.Product;

    public static string AssemblyVersion =
        $"v{Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}";

    public static string AssemblyDescription = Assembly
        .GetExecutingAssembly()
        .GetCustomAttribute<AssemblyDescriptionAttribute>()
        ?.Description;

    public class CommandLineOptions
    {
        [Option('c', "character", Required = false, HelpText = "Set the character name to use.")]
        public string Character { get; set; }

        [Option('p', "profile", Required = false, HelpText = "Set the profile name to use.")]
        public string Profile { get; set; }

        [Option('l', "listen", Required = false, HelpText = "Enable IPC and listen on the specified pipe name.")]
        public string Listen { get; set; }

        [Option('e', "create-autologin", Required = false, HelpText = "Create a new autologin entry.")]
        public bool CreateAutologinEntry { get; set; }

        [Option("username", Required = false, HelpText = "Username for the autologin entry.")]
        public string Username { get; set; }

        [Option("password", Required = false, HelpText = "Password for the autologin entry.")]
        public string Password { get; set; }

        [Option("secondary-password", Required = false, HelpText = "Secondary password for the autologin entry.")]
        public string SecondaryPassword { get; set; }

        [Option("provider-name", Required = false, HelpText = "Provider name (e.g., Joymax, JCPlanet).")]
        public string ProviderName { get; set; }
        
        [Option("server", Required = false, HelpText = "Server name for the autologin entry.")]
        public string Server { get; set; }

        [Option('a', "select-autologin", Required = false, HelpText = "Select an existing autologin entry by username.")]
        public string SelectAutologin { get; set; }
    }
    private static void DisplayHelp(ParserResult<CommandLineOptions> result)
    {
        var helpText = HelpText.AutoBuild(
            result,
            h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.AddDashesToOption = true;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }
        );
        MessageBox.Show(
            helpText,
            AssemblyTitle + " " + AssemblyVersion,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    [STAThread]
    private static void Main(string[] args)
    {
        var parser = new Parser(with => with.HelpWriter = Console.Out);
        var parserResult = parser.ParseArguments<CommandLineOptions>(args);

        parserResult
            .WithParsed(options =>
            {
                RunOptions(options);
            })
            .WithNotParsed(errs =>
            {
                DisplayHelp(parserResult);
                Environment.Exit(1);
            });

        //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        // We need "." instead of "," while saving float numbers
        // Also client data is "." based float digit numbers
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

        MainForm = new Main();
        SplashScreen splashScreen = new SplashScreen(MainForm);
        splashScreen.ShowDialog();

        if (!string.IsNullOrEmpty(_commandLineSelectAutologinUsername))
        {
            GlobalConfig.Set("RSBot.General.AutoLoginAccountUsername", _commandLineSelectAutologinUsername);
            GlobalConfig.Save();
            Log.Debug($"Autologin entry '{_commandLineSelectAutologinUsername}' applied and saved from command line.");
        }

        Application.Run(MainForm);
    }

    private static void RunOptions(CommandLineOptions options)
    {
        if (!string.IsNullOrEmpty(options.Profile))
        {
            var profile = options.Profile;
            if (ProfileManager.ProfileExists(profile))
                ProfileManager.SetSelectedProfile(profile);
            else
                ProfileManager.Add(profile);

            ProfileManager.IsProfileLoadedByArgs = true;
            Log.Debug($"Selected profile by args: {profile}");
        }

        if (!string.IsNullOrEmpty(options.Character))
        {
            var character = options.Character;
            ProfileManager.SelectedCharacter = character;
            Log.Debug($"Selected character by args: {character}");
        }

        if (options.CreateAutologinEntry)
        {
            if (string.IsNullOrEmpty(options.Username) || string.IsNullOrEmpty(options.Password))
            {
                Log.Error("Username and Password are required to create an autologin entry.");
                Environment.Exit(1);
            }

            // Ensure accounts are loaded before trying to add to them
            Accounts.Load();

            byte channel = 0;
            if (!string.IsNullOrEmpty(options.ProviderName))
            {
                switch (options.ProviderName.ToLowerInvariant())
                {
                    case "joymax":
                        channel = 1;
                        break;
                    case "jcplanet":
                        channel = 2;
                        break;
                    default:
                        Log.Error($"Unrecognized provider name '{options.ProviderName}'. Supported: Joymax, JCPlanet.");
                        Environment.Exit(1);
                        break;
                }
            }
            // Default to Joymax if no provider name is specified, matching UI default behavior.
            if (channel == 0) channel = 1;

            var newAccount = new Account
            {
                Username = options.Username,
                Password = options.Password,
                SecondaryPassword = options.SecondaryPassword,
                Servername = options.Server,
                Channel = channel,
                Characters = new List<string>() // Initialize empty character list
            };

            // Check if an account with the same username already exists
            var existingAccount = Accounts.SavedAccounts.Find(a => a.Username == newAccount.Username);
            if (existingAccount != null)
            {
                Log.Warn($"Autologin entry for username '{newAccount.Username}' already exists. Updating it.");
                Accounts.SavedAccounts.Remove(existingAccount); // Remove old entry
            }

            Accounts.SavedAccounts.Add(newAccount);
            Accounts.Save();
            Log.Debug($"Autologin entry for '{newAccount.Username}' created/updated successfully.");
            Environment.Exit(0); // Exit after creating autologin entry
        }

        if (!string.IsNullOrEmpty(options.Listen))
        {
            IpcManager.Initialize(options.Listen);
        }

        if (!string.IsNullOrEmpty(options.SelectAutologin))
        {
            _commandLineSelectAutologinUsername = options.SelectAutologin;
            Log.Debug($"Autologin entry '{options.SelectAutologin}' marked for selection.");
        }
    }
}
