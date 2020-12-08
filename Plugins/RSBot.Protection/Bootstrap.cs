using RSBot.Core;
using RSBot.Core.Plugins;
using RSBot.Protection.Components.Pet;
using RSBot.Protection.Components.Player;
using RSBot.Protection.Components.Town;
using RSBot.Protection.Views;
using System.Windows.Forms;
using View = RSBot.Protection.Views.View;

namespace RSBot.Protection
{
    public class Bootstrap : IPlugin
    {
        #region Interface

        /// <summary>
        /// Gets or sets the information of the plugin.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public PluginInfo Information => new PluginInfo
        {
            DisplayAsTab = true,
            DisplayName = "Protection",
            InternalName = "RSBot.Protection",
            LoadIndex = 108,
            TabDisplayIndex = 4
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //Player handlers
            HealthRecoveryHandler.Initialize();
            ManaRecoveryHandler.Initialize();
            UniversalPillHandler.Initialize();
            VigorHealthRecoveryHandler.Initialize();
            VigorManaRecoveryHandler.Initialize();
            SkillHealthHandler.Initialize();
            SkillManaHandler.Initialize();
            BadStateSkillHandler.Initialize();

            //Pet handlers
            AttackPetHealthRecoveryHandler.Initialize();
            VehiclePetHealthRecoveryHandler.Initialize();
            HungerRecoveryHandler.Initiliaze();
            PetBadStatusHandler.Initialize();
            ReviveAttackPetHandler.Initialize();
            AutoSummonAttackPet.Initialize();

            //Back town
            DeadHandler.Initialize();
            AmmunitionHandler.Initialize();
            InventoryFullHandler.Initialize();
            PetInventoryFullHandler.Initialize();
            NoManaPotionsHandler.Initialize();
            NoHealthPotionsHandler.Initialize();
            DurabilityLowHandler.Initialize();
            LevelUpHandler.Initialize();

            Log.Notify("Plugin [Protection] initialized!");
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        /// <returns></returns>
        public Control GetView()
        {
            return View.Instance ?? (View.Instance = new Main());
        }

        #endregion Interface
    }
}