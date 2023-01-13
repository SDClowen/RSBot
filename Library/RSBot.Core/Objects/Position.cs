using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects
{
    public struct Position
    {
        private float _XOffset;
        private float _YOffset;

        /// <summary>
        /// Gets the regional id.
        /// </summary>
        public Region Region;

        /// <summary>
        /// Gets or set the position X from map
        /// </summary>
        public float XOffset
        {
            get => _XOffset;
            set
            {
                _XOffset = value;

                if (Region.IsDungeon)
                    return;

                while (_XOffset < 0)
                {
                    _XOffset += 1920;
                    Region.X -= 1;
                }

                while (_XOffset > 1920)
                {
                    _XOffset -= 1920;
                    Region.X += 1;
                }
            }
        }
        /// <summary>
        /// Gets or set the position Y from map.
        /// </summary>
        public float YOffset
        {
            get => _YOffset;
            set
            {
                _YOffset = value;

                if (Region.IsDungeon)
                    return;

                while (_YOffset < 0)
                {
                    _YOffset += 1920;
                    Region.Y -= 1;
                }

                while (_YOffset > 1920)
                {
                    _YOffset -= 1920;
                    Region.Y += 1;
                }
            }
        }

        /// <summary>
        /// Gets or set the position Z from map.
        /// </summary>
        public float ZOffset { get; set; }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        public short Angle { get; set; }

        /// <summary>
        /// Gets or sets the world id.
        /// </summary>
        public short WorldId { get; set; }

        /// <summary>
        /// Gets or sets the layer id.
        /// </summary>
        public short LayerId { get; set; }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <value>
        /// The x coordinate.
        /// </value>
        public float X => Region.IsDungeon ? _XOffset / 10 : (Region.X - 135) * 192 + _XOffset / 10;

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <value>
        /// The y coordinate.
        /// </value>
        public float Y => Region.IsDungeon ? _YOffset / 10 : (Region.Y - 92) * 192 + _YOffset / 10;

        /// <summary>
        /// Gets offset from x sector.
        /// </summary>
        public float XSectorOffset => Region.IsDungeon ? (127 * 192 + _XOffset / 10) * 10 % 1920 : _XOffset;

        /// <summary>
        /// Gets offset from y sector.
        /// </summary>
        public float YSectorOffset => Region.IsDungeon ? (128 * 192 + _YOffset / 10) * 10 % 1920 : _YOffset;

        /// <summary>
        /// Creates a position by using world map coordinates
        /// </summary>
        /// <param name="regionId">Region Id required for dungeon maps</param>
        public Position(float x, float y, ushort regionId = 0)
            : this()
        {
            Region = regionId;

            // World map coordinates has been provided
            if (!Region.IsDungeon)
            {
                var xOffset = (int)(Math.Abs(x) % 192 * 10);
                if (x < 0)
                    xOffset = 1920 - xOffset;

                var yOffset = (int)(Math.Abs(y) % 192 * 10);
                if (y < 0)
                    yOffset = 1920 - yOffset;

                Region.X = (byte)Math.Round((x - xOffset / 10f) / 192f + 135);
                Region.Y = (byte)Math.Round((y - yOffset / 10f) / 192f + 92);

                XOffset = xOffset;
                YOffset = yOffset;
                return;
            }

            // Dungeon map coordinates

            XOffset = x * 10;
            YOffset = y * 10;
        }

        /// <summary>
        /// Creates a position using sector offsets
        /// </summary>
        /// <param name="xOffset">The x offset.</param>
        /// <param name="yOffset">The y offset.</param>
        /// <param name="zOffset">The z offset.</param>
        /// <param name="regionId">The region identifier.</param>
        public Position(short xOffset, short yOffset, short zOffset, ushort regionId)
            : this()
        {
            Region = regionId;

            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;
        }

        /// <summary>
        /// Creates a position using map offsets
        /// </summary>
        public Position(float xOffset, float yOffset, float zOffset, byte xSector, byte ySector)
            : this()
        {
            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;

            Region.X = xSector;
            Region.Y = ySector;
        }

        /// <summary>
        /// Calculates the distance to the destination
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public double DistanceTo(Position position)
        {
            return Math.Sqrt(Math.Pow(X - position.X, 2) + Math.Pow(Y - position.Y, 2));
        }

        /// <summary>
        /// Reads all requierd data from the packet and returns a new Postion object.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Position FromPacket(Packet packet)
        {
            return new()
            {
                Region = packet.ReadUShort(),
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
            return new()
            {
                Region = packet.ReadUShort(),
                XOffset = packet.ReadInt(),
                ZOffset = packet.ReadInt(),
                YOffset = packet.ReadInt()
            };
        }

        /// <summary>
        /// Reads all requierd data from the packet and returns a new Postion object.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Position FromPacketConditional(Packet packet, bool parseLayerWorldId = true)
        {
            Position position = new()
            {
                Region = packet.ReadUShort()
            };

            if (!position.Region.IsDungeon)
            {
                position.XOffset = packet.ReadShort();
                position.ZOffset = packet.ReadShort();
                position.YOffset = packet.ReadShort();
            }
            else
            {
                position.XOffset = packet.ReadInt();
                position.ZOffset = packet.ReadInt();
                position.YOffset = packet.ReadInt();
            }

            if (parseLayerWorldId)
            {
                position.WorldId = packet.ReadShort();
                position.LayerId = packet.ReadShort();
            }

            return position;
        }

        /// <summary>
        /// Calculates the distance to the current player
        /// </summary>
        public double DistanceToPlayer()
        {
            return DistanceTo(Game.Player.Movement.Source);
        }

        /// <summary>
        /// Get sector by offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <returns>The generated sector</returns>
        public byte GetSectorFromOffset(float offset)
            => (byte)(((128.0 * 192.0 + (128 * 192 + offset / 10)) / 192.0) - 128);

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"X:{X:0.0} Y:{Y:0.0}";
        }
    }
}