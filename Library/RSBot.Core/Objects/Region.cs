using System;
using System.Collections.Generic;

namespace RSBot.Core.Objects
{
    public class Region
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ushort Id { get; set; }

        /// <summary>
        /// Gets or sets the x sector.
        /// </summary>
        /// <value>
        /// The x sector.
        /// </value>
        public byte XSector => BitConverter.GetBytes(Id)[0];

        /// <summary>
        /// Gets or sets the y secotr.
        /// </summary>
        /// <value>
        /// The y secotr.
        /// </value>
        public byte YSector => BitConverter.GetBytes(Id)[1];

        /// <summary>
        /// Initializes a new instance of the <see cref="Region" /> class.
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        public Region(ushort regionId)
        {
            Id = regionId;
        }

        /// <summary>
        /// Froms the sectors.
        /// </summary>
        /// <param name="xSector">The x sector.</param>
        /// <param name="ySector">The y sector.</param>
        /// <returns></returns>
        public static Region FromSectors(byte xSector, byte ySector)
        {
            var buffer = new[] { xSector, ySector };
            return new Region(BitConverter.ToUInt16(buffer, 0));
        }

        /// <summary>
        /// Gets the surroundings.
        /// </summary>
        /// <returns></returns>
        public static List<Region> GetSurroundingRegions(byte xSector, byte ySector)
        {
            var result = new List<Region>
            {
                FromSectors((byte) (xSector - 1), (byte) (ySector + 1)), //TL
                FromSectors(xSector, (byte) (ySector + 1)), //TC
                FromSectors((byte) (xSector + 1), (byte) (ySector + 1)), //TR
                FromSectors((byte) (xSector - 1), ySector), //CL
                FromSectors(xSector, ySector), //CC
                FromSectors((byte) (xSector + 1), ySector), //CR
                FromSectors((byte) (xSector - 1), (byte) (ySector - 1)), //BL
                FromSectors(xSector, (byte) (ySector - 1)), //BC
                FromSectors((byte) (xSector + 1), (byte) (ySector - 1)) //BR
            };

            return result;
        }
    }
}