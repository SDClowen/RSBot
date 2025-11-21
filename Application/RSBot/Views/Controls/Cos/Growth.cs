using System.ComponentModel;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(false)]
public partial class Growth : CosControlBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Growth" /> class.
    /// </summary>
    public Growth()
    {
        InitializeComponent();
        SubscribeEvents();
        MiniCosControl.Satiety.Visible = false;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnGrowthLevelUp", OnGrowthLevelUp);
        EventManager.SubscribeEvent("OnGrowthExperienceUpdate", OnGrowthExperienceUpdate);
        EventManager.SubscribeEvent("OnGrowthHungerUpdate", OnGrowthHungerUpdate);
        EventManager.SubscribeEvent("OnGrowthNameChange", OnGrowthNameChange);
        EventManager.SubscribeEvent("OnGrowthHealthUpdate", OnGrowthHealthUpdate);
    }

    /// <summary>
    ///     Handels the name change event of the pet
    /// </summary>
    private void OnGrowthNameChange()
    {
        if (Game.Player.Growth == null)
            return;

        lblPetName.Text = Game.Player.Growth.Name;
    }

    /// <summary>
    ///     Handels the pet level up event
    /// </summary>
    private void OnGrowthLevelUp()
    {
        if (Game.Player.Growth == null)
            return;

        labelLevel.Text = "lv." + Game.Player.Growth.Level;
        MiniCosControl.Level.Text = labelLevel.Text;

        OnGrowthNameChange();
        OnGrowthHealthUpdate();
        OnGrowthHungerUpdate();
        OnGrowthExperienceUpdate();
    }

    /// <summary>
    ///     Handles the update pet hp or mp
    /// </summary>
    private void OnGrowthHealthUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        progressHP.Value = Game.Player.Growth.Health;
        progressHP.Maximum = Game.Player.Growth.MaxHealth;

        MiniCosControl.Hp.Value = Game.Player.Growth.Health;
        MiniCosControl.Hp.Maximum = Game.Player.Growth.MaxHealth;
    }

    /// <summary>
    ///     Handles the pet experience update event
    /// </summary>
    private void OnGrowthExperienceUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        progressEXP.Value = Game.Player.Growth.Experience;
        progressEXP.Maximum = Game.Player.Growth.MaxExperience;
    }

    /// <summary>
    ///     Handels the hunger update event
    /// </summary>
    private void OnGrowthHungerUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        progressHGP.Value = Game.Player.Growth.CurrentHungerPoints;
        progressHGP.Maximum = Game.Player.Growth.MaxHungerPoints;

        MiniCosControl.Hgp.Value = Game.Player.Growth.CurrentHungerPoints;
        MiniCosControl.Hgp.Maximum = Game.Player.Growth.MaxHungerPoints;
    }

    public override void Initialize()
    {
        OnGrowthLevelUp();

        var icon = Game.Player.Growth.Record?.GetIcon();
        if (icon != null)
            MiniCosControl.Icon.BackgroundImage = icon;
    }

    public override void Reset()
    {
        base.Reset();

        lblPetName.Text = LanguageManager.GetLang("LabelPetName");

        progressEXP.Value = 0;
        progressHGP.Value = 0;

        progressEXP.Maximum = 0;
        progressHGP.Maximum = 0;

        MiniCosControl.Hgp.Value = 0;
        MiniCosControl.Hgp.Maximum = 0;
    }
}
