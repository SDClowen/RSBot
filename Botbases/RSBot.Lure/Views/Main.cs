using System;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Lure.Components;

namespace RSBot.Lure.Views;

[System.ComponentModel.ToolboxItem(false)]
public partial class Main : UserControl
{
    private const int ScriptRecorderOwnerId = 1000;

    private bool _configLocked;

    public Main()
    {
        InitializeComponent();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnSaveScript", new Action<int, string>(OnSaveScript));
    }

    private void OnSaveScript(int ownerId, string path)
    {
        if (IsDisposed || Disposing)
            return;

        if (ownerId != ScriptRecorderOwnerId)
            return;

        radioUseScript.Checked = true;
        txtScriptPath.Text = path;
        LureConfig.SelectedScriptPath = txtScriptPath.Text;
    }

    private void OnLoadCharacter()
    {
        if (IsDisposed || Disposing)
            return;

        checkUseHowlingShout.Enabled = Game.Player.Race == ObjectCountry.Europe;
        checkNoHowlingAtCenter.Enabled = Game.Player.Race == ObjectCountry.Europe;

        LoadConfig();
    }

    private void LoadConfig()
    {
        if (_configLocked)
            return;

        _configLocked = true;

        lblX.Text = LureConfig.Area.Position.X.ToString("0.0");
        lblY.Text = LureConfig.Area.Position.Y.ToString("0.0");
        numRadius.Value = LureConfig.Area.Radius;
        radioUseScript.Checked = LureConfig.UseScript;
        radioWalkRandomly.Checked = LureConfig.WalkRandomly;
        radioStayAtCenter.Checked = LureConfig.StayAtCenter;
        checkStayAtCenter.Checked = LureConfig.StayAtCenterFor;
        numStayAtCenterSeconds.Value = LureConfig.StayAtCenterForSeconds;
        txtScriptPath.Text = LureConfig.SelectedScriptPath;
        checkUseHowlingShout.Checked = LureConfig.UseHowlingShout;
        checkUseNormalAttack.Checked = LureConfig.UseNormalAttack;
        checkStopPartyMemberDead.Checked = LureConfig.StopIfNumPartyMemberDead;
        checkStopMonsterType.Checked = LureConfig.StopIfNumMonsterType;
        checkStopPartyMember.Checked = LureConfig.StopIfNumPartyMember;
        numPartyMemberDead.Value = LureConfig.NumPartyMemberDead;
        numMonsterType.Value = LureConfig.NumMonsterType;
        numPartyMember.Value = LureConfig.NumPartyMember;
        checkNoHowlingAtCenter.Checked = LureConfig.NoHowlingAtCenter;
        checkUseAttackingSkills.Checked = LureConfig.UseAttackingSkills;
        txtWalkbackScript.Text = LureConfig.WalkscriptPath;
        comboMonsterType.SelectedIndex = LureConfig.SelectedMonsterType switch
        {
            MonsterRarity.General => 0,
            MonsterRarity.Champion => 1,
            MonsterRarity.Giant => 2,
            MonsterRarity.GeneralParty => 3,
            MonsterRarity.ChampionParty => 4,
            MonsterRarity.GiantParty => 5,
            MonsterRarity.Elite => 6,
            MonsterRarity.EliteStrong => 7,
            MonsterRarity.Unique => 8,
            MonsterRarity.Event => 9,
            _ => 0
        };

        _configLocked = false;
    }

    private void OnSettingsChanged(object sender, EventArgs e)
    {
        if (_configLocked)
            return;

        _configLocked = true;

        LureConfig.Area = new Area
        {
            Name = "Lure",
            Position = LureConfig.Area.Position,
            Radius = (int)numRadius.Value
        };

        LureConfig.UseNormalAttack = checkUseNormalAttack.Checked;
        LureConfig.UseHowlingShout = checkUseHowlingShout.Checked;
        LureConfig.StopIfNumMonsterType = checkStopMonsterType.Checked;
        LureConfig.StopIfNumPartyMemberDead = checkStopPartyMemberDead.Checked;
        LureConfig.StopIfNumPartyMember = checkStopPartyMember.Checked;
        LureConfig.StayAtCenterFor = checkStayAtCenter.Checked;
        LureConfig.UseScript = radioUseScript.Checked;
        LureConfig.WalkRandomly = radioWalkRandomly.Checked;
        LureConfig.StayAtCenter = radioStayAtCenter.Checked;
        LureConfig.NumMonsterType = (int)numMonsterType.Value;
        LureConfig.NumPartyMember = (int)numPartyMember.Value;
        LureConfig.NumPartyMemberDead = (int)numPartyMemberDead.Value;
        LureConfig.StayAtCenterForSeconds = (int)numStayAtCenterSeconds.Value;
        LureConfig.NoHowlingAtCenter = checkNoHowlingAtCenter.Checked;
        LureConfig.UseAttackingSkills = checkUseAttackingSkills.Checked;

        _configLocked = false;
    }

    private void btnSetCenter_Click(object sender, EventArgs e)
    {
        LureConfig.Area = new Area
        {
            Name = "Lure",
            Position = Game.Player.Position,
            Radius = (int)numRadius.Value
        };

        lblX.Text = LureConfig.Area.Position.X.ToString("0.0");
        lblY.Text = LureConfig.Area.Position.Y.ToString("0.0");
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        var fileBrowser = new OpenFileDialog
            { Title = "RSBot - Choose lure script", Filter = "RSBot script (*.rbs)|*.rbs", Multiselect = false };

        if (fileBrowser.ShowDialog() != DialogResult.OK)
            return;

        radioUseScript.Checked = true;
        txtScriptPath.Text = fileBrowser.FileName;
        LureConfig.SelectedScriptPath = fileBrowser.FileName;
    }

    private void linkRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (!ScriptManager.Running)
            EventManager.FireEvent("OnShowScriptRecorder", ScriptRecorderOwnerId, true);
        else
            MessageBox.Show("Can not record a new script while a script is running! Stop the bot and try again.",
                "Script manager busy",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btnBrowseWalkscript_Click(object sender, EventArgs e)
    {
        var fileBrowser = new OpenFileDialog
            { Title = "RSBot - Choose walkback script", Filter = "RSBot script (*.rbs)|*.rbs", Multiselect = false };

        if (fileBrowser.ShowDialog() != DialogResult.OK)
            return;

        txtWalkbackScript.Text = fileBrowser.FileName;
        LureConfig.WalkscriptPath = fileBrowser.FileName;
    }

    private void comboMonsterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LureConfig.SelectedMonsterType = comboMonsterType.SelectedIndex switch
        {
            0 => MonsterRarity.General,
            1 => MonsterRarity.Champion,
            2 => MonsterRarity.Giant,
            3 => MonsterRarity.GeneralParty,
            4 => MonsterRarity.ChampionParty,
            5 => MonsterRarity.GiantParty,
            6 => MonsterRarity.Elite,
            7 => MonsterRarity.EliteStrong,
            8 => MonsterRarity.Unique,
            9 => MonsterRarity.Event,
            _ => LureConfig.SelectedMonsterType
        };
    }
}