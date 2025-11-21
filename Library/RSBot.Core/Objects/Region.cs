using System.Runtime.InteropServices;
using RSBot.Core.Network;

namespace RSBot.Core.Objects;

[StructLayout(LayoutKind.Explicit)]
public struct Region
{
    [FieldOffset(0)]
    public ushort Id;

    [FieldOffset(0)]
    public byte X;

    [FieldOffset(sizeof(byte))]
    public byte Y;

    public bool IsDungeon => (Id & 0x8000) != 0;

    public Region(ushort id)
        : this()
    {
        Id = id;
    }

    public Region(byte x, byte y)
        : this()
    {
        X = x;
        Y = y;
    }

    public static implicit operator ushort(Region wrapper)
    {
        return wrapper.Id;
    }

    public static implicit operator Region(ushort value)
    {
        return new Region(value);
    }

    public Region[] GetSurroundingRegions()
    {
        if (this.IsDungeon)
        {
            return new[] { this };
        }
        return new Region[]
        {
            new((byte)(X - 1), (byte)(Y + 1)), //TL
            new(X, (byte)(Y + 1)), //TC
            new((byte)(X + 1), (byte)(Y + 1)), //TR
            new((byte)(X - 1), Y), //CL
            new(X, Y), //CC
            new((byte)(X + 1), Y), //CR
            new((byte)(X - 1), (byte)(Y - 1)), //BL
            new(X, (byte)(Y - 1)), //BC
            new((byte)(X + 1), (byte)(Y - 1)), //BR
        };
    }

    /// <summary>
    ///     Write current value to the packet
    /// </summary>
    /// <param name="packet">The packet.</param>
    internal void Serialize(Packet packet)
    {
        packet.WriteUShort(Id);
    }

    public static bool TryParse(string value, out Region parsedValue)
    {
        parsedValue = 0;
        if (!int.TryParse(value, out var parsed))
            return false;
        unchecked
        {
            parsedValue = (ushort)parsed;
        }

        return true;
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}
