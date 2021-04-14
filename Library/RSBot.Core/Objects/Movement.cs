using RSBot.Core.Network;

namespace RSBot.Core.Objects
{
    public struct Movement
    {
        /// <summary>
        /// Gets or sets the has destination.
        /// </summary>
        public bool HasDestination;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public byte Type;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        public Position Destination;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public Position Source;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public MovementState StateType;

        /// <summary>
        /// Gets or sets the has source.
        /// </summary>
        public bool HasSource;

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        public double Angle;

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
                    XSector = packet.ReadByte(),
                    YSector = packet.ReadByte(),
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
                result.Type = packet.ReadByte();
                result.Angle = packet.ReadShort();
            }

            result.HasSource = packet.ReadBool();

            if (result.HasSource)
            {
                result.Source.XSector = packet.ReadByte();
                result.Source.YSector = packet.ReadByte();
                if (!result.Source.IsInDungeon)
                {
                    result.Source.XOffset = packet.ReadShort() / 10;
                    result.Source.ZOffset = packet.ReadInt() / 10;
                    result.Source.YOffset = packet.ReadShort() / 10;
                }
                else
                {
                    result.Source.XOffset = packet.ReadInt() / 10;
                    result.Source.ZOffset = packet.ReadInt() / 10;
                    result.Source.YOffset = packet.ReadInt() / 10;
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
                Type = packet.ReadByte()
            };

            if (result.HasDestination)
            {
                result.Destination = new Position { XSector = packet.ReadByte(), YSector = packet.ReadByte() };

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
                result.StateType = (MovementState)packet.ReadByte();
                result.Angle = packet.ReadShort();
            }
            return result;
        }
    }
}