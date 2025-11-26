using System.ComponentModel;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(false)]
public partial class Ability : CosControlBase
{
    public Ability()
    {
        InitializeComponent();
        MiniCosControl.Satiety.Visible = false;
        MiniCosControl.Hgp.Visible = false;
        MiniCosControl.Level.Visible = false;
        progressHP.ShowAsPercent = true;
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnAbilityPetNameChange", OnAbilityPetNameChange);
    }

    private void OnAbilityPetNameChange()
    {
        if (Game.Player.AbilityPet == null)
            return;

        lblPetName.Text = Game.Player.AbilityPet.Name;
    }

    public override void Initialize()
    {
        base.Initialize();

        if (Game.Player.AbilityPet == null)
            return;

        progressHP.Value = 100;
        progressHP.Maximum = 100;

        MiniCosControl.Hp.Value = 100;
        MiniCosControl.Hp.Maximum = 100;

        lblPetName.Text = Game.Player.AbilityPet.Name;

        var icon = Game.Player.AbilityPet.Record?.GetIcon();
        if (icon != null)
            MiniCosControl.Icon.BackgroundImage = icon;
    }
}
