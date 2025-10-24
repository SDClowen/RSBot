using System;
using System.Numerics;
using RSBot.Core.Network;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Dungeon;

namespace RSBot.Core.Objects;

public struct Position
{

    /// <summary>
    ///     Gets the regional id.
    /// </summary>
    public Region Region;

    /// <summary>
    ///     Gets or set the position X from map
    /// </summary>
    public float XOffset { get; set; }

    /// <summary>
    ///     Gets or set the position Y from map.
    /// </summary>
    public float YOffset { get; set; }
    /// <summary>
    ///     Gets or set the position Z from map.
    /// </summary>
    public float ZOffset { get; set; }

    /// <summary>
    ///     Gets or sets the angle.
    /// </summary>
    public short Angle { get; set; }

    /// <summary>
    ///     Gets or sets the world id.
    /// </summary>
    public short WorldId { get; set; }

    public short LayerId { get; set; }

    /// <summary>
    ///     Gets the x coordinate.
    /// </summary>
    /// <value>
    ///     The x coordinate.
    /// </value>
    public float X => XOffset == 0 ? 0 : Region.IsDungeon ? XOffset / 10 : (Region.X - 135) * 192 + XOffset / 10;

    /// <summary>
    ///     Gets the y coordinate.
    /// </summary>
    /// <value>
    ///     The y coordinate.
    /// </value>
    public float Y => YOffset == 0 ? 0 : Region.IsDungeon ? YOffset / 10 : (Region.Y - 92) * 192 + YOffset / 10;

    /// <summary>
    ///     Gets offset from x sector.
    /// </summary>
    public float XSectorOffset => Region.IsDungeon ? (127 * 192 + XOffset / 10) * 10 % 1920 : XOffset;

    /// <summary>
    ///     Gets offset from y sector.
    /// </summary>
    public float YSectorOffset => Region.IsDungeon ? (128 * 192 + YOffset / 10) * 10 % 1920 : YOffset;

    /// <summary>
    ///     Creates a position by using world map coordinates
    /// </summary>
    /// <param name="region">Region required for dungeon maps</param>
    public Position(float x, float y, Region region = default)
        : this()
    {
        Region = region;

        // World map coordinates has been provided
        if (!Region.IsDungeon)
        {
            var xOffset = MathF.Abs(x) % 192.0f * 10.0f;
            if (x < 0)
                xOffset = 1920.0f - xOffset;

            var yOffset = MathF.Abs(y) % 192.0f * 10.0f;
            if (y < 0)
                yOffset = 1920.0f - yOffset;

            Region.X = (byte)MathF.Round((x - xOffset / 10.0f) / 192.0f + 135.0f);
            Region.Y = (byte)MathF.Round((y - yOffset / 10.0f) / 192.0f + 92.0f);

            XOffset = xOffset;
            YOffset = yOffset;
            return;
        }

        // Dungeon map coordinates

        XOffset = x * 10;
        YOffset = y * 10;
    }

    /// <summary>
    ///     Creates a position by using world map coordinates without region
    /// </summary>
    public Position(float x, float y)
    : this()
    {
        var xOffset = MathF.Abs(x) % 192.0f * 10.0f;
        if (x < 0)
            xOffset = 1920.0f - xOffset;

        var yOffset = MathF.Abs(y) % 192.0f * 10.0f;
        if (y < 0)
            yOffset = 1920.0f - yOffset;

        byte regionX = (byte)Math.Round((x - xOffset / 10.0f) / 192.0f + 135.0f);
        byte regionY = (byte)Math.Round((y - yOffset / 10.0f) / 192.0f + 92.0f);

        Region = new((ushort)((regionY << 8) | regionX));

        if (!Region.IsDungeon)
        {
            XOffset = xOffset;
            YOffset = yOffset;
            return;
        }

        XOffset = x * 10;
        YOffset = y * 10;
    }

    /// <summary>
    ///     Creates a position using sector offsets
    /// </summary>
    /// <param name="region">The region identifier.</param>
    /// <param name="xOffset">The x offset.</param>
    /// <param name="yOffset">The y offset.</param>
    /// <param name="zOffset">The z offset.</param>
    public Position(Region region, float xOffset, float yOffset, float zOffset)
        : this()
    {
        Region = region;

        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;
    }

    /// <summary>
    ///     Creates a position using map offsets
    /// </summary>
    public Position(byte xSector, byte ySector, float xOffset, float yOffset, float zOffset)
        : this()
    {
        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;

        Region.X = xSector;
        Region.Y = ySector;
    }

    /// <summary>
    ///     Calculates the distance to the destination
    /// </summary>
    /// <param name="position">The position.</param>
    /// <returns></returns>
    public double DistanceTo(Position position)
    {
        var pX = X - position.X;
        var pY = Y - position.Y;

        return Math.Sqrt(pX * pX + pY * pY);
    }

    /// <summary>
    ///     Reads all requierd data from the packet and returns a new Postion object.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public static Position FromPacket(Packet packet)
    {
        return new Position
        {
            Region = packet.ReadUShort(),
            XOffset = packet.ReadFloat(),
            ZOffset = packet.ReadFloat(),
            YOffset = packet.ReadFloat(),
            Angle = packet.ReadShort()
        };
    }

    /// <summary>
    ///     Reads all requierd data from the packet and returns a new Postion object.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <returns></returns>
    public static Position FromPacketInt(Packet packet)
    {
        return new Position
        {
            Region = packet.ReadUShort(),
            XOffset = packet.ReadInt(),
            ZOffset = packet.ReadInt(),
            YOffset = packet.ReadInt()
        };
    }

    /// <summary>
    ///     Reads all requierd data from the packet and returns a new Postion object.
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
    ///     Calculates the distance to the current player
    /// </summary>
    public double DistanceToPlayer()
    {
        return DistanceTo(Game.Player.Position);
    }

    /// <summary>
    ///     Get sector by offset
    /// </summary>
    /// <param name="offset">The offset</param>
    /// <returns>The generated sector</returns>
    public byte GetSectorFromOffset(float offset)
    {
        return (byte)((128.0 * 192.0 + (128 * 192 + offset / 10)) / 192.0 - 128);
    }

    /// <summary>
    ///     Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///     A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"X:{X:0.0} Y:{Y:0.0}";
    }

    public bool TryGetNavMeshTransform(out NavMeshTransform transform)
    {
        transform = new NavMeshTransform(Region.Id, new Vector3(XOffset, ZOffset, YOffset));

        return NavMeshManager.ResolveCellAndHeight(transform);
    }

    public bool HasCollisionBetween(Position destination, NavMeshRaycastType type = NavMeshRaycastType.Attack)
    {
        if (!Kernel.EnableCollisionDetection)
            return false;

        if (!TryGetNavMeshTransform(out var srcTransform)
            || !destination.TryGetNavMeshTransform(out var destTransform))
            return false;

        return !NavMeshManager.Raycast(srcTransform, destTransform, type);
    }
}