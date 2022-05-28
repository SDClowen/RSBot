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
            LoadIndex = 3,
            TabDisplayIndex = 3
        };

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //Player handlers
            HealthManaRecoveryHandler.Initialize();
            UniversalPillHandler.Initialize();
            VigorRecoveryHandler.Initialize();
            SkillHealthHandler.Initialize();
            SkillManaHandler.Initialize();
            BadStateSkillHandler.Initialize();
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
        }

        /// <summary>
        /// Gets the view that will be displayed as tab page.
        /// </summary>
        /// <returns></returns>
        public Control GetView()
        {
            return View.Instance ?? (View.Instance = new Main());
        }

        /// <summary>
        /// Translate the plugin
        /// </summary>
        /// <param name="language">The language</param>
        public void Translate()
        {
            LanguageManager.Translate(GetView(), Kernel.Language);
        }
    }
}