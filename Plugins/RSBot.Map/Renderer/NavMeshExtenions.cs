using System.Drawing;
using RSBot.NavMeshApi.Edges;

namespace RSBot.Map.Renderer;

public static class NavMeshExtenions
{
    public static Pen ToPen(this NavMeshEdgeFlag flag)
    {
        if ((flag & NavMeshEdgeFlag.Blocked) != 0)
            return Pens.Red;

        if ((flag & NavMeshEdgeFlag.Railing) != 0)
            return Pens.Blue;

        return Pens.Lime;
    }

    internal static Color ToColor(this int i)
    {
        // https://discussions.unity.com/t/how-can-i-get-the-pre-defined-color-of-a-navmesh-area/193595/3
        static int Bit(int a, int b) => (a & 1 << b) >> b;

        if (i == 0)
            return Color.FromArgb(alpha: 128, red: 0, green: 192, blue: 255);

        int r = (Bit(i, 4) + Bit(i, 1) * 2 + 1) * 63;
        int g = (Bit(i, 3) + Bit(i, 2) * 2 + 1) * 63;
        int b = (Bit(i, 5) + Bit(i, 0) * 2 + 1) * 63;
        return Color.FromArgb(128, r, g, b);
    }
}
