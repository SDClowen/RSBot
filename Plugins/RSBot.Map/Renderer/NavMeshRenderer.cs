using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using RSBot.Core.Extensions;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Dungeon;
using RSBot.NavMeshApi.Mathematics;
using RSBot.NavMeshApi.Object;
using RSBot.NavMeshApi.Terrain;
using SDUI.Controls;

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

        if (this.DesignMode)
            return;

        _font = new Font("Arial", 64f);
        _smallFont = new Font("Arial", 32f);
        _transform = new NavMeshTransform(Vector3.Zero);
        _mouseTransform = new NavMeshTransform(Vector3.Zero);
    }

    public void Update(NavMeshTransform transform)
    {
        if (_transform != null && transform.Position.Distance(_transform.Position) < 1)
            return;

        _transform = transform;
        _mouseTransform = new NavMeshTransform(Vector3.Zero);

        this.Invalidate();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.Clear(SDUI.ColorScheme.BackColor);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_transform?.Region == 0u)
            return;

        var g = e.Graphics;

        var matrix = new Matrix();

        matrix.Scale(this.Width / 1920.0f * _zoom, this.Height / 1920.0f * _zoom);
        matrix.Translate(960.0f - _transform.Offset.X, 960 - _transform.Offset.Z);
        g.MultiplyTransform(matrix);

        var set = new HashSet<int>();

        if (_transform.Region.IsDungeon)
        {
            if (!NavMeshManager.TryGetNavMeshDungeon(_transform.Region, out var dungeon))
                return;

            this.DrawNavMeshDungeon(set, g, dungeon);
        }
        else
        {
            for (int rz = _transform.Region.Z - 1; rz < _transform.Region.Z + 2; rz++)
            {
                for (int rx = _transform.Region.X - 1; rx < _transform.Region.X + 2; rx++)
                {
                    var rid = new RID((byte)rx, (byte)rz);
                    if (!NavMeshManager.TryGetNavMeshTerrain(rid, out var terrain))
                        continue;

                    foreach (var edge in terrain.GlobalEdges)
                        edge.Link();

                    this.DrawTerrain(set, g, terrain);
                }
            }
        }

        g.FillEllipse(Brushes.Red, _transform.Offset.X - 5, _transform.Offset.Z - 5, 10, 10);

        var localMouseOffset = RID.Transform(_mouseTransform.Offset, _transform.Region, _mouseTransform.Region);
        if (_raycastVisualizer)
        {
            g.DrawLine(Pens.White, _transform.Offset.X, _transform.Offset.Z, localMouseOffset.X, localMouseOffset.Z);
            if (_hit != null)
            {
                var localHitOffset = RID.Transform(_hit.Position, _transform.Region, _hit.Region);
                g.DrawLine(Pens.Red, _transform.Offset.X, _transform.Offset.Z, localHitOffset.X, localHitOffset.Z);
            }
        }

        matrix.Invert();
        g.MultiplyTransform(matrix);

        var textBrush = new SolidBrush(SDUI.ColorScheme.ForeColor);

        g.DrawString($"Player: {_transform}", DefaultFont, textBrush, 0, 0);
        g.DrawString($"Cursor: {_mouseTransform}", DefaultFont, textBrush, 0, 12);
        if (_hit != null)
            g.DrawString($"Hit: {_hit}", DefaultFont, Brushes.Red, 0, 24);
    }

    private void DrawNavMeshDungeon(HashSet<int> set, Graphics g, NavMeshDungeon dungeon)
    {
        if (_transform.Instance is not NavMeshInstBlock currentBlock)
            return;

        foreach (var block in dungeon.Blocks.Where(b => b.FloorIndex == currentBlock.FloorIndex))
        {
            var blockMatrix = new Matrix();
            blockMatrix.RotateAt(block.Yaw * (180.0f / MathF.PI), block.LocalPosition.ToPointF());
            blockMatrix.Translate(block.LocalPosition.X, block.LocalPosition.Z);

            g.MultiplyTransform(blockMatrix);

            this.DrawNavMeshObj(g, block.ID, block.NavMeshObj);

            blockMatrix.Invert();
            g.MultiplyTransform(blockMatrix);

            set.Add(block.ID);

            foreach (var obj in block.ObjectList)
                g.DrawCircle(Pens.Red, obj.Circle);
        }
    }

    private void DrawTerrain(HashSet<int> set, Graphics g, NavMeshTerrain terrain)
    {
        var dx = (terrain.Region.X - _transform.Region.X) * RID.Width;
        var dz = (terrain.Region.Z - _transform.Region.Z) * RID.Length;

        var matrix = new Matrix();
        matrix.Translate(dx, dz);

        g.MultiplyTransform(matrix);

        if (_drawRegionBorder)
            g.DrawRectangle(Pens.Magenta, 0, 0, 1920 - 1, 1920 - 1);

        if (_drawTerrainCellID)
        {
            foreach (var cell in terrain.Cells)
                g.DrawString($"{cell}", _smallFont, Brushes.White, cell.RectangleF.Center.ToPointF());
        }

        if (_drawTerrainGlobalEdges)
        {
            foreach (var edge in terrain.GlobalEdges)
            {
                var pen = edge.Flag.ToPen();
                g.DrawLine(pen, edge.Line);

                if (_drawTerrainGlobalEdgeID)
                    g.DrawString($"{edge}", _smallFont, Brushes.White, edge.Line.Center.ToPointF());
            }
        }

        if (_drawTerrainInternalEdges)
        {
            foreach (var edge in terrain.InternalEdges)
            {
                var pen = edge.Flag.ToPen();
                g.DrawLine(pen, edge.Line);

                if (_drawTerrainInternalEdgeID)
                    g.DrawString($"{edge}", _smallFont, Brushes.White, edge.Line.Center.ToPointF());
            }
        }

        foreach (var obj in terrain.Instances)
        {
            if (set.Contains(obj.WorldUID))
                continue;

            var objMatrix = new Matrix();
            objMatrix.RotateAt(obj.Yaw * (180.0f / MathF.PI), obj.LocalPosition.ToPointF());
            objMatrix.Translate(obj.LocalPosition.X, obj.LocalPosition.Z);

            g.MultiplyTransform(objMatrix);

            this.DrawNavMeshObj(g, obj.WorldUID, obj.NavMeshObj);

            objMatrix.Invert();
            g.MultiplyTransform(objMatrix);

            set.Add(obj.WorldUID);
        }

        if (_drawRegionId)
            g.DrawString($"{terrain.Region}", _font, Brushes.White, 0, 0);

        matrix.Invert();
        g.MultiplyTransform(matrix);
    }

    private void DrawNavMeshObj(Graphics g, int id, NavMeshObj obj)
    {
        if (_drawObjectGround)
        {
            var brush = new SolidBrush(id.ToColor());
            foreach (var cell in obj.Cells)
            {
                g.FillTriangleF(brush, cell.Triangle);

                if (_drawObjectCellID)
                {
                    string label;
                    if (cell.EventZone == NavMeshEventZone.Empty)
                        label = $"{cell}";
                    else
                        label = $"{cell} [{obj.Events[cell.EventZone.Index]}, {cell.EventZone.Flag}]";
                    g.DrawString(label, _smallFont, Brushes.White, cell.Triangle.Center.ToPointF());
                }
            }
        }

        if (_drawObjectGlobalEdges)
        {
            foreach (var edge in obj.GlobalEdges)
            {
                g.DrawLine(edge.Flag.ToPen(), edge.Line);

                if (_drawObjectGlobalEdgeID)
                {
                    string label;
                    if (edge.EventZone == NavMeshEventZone.Empty)
                        label = $"{edge}";
                    else
                        label = $"{edge} [{obj.Events[edge.EventZone.Index]}, {edge.EventZone.Flag}]";
                    g.DrawString(label, _smallFont, Brushes.White, edge.Line.Center.ToPointF());
                }
            }
        }

        if (_drawObjectInternalEdges)
        {
            foreach (var edge in obj.InternalEdges)
            {
                g.DrawLine(edge.Flag.ToPen(), edge.Line);

                if (_drawObjectInternalEdgeID)
                {
                    string label;
                    if (edge.EventZone == NavMeshEventZone.Empty)
                        label = $"{edge}";
                    else
                        label = $"{edge} [{obj.Events[edge.EventZone.Index]}, {edge.EventZone.Flag}]";
                    g.DrawString(label, _smallFont, Brushes.White, edge.Line.Center.ToPointF());
                }
            }
        }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        if (_raycastVisualizer)
            return;

        _zoom += e.Delta * 0.001f;

        if (_zoom < 0.5)
            _zoom = 0.5f;

        if (_zoom > 1.5)
            _zoom = 2;

        this.Invalidate();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

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

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Left && _raycastVisualizer)
        {
            try
            {
                this.Raycast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

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
