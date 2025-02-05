using System.ComponentModel;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(false)]
public partial class Fellow : CosControlBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Fellow" /> class.
    /// </summary>
    public Fellow()
    {
        InitializeComponent();
        SubscribeEvents();

        MiniCosControl.Hgp.Visible = false;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnFellowLevelUp", OnFellowLevelUp);
        EventManager.SubscribeEvent("OnFellowExperienceUpdate", OnFellowExperienceUpdate);
        EventManager.SubscribeEvent("OnFellowSatietyUpdate", OnFellowSatietyUpdate);
        EventManager.SubscribeEvent("OnFellowNameChange", OnFellowNameChange);
        EventManager.SubscribeEvent("OnFellowHealthUpdate", OnFellowHealthUpdate);
    }

    /// <summary>
    ///     Handels the name change event of the pet
    /// </summary>
    private void OnFellowNameChange()
    {
        if (Game.Player.Fellow == null)
            return;

        lblPetName.Text = Game.Player.Fellow.Name;
    }

    /// <summary>
    ///     Handels the pet level up event
    /// </summary>
    private void OnFellowLevelUp()
    {
        if (Game.Player.Fellow == null)
            return;

        labelLevel.Text = "lv." + Game.Player.Fellow.Level;
        MiniCosControl.Level.Text = labelLevel.Text;

        progressBarStoredSp.Maximum = Game.Player.Fellow.MaxStoredSp;
        progressBarStoredSp.Value = Game.Player.Fellow.StoredSp;

        OnFellowNameChange();
        OnFellowHealthUpdate();
        OnFellowSatietyUpdate();
        OnFellowExperienceUpdate();
    }

    /// <summary>
    ///     Handles the update pet hp or mp
    /// </summary>
    private void OnFellowHealthUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        progressHP.Maximum = Game.Player.Fellow.MaxHealth;
        progressHP.Value = Game.Player.Fellow.Health;

        MiniCosControl.Hp.Maximum = Game.Player.Fellow.MaxHealth;
        MiniCosControl.Hp.Value = Game.Player.Fellow.Health;
    }

    /// <summary>
    ///     Handles the pet experience update event
    /// </summary>
    private void OnFellowExperienceUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        progressEXP.Maximum = 100;
        progressEXP.Value = (byte)((Game.Player.Fellow.Experience / Game.Player.Fellow.MaxExperience) * 100);
    }

    /// <summary>
    ///     Handels the hunger update event
    /// </summary>
    private void OnFellowSatietyUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        progressSatiety.Maximum = 36000;
        progressSatiety.Value = Game.Player.Fellow.Satiety;

        MiniCosControl.Satiety.Maximum = 36000;
        MiniCosControl.Satiety.Value = Game.Player.Fellow.Satiety;
    }

    public override void Initialize()
    {
        OnFellowLevelUp();

        var icon = Game.Player.Fellow.Record?.GetIcon();
        if (icon != null)
            MiniCosControl.Icon.BackgroundImage = icon;
    }

    public override void Reset()
    {
        base.Reset();

        lblPetName.Text = LanguageManager.GetLang("LabelPetName");

        progressEXP.Value = 0;
        progressSatiety.Value = 0;

        progressSatiety.Maximum = 36000;
        progressEXP.Maximum = 0;

        MiniCosControl.Satiety.Value = 0;
        MiniCosControl.Satiety.Maximum = 0;
    }
}