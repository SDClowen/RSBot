using RSBot.Core.Extensions;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Dungeon;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;
using RSBot.NavMeshApi.Terrain;
using SDUI;
using SDUI.Controls;
using SDUI.Helpers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using Vortice.Mathematics;

namespace RSBot.Map.Renderer;

public partial class NavMeshRenderer : DoubleBufferedControl
{
    private bool _isDragging;
    private Point _dragPosition;

    private NavMeshTransform _transform;
    private NavMeshTransform _mouseTransform;
    private NavMeshRaycastHit? _hit = null;

    private readonly Font _font;
    private readonly Font _smallFont;

    private float _zoom = 1.0f;

    private bool _drawRegionId = true;
    private bool _drawRegionBorder = true;
    private bool _drawTerrainGlobalEdges = true;
    private bool _drawTerrainInternalEdges = true;
    private bool _drawObjectGlobalEdges = true;
    private bool _drawObjectInternalEdges = true;
    private bool _drawObjectGround = true;

    private bool _drawTerrainCellID = false;
    private bool _drawTerrainGlobalEdgeID = false;
    private bool _drawTerrainInternalEdgeID = false;
    private bool _drawObjectCellID = false;
    private bool _drawObjectGlobalEdgeID = false;
    private bool _drawObjectInternalEdgeID = false;

    private bool _raycastVisualizer = false;

    public NavMeshRenderer()
    {
        this.InitializeComponent();

        _font = new Font("Arial", 64f);
        _smallFont = new Font("Arial", 32f);
        _transform = new NavMeshTransform(Vector3.Zero);
        _mouseTransform = new NavMeshTransform(Vector3.Zero);

        this.MouseWheel += NavMeshRenderer_MouseWheel;
        this.MouseMove += NavMeshRenderer_MouseMove;
        this.MouseDown += NavMeshRenderer_MouseDown;
        this.MouseUp += NavMeshRenderer_MouseUp;
        this.Paint += NavMeshRenderer_Paint;

    }

    public void Update(NavMeshTransform transform)
    {
        if (_transform != null && transform.Position.Distance(_transform.Position) < 1)
            return;

        _transform = transform;
        _mouseTransform = new NavMeshTransform(Vector3.Zero);

        this.Invalidate();
    }

    private void NavMeshRenderer_Paint(object sender, SKPaintSurfaceEventArgs e)
    {
        if (_transform?.Region == 0u)
            return;

        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Black);

        var scaleX = Width / 1920f * _zoom;
        var scaleY = Height / 1920f * _zoom;

        var worldMatrix =
            SKMatrix.CreateScale(scaleX, scaleY)
            .PostConcat(SKMatrix.CreateTranslation(
                960f - _transform.Offset.X,
                960f - _transform.Offset.Z));

        canvas.Concat(worldMatrix);

        var set = new HashSet<int>();

        if (_transform.Region.IsDungeon)
        {
            if (!NavMeshManager.TryGetNavMeshDungeon(_transform.Region, out var dungeon))
                return;

            DrawNavMeshDungeon(set, canvas, dungeon);
        }
        else
        {
            for (int rz = _transform.Region.Z - 1; rz < _transform.Region.Z + 2; rz++)
                for (int rx = _transform.Region.X - 1; rx < _transform.Region.X + 2; rx++)
                {
                    var rid = new RID((byte)rx, (byte)rz);
                    if (!NavMeshManager.TryGetNavMeshTerrain(rid, out var terrain))
                        continue;

                    foreach (var edge in terrain.GlobalEdges)
                        edge.Link();

                    DrawTerrain(set, canvas, terrain);
                }
        }

        using var redCirclePaint = new SKPaint()
        {
            Color = SKColors.Red,
            IsStroke = false,
            IsAntialias = true
        };

        canvas.DrawCircle(
            _transform.Offset.X,
            _transform.Offset.Z,
            5,
            redCirclePaint);

        var localMouse = RID.Transform(_mouseTransform.Offset, _transform.Region, _mouseTransform.Region);

        if (_raycastVisualizer)
        {
            using var whitePaint = new SKPaint()
            {
                Color = SKColors.White,
                IsStroke = true,
                StrokeWidth = 1f,
                IsAntialias = true
            };

            canvas.DrawLine(
                _transform.Offset.X,
                _transform.Offset.Z,
                localMouse.X,
                localMouse.Z,
                whitePaint);

            if (_hit != null)
            {
                using var redPaint = new SKPaint()
                {
                    Color = SKColors.Red,
                    IsStroke = true,
                    StrokeWidth = 1f,
                    IsAntialias = true
                };

                var localHit = RID.Transform(_hit.Position, _transform.Region, _hit.Region);
                canvas.DrawLine(
                    _transform.Offset.X,
                    _transform.Offset.Z,
                    localHit.X,
                    localHit.Z,
                    redPaint);
            }
        }

        canvas.SetMatrix(SKMatrix.Identity);


        TextRenderingHelper.DrawText(canvas, $"Player: {_transform}", 0, 12, SKColors.White);
        TextRenderingHelper.DrawText(canvas, $"Cursor: {_mouseTransform}", 0, 24, SKColors.White);

        if (_hit != null)
            TextRenderingHelper.DrawText(canvas, $"Hit: {_hit}", 0, 36, SKColors.Red);
    }

    private void DrawNavMeshDungeon(HashSet<int> set, SKCanvas c, NavMeshDungeon dungeon)
    {
        if (_transform.Instance is not NavMeshInstBlock currentBlock)
            return;

        foreach (var block in dungeon.Blocks.Where(b => b.FloorIndex == currentBlock.FloorIndex))
        {
            var m =
                SKMatrix.CreateRotation(
                    block.Yaw,
                    block.LocalPosition.X,
                    block.LocalPosition.Z)
                .PostConcat(SKMatrix.CreateTranslation(
                    block.LocalPosition.X,
                    block.LocalPosition.Z));

            c.Concat(m);

            DrawNavMeshObj(c, block.ID, block.NavMeshObj);

            c.SetMatrix(SKMatrix.Identity);

            set.Add(block.ID);


            using var redPaint = new SKPaint()
            {
                Color = SKColors.Red,
                IsStroke = true,
                StrokeWidth = 1f,
                IsAntialias = true
            };

            foreach (var obj in block.ObjectList)
                c.DrawCircle(obj.Circle.Position.X, obj.Circle.Position.Y, obj.Circle.Radius, redPaint);
        }
    }

    private void DrawTerrain(HashSet<int> set, SKCanvas c, NavMeshTerrain terrain)
    {
        var dx = (terrain.Region.X - _transform.Region.X) * RID.Width;
        var dz = (terrain.Region.Z - _transform.Region.Z) * RID.Length;

        c.Concat(SKMatrix.CreateTranslation(dx, dz));

        if (_drawRegionBorder)
        {
            using var magentaPaint = new SKPaint()
            {
                Color = SKColors.Magenta,
                IsStroke = true,
                StrokeWidth = 1f,
                IsAntialias = true
            };

            c.DrawRect(0, 0, 1919, 1919, magentaPaint);
        }

        if (_drawTerrainGlobalEdges)
            foreach (var e in terrain.GlobalEdges)
                c.DrawLine(e.Flag.ToStroke(), e.Line);

        foreach (var obj in terrain.Instances)
        {
            if (set.Contains(obj.WorldUID))
                continue;

            var m =
                SKMatrix.CreateRotation(
                    obj.Yaw,
                    obj.LocalPosition.X,
                    obj.LocalPosition.Z)
                .PostConcat(SKMatrix.CreateTranslation(
                    obj.LocalPosition.X,
                    obj.LocalPosition.Z));

            c.Concat(m);
            DrawNavMeshObj(c, obj.WorldUID, obj.NavMeshObj);
            c.SetMatrix(SKMatrix.Identity);

            set.Add(obj.WorldUID);
        }
    }
    private void DrawNavMeshObj(SKCanvas c, int id, NavMeshObj obj)
    {
        if (_drawObjectGround)
        {
            foreach (var cell in obj.Cells)
                c.FillTriangleF(id, cell.Triangle);
        }

        if (_drawObjectGlobalEdges)
            foreach (var e in obj.GlobalEdges)
                c.DrawLine(e.Flag.ToStroke(), e.Line);
    }



    private void NavMeshRenderer_MouseWheel(object sender, MouseEventArgs e)
    {
        if (_raycastVisualizer)
            return;

        _zoom += e.Delta * 0.001f;

        if (_zoom < 0.5)
            _zoom = 0.5f;

        if (_zoom > 1.5)
            _zoom = 2;

        this.Invalidate();
    }

    private void NavMeshRenderer_MouseMove(object sender, MouseEventArgs e)
    {
        if (_isDragging)
        {
            var dx = _dragPosition.X - e.X;
            var dy = _dragPosition.Y - e.Y;
            _dragPosition = e.Location;

            _transform.Offset += new Vector3(dx * (RID.Width / this.Width), 0, dy * (RID.Length / this.Height));
            _transform.Normalize();
            _hit = null;
        }

        _mouseTransform.Region = _transform.Region;
        _mouseTransform.Offset = new Vector3(
            _transform.Offset.X - 960.0f + (e.X * (RID.Width / this.Width)),
            0.0f,
            _transform.Offset.Z - 960.0f + (e.Y * (RID.Length / this.Height))
        );
        _mouseTransform.Normalize();

        NavMeshManager.ResolveCellAndHeight(_transform);
        NavMeshManager.ResolveCellAndHeight(_mouseTransform);

        this.Invalidate();
    }

    private void NavMeshRenderer_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _raycastVisualizer)
        {
            try
            {
                this.Raycast();
            }
            catch (Exception ex)
            {
                RSBot.Core.Log.Fatal(ex);
            }
        }

        if (e.Button == MouseButtons.Right)
            contextRenderSettings.Show(this, e.Location);

        if (e.Button == MouseButtons.Middle)
        {
            _dragPosition = e.Location;
            _isDragging = true;
        }
    }

    private void NavMeshRenderer_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Middle)
            _isDragging = false;
    }

    private void Raycast()
    {
        _hit = null;
        var source = new NavMeshTransform(_transform);
        var destination = new NavMeshTransform(_mouseTransform);

        if (
            !NavMeshManager.Raycast(source, destination, NavMeshRaycastType.Move, out NavMeshRaycastHit? hit)
            && hit != null
        )
        {
            _hit = hit;
            return;
        }
    }

    private void regionIDToolStripMenuItem_CheckedChange(object sender, EventArgs e)
    {
        _drawRegionId = regionIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void regionBorderToolStripMenuItem_CheckedChange(object sender, EventArgs e)
    {
        _drawRegionBorder = regionBorderToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void globalEdgesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        _drawTerrainGlobalEdges = terrainGlobalEdgesToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void internalEdgesToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        _drawTerrainInternalEdges = terrainInternalEdgesToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void globalEdgesToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
    {
        _drawObjectGlobalEdges = objectGlobalEdgesToolStripMenuItem1.Checked;
        this.Invalidate();
    }

    private void internalEdgesToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
    {
        _drawObjectInternalEdges = objectInternalEdgesToolStripMenuItem1.Checked;
        this.Invalidate();
    }

    private void groundToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        _drawObjectGround = objectGroundToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void terrainCellIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawTerrainCellID = terrainCellIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void terrainGlobalEdgeIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawTerrainGlobalEdgeID = terrainGlobalEdgeIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void terrainInternalEdgeIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawTerrainInternalEdgeID = terrainInternalEdgeIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void objectCellIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawObjectCellID = objectCellIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void objectGlobalEdgeIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawObjectGlobalEdgeID = objectGlobalEdgeIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void objectInternalEdgeIDToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _drawObjectInternalEdgeID = objectInternalEdgeIDToolStripMenuItem.Checked;
        this.Invalidate();
    }

    private void raycastMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        _raycastVisualizer = raycastMenuItem.Checked;
        _zoom = 1;

        this.Invalidate();
    }
}
