using RSBot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RSBot.LanguageWizard.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
            LoadTranslationList();
            comboDirectChoice.SelectedIndex = GlobalConfig.Get<int>("RSBot.TranslationIndex", 9);
        }

        #region WinAPI

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        #endregion WinAPI

        private void LoadTranslationList()
        {
            var file = Game.MediaPk2.GetFile("textdata_object.txt");

            var fileText = file.ReadAllLines();

            var cleanLines = new List<string>();

            for (var i = 0; i < 200; i++)
            {
                var line = fileText[i];
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("/") && line.Count(l => l == '\t') > 10)
                    cleanLines.Add(line);
            }

            var tabCount = cleanLines[0].Count(l => l == '\t');
            for (var i = 0; i < tabCount; i++)
            {
                lvValues.Columns.Add(i.ToString());
                comboDirectChoice.Items.Add(i.ToString());
            }

            foreach (var line in cleanLines)
            {
                var split = line.Split('\t');

                var item = new ListViewItem(split[0]);

                foreach (var subItem in split)
                {
                    item.SubItems.Add(subItem);
                }

                lvValues.Items.Add(item);
            }
        }

        /// <summary>
        /// Attempts to find the translation index by an offset in the sro process memory.
        /// Returns the index on success, 0 if the action has failed.
        /// </summary>
        /// <returns></returns>
        private int FindIndex()
        {
            var process = Kernel.ClientProcess;
            if (process == null)
            {
                MessageBox.Show(@"Could not find any running sro_client process. Please start the game and try again.", @"Process missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }

            try
            {
                var processHandle = OpenProcess(0x0010, false, process.Id);
                var bytesRead = 0;
                var buffer = new byte[4];

                ReadProcessMemory((int)processHandle, 0x00EECE80 + 0x0858, buffer, buffer.Length, ref bytesRead);

                var index = BitConverter.ToInt32(buffer, 0);

                return 0x04 + index;
            }
            catch
            {
                MessageBox.Show(
                    @"The attempt to automatically find the translation index has failed!\nPlease set it manually.",
                    @"Attempt failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return 0;
        }

        private void lvValues_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            comboDirectChoice.SelectedIndex = e.Column;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.TranslationIndex", comboDirectChoice.SelectedIndex.ToString());
            GlobalConfig.Save();

            MessageBox.Show(
                $"The new translation index has been set to {comboDirectChoice.SelectedIndex}.\nPlease restart RSBot to apply the changes.",
                @"Translation index saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindKey_Click(object sender, EventArgs e)
        {
            var index = FindIndex();
            if (index == 0) return;

            MessageBox.Show($@"Automatically found the translation index '{index}'.", @"Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            comboDirectChoice.SelectedIndex = index;
        }
    }
}