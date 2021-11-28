using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Party.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        private bool _applySettings = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
            cbPartySearchPurpose.SelectedIndex = 0;
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
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
        }

        /// <summary>
        /// Add new party member
        /// </summary>
        /// <param name="member"></param>
        public void AddNewPartyMember(PartyMember member)
        {
            var viewItem = listParty.Items.Add(member.Name, member.Name, 0);
            viewItem.UseItemStyleForSubItems = false;

            viewItem.SubItems.Add(member.Level.ToString());
            if (string.IsNullOrWhiteSpace(member.Guild))
                viewItem.SubItems.Add("< No Guild > ").ForeColor = Color.DarkGray;
            else
                viewItem.SubItems.Add(member.Guild);

            var mastery1 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId1);
            var mastery2 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId2);
            var location = Game.ReferenceManager.GetTranslation(member.Position.RegionID.ToString());

            var masteryInfo = "<none>";
            if (mastery1 != null)
                masteryInfo = mastery1.Name;
            if (mastery2 != null)
                masteryInfo += $", {mastery2.Name}";

            viewItem.SubItems.Add(masteryInfo);
            viewItem.SubItems.Add(location);
        }

        /// <summary>
        /// Saves the automatic party player list.
        /// </summary>
        private void SaveAutoPartyPlayerList()
        {
            PlayerConfig.SetArray("RSBot.Party.AutoPartyList", listAutoParty.Items.Cast<string>().ToArray());

            Bundle.Container.Refresh();
        }

        /// <summary>
        /// Requests the party list.
        /// </summary>
        private void RequestPartyList(byte page = 0)
        {
            lvPartyMatching.BeginUpdate();
            lvPartyMatching.Items.Clear();
            Task.Run(() =>
            {
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
                    if (party.Leader == Game.Player.Name || party.Leader == Game.Player.JobInformation.Name)
                    {
                        listItem.Font = new Font(View.Instance.Font, FontStyle.Bold);
                        listItem.BackColor = Color.FromArgb(244, 247, 252);
                        listItem.ForeColor = Color.FromArgb(9, 40, 86);
                        listViewItems.Insert(0, listItem);
                        continue;
                    }
                    listViewItems.Add(listItem);
                }

                lvPartyMatching.Items.AddRange(listViewItems.ToArray());
            });
            lvPartyMatching.EndUpdate();
        }

        /// <summary>
        /// The first event that will be fired after the player enters the game
        /// </summary>
        private void OnEnterGame()
        {
            _applySettings = false;

            Bundle.Container.Refresh();

            checkAutoExpAutoShare.Checked = PlayerConfig.Get<bool>("RSBot.Party.EXPAutoShare");
            checkAutoItemAutoShare.Checked = PlayerConfig.Get<bool>("RSBot.Party.ItemAutoShare");
            checkAutoAllowInvitations.Checked = PlayerConfig.Get<bool>("RSBot.Party.AllowInvitations");
            checkAcceptAtTrainingPlace.Checked = Bundle.Container.AutoParty.Config.OnlyAtTrainingPlace;
            checkInviteAll.Checked = Bundle.Container.AutoParty.Config.InviteAll;
            checkInviteFromList.Checked = Bundle.Container.AutoParty.Config.InviteFromList;
            checkAcceptAll.Checked = Bundle.Container.AutoParty.Config.AcceptAll;
            checkAcceptFromList.Checked = Bundle.Container.AutoParty.Config.AcceptFromList;

            listAutoParty.Items.AddRange(PlayerConfig.GetArray<string>("RSBot.Party.AutoPartyList"));
            _applySettings = true;
        }

        /// <summary>
        /// Displays the party members.
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

                foreach (var member in Game.Party.Members.FindAll(p => p.Name != Game.Player.Name || p.Name != Game.Player.JobInformation.Name))
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
            catch
            {
            }
            listParty.EndUpdate();
        }

        private void OnChangePartyEntry()
        {
            Log.Notify($"Formed party changed #{Bundle.Container.PartyMatching.Id}");

            if (tabMain.SelectedTab == tpPartyMatching)
                RequestPartyList();
        }

        private void OnDeletePartyEntry()
        {
            if (tabMain.SelectedTab == tpPartyMatching && lvPartyMatching.Items[0].Name == Bundle.Container.PartyMatching.Id.ToString())
                lvPartyMatching.Items.Remove(lvPartyMatching.Items[0]);

            Bundle.Container.PartyMatching.Id = 0;

            btnPartyMatchForm.Enabled = true;
            btnPartyMatchChangeEntry.Enabled = false;
            btnPartyMatchDeleteEntry.Enabled = false;
            btnJoinFormedParty.Enabled = true;
            grbAutoPartySettings.Enabled = true;

            if (Bundle.Container.PartyMatching.Config.AutoReform)
                Bundle.Container.PartyMatching.Create();
        }

        private void OnCreatePartyEntry()
        {
            Log.Notify($"Formed party matching entry #{Bundle.Container.PartyMatching.Id}");
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
            Log.Notify($"[{member.Name}] joined the party.");
            AddNewPartyMember(member);
        }

        private void OnPartyMemberLeave(PartyMember member)
        {
            Log.Notify($"[{member.Name}] has left the party.");
            listParty.Items.RemoveByKey(member.Name);
        }

        private void OnPartyMemberBanned(PartyMember member)
        {
            Log.Notify($"[{member.Name}] is banned from the party.");
            if (member.Name != Game.Player.Name)
                listParty.Items.RemoveByKey(member.Name);
            else
                OnPartyDismiss();
        }

        /// <summary>
        /// Called when [party member update].
        /// </summary>
        /// <param name="member">The member.</param>
        private void OnPartyMemberUpdate(PartyMember member)
        {
            if (!listParty.Items.ContainsKey(member.Name)) return;

            var lvItem = listParty.Items[member.Name];

            lvItem.Text = member.Name;
            lvItem.SubItems[1].Text = member.Level.ToString();
            lvItem.SubItems[2].Text = member.Guild;

            var mastery1 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId1);
            var mastery2 = Game.ReferenceManager.GetRefSkillMastery(member.MasteryId2);
            var location = Game.ReferenceManager.GetTranslation(member.Position.RegionID.ToString());

            var masteryInfo = "<none>";
            if (mastery1 != null)
                masteryInfo = mastery1.Name;
            if (mastery2 != null)
                masteryInfo += $", {mastery2.Name}";

            lvItem.SubItems[3].Text = masteryInfo;
            lvItem.SubItems[4].Text = location;
        }

        /// <summary>
        /// Clear party
        /// </summary>
        public void OnPartyDismiss()
        {
            Bundle.Container.PartyMatching.HasMatchingEntry = false;
            btnLeaveParty.Enabled = false;
            menuLeave.Enabled = false;
            lblLeader.Text = "<Not in a party>";
            listParty.Items.Clear();
            Log.Notify("The party has been dismissed!");
            OnDeletePartyEntry();
        }

        /// <summary>
        /// Handles the Click event of the btnLeaveParty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLeaveParty_Click(object sender, System.EventArgs e)
        {
            Game.Party.Leave();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkSettings_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!_applySettings) return;

            PlayerConfig.Set("RSBot.Party.EXPAutoShare", checkAutoExpAutoShare.Checked);
            PlayerConfig.Set("RSBot.Party.ItemAutoShare", checkAutoItemAutoShare.Checked);
            PlayerConfig.Set("RSBot.Party.AllowInvitations", checkAutoAllowInvitations.Checked);

            Bundle.Container.AutoParty.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the menuBanish control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuBanish_Click(object sender, System.EventArgs e)
        {
            if (listParty.SelectedItems.Count == 1 && Game.Party.IsLeader)
                Game.Party.GetMemberByName(listParty.SelectedItems[0].Text)?.Banish();
        }

        /// <summary>
        /// Handles the Click event of the btnAddToAutoParty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddToAutoParty_Click(object sender, System.EventArgs e)
        {
            var diag = new InputDialog(@"Character name", "Please enter the character name that you want to add to the auto party list.");

            if (diag.ShowDialog() != DialogResult.OK) return;

            listAutoParty.Items.Add(diag.Value);
            SaveAutoPartyPlayerList();
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveFromAutoParty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRemoveFromAutoParty_Click(object sender, System.EventArgs e)
        {
            if (listAutoParty.SelectedIndex == -1) return;
            listAutoParty.Items.Remove(listAutoParty.SelectedItem);

            SaveAutoPartyPlayerList();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkAutoPartySetting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkAutoPartySetting_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!_applySettings) return;

            PlayerConfig.Set("RSBot.Party.AcceptAll", checkAcceptAll.Checked);
            PlayerConfig.Set("RSBot.Party.AcceptList", checkAcceptFromList.Checked);
            PlayerConfig.Set("RSBot.Party.InviteAll", checkInviteAll.Checked);
            PlayerConfig.Set("RSBot.Party.InviteList", checkInviteFromList.Checked);
            PlayerConfig.Set("RSBot.Party.AtTrainingPlace", checkAcceptAtTrainingPlace.Checked);
            PlayerConfig.Set("RSBot.Party.AcceptIfBotStopped", checkAcceptIfBotStopped.Checked);

            Bundle.Container.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the ctxJoinParty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnJoinFormedParty_Click(object sender, System.EventArgs e)
        {
            if (lvPartyMatching.SelectedItems.Count != 1)
                return;

            var partyNumber = Convert.ToInt32(lvPartyMatching.SelectedItems[0].Text);

            Log.Notify("Requesting to join party #" + partyNumber);

            Bundle.Container.PartyMatching.Join(partyNumber);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the tpPartyMatching page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tpPartyMatching)
                RequestPartyList();
        }

        /// <summary>
        /// Handles the Click event of the btnPartyMatchForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPartyMatchForm_Click(object sender, EventArgs e)
        {
            var senderName = (sender as Button).Name;

            var formingParty = new AutoFormParty(senderName == nameof(btnPartyMatchForm) ? "Forming party" : "Change Entry");
            if (formingParty.ShowDialog() == DialogResult.OK)
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
            {
                //No case sensitivity
                lvItems.RemoveAll(p => !p.SubItems[2].Text.ToLowerInvariant().Contains(tbPartySearchName.Text.ToLowerInvariant()));
            }

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
    }
}