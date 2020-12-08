namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefShopGood : IReference
    {
        #region Fields

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public byte Service;

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public int Country;

        /// <summary>
        /// Gets or sets the name of the reference tab code.
        /// </summary>
        /// <value>
        /// The name of the reference tab code.
        /// </value>
        public string RefTabCodeName;

        /// <summary>
        /// Gets or sets the name of the reference package item code.
        /// </summary>
        /// <value>
        /// The name of the reference package item code.
        /// </value>
        public string RefPackageItemCodeName;

        /// <summary>
        /// Gets or sets the index of the slot.
        /// </summary>
        /// <value>
        /// The index of the slot.
        /// </value>
        public byte SlotIndex;

        #endregion Fields

        public bool Load(ReferenceParser parser)
        {
            //Skip disabled
            if (!parser.TryParseByte(0, out Service) || Service == 0)
                return false;

            parser.TryParseInt(1, out Country);
            parser.TryParseString(2, out RefTabCodeName);
            parser.TryParseString(3, out RefPackageItemCodeName);
            parser.TryParseByte(4, out SlotIndex);

            return true;
        }
    }
}