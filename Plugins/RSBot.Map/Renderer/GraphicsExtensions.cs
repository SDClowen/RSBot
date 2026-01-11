using RSBot.NavMeshApi.Mathematics;
using SkiaSharp;

namespace RSBot.Map.Renderer;


public static class GraphicsExtensions
{
    public static void DrawLine(this SKCanvas c, SKPaint p, LineF l) =>
        c.DrawLine(l.Min.X, l.Min.Z, l.Max.X, l.Max.Z, p);

    public static void DrawCircle(this SKCanvas c, SKPaint p, CircleF circle) =>
        c.DrawCircle(circle.Position.X, circle.Position.Y, circle.Radius, p);

    public static void FillTriangleF(this SKCanvas c, int id, TriangleF t)
    {
        using SKPaint p = new()
        {
            Color = id.ToSKColor(),
            IsStroke = false,
            IsAntialias = true
        };

        using var path = new SKPath();
        path.MoveTo(t.P1.X, t.P1.Z);
        path.LineTo(t.P2.X, t.P2.Z);
        path.LineTo(t.P3.X, t.P3.Z);
        path.Close();
        c.DrawPath(path, p);
    }

    public static void FillRectangleF(this SKCanvas c, SKPaint p, NavMeshApi.Mathematics.RectangleF r)
    {
        using var path = new SKPath();
        path.MoveTo(r.TopLeft.X, 1920 - r.TopLeft.Y);
        path.LineTo(r.TopRight.X, 1920 - r.TopRight.Y);
        path.LineTo(r.BottomRight.X, 1920 - r.BottomRight.Y);
        path.LineTo(r.BottomLeft.X, 1920 - r.BottomLeft.Y);
        path.Close();
        c.DrawPath(path, p);
    }
}
