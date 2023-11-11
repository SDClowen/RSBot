using System;
using System.Numerics;
using RSBot.Core.Network;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.Core.Components.NewPosition
{
    public class NewPosition
    {
        public RID Region => _regionPosition.Region;

        //Local space
        public float XOffset => _regionPosition.LocalPosition.X;
        public float YOffset => _regionPosition.LocalPosition.Y;
        public float ZOffset => _regionPosition.LocalPosition.Z;

        //World space
        public float WorldXOffset => _regionPosition.Position.X;
        public float WorldYOffset => _regionPosition.Position.Y;
        public float WorldZOffset => _regionPosition.Position.Z;

        //Coordinates starting from the world's center in "Hotan"
        public float X => XOffset == 0 ? 0 : Region.IsDungeon ? XOffset / 10 : (Region.X - 135) * 192 + XOffset / 10;
        public float Y => ZOffset == 0 ? 0 : Region.IsDungeon ? ZOffset / 10 : (Region.Z - 92) * 192 + ZOffset / 10;

        public NavMeshTransform NavMeshTransform { get; }

        private readonly RegionPosition _regionPosition;

        public NewPosition(ushort regionId) : this(regionId, 0, 0, 0)
        {
        }

        public NewPosition(RID region) : this((ushort)region, 0, 0, 0)
        {
        }

        public NewPosition(RID region, float xOffset, float yOffset, float zOffset) : this((ushort)region, xOffset, yOffset, zOffset)
        {
        }

        public NewPosition(ushort regionId, float xOffset, float yOffset, float zOffset)
        {
            _regionPosition = new RegionPosition(regionId, new Vector3(xOffset, yOffset, zOffset));
            NavMeshTransform = new NavMeshTransform(_regionPosition.Region, _regionPosition.Position);
        }


        /// <summary>
        ///     Calculates the distance to the destination
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public double DistanceTo(NewPosition position)
        {
            var pX = WorldXOffset - position.WorldXOffset;
            var pY = WorldYOffset - position.WorldYOffset;
            var pZ = WorldZOffset - position.WorldZOffset;

            return Math.Sqrt(pX * pX + pY * pY + pZ * pZ);
        }


        public static NewPosition FromPacket(Packet packet)
        {
            var region = (RID)packet.ReadUShort();

            float xOffset, yOffset, zOffset;
            if (region.IsDungeon)
            {
                xOffset = packet.ReadInt();
                yOffset = packet.ReadInt();
                zOffset = packet.ReadInt();
            }
            else
            {
                xOffset = packet.ReadShort();
                yOffset = packet.ReadShort();
                zOffset = packet.ReadShort();
            }

            return new NewPosition(region, xOffset, yOffset, zOffset);
        }
    }
}
