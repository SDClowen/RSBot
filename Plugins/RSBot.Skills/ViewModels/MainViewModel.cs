using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using RSBot.Skills.Components;
using RSBot.Skills.Views.Dialog;

namespace RSBot.Skills.ViewModels;

/// <summary>
/// View model for the main skills view that handles skill management and configuration
/// </summary>
public class MainViewModel : ReactiveObject
{
    #region Private Fields

    private SkillInfo _selectedSkill;
    private bool _useSkillsInOrder;
    private bool _noAttack;
    private bool _useTeleportSkill;
    private bool _useDefaultAttack;
    private bool _warlockMode;
    private bool _learnMastery;
    private bool _learnMasteryBotStopped;
    private bool _autoAcceptResurrection;
    private bool _autoResurrectPartyMembers;
    private bool _castBuffsInTowns;
    private bool _castBuffsDuringWalkBack;
    private bool _showAttacks = true;
    private bool _showBuffs = true;
    private bool _hideLowerLevelSkills;
    private decimal _masteryGap;
    private string _selectedMonsterType;
    private SkillInfo _selectedImbueSkill;
    private MasteryComboBoxItem _selectedMastery;
    private SkillInfo _selectedTeleportSkill;
    private SkillInfo _selectedResurrectionSkill;
    private SkillInfo _selectedActiveBuff;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the selected skill
    /// </summary>
    public SkillInfo SelectedSkill
    {
        get => _selectedSkill;
        set => this.RaiseAndSetIfChanged(ref _selectedSkill, value);
    }

    /// <summary>
    /// Gets or sets the collection of skills
    /// </summary>
    public ObservableCollection<SkillInfo> Skills { get; private set; } = new();

    /// <summary>
    /// Gets or sets the collection of attacking skills
    /// </summary>
    public ObservableCollection<SkillInfo> AttackingSkills { get; private set; } = new();

    /// <summary>
    /// Gets or sets the collection of buff skills
    /// </summary>
    public ObservableCollection<SkillInfo> BuffSkills { get; private set; } = new();

    /// <summary>
    /// Gets or sets the collection of active buffs
    /// </summary>
    public ObservableCollection<SkillInfo> ActiveBuffs { get; private set; } = new();

    /// <summary>
    /// Gets or sets the collection of party members
    /// </summary>
    public ObservableCollection<PartyMember> PartyMembers { get; private set; } = new();

    /// <summary>
    /// Gets the collection of monster types
    /// </summary>
    public ObservableCollection<string> MonsterTypes { get; private set; } = new()
    {
        "General (Default)",
        "Champion",
        "Giant",
        "General (Party)",
        "Champion (Party)",
        "Giant (Party)",
        "Elite",
        "Strong",
        "Unique",
        "Event"
    };

    /// <summary>
    /// Gets the collection of imbue skills
    /// </summary>
    public ObservableCollection<SkillInfo> ImbueSkills { get; private set; } = new();

    /// <summary>
    /// Gets the collection of masteries
    /// </summary>
    public ObservableCollection<MasteryComboBoxItem> Masteries { get; private set; } = new();

    /// <summary>
    /// Gets the collection of teleport skills
    /// </summary>
    public ObservableCollection<SkillInfo> TeleportSkills { get; private set; } = new();

    /// <summary>
    /// Gets the collection of resurrection skills
    /// </summary>
    public ObservableCollection<SkillInfo> ResurrectionSkills { get; private set; } = new();

    public bool UseSkillsInOrder
    {
        get => _useSkillsInOrder;
        set
        {
            this.RaiseAndSetIfChanged(ref _useSkillsInOrder, value);
            SaveSettings();
        }
    }

    public bool NoAttack
    {
        get => _noAttack;
        set
        {
            this.RaiseAndSetIfChanged(ref _noAttack, value);
            SaveSettings();
        }
    }

    public bool UseTeleportSkill
    {
        get => _useTeleportSkill;
        set
        {
            this.RaiseAndSetIfChanged(ref _useTeleportSkill, value);
            SaveSettings();
        }
    }

    public bool UseDefaultAttack
    {
        get => _useDefaultAttack;
        set
        {
            this.RaiseAndSetIfChanged(ref _useDefaultAttack, value);
            SaveSettings();
        }
    }

    public bool WarlockMode
    {
        get => _warlockMode;
        set
        {
            this.RaiseAndSetIfChanged(ref _warlockMode, value);
            SaveSettings();
        }
    }

    public bool LearnMastery
    {
        get => _learnMastery;
        set
        {
            this.RaiseAndSetIfChanged(ref _learnMastery, value);
            SaveSettings();
        }
    }

    public bool LearnMasteryBotStopped
    {
        get => _learnMasteryBotStopped;
        set
        {
            this.RaiseAndSetIfChanged(ref _learnMasteryBotStopped, value);
            SaveSettings();
        }
    }

    public bool AutoAcceptResurrection
    {
        get => _autoAcceptResurrection;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoAcceptResurrection, value);
            SaveSettings();
        }
    }

    public bool AutoResurrectPartyMembers
    {
        get => _autoResurrectPartyMembers;
        set
        {
            this.RaiseAndSetIfChanged(ref _autoResurrectPartyMembers, value);
            SaveSettings();
        }
    }

    public bool CastBuffsInTowns
    {
        get => _castBuffsInTowns;
        set
        {
            this.RaiseAndSetIfChanged(ref _castBuffsInTowns, value);
            SaveSettings();
        }
    }

    public bool CastBuffsDuringWalkBack
    {
        get => _castBuffsDuringWalkBack;
        set
        {
            this.RaiseAndSetIfChanged(ref _castBuffsDuringWalkBack, value);
            SaveSettings();
        }
    }

    public bool ShowAttacks
    {
        get => _showAttacks;
        set
        {
            this.RaiseAndSetIfChanged(ref _showAttacks, value);
            RefreshSkills();
            SaveSettings();
        }
    }

    public bool ShowBuffs
    {
        get => _showBuffs;
        set
        {
            this.RaiseAndSetIfChanged(ref _showBuffs, value);
            RefreshSkills();
            SaveSettings();
        }
    }

    public bool HideLowerLevelSkills
    {
        get => _hideLowerLevelSkills;
        set
        {
            this.RaiseAndSetIfChanged(ref _hideLowerLevelSkills, value);
            RefreshSkills();
            SaveSettings();
        }
    }

    public decimal MasteryGap
    {
        get => _masteryGap;
        set
        {
            this.RaiseAndSetIfChanged(ref _masteryGap, value);
            SaveSettings();
        }
    }

    public string SelectedMonsterType
    {
        get => _selectedMonsterType;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedMonsterType, value);
            LoadAttacks(MonsterTypes.IndexOf(value));
        }
    }

    public SkillInfo SelectedImbueSkill
    {
        get => _selectedImbueSkill;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedImbueSkill, value);
            SkillManager.ImbueSkill = value;
            PlayerConfig.Set("RSBot.Skills.Imbue", value?.Id ?? 0);
        }
    }

    public MasteryComboBoxItem SelectedMastery
    {
        get => _selectedMastery;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedMastery, value);
            PlayerConfig.Set("RSBot.Skills.selectedMastery", value?.Record.NameCode);
        }
    }

    public SkillInfo SelectedTeleportSkill
    {
        get => _selectedTeleportSkill;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedTeleportSkill, value);
            SkillManager.TeleportSkill = value;
            PlayerConfig.Set("RSBot.Skills.TeleportSkill", value?.Id ?? 0);
        }
    }

    public SkillInfo SelectedResurrectionSkill
    {
        get => _selectedResurrectionSkill;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedResurrectionSkill, value);
            SkillManager.ResurrectionSkill = value;
            PlayerConfig.Set("RSBot.Skills.ResurrectionSkill", value?.Id ?? 0);
        }
    }

    /// <summary>
    /// Gets or sets the selected active buff
    /// </summary>
    public SkillInfo SelectedActiveBuff
    {
        get => _selectedActiveBuff;
        set => this.RaiseAndSetIfChanged(ref _selectedActiveBuff, value);
    }

    #endregion

    #region Commands

    /// <summary>
    /// Gets the command to add a skill to attacks
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddToAttacksCommand { get; private set; }

    /// <summary>
    /// Gets the command to add a skill to buffs
    /// </summary>
    public ReactiveCommand<Unit, Unit> AddToBuffsCommand { get; private set; }

    /// <summary>
    /// Gets the command to use a skill
    /// </summary>
    public ReactiveCommand<Unit, Unit> UseSkillCommand { get; private set; }

    /// <summary>
    /// Gets the command to use a skill on a party member
    /// </summary>
    public ReactiveCommand<PartyMember, Unit> UseSkillOnPartyMemberCommand { get; private set; }

    /// <summary>
    /// Gets the command to move an attacking skill up
    /// </summary>
    public ReactiveCommand<Unit, Unit> MoveAttackingSkillUpCommand { get; private set; }

    /// <summary>
    /// Gets the command to move an attacking skill down
    /// </summary>
    public ReactiveCommand<Unit, Unit> MoveAttackingSkillDownCommand { get; private set; }

    /// <summary>
    /// Gets the command to remove an attacking skill
    /// </summary>
    public ReactiveCommand<Unit, Unit> RemoveAttackingSkillCommand { get; private set; }

    /// <summary>
    /// Gets the command to move a buff skill up
    /// </summary>
    public ReactiveCommand<Unit, Unit> MoveBuffSkillUpCommand { get; private set; }

    /// <summary>
    /// Gets the command to move a buff skill down
    /// </summary>
    public ReactiveCommand<Unit, Unit> MoveBuffSkillDownCommand { get; private set; }

    /// <summary>
    /// Gets the command to remove a buff skill
    /// </summary>
    public ReactiveCommand<Unit, Unit> RemoveBuffSkillCommand { get; private set; }

    /// <summary>
    /// Gets the command to show skill properties
    /// </summary>
    public ReactiveCommand<Unit, Unit> ShowSkillPropertiesCommand { get; private set; }

    /// <summary>
    /// Gets the command to show buff properties
    /// </summary>
    public ReactiveCommand<Unit, Unit> ShowBuffPropertiesCommand { get; private set; }

    /// <summary>
    /// Gets the command to refresh party members
    /// </summary>
    public ReactiveCommand<Unit, Unit> RefreshPartyMembersCommand { get; private set; }

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class
    /// </summary>
    public MainViewModel()
    {
        
    }

    /// <summary>
    /// Initializes the commands
    /// </summary>
    private void InitializeCommands()
    {
        var canExecuteSkillCommand = this.WhenAnyValue(x => x.SelectedSkill)
            .Select(skill => skill != null);

        AddToAttacksCommand = ReactiveCommand.Create(ExecuteAddToAttacks, canExecuteSkillCommand);
        AddToBuffsCommand = ReactiveCommand.Create(ExecuteAddToBuffs, canExecuteSkillCommand);
        UseSkillCommand = ReactiveCommand.Create(ExecuteUseSkill, canExecuteSkillCommand);
        UseSkillOnPartyMemberCommand = ReactiveCommand.Create<PartyMember>(ExecuteUseSkillOnPartyMember);

        MoveAttackingSkillUpCommand = ReactiveCommand.Create(ExecuteMoveAttackingSkillUp);
        MoveAttackingSkillDownCommand = ReactiveCommand.Create(ExecuteMoveAttackingSkillDown);
        RemoveAttackingSkillCommand = ReactiveCommand.Create(ExecuteRemoveAttackingSkill);

        MoveBuffSkillUpCommand = ReactiveCommand.Create(ExecuteMoveBuffSkillUp);
        MoveBuffSkillDownCommand = ReactiveCommand.Create(ExecuteMoveBuffSkillDown);
        RemoveBuffSkillCommand = ReactiveCommand.Create(ExecuteRemoveBuffSkill);

        ShowSkillPropertiesCommand = ReactiveCommand.Create(ExecuteShowSkillProperties, 
            this.WhenAnyValue(x => x.SelectedSkill)
                .Select(skill => skill != null && Kernel.Debug));

        ShowBuffPropertiesCommand = ReactiveCommand.Create(ExecuteShowBuffProperties,
            this.WhenAnyValue(x => x.SelectedSkill)
                .Select(skill => skill != null && Kernel.Debug));

        RefreshPartyMembersCommand = ReactiveCommand.Create(ExecuteRefreshPartyMembers);
    }

    private void ExecuteAddToAttacks()
    {
        if (SelectedSkill == null)
            return;

        if (AttackingSkills.Any(s => s.Record.Action_Overlap != 0 && s.Record.Action_Overlap == SelectedSkill.Record.Action_Overlap))
            return;

        if (SelectedSkill.Record.TargetGroup_Enemy_M || SelectedSkill.IsAttack)
        {
            AttackingSkills.Add(SelectedSkill);
            SaveAttacks();
        }
    }

    private void ExecuteAddToBuffs()
    {
        if (SelectedSkill == null)
            return;

        if (BuffSkills.Any(s => s.Record.Action_Overlap != 0 && s.Record.Action_Overlap == SelectedSkill.Record.Action_Overlap))
            return;

        if (!SelectedSkill.IsAttack && !SelectedSkill.Record.TargetGroup_Enemy_M)
        {
            BuffSkills.Add(SelectedSkill);
            SaveBuffs();
        }
    }

    private void ExecuteUseSkill()
    {
        SelectedSkill?.Cast(buff: true);
    }

    private void ExecuteUseSkillOnPartyMember(PartyMember member)
    {
        if (SelectedSkill == null || member == null)
            return;

        SelectedSkill.Cast(member.Player.UniqueId, true);
    }

    private void ExecuteMoveAttackingSkillUp()
    {
        var selectedIndex = AttackingSkills.IndexOf(SelectedSkill);
        if (selectedIndex <= 0)
            return;

        AttackingSkills.Move(selectedIndex, selectedIndex - 1);
        SaveAttacks();
    }

    private void ExecuteMoveAttackingSkillDown()
    {
        var selectedIndex = AttackingSkills.IndexOf(SelectedSkill);
        if (selectedIndex < 0 || selectedIndex >= AttackingSkills.Count - 1)
            return;

        AttackingSkills.Move(selectedIndex, selectedIndex + 1);
        SaveAttacks();
    }

    private void ExecuteRemoveAttackingSkill()
    {
        if (SelectedSkill == null)
            return;

        AttackingSkills.Remove(SelectedSkill);
        SaveAttacks();
    }

    private void ExecuteMoveBuffSkillUp()
    {
        var selectedIndex = BuffSkills.IndexOf(SelectedSkill);
        if (selectedIndex <= 0)
            return;

        BuffSkills.Move(selectedIndex, selectedIndex - 1);
        SaveBuffs();
    }

    private void ExecuteMoveBuffSkillDown()
    {
        var selectedIndex = BuffSkills.IndexOf(SelectedSkill);
        if (selectedIndex < 0 || selectedIndex >= BuffSkills.Count - 1)
            return;

        BuffSkills.Move(selectedIndex, selectedIndex + 1);
        SaveBuffs();
    }

    private void ExecuteRemoveBuffSkill()
    {
        if (SelectedSkill == null)
            return;

        BuffSkills.Remove(SelectedSkill);
        SaveBuffs();
    }

    private void ExecuteShowSkillProperties()
    {
        if (SelectedSkill == null || !Kernel.Debug)
            return;

        var propertiesWindow = new SkillProperties(SelectedSkill.Record);
        propertiesWindow.Show();
    }

    private void ExecuteShowBuffProperties()
    {
        if (SelectedSkill == null || !Kernel.Debug)
            return;

        var propertiesWindow = new BuffProperties(SelectedSkill);
        propertiesWindow.Show();
    }

    private void ExecuteRefreshPartyMembers()
    {
        InitializePartyMembers();
    }

    private void InitializePartyMembers()
    {
        PartyMembers.Clear();

        if (!Game.Party.IsInParty)
            return;

        foreach (var member in Game.Party.Members)
        {
            if (member == null)
                continue;

            PartyMembers.Add(new PartyMember
            {
                Name = member.Name,
                Player = member.Player
            });
        }
    }

    /// <summary>
    /// Loads the character data when a character is loaded
    /// </summary>
    public void LoadCharacterData()
    {
        LoadSettings();
        InitializeCommands();
        InitializePartyMembers();
        InitializeActiveBuffs();

        LoadMasteries();
        LoadTeleportSkills();
        LoadResurrectionSkills();
        LoadImbueSkills();
        RefreshSkills();
        LoadAttacks();
        LoadBuffs();
        InitializePartyMembers();
        InitializeActiveBuffs();
    }

    /// <summary>
    /// Loads the settings from the configuration
    /// </summary>
    private void LoadSettings()
    {
        const string key = "RSBot.Skills.";

        UseSkillsInOrder = PlayerConfig.Get(key + "UseSkillsInOrder", false);
        NoAttack = PlayerConfig.Get(key + "NoAttack", false);
        UseTeleportSkill = PlayerConfig.Get(key + "UseTeleportSkill", false);
        UseDefaultAttack = PlayerConfig.Get(key + "UseDefaultAttack", true);
        WarlockMode = PlayerConfig.Get(key + "WarlockMode", false);
        LearnMastery = PlayerConfig.Get(key + "LearnMastery", false);
        LearnMasteryBotStopped = PlayerConfig.Get(key + "LearnMasteryBotStopped", false);
        AutoAcceptResurrection = PlayerConfig.Get(key + "AutoAcceptResurrection", true);
        AutoResurrectPartyMembers = PlayerConfig.Get(key + "AutoResurrectPartyMembers", false);
        CastBuffsInTowns = PlayerConfig.Get(key + "CastBuffsInTowns", false);
        CastBuffsDuringWalkBack = PlayerConfig.Get(key + "CastBuffsDuringWalkBack", true);
        ShowAttacks = PlayerConfig.Get(key + "ShowAttacks", true);
        ShowBuffs = PlayerConfig.Get(key + "ShowBuffs", true);
        HideLowerLevelSkills = PlayerConfig.Get(key + "HideLowerLevelSkills", false);
        MasteryGap = PlayerConfig.Get(key + "MasteryGap", 0m);
    }

    /// <summary>
    /// Saves the settings to the configuration
    /// </summary>
    private void SaveSettings()
    {
        const string key = "RSBot.Skills.";

        PlayerConfig.Set(key + "UseSkillsInOrder", UseSkillsInOrder);
        PlayerConfig.Set(key + "NoAttack", NoAttack);
        PlayerConfig.Set(key + "UseTeleportSkill", UseTeleportSkill);
        PlayerConfig.Set(key + "UseDefaultAttack", UseDefaultAttack);
        PlayerConfig.Set(key + "WarlockMode", WarlockMode);
        PlayerConfig.Set(key + "LearnMastery", LearnMastery);
        PlayerConfig.Set(key + "LearnMasteryBotStopped", LearnMasteryBotStopped);
        PlayerConfig.Set(key + "AutoAcceptResurrection", AutoAcceptResurrection);
        PlayerConfig.Set(key + "AutoResurrectPartyMembers", AutoResurrectPartyMembers);
        PlayerConfig.Set(key + "CastBuffsInTowns", CastBuffsInTowns);
        PlayerConfig.Set(key + "CastBuffsDuringWalkBack", CastBuffsDuringWalkBack);
        PlayerConfig.Set(key + "ShowAttacks", ShowAttacks);
        PlayerConfig.Set(key + "ShowBuffs", ShowBuffs);
        PlayerConfig.Set(key + "HideLowerLevelSkills", HideLowerLevelSkills);
        PlayerConfig.Set(key + "MasteryGap", MasteryGap);
    }

    /// <summary>
    /// Loads the masteries for the current character
    /// </summary>
    private void LoadMasteries()
    {
        Masteries.Clear();

        foreach (var mastery in Game.Player.Skills.Masteries)
        {
            Masteries.Add(new MasteryComboBoxItem
            {
                Record = mastery.Record,
                Level = mastery.Level
            });
        }

        var selectedMastery = PlayerConfig.Get<string>("RSBot.Skills.selectedMastery");
        SelectedMastery = Masteries.FirstOrDefault(m => m.Record.NameCode == selectedMastery);
    }

    /// <summary>
    /// Loads the teleport skills for the current character
    /// </summary>
    private void LoadTeleportSkills()
    {
        TeleportSkills.Clear();

        var selectedTeleportSkillId = PlayerConfig.Get<uint>("RSBot.Skills.TeleportSkill");
        foreach (var skill in Game.Player.Skills.KnownSkills.Where(s =>
                     s.CanBeCasted && s.Record.Action_ActionDuration == 0 && s.Record.Params[2] == 500))
        {
            TeleportSkills.Add(skill);
            if (skill.Id == selectedTeleportSkillId)
                SelectedTeleportSkill = skill;
        }
    }

    /// <summary>
    /// Loads the resurrection skills for the current character
    /// </summary>
    private void LoadResurrectionSkills()
    {
        ResurrectionSkills.Clear();

        var selectedResurrectionSkillId = PlayerConfig.Get<uint>("RSBot.Skills.ResurrectionSkill");
        foreach (var skill in Game.Player.Skills.KnownSkills.Where(
                         s => s.Record != null && s.Record.TargetEtc_SelectDeadBody && !s.Record.TargetGroup_Enemy_M))
        {
            ResurrectionSkills.Add(skill);
            if (skill.Id == selectedResurrectionSkillId)
                SelectedResurrectionSkill = skill;
        }
    }

    /// <summary>
    /// Loads the imbue skills for the current character
    /// </summary>
    private void LoadImbueSkills()
    {
        ImbueSkills.Clear();

        ImbueSkills.Add(null);

        var selectedImbueSkillId = PlayerConfig.Get<uint>("RSBot.Skills.Imbue");
        foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.IsImbue && s.Enabled))
        {
            ImbueSkills.Add(skill);
            if (skill.Id == selectedImbueSkillId)
                SelectedImbueSkill = skill;
        }
    }

    /// <summary>
    /// Refreshes the skills list based on current filters
    /// </summary>
    private void RefreshSkills()
    {
        if (!Game.Ready)
            return;

        Skills.Clear();

        if (Game.Player.TryGetAbilitySkills(out var abilitySkills))
        {
            foreach (var skill in abilitySkills)
            {
                if (skill.IsPassive)
                    continue;

                if (!ShowAttacks && skill.Record.TargetGroup_Enemy_M)
                    continue;

                if (!ShowBuffs && !skill.Record.TargetGroup_Enemy_M)
                    continue;

                Skills.Add(skill);
            }
        }

        foreach (var skill in Game.Player.Skills.KnownSkills.Where(s => s.Enabled && s.Record.ReqCommon_Mastery1 != 1000))
        {
            if (skill.IsPassive)
                continue;

            if (skill.IsImbue)
                continue;

            if (HideLowerLevelSkills && skill.IsLowLevel())
                continue;

            if (!ShowAttacks && skill.Record.TargetGroup_Enemy_M)
                continue;

            if (!ShowBuffs && !skill.Record.TargetGroup_Enemy_M)
                continue;

            Skills.Add(skill);
        }
    }

    /// <summary>
    /// Loads the attacking skills for the specified monster type
    /// </summary>
    private void LoadAttacks(int index = 0)
    {
        AttackingSkills.Clear();

        var skillIds = PlayerConfig.GetArray<uint>("RSBot.Skills.Attacks_" + index);
        foreach (var skillId in skillIds)
        {
            var skillInfo = Game.Player.Skills.GetSkillInfoById(skillId);
            if (skillInfo != null)
                AttackingSkills.Add(skillInfo);
        }
    }

    /// <summary>
    /// Loads the buff skills
    /// </summary>
    private void LoadBuffs()
    {
        BuffSkills.Clear();

        var skillIds = PlayerConfig.GetArray<uint>("RSBot.Skills.Buffs");
        foreach (var skillId in skillIds)
        {
            var skillInfo = Game.Player.Skills.GetSkillInfoById(skillId);
            if (skillInfo != null)
                BuffSkills.Add(skillInfo);
        }
    }

    /// <summary>
    /// Saves the attacking skills
    /// </summary>
    private void SaveAttacks()
    {
        var index = MonsterTypes.IndexOf(SelectedMonsterType);
        var skillIds = AttackingSkills.Select(skill => skill.Id).ToArray();
        PlayerConfig.SetArray("RSBot.Skills.Attacks_" + index, skillIds);
    }

    /// <summary>
    /// Saves the buff skills
    /// </summary>
    private void SaveBuffs()
    {
        var skillIds = BuffSkills.Select(skill => skill.Id).ToArray();
        PlayerConfig.SetArray("RSBot.Skills.Buffs", skillIds);
    }

    #region Event Handlers

    public void OnSkillLearned(SkillInfo learnedSkill)
    {
        if (!Game.Ready) return;
        RefreshSkills();
    }

    public void OnSkillUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        if (!Game.Ready) return;
        CheckSkillWithdrawnOrUpgraded(oldSkill, newSkill);
    }

    public void OnWithdrawSkill(SkillInfo oldSkill, SkillInfo newSkill)
    {
        if (!Game.Ready) return;
        CheckSkillWithdrawnOrUpgraded(oldSkill, newSkill);
    }

    private void CheckSkillWithdrawnOrUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        if (!Game.Ready) return;

        var attackIndex = AttackingSkills.IndexOf(oldSkill);
        if (attackIndex != -1)
        {
            AttackingSkills[attackIndex] = newSkill;
            SaveAttacks();
        }

        var buffIndex = BuffSkills.IndexOf(oldSkill);
        if (buffIndex != -1)
        {
            BuffSkills[buffIndex] = newSkill;
            SaveBuffs();
        }

        RefreshSkills();
    }

    public void OnLearnSkillMastery(MasteryInfo info)
    {
        if (!Game.Ready) return;
        LoadMasteries();
    }

    public void OnAddBuff(SkillInfo buffInfo)
    {
        if (!Game.Ready) return;
        if (!ActiveBuffs.Contains(buffInfo))
            ActiveBuffs.Add(buffInfo);
    }

    public void OnRemoveBuff(SkillInfo removingBuff)
    {
        if (!Game.Ready) return;
        var buffToRemove = ActiveBuffs.FirstOrDefault(b => 
            b.Id == removingBuff.Id && b.Token == removingBuff.Token);
        
        if (buffToRemove != null)
            ActiveBuffs.Remove(buffToRemove);
    }

    public void OnResurrectionRequest()
    {
        if (!Game.Ready) return;
        if (AutoAcceptResurrection)
            Game.AcceptanceRequest?.Accept();
    }

    public void OnSpUpdated()
    {
        if (!Game.Ready) return;
        if (!LearnMastery || SelectedMastery == null)
            return;

        while (SelectedMastery.Level + MasteryGap < Game.Player.Level)
        {
            if (!LearnMasteryBotStopped && !Kernel.Bot.Running)
                break;

            var nextMasteryLevel = Game.ReferenceManager.GetRefLevel((byte)(SelectedMastery.Level + 1));

            if (nextMasteryLevel.Exp_M > Game.Player.SkillPoints)
            {
                Log.Debug($"Auto. upping mastery cancelled due to insufficient skill points. Required: {nextMasteryLevel.Exp_M}");
                break;
            }

            Log.Notify($"Auto. train mastery [{SelectedMastery.Record.Name} to lv. {nextMasteryLevel}");
            LearnMasteryHandler.LearnMastery(SelectedMastery.Record.ID);
            Thread.Sleep(500);
        }
    }

    public void OnAddItemPerk(uint targetId, uint token)
    {
        if (!Game.Ready) return;
        if (targetId != Game.Player.UniqueId)
            return;

        var perk = Game.Player.State.ActiveItemPerks[token];
        if (perk?.Item != null)
            OnAddBuff(new SkillInfo(perk.Value, true));
    }

    public void OnRemoveItemPerk(uint targetId, ItemPerk removedPerk)
    {
        if (!Game.Ready) return;
        if (targetId != Game.Player.UniqueId || removedPerk?.Item == null)
            return;

        OnRemoveBuff(new SkillInfo(removedPerk.Value, true));
    }

    #endregion

    /// <summary>
    /// Applies the attack skills to the skill manager
    /// </summary>
    private void ApplyAttackSkills()
    {
        foreach (var collection in SkillManager.Skills.Values)
            collection.Clear();

        for (var i = 0; i < MonsterTypes.Count; i++)
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
    /// Applies the buff skills to the skill manager
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

    private void InitializeActiveBuffs()
    {
        ActiveBuffs.Clear();

        foreach (var buff in Game.Player.State.ActiveBuffs)
        {
            if (buff == null)
                continue;

            OnAddBuff(buff);
        }

        foreach (var perk in Game.Player.State.ActiveItemPerks.Values)
        {
            if (perk?.Item == null)
                continue;

            OnAddBuff(new SkillInfo(perk.Value, true));
        }
    }
}

/// <summary>
/// Represents a mastery item in the combo box
/// </summary>
public class MasteryComboBoxItem
{
    public byte Level { get; set; }
    public RefSkillMastery Record { get; set; }

    public override string ToString()
    {
        return $"{Record.Name} (Lv. {Level})";
    }
}

/// <summary>
/// Represents a party member
/// </summary>
public class PartyMember
{
    public string Name { get; set; }
    public SpawnedPlayer Player { get; set; }
} 