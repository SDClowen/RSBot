using RSBot.Pk2.IO;
using RSBot.Pk2.Security;
using RSBot.Pk2.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RSBot.Pk2
{
    public class PK2Archive : IDisposable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposing; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; set; }

        /// <summary>
        /// Gets or sets the header of the PK2 archive.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public PK2Header Header { get; set; }

        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<PK2Block> Blocks { get; set; }

        /// <summary>
        /// Gets or sets the path of the PK2 archive.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PK2Archive"/> is loaded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if loaded; otherwise, <c>false</c>.
        /// </value>
        public bool Loaded { get; private set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public PK2Config Config { get; private set; }

        /// <summary>
        /// The files.
        /// </summary>
        public List<PK2File> Files => _files;

        /// <summary>
        /// The files.
        /// </summary>
        private List<PK2File> _files;

        /// <summary>
        /// The directories.
        /// </summary>
        private List<PK2Directory> _directories;

        /// <summary>
        /// The file adapter
        /// </summary>
        private FileAdapter _fileAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Archive"/> class.
        /// The key is set to the isro standard encryption key.
        /// Do not provide any baseKey, if you wish to use the default base key for the archive.
        /// </summary>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="BlowfishSecurityException"></exception>
        /// <exception cref="InvalidHeaderException"></exception>
        public PK2Archive(string path, PK2Config config = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            //Initialize default config
            if (config == null)
                config = PK2Config.GetDefault();

            //assign the config to this instance
            Config = config;

            //Create file reader...
            _fileAdapter = new FileAdapter(path);
            Path = path;

            //Read header...
            Header = new PK2Header(_fileAdapter.ReadData(0, 256));

            if (Header.Encrypted)
            {
                var blowfishKey = BlowfishUtilities.GenerateFinalBlowfishKey(Config.Key, Config.BaseKey);
                var blowfish = new Blowfish();
                blowfish.Initialize(blowfishKey);
                BlowfishUtilities.SetBlowfish(blowfish);

                var tempChecksum =
                    BlowfishUtilities.GetBlowfish().Encode(Encoding.ASCII.GetBytes("Joymax Pak File"));

                //Check if the security checksum equals the generated checksum
                if (tempChecksum[0] != Header.SecurityChecksum[0]
                    || tempChecksum[1] != Header.SecurityChecksum[1]
                    || tempChecksum[2] != Header.SecurityChecksum[2])
                    throw new BlowfishSecurityException(Config.Key);
            }

            switch (Config.Mode)
            {
                case PK2Mode.IndexBlocks:
                    Blocks = new List<PK2Block>();
                    ReadBlockAt(256);
                    break;

                case PK2Mode.Index:
                    _files = new List<PK2File>();
                    _directories = new List<PK2Directory>();

                    ReadBlockAt(256, new PK2Directory(_fileAdapter));
                    break;
            }

            Loaded = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PK2Archive"/> class.
        /// </summary>
        ~PK2Archive()
        {
            if (!IsDisposing && !IsDisposed)
                Dispose();
        }

        /// <summary>
        /// Reads the block.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="currentDirectory">The current directory.</param>
        private void ReadBlockAt(ulong position, PK2Directory currentDirectory = null)
        {
            var currentBlockBuffer = _fileAdapter.ReadData((long)position, 2560);
            var currentBlock = new PK2Block(_fileAdapter, currentBlockBuffer, position);

            //Read the subfolder chain
            //The folder "." and ".." are required if you which to use "free-browsing" mode, without reading the whole index at once
            foreach (var pk2Entry in currentBlock.Entries.Where(entry => !entry.Name.StartsWith(".") && entry.Position > 0))
            {
                switch (pk2Entry.Type)
                {
                    case PK2EntryType.Directory:
                        if (Config.Mode == PK2Mode.Index)
                        {
                            var subDirectory = new PK2Directory(_fileAdapter, pk2Entry, currentDirectory);
                            _directories.Add(subDirectory);
                            ReadBlockAt(pk2Entry.Position, subDirectory);
                        }
                        else
                            ReadBlockAt(pk2Entry.Position);

                        break;

                    case PK2EntryType.File:
                        if (Config.Mode == PK2Mode.Index)
                            _files.Add(new PK2File(_fileAdapter, pk2Entry, currentDirectory));
                        break;
                }
            }

            //Check if the chain continues at another position
            if (currentBlock.Entries[19].NextChain > 0)
                ReadBlockAt(currentBlock.Entries[19].NextChain, currentDirectory);

            if (Config.Mode == PK2Mode.IndexBlocks)
                Blocks.Add(currentBlock);
        }

        /// <summary>
        /// Files the name exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool FileNameExists(string name)
        {
            return _files.FirstOrDefault(file => file.Name == name) != null;
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="absolutePath">if set to <c>true</c> [absolute path].</param>
        /// <returns></returns>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">The method GetFile() is only available in Index-Mode</exception>
        public PK2File GetFile(string path, bool absolutePath = false)
        {
            if (!Loaded)
                throw new PK2NotLoadedException();

            if (Config.Mode != PK2Mode.Index)
                throw new InvalidOperationException("The method GetFile() is only available in Index-Mode");

            return absolutePath
                ? _files.FirstOrDefault(file => file.Path.ToLowerInvariant() == path.ToLowerInvariant())
                : _files.Where(file => file.Name.ToLowerInvariant() == path.ToLowerInvariant()).OrderByDescending(file => file.CreateTime).FirstOrDefault();
        }

        /// <summary>
        /// Returns a value indicating if the specified file exists
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public bool FileExists(string path)
        {
            return GetFile(path) != null;
        }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">The method GetDirectory() is only available in Index-Mode</exception>
        public PK2Directory GetDirectory(string path)
        {
            if (!Loaded)
                throw new PK2NotLoadedException();

            if (Config.Mode != PK2Mode.Index)
                throw new InvalidOperationException("The method GetDirectory() is only available in Index-Mode");

            return _directories.FirstOrDefault(directory => directory.Path == path);
        }

        /// <summary>
        /// Gets the directories.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns></returns>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">The method GetFile() is only available in Index-Mode</exception>
        public PK2Directory[] GetDirectories(string path, bool recursive)
        {
            if (!Loaded)
                throw new PK2NotLoadedException();

            if (Config.Mode != PK2Mode.Index)
                throw new InvalidOperationException("The method GetDirectories() is only available in Index-Mode");

            return recursive ? _directories.Where(directory => directory.Path.StartsWith(path)).ToArray() : _directories.Where(directory => directory.Path == path).ToArray();
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns></returns>
        /// <exception cref="PK2NotLoadedException"></exception>
        /// <exception cref="System.InvalidOperationException">The method GetFiles() is only available in Index-Mode</exception>
        public PK2File[] GetFiles(string path, bool recursive)
        {
            if (!Loaded)
                throw new PK2NotLoadedException();

            if (Config.Mode != PK2Mode.Index)
                throw new InvalidOperationException("The method GetFiles() is only available in Index-Mode");

            return recursive ? _files.Where(file => file.Path.StartsWith(path)).ToArray() : _files.Where(file => file.Path == path).ToArray();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">PK2Archive</exception>
        public void Dispose()
        {
            if (IsDisposed || IsDisposing)
                throw new ObjectDisposedException("PK2Archive");

            IsDisposing = true;

            BlowfishUtilities.SetBlowfish(null);

            Header = null;
            Config = null;
            Blocks = null;
            Loaded = false;
            _directories = null;
            _files = null;
            _fileAdapter = null;

            IsDisposing = false;
            IsDisposed = true;
        }
    }
}