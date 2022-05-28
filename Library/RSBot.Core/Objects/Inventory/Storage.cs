namespace RSBot.Core.Objects.Inventory
{
    public class Storage : InventoryItemCollection
    {
        /// <summary>
        /// The gold amount in the storage
        /// </summary>
        public ulong Gold;

        /// <summary>
        /// Create instance of the <seealso cref="Storage"/>
        /// </summary>
        /// <param name="size">The standart 150(5 page)</param>
        public Storage(byte size = 150)
            : base(size) { }
    }
}
