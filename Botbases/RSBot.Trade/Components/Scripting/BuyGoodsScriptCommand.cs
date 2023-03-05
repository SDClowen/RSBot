using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Objects;

namespace RSBot.Trade.Components.Scripting
{
    internal class BuyGoodsScriptCommand : IScriptCommand
    {
        #region Properties

        public string Name => "buy-goods";

        public bool IsBusy { get; private set; }

        public Dictionary<string, string> Arguments => new Dictionary<string, string>
        {
            {"Codename", "The code name of the NPC"}
        };

        #endregion Properties

        #region Methods

        public bool Execute(string[] arguments = null)
        {
            if (arguments == null || arguments.Length < Arguments.Count)
            {
                Log.Warn("[Script] Invalid buy command: NPC code name information missing.");

                return false;
            }

            if (Game.Player.JobTransport == null)
            {
                Log.Warn("[Script] Can not buy items: No active job transport.");

                return false;
            }


            try
            {
                IsBusy = true;
                var codeName = arguments[0];
                
                ShoppingManager.ChooseTalkOption(codeName, TalkOption.Trade);

                if (Game.SelectedEntity == null)
                {
                    Log.Warn("[Script] Can not buy items: Not in dialog with an NPC.");

                    return false;
                }

                Log.Notify("[Script] Purchasing items...");

                SellGoods();
                BuyGoods();
                
                ShoppingManager.CloseShop();
                return true;
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        private void SellGoods()
        {
            return;
        }

        private void BuyGoods()
        {
            if (!TradeConfig.BuyGoods)
                return;

            var shopGroup = Game.ReferenceManager.GetRefShopGroup(Game.SelectedEntity?.Record.CodeName);
            if (shopGroup == null)
            {
                Log.Warn("[Script] Can not buy items: Can not find the shop info.");

                return;
            }

            var shopGoods = Game.ReferenceManager.GetRefShopGoods(shopGroup);
            var item = shopGoods?.FirstOrDefault();

            if (item == null)
            {
                Log.Warn("[Script] Can not buy items: Can not find the shop info.");

                return;
            }

            var tabIndex = Game.ReferenceManager.GetRefShopGoodTabIndex(Game.SelectedEntity?.Record.CodeName, item);
            if (tabIndex == 0xFF) //Specified item not available in this shop!
            {
                Log.Warn("[Script] Can not buy items: Can not find the item in the shop.");

                return;
            }

            var packageItem = Game.ReferenceManager.GetRefPackageItem(item.RefPackageItemCodeName);
            if (packageItem?.RefItem == null)
            {
                Log.Warn("[Script] Can not buy items: Can not find the referenced item.");

                return;
            }
            
            var bought = 0;
            while (!Game.Player.JobTransport.Inventory.Full)
            {
                var buyNextQty = packageItem.RefItem.MaxStack;

                if (TradeConfig.BuyGoodsQuantity > 0 && bought + buyNextQty > TradeConfig.BuyGoodsQuantity)
                    buyNextQty = TradeConfig.BuyGoodsQuantity - bought;
                
                //ToDO: After testing remove this line!
                buyNextQty = 1;
                ShoppingManager.PurchaseItem(Game.Player.JobTransport, tabIndex, item.SlotIndex, (ushort) buyNextQty);

                bought += buyNextQty;
            }
        }
        

        public void Stop()
        {
            IsBusy = false;
        }

        #endregion Methods
    }
}
