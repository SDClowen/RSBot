using RSBot.Core;
using System;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class ExitDialog : Form
    {
        #region Properties
        public bool ExitClient { get; private set; }

        #endregion

        public ExitDialog()
        {
            InitializeComponent();
        }

        private void checkDontAskAgain_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.showExitDialog", checkDontAskAgain.Checked.ToString());
        }

        private void checkExitClient_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.exitClient", checkExitClient.Checked.ToString());
            ExitClient = checkExitClient.Checked;
        }

        private void ExitDialog_Load(object sender, EventArgs e)
        {
            checkExitClient.Checked = GlobalConfig.Get<bool>("RSBot.exitClient");
        }
    }
}