using Python.Runtime;
using RSBot.Core;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System.IO;
using System.Windows.Forms;

namespace RSBot.Python.Components.API.Core.Entity
{
    public class ConfigAPI : IPythonPlugin
    {
        private Main _main;
        private string projectDir = Directory.GetParent(Application.StartupPath).FullName;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "config";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }

        private string GetConfigDir()
        {
            return Path.Combine(projectDir, "User");
        }
        private string GetConfigPath()
        {
            if (Game.Player == null)
            {
                return Path.Combine(projectDir, "User", "Default");
            }
            return Path.Combine(projectDir, "User", "Default", $"{Game.Player.Name}.rs");
        }
        private string GetLogDir()
        {
            return Path.Combine(projectDir, "User", "Logs");
        }
        private string GetLogPath()
        {
            if (Game.Player == null)
            {
                return Path.Combine(projectDir, "User", "Logs");
            }
            return Path.Combine(projectDir, "User", "Logs", Game.Player.Name);
        }
        public string get_config_dir()
        {
            return GetConfigDir();
        }
        public string get_config_path()
        {
            return GetConfigPath();
        }
        public string get_log_dir()
        {
            return GetLogDir();
        }
        public string get_log_path()
        {
            return GetLogPath();
        }


    }
}
