using System;
using System.Windows.Forms;
using RSBot.Core;
using SDUI.Controls;

namespace RSBot.General.Views;

public partial class SoundNotificationWindow : UIWindowBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SoundNotificationWindow " /> class.
    /// </summary>
    public SoundNotificationWindow()
    {
        InitializeComponent();
        Text = "Notification Sounds";
    }

    /// <summary>
    ///     Handles the shown event of the form control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    /// <remarks>
    /// Is used instead of "Load" event, because otherwiese the "SDUI" Controls could have the
    /// wrong enable state!
    /// </remarks>
    private void SoundNotificationWindow_Shown(object sender, EventArgs e)
    {
        bool playerLoaded = false;
        if (Game.Player != null && Game.Player.NotificationSounds != null)
        {
            playerLoaded = true;
        }

        lblPlayerMustBeLoggedIn.Visible = !playerLoaded;

        chkUniqueAppearedGeneral.Enabled = playerLoaded;
        txtUniqueAppearedGeneral.Enabled = playerLoaded;
        btnUniqueAppearedGeneral.Enabled = playerLoaded;
        txtRegex.Enabled = playerLoaded;

        chkTigerGirl.Enabled = playerLoaded;
        txtTigerGirl.Enabled = playerLoaded;
        btnTigerGirl.Enabled = playerLoaded;

        chkCerberus.Enabled = playerLoaded;
        txtCerberus.Enabled = playerLoaded;
        btnCerberus.Enabled = playerLoaded;

        chkIvy.Enabled = playerLoaded;
        txtIvy.Enabled = playerLoaded;
        btnIvy.Enabled = playerLoaded;

        chkUruchi.Enabled = playerLoaded;
        txtUruchi.Enabled = playerLoaded;
        btnUruchi.Enabled = playerLoaded;

        chkIsyutaru.Enabled = playerLoaded;
        txtIsyutaru.Enabled = playerLoaded;
        btnIsyutaru.Enabled = playerLoaded;

        chkLordYarkan.Enabled = playerLoaded;
        txtLordYarkan.Enabled = playerLoaded;
        btnLordYarkan.Enabled = playerLoaded;

        chkDemonChaitan.Enabled = playerLoaded;
        txtDemonChaitan.Enabled = playerLoaded;
        btnDemonChaitan.Enabled = playerLoaded;

        chkUniqueInRange.Enabled = playerLoaded;
        txtUniqueInRange.Enabled = playerLoaded;
        btnUniqueInRange.Enabled = playerLoaded;

        btnOK.Enabled = playerLoaded;

        if (false == playerLoaded)
        {
            return;
        }

        Core.Objects.NotificationSounds tmp = Game.Player.NotificationSounds;

        chkUniqueAppearedGeneral.Checked = tmp.PlayUniqueAlarmGeneral;
        txtUniqueAppearedGeneral.Text = tmp.PathUniqueAlarmGeneral;
        txtRegex.Text = tmp.RegexUniqueAlarmGeneral.ToString();

        chkTigerGirl.Checked = tmp.PlayUniqueAlarmTigerGirl;
        txtTigerGirl.Text = tmp.PathUniqueAlarmTigerGirl;

        chkCerberus.Checked = tmp.PlayUniqueAlarmCerberus;
        txtCerberus.Text = tmp.PathUniqueAlarmCerberus;

        chkIvy.Checked = tmp.PlayUniqueAlarmCaptainIvy;
        txtIvy.Text = tmp.PathUniqueAlarmCaptainIvy;

        chkUruchi.Checked = tmp.PlayUniqueAlarmUruchi;
        txtUruchi.Text = tmp.PathUniqueAlarmUruchi;

        chkIsyutaru.Checked = tmp.PlayUniqueAlarmIsyutaru;
        txtIsyutaru.Text = tmp.PathUniqueAlarmIsyutaru;

        chkLordYarkan.Checked = tmp.PlayUniqueAlarmLordYarkan;
        txtLordYarkan.Text = tmp.PathUniqueAlarmLordYarkan;

        chkDemonChaitan.Checked = tmp.PlayUniqueAlarmDemonShaitan;
        txtDemonChaitan.Text = tmp.PathUniqueAlarmDemonShaitan;

        chkUniqueInRange.Checked = tmp.PlayAlarmUniqueInRange;
        txtUniqueInRange.Text = tmp.PathAlarmUniqueInRange;

        UpdateControlState();
    }

    /// <summary>
    ///     Handles the Click event of the btnOK control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnOK_Click(object sender, EventArgs e)
    {
        if (Game.Player != null)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            SaveSettings();
        }
        else
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        Close();
    }

    /// <summary>
    ///     Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = System.Windows.Forms.DialogResult.Cancel;
        Close();
    }

    /// <summary>
    ///     Updates controls
    /// </summary>
    public void UpdateControlState()
    {
        txtUniqueAppearedGeneral.Enabled =
            btnUniqueAppearedGeneral.Enabled =
            txtRegex.Enabled =
                chkUniqueAppearedGeneral.Checked;
        txtUniqueInRange.Enabled = btnUniqueInRange.Enabled = chkUniqueInRange.Checked;

        txtTigerGirl.Enabled = btnTigerGirl.Enabled = chkTigerGirl.Checked;
        txtCerberus.Enabled = btnCerberus.Enabled = chkCerberus.Checked;
        txtIvy.Enabled = btnIvy.Enabled = chkIvy.Checked;
        txtUruchi.Enabled = btnUruchi.Enabled = chkUruchi.Checked;
        txtIsyutaru.Enabled = btnIsyutaru.Enabled = chkIsyutaru.Checked;
        txtLordYarkan.Enabled = btnLordYarkan.Enabled = chkLordYarkan.Checked;
        txtDemonChaitan.Enabled = btnLordYarkan.Enabled = chkLordYarkan.Checked;
        txtDemonChaitan.Enabled = btnDemonChaitan.Enabled = chkDemonChaitan.Checked;
    }

    // Saves settings
    private void SaveSettings()
    {
        if (Game.Player == null || Game.Player.NotificationSounds == null)
        {
            return;
        }

        Core.Objects.NotificationSounds tmp = Game.Player.NotificationSounds;

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmGeneral", txtUniqueAppearedGeneral.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmGeneral", chkUniqueAppearedGeneral.Checked);
        tmp.UpdatePlayerSettings("RSBot.Sounds.RegexUniqueAlarmGeneral", txtRegex.Text);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathAlarmUniqueInRange", txtUniqueInRange.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayAlarmUniqueInRange", chkUniqueInRange.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmTigerGirl", txtTigerGirl.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmTigerGirl", chkTigerGirl.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmCerberus", txtCerberus.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmCerberus", chkCerberus.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmCaptainIvy", txtIvy.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmCaptainIvy", chkIvy.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmUruchi", txtUruchi.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmUruchi", chkUruchi.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmIsyutaru", txtIsyutaru.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmIsyutaru", chkIsyutaru.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmLordYarkan", txtLordYarkan.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmLordYarkan", chkLordYarkan.Checked);

        tmp.UpdatePlayerSettings("RSBot.Sounds.PathUniqueAlarmDemonShaitan", txtDemonChaitan.Text);
        tmp.UpdatePlayerSettings("RSBot.Sounds.PlayUniqueAlarmDemonShaitan", chkDemonChaitan.Checked);
    }

    /// <summary>
    /// Checkbox checkedchanged event
    /// </summary>
    private void Checkbox_CheckedChanged(object sender, EventArgs e)
    {
        UpdateControlState();
    }

    private void btnUniqueAppearedGeneral_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtUniqueAppearedGeneral.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnTigerGirl_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtTigerGirl.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnCerberus_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCerberus.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnIvy_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtIvy.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnUruchi_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtUruchi.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnIsyutaru_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtIsyutaru.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnLordYarkan_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLordYarkan.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnDemonChaitan_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDemonChaitan.Text = openFileDialog.FileName;
            }
        }
    }

    private void btnUniqueInRange_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = ".wav (*.wav)|*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtUniqueInRange.Text = openFileDialog.FileName;
            }
        }
    }
}
