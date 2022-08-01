using RSBot.Core;
using RSBot.Core.Components;
using RSBot.General.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RSBot.General.Components
{
    internal class Accounts
    {
        /// <summary>
        /// Gets or sets the saved accounts.
        /// </summary>
        /// <value>
        /// The saved accounts.
        /// </value>
        public static List<Account> SavedAccounts { get; set; }

        /// <summary>
        /// Gets or sets the joined account.
        /// </summary>
        public static Account Joined { get; set; }

        /// <summary>
        /// Get the data file path
        /// </summary>
        private static string _filePath => Path.Combine(Environment.CurrentDirectory, "User", ProfileManager.SelectedProfile, "autologin.data");

        /// <summary>
        /// Check the saving directory
        /// </summary>
        /// <returns></returns>
        private static void CheckDirectory()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public static void Load()
        {
            try
            {
                CheckDirectory();

                SavedAccounts = new List<Account>();

                using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate))
                {
                    if (fileStream.Length == 0)
                        return;

                    // We cant use System.???? namespace serializers because the dlls not in the same directory.
                    // Also we can use other serializers like json, but i think, its dont need. Because small code is enough for us.
                    // But this is not bad ;)
                    using (var reader = new BinaryReader(fileStream))
                    {
                        var length = reader.ReadInt32();
                        for (int i = 0; i < length; i++)
                        {
                            var account = new Account();
                            account.Username = reader.ReadString();
                            account.Password = reader.ReadString();
                            account.SecondaryPassword = reader.ReadString();
                            account.Servername = reader.ReadString();
                            account.SelectedCharacter = reader.ReadString();

                            var charCount = reader.ReadInt32();

                            account.Characters = new List<string>(charCount);

                            for (int j = 0; j < charCount; j++)
                                account.Characters.Add(reader.ReadString());

                            SavedAccounts.Add(account);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Core.Log.NotifyLang("FileNotFound", _filePath);
                Core.Log.Fatal(ex);
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public static void Save()
        {
            CheckDirectory();

            if (SavedAccounts == null) 
                return;

            try
            {
                using (var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate))
                {
                    using (var writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(SavedAccounts.Count);

                        foreach (var account in SavedAccounts)
                        {
                            writer.Write(account.Username);
                            writer.Write(account.Password);
                            writer.Write(account.SecondaryPassword);
                            writer.Write(account.Servername);
                            writer.Write(account.SelectedCharacter);
                            writer.Write(account.Characters.Count);
                            foreach (var character in account.Characters)
                                    writer.Write(character);
                        }
                    }
                }
            }
            catch
            {
                Core.Log.NotifyLang("FileNotFound", _filePath);
            }
        }
    }
}