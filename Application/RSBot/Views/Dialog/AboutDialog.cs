using System;
using SDUI.Controls;

namespace RSBot.Views;

internal partial class AboutDialog : UIWindow
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
