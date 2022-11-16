using RSBot.Core;
using System.Windows.Forms;
using System;
using System.Text;
using RSBot.Core.Extensions;
using RSBot.Core.Components;

namespace RSBot.Views
{
    public partial class ConfigDialog : SDUI.Controls.CleanForm
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

                numUpDownProxyPort.Value = proxyPort;
                textBoxId.Text = values[3];
                textBoxPw.Text = values[4];

                if (!byte.TryParse(values[5], out var version))
                    return;

                comboBoxProxyVersion.SelectedIndex = version == 4 ? 0 : 1;
            }
            catch
            {

            }
        }

        private void ConfigDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxProxyIp.Text))
            {
                DialogResult = DialogResult.Retry;
                return;
            }

            if (numUpDownProxyPort.Value == 0)
            {
                DialogResult = DialogResult.Retry;
                return;
            }

            StringBuilder builder = new();
            builder.AppendFormat("{0}|", checkBoxOnOf.Checked);
            builder.AppendFormat("{0}|", textBoxProxyIp.Text);
            builder.AppendFormat("{0}|", numUpDownProxyPort.Value);
            builder.AppendFormat("{0}|", textBoxId.Text);
            builder.AppendFormat("{0}|", textBoxPw.Text);
            builder.AppendFormat("{0}", comboBoxProxyVersion.SelectedIndex == 0 ? 4 : 5);
            GlobalConfig.Set("RSBot.Network.Proxy", builder.ToString());
        }
    }
}