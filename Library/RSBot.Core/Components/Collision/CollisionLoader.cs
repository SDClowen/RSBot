using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RSBot.Core.Components.Collision
{
    internal class CollisionLoader
    {
        /// <summary>
        /// The collisions
        /// </summary>
        internal Dictionary<int, long> Index;

        #region Fields

        /// <summary>
        /// The map file path
        /// </summary>
        private readonly string _mapFilePath;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionLoader" /> class.
        /// </summary>
        /// <param name="mapFilePath">The map file path.</param>
        /// <param name="indexFilePath">The index file path.</param>
        public CollisionLoader(string mapFilePath, string indexFilePath)
        {
            _mapFilePath = mapFilePath;
            ReadIndex(indexFilePath);
        }

        /// <summary>
        /// Reads the index.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void ReadIndex(string filePath)
        {
            Index = new Dictionary<int, long>();
            using (var reader = new BinaryReader(File.OpenRead(filePath)))
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                    Index.Add(reader.ReadInt32(), reader.ReadInt64());
        }

        /// <summary>
        /// Gets the collisions.
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <returns></returns>
        public List<Line> GetCollisions(int regionId)
        {
            if (!Index.ContainsKey(regionId))
                return new List<Line>();

            var sectorCollisions = new List<Line>();

            using (var reader = new BinaryReader(File.OpenRead(_mapFilePath)))
            {
                reader.BaseStream.Position = Index[regionId];

                //Validate the data from the index
                var internalRegionId = reader.ReadInt32();
                if (internalRegionId != regionId)
                    return sectorCollisions; //No data found

                //Load terrain edges
                var terrainEdgeCount = reader.ReadInt32();
                for (var i = 0; i < terrainEdgeCount; i++)
                {
                    var line = new Line
                    {
                        Source = new Point(reader.ReadInt32(), reader.ReadInt32()),
                        Destination = new Point(reader.ReadInt32(), reader.ReadInt32())
                    };

                    sectorCollisions.Add(line);
                }

                //Load object edges
                var objectEdgeCount = reader.ReadInt32();
                for (var i = 0; i < objectEdgeCount; i++)
                {
                    var line = new Line
                    {
                        Source = new Point(reader.ReadInt32(), reader.ReadInt32()),
                        Destination = new Point(reader.ReadInt32(), reader.ReadInt32())
                    };

                    sectorCollisions.Add(line);
                }
            }

            return sectorCollisions;
        }
    }
}