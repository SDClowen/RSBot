using RSBot.Pk2.IO;
using RSBot.Pk2.IO.Stream;
using RSBot.Pk2.Security;
using System;
using System.IO;
using System.Threading;

namespace RSBot.Pk2.Types
{
    public class PK2Entry
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public PK2EntryType Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the access time.
        /// </summary>
        /// <value>
        /// The access time.
        /// </value>
        public DateTime AccessTime { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the modify time.
        /// </summary>
        /// <value>
        /// The modify time.
        /// </value>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public ulong Position { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public uint Size { get; set; }

        /// <summary>
        /// Gets or sets the next chain.
        /// </summary>
        /// <value>
        /// The next chain.
        /// </value>
        public ulong NextChain { get; set; }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public byte Index { get; set; }

        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        /// <value>
        /// The block.
        /// </value>
        public PK2Block Block { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public ulong Offset => Block.Offset + ((ulong)Index * 128);

        #region Fields

        private FileAdapter _fileAdapter;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Entry"/> class.
        /// </summary>
        public PK2Entry(FileAdapter fileAdapter)
        {
            _fileAdapter = fileAdapter;

            Type = PK2EntryType.Empty;
            Name = "";
            AccessTime = DateTime.Now;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Entry" /> class.
        /// </summary>
        /// <param name="fileAdatper"></param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="block">The block.</param>
        /// <param name="index">The index of the entry inside the block.</param>
        /// <exception cref="InvalidEntryException"></exception>
        public PK2Entry(FileAdapter fileAdatper, byte[] buffer, PK2Block block, byte index)
        {
            _fileAdapter = fileAdatper;

            Index = index;
            Block = block;

            using (var streamWorker = new StreamWorker(buffer, StreamOperation.Read))
            {
                try
                {
                    Type = (PK2EntryType)streamWorker.ReadByte();
                    Name = streamWorker.ReadString(81).Trim('\0');
                    AccessTime = DateTime.FromFileTimeUtc(streamWorker.ReadLong());
                    CreateTime = DateTime.FromFileTimeUtc(streamWorker.ReadLong());
                    ModifyTime = DateTime.FromFileTimeUtc(streamWorker.ReadLong());
                    Position = streamWorker.ReadULong();
                    Size = streamWorker.ReadUInt();
                    NextChain = streamWorker.ReadULong();
                    streamWorker.ReadByteArray(2); //Padding to reach 128 bytes length
                }
                catch
                {
                    throw new InvalidEntryException(buffer);
                }
            }
        }

        /// <summary>
        /// Returns this instance of PK2Entry as byte[] which can be used to be written back to the PK2 archive
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            var result = new byte[128];
            using (var stream = new StreamWorker(result, StreamOperation.Write))
            {
                stream.WriteByte(Type);
                stream.WriteString(Name);
                stream.WriteByteArray(new byte[81 - Name.Length]); //Write the name padding
                stream.WriteLong(AccessTime.Ticks);
                stream.WriteLong(CreateTime.Ticks);
                stream.WriteLong(ModifyTime.Ticks);
                stream.WriteULong(Position);
                stream.WriteUInt(Size);
                stream.WriteULong(NextChain);
                stream.WriteByteArray(new byte[2]); //Padding to reach 128 bytes length
            }

            //If we have an encypted archive we have to encrypt this, too
            if (BlowfishUtilities.GetBlowfish() != null)
                result = BlowfishUtilities.GetBlowfish().Encode(result);

            return result;
        }

        /// <summary>
        /// Saves the entry back to the PK2.
        /// </summary>
        /// <exception cref="PK2NotLoadedException"></exception>
        public void Save()
        {
            if (_fileAdapter == null)
                throw new PK2NotLoadedException();

            _fileAdapter.WriteData(ToByteArray(), (long)Offset);
        }

        /// <summary>
        /// Renames the specified new name.
        /// </summary>
        /// <param name="newName">The new name.</param>
        public void Rename(string newName)
        {
            Name = newName;
            Save();
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {
            Type = PK2EntryType.Empty;
            Save();
        }

        /// <summary>
        /// Extracts the file to the specified destination
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">Directories can not be extracted.</exception>
        public void Extract(string destination)
        {
            if (_fileAdapter == null)
                throw new PK2NotLoadedException();

            if (Type != PK2EntryType.File)
                throw new InvalidOperationException("Directories can not be extracted."); //TODO: find something better

            using (var stream = new FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write))
            {
                while (!stream.CanWrite)
                    Thread.Sleep(1);

                var buffer = _fileAdapter.ReadData((long)Position, (int)Size);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">It's impossible to read data from a directory or from a deleted file.</exception>
        public byte[] GetData()
        {
            if (_fileAdapter == null)
                throw new PK2NotLoadedException();

            if (Type != PK2EntryType.File)
                throw new InvalidOperationException("It's impossible to read data from a directory or from a deleted file."); //TODO: find something better

            return _fileAdapter.ReadData((long)Position, (int)Size);
        }

        /// <summary>
        /// Gets the child block if the entry is a directory.
        /// </summary>
        /// <returns></returns>
        public PK2Block GetChildBlock()
        {
            return new PK2Block(_fileAdapter, _fileAdapter.ReadData((long)Position, 2560), Position);
        }
    }
}

// <summary>
// Structure of the PK2 Entry
// {
//     1       Byte Type
//     81      Bytes Name
//     8       Byte AccessTime
//     8       Bytes CreateTime
//     8       Bytes ModifyTime
//     8       Bytes Position
//     4       Bytes Size
//     8       Bytes NextChain
//     2       Bytes Padding
// }
// </summary>