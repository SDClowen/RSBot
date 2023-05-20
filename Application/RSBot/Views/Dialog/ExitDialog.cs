﻿using RSBot.Core;
using RSBot.Core.Components;
using SDUI.Controls;
using System;

namespace RSBot.Views
{
    public partial class ExitDialog : UIWindowBase
    {
        public ExitDialog()
        {
            InitializeComponent();
        }

        private void checkDontAskAgain_CheckedChanged(object sender, EventArgs e)
        {
            GlobalConfig.Set("RSBot.showExitDialog", checkDontAskAgain.Checked.ToString());
        }

        private void ExitDialog_Load(object sender, EventArgs e)
        {
            LanguageManager.Translate(this, Kernel.Language);
        }
    }
}