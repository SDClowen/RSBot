using System.Collections.Generic;
using System.Linq;

namespace RSBot.Pk2.Types
{
    public class PK2BlockCollection
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<PK2Block> Blocks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2BlockCollection"/> class.
        /// </summary>
        public PK2BlockCollection()
        {
            Blocks = new List<PK2Block>();
        }

        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns></returns>
        public PK2Entry[] GetEntries()
        {
            return Blocks.SelectMany(block => block.Entries).ToArray();
        }
    }
}