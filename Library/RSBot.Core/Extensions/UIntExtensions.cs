namespace RSBot.Core.Extensions;

public static class UIntExtensions
{
    public static ushort LoWord(this uint value)
    {
        return (ushort)(value & 0xFFFF);
    }

    public static ushort HiWord(this uint value)
    {
        return (ushort)(value >> 16);
    }
}
