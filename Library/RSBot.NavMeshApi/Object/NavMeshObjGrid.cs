using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Helper;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi.Object;

public class NavMeshObjGrid
{
    private readonly NavMeshObj _obj;

    private NavMeshObjGridTile[] _tiles;

    public Vector2 Origin { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public RectangleF Rectangle { get; set; }

    public NavMeshObjGrid(NavMeshObj obj)
    {
        _obj = obj;
    }

    public NavMeshObjGridTile this[int index]
    {
        get
        {
            return _tiles[index];
        }
    }

    public NavMeshObjGridTile this[int x, int y]
    {
        get
        {
            if (x < 0 || x >= this.Width || y < 0 || y >= this.Height)
                return null;

            return _tiles[(y * this.Width) + x];
        }
    }

    public NavMeshObjGridTile this[Vector2 vPos]
    {
        get
        {
            var tileX = (int)((vPos.X - this.Origin.X) / NavMeshObjGridTile.Width);
            var tileY = (int)((vPos.Y - this.Origin.Y) / NavMeshObjGridTile.Height);
            return this[tileX, tileY];
        }
    }

    internal void Load(NavMeshReader reader)
    {
        this.Origin = reader.ReadVector2();
        this.Width = reader.ReadInt32();
        this.Height = reader.ReadInt32();
        this.Rectangle = new RectangleF(this.Origin.X, this.Origin.Y, this.Width * NavMeshObjGridTile.Width, this.Height * NavMeshObjGridTile.Height);

        var tileCount = reader.ReadInt32();
        _tiles = new NavMeshObjGridTile[tileCount];

        for (int i = 0; i < tileCount; i++)
        {
            var tile = new NavMeshObjGridTile(this, i);

            var tileGlobalEdgeCount = reader.ReadInt32();
            for (int ii = 0; ii < tileGlobalEdgeCount; ii++)
            {
                var index = reader.ReadInt16();
                if (index >= _obj.GlobalEdges.Count || index < 0)
                {
                    Debug.WriteLine($"Odd GlobalEdgeIndex '{index}' (max is {_obj.GlobalEdges.Count - 1}) in NavMeshObjGridTile {tile}");
                    continue;
                }
                tile.AddGlobalEdge(_obj.GlobalEdges[index]);
            }

            _tiles[i] = tile;
        }
    }

    internal (int X, int Y) GetTileOffset(Vector2 p)
    {
        var tileOffset = (p - this.Origin) / NavMeshObjGridTile.Size;
        tileOffset.X = tileOffset.X.Clamp(0, this.Width - 1);
        tileOffset.Y = tileOffset.Y.Clamp(0, this.Height - 1);
        return ((int)tileOffset.X, (int)tileOffset.Y);
    }
}