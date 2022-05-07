using RSBot.Core.Network;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    /// <summary>
    /// The Character's Invetory with EquippedPart and NormalPart.
    /// </summary>
    public class CharacterInventory : InventoryBase
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size">The size.</param>
        public CharacterInventory(byte size) : base(size)
        {
        }

        /// <summary>
        /// Minimum slot of NormalPart.
        /// </summary>
        public const byte NORMAL_PART_MIN_SLOT = 13;

        /// <summary>
        /// Gets the size of NormalPart.
        /// </summary>
        public byte NormalPartSize => (byte)(Size - NORMAL_PART_MIN_SLOT);

        /// <summary>
        /// Gets a value indicating whether the NormalPart is full.
        /// </summary>
        /// <value>
        /// <c>true</c> if the NormalPart is full; otherwise, <c>false</c>.
        /// </value>
        public override bool Full => GetNormalPartItems().Count >= NormalPartSize;

        /// <summary>
        /// Gets the first free slot number inside NormalPart.
        /// </summary>
        /// <returns>if found: the first free slot number; otherwise: 0</returns>
        public override byte GetFreeSlot()
        {
            for (byte slot = NORMAL_PART_MIN_SLOT; slot < Size; slot++)
            {
                if (GetItemAt(slot) == null)
                    return slot;
            }

            return 0;
        }

        /// <summary>
        /// Gets items of EquippedPart, ordered by slot.
        /// </summary>
        /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetEquippedPartItems() => GetItems_ByPredicate(item => item.Slot < NORMAL_PART_MIN_SLOT);

        /// <summary>
        /// Gets items of NormalPart, ordered by slot.
        /// </summary>
        /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetNormalPartItems() => GetItems_ByPredicate(item => item.Slot >= NORMAL_PART_MIN_SLOT);

        /// <summary>
        /// Gets items of NormalPart by ItemId, ordered by slot.
        /// </summary>
        /// <param name="itemId">The identifier of item.</param>
        /// <returns>If found: list of item(s), ordered by slot; otherwise empty list</returns>
        public List<InventoryItem> GetNormalPartItems_ByItemId(uint itemId) => GetItems_ByPredicate(item => item.Slot >= NORMAL_PART_MIN_SLOT && item.ItemId == itemId);

        /// <summary>
        /// Gets item from first slot by <see cref="TypeIdFilter"/>.
        /// </summary>
        /// <param name="filter">The <see cref="TypeIdFilter"/>.</param>
        /// <returns>if found: the first slot number; otherwise: 0</returns>
        public byte GetFirstSlot_ByTypeIdFilter(TypeIdFilter filter) => GetItem_ByTypeIdFilter(filter) is InventoryItem item ? item.Slot : (byte)0x00;

        /// <summary>
        /// Moves the item inside Character's Inventory.
        /// </summary>
        /// <param name="sourceSlot">The source slot.</param>
        /// <param name="destinationSlot">The destination slot.</param>
        /// <param name="amount">The amount.</param>
        /// <returns><c>true</c> if successfully moved; otherwise, <c>false</c>.</returns>
        public bool MoveItem(byte sourceSlot, byte destinationSlot, ushort? amount = null)
        {
            var itemAtSource = GetItemAt(sourceSlot);

            if (itemAtSource == null) return false;

            if (amount == null)
                amount = 0;
            if (amount == 0)
                amount = itemAtSource.Amount;

            var packet = new Packet(0x7034);
            packet.WriteByte(0); //kinda flag
            packet.WriteByte(sourceSlot);
            packet.WriteByte(destinationSlot);
            packet.WriteUShort(amount);

            var asyncResult = new AwaitCallback(response =>
            {
                var result = response.ReadByte();
                if (result == 0x01)
                {
                    var operation = response.ReadByte();
                    if (operation != 0)
                        return AwaitCallbackResult.ConditionFailed;

                    var source = response.ReadByte();
                    var destination = response.ReadByte();
                    if (source == sourceSlot && destination == destinationSlot)
                        return AwaitCallbackResult.Successed;
                }

                return AwaitCallbackResult.Failed;
            }, 0xB034);

            PacketManager.SendPacket(packet, PacketDestination.Server, asyncResult);
            asyncResult.AwaitResponse(500);

            return asyncResult.IsCompleted;
        }
    }
}
