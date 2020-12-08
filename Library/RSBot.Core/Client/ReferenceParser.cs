using System;

namespace RSBot.Core.Client
{
    public sealed class ReferenceParser
    {
        private readonly string[] _data;
        private readonly int _length;

        public ReferenceParser(string line)
        {
            _data = line.Split('\t');
            _length = _data.Length;
        }

        public bool TryParseEnum<TEnum>(int index, out TEnum result)
            where TEnum : struct
        {
            if (index < _length && Enum.TryParse(_data[index], out result))
                return true;

            result = default(TEnum);
            return false;
        }

        public bool TryParseString(int index, out string result)
        {
            if (index < _length)
            {
                result = _data[index];
                return true;
            }

            result = default(string);
            return false;
        }

        public bool TryParseString(int index, out string result, string @default)
        {
            if (index < _length)
            {
                result = _data[index];
                return true;
            }

            result = @default;
            return false;
        }

        public bool TryParseBool(int index, out bool result)
        {
            if (index < _length && bool.TryParse(_data[index], out result))
                return true;

            result = default(bool);
            return false;
        }

        public bool TryParseBool(int index, out bool result, bool @default)
        {
            if (index < _length && bool.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseSByte(int index, out sbyte result)
        {
            if (index < _length && sbyte.TryParse(_data[index], out result))
                return true;

            result = default(sbyte);
            return false;
        }

        public bool TryParseSByte(int index, out sbyte result, sbyte @default)
        {
            if (index < _length && sbyte.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseByte(int index, out byte result)
        {
            if (index < _length && byte.TryParse(_data[index], out result))
                return true;

            result = default(byte);
            return false;
        }

        public bool TryParseByte(int index, out byte result, byte @default)
        {
            if (index < _length && byte.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseShort(int index, out short result)
        {
            if (index < _length && short.TryParse(_data[index], out result))
                return true;

            result = default(short);
            return false;
        }

        public bool TryParseShort(int index, out short result, short @default)
        {
            if (index < _length && short.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseUShort(int index, out ushort result)
        {
            if (index < _length && ushort.TryParse(_data[index], out result))
                return true;

            result = default(ushort);
            return false;
        }

        public bool TryParseUShort(int index, out ushort result, ushort @default)
        {
            if (index < _length && ushort.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseInt(int index, out int result)
        {
            if (index < _length && int.TryParse(_data[index], out result))
                return true;

            result = default(int);
            return false;
        }

        public bool TryParseInt(int index, out int result, int @default)
        {
            if (index < _length && int.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseUInt(int index, out uint result)
        {
            if (index < _length && uint.TryParse(_data[index], out result))
                return true;

            result = default(uint);
            return false;
        }

        public bool TryParseUInt(int index, out uint result, uint @default)
        {
            if (index < _length && uint.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseLong(int index, out long result)
        {
            if (index < _length && long.TryParse(_data[index], out result))
                return true;

            result = default(long);
            return false;
        }

        public bool TryParseLong(int index, out long result, long @default)
        {
            if (index < _length && long.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseULong(int index, out ulong result)
        {
            if (index < _length && ulong.TryParse(_data[index], out result))
                return true;

            result = default(ulong);
            return false;
        }

        public bool TryParseULong(int index, out ulong result, ulong @default)
        {
            if (index < _length && ulong.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }

        public bool TryParseFloat(int index, out float result)
        {
            if (index < _length && float.TryParse(_data[index], out result))
                return true;

            result = default(float);
            return false;
        }

        public bool TryParseFloat(int index, out float result, float @default)
        {
            if (index < _length && float.TryParse(_data[index], out result))
                return true;

            result = @default;
            return false;
        }
    }
}