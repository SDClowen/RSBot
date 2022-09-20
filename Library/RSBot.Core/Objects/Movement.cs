using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects
{
    public struct Movement
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public MovementType Type;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public bool Moving;

        /// <summary>
        /// Gets or sets the has destination.
        /// </summary>
        public bool HasDestination;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        public Position Destination;

        /// <summary>
        /// Gets or sets the has source.
        /// </summary>
        public bool HasSource;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Position Source;

        /// <summary>
        /// Gets or sets the has angle.
        /// </summary>
        public bool HasAngle;

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        public float Angle;

        internal double MovingX, MovingY;
        internal TimeSpan RemainingTime;

        /// <summary>
        /// Motion from packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Movement MotionFromPacket(Packet packet)
        {
            var result = new Movement { HasDestination = packet.ReadBool() };

            if (result.HasDestination)
            {
                result.Destination = new Position
                {
                    RegionID = packet.ReadUShort()
                };

                if (!result.Destination.IsInDungeon)
                {
                    result.Destination.XOffset = packet.ReadShort();
                    result.Destination.ZOffset = packet.ReadShort();
                    result.Destination.YOffset = packet.ReadShort();
                }
                else
                {
                    result.Destination.XOffset = packet.ReadInt();
                    result.Destination.ZOffset = packet.ReadInt();
                    result.Destination.YOffset = packet.ReadInt();
                }
            }
            else
            {
                result.HasDestination = packet.ReadByte() == 1; //0 = Spinning, 1 = Sky-/Key-walking
                result.HasAngle = true;
                result.Angle = packet.ReadShort();
            }

            var hasEvent = packet.ReadBool();
            if (hasEvent)
            {
                if (result.HasDestination)
                {
                    // Sector changed

                    //ushort latestRegionID = packet.ReadUShort();
                    // ushort unkUShort01
                    // ushort unkUShort02
                    // ushort unkUShort03
                    // ushort unkUShort04
                }
                else
                {
                    // Angle changed

                    result.HasAngle = true;
                    result.Angle = packet.ReadShort();
                    // short unkShort01 = packet.ReadShort();
                    // short unkShort02 = packet.ReadShort();
                    // short unkShort03 = packet.ReadShort();
                    // short unkShort04 = packet.ReadShort();
                }
            }
            return result;
        }

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Movement FromPacket(Packet packet)
        {
            var result = new Movement
            {
                Source = Position.FromPacket(packet),
                HasDestination = packet.ReadBool(),
                Type = (MovementType)packet.ReadByte()
            };

            if (result.HasDestination)
            {
                result.Destination = new Position { RegionID = packet.ReadUShort() };

                if (!result.Destination.IsInDungeon)
                {
                    result.Destination.XOffset = packet.ReadShort();
                    result.Destination.ZOffset = packet.ReadShort();
                    result.Destination.YOffset = packet.ReadShort();
                }
                else
                {
                    result.Destination.XOffset = packet.ReadInt();
                    result.Destination.ZOffset = packet.ReadInt();
                    result.Destination.YOffset = packet.ReadInt();
                }
            }
            else
            {
                var actionType = packet.ReadByte();  //0 = Spinning, 1 = Sky-/Key-walking
                result.HasAngle = true;
                result.Angle = packet.ReadShort();
            }

            return result;
        }
    }
}