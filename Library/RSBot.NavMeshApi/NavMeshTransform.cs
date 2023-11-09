using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Helper;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public class NavMeshTransform
{
    public Region Region;
    public Vector3 Offset;
    public Vector3 Position => Region.Position + Offset;

    public NavMesh NavMesh => this.Cell?.NavMesh;
    public NavMeshCell Cell { get; set; }
    public NavMeshInst Instance { get; set; }

    public NavMeshTransform(Region region, Vector3 offset)
    {
        Region = region;
        Offset = offset;
    }

    public NavMeshTransform(Vector3 positionn)
    {
        var regionX = (byte)(positionn.X / Region.Width);
        var regionZ = (byte)(positionn.Z / Region.Length);

        Region = new Region(regionX, regionZ);
        Offset = positionn - Region.Position;
    }

    public override string ToString() => $"{Offset} {Region}";

    public void Break()
    {
        // Used to break a position which is exactly on 0 or 1920 after region transition.

        const float breakThreshold = 0.01f;

        if (Offset.X.IsApproximately(Region.Width))
            Offset.X = breakThreshold;
        else if (Offset.X.IsApproximately(0.0f))
            Offset.X = Region.Width - breakThreshold;

        if (Offset.Z.IsApproximately(Region.Length))
            Offset.Z = breakThreshold;
        else if (Offset.Z.IsApproximately(0.0f))
            Offset.Z = Region.Length - breakThreshold;
    }

    public void Normalize()
    {
        if (Region.IsDungeon)
            return;

        while (Offset.X >= Region.Width)
        {
            Region.X++;
            Offset.X -= Region.Width;
        }

        while (Offset.X < 0.0f)
        {
            Region.X--;
            Offset.X += Region.Width;
        }

        while (Offset.Z >= Region.Length)
        {
            Region.Z++;
            Offset.Z -= Region.Length;
        }

        while (Offset.Z < 0.0f)
        {
            Region.Z--;
            Offset.Z += Region.Length;
        }
    }

    public void NormalizeOnce()
    {
        if (Region.IsDungeon)
            return;

        if (Offset.X >= Region.Width)
        {
            Region.X++;
            Offset.X -= Region.Width;
        }

        if (Offset.X < 0.0f)
        {
            Region.X--;
            Offset.X += Region.Width;
        }

        if (Offset.Z >= Region.Length)
        {
            Region.Z++;
            Offset.Z -= Region.Length;
        }

        if (Offset.Z < 0.0f)
        {
            Region.Z--;
            Offset.Z += Region.Length;
        }
    }

    [Obsolete("Slower due to divisions, use Normalize instead")]
    public void NormalizeComplex()
    {
        if (Region.IsDungeon)
            return;

        // move x back into region space
        if (Offset.X >= Region.Width)
        {
            Region.X += (byte)(Offset.X / Region.Width);
            Offset.X %= Region.Width;
        }

        if (Offset.X < 0.0f)
        {
            Region.X += (byte)(Offset.X / Region.Width);
            Offset.X %= Region.Width;
        }

        // move z back into region space
        if (Offset.Z >= Region.Length)
        {
            Region.Z += (byte)(Offset.Z / Region.Length);
            Offset.Z %= Region.Length;
        }

        if (Offset.Z < 0.0f)
        {
            Region.Z += (byte)(Offset.Z / Region.Length);
            Offset.Z %= Region.Length;
        }
    }
}