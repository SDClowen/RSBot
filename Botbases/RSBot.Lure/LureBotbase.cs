using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Lure.Bundle;
using RSBot.Lure.Components;
using System.Data.Common;
using System.Windows.Forms;

namespace RSBot.Lure;

public class LureBotbase : IBotbase
{
    private bool _interrupted;
    public string Name => "RSBot.Lure";

    public string DisplayName => "Lure";

    public string TabText => DisplayName;

    public Area Area => LureConfig.Area;

    /// <summary>
    ///     Ticks this instance. It's the botbase main-loop
    /// </summary>
    public void Tick()
    {
        if (!Kernel.Bot.Running)
            return;

        if (PickupManager.RunningPlayerPickup)
            return;

        if (Area.Position.DistanceToPlayer() > 80)
        {
            if (!ScriptManager.Running)
                EventManager.FireEvent("Bundle.Loop.Start");

            EventManager.FireEvent("Bundle.Loop.Invoke");

            return;
        }

        EventManager.FireEvent("Bundle.Buff.Invoke");
        EventManager.FireEvent("Bundle.Resurrection.Invoke");
        EventManager.FireEvent("Bundle.PartyBuffing.Invoke");

        var interruptMessage = LoopConditionValidator.CheckLoopConditions();
        if (interruptMessage != null)
        {
            ScriptManager.Stop();

            if (LureConfig.Area.Position.DistanceToPlayer() > 2)
                Game.Player.MoveTo(LureConfig.Area.Position);

            if (!_interrupted)
                Log.Warn(interruptMessage);

            _interrupted = true;

            return;
        }

        _interrupted = false;

        if (Game.Player.HasActiveVehicle)
            Game.Player.Vehicle.Dismount();

        if (LureConfig.UseHowlingShout)
            HowlingShoutBundle.Tick();

        TargetBundle.Tick();
        AttackBundle.Tick();
        MovementBundle.Tick();

        if (!PickupManager.RunningPlayerPickup && !PickupManager.RunningAbilityPetPickup)
            EventManager.FireEvent("Bundle.Loot.Invoke");
    }

    /// <summary>
    ///     Gets the view.
    /// </summary>
    /// <returns></returns>
    public Control View => Views.View.Main;

    /// <summary>
    ///     Starts this instance.
    /// </summary>
    public void Start()
    {
        Log.Notify("[Lure] bot started!");
    }

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    public void Stop()
    {
        EventManager.FireEvent("Bundle.Loop.Stop");
        EventManager.FireEvent("Bundle.Loot.Stop");
        EventManager.FireEvent("Bundle.PartyBuffing.Stop");
        EventManager.FireEvent("Bundle.Buff.Stop");

        Log.Notify("[Lure] bot stopped!");
    }

    public void Register()
    {
        Log.Debug("[Lure] Botbase registered to the kernel!");
    }

    /// <summary>
    ///     Translate the botbase plugin
    /// </summary>
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }
}