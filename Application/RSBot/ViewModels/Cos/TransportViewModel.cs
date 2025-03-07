using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the transport pet control that displays transport information
/// </summary>
public class TransportViewModel : CosControlBaseViewModel
{
    public TransportViewModel(MiniCosControlViewModel miniCosControlModel) 
        : base(miniCosControlModel)
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateTransportHealth", OnUpdateTransportHealth);
    }

    private void OnUpdateTransportHealth()
    {
        if (Game.Player.Transport == null)
            return;

        HealthMaximum = Game.Player.Transport.MaxHealth;
        Health = Game.Player.Transport.Health;
    }

    public override void Initialize()
    {
        base.Initialize();
        _miniCosControl.SatietyVisible = false;
        _miniCosControl.HgpVisible = false;
        return;

        if (Game.Player.Transport == null)
            return;


        HealthMaximum = Game.Player.Transport.MaxHealth;
        Health = Game.Player.Transport.Health;

        var record = Game.Player.Transport.Record;
        if (record == null)
            return;

        PetName = record.GetRealName();
        Level = $"Lv.{record.ReqLevel1}";

        _miniCosControl.ImageSource = record.GetIcon();
    }
} 