using System.ComponentModel;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(false)]
public partial class JobTransport : CosControlBase
{
    public JobTransport()
    {
        InitializeComponent();

        SubscribeEvents();
        MiniCosControl.Satiety.Visible = false;
        MiniCosControl.Hgp.Visible = false;
    }

    public override void Initialize()
    {
        base.Initialize();

        progressHP.Maximum = Game.Player.JobTransport.MaxHealth;
        progressHP.Value = Game.Player.JobTransport.Health;

        MiniCosControl.Hp.Maximum = Game.Player.JobTransport.MaxHealth;
        MiniCosControl.Hp.Value = Game.Player.JobTransport.Health;

        var record = Game.Player.JobTransport.Record;
        if (record == null)
            return;

        lblPetName.Text = record.GetRealName();
        MiniCosControl.Level.Text = "Lv." + record.ReqLevel1;

        var icon = Game.Player.JobTransport.Record?.GetIcon();
        if (icon != null)
            MiniCosControl.Icon.BackgroundImage = icon;
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateJobTransportHealth", OnUpdateJobTransportHealth);
    }

    /// <summary>
    ///     Handles the update pet hp or mp
    /// </summary>
    private void OnUpdateJobTransportHealth()
    {
        if (Game.Player.JobTransport == null)
            return;

        progressHP.Maximum = Game.Player.JobTransport.MaxHealth;
        progressHP.Value = Game.Player.JobTransport.Health;

        MiniCosControl.Hp.Maximum = Game.Player.JobTransport.MaxHealth;
        MiniCosControl.Hp.Value = Game.Player.JobTransport.Health;
    }
}