using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Skills.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        private bool _applySkills;

        private enum MoveDirection { Up = -1, Down = 1 };

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        /// <summary>
        /// Applies the attack skills.
        /// </summary>
        private void ApplyAttackSkills()
        {
            for (var i = 0; i < comboMonsterType.Items.Count; i++)
            {
                var groupIds = PlayerConfig.GetArray<int>("RSBot.Skills.Attacks_" + i);

                foreach (var groupId in groupIds)
                {
                    var skillInfo = Game.Player.Skills.GetSkillInfoByGroupId(groupId);

                    if (skillInfo == null) continue;

                    //Apply to core
                    switch (i)
                    {
                        case 0:
                            SkillManager.Skills[MonsterRarity.General].Add(skillInfo);
                            continue;
                        case 1:
                            SkillManager.Skills[MonsterRarity.Champion].Add(skillInfo);
                            continue;
                        case 2:
                            SkillManager.Skills[MonsterRarity.Elite].Add(skillInfo);
                            continue;
                        case 3:
                            SkillManager.Skills[MonsterRarity.Giant].Add(skillInfo);
                            continue;
                        case 4:
                            SkillManager.Skills[MonsterRarity.GeneralParty].Add(skillInfo);
                            continue;
                        case 5:
                            SkillManager.Skills[MonsterRarity.ChampionParty].Add(skillInfo);
                            continue;
                        case 6:
                            SkillManager.Skills[MonsterRarity.GiantParty].Add(skillInfo);
                            continue;
                        case 7:
                            SkillManager.Skills[MonsterRarity.Unique].Add(skillInfo);
                            continue;
                        default:
                            SkillManager.Skills[MonsterRarity.General].Add(skillInfo); //Every other monster rarity will apply to default (general)
                            continue;
                    }
                }
            }
        }

        /// <summary>
        /// Applies the buff skills.
        /// </summary>
        private void ApplyBuffSkills()
        {
            SkillManager.Buffs.Clear();

            foreach (var item in PlayerConfig.GetArray<int>("RSBot.Skills.Buffs"))
            {
                var characterSkill = Game.Player.Skills.GetSkillInfoByGroupId(item);
                if (characterSkill == null) continue;

                SkillManager.Buffs.Add(characterSkill);
            }
        }

        /// <summary>
        /// Applies the skills.
        /// </summary>
        private void ApplySkills()
        {
            if (!_applySkills) return;

            SkillManager.Skills[MonsterRarity.General].Clear();
            SkillManager.Skills[MonsterRarity.Champion].Clear();
            SkillManager.Skills[MonsterRarity.Elite].Clear();
            SkillManager.Skills[MonsterRarity.Giant].Clear();
            SkillManager.Skills[MonsterRarity.GeneralParty].Clear();
            SkillManager.Skills[MonsterRarity.ChampionParty].Clear();
            SkillManager.Skills[MonsterRarity.GiantParty].Clear();
            SkillManager.Skills[MonsterRarity.Unique].Clear();

            ApplyAttackSkills();
            ApplyBuffSkills();
        }

        /// <summary>
        /// Loads the attacks.
        /// </summary>
        /// <param name="index">The index.</param>
        private void LoadAttacks(int index = 0)
        {
            listAttackingSkills.BeginUpdate();
            listAttackingSkills.Items.Clear();

            var skillArray = PlayerConfig.GetArray<int>("RSBot.Skills.Attacks_" + index);

            foreach (var skillInfo in Game.Player.Skills.KnownSkills.FindAll(p => skillArray.Contains(p.Record.GroupID) && p.Enabled && p.IsAttack).ToArray())
            {
                var item = new ListViewItem(skillInfo.Record.GetRealName()) { Tag = skillInfo.Record };
                item.SubItems.Add("lv. " + skillInfo.Record.Basic_Level);
                listAttackingSkills.Items.Add(item);
            }

            listAttackingSkills.EndUpdate();

            //Load the skill images.
            Task.Run(() => { LoadSkillImages(listAttackingSkills); });
        }

        /// <summary>
        /// Loads the buffs.
        /// </summary>
        private void LoadBuffs()
        {
            listBuffs.BeginUpdate();
            listBuffs.Items.Clear();

            var skillArray = PlayerConfig.GetArray<int>("RSBot.Skills.Buffs");

            foreach (var skillInfo in Game.Player.Skills.KnownSkills.FindAll(p => skillArray.Contains(p.Record.GroupID) && p.Enabled && !p.IsAttack).ToArray())
            {
                var item = new ListViewItem(skillInfo.Record.GetRealName()) { Tag = skillInfo.Record };

                item.SubItems.Add("lv. " + skillInfo.Record.Basic_Level);
                listBuffs.Items.Add(item);
            }

            listBuffs.EndUpdate();

            //Load the skill images.
            Task.Run(() => { LoadSkillImages(listBuffs); });
        }

        /// <summary>
        /// Loads the imbues.
        /// </summary>
        private void LoadImbues()
        {
            comboImue.Items.Clear();

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.Record != null && s.Record.Basic_Activity == 1 && s.Record.Params[4] == 8 && s.Enabled))
                comboImue.Items.Add(skill.Record.GetRealName());

            var imbueIndex = PlayerConfig.Get<int>("RSBot.Skills.ImbueIndex");

            if (comboImue.Items.Count - 1 >= imbueIndex)
                comboImue.SelectedIndex = imbueIndex;
        }

        /// <summary>
        /// Loads the resurrection skills.
        /// </summary>
        private void LoadResurrectionSkills()
        {
            comboResurrectionSkill.Items.Clear();

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(
                s => s.Record != null && s.Record.TargetEtc_SelectDeadBody == 1 &&
               (s.Record.Params[3] == 1751474540 || s.Record.Params[3] == 1919776116)))
            {
                comboResurrectionSkill.Items.Add(skill.Record.GetRealName());
            }

            var resIndex = PlayerConfig.Get<int>("RSBot.Skills.ResurrectionSkillIndex");

            if (comboResurrectionSkill.Items.Count - 1 >= resIndex)
                comboResurrectionSkill.SelectedIndex = resIndex;
        }

        /// <summary>
        /// Loads the skill images into the ImageList of the <seealso cref="ListView"/> control.
        /// </summary>
        private void LoadSkillImages(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                var skill = (RefSkill)item.Tag;

                if (imgSkills.Images.Keys.Cast<string>().Contains(skill.ID.ToString()))
                {
                    item.ImageKey = skill.ID.ToString();

                    //No need to reload the image from the PK2
                    continue;
                }

                //Skill image loading
                if (!Game.MediaPk2.FileExists(Path.GetFileName(skill.UI_IconFile)))
                    continue;

                var imageFile = Game.MediaPk2.GetFile(Path.GetFileName(skill.UI_IconFile));

                imgSkills.Images.Add(skill.ID.ToString(), imageFile.ToImage());

                //Renders the image
                item.ImageKey = skill.ID.ToString();
            }
        }

        /// <summary>
        /// Loads the skills.
        /// </summary>
        private void LoadSkills()
        {
            if (Game.Player == null) return;

            LoadImbues();
            LoadResurrectionSkills();

            listSkills.BeginUpdate();
            listSkills.Items.Clear();
            listSkills.Groups.Clear();

            foreach (var mastery in Game.Player.Skills.Masteries)
            {
                var group = new ListViewGroup(Game.ReferenceManager.GetTranslation(mastery.Record.NameCode) + " (lv. " + mastery.Level + ")");
                group.Tag = mastery.Id;
                listSkills.Groups.Add(group);
            }

            var unknownSkillNamesCount = 0;
            foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.Enabled))
            {
                var isLowLevelSkill = skill.Record.ReqCommon_MasteryLevel1 <
                                       Game.Player.Skills.GetMasteryInfoById((uint)skill.Record.ReqCommon_Mastery1).Level - 20;

                if (checkHideLowerLevelSkills.Checked && isLowLevelSkill || skill.IsPassive) continue; //Dont list passive skills or lower level skills?

                var name = skill.Record.GetRealName();

                if (string.IsNullOrWhiteSpace(name) || name == "" || name == "0")
                    unknownSkillNamesCount++;

                var item = new ListViewItem(name) { Tag = skill.Record };
                item.SubItems.Add("lv. " + skill.Record.Basic_Level);

                foreach (var @group in listSkills.Groups.Cast<ListViewGroup>().Where(@group => Convert.ToInt32(@group.Tag) == skill.Record.ReqCommon_Mastery1))
                    item.Group = @group;

                if (skill.Record.TargetType_Animal == 1 && checkShowAttacks.Checked)
                    listSkills.Items.Add(item);
                else if (skill.Record.TargetType_Animal == 0 && checkShowBuffs.Checked)
                    listSkills.Items.Add(item);
            }

            if (unknownSkillNamesCount > 3)
                Log.Warn("Detected wrong translation index, please go to 'Tools->Plugins->Language Wizard' to set the correct one!");

            listSkills.EndUpdate();

            //Load the skill images.
            Task.Run(() => { LoadSkillImages(listSkills); });
        }

        /// <summary>
        /// Move the selected items by <seealso cref="MoveDirection"/>
        /// </summary>
        /// <param name="sender">The ListView</param>
        /// <param name="direction">The move direction</param>
        private void MoveListViewItems(ListView sender, MoveDirection direction)
        {
            var valid = sender.SelectedItems.Count > 0 &&
                        ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                        || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

            if (valid)
            {
                var firstIndex = sender.SelectedItems[0].Index;
                var selectedItems = sender.SelectedItems.Cast<ListViewItem>().ToList();

                sender.BeginUpdate();

                foreach (ListViewItem item in sender.SelectedItems)
                    item.Remove();

                if (direction == MoveDirection.Up)
                {
                    var insertTo = firstIndex - 1;
                    foreach (var item in selectedItems)
                    {
                        sender.Items.Insert(insertTo, item);
                        insertTo++;
                    }
                }
                else
                {
                    var insertTo = firstIndex + 1;
                    foreach (var item in selectedItems)
                    {
                        sender.Items.Insert(insertTo, item);
                        insertTo++;
                    }
                }
                sender.EndUpdate();
            }
        }

        /// <summary>
        /// Refreshes the active buffs.
        /// </summary>
        private void RefreshActiveBuffs()
        {
            if (Game.Player == null || Game.Player.Buffs == null) return;

            listActiveBuffs.BeginUpdate();
            listActiveBuffs.Items.Clear();
            var activeBuffs = Game.Player.Buffs.ToArray();
            foreach (var buff in activeBuffs)
            {
                var lvItem = new ListViewItem(buff.Record.GetRealName()) { Tag = buff.Record };
                lvItem.SubItems.Add("lv. " + buff.Record.Basic_Level);

                listActiveBuffs.Items.Add(lvItem);
            }
            listActiveBuffs.EndUpdate();

            // Load skill images
            Task.Run(() => { LoadSkillImages(listActiveBuffs); });
        }

        /// <summary>
        /// Saves the attacks.
        /// </summary>
        private void SaveAttacks()
        {
            var savedSkills = listAttackingSkills.Items.Cast<ListViewItem>().Select(p => ((RefSkill)p.Tag).GroupID).ToArray();

            PlayerConfig.SetArray("RSBot.Skills.Attacks_" + comboMonsterType.SelectedIndex, savedSkills);

            ApplySkills();
        }

        /// <summary>
        /// Saves the buffs.
        /// </summary>
        private void SaveBuffs()
        {
            var savedBuffs = listBuffs.Items.Cast<ListViewItem>().Select(p => ((RefSkill)p.Tag).GroupID).ToArray();

            PlayerConfig.SetArray("RSBot.Skills.Buffs", savedBuffs);

            ApplyBuffSkills();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
            EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
            EventManager.SubscribeEvent("OnLearnSkill", new Action<SkillInfo, bool>(OnLearnSkill));
            EventManager.SubscribeEvent("OnLearnSkillMastery", new Action<MasteryInfo>(OnLearnSkillMastery));
            EventManager.SubscribeEvent("OnWithdrawSkill", new Action<SkillInfo>(OnWithdrawSkill));
            EventManager.SubscribeEvent("OnResurrectionRequest", OnResurrectionRequest);
        }

        /// <summary>
        /// The first event that will be fired after the player enters the game
        /// </summary>
        private void OnEnterGame()
        {
            checkShowAttacks.Checked = PlayerConfig.Get<bool>("RSBot.Skills.ShowAttacks", true);
            checkShowBuffs.Checked = PlayerConfig.Get<bool>("RSBot.Skills.ShowBuffs", true);
            checkHideLowerLevelSkills.Checked = PlayerConfig.Get<bool>("RSBot.Skills.HideLowerLevelSkills");
            checkAcceptResurrection.Checked = PlayerConfig.Get<bool>("RSBot.Skills.AcceptResurrection");
            checkResurrectParty.Checked = PlayerConfig.Get<bool>("RSBot.Skills.ResurrectPartyMembers");
            checkCastBuffsInTowns.Checked = PlayerConfig.Get<bool>("RSBot.Skills.CastBuffsInTowns");
            checkCastBuffsDuringWalkBack.Checked = PlayerConfig.Get<bool>("RSBot.Skills.CastBuffsDuringWalkBack");
        }

        /// <summary>
        /// Core_s the on learn skill.
        /// </summary>
        /// <param name="skill">The skill.</param>
        /// <param name="update">if set to <c>true</c> [update].</param>
        private void OnLearnSkill(SkillInfo skill, bool update)
        {
            if (update)
                Log.Notify($"The skill [{skill.Record.GetRealName()}] has been upgraded!");
            else
                Log.Notify($"New skill [{skill.Record.GetRealName()}] has been learned!");

            LoadSkills();
            LoadAttacks();
            LoadBuffs();

            _applySkills = true;
            ApplySkills();
            _applySkills = false;
        }

        /// <summary>
        /// Core_s the on learn skill mastery.
        /// </summary>
        /// <param name="info">The information.</param>
        private void OnLearnSkillMastery(MasteryInfo info)
        {
            Log.Notify($"The mastery [{info.Record.Name}] has been upgraded!");

            LoadSkills();
        }

        /// <summary>
        /// Main_s the on load character.
        /// </summary>
        private void OnLoadCharacter()
        {
            comboMonsterType.SelectedIndex = 0;
            LoadSkills();
            LoadAttacks();
            LoadBuffs();

            _applySkills = true;
            ApplySkills();
            _applySkills = false;
        }

        private void OnResurrectionRequest()
        {
            if (Game.AcceptanceRequest != null && PlayerConfig.Get<bool>("RSBot.Skills.AcceptResurrection"))
                Game.AcceptanceRequest.Accept();
        }

        /// <summary>
        /// Core_s the on withdraw skill.
        /// </summary>
        /// <param name="oldSkill">The old skill.</param>
        private void OnWithdrawSkill(SkillInfo oldSkill)
        {
            Log.Notify($"The skill [{oldSkill.Record.GetRealName()}] was withdrawn.");
            LoadSkills();
            LoadAttacks();
            LoadBuffs();

            _applySkills = true;
            ApplySkills();
            _applySkills = false;
        }

        /// <summary>
        /// Handles the Click event of the btnMoveAttackSkillDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveAttackSkillDown_Click(object sender, EventArgs e)
        {
            MoveListViewItems(listAttackingSkills, MoveDirection.Down);
            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveAttackSkillUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveAttackSkillUp_Click(object sender, EventArgs e)
        {
            MoveListViewItems(listAttackingSkills, MoveDirection.Up);
            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveBuffSkillDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveBuffSkillDown_Click(object sender, EventArgs e)
        {
            MoveListViewItems(listBuffs, MoveDirection.Down);
            SaveBuffs();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveBuffSkillUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveBuffSkillUp_Click(object sender, EventArgs e)
        {
            MoveListViewItems(listBuffs, MoveDirection.Up);
            SaveBuffs();
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveAttackSkill control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveAttackSkill_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listAttackingSkills.SelectedItems)
                item.Remove();

            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the btnRemoveBuffSkill control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveBuffSkill_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listBuffs.SelectedItems)
                item.Remove();

            SaveBuffs();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkAcceptResurrection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkAcceptResurrection_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Skills.AcceptResurrection", checkAcceptResurrection.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkCastBuffsInTowns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkCastBuffsInTowns_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Skills.CastBuffsInTowns", checkCastBuffsInTowns.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkCastBuffsWhenWalkBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkCastBuffsWhenWalkBack_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Skills.CastBuffsDuringWalkBack", checkCastBuffsDuringWalkBack.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkResurrectParty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkResurrectParty_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Skills.ResurrectPartyMembers", checkResurrectParty.Checked);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboImue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboImue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboImue.SelectedIndex != -1)
            {
                PlayerConfig.Set("RSBot.Skills.ImbueIndex", comboImue.SelectedIndex);

                var skill = Game.Player.Skills.GetSkillByName(comboImue.SelectedItem.ToString());
                SkillManager.ImbueSkill = skill;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboMonsterType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboMonsterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttacks(comboMonsterType.SelectedIndex);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboResurrectionSkill control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboResurrectionSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboResurrectionSkill.SelectedIndex != -1)
            {
                PlayerConfig.Set("RSBot.Skills.ResurrectionSkillIndex", comboResurrectionSkill.SelectedIndex);

                var skill = Game.Player.Skills.GetSkillByName(comboResurrectionSkill.SelectedItem.ToString());
                SkillManager.ResurrectionSkill = skill;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the filters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Skills.ShowBuffs", checkShowBuffs.Checked);
            PlayerConfig.Set("RSBot.Skills.ShowAttacks", checkShowAttacks.Checked);
            PlayerConfig.Set("RSBot.Skills.HideLowerLevelSkills", checkHideLowerLevelSkills.Checked);

            LoadSkills();
        }

        /// <summary>
        /// Handles the Click event of the menuAddAttack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuAddAttack_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listSkills.SelectedItems)
            {
                if (listAttackingSkills.Items.Cast<ListViewItem>()
                   .Count(p => ((RefSkill)p.Tag).GroupID == ((RefSkill)item.Tag).GroupID) != 0)
                    continue;

                var skill = Game.Player.Skills.GetSkillInfoByGroupId(((RefSkill)item.Tag).GroupID);
                if (skill != null && skill.IsAttack)
                    listAttackingSkills.Items.Add((ListViewItem)item.Clone());
            }

            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the menuAddBuff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuAddBuff_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listSkills.SelectedItems)
            {
                if (listBuffs.Items.Cast<ListViewItem>()
                   .Count(p => ((RefSkill)p.Tag).GroupID == ((RefSkill)item.Tag).GroupID) != 0)
                    continue;

                var skill = Game.Player.Skills.GetSkillInfoByGroupId(((RefSkill)item.Tag).GroupID);
                if (skill != null && !skill.IsAttack)
                    listBuffs.Items.Add((ListViewItem)item.Clone());
            }

            SaveBuffs();
        }

        /// <summary>
        /// Handles the Tick event of the trmActiveBuffs control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void trmActiveBuffs_Tick(object sender, EventArgs e)
        {
            RefreshActiveBuffs();
        }
    }
}