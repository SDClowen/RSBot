using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Theme.Extensions;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();

            listSkills.ContextMenu = skillContextMenu;
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
            EventManager.SubscribeEvent("OnAddBuff", new Action<BuffInfo>(OnAddBuff));
            EventManager.SubscribeEvent("OnRemoveBuff", new Action<BuffInfo>(OnRemoveBuff));
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
        /// Check if the skill is low level for character (Lazy basic :-;)
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>
        /// <c>true</c> otherwise, <c>false</c>.
        /// </returns>
        private bool IsLowLevelSkill(RefSkill skill)
        {
            return skill.ReqCommon_MasteryLevel1 <
                                       Game.Player.Skills.GetMasteryInfoById((uint)skill.ReqCommon_Mastery1).Level - 20;
        }

        /// <summary>
        /// Applies the attack skills.
        /// </summary>
        private void ApplyAttackSkills()
        {
            for (var i = 0; i < comboMonsterType.Items.Count; i++)
            {
                var skillIds = PlayerConfig.GetArray<uint>("RSBot.Skills.Attacks_" + i);

                foreach (var skillId in skillIds)
                {
                    var skillInfo = Game.Player.Skills.GetSkillInfoById(skillId);

                    if (skillInfo == null) 
                        continue;

                    switch (i)
                    {
                        case 1:
                            SkillManager.Skills[MonsterRarity.Champion].Add(skillInfo);
                            continue;
                        case 2:
                            SkillManager.Skills[MonsterRarity.Giant].Add(skillInfo);
                            continue;
                        case 3:
                            SkillManager.Skills[MonsterRarity.GeneralParty].Add(skillInfo);
                            continue;
                        case 4:
                            SkillManager.Skills[MonsterRarity.ChampionParty].Add(skillInfo);
                            continue;
                        case 5:
                            SkillManager.Skills[MonsterRarity.GiantParty].Add(skillInfo);
                            continue;
                        case 6:
                            SkillManager.Skills[MonsterRarity.Elite].Add(skillInfo);
                            continue;
                        case 7:
                            SkillManager.Skills[MonsterRarity.EliteStrong].Add(skillInfo);
                            continue;
                        case 8:
                            SkillManager.Skills[MonsterRarity.Unique].Add(skillInfo);
                            continue;
                        default:
                            SkillManager.Skills[MonsterRarity.General].Add(skillInfo);
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

            foreach (var buffId in PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs"))
            {
                var skillInfo = Game.Player.Skills.GetSkillInfoById(buffId);
                if (skillInfo == null) 
                    continue;

                SkillManager.Buffs.Add(skillInfo);
            }
        }

        /// <summary>
        /// Applies the skills.
        /// </summary>
        private void ApplySkills()
        {
            if (!_applySkills) 
                return;

            foreach (var collection in SkillManager.Skills.Values)
                collection.Clear();

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

            var skillArray = PlayerConfig.GetArray<uint>("RSBot.Skills.Attacks_" + index);

            foreach (var skillInfo in Game.Player.Skills.KnownSkills.FindAll(p => skillArray.Contains(p.Id) && p.Enabled && p.IsAttack).ToArray())
            {
                var item = new ListViewItem(skillInfo.Record.GetRealName()) { Tag = skillInfo };
                item.SubItems.Add("lv. " + skillInfo.Record.Basic_Level);
                listAttackingSkills.Items.Add(item);
            }

            listAttackingSkills.EndUpdate();

            Task.Run(() => { LoadSkillImages(listAttackingSkills); });
        }

        /// <summary>
        /// Loads the buffs.
        /// </summary>
        private void LoadBuffs()
        {
            listBuffs.BeginUpdate();
            listBuffs.Items.Clear();

            var skillArray = PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs");

            foreach (var skillInfo in Game.Player.Skills.KnownSkills.FindAll(p => skillArray.Contains(p.Id) && p.Enabled && !p.IsAttack).ToArray())
            {
                var item = new ListViewItem(skillInfo.Record.GetRealName()) { Tag = skillInfo };

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
            comboImbue.Items.Clear();

            var selectedImbue = PlayerConfig.Get<int>("RSBot.Skills.Imbue");

            comboImbue.SelectedIndex = comboImbue.Items.Add("None");

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.IsImbue && s.Enabled))
            {
                if (IsLowLevelSkill(skill.Record))
                    continue;

                var index = comboImbue.Items.Add(skill);
                
                if (selectedImbue == 0)
                    continue;
                
                if (selectedImbue == skill.Id)
                    comboImbue.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Loads the resurrection skills.
        /// </summary>
        private void LoadResurrectionSkills()
        {
            comboResurrectionSkill.Items.Clear();

            comboResurrectionSkill.SelectedIndex = comboResurrectionSkill.Items.Add("None");

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(
                s => s.Record != null && s.Record.TargetEtc_SelectDeadBody &&
               (s.Record.Params[3] == 1751474540 || s.Record.Params[3] == 1919776116)))
            {
                if (IsLowLevelSkill(skill.Record))
                    continue;

                var index = comboResurrectionSkill.Items.Add(skill);
                var resurrectionSkillId = PlayerConfig.Get<int>("RSBot.Skills.ResurrectionSkill");
                if (resurrectionSkillId == 0)
                    continue;
                
                if (skill.Id == resurrectionSkillId)
                    comboResurrectionSkill.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Load the skill image into the ImageList of the <seealso cref="ListViewItem"/>
        /// </summary>
        /// <param name="refSkill">The RefSkill</param>
        private void LoadSkillImageForListViewItem(ListViewItem item)
        {
            var skill = item.Tag as ISkillDataInfo;
            if (imgSkills.Images.Keys.Cast<string>().Contains(skill.Id.ToString()))
            {
                item.ImageKey = skill.Id.ToString();
                return;
            }

            if (!Game.MediaPk2.FileExists(Path.GetFileName(skill.Record.UI_IconFile)))
                return;

            var imageFile = Game.MediaPk2.GetFile(Path.GetFileName(skill.Record.UI_IconFile));

            imgSkills.Images.Add(skill.Id.ToString(), imageFile.ToImage());

            item.ImageKey = skill.Id.ToString();
        }

        /// <summary>
        /// Loads the skill images into the ImageList of the <seealso cref="ListView"/> control.
        /// </summary>
        private void LoadSkillImages(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
                LoadSkillImageForListViewItem(item);
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

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.Enabled))
            {
                var isLowLevelSkill = IsLowLevelSkill(skill.Record);
                if (checkHideLowerLevelSkills.Checked && isLowLevelSkill) 
                    continue;

                if (skill.IsPassive)
                    continue;

                if (!skill.IsAttack && skill.Record.Target_Required && !skill.Record.TargetGroup_Self)
                    continue;

                var name = skill.Record.GetRealName();

                var item = new ListViewItem(name) { Tag = skill };
                item.SubItems.Add("lv. " + skill.Record.Basic_Level);

                foreach (var @group in listSkills.Groups.Cast<ListViewGroup>().Where(@group => Convert.ToInt32(@group.Tag) == skill.Record.ReqCommon_Mastery1))
                    item.Group = @group;

                if (skill.IsAttack && checkShowAttacks.Checked)
                    listSkills.Items.Add(item);
                else if (!skill.IsAttack && !skill.IsImbue && checkShowBuffs.Checked)
                    listSkills.Items.Add(item);
            }

            listSkills.EndUpdate();

            //Load the skill images.
            Task.Run(() => { LoadSkillImages(listSkills); });
        }

        /// <summary>
        /// Saves the attacks.
        /// </summary>
        private void SaveAttacks()
        {
            var savedSkills = listAttackingSkills.Items.Cast<ListViewItem>().Select(p => ((ISkillDataInfo)p.Tag).Id).ToArray();

            PlayerConfig.SetArray("RSBot.Skills.Attacks_" + comboMonsterType.SelectedIndex, savedSkills);

            _applySkills = true;
            ApplySkills();
            _applySkills = false;
        }

        /// <summary>
        /// Saves the buffs.
        /// </summary>
        private void SaveBuffs()
        {
            var savedBuffs = listBuffs.Items.Cast<ListViewItem>().Select(p => ((ISkillDataInfo)p.Tag).Id).ToArray();

            PlayerConfig.SetArray("RSBot.Skills.Buffs", savedBuffs);

            ApplyBuffSkills();
        }

        /// <summary>
        /// Run the event after added the buff from the character
        /// </summary>
        /// <param name="buffInfo">The added <see cref="BuffInfo"/></param>
        private void OnAddBuff(BuffInfo buffInfo)
        {
            try
            {
                var item = new ListViewItem
                {
                    Text = buffInfo.Record.GetRealName(),
                    Tag = buffInfo
                };

                item.SubItems.Add("lv. " + buffInfo.Record.Basic_Level);
                LoadSkillImageForListViewItem(item);
                listActiveBuffs.Items.Add(item);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Run the event after removed the buff from the character
        /// </summary>
        /// <param name="buffInfo">The removed <see cref="BuffInfo"/></param>
        private void OnRemoveBuff(BuffInfo removingBuff)
        {
            try
            {
                for (int i = 0; i < listActiveBuffs.Items.Count; i++)
                {
                    var listItem = listActiveBuffs.Items[i];
                    if (listItem == null)
                        continue;

                    var itemBuffInfo = listItem.Tag as BuffInfo;
                    if (itemBuffInfo != null &&
                        itemBuffInfo.Id == removingBuff.Id &&
                        itemBuffInfo.Token == removingBuff.Token)
                    {
                        // System.IndexOutOfRangeException: 'Index was outside the bounds of the array.' ?? 
                        listItem.Remove();
                        return;
                    }

                }
            }
            catch
            {

            }
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

            listActiveBuffs.Items.Clear();
        }

        /// <summary>
        /// Core_s the on resurrection request
        /// </summary>
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
            listAttackingSkills.MoveSelectedItems(MoveDirection.Down);
            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveAttackSkillUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveAttackSkillUp_Click(object sender, EventArgs e)
        {
            listAttackingSkills.MoveSelectedItems(MoveDirection.Up);
            SaveAttacks();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveBuffSkillDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveBuffSkillDown_Click(object sender, EventArgs e)
        {
            listBuffs.MoveSelectedItems(MoveDirection.Down);
            SaveBuffs();
        }

        /// <summary>
        /// Handles the Click event of the btnMoveBuffSkillUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMoveBuffSkillUp_Click(object sender, EventArgs e)
        {
            listBuffs.MoveSelectedItems(MoveDirection.Up);
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
        private void comboImbue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboImbue.SelectedIndex < 0)
                return;

            SkillInfo imbue = null;

            if (comboImbue.SelectedIndex > 0)
                imbue = comboImbue.SelectedItem as SkillInfo;

            SkillManager.ImbueSkill = imbue;
            PlayerConfig.Set("RSBot.Skills.Imbue", imbue == null ? 0 : imbue.Id);
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
            if (comboResurrectionSkill.SelectedIndex < 0)
                return;

            SkillInfo skill = null;

            if (comboResurrectionSkill.SelectedIndex > 0)
                skill = comboResurrectionSkill.SelectedItem as SkillInfo;

            SkillManager.ResurrectionSkill = skill;
            PlayerConfig.Set("RSBot.Skills.ResurrectionSkill", skill == null ? 0 : skill.Id);
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
                var selectedRefSkill = item.Tag as SkillInfo;
                if (listAttackingSkills.Items.Cast<ListViewItem>()
                   .Count(p => ((SkillInfo)p.Tag).Record.Action_Overlap != 0 && ((SkillInfo)p.Tag).Record.Action_Overlap == selectedRefSkill.Record.Action_Overlap) != 0)
                    continue;

                if (selectedRefSkill != null && selectedRefSkill.IsAttack)
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
                var selectedRefSkill = item.Tag as SkillInfo;
                if (listBuffs.Items.Cast<ListViewItem>()
                   .Count(p => ((SkillInfo)p.Tag).Record.Action_Overlap != 0 && ((SkillInfo)p.Tag).Record.Action_Overlap == selectedRefSkill.Record.Action_Overlap) != 0)
                    continue;

                if (selectedRefSkill != null && !selectedRefSkill.IsAttack)
                    listBuffs.Items.Add((ListViewItem)item.Clone());
            }

            SaveBuffs();
        }
    }
}