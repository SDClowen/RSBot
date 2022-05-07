using System;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    /// <summary>
    /// Base class for Inventory handling.
    /// </summary>
    public class InventoryBase
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size">The size.</param>
        public InventoryBase(byte size)
        {
            Size = size;
            _Items = new List<InventoryItem>();
        }

        /// <summary>
        /// The list of items.
        /// </summary>
        protected List<InventoryItem> _Items;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public byte Size { get; set; }

        /// <summary>
        /// The Count of Items.
        /// </summary>
        public int ItemsCount => _Items.Count;

        /// <summary>
        /// Gets a value indicating whether this is full.
        /// </summary>
        /// <value>
        /// <c>true</c> if this is full; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Full => ItemsCount >= Size;

        /// <summary>
        /// Gets the first free slot number.
        /// </summary>
        /// <returns>if found: the first free slot number; otherwise: 0xFF</returns>
        public virtual byte GetFreeSlot()
        {
            for (byte slot = 0; slot < Size; slot++)
            {
                if (GetItemAt(slot) == null)
                    return slot;
            }

            return 0xFF;
        }

        /// <summary>
        /// Adds new item.
        /// </summary>
        /// <param name="newItem">The new item.</param>
        public void AddItem(InventoryItem newItem) => _Items.Add(newItem);

        /// <summary>
        /// Removes the item at the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public void RemoveItemAt(byte slot) => _Items.Remove(GetItemAt(slot));

        /// <summary>
        /// Gets the item at the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns>if found: the item at the slot; otherwise: null</returns>
        public InventoryItem GetItemAt(byte slot) => GetItem_ByPredicate(item => item.Slot == slot);

        /// <summary>
        /// Determines whether [has item at] the slot.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns>if has item at the slot: true; otherwise: false</returns>
        public bool HasItemAt(byte slot) => GetItem_ByPredicate(item => item.Slot == slot) != null;

        #region UpdateItem
        /// <summary>
        /// Updates the item slot by slot.
        /// </summary>
        /// <param name="slot">The slot of the item.</param>
        /// <param name="newSlot">The new slot.</param>
        public void UpdateItemSlot_BySlot(byte slot, byte newSlot)
        {
            if (GetItemAt(slot) is InventoryItem itemToUpdate)
                itemToUpdate.Slot = newSlot;
        }

        /// <summary>
        /// Updates the item amount by slot.
        /// </summary>
        /// <param name="slot">The slot of the item.</param>
        /// <param name="newAmount">The new amount.</param>
        public void UpdateItemAmount_BySlot(byte slot, ushort newAmount)
        {
            if (GetItemAt(slot) is InventoryItem itemToUpdate)
                itemToUpdate.Amount = newAmount;
        }
        #endregion UpdateItem

        /// <summary>
        /// Orders the items by slot.
        /// </summary>
        protected void OrderBySlot() => _Items.Sort((a, b) => a.Slot.CompareTo(b.Slot));

        /// <summary>
        /// Gets all items, ordered by slot.
        /// </summary>
        /// <returns></returns>
        public List<InventoryItem> GetItems()
        {
            OrderBySlot();
            return _Items;
        }

        #region by Predicate
        /// <summary>
        /// Gets the item from first slot by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>if found: the item from first slot; otherwise: null</returns>
        public InventoryItem GetItem_ByPredicate(Predicate<InventoryItem> predicate)
        {
            OrderBySlot();
            return _Items.Find(predicate);
        }

        /// <summary>
        /// Gets all items by predicate, oredered by slot.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>If found: list of item(s), oredered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetItems_ByPredicate(Predicate<InventoryItem> predicate)
        {
            OrderBySlot();
            return _Items.FindAll(predicate);
        }
        #endregion by Predicate

        #region by TypeIdFilter
        /// <summary>
        /// Gets the item from first slot by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>if found: the item from first slot; otherwise: null</returns>
        public InventoryItem GetItem_ByTypeIdFilter(TypeIdFilter filter) => GetItem_ByPredicate(item => filter.EqualsRefItem(item.Record));

        /// <summary>
        /// Gets all items by <see cref="TypeIdFilter"/>, ordered by slot..
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>If found: list of item(s), oredered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetItems_ByTypeIdFilter(TypeIdFilter filter) => GetItems_ByPredicate(item => filter.EqualsRefItem(item.Record));

        /// <summary>
        /// Gets the best item from the first slot by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>If found: the best item from the first slot; otherwise null</returns>
        public InventoryItem GetItemBest_ByTypeIdFilter(TypeIdFilter filter)
        {
            InventoryItem nearestItem = null;
            foreach (var item in GetItems_ByTypeIdFilter(filter))
            {
                if (nearestItem == null)
                    nearestItem = item;
                else
                {
                    if (item.Record.ReqLevel1 > nearestItem.Record.ReqLevel1 && item.OptLevel > nearestItem.OptLevel)
                        nearestItem = item;
                }
            }

            return nearestItem;
        }

        /// <summary>
        /// Gets the SumAmount by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>if found: the SumAmount; otherwise: 0</returns>
        public int GetSumAmount_ByTypeIdFilter(TypeIdFilter filter)
        {
            int sum = 0;
            foreach (var item in GetItems_ByTypeIdFilter(filter))
                sum += item.Amount;

            return sum;
        }
        #endregion by TypeIdFilter

        #region by Record.ID
        /// <summary>
        /// Gets the item from first slot by Record.ID.
        /// </summary>
        /// <param name="recordID">The Record.ID of item.</param>
        /// <returns>If found: the item from first slot; otherwise null</returns>
        public InventoryItem GetItem_ByRecordID(uint recordID) => GetItem_ByPredicate(item => item.Record.ID == recordID);

        /// <summary>
        /// Gets all items by Record.ID, ordered by slot.
        /// </summary>
        /// <param name="recordID">The Record.ID of item.</param>
        /// <returns>If found: list of item(s), oredered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetItems_ByRecordID(uint recordID) => GetItems_ByPredicate(item => item.Record.ID == recordID);
        #endregion by Record.ID

        #region by Record.CodeName
        /// <summary>
        /// Gets the item from first slot by Record.CodeName.
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>If found: the item from first slot; otherwise null</returns>
        public InventoryItem GetItem_ByRecordCodeName(string recordCodeName) => GetItem_ByPredicate(item => item.Record.CodeName == recordCodeName);

        /// <summary>
        /// Gets all items by Record.CodeName of item, ordered by slot.
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>If found: list of item(s), oredered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetItems_ByRecordCodeName(string recordCodeName) => GetItems_ByPredicate(item => item.Record.CodeName == recordCodeName);

        /// <summary>
        /// Gets the SumAmount by Record.CodeName of item.
        /// </summary>
        /// <param name="recordCodeName">The Record.CodeName of item.</param>
        /// <returns>if found: the SumAmount; otherwise: 0</returns>
        public int GetSumAmount_ByRecordCodeName(string recordCodeName)
        {
            int sum = 0;
            foreach (var item in GetItems_ByRecordCodeName(recordCodeName))
                sum += item.Amount;

            return sum;
        }
        #endregion by Record.CodeName
    }
}
