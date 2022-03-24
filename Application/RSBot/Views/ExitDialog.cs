﻿using RSBot.Core;
using RSBot.Theme.Controls;
using System;

namespace RSBot.Views
{
    public partial class ExitDialog : CleanForm
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