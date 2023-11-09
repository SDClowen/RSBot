using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Dungeon;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Terrain;

using System.Drawing;
using System.Numerics;

namespace RSBot.Map.Renderer;

internal class NavMeshRenderer
{
    private record NavMeshObjRenderConfig(bool DrawInternalEdges, bool DrawGlobalEdges, Pen Color);
    private record NavMeshTerrainRenderConfig(bool DrawInternalEdges, bool DrawGlobalEdges, Pen Color);

    private const float Scale = 256 / 192.0f;

    private readonly Graphics _graphics;
    private readonly int _canvasWidth;
    private readonly int _canvasHeight;

    public NavMeshRenderer(Graphics graphics, int canvasWidth, int canvasHeight)
    {
        _graphics = graphics;
        _canvasWidth = canvasWidth;
        _canvasHeight = canvasHeight;
    }

    public void Render(NavMesh navMesh)
    {
        var terrainConfig = new NavMeshTerrainRenderConfig(true, true, Pens.Red);
        var objConfig = new NavMeshObjRenderConfig(true, true, Pens.Red);

        if (navMesh is NavMeshTerrain terrain)
        {
            this.DrawNavMeshTerrain(terrain, terrainConfig);
            foreach (var navMeshObjInst in terrain.Instances)
                this.DrawNavMeshInstObj(terrain.Region, navMeshObjInst, objConfig);
        }
        else if (navMesh is NavMeshDungeon dungeon)
            this.DrawNavMeshDungeon(dungeon);

    }

    private void DrawNavMeshDungeon(NavMeshDungeon dungeon)
    {
        //ToDO Further dungeon investigations!
    }

    private void DrawNavMeshInstObj(NavMeshApi.Mathematics.RID region, NavMeshInst instObj, NavMeshObjRenderConfig config)
    {
        var transformedPositions = new Vector3[instObj.NavMeshObj.Vertices.Length];
        for (var iVertex = 0; iVertex < instObj.NavMeshObj.Vertices.Length; iVertex++)
        {
            var transformed = Vector3.Transform(instObj.NavMeshObj.Vertices[iVertex].Position, instObj.LocalToWorld);

            transformedPositions[iVertex] = transformed;
        }

        if (config.DrawGlobalEdges)
        {
            foreach (var globalEdge in instObj.NavMeshObj.GlobalEdges)
            {
                if (!globalEdge.IsBlocked)
                    continue;

                var posA = transformedPositions[globalEdge.Vertex0.Index];
                var posB = transformedPositions[globalEdge.Vertex1.Index];

                var positionA = this.GetWorldPosition(region, posA);
                var positionB = this.GetWorldPosition(region, posB);

                this.DrawLine(positionA, positionB, config.Color);
            }
        }

        if (config.DrawInternalEdges)
        {
            foreach (var internalEdge in instObj.NavMeshObj.InternalEdges)
            {
                if (!internalEdge.IsBlocked)
                    continue;

                var posA = transformedPositions[internalEdge.Vertex0.Index];
                var posB = transformedPositions[internalEdge.Vertex1.Index];

                var positionA = this.GetWorldPosition(region, posA);
                var positionB = this.GetWorldPosition(region, posB);

                this.DrawLine(positionA, positionB, config.Color);
            }
        }
    }

    private void DrawNavMeshTerrain(NavMeshTerrain terrain, NavMeshTerrainRenderConfig config)
    {

        if (config.DrawInternalEdges)
        {
            foreach (var internalEdge in terrain.InternalEdges)
            {
                if (internalEdge.IsBlocked)
                    this.DrawEdge(terrain.Region, internalEdge, config.Color);

            }
        }

        if (config.DrawGlobalEdges)
        {
            foreach (var globalEdge in terrain.GlobalEdges)
            {
                if (globalEdge.IsBlocked)
                    this.DrawEdge(terrain.Region, globalEdge, config.Color);
            }
        }
    }

    private void DrawEdge(NavMeshApi.Mathematics.RID region, NavMeshEdge edge, Pen color)
    {
        var posA = this.GetWorldPosition(region, edge.Line.Min);
        var posB = this.GetWorldPosition(region, edge.Line.Max);

        this.DrawLine(posA, posB, color);
    }

    private void DrawLine(Position source, Position destination, Pen color)
    {
        //Skip too far away?
        var distanceToPositionA = source.DistanceToPlayer();
        var distanceToPositionB = destination.DistanceToPlayer();
        if (distanceToPositionA > 150 || distanceToPositionB > 150)
            return;

        if (source.DistanceTo(destination) > 150)
            return;

        var srcX = this.GetMapX(source);
        var srcY = this.GetMapY(source);
        var destinationX = this.GetMapX(destination);
        var destinationY = this.GetMapY(destination);

        //Leaves viewscope?
        if (srcX > _canvasWidth) srcX = _canvasWidth;
        if (srcY > _canvasHeight) srcY = _canvasHeight;
        if (srcX < 0) srcX = 0;
        if (srcY < 0) srcY = 0;
        if (destinationX > _canvasWidth) destinationX = _canvasWidth;
        if (destinationY > _canvasHeight) destinationY = _canvasHeight;
        if (destinationY < 0) destinationY = 0;
        if (destinationX < 0) destinationX = 0;

        _graphics.DrawLine(color, srcX, srcY, destinationX, destinationY);
    }

    private Position GetWorldPosition(NavMeshApi.Mathematics.RID region, Vector3 localPosition)
    {
        return new Position(region.X, region.Z, localPosition.X, localPosition.Z, localPosition.Y);
    }

    private float GetMapX(Position gamePosition)
    {
        //Player is center
        return _canvasWidth / 2f + (gamePosition.X - Game.Player.Movement.Source.X) * Scale;
    }

    private float GetMapY(Position gamePosition)
    {
        //Player is center
        return _canvasHeight / 2f + (gamePosition.Y - Game.Player.Movement.Source.Y) * Scale * -1.0f;
    }
}