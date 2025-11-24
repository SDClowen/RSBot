using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using RSBot.Core.Objects.Inventory;
using RSBot.Core.Objects.Item;

namespace RSBot.Core.Objects;

public class InventoryItem
{
    private byte _optLevel;

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public InventoryItemCosInfo Cos;

    /// <summary>
    ///     Gets or sets the item identifier.
    /// </summary>
    /// <value>
    ///     The item identifier.
    /// </value>
    public uint ItemId { get; set; }

    /// <summary>
    ///     Gets or sets the slot.
    /// </summary>
    /// <value>
    ///     The slot.
    /// </value>
    public byte Slot { get; set; }

    /// <summary>
    ///     Gets or sets the rental.
    /// </summary>
    /// <value>
    ///     The rental.
    /// </value>
    public RentInfo Rental { get; set; }

    /// <summary>
    ///     Gets or sets the record.
    /// </summary>
    /// <value>
    ///     The record.
    /// </value>
    public RefObjItem Record => Game.ReferenceManager.GetRefItem(ItemId);

    /// <summary>
    ///     Gets or sets the opt level.
    /// </summary>
    /// <value>
    ///     The opt level.
    /// </value>
    public byte OptLevel
    {
        get
        {
            if (BindingOptions == null)
                return _optLevel;

            var advancedElixirOptLevel = BindingOptions
                .Where(b => b.Type == BindingOptionType.AdvancedElixir)
                .Sum(b => b.Value != null ? b.Value : 0);

            if (_optLevel + advancedElixirOptLevel > byte.MaxValue)
                return byte.MaxValue;

            return (byte)(_optLevel + advancedElixirOptLevel);
        }
        set => _optLevel = value;
    }

    /// <summary>
    ///     Gets or sets the variance.
    /// </summary>
    /// <value>
    ///     The variance.
    /// </value>
    public ItemAttributesInfo Attributes { get; set; }

    /// <summary>
    ///     Gets or sets the data.
    /// </summary>
    /// <value>
    ///     The data.
    /// </value>
    public uint Durability { get; set; }

    /// <summary>
    ///     Gets or sets the magic options.
    /// </summary>
    /// <value>
    ///     The magic options.
    /// </value>
    public List<MagicOptionInfo> MagicOptions { get; set; }

    /// <summary>
    ///     Gets or sets the options.
    /// </summary>
    /// <value>
    ///     The options.
    /// </value>
    public List<BindingOption> BindingOptions { get; set; }

    /// <summary>
    ///     Gets or sets the amount.
    /// </summary>
    /// <value>
    ///     The amount.
    /// </value>
    public ushort Amount { get; set; }

    /// <summary>
    ///     Gets or sets the state.
    /// </summary>
    /// <value>
    ///     The state.
    /// </value>
    public InventoryItemState State { get; set; }

    /// <summary>
    ///     Gets a value indicating whether [item skill in use].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [item skill in use]; otherwise, <c>false</c>.
    /// </value>
    public bool ItemSkillInUse
    {
        get
        {
            //ToDo: Refine this whole check to act 1:1 like the client. I think Action_Overlap is a bitmap and not an actual value to work with.
            var refSkill = GetRefSkill();

            if (refSkill != null)
                return Game.Player.State.ActiveBuffs.FirstOrDefault(b =>
                        b.Record.ID == refSkill.ID || b.Record.Action_Overlap == refSkill.Action_Overlap
                    ) != null;

            var perk = Game.Player.State.ActiveItemPerks.Values.FirstOrDefault(p =>
                p.ItemId == Record.ID || (Record.Param1 > 0 && p.Item.Param1 == Record.Param1)
            );

            return perk != null;
        }
    }

    /// <summary>
    ///     Uses the item
    /// </summary>
    /// <returns></returns>
    public bool Use()
    {
        Log.Debug($"Using item tid: 0x{Record.Tid:x2} {Record.CodeName} {Record}");

        var packet = new Packet(0x704C);
        packet.WriteByte(Slot);

        if (Game.ClientType > GameClientType.Vietnam)
            packet.WriteInt(Record.Tid);
        else
            packet.WriteUShort(Record.Tid);

        var asyncCallback = new AwaitCallback(
            response => response.ReadByte() == 0x01 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail,
            0xB04C
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback);
        asyncCallback.AwaitResponse(500);

        return asyncCallback.IsCompleted;
    }

    /// <summary>
    ///     Use the item for destination item
    /// </summary>
    /// <param name="destinationSlot">The destination item slot</param>
    public bool UseTo(byte destinationSlot, int mapId = -1)
    {
        var packet = new Packet(0x704C);
        packet.WriteByte(Slot);

        if (Game.ClientType > GameClientType.Vietnam)
            packet.WriteInt(Record.Tid);
        else
            packet.WriteUShort(Record.Tid);

        packet.WriteByte(destinationSlot);

        if (mapId > -1)
            packet.WriteInt(mapId);

        var asyncCallback = new AwaitCallback(
            response => response.ReadByte() == 0x01 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail,
            0xB04C
        );

        PacketManager.SendPacket(packet, PacketDestination.Server, asyncCallback);
        asyncCallback.AwaitResponse(500);

        return asyncCallback.IsCompleted;
    }

    /// <summary>
    ///     Use the item for destination item
    /// </summary>
    /// <param name="destinationSlot">The destination item slot</param>
    public void UseFor(uint uniqueId)
    {
        var packet = new Packet(0x704C);
        packet.WriteByte(Slot);

        if (Game.ClientType > GameClientType.Vietnam)
            packet.WriteInt(Record.Tid);
        else
            packet.WriteUShort(Record.Tid);

        packet.WriteUInt(uniqueId);

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Equip the item
    /// </summary>
    /// <param name="slot">The slot</param>
    public bool Equip(byte slot)
    {
        var attempt = 0;
        while (
            !Game.Player.Inventory.MoveItem(Slot, slot)
            && Kernel.Bot.Running
            && Game.Player.State.ScrollState == ScrollState.Cancel
        )
        {
            if (attempt++ > 5)
                return false;

            Thread.Sleep(250);
        }

        return true;
    }

    /// <summary>
    ///     Drop the item
    /// </summary>
    public bool Drop(bool cos = false, uint? cosUniqueId = 0)
    {
        if (Record.CanDrop == ObjectDropType.No)
            return false;

        var packet = new Packet(0x7034);
        if (cos)
        {
            packet.WriteByte(InventoryOperation.SP_DROP_ITEM_COS);
            packet.WriteUInt(cosUniqueId);
        }
        else
        {
            packet.WriteByte(InventoryOperation.SP_DROP_ITEM);
        }

        packet.WriteByte(Slot);
        PacketManager.SendPacket(packet, PacketDestination.Server);

        return true;
    }

    /// <summary>
    ///     Parse from incoming packet
    /// </summary>
    /// <param name="packet">The packet</param>
    /// <param name="destinationSlot">The destination slot</param>
    /// <param name="hasDestinationSlot">The has destination slot</param>
    /// <returns></returns>
    public static InventoryItem FromPacket(Packet packet, byte destinationSlot = 0xFE)
    {
        var item = new InventoryItem
        {
            MagicOptions = new List<MagicOptionInfo>(),
            BindingOptions = new List<BindingOption>(),
            Amount = 1,
            Slot = destinationSlot,
        };

        if (destinationSlot == 0xFE)
            item.Slot = packet.ReadByte();

        if (Game.ClientType > GameClientType.Thailand)
            item.Rental = RentInfo.FromPacket(packet);

        item.ItemId = packet.ReadUInt();

        var record = item.Record;
        if (record == null)
        {
            Log.Notify("No item found for " + item.ItemId);

            return null;
        }

        if (record.IsEquip || record.IsFellowEquip || record.IsJobEquip)
        {
            item.OptLevel = packet.ReadByte();
            item.Attributes = new ItemAttributesInfo(packet.ReadULong());
            item.Durability = packet.ReadUInt();

            //Read magic options for the item
            var magicOptionsAmount = packet.ReadByte();
            for (var iMagicOption = 0; iMagicOption < magicOptionsAmount; iMagicOption++)
                item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));

            if (Game.ClientType > GameClientType.Thailand)
            {
                //Read sockets & advanced elixirs

                var bindingCount = 2;
                switch (Game.ClientType)
                {
                    case GameClientType.Chinese_Old:
                    case GameClientType.Chinese:
                    case GameClientType.Global:
                    case GameClientType.Turkey:
                    case GameClientType.Rigid:
                    case GameClientType.RuSro:
                    case GameClientType.VTC_Game:
                    case GameClientType.Japanese:
                    case GameClientType.Taiwan:
                        bindingCount = 4;
                        break;
                    case GameClientType.Korean:
                        bindingCount = 3;
                        break;
                }

                for (var bindingIndex = 0; bindingIndex < bindingCount; bindingIndex++)
                {
                    var bindingType = (BindingOptionType)packet.ReadByte();
                    var bindingAmount = packet.ReadByte();
                    for (var iSocketAmount = 0; iSocketAmount < bindingAmount; iSocketAmount++)
                        item.BindingOptions.Add(BindingOption.FromPacket(packet, bindingType));
                }
            }
        }
        else if (record.IsPet)
        {
            item.State = (InventoryItemState)packet.ReadByte();
            item.Amount = 1;

            if (item.State != InventoryItemState.Inactive)
            {
                item.Cos.Id = packet.ReadUInt(); //RefCharID
                item.Cos.Name = packet.ReadString(); //Name

                if (record.TypeID4 == 2)
                    item.Cos.Rental = RentInfo.FromPacket(packet);
                else if (Game.ClientType >= GameClientType.Chinese_Old)
                    item.Cos.Level = packet.ReadByte(); // cos level

                var buffCount = packet.ReadByte();
                for (var i = 0; i < buffCount; i++)
                {
                    var buffType = packet.ReadByte();
                    if (buffType == 0 || buffType == 20 || buffType == 6)
                    {
                        var itemId = packet.ReadUInt(); // buffType: 0 => skillId ? 20 => itemId
                        var leftTime = packet.ReadUInt();
                    }

                    if (buffType == 5)
                    {
                        var itemId = packet.ReadUInt();
                        var leftTime = packet.ReadUInt();
                        var leftTime2 = packet.ReadUInt();
                        var unk2 = packet.ReadByte();
                    }
                }
            }
        }
        else if (record.IsTransmonster)
        {
            item.Cos.Id = packet.ReadUInt(); //Monster ObjectId
        }
        else if (record.IsMagicCube)
        {
            item.Amount = (ushort)packet.ReadUInt(); //Quantity
        }
        else if (record.IsSpecialtyGoodBox)
        {
            item.Amount = (ushort)packet.ReadUInt(); //Quantity
        }
        else if (record.IsStackable) //ITEM_ETC
        {
            item.Amount = packet.ReadUShort();

            if (record.TypeID3 == 11) //Magic/Attr stone
            {
                if (record.TypeID4 == 1 || record.TypeID4 == 2)
                    packet.ReadByte();
            }
            else if (record.TypeID3 == 14 && record.TypeID4 == 2)
            {
                //ITEM_MALL_GACHA_CARD_WIN
                //ITEM_MALL_GACHA_CARD_LOSE
                var magParamCount = packet.ReadByte();
                for (var i = 0; i < magParamCount; i++)
                {
                    packet.ReadUInt();
                    packet.ReadUInt();
                }
            }

            if (record.IsTrading)
                //Owner name (Player name)
                packet.ReadString();
        }

        return item;
    }

    /// <summary>
    ///     Gets the filter.
    /// </summary>
    /// <returns></returns>
    public TypeIdFilter GetFilter()
    {
        return new TypeIdFilter(Record.TypeID1, Record.TypeID2, Record.TypeID3, Record.TypeID4);
    }

    public override string ToString()
    {
        return Record.CodeName;
    }

    public bool CanBeEquipped()
    {
        if (Record.IsAmmunition)
            return true;
        if (!Record.IsEquip)
            return false;
        if (Record.ReqLevel1 > Game.Player.Level)
            return false;
        if (Record.ReqGender != 2 && Record.ReqGender != (byte)Game.Player.Gender)
            return false;
        if (Record.Country != Game.Player.Record.Country)
            return false;

        return true;
    }

    public bool HasAbility(out RefAbilityByItemOptLevel abilityItem)
    {
        abilityItem = Game.ReferenceManager.GetAbilityItem(ItemId, OptLevel);

        return abilityItem != null;
    }

    public bool HasExtraAbility(out IEnumerable<RefExtraAbilityByEquipItemOptLevel> abilityItems)
    {
        abilityItems = Game.ReferenceManager.GetExtraAbilityItems(ItemId, OptLevel);

        return abilityItems != null;
    }

    public override bool Equals(object obj)
    {
        if (obj is TypeIdFilter filter)
            return filter.EqualsRefItem(Record);

        return false;
    }

    public RefSkill? GetRefSkill()
    {
        if (string.IsNullOrEmpty(Record.Desc1))
            return null;

        return Game.ReferenceManager.GetRefSkill(Record.Desc1);
    }

    public InventoryItem Clone()
    {
        return (InventoryItem)MemberwiseClone();
    }

    public override int GetHashCode()
    {
        return Record.GetHashCode();
    }
}
