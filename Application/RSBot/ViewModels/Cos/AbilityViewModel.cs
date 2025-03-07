using RSBot.Core;
using RSBot.Core.Event;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the ability pet control
/// </summary>
public class AbilityViewModel : CosControlBaseViewModel
{
    public AbilityViewModel(MiniCosControlViewModel miniCosControlViewModel)
        : base(miniCosControlViewModel)
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnAbilityPetNameChange", OnAbilityPetNameChange);
    }

    private void OnAbilityPetNameChange()
    {
        if (Game.Player.AbilityPet == null)
            return;

        PetName = Game.Player.AbilityPet.Name;
    }

    public override void Initialize()
    {
        base.Initialize();

        _miniCosControl.SatietyVisible = false;
        _miniCosControl.HgpVisible = false;
        return;


        if (Game.Player.AbilityPet == null)
            return;

        Health = 100;
        HealthMaximum = 100;
        PetName = Game.Player.AbilityPet.Name;

        var record = Game.Player.AbilityPet.Record;
        if (record == null)
            return;

        PetName = record.GetRealName();
        Level = $"Lv.{record.ReqLevel1}";

        _miniCosControl.ImageSource = record.GetIcon();
    }
} 