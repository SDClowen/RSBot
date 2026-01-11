using System.Drawing;
using RSBot.NavMeshApi.Edges;
using SkiaSharp;

namespace RSBot.Map.Renderer;

public static class NavMeshExtenions
{
    public static SKPaint ToStroke(this NavMeshEdgeFlag flag)
    {
        SKPaint paint = new()
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 2,
        };

        if ((flag & NavMeshEdgeFlag.Blocked) != 0)
            paint.Color = SKColors.Red;
        else if ((flag & NavMeshEdgeFlag.Railing) != 0)
            paint.Color = SKColors.Blue;
        else
            paint.Color = SKColors.Lime;

        return paint;
    }
}
