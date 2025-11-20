namespace RSBot.Core.Extensions;

public static class UShortExtensions
{
    public static byte ToLoByte(this ushort value)
    {
        return (byte)(value & 0xFF);
    }

    public static byte ToHiByte(this ushort value)
    {
        return (byte)(value >> 8);
    }
}
