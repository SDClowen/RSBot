using RSBot.FileSystem;
using RSBot.NavMeshApi;
using RSBot.NavMeshApi.Object;
using RSBot.NavMeshApi.Terrain;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace RSBot.NavMeshVisualizer;

public partial class NavMeshRenderer : UserControl
{
    private bool _isDragging;
    private Point _dragPosition;

    private NavMeshTransform _transform;
    private NavMeshTransform _mouseTransform;
    private NavMeshTransform? _hit = null;

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
    private bool _drawTerrainCellID = true;
    private bool _drawTerrainGlobalEdgeID = true;
    private bool _drawTerrainInternalEdgeID = true;
    private bool _drawObjectCellID = true;
    private bool _drawObjectGlobalEdgeID = true;
    private bool _drawObjectInternalEdgeID = true;

    public NavMeshRenderer()
    {
        this.InitializeComponent();

        if (this.DesignMode)
            return;

        var data = new PackFileSystem(Path.Combine("D:\\Games\\Silkroad_TestIn", "Data.pk2"), "169841");

        var item = data.GetFile("\\navmesh\\mapinfo.mfo");
        Debug.WriteLine(item.Path);

        NavMeshManager.Initialize(data);

        _transform = new NavMeshTransform(new NavMeshApi.Mathematics.Region(25000), new Vector3(960, 0, 960));
        _mouseTransform = new NavMeshTransform(Vector3.Zero);

        _font = new Font("Arial", 64f);
        _smallFont = new Font("Arial", 16f);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;

        var matrix = new Matrix();

        matrix.Scale(this.Width / 1920.0f, this.Height / 1920.0f);
        matrix.Translate(960.0f - _transform.Offset.X, 960 - _transform.Offset.Z);
        g.MultiplyTransform(matrix);

        var set = new HashSet<int>();

        for (int rz = _transform.Region.Z - 1; rz < _transform.Region.Z + 2; rz++)
        {
            for (int rx = _transform.Region.X - 1; rx < _transform.Region.X + 2; rx++)
            {
                var rid = new NavMeshApi.Mathematics.Region((byte)rx, (byte)rz);
                if (!NavMeshManager.TryGetNavMeshTerrain(rid, out var terrain))
                    return;

                this.DrawTerrain(set, g, terrain);
            }
        }

        var localMouseOffset = _mouseTransform.Offset;
        this.TransformToRegion(ref localMouseOffset, _transform.Region, _mouseTransform.Region);

        g.DrawLine(Pens.White, _transform.Offset.X, _transform.Offset.Z, localMouseOffset.X, localMouseOffset.Z);
        if (_hit != null)
        {
            var localHitOffset = _hit.Offset;
            this.TransformToRegion(ref localHitOffset, _transform.Region, _hit.Region);
            g.DrawLine(Pens.Red, _transform.Offset.X, _transform.Offset.Z, localHitOffset.X, localHitOffset.Z);
        }

        matrix.Invert();
        g.MultiplyTransform(matrix);

        g.DrawString($"Player: {_transform}", DefaultFont, Brushes.Black, 0, 0);
        g.DrawString($"Cursor: {_mouseTransform}", DefaultFont, Brushes.Black, 0, 12);
        if (_hit != null)
            g.DrawString($"Hit: {_mouseTransform}", DefaultFont, Brushes.Black, 0, 24);
    }

    private void TransformToRegion(ref Vector3 offset, NavMeshApi.Mathematics.Region sourceRegion, NavMeshApi.Mathematics.Region targetRegion)
    {
        if (sourceRegion != targetRegion)
        {
            var localX = offset.X + ((targetRegion.X - sourceRegion.X) * NavMeshApi.Mathematics.Region.Width);
            var localZ = offset.Z + ((targetRegion.Z - sourceRegion.Z) * NavMeshApi.Mathematics.Region.Length);

            offset = new Vector3(localX, 0, localZ);
        }
    }

    private void DrawTerrain(HashSet<int> set, Graphics g, NavMeshTerrain terrain)
    {
        var dx = (terrain.Region.X - _transform.Region.X) * NavMeshApi.Mathematics.Region.Width;
        var dz = (terrain.Region.Z - _transform.Region.Z) * NavMeshApi.Mathematics.Region.Length;

        var matrix = new Matrix();
        matrix.Translate(dx, dz);

        g.MultiplyTransform(matrix);

        if (_drawRegionBorder)
            g.DrawRectangle(Pens.Magenta, 0, 0, 1920 - 1, 1920 - 1);

        if (_drawTerrainCellID)
        {
            foreach (var cell in terrain.Cells)
                g.DrawString($"{cell}", _smallFont, Brushes.Black, cell.RectangleF.Center.ToPointF());
        }

        if (_drawTerrainGlobalEdges)
        {
            foreach (var edge in terrain.GlobalEdges)
            {
                var pen = edge.Flag.ToPen();
                g.DrawLine(pen, edge.Line);

                if (_drawTerrainGlobalEdgeID)
                    g.DrawString($"{edge}", _smallFont, Brushes.Black, edge.Line.Center.ToPointF());
            }
        }

        if (_drawTerrainInternalEdges)
        {
            foreach (var edge in terrain.InternalEdges)
            {
                var pen = edge.Flag.ToPen();
                g.DrawLine(pen, edge.Line);

                if (_drawTerrainInternalEdgeID)
                    g.DrawString($"{edge}", _smallFont, Brushes.Black, edge.Line.Center.ToPointF());
            }
        }

        foreach (var obj in terrain.Instances)
        {
            if (set.Contains(obj.WorldUID))
                continue;

            var objMatrix = new Matrix();
            objMatrix.RotateAt(obj.Yaw * (180.0f / MathF.PI), new PointF(obj.LocalPosition.X, obj.LocalPosition.Z));
            objMatrix.Translate(obj.LocalPosition.X, obj.LocalPosition.Z);

            g.MultiplyTransform(objMatrix);

            this.DrawNavMeshObj(g, obj.WorldUID, obj.NavMeshObj);

            objMatrix.Invert();
            g.MultiplyTransform(objMatrix);

            set.Add(obj.WorldUID);
        }

        if (_drawRegionId)
            g.DrawString($"{terrain.Region}", _font, Brushes.Black, 0, 0);

        matrix.Invert();
        g.MultiplyTransform(matrix);
    }

    private void DrawNavMeshObj(Graphics g, int id, NavMeshObj obj)
    {
        if (_drawObjectGround)
        {
            var brush = new SolidBrush(id.ToColor());
            foreach (var cell in obj.Cells)
                g.FillTriangleF(brush, cell.Triangle);
        }

        if (_drawObjectGlobalEdges)
        {
            foreach (var edge in obj.GlobalEdges)
                g.DrawLine(edge.Flag.ToPen(), edge.Line);
        }

        if (_drawObjectInternalEdges)
        {
            foreach (var edge in obj.InternalEdges)
            {
                g.DrawLine(edge.Flag.ToPen(), edge.Line);
            }
        }
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        _zoom += e.Delta * 0.001f;
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

            _transform.Offset += new Vector3(dx * (NavMeshApi.Mathematics.Region.Width / this.Width), 0, dy * (NavMeshApi.Mathematics.Region.Length / this.Height));
            _transform.Normalize();
            _hit = null;
        }

        _mouseTransform.Region = _transform.Region;
        _mouseTransform.Offset = new Vector3(_transform.Offset.X - 960.0f + (e.X * (NavMeshApi.Mathematics.Region.Width / this.Width)), 0.0f, _transform.Offset.Z - 960.0f + (e.Y * (NavMeshApi.Mathematics.Region.Length / this.Height)));
        _mouseTransform.Normalize();

        if (!NavMeshManager.ResolveCellAndHeight(_transform))
            return;

        if (!NavMeshManager.ResolveCellAndHeight(_mouseTransform))
            return;

        this.Invalidate();

    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button == MouseButtons.Left)
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
            contextMenuStrip1.Show(this, e.Location);

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
        var source = new NavMeshTransform(_transform);
        var destination = new NavMeshTransform(_mouseTransform);

        if (!NavMeshManager.Raycast(source, destination, NavMeshRaycastType.Move, out NavMeshRaycastHit? hit) && hit != null)
        {
            _hit = new NavMeshTransform(hit.Region, hit.Position);
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
}
