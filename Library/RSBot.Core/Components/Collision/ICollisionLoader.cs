using System.Collections.Generic;

namespace RSBot.Core.Components.Collision;

internal interface ICollisionLoader
{
    List<Line> GetCollisions(int regionId);
}
