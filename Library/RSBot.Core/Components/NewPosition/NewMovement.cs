using RSBot.Core.Network;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.Core.Components.NewPosition
{
    internal class NewMovement
    {
        public NewPosition Source;
        public NewPosition Destination;
        public float Angle;

        public bool HasSource => Source != null;
        public bool HasDestination => Destination != null;

        public static NewMovement FromPacket(Packet packet)
        {
            NewPosition src = null, dest = null;
            float angle = 0;

            //Destination
            if (packet.ReadBool())
                dest = NewPosition.FromPacket(packet);
            else
            {
                packet.ReadByte();
                angle = packet.ReadFloat();
            }

            //Source
            if (packet.ReadBool())
            {
                var region = (RID)packet.ReadUShort();

                float xOffset, yOffset, zOffset;
                if (region.IsDungeon)
                {
                    xOffset = packet.ReadInt() / 10f;
                    yOffset = packet.ReadFloat();
                    zOffset = packet.ReadInt() / 10f;
                }
                else
                {
                    xOffset = packet.ReadShort() / 10f;
                    yOffset = packet.ReadFloat();
                    zOffset = packet.ReadShort() / 10f;
                }

                src = new NewPosition(region, xOffset, yOffset, zOffset);
            }

            return new NewMovement { Source = src, Destination = dest, Angle = angle};
        }
    }
}
