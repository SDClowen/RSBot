using System;
using System.Text;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using SDUI.Controls;

namespace RSBot.Views;

public partial class ConfigDialog : UIWindowBase
{
    public ConfigDialog()
    {
        InitializeComponent();
        Text = "Config";
    }

    private void ExitDialog_Load(object sender, EventArgs e)
    {
        LanguageManager.Translate(this, Kernel.Language);

        var values = GlobalConfig.GetArray<string>("RSBot.Network.Proxy", '|', StringSplitOptions.TrimEntries);
        if (values.Length != 6)
            return;

        try
        {
            bool.TryParse(values[0], out var isActive);
            checkBoxOnOf.Checked = isActive;
            textBoxProxyIp.Text = values[1];

            if (!int.TryParse(values[2], out var proxyPort))
                return;

            textBoxPort.Text = proxyPort.ToString();
            textBoxId.Text = values[3];
            textBoxPw.Text = values[4];

            if (!byte.TryParse(values[5], out var version))
                return;

            comboBoxProxyVersion.SelectedIndex = version == 4 ? 0 : 1;
        }
        catch { }
    }

    private void ConfigDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.Retry)
            e.Cancel = true;
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxProxyIp.Text))
        {
            DialogResult = DialogResult.Retry;
            return;
        }

        if (textBoxPort.Text == "0")
        {
            DialogResult = DialogResult.Retry;
            return;
        }

        StringBuilder builder = new();
        builder.AppendFormat("{0}|", checkBoxOnOf.Checked);
        builder.AppendFormat("{0}|", textBoxProxyIp.Text);
        builder.AppendFormat("{0}|", textBoxPort.Text);
        builder.AppendFormat("{0}|", textBoxId.Text);
        builder.AppendFormat("{0}|", textBoxPw.Text);
        builder.AppendFormat("{0}", comboBoxProxyVersion.SelectedIndex == 0 ? 4 : 5);
        GlobalConfig.Set("RSBot.Network.Proxy", builder.ToString());
    }
}
