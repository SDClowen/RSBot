using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using RSBot.Protection.Components.Player;

namespace RSBot.Protection.ViewModels;

/// <summary>
/// View model for the protection settings that manages HP/MP recovery, bad status, pet care and town return conditions
/// </summary>
public class MainViewModel : ReactiveObject
{
    #region Fields

    private bool _useHPPotions;
    private bool _useMPPotions;
    private bool _useVigorHP;
    private bool _useVigorMP;
    private bool _useHPSkill;
    private bool _useMPSkill;
    private bool _useBadStatusSkill;
    private bool _useAbnormalStatePotions;
    private bool _usePetHP;
    private bool _useHGP;
    private bool _useMountHP;
    private bool _useUniversalPills;
    private bool _autoSummonAttackPet;
    private bool _reviveAttackPet;
    private bool _backTownWhenDead;
    private bool _backTownWhenInventoryFull;
    private bool _backTownWhenNoHPPotions;
    private bool _backTownWhenNoMPPotions;
    private bool _backTownWhenLevelUp;
    private bool _backTownWhenDurabilityLow;
    private bool _backTownWhenNoArrows;
    private bool _backTownWhenPetInventoryFull;
    private bool _stopBotOnReturnToTown;
    private bool _increaseSTR;
    private bool _increaseINT;
    private bool _stopBotWhenIncreasingStats;

    private decimal _hpPotionMin;
    private decimal _mpPotionMin;
    private decimal _vigorHPMin;
    private decimal _vigorMPMin;
    private decimal _hpSkillMin;
    private decimal _mpSkillMin;
    private decimal _petHPMin;
    private decimal _petHGPMin;
    private decimal _mountHPMin;
    private decimal _deadTimeout;
    private decimal _strPoints;
    private decimal _intPoints;

    private SkillInfo _selectedHPSkill;
    private SkillInfo _selectedMPSkill;
    private SkillInfo _selectedBadStatusSkill;

    private List<SkillInfo> _hpSkills;
    private List<SkillInfo> _mpSkills;
    private List<SkillInfo> _badStatusSkills;

    private bool _isRunning;

    #endregion

    #region Properties

    public bool UseHPPotions
    {
        get => _useHPPotions;
        set => this.RaiseAndSetIfChanged(ref _useHPPotions, value);
    }

    public bool UseMPPotions
    {
        get => _useMPPotions;
        set => this.RaiseAndSetIfChanged(ref _useMPPotions, value);
    }

    public bool UseVigorHP
    {
        get => _useVigorHP;
        set => this.RaiseAndSetIfChanged(ref _useVigorHP, value);
    }

    public bool UseVigorMP
    {
        get => _useVigorMP;
        set => this.RaiseAndSetIfChanged(ref _useVigorMP, value);
    }

    public bool UseHPSkill
    {
        get => _useHPSkill;
        set => this.RaiseAndSetIfChanged(ref _useHPSkill, value);
    }

    public bool UseMPSkill
    {
        get => _useMPSkill;
        set => this.RaiseAndSetIfChanged(ref _useMPSkill, value);
    }

    public bool UseBadStatusSkill
    {
        get => _useBadStatusSkill;
        set => this.RaiseAndSetIfChanged(ref _useBadStatusSkill, value);
    }

    public bool UseAbnormalStatePotions
    {
        get => _useAbnormalStatePotions;
        set => this.RaiseAndSetIfChanged(ref _useAbnormalStatePotions, value);
    }

    public bool UsePetHP
    {
        get => _usePetHP;
        set => this.RaiseAndSetIfChanged(ref _usePetHP, value);
    }

    public bool UseHGP
    {
        get => _useHGP;
        set => this.RaiseAndSetIfChanged(ref _useHGP, value);
    }

    public bool UseMountHP
    {
        get => _useMountHP;
        set => this.RaiseAndSetIfChanged(ref _useMountHP, value);
    }

    public bool UseUniversalPills
    {
        get => _useUniversalPills;
        set => this.RaiseAndSetIfChanged(ref _useUniversalPills, value);
    }

    public bool AutoSummonAttackPet
    {
        get => _autoSummonAttackPet;
        set => this.RaiseAndSetIfChanged(ref _autoSummonAttackPet, value);
    }

    public bool ReviveAttackPet
    {
        get => _reviveAttackPet;
        set => this.RaiseAndSetIfChanged(ref _reviveAttackPet, value);
    }

    public bool BackTownWhenDead
    {
        get => _backTownWhenDead;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenDead, value);
    }

    public bool BackTownWhenInventoryFull
    {
        get => _backTownWhenInventoryFull;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenInventoryFull, value);
    }

    public bool BackTownWhenNoHPPotions
    {
        get => _backTownWhenNoHPPotions;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenNoHPPotions, value);
    }

    public bool BackTownWhenNoMPPotions
    {
        get => _backTownWhenNoMPPotions;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenNoMPPotions, value);
    }

    public bool BackTownWhenLevelUp
    {
        get => _backTownWhenLevelUp;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenLevelUp, value);
    }

    public bool BackTownWhenDurabilityLow
    {
        get => _backTownWhenDurabilityLow;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenDurabilityLow, value);
    }

    public bool BackTownWhenNoArrows
    {
        get => _backTownWhenNoArrows;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenNoArrows, value);
    }

    public bool BackTownWhenPetInventoryFull
    {
        get => _backTownWhenPetInventoryFull;
        set => this.RaiseAndSetIfChanged(ref _backTownWhenPetInventoryFull, value);
    }

    public bool StopBotOnReturnToTown
    {
        get => _stopBotOnReturnToTown;
        set => this.RaiseAndSetIfChanged(ref _stopBotOnReturnToTown, value);
    }

    public bool IncreaseSTR
    {
        get => _increaseSTR;
        set => this.RaiseAndSetIfChanged(ref _increaseSTR, value);
    }

    public bool IncreaseINT
    {
        get => _increaseINT;
        set => this.RaiseAndSetIfChanged(ref _increaseINT, value);
    }

    public bool StopBotWhenIncreasingStats
    {
        get => _stopBotWhenIncreasingStats;
        set => this.RaiseAndSetIfChanged(ref _stopBotWhenIncreasingStats, value);
    }

    public decimal HPPotionMin
    {
        get => _hpPotionMin;
        set => this.RaiseAndSetIfChanged(ref _hpPotionMin, value);
    }

    public decimal MPPotionMin
    {
        get => _mpPotionMin;
        set => this.RaiseAndSetIfChanged(ref _mpPotionMin, value);
    }

    public decimal VigorHPMin
    {
        get => _vigorHPMin;
        set => this.RaiseAndSetIfChanged(ref _vigorHPMin, value);
    }

    public decimal VigorMPMin
    {
        get => _vigorMPMin;
        set => this.RaiseAndSetIfChanged(ref _vigorMPMin, value);
    }

    public decimal HPSkillMin
    {
        get => _hpSkillMin;
        set => this.RaiseAndSetIfChanged(ref _hpSkillMin, value);
    }

    public decimal MPSkillMin
    {
        get => _mpSkillMin;
        set => this.RaiseAndSetIfChanged(ref _mpSkillMin, value);
    }

    public decimal PetHPMin
    {
        get => _petHPMin;
        set => this.RaiseAndSetIfChanged(ref _petHPMin, value);
    }

    public decimal PetHGPMin
    {
        get => _petHGPMin;
        set => this.RaiseAndSetIfChanged(ref _petHGPMin, value);
    }

    public decimal MountHPMin
    {
        get => _mountHPMin;
        set => this.RaiseAndSetIfChanged(ref _mountHPMin, value);
    }

    public decimal DeadTimeout
    {
        get => _deadTimeout;
        set => this.RaiseAndSetIfChanged(ref _deadTimeout, value);
    }

    public decimal STRPoints
    {
        get => _strPoints;
        set
        {
            this.RaiseAndSetIfChanged(ref _strPoints, value);
            UpdateMaxPoints();
        }
    }

    public decimal INTPoints
    {
        get => _intPoints;
        set
        {
            this.RaiseAndSetIfChanged(ref _intPoints, value);
            UpdateMaxPoints();
        }
    }

    public SkillInfo SelectedHPSkill
    {
        get => _selectedHPSkill;
        set => this.RaiseAndSetIfChanged(ref _selectedHPSkill, value);
    }

    public SkillInfo SelectedMPSkill
    {
        get => _selectedMPSkill;
        set => this.RaiseAndSetIfChanged(ref _selectedMPSkill, value);
    }

    public SkillInfo SelectedBadStatusSkill
    {
        get => _selectedBadStatusSkill;
        set => this.RaiseAndSetIfChanged(ref _selectedBadStatusSkill, value);
    }

    public List<SkillInfo> HPSkills
    {
        get => _hpSkills;
        set => this.RaiseAndSetIfChanged(ref _hpSkills, value);
    }

    public List<SkillInfo> MPSkills
    {
        get => _mpSkills;
        set => this.RaiseAndSetIfChanged(ref _mpSkills, value);
    }

    public List<SkillInfo> BadStatusSkills
    {
        get => _badStatusSkills;
        set => this.RaiseAndSetIfChanged(ref _badStatusSkills, value);
    }

    public bool IsRunning
    {
        get => _isRunning;
        set => this.RaiseAndSetIfChanged(ref _isRunning, value);
    }

    public string RunButtonText => IsRunning ? "Cancel" : "Run";

    #endregion

    #region Commands

    public ReactiveCommand<Unit, Unit> RunCommand { get; }

    #endregion

    public MainViewModel()
    {
        LoadSettings();
        RefreshSkills();

        RunCommand = ReactiveCommand.Create(ExecuteRun);

        // Subscribe to property changes to save settings
        this.WhenAnyValue(
            x => x.UseHPPotions,
            x => x.UseMPPotions,
            x => x.UseVigorHP,
            x => x.UseVigorMP,
            x => x.UseHPSkill,
            x => x.UseMPSkill,
            x => x.UseBadStatusSkill)
            .Subscribe(_ => SaveSettings());

        this.WhenAnyValue(
            x => x.BackTownWhenPetInventoryFull,
            x => x.StopBotOnReturnToTown,
            x => x.IncreaseSTR,
            x => x.IncreaseINT,
            x => x.StopBotWhenIncreasingStats)
            .Subscribe(_ => SaveSettings());


        this.WhenAnyValue(x => x.BackTownWhenDead,
            x => x.BackTownWhenInventoryFull,
            x => x.BackTownWhenNoHPPotions,
            x => x.BackTownWhenNoMPPotions,
            x => x.BackTownWhenLevelUp,
            x => x.BackTownWhenDurabilityLow,
            x => x.BackTownWhenNoArrows)
            .Subscribe(_ => SaveSettings());

        this.WhenAnyValue(x => x.UseAbnormalStatePotions,
            x => x.UsePetHP,
            x => x.UseHGP,
            x => x.UseMountHP,
            x => x.UseUniversalPills,
            x => x.AutoSummonAttackPet,
            x => x.ReviveAttackPet)
            .Subscribe(_ => SaveSettings());

        this.WhenAnyValue(
            x => x.HPPotionMin,
            x => x.MPPotionMin,
            x => x.VigorHPMin,
            x => x.VigorMPMin,
            x => x.HPSkillMin,
            x => x.MPSkillMin,
            x => x.PetHPMin)
            .Subscribe(_ => SaveSettings());

        this.WhenAnyValue(
            x => x.PetHGPMin,
            x => x.MountHPMin,
            x => x.DeadTimeout,
            x => x.STRPoints,
            x => x.INTPoints)
            .Subscribe(_ => SaveSettings());

        this.WhenAnyValue(
            x => x.SelectedHPSkill,
            x => x.SelectedMPSkill,
            x => x.SelectedBadStatusSkill)
            .Subscribe(_ => SaveSettings());

        SubscribeEvents();
    }

    /// <summary>
    /// Subscribes to game events for skill updates
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnSkillLearned", new Action<SkillInfo>(OnSkillLearned));
        EventManager.SubscribeEvent("OnSkillUpgraded", new Action<SkillInfo, SkillInfo>(OnSkillUpgraded));
        EventManager.SubscribeEvent("OnIncreaseStrength", OnIncreaseStat);
        EventManager.SubscribeEvent("OnIncreaseIntelligence", OnIncreaseStat);
    }

    /// <summary>
    /// Handles the OnLoadCharacter event
    /// </summary>
    private void OnLoadCharacter()
    {
        RefreshSkills();
    }

    /// <summary>
    /// Handles the OnSkillLearned event
    /// </summary>
    private void OnSkillLearned(SkillInfo skill)
    {
        RefreshSkills();
    }

    /// <summary>
    /// Handles the OnSkillUpgraded event
    /// </summary>
    private void OnSkillUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        // TODO: Update old skill ids in config
        RefreshSkills();
    }

    /// <summary>
    /// Handles stat increase events
    /// </summary>
    private void OnIncreaseStat()
    {
        CheckStatPoints();
    }

    private void LoadSettings()
    {
        const string key = "RSBot.Protection.";

        UseHPPotions = PlayerConfig.Get(key + "checkUseHPPotionsPlayer", false);
        UseMPPotions = PlayerConfig.Get(key + "checkUseMPPotionsPlayer", false);
        UseVigorHP = PlayerConfig.Get(key + "checkUseVigorHP", false);
        UseVigorMP = PlayerConfig.Get(key + "checkUseVigorMP", false);
        UseHPSkill = PlayerConfig.Get(key + "checkUseSkillHP", false);
        UseMPSkill = PlayerConfig.Get(key + "checkUseSkillMP", false);
        UseBadStatusSkill = PlayerConfig.Get(key + "checkUseBadStatusSkill", false);
        UseAbnormalStatePotions = PlayerConfig.Get(key + "checkUseAbnormalStatePotion", false);
        UsePetHP = PlayerConfig.Get(key + "checkUsePetHP", false);
        UseHGP = PlayerConfig.Get(key + "checkUseHGP", false);
        UseMountHP = PlayerConfig.Get(key + "checkUseMountHP", false);
        UseUniversalPills = PlayerConfig.Get(key + "checkUseUniversalPills", false);
        AutoSummonAttackPet = PlayerConfig.Get(key + "checkAutoSummonAttackPet", false);
        ReviveAttackPet = PlayerConfig.Get(key + "checkReviveAttackPet", false);
        BackTownWhenDead = PlayerConfig.Get(key + "checkDead", false);
        BackTownWhenInventoryFull = PlayerConfig.Get(key + "checkInventory", false);
        BackTownWhenNoHPPotions = PlayerConfig.Get(key + "checkNoHPPotions", false);
        BackTownWhenNoMPPotions = PlayerConfig.Get(key + "checkNoMPPotions", false);
        BackTownWhenLevelUp = PlayerConfig.Get(key + "checkLevelUp", false);
        BackTownWhenDurabilityLow = PlayerConfig.Get(key + "checkDurability", false);
        BackTownWhenNoArrows = PlayerConfig.Get(key + "checkNoArrows", false);
        BackTownWhenPetInventoryFull = PlayerConfig.Get(key + "checkFullPetInventory", false);
        StopBotOnReturnToTown = PlayerConfig.Get(key + "checkStopBotOnReturnToTown", false);
        IncreaseSTR = PlayerConfig.Get(key + "checkIncStr", false);
        IncreaseINT = PlayerConfig.Get(key + "checkIncInt", false);
        StopBotWhenIncreasingStats = PlayerConfig.Get(key + "checkIncBotStopped", false);

        HPPotionMin = PlayerConfig.Get(key + "numPlayerHPPotionMin", 50m);
        MPPotionMin = PlayerConfig.Get(key + "numPlayerMPPotionMin", 50m);
        VigorHPMin = PlayerConfig.Get(key + "numPlayerHPVigorPotionMin", 50m);
        VigorMPMin = PlayerConfig.Get(key + "numPlayerMPVigorPotionMin", 50m);
        HPSkillMin = PlayerConfig.Get(key + "numPlayerSkillHPMin", 50m);
        MPSkillMin = PlayerConfig.Get(key + "numPlayerSkillMPMin", 50m);
        PetHPMin = PlayerConfig.Get(key + "numPetMinHP", 50m);
        PetHGPMin = PlayerConfig.Get(key + "numPetMinHGP", 50m);
        MountHPMin = PlayerConfig.Get(key + "numMountMinHP", 50m);
        DeadTimeout = PlayerConfig.Get(key + "numDeadTimeout", 30m);
        STRPoints = PlayerConfig.Get(key + "numIncStr", 0m);
        INTPoints = PlayerConfig.Get(key + "numIncInt", 0m);
    }

    private void SaveSettings()
    {
        const string key = "RSBot.Protection.";

        PlayerConfig.Set(key + "checkUseHPPotionsPlayer", UseHPPotions);
        PlayerConfig.Set(key + "checkUseMPPotionsPlayer", UseMPPotions);
        PlayerConfig.Set(key + "checkUseVigorHP", UseVigorHP);
        PlayerConfig.Set(key + "checkUseVigorMP", UseVigorMP);
        PlayerConfig.Set(key + "checkUseSkillHP", UseHPSkill);
        PlayerConfig.Set(key + "checkUseSkillMP", UseMPSkill);
        PlayerConfig.Set(key + "checkUseBadStatusSkill", UseBadStatusSkill);
        PlayerConfig.Set(key + "checkUseAbnormalStatePotion", UseAbnormalStatePotions);
        PlayerConfig.Set(key + "checkUsePetHP", UsePetHP);
        PlayerConfig.Set(key + "checkUseHGP", UseHGP);
        PlayerConfig.Set(key + "checkUseMountHP", UseMountHP);
        PlayerConfig.Set(key + "checkUseUniversalPills", UseUniversalPills);
        PlayerConfig.Set(key + "checkAutoSummonAttackPet", AutoSummonAttackPet);
        PlayerConfig.Set(key + "checkReviveAttackPet", ReviveAttackPet);
        PlayerConfig.Set(key + "checkDead", BackTownWhenDead);
        PlayerConfig.Set(key + "checkInventory", BackTownWhenInventoryFull);
        PlayerConfig.Set(key + "checkNoHPPotions", BackTownWhenNoHPPotions);
        PlayerConfig.Set(key + "checkNoMPPotions", BackTownWhenNoMPPotions);
        PlayerConfig.Set(key + "checkLevelUp", BackTownWhenLevelUp);
        PlayerConfig.Set(key + "checkDurability", BackTownWhenDurabilityLow);
        PlayerConfig.Set(key + "checkNoArrows", BackTownWhenNoArrows);
        PlayerConfig.Set(key + "checkFullPetInventory", BackTownWhenPetInventoryFull);
        PlayerConfig.Set(key + "checkStopBotOnReturnToTown", StopBotOnReturnToTown);
        PlayerConfig.Set(key + "checkIncStr", IncreaseSTR);
        PlayerConfig.Set(key + "checkIncInt", IncreaseINT);
        PlayerConfig.Set(key + "checkIncBotStopped", StopBotWhenIncreasingStats);

        PlayerConfig.Set(key + "numPlayerHPPotionMin", HPPotionMin);
        PlayerConfig.Set(key + "numPlayerMPPotionMin", MPPotionMin);
        PlayerConfig.Set(key + "numPlayerHPVigorPotionMin", VigorHPMin);
        PlayerConfig.Set(key + "numPlayerMPVigorPotionMin", VigorMPMin);
        PlayerConfig.Set(key + "numPlayerSkillHPMin", HPSkillMin);
        PlayerConfig.Set(key + "numPlayerSkillMPMin", MPSkillMin);
        PlayerConfig.Set(key + "numPetMinHP", PetHPMin);
        PlayerConfig.Set(key + "numPetMinHGP", PetHGPMin);
        PlayerConfig.Set(key + "numMountMinHP", MountHPMin);
        PlayerConfig.Set(key + "numDeadTimeout", DeadTimeout);
        PlayerConfig.Set(key + "numIncStr", STRPoints);
        PlayerConfig.Set(key + "numIncInt", INTPoints);

        if (SelectedHPSkill != null)
            PlayerConfig.Set(key + "HpSkill", SelectedHPSkill.Id);
        if (SelectedMPSkill != null)
            PlayerConfig.Set(key + "MpSkill", SelectedMPSkill.Id);
        if (SelectedBadStatusSkill != null)
            PlayerConfig.Set(key + "BadStatusSkill", SelectedBadStatusSkill.Id);
    }

    private void RefreshSkills()
    {
        HPSkills = new List<SkillInfo>();
        MPSkills = new List<SkillInfo>();
        BadStatusSkills = new List<SkillInfo>();

        if (Game.Player == null)
            return;

        foreach (var skill in Game.Player.Skills.KnownSkills)
        {
            if (!skill.Enabled || skill.IsPassive || (skill.Record.Target_Required && !skill.Record.TargetGroup_Self))
                continue;

            // Add to appropriate lists based on skill type
            HPSkills.Add(skill);
            MPSkills.Add(skill);
            BadStatusSkills.Add(skill);

            // Set selected skills based on saved IDs
            var hpSkillId = PlayerConfig.Get<uint>("RSBot.Protection.HpSkill");
            var mpSkillId = PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
            var badStatusSkillId = PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");

            if (skill.Id == hpSkillId)
                SelectedHPSkill = skill;
            if (skill.Id == mpSkillId)
                SelectedMPSkill = skill;
            if (skill.Id == badStatusSkillId)
                SelectedBadStatusSkill = skill;
        }
    }

    private void UpdateMaxPoints()
    {
        var maxPoints = 3m;
        if (STRPoints > maxPoints - INTPoints)
            STRPoints = maxPoints - INTPoints;
        if (INTPoints > maxPoints - STRPoints)
            INTPoints = maxPoints - STRPoints;
    }

    public void CheckStatPoints()
    {
        if (Game.Player.StatPoints < STRPoints + INTPoints)
        {
            IsRunning = false;
            StatPointsHandler.CancellationRequested = true;
        }
    }

    private void ExecuteRun()
    {
        if (IsRunning)
        {
            IsRunning = false;
            StatPointsHandler.CancellationRequested = true;
            return;
        }

        var stepSize = STRPoints + INTPoints;
        if (stepSize == 0)
            return;

        if (Game.Player.StatPoints < stepSize)
            return;

        var availableSteps = Math.Floor(Game.Player.StatPoints / stepSize);
        if (Game.Player.StatPoints == stepSize)
            availableSteps = 1;

        if (availableSteps == 0)
            return;

        StatPointsHandler.CancellationRequested = false;
        StatPointsHandler.IncreaseStatPoints((int)availableSteps);
        IsRunning = true;
    }
} 