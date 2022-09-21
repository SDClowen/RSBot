using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects
{
    public class Position
    {
        #region Private Members
        private ushort _RegionID;
        private byte _XSector;
        private byte _YSector;
        private float _XOffset;
        private float _YOffset;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Gets or set the region identifier.
        /// </summary>
        public ushort RegionID
        {
            get => _RegionID;
            set
            {
                _RegionID = value;
                _YSector = (byte)(value >> 8);
                _XSector = (byte)(value & 0xFF);
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is in dungeon.
        /// </summary>
        /// <value><c>true</c> if this instance is in dungeon; otherwise, <c>false</c>.</value>
        public bool IsInDungeon => _RegionID > short.MaxValue;
        /// <summary>
        /// Gets the regional X sector.
        /// </summary>
        public byte XSector { get => _XSector; }
        /// <summary>
        /// Gets the regional Y sector.
        /// </summary>
        public byte YSector { get => _YSector; }
        /// <summary>
        /// Gets or set the position X from map
        /// </summary>
        public float XOffset
        {
            get { return _XOffset; }
            set
            {
                if (IsInDungeon)
                {
                    _XOffset = value;
                    _XSector = (byte)(((128.0 * 192.0 + (128 * 192 + value / 10)) / 192.0) - 128);
                }
                else
                {
                    _XOffset = value;
                    while (_XOffset < 0)
                    {
                        _XOffset += 1920;
                        _XSector -= 1;
                    }
                    while (_XOffset > 1920)
                    {
                        _XOffset -= 1920;
                        _XSector += 1;
                    }
                }
            }
        }
        /// <summary>
        /// Gets or set the position Y from map.
        /// </summary>
        public float YOffset
        {
            get { return _YOffset; }
            set
            {
                if (IsInDungeon)
                {
                    _YOffset = value;
                    _YSector = (byte)(((128.0 * 192.0 + (128 * 192 + value / 10)) / 192.0) - 128);
                }
                else
                {
                    _YOffset = value;
                    while (_YOffset < 0)
                    {
                        _YOffset += 1920;
                        _YSector -= 1;
                    }
                    while (_YOffset > 1920)
                    {
                        _YOffset -= 1920;
                        _YSector += 1;
                    }
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
        /// Gets the x coordinate.
        /// </summary>
        /// <value>
        /// The x coordinate.
        /// </value>
        public float XCoordinate => IsInDungeon ? _XOffset / 10 : (_XSector - 135) * 192 + _XOffset / 10;
        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <value>
        /// The y coordinate.
        /// </value>
        public float YCoordinate => IsInDungeon ? _YOffset / 10 : (_YSector - 92) * 192 + _YOffset / 10;
        /// <summary>
        /// Gets offset from x sector.
        /// </summary>
        public float XSectorOffset => IsInDungeon? (127 * 192 + _XOffset / 10) * 10 % 1920 : _XOffset;
        /// <summary>
        /// Gets offset from y sector.
        /// </summary>
        public float YSectorOffset => IsInDungeon ? (128 * 192 + _YOffset / 10) * 10 % 1920 : _YOffset;
        #endregion Public Properties

        #region Constructors
        public Position() { }
        /// <summary>
        /// Creates a position by using world map coordinates
        /// </summary>
        /// <param name="regionID">Region ID required for dungeon maps</param>
        public Position(float xCoordinate, float yCoordinate, ushort regionID = 0)
        {
            RegionID = regionID;
            // World map coordinates has been provided
            if (!IsInDungeon)
            {
                var xOffset = (int)(Math.Abs(xCoordinate) % 192 * 10);
                if (xCoordinate < 0)
                    xOffset = 1920 - xOffset;
                var yOffset = (int)(Math.Abs(yCoordinate) % 192 * 10);
                if (yCoordinate < 0)
                    yOffset = 1920 - yOffset;

                _XSector = (byte)Math.Round((xCoordinate - xOffset / 10f) / 192f + 135);
                _YSector = (byte)Math.Round((yCoordinate - yOffset / 10f) / 192f + 92);
                _RegionID = (ushort)((_YSector << 8) | _XSector);

                XOffset = xOffset;
                YOffset = yOffset;
            }
            // Dungeon map coordinates
            else
            {
                XOffset = xCoordinate * 10;
                YOffset = yCoordinate * 10;
            }            
        }
        /// <summary>
        /// Creates a position using map offsets
        /// </summary>
        public Position(float xOffset, float yOffset, float zOffset, byte xSector, byte ySector)
        {
            _RegionID = (ushort)((ySector << 8) | xSector);
            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;
        }
        /// <summary>
        /// Creates a position using map offsets
        /// </summary>
        public Position(float xOffset, float yOffset, float zOffset, ushort regionID)
        {
            RegionID = regionID;
            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;
        }
        #endregion

        #region Public Methods
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
        /// <summary>
        /// Calculates the distance to the destination
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public double DistanceTo(Position position)
        {
            // Distance cannot be calculated
            if (IsInDungeon != position.IsInDungeon)
                return double.MaxValue;
            // Make sure they are in the same dungeon
            if (IsInDungeon && RegionID != position.RegionID)
                return double.MaxValue;

            // Both are in the same region
            return Math.Sqrt(Math.Pow(XCoordinate - position.XCoordinate, 2) + Math.Pow(YCoordinate - position.YCoordinate, 2));
        }
        #endregion Public Methods

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
                RegionID = packet.ReadUShort(),
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
                RegionID = packet.ReadUShort(),
                XOffset = packet.ReadInt(),
                ZOffset = packet.ReadInt(),
                YOffset = packet.ReadInt()
            };
        }
        /// <summary>
        /// Calculates the distance to the current player
        /// </summary>
        public double DistanceToPlayer()
        {
            return DistanceTo(Game.Player.Movement.Source);
        }
        #endregion Helper
    }
}