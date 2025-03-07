using Avalonia.Media;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using System;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the fellow pet control that displays fellow information and statistics
/// </summary>
public class FellowViewModel : CosControlBaseViewModel
{
    private int _experienceMaximum;
    private int _experienceValue;
    private int _satietyMaximum;
    private int _satietyValue;
    private int _storedSpMaximum;
    private int _storedSpValue;

    public FellowViewModel(MiniCosControlViewModel miniCosControlViewModel)
        : base(miniCosControlViewModel)
    {
        SubscribeEvents();
    }

    public int ExperienceMaximum
    {
        get => _experienceMaximum;
        set => this.RaiseAndSetIfChanged(ref _experienceMaximum, value);
    }

    public int ExperienceValue
    {
        get => _experienceValue;
        set => this.RaiseAndSetIfChanged(ref _experienceValue, value);
    }

    public int SatietyMaximum
    {
        get => _satietyMaximum;
        set => this.RaiseAndSetIfChanged(ref _satietyMaximum, value);
    }

    public int SatietyValue
    {
        get => _satietyValue;
        set => this.RaiseAndSetIfChanged(ref _satietyValue, value);
    }

    public int StoredSpMaximum
    {
        get => _storedSpMaximum;
        set => this.RaiseAndSetIfChanged(ref _storedSpMaximum, value);
    }

    public int StoredSpValue
    {
        get => _storedSpValue;
        set => this.RaiseAndSetIfChanged(ref _storedSpValue, value);
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnFellowLevelUp", OnFellowLevelUp);
        EventManager.SubscribeEvent("OnFellowExperienceUpdate", OnFellowExperienceUpdate);
        EventManager.SubscribeEvent("OnFellowSatietyUpdate", OnFellowSatietyUpdate);
        EventManager.SubscribeEvent("OnFellowNameChange", OnFellowNameChange);
        EventManager.SubscribeEvent("OnFellowHealthUpdate", OnFellowHealthUpdate);
    }

    private void OnFellowNameChange()
    {
        if (Game.Player.Fellow == null)
            return;

        PetName = Game.Player.Fellow.Name;
    }

    private void OnFellowLevelUp()
    {
        if (Game.Player.Fellow == null)
            return;

        Level = $"lv.{Game.Player.Fellow.Level}";
        StoredSpMaximum = Game.Player.Fellow.MaxStoredSp;
        StoredSpValue = Game.Player.Fellow.StoredSp;

        OnFellowNameChange();
        OnFellowHealthUpdate();
        OnFellowSatietyUpdate();
        OnFellowExperienceUpdate();
    }

    private void OnFellowHealthUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        HealthMaximum = Game.Player.Fellow.MaxHealth;
        Health = Game.Player.Fellow.Health;
    }

    private void OnFellowExperienceUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        ExperienceMaximum = 100;
        ExperienceValue = (byte)((Game.Player.Fellow.Experience / Game.Player.Fellow.MaxExperience) * 100);
    }

    private void OnFellowSatietyUpdate()
    {
        if (Game.Player.Fellow == null)
            return;

        SatietyMaximum = 36000;
        SatietyValue = Game.Player.Fellow.Satiety;
    }

    public override void Initialize()
    {
        base.Initialize();
        return;

        OnFellowLevelUp();

        if (Game.Player.Fellow == null)
            return;

        _miniCosControl.SatietyVisible = true;
        _miniCosControl.HgpVisible = false;

        var record = Game.Player.AbilityPet.Record;
        if (record == null)
            return;

        PetName = record.GetRealName();
        Level = $"Lv.{record.ReqLevel1}";

        _miniCosControl.ImageSource = record.GetIcon();
    }

    public override void Reset()
    {
        base.Reset();

        ExperienceValue = 0;
        SatietyValue = 0;
        StoredSpValue = 0;

        SatietyMaximum = 36000;
        ExperienceMaximum = 0;
        StoredSpMaximum = 0;
    }
} 