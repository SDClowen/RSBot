using RSBot.Core;
using RSBot.Core.Components;
using System;
using System.IO;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class SplashScreen : Form
    {
        private readonly Main _mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _mainForm = new Main();

            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            referenceDataLoader.RunWorkerCompleted += ReferenceDataLoaderCompleted;
        }

        /// <summary>
        /// Handles the Load event of the SplashScreen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            using (var updaterDialog = new Updater())
            {
                if (await updaterDialog.Check())
                    updaterDialog.ShowDialog(this);
            }

            GlobalConfig.Load("config");

            if (!GlobalConfig.Exists("RSBot.SilkroadDirectory") || !File.Exists(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2"))
            {
                var diag = new OpenFileDialog
                {
                    Title = @"Please select your silkroad executable in order to continue...",
                    Filter = "Executable (*.exe)|*.exe",
                    FileName = "sro_client.exe"
                };

                var result = diag.ShowDialog();

                var silkroadDirectory = Path.GetDirectoryName(diag.FileName);

                if (result == DialogResult.OK && File.Exists(Path.Combine(silkroadDirectory, "media.pk2")))
                {
                    GlobalConfig.Set("RSBot.SilkroadDirectory", silkroadDirectory);
                    GlobalConfig.Set("RSBot.SilkroadExecutable", Path.GetFileName(diag.FileName));
                }
                else
                {
                    MessageBox.Show(@"Please select a proper Silkroad directory!");
                    Environment.Exit(0);
                }
            }

            InitializeBot();

            referenceDataLoader.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the Initializer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void ReferenceDataLoaderCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _mainForm.Show();
            Hide();

            GlobalConfig.Save();
        }

        /// <summary>
        /// Initializes the bot.
        /// </summary>
        private void InitializeBot()
        {
            //---- Boot kernel -----
            Kernel.Initialize();
            Game.Initialize();

            //---- Load Plugins ----
            if (!Kernel.PluginManager.LoadAssemblies())
            {
                MessageBox.Show(@"Failed to load plugins. Process canceled!", @"Initialize Application - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //---- Load Botbases ----
            if (!Kernel.BotbaseManager.LoadAssemblies())
                MessageBox.Show(@"Failed to load botbases. Process canceled!", @"Initialize Application - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handles the DoWork event of the referenceDataLoader control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void referenceDataLoader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Game.MediaPk2 = CacheController.LoadState(GlobalConfig.Get<string>("RSBot.SilkroadDirectory") + "\\media.pk2");

            if (Game.MediaPk2 == null)
            {
                MessageBox.Show(@"Failed to load game data. Boot process canceled!", @"Initialize Application - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Game.ReferenceManager.Load(GlobalConfig.Get<int>("RSBot.TranslationIndex", 9));
        }
    }
}