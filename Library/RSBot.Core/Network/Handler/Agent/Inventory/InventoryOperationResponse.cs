using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using RSBot.Core.Objects.Spawn;
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
                Log.Debug($"ItemOperation error received:  [{result.ToString("X")}] ({packet.ReadUShort().ToString("X")})");
                return;
            }

            var type = packet.ReadByte();

            switch (type)
            {
                case 0:
                    ParseInventoryToInventory(packet);
                    //e.g when equipping a Bow (see ammo)
                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x00)
                            ParseInventoryToInventory(packet);
                    break;

                case 1:
                    ParseStorageToStorage(packet);
                    break;

                case 2:
                    ParseInventoryToStorage(packet);
                    break;

                case 3:
                    ParseStorageToInventory(packet);
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

                case 16:
                    ParsePetToPet(packet);
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

                case 26:
                    ParsePetToInventory(packet);
                    break;

                case 27:
                    ParseInventoryToPet(packet);
                    break;

                case 28:
                    ParseOtherToInventory(packet);
                    break;

                case 29:
                    ParseGuildStorageToGuildStorage(packet);
                    break;

                case 30:
                    ParseInventoryToGuildStorage(packet);
                    break;

                case 31:
                    ParseGuildStorageToInventory(packet);
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

                case 35:
                    ParseAvatarToInventory(packet);

                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x23)
                            ParseAvatarToInventory(packet);
                    break;

                case 36:
                    ParseInventoryToAvatar(packet);

                    if (packet.ReadBool())
                        if (packet.ReadByte() == 0x00)
                            ParseInventoryToAvatar(packet);
                    break;
            }

            EventManager.FireEvent("OnInventoryUpdate");
        }

        /// <summary>
        /// Parses the inventory to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToInventory(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();
            var amount = packet.ReadUShort();

            var itemAtSource = Core.Game.Player.Inventory.GetItemAt(sourceSlot);
            var itemAtDestination = Core.Game.Player.Inventory.GetItemAt(destinationSlot);

            if (itemAtSource == null) return;

            //Move the item from A -> B
            if (itemAtDestination == null)
            {
                //Split item
                if (itemAtSource.Amount != amount && amount != 0)
                {
                    itemAtSource.Amount -= amount;

                    //The item has been split in two parts.
                    //Copy the item with the given amount to the new slot
                    var newInventoryItem = new InventoryItem
                    {
                        //Copy the item infos from the source item. Some may be useless because only ETC items can be split but anyway, just to make sure assign everything
                        Amount = amount,
                        Slot = destinationSlot,
                        Durability = itemAtSource.Durability,
                        ItemId = itemAtSource.ItemId,
                        MagicOptions = itemAtSource.MagicOptions,
                        OptLevel = itemAtSource.OptLevel,
                        BindingOptions = itemAtSource.BindingOptions,
                        Rental = itemAtSource.Rental,
                        Variance = itemAtSource.Variance
                    };

                    Core.Game.Player.Inventory.Items.Add(newInventoryItem);

                    Log.Debug($"[Inventory->Inventory] Split item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) to (slot={destinationSlot}, amount={amount}");
                    return;
                }

                Log.Debug($"[Inventory->Inventory] Move item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={amount}) to (slot= {destinationSlot})");
                Core.Game.Player.Inventory.UpdateItemSlot(sourceSlot, destinationSlot);
            }
            else
            {
                //The items will be merged!
                if (itemAtDestination.ItemId == itemAtSource.ItemId)
                {
                    //Check if the items can stack, otherwise move A to B and B to A
                    var newItemAmount = itemAtDestination.Amount + itemAtSource.Amount;
                    if (newItemAmount > itemAtDestination.Record.MaxStack)
                    {
                        itemAtDestination.Slot = sourceSlot;
                        itemAtSource.Slot = destinationSlot;

                        Log.Debug($"[Inventory->Inventory] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the max stack was reached.");
                    }
                    else
                    {
                        itemAtDestination.Amount = (ushort)newItemAmount;

                        Log.Debug($"[Inventory->Inventory] Merge item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) with (slot={itemAtDestination.Slot}, amount={itemAtDestination.Amount})");
                        Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);
                    }
                }
                else
                {
                    itemAtDestination.Slot = sourceSlot;
                    itemAtSource.Slot = destinationSlot;
                    Log.Debug($"[Inventory->Inventory] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the items are not identically.");
                }
            }
        }

        /// <summary>
        /// Parses the storage to storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseStorageToStorage(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();
            var amount = packet.ReadUShort();

            var itemAtSource = Core.Game.Player.Storage.GetItemAt(sourceSlot);
            var itemAtDestination = Core.Game.Player.Storage.GetItemAt(destinationSlot);

            if (itemAtSource == null) return;

            //Move the item from A -> B
            if (itemAtDestination == null)
            {
                //Split item
                if (itemAtSource.Amount != amount && amount != 0)
                {
                    itemAtSource.Amount -= amount;

                    //The item has been split in two parts.
                    //Copy the item with the given amount to the new slot
                    var newInventoryItem = new InventoryItem
                    {
                        //Copy the item infos from the source item. Some may be useless because only ETC items can be split but anyway, just to make sure assign everything
                        Amount = amount,
                        Slot = destinationSlot,
                        Durability = itemAtSource.Durability,
                        ItemId = itemAtSource.ItemId,
                        MagicOptions = itemAtSource.MagicOptions,
                        OptLevel = itemAtSource.OptLevel,
                        BindingOptions = itemAtSource.BindingOptions,
                        Rental = itemAtSource.Rental,
                        Variance = itemAtSource.Variance
                    };

                    Core.Game.Player.Storage.Items.Add(newInventoryItem);

                    Log.Debug($"[Storage->Storage] Split item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) to (slot={destinationSlot}, amount={amount}");
                    return;
                }

                Log.Debug($"[Storage->Storage] Move item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={amount}) to (slot= {destinationSlot})");
                Core.Game.Player.Storage.UpdateItemSlot(sourceSlot, destinationSlot);
            }
            else
            {
                //The items will be merged!
                if (itemAtDestination.ItemId == itemAtSource.ItemId)
                {
                    //Check if the items can stack, otherwise move A to B and B to A
                    var newItemAmount = itemAtDestination.Amount + itemAtSource.Amount;
                    if (newItemAmount > itemAtDestination.Record.MaxStack)
                    {
                        itemAtDestination.Slot = sourceSlot;
                        itemAtSource.Slot = destinationSlot;

                        Log.Debug($"[Storage->Storage] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the max stack was reached.");
                    }
                    else
                    {
                        itemAtDestination.Amount = (ushort)newItemAmount;

                        Log.Debug($"[Storage->Storage] Merge item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) with (slot={itemAtDestination.Slot}, amount={itemAtDestination.Amount})");
                        Core.Game.Player.Storage.RemoveItemAt(sourceSlot);
                    }
                }
                else
                {
                    itemAtDestination.Slot = sourceSlot;
                    itemAtSource.Slot = destinationSlot;

                    Log.Debug($"[Storage->Storage] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the items are not identically.");
                }
            }
        }

        /// <summary>
        /// Parses the inventory to storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToStorage(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var sourceItem = Core.Game.Player.Inventory.GetItemAt(sourceSlot);
            if (sourceItem == null) return; //Invalid?! should not happen at all.

            sourceItem.Slot = destinationSlot;
            Core.Game.Player.Storage.Items.Add(sourceItem);

            Core.Game.Player.Inventory.RemoveItemAt(sourceItem.Slot);

            Log.Debug($"[Inventory->Storage] Move item {sourceItem.Record.GetRealName()} (slot={sourceSlot}) to storage (slot={destinationSlot}");
        }

        /// <summary>
        /// Parses the storage to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseStorageToInventory(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var sourceItem = Core.Game.Player.Storage.GetItemAt(sourceSlot);
            if (sourceItem == null) return; //Invalid?! should not happen at all.

            Core.Game.Player.Storage.RemoveItemAt(sourceItem.Slot);

            sourceItem.Slot = destinationSlot;
            Core.Game.Player.Inventory.Items.Add(sourceItem);

            Log.Debug($"[Storage->Inventory] Move item {sourceItem.Record.GetRealName()} (slot={sourceSlot}, amount={sourceItem.Amount}) to inventory (slot={destinationSlot})");
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

            var item = GetItemFromPacket(packet, destinationSlot);
            var itemAtSlot = Core.Game.Player.Inventory.GetItemAt(item.Slot);

            if (itemAtSlot != null)
            {
                itemAtSlot.Amount = item.Amount;

                Log.Debug(
                    $"[Floor->Inventory] Merge item {itemAtSlot.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount})");
            }
            else
            {
                Core.Game.Player.Inventory.Items.Add(item);

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
            var tabIndex = packet.ReadByte();
            var tabSlot = packet.ReadByte();
            var itemAmount = packet.ReadByte(); //item amount ololo.. ignore for now!

            var destintationSlots = packet.ReadByteArray(itemAmount);

            var amount = packet.ReadUShort();
            var npc = Core.Game.SelectedEntity == null ? Core.Game.LastSelectedEntity : Core.Game.SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Could not determine which item was bought, since currently no entity is selected.");
                return;
            }

            if (!(npc.Entity is SpawnedBionic bionic))
                return;
            
            var refShopGoodObj = Core.Game.ReferenceManager.GetRefPackageItem(bionic.Record.CodeName, tabIndex, tabSlot);
            var item = Core.Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

            Log.Notify($"Bought [{item.GetRealName(true)}] x {amount} from [{bionic.Record.GetRealName()}]");

            //_ETC_
            if (itemAmount != destintationSlots.Length)
            {
                Core.Game.Player.Inventory.Items.Add(new InventoryItem
                {
                    Slot = destintationSlots[0],
                    Amount = amount,
                    ItemId = item.ID,
                    Durability = (uint)refShopGoodObj.Data,
                    Variance = (ulong)refShopGoodObj.Variance,
                    OptLevel = refShopGoodObj.OptLevel
                });

                EventManager.FireEvent("OnBuyItem", destintationSlots[0]);
            }
            else
            {
                foreach (var slot in destintationSlots)
                {
                    Core.Game.Player.Inventory.Items.Add(new InventoryItem
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

            Core.Game.Player.Inventory.Items.Add(GetItemFromPacket(packet, destinationSlot));
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
        /// Parses the pet to pet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParsePetToPet(Packet packet)
        {
            var petUniqueId = packet.ReadUInt();
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();
            var amount = packet.ReadUShort();

            if (!Core.Game.Player.HasActiveAbilityPet || Core.Game.Player.AbilityPet.UniqueId != petUniqueId) return;

            var itemAtSource = Core.Game.Player.AbilityPet.GetItemAt(sourceSlot);
            var itemAtDestination = Core.Game.Player.AbilityPet.GetItemAt(destinationSlot);

            if (itemAtSource == null) return;

            //Move the item from A -> B
            if (itemAtDestination == null)
            {
                //Split item
                if (itemAtSource.Amount != amount && amount != 0)
                {
                    itemAtSource.Amount -= amount;

                    //The item has been split in two parts.
                    //Copy the item with the given amount to the new slot
                    var newInventoryItem = new InventoryItem
                    {
                        //Copy the item infos from the source item. Some may be useless because only ETC items can be split but anyway, just to make sure assign everything
                        Amount = amount,
                        Slot = destinationSlot,
                        Durability = itemAtSource.Durability,
                        ItemId = itemAtSource.ItemId,
                        MagicOptions = itemAtSource.MagicOptions,
                        OptLevel = itemAtSource.OptLevel,
                        BindingOptions = itemAtSource.BindingOptions,
                        Rental = itemAtSource.Rental,
                        Variance = itemAtSource.Variance
                    };

                    Core.Game.Player.AbilityPet.Items.Add(newInventoryItem);
                    Log.Debug($"[Pet->Pet] Split item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) to (slot={destinationSlot}, amount={amount}");
                    return;
                }

                Log.Debug($"[Pet->Pet] Move item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={amount}) to (slot= {destinationSlot})");
                Core.Game.Player.AbilityPet.UpdateItemSlot(sourceSlot, destinationSlot);
            }
            else
            {
                //The items will be merged!
                if (itemAtDestination.ItemId == itemAtSource.ItemId)
                {
                    //Check if the items can stack, otherwise move A to B and B to A
                    var newItemAmount = itemAtDestination.Amount + itemAtSource.Amount;
                    if (newItemAmount > itemAtDestination.Record.MaxStack)
                    {
                        itemAtDestination.Slot = sourceSlot;
                        itemAtSource.Slot = destinationSlot;
                        Log.Debug($"[Pet->Pet] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the max stack was reached.");
                    }
                    else
                    {
                        itemAtDestination.Amount = (ushort)newItemAmount;

                        Core.Game.Player.AbilityPet.RemoveItemAt(sourceSlot);
                        Log.Debug($"[Pet->Pet] Merge item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) with (slot={itemAtDestination.Slot}, amount={itemAtDestination.Amount})");
                    }
                }
                else
                {
                    itemAtDestination.Slot = sourceSlot;
                    itemAtSource.Slot = destinationSlot;

                    Log.Debug($"[Pet->Pet] Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the items are not identically.");
                }
            }
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

            var item = GetItemFromPacket(packet, destinationSlot, true);
            var itemAtSlot = Core.Game.Player.AbilityPet.GetItemAt(item.Slot);

            if (itemAtSlot != null)
            {
                itemAtSlot.Amount = item.Amount;

                Log.Debug($"[Floor->Pet] Merge item {itemAtSlot.Record.GetRealName()} (slot={destinationSlot}, amount={item.Amount})");
            }
            else
            {
                Core.Game.Player.AbilityPet.Items.Add(item);
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
                Core.Game.Player.AbilityPet.RemoveItemAt(sourceSlot);
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

            var npc = Core.Game.SelectedEntity == null ? Core.Game.LastSelectedEntity : Core.Game.SelectedEntity;
            if (npc == null)
            {
                Log.Debug("Could not determine which item was bought, since currently no entity is selected.");
                return;
            }

            if (!(npc.Entity is SpawnedBionic bionic))
                return;

            var refShopGoodObj = Core.Game.ReferenceManager.GetRefPackageItem(bionic.Record.CodeName, tabIndex, tabSlot);
            var item = Core.Game.ReferenceManager.GetRefItem(refShopGoodObj.RefItemCodeName);

            var destinationSlot = packet.ReadByte();

            var amount = packet.ReadUShort();

            Log.Notify($"Bought [{item.GetRealName()}] x{amount} from [{bionic.Record.GetRealName()}]");

            Core.Game.Player.AbilityPet.Items.Add(new InventoryItem
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

            var itemAtSlot = Core.Game.Player.AbilityPet.GetItemAt(sourceSlot);

            if (amount == itemAtSlot.Amount)
                Core.Game.Player.AbilityPet.RemoveItemAt(sourceSlot);
            else
                Core.Game.Player.AbilityPet.UpdateItemAmount(sourceSlot, (ushort)(itemAtSlot.Amount - amount));
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
                    Core.Game.Player.Inventory.Items.Add(new InventoryItem
                    {
                        Slot = slot,
                        Amount = (ushort)amount,
                        ItemId = itemInfo.ID,
                        Durability = (uint)refShopGoodObj.Data,
                        Variance = (ulong)refShopGoodObj.Variance,
                        OptLevel = refShopGoodObj.OptLevel,
                        Rental = RentInfo.FromPacket(packet)
                    });
                }
            }
        }

        /// <summary>
        /// Parses the pet to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParsePetToInventory(Packet packet)
        {
            var petUniqueId = packet.ReadUInt();

            if (!Core.Game.Player.HasActiveAbilityPet || Core.Game.Player.AbilityPet.UniqueId != petUniqueId) return;

            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var newItem = Core.Game.Player.AbilityPet.GetItemAt(sourceSlot);

            if (newItem == null) return;

            Core.Game.Player.Inventory.Items.Add(newItem);
            Core.Game.Player.AbilityPet.RemoveItemAt(sourceSlot);
            newItem.Slot = destinationSlot;
        }

        /// <summary>
        /// Parses the inventory to pet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToPet(Packet packet)
        {
            var petUniqueId = packet.ReadUInt();

            if (!Core.Game.Player.HasActiveAbilityPet || Core.Game.Player.AbilityPet.UniqueId != petUniqueId) return;

            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var newItem = Core.Game.Player.Inventory.GetItemAt(sourceSlot);

            Core.Game.Player.AbilityPet.Items.Add(newItem);
            Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);

            newItem.Slot = destinationSlot;
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
                var item = GetItemFromPacket(packet, destinationSlot);
                var itemAtSlot = Core.Game.Player.Inventory.GetItemAt(destinationSlot);

                if (itemAtSlot == null)
                    Core.Game.Player.Inventory.Items.Add(item);
                else
                    itemAtSlot.Amount = item.Amount;

                EventManager.FireEvent("OnPartyPickItem", item);
            }
        }

        /// <summary>
        /// Parses the guild storage to guild storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGuildStorageToGuildStorage(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();
            var amount = packet.ReadUShort();

            var itemAtSource = Core.Game.Player.GuildStorage.GetItemAt(sourceSlot);
            var itemAtDestination = Core.Game.Player.GuildStorage.GetItemAt(destinationSlot);

            if (itemAtSource == null) return;

            //Move the item from A -> B
            if (itemAtDestination == null)
            {
                //Split item
                if (itemAtSource.Amount != amount && amount != 0)
                {
                    itemAtSource.Amount -= amount;

                    //The item has been split in two parts.
                    //Copy the item with the given amount to the new slot
                    var newInventoryItem = new InventoryItem
                    {
                        //Copy the item infos from the source item. Some may be useless because only ETC items can be split but anyway, just to make sure assign everything
                        Amount = amount,
                        Slot = destinationSlot,
                        Durability = itemAtSource.Durability,
                        ItemId = itemAtSource.ItemId,
                        MagicOptions = itemAtSource.MagicOptions,
                        OptLevel = itemAtSource.OptLevel,
                        BindingOptions = itemAtSource.BindingOptions,
                        Rental = itemAtSource.Rental,
                        Variance = itemAtSource.Variance
                    };

                    Core.Game.Player.GuildStorage.Items.Add(newInventoryItem);
                    return;
                }

                Core.Game.Player.GuildStorage.UpdateItemSlot(sourceSlot, destinationSlot);
            }
            else
            {
                //The items will be merged!
                if (itemAtDestination.ItemId == itemAtSource.ItemId)
                {
                    //Check if the items can stack, otherwise move A to B and B to A
                    var newItemAmount = itemAtDestination.Amount + itemAtSource.Amount;
                    if (newItemAmount > itemAtDestination.Record.MaxStack)
                    {
                        itemAtDestination.Slot = sourceSlot;
                        itemAtSource.Slot = destinationSlot;
                    }
                    else
                    {
                        itemAtDestination.Amount = (ushort)newItemAmount;

                        Core.Game.Player.GuildStorage.RemoveItemAt(sourceSlot);
                    }
                }
                else
                {
                    itemAtDestination.Slot = sourceSlot;
                    itemAtSource.Slot = destinationSlot;
                }
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
        /// Parses the guild to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseGuildStorageToInventory(Packet packet)
        {
            if (Core.Game.Player.GuildStorage == null) return;

            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var sourceItem = Core.Game.Player.GuildStorage.GetItemAt(sourceSlot);
            if (sourceItem == null) return; //Invalid?! should not happen at all.

            Core.Game.Player.GuildStorage.RemoveItemAt(sourceItem.Slot);

            sourceItem.Slot = destinationSlot;
            Core.Game.Player.Inventory.Items.Add(sourceItem);
        }

        /// <summary>
        /// Parses the inventory to guild storage.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToGuildStorage(Packet packet)
        {
            if (Core.Game.Player.GuildStorage == null) return;

            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var sourceItem = Core.Game.Player.Inventory.GetItemAt(sourceSlot);
            if (sourceItem == null) return; //Invalid?! should not happen at all.

            Core.Game.Player.Inventory.RemoveItemAt(sourceItem.Slot);

            sourceItem.Slot = destinationSlot;
            Core.Game.Player.GuildStorage.Items.Add(sourceItem);
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

            Core.Game.Player.Inventory.Items.Add(itemAtSource);

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
        /// Parses the inventory to avatar.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseInventoryToAvatar(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var newItem = Core.Game.Player.Inventory.GetItemAt(sourceSlot);

            Core.Game.Player.Inventory.Avatars.Add(newItem);
            Core.Game.Player.Inventory.RemoveItemAt(sourceSlot);

            newItem.Slot = destinationSlot;
        }

        /// <summary>
        /// Parses the avatar to inventory.
        /// </summary>
        /// <param name="packet">The packet.</param>
        private static void ParseAvatarToInventory(Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var newItem = Core.Game.Player.Inventory.GetAvatarItemAt(sourceSlot);

            Core.Game.Player.Inventory.Items.Add(newItem);
            Core.Game.Player.Inventory.RemoveAvatarItemAt(sourceSlot);

            newItem.Slot = destinationSlot;
        }

        /// <summary>
        /// Gets the item from packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <param name="destinationSlot">The destination slot.</param>
        /// <param name="hasDestinationSlot">if set to <c>true</c> [has destination slot].</param>
        /// <returns></returns>
        private static InventoryItem GetItemFromPacket(Packet packet, byte destinationSlot, bool hasDestinationSlot = false)
        {
            return InventoryItem.FromPacket(packet, destinationSlot, hasDestinationSlot);
        }
    }
}