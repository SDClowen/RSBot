using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Party;
using RSBot.Core.Objects.Skill;
using SDUI;
using SDUI.Controls;
using Button = SDUI.Controls.Button;
using ListViewExtensions = RSBot.Core.Extensions.ListViewExtensions;

namespace RSBot.Party.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private bool _applySettings = true;

    /// <summary>
    ///     The buffing party member list
    /// </summary>
    private List<BuffingPartyMember> _buffings;

    /// <summary>
    ///     The selected buffing group
    /// </summary>
    private ListViewItem _selectedBuffingGroup;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();

        selectedMemberBuffs.SmallImageList = ListViewExtensions.StaticImageList;
        listPartyBuffSkills.SmallImageList = ListViewExtensions.StaticImageList;

        _selectedBuffingGroup = new ListViewItem();
        _buffings = new List<BuffingPartyMember>();
        CheckForIllegalCrossThreadCalls = false;
        cbPartySearchPurpose.SelectedIndex = 0;

        SubscribeEvents();
    }

    /// <summary>
    ///     Translated No Guild Text
    /// </summary>
    private string _noGuildText => LanguageManager.GetLang("NoGuild");

    private string _none => LanguageManager.GetLang("none");

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        EventManager.SubscribeEvent("OnCreatePartyEntry", OnCreatePartyEntry);
        EventManager.SubscribeEvent("OnChangePartyEntry", OnChangePartyEntry);
        EventManager.SubscribeEvent("OnDeletePartyEntry", OnDeletePartyEntry);
        EventManager.SubscribeEvent("OnPartyData", OnPartyData);
        EventManager.SubscribeEvent("OnPartyMemberJoin", new Action<PartyMember>(OnPartyMemberJoin));
        EventManager.SubscribeEvent("OnPartyMemberLeave", new Action<PartyMember>(OnPartyMemberLeave));
        EventManager.SubscribeEvent("OnPartyMemberBanned", new Action<PartyMember>(OnPartyMemberBanned));
        EventManager.SubscribeEvent("OnPartyMemberUpdate", new Action<PartyMember>(OnPartyMemberUpdate));
        EventManager.SubscribeEvent("OnPartyDismiss", OnPartyDismiss);
        EventManager.SubscribeEvent("OnPartyLeaderChange", OnPartyData);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnPartyDismiss);
    }

    /// <summary>
    ///     Add new party member
    /// </summary>
    /// <param name="member"></param>
    public void AddNewPartyMember(PartyMember member)
    {
        if (listParty.Items.ContainsKey(member?.Name))
            return;

        var viewItem = listParty.Items.Add(member.Name, member.Name, 0);
        viewItem.UseItemStyleForSubItems = false;
        viewItem.Tag = member;

        viewItem.SubItems.Add(member.Level.ToString());
        if (string.IsNullOrWhiteSpace(member.Guild))
            viewItem.SubItems.Add(_noGuildText).ForeColor = Color.DarkGray;
        else
            viewItem.SubItems.Add(member.Guild);

        var mastery1 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId1);
        var mastery2 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId2);
        var location = Game.ReferenceManager.GetTranslation(member.Position.Region.ToString());

        var masteryInfo = _none;
        if (mastery1 != null)
            masteryInfo = mastery1.Name;
        if (mastery2 != null)
            masteryInfo += $", {mastery2.Name}";

        viewItem.SubItems.Add(masteryInfo);
        viewItem.SubItems.Add(location);
    }

    /// <summary>
    ///     Load the buffing groups
    /// </summary>
    /// <returns>The groups</returns>
    private string[] LoadBuffingGroups()
    {
        return PlayerConfig.GetArray<string>("RSBot.Party.Buffing.Groups");
    }

    /// <summary>
    ///     Save the buffing groups
    /// </summary>
    private void SaveBuffingGroups()
    {
        PlayerConfig.SetArray(
            "RSBot.Party.Buffing.Groups",
            listViewGroups.Items.Cast<ListViewItem>().Select(p => p.Text)
        );
    }

    /// <summary>
    ///     Get party buffing members from the config
    /// </summary>
    /// <returns>Configured buffed party members</returns>
    private void LoadBuffingMembers()
    {
        var buffingMembers = new List<BuffingPartyMember>();

        var settings = PlayerConfig.Get("RSBot.Party.Buffing", string.Empty);
        var collection = settings.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in collection)
            buffingMembers.Add(new BuffingPartyMember(item));

        _buffings = buffingMembers;
    }

    /// <summary>
    ///     Saves the buffing party members
    /// </summary>
    /// <param name="members"></param>
    private void SaveBuffingPartyMembers()
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in _buffings)
            stringBuilder.Append(item.Serialize());

        PlayerConfig.Set("RSBot.Party.Buffing", stringBuilder.ToString());
        PlayerConfig.Save();

        EventManager.FireEvent("OnPartyBuffSettingsChanged");
    }

    /// <summary>
    ///     Saves the automatic party player list.
    /// </summary>
    private void SaveAutoPartyPlayerList()
    {
        PlayerConfig.SetArray(
            "RSBot.Party.AutoPartyList",
            listAutoParty.Items.OfType<ListViewItem>().Select(p => p.Text).ToArray()
        );

        Bundle.Container.Refresh();
    }

    /// <summary>
    ///     Saves the automatic party player list.
    /// </summary>
    private void SaveCommandPlayersList()
    {
        PlayerConfig.SetArray(
            "RSBot.Party.Commands.PlayersList",
            listCommandPlayers.Items.OfType<ListViewItem>().Select(p => p.Text).ToArray()
        );

        Bundle.Container.Refresh();
    }

    /// <summary>
    ///     Refresh the buffing group members
    /// </summary>
    private void RefreshGroupMembers()
    {
        listViewPartyMembers.Items.Clear();

        foreach (ListViewItem itemGroup in listViewGroups.Items)
        {
            var members = _buffings.FindAll(p => p.Group == itemGroup.Text);

            itemGroup.SubItems[1].Text = members.Count.ToString();

            if (itemGroup.Text == _selectedBuffingGroup.Text)
                foreach (var member in members)
                {
                    var item = listViewPartyMembers.Items.Add(member.Name, member.Name, 0);
                    if (item.Index == 0)
                        item.Selected = true;
                }
        }

        LoadPartyBuffSkills();
    }

    /// <summary>
    ///     Requests the party list.
    /// </summary>
    private void RequestPartyList(byte page = 0)
    {
        Task.Run(() =>
        {
            lvPartyMatching.BeginUpdate();
            lvPartyMatching.Items.Clear();

            var listViewItems = new List<ListViewItem>();
            var currentPage = Bundle.Container.PartyMatching.RequestPartyList(page);

            btnPrev.Enabled = currentPage.Page > 0;
            btnNext.Enabled = currentPage.Page != currentPage.PageCount - 1;
            btnPrev.Tag = currentPage.Page - 1;
            btnNext.Tag = currentPage.Page + 1;

            lbl_partyPageRange.Text = $"{currentPage.Page + 1} / {currentPage.PageCount}";

            foreach (var party in currentPage.Parties)
            {
                var existingEntry = listViewItems.Find(p => p.Name == party.Id.ToString());
                //For a self created party!
                if (existingEntry != null)
                    continue;

                var listItem = new ListViewItem { Text = party.Id.ToString(), Name = party.Id.ToString() };
                listItem.SubItems.Add(party.Race.ToString());
                listItem.SubItems.Add(party.Leader);
                listItem.SubItems.Add(party.Title);
                listItem.SubItems.Add(party.Purpose.ToString());
                listItem.SubItems.Add(party.MemberCount.ToString("#/" + party.Settings.MaxMember));
                listItem.SubItems.Add(party.MinLevel + "~" + party.MaxLevel);

                listItem.ToolTipText = party.Settings.ToString();
                if (
                    party.Leader == Game.Player.Name
                    || party.Leader == Game.Player.JobInformation.Name
                    || Game.Party?.Leader?.Name == party.Leader
                )
                {
                    listItem.Font = new Font(Font, FontStyle.Bold);

                    listItem.BackColor = ControlPaint.Light(ColorScheme.BackColor, .15f);
                    listItem.Font = new Font(Font, FontStyle.Bold);

                    listViewItems.Insert(0, listItem);

                    continue;
                }

                listViewItems.Add(listItem);
            }

            foreach (var item in listViewItems)
                lvPartyMatching.Items.Add(item);

            lvPartyMatching.EndUpdate();
        });
    }

    /// <summary>
    ///     Loads the settings.
    /// </summary>
    private void LoadSettings()
    {
        _applySettings = false;

        Bundle.Container.Refresh();

        checkAutoExpAutoShare.Checked = PlayerConfig.Get<bool>("RSBot.Party.EXPAutoShare", true);
        checkAutoItemAutoShare.Checked = PlayerConfig.Get<bool>("RSBot.Party.ItemAutoShare", true);
        checkAutoAllowInvitations.Checked = PlayerConfig.Get<bool>("RSBot.Party.AllowInvitations", true);
        checkAcceptAtTrainingPlace.Checked = Bundle.Container.AutoParty.Config.OnlyAtTrainingPlace;
        checkInviteAll.Checked = Bundle.Container.AutoParty.Config.InviteAll;
        checkInviteFromList.Checked = Bundle.Container.AutoParty.Config.InviteFromList;
        checkAcceptAll.Checked = Bundle.Container.AutoParty.Config.AcceptAll;
        checkAcceptFromList.Checked = Bundle.Container.AutoParty.Config.AcceptFromList;

        checkBoxLeaveIfMasterNot.Checked = Bundle.Container.AutoParty.Config.LeaveIfMasterNot;
        textBoxLeaveIfMasterNotName.Text = Bundle.Container.AutoParty.Config.LeaveIfMasterNotName;
        textBoxLeaveIfMasterNotName.Enabled = !checkBoxLeaveIfMasterNot.Checked;
        checkBoxFollowMaster.Checked = PlayerConfig.Get("RSBot.Party.AlwaysFollowPartyMaster", false);

        checkAcceptIfBotStopped.Checked = Bundle.Container.AutoParty.Config.AcceptIfBotIsStopped;
        checkBoxListenMasterCommands.Checked = Bundle.Container.Commands.Config.ListenOnlyMaster;
        checkBoxListenCommandsOnlyList.Checked = Bundle.Container.Commands.Config.ListenFromList;

        var autoPartyList = PlayerConfig.GetArray<string>("RSBot.Party.AutoPartyList");
        foreach (var item in autoPartyList)
            listAutoParty.Items.Add(item);

        var playerList = PlayerConfig.GetArray<string>("RSBot.Party.Commands.PlayersList");
        foreach (var item in playerList)
            listCommandPlayers.Items.Add(item);

        _applySettings = true;
    }

    /// <summary>
    ///     This event will fire as soon as character loaded
    /// </summary>
    private void OnLoadCharacter()
    {
        listViewGroups.Items.Clear();

        var selectedGroup = PlayerConfig.Get("RSBot.Party.Buffing.SelectedGroup", "Default");

        LoadBuffingMembers();
        var groups = LoadBuffingGroups();
        if (groups.Length == 0)
        {
            var item = listViewGroups.Items.Add("Default", "Default", 0);
            item.SubItems.Add("0");
            item.Selected = true;
            _selectedBuffingGroup = item;

            SaveBuffingGroups();
        }
        else
        {
            foreach (var group in groups)
            {
                var item = listViewGroups.Items.Add(group, group, 0);
                item.SubItems.Add("0");

                if (group == selectedGroup)
                {
                    item.Selected = true;
                    _selectedBuffingGroup = item;
                }
            }
        }

        RefreshGroupMembers();
    }

    private async void OnEnterGame()
    {
        await Task.Delay(5000);

        if (
            Game.Ready
            && Bundle.Container.PartyMatching.Config.AutoReform
            && !Bundle.Container.PartyMatching.HasMatchingEntry
        )
            Bundle.Container.PartyMatching.Create();
    }

    /// <summary>
    ///     Load party related buffs
    /// </summary>
    /// <summary>
    ///     Loads the skills.
    /// </summary>
    private void LoadPartyBuffSkills()
    {
        Log.Notify("Refreshing party buff skills");

        if (Game.Player == null)
            return;

        listPartyBuffSkills.BeginUpdate();
        listPartyBuffSkills.Items.Clear();
        listPartyBuffSkills.Groups.Clear();

        foreach (var mastery in Game.Player.Skills.Masteries)
        {
            var group = new ListViewGroup(
                Game.ReferenceManager.GetTranslation(mastery.Record.NameCode) + " (lv. " + mastery.Level + ")"
            );
            group.Tag = mastery.Id;
            listPartyBuffSkills.Groups.Add(group);
        }

        var skills = Game.Player.Skills.KnownSkills.Where(s =>
            s.Enabled && s.Record.TargetGroup_Party && !s.Record.TargetEtc_SelectDeadBody
        );

        List<string> additionalGroups =
        [
            "SKILL_EU_BARD_SPEEDUPA_MSPEED_A", //Moving March
            "SKILL_EU_BARD_SPEEDUPA_MSPEED_B", //Swing March
            "SKILL_EU_CLERIC_SAINTA_ABNORMAL_B", //Holy Spell
            "SKILL_EU_CLERIC_SAINTA_ABNORMAL_B_1", //God's Spell
        ];

        var additionalSkills = Game.Player.Skills.KnownSkills.Where(s =>
            s.Enabled && additionalGroups.Contains(s.Record.Basic_Group)
        );

        IEnumerable<SkillInfo> partyBuffSkills = skills.Union(additionalSkills);

        foreach (var skill in partyBuffSkills)
        {
            if (skill.IsPassive)
                continue;

            if (checkHideLowerLevelSkills.Checked && skill.IsLowLevel())
                continue;

            var limit = 0;
            var paramIndex = skill.Record.Params.FindIndex(p => p == 1819175795);

            if (paramIndex != -1)
                limit = skill.Record.Params[paramIndex + 3];

            var count = _buffings.Count(p => p.Group == _selectedBuffingGroup.Text && p.Buffs.Any(v => v == skill.Id));

            var item = new ListViewItem($"{skill.Record.GetRealName()}");
            item.Tag = skill;

            var subItem = item.SubItems.Add(limit != 0 ? $"{limit - count}" : "No limit");
            item.UseItemStyleForSubItems = false;

            if (limit == 0)
                subItem.ForeColor = Color.DarkGreen;
            else
                subItem.ForeColor = Color.DarkRed;

            subItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

            foreach (
                var group in listPartyBuffSkills
                    .Groups.Cast<ListViewGroup>()
                    .Where(group => Convert.ToInt32(group.Tag) == skill.Record.ReqCommon_Mastery1)
            )
                item.Group = group;

            listPartyBuffSkills.Items.Add(item);

            item.LoadSkillImageAsync();
        }

        listPartyBuffSkills.EndUpdate();
    }

    /// <summary>
    ///     Displays the party members.
    /// </summary>
    public void OnPartyData()
    {
        listParty.BeginUpdate();
        try
        {
            listParty.Items.Clear();

            if (Game.Party.Members == null)
            {
                listParty.EndUpdate();
                OnPartyDismiss();
                return;
            }

            foreach (
                var member in Game.Party.Members.FindAll(p =>
                    p.Name != Game.Player.Name || p.Name != Game.Player.JobInformation.Name
                )
            )
                AddNewPartyMember(member);

            menuBanish.Enabled = Game.Party.IsLeader;

            //Update other UI components
            lblLeader.Text = Game.Party.Leader.Name;
            btnJoinFormedParty.Enabled = false;
            btnPartyMatchForm.Enabled = false;

            _applySettings = false;
            checkCurrentAllowInvitations.Checked = Game.Party.Settings.AllowInvitation;
            checkCurrentAutoShareEXP.Checked = Game.Party.Settings.ExperienceAutoShare;
            checkCurrentAutoShareItems.Checked = Game.Party.Settings.ItemAutoShare;
            _applySettings = true;

            btnLeaveParty.Enabled = true;
            menuLeave.Enabled = true;
        }
        catch { }

        listParty.EndUpdate();
    }

    private void OnChangePartyEntry()
    {
        Log.NotifyLang("FormedPartyChanged", Bundle.Container.PartyMatching.Id);

        if (tabMain.SelectedTab == tpPartyMatching)
            RequestPartyList();
    }

    private void OnDeletePartyEntry()
    {
        if (
            tabMain.SelectedTab == tpPartyMatching
            && lvPartyMatching.Items.Count > 0
            && lvPartyMatching.Items[0].Name == Bundle.Container.PartyMatching.Id.ToString()
        )
            lvPartyMatching.Items.Remove(lvPartyMatching.Items[0]);

        Bundle.Container.PartyMatching.Id = 0;

        btnPartyMatchForm.Enabled = true;
        btnPartyMatchChangeEntry.Enabled = false;
        btnPartyMatchDeleteEntry.Enabled = false;
        btnJoinFormedParty.Enabled = true;
        grbAutoPartySettings.Enabled = true;

        if (Game.Ready && Bundle.Container.PartyMatching.Config.AutoReform)
            Bundle.Container.PartyMatching.Create();
    }

    private void OnCreatePartyEntry()
    {
        Log.NotifyLang("FormedPartyEntry", Bundle.Container.PartyMatching.Id);

        btnPartyMatchChangeEntry.Enabled = true;
        btnPartyMatchDeleteEntry.Enabled = true;
        btnPartyMatchForm.Enabled = false;
        btnJoinFormedParty.Enabled = false;
        grbAutoPartySettings.Enabled = false;

        _applySettings = false;
        checkCurrentAllowInvitations.Checked = Game.Party.Settings.AllowInvitation;
        checkCurrentAutoShareEXP.Checked = Game.Party.Settings.ExperienceAutoShare;
        checkCurrentAutoShareItems.Checked = Game.Party.Settings.ItemAutoShare;
        _applySettings = true;

        if (tabMain.SelectedTab == tpPartyMatching)
            RequestPartyList();
    }

    private void OnPartyMemberJoin(PartyMember member)
    {
        Log.NotifyLang("UserJoinedParty", member.Name);
        AddNewPartyMember(member);
    }

    private void OnPartyMemberLeave(PartyMember member)
    {
        Log.NotifyLang("UserLeftParty", member.Name);

        listParty.Items.RemoveByKey(member.Name);

        if (Bundle.Container.PartyMatching.Config.AutoReform)
            if (
                Game.Party != null
                && !Bundle.Container.PartyMatching.HasMatchingEntry
                && Game.Party.Members?.Count < Game.Party.Settings.MaxMember
            )
                Bundle.Container.PartyMatching.Create();
    }

    private void OnPartyMemberBanned(PartyMember member)
    {
        Log.NotifyLang("UserBannedParty", member.Name);

        if (member.Name != Game.Player.Name)
        {
            listParty.Items.RemoveByKey(member.Name);

            if (Bundle.Container.PartyMatching.Config.AutoReform)
                if (
                    Game.Party != null
                    && !Bundle.Container.PartyMatching.HasMatchingEntry
                    && Game.Party.Members?.Count < Game.Party.Settings.MaxMember
                )
                    Bundle.Container.PartyMatching.Create();
        }
        else
            OnPartyDismiss();
    }

    /// <summary>
    ///     Called when [party member update].
    /// </summary>
    /// <param name="member">The member.</param>
    private void OnPartyMemberUpdate(PartyMember member)
    {
        if (!listParty.Items.ContainsKey(member.Name))
            return;

        var lvItem = listParty.Items[member.Name];

        lvItem.Text = member.Name;
        lvItem.SubItems[1].Text = member.Level.ToString();
        if (string.IsNullOrWhiteSpace(member.Guild))
        {
            lvItem.SubItems[2].Text = _noGuildText;
            lvItem.SubItems[2].ForeColor = Color.DarkGray;
        }
        else
        {
            lvItem.SubItems[2].Text = member.Guild;
            lvItem.SubItems[2].ResetStyle();
        }

        var mastery1 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId1);
        var mastery2 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId2);
        var location = Game.ReferenceManager.GetTranslation(member.Position.Region.ToString());

        var masteryInfo = _none;
        if (mastery1 != null)
            masteryInfo = mastery1.Name;
        if (mastery2 != null)
            masteryInfo += $", {mastery2.Name}";

        lvItem.SubItems[3].Text = masteryInfo;
        lvItem.SubItems[4].Text = location;
    }

    /// <summary>
    ///     Clear party
    /// </summary>
    public void OnPartyDismiss()
    {
        if (!Game.Ready)
            return;

        Bundle.Container.PartyMatching.HasMatchingEntry = false;
        btnLeaveParty.Enabled = false;
        menuLeave.Enabled = false;
        lblLeader.Text = LanguageManager.GetLang("NotInParty");
        listParty.Items.Clear();
        Log.NotifyLang("PartyDismissed");
        OnDeletePartyEntry();
    }

    /// <summary>
    ///     Handles the Click event of the btnLeaveParty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void btnLeaveParty_Click(object sender, EventArgs e)
    {
        Game.Party.Leave();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void checkSettings_CheckedChanged(object sender, EventArgs e)
    {
        if (!_applySettings)
            return;

        PlayerConfig.Set("RSBot.Party.EXPAutoShare", checkAutoExpAutoShare.Checked);
        PlayerConfig.Set("RSBot.Party.ItemAutoShare", checkAutoItemAutoShare.Checked);
        PlayerConfig.Set("RSBot.Party.AllowInvitations", checkAutoAllowInvitations.Checked);

        Bundle.Container.AutoParty.Refresh();
    }

    /// <summary>
    ///     Handles the Click event of the menuBanish control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void menuBanish_Click(object sender, EventArgs e)
    {
        if (listParty.SelectedItems.Count == 1 && Game.Party.IsLeader)
            Game.Party.GetMemberByName(listParty.SelectedItems[0].Text)?.Banish();
    }

    /// <summary>
    ///     Handles the Click event of the btnAddToAutoParty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void btnAddToAutoParty_Click(object sender, EventArgs e)
    {
        var dialog = new InputDialog(
            "Input",
            LanguageManager.GetLang("CharName"),
            LanguageManager.GetLang("EnterCharNameForPartyList")
        );

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        listAutoParty.Items.Add(dialog.Value.ToString());
        SaveAutoPartyPlayerList();
    }

    /// <summary>
    ///     Handles the Click event of the btnRemoveFromAutoParty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void btnRemoveFromAutoParty_Click(object sender, EventArgs e)
    {
        if (listAutoParty.SelectedIndices.Count == 0)
            return;

        listAutoParty.Items.RemoveAt(listAutoParty.SelectedIndices[0]);

        SaveAutoPartyPlayerList();
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkAutoPartySetting control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void checkAutoPartySetting_CheckedChanged(object sender, EventArgs e)
    {
        if (!_applySettings)
            return;

        PlayerConfig.Set("RSBot.Party.AcceptAll", checkAcceptAll.Checked);
        PlayerConfig.Set("RSBot.Party.AcceptList", checkAcceptFromList.Checked);
        PlayerConfig.Set("RSBot.Party.InviteAll", checkInviteAll.Checked);
        PlayerConfig.Set("RSBot.Party.InviteList", checkInviteFromList.Checked);
        PlayerConfig.Set("RSBot.Party.AtTrainingPlace", checkAcceptAtTrainingPlace.Checked);
        PlayerConfig.Set("RSBot.Party.AcceptIfBotStopped", checkAcceptIfBotStopped.Checked);
        PlayerConfig.Set("RSBot.Party.LeaveIfMasterNot", checkBoxLeaveIfMasterNot.Checked);
        PlayerConfig.Set("RSBot.Party.LeaveIfMasterNotName", textBoxLeaveIfMasterNotName.Text);

        textBoxLeaveIfMasterNotName.Enabled = !checkBoxLeaveIfMasterNot.Checked;

        PlayerConfig.Set("RSBot.Party.Commands.ListenFromMaster", checkBoxListenMasterCommands.Checked);
        PlayerConfig.Set("RSBot.Party.Commands.ListenOnlyList", checkBoxListenCommandsOnlyList.Checked);

        Bundle.Container.Refresh();
    }

    /// <summary>
    ///     Handles the Click event of the ctxJoinParty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void btnJoinFormedParty_Click(object sender, EventArgs e)
    {
        if (lvPartyMatching.SelectedItems.Count != 1)
            return;

        var partyNumber = Convert.ToUInt32(lvPartyMatching.SelectedItems[0].Text);

        Log.NotifyLang("JoinFormedParty", partyNumber);

        Task.Run(() =>
        {
            btnJoinFormedParty.Enabled = false;
            btnJoinFormedParty.Text = LanguageManager.GetLang("Joining");

            var joiningResult = Bundle.Container.PartyMatching.Join(partyNumber);
            if (joiningResult)
                RequestPartyList();

            btnJoinFormedParty.Text = LanguageManager.GetLang("JoinParty");
            btnJoinFormedParty.Enabled = !joiningResult;
        });
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the tpPartyMatching page.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabMain.SelectedTab == tpPartyMatching)
            RequestPartyList();
    }

    /// <summary>
    ///     Handles the Click event of the btnPartyMatchForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnPartyMatchForm_Click(object sender, EventArgs e)
    {
        var senderName = (sender as Button).Name;

        View.PartyWindow.Text =
            senderName == nameof(btnPartyMatchForm)
                ? LanguageManager.GetLang("FormingParty")
                : LanguageManager.GetLang("ChangeEntry");

        if (View.PartyWindow.ShowDialog() == DialogResult.OK)
        {
            if (senderName == nameof(btnPartyMatchForm))
                Bundle.Container.PartyMatching.Create();
            else
                Bundle.Container.PartyMatching.Change();
        }
    }

    private void PageNatigateBtn_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        btn.Enabled = false;

        RequestPartyList(Convert.ToByte(btn.Tag));
    }

    private void btnPartyMatchDeleteEntry_Click(object sender, EventArgs e)
    {
        Bundle.Container.PartyMatching.Config.AutoReform = false;
        Bundle.Container.PartyMatching.Delete();
    }

    private void btnPartyRefresh_Click(object sender, EventArgs e)
    {
        RequestPartyList(Convert.ToByte(lbl_partyPageRange.Tag));
    }

    private void btnPartySearch_Click(object sender, EventArgs e)
    {
        var lvItems = lvPartyMatching.Items.Cast<ListViewItem>().ToList();

        var selectedPurpose = cbPartySearchPurpose.SelectedItem.ToString();

        if (selectedPurpose != "All")
            lvItems.RemoveAll(p => p.SubItems[4].Text != selectedPurpose);

        if (!string.IsNullOrWhiteSpace(tbPartySearchName.Text))
            //No case sensitivity
            lvItems.RemoveAll(p =>
                !p.SubItems[2].Text.ToLowerInvariant().Contains(tbPartySearchName.Text.ToLowerInvariant())
            );

        if (nudPartySearchMin.Value > 1 || nudPartySearchMax.Value < 140)
        {
            lvItems.RemoveAll(p => p.SubItems[6].Text != nudPartySearchMin.Value + "~" + nudPartySearchMax.Value);

            if (selectedPurpose != "All")
                lvItems.RemoveAll(p => p.SubItems[4].Text != selectedPurpose);
        }

        if (lvItems?.Count() > 0 && lvItems?.Count() != lvPartyMatching.Items.Count)
        {
            lvPartyMatching.Items.Clear();

            lvPartyMatching.Items.AddRange(lvItems.ToArray());
        }
    }

    private void checkHideLowerLevelSkills_CheckedChanged(object sender, EventArgs e)
    {
        LoadPartyBuffSkills();
        PlayerConfig.Set("RSBot.Party.Buffing.HideLowerLevelSkills", checkHideLowerLevelSkills.Checked);
    }

    private void listViewGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (
            listViewGroups.SelectedIndices.Count == 0
            || listViewGroups.SelectedIndices[0] == _selectedBuffingGroup.Index
        )
            return;

        _selectedBuffingGroup = listViewGroups.SelectedItems[0];

        PlayerConfig.Set("RSBot.Party.Buffing.SelectedGroup", _selectedBuffingGroup.Text);
        RefreshGroupMembers();
    }

    private void listViewPartyMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listViewPartyMembers.SelectedItems.Count == 0)
            return;

        selectedMemberBuffs.Items.Clear();

        var name = listViewPartyMembers.SelectedItems[0].Text;
        var member = _buffings.Find(p => p.Name == name);
        if (member == null)
            return;

        foreach (var skillId in member.Buffs)
        {
            var listViewItemOfMainList = listPartyBuffSkills
                .Items.Cast<ListViewItem>()
                .FirstOrDefault(p => ((SkillInfo)p.Tag).Id == skillId);
            if (listViewItemOfMainList == null)
                continue;

            var clone = (ListViewItem)listViewItemOfMainList.Clone();
            clone.SubItems.RemoveAt(1);
            selectedMemberBuffs.Items.Add(clone);
        }
    }

    private void btnAddBuffToMember_Click(object sender, EventArgs e)
    {
        if (listViewPartyMembers.SelectedItems.Count == 0)
            return;

        if (listPartyBuffSkills.SelectedItems.Count == 0)
            return;

        var memberName = listViewPartyMembers.SelectedItems[0].Text;

        var buffingMember = _buffings.Find(p => p.Name == memberName);
        if (buffingMember == null)
            return;

        foreach (ListViewItem viewItem in listPartyBuffSkills.SelectedItems)
        {
            var skill = viewItem.Tag as SkillInfo;
            if (skill == null)
                continue;

            // TODO: Some buffs have Action_Overlap = 0. When filtering only by indirect criteria, such as Action_Overlap,
            // there are situations when the buff is not added, because another buff is detected as this buff (Physical Screen = Morale Screen).
            // We need to find an attribute that allows us to accurately determine the inheritance of buffs from another books (Body Deity -> Angel's Body).
            // As a temporary solution, we are filtering only the skills of one group, but in this case,
            // buffs from different books/series are not considered inheritable.
            if (
                buffingMember.Buffs.Any(id =>
                    id == skill.Id
                    || (
                        Game.ReferenceManager.SkillData.TryGetValue(id, out var refSkill)
                        && refSkill.Action_Overlap == skill.Record.Action_Overlap
                        && refSkill.Basic_Group.StartsWith(skill.Record.Basic_Group)
                    )
                )
            )
                continue;

            buffingMember.Buffs.Add(skill.Id);

            var buffItem = (ListViewItem)viewItem.Clone();
            buffItem.SubItems.RemoveAt(1);
            selectedMemberBuffs.Items.Add(buffItem);

            var subItem = viewItem.SubItems[1];
            if (int.TryParse(subItem.Text, out var limit))
                subItem.Text = (limit - 1).ToString();
        }

        SaveBuffingPartyMembers();
    }

    private void btnRemoveBuffFromMember_Click(object sender, EventArgs e)
    {
        if (listViewPartyMembers.SelectedItems.Count == 0)
            return;

        if (selectedMemberBuffs.SelectedItems.Count == 0)
            return;

        var memberName = listViewPartyMembers.SelectedItems[0].Text;

        var buffingMember = _buffings.FirstOrDefault(p => p.Name == memberName);
        if (buffingMember == null)
            return;

        foreach (ListViewItem viewItem in selectedMemberBuffs.SelectedItems)
        {
            var skill = viewItem.Tag as SkillInfo;
            if (skill == null)
                continue;

            buffingMember.Buffs.Remove(skill.Id);
            viewItem.Remove();

            var mainItem = listPartyBuffSkills.Items.Cast<ListViewItem>().FirstOrDefault(p => p.Tag == skill);
            if (mainItem == null)
                continue;

            var subItem = mainItem.SubItems[1];
            if (int.TryParse(subItem.Text, out var limit))
                subItem.Text = (limit + 1).ToString();
        }

        SaveBuffingPartyMembers();
    }

    private void menuItemAddToBuffing_Click(object sender, EventArgs e)
    {
        if (listParty.SelectedItems.Count == 0)
            return;

        var partyMember = listParty.SelectedItems[0].Tag as PartyMember;
        if (partyMember == null)
            return;

        if (partyMember.Name == Game.Player.Name)
            return;

        var dialogTitle = LanguageManager.GetLang("SelectGroup", partyMember.Name);
        var dialogDesc = LanguageManager.GetLang("SelectGroupDesc");
        var dialog = new InputDialog(dialogTitle, dialogTitle, dialogDesc, InputDialog.InputType.Combobox);

        var groups = listViewGroups.Items.Cast<ListViewItem>().Select(p => p.Text).ToArray();

        dialog.Selector.Items.AddRange(groups);

        dialog.Selector.SelectedIndex = 0;

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            var dialogValue = dialog.Value.ToString();

            if (_buffings.Any(p => p.Group == dialogValue && p.Name == partyMember.Name))
            {
                MessageBox.Show(LanguageManager.GetLang("MsgBoxGroupAlreadyIn", partyMember.Name));
                return;
            }

            _buffings.Add(new BuffingPartyMember { Name = partyMember.Name, Group = dialogValue });

            if (dialogValue == _selectedBuffingGroup.Text)
                RefreshGroupMembers();

            SaveBuffingPartyMembers();

            MessageBox.Show(LanguageManager.GetLang("SuccessAddedBuffing"));
        }
    }

    private void menuItemRefreshBuffs_Click(object sender, EventArgs e)
    {
        LoadPartyBuffSkills();
    }

    private void buttonAddGroup_Click(object sender, EventArgs e)
    {
        var title = LanguageManager.GetLang("CreateNewGroup");
        var desc = LanguageManager.GetLang("CreateNewGroupDesc");

        var dialog = new InputDialog(title, title, desc);
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            var value = dialog.Value.ToString();
            var item = listViewGroups.Items.Add(value, value, 0);
            item.SubItems.Add("0");
            item.Selected = true;

            SaveBuffingGroups();
        }
    }

    private void buttonRemoveGroup_Click(object sender, EventArgs e)
    {
        if (listViewGroups.SelectedItems.Count == 0)
            return;

        var selectedItem = listViewGroups.SelectedItems[0];
        var group = selectedItem.Text;

        var count = _buffings.Count(p => p.Group == group);
        if (count == 0)
        {
            selectedItem.Remove();

            SaveBuffingGroups();

            return;
        }

        if (
            MessageBox.Show(this, LanguageManager.GetLang("GroupDeleteWarn", count), "Warning", MessageBoxButtons.YesNo)
            == DialogResult.Yes
        )
        {
            if (group != "Default")
                selectedItem.Remove();

            var affected = _buffings.RemoveAll(p => p.Group == group) > 0;

            SaveBuffingGroups();
            SaveBuffingPartyMembers();

            if (affected)
                LoadPartyBuffSkills();
        }
    }

    private void buttonRemoveCharFromBuffing_Click(object sender, EventArgs e)
    {
        if (listViewPartyMembers.SelectedItems.Count == 0)
            return;

        if (
            MessageBox.Show(this, LanguageManager.GetLang("GroupCharDeleteWarn"), "Warning", MessageBoxButtons.YesNo)
            == DialogResult.Yes
        )
        {
            var selectedItem = listViewPartyMembers.SelectedItems[0];
            var name = selectedItem.Text;

            var affected = _buffings.RemoveAll(p => p.Name == name);
            if (affected > 0)
            {
                selectedItem.Remove();
                RefreshGroupMembers();
                SaveBuffingPartyMembers();
                LoadPartyBuffSkills();
            }
        }
    }

    private void buttonAddCharToBuffing_Click(object sender, EventArgs e)
    {
        var diag = new InputDialog(
            "Input",
            LanguageManager.GetLang("CharName"),
            LanguageManager.GetLang("EnterCharNameForBuffing")
        );

        if (diag.ShowDialog(this) != DialogResult.OK)
            return;

        string name = diag.Value.ToString();

        if (_buffings.Any(p => p.Group == _selectedBuffingGroup.Text && p.Name == name))
        {
            MessageBox.Show(LanguageManager.GetLang("MsgBoxGroupAlreadyIn", name));
            return;
        }

        _buffings.Add(new BuffingPartyMember { Name = name, Group = _selectedBuffingGroup.Text });

        RefreshGroupMembers();
        SaveBuffingPartyMembers();
    }

    private void buttonCommandPlayerAdd_Click(object sender, EventArgs e)
    {
        var diag = new InputDialog(
            "Input",
            LanguageManager.GetLang("CharName"),
            LanguageManager.GetLang("EnterCharNameForCommandList")
        );

        if (diag.ShowDialog(this) != DialogResult.OK)
            return;

        listCommandPlayers.Items.Add(diag.Value.ToString());
        SaveCommandPlayersList();
    }

    private void buttonCommandPlayerRemove_Click(object sender, EventArgs e)
    {
        if (listCommandPlayers.SelectedIndices.Count == 0)
            return;

        listCommandPlayers.Items.RemoveAt(listCommandPlayers.SelectedIndices[0]);

        SaveCommandPlayersList();
    }

    private void buttonAutoJoinConfig_Click(object sender, EventArgs e)
    {
        checkBoxJoinByName.Checked = PlayerConfig.Get("RSBot.Party.AutoJoin.ByName", false);
        checkBoxJoinByTitle.Checked = PlayerConfig.Get("RSBot.Party.AutoJoin.ByTitle", false);
        textBoxJoinByName.Text = PlayerConfig.Get("RSBot.Party.AutoJoin.Name", string.Empty);
        textBoxJoinByTitle.Text = PlayerConfig.Get("RSBot.Party.AutoJoin.Title", string.Empty);
        topPartyPanel.Height = 120;

        buttonAutoJoinConfig.Color = ColorScheme.BackColor;
    }

    private void buttonConfirmJoinConfig_Click(object sender, EventArgs e)
    {
        PlayerConfig.Set("RSBot.Party.AutoJoin.ByName", checkBoxJoinByName.Checked);
        PlayerConfig.Set("RSBot.Party.AutoJoin.ByTitle", checkBoxJoinByTitle.Checked);

        if (checkBoxJoinByName.Checked)
            PlayerConfig.Set("RSBot.Party.AutoJoin.Name", textBoxJoinByName.Text);

        if (checkBoxJoinByTitle.Checked)
            PlayerConfig.Set("RSBot.Party.AutoJoin.Title", textBoxJoinByTitle.Text);

        Bundle.Container.Refresh();

        buttonAutoJoinConfig.Color = Color.Transparent;
        topPartyPanel.Height = 47;
    }

    private void checkBoxFollowMaster_CheckedChanged(object sender, EventArgs e)
    {
        PlayerConfig.Set("RSBot.Party.AlwaysFollowPartyMaster", checkBoxFollowMaster.Checked);

        Bundle.Container.Refresh();
    }

    /// <summary>
    ///     Occurs before Main form is displayed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Load(object sender, EventArgs e)
    {
        LoadSettings();
    }
}
