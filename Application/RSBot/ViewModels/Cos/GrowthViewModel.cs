using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the growth pet control that displays growth information and statistics
/// </summary>
public class GrowthViewModel : CosControlBaseViewModel
{
    private int _experienceMaximum;
    private int _experienceValue;
    private int _hungerPointsMaximum;
    private int _hungerPointsValue;

    public GrowthViewModel(MiniCosControlViewModel miniCosControlViewModel)
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

    public int HungerPointsMaximum
    {
        get => _hungerPointsMaximum;
        set => this.RaiseAndSetIfChanged(ref _hungerPointsMaximum, value);
    }

    public int HungerPointsValue
    {
        get => _hungerPointsValue;
        set => this.RaiseAndSetIfChanged(ref _hungerPointsValue, value);
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnGrowthLevelUp", OnGrowthLevelUp);
        EventManager.SubscribeEvent("OnGrowthExperienceUpdate", OnGrowthExperienceUpdate);
        EventManager.SubscribeEvent("OnGrowthHungerUpdate", OnGrowthHungerUpdate);
        EventManager.SubscribeEvent("OnGrowthNameChange", OnGrowthNameChange);
        EventManager.SubscribeEvent("OnGrowthHealthUpdate", OnGrowthHealthUpdate);
    }

    private void OnGrowthNameChange()
    {
        if (Game.Player.Growth == null)
            return;

        PetName = Game.Player.Growth.Name;
    }

    private void OnGrowthLevelUp()
    {
        if (Game.Player.Growth == null)
            return;

        Level = $"lv.{Game.Player.Growth.Level}";

        OnGrowthNameChange();
        OnGrowthHealthUpdate();
        OnGrowthHungerUpdate();
        OnGrowthExperienceUpdate();
    }

    private void OnGrowthHealthUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        HealthMaximum = Game.Player.Growth.MaxHealth;
        Health = Game.Player.Growth.Health;
    }

    private void OnGrowthExperienceUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        ExperienceMaximum = 100;
        ExperienceValue = (byte)((Game.Player.Growth.Experience / Game.Player.Growth.MaxExperience) * 100);
    }

    private void OnGrowthHungerUpdate()
    {
        if (Game.Player.Growth == null)
            return;

        HungerPointsMaximum = Game.Player.Growth.MaxHungerPoints;
        HungerPointsValue = Game.Player.Growth.CurrentHungerPoints;
    }

    public override void Initialize()
    {
        base.Initialize();

        _miniCosControl.SatietyVisible = false;
        return;

        if (Game.Player.Growth == null)
            return;

        OnGrowthLevelUp();


        var record = Game.Player.Growth.Record;
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
        HungerPointsValue = 0;

        ExperienceMaximum = 0;
        HungerPointsMaximum = 0;
    }
} 