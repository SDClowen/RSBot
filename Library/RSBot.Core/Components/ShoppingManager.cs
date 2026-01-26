using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Cos;
using RSBot.Core.Objects.Inventory;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using static RSBot.Core.Game;

namespace RSBot.Core.Components;

public static class ShoppingManager
{
    /// <summary>
    ///     Gets or sets the shopping list.
    /// </summary>
    /// <value>
    ///     The shopping list.
    /// </value>
    public static Dictionary<RefShopGood, int> ShoppingList { get; set; }

    /// <summary>
    ///     Gets a value indicating whether this <see cref="ShoppingManager" /> is finished.
    /// </summary>
    /// <value>
    ///     <c>true</c> if finished; otherwise, <c>false</c>.
    /// </value>
    public static bool Finished { get; private set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="ShoppingManager" /> is enabled.
    /// </summary>
    /// <value>
    ///     <c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    public static bool Enabled { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [repair gear].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [repair gear]; otherwise, <c>false</c>.
    /// </value>
    public static bool RepairGear { get; set; }

    /// <summary>
    ///     Gets or sets the sell filter.
    /// </summary>
    /// <value>
    ///     The armor sell filter.
    /// </value>
    public static List<string> SellFilter { get; set; }

    /// <summary>
    ///     Gets or sets the store filter.
    /// </summary>
    /// <value>
    ///     The store filter.
    /// </value>
    public static List<string> StoreFilter { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="ShoppingManager" /> is running.
    /// </summary>
    /// <value>
    ///     <c>true</c> if running; otherwise, <c>false</c>.
    /// </value>
    public static bool Running { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [sell pet items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [sell pet items]; otherwise, <c>false</c>.
    /// </value>
    public static bool SellPetItems { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [store pet items].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [store pet items]; otherwise, <c>false</c>.
    /// </value>
    public static bool StorePetItems { get; set; }

    /// <summary>
    ///     Gets or sets the buyback list.
    /// </summary>
    /// <value>
    ///     The buyback list.
    /// </value>
    internal static Dictionary<byte, InventoryItem> BuybackList { get; set; }

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    internal static void Initialize()
    {
        ShoppingList = new Dictionary<RefShopGood, int>();
        StoreFilter = new List<string>();
        SellFilter = new List<string>();
        BuybackList = new Dictionary<byte, InventoryItem>();

        Log.Debug("Initialized [ShoppingManager]!");
    }

    /// <summary>
    ///     Runs this instance.
    /// </summary>
    public static void Run(string npcCodeName)
    {
        if (!Enabled)
            return;

        Finished = false;
        Running = true;

        SelectNPC(npcCodeName);

        Log.Status("Selling items");

        //Prevent modification during the for-each loop
        var tempItemSellList = Game.Player.Inventory.GetNormalPartItems(item =>
            SellFilter.Any(p => p == item.Record.CodeName)
        );

        foreach (var item in tempItemSellList)
            SellItem(item);

        if (Game.Player.HasActiveAbilityPet && SellPetItems)
        {
            tempItemSellList = Game.Player.AbilityPet.Inventory.GetItems(item =>
                SellFilter.Any(p => p == item.Record.CodeName)
            );

            foreach (var item in tempItemSellList)
            {
                var playerSlot = Game.Player.AbilityPet.MoveItemToPlayer(item.Slot);
                if (playerSlot != 0xFF)
                    SellItem(Game.Player.Inventory.GetItemAt(playerSlot));
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

            Log.Status("Buying items");

            while (totalAmountToBuy > 0 && !Game.Player.Inventory.Full)
            {
                var amountStep = totalAmountToBuy;
                if (totalAmountToBuy >= refItem.MaxStack)
                    amountStep = refItem.MaxStack; //Buy only one stack

                PurchaseItem(tabIndex, actualItem.SlotIndex, (ushort)amountStep);
                totalAmountToBuy -= amountStep; //One stack bought, substract from total amount!
                Thread.Sleep(500);
            }

            //merge stacks
            if (refItem.MaxStack > 1)
            {
                IList<InventoryItem> getItems()
                {
                    return Game.Player.Inventory.GetItems(i =>
                        i.Record.CodeName == refPackageItem.RefItemCodeName && i.Amount < refItem.MaxStack
                    );
                }

                var nonFullStacks = getItems();
                while (nonFullStacks.Count >= 2)
                {
                    Game.Player.Inventory.MoveItem(
                        nonFullStacks[1].Slot,
                        nonFullStacks[0].Slot,
                        (ushort)Math.Min(refItem.MaxStack - nonFullStacks[0].Amount, nonFullStacks[1].Amount)
                    );
                    nonFullStacks = getItems();
                    Thread.Sleep(500);
                }
            }
        }

        CloseShop();

        Finished = true;
        Running = false;
    }

    /// <summary>
    ///     Sells the item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="cos"></param>
    public static void SellItem(InventoryItem item, SpawnedBionic cos = null)
    {
        if (SelectedEntity == null)
            return;

        var packet = new Packet(0x7034);
        packet.WriteByte(cos == null ? InventoryOperation.SP_SELL_ITEM : InventoryOperation.SP_SELL_ITEM_COS);

        if (cos != null)
            packet.WriteUInt(cos.UniqueId);

        packet.WriteByte(item.Slot);
        packet.WriteUShort(item.Amount);
        packet.WriteUInt(SelectedEntity.UniqueId);

        var awaitResult = new AwaitCallback(null, 0xB034);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();

        Log.Debug("[Shopping manager] - Sold item: " + item.Record.GetRealName());
    }

    /// <summary>
    ///     Purchases the item.
    /// </summary>
    /// <param name="tab">The tab.</param>
    /// <param name="slot">The slot.</param>
    /// <param name="amount">The amount.</param>
    public static void PurchaseItem(int tab, int slot, ushort amount)
    {
        if (SelectedEntity == null)
        {
            Log.Debug("Cannot buy items, because no shop is selected!");
            return;
        }

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_BUY_ITEM); //Buy item flag
        packet.WriteByte(tab);
        packet.WriteByte(slot);
        packet.WriteUShort(amount);
        packet.WriteUInt(SelectedEntity.UniqueId);

        var awaitResult = new AwaitCallback(null, 0xB034);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();
    }

    /// <summary>
    ///     Purchases the item to the given transport
    /// </summary>
    /// <param name="transport"></param>
    /// <param name="tab"></param>
    /// <param name="slot"></param>
    /// <param name="amount"></param>
    public static void PurchaseItem(Cos transport, int tab, int slot, ushort amount)
    {
        if (SelectedEntity == null)
        {
            Log.Debug("Cannot buy items, because no shop is selected!");
            return;
        }

        var packet = new Packet(0x7034);
        packet.WriteByte(InventoryOperation.SP_BUY_ITEM_COS); //Buy item flag
        packet.WriteUInt(0); //Always 0 but should actually be the transport's unique id as it would make more sense
        //packet.WriteUInt(transport.UniqueId); //may be 0?
        packet.WriteByte(tab);
        packet.WriteByte(slot);
        packet.WriteUShort(amount);
        packet.WriteUInt(SelectedEntity.UniqueId);

        var awaitResult = new AwaitCallback(null, 0xB034);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();
    }

    public static void ReceiveSupplies(string npcCodeName)
    {
        Finished = false;
        Running = true;

        uint questId = GetQuestId(npcCodeName);
        CloseShop();

        var currentWeapon = Game.Player.Weapon;
        IEnumerable<RefEventRewardItems> items = null;

        var excludedItemCodeNames = new List<string>();

        if (currentWeapon.Record.TypeID4 == 6) // Bow
            excludedItemCodeNames.Add("ITEM_ETC_LEVEL_BOLT");
        else if (currentWeapon.Record.TypeID4 == 12) // Crossbow
            excludedItemCodeNames.Add("ITEM_ETC_LEVEL_ARROW");
        else
            excludedItemCodeNames.AddRange(["ITEM_ETC_LEVEL_ARROW", "ITEM_ETC_LEVEL_BOLT"]);

        items = ReferenceManager
            .GetEventRewardItems(questId)
            .Where(r =>
                Game.Player.Level >= r.MinRequiredLevel
                && Game.Player.Level <= r.MaxRequiredLevel
                && !excludedItemCodeNames.Contains(r.ItemCodeName)
            );

        foreach (var item in items)
        {
            ReceiveQuestReward(npcCodeName, questId, item.Item.ID);
        }

        Finished = true;
        Running = false;
    }

    public static uint GetQuestId(string npcCodeName)
    {
        ChooseTalkOption(npcCodeName, TalkOption.Quest);

        var packet = new Packet(0x30D4); //AGENT_QUEST_TALK
        packet.WriteByte(5);

        uint questId = 0;

        var awaitCallback = new AwaitCallback(
            response =>
            {
                questId = response.ReadUInt();
                return AwaitCallbackResult.Success;
            },
            0x3514
        ); //AGENT_QUEST_REWARD_TALK

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();

        return questId;
    }

    public static void ReceiveQuestReward(string npcCodeName, uint questId, uint rewardId)
    {
        GetQuestId(npcCodeName);

        var packet = new Packet(0x7515); //AGENT_QUEST_REWAD_SELECT
        packet.WriteUInt(questId);
        packet.WriteByte(1);
        packet.WriteUInt(rewardId);
        PacketManager.SendPacket(packet, PacketDestination.Server);

        CloseShop();
    }

    /// <summary>
    ///     Repairs the items.
    /// </summary>
    public static void RepairItems(string npcCodeName)
    {
        if (!RepairGear)
            return;

        SelectNPC(npcCodeName);

        if (SelectedEntity == null)
        {
            Log.Debug("Cannot repair items because there is no smith selected!");
            return;
        }

        var packet = new Packet(0x703E);
        packet.WriteUInt(SelectedEntity.UniqueId);
        packet.WriteByte(2); //repair all items

        var awaitCallback = new AwaitCallback(
            response =>
            {
                var result = packet.ReadByte();

                if (result == 2)
                {
                    var errorCode = response.ReadUShort();

                    Log.Debug($"Repair of items at NPC {npcCodeName} failed [code={errorCode}]");

                    return AwaitCallbackResult.Fail;
                }

                return AwaitCallbackResult.Success;
            },
            0xB03E
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, awaitCallback);
        awaitCallback.AwaitResponse();

        CloseShop();
    }

    /// <summary>
    ///     Stores the items.
    /// </summary>
    /// <param name="npcCodeName">Name of the NPC code.</param>
    public static void StoreItems(string npcCodeName)
    {
        int firstSlot = 13;
        if (Game.ClientType == GameClientType.Global
            || Game.ClientType == GameClientType.Korean
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Turkey
            || Game.ClientType == GameClientType.Taiwan
            || Game.ClientType == GameClientType.Japanese)
            firstSlot = 17; //4 slots for relics

        var tempInventory = Game.Player.Inventory.GetItems(item =>
            item.Slot >= firstSlot && StoreFilter.Any(p => p == item.Record.CodeName)
        );

        SelectNPC(npcCodeName);
        var npc = SelectedEntity;
        if (npc == null)
        {
            Log.Debug("Cannot store items because there is no storage NPC selected!");
            return;
        }

        if (npc.Record.CodeName.Contains("WAREHOUSE"))
        {
            OpenStorage(npc.UniqueId);
            if (Game.Player.Storage == null)
                return;
        }
        else
        {
            OpenGuildStorage(npc.UniqueId);
            if (Game.Player.GuildStorage == null)
                return;
        }

        Log.Status("Storing items");
        foreach (var item in tempInventory)
            StoreItem(item, npc);

        if (Game.Player.HasActiveAbilityPet && StorePetItems)
        {
            var petItemStoreList = Game.Player.AbilityPet.Inventory.GetItems(item =>
                StoreFilter.Any(p => p == item.Record.CodeName)
            );

            foreach (var item in petItemStoreList)
            {
                var playerSlot = Game.Player.AbilityPet.MoveItemToPlayer(item.Slot);
                if (playerSlot != 0xFF)
                {
                    var movedItem = Game.Player.Inventory.GetItemAt(playerSlot);
                    StoreItem(movedItem, npc);
                }
            }
        }
        if (!npc.Record.CodeName.Contains("WAREHOUSE"))
            CloseGuildStorage(npc.UniqueId);

        if (Game.Clientless || npc.Record.CodeName.Contains("WAREHOUSE"))
            CloseShop();
        else
            CloseGuildShop();
    }

    public static void SortItems(string npcCodeName)
    {
        SelectNPC(npcCodeName);
        var npc = SelectedEntity;
        if (npc == null)
        {
            Log.Debug("Cannot sort items because there is no storage NPC selected!");
            return;
        }

        IList<InventoryItem> allStorageItems = null;

        if (npc.Record.CodeName.Contains("WAREHOUSE"))
        {
            OpenStorage(npc.UniqueId);
            Game.Player.Storage.Sort(npc);
            allStorageItems = Game.Player.Storage.GetItems(item => true);
        }
        else
        {
            OpenGuildStorage(npc.UniqueId);
            Game.Player.GuildStorage.Sort(npc);
            allStorageItems = Game.Player.GuildStorage.GetItems(item => true);
        }
        
        if (allStorageItems == null || allStorageItems.Count == 0)
        {
            if (!npc.Record.CodeName.Contains("WAREHOUSE"))
                CloseGuildStorage(npc.UniqueId);

            if (Game.Clientless || npc.Record.CodeName.Contains("WAREHOUSE"))
                CloseShop();
            else
                CloseGuildShop();

            return;
        }

        byte minSlot = allStorageItems.Min(i => i.Slot);
        byte maxSlot = allStorageItems.Max(i => i.Slot);

        for (byte i = minSlot; i <= maxSlot; i++)
        {
            // Get remaining items at or after slot i, ordered by grouping key
            List<InventoryItem> remaining = null;
            if (npc.Record.CodeName.Contains("WAREHOUSE"))
            { 
                remaining = Game.Player.Storage
                    .GetItems(it => it.Slot >= i)
                    .OrderBy(it => it.ItemId)
                    .ThenBy(it => it.Slot)
                    .ToList();
            }
            else
            {
                remaining = Game.Player.GuildStorage
                    .GetItems(it => it.Slot >= i)
                    .OrderBy(it => it.ItemId)
                    .ThenBy(it => it.Slot)
                    .ToList();
            }

            if (remaining == null || remaining.Count == 0)
                continue;

            var groupKey = remaining[0].Record.CodeName;

            // Find smallest slot among remaining items that match the group key
            var candidateSlots = remaining
                .Where(it => it.Record.CodeName == groupKey)
                .Select(it => it.Slot)
                .OrderBy(s => s)
                .ToList();

            if (candidateSlots == null || candidateSlots.Count == 0)
                break;

            var fromSlot = candidateSlots[0];

            if (fromSlot == i)
                continue;

            Log.Debug($"[ShoppingManager] Reordering storage: moving slot {fromSlot} to slot {i}");

            // Move the entire stack from 'fromSlot' to 'i'
            InventoryItem itemToMove;
            if (npc.Record.CodeName.Contains("WAREHOUSE"))
            {
                itemToMove = Game.Player.Storage.GetItemAt(fromSlot);
                if (itemToMove != null)
                {
                    Game.Player.Storage.MoveItem(fromSlot, i, (ushort)itemToMove.Amount, npc);
                    Thread.Sleep(500);
                }
            }
            else
            {
                itemToMove = Game.Player.GuildStorage.GetItemAt(fromSlot);
                if (itemToMove != null)
                {
                    Game.Player.GuildStorage.MoveItem(fromSlot, i, (ushort)itemToMove.Amount, npc);
                    Thread.Sleep(500);
                }
            }

        }

        if (!npc.Record.CodeName.Contains("WAREHOUSE"))
            CloseGuildStorage(npc.UniqueId);

        if (Game.Clientless || npc.Record.CodeName.Contains("WAREHOUSE"))
            CloseShop();
        else
            CloseGuildShop();
    }

    /// <summary>
    ///     Closes the shop.
    /// </summary>
    public static void CloseShop()
    {
        Running = false;

        if (SelectedEntity != null && SelectedEntity.TryDeselect())
            SelectedEntity = null;
    }

    /// <summary>
    ///     Closes the guild shop.
    /// </summary>
    public static void CloseGuildShop()
    {
        Running = false;

        if (SelectedEntity != null)
            SelectedEntity = null;
    }

    /// <summary>
    ///     Closes the guild storage.
    /// </summary>
    public static void CloseGuildStorage(uint uniqueId)
    {
        var packet = new Packet(0x7251);
        packet.WriteUInt(uniqueId);
        var awaitResult = new AwaitCallback(null, 0xB251);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();

        Thread.Sleep(2000);
    }

    /// <summary>
    ///     Opens the storage.
    /// </summary>
    private static void OpenStorage(uint uniqueId)
    {
        if (Game.Player.Storage != null)
            return;

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
    ///     Opens the guild storage.
    /// </summary>
    private static void OpenGuildStorage(uint uniqueId)
    {
        var packet = new Packet(0x7046);
        packet.WriteUInt(uniqueId);
        packet.WriteByte(0x0D);
        var awaitResult = new AwaitCallback(null, 0xB046);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();

        Thread.Sleep(2000);

        if (Game.Clientless)
        {
            packet = new Packet(0x7250);
            packet.WriteInt(uniqueId);
            awaitResult = new AwaitCallback(null, 0xB250);
            PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
            awaitResult.AwaitResponse();

            packet = new Packet(0x7252);
            packet.WriteInt(uniqueId);
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }
    }

    /// <summary>
    ///     Opens the shop.
    /// </summary>
    /// <param name="npcCodeName">Name of the NPC code.</param>
    public static void SelectNPC(string npcCodeName)
    {
        if (SelectedEntity != null && SelectedEntity.Record.CodeName == npcCodeName)
            return;

        if (!SpawnManager.TryGetEntity<SpawnedNpcNpc>(p => p.Record.CodeName == npcCodeName, out var entity))
        {
            Log.Warn("Cannot access the NPC [" + npcCodeName + "] because it does not exist nearby.");

            return;
        }

        entity.TrySelect();
    }

    /// <summary>
    ///     Stores an item.
    /// </summary>
    /// <param name="item">Item to put in storage.</param>
    private static void StoreItem(InventoryItem item, SpawnedBionic npc)
    {
        //Store item
        byte destinationSlot;
        if (npc.Record.CodeName.Contains("WAREHOUSE"))
        {
            destinationSlot = Game.Player.Storage.GetFreeSlot();
        }
        else
        {
            destinationSlot = Game.Player.GuildStorage.GetFreeSlot();
        }
        var packet = new Packet(0x7034);
        packet.WriteByte(npc.Record.CodeName.Contains("WAREHOUSE") ? 0x02 : 0x1E); //Store Item Flag (02 - warehouse; 1E - guild)
        packet.WriteByte(item.Slot);
        packet.WriteByte(destinationSlot);
        packet.WriteUInt(npc.UniqueId);

        var awaitResult = new AwaitCallback(null, 0xB034);
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse();
    }

    public static void LoadFilters()
    {
        var configSell = PlayerConfig.GetArray<string>("RSBot.Shopping.Sell");
        var configStore = PlayerConfig.GetArray<string>("RSBot.Shopping.Store");

        foreach (var item in configSell)
            SellFilter.Add(item);

        foreach (var item in configStore)
            StoreFilter.Add(item);
    }

    public static void SaveFilters()
    {
        PlayerConfig.SetArray("RSBot.Shopping.Sell", SellFilter);
        PlayerConfig.SetArray("RSBot.Shopping.Store", StoreFilter);
    }

    /// <summary>
    ///     Selects the given NPC and chooses the specified dialog option.
    /// </summary>
    /// <param name="npcCodeName"></param>
    /// <param name="option"></param>
    public static void ChooseTalkOption(string npcCodeName, TalkOption option)
    {
        if (!SpawnManager.TryGetEntity<SpawnedNpcNpc>(p => p.Record.CodeName == npcCodeName, out var entity))
        {
            Log.Debug("Cannot access the NPC [" + npcCodeName + "] because it does not exist nearby.");

            return;
        }

        SelectNPC(npcCodeName);
        //CloseShop();

        var packet = new Packet(0x7046);
        packet.WriteUInt(entity.UniqueId);
        packet.WriteByte(option);

        var awaitResult = new AwaitCallback(
            response =>
            {
                return response.ReadByte() == 0x01 && response.ReadByte() == (byte)option
                    ? AwaitCallbackResult.Success
                    : AwaitCallbackResult.ConditionFailed;
            },
            0xB046
        );
        PacketManager.SendPacket(packet, PacketDestination.Server, awaitResult);
        awaitResult.AwaitResponse(1000);
    }

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    public static void Stop()
    {
        Running = false;
        Finished = true;
    }
}
