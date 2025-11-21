using System.ComponentModel;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(false)]
public partial class Transport : CosControlBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Transport" /> class.
    /// </summary>
    public Transport()
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;

        SubscribeEvents();
        MiniCosControl.Satiety.Visible = false;
        MiniCosControl.Hgp.Visible = false;
    }

    public override void Initialize()
    {
        base.Initialize();

        progressHP.Value = Game.Player.Transport.Health;
        progressHP.Maximum = Game.Player.Transport.MaxHealth;

        MiniCosControl.Hp.Value = Game.Player.Transport.Health;
        MiniCosControl.Hp.Maximum = Game.Player.Transport.MaxHealth;

        var record = Game.Player.Transport.Record;
        if (record == null)
            return;

        lblPetName.Text = record.GetRealName();
        MiniCosControl.Level.Text = "Lv." + record.ReqLevel1;

        var icon = Game.Player.Transport.Record?.GetIcon();
        if (icon != null)
            MiniCosControl.Icon.BackgroundImage = icon;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateTransportHealth", OnUpdateTransportHealth);
    }

    /// <summary>
    ///     Handles the update pet hp or mp
    /// </summary>
    private void OnUpdateTransportHealth()
    {
        if (Game.Player.Transport == null)
            return;

        progressHP.Value = Game.Player.Transport.Health;
        progressHP.Maximum = Game.Player.Transport.MaxHealth;

        MiniCosControl.Hp.Value = Game.Player.Transport.Health;
        MiniCosControl.Hp.Maximum = Game.Player.Transport.MaxHealth;
    }
}
