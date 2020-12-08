using RSBot.Pk2.IO;
using System.Collections.Generic;
using System.IO;

namespace RSBot.Pk2.Types
{
    public class PK2File : PK2Entry
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path => Name != "" ? Parent + "/" + Name : "";

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Parent { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2File" /> class.
        /// </summary>
        /// <param name="fileAdapter"></param>
        public PK2File(FileAdapter fileAdapter) : base(fileAdapter) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2File" /> class.
        /// </summary>
        /// <param name="fileAdapter">The file adapter.</param>
        /// <param name="entry">The entry.</param>
        /// <param name="parent">The parent.</param>
        public PK2File(FileAdapter fileAdapter, PK2Entry entry, string parent) : base(fileAdapter)
        {
            Parent = parent;

            Index = entry.Index;
            Block = entry.Block;
            AccessTime = entry.AccessTime;
            CreateTime = entry.CreateTime;
            ModifyTime = entry.ModifyTime;
            Name = entry.Name;
            NextChain = entry.NextChain;
            Position = entry.Position;
            Size = entry.Size;

            Type = PK2EntryType.File;
        }

        /// <summary>
        /// Reads all text of this file.
        /// </summary>
        /// <returns></returns>
        public string ReadAllText()
        {
            var buffer = GetData();
            if (buffer == null)
                return null;

            using (var reader = new StreamReader(GetStream()))
            {
                return reader.ReadToEnd();
            }
        }

        public IEnumerable<string> ReadAllLines()
        {
            using (var reader = new StreamReader(GetStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// Gets the stream of this file.
        /// </summary>
        /// <returns></returns>
        public Stream GetStream()
        {
            return new MemoryStream(GetData());
        }
    }
}