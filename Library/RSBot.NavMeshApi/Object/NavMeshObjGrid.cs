using System.Diagnostics;
using System.Numerics;
using RSBot.NavMeshApi.Extensions;
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
        get { return _tiles[index]; }
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
        this.Rectangle = new RectangleF(
            this.Origin.X,
            this.Origin.Y,
            this.Width * NavMeshObjGridTile.Width,
            this.Height * NavMeshObjGridTile.Height
        );

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
                    Debug.WriteLine(
                        $"Odd GlobalEdgeIndex '{index}' (max is {_obj.GlobalEdges.Count - 1}) in NavMeshObjGridTile {tile}"
                    );
                    continue;
                }
                tile.AddGlobalEdge(_obj.GlobalEdges[index]);
            }

            _tiles[i] = tile;
        }
    }

    public void Raytrace(LineF line, Action<NavMeshObjGridTile> callback)
    {
        var v0 = (line.Min.ToVector2() - this.Origin) / NavMeshObjGridTile.Size;
        var v1 = (line.Max.ToVector2() - this.Origin) / NavMeshObjGridTile.Size;
        this.Raytrace(
            v0,
            v1,
            (tileX, tileY) =>
            {
                var tile = this[tileX, tileY];
                if (tile != null)
                    callback(tile);
            }
        );
    }

    private void Raytrace(Vector2 v0, Vector2 v1, Action<int, int> callback)
    {
        var dx = MathF.Abs(v1.X - v0.X);
        var dy = MathF.Abs(v1.Y - v0.Y);

        if (dx == 0 && dy == 0)
            return; // v0 is equal to v1

        int srcTileX = MathHelper.FloorToInt(v0.X);
        int srcTileY = MathHelper.FloorToInt(v0.Y);

        int n = 1;
        int stepX = MathF.Sign(v1.X - v0.X);
        int stepY = MathF.Sign(v1.Y - v0.Y);

        float error;
        if (v1.X > v0.X)
        {
            n += MathHelper.FloorToInt(v1.X) - srcTileX;
            error = (MathF.Floor(v0.X) + 1 - v0.X) * dy;
        }
        else
        {
            n += srcTileX - MathHelper.FloorToInt(v1.X);
            error = (v0.X - MathF.Floor(v0.X)) * dy;
        }

        if (v1.Y > v0.Y)
        {
            n += MathHelper.FloorToInt(v1.Y) - srcTileY;
            error -= (MathF.Floor(v0.Y) + 1 - v0.Y) * dx;
        }
        else
        {
            n += srcTileY - MathHelper.FloorToInt(v1.Y);
            error -= (v0.Y - MathF.Floor(v0.Y)) * dx;
        }

        while (n > 0)
        {
            //this.DrawAt(tileX, tileY);
            callback(srcTileX, srcTileY);

            if (error > 0)
            {
                srcTileY += stepY;
                error -= dx;
            }
            else
            {
                srcTileX += stepX;
                error += dy;
            }

            --n;
        }
    }
}
