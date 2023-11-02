using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using SDUI.Controls;

namespace RSBot.Party.Views;

public partial class AutoFormParty : UIWindowBase
{
    public AutoFormParty()
    {
        InitializeComponent();
    }

    private void AutoFormParty_Load(object sender, EventArgs e)
    {
        cb_AutoReform.Checked = Bundle.Container.PartyMatching.Config.AutoReform;
        cb_AutoAccept.Checked = Bundle.Container.PartyMatching.Config.AutoAccept;
        gbObjective.Controls.OfType<Radio>()
            .FirstOrDefault(p => p.Name == "rbtn_" + Bundle.Container.PartyMatching.Config.Purpose).Checked = true;

        if (Game.Player.Inventory.GetItemAt(8) != null)
        {
            rbtn_Trade.Enabled = Game.Player.JobInformation.Type == JobType.Trade ||
                                 Game.Player.JobInformation.Type == JobType.Hunter;
            rbtn_Trade.Checked = rbtn_Trade.Enabled;

            rbtn_Thief.Enabled = Game.Player.JobInformation.Type == JobType.Thief;
            rbtn_Thief.Checked = rbtn_Thief.Enabled;

            rbtn_Hunting.Enabled = false;
            rbtn_Quest.Enabled = false;
        }
        else if ((byte)Bundle.Container.PartyMatching.Config.Purpose > 1)
        {
            rbtn_Hunting.Checked = true;
        }

        var settingStr = Game.Party.Settings.ToString()
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        label_partytype.Text = settingStr[0];
        label_partytype2.Text = settingStr[1];

        min_level.Value = Bundle.Container.PartyMatching.Config.LevelFrom;
        max_level.Value = Bundle.Container.PartyMatching.Config.LevelTo;

        if (!Game.Party.Settings.ExperienceAutoShare &&
            !Game.Party.Settings.ItemAutoShare)
            tb_Title.Text = "Auto LTP - RSBot";
        else
            tb_Title.Text = Bundle.Container.PartyMatching.Config.Title;
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        Bundle.Container.PartyMatching.Config.Title = tb_Title.Text;
        Bundle.Container.PartyMatching.Config.LevelFrom = (byte)min_level.Value;
        Bundle.Container.PartyMatching.Config.LevelTo = (byte)max_level.Value;
    }

    private void cb_AutoAccept_CheckedChanged(object sender, EventArgs e)
    {
        Bundle.Container.PartyMatching.Config.AutoAccept = cb_AutoAccept.Checked;
    }

    private void cb_AutoReform_CheckedChanged(object sender, EventArgs e)
    {
        Bundle.Container.PartyMatching.Config.AutoReform = cb_AutoReform.Checked;
    }

    private void radioCheckedChanged(object sender, EventArgs e)
    {
        var rbtn = sender as Radio;
        var partyPurpose = (PartyPurpose)(Convert.ToByte(rbtn?.Tag) - 1);

        if (partyPurpose == Bundle.Container.PartyMatching.Config.Purpose)
            return;

        Bundle.Container.PartyMatching.Config.Purpose = partyPurpose;

        if (!Game.Party.Settings.ExperienceAutoShare &&
            !Game.Party.Settings.ItemAutoShare)
        {
            tb_Title.Text = "Auto LTP - RSBot";
        }
        else
        {
            tb_Title.Text = Game.ReferenceManager.GetTranslation("UIIT_MSG_PARTYMATCH_RECORD_DEFAULT" + rbtn?.Tag);

            if (!string.IsNullOrWhiteSpace(tb_Title.Text))
                Bundle.Container.PartyMatching.Config.Title = tb_Title.Text;
        }
    }
}