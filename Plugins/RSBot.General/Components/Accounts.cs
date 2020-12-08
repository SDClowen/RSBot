using RSBot.General.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        #region Constants

        private const string Filename = "autologin.dat";
        private const string DirectoryName = "\\User\\";
        private const string SavePath = DirectoryName + Filename;
        private const string Key = "bJc9CU3GLkHAUmYV";

        #endregion Constants

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public static void Load()
        {
            SavedAccounts = new List<Account>();

            try
            {
                if (!File.Exists(Environment.CurrentDirectory + SavePath))
                    File.Create(Environment.CurrentDirectory + SavePath).Dispose();

                var fileContent = File.ReadAllText(Environment.CurrentDirectory + SavePath);

                if (fileContent == string.Empty)
                    return;

                fileContent = RijndaelHelper.Decrypt(fileContent, Key);

                foreach (var line in fileContent.Split('\n').Where(line => !string.IsNullOrEmpty(line)))
                {
                    SavedAccounts.Add(new Account
                    {
                        Username = line.Split('\t')[0],
                        Password = line.Split('\t')[1],
                        Servername = line.Split('\t')[2],
                        Characters = line.Split('\t')[3].Split(',')
                    });
                }
            }
            catch
            {
                Core.Log.Notify($"Unable to load [{Filename}] file not found or damaged!");
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public static void Save()
        {
            if (SavedAccounts == null || SavedAccounts.Count == 0) return; //nothing to be saved!
            if (!Directory.Exists(Environment.CurrentDirectory + DirectoryName))
                Directory.CreateDirectory(Environment.CurrentDirectory + DirectoryName);

            var accountString = string.Empty;

            foreach (var account in SavedAccounts)
            {
                accountString += account.Username + "\t" + account.Password + "\t" + account.Servername + "\t";

                if (account.Characters != null) accountString = account.Characters.Aggregate(accountString, (current, character) => current + (character + ","));

                accountString += '\n';
            }

            accountString = RijndaelHelper.Encrypt(accountString, Key);

            File.WriteAllText(Environment.CurrentDirectory + SavePath, accountString);
        }
    }
}