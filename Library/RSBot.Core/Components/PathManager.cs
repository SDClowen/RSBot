using System;
using RSBot.Core.Components.Collision.Calculated;
using RSBot.Core.Event;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using RSBot.Core.Objects;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.Topology;
using TriangleNet.Meshing;
using TriangleNet.Smoothing;
using TriangleNet.Meshing.Algorithm;
using Point = TriangleNet.Geometry.Point;
using Region = RSBot.Core.Objects.Region;

namespace RSBot.Core.Components;

public static class PathManager
{
    //A TODO: Change to false
    public static bool Enabled = true;

    /// <summary>
    /// Gets a value indicating whether this instance is initialized.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
    /// </value>
    public static bool IsInitialized { get; private set; }

    /// <summary>
    /// Gets a value indicating whether this instance is updating.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is updating; otherwise, <c>false</c>.
    /// </value>
    public static bool IsUpdating { get; private set; }

    /// <summary>
    /// Gets the center region identifier.
    /// </summary>
    /// <value>
    /// The center region identifier.
    /// </value>
    public static ushort CenterRegionId { get; private set; }

    /// <summary>
    /// Gets the active walk grids.
    /// </summary>
    /// <value>
    /// The active walk grids.
    /// </value>
    public static List<CalculatedWalkGrid> ActiveWalkGrids { get; private set; }

    public static Triangle[] Triangles { get; private set; }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        EventManager.SubscribeEvent("OnUpdateCollisions", OnUpdateCollisions);

        IsInitialized = true;
    }

    /// <summary>
    /// Called when [update collisions].
    /// </summary>
    private static void OnUpdateCollisions()
    {
        Update(CollisionManager.CenterRegionId);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has active collision meshes.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has active meshes; otherwise, <c>false</c>.
    /// </value>
    public static bool HasActiveGrids
    {
        get
        {
            if (!IsInitialized || !Enabled)
                return false;

            if (ActiveWalkGrids == null)
                return false;

            if (IsUpdating)
                return false;

            return ActiveWalkGrids.Count > 0;
        }
    }

    /// <summary>
    /// Updates to the specified center region identifier.
    /// </summary>
    /// <param name="centerRegionId">The center region identifier.</param>
    private static void Update(ushort centerRegionId)
    {
        if (!Enabled)
            return;

        IsUpdating = true;
        CenterRegionId = centerRegionId;
        ActiveWalkGrids = new List<CalculatedWalkGrid>(9);

        var centerRegion = new Region(centerRegionId);
        var surroundedBy = Region.GetSurroundingRegions(centerRegion.XSector, centerRegion.YSector);

        foreach (var region in surroundedBy)
        {
            var mesh = CollisionManager.GetCollisionMesh(region.Id);

            if (!mesh.HasValue)
                continue;

            var calculatedMesh = new CalculatedWalkGrid(mesh.Value);

            ActiveWalkGrids.Add(calculatedMesh);
        }

        Triangles = TriangulateWalkMesh();

        IsUpdating = false;

        Log.Debug($"[PathManager] Updated to {ActiveWalkGrids.Count} active walk grids");
    }

    private static Contour GetBoundingBox()
    {
            var regionTopLeft = ActiveWalkGrids[0].RegionId;
            var regionTopRight = ActiveWalkGrids[2].RegionId;
            var regionBottomLeft = ActiveWalkGrids[6].RegionId;
            var regionBottomRight = ActiveWalkGrids[8].RegionId;

            var positionTL = new Position(0, 0, 0f, regionTopLeft);
            var positionTR = new Position(1920, 0, 0f, regionTopRight);
            var positionBL = new Position(0, 1920, 0f, regionBottomLeft);
            var positionBR = new Position(192, 1920, 0f, regionBottomRight);

            var points = new List<Vertex>();
            points.Add(new(positionTL.XCoordinate, positionTL.YCoordinate));
            points.Add(new(positionTR.XCoordinate, positionTR.YCoordinate));
            points.Add(new(positionBL.XCoordinate, positionBL.YCoordinate));
            points.Add(new(positionBR.XCoordinate, positionBR.YCoordinate));

            return new Contour(points);
    }

    private static Triangle[] TriangulateWalkMesh()
    {
        var polygon = new Polygon();
        polygon.Add(GetBoundingBox());

        foreach (var grid in ActiveWalkGrids)
        {
            foreach (var obj in grid.Objects)
            {
                //polygon.Points.AddRange(obj.GetOutlineVertices());
                //var verticies = obj.GetOutlineVertices();
                ////polygon.Points.AddRange(verticies);

                //var contour = new Contour(verticies, 0, true);
                polygon.Segments.AddRange(obj.GetSegments());
                //polygon.Add(contour, true);
            }
        }

        //var quality = new QualityOptions() { MinimumAngle = 30.0 };

        polygon.Bounds();

        try
        {
            //var quality = new QualityOptions()
            //{
            //    MinimumAngle = 25.0,
            //    VariableArea = true
            //};
            var options = new ConstraintOptions() { ConformingDelaunay = true, SegmentSplitting = 2 };
            var mesh = polygon.Triangulate(options);
            var smoother = new SimpleSmoother();

            // Smooth mesh.
            //smoother.Smooth(mesh, 25, .05);

            if (mesh.Triangles is not TrianglePool triangles)
                return Array.Empty<Triangle>();

            var result = triangles.ToArray();

            return result;
        }
        catch (Exception e)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        }

        return Array.Empty<Triangle>();
    }
}