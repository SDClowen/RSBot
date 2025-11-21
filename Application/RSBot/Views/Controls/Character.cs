using System;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using SDUI.Controls;

namespace RSBot.Views.Controls;

public partial class Character : DoubleBufferedControl
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Character" /> class.
    /// </summary>
    public Character()
    {
        InitializeComponent();

        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
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
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnInitialized", OnInitialized);
    }

    private void OnLevelUp(byte oldLevel)
    {
        lblLevel.Text = $"lv.{Game.Player.Level}";
    }

    private void OnInitialized()
    {
        lblPlayerName.Text = LanguageManager.GetLang("LabelPlayerName");
    }

    private void OnUpdateSP()
    {
        lblSP.Text = Game.Player.SkillPoints.ToString("#,#0");
    }

    private void OnUpdateGold()
    {
        lblGold.Text = Game.Player.Gold.ToString("#,#0");
    }

    /// <summary>
    ///     On Hp/MP update
    /// </summary>
    private void OnLoadCharacterStats()
    {
        lblInt.Text = Game.Player.Intelligence.ToString();
        lblStr.Text = Game.Player.Strength.ToString();

        if (Game.Player.MaximumHealth == 0)
            return;

        if (Game.Player.MaximumMana == 0)
            return;

        progressHP.Maximum = Game.Player.MaximumHealth;
        progressMP.Maximum = Game.Player.MaximumMana;
        progressHP.Value = Game.Player.Health;
        progressMP.Value = Game.Player.Mana;
    }

    /// <summary>
    ///     On Exp update
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    private void OnExpUpdate()
    {
        progressEXP.Value = Game.Player.Experience;
        progressEXP.Maximum = Game.ReferenceManager.GetRefLevel(Game.Player.Level).Exp_C;
    }

    /// <summary>
    ///     s the on load character.
    /// </summary>
    private void OnLoadCharacter()
    {
        lblPlayerName.Text = Game.Player.Name;

        OnLevelUp(Game.Player.Level);
        OnLoadCharacterStats();
        OnExpUpdate();
        OnUpdateSP();
        OnUpdateGold();
    }

    /// <summary>
    ///     Reset UI after character disconnect
    /// </summary>
    private void OnAgentServerDisconnected()
    {
        lblPlayerName.Text = LanguageManager.GetLang("LabelPlayerName");
        lblLevel.Text = "0";
        lblStr.Text = "0";
        lblInt.Text = "0";
        lblGold.Text = "0";
        lblSP.Text = "0";
        progressHP.Value = 0;
        progressMP.Value = 0;
        progressEXP.Value = 0;
        progressHP.Maximum = 0;
        progressMP.Maximum = 0;
        progressEXP.Maximum = 0;
    }
}
