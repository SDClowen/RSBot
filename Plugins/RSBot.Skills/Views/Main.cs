using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Skills.Components;
using SDUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CheckBox = SDUI.Controls.CheckBox;
using ListViewExtensions = RSBot.Core.Extensions.ListViewExtensions;

namespace RSBot.Skills.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    private System.Windows.Forms.Timer _buffTimer;
    private bool _didFirstDraw;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        InitializeComponent();
        SubscribeEvents();

        listAttackingSkills.SmallImageList = ListViewExtensions.StaticImageList;
        listBuffs.SmallImageList = ListViewExtensions.StaticImageList;
        listSkills.SmallImageList = ListViewExtensions.StaticImageList;
        // Details view uses SmallImageList for item icons
        listActiveBuffs.SmallImageList = ListViewExtensions.StaticImageList;

        _lock = new object();

        // Start periodic invalidation for active-buff overlays
        _buffTimer = new() { Interval = 100 };
        _buffTimer.Tick += BuffTimer_Tick;
        _buffTimer.Start();

        // Use owner-draw to reliably draw overlay on each item after default rendering
        listActiveBuffs.OwnerDraw = true;
        listActiveBuffs.DrawItem += ListSkill_DrawItem;

        // Also owner-draw attack and skill lists to render cooldown overlays on cast
        listAttackingSkills.OwnerDraw = true;
        listAttackingSkills.DrawItem += ListSkill_DrawItem;

        listBuffs.OwnerDraw = true;
        listBuffs.DrawItem += ListSkill_DrawItem;

        listSkills.OwnerDraw = true;
        listSkills.DrawItem += ListSkill_DrawItem;

        // Ensure timer is disposed when control is disposed
        this.Disposed += (s, e) => { _buffTimer?.Stop(); _buffTimer?.Dispose(); };
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);

        EventManager.SubscribeEvent("OnSkillLearned", new Action<SkillInfo>(OnSkillLearned));
        EventManager.SubscribeEvent("OnSkillUpgraded", new Action<SkillInfo, SkillInfo>(OnSkillUpgraded));
        EventManager.SubscribeEvent("OnWithdrawSkill", new Action<SkillInfo, SkillInfo>(OnWithdrawSkill));
        EventManager.SubscribeEvent("OnLearnSkillMastery", new Action<MasteryInfo>(OnLearnSkillMastery));

        EventManager.SubscribeEvent("OnAddBuff", new Action<SkillInfo>(OnAddBuff));
        EventManager.SubscribeEvent("OnRemoveBuff", new Action<SkillInfo>(OnRemoveBuff));
        EventManager.SubscribeEvent("OnResurrectionRequest", OnResurrectionRequest);
        EventManager.SubscribeEvent("OnExpSpUpdate", OnSpUpdated);
        EventManager.SubscribeEvent("OnAddItemPerk", new Action<uint, uint>(OnAddItemPerk));
        EventManager.SubscribeEvent("OnRemoveItemPerk", new Action<uint, ItemPerk>(OnRemoveItemPerk));
    }

    /// <summary>
    ///     Called when [remove item perk].
    /// </summary>
    /// <param name="targetId">The target identifier.</param>
    /// <param name="removedPerk">The removed perk.</param>
    private void OnRemoveItemPerk(uint targetId, ItemPerk removedPerk)
    {
        if (targetId != Game.Player.UniqueId || removedPerk == null)
            return;

        for (var i = 0; i < listActiveBuffs.Items.Count; i++)
        {
            var listItem = listActiveBuffs.Items[i];

            if (listItem?.Tag is not ItemPerk perkInfo || perkInfo.Token != removedPerk.Token)
                continue;

            listItem.Remove();
            return;
        }
    }

    /// <summary>
    ///     Called when [add item perk].
    /// </summary>
    /// <param name="targetId">The target identifier.</param>
    /// <param name="token">The token.</param>
    private void OnAddItemPerk(uint targetId, uint token)
    {
        if (targetId != Game.Player.UniqueId)
            return;

        var perk = Game.Player.State.ActiveItemPerks[token];
        var item = new ListViewItem { Text = perk.Item?.GetRealName(), Tag = perk };

        listActiveBuffs.Items.Add(item);

        Log.Debug($"OnAddItemPerk: added perk itemId={perk.ItemId} token={token}");
        item.LoadSkillImage();
        listActiveBuffs.Invalidate();
    }

    /// <summary>
    ///     Will be triggered if EXP/SP were gained. Increases the selected mastery level (if available)
    /// </summary>
    private void OnSpUpdated()
    {
        if (_selectedMastery == null || !checkLearnMastery.Checked)
            return;

        while (_selectedMastery.Level + numMasteryGap.Value < Game.Player.Level)
        {
            if (!checkLearnMasteryBotStopped.Checked && !Kernel.Bot.Running)
                break;

            var nextMasteryLevel = Game.ReferenceManager.GetRefLevel((byte)(_selectedMastery.Level + 1));

            if (nextMasteryLevel.Exp_M > Game.Player.SkillPoints)
            {
                Log.Debug(
                    $"Auto. upping mastery cancelled due to insufficient skill points. Required: {nextMasteryLevel.Exp_M}"
                );

                break;
            }

            Log.Notify($"Auto. train mastery [{_selectedMastery.Record.Name} to lv. {nextMasteryLevel}");
            LearnMasteryHandler.LearnMastery(_selectedMastery.Record.ID);
            Thread.Sleep(500);
        }
    }

    /// <summary>
    ///     Loads the settings.
    /// </summary>
    private void LoadSettings()
    {
        const string key = "RSBot.Skills.";

        foreach (var checkbox in panelPlayerSkills.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAttackingSkills.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAutomatedResurrection.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAdvancedBuff.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in grpMasteryUpdate.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);

        foreach (var num in grpMasteryUpdate.Controls.OfType<NumUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var num in groupBoxAutomatedResurrection.Controls.OfType<NumUpDown>())
            num.Value = PlayerConfig.Get(key + num.Name, num.Value);

        foreach (var checkbox in groupAdvancedSetup.Controls.OfType<CheckBox>())
            checkbox.Checked = PlayerConfig.Get(key + checkbox.Name, checkbox.Checked);
    }

    /// <summary>
    ///     Saves the settings.
    /// </summary>
    private void ApplySettings()
    {
        const string key = "RSBot.Skills.";
        foreach (var checkbox in panelPlayerSkills.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAttackingSkills.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAutomatedResurrection.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in groupBoxAdvancedBuff.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var checkbox in grpMasteryUpdate.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);

        foreach (var num in grpMasteryUpdate.Controls.OfType<NumUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var num in groupBoxAutomatedResurrection.Controls.OfType<NumUpDown>())
            PlayerConfig.Set(key + num.Name, num.Value);

        foreach (var checkbox in groupAdvancedSetup.Controls.OfType<CheckBox>())
            PlayerConfig.Set(key + checkbox.Name, checkbox.Checked);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the settings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void settings_CheckedChanged(object sender, EventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();
    }

    /// <summary>
    ///     Handles the ValueChanged event of the numSettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void numSettings_ValueChanged(object sender, EventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();
    }

    /// <summary>
    ///     Applies the attack skills.
    /// </summary>
    private void ApplyAttackSkills()
    {
        foreach (var collection in SkillManager.Skills.Values)
            collection.Clear();

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
                    case 9:
                        SkillManager.Skills[MonsterRarity.Event].Add(skillInfo);
                        continue;
                    default:
                        SkillManager.Skills[MonsterRarity.General].Add(skillInfo);
                        continue;
                }
            }
        }
    }

    /// <summary>
    ///     Applies the buff skills.
    /// </summary>
    private void ApplyBuffSkills()
    {
        SkillManager.Buffs.Clear();

        Game.Player.TryGetAbilitySkills(out var abilitySkills);

        foreach (var buffId in PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs"))
        {
            var skillInfo = Game.Player.Skills.GetSkillInfoById(buffId);
            if (skillInfo == null)
            {
                skillInfo = abilitySkills.FirstOrDefault(p => p.Id == buffId);
                if (skillInfo == null)
                    continue;
            }

            SkillManager.Buffs.Add(skillInfo);
        }
    }

    /// <summary>
    ///     Loads the masteries.
    /// </summary>
    private void LoadMasteries()
    {
        var selectedMastery = PlayerConfig.Get<string>("RSBot.Skills.selectedMastery");
        comboLearnMastery.BeginUpdate();
        comboLearnMastery.Items.Clear();

        foreach (var mastery in Game.Player.Skills.Masteries)
            comboLearnMastery.Items.Add(new MasteryComboBoxItem { Level = mastery.Level, Record = mastery.Record });

        foreach (MasteryComboBoxItem item in comboLearnMastery.Items)
            if (item.Record.NameCode == selectedMastery)
                comboLearnMastery.SelectedItem = item;

        comboLearnMastery.EndUpdate();

        comboLearnMastery.Update();
    }

    /// <summary>
    ///     Loads the available teleport skills into the combo box
    /// </summary>
    private void LoadTeleportSkills()
    {
        comboTeleportSkill.BeginUpdate();
        comboTeleportSkill.Items.Clear();

        var selectedTeleportSkill = PlayerConfig.Get<uint>("RSBot.Skills.TeleportSkill");
        foreach (
            var skill in Game.Player.Skills.KnownSkills.Where(s =>
                s.CanBeCasted && s.Record.Action_ActionDuration == 0 && s.Record.Params[2] == 500
            )
        )
        {
            var index = comboTeleportSkill.Items.Add(
                new TeleportSkillComboBoxItem { Level = skill.Record.Basic_Level, Record = skill.Record }
            );

            if (selectedTeleportSkill == skill.Record.ID)
            {
                comboTeleportSkill.SelectedIndex = index;
                SkillManager.TeleportSkill = skill;
            }
        }

        comboLearnMastery.EndUpdate();
    }

    /// <summary>
    ///     Loads the attacks.
    /// </summary>
    /// <param name="index">The index.</param>
    private void LoadAttacks(int index = 0)
    {
        lock (_lock)
        {
            listAttackingSkills.BeginUpdate();
            listAttackingSkills.Items.Clear();

            var skillArray = PlayerConfig.GetArray<uint>("RSBot.Skills.Attacks_" + index);
            foreach (var skillId in skillArray)
            {
                var skillInfo = Game.Player.Skills.GetSkillInfoById(skillId);
                if (skillInfo == null)
                    continue;

                var item = new ListViewItem(skillInfo.Record.GetRealName()) { Tag = skillInfo };
                item.SubItems.Add("lv. " + skillInfo.Record.Basic_Level);
                listAttackingSkills.Items.Add(item);
                item.LoadSkillImageAsync();
            }

            listAttackingSkills.EndUpdate();
        }
    }

    /// <summary>
    ///     Loads the buffs.
    /// </summary>
    private void LoadBuffs()
    {
        lock (_lock)
        {
            listBuffs.BeginUpdate();
            listBuffs.Items.Clear();

            Game.Player.TryGetAbilitySkills(out var abilitySkills);

            var buffs = PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs");
            foreach (var buffId in buffs)
            {
                var buffInfo = Game.Player.Skills.GetSkillInfoById(buffId);
                if (buffInfo == null)
                {
                    buffInfo = abilitySkills.FirstOrDefault(p => p.Id == buffId);
                    if (buffInfo == null)
                        continue;
                }

                var item = new ListViewItem(buffInfo.Record.GetRealName()) { Tag = buffInfo };

                item.SubItems.Add("lv. " + buffInfo.Record.Basic_Level);
                listBuffs.Items.Add(item);
                item.LoadSkillImageAsync();
            }

            listBuffs.EndUpdate();
        }
    }

    /// <summary>
    ///     Loads the imbues.
    /// </summary>
    private void LoadImbues()
    {
        lock (_lock)
        {
            comboImbue.Items.Clear();

            var selectedImbue = PlayerConfig.Get<int>("RSBot.Skills.Imbue");

            comboImbue.SelectedIndex = comboImbue.Items.Add("None");

            foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.IsImbue && s.Enabled))
            {
                /*
                if (skill.IsLowLevel())
                    continue;
                */
                var index = comboImbue.Items.Add(skill);

                if (selectedImbue == 0)
                    continue;

                if (selectedImbue == skill.Id)
                    comboImbue.SelectedIndex = index;
            }
        }
    }

    /// <summary>
    ///     Loads the resurrection skills.
    /// </summary>
    private void LoadResurrectionSkills()
    {
        lock (_lock)
        {
            comboResurrectionSkill.Items.Clear();
            comboResurrectionSkill.Items.Add("None");

            foreach (
                var skill in Game.Player.Skills.KnownSkills.Where(s =>
                    s.Record != null
                    && ((s.Record.TargetEtc_SelectDeadBody && !s.Record.TargetGroup_Enemy_M) || s.Record.GroupID == 659)
                )
            ) //group res
            {
                if (skill.IsLowLevel())
                    continue;

                var index = comboResurrectionSkill.Items.Add(skill);
                var resurrectionSkillId = PlayerConfig.Get<int>("RSBot.Skills.ResurrectionSkill");
                if (skill.Id == resurrectionSkillId)
                    comboResurrectionSkill.SelectedIndex = index;
            }

            if (comboResurrectionSkill.SelectedIndex <= 0)
                comboResurrectionSkill.SelectedIndex = 0;
        }
    }

    /// <summary>
    ///     Loads the skills.
    /// </summary>
    private void LoadSkills()
    {
        lock (_lock)
        {
            var player = Game.Player;
            if (player == null)
                return;

            LoadTeleportSkills();
            LoadResurrectionSkills();
            LoadTeleportSkills();
            LoadImbues();
            LoadBuffs();
            LoadMasteries();
            LoadAttacks(comboMonsterType.SelectedIndex);

            listSkills.BeginUpdate();
            listSkills.Items.Clear();
            listSkills.Groups.Clear();

            if (Game.Player.TryGetAbilitySkills(out var abilitySkills))
            {
                var group = new ListViewGroup("Ability") { Tag = 0 };
                listSkills.Groups.Add(group);

                foreach (var skill in abilitySkills)
                {
                    if (skill.IsPassive)
                        continue;

                    var listViewItem = new ListViewItem(skill.Record.GetRealName()) { Tag = skill };
                    listViewItem.SubItems.Add("lv. " + skill.Record.Basic_Level);
                    listViewItem.Group = group;
                    listSkills.Items.Add(listViewItem);

                    listViewItem.LoadSkillImage();
                }
            }

            foreach (var mastery in player.Skills.Masteries)
            {
                var group = new ListViewGroup(
                    Game.ReferenceManager.GetTranslation(mastery.Record.NameCode) + " (lv. " + mastery.Level + ")"
                );
                group.Tag = mastery.Id;
                listSkills.Groups.Add(group);
            }

            foreach (
                var skill in player.Skills.KnownSkills.Where(s => s.Enabled && s.Record.ReqCommon_Mastery1 != 1000)
            )
            {
                if (skill.IsPassive)
                    continue;

                if (skill.IsImbue)
                    continue;

                if (checkHideLowerLevelSkills.Checked && skill.IsLowLevel())
                    continue;

                //if (!skill.IsAttack && skill.Record.Target_Required && !skill.Record.TargetGroup_Self)
                //continue;

                var name = skill.Record.GetRealName();

                var item = new ListViewItem(name) { Tag = skill };
                item.SubItems.Add("lv. " + skill.Record.Basic_Level);

                foreach (
                    var group in listSkills
                        .Groups.Cast<ListViewGroup>()
                        .Where(group => Convert.ToInt32(group.Tag) == skill.Record.ReqCommon_Mastery1)
                )
                    item.Group = group;

                if (skill.IsAttack && checkShowAttacks.Checked)
                    listSkills.Items.Add(item);
                else if (!skill.IsAttack && !skill.IsImbue && checkShowBuffs.Checked)
                    listSkills.Items.Add(item);

                item.LoadSkillImage();
            }

            listSkills.EndUpdate();
        }
    }

    /// <summary>
    ///     Saves the attacks.
    /// </summary>
    private void SaveAttacks()
    {
        var savedSkills = listAttackingSkills.Items.Cast<ListViewItem>().Select(p => ((SkillInfo)p.Tag).Id).ToArray();

        PlayerConfig.SetArray("RSBot.Skills.Attacks_" + comboMonsterType.SelectedIndex, savedSkills);

        ApplyAttackSkills();
    }

    /// <summary>
    ///     Saves the buffs.
    /// </summary>
    private void SaveBuffs()
    {
        var savedBuffs = listBuffs.Items.Cast<ListViewItem>().Select(p => ((SkillInfo)p.Tag).Id).ToArray();

        PlayerConfig.SetArray("RSBot.Skills.Buffs", savedBuffs);

        ApplyBuffSkills();
    }

    /// <summary>
    ///     Run the event after added the buff from the character
    /// </summary>
    /// <param name="buffInfo">The added <see cref="BuffInfo" /></param>
    private void OnAddBuff(SkillInfo buffInfo)
    {
        try
        {
            var item = new ListViewItem { Text = buffInfo.Record.GetRealName(), Tag = buffInfo };

            item.SubItems.Add("lv. " + buffInfo.Record.Basic_Level);

            listActiveBuffs.Items.Add(item);
            item.LoadSkillImageAsync();
        }
        catch { }
    }

    /// <summary>
    ///     Run the event after removed the buff from the character
    /// </summary>
    /// <param name="buffInfo">The removed <see cref="BuffInfo" /></param>
    private void OnRemoveBuff(SkillInfo removingBuff)
    {
        try
        {
            for (var i = 0; i < listActiveBuffs.Items.Count; i++)
            {
                var listItem = listActiveBuffs.Items[i];
                if (listItem == null)
                    continue;

                var itemBuffInfo = listItem.Tag as SkillInfo;
                if (
                    itemBuffInfo != null
                    && itemBuffInfo.Id == removingBuff.Id
                    && itemBuffInfo.Token == removingBuff.Token
                )
                {
                    listItem?.Remove();
                    return;
                }
            }
        }
        catch { }
    }

    private void BuffTimer_Tick(object sender, EventArgs e)
    {
        // Periodically redraw active buffs so remaining time/arc updates smoothly
        try
        {
            listActiveBuffs.Invalidate();
            listAttackingSkills.Invalidate();
            listBuffs.Invalidate();
            listSkills.Invalidate();
        }
        catch { }
    }

    void DrawRectCooldown(Graphics g, Rectangle rect, float percent, Color baseColor)
    {
        percent = Math.Clamp(percent, 0f, 1f);
        if (percent <= 0f)
            return;

        int w = rect.Width;
        int h = rect.Height;

        using var bmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        using var bg = Graphics.FromImage(bmp);

        bg.Clear(Color.Transparent);

        float cx = w / 2f;
        float cy = h / 2f;

        float maxAngle = 360f * percent;

        float fadeStart = 0.15f;
        float fadeFactor = percent < fadeStart
            ? percent / fadeStart
            : 1f;

        int alpha = (int)(160 * fadeFactor);
        int glowAlpha = (int)(90 * fadeFactor);

        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                float dx = x - cx;
                float dy = cy - y;

                float angle = (float)(Math.Atan2(dx, dy) * 180.0 / Math.PI);
                if (angle < 0) angle += 360f;

                angle = 360f - angle;

                if (angle <= maxAngle)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(alpha, baseColor));
                }
            }
        }

        using (var glowBrush = new SolidBrush(Color.FromArgb(glowAlpha, baseColor)))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(glowBrush,
                rect.Left - 1,
                rect.Top - 1,
                rect.Width + 2,
                rect.Height + 2);
        }

        g.DrawImageUnscaled(bmp, rect.Location);
    }


    private void ListSkill_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        try
        {
            var listView = (SDUI.Controls.ListView)sender;
            var item = e.Item;
            if (item?.Tag is not SkillInfo skill)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // background
            e.DrawBackground();

            // --- ICON RECT
            Rectangle iconRect = listView.GetItemRect(item.Index, ItemBoundsPortion.Icon);

            // --- DRAW ICON
            Image img = null;
            if (!string.IsNullOrEmpty(item.ImageKey) &&
                listView.SmallImageList?.Images.ContainsKey(item.ImageKey) == true)
            {
                img = listView.SmallImageList.Images[item.ImageKey];
            }
            else if (item.ImageIndex >= 0 &&
                     listView.SmallImageList != null &&
                     item.ImageIndex < listView.SmallImageList.Images.Count)
            {
                img = listView.SmallImageList.Images[item.ImageIndex];
            }

            if (img != null)
                g.DrawImage(img, iconRect);

            // --- TEXT (skill name)
            Rectangle textRect = new Rectangle(
                iconRect.Right + 6,
                e.Bounds.Top,
                e.Bounds.Width - (iconRect.Right - e.Bounds.Left) - 6,
                e.Bounds.Height);

            TextRenderer.DrawText(
                g,
                item.Text,
                listView.Font,
                textRect,
                listView.ForeColor,
                TextFormatFlags.Left |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis);

            // --- COOLDOWN RECT
            int size = Math.Min(iconRect.Width, iconRect.Height);
            Rectangle cooldownRect = new Rectangle(
                iconRect.Left + (iconRect.Width - size) / 2,
                iconRect.Top + (iconRect.Height - size) / 2,
                size,
                size);

            var percent = (float)skill.CooldownPercent;
            if (percent <= 0f)
                return;

            using var bgbrush = new SolidBrush(Color.FromArgb(100, Color.Black));
            g.FillRectangle(bgbrush, cooldownRect);

            DrawRectCooldown(
                g,
                cooldownRect,
                percent,
                Color.Black);


            // --- CENTERED SECONDS TEXT
            int seconds = (int)Math.Ceiling(skill.CooldownRemainingMilliseconds / 1000f);
            string label = seconds > 60 ? (seconds / 60f).ToString("0.0") : seconds.ToString();

            using var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using var textBrush = new SolidBrush(Color.White);

            using var font = new Font("Arial", 9, FontStyle.Bold);
            g.DrawString(label, font, textBrush, cooldownRect, sf);
        }
        catch
        {
            // deliberately swallow – draw loop must never crash
        }
    }


    /// <summary>
    ///     Check the skills upgraded or withdrawn
    /// </summary>
    /// <param name="oldSkill">The old skill</param>
    /// <param name="newSkill">The new skill</param>
    private void CheckSkillWithdrawnOrUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        for (var i = 0; i < comboMonsterType.Items.Count; i++)
        {
            var skills = PlayerConfig.GetArray<uint>($"RSBot.Skills.Attacks_{i}").ToList();
            var index = skills.IndexOf(oldSkill.Id);
            if (index == -1)
                continue;

            if (oldSkill.Id == newSkill.Id)
                skills.RemoveAt(index);
            else
                skills[index] = newSkill.Id;

            PlayerConfig.SetArray($"RSBot.Skills.Attacks_{i}", skills);
        }

        var buffs = PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs").ToList();
        var buffIndex = buffs.IndexOf(oldSkill.Id);
        if (buffIndex != -1)
        {
            // remove skill
            if (newSkill.Id == oldSkill.Id)
                buffs.RemoveAt(buffIndex);
            else
                buffs[buffIndex] = newSkill.Id;

            PlayerConfig.SetArray("RSBot.Skills.Buffs", buffs);
        }

        var resurrectionSkill = PlayerConfig.Get<uint>("RSBot.Skills.ResurrectionSkill");
        if (resurrectionSkill == oldSkill.Id)
        {
            if (oldSkill.Id == newSkill.Id)
                SkillManager.ResurrectionSkill = null;
            else
                resurrectionSkill = newSkill.Id;

            PlayerConfig.Set("RSBot.Skills.ResurrectionSkill", resurrectionSkill);
        }

        var selectedImbue = PlayerConfig.Get<uint>("RSBot.Skills.Imbue");
        if (selectedImbue == oldSkill.Id)
        {
            if (oldSkill.Id == newSkill.Id)
                SkillManager.ImbueSkill = null;
            else
                selectedImbue = newSkill.Id;

            PlayerConfig.Set("RSBot.Skills.Imbue", selectedImbue);
        }

        var selectedTeleportSkill = PlayerConfig.Get<uint>("RSBot.Skills.TeleportSkill");
        if (selectedTeleportSkill == oldSkill.Id)
        {
            if (oldSkill.Id == newSkill.Id)
                SkillManager.TeleportSkill = null;
            else
                selectedTeleportSkill = newSkill.Id;

            PlayerConfig.Set("RSBot.Skills.TeleportSkill", selectedTeleportSkill);
        }

        LoadSkills();
        ApplyAttackSkills();
        ApplyBuffSkills();

        PlayerConfig.Save();
    }

    /// <summary>
    ///     Call after skill learned
    /// </summary>
    /// <param name="learnedSkill"></param>
    private void OnSkillLearned(SkillInfo learnedSkill)
    {
        Log.NotifyLang("SkillLearned", learnedSkill.Record.GetRealName());
        LoadSkills();
    }

    /// <summary>
    ///     Call after learned skill upgraded
    /// </summary>
    /// <param name="skill">The old skill.</param>
    /// <param name="newSkill">The new skill.</param>
    private void OnSkillUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        Log.NotifyLang("SkillUpgraded", newSkill);

        CheckSkillWithdrawnOrUpgraded(oldSkill, newSkill);
    }

    /// <summary>
    ///     Core_s the on withdraw skill.
    /// </summary>
    /// <param name="oldSkill">The old skill.</param>
    /// <param name="newSkill">The new skill.</param>
    private void OnWithdrawSkill(SkillInfo oldSkill, SkillInfo newSkill)
    {
        Log.NotifyLang("SkillWithdrawn", oldSkill);

        CheckSkillWithdrawnOrUpgraded(oldSkill, newSkill);
    }

    /// <summary>
    ///     Core_s the on learn skill mastery.
    /// </summary>
    /// <param name="info">The information.</param>
    private void OnLearnSkillMastery(MasteryInfo info)
    {
        Log.NotifyLang("MasteryUpgraded", info.Record.Name);

        LoadSkills();
    }

    /// <summary>
    ///     Main_s the on load character.
    /// </summary>
    private void OnLoadCharacter()
    {
        comboMonsterType.SelectedIndex = 0;

        LoadSkills();

        ApplyAttackSkills();
        ApplyBuffSkills();

        listActiveBuffs.Items.Clear();
    }

    /// <summary>
    ///     Core_s the on resurrection request
    /// </summary>
    private void OnResurrectionRequest()
    {
        const string key = "RSBot.Skills.";
        if (Game.AcceptanceRequest != null && PlayerConfig.Get<bool>(key + checkAcceptResurrection.Name))
            Game.AcceptanceRequest.Accept();
    }

    /// <summary>
    ///     Handles the Click event of the btnMoveAttackSkillDown control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnMoveAttackSkillDown_Click(object sender, EventArgs e)
    {
        listAttackingSkills.MoveSelectedItems(MoveDirection.Down);
        SaveAttacks();
    }

    /// <summary>
    ///     Handles the Click event of the btnMoveAttackSkillUp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnMoveAttackSkillUp_Click(object sender, EventArgs e)
    {
        listAttackingSkills.MoveSelectedItems(MoveDirection.Up);
        SaveAttacks();
    }

    /// <summary>
    ///     Handles the Click event of the btnMoveBuffSkillDown control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnMoveBuffSkillDown_Click(object sender, EventArgs e)
    {
        listBuffs.MoveSelectedItems(MoveDirection.Down);
        SaveBuffs();
    }

    /// <summary>
    ///     Handles the Click event of the btnMoveBuffSkillUp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnMoveBuffSkillUp_Click(object sender, EventArgs e)
    {
        listBuffs.MoveSelectedItems(MoveDirection.Up);
        SaveBuffs();
    }

    /// <summary>
    ///     Handles the Click event of the btnRemoveAttackSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnRemoveAttackSkill_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listAttackingSkills.SelectedItems)
            item.Remove();

        SaveAttacks();
    }

    /// <summary>
    ///     Handles the Click event of the btnRemoveBuffSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnRemoveBuffSkill_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listBuffs.SelectedItems)
            item.Remove();

        SaveBuffs();
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboImue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
    ///     Handles the SelectedIndexChanged event of the comboMonsterType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void comboMonsterType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAttacks(comboMonsterType.SelectedIndex);
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the comboResurrectionSkill control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
    ///     Handles the CheckedChanged event of the filters control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Filter_CheckedChanged(object sender, EventArgs e)
    {
        if (_settingsLoaded)
            ApplySettings();

        LoadSkills();
    }

    /// <summary>
    ///     Handles the Click event of the menuAddAttack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void menuAddAttack_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listSkills.SelectedItems)
        {
            var selectedRefSkill = item.Tag as SkillInfo;

            if (
                listAttackingSkills
                    .Items.Cast<ListViewItem>()
                    .Any(p =>
                        ((SkillInfo)p.Tag).Record.Action_Overlap != 0
                        && ((SkillInfo)p.Tag).Record.Action_Overlap == selectedRefSkill.Record.Action_Overlap
                    )
            )
                continue;

            //if (selectedRefSkill != null && selectedRefSkill.IsAttack)
            if (selectedRefSkill != null && (selectedRefSkill.Record.TargetGroup_Enemy_M || selectedRefSkill.IsAttack))
                listAttackingSkills.Items.Add((ListViewItem)item.Clone());
        }

        SaveAttacks();
    }

    /// <summary>
    ///     Handles the Click event of the menuAddBuff control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void menuAddBuff_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listSkills.SelectedItems)
        {
            var selectedRefSkill = item.Tag as SkillInfo;
            if (
                listBuffs
                    .Items.Cast<ListViewItem>()
                    .Any(p =>
                        ((SkillInfo)p.Tag).Record.Action_Overlap != 0
                        && ((SkillInfo)p.Tag).Record.Action_Overlap == selectedRefSkill.Record.Action_Overlap
                    )
            )
                continue;

            if (selectedRefSkill != null && !selectedRefSkill.IsAttack && !selectedRefSkill.Record.TargetGroup_Enemy_M)
                listBuffs.Items.Add((ListViewItem)item.Clone());
        }

        SaveBuffs();
    }

    private void comboLearnMastery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboLearnMastery.SelectedIndex < 0)
            return;

        var selectedItem = (MasteryComboBoxItem)comboLearnMastery.SelectedItem;
        _selectedMastery = selectedItem;

        PlayerConfig.Set("RSBot.Skills.selectedMastery", selectedItem.Record.NameCode);
    }

    private void listSkills_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (listSkills.SelectedItems.Count <= 0)
            return;

        if (!Kernel.Debug)
            return;

        if (listSkills.SelectedItems[0].Tag is not SkillInfo skillInfo)
            return;

        var itemForm = new SkillProperties(skillInfo.Record);
        itemForm.Show();
    }

    private void useToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listSkills.SelectedItems.Count <= 0)
            return;

        if (listSkills.SelectedItems[0].Tag is not SkillInfo skillInfo)
            return;

        if (skillInfo.IsAttack)
            return;

        skillInfo.Cast(buff: true);
    }

    private void skillContextMenu_Opening(object sender, CancelEventArgs e)
    {
        useToPartyMemberToolStripMenuItem.DropDownItems.Clear();

        if (!Game.Party.IsInParty)
            return;

        foreach (var member in Game.Party.Members)
        {
            if (member == null)
                return;

            useToPartyMemberToolStripMenuItem.DropDown.Items.Add(
                member.Name,
                null,
                (menuItemSender, _2) =>
                {
                    try
                    {
                        if (listSkills.SelectedItems.Count <= 0)
                            return;

                        if (listSkills.SelectedItems[0].Tag is not SkillInfo skillInfo)
                            return;

                        if (skillInfo.IsAttack)
                            return;

                        var menuItem = menuItemSender as ToolStripMenuItem;
                        if (menuItem == null)
                            return;

                        var member = Game.Party.GetMemberByName(menuItem.Text);
                        if (member == null)
                            return;

                        skillInfo.Cast(member.Player.UniqueId, true);
                    }
                    catch { }
                }
            );
        }
    }

    private void listActiveBuffs_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (!Kernel.Debug)
            return;

        var propertiesWindow = listActiveBuffs.SelectedItems[0].Tag switch
        {
            SkillInfo skillInfo => new BuffProperties(skillInfo),
            ItemPerk itemPerk => new BuffProperties(itemPerk),
            _ => null,
        };

        propertiesWindow?.Show();
    }

    private void comboTeleportSkill_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboTeleportSkill.SelectedItem is not TeleportSkillComboBoxItem comboItem)
            return;

        PlayerConfig.Set("RSBot.Skills.TeleportSkill", comboItem.Record.ID);

        SkillManager.TeleportSkill = Game.Player.Skills.GetSkillInfoById(comboItem.Record.ID);
    }

    /// <summary>
    ///     Occurs before Main form is displayed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Load(object sender, EventArgs e)
    {
        _settingsLoaded = false;
        LoadSettings();
        _settingsLoaded = true;
    }

    private class MasteryComboBoxItem
    {
        public byte Level;
        public RefSkillMastery Record;

        public override string ToString()
        {
            return Record.Name + $" lv.{Level}";
        }
    }

    private class TeleportSkillComboBoxItem
    {
        public byte Level;
        public RefSkill Record;

        public override string ToString()
        {
            return Record.GetRealName() + $" lv.{Level}";
        }
    }

    #region Fields

    private readonly object _lock;
    private MasteryComboBoxItem _selectedMastery;
    private bool _settingsLoaded;

    #endregion Fields
}
