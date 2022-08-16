using System.Collections.Generic;

namespace RSBot.Core.Components.Collision;

/// <summary>
/// Default collision loader.
/// Used when no other loader is available. 
/// </summary>
internal class NoCollisionLoader : ICollisionLoader
{
    public List<Line> GetCollisions(int regionId)
    {
        return new List<Line>();
    }
}
