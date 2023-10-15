using System.Collections.Generic;
using System.Linq;

namespace RSBot.Pk2.Types;

public class PK2BlockCollection : List<PK2Block>
{
    /// <summary>
    /// Gets the entries.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<PK2Entry> GetEntries()
    {
        return this.SelectMany(block => block.Entries);
    }
}