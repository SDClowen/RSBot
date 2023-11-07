using System.Drawing;
using System.Numerics;
using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Edges;
using RSBot.NavMeshApi.Terrain;

namespace RSBot.Map.Renderer;

internal class NavMeshRenderer
{
    private record NavMeshObjRenderConfig(bool DrawInternalEdges, bool DrawGlobalEdges, Pen Color);
    private record NavMeshTerrainRenderConfig(bool DrawInternalEdges, bool DrawGlobalEdges, bool DrawCells, Pen Color);

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
        var terrainConfig = new NavMeshTerrainRenderConfig(true, true, true, Pens.Blue);
        var objConfig = new NavMeshObjRenderConfig(true, true, Pens.Red);

        if (navMesh is NavMeshTerrain terrain)
        {
            DrawNavMeshTerrain(terrain, terrainConfig);

            foreach (var navMeshObjInst in terrain.Instances)
                DrawNavMeshInstObj(terrain.Region, navMeshObjInst, objConfig);
        }
    }

    private void DrawNavMeshInstObj(NavMeshApi.Mathematics.Region region, NavMeshInst instObj, NavMeshObjRenderConfig config)
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

                var positionA = GetWorldPosition(region, posA);
                var positionB = GetWorldPosition(region, posB);

                DrawLine(positionA, positionB, config.Color);
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

                var positionA = GetWorldPosition(region, posA);
                var positionB = GetWorldPosition(region, posB);
                
                DrawLine(positionA, positionB, config.Color);
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
                    DrawEdge(terrain.Region, internalEdge, config.Color);

            }
        }

        if (config.DrawGlobalEdges)
        {
            foreach (var globalEdge in terrain.GlobalEdges)
            {
                if (globalEdge.IsBlocked)
                    DrawEdge(terrain.Region, globalEdge, config.Color);
            }
        }

        if (config.DrawCells)
        {
            foreach (var cell in terrain.Cells)
            {
                foreach (var cellEdge in cell.Edges)
                {
                    if (cellEdge.IsBlocked)
                        DrawEdge(terrain.Region, cellEdge, config.Color);
                }
            }
        }
    }

    private void DrawEdge(NavMeshApi.Mathematics.Region region, NavMeshEdge edge, Pen color)
    {
        var posA = GetWorldPosition(region, edge.Line.Min);
        var posB = GetWorldPosition(region, edge.Line.Max);

        DrawLine(posA, posB, color);
    }

    private void DrawLine(Position source, Position destination, Pen color)
    {
        //Skip too far away?
        //var distanceToPositionA = source.DistanceToPlayer();
        //var distanceToPositionB = destination.DistanceToPlayer();
        //if (distanceToPositionA > 150 || distanceToPositionB > 150)
        //    return;

        var srcX = GetMapX(source);
        var srcY = GetMapY(source);
        var destinationX = GetMapX(destination);
        var destinationY = GetMapY(destination);

        _graphics.DrawLine(color, srcX, srcY, destinationX, destinationY);
    }

    private Position GetWorldPosition(NavMeshApi.Mathematics.Region region, Vector3 localPosition)
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