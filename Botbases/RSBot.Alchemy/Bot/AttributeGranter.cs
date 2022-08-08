using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects.Inventory.Item;

namespace RSBot.Alchemy.Bot
{
    internal class AttributeGranter
    {
        #region Members

        private bool _shouldRun;
        #endregion

        #region Methods

        public void Run(AttributesConfig config) 
        {
            if (!config.Attributes.Any())
            {
                Log.Error("[Alchemy] No attribute stone fusion configured!");

                Kernel.Bot.Stop();

                return;
            }

            //Wait for the next tick to operate
            if (!_shouldRun)
                return;

            foreach (var attribute in config.Attributes)
            {
                var slot = AttributesInfo.GetAttributeSlotForItem(attribute.Group, config.Item.Record);
                var currentValue = config.Item.Attributes.GetPercentage(slot);

                if (currentValue >= attribute.MaxValue)
                    continue;

                AlchemyManager.FuseAttributeStone(attribute.Stone, config.Item);

                _shouldRun = false;
            }
        }

        #endregion
    }
}
