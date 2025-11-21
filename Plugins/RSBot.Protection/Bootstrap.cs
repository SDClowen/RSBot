using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Protection.Components.Pet;
using RSBot.Protection.Components.Player;
using RSBot.Protection.Components.Town;

namespace RSBot.Protection;

public class Bootstrap : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.Protection";

    /// <inheritdoc />
    public string DisplayName => "Protection";

    /// <inheritdoc />
    public bool DisplayAsTab => true;

    /// <inheritdoc />
    public int Index => 2;

    /// <inheritdoc />
    public bool RequireIngame => true;

    /// <inheritdoc />
    public void Initialize()
    {
        //Player handlers
        HealthManaRecoveryHandler.Initialize();
        UniversalPillHandler.Initialize();
        VigorRecoveryHandler.Initialize();
        StatPointsHandler.Initialize();

        //Pet handlers
        CosHealthRecoveryHandler.Initialize();
        CosHGPRecoveryHandler.Initiliaze();
        CosBadStatusHandler.Initialize();
        CosReviveHandler.Initialize();
        AutoSummonAttackPet.Initialize();

        //Back town
        DeadHandler.Initialize();
        AmmunitionHandler.Initialize();
        InventoryFullHandler.Initialize();
        PetInventoryFullHandler.Initialize();
        NoManaPotionsHandler.Initialize();
        NoHealthPotionsHandler.Initialize();
        LevelUpHandler.Initialize();
        DurabilityLowHandler.Initialize();
        FatigueHandler.Initialize();
    }

    /// <inheritdoc />
    public Control View => Views.View.Instance;

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void OnLoadCharacter()
    {
        // do nothing
    }
}
