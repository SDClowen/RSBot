using System.Numerics;
using RSBot.NavMeshApi.Cells;
using RSBot.NavMeshApi.Helper;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public class NavMeshTransform
{
    public RID Region;
    public Vector3 Offset;
    public Vector3 Position => Region.Position + Offset;

    public NavMesh NavMesh => this.Cell?.NavMesh;
    public NavMeshCell Cell { get; set; }
    public NavMeshInst Instance { get; set; }

    public NavMeshTransform(RID region, Vector3 offset)
    {
        Region = region;
        Offset = offset;
    }

    public NavMeshTransform(NavMeshTransform transform)
    {
        Region = transform.Region;
        Offset = transform.Offset;
        //this.NavMesh = transform.NavMesh;
        this.Cell = transform.Cell;
        this.Instance = transform.Instance;
    }

    public NavMeshTransform(Vector3 worldPosition)
    {
        var regionX = (byte)(worldPosition.X / RID.Width);
        var regionZ = (byte)(worldPosition.Z / RID.Length);

        Region = new RID(regionX, regionZ);
        Offset = worldPosition - Region.Position;
    }

    public override string ToString() => $"{Offset} {Region}; Cell: {this.Cell}; Instance: {this.Instance}";

    public void Break()
    {
        // Used to break a position which is exactly on 0 or 1920 after region transition.

        const float breakThreshold = 0.01f;

        if (Offset.X.IsApproximately(RID.Width))
            Offset.X = breakThreshold;
        else if (Offset.X.IsApproximately(0.0f))
            Offset.X = RID.Width - breakThreshold;

        if (Offset.Z.IsApproximately(RID.Length))
            Offset.Z = breakThreshold;
        else if (Offset.Z.IsApproximately(0.0f))
            Offset.Z = RID.Length - breakThreshold;
    }

    public void Normalize()
    {
        if (Region.IsDungeon)
            return;

        while (Offset.X >= RID.Width)
        {
            Region.X++;
            Offset.X -= RID.Width;
        }

        while (Offset.X < 0.0f)
        {
            Region.X--;
            Offset.X += RID.Width;
        }

        while (Offset.Z >= RID.Length)
        {
            Region.Z++;
            Offset.Z -= RID.Length;
        }

        while (Offset.Z < 0.0f)
        {
            Region.Z--;
            Offset.Z += RID.Length;
        }
    }

    public void NormalizeOnce()
    {
        if (Region.IsDungeon)
            return;

        if (Offset.X >= RID.Width)
        {
            Region.X++;
            Offset.X -= RID.Width;
        }

        if (Offset.X < 0.0f)
        {
            Region.X--;
            Offset.X += RID.Width;
        }

        if (Offset.Z >= RID.Length)
        {
            Region.Z++;
            Offset.Z -= RID.Length;
        }

        if (Offset.Z < 0.0f)
        {
            Region.Z--;
            Offset.Z += RID.Length;
        }
    }

    [Obsolete("Slower due to divisions, use Normalize instead")]
    public void NormalizeComplex()
    {
        if (Region.IsDungeon)
            return;

        // move x back into region space
        if (Offset.X >= RID.Width)
        {
            Region.X += (byte)(Offset.X / RID.Width);
            Offset.X %= RID.Width;
        }

        if (Offset.X < 0.0f)
        {
            Region.X += (byte)(Offset.X / RID.Width);
            Offset.X %= RID.Width;
        }

        // move z back into region space
        if (Offset.Z >= RID.Length)
        {
            Region.Z += (byte)(Offset.Z / RID.Length);
            Offset.Z %= RID.Length;
        }

        if (Offset.Z < 0.0f)
        {
            Region.Z += (byte)(Offset.Z / RID.Length);
            Offset.Z %= RID.Length;
        }
    }
}
