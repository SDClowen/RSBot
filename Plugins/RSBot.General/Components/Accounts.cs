using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Network.Protocol;
using RSBot.General.Models;

namespace RSBot.General.Components;

internal class Accounts
{
    /// <summary>
    ///     Gets or sets the saved accounts.
    /// </summary>
    /// <value>
    ///     The saved accounts.
    /// </value>
    public static List<Account> SavedAccounts { get; set; }

    /// <summary>
    ///     Gets or sets the joined account.
    /// </summary>
    public static Account Joined { get; set; }

    /// <summary>
    ///     Get the data file path
    /// </summary>
    private static string _filePath =>
        Path.Combine(Kernel.BasePath, "User", ProfileManager.SelectedProfile, "autologin.data");

    /// <summary>
    ///     Check the saving directory
    /// </summary>
    /// <returns></returns>
    private static void EnsureDirectoryExists()
    {
        var directory = Path.GetDirectoryName(_filePath);

        Directory.CreateDirectory(directory);
    }

    /// <summary>
    ///     Loads this instance.
    /// </summary>
    public static void Load()
    {
        try
        {
            EnsureDirectoryExists();

            SavedAccounts = new List<Account>();

            if (!File.Exists(_filePath))
                return;

            var buffer = File.ReadAllBytes(_filePath);
            if (buffer.Length == 0)
                return;

            //Decode credentials
            var blowfish = new Blowfish();
            buffer = blowfish.Decode(buffer);

            var serialized = Encoding.UTF8.GetString(buffer).Trim('\0');

            SavedAccounts = JsonSerializer.Deserialize<List<Account>>(serialized) ?? new List<Account>(4);
        }
        catch (Exception ex)
        {
            Log.NotifyLang("FileNotFound", _filePath);
            Log.Fatal(ex);
        }
    }

    /// <summary>
    ///     Saves this instance.
    /// </summary>
    public static void Save()
    {
        EnsureDirectoryExists();

        if (SavedAccounts == null)
            return;

        try
        {
            //Encode user credentials
            var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(SavedAccounts));

            //Maybe add some password protection and use blowfish.initialize(password)
            var blowfish = new Blowfish();
            buffer = blowfish.Encode(buffer);

            File.WriteAllBytes(_filePath, buffer);
        }
        catch
        {
            Log.NotifyLang("FileNotFound", _filePath);
        }
    }
}
