using RSBot.Core;
using System;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class ExitDialog : Form
    {
        public ExitDialog()
        {
            InitializeComponent();
        }

        private void checkDontAskAgain_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.showExitDialog", checkDontAskAgain.Checked.ToString());
        }
    }
}