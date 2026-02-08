using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Plugins;
using RSBot.Lure.Bundle;
using RSBot.Lure.Components;
using System;
using System.Windows.Forms;

namespace RSBot.Lure;

public class LureBotbase : IBotbase
{
    private bool _interrupted;

    /// <inheritdoc />
    public string Author => "RSBot Team";

    /// <inheritdoc />
    public string Description => "Botbase focused on luring mobs in the best areas of the game.";

    /// <inheritdoc />
    public string Name => "RSBot.Lure";

    /// <inheritdoc />
    public string Title => "Lure";

    /// <inheritdoc />
    public string Version => "1.0.0";

    /// <inheritdoc />
    public bool Enabled { get; set; }

    /// <inheritdoc />
    public Area Area => LureConfig.Area;

    /// <inheritdoc />
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

        EventManager.FireEvent("Bundle.Resurrect.Invoke");
        EventManager.FireEvent("Bundle.Buff.Invoke");
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

    /// <inheritdoc />
    public Control View => Views.View.Main;

    /// <inheritdoc />
    public void Start()
    {
        Log.Notify("[Lure] bot started!");
    }

    /// <inheritdoc />
    public void Stop()
    {
        EventManager.FireEvent("Bundle.Loop.Stop");
        EventManager.FireEvent("Bundle.Loot.Stop");
        EventManager.FireEvent("Bundle.PartyBuffing.Stop");
        EventManager.FireEvent("Bundle.Buff.Stop");

        Log.Notify("[Lure] bot stopped!");
    }

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void Initialize()
    {
        Log.Debug("[Lure] Botbase registered to the kernel!");
    }

    /// <inheritdoc />
    public void Enable()
    {
        if (View != null)
            View.Enabled = true;
    }

    /// <inheritdoc />
    public void Disable()
    {
        if (View != null)
            View.Enabled = false;
    }
}
