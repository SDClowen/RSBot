using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace RSBot.Replacer
{
    internal static class Program
    {
        private static void Main()
        {
            var startupPath = Application.StartupPath;
            try
            {
                var tempDirectory = Path.Combine(startupPath, "rsbot_download_temp");
                var zipFilePath = tempDirectory + "\\latest.zip";

                if (Directory.Exists(tempDirectory) && File.Exists(zipFilePath))
                {
                    ZipFile.ExtractToDirectory(zipFilePath, tempDirectory);

                    File.Delete(zipFilePath);
                    CopyDir(tempDirectory, startupPath);
                    Directory.Delete(tempDirectory, true);
                }

                Process.Start(Path.Combine(startupPath, "RSBot.exe"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Environment.Exit(0);
        }

        /// <summary>
        /// Copy directory to destination directory
        /// </summary>
        /// <param name="sourceFolder">The source folder</param>
        /// <param name="destFolder">The Destination folder</param>
        private static void CopyDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            // Get Files & Copy
            var files = Directory.GetFiles(sourceFolder);
            foreach (var file in files)
                File.Copy(file, Path.Combine(destFolder, Path.GetFileName(file)), true);

            // Get dirs recursively and copy files
            var folders = Directory.GetDirectories(sourceFolder);
            foreach (var folder in folders)
                CopyDir(folder, Path.Combine(destFolder, Path.GetFileName(folder)));
        }
    }
}