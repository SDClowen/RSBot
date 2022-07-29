using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static RSBot.Core.Game;

namespace RSBot.Core.Components
{
    public static class ShoppingManager
    {
        /// <summary>
        /// Gets or sets the shopping list.
        /// </summary>
        /// <value>
        /// The shopping list.
        /// </value>
        public static Dictionary<RefShopGood, int> ShoppingList { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ShoppingManager"/> is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if finished; otherwise, <c>false</c>.
        /// </value>
        public static bool Finished { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShoppingManager"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [repair gear].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [repair gear]; otherwise, <c>false</c>.
        /// </value>
        public static bool RepairGear { get; set; }

        /// <summary>
        /// Gets or sets the sell filter.
        /// </summary>
        /// <value>
        /// The armor sell filter.
        /// </value>
        public static ItemFilter SellFilter { get; set; }

        /// <summary>
        /// Gets or sets the store filter.
        /// </summary>
        /// <value>
        /// The store filter.
        /// </value>
        public static ItemFilter StoreFilter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShoppingManager"/> is running.
        /// </summary>
        /// <value>
        ///   <c>true</c> if running; otherwise, <c>false</c>.
        /// </value>
        public static bool Running { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [sell pet items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sell pet items]; otherwise, <c>false</c>.
        /// </value>
        public static bool SellPetItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [store pet items].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [store pet items]; otherwise, <c>false</c>.
        /// </value>
        public static bool StorePetItems { get; set; }

        /// <summary>
        /// Gets or sets the buyback list.
        /// </summary>
        /// <value>
        /// The buyback list.
        /// </value>
        internal static Dictionary<byte, InventoryItem> BuybackList { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        internal static void Initialize()
        {
            ShoppingList = new Dictionary<RefShopGood, int>();
            StoreFilter = new ItemFilter();
            SellFilter = new ItemFilter();

            BuybackList = new Dictionary<byte, InventoryItem>();

            Log.Debug("Initialized [ShoppingManager]!");
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public static void Run(string npcCodeName)
        {
            if (!Enabled)
                return;

            Finished = false;
            Running = true;

            SelectNPC(npcCodeName);

            //Prevent modification during the for-each loop
            var tempItemSellList =
                 Game.Player.Inventory.GetNormalPartItems(item => SellFilter.Invoke(item.Record));

            foreach (var item in tempItemSellList)
                SellItem(item);

            if (Game.Player.HasActiveAbilityPet && SellPetItems)
            {
                tempItemSellList = Game.Player.AbilityPet.Inventory.GetItems(item => SellFilter.Invoke(item.Record));

                foreach (var item in tempItemSellList)
                {
                    var playerSlot = Game.Player.AbilityPet.MoveItemToPlayer(item.Slot);
                    if (playerSlot != 0xFF)
                        SellItem(Game.Player.Inventory.GetItemAt((byte)playerSlot));
                } 
            }

            var shopGroup = ReferenceManager.GetRefShopGroup(npcCodeName);
            if (shopGroup == null)
            {
                Log.Warn("Could not buy anything from this NPC - It's not a shop!");
                CloseShop();

                Finished = true;
                Running = false;
                return;
            }

            var shopGoods = ReferenceManager.GetRefShopGoods(shopGroup);

            foreach (var item in ShoppingList)
            {
                if (!Running)
                    return;

                var actualItem = shopGoods.FirstOrDefault(x => x.RefPackageItemCodeName == item.Key.RefPackageItemCodeName);

                if (actualItem == null)
                    continue;

                var tabIndex = ReferenceManager.GetRefShopGoodTabIndex(npcCodeName, actualItem);
                if (tabIndex == 0xFF) //Specified item not available in this shop!
                    continue;

                var refPackageItem = ReferenceManager.GetRefPackageItem(item.Key.RefPackageItemCodeName);

                var holdingAmount = Game.Player.Inventory.GetSumAmount(refPackageItem.RefItemCodeName);
                var totalAmountToBuy = item.Value - holdingAmount;

                var refItem = ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);
                if (refItem == null)
                    continue; //Should not happen

                while (totalAmountToBuy > 0 && !Game.Player.Inventory.Full)
                {
                    var amountStep = totalAmountToBuy;
                    if (totalAmountToBuy >= refItem.MaxStack)
                        amountStep = refItem.MaxStack; //Buy only one stack

                    PurchaseItem(tabIndex, actualItem.SlotIndex, (ushort)amountStep);
                    totalAmountToBuy -= amountStep; //One stack bought, substract from total amount!
                    Thread.Sleep(100);
                }

                //merge stacks
                if (refItem.MaxStack > 1)
                {
                    IList<InventoryItem> getItems() 
                        => Game.Player.Inventory.GetItems(i => i.Record.CodeName == refPackageItem.RefItemCodeName && i.Amount < refItem.MaxStack); 

                    var nonFullStacks = getItems();
                    while (nonFullStacks.Count >= 2)
                    {
                        Game.Player.Inventory.MoveItem(nonFullStacks[1].Slot, nonFullStacks[0].Slot, (ushort)Math.Min(refItem.MaxStack - nonFullStacks[0].Amount, nonFullStacks[1].Amount));
                        nonFullStacks = getItems();
                        Thread.Sleep(100);
                    }
                }
            }

            CloseShop();

            Finished = true;
            Running = false;
        }

        /// <summary>
        /// Sells the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void SellItem(InventoryItem item)
        {
            if (SelectedEntity == null)
                return;

            var packet = new Packet(0x7034);
            packet.WriteByte(0x09);
            packet.WriteByte(item.Slot);
            packet.WriteUShort(item.Amount);
            packet.WriteUInt(SelectedEntity.UniqueId);

            var awaitResult = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            Log.Debug("[Shopping manager] - Sold item (player): " + item.Record.GetRealName());
        }

        /// <summary>
        /// Purchases the item.
        /// </summary>
        /// <param name="tab">The tab.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="amount">The amount.</param>
        public static void PurchaseItem(int tab, int slot, ushort amount)
        {
            var npc = SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Cannot buy items, because no shop is selected!");
                return;
            }

            var packet = new Packet(0x7034);
            packet.WriteByte(0x08); //Buy item flag
            packet.WriteByte(tab);
            packet.WriteByte(slot);
            packet.WriteUShort(amount);
            packet.WriteUInt(npc.UniqueId);

            var awaitResult = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();
        }

        /// <summary>
        /// Repairs the items.
        /// </summary>
        public static void RepairItems(string npcCodeName)
        {
            if (!RepairGear)
                return;

            SelectNPC(npcCodeName);

            var npc = SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Cannot repair items because there is no smith selected!");
                return;
            }

            var packet = new Packet(0x703E);
            packet.WriteUInt(npc.UniqueId);
            packet.WriteByte(2); //repair all items

            PacketManager.SendPacket(packet, PacketDestination.Server);

            CloseShop();
        }

        /// <summary>
        /// Stores the items.
        /// </summary>
        /// <param name="npcCodeName">Name of the NPC code.</param>
        public static void StoreItems(string npcCodeName)
        {
            var tempInventory = Game.Player.Inventory.GetItems(x => x.Slot > 13 && StoreFilter.Invoke(x.Record));

            SelectNPC(npcCodeName);
            var npc = SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Cannot store items because there is no storage NPC selected!");
                return;
            }

            OpenStorage(npc.UniqueId);

            if (Game.Player.Storage == null)
                return;

            foreach (var item in tempInventory)
            {
                StoreItem(item, npc);
            }

            if (Game.Player.HasActiveAbilityPet && StorePetItems)
            {
                var petItemStoreList = Game.Player.AbilityPet.Inventory.GetItems(item => StoreFilter.Invoke(item.Record));

                foreach (var item in petItemStoreList)
                {
                    var playerSlot = Game.Player.AbilityPet.MoveItemToPlayer(item.Slot);
                    if (playerSlot != 0xFF)
                    {
                        var movedItem = Game.Player.Inventory.GetItemAt((byte)playerSlot);
                        StoreItem(movedItem, npc);
                    }
                }
            }

            CloseShop();
        }

        /// <summary>
        /// Closes the shop.
        /// </summary>
        private static void CloseShop()
        {
            if (SelectedEntity != null && SelectedEntity.TryDeselect())
                SelectedEntity = null;
        }

        /// <summary>
        /// Opens the storage.
        /// </summary>
        private static void OpenStorage(uint uniqueId)
        {
            if (Game.Player.Storage != null) return;

            var packet = new Packet(0x703C);
            packet.WriteInt(uniqueId);
            packet.WriteByte(0);

            var awaitResult = new AwaitCallback(null, 0x3049);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            packet = new Packet(0x7046);
            packet.WriteUInt(uniqueId);
            packet.WriteUInt(0x04);

            awaitResult = new AwaitCallback(null, 0xB046);

            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();
        }

        /// <summary>
        /// Opens the shop.
        /// </summary>
        /// <param name="npcCodeName">Name of the NPC code.</param>
        public static void SelectNPC(string npcCodeName)
        {
            if (!SpawnManager.TryGetEntity<SpawnedNpcNpc>(p => p.Record.CodeName == npcCodeName, out var entity))
            {
                Log.Debug("Cannot access the NPC [" + npcCodeName + "] because it does not exist nearby.");
                return;
            }

            entity.TrySelect();
        }

        /// <summary>
        /// Stores an item.
        /// </summary>
        /// <param name="item">Item to put in storage.</param>
        private static void StoreItem(InventoryItem item, SpawnedBionic npc)
        {
            //Use later to merge item!
            var existingItem = Game.Player.Storage.GetItem(item.Record.ID);

            //Store item
            var destinationSlot = Game.Player.Storage.GetFreeSlot();
            var packet = new Packet(0x7034);
            packet.WriteByte(0x02); //Store Item Flag
            packet.WriteByte(item.Slot);
            packet.WriteByte(destinationSlot);
            packet.WriteUInt(npc.UniqueId);

            var awaitResult = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            if (item.Record.MaxStack <= 1 || existingItem == null)
                return;

            //Merge with existing item.
            var mergeAmount = existingItem.Amount + item.Amount <= existingItem.Record.MaxStack
                ? item.Amount
                : existingItem.Record.MaxStack - existingItem.Amount;

            var mergePacket = new Packet(0x7034);
            mergePacket.WriteByte(0x01); //Store Item Flag
            mergePacket.WriteByte(destinationSlot);
            mergePacket.WriteByte(existingItem.Slot);
            mergePacket.WriteUShort(mergeAmount);
            mergePacket.WriteUInt(npc.UniqueId);

            awaitResult = new AwaitCallback(null, 0xB034);
            PacketManager.SendPacket(mergePacket, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public static void Stop()
        {
            Running = false;
            Finished = true;
        }
    }
}