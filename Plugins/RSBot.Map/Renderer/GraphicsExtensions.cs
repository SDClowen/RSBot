using System.Drawing;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.Map.Renderer;

public static class GraphicsExtensions
{
    public static void DrawLine(this Graphics g, Pen pen, LineF line) =>
        g.DrawLine(pen, line.Min.X, line.Min.Z, line.Max.X, line.Max.Z);

    public static void DrawCircle(this Graphics g, Pen pen, CircleF circle) =>
        g.DrawEllipse(
            pen,
            circle.Position.X - circle.Radius,
            circle.Position.Y - circle.Radius,
            circle.Radius * 2,
            circle.Radius * 2
        );

    public static void FillTriangleF(this Graphics g, Brush brush, TriangleF triangle) =>
        g.FillPolygon(
            brush,
            new PointF[]
            {
                new PointF(triangle.P1.X, triangle.P1.Z),
                new PointF(triangle.P2.X, triangle.P2.Z),
                new PointF(triangle.P3.X, triangle.P3.Z),
            }
        );

    public static void FillRectangleF(this Graphics g, Brush brush, NavMeshApi.Mathematics.RectangleF rectangle) =>
        g.FillPolygon(
            brush,
            new PointF[]
            {
                new PointF(rectangle.TopLeft.X, 1920.0f - rectangle.TopLeft.Y),
                new PointF(rectangle.TopRight.X, 1920.0f - rectangle.TopRight.Y),
                new PointF(rectangle.BottomRight.X, 1920.0f - rectangle.BottomRight.Y),
                new PointF(rectangle.BottomLeft.X, 1920.0f - rectangle.BottomLeft.Y),
            }
        );
}
