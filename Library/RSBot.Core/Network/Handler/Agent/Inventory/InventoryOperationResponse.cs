using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using System.Collections.Generic;

namespace RSBot.Core.Network.Handler.Agent.Inventory
{
    internal class InventoryOperationResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB034;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
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

            var type = packet.ReadByte();

            switch (type)
            {
                case 0: // InventoryToInventory
                    ParseInventoryTypes(InventoryType.Inventory, InventoryType.Inventory, packet);
                    // 2nd item - e.g when equipping a Bow (see ammo)
                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x00)
                            ParseInventoryTypes(InventoryType.Inventory, InventoryType.Inventory, packet);
                    break;

                case 1: // StorageToStorage
                    ParseInventoryTypes(InventoryType.Storage, InventoryType.Storage, packet);
                    break;

                case 2: // InventoryToStorage
                    ParseInventoryTypes(InventoryType.Inventory, InventoryType.Storage, packet);
                    break;

                case 3: // StorageToInventory
                    ParseInventoryTypes(InventoryType.Storage, InventoryType.Inventory, packet);
                    break;

                case 4: //exchange in
                case 5: //exchange out
                    break;

                case 6:
                    ParseFloorToInventory(packet);
                    break;

                case 7:
                    ParseInventoryToFloor(packet);
                    break;

                case 8:
                    ParseNpcToInventory(packet);
                    break;

                case 9:
                    ParseInventoryToNpc(packet);
                    break;

                case 10: //Drop gold
                    ParseGoldToFloor(packet);
                    break;

                case 11: //Deposit gold
                    ParseGoldToStorage(packet);
                    break;

                case 12: //Withdraw gold
                    ParseStorageToGold(packet);
                    break;

                case 13: //Update exchange gold
                    break;

                case 14:
                    ParseAddItemByServer(packet);
                    break;

                case 15:
                    ParseDeleteItemByServer(packet);
                    break;

                case 16: // PetToPet
                    ParseInventoryTypes(InventoryType.Pet, InventoryType.Pet, packet);
                    break;

                case 17:
                    ParseFloorToPet(packet);
                    break;

                case 18:
                    ParsePetToFloor(packet);
                    break;

                case 19:
                    ParseNpcToPet(packet);
                    break;

                case 20:
                    ParsePetToNpc(packet);
                    break;

                case 21: //Delete cos item by server
                    break;

                case 24:
                    ParseMallToPlayer(packet);
                    break;

                case 26: // PetToInventory
                    ParseInventoryTypes(InventoryType.Pet, InventoryType.Inventory, packet);
                    break;

                case 27: // InventoryToPet
                    ParseInventoryTypes(InventoryType.Inventory, InventoryType.Pet, packet);
                    break;

                case 28:
                    ParseOtherToInventory(packet);
                    break;

                case 29: // GuildStorageToGuildStorage
                    ParseInventoryTypes(InventoryType.GuildStorage, InventoryType.GuildStorage, packet);
                    break;

                case 30: // InventoryToGuildStorage
                    ParseInventoryTypes(InventoryType.Inventory, InventoryType.GuildStorage, packet);
                    break;

                case 31: // GuildStorageToInventory
                    ParseInventoryTypes(InventoryType.GuildStorage, InventoryType.Inventory, packet);
                    break;

                case 32:
                    ParseGoldToGuildStorage(packet);
                    break;

                case 33:
                    ParseGuildStorageToGold(packet);
                    break;

                case 34: //Buy back
                    ParseBuybackToInventory(packet);
                    break;

                case 35: // AvatarToInventory
                    ParseInventoryTypes(InventoryType.Avatars, InventoryType.Inventory, packet);

                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x23)
                            ParseInventoryTypes(InventoryType.Avatars, InventoryType.Inventory, packet); ;
                    break;

                case 36: // InventoryToAvatar
                    ParseInventoryTypes(InventoryType.Inventory, InventoryType.Avatars, packet);

                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x00)
                            ParseInventoryTypes(InventoryType.Inventory, InventoryType.Avatars, packet);
                    break;
            }

            EventManager.FireEvent("OnInventoryUpdate");
        }

        /// <summary>
        /// Parses the floor to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseFloorToInventory(Packet packet)
        {
            var destinationSlot = packet.ReadByte();

            if (destinationSlot == 0xFE) //gold
            {
                Core.Game.Player.Gold += packet.ReadUInt();
                return;
            }

            var item = InventoryItem.FromPacket(packet, destinationSlot);
            var itemAtSlot = Core.Game.Player.Inventory.GetItemAt(item.Slot);

            if (itemAtSlot != null)
            {
                itemAtSlot.Amount = item.Amount;

                EventManager.FireEvent("OnUpdateInventoryItem", itemAtSlot.Slot);
                Log.Debug(
                    $"[Floor->Inventory] Merge item {itemAtSlot.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount})");
            }
            else
            {
                Core.Game.Player.Inventory.AddItem(item);

                Log.Debug($"[Floor->Inventory] Add item {item.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount}");
            }

            Log.Notify($"Picked up item [{item.Record.GetRealName(true)}]");

            EventManager.FireEvent("OnPickupItem", item);
        }

        /// <summary>
        /// Parses the inventory to floor.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToFloor(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);

            Log.Debug($"[Inventory->Floor] Remove item (slot={sourceSlot})");
        }

        /// <summary>
        /// Parses the NPC to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseNpcToInventory(Packet packet)
        {
            byte[] destinationSlots = null;
            ushort amount = 0;
            byte itemAmount = 0;

            var tabIndex = packet.ReadByte();
            var tabSlot = packet.ReadByte();

            if(Core.Game.ClientType > GameClientType.Chinese)
            {
                amount = packet.ReadUShort();
                itemAmount = packet.ReadByte();
                destinationSlots = packet.ReadByteArray(itemAmount);
            }
            else
            {
                itemAmount = packet.ReadByte();
                destinationSlots = packet.ReadByteArray(itemAmount);
                amount = packet.ReadUShort();
            }

            var npc = Core.Game.SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Could not determine which item was bought, since currently no entity is selected.");
                return;
            }
            
            var refShopGoodObj = Core.Game.ReferenceManager.GetRefPackageItem(npc.Record.CodeName, tabIndex, tabSlot);
            var item = Core.Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

            Log.Notify($"Bought [{item.GetRealName(true)}] x {amount} from [{npc.Record.GetRealName()}]");

            //_ETC_
            if (itemAmount != destinationSlots.Length)
            {
                Core.Game.Player.Inventory.AddItem(new InventoryItem
                {
                    Slot = destinationSlots[0],
                    Amount = amount,
                    ItemId = item.ID,
                    Durability = (uint)refShopGoodObj.Data,
                    Variance = (ulong)refShopGoodObj.Variance,
                    OptLevel = refShopGoodObj.OptLevel
                });

                EventManager.FireEvent("OnBuyItem", destinationSlots[0]);
            }
            else
            {
                foreach (var slot in destinationSlots)
                {
                    Core.Game.Player.Inventory.AddItem(new InventoryItem
                    {
                        Slot = slot,
                        Amount = amount,
                        ItemId = item.ID,
                        Durability = (uint)refShopGoodObj.Data,
                        Variance = (ulong)refShopGoodObj.Variance,
                        OptLevel = refShopGoodObj.OptLevel
                    });

                    EventManager.FireEvent("OnBuyItem", slot);
                }
            }
        }

        /// <summary>
        /// Parses the inventory to NPC.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToNpc(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var amount = packet.ReadUShort();
            var uniqueId = packet.ReadUInt();
            var buybackSlot = packet.ReadByte();

            var itemAtSlot = Core.Game.Player.Inventory.GetItemAt(sourceSlot);
            if (itemAtSlot == null)
                return;

            if(buybackSlot != byte.MaxValue)
			{
				buybackSlot -= 1;
				
				if (ShoppingManager.BuybackList.ContainsKey(buybackSlot))
					ShoppingManager.BuybackList[buybackSlot] = itemAtSlot;
				else
					ShoppingManager.BuybackList.Add(buybackSlot, itemAtSlot);
			}
			
            if (amount == itemAtSlot.Amount)
            {
                Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);

                Log.Debug($"[Inventory->NPC] Remove item {itemAtSlot.Record.GetRealName()} (slot={sourceSlot}, amount={amount})");
            }
            else
            {
                Core.Game.Player.Inventory.UpdateItemAmount(sourceSlot, (ushort)(itemAtSlot.Amount - amount));

                Log.Debug($"[Inventory->NPC] Update item {itemAtSlot.Record.GetRealName()} (slot={sourceSlot}, amount={amount})");
            }
            Log.Notify($"Sold item [{itemAtSlot.Record.GetRealName()}] x {amount}");
        }

        /// <summary>
        /// Parses the gold to floor.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGoldToFloor(Packet packet)
        {
            Core.Game.Player.Gold -= packet.ReadULong();
        }

        /// <summary>
        /// Parses the gold to storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGoldToStorage(Packet packet)
        {
            Core.Game.Player.Gold -= packet.ReadULong();
        }

        /// <summary>
        /// Parses the storage to gold.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseStorageToGold(Packet packet)
        {
            Core.Game.Player.Gold += packet.ReadULong();
        }

        /// <summary>
        /// Parses the add item by server.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseAddItemByServer(Packet packet)
        {
            var destinationSlot = packet.ReadByte();
            packet.ReadByte(); //Reason?

            Core.Game.Player.Inventory.AddItem(InventoryItem.FromPacket(packet, destinationSlot));
        }

        /// <summary>
        /// Parses the delete item by server.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseDeleteItemByServer(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);
        }

        /// <summary>
        /// Parses the floor to pet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseFloorToPet(Packet packet)
        {
            var petUniqueId = packet.ReadUInt();

            if (!Core.Game.Player.HasActiveAbilityPet || Core.Game.Player.AbilityPet.UniqueId != petUniqueId) return;

            var destinationSlot = packet.ReadByte();
            if (destinationSlot == 0xFE) //gold
            {
                Core.Game.Player.Gold += packet.ReadUInt();
                return;
            }

            var item = InventoryItem.FromPacket(packet, destinationSlot);
            var itemAtSlot = Core.Game.Player.AbilityPet.Inventory.GetItemAt(item.Slot);

            if (itemAtSlot != null)
            {
                itemAtSlot.Amount = item.Amount;

                Log.Debug($"[Floor->Pet] Merge item {itemAtSlot.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount})");
            }
            else
            {
                Core.Game.Player.AbilityPet.Inventory.AddItem(item);
                Log.Debug($"[Floor->Pet] Add item {item.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount}");
            }

            EventManager.FireEvent("OnPickupItem", item);
        }

        /// <summary>
        /// Parses the pet to floor.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParsePetToFloor(Packet packet)
        {
            var uniqueId = packet.ReadUInt();
            var sourceSlot = packet.ReadByte();

            if (Core.Game.Player.AbilityPet != null && Core.Game.Player.AbilityPet.UniqueId == uniqueId)
            {
                Core.Game.Player.AbilityPet.Inventory.RemoveItemAt(sourceSlot);
                Log.Debug($"[Pet->Floor] Remove item (slot={sourceSlot})");
            }
        }

        /// <summary>
        /// Parses the NPC to pet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseNpcToPet(Packet packet)
        {
            var uniqueId = packet.ReadUInt();

            if (Core.Game.Player.AbilityPet == null || Core.Game.Player.AbilityPet.UniqueId != uniqueId) return;
            var tabIndex = packet.ReadByte();
            var tabSlot = packet.ReadByte();
            packet.ReadByte(); //item amount ololo.. ignore for now!

            var npc = Core.Game.SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Could not determine which item was bought, since currently no entity is selected.");
                return;
            }

            var refShopGoodObj = Core.Game.ReferenceManager.GetRefPackageItem(npc.Record.CodeName, tabIndex, tabSlot);
            var item = Core.Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

            var destinationSlot = packet.ReadByte();

            var amount = packet.ReadUShort();

            Log.Notify($"Bought [{item.GetRealName()}] x{amount} from [{npc.Record.GetRealName()}]");

            Core.Game.Player.AbilityPet.Inventory.AddItem(new InventoryItem
            {
                Slot = destinationSlot,
                Amount = amount,
                ItemId = item.ID,
                Durability = (uint)refShopGoodObj.Data,
                Variance = (ulong)refShopGoodObj.Variance,
                OptLevel = refShopGoodObj.OptLevel
            });
        }

        /// <summary>
        /// Parses the pet to NPC.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParsePetToNpc(Packet packet)
        {
            var uniqueId = packet.ReadUInt();
            var sourceSlot = packet.ReadByte();
            var amount = packet.ReadUShort();
            packet.ReadUInt(); //NPC unique id
            packet.ReadByte(); //Buyback slot

            if (Core.Game.Player.AbilityPet == null || Core.Game.Player.AbilityPet.UniqueId != uniqueId) return;

            var itemAtSlot = Core.Game.Player.AbilityPet.Inventory.GetItemAt(sourceSlot);

            if (amount == itemAtSlot.Amount)
                Core.Game.Player.AbilityPet.Inventory.RemoveItemAt(sourceSlot);
            else
                Core.Game.Player.AbilityPet.Inventory.UpdateItemAmount(sourceSlot, (ushort)(itemAtSlot.Amount - amount));
        }

        /// <summary>
        /// Parses the mall to player.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseMallToPlayer(Packet packet)
        {
            var refShopGroupId = packet.ReadUShort();
            var groupIndex = packet.ReadByte();
            var tabIndex = packet.ReadByte();
            var slotIndex = packet.ReadByte();
            var itemCount = packet.ReadByte();

            var refShopGoodObj = Core.Game.ReferenceManager.GetRefPackageItemById(refShopGroupId, groupIndex, tabIndex, slotIndex);
            var itemInfo = Core.Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

            if (refShopGoodObj != null && itemInfo != null)
            {
                var itemSlots = packet.ReadByteArray(itemCount);
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
                        Variance = (ulong)refShopGoodObj.Variance,
                        OptLevel = refShopGoodObj.OptLevel
                    };

                    if(Core.Game.ClientType > GameClientType.Thailand)
                        item.Rental = RentInfo.FromPacket(packet);

                    Core.Game.Player.Inventory.AddItem(item);
                }
            }
        }

        /// <summary>
        /// Parses the other to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseOtherToInventory(Packet packet)
        {
            var uniqueId = packet.ReadUInt(); // picker uniqueId

            var destinationSlot = packet.ReadByte();
            if (destinationSlot == 0xFE)
                Core.Game.Player.Gold += packet.ReadUInt();
            else
            {
                var item = InventoryItem.FromPacket(packet, destinationSlot);
                var itemAtSlot = Core.Game.Player.Inventory.GetItemAt(destinationSlot);

                if (itemAtSlot == null)
                    Core.Game.Player.Inventory.AddItem(item);
                else
                    itemAtSlot.Amount = item.Amount;

                EventManager.FireEvent("OnPartyPickItem", item);
            }
        }

        /// <summary>
        /// Parses the guild to gold.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGuildStorageToGold(Packet packet)
        {
            Core.Game.Player.Gold += packet.ReadULong();
        }

        /// <summary>
        /// Parses the gold to guild storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGoldToGuildStorage(Packet packet)
        {
            Core.Game.Player.Gold -= packet.ReadULong();
        }

        /// <summary>
        /// Parses the buyback to inventory.
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

            Core.Game.Player.Inventory.AddItem(itemAtSource);

            Log.Debug("Buyback: " + itemAtSource.Record.GetRealName());
            var newBuybackList = new Dictionary<byte, InventoryItem>();

            foreach (var item in ShoppingManager.BuybackList)
            {
                if (item.Key == sourceSlot) continue;

                newBuybackList.Add(item.Key > sourceSlot ? (byte)(item.Key - 1) : item.Key, item.Value);
            }

            ShoppingManager.BuybackList = newBuybackList;
        }

        /// <summary>
        /// Parses <see cref="InventoryBase"/> instance to <see cref="InventoryBase"/> instance operations by their <see cref="InventoryType"/>s.
        /// </summary>
        /// <param name="srcType">The source <see cref="InventoryType"/>.</param>
        /// <param name="destType">The destination <see cref="InventoryType"/>.</param>
        /// <param name="packet">The <see cref="Packet"/>.</param>
        private void ParseInventoryTypes(InventoryType srcType, InventoryType destType, Packet packet)
        {
            var abilityPet = Core.Game.Player.AbilityPet;
            var srcInv = GetInventory(srcType, abilityPet);
            if (srcInv == null || srcInv.Size == 0)
                return;

            if ((srcType == InventoryType.Pet || destType == InventoryType.Pet) && (abilityPet == null || packet.ReadUInt() != abilityPet.UniqueId))
                return;

            if (srcType == destType)
                SameInvsOperations(srcInv, srcType.ToString(), packet);
            else
            {
                var destInv = GetInventory(destType, abilityPet);
                if (destInv == null || destInv.Size == 0)
                    return;

                DifferentInvsOperations(srcInv, destInv, srcType.ToString(), destType.ToString(), packet);
            }
        }
  
        /// <summary>
        /// Gets the <see cref="InventoryBase"/> instance by its <see cref="InventoryType"/>.
        /// </summary>
        /// <param name="type">The <see cref="InventoryType"/>.</param>
        /// <param name="abilityPet">The current summoned <see cref="AbilityPet"/>.</param>
        /// <returns>The <see cref="InventoryType"/> instance if exists; otherwise null.</returns>
        private InventoryBase GetInventory(InventoryType type, AbilityPet abilityPet)
        {
            InventoryBase result = null;
            switch (type)
            {
                case InventoryType.Inventory:
                    result = Core.Game.Player.Inventory;
                    break;
                case InventoryType.Avatars:
                    result = Core.Game.Player.Avatars;
                    break;
                case InventoryType.Pet:
                    result = abilityPet?.Inventory;
                    break;
                case InventoryType.Storage:
                    result = Core.Game.Player.Storage;
                    break;
                case InventoryType.GuildStorage:
                    result = Core.Game.Player.GuildStorage;
                    break;
            }

            return result;
        }

        /// <summary>
        /// For Operations of Same <see cref="InventoryBase"/> instances.
        /// </summary>
        /// <param name="inv">The inventory.</param>
        /// <param name="invName">The name of the inventory.</param>
        /// <param name="packet">The <see cref="Packet"/>.</param>
        private void SameInvsOperations(InventoryBase inv, string invName, Packet packet)
        {
            #region infos
            // packet
            var srcSlot = packet.ReadByte();
            var destSlot = packet.ReadByte();
            var movedAmount = packet.ReadUShort();
            // bag
            var srcItem = inv.GetItemAt(srcSlot);
            var destItem = inv.GetItemAt(destSlot);
            var srcAmount = srcItem.Amount;
            if (movedAmount == 0)
                movedAmount = srcAmount;
            var destAmount = destItem == null ? (ushort)0 : destItem.Amount;
            var srcMaxStack = srcItem.Record.MaxStack;
            #endregion infos

            #region options
            // to empty slot
            if (destItem == null)
            {
                if (srcAmount == movedAmount)
                    Move();
                else
                    Split();
            }
            // to not empty slot
            else
            {
                // different type
                if (destItem.ItemId != srcItem.ItemId)
                    SwitchDifferentType();
                // same type
                else
                {
                    if (srcAmount == srcMaxStack || destAmount == srcMaxStack)
                        SwitchSameType();
                    else
                    {
                        srcItem.Amount -= movedAmount;
                        destItem.Amount += movedAmount;

                        if (srcAmount != movedAmount)
                            MergeTwoSlots();
                        else
                            MergeIntoOneSlot();
                    }
                }
            }
            #endregion options

            #region local methods
            void Move()
            {
                srcItem.Slot = destSlot;

                Log.Debug($"[{invName}->{invName}] Move item(amount={movedAmount}) {srcItem.Record.GetRealName()} from (slot={srcSlot}, amount={srcAmount}) to (slot= {destSlot})");
            }

            void Split()
            {
                srcItem.Amount -= movedAmount;

                var newItem = srcItem.CreateClone();
                newItem.Slot = destSlot;
                newItem.Amount = movedAmount;
                inv.AddItem(newItem);

                Log.Debug($"[{invName}->{invName}] Split item(amount={movedAmount}) {srcItem.Record.GetRealName()} (slot={srcSlot}, amount={srcAmount}) to (slot={destSlot}");
            }

            void SwitchDifferentType()
            {
                destItem.Slot = srcSlot;
                srcItem.Slot = destSlot;

                Log.Debug($"[{invName}->{invName}] Switch item {srcItem.Record.GetRealName()} (slot={srcSlot}) with (slot={destSlot}) because the items are not identically.");
            }

            void SwitchSameType()
            {
                destItem.Slot = srcSlot;
                srcItem.Slot = destSlot;

                Log.Debug($"[{invName}->{invName}] Switch item {srcItem.Record.GetRealName()} (slot={srcSlot}) with (slot={destSlot}) because the max stack({srcMaxStack}) was reached.");
            }

            void MergeTwoSlots()
            {
                Log.Debug($"[{invName}->{invName}] Merge item {srcItem.Record.GetRealName()} (slot={srcSlot}, amount={srcAmount}) with (slot={destSlot}, amount={destAmount})");
            }

            void MergeIntoOneSlot()
            {
                inv.RemoveItemAt(srcSlot);

                Log.Debug($"[{invName}->{invName}] Merge item {srcItem.Record.GetRealName()} (slot={srcSlot}, amount={srcAmount}) with (slot={destSlot}, amount={destAmount}) into one (slot={destSlot})");
            }
            #endregion local methods
        }

        /// <summary>
        /// For Operations of Different <see cref="InventoryBase"/> instances.
        /// </summary>
        /// <param name="srcInv">The source <see cref="InventoryBase"/> instance.</param>
        /// <param name="destInv">The destination <see cref="InventoryBase"/> instance.</param>
        /// <param name="srcInvName">The name of the source <see cref="InventoryType"/>.</param>
        /// <param name="destInvName">The name of the destination <see cref="InventoryType"/>.</param>
        /// <param name="packet">The <see cref="Packet"/>.</param>
        private void DifferentInvsOperations(InventoryBase srcInv, InventoryBase destInv, string srcInvName, string destInvName, Packet packet)
        {
            #region infos
            // packet
            var srcSlot = packet.ReadByte();
            var destSlot = packet.ReadByte();
            // bag
            var srcItem = srcInv.GetItemAt(srcSlot);
            #endregion infos

            #region options
            // to empty slot, no more options
            Move();
            #endregion options

            #region local methods
            void Move()
            {
                srcInv.RemoveItemAt(srcSlot);
                
                srcItem.Slot = destSlot;
                destInv.AddItem(srcItem);

                Log.Debug($"[{srcInvName}->{destInvName}] Move item {srcItem.Record.GetRealName()} from {srcInvName}(slot={srcSlot}) to {destInvName}(slot={destSlot})");
            }
            #endregion local methods
        }

    }
}