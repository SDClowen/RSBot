using System.Collections.Generic;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Cos;
using RSBot.Core.Objects.Inventory;
using RSBot.Core.Objects.Item;

namespace RSBot.Core.Network.Handler.Agent.Inventory;

internal class InventoryOperationResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB034;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var result = packet.ReadByte();
        if (result != 0x01)
        {
            var code = packet.ReadByte();

            Log.Debug($"ItemOperation error received:  [{result:X}] ({code:X})");
            return;
        }

        var type = (InventoryOperation)packet.ReadByte();
        switch (type)
        {
            case InventoryOperation.SP_UPDATE_SLOTS_INV:

                Game.Player.Inventory.Move(packet);

                //e.g when equipping a Bow (see ammo)
                if (packet.ReadBool())
                    if (packet.ReadByte() == 0x00)
                        Game.Player.Inventory.Move(packet);

                break;

            case InventoryOperation.SP_UPDATE_SLOTS_CHEST:
                Game.Player.Storage.Move(packet);
                break;

            case InventoryOperation.SP_DEPOSIT_ITEM:
                Game.Player.Inventory.MoveTo(Game.Player.Storage, packet);
                break;

            case InventoryOperation.SP_WITHDRAW_ITEM:
                Game.Player.Storage.MoveTo(Game.Player.Inventory, packet);
                break;

            case InventoryOperation.SP_PICK_ITEM:
                ParseFloorToInventory(packet, Game.Player.Inventory);
                break;

            case InventoryOperation.SP_DROP_ITEM:
                ParseDeleteItemByServer(packet);
                break;

            case InventoryOperation.SP_BUY_ITEM:
                ParseNpcToInventory(packet, Game.Player.Inventory, Game.Player.UniqueId);
                break;

            case InventoryOperation.SP_SELL_ITEM:
                ParseInventoryToNpc(packet, Game.Player.Inventory);
                break;

            case InventoryOperation.SP_DROP_GOLD:
                ParseGoldToFloor(packet);
                break;

            case InventoryOperation.SP_DEPOSIT_GOLD:
                ParseGoldToStorage(packet, Game.Player.Storage);
                break;

            case InventoryOperation.SP_WITHDRAW_GOLD:
                ParseStorageToGold(packet, Game.Player.Storage);
                break;

            case InventoryOperation.SP_ADD_ITEM_BY_SERVER:
                ParseAddItemByServer(packet);
                break;

            case InventoryOperation.SP_DEL_ITEM_BY_SERVER:
                ParseDeleteItemByServer(packet);
                break;

            case InventoryOperation.SP_UPDATE_SLOTS_INV_COS:
                ParseCosInventoryMoving(packet);
                break;

            case InventoryOperation.SP_PICK_ITEM_COS:
                ParseFloorToCos(packet);
                break;

            case InventoryOperation.SP_DROP_ITEM_COS:
                ParseCosToFloor(packet);
                break;

            case InventoryOperation.SP_BUY_ITEM_COS:
                ParseNpcToCos(packet);
                break;

            case InventoryOperation.SP_SELL_ITEM_COS:
                ParseCosToNpc(packet);
                break;

            case InventoryOperation.SP_DEL_COSITEM_BY_SERVER:
                ParseDeleteCosItemByServer(packet);
                break;

            case InventoryOperation.SP_BUY_CASH_ITEM:
                ParseMallToPlayer(packet);
                break;

            case InventoryOperation.SP_MOVE_ITEM_PET_PC:
                ParseCosToInventory(packet);
                break;

            case InventoryOperation.SP_MOVE_ITEM_PC_PET:
                ParseInventoryToCos(packet);
                break;

            case InventoryOperation.SP_PICK_ITEM_BY_OTHER:
                ParseOtherToInventory(packet);
                break;

            case InventoryOperation.SP_GUILD_CHEST_UPDATE_SLOT:
                Game.Player.GuildStorage.Move(packet);
                break;

            case InventoryOperation.SP_GUILD_CHEST_DEPOSIT_ITEM:
                Game.Player.Inventory.MoveTo(Game.Player.GuildStorage, packet);
                break;

            case InventoryOperation.SP_GUILD_CHEST_WITHDRAW_ITEM:
                Game.Player.GuildStorage.MoveTo(Game.Player.Inventory, packet);
                break;

            case InventoryOperation.SP_GUILD_CHEST_DEPOSIT_GOLD:
                ParseGoldToStorage(packet, Game.Player.GuildStorage);
                break;

            case InventoryOperation.SP_GUILD_CHEST_WITHDRAW_GOLD:
                ParseStorageToGold(packet, Game.Player.GuildStorage);
                break;

            case InventoryOperation.SP_RESTORE_SOLDITEM_INSHOP:
                ParseBuybackToInventory(packet);
                break;

            case InventoryOperation.SP_MOVE_ITEM_AVATAR_PC:

                Game.Player.Avatars.MoveTo(Game.Player.Inventory, packet);
                packet.ReadUShort(); // amount

                if (packet.ReadBool())
                    if (packet.ReadByte() == 0x23)
                        Game.Player.Avatars.MoveTo(Game.Player.Inventory, packet);

                break;

            case InventoryOperation.SP_MOVE_ITEM_PC_AVATAR:

                Game.Player.Inventory.MoveTo(Game.Player.Avatars, packet);
                packet.ReadUShort(); // amount

                if (packet.ReadBool())
                    if (packet.ReadByte() == 0x00)
                        Game.Player.Inventory.MoveTo(Game.Player.Avatars, packet);

                break;

            case InventoryOperation.SP_MOVE_ITEM_PC_JOB:

                Game.Player.Inventory.MoveTo(Game.Player.Job2, packet);
                packet.ReadUShort(); // amount

                break;

            case InventoryOperation.SP_MOVE_ITEM_JOB_PC:

                Game.Player.Job2.MoveTo(Game.Player.Inventory, packet);
                packet.ReadUShort(); // amount

                break;

            case InventoryOperation.SP_BUY_ITEM_WITH_TOKEN:
                ParseTokenNpcToInventory(packet);
                break;

            case InventoryOperation.SP_PICK_SPECIAL_GOODS:
                ParseFloorToSpecialtyBag(packet);
                break;

            case InventoryOperation.SP_MOVE_ITEM_BAG_TO_JOBTRANSPORT:

                var cosUniqueId = packet.ReadUInt();
                Cos cos = Game.Player.JobTransport;
                if (cos == null || cosUniqueId != cos.UniqueId)
                    return;

                Game.Player.Job2SpecialtyBag.MoveTo(cos.Inventory, packet);

                break;

            case InventoryOperation.SP_DELETE_BAG_ITEM_BY_SERVER:

                var sourceSlot = packet.ReadByte();
                Game.Player.Job2SpecialtyBag.RemoveAt(sourceSlot);

                break;

            default:
                Log.Error(
                    $"If you see this message i, please open an issue by explaining your last inventory operation! InventoryOperationType: {type}"
                );
                break;
        }

        EventManager.FireEvent("OnInventoryUpdate");
    }

    /// <summary>
    ///     Parses the floor to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseFloorToSpecialtyBag(Packet packet)
    {
        var unknown1 = packet.ReadUInt();

        ParseFloorToInventory(packet, Game.Player.Job2SpecialtyBag);
    }

    /// <summary>
    ///     Parses the floor to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseFloorToInventory(Packet packet, InventoryItemCollection inventory)
    {
        var destinationSlot = packet.ReadByte();

        if (destinationSlot == 0xFE) //gold
        {
            var goldAmount = packet.ReadUInt();
            Game.Player.Gold += goldAmount;

            EventManager.FireEvent("OnPickupGold", goldAmount);

            Log.Notify($"Picked up [{goldAmount}] gold");
            return;
        }

        var item = InventoryItem.FromPacket(packet, destinationSlot);
        var itemAtSlot = inventory.GetItemAt(item.Slot);

        if (itemAtSlot != null)
        {
            itemAtSlot.Amount = item.Amount;

            EventManager.FireEvent("OnUpdateInventoryItem", itemAtSlot.Slot);
            Log.Debug(
                $"[Floor->Inventory] Merge item {itemAtSlot.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount})"
            );
        }
        else
        {
            inventory.Add(item);

            Log.Debug(
                $"[Floor->Inventory] Add item {item.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount}"
            );
        }

        Log.Notify($"Picked up item [{item.Record.GetRealName(true)}]");

        EventManager.FireEvent("OnPickupItem", item);
    }

    /// <summary>
    ///     Parses the NPC to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseNpcToInventory(Packet packet, InventoryItemCollection inventory, uint entityUniqueId)
    {
        byte[] destinationSlots = null;
        ushort amount = 0;
        byte itemAmount = 0;

        var tabIndex = packet.ReadByte();
        var tabSlot = packet.ReadByte();

        if (Game.ClientType >= GameClientType.Chinese && Game.ClientType != GameClientType.Rigid)
        {
            amount = packet.ReadUShort();
            itemAmount = packet.ReadByte();
            destinationSlots = packet.ReadBytes(itemAmount);
        }
        else
        {
            itemAmount = packet.ReadByte();
            destinationSlots = packet.ReadBytes(itemAmount);
            amount = packet.ReadUShort();
        }

        var npc = Game.SelectedEntity;
        if (npc == null)
        {
            Log.Debug("Could not determine which item was bought, since currently no entity is selected.");
            return;
        }

        var refShopGoodObj = Game.ReferenceManager.GetRefPackageItem(npc.Record.CodeName, tabIndex, tabSlot);
        var item = Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

        if (item.IsStackable && refShopGoodObj.Data > 0)
            amount = (ushort)refShopGoodObj.Data;

        Log.Notify($"Bought [{item.GetRealName(true)}] x {amount} from [{npc.Record.GetRealName()}]");

        //_ETC_
        if (itemAmount != destinationSlots.Length)
        {
            inventory.Add(
                new InventoryItem
                {
                    Slot = destinationSlots[0],
                    Amount = amount,
                    ItemId = item.ID,
                    Durability = (uint)refShopGoodObj.Data,
                    Attributes = new ItemAttributesInfo((ulong)refShopGoodObj.Variance),
                    OptLevel = refShopGoodObj.OptLevel,
                }
            );

            EventManager.FireEvent("OnBuyItem", destinationSlots[0], entityUniqueId);
        }
        else
        {
            foreach (var slot in destinationSlots)
            {
                inventory.Add(
                    new InventoryItem
                    {
                        Slot = slot,
                        Amount = amount,
                        ItemId = item.ID,
                        Durability = (uint)refShopGoodObj.Data,
                        Attributes = new ItemAttributesInfo((ulong)refShopGoodObj.Variance),
                        OptLevel = refShopGoodObj.OptLevel,
                    }
                );

                EventManager.FireEvent("OnBuyItem", slot, entityUniqueId);
            }
        }
    }

    /// <summary>
    ///     Parses the NPC to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseTokenNpcToInventory(Packet packet)
    {
        var inventory = Game.Player.Inventory;
        ParseNpcToInventory(packet, inventory, Game.Player.UniqueId);

        var unknown1 = packet.ReadByte();
        var tokenSlot = packet.ReadByte();
        var updatedTokenCount = packet.ReadUShort();
        var unknown2 = packet.ReadInt();

        inventory.UpdateItemAmount(tokenSlot, updatedTokenCount);
    }

    /// <summary>
    ///     Parses the inventory to NPC.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseInventoryToNpc(Packet packet, InventoryItemCollection inventory)
    {
        var sourceSlot = packet.ReadByte();
        var amount = packet.ReadUShort();
        var uniqueId = packet.ReadUInt();
        var buybackSlot = packet.ReadByte();

        var itemAtSlot = inventory.GetItemAt(sourceSlot);
        if (itemAtSlot == null)
            return;

        if (buybackSlot != byte.MaxValue)
        {
            buybackSlot -= 1;

            if (ShoppingManager.BuybackList.ContainsKey(buybackSlot))
                ShoppingManager.BuybackList[buybackSlot] = itemAtSlot;
            else
                ShoppingManager.BuybackList.Add(buybackSlot, itemAtSlot);
        }

        if (amount == itemAtSlot.Amount)
        {
            inventory.RemoveAt(sourceSlot);

            Log.Debug(
                $"[Inventory->NPC] Remove item {itemAtSlot.Record.GetRealName()} (slot={sourceSlot}, amount={amount})"
            );
        }
        else
        {
            inventory.UpdateItemAmount(sourceSlot, (ushort)(itemAtSlot.Amount - amount));

            Log.Debug(
                $"[Inventory->NPC] Update item {itemAtSlot.Record.GetRealName()} (slot={sourceSlot}, amount={amount})"
            );
        }

        Log.Notify($"Sold item [{itemAtSlot.Record.GetRealName()}] x {amount}");
    }

    /// <summary>
    ///     Parses the gold to floor.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseGoldToFloor(Packet packet)
    {
        Game.Player.Gold -= packet.ReadULong();
    }

    /// <summary>
    ///     Parses the gold to storage.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseGoldToStorage(Packet packet, Storage storage)
    {
        var gold = packet.ReadULong();
        var userGold = Game.Player.Gold - gold;
        Game.Player.Gold = userGold;

        storage.Gold += userGold;

        EventManager.FireEvent("OnStorageGoldUpdated");
    }

    /// <summary>
    ///     Parses the storage to gold.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseStorageToGold(Packet packet, Storage storage)
    {
        var gold = packet.ReadULong();
        var userGold = Game.Player.Gold + gold;

        Game.Player.Gold = userGold;
        storage.Gold -= gold;

        EventManager.FireEvent("OnStorageGoldUpdated");
    }

    /// <summary>
    ///     Parses the add item by server.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseAddItemByServer(Packet packet)
    {
        var destinationSlot = packet.ReadByte();
        packet.ReadByte(); //Reason?

        Game.Player.Inventory.Add(InventoryItem.FromPacket(packet, destinationSlot));
    }

    /// <summary>
    ///     Parses the delete item by server.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseDeleteItemByServer(Packet packet)
    {
        var sourceSlot = packet.ReadByte();
        Game.Player.Inventory.RemoveAt(sourceSlot);

        Log.Debug($"[Inventory->Delete] Remove item (slot={sourceSlot})");
    }

    /// <summary>
    ///     Parses the delete item by server.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseDeleteCosItemByServer(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        var sourceSlot = packet.ReadByte();
        var reason = packet.ReadByte();

        cos.Inventory.RemoveAt(sourceSlot);

        Log.Debug($"[Inventory->Delete] Remove cos item (slot={sourceSlot})");
    }

    /// <summary>
    ///     Parses the pet to pet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseCosInventoryMoving(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        cos.Inventory.Move(packet);
    }

    /// <summary>
    ///     Parses the floor to pet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseFloorToCos(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        ParseFloorToInventory(packet, cos.Inventory);
    }

    /// <summary>
    ///     Parses the pet to floor.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseCosToFloor(Packet packet)
    {
        var uniqueId = packet.ReadUInt();
        var sourceSlot = packet.ReadByte();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        cos.Inventory.RemoveAt(sourceSlot);
        Log.Debug($"[Pet->Floor] Remove item (slot={sourceSlot})");
    }

    /// <summary>
    ///     Parses the NPC to pet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseNpcToCos(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        ParseNpcToInventory(packet, cos.Inventory, cos.UniqueId);
    }

    /// <summary>
    ///     Parses the pet to NPC.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseCosToNpc(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        Cos cos = null;

        if (uniqueId == Game.Player.AbilityPet?.UniqueId)
            cos = Game.Player.AbilityPet;
        else if (uniqueId == Game.Player.JobTransport?.UniqueId)
            cos = Game.Player.JobTransport;

        if (cos == null)
            return;

        ParseInventoryToNpc(packet, cos.Inventory);
    }

    /// <summary>
    ///     Parses the mall to player.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseMallToPlayer(Packet packet)
    {
        var refShopGroupId = packet.ReadUShort();
        var groupIndex = packet.ReadByte();
        var tabIndex = packet.ReadByte();
        var slotIndex = packet.ReadByte();
        var itemCount = packet.ReadByte();

        var refShopGoodObj = Game.ReferenceManager.GetRefPackageItemById(
            refShopGroupId,
            groupIndex,
            tabIndex,
            slotIndex
        );
        var itemInfo = Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

        if (refShopGoodObj != null && itemInfo != null)
        {
            var itemSlots = packet.ReadBytes(itemCount);
            var quantity = packet.ReadUShort();

            var amount = refShopGoodObj.Data;

            if (itemCount != quantity)
                amount = quantity;

            if (amount == 0)
                amount = 1;

            foreach (var slot in itemSlots)
            {
                var item = new InventoryItem
                {
                    Slot = slot,
                    Amount = (ushort)amount,
                    ItemId = itemInfo.ID,
                    Durability = (uint)refShopGoodObj.Data,
                    Attributes = new ItemAttributesInfo((ulong)refShopGoodObj.Variance),
                    OptLevel = refShopGoodObj.OptLevel,
                };

                if (Game.ClientType > GameClientType.Thailand)
                    item.Rental = RentInfo.FromPacket(packet);

                Game.Player.Inventory.Add(item);
            }
        }
    }

    /// <summary>
    ///     Parses the pet to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseCosToInventory(Packet packet)
    {
        var petUniqueId = packet.ReadUInt();

        var cos = Game.Player.AbilityPet;

        if (!Game.Player.HasActiveAbilityPet || cos.UniqueId != petUniqueId)
            return;

        cos.Inventory.MoveTo(Game.Player.Inventory, packet);
    }

    /// <summary>
    ///     Parses the inventory to pet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseInventoryToCos(Packet packet)
    {
        var petUniqueId = packet.ReadUInt();
        var cos = Game.Player.AbilityPet;

        if (!Game.Player.HasActiveAbilityPet || cos.UniqueId != petUniqueId)
            return;

        Game.Player.Inventory.MoveTo(cos.Inventory, packet);
    }

    /// <summary>
    ///     Parses the other to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseOtherToInventory(Packet packet)
    {
        var uniqueId = packet.ReadUInt(); // picker uniqueId

        var destinationSlot = packet.ReadByte();
        if (destinationSlot == 0xFE)
        {
            Game.Player.Gold += packet.ReadUInt();
        }
        else
        {
            var item = InventoryItem.FromPacket(packet, destinationSlot);
            var itemAtSlot = Game.Player.Inventory.GetItemAt(destinationSlot);

            if (itemAtSlot == null)
                Game.Player.Inventory.Add(item);
            else
                itemAtSlot.Amount = item.Amount;

            EventManager.FireEvent("OnPartyPickItem", item);
        }
    }

    /// <summary>
    ///     Parses the buyback to inventory.
    /// </summary>
    /// <param name="packet">The packet.</param>
    private static void ParseBuybackToInventory(Packet packet)
    {
        var destinationSlot = packet.ReadByte();
        var sourceSlot = packet.ReadByte();
        var amount = packet.ReadUShort();

        var itemAtSource = ShoppingManager.BuybackList[sourceSlot];
        itemAtSource.Slot = destinationSlot;
        itemAtSource.Amount = amount;

        Game.Player.Inventory.Add(itemAtSource);

        Log.Debug("Buyback: " + itemAtSource.Record.GetRealName());
        var newBuybackList = new Dictionary<byte, InventoryItem>();

        foreach (var item in ShoppingManager.BuybackList)
        {
            if (item.Key == sourceSlot)
                continue;

            newBuybackList.Add(item.Key > sourceSlot ? (byte)(item.Key - 1) : item.Key, item.Value);
        }

        ShoppingManager.BuybackList = newBuybackList;
    }
}
