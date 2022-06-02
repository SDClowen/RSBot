using System;
using System.IO;
using System.Text;

namespace RSBot.Pk2.IO.Stream
{
    /// <summary>
    /// This class handles all the stream data. It can read and write data from/to it and
    /// safe it back to a file
    /// </summary>
    internal class StreamWorker : IDisposable
    {
        /// <summary>
        /// Gets the reader.
        /// </summary>
        /// <value>
        /// The reader.
        /// </value>
        public Reader Reader { get; private set; }

        /// <summary>
        /// Gets or sets the writer.
        /// </summary>
        /// <value>
        /// The writer.
        /// </value>
        public Writer Writer { get; private set; }

        /// <summary>
        /// Represents the buffer data
        /// </summary>
        public byte[] Buffer { get; private set; }

        /// <summary>
        /// Gets the operation.
        /// </summary>
        /// <value>
        /// The operation.
        /// </value>
        public StreamOperation Operation { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposing; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposing { get; set; }

        /// <summary>
        /// Represents the lock so the data cannot be damaged while using multiple threads
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>Constructor
        /// Initializes the StreamController with a default buffer
        /// </summary>
        /// <param name="buffer">Data</param>
        /// <param name="operation">Type</param>
        public StreamWorker(byte[] buffer, StreamOperation operation)
        {
            Operation = operation;

            switch (operation)
            {
                case StreamOperation.Read:
                    Reader = new Reader(buffer);
                    break;

                case StreamOperation.ReadWrite:
                    Reader = new Reader(buffer);

                    Writer = buffer != null ? new Writer(buffer) : new Writer();
                    break;

                case StreamOperation.Write:
                    Writer = buffer != null ? new Writer(buffer) : new Writer();
                    break;
            }
        }

        #region Destructor

        ~StreamWorker()
        {
            if (!IsDisposing && !IsDisposed) Dispose();
        }

        #endregion Destructor

        #region Read

        /// <summary>
        /// Reads the next byte from the stream
        /// </summary>
        /// <returns>Next byte</returns>
        public byte ReadByte()
        {
            lock (_lock) { return Reader.ReadByte(); }
        }

        /// <summary>
        /// Reads the byte array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public byte[] ReadByteArray(int count)
        {
            lock (_lock)
            {
                var buffer = new byte[count];

                for (var i = 0; i < count; i++)
                    buffer[i] = ReadByte();

                return buffer;
            }
        }

        /// <summary>
        /// Reads the next sbyte from the stream
        /// </summary>
        /// <returns>Next sbyte</returns>
        public sbyte ReadSByte()
        {
            lock (_lock) { return Reader.ReadSByte(); }
        }

        /// <summary>
        /// Reads the next ushort from the stream
        /// </summary>
        /// <returns>Next ushort</returns>
        public ushort ReadUShort()
        {
            lock (_lock) { return Reader.ReadUInt16(); }
        }

        /// <summary>
        /// Reads the next short from the stream
        /// </summary>
        /// <returns>Next short</returns>
        public short ReadShort()
        {
            lock (_lock) { return Reader.ReadInt16(); }
        }

        /// <summary>
        /// Reads the next uinteger from the stream
        /// </summary>
        /// <returns>Next uinteger</returns>
        public uint ReadUInt()
        {
            lock (_lock) { return Reader.ReadUInt32(); }
        }

        /// <summary>
        /// Reads the next integer from the stream
        /// </summary>
        /// <returns>Next integer</returns>
        public int ReadInt()
        {
            lock (_lock) { return Reader.ReadInt32(); }
        }

        /// <summary>
        /// Reads the next ulong from the stream
        /// </summary>
        /// <returns>Next ulong</returns>
        public ulong ReadULong()
        {
            lock (_lock) { return Reader.ReadUInt64(); }
        }

        /// <summary>
        /// Reads the next long from the stream
        /// </summary>
        /// <returns>Next long</returns>
        public long ReadLong()
        {
            lock (_lock) { return Reader.ReadInt64(); }
        }

        /// <summary>
        /// Reads the next float from the stream
        /// </summary>
        /// <returns>Next float</returns>
        public float ReadFloat()
        {
            lock (_lock) { return Reader.ReadSingle(); }
        }

        /// <summary>
        /// Reads the next double from the stream
        /// </summary>
        /// <returns>Next double</returns>
        public double ReadDouble()
        {
            lock (_lock) { return Reader.ReadDouble(); }
        }

        /// <summary>
        /// Reads the next string from the stream by a specific codepage
        /// </summary>
        /// <returns>Next string</returns>
        public string ReadString(int length, int codepage = 65001)
        {
            lock (_lock)
            {
                var bytes = Reader.ReadBytes(length);
                return Encoding.GetEncoding(codepage).GetString(bytes);
            }
        }

        /// <summary>
        /// Reads a boolean from the current buffer
        /// </summary>
        /// <returns>Next boolean</returns>
        public bool ReadBool()
        {
            lock (_lock) { return Reader.ReadBoolean(); }
        }

        /// <summary>
        /// Reads a boolean array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of booleans in the array</param>
        /// <returns>Next boolean array</returns>
        public bool[] ReadBoolArray(int count)
        {
            lock (_lock)
            {
                var boolArray = new bool[count];

                for (var i = 0; i < count; i++)
                    boolArray[i] = Reader.ReadBoolean();

                return boolArray;
            }
        }

        /// <summary>
        /// Reads a float array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of floats in the array</param>
        /// <returns>Next float array</returns>
        public float[] ReadFloatArray(int count)
        {
            lock (_lock)
            {
                var numArray = new float[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadSingle();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a integer array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of integer in the array</param>
        /// <returns>Next integer array</returns>
        public int[] ReadIntArray(int count)
        {
            lock (_lock)
            {
                var numArray = new int[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadInt32();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a long array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of longs in the array</param>
        /// <returns>Next long array</returns>
        public long[] ReadLongArray(int count)
        {
            lock (_lock)
            {
                var numArray = new long[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadInt64();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a sbyte array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of sbytes in the array</param>
        /// <returns>Next sbyte array</returns>
        public sbyte[] ReadSByteArray(int count)
        {
            lock (_lock)
            {
                var numArray = new sbyte[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadSByte();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a sbyte array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of shorts in the array</param>
        /// <returns>Next short array</returns>
        public short[] ReadShortArray(int count)
        {
            lock (_lock)
            {
                var numArray = new short[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadInt16();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a uinteger array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of uintegers in the array</param>
        /// <returns>Next uinteger array</returns>
        public uint[] ReadUIntArray(int count)
        {
            lock (_lock)
            {
                var numArray = new uint[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadUInt32();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a ulong array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of ulongs in the array</param>
        /// <returns>Next ulong array</returns>
        public ulong[] ReadULongArray(int count)
        {
            lock (_lock)
            {
                var numArray = new ulong[count];

                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadUInt64();

                return numArray;
            }
        }

        /// <summary>
        /// Reads a unicode array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of unicodes in the array</param>
        /// <returns>Next unicode array</returns>
        public string[] ReadUnicodeArray(int count)
        {
            lock (_lock)
            {
                var strArray = new string[count];
                for (var i = 0; i < count; i++)
                {
                    var num2 = Reader.ReadUInt16();
                    var bytes = Reader.ReadBytes(num2 * 2);
                    strArray[i] = Encoding.Unicode.GetString(bytes);
                }
                return strArray;
            }
        }

        /// <summary>
        /// Reads a ushort array from the buffer by using a count
        /// </summary>
        /// <param name="count">count of ushorts in the array</param>
        /// <returns>Next ushort array</returns>
        public ushort[] ReadUShortArray(int count)
        {
            lock (_lock)
            {
                var numArray = new ushort[count];
                for (var i = 0; i < count; i++)
                    numArray[i] = Reader.ReadUInt16();

                return numArray;
            }
        }

        /// <summary>Seek Read
        /// Sets the position in the current reader stream
        /// </summary>
        /// <param name="offset">Startpoint</param>
        /// <param name="origin"></param>
        /// <returns>Seek</returns>
        public long SeekRead(long offset, SeekOrigin origin)
        {
            lock (_lock) { return Reader.BaseStream.Seek(offset, origin); }
        }

        #endregion Read

        #region Write

        /// <summary>AppendData
        /// Appends a  of data to the writer
        /// </summary>
        /// <param name="data">Block of data</param>
        public void Append(byte[] data)
        {
            WriteByteArray(data);
        }

        /// <summary>
        /// Extends the writer to a new size.
        /// </summary>
        /// <param name="finalSize">The final size.</param>
        public void ExtendTo(int finalSize)
        {
            var dataToAppend = new byte[finalSize - Writer.BaseStream.Length];
            for (var i = 0; i < dataToAppend.Length; i++)
                dataToAppend[i] = 0;

            Append(dataToAppend);
        }

        /// <summary>
        /// Appends a block of data to the writer
        /// </summary>
        /// <param name="stream">StreamController to append</param>
        public void Append(StreamWorker stream)
        {
            WriteByteArray(stream.GetWriterBytes());
        }

        /// <summary>
        /// Sets the current position within the stream
        /// </summary>
        /// <param name="position"></param>
        public void SeekWrite(long position)
        {
            Writer.BaseStream.Position = position;
        }

        /// <summary>
        /// Writes the string.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteString(object value)
        {
            WriteAscii(value, 0x4e4);
        }

        /// <summary>
        /// Writes the string.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteString(string value)
        {
            WriteAscii(value, 0x4e4);
        }

        /// <summary>
        /// Writes the ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAscii(object value, int codepage)
        {
            lock (_lock)
            {
                var bytes = Encoding.GetEncoding(codepage).GetBytes(value.ToString());
                var s = Encoding.UTF7.GetString(bytes);
                var buffer = Encoding.Default.GetBytes(s);
                Writer.Write(buffer);
            }
        }

        /// <summary>
        /// Writes the ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAscii(string value, int codepage)
        {
            lock (_lock)
            {
                var bytes = Encoding.GetEncoding(codepage).GetBytes(value);
                var s = Encoding.UTF7.GetString(bytes);
                var buffer = Encoding.Default.GetBytes(s);
                Writer.Write(buffer);
            }
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteAsciiArray(object[] values)
        {
            WriteAsciiArray(values, 0, values.Length, 0x4e4);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteAsciiArray(string[] values)
        {
            WriteAsciiArray(values, 0, values.Length, 0x4e4);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAsciiArray(object[] values, int codepage)
        {
            WriteAsciiArray(values, 0, values.Length, codepage);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAsciiArray(string[] values, int codepage)
        {
            WriteAsciiArray(values, 0, values.Length, codepage);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteAsciiArray(object[] values, int index, int count)
        {
            WriteAsciiArray(values, index, count, 0x4e4);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteAsciiArray(string[] values, int index, int count)
        {
            WriteAsciiArray(values, index, count, 0x4e4);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAsciiArray(object[] values, int index, int count, int codepage)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteAscii(values[i].ToString(), codepage);
            }
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteAsciiArray(string[] values, int index, int count, int codepage)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteAscii(values[i], codepage);
            }
        }

        /// <summary>
        /// Writes the bool.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void WriteBool(bool value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the bool.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteBool(object value)
        {
            lock (_lock)
            {
                Writer.Write((byte)(Convert.ToUInt64(value) & 0xffL));
            }
        }

        /// <summary>
        /// Writes the bool array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteBoolArray(bool[] values)
        {
            WriteBoolArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the bool array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteBoolArray(object[] values)
        {
            WriteBoolArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the bool array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteBoolArray(bool[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the bool array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteBoolArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteBool(values[i]);
            }
        }

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteByte(byte value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteByte(object value)
        {
            lock (_lock)
            {
                Writer.Write((byte)(Convert.ToUInt64(value) & 0xffL));
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteByteArray(byte[] values)
        {
            lock (_lock)
            {
                Writer.Write(values);
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteByteArray(object[] values)
        {
            lock (_lock)
            {
                WriteByteArray(values, 0, values.Length);
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteByteArray(byte[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteByteArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteByte(values[i]);
            }
        }

        /// <summary>
        /// Writes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteDouble(double value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteDouble(object value)
        {
            lock (_lock)
            {
                Writer.Write(Convert.ToDouble(value));
            }
        }

        /// <summary>
        /// Writes the double array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteDoubleArray(double[] values)
        {
            WriteDoubleArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the double array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteDoubleArray(object[] values)
        {
            WriteDoubleArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the double array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteDoubleArray(double[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the double array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteDoubleArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteDouble(values[i]);
            }
        }

        /// <summary>
        /// Writes the float.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteFloat(object value)
        {
            lock (_lock)
            {
                Writer.Write(Convert.ToSingle(value));
            }
        }

        /// <summary>
        /// Writes the float.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteFloat(float value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the float array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteFloatArray(object[] values)
        {
            WriteFloatArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the float array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteFloatArray(float[] values)
        {
            WriteFloatArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the float array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteFloatArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteFloat(values[i]);
            }
        }

        /// <summary>
        /// Writes the float array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteFloatArray(float[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the integer.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteInt(int value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the int.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteInt(object value)
        {
            lock (_lock)
            {
                Writer.Write((int)(((ulong)Convert.ToInt64(value)) & 0xffffffffL));
            }
        }

        /// <summary>
        /// Writes the int array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteIntArray(int[] values)
        {
            WriteIntArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the int array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteIntArray(object[] values)
        {
            WriteIntArray(values, 0, values.Length);
        }

        public void WriteIntArray(int[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the int array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteIntArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteInt(values[i]);
            }
        }

        /// <summary>
        /// Writes the long.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteLong(long value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the long.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteLong(object value)
        {
            lock (_lock)
            {
                Writer.Write(Convert.ToInt64(value));
            }
        }

        /// <summary>
        /// Writes the long array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteLongArray(long[] values)
        {
            WriteLongArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the long array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteLongArray(object[] values)
        {
            WriteLongArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the long array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteLongArray(long[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the long array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteLongArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteLong(values[i]);
            }
        }

        /// <summary>
        /// Writes the s byte.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteSByte(object value)
        {
            lock (_lock)
            {
                Writer.Write((sbyte)(Convert.ToInt64(value) & 0xffL));
            }
        }

        /// <summary>
        /// Writes the s byte.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteSByte(sbyte value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the s byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteSByteArray(object[] values)
        {
            WriteSByteArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the s byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteSByteArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteSByte(values[i]);
            }
        }

        /// <summary>
        /// Writes the short.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteShort(short value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the short.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteShort(object value)
        {
            lock (_lock)
            {
                Writer.Write((ushort)(Convert.ToInt64(value) & 0xffffL));
            }
        }

        /// <summary>
        /// Writes the short array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteShortArray(short[] values)
        {
            WriteShortArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the short array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteShortArray(object[] values)
        {
            WriteShortArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the short array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteShortArray(short[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the short array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteShortArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteShort(values[i]);
            }
        }

        /// <summary>
        /// Writes the u int.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUInt(object value)
        {
            lock (_lock)
            {
                Writer.Write((uint)(Convert.ToUInt64(value) & 0xffffffffL));
            }
        }

        /// <summary>
        /// Writes the u int.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUInt(uint value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u int array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUIntArray(object[] values)
        {
            WriteUIntArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u int array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUIntArray(uint[] values)
        {
            WriteUIntArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u int array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUIntArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteUInt(values[i]);
            }
        }

        /// <summary>
        /// Writes the u int array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUIntArray(uint[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the u long.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteULong(object value)
        {
            lock (_lock)
            {
                Writer.Write(Convert.ToUInt64(value));
            }
        }

        /// <summary>
        /// Writes the u long.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteULong(ulong value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u long array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteULongArray(object[] values)
        {
            WriteULongArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u long array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteULongArray(ulong[] values)
        {
            WriteULongArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u long array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteULongArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteULong(values[i]);
            }
        }

        /// <summary>
        /// Writes the u long array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteULongArray(ulong[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    Writer.Write(values[i]);
            }
        }

        /// <summary>
        /// Writes the unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUnicode(object value)
        {
            lock (_lock)
            {
                var bytes = Encoding.Unicode.GetBytes(value.ToString());
                Writer.Write(bytes);
            }
        }

        /// <summary>
        /// Writes the unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUnicode(string value)
        {
            lock (_lock)
            {
                var bytes = Encoding.Unicode.GetBytes(value);
                Writer.Write(bytes);
            }
        }

        /// <summary>
        /// Writes the unicode array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUnicodeArray(object[] values)
        {
            WriteUnicodeArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the unicode array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUnicodeArray(string[] values)
        {
            WriteUnicodeArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the unicode array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUnicodeArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteUnicode(values[i].ToString());
            }
        }

        /// <summary>
        /// Writes the unicode array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUnicodeArray(string[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteUnicode(values[i]);
            }
        }

        /// <summary>
        /// Writes the u short.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUShort(object value)
        {
            lock (_lock)
            {
                Writer.Write((ushort)(Convert.ToUInt64(value) & (0xffffL)));
            }
        }

        /// <summary>
        /// Writes the u short.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteUShort(ushort value)
        {
            lock (_lock)
            {
                Writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u short array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUShortArray(object[] values)
        {
            WriteUShortArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u short array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteUShortArray(ushort[] values)
        {
            WriteUShortArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the u short array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUShortArray(object[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                    WriteUShort(values[i]);
            }
        }

        /// <summary>
        /// Writes the u short array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        public void WriteUShortArray(ushort[] values, int index, int count)
        {
            lock (_lock)
            {
                for (var i = index; i < (index + count); i++)
                {
                    Writer.Write(values[i]);
                }
            }
        }

        #endregion Write

        /// <summary>Get Writer Bytes
        /// Returns the current buffer of the writer
        /// </summary>
        /// <returns></returns>
        public byte[] GetWriterBytes()
        {
            return Writer.GetBuffer();
        }

        /// <summary>Dispose
        /// Lets the current object dispose
        ///
        /// Exceptions:
        ///  ObjectDisposedException
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed || IsDisposing)
                throw new ObjectDisposedException("StreamController");

            lock (_lock)
            {
                IsDisposing = true;

                if (Reader != null)
                {
                    Reader.Close(); Reader = null;
                }

                if (Writer != null)
                {
                    Writer.Close(); Writer = null;
                }
                Buffer = null;

                IsDisposing = false;
                IsDisposed = true;
            }
        }
    }
}