using System;
using System.Globalization;
using RSBot.Core.Objects;

namespace RSBot.Core.Client;

public sealed class ReferenceParser
{
    private readonly string[] _data;
    private readonly int _length;

    public ReferenceParser(string line)
    {
        _data = line.Split('\t');
        _length = _data.Length;
    }

    public int GetColumnCount()
    {
        return _data.Length;
    }

    public bool TryParse<TEnum>(int index, out TEnum result)
        where TEnum : struct
    {
        if (index < _length && Enum.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out string result)
    {
        if (index < _length)
        {
            result = _data[index];
            return true;
        }

        result = default;
        return false;
    }

    public bool TryParse(int index, out string result, string @default)
    {
        if (index < _length)
        {
            result = _data[index];
            return true;
        }

        result = @default;
        return false;
    }

    public bool TryParse(int index, out bool result)
    {
        result = false;

        if (index >= _length)
            return false;

        if (byte.TryParse(_data[index], out var value))
        {
            result = value == 1;
            return true;
        }

        return false;
    }

    public bool TryParse(int index, out bool result, bool @default)
    {
        if (TryParse(index, out result))
            return true;

        result = @default;

        return false;
    }

    public bool TryParse(int index, out byte result)
    {
        if (index < _length && byte.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out byte result, byte @default)
    {
        if (index < _length && byte.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out short result)
    {
        if (index < _length && short.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out short result, short @default)
    {
        if (index < _length && short.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out ushort result)
    {
        if (index < _length && ushort.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out ushort result, ushort @default)
    {
        if (index < _length && ushort.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out Region result)
    {
        if (index < _length && Region.TryParse(_data[index], out result))
            return true;

        result = default(ushort);
        return false;
    }

    public bool TryParse(int index, out Region result, Region @default)
    {
        if (index < _length && Region.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out int result)
    {
        if (index < _length && int.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out int result, int @default)
    {
        if (index < _length && int.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out uint result)
    {
        if (index < _length && uint.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out uint result, uint @default)
    {
        if (index < _length && uint.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out long result)
    {
        if (index < _length && long.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out long result, long @default)
    {
        if (index < _length && long.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out ulong result)
    {
        if (index < _length && ulong.TryParse(_data[index], out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out ulong result, ulong @default)
    {
        if (index < _length && ulong.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }

    public bool TryParse(int index, out float result)
    {
        if (index < _length && float.TryParse(_data[index], NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            return true;

        result = default;
        return false;
    }

    public bool TryParse(int index, out float result, float @default)
    {
        if (index < _length && float.TryParse(_data[index], out result))
            return true;

        result = @default;
        return false;
    }
}
