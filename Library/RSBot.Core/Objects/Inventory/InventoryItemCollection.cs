using RSBot.Core.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class InventoryItemCollection : ICollection<InventoryItem>
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size">The size.</param>
        public InventoryItemCollection(Packet packet)
            : this(packet.ReadByte())
        {
            var size = packet.ReadByte();
            for (var i = 0; i < size; i++)
                _collection.Add(InventoryItem.FromPacket(packet));
        }

        /// <summary>
        /// The list of items.
        /// </summary>
        protected List<InventoryItem> _collection;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public byte Capacity
        {
            get => (byte)(_collection.Capacity - 1);
            set => _collection.Capacity = value + 1;
        }

        /// <summary>
        /// The Count of Items.
        /// </summary>
        public int Count => _collection.Count;

        /// <summary>
        /// Gets a value indicating whether this is full.
        /// </summary>
        /// <value>
        /// <c>true</c> if this is full; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Full => Count >= Capacity;

        /// <summary>
        /// Gets a value indicating whether this is readonly.
        /// </summary>
        /// <value>
        /// <c>true</c> if this is readonly; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly => false;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index">The index of the element</param>
        public InventoryItem this[int index]
        {
            get => _collection[index];
            set => _collection[index] = value;
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size">The size.</param>
        public InventoryItemCollection(byte size)
        {
            _collection = new List<InventoryItem>(size + 1);
        }

        /// <summary>
        /// Adds new item.
        /// </summary>
        /// <param name="newItem">The new item.</param>
        public void Add(InventoryItem newItem)
            => _collection.Add(newItem);

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The Inventory Item.</param>
        public bool Remove(InventoryItem item)
            => _collection.Remove(item);

        /// <summary>
        /// Removes the item at the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void RemoveAt(byte slot)
            => _collection.Remove(GetItemAt(slot));

        /// <summary>
        /// Gets the item at the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns>if found: the item at the slot; otherwise: null</returns>
        public InventoryItem GetItemAt(byte slot)
            => GetItem(item => item.Slot == slot);

        /// <summary>
        /// Determines whether [contains] the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>if contains: true; otherwise: false</returns>
        public bool Contains(InventoryItem item)
            => _collection.Contains(item);

        /// <summary>
        /// Determines whether [has item at] the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns>if has item at the slot: true; otherwise: false</returns>
        public bool Contains(byte slot)
            => GetItem(item => item.Slot == slot) != null;

        /// <summary>
        /// Updates the item slot by slot.
        /// </summary>
        /// <param name="slot">The slot of the item.</param>
        /// <param name="newSlot">The new slot.</param>
        public void UpdateItemSlot(byte slot, byte newSlot)
        {
            if (GetItemAt(slot) is InventoryItem itemToUpdate)
                itemToUpdate.Slot = newSlot;
        }

        /// <summary>
        /// Updates the item amount by slot.
        /// </summary>
        /// <param name="slot">The slot of the item.</param>
        /// <param name="newAmount">The new amount.</param>
        public void UpdateItemAmount(byte slot, ushort newAmount)
        {
            if (GetItemAt(slot) is InventoryItem itemToUpdate)
                itemToUpdate.Amount = newAmount;
        }

        /// <summary>
        /// Orders the items by slot.
        /// </summary>
        protected void OrderBySlot()
            => _collection.Sort((a, b) => a.Slot.CompareTo(b.Slot));

        /// <summary>
        /// Gets all items by predicate, oredered by slot.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>If found: list of item(s); otherwise empty list</returns>
        public IList<InventoryItem> GetItems(Predicate<InventoryItem> predicate)
        {
            OrderBySlot();
            return _collection.FindAll(predicate);
        }
        /// <summary>
        /// Gets all items by Record.ID
        /// </summary>
        /// <param name="objId">The Record.ID of item.</param>
        /// <returns>If found: list of item(s); otherwise empty list</returns>
        public ICollection<InventoryItem> GetItems(uint objId)
            => GetItems(item => item.Record.ID == objId);

        /// <summary>
        /// Gets all items by Record.CodeName of item
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>If found: list of item(s), oredered by slot; otherwise empty list</returns>
        public ICollection<InventoryItem> GetItems(string recordCodeName)
            => GetItems(item => item.Record.CodeName == recordCodeName);

        /// <summary>
        /// Gets all items by <see cref="TypeIdFilter"/>
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>If found: list of item(s); otherwise empty list</returns>
        public ICollection<InventoryItem> GetItems(TypeIdFilter filter)
            => GetItems(item => filter.EqualsRefItem(item.Record));

        /// <summary>
        /// Gets all items by <see cref="TypeIdFilter"/>
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>If found: list of item(s); otherwise empty list</returns>
        public ICollection<InventoryItem> GetItems(TypeIdFilter filter, Predicate<InventoryItem> action)
            => GetItems(item => filter.EqualsRefItem(item.Record) && action(item));

        /// <summary>
        /// Gets the item from first slot by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>if found: the item from first slot; otherwise: null</returns>
        public InventoryItem GetItem(Predicate<InventoryItem> predicate)
            => GetItems(predicate).FirstOrDefault();

        /// <summary>
        /// Gets the item from first slot by Record.ID.
        /// </summary>
        /// <param name="objId">The Record.ID of item.</param>
        /// <returns>If found: the item from first slot; otherwise null</returns>
        public InventoryItem GetItem(uint objId)
            => GetItem(item => item.Record.ID == objId);

        /// <summary>
        /// Gets the item from first slot by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>if found: the item from first slot; otherwise: null</returns>
        public InventoryItem GetItem(TypeIdFilter filter)
            => GetItem(item => filter.EqualsRefItem(item.Record));

        /// <summary>
        /// Gets all items by <see cref="TypeIdFilter"/>
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>If found: list of item(s); otherwise empty list</returns>
        public InventoryItem GetItem(TypeIdFilter filter, Predicate<InventoryItem> action)
            => GetItem(item => filter.EqualsRefItem(item.Record) && action(item));

        /// <summary>
        /// Gets the item from first slot by Record.CodeName.
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>If found: the item from first slot; otherwise null</returns>
        public InventoryItem GetItem(string recordCodeName)
            => GetItem(item => item.Record.CodeName == recordCodeName);

        /// <summary>
        /// Gets the SumAmount by Record.CodeName of item.
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>if found: the SumAmount; otherwise: 0</returns>
        public int GetSumAmount(string recordCodeName)
        {
            var sum = 0;
            foreach (var item in GetItems(recordCodeName))
                sum += item.Amount;

            return sum;
        }

        /// <summary>
        /// Gets the SumAmount by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>if found: the SumAmount; otherwise: 0</returns>
        public int GetSumAmount(TypeIdFilter filter)
        {
            var sum = 0;
            foreach (var item in GetItems(filter))
                sum += item.Amount;

            return sum;
        }

        /// <summary>
        /// Gets the best item from the first slot by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>If found: the best item from the first slot; otherwise null</returns>
        public InventoryItem GetItemBest(TypeIdFilter filter)
        {
            InventoryItem nearestItem = null;
            foreach (var item in GetItems(filter))
            {
                if (nearestItem == null)
                    nearestItem = item;
                else
                {
                    if (item.Record.ReqLevel1 > nearestItem.Record.ReqLevel1 &&
                        item.OptLevel > nearestItem.OptLevel &&
                        item.CanBeEquipped())
                        nearestItem = item;
                }
            }

            return nearestItem;
        }

        /// <summary>
        /// Gets the first free slot number.
        /// </summary>
        /// <returns>if found: the first free slot number; otherwise: 0xFF</returns>
        public virtual byte GetFreeSlot()
        {
            for (byte slot = 0; slot < Capacity; slot++)
            {
                if (GetItemAt(slot) == null)
                    return slot;
            }

            return 0xFF;
        }

        /// <summary>
        /// Copy item to the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The start index</param>
        public void CopyTo(InventoryItem[] array, int arrayIndex)
            => _collection.CopyTo(array, arrayIndex);

        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
            => _collection.Clear();

        /// <summary>
        /// Get enumerator of this collection
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<InventoryItem> GetEnumerator()
        {
            OrderBySlot();
             return _collection.GetEnumerator();
        }

        /// <summary>
        /// Get enumerator of this collection
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            OrderBySlot();
            return _collection.GetEnumerator();
        }

        /// <summary>
        /// Move via packet operation
        /// </summary>
        /// <param name="justMove">Just move the item to new slot without control others</param>
        public void Move(Packet packet, bool justMove = false)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();
            ushort amount = 0;

            if (!justMove)
                amount = packet.ReadUShort();

            var itemAtSource = GetItemAt(sourceSlot);
            var itemAtDestination = GetItemAt(destinationSlot);

            if (itemAtSource == null)
                return;

            if (justMove)
            {
                itemAtDestination.Slot = sourceSlot;
                itemAtSource.Slot = destinationSlot;
                Log.Debug($"[InventoryItemCollection::Move]  Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the items are not identically.");

                return;
            }

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

                    Add(newInventoryItem);

                    Log.Debug($"[InventoryItemCollection::Move] Split item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) to (slot={destinationSlot}, amount={amount}");
                    return;
                }

                Log.Debug($"[InventoryItemCollection::Move]  Move item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={amount}) to (slot= {destinationSlot})");
                
                itemAtSource.Slot = destinationSlot;
            }
            else
            {
                //The items will be merged!
                if (itemAtDestination.ItemId == itemAtSource.ItemId)
                {
                    //Check if the items can stack, otherwise move A to B and B to A
                    var newItemAmount = itemAtDestination.Amount + amount;
                    if (newItemAmount > itemAtDestination.Record.MaxStack)
                    {
                        itemAtDestination.Slot = sourceSlot;
                        itemAtSource.Slot = destinationSlot;

                        Log.Debug($"[InventoryItemCollection::Move]  Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the max stack was reached.");
                    }
                    else
                    {
                        itemAtDestination.Amount = (ushort)newItemAmount;
                        itemAtSource.Amount -= amount;

                        Log.Debug($"[InventoryItemCollection::Move]  Merge item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}, amount={itemAtSource.Amount}) with (slot={itemAtDestination.Slot}, amount={itemAtDestination.Amount})");
                        if (itemAtSource.Amount <= 0) RemoveAt(sourceSlot);
                    }
                }
                else
                {
                    itemAtDestination.Slot = sourceSlot;
                    itemAtSource.Slot = destinationSlot;
                    Log.Debug($"[InventoryItemCollection::Move]  Switch item {itemAtSource.Record.GetRealName()} (slot={itemAtSource.Slot}) with (slot={itemAtDestination.Slot}) because the items are not identically.");
                }
            }
        }

        public void MoveTo(InventoryItemCollection inventory, Packet packet)
        {
            var sourceSlot = packet.ReadByte();
            var destinationSlot = packet.ReadByte();

            var sourceItem = GetItemAt(sourceSlot);
            if (sourceItem == null)
                return; //Invalid?! should not happen at all.

            sourceItem.Slot = destinationSlot;
            inventory.Add(sourceItem);

            RemoveAt(sourceItem.Slot);

            Log.Debug($"[InventoryItemCollection::MoveTo] Move item {sourceItem.Record.GetRealName()} (slot={sourceSlot}) to storage (slot={destinationSlot}");
        }
    }
}
