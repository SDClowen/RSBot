using System;
using System.IO;
using System.Text;
using RSBot.Core.Extensions;

namespace RSBot.Core.Network
{
    public class Packet : IDisposable
    {
        private BinaryWriter _writer;
        private BinaryReader _reader;

        private byte[] _readerBytes;
        private readonly object _lock;

        /// <summary>
        /// Gets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Packet"/> is encrypted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if encrypted; otherwise, <c>false</c>.
        /// </value>
        public bool Encrypted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Packet"/> is massive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if massive; otherwise, <c>false</c>.
        /// </value>
        public bool Massive { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Packet"/> is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if locked; otherwise, <c>false</c>.
        /// </value>
        public bool Locked;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Packet"/> using opcode.
        /// </summary>
        public string HexCode => $"0x{Opcode:X4}";

        /// <summary>
        /// Gets the reader position.
        /// </summary>
        /// <value>
        /// The reader position.
        /// </value>
        /// <exception cref="PacketException">Cannot read position from an unlocked Packet.</exception>
        public int ReaderPosition
        {
            get
            {
                //lock (_lock)
                {
                    if (!Locked)
                        throw new Exception("Cannot read position from an unlocked Packet.");

                    return (int)(_reader.BaseStream.Length - _reader.BaseStream.Position);
                }
            }
        }

        /// <summary>
        /// Gets the reader lenght.
        /// </summary>
        /// <value>
        /// The reader lenght.
        /// </value>
        /// <exception cref="PacketException">Cannot read lenght from an unlocked Packet.</exception>
        public int Length
        {
            get
            {
                //lock (_lock)
                {
                    if (!Locked)
                        return (int)(_writer.BaseStream.Length);

                    return (int)(_reader.BaseStream.Length);
                }
            }
        }

        /// <summary>
        /// Gets the reader remain.
        /// </summary>
        /// <value>
        /// The reader remain.
        /// </value>
        /// <exception cref="PacketException">Cannot read remain from an unlocked Packet.</exception>
        public int Remaining
        {
            get
            {
                //lock (_lock)
                {
                    if (!Locked)
                        throw new Exception("Cannot read remain from an unlocked Packet.");

                    return (int)(_reader.BaseStream.Length - _reader.BaseStream.Position);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="rhs">The RHS.</param>
        public Packet(Packet rhs)
        {
            lock (rhs._lock)
            {
                _lock = new object();

                Opcode = rhs.Opcode;
                Encrypted = rhs.Encrypted;
                Massive = rhs.Massive;
                Locked = rhs.Locked;

                if (!Locked)
                {
                    _writer = new(new MemoryStream());
                    _reader = null;
                    _readerBytes = null;
                    _writer.Write(rhs._writer.GetSnapshot());
                }
                else
                {
                    _writer = null;
                    _readerBytes = rhs._readerBytes;
                    _reader = new BinaryReader(new MemoryStream(_readerBytes));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        public Packet(ushort opcode)
        {
            Opcode = opcode;
            Encrypted = false;
            Massive = false;

            _lock = new object();
            _writer = new BinaryWriter(new MemoryStream());
            _reader = null;
            _readerBytes = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        /// <param name="encrypted">if set to <c>true</c> [encrypted].</param>
        public Packet(ushort opcode, bool encrypted)
        {
            Opcode = opcode;
            Encrypted = encrypted;
            Massive = false;

            _lock = new object();
            _writer = new(new MemoryStream());
            _reader = null;
            _readerBytes = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        /// <param name="encrypted">if set to <c>true</c> [encrypted].</param>
        /// <param name="massive">if set to <c>true</c> [massive].</param>
        /// <exception cref="PacketException">Packets cannot both be massive and encrypted!</exception>
        public Packet(ushort opcode, bool encrypted, bool massive)
        {
            if (encrypted && massive)
                throw new Exception("Packets cannot both be massive and encrypted!");

            Opcode = opcode;
            Encrypted = encrypted;
            Massive = massive;

            _lock = new object();
            _writer = new(new MemoryStream());
            _reader = null;
            _readerBytes = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        /// <param name="encrypted">if set to <c>true</c> [encrypted].</param>
        /// <param name="massive">if set to <c>true</c> [massive].</param>
        /// <param name="bytes">The bytes.</param>
        /// <exception cref="PacketException">Packets cannot both be massive and encrypted!</exception>
        public Packet(ushort opcode, bool encrypted, bool massive, byte[] bytes)
        {
            if (encrypted && massive)
                throw new Exception("Packets cannot both be massive and encrypted!");

            Opcode = opcode;
            Encrypted = encrypted;
            Massive = massive;

            _lock = new object();
            _writer = new(new MemoryStream());
            _writer.Write(bytes);
            _reader = null;
            _readerBytes = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Packet"/> class.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        /// <param name="encrypted">if set to <c>true</c> [encrypted].</param>
        /// <param name="massive">if set to <c>true</c> [massive].</param>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        /// <exception cref="PacketException">Packets cannot both be massive and encrypted!</exception>
        public Packet(
            ushort opcode,
            bool encrypted,
            bool massive,
            byte[] bytes,
            int offset,
            int length,
            bool locked = false
        )
        {
            if (encrypted && massive)
                throw new Exception("Packets cannot both be massive and encrypted!");

            Opcode = opcode;
            Encrypted = encrypted;
            Massive = massive;

            _lock = new object();
            _writer = new(new MemoryStream());
            _writer.Write(bytes, offset, length);
            _reader = null;
            _readerBytes = null;

            if (locked)
                Lock();
        }

        /// <summary>
        /// Locks the writer and stores everything into the reader.
        /// </summary>
        public void Lock()
        {
            //lock (_lock)
            {
                if (Locked)
                    return;

                _readerBytes = _writer.GetSnapshot();
                _reader = new BinaryReader(new MemoryStream(_readerBytes));
                _writer.Close();
                _writer = null;

                Locked = true;
            }
        }

        /// <summary>
        /// Opens a the writer and loads the reader bytes into the writer
        /// </summary>
        public void Unlock()
        {
            //lock (_lock)
            {
                if (!Locked)
                    return;

                _writer = new(new MemoryStream());
                _writer.Write(_readerBytes);
                _reader.Close();
                _reader = null;
                _readerBytes = null;

                Locked = false;
            }
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            //lock (_lock)
            return Locked ? _readerBytes : _writer.GetSnapshot();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (Locked)
                return _readerBytes != null
                    ? "\n0x" + Opcode.ToString("X2") + "\n " + _readerBytes.HexDump() + "\n"
                    : "Empty";

            //Get the bytes from the writer
            //lock (_lock)
            {
                return _writer.GetSnapshot().HexDump();
            }
        }

        /// <summary>
        /// Seeks the read.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="orgin">The orgin.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot SeekRead on an unlocked Packet.</exception>
        public long SeekRead(long offset, SeekOrigin orgin)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot SeekRead on an unlocked Packet.");

                return _reader.BaseStream.Seek(offset, orgin);
            }
        }

        /// <summary>
        /// Reads the bool.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public bool ReadBool()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadBoolean();
            }
        }

        /// <summary>
        /// Reads the byte.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public byte ReadByte()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadByte();
            }
        }

        /// <summary>
        /// Reads the char.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public char ReadChar()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadChar();
            }
        }

        /// <summary>
        /// Reads the s byte.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public sbyte ReadSByte()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadSByte();
            }
        }

        /// <summary>
        /// Reads the ushort.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public ushort ReadUShort()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadUInt16();
            }
        }

        /// <summary>
        /// Reads the short.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public short ReadShort()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadInt16();
            }
        }

        /// <summary>
        /// Reads the uint.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public uint ReadUInt()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadUInt32();
            }
        }

        /// <summary>
        /// Reads the int.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public int ReadInt()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadInt32();
            }
        }

        /// <summary>
        /// Reads the ulong.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public ulong ReadULong()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadUInt64();
            }
        }

        /// <summary>
        /// Reads the long.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public long ReadLong()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadInt64();
            }
        }

        /// <summary>
        /// Reads the float.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public float ReadFloat()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadSingle();
            }
        }

        /// <summary>
        /// Reads the double.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public double ReadDouble()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadDouble();
            }
        }

        /// <summary>
        /// Reads the double.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public DateTime ReadDateTime()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return new DateTime(
                    ReadShort(), // Day
                    ReadShort(), // Month
                    ReadShort(), // Year
                    ReadShort(), // Hour
                    ReadShort(), // Minute
                    ReadShort(), // Second
                    ReadInt()
                ); // MiliSecond
            }
        }

        /// <summary>
        /// Reads the ASCII.
        /// </summary>
        /// <param name="codepage">The codepage.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public string ReadString(int codepage = 1254)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var length = _reader.ReadUInt16();
                var bytes = _reader.ReadBytes(length);

                if (Game.ClientType == GameClientType.RuSro)
                    codepage = 1251;

                if (Game.ClientType == GameClientType.Chinese || Game.ClientType == GameClientType.Taiwan)
                    codepage = 950;

                if (Game.ClientType == GameClientType.Korean)
                    codepage = 949;

                if (Game.ClientType == GameClientType.Japanese)
                    codepage = 932;

                if (Game.ClientType == GameClientType.Global
                    || Game.ClientType == GameClientType.VTC_Game
                    || Game.ClientType == GameClientType.Turkey)
                    codepage = 65001;

                return Encoding.GetEncoding(codepage).GetString(bytes);
            }
        }

        /// <summary>
        /// Reads the unicode.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public string ReadUnicode()
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var length = _reader.ReadUInt16();
                var bytes = _reader.ReadBytes(length * 2);

                return Encoding.Unicode.GetString(bytes);
            }
        }

        /// <summary>
        /// Reads the bool array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public bool[] ReadBoolArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new bool[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadBoolean();

                return values;
            }
        }

        /// <summary>
        /// Reads the byte array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public byte[] ReadBytes(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                return _reader.ReadBytes(count);
            }
        }

        /// <summary>
        /// Reads the s byte array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public sbyte[] ReadSByteArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new sbyte[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadSByte();

                return values;
            }
        }

        /// <summary>
        /// Reads the u short array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public ushort[] ReadUShortArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new ushort[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadUInt16();

                return values;
            }
        }

        /// <summary>
        /// Reads the short array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public short[] ReadShortArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new short[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadInt16();

                return values;
            }
        }

        /// <summary>
        /// Reads the u int array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public uint[] ReadUIntArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new uint[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadUInt32();

                return values;
            }
        }

        /// <summary>
        /// Reads the int array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public int[] ReadIntArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new int[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadInt32();

                return values;
            }
        }

        /// <summary>
        /// Reads the u long array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public ulong[] ReadULongArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new ulong[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadUInt64();

                return values;
            }
        }

        /// <summary>
        /// Reads the long array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public long[] ReadLongArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new long[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadInt64();

                return values;
            }
        }

        /// <summary>
        /// Reads the float array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public float[] ReadFloatArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new float[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadSingle();

                return values;
            }
        }

        /// <summary>
        /// Reads the double array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public double[] ReadDoubleArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new Double[count];
                for (var x = 0; x < count; ++x)
                    values[x] = _reader.ReadDouble();

                return values;
            }
        }

        /// <summary>
        /// Reads the ASCII array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="codepage">The codepage.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public string[] ReadStringArray(int count, int codepage = 1254)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new string[count];
                for (var x = 0; x < count; ++x)
                    values[x] = ReadString();

                return values;
            }
        }

        /// <summary>
        /// Reads the unicode array.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot Read from an unlocked Packet.</exception>
        public string[] ReadUnicodeArray(int count)
        {
            //lock (_lock)
            {
                if (!Locked)
                    throw new Exception("Cannot Read from an unlocked Packet.");

                var values = new string[count];
                for (var x = 0; x < count; ++x)
                    values[x] = ReadUnicode();

                return values;
            }
        }

        /// <summary>
        /// Seeks the write.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="orgin">The orgin.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot SeekWrite on a locked Packet.</exception>
        public long SeekWrite(long offset, SeekOrigin orgin)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot SeekWrite on a locked Packet.");

                return _writer.BaseStream.Seek(offset, orgin);
            }
        }

        /// <summary>
        /// Seeks the write.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="orgin">The orgin.</param>
        /// <returns></returns>
        /// <exception cref="PacketException">Cannot SeekWrite on a locked Packet.</exception>
        public Packet Offset(long offset)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot SeekWrite on a locked Packet.");

                _writer.BaseStream.Position = offset;

                return this;
            }
        }

        /// <summary>
        /// Writes the bool.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBool(bool value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteByte(byte value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        public void WriteDateTime(DateTime dateTime)
        {
            WriteShort(dateTime.Day);
            WriteShort(dateTime.Month);
            WriteShort(dateTime.Year);
            WriteShort(dateTime.Hour);
            WriteShort(dateTime.Minute);
            WriteShort(dateTime.Second);
            WriteInt(dateTime.Millisecond);
        }

        /// <summary>
        /// Writes the s byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteSByte(sbyte value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u short.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUShort(ushort value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the short.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteShort(short value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUInt(uint value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteInt(int value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the u long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteULong(ulong value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteLong(long value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteFloat(float value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteDouble(double value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(value);
            }
        }

        /// <summary>
        /// Writes the ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="codePage">The Codepage.</param>
        public void WriteString(string value, int codePage = 1254)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                if (value == null)
                    value = string.Empty;

                if (Game.ClientType == GameClientType.RuSro)
                    codePage = 1251;

                if (Game.ClientType == GameClientType.Chinese || Game.ClientType == GameClientType.Taiwan)
                    codePage = 950;

                if (Game.ClientType == GameClientType.Korean)
                    codePage = 949;

                if (Game.ClientType == GameClientType.Japanese)
                    codePage = 932;

                if (Game.ClientType == GameClientType.Global
                    || Game.ClientType == GameClientType.VTC_Game
                    || Game.ClientType == GameClientType.Turkey)
                    codePage = 65001;

                var bytes = Encoding.GetEncoding(codePage).GetBytes(value);
                _writer.Write((ushort)bytes.Length);
                _writer.Write(bytes);
            }
        }

        /// <summary>
        /// Writes the unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUnicode(string value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                if (value == null)
                    value = string.Empty;

                var bytes = Encoding.Unicode.GetBytes(value);

                _writer.Write((ushort)value.Length);
                _writer.Write(bytes);
            }
        }

        /// <summary>
        /// Writes the bool.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBool(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((byte)(Convert.ToUInt64(value) & 0xFF));
            }
        }

        /// <summary>
        /// Writes the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteByte(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((byte)(Convert.ToUInt64(value) & 0xFF));
            }
        }

        /// <summary>
        /// Writes the s byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteSByte(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((sbyte)(Convert.ToInt64(value) & 0xFF));
            }
        }

        /// <summary>
        /// Writes the u short.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUShort(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((ushort)(Convert.ToUInt64(value) & 0xFFFF));
            }
        }

        /// <summary>
        /// Writes the short.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteShort(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((ushort)(Convert.ToInt64(value) & 0xFFFF));
            }
        }

        /// <summary>
        /// Writes the uint.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUInt(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((uint)(Convert.ToUInt64(value) & 0xFFFFFFFF));
            }
        }

        /// <summary>
        /// Writes the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteInt(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write((int)(Convert.ToInt64(value) & 0xFFFFFFFF));
            }
        }

        /// <summary>
        /// Writes the u long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteULong(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(Convert.ToUInt64(value));
            }
        }

        /// <summary>
        /// Writes the long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteLong(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(Convert.ToInt64(value));
            }
        }

        /// <summary>
        /// Writes the float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteFloat(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(Convert.ToSingle(value));
            }
        }

        /// <summary>
        /// Writes the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteDouble(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(Convert.ToDouble(value));
            }
        }

        /// <summary>
        /// Writes the ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        public void WriteString(object value)
        {
            WriteString(value.ToString());
        }

        /// <summary>
        /// Writes the unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUnicode(object value)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                var bytes = Encoding.Unicode.GetBytes(value.ToString());

                _writer.Write((ushort)value.ToString().Length);
                _writer.Write(bytes);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBoolArray(bool[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBytes(byte[] values)
        {
            if (Locked)
                throw new Exception("Cannot Write to a locked Packet.");

            _writer.Write(values);
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBytes(byte[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                _writer.Write(values, index, count);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUShortArray(ushort[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteShortArray(short[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUIntArray(uint[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteIntArray(int[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteULongArray(ulong[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteLongArray(long[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteFloatArray(float[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteDoubleArray(double[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    _writer.Write(values[x]);
            }
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteStringArray(string[] values, int codepage = 1254)
        {
            WriteStringArray(values, 0, values.Length, codepage);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="codepage">The codepage.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteStringArray(string[] values, int index, int count, int codepage = 1254)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteString(values[x], codepage);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUnicodeArray(string[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteUnicode(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBoolArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteBool(values[x]);
            }
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteBytes(object[] values)
        {
            WriteBytes(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the byte array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteBytes(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteByte(values[x]);
            }
        }

        /// <summary>
        /// Writes the sbyte array.
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteSByteArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteSByte(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUShortArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteUShort(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteShortArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteShort(values[x]);
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
        /// Writes the uint array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUIntArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteUInt(values[x]);
            }
        }

        /// <summary>
        /// Writes the int array.
        /// </summary>
        /// <param name="values">The values.</param>
        public void WriteIntArray(object[] values)
        {
            WriteIntArray(values, 0, values.Length);
        }

        /// <summary>
        /// Writes the int array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteIntArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteInt(values[x]);
            }
        }

        /// <summary>
        /// Writes the ulong array.
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteULongArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteULong(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteLongArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteLong(values[x]);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteFloatArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteFloat(values[x]);
            }
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
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteDoubleArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteDouble(values[x]);
            }
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="codepage">The codepage.</param>
        public void WriteStringArray(object[] values, int codepage = 1254)
        {
            WriteStringArray(values, 0, values.Length, codepage);
        }

        /// <summary>
        /// Writes the ASCII array.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="codepage">The codepage.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteStringArray(object[] values, int index, int count, int codepage = 1254)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteString(values[x].ToString(), codepage);
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
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <exception cref="PacketException">Cannot Write to a locked Packet.</exception>
        public void WriteUnicodeArray(object[] values, int index, int count)
        {
            //lock (_lock)
            {
                if (Locked)
                    throw new Exception("Cannot Write to a locked Packet.");

                for (var x = index; x < index + count; ++x)
                    WriteUnicode(values[x].ToString());
            }
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _writer?.Dispose();
                    _reader?.Dispose();
                    _readerBytes = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Packet()
        {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
}
