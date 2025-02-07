using Avalonia.Media;
using RSBot.Core;
using RSBot.Core.Event;
using System;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the job transport pet control that displays job transport information
/// </summary>
public class JobTransportViewModel : CosControlBaseViewModel
{
    public JobTransportViewModel(MiniCosControlViewModel miniCosControlViewModel)
        : base(miniCosControlViewModel) 
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnUpdateJobTransportHealth", OnUpdateJobTransportHealth);
    }

    private void OnUpdateJobTransportHealth()
    {
        if (Game.Player.JobTransport == null)
            return;

        HealthMaximum = Game.Player.JobTransport.MaxHealth;
        Health = Game.Player.JobTransport.Health;
    }

    public override void Initialize()
    {
        base.Initialize();
        _miniCosControl.SatietyVisible = false;
        _miniCosControl.HgpVisible = false;
        return;

        if (Game.Player.JobTransport == null)
            return;

        HealthMaximum = Game.Player.JobTransport.MaxHealth;
        Health = Game.Player.JobTransport.Health;

        var record = Game.Player.JobTransport.Record;
        if (record == null)
            return;

        PetName = record.GetRealName();
        Level = $"Lv.{record.ReqLevel1}";

        _miniCosControl.ImageSource = record.GetIcon();
    }
} 