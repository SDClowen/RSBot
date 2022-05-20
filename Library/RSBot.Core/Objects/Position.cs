using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects
{
    public struct Position
    {
        /// <summary>
        /// Gets the region identifier.
        /// </summary>
        public ushort RegionID => BitConverter.ToUInt16(new[] { XSector, YSector }, 0);

        /// <summary>
        /// Gets or set the regional X sector.
        /// </summary>
        private byte _XSector;

        public byte XSector
        {
            get => !IsInDungeon ? ((WorldXOffset == 0) ? _XSector : (byte)(WorldXOffset / 1920)) : _XSector;
            set
            {
                _XSector = value;
            }
        }

        /// <summary>
        /// Gets or set the regional Y sector.
        /// </summary>
        private byte _YSector;

        public byte YSector
        {
            get => !IsInDungeon ? ((WorldYOffset == 0) ? _YSector : (byte)(WorldYOffset / 1920)) : _YSector;
            set
            {
                _YSector = value;
            }
        }

        /// <summary>
        /// Gets or set the regional XOffset
        /// </summary>
        public float WorldXOffset;

        /// <summary>
        /// Gets or set the regional YOffset
        /// </summary>
        public float WorldYOffset;

        /// <summary>
        /// Gets or sets the x offset.
        /// </summary>
        public float XOffset
        {
            get => IsInDungeon ? XOffsetFromX(XCoordinate) : WorldXOffset % 1920;
            set
            {
                WorldXOffset = _XSector * 1920 + value;
            }
        }

        /// <summary>
        /// Gets or sets the z offset.
        /// </summary>
        public float ZOffset;

        /// <summary>
        /// Gets or sets the y offset.
        /// </summary>
        public float YOffset
        {
            get => IsInDungeon ? YOffsetFromY(YCoordinate) : WorldYOffset % 1920;
            set
            {
                WorldYOffset = _YSector * 1920 + value;
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        public short Angle;

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <value>
        /// The x coordinate.
        /// </value>
        public float XCoordinate
        {
            get => (WorldXOffset - (135 * 1920)) / 10;
            set
            {
                XSector = XSectorFromX(value);
                XOffset = XOffsetFromX(value);
            }
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <value>
        /// The y coordinate.
        /// </value>
        public float YCoordinate
        {
            get => (WorldYOffset - (92 * 1920)) / 10;
            set
            {
                YSector = YSectorFromY(value);
                YOffset = YOffsetFromY(value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is in dungeon.
        /// </summary>
        /// <value><c>true</c> if this instance is in dungeon; otherwise, <c>false</c>.</value>
        public bool IsInDungeon => _YSector == 0x80;
        
        #region Helper

        /// <summary>
        /// Reads all requierd data from the packet and returns a new Postion object.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Position FromPacket(Packet packet)
        {
            return new Position
            {
                XSector = packet.ReadByte(),
                YSector = packet.ReadByte(),
                XOffset = packet.ReadFloat(),
                ZOffset = packet.ReadFloat(),
                YOffset = packet.ReadFloat(),
                Angle = packet.ReadShort()
            };
        }


        /// <summary>
        /// Reads all requierd data from the packet and returns a new Postion object.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Position FromPacketInt(Packet packet)
        {
            return new Position
            {
                XSector = packet.ReadByte(),
                YSector = packet.ReadByte(),
                XOffset = packet.ReadInt(),
                ZOffset = packet.ReadInt(),
                YOffset = packet.ReadInt()
            };
        }

        public static Position FromOffsets(float xOffset, float yOffset, float zOffset, byte xSector, byte ySector)
        {
            return new Position
            {
                XSector = xSector,
                YSector = ySector,
                XOffset = xOffset,
                ZOffset = zOffset,
                YOffset = yOffset,
                Angle = 0
            };
        }
        public static Position FromOffsets(float xOffset, float yOffset, float zOffset, ushort regionId)
        {
            var xSec = GetXSector(regionId);
            var ySec = GetYSector(regionId);

            return FromOffsets(xOffset, yOffset, zOffset, xSec, ySec);
        }

        /// <summary>
        /// Calculates the distance to the destination
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public double DistanceTo(Position position)
        {
            return Math.Sqrt(Math.Pow(XCoordinate - position.XCoordinate, 2) + Math.Pow(YCoordinate - position.YCoordinate, 2));
        }

        public double DistanceToPlayer()
        {
            return DistanceTo(Game.Player.Movement.Source);
        }

        public byte XSectorFromX(float x)
        {
            if (IsInDungeon)
                return XSector;

            return (byte)((x / 192.0) + 135.0);
        }

        public byte YSectorFromY(float y)
        {
            if (IsInDungeon)
                return YSector;

            return (byte)((y / 192.0) + 92);
        }

        public float XOffsetFromX(float x)
        {
            return (float)((x / 192.0 - XSectorFromX(x) + 135.0) * 192.0 * 10.0);
        }

        public float YOffsetFromY(float y)
        {
            return (float)((y / 192.0 - YSectorFromY(y) + 92.0) * 192.0 * 10.0);
        }

        public static byte GetXSector(ushort regionId)
        {
            return BitConverter.GetBytes(regionId)[0];
        }

        public static byte GetYSector(ushort regionId)
        {
            return BitConverter.GetBytes(regionId)[1];
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"X:{XCoordinate:0.0} Y:{YCoordinate:0.0}";
        }

        #endregion Helper
    }
}