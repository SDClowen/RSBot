using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using System;
using System.Reactive;

namespace RSBot.ViewModels;

/// <summary>
/// Represents the view model for character information and statistics
/// </summary>
public class CharacterViewModel : ReactiveObject
{
    #region Private Fields

    private string _playerName;
    private string _level;
    private string _strength;
    private string _intelligence;
    private string _gold;
    private string _skillPoints;
    private int _healthMaximum;
    private int _manaMaximum;
    private int _health;
    private int _mana;
    private double _expMaximum;
    private double _expValue;

    #endregion

    /// <summary>
    /// Initializes a new instance of the CharacterViewModel class
    /// </summary>
    public CharacterViewModel()
    {
        Reset();
        SubscribeEvents();
    }

    #region Public Properties

    /// <summary>
    /// Gets or sets the player name
    /// </summary>
    public string PlayerName
    {
        get => _playerName;
        set => this.RaiseAndSetIfChanged(ref _playerName, value);
    }

    /// <summary>
    /// Gets or sets the character level
    /// </summary>
    public string Level
    {
        get => _level;
        set => this.RaiseAndSetIfChanged(ref _level, value);
    }

    /// <summary>
    /// Gets or sets the character strength
    /// </summary>
    public string Strength
    {
        get => _strength;
        set => this.RaiseAndSetIfChanged(ref _strength, value);
    }

    /// <summary>
    /// Gets or sets the character intelligence
    /// </summary>
    public string Intelligence
    {
        get => _intelligence;
        set => this.RaiseAndSetIfChanged(ref _intelligence, value);
    }

    /// <summary>
    /// Gets or sets the character gold amount
    /// </summary>
    public string Gold
    {
        get => _gold;
        set => this.RaiseAndSetIfChanged(ref _gold, value);
    }

    /// <summary>
    /// Gets or sets the character skill points
    /// </summary>
    public string SkillPoints
    {
        get => _skillPoints;
        set => this.RaiseAndSetIfChanged(ref _skillPoints, value);
    }

    /// <summary>
    /// Gets or sets the character maximum health
    /// </summary>
    public int HealthMaximum
    {
        get => _healthMaximum;
        set => this.RaiseAndSetIfChanged(ref _healthMaximum, value);
    }

    /// <summary>
    /// Gets or sets the character maximum mana
    /// </summary>
    public int ManaMaximum
    {
        get => _manaMaximum;
        set => this.RaiseAndSetIfChanged(ref _manaMaximum, value);
    }

    /// <summary>
    /// Gets or sets the character current health
    /// </summary>
    public int Health
    {
        get => _health;
        set => this.RaiseAndSetIfChanged(ref _health, value);
    }

    /// <summary>
    /// Gets or sets the character current mana
    /// </summary>
    public int Mana
    {
        get => _mana;
        set => this.RaiseAndSetIfChanged(ref _mana, value);
    }

    /// <summary>
    /// Gets or sets the character maximum experience
    /// </summary>
    public double ExpMaximum
    {
        get => _expMaximum;
        set => this.RaiseAndSetIfChanged(ref _expMaximum, value);
    }

    /// <summary>
    /// Gets or sets the character current experience value
    /// </summary>
    public double ExpValue
    {
        get => _expValue;
        set => this.RaiseAndSetIfChanged(ref _expValue, value);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Subscribes to all required events
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnLoadCharacterStats", OnLoadCharacterStats);
        EventManager.SubscribeEvent("OnLevelUp", new Action<byte>(OnLevelUp));
        EventManager.SubscribeEvent("OnExpSpUpdate", OnExpUpdate);
        EventManager.SubscribeEvent("OnUpdateHPMP", OnLoadCharacterStats);
        EventManager.SubscribeEvent("OnUpdateGold", OnUpdateGold);
        EventManager.SubscribeEvent("OnUpdateSP", OnUpdateSP);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", Reset);
        EventManager.SubscribeEvent("OnInitialized", OnInitialized);
    }

    /// <summary>
    /// Handles the level up event
    /// </summary>
    /// <param name="oldLevel">The previous level</param>
    private void OnLevelUp(byte oldLevel)
    {
        Level = $"lv.{Game.Player.Level}";
    }

    /// <summary>
    /// Handles the initialization event
    /// </summary>
    private void OnInitialized()
    {
        PlayerName = LanguageManager.GetLang("LabelPlayerName");
    }

    /// <summary>
    /// Handles the skill points update event
    /// </summary>
    private void OnUpdateSP()
    {
        SkillPoints = Game.Player.SkillPoints.ToString("#,#0");
    }

    /// <summary>
    /// Handles the gold update event
    /// </summary>
    private void OnUpdateGold()
    {
        Gold = Game.Player.Gold.ToString("#,#0");
    }

    /// <summary>
    /// Handles the character stats update event
    /// </summary>
    private void OnLoadCharacterStats()
    {
        Intelligence = Game.Player.Intelligence.ToString();
        Strength = Game.Player.Strength.ToString();

        if (Game.Player.MaximumHealth == 0)
            return;

        if (Game.Player.MaximumMana == 0)
            return;

        HealthMaximum = Game.Player.MaximumHealth;
        ManaMaximum = Game.Player.MaximumMana;
        Health = Game.Player.Health;
        Mana = Game.Player.Mana;
    }

    /// <summary>
    /// Handles the experience update event
    /// </summary>
    private void OnExpUpdate()
    {
        ExpMaximum = Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C;
        ExpValue = Game.Player.Experience;
    }

    /// <summary>
    /// Handles the character load event
    /// </summary>
    private void OnLoadCharacter()
    {
        PlayerName = Game.Player.Name;

        OnLevelUp(Game.Player.Level);
        OnLoadCharacterStats();
        OnExpUpdate();
        OnUpdateSP();
        OnUpdateGold();
    }

    /// <summary>
    /// Handles the agent server disconnected event
    /// </summary>
    private void Reset()
    {
        PlayerName = LanguageManager.GetLang("LabelPlayerName");
        Level = "0";
        Strength = "0";
        Intelligence = "0";
        Gold = "0";
        SkillPoints = "0";
        Health = 0;
        Mana = 0;
        ExpValue = 0;
        HealthMaximum = 0;
        ManaMaximum = 0;
        ExpMaximum = 0;
    }

    #endregion
} 