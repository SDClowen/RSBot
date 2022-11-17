using SDUI.Controls;
using System;
using System.Reflection;

namespace RSBot.Views
{
    partial class AboutDialog : CleanForm
    {
        public AboutDialog()
        {
            InitializeComponent();
            labelName.Text = Program.AssemblyTitle;
            labelDescription.Text = Program.AssemblyDescription; 
            labelVersion.Text = Program.AssemblyVersion;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
