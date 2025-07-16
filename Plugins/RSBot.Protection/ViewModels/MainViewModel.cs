using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using RSBot.Protection.Components.Player;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace RSBot.Protection.ViewModels;

public class MainViewModel : ReactiveObject
{
    private bool _settingsLoaded;
    private bool _skillSettingsLoaded;
    private bool _statIncreaseRunning;

    public MainViewModel()
    {
        SubscribeEvents();

        RunCommand = ReactiveCommand.Create(ExecuteRunCommand); 
        LoadedCommand = ReactiveCommand.Create(LoadSettings);
    }

    #region Properties

    // Health/Mana Recovery
    public bool UseHPPotionsPlayer { get; set; }
    public int PlayerHPPotionMin { get; set; } = 75;
    public bool UseMPPotionsPlayer { get; set; }
    public int PlayerMPPotionMin { get; set; } = 75;
    public bool UseVigorHP { get; set; }
    public int PlayerHPVigorPotionMin { get; set; } = 50;
    public bool UseVigorMP { get; set; }
    public int PlayerMPVigorPotionMin { get; set; } = 50;
    public bool UseSkillHP { get; set; }
    public int PlayerSkillHPMin { get; set; } = 50;
    public bool UseSkillMP { get; set; }
    public int PlayerSkillMPMin { get; set; } = 50;

    // Bad Status
    public bool UseUniversalPills { get; set; } = true;
    public bool UseBadStatusSkill { get; set; }

    // Pet Recovery
    public bool UsePetHP { get; set; } = true;
    public int PetMinHP { get; set; } = 80;
    public bool UseHGP { get; set; } = true;
    public int PetMinHGP { get; set; } = 90;
    public bool UseAbnormalStatePotion { get; set; } = true;
    public bool ReviveAttackPet { get; set; }
    public bool AutoSummonAttackPet { get; set; }

    // Back to Town
    public bool Dead { get; set; }
    public int DeadTimeout { get; set; } = 30;
    public bool StopBotOnReturnToTown { get; set; }
    public bool NoArrows { get; set; }
    public bool Inventory { get; set; }
    public bool FullPetInventory { get; set; }
    public bool NoHPPotions { get; set; }
    public int HPPotionsLeft { get; set; } = 15;
    public bool NoMPPotions { get; set; }
    public int MPPotionsLeft { get; set; } = 15;
    public bool Durability { get; set; }
    public bool LevelUp { get; set; }
    public bool ShardFatigue { get; set; }
    public int ShardFatigueMinToDC { get; set; } = 15;

    // Stat Points
    public bool IncInt { get; set; }
    public int IncIntValue { get; set; }
    public bool IncStr { get; set; }
    public int IncStrValue { get; set; }
    public bool IncBotStopped { get; set; } = true;

    // Skills
    public ObservableCollection<SkillInfo> Skills { get; } = new();
    public SkillInfo SelectedSkillHP { get; set; }
    public SkillInfo SelectedSkillMP { get; set; }
    public SkillInfo SelectedBadStatusSkill { get; set; }

    // Commands
    public ReactiveCommand<Unit, Unit> RunCommand { get; }
    public ReactiveCommand<Unit, Unit> LoadedCommand { get; }
    public string RunButtonText => _statIncreaseRunning ? "Cancel" : "Run";
    #endregion

    #region Methods

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

        this.WhenAnyValue(
            x => x.UseHPPotionsPlayer,
            x => x.PlayerHPPotionMin,
            x => x.UseMPPotionsPlayer,
            x => x.PlayerMPPotionMin,
            x => x.UseVigorHP,
            x => x.PlayerHPVigorPotionMin,
            x => x.UseVigorMP).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.PlayerMPVigorPotionMin,
            x => x.UseSkillHP,
            x => x.PlayerSkillHPMin,
            x => x.UseSkillMP,
            x => x.PlayerSkillMPMin,
            x => x.UseUniversalPills,
            x => x.UseBadStatusSkill).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.UsePetHP,
            x => x.PetMinHP,
            x => x.UseHGP,
            x => x.PetMinHGP,
            x => x.UseAbnormalStatePotion,
            x => x.ReviveAttackPet,
            x => x.AutoSummonAttackPet).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.Dead,
            x => x.DeadTimeout,
            x => x.StopBotOnReturnToTown,
            x => x.NoArrows,
            x => x.Inventory,
            x => x.FullPetInventory,
            x => x.NoHPPotions).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.HPPotionsLeft,
            x => x.NoMPPotions,
            x => x.MPPotionsLeft,
            x => x.Durability,
            x => x.LevelUp,
            x => x.ShardFatigue,
            x => x.ShardFatigueMinToDC).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.IncInt,
            x => x.IncIntValue,
            x => x.IncStr,
            x => x.IncStrValue,
            x => x.IncBotStopped,
            x => x.SelectedSkillHP,
            x => x.SelectedSkillMP).Subscribe(_ => {
                if (_settingsLoaded)
                    ApplySettings();
            });

        this.WhenAnyValue(
            x => x.SelectedBadStatusSkill
        ).Subscribe(_ => {
            if (_settingsLoaded)
                ApplySettings();
        });
    }

    private void LoadSettings()
    {
        const string key = "RSBot.Protection.";

        // Health/Mana Recovery
        UseHPPotionsPlayer = PlayerConfig.Get(key + "checkUseHPPotionsPlayer", true);
        PlayerHPPotionMin = PlayerConfig.Get(key + "numPlayerHPPotionMin", 75);
        UseMPPotionsPlayer = PlayerConfig.Get(key + "checkUseMPPotionsPlayer", true);
        PlayerMPPotionMin = PlayerConfig.Get(key + "numPlayerMPPotionMin", 75);
        UseVigorHP = PlayerConfig.Get(key + "checkUseVigorHP", false);
        PlayerHPVigorPotionMin = PlayerConfig.Get(key + "numPlayerHPVigorPotionMin", 50);
        UseVigorMP = PlayerConfig.Get(key + "checkUseVigorMP", false);
        PlayerMPVigorPotionMin = PlayerConfig.Get(key + "numPlayerMPVigorPotionMin", 50);
        UseSkillHP = PlayerConfig.Get(key + "checkUseSkillHP", false);
        PlayerSkillHPMin = PlayerConfig.Get(key + "numPlayerSkillHPMin", 50);
        UseSkillMP = PlayerConfig.Get(key + "checkUseSkillMP", false);
        PlayerSkillMPMin = PlayerConfig.Get(key + "numPlayerSkillMPMin", 50);

        // Bad Status
        UseUniversalPills = PlayerConfig.Get(key + "checkUseUniversalPills", true);
        UseBadStatusSkill = PlayerConfig.Get(key + "checkUseBadStatusSkill", false);

        // Pet Recovery
        UsePetHP = PlayerConfig.Get(key + "checkUsePetHP", true);
        PetMinHP = PlayerConfig.Get(key + "numPetMinHP", 80);
        UseHGP = PlayerConfig.Get(key + "checkUseHGP", true);
        PetMinHGP = PlayerConfig.Get(key + "numPetMinHGP", 90);
        UseAbnormalStatePotion = PlayerConfig.Get(key + "checkUseAbnormalStatePotion", true);
        ReviveAttackPet = PlayerConfig.Get(key + "checkReviveAttackPet", false);
        AutoSummonAttackPet = PlayerConfig.Get(key + "checkAutoSummonAttackPet", false);

        // Back to Town
        Dead = PlayerConfig.Get(key + "checkDead", false);
        DeadTimeout = PlayerConfig.Get(key + "numDeadTimeout", 30);
        StopBotOnReturnToTown = PlayerConfig.Get(key + "checkStopBotOnReturnToTown", false);
        NoArrows = PlayerConfig.Get(key + "checkNoArrows", false);
        Inventory = PlayerConfig.Get(key + "checkInventory", false);
        FullPetInventory = PlayerConfig.Get(key + "checkFullPetInventory", false);
        NoHPPotions = PlayerConfig.Get(key + "checkNoHPPotions", false);
        HPPotionsLeft = PlayerConfig.Get(key + "numHPPotionsLeft", 15);
        NoMPPotions = PlayerConfig.Get(key + "checkNoMPPotions", false);
        MPPotionsLeft = PlayerConfig.Get(key + "numMPPotionsLeft", 15);
        Durability = PlayerConfig.Get(key + "checkDurability", false);
        LevelUp = PlayerConfig.Get(key + "checkLevelUp", false);
        ShardFatigue = PlayerConfig.Get(key + "checkShardFatigue", false);
        ShardFatigueMinToDC = PlayerConfig.Get(key + "numShardFatigueMinToDC", 15);

        // Stat Points
        IncInt = PlayerConfig.Get(key + "checkIncInt", false);
        IncIntValue = PlayerConfig.Get(key + "numIncInt", 0);
        IncStr = PlayerConfig.Get(key + "checkIncStr", false);
        IncStrValue = PlayerConfig.Get(key + "numIncStr", 0);
        IncBotStopped = PlayerConfig.Get(key + "checkIncBotStopped", true);

        _settingsLoaded = true;
    }

    private void ApplySettings()
    {
        const string key = "RSBot.Protection.";

        // Health/Mana Recovery
        PlayerConfig.Set(key + "checkUseHPPotionsPlayer", UseHPPotionsPlayer);
        PlayerConfig.Set(key + "numPlayerHPPotionMin", PlayerHPPotionMin);
        PlayerConfig.Set(key + "checkUseMPPotionsPlayer", UseMPPotionsPlayer);
        PlayerConfig.Set(key + "numPlayerMPPotionMin", PlayerMPPotionMin);
        PlayerConfig.Set(key + "checkUseVigorHP", UseVigorHP);
        PlayerConfig.Set(key + "numPlayerHPVigorPotionMin", PlayerHPVigorPotionMin);
        PlayerConfig.Set(key + "checkUseVigorMP", UseVigorMP);
        PlayerConfig.Set(key + "numPlayerMPVigorPotionMin", PlayerMPVigorPotionMin);
        PlayerConfig.Set(key + "checkUseSkillHP", UseSkillHP);
        PlayerConfig.Set(key + "numPlayerSkillHPMin", PlayerSkillHPMin);
        PlayerConfig.Set(key + "checkUseSkillMP", UseSkillMP);
        PlayerConfig.Set(key + "numPlayerSkillMPMin", PlayerSkillMPMin);

        // Bad Status
        PlayerConfig.Set(key + "checkUseUniversalPills", UseUniversalPills);
        PlayerConfig.Set(key + "checkUseBadStatusSkill", UseBadStatusSkill);

        // Pet Recovery
        PlayerConfig.Set(key + "checkUsePetHP", UsePetHP);
        PlayerConfig.Set(key + "numPetMinHP", PetMinHP);
        PlayerConfig.Set(key + "checkUseHGP", UseHGP);
        PlayerConfig.Set(key + "numPetMinHGP", PetMinHGP);
        PlayerConfig.Set(key + "checkUseAbnormalStatePotion", UseAbnormalStatePotion);
        PlayerConfig.Set(key + "checkReviveAttackPet", ReviveAttackPet);
        PlayerConfig.Set(key + "checkAutoSummonAttackPet", AutoSummonAttackPet);

        // Back to Town
        PlayerConfig.Set(key + "checkDead", Dead);
        PlayerConfig.Set(key + "numDeadTimeout", DeadTimeout);
        PlayerConfig.Set(key + "checkStopBotOnReturnToTown", StopBotOnReturnToTown);
        PlayerConfig.Set(key + "checkNoArrows", NoArrows);
        PlayerConfig.Set(key + "checkInventory", Inventory);
        PlayerConfig.Set(key + "checkFullPetInventory", FullPetInventory);
        PlayerConfig.Set(key + "checkNoHPPotions", NoHPPotions);
        PlayerConfig.Set(key + "numHPPotionsLeft", HPPotionsLeft);
        PlayerConfig.Set(key + "checkNoMPPotions", NoMPPotions);
        PlayerConfig.Set(key + "numMPPotionsLeft", MPPotionsLeft);
        PlayerConfig.Set(key + "checkDurability", Durability);
        PlayerConfig.Set(key + "checkLevelUp", LevelUp);
        PlayerConfig.Set(key + "checkShardFatigue", ShardFatigue);
        PlayerConfig.Set(key + "numShardFatigueMinToDC", ShardFatigueMinToDC);

        // Stat Points
        PlayerConfig.Set(key + "checkIncInt", IncInt);
        PlayerConfig.Set(key + "numIncInt", IncIntValue);
        PlayerConfig.Set(key + "checkIncStr", IncStr);
        PlayerConfig.Set(key + "numIncStr", IncStrValue);
        PlayerConfig.Set(key + "checkIncBotStopped", IncBotStopped);

        // Skills
        if (SelectedSkillHP != null)
            PlayerConfig.Set(key + "HpSkill", SelectedSkillHP.Id);
        if (SelectedSkillMP != null)
            PlayerConfig.Set(key + "MpSkill", SelectedSkillMP.Id);
        if (SelectedBadStatusSkill != null)
            PlayerConfig.Set(key + "BadStatusSkill", SelectedBadStatusSkill.Id);
    }

    private void RefreshSkills()
    {
        _skillSettingsLoaded = false;

        Skills.Clear();

        foreach (var skill in Game.Player.Skills.KnownSkills)
        {
            if (!skill.Enabled)
                continue;

            if (skill.IsPassive)
                continue;

            if (skill.Record.Target_Required && !skill.Record.TargetGroup_Self)
                continue;

            Skills.Add(skill);

            // Set selected skills from config
            var skillId = PlayerConfig.Get<uint>("RSBot.Protection.BadStatusSkill");
            if (skillId == skill.Id)
                SelectedBadStatusSkill = skill;

            skillId = PlayerConfig.Get<uint>("RSBot.Protection.HpSkill");
            if (skillId == skill.Id)
                SelectedSkillHP = skill;

            skillId = PlayerConfig.Get<uint>("RSBot.Protection.MpSkill");
            if (skillId == skill.Id)
                SelectedSkillMP = skill;
        }

        _skillSettingsLoaded = true;
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
    }

    /// <summary>
    /// Handles the OnLoadCharacter event
    /// </summary>
    private void OnLoadCharacter()
    {
        RefreshSkills();
    }


    /// <summary>
    /// Handles stat increase events
    /// </summary>
    private void OnIncreaseStat()
    {
        if (Game.Player.StatPoints < IncIntValue + IncStrValue)
        {
            _statIncreaseRunning = false;
            StatPointsHandler.CancellationRequested = true;
        }
    }

    private void ExecuteRunCommand()
    {
        if (_statIncreaseRunning)
        {
            _statIncreaseRunning = false;
            StatPointsHandler.CancellationRequested = true;
            return;
        }

        StatPointsHandler.CancellationRequested = false;
        var stepSize = IncIntValue + IncStrValue;

        if (stepSize == 0) return;
        if (Game.Player.StatPoints < stepSize)
            return;

        var availableSteps = Math.Floor((double)Game.Player.StatPoints / stepSize);

        if (Game.Player.StatPoints == stepSize)
            availableSteps = 1;

        if (availableSteps == 0) return;

        Task.Run(() => StatPointsHandler.IncreaseStatPoints((int)availableSteps));

        _statIncreaseRunning = true;
    }

    #endregion
}