using System.Diagnostics;
using NavMeshApi;
using RSBot.Core.Objects;

namespace RSBot.Core.Components.Collision.NavMesh
{
    public class NavMeshCollisionManager
    {
        public static Region CenterRegion;
        public static NavMeshApi.NavMesh[] LoadedNavMeshes = new NavMeshApi.NavMesh[9];

        public NavMeshCollisionManager()
        {
        }

        public static void LoadNavMeshes(Region center)
        {
            CenterRegion = center;
            

        }
    }
}
